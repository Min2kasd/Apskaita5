﻿Imports ApskaitaObjects.My.Resources

Namespace Goods

    ''' <summary>
    ''' Represents a collection of goods (stock) that are consumed in production
    ''' and belong to a complex goods production document.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="GoodsComplexOperationProduction">GoodsComplexOperationProduction</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsComponentItemList
        Inherits BusinessListBase(Of GoodsComponentItemList, GoodsComponentItem)

#Region " Business Methods "

        Private _ParentAmount As Double = 0

        ''' <summary>
        ''' Corresponds to <see cref="GoodsComplexOperationProduction.Amount">GoodsComplexOperationProduction.Amount</see>.
        ''' Used to pass data to the child items.
        ''' </summary>
        ''' <remarks></remarks>
        Friend ReadOnly Property ParentAmount() As Double
            Get
                Return CRound(_ParentAmount, ROUNDAMOUNTGOODS)
            End Get
        End Property


        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            Return result
        End Function

        Public Function HasWarnings() As Boolean
            For Each i As GoodsComponentItem In Me
                If i.BrokenRulesCollection.WarningCount > 0 Then Return True
            Next
            Return False
        End Function


        ''' <summary>
        ''' Returns whether the list contains an item for the goods specified.
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' to look for</param>
        ''' <remarks></remarks>
        Public Function ContainsGood(ByVal goodsID As Integer) As Boolean
            For Each i As GoodsComponentItem In Me
                If i.GoodsInfo.ID = goodsID Then Return True
            Next
            For Each i As GoodsComponentItem In Me.DeletedList
                If Not i.IsNew AndAlso i.GoodsInfo.ID = goodsID Then Return True
            Next
            Return False
        End Function

        ''' <summary>
        ''' Returns whether the collection contains goods which value (discard costs)
        ''' are calculated on persistence, i.e. the product costs will not be zero.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function ContainsCalculatedAtRuntimeValueGoods() As Boolean
            For Each c As GoodsComponentItem In Me
                If c.GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent Then Return True
            Next
            Return False
        End Function


        Friend Sub RecalculateForProductionAmount(ByVal ammountInProduction As Double)
            Me.RaiseListChangedEvents = False
            _ParentAmount = ammountInProduction
            For Each c As GoodsComponentItem In Me
                c.RecalculateForProductionAmount(ammountInProduction)
            Next
            Me.RaiseListChangedEvents = True
            Me.ResetBindings()
        End Sub

        Friend Sub SetParentDate(ByVal value As Date)
            RaiseListChangedEvents = False
            For Each i As GoodsComponentItem In Me
                i.SetParentDate(value)
            Next
            RaiseListChangedEvents = True
            ResetBindings()
        End Sub

        Friend Sub SetParentWarehouse(ByVal value As WarehouseInfo)
            For Each i As GoodsComponentItem In Me
                If Not i.ChronologyValidator.FinancialDataCanChange Then
                    Throw New Exception(String.Format(Goods_GoodsComponentItemList_CannotChangeFinancialData, _
                        i.GoodsName, vbCrLf, i.ChronologyValidator.FinancialDataCanChangeExplanation))
                End If
            Next
            RaiseListChangedEvents = False
            For Each i As GoodsComponentItem In Me
                i.SetParentWarehouse(value)
            Next
            RaiseListChangedEvents = True
            ResetBindings()
        End Sub


        ''' <summary>
        ''' Sets costs of the goods to discard (consume) using <see cref="GoodsCostItemList">
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
                Throw New Exception(Goods_GoodsComponentItemList_GoodsCostListEmpty)
            End If

            warnings = ""

            Dim countRequired As Integer = 0
            For Each i As GoodsComponentItem In Me
                If i.GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent Then
                    countRequired += 1
                End If
            Next

            If Not countRequired > 0 Then
                Throw New Exception(Goods_GoodsComponentItemList_NoPersistentGoodsInList)
            End If

            If values.Count <> countRequired Then
                warnings = AddWithNewLine(warnings, String.Format( _
                    Goods_GoodsComponentItemList_GoodsCostsListCountMismatch, _
                    countRequired.ToString(), values.Count.ToString()), False)
            End If

            Dim successCount As Integer = 0
            Dim isFound As Boolean

            RaiseListChangedEvents = False

            For Each value As GoodsCostItem In values

                isFound = False

                For Each i As GoodsComponentItem In Me

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
                        Goods_GoodsComponentItemList_OrphanGoodsCost, _
                        value.GoodsID.ToString()), False)
                End If

            Next

            RaiseListChangedEvents = True
            Me.ResetBindings()

            If Not StringIsNullOrEmpty(warnings) Then
                If successCount > 0 Then
                    warnings = String.Format(Goods_GoodsComponentItemList_RefreshCostsWarning, _
                        successCount.ToString(), values.Count.ToString(), vbCrLf, warnings)
                Else
                    Throw New Exception(String.Format(Goods_GoodsComponentItemList_RefreshCostsException, _
                        vbCrLf, warnings))
                End If
            End If

        End Sub

        ''' <summary>
        ''' Sets costs of the goods to discard (consume) using <see cref="GoodsCostItem">
        ''' query object</see>.
        ''' </summary>
        ''' <param name="value">a query object containing information about the costs 
        ''' of the given goods for a given amount, warehouse and date.</param>
        ''' <remarks></remarks>
        Friend Sub RefreshCosts(ByVal value As GoodsCostItem)

            Dim isFound As Boolean = False

            For Each i As GoodsComponentItem In Me

                If i.GoodsInfo.ID = value.GoodsID Then

                    i.LoadCostInfo(value)
                    isFound = True
                    Exit For

                End If

            Next

            If Not isFound Then
                Throw New Exception(String.Format( _
                    Goods_GoodsComponentItemList_OrphanGoodsCost, _
                    value.GoodsID.ToString()))
            End If

        End Sub

        ''' <summary>
        ''' Gets an array of param objects for a <see cref="GoodsCostItemList">query object</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Function GetGoodsCostsParams() As GoodsCostParam()
            Dim result As New List(Of GoodsCostParam)
            For Each i As GoodsComponentItem In Me
                If i.GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent Then _
                    result.Add(i.GetGoodsCostParam())
            Next
            Return result.ToArray
        End Function

        ''' <summary>
        ''' Gets a total discard costs.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Function GetTotalCosts() As Double
            Dim result As Double = 0
            For Each i As GoodsComponentItem In Me
                result = CRound(result + i.TotalCost)
            Next
            Return result
        End Function

        ''' <summary>
        ''' Adds items in the list to the current collection.
        ''' </summary>
        ''' <param name="list"></param>
        ''' <remarks>Should only be called by a parent complex production document
        ''' because it does not handle CanChangeFinancialData and does not 
        ''' automaticaly initiate reloading of IChronologyValidator of the parent document.
        ''' (ListChanged event fired with type <see cref="ComponentModel.ListChangedType.Reset">ComponentModel.ListChangedType.Reset</see>,
        ''' not ItemAdded or ItemDeleted.</remarks>
        Friend Sub AddRange(ByVal list As GoodsComponentItemList)
            CheckNewListForConcurrentItems(list)
            Me.RaiseListChangedEvents = False
            For Each o As GoodsComponentItem In list
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
        Private Sub CheckNewListForConcurrentItems(ByVal list As GoodsComponentItemList)

            If list Is Nothing OrElse list.Count < 1 Then
                Throw New Exception(Goods_GoodsComponentItemList_NewComponentItemListEmpty)
            End If

            Dim message As String = ""

            For Each newItem As GoodsComponentItem In list
                For Each existingItem As GoodsComponentItem In Me
                    If existingItem.GoodsInfo.ID = newItem.GoodsInfo.ID Then
                        message = AddWithNewLine(message, String.Format("{0} (ID={1})", _
                            existingItem.GoodsInfo.Name, existingItem.GoodsInfo.ID), False)
                        Exit For
                    End If
                Next
            Next

            For Each newItem As GoodsComponentItem In list
                For Each deletedItem As GoodsComponentItem In Me
                    If Not deletedItem.IsNew AndAlso deletedItem.GoodsInfo.ID = newItem.GoodsInfo.ID Then
                        message = AddWithNewLine(message, String.Format("{0} (ID={1})", _
                            deletedItem.GoodsInfo.Name, deletedItem.GoodsInfo.ID), False)
                        Exit For
                    End If
                Next
            Next

            If Not String.IsNullOrEmpty(message) Then
                Throw New Exception(String.Format(Goods_GoodsComponentItemList_DuplicateItemsInNewComponentItemList, _
                    vbCrLf, message))
            End If

        End Sub

        Friend Function GetLimitations() As OperationalLimitList()
            Dim result As New List(Of OperationalLimitList)
            For Each i As GoodsComponentItem In Me
                result.Add(i.ChronologyValidator)
            Next
            Return result.ToArray
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a a collection of new goods components created for 
        ''' goods ID's specified. Use <see cref="GoodsComplexOperationProduction.AddRange">
        ''' GoodsComplexOperationProduction.AddRange</see> method to add them 
        ''' to a complex goods production document.
        ''' </summary>
        ''' <param name="goodsIDs">an array of <see cref="GoodsItem.ID">goods ID's</see>
        ''' that the operation list should be fetched for</param>
        ''' <param name="warehouseID">an <see cref="Warehouse.ID">ID of the warehouse
        ''' that the goods should be discarded from</see></param>
        ''' <param name="parentValidator">a chronologic validator of a parent document
        ''' that the operation list should be fetched for</param>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsComponentItemList(ByVal goodsIDs As Integer(), _
            ByVal warehouseID As Integer, ByVal parentValidator As IChronologicValidator) As GoodsComponentItemList
            Return DataPortal.Create(Of GoodsComponentItemList) _
                (New Criteria(goodsIDs, warehouseID, parentValidator))
        End Function

        ''' <summary>
        ''' Gets a new (empty) GoodsComponentItemList instance for a new production operation.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsComponentItemList() As GoodsComponentItemList
            Return New GoodsComponentItemList
        End Function

        ''' <summary>
        ''' Gets a new GoodsComponentItemList instance for a new production operation
        ''' using a template.
        ''' </summary>
        ''' <param name="calculationComponents">a template for the production stock</param>
        ''' <param name="productionAmount">an amount of the goods produced</param>
        ''' <param name="parentValidator">a parent operation chronology validator</param>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsComponentItemList(ByVal calculationComponents _
            As ProductionComponentItemList, ByVal productionAmount As Double, _
            ByVal parentWarehouse As WarehouseInfo, _
            ByVal parentValidator As IChronologicValidator) As GoodsComponentItemList
            Return New GoodsComponentItemList(calculationComponents, productionAmount, _
                parentWarehouse, parentValidator)
        End Function

        ''' <summary>
        ''' Gets an existing GoodsComponentItemList instance using a database query result.
        ''' </summary>
        ''' <param name="objList">a list of goods operation persistence objects
        ''' containing discard operations data</param>
        ''' <param name="parentValidator">a parent operation chronology validator</param>
        ''' <param name="limitationsDataSource">a datasource for the 
        ''' <see cref="OperationalLimitList">chronologic validator</see></param>
        ''' <remarks></remarks>
        Friend Shared Function GetGoodsComponentItemList(ByVal objList As List(Of OperationPersistenceObject), _
            ByVal parentValidator As IChronologicValidator, ByVal limitationsDataSource As DataTable) As GoodsComponentItemList
            Return New GoodsComponentItemList(objList, parentValidator, limitationsDataSource)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal calculationComponents As ProductionComponentItemList, _
            ByVal productionAmount As Double, ByVal parentWarehouse As WarehouseInfo, _
            ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
            Create(calculationComponents, productionAmount, parentWarehouse, parentValidator)
        End Sub

        Private Sub New(ByVal objList As List(Of OperationPersistenceObject), _
            ByVal parentValidator As IChronologicValidator, ByVal limitationsDataSource As DataTable)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = parentValidator.FinancialDataCanChange
            Fetch(objList, parentValidator, limitationsDataSource)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _IDs As Integer()
            Private _WarehouseID As Integer
            Private _ParentValidator As IChronologicValidator
            Public ReadOnly Property IDs() As Integer()
                Get
                    Return _IDs
                End Get
            End Property
            Public ReadOnly Property WarehouseID() As Integer
                Get
                    Return _WarehouseID
                End Get
            End Property
            Public ReadOnly Property ParentValidator() As IChronologicValidator
                Get
                    Return _ParentValidator
                End Get
            End Property
            Public Sub New(ByVal nIDs As Integer(), ByVal nWarehouseID As Integer, _
                ByVal nParentValidator As IChronologicValidator)
                _IDs = nIDs
                _ParentValidator = nParentValidator
                _WarehouseID = nWarehouseID
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            If Not GoodsComplexOperationProduction.CanAddObject() Then
                Throw New System.Security.SecurityException( _
                    My.Resources.Common_SecuritySelectDenied)
            End If

            If criteria.IDs Is Nothing OrElse criteria.IDs.Length < 1 Then
                Throw New Exception(Goods_GoodsComponentItemList_GoodsIdsNull)
            End If

            Dim parentWarehouse As WarehouseInfo = WarehouseInfoList.GetListChild. _
                GetItem(criteria.WarehouseID, False)

            RaiseListChangedEvents = False

            For Each goodsID As Integer In criteria.IDs
                Add(GoodsComponentItem.NewGoodsComponentItem( _
                    goodsID, parentWarehouse, criteria.ParentValidator))
            Next

            RaiseListChangedEvents = True

        End Sub

        Private Sub Create(ByVal calculationComponents As ProductionComponentItemList, _
            ByVal productionAmount As Double, ByVal parentWarehouse As WarehouseInfo, _
            ByVal parentValidator As IChronologicValidator)

            RaiseListChangedEvents = False

            _ParentAmount = productionAmount

            For Each obj As ProductionComponentItem In calculationComponents
                Add(GoodsComponentItem.NewGoodsComponentItem(obj, productionAmount, _
                    parentWarehouse, parentValidator))
            Next

            RaiseListChangedEvents = True

        End Sub

        Private Sub Fetch(ByVal objList As List(Of OperationPersistenceObject), _
            ByVal parentValidator As IChronologicValidator, ByVal limitationsDataSource As DataTable)

            Dim productionAmount As Double = 0
            Dim acquisitionMissing As Boolean = True
            For Each obj As OperationPersistenceObject In objList
                If obj.OperationType = GoodsOperationType.Acquisition Then
                    productionAmount = obj.Amount
                    acquisitionMissing = False
                    Exit For
                End If
            Next

            If acquisitionMissing Then
                Throw New Exception(Goods_GoodsComponentItemList_AcquisitionMissing)
            End If

            RaiseListChangedEvents = False

            _ParentAmount = productionAmount

            For Each obj As OperationPersistenceObject In objList
                If obj.OperationType = GoodsOperationType.Discard Then _
                    Add(GoodsComponentItem.GetGoodsComponentItem(obj, productionAmount, _
                        parentValidator, limitationsDataSource))
            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByVal parent As GoodsComplexOperationProduction)

            RaiseListChangedEvents = False

            For Each item As GoodsComponentItem In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As GoodsComponentItem In Me
                If item.IsNew OrElse item.IsDirty Then
                    item.Update(parent)
                End If
            Next

            RaiseListChangedEvents = True

        End Sub


        Friend Function GetBookEntryInternalList() As BookEntryInternalList

            Dim result As BookEntryInternalList = BookEntryInternalList. _
                NewBookEntryInternalList(BookEntryType.Kreditas)

            ' goods discard costs are preloaded in CheckIfCanUpdate method
            RaiseListChangedEvents = False
            For Each c As GoodsComponentItem In Me
                result.Add(c.GetBookEntryInternal())
            Next
            RaiseListChangedEvents = True

            Return result

        End Function


        Friend Sub CheckIfCanUpdate(ByVal parent As GoodsComplexOperationProduction, _
            ByVal limitationsDataSource As DataTable)

            For Each i As GoodsComponentItem In Me
                i.SetParentDate(parent.Date) ' just in case
                i.SetParentAcquisitionAccount(parent.AcquisitionAccount)
                i.SetParentProperties(parent.DocumentNumber, parent.Content)
                If i.IsDirty Then i.CheckIfCanUpdate(parent.ChronologyValidatorDiscard. _
                    BaseValidator, limitationsDataSource)
            Next

            For Each i As GoodsComponentItem In Me.DeletedList
                If Not i.IsNew Then i.CheckIfCanDelete(limitationsDataSource, _
                    parent.ChronologyValidatorDiscard.BaseValidator)
            Next

        End Sub

#End Region

    End Class

End Namespace