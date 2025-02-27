﻿Namespace General

    ''' <summary>
    ''' Represents a command to close revenue and costs <see cref="General.Account">accounts</see> 
    ''' at the end of the accounting period (usualy calendar year).
    ''' </summary>
    ''' <remarks>Creates spefific type - <see cref="DocumentType.ClosingEntries">ClosingEntries</see> - 
    ''' of <see cref="General.JournalEntry">JournalEntry</see>. Does not write any data outside normal 
    ''' <see cref="General.JournalEntry">JournalEntry</see> scope.</remarks>
    <Serializable()> _
    Public NotInheritable Class ClosingEntriesCommand
        Inherits CommandBase

#Region " Authorization Rules "

        Public Shared Function CanExecuteCommand() As Boolean
            Return Csla.ApplicationContext.User.IsInRole("General.ClosingEntriesCommand3")
        End Function

#End Region

#Region " Client-side Code "

        Private mResult As Integer
        Private _Date As Date
        Private _ConsolidatedAccount As Long
        Private _CurrentProfitAccount As Long
        Private _FormerProfitAccount As Long

        ''' <summary>
        ''' Date of the closing operation (last day of the period).
        ''' </summary>
        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        ''' <summary>
        ''' Technical account used for closure. Credited by the total amount of costs nominal accounts 
        ''' and debited by the total amount of revenue nominal accounts.
        ''' </summary>
        ''' <remarks>Use <see cref="General.CompanyAccount">default company account</see>
        ''' of type <see cref="General.DefaultAccountType.ClosingSummary">ClosingSummary</see> 
        ''' as provided by <see cref="Settings.CompanyInfo.GetDefaultAccount">Settings.CompanyInfo.GetDefaultAccount</see> method.</remarks>
        Public ReadOnly Property ConsolidatedAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ConsolidatedAccount
            End Get
        End Property

        ''' <summary>
        ''' Account where the result (income/loss) for the current period is stored.
        ''' </summary>
        ''' <remarks>Use <see cref="General.CompanyAccount">default company account</see>
        ''' of type <see cref="General.DefaultAccountType.CurrentProfit">CurrentProfit</see> 
        ''' as provided by <see cref="Settings.CompanyInfo.GetDefaultAccount">Settings.CompanyInfo.GetDefaultAccount</see> method.</remarks>
        Public ReadOnly Property CurrentProfitAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentProfitAccount
            End Get
        End Property

        ''' <summary>
        ''' Account where the result (income/loss) for the previous periods is stored.
        ''' </summary>
        ''' <remarks>Use <see cref="General.CompanyAccount">default company account</see>
        ''' of type <see cref="General.DefaultAccountType.FormerProfit">FormerProfit</see> 
        ''' as provided by <see cref="Settings.CompanyInfo.GetDefaultAccount">Settings.CompanyInfo.GetDefaultAccount</see> method.</remarks>
        Public ReadOnly Property FormerProfitAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FormerProfitAccount
            End Get
        End Property

        ''' <summary>
        ''' Database ID of the closing operation in the general ledger.
        ''' </summary>
        Public ReadOnly Property Result() As Integer
            Get
                Return mResult
            End Get
        End Property


        Private Sub BeforeServer()
            ' implement code to run on client
            ' before server is called
        End Sub

        Private Sub AfterServer()
            ' implement code to run on client
            ' after server is called
        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Closes revenue and costs nominal <see cref="General.Account">accounts</see> at the end of the period
        ''' and creates a <see cref="General.JournalEntry">JournalEntry</see> of type
        ''' <see cref="DocumentType.ClosingEntries">ClosingEntries</see> in the general ledger.
        ''' </summary>
        ''' <param name="closeAtDate">Date of the closing operation (last day of the period).</param>
        ''' <param name="consolidatedAccount">Technical account used for closure. 
        ''' Credited by the total amount of costs nominal accounts 
        ''' and debited by the total amount of revenue nominal accounts. 
        ''' A <see cref="CompanyAccount">CompanyAccount</see> of type 
        ''' <see cref="DefaultAccountType.ClosingSummary">DefaultAccountType.ClosingSummary</see>
        ''' should be used as default.</param>
        ''' <param name="currentProfitAccount">Account where the result (income/loss) for the current period is stored.
        ''' A <see cref="CompanyAccount">CompanyAccount</see> of type 
        ''' <see cref="DefaultAccountType.CurrentProfit">DefaultAccountType.CurrentProfit</see>
        ''' should be used as default.</param>
        ''' <param name="formerProfitAccount">Account where the result (income/loss) for the previous periods is stored.
        ''' A <see cref="CompanyAccount">CompanyAccount</see> of type 
        ''' <see cref="DefaultAccountType.FormerProfit">DefaultAccountType.FormerProfit</see>
        ''' should be used as default.</param>
        ''' <returns><see cref="General.JournalEntry.ID">database ID of the closing operation in the general ledger</see></returns>
        ''' <remarks></remarks>
        Public Shared Function TheCommand(ByVal closeAtDate As Date, ByVal consolidatedAccount As Long, _
            ByVal currentProfitAccount As Long, ByVal formerProfitAccount As Long) As Integer

            If closeAtDate.Date <= GetCurrentCompany.LastClosingDate.Date Then
                Throw New Exception(String.Format(My.Resources.General_ClosingEntriesCommand_InvalidDate, _
                    closeAtDate.ToString("yyyy-MM-dd"), GetCurrentCompany.LastClosingDate.ToString("yyyy-MM-dd")))
            End If

            If Not consolidatedAccount > 0 Then
                Throw New Exception(My.Resources.General_ClosingEntriesCommand_ConsolidatedAccountNull)
            End If

            Dim cmd As New ClosingEntriesCommand(closeAtDate, consolidatedAccount, _
                currentProfitAccount, formerProfitAccount)

            cmd.BeforeServer()
            cmd = DataPortal.Execute(Of ClosingEntriesCommand)(cmd)
            cmd.AfterServer()

            Return cmd.Result

        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal nDate As Date, ByVal nConsolidatedAccount As Long, _
            ByVal nCurrentProfitAccount As Long, ByVal nFormerProfitAccount As Long)
            _Date = nDate.Date
            _ConsolidatedAccount = nConsolidatedAccount
            _CurrentProfitAccount = nCurrentProfitAccount
            _FormerProfitAccount = nFormerProfitAccount
        End Sub

#End Region

#Region " Server-side Code "

        Protected Overrides Sub DataPortal_Execute()

            If Not CanExecuteCommand() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            mResult = CloseEntries(_Date, _ConsolidatedAccount, _CurrentProfitAccount, _FormerProfitAccount)

        End Sub

        ''' <summary>
        ''' Closes revenue and costs nominal <see cref="General.Account">accounts</see> at the end of the period
        ''' and creates a <see cref="General.JournalEntry">JournalEntry</see> of type
        ''' <see cref="DocumentType.ClosingEntries">ClosingEntries</see> in the general ledger bypassing dataportal.
        ''' </summary>
        ''' <param name="closeAtDate">Date of the closing operation (last day of the period).</param>
        ''' <param name="consolidatedAccount">Technical account used for closure. 
        ''' Credited by the total amount of costs nominal accounts 
        ''' and debited by the total amount of revenue nominal accounts. 
        ''' A <see cref="CompanyAccount">CompanyAccount</see> of type 
        ''' <see cref="DefaultAccountType.ClosingSummary">DefaultAccountType.ClosingSummary</see>
        ''' should be used as default.</param>
        ''' <param name="currentProfitAccount">Account where the result (income/loss) for the current period is stored.
        ''' A <see cref="CompanyAccount">CompanyAccount</see> of type 
        ''' <see cref="DefaultAccountType.CurrentProfit">DefaultAccountType.CurrentProfit</see>
        ''' should be used as default.</param>
        ''' <param name="formerProfitAccount">Account where the result (income/loss) for the previous periods is stored.
        ''' A <see cref="CompanyAccount">CompanyAccount</see> of type 
        ''' <see cref="DefaultAccountType.FormerProfit">DefaultAccountType.FormerProfit</see>
        ''' should be used as default.</param>
        ''' <returns><see cref="General.JournalEntry.ID">database ID of the closing operation in the general ledger</see></returns>
        ''' <remarks></remarks>
        Friend Shared Function CloseEntries(ByVal closeAtDate As Date, ByVal consolidatedAccount As Long, _
            ByVal currentProfitAccount As Long, ByVal formerProfitAccount As Long) As Integer

            ' do validation

            If (Not GetCurrentCompany.AccountClassPrefix51 > 0 AndAlso _
                Not GetCurrentCompany.AccountClassPrefix52 > 0) OrElse _
                (Not GetCurrentCompany.AccountClassPrefix61 > 0 AndAlso _
                Not GetCurrentCompany.AccountClassPrefix62 > 0) Then
                Throw New Exception(My.Resources.General_ClosingEntriesCommand_AccountClassPrefixNull)
            End If

            If Not consolidatedAccount > 0 Then
                Throw New Exception(My.Resources.General_ClosingEntriesCommand_ConsolidatedAccountNull)
            End If

            ' create book entries

            Dim entries As BookEntryInternalList = GetClosingBookEntries(closeAtDate)

            If Not entries.Count > 0 Then Throw New Exception( _
                My.Resources.General_ClosingEntriesCommand_NoResidualAmount)

            entries.AddRange(GetBalanceBookEntries(entries, consolidatedAccount, currentProfitAccount))

            entries.AddRange(GetFormerProfitBookEntries(closeAtDate, currentProfitAccount, formerProfitAccount))

            ' create general ledger operation

            Dim newJournalEntry As JournalEntry = JournalEntry.NewJournalEntryChild(DocumentType.ClosingEntries)

            newJournalEntry.Date = closeAtDate.Date
            newJournalEntry.Content = My.Resources.General_ClosingEntriesCommand_DefaultContent
            newJournalEntry.DocNumber = My.Resources.General_ClosingEntriesCommand_DefaultNumber

            newJournalEntry.DebetList.LoadBookEntryListFromInternalList(entries, False, False)
            newJournalEntry.CreditList.LoadBookEntryListFromInternalList(entries, False, False)

            If Not newJournalEntry.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_FailedToCreateJournalEntry, _
                    vbCrLf, newJournalEntry.ToString, vbCrLf, newJournalEntry.GetAllBrokenRules))
            End If

            newJournalEntry = newJournalEntry.SaveChild()

            ' Last closing day is part of CompanyInfo object in GlobalContext
            ApskaitaObjects.Settings.CompanyInfo.LoadCompanyInfoToGlobalContext("", "")

            Return newJournalEntry.ID

        End Function

        Private Shared Function GetClosingBookEntries(ByVal closingDate As Date) As BookEntryInternalList

            Dim result As BookEntryInternalList = BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            Dim myComm As New SQLCommand("ClosingResultsSelect")
            myComm.AddParam("?DT", closingDate)
            myComm.AddParam("?AA", GetCurrentCompany.AccountClassPrefix51.ToString & GetWildcart())
            myComm.AddParam("?AB", GetCurrentCompany.AccountClassPrefix52.ToString & GetWildcart())
            myComm.AddParam("?AC", GetCurrentCompany.AccountClassPrefix61.ToString & GetWildcart())
            myComm.AddParam("?AD", GetCurrentCompany.AccountClassPrefix62.ToString & GetWildcart())

            Using myData As DataTable = myComm.Fetch

                For i As Integer = myData.Rows.Count To 1 Step -1

                    Dim accountID As Long = CLongSafe(myData.Rows(i - 1).Item(0), 0)
                    If Not accountID > 0 Then
                        Throw New Exception(My.Resources.General_ClosingEntriesCommand_InvalidFetchResult)
                    End If

                    ' entry type should be inverted, as the closing shall render the balance null
                    ' by adding an entry of an opposite type
                    Dim entryType As BookEntryType = BookEntryType.Debetas
                    If CDblSafe(myData.Rows(i - 1).Item(1), 2, 0) > CDblSafe(myData.Rows(i - 1).Item(2), 2, 0) Then
                        entryType = BookEntryType.Kreditas
                    End If

                    Dim entrySum As Double = CRound(Math.Abs(CDblSafe(myData.Rows(i - 1).Item(1), 2, 0) _
                        - CDblSafe(myData.Rows(i - 1).Item(2), 2, 0)))

                    If CRound(entrySum) > 0 Then

                        result.Add(BookEntryInternal.NewBookEntryInternal(entryType, _
                            accountID, entrySum, Nothing))

                    End If

                Next

            End Using

            Return result

        End Function

        Private Shared Function GetBalanceBookEntries(ByVal closingEntries As BookEntryInternalList, _
            ByVal consolidatedAccount As Long, ByVal currentProfitAccount As Long) As BookEntryInternalList

            Dim result As BookEntryInternalList = BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            ' consolidated account entries should be of oposite type in order to balance closing book entries
            Dim creditSum As Double = closingEntries.GetTotalSum(BookEntryType.Debetas)
            Dim debetSum As Double = closingEntries.GetTotalSum(BookEntryType.Kreditas)

            ' add balance totals
            If CRound(debetSum, 2) > 0 Then
                result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                    consolidatedAccount, debetSum, Nothing))
            End If
            If CRound(creditSum, 2) > 0 Then
                result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                    consolidatedAccount, creditSum, Nothing))
            End If

            ' add entries to move the consolidated account balance 
            ' to the current profit (loss) account (if available)
            If currentProfitAccount > 0 Then

                If CRound(debetSum) > CRound(creditSum) Then

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                        currentProfitAccount, CRound(debetSum - creditSum), Nothing))
                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                        consolidatedAccount, CRound(debetSum - creditSum), Nothing))

                ElseIf CRound(debetSum) < CRound(creditSum) Then

                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                        consolidatedAccount, CRound(creditSum - debetSum), Nothing))
                    result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                        currentProfitAccount, CRound(creditSum - debetSum), Nothing))

                End If

            End If

            Return result

        End Function

        Private Shared Function GetFormerProfitBookEntries(ByVal closingDate As Date, _
            ByVal currentProfitAccount As Long, ByVal formerProfitAccount As Long) As BookEntryInternalList

            Dim result As BookEntryInternalList = BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            If Not currentProfitAccount > 0 OrElse Not formerProfitAccount > 0 Then
                Return result
            End If

            Dim myComm As New SQLCommand("FetchCurrentProfit")
            myComm.AddParam("?DT", closingDate)
            myComm.AddParam("?AC", currentProfitAccount)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count > 0 Then

                    Dim dr As DataRow = myData.Rows(0)

                    ' if debit sum in the current profit (loss) account is greater then credit sum
                    If CDblSafe(dr.Item(0), 2, 0) > CDblSafe(dr.Item(1), 2, 0) Then

                        result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                            formerProfitAccount, CRound(CDblSafe(dr.Item(0), 2, 0) - CDblSafe(dr.Item(1), 2, 0)), Nothing))
                        result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                            currentProfitAccount, CRound(CDblSafe(dr.Item(0), 2, 0) - CDblSafe(dr.Item(1), 2, 0)), Nothing))

                        ' if credit sum in the current profit (loss) account is greater then debit sum
                    ElseIf CDblSafe(dr.Item(0), 2, 0) < CDblSafe(dr.Item(1), 2, 0) Then

                        result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                            currentProfitAccount, CRound(CDblSafe(dr.Item(1), 2, 0) - CDblSafe(dr.Item(0), 2, 0)), Nothing))
                        result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                            formerProfitAccount, CRound(CDblSafe(dr.Item(1), 2, 0) - CDblSafe(dr.Item(0), 2, 0)), Nothing))

                    End If

                End If

            End Using

            Return result

        End Function

#End Region

    End Class

End Namespace
