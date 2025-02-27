﻿Imports AccDataAccessLayer.Security
Public Class F_DeleteDatabase

    Private Sub F_Del_DB_Activated(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Activated
        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub F_DeleteDatabase_HelpButtonClicked(ByVal sender As Object, _
        ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
        Dim topicID As String = Me.GetType.Name
        If topicID.Length > 32 Then topicID = topicID.Substring(0, 32)
        topicID = topicID & ".htm"
        Help.ShowHelp(Me, "Apskaita5Help.chm", HelpNavigator.Topic, topicID)
    End Sub

    Private Sub F_Del_DB_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dBlist As DatabaseInfoList

        Try
            Using busy As New StatusBusy
                dBlist = DatabaseInfoList.GetDatabaseList
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        DatabaseInfoListBindingSource.DataSource = dBlist

    End Sub

    Private Sub DatabaseInfoListDataGridView_CellDoubleClick(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles DatabaseInfoListDataGridView.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub

        Dim selectedDatabaseInfo As DatabaseInfo
        Try
            selectedDatabaseInfo = CType(DatabaseInfoListDataGridView.Rows(e.RowIndex).DataBoundItem,  _
                DatabaseInfo)
        Catch ex As Exception
            Exit Sub
        End Try

        MsgBox("DĖMESIO. ĮMONĖS DUOMENŲ BAZĖS IŠTRYNIMAS YRA NEGRĮŽTAMAS. " _
        & "SUNAIKINTŲ DUOMENŲ ATKURTI NEBUS ĮMANOMA.", MsgBoxStyle.Critical)

        If Not YesOrNo("Ar tikrai suprantate, kad įmonės duomenų nebus įmanoma atkurti?") Then Exit Sub

        MsgBox("DĖMESIO. ĮMONĖS DUOMENŲ BAZĖS IŠTRYNIMAS YRA NEGRĮŽTAMAS. " _
        & "SUNAIKINTŲ DUOMENŲ ATKURTI NEBUS ĮMANOMA.", MsgBoxStyle.Critical)

        If Not YesOrNo("Ar tikrai norite sunaikinti pasirinktos įmonės duomenis?") Then Exit Sub
        If Not YesOrNo("PASKUTINĮ KARTĄ KLAUSIU. Ar tikrai tikrai norite sunaikinti pasirinktos įmonės duomenis?") Then Exit Sub

        Try
            Using busy As New StatusBusy
                CommandDropDatabase.TheCommand(selectedDatabaseInfo.DatabaseName)
            End Using
        Catch ex As Exception
            ShowError(ex, Nothing)
            Exit Sub
        End Try

        MsgBox("Įmonės duomenys sėkmingai pašalinti.")

        Dim dBlist As DatabaseInfoList

        Try
            Using busy As New StatusBusy
                DatabaseInfoList.InvalidateCache()
                dBlist = DatabaseInfoList.GetDatabaseList
                DirectCast(CurrentMdiParent, MDIParent1).DatabasesToMenu()
            End Using
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko atnaujinti įmonių sąrašo." & ex.Message, ex), Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        DatabaseInfoListBindingSource.RaiseListChangedEvents = False
        DatabaseInfoListBindingSource.DataSource = Nothing
        DatabaseInfoListBindingSource.DataSource = dBlist
        DatabaseInfoListBindingSource.RaiseListChangedEvents = True
        DatabaseInfoListBindingSource.ResetBindings(False)

    End Sub

End Class