﻿Imports ApskaitaObjects.Workers
Imports ApskaitaObjects.ActiveReports
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.Printing

Friend Class F_ImprestSheetInfoList
    Implements ISupportsPrinting

    Private _FormManager As CslaActionExtenderReportForm(Of ImprestSheetInfoList)
    Private _ListViewManager As DataListViewEditControlManager(Of ImprestSheetInfo)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_ImprestSheetInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

    End Sub

    Private Function SetDataSources() As Boolean

        Try

            _ListViewManager = New DataListViewEditControlManager(Of ImprestSheetInfo) _
                (ImprestSheetInfoListDataListView, ContextMenuStrip1, Nothing, _
                 Nothing, Nothing, Nothing)

            _ListViewManager.AddCancelButton = True
            _ListViewManager.AddButtonHandler("Keisti", "Keisti avanso žiniaraščio duomenis.", _
                AddressOf ChangeItem)
            _ListViewManager.AddButtonHandler("Ištrinti", "Pašalinti avanso žiniaraščio duomenis iš duomenų bazės.", _
                AddressOf DeleteItem)

            _ListViewManager.AddMenuItemHandler(ChangeItem_MenuItem, AddressOf ChangeItem)
            _ListViewManager.AddMenuItemHandler(DeleteItem_MenuItem, AddressOf DeleteItem)
            _ListViewManager.AddMenuItemHandler(NewItem_MenuItem, AddressOf NewItem)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            ' ImprestSheetInfoList.GetImprestSheetInfoList(dateFrom, dateTo)
            _FormManager = New CslaActionExtenderReportForm(Of ImprestSheetInfoList) _
                (Me, ImprestSheetInfoListBindingSource, Nothing, Nothing, RefreshButton, _
                 ProgressFiller1, "GetImprestSheetInfoList", AddressOf GetReportParams)

            _FormManager.ManageDataListViewStates(ImprestSheetInfoListDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        RefreshButton.Enabled = ImprestSheetInfoList.CanGetObject

        DateFromAccDatePicker.Value = Today.AddMonths(-3)

        Return True

    End Function


    Private Function GetReportParams() As Object()
        ' ImprestSheetInfoList.GetImprestSheetInfoList(DateFromDateTimePicker.Value, DateToDateTimePicker.Value)
        Return New Object() {DateFromAccDatePicker.Value, DateToAccDatePicker.Value}
    End Function

    Private Sub NewButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewButton.Click
        NewItem(Nothing)
    End Sub

    Private Sub ChangeItem(ByVal item As ImprestSheetInfo)
        If item Is Nothing Then Exit Sub
        ' ImprestSheet.GetImprestSheet(item.ID)
        _QueryManager.InvokeQuery(Of ImprestSheet)(Nothing, "GetImprestSheet", True, _
            AddressOf OpenObjectEditForm, item.ID)
    End Sub

    Private Sub DeleteItem(ByVal item As ImprestSheetInfo)

        If item Is Nothing Then Exit Sub

        If CheckIfObjectEditFormOpen(Of ImprestSheet)(item.ID, True, True) Then Exit Sub

        If Not YesOrNo("Ar tikrai norite pašalinti avanso žiniaraščio duomenis?") Then Exit Sub

        ' ImprestSheet.DeleteImprestSheet(item.ID)
        _QueryManager.InvokeQuery(Of ImprestSheet)(Nothing, "DeleteImprestSheet", False, _
            AddressOf OnItemDeleted, item.ID)

    End Sub

    Private Sub OnItemDeleted(ByVal result As Object, ByVal exceptionHandled As Boolean)
        If exceptionHandled Then Exit Sub
        If Not YesOrNo("Avanso žiniaraščio duomenys sėkmingai pašalinti. Atnaujinti sąrašą?") Then Exit Sub
        RefreshButton.PerformClick()
    End Sub

    Private Sub NewItem(ByVal item As ImprestSheetInfo)
        OpenNewForm(Of ImprestSheet)()
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
            PrintObject(_FormManager.DataSource, False, 0, "AvansoZiniarastis", Me, _
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
            PrintObject(_FormManager.DataSource, True, 0, "AvansoZiniarastis", Me, _
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