﻿Imports AccDataAccessLayer.DatabaseAccess.DatabaseStructure
Public Class MainForm

    Private Sub OpenSqliteFileButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OpenSqliteFileButton.Click

        Using ofd As New OpenFileDialog
            ofd.Filter = "Duomenų bazė|*.db|Visi failai|*.*"
            ofd.Multiselect = False
            ofd.CheckFileExists = False
            If ofd.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
            FileTextBox.Text = ofd.FileName
        End Using

    End Sub

    Private Sub MigrateButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MigrateButton.Click

        Dim result As New MigrationMethods.MySqlToSQLiteCredentials(HostTextBox.Text, _
            PortTextBox.Text, UserTextBox.Text, MySqlPasswordTextBox.Text, DatabaseTextBox.Text, _
            FileTextBox.Text, SqlitePasswordTextBox.Text, Nothing)
        Using dlg As New F_Migrate(result, ToSqliteRadioButton.Checked)
            dlg.ShowDialog()
        End Using

    End Sub

End Class
