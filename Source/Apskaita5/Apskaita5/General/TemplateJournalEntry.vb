﻿Imports ApskaitaObjects.Attributes

Namespace General

    ''' <summary>
    ''' Represents a template for a <see cref="General.JournalEntry">single ledger operation</see> that encompasses two or more <see cref="General.TemplateBookEntry">transaction templates</see>.
    ''' </summary>
    ''' <remarks>Values are stored in the database table tipines_op.</remarks>
    <Serializable()> _
    Public NotInheritable Class TemplateJournalEntry
        Inherits BusinessBase(Of TemplateJournalEntry)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Name As String = ""
        Private _Content As String = ""
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private _DebetList As TemplateBookEntryList
        Private _CreditList As TemplateBookEntryList

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _DebetListSortedList As Csla.SortedBindingList(Of TemplateBookEntry) = Nothing
        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _CreditListSortedList As Csla.SortedBindingList(Of TemplateBookEntry) = Nothing

        ''' <summary>
        ''' Gets an ID of the TemplateJournalEntry object (assigned by DB AUTO_INCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database field tipines_op.T_ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the template data was inserted into the database.
        ''' </summary>
        ''' <remarks>Value is stored in the database field tipines_op.InsertDate.</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the template data was last updated.
        ''' </summary>
        ''' <remarks>Value is stored in the database field tipines_op.UpdateDate.</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the name of the template. Usualy it is shown in drop down controls.
        ''' </summary>
        ''' <remarks>Value is stored in the database field tipines_op.Turinys.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255, False)> _
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
        ''' Gets the template (default text) for the JournalEntry property <see cref="JournalEntry.Content">Content</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field tipines_op.Pavadinimas.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255, False)> _
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
        ''' Gets the template for JournalEntry property <see cref="JournalEntry.DebetList">DebetList</see>.
        ''' </summary>
        Public ReadOnly Property DebetList() As TemplateBookEntryList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DebetList
            End Get
        End Property

        ''' <summary>
        ''' Gets the template for JournalEntry property <see cref="JournalEntry.CreditList">CreditList</see>.
        ''' </summary>
        Public ReadOnly Property CreditList() As TemplateBookEntryList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CreditList
            End Get
        End Property

        ''' <summary>
        ''' Gets as sortable view for <see cref="DebetList">DebetList</see>.
        ''' </summary>
        Public ReadOnly Property DebetListSorted() As Csla.SortedBindingList(Of TemplateBookEntry)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _DebetListSortedList Is Nothing Then _DebetListSortedList = _
                    New Csla.SortedBindingList(Of TemplateBookEntry)(_DebetList)
                Return _DebetListSortedList
            End Get
        End Property

        ''' <summary>
        ''' Gets as sortable view for <see cref="CreditList">CreditList</see>.
        ''' </summary>
        Public ReadOnly Property CreditListSorted() As Csla.SortedBindingList(Of TemplateBookEntry)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _CreditListSortedList Is Nothing Then _CreditListSortedList = _
                    New Csla.SortedBindingList(Of TemplateBookEntry)(_CreditList)
                Return _CreditListSortedList
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
                Return (Not String.IsNullOrEmpty(_Name.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Content.Trim)) _
                    OrElse _DebetList.Count > 0 OrElse _CreditList.Count > 0
            End Get
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _DebetList.IsDirty OrElse _CreditList.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _DebetList.IsValid AndAlso _CreditList.IsValid _
                    AndAlso _DebetList.Count > 0 AndAlso _CreditList.Count > 0
            End Get
        End Property



        Public Overrides Function Save() As TemplateJournalEntry

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim result As TemplateJournalEntry = MyBase.Save
            HelperLists.TemplateJournalEntryInfoList.InvalidateCache()
            Return result

        End Function


        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules

            Dim result As String = ""

            If Not MyBase.IsValid Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error), False)
            If Not _DebetList.IsValid Then result = AddWithNewLine(result, _
                _DebetList.GetAllBrokenRules, False)
            If Not _CreditList.IsValid Then result = AddWithNewLine(result, _
                _CreditList.GetAllBrokenRules, False)

            If Not _DebetList.Count > 0 Then result = AddWithNewLine(result, _
                My.Resources.General_TemplateJournalEntry_DebitAccountsEmpty, False)
            If Not _CreditList.Count > 0 Then result = AddWithNewLine(result, _
                My.Resources.General_TemplateJournalEntry_CreditAccountsEmpty, False)

            Return result

        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If Me.BrokenRulesCollection.WarningCount > 0 Then
                result = AddWithNewLine(result, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning), False)
            End If
            If _DebetList.HasWarnings Then
                result = AddWithNewLine(result, _DebetList.GetAllWarnings, False)
            End If
            If _CreditList.HasWarnings Then
                result = AddWithNewLine(result, _CreditList.GetAllWarnings, False)
            End If
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return Me.BrokenRulesCollection.WarningCount > 0 OrElse _DebetList.HasWarnings _
                OrElse _CreditList.HasWarnings
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return _Name
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Name"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Csla.Validation.RuleArgs("Content"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("General.JournalEntryTemplate2")
        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.JournalEntryTemplate2")
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.JournalEntryTemplate1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.JournalEntryTemplate3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.JournalEntryTemplate3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets as new TemplateJournalEntry business object.
        ''' </summary>
        Public Shared Function NewTemplateJournalEntry() As TemplateJournalEntry

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Dim result As New TemplateJournalEntry

            result._DebetList = TemplateBookEntryList.NewTemplateBookEntryList(BookEntryType.Debetas)
            result._CreditList = TemplateBookEntryList.NewTemplateBookEntryList(BookEntryType.Kreditas)

            result.ValidationRules.CheckRules()

            Return result

        End Function

        ''' <summary>
        ''' Gets an existing TemplateJournalEntry business object.
        ''' </summary>
        ''' <param name="templateID"><see cref="ID">ID</see> of the TemplateJournalEntry.</param>
        Public Shared Function GetTemplateJournalEntry(ByVal templateID As Integer) As TemplateJournalEntry
            Return DataPortal.Fetch(Of TemplateJournalEntry)(New Criteria(templateID))
        End Function

        ''' <summary>
        ''' Deletes an existing TemplateJournalEntry from database.
        ''' </summary>
        ''' <param name="templateID"><see cref="ID">ID</see> of the TemplateJournalEntry to delete.</param>
        Public Shared Sub DeleteTemplateJournalEntry(ByVal templateID As Integer)
            DataPortal.Delete(New Criteria(templateID))
            HelperLists.TemplateJournalEntryInfoList.InvalidateCache()
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

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("SelectTemplateJournalEntry")
            myComm.AddParam("?BD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Throw New Exception( _
                    String.Format(My.Resources.Common_ObjectNotFound, _
                    My.Resources.General_TemplateJournalEntry_TypeName, criteria.ID))

                Dim dr As DataRow = myData.Rows(0)

                _ID = criteria.ID
                _Name = CStrSafe(dr.Item(0)).Trim
                _Content = CStrSafe(dr.Item(1)).Trim
                _InsertDate = CTimeStampSafe(dr.Item(2))
                _UpdateDate = CTimeStampSafe(dr.Item(3))

            End Using

            myComm = New SQLCommand("SelectTemplateBookEntryList")
            myComm.AddParam("?BD", criteria.ID)

            Using myData As DataTable = myComm.Fetch
                _DebetList = TemplateBookEntryList.GetTemplateBookEntryList(myData, BookEntryType.Debetas)
                _CreditList = TemplateBookEntryList.GetTemplateBookEntryList(myData, BookEntryType.Kreditas)
            End Using

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            CheckIfNameUnique()

            Dim myComm As New SQLCommand("TemplateJournalEntryInsert")
            AddWithParams(myComm)

            Using transaction As New SqlTransaction

                Try

                    myComm.Execute()

                    _ID = Convert.ToInt32(myComm.LastInsertID)

                    DebetList.Update(Me)
                    CreditList.Update(Me)

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

            CheckIfNameUnique()

            CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("TemplateJournalEntryUpdate")
            AddWithParams(myComm)
            myComm.AddParam("?BD", _ID)

            Using transaction As New SqlTransaction

                Try

                    myComm.Execute()

                    DebetList.Update(Me)
                    CreditList.Update(Me)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?PV", _Name.Trim)
            myComm.AddParam("?TR", _Content.Trim)

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

            Dim myComm As New SQLCommand("TemplateJournalEntryDelete")
            myComm.AddParam("?BD", DirectCast(criteria, Criteria).ID)

            Using transaction As New SqlTransaction

                Try

                    myComm.Execute()

                    myComm = New SQLCommand("TemplateBookEntriesDelete")
                    myComm.AddParam("?BD", DirectCast(criteria, Criteria).ID)
                    myComm.Execute()

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkNew()

        End Sub


        Private Sub CheckIfNameUnique()

            Dim myComm As New SQLCommand("TemplateJournalEntryExists")
            myComm.AddParam("?TD", _ID)
            myComm.AddParam("?NM", _Name.ToLower.Trim)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then _
                    Throw New Exception(My.Resources.General_TemplateJournalEntry_DuplicateName)
            End Using

        End Sub

        Private Sub CheckIfUpdateDateChanged()

            Dim myComm As New SQLCommand("CheckIfTemplateJournalEntryUpdateDateChanged")
            myComm.AddParam("?CD", _ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 OrElse CDateTimeSafe(myData.Rows(0).Item(0), _
                    Date.MinValue) = Date.MinValue Then

                    Throw New Exception(String.Format(My.Resources.Common_ObjectNotFound, _
                        My.Resources.General_TemplateJournalEntry_TypeName, _ID.ToString))

                End If

                If CTimeStampSafe(myData.Rows(0).Item(0)) <> _UpdateDate Then

                    Throw New Exception(My.Resources.Common_UpdateDateHasChanged)

                End If

            End Using

        End Sub

#End Region

    End Class

End Namespace