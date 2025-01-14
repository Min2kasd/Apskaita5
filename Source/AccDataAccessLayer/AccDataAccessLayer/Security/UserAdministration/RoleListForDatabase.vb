﻿Imports AccDataAccessLayer.Security.DatabaseTableAccess
Imports AccDataAccessLayer.DatabaseAccess
Namespace Security.UserAdministration

    <Serializable()> _
Public Class RoleListForDatabase
        Inherits BusinessBase(Of RoleListForDatabase)

#Region " Business Methods "

        Private _GID As Guid = Guid.NewGuid
        Private _DatabaseName As String = ""
        Private _CompanyName As String = ""
        Private _RoleList As RoleList

        Public ReadOnly Property DatabaseName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DatabaseName.Trim
            End Get
        End Property

        Public ReadOnly Property CompanyName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CompanyName.Trim
            End Get
        End Property

        Public ReadOnly Property RoleList() As RoleList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _RoleList
            End Get
        End Property


        Public Function HasAllRoles() As Boolean
            For Each r As Role In _RoleList
                If r.RoleLevel <> RoleAccessType.Update Then Return False
            Next
            Return True
        End Function

        Public Function HasNoRoles() As Boolean
            For Each r As Role In _RoleList
                If r.RoleLevel <> RoleAccessType.None Then Return False
            Next
            Return True
        End Function

        Public Function HadAllRoles() As Boolean
            For Each r As Role In _RoleList
                If r.RoleLevelOld <> RoleAccessType.Update Then Return False
            Next
            Return True
        End Function

        Public Function HadNoRoles() As Boolean
            For Each r As Role In _RoleList
                If r.RoleLevelOld <> RoleAccessType.None Then Return False
            Next
            Return True
        End Function

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _RoleList.IsDirty
            End Get
        End Property

        Protected Overrides Function GetIdValue() As Object
            Return _GID
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            ' TODO: add authorization rules
            'AuthorizationRules.AllowWrite("", "")
        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewDatabaseRoleList(ByVal DbInfo As DatabaseInfo, _
            ByVal RoleDbaGauge As Csla.SortedBindingList(Of DatabaseTableAccessRole)) As RoleListForDatabase
            Return New RoleListForDatabase(DbInfo, RoleDbaGauge)
        End Function

        Friend Shared Function GetDatabaseRoleList(ByVal DbInfo As DatabaseInfo, _
            ByVal RoleListDataTable As DataTable, _
            ByVal RoleDbaGauge As Csla.SortedBindingList(Of DatabaseTableAccessRole)) As RoleListForDatabase
            Return New RoleListForDatabase(DbInfo, RoleListDataTable, RoleDbaGauge)
        End Function

        Private Sub New()
            MarkAsChild()
        End Sub

        Private Sub New(ByVal DbInfo As DatabaseInfo, ByVal RoleDbaGauge As Csla.SortedBindingList(Of DatabaseTableAccessRole))
            MarkAsChild()
            Fetch(DbInfo, RoleDbaGauge)
        End Sub

        Private Sub New(ByVal DbInfo As DatabaseInfo, ByVal RoleListDataTable As DataTable, _
            ByVal RoleDbaGauge As Csla.SortedBindingList(Of DatabaseTableAccessRole))
            MarkAsChild()
            Fetch(DbInfo, RoleListDataTable, RoleDbaGauge)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal DbInfo As DatabaseInfo, ByVal RoleListDataTable As DataTable, _
            ByVal RoleDbaGauge As Csla.SortedBindingList(Of DatabaseTableAccessRole))

            _DatabaseName = DbInfo.DatabaseName
            _CompanyName = DbInfo.CompanyName
            _RoleList = UserAdministration.RoleList.GetRoleList(RoleListDataTable, _DatabaseName, RoleDbaGauge)

            MarkOld()

        End Sub

        Private Sub Fetch(ByVal DbInfo As DatabaseInfo, ByVal RoleDbaGauge As Csla.SortedBindingList(Of DatabaseTableAccessRole))

            _DatabaseName = DbInfo.DatabaseName
            _CompanyName = DbInfo.CompanyName
            _RoleList = UserAdministration.RoleList.NewRoleList(RoleDbaGauge)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As User, ByVal CurrentIdentity As AccIdentity)
            _RoleList.Update(parent, _DatabaseName, CurrentIdentity)
            MarkOld()
        End Sub

        Friend Sub RevokeDatabasePrivileges(ByVal CurrentIdentity As AccIdentity, _
            ByVal UserOfRole As User, ByVal UserHost As String, _
            ByVal RoleToSqlGauge As DatabaseTableAccessRoleList, _
            ByVal cSqlGenerator As SqlServerSpecificMethods.ISqlGenerator)

            If Not cSqlGenerator.SupportsTablePrivileges OrElse _
                cSqlGenerator.TablePrivilegesAreRevokedByRevokeAllPrivileges Then Exit Sub

            If HadNoRoles() Then Exit Sub ' no privilieges -> nothing to revoke

            Dim myComm As SQLCommand

            ' all roles on database means no separate privileges to tables
            If HadAllRoles() Then

                myComm = New SQLCommand("RawSQL", cSqlGenerator. _
                    GetRevokeAllPrivilegesForDatabase(_DatabaseName, _
                    UserOfRole.Name, UserHost))

                Try
                    myComm.Execute()
                    Exit Sub
                Catch ex As Exception
                    ' ignore exceptions when revoking, 
                    ' unsuccesfull revoking of a single privilege is not substantial
                End Try

                Exit Sub

            End If

            ' make aggregated list for old privileges on tables
            Dim GrantDictionary As New Dictionary(Of String, RoleAccessType)
            For Each r As Role In _RoleList
                For Each g As DatabaseTableAccessRole In RoleToSqlGauge
                    If r.RoleName.Trim.ToLower = g.RoleName.Trim.ToLower Then
                        r.AddWithPrivilege(g, GrantDictionary, True)
                        Exit For
                    End If
                Next
            Next

            For Each p As KeyValuePair(Of String, RoleAccessType) In GrantDictionary
                myComm = New SQLCommand("RawSQL", cSqlGenerator.GetRevokePrivilege( _
                    p.Value, _DatabaseName, p.Key.Trim, UserOfRole.Name, UserHost))
                Try
                    myComm.Execute()
                Catch ex As Exception
                    ' ignore exceptions when revoking, 
                    ' unsuccesfull revoking of a single privilege is not substantial
                End Try
            Next

        End Sub

        Friend Sub GrantDatabasePrivileges(ByVal CurrentIdentity As AccIdentity, _
            ByVal UserOfRole As User, ByVal UserHost As String, _
            ByVal RoleToSqlGauge As DatabaseTableAccessRoleList, _
            ByVal cSqlGenerator As SqlServerSpecificMethods.ISqlGenerator)

            If Not cSqlGenerator.SupportsTablePrivileges Then Exit Sub

            If HasNoRoles() Then Exit Sub ' nothing to grant

            Dim myComm As SQLCommand

            ' all roles on database means no separate privileges to tables
            If HasAllRoles() Then

                myComm = New SQLCommand("RawSQL", cSqlGenerator. _
                    GetGrantAllPrivilegesForDatabase(_DatabaseName, UserOfRole.Name, UserHost))

                myComm.Execute()

                Exit Sub

            End If

            ' everybody has to have an access to DB level functions (e.g. custom round)
            If cSqlGenerator.SupportsStoredProcedures Then

                myComm = New SQLCommand("RawSQL", cSqlGenerator. _
                    GetGrantExecutePrivilegeForDatabase(_DatabaseName, UserOfRole.Name, UserHost))

                myComm.Execute()

            End If

            ' make aggregated list for privileges on tables
            Dim GrantDictionary As New Dictionary(Of String, RoleAccessType)
            For Each r As Role In _RoleList
                For Each g As DatabaseTableAccessRole In RoleToSqlGauge
                    If r.RoleName.Trim.ToLower = g.RoleName.Trim.ToLower Then
                        r.AddWithPrivilege(g, GrantDictionary)
                        Exit For
                    End If
                Next
            Next

            For Each p As KeyValuePair(Of String, RoleAccessType) In GrantDictionary
                myComm = New SQLCommand("RawSQL", cSqlGenerator.GetGrantPrivilege( _
                    p.Value, _DatabaseName, p.Key, UserOfRole.Name, UserHost))
                myComm.Execute()
            Next

        End Sub

#End Region

    End Class

End Namespace
