﻿Namespace General

    ''' <summary>
    ''' Represents a ledger <see cref="General.Account">Account</see> list for the company.
    ''' </summary>
    ''' <remarks>Exists a single instance per company.</remarks>
    <Serializable()> _
    Public NotInheritable Class AccountList
        Inherits BusinessListBase(Of AccountList, Account)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        ' used to pass default account data when the list is imported
        Private _SettingsDictionary As Dictionary(Of DefaultAccountType, Long) = Nothing


        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid
            End Get
        End Property

        Public ReadOnly Property IsSettingsDictionaryAvailable() As Boolean
            Get
                Return Not _SettingsDictionary Is Nothing AndAlso _SettingsDictionary.Count > 0
            End Get
        End Property

        ''' <summary>
        ''' Returns true if the list is dirty, i.e. changed after beeing fetched.
        ''' </summary>
        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                Return IsDirty
            End Get
        End Property


        Protected Overrides Function AddNewCore() As Object
            Dim newItem As Account = Account.NewAccount
            Me.Add(newItem)
            Return newItem
        End Function


        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            If Me.IsValid Then Return ""
            Return GetAllBrokenRulesForList(Me)
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            If Not HasWarnings() Then Return ""
            Return GetAllWarningsForList(Me)
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            For Each i As Account In Me
                If i.BrokenRulesCollection.WarningCount > 0 Then Return True
            Next
            Return False
        End Function


        ''' <summary>
        ''' Adds accounts from a text file.
        ''' </summary>
        ''' <param name="filePath">Path to the file containing account data.
        ''' Lines should be delimited by CrLf, fields should be delimited by Tab.</param>
        ''' <param name="overwrite">Whether to clear the current items.</param>
        ''' <param name="encoding">The file encoding, default is Unicode.</param>
        ''' <remarks>The method is a part of data import/export functionality
        ''' altogether with <see cref="LoadAccountListFromString">LoadAccountListFromString</see>,
        ''' <see cref="SaveToFile">SaveToFile</see> and
        ''' <see cref="SaveToString">SaveToString</see>.</remarks>
        Public Sub LoadAccountListFromFile(ByVal filePath As String, _
            ByVal overwrite As Boolean, Optional ByVal encoding As System.Text.Encoding = Nothing)

            If StringIsNullOrEmpty(filePath) Then
                Throw New ArgumentNullException("filePath", My.Resources.General_AccountList_FilePathNull)
            End If

            If Not IO.File.Exists(filePath) Then
                Throw New Exception(String.Format(My.Resources.General_AccountList_FileNotFound, filePath))
            End If

            If encoding Is Nothing Then
                encoding = System.Text.Encoding.Unicode
            End If

            Dim content As String = IO.File.ReadAllText(filePath, encoding)

            If StringIsNullOrEmpty(content) Then
                Throw New Exception(My.Resources.General_AccountList_FileContentNull)
            End If

            LoadAccountListFromString(content, overwrite)

        End Sub

        ''' <summary>
        ''' Adds accounts from a (paste) string.
        ''' </summary>
        ''' <param name="pasteString">String containing account data. 
        ''' Lines should be delimited by CrLf, fields should be delimited by Tab.</param>
        ''' <param name="overwrite">Whether to clear the current items.</param>
        ''' <remarks>The method is a part of data import/export functionality
        ''' altogether with <see cref="LoadAccountListFromFile">LoadAccountListFromFile</see>,
        ''' <see cref="SaveToFile">SaveToFile</see> and
        ''' <see cref="SaveToString">SaveToString</see>.</remarks>
        Public Sub LoadAccountListFromString(ByVal pasteString As String, ByVal overwrite As Boolean)

            If StringIsNullOrEmpty(pasteString.Trim) Then
                Throw New Exception(My.Resources.General_AccountList_ClipBoardIsEmpty)
            End If

            ' fetch AssignableCRItemList and transform it to uppercased string array for caseinsensitive validation

            Dim reportItems As AssignableCRItemList = Nothing

            Try
                reportItems = AssignableCRItemList.GetList
            Catch ex As Exception
                Throw New Exception(String.Format(My.Resources.General_AccountList_FailedToFetchAssignableCRItemList,
                    ex.Message), ex)
            End Try

            ' cannot add accounts without financial statements structure present
            If reportItems.Count < 2 Then
                Throw New Exception(My.Resources.General_AccountList_AssignableCRItemListEmpty)
            End If

            Dim codeItems As CodeInfoList = Nothing

            Try
                codeItems = CodeInfoList.GetList
            Catch ex As Exception
                Throw New Exception(String.Format(My.Resources.General_AccountList_FailedToFetchAssignableCRItemList,
                    ex.Message), ex)
            End Try

            RaiseListChangedEvents = False

            If overwrite Then Me.Clear()

            _SettingsDictionary = New Dictionary(Of DefaultAccountType, Long)

            For Each dr As String In pasteString.Split(New String() {vbCrLf},
                StringSplitOptions.RemoveEmptyEntries)

                Dim newAccount As Account = Account.NewAccount(dr, reportItems, codeItems)
                Add(newAccount)
                AddDefaultAccountsEntry(GetField(dr, vbTab, 3), newAccount.ID)

            Next

            For Each a As Account In Me
                a.ValidateChild()
            Next

            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub

        ''' <summary>
        ''' Adds accounts from a template datatable, 
        ''' see <see cref="Account.GetDataTableSpecification()">Account.GetDataTableSpecification</see> method.
        ''' </summary>
        ''' <param name="table">A template datatable containing the data.</param>
        ''' <param name="overwrite">Whether to clear the current items.</param>
        ''' <remarks></remarks>
        Public Sub LoadAccountListFromDataTable(ByVal table As DataTable, ByVal overwrite As Boolean)

            If table Is Nothing OrElse table.Rows.Count < 1 Then
                Throw New ArgumentNullException("table")
            End If

            ' fetch AssignableCRItemList and transform it to uppercased string array for caseinsensitive validation

            Dim reportItems As AssignableCRItemList = Nothing

            Try
                reportItems = AssignableCRItemList.GetList
            Catch ex As Exception
                Throw New Exception(String.Format(My.Resources.General_AccountList_FailedToFetchAssignableCRItemList,
                    ex.Message), ex)
            End Try

            ' cannot add accounts without financial statements structure present
            If reportItems.Count < 2 Then
                Throw New Exception(My.Resources.General_AccountList_AssignableCRItemListEmpty)
            End If

            Dim codeItems As CodeInfoList = Nothing

            Try
                codeItems = CodeInfoList.GetList
            Catch ex As Exception
                Throw New Exception(String.Format(My.Resources.General_AccountList_FailedToFetchAssignableCRItemList,
                    ex.Message), ex)
            End Try

            RaiseListChangedEvents = False

            If overwrite Then Me.Clear()

            _SettingsDictionary = New Dictionary(Of DefaultAccountType, Long)

            For Each dr As DataRow In table.Rows

                Dim newAccount As Account = Account.NewAccount(dr, reportItems, codeItems)
                Add(newAccount)
                AddDefaultAccountsEntry(DirectCast(dr.Item("DefaultAccountType"), String), newAccount.ID)

            Next

            For Each a As Account In Me
                a.ValidateChild()
            Next

            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub

        ''' <summary>
        ''' Writes current AccountList instance to a text file.
        ''' </summary>
        ''' <param name="filePath">path of the file to save the data to</param>
        ''' <param name="encoding">The file encoding, default is Unicode.</param>
        ''' <remarks>The method is a part of data import/export functionality
        ''' altogether with <see cref="LoadAccountListFromString">LoadAccountListFromString</see>,
        ''' <see cref="LoadAccountListFromFile">LoadAccountListFromFile</see> and
        ''' <see cref="SaveToString">SaveToString</see>.</remarks>
        Public Sub SaveToFile(ByVal filePath As String, _
            Optional ByVal encoding As System.Text.Encoding = Nothing)

            If StringIsNullOrEmpty(filePath) Then
                Throw New ArgumentNullException("filePath", My.Resources.General_AccountList_FilePathNull)
            End If

            If encoding Is Nothing Then
                encoding = System.Text.Encoding.Unicode
            End If

            IO.File.WriteAllText(filePath, SaveToString(), encoding)

        End Sub

        ''' <summary>
        ''' Converts current AccountList instance to a string.
        ''' </summary>
        ''' <remarks>The method is a part of data import/export functionality
        ''' altogether with <see cref="LoadAccountListFromString">LoadAccountListFromString</see>,
        ''' <see cref="SaveToFile">SaveToFile</see> and
        ''' <see cref="LoadAccountListFromFile">LoadAccountListFromFile</see>.</remarks>
        Public Function SaveToString() As String

            If Not Me.Count > 0 Then
                Throw New Exception(My.Resources.General_AccountList_IsEmpty)
            End If

            Dim result As New List(Of String)
            For Each a As Account In Me
                result.Add(a.ConvertToTabSeparatedString())
            Next

            Return String.Join(vbCrLf, result.ToArray())

        End Function

        Private Sub AddDefaultAccountsEntry(ByVal defaultAccountType As String, account As Long)

            If Not StringIsNullOrEmpty(defaultAccountType) AndAlso account > 0 Then

                Try
                    Dim currentType As DefaultAccountType = Utilities.ConvertDatabaseCharID(Of DefaultAccountType) _
                        (defaultAccountType)
                    If Not _SettingsDictionary.ContainsKey(currentType) Then
                        _SettingsDictionary.Add(currentType, account)
                    End If
                Catch ex As Exception
                End Try

            End If

        End Sub


        Public Overrides Function Save() As AccountList

            If Not Me.Count > 0 Then
                Throw New Exception(My.Resources.General_AccountList_IsEmpty)
            End If

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim result As AccountList = MyBase.Save()
            HelperLists.AccountInfoList.InvalidateCache()
            Return result

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.AccountList1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return False
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.AccountList3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return False
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a current account list from a database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function GetAccountList() As AccountList
            Return DataPortal.Fetch(Of AccountList)(New Criteria())
        End Function

        ''' <summary>
        ''' Gets a current account list from a database bypassing DataPortal.
        ''' </summary>
        ''' <remarks>Should only be invoked on server side.</remarks>
        Friend Shared Function GetAccountListChild() As AccountList
            Dim result As New AccountList
            result.MarkAsChild()
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        Private Sub New()
            ' require use of factory methods
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()
            End Sub
        End Class


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then
                Throw New System.Security.SecurityException(My.Resources.Common_SecuritySelectDenied)
            End If

            Dim myComm As New SQLCommand("GetAccountList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                For Each dr As DataRow In myData.Rows
                    Add(Account.GetAccount(dr))
                Next

                RaiseListChangedEvents = True

            End Using

        End Sub


        ''' <summary>
        ''' Saves the object as a child of some other object bypassing DataPortal and returns the saved instance.
        ''' </summary>
        ''' <remarks>Should only be invoked on server side.
        ''' Should only be invoked on child objects that were created or fetched using child factory methods.</remarks>
        Friend Function SaveChild() As AccountList

            If Not IsChild Then Throw New Exception(My.Resources.Common_InvalidSaveChild)

            Dim result As AccountList = Me.Clone
            result.DoUpdate()
            Return result

        End Function

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then
                Throw New System.Security.SecurityException(My.Resources.Common_SecurityUpdateDenied)
            End If

            DoUpdate()

        End Sub

        Private Sub DoUpdate()

            If Not Me.Count > 0 Then
                Throw New Exception(My.Resources.General_AccountList_IsEmpty)
            End If

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            For Each item As Account In DeletedList
                If Not item.IsNew Then item.CheckIfCanDelete()
            Next

            Dim insertDefaultAcc As Boolean = Not DefaultAccountsAlreadyExist()

            Using transaction As New SqlTransaction

                Try

                    RaiseListChangedEvents = False

                    For Each item As Account In DeletedList
                        If Not item.IsNew Then item.DeleteSelf()
                    Next
                    DeletedList.Clear()

                    For Each item As Account In Me
                        If item.IsNew Then
                            item.Insert(Me)
                        ElseIf item.IsDirty Then
                            item.Update(Me)
                        End If
                    Next

                    RaiseListChangedEvents = True

                    If insertDefaultAcc Then
                        InsertDefaultAccounts()
                    End If

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

        End Sub


        Private Function DefaultAccountsAlreadyExist() As Boolean
            Dim myComm As New SQLCommand("DefaultAccountsAlreadyExist")
            Using myData As DataTable = myComm.Fetch()
                If myData.Rows.Count > 0 Then
                    Return (CIntSafe(myData.Rows(0).Item(0), 0) > 0)
                End If
            End Using
            Return False
        End Function

        Private Sub InsertDefaultAccounts()

            If _SettingsDictionary Is Nothing OrElse Not _SettingsDictionary.Count > 0 Then
                Exit Sub
            End If

            Dim myComm As SQLCommand
            For Each k As KeyValuePair(Of DefaultAccountType, Long) In _SettingsDictionary

                myComm = New SQLCommand("InsertCompanyAccount")
                myComm.AddParam("?AA", Utilities.ConvertDatabaseID(k.Key))
                myComm.AddParam("?AB", k.Value)

                myComm.Execute()

            Next

        End Sub

#End Region

    End Class

End Namespace