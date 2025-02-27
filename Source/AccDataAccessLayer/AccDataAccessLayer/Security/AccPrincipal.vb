﻿Imports System.Security.Principal

Namespace Security

    <Serializable()> _
    Public Class AccPrincipal
        Inherits Csla.Security.BusinessPrincipalBase

        Private Sub New(ByVal identity As IIdentity)
            MyBase.New(identity)
        End Sub

        ''' <summary>
        ''' Primary login (in the program without certain database).
        ''' </summary>
        ''' <param name="cLocalUser"> LocalUser object with the connection details.</param>
        ''' <param name="cPassword"> Password to be used. </param>
        ''' <param name="cCacheManager"> Object that implements ICacheManager interface
        ''' and is used for cached object management. </param>
        Public Shared Function Login(ByVal cLocalUser As LocalUser, _
            ByVal cPassword As String, ByVal cCacheManager As ICacheManager) As Boolean
            If cLocalUser.ConnectionTechnology = ConnectionType.Local Then
                Return SetPrincipal(AccIdentity.GetIdentity(cLocalUser.Name, _
                    cPassword, cLocalUser.SqlServerAddress, cLocalUser.SqlServerPort, _
                    cLocalUser.SqlServerType, cLocalUser.DatabaseNamingConvention, _
                    cLocalUser.UseSSL, cLocalUser.SslCertificateFile, _
                    cLocalUser.SslCertificatePassword, cLocalUser.SslCertificateInstalled, _
                    cLocalUser.CannotSetGrants, cCacheManager, cLocalUser.SqlConnectionCharSet), cCacheManager)
            Else
                Return SetPrincipal(AccIdentity.GetIdentity(cLocalUser.Name, _
                    cPassword, cLocalUser.ConnectionTechnology, cLocalUser.ApplicationServerURL, _
                    cLocalUser.UseSSL, cLocalUser.SslCertificateFile, _
                    cLocalUser.SslCertificatePassword, cLocalUser.SslCertificateInstalled, _
                    cCacheManager), cCacheManager)
            End If
        End Function

        ''' <summary>
        ''' Primary login (in the program without certain database) for web server.
        ''' </summary>
        ''' <param name="cUserName"> User name to be used.</param>
        ''' <param name="cPassword"> Password to be used. </param>
        ''' <param name="cCacheManager"> Object that implements ICacheManager interface
        ''' and is used for cached object management. </param>
        Public Shared Function Login(ByVal cUserName As String, _
            ByVal cPassword As String, ByVal cCacheManager As ICacheManager) As Boolean
            Return SetPrincipal(AccIdentity.GetIdentity(cUserName, _
                cPassword, cCacheManager), cCacheManager)
        End Function

        ''' <summary>
        ''' Primary login for local user, i.e. using file based SQL server, e.g. SQLite.
        ''' </summary>
        ''' <param name="cSqlServerType"> SQL server type. </param>
        Public Shared Function LoginAsLocalUser(ByVal cSqlServerType As SqlServerType) As Boolean
            Return SetPrincipal(AccIdentity.GetLocalUserIdentity(cSqlServerType), Nothing)
        End Function

        ''' <summary>
        ''' Secondary login (to certain database when user is logged in the program).
        ''' </summary>
        ''' <param name="cDatabase"> Name of the database to log in.</param>
        Public Shared Function Login(ByVal cDatabase As String, ByVal cCacheManager As ICacheManager, _
            Optional ByVal cPassword As String = "") As Boolean

            If ApplicationContext.User Is Nothing OrElse Not TypeOf ApplicationContext.User Is AccPrincipal _
                OrElse CType(ApplicationContext.User, AccPrincipal).Identity Is Nothing _
                OrElse Not TypeOf CType(ApplicationContext.User, AccPrincipal).Identity Is AccIdentity _
                OrElse Not CType(CType(ApplicationContext.User, AccPrincipal).Identity, AccIdentity).IsAuthenticated Then _
                Throw New Exception("Klaida. Tik prisijungęs prie programos (authenticated) vartotojas " & _
                    "gali prisijungti prie konkrečios duomenų bazės.")

            Return SetPrincipal(AccIdentity.GetIdentity(cDatabase, cCacheManager, cPassword), cCacheManager)

        End Function

        ''' <summary>
        ''' Login method for web server impersonation.
        ''' </summary>
        ''' <param name="cDatabase"> Name of the database to log in.</param>
        Public Shared Function LoginAsServer(ByVal cUserName As String, ByVal cDatabase As String, _
            ByVal cCacheManager As ICacheManager) As Boolean
            Dim i As AccIdentity = AccIdentity.GetServerIdentity(cUserName, cDatabase)
            Dim result As Boolean = SetPrincipal(i, cCacheManager)
            If result AndAlso Not cCacheManager Is Nothing Then cCacheManager. _
                AddCompanyInfoToLocalContext(cDatabase, i.Password)
            Return result
        End Function

        Private Shared Function SetPrincipal(ByVal identity As AccIdentity, _
            ByVal cCacheManager As ICacheManager) As Boolean

            If identity.IsAuthenticated Then
                Dim principal As AccPrincipal = New AccPrincipal(identity)
                Csla.ApplicationContext.User = principal
                CacheManager.InvalidateCompanyCache()
                If Not cCacheManager Is Nothing Then cCacheManager.ClearCache()
                Return True
            End If

            Return False

        End Function

        Public Shared Sub Logout(ByVal cCacheManager As ICacheManager)
            Dim identity As AccIdentity = AccIdentity.UnauthenticatedIdentity()
            Dim principal As AccPrincipal = New AccPrincipal(identity)
            Csla.ApplicationContext.User = principal
            cCacheManager.ClearCache()
        End Sub

        Public Overrides Function IsInRole(ByVal role As String) As Boolean
            Dim identity As AccIdentity = CType(Me.Identity, AccIdentity)
            Return identity.IsInRole(role)
        End Function

    End Class

End Namespace