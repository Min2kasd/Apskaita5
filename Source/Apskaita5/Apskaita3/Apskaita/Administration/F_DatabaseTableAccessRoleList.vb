﻿Imports System.ComponentModel
Imports System.Windows.Forms
Imports AccControlsWinForms
Imports AccDataAccessLayer.Security.DatabaseTableAccess
Public Class F_DatabaseTableAccessRoleList

    Private Obj As DatabaseTableAccessRoleList


    Private Sub F_DatabaseTableAccessRoleList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Obj = DatabaseTableAccessRoleList.NewRoleDatabaseAccessList

        Rebind(Obj)

        Try
            Using busy As New StatusBusy
                AccDataAccessLayer.DatabaseAccess.DatabaseStructure.DatabaseStructure.GetDatabaseStructure()
            End Using
        Catch ex As Exception
            ShowError(New Exception("Nepavyko gauti duomenų bazės struktūros šablono: " _
                & ex.Message, ex), Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

    End Sub


    Private Sub LoadGaugeButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles LoadGaugeButton.Click

        Dim result As MsgBoxResult = SaveIfDirty()
        If result = MsgBoxResult.Cancel Then Exit Sub

        If result <> MsgBoxResult.Yes Then CancelEdit()

        Try
            Using busy As New StatusBusy
                Obj = DatabaseTableAccessRoleList.GetRoleDatabaseAccessList()
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
        End Try

        Rebind(Obj)

    End Sub

    Private Sub OpenFileButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OpenFileButton.Click

        Dim result As MsgBoxResult = SaveIfDirty()
        If result = MsgBoxResult.Cancel Then Exit Sub

        Dim filePath As String = ""
        Using ofd As New OpenFileDialog
            ofd.Multiselect = False
            ofd.ShowDialog()
            filePath = ofd.FileName
        End Using

        If StringIsNullOrEmpty(filePath) OrElse Not IO.File.Exists(filePath) Then
            If result = MsgBoxResult.Yes Then Rebind(Obj)
            Exit Sub
        End If

        If result <> MsgBoxResult.Yes Then CancelEdit()

        Try
            Using busy As New StatusBusy
                Obj = DatabaseTableAccessRoleList.GetRoleDatabaseAccessList(filePath)
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
        End Try

        Rebind(Obj)

    End Sub

    Private Sub SaveFileButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles SaveFileButton.Click

        If StringIsNullOrEmpty(Obj.FilePath) Then
            SaveFileAsButton_Click(sender, e)
            Exit Sub
        End If

        If Not YesOrNo("Išsaugoti failą?") Then Exit Sub

        ApplyEdit()

        Try
            Using busy As New StatusBusy
                Obj = Obj.Clone.Save
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Rebind(Obj)

    End Sub

    Private Sub SaveFileAsButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles SaveFileAsButton.Click

        Dim filePath As String = ""
        Using sfd As New SaveFileDialog
            sfd.ShowDialog()
            filePath = sfd.FileName
        End Using

        If StringIsNullOrEmpty(filePath) Then Exit Sub

        If Not YesOrNo("Išsaugoti failą?") Then Exit Sub

        ApplyEdit()

        Try
            Using busy As New StatusBusy
                Obj = Obj.Clone.SaveAs(filePath)
            End Using
        Catch ex As Exception
            ShowError(ex, Obj)
        End Try

        Rebind(Obj)

    End Sub

    Private Sub PasteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles PasteButton.Click
        If Obj Is Nothing Then Exit Sub

        Dim answ As String = Ask("Overwrite content?", New ButtonStructure("Overwrite", "Overwrite with paste results"), _
            New ButtonStructure("Append", "Append with paste results"), New ButtonStructure("Cancel", "Do nothing"))

        If answ <> "Overwrite" AndAlso answ <> "Append" Then Exit Sub

        Try
            Obj.Paste(Clipboard.GetText, (answ = "Overwrite"))
        Catch ex As Exception
            ShowError(ex, Nothing)
        End Try

    End Sub


    Private Function SaveIfDirty() As MsgBoxResult

        If (Not Obj.IsNew AndAlso Obj.IsDirty) OrElse (Obj.IsNew AndAlso Obj.Count > 0) Then

            Dim result As String = Ask("Išsaugoti esamus duomenis prieš įkraunant naujus?", _
                New ButtonStructure("Taip", "Išsaugoti esamus ir įkrauti naujus duomenis."), _
                New ButtonStructure("Ne", "Neišsaugoti esamų ir įkrauti naujus duomenis."), _
                New ButtonStructure("Atšaukti", "Neįkrauti naujų duomenų."))

            If result <> "Taip" AndAlso result <> "Ne" Then Return MsgBoxResult.Cancel

            If result = "Taip" Then

                Dim filePath As String = ""
                If StringIsNullOrEmpty(Obj.FilePath) Then
                    Using sfd As New SaveFileDialog
                        sfd.ShowDialog()
                        filePath = sfd.FileName
                    End Using

                    If StringIsNullOrEmpty(filePath) OrElse Not IO.File.Exists(filePath) Then Return MsgBoxResult.Cancel
                End If

                ApplyEdit()

                Try
                    Using busy As New StatusBusy
                        If StringIsNullOrEmpty(filePath) Then
                            Obj = Obj.Clone.Save
                        Else
                            Obj = Obj.Clone.SaveAs(filePath)
                        End If
                    End Using
                Catch ex As Exception
                    ShowError(ex, Obj)
                    Rebind(Obj)
                    Return MsgBoxResult.Cancel
                End Try

                Return MsgBoxResult.Yes

            End If

        End If

        Return MsgBoxResult.No

    End Function

    Private Sub ApplyEdit()

        DatabaseTableAccessRoleListBindingSource.RaiseListChangedEvents = False

        UnbindBindingSource(DatabaseTableAccessRoleListBindingSource, True)

        DatabaseTableAccessRoleListBindingSource.EndEdit()

        Obj.ApplyEdit()

    End Sub

    Private Sub CancelEdit()

        DatabaseTableAccessRoleListBindingSource.RaiseListChangedEvents = False

        UnbindBindingSource(DatabaseTableAccessRoleListBindingSource, False)

        Obj.CancelEdit()

    End Sub

    Private Sub Rebind(ByVal dataSource As DatabaseTableAccessRoleList)

        dataSource.BeginEdit()

        'DatabaseTableAccessRoleListBindingSource.DataSource = Nothing
        'TableAccessListBindingSource.DataSource = DatabaseTableAccessRoleListBindingSource

        DatabaseTableAccessRoleListBindingSource.DataSource = dataSource

        DatabaseTableAccessRoleListBindingSource.RaiseListChangedEvents = True

        DatabaseTableAccessRoleListBindingSource.ResetBindings(False)

    End Sub

    Private Sub UnbindBindingSource(ByVal source As BindingSource, ByVal apply As Boolean)

        Dim current As System.ComponentModel.IEditableObject = CType(source.Current,  _
            System.ComponentModel.IEditableObject)

        If Not TypeOf source.DataSource Is BindingSource Then source.DataSource = Nothing

        If Not current Is Nothing Then
            If apply Then
                current.EndEdit()
            Else
                current.CancelEdit()
            End If
        End If

    End Sub

End Class