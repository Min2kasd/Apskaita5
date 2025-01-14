﻿Imports ApskaitaObjects.General
Imports ApskaitaObjects.ActiveReports
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists
Imports AccDataBindingsWinForms.Printing

Friend Class F_PersonInfoItemList
    Implements ISupportsPrinting

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.PersonGroupInfoList), GetType(HelperLists.PersonInfoList)}

    Private _FormManager As CslaActionExtenderReportForm(Of PersonInfoItemList)
    Private _ListViewManager As DataListViewEditControlManager(Of PersonInfoItem)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_Persons_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub


    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _ListViewManager = New DataListViewEditControlManager(Of PersonInfoItem) _
                (PersonInfoItemListDataListView, ContextMenuStrip1, Nothing, _
                 Nothing, Nothing, Nothing)

            _ListViewManager.AddCancelButton = True
            _ListViewManager.AddButtonHandler("Keisti", "Keisti kontrahento duomenis.", _
                AddressOf ChangeItem)
            _ListViewManager.AddButtonHandler("Ištrinti", "Pašalinti kontrahento duomenis iš duomenų bazės.", _
                AddressOf DeleteItem)

            _ListViewManager.AddMenuItemHandler(ChangeItem_MenuItem, AddressOf ChangeItem)
            _ListViewManager.AddMenuItemHandler(DeleteItem_MenuItem, AddressOf DeleteItem)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            ' PersonInfoItemList.GetList()
            _FormManager = New CslaActionExtenderReportForm(Of PersonInfoItemList) _
                (Me, PersonInfoItemListBindingSource, Nothing, _RequiredCachedLists, _
                 RefreshButton, ProgressFiller1, "GetList", AddressOf GetReportParams)

            _FormManager.ManageDataListViewStates(PersonInfoItemListDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Function GetReportParams() As Object()
        'PersonInfoItemList.GetList(ShowClientsCheckBox.Checked, ShowsuppliersCheckBox.Checked, _
        '    ShowWorkersCheckBox.Checked, LikeStringTextBox.Text)
        Return New Object() {ShowClientsCheckBox.Checked, ShowsuppliersCheckBox.Checked, _
            ShowWorkersCheckBox.Checked, LikeStringTextBox.Text}
    End Function

    Private Sub ChangeItem(ByVal item As PersonInfoItem)
        If item Is Nothing Then Exit Sub

        ' Person.GetPerson(id)
        _QueryManager.InvokeQuery(Of Person)(Nothing, "GetPerson", True, _
            AddressOf OpenObjectEditForm, item.ID)

    End Sub

    Private Sub DeleteItem(ByVal item As PersonInfoItem)

        If item Is Nothing Then Exit Sub

        If CheckIfObjectEditFormOpen(Of Person)(item.ID, True, True) Then Exit Sub

        If Not YesOrNo("Ar tikrai norite pašalinti pasirinkto kontrahento " & _
            "duomenis iš duomenų bazės?") Then Exit Sub

        ' Person.DeletePerson(id)
        _QueryManager.InvokeQuery(Of Person)(Nothing, "DeletePerson", False, _
            AddressOf OnPersonDeleted, item.ID)

    End Sub

    Private Sub OnPersonDeleted(ByVal result As Object, ByVal exceptionHandled As Boolean)
        If exceptionHandled Then Exit Sub
        MsgBox("Kontrahento duomenys sėkmingai pašalinti iš duomenų bazės.", _
            MsgBoxStyle.Information, "Info")
        RefreshButton.PerformClick()
    End Sub


    Public Function GetMailDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetMailDropDownItems
        Return Nothing
    End Function

    Public Function GetPrintDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintDropDownItems
        Return Nothing
    End Function

    Public Function GetPrintPreviewDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintPreviewDropDownItems
        Return Nothing
    End Function

    Public Sub OnMailClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnMailClick
        If _FormManager.DataSource Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(_FormManager.DataSource, 0)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, False, 0, "KontrahentuSarasas", Me, _
                _ListViewManager.GetCurrentFilterDescription(), _
                _ListViewManager.GetDisplayOrderIndexes())
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, True, 0, "KontrahentuSarasas", Me, _
                _ListViewManager.GetCurrentFilterDescription(), _
                _ListViewManager.GetDisplayOrderIndexes())
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function

End Class