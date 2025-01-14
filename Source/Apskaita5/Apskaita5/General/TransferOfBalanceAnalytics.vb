﻿Imports ApskaitaObjects.Attributes

Namespace General

    ''' <summary>
    ''' Represents a transfered <see cref="General.Account">Account</see> balance assigned to a certain person.
    ''' </summary>
    ''' <remarks>Can only be used as a child object for <see cref="General.TransferOfBalanceAnalyticsList">TransferOfBalanceAnalyticsList</see>.
    ''' Data is stored in database table bzdata.
    ''' Differs from a <see cref="General.BookEntry">BookEntry</see> as the <see cref="General.TransferOfBalanceAnalytics.Person">Person</see> property is mandatory.</remarks>
    <Serializable()> _
    Public NotInheritable Class TransferOfBalanceAnalytics
        Inherits BusinessBase(Of TransferOfBalanceAnalytics)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private Const PasteColumnCount As Integer = 4

        Private _ID As Guid = Guid.NewGuid
        Private _EntryType As BookEntryType = BookEntryType.Debetas
        Private _Account As Long = 0
        Private _Ammount As Double = 0
        Private _Person As PersonInfo = Nothing
        Private _FinancialDataCanChange As Boolean = True

        ''' <summary>
        ''' Object ID. Does not represent a database ID, as a TransferOfBalanceAnalytics instance
        ''' is not a real entity, only a derivative from <see cref="General.BookEntry">BookEntry</see>.
        ''' </summary>
        Public ReadOnly Property ID() As Guid
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Returnes TRUE if the parent <see cref="General.TransferOfBalance">TransferOfBalance</see> allows financial changes in the balance due to business restrains.
        ''' </summary>
        Public ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' <see cref="BookEntryType">Type</see> (credit/debit) of the balance.
        ''' </summary>
        Public Property EntryType() As BookEntryType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _EntryType
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As BookEntryType)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _EntryType <> value Then
                    _EntryType = value
                    PropertyHasChanged()
                    PropertyHasChanged("EntryTypeHumanReadable")
                End If
            End Set
        End Property

        ''' <summary>
        ''' <see cref="BookEntryType">Type</see> (credit/debit) of the balance human readable.
        ''' </summary>
        <LocalizedEnumField(GetType(BookEntryType), False, "")> _
        Public Property EntryTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Utilities.ConvertLocalizedName(EntryType)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value Is Nothing Then value = ""
                If _EntryType <> Utilities.ConvertLocalizedName(Of BookEntryType)(value) Then
                    _EntryType = Utilities.ConvertLocalizedName(Of BookEntryType)(value)
                    PropertyHasChanged()
                    PropertyHasChanged("EntryType")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Represents <see cref="General.Account.ID">the number of the account</see> of the balance.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.AccountInfoList">AccountInfoList</see> for the datasource.
        ''' Corresponds to the <see cref="General.BookEntry.Account">BookEntry.Account</see> property.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 2, 4)> _
        Public Property Account() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _Account <> value Then
                    _Account = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Represents the amount of the balance in the base currency.
        ''' </summary>
        ''' <remarks>Corresponds to the <see cref="General.BookEntry.Amount">BookEntry.Amount</see> property.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public Property Ammount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Ammount)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_Ammount) <> CRound(value) Then
                    _Ammount = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Represents the person whose balance is transfered.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.PersonInfoList">PersonInfoList</see> for the datasource.
        ''' Corresponds to the <see cref="General.BookEntry.Person">BookEntry.Person</see> property.</remarks>
        <PersonField(ValueRequiredLevel.Mandatory)> _
        Public Property Person() As PersonInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Person
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As PersonInfo)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If Not (_Person Is Nothing AndAlso value Is Nothing) AndAlso Not _
                    (Not _Person Is Nothing AndAlso Not value Is Nothing AndAlso _Person = value) Then
                    _Person = value
                    PropertyHasChanged()
                End If
            End Set
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
            Return PasteColumnCount
        End Function

        ''' <summary>
        ''' Gets an array of expected fields sequence in (tab delimited) paste string.
        ''' </summary>
        Public Shared Function GetPasteStringColumns() As String()
            Return My.Resources.General_TransferOfBalanceAnalytics_PasteColumns.Split( _
                New String() {"<BR>"}, StringSplitOptions.RemoveEmptyEntries)
        End Function

        ''' <summary>
        ''' Gets a human readable description of expected fields sequence in (tab delimited) paste string.
        ''' </summary>
        Public Shared Function GetPasteStringColumnsDescription() As String
            Return String.Format(My.Resources.General_TransferOfBalanceAnalytics_PasteColumnsDescription, _
                PasteColumnCount, String.Join(", ", My.Resources.General_TransferOfBalanceAnalytics_PasteColumns. _
                Split(New String() {"<BR>"}, StringSplitOptions.RemoveEmptyEntries)))
        End Function

        Public Shared Function GetDataTableSpecification() As DataTable

            Dim result As New DataTable

            Dim entryTypeColumn As New DataColumn("EntryType", GetType(String))
            entryTypeColumn.Caption = GetResourcesPropertyName(GetType(TransferOfBalanceAnalytics), "EntryType")
            result.Columns.Add(entryTypeColumn)

            Dim accountColumn As New DataColumn("Account", GetType(Long))
            accountColumn.Caption = GetResourcesPropertyName(GetType(TransferOfBalanceAnalytics), "Account")
            result.Columns.Add(accountColumn)

            Dim ammountColumn As New DataColumn("Ammount", GetType(Double))
            ammountColumn.Caption = GetResourcesPropertyName(GetType(TransferOfBalanceAnalytics), "Ammount")
            result.Columns.Add(ammountColumn)

            Dim personCodeColumn As New DataColumn("PersonCode", GetType(String))
            personCodeColumn.Caption = My.Resources.General_TransferOfBalanceAnalytics_PersonCode
            result.Columns.Add(personCodeColumn)

            Return result

        End Function



        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Dim personString As String = "-"
            If Not _Person Is Nothing AndAlso Not _Person.IsEmpty Then personString = _Person.ToString
            Return String.Format("{0} {1} = {2}, kontrahentas: {3}", EntryTypeHumanReadable, _
                _Account.ToString, _Ammount.ToString("##,#.00"), personString)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.AccountFieldValidation, _
                New Csla.Validation.RuleArgs("Account"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Ammount"))
            ValidationRules.AddRule(AddressOf CommonValidation.PersonFieldValidation, _
                New Csla.Validation.RuleArgs("Person"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Get a new empty TransferOfBalanceAnalytics.
        ''' </summary>
        Friend Shared Function NewTransferOfBalanceAnalytics() As TransferOfBalanceAnalytics
            Dim result As New TransferOfBalanceAnalytics
            result.ValidationRules.CheckRules()
            Return result
        End Function

        ''' <summary>
        ''' Get a new TransferOfBalanceAnalytics instance by paste string.
        ''' </summary>
        ''' <param name="pasteString">Tab delimited string containing balance fields.</param>
        ''' <param name="accountsInfo">a list of accounts in the database to validate imported data</param>
        ''' <param name="personsInfo">a list of persons in the database to validate imported data</param>
        Friend Shared Function NewTransferOfBalanceAnalytics(ByVal pasteString As String,
            ByVal personsInfo As PersonInfoList, ByVal accountsInfo As AccountInfoList) As TransferOfBalanceAnalytics
            Return New TransferOfBalanceAnalytics(pasteString, personsInfo, accountsInfo)
        End Function

        ''' <summary>
        ''' Get a new TransferOfBalanceAnalytics instance by a template datarow,
        ''' see <see cref="GetDataTableSpecification()">GetDataTableSpecification</see> method.
        ''' </summary>
        ''' <param name="dr">a template datarow that contains item data</param>
        ''' <param name="accountsInfo">a list of accounts in the database to validate imported data</param>
        ''' <param name="personsInfo">a list of persons in the database to validate imported data</param>
        Friend Shared Function NewTransferOfBalanceAnalytics(ByVal dr As DataRow,
            ByVal personsInfo As PersonInfoList, ByVal accountsInfo As AccountInfoList) As TransferOfBalanceAnalytics
            Return New TransferOfBalanceAnalytics(dr, personsInfo, accountsInfo)
        End Function

        ''' <summary>
        ''' Get an existing TransferOfBalanceAnalytics from database.
        ''' </summary>
        ''' <param name="bookEntryItem">Internal BookEntry representation derived from database query.</param>
        ''' <param name="nFinancialDataCanChange">Wheather parent object limits financial changes.</param>
        Friend Shared Function GetTransferOfBalanceAnalytics(ByVal bookEntryItem As BookEntryInternal, _
            ByVal nFinancialDataCanChange As Boolean) As TransferOfBalanceAnalytics
            Return New TransferOfBalanceAnalytics(bookEntryItem, nFinancialDataCanChange)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal bookEntryItem As BookEntryInternal, ByVal nFinancialDataCanChange As Boolean)
            MarkAsChild()
            Fetch(bookEntryItem, nFinancialDataCanChange)
        End Sub

        Private Sub New(ByVal pasteString As String, ByVal personsInfo As PersonInfoList, _
            ByVal accountsInfo As AccountInfoList)
            MarkAsChild()
            Create(pasteString, personsInfo, accountsInfo)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal personsInfo As PersonInfoList,
            ByVal accountsInfo As AccountInfoList)
            MarkAsChild()
            Create(dr, personsInfo, accountsInfo)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal pasteString As String, ByVal personsInfo As PersonInfoList, _
            ByVal accountsInfo As AccountInfoList)

            Try
                _EntryType = Utilities.ConvertLocalizedName(Of BookEntryType) _
                    (GetField(pasteString, vbTab, 0))
            Catch ex As Exception
                Try
                    _EntryType = Utilities.ConvertDatabaseCharID(Of BookEntryType) _
                        (GetField(pasteString, vbTab, 0))
                Catch ex2 As Exception
                    Try
                        _EntryType = DirectCast([Enum].Parse(GetType(BookEntryType), _
                            GetField(pasteString, vbTab, 0)), BookEntryType)
                    Catch ex3 As Exception
                    End Try
                End Try
            End Try

            Long.TryParse(GetField(pasteString, vbTab, 1), _Account)
            Double.TryParse(GetField(pasteString, vbTab, 2), _Ammount)

            If accountsInfo.GetAccountByID(_Account) Is Nothing Then _Account = 0

            If Not personsInfo Is Nothing Then
                Dim PersonCode As String = GetField(pasteString, vbTab, 3).Trim.ToLower
                If Not String.IsNullOrEmpty(PersonCode.Trim) Then _
                    _Person = personsInfo.GetPersonInfo(PersonCode)
            End If

            ValidationRules.CheckRules()

        End Sub

        Private Sub Create(ByVal dr As DataRow, ByVal personsInfo As PersonInfoList,
            ByVal accountsInfo As AccountInfoList)

            Try
                _EntryType = Utilities.ConvertLocalizedName(Of BookEntryType) _
                    (DirectCast(dr.Item("EntryType"), String))
            Catch ex As Exception
                Try
                    _EntryType = Utilities.ConvertDatabaseCharID(Of BookEntryType) _
                        (DirectCast(dr.Item("EntryType"), String))
                Catch ex2 As Exception
                    Try
                        _EntryType = DirectCast([Enum].Parse(GetType(BookEntryType),
                            DirectCast(dr.Item("EntryType"), String)), BookEntryType)
                    Catch ex3 As Exception
                    End Try
                End Try
            End Try
            _Account = DirectCast(dr.Item("Account"), Long)
            _Ammount = CRound(DirectCast(dr.Item("Ammount"), Double))

            If accountsInfo.GetAccountByID(_Account) Is Nothing Then _Account = 0

            If Not personsInfo Is Nothing Then
                Dim personCode As String = DirectCast(dr.Item("PersonCode"), String)
                If Not StringIsNullOrEmpty(personCode) Then _
                    _Person = personsInfo.GetPersonInfo(personCode)
            End If

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal BookEntryItem As BookEntryInternal, ByVal nFinancialDataCanChange As Boolean)

            _Ammount = BookEntryItem.Ammount
            _EntryType = BookEntryItem.EntryType
            _Account = BookEntryItem.Account
            _Person = BookEntryItem.Person
            _FinancialDataCanChange = nFinancialDataCanChange

            MarkOld()

        End Sub

#End Region

    End Class

End Namespace