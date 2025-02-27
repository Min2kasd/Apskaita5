﻿Imports ApskaitaObjects.My.Resources

Namespace Goods

    ''' <summary>
    ''' Represents a collection of goods consignments.
    ''' </summary>
    ''' <remarks>Values are stored in the database table consignments.</remarks>
    <Serializable()> _
    Friend Class ConsignmentPersistenceObjectList
        Inherits BusinessListBase(Of ConsignmentPersistenceObjectList, ConsignmentPersistenceObject)

#Region " Business Methods "

        Friend Sub MergeChangedList(ByVal finalListView As ConsignmentPersistenceObjectList)

            Dim isFound As Boolean = False

            For i As Integer = Me.Count - 1 To 0 Step -1
                isFound = False
                For Each d As ConsignmentPersistenceObject In finalListView
                    If Item(i).AcquisitionID = d.AcquisitionID Then
                        isFound = True
                        Exit For
                    End If
                Next
                If Not isFound Then Me.RemoveAt(i)
            Next

            For Each d As ConsignmentPersistenceObject In finalListView
                isFound = False
                For Each c As ConsignmentPersistenceObject In Me
                    If c.AcquisitionID = d.AcquisitionID Then
                        isFound = True
                        c.Amount = d.Amount
                        c.TotalValue = d.TotalValue
                        c.UnitValue = d.UnitValue
                        Exit For
                    End If
                Next
                If Not isFound Then Me.Add(d.Clone)
            Next

        End Sub

        ''' <summary>
        ''' Gets a <see cref="ConsignmentPersistenceObject.TotalValue">total value</see>
        ''' of all the consignments in the list.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetTotalValue() As Double
            Dim result As Double = 0
            For Each entry As ConsignmentPersistenceObject In Me
                result = CRound(result + entry.TotalValue)
            Next
            Return result
        End Function

        ''' <summary>
        ''' Gets a <see cref="ConsignmentPersistenceObject.TotalValueLeft">total 
        ''' residual value</see> of all the consignments in the list.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetTotalValueLeft() As Double
            Dim result As Double = 0
            For Each entry As ConsignmentPersistenceObject In Me
                result = CRound(result + entry.TotalValueLeft)
            Next
            Return result
        End Function

        ''' <summary>
        ''' Gets a <see cref="ConsignmentPersistenceObject.AmountLeft">total 
        ''' residual amount</see> of all the consignments in the list.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetTotalAmountLeft() As Double
            Dim result As Double = 0
            For Each entry As ConsignmentPersistenceObject In Me
                result = CRound(result + entry.AmountLeft, ROUNDAMOUNTGOODS)
            Next
            Return result
        End Function

        ''' <summary>
        ''' Removes the consignments that were acquired after the date specified.
        ''' </summary>
        ''' <param name="dateLimit">latest allowed consignment acquisition date</param>
        ''' <remarks></remarks>
        Friend Sub RemoveLateEntries(ByVal dateLimit As Date)

            If dateLimit = Date.MinValue OrElse dateLimit = Date.MaxValue OrElse Me.Count < 1 Then Exit Sub

            RaiseListChangedEvents = False

            For i As Integer = Me.Count - 1 To 0 Step -1
                If Item(i).AcquisitionDate.Date > dateLimit.Date Then RemoveAt(i)
            Next

            RaiseListChangedEvents = True

        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new ConsignmentPersistenceObjectList instance that contains 
        ''' goods consignments in a warehouse available for discard by a parent goods
        ''' operation.
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see> 
        ''' for which the consignments should be fetched</param>
        ''' <param name="warehouseID">an <see cref="Warehouse.ID">ID of the warehouse</see> 
        ''' for which the consignments should be fetched</param>
        ''' <param name="discardParentID">an <see cref="OperationPersistenceObject.ID">
        ''' ID of the parent goods operation</see> that is also a parent of 
        ''' <see cref="ConsignmentDiscardPersistenceObject.ParentID">
        ''' goods consignements discard</see>. (in order to ignore consignments discards 
        ''' that are part of the parent operation)</param>
        ''' <param name="consignmentParentID">an <see cref="OperationPersistenceObject.ID">
        ''' ID of the parent goods operation</see> that is also a parent of 
        ''' <see cref="ConsignmentPersistenceObject.ParentID">goods consignements</see>. 
        ''' (in order to ignore consignments that are part of the parent operation)</param>
        ''' <param name="orderDesc">whether to sort the consignments by date in 
        ''' descending order (for value calculation or discard using <see cref="GoodsValuationMethod.LIFO">
        ''' LIFO valuation method</see>)</param>
        ''' <remarks></remarks>
        Friend Shared Function NewConsignmentPersistenceObjectList(ByVal goodsID As Integer, _
            ByVal warehouseID As Integer, ByVal discardParentID As Integer, _
            ByVal consignmentParentID As Integer, ByVal orderDesc As Boolean) As ConsignmentPersistenceObjectList
            Return New ConsignmentPersistenceObjectList(goodsID, warehouseID, _
                discardParentID, consignmentParentID, orderDesc)
        End Function

        ''' <summary>
        ''' Gets an existing ConsignmentPersistenceObjectList instance from a database
        ''' for a specified parent goods operation.
        ''' </summary>
        ''' <param name="parentID">an <see cref="OperationPersistenceObject.ID">
        ''' ID of the goods operation</see> that owns a list of consignments</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Shared Function GetConsignmentPersistenceObjectList(ByVal parentID As Integer) _
            As ConsignmentPersistenceObjectList
            Return New ConsignmentPersistenceObjectList(parentID)
        End Function

        Friend Shared Function GetConsignmentPersistenceObjectList(ByVal warehouseID As Integer, _
            ByVal parentID As Integer) As Dictionary(Of Integer, ConsignmentPersistenceObjectList)

            If Not parentID > 0 Then parentID = -1

            Dim myComm As New SQLCommand("FetchConsignmentPersistenceObjectListForWarehouse")
            myComm.AddParam("?WD", warehouseID)
            myComm.AddParam("?CD", parentID)

            Dim result As Dictionary(Of Integer, ConsignmentPersistenceObjectList)

            Using myData As DataTable = myComm.Fetch

                result = New Dictionary(Of Integer, ConsignmentPersistenceObjectList)

                For Each dr As DataRow In myData.Rows

                    If CIntSafe(dr.Item(10), 0) > 0 AndAlso Not result.ContainsKey(CIntSafe(dr.Item(10), 0)) Then
                        result.Add(CIntSafe(dr.Item(10), 0), New ConsignmentPersistenceObjectList(myData, _
                            CIntSafe(dr.Item(10), 0)))
                    End If

                Next

            End Using

            Return result

        End Function

        Friend Shared Function GetConsignmentPersistenceObjectList( _
            ByVal availableConsignments As ConsignmentPersistenceObjectList, _
            ByVal amountRequired As Double) As ConsignmentPersistenceObjectList
            Return New ConsignmentPersistenceObjectList(availableConsignments, amountRequired)
        End Function


        ''' <summary>
        ''' Gets a ConsignmentPersistenceObjectList instance that is 
        ''' a clone of the current list, but the order of the items 
        ''' within the list is inverted.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Function GetInvertedList() As ConsignmentPersistenceObjectList

            Dim result As New ConsignmentPersistenceObjectList

            result.RaiseListChangedEvents = False

            For i As Integer = Me.Count - 1 To 0 Step -1
                result.Add(Me.Item(i - 1).Clone)
            Next

            result.RaiseListChangedEvents = True

            Return result

        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal parentID As Integer)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Fetch(parentID)
        End Sub

        Private Sub New(ByVal goodsID As Integer, ByVal warehouseID As Integer, _
            ByVal discardParentID As Integer, ByVal consignmentParentID As Integer, _
            ByVal orderDesc As Boolean)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Fetch(goodsID, warehouseID, discardParentID, consignmentParentID, orderDesc)
        End Sub

        Private Sub New(ByVal availableConsignments As ConsignmentPersistenceObjectList, _
            ByVal amountRequired As Double)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Fetch(availableConsignments, amountRequired)
        End Sub

        Private Sub New(ByVal myData As DataTable, ByVal goodsID As Integer)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            DoFetch(myData, goodsID)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal parentID As Integer)

            If Not parentID > 0 Then parentID = -1

            Dim myComm As New SQLCommand("FetchConsignmentPersistenceObjectListForParent")
            myComm.AddParam("?CD", parentID)

            DoFetch(myComm, False, True)

        End Sub

        Private Sub Fetch(ByVal goodsID As Integer, ByVal warehouseID As Integer, _
            ByVal discardParentID As Integer, ByVal consignmentParentID As Integer, _
            ByVal orderDesc As Boolean)

            If Not discardParentID > 0 Then discardParentID = -1
            If Not consignmentParentID > 0 Then consignmentParentID = -1

            Dim myComm As New SQLCommand("FetchConsignmentPersistenceObjectList")
            myComm.AddParam("?GD", goodsID)
            myComm.AddParam("?WD", warehouseID)
            myComm.AddParam("?OD", discardParentID)
            myComm.AddParam("?PD", consignmentParentID)

            DoFetch(myComm, orderDesc, False)

        End Sub

        Private Sub Fetch(ByVal availableConsignments As ConsignmentPersistenceObjectList, _
            ByVal amountRequired As Double)

            RaiseListChangedEvents = False

            For Each c As ConsignmentPersistenceObject In availableConsignments

                Add(ConsignmentPersistenceObject.NewConsignmentPersistenceObject(c, amountRequired))

                If Not CRound(amountRequired, ROUNDUNITGOODS) > 0 Then Exit For

            Next

            If CRound(amountRequired, ROUNDAMOUNTGOODS) > 0 Then
                Throw New Exception(Goods_ConsignmentPersistenceObjectList_InsufficientAmountInWarehouse)
            End If

            RaiseListChangedEvents = True

        End Sub

        Private Sub DoFetch(ByVal myComm As SQLCommand, ByVal orderDesc As Boolean, ByVal isForUpdate As Boolean)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Exit Sub

                RaiseListChangedEvents = False

                If orderDesc Then

                    For i As Integer = myData.Rows.Count - 1 To 0 Step -1
                        Add(ConsignmentPersistenceObject.GetConsignmentPersistenceObject(myData.Rows(i), isForUpdate))
                    Next

                Else

                    For Each dr As DataRow In myData.Rows
                        Add(ConsignmentPersistenceObject.GetConsignmentPersistenceObject(dr, isForUpdate))
                    Next

                End If

                RaiseListChangedEvents = True

            End Using

        End Sub

        Private Sub DoFetch(ByVal myData As DataTable, ByVal goodsID As Integer)

            RaiseListChangedEvents = False

            For Each dr As DataRow In myData.Rows
                If CIntSafe(dr.Item(10), 0) = goodsID Then _
                    Add(ConsignmentPersistenceObject.GetConsignmentPersistenceObject(dr, False))
            Next

            RaiseListChangedEvents = True

        End Sub


        Friend Sub Update(ByVal parentID As Integer, ByVal parentWarehouseID As Integer)

            RaiseListChangedEvents = False

            For Each item As ConsignmentPersistenceObject In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As ConsignmentPersistenceObject In Me
                If item.IsNew Then
                    item.Insert(parentID, parentWarehouseID)
                ElseIf item.IsDirty Then
                    item.Update(parentID)
                End If
            Next

            RaiseListChangedEvents = True

        End Sub

        'Friend Shared Sub UpdateWarehouse(ByVal parentID As Integer, _
        '    ByVal parentWarehouseID As Integer)

        '    Dim myComm As New SQLCommand("UpdateConsignmentDiscardPersistenceObjectWarehouse")
        '    myComm.AddParam("?PD", parentID)
        '    myComm.AddParam("?WD", parentWarehouseID)

        '    myComm.Execute()

        'End Sub

#End Region

    End Class

End Namespace