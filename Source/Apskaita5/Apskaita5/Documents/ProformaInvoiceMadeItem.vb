﻿Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.Attributes
Imports Csla.Validation
Imports ApskaitaObjects.My.Resources
Imports ApskaitaObjects.General

Namespace Documents

    ''' <summary>
    ''' Represents a line (item) within a <see cref="ProformaInvoiceMade">proforma invoice made</see>.
    ''' </summary>
    ''' <remarks>Should only be used as a child of a <see cref="ProformaInvoiceMadeItemList">ProformaInvoiceMadeItemList</see>.
    ''' Values are stored in the database table ProformaInvoiceMadeItems.</remarks>
    <Serializable()> _
    Public NotInheritable Class ProformaInvoiceMadeItem
        Inherits BusinessBase(Of ProformaInvoiceMadeItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = -1
        Private _NameInvoice As String = ""
        Private _NameInvoiceAltLng As String = ""
        Private _MeasureUnit As String = ""
        Private _MeasureUnitAltLng As String = ""
        Private _Ammount As Double = 0
        Private _UnitValue As Double = 0
        Private _Sum As Double = 0
        Private _SumCorrection As Integer = 0
        Private _VatRate As Double = 0
        Private _SumVat As Double = 0
        Private _SumVatCorrection As Integer = 0
        Private _SumTotal As Double = 0
        Private _Discount As Double = 0
        Private _DiscountVat As Double = 0
        Private _DiscountVatCorrection As Integer = 0
        Private _TradedItem As ITradedItem = Nothing
        Private _LanguageCode As String = ""


        ''' <summary>
        ''' Technical property to enable language related validation.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property LanguageCode() As String
            Get
                Return _LanguageCode
            End Get
            Friend Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _LanguageCode.Trim <> value.Trim Then
                    _LanguageCode = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets an ID of the item that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database table ProformaInvoiceMadeItems.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a content (description) of the item in the base language as printed in the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database table ProformaInvoiceMadeItems.NameInvoice.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property NameInvoice() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NameInvoice.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _NameInvoice.Trim <> value.Trim Then
                    _NameInvoice = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a content (description) of the item in the alternative language 
        ''' (<see cref="ProformaInvoiceMade.LanguageCode">original language of the invoice</see>) 
        ''' as printed in the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database table ProformaInvoiceMadeItems.NameAltLng.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property NameInvoiceAltLng() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NameInvoiceAltLng.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _NameInvoiceAltLng.Trim <> value.Trim Then
                    _NameInvoiceAltLng = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a measure unit of the item in the base language as printed in the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database table ProformaInvoiceMadeItems.MeasureUnit.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 50)> _
        Public Property MeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MeasureUnit.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _MeasureUnit.Trim <> value.Trim Then
                    _MeasureUnit = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a measure unit of the item in the alternative language 
        ''' (<see cref="ProformaInvoiceMade.LanguageCode">original language of the invoice</see>) 
        ''' as printed in the invoice.
        ''' </summary>
        ''' <remarks>Value is stored in the database table ProformaInvoiceMadeItems.MeasureUnitAltLng.</remarks>
        <StringField(ValueRequiredLevel.Optional, 50)> _
        Public Property MeasureUnitAltLng() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MeasureUnitAltLng.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _MeasureUnitAltLng.Trim <> value.Trim Then
                    _MeasureUnitAltLng = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the amount of the goods/services sold.
        ''' </summary>
        ''' <remarks>Value round order is <see cref="ROUNDAMOUNTINVOICEMADE">ROUNDAMOUNTINVOICEMADE</see>.
        ''' Value is stored in the database table ProformaInvoiceMadeItems.Amount.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDAMOUNTINVOICEMADE)> _
        Public Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Ammount, ROUNDAMOUNTINVOICEMADE)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Ammount, ROUNDAMOUNTINVOICEMADE) <> CRound(value, ROUNDAMOUNTINVOICEMADE) Then
                    _Ammount = CRound(value, ROUNDAMOUNTINVOICEMADE)
                    CalculateSum()
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the value of the goods/services sold per unit 
        ''' in <see cref="ProformaInvoiceMade.CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Value round order is <see cref="ROUNDUNITINVOICEMADE">ROUNDUNITINVOICEMADE</see>.
        ''' Value is stored in the database table ProformaInvoiceMadeItems.UnitValue.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDUNITINVOICEMADE)> _
        Public Property UnitValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitValue, ROUNDUNITINVOICEMADE)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_UnitValue, ROUNDUNITINVOICEMADE) <> CRound(value, ROUNDUNITINVOICEMADE) Then
                    _UnitValue = CRound(value, ROUNDUNITINVOICEMADE)
                    CalculateSum()
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total value of the goods/services sold (excluding VAT)
        ''' in <see cref="InvoiceMade.CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Equals <see cref="Amount">Ammount</see> multiplied by 
        ''' <see cref="UnitValue">UnitValue</see>
        ''' plus <see cref="SumCorrection">SumCorrection</see> divided by 100.
        ''' Value is stored in the database table ProformaInvoiceMadeItems.SumOriginal.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a correction of <see cref="Sum">Sum</see> in cents (1/100 of the currency unit).
        ''' </summary>
        ''' <remarks>Value is calculated (not persisted) as the difference between 
        ''' <see cref="Amount">Amount</see> multiplied by  <see cref="UnitValue">UnitValue</see>
        ''' and <see cref="Sum">Sum</see>.</remarks>
        <CorrectionField()> _
        Public Property SumCorrection() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SumCorrection
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _SumCorrection <> value Then
                    _SumCorrection = value
                    CalculateSum()
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the applicable VAT rate in percents for the goods/services sold (21 = 21%).
        ''' </summary>
        ''' <remarks>Value is stored in the database table ProformaInvoiceMadeItems.VatRate.</remarks>
        <TaxRateField(ValueRequiredLevel.Optional, ApskaitaObjects.Settings.TaxRateType.Vat)> _
        Public Property VatRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_VatRate)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_VatRate) <> CRound(value) Then
                    _VatRate = CRound(value)
                    CalculateDiscountVat()
                    CalculateSumVat()
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the VAT value in <see cref="ProformaInvoiceMade.CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Equals <see cref="Sum">Sum</see> multiplied by 
        ''' <see cref="VatRate">VatRate</see> and divided by 100
        ''' plus <see cref="SumVatCorrection">SumVatCorrection</see> divided by 100.
        ''' Value is stored in the database table ProformaInvoiceMadeItems.SumVat.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property SumVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumVat)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a correction of <see cref="SumVat">SumVat</see> in cents (1/100 of the currency unit).
        ''' </summary>
        ''' <remarks>Value is calculated (not persisted) as the difference between 
        ''' <see cref="Sum">Sum</see> multiplied by <see cref="VatRate">VatRate</see>, divided by 100
        ''' and <see cref="SumVat">SumVat</see>.</remarks>
        <CorrectionField()> _
        Public Property SumVatCorrection() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SumVatCorrection
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _SumVatCorrection <> value Then
                    _SumVatCorrection = value
                    CalculateSumVat()
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total value of the goods/services sold (including VAT)
        ''' in <see cref="InvoiceMade.CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Equals <see cref="Sum">Sum</see> plus <see cref="SumVat">SumVat</see>.
        ''' Value is not stored in the database.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property SumTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumTotal)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a discount value in <see cref="ProformaInvoiceMade.CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database table ProformaInvoiceMadeItems.Discount.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property Discount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Discount)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Discount) <> CRound(value) Then
                    _Discount = CRound(value)
                    CalculateDiscountVat()
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the discount VAT value in <see cref="ProformaInvoiceMade.CurrencyCode">the original invoice currency</see>.
        ''' </summary>
        ''' <remarks>Equals <see cref="Discount">Discount</see> multiplied by 
        ''' <see cref="VatRate">VatRate</see> and divided by 100
        ''' plus <see cref="DiscountVatCorrection">DiscountVatCorrection</see> divided by 100.
        ''' Value is stored in the database table ProformaInvoiceMadeItems.DiscountVat.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property DiscountVat() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DiscountVat)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a correction of <see cref="DiscountVat">DiscountVat</see> in cents (1/100 of the currency unit).
        ''' </summary>
        ''' <remarks>Value is calculated (not persisted) as the difference between 
        ''' <see cref="Discount">Discount</see> multiplied by <see cref="VatRate">VatRate</see>, divided by 100
        ''' and <see cref="DiscountVat">DiscountVat</see>.</remarks>
        <CorrectionField()> _
        Public Property DiscountVatCorrection() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DiscountVatCorrection
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _DiscountVatCorrection <> value Then
                    _DiscountVatCorrection = value
                    CalculateDiscountVat()
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' An item that is intended to be sold (goods, services, etc.).
        ''' </summary>
        ''' <remarks>Traded item type value is stored in the database table ProformaInvoiceMadeItems.TradedItemType,
        ''' Traded item ID value is stored in the database table ProformaInvoiceMadeItems.TradedItemID.</remarks>
        Public ReadOnly Property TradedItem() As ITradedItem
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TradedItem
            End Get
        End Property

        ''' <summary>
        ''' A name (description) of the item that is intended to be sold (goods, services, etc.).
        ''' </summary>
        ''' <remarks>Traded item type value is stored in the database table ProformaInvoiceMadeItems.TradedItemType,
        ''' Traded item ID value is stored in the database table ProformaInvoiceMadeItems.TradedItemID.</remarks>
        Public ReadOnly Property TradedItemContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _TradedItem Is Nothing Then
                    Return ""
                Else
                    If TypeOf _TradedItem Is ServiceInfo Then
                        Return String.Format(Documents_ProformaInvoiceMadeItem_TradedItemContent_Services, _TradedItem.ToString())
                    ElseIf TypeOf _TradedItem Is GoodsInfo Then
                        Return String.Format(Documents_ProformaInvoiceMadeItem_TradedItemContent_Goods, _TradedItem.ToString())
                    Else
                        Return String.Format(Documents_ProformaInvoiceMadeItem_TradedItemContent_Undefined, _TradedItem.ToString())
                    End If
                End If
            End Get
        End Property


        Private Sub CalculateSum()
            _Sum = CRound(CRound(_UnitValue * _Ammount) + _SumCorrection / 100)
            PropertyHasChanged("Sum")
            CalculateSumVat()
        End Sub

        Private Sub CalculateSumVat()
            _SumVat = CRound(CRound(_Sum * _VatRate / 100) + _SumVatCorrection / 100)
            _SumTotal = CRound(_Sum + _SumVat)
            PropertyHasChanged("SumVat")
            PropertyHasChanged("SumTotal")
        End Sub

        Private Sub CalculateDiscountVat()
            _DiscountVat = CRound(CRound(_VatRate * _Discount / 100) _
                + _DiscountVatCorrection / 100)
            PropertyHasChanged("DiscountVat")
        End Sub


        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString

            If IsValid Then Return ""

            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, vbCrLf, _
                Me.BrokenRulesCollection.ToString(RuleSeverity.Error))

        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString

            If Not HasWarnings() Then Return ""

            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, vbCrLf, _
                Me.BrokenRulesCollection.ToString(RuleSeverity.Warning))

        End Function

        Public Function HasWarnings() As Boolean
            Return BrokenRulesCollection.WarningCount > 0
        End Function


        Friend Sub MarkAsCopy()

            _ID = -1
            _Guid = Guid.NewGuid

            MarkNew()

        End Sub

        ''' <summary>
        ''' Gets item data as a data transfer object.
        ''' </summary>
        ''' <remarks>Used to implement data exchange with other applications.</remarks>
        Friend Function GetInvoiceItemInfo() As InvoiceInfo.InvoiceItemInfo

            Dim result As New InvoiceInfo.InvoiceItemInfo

            result.Ammount = Me._Ammount
            result.Comments = ""
            result.Discount = Me._Discount
            result.DiscountVat = Me._DiscountVat
            result.ID = Me._ID.ToString
            result.MeasureUnit = Me._MeasureUnit
            result.MeasureUnitAltLng = Me._MeasureUnitAltLng
            result.NameInvoice = Me._NameInvoice
            result.NameInvoiceAltLng = Me._NameInvoiceAltLng
            result.ProjectCode = ""
            result.Sum = Me._Sum
            result.SumReceived = 0
            result.SumTotal = Me._SumTotal
            result.SumVat = Me._SumVat
            result.UnitValue = Me._UnitValue
            result.VatRate = Me._VatRate

            Return result

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Documents_ProformaInvoiceMadeItem_ToString, _
                _NameInvoice, DblParser(_Ammount, ROUNDAMOUNTINVOICEMADE), _MeasureUnit, _
                DblParser(_UnitValue, ROUNDUNITINVOICEMADE))
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("NameInvoice"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("MeasureUnit"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Validation.RuleArgs("UnitValue"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Validation.RuleArgs("Amount"))
            ValidationRules.AddRule(AddressOf CommonValidation.IntegerFieldValidation, _
                New Validation.RuleArgs("SumCorrection"))

            ValidationRules.AddRule(AddressOf CommonValidation.AltLanguageValidation, _
                New CommonValidation.ReferencePropertyRuleArgs("NameInvoiceAltLng", _
                "LanguageCode"))
            ValidationRules.AddRule(AddressOf CommonValidation.AltLanguageValidation, _
                New CommonValidation.ReferencePropertyRuleArgs("MeasureUnitAltLng", _
                "LanguageCode"))

            ValidationRules.AddRule(AddressOf DiscountValidation, "Discount")
            ValidationRules.AddRule(AddressOf DiscountVatValidation, "DiscountVat")
            ValidationRules.AddRule(AddressOf SumVatCorrectionValidation, "SumVatCorrection")
            ValidationRules.AddRule(AddressOf DiscountVatCorrectionValidation, "DiscountVatCorrection")

            ValidationRules.AddDependantProperty("LanguageCode", "NameInvoiceAltLng", False)
            ValidationRules.AddDependantProperty("LanguageCode", "MeasureUnitAltLng", False)

            ValidationRules.AddDependantProperty("Sum", "Discount", False)
            ValidationRules.AddDependantProperty("SumVat", "DiscountVat", False)
            ValidationRules.AddDependantProperty("VatRate", "SumVatCorrection", False)
            ValidationRules.AddDependantProperty("VatRate", "DiscountVatCorrection", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that Discount is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DiscountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As ProformaInvoiceMadeItem = DirectCast(target, ProformaInvoiceMadeItem)

            Return DiscountValidationInt(valObj._Discount, valObj._Sum, _
                 My.Resources.Documents_ProformaInvoiceMadeItem_Discount, _
                 My.Resources.Documents_ProformaInvoiceMadeItem_Sum, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that DiscountVat is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DiscountVatValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As ProformaInvoiceMadeItem = DirectCast(target, ProformaInvoiceMadeItem)

            Return DiscountValidationInt(valObj._DiscountVat, valObj._SumVat, _
                 My.Resources.Documents_ProformaInvoiceMadeItem_DiscountVat, _
                 My.Resources.Documents_ProformaInvoiceMadeItem_SumVat, e)

        End Function

        Private Shared Function DiscountValidationInt(ByVal discountValue As Double, _
            ByVal propertyValue As Double, ByVal discountName As String, _
            ByVal propertyName As String, ByVal e As Validation.RuleArgs) As Boolean

            If CRound(discountValue) < 0 Then

                e.Description = My.Resources.Documents_ProformaInvoiceMadeItem_DiscountNegative
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf CRound(discountValue) > CRound(propertyValue) Then

                e.Description = String.Format(My.Resources.Documents_ProformaInvoiceMadeItem_ValueExceedsLimits, _
                    discountName, propertyName)
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that SumVatCorrection is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumVatCorrectionValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As ProformaInvoiceMadeItem = DirectCast(target, ProformaInvoiceMadeItem)

            If Not CRound(valObj._VatRate, 2) > 0 AndAlso valObj._SumVatCorrection <> 0 Then

                e.Description = My.Resources.Documents_ProformaInvoiceMadeItem_SumVatCorrectionInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return CommonValidation.IntegerFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that DiscountVatCorrection is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DiscountVatCorrectionValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As ProformaInvoiceMadeItem = DirectCast(target, ProformaInvoiceMadeItem)

            If Not CRound(valObj._VatRate, 2) > 0 AndAlso _
                valObj._SumVatCorrection <> 0 Then

                e.Description = My.Resources.Documents_ProformaInvoiceMadeItem_SumVatCorrectionInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return CommonValidation.IntegerFieldValidation(target, e)

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewProformaInvoiceMadeItem(ByVal parentLanguageCode As String) As ProformaInvoiceMadeItem
            Return New ProformaInvoiceMadeItem(parentLanguageCode)
        End Function

        Friend Shared Function NewProformaInvoiceMadeItem(ByVal parentLanguageCode As String, _
            ByVal parentCurrencyCode As String, ByVal newTradedItem As ITradedItem, _
            ByVal regionalizedDictionary As RegionalInfoDictionary) As ProformaInvoiceMadeItem
            Return New ProformaInvoiceMadeItem(parentLanguageCode, parentCurrencyCode, newTradedItem, regionalizedDictionary)
        End Function

        Friend Shared Function NewProformaInvoiceMadeItem(ByVal parentLanguageCode As String, _
            ByVal info As InvoiceInfo.InvoiceItemInfo) As ProformaInvoiceMadeItem
            Return New ProformaInvoiceMadeItem(parentLanguageCode, info)
        End Function

        Friend Shared Function DoomyProformaInvoiceMadeItem(ByVal randomGenerator As Random) As ProformaInvoiceMadeItem
            Return New ProformaInvoiceMadeItem(randomGenerator)
        End Function

        Friend Shared Function GetProformaInvoiceMadeItem(ByVal parentLanguageCode As String, _
            ByVal dr As DataRow) As ProformaInvoiceMadeItem
            Return New ProformaInvoiceMadeItem(parentLanguageCode, dr)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal parentLanguageCode As String)
            ' require use of factory methods
            MarkAsChild()
            Create(parentLanguageCode)
        End Sub

        Private Sub New(ByVal parentLanguageCode As String, ByVal parentCurrencyCode As String, ByVal newTradedItem As ITradedItem, _
            ByVal regionalizedDictionary As RegionalInfoDictionary)
            ' require use of factory methods
            MarkAsChild()
            Create(parentLanguageCode, parentCurrencyCode, newTradedItem, regionalizedDictionary)
        End Sub

        Private Sub New(ByVal randomGenerator As Random)
            ' require use of factory methods
            MarkAsChild()
            Create(randomGenerator)
        End Sub

        Private Sub New(ByVal parentLanguageCode As String, ByVal info As InvoiceInfo.InvoiceItemInfo)
            MarkAsChild()
            Create(parentLanguageCode, info)
        End Sub

        Private Sub New(ByVal parentLanguageCode As String, ByVal dr As DataRow)
            MarkAsChild()
            Fetch(parentLanguageCode, dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal parentLanguageCode As String)

            _MeasureUnit = GetCurrentCompany.MeasureUnitInvoiceMade

            If GetCurrentCompany.UseVatDeclarationSchemas AndAlso GetCurrentCompany.DeclarationSchemaSales _
                <> VatDeclarationSchemaInfo.Empty Then
                _VatRate = GetCurrentCompany.DeclarationSchemaSales.VatRate
            Else
                _VatRate = GetCurrentCompany.GetDefaultRate(DefaultRateType.Vat)
            End If

            _LanguageCode = parentLanguageCode

            ValidationRules.CheckRules()

        End Sub

        Private Sub Create(ByVal parentLanguageCode As String, ByVal parentCurrencyCode As String, _
            ByVal newTradedItem As ITradedItem, ByVal regionalizedDictionary As RegionalInfoDictionary)

            If regionalizedDictionary Is Nothing OrElse newTradedItem Is Nothing Then
                Create(parentLanguageCode)
                Exit Sub
            End If

            If TypeOf newTradedItem Is ServiceInfo Then
                _VatRate = DirectCast(newTradedItem, ServiceInfo).RateVatSales
            ElseIf TypeOf newTradedItem Is GoodsInfo Then
                _VatRate = DirectCast(newTradedItem, GoodsInfo).DefaultVatRateSales
            Else
                If GetCurrentCompany.UseVatDeclarationSchemas AndAlso GetCurrentCompany.DeclarationSchemaSales _
                    <> VatDeclarationSchemaInfo.Empty Then
                    _VatRate = GetCurrentCompany.DeclarationSchemaSales.VatRate
                Else
                    _VatRate = GetCurrentCompany.GetDefaultRate(DefaultRateType.Vat)
                End If
            End If

            _TradedItem = newTradedItem
            _LanguageCode = parentLanguageCode

            Dim asRegionalizable As IRegionalDataObject = Nothing
            Try
                asRegionalizable = DirectCast(newTradedItem, IRegionalDataObject)
            Catch ex As Exception
                Exit Sub
            End Try
            If asRegionalizable Is Nothing Then
                Create(parentLanguageCode)
                Exit Sub
            End If

            Dim result As RegionalContentEntry = regionalizedDictionary.ContentDictionary.GetRegionalContentEntry( _
                asRegionalizable.RegionalObjectType, asRegionalizable.RegionalObjectID, parentLanguageCode)

            If LanguagesEquals(result.LanguageCode, LanguageCodeLith, LanguageCodeLith) Then

                _MeasureUnit = result.MeasureUnit
                _NameInvoice = result.ContentInvoice

                PropertyHasChanged("MeasureUnit")
                PropertyHasChanged("NameInvoice")

            Else

                _MeasureUnitAltLng = result.MeasureUnit
                _NameInvoiceAltLng = result.ContentInvoice

                PropertyHasChanged("MeasureUnitAltLng")
                PropertyHasChanged("NameInvoiceAltLng")

                result = regionalizedDictionary.ContentDictionary.GetRegionalContentEntry( _
                    asRegionalizable.RegionalObjectType, asRegionalizable.RegionalObjectID, _
                    LanguageCodeLith)

                _MeasureUnit = result.MeasureUnit
                _NameInvoice = result.ContentInvoice

            End If

            regionalizedDictionary.GetSalePrice(asRegionalizable.RegionalObjectType, _
                asRegionalizable.RegionalObjectID, parentCurrencyCode, _UnitValue)

            ValidationRules.CheckRules()

        End Sub

        Private Sub Create(ByVal randomGenerator As Random)

            ' create doomy item with random data
            _Ammount = CRound(randomGenerator.Next(1, 1000000) / 10000, ROUNDAMOUNTINVOICEMADE)
            _NameInvoice = String.Format(My.Resources.Documents_ProformaInvoiceMadeItem_DoomyNameInvoice, randomGenerator.Next(1, 1000).ToString)
            _NameInvoiceAltLng = String.Format(My.Resources.Documents_ProformaInvoiceMadeItem_DoomyNameInvoiceAltLng, randomGenerator.Next(1, 1000).ToString)
            _UnitValue = CRound(randomGenerator.Next(1, 1000000) / 10000, ROUNDUNITINVOICEMADE)
            _VatRate = Convert.ToDouble(IIf(randomGenerator.Next(1, 31) > 20, 0, 21))
            _MeasureUnit = My.Resources.Documents_ProformaInvoiceMadeItem_DoomyMeasureUnit
            _MeasureUnitAltLng = My.Resources.Documents_ProformaInvoiceMadeItem_DoomyMeasureUnitAltLng
            _LanguageCode = My.Resources.Documents_ProformaInvoiceMade_DoomyInvoiceLanguage

            CalculateSum()

            _Discount = Convert.ToDouble(IIf(randomGenerator.Next(1, 31) > 20, _
                CRound(_Sum * randomGenerator.Next(3, 20) / 100), 0))

            CalculateDiscountVat()

        End Sub

        Private Sub Create(ByVal parentLanguageCode As String, ByVal info As InvoiceInfo.InvoiceItemInfo)

            Me._Ammount = info.Ammount
            Me._Discount = info.Discount
            Me._DiscountVat = info.DiscountVat
            Me._MeasureUnit = info.MeasureUnit
            Me._MeasureUnitAltLng = info.MeasureUnitAltLng
            Me._NameInvoice = info.NameInvoice
            Me._NameInvoiceAltLng = info.NameInvoiceAltLng
            Me._Sum = info.Sum
            Me._SumTotal = info.SumTotal
            Me._SumVat = info.SumVat
            Me._UnitValue = info.UnitValue
            Me._VatRate = info.VatRate
            _LanguageCode = parentLanguageCode

            CalculateCorrections()

            ValidationRules.CheckRules()

        End Sub


        Private Sub Fetch(ByVal parentLanguageCode As String, ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(0), 0)
            _NameInvoice = CStrSafe(dr.Item(1)).Trim
            _NameInvoiceAltLng = CStrSafe(dr.Item(2)).Trim
            _MeasureUnit = CStrSafe(dr.Item(3)).Trim
            _MeasureUnitAltLng = CStrSafe(dr.Item(4)).Trim
            _Ammount = CDblSafe(dr.Item(5), ROUNDAMOUNTINVOICEMADE, 0)
            _UnitValue = CDblSafe(dr.Item(6), ROUNDUNITINVOICEMADE, 0)
            _Sum = CDblSafe(dr.Item(7), 2, 0)
            _VatRate = CDblSafe(dr.Item(8), 2, 0)
            _SumVat = CDblSafe(dr.Item(9), 2, 0)
            _Discount = CDblSafe(dr.Item(10), 2, 0)
            _DiscountVat = CDblSafe(dr.Item(11), 2, 0)

            Select Case CIntSafe(dr.Item(12), 0)
                Case 0
                    ' do nothing
                    _TradedItem = Nothing
                Case 1
                    _TradedItem = ServiceInfo.GetServiceInfo(CIntSafe(dr.Item(13), 0))
                Case 2
                    _TradedItem = GoodsInfo.GetGoodsInfo(CIntSafe(dr.Item(13), 0))
                Case Else
                    Throw New NotImplementedException(String.Format( _
                        Documents_ProformaInvoiceMadeItem_TradedItemTypeCodeNotImplemented, CIntSafe(dr.Item(13))))
            End Select

            CalculateCorrections()

            _SumTotal = CRound(_Sum + _SumVat)
            _LanguageCode = parentLanguageCode

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Private Sub CalculateCorrections()

            ' _Sum = CRound(CRound(_UnitValue * _Ammount) + _SumCorrection / 100)
            _SumCorrection = Convert.ToInt32(Math.Floor(CRound(_Sum - CRound(_UnitValue * _Ammount)) * 100))
            ' _SumVat = CRound(CRound(_Sum * _VatRate / 100) + _SumVatCorrection / 100)
            _SumVatCorrection = Convert.ToInt32(Math.Floor(CRound(_SumVat - CRound(_Sum * _VatRate / 100)) * 100))
            '_DiscountVat = CRound(CRound(_VatRate * _Discount / 100) _
            '    + _DiscountVatCorrection / 100)
            _DiscountVatCorrection = Convert.ToInt32(Math.Floor(CRound(_DiscountVat _
                - CRound(_VatRate * _Discount / 100)) * 100))

        End Sub


        Friend Sub Insert(ByVal parentInvoice As ProformaInvoiceMade)

            Dim myComm As New SQLCommand("InsertProformaInvoiceMadeItem")
            myComm.AddParam("?AN", parentInvoice.ID)
            AddWithParamsGeneral(myComm)

            If _TradedItem Is Nothing Then
                myComm.AddParam("?AL", 0)
                myComm.AddParam("?AM", 0)
            Else
                myComm.AddParam("?AM", _TradedItem.ID)
                If TypeOf _TradedItem Is ServiceInfo Then
                    myComm.AddParam("?AL", 1)
                ElseIf TypeOf _TradedItem Is GoodsInfo Then
                    myComm.AddParam("?AL", 2)
                Else
                    Throw New NotImplementedException(String.Format(Documents_ProformaInvoiceMadeItem_TradedItemTypeNotImplemented, _
                        _TradedItem.GetType.FullName))
                End If
            End If

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parentInvoice As ProformaInvoiceMade)

            Dim myComm As SQLCommand = New SQLCommand("UpdateProformaInvoiceMadeItem")
            myComm.AddParam("?CD", _ID)
            AddWithParamsGeneral(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Private Sub AddWithParamsGeneral(ByRef myComm As SQLCommand)

            myComm.AddParam("?AA", _NameInvoice.Trim)
            myComm.AddParam("?AB", _NameInvoiceAltLng.Trim)
            myComm.AddParam("?AC", _MeasureUnit.Trim)
            myComm.AddParam("?AD", _MeasureUnitAltLng.Trim)
            myComm.AddParam("?AE", CRound(_Ammount, ROUNDAMOUNTINVOICEMADE))
            myComm.AddParam("?AF", CRound(_UnitValue, ROUNDUNITINVOICEMADE))
            myComm.AddParam("?AG", CRound(_Sum))
            myComm.AddParam("?AH", CRound(_VatRate))
            myComm.AddParam("?AI", CRound(_SumVat))
            myComm.AddParam("?AJ", CRound(_Discount))
            myComm.AddParam("?AK", CRound(_DiscountVat))

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteProformaInvoiceMadeItem")
            myComm.AddParam("?CD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub

#End Region

    End Class

End Namespace