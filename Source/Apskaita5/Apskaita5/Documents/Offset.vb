﻿Imports ApskaitaObjects.Attributes

Namespace Documents

    ''' <summary>
    ''' Represents an offset operation - cancelation of accounting entries with an equal but opposite entries).
    ''' </summary>
    ''' <remarks>Encapsulates a <see cref="General.JournalEntry">JournalEntry</see> of type <see cref="DocumentType.Offset">DocumentType.Offset</see>.
    ''' There is no specific database table for this object (fully encapsulated).</remarks>
    <Serializable()> _
    Public NotInheritable Class Offset
        Inherits BusinessBase(Of Offset)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _ChronologicValidator As SimpleChronologicValidator
        Private _Date As Date = Today
        Private _DocumentNumber As String = ""
        Private _Content As String = ""
        Private _SumDebit As Double = 0
        Private _SumCredit As Double = 0
        Private _BalanceItemID As Integer = 0
        Private _BalanceSum As Double = 0
        Private _BalanceAccount As Long = 0
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private WithEvents _ItemList As OffsetItemList

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _ItemListSortedList As Csla.SortedBindingList(Of OffsetItem) = Nothing


        ''' <summary>
        ''' Gets <see cref="General.JournalEntry.ID">an ID of the journal entry</see> that is created by the offset.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="IChronologicValidator">IChronologicValidator</see> object that contains business restraints on updating the offset.
        ''' </summary>
        ''' <remarks>A <see cref="SimpleChronologicValidator">SimpleChronologicValidator</see> is used to validate an offset chronological business rules.</remarks>
        Public ReadOnly Property ChronologicValidator() As SimpleChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologicValidator
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the offset was inserted into the database.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.InsertDate">journal entry InsertDate property</see>.</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the offset was last updated.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.UpdateDate">journal entry UpdateDate property</see>.</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the date of the offset.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.Date">journal entry Date property</see>.</remarks>
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
        ''' Gets or sets a number of the offset.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.DocNumber">journal entry DocNumber property</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 30)> _
        Public Property DocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _DocumentNumber.Trim <> value.Trim Then
                    _DocumentNumber = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the content (description) of the offset.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.Content">journal entry Content property</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Content.Trim <> value.Trim Then
                    _Content = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total sum of debit accounting entries within the offset.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property SumDebit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumDebit)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total sum of credit accounting entries within the offset.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property SumCredit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumCredit)
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID of the balance item. Equals 0 if none.
        ''' </summary>
        ''' <remarks>Balance item is an item that fills the difference between other offset items
        ''' in case they don't sum up to 0.
        ''' Balance item is persisted as a <see cref="OffsetItem">normal offset item</see>,
        ''' but it's <see cref="OffsetItem.Person">Person</see> property is set to null
        ''' (normal offset items are not allowed null person) 
        ''' and <see cref="OffsetItem.CurrencyCode">CurrencyCode</see> property is always set 
        ''' to the base currency.</remarks>
        Public ReadOnly Property BalanceItemID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BalanceItemID
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a balance sum.
        ''' Positive value is treated as revenue, negative value is treated as costs.
        ''' </summary>
        ''' <remarks>Balance item is an item that fills the difference between other offset items
        ''' in case they don't sum up to 0.
        ''' Balance item is persisted as a <see cref="OffsetItem">normal offset item</see>,
        ''' but it's <see cref="OffsetItem.Person">Person</see> property is set to null
        ''' (normal offset items are not allowed null person) 
        ''' and <see cref="OffsetItem.CurrencyCode">CurrencyCode</see> property is always set 
        ''' to the base currency.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public Property BalanceSum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BalanceSum)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _ChronologicValidator.FinancialDataCanChange Then Exit Property
                If CRound(_BalanceSum) <> CRound(value) Then
                    _BalanceSum = CRound(value)
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a <see cref="General.Account.ID">balance account</see>.
        ''' </summary>
        ''' <remarks>Balance item is an item that fills the difference between other offset items
        ''' in case they don't sum up to 0.
        ''' Balance item is persisted as a <see cref="OffsetItem">normal offset item</see>,
        ''' but it's <see cref="OffsetItem.Person">Person</see> property is set to null
        ''' (normal offset items are not allowed null person) 
        ''' and <see cref="OffsetItem.CurrencyCode">CurrencyCode</see> property is always set 
        ''' to the base currency.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, True, 5, 6)> _
        Public Property BalanceAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BalanceAccount
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If Not _ChronologicValidator.FinancialDataCanChange Then Exit Property
                If _BalanceAccount <> value Then
                    _BalanceAccount = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the the offset items (accounting entries).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ItemList() As OffsetItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ItemList
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable view of the the offset items (accounting entries).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ItemListSorted() As Csla.SortedBindingList(Of OffsetItem)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _ItemListSortedList Is Nothing Then _ItemListSortedList = _
                    New Csla.SortedBindingList(Of OffsetItem)(_ItemList)
                Return _ItemListSortedList
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
                Return (Not String.IsNullOrEmpty(_DocumentNumber.Trim) OrElse _ItemList.Count > 0)
            End Get
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _ItemList.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _ItemList.IsValid
            End Get
        End Property



        Public Overrides Function Save() As Offset

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Return MyBase.Save

        End Function


        Private Sub Recalculate(ByVal raisePropertyHasChanged As Boolean)

            _SumDebit = 0
            _SumCredit = 0

            For Each i As OffsetItem In _ItemList
                _SumDebit = CRound(_SumDebit + i.Debit)
                _SumCredit = CRound(_SumCredit + i.Credit)
            Next

            If CRound(_BalanceSum) > 0 Then
                _SumCredit = CRound(_SumCredit + _BalanceSum)
            ElseIf CRound(_BalanceSum) < 0 Then
                _SumDebit = CRound(_SumDebit - _BalanceSum)
            End If

            If raisePropertyHasChanged Then
                PropertyHasChanged("SumCredit")
                PropertyHasChanged("SumDebit")
            End If

        End Sub


        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            If Not _ItemList.IsValid Then result = AddWithNewLine(result, _ItemList.GetAllBrokenRules, False)
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then _
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            If _ItemList.HasWarnings() Then result = AddWithNewLine(result, _ItemList.GetAllWarnings, False)
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return (MyBase.BrokenRulesCollection.WarningCount > 0 OrElse _ItemList.HasWarnings())
        End Function


        ''' <summary>
        ''' Sets the <see cref="BalanceSum">BalanceSum</see> property to fill 
        ''' the difference between other offset items.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CalculateBalance()

            If Not _ChronologicValidator.FinancialDataCanChange Then
                Throw New Exception(String.Format(My.Resources.Common_CannotUpdateFinancialData, _
                    vbCrLf, _ChronologicValidator.FinancialDataCanChangeExplanation))
            End If

            Dim newBalanceSum As Double = _BalanceSum

            If CRound(_SumDebit) > CRound(_SumCredit) Then
                newBalanceSum = CRound(_BalanceSum + _SumDebit - _SumCredit)
            ElseIf CRound(_SumDebit) < CRound(_SumCredit) Then
                newBalanceSum = CRound(_BalanceSum - _SumCredit + _SumDebit)
            End If

            BalanceSum = newBalanceSum

        End Sub


        Private Sub ItemList_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _ItemList.ListChanged
            Recalculate(True)
        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As Offset = DirectCast(MyBase.GetClone(), Offset)
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
                RemoveHandler _ItemList.ListChanged, AddressOf ItemList_Changed
            Catch ex As Exception
            End Try
            AddHandler _ItemList.ListChanged, AddressOf ItemList_Changed
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Documents_Offset_ToString, _
                _Date.ToString("yyyy-MM-dd"), _DocumentNumber, _ID.ToString())
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("DocumentNumber"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Content"))

            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.ChronologyValidation, _
                New CommonValidation.CommonValidation.ChronologyRuleArgs("Date", "ChronologicValidator"))

            ValidationRules.AddRule(AddressOf SumDebitValidation, _
                New Validation.RuleArgs("SumDebit"))
            ValidationRules.AddRule(AddressOf BalanceAccountValidation, _
                New Validation.RuleArgs("BalanceAccount"))

            ValidationRules.AddDependantProperty("SumCredit", "SumDebit", False)
            ValidationRules.AddDependantProperty("BalanceSum", "SumDebit", False)
            ValidationRules.AddDependantProperty("BalanceSum", "BalanceAccount", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property SumDebit is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumDebitValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As Offset = DirectCast(target, Offset)

            If Not DoubleFieldValidation(target, e) Then Return False

            If CRound(valObj._SumDebit) <> CRound(valObj._SumCredit) Then
                e.Description = My.Resources.Documents_Offset_InvalidBalance
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property BalanceAccount is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function BalanceAccountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As Offset = DirectCast(target, Offset)

            If CRound(valObj._BalanceSum) = 0 Then Return True

            If Not CommonValidation.CommonValidation.AccountFieldValidation(target, e) Then Return False

            Dim accountClass As Byte = General.Account.GetAccountClass(valObj._BalanceAccount)

            If CRound(valObj._BalanceSum) > 0 AndAlso accountClass <> 5 Then

                e.Description = My.Resources.Documents_Offset_IncomeBalanceAccountExpected
                e.Severity = Validation.RuleSeverity.Warning
                Return False

            ElseIf CRound(valObj._BalanceSum) < 0 AndAlso accountClass <> 6 Then

                e.Description = My.Resources.Documents_Offset_CostsBalanceAccountExpected
                e.Severity = Validation.RuleSeverity.Warning
                Return False

            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Documents.Offset2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Offset1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Offset2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Offset3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.Offset3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new Offset instance.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function NewOffset() As Offset

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Dim result As New Offset
            result._ItemList = OffsetItemList.NewOffsetItemList
            result._ChronologicValidator = SimpleChronologicValidator.NewSimpleChronologicValidator( _
                My.Resources.Documents_Offset_TypeName, Nothing)
            result.ValidationRules.CheckRules()
            Return result

        End Function

        ''' <summary>
        ''' Gets an existing Offset instance from a database.
        ''' </summary>
        ''' <param name="nID">An ID of the Offset instance to get.</param>
        ''' <remarks></remarks>
        Public Shared Function GetOffset(ByVal nID As Integer) As Offset
            Return DataPortal.Fetch(Of Offset)(New Criteria(nID))
        End Function

        ''' <summary>
        ''' Deletes an existing Offset instance from a database.
        ''' </summary>
        ''' <param name="id">An ID of the Offset instance to delete.</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteOffset(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public Sub New(ByVal nID As Integer)
                _ID = nID
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchOffset")
            myComm.AddParam("?BD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Common_ObjectNotFound, My.Resources.Documents_Offset_TypeName, _
                    criteria.ID.ToString()))

                Dim dr As DataRow = myData.Rows(0)

                Dim actualDocumentType As DocumentType = Utilities.ConvertDatabaseCharID(Of DocumentType) _
                    (CStrSafe(dr.Item(3)).Trim)
                If actualDocumentType <> DocumentType.Offset Then Throw New Exception(String.Format( _
                    My.Resources.Common_InvalidJournalEntryDocumentType, criteria.ID.ToString(), _
                    Utilities.ConvertLocalizedName(actualDocumentType), Utilities.ConvertLocalizedName(DocumentType.Offset)))

                _ID = criteria.ID

                _Date = CDateSafe(dr.Item(0), Today)
                _DocumentNumber = CStrSafe(dr.Item(1)).Trim
                _Content = CStrSafe(dr.Item(2)).Trim
                _InsertDate = CTimeStampSafe(dr.Item(4))
                _UpdateDate = CTimeStampSafe(dr.Item(5))

            End Using

            _ChronologicValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                _ID, _Date, My.Resources.Documents_Offset_TypeName, Nothing)

            Dim balanceItem As OffsetItem = Nothing

            _ItemList = OffsetItemList.GetOffsetItemList(Me, balanceItem)

            If Not balanceItem Is Nothing AndAlso balanceItem.ID > 0 Then
                _BalanceItemID = balanceItem.ID
                If balanceItem.Type = BookEntryType.Debetas Then
                    _BalanceSum = -balanceItem.Sum
                Else
                    _BalanceSum = balanceItem.Sum
                End If
                _BalanceAccount = balanceItem.Account
            End If

            Recalculate(False)

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

                    entry = entry.SaveChild

                    _ID = entry.ID
                    _InsertDate = entry.InsertDate
                    _UpdateDate = entry.UpdateDate

                    Dim balanceItem As OffsetItem = OffsetItem.GetBalanceOffsetItem(0, _BalanceSum, _BalanceAccount)
                    If Not balanceItem Is Nothing Then
                        balanceItem.Insert(Me)
                        _BalanceItemID = balanceItem.ID
                    End If

                    ItemList.Update(Me)

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

            _ChronologicValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                _ID, _ChronologicValidator.CurrentOperationDate, _
                My.Resources.Documents_Offset_TypeName, Nothing)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim entry As General.JournalEntry = GetJournalEntry()

            Using transaction As New SqlTransaction

                Try

                    entry = entry.SaveChild
                    _UpdateDate = entry.UpdateDate

                    If _ChronologicValidator.FinancialDataCanChange Then

                        Dim balanceItem As OffsetItem = OffsetItem.GetBalanceOffsetItem( _
                            _BalanceItemID, _BalanceSum, _BalanceAccount)
                        If Not balanceItem Is Nothing Then
                            If (CRound(BalanceSum) = 0 OrElse Not BalanceAccount > 0) AndAlso _BalanceItemID > 0 Then
                                balanceItem.DeleteSelf()
                            ElseIf _BalanceItemID > 0 Then
                                balanceItem.Update(Me)
                            Else
                                balanceItem.Insert(Me)
                            End If
                        End If

                    End If

                    ItemList.Update(Me)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted(DirectCast(criteria, Criteria).ID, DocumentType.Offset)

            Dim myComm As New SQLCommand("DeleteAllOffsetItems")
            myComm.AddParam("?CD", DirectCast(criteria, Criteria).ID)

            Using transaction As New SqlTransaction

                Try

                    myComm.Execute()

                    General.JournalEntry.DeleteJournalEntryChild(DirectCast(criteria, Criteria).ID)

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
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.Offset)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_ID, DocumentType.Offset)
                If result.UpdateDate <> _UpdateDate Then Throw New Exception( _
                    My.Resources.Common_UpdateDateHasChanged)
            End If

            result.Content = _Content
            result.Date = _Date
            result.DocNumber = _DocumentNumber

            If _ChronologicValidator.FinancialDataCanChange Then

                Dim fullBookEntryList As BookEntryInternalList = _ItemList.GetBookEntryList()

                If CRound(_BalanceSum) > 0 AndAlso _BalanceAccount > 0 Then
                    fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, _BalanceAccount, CRound(_BalanceSum), Nothing))
                ElseIf CRound(_BalanceSum) < 0 AndAlso _BalanceAccount > 0 Then
                    fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, _BalanceAccount, CRound(-_BalanceSum), Nothing))
                End If

                fullBookEntryList.Aggregate()

                result.DebetList.Clear()
                result.CreditList.Clear()

                result.DebetList.LoadBookEntryListFromInternalList(fullBookEntryList, False, False)
                result.CreditList.LoadBookEntryListFromInternalList(fullBookEntryList, False, False)

            End If

            If Not result.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_FailedToCreateJournalEntry, _
                    vbCrLf, result.ToString, vbCrLf, result.GetAllBrokenRules))
            End If

            Return result

        End Function

#End Region

    End Class

End Namespace