﻿Imports ApskaitaObjects.My.Resources

Namespace Goods

    ''' <summary>
    ''' Represents a <see cref="ConsignmentPersistenceObject">goods consignments</see>
    ''' discard transaction, i.e. a collection of individual consignment discard items.
    ''' </summary>
    ''' <remarks>Discards a certain amount of goods from <see cref="ConsignmentPersistenceObject">
    ''' goods consignments</see> when the goods are transfered from a warehouse
    ''' or discarded.
    ''' Values are stored in the database table consignmentdiscards.</remarks>
    <Serializable()> _
    Friend Class ConsignmentDiscardPersistenceObjectList
        Inherits BusinessListBase(Of ConsignmentDiscardPersistenceObjectList, ConsignmentDiscardPersistenceObject)

#Region " Business Methods "

        Friend Sub MergeChangedList(ByVal finalListView As ConsignmentDiscardPersistenceObjectList)

            Dim isFound As Boolean = False

            For i As Integer = Me.Count - 1 To 0 Step -1
                isFound = False
                For Each d As ConsignmentDiscardPersistenceObject In finalListView
                    If Item(i).ConsignmentID = d.ConsignmentID Then
                        isFound = True
                        Exit For
                    End If
                Next
                If Not isFound Then Me.RemoveAt(i)
            Next

            For Each d As ConsignmentDiscardPersistenceObject In finalListView
                isFound = False
                For Each c As ConsignmentDiscardPersistenceObject In Me
                    If c.ConsignmentID = d.ConsignmentID Then
                        isFound = True
                        c.Amount = d.Amount
                        c.TotalValue = d.TotalValue
                        Exit For
                    End If
                Next
                If Not isFound Then Me.Add(d.Clone)
            Next

        End Sub

        ''' <summary>
        ''' Gets a <see cref="ConsignmentDiscardPersistenceObject.TotalValue">
        ''' total value of the goods dicarded</see> in the transaction.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetTotalValue() As Double
            Dim result As Double = 0
            For Each entry As ConsignmentDiscardPersistenceObject In Me
                result = CRound(result + entry.TotalValue)
            Next
            Return result
        End Function

        ''' <summary>
        ''' Gets a <see cref="ConsignmentDiscardPersistenceObject.Amount">
        ''' total amount of the goods dicarded</see> in the transaction.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetTotalAmount() As Double
            Dim result As Double = 0
            For Each entry As ConsignmentDiscardPersistenceObject In Me
                result = CRound(result + entry.Amount, ROUNDAMOUNTGOODS)
            Next
            Return result
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new ConsignmentDiscardPersistenceObjectList instance.
        ''' </summary>
        ''' <param name="availableConsignments">a collection of consignments 
        ''' that could be discarded by the parent goods operation
        ''' (use <see cref="ConsignmentPersistenceObjectList.NewConsignmentPersistenceObjectList">
        ''' ConsignmentPersistenceObjectList.GetConsignmentPersistenceObjectList</see>
        ''' method to fetch available consignments)</param>
        ''' <param name="amountRequired">an amount that the parent goods operation
        ''' needs to discard</param>
        ''' <param name="goodsName">a name of the goods</param>
        ''' <remarks></remarks>
        Friend Shared Function NewConsignmentDiscardPersistenceObjectList( _
            ByVal availableConsignments As ConsignmentPersistenceObjectList, _
            ByVal amountRequired As Double, ByVal goodsName As String) As ConsignmentDiscardPersistenceObjectList
            Return New ConsignmentDiscardPersistenceObjectList(availableConsignments, _
                amountRequired, goodsName)
        End Function

        ''' <summary>
        ''' Gets an existing ConsignmentDiscardPersistenceObjectList instance
        ''' for a parent goods operation from a database.
        ''' </summary>
        ''' <param name="parentID">an ID of the parent goods operation</param>
        ''' <remarks></remarks>
        Friend Shared Function GetConsignmentDiscardPersistenceObjectList( _
            ByVal parentID As Integer) As ConsignmentDiscardPersistenceObjectList
            Return New ConsignmentDiscardPersistenceObjectList(parentID)
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

        Private Sub New(ByVal availableConsignments As ConsignmentPersistenceObjectList, _
            ByVal amountRequired As Double, ByVal goodsName As String)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Fetch(availableConsignments, amountRequired, goodsName)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal parentID As Integer)

            Dim myComm As New SQLCommand("FetchConsignmentDiscardPersistenceObjectList")
            myComm.AddParam("?CD", parentID)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                For Each dr As DataRow In myData.Rows
                    Add(ConsignmentDiscardPersistenceObject.GetConsignmentDiscardPersistenceObject(dr))
                Next

                RaiseListChangedEvents = True

            End Using

        End Sub

        Private Sub Fetch(ByVal availableConsignments As ConsignmentPersistenceObjectList, _
            ByVal amountRequired As Double, ByVal goodsName As String)

            RaiseListChangedEvents = False

            For Each c As ConsignmentPersistenceObject In availableConsignments

                Add(ConsignmentDiscardPersistenceObject. _
                    NewConsignmentDiscardPersistenceObject(c, amountRequired))

                If Not CRound(amountRequired, ROUNDAMOUNTGOODS) > 0 Then Exit For

            Next

            If CRound(amountRequired, ROUNDAMOUNTGOODS) > 0 Then
                Throw New Exception(String.Format(Goods_ConsignmentDiscardPersistenceObjectList_NotEnoughInStockEexception, _
                    goodsName))
            End If

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByVal parentID As Integer)

            RaiseListChangedEvents = False

            For Each item As ConsignmentDiscardPersistenceObject In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As ConsignmentDiscardPersistenceObject In Me
                If item.IsNew Then
                    item.Insert(parentID)
                ElseIf item.IsDirty Then
                    item.Update()
                End If
            Next

            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace