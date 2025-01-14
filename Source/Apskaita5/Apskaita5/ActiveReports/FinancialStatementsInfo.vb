﻿Namespace ActiveReports

    ''' <summary>
    ''' Represents consolidated financial reports parent report, consists of 
    ''' <see cref="BalanceSheetInfoList">balance sheet</see>, 
    ''' <see cref="IncomeStatementInfoList">income statement</see> and
    ''' <see cref="AccountTurnoverInfoList">account turnover report</see>.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public NotInheritable Class FinancialStatementsInfo
        Inherits ReadOnlyBase(Of FinancialStatementsInfo)

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _FirstPeriodDateStart As Date = Today
        Private _SecondPeriodDateStart As Date = Today
        Private _SecondPeriodDateEnd As Date = Today
        Private _ClosingSummaryAccount As Long = 0
        Private _ClosingSummaryBalanceItem As String = ""
        Private _IncludeWithoutTurnover As Boolean = False
        Private _AccountTurnoverList As AccountTurnoverInfoList = Nothing
        Private _BalanceSheet As BalanceSheetInfoList = Nothing
        Private _IncomeStatement As IncomeStatementInfoList = Nothing


        ''' <summary>
        ''' First perdiod start date.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property FirstPeriodDateStart() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FirstPeriodDateStart
            End Get
        End Property

        ''' <summary>
        ''' Second perdiod start date (end of the first period).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SecondPeriodDateStart() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SecondPeriodDateStart
            End Get
        End Property

        ''' <summary>
        ''' Second perdiod end date.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SecondPeriodDateEnd() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SecondPeriodDateEnd
            End Get
        End Property

        ''' <summary>
        ''' <see cref="General.DefaultAccountType.ClosingSummary">Closing summary account.</see>
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ClosingSummaryAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ClosingSummaryAccount
            End Get
        End Property

        ''' <summary>
        ''' Balance item ("line") associated with the <see cref="General.DefaultAccountType.ClosingSummary">closing summary account.</see>
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ClosingSummaryBalanceItem() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ClosingSummaryBalanceItem.Trim
            End Get
        End Property

        ''' <summary>
        ''' Accounts turnover report.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountTurnoverList() As AccountTurnoverInfoList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountTurnoverList
            End Get
        End Property

        ''' <summary>
        ''' Balance sheet.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property BalanceSheet() As BalanceSheetInfoList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BalanceSheet
            End Get
        End Property

        ''' <summary>
        ''' Income statement.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IncomeStatement() As IncomeStatementInfoList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IncomeStatement
            End Get
        End Property

        ''' <summary>
        ''' Whether account turnover report includes accounts without turnover 
        ''' as defined by method <see cref="AccountTurnoverInfo.HasTurnover">AccountTurnoverInfo.HasTurnover</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IncludeWithoutTurnover() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IncludeWithoutTurnover
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.ActiveReports_FinancialStatementsInfo_ToString, _
                _SecondPeriodDateStart.ToString("yyyy-MM-dd"), _SecondPeriodDateEnd.ToString("yyyy-MM-dd"), _
                _FirstPeriodDateStart.ToString("yyyy-MM-dd"), _SecondPeriodDateStart.AddDays(-1).ToString("yyyy-MM-dd"))
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.FinancialStatement1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetFinancialStatementsInfo(ByVal nFirstPeriodDateStart As Date, _
            ByVal nSecondPeriodDateStart As Date, ByVal nSecondPeriodDateEnd As Date, _
            ByVal nClosingSummaryAccount As Long, ByVal nIncludeWithoutTurnover As Boolean) As FinancialStatementsInfo
            Return DataPortal.Fetch(Of FinancialStatementsInfo)(New Criteria( _
                nFirstPeriodDateStart, nSecondPeriodDateStart, nSecondPeriodDateEnd, _
                nClosingSummaryAccount, nIncludeWithoutTurnover))
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _FirstPeriodDateStart As Date = Today
            Private _SecondPeriodDateStart As Date = Today
            Private _SecondPeriodDateEnd As Date = Today
            Private _ClosingSummaryAccount As Long = 0
            Private _IncludeWithoutTurnover As Boolean = False
            Public ReadOnly Property FirstPeriodDateStart() As Date
                Get
                    Return _FirstPeriodDateStart
                End Get
            End Property
            Public ReadOnly Property SecondPeriodDateStart() As Date
                Get
                    Return _SecondPeriodDateStart
                End Get
            End Property
            Public ReadOnly Property SecondPeriodDateEnd() As Date
                Get
                    Return _SecondPeriodDateEnd
                End Get
            End Property
            Public ReadOnly Property ClosingSummaryAccount() As Long
                Get
                    Return _ClosingSummaryAccount
                End Get
            End Property
            Public ReadOnly Property IncludeWithoutTurnover() As Boolean
                Get
                    Return _IncludeWithoutTurnover
                End Get
            End Property
            Public Sub New(ByVal nFirstPeriodDateStart As Date, ByVal nSecondPeriodDateStart As Date, _
                ByVal nSecondPeriodDateEnd As Date, ByVal nClosingSummaryAccount As Long, _
                ByVal nIncludeWithoutTurnover As Boolean)
                _FirstPeriodDateStart = nFirstPeriodDateStart
                _SecondPeriodDateStart = nSecondPeriodDateStart
                _SecondPeriodDateEnd = nSecondPeriodDateEnd
                _ClosingSummaryAccount = nClosingSummaryAccount
                _IncludeWithoutTurnover = nIncludeWithoutTurnover
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim closingSummaryAccountID As Long = criteria.ClosingSummaryAccount
            If Not closingSummaryAccountID > 0 Then
                closingSummaryAccountID = GetCurrentCompany.GetDefaultAccount(General.DefaultAccountType.ClosingSummary)
            End If

            If Not criteria.FirstPeriodDateStart.Date < criteria.SecondPeriodDateStart.Date Then _
                Throw New Exception(My.Resources.ActiveReports_FinancialStatementsInfo_FirstPeriodInvalid)
            If Not criteria.SecondPeriodDateStart.Date < criteria.SecondPeriodDateEnd.Date Then _
                Throw New Exception(My.Resources.ActiveReports_FinancialStatementsInfo_SecondPeriodInvalid)
            If Not closingSummaryAccountID > 0 Then _
                Throw New Exception(My.Resources.ActiveReports_FinancialStatementsInfo_ClosingSummaryAccountNull)


            Dim myComm As New SQLCommand("FetchAccountTurnoverInfoList")
            myComm.AddParam("?DF", criteria.FirstPeriodDateStart)
            myComm.AddParam("?DT", criteria.SecondPeriodDateStart)
            myComm.AddParam("?DE", criteria.SecondPeriodDateEnd)

            Using myData As DataTable = myComm.Fetch

                _AccountTurnoverList = AccountTurnoverInfoList.GetAccountTurnoverInfoList( _
                    myData, criteria.IncludeWithoutTurnover, closingSummaryAccountID)

                _ClosingSummaryBalanceItem = _AccountTurnoverList. _
                    GetClosingSummaryBalanceItem(closingSummaryAccountID, True)

            End Using

            Dim consolidatedStructure As General.ConsolidatedReport = _
                General.ConsolidatedReport.GetConsolidatedReportChild()
            consolidatedStructure.SetValues(_AccountTurnoverList, _AccountTurnoverList. _
                GetClosingSummaryBalanceItemId(closingSummaryAccountID, True))

            _BalanceSheet = BalanceSheetInfoList.GetBalanceSheetInfoList(consolidatedStructure.GetBalanceSheetInfoList())
            _IncomeStatement = IncomeStatementInfoList.GetIncomeStatementInfoList(consolidatedStructure.GetIncomeStatementInfoList())

            'myComm = New SQLCommand("FetchFinancialStatementsBalance")
            'myComm.AddParam("?DF", criteria.SecondPeriodDateStart)
            'myComm.AddParam("?DT", criteria.SecondPeriodDateEnd)

            'Using myData As DataTable = myComm.Fetch

            '    _BalanceSheet = BalanceSheetInfoList.GetBalanceSheetInfoList(myData)
            '    ' simulate closing to achieve debit=credit
            '    _BalanceSheet.UpdateOptimizedCurrentPeriodBalance( _
            '        _AccountTurnoverList.GetCurrentPeriodClosingSum, _ClosingSummaryBalanceItem)
            '    _BalanceSheet.UpdateOptimizedFormerPeriodBalance( _
            '        _AccountTurnoverList.GetFormerPeriodClosingSum, _ClosingSummaryBalanceItem)

            '    _IncomeStatement = IncomeStatementInfoList.GetIncomeStatementInfoList(myData)
            '    ' exclude turnover of closing operations
            '    _IncomeStatement.UpdateOptimizedValues(_AccountTurnoverList)

            'End Using

            _FirstPeriodDateStart = criteria.FirstPeriodDateStart
            _SecondPeriodDateStart = criteria.SecondPeriodDateStart
            _SecondPeriodDateEnd = criteria.SecondPeriodDateEnd
            _ClosingSummaryAccount = closingSummaryAccountID
            _IncludeWithoutTurnover = criteria.IncludeWithoutTurnover

        End Sub

#End Region

    End Class

End Namespace