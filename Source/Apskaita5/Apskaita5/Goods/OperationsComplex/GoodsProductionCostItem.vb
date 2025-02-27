﻿Imports Csla.Validation

Namespace Goods

    ''' <summary>
    ''' Represents productions costs that are added to the costs of the goods produced.
    ''' </summary>
    ''' <remarks>Values are calculated by subtracting goods acquisition and discard
    ''' book entries from the encapsulated <see cref="General.JournalEntry">JournalEntry</see>.
    ''' See <see cref="GoodsComplexOperationProduction.Fetch">GoodsComplexOperationProduction.Fetch</see>
    ''' method for details.
    ''' Should only be used as a child of <see cref="GoodsProductionCostItemList">GoodsProductionCostItemList</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsProductionCostItem
        Inherits BusinessBase(Of GoodsProductionCostItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _Account As Long = 0
        Private _CostPerProductionUnit As Double = 0
        Private _TotalCost As Double = 0
        Private _FinancialDataCanChange As Boolean = True


        ''' <summary>
        ''' Whether a parent production operation allows to change financial data of
        ''' the production costs.
        ''' </summary>
        ''' <remarks>Value is set by a parent operation on fetch.</remarks>
        Public ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' An <see cref="General.Account.ID">account</see> of the production costs.
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 1, 2, 6)> _
        Public Property Account() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _Account <> value Then
                    _Account = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an amount (sum) of the production costs per <see cref="GoodsComplexOperationProduction.Amount">
        ''' amount of the goods produced.</see>
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDUNITGOODS)> _
        Public Property CostPerProductionUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CostPerProductionUnit, ROUNDUNITGOODS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)

                If Not _FinancialDataCanChange Then Exit Property

                If CRound(_CostPerProductionUnit, ROUNDUNITGOODS) <> CRound(value, ROUNDUNITGOODS) Then

                    _CostPerProductionUnit = CRound(value, ROUNDUNITGOODS)
                    PropertyHasChanged()

                    If Not Me.Parent Is Nothing AndAlso DirectCast(Me.Parent,  _
                        GoodsProductionCostItemList).ParentAmount > 0 Then
                        _TotalCost = CRound(_CostPerProductionUnit * DirectCast(Me.Parent,  _
                        GoodsProductionCostItemList).ParentAmount)
                        PropertyHasChanged("TotalCost")
                    End If

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a total amount (sum) of the production costs.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public Property TotalCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalCost)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)

                If Not _FinancialDataCanChange Then Exit Property

                If CRound(_TotalCost) <> CRound(value) Then

                    _TotalCost = CRound(value)
                    PropertyHasChanged()

                    If Not Me.Parent Is Nothing AndAlso DirectCast(Me.Parent,  _
                        GoodsProductionCostItemList).ParentAmount > 0 Then
                        _CostPerProductionUnit = CRound(_TotalCost / DirectCast(Me.Parent,  _
                            GoodsProductionCostItemList).ParentAmount, ROUNDUNITGOODS)
                        PropertyHasChanged("CostPerProductionUnit")
                    End If

                End If

            End Set
        End Property



        Public Function GetAllBrokenRules() As String
            Dim result As String = ""
            If Not MyBase.IsValid Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error), False)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then
                result = AddWithNewLine(result, _
                    Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning), False)
            End If
            Return result
        End Function

        Public Function HasWarnings() As Boolean
            Return MyBase.BrokenRulesCollection.WarningCount > 0
        End Function

        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.GetAllBrokenRules())
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If Not HasWarnings() Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.GetAllWarnings())
        End Function


        ''' <summary>
        ''' Recalculates <see cref="TotalCost">TotalCost</see> when the amount
        ''' of the goods produced changes.
        ''' </summary>
        ''' <param name="amountInProduction">a new amount of the goods produced</param>
        ''' <remarks></remarks>
        Friend Sub RecalculateForProductionAmount(ByVal amountInProduction As Double)
            _TotalCost = CRound(_CostPerProductionUnit * amountInProduction)
            PropertyHasChanged("TotalCost")
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Goods_GoodsProductionCostItem_ToString, _
                _Account.ToString, DblParser(_CostPerProductionUnit, ROUNDUNITGOODS))
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.AccountFieldValidation, _
                New RuleArgs("Account"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New RuleArgs("TotalCost"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New RuleArgs("CostPerProductionUnit"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new GoodsProductionCostItem instance.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsProductionCostItem() As GoodsProductionCostItem
            Dim result As New GoodsProductionCostItem
            result.ValidationRules.CheckRules()
            Return result
        End Function

        ''' <summary>
        ''' Gets a new GoodsProductionCostItem instance and initializes it's values
        ''' using a template.
        ''' </summary>
        ''' <param name="calculationCost">a template production costs item</param>
        ''' <param name="productionAmount">an amount of the goods produced
        ''' (when loading data from a template, equals <see cref="ProductionCalculation.Amount">
        ''' ProductionCalculation.Amount</see>)</param>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsProductionCostItem(ByVal calculationCost _
            As ProductionCostItem, ByVal productionAmount As Double) As GoodsProductionCostItem
            Return New GoodsProductionCostItem(calculationCost, productionAmount)
        End Function

        ''' <summary>
        ''' Gets an existing GoodsProductionCostItem instance using a database query result.
        ''' </summary>
        ''' <param name="dr">a database query result</param>
        ''' <param name="productionAmount">an amount of the goods produced</param>
        ''' <param name="nFinancialDataCanChange">whether a parent production operation 
        ''' allows to change financial data of the production costs</param>
        ''' <remarks></remarks>
        Friend Shared Function GetGoodsProductionCostItem(ByVal dr As BookEntryInternal, _
            ByVal productionAmount As Double, ByVal nFinancialDataCanChange As Boolean) As GoodsProductionCostItem
            Return New GoodsProductionCostItem(dr, productionAmount, nFinancialDataCanChange)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal calculationCost As ProductionCostItem, _
            ByVal productionAmount As Double)
            ' require use of factory methods
            MarkAsChild()
            Create(calculationCost, productionAmount)
        End Sub

        Private Sub New(ByVal dr As BookEntryInternal, ByVal productionAmount As Double, _
            ByVal nFinancialDataCanChange As Boolean)
            MarkAsChild()
            Fetch(dr, productionAmount, nFinancialDataCanChange)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal calculationCost As ProductionCostItem, _
            ByVal productionAmount As Double)

            If Not CRound(productionAmount, ROUNDAMOUNTGOODS) > 0 Then productionAmount = 1

            _CostPerProductionUnit = CRound(calculationCost.Amount / productionAmount, ROUNDUNITGOODS)
            _TotalCost = calculationCost.Amount
            _Account = calculationCost.Account

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As BookEntryInternal, ByVal productionAmount As Double, _
            ByVal nFinancialDataCanChange As Boolean)

            _Account = dr.Account
            _TotalCost = dr.Ammount
            If CRound(productionAmount, ROUNDAMOUNTGOODS) > 0 Then
                _CostPerProductionUnit = CRound(_TotalCost / productionAmount, ROUNDUNITGOODS)
            End If
            _FinancialDataCanChange = nFinancialDataCanChange

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Friend Function GetBookEntryInternal() As BookEntryInternal
            Return BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                _Account, _TotalCost)
        End Function

#End Region

    End Class

End Namespace