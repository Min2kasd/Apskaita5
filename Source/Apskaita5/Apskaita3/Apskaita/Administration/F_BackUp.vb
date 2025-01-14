﻿Imports System.io
Imports AccDataAccessLayer.Security
Imports AccControlsWinForms
Imports AccDataAccessLayer

Public Class F_BackUp

    Private _CharSetDirPath As String = ""
    Private _BaseDirPath As String = ""
    Private _DefaultFileExtension As String = "sql"


    Private Sub F_BackUp_Activated(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles MyBase.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub BackUp_Load(ByVal sender As Object, _
            ByVal e As System.EventArgs) Handles Me.Load

        SaveAsFileNameTextBox.Text = ""
        OpenFileNameTextbox.Text = ""

        Dim currentIdentity As AccIdentity = GetCurrentIdentity()

        If Not currentIdentity.IsLocalUser Then
            If currentIdentity.ConnectionType <> AccDataAccessLayer.ConnectionType.Local _
                OrElse (currentIdentity.ConnectionType = AccDataAccessLayer.ConnectionType.Local _
                AndAlso currentIdentity.SQLServer.Trim.ToLower <> "localhost" AndAlso _
                currentIdentity.SQLServer.Trim.ToLower <> "127.0.0.1") Then

                MsgBox("Klaida. Duomenų bazių atsargines kopijas galima kurti/atkurti " _
                    & "tik tame pačiame kompiuteryje, kuriame instaliuotas serveris.", _
                    MsgBoxStyle.Exclamation, "Klaida.")
                DisableAllControls(Me)
                Exit Sub

            ElseIf currentIdentity.ConnectionType = AccDataAccessLayer.ConnectionType.Local _
                AndAlso (currentIdentity.SQLServer.Trim.ToLower = "localhost" OrElse _
                currentIdentity.SQLServer.Trim.ToLower = "127.0.0.1") AndAlso _
                currentIdentity.Name.Trim.ToLower <> GetRootName().Trim.ToLower Then

                MsgBox("Klaida. Duomenų bazių atsargines kopijas gali kurti/atkurti " _
                    & "tik pagrindinis (root) vartotojas.", MsgBoxStyle.Exclamation, "Klaida.")
                DisableAllControls(Me)
                Exit Sub

            End If
        End If

        If currentIdentity.SqlServerType = AccDataAccessLayer.SqlServerType.MySQL Then

            Using busy As New StatusBusy
                Try
                    Dim tmp As CharSetDir
                    tmp = CharSetDir.GetCharSetDir
                    _CharSetDirPath = tmp.CharSetDir
                    _BaseDirPath = tmp.BaseDir
                Catch ex As Exception
                    ShowError(ex, Nothing)
                    DisableAllControls(Me)
                End Try
            End Using

            If StringIsNullOrEmpty(_CharSetDirPath) Then

                If Not RequestUserFolder("Klaida. Nenustatytas MySQL serverio CharSet folderis.", _
                    "MySQL CharSet Folderis", "Klaida. Dėl trūkstamų duomenų apie mysql instaliacijos " _
                    & "vietą nebus galimybės atkurti duomenų bazę.", "", "", _CharSetDirPath) Then
                    OpenFileNameTextbox.Enabled = False
                    OpenFileButton2.Enabled = False
                    RecoverFromFileButton.Enabled = False
                End If

            End If

            If StringIsNullOrEmpty(_BaseDirPath) Then

                If Not RequestUserFolder("Klaida. Nenustatytas MySQL serverio instaliacijos folderis.", _
                    "MySQL CharSet Folderis", "Klaida. Dėl trūkstamų duomenų apie mysql instaliacijos " _
                    & "vietą nebus galimybės nei atkurti duomenų bazę, nei sukurti atsarginę kopiją.", _
                    "bin\mysql.exe", "Klaida. Pasirinktas folderis nėra MySQL instaliacija. Dėl trūkstamų " _
                    & "duomenų apie mysql instaliacijos vietą nebus galimybės nei atkurti duomenų bazę, " _
                    & "nei sukurti atsarginę kopiją.", _BaseDirPath) Then
                    DisableAllControls(Me)
                End If

            End If

            If Not StringIsNullOrEmpty(_CharSetDirPath) Then
                _CharSetDirPath = Chr(34) & _CharSetDirPath & Chr(34)
            End If

        End If

        _DefaultFileExtension = "sql"

        If IsLoggedInDB() Then
            SaveAsFileNameTextBox.Text = IO.Path.Combine(Environment.GetFolderPath( _
                Environment.SpecialFolder.Desktop), GetDefaultFileName())
        Else
            SaveAsFileNameTextBox.Enabled = False
            OpenFileButton.Enabled = False
            SaveToFileButton.Enabled = False
        End If

    End Sub


    Private Sub OpenFileButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OpenFileButton.Click

        Using sfd As New SaveFileDialog
            sfd.AddExtension = True
            sfd.DefaultExt = "." & _DefaultFileExtension
            sfd.Filter = String.Format("Atsarginė kopija|*.{0}|Visi failai|*.*", _DefaultFileExtension)
            sfd.ValidateNames = True
            sfd.FileName = GetDefaultFileName()
            If sfd.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
            SaveAsFileNameTextBox.Text = sfd.FileName
        End Using

    End Sub

    Private Sub OpenFileButton2_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OpenFileButton2.Click

        Using ofd As New OpenFileDialog
            ofd.Filter = String.Format("Atsarginė kopija|*.{0}|Visi failai|*.*", _DefaultFileExtension)
            ofd.Multiselect = False
            If ofd.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
            OpenFileNameTextbox.Text = ofd.FileName
        End Using

    End Sub


    Private Function RequestUserFolder(ByVal requestMessage As String, _
        ByVal dialogDescription As String, ByVal errorMessage As String, _
        ByVal fileToCheck As String, ByVal errorFileNotFoundMessage As String, _
        ByRef result As String) As Boolean

        MsgBox(requestMessage, MsgBoxStyle.Exclamation, "")

        Using ofd As New FolderBrowserDialog

            ofd.Description = dialogDescription
            ofd.ShowNewFolderButton = False

            If ofd.ShowDialog <> Windows.Forms.DialogResult.OK Then Return False

            If ofd.SelectedPath Is Nothing OrElse String.IsNullOrEmpty(ofd.SelectedPath.Trim) _
                OrElse Not IO.Directory.Exists(ofd.SelectedPath) Then
                MsgBox(errorMessage, MsgBoxStyle.Exclamation, "Klaida")
                Return False
            End If

            If Not StringIsNullOrEmpty(fileToCheck) _
                AndAlso Not IO.File.Exists(IO.Path.Combine(ofd.SelectedPath, fileToCheck)) Then
                MsgBox(errorFileNotFoundMessage, MsgBoxStyle.Exclamation, "Klaida")
                Return False
            End If

            result = ofd.SelectedPath

        End Using

        Return True

    End Function


    Private Sub SaveToFileButton_Click(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles SaveToFileButton.Click

        If StringIsNullOrEmpty(SaveAsFileNameTextBox.Text) Then
            MsgBox("Klaida. Nenurodytas failo pavadinimas.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Dim currentIdentity As AccIdentity = GetCurrentIdentity()

        If Not IsLoggedInDB() Then
            MsgBox("Klaida. Neprisijungta prie jokios duomenų bazės.", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Try
            Using busy As New StatusBusy
                If currentIdentity.IsLocalUser Then
                    LocalUserMakeBackUp(currentIdentity)
                ElseIf currentIdentity.SqlServerType = AccDataAccessLayer.SqlServerType.MySQL Then
                    MySqlMakeBackUp(currentIdentity)
                Else
                    Throw New NotImplementedException(String.Format( _
                        "Klaida. SQL serverio tipas {0} nepalaikomas.", _
                        currentIdentity.SqlServerType.ToString))
                End If
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
            Exit Sub
        End Try

        MsgBox("Įmonės duomenų bazės atsarginė kopija sėkmingai sukurta.", _
            MsgBoxStyle.Information, "Info")

        Me.Close()

    End Sub

    Private Sub LocalUserMakeBackUp(ByVal currentIdentity As AccIdentity)

        Dim oldPass As String = ""
        If Not StringIsNullOrEmpty(currentIdentity.Password) Then
            oldPass = currentIdentity.Password
            Try
                CommandChangePassword.TheCommand(oldPass, "", "")
            Catch ex As Exception
                Throw New Exception("Klaida. Nepavyko laikinai nuimti slaptažodžio: " & ex.Message, ex)
            End Try
        End If

        Try

            Using busy As New StatusBusy

                Using shellProcess As New Process

                    shellProcess.StartInfo.FileName = "cmd.exe"
                    shellProcess.StartInfo.UseShellExecute = False
                    shellProcess.StartInfo.WorkingDirectory = AppPath()
                    shellProcess.StartInfo.RedirectStandardInput = True
                    shellProcess.StartInfo.RedirectStandardOutput = True
                    shellProcess.StartInfo.RedirectStandardError = True
                    shellProcess.Start()
                    Dim myStreamWriter As StreamWriter = shellProcess.StandardInput
                    Dim cmdText As String = "sqlite3.exe " & Chr(34) & GetFullPathToSQLiteDbFile( _
                        currentIdentity.Database).Trim & Chr(34) & " .dump > " & Chr(34) _
                        & SaveAsFileNameTextBox.Text & Chr(34)
                    myStreamWriter.WriteLine(IO.Path.GetPathRoot(AppPath()).Substring(0, 2))
                    myStreamWriter.WriteLine("cd " & AppPath())
                    myStreamWriter.WriteLine(cmdText)
                    myStreamWriter.Close()

                    shellProcess.WaitForExit()

                    Dim standardError As String = shellProcess.StandardError.ReadToEnd
                    If Not StringIsNullOrEmpty(standardError) Then
                        shellProcess.Close()
                        Throw New Exception(standardError & vbCrLf & vbCrLf _
                            & GetSystemState(SaveAsFileNameTextBox.Text))
                    End If

                    shellProcess.Close()

                End Using

            End Using

        Catch ex As Exception

            If Not StringIsNullOrEmpty(oldPass) Then
                Try
                    CommandChangePassword.TheCommand("", oldPass, oldPass)
                Catch e As Exception
                    Throw New Exception("Klaida kuriant atsarginę kopiją: " & ex.Message _
                        & vbCrLf & "Klaida. Nepavyko grąžinti laikinai nuimto slaptažodžio: " & e.Message, ex)
                End Try
            End If

            Throw New Exception("Klaida kuriant atsarginę kopiją: " & ex.Message, ex)

        End Try

        If Not StringIsNullOrEmpty(oldPass) Then
            Try
                CommandChangePassword.TheCommand("", oldPass, oldPass)
            Catch e As Exception
                MsgBox("Klaida. Nepavyko grąžinti laikinai nuimto slaptažodžio: " _
                    & e.Message, MsgBoxStyle.Exclamation, "")
            End Try
        End If

    End Sub

    Private Sub MySqlMakeBackUp(ByVal currentIdentity As AccIdentity)
        Try
            Using shellProcess As New Process

                If StringIsNullOrEmpty(_BaseDirPath) Then
                    shellProcess.StartInfo.FileName = "mysqldump.exe"
                Else
                    shellProcess.StartInfo.FileName = IO.Path.Combine(IO.Path.Combine( _
                        _BaseDirPath, "bin"), "mysqldump.exe")
                End If
                shellProcess.StartInfo.Arguments = "--opt --user=root --password=" & _
                    currentIdentity.Password & " --no-create-db --routines --result-file=" & Chr(34) & _
                    SaveAsFileNameTextBox.Text & Chr(34) & " " & currentIdentity.Database
                shellProcess.StartInfo.WorkingDirectory = IO.Path.Combine(_BaseDirPath, "bin")
                shellProcess.StartInfo.UseShellExecute = False
                shellProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                shellProcess.StartInfo.RedirectStandardError = True

                shellProcess.Start()

                shellProcess.WaitForExit()

                Dim standardError As String = shellProcess.StandardError.ReadToEnd
                If Not StringIsNullOrEmpty(standardError) Then
                    If standardError.ToLower.Contains("warning") Then
                        MsgBox("Įspėjimas. Kuriant duomenų bazės atsarginę kopija galėjo kilti klaida: " _
                               & standardError, MsgBoxStyle.Information, "Įspėjimas")
                    Else
                        shellProcess.Close()
                        Throw New Exception(standardError & vbCrLf & vbCrLf _
                            & GetSystemState(SaveAsFileNameTextBox.Text))
                    End If
                End If

                shellProcess.Close()

            End Using

        Catch ex As Exception
            Throw New Exception("Klaida kuriant atsarginę kopiją: " & ex.Message, ex)
        End Try
    End Sub


    Private Sub RecoverFromFile_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RecoverFromFileButton.Click

        If StringIsNullOrEmpty(OpenFileNameTextbox.Text) Then Exit Sub

        Dim fileTimeStamp As String

        Try
            Dim tf As New FileInfo(OpenFileNameTextbox.Text)

            If Not tf.Exists Then
                MsgBox("Klaida. Nepasirinktas atsarginės kopijos dokumentas.", _
                    MsgBoxStyle.Exclamation, "Klaida.")
                Exit Sub
            End If

            fileTimeStamp = tf.CreationTime.ToShortDateString _
                & " " & tf.CreationTime.ToShortTimeString

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko įkrauti atsarginės kopijos failo: " & ex.Message, ex), Nothing)
            Exit Sub
        End Try

        Dim currentIdentity As AccIdentity = GetCurrentIdentity()

        If Not currentIdentity.IsLocalUser AndAlso StringIsNullOrEmpty(_CharSetDirPath) Then
            MsgBox("Klaida. Duomenų bazės atkūrimui trūksta duomenų (nežinomas CharSetDir kelias).", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        If Not currentIdentity.IsLocalUser AndAlso StringIsNullOrEmpty(_BaseDirPath) Then
            MsgBox("Klaida. Duomenų bazės atkūrimui trūksta duomenų (nežinomas MySQL instaliacijos kelias).", _
                MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If


        Dim backupCompanyName As String = ""
        Dim backupCompanyCode As String = ""
        Dim backupContainsCreateDatabase As Boolean

        Try
            Using busy As New StatusBusy

                If currentIdentity.IsLocalUser Then
                    SQLiteGetCompanyDataFromBackupFile(OpenFileNameTextbox.Text, backupCompanyName, _
                        backupCompanyCode, backupContainsCreateDatabase)
                ElseIf currentIdentity.SqlServerType = AccDataAccessLayer.SqlServerType.MySQL Then
                    MySqlGetCompanyDataFromBackupFile(OpenFileNameTextbox.Text, backupCompanyName, _
                        backupCompanyCode, backupContainsCreateDatabase)
                Else
                    Throw New NotImplementedException(String.Format( _
                        "Klaida. SQL serverio tipas {0} nepalaikomas.", _
                        currentIdentity.SqlServerType.ToString))
                End If

            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
            Exit Sub
        End Try

        Dim dbList As DatabaseInfoList
        Try
            Using busy As New StatusBusy
                dbList = DatabaseInfoList.GetDatabaseList
            End Using
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti įmonių sąrašo.", ex), Nothing)
            Exit Sub
        End Try

        If IsLoggedInDB() Then

            Try
                Using busy As New StatusBusy
                    AccPrincipal.Login("", New CustomCacheManager)
                    DirectCast(CurrentMdiParent, MDIParent1).LogOffToGUI()
                End Using
            Catch ex As Exception
                ShowError(ex, Nothing)
                Exit Sub
            End Try

        End If

        Dim existingDb As Boolean = False
        Dim indexExistingDb As Integer = 0
        For i As Integer = 1 To dbList.Count

            If Not StringIsNullOrEmpty(backupCompanyCode) AndAlso _
                dbList(i - 1).Id.Trim.ToLower = backupCompanyCode.Trim.ToLower Then
                existingDb = True
                indexExistingDb = i - 1
            ElseIf StringIsNullOrEmpty(backupCompanyCode) AndAlso _
                (dbList(i - 1).CompanyName.Trim.ToLower = backupCompanyName.Trim.ToLower _
                OrElse dbList(i - 1).DatabaseName.Trim.ToLower = dbList.GetNewLocalDatabaseName( _
                backupCompanyName.Trim)) Then
                existingDb = True
                indexExistingDb = i - 1
            End If

        Next

        Dim ats As String = ""
        If existingDb Then

            String.Format("DĖMESIO. Atsarginėje kopijoje išsaugoti įmonės duomenys:{0}duomenų bazė - {1}, įmonės pavadinimas - {2}, kodas - {3}.{4}Duomenų bazės atsarginė kopija buvo padaryta {5}.{6}Atkūrus duomenų bazę iš šios atsarginės kopijos, visų vėliau registruotų operacijų duomenys bus negrįžtamai prarasti. Ar tikrai norite atkurti duomenų bazę iš atsarginės kopijos?", _
                vbCrLf, dbList(indexExistingDb).DatabaseName, dbList(indexExistingDb).CompanyName, _
                dbList(indexExistingDb).Id, vbCrLf, fileTimeStamp, vbCrLf)

            ats = Ask(String.Format("DĖMESIO. Atsarginėje kopijoje išsaugoti įmonės duomenys:{0}duomenų bazė - {1}, įmonės pavadinimas - {2}, kodas - {3}.{4}Duomenų bazės atsarginė kopija buvo padaryta {5}.{6}Atkūrus duomenų bazę iš šios atsarginės kopijos, visų vėliau registruotų operacijų duomenys bus negrįžtamai prarasti. Ar tikrai norite atkurti duomenų bazę iš atsarginės kopijos?", _
                vbCrLf, dbList(indexExistingDb).DatabaseName, dbList(indexExistingDb).CompanyName, _
                dbList(indexExistingDb).Id, vbCrLf, fileTimeStamp, vbCrLf), _
                New ButtonStructure("Atkurti", "Perrašyti duomenis ""ant viršaus""."), _
                New ButtonStructure("Įtraukti naują", "Sukurti naują įmonę pagal atsarginės kopijos duomenis."), _
                New ButtonStructure("Atšaukti", "Nieko nedaryti."))
            If ats = "Atšaukti" Then Exit Sub
        Else
            If Not YesOrNo(String.Format("Sukurti naują duomenų bazę įmonei ""{0}""?", _
                backupCompanyName)) Then Exit Sub
        End If

        Dim modifiedBackupFilePath As String = OpenFileNameTextbox.Text
        If backupContainsCreateDatabase Then

            ' defining backup file encoding
            Dim enc As System.Text.Encoding = Nothing
            'Try
            '    enc = GetFileEncoding(OpenFileNameTextbox.Text, True)
            'Catch ex As Exception
            '    If Not YesOrNo("Dėmesio. Nepavyko identifikuoti atsarginės kopijos failo " _
            '        & "duomenų koduotės (encoding). Gali būti blogai atkurti lietuviškų " _
            '        & "raidžių simboliai. Ar norite tęsti atkūrimą?") Then Exit Sub
            'End Try

            Try
                Using busy As New StatusBusy

                    If currentIdentity.IsLocalUser Then
                        ' do nothing, sqlite file cannot contain create database
                    ElseIf currentIdentity.SqlServerType = AccDataAccessLayer.SqlServerType.MySQL Then
                        modifiedBackupFilePath = MySqlCreateCleanBackupFile(modifiedBackupFilePath, enc)
                    Else
                        Throw New NotImplementedException(String.Format( _
                            "Klaida. SQL serverio tipas {0} nepalaikomas.", _
                            currentIdentity.SqlServerType.ToString))
                    End If

                End Using
            Catch ex As Exception
                ShowError(ex, Nothing)
                Exit Sub
            End Try

        End If

        Try
            Using busy As New StatusBusy

                Dim dbNameToRestore As String = ""
                If ats = "Atkurti" Then
                    dbNameToRestore = dbList(indexExistingDb).DatabaseName
                End If
                If currentIdentity.IsLocalUser Then
                    SqliteRestoreDatabase(modifiedBackupFilePath, dbNameToRestore, backupCompanyName)
                ElseIf currentIdentity.SqlServerType = AccDataAccessLayer.SqlServerType.MySQL Then
                    MySqlRestoreDatabase(modifiedBackupFilePath, dbNameToRestore)
                Else
                    Throw New NotImplementedException(String.Format( _
                        "Klaida. SQL serverio tipas {0} nepalaikomas.", _
                        currentIdentity.SqlServerType.ToString))
                End If

            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
            Exit Sub
        End Try

        MsgBox(String.Format("Įmonės ""{0}"" duomenų bazė sėkmingai atkurta.{1}Atkūrimo data ir laikas: {2}.", _
            backupCompanyName, vbCrLf, fileTimeStamp), MsgBoxStyle.Information, "Info")

        DatabaseInfoList.InvalidateCache()
        Try
            Using busy As New StatusBusy
                dbList = DatabaseInfoList.GetDatabaseList
                DirectCast(CurrentMdiParent, MDIParent1).DatabasesToMenu()
            End Using
        Catch ex As Exception
            ShowError(New Exception(String.Format("Klaida. Nepavyko atnaujinti duomenų bazių sąrašo po atkūrimo:{0}{1}",
                vbCrLf, ex.Message), ex), Nothing)
        End Try

        Try
            If modifiedBackupFilePath.Trim <> OpenFileNameTextbox.Text.Trim AndAlso _
                IO.File.Exists(modifiedBackupFilePath) Then
                IO.File.Delete(modifiedBackupFilePath)
            End If
        Catch ex As Exception
            ' may warn the user that modified backup copy remains in program folder?
        End Try

        Me.Close()

    End Sub

    Private Sub MySqlGetCompanyDataFromBackupFile(ByVal backupFilePath As String, _
        ByRef companyName As String, ByRef companyCode As String, _
        ByRef backupContainsCreateDatabase As Boolean)

        companyName = ""
        companyCode = ""
        backupContainsCreateDatabase = False

        Dim containsPragma As Boolean = False
        Dim containsCompany As Boolean = False

        Using objReader As StreamReader = New StreamReader(backupFilePath)

            Dim s As String

            While objReader.Peek <> -1

                s = objReader.ReadLine()

                If s.Contains("INSERT") And s.Trim.ToLower.Contains("`imone`") Then

                    companyName = s.Substring(s.IndexOf(",'") + 2, _
                        s.IndexOf("'", s.IndexOf(",'") + 2) - s.IndexOf(",'") - 2)

                    companyCode = s.Substring(s.IndexOf("(") + 1, s.IndexOf(",") - s.IndexOf("(") - 1)

                    containsCompany = True

                    Exit While

                ElseIf s.Contains("CREATE DATABASE") Then
                    backupContainsCreateDatabase = True
                ElseIf s.Contains("PRAGMA ") Then
                    containsPragma = True
                End If
            End While

            objReader.Close()

        End Using

        If containsPragma Then
            Throw New Exception("Klaida. Atsarginės kopijos failas buvo sukurtas ne MySQL duomenų bazei.")
        End If
        If Not containsCompany Then
            Throw New Exception("Klaida. Atsarginės kopijos faile nėra saugoma įmonės apskaitos duomenų bazė.")
        End If

    End Sub

    Private Sub SQLiteGetCompanyDataFromBackupFile(ByVal backupFilePath As String, _
        ByRef companyName As String, ByRef companyCode As String, _
        ByRef backupContainsCreateDatabase As Boolean)

        companyName = ""
        companyCode = ""
        backupContainsCreateDatabase = False

        Dim containsPragma As Boolean = False
        Dim containsCompany As Boolean = False

        Using objReader As New StreamReader(backupFilePath)

            Dim s As String

            While objReader.Peek <> -1

                s = objReader.ReadLine()

                If s.Contains("INSERT") And s.Trim.ToLower.Contains("""imone""") Then

                    companyName = s.Substring(s.IndexOf(",'") + 2, _
                        s.IndexOf("'", s.IndexOf(",'") + 2) - s.IndexOf(",'") - 2)

                    companyCode = s.Substring(s.IndexOf("(") + 1, s.IndexOf(",") - s.IndexOf("(") - 1)

                    containsCompany = True

                    If containsPragma Then Exit While

                ElseIf s.Contains("PRAGMA ") Then

                    containsPragma = True
                    If containsCompany Then Exit While

                End If

            End While

            objReader.Close()

        End Using

        If Not containsPragma Then
            Throw New Exception("Klaida. Atsarginės kopijos failas buvo sukurtas ne SQLite duomenų bazei.")
        End If
        If Not containsCompany Then
            Throw New Exception("Klaida. Atsarginės kopijos faile nėra saugoma įmonės apskaitos duomenų bazė.")
        End If

    End Sub

    Private Function MySqlCreateCleanBackupFile(ByVal backupFilePath As String, _
        ByVal backupFileEncoding As System.Text.Encoding) As String

        Dim modifiedBackupFilePath As String = IO.Path.Combine(IO.Path.GetTempPath, "tmp_backup.sql")

        If backupFileEncoding Is Nothing Then
            backupFileEncoding = New System.Text.UTF8Encoding(False)
        End If


        Using busy As New StatusBusy

            Using objWriter As New StreamWriter(modifiedBackupFilePath, False, backupFileEncoding)

                Using objReader As New StreamReader(backupFilePath)

                    Dim s As String

                    While objReader.Peek <> -1

                        s = objReader.ReadLine()
                        If Not s.Trim.StartsWith("CREATE DATABASE ") AndAlso _
                            Not s.Trim.StartsWith("USE ") Then
                            objWriter.WriteLine(s)
                        End If

                    End While

                    objReader.Close()

                End Using

                objWriter.Close()

            End Using

        End Using

        Return modifiedBackupFilePath

    End Function

    Private Sub MySqlRestoreDatabase(ByVal modifiedBackupFilePath As String, _
        ByRef dbNameToRestore As String)

        Dim newDbCreated As Boolean = False

        If StringIsNullOrEmpty(dbNameToRestore) Then

            Try
                dbNameToRestore = AccDataAccessLayer.Security.CommandGetNewDatabaseName. _
                    TheCommand("")
            Catch ex As Exception
                Throw New Exception("Klaida. Nepavyko gauti naujos duomenų bazės pavadinimo.", ex)
            End Try

            Try
                Dim myComm As New SQLCommand("RawSQL", String.Format("CREATE DATABASE {0} CHARACTER SET=cp1257;", _
                    dbNameToRestore.Trim))
                myComm.Execute()
                newDbCreated = True
            Catch ex As Exception
                Throw New Exception("Klaida. Nepavyko sukurti naujos duomenų bazės.", ex)
            End Try

        End If

        Dim cmdText As String = "mysql --user=root --password=" & GetCurrentIdentity.Password _
            & " --character-sets-dir=" & _CharSetDirPath & " " & dbNameToRestore & " < " _
            & Chr(34) & modifiedBackupFilePath & Chr(34)

        Using myProcess As New Process()

            myProcess.StartInfo.FileName = "cmd.exe"
            myProcess.StartInfo.UseShellExecute = False
            myProcess.StartInfo.WorkingDirectory = IO.Path.Combine(_BaseDirPath, "bin")
            myProcess.StartInfo.RedirectStandardInput = True
            myProcess.StartInfo.RedirectStandardOutput = True
            myProcess.StartInfo.RedirectStandardError = True

            myProcess.Start()

            Dim myStreamWriter As StreamWriter = myProcess.StandardInput
            If Not StringIsNullOrEmpty(_BaseDirPath) Then
                myStreamWriter.WriteLine(IO.Path.GetPathRoot(_BaseDirPath).Substring(0, 2))
                myStreamWriter.WriteLine("cd " & _BaseDirPath)
            End If
            myStreamWriter.WriteLine(cmdText)
            myStreamWriter.Close()

            myProcess.WaitForExit()

            Dim standardError As String = myProcess.StandardError.ReadToEnd
            If Not StringIsNullOrEmpty(standardError) Then

                If standardError.ToLower.Contains("warning") Then

                    MsgBox("Įspėjimas. Atkuriant duomenų bazę galėjo kilti klaida: " & standardError, MsgBoxStyle.Information, "Įspėjimas")

                Else

                    If newDbCreated Then

                        Try
                            Dim myComm As New SQLCommand("RawSQL", "DROP DATABASE " & dbNameToRestore.Trim & ";")
                            myComm.Execute()
                        Catch ex As Exception
                            myProcess.Close()
                            Throw New Exception("Klaida atkuriant atsarginę kopiją: " & standardError & vbCrLf _
                                & "Klaida. Nepavyko panaikinti naujos (tuščios) duomenų bazės: " & ex.Message, ex)
                        End Try

                    End If

                    myProcess.Close()

                    Throw New Exception("Klaida atkuriant atsarginę kopiją: " & standardError _
                        & vbCrLf & vbCrLf & GetSystemState(modifiedBackupFilePath))

                End If

            End If

            myProcess.Close()

        End Using

    End Sub

    Private Sub SqliteRestoreDatabase(ByVal modifiedBackupFilePath As String, _
        ByRef dbNameToRestore As String, ByVal newCompanyName As String)

        Dim dbHasBeenBackedUp As Boolean = False

        Dim dbBackupPath As String = IO.Path.Combine(IO.Path.GetTempPath, "temp_sqlite.bak")
        Try
            If IO.File.Exists(dbBackupPath) Then
                IO.File.Delete(dbBackupPath)
            End If
        Catch ex As Exception
        End Try

        Dim dbFilePath As String

        If StringIsNullOrEmpty(dbNameToRestore) Then

            Try
                dbNameToRestore = AccDataAccessLayer.Security.CommandGetNewDatabaseName. _
                    TheCommand(newCompanyName)
            Catch ex As Exception
                Throw New Exception("Klaida. Nepavyko gauti naujos duomenų bazės pavadinimo.", ex)
            End Try

            dbFilePath = GetFullPathToSQLiteDbFile(dbNameToRestore.Trim)

        Else

            dbFilePath = GetFullPathToSQLiteDbFile(dbNameToRestore.Trim)

            Try
                IO.File.Copy(dbFilePath, dbBackupPath)
                IO.File.Delete(dbFilePath)
            Catch ex As Exception
                Throw New Exception("Klaida. Nepavyko backupinti atnaujinamos duomenų bazės: " & ex.Message, ex)
            End Try

            dbHasBeenBackedUp = True

        End If

        Dim cmdText As String = "sqlite3 " & Chr(34) & dbFilePath & Chr(34) & " < " _
            & Chr(34) & modifiedBackupFilePath & Chr(34)

        Using myProcess As New Process()

            myProcess.StartInfo.FileName = "cmd.exe"
            myProcess.StartInfo.UseShellExecute = False
            myProcess.StartInfo.WorkingDirectory = AppPath()
            myProcess.StartInfo.RedirectStandardInput = True
            myProcess.StartInfo.RedirectStandardOutput = True
            myProcess.StartInfo.RedirectStandardError = True

            myProcess.Start()

            Dim myStreamWriter As StreamWriter = myProcess.StandardInput
            myStreamWriter.WriteLine(IO.Path.GetPathRoot(AppPath()).Substring(0, 2))
            myStreamWriter.WriteLine("cd " & AppPath())
            myStreamWriter.WriteLine(cmdText)
            myStreamWriter.Close()

            myProcess.WaitForExit()

            Dim standardError As String = myProcess.StandardError.ReadToEnd
            If Not StringIsNullOrEmpty(standardError) Then

                If dbHasBeenBackedUp Then
                    Try
                        IO.File.Copy(dbBackupPath, dbFilePath)
                        IO.File.Delete(dbBackupPath)
                    Catch ex As Exception
                        myProcess.Close()
                        Throw New Exception("Klaida atkuriant atsarginę kopiją: " & standardError _
                            & vbCrLf & "DĖMESIO. Sugadintas pirminis duomenų bazės failas.", ex)
                    End Try
                End If

                myProcess.Close()

                Throw New Exception("Klaida atkuriant atsarginę kopiją: " & standardError _
                    & vbCrLf & vbCrLf & GetSystemState(modifiedBackupFilePath))

            End If

            myProcess.Close()

        End Using

        If dbHasBeenBackedUp Then
            Try
                IO.File.Delete(dbBackupPath)
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Function GetDefaultFileName() As String
        Return DatabaseInfoList.GetLocalDatabaseNameByCompanyName( _
            GetCurrentCompany.Name) & Today.ToString("yyyyMMdd") _
            & "." & _DefaultFileExtension
    End Function

    'Private Function LocalUserRestoreFromBackUp(ByVal CurrentIdentity As AccIdentity, _
    '    ByVal FileTimeStamp As String) As Boolean

    '    Dim BackupCompanyName, BackupCompanyCode, OriginalCompanyName, OriginalCompanyCode As String

    '    Try
    '        FetchCompanyFromDbFile(OpenFileNameTextbox.Text, AccDataAccessLayer.SqlServerType.SQLite, _
    '            BackupDatabasePasswordTextBox.Text.Trim, BackupCompanyName, BackupCompanyCode)
    '    Catch ex As Exception
    '        ShowError(New Exception("Klaida. Nepavyko atidaryti atsarginės kopijos failo. " _
    '            & ex.Message, ex))
    '        Return False
    '    End Try

    '    Dim DbList As DatabaseInfoList
    '    Try
    '        DbList = DatabaseInfoList.GetDatabaseList
    '    Catch ex As Exception
    '        ShowError(New Exception("Klaida. Nepavyko gauti įmonių sąrašo", ex))
    '        Return False
    '    End Try

    '    If RecoveryTargetDbComboBox.SelectedIndex = 0 Then

    '        Dim NewDbFileName As String = DbList.GetLocalDatabaseNameByCompanyName(BackupCompanyName)

    '        If DbList.DatabaseNameExists(NewDbFileName) Then

    '            Dim NewDbFileNameModified As String = DbList.GetNewLocalDatabaseName(BackupCompanyName)

    '            If Not YesOrNo("Duomenų bazė pavadinimu '" & NewDbFileName _
    '                & "' jau yra. Įtraukti pavadinimu '" & NewDbFileNameModified & "'?") Then Return False

    '            NewDbFileName = NewDbFileNameModified

    '        Else

    '            If Not YesOrNo("Atsarginės kopijos failas buvo sukurtas " & FileTimeStamp _
    '                & ". Jame saugomi duomenys apie įmonę '" & BackupCompanyName.Trim _
    '                & "', kurios kodas yra " & BackupCompanyCode.Trim _
    '                & ". Sukurti naują duomenų bazę pavadinimu '" & NewDbFileName _
    '                & "' iš šios atsarginės kopijos duomenų?") Then Return False

    '        End If

    '        Try
    '            IO.File.Copy(OpenFileNameTextbox.Text, GetFullPathToSQLiteDbFile(NewDbFileName), False)
    '        Catch ex As Exception
    '            ShowError(ex)
    '            Return False
    '        End Try

    '        MsgBox("Duomenų bazė '" & NewDbFileName & "' sėkmingai sukurta iš atsarginės kopijos.", _
    '             MsgBoxStyle.Information, "Info")

    '        DatabaseInfoList.InvalidateCache()
    '        Try
    '            DbList = DatabaseInfoList.GetDatabaseList
    '            DatabasesToMenu()
    '        Catch ex As Exception
    '            ShowError(New Exception("Klaida. Nepavyko atnaujinti duomenų bazių sąrašo.", ex))
    '        End Try

    '        Return True

    '    End If

    '    Try
    '        FetchCompanyFromDbFile(GetFullPathToSQLiteDbFile( _
    '            RecoveryTargetDbComboBox.SelectedItem.ToString.Trim), _
    '            AccDataAccessLayer.SqlServerType.SQLite, _
    '            LocalDatabasePasswordTextBox.Text.Trim, OriginalCompanyName, OriginalCompanyCode)
    '    Catch ex As Exception
    '        ShowError(New Exception("Klaida. Nepavyko atidaryti atkuriamos duomenų bazės. " _
    '            & ex.Message, ex))
    '        Return False
    '    End Try

    '    If BackupCompanyCode.Trim.ToLower <> OriginalCompanyCode.Trim.ToLower Then

    '        Dim result As String = Ask("Pasirinktoje esamoje duomenų bazėje yra saugomi įmonės '" _
    '            & OriginalCompanyName & "', kurios kodas yra " & OriginalCompanyCode _
    '            & ", duomenys. Atsarginėje kopijoje yra saugomi kitos įmonės duomenys - '" _
    '            & BackupCompanyName & "', kurios kodas yra " & BackupCompanyCode & "." _
    '            & vbCrLf & "Jūs galite perrašyti naujus duomenis ir ignoruoti įmonių " _
    '            & "neatitikimą arba sukurti naują duomenų bazę iš šios atsarginės kopijos.", _
    '            New ButtonStructure("Perrašyti", "Atsarginės kopijos duomenys pakeis dabartinį " _
    '            & "šios duomenų bazės turinį."), New ButtonStructure("Įtraukti kaip naują", _
    '            "Iš atsarginės kopijos duomenų bus sukurta nauja duomenų bazė."), _
    '            New ButtonStructure("Atšaukti", "Nedaryti nieko"))

    '        If result <> "Perrašyti" AndAlso result <> "Įtraukti kaip naują" Then Return False

    '        If result = "Įtraukti kaip naują" Then

    '            Dim NewDbFileName As String = AccDataAccessLayer.ConvertFromLithuanianToEnglishLetters( _
    '                BackupCompanyName.Trim).Replace(" ", "")

    '            If DbList.DatabaseNameExists(NewDbFileName) Then

    '                Dim NewDbFileNameModified As String = SQLiteGetNewDbName(NewDbFileName, DbList)

    '                If Not YesOrNo("Duomenų bazė pavadinimu '" & NewDbFileName _
    '                    & "' jau yra. Įtraukti pavadinimu '" & NewDbFileNameModified & "'?") Then Return False

    '                NewDbFileName = NewDbFileNameModified

    '            End If


    '            Try
    '                IO.File.Copy(OpenFileNameTextbox.Text, GetFullPathToSQLiteDbFile(NewDbFileName), False)
    '            Catch ex As Exception
    '                ShowError(ex)
    '                Return False
    '            End Try

    '            MsgBox("Duomenų bazė '" & NewDbFileName & "' sėkmingai sukurta iš atsarginės kopijos.", _
    '                 MsgBoxStyle.Information, "Info")

    '            DatabaseInfoList.InvalidateCache()
    '            Try
    '                DbList = DatabaseInfoList.GetDatabaseList
    '                DatabasesToMenu()
    '            Catch ex As Exception
    '                ShowError(New Exception("Klaida. Nepavyko atnaujinti duomenų bazių sąrašo.", ex))
    '            End Try

    '            Return True

    '        Else

    '            Try
    '                IO.File.Copy(OpenFileNameTextbox.Text, GetFullPathToSQLiteDbFile( _
    '                    RecoveryTargetDbComboBox.SelectedItem.ToString.Trim), True)
    '            Catch ex As Exception
    '                ShowError(ex)
    '                Return False
    '            End Try

    '            MsgBox("Duomenų bazė '" & RecoveryTargetDbComboBox.SelectedItem.ToString.Trim _
    '                & "' sėkmingai atkurta iš atsarginės kopijos.", MsgBoxStyle.Information, "Info")

    '            DatabaseInfoList.InvalidateCache()
    '            Try
    '                DbList = DatabaseInfoList.GetDatabaseList
    '                DatabasesToMenu()
    '            Catch ex As Exception
    '                ShowError(New Exception("Klaida. Nepavyko atnaujinti duomenų bazių sąrašo po atkūrimo.", ex))
    '            End Try

    '            Return True

    '        End If

    '    Else

    '        If Not YesOrNo("Atsarginės kopijos failas buvo sukurtas " & FileTimeStamp _
    '            & ". Atkūrus duomenų bazę iš šios atsarginės kopijos, visų vėliau registruotų " _
    '            & "operacijų duomenys bus negrįžtamai prarasti. Ar tikrai norite atkurti " _
    '            & "duomenų bazę iš atsarginės kopijos?") Then Return False

    '        Try
    '            IO.File.Copy(OpenFileNameTextbox.Text, GetFullPathToSQLiteDbFile( _
    '                RecoveryTargetDbComboBox.SelectedItem.ToString.Trim), True)
    '        Catch ex As Exception
    '            ShowError(ex)
    '            Return False
    '        End Try

    '        MsgBox("Duomenų bazė '" & RecoveryTargetDbComboBox.SelectedItem.ToString.Trim _
    '            & "' sėkmingai atkurta iš atsarginės kopijos.", MsgBoxStyle.Information, "Info")

    '        DatabaseInfoList.InvalidateCache()
    '        Try
    '            DbList = DatabaseInfoList.GetDatabaseList
    '            DatabasesToMenu()
    '        Catch ex As Exception
    '            ShowError(New Exception("Klaida. Nepavyko atnaujinti duomenų bazių sąrašo po atkūrimo.", ex))
    '        End Try

    '        Return True

    '    End If

    'End Function

    'Private Function SQLiteGetNewDbName(ByVal BasicName As String, _
    '    ByVal DbList As DatabaseInfoList) As String

    '    For Each db As DatabaseInfo In DbList
    '        If db.DatabaseName.Trim.ToLower = BasicName.Trim.ToLower Then

    '            For i As Integer = 2 To 999
    '                If Not DbList.DatabaseNameExists(BasicName.Trim & i.ToString) Then _
    '                    Return BasicName.Trim & i.ToString
    '            Next

    '        End If
    '    Next

    '    Return BasicName.Trim

    'End Function

    'Private Function MySqlRestoreFromBackUp(ByVal CurrentIdentity As AccIdentity, _
    '    ByVal FileTimeStamp As String) As Boolean

    '    Dim pv As String
    '    'OpenFileNameTextbox.Text

    '    Dim BackupCompanyName, BackupCompanyCode, BackupDatabaseName, _
    '        OriginalCompanyName, OriginalCompanyCode, OriginalDatabaseName As String

    '    Try
    '        MySqlGetCompanyDataFromBackupFile(OpenFileNameTextbox.Text, BackupCompanyName, _
    '            BackupCompanyCode, BackupDatabaseName)
    '    Catch ex As Exception
    '        ShowError(New Exception("Klaida. Nepavyko įkrauti atsarginės kopijos failo. " _
    '            & "Tikėtina, kad šis failas nėra duomenų bazės atsarginė kopija" & ex.Message, ex))
    '        Return False
    '    End Try

    '    If BackupCompanyCode Is Nothing OrElse String.IsNullOrEmpty(BackupCompanyCode.Trim) Then
    '        MsgBox("Klaida. Nepavyko nustatyti atsarginėje kopijoje saugomos įmonės kodo.", _
    '             MsgBoxStyle.Exclamation, "Klaida.")
    '        Return False
    '    End If

    '    If BackupDatabaseName Is Nothing OrElse String.IsNullOrEmpty(BackupDatabaseName.Trim) Then
    '        MsgBox("Klaida. Nepavyko nustatyti atsarginėje kopijoje saugomos duomenų bazės pavadinimo.", _
    '             MsgBoxStyle.Exclamation, "Klaida.")
    '        Return False
    '    End If

    '    Dim DbList As DatabaseInfoList
    '    Try
    '        DbList = DatabaseInfoList.GetDatabaseList
    '    Catch ex As Exception
    '        ShowError(New Exception("Klaida. Nepavyko gauti įmonių sąrašo", ex))
    '        Return False
    '    End Try

    '    pv = CurrentIdentity.Password
    '    If IsLoggedInDB() Then
    '        AccPrincipal.Login("", New CustomCacheManager)
    '        LogOffToGUI()
    '    End If

    '    Dim DuplicateDB As Boolean = False
    '    Dim MismatchDB As Boolean = False
    '    Dim IndexDuplicate As Integer
    '    Dim IndexMismatch As Integer

    '    For i As Integer = 1 To DbList.Count
    '        If DbList(i - 1).DatabaseName.Trim = BackupDatabaseName.Trim _
    '            AndAlso DbList(i - 1).Id.Trim.ToLower <> BackupCompanyCode.Trim.ToLower Then
    '            DuplicateDB = True
    '            IndexDuplicate = i
    '        ElseIf DbList(i - 1).DatabaseName.Trim <> BackupDatabaseName.Trim _
    '            AndAlso DbList(i - 1).Id.Trim.ToLower = BackupCompanyCode.Trim.ToLower Then
    '            MismatchDB = True
    '            IndexMismatch = i
    '        End If
    '    Next

    '    Dim ats As String = ""
    '    If DuplicateDB And MismatchDB Then
    '        ats = Ask("DĖMESIO. Atsarginėje kopijoje išsaugoti įmonės " & _
    '        "duomenys: duomenų bazė - " & BackupDatabaseName & ", įmonės pavadinimas - " & BackupCompanyName & _
    '        ", kodas - " & BackupCompanyCode & "." & vbCrLf & _
    '        "To pačio pavadinimo serverio duomenų bazėje saugomi kitos įmonės duomenys: " & _
    '        DbList(IndexDuplicate - 1).CompanyName & ", kodas " & DbList(IndexDuplicate - 1).Id & "." & _
    '        vbCrLf & "Serveryje įmonės, kurios duomenis norima atkurti, " & _
    '        "duomenys yra saugomi kitoje duomenų bazėje: " & DbList(IndexMismatch - 1).DatabaseName & ".", _
    '        New ButtonStructure("Overwrite", "Perrašyti duomenis ""ant viršaus"" ištrinant " & _
    '        "prieš tai buvusį faile nurodytos duomenų bazės turinį."), New ButtonStructure("Naudoti esamą", _
    '        "Naudoti duomenų bazę, kurioje šiuo metu saugomi tos įmonės duomenys."), _
    '        New ButtonStructure("Įtraukti naują", "Sukurti naują įmonę pagal atsarginės kopijos duomenis."), _
    '        New ButtonStructure("Atšaukti", "Nieko nedaryti."))
    '    ElseIf DuplicateDB Then
    '        ats = Ask("DĖMESIO. Atsarginėje kopijoje išsaugoti įmonės " & _
    '        "duomenys: duomenų bazė - " & BackupDatabaseName & ", įmonės pavadinimas - " & BackupCompanyName & _
    '        ", kodas - " & BackupCompanyCode & "." & vbCrLf & _
    '        "To pačio pavadinimo serverio duomenų bazėje saugomi kitos įmonės duomenys: " & _
    '        DbList(IndexDuplicate - 1).CompanyName & ", kodas " & DbList(IndexDuplicate - 1).Id & ".", _
    '        New ButtonStructure("Overwrite", "Perrašyti duomenis ""ant viršaus"" ištrinant " & _
    '        "prieš tai buvusį faile nurodytos duomenų bazės turinį."), _
    '        New ButtonStructure("Įtraukti naują", "Sukurti naują įmonę pagal atsarginės kopijos duomenis."), _
    '        New ButtonStructure("Atšaukti", "Nieko nedaryti."))
    '    ElseIf MismatchDB Then
    '        ats = Ask("DĖMESIO. Atsarginėje kopijoje išsaugoti įmonės " & _
    '        "duomenys: duomenų bazė - " & BackupDatabaseName & ", įmonės pavadinimas - " & BackupCompanyName & _
    '        ", kodas - " & BackupCompanyCode & "." & vbCrLf & "Serveryje tos pačios įmonės " & _
    '        "duomenys saugomi kitoje duomenų bazėje: " & DbList(IndexMismatch - 1).DatabaseName & ".", _
    '        New ButtonStructure("Naudoti esamą", "Naudoti duomenų bazę, kurioje šiuo metu saugomi tos įmonės duomenys."), _
    '        New ButtonStructure("Įtraukti naują", "Sukurti naują įmonę pagal failo duomenis."), _
    '        New ButtonStructure("Atšaukti", "Nieko nedaryti."))
    '    Else
    '        If Not YesOrNo("DĖMESIO. Įmonės " & BackupCompanyName & " duomenų bazės atsarginė kopija buvo padaryta " _
    '            & FileTimeStamp & ". Atkūrus duomenų bazę iš šios atsarginės kopijos, visų vėliau registruotų " _
    '            & "operacijų duomenys bus negrįžtamai prarasti. Ar tikrai norite atkurti " _
    '            & "duomenų bazę iš atsarginės kopijos?") Then Exit Function
    '    End If

    '    If (DuplicateDB OrElse MismatchDB) AndAlso ats <> "Overwrite" AndAlso ats <> "Naudoti esamą" _
    '        AndAlso ats <> "Įtraukti naują" Then Return False

    '    Dim ModifiedBackupFilePath As String = OpenFileNameTextbox.Text

    '    If (DuplicateDB OrElse MismatchDB) AndAlso ats <> "Overwrite" Then

    '        ' defining backup file encoding
    '        Dim enc As System.Text.Encoding
    '        Try
    '            enc = GetFileEncoding(OpenFileNameTextbox.Text, True)
    '        Catch ex As Exception
    '            If Not YesOrNo("Dėmesio. Nepavyko identifikuoti atsarginės kopijos failo " _
    '                & "duomenų koduotės (encoding). Gali būti blogai atkurti lietuviškų " _
    '                & "raidžių simboliai. Ar norite tęsti atkūrimą?") Then Return False
    '        End Try

    '        Dim NewDatabaseName As String = ""
    '        Try
    '            NewDatabaseName = AccDataAccessLayer.Security.CommandGetNewDatabaseName.TheCommand
    '        Catch ex As Exception
    '            ShowError(New Exception("Klaida. Nepavyko gauti naujos duomenų bazės pavadinimo.", ex))
    '            Return False
    '        End Try

    '        Try
    '            ' changing DB name in backup file
    '            Dim backupStr() As String = File.ReadAllLines(OpenFileNameTextbox.Text, enc)

    '            For j As Integer = 1 To backupStr.Length
    '                If backupStr(j - 1).Contains(BackupDatabaseName.Trim) Then
    '                    If ats = "Įtraukti naują" Then
    '                        backupStr(j - 1) = backupStr(j - 1).Replace(BackupDatabaseName.Trim, _
    '                        NewDatabaseName)
    '                    Else ' same entity different DB
    '                        backupStr(j - 1) = backupStr(j - 1).Replace(BackupDatabaseName.Trim, _
    '                            DbList(IndexMismatch - 1).DatabaseName.Trim)
    '                    End If
    '                End If
    '                If backupStr(j - 1).Contains("CREATE TABLE") Then Exit For
    '            Next

    '            ModifiedBackupFilePath = IO.Path.Combine(IO.Path.GetTempPath, "tmp_backup.sql")

    '            File.WriteAllLines(ModifiedBackupFilePath, backupStr, enc)

    '        Catch ex As Exception
    '            ShowError(New Exception("Klaida. Nepavyko pakoreguoti atsarginės kopijos duomenų: " _
    '                & ex.Message, ex))
    '            Return False
    '        End Try

    '    End If

    '    Dim BatchFilePath As String = IO.Path.Combine(IO.Path.GetTempPath, "tempFile.bat")

    '    Try
    '        Using fs As New FileStream(BatchFilePath, FileMode.Create, FileAccess.Write)
    '            Try
    '                Using s As New StreamWriter(fs)

    '                    Try
    '                        s.BaseStream.Seek(0, SeekOrigin.End)
    '                        s.WriteLine("@echo off")
    '                        s.WriteLine("mysql --user=root --password=" & pv _
    '                        & " --character-sets-dir=" & CharSetDirPath & " < " & Chr(34) & _
    '                            ModifiedBackupFilePath & Chr(34))
    '                        s.Close()
    '                        fs.Close()
    '                    Catch ex As Exception
    '                        s.Close()
    '                        Throw ex
    '                    End Try

    '                End Using
    '            Catch ex As Exception
    '                fs.Close()
    '            End Try
    '        End Using
    '    Catch ex As Exception
    '        Throw New Exception("Klaida. Nepavyko sukurti batch failo (skripto), " _
    '            & "reikalingo duomenų bazės atkūrimui." & ex.Message, ex)
    '    End Try


    '    Try
    '        Using ShellProcess As New Process

    '            ShellProcess.StartInfo.FileName = BatchFilePath
    '            ShellProcess.StartInfo.UseShellExecute = False
    '            ShellProcess.StartInfo.RedirectStandardError = True
    '            ShellProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
    '            ShellProcess.Start()
    '            ShellProcess.WaitForExit()

    '            Dim ShellErrorMessage As String = ShellProcess.StandardError.ReadToEnd

    '            If Not String.IsNullOrEmpty(ShellErrorMessage) Then
    '                MsgBox("Klaida atkuriant duomenų bazę: " & ShellErrorMessage, _
    '                    MsgBoxStyle.Exclamation, "Klaida.")
    '                Return False
    '            End If

    '        End Using
    '    Catch ex As Exception
    '        ShowError(New Exception("Klaida startuojant arba vykdant atkūrimo procesą: " _
    '            & ex.Message, ex))
    '        Return False
    '    End Try

    '    MsgBox("Įmonės '" & BackupCompanyName & "' duomenų bazė sėkmingai atkurta. " _
    '        & "Atkūrimo data ir laikas: " & FileTimeStamp & ".", MsgBoxStyle.Information, "Info")

    '    DatabaseInfoList.InvalidateCache()
    '    Try
    '        DbList = DatabaseInfoList.GetDatabaseList
    '        DatabasesToMenu()
    '    Catch ex As Exception
    '        ShowError(New Exception("Klaida. Nepavyko atnaujinti duomenų bazių sąrašo po atkūrimo.", ex))
    '    End Try

    '    Try
    '        If IO.File.Exists(BatchFilePath) Then IO.File.Delete(BatchFilePath)
    '    Catch ex As Exception
    '    End Try

    '    Try

    '        If ModifiedBackupFilePath.Trim <> OpenFileNameTextbox.Text.Trim AndAlso _
    '            IO.File.Exists(ModifiedBackupFilePath) Then IO.File.Delete(ModifiedBackupFilePath)
    '    Catch ex As Exception
    '        ' may warn the user that modified backup copy remains in program folder?
    '    End Try

    '    Return True

    'End Function

    Private Function GetSystemState(ByVal modifiedBackupFilePath As String) As String
        Dim mysqlExists As Boolean = False
        Dim mysqldumpExists As Boolean = False
        Dim sqlite3Exists As Boolean = False
        Dim cmdExists As Boolean = False
        If Not StringIsNullOrEmpty(_BaseDirPath) Then
            mysqlExists = FileExists("mysql.exe", IO.Path.Combine(IO.Path.Combine( _
                _BaseDirPath, "bin"), "mysql.exe"))
            mysqldumpExists = FileExists("mysqldump.exe", IO.Path.Combine(IO.Path.Combine( _
                _BaseDirPath, "bin"), "mysqldump.exe"))
            sqlite3Exists = FileExists("sqlite3.exe", IO.Path.Combine(AppPath, "sqlite3.exe"))
            cmdExists = FileExists("cmd.exe", "")
        End If
        Return String.Format("Windows versija: {0}; MySQL base dir: {1}; MySql Charset dir: {2}; MySql Exists: {3}; MySqlDump exists: {4}; Backup File path: '{5}'; PATH variable: '{6}'; SQLite3 exists: {7}; Application path: '{8}'; Command line exists: {9}.", _
            Environment.OSVersion.VersionString, _BaseDirPath, _CharSetDirPath, _
            mysqlExists.ToString, mysqldumpExists.ToString, modifiedBackupFilePath, _
            Environment.GetEnvironmentVariable("PATH"), sqlite3Exists.ToString, AppPath, cmdExists.ToString)
    End Function

    Private Shared Function FileExists(ByVal fileName As String, ByVal possibleFullPath As String) As Boolean
        If (Not StringIsNullOrEmpty(possibleFullPath) AndAlso File.Exists(possibleFullPath)) _
            OrElse File.Exists(fileName) Then Return True
        Dim values As String = Environment.GetEnvironmentVariable("PATH")
        For Each path As String In values.Split(";"c)
            Dim fullPath As String = IO.Path.Combine(path, fileName)
            If File.Exists(fullPath) Then Return True
        Next
        Return False
    End Function

End Class