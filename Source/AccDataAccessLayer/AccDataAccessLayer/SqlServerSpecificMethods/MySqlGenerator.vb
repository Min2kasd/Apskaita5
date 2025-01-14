﻿Imports AccDataAccessLayer.DatabaseAccess
Namespace SqlServerSpecificMethods

    Friend Class MySqlGenerator
        Implements ISqlGenerator

#Region "*** Properties ***"

        Public ReadOnly Property ShowTablesResultsIncludeCreateTableStatements() As Boolean _
            Implements ISqlGenerator.ShowTablesResultsIncludeCreateTableStatements
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property CreateStatementContainsIndexes() As Boolean _
            Implements ISqlGenerator.CreateStatementContainsIndexes
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property StoredProcedureNameItemInQueryResults() As Integer _
            Implements ISqlGenerator.StoredProcedureNameItemInQueryResults
            Get
                Return 0
            End Get
        End Property

        Public ReadOnly Property StoredProcedureSourceItemInQueryResults() As Integer _
            Implements ISqlGenerator.StoredProcedureSourceItemInQueryResults
            Get
                Return 2
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
                Return True
            End Get
        End Property

        Public ReadOnly Property SupportsUniqueFields() As Boolean _
            Implements ISqlGenerator.SupportsUniqueFields
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property SupportsUsignedFields() As Boolean _
            Implements ISqlGenerator.SupportsUsignedFields
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property SupportsEnumFields() As Boolean _
            Implements ISqlGenerator.SupportsEnumFields
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property ServerType() As DataAccessTypes.SqlServerType _
            Implements ISqlGenerator.ServerType
            Get
                Return SqlServerType.MySQL
            End Get
        End Property

        Public ReadOnly Property DatabaseIsCreatedByConnectionAutomaticaly() As Boolean _
            Implements ISqlGenerator.DatabaseIsCreatedByConnectionAutomaticaly
            Get
                Return True
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
                Return False
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
                Return True
            End Get
        End Property

        Public ReadOnly Property SupportsBlobLength() As Boolean _
            Implements ISqlGenerator.SupportsBlobLength
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property SupportsCharLength() As Boolean _
            Implements ISqlGenerator.SupportsCharLength
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property SupportsDecimalLength() As Boolean _
            Implements ISqlGenerator.SupportsDecimalLength
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property SupportsDoubleLength() As Boolean _
            Implements ISqlGenerator.SupportsDoubleLength
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property SupportsEnums() As Boolean _
            Implements ISqlGenerator.SupportsEnums
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property SupportsIntLength() As Boolean _
            Implements ISqlGenerator.SupportsIntLength
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property SupportsVarCharLength() As Boolean _
            Implements ISqlGenerator.SupportsVarCharLength
            Get
                Return True
            End Get
        End Property

#End Region

#Region "*** DatabaseStructure.DatabaseField ***"

        Public Function GetModifyFieldStatement(ByVal DatabaseName As String, _
            ByVal TableName As String, ByVal field As DatabaseAccess.DatabaseStructure.DatabaseField) As String _
            Implements ISqlGenerator.GetModifyFieldStatement

            Return "ALTER TABLE `" & DatabaseName & "`.`" & TableName _
                & "` MODIFY COLUMN " & GetFieldDbDefinition(field).Replace("PRIMARY KEY", "") & ";"

        End Function

        Public Function GetFieldDbDefinition(ByVal field As DatabaseAccess.DatabaseStructure.DatabaseField) _
            As String Implements ISqlGenerator.GetFieldDbDefinition

            Dim result As String = field.Name.Trim & " " & Me.GetFieldTypeName(field.Type)
            If DatabaseFieldTypeIsChar(field.Type) Then
                result = result & "(" & field.Length.ToString & ") "
            ElseIf field.Type = DatabaseFieldType.Enum Then
                Dim EnumValueArray As String() = field.EnumValues.Split(New Char() _
                    {","c}, StringSplitOptions.RemoveEmptyEntries)
                result = result & "("
                For Each s As String In EnumValueArray
                    result = result & "'" & s.Trim & "', "
                Next
                result = result.Substring(0, result.Length - 2) & ") "
            End If

            If DatabaseFieldTypeIsInteger(field.Type) AndAlso field.Unsigned Then _
                result = result.Trim & " UNSIGNED "

            If field.NotNull Then result = result.Trim & " NOT NULL "

            If DatabaseFieldTypeIsInteger(field.Type) AndAlso field.Autoincrement Then _
                result = result.Trim & " AUTO_INCREMENT "

            If field.PrimaryKey Then result = result.Trim & " PRIMARY KEY "

            Return result.Trim

        End Function

        Public Function GetDropFieldStatement(ByVal DatabaseName As String, _
            ByVal TableName As String, ByVal field As DatabaseAccess.DatabaseStructure.DatabaseField) As String _
            Implements ISqlGenerator.GetDropFieldStatement
            Return "ALTER TABLE `" & DatabaseName.Trim & "`.`" & TableName.Trim _
                & "` DROP COLUMN " & field.Name.Trim & ";"
        End Function

        Public Function GetAddFieldStatement(ByVal DatabaseName As String, ByVal TableName As String, _
            ByVal field As DatabaseAccess.DatabaseStructure.DatabaseField) As String _
            Implements ISqlGenerator.GetAddFieldStatement

            Dim result As String = "ALTER TABLE `" & DatabaseName & "`.`" & TableName _
                & "` ADD COLUMN " & GetFieldDbDefinition(field) & ";"

            If field.NotNull AndAlso field.Type = DatabaseFieldType.Date Then
                result = result & "UPDATE `" & DatabaseName & "`.`" & TableName _
                & "` SET " & field.Name & "='" & (New MySqlCommandManager).DateToDbString(DateTime.UtcNow) & "';"
            ElseIf field.NotNull AndAlso (field.Type = DatabaseFieldType.DateTime OrElse _
                field.Type = DatabaseFieldType.Time) Then
                result = result & "UPDATE `" & DatabaseName & "`.`" & TableName _
                & "` SET " & field.Name & "='" & (New MySqlCommandManager).DateTimeToDbString(DateTime.UtcNow) & "';"
            End If

            Return result

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
            result = result & "`" & field.IndexName.Trim & "` ON `" & DatabaseName.Trim & "`.`" & _
                TableName.Trim & "` (`" & field.Name.Trim & "`);"
            Return result

        End Function

        Public Function GetDropIndexStatement(ByVal DatabaseName As String, ByVal TableName As String, _
            ByVal field As DatabaseAccess.DatabaseStructure.DatabaseField) As String _
            Implements ISqlGenerator.GetDropIndexStatement
            Return "DROP INDEX `" & field.IndexName.Trim & "` ON `" & DatabaseName.Trim & _
                "`.`" & TableName.Trim & "`;"
        End Function

        Public Function GetIndexDbDefinition(ByVal field As DatabaseAccess.DatabaseStructure.DatabaseField) _
            As String Implements ISqlGenerator.GetIndexDbDefinition
            If field.Unique Then
                Return "UNIQUE KEY `" & field.IndexName.Trim & "` (`" & field.Name.Trim & "`)"
            Else
                Return "KEY `" & field.IndexName.Trim & "` (`" & field.Name.Trim & "`)"
            End If
        End Function

        Public Sub FetchDatabaseFieldFromDbDefinition(ByVal DbDefinition As String, _
            ByRef Name As String, ByRef NotNull As Boolean, ByRef Autoincrement As Boolean, _
            ByRef PrimaryKey As Boolean, ByRef Unsigned As Boolean, _
            ByRef FieldType As DataAccessTypes.DatabaseFieldType, ByRef Length As Integer, _
            ByRef EnumValues As String, ByRef Unique As Boolean) _
            Implements ISqlGenerator.FetchDatabaseFieldFromDbDefinition

            Dim cleanDefinition As String = DbDefinition.Trim.Replace("`", "").Replace("'", ""). _
                Replace("""", "").Replace(", ", ",").Trim

            Name = cleanDefinition.Split(New Char() {" "c}, _
                StringSplitOptions.RemoveEmptyEntries)(0).Trim

            cleanDefinition = cleanDefinition.Substring(Name.Length + 1)

            NotNull = cleanDefinition.ToLower.Contains("not null")
            Autoincrement = cleanDefinition.ToLower.Contains("auto_increment")
            PrimaryKey = cleanDefinition.ToLower.Contains("primary key")

            Unsigned = cleanDefinition.ToLower.Contains("unsigned")

            Dim TypeName As String = cleanDefinition.Split(New Char() {" "c}, _
                StringSplitOptions.RemoveEmptyEntries)(0).Trim
            Dim TypeDetails As String = ""
            If TypeName.Contains("(") Then
                TypeDetails = TypeName.Substring(TypeName.IndexOf("(") + 1, _
                    TypeName.IndexOf(")") - TypeName.IndexOf("(") - 1)
                TypeName = TypeName.Substring(0, TypeName.IndexOf("("))
            End If

            FieldType = GetFieldTypeFromDbDefinition(TypeName)

            If FieldType <> DatabaseFieldType.Decimal AndAlso FieldType <> DatabaseFieldType.Double _
                AndAlso FieldType <> DatabaseFieldType.Float AndAlso FieldType <> DatabaseFieldType.Integer _
                AndAlso FieldType <> DatabaseFieldType.IntegerBig AndAlso FieldType <> DatabaseFieldType.IntegerMedium _
                AndAlso FieldType <> DatabaseFieldType.IntegerSmall AndAlso FieldType <> DatabaseFieldType.IntegerTiny _
                AndAlso FieldType <> DatabaseFieldType.Real Then Unsigned = False

            If FieldType = DatabaseFieldType.Char OrElse FieldType = DatabaseFieldType.VarChar Then
                Integer.TryParse(TypeDetails.Trim.Replace("`", "").Replace("'", "").Replace("""", ""), Length)
            ElseIf FieldType = DatabaseFieldType.Enum Then
                EnumValues = TypeDetails.Trim.Replace("`", "").Replace("'", "").Replace("""", "")
            End If

        End Sub

        Public Function DatabaseFieldTypesSimilar(ByVal fieldType1 As DataAccessTypes.DatabaseFieldType, _
            ByVal fieldType2 As DataAccessTypes.DatabaseFieldType) As Boolean _
            Implements ISqlGenerator.DatabaseFieldTypesSimilar

            If (fieldType1 = DatabaseFieldType.Double OrElse _
                fieldType1 = DatabaseFieldType.Real) AndAlso _
                (fieldType2 = DatabaseFieldType.Double OrElse _
                fieldType2 = DatabaseFieldType.Real) Then Return True

            Return fieldType1 = fieldType2

        End Function

        Public Function GetFieldTypeFromDbDefinition(ByVal DbDefinition As String) _
            As DataAccessTypes.DatabaseFieldType _
            Implements ISqlGenerator.GetFieldTypeFromDbDefinition

            Select Case DbDefinition.Trim.ToUpper
                Case "BLOB"
                    Return DatabaseFieldType.Blob
                Case "LONGBLOB"
                    Return DatabaseFieldType.BlobLong
                Case "MEDIUMBLOB"
                    Return DatabaseFieldType.BlobMedium
                Case "TINYBLOB"
                    Return DatabaseFieldType.BlobTiny
                Case "CHAR"
                    Return DatabaseFieldType.Char
                Case "DATE"
                    Return DatabaseFieldType.Date
                Case "DATETIME"
                    Return DatabaseFieldType.DateTime
                Case "DECIMAL"
                    Return DatabaseFieldType.Decimal
                Case "DOUBLE"
                    Return DatabaseFieldType.Double
                Case "ENUM"
                    Return DatabaseFieldType.Enum
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
                    Return DatabaseFieldType.IntegerTiny
                Case "REAL"
                    Return DatabaseFieldType.Real
                Case "TEXT"
                    Return DatabaseFieldType.Text
                Case "LONGTEXT"
                    Return DatabaseFieldType.TextLong
                Case "MEDIUMTEXT"
                    Return DatabaseFieldType.TextMedium
                Case "TIME"
                    Return DatabaseFieldType.Time
                Case "TIMESTAMP"
                    Return DatabaseFieldType.TimeStamp
                Case "VARCHAR"
                    Return DatabaseFieldType.VarChar
                Case Else
                    Throw New NotSupportedException("Klaida. Duomenų tipas '" & _
                        DbDefinition.Trim.ToUpper & "' MySQL serveryje nežinomas.")
            End Select

        End Function

        Public Function GetFieldTypeName(ByVal fieldType As DataAccessTypes.DatabaseFieldType) As String _
            Implements ISqlGenerator.GetFieldTypeName

            Select Case fieldType
                Case DatabaseFieldType.Blob
                    Return "BLOB"
                Case DatabaseFieldType.BlobLong
                    Return "LONGBLOB"
                Case DatabaseFieldType.BlobMedium
                    Return "MEDIUMBLOB"
                Case DatabaseFieldType.BlobTiny
                    Return "TINYBLOB"
                Case DatabaseFieldType.Char
                    Return "CHAR"
                Case DatabaseFieldType.Date
                    Return "DATE"
                Case DatabaseFieldType.DateTime
                    Return "DATETIME"
                Case DatabaseFieldType.Decimal
                    Return "DECIMAL"
                Case DatabaseFieldType.Double
                    Return "DOUBLE"
                Case DatabaseFieldType.Enum
                    Return "ENUM"
                Case DatabaseFieldType.Float
                    Return "FLOAT"
                Case DatabaseFieldType.Integer
                    Return "INT"
                Case DatabaseFieldType.IntegerBig
                    Return "BIGINT"
                Case DatabaseFieldType.IntegerMedium
                    Return "MEDIUMINT"
                Case DatabaseFieldType.IntegerSmall
                    Return "SMALLINT"
                Case DatabaseFieldType.IntegerTiny
                    Return "TINYINT"
                Case DatabaseFieldType.Real
                    Return "DOUBLE"
                Case DatabaseFieldType.Text
                    Return "TEXT"
                Case DatabaseFieldType.TextLong
                    Return "LONGTEXT"
                Case DatabaseFieldType.TextMedium
                    Return "MEDIUMTEXT"
                Case DatabaseFieldType.Time
                    Return "TIME"
                Case DatabaseFieldType.TimeStamp
                    Return "TIMESTAMP"
                Case DatabaseFieldType.VarChar
                    Return "VARCHAR"
                Case Else
                    Throw New NotSupportedException("Klaida. Duomenų tipas '" & _
                        fieldType.ToString & "' MySQL serveryje nežinomas.")
            End Select

        End Function

#End Region

#Region "*** DatabaseStructure.DatabaseFieldList ***"

        Public Function GetIndexNameFromDbDefinition(ByVal DbDefinition As String) As String _
            Implements ISqlGenerator.GetIndexNameFromDbDefinition

            If DbDefinition.Trim.ToUpper.StartsWith("PRIMARY KEY") Then Return ""

            DbDefinition = DbDefinition.Trim.Replace("`", "").Replace("""", ""). _
                Replace("'", "").Replace("KEY", "").Replace("UNIQUE", "").Trim

            Return DbDefinition.Substring(0, DbDefinition.IndexOf("("))

        End Function

        Public Function GetIndexTableNameFromDbDefinition(ByVal DbDefinition As String) As String _
            Implements ISqlGenerator.GetIndexTableNameFromDbDefinition
            Throw New NotSupportedException("Klaida. MySql serverio indeksų apibrėžimuose lentelė nenurodoma.")
        End Function

        Public Function GetIndexColumnNameFromDbDefinition(ByVal DbDefinition As String) As String _
            Implements ISqlGenerator.GetIndexColumnNameFromDbDefinition

            DbDefinition = DbDefinition.Trim.Replace("`", "").Replace("""", ""). _
                Replace("'", "").Trim

            DbDefinition = DbDefinition.Substring(DbDefinition.IndexOf("(") + 1, _
                DbDefinition.IndexOf(")") - DbDefinition.IndexOf("(") - 1)

            If DbDefinition.Contains("(") Then DbDefinition = DbDefinition.Substring(0, DbDefinition.IndexOf("("))

            Return DbDefinition

        End Function

        Public Function IsValidFieldDbDefinition(ByVal DbDefinition As String) As Boolean _
            Implements ISqlGenerator.IsValidFieldDbDefinition

            Return Not DbDefinition Is Nothing AndAlso Not String.IsNullOrEmpty(DbDefinition.Trim) _
                AndAlso (DbDefinition.Trim.StartsWith("`") OrElse DbDefinition.Trim.StartsWith("""") _
                OrElse DbDefinition.Trim.StartsWith("'"))

        End Function

        Public Function IsPrimaryKeyDbDefinition(ByVal DbDefinition As String) As Boolean _
            Implements ISqlGenerator.IsPrimaryKeyDbDefinition

            Return Not DbDefinition Is Nothing AndAlso Not String.IsNullOrEmpty(DbDefinition.Trim) _
                AndAlso DbDefinition.Replace("  ", " ").Trim.ToUpper.StartsWith("PRIMARY KEY")

        End Function

        Public Function IsValidIndexDbDefinition(ByVal DbDefinition As String) As Boolean _
            Implements ISqlGenerator.IsValidIndexDbDefinition

            Return Not DbDefinition Is Nothing AndAlso Not String.IsNullOrEmpty(DbDefinition.Trim) _
                AndAlso (DbDefinition.Replace("  ", " ").Trim.ToUpper.StartsWith("KEY") OrElse _
                DbDefinition.Replace("  ", " ").Trim.ToUpper.StartsWith("UNIQUE KEY"))

        End Function

        Public Function IsIndexUniqueInDbDefinition(ByVal DbDefinition As String) As Boolean _
            Implements ISqlGenerator.IsIndexUniqueInDbDefinition
            Return Not DbDefinition Is Nothing AndAlso Not DbDefinition.ToUpper.IndexOf("UNIQUE ") < 0
        End Function

#End Region

#Region "*** DatabaseStructure.DatabaseTable ***"

        Public Function GetCreateTableStatementHeader(ByVal DatabaseName As String, _
            ByVal table As DatabaseAccess.DatabaseStructure.DatabaseTable) As String _
            Implements ISqlGenerator.GetCreateTableStatementHeader
            Return "CREATE TABLE " & DatabaseName.Trim & "." & table.Name.Trim & "("
        End Function

        Public Function GetCreateTableStatementTail(ByVal table As _
            DatabaseAccess.DatabaseStructure.DatabaseTable) As String _
            Implements ISqlGenerator.GetCreateTableStatementTail

            Dim result As String = ")"

            If Not table.EngineName Is Nothing AndAlso _
                Not String.IsNullOrEmpty(table.EngineName.Trim) Then _
                result = result & " ENGINE=" & table.EngineName.Trim
            If Not table.CharsetName Is Nothing AndAlso _
                Not String.IsNullOrEmpty(table.CharsetName.Trim) Then _
                result = result & " DEFAULT CHARSET=" & table.CharsetName.Trim

            Return result & ";"

        End Function

        Public Sub FetchDatabaseTableFromDbDefinition(ByVal DbDefinition As String, _
            ByRef Name As String, ByRef EngineName As String, ByRef CharsetName As String) _
            Implements ISqlGenerator.FetchDatabaseTableFromDbDefinition

            Try

                Dim result As String

                result = DbDefinition.Trim.Replace("`", "").Replace("'", "").Replace("""", "")

                Name = result.Replace("CREATE TABLE", "").Trim
                Name = Name.Substring(0, Name.IndexOf("("))

                result = result.Substring(result.LastIndexOf(")") + 1).Replace(";", "").Trim

                If result.ToUpper.Contains("ENGINE=") Then
                    If result.Substring(result.IndexOf("ENGINE=")).IndexOf(" ") < 0 Then
                        EngineName = result.Substring(result.IndexOf("ENGINE=") + 7)
                    Else
                        EngineName = result.Substring(result.IndexOf("ENGINE=") + 7, _
                            result.Substring(result.IndexOf("ENGINE=") + 7).IndexOf(" "))
                    End If
                End If

                If result.ToUpper.Contains("CHARSET=") Then
                    If result.Substring(result.IndexOf("CHARSET=")).IndexOf(" ") < 0 Then
                        CharsetName = result.Substring(result.IndexOf("CHARSET=") + 8)
                    Else
                        CharsetName = result.Substring(result.IndexOf("CHARSET=") + 8, _
                            result.Substring(result.IndexOf("CHARSET=") + 8).IndexOf(" "))
                    End If
                End If

            Catch ex As Exception

                Throw New Exception("Failed to parse MySQL table definition string:" _
                    & vbCrLf & DbDefinition, ex)

            End Try


        End Sub

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
            Return "DROP TABLE " & DatabaseName.Trim & "." & TableName.Trim & ";"
        End Function

#End Region

#Region "*** DatabaseStructure.DatabaseTableList ***"

        Public Function GetShowCreateTableStatement(ByVal DatabaseName As String, _
            ByVal TableName As String) As String Implements ISqlGenerator.GetShowCreateTableStatement
            Return "SHOW CREATE TABLE " & DatabaseName.Trim & "." & TableName.Trim & ";"
        End Function

        Public Function GetShowTablesStatement(ByVal DatabaseName As String) As String _
            Implements ISqlGenerator.GetShowTablesStatement
            Return "SHOW TABLES FROM " & DatabaseName.Trim & ";"
        End Function

        Public Function GetShowIndexesStatement(ByVal DatabaseName As String) As String _
            Implements ISqlGenerator.GetShowIndexesStatement
            Throw New NotSupportedException("Klaida. MySql serveryje neįmanoma gauti " & _
                "visų indeksų sąrašo, indeksai yra nurodomi CREATE TABLE statement'uose.")
        End Function

#End Region

#Region "*** DatabaseStructure.DatabaseStoredProcedure ***"

        Public Function GetCreateProcedureStatement(ByVal DatabaseName As String, _
            ByVal procedure As DatabaseAccess.DatabaseStructure.DatabaseStoredProcedure) As String _
            Implements ISqlGenerator.GetCreateProcedureStatement

            If procedure.SourceCode.ToLower.IndexOf(procedure.Name.Trim.ToLower) < 0 Then _
                Throw New Exception("Klaida. Funkcijos kode privalo būti jos pavadinimas.")

            If procedure.SourceCode.Substring(0, procedure.SourceCode.ToLower. _
                IndexOf("begin")).ToLower.Contains("function") Then
                Return "CREATE FUNCTION " & DatabaseName.Trim & "." & procedure.Name.Trim _
                    & procedure.SourceCodeComparable
            Else
                Return "CREATE PROCEDURE " & DatabaseName.Trim & "." & procedure.Name.Trim _
                    & procedure.SourceCodeComparable
            End If

        End Function

        Public Function GetDropProcedureStatement(ByVal DatabaseName As String, _
            ByVal procedure As DatabaseAccess.DatabaseStructure.DatabaseStoredProcedure) As String _
            Implements ISqlGenerator.GetDropProcedureStatement

            If procedure.SourceCode.Substring(0, procedure.SourceCode.ToLower. _
                IndexOf("begin")).ToLower.Contains("function") Then
                Return "DROP FUNCTION IF EXISTS `" & DatabaseName & "`.`" & procedure.Name.Trim & "`;"
            Else
                Return "DROP PROCEDURE IF EXISTS `" & DatabaseName & "`.`" & procedure.Name.Trim & "`;"
            End If

        End Function

        Public Function GetUpdateProcedureStatement(ByVal DatabaseName As String, _
            ByVal procedure As DatabaseAccess.DatabaseStructure.DatabaseStoredProcedure) As String _
            Implements ISqlGenerator.GetUpdateProcedureStatement

            If procedure.SourceCode.ToLower.IndexOf(procedure.Name.Trim.ToLower) < 0 Then _
                Throw New Exception("Klaida. Funkcijos kode privalo būti jos pavadinimas.")

            Dim result As String = GetDropProcedureStatement(DatabaseName, procedure)

            If procedure.SourceCode.Substring(0, procedure.SourceCode.ToLower. _
                IndexOf("begin")).ToLower.Contains("function") Then
                result = result & "CREATE FUNCTION " & DatabaseName.Trim & "." & procedure.Name.Trim _
                    & procedure.SourceCodeComparable
            Else
                result = result & "CREATE PROCEDURE " & DatabaseName.Trim & "." & procedure.Name.Trim _
                    & procedure.SourceCodeComparable
            End If

            Return result

        End Function

        Public Sub FetchStoredProcedureFromDbDefinition(ByVal DbDefinition As String, _
            ByRef Name As String, ByRef SourceCode As String, _
            ByRef SourceCodeComparable As String) Implements ISqlGenerator.FetchStoredProcedureFromDbDefinition

            Dim IsFunction As Boolean = DbDefinition.Trim.Substring(0, DbDefinition.Trim.IndexOf("BEGIN")).ToLower.Contains("function")
            Dim RoutineType As String
            If IsFunction Then
                RoutineType = "function"
            Else
                RoutineType = "procedure"
            End If

            SourceCode = "CREATE " & DbDefinition.Trim.Substring(DbDefinition.Trim.ToLower.IndexOf(RoutineType))
            SourceCode = SourceCode.Trim
            SourceCode = SourceCode.Substring(0, SourceCode.IndexOf("BEGIN")). _
                Replace("`", "").Replace("'", "").Replace("""", "") _
                & SourceCode.Substring(SourceCode.IndexOf("BEGIN"))

            SourceCodeComparable = SourceCode.Substring(SourceCode.IndexOf("("))

        End Sub

#End Region

#Region "*** DatabaseStructure.DatabaseStoredProcedureList ***"

        Public Function GetShowCreateProcedureStatement(ByVal DatabaseName As String, _
            ByVal ProcedureName As String) As String Implements ISqlGenerator.GetShowCreateProcedureStatement
            Return "SHOW CREATE FUNCTION " & DatabaseName.Trim & "." & ProcedureName.Trim & ";"
        End Function

        Public Function GetShowProceduresStatement(ByVal DatabaseName As String) As String _
            Implements ISqlGenerator.GetShowProceduresStatement
            Return "SHOW FUNCTION STATUS WHERE Db='" & DatabaseName.Trim & "';"
        End Function

#End Region

#Region "*** SqlUtilities ***"

        Public Sub CreateDatabaseCustomCode(ByVal DatabaseName As String, ByVal CharsetName As String) _
            Implements ISqlGenerator.CreateDatabaseCustomCode
            Throw New NotSupportedException("Klaida. MySQL duomenų bazės " & _
                "sukuriamos SQL užklausa, o ne specialiu metodu.")
        End Sub

        Public Function GetCreateDatabaseStatement(ByVal DatabaseName As String, _
            ByVal CharsetName As String) As String _
            Implements ISqlGenerator.GetCreateDatabaseStatement
            If String.IsNullOrEmpty(CharsetName.Trim) Then
                Return "CREATE DATABASE " & DatabaseName.Trim & ";"
            Else
                Return "CREATE DATABASE " & DatabaseName.Trim & _
                    " CHARACTER SET " & CharsetName.Trim & ";"
            End If
        End Function

        Public Sub DoCreateDatabase(ByVal DatabaseName As String, ByVal CharsetName As String) _
           Implements ISqlGenerator.DoCreateDatabase

            Dim myComm As New DatabaseAccess.SQLCommand("RawSQL", _
                GetCreateDatabaseStatement(DatabaseName, CharsetName))
            myComm.Execute()

        End Sub


#End Region

#Region "*** UserProfile ***"

        Public Function GetFetchUserProfileStatement() As String _
            Implements ISqlGenerator.GetFetchUserProfileStatement
            If GetCurrentIdentity.IsSecuritySystemInternal Then
                Return "CALL " & GetCurrentIdentity.SecurityDatabase & ".GetUserInfoInternal('" _
                    & GetCurrentIdentity.Name & "', '" & HashPasswordSha256(GetCurrentIdentity.Password) & "');"
            Else
                Return "CALL " & GetCurrentIdentity.SecurityDatabase & ".GetUserInfo;"
            End If
        End Function

        Public Function GetUpdateUserProfileStatement() As String _
            Implements ISqlGenerator.GetUpdateUserProfileStatement
            If GetCurrentIdentity.IsSecuritySystemInternal Then
                Return "CALL accsecurity.SetUserInfoInternal(?RN, ?SG, ?PS, ?DT, ?LV, ?NM, ?PV);"
            Else
                Return "CALL accsecurity.SetUserInfo(?RN, ?SG, ?PS, ?DT, ?LV);"
            End If
        End Function

#End Region

#Region "*** DatabaseTableAccessItem ***"

        Public Function GetPrivilegeSqlDefinition(ByVal PrivilegeType As RoleAccessType, _
                    ByVal InsertRequiresUpdate As Boolean, ByVal UpdateRequiresInsert As Boolean) As String _
                    Implements ISqlGenerator.GetPrivilegeSqlDefinition
            If PrivilegeType = RoleAccessType.None Then
                Return ""
            ElseIf PrivilegeType = RoleAccessType.Read Then
                Return "SELECT"
            ElseIf (PrivilegeType = RoleAccessType.Write AndAlso Not InsertRequiresUpdate) OrElse _
                (PrivilegeType = RoleAccessType.Update AndAlso UpdateRequiresInsert) Then
                Return "SELECT, INSERT"
            ElseIf (PrivilegeType = RoleAccessType.Write AndAlso InsertRequiresUpdate) _
                OrElse (PrivilegeType = RoleAccessType.Update AndAlso Not UpdateRequiresInsert) Then
                Return "SELECT, INSERT, UPDATE, DELETE"
            Else
                Throw New NotSupportedException("Privilegijos tipas '" & _
                    PrivilegeType.ToString & "' nežinomas. Metodas - " & _
                    "DatabaseTableAccessItem.GetPrivilegeSqlDefinition.")
            End If
        End Function

#End Region

#Region "*** TableAccessLevel ***"

        Public Function GetGrantStatement(ByVal DataBaseName As String, ByVal TableName As String, _
                    ByVal UserName As String, ByVal HostName As String, _
                    ByVal AccessLevel As DatabaseTableAccessType) As String _
                    Implements ISqlGenerator.GetGrantStatement

            If AccessLevel = DatabaseTableAccessType.Select Then
                Return "GRANT SELECT ON " & DataBaseName & "." & TableName & " TO '" _
                    & UserName & "'@'" & HostName & "';"
            ElseIf AccessLevel = DatabaseTableAccessType.Insert Then
                Return "GRANT SELECT, INSERT ON " & DataBaseName & "." & TableName _
                    & UserName & "'@'" & HostName & "';"
            ElseIf AccessLevel = DatabaseTableAccessType.Update Then
                Return "GRANT SELECT, INSERT, UPDATE, DELETE ON " & DataBaseName & "." & TableName _
                    & UserName & "'@'" & HostName & "';"
            Else
                Throw New NotSupportedException("Klaida. Duomenų bazės lentelių prieigos tipas '" _
                    & AccessLevel.ToString & "' nežinomas.")
            End If

        End Function

#End Region

#Region "*** Role ***"

        Public Function GetInsertRoleStatement() As String _
            Implements ISqlGenerator.GetInsertRoleStatement
            Return "INSERT INTO roles(UserID, DatabaseName, RoleName, RoleLevel) VALUES(?UD, ?DN, ?RN, ?RL);"
        End Function

#End Region

#Region "*** RoleListForDatabase ***"

        Public Function GetRevokeAllPrivilegesForDatabase(ByVal cDatabaseName As String, _
            ByVal cUserName As String, ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetRevokeAllPrivilegesForDatabase

            Return "REVOKE SELECT, INSERT, UPDATE, DELETE, EXECUTE ON " _
                & cDatabaseName.Trim & ".* FROM '" & cUserName.Trim & "'@'" _
                & cUserHost.Trim & "';"

        End Function

        Public Function GetPrivilegeSqlDefinition(ByVal PrivilegeType As DataAccessTypes.RoleAccessType) _
            As String Implements ISqlGenerator.GetPrivilegeSqlDefinition
            Select Case PrivilegeType
                Case RoleAccessType.None
                    Return ""
                Case RoleAccessType.Read
                    Return "SELECT"
                Case RoleAccessType.Write
                    Return "SELECT, INSERT"
                Case RoleAccessType.Update
                    Return "SELECT, INSERT, UPDATE, DELETE"
                Case Else
                    Throw New NotSupportedException("Privilegijos tipas '" & _
                        PrivilegeType.ToString & "' nežinomas. Metodas - " & _
                        "MySqlGenerator.GetPrivilegeSqlDefinition.")
            End Select
        End Function

        Public Function GetRevokePrivilege(ByVal cRole As DataAccessTypes.RoleAccessType, _
            ByVal cDatabaseName As String, ByVal cTableName As String, _
            ByVal cUserName As String, ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetRevokePrivilege

            Return "REVOKE " & GetPrivilegeSqlDefinition(cRole) & " ON " _
                & cDatabaseName.Trim & "." & cTableName.Trim & " FROM '" & _
                cUserName.Trim & "'@'" & cUserHost.Trim & "'"

        End Function

        Public Function GetGrantAllPrivilegesForDatabase(ByVal cDatabaseName As String, _
            ByVal cUserName As String, ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetGrantAllPrivilegesForDatabase

            Return "GRANT SELECT, INSERT, UPDATE, DELETE, EXECUTE ON " _
                & cDatabaseName.Trim & ".* TO '" & cUserName.Trim & "'@'" _
                & cUserHost.Trim & "';"

        End Function

        Public Function GetGrantExecutePrivilegeForDatabase(ByVal cDatabaseName As String, _
            ByVal cUserName As String, ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetGrantExecutePrivilegeForDatabase

            Return "GRANT EXECUTE ON " & cDatabaseName.Trim & ".* TO '" _
                    & cUserName.Trim & "'@'" & cUserHost.Trim & "';"

        End Function

        Public Function GetGrantPrivilege(ByVal cRole As DataAccessTypes.RoleAccessType, _
            ByVal cDatabaseName As String, ByVal cTableName As String, _
            ByVal cUserName As String, ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetGrantPrivilege

            Return "GRANT " & GetPrivilegeSqlDefinition(cRole) & " ON " _
                & cDatabaseName.Trim & "." & cTableName & " TO '" _
                & cUserName.Trim & "'@'" & cUserHost.Trim & "';"

        End Function

#End Region

#Region "*** User ***"

        Public Function GetFetchUserDataStatement(ByVal cUserName As String, _
           ByVal FetchFromSystemDB As Boolean) As String _
           Implements ISqlGenerator.GetFetchUserDataStatement

            If FetchFromSystemDB Then
                Return "SELECT s.ID, s.Name, s.RealName, s.UserPosition, s.UserDetails, " _
                    & "s.Signature, s.UserLevel, (SELECT SUBSTR(i.GRANTEE, LOCATE('@', i.GRANTEE)+1) " _
                    & "FROM information_schema.USER_PRIVILEGES i " & "WHERE LOCATE('" _
                    & cUserName.Trim.ToLower & "', LOWER(i.GRANTEE))=2 LIMIT 1) " _
                    & "FROM users s WHERE LOWER(s.Name)='" & cUserName.Trim.ToLower & "';"
            Else
                Return "SELECT s.ID, s.Name, s.RealName, s.UserPosition, s.UserDetails, " _
                    & "s.Signature, s.Userlevel FROM users s WHERE LOWER(s.Name)='" _
                    & cUserName.Trim.ToLower & "';"
            End If

        End Function

        Public Function GetFetchUserRolesStatement(ByVal cUserName As String) As String _
            Implements ISqlGenerator.GetFetchUserRolesStatement

            Return "SELECT R.DatabaseName, R.RoleName, R.RoleLevel FROM roles AS R, " _
                & "users AS U WHERE R.UserID=U.ID AND LOWER(U.Name)='" _
                & cUserName.Trim.ToLower & "' ORDER BY R.DatabaseName;"

        End Function

        Public Function GetInsertUserStatement(ByVal cUser As Security.UserAdministration.User) _
            As String Implements ISqlGenerator.GetInsertUserStatement

            Return "INSERT INTO users(Name, RealName, Password, Signature, UserPosition, " _
                & "UserDetails, UserLevel) VALUES(?NM, ?RN, ?PS, ?SG, ?UP, ?UD, ?LV);"

        End Function

        Public Function GetCreateUserStatement(ByVal cUserName As String, _
            ByVal cUserHost As String, ByVal cPassword As String) As String _
            Implements ISqlGenerator.GetCreateUserStatement

            Return "CREATE USER '" & cUserName.Trim & "'@'" & cUserHost.Trim _
                & "' IDENTIFIED BY '" & cPassword.Trim & "';"

        End Function

        Public Function GetGrantUsageStatement(ByVal cUserName As String, _
            ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetGrantUsageStatement

            Return "GRANT USAGE ON *.* TO '" & cUserName.Trim & "'@'" _
                & cUserHost.Trim & "' WITH MAX_USER_CONNECTIONS 20;"

        End Function

        Public Function GetInsertAdminRoleStatement(ByVal UserID As Integer, _
            ByVal AdminRoleName As String) As String _
            Implements ISqlGenerator.GetInsertAdminRoleStatement

            Return "INSERT INTO roles(UserID, DatabaseName, RoleName, RoleLevel) VALUES(" _
                & UserID.ToString & ", '', '" & AdminRoleName & "', 3);"

        End Function

        Public Function GetGrantAdminPrivilegesStatement(ByVal cUserName As String, _
            ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetGrantAdminPrivilegesStatement

            Return "GRANT CREATE, DELETE, FILE, INSERT, SELECT, UPDATE, EXECUTE, " _
                & "SHOW DATABASES ON *.* TO '" & cUserName.Trim & "'@'" _
                & cUserHost.Trim & "' WITH GRANT OPTION;"

        End Function

        Public Function GetRevokeAllPrivilegesStatement(ByVal cUserName As String, _
            ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetRevokeAllPrivilegesStatement

            Return "REVOKE ALL PRIVILEGES, GRANT OPTION FROM '" _
                & cUserName.Trim & "'@'" & cUserHost.Trim & "';"

        End Function

        Public Function GetRevokeAdminPrivilegesStatement(ByVal cUserName As String, _
            ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetRevokeAdminPrivilegesStatement

            Return "REVOKE CREATE, DELETE, FILE, INSERT, SELECT, UPDATE, EXECUTE, " _
                & "SHOW DATABASES ON *.* FROM '" & cUserName.Trim & "'@'" & cUserHost.Trim & "';"

        End Function

        Public Function GetUpdateUserStatement(ByVal UpdatePassword As Boolean) As String _
            Implements ISqlGenerator.GetUpdateUserStatement

            If UpdatePassword Then
                Return "UPDATE users SET Name=?NM, RealName=?RN, Password=?PS, Signature=?SG, " _
                    & "UserPosition=?UP, UserDetails=?UD, UserLevel=?LV WHERE ID=?UI ;"
            Else
                Return "UPDATE users SET Name=?NM, RealName=?RN, Signature=?SG, " _
                    & "UserPosition=?UP, UserDetails=?UD, UserLevel=?LV WHERE ID=?UI ;"
            End If

        End Function

        Public Function GetRenameUserStatement(ByVal cUserName As String, _
            ByVal cUserHost As String, ByVal cUserNameOld As String, _
            ByVal cUserHostOld As String) As String _
            Implements ISqlGenerator.GetRenameUserStatement

            Return "RENAME USER '" & cUserNameOld.Trim & "'@'" & cUserHostOld.Trim _
                & "' TO '" & cUserName.Trim & "'@'" & cUserHost.Trim & "';"

        End Function

        Public Function GetUpdatePasswordForUserStatement(ByVal cUserName As String, _
            ByVal cUserHost As String, ByVal cPassword As String) As String _
            Implements ISqlGenerator.GetUpdatePasswordForUserStatement

            Return "SET PASSWORD FOR '" & cUserName.Trim & "'@'" & _
                cUserHost.Trim & "' = PASSWORD(' " & cPassword.Trim & "');"

        End Function

        Public Function GetDeleteAllRolesStatement(ByVal UserID As Integer) As String _
            Implements ISqlGenerator.GetDeleteAllRolesStatement

            Return "DELETE FROM roles WHERE roles.UserID=" & UserID.ToString & ";"

        End Function

        Public Function GetDeleteUserStatement(ByVal UserID As Integer) As String _
            Implements ISqlGenerator.GetDeleteUserStatement
            Return "DELETE FROM users WHERE users.ID=" & UserID.ToString & ";"
        End Function

        Public Function GetDropUserStatement(ByVal cUserName As String, _
            ByVal cUserHost As String) As String _
            Implements ISqlGenerator.GetDropUserStatement

            Return "DROP USER '" & cUserName.Trim & "'@'" & cUserHost.Trim & "' ;"

        End Function

        Public Function GetFetchNameIsUniqueInSqlServerStatement() As String _
            Implements ISqlGenerator.GetFetchNameIsUniqueInSqlServerStatement

            Return "SELECT DISTINCT U.GRANTEE FROM information_schema.USER_PRIVILEGES " _
                & "U WHERE LOWER(SUBSTR(U.GRANTEE,2, LOCATE('@', U.GRANTEE)-3))=LOWER(?NM) " _
                & "AND LOWER(SUBSTR(U.GRANTEE,2, LOCATE('@', U.GRANTEE)-3))<>LOWER(?NO);"

        End Function

        Public Function GetFetchNameIsUniqueStatement() As String _
            Implements ISqlGenerator.GetFetchNameIsUniqueStatement

            Return "SELECT s.Name FROM users AS s WHERE LOWER(TRIM(s.Name))=" _
                & "LOWER(TRIM(?NM)) AND LOWER(TRIM(s.Name))<>LOWER(TRIM(?NO));"

        End Function

#End Region

        Public Function GetFullPathToDbFile(ByVal DbFileName As String) As String _
            Implements ISqlGenerator.GetFullPathToDbFile
            Throw New NotSupportedException("Klaida. MySQL yra ne failinis serveris, " & _
                "neįmanoma nurodyti path iki failo.")
        End Function

        Public Function GetFetchUserInfoListStatement(ByVal ForCurrentDatabase As Boolean) As String _
            Implements ISqlGenerator.GetFetchUserInfoListStatement

            If ForCurrentDatabase Then
                Return "SELECT s.ID, s.Name, s.RealName FROM users AS s " _
                    & "LEFT JOIN roles AS r ON r.UserID=s.ID " _
                    & "WHERE LOWER(TRIM(r.DatabaseName))=LOWER(TRIM('" & GetCurrentIdentity.Database & "')) " _
                    & "OR LOWER(TRIM(r.RoleName))=LOWER(TRIM('Admin')) GROUP BY s.ID;"
            Else
                Return "SELECT s.ID, s.Name, s.RealName FROM users AS s;"
            End If

        End Function

    End Class

End Namespace