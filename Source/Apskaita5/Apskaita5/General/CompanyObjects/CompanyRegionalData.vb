﻿Imports ApskaitaObjects.Attributes

Namespace General

    ''' <summary>
    ''' Represents general company data for a certain language.
    ''' </summary>
    ''' <remarks>Values for the base language are stored in the database table imone. 
    ''' Values for other languages are stored in the database table companyregionaldata.</remarks>
    <Serializable()> _
    Public NotInheritable Class CompanyRegionalData
        Inherits BusinessBase(Of CompanyRegionalData)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Private _ID As Integer = -1
        Private _LanguageCode As String = ""
        Private _LanguageName As String = ""
        Private _Address As String = ""
        Private _BankAccount As String = ""
        Private _Bank As String = ""
        Private _BankSWIFT As String = ""
        Private _BankAddress As String = ""
        Private _Contacts As String = ""
        Private _InvoiceInfoLine As String = ""
        Private _MeasureUnitInvoiceMade As String = ""
        Private _DiscountName As String = ""
        Private _LogoImage As Byte() = Nothing
        Private _HeadTitle As String = ""
        Private _InvoiceForm As Byte() = Nothing
        Private _ProformaInvoiceForm As Byte() = Nothing


        ''' <summary>
        ''' Gets an ID of the regional data that is asigned by a database (AUTOINCREMENT).
        ''' Returns 0 for base language.
        ''' </summary>
        ''' <remarks>Value for the base language is always 0. 
        ''' Value for any other language is stored in the database field companyregionaldata.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets a language code for the current data.
        ''' </summary>
        ''' <remarks>Can only be set for a new CompanyRegionalData.
        ''' Value for the base language is always base language code. 
        ''' Value for any other language is stored in the database field companyregionaldata.LanguageCode.</remarks>
        <LanguageCodeField(ValueRequiredLevel.Mandatory, False)> _
        Public Property LanguageCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageCode
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)

                If Not IsNew Then
                    PropertyHasChanged()
                    Exit Property
                End If

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
                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets a language name for the current data.
        ''' </summary>
        ''' <remarks>Can only be set for a new CompanyRegionalData.
        ''' Value for the base language is always base language name. 
        ''' Value for any other language is stored in the database field companyregionaldata.LanguageCode.</remarks>
        <LanguageNameField(ValueRequiredLevel.Mandatory, False)> _
        Public Property LanguageName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageName
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)

                If Not IsNew Then
                    PropertyHasChanged()
                    Exit Property
                End If

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
                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a company address in <see cref="LanguageName">LanguageName</see>.
        ''' </summary>
        ''' <remarks>Value for the base language is stored in the database field imone.I_Adresas. 
        ''' Value for any other language is stored in the database field companyregionaldata.Address.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255, False)> _
        Public Property Address() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Address.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Address.Trim <> value.Trim Then
                    _Address = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a company's bank account in <see cref="LanguageName">LanguageName</see>.
        ''' </summary>
        ''' <remarks>Value for the base language is stored in the database field imone.I_Banko_sask. 
        ''' Value for any other language is stored in the database field companyregionaldata.BankAccount.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 40, False)> _
        Public Property BankAccount() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BankAccount.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _BankAccount.Trim <> value.Trim Then
                    _BankAccount = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a company's bank name in <see cref="LanguageName">LanguageName</see>.
        ''' </summary>
        ''' <remarks>Value for the base language is stored in the database field imone.I_Bankas. 
        ''' Value for any other language is stored in the database field companyregionaldata.Bank.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255, False)> _
        Public Property Bank() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Bank.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Bank.Trim <> value.Trim Then
                    _Bank = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a company's bank's SWIFT code in <see cref="LanguageName">LanguageName</see>.
        ''' </summary>
        ''' <remarks>Value for the base language is stored in the database field imone.BankSWIFT. 
        ''' Value for any other language is stored in the database field companyregionaldata.BankSWIFT.</remarks>
        <StringField(ValueRequiredLevel.Recommended, 100, False)> _
        Public Property BankSWIFT() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BankSWIFT.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _BankSWIFT.Trim <> value.Trim Then
                    _BankSWIFT = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a company's bank's address in <see cref="LanguageName">LanguageName</see>.
        ''' </summary>
        ''' <remarks>Value for the base language is stored in the database field imone.BankAddress. 
        ''' Value for any other language is stored in the database field companyregionaldata.BankAddress.</remarks>
        <StringField(ValueRequiredLevel.Recommended, 255, False)> _
        Public Property BankAddress() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BankAddress.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _BankAddress.Trim <> value.Trim Then
                    _BankAddress = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a company contact data in <see cref="LanguageName">LanguageName</see>.
        ''' </summary>
        ''' <remarks>Value for the base language is stored in the database field imone.I_Koordinates. 
        ''' Value for any other language is stored in the database field companyregionaldata.Contacts.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255, False)> _
        Public Property Contacts() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Contacts.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Contacts.Trim <> value.Trim Then
                    _Contacts = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets additinal information that could be displayed in invoices made in <see cref="LanguageName">LanguageName</see>.
        ''' </summary>
        ''' <remarks>Value for the base language is stored in the database field imone.InvoiceInfoLine. 
        ''' Value for any other language is stored in the database field companyregionaldata.InvoiceInfoLine.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255, False)> _
        Public Property InvoiceInfoLine() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InvoiceInfoLine.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _InvoiceInfoLine.Trim <> value.Trim Then
                    _InvoiceInfoLine = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a default measure unit name for invoices made in <see cref="LanguageName">LanguageName</see>.
        ''' </summary>
        ''' <remarks>Value for the base language is stored in the database field imone.MeasureUnitInvoiceMade. 
        ''' Value for any other language is stored in the database field companyregionaldata.MeasureUnitInvoiceMade.</remarks>
        <StringField(ValueRequiredLevel.Recommended, 50, False)> _
        Public Property MeasureUnitInvoiceMade() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MeasureUnitInvoiceMade.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _MeasureUnitInvoiceMade.Trim <> value.Trim Then
                    _MeasureUnitInvoiceMade = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a discount name for invoices made in <see cref="LanguageName">LanguageName</see>.
        ''' </summary>
        ''' <remarks>Value for the base language is stored in the database field imone.DiscountName. 
        ''' Value for any other language is stored in the database field companyregionaldata.DiscountName.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255, False)> _
        Public Property DiscountName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DiscountName.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _DiscountName.Trim <> value.Trim Then
                    _DiscountName = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a company logo in <see cref="LanguageName">LanguageName</see>.
        ''' </summary>
        ''' <remarks>Values are stored in the database table companyforms 
        ''' where field FormToken equals <see cref="CompanyBinaryDataType.Logo">CompanyBinaryDataType.Logo</see>.</remarks>
        Public Property LogoImage() As System.Drawing.Image
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ByteArrayToImage(_LogoImage)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As System.Drawing.Image)

                CanWriteProperty(True)

                If value Is Nothing AndAlso (_LogoImage Is Nothing OrElse _
                    Not _LogoImage.Length > 50) Then Exit Property

                If value Is Nothing Then
                    _LogoImage = Nothing
                    PropertyHasChanged()
                    Exit Property
                End If

                Dim valueArray As Byte() = ImageToByteArray(value)

                If _LogoImage Is Nothing OrElse valueArray Is Nothing OrElse _
                    Not _LogoImage.Equals(valueArray) Then
                    _LogoImage = valueArray
                    PropertyHasChanged()
                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a company's head title name in <see cref="LanguageName">LanguageName</see>.
        ''' </summary>
        ''' <remarks>Value for the base language is stored in the database field imone.HeadTitle. 
        ''' Value for any other language is stored in the database field companyregionaldata.HeadTitle.</remarks>
        <StringField(ValueRequiredLevel.Recommended, 255, False)> _
        Public Property HeadTitle() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HeadTitle.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _HeadTitle.Trim <> value.Trim Then
                    _HeadTitle = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an invoice form (.rdlc format) in <see cref="LanguageName">LanguageName</see>.
        ''' </summary>
        ''' <remarks>Values are stored in the database table companyforms 
        ''' where field FormToken equals <see cref="CompanyBinaryDataType.InvoiceForm">CompanyBinaryDataType.InvoiceForm</see>.</remarks>
        Public Property InvoiceForm() As Byte()
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InvoiceForm
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Byte())
                CanWriteProperty(True)
                If Not (_InvoiceForm Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _InvoiceForm Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _InvoiceForm.Equals(value)) Then
                    _InvoiceForm = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a proforma invoice form (.rdlc format) in <see cref="LanguageName">LanguageName</see>.
        ''' </summary>
        ''' <remarks>Values are stored in the database table companyforms 
        ''' where field FormToken equals <see cref="CompanyBinaryDataType.ProformaInvoiceForm">CompanyBinaryDataType.ProformaInvoiceForm</see>.</remarks>
        Public Property ProformaInvoiceForm() As Byte()
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ProformaInvoiceForm
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Byte())
                CanWriteProperty(True)
                If Not (_ProformaInvoiceForm Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _ProformaInvoiceForm Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _ProformaInvoiceForm.Equals(value)) Then
                    _ProformaInvoiceForm = value
                    PropertyHasChanged()
                End If
            End Set
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsDirty
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
                Return (Not Me.IsNew AndAlso Me.IsDirty) OrElse (IsNew AndAlso _
                    (Not String.IsNullOrEmpty(_Address.Trim) OrElse _
                    Not String.IsNullOrEmpty(_Contacts.Trim) OrElse _
                    Not String.IsNullOrEmpty(_BankAccount.Trim) OrElse _
                    Not String.IsNullOrEmpty(_Bank.Trim) OrElse _
                    Not String.IsNullOrEmpty(_BankSWIFT.Trim) OrElse _
                    Not String.IsNullOrEmpty(_InvoiceInfoLine.Trim) OrElse _
                    Not String.IsNullOrEmpty(_DiscountName.Trim) OrElse _
                    Not String.IsNullOrEmpty(_MeasureUnitInvoiceMade.Trim) OrElse _
                    Not String.IsNullOrEmpty(_HeadTitle.Trim) OrElse _
                    (Not _LogoImage Is Nothing AndAlso _LogoImage.Length > 50) OrElse _
                    (Not _InvoiceForm Is Nothing AndAlso _InvoiceForm.Length > 50)))
            End Get
        End Property



        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return Me.BrokenRulesCollection.WarningCount > 0
        End Function

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
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning), False)
            Return result
        End Function


        Public Overrides Function Save() As CompanyRegionalData

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim result As CompanyRegionalData = MyBase.Save
            CompanyRegionalInfoList.InvalidateCache()
            Return result

        End Function

        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Address"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("BankAccount"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Bank"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("DiscountName"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("BankSWIFT"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("BankAddress"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Contacts"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("InvoiceInfoLine"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("MeasureUnitInvoiceMade"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("HeadTitle"))

            ValidationRules.AddRule(AddressOf LanguageValidation, New Validation.RuleArgs("LanguageName"))

        End Sub

        ''' <summary>
        ''' Rule ensuring that a language is specified.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function LanguageValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            If Not LanguageNameValidation(target, e) Then Return False

            Dim valObj As CompanyRegionalData = DirectCast(target, CompanyRegionalData)

            If Not StringIsNullOrEmpty(valObj._LanguageCode) AndAlso valObj.IsNew AndAlso _
                valObj._LanguageCode.Trim.ToUpper = LanguageCodeLith.Trim.ToUpper Then
                e.Description = String.Format(My.Resources.General_CompanyRegionalData_BaseLanguageAlreadyExists, _
                    GetLanguageName(LanguageCodeLith, False))
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("General.Company3")
        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.Company3")
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.Company1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.Company3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.Company3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Get a new CompanyRegionalData instance for a new region/language.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function NewCompanyRegionalData() As CompanyRegionalData

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Dim result As New CompanyRegionalData
            result.ValidationRules.CheckRules()
            Return result

        End Function

        ''' <summary>
        ''' Gets an existing CompanyRegionalData instance from database.
        ''' </summary>
        ''' <param name="regionalDataId"><see cref="ID">ID</see> of the CompanyRegionalData to get. 
        ''' Use 0 to get CompanyRegionalData for base language.</param>
        ''' <remarks></remarks>
        Public Shared Function GetCompanyRegionalData(ByVal regionalDataId As Integer) As CompanyRegionalData
            If regionalDataId < 0 Then regionalDataId = 0
            Return DataPortal.Fetch(Of CompanyRegionalData)(New Criteria(regionalDataId))
        End Function

        ''' <summary>
        ''' Deletes CompanyRegionalData instance. 
        ''' </summary>
        ''' <param name="regionalDataId"><see cref="ID">ID</see> of the CompanyRegionalData to delete.
        ''' CompanyRegionalData for base language cannot be deleted.</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteCompanyRegionalData(ByVal regionalDataId As Integer)
            DataPortal.Delete(New Criteria(regionalDataId))
            CompanyRegionalInfoList.InvalidateCache()
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private mId As Integer
            Public ReadOnly Property Id() As Integer
                Get
                    Return mId
                End Get
            End Property
            Public Sub New(ByVal id As Integer)
                mId = id
            End Sub
        End Class


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As SQLCommand
            If criteria.Id < 1 Then
                myComm = New SQLCommand("FetchRegionalDataLT")
                myComm.AddParam("?LC", LanguageCodeLith.Trim)
            Else
                myComm = New SQLCommand("FetchRegionalData")
                myComm.AddParam("?RD", criteria.Id)
            End If
            myComm.AddParam("?IT", Utilities.ConvertDatabaseCharID(CompanyBinaryDataType.InvoiceForm))
            myComm.AddParam("?LT", Utilities.ConvertDatabaseCharID(CompanyBinaryDataType.Logo))
            myComm.AddParam("?AT", Utilities.ConvertDatabaseCharID(CompanyBinaryDataType.ProformaInvoiceForm))

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception( _
                    String.Format(My.Resources.Common_ObjectNotFound, _
                    My.Resources.General_CompanyRegionalData_TypeName, criteria.Id.ToString))

                Dim dr As DataRow = myData.Rows(0)

                _ID = criteria.Id

                _LanguageCode = CStrSafe(dr.Item(0)).Trim
                _LanguageName = GetLanguageName(_LanguageCode, False)
                _Address = CStrSafe(dr.Item(1)).Trim
                _Bank = CStrSafe(dr.Item(2)).Trim
                _BankAccount = CStrSafe(dr.Item(3)).Trim
                _BankSWIFT = CStrSafe(dr.Item(4)).Trim
                _BankAddress = CStrSafe(dr.Item(5)).Trim
                _Contacts = CStrSafe(dr.Item(6)).Trim
                _InvoiceInfoLine = CStrSafe(dr.Item(7)).Trim
                _MeasureUnitInvoiceMade = CStrSafe(dr.Item(8)).Trim
                _DiscountName = CStrSafe(dr.Item(9)).Trim
                _HeadTitle = CStrSafe(dr.Item(10)).Trim
                _InvoiceForm = CByteArraySafe(dr.Item(11), 50)
                _LogoImage = CByteArraySafe(dr.Item(12), 50)
                _ProformaInvoiceForm = CByteArraySafe(dr.Item(13), 50)

            End Using

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            If _LanguageCode.Trim.ToUpper = LanguageCodeLith.Trim.ToUpper Then Throw New Exception( _
                String.Format(My.Resources.General_CompanyRegionalData_BaseLanguageAlreadyExists, _
                GetLanguageName(LanguageCodeLith, False)))

            CheckIfLanguageUnique()

            Dim myComm As New SQLCommand("InsertRegionalData")
            myComm.AddParam("?AA", _LanguageCode.Trim.ToUpper)
            AddCommandWithParams(myComm)

            Using transaction As New SqlTransaction

                Try

                    myComm.Execute()

                    _ID = Convert.ToInt32(myComm.LastInsertID)

                    InsertRegionalForms()

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

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim myComm As SQLCommand

            If _LanguageCode.Trim.ToLower <> LanguageCodeLith.Trim.ToLower Then

                myComm = New SQLCommand("UpdateCompanyRegionalData")
                myComm.AddParam("?RD", _ID)

            Else

                myComm = New SQLCommand("UpdateCompanyRegionalDataLT")

            End If

            AddCommandWithParams(myComm)

            Using transaction As New SqlTransaction

                Try

                    myComm.Execute()

                    InsertRegionalForms()

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

            If _LanguageCode.Trim.ToLower = LanguageCodeLith.Trim.ToLower Then _
                ApskaitaObjects.Settings.CompanyInfo.LoadCompanyInfoToGlobalContext("", "")

        End Sub

        Private Sub InsertRegionalForms()

            Dim myComm As SQLCommand

            If Not IsNew Then
                myComm = New SQLCommand("DeleteRegionalDataForms")
                myComm.AddParam("?LC", _LanguageCode.Trim)
                myComm.Execute()
            End If

            If Not _InvoiceForm Is Nothing AndAlso _InvoiceForm.Length > 50 Then
                myComm = New SQLCommand("InsertRegionalDataForm")
                myComm.AddParam("?LC", _LanguageCode.Trim)
                myComm.AddParam("?FT", Utilities.ConvertDatabaseCharID(CompanyBinaryDataType.InvoiceForm))
                myComm.AddParam("?FB", _InvoiceForm)
                myComm.Execute()
            End If

            If Not _LogoImage Is Nothing AndAlso _LogoImage.Length > 50 Then
                myComm = New SQLCommand("InsertRegionalDataForm")
                myComm.AddParam("?LC", _LanguageCode.Trim)
                myComm.AddParam("?FT", Utilities.ConvertDatabaseCharID(CompanyBinaryDataType.Logo))
                myComm.AddParam("?FB", _LogoImage)
                myComm.Execute()
            End If

            If Not _ProformaInvoiceForm Is Nothing AndAlso _ProformaInvoiceForm.Length > 50 Then
                myComm = New SQLCommand("InsertRegionalDataForm")
                myComm.AddParam("?LC", _LanguageCode.Trim)
                myComm.AddParam("?FT", Utilities.ConvertDatabaseCharID(CompanyBinaryDataType.ProformaInvoiceForm))
                myComm.AddParam("?FB", _ProformaInvoiceForm)
                myComm.Execute()
            End If

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            If Not criteria.Id > 0 Then Throw New Exception(String.Format( _
                My.Resources.General_CompanyRegionalData_CannotDeleteBaseLanguage, _
                GetLanguageName(LanguageCodeLith, False)))

            CheckIfRegionalDataIsUsed(criteria.Id)

            Dim myComm As New SQLCommand("DeleteRegionalData")
            myComm.AddParam("?RD", criteria.Id)

            Using transaction As New SqlTransaction

                Try

                    myComm.Execute()

                    myComm = New SQLCommand("DeleteAllRegionalFormsByID")
                    myComm.AddParam("?RD", criteria.Id)

                    myComm.Execute()

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkNew()

        End Sub


        Private Sub AddCommandWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AB", _Address)
            myComm.AddParam("?AC", _Bank)
            myComm.AddParam("?AD", _BankAccount)
            myComm.AddParam("?AE", _BankSWIFT)
            myComm.AddParam("?AF", _BankAddress)
            myComm.AddParam("?AG", _Contacts)
            myComm.AddParam("?AH", _InvoiceInfoLine)
            myComm.AddParam("?AI", _MeasureUnitInvoiceMade)
            myComm.AddParam("?AJ", _DiscountName)
            myComm.AddParam("?AK", _HeadTitle)

        End Sub


        Private Sub CheckIfLanguageUnique()

            If _LanguageCode.Trim.ToLower = LanguageCodeLith.Trim.ToLower Then Exit Sub

            Dim myComm As New SQLCommand("CheckIfRegionalDataUnique")
            myComm.AddParam("?RD", _ID)
            myComm.AddParam("?LC", _LanguageCode.Trim)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0)) > 0 Then _
                    Throw New Exception(String.Format(My.Resources.General_CompanyRegionalData_BaseLanguageAlreadyExists, _
                    _LanguageName))
            End Using

        End Sub

        Private Sub CheckIfRegionalDataIsUsed(ByVal RegionalDataID As Integer)

            'Dim myComm As New SQLCommand("CheckIfRegionalDataIsUsed")
            'myComm.AddParam("?RD", RegionalDataID)

            'Using myData As DataTable = myComm.Fetch
            '    If myData.Rows.Count > 0 Then

            '        Dim result As New List(Of String)

            '        If CIntSafe(myData.Rows(0).Item(0)) > 0 Then result.Add("klientų")
            '        If CIntSafe(myData.Rows(0).Item(1)) > 0 Then result.Add("išrašytų sąskaitų")
            '        If CIntSafe(myData.Rows(0).Item(2)) > 0 Then result.Add("užsakymų")
            '        If CIntSafe(myData.Rows(0).Item(3)) > 0 Then result.Add("projektų")

            '        If result.Count > 0 Then
            '            Throw New Exception("Klaida. Šio regiono duomenys yra naudojami " _
            '                & String.Join(", ", result.ToArray) & ".")
            '        End If

            '    End If
            'End Using

        End Sub

#End Region

    End Class

End Namespace