﻿Namespace Security

    <Serializable()> _
    Public Class LocalUser
        Inherits BusinessBase(Of LocalUser)

#Region " Business Methods "

        Private _GID As Guid = Guid.NewGuid
        Private _Name As String = ""
        Private _ConnectionTechnology As ConnectionType = ConnectionType.Local
        Private _ApplicationServerURL As String = ""
        Private _SqlServerType As SqlServerType = SqlServerType.MySQL
        Private _SqlServerAddress As String = ""
        Private _SqlServerPort As String = ""
        Private _DatabaseNamingConvention As String = "apskaita"
        Private _UseSSL As Boolean = False
        Private _SslCertificateFile As String = ""
        Private _SslCertificateInstalled As Boolean = False
        Private _SslCertificatePassword As String = ""
        Private _CannotSetGrants As Boolean = False
        Private _SqlConnectionCharSet As String = "cp1257"


        Public ReadOnly Property ID() As Guid
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GID
            End Get
        End Property

        Public Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _Name.Trim <> value.Trim Then
                    _Name = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property ConnectionTechnology() As ConnectionType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ConnectionTechnology
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As ConnectionType)
                If _ConnectionTechnology <> value Then
                    _ConnectionTechnology = value
                    PropertyHasChanged()
                    PropertyHasChanged("ConnectionTechnologyHumanReadable")
                End If
            End Set
        End Property

        Public Property ApplicationServerURL() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ApplicationServerURL
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _ApplicationServerURL.Trim.ToLower <> value.Trim.ToLower Then
                    _ApplicationServerURL = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property SqlServerType() As SqlServerType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SqlServerType
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As SqlServerType)
                If _SqlServerType <> value Then
                    _SqlServerType = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property SqlServerAddress() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SqlServerAddress
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _SqlServerAddress.Trim <> value.Trim Then
                    _SqlServerAddress = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property SqlServerPort() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SqlServerPort
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _SqlServerPort.Trim <> value.Trim Then
                    _SqlServerPort = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property ConnectionTechnologyHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ConvertConnectionTypeHumanReadable(_ConnectionTechnology)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If String.IsNullOrEmpty(value.Trim) Then _
                    value = ConvertConnectionTypeHumanReadable(ConnectionType.Local)
                If _ConnectionTechnology <> ConvertConnectionTypeHumanReadable(value) Then
                    _ConnectionTechnology = ConvertConnectionTypeHumanReadable(value)
                    PropertyHasChanged()
                    PropertyHasChanged("ConnectionTechnology")
                End If
            End Set
        End Property

        Public Property SqlServerTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ConvertSqlServerTypeHumanReadable(_SqlServerType)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If String.IsNullOrEmpty(value.Trim) Then value = _
                    ConvertSqlServerTypeHumanReadable(DataAccessTypes.SqlServerType.MySQL)
                If ConvertSqlServerTypeHumanReadable(value) <> _SqlServerType Then
                    _SqlServerType = ConvertSqlServerTypeHumanReadable(value)
                    PropertyHasChanged()
                    PropertyHasChanged("SqlServerType")
                End If
            End Set
        End Property

        Public Property DatabaseNamingConvention() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DatabaseNamingConvention
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _DatabaseNamingConvention.Trim <> value.Trim Then
                    _DatabaseNamingConvention = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property UseSSL() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UseSSL
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _UseSSL <> value Then
                    _UseSSL = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property SslCertificateFile() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SslCertificateFile.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _SslCertificateFile.Trim <> value.Trim Then
                    _SslCertificateFile = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property SslCertificateInstalled() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SslCertificateInstalled
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _SslCertificateInstalled <> value Then
                    _SslCertificateInstalled = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property SslCertificatePassword() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SslCertificatePassword.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _SslCertificatePassword.Trim <> value.Trim Then
                    _SslCertificatePassword = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property CannotSetGrants() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CannotSetGrants
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _CannotSetGrants <> value Then
                    _CannotSetGrants = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property ServerAddress() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _ConnectionTechnology = ConnectionType.Local Then
                    Return ConvertSqlServerTypeHumanReadable(_SqlServerType) & " - " _
                        & _SqlServerAddress.Trim & ":" & _SqlServerPort.Trim & " @" _
                        & _DatabaseNamingConvention.Trim
                Else
                    Return _ApplicationServerURL
                End If
            End Get
        End Property

        Public Property SqlConnectionCharSet() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SqlConnectionCharSet.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _SqlConnectionCharSet.Trim <> value.Trim Then
                    _SqlConnectionCharSet = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property




        Protected Overrides Function GetIdValue() As Object
            Return _GID
        End Function

        Public Overrides Function ToString() As String
            Return _Name & ", " & Me.ServerAddress
        End Function


#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.StringRequiredRuleArgs("Name", "vartotojo vardas"))
            ValidationRules.AddRule(AddressOf ApplicationServerURLValidation, _
                New Validation.RuleArgs("ApplicationServerURL"))
            ValidationRules.AddRule(AddressOf SqlServerAddressValidation, _
                New Validation.RuleArgs("SqlServerAddress"))
            ValidationRules.AddRule(AddressOf SqlServerPortValidation, _
                New Validation.RuleArgs("SqlServerPort"))
            ValidationRules.AddRule(AddressOf DatabaseNamingConventionValidation, _
                New Validation.RuleArgs("DatabaseNamingConvention"))
            ValidationRules.AddDependantProperty("ConnectionTechnology", "ApplicationServerURL")
            ValidationRules.AddDependantProperty("ConnectionTechnology", "SqlServerAddress")
            ValidationRules.AddDependantProperty("ConnectionTechnology", "SqlServerPort")
            ValidationRules.AddDependantProperty("ConnectionTechnology", "DatabaseNamingConvention")

        End Sub

        ''' <summary>
        ''' Rule ensuring that Application Server URL is provided, when non local technology is used.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function ApplicationServerURLValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As LocalUser = DirectCast(target, LocalUser)

            If ValObj._ConnectionTechnology <> ConnectionType.Local AndAlso _
                String.IsNullOrEmpty(ValObj._ApplicationServerURL.Trim) Then
                e.Description = "Nenurodytas programos serverio URL adresas."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True
        End Function

        ''' <summary>
        ''' Rule ensuring that SQL Server address is provided, when local technology is used.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SqlServerAddressValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As LocalUser = DirectCast(target, LocalUser)

            If ValObj._ConnectionTechnology = ConnectionType.Local AndAlso _
                String.IsNullOrEmpty(ValObj._SqlServerAddress.Trim) Then
                e.Description = "Nenurodytas SQL serverio adresas."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True
        End Function

        ''' <summary>
        ''' Rule ensuring that SQL Server port is provided, when local technology is used.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SqlServerPortValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As LocalUser = DirectCast(target, LocalUser)

            If ValObj._ConnectionTechnology = ConnectionType.Local AndAlso _
                String.IsNullOrEmpty(ValObj._SqlServerPort.Trim) Then
                e.Description = "Nenurodytas SQL serverio portas."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True
        End Function

        ''' <summary>
        ''' Rule ensuring that SQL Server DatabaseNamingConvention is provided, when local technology is used.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DatabaseNamingConventionValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As LocalUser = DirectCast(target, LocalUser)

            If ValObj._ConnectionTechnology = ConnectionType.Local AndAlso _
                String.IsNullOrEmpty(ValObj._DatabaseNamingConvention.Trim) Then
                e.Description = "Nenurodyta duomenų bazių vardų pagrindas SQL serveryje."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewLocalUser() As LocalUser
            Return New LocalUser
        End Function

        Friend Shared Function GetLocalUser(ByVal UserString As String) As LocalUser
            Return New LocalUser(UserString)
        End Function

        Private Sub New()
            MarkAsChild()
            ValidationRules.CheckRules()
        End Sub

        Private Sub New(ByVal UserString As String)
            MarkAsChild()
            Fetch(UserString)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal UserString As String)
            _Name = GetElement(UserString, 0)
            _SqlServerAddress = GetElement(UserString, 1)
            _SqlServerPort = GetElement(UserString, 2)
            _ApplicationServerURL = GetElement(UserString, 4)
            Dim t As String = GetElement(UserString, 3).Trim
            If String.IsNullOrEmpty(t) OrElse t = "0" Then
                _ConnectionTechnology = ConnectionType.Local
            ElseIf t = "1" Then
                _ConnectionTechnology = ConnectionType.Remoting
            ElseIf t = "2" Then
                _ConnectionTechnology = ConnectionType.WebService
            ElseIf t = "3" Then
                _ConnectionTechnology = ConnectionType.EnerpriseServices
            Else
                Throw New Exception("Klaida nuskaitant programos vartotojų sąrašą. " & _
                    "Nenustatyta vartotojo " & _Name & " prisijungimo technologija.")
            End If

            t = GetElement(UserString, 5)
            If Not String.IsNullOrEmpty(t.Trim) AndAlso Integer.TryParse(t, New Integer) Then
                If CInt(t) = 0 Then
                    _SqlServerType = SqlServerType.MySQL
                ElseIf CInt(t) = 1 Then
                    _SqlServerType = SqlServerType.SQLite
                Else
                    Throw New Exception("Klaida nuskaitant programos vartotojų sąrašą. " _
                        & "Neaiškus SQL serverio tipas, kuriam programos nustatymuose " _
                        & "suteiktas kodas '" & t & "'.")
                End If
            End If

            _DatabaseNamingConvention = GetElement(UserString, 6).Trim

            If Integer.TryParse(GetElement(UserString, 7).Trim, New Integer) _
                AndAlso CInt(GetElement(UserString, 7).Trim) > 0 Then
                _UseSSL = True
            Else
                _UseSSL = False
            End If

            If Integer.TryParse(GetElement(UserString, 8).Trim, New Integer) _
                AndAlso CInt(GetElement(UserString, 8).Trim) > 0 Then
                _SslCertificateInstalled = True
            Else
                _SslCertificateInstalled = False
            End If

            _SslCertificateFile = GetElement(UserString, 9).Trim
            _SslCertificatePassword = GetElement(UserString, 10).Trim

            If Integer.TryParse(GetElement(UserString, 11).Trim, New Integer) _
                AndAlso CInt(GetElement(UserString, 11).Trim) > 0 Then
                _CannotSetGrants = True
            Else
                _CannotSetGrants = False
            End If

            _SqlConnectionCharSet = GetElement(UserString, 12).Trim

            ValidationRules.CheckRules()
            MarkOld()

        End Sub

        Friend Function ToSettingsString() As String
            Dim result As String = _Name & Chr(9) & _SqlServerAddress & Chr(9) & _SqlServerPort & Chr(9)
            If _ConnectionTechnology = ConnectionType.Local Then
                result = result & "0"
            ElseIf _ConnectionTechnology = ConnectionType.Remoting Then
                result = result & "1"
            ElseIf _ConnectionTechnology = ConnectionType.WebService Then
                result = result & "2"
            Else
                result = result & "3"
            End If
            result = result & Chr(9) & _ApplicationServerURL
            If _SqlServerType = SqlServerType.MySQL Then
                result = result & Chr(9) & "0"
            Else
                result = result & Chr(9) & "1"
            End If
            result = result & Chr(9) & _DatabaseNamingConvention & Chr(9)
            If _UseSSL Then
                result = result & "1" & Chr(9)
            Else
                result = result & "0" & Chr(9)
            End If
            If _SslCertificateInstalled Then
                result = result & "1" & Chr(9)
            Else
                result = result & "0" & Chr(9)
            End If
            result = result & _SslCertificateFile & Chr(9)
            result = result & _SslCertificatePassword & Chr(9)
            If _CannotSetGrants Then
                result = result & "1"
            Else
                result = result & "0"
            End If
            result = result & Chr(9) & _SqlConnectionCharSet

            Return result

        End Function

#End Region

    End Class

End Namespace