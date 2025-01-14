﻿Imports ApskaitaObjects.My.Resources
Namespace Goods

    ''' <summary>
    ''' Represents a collection of simple goods transfer operations
    ''' that belong to a complex goods transfer document.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="GoodsComplexOperationInternalTransfer">GoodsComplexOperationInternalTransfer</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsInternalTransferItemList
        Inherits BusinessListBase(Of GoodsInternalTransferItemList, GoodsInternalTransferItem)

#Region " Business Methods "

        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            Return result
        End Function

        Public Function HasWarnings() As Boolean
            For Each i As GoodsInternalTransferItem In Me
                If i.HasWarnings Then Return True
            Next
            Return False
        End Function


        Friend Sub SetParentDate(ByVal value As Date)
            RaiseListChangedEvents = False
            For Each i As GoodsInternalTransferItem In Me
                i.SetParentDate(value)
            Next
            RaiseListChangedEvents = True
        End Sub

        Friend Sub SetWarehouseFrom(ByVal value As WarehouseInfo)
            RaiseListChangedEvents = False
            For Each i As GoodsInternalTransferItem In Me
                i.SetParentWarehouseFrom(value)
            Next
            RaiseListChangedEvents = True
        End Sub

        Friend Sub SetWarehouseTo(ByVal value As WarehouseInfo)
            RaiseListChangedEvents = False
            For Each i As GoodsInternalTransferItem In Me
                i.SetParentWarehouseTo(value)
            Next
            RaiseListChangedEvents = True
        End Sub


        ''' <summary>
        ''' Returns whether the list contains an item for the goods specified.
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' to look for</param>
        ''' <remarks></remarks>
        Public Function ContainsGood(ByVal goodsID As Integer) As Boolean
            For Each i As GoodsInternalTransferItem In Me
                If i.GoodsInfo.ID = goodsID Then Return True
            Next
            For Each i As GoodsInternalTransferItem In Me.DeletedList
                If Not i.IsNew AndAlso i.GoodsInfo.ID = goodsID Then Return True
            Next
            Return False
        End Function

        ''' <summary>
        ''' Sets costs of the goods to transfer using <see cref="GoodsCostItemList">
        ''' query object</see>.
        ''' </summary>
        ''' <param name="values">a query object containing information about the costs 
        ''' of the goods for a given amount, warehouse and date.</param>
        ''' <param name="warnings">an out parameter that returns a description of 
        ''' non critical errors encountered while seting the data</param>
        ''' <remarks></remarks>
        Friend Sub RefreshCosts(ByVal values As GoodsCostItemList, _
            ByRef warnings As String)

            If values Is Nothing OrElse values.Count < 1 Then
                Throw New Exception(Goods_GoodsInternalTransferItemList_GoodsCostListEmpty)
            End If

            warnings = ""

            If values.Count <> Me.Count Then
                warnings = AddWithNewLine(warnings, String.Format( _
                    Goods_GoodsInternalTransferItemList_GoodsCostsListCountMismatch, _
                    Me.Count.ToString(), values.Count.ToString()), False)
            End If

            Dim successCount As Integer = 0
            Dim isFound As Boolean

            RaiseListChangedEvents = False

            For Each value As GoodsCostItem In values

                isFound = False

                For Each i As GoodsInternalTransferItem In Me

                    If i.GoodsInfo.ID = value.GoodsID Then

                        Try
                            i.LoadCostInfo(value)
                            successCount += 1
                        Catch ex As Exception
                            warnings = AddWithNewLine(warnings, ex.Message, False)
                        End Try

                        isFound = True
                        Exit For

                    End If

                Next

                If Not isFound Then
                    warnings = AddWithNewLine(warnings, String.Format( _
                        Goods_GoodsInternalTransferItemList_OrphanGoodsCost, _
                        value.GoodsID.ToString()), False)
                End If

            Next

            RaiseListChangedEvents = True
            Me.ResetBindings()

            If Not StringIsNullOrEmpty(warnings) Then
                If successCount > 0 Then
                    warnings = String.Format(Goods_GoodsInternalTransferItemList_RefreshCostsWarning, _
                        successCount.ToString(), values.Count.ToString(), vbCrLf, warnings)
                Else
                    Throw New Exception(String.Format(Goods_GoodsInternalTransferItemList_RefreshCostsException, _
                        vbCrLf, warnings))
                End If
            End If

        End Sub

        ''' <summary>
        ''' Sets costs of the goods to transfer using <see cref="GoodsCostItem">
        ''' query object</see>.
        ''' </summary>
        ''' <param name="value">a query object containing information about the costs 
        ''' of the given goods for a given amount, warehouse and date.</param>
        ''' <remarks></remarks>
        Friend Sub RefreshCosts(ByVal value As GoodsCostItem)

            Dim isFound As Boolean = False

            For Each i As GoodsInternalTransferItem In Me

                If i.GoodsInfo.ID = value.GoodsID Then

                    i.LoadCostInfo(value)
                    isFound = True
                    Exit For

                End If

            Next

            If Not isFound Then
                Throw New Exception(String.Format( _
                    Goods_GoodsInternalTransferItemList_OrphanGoodsCost, _
                    value.GoodsID.ToString()))
            End If

        End Sub

        ''' <summary>
        ''' Gets an array of param objects for a <see cref="GoodsCostItemList">query object</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Function GetGoodsCostsParams() As GoodsCostParam()
            Dim result As New List(Of GoodsCostParam)
            For Each i As GoodsInternalTransferItem In Me
                result.Add(i.GetGoodsCostParam())
            Next
            Return result.ToArray
        End Function

        ''' <summary>
        ''' Gets a total costs of the goods transfered.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Function GetTotalCosts() As Double
            Dim result As Double = 0
            For Each i As GoodsInternalTransferItem In Me
                result = CRound(result + i.TotalCost)
            Next
            Return result
        End Function

        ''' <summary>
        ''' Adds items in the list to the current collection.
        ''' </summary>
        ''' <param name="list"></param>
        ''' <remarks>Should only be called by a parent complex internal transfer document
        ''' because it does not handle CanChangeFinancialData and does not 
        ''' automaticaly initiate reloading of IChronologyValidator of the parent document.
        ''' (ListChanged event fired with type <see cref="ComponentModel.ListChangedType.Reset">ComponentModel.ListChangedType.Reset</see>,
        ''' not ItemAdded or ItemDeleted.</remarks>
        Friend Sub AddRange(ByVal list As GoodsInternalTransferItemList)
            CheckNewListForConcurrentItems(list)
            Me.RaiseListChangedEvents = False
            For Each o As GoodsInternalTransferItem In list
                Add(o.Clone())
            Next
            Me.RaiseListChangedEvents = True
            Me.ResetBindings()
        End Sub

        ''' <summary>
        ''' Checks a new items list for concurrent items that already exists
        ''' in the document or were deleted from the document. Throws exception
        ''' if concurrent items are found or the new item list is null or empty. 
        ''' </summary>
        ''' <param name="list"></param>
        ''' <remarks></remarks>
        Private Sub CheckNewListForConcurrentItems(ByVal list As GoodsInternalTransferItemList)

            If list Is Nothing OrElse list.Count < 1 Then
                Throw New Exception(Goods_GoodsInternalTransferItemList_NewInternalTransferItemListEmpty)
            End If

            Dim message As String = ""

            For Each newItem As GoodsInternalTransferItem In list
                For Each existingItem As GoodsInternalTransferItem In Me
                    If existingItem.GoodsInfo.ID = newItem.GoodsInfo.ID Then
                        message = AddWithNewLine(message, String.Format("{0} (ID={1})", _
                            existingItem.GoodsInfo.Name, existingItem.GoodsInfo.ID), False)
                        Exit For
                    End If
                Next
            Next

            For Each newItem As GoodsInternalTransferItem In list
                For Each deletedItem As GoodsInternalTransferItem In Me
                    If Not deletedItem.IsNew AndAlso deletedItem.GoodsInfo.ID = newItem.GoodsInfo.ID Then
                        message = AddWithNewLine(message, String.Format("{0} (ID={1})", _
                            deletedItem.GoodsInfo.Name, deletedItem.GoodsInfo.ID), False)
                        Exit For
                    End If
                Next
            Next

            If Not String.IsNullOrEmpty(message) Then
                Throw New Exception(String.Format(Goods_GoodsInternalTransferItemList_DuplicateItemsInNewInternalTransferItemList, _
                    vbCrLf, message))
            End If

        End Sub

        Friend Function GetLimitations(ByVal forAcquisitions As Boolean) As OperationalLimitList()
            Dim result As New List(Of OperationalLimitList)
            For Each i As GoodsInternalTransferItem In Me
                If forAcquisitions Then
                    result.Add(i.ChronologyValidatorAcquisition)
                Else
                    result.Add(i.ChronologyValidatorTransfer)
                End If
            Next
            Return result.ToArray
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a a collection of new goods internal transfer items created for 
        ''' goods ID's specified. Use <see cref="GoodsComplexOperationInternalTransfer.AddRange">
        ''' GoodsComplexOperationInternalTransfer.AddRange</see> method to add them 
        ''' to a complex goods internal transfer document.
        ''' </summary>
        ''' <param name="goodsIDs">an array of <see cref="GoodsItem.ID">goods ID's</see>
        ''' that the operation list should be fetched for</param>
        ''' <param name="warehouseFromID">an <see cref="Warehouse.ID">ID of the warehouse</see>
        ''' that the goods should be transfered (discarded) from</param>
        ''' <param name="warehouseToID">an <see cref="Warehouse.ID">ID of the warehouse</see>
        ''' that the goods should be transfered (acquired) to</param>
        ''' <param name="parentValidator">a chronologic validator of a parent document
        ''' that the operation list should be fetched for</param>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsInternalTransferItemList(ByVal goodsIDs As Integer(), _
            ByVal warehouseFromID As Integer, ByVal warehouseToID As Integer, _
            ByVal parentValidator As IChronologicValidator) As GoodsInternalTransferItemList
            Return DataPortal.Create(Of GoodsInternalTransferItemList) _
                (New Criteria(goodsIDs, warehouseFromID, warehouseToID, parentValidator))
        End Function

        ''' <summary>
        ''' Gets a new (empty) GoodsInternalTransferItemList instance for 
        ''' a new complex internal transfer operation.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsInternalTransferItemList() As GoodsInternalTransferItemList
            Return New GoodsInternalTransferItemList
        End Function

        ''' <summary>
        ''' Gets an existing GoodsInternalTransferItemList instance 
        ''' using a database query result.
        ''' </summary>
        ''' <param name="objList">a list of goods operation persistence objects
        ''' containing encapsulated simple operations data</param>
        ''' <param name="parentValidator">a parent operation chronology validator</param>
        ''' <param name="limitationsDataSource">a datasource for the 
        ''' <see cref="OperationalLimitList">chronologic validator</see></param>
        ''' <remarks></remarks>
        Friend Shared Function GetGoodsInternalTransferItemList( _
            ByVal objList As List(Of OperationPersistenceObject), _
            ByVal limitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator) As GoodsInternalTransferItemList
            Return New GoodsInternalTransferItemList(objList, limitationsDataSource, parentValidator)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal objList As List(Of OperationPersistenceObject), _
            ByVal limitationsDataSource As DataTable, ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
            Fetch(objList, limitationsDataSource, parentValidator)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _IDs As Integer()
            Private _WarehouseFromID As Integer
            Private _WarehouseToID As Integer
            Private _ParentValidator As IChronologicValidator
            Public ReadOnly Property IDs() As Integer()
                Get
                    Return _IDs
                End Get
            End Property
            Public ReadOnly Property WarehouseFromID() As Integer
                Get
                    Return _WarehouseFromID
                End Get
            End Property
            Public ReadOnly Property WarehouseToID() As Integer
                Get
                    Return _WarehouseToID
                End Get
            End Property
            Public ReadOnly Property ParentValidator() As IChronologicValidator
                Get
                    Return _ParentValidator
                End Get
            End Property
            Public Sub New(ByVal nIDs As Integer(), ByVal nWarehouseFromID As Integer, _
                ByVal nWarehouseToID As Integer, ByVal nParentValidator As IChronologicValidator)
                _IDs = nIDs
                _ParentValidator = nParentValidator
                _WarehouseFromID = nWarehouseFromID
                _WarehouseToID = nWarehouseToID
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            If Not GoodsComplexOperationInternalTransfer.CanAddObject() Then
                Throw New System.Security.SecurityException( _
                    My.Resources.Common_SecuritySelectDenied)
            End If

            If criteria.IDs Is Nothing OrElse criteria.IDs.Length < 1 Then
                Throw New Exception(Goods_GoodsInternalTransferItemList_GoodsIdsNull)
            End If

            Dim list As WarehouseInfoList = WarehouseInfoList.GetListChild
            Dim parentWarehouseFrom As WarehouseInfo = list.GetItem(criteria.WarehouseFromID, False)
            Dim parentWarehouseTo As WarehouseInfo = list.GetItem(criteria.WarehouseToID, False)

            RaiseListChangedEvents = False

            For Each goodsID As Integer In criteria.IDs
                Add(GoodsInternalTransferItem.NewGoodsInternalTransferItem( _
                    goodsID, parentWarehouseFrom, parentWarehouseTo, _
                    criteria.ParentValidator))
            Next

            RaiseListChangedEvents = True

        End Sub


        Private Sub Fetch(ByVal objList As List(Of OperationPersistenceObject), _
            ByVal limitationsDataSource As DataTable, ByVal parentValidator As IChronologicValidator)

            RaiseListChangedEvents = False

            For Each obj As OperationPersistenceObject In objList

                If obj.OperationType <> GoodsOperationType.Transfer AndAlso _
                    obj.OperationType <> GoodsOperationType.Acquisition Then
                    Throw New Exception(String.Format(Goods_GoodsInternalTransferItemList_ChildOperationDataCorrupt, _
                        ConvertLocalizedName(obj.OperationType)))
                End If

                If obj.OperationType = GoodsOperationType.Acquisition Then
                    MyBase.Add(GoodsInternalTransferItem.GetGoodsInternalTransferItem( _
                        obj, GetOperationPair(obj.GoodsInfo.ID, objList), _
                        limitationsDataSource, parentValidator))
                End If

            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByVal parent As GoodsComplexOperationInternalTransfer)

            RaiseListChangedEvents = False

            For Each item As GoodsInternalTransferItem In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As GoodsInternalTransferItem In Me
                If item.IsNew OrElse item.IsDirty Then
                    item.Update(parent)
                End If
            Next

            RaiseListChangedEvents = True

        End Sub


        Private Function GetOperationPair(ByVal goodsID As Integer, _
            ByVal objList As List(Of OperationPersistenceObject)) As OperationPersistenceObject

            For Each obj As OperationPersistenceObject In objList
                If obj.OperationType = GoodsOperationType.Transfer AndAlso _
                    obj.GoodsInfo.ID = goodsID Then
                    Return obj
                End If
            Next

            Throw New Exception(String.Format(Goods_GoodsInternalTransferItemList_OperationPairNotFound, _
                goodsID.ToString))

        End Function

        Friend Sub CheckIfCanUpdate(ByVal parent As GoodsComplexOperationInternalTransfer, _
            ByVal limitationsDataSource As DataTable)

            For Each i As GoodsInternalTransferItem In Me
                i.SetParentProperties(parent.DocumentNumber, parent.Content)
                If i.IsDirty Then
                    i.PrepareConsignements()
                    i.CheckIfCanUpdate(parent.OperationalLimitAcquisition.BaseValidator, _
                        limitationsDataSource)
                End If
            Next

            For Each i As GoodsInternalTransferItem In Me.DeletedList
                If Not i.IsNew Then
                    i.CheckIfCanDelete(parent.OperationalLimitAcquisition.BaseValidator, _
                        limitationsDataSource)
                End If
            Next

        End Sub

        Friend Function GetBookEntryInternalList() As BookEntryInternalList
            Dim result As BookEntryInternalList = BookEntryInternalList. _
                NewBookEntryInternalList(BookEntryType.Debetas)
            For Each i As GoodsInternalTransferItem In Me
                result.AddRange(i.GetBookEntryInternalList())
            Next
            Return result
        End Function

#End Region

    End Class

End Namespace