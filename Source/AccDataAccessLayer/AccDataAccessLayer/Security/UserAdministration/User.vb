﻿Imports AccDataAccessLayer.DatabaseAccess
Imports AccDataAccessLayer.Security.DatabaseTableAccess
Namespace Security.UserAdministration

    <Serializable()> _
    Public Class User
        Inherits BusinessBase(Of User)

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Name As String = ""
        Private _NameOld As String = ""
        Private _Host As String = ""
        Private _HostOld As String = ""
        Private _Password As String = ""
        Private _PasswordRepeated As String = ""
        Private _RealName As String = ""
        Private _Position As String = ""
        Private _Details As String = ""
        Private _IsAdmin As Boolean = False
        Private _WasAdmin As Boolean = False
        Private _Signature As Byte() = Nothing
        Private _Roles As RoleListForDatabaseList = Nothing
        Private _UserLevel As Integer = 0

        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

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

        Public Property Host() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Host.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Host.Trim <> value.Trim Then
                    _Host = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property NameOld() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NameOld.Trim
            End Get
        End Property

        Public ReadOnly Property HostOld() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HostOld.Trim
            End Get
        End Property

        Public Property Password() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Password.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Password.Trim <> value.Trim Then
                    _Password = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property PasswordRepeated() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PasswordRepeated.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _PasswordRepeated.Trim <> value.Trim Then
                    _PasswordRepeated = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property RealName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _RealName.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _RealName.Trim <> value.Trim Then
                    _RealName = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Position() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Position.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Position.Trim <> value.Trim Then
                    _Position = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Details() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Details.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Details.Trim <> value.Trim Then
                    _Details = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property IsAdmin() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsAdmin
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _IsAdmin <> value Then
                    _IsAdmin = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property WasAdmin() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WasAdmin
            End Get
        End Property

        Public Property Signature() As System.Drawing.Image
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ByteArrayToImage(_Signature)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As System.Drawing.Image)
                CanWriteProperty(True)
                If value Is Nothing AndAlso (_Signature Is Nothing OrElse _
                    Not _Signature.Length > 10) Then Exit Property

                If value Is Nothing Then
                    _Signature = Nothing
                    PropertyHasChanged()
                    Exit Property
                End If

                Dim valueArray As Byte() = ImageToByteArray(value)

                If _Signature Is Nothing OrElse valueArray Is Nothing OrElse _
                    Not _Signature.Equals(valueArray) Then
                    _Signature = valueArray
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property Roles() As RoleListForDatabaseList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Roles
            End Get
        End Property

        Public Property UserLevel() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UserLevel
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _UserLevel <> value Then
                    _UserLevel = value
                    PropertyHasChanged()
                End If
            End Set
        End Property


        Public Function IsDirtyEnough() As Boolean

            If Not IsNew AndAlso Not IsDirty Then Return False
            If Not IsNew AndAlso IsDirty Then Return True

            If Not String.IsNullOrEmpty(_Name.Trim) OrElse _
                Not String.IsNullOrEmpty(_RealName.Trim) OrElse _
                Not String.IsNullOrEmpty(_Position.Trim) OrElse _
                Not String.IsNullOrEmpty(_Details.Trim) OrElse _
                Not (_Signature Is Nothing OrElse _Signature.Length < 50) _
                OrElse _Roles.HasAnyRights Then Return True

            Return False

        End Function

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _Roles.IsDirty
            End Get
        End Property

        Public Overrides Function Save() As User

            If (IsNew AndAlso Not CanAddObject()) OrElse (Not IsNew AndAlso Not CanEditObject()) Then _
                Throw New Exception("Klaida. Jūsų teisių nepakanka šiam veiksmui atlikti.")

            If Not IsValid Then Throw New Exception("Klaida. Vartotojo duomenyse yra klaidų: " _
                & Me.BrokenRulesCollection.ToString)

            Return MyBase.Save()

        End Function

        Protected Overrides Function GetIdValue() As Object
            Return _Name
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.StringRequiredRuleArgs("Name", "vartotojo vardas"))
            ValidationRules.AddRule(AddressOf HostValidation, New Validation.RuleArgs("Host"))
            ValidationRules.AddRule(AddressOf PasswordValidation, New Validation.RuleArgs("Password"))
            ValidationRules.AddRule(AddressOf PasswordRepeatedValidation, _
                New Validation.RuleArgs("PasswordRepeated"))
            ValidationRules.AddDependantProperty("Password", "PasswordRepeated")

        End Sub

        ''' <summary>
        ''' Rule ensuring that host is provided, when local technology is used.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function HostValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim CurrentIdentity As AccIdentity = GetCurrentIdentity()

            If CurrentIdentity.ConnectionType = ConnectionType.Local AndAlso _
                Not CurrentIdentity.IsSqlServerFileBased AndAlso _
                Not CurrentIdentity.CannotSetGrants AndAlso _
                String.IsNullOrEmpty(DirectCast(target, User).Host.Trim) Then
                e.Description = "Nenurodytas vartotojo prisijungimo sritis (hostas)."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that password is provided for a new user.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function PasswordValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As User = DirectCast(target, User)
            Dim ErrorMessage As String = ""

            If Not IsPasswordValid(ValObj.Password, ValObj.PasswordRepeated, _
                ErrorMessage, Not ValObj.IsNew, False) Then
                e.Description = ErrorMessage
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that repeated password is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function PasswordRepeatedValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As User = DirectCast(target, User)
            Dim ErrorMessage As String = ""

            If Not IsPasswordValid(ValObj.Password, ValObj.PasswordRepeated, _
                ErrorMessage, True, True) Then
                e.Description = ErrorMessage
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function


        Public Shared Function IsPasswordValid(ByVal Pass1 As String, ByVal Pass2 As String, _
            ByRef ErrorMessage As String, ByVal EmptyPasswordValid As Boolean, _
            ByVal ValidateFailureToRepeat As Boolean) As Boolean

            If Pass1 Is Nothing Then Pass1 = ""
            If Pass2 Is Nothing Then Pass2 = ""

            If String.IsNullOrEmpty(Pass1.Trim) AndAlso Not EmptyPasswordValid Then
                ErrorMessage = "Nenurodytas slaptažodis."
                Return False
            End If

            If Not String.IsNullOrEmpty(Pass1.Trim) AndAlso Pass1.Trim <> Pass2.Trim _
                AndAlso ValidateFailureToRepeat Then
                ErrorMessage = "Pakartotinai įvestas slaptažodis nėra tapatus pirmajam."
                Return False
            End If

            If Pass1.Trim.Length < 6 AndAlso Pass1.Trim.Length > 0 Then
                ErrorMessage = "Slaptažodis turi būti mažiausiai iš 6 simbolių."
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Admin")
        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Admin")
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Admin")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Admin")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Admin")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewUser() As User
            If Not CanAddObject() Then Throw New Exception("Klaida. Jūsų teisių nepakanka šiam veiksmui atlikti.")
            Return DataPortal.Create(Of User)()
        End Function

        Public Shared Function GetUser(ByVal id As String) As User
            If Not CanGetObject() Then Throw New Exception("Klaida. Jūsų teisių nepakanka šiam veiksmui atlikti.")
            If id Is Nothing OrElse String.IsNullOrEmpty(id.Trim) Then Throw New Exception( _
                "Klaida. Nenurodytas vartotojo vardas")
            Return DataPortal.Fetch(Of User)(New Criteria(id))
        End Function

        Public Shared Sub DeleteUser(ByVal id As String)
            If Not CanDeleteObject() Then Throw New Exception("Klaida. Jūsų teisių nepakanka šiam veiksmui atlikti.")
            DataPortal.Delete(New Criteria(id))
        End Sub

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private mId As String
            Public ReadOnly Property Id() As String
                Get
                    Return mId
                End Get
            End Property
            Public Sub New(ByVal id As String)
                mId = id
            End Sub
        End Class


        Protected Overrides Sub DataPortal_Create()

            Dim DbInfoList As DatabaseInfoList = DatabaseInfoList.GetDatabaseListServerSide
            Dim RoleDbaGauge As DatabaseTableAccessRoleList = DatabaseTableAccessRoleList. _
                GetRoleDatabaseAccessListServerSide

            _Roles = RoleListForDatabaseList.NewRoleListForDatabaseList(DbInfoList, RoleDbaGauge)

            MarkNew()
            ValidationRules.CheckRules()

        End Sub


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            Dim CurrentIdentity As AccIdentity = GetCurrentIdentity()

            If criteria.Id.Trim.ToLower = CurrentIdentity.Name.Trim.ToLower Then _
                Throw New System.Security.SecurityException("Klaida. Redaguoti " _
                & "savo paties teisių neleidžiama.")
            If criteria.Id.Trim.ToLower = GetRootName().Trim.ToLower Then _
                Throw New System.Security.SecurityException("Klaida. Neleidžiama redaguoti root vartotojo teisių.")

            Dim cSqlGenerator As SqlServerSpecificMethods.ISqlGenerator = GetSqlGenerator()

            Dim FetchHostFromSystemDB As Boolean = _
                CurrentIdentity.ConnectionType = ConnectionType.Local AndAlso _
                Not cSqlGenerator.SqlServerFileBased AndAlso Not CurrentIdentity.CannotSetGrants

            Dim myComm As New SQLCommand("RawSQL", cSqlGenerator.GetFetchUserDataStatement( _
                criteria.Id, FetchHostFromSystemDB))

            Using New ChangedDatabase(CurrentIdentity.SecurityDatabase)

                Using myData As DataTable = myComm.Fetch

                    If myData Is Nothing OrElse myData.Rows.Count < 1 Then Throw New Exception( _
                        "Klaida. Vartotojas '" & criteria.Id & "' neegzistuoja.")

                    _ID = CInt(myData.Rows(0).Item(0))
                    _Name = myData.Rows(0).Item(1).ToString.Trim
                    _RealName = myData.Rows(0).Item(2).ToString.Trim
                    _Position = myData.Rows(0).Item(3).ToString.Trim
                    _Details = myData.Rows(0).Item(4).ToString.Trim
                    Try
                        _Signature = CType(myData.Rows(0).Item(5), Byte())
                    Catch ex As Exception
                        _Signature = Nothing
                    End Try
                    _UserLevel = CInt(myData.Rows(0).Item(6))
                    If CurrentIdentity.ConnectionType <> ConnectionType.Local AndAlso _
                        Not cSqlGenerator.SqlServerFileBased Then
                        _Host = CurrentIdentity.GetSqlHostOnRemoteServer
                    ElseIf FetchHostFromSystemDB Then
                        Try
                            _Host = myData.Rows(0).Item(7).ToString.Replace("""", ""). _
                                Replace("'", "").Replace("`", "")
                        Catch ex As Exception
                            Throw New Exception("Klaida. Nepavyko nustatyti vartotojo host'o.", ex)
                        End Try
                    Else
                        _Host = ""
                    End If

                    _NameOld = _Name
                    _HostOld = _Host

                End Using

                myComm = New SQLCommand("RawSQL", cSqlGenerator.GetFetchUserRolesStatement(criteria.Id))

                Using myData As DataTable = myComm.Fetch

                    Dim DbInfoList As DatabaseInfoList = DatabaseInfoList.GetDatabaseListServerSide
                    Dim RoleDbaGauge As DatabaseTableAccessRoleList = DatabaseTableAccessRoleList. _
                        GetRoleDatabaseAccessListServerSide

                    For Each dr As DataRow In myData.Rows
                        If dr.Item(1).ToString.Trim.ToLower = Name_AdminRole.Trim.ToLower Then
                            _IsAdmin = True
                            _WasAdmin = True
                            Exit For
                        End If
                    Next

                    _Roles = RoleListForDatabaseList.GetRoleListForDatabaseList(DbInfoList, myData, RoleDbaGauge)

                End Using

            End Using

            MarkOld()
            ValidationRules.CheckRules()

        End Sub

        Protected Overrides Sub DataPortal_Insert()

            Dim CurrentIdentity As AccIdentity = GetCurrentIdentity()
            Dim cSqlGenerator As SqlServerSpecificMethods.ISqlGenerator = GetSqlGenerator()
            CheckIfUserNameUnique(CurrentIdentity, cSqlGenerator)

            Dim ErrorString As String = ""
            If Not IsPasswordValid(_Password, _PasswordRepeated, ErrorString, False, True) Then _
                Throw New Exception("Klaida. " & ErrorString)

            Dim cHost As String
            If CurrentIdentity.ConnectionType = ConnectionType.Local Then
                cHost = _Host.Trim
            ElseIf CurrentIdentity.IsSecuritySystemInternal Then
                cHost = ""
            Else
                cHost = CurrentIdentity.GetSqlHostOnRemoteServer
            End If

            Dim RoleToSqlGauge As DatabaseTableAccessRoleList = _
                DatabaseTableAccessRoleList.GetRoleDatabaseAccessListServerSide
            Dim DbInfoList As DatabaseInfoList = DatabaseInfoList.GetDatabaseListServerSide

            Using ChangedDb As New ChangedDatabase(CurrentIdentity.SecurityDatabase)

                ' UPDATE GENERAL DATA: NAME, HOST, ETC.
                Using transaction As New SqlTransaction

                    Try

                        Dim myComm As New SQLCommand("RawSQL", cSqlGenerator.GetInsertUserStatement(Me))

                        myComm.AddParam("?NM", _Name)
                        myComm.AddParam("?RN", _RealName)
                        myComm.AddParam("?SG", _Signature, GetType(Byte()))
                        myComm.AddParam("?UP", _Position)
                        myComm.AddParam("?UD", _Details)
                        myComm.AddParam("?LV", _UserLevel)
                        If _Password Is Nothing Then _Password = ""
                        myComm.AddParam("?PS", HashPasswordSha256(_Password.Trim))

                        myComm.Execute()

                        _ID = Convert.ToInt32(myComm.LastInsertID)
                        _NameOld = _Name

                        If cSqlGenerator.SupportsTablePrivileges AndAlso Not CurrentIdentity.CannotSetGrants Then

                            myComm = New SQLCommand("RawSQL", cSqlGenerator.GetCreateUserStatement( _
                                _Name, cHost, _Password))

                            myComm.Execute()

                            myComm = New SQLCommand("RawSQL", cSqlGenerator.GetGrantUsageStatement( _
                                _Name, cHost))

                            If Not String.IsNullOrEmpty(myComm.Sentence.Trim) Then myComm.Execute()

                        End If

                        If CurrentIdentity.ConnectionType = ConnectionType.Local Then
                            _HostOld = _Host.Trim
                        Else
                            _HostOld = ""
                            _Host = ""
                        End If

                        If _IsAdmin Then

                            myComm = New SQLCommand("RawSQL", cSqlGenerator.GetInsertAdminRoleStatement( _
                                _ID, Name_AdminRole))
                            myComm.Execute()

                            DatabaseAccess.TransactionCommit()

                            _Roles = RoleListForDatabaseList.NewRoleListForDatabaseList(DbInfoList, RoleToSqlGauge)

                            Exit Sub

                        End If

                        _Roles.Update(Me, CurrentIdentity)

                        transaction.Commit()

                    Catch ex As Exception
                        transaction.SetNonSqlException(ex)
                        Throw
                    End Try

                End Using

                Using transaction As New SqlTransaction

                    Try

                        Try
                            GrantPrivileges(CurrentIdentity, cHost, RoleToSqlGauge, cSqlGenerator)
                        Catch ex As Exception
                            Try
                                DatabaseAccess.TransactionRollBack(ex)
                            Catch e As Exception
                            End Try
                            Throw ex
                        End Try

                        transaction.Commit()

                    Catch ex As Exception
                        transaction.SetNonSqlException(ex)
                        Throw New Exception("Klaida. Nepavyko nustatyti vartotojo teisių." _
                            & vbCrLf & "ATKREIPKITE DĖMESĮ, kad vartotojas buvo sėkmingai sukurtas, " _
                            & "todėl prieš redaguodami šio vartotojo duomenis juos perkraukite:" _
                            & vbCrLf & ex.Message, ex)
                    End Try

                End Using

            End Using

        End Sub

        Protected Overrides Sub DataPortal_Update()

            Dim CurrentIdentity As AccIdentity = GetCurrentIdentity()
            Dim cSqlGenerator As SqlServerSpecificMethods.ISqlGenerator = GetSqlGenerator()

            If _Name.Trim.ToLower <> _NameOld.Trim.ToLower Then _
                CheckIfUserNameUnique(CurrentIdentity, cSqlGenerator)

            Dim UpdateLogString As String = ""

            If Not IsPasswordValid(_Password, _PasswordRepeated, UpdateLogString, True, True) Then _
                Throw New Exception("Klaida. " & UpdateLogString)

            Dim cHost As String
            If CurrentIdentity.ConnectionType = ConnectionType.Local Then
                cHost = _HostOld
            ElseIf CurrentIdentity.IsSecuritySystemInternal Then
                cHost = ""
            Else
                cHost = CurrentIdentity.GetSqlHostOnRemoteServer
            End If

            Dim RoleToSqlGauge As DatabaseTableAccessRoleList = _
                DatabaseTableAccessRoleList.GetRoleDatabaseAccessListServerSide
            Dim DbInfoList As DatabaseInfoList = DatabaseInfoList.GetDatabaseListServerSide

            If _Password Is Nothing Then _Password = ""
            Dim UpdatePassword As Boolean = (Not String.IsNullOrEmpty(_Password) AndAlso _
                (cSqlGenerator.SqlServerFileBased OrElse CurrentIdentity.IsSecuritySystemInternal))

            Dim myComm As SQLCommand

            Using ChangedDb As New ChangedDatabase(CurrentIdentity.SecurityDatabase)

                ' UPDATE GENERAL DATA: NAME, HOST, ETC.
                Using transaction As New SqlTransaction

                    Try

                        myComm = New SQLCommand("RawSQL", cSqlGenerator.GetUpdateUserStatement(UpdatePassword))
                        If _Name.Trim.ToLower <> _NameOld.Trim.ToLower Then
                            myComm.AddParam("?NM", _Name)
                        Else
                            myComm.AddParam("?NM", _NameOld)
                        End If
                        myComm.AddParam("?RN", _RealName)
                        myComm.AddParam("?SG", _Signature, GetType(Byte()))
                        myComm.AddParam("?UP", _Position)
                        myComm.AddParam("?UD", _Details)
                        myComm.AddParam("?LV", _UserLevel)
                        myComm.AddParam("?UI", _ID)
                        If UpdatePassword Then myComm.AddParam("?PS", HashPasswordSha256(_Password))

                        myComm.Execute()

                        AddLogString(UpdateLogString, "Bendri vartotojo duomenys sėkmingai pakeisti.")

                        If UpdatePassword Then AddLogString(UpdateLogString, "Vartotojo slaptažodis sėkmingai pakeistas.")

                        If _Name.Trim.ToLower <> _NameOld.Trim.ToLower Then _NameOld = _Name.Trim

                        If Not cSqlGenerator.SqlServerFileBased AndAlso Not CurrentIdentity.CannotSetGrants Then

                            ' change user name and (or) host (host can only be changed for direct connection)
                            If (CurrentIdentity.ConnectionType = ConnectionType.Local AndAlso _
                                _Host.Trim.ToLower <> cHost.Trim.ToLower) OrElse _
                                _Name.Trim.ToLower <> _NameOld.Trim.ToLower Then

                                If CurrentIdentity.ConnectionType = ConnectionType.Local Then
                                    myComm = New SQLCommand("RawSQL", cSqlGenerator.GetRenameUserStatement( _
                                        _NameOld, _HostOld, _Name, _Host))
                                    _HostOld = _Host.Trim
                                Else
                                    myComm = New SQLCommand("RawSQL", cSqlGenerator.GetRenameUserStatement( _
                                        _NameOld, cHost, _Name, cHost))
                                    _HostOld = cHost.Trim
                                End If

                                myComm.Execute()

                                _NameOld = _Name.Trim

                                AddLogString(UpdateLogString, "Vartotojo duomenys SQL serverio administravimo sistemoje sėkmingai pakeisti.")

                            End If

                            If Not String.IsNullOrEmpty(_Password) Then

                                myComm = New SQLCommand("RawSQL", cSqlGenerator.GetUpdatePasswordForUserStatement( _
                                    _Name, cHost, _Password))
                                myComm.Execute()

                                AddLogString(UpdateLogString, "Vartotojo slaptažodis SQL serverio administravimo sistemoje sėkmingai pakeistas.")

                            End If

                        End If

                        transaction.Commit()

                    Catch ex As Exception
                        transaction.SetNonSqlException(ex)
                        Throw
                    End Try

                End Using

                Using transaction As New SqlTransaction

                    Try

                        RevokeAllPrivileges(CurrentIdentity, cHost, RoleToSqlGauge, cSqlGenerator)
                        GrantPrivileges(CurrentIdentity, cHost, RoleToSqlGauge, cSqlGenerator)

                        myComm = New SQLCommand("RawSQL", cSqlGenerator.GetDeleteAllRolesStatement(_ID))
                        myComm.Execute()

                        If _IsAdmin Then

                            myComm = New SQLCommand("RawSQL", cSqlGenerator.GetInsertAdminRoleStatement( _
                                _ID, Name_AdminRole))
                            myComm.Execute()

                            DatabaseAccess.TransactionCommit()

                            _Roles = RoleListForDatabaseList.NewRoleListForDatabaseList(DbInfoList, RoleToSqlGauge)

                            Exit Sub

                        End If

                        _Roles.Update(Me, CurrentIdentity)

                        transaction.Commit()

                    Catch ex As Exception
                        transaction.SetNonSqlException(ex)
                        Throw New Exception("Klaida. Nepavyko nustatyti vartotojo teisių." _
                            & vbCrLf & "ATKREIPKITE DĖMESĮ, kad vartotojo bendri duomenys buvo sėkmingai " _
                            & "pakeisti, todėl prieš redaguodami šio vartotojo duomenis juos perkraukite:" _
                            & vbCrLf & UpdateLogString & vbCrLf & ex.Message, ex)
                    End Try

                End Using

            End Using

        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_Name))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)

            Dim CurrentIdentity As AccIdentity = GetCurrentIdentity()
            Dim RoleToSqlGauge As DatabaseTableAccessRoleList = _
                DatabaseTableAccessRoleList.GetRoleDatabaseAccessListServerSide
            Dim cSqlGenerator As SqlServerSpecificMethods.ISqlGenerator = GetSqlGenerator()

            Dim UserToDelete As New User
            UserToDelete.DataPortal_Fetch(criteria)

            Dim cHost As String
            If CurrentIdentity.ConnectionType = ConnectionType.Local Then
                cHost = UserToDelete.Host.Trim
            Else
                cHost = CurrentIdentity.GetSqlHostOnRemoteServer
            End If

            Using New ChangedDatabase(CurrentIdentity.SecurityDatabase)

                Using transaction As New SqlTransaction

                    Try

                        Dim myComm As New SQLCommand("RawSQL", cSqlGenerator.GetDeleteAllRolesStatement( _
                                            UserToDelete.ID))
                        myComm.Execute()

                        myComm = New SQLCommand("RawSQL", cSqlGenerator.GetDeleteUserStatement( _
                            UserToDelete.ID))
                        myComm.Execute()

                        If cSqlGenerator.SupportsTablePrivileges AndAlso Not CurrentIdentity.CannotSetGrants Then

                            RevokeAllPrivileges(CurrentIdentity, cHost, RoleToSqlGauge, cSqlGenerator)

                            myComm = New SQLCommand("RawSQL", cSqlGenerator.GetDropUserStatement( _
                                UserToDelete.Name, cHost))
                            myComm.Execute()

                        End If

                        transaction.Commit()

                    Catch ex As Exception
                        transaction.SetNonSqlException(ex)
                        Throw
                    End Try

                End Using

            End Using

        End Sub



        Private Sub RevokeAllPrivileges(ByVal CurrentIdentity As AccIdentity, _
            ByVal UserHost As String, ByVal RoleToSqlGauge As DatabaseTableAccessRoleList, _
            ByVal cSqlGenerator As SqlServerSpecificMethods.ISqlGenerator)

            If Not cSqlGenerator.SupportsTablePrivileges OrElse CurrentIdentity.CannotSetGrants Then Exit Sub

            Dim myComm As SQLCommand

            If cSqlGenerator.TablePrivilegesAreRevokedByRevokeAllPrivileges Then
                myComm = New SQLCommand("RawSQL", cSqlGenerator.GetRevokeAllPrivilegesStatement( _
                    _Name, UserHost))
                myComm.Execute()
                Exit Sub
            End If

            ' IMPLEMENTATION OF REVOKING PRIVILEGES ONE BY ONE (JUST IN CASE)
            If _WasAdmin Then

                myComm = New SQLCommand("RawSQL", cSqlGenerator.GetRevokeAdminPrivilegesStatement( _
                    _Name, UserHost))
                myComm.Execute()
                Exit Sub

            End If

            _Roles.RevokeAllDatabasePrivileges(CurrentIdentity, Me, UserHost, RoleToSqlGauge, cSqlGenerator)

        End Sub

        Private Sub GrantPrivileges(ByVal CurrentIdentity As AccIdentity, _
            ByVal UserHost As String, ByVal RoleToSqlGauge As DatabaseTableAccessRoleList, _
            ByVal cSqlGenerator As SqlServerSpecificMethods.ISqlGenerator)

            If Not cSqlGenerator.SupportsTablePrivileges OrElse CurrentIdentity.CannotSetGrants Then Exit Sub

            Dim myComm As SQLCommand

            If _IsAdmin Then

                myComm = New SQLCommand("RawSQL", _
                    cSqlGenerator.GetGrantAdminPrivilegesStatement(_Name, UserHost))
                myComm.Execute()

                Exit Sub

            End If

            ' everybody has to have an access to security database functions (e.g. Login)
            If cSqlGenerator.SupportsStoredProcedures Then

                myComm = New SQLCommand("RawSQL", cSqlGenerator.GetGrantExecutePrivilegeForDatabase( _
                    CurrentIdentity.SecurityDatabase, _Name, UserHost))
                myComm.Execute()

            End If

            _Roles.GrantDatabasePrivileges(CurrentIdentity, Me, UserHost, RoleToSqlGauge, cSqlGenerator)

        End Sub

        Private Sub CheckIfUserNameUnique(ByVal CurrentIdentity As AccIdentity, _
            ByVal cSqlGenerator As SqlServerSpecificMethods.ISqlGenerator)

            Dim myComm As New SQLCommand("RawSQL", cSqlGenerator.GetFetchNameIsUniqueStatement())
            myComm.AddParam("?NM", _Name.Trim)
            myComm.AddParam("?NO", _NameOld.Trim)

            Using New ChangedDatabase(CurrentIdentity.SecurityDatabase)

                Using myData As DataTable = myComm.Fetch

                    If myData.Rows.Count > 0 Then Throw New Exception( _
                        "Klaida. Toks vartotojo vardas jau yra.")

                End Using

            End Using

            If cSqlGenerator.SupportsTablePrivileges AndAlso Not CurrentIdentity.CannotSetGrants Then

                myComm = New SQLCommand("RawSQL", cSqlGenerator.GetFetchNameIsUniqueInSqlServerStatement())
                myComm.AddParam("?NM", _Name.Trim)
                myComm.AddParam("?NO", _NameOld.Trim)
                Using myData As DataTable = myComm.Fetch
                    If myData.Rows.Count > 0 Then Throw New Exception( _
                        "Klaida. Toks sisteminis vartotojo vardas (administruojantis) jau yra.")
                End Using

            End If

        End Sub

        Private Sub AddLogString(ByRef LogString As String, ByVal NewLogEntry As String)
            If String.IsNullOrEmpty(LogString.Trim) Then
                LogString = NewLogEntry
            Else
                LogString = LogString & vbCrLf & NewLogEntry
            End If
        End Sub

#End Region

    End Class

End Namespace
