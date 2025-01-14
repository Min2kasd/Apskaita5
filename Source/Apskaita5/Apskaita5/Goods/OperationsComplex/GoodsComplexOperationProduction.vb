﻿Imports Csla.Validation
Imports ApskaitaObjects.My.Resources

Namespace Goods

    ''' <summary>
    ''' Represents a complex goods production operation that consists of 
    ''' a <see cref="GoodsOperationAcquisition">simple goods acquisition operation</see>
    ''' (for the goods produced) and multiple (0...*) <see cref="GoodsOperationDiscard">
    ''' simple goods discard operations</see> (for the goods/stock consumed in production).
    ''' </summary>
    ''' <remarks>See methodology for BAS No 9 ""Stores"" para. 10 - 23 for details.
    ''' Encapsulates a <see cref="General.JournalEntry">JournalEntry</see>
    ''' of type <see cref="DocumentType.GoodsProduction">DocumentType.GoodsProduction</see>.
    ''' Values are stored using <see cref="ComplexOperationPersistenceObject">ComplexOperationPersistenceObject</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsComplexOperationProduction
        Inherits BusinessBase(Of GoodsComplexOperationProduction)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _JournalEntryID As Integer = 0
        Private _ChronologyValidatorDiscard As ComplexChronologicValidator = Nothing
        Private _DocumentNumber As String = ""
        Private _WarehouseForComponents As WarehouseInfo = Nothing
        Private _OldWarehouseForComponentsID As Integer = 0
        Private _Acquisition As GoodsOperationAcquisition = Nothing
        Private _CalculationIsPerUnit As Double = 0
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private WithEvents _ComponentItems As GoodsComponentItemList
        Private WithEvents _CostsItems As GoodsProductionCostItemList

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _ComponentItemsSortedList As Csla.SortedBindingList(Of GoodsComponentItem) = Nothing
        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _CostsItemsSortedList As Csla.SortedBindingList(Of GoodsProductionCostItem) = Nothing


        ''' <summary>
        ''' Gets an ID of the operation that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.ID">ComplexOperationPersistenceObject.ID</see>.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.JournalEntry.ID">ID of the journal entry</see>
        ''' that is encapsulated by the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.JournalEntryID">ComplexOperationPersistenceObject.JournalEntryID</see>.</remarks>
        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the operation was inserted into the database.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.InsertDate">ComplexOperationPersistenceObject.InsertDate</see>.</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the operation was last updated.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.UpdateDate">ComplexOperationPersistenceObject.UpdateDate</see>.</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsOperationAcquisition.OperationLimitations">
        ''' chronologic validator of the encapsulated simple acquisition operation</see>.
        ''' </summary>
        ''' <remarks>A proxy property to the encapsulated <see cref="GoodsOperationAcquisition">
        ''' simple goods acquisition operation</see> field.</remarks>
        Public ReadOnly Property ChronologyValidatorAcquisition() As OperationalLimitList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Acquisition.OperationLimitations
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="IChronologicValidator">IChronologicValidator</see> object 
        ''' that contains business restraints on updating the <see cref="ComponentItems">
        ''' discard operations data</see>.
        ''' </summary>
        ''' <remarks>A <see cref="ComplexChronologicValidator">ComplexChronologicValidator</see> 
        ''' is used to validate a complex goods operation chronological business rules.</remarks>
        Public ReadOnly Property ChronologyValidatorDiscard() As ComplexChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologyValidatorDiscard
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a date of the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.OperationDate">ComplexOperationPersistenceObject.OperationDate</see>.</remarks>
        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Acquisition.JournalEntryDate
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If _Acquisition.JournalEntryDate.Date <> value.Date Then
                    _Acquisition.SetParentDate(value.Date)
                    _ComponentItems.SetParentDate(value.Date)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a document number of the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.DocNo">ComplexOperationPersistenceObject.DocNo</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 30)> _
        Public Property DocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _DocumentNumber.Trim <> value.Trim Then
                    _DocumentNumber = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a content (description) of the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.Content">ComplexOperationPersistenceObject.Content</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Acquisition.Description
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Acquisition.Description.Trim <> value.Trim Then
                    _Acquisition.SetDescription(value.Trim)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a a warehouse for the goods produced.
        ''' </summary>
        ''' <remarks>A proxy property to the encapsulated <see cref="GoodsOperationAcquisition">
        ''' simple goods acquisition operation</see> field.
        ''' Corresponds to <see cref="ComplexOperationPersistenceObject.SecondaryWarehouse">ComplexOperationPersistenceObject.SecondaryWarehouse</see>.</remarks>
        <WarehouseField(ValueRequiredLevel.Mandatory)> _
        Public Property WarehouseForProduction() As WarehouseInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Acquisition.Warehouse
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As WarehouseInfo)
                CanWriteProperty(True)

                If WarehouseForProductionIsReadOnly Then Exit Property

                If Not (_Acquisition.Warehouse Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Acquisition.Warehouse Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _Acquisition.Warehouse.ID = value.ID) Then

                    _Acquisition.Warehouse = value
                    PropertyHasChanged()
                    PropertyHasChanged("AcquisitionAccount")
                    PropertyHasChanged("ChronologyValidatorAcquisition")

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets <see cref="GoodsSummary">general information about the goods</see> 
        ''' that are produced by the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the encapsulated <see cref="GoodsOperationAcquisition">
        ''' simple goods acquisition operation</see> field.</remarks>
        Public ReadOnly Property GoodsInfo() As GoodsSummary
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Acquisition.GoodsInfo
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsItem.Name">name of the goods</see> 
        ''' that are produced by the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the encapsulated <see cref="GoodsOperationAcquisition">
        ''' simple goods acquisition operation</see> field.</remarks>
        Public ReadOnly Property GoodsName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Acquisition.GoodsInfo.Name
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsItem.MeasureUnit">measure unit of the goods</see> 
        ''' that are produced by the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the encapsulated <see cref="GoodsOperationAcquisition">
        ''' simple goods acquisition operation</see> field.</remarks>
        Public ReadOnly Property GoodsMeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Acquisition.GoodsInfo.MeasureUnit
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="GoodsItem.AccountingMethod">accounting method for the goods</see> 
        ''' that are produced by the operation as a localized human readable string.
        ''' </summary>
        ''' <remarks>A proxy property to the encapsulated <see cref="GoodsOperationAcquisition">
        ''' simple goods acquisition operation</see> field.</remarks>
        Public ReadOnly Property GoodsAccountingMethod() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Acquisition.GoodsInfo.AccountingMethodHumanReadable
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsItem.DefaultValuationMethod">current valuation method 
        ''' for the goods</see> that are produced by the operation as a localized 
        ''' human readable string.
        ''' </summary>
        ''' <remarks>A proxy property to the encapsulated <see cref="GoodsOperationAcquisition">
        ''' simple goods acquisition operation</see> field.</remarks>
        Public ReadOnly Property GoodsValuationMethod() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Acquisition.GoodsInfo.ValuationMethodHumanReadable
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.Account.ID">account</see> where the total costs
        ''' of the goods produced is accounted.
        ''' </summary>
        ''' <remarks>A proxy property to the encapsulated <see cref="GoodsOperationAcquisition">
        ''' simple goods acquisition operation</see> field.</remarks>
        Public ReadOnly Property AcquisitionAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Acquisition.AcquisitionAccount
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a a warehouse for the goods/stock consumed in production.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.Warehouse">ComplexOperationPersistenceObject.Warehouse</see>.</remarks>
        <WarehouseField(ValueRequiredLevel.Mandatory)> _
        Public Property WarehouseForComponents() As WarehouseInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WarehouseForComponents
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As WarehouseInfo)
                CanWriteProperty(True)
                If WarehouseForComponentsIsReadOnly Then Exit Property
                If Not (_WarehouseForComponents Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _WarehouseForComponents Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _WarehouseForComponents.ID = value.ID) Then

                    _WarehouseForComponents = value
                    PropertyHasChanged()

                    _ComponentItems.SetParentWarehouse(value)
                    _ChronologyValidatorDiscard = ComplexChronologicValidator.GetComplexChronologicValidator( _
                        _ChronologyValidatorDiscard, _ComponentItems.GetLimitations())
                    PropertyHasChanged("ChronologyValidatorDiscard")

                End If
            End Set
        End Property

        Public ReadOnly Property OldWarehouseForComponentsID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OldWarehouseForComponentsID
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="ProductionCalculation.Amount">standard production 
        ''' amount in the currently loaded production calculation (template)</see>.
        ''' </summary>
        ''' <remarks>Ad hoc information only, value is not persisted.</remarks>
        Public ReadOnly Property CalculationIsPerUnit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CalculationIsPerUnit, ROUNDAMOUNTGOODS)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets an amount of the goods produced.
        ''' </summary>
        ''' <remarks>Corresponds to the <see cref="GoodsOperationAcquisition.Ammount">amount
        ''' of the encapsulated simple goods acquisition operation</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDAMOUNTGOODS)> _
        Public Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Acquisition.Ammount
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)

                If AmountIsReadOnly Then Exit Property

                If _Acquisition.Ammount <> CRound(value, ROUNDAMOUNTGOODS) Then

                    _Acquisition.SetAmount(CRound(value, ROUNDAMOUNTGOODS))
                    PropertyHasChanged()

                    If CRound(value, ROUNDAMOUNTGOODS) > 0 Then
                        _Acquisition.SetUnitCost(CRound(_Acquisition.TotalCost _
                            / value, ROUNDUNITGOODS))
                    Else
                        _Acquisition.SetUnitCost(0)
                    End If
                    PropertyHasChanged("UnitValue")

                    _ComponentItems.RecalculateForProductionAmount(value)

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets a unit value of the goods produced.
        ''' </summary>
        ''' <remarks>Corresponds to the <see cref="GoodsOperationAcquisition.UnitCost">
        ''' unit value of the encapsulated simple goods acquisition operation</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDUNITGOODS)> _
        Public ReadOnly Property UnitValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Acquisition.UnitCost
            End Get
        End Property

        ''' <summary>
        ''' Gets a unit value of the goods produced.
        ''' </summary>
        ''' <remarks>Corresponds to the <see cref="GoodsOperationAcquisition.TotalCost">
        ''' total value of the encapsulated simple goods acquisition operation</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property TotalValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Acquisition.TotalCost
            End Get
        End Property

        ''' <summary>
        ''' Gets a collection of the goods/stock that are consumed in production.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ComponentItems() As GoodsComponentItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComponentItems
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable collection of the goods/stock that are consumed in production.
        ''' </summary>
        ''' <remarks>Used to implement autosort in a datagridview.</remarks>
        Public ReadOnly Property ComponentItemsSorted() As Csla.SortedBindingList(Of GoodsComponentItem)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _ComponentItemsSortedList Is Nothing Then
                    _ComponentItemsSortedList = New Csla.SortedBindingList(Of GoodsComponentItem)(_ComponentItems)
                End If
                Return _ComponentItemsSortedList
            End Get
        End Property

        ''' <summary>
        ''' Gets a collection of the production costs.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CostsItems() As GoodsProductionCostItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CostsItems
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable collection of the production costs.
        ''' </summary>
        ''' <remarks>Used to implement autosort in a datagridview.</remarks>
        Public ReadOnly Property CostsItemsSorted() As Csla.SortedBindingList(Of GoodsProductionCostItem)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _CostsItemsSortedList Is Nothing Then
                    _CostsItemsSortedList = New Csla.SortedBindingList(Of GoodsProductionCostItem)(_CostsItems)
                End If
                Return _CostsItemsSortedList
            End Get
        End Property


        ''' <summary>
        ''' Whether the <see cref="WarehouseForProduction">WarehouseForProduction</see>
        ''' property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property WarehouseForProductionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _Acquisition.OperationLimitations.FinancialDataCanChange OrElse _
                    Not _ChronologyValidatorDiscard.FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="WarehouseForComponents">WarehouseForComponents</see>
        ''' property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property WarehouseForComponentsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologyValidatorDiscard.FinancialDataCanChange OrElse _
                    Not _ChronologyValidatorDiscard.ChildrenFinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="Amount">Amount</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AmountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _Acquisition.OperationLimitations.FinancialDataCanChange OrElse _
                    Not _ChronologyValidatorDiscard.FinancialDataCanChange OrElse _
                    Not _ChronologyValidatorDiscard.ChildrenFinancialDataCanChange
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_DocumentNumber.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Acquisition.Description.Trim) _
                    OrElse _ComponentItems.Count > 0)
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _ComponentItems.IsDirty OrElse _CostsItems.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _ComponentItems.IsValid AndAlso _CostsItems.IsValid
            End Get
        End Property



        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules

            If IsValid Then Return ""

            Dim result As String = ""
            If Not MyBase.IsValid Then
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            End If
            If Not _ComponentItems.IsValid Then
                result = AddWithNewLine(result, _ComponentItems.GetAllBrokenRules, False)
            End If
            If Not _CostsItems.IsValid Then
                result = AddWithNewLine(result, _CostsItems.GetAllBrokenRules, False)
            End If

            Return result

        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings

            If Not HasWarnings() Then Return ""

            Dim result As String = ""

            If Me.BrokenRulesCollection.WarningCount > 0 Then
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            End If
            If _ComponentItems.HasWarnings() Then
                result = AddWithNewLine(result, _ComponentItems.GetAllWarnings, False)
            End If
            If _CostsItems.HasWarnings() Then
                result = AddWithNewLine(result, _CostsItems.GetAllWarnings, False)
            End If

            Return result

        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return Me.BrokenRulesCollection.WarningCount > 0 OrElse _
                _ComponentItems.HasWarnings() OrElse _CostsItems.HasWarnings()
        End Function


        ''' <summary>
        ''' Sets costs of the goods to discard (consume) using <see cref="GoodsCostItemList">
        ''' query object</see>.
        ''' </summary>
        ''' <param name="values">a query object containing information about the costs 
        ''' of the goods for a given amount, warehouse and date.</param>
        ''' <param name="warnings">an out parameter that returns a description of 
        ''' non critical errors encountered while seting the data</param>
        ''' <remarks></remarks>
        Public Sub RefreshCosts(ByVal values As GoodsCostItemList, ByRef warnings As String)

            warnings = ""

            If Not ChronologyValidatorDiscard.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsComplexOperationProduction_CannotChangeFinancialData, _
                    vbCrLf, ChronologyValidatorDiscard.FinancialDataCanChangeExplanation))
            ElseIf Not ChronologyValidatorAcquisition.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsComplexOperationProduction_CannotChangeFinancialDataAcquisition, _
                    vbCrLf, ChronologyValidatorAcquisition.FinancialDataCanChangeExplanation))
            End If

            _ComponentItems.RefreshCosts(values, warnings)

        End Sub

        ''' <summary>
        ''' Sets costs of the goods to discard using <see cref="GoodsCostItem">
        ''' query object</see>.
        ''' </summary>
        ''' <param name="value">a query object containing information about the costs 
        ''' of the given goods for a given amount, warehouse and date.</param>
        ''' <remarks></remarks>
        Public Sub RefreshCosts(ByVal value As GoodsCostItem)

            If Not ChronologyValidatorDiscard.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsComplexOperationProduction_CannotChangeFinancialData, _
                    vbCrLf, ChronologyValidatorDiscard.FinancialDataCanChangeExplanation))
            ElseIf Not ChronologyValidatorAcquisition.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsComplexOperationProduction_CannotChangeFinancialDataAcquisition, _
                    vbCrLf, ChronologyValidatorAcquisition.FinancialDataCanChangeExplanation))
            End If

            _ComponentItems.RefreshCosts(value)

        End Sub

        ''' <summary>
        ''' Gets an array of param objects for a <see cref="GoodsCostItemList">query object</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetCostsParams() As GoodsCostParam()
            If _WarehouseForComponents Is Nothing OrElse _WarehouseForComponents.IsEmpty Then
                Throw New Exception(Goods_GoodsComplexOperationProduction_WarehouseForComponentsNull)
            End If
            Return _ComponentItems.GetGoodsCostsParams()
        End Function

        ''' <summary>
        ''' Adds items in the list to the current component collection.
        ''' </summary>
        ''' <param name="list"></param>
        ''' <remarks>Invoke <see cref="GoodsComponentItemList.NewGoodsComponentItemList">GoodsComponentItemList.NewGoodsComponentItemList</see>
        ''' to get a list of new child operations by goods ID's.</remarks>
        Public Sub AddRange(ByVal list As GoodsComponentItemList)

            If Not ChronologyValidatorDiscard.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsComplexOperationProduction_CannotChangeFinancialData, _
                    vbCrLf, ChronologyValidatorDiscard.FinancialDataCanChangeExplanation))
            ElseIf Not ChronologyValidatorAcquisition.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsComplexOperationProduction_CannotChangeFinancialDataAcquisition, _
                    vbCrLf, ChronologyValidatorAcquisition.FinancialDataCanChangeExplanation))
            End If

            list.SetParentDate(_Acquisition.JournalEntryDate)
            list.SetParentWarehouse(_WarehouseForComponents)

            _ComponentItems.AddRange(list)

            For Each i As GoodsComponentItem In list
                _ChronologyValidatorDiscard.MergeNewValidationItem(i.ChronologyValidator)
            Next
            PropertyHasChanged("ChronologyValidatorDiscard")

        End Sub

        ''' <summary>
        ''' Recalculates production costs and component costs for a new production amount.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RecalculateForProductionAmount()

            If Not _Acquisition.Ammount > 0 Then Exit Sub

            If Not _Acquisition.OperationLimitations.FinancialDataCanChange Then
                Throw New Exception(String.Format( _
                    Goods_GoodsComplexOperationProduction_CannotChangeFinancialDataAcquisition, _
                    vbCrLf, _Acquisition.OperationLimitations.FinancialDataCanChangeExplanation))
            ElseIf Not _ChronologyValidatorDiscard.ChildrenFinancialDataCanChange Then
                Throw New Exception(String.Format( _
                    Goods_GoodsComplexOperationProduction_CannotChangeFinancialDataDiscard, vbCrLf, _
                    _ChronologyValidatorDiscard.ChildrenFinancialDataCanChangeExplanation))
            ElseIf Not _ChronologyValidatorDiscard.FinancialDataCanChange Then
                Throw New Exception(String.Format( _
                    Goods_GoodsComplexOperationProduction_CannotChangeFinancialData, _
                    vbCrLf, _ChronologyValidatorDiscard.FinancialDataCanChangeExplanation))
            End If

            _ComponentItems.RecalculateForProductionAmount(_Acquisition.Ammount)
            _CostsItems.RecalculateForProductionAmount(_Acquisition.Ammount)

        End Sub


        Public Overrides Function Save() As GoodsComplexOperationProduction
            Return MyBase.Save
        End Function


        Private Sub CalculateSum(ByVal raisePropertyHasChanged As Boolean)

            _Acquisition.TotalCost = CRound(_ComponentItems.GetTotalCosts() _
                + _CostsItems.GetTotalCosts, 2)
            If _Acquisition.Ammount > 0 Then
                _Acquisition.SetUnitCost(CRound(_Acquisition.TotalCost _
                    / _Acquisition.Ammount, ROUNDUNITGOODS))
            Else
                _Acquisition.SetUnitCost(0)
            End If

            If raisePropertyHasChanged Then
                PropertyHasChanged("TotalValue")
                PropertyHasChanged("UnitValue")
            End If

        End Sub

        Private Sub ComponentItems_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _ComponentItems.ListChanged

            CalculateSum(True)

            If e.ListChangedType = ComponentModel.ListChangedType.ItemDeleted Then
                _ChronologyValidatorDiscard = ComplexChronologicValidator.GetComplexChronologicValidator( _
                    _ChronologyValidatorDiscard, _ComponentItems.GetLimitations())
                PropertyHasChanged("ChronologyValidatorDiscard")
            ElseIf e.ListChangedType = ComponentModel.ListChangedType.ItemAdded Then
                _ChronologyValidatorDiscard.MergeNewValidationItem( _
                    _ComponentItems(e.NewIndex).ChronologyValidator)
                PropertyHasChanged("ChronologyValidatorDiscard")
            End If

        End Sub

        Private Sub CostsItems_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _CostsItems.ListChanged
            CalculateSum(True)
        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As GoodsComplexOperationProduction = DirectCast(MyBase.GetClone(),  _
                GoodsComplexOperationProduction)
            result.RestoreChildListsHandles()
            Return result
        End Function

        Protected Overrides Sub OnDeserialized(ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            RestoreChildListsHandles()
        End Sub

        Protected Overrides Sub UndoChangesComplete()
            MyBase.UndoChangesComplete()
            RestoreChildListsHandles()
        End Sub

        ''' <summary>
        ''' Helper method. Takes care of TaskTimeSpans loosing its handler. See GetClone method.
        ''' </summary>
        Friend Sub RestoreChildListsHandles()
            Try
                RemoveHandler _ComponentItems.ListChanged, AddressOf ComponentItems_Changed
                RemoveHandler _CostsItems.ListChanged, AddressOf CostsItems_Changed
            Catch ex As Exception
            End Try
            AddHandler _ComponentItems.ListChanged, AddressOf ComponentItems_Changed
            AddHandler _CostsItems.ListChanged, AddressOf CostsItems_Changed
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(Goods_GoodsComplexOperationProduction_ToString, _
                Me.Date.ToString("yyyy-MM-dd"), Me.GoodsName, _DocumentNumber, _ID.ToString())
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New RuleArgs("DocumentNumber"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New RuleArgs("Content"))
            ValidationRules.AddRule(AddressOf CommonValidation.ValueObjectFieldValidation, _
                New Csla.Validation.RuleArgs("WarehouseForProduction"))
            ValidationRules.AddRule(AddressOf CommonValidation.ValueObjectFieldValidation, _
                New Csla.Validation.RuleArgs("WarehouseForComponents"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New RuleArgs("Amount"))

            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "ChronologyValidatorAcquisition"))
            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "ChronologyValidatorDiscard"))

            ValidationRules.AddRule(AddressOf TotalValueValidation, New RuleArgs("TotalValue"))

            ValidationRules.AddDependantProperty("ChronologyValidatorAcquisition", "Date", False)
            ValidationRules.AddDependantProperty("ChronologyValidatorDiscard", "Date", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property TotalValue is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function TotalValueValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As GoodsComplexOperationProduction = DirectCast(target, GoodsComplexOperationProduction)

            If Not valObj._Acquisition.TotalCost > 0 AndAlso Not valObj._ComponentItems. _
                ContainsCalculatedAtRuntimeValueGoods Then

                e.Description = Goods_GoodsComplexOperationProduction_CompositionEmpty
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Goods.GoodsOperationProduction2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationProduction1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationProduction2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationProduction3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationProduction3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new GoodsComplexOperationProduction instance.
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see> 
        ''' to be produced</param>
        ''' <param name="productionWarehouseID">an <see cref="Warehouse.ID">ID of 
        ''' the warehouse</see> to store the produced goods in</param>
        ''' <param name="componentsWarehouseID">an <see cref="Warehouse.ID">ID of 
        ''' the warehouse</see> where the components/stock are stored</param>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsComplexOperationProduction(ByVal goodsID As Integer, _
            ByVal productionWarehouseID As Integer, ByVal componentsWarehouseID As Integer) As GoodsComplexOperationProduction
            Return DataPortal.Create(Of GoodsComplexOperationProduction) _
                (New Criteria(goodsID, productionWarehouseID, componentsWarehouseID, False))
        End Function

        ''' <summary>
        ''' Gets a new GoodsComplexOperationProduction instance using a template data.
        ''' </summary>
        ''' <param name="productionWarehouseID">an <see cref="Warehouse.ID">ID of 
        ''' the warehouse</see> to store the produced goods in</param>
        ''' <param name="componentsWarehouseID">an <see cref="Warehouse.ID">ID of 
        ''' the warehouse</see> where the components/stock are stored</param>
        ''' <param name="calculationID">an <see cref="ProductionCalculation.ID">
        ''' ID of the template to use</see></param>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsComplexOperationProductionByCalculation( _
            ByVal calculationID As Integer, ByVal productionWarehouseID As Integer, _
            ByVal componentsWarehouseID As Integer) As GoodsComplexOperationProduction
            Return DataPortal.Create(Of GoodsComplexOperationProduction) _
                (New Criteria(calculationID, productionWarehouseID, componentsWarehouseID, True))
        End Function

        ''' <summary>
        ''' Gets an existing GoodsComplexOperationProduction instance from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID</see> of the operation to fetch</param>
        ''' <remarks></remarks>
        Public Shared Function GetGoodsComplexOperationProduction(ByVal id As Integer) _
            As GoodsComplexOperationProduction
            Return DataPortal.Fetch(Of GoodsComplexOperationProduction)(New Criteria(id))
        End Function

        ''' <summary>
        ''' Deletes an existing GoodsComplexOperationProduction instance from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID</see> of the operation to delete</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteGoodsComplexOperationProduction(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer = 0
            Private _ProductionWarehouseID As Integer = 0
            Private _ComponentsWarehouseID As Integer = 0
            Private _CreateUsingCalculation As Boolean = False
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public ReadOnly Property ProductionWarehouseID() As Integer
                Get
                    Return _ProductionWarehouseID
                End Get
            End Property
            Public ReadOnly Property ComponentsWarehouseID() As Integer
                Get
                    Return _ComponentsWarehouseID
                End Get
            End Property
            Public ReadOnly Property CreateUsingCalculation() As Boolean
                Get
                    Return _CreateUsingCalculation
                End Get
            End Property
            Public Sub New(ByVal nID As Integer)
                _ID = nID
            End Sub
            Public Sub New(ByVal nID As Integer, ByVal nProductionWarehouseID As Integer, _
                ByVal nComponentsWarehouseID As Integer, ByVal nCreateUsingCalculation As Boolean)
                _ID = nID
                _ProductionWarehouseID = nProductionWarehouseID
                _ComponentsWarehouseID = nComponentsWarehouseID
                _CreateUsingCalculation = nCreateUsingCalculation
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Dim baseValidator As SimpleChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator(ConvertLocalizedName(DocumentType.GoodsProduction), Nothing)

            _WarehouseForComponents = WarehouseInfoList.GetListChild.GetItem( _
                criteria.ComponentsWarehouseID, False)

            If criteria.CreateUsingCalculation Then

                Dim calculation As ProductionCalculation = ProductionCalculation. _
                    GetProductionCalculationChild(criteria.ID)

                _ComponentItems = GoodsComponentItemList.NewGoodsComponentItemList( _
                    calculation.ComponentList, calculation.Amount, _
                    _WarehouseForComponents, baseValidator)
                _CostsItems = GoodsProductionCostItemList.NewGoodsProductionCostItemList( _
                    calculation.CostList, calculation.Amount)

                _Acquisition = GoodsOperationAcquisition.NewGoodsOperationAcquisitionChild( _
                    calculation.Goods.ID, criteria.ProductionWarehouseID, baseValidator)

                _CalculationIsPerUnit = calculation.Amount
                _Acquisition.SetAmount(calculation.Amount)

                CalculateSum(False)

            Else

                _ComponentItems = GoodsComponentItemList.NewGoodsComponentItemList
                _CostsItems = GoodsProductionCostItemList.NewGoodsProductionCostItemList

                _Acquisition = GoodsOperationAcquisition.NewGoodsOperationAcquisitionChild( _
                    criteria.ID, criteria.ProductionWarehouseID, baseValidator)

            End If

            _ChronologyValidatorDiscard = ComplexChronologicValidator. _
                NewComplexChronologicValidator(baseValidator.CurrentOperationName, _
                baseValidator, Nothing, _ComponentItems.GetLimitations)

            ValidationRules.CheckRules()

            MarkNew()

        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Fetch(criteria.ID)

        End Sub

        Private Sub Fetch(ByVal operationID As Integer)

            Dim obj As ComplexOperationPersistenceObject = ComplexOperationPersistenceObject. _
                GetComplexOperationPersistenceObject(operationID, _
                GoodsComplexOperationType.Production, True)

            Fetch(obj)

        End Sub

        Private Sub Fetch(ByVal obj As ComplexOperationPersistenceObject)

            _ID = obj.ID
            _JournalEntryID = obj.JournalEntryID
            _InsertDate = obj.InsertDate
            _UpdateDate = obj.UpdateDate
            _DocumentNumber = obj.DocNo
            _WarehouseForComponents = obj.Warehouse

            _OldWarehouseForComponentsID = obj.Warehouse.ID

            Dim baseValidator As SimpleChronologicValidator = SimpleChronologicValidator. _
                GetSimpleChronologicValidator(_ID, obj.OperationDate, _
                ConvertLocalizedName(DocumentType.GoodsProduction), Nothing)

            Using myData As DataTable = OperationalLimitList.GetDataSourceForComplexOperation(_ID, obj.OperationDate)

                Dim objList As List(Of OperationPersistenceObject) = _
                    OperationPersistenceObject.GetOperationPersistenceObjectList(_ID)

                _ComponentItems = GoodsComponentItemList.GetGoodsComponentItemList( _
                    objList, baseValidator, myData)

                For Each p As OperationPersistenceObject In objList
                    If p.OperationType = GoodsOperationType.Acquisition Then
                        _Acquisition = GoodsOperationAcquisition.GetGoodsOperationAcquisitionChild( _
                            p, myData, baseValidator)
                        Exit For
                    End If
                Next

            End Using

            If _JournalEntryID > 0 Then

                Dim myComm As New SQLCommand("BookEntriesFetch")
                myComm.AddParam("?BD", _JournalEntryID)

                Using myData As DataTable = myComm.Fetch

                    Dim invertedComponentEntryList As BookEntryInternalList = _
                        _ComponentItems.GetBookEntryInternalList.GetInvertedList()

                    Dim costEntryList As BookEntryInternalList = BookEntryInternalList. _
                        NewBookEntryInternalList(BookEntryType.Kreditas)

                    For Each dr As DataRow In myData.Rows

                        If ConvertDatabaseCharID(Of BookEntryType)(CStrSafe(dr.Item(1))) _
                            = BookEntryType.Kreditas Then

                            costEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                                BookEntryType.Kreditas, CLongSafe(dr.Item(2), 0), _
                                CDblSafe(dr.Item(3), 2, 0), Nothing))

                        ElseIf CDblSafe(dr.Item(3), 2, 0) < _Acquisition.TotalCost Then

                            costEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                                BookEntryType.Kreditas, CLongSafe(dr.Item(2), 0), _
                                CRound(_Acquisition.TotalCost - CDblSafe(dr.Item(3), 2, 0)), Nothing))

                        End If

                    Next

                    costEntryList.AddRange(invertedComponentEntryList)

                    costEntryList.Aggregate()

                    _CostsItems = GoodsProductionCostItemList.GetGoodsProductionCostItemList( _
                        costEntryList, _Acquisition.Ammount, baseValidator.FinancialDataCanChange)

                End Using

            Else

                _CostsItems = GoodsProductionCostItemList.NewGoodsProductionCostItemList()

            End If

            _ChronologyValidatorDiscard = ComplexChronologicValidator.GetComplexChronologicValidator(
                _ID, _Acquisition.JournalEntryDate, baseValidator.CurrentOperationName, baseValidator,
                Nothing, _ComponentItems.GetLimitations)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            CheckIfCanUpdate()
            DoSave()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            CheckIfCanUpdate()
            DoSave()

        End Sub

        Private Sub DoSave()

            Dim obj As ComplexOperationPersistenceObject = GetPersistenceObj()

            Dim entry As General.JournalEntry = GetJournalEntry()

            Using transaction As New SqlTransaction

                Try

                    If Not entry Is Nothing Then
                        entry = entry.SaveChild
                        _JournalEntryID = entry.ID
                        obj.JournalEntryID = _JournalEntryID
                    ElseIf entry Is Nothing AndAlso _JournalEntryID > 0 Then
                        General.JournalEntry.DeleteJournalEntryChild(_JournalEntryID)
                        _JournalEntryID = 0
                        obj.JournalEntryID = 0
                    End If

                    obj = obj.SaveChild(_Acquisition.OperationLimitations.FinancialDataCanChange _
                        AndAlso _ChronologyValidatorDiscard.FinancialDataCanChange, _
                        _Acquisition.OperationLimitations.FinancialDataCanChange, _
                        _Acquisition.OperationLimitations.FinancialDataCanChange _
                        AndAlso _ChronologyValidatorDiscard.FinancialDataCanChange)

                    If IsNew Then
                        _ID = obj.ID
                        _InsertDate = obj.InsertDate
                    End If
                    _UpdateDate = obj.UpdateDate

                    _Acquisition.SaveChild(_JournalEntryID, _ID, True, _
                        Not _ChronologyValidatorDiscard.BaseValidator.FinancialDataCanChange)

                    _ComponentItems.Update(Me)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            _OldWarehouseForComponentsID = _WarehouseForComponents.ID

            MarkOld()

        End Sub

        Private Function GetPersistenceObj() As ComplexOperationPersistenceObject

            Dim obj As ComplexOperationPersistenceObject
            If IsNew Then
                obj = ComplexOperationPersistenceObject.NewComplexOperationPersistenceObject( _
                    GoodsComplexOperationType.Production, _Acquisition.GoodsInfo.ID)
            Else
                obj = ComplexOperationPersistenceObject.GetComplexOperationPersistenceObject( _
                    _ID, GoodsComplexOperationType.Production)
                If obj.UpdateDate <> _UpdateDate Then Throw New Exception( _
                    My.Resources.Common_UpdateDateHasChanged)
            End If

            obj.AccountOperation = 0
            obj.Content = _Acquisition.Description
            obj.DocNo = _DocumentNumber
            obj.JournalEntryID = _JournalEntryID
            obj.OperationDate = _Acquisition.JournalEntryDate
            obj.SecondaryWarehouse = _Acquisition.Warehouse
            obj.Warehouse = _WarehouseForComponents

            Return obj

        End Function



        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            Dim operationToDelete As GoodsComplexOperationProduction = _
                New GoodsComplexOperationProduction
            operationToDelete.Fetch(DirectCast(criteria, Criteria).ID)

            If Not operationToDelete._ChronologyValidatorDiscard.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsComplexOperationProduction_InvalidDelete, _
                    vbCrLf, operationToDelete._ChronologyValidatorDiscard.FinancialDataCanChangeExplanation))
            ElseIf Not operationToDelete._Acquisition.OperationLimitations.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsComplexOperationProduction_InvalidDelete, _
                    vbCrLf, operationToDelete._Acquisition.OperationLimitations.FinancialDataCanChangeExplanation))
            End If

            If operationToDelete.JournalEntryID > 0 Then
                IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted( _
                    operationToDelete.JournalEntryID, DocumentType.GoodsProduction)
            End If

            Using transaction As New SqlTransaction

                Try

                    ComplexOperationPersistenceObject.Delete(operationToDelete.ID, _
                        True, True, True)

                    If operationToDelete.JournalEntryID > 0 Then
                        General.JournalEntry.DeleteJournalEntryChild(operationToDelete.JournalEntryID)
                    End If

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkNew()

        End Sub


        Private Function GetJournalEntry() As General.JournalEntry

            Dim result As General.JournalEntry
            If IsNew OrElse Not _JournalEntryID > 0 Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.GoodsProduction)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_JournalEntryID, DocumentType.GoodsProduction)
            End If

            result.Content = _Acquisition.Description
            result.Date = _Acquisition.JournalEntryDate
            result.DocNumber = _DocumentNumber

            Dim fullBookEntryList As BookEntryInternalList = BookEntryInternalList. _
                NewBookEntryInternalList(BookEntryType.Kreditas)

            fullBookEntryList.AddRange(_ComponentItems.GetBookEntryInternalList())
            fullBookEntryList.AddRange(_CostsItems.GetBookEntryInternalList)
            fullBookEntryList.AddRange(_Acquisition.GetTotalBookEntryList)

            fullBookEntryList.Aggregate()

            If Not fullBookEntryList.Count > 0 Then Return Nothing

            If _ChronologyValidatorDiscard.FinancialDataCanChange AndAlso _Acquisition. _
                OperationLimitations.FinancialDataCanChange Then

                result.DebetList.Clear()
                result.CreditList.Clear()

                result.DebetList.LoadBookEntryListFromInternalList(fullBookEntryList, False, False)
                result.CreditList.LoadBookEntryListFromInternalList(fullBookEntryList, False, False)

            End If

            If Not result.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_FailedToCreateJournalEntry, _
                    vbCrLf, result.ToString, vbCrLf, result.GetAllBrokenRules))
            End If

            Return result

        End Function

        Private Sub CheckIfCanUpdate()

            If IsNew Then
                _ComponentItems.CheckIfCanUpdate(Me, Nothing)
                _Acquisition.CheckIfCanUpdate(Me.ChronologyValidatorAcquisition.BaseValidator, _
                    Nothing)
            Else
                Using myData As DataTable = OperationalLimitList.GetDataSourceForComplexOperation( _
                    _ID, _ChronologyValidatorDiscard.CurrentOperationDate)
                    _ComponentItems.CheckIfCanUpdate(Me, myData)
                    _Acquisition.CheckIfCanUpdate(Me.ChronologyValidatorAcquisition.BaseValidator, _
                    myData)
                End Using
            End If

            CalculateSum(False)

            ValidationRules.CheckRules()
            If Not IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, _
                    vbCrLf, GetAllBrokenRules()))
            End If

        End Sub

#End Region

    End Class

End Namespace