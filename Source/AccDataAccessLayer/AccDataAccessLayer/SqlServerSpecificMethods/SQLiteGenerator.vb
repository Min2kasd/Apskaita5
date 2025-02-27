﻿Imports AccDataAccessLayer.DatabaseAccess
Namespace SqlServerSpecificMethods

    Friend Class SQLiteGenerator
        Implements ISqlGenerator

        Private Const DateTimeFormatString As String = "yyyy-MM-dd HH\:mm\:ss.fff"

#Region "*** Properties ***"

        Public ReadOnly Property ServerType() As DataAccessTypes.SqlServerType _
            Implements ISqlGenerator.ServerType
            Get
                Return SqlServerType.SQLite
            End Get
        End Property

        Public ReadOnly Property DatabaseIsCreatedByConnectionAutomaticaly() As Boolean _
            Implements ISqlGenerator.DatabaseIsCreatedByConnectionAutomaticaly
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property DatabaseIsCreatedByCustomCode() As Boolean _
            Implements ISqlGenerator.DatabaseIsCreatedByCustomCode
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property DatabaseIsCreatedBySqlStatement() As Boolean _
            Implements ISqlGenerator.DatabaseIsCreatedBySqlStatement
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property CreateStatementContainsIndexes() As Boolean _
            Implements ISqlGenerator.CreateStatementContainsIndexes
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property ShowTablesResultsIncludeCreateTableStatements() As Boolean _
            Implements ISqlGenerator.ShowTablesResultsIncludeCreateTableStatements
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property StoredProcedureNameItemInQueryResults() As Integer _
            Implements ISqlGenerator.StoredProcedureNameItemInQueryResults
            Get
                Return -1
            End Get
        End Property

        Public ReadOnly Property StoredProcedureSourceItemInQueryResults() As Integer _
            Implements ISqlGenerator.StoredProcedureSourceItemInQueryResults
            Get
                Return -1
            End Get
        End Property

        Public ReadOnly Property ShowProceduresResultsIncludeCreateTableStatements() As Boolean _
            Implements ISqlGenerator.ShowProceduresResultsIncludeCreateTableStatements
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property SupportsStoredProcedures() As Boolean _
            Implements ISqlGenerator.SupportsStoredProcedures
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property SupportsUniqueFields() As Boolean _
            Implements ISqlGenerator.SupportsUniqueFields
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property SupportsUsignedFields() As Boolean _
            Implements ISqlGenerator.SupportsUsignedFields
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property SupportsEnumFields() As Boolean _
            Implements ISqlGenerator.SupportsEnumFields
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property RootName() As String _
            Implements ISqlGenerator.RootName
            Get
                Return "root"
            End Get
        End Property

        Public ReadOnly Property SqlServerFileBased() As Boolean _
            Implements ISqlGenerator.SqlServerFileBased
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property Wildcart() As String _
            Implements ISqlGenerator.Wildcart
            Get
                Return "%"
            End Get
        End Property

        Public ReadOnly Property TablePrivilegesAreRevokedByRevokeAllPrivileges() As Boolean _
            Implements ISqlGenerator.TablePrivilegesAreRevokedByRevokeAllPrivileges
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property SupportsTablePrivileges() As Boolean _
            Implements ISqlGenerator.SupportsTablePrivileges
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property SupportsBlobLength() As Boolean _
            Implements ISqlGenerator.SupportsBlobLength
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property SupportsCharLength() As Boolean _
            Implements ISqlGenerator.SupportsCharLength
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property SupportsDecimalLength() As Boolean _
            Implements ISqlGenerator.SupportsDecimalLength
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property SupportsDoubleLength() As Boolean _
            Implements ISqlGenerator.SupportsDoubleLength
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property SupportsEnums() As Boolean _
            Implements ISqlGenerator.SupportsEnums
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property SupportsIntLength() As Boolean _
            Implements ISqlGenerator.SupportsIntLength
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property SupportsVarCharLength() As Boolean _
            Implements ISqlGenerator.SupportsVarCharLength
            Get
                Return False
            End Get
        End Property

#End Region

#Region "*** DatabaseStructure.DatabaseField ***"

        Public Function GetFieldDbDefinition(ByVal field As DatabaseAccess.DatabaseStructure.DatabaseField) _
            As String Implements ISqlGenerator.GetFieldDbDefinition

            Dim applicableFieldType As DatabaseFieldType = field.Type
            If field.Autoincrement Then applicableFieldType = DatabaseFieldType.Integer

            Dim result As String = field.Name.Trim & " " & Me.GetFieldTypeName(applicableFieldType)

            If DatabaseFieldTypeIsChar(field.Type) Then _
                result = result & "(" & field.Length.ToString & ")" ' ??? SUPPORTED ???

            If field.NotNull Then result = result.Trim & " NOT NULL "

            If field.PrimaryKey Then
                If DatabaseFieldTypeIsInteger(field.Type) AndAlso field.Autoincrement Then
                    result = result.Trim & " PRIMARY KEY AUTOINCREMENT"
                Else
                    result = result.Trim & " PRIMARY KEY"
                End If

            ElseIf field.Unique AndAlso (field.IndexName Is Nothing OrElse _
                String.IsNullOrEmpty(field.IndexName.Trim)) Then
                result = result.Trim & " UNIQUE"
            End If

            Return result.Trim

        End Function

        Public Function GetModifyFieldStatement(ByVal DatabaseName As String, ByVal TableName As String, _
            ByVal field As DatabaseAccess.DatabaseStructure.DatabaseField) As String _
            Implements ISqlGenerator.GetModifyFieldStatement

            Throw New NotSupportedException("Klaida. SQLite failinis serveris " _
                & "nenumato galimybės keisti laukų duomenis.")

        End Function

        Public Function GetDropFieldStatement(ByVal DatabaseName As String, _
            ByVal TableName As String, ByVal field As DatabaseAccess.DatabaseStructure.DatabaseField) As String _
            Implements ISqlGenerator.GetDropFieldStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris " _
                & "nenumato galimybės pašalinti laukus.")
        End Function

        Public Function GetAddFieldStatement(ByVal DatabaseName As String, ByVal TableName As String, _
            ByVal field As DatabaseAccess.DatabaseStructure.DatabaseField) As String _
            Implements ISqlGenerator.GetAddFieldStatement
            Return "ALTER TABLE " & TableName & " ADD COLUMN " & GetNotNullSafeFieldDbDefinition(field) & ";"
        End Function

        Private Function GetNotNullSafeFieldDbDefinition(ByVal field As DatabaseStructure.DatabaseField) As String

            Dim applicableFieldType As DatabaseFieldType = field.Type
            If field.Autoincrement Then applicableFieldType = DatabaseFieldType.Integer

            Dim result As String = field.Name.Trim & " " & Me.GetFieldTypeName(applicableFieldType)

            If DatabaseFieldTypeIsChar(field.Type) Then _
                result = result & "(" & field.Length.ToString & ")" ' ??? SUPPORTED ???

            If field.NotNull Then result = result & " DEFAULT " _
                & GetDefaultValueForFieldType(field.Type, field.EnumValues) & " NOT NULL"

            If field.PrimaryKey Then
                If DatabaseFieldTypeIsInteger(field.Type) AndAlso field.Autoincrement Then
                    result = result.Trim & " PRIMARY KEY AUTOINCREMENT"
                Else
                    result = result.Trim & " PRIMARY KEY"
                End If

            ElseIf field.Unique AndAlso (field.IndexName Is Nothing OrElse _
                String.IsNullOrEmpty(field.IndexName.Trim)) Then
                result = result.Trim & " UNIQUE"
            End If

            Return result.Trim

        End Function

        Private Function GetDefaultValueForFieldType(ByVal fieldType As DatabaseFieldType, _
            ByVal EnumValues As String) As String

            Select Case fieldType
                Case DatabaseFieldType.Blob
                    Throw New NotSupportedException("Cannot add new NOT NULL column of type " _
                        & "BLOB because BLOB type does not have default value.")
                Case DatabaseFieldType.BlobLong
                    Throw New NotSupportedException("Cannot add new NOT NULL column of type " _
                        & "BLOB because BLOB type does not have default value.")
                Case DatabaseFieldType.BlobMedium
                    Throw New NotSupportedException("Cannot add new NOT NULL column of type " _
                        & "BLOB because BLOB type does not have default value.")
                Case DatabaseFieldType.BlobTiny
                    Throw New NotSupportedException("Cannot add new NOT NULL column of type " _
                        & "BLOB because BLOB type does not have default value.")
                Case DatabaseFieldType.Char
                    Return "''"
                Case DatabaseFieldType.Date
                    Return "'" & Today.ToString(DateTimeFormatString) & "'"
                Case DatabaseFieldType.DateTime
                    Return "'" & Now.ToString(DateTimeFormatString) & "'"
                Case DatabaseFieldType.Decimal
                    Return "0"
                Case DatabaseFieldType.Double
                    Return "0"
                Case DatabaseFieldType.Enum
                    Try
                        Return "'" & EnumValues.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)(0) & "'"
                    Catch ex As Exception
                        Throw New Exception("Failed to find the default enum value.", ex)
                    End Try
                Case DatabaseFieldType.Float
                    Return "0"
                Case DatabaseFieldType.Integer
                    Return "0"
                Case DatabaseFieldType.IntegerBig
                    Return "0"
                Case DatabaseFieldType.IntegerMedium
                    Return "0"
                Case DatabaseFieldType.IntegerSmall
                    Return "0"
                Case DatabaseFieldType.IntegerTiny
                    Return "0"
                Case DatabaseFieldType.Real
                    Return "0"
                Case DatabaseFieldType.Text
                    Return "''"
                Case DatabaseFieldType.TextLong
                    Return "''"
                Case DatabaseFieldType.TextMedium
                    Return "''"
                Case DatabaseFieldType.Time
                    Return "'" & Now.ToString(DateTimeFormatString) & "'"
                Case DatabaseFieldType.TimeStamp
                    Return "'" & Now.ToString(DateTimeFormatString) & "'"
                Case DatabaseFieldType.VarChar
                    Return "''"
                Case Else
                    Throw New NotSupportedException("Cannot add new NOT NULL column of type " _
                        & fieldType.ToString & " because this type does not have default value.")
            End Select

        End Function

        Private Function GetDefaultValueForType(ByVal nType As DatabaseFieldType, _
            ByVal DefaultEnumValue As String) As Object

            Select Case nType
                Case DatabaseFieldType.Blob
                    Return New Byte() {}
                Case DatabaseFieldType.BlobLong
                    Return New Byte() {}
                Case DatabaseFieldType.BlobMedium
                    Return New Byte() {}
                Case DatabaseFieldType.BlobTiny
                    Return New Byte() {}
                Case DatabaseFieldType.Char
                    Return ""
                Case DatabaseFieldType.Date
                    Return Today
                Case DatabaseFieldType.DateTime
                    Return Now
                Case DatabaseFieldType.Decimal
                    Return 0
                Case DatabaseFieldType.Double
                    Return 0
                Case DatabaseFieldType.Enum
                    Return DefaultEnumValue
                Case DatabaseFieldType.Float
                    Return 0
                Case DatabaseFieldType.Integer
                    Return 0
                Case DatabaseFieldType.IntegerBig
                    Return 0
                Case DatabaseFieldType.IntegerMedium
                    Return 0
                Case DatabaseFieldType.IntegerSmall
                    Return 0
                Case DatabaseFieldType.IntegerTiny
                    Return 0
                Case DatabaseFieldType.Real
                    Return 0
                Case DatabaseFieldType.Text
                    Return ""
                Case DatabaseFieldType.TextLong
                    Return ""
                Case DatabaseFieldType.TextMedium
                    Return ""
                Case DatabaseFieldType.Time
                    Return Now
                Case DatabaseFieldType.TimeStamp
                    Return Now
                Case DatabaseFieldType.VarChar
                    Return ""
                Case Else
                    Throw New NotSupportedException("Klaida. Duomenų tipas '" & _
                        nType.ToString & "' SQLite serveryje nežinomas.")
            End Select

        End Function

        Public Function GetCreateIndexStatement(ByVal DatabaseName As String, ByVal TableName As String, _
            ByVal field As DatabaseAccess.DatabaseStructure.DatabaseField) As String _
            Implements ISqlGenerator.GetCreateIndexStatement

            Dim result As String = "CREATE "
            If field.Unique Then
                result = result & "UNIQUE INDEX "
            Else
                result = result & "INDEX "
            End If
            ' SQL index names have to bu unique across database -> add table name to indexname
            result = result & TableName.Trim & field.IndexName.Trim & " ON " & TableName & " (" _
                & field.Name.Trim & ");"
            Return result

        End Function

        Public Function GetDropIndexStatement(ByVal DatabaseName As String, ByVal TableName As String, _
            ByVal field As DatabaseAccess.DatabaseStructure.DatabaseField) As String _
            Implements ISqlGenerator.GetDropIndexStatement
            Return "DROP INDEX " & field.IndexName.Trim & ";"
        End Function

        Public Function GetIndexDbDefinition(ByVal field As DatabaseAccess.DatabaseStructure.DatabaseField) _
            As String Implements ISqlGenerator.GetIndexDbDefinition
            Throw New Exception("Klaida. Failiniame SQLite serveryje indeksai nėra " & _
                "apibrėžiami CREATE TABLE sakinyje.")
        End Function

        Public Sub FetchDatabaseFieldFromDbDefinition(ByVal DbDefinition As String, _
            ByRef Name As String, ByRef NotNull As Boolean, ByRef Autoincrement As Boolean, _
            ByRef PrimaryKey As Boolean, ByRef Unsigned As Boolean, _
            ByRef FieldType As DataAccessTypes.DatabaseFieldType, ByRef Length As Integer, _
            ByRef EnumValues As String, ByRef Unique As Boolean) _
            Implements ISqlGenerator.FetchDatabaseFieldFromDbDefinition

            Dim cleanDefinition As String = DbDefinition.Trim.Replace("[", "").Replace("]", "")

            Name = cleanDefinition.Split(New Char() {" "c}, _
                StringSplitOptions.RemoveEmptyEntries)(0).Trim

            cleanDefinition = cleanDefinition.Substring(Name.Length + 1)

            NotNull = cleanDefinition.ToLower.Contains("not null")
            Autoincrement = cleanDefinition.ToLower.Contains("autoincrement")
            PrimaryKey = cleanDefinition.ToLower.Contains("primary key")
            Unique = cleanDefinition.ToLower.Contains("unique")
            Unsigned = False

            Dim TypeName As String = cleanDefinition.Split(New Char() {" "c}, _
                StringSplitOptions.RemoveEmptyEntries)(0).Trim
            Dim TypeDetails As String = ""
            If TypeName.Contains("(") Then
                TypeDetails = TypeName.Substring(TypeName.IndexOf("("), _
                    TypeName.IndexOf(")") - TypeName.IndexOf("("))
                TypeName = TypeName.Substring(0, TypeName.IndexOf("("))
            End If

            FieldType = GetFieldTypeFromDbDefinition(TypeName)

            If FieldType = DatabaseFieldType.Char OrElse FieldType = DatabaseFieldType.VarChar Then
                Integer.TryParse(TypeDetails.Trim.Replace("`", ""), Length)
            ElseIf FieldType = DatabaseFieldType.Enum Then
                EnumValues = TypeDetails.Trim.Replace("`", "")
            End If

        End Sub

        Public Function DatabaseFieldTypesSimilar(ByVal fieldType1 As DataAccessTypes.DatabaseFieldType, _
            ByVal fieldType2 As DataAccessTypes.DatabaseFieldType) As Boolean _
            Implements ISqlGenerator.DatabaseFieldTypesSimilar

            Return (FieldTypeToBaseType(fieldType1) = FieldTypeToBaseType(fieldType2))

        End Function

        Private Function FieldTypeToBaseType(ByVal fieldType As DataAccessTypes.DatabaseFieldType) _
            As DataAccessTypes.DatabaseFieldType

            Select Case fieldType
                Case DatabaseFieldType.Blob
                    Return DatabaseFieldType.Blob
                Case DatabaseFieldType.BlobLong
                    Return DatabaseFieldType.Blob
                Case DatabaseFieldType.BlobMedium
                    Return DatabaseFieldType.Blob
                Case DatabaseFieldType.BlobTiny
                    Return DatabaseFieldType.Blob
                Case DatabaseFieldType.Char
                    Return DatabaseFieldType.Text
                Case DatabaseFieldType.Date
                    Return DatabaseFieldType.Date
                Case DatabaseFieldType.DateTime
                    Return DatabaseFieldType.Date
                Case DatabaseFieldType.Decimal
                    Return DatabaseFieldType.Decimal
                Case DatabaseFieldType.Double
                    Return DatabaseFieldType.Double
                Case DatabaseFieldType.Enum
                    Return DatabaseFieldType.Text
                Case DatabaseFieldType.Float
                    Return DatabaseFieldType.Double
                Case DatabaseFieldType.Integer
                    Return DatabaseFieldType.Integer
                Case DatabaseFieldType.IntegerBig
                    Return DatabaseFieldType.Integer
                Case DatabaseFieldType.IntegerMedium
                    Return DatabaseFieldType.Integer
                Case DatabaseFieldType.IntegerSmall
                    Return DatabaseFieldType.Integer
                Case DatabaseFieldType.IntegerTiny
                    Return DatabaseFieldType.Integer
                Case DatabaseFieldType.Real
                    Return DatabaseFieldType.Double
                Case DatabaseFieldType.Text
                    Return DatabaseFieldType.Text
                Case DatabaseFieldType.TextLong
                    Return DatabaseFieldType.Text
                Case DatabaseFieldType.TextMedium
                    Return DatabaseFieldType.Text
                Case DatabaseFieldType.Time
                    Return DatabaseFieldType.Date
                Case DatabaseFieldType.TimeStamp
                    Return DatabaseFieldType.Date
                Case DatabaseFieldType.VarChar
                    Return DatabaseFieldType.Text
                Case Else
                    Return DatabaseFieldType.Blob
            End Select


        End Function

        Public Function GetFieldTypeFromDbDefinition(ByVal DbDefinition As String) _
            As DataAccessTypes.DatabaseFieldType _
            Implements ISqlGenerator.GetFieldTypeFromDbDefinition

            Select Case DbDefinition.Trim.ToUpper
                Case "BLOB"
                    Return DatabaseFieldType.Blob
                Case "DATE"
                    Return DatabaseFieldType.Date
                Case "DATETIME"
                    Return DatabaseFieldType.DateTime
                Case "DECIMAL"
                    Return DatabaseFieldType.Decimal
                Case "DOUBLE"
                    Return DatabaseFieldType.Double
                Case "FLOAT"
                    Return DatabaseFieldType.Float
                Case "INT"
                    Return DatabaseFieldType.Integer
                Case "INTEGER"
                    Return DatabaseFieldType.Integer
                Case "BIGINT"
                    Return DatabaseFieldType.IntegerBig
                Case "MEDIUMINT"
                    Return DatabaseFieldType.IntegerMedium
                Case "SMALLINT"
                    Return DatabaseFieldType.IntegerSmall
                Case "TINYINT"
                    Return DatabaseFieldType.IntegerSmall
                Case "REAL"
                    Return DatabaseFieldType.Real
                Case "TEXT"
                    Return DatabaseFieldType.Text
                Case "VARCHAR"
                    Return DatabaseFieldType.VarChar
                Case Else
                    Throw New NotSupportedException("Klaida. Duomenų tipas '" & _
                        DbDefinition.Trim.ToUpper & "' SQLite serveryje nežinomas.")
            End Select

        End Function

        Public Function GetFieldTypeName(ByVal fieldType As DataAccessTypes.DatabaseFieldType) As String _
            Implements ISqlGenerator.GetFieldTypeName

            Select Case fieldType
                Case DatabaseFieldType.Blob
                    Return "BLOB"
                Case DatabaseFieldType.BlobLong
                    Return "BLOB"
                Case DatabaseFieldType.BlobMedium
                    Return "BLOB"
                Case DatabaseFieldType.BlobTiny
                    Return "BLOB"
                Case DatabaseFieldType.Char
                    Return "VARCHAR"
                Case DatabaseFieldType.Date
                    Return "DATE"
                Case DatabaseFieldType.DateTime
                    Return "DATETIME"
                Case DatabaseFieldType.Decimal
                    Return "DECIMAL"
                Case DatabaseFieldType.Double
                    Return "DOUBLE"
                Case DatabaseFieldType.Enum
                    Return "VARCHAR"
                Case DatabaseFieldType.Float
                    Return "FLOAT"
                Case DatabaseFieldType.Integer
                    Return "INTEGER"
                Case DatabaseFieldType.IntegerBig
                    Return "BIGINT"
                Case DatabaseFieldType.IntegerMedium
                    Return "MEDIUMINT"
                Case DatabaseFieldType.IntegerSmall
                    Return "SMALLINT"
                Case DatabaseFieldType.IntegerTiny
                    Return "TINYINT"
                Case DatabaseFieldType.Real
                    Return "REAL"
                Case DatabaseFieldType.Text
                    Return "TEXT"
                Case DatabaseFieldType.TextLong
                    Return "TEXT"
                Case DatabaseFieldType.TextMedium
                    Return "TEXT"
                Case DatabaseFieldType.Time
                    Return "DATETIME"
                Case DatabaseFieldType.TimeStamp
                    Return "DATETIME"
                Case DatabaseFieldType.VarChar
                    Return "VARCHAR"
                Case Else
                    Throw New NotSupportedException("Klaida. Duomenų tipas '" & _
                        fieldType.ToString & "' SQLite serveryje nežinomas.")
            End Select

        End Function

#End Region

#Region "*** DatabaseStructure.DatabaseFieldList ***"

        Public Function GetIndexNameFromDbDefinition(ByVal DbDefinition As String) As String _
                Implements ISqlGenerator.GetIndexNameFromDbDefinition

            DbDefinition = DbDefinition.Trim.Replace("[", "").Replace("]", ""). _
                Replace(" UNIQUE ", " ").Replace("CREATE INDEX", "").Trim

            Return DbDefinition.Substring(0, DbDefinition.IndexOf(" ON "))

        End Function

        Public Function GetIndexTableNameFromDbDefinition(ByVal DbDefinition As String) As String _
            Implements ISqlGenerator.GetIndexTableNameFromDbDefinition
            Return DbDefinition.Substring(DbDefinition.IndexOf(" ON "), _
                DbDefinition.IndexOf("(") - DbDefinition.IndexOf(" ON "))
        End Function

        Public Function GetIndexColumnNameFromDbDefinition(ByVal DbDefinition As String) As String _
            Implements ISqlGenerator.GetIndexColumnNameFromDbDefinition

            DbDefinition = DbDefinition.Trim.Replace("[", "").Replace("]", "").Trim

            Return DbDefinition.Substring(DbDefinition.IndexOf("(") + 1, DbDefinition.IndexOf(")") _
                - DbDefinition.IndexOf("(") - 1).Trim.Split(" "c)(0)

        End Function

        Public Function IsValidFieldDbDefinition(ByVal DbDefinition As String) As Boolean _
            Implements ISqlGenerator.IsValidFieldDbDefinition

            Return Not DbDefinition Is Nothing AndAlso Not String.IsNullOrEmpty(DbDefinition.Trim)

        End Function

        Public Function IsPrimaryKeyDbDefinition(ByVal DbDefinition As String) As Boolean _
            Implements ISqlGenerator.IsPrimaryKeyDbDefinition
            Throw New NotSupportedException("Klaida. SQLite failiniame serveryje " & _
                "CREATE TABLE sakinyje indeksai nenurodomi.")
        End Function

        Public Function IsValidIndexDbDefinition(ByVal DbDefinition As String) As Boolean _
            Implements ISqlGenerator.IsValidIndexDbDefinition
            Throw New NotSupportedException("Klaida. SQLite failiniame serveryje " & _
                "CREATE TABLE sakinyje indeksai nenurodomi.")
        End Function

        Public Function IsIndexUniqueInDbDefinition(ByVal DbDefinition As String) As Boolean _
            Implements ISqlGenerator.IsIndexUniqueInDbDefinition
            Return Not DbDefinition Is Nothing AndAlso Not DbDefinition.ToUpper.IndexOf("UNIQUE ") < 0
        End Function

#End Region

#Region "*** DatabaseStructure.DatabaseTable ***"

        Public Function GetCreateTableStatementHeader(ByVal DatabaseName As String, _
            ByVal table As DatabaseAccess.DatabaseStructure.DatabaseTable) As String Implements ISqlGenerator.GetCreateTableStatementHeader
            Return "CREATE TABLE " & table.Name.Trim & "("
        End Function

        Public Function GetCreateTableStatementTail(ByVal table _
            As DatabaseAccess.DatabaseStructure.DatabaseTable) As String _
            Implements ISqlGenerator.GetCreateTableStatementTail
            Return ");"
        End Function

        Public Function GetCreateTableStatementFieldSeparator() As String _
            Implements ISqlGenerator.GetCreateTableStatementFieldSeparator
            Return ", "
        End Function

        Public Function GetCreateTableStatementLeftBracket() As String _
            Implements ISqlGenerator.GetCreateTableStatementLeftBracket
            Return "("
        End Function

        Public Function GetCreateTableStatementRightBracket() As String _
            Implements ISqlGenerator.GetCreateTableStatementRightBracket
            Return ")"
        End Function

        Public Function GetDropTableStatement(ByVal DatabaseName As String, _
            ByVal TableName As String) As String Implements ISqlGenerator.GetDropTableStatement
            Return "DROP TABLE " & TableName.Trim & ";"
        End Function

        Public Sub FetchDatabaseTableFromDbDefinition(ByVal DbDefinition As String, _
            ByRef Name As String, ByRef EngineName As String, ByRef CharsetName As String) _
            Implements ISqlGenerator.FetchDatabaseTableFromDbDefinition

            DbDefinition = DbDefinition.Trim.Replace("`", "").Replace("'", ""). _
                Replace("""", "").Replace("[", "").Replace("]", "")

            Name = DbDefinition.Replace("CREATE TABLE", "").Trim.Substring(0, _
                DbDefinition.Replace("CREATE TABLE", "").Trim.IndexOf("("))

        End Sub

#End Region

#Region "*** DatabaseStructure.DatabaseTableList ***"

        Public Function GetShowCreateTableStatement(ByVal DatabaseName As String, _
            ByVal TableName As String) As String Implements ISqlGenerator.GetShowCreateTableStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris duoda " & _
                "CREATE TABLE statement'us kartu su lentelių sąrašu.")
        End Function

        Public Function GetShowTablesStatement(ByVal DatabaseName As String) As String _
            Implements ISqlGenerator.GetShowTablesStatement
            Return "SELECT name, sql FROM sqlite_master WHERE type='table' AND " & _
                "LOWER(SUBSTR(name,0, 7))<>'sqlite_';"
        End Function

        Public Function GetShowIndexesStatement(ByVal DatabaseName As String) As String _
            Implements ISqlGenerator.GetShowIndexesStatement
            Return "SELECT name, tbl_name, sql FROM sqlite_master WHERE type='index' AND NOT sql IS NULL;"
        End Function

#End Region

#Region "*** DatabaseStructure.DatabaseStoredProcedure ***"

        Public Function GetCreateProcedureStatement(ByVal DatabaseName As String, _
            ByVal procedure As DatabaseAccess.DatabaseStructure.DatabaseStoredProcedure) As String _
            Implements ISqlGenerator.GetCreateProcedureStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris " _
                & "nepalaiko stored procedures.")
        End Function

        Public Function GetDropProcedureStatement(ByVal DatabaseName As String, _
            ByVal procedure As DatabaseAccess.DatabaseStructure.DatabaseStoredProcedure) As String _
            Implements ISqlGenerator.GetDropProcedureStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris " _
                & "nepalaiko stored procedures.")
        End Function

        Public Function GetUpdateProcedureStatement(ByVal DatabaseName As String, _
            ByVal procedure As DatabaseAccess.DatabaseStructure.DatabaseStoredProcedure) As String _
            Implements ISqlGenerator.GetUpdateProcedureStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris " _
                & "nepalaiko stored procedures.")
        End Function

        Public Sub FetchStoredProcedureFromDbDefinition(ByVal DbDefinition As String, _
            ByRef Name As String, ByRef SourceCode As String, ByRef SourceCodeComparable As String) _
            Implements ISqlGenerator.FetchStoredProcedureFromDbDefinition
            Throw New NotSupportedException("Klaida. SQLite failinis serveris " _
                & "nepalaiko stored procedures.")
        End Sub

#End Region

#Region "*** DatabaseStructure.DatabaseStoredProcedureList ***"

        Public Function GetShowCreateProcedureStatement(ByVal DatabaseName As String, _
            ByVal ProcedureName As String) As String _
            Implements ISqlGenerator.GetShowCreateProcedureStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris " _
                & "nepalaiko stored procedures.")
        End Function

        Public Function GetShowProceduresStatement(ByVal DatabaseName As String) As String _
            Implements ISqlGenerator.GetShowProceduresStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris " _
                & "nepalaiko stored procedures.")
        End Function

#End Region

#Region "*** SqlUtilities ***"

        Public Sub CreateDatabaseCustomCode(ByVal DatabaseName As String, ByVal CharsetName As String) _
            Implements ISqlGenerator.CreateDatabaseCustomCode
            Throw New NotSupportedException("Klaida. SQLite duomenų bazių " & _
                "failai sukuriami automatiškai per pirmą prisijungimą.")
        End Sub

        Public Function GetCreateDatabaseStatement(ByVal DatabaseName As String, _
            ByVal CharsetName As String) As String _
            Implements ISqlGenerator.GetCreateDatabaseStatement
            Throw New NotSupportedException("Klaida. SQLite duomenų bazių " & _
                "failai sukuriami automatiškai per pirmą prisijungimą, o ne SQL užklausa.")
        End Function

        Public Sub DoCreateDatabase(ByVal DatabaseName As String, ByVal CharsetName As String) _
            Implements ISqlGenerator.DoCreateDatabase
            ' do nothing, database will be created on first connection
        End Sub

#End Region

#Region "*** UserProfile ***"

        Public Function GetFetchUserProfileStatement() As String _
            Implements ISqlGenerator.GetFetchUserProfileStatement
            Return "SELECT RealName, UserPosition, " _
                & "UserDetails, Signature, UserLevel FROM users WHERE LOWER(TRIM(Name))=" & _
                GetCurrentIdentity().Name.Trim & ";"
        End Function

        Public Function GetUpdateUserProfileStatement() As String _
            Implements ISqlGenerator.GetUpdateUserProfileStatement
            Return "CALL accsecurity.SetUserInfo(?RN, ?SG, ?PS, ?DT, ?LV);"
        End Function

#End Region

#Region "*** DatabaseTableAccessItem ***"

        Public Function GetPrivilegeSqlDefinition(ByVal PrivilegeType As RoleAccessType, _
            ByVal InsertRequiresUpdate As Boolean, ByVal UpdateRequiresInsert As Boolean) As String _
            Implements ISqlGenerator.GetPrivilegeSqlDefinition
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

#End Region

#Region "*** TableAccessLevel ***"

        Public Function GetGrantStatement(ByVal DataBaseName As String, ByVal TableName As String, _
            ByVal UserName As String, ByVal HostName As String, _
            ByVal AccessLevel As DatabaseTableAccessType) As String _
            Implements ISqlGenerator.GetGrantStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

#End Region

#Region "*** Role ***"

        Public Function GetInsertRoleStatement() As String _
            Implements ISqlGenerator.GetInsertRoleStatement
            Return "INSERT INTO roles(UserID, DatabaseName, RoleName, RoleLevel) VALUES($UD, $DN, $RN, $RL);"
        End Function

#End Region

#Region "*** RoleListForDatabase ***"

        Public Function GetGrantAllPrivilegesForDatabase(ByVal cDatabaseName As String, _
            ByVal cUserName As String, ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetGrantAllPrivilegesForDatabase
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

        Public Function GetGrantExecutePrivilegeForDatabase(ByVal cDatabaseName As String, _
            ByVal cUserName As String, ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetGrantExecutePrivilegeForDatabase
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

        Public Function GetGrantPrivilege(ByVal cRole As DataAccessTypes.RoleAccessType, _
            ByVal cDatabaseName As String, ByVal cTableName As String, _
            ByVal cUserName As String, ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetGrantPrivilege
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

        Public Function GetPrivilegeSqlDefinition1(ByVal PrivilegeType As _
            DataAccessTypes.RoleAccessType) As String Implements ISqlGenerator.GetPrivilegeSqlDefinition
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

        Public Function GetRevokeAllPrivilegesForDatabase(ByVal cDatabaseName As String, _
            ByVal cUserName As String, ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetRevokeAllPrivilegesForDatabase
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

        Public Function GetRevokePrivilege(ByVal cRole As DataAccessTypes.RoleAccessType, _
            ByVal cDatabaseName As String, ByVal cTableName As String, _
            ByVal cUserName As String, ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetRevokePrivilege
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

#End Region

#Region "*** User ***"

        Public Function GetFetchUserDataStatement(ByVal cUserName As String, _
            ByVal FetchFromSystemDB As Boolean) As String _
            Implements ISqlGenerator.GetFetchUserDataStatement

            Return "SELECT ID, Name, RealName, UserPosition, UserDetails, " _
                & "Signature, UserLevel FROM users WHERE LOWER(Name)='" & cUserName.Trim.ToLower & "';"

        End Function

        Public Function GetFetchUserRolesStatement(ByVal cUserName As String) As String _
            Implements ISqlGenerator.GetFetchUserRolesStatement

            Return "SELECT R.DatabaseName, R.RoleName, R.RoleLevel FROM roles AS R" _
                & ", users AS U WHERE R.UserID=U.ID AND LOWER(U.Name)='" _
                & cUserName.Trim.ToLower & "' ORDER BY R.DatabaseName;"

        End Function

        Public Function GetInsertUserStatement(ByVal cUser As Security.UserAdministration.User) _
            As String Implements ISqlGenerator.GetInsertUserStatement

            Return "INSERT INTO users (Name, RealName, Password, Signature, " _
                & "UserPosition, UserDetails, UserLevel) VALUES($NM, $RN, $PS, $SG, $UP, $UD, $LV);"

        End Function

        Public Function GetInsertAdminRoleStatement(ByVal UserID As Integer, _
            ByVal AdminRoleName As String) As String _
            Implements ISqlGenerator.GetInsertAdminRoleStatement

            Return "INSERT INTO roles(UserID, DatabaseName, RoleName, RoleLevel) VALUES(" _
                & UserID.ToString & ", '', '" & AdminRoleName & "', 3);"

        End Function

        Public Function GetUpdateUserStatement(ByVal UpdatePassword As Boolean) As String _
            Implements ISqlGenerator.GetUpdateUserStatement

            If UpdatePassword Then
                Return "UPDATE users SET Name=$NM, RealName=$RN, Password=$PS, Signature=$SG, " _
                    & "UserPosition=$UP, UserDetails=$UD, UserLevel=$LV WHERE ID=$UI ;"

            Else
                Return "UPDATE users SET Name=$NM, RealName=$RN, Signature=$SG, " _
                    & "UserPosition=$UP, UserDetails=$UD, UserLevel=$LV WHERE ID=$UI ;"

            End If

        End Function

        Public Function GetCreateUserStatement(ByVal cUserName As String, _
            ByVal cUserHost As String, ByVal cPassword As String) As String _
            Implements ISqlGenerator.GetCreateUserStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

        Public Function GetDeleteAllRolesStatement(ByVal UserID As Integer) As String _
            Implements ISqlGenerator.GetDeleteAllRolesStatement
            Return "DELETE FROM roles WHERE roles.UserID=" & UserID.ToString & ";"
        End Function

        Public Function GetGrantAdminPrivilegesStatement(ByVal cUserName As String, _
            ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetGrantAdminPrivilegesStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

        Public Function GetGrantUsageStatement(ByVal cUserName As String, _
            ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetGrantUsageStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

        Public Function GetRenameUserStatement(ByVal cUserName As String, _
            ByVal cUserHost As String, ByVal cUserNameOld As String, _
            ByVal cUserHostOld As String) As String _
            Implements ISqlGenerator.GetRenameUserStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

        Public Function GetRevokeAdminPrivilegesStatement(ByVal cUserName As String, _
            ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetRevokeAdminPrivilegesStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

        Public Function GetRevokeAllPrivilegesStatement(ByVal cUserName As String, _
            ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetRevokeAllPrivilegesStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

        Public Function GetUpdatePasswordForUserStatement(ByVal cUserName As String, _
            ByVal cUserHost As String, ByVal cPassword As String) As String _
            Implements ISqlGenerator.GetUpdatePasswordForUserStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

        Public Function GetDeleteUserStatement(ByVal UserID As Integer) As String _
            Implements ISqlGenerator.GetDeleteUserStatement
            Return "DELETE FROM users WHERE users.ID=" & UserID.ToString & ";"
        End Function

        Public Function GetDropUserStatement(ByVal cUserName As String, _
            ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetDropUserStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

        Public Function GetFetchNameIsUniqueInSqlServerStatement() As String _
            Implements ISqlGenerator.GetFetchNameIsUniqueInSqlServerStatement
            Throw New NotSupportedException("Klaida. SQLite failinis serveris neturi privilegijų sistemos.")
        End Function

        Public Function GetFetchNameIsUniqueStatement() As String _
            Implements ISqlGenerator.GetFetchNameIsUniqueStatement

            Return "SELECT Name FROM users WHERE LOWER(TRIM(Name))=" _
                & "LOWER(TRIM($NM)) AND LOWER(TRIM(Name))<>LOWER(TRIM($NO));"

        End Function

#End Region

        Public Function GetFullPathToDbFile(ByVal DbFileName As String) As String _
            Implements ISqlGenerator.GetFullPathToDbFile
            Return AppPath() & Path_FileServerDatabaseFiles & "\" & DbFileName & Name_FileServerDatabaseFilesExtension
        End Function

        Public Function GetFetchUserInfoListStatement(ByVal ForCurrentDatabase As Boolean) As String _
            Implements ISqlGenerator.GetFetchUserInfoListStatement

            If ForCurrentDatabase Then
                Return "SELECT s.ID, s.Name, s.RealName FROM users AS s " _
                    & "LEFT JOIN roles AS r ON r.UserID=s.ID " _
                    & "WHERE LOWER(TRIM(r.DatabaseName))=LOWER(TRIM('" & GetCurrentIdentity.Database & "')) " _
                    & "OR LOWER(TRIM(r.RoleName))=LOWER(TRIM('Admin')) GROUP BY s.ID;"
            Else
                Return "SELECT ID, Name, RealName FROM users;"
            End If

        End Function

    End Class

End Namespace