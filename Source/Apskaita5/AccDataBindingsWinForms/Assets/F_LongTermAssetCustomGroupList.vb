﻿Imports ApskaitaObjects.Assets
Imports AccControlsWinForms

Friend Class F_LongTermAssetCustomGroupList
    Implements ISingleInstanceForm

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of LongTermAssetCustomGroupList)
    Private _ListViewManager As DataListViewEditControlManager(Of LongTermAssetCustomGroup)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_LongTermAssetCustomGroupList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            ' LongTermAssetCustomGroupList.GetLongTermAssetCustomGroupList()
            _QueryManager.InvokeQuery(Of LongTermAssetCustomGroupList)(Nothing, _
                "GetLongTermAssetCustomGroupList", True, AddressOf OnDataSourceFetched)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try
    End Sub

    Private Sub OnDataSourceFetched(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If exceptionHandled Then
            DisableAllControls(Me)
            Exit Sub
        ElseIf result Is Nothing Then
            MsgBox("Klaida. Dėl nežinomų priežasčių nepavyko gauti ilgalaikio turto grupių grupių duomenų.", _
                MsgBoxStyle.Exclamation, "Klaida")
            DisableAllControls(Me)
            Exit Sub
        End If

        Try

            _ListViewManager = New DataListViewEditControlManager(Of LongTermAssetCustomGroup) _
                (LongTermAssetCustomGroupListDataListView, Nothing, AddressOf OnItemsDelete, _
                 AddressOf OnItemAdd, Nothing, DirectCast(result, LongTermAssetCustomGroupList))

            _FormManager = New CslaActionExtenderEditForm(Of LongTermAssetCustomGroupList) _
                (Me, LongTermAssetCustomGroupListBindingSource, DirectCast(result, LongTermAssetCustomGroupList), _
                Nothing, nOkButton, ApplyButton, nCancelButton, Nothing, ProgressFiller1)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

    End Sub


    Private Sub OnItemsDelete(ByVal items As LongTermAssetCustomGroup())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        For Each item As LongTermAssetCustomGroup In items
            _FormManager.DataSource.Remove(item)
        Next
    End Sub

    Private Sub OnItemAdd()
        _FormManager.DataSource.AddNew()
    End Sub

End Class