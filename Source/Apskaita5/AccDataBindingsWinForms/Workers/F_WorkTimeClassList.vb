﻿Imports ApskaitaObjects.Workers
Imports AccControlsWinForms

Friend Class F_WorkTimeClassList
    Implements ISingleInstanceForm

    Private _FormManager As CslaActionExtenderEditForm(Of WorkTimeClassList)
    Private _ListViewManager As DataListViewEditControlManager(Of WorkTimeClass)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_WorkTimeClassList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        Try

            ' WorkTimeClassList.GetWorkTimeClassList()
            _QueryManager.InvokeQuery(Of WorkTimeClassList)(Nothing, "GetWorkTimeClassList", _
                True, AddressOf OnDataSourceLoaded)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti darbo ir poilsio laiko klasių duomenų.", ex), Nothing)
            DisableAllControls(Me)
        End Try

    End Sub

    Private Function SetDataSources() As Boolean

        Try

            _ListViewManager = New DataListViewEditControlManager(Of WorkTimeClass) _
                (WorkTimeClassListDataListView, Nothing, AddressOf DeleteItems, _
                 AddressOf AddNewItem, Nothing, Nothing)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti sąskaitų plano duomenų.", ex), Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        IOkButton.Enabled = WorkTimeClassList.CanEditObject
        IApplyButton.Enabled = WorkTimeClassList.CanEditObject

        Return True

    End Function

    Private Sub OnDataSourceLoaded(ByVal source As Object, ByVal exceptionHandled As Boolean)

        If exceptionHandled Then

            DisableAllControls(Me)
            Exit Sub

        ElseIf source Is Nothing Then

            ShowError(New Exception("Klaida. Nepavyko gauti darbo ir poilsio laiko klasių duomenų."), Nothing)
            DisableAllControls(Me)
            Exit Sub

        End If

        Try

            _FormManager = New CslaActionExtenderEditForm(Of WorkTimeClassList) _
                (Me, WorkTimeClassListBindingSource, DirectCast(source, WorkTimeClassList), _
                 Nothing, IOkButton, IApplyButton, ICancelButton, Nothing, ProgressFiller1)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti darbo ir poilsio laiko klasių duomenų.", ex), Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        FetchTypicalWorkTimeClassListButton.Visible = (_FormManager.DataSource.Count < 1)

    End Sub


    Private Sub DeleteItems(ByVal items As WorkTimeClass())
        If items Is Nothing OrElse items.Length < 1 Then Exit Sub
        For Each item As WorkTimeClass In items
            If Not item.IsNew AndAlso item.IsInUse Then
                MsgBox(String.Format("Klaida. Darbo laiko tipas '{0}' buvo naudojamas sudarant darbo " _
                    & "laiko apskaitos žiniaraščius. Jos pašalinti neleidžiama.", item.Name), _
                    MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            End If
        Next
        For Each item As WorkTimeClass In items
            _FormManager.DataSource.Remove(item)
        Next
    End Sub

    Private Sub AddNewItem()
        _FormManager.DataSource.AddNew()
    End Sub

    Private Sub FetchTypicalWorkTimeClassListButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles FetchTypicalWorkTimeClassListButton.Click

        If _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.Count > 0 Then Exit Sub

        If Not YesOrNo("Ar tikrai norite generuoti tipinę darbo laiko klasių struktūrą?") Then Exit Sub

        Try
            Using bus As New StatusBusy
                _FormManager.DataSource.AddWithTypicalCodes()
            End Using
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try

    End Sub

    Private Sub WorkTimeClassListDataListView_CellEditStarting(ByVal sender As Object, _
        ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles WorkTimeClassListDataListView.CellEditStarting

        If e.RowObject Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If

        Dim selectedItem As WorkTimeClass = DirectCast(e.RowObject, WorkTimeClass)

        If Not selectedItem.IsNew AndAlso selectedItem.IsInUse AndAlso e.Column.AspectName <> "Name" Then
            e.Cancel = True
            Exit Sub
        End If

    End Sub

End Class