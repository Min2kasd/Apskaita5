﻿Imports ApskaitaObjects.Attributes

Namespace Documents

    ''' <summary>
    ''' Represents an account that is used for money transactions (bank, till, etc.)
    ''' </summary>
    ''' <remarks>Provides additional data on top of <see cref="General.Account">General.Account</see> 
    ''' in order to support money transactions (currencies, specific data import functionality, etc.)
    ''' Values are stored in the database table cashaccounts.</remarks>
    <Serializable()> _
    Public NotInheritable Class CashAccount
        Inherits BusinessBase(Of CashAccount)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Type As CashAccountType = CashAccountType.BankAccount
        Private _TypeHumanReadable As String = Utilities.ConvertLocalizedName(CashAccountType.BankAccount)
        Private _ManagingPerson As PersonInfo
        Private _Account As Long = 0
        Private _BankFeeCostsAccount As Long = 0
        Private _Name As String = ""
        Private _BankAccountNumber As String = ""
        Private _BankName As String = ""
        Private _BankCode As String = ""
        Private _IsLitasEsisCompliant As Boolean = False
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _EnforceUniqueOperationID As Boolean = False
        Private _BankFeeLimit As Integer = 0
        Private _BalanceAtBegining As Double = 0
        Private _IsInUse As Boolean = False
        Private _IsObsolete As Boolean = False


        ''' <summary>
        ''' Gets an ID of the cash account that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets <see cref="CashAccountType">a type of the cash account</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.TypeID.</remarks>
        Public Property [Type]() As CashAccountType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As CashAccountType)
                CanWriteProperty(True)
                If _IsInUse Then Exit Property
                If _Type <> value Then
                    _Type = value
                    _TypeHumanReadable = Utilities.ConvertLocalizedName(_Type)
                    PropertyHasChanged()
                    PropertyHasChanged("TypeHumanReadable")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets <see cref="CashAccountType">a type of the cash account</see> as a localized human readable string.
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.TypeID.</remarks>
        <LocalizedEnumField(GetType(CashAccountType), False, "")> _
        Public Property TypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TypeHumanReadable
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)

                CanWriteProperty(True)
                If _IsInUse Then Exit Property

                If value Is Nothing Then value = ""

                Dim enumValue As CashAccountType = Utilities.ConvertLocalizedName(Of CashAccountType)(value)

                If _Type <> enumValue Then
                    _Type = enumValue
                    _TypeHumanReadable = Utilities.ConvertLocalizedName(_Type)
                    PropertyHasChanged()
                    PropertyHasChanged("Type")
                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets <see cref="General.Account.ID">an account</see> for the cash account.
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.Account.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, True, 2)> _
        Public Property Account() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _IsInUse Then Exit Property
                If _Account <> value Then
                    _Account = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets <see cref="General.Account.ID">an account</see> for the bank fee costs.
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.Account.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, True, 6)> _
        Public Property BankFeeCostsAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BankFeeCostsAccount
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _BankFeeCostsAccount <> value Then
                    _BankFeeCostsAccount = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a person that is responsible for the cash account administration 
        ''' (e.g. some bank, PayPal, etc.).
        ''' </summary>
        ''' <remarks>Is null in case of a till account.
        ''' Value is stored in the database table cashaccounts.ManagingPersonID.</remarks>
        <PersonFieldAttribute(ValueRequiredLevel.Mandatory, False, True, False)> _
        Public Property ManagingPerson() As PersonInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ManagingPerson
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As PersonInfo)
                CanWriteProperty(True)

                If Not (_ManagingPerson Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _ManagingPerson Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _ManagingPerson = value) Then

                    _ManagingPerson = value
                    PropertyHasChanged()

                    If _Type = CashAccountType.BankAccount OrElse _Type = CashAccountType.PseudoBankAccount Then
                        If _ManagingPerson Is Nothing OrElse _ManagingPerson.IsEmpty Then
                            _BankCode = ""
                            _BankFeeCostsAccount = 0
                            _BankName = ""
                        Else
                            _BankCode = _ManagingPerson.Code
                            _BankFeeCostsAccount = _ManagingPerson.AccountAgainstBankSupplyer
                            _BankName = _ManagingPerson.Name
                        End If
                        PropertyHasChanged("BankCode")
                        PropertyHasChanged("BankFeeCostsAccount")
                        PropertyHasChanged("BankName")
                    End If

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a name of the cash account. 
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.Name.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
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
        ''' Gets or sets a number of the cash account (e.g. IBAN).
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.BankAccountNumber.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 100)> _
        Public Property BankAccountNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BankAccountNumber.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _BankAccountNumber.Trim <> value.Trim Then
                    _BankAccountNumber = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a name of the bank that is administering the cash account.
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.BankName.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property BankName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BankName.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _BankName.Trim <> value.Trim Then
                    _BankName = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a company registration code of the bank that is administering the cash account.
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.BankCode.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property BankCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BankCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _BankCode.Trim <> value.Trim Then
                    _BankCode = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the bank, that is administering the cash account, 
        ''' supports ISO20022 standard (previously LITAS-ESIS standard) for electronic bank data.
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.IsLitasEsisCompliant.</remarks>
        Public Property IsLitasEsisCompliant() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsLitasEsisCompliant
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IsLitasEsisCompliant <> value Then
                    _IsLitasEsisCompliant = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the currency of the cash account.
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.CurrencyCode.</remarks>
        <CurrencyFieldAttribute(ValueRequiredLevel.Mandatory)> _
        Public Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)

                CanWriteProperty(True)

                If _IsInUse Then Exit Property

                If value Is Nothing Then value = ""

                If Not CurrenciesEquals(_CurrencyCode, value, GetCurrentCompany.BaseCurrency) Then
                    _CurrencyCode = value.Trim
                    PropertyHasChanged()
                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to enforce the uniqueness of <see cref="BankOperation.UniqueCode">BankOperation.UniqueCode</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.EnforceUniqueOperationID.</remarks>
        Public Property EnforceUniqueOperationID() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _EnforceUniqueOperationID
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _EnforceUniqueOperationID <> value Then
                    _EnforceUniqueOperationID = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an amount of a withdrawal that is treated as a bank fee when importing data.
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.BankFeeLimit.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2)> _
        Public Property BankFeeLimit() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BankFeeLimit
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _BankFeeLimit <> value Then
                    _BankFeeLimit = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a balance of the cash account at the moment of the transfer of balance 
        ''' (in the cash account's currency).
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.BalanceAtBegining.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property BalanceAtBegining() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BalanceAtBegining
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_BalanceAtBegining) <> CRound(value) Then
                    _BalanceAtBegining = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the cash account is obsolete, no longer in use.
        ''' </summary>
        ''' <remarks>Value is stored in the database table cashaccounts.IsObsolete.</remarks>
        Public Property IsObsolete() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsObsolete
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IsObsolete <> value Then
                    _IsObsolete = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the cash account is in use, i.e. there are cash operations in the account.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsInUse() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsInUse
            End Get
        End Property



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
            Return String.Format(My.Resources.Documents_CashAccount_ToString, _
                _Account.ToString(), _TypeHumanReadable, _Name, _ID.ToString())
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Name"))
            ValidationRules.AddRule(AddressOf CommonValidation.AccountFieldValidation, _
                New Csla.Validation.RuleArgs("Account"))
            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyFieldValidation, _
                New Csla.Validation.RuleArgs("CurrencyCode"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringValueUniqueInCollectionValidation, _
                New Csla.Validation.RuleArgs("Name"))

            ValidationRules.AddRule(AddressOf ManagingPersonValidation, _
                New Validation.RuleArgs("ManagingPerson"))
            ValidationRules.AddRule(AddressOf BankFeeCostsAccountValidation, _
                New Validation.RuleArgs("BankFeeCostsAccount"))
            ValidationRules.AddRule(AddressOf EnforceUniqueOperationIDValidation, _
               New Validation.RuleArgs("EnforceUniqueOperationID"))
            ValidationRules.AddRule(AddressOf BankValidation, New Validation.RuleArgs("BankAccountNumber"))
            ValidationRules.AddRule(AddressOf BankValidation, New Validation.RuleArgs("BankName"))
            ValidationRules.AddRule(AddressOf BankValidation, New Validation.RuleArgs("BankCode"))

            ValidationRules.AddDependantProperty("Type", "ManagingPerson", False)
            ValidationRules.AddDependantProperty("Type", "BankFeeCostsAccount", False)
            ValidationRules.AddDependantProperty("Type", "BankAccountNumber", False)
            ValidationRules.AddDependantProperty("Type", "BankName", False)
            ValidationRules.AddDependantProperty("Type", "BankCode", False)
            ValidationRules.AddDependantProperty("Type", "EnforceUniqueOperationID", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the values of the properties 
        ''' related to Bank fees are valid (for (pseudo) bank account).
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function BankValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As CashAccount = DirectCast(target, CashAccount)

            If valObj._Type <> CashAccountType.BankAccount AndAlso _
                valObj._Type <> CashAccountType.PseudoBankAccount Then Return True

            Return StringFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that the values of the properties 
        ''' related to Bank are valid (for (pseudo) bank account).
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function ManagingPersonValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As CashAccount = DirectCast(target, CashAccount)

            If valObj._Type <> CashAccountType.BankAccount AndAlso _
                valObj._Type <> CashAccountType.PseudoBankAccount Then Return True

            Return PersonFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that the values of the properties 
        ''' related to Bank are valid (for (pseudo) bank account).
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function BankFeeCostsAccountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As CashAccount = DirectCast(target, CashAccount)

            If valObj._Type <> CashAccountType.BankAccount AndAlso _
                valObj._Type <> CashAccountType.PseudoBankAccount Then Return True

            Return AccountFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that the values of the properties 
        ''' related to Bank are valid (for (pseudo) bank account).
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function EnforceUniqueOperationIDValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As CashAccount = DirectCast(target, CashAccount)

            If valObj._Type <> CashAccountType.BankAccount AndAlso _
                valObj._Type <> CashAccountType.PseudoBankAccount Then Return True

            If Not DirectCast(target, CashAccount).EnforceUniqueOperationID Then
                e.Description = My.Resources.Documents_CashAccount_BankWithoutUniqueCodes
                e.Severity = Validation.RuleSeverity.Warning
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewCashAccount() As CashAccount
            Dim result As New CashAccount
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function GetCashAccount(ByVal dr As DataRow) As CashAccount
            Return New CashAccount(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(0), 0)
            _Name = CStrSafe(dr.Item(1)).Trim
            _Account = CLongSafe(dr.Item(2), 0)
            _BankAccountNumber = CStrSafe(dr.Item(3)).Trim
            _BankName = CStrSafe(dr.Item(4)).Trim
            _BankCode = CStrSafe(dr.Item(5)).Trim
            _IsLitasEsisCompliant = ConvertDbBoolean(CIntSafe(dr.Item(6), 0))
            _CurrencyCode = CStrSafe(dr.Item(7)).Trim
            _EnforceUniqueOperationID = ConvertDbBoolean(CIntSafe(dr.Item(8), 0))
            _BankFeeLimit = CIntSafe(dr.Item(9), 0)
            _Type = Utilities.ConvertDatabaseID(Of CashAccountType)(CIntSafe(dr.Item(10), 0))
            _TypeHumanReadable = Utilities.ConvertLocalizedName(_Type)
            _BalanceAtBegining = CDblSafe(dr.Item(11), 2, 0)
            _IsObsolete = ConvertDbBoolean(CIntSafe(dr.Item(12), 0))
            _BankFeeCostsAccount = CLongSafe(dr.Item(13), 0)
            _IsInUse = ConvertDbBoolean(CIntSafe(dr.Item(14), 0))
            _ManagingPerson = PersonInfo.GetPersonInfo(dr, 15)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert(ByVal parent As CashAccountList)

            Dim myComm As New SQLCommand("InsertCashAccount")
            AddWithParams(myComm)
            myComm.AddParam("?AH", Utilities.ConvertDatabaseID(_Type))

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As CashAccountList)

            Dim myComm As New SQLCommand("UpdateCashAccount")
            myComm.AddParam("?CD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteCashAccount")
            myComm.AddParam("?CD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)
            myComm.AddParam("?AA", _Name.Trim)
            myComm.AddParam("?AB", _BankName.Trim)
            myComm.AddParam("?AC", _BankCode.Trim)
            myComm.AddParam("?AD", ConvertDbBoolean(_IsLitasEsisCompliant))
            myComm.AddParam("?AE", _CurrencyCode.Trim)
            myComm.AddParam("?AF", ConvertDbBoolean(_EnforceUniqueOperationID))
            myComm.AddParam("?AG", CRound(_BankFeeLimit))
            myComm.AddParam("?AI", CRound(_BalanceAtBegining))
            myComm.AddParam("?AJ", ConvertDbBoolean(_IsObsolete))
            myComm.AddParam("?AK", _Account)
            myComm.AddParam("?AL", _BankAccountNumber.Trim)
            myComm.AddParam("?AM", _BankFeeCostsAccount)
            If Not _ManagingPerson Is Nothing AndAlso Not _ManagingPerson.IsEmpty Then
                myComm.AddParam("?AN", _ManagingPerson.ID)
            Else
                myComm.AddParam("?AN", 0)
            End If
        End Sub

        Friend Sub CheckIfInUse()

            If IsNew Then Exit Sub

            Dim myComm As New SQLCommand("CheckIfCashAccountUsed")
            myComm.AddParam("?CD", _ID)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count < 1 Then
                    _IsInUse = False
                Else
                    _IsInUse = ConvertDbBoolean(CIntSafe(myData.Rows(0).Item(0), 0))
                End If
            End Using

        End Sub

#End Region

    End Class

End Namespace