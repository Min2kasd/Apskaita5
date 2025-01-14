﻿Imports AccDataAccessLayer.DatabaseAccess
Namespace Security

    <Serializable()> _
    Public Class DatabaseInfoList
        Inherits Csla.ReadOnlyListBase(Of DatabaseInfoList, DatabaseInfo)

#Region " Business Methods "

        Private _IsFetchedWithErrors As Boolean = False
        Private _ErrorsString As String = ""


        Public ReadOnly Property IsFetchedWithErrors() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsFetchedWithErrors
            End Get
        End Property

        Public ReadOnly Property ErrorsString() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ErrorsString.Trim
            End Get
        End Property


        Public Function DatabaseNameExists(ByVal cName As String) As Boolean
            For Each db As DatabaseInfo In Me
                If db.DatabaseName.Trim.ToLower = cName.Trim.ToLower Then Return True
            Next
            Return False
        End Function

        Friend Function GetNewDatabaseNameByNamingConvention() As String

            Dim max As Integer = 0
            Dim cIdentity As AccIdentity = GetCurrentIdentity()
            For Each db As DatabaseInfo In Me
                If CInt(db.DatabaseName.Trim.Substring(cIdentity.DatabaseNamingConvention.Trim.Length)) > max Then _
                    max = CInt(db.DatabaseName.Trim.Substring(cIdentity.DatabaseNamingConvention.Trim.Length))
            Next
            max += 1

            If max < 10 Then
                Return cIdentity.DatabaseNamingConvention.Trim & "0" & max.ToString
            Else
                Return cIdentity.DatabaseNamingConvention.Trim & max.ToString
            End If

        End Function

        Public Function GetNewLocalDatabaseName(ByVal CompanyName As String) As String

            Dim BasicName As String = GetLocalDatabaseNameByCompanyName(CompanyName)
            For Each db As DatabaseInfo In Me
                If db.DatabaseName.Trim.ToLower = BasicName.Trim.ToLower Then

                    For i As Integer = 2 To 999
                        If Not DatabaseNameExists(BasicName.Trim & i.ToString) Then _
                            Return BasicName.Trim & i.ToString
                    Next

                End If
            Next
            Return BasicName.Trim

        End Function

        Public Shared Function GetLocalDatabaseNameByCompanyName(ByVal CompanyName As String) As String

            If CompanyName Is Nothing OrElse String.IsNullOrEmpty(CompanyName) Then _
                Throw New ArgumentNullException("Klaida. Nenurodytas įmonės pavadinimas.")

            CompanyName = CompanyName.Trim.ToLower.Replace("ą", "a").Replace("č", "c") _
                .Replace("ę", "e").Replace("ė", "e").Replace("į", "i").Replace("š", "s") _
                .Replace("ų", "u").Replace("ū", "u").Replace("ž", "z").Replace("&", " and ") _
                .Replace("  ", " ")
            For Each c As Char In IO.Path.GetInvalidFileNameChars
                CompanyName = CompanyName.Replace(c, "")
            Next

            Dim result As String = ""

            Dim EmptySpace As Boolean = False
            For Each c As Char In CompanyName
                If Char.IsLetterOrDigit(c) Then
                    If EmptySpace Then
                        result = result & Char.ToUpper(c)
                        EmptySpace = False
                    Else
                        result = result & c
                    End If
                ElseIf c = "&" Then
                    result = result & "And"
                ElseIf c = " " Then
                    EmptySpace = True
                End If
            Next

            Return result

        End Function

        Public Function GetCompanyNameByLocalDatabaseName(ByVal LocalDatabaseName As String) As String

            If LocalDatabaseName Is Nothing OrElse String.IsNullOrEmpty(LocalDatabaseName) Then _
                Throw New Exception("Klaida. Nenurodytas įmonės duomenų bazės pavadinimas.")

            LocalDatabaseName = LocalDatabaseName.Trim

            Dim result As String = LocalDatabaseName.Substring(0, 1).ToUpper

            For i As Integer = 2 To LocalDatabaseName.Trim.Length
                If Char.IsUpper(LocalDatabaseName(i - 1)) Then
                    result = result & " " & LocalDatabaseName(i - 1)
                Else
                    result = result & LocalDatabaseName(i - 1)
                End If
            Next

            Return result

        End Function

#End Region

#Region " Factory Methods "

        ' user side cache
        <NonSerialized()> _
        Private Shared _Cache As DatabaseInfoList = Nothing

        Public Shared Function GetDatabaseList() As DatabaseInfoList
            If _Cache Is Nothing Then
                _Cache = DataPortal.Fetch(Of DatabaseInfoList)(New Criteria)
            End If
            Return _Cache
        End Function

        Friend Shared Function GetDatabaseListServerSide() As DatabaseInfoList
            Dim result As New DatabaseInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function

        ''' <summary>
        ''' Clears the in-memory DatabaseList cache 
        ''' so the list of databases is reloaded on
        ''' next request.
        ''' </summary>
        Public Shared Sub InvalidateCache()
            _Cache = Nothing
        End Sub

        Private Sub New()

        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            ' no criteria - we retrieve all resources
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            Dim SqlCommandManager As SqlServerSpecificMethods.ISqlCommandManager = GetSqlCommandManager()

            Dim databaseList As List(Of String) = SqlCommandManager.GetAccesibleDatabaseList

            RaiseListChangedEvents = False
            IsReadOnly = False

            Dim CompanyName As String = ""
            Dim CompanyID As String = ""
            Dim IsLocalUser As Boolean = GetCurrentIdentity.IsLocalUser

            For Each databaseName As String In databaseList

                ' Company data could throw a security error if a user has USAGE privilege,
                ' but no SELECT privilege on Company table; in this case ignore the company,
                ' i.e. do not add it to the accesible company list without throwing
                Try
                    SqlCommandManager.FetchCompanyInfoData(databaseName, CompanyName, CompanyID)
                    Add(New DatabaseInfo(databaseName, CompanyName, CompanyID))
                Catch ex As Exception
                    AddError("Nepavyko prisijungti prie bazės: '" & databaseName _
                        & "'. Klaida: " & ex.Message)
                    Add(New DatabaseInfo(databaseName, "Negauti duomenys", "Negauti duomenys"))
                End Try

            Next

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

        Private Sub AddError(ByVal NewError As String)
            If String.IsNullOrEmpty(_ErrorsString.Trim) Then
                _ErrorsString = NewError
            Else
                _ErrorsString = _ErrorsString & vbCrLf & NewError
            End If
            _IsFetchedWithErrors = True
        End Sub

#End Region

    End Class

End Namespace