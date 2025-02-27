﻿Imports AccDataAccessLayer.DatabaseAccess
Namespace Security.DatabaseTableAccess

    Friend Structure TableAccessLevel
        Public TableName As String
        Public AccessLevel As DatabaseTableAccessType

        Public Sub New(ByVal nTableName As String, ByVal nAccessLevel As DatabaseTableAccessType)
            TableName = nTableName
            AccessLevel = nAccessLevel
        End Sub

        Public Function GetGrantStatement(ByVal DataBaseName As String, _
            ByVal UserName As String, ByVal HostName As String, _
            ByVal nServerType As SqlServerType) As String

            Dim SqlGenerator As SqlServerSpecificMethods.ISqlGenerator = GetSqlGenerator()
            Return SqlGenerator.GetGrantStatement(DataBaseName, TableName, _
                UserName, HostName, AccessLevel)
            
        End Function

    End Structure

End Namespace