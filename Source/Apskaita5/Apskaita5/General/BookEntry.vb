﻿Imports ApskaitaObjects.Attributes

Namespace General

    ''' <summary>
    ''' Represents a single ledger transaction that credits or debits certain <see cref="General.Account">Account</see>.
    ''' </summary>
    ''' <remarks>Can only be used as a child object for <see cref="General.BookEntryList">BookEntryList</see>
    ''' Data is stored in database table bzdata.</remarks>
    <Serializable()> _
    Public NotInheritable Class BookEntry
        Inherits BusinessBase(Of BookEntry)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private Const PasteColumnCount As Integer = 3

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Long = 0
        Private _FinancialDataCanChange As Boolean = True
        Private _Account As Long = 0
        Private _Amount As Double = 0
        Private _Person As PersonInfo = Nothing

        ''' <summary>
        ''' Returns an ID of the transaction that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Data is stored in database field bzdata.Nr.</remarks>
        Public ReadOnly Property ID() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Returnes TRUE if the parent object allows financial changes in transaction due to business restrains.
        ''' </summary>
        ''' <remarks>Chronologic business restrains are provided by an object implementing <see cref="IChronologicValidator">IChronologicValidator</see>).</remarks>
        Public ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Represents <see cref="General.Account.ID">the number of the account</see> that is affected by the transaction.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.AccountInfoList">AccountInfoList</see> for the datasource.
        ''' Data is stored in database field bzdata.Op_saskaita.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False)> _
        Public Property Account() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value < 0 Then value = 0
                If _Account <> value Then
                    _Account = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Represents the amount of the transaction in the base currency.
        ''' </summary>
        ''' <remarks>Data is stored in database field bzdata.Op_suma.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(value) < 0 Then value = 0
                If CRound(_Amount) <> CRound(value) Then
                    _Amount = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Represents the person that is involved in the transaction.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.PersonInfoList">PersonInfoList</see> for the datasource.
        ''' Data is stored in database field bzdata.Op_ana.</remarks>
        <PersonField(ValueRequiredLevel.Optional)> _
        Public Property Person() As PersonInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Person
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As PersonInfo)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If Not (_Person Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Person Is Nothing AndAlso Not value Is Nothing AndAlso _Person = value) Then
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
            Return My.Resources.General_Account_PasteColumns.Split(New String() {"<BR>"}, _
                StringSplitOptions.RemoveEmptyEntries)
        End Function

        ''' <summary>
        ''' Gets a human readable description of expected fields sequence in (tab delimited) paste string.
        ''' </summary>
        Public Shared Function GetPasteStringColumnsDescription() As String
            Return String.Format(My.Resources.General_BookEntry_PasteColumnsDescription, PasteColumnCount, _
                String.Join(", ", My.Resources.General_BookEntry_PasteColumns.Split(New String() {"<BR>"}, _
                StringSplitOptions.RemoveEmptyEntries)))
        End Function


        Friend Function GetBookEntryCopy() As BookEntry
            Dim result As New BookEntry
            result.MarkAsChild()
            result._Account = _Account
            result._Amount = _Amount
            result._Person = _Person
            result.ValidationRules.CheckRules()
            Return result
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Dim accountPrefix As String = ""
            If Not Parent Is Nothing Then
                If DirectCast(Parent, BookEntryList).Type = BookEntryType.Debetas Then
                    accountPrefix = My.Resources.General_BookEntryList_CharForDebit
                Else
                    accountPrefix = My.Resources.General_BookEntryList_CharForCredit
                End If
            End If
            Return ToString(accountPrefix)
        End Function

        Public Overloads Function ToString(ByVal accountPrefix As String) As String
            Dim personString As String = ""
            If Not _Person Is Nothing AndAlso Not _Person.IsEmpty Then personString = _Person.ToString
            Return String.Format("{0}{1} - {2}{3} {4}", accountPrefix, _Account.ToString, _
                _Amount.ToString("##,#.00"), GetCurrentCompany.BaseCurrency, personString)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.AccountFieldValidation,
                New Csla.Validation.RuleArgs("Account"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation,
                New Csla.Validation.RuleArgs("Amount"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Get a new empty BookEntry.
        ''' </summary>
        Friend Shared Function NewBookEntry() As BookEntry
            Dim result As New BookEntry
            result.ValidationRules.CheckRules()
            Return result
        End Function

        ''' <summary>
        ''' Get a BookEntry by internal form.
        ''' </summary>
        ''' <param name="BookEntryInternalItem"></param>
        Friend Shared Function NewBookEntry(ByVal BookEntryInternalItem As BookEntryInternal) As BookEntry
            Return New BookEntry(BookEntryInternalItem, False)
        End Function

        ''' <summary>
        ''' Get a new BookEntry instance by paste string.
        ''' </summary>
        ''' <param name="pasteString">Tab delimited string containing account fields.</param>
        Friend Shared Function NewBookEntry(ByVal pasteString As String, _
            ByVal personsInfo As PersonInfoList, ByVal accountsInfo As AccountInfoList) As BookEntry
            Return New BookEntry(pasteString, personsInfo, accountsInfo)
        End Function

        ''' <summary>
        ''' Get an existing BookEntry from database.
        ''' </summary>
        ''' <param name="dr">Datarow returned by database query.</param>
        ''' <param name="nFinancialDataCanChange">Wheather parent object limits financial changes.</param>
        Friend Shared Function GetBookEntry(ByVal dr As DataRow, _
            ByVal nFinancialDataCanChange As Boolean) As BookEntry
            Return New BookEntry(dr, nFinancialDataCanChange)
        End Function

        ''' <summary>
        ''' Only for object TransferOfBalance.
        ''' </summary>
        ''' <remarks>Only for object TransferOfBalance.</remarks>
        Friend Shared Function GetBookEntry(ByVal nBookEntryInternal As BookEntryInternal, _
            ByVal MarkItemAsOld As Boolean) As BookEntry
            Return New BookEntry(nBookEntryInternal, MarkItemAsOld)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal nBookEntryInternal As BookEntryInternal, ByVal MarkItemAsOld As Boolean)
            MarkAsChild()
            Create(nBookEntryInternal, MarkItemAsOld)
        End Sub

        Private Sub New(ByVal pasteString As String, ByVal personsInfo As PersonInfoList, _
            ByVal accountsInfo As AccountInfoList)
            MarkAsChild()
            Create(pasteString, personsInfo, accountsInfo)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal nFinancialDataCanChange As Boolean)
            MarkAsChild()
            Fetch(dr, nFinancialDataCanChange)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal nBookEntryInternal As BookEntryInternal, ByVal MarkItemAsOld As Boolean)

            _Amount = nBookEntryInternal.Ammount
            _Account = nBookEntryInternal.Account
            _Person = nBookEntryInternal.Person

            If MarkItemAsOld Then MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Create(ByVal pasteString As String, ByVal personsInfo As PersonInfoList, _
            ByVal accountsInfo As AccountInfoList)

            Long.TryParse(GetField(pasteString, vbTab, 0), _Account)
            Double.TryParse(GetField(pasteString, vbTab, 1), _Amount)

            If accountsInfo.GetAccountByID(_Account) Is Nothing Then _Account = 0

            If Not personsInfo Is Nothing Then
                Dim PersonCode As String = GetField(pasteString, vbTab, 2).Trim.ToLower
                If Not StringIsNullOrEmpty(PersonCode) Then _
                    _Person = personsInfo.GetPersonInfo(PersonCode)
            End If

            ValidationRules.CheckRules()

        End Sub


        Private Sub Fetch(ByVal dr As DataRow, ByVal nFinancialDataCanChange As Boolean)

            _ID = CLongSafe(dr.Item(0), 0)
            _Account = CLongSafe(dr.Item(2), 0)
            _Amount = CDblSafe(dr.Item(3), 2, 0)
            _Person = HelperLists.PersonInfo.GetPersonInfo(dr, 4)
            _FinancialDataCanChange = nFinancialDataCanChange

            MarkOld()

        End Sub


        Friend Sub Insert(ByVal parentList As BookEntryList, ByVal parent As JournalEntry)

            Dim myComm As New SQLCommand("BookEntryInsert")
            myComm.AddParam("?AA", parent.ID)
            myComm.AddParam("?AB", Utilities.ConvertDatabaseCharID(parentList.Type))
            AddWithParamsGeneral(myComm)
            AddWithParamsFinancial(myComm)

            myComm.Execute()

            _ID = myComm.LastInsertID

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parentList As BookEntryList, ByVal parent As JournalEntry)

            Dim myComm As SQLCommand
            If parent.ChronologyValidator.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateBookEntry")
                AddWithParamsFinancial(myComm)
            Else
                myComm = New SQLCommand("UpdateBookEntryGeneral")
            End If
            myComm.AddParam("?BD", _ID)
            AddWithParamsGeneral(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteBookEntry")
            myComm.AddParam("?BD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub


        Private Sub AddWithParamsGeneral(ByRef myComm As SQLCommand)

            If Not _Person Is Nothing AndAlso _Person.ID > 0 Then
                myComm.AddParam("?AE", _Person.ID)
            Else
                myComm.AddParam("?AE", 0)
            End If

        End Sub

        Private Sub AddWithParamsFinancial(ByRef myComm As SQLCommand)

            myComm.AddParam("?AC", _Account)
            myComm.AddParam("?AD", CRound(_Amount))

        End Sub

#End Region

    End Class

End Namespace