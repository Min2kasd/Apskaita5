﻿Imports ApskaitaObjects.Attributes

Namespace General

    ''' <summary>
    ''' Represents a <see cref="Person">person's</see> data to be imported to the database.
    ''' </summary>
    ''' <remarks>Corresponds to <see cref="General.Person">General.Person</see>, 
    ''' but is specificaly adapted for multiple person data insertion.</remarks>
    <Serializable()> _
    Public NotInheritable Class ImportedPerson
        Inherits BusinessBase(Of ImportedPerson)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private Const PASTE_COLUMN_COUNT As Integer = 21

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _Name As String = ""
        Private _Code As String = ""
        Private _CodeIsNotReal As Boolean = False
        Private _Address As String = ""
        Private _Bank As String = ""
        Private _BankAccount As String = ""
        Private _CodeVAT As String = ""
        Private _CodeSODRA As String = ""
        Private _Email As String = ""
        Private _ContactInfo As String = ""
        Private _InternalCode As String = ""
        Private _LanguageCode As String = ""
        Private _CurrencyCode As String = ""
        Private _StateCode As String = ""
        Private _AccountAgainstBankBuyer As Long = 0
        Private _AccountAgainstBankSupplyer As Long = 0
        Private _IsNaturalPerson As Boolean = False
        Private _IsClient As Boolean = False
        Private _IsSupplier As Boolean = False
        Private _IsWorker As Boolean = False
        Private _IsObsolete As Boolean = False
        Private _AlreadyPresent As Boolean = False
        Private _NotUniqueCode As Boolean = False

        ''' <summary>
        ''' Gets an official name of the person.
        ''' </summary>
        <StringField(ValueRequiredLevel.Mandatory, 100, False)> _
        Public ReadOnly Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets an official registration/personal code of the person.
        ''' </summary>
        <StringField(ValueRequiredLevel.Mandatory, 20, False)> _
        Public ReadOnly Property Code() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Code.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="Code">Code</see> is not real, 
        ''' i.e. assigned by the company (e.g. natural persons are not required
        ''' to provide their personal identification code).
        ''' </summary>
        ''' <remarks>Value is stored in the database field asmenys.CodeIsNotReal.</remarks>
        Public ReadOnly Property CodeIsNotReal() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeIsNotReal
            End Get
        End Property

        ''' <summary>
        ''' Gets an address of the person.
        ''' </summary>
        <StringField(ValueRequiredLevel.Mandatory, 255, False)> _
        Public ReadOnly Property Address() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Address.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a name of the bank used by the person.
        ''' </summary>
        <StringField(ValueRequiredLevel.Optional, 100, False)> _
        Public ReadOnly Property Bank() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Bank.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a bank account number used by the person.
        ''' </summary>
        <StringField(ValueRequiredLevel.Optional, 50, False)> _
        Public ReadOnly Property BankAccount() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BankAccount.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a VAT payer code of the person.
        ''' </summary>
        <StringField(ValueRequiredLevel.Optional, 20, False)> _
        Public ReadOnly Property CodeVAT() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeVAT.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a SODRA (social security) code of the person.
        ''' </summary>
        ''' <remarks>Only applicable to natural persons.</remarks>
        <StringField(ValueRequiredLevel.Optional, Person.SodraCodeMaxLength, False)> _
        Public ReadOnly Property CodeSODRA() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeSODRA.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets an email address of the person.
        ''' </summary>
        <StringField(ValueRequiredLevel.Optional, 40, False)> _
        Public ReadOnly Property Email() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Email.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets any other person info, e.g. phone number, etc.
        ''' </summary>
        <StringField(ValueRequiredLevel.Optional, 255, False)> _
        Public ReadOnly Property ContactInfo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContactInfo.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets an internal code of the person for company's uses.
        ''' </summary>
        <StringField(ValueRequiredLevel.Optional, 255, False)> _
        Public ReadOnly Property InternalCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InternalCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a default language's ISO 639-1 code used by the person.
        ''' </summary>
        <LanguageCodeField(ValueRequiredLevel.Mandatory, True)> _
        Public ReadOnly Property LanguageCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a state of the origin of the person (ISO 3166–1 alpha 2 code).
        ''' </summary>
        ''' <remarks>Value is stored in the database field asmenys.StateCode.</remarks>
        <CodeField(ValueRequiredLevel.Mandatory, ApskaitaObjects.Settings.CodeType.VmiState)> _
        Public ReadOnly Property StateCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _StateCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a default currency code used by the person.
        ''' </summary>
        <CurrencyField(ValueRequiredLevel.Mandatory)> _
        Public ReadOnly Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets an account for buyers' debts.
        ''' </summary>
        ''' <remarks>Used when importing bank operations of type 'money received'. Credits this account, debits bank account.</remarks>
        <AccountField(ValueRequiredLevel.Recommended, False, 1, 2, 3, 4, 5, 6)> _
        Public ReadOnly Property AccountAgainstBankBuyer() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountAgainstBankBuyer
            End Get
        End Property

        ''' <summary>
        ''' Gets an account for suppliers' debts.
        ''' </summary>
        ''' <remarks>Used when importing bank operations of type 'money transfered'. Debits this account, credits bank account.</remarks>
        <AccountField(ValueRequiredLevel.Recommended, False, 1, 2, 3, 4, 5, 6)> _
        Public ReadOnly Property AccountAgainstBankSupplyer() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountAgainstBankSupplyer
            End Get
        End Property

        ''' <summary>
        ''' Whether the person is a natural person, i.e. not a company.
        ''' </summary>
        Public ReadOnly Property IsNaturalPerson() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsNaturalPerson
            End Get
        End Property

        ''' <summary>
        ''' Whether a person is a client of the company.
        ''' </summary>
        Public ReadOnly Property IsClient() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsClient
            End Get
        End Property

        ''' <summary>
        ''' Whether a person is a supplier of the company.
        ''' </summary>
        Public ReadOnly Property IsSupplier() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsSupplier
            End Get
        End Property

        ''' <summary>
        ''' Whether a person is a worker of the company.
        ''' </summary>
        Public ReadOnly Property IsWorker() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsWorker
            End Get
        End Property

        ''' <summary>
        ''' Whether the person is no longer in use, i.e. not supposed to be displayed in combos.
        ''' </summary>
        Public ReadOnly Property IsObsolete() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsObsolete
            End Get
        End Property

        ''' <summary>
        ''' Whether a person with the same <see cref="Code">Code</see> is already in the database.
        ''' </summary>
        Public ReadOnly Property AlreadyPresent() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AlreadyPresent
            End Get
        End Property

        ''' <summary>
        ''' Whether a person's <see cref="Code">Code</see> is not unique in the list.
        ''' </summary>
        Public ReadOnly Property NotUniqueCode() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NotUniqueCode
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


        ''' <summary>
        ''' Gets expected fields count in (tab delimited) paste string.
        ''' </summary>
        Public Shared Function GetPasteStringColumnCount() As Integer
            Return PASTE_COLUMN_COUNT
        End Function

        ''' <summary>
        ''' Gets an array of expected fields sequence in (tab delimited) paste string.
        ''' </summary>
        Public Shared Function GetPasteStringColumns() As String()
            Return My.Resources.General_ImportedPerson_PasteColumns.Split(New String() {"<BR>"}, _
                StringSplitOptions.RemoveEmptyEntries)
        End Function

        ''' <summary>
        ''' Gets a human readable description of expected fields sequence in (tab delimited) paste string.
        ''' </summary>
        Public Shared Function GetPasteStringColumnsDescription() As String
            Return String.Format(My.Resources.General_ImportedPerson_PasteColumnsDescription1, PASTE_COLUMN_COUNT,
                String.Join(", ", My.Resources.General_ImportedPerson_PasteColumns.Split(New String() {"<BR>"},
                StringSplitOptions.RemoveEmptyEntries)))
        End Function

        ''' <summary>
        ''' Gets a datatable which columns corresponds to the required imported data 
        ''' (propert name, data type and regionalized caption).
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetDataTableSpecification() As DataTable
            Return Utilities.GetDataTableSpecification(GetType(ImportedPerson),
                New String() {"NotUniqueCode", "AlreadyPresent"})
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format("{0} ({1}), {2}", _Name, _Code, _Address)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Name"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Code"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Address"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Bank"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("BankAccount"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("CodeVAT"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Email"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("ContactInfo"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("InternalCode"))
            ValidationRules.AddRule(AddressOf CommonValidation.AccountFieldValidation, _
                New Csla.Validation.RuleArgs("AccountAgainstBankBuyer"))
            ValidationRules.AddRule(AddressOf CommonValidation.AccountFieldValidation, _
                New Csla.Validation.RuleArgs("AccountAgainstBankSupplyer"))
            ValidationRules.AddRule(AddressOf CommonValidation.LanguageCodeValidation, _
                New Csla.Validation.RuleArgs("LanguageCode"))
            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyFieldValidation, _
                New Csla.Validation.RuleArgs("CurrencyCode"))

            ValidationRules.AddRule(AddressOf AlreadyPresentValidation, New Validation.RuleArgs("AlreadyPresent"))
            ValidationRules.AddRule(AddressOf NotUniqueCodeValidation, New Validation.RuleArgs("NotUniqueCode"))
            ValidationRules.AddRule(AddressOf CodeSODRAValidation, New Validation.RuleArgs("CodeSODRA"))

        End Sub

        Private Shared Function AlreadyPresentValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As ImportedPerson = DirectCast(target, ImportedPerson)

            If ValObj._AlreadyPresent Then
                e.Description = My.Resources.General_Person_CodeNotUnique
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        Private Shared Function NotUniqueCodeValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As ImportedPerson = DirectCast(target, ImportedPerson)

            If ValObj._NotUniqueCode Then
                e.Description = My.Resources.General_ImportedPerson_CodeNotUniqueInList
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        Private Shared Function CodeSODRAValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As ImportedPerson = DirectCast(target, ImportedPerson)

            If StringIsNullOrEmpty(valObj._CodeSODRA) AndAlso valObj._IsWorker Then
                e.Description = My.Resources.General_Person_SodraCodeRequired
                e.Severity = Validation.RuleSeverity.Warning
                Return False
            ElseIf valObj._IsWorker AndAlso valObj._CodeSODRA.Trim.Length > Person.SodraCodeMaxLength Then
                e.Description = String.Format(My.Resources.Common_StringExceedsMaxLength, _
                    My.Resources.General_Person_CodeSODRA, Person.SodraCodeMaxLength.ToString)
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

        ''' <summary>
        ''' Get a new ImportedPerson instance by paste string.
        ''' </summary>
        ''' <param name="s">String array containing person data fields.</param>
        Friend Shared Function NewImportedPerson(ByVal s As String(), _
            ByVal AccountList As List(Of Long), ByVal PersonCodeList As List(Of String), _
            ByRef PreviousCodes As List(Of String)) As ImportedPerson
            Return New ImportedPerson(s, AccountList, PersonCodeList, PreviousCodes)
        End Function

        Friend Shared Function NewImportedPerson(ByVal dr As DataRow,
            ByVal AccountList As List(Of Long), ByVal PersonCodeList As List(Of String),
            ByRef PreviousCodes As List(Of String)) As ImportedPerson
            Return New ImportedPerson(dr, AccountList, PersonCodeList, PreviousCodes)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal s As String(), ByVal AccountList As List(Of Long), _
            ByVal PersonCodeList As List(Of String), ByRef PreviousCodes As List(Of String))
            MarkAsChild()
            Create(s, AccountList, PersonCodeList, PreviousCodes)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal AccountList As List(Of Long),
            ByVal PersonCodeList As List(Of String), ByRef PreviousCodes As List(Of String))
            MarkAsChild()
            Create(dr, AccountList, PersonCodeList, PreviousCodes)
        End Sub
#End Region

#Region " Data Access "

        Private Sub Create(ByVal s As String(), ByVal AccountList As List(Of Long), _
            ByVal PersonCodeList As List(Of String), ByRef PreviousCodes As List(Of String))

            _Name = CStrSafe(GetItem(s, 0)).Trim
            _Code = CStrSafe(GetItem(s, 1)).Trim
            _Address = CStrSafe(GetItem(s, 2)).Trim
            _Bank = CStrSafe(GetItem(s, 3)).Trim
            _BankAccount = CStrSafe(GetItem(s, 4)).Trim
            _CodeVAT = CStrSafe(GetItem(s, 5)).Trim
            _CodeSODRA = CStrSafe(GetItem(s, 6)).Trim
            _Email = CStrSafe(GetItem(s, 7)).Trim
            _ContactInfo = CStrSafe(GetItem(s, 8)).Trim
            _InternalCode = CStrSafe(GetItem(s, 9)).Trim
            _LanguageCode = CStrSafe(GetItem(s, 10)).Trim
            _CurrencyCode = CStrSafe(GetItem(s, 11)).Trim
            _IsNaturalPerson = ConvertDbBoolean(CIntSafe(GetItem(s, 12), 0))
            _IsClient = ConvertDbBoolean(CIntSafe(GetItem(s, 13), 0))
            _IsSupplier = ConvertDbBoolean(CIntSafe(GetItem(s, 14), 0))
            _IsWorker = ConvertDbBoolean(CIntSafe(GetItem(s, 15), 15))
            _IsObsolete = ConvertDbBoolean(CIntSafe(GetItem(s, 16), 0))
            _AccountAgainstBankBuyer = CLongSafe(GetItem(s, 17), 0)
            _AccountAgainstBankSupplyer = CLongSafe(GetItem(s, 18), 0)
            _CodeIsNotReal = ConvertDbBoolean(CIntSafe(GetItem(s, 19), 0))
            _StateCode = CStrSafe(GetItem(s, 20)).Trim
            If StringIsNullOrEmpty(_StateCode) Then _StateCode = StateCodeLith

            If Not AccountList.Contains(_AccountAgainstBankBuyer) Then _AccountAgainstBankBuyer = 0
            If Not AccountList.Contains(_AccountAgainstBankSupplyer) Then _AccountAgainstBankSupplyer = 0

            If Not String.IsNullOrEmpty(_Code.Trim) Then

                If PersonCodeList.Contains(_Code.Trim.ToUpper) Then
                    _AlreadyPresent = True
                Else
                    _AlreadyPresent = False
                End If

                If PreviousCodes.Contains(_Code.Trim.ToUpper) Then
                    _NotUniqueCode = True
                Else
                    _NotUniqueCode = False
                    PreviousCodes.Add(_Code.Trim.ToUpper)
                End If

            End If

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Create(ByVal dr As DataRow, ByVal AccountList As List(Of Long),
            ByVal PersonCodeList As List(Of String), ByRef PreviousCodes As List(Of String))

            _Name = dr.Item("Name").ToString
            _Code = dr.Item("Code").ToString
            _Address = dr.Item("Address").ToString
            _Bank = dr.Item("Bank").ToString
            _BankAccount = dr.Item("BankAccount").ToString
            _CodeVAT = dr.Item("CodeVAT").ToString
            _CodeSODRA = dr.Item("CodeSODRA").ToString
            _Email = dr.Item("Email").ToString
            _ContactInfo = dr.Item("ContactInfo").ToString
            _InternalCode = dr.Item("InternalCode").ToString
            _LanguageCode = dr.Item("LanguageCode").ToString
            _CurrencyCode = dr.Item("CurrencyCode").ToString
            _IsNaturalPerson = DirectCast(dr.Item("IsNaturalPerson"), Boolean)
            _IsClient = DirectCast(dr.Item("IsClient"), Boolean)
            _IsSupplier = DirectCast(dr.Item("IsSupplier"), Boolean)
            _IsWorker = DirectCast(dr.Item("IsWorker"), Boolean)
            _IsObsolete = DirectCast(dr.Item("IsObsolete"), Boolean)
            _AccountAgainstBankBuyer = DirectCast(dr.Item("AccountAgainstBankBuyer"), Long)
            _AccountAgainstBankSupplyer = DirectCast(dr.Item("AccountAgainstBankSupplyer"), Long)
            _CodeIsNotReal = DirectCast(dr.Item("CodeIsNotReal"), Boolean)
            _StateCode = dr.Item("StateCode").ToString
            If StringIsNullOrEmpty(_StateCode) Then _StateCode = StateCodeLith

            If Not AccountList.Contains(_AccountAgainstBankBuyer) Then _AccountAgainstBankBuyer = 0
            If Not AccountList.Contains(_AccountAgainstBankSupplyer) Then _AccountAgainstBankSupplyer = 0

            If Not String.IsNullOrEmpty(_Code.Trim) Then

                If PersonCodeList.Contains(_Code.Trim.ToUpper) Then
                    _AlreadyPresent = True
                Else
                    _AlreadyPresent = False
                End If

                If PreviousCodes.Contains(_Code.Trim.ToUpper) Then
                    _NotUniqueCode = True
                Else
                    _NotUniqueCode = False
                    PreviousCodes.Add(_Code.Trim.ToUpper)
                End If

            End If

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert()

            Dim p As Person = Person.NewPersonChild

            p.Name = _Name
            p.Code = _Code
            p.Address = _Address
            p.Bank = _Bank
            p.BankAccount = _BankAccount
            p.CodeVAT = _CodeVAT
            p.CodeSODRA = _CodeSODRA
            p.Email = _Email
            p.ContactInfo = _ContactInfo
            p.InternalCode = _InternalCode
            p.LanguageCode = _LanguageCode
            p.CurrencyCode = _CurrencyCode
            p.IsNaturalPerson = _IsNaturalPerson
            p.IsClient = _IsClient
            p.IsSupplier = _IsSupplier
            p.IsWorker = _IsWorker
            p.IsObsolete = _IsObsolete
            p.AccountAgainstBankBuyer = _AccountAgainstBankBuyer
            p.AccountAgainstBankSupplyer = _AccountAgainstBankSupplyer
            p.StateCode = _StateCode
            p.CodeIsNotReal = _CodeIsNotReal

            p.SaveChild()

            _AlreadyPresent = True

            MarkOld()

        End Sub

        Private Function GetItem(ByVal s As String(), ByVal index As Integer) As String
            If s Is Nothing OrElse index + 1 > s.Length Then Return ""
            Return s(index)
        End Function

#End Region

    End Class

End Namespace