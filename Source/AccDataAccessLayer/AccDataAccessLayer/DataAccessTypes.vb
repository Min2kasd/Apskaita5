﻿Public Module DataAccessTypes

#Region "  Maps  "

    

#End Region

#Region "   Types   "

    Public Enum SqlServerType
        MySQL
        SQLite
    End Enum

    Public Enum ExceptionType
        NotSupportedException
        SecurityException
        UnknownException
    End Enum

    Public Enum ConnectionType
        Local
        Remoting
        WebService
        EnerpriseServices
    End Enum

    Public Enum DatabaseFieldType
        Float
        Real
        [Double]
        [Decimal]
        IntegerTiny
        IntegerSmall
        IntegerMedium
        [Integer]
        IntegerBig
        TimeStamp
        [Date]
        [DateTime]
        [Time]
        [Char]
        VarChar
        Text
        TextMedium
        TextLong
        BlobTiny
        Blob
        BlobMedium
        BlobLong
        [Enum]
    End Enum

    Friend Enum DatabaseStructureType
        DatabaseMirror
        GaugeFile
        Other
    End Enum

    Public Enum DatabaseTableAccessType
        [Select]
        [Insert]
        [Update]
    End Enum

    Public Enum RoleAccessType
        None
        Read
        Write
        Update
    End Enum

    Public Enum DatabaseStructureErrorType
        TableMissing
        TableObsolete
        FieldMissing
        FieldObsolete
        FieldDefinitionObsolete
        IndexMissing
        IndexObsolete
        ProcedureMissing
        ProcedureObsolete
        ProcedureDefinitionObsolete
        Custom
    End Enum

#End Region

#Region "   Converters   "

    Public Function ConvertSqlServerTypeHumanReadable(ByVal nType As SqlServerType) As String
        Select Case nType
            Case SqlServerType.MySQL
                Return "MySQL serveris"
            Case SqlServerType.SQLite
                Return "SQLite failinis serveris"
            Case Else
                Throw New Exception("Klaida. Serverio tipas '" & nType.ToString & "' nežinomas.")
        End Select
    End Function

    Public Function ConvertSqlServerTypeHumanReadable(ByVal TypeName As String) As SqlServerType
        Select Case TypeName.Trim.ToLower
            Case "mysql serveris"
                Return SqlServerType.MySQL
            Case "sqlite failinis serveris"
                Return SqlServerType.SQLite
            Case Else
                Throw New Exception("Klaida. Serverio tipas '" & TypeName & "' nežinomas.")
        End Select
    End Function

    Public Function GetSqlServerTypeDataSource(ByVal AddEmpty As Boolean, _
        ByVal ExcludeFileServers As Boolean) As List(Of String)

        Dim result As New List(Of String)
        If AddEmpty Then result.Add("")

        Dim list As New List(Of SqlServerType)
        For Each t As SqlServerType In [Enum].GetValues(GetType(SqlServerType))
            list.Add(t)
        Next

        For Each name As SqlServerType In list
            If Not DatabaseAccess.GetSqlGenerator(name).SqlServerFileBased _
                OrElse Not ExcludeFileServers Then
                result.Add(ConvertSqlServerTypeHumanReadable(name))
            End If
        Next

        Return result

    End Function


    Public Function ConvertConnectionTypeHumanReadable(ByVal ConnType As ConnectionType) As String
        Select Case ConnType
            Case ConnectionType.Local
                Return "Tiesioginis ryšys"
            Case ConnectionType.Remoting
                Return "Remoting"
            Case ConnectionType.EnerpriseServices
                Return "Enerprise servisas"
            Case ConnectionType.WebService
                Return "Web servisas"
            Case Else
                Throw New Exception("Klaida. Nežinomas technologijos tipas '" & _
                    ConnType.ToString & "'.")
        End Select
    End Function

    Public Function ConvertConnectionTypeHumanReadable(ByVal ConnTypeString As String) As ConnectionType
        Select Case ConnTypeString.ToLower.Trim
            Case "tiesioginis ryšys"
                Return ConnectionType.Local
            Case "remoting"
                Return ConnectionType.Remoting
            Case "enerprise servisas"
                Return ConnectionType.EnerpriseServices
            Case "web servisas"
                Return ConnectionType.WebService
            Case Else
                Throw New Exception("Klaida. Nežinomas technologijos tipas '" & _
                    ConnTypeString & "'.")
        End Select
    End Function

    Public Function GetConnectionTypeDataSource(ByVal AddEmpty As Boolean) As List(Of String)

        Dim result As New List(Of String)
        If AddEmpty Then result.Add("")

        Dim list As New List(Of ConnectionType)
        For Each t As ConnectionType In [Enum].GetValues(GetType(ConnectionType))
            list.Add(t)
        Next

        For Each name As ConnectionType In list
            result.Add(ConvertConnectionTypeHumanReadable(name))
        Next

        Return result

    End Function



    Public Function DatabaseFieldTypeIsFloat(ByVal fieldType As DatabaseFieldType) As Boolean
        Return (fieldType = DatabaseFieldType.Float OrElse _
            fieldType = DatabaseFieldType.Real OrElse _
            fieldType = DatabaseFieldType.Double)
    End Function

    Public Function DatabaseFieldTypeIsChar(ByVal fieldType As DatabaseFieldType) As Boolean
        Return (fieldType = DatabaseFieldType.Char OrElse _
            fieldType = DatabaseFieldType.VarChar)
    End Function

    Public Function DatabaseFieldTypeIsText(ByVal fieldType As DatabaseFieldType) As Boolean
        Return (fieldType = DatabaseFieldType.Text OrElse _
            fieldType = DatabaseFieldType.TextMedium OrElse _
            fieldType = DatabaseFieldType.TextLong)
    End Function

    Public Function DatabaseFieldTypeIsBlob(ByVal fieldType As DatabaseFieldType) As Boolean
        Return (fieldType = DatabaseFieldType.Blob OrElse _
            fieldType = DatabaseFieldType.BlobLong OrElse _
            fieldType = DatabaseFieldType.BlobMedium OrElse _
            fieldType = DatabaseFieldType.BlobTiny)
    End Function

    Public Function DatabaseFieldTypeIsDateTime(ByVal fieldType As DatabaseFieldType) As Boolean
        Return (fieldType = DatabaseFieldType.Date OrElse _
            fieldType = DatabaseFieldType.DateTime OrElse _
            fieldType = DatabaseFieldType.Time OrElse _
            fieldType = DatabaseFieldType.TimeStamp)
    End Function

    Public Function DatabaseFieldTypeIsInteger(ByVal fieldType As DatabaseFieldType) As Boolean
        Return (fieldType = DatabaseFieldType.Integer OrElse _
            fieldType = DatabaseFieldType.IntegerBig OrElse _
            fieldType = DatabaseFieldType.IntegerMedium OrElse _
            fieldType = DatabaseFieldType.IntegerSmall OrElse _
            fieldType = DatabaseFieldType.IntegerTiny)
    End Function



    Public Function ConvertRoleAccessTypeInteger(ByVal nRoleAccessType As RoleAccessType) As Integer
        Select Case nRoleAccessType
            Case RoleAccessType.None
                Return 0
            Case RoleAccessType.Read
                Return 1
            Case RoleAccessType.Write
                Return 2
            Case RoleAccessType.Update
                Return 3
            Case Else
                Throw New Exception("Klaida. Teisės prieigos lygis '" _
                    & nRoleAccessType.ToString & "' nežinomas.")
        End Select
    End Function

    Public Function ConvertRoleAccessTypeInteger(ByVal nRoleAccessInteger As Integer) As RoleAccessType
        Select Case nRoleAccessInteger
            Case 0
                Return RoleAccessType.None
            Case 1
                Return RoleAccessType.Read
            Case 2
                Return RoleAccessType.Write
            Case 3
                Return RoleAccessType.Update
            Case Else
                Throw New Exception("Klaida. Teisės prieigos lygio kodas '" _
                    & nRoleAccessInteger.ToString & "' nežinomas.")
        End Select
    End Function

    Public Function ConvertFromLithuanianToEnglishLetters(ByVal OriginalString As String) As String
        Return OriginalString.Replace("ą", "").Replace("č", "").Replace("ę", "").Replace("ė", ""). _
            Replace("į", "").Replace("š", "").Replace("ų", "").Replace("ū", "").Replace("ž", ""). _
            Replace("Ą", "").Replace("Č", "").Replace("Ę", "").Replace("Ė", "").Replace("Į", ""). _
            Replace("Š", "").Replace("Ų", "").Replace("Ū", "").Replace("Ž", "")
    End Function

#End Region

End Module
