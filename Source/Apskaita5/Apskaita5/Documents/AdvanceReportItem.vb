﻿Imports ApskaitaObjects.Attributes

Namespace Documents

    ''' <summary>
    ''' Represents an item in a advance report document. Contains info about some document:  
    ''' (a) that was payed by the accountable person and needs to be reimbursed;
    ''' (b) under which the money was received by the accountable person and needs to be redeemed by the company.
    ''' </summary>
    ''' <remarks>Should only be used as a child of a <see cref="AdvanceReportItemList">AdvanceReportItemList</see>.
    ''' Values are stored in the database table apyskaitos.</remarks>
    <Serializable()> _
    Public NotInheritable Class AdvanceReportItem
        Inherits BusinessBase(Of AdvanceReportItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _FinancialDataCanChange As Boolean = True
        Private _ID As Integer = 0
        Private _Date As Date = Today
        Private _DocumentNumber As String = ""
        Private _Person As PersonInfo = Nothing
        Private _Content As String = ""
        Private _Income As Boolean = False
        Private _Account As Long = 0
        Private _AccountVat As Long = 0
        Private _Sum As Double = 0
        Private _VatRate As Double = 0
        Private _DeclarationSchema As VatDeclarationSchemaInfo = Nothing
        Private _SumVat As Double = 0
        Private _SumVatCorrection As Integer = 0
        Private _SumTotal As Double = 0
        Private _SumLTL As Double = 0
        Private _SumCorrectionLTL As Integer = 0
        Private _SumVatLTL As Double = 0
        Private _SumVatCorrectionLTL As Integer = 0
        Private _SumTotalLTL As Double = 0
        Private _CurrencyRateChangeEffect As Double = 0
        Private _AccountCurrencyRateChangeEffect As Long = 0
        Private _InvoiceID As Integer = 0
        Private _InvoiceIsMade As Boolean = False
        Private _InvoiceDateAndNumber As String = ""
        Private _InvoiceDate As Date = Today
        Private _InvoiceContent As String = ""
        Private _InvoiceCurrencyCode As String = ""
        Private _InvoiceCurrencyRate As Double = 0
        Private _InvoiceSumOriginal As Double = 0
        Private _InvoiceSumVatOriginal As Double = 0
        Private _InvoiceSumTotalOriginal As Double = 0
        Private _InvoiceSumLTL As Double = 0
        Private _InvoiceSumVatLTL As Double = 0
        Private _InvoiceSumTotalLTL As Double = 0
        Private _InvoiceSumTotal As Double = 0


        ''' <summary>
        ''' Gets an ID of the item that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database table apyskaitos.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Returnes TRUE if the parent advance report allows financial changes due to business restrains.
        ''' </summary>
        ''' <remarks>Chronologic business restrains are provided by a <see cref="SimpleChronologicValidator">SimpleChronologicValidator</see>.</remarks>
        Public ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a date of the document.
        ''' </summary>
        ''' <remarks>Is readonly if the item represensts an invoice.
        ''' Value is stored in the database table apyskaitos.Dt.</remarks>
        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a number of the document.
        ''' </summary>
        ''' <remarks>Is readonly if the item represensts an invoice.
        ''' Value is stored in the database table apyskaitos.DocNr.</remarks>
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
        ''' Gets or sets a person that the document is addressed for (a buyer or a supplier).
        ''' </summary>
        ''' <remarks>Is readonly if the item represensts an invoice.
        ''' Use <see cref="HelperLists.PersonInfoList">HelperLists.PersonInfoList</see> for a datasource.
        ''' Value is stored in the database table apyskaitos.Analit.</remarks>
        <PersonFieldAttribute(ValueRequiredLevel.Mandatory)> _
        Public Property Person() As PersonInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Person
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As PersonInfo)
                CanWriteProperty(True)
                If PersonIsReadOnly Then Exit Property
                If Not (_Person Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Person Is Nothing AndAlso Not value Is Nothing AndAlso _Person = value) Then
                    _Person = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a content (description) of the document.
        ''' </summary>
        ''' <remarks>Value is stored in the database table apyskaitos.Aprasas.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Content.Trim <> value.Trim Then
                    _Content = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the accountable person received money on behalf of the company.
        ''' </summary>
        ''' <remarks>Is readonly if the item represensts an invoice.
        ''' Value is stored in the database table apyskaitos.Tipas as value 
        ''' <see cref="BookEntryType.Kreditas">BookEntryType.Kreditas</see>.</remarks>
        Public Property Income() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Income
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If IncomeIsReadOnly Then Exit Property
                If _Income <> value Then
                    _Income = value
                    PropertyHasChanged()
                    PropertyHasChanged("Expenses")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the accountable person payed money on behalf of the company.
        ''' </summary>
        ''' <remarks>Is readonly if the item represensts an invoice.
        ''' Value is stored in the database table apyskaitos.Tipas
        '''  as value <see cref="BookEntryType.Debetas">BookEntryType.Debetas</see>.</remarks>
        Public Property Expenses() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _Income
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If ExpensesIsReadOnly Then Exit Property
                If _Income = value Then
                    _Income = Not value
                    PropertyHasChanged()
                    PropertyHasChanged("Income")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="General.Account.ID">account</see>: 
        ''' (a) for buyers/suppliers debts as specified by the invoice (if the item represents an invoice).
        ''' (b) for costs/revenues for the document (e.g. for a till receipt).
        ''' </summary>
        ''' <remarks>Is readonly if the item represents an invoice.
        ''' Value is stored in the database table apyskaitos.Sask.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 1, 2, 3, 4, 5, 6)> _
        Public Property Account() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountIsReadOnly Then Exit Property
                If _Account <> value Then
                    _Account = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="General.Account.ID">account</see> for 
        ''' VAT payable/receivable/non-deductable costs
        ''' (only if the item does not represent an invoice, null otherwise).
        ''' </summary>
        ''' <remarks>Is readonly and equals null if the item represents an invoice.
        ''' Value is stored in the database table apyskaitos.PVMSask.</remarks>
        <AccountField(ValueRequiredLevel.Optional, False, 2, 4, 6)> _
        Public Property AccountVat() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountVat
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountVatIsReadOnly Then Exit Property
                If _AccountVat <> value Then
                    _AccountVat = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the sum of the document (excluding VAT if any) in the currency of the parent advance report. 
        ''' </summary>
        ''' <remarks>Is readonly if the item represents an invoice.
        ''' Value is stored in the database table apyskaitos.Suma.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If SumIsReadOnly Then Exit Property
                If CRound(_Sum) <> CRound(value) Then
                    _Sum = CRound(value)
                    PropertyHasChanged()
                    CalculateSumVat(0, True)
                    CalculateSumLTL(0, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the VAT rate (if any) for the document. 
        ''' </summary>
        ''' <remarks>Is readonly and equals zero if the item represents an invoice.
        ''' Value is stored in the database table apyskaitos.PVMTarifas.</remarks>
        <TaxRateField(ValueRequiredLevel.Optional, ApskaitaObjects.Settings.TaxRateType.Vat)> _
        Public Property VatRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_VatRate)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If VatRateIsReadOnly Then Exit Property
                If CRound(_VatRate) <> CRound(value) Then
                    _VatRate = CRound(value)
                    PropertyHasChanged()
                    CalculateSumVat(0, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the applicable VAT declaration schema for the goods/services bought/sold.
        ''' </summary>
        ''' <remarks>Value is stored in the database table sfd.DeclarationSchemaID.</remarks>
        <VatDeclarationSchemaFieldAttribute(ValueRequiredLevel.Recommended, TradedItemType.Purchases)> _
        Public Property DeclarationSchema() As VatDeclarationSchemaInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DeclarationSchema
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As VatDeclarationSchemaInfo)
                CanWriteProperty(True)
                If DeclarationSchemaIsReadOnly Then Exit Property
                If Not (_DeclarationSchema Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _DeclarationSchema Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _DeclarationSchema = value) Then
                    _DeclarationSchema = value
                    If Not _DeclarationSchema Is Nothing AndAlso Not _DeclarationSchema.IsEmpty _
                        AndAlso Not VatRateIsReadOnly Then
                        VatRate = _DeclarationSchema.VatRate
                    End If
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the VAT sum of the the document in the currency of the parent advance report.
        ''' </summary>
        ''' <remarks>Value is stored in the database table apyskaitos.SumVat.</remarks>
        Public ReadOnly Property SumVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVat)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the VAT sum correction (in cents) in the currency of the parent advance report.
        ''' (in case VAT sum in the document is not equal to the sum in the currency of the 
        ''' parent advance report * VAT rate)
        ''' </summary>
        ''' <remarks>Value is calculated: the sum in the currency of the parent advance report * VAT rate
        ''' minus the VAT sum in the currency of the parent advance report.
        ''' Is readonly and equals zero if the item represents an invoice.</remarks>
        <CorrectionField()> _
        Public Property SumVatCorrection() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SumVatCorrection
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If SumVatCorrectionIsReadOnly Then Exit Property
                If _SumVatCorrection <> value Then
                    _SumVatCorrection = value
                    PropertyHasChanged()
                    CalculateSumVat(0, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total sum of the the document in the currency of the parent advance report.
        ''' (<see cref="Sum">Sum</see> plus <see cref="SumVat">SumVat</see>)
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotal)
            End Get
        End Property

        ''' <summary>
        ''' Gets the sum of the document (excluding VAT if any) in the base currency of the company. 
        ''' </summary>
        ''' <remarks>Value is stored in the database table apyskaitos.SumLTL.</remarks>
        Public ReadOnly Property SumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the correction (in cents) of the sum in the base company currency.
        ''' (in case the sum in base currency is not equal to the sum in parent advance report currency 
        ''' * parent advance report currency rate)
        ''' </summary>
        ''' <remarks>Value is calculated: the sum in parent advance report currency 
        ''' * parent advance report currency rate minus the sum in base currency.</remarks>
        <CorrectionField()> _
        Public Property SumCorrectionLTL() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SumCorrectionLTL
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If SumCorrectionLTLIsReadOnly Then Exit Property
                If _SumCorrectionLTL <> value Then
                    _SumCorrectionLTL = value
                    PropertyHasChanged()
                    CalculateSumLTL(0, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the VAT sum of the document (if any) in the base currency of the company. 
        ''' </summary>
        ''' <remarks>Value is stored in the database table apyskaitos.SumVatLTL.</remarks>
        Public ReadOnly Property SumVatLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVatLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the VAT sum correction (in cents) in the base currency of the company.
        ''' (in case VAT sum in the base currency of the company is not equal to 
        ''' the sum in the base currency of the company * VAT rate)
        ''' </summary>
        ''' <remarks>Value is calculated: the sum in the base currency of the company * VAT rate
        ''' minus the VAT sum in the base currency of the company.
        ''' Is readonly and equals zero if the item represents an invoice.</remarks>
        <CorrectionField()> _
        Public Property SumVatCorrectionLTL() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SumVatCorrectionLTL
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If SumVatCorrectionLTLIsReadOnly Then Exit Property
                If _SumVatCorrectionLTL <> value Then
                    _SumVatCorrectionLTL = value
                    PropertyHasChanged()
                    CalculateSumVatLTL(0, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total sum of the the document in the base currency of the company.
        ''' (<see cref="SumLTL">SumLTL</see> plus <see cref="SumVatLTL">SumVatLTL</see>)
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumTotalLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotalLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the sum of the currency rate change effect. 
        ''' Positive value is treated as revenue, negative value is treated as costs.
        ''' </summary>
        ''' <remarks>Value is stored in the database table apyskaitos.CurrencyRateChangeEffect.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property CurrencyRateChangeEffect() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateChangeEffect)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CurrencyRateChangeEffectIsReadOnly Then Exit Property
                If CRound(_CurrencyRateChangeEffect) <> CRound(value) Then
                    _CurrencyRateChangeEffect = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="General.Account.ID">account</see> for the currency rate change effect.
        ''' </summary>
        ''' <remarks>Value is stored in the database table apyskaitos.AccountCurrencyRateChangeEffect.</remarks>
        <AccountField(ValueRequiredLevel.Optional, True, 5, 6)> _
        Public Property AccountCurrencyRateChangeEffect() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountCurrencyRateChangeEffect
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountCurrencyRateChangeEffectIsReadOnly Then Exit Property
                If _AccountCurrencyRateChangeEffect <> value Then
                    _AccountCurrencyRateChangeEffect = value
                    PropertyHasChanged()
                End If
            End Set
        End Property


        ''' <summary>
        ''' Gets an ID of the attached invoice.
        ''' </summary>
        ''' <remarks>Is an <see cref="General.JournalEntry.ID">ID of the JournalEntry</see>
        ''' that is encapsulated by the invoice. Also corresponds to
        ''' <see cref="InvoiceMade.ID">InvoiceMade.ID</see> or <see cref="InvoiceReceived.ID">InvoiceReceived.ID</see>.
        ''' Value is stored in the database table apyskaitos.SG.</remarks>
        Public ReadOnly Property InvoiceID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InvoiceID
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the attached invoice is <see cref="InvoiceMade">InvoiceMade</see>
        ''' (otherwise - <see cref="InvoiceReceived">InvoiceReceived</see>).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property InvoiceIsMade() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InvoiceIsMade
            End Get
        End Property

        ''' <summary>
        ''' Gets a string representing the attached invoice date and number.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property InvoiceDateAndNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InvoiceDateAndNumber.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a date of the attached invoice.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property InvoiceDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InvoiceDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a content (description) of the attached invoice.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="InvoiceMade.Content">InvoiceMade.Content</see> 
        ''' or <see cref="InvoiceReceived.Content">InvoiceReceived.Content</see>.</remarks>
        Public ReadOnly Property InvoiceContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InvoiceContent.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a currency of the attached invoice.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="InvoiceMade.CurrencyCode">InvoiceMade.CurrencyCode</see> 
        ''' or <see cref="InvoiceReceived.CurrencyCode">InvoiceReceived.CurrencyCode</see>.</remarks>
        Public ReadOnly Property InvoiceCurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InvoiceCurrencyCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a currency rate as set in the attached invoice.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="InvoiceMade.CurrencyRate">InvoiceMade.CurrencyRate</see> 
        ''' or <see cref="InvoiceReceived.CurrencyRate">InvoiceReceived.CurrencyRate</see>.</remarks>
        Public ReadOnly Property InvoiceCurrencyRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_InvoiceCurrencyRate, ROUNDCURRENCYRATE)
            End Get
        End Property

        ''' <summary>
        ''' Gets a sum (excluding VAT) in the attached invoice in it's original currence.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="InvoiceMade.Sum">InvoiceMade.Sum</see> 
        ''' or <see cref="InvoiceReceived.Sum">InvoiceReceived.Sum</see>.</remarks>
        Public ReadOnly Property InvoiceSumOriginal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_InvoiceSumOriginal)
            End Get
        End Property

        ''' <summary>
        ''' Gets a VAT sum in the attached invoice in it's original currence.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="InvoiceMade.SumVat">InvoiceMade.SumVat</see> 
        ''' or <see cref="InvoiceReceived.SumVat">InvoiceReceived.SumVat</see>.</remarks>
        Public ReadOnly Property InvoiceSumVatOriginal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_InvoiceSumVatOriginal)
            End Get
        End Property

        ''' <summary>
        ''' Gets a total sum of the attached invoice in it's original currence.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="InvoiceMade.SumTotal">InvoiceMade.SumTotal</see> 
        ''' or <see cref="InvoiceReceived.SumTotal">InvoiceReceived.SumTotal</see>.
        ''' Equals <see cref="InvoiceSumOriginal">InvoiceSumOriginal</see>
        ''' plus <see cref="InvoiceSumVatOriginal">InvoiceSumVatOriginal</see></remarks>
        Public ReadOnly Property InvoiceSumTotalOriginal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_InvoiceSumTotalOriginal)
            End Get
        End Property

        ''' <summary>
        ''' Gets a sum (excluding VAT) in the attached invoice in the base currency of the company
        ''' (as set by the invoice, not calculated).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="InvoiceMade.SumLTL">InvoiceMade.SumLTL</see> 
        ''' or <see cref="InvoiceReceived.SumLTL">InvoiceReceived.SumLTL</see>.</remarks>
        Public ReadOnly Property InvoiceSumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_InvoiceSumLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets a VAT sum in the attached invoice in the base currency of the company
        ''' (as set by the invoice, not calculated).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="InvoiceMade.SumVatLTL">InvoiceMade.SumVatLTL</see> 
        ''' or <see cref="InvoiceReceived.SumVatLTL">InvoiceReceived.SumVatLTL</see>.</remarks>
        Public ReadOnly Property InvoiceSumVatLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_InvoiceSumVatLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets a total sum of the attached invoice in the base currency of the company
        ''' (as set by the invoice, not calculated).</summary>
        ''' <remarks>Corresponds to <see cref="InvoiceMade.SumTotalLTL">InvoiceMade.SumTotalLTL</see> 
        ''' or <see cref="InvoiceReceived.SumTotalLTL">InvoiceReceived.SumTotalLTL</see>.
        ''' Equals <see cref="InvoiceSumLTL">InvoiceSumLTL</see>
        ''' plus <see cref="InvoiceSumVatLTL">InvoiceSumVatLTL</see></remarks>
        Public ReadOnly Property InvoiceSumTotalLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_InvoiceSumTotalLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets a total sum of the attached invoice in the currency of the parent advance report.</summary>
        ''' <remarks>Is calculated by multiplying the currency rate of the parent advance report
        ''' and <see cref="InvoiceSumTotalLTL">InvoiceSumTotalLTL</see></remarks>
        Public ReadOnly Property InvoiceSumTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_InvoiceSumTotal)
            End Get
        End Property


        ''' <summary>
        ''' Gets whether the <see cref="Person">Person</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property PersonIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (_InvoiceID > 0)
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="Income">Income</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IncomeIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (_InvoiceID > 0 OrElse Not _FinancialDataCanChange)
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="Expenses">Expenses</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ExpensesIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (_InvoiceID > 0 OrElse Not _FinancialDataCanChange)
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="Account">Account</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (_InvoiceID > 0 OrElse Not _FinancialDataCanChange)
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="AccountVat">AccountVat</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountVatIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (_InvoiceID > 0 OrElse Not _FinancialDataCanChange)
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="Sum">Sum</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="VatRate">VatRate</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property VatRateIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (_InvoiceID > 0 OrElse Not _FinancialDataCanChange)
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="DeclarationSchema">DeclarationSchema</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DeclarationSchemaIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (_InvoiceID > 0 OrElse Not _FinancialDataCanChange)
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="SumVatCorrection">SumVatCorrection</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumVatCorrectionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (_InvoiceID > 0 OrElse Not _FinancialDataCanChange)
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="SumCorrectionLTL">SumCorrectionLTL</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumCorrectionLTLIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="SumVatCorrectionLTL">SumVatCorrectionLTL</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumVatCorrectionLTLIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (_InvoiceID > 0 OrElse Not _FinancialDataCanChange)
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="CurrencyRateChangeEffect">CurrencyRateChangeEffect</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrencyRateChangeEffectIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="AccountCurrencyRateChangeEffect">AccountCurrencyRateChangeEffect</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountCurrencyRateChangeEffectIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _FinancialDataCanChange
            End Get
        End Property



        Private Sub CalculateSumVatLTL(ByVal pCurrencyRate As Double, ByVal raisePropertyHasChanged As Boolean)

            If _InvoiceID > 0 Then

                _SumVatLTL = 0.0
                _SumTotalLTL = CRound(_SumLTL)
                _SumVatCorrectionLTL = 0

                If raisePropertyHasChanged Then
                    PropertyHasChanged("SumVatCorrectionLTL")
                End If

            Else

                _SumVatLTL = CRound(CRound(_SumVat * GetCurrencyRate(pCurrencyRate)) + _SumVatCorrectionLTL / 100)
                _SumTotalLTL = CRound(_SumLTL + _SumVatLTL)

            End If

            If raisePropertyHasChanged Then
                PropertyHasChanged("SumVatLTL")
                PropertyHasChanged("SumTotalLTL")
            End If

        End Sub

        Friend Sub CalculateSumLTL(ByVal pCurrencyRate As Double, ByVal raisePropertyHasChanged As Boolean)

            _SumLTL = CRound(CRound(_Sum * GetCurrencyRate(pCurrencyRate)) + _SumCorrectionLTL / 100)

            If _InvoiceID > 0 Then

                _SumTotalLTL = CRound(_SumLTL)

            Else

                _SumTotalLTL = CRound(_SumLTL + _SumVatLTL)

            End If

            If raisePropertyHasChanged Then
                PropertyHasChanged("SumLTL")
                PropertyHasChanged("SumTotalLTL")
            End If

        End Sub

        Private Sub CalculateSumVat(ByVal pCurrencyRate As Double, ByVal raisePropertyHasChanged As Boolean)

            If _InvoiceID > 0 Then

                _SumVat = 0.0
                _SumTotal = CRound(_Sum)
                _SumVatCorrection = 0

                If raisePropertyHasChanged Then
                    PropertyHasChanged("SumVatCorrection")
                End If

            Else

                _SumVat = CRound(CRound(_Sum * _VatRate / 100) + _SumVatCorrection / 100)
                _SumTotal = CRound(_Sum + _SumVat)

            End If

            If raisePropertyHasChanged Then
                PropertyHasChanged("SumVat")
                PropertyHasChanged("SumTotal")
            End If

            CalculateSumVatLTL(pCurrencyRate, raisePropertyHasChanged)

        End Sub

        Private Function GetCurrencyRate(ByVal pCurrencyRate As Double) As Double
            If CRound(pCurrencyRate, ROUNDCURRENCYRATE) > 0 Then Return pCurrencyRate
            If Parent Is Nothing Then Return 1
            If DirectCast(Parent, AdvanceReportItemList).CurrencyRate > 0 Then _
                Return DirectCast(Parent, AdvanceReportItemList).CurrencyRate
            Return 1
        End Function


        Friend Sub UpdateCurrency(ByVal nCurrencyRate As Double, ByVal nCurrencyCode As String, _
            ByVal baseCurrency As String)

            CalculateSumLTL(nCurrencyRate, False)
            CalculateSumVatLTL(nCurrencyRate, False)

            If _InvoiceID > 0 Then

                CalculateInvoiceSumTotal(nCurrencyRate, nCurrencyCode, baseCurrency, False)

            End If

            If Not Me.Parent Is Nothing Then
                ValidationRules.CheckRules("CurrencyRateChangeEffect")
            End If

            MarkDirty()

        End Sub

        Private Sub CalculateInvoiceSumTotal(ByVal nCurrencyRate As Double, ByVal nCurrencyCode As String, _
            ByVal baseCurrency As String, ByVal raisePropertyHasChanged As Boolean)

            If Not _InvoiceID > 0 Then Exit Sub

            ' if the invoice currency is the same as the advance report currency -> nothing to convert
            If CurrenciesEquals(nCurrencyCode, _InvoiceCurrencyCode, baseCurrency) Then

                _InvoiceSumTotal = _InvoiceSumTotalOriginal

            Else

                ' Conversion should be based on InvoiceSumTotalLTL, because 
                ' invoices also have corrections for calculated values
                _InvoiceSumTotal = ConvertCurrency(_InvoiceSumTotalLTL, "", 1.0, _
                    nCurrencyCode, nCurrencyRate, GetCurrentCompany.BaseCurrency, 2, _
                    ROUNDCURRENCYRATE, _InvoiceSumTotalLTL)

            End If

            If raisePropertyHasChanged Then
                PropertyHasChanged("InvoiceSumTotal")
            End If

        End Sub


        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String

            Dim typeString As String = ""
            If _InvoiceID > 0 Then
                If _InvoiceIsMade Then
                    typeString = My.Resources.Documents_AdvanceReportItem_SubTypeInvoiceMade
                Else
                    typeString = My.Resources.Documents_AdvanceReportItem_SubTypeInvoiceReceived
                End If
            Else
                If _Income Then
                    typeString = My.Resources.Documents_AdvanceReportItem_SubTypeOtherReceived
                Else
                    typeString = My.Resources.Documents_AdvanceReportItem_SubTypeOtherPayed
                End If
            End If

            Dim personString As String = My.Resources.Documents_AdvanceReportItem_NullPersonName
            If Not _Person Is Nothing AndAlso Not _Person.IsEmpty Then
                personString = _Person.ToString()
            End If

            Return String.Format(My.Resources.Documents_AdvanceReportItem_ToString, _
                _Date.ToString("yyyy-MM-dd"), typeString, _DocumentNumber, personString, _Content)

        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Content"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("DocumentNumber"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.AccountFieldValidation, _
                New Csla.Validation.RuleArgs("Account"))
            ValidationRules.AddRule(AddressOf CommonValidation.AccountFieldValidation, _
                New Csla.Validation.RuleArgs("AccountVat"))
            ValidationRules.AddRule(AddressOf CommonValidation.AccountFieldValidation, _
                New Csla.Validation.RuleArgs("AccountCurrencyRateChangeEffect"))
            ValidationRules.AddRule(AddressOf CommonValidation.PersonFieldValidation, _
                New Csla.Validation.RuleArgs("Person"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Sum"))


            ValidationRules.AddRule(AddressOf DateValidation, New Validation.RuleArgs("Date"))
            ValidationRules.AddRule(AddressOf AccountVatValidation, New Validation.RuleArgs("AccountVat"))
            ValidationRules.AddRule(AddressOf AccountCurrencyRateChangeEffectValidation, _
                New Validation.RuleArgs("AccountCurrencyRateChangeEffect"))
            ValidationRules.AddRule(AddressOf CurrencyRateChangeEffectValidation, _
                New Validation.RuleArgs("CurrencyRateChangeEffect"))
            ValidationRules.AddRule(AddressOf SumValidation, New Validation.RuleArgs("Sum"))
            ValidationRules.AddRule(AddressOf SumLTLValidation, New Validation.RuleArgs("SumLTL"))
            ValidationRules.AddRule(AddressOf DeclarationSchemaValidation, _
                New CommonValidation.VatDeclarationSchemaFieldRuleArgs("DeclarationSchema", _
                "VatRate"))


            ValidationRules.AddDependantProperty("VatRate", "AccountVat", False)
            ValidationRules.AddDependantProperty("VatRate", "DeclarationSchema", False)
            ValidationRules.AddDependantProperty("CurrencyRateChangeEffect", _
                "AccountCurrencyRateChangeEffect", False)
            ValidationRules.AddDependantProperty("InvoiceSumTotal", "Sum", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property Date is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DateValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As AdvanceReportItem = DirectCast(target, AdvanceReportItem)

            If valObj._InvoiceID > 0 AndAlso valObj._Date.Date < valObj._InvoiceDate.Date Then

                e.Description = My.Resources.Documents_AdvanceReportItem_InvoiceDateMismatch
                e.Severity = Validation.RuleSeverity.Warning
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountVat is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountVatValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As AdvanceReportItem = DirectCast(target, AdvanceReportItem)

            If Not valObj._InvoiceID > 0 AndAlso CRound(valObj._VatRate) > 0 _
                AndAlso Not valObj._AccountVat > 0 Then

                e.Description = My.Resources.Documents_AdvanceReportItem_AccountVatNull
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property Sum is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As AdvanceReportItem = DirectCast(target, AdvanceReportItem)

            If valObj._InvoiceID > 0 AndAlso CRound(valObj._Sum) > CRound(valObj._InvoiceSumTotal) Then

                e.Description = My.Resources.Documents_AdvanceReportItem_SumInvalid
                e.Severity = Validation.RuleSeverity.Warning
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property SumLTL is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumLTLValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As AdvanceReportItem = DirectCast(target, AdvanceReportItem)

            If Not valObj._InvoiceID > 0 Then Return True

            Dim totalWithCorrection As Double = valObj._InvoiceSumTotalLTL
            If valObj._Income Then
                totalWithCorrection = CRound(totalWithCorrection + valObj._CurrencyRateChangeEffect)
            Else
                totalWithCorrection = CRound(totalWithCorrection - valObj._CurrencyRateChangeEffect)
            End If

            If CRound(totalWithCorrection) > CRound(valObj._InvoiceSumTotalLTL) Then

                e.Description = My.Resources.Documents_AdvanceReportItem_SumLTLInvalid
                e.Severity = Validation.RuleSeverity.Warning
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountCurrencyRateChangeEffect is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountCurrencyRateChangeEffectValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As AdvanceReportItem = DirectCast(target, AdvanceReportItem)

            If CRound(valObj._CurrencyRateChangeEffect) <> 0.0 AndAlso _
                Not valObj._AccountCurrencyRateChangeEffect > 0 Then

                e.Description = My.Resources.Documents_AdvanceReportItem_AccountCurrencyRateChangeEffectNull
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property CurrencyRateChangeEffect is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function CurrencyRateChangeEffectValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As AdvanceReportItem = DirectCast(target, AdvanceReportItem)

            If valObj.Parent Is Nothing Then Return True

            If (Not valObj._InvoiceID > 0 OrElse IsBaseCurrency(valObj._InvoiceCurrencyCode, _
                GetCurrentCompany.BaseCurrency)) AndAlso _
                IsBaseCurrency(DirectCast(valObj.Parent, AdvanceReportItemList).CurrencyCode, _
                GetCurrentCompany.BaseCurrency) AndAlso _
                CRound(valObj._CurrencyRateChangeEffect) <> 0.0 Then

                e.Description = My.Resources.Documents_AdvanceReportItem_CurrencyRateChangeEffectInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that DeclarationSchema is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DeclarationSchemaValidation(ByVal target As Object, _
            ByVal e As CommonValidation.VatDeclarationSchemaFieldRuleArgs) As Boolean

            Dim valObj As AdvanceReportItem = DirectCast(target, AdvanceReportItem)

            If valObj.InvoiceID > 0 Then Return True

            Return CommonValidation.VatDeclarationSchemaFieldValidation(target, e)

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new AdvanceReportItem instance.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Shared Function NewAdvanceReportItem() As AdvanceReportItem
            Dim result As New AdvanceReportItem
            result.ValidationRules.CheckRules()
            Return result
        End Function

        ''' <summary>
        ''' Gets a new AdvanceReportItem instance with an invoice attached.
        ''' </summary>
        ''' <param name="invoiceToAdd">Invoice data.</param>
        ''' <param name="invoicePersonInfo">PersonInfo value object for the invoice 
        ''' (ActiveReports.InvoiceInfoItem does not contain such an object).</param>
        ''' <param name="nCurrencyCode">Currency code of the parent advance report.</param>
        ''' <param name="nCurrencyRate">Currency rate of the parent advance report.</param>
        ''' <remarks></remarks>
        Friend Shared Function NewAdvanceReportItem(ByVal invoiceToAdd As ActiveReports.InvoiceInfoItem, _
            ByVal invoicePersonInfo As PersonInfo, ByVal nCurrencyCode As String, _
            ByVal nCurrencyRate As Double) As AdvanceReportItem
            Return New AdvanceReportItem(invoiceToAdd, invoicePersonInfo, nCurrencyCode, nCurrencyRate)
        End Function

        ''' <summary>
        ''' Gets an existing AdvanceReportItem instance from a database.
        ''' </summary>
        ''' <param name="dr">Database qequest result.</param>
        ''' <param name="pCurrencyRate">Currency rate of the parent advance report.</param>
        ''' <param name="pCurrencyCode">Currency code of the parent advance report.</param>
        ''' <param name="nFinancialDataCanChange">Whether the parent advance report allows updating financial item data.</param>
        ''' <remarks></remarks>
        Friend Shared Function GetAdvanceReportItem(ByVal dr As DataRow, ByVal pCurrencyRate As Double, _
            ByVal pCurrencyCode As String, ByVal nFinancialDataCanChange As Boolean, _
            ByRef fetchWarnings As String) As AdvanceReportItem
            Return New AdvanceReportItem(dr, pCurrencyRate, pCurrencyCode, nFinancialDataCanChange, fetchWarnings)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub


        Private Sub New(ByVal invoiceToAdd As ActiveReports.InvoiceInfoItem, _
            ByVal invoicePersonInfo As PersonInfo, ByVal nCurrencyCode As String, _
            ByVal nCurrencyRate As Double)
            MarkAsChild()
            Create(invoiceToAdd, invoicePersonInfo, nCurrencyCode, nCurrencyRate)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal pCurrencyRate As Double, ByVal pCurrencyCode As String, _
            ByVal nFinancialDataCanChange As Boolean, ByRef fetchWarnings As String)
            MarkAsChild()
            Fetch(dr, pCurrencyRate, pCurrencyCode, nFinancialDataCanChange, fetchWarnings)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal invoiceToAdd As ActiveReports.InvoiceInfoItem, _
            ByVal invoicePersonInfo As PersonInfo, ByVal nCurrencyCode As String, _
            ByVal nCurrencyRate As Double)

            If invoiceToAdd Is Nothing OrElse Not invoiceToAdd.ID > 0 Then

                Throw New Exception(My.Resources.Documents_AdvanceReportItem_InvoiceInfoNull)

            ElseIf invoicePersonInfo Is Nothing OrElse invoicePersonInfo.IsEmpty Then

                Throw New Exception(My.Resources.Documents_AdvanceReportItem_PersonNull)

            ElseIf invoicePersonInfo.ID <> invoiceToAdd.PersonID Then

                Throw New Exception(My.Resources.Documents_AdvanceReportItem_PersonInvalid)

            End If

            _InvoiceID = invoiceToAdd.ID
            _InvoiceContent = invoiceToAdd.Content
            _InvoiceCurrencyCode = invoiceToAdd.CurrencyCode
            _InvoiceCurrencyRate = invoiceToAdd.CurrencyRate
            _InvoiceSumOriginal = invoiceToAdd.Sum
            _InvoiceSumVatOriginal = invoiceToAdd.SumVat
            _InvoiceSumTotalOriginal = invoiceToAdd.TotalSum
            _InvoiceSumLTL = invoiceToAdd.SumLTL
            _InvoiceSumVatLTL = invoiceToAdd.SumVatLTL
            _InvoiceSumTotalLTL = invoiceToAdd.TotalSumLTL
            _InvoiceDate = invoiceToAdd.Date

            If invoiceToAdd.Type = ActiveReports.InvoiceInfoType.InvoiceMade Then
                _InvoiceIsMade = True
                _InvoiceDateAndNumber = String.Format(My.Resources.Documents_AdvanceReportItem_InvoiceDateAndNumberFormat, _
                    _InvoiceDate.ToString("yyyy-MM-dd"), My.Resources.Documents_AdvanceReportItem_SubTypeInvoiceMade, _
                    invoiceToAdd.Number)
                _Income = True
            Else
                _InvoiceIsMade = False
                _InvoiceDateAndNumber = String.Format(My.Resources.Documents_AdvanceReportItem_InvoiceDateAndNumberFormat, _
                    _InvoiceDate.ToString("yyyy-MM-dd"), My.Resources.Documents_AdvanceReportItem_SubTypeInvoiceReceived, _
                    invoiceToAdd.Number)
                _Income = False
            End If

            CalculateInvoiceSumTotal(nCurrencyRate, nCurrencyCode, GetCurrentCompany.BaseCurrency, False)

            _Date = invoiceToAdd.Date
            _DocumentNumber = invoiceToAdd.Number
            _Person = invoicePersonInfo
            _Content = invoiceToAdd.Content
            _Account = invoiceToAdd.PersonAccount
            _AccountVat = 0 ' invoice can have multiple VAT accounts
            _Sum = _InvoiceSumTotal
            _VatRate = 0 ' invoice can have multiple VAT rates
            _SumVat = 0 ' no point in showing invoice VAT
            _SumVatCorrection = 0
            _SumTotal = _InvoiceSumTotal
            _SumCorrectionLTL = Convert.ToInt32(CRound(_InvoiceSumTotalLTL - _
                CRound(_Sum * nCurrencyRate)) * 100) ' ???
            _SumLTL = CRound(CRound(_Sum * nCurrencyRate) + _SumCorrectionLTL / 100)
            _SumVatLTL = 0
            _SumVatCorrectionLTL = 0
            _SumTotalLTL = _SumLTL
            _CurrencyRateChangeEffect = 0
            _AccountCurrencyRateChangeEffect = 0

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow, ByVal pCurrencyRate As Double, _
            ByVal pCurrencyCode As String, ByVal nFinancialDataCanChange As Boolean, _
            ByRef fetchWarnings As String)

            _ID = CIntSafe(dr.Item(0), 0)
            _Date = CDateSafe(dr.Item(1), Today)
            _DocumentNumber = CStrSafe(dr.Item(2)).Trim
            _Content = CStrSafe(dr.Item(3)).Trim
            _Income = (Utilities.ConvertDatabaseCharID(Of BookEntryType)(CStrSafe(dr.Item(4))) _
                = BookEntryType.Kreditas)

            _InvoiceID = CIntSafe(dr.Item(14), 0)

            _Sum = CDblSafe(dr.Item(5), 2, 0)
            _VatRate = CDblSafe(dr.Item(6), 2, 0)
            _SumVat = CDblSafe(dr.Item(7), 2, 0)
            If _InvoiceID > 0 Then
                _SumVatCorrection = 0
                _SumVat = 0
            Else
                ' _SumVat = CRound(CRound(_Sum * _VatRate / 100) + _SumVatCorrection / 100)
                _SumVatCorrection = Convert.ToInt32(Math.Floor(CRound(_SumVat - CRound(_Sum * _VatRate / 100)) * 100))
            End If
            _SumTotal = CRound(_Sum + _SumVat)
            _SumLTL = CDblSafe(dr.Item(8), 2, 0)
            ' _SumLTL = CRound(CRound(_Sum * GetCurrencyRate(pCurrencyRate)) + _SumCorrectionLTL / 100)
            _SumCorrectionLTL = Convert.ToInt32(Math.Floor(CRound(_SumLTL - CRound(_Sum * pCurrencyRate)) * 100))
            _SumVatLTL = CDblSafe(dr.Item(9), 2, 0)
            If _InvoiceID > 0 Then
                _SumVatCorrectionLTL = 0
                _SumVatLTL = 0.0
            Else
                ' _SumVatLTL = CRound(CRound(_SumVat * GetCurrencyRate(pCurrencyRate)) + _SumVatCorrectionLTL / 100)
                _SumVatCorrectionLTL = Convert.ToInt32(Math.Floor(CRound(_SumVatLTL - CRound(_SumVat * pCurrencyRate)) * 100))
            End If
            _SumTotalLTL = CRound(_SumLTL + _SumVatLTL)
            _CurrencyRateChangeEffect = CDblSafe(dr.Item(10), 2, 0)
            _AccountCurrencyRateChangeEffect = CLongSafe(dr.Item(11), 0)
            _Account = CLongSafe(dr.Item(12), 0)
            _AccountVat = CLongSafe(dr.Item(13), 0)

            _Person = PersonInfo.GetPersonInfo(dr, 27)
            _DeclarationSchema = VatDeclarationSchemaInfo.GetVatDeclarationSchemaInfo(dr, 67)

            Dim invoiceDataHasChanged As Boolean = False

            If _InvoiceID > 0 Then

                If CIntSafe(dr.Item(15), 0) > 0 Then

                    If CLongSafe(dr.Item(16), 0) <> _Account Then

                        If nFinancialDataCanChange Then

                            fetchWarnings = AddWithNewLine(fetchWarnings, String.Format( _
                                My.Resources.Documents_AdvanceReportItem_InvoiceAccountHasChanged, _
                                Me.ToString(), My.Resources.Documents_AdvanceReportItem_CanFixInvoiceData), False)

                            _Account = CLongSafe(dr.Item(16), 0)
                            invoiceDataHasChanged = True

                        Else

                            fetchWarnings = AddWithNewLine(fetchWarnings, String.Format( _
                                My.Resources.Documents_AdvanceReportItem_InvoiceAccountHasChanged, _
                                Me.ToString(), My.Resources.Documents_AdvanceReportItem_CannotFixInvoiceData), False)

                        End If

                    End If

                    _InvoiceContent = CStrSafe(dr.Item(17)).Trim

                    If ConvertDbBoolean(CIntSafe(dr.Item(18), 0)) Then
                        _InvoiceIsMade = True
                        _InvoiceDateAndNumber = String.Format(My.Resources.Documents_AdvanceReportItem_InvoiceDateAndNumberFormat, _
                            CDateSafe(dr.Item(19), Date.MinValue).ToString("yyyy-MM-dd"), My.Resources.Documents_AdvanceReportItem_SubTypeInvoiceMade, _
                            CStrSafe(dr.Item(20)))
                    Else
                        _InvoiceIsMade = False
                        _InvoiceDateAndNumber = String.Format(My.Resources.Documents_AdvanceReportItem_InvoiceDateAndNumberFormat, _
                            CDateSafe(dr.Item(19), Date.MinValue).ToString("yyyy-MM-dd"), My.Resources.Documents_AdvanceReportItem_SubTypeInvoiceReceived, _
                            CStrSafe(dr.Item(20)))
                    End If

                    _InvoiceDate = CDateSafe(dr.Item(19), Date.MinValue)

                    If (_InvoiceIsMade AndAlso Not _Income) OrElse (Not _InvoiceIsMade AndAlso _Income) Then

                        If nFinancialDataCanChange Then

                            fetchWarnings = AddWithNewLine(fetchWarnings, String.Format( _
                                My.Resources.Documents_AdvanceReportItem_InvoiceTypeMismatch, _
                                Me.ToString(), My.Resources.Documents_AdvanceReportItem_CanFixInvoiceData), False)

                            If _InvoiceIsMade Then
                                _Income = True
                            Else
                                _Income = False
                            End If
                            invoiceDataHasChanged = True

                        Else

                            fetchWarnings = AddWithNewLine(fetchWarnings, String.Format( _
                                My.Resources.Documents_AdvanceReportItem_InvoiceTypeMismatch, _
                                Me.ToString(), My.Resources.Documents_AdvanceReportItem_CannotFixInvoiceData), False)

                        End If

                    End If

                    _InvoiceCurrencyCode = CStrSafe(dr.Item(21)).Trim
                    _InvoiceCurrencyRate = CDblSafe(dr.Item(22), ROUNDCURRENCYRATE, 0)
                    _InvoiceSumOriginal = CDblSafe(dr.Item(23), 2, 0)
                    _InvoiceSumVatOriginal = CDblSafe(dr.Item(24), 2, 0)
                    _InvoiceSumLTL = CDblSafe(dr.Item(25), 2, 0)
                    _InvoiceSumVatLTL = CDblSafe(dr.Item(26), 2, 0)
                    _InvoiceSumTotalOriginal = CRound(_InvoiceSumOriginal + _InvoiceSumVatOriginal, 2)
                    _InvoiceSumTotalLTL = CRound(_InvoiceSumLTL + _InvoiceSumVatLTL, 2)

                    CalculateInvoiceSumTotal(pCurrencyRate, pCurrencyCode, GetCurrentCompany.BaseCurrency, False)

                    Dim invoicePerson As PersonInfo = PersonInfo.GetPersonInfo(dr, 47)

                    If invoicePerson <> _Person Then

                        If nFinancialDataCanChange Then

                            fetchWarnings = AddWithNewLine(fetchWarnings, String.Format( _
                                My.Resources.Documents_AdvanceReportItem_InvoicePersonHasChanged, _
                                Me.ToString(), My.Resources.Documents_AdvanceReportItem_CanFixInvoiceData), False)

                            _Person = invoicePerson
                            invoiceDataHasChanged = True

                        Else

                            fetchWarnings = AddWithNewLine(fetchWarnings, String.Format( _
                                My.Resources.Documents_AdvanceReportItem_InvoicePersonHasChanged, _
                                Me.ToString(), My.Resources.Documents_AdvanceReportItem_CannotFixInvoiceData), False)

                        End If

                    End If

                Else

                    fetchWarnings = AddWithNewLine(fetchWarnings, String.Format( _
                        My.Resources.Documents_AdvanceReportItem_InvoiceDataMissing, _
                        Me.ToString(), _InvoiceID.ToString()), False)

                End If

            End If

            _FinancialDataCanChange = nFinancialDataCanChange

            MarkOld()

            If invoiceDataHasChanged Then MarkDirty()

            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert(ByVal parent As AdvanceReport)

            Dim myComm As New SQLCommand("InsertAdvanceReportItem")
            AddWithParamsGeneral(myComm)
            AddWithParamsFinancial(myComm)
            myComm.AddParam("?AA", parent.ID)
            myComm.AddParam("?AJ", _InvoiceID)

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As AdvanceReport)

            Dim myComm As SQLCommand
            If parent.ChronologicValidator.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateAdvanceReportItem")
                AddWithParamsFinancial(myComm)
            Else
                myComm = New SQLCommand("UpdateAdvanceReportItemNonFinancial")
            End If
            myComm.AddParam("?CD", _ID)
            AddWithParamsGeneral(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteAdvanceReportItem")
            myComm.AddParam("?CD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub


        Private Sub AddWithParamsGeneral(ByRef myComm As SQLCommand)

            myComm.AddParam("?AB", _DocumentNumber.Trim)
            myComm.AddParam("?AC", _Content.Trim)
            myComm.AddParam("?AK", _Date.Date)
            If _Person Is Nothing OrElse _Person.IsEmpty Then
                myComm.AddParam("?AL", 0)
            Else
                myComm.AddParam("?AL", _Person.ID)
            End If

        End Sub

        Private Sub AddWithParamsFinancial(ByRef myComm As SQLCommand)

            If _Income Then
                myComm.AddParam("?AD", Utilities.ConvertDatabaseCharID(BookEntryType.Kreditas))
            Else
                myComm.AddParam("?AD", Utilities.ConvertDatabaseCharID(BookEntryType.Debetas))
            End If
            myComm.AddParam("?AE", CRound(_Sum))
            myComm.AddParam("?AH", CRound(_SumLTL))
            myComm.AddParam("?AM", _Account)
            myComm.AddParam("?AO", CRound(_CurrencyRateChangeEffect, 2))
            myComm.AddParam("?AP", _AccountCurrencyRateChangeEffect)

            If _InvoiceID > 0 Then
                myComm.AddParam("?AF", 0.0)
                myComm.AddParam("?AG", 0.0)
                myComm.AddParam("?AI", 0.0)
                myComm.AddParam("?AN", 0)
                myComm.AddParam("?AQ", 0)
            Else
                myComm.AddParam("?AF", CRound(_VatRate))
                myComm.AddParam("?AG", CRound(_SumVat))
                myComm.AddParam("?AI", CRound(_SumVatLTL))
                myComm.AddParam("?AN", _AccountVat)
                If _DeclarationSchema Is Nothing OrElse _DeclarationSchema.IsEmpty Then
                    myComm.AddParam("?AQ", 0)
                Else
                    myComm.AddParam("?AQ", _DeclarationSchema.ID)
                End If
            End If

        End Sub

        Friend Function GetBookEntryList(ByVal accountablePersonAccount As Long) As BookEntryInternalList

            Dim result As BookEntryInternalList = BookEntryInternalList. _
                NewBookEntryInternalList(BookEntryType.Debetas)

            If _Income AndAlso _InvoiceID > 0 Then

                result.Add(BookEntryInternal.NewBookEntryInternal( _
                    BookEntryType.Kreditas, _Account, _SumLTL, _Person))
                result.Add(BookEntryInternal.NewBookEntryInternal( _
                    BookEntryType.Debetas, accountablePersonAccount, _SumLTL, Nothing))

            ElseIf _Income Then

                result.Add(BookEntryInternal.NewBookEntryInternal( _
                    BookEntryType.Kreditas, _Account, _SumLTL, _Person))
                If CRound(_VatRate) > 0.0 Then
                    result.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, _AccountVat, _SumVatLTL, _Person))
                End If
                result.Add(BookEntryInternal.NewBookEntryInternal( _
                    BookEntryType.Debetas, accountablePersonAccount, _SumTotalLTL, Nothing))

            ElseIf Not _Income AndAlso _InvoiceID > 0 Then

                result.Add(BookEntryInternal.NewBookEntryInternal( _
                    BookEntryType.Debetas, _Account, _SumLTL, _Person))
                result.Add(BookEntryInternal.NewBookEntryInternal( _
                    BookEntryType.Kreditas, accountablePersonAccount, _SumLTL, Nothing))

            Else

                result.Add(BookEntryInternal.NewBookEntryInternal( _
                    BookEntryType.Debetas, _Account, _SumLTL, _Person))
                If CRound(_VatRate) > 0.0 Then
                    result.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, _AccountVat, _SumVatLTL, _Person))
                End If
                result.Add(BookEntryInternal.NewBookEntryInternal( _
                    BookEntryType.Kreditas, accountablePersonAccount, _SumTotalLTL, Nothing))

            End If

            If CRound(_CurrencyRateChangeEffect) > 0 Then
                result.Add(BookEntryInternal.NewBookEntryInternal( _
                    BookEntryType.Debetas, _Account, _CurrencyRateChangeEffect, _Person))
                result.Add(BookEntryInternal.NewBookEntryInternal( _
                    BookEntryType.Kreditas, _AccountCurrencyRateChangeEffect, _
                    _CurrencyRateChangeEffect, Nothing))

            ElseIf CRound(_CurrencyRateChangeEffect) < 0 Then
                result.Add(BookEntryInternal.NewBookEntryInternal( _
                    BookEntryType.Kreditas, _Account, -_CurrencyRateChangeEffect, _Person))
                result.Add(BookEntryInternal.NewBookEntryInternal( _
                    BookEntryType.Debetas, _AccountCurrencyRateChangeEffect, _
                    -_CurrencyRateChangeEffect, Nothing))

            End If

            Return result

        End Function

#End Region

    End Class

End Namespace