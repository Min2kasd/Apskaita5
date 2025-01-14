﻿Imports AccDataAccessLayer.Security
Imports AccDataAccessLayer
Imports AccDataBindingsWinForms.CachedInfoLists

Public Class F_Login

    Private _FormClosingInternal As Boolean = False
    Private Obj As LocalUser

    Private Sub F_Login_FormClosing(ByVal sender As Object, _
            ByVal e As System.Windows.Forms.FormClosingEventArgs) _
            Handles Me.FormClosing
        If _FormClosingInternal Then Exit Sub
        If YesOrNo("Ar tikrai norite baigti darba su programa?") Then
            _FormClosingInternal = True
            My.Application.IsInternalShutdown = True
            Global.System.Windows.Forms.Application.Exit()
            Me.Close()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub F_Login_HelpButtonClicked(ByVal sender As Object, _
        ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        Dim topicID As String = Me.GetType.Name
        If topicID.Length > 32 Then topicID = topicID.Substring(0, 32)
        topicID = topicID & ".htm"
        Help.ShowHelp(Me, "Apskaita5Help.chm", HelpNavigator.Topic, topicID)
    End Sub

    Private Sub F_Login_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Dim list As New List(Of ConnectionType)
        For Each t As ConnectionType In [Enum].GetValues(GetType(ConnectionType))
            ConnectionTechnologyHumanReadableComboBox.Items.Add( _
                ConvertConnectionTypeHumanReadable(t))
        Next

        SqlServerTypeHumanReadableComboBox.DataSource = GetSqlServerTypeDataSource(False, True)

        Dim users As LocalUserList
        Try
            users = LocalUserList.GetLocalUserList(MyCustomSettings.LocalUsers)
        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        PrepareControlWithAdHocDataSource(LocalUserListAccGridComboBox, users)

        If users.Count > 0 Then LocalUserListAccGridComboBox.SelectedValue = users.Item(0)
        PasswordTextBox.Text = ""

        ' clear user at first
        AccPrincipal.Logout(New CustomCacheManager)

        Try
            Obj = LocalUser.NewLocalUser
        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        LocalUserBindingSource.DataSource = Obj

    End Sub

    Private Sub LoginButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles LoginButton.Click

        Dim selectedUser As LocalUser

        If NewUserCheckBox.Checked Then

            If Not Obj.IsValid Then
                MsgBox("Klaida. Neįvesti visi prisijungimui būtini duomenys arba jie įvesti klaidingai: " & _
                    vbCrLf & Obj.BrokenRulesCollection.ToString, MsgBoxStyle.Exclamation, "Klaida.")
                Exit Sub
            End If
            selectedUser = Obj

        Else

            If LocalUserListAccGridComboBox.SelectedValue Is Nothing OrElse _
                Not TypeOf LocalUserListAccGridComboBox.SelectedValue Is LocalUser Then
                MsgBox("Klaida. Nepasirinktas vartotojas.", MsgBoxStyle.Exclamation, "Klaida.")
                Exit Sub
            End If

            selectedUser = CType(LocalUserListAccGridComboBox.SelectedValue, LocalUser)

        End If


        Try
            Using busy As New StatusBusy
                If Not AccPrincipal.Login(selectedUser, PasswordTextBox.Text, _
                    New CustomCacheManager) Then Exit Sub
            End Using
        Catch ex As Exception
            ShowError(ex, selectedUser)
            Exit Sub
        End Try


        If NewUserCheckBox.Checked Then
            Try
                Dim cLocalUsers As LocalUserList = LocalUserList.GetLocalUserList(MyCustomSettings.LocalUsers)
                cLocalUsers.Add(Obj)
                MyCustomSettings.LocalUsers = cLocalUsers.GetSettingsString()
                MyCustomSettings.Save()
            Catch ex As Exception
                ShowError(ex, Nothing)
                Exit Sub
            End Try
        End If

        If selectedUser.ConnectionTechnology = ConnectionType.Local Then _
            AddSqlQueryTimeoutToLocalContext(MyCustomSettings.SQLQueryTimeOut)

        _FormClosingInternal = True
        Me.Close()

    End Sub

    Private Sub LoginWithoutServerButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LoginWithoutServerButton.Click

        AccPrincipal.LoginAsLocalUser(SqlServerType.SQLite)
        AddSqlQueryTimeoutToLocalContext(MyCustomSettings.SQLQueryTimeOut)
        _FormClosingInternal = True
        Me.Close()

    End Sub

    Private Sub NewUserCheckBox_CheckedChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewUserCheckBox.CheckedChanged

        If NewUserCheckBox.Checked Then
            Me.Height = 455
            SplitContainer1.Panel2Collapsed = False
            LocalUserListAccGridComboBox.Visible = False
            NameTextBox.Visible = True
            LocalUserListAccGridComboBox.SendToBack()
            NameTextBox.BringToFront()
            SplitContainer1.SplitterDistance = 100

            ConnectionTechnologyHumanReadableComboBox.Width = LocalUserListAccGridComboBox.Width + 29
            ApplicationServerURLTextBox.Width = LocalUserListAccGridComboBox.Width + 29
            SqlServerAddressTextBox.Width = LocalUserListAccGridComboBox.Width + 29
            SqlServerPortAccBox.Width = LocalUserListAccGridComboBox.Width + 29
            SqlServerTypeHumanReadableComboBox.Width = LocalUserListAccGridComboBox.Width + 29
            DatabaseNamingConventionTextBox.Width = LocalUserListAccGridComboBox.Width + 29
            SslCertificatePasswordTextBox.Width = LocalUserListAccGridComboBox.Width + 29
            SslCertificateFileTextBox.Width = LocalUserListAccGridComboBox.Width + 4
            OpenCertificateFileButton.Location = New Point(SslCertificateFileTextBox.Location.X _
                + SslCertificateFileTextBox.Width + 2, OpenCertificateFileButton.Location.Y)
            SqlConnectionCharSetTextBox.Width = LocalUserListAccGridComboBox.Width + 29


            ConnectionTechnologyHumanReadableComboBox_SelectedIndexChanged(Me, New EventArgs)

        Else
            Me.Height = 130
            SplitContainer1.Panel2Collapsed = True
            LocalUserListAccGridComboBox.Visible = True
            NameTextBox.Visible = False
            LocalUserListAccGridComboBox.BringToFront()
            NameTextBox.SendToBack()
        End If

    End Sub

    Private Sub ConnectionTechnologyHumanReadableComboBox_SelectedIndexChanged( _
        ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        ConnectionTechnologyHumanReadableComboBox.SelectedIndexChanged

        If ConnectionTechnologyHumanReadableComboBox.SelectedItem Is Nothing OrElse _
            String.IsNullOrEmpty(ConnectionTechnologyHumanReadableComboBox.SelectedItem.ToString.Trim) _
            Then Exit Sub

        ApplicationServerURLTextBox.Enabled = (ConvertConnectionTypeHumanReadable( _
            ConnectionTechnologyHumanReadableComboBox.SelectedItem.ToString) <> ConnectionType.Local)
        SqlServerAddressTextBox.Enabled = Not ApplicationServerURLTextBox.Enabled
        SqlServerPortAccBox.Enabled = SqlServerAddressTextBox.Enabled
        SqlServerTypeHumanReadableComboBox.Enabled = SqlServerPortAccBox.Enabled
        DatabaseNamingConventionTextBox.Enabled = (ConvertConnectionTypeHumanReadable( _
            ConnectionTechnologyHumanReadableComboBox.SelectedItem.ToString) = ConnectionType.Local)
        SqlConnectionCharSetTextBox.Enabled = SqlServerAddressTextBox.Enabled

        Obj.ConnectionTechnologyHumanReadable = ConnectionTechnologyHumanReadableComboBox.SelectedItem.ToString

    End Sub

    Private Sub OpenCertificateFileButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OpenCertificateFileButton.Click

        Using ofd As New OpenFileDialog
            ofd.Multiselect = False
            If ofd.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then Exit Sub
            Me.SslCertificateFileTextBox.Text = ofd.FileName
        End Using

    End Sub

End Class