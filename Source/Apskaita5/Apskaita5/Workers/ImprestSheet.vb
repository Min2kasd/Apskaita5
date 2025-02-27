﻿Imports ApskaitaObjects.Attributes
Imports ApskaitaObjects.Documents.BankDataExchangeProviders
Imports ApskaitaObjects.My.Resources

Namespace Workers

    ''' <summary>
    ''' Represents imprest calculations for particular labour contracts for a particular month.
    ''' </summary>
    ''' <remarks>Encapsulates a <see cref="General.JournalEntry">JournalEntry</see> of type <see cref="DocumentType.ImprestSheet">DocumentType.ImprestSheet</see>.
    ''' Values are stored in the database table d_avansai.</remarks>
    <Serializable()> _
    Public NotInheritable Class ImprestSheet
        Inherits BusinessBase(Of ImprestSheet)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _ChronologicValidator As SheetChronologicValidator
        Private _Number As Integer = 0
        Private _Year As Integer = Today.Year
        Private _Month As Integer = Today.Month
        Private _Date As Date = Today
        Private _TotalSum As Double = 0
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private WithEvents _Items As ImprestItemList

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _ItemsSortedList As Csla.SortedBindingList(Of ImprestItem) = Nothing


        ''' <summary>
        ''' Gets <see cref="General.JournalEntry.ID">an ID of the journal entry</see> that is created by the imprest sheet.
        ''' </summary>
        ''' <remarks>Value is stored in the database table d_avansai.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="IChronologicValidator">IChronologicValidator</see> object that contains business restraints on updating the sheet.
        ''' </summary>
        ''' <remarks>A <see cref="SheetChronologicValidator">SheetChronologicValidator</see> is used to validate an imprest sheet chronological business rules.</remarks>
        Public ReadOnly Property ChronologicValidator() As IChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologicValidator
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the sheet was inserted into the database.
        ''' </summary>
        ''' <remarks>Value is stored in the database field d_avansai.InsertDate.</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the sheet was last updated.
        ''' </summary>
        ''' <remarks>Value is stored in the database field d_avansai.UpdateDate.</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the number of the sheet.
        ''' </summary>
        ''' <remarks>Value is stored in the database field d_avansai.Nr.</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False)> _
        Public Property Number() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Number
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If _Number <> value Then
                    _Number = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the year of the imprest calculations within the sheet.
        ''' </summary>
        ''' <remarks>Value is stored in the database field d_avansai.Met.</remarks>
        Public ReadOnly Property Year() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Year
            End Get
        End Property

        ''' <summary>
        ''' Gets the month of the imprest calculations within the sheet.
        ''' </summary>
        ''' <remarks>Value is stored in the database field d_avansai.Men.</remarks>
        Public ReadOnly Property Month() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Month
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the date of the sheet.
        ''' </summary>
        ''' <remarks>Value is stored in the database field d_avansai.Z_data.</remarks>
        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a collection of the imprest calculation items.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Items() As ImprestItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Items
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable collection of the imprest calculation items.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in datagridview.</remarks>
        Public ReadOnly Property ItemsSorted() As Csla.SortedBindingList(Of ImprestItem)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _ItemsSortedList Is Nothing Then _ItemsSortedList = _
                    New Csla.SortedBindingList(Of ImprestItem)(_Items)
                Return _ItemsSortedList
            End Get
        End Property

        ''' <summary>
        ''' Gets the total sum of the calculated imprest.
        ''' (<see cref="ImprestItem.PayOffSumTotal">ImprestItem.PayOffSumTotal</see>).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property TotalSum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalSum)
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
                Return _Items.GetIsDirtyEnough(Me)
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _Items.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _Items.IsValid
            End Get
        End Property


        Public Overrides Function Save() As ImprestSheet

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Return MyBase.Save

        End Function


        Private Sub Items_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _Items.ListChanged

            _TotalSum = CRound(_Items.GetTotalSum)
            PropertyHasChanged("TotalSum")

        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As ImprestSheet = DirectCast(MyBase.GetClone(), ImprestSheet)
            result.RestoreChildListsHandles()
            Return result
        End Function

        Protected Overrides Sub OnDeserialized(ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            RestoreChildListsHandles()
        End Sub

        Protected Overrides Sub UndoChangesComplete()
            MyBase.UndoChangesComplete()
            RestoreChildListsHandles()
        End Sub

        ''' <summary>
        ''' Helper method. Takes care of TaskTimeSpans loosing its handler. See GetClone method.
        ''' </summary>
        Friend Sub RestoreChildListsHandles()
            Try
                RemoveHandler _Items.ListChanged, AddressOf Items_Changed
            Catch ex As Exception
            End Try
            AddHandler _Items.ListChanged, AddressOf Items_Changed
        End Sub


        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error), False)
            If Not _Items.IsValid Then result = AddWithNewLine(result, _
                _Items.GetAllBrokenRules, False)
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If Not MyBase.BrokenRulesCollection.WarningCount > 0 Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning), False)
            If _Items.HasWarnings Then result = AddWithNewLine(result, _Items.GetAllWarnings, False)
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return (MyBase.BrokenRulesCollection.WarningCount > 0 OrElse _Items.HasWarnings)
        End Function


        Public Function ExportBankPayments() As ExportedBankPaymentList

            Dim personLookup As PersonInfoList = PersonInfoList.GetList()

            Dim result As ExportedBankPaymentList = ExportedBankPaymentList.NewExportedBankPaymentList()
            For Each item As ImprestItem In _Items
                If item.IsChecked Then
                    result.Add(ExportedBankPayment.NewExportedBankPayment(item.PersonID, _
                        item.PayOffSumTotal, String.Format(Workers_ImprestSheet_DescriptionForExportedBankPayment, 
                            _Year, _Month), personLookup))
                End If
            Next

            If result.Count < 1 Then Throw New Exception(Workers_ImprestSheet_NoWorkersInSheetToExportBankPayments)

            Return result

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Workers_ImprestSheet_ToString, _
                _Date.ToString("yyyy-MM-dd"), _Number.ToString(), _Year.ToString(), _
                _Month.ToString(), _ID.ToString())
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.IntegerFieldValidation, _
                New Csla.Validation.RuleArgs("Number"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("TotalSum"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.ChronologyValidation, _
                New CommonValidation.CommonValidation.ChronologyRuleArgs("Date", "ChronologicValidator"))
        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Workers.ImprestSheet2")
        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.ImprestSheet2")
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.ImprestSheet1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.ImprestSheet3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.ImprestSheet3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new imprest sheet.
        ''' </summary>
        ''' <param name="nYear">A year of the imprest sheet.</param>
        ''' <param name="nMonth">A month of the imprest sheet.</param>
        ''' <remarks></remarks>
        Public Shared Function NewImprestSheet(ByVal nYear As Integer, ByVal nMonth As Integer) As ImprestSheet

            Dim result As ImprestSheet = DataPortal.Create(Of ImprestSheet)(New Criteria(nYear, nMonth))
            result.MarkNew()
            Return result

        End Function

        ''' <summary>
        ''' Gets an existing imprest sheet from the database.
        ''' </summary>
        ''' <param name="nID">ID of the imprest sheet to get.</param>
        ''' <remarks></remarks>
        Public Shared Function GetImprestSheet(ByVal nID As Integer) As ImprestSheet
            Return DataPortal.Fetch(Of ImprestSheet)(New Criteria(nID))
        End Function

        ''' <summary>
        ''' Deletes an existing imprest sheet from the database.
        ''' </summary>
        ''' <param name="id">ID of the imprest sheet to delete.</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteImprestSheet(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private ReadOnly _ID As Integer
            Private ReadOnly _Year As Integer
            Private ReadOnly _Month As Integer
            Public ReadOnly Property Id() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public ReadOnly Property Year() As Integer
                Get
                    Return _Year
                End Get
            End Property
            Public ReadOnly Property Month() As Integer
                Get
                    Return _Month
                End Get
            End Property
            Public Sub New(ByVal id As Integer)
                _ID = id
                _Year = 0
                _Month = 0
            End Sub
            Public Sub New(ByVal nYear As Integer, ByVal nMonth As Integer)
                _ID = 0
                _Year = nYear
                _Month = nMonth
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            If Not criteria.Year > 0 OrElse Not criteria.Month > 0 Then Throw New Exception( _
                My.Resources.Workers_ImprestSheet_YearOrMonthNull)

            Dim myComm As New SQLCommand("FetchNewImprestSheet")
            myComm.AddParam("?DT", New Date(criteria.Year, criteria.Month, _
                Date.DaysInMonth(criteria.Year, criteria.Month)))
            myComm.AddParam("?YR", criteria.Year)
            myComm.AddParam("?MN", criteria.Month)

            Using myData As DataTable = myComm.Fetch
                _Items = ImprestItemList.NewImprestItemList(myData)
            End Using

            _Year = criteria.Year
            _Month = criteria.Month
            _Date = New Date(_Year, _Month, 15).Date

            _ChronologicValidator = SheetChronologicValidator.NewSheetChronologicValidator( _
                DocumentType.ImprestSheet, _Year, _Month)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchImprestSheetGeneralData")
            myComm.AddParam("?NR", criteria.Id)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Common_ObjectNotFound, My.Resources.Workers_ImprestSheet_TypeName, _
                    criteria.Id.ToString()))

                Dim dr As DataRow = myData.Rows(0)

                _ID = criteria.Id
                _Number = CIntSafe(dr.Item(0), 0)
                _Date = CDateSafe(dr.Item(1), Today)
                _Year = CIntSafe(dr.Item(2), 0)
                _Month = CIntSafe(dr.Item(3), 0)
                _InsertDate = CTimeStampSafe(dr.Item(4))
                _UpdateDate = CTimeStampSafe(dr.Item(5))

            End Using

            _ChronologicValidator = SheetChronologicValidator.GetSheetChronologicValidator( _
                DocumentType.ImprestSheet, _ID, _Date, _Year, _Month, Nothing)

            myComm = New SQLCommand("FetchImprestSheetDetails")
            myComm.AddParam("?NR", criteria.Id)

            Using myData As DataTable = myComm.Fetch
                _Items = ImprestItemList.GetImprestItemList(myData, _ChronologicValidator.FinancialDataCanChange)
            End Using

            _TotalSum = _Items.GetTotalSum

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

            Dim entry As General.JournalEntry = GetJournalEntry()

            Using transaction As New SqlTransaction

                Try

                    entry = entry.SaveChild()

                    _ID = entry.ID

                    Dim myComm As New SQLCommand("InsertImprestSheet")
                    AddWithParams(myComm)
                    myComm.AddParam("?YR", _Year)
                    myComm.AddParam("?MN", _Month)

                    myComm.Execute()

                    _Items.Update(Me)

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

            _ChronologicValidator = SheetChronologicValidator.GetSheetChronologicValidator( _
                DocumentType.ImprestSheet, _ID, _ChronologicValidator.CurrentOperationDate, _
                _Year, _Month, Nothing)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim entry As General.JournalEntry = GetJournalEntry()

            CheckIfUpdateDateChanged()

            Using transaction As New SqlTransaction

                Try

                    entry = entry.SaveChild()

                    Dim myComm As New SQLCommand("UpdateImprestSheet")
                    AddWithParams(myComm)

                    myComm.Execute()

                    If _ChronologicValidator.FinancialDataCanChange Then _Items.Update(Me)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AD", _ID)
            myComm.AddParam("?NR", _Number)
            myComm.AddParam("?DT", _Date)

            _UpdateDate = GetCurrentTimeStamp()
            If Me.IsNew Then _InsertDate = _UpdateDate
            myComm.AddParam("?UD", _UpdateDate.ToUniversalTime)

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            SheetChronologicValidator.CheckIfCanDelete(DocumentType.ImprestSheet, _
                DirectCast(criteria, Criteria).Id)

            IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted(DirectCast(criteria, Criteria).Id, DocumentType.ImprestSheet)

            Using transaction As New SqlTransaction

                Try

                    General.JournalEntry.DeleteJournalEntryChild(DirectCast(criteria, Criteria).Id)

                    Dim myComm As New SQLCommand("DeleteImprestSheetGeneral")
                    myComm.AddParam("?NR", DirectCast(criteria, Criteria).Id)
                    myComm.Execute()

                    myComm = New SQLCommand("DeleteImprestSheetDetails")
                    myComm.AddParam("?NR", DirectCast(criteria, Criteria).Id)
                    myComm.Execute()

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkNew()

        End Sub


        Private Function GetJournalEntry() As General.JournalEntry

            Dim result As General.JournalEntry

            If IsNew Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.ImprestSheet)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_ID, DocumentType.ImprestSheet)
            End If

            result.Content = String.Format(My.Resources.Workers_ImprestSheet_JournalEntryContent, _
                _Year.ToString, _Month.ToString)
            result.Date = _Date.Date
            result.DocNumber = String.Format(My.Resources.Workers_ImprestSheet_JournalEntryDocNumber, _
                _Number.ToString)

            _TotalSum = _Items.GetTotalSum ' just in case

            If IsNew Then
                Dim debetEntry As General.BookEntry = General.BookEntry.NewBookEntry()
                debetEntry.Amount = _TotalSum
                debetEntry.Account = GetCurrentCompany.Accounts.GetAccount( _
                    General.DefaultAccountType.WageImprestPayable)
                Dim creditEntry As General.BookEntry = General.BookEntry.NewBookEntry()
                creditEntry.Amount = _TotalSum
                creditEntry.Account = GetCurrentCompany.Accounts.GetAccount( _
                     General.DefaultAccountType.WagePayable)
                result.CreditList.Add(creditEntry)
                result.DebetList.Add(debetEntry)
            ElseIf _ChronologicValidator.FinancialDataCanChange Then
                result.DebetList(0).Amount = _TotalSum
                result.CreditList(0).Amount = _TotalSum
            End If

            If Not result.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_FailedToCreateJournalEntry, _
                    vbCrLf, result.ToString, vbCrLf, result.GetAllBrokenRules))
            End If

            Return result

        End Function

        Private Sub CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("CheckIfImprestSheetUpdateDateChanged")
            myComm.AddParam("?CD", _ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 OrElse CDateTimeSafe(myData.Rows(0).Item(0), _
                    Date.MinValue) = Date.MinValue Then

                    Throw New Exception(String.Format(My.Resources.Common_ObjectNotFound, _
                        My.Resources.Workers_ImprestSheet_TypeName, _ID.ToString))

                End If

                If CTimeStampSafe(myData.Rows(0).Item(0)) <> _UpdateDate Then

                    Throw New Exception(My.Resources.Common_UpdateDateHasChanged)

                End If

            End Using

        End Sub

#End Region

    End Class

End Namespace