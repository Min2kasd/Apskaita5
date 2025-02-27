﻿Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.Documents.BankDataExchangeProviders

Namespace Documents

    <Serializable()> _
    Public NotInheritable Class BankOperationItemList
        Inherits BusinessListBase(Of BankOperationItemList, BankOperationItem)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Private _Account As CashAccountInfo = Nothing
        Private _Bank As PersonInfo = Nothing
        Private _SourceType As String = ""
        Private _Description As String = ""
        Private _BalanceStart As Double = 0
        Private _BalanceEnd As Double = 0
        Private _Income As Double = 0
        Private _Spendings As Double = 0
        Private _DateStart As Date = Today
        Private _DateEnd As Date = Today


        ''' <summary>
        ''' The bank account which the data is imported to.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Account() As CashAccountInfo
            Get
                Return _Account
            End Get
        End Property

        ''' <summary>
        ''' The bank that is administering the account.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Bank() As PersonInfo
            Get
                Return _Bank
            End Get
        End Property

        ''' <summary>
        ''' The source of the data.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SourceType() As String
            Get
                Return _SourceType
            End Get
        End Property

        ''' <summary>
        ''' The bank account balance at the begining of the data period (as specified in the imported data).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property BalanceStart() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BalanceStart)
            End Get
        End Property

        ''' <summary>
        ''' The bank account balance at the end of the data period (as specified in the imported data).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property BalanceEnd() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BalanceEnd)
            End Get
        End Property

        ''' <summary>
        ''' Total sum of money received within the imported data.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Income() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Income)
            End Get
        End Property

        ''' <summary>
        ''' Total sum of money transfered (spent) within the imported data.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Spendings() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Spendings)
            End Get
        End Property

        ''' <summary>
        ''' The begining of the data period (as specified in the imported data).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DateStart() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateStart
            End Get
        End Property

        ''' <summary>
        ''' The end of the data period (as specified in the imported data).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DateEnd() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateEnd
            End Get
        End Property


        ''' <summary>
        ''' Returnes TRUE if the object contains some user provided data.
        ''' </summary>
        Public ReadOnly Property IsDirtyEnough() As Boolean Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Me.Count < 1 Then Return False
                For Each i As BankOperationItem In Me
                    If Not i.ExistsInDatabase Then Return True
                Next
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid
            End Get
        End Property


        ''' <summary>
        ''' Gets a human readable (localized) description of the import source data.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetDescription() As String
            Return _Description
        End Function


        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = GetAllBrokenRulesForList(Me)
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = GetAllWarningsForList(Me)
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            For Each i As BankOperationItem In Me
                If i.BrokenRulesCollection.WarningCount > 0 Then Return True
            Next
            Return False
        End Function


        ''' <summary>
        ''' Updates data within the list with a saved bank operation data.
        ''' </summary>
        ''' <param name="savedBankOperation">A <see cref="BankOperation">BankOperation</see>
        ''' that was created using the imported data and was saved to a database.</param>
        ''' <remarks></remarks>
        Public Sub UpdateWithBankOperation(ByVal savedBankOperation As BankOperation)
            If savedBankOperation Is Nothing OrElse savedBankOperation.IsNew Then Exit Sub
            For Each i As BankOperationItem In Me
                i.IdentifyWithBankOperation(savedBankOperation, _Account)
            Next
        End Sub


        Public Overrides Function Save() As BankOperationItemList
            Return MyBase.Save()
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return False
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return BankOperation.CanAddObject
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return False
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return False
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of BankOperationItem) = Nothing

        ''' <summary>
        ''' Creates a new empty list.
        ''' </summary>
        ''' <remarks>Used to provide a default/empty binding source.</remarks>
        Public Shared Function NewBankOperationItemList() As BankOperationItemList
            Return New BankOperationItemList
        End Function

        ''' <summary>
        ''' Creates a new list of imported bank operation data using a LITAS-ESIS file.
        ''' </summary>
        ''' <param name="accountStatement">an IBankAccountStatement object containing 
        ''' bank account statement data in caninical format</param>
        ''' <param name="account">the account that the operations are ment for</param>
        ''' <param name="bankDocumentPrefix">a user defined prefix for the 
        ''' <see cref="BankOperation.DocumentNumber">DocumentNumber</see> property</param>
        ''' <param name="ignoreWrongIBAN">whether to ignore the fact, that the IBAN numbers
        ''' in the file and the account do not match</param>
        ''' <remarks></remarks>
        Public Shared Function GetBankOperationItemList(ByVal accountStatement As IBankAccountStatement, _
            ByVal account As CashAccountInfo, ByVal bankDocumentPrefix As String, _
            ByVal ignoreWrongIBAN As Boolean) As BankOperationItemList

            If accountStatement Is Nothing Then
                Throw New Exception(My.Resources.Documents_BankOperationItemList_AccountStatementNull)
            ElseIf accountStatement.Items Is Nothing OrElse accountStatement.Items.Count < 1 Then
                Throw New Exception(My.Resources.Documents_BankOperationItemList_AccountStatementWithoutOperations)
            ElseIf account Is Nothing OrElse account.IsEmpty Then
                Throw New Exception(My.Resources.Documents_BankOperationItemList_AccountNull)
            ElseIf account.Type <> CashAccountType.PseudoBankAccount AndAlso _
                account.Type <> CashAccountType.BankAccount Then
                Throw New Exception(My.Resources.Documents_BankOperationItemList_AccountInvalid)
            ElseIf accountStatement.FormatContainsAccountCurrency AndAlso _
                Not CurrenciesEquals(accountStatement.AccountCurrency, account.CurrencyCode, _
                GetCurrentCompany().BaseCurrency) Then
                Throw New Exception(String.Format(My.Resources.Documents_BankOperationItemList_InvalidCurrency, _
                    accountStatement.AccountCurrency.Trim.ToUpper, account.CurrencyCode.Trim.ToUpper))
            ElseIf Not ignoreWrongIBAN AndAlso accountStatement.FormatContainsAccountIBAN _
                AndAlso accountStatement.AccountIBAN.Trim.ToUpper _
                <> account.BankAccountNumber.Trim.ToUpper Then
                Throw New Exception(String.Format(My.Resources.Documents_BankOperationItemList_InvalidIBAN, _
                    accountStatement.AccountIBAN.Trim.ToUpper, account.BankAccountNumber.Trim.ToUpper))
            End If

            Return DataPortal.Fetch(Of BankOperationItemList)(New Criteria( _
                accountStatement, account, bankDocumentPrefix))

        End Function

        ''' <summary>
        ''' Gets a sortable view of the list.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a grid.</remarks>
        Public Function GetSortedList() As Csla.SortedBindingList(Of BankOperationItem)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of BankOperationItem)(Me)
            Return _SortedList
        End Function


        Private Sub New()
            ' require use of factory methods
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _AccountStatement As IBankAccountStatement
            Private _Account As CashAccountInfo = Nothing
            Private _BankDocumentPrefix As String = ""
            Public ReadOnly Property AccountStatement() As IBankAccountStatement
                Get
                    Return _AccountStatement
                End Get
            End Property
            Public ReadOnly Property Account() As CashAccountInfo
                Get
                    Return _Account
                End Get
            End Property
            Public ReadOnly Property BankDocumentPrefix() As String
                Get
                    Return _BankDocumentPrefix
                End Get
            End Property
            Public Sub New(ByVal nAccountStatement As IBankAccountStatement, _
                ByVal nAccount As CashAccountInfo, ByVal nBankDocumentPrefix As String)
                _AccountStatement = nAccountStatement
                _Account = nAccount
                _BankDocumentPrefix = nBankDocumentPrefix
            End Sub
        End Class


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            If criteria.AccountStatement Is Nothing Then
                Throw New Exception(My.Resources.Documents_BankOperationItemList_AccountStatementNull)
            ElseIf criteria.AccountStatement.Items Is Nothing OrElse _
                criteria.AccountStatement.Items.Count < 1 Then
                Throw New Exception(My.Resources.Documents_BankOperationItemList_AccountStatementWithoutOperations)
            ElseIf criteria.Account Is Nothing OrElse criteria.Account.IsEmpty Then
                Throw New Exception(My.Resources.Documents_BankOperationItemList_AccountNull)
            ElseIf criteria.Account.Type <> CashAccountType.PseudoBankAccount AndAlso _
                criteria.Account.Type <> CashAccountType.BankAccount Then
                Throw New Exception(My.Resources.Documents_BankOperationItemList_AccountInvalid)
            ElseIf criteria.AccountStatement.FormatContainsAccountCurrency AndAlso _
                Not CurrenciesEquals(criteria.AccountStatement.AccountCurrency, _
                criteria.Account.CurrencyCode, GetCurrentCompany().BaseCurrency) Then
                Throw New Exception(String.Format(My.Resources.Documents_BankOperationItemList_InvalidCurrency, _
                    criteria.AccountStatement.AccountCurrency.Trim.ToUpper, _
                    criteria.Account.CurrencyCode.Trim.ToUpper))
            End If

            RaiseListChangedEvents = False

            _Account = criteria.Account
            _BalanceStart = criteria.AccountStatement.BalanceStart
            _BalanceEnd = criteria.AccountStatement.BalanceEnd
            _DateStart = criteria.AccountStatement.PeriodStart
            _DateEnd = criteria.AccountStatement.PeriodEnd
            _SourceType = criteria.AccountStatement.SourceType
            _Description = criteria.AccountStatement.Description

            For Each dataItem As BankAccountStatementItem In criteria.AccountStatement.Items
                Add(BankOperationItem.GetBankOperationItem(dataItem, criteria.Account, _
                    criteria.BankDocumentPrefix))
            Next

            TryFixUniqueCodes()

            If criteria.Account.ManagingPersonID > 0 Then

                Try
                    _Bank = PersonInfo.GetPersonInfoChild(criteria.Account.ManagingPersonID, True)
                Catch ex As Exception
                    ' error is not essential, not worth to interrupt the process
                End Try

            End If

            _Income = 0
            _Spendings = 0
            For Each i As BankOperationItem In Me
                i.RecognizeItem(criteria.Account, _Bank)
                If i.Inflow Then
                    _Income += i.SumInAccount
                Else
                    _Spendings += i.SumInAccount
                End If
            Next

            _Income = CRound(_Income)
            _Spendings = CRound(_Spendings)

            RaiseListChangedEvents = True

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            If Not Me.Count > 0 Then Throw New Exception(My.Resources.Documents_BankOperationItemList_ListEmpty)

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            CheckUniqueCodeConstraintsWithinList()

            For Each item As BankOperationItem In Me
                item.PrepareForInsert(_Account)
            Next

            RaiseListChangedEvents = False

            DeletedList.Clear()

            Using transaction As New SqlTransaction

                Try

                    For Each item As BankOperationItem In Me
                        item.Insert()
                    Next

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            RaiseListChangedEvents = True

        End Sub


        Private Sub TryFixUniqueCodes()

            If Not _Account.EnforceUniqueOperationID Then Exit Sub

            Dim i, j As Integer

            Dim sameUniqueCounter As Integer

            For i = 1 To Me.Count

                If StringIsNullOrEmpty(Item(i - 1).UniqueCode) Then Throw New Exception( _
                    My.Resources.Documents_BankOperationItem_UniqueCodeNotSpecified)

                ' some banks use the same unique code for the operation and the related bank fee
                ' these duplicate entries could be fixed, thus exception is thrown 
                ' only if more than two entries have the same unique code
                sameUniqueCounter = 0

                For j = i + 1 To Me.Count
                    If Item(i - 1).UniqueCode.Trim.ToUpper = Item(j - 1).UniqueCode.Trim.ToUpper Then
                        sameUniqueCounter += 1
                    End If
                Next

                If sameUniqueCounter > 1 Then
                    Throw New Exception(My.Resources.Documents_BankOperationItem_UniqueCodesInvalid)
                End If

            Next

            For i = 1 To Me.Count
                For j = i + 1 To Me.Count
                    If Item(i - 1).UniqueCode.Trim.ToUpper = Item(j - 1).UniqueCode.Trim.ToUpper Then
                        Item(i - 1).FixUniqueCodes(Item(j - 1))
                    End If
                Next
            Next

        End Sub

        Private Sub CheckUniqueCodeConstraintsWithinList()

            If Not _Account.EnforceUniqueOperationID Then Exit Sub

            Dim i, j As Integer
            Dim operationsWithoutUniqueCode As New List(Of String)
            Dim operationsWithDuplicateUniqueCode As New List(Of String)

            For i = 1 To Me.Count

                If StringIsNullOrEmpty(Me.Item(i - 1).UniqueCode) Then

                    operationsWithoutUniqueCode.Add(Me.Item(i - 1).ToString)

                Else

                    For j = i + 1 To Me.Count

                        If Me.Item(i - 1).UniqueCode.Trim.ToUpper = Me.Item(j - 1).UniqueCode.Trim.ToUpper Then
                            operationsWithDuplicateUniqueCode.Add(String.Format("{0} -> {1}", _
                                Me.Item(i - 1).ToString, Me.Item(j - 1).ToString))
                        End If

                    Next

                End If

            Next

            Dim exceptionMessage As String = ""

            If operationsWithoutUniqueCode.Count > 0 Then
                exceptionMessage = String.Format(My.Resources.Documents_BankOperationItemList_UniqueCodesMissing, _
                    vbCrLf, String.Join(vbCrLf, operationsWithoutUniqueCode.ToArray))
            End If

            If operationsWithDuplicateUniqueCode.Count > 0 Then
                exceptionMessage = AddWithNewLine(exceptionMessage, _
                    String.Format(My.Resources.Documents_BankOperationItemList_UniqueCodeDuplicates, _
                    vbCrLf, String.Join(vbCrLf, operationsWithDuplicateUniqueCode.ToArray)), False)
            End If

            If Not StringIsNullOrEmpty(exceptionMessage) Then
                Throw New Exception(exceptionMessage)
            End If

        End Sub

#End Region

    End Class

End Namespace