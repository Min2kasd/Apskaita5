﻿Imports ApskaitaObjects.My.Resources
Imports Csla.Validation

Namespace Goods

    ''' <summary>
    ''' Represents goods (stock) that is consumed in production.
    ''' </summary>
    ''' <remarks>Values are persisted using an encapsulated <see cref="GoodsOperationDiscard">
    ''' simple goods discard operation</see>.
    ''' Should only be used as a child of <see cref="GoodsComponentItemList">GoodsComponentItemList</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsComponentItem
        Inherits BusinessBase(Of GoodsComponentItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _Discard As GoodsOperationDiscard = Nothing
        Private _AmountPerProductionUnit As Double = 0


        ''' <summary>
        ''' Gets an <see cref="GoodsOperationDiscard.ID">ID of the encapsulated 
        ''' simple goods discard operation</see>.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsOperationDiscard">
        ''' encapsulated simple goods discard operation</see>.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard.ID
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsOperationDiscard.GoodsInfo">general information 
        ''' about the goods</see> that are discarded by the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsOperationDiscard">
        ''' encapsulated simple goods discard operation</see>.</remarks>
        Public ReadOnly Property GoodsInfo() As GoodsSummary
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard.GoodsInfo
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsOperationDiscard.GoodsInfo">name of 
        ''' the goods</see> that are discarded by the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsOperationDiscard">
        ''' encapsulated simple goods discard operation</see>.</remarks>
        Public ReadOnly Property GoodsName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard.GoodsInfo.Name
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsOperationDiscard.GoodsInfo">measure unit of 
        ''' the goods</see> that are discarded by the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsOperationDiscard">
        ''' encapsulated simple goods discard operation</see>.</remarks>
        Public ReadOnly Property GoodsMeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard.GoodsInfo.MeasureUnit
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="GoodsOperationDiscard.GoodsInfo">accounting method of 
        ''' the goods</see> that are discarded by the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsOperationDiscard">
        ''' encapsulated simple goods discard operation</see>.</remarks>
        Public ReadOnly Property GoodsAccountingMethod() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard.GoodsInfo.AccountingMethodHumanReadable
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsOperationDiscard.GoodsInfo">valuation method of 
        ''' the goods</see> that are discarded by the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsOperationDiscard">
        ''' encapsulated simple goods discard operation</see>.</remarks>
        Public ReadOnly Property GoodsValuationMethod() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard.GoodsInfo.ValuationMethodHumanReadable
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="GoodsOperationDiscard.OperationLimitations">
        ''' chronologic limitations of the encapsulated simple goods 
        ''' discard operation</see>.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsOperationDiscard">
        ''' encapsulated simple goods discard operation</see>.</remarks>
        Public ReadOnly Property ChronologyValidator() As OperationalLimitList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard.OperationLimitations
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets an amount of the goods/stock consumed to produce 
        ''' a single unit of the production.
        ''' </summary>
        ''' <remarks>Value is calculated on fetch as the <see cref="Amount">Amount</see>
        ''' divided by the <see cref="GoodsComplexOperationProduction.Amount">
        ''' amount of the goods produced</see>.
        ''' Value is loaded from a template when creating a new instance from a template.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDAMOUNTGOODS)> _
        Public Property AmountPerProductionUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountPerProductionUnit, ROUNDAMOUNTGOODS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)

                If value < 0 Then value = 0
                If AmountPerProductionUnitIsReadOnly Then Exit Property

                If CRound(_AmountPerProductionUnit, ROUNDAMOUNTGOODS) _
                    <> CRound(value, ROUNDAMOUNTGOODS) Then

                    _AmountPerProductionUnit = CRound(value, ROUNDAMOUNTGOODS)
                    PropertyHasChanged()

                    If Not Parent Is Nothing AndAlso DirectCast(Parent,  _
                        GoodsProductionCostItemList).ParentAmount > 0 Then
                        Amount = (_AmountPerProductionUnit * DirectCast(Parent,  _
                            GoodsProductionCostItemList).ParentAmount)
                    End If

                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an <see cref="GoodsOperationDiscard.Ammount">amount of 
        ''' the goods</see> that is discarded by the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsOperationDiscard">
        ''' encapsulated simple goods discard operation</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDAMOUNTGOODS)> _
        Public Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard.Ammount
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)

                CanWriteProperty(True)
                If value < 0 Then value = 0
                If AmountIsReadOnly Then Exit Property

                If _Discard.Ammount <> CRound(value, ROUNDAMOUNTGOODS) Then
                    _Discard.Ammount = CRound(value, ROUNDAMOUNTGOODS)
                    PropertyHasChanged()
                    PropertyHasChanged("UnitCost")
                    PropertyHasChanged("TotalCost")
                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a <see cref="GoodsOperationDiscard.NormativeUnitValue"> 
        ''' normative unit costs of the goods</see> that are discarded by the operation.
        ''' </summary>
        ''' <remarks>Only applicable if the goods are accounted using
        ''' <see cref="Goods.GoodsAccountingMethod.Periodic">Periodic accounting method</see>.
        ''' A proxy property to the <see cref="GoodsOperationDiscard">
        ''' encapsulated simple goods discard operation</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDUNITGOODS)> _
        Public Property NormativeUnitCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard.NormativeUnitValue
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)

                If value < 0 Then value = 0

                If NormativeUnitCostIsReadOnly Then Exit Property

                If _Discard.NormativeUnitValue <> CRound(value, ROUNDUNITGOODS) Then

                    _Discard.NormativeUnitValue = CRound(value, ROUNDUNITGOODS)
                    PropertyHasChanged()
                    PropertyHasChanged("TotalCost")

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets costs of the discarded goods per unit.
        ''' </summary>
        ''' <remarks>Only applicable if the goods are accounted using
        ''' <see cref="Goods.GoodsAccountingMethod.Persistent">Persistent accounting method</see>.
        ''' Use <see cref="GoodsCostItem">goods cost query object</see> to fetch
        ''' costs for a discarded amount.
        ''' Is calculated as <see cref="TotalCost">TotalCost</see>
        ''' divided by <see cref="Amount">Amount</see>.
        ''' Final value is set by <see cref="ConsignmentDiscardPersistenceObjectList">
        ''' consignment discards persistence object</see>.
        ''' A proxy property to the <see cref="GoodsOperationDiscard">
        ''' encapsulated simple goods discard operation</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, ROUNDUNITGOODS)> _
        Public ReadOnly Property UnitCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard.UnitCost
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsOperationDiscard.TotalCost"> 
        ''' total costs (either real or normative) of the goods</see> 
        ''' that are discarded by the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsOperationDiscard">
        ''' encapsulated simple goods discard operation</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2)> _
        Public ReadOnly Property TotalCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _Discard.GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                    Return _Discard.NormativeTotalValue
                Else
                    Return _Discard.TotalCost
                End If
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets an <see cref="General.Account.ID">account</see>
        ''' for the accumulated normative costs.
        ''' </summary>
        ''' <remarks>Only applicable if the goods are accounted using
        ''' <see cref="Goods.GoodsAccountingMethod.Periodic">Periodic accounting method</see>.
        ''' When producing goods the <see cref="GoodsComplexOperationProduction.AcquisitionAccount">
        ''' acquisition account of the goods produced</see> is debited with the total 
        ''' (normative) costs. This book entry is balanced by crediting AccountContrary.
        ''' After the <see cref="GoodsComplexOperationInventorization">inventorization</see>
        ''' the accumulated normative costs should be manualy (with a simple journal entry) 
        ''' balanced with the <see cref="GoodsItem.AccountSalesNetCosts">
        ''' sales net costs account</see>.
        ''' Corresponds to the <see cref="GoodsOperationDiscard.AccountGoodsDiscardCosts">
        ''' goods discard costs encapsulated simple goods discard operation</see>.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 3, 4, 6)> _
        Public Property AccountContrary() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _Discard.GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                    Return _Discard.AccountGoodsDiscardCosts
                ElseIf Not _Discard.Warehouse Is Nothing AndAlso Not _Discard.Warehouse.IsEmpty Then
                    Return _Discard.Warehouse.WarehouseAccount
                Else
                    Return 0
                End If
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountContraryIsReadOnly Then Exit Property
                If _Discard.AccountGoodsDiscardCosts <> value Then
                    _Discard.AccountGoodsDiscardCosts = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a <see cref="GoodsOperationDiscard.Description"> 
        ''' content (description, remarks)</see> for the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsOperationDiscard">
        ''' encapsulated simple goods discard operation</see>.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property Remarks() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard.Description
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Discard.Description <> value.Trim Then
                    _Discard.Description = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _Discard.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid
            End Get
        End Property


        ''' <summary>
        ''' Whether the <see cref="AmountPerProductionUnit">AmountPerProductionUnit</see>
        ''' property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AmountPerProductionUnitIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _Discard.OperationLimitations.FinancialDataCanChange _
                    OrElse Not _Discard.OperationLimitations.BaseValidator.FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="Amount">Amount</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AmountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _Discard.OperationLimitations.FinancialDataCanChange _
                    OrElse Not _Discard.OperationLimitations.BaseValidator.FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="NormativeUnitCost">NormativeUnitCost</see>
        ''' property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property NormativeUnitCostIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard.GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Persistent _
                    OrElse Not _Discard.OperationLimitations.FinancialDataCanChange _
                    OrElse Not _Discard.OperationLimitations.BaseValidator.FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="AccountContrary">AccountContrary</see>
        ''' property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountContraryIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Discard.GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Persistent _
                    OrElse Not _Discard.OperationLimitations.BaseValidator.FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="LoadCostInfo">LoadCostInfo</see> method could be invoked,
        ''' i.e. <see cref="UnitCost">UnitCost</see> and 
        ''' <see cref="TotalCost">TotalCost</see> can be set.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property LoadCostInfoIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _Discard.OperationLimitations.FinancialDataCanChange
            End Get
        End Property


        Public Function HasWarnings() As Boolean
            Return MyBase.BrokenRulesCollection.WarningCount > 0
        End Function

        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If Not MyBase.IsValid Then Return String.Format( _
                My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
            If Not _Discard.IsValid Then Return String.Format( _
                My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, _Discard.GetAllBrokenRules())
            Return ""
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If Not HasWarnings() Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
        End Function


        ''' <summary>
        ''' Loads <see cref="UnitCost">UnitCost</see> and <see cref="TotalCost">TotalCost</see>
        ''' values from a <see cref="GoodsCostItem">query object</see>.
        ''' </summary>
        ''' <param name="costInfo">a query object</param>
        ''' <remarks></remarks>
        Public Sub LoadCostInfo(ByVal costInfo As GoodsCostItem)
            _Discard.LoadCostInfo(costInfo)
            PropertyHasChanged("UnitCost")
            PropertyHasChanged("TotalCost")
        End Sub

        ''' <summary>
        ''' Gets a param object for a <see cref="GoodsCostItem">query object</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetGoodsCostParam() As GoodsCostParam
            Return _Discard.GetGoodsCostParam()
        End Function


        Friend Sub RecalculateForProductionAmount(ByVal ammountInProduction As Double)

            If Not CRound(_AmountPerProductionUnit, ROUNDUNITGOODS) > 0 Then Exit Sub

            If Not _Discard.OperationLimitations.FinancialDataCanChange Then _
                Throw New Exception(String.Format(Goods_GoodsComponentItem_CannotChangeFinancialData, _
                    _Discard.GoodsInfo.Name, vbCrLf, _Discard.OperationLimitations. _
                    FinancialDataCanChangeExplanation))

            Amount = (_AmountPerProductionUnit * ammountInProduction)

        End Sub


        Friend Sub SetParentDate(ByVal parentDate As Date)
            If _Discard.Date.Date <> parentDate.Date Then
                _Discard.SetParentDate(parentDate)
                PropertyHasChanged()
            End If
        End Sub

        Friend Sub SetParentProperties(ByVal parentDocumentNumber As String, _
            ByVal parentContent As String)
            _Discard.SetParentProperties(parentDocumentNumber, parentContent)
        End Sub

        Friend Sub SetParentWarehouse(ByVal value As WarehouseInfo)

            If Not (_Discard.Warehouse Is Nothing AndAlso value Is Nothing) _
                AndAlso Not (Not _Discard.Warehouse Is Nothing AndAlso Not value Is Nothing _
                AndAlso _Discard.Warehouse.ID = value.ID) Then

                _Discard.SetParentWarehouse(value)
                PropertyHasChanged()

                If _Discard.GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Persistent Then
                    PropertyHasChanged("AccountContrary")
                End If

            End If

        End Sub

        Friend Sub SetParentAcquisitionAccount(ByVal newAccount As Long)
            If _Discard.GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Persistent _
                AndAlso _Discard.AccountGoodsDiscardCosts <> newAccount Then
                _Discard.AccountGoodsDiscardCosts = newAccount
            End If
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Goods_GoodsComponentItem_ToString, _
                _Discard.GoodsInfo.Name)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New RuleArgs("Amount"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New RuleArgs("AmountPerProductionUnit"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New RuleArgs("Remarks"))

            ValidationRules.AddRule(AddressOf NormativeUnitCostValidation, _
                New RuleArgs("NormativeUnitCost"))
            ValidationRules.AddRule(AddressOf AccountContraryValidation, _
                New RuleArgs("AccountContrary"))

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property NormativeUnitCost is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function NormativeUnitCostValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            If DirectCast(target, GoodsComponentItem)._Discard.GoodsInfo.AccountingMethod _
                = Goods.GoodsAccountingMethod.Periodic Then
                Return CommonValidation.DoubleFieldValidation(target, e)
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountContrary is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountContraryValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            If DirectCast(target, GoodsComponentItem)._Discard.GoodsInfo.AccountingMethod _
                = Goods.GoodsAccountingMethod.Periodic Then
                Return CommonValidation.AccountFieldValidation(target, e)
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new GoodsComponentItem instance.
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' to discard (consume in production)</param>
        ''' <param name="parentWarehouse">a warehouse to discard (consume) the goods from</param>
        ''' <param name="parentValidator">a chronologic validator of the parent document (if any)</param>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsComponentItem(ByVal goodsID As Integer, _
            ByVal parentWarehouse As WarehouseInfo, _
            ByVal parentValidator As IChronologicValidator) As GoodsComponentItem
            Return New GoodsComponentItem(goodsID, parentWarehouse, parentValidator)
        End Function

        ''' <summary>
        ''' Gets a new GoodsComponentItem instance using a template.
        ''' </summary>
        ''' <param name="calculationComponent">template goods/stock to consume in production</param>
        ''' <param name="productionAmount">an amount of the goods produced</param>
        ''' <param name="parentWarehouse">a warehouse to discard (consume) the goods from</param>
        ''' <param name="parentValidator">a chronologic validator of the parent document (if any)</param>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsComponentItem(ByVal calculationComponent _
            As ProductionComponentItem, ByVal productionAmount As Double, _
            ByVal parentWarehouse As WarehouseInfo, _
            ByVal parentValidator As IChronologicValidator) As GoodsComponentItem
            Return New GoodsComponentItem(calculationComponent, productionAmount, _
                parentWarehouse, parentValidator)
        End Function

        ''' <summary>
        ''' Gets an existing GoodsComponentItem instance using a database query result.
        ''' </summary>
        ''' <param name="obj">a goods operation persistence object containg the operation data</param>
        ''' <param name="productionAmount">an amount of the goods produced</param>
        ''' <param name="parentValidator">a chronologic validator of the parent document (if any)</param>
        ''' <param name="limitationsDataSource">a datasource for the 
        ''' <see cref="OperationalLimitList">chronologic validator</see></param>
        ''' <remarks></remarks>
        Friend Shared Function GetGoodsComponentItem(ByVal obj As OperationPersistenceObject, _
            ByVal productionAmount As Double, ByVal parentValidator As IChronologicValidator, _
            ByVal limitationsDataSource As DataTable) As GoodsComponentItem
            Return New GoodsComponentItem(obj, productionAmount, parentValidator, _
                limitationsDataSource)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal goodsID As Integer, ByVal parentWarehouse As WarehouseInfo, _
            ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            MarkAsChild()
            Create(goodsID, parentWarehouse, parentValidator)
        End Sub

        Private Sub New(ByVal calculationComponent As ProductionComponentItem, _
            ByVal productionAmount As Double, ByVal parentWarehouse As WarehouseInfo, _
            ByVal parentValidator As IChronologicValidator)
            MarkAsChild()
            Create(calculationComponent, productionAmount, parentWarehouse, parentValidator)
        End Sub

        Private Sub New(ByVal obj As OperationPersistenceObject, ByVal productionAmount As Double, _
            ByVal parentValidator As IChronologicValidator, ByVal limitationsDataSource As DataTable)
            MarkAsChild()
            Fetch(obj, productionAmount, parentValidator, limitationsDataSource)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private mId As Integer
            Private mParentValidator As IChronologicValidator
            Public ReadOnly Property Id() As Integer
                Get
                    Return mId
                End Get
            End Property
            Public ReadOnly Property ParentValidator() As IChronologicValidator
                Get
                    Return mParentValidator
                End Get
            End Property
            Public Sub New(ByVal id As Integer, ByVal nParentValidator As IChronologicValidator)
                mId = id
                mParentValidator = nParentValidator
            End Sub
        End Class


        Private Sub Create(ByVal goodsID As Integer, ByVal parentWarehouse As WarehouseInfo, _
            ByVal parentValidator As IChronologicValidator)

            _Discard = GoodsOperationDiscard.NewGoodsOperationDiscardChild( _
                goodsID, parentWarehouse, parentValidator)

            If Not parentWarehouse Is Nothing AndAlso Not parentWarehouse.IsEmpty _
                AndAlso _Discard.GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Persistent Then
                _Discard.AccountGoodsDiscardCosts = parentWarehouse.WarehouseAccount
            End If

            ValidationRules.CheckRules()

        End Sub

        Private Sub Create(ByVal calculationComponent As ProductionComponentItem, _
            ByVal productionAmount As Double, ByVal parentWarehouse As WarehouseInfo, _
            ByVal parentValidator As IChronologicValidator)

            If Not CRound(productionAmount, ROUNDAMOUNTGOODS) > 0 Then productionAmount = 1

            _Discard = GoodsOperationDiscard.NewGoodsOperationDiscardChild( _
                calculationComponent.Goods.ID, parentWarehouse, parentValidator)
            _Discard.Ammount = calculationComponent.Amount
            _AmountPerProductionUnit = calculationComponent.Amount / productionAmount

            If _Discard.GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                _Discard.NormativeUnitValue = calculationComponent.NormativeUnitCost
            End If

            If Not parentWarehouse Is Nothing AndAlso Not parentWarehouse.IsEmpty _
                AndAlso _Discard.GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Persistent Then
                _Discard.AccountGoodsDiscardCosts = parentWarehouse.WarehouseAccount
            End If

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal obj As OperationPersistenceObject, ByVal productionAmount As Double, _
            ByVal parentValidator As IChronologicValidator, ByVal limitationsDataSource As DataTable)

            _Discard = GoodsOperationDiscard.GetGoodsOperationDiscardChild(obj, _
                parentValidator, limitationsDataSource)

            If CRound(productionAmount, ROUNDAMOUNTGOODS) > 0 Then
                _AmountPerProductionUnit = CRound(_Discard.Ammount / productionAmount, ROUNDUNITGOODS)
            End If

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Friend Sub Update(ByVal parent As GoodsComplexOperationProduction)

            _Discard.SaveChild(parent.JournalEntryID, parent.ID, _
                Not parent.ChronologyValidatorDiscard.FinancialDataCanChange)

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()
            _Discard.DeleteGoodsOperationDiscardChild()
            MarkNew()
        End Sub


        Friend Sub CheckIfCanUpdate(ByVal parentValidator As IChronologicValidator, _
            ByVal limitationsDataSource As DataTable)
            If _Discard.GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Persistent _
                AndAlso _Discard.OperationLimitations.FinancialDataCanChange _
                AndAlso (parentValidator Is Nothing OrElse parentValidator.FinancialDataCanChange) Then
                _Discard.PreloadCosts()
            End If
            _Discard.CheckIfCanUpdate(limitationsDataSource, parentValidator)
        End Sub

        Friend Sub CheckIfCanDelete(ByVal limitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator)
            _Discard.CheckIfCanDelete(limitationsDataSource, parentValidator)
        End Sub

        Friend Function GetBookEntryInternal() As BookEntryInternal

            If _Discard.GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                Return BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                    _Discard.AccountGoodsDiscardCosts, _Discard.TotalCost)
            Else
                Return BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                    _Discard.Warehouse.WarehouseAccount, _Discard.TotalCost)
            End If

        End Function

#End Region

    End Class

End Namespace