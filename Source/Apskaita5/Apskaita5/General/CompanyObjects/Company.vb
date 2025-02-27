﻿Imports System.Security
Imports ApskaitaObjects.Attributes
Imports ApskaitaObjects.Documents

Namespace General

    ''' <summary>
    ''' Represents general current company's data.
    ''' </summary>
    ''' <remarks>Values are stored in the database table imone.</remarks>
    <Serializable()> _
    Public NotInheritable Class Company
        Inherits BusinessBase(Of Company)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Private _BaseCurrency As String = "EUR"
        Private _Code As String = ""
        Private _Name As String = ""
        Private _CodeVat As String = ""
        Private _Email As String = ""
        Private _HeadPerson As String = ""
        Private _Accountant As String = ""
        Private _Cashier As String = ""
        Private _CodeSODRA As String = ""
        Private _HeadPersonSignature As Byte() = Nothing
        Private _NumbersInInvoice As Integer = 0
        Private _AddDateToInvoiceNumber As Boolean = False
        Private _AddDateToTillIncomeOrderNumber As Boolean = False
        Private _AddDateToTillSpendingsOrderNumber As Boolean = False
        Private _DefaultInvoiceMadeContent As String = ""
        Private _DefaultInvoiceReceivedContent As String = ""
        Private _MeasureUnitInvoiceReceived As String = ""
        Private _AccountClassPrefix11 As Integer = 1
        Private _AccountClassPrefix12 As Integer = 0
        Private _AccountClassPrefix21 As Integer = 2
        Private _AccountClassPrefix22 As Integer = 0
        Private _AccountClassPrefix31 As Integer = 3
        Private _AccountClassPrefix32 As Integer = 0
        Private _AccountClassPrefix41 As Integer = 4
        Private _AccountClassPrefix42 As Integer = 0
        Private _AccountClassPrefix51 As Integer = 5
        Private _AccountClassPrefix52 As Integer = 0
        Private _AccountClassPrefix61 As Integer = 6
        Private _AccountClassPrefix62 As Integer = 0
        Private _DefaultTaxRates As CompanyRateList = Nothing
        Private _Accounts As CompanyAccountList = Nothing
        Private _DefaultTaxNpdFormula As String = "NPD-(imz(PAJ-555)*0,15)"
        Private _CompanyDatabaseName As String = ""
        Private _UseVatDeclarationSchemas As Boolean = False
        Private _DeclarationSchemaSales As VatDeclarationSchemaInfo = Nothing
        Private _DeclarationSchemaPurchase As VatDeclarationSchemaInfo = Nothing
        Private _MainEconomicActivityCode As String = ""
        Private _VatDeductionPercentage As Double = 100


        ''' <summary>
        ''' Represents a currency (code) that is used as a base for accounting.
        ''' </summary>
        ''' <remarks>Can only be set for a new company. Cannot be changed for an existing company.
        ''' Value is stored in the database field imone.BaseCurrency.</remarks>
        Public Property BaseCurrency() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BaseCurrency.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If Not IsNew Then Exit Property
                If value Is Nothing Then value = ""
                If _BaseCurrency.Trim <> value.Trim Then
                    _BaseCurrency = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Company's registration code.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.I_Kodas.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 20, False)> _
        Public Property Code() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Code.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Code.Trim <> value.Trim Then
                    _Code = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Company's official name.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.I_Pavadinimas.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255, False)> _
        Public Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Name.Trim <> value.Trim Then
                    _Name = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Company's VAT registration code.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.I_PVM_kodas.</remarks>
        <StringField(ValueRequiredLevel.Optional, 20, False)> _
        Public Property CodeVat() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeVat.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CodeVat.Trim <> value.Trim Then
                    _CodeVat = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' A main company's economic activity code (EVRK).
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.MainActivityCode.</remarks>
        <StringField(ValueRequiredLevel.Recommended, 20, False)> _
        Public Property MainEconomicActivityCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MainEconomicActivityCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _MainEconomicActivityCode.Trim <> value.Trim Then
                    _MainEconomicActivityCode = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' An email address of a company.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.I_Mail.</remarks>
        <StringField(ValueRequiredLevel.Optional, 50, False)> _
        Public Property Email() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Email.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Email.Trim <> value.Trim Then
                    _Email = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Company's head person's name, surname.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.I_Vadas.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255, False)> _
        Public Property HeadPerson() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HeadPerson.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _HeadPerson.Trim <> value.Trim Then
                    _HeadPerson = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Company's (chief) accountant's name, surname.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.Accountant.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255, False)> _
        Public Property Accountant() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Accountant.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Accountant.Trim <> value.Trim Then
                    _Accountant = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Company's cashier's name, surname.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.Cashier.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255, False)> _
        Public Property Cashier() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Cashier.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Cashier.Trim <> value.Trim Then
                    _Cashier = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Company's social security code.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.I_SD.</remarks>
        <StringField(ValueRequiredLevel.Optional, 20, False)> _
        Public Property CodeSODRA() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeSODRA.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CodeSODRA.Trim <> value.Trim Then
                    _CodeSODRA = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Facsimile of head person's signature.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.HeadPersonSignature.</remarks>
        Public Property HeadPersonSignature() As System.Drawing.Image
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ByteArrayToImage(_HeadPersonSignature)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As System.Drawing.Image)

                CanWriteProperty(True)

                If value Is Nothing AndAlso (_HeadPersonSignature Is Nothing OrElse _
                    Not _HeadPersonSignature.Length > 50) Then Exit Property

                If value Is Nothing Then
                    _HeadPersonSignature = Nothing
                    PropertyHasChanged()
                    Exit Property
                End If

                Dim valueArray As Byte() = ImageToByteArray(value)

                If _HeadPersonSignature Is Nothing OrElse valueArray Is Nothing OrElse _
                    Not _HeadPersonSignature.Equals(valueArray) Then
                    _HeadPersonSignature = valueArray
                    PropertyHasChanged()
                End If

            End Set
        End Property

        ''' <summary>
        ''' How many numeric positions are displayed for invoice number, e.g. use 5 for "00001". Use 0 for not enforcing fixed number.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.NumbersInInvoice.</remarks>
        <IntegerField(ValueRequiredLevel.Optional, False, True, 0, 10, False)> _
        Public Property NumbersInInvoice() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NumbersInInvoice
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If value > 20 Then value = 20
                If _NumbersInInvoice <> value Then
                    _NumbersInInvoice = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Wheather to display an invoice date as part of an invoice number.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>If true, overrides <see cref="NumbersInInvoice">NumbersInInvoice</see>.
        ''' Value is stored in the database field imone.AddDateToInvoiceNumber.</remarks>
        Public Property AddDateToInvoiceNumber() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AddDateToInvoiceNumber
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _AddDateToInvoiceNumber <> value Then
                    _AddDateToInvoiceNumber = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Wheather to display a TillIncomeOrder date as part of a TillIncomeOrder number.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.AddDateToTillIncomeOrderNumber.</remarks>
        Public Property AddDateToTillIncomeOrderNumber() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AddDateToTillIncomeOrderNumber
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _AddDateToTillIncomeOrderNumber <> value Then
                    _AddDateToTillIncomeOrderNumber = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Wheather to display a TillSpendingsOrder date as part of a TillSpendingsOrder number.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.AddDateToTillSpendingsOrderNumber.</remarks>
        Public Property AddDateToTillSpendingsOrderNumber() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AddDateToTillSpendingsOrderNumber
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _AddDateToTillSpendingsOrderNumber <> value Then
                    _AddDateToTillSpendingsOrderNumber = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Wheather to use <see cref="Documents.VatDeclarationSchema">VAT declaration schemas</see>
        ''' in invoices and other VAT documents.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.UseVatDeclarationSchemas.</remarks>
        Public Property UseVatDeclarationSchemas() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UseVatDeclarationSchemas
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _UseVatDeclarationSchemas <> value Then
                    _UseVatDeclarationSchemas = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a default VAT declaration schema for the goods/services sold.
        ''' </summary>
        ''' <remarks>Value is stored in the database table imone.DeclarationSchemaIDSales.</remarks>
        <VatDeclarationSchemaField(ValueRequiredLevel.Recommended, TradedItemType.Sales)> _
        Public Property DeclarationSchemaSales() As VatDeclarationSchemaInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DeclarationSchemaSales
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As VatDeclarationSchemaInfo)
                CanWriteProperty(True)
                If Not (_DeclarationSchemaSales Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _DeclarationSchemaSales Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _DeclarationSchemaSales = value) Then
                    _DeclarationSchemaSales = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a default VAT declaration schema for the goods/services bought.
        ''' </summary>
        ''' <remarks>Value is stored in the database table imone.DeclarationSchemaIDPurchase.</remarks>
        <VatDeclarationSchemaField(ValueRequiredLevel.Recommended, TradedItemType.All)> _
        Public Property DeclarationSchemaPurchase() As VatDeclarationSchemaInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DeclarationSchemaPurchase
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As VatDeclarationSchemaInfo)
                CanWriteProperty(True)
                If Not (_DeclarationSchemaPurchase Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _DeclarationSchemaPurchase Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _DeclarationSchemaPurchase = value) Then
                    _DeclarationSchemaPurchase = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' A company's VAT deduction percentage.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.VatDeductionPercentage.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2, True, 0.0, 100.0)> _
        Public Property VatDeductionPercentage() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_VatDeductionPercentage)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_VatDeductionPercentage) <> CRound(value) Then
                    _VatDeductionPercentage = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Default text that is set for a new <see cref="Documents.InvoiceMade.Content">InvoiceMade.Content</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.DefaultInvoiceMadeContent.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255, False)> _
        Public Property DefaultInvoiceMadeContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultInvoiceMadeContent.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _DefaultInvoiceMadeContent.Trim <> value.Trim Then
                    _DefaultInvoiceMadeContent = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Default text that is set for a new <see cref="Documents.InvoiceReceived.Content">InvoiceReceived.Content</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.DefaultInvoiceReceivedContent.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255, False)> _
        Public Property DefaultInvoiceReceivedContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultInvoiceReceivedContent.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _DefaultInvoiceReceivedContent.Trim <> value.Trim Then
                    _DefaultInvoiceReceivedContent = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Default text that is set for a new <see cref="Documents.InvoiceReceivedItem.MeasureUnit">InvoiceReceivedItem.MeasureUnit</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.MeasureUnitInvoiceReceived.</remarks>
        <StringField(ValueRequiredLevel.Optional, 50, False)> _
        Public Property MeasureUnitInvoiceReceived() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MeasureUnitInvoiceReceived.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _MeasureUnitInvoiceReceived.Trim <> value.Trim Then
                    _MeasureUnitInvoiceReceived = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' First number in an <see cref="Account.ID">account mumber</see> denoting 
        ''' that the account corresponds to the first class in traditional clasification (long term assets).
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.AccountClassPrefix11.</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False, True, 0, 9, True)> _
        Public Property AccountClassPrefix11() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix11
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If value > 9 Then value = 9
                If _AccountClassPrefix11 <> value Then
                    _AccountClassPrefix11 = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' First number in an <see cref="Account.ID">account mumber</see> denoting 
        ''' that the account corresponds to the first class in traditional clasification (long term assets).
        ''' </summary>
        ''' <remarks>Used if there are more than one prefix denoting the class, zero otherwise.
        ''' Value is stored in the database field imone.AccountClassPrefix12.</remarks>
        <IntegerField(ValueRequiredLevel.Optional, False, True, 0, 9, True)> _
        Public Property AccountClassPrefix12() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix12
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If value > 9 Then value = 9
                If _AccountClassPrefix12 <> value Then
                    _AccountClassPrefix12 = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' First number in an <see cref="Account.ID">account mumber</see> denoting 
        ''' that the account corresponds to the second class in traditional clasification (short term assets).
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.AccountClassPrefix21.</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False, True, 0, 9, True)> _
        Public Property AccountClassPrefix21() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix21
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If value > 9 Then value = 9
                If _AccountClassPrefix21 <> value Then
                    _AccountClassPrefix21 = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' First number in an <see cref="Account.ID">account mumber</see> denoting 
        ''' that the account corresponds to the second class in traditional clasification (short term assets).
        ''' </summary>
        ''' <remarks>Used if there are more than one prefix denoting the class, zero otherwise.
        ''' Value is stored in the database field imone.AccountClassPrefix22.</remarks>
        <IntegerField(ValueRequiredLevel.Optional, False, True, 0, 9, True)> _
        Public Property AccountClassPrefix22() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix22
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If value > 9 Then value = 9
                If _AccountClassPrefix22 <> value Then
                    _AccountClassPrefix22 = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' First number in an <see cref="Account.ID">account mumber</see> denoting 
        ''' that the account corresponds to the third class in traditional clasification (equity).
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.AccountClassPrefix31.</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False, True, 0, 9, True)> _
        Public Property AccountClassPrefix31() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix31
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If value > 9 Then value = 9
                If _AccountClassPrefix31 <> value Then
                    _AccountClassPrefix31 = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' First number in an <see cref="Account.ID">account mumber</see> denoting 
        ''' that the account corresponds to the third class in traditional clasification (equity).
        ''' </summary>
        ''' <remarks>Used if there are more than one prefix denoting the class, zero otherwise.
        ''' Value is stored in the database field imone.AccountClassPrefix32.</remarks>
        <IntegerField(ValueRequiredLevel.Optional, False, True, 0, 9, True)> _
        Public Property AccountClassPrefix32() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix32
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If value > 9 Then value = 9
                If _AccountClassPrefix32 <> value Then
                    _AccountClassPrefix32 = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' First number in an <see cref="Account.ID">account mumber</see> denoting 
        ''' that the account corresponds to the fourth class in traditional clasification (liabilities).
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.AccountClassPrefix41.</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False, True, 0, 9, True)> _
        Public Property AccountClassPrefix41() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix41
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If value > 9 Then value = 9
                If _AccountClassPrefix41 <> value Then
                    _AccountClassPrefix41 = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' First number in an <see cref="Account.ID">account mumber</see> denoting 
        ''' that the account corresponds to the fourth class in traditional clasification (liabilities).
        ''' </summary>
        ''' <remarks>Used if there are more than one prefix denoting the class, zero otherwise.
        ''' Value is stored in the database field imone.AccountClassPrefix42.</remarks>
        <IntegerField(ValueRequiredLevel.Optional, False, True, 0, 9, True)> _
        Public Property AccountClassPrefix42() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix42
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If value > 9 Then value = 9
                If _AccountClassPrefix42 <> value Then
                    _AccountClassPrefix42 = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' First number in an <see cref="Account.ID">account mumber</see> denoting 
        ''' that the account corresponds to the fifth class in traditional clasification (revenues).
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.AccountClassPrefix51.</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False, True, 0, 9, True)> _
        Public Property AccountClassPrefix51() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix51
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If value > 9 Then value = 9
                If _AccountClassPrefix51 <> value Then
                    _AccountClassPrefix51 = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' First number in an <see cref="Account.ID">account mumber</see> denoting 
        ''' that the account corresponds to the fifth class in traditional clasification (revenues).
        ''' </summary>
        ''' <remarks>Used if there are more than one prefix denoting the class, zero otherwise.
        ''' Value is stored in the database field imone.AccountClassPrefix52.</remarks>
        <IntegerField(ValueRequiredLevel.Optional, False, True, 0, 9, True)> _
        Public Property AccountClassPrefix52() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix52
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If value > 9 Then value = 9
                If _AccountClassPrefix52 <> value Then
                    _AccountClassPrefix52 = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' First number in an <see cref="Account.ID">account mumber</see> denoting 
        ''' that the account corresponds to the sixth class in traditional clasification (expenses).
        ''' </summary>
        ''' <remarks>Value is stored in the database field imone.AccountClassPrefix61.</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False, True, 0, 9, True)> _
        Public Property AccountClassPrefix61() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix61
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If value > 9 Then value = 9
                If _AccountClassPrefix61 <> value Then
                    _AccountClassPrefix61 = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' First number in an <see cref="Account.ID">account mumber</see> denoting 
        ''' that the account corresponds to the sixth class in traditional clasification (expenses).
        ''' </summary>
        ''' <remarks>Used if there are more than one prefix denoting the class, zero otherwise.
        ''' Value is stored in the database field imone.AccountClassPrefix62.</remarks>
        <IntegerField(ValueRequiredLevel.Optional, False, True, 0, 9, True)> _
        Public Property AccountClassPrefix62() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountClassPrefix62
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If value > 9 Then value = 9
                If _AccountClassPrefix62 <> value Then
                    _AccountClassPrefix62 = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' A formula used to calculate a (minimum) not-taxable personal income (NPD). 
        ''' </summary>
        ''' <remarks>See <see cref="Company.NpdFormulaValidation">NpdFormulaValidation</see> method for details.
        ''' Value is stored in the database field imone.DefaultTaxNpdFormula.</remarks>
        <StringField(ValueRequiredLevel.Recommended, 255, False)> _
        Public Property DefaultTaxNpdFormula() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultTaxNpdFormula.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _DefaultTaxNpdFormula.Trim <> value.Trim Then
                    _DefaultTaxNpdFormula = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' A list of <see cref="CompanyRateList">default rates</see> (tax, wage, etc.) by type.
        ''' </summary>
        ''' <remarks>Values are stored in the database table companyrates.</remarks>
        Public ReadOnly Property DefaultTaxRates() As CompanyRateList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultTaxRates
            End Get
        End Property

        ''' <summary>
        ''' A list of <see cref="CompanyAccountList">default accounts</see> by type.
        ''' </summary>
        ''' <remarks>Values are stored in the database table companyaccounts.</remarks>
        Public ReadOnly Property Accounts() As CompanyAccountList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Accounts
            End Get
        End Property

        ''' <summary>
        ''' A name of the database that the the company data is stored in.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CompanyDatabaseName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CompanyDatabaseName
            End Get
        End Property


        ''' <summary>
        ''' Returnes TRUE if the object is new and contains some user provided data 
        ''' OR
        ''' object is not new and was changed by the user.
        ''' </summary>
        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_Code.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Name.Trim) _
                    OrElse Not String.IsNullOrEmpty(_CodeVat.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Email.Trim) _
                    OrElse Not String.IsNullOrEmpty(_HeadPerson.Trim) _
                    OrElse Not String.IsNullOrEmpty(_CodeSODRA.Trim) _
                    OrElse Not String.IsNullOrEmpty(_DefaultInvoiceMadeContent.Trim) _
                    OrElse Not String.IsNullOrEmpty(_DefaultInvoiceReceivedContent.Trim) _
                    OrElse Not String.IsNullOrEmpty(_DefaultTaxNpdFormula.Trim))
            End Get
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _Accounts.IsDirty OrElse _DefaultTaxRates.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _Accounts.IsValid AndAlso _DefaultTaxRates.IsValid
            End Get
        End Property



        Public Overrides Function Save() As Company

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Return MyBase.Save

        End Function


        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return Me.BrokenRulesCollection.WarningCount > 0 OrElse _Accounts.HasWarnings _
                OrElse _DefaultTaxRates.HasWarnings
        End Function

        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error), False)
            If Not _DefaultTaxRates.IsValid Then result = AddWithNewLine(result, _
                _DefaultTaxRates.GetAllBrokenRules, False)
            If Not _Accounts.IsValid Then result = AddWithNewLine(result, _
                _Accounts.GetAllBrokenRules, False)
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning), False)
            If _DefaultTaxRates.HasWarnings Then result = AddWithNewLine(result, _DefaultTaxRates.GetAllWarnings, False)
            If _Accounts.HasWarnings Then result = AddWithNewLine(result, _Accounts.GetAllWarnings, False)
            Return result
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Code
        End Function

        Public Overrides Function ToString() As String
            Return String.Format("{0} ({1})", _Name, _Code)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyFieldValidation, _
                New Csla.Validation.RuleArgs("BaseCurrency"))

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Code"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Name"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("CodeVat"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Email"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("HeadPerson"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Accountant"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Cashier"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("CodeSODRA"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("DefaultInvoiceMadeContent"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("DefaultInvoiceReceivedContent"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("MeasureUnitInvoiceReceived"))
            ValidationRules.AddRule(AddressOf CommonValidation.IntegerFieldValidation, _
                New Csla.Validation.RuleArgs("NumbersInInvoice"))
            ValidationRules.AddRule(AddressOf CommonValidation.VatDeclarationSchemaFieldValidation, _
                New VatDeclarationSchemaFieldRuleArgs("DeclarationSchemaSales", ""))
            ValidationRules.AddRule(AddressOf CommonValidation.VatDeclarationSchemaFieldValidation, _
                New VatDeclarationSchemaFieldRuleArgs("DeclarationSchemaPurchase", ""))

            ValidationRules.AddRule(AddressOf AccountClassValidation, _
                New Validation.RuleArgs("AccountClassPrefix12"))
            ValidationRules.AddRule(AddressOf NpdFormulaValidation, _
                New Validation.RuleArgs("DefaultTaxNpdFormula"))

            ValidationRules.AddDependantProperty("AccountClassPrefix11", "AccountClassPrefix12", False)
            ValidationRules.AddDependantProperty("AccountClassPrefix21", "AccountClassPrefix12", False)
            ValidationRules.AddDependantProperty("AccountClassPrefix22", "AccountClassPrefix12", False)
            ValidationRules.AddDependantProperty("AccountClassPrefix31", "AccountClassPrefix12", False)
            ValidationRules.AddDependantProperty("AccountClassPrefix32", "AccountClassPrefix12", False)
            ValidationRules.AddDependantProperty("AccountClassPrefix41", "AccountClassPrefix12", False)
            ValidationRules.AddDependantProperty("AccountClassPrefix42", "AccountClassPrefix12", False)
            ValidationRules.AddDependantProperty("AccountClassPrefix51", "AccountClassPrefix12", False)
            ValidationRules.AddDependantProperty("AccountClassPrefix52", "AccountClassPrefix12", False)
            ValidationRules.AddDependantProperty("AccountClassPrefix61", "AccountClassPrefix12", False)
            ValidationRules.AddDependantProperty("AccountClassPrefix62", "AccountClassPrefix12", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property AccountClassPrefix11 is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountClassValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As Company = DirectCast(target, Company)
            Dim l As New List(Of Integer)

            If Not ValObj._AccountClassPrefix11 > 0 Then
                e.Description = String.Format(My.Resources.General_Company_AccountClassPrefixNull, (1).ToString)
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf Not ValObj._AccountClassPrefix21 > 0 Then
                e.Description = String.Format(My.Resources.General_Company_AccountClassPrefixNull, (2).ToString)
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf Not ValObj._AccountClassPrefix31 > 0 Then
                e.Description = String.Format(My.Resources.General_Company_AccountClassPrefixNull, (3).ToString)
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf Not ValObj._AccountClassPrefix41 > 0 Then
                e.Description = String.Format(My.Resources.General_Company_AccountClassPrefixNull, (4).ToString)
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf Not ValObj._AccountClassPrefix51 > 0 Then
                e.Description = String.Format(My.Resources.General_Company_AccountClassPrefixNull, (5).ToString)
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf Not ValObj._AccountClassPrefix61 > 0 Then
                e.Description = String.Format(My.Resources.General_Company_AccountClassPrefixNull, (6).ToString)
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            l.Add(ValObj._AccountClassPrefix11)
            l.Add(ValObj._AccountClassPrefix12)
            l.Add(ValObj._AccountClassPrefix21)
            l.Add(ValObj._AccountClassPrefix22)
            l.Add(ValObj._AccountClassPrefix31)
            l.Add(ValObj._AccountClassPrefix32)
            l.Add(ValObj._AccountClassPrefix41)
            l.Add(ValObj._AccountClassPrefix42)
            l.Add(ValObj._AccountClassPrefix51)
            l.Add(ValObj._AccountClassPrefix52)
            l.Add(ValObj._AccountClassPrefix61)
            l.Add(ValObj._AccountClassPrefix62)

            Dim i, j As Integer
            For i = l.Count To 1 Step -1
                If l(i - 1) = 0 Then l.RemoveAt(i - 1)
            Next

            For i = 1 To l.Count - 1
                For j = i + 1 To l.Count
                    If l(i - 1) = l(j - 1) Then
                        e.Description = String.Format(My.Resources.General_Company_AccountClassPrefixNotUnique, l(i - 1).ToString)
                        e.Severity = Validation.RuleSeverity.Error
                        Return False
                    End If
                Next
            Next

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property DefaultTaxNpdFormula is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function NpdFormulaValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As Company = DirectCast(target, Company)

            If StringIsNullOrEmpty(ValObj._DefaultTaxNpdFormula) Then
                e.Description = My.Resources.General_Company_NpdFormulaNull
                e.Severity = Validation.RuleSeverity.Warning
                Return False
            End If

            Dim FS As New FormulaSolver
            FS.Param("NPD") = 470
            FS.Param("PAJ") = 800
            If Not FS.Solved(ValObj._DefaultTaxNpdFormula.Trim, New Double) Then
                e.Description = My.Resources.General_Company_NpdFormulaInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            If ValObj._DefaultTaxNpdFormula.Trim.Length > 255 Then
                e.Description = My.Resources.General_Company_NpdFormulaTooLong
                e.Severity = Validation.RuleSeverity.Warning
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("General.Company3")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.Company1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole(Name_AdminRole)
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.Company3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole(Name_AdminRole)
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Get a new company instance. Creates a new database on save.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function NewCompany() As Company
            If Not CanAddObject() Then Throw New SecurityException( _
                My.Resources.Common_SecurityInsertDenied)
            Dim result As New Company
            result._Accounts = CompanyAccountList.NewCompanyAccountList
            result._DefaultTaxRates = CompanyRateList.NewCompanyRateList
            result.ValidationRules.CheckRules()
            Return result
        End Function

        ''' <summary>
        ''' Get a current company instance.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function GetCompany() As Company
            Return DataPortal.Fetch(Of Company)(New Criteria())
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("CompanyFetch")

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception( _
                    String.Format(My.Resources.Common_ObjectNotFound, My.Resources.General_Company_TypeName, ""))

                Dim dr As DataRow = myData.Rows(0)

                _Code = CStrSafe(dr.Item(0)).Trim
                _Name = CStrSafe(dr.Item(1)).Trim
                _CodeVat = CStrSafe(dr.Item(2)).Trim
                _Email = CStrSafe(dr.Item(3)).Trim
                _HeadPerson = CStrSafe(dr.Item(4)).Trim
                _CodeSODRA = CStrSafe(dr.Item(5)).Trim
                _HeadPersonSignature = CByteArraySafe(dr.Item(6), 0)
                _NumbersInInvoice = CIntSafe(dr.Item(7), 0)
                _AddDateToInvoiceNumber = ConvertDbBoolean(CIntSafe(dr.Item(8), 0))
                _DefaultInvoiceMadeContent = CStrSafe(dr.Item(9)).Trim
                _DefaultInvoiceReceivedContent = CStrSafe(dr.Item(10)).Trim
                _AccountClassPrefix11 = CIntSafe(dr.Item(11), 0)
                _AccountClassPrefix12 = CIntSafe(dr.Item(12), 0)
                _AccountClassPrefix21 = CIntSafe(dr.Item(13), 0)
                _AccountClassPrefix22 = CIntSafe(dr.Item(14), 0)
                _AccountClassPrefix31 = CIntSafe(dr.Item(15), 0)
                _AccountClassPrefix32 = CIntSafe(dr.Item(16), 0)
                _AccountClassPrefix41 = CIntSafe(dr.Item(17), 0)
                _AccountClassPrefix42 = CIntSafe(dr.Item(18), 0)
                _AccountClassPrefix51 = CIntSafe(dr.Item(19), 0)
                _AccountClassPrefix52 = CIntSafe(dr.Item(20), 0)
                _AccountClassPrefix61 = CIntSafe(dr.Item(21), 0)
                _AccountClassPrefix62 = CIntSafe(dr.Item(22), 0)
                _DefaultTaxNpdFormula = CStrSafe(dr.Item(23)).Trim
                _MeasureUnitInvoiceReceived = CStrSafe(dr.Item(24)).Trim
                _AddDateToTillIncomeOrderNumber = ConvertDbBoolean(CIntSafe(dr.Item(25), 0))
                _AddDateToTillSpendingsOrderNumber = ConvertDbBoolean(CIntSafe(dr.Item(26), 0))
                _BaseCurrency = CStrSafe(dr.Item(27)).Trim
                If String.IsNullOrEmpty(_BaseCurrency.Trim) Then _BaseCurrency = "LTL"
                _Accountant = CStrSafe(dr.Item(28)).Trim
                _Cashier = CStrSafe(dr.Item(29)).Trim
                _MainEconomicActivityCode = CStrSafe(dr.Item(30)).Trim
                _VatDeductionPercentage = CDblSafe(dr.Item(31), 2, 100.0)
                _UseVatDeclarationSchemas = ConvertDbBoolean(CIntSafe(dr.Item(32), 0))
                _DeclarationSchemaSales = VatDeclarationSchemaInfo.GetVatDeclarationSchemaInfo(dr, 33)
                _DeclarationSchemaPurchase = VatDeclarationSchemaInfo.GetVatDeclarationSchemaInfo(dr, 42)

                _CompanyDatabaseName = GetCurrentIdentity.Database

            End Using

            _Accounts = CompanyAccountList.GetCompanyAccountList
            _DefaultTaxRates = CompanyRateList.GetCompanyRateList

            ValidationRules.CheckRules()

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            CreateCompany(_Name, AddressOf CustomCreateDatabaseMethod)

            MarkOld()

        End Sub

        Private Sub CustomCreateDatabaseMethod(ByVal NewDatabaseName As String)

            Dim myComm As New SQLCommand("CompanyInsert")
            AddWithParams(myComm)
            myComm.AddParam("?BB", "")
            myComm.AddParam("?BC", "")
            myComm.AddParam("?BD", "")
            myComm.AddParam("?BE", "")
            myComm.AddParam("?BF", "")
            myComm.AddParam("?BG", "")
            myComm.AddParam("?BH", "")
            myComm.AddParam("?BI", "")
            myComm.AddParam("?BK", "")
            myComm.AddParam("?BL", "")
            myComm.AddParam("?BO", _BaseCurrency)

            Using transaction As New SqlTransaction

                Try

                    myComm.Execute()

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw New Exception(My.Resources.General_Company_InsertFailed, ex)
                End Try

            End Using

            _CompanyDatabaseName = NewDatabaseName

        End Sub


        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim myComm As New SQLCommand("CompanyUpdate")
            AddWithParams(myComm)

            Using transaction As New SqlTransaction

                Try

                    myComm.Execute()

                    _DefaultTaxRates.Update(Me)
                    _Accounts.Update(Me)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            ' Company identification info is part of CompanyInfo object in GlobalContext
            ApskaitaObjects.Settings.CompanyInfo.LoadCompanyInfoToGlobalContext("", "")

        End Sub


        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AA", _Code.Trim)
            myComm.AddParam("?AB", _Name.Trim)
            myComm.AddParam("?AC", _CodeVat.Trim)
            myComm.AddParam("?AD", _Email.Trim)
            myComm.AddParam("?AE", _HeadPerson.Trim)
            myComm.AddParam("?AF", _CodeSODRA.Trim)
            myComm.AddParam("?AG", _HeadPersonSignature, GetType(Byte()))
            myComm.AddParam("?AH", _NumbersInInvoice)
            myComm.AddParam("?AI", ConvertDbBoolean(_AddDateToInvoiceNumber))
            myComm.AddParam("?AJ", _DefaultInvoiceMadeContent.Trim)
            myComm.AddParam("?AK", _DefaultInvoiceReceivedContent.Trim)
            myComm.AddParam("?AL", _AccountClassPrefix11)
            myComm.AddParam("?AM", _AccountClassPrefix12)
            myComm.AddParam("?AN", _AccountClassPrefix21)
            myComm.AddParam("?AO", _AccountClassPrefix22)
            myComm.AddParam("?AQ", _AccountClassPrefix31)
            myComm.AddParam("?AP", _AccountClassPrefix32)
            myComm.AddParam("?AR", _AccountClassPrefix41)
            myComm.AddParam("?AT", _AccountClassPrefix42)
            myComm.AddParam("?AU", _AccountClassPrefix51)
            myComm.AddParam("?AV", _AccountClassPrefix52)
            myComm.AddParam("?AZ", _AccountClassPrefix61)
            myComm.AddParam("?AW", _AccountClassPrefix62)
            myComm.AddParam("?BA", _DefaultTaxNpdFormula.Trim)
            myComm.AddParam("?BJ", _MeasureUnitInvoiceReceived.Trim)
            myComm.AddParam("?BM", ConvertDbBoolean(_AddDateToTillIncomeOrderNumber))
            myComm.AddParam("?BN", ConvertDbBoolean(_AddDateToTillSpendingsOrderNumber))
            myComm.AddParam("?BQ", _Accountant.Trim)
            myComm.AddParam("?BP", _Cashier.Trim)
            myComm.AddParam("?BR", ConvertDbBoolean(_UseVatDeclarationSchemas))
            If _DeclarationSchemaSales = VatDeclarationSchemaInfo.Empty Then
                myComm.AddParam("?BS", 0)
            Else
                myComm.AddParam("?BS", _DeclarationSchemaSales.ID)
            End If
            If _DeclarationSchemaPurchase = VatDeclarationSchemaInfo.Empty Then
                myComm.AddParam("?BT", 0)
            Else
                myComm.AddParam("?BT", _DeclarationSchemaPurchase.ID)
            End If
            myComm.AddParam("?BU", _MainEconomicActivityCode)
            myComm.AddParam("?BV", _VatDeductionPercentage)

        End Sub

#End Region

    End Class

End Namespace