﻿Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.Attributes

Namespace Documents

    ''' <summary>
    ''' Represents a proforma invoice made (issued) by the company.
    ''' </summary>
    ''' <remarks>A standalone business object, strictly speaking not an accounting document.
    ''' Values are stored in the database table proformainvoicesmade.</remarks>
    <Serializable()> _
    Public NotInheritable Class ProformaInvoiceMade
        Inherits BusinessBase(Of ProformaInvoiceMade)
        Implements IIsDirtyEnough, IClientEmailProvider, IValidationMessageProvider, ISyncable

#Region " Business Methods "

        Private _ID As Integer = -1
        Private _Payer As PersonInfo = Nothing
        Private _Date As Date = Today
        Private _Serial As String = ""
        Private _Number As Integer = 0
        Private _Content As String = ""
        Private WithEvents _InvoiceItems As ProformaInvoiceMadeItemList
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _LanguageCode As String = LanguageCodeLith.Trim.ToUpper
        Private _LanguageName As String = GetLanguageName(LanguageCodeLith, False)
        Private _CustomInfo As String = ""
        Private _CustomInfoAltLng As String = ""
        Private _CommentsInternal As String = ""
        Private _Sum As Double = 0
        Private _SumVat As Double = 0
        Private _SumTotal As Double = 0
        Private _SumDiscount As Double = 0
        Private _SumDiscountVat As Double = 0
        Private _ExternalID As String = ""
        Private _FullNumber As String = ""
        Private _AddDateToNumberOptionWasUsed As Boolean = False
        Private _NumbersInInvoice As Integer = 0
        Private _IsDoomyInvoice As Boolean = False
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _SortedList As SortedBindingList(Of ProformaInvoiceMadeItem) = Nothing


        ''' <summary>
        ''' Gets an ID of the invoice that is assigned by the database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database field proformainvoicesmade.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Whether it is a doomy invoice (created as an example, not ment for saving to the database).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsDoomyInvoice() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsDoomyInvoice
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the invoice data was inserted into the database.
        ''' </summary>
        ''' <remarks>Value is stored in the database field proformainvoicesmade.InsertDate.</remarks>
        Public ReadOnly Property InsertDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the invoice data was last updated.
        ''' </summary>
        ''' <remarks>Value is stored in the database field proformainvoicesmade.UpdateDate.</remarks>
        Public ReadOnly Property UpdateDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a <see cref="General.Person">person</see> whom the invoice is issued to.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.PersonInfoList">PersonInfoList</see> as a datasource.
        ''' Value is stored in the database field proformainvoicesmade.PayerID.</remarks>
        <PersonFieldAttribute(ValueRequiredLevel.Mandatory)> _
        Public Property Payer() As PersonInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Payer
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As PersonInfo)

                CanWriteProperty(True)

                If _Payer <> value Then

                    _Payer = value
                    PropertyHasChanged()

                    If _Payer <> PersonInfo.Empty Then

                        LanguageCode = _Payer.LanguageCode
                        CurrencyCode = _Payer.CurrencyCode

                    End If

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the date of the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database field proformainvoicesmade.InvoiceDate.</remarks>
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
                    UpdateFullNumber(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the serial (code) of the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database field proformainvoicesmade.InvoiceSerial.</remarks>
        <DocumentSerialField(ValueRequiredLevel.Mandatory, ApskaitaObjects.Settings.DocumentSerialType.ProformaInvoice)> _
        Public Property Serial() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Serial.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Serial.Trim.ToUpper <> value.Trim.ToUpper Then
                    _Serial = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the the running number of the invoice. 
        ''' Used to generate full number according to the company rules, 
        ''' see <see cref="FullNumber">FullNumber</see> property for details.
        ''' </summary>
        ''' <remarks>Value is stored in the database field proformainvoicesmade.InvoiceNumber.</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False)> _
        Public Property Number() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Number
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _Number <> value Then
                    _Number = value
                    PropertyHasChanged()
                    UpdateFullNumber(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a full formated number of the invoice (excluding serial code) as specified by the company rules.
        ''' </summary>
        ''' <remarks>Options for formating an invoice number are as follows:
        ''' a) plain <see cref="Number">running number</see>, e.g. 123
        ''' (if <see cref="General.Company.AddDateToInvoiceNumber">Company.AddDateToInvoiceNumber</see> 
        ''' is set to false and <see cref="General.Company.NumbersInInvoice">Company.NumbersInInvoice</see> 
        ''' is set to zero);
        ''' b) <see cref="Date">Date</see> concetanated with the <see cref="Number">running number</see>, e.g. 20151010-123
        ''' (if <see cref="General.Company.AddDateToInvoiceNumber">Company.AddDateToInvoiceNumber</see> is set to true);
        ''' c) the <see cref="Number">running number</see> prefixed with '0', e.g. 00015 
        ''' (if <see cref="General.Company.AddDateToInvoiceNumber">Company.AddDateToInvoiceNumber</see> 
        ''' is set to false and <see cref="General.Company.NumbersInInvoice">Company.NumbersInInvoice</see> 
        ''' is set to a positive number).
        ''' Invoice formating rule is initialized from the company's settings, when a new invoice instance 
        ''' is created, and cannot be changed afterwards.
        ''' Invoice formating rule is defined by the properties <see cref="AddDateToNumberOptionWasUsed">AddDateToNumberOptionWasUsed</see>
        ''' and <see cref="NumbersInInvoice">NumbersInInvoice</see>.
        ''' Formating is done by the method <see cref="UpdateFullNumber">UpdateFullNumber</see>.
        ''' Value is stored in the database field proformainvoicesmade.FullInvoiceNumber.</remarks>
        Public ReadOnly Property FullNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FullNumber.Trim
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="Date">invoice date</see> should be used when formating 
        ''' the <see cref="FullNumber">invoice full number</see>.
        ''' </summary>
        ''' <remarks>Value is initialized, when a new invoice instance is created,
        ''' using <see cref="General.Company.AddDateToInvoiceNumber">Company.AddDateToInvoiceNumber</see> 
        ''' property value.
        ''' Value is stored in the database field proformainvoicesmade.AddDateToNumberOptionWasUsed.</remarks>
        Public ReadOnly Property AddDateToNumberOptionWasUsed() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AddDateToNumberOptionWasUsed
            End Get
        End Property

        ''' <summary>
        ''' Gets a minimum length of the <see cref="FullNumber">invoice full number</see>
        ''' (the lacking space is filled with '0' chars, e.g. 00015).
        ''' </summary>
        ''' <remarks>Value is initialized, when a new invoice instance is created,
        ''' using <see cref="General.Company.NumbersInInvoice">Company.NumbersInInvoice</see> property value.
        ''' Value is stored in the database field proformainvoicesmade.NumbersInInvoice.</remarks>
        Public ReadOnly Property NumbersInInvoice() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NumbersInInvoice
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a content (description) of the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database field proformainvoicesmade.InvoiceContent.</remarks>
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
        ''' Gets the invoice lines (items) collection.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property InvoiceItems() As ProformaInvoiceMadeItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InvoiceItems
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable view of the invoice lines (items) collection.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property InvoiceItemsSorted() As SortedBindingList(Of ProformaInvoiceMadeItem)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _SortedList Is Nothing Then _SortedList = _
                    New SortedBindingList(Of ProformaInvoiceMadeItem)(_InvoiceItems)
                Return _SortedList
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a currency of the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database field proformainvoicesmade.CurrencyCode.</remarks>
        <CurrencyFieldAttribute(ValueRequiredLevel.Mandatory)> _
        Public Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""

                If _CurrencyCode.Trim <> value.Trim Then

                    _CurrencyCode = value.Trim
                    PropertyHasChanged()

                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an invoice language code.
        ''' </summary>
        ''' <remarks>Value is stored in the database field proformainvoicesmade.LanguageCode.</remarks>
        <LanguageCodeFieldAttribute(ValueRequiredLevel.Mandatory, True)> _
        Public Property LanguageCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)

                CanWriteProperty(True)

                If value Is Nothing Then value = ""

                If _LanguageCode.Trim.ToUpper <> value.Trim.ToUpper Then

                    _LanguageName = GetLanguageName(value.Trim, False)

                    If String.IsNullOrEmpty(_LanguageName.Trim) Then
                        _LanguageCode = ""
                    Else
                        _LanguageCode = value.Trim.ToUpper
                    End If

                    PropertyHasChanged()
                    PropertyHasChanged("LanguageName")

                    _InvoiceItems.LanguageCode = _LanguageCode

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an invoice language name.
        ''' </summary>
        ''' <remarks>Value is stored in the database field proformainvoicesmade.LanguageCode.</remarks>
        <LanguageNameFieldAttribute(ValueRequiredLevel.Mandatory, True)> _
        Public Property LanguageName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageName
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)

                CanWriteProperty(True)

                If value Is Nothing Then value = ""

                If _LanguageName.Trim.ToUpper <> value.Trim.ToUpper Then
                    _LanguageCode = GetLanguageCode(value.Trim, False)
                    If String.IsNullOrEmpty(_LanguageCode.Trim) Then
                        _LanguageName = ""
                    Else
                        _LanguageName = value.Trim.ToUpper
                    End If
                    PropertyHasChanged()
                    PropertyHasChanged("LanguageCode")
                    _InvoiceItems.LanguageCode = _LanguageCode
                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets custom invoice info, that is ment for the client (payer), in base language.
        ''' </summary>
        ''' <remarks>Value is stored in the database field proformainvoicesmade.CustomInfo.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property CustomInfo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CustomInfo.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CustomInfo.Trim <> value.Trim Then
                    _CustomInfo = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets custom invoice info, that is ment for the client (payer), in 
        ''' <see cref="LanguageCode">invoice language</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field proformainvoicesmade.CustomInfoAltLng.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property CustomInfoAltLng() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CustomInfoAltLng.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CustomInfoAltLng.Trim <> value.Trim Then
                    _CustomInfoAltLng = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets internal comments for the invoice (accountant comments of different kinds).
        ''' </summary>
        ''' <remarks>Value is stored in the database field proformainvoicesmade.CommentsInternal.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property CommentsInternal() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CommentsInternal.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CommentsInternal.Trim <> value.Trim Then
                    _CommentsInternal = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets an external invoice ID (when the invoice data is imported from an external data source).
        ''' </summary>
        ''' <remarks>Should be unique or empty. If using multiple data sources (systems, applications),
        ''' each datasource should have unique prefix.
        ''' Value is stored in the database field proformainvoicesmade.ExternalID.</remarks>
        Public ReadOnly Property ExternalID() As String _
            Implements ISyncable.ExternalID
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ExternalID.Trim
            End Get
        End Property


        ''' <summary>
        ''' Gets the total value of the goods/services sold (excluding VAT and discount)
        ''' in <see cref="CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Sum over <see cref="ProformaInvoiceMadeItem.Sum">the items' Sum property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total VAT value (excluding discount part) in <see cref="CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Sum over <see cref="ProformaInvoiceMadeItem.SumVat">the items' SumVat property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property SumVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVat)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total value of the goods/services sold (including VAT, excluding discount)
        ''' in <see cref="CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Sum over <see cref="ProformaInvoiceMadeItem.SumTotal">the items' SumTotal property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property SumTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotal)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total discount value (excluding VAT) in <see cref="CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Sum over <see cref="ProformaInvoiceMadeItem.Discount">the items' Discount property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property SumDiscount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumDiscount)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total discount VAT value in <see cref="CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Sum over <see cref="ProformaInvoiceMadeItem.DiscountVat">the items' DiscountVat property</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property SumDiscountVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumDiscountVat)
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (_InvoiceItems.Count > 0 _
                    OrElse Not StringIsNullOrEmpty(_Content) _
                    OrElse Not StringIsNullOrEmpty(_CustomInfo) _
                    OrElse Not StringIsNullOrEmpty(_CustomInfoAltLng) _
                    OrElse Not StringIsNullOrEmpty(_CommentsInternal))
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _InvoiceItems.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _InvoiceItems.IsValid
            End Get
        End Property



        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            End If
            If Not _InvoiceItems.IsValid Then
                result = AddWithNewLine(result, _InvoiceItems.GetAllBrokenRules, False)
            End If
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            End If
            If _InvoiceItems.HasWarnings() Then
                result = AddWithNewLine(result, _InvoiceItems.GetAllWarnings, False)
            End If
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return (MyBase.BrokenRulesCollection.WarningCount > 0 _
                OrElse _InvoiceItems.HasWarnings())
        End Function


        Public Overrides Function Save() As ProformaInvoiceMade
            Return MyBase.Save
        End Function


        ''' <summary>
        ''' Adds a new <see cref="ProformaInvoiceMadeItem">ProformaInvoiceMadeItem</see> with 
        ''' a <see cref="ITradedItem">traded item</see>.
        ''' </summary>
        ''' <param name="newTradedItem">an item that is intended to be sold</param>
        ''' <param name="regionalizedDictionary">A <see cref="RegionalInfoDictionary">RegionalInfoDictionary</see> 
        ''' instance to be used for setting regional names and prices.</param>
        ''' <returns>The <see cref="ProformaInvoiceMadeItem">ProformaInvoiceMadeItem</see> 
        ''' instance that was added to the invoice.</returns>
        ''' <remarks></remarks>
        Public Function AddNewTradedItem(ByVal newTradedItem As ITradedItem, _
            Optional ByVal regionalizedDictionary As RegionalInfoDictionary = Nothing) As ProformaInvoiceMadeItem

            If newTradedItem Is Nothing Then
                Throw New Exception(My.Resources.Documents_ProformaInvoiceMade_NewAttachedOperationIsNull)
            End If

            Dim item As ProformaInvoiceMadeItem = ProformaInvoiceMadeItem.NewProformaInvoiceMadeItem( _
                _LanguageCode, _CurrencyCode, newTradedItem, regionalizedDictionary)

            _InvoiceItems.Add(item)

            Return item

        End Function


        ''' <summary>
        ''' Gets an email address that should be used when sending the invoice to the client.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetClientEmail() As String _
            Implements IClientEmailProvider.GetClientEmail
            If _Payer = PersonInfo.Empty Then Return ""
            Return _Payer.Email
        End Function

        ''' <summary>
        ''' Gets an addressee (Payer) name that should be used when sending the invoice to the client.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetClientName() As String Implements IClientEmailProvider.GetClientName
            If _Payer = PersonInfo.Empty Then Return ""
            Return _Payer.Name
        End Function


        Private Sub UpdateFullNumber(ByVal raisePropertyHasChanged As Boolean)

            Dim newNumber As String = ""

            If _AddDateToNumberOptionWasUsed Then
                newNumber = String.Format("{0}-{1}", _Date.ToString("yyyyMMdd"), _Number)
            Else
                If _NumbersInInvoice < 1 Then
                    newNumber = _Number.ToString
                Else
                    newNumber = GetMinLengthString(_Number.ToString, _NumbersInInvoice, "0"c)
                End If
            End If

            If newNumber.Trim <> _FullNumber.Trim Then
                _FullNumber = newNumber.Trim
                If raisePropertyHasChanged Then PropertyHasChanged("FullNumber")
            End If

        End Sub


        Private Sub InvoiceMadeItems_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) _
            Handles _InvoiceItems.ListChanged

            CalculateSubTotals(True)

        End Sub

        Private Sub CalculateSubTotals(ByVal raisePropertChangedEvents As Boolean)

            _Sum = 0
            _SumVat = 0
            _SumDiscount = 0
            _SumDiscountVat = 0

            For Each i As ProformaInvoiceMadeItem In _InvoiceItems
                _Sum = CRound(_Sum + i.Sum - i.Discount)
                _SumVat = CRound(_SumVat + i.SumVat - i.DiscountVat)
                _SumDiscount = CRound(_SumDiscount + i.Discount)
                _SumDiscountVat = CRound(_SumDiscountVat + i.DiscountVat)
            Next

            _SumTotal = CRound(_Sum + _SumVat)

            If raisePropertChangedEvents Then
                PropertyHasChanged("Sum")
                PropertyHasChanged("SumVat")
                PropertyHasChanged("SumDiscount")
                PropertyHasChanged("SumDiscountVat")
                PropertyHasChanged("SumTotal")
            End If

        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As ProformaInvoiceMade = DirectCast(MyBase.GetClone(), ProformaInvoiceMade)
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
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Friend Sub RestoreChildListsHandles()
            Try
                RemoveHandler _InvoiceItems.ListChanged, AddressOf InvoiceMadeItems_Changed
            Catch ex As Exception
            End Try
            AddHandler _InvoiceItems.ListChanged, AddressOf InvoiceMadeItems_Changed
        End Sub


        ''' <summary>
        ''' Gets a human friendly file name to be used when saving an invoice as a document (e.g. pdf fo email).
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetFileName() As String
            Return String.Format("ProformaInvoice_{0}_No_{1}{2}", _Date.ToString("yyyy_MM_dd"), _
                _Serial, _FullNumber)
        End Function


        ''' <summary>
        ''' Gets invoice data as a data transfer object.
        ''' </summary>
        ''' <param name="systemGuid">An ID of the system that generates the data transfer object.
        ''' Used to distinguish data transfer within and outside a system (an application instance).
        ''' Use <see cref="System.Guid">Guid.ToString</see> to generate an application instance Guid.</param>
        ''' <remarks>Used to implement data exchange with other applications.</remarks>
        Public Function GetInvoiceInfo(ByVal systemGuid As String) As InvoiceInfo.InvoiceInfo

            Dim result As New InvoiceInfo.InvoiceInfo

            result.AddDateToNumberOptionWasUsed = Me.AddDateToNumberOptionWasUsed
            result.CommentsInternal = Me._CommentsInternal
            result.Content = Me._Content
            result.CurrencyCode = Me._CurrencyCode
            result.CustomInfo = Me._CustomInfo
            result.CustomInfoAltLng = Me._CustomInfoAltLng
            result.Date = Me._Date
            result.Discount = Me._SumDiscount
            result.DiscountVat = Me._SumDiscountVat
            result.ExternalID = Me._ExternalID
            result.FullNumber = Me._FullNumber
            result.ID = Me._ID.ToString
            result.LanguageCode = Me._LanguageCode
            result.Number = Me._Number
            result.NumbersInInvoice = Me._NumbersInInvoice
            result.ProjectCode = ""
            result.Serial = Me._Serial
            result.SystemGuid = systemGuid
            result.Sum = Me._Sum
            result.SumReceived = 0
            result.SumTotal = Me._SumTotal
            result.SumVat = Me._SumVat
            result.UpdateDate = Me._UpdateDate

            If _Payer <> PersonInfo.Empty Then
                result.Payer.Address = _Payer.Address
                result.Payer.BalanceAtBegining = 0
                result.Payer.BreedCode = _Payer.InternalCode
                result.Payer.Code = _Payer.Code
                result.Payer.CodeVAT = _Payer.CodeVAT
                result.Payer.Contacts = _Payer.ContactInfo
                result.Payer.CurrencyCode = _Payer.CurrencyCode
                result.Payer.Email = _Payer.Email
                result.Payer.ExternalID = ""
                result.Payer.ID = _Payer.ID.ToString
                result.Payer.IsClient = _Payer.IsClient
                result.Payer.IsCodeLocal = False
                result.Payer.IsNaturalPerson = _Payer.IsNaturalPerson
                result.Payer.IsObsolete = _Payer.IsObsolete
                result.Payer.IsSupplier = _Payer.IsSupplier
                result.Payer.IsWorker = _Payer.IsWorker
                result.Payer.LanguageCode = _Payer.LanguageCode
                result.Payer.Name = _Payer.Name
                result.Payer.VatExemption = ""
                result.Payer.VatExemptionAltLng = ""
            End If

            result.InvoiceItems = Me._InvoiceItems.GetInvoiceItemInfoList

            Return result

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Documents_ProformaInvoiceMade_ToString, _
                _Date.ToString("yyyy-MM-dd"), _Serial, _FullNumber, _ID.ToString(), _Content)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("Content"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("Serial"))
            ValidationRules.AddRule(AddressOf CommonValidation.IntegerFieldValidation, _
                New Validation.RuleArgs("Number"))
            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyFieldValidation, _
                New Validation.RuleArgs("CurrencyCode"))
            ValidationRules.AddRule(AddressOf CommonValidation.LanguageNameValidation, _
                New Validation.RuleArgs("LanguageName"))
            ValidationRules.AddRule(AddressOf CommonValidation.PersonFieldValidation, _
                New Validation.RuleArgs("Payer"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("CustomInfo"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("CustomInfoAltLng"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("CommentsInternal"))

            ValidationRules.AddRule(AddressOf SumValidation, "Sum")
            ValidationRules.AddRule(AddressOf SumDiscountValidation, "SumDiscount")

        End Sub

        ''' <summary>
        ''' Rule ensuring that any items exist.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As ProformaInvoiceMade = DirectCast(target, ProformaInvoiceMade)

            If Not valObj._InvoiceItems.Count > 0 Then

                e.Description = My.Resources.Documents_ProformaInvoiceMade_NoItems
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return CommonValidation.DoubleFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that discount is possible.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumDiscountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As ProformaInvoiceMade = DirectCast(target, ProformaInvoiceMade)

            If Not CommonValidation.DoubleFieldValidation(target, e) Then Return False

            If CRound(valObj._SumDiscount, 2) > CRound(valObj._Sum, 2) Then

                e.Description = My.Resources.Documents_ProformaInvoiceMade_DiscountSumInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Documents.ProformaInvoiceMade2")
        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.ProformaInvoiceMade2")
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.ProformaInvoiceMade1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.ProformaInvoiceMade3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.ProformaInvoiceMade3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new instance of ProformaInvoiceMade.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function NewProformaInvoiceMade() As ProformaInvoiceMade
            Return New ProformaInvoiceMade(False)
        End Function

        ''' <summary>
        ''' Gets a doomy instance of ProformaInvoiceMade (to be used as sample data, e.g. for invoice form preview).
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function DoomyProformaInvoiceMade() As ProformaInvoiceMade
            Return New ProformaInvoiceMade(True)
        End Function

        ''' <summary>
        ''' Gets a new ProformaInvoiceMade instance using data transfer object.
        ''' </summary>
        ''' <param name="info">A data transfer object that contains invoice data.</param>
        ''' <param name="systemGuid">An ID of the system that requests the creation of the invoice 
        ''' using the data transfer object. Used to distinguish data transfer within and outside a system (an application instance).
        ''' Use <see cref="System.Guid">Guid.ToString</see> to generate an application instance Guid.</param>
        ''' <param name="useImportedObjectExternalID">Whether to use the data transfer object ExternalID
        ''' property when setting <see cref="ExternalID">invoice ExternalID property</see>
        ''' (otherwise the ID property of the data transfer object is used).</param>
        ''' <param name="clientList">Lookup list for person data.</param>
        ''' <param name="unknownPerson">Output param. Is set to data transfer object person data,
        ''' if the person is not identified with any person in the company database.
        ''' Used for further data import (new person data).</param>
        ''' <remarks></remarks>
        Public Shared Function NewProformaInvoiceMade(ByVal info As InvoiceInfo.InvoiceInfo, _
            ByVal systemGuid As String, ByVal useImportedObjectExternalID As Boolean, _
            ByVal clientList As PersonInfoList, ByRef unknownPerson As InvoiceInfo.ClientInfo) As ProformaInvoiceMade

            Dim result As New ProformaInvoiceMade(info, systemGuid, useImportedObjectExternalID, clientList)

            If result.Payer = PersonInfo.Empty AndAlso Not info.Payer Is Nothing _
                AndAlso Not StringIsNullOrEmpty(info.Payer.Code) Then
                unknownPerson = info.Payer
            Else
                unknownPerson = Nothing
            End If

            Return result

        End Function


        ''' <summary>
        ''' Gets an existing instance of ProformaInvoiceMade from a database.
        ''' </summary>
        ''' <param name="nID">An ID of the ProformaInvoiceMade to get.</param>
        ''' <remarks></remarks>
        Public Shared Function GetProformaInvoiceMade(ByVal nID As Integer) As ProformaInvoiceMade
            Return DataPortal.Fetch(Of ProformaInvoiceMade)(New Criteria(nID))
        End Function


        Friend Shared Function GetOrCreateProformaInvoiceMadeChild(ByVal info As InvoiceInfo.InvoiceInfo, _
            ByVal useImportedObjectExternalID As Boolean, ByVal clientList As PersonInfoList, _
            ByRef unknownPerson As InvoiceInfo.ClientInfo) As ProformaInvoiceMade

            If useImportedObjectExternalID AndAlso StringIsNullOrEmpty(info.ExternalID) Then
                Throw New Exception("ExternalID is not specified.")
            ElseIf Not useImportedObjectExternalID AndAlso StringIsNullOrEmpty(info.ID) Then
                Throw New Exception("ID is not specified.")
            End If

            Dim myComm As New SQLCommand("FetchProformaInvoiceMadeIDByExternalID")
            If useImportedObjectExternalID Then
                myComm.AddParam("?MN", info.ExternalID.Trim)
            Else
                myComm.AddParam("?MN", info.ID.Trim)
            End If

            Dim result As New ProformaInvoiceMade
            result.MarkAsChild()

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then
                    result.DoFetch(CIntSafe(myData.Rows(0).Item(0), 0))
                End If

            End Using

            result.Create(info, "123456", useImportedObjectExternalID, clientList)

            If result.Payer = PersonInfo.Empty AndAlso Not info.Payer Is Nothing Then
                unknownPerson = info.Payer
            Else
                unknownPerson = Nothing
            End If

            Return result

        End Function


        ''' <summary>
        ''' Deletes an existing instance of ProformaInvoiceMade from a database.
        ''' </summary>
        ''' <param name="id">An ID of the ProformaInvoiceMade to delete.</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteProformaInvoiceMade(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
        End Sub


        Public Function GetProformaInvoiceMadeCopy() As ProformaInvoiceMade

            Dim result As ProformaInvoiceMade = Me.Clone
            result._ID = -1
            result._Number = 0
            result._Date = Today
            result._FullNumber = ""
            result._InvoiceItems.MarkAsCopy()

            result.MarkNew()

            result.ValidationRules.CheckRules()

            Return result

        End Function


        ''' <summary>
        ''' Gets an existing ProformaInvoiceMade instance from a database bypassing DataPortal.
        ''' </summary>
        ''' <param name="id">an ID of the invoice to get</param>
        ''' <remarks>Should only be used on server side.
        ''' Required by the <see cref="BusinessObjectCollection(of T)">BusinessObjectCollection</see>
        ''' in order to fetch multiple invoices by a single request.</remarks>
        Friend Shared Function GetProformaInvoiceMadeChild(ByVal id As Integer) As ProformaInvoiceMade
            Return New ProformaInvoiceMade(id)
        End Function


        Private Sub New()
            ' require use of factory methods

        End Sub

        Private Sub New(ByVal doomyInstance As Boolean)
            Create(doomyInstance)
        End Sub

        Private Sub New(ByVal info As InvoiceInfo.InvoiceInfo, ByVal systemGuid As String, _
            ByVal useImportedObjectExternalID As Boolean, ByVal clientList As PersonInfoList)
            Create(info, systemGuid, useImportedObjectExternalID, clientList)
        End Sub

        Private Sub New(ByVal nID As Integer)
            MarkAsChild()
            DoFetch(nID)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Private _DefaultVatRate As Double
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public ReadOnly Property DefaultVatRate() As Double
                Get
                    Return _DefaultVatRate
                End Get
            End Property
            Public Sub New(ByVal nID As Integer, ByVal nDefaultVatRate As Double)
                _ID = nID
                _DefaultVatRate = nDefaultVatRate
            End Sub
            Public Sub New(ByVal nID As Integer)
                _ID = nID
                _DefaultVatRate = 0
            End Sub
        End Class


        Private Sub Create(ByVal doomyInstance As Boolean)

            If doomyInstance Then
                InitializeDoomyInstance()
            Else
                InitializeNewInstance()
            End If

        End Sub

        Private Sub InitializeNewInstance()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Dim cc As ApskaitaObjects.Settings.CompanyInfo = GetCurrentCompany()

            _AddDateToNumberOptionWasUsed = cc.AddDateToInvoiceNumber
            _NumbersInInvoice = cc.NumbersInInvoice
            _Content = cc.DefaultInvoiceMadeContent

            _InvoiceItems = ProformaInvoiceMadeItemList.NewProformaInvoiceMadeItemList(Me)

            ValidationRules.CheckRules()

        End Sub

        Private Sub InitializeDoomyInstance()

            Dim r As New Random

            _IsDoomyInvoice = True

            Dim cc As ApskaitaObjects.Settings.CompanyInfo = GetCurrentCompany()

            _AddDateToNumberOptionWasUsed = cc.AddDateToInvoiceNumber
            _NumbersInInvoice = cc.NumbersInInvoice

            _CommentsInternal = My.Resources.Documents_ProformaInvoiceMade_DoomyCommentsInternal
            _Content = My.Resources.Documents_ProformaInvoiceMade_DoomyContent
            _CurrencyCode = My.Resources.Documents_ProformaInvoiceMade_DoomyInvoiceCurrency
            _CustomInfo = My.Resources.Documents_ProformaInvoiceMade_DoomyCustomInfo
            _CustomInfoAltLng = My.Resources.Documents_ProformaInvoiceMade_DoomyCustomInfoAltLng
            _Date = Today
            _LanguageCode = My.Resources.Documents_ProformaInvoiceMade_DoomyInvoiceLanguage
            _Number = 123
            _Payer = PersonInfo.DoomyPersonInfo
            _Serial = My.Resources.Documents_ProformaInvoiceMade_DoomySerial

            UpdateFullNumber(False)

            _InvoiceItems = ProformaInvoiceMadeItemList.DoomyProformaInvoiceMadeItemList(r, Me)

            CalculateSubTotals(False)

        End Sub

        Private Sub Create(ByVal info As InvoiceInfo.InvoiceInfo, _
            ByVal systemGuid As String, ByVal useImportedObjectExternalID As Boolean, _
            ByVal clientList As PersonInfoList)

            ' data transfer within the same system (an application instance)
            If info.SystemGuid.Trim = systemGuid.Trim Then

                _Number = 0
                _ExternalID = ""

            Else

                _Number = info.Number

                If useImportedObjectExternalID Then
                    Me._ExternalID = info.ExternalID
                Else
                    Me._ExternalID = info.ID
                End If

            End If

            Me._AddDateToNumberOptionWasUsed = info.AddDateToNumberOptionWasUsed
            Me._CommentsInternal = info.CommentsInternal
            Me._Content = info.Content
            If Not StringIsNullOrEmpty(info.ProjectCode.Trim) Then _
                _Content = _Content & " (projektas - " & info.ProjectCode.Trim & ")"
            Me._CurrencyCode = info.CurrencyCode
            Me._CustomInfo = info.CustomInfo
            Me._CustomInfoAltLng = info.CustomInfoAltLng
            Me._Date = info.Date
            Me._LanguageCode = info.LanguageCode
            Me._Number = info.Number
            Me._NumbersInInvoice = info.NumbersInInvoice
            Me._Serial = info.Serial
            Me._UpdateDate = info.UpdateDate

            UpdateFullNumber(False)

            If Not info.Payer Is Nothing AndAlso Not StringIsNullOrEmpty(info.Payer.Code) Then
                Me._Payer = clientList.GetPersonInfo(info.Payer.Code)
            End If

            If IsNew Then
                _InvoiceItems = ProformaInvoiceMadeItemList.NewProformaInvoiceMadeItemList(info)
            Else
                _InvoiceItems.AddWithNewItems(info, Me)
            End If

            CalculateSubTotals(False)

            ValidationRules.CheckRules()

        End Sub


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            DoFetch(criteria.ID)

        End Sub

        Private Sub DoFetch(ByVal invoiceID As Integer)

            Dim myComm As New SQLCommand("FetchProformaInvoiceMade")
            myComm.AddParam("?CD", invoiceID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Common_ObjectNotFound, My.Resources.Documents_ProformaInvoiceMade_TypeName, _
                    invoiceID.ToString()))

                DoFetch(myData.Rows(0))

            End Using

        End Sub

        Private Sub DoFetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(0), 0)
            _Date = CDateSafe(dr.Item(1), Today)
            _Serial = CStrSafe(dr.Item(2)).Trim
            _Number = CIntSafe(dr.Item(3), 0)
            _FullNumber = CStrSafe(dr.Item(4)).Trim
            _AddDateToNumberOptionWasUsed = ConvertDbBoolean(CIntSafe(dr.Item(5), 0))
            _NumbersInInvoice = CIntSafe(dr.Item(6), 0)
            _Content = CStrSafe(dr.Item(7)).Trim
            _CurrencyCode = CStrSafe(dr.Item(8)).Trim
            _LanguageCode = CStrSafe(dr.Item(9)).Trim
            _CustomInfo = CStrSafe(dr.Item(10)).Trim
            _CustomInfoAltLng = CStrSafe(dr.Item(11)).Trim
            _CommentsInternal = CStrSafe(dr.Item(12)).Trim
            _ExternalID = CStrSafe(dr.Item(13)).Trim
            _InsertDate = CTimeStampSafe(dr.Item(14))
            _UpdateDate = CTimeStampSafe(dr.Item(15))
            _Payer = PersonInfo.GetPersonInfo(dr, 16)

            _InvoiceItems = ProformaInvoiceMadeItemList.GetInvoiceMadeItemList(Me)

            CalculateSubTotals(False)
            UpdateFullNumber(False)

            MarkOld()
            ValidationRules.CheckRules()

        End Sub


        Friend Sub SaveChild()
            If IsNew Then
                DoInsert()
            Else
                DoUpdate()
            End If
        End Sub

        Protected Overrides Sub DataPortal_Insert()

            If _IsDoomyInvoice Then
                Throw New InvalidOperationException(My.Resources.Documents_ProformaInvoiceMade_InvalidSaveForDoomy)
            End If

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            DoInsert()

        End Sub

        Private Sub DoInsert()

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            CheckIfExternalIdUnique()

            CheckIfNumberUnique()

            Using transaction As New SqlTransaction

                Try

                    Dim myComm As New SQLCommand("InsertProformaInvoiceMade")
                    AddParams(myComm)

                    myComm.Execute()

                    _ID = CInt(myComm.LastInsertID)

                    _InvoiceItems.Update(Me)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            DoUpdate()

        End Sub

        Private Sub DoUpdate()

            UpdateFullNumber(False)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            CheckIfExternalIdUnique()

            CheckIfNumberUnique()

            CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("UpdateProformaInvoiceMade")
            AddParams(myComm)
            myComm.AddParam("?CD", _ID)

            Using transaction As New SqlTransaction

                Try

                    myComm.Execute()

                    _InvoiceItems.Update(Me)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub

        Private Sub AddParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AA", _Date.Date)
            myComm.AddParam("?AB", _Serial.Trim)
            myComm.AddParam("?AC", _Number)
            myComm.AddParam("?AD", _FullNumber.Trim)
            myComm.AddParam("?AE", ConvertDbBoolean(_AddDateToNumberOptionWasUsed))
            myComm.AddParam("?AF", _NumbersInInvoice)
            myComm.AddParam("?AG", _Content.Trim)
            myComm.AddParam("?AH", _CurrencyCode.Trim)
            myComm.AddParam("?AI", _LanguageCode.Trim)
            myComm.AddParam("?AJ", _CustomInfo.Trim)
            myComm.AddParam("?AK", _CustomInfoAltLng.Trim)
            myComm.AddParam("?AL", _CommentsInternal.Trim)
            myComm.AddParam("?AM", _ExternalID.Trim)
            myComm.AddParam("?AN", _Payer.ID)

            _UpdateDate = GetCurrentTimeStamp()
            If Me.IsNew Then _InsertDate = _UpdateDate
            myComm.AddParam("?AO", _UpdateDate.ToUniversalTime)

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            DoDelete(DirectCast(criteria, Criteria).ID)

        End Sub

        Friend Shared Sub DeleteInvoiceByExternalID(ByVal externalIdToDelete As String)

            Dim myComm As New SQLCommand("FetchProformaInvoiceMadeIDByExternalID")
            myComm.AddParam("?MN", externalIdToDelete.Trim)

            Dim idToDelete As Integer

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then
                    If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                        My.Resources.Common_ObjectNotFound, My.Resources.Documents_ProformaInvoiceMade_TypeName, _
                        externalIdToDelete.ToString()))
                End If

                idToDelete = CIntSafe(myData.Rows(0).Item(0), 0)

            End Using

            DoDelete(idToDelete)

        End Sub

        Private Shared Sub DoDelete(ByVal id As Integer)

            Dim cInvoice As New ProformaInvoiceMade
            cInvoice.DoFetch(id)

            Dim myComm As New SQLCommand("DeleteProformaInvoiceMade")
            myComm.AddParam("?CD", id)

            Using transaction As New SqlTransaction

                Try

                    myComm.Execute()

                    myComm = New SQLCommand("DeleteProformaInvoiceMadeItems")
                    myComm.AddParam("?MD", id)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

        End Sub


        Private Sub CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("CheckIfProformaInvoiceMadeUpdateDateChanged")
            myComm.AddParam("?SD", _ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 OrElse CDateTimeSafe(myData.Rows(0).Item(0), _
                    Date.MinValue) = Date.MinValue Then

                    Throw New Exception(String.Format(My.Resources.Common_ObjectNotFound, _
                        My.Resources.Documents_ProformaInvoiceMade_TypeName, _ID.ToString))

                End If

                If CTimeStampSafe(myData.Rows(0).Item(0)) <> _UpdateDate Then

                    Throw New Exception(My.Resources.Common_UpdateDateHasChanged)

                End If

            End Using

        End Sub

        Private Sub CheckIfExternalIdUnique()

            If StringIsNullOrEmpty(_ExternalID) Then Exit Sub

            Dim myComm As New SQLCommand("FetchProformaInvoiceMadeIDByExternalID")
            myComm.AddParam("?MN", _ExternalID.Trim)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 _
                    AndAlso CIntSafe(myData.Rows(0).Item(0), 0) <> _ID Then _
                    Throw New Exception(String.Format(My.Resources.Documents_ProformaInvoiceMade_ExternalIdNotUnique, _
                        _ExternalID.Trim))
            End Using

        End Sub

        Private Sub CheckIfNumberUnique()

            Dim myComm As SQLCommand
            If _AddDateToNumberOptionWasUsed Then
                myComm = New SQLCommand("CheckIfProformaInvoiceNumberUniqueWithDate")
                myComm.AddParam("?ND", _Date)
            Else
                myComm = New SQLCommand("CheckIfProformaInvoiceNumberUnique")
            End If
            myComm.AddParam("?SR", _Serial.Trim.ToUpper)
            myComm.AddParam("?NM", _Number)
            myComm.AddParam("?IN", _ID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 Then Throw New Exception( _
                    My.Resources.Documents_ProformaInvoiceMade_SerialNumberNotUnique)
            End Using

        End Sub

#End Region

    End Class

End Namespace