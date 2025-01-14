﻿
Imports ApskaitaObjects.My.Resources
Imports Csla.Validation

Namespace Goods

    ''' <summary>
    ''' Represents a simple goods price cut operation (when the balance value 
    ''' is reduced to the market value or restored to the acquisition value).
    ''' </summary>
    ''' <remarks>See methodology for BAS No 9 ""Stores"" para. 24 - 33 for details.
    ''' Encapsulates a <see cref="General.JournalEntry">JournalEntry</see>
    ''' of type <see cref="DocumentType.GoodsRevalue">DocumentType.GoodsRevalue</see>.
    ''' Values are stored using <see cref="OperationPersistenceObject">OperationPersistenceObject</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsOperationPriceCut
        Inherits BusinessBase(Of GoodsOperationPriceCut)
        Implements IIsDirtyEnough, IGetErrorForListItem, IValidationMessageProvider

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _JournalEntryID As Integer = 0
        Private _GoodsInfo As GoodsSummary = Nothing
        Private _OperationLimitations As OperationalLimitList = Nothing
        Private _ComplexOperationID As Integer = 0
        Private _ComplexOperationType As GoodsComplexOperationType = GoodsComplexOperationType.BulkPriceCut
        Private _ComplexOperationHumanReadable As String = ""
        Private _DocumentNumber As String = ""
        Private _Date As Date = Today
        Private _Description As String = ""
        Private _AmountInWarehouseAccounts As Double = 0
        Private _TotalValueInWarehouseAccounts As Double = 0
        Private _TotalValueCurrentPriceCut As Double = 0
        Private _UnitValueInWarehouseAccounts As Double = 0
        Private _TotalValuePriceCut As Double = 0
        Private _UnitValuePriceCut As Double = 0
        Private _TotalValueAfterPriceCut As Double = 0
        Private _UnitValueAfterPriceCut As Double = 0
        Private _AccountPriceCutCosts As Long = 0
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now


        ''' <summary>
        ''' Gets an ID of the operation that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.ID">OperationPersistenceObject.ID</see>.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the operation was inserted into the database.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.InsertDate">OperationPersistenceObject.InsertDate</see>.</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the operation was last updated.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.UpdateDate">OperationPersistenceObject.UpdateDate</see>.</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="ComplexOperationPersistenceObject.ID">ID of the complex 
        ''' goods operation</see> that the operation is a part of (if any).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.ComplexOperationID">OperationPersistenceObject.ComplexOperationID</see>.</remarks>
        Public ReadOnly Property ComplexOperationID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationID
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="ComplexOperationPersistenceObject.OperationType">type 
        ''' of the complex goods operation</see> that the operation is a part of.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.ComplexOperationType">OperationPersistenceObject.ComplexOperationType</see>.</remarks>
        Public ReadOnly Property ComplexOperationType() As GoodsComplexOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationType
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="ComplexOperationPersistenceObject.OperationType">localized
        ''' human readable type of the complex goods operation</see> that the operation 
        ''' is a part of (if any).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.ComplexOperationHumanReadable">OperationPersistenceObject.ComplexOperationHumanReadable</see>.</remarks>
        Public ReadOnly Property ComplexOperationHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationHumanReadable.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.JournalEntry.ID">ID of the journal entry</see>
        ''' that is encapsulated by the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.JournalEntryID">OperationPersistenceObject.JournalEntryID</see>.</remarks>
        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="GoodsSummary">general information about the goods</see> 
        ''' that the operation operates with.
        ''' </summary>
        ''' <remarks>Is set when creating a new operation and cannot be changed afterwards.
        ''' Corresponds to <see cref="OperationPersistenceObject.GoodsInfo">OperationPersistenceObject.GoodsInfo</see>.</remarks>
        Public ReadOnly Property GoodsInfo() As GoodsSummary
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsItem.Name">name of the goods</see> 
        ''' that the operation operates with.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsInfo">GoodsInfo</see> field
        ''' to enable databinding in a datagridview.</remarks>
        Public ReadOnly Property GoodsName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.Name
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsItem.MeasureUnit">measure unit of the goods</see> 
        ''' that the operation operates with.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsInfo">GoodsInfo</see> field
        ''' to enable databinding in a datagridview.</remarks>
        Public ReadOnly Property GoodsMeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.MeasureUnit
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="GoodsItem.AccountingMethod">accounting method for the goods</see> 
        ''' that the operation operates with as a localized human readable string.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsInfo">GoodsInfo</see> field
        ''' to enable databinding in a datagridview.</remarks>
        Public ReadOnly Property GoodsAccountingMethod() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethodHumanReadable
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsItem.DefaultValuationMethod">current valuation method 
        ''' for the goods</see> that the operation operates with as a localized 
        ''' human readable string.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsInfo">GoodsInfo</see> field
        ''' to enable databinding in a datagridview.</remarks>
        Public ReadOnly Property GoodsValuationMethod() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.ValuationMethodHumanReadable
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsItem.AccountValueReduction">value reduction account 
        ''' of the goods</see> that the operation operates with.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsInfo">GoodsInfo</see> field
        ''' to enable databinding in a datagridview.</remarks>
        Public ReadOnly Property GoodsAccountPriceCut() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountValueReduction
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="IChronologicValidator">IChronologicValidator</see> object 
        ''' that contains business restraints on updating the operation data.
        ''' </summary>
        ''' <remarks>A <see cref="OperationalLimitList">OperationalLimitList</see> 
        ''' is used to validate a goods operation chronological business rules.</remarks>
        Public ReadOnly Property OperationLimitations() As OperationalLimitList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationLimitations
            End Get
        End Property


        ''' <summary>
        ''' Gets or sets a document number of the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.DocNo">OperationPersistenceObject.DocNo</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 30)> _
        Public Property DocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If DocumentNumberIsReadOnly Then Exit Property
                If value Is Nothing Then value = ""
                If _DocumentNumber.Trim <> value.Trim Then
                    _DocumentNumber = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a date of the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.OperationDate">OperationPersistenceObject.OperationDate</see>.</remarks>
        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If DateIsReadOnly Then Exit Property
                SetParentDate(value)
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a content (description) of the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.Content">OperationPersistenceObject.Content</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property Description() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Description.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If DescriptionIsReadOnly Then Exit Property
                If value Is Nothing Then value = ""
                If _Description.Trim <> value.Trim Then
                    _Description = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a total amount of the goods in all the <see cref="Warehouse.WarehouseAccount">
        ''' warehouses</see>.
        ''' </summary>
        ''' <remarks>Value is fetched using a <see cref="GoodsPriceInWarehouseItem">GoodsPriceInWarehouseItem</see>
        ''' helper object.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDAMOUNTGOODS)> _
        Public ReadOnly Property AmountInWarehouseAccounts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AmountInWarehouseAccounts, ROUNDAMOUNTGOODS)
            End Get
        End Property

        ''' <summary>
        ''' Gets a total balance value of the goods in all the <see cref="Warehouse.WarehouseAccount">
        ''' warehouses</see>.
        ''' </summary>
        ''' <remarks>Value is fetched using a <see cref="GoodsPriceInWarehouseItem">GoodsPriceInWarehouseItem</see>
        ''' helper object.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property TotalValueInWarehouseAccounts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueInWarehouseAccounts)
            End Get
        End Property

        ''' <summary>
        ''' Gets a current balance of the <see cref="GoodsItem.AccountValueReduction">
        ''' value reduction account</see> for the goods.
        ''' </summary>
        ''' <remarks>Positive value is for a credit balance, negative value (invalid) 
        ''' is for a debit balance.
        ''' Value is fetched using a <see cref="GoodsPriceInWarehouseItem">GoodsPriceInWarehouseItem</see>
        ''' helper object.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property TotalValueCurrentPriceCut() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueCurrentPriceCut)
            End Get
        End Property

        ''' <summary>
        ''' Gets a per unit balance value of the goods in all the <see cref="Warehouse.WarehouseAccount">
        ''' warehouses</see>.
        ''' </summary>
        ''' <remarks>Value is calculated as <see cref="TotalValueInWarehouseAccounts">TotalValueInWarehouseAccounts</see>
        ''' minus <see cref="TotalValueCurrentPriceCut">TotalValueCurrentPriceCut</see> 
        ''' divided by the <see cref="AmountInWarehouseAccounts">AmountInWarehouseAccounts</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDUNITGOODS)> _
        Public ReadOnly Property UnitValueInWarehouseAccounts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitValueInWarehouseAccounts, ROUNDUNITGOODS)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a total value of the price cut that is set by the operation.
        ''' </summary>
        ''' <remarks>Positive number represents a credit entry in the 
        ''' <see cref="GoodsItem.AccountValueReduction">value reduction account</see>
        ''' (the balance value is reduced), negative number represents a debit entry in the
        ''' <see cref="GoodsItem.AccountValueReduction">value reduction account</see>
        ''' (the balance value is increased/restored).
        ''' Corresponds to minus <see cref="OperationPersistenceObject.AccountPriceCut">OperationPersistenceObject.AccountPriceCut</see>
        ''' and <see cref="OperationPersistenceObject.AccountOperationValue">OperationPersistenceObject.AccountOperationValue</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, True, 2)> _
        Public Property TotalValuePriceCut() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValuePriceCut)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If TotalValuePriceCutIsReadOnly Then Exit Property
                If CRound(_TotalValuePriceCut) <> CRound(value) Then
                    _TotalValuePriceCut = CRound(value)
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a value of the price cut per unit that is set by the operation.
        ''' </summary>
        ''' <remarks>Value is calculated as <see cref="TotalValuePriceCut">TotalValuePriceCut</see>
        ''' divided by <see cref="AmountInWarehouseAccounts">AmountInWarehouseAccounts</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, True, ROUNDUNITGOODS)> _
        Public ReadOnly Property UnitValuePriceCut() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitValuePriceCut, ROUNDUNITGOODS)
            End Get
        End Property

        ''' <summary>
        ''' Gets a total value of the goods after the operation.
        ''' </summary>
        ''' <remarks>Value is calculated as <see cref="TotalValueInWarehouseAccounts">TotalValueInWarehouseAccounts</see>
        ''' minus <see cref="TotalValueCurrentPriceCut">TotalValueCurrentPriceCut</see>
        ''' minus <see cref="TotalValuePriceCut">TotalValuePriceCut</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property TotalValueAfterPriceCut() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueAfterPriceCut)
            End Get
        End Property

        ''' <summary>
        ''' Gets a value of the goods per unit after the operation.
        ''' </summary>
        ''' <remarks>Value is calculated as <see cref="TotalValueAfterPriceCut">TotalValueAfterPriceCut</see>
        ''' divided by <see cref="AmountInWarehouseAccounts">AmountInWarehouseAccounts</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDUNITGOODS)> _
        Public ReadOnly Property UnitValueAfterPriceCut() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitValueAfterPriceCut, ROUNDUNITGOODS)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="General.Account.ID">account</see> for the
        ''' price cut costs.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.AccountOperation">OperationPersistenceObject.AccountOperation</see>.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 5, 6)> _
        Public Property AccountPriceCutCosts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountPriceCutCosts
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountPriceCutCostsIsReadOnly Then Exit Property
                If _AccountPriceCutCosts <> value Then
                    _AccountPriceCutCosts = value
                    PropertyHasChanged()
                End If
            End Set
        End Property



        ''' <summary>
        ''' Whether the <see cref="DocumentNumber">DocumentNumber</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DocumentNumberIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return IsChild OrElse _ComplexOperationID > 0
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="Date">Date</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DateIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange OrElse _
                    IsChild OrElse _ComplexOperationID > 0
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="Description">Description</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DescriptionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not IsChild AndAlso _ComplexOperationID > 0
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="TotalValuePriceCut">TotalValuePriceCut</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TotalValuePriceCutIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not IsChild AndAlso _ComplexOperationID > 0)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="AccountPriceCutCosts">AccountPriceCutCosts</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountPriceCutCostsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not IsChild AndAlso _ComplexOperationID > 0)
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_DocumentNumber.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Description.Trim) _
                    OrElse CRound(_TotalValuePriceCut) <> 0)
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid
            End Get
        End Property


        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error), False)
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then
                result = AddWithNewLine(result, _
                    Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning), False)
            End If
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
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


        Private Sub RecalculateAll(ByVal raisePropertyChanged As Boolean)

            If CRound(_AmountInWarehouseAccounts, ROUNDAMOUNTGOODS) > 0 Then
                _UnitValueInWarehouseAccounts = CRound(CRound(_TotalValueInWarehouseAccounts _
                    - _TotalValueCurrentPriceCut) / _AmountInWarehouseAccounts, ROUNDUNITGOODS)
            Else
                _UnitValueInWarehouseAccounts = 0
            End If

            If raisePropertyChanged Then PropertyHasChanged("UnitValueInWarehouseAccounts")

            Recalculate(raisePropertyChanged)

        End Sub

        Private Sub Recalculate(ByVal raisePropertyChanged As Boolean)

            _TotalValueAfterPriceCut = CRound(_TotalValueInWarehouseAccounts _
                - _TotalValueCurrentPriceCut - _TotalValuePriceCut)

            If CRound(_AmountInWarehouseAccounts, ROUNDAMOUNTGOODS) > 0 Then
                _UnitValuePriceCut = CRound(_TotalValuePriceCut _
                    / _AmountInWarehouseAccounts, ROUNDUNITGOODS)
                _UnitValueAfterPriceCut = CRound(_TotalValueAfterPriceCut _
                    / _AmountInWarehouseAccounts, ROUNDUNITGOODS)
            Else
                _UnitValuePriceCut = 0
                _UnitValueAfterPriceCut = 0
            End If

            If raisePropertyChanged Then
                PropertyHasChanged("TotalValueAfterPriceCut")
                PropertyHasChanged("UnitValuePriceCut")
                PropertyHasChanged("UnitValueAfterPriceCut")
            End If

        End Sub


        ''' <summary>
        ''' Sets properties that are handled by a parent document 
        ''' and do not require realtime validation but do require validation before update.
        ''' </summary>
        ''' <param name="parentDocumentNumber">A parent document number.</param>
        ''' <param name="parentContent">A parent content.</param>
        ''' <remarks>Should be invoked before a parent document updates the operation.</remarks>
        Friend Sub SetParentProperties(ByVal parentDocumentNumber As String, _
            ByVal parentContent As String)

            If _DocumentNumber.Trim <> parentDocumentNumber.Trim Then
                _DocumentNumber = parentDocumentNumber.Trim
                PropertyHasChanged("DocumentNumber")
            End If

        End Sub

        ''' <summary>
        ''' Sets a new operation date as provided by the parent document.
        ''' </summary>
        ''' <param name="parentDate">a new date of the parent document</param>
        ''' <remarks></remarks>
        Friend Sub SetParentDate(ByVal parentDate As Date)

            If _Date.Date <> parentDate.Date Then

                _Date = parentDate.Date
                PropertyHasChanged("Date")

                If CRound(_AmountInWarehouseAccounts, ROUNDAMOUNTGOODS) > 0 OrElse _
                    CRound(_TotalValueInWarehouseAccounts) > 0 OrElse _
                    CRound(_TotalValueCurrentPriceCut) <> 0 Then

                    _AmountInWarehouseAccounts = 0
                    _TotalValueInWarehouseAccounts = 0
                    _TotalValueCurrentPriceCut = 0

                    PropertyHasChanged("AmountInWarehouseAccounts")
                    PropertyHasChanged("TotalValueInWarehouseAccounts")
                    PropertyHasChanged("TotalValueCurrentPriceCut")

                    RecalculateAll(True)

                End If

            End If

        End Sub


        ''' <summary>
        ''' Gets a param object for a <see cref="GoodsPriceInWarehouseItem">query object</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetGoodsPriceInWarehouseParam() As GoodsPriceInWarehouseParam
            Return GoodsPriceInWarehouseParam.NewGoodsPriceCutParam(_GoodsInfo.ID, _ID)
        End Function

        ''' <summary>
        ''' Sets new initial amount and value of the goods in the warehouses).
        ''' </summary>
        ''' <param name="value">a query object containing information about amount 
        ''' and value of the goods in the warehouses at a certain date.
        ''' </param>
        ''' <remarks></remarks>
        Public Sub RefreshValuesInWarehouse(ByVal value As GoodsPriceInWarehouseItem)

            If Not _OperationLimitations.FinancialDataCanChange Then Throw New Exception( _
                String.Format(Goods_GoodsOperationPriceCut_CannotChangeFinancialData, _
                vbCrLf, _OperationLimitations.FinancialDataCanChangeExplanation))
            If value.GoodsID <> _GoodsInfo.ID Then Throw New ArgumentException( _
                Goods_GoodsOperationPriceCut_GoodsIdMismatch)
            If value.Date.Date <> _Date.Date Then Throw New ArgumentException( _
                String.Format(Goods_GoodsOperationPriceCut_DateMismatch, _
                value.Date.ToString("yyyy-MM-dd"), _Date.ToString("yyyy-MM-dd")))

            _AmountInWarehouseAccounts = value.AmountInWarehouseAccounts
            _TotalValueInWarehouseAccounts = value.TotalValueInWarehouseAccounts
            _TotalValueCurrentPriceCut = value.TotalValueCurrentPriceCut

            PropertyHasChanged("AmountInWarehouseAccounts")
            PropertyHasChanged("TotalValueInWarehouseAccounts")
            PropertyHasChanged("TotalValueCurrentPriceCut")

            RecalculateAll(True)

        End Sub


        Public Overrides Function Save() As GoodsOperationPriceCut
            Return MyBase.Save
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Goods_GoodsOperationPriceCut_ToString, _
                _GoodsInfo.Name, _ID.ToString)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New RuleArgs("AmountInWarehouseAccounts"))
            ValidationRules.AddRule(AddressOf CommonValidation.AccountFieldValidation, _
                New RuleArgs("AccountPriceCutCosts"))

            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "OperationLimitations"))


            ValidationRules.AddRule(AddressOf RootStringFieldValidation, _
                New RuleArgs("DocumentNumber"))
            ValidationRules.AddRule(AddressOf RootStringFieldValidation, _
                New RuleArgs("Description"))

            ValidationRules.AddRule(AddressOf TotalValuePriceCutValidation, _
                New Validation.RuleArgs("TotalValuePriceCut"))
            ValidationRules.AddDependantProperty("TotalValueInWarehouseAccounts", _
                "TotalValuePriceCut", False)
            ValidationRules.AddDependantProperty("TotalValueCurrentPriceCut", _
                "TotalValuePriceCut", False)

            ValidationRules.AddDependantProperty("OperationLimitations", "Date", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of a string property would only get validated
        ''' for a root object.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function RootStringFieldValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            If DirectCast(target, GoodsOperationPriceCut).IsChild Then Return True

            Return CommonValidation.StringFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property TotalValuePriceCut is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function TotalValuePriceCutValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As GoodsOperationPriceCut = DirectCast(target, GoodsOperationPriceCut)

            If CRound(valObj._TotalValueInWarehouseAccounts - valObj._TotalValueCurrentPriceCut _
                - valObj._TotalValuePriceCut) <= 0 Then
                e.Description = Goods_GoodsOperationPriceCut_PriceCutBelowZero
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf CRound(valObj._TotalValuePriceCut + valObj._TotalValueCurrentPriceCut) < 0 Then
                e.Description = Goods_GoodsOperationPriceCut_PriceCutCannotIncreaseValue
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return CommonValidation.DoubleFieldValidation(target, e)

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Goods.GoodsOperationPriceCut2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationPriceCut1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationPriceCut2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationPriceCut3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationPriceCut3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new GoodsOperationPriceCut instance.
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' that the operation operates with</param>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsOperationPriceCut(ByVal goodsID As Integer) As GoodsOperationPriceCut
            Return DataPortal.Create(Of GoodsOperationPriceCut)(New Criteria(goodsID))
        End Function

        ''' <summary>
        ''' Gets a new GoodsOperationPriceCut instance as a child operation 
        ''' for a parent complex goods operation.
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' that the operation operates with</param>
        ''' <param name="parentValidator">a chronology validator of the parent 
        ''' complex goods operation</param>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsOperationPriceCutChild(ByVal goodsID As Integer, _
            ByVal parentValidator As IChronologicValidator) As GoodsOperationPriceCut
            Return New GoodsOperationPriceCut(goodsID, parentValidator)
        End Function

        ''' <summary>
        ''' Gets an existing GoodsOperationPriceCut instance from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID</see> of the operation to fetch</param>
        ''' <remarks></remarks>
        Public Shared Function GetGoodsOperationPriceCut(ByVal id As Integer) As GoodsOperationPriceCut
            Return DataPortal.Fetch(Of GoodsOperationPriceCut)(New Criteria(id))
        End Function

        ''' <summary>
        ''' Gets a child operation for a parent complex goods operation by a 
        ''' database query result.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID</see> of the operation to fetch</param>
        '''<remarks></remarks>
        Friend Shared Function GetGoodsOperationPriceCutChild(ByVal id As Integer) As GoodsOperationPriceCut
            Return New GoodsOperationPriceCut(id)
        End Function

        ''' <summary>
        ''' Gets a child operation for a parent complex goods operation by a 
        ''' database query result.
        ''' </summary>
        ''' <param name="dr">a database query result containing the operation data</param>
        ''' <param name="limitationsDataSource">a datasource for the 
        ''' <see cref="OperationalLimitList">OperationalLimitList</see></param>
        ''' <param name="parentValidator">a chronology validator of the parent 
        ''' complex goods operation</param>
        '''<remarks></remarks>
        Friend Shared Function GetGoodsOperationPriceCutChild(ByVal dr As DataRow, _
            ByVal limitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator) As GoodsOperationPriceCut
            Return New GoodsOperationPriceCut(dr, limitationsDataSource, parentValidator)
        End Function

        ''' <summary>
        ''' Deletes an existing GoodsOperationPriceCut instance from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID</see> of the operation to delete</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteGoodsOperationPriceCut(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal goodsID As Integer, ByVal parentValidator As IChronologicValidator)
            MarkAsChild()
            DoCreate(goodsID, parentValidator)
        End Sub

        Private Sub New(ByVal nID As Integer)
            MarkAsChild()
            DoFetch(nID)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal limitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator)
            MarkAsChild()
            DoFetch(dr, limitationsDataSource, parentValidator)
        End Sub


#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private mId As Integer = 0
            Public ReadOnly Property Id() As Integer
                Get
                    Return mId
                End Get
            End Property
            Public Sub New(ByVal id As Integer)
                mId = id
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            DoCreate(criteria.Id, Nothing)

        End Sub

        Private Sub DoCreate(ByVal goodsID As Integer, ByVal parentValidator As IChronologicValidator)

            If Not goodsID > 0 Then
                Throw New ArgumentException(Goods_GoodsOperationPriceCut_GoodsIdNull)
            End If

            Dim myComm As New SQLCommand("CreateGoodsOperationPriceCut")
            myComm.AddParam("?DT", Today.Date)
            myComm.AddParam("?GD", goodsID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Common_ObjectNotFound, My.Resources.Goods_GoodsItem_TypeName, _
                    goodsID.ToString()))

                Dim dr As DataRow = myData.Rows(0)

                _AmountInWarehouseAccounts = CDblSafe(dr.Item(0), ROUNDAMOUNTGOODS, 0)
                _TotalValueInWarehouseAccounts = CDblSafe(dr.Item(1), 2, 0)
                _TotalValueCurrentPriceCut = -CDblSafe(dr.Item(2), 2, 0)
                _GoodsInfo = GoodsSummary.GetGoodsSummary(dr, 3)

                RecalculateAll(False)

            End Using

            _OperationLimitations = OperationalLimitList.NewOperationalLimitList( _
                _GoodsInfo, GoodsOperationType.PriceCut, 0, parentValidator)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            DoFetch(criteria.Id)

        End Sub

        Private Sub DoFetch(ByVal nID As Integer)

            If Not nID > 0 Then
                Throw New ArgumentException(Goods_GoodsOperationPriceCut_OperationIdNull)
            End If

            Dim myComm As New SQLCommand("FetchGoodsOperationPriceCut")
            myComm.AddParam("?OD", nID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Common_ObjectNotFound, My.Resources.Goods_GoodsOperationPriceCut_TypeName, _
                    nID.ToString()))

                DoFetch(myData.Rows(0), Nothing, Nothing)

            End Using

        End Sub

        Private Sub DoFetch(ByVal dr As DataRow, ByVal limitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator)

            If ConvertDatabaseID(Of GoodsOperationType)(CIntSafe(dr.Item(2), 0)) _
                   <> GoodsOperationType.PriceCut Then
                Throw New Exception(String.Format(Goods_GoodsOperationPriceCut_InvalidOperationType, _
                    ConvertLocalizedName(ConvertDatabaseID(Of GoodsOperationType) _
                    (CIntSafe(dr.Item(2), 0)))))
            End If

            _ID = CIntSafe(dr.Item(0), 0)
            _Date = CDateSafe(dr.Item(1), Today)
            _JournalEntryID = CIntSafe(dr.Item(3), 0)
            _DocumentNumber = CStrSafe(dr.Item(4)).Trim
            _Description = CStrSafe(dr.Item(5)).Trim
            _TotalValuePriceCut = -CDblSafe(dr.Item(6), 2, 0)
            _ComplexOperationID = CIntSafe(dr.Item(7), 0)
            If _ComplexOperationID > 0 Then
                _ComplexOperationType = ConvertDatabaseID(Of GoodsComplexOperationType) _
                (CIntSafe(dr.Item(8), 0))
                _ComplexOperationHumanReadable = ConvertLocalizedName(_ComplexOperationType)
            End If
            _AccountPriceCutCosts = CLongSafe(dr.Item(9), 0)
            _InsertDate = CTimeStampSafe(dr.Item(10))
            _UpdateDate = CTimeStampSafe(dr.Item(11))
            _AmountInWarehouseAccounts = CDblSafe(dr.Item(12), ROUNDAMOUNTGOODS, 0)
            _TotalValueInWarehouseAccounts = CDblSafe(dr.Item(13), 2, 0)
            _TotalValueCurrentPriceCut = -CDblSafe(dr.Item(14), 2, 0)
            _GoodsInfo = GoodsSummary.GetGoodsSummary(dr, 15)

            RecalculateAll(False)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo, GoodsOperationType.PriceCut, _ID, _Date, 0, _
                parentValidator, limitationsDataSource)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            If IsChild OrElse _ComplexOperationID > 0 Then Throw New InvalidOperationException( _
                Goods_GoodsOperationPriceCut_InvalidChildSave)

            CheckIfCanUpdate(Nothing, Nothing)
            DoSave(True)

        End Sub

        Protected Overrides Sub DataPortal_Update()
            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            If IsChild OrElse _ComplexOperationID > 0 Then Throw New InvalidOperationException( _
                Goods_GoodsOperationPriceCut_InvalidChildSave)

            CheckIfCanUpdate(Nothing, Nothing)
            DoSave(True)

        End Sub

        ''' <summary>
        ''' Saves a GoodsOperationPriceCut child instance to a database.
        ''' </summary>
        ''' <remarks>Does a save operation on server side. Doesn't check for critical rules.
        ''' Critical rules checking method <see cref="CheckIfCanUpdate">CheckIfCanUpdate</see> 
        ''' needs to be invoked before starting a transaction.</remarks>
        Friend Sub SaveChild(ByVal parentComplexOperationID As Integer, _
            ByVal parentJournalEntryID As Integer, ByVal parentFinancialDataCanChange As Boolean)

            If Not IsNew AndAlso Not IsDirty Then Exit Sub

            If IsNew Then
                _JournalEntryID = parentJournalEntryID
                _ComplexOperationID = parentComplexOperationID
            End If

            DoSave(parentFinancialDataCanChange)

        End Sub

        Private Sub DoSave(ByVal parentFinancialDataCanChange As Boolean)

            Dim obj As OperationPersistenceObject = GetPersistenceObj()

            Dim entry As General.JournalEntry = Nothing
            If Not IsChild Then
                entry = GetJournalEntryForDocument()
            End If

            Using transaction As New SqlTransaction

                Try

                    If Not IsChild Then
                        entry = entry.SaveChild()
                        If IsNew Then
                            _JournalEntryID = entry.ID
                            obj.JournalEntryID = _JournalEntryID
                        End If
                    End If

                    obj = obj.Save(_OperationLimitations.FinancialDataCanChange _
                        AndAlso parentFinancialDataCanChange, False)

                    If IsNew Then
                        _ID = obj.ID
                        _InsertDate = obj.InsertDate
                    End If
                    _UpdateDate = obj.UpdateDate

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub

        Private Function GetPersistenceObj() As OperationPersistenceObject

            Dim obj As OperationPersistenceObject
            If IsNew Then
                obj = OperationPersistenceObject.NewOperationPersistenceObject( _
                    GoodsOperationType.PriceCut, _GoodsInfo.ID)
            Else
                obj = OperationPersistenceObject.GetOperationPersistenceObjectForSave( _
                    _ID, GoodsOperationType.PriceCut, _UpdateDate, IsChild)
            End If

            obj.AccountDiscounts = 0
            obj.AccountGeneral = 0
            obj.AccountPurchases = 0
            obj.AccountSalesNetCosts = 0
            obj.AmountInPurchases = 0
            obj.AccountPriceCut = -_TotalValuePriceCut
            obj.AccountOperation = _AccountPriceCutCosts
            obj.AccountOperationValue = _TotalValuePriceCut
            obj.Amount = 0
            obj.AmountInWarehouse = 0
            obj.TotalValue = 0
            obj.UnitValue = 0
            obj.Warehouse = Nothing
            obj.WarehouseID = 0
            obj.Content = _Description
            obj.DocNo = _DocumentNumber
            obj.JournalEntryID = _JournalEntryID
            obj.OperationDate = _Date
            obj.ComplexOperationID = _ComplexOperationID

            Return obj

        End Function

        Private Function GetJournalEntryForDocument() As General.JournalEntry

            Dim result As General.JournalEntry

            If IsNew Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.GoodsRevalue)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_JournalEntryID, _
                    DocumentType.GoodsRevalue)
            End If

            result.Date = _Date.Date
            result.Person = Nothing
            result.Content = String.Format(Goods_GoodsOperationPriceCut_JournalEntryContent, _Description)
            result.DocNumber = _DocumentNumber

            If _OperationLimitations.FinancialDataCanChange Then

                Dim bookEntryList As BookEntryInternalList = GetTotalBookEntryList()

                result.DebetList.LoadBookEntryListFromInternalList(bookEntryList, False, False)
                result.CreditList.LoadBookEntryListFromInternalList(bookEntryList, False, False)

            End If

            If Not result.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_FailedToCreateJournalEntry, _
                    vbCrLf, result.ToString, vbCrLf, result.GetAllBrokenRules))
            End If

            Return result

        End Function


        ''' <summary>
        ''' Deletes an existing GoodsOperationPriceCut child instance from a database.
        ''' </summary>
        ''' <remarks>Does a delete operation on server side. Doesn't check for critical rules.
        ''' Critical rules checking method <see cref="CheckIfCanDelete">CheckIfCanDelete</see> 
        ''' needs to be invoked before starting a transaction.</remarks>
        Friend Sub DeleteChild()
            DoDelete()
        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            Dim operationToDelete As GoodsOperationPriceCut = New GoodsOperationPriceCut
            operationToDelete.DataPortal_Fetch(DirectCast(criteria, Criteria).Id)

            operationToDelete.CheckIfCanDelete(Nothing, Nothing)

            If operationToDelete.JournalEntryID > 0 Then
                IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted( _
                    operationToDelete.JournalEntryID, DocumentType.GoodsRevalue)
            End If

            operationToDelete.DoDelete()

        End Sub

        Private Sub DoDelete()

            Using transaction As New SqlTransaction

                Try

                    OperationPersistenceObject.Delete(_ID, False, False)

                    If Not IsChild AndAlso _JournalEntryID > 0 Then
                        General.JournalEntry.DeleteJournalEntryChild(_JournalEntryID)
                    End If

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

        End Sub


        Friend Function GetTotalBookEntryList() As BookEntryInternalList

            Dim result As BookEntryInternalList = _
               BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            If CRound(_TotalValuePriceCut) > 0 Then

                result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                    _GoodsInfo.AccountValueReduction, _TotalValuePriceCut, Nothing))

                result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                    _AccountPriceCutCosts, _TotalValuePriceCut, Nothing))

            Else

                result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                    _GoodsInfo.AccountValueReduction, -_TotalValuePriceCut, Nothing))

                result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                    _AccountPriceCutCosts, -_TotalValuePriceCut, Nothing))

            End If

            Return result

        End Function

        Friend Sub CheckIfCanDelete(ByVal limitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator)

            _OperationLimitations = OperationalLimitList.GetUpdatedOperationalLimitList( _
                _OperationLimitations, parentValidator, limitationsDataSource)

            If Not _OperationLimitations.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsOperationPriceCut_InvalidDelete, _
                    _GoodsInfo.Name, vbCrLf, _
                    _OperationLimitations.FinancialDataCanChangeExplanation))
            End If

        End Sub

        Friend Sub CheckIfCanUpdate(ByVal limitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator)

            _OperationLimitations = OperationalLimitList.GetUpdatedOperationalLimitList( _
                _OperationLimitations, parentValidator, limitationsDataSource)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    Me.BrokenRulesCollection.ToString(RuleSeverity.Error)))
            End If

        End Sub

#End Region

    End Class

End Namespace