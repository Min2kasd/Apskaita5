﻿Imports System.Windows.Forms
Imports System.Drawing
Imports AccDataAccessLayer.Security
Public Class F_UserProfile

    Private Obj As UserProfile

    Private Sub F_UserProfile_Activated(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Activated
        If Me.WindowState = FormWindowState.Maximized Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_UserProfile_Closing(ByVal sender As System.Object, _
            ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If Not Obj Is Nothing AndAlso Obj.IsDirty AndAlso Not Obj.UpdateDeniedByServerPolitics Then

            Dim result As String = Ask("Išsaugoti vartotojo profilio duomenis?", _
                New ButtonStructure("Taip", "Išsaugoti ir uždaryti formą."), _
                New ButtonStructure("Ne", "Neišsaugoti ir uždaryti formą."), _
                New ButtonStructure("Atšaukti", "Neuždaryti formos."))

            If result <> "Taip" AndAlso result <> "Ne" Then
                e.Cancel = True
                Exit Sub
            End If

            If result = "Taip" Then
                If Not SaveObj(False) Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If

        End If

        If Not Obj Is Nothing AndAlso Obj.IsDirty Then CancelObj()

    End Sub

    Private Sub F_UserProfile_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Using busy As New StatusBusy
                Obj = UserProfile.GetList
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        UserProfileBindingSource.DataSource = Obj

        OkButtonI.Enabled = Not Obj.UpdateDeniedByServerPolitics
        ApplyButtonI.Enabled = Not Obj.UpdateDeniedByServerPolitics

    End Sub


    Private Sub OkButtonI_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OkButtonI.Click
        If SaveObj(True) Then
            Me.Close()
        End If
    End Sub

    Private Sub ApplyButtonI_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButtonI.Click
        SaveObj(True)
    End Sub

    Private Sub CancelButtonI_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CancelButtonI.Click
        CancelObj()
    End Sub


    Private Sub OpenImageButton_Click(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles OpenImageButton.Click

        Using opf As New OpenFileDialog

            opf.Multiselect = False

            If opf.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then Exit Sub
            If StringIsNullOrEmpty(opf.FileName) OrElse Not IO.File.Exists(opf.FileName) Then Exit Sub

            Try
                SignaturePictureBox.Image = DirectCast(Image.FromFile(opf.FileName).Clone, Image)
            Catch ex As Exception
                MsgBox("Klaida. Neatpažintas paveikslėlio formatas: " & ex.Message, MsgBoxStyle.Exclamation)
            End Try

        End Using

    End Sub

    Private Sub ClearImageButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ClearImageButton.Click
        SignaturePictureBox.Image = Nothing
    End Sub


    Private Function SaveObj(ByVal askForConfirmation As Boolean) As Boolean

        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Neužpildyti visi reikalingi duomenys arba duomenyse yra klaidų: " & _
                Obj.BrokenRulesCollection.ToString, MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        If askForConfirmation Then
            If Not YesOrNo("Išsaugoti vartotojo profilio duomenis?") Then Return False
        End If

        Me.UserProfileBindingSource.RaiseListChangedEvents = False
        Me.UserProfileBindingSource.EndEdit()


        Try
            Using busu As New StatusBusy
                Obj = Obj.Clone.Save()
            End Using
        Catch ex As Exception
            ShowError(ex, Obj)
            Me.UserProfileBindingSource.RaiseListChangedEvents = True
            Return False
        End Try

        UserProfileBindingSource.DataSource = Nothing
        UserProfileBindingSource.DataSource = Obj

        Me.UserProfileBindingSource.RaiseListChangedEvents = True
        Me.UserProfileBindingSource.ResetBindings(False)

        MsgBox("Vartotojo profilio duomenys sėkmingai pakeisti.", MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()
        Me.UserProfileBindingSource.RaiseListChangedEvents = False
        Me.UserProfileBindingSource.CancelEdit()
        Me.UserProfileBindingSource.RaiseListChangedEvents = True
        Me.UserProfileBindingSource.ResetBindings(False)
    End Sub

End Class