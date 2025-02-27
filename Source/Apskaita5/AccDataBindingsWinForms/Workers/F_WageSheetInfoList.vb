﻿Imports ApskaitaObjects.Workers
Imports ApskaitaObjects.ActiveReports
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.Printing
Imports AccDataBindingsWinForms.CachedInfoLists
Imports ApskaitaObjects.Attributes

Friend Class F_WageSheetInfoList
    Implements ISupportsPrinting

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.PersonInfoList)}

    Private _FormManager As CslaActionExtenderReportForm(Of WageSheetInfoList)
    Private _ListViewManager As DataListViewEditControlManager(Of WageSheetInfo)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_WageSheetInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _ListViewManager = New DataListViewEditControlManager(Of WageSheetInfo) _
                (WageSheetInfoListDataListView, ContextMenuStrip1, Nothing, _
                 Nothing, Nothing, Nothing)

            _ListViewManager.AddCancelButton = True
            _ListViewManager.AddButtonHandler("Keisti", "Keisti darbo užmokesčio žiniaraščio duomenis.", _
                AddressOf ChangeItem)
            _ListViewManager.AddButtonHandler("Ištrinti", "Pašalinti darbo užmokesčio žiniaraščio duomenis iš duomenų bazės.", _
                AddressOf DeleteItem)

            _ListViewManager.AddMenuItemHandler(ChangeItem_MenuItem, AddressOf ChangeItem)
            _ListViewManager.AddMenuItemHandler(DeleteItem_MenuItem, AddressOf DeleteItem)
            _ListViewManager.AddMenuItemHandler(NewItem_MenuItem, AddressOf NewItem)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            ' WageSheetInfoList.GetWageSheetInfoList(dateFrom, dateTo)
            _FormManager = New CslaActionExtenderReportForm(Of WageSheetInfoList) _
                (Me, WageSheetInfoListBindingSource, Nothing, _RequiredCachedLists, _
                 RefreshButton, ProgressFiller1, "GetWageSheetInfoList", _
                 AddressOf GetReportParams)

            _FormManager.ManageDataListViewStates(WageSheetInfoListDataListView)

            PrepareControl(WorkersAccListComboBox, New PersonFieldAttribute( _
                ValueRequiredLevel.Optional, False, False, True))

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        RefreshButton.Enabled = ImprestSheetInfoList.CanGetObject
        NewButton.Enabled = WageSheet.CanAddObject

        DateFromAccDatePicker.Value = Today.AddMonths(-3)

        Return True

    End Function


    Private Function GetReportParams() As Object()

        Dim currentWorker As HelperLists.PersonInfo = Nothing
        Try
            currentWorker = DirectCast(WorkersAccListComboBox.SelectedValue,  _
                HelperLists.PersonInfo)
        Catch ex As Exception
        End Try

        'WageSheetInfoList.GetWageSheetInfoList(DateFromDateTimePicker.Value, _
        '    DateToDateTimePicker.Value, currentWorker, ShowPayedOutCheckBox.Checked)
        Return New Object() {DateFromAccDatePicker.Value, DateToAccDatePicker.Value, _
            currentWorker, ShowPayedOutCheckBox.Checked}

    End Function

    Private Sub NewButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewButton.Click
        NewItem(Nothing)
    End Sub

    Private Sub ChangeItem(ByVal item As WageSheetInfo)
        If item Is Nothing Then Exit Sub
        ' WageSheet.GetWageSheet(item.ID)
        _QueryManager.InvokeQuery(Of WageSheet)(Nothing, "GetWageSheet", True, _
            AddressOf OpenObjectEditForm, item.ID)
    End Sub

    Private Sub DeleteItem(ByVal item As WageSheetInfo)

        If item Is Nothing Then Exit Sub

        If CheckIfObjectEditFormOpen(Of WageSheet)(item.ID, True, True) Then Exit Sub

        If Not YesOrNo("Ar tikrai norite pašalinti darbo užmokesčio žiniaraščio duomenis?") Then Exit Sub

        ' WageSheet.DeleteWageSheet(item.ID)
        _QueryManager.InvokeQuery(Of WageSheet)(Nothing, "DeleteWageSheet", False, _
            AddressOf OnItemDeleted, item.ID)

    End Sub

    Private Sub OnItemDeleted(ByVal result As Object, ByVal exceptionHandled As Boolean)
        If exceptionHandled Then Exit Sub
        If Not YesOrNo("Darbo užmokesčio žiniaraščio duomenys sėkmingai pašalinti. Atnaujinti sąrašą?") Then Exit Sub
        RefreshButton.PerformClick()
    End Sub

    Private Sub NewItem(ByVal item As WageSheetInfo)
        OpenNewForm(Of WageSheet)()
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
            PrintObject(_FormManager.DataSource, False, 0, "DUZsarasas", Me, _
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
            PrintObject(_FormManager.DataSource, True, 0, "DUZsarasas", Me, _
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


    Private Sub WageSheetInfoListBindingSource_DataSourceChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles WageSheetInfoListBindingSource.DataSourceChanged
        If _FormManager Is Nothing OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        TotalSumAfterDeductionsAccBox.DecimalValue = _FormManager.DataSource.TotalSumAfterDeductions
        TotalSumPayedOutAccBox.DecimalValue = _FormManager.DataSource.TotalSumPayedOut
        WageSheetInfoListDataListView.Select()
    End Sub

End Class