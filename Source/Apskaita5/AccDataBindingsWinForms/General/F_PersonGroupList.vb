﻿Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists
Imports ApskaitaObjects.General

Friend Class F_PersonGroupList
    Implements ISingleInstanceForm

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of PersonGroupList)
    Private _ListViewManager As DataListViewEditControlManager(Of PersonGroup)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_PersonGroups_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        Try

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            ' PersonGroupList.GetPersonGroupList()
            _QueryManager.InvokeQuery(Of PersonGroupList)(Nothing, "GetPersonGroupList", _
                True, AddressOf OnDataSourceLoaded)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti sąskaitų plano duomenų.", ex), Nothing)
            DisableAllControls(Me)
        End Try

    End Sub

    Private Function SetDataSources() As Boolean

        Try

            _ListViewManager = New DataListViewEditControlManager(Of PersonGroup) _
                (PersonGroupListDataListView, Nothing, AddressOf DeleteItems, _
                 AddressOf AddNewItem, Nothing, Nothing)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti kontrahentų grupių duomenų.", ex), Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        IOkButton.Enabled = ApskaitaObjects.General.PersonGroupList.CanEditObject()
        IApplyButton.Enabled = ApskaitaObjects.General.PersonGroupList.CanEditObject()

        Return True

    End Function

    Private Sub OnDataSourceLoaded(ByVal source As Object, ByVal exceptionHandled As Boolean)

        If exceptionHandled Then

            DisableAllControls(Me)
            Exit Sub

        ElseIf source Is Nothing Then

            ShowError(New Exception("Klaida. Nepavyko gauti kontrahentų grupių duomenų."), Nothing)
            DisableAllControls(Me)
            Exit Sub

        End If

        Try

            _FormManager = New CslaActionExtenderEditForm(Of PersonGroupList) _
                (Me, PersonGroupListBindingSource, DirectCast(source, PersonGroupList), _
                 Nothing, IOkButton, IApplyButton, ICancelButton, _
                 Nothing, ProgressFiller1)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti kontrahentų grupių duomenų.", ex), Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

    End Sub


    Private Sub DeleteItems(ByVal items As PersonGroup())

        If items Is Nothing OrElse items.Length < 1 Then Exit Sub

        For Each item As PersonGroup In items
            If item.IsInUse Then
                MsgBox(String.Format("Klaida. Kontrahentų grupei {0} yra priskirta asmenų, jos pašalinti neleidžiama.", _
                    item.Name), MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            End If
        Next

        For Each item As PersonGroup In items
            _FormManager.DataSource.Remove(item)
        Next

    End Sub

    Private Sub AddNewItem()
        If _FormManager.DataSource Is Nothing Then Exit Sub
        _FormManager.DataSource.AddNew()
    End Sub


    Private Sub _FormManager_DataSourceStateHasChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles _FormManager.DataSourceStateHasChanged

        If CurrentMdiParent Is Nothing Then Exit Sub

        If Not PrepareCache(Me, GetType(HelperLists.PersonGroupInfoList)) Then Exit Sub

        For Each frm As Form In CurrentMdiParent.MdiChildren
            If TypeOf frm Is F_Person Then DirectCast(frm, F_Person).RefreshPersonGroupList()
        Next

    End Sub

End Class