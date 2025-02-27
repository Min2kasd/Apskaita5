﻿Namespace Goods

    ''' <summary>
    ''' Represents a collection of productions costs that are added to the costs 
    ''' of the goods produced.
    ''' </summary>
    ''' <remarks>Values are calculated by subtracting goods acquisition and discard
    ''' book entries from the encapsulated <see cref="General.JournalEntry">JournalEntry</see>.
    ''' See <see cref="GoodsComplexOperationProduction.Fetch">GoodsComplexOperationProduction.Fetch</see>
    ''' method for details.
    ''' Should only be used as a child of <see cref="GoodsComplexOperationProduction">GoodsComplexOperationProduction</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsProductionCostItemList
        Inherits BusinessListBase(Of GoodsProductionCostItemList, GoodsProductionCostItem)

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

        Protected Overrides Function AddNewCore() As Object
            Dim newItem As GoodsProductionCostItem = GoodsProductionCostItem.NewGoodsProductionCostItem
            Me.Add(newItem)
            Return newItem
        End Function


        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            Return result
        End Function

        Public Function HasWarnings() As Boolean
            For Each i As GoodsProductionCostItem In Me
                If i.HasWarnings() Then Return True
            Next
            Return False
        End Function


        Friend Function GetTotalCosts() As Double
            Dim result As Double = 0
            For Each c As GoodsProductionCostItem In Me
                result = CRound(GetTotalCosts + c.TotalCost)
            Next
            Return result
        End Function

        ''' <summary>
        ''' Recalculates <see cref="GoodsProductionCostItem.TotalCost">total
        ''' production costs</see> for a new amount of the goods produced.
        ''' </summary>
        ''' <param name="ammountInProduction">a new amount of the goods produced</param>
        ''' <remarks></remarks>
        Friend Sub RecalculateForProductionAmount(ByVal ammountInProduction As Double)
            Me.RaiseListChangedEvents = False
            _ParentAmount = ammountInProduction
            For Each c As GoodsProductionCostItem In Me
                c.RecalculateForProductionAmount(ammountInProduction)
            Next
            Me.RaiseListChangedEvents = True
            Me.ResetBindings()
        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new GoodsProductionCostItemList instance for a new <see cref="GoodsComplexOperationProduction">
        ''' parent goods production operation</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsProductionCostItemList() As GoodsProductionCostItemList
            Return New GoodsProductionCostItemList
        End Function

        ''' <summary>
        ''' Gets a new GoodsProductionCostItemList instance for a new <see cref="GoodsComplexOperationProduction">
        ''' parent goods production operation</see> and initializes it with the template data.
        ''' </summary>
        ''' <param name="calculationCosts">a production costs template</param>
        ''' <param name="productionAmount">an amount of the goods produced</param>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsProductionCostItemList(ByVal calculationCosts _
            As ProductionCostItemList, ByVal productionAmount As Double) As GoodsProductionCostItemList
            Return New GoodsProductionCostItemList(calculationCosts, productionAmount)
        End Function

        ''' <summary>
        ''' Gets an existing GoodsProductionCostItemList instance using a database query results.
        ''' </summary>
        ''' <param name="costEntryList">a database query results</param>
        ''' <param name="productionAmount">an amount of the goods produced</param>
        ''' <param name="nFinancialDataCanChange">whether a parent production operation 
        ''' allows to change financial data of the production costs</param>
        ''' <remarks></remarks>
        Friend Shared Function GetGoodsProductionCostItemList(ByVal costEntryList As BookEntryInternalList, _
            ByVal productionAmount As Double, ByVal nFinancialDataCanChange As Boolean) As GoodsProductionCostItemList
            Return New GoodsProductionCostItemList(costEntryList, productionAmount, nFinancialDataCanChange)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal calculationCosts As ProductionCostItemList, _
            ByVal productionAmount As Double)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Create(calculationCosts, productionAmount)
        End Sub

        Private Sub New(ByVal costEntryList As BookEntryInternalList, _
            ByVal productionAmount As Double, ByVal nFinancialDataCanChange As Boolean)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = nFinancialDataCanChange
            Me.AllowNew = nFinancialDataCanChange
            Me.AllowRemove = nFinancialDataCanChange
            Fetch(costEntryList, productionAmount, nFinancialDataCanChange)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal calculationCosts As ProductionCostItemList, ByVal productionAmount As Double)

            RaiseListChangedEvents = False

            _ParentAmount = productionAmount

            For Each dr As ProductionCostItem In calculationCosts
                Add(GoodsProductionCostItem.NewGoodsProductionCostItem(dr, productionAmount))
            Next

            RaiseListChangedEvents = True

        End Sub

        Private Sub Fetch(ByVal costEntryList As BookEntryInternalList, _
            ByVal productionAmount As Double, ByVal nFinancialDataCanChange As Boolean)

            RaiseListChangedEvents = False

            _ParentAmount = productionAmount

            For Each b As BookEntryInternal In costEntryList
                Add(GoodsProductionCostItem.GetGoodsProductionCostItem(b, _
                    productionAmount, nFinancialDataCanChange))
            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Function GetBookEntryInternalList() As BookEntryInternalList

            Dim result As BookEntryInternalList = _
               BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Kreditas)

            RaiseListChangedEvents = False

            DeletedList.Clear()

            For Each costItem As GoodsProductionCostItem In Me
                result.Add(costItem.GetBookEntryInternal)
            Next

            RaiseListChangedEvents = True

            Return result

        End Function

#End Region

    End Class

End Namespace