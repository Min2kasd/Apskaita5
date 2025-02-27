﻿Imports ApskaitaObjects.ActiveReports
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists
Imports AccDataBindingsWinForms.Printing
Imports ApskaitaObjects.Attributes
Imports ApskaitaObjects.Documents.BankDataExchangeProviders
Imports ApskaitaObjects.HelperLists

Friend Class F_DebtInfoList
    Implements ISupportsPrinting

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.PersonGroupInfoList), GetType(HelperLists.AccountInfoList)}

    Private _FormManager As CslaActionExtenderReportForm(Of DebtInfoList)
    Private _ListViewManager As DataListViewEditControlManager(Of DebtInfo)


    Private Sub F_DebtInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub




    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.PersonGroupInfoList), _
            GetType(HelperLists.AccountInfoList)) Then Return False

        Try

            _ListViewManager = New DataListViewEditControlManager(Of DebtInfo) _
                (DebtInfoListDataListView, Nothing, Nothing, Nothing, Nothing, Nothing)

            _ListViewManager.AddCancelButton = False
            _ListViewManager.AddButtonHandler("Detaliau", "Detalesnė informacija", AddressOf ShowDetails)

            _FormManager = New CslaActionExtenderReportForm(Of DebtInfoList) _
                (Me, DebtInfoListBindingSource, Nothing, _RequiredCachedLists, _
                 RefreshButton, ProgressFiller1, "GetDebtInfoList", AddressOf GetReportParams)

            _FormManager.ManageDataListViewStates(DebtInfoListDataListView)

            PrepareControl(PersonGroupComboBox, New PersonGroupFieldAttribute( _
                ValueRequiredLevel.Optional))
            PrepareControl(AccountAccGridComboBox, New AccountFieldAttribute( _
                ValueRequiredLevel.Optional, False, 1, 2, 3, 4))

            DateFromAccDatePicker.Value = Today.AddMonths(-1)
            AccountAccGridComboBox.SelectedValue = GetCurrentCompany.GetDefaultAccount( _
                General.DefaultAccountType.Buyers)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Function GetReportParams() As Object()
        Return New Object() {DateFromAccDatePicker.Value.Date, DateToAccDatePicker.Value.Date, _
            AccountAccGridComboBox.SelectedValue, IsBuyerRadioButton.Checked, _
            PersonGroupComboBox.SelectedValue, IgnorePersonTypeCheckBox.Checked, _
            ShowZeroDebtsCheckBox.Checked, MarginOfErrorAccTextBox.DecimalValue}
    End Function

    Private Sub ShowDetails(ByVal item As DebtInfo)

        If item Is Nothing Then Exit Sub

        ShowAccountTurnover(_FormManager.DataSource.Account, _
            _FormManager.DataSource.DateFrom, _FormManager.DataSource.DateTo, item.PersonID)

    End Sub

    Private Sub IsBuyerRadioButton_CheckedChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IsBuyerRadioButton.CheckedChanged
        If IsBuyerRadioButton.Checked Then
            AccountAccGridComboBox.SelectedValue = GetCurrentCompany.GetDefaultAccount( _
                General.DefaultAccountType.Buyers)
        Else
            AccountAccGridComboBox.SelectedValue = GetCurrentCompany.GetDefaultAccount( _
                General.DefaultAccountType.Suppliers)
        End If
        ExportPaymentsButton.Enabled = Not IsBuyerRadioButton.Checked
    End Sub

    Private Sub ExportPaymentsButton_Click(sender As Object, e As EventArgs) Handles ExportPaymentsButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Try
            ExportBankPayments(_FormManager.DataSource.ExportBankPayments(), Me)
        Catch ex As Exception
            ShowError(ex)
        End Try

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
            PrintObject(_FormManager.DataSource, False, 0, "SkoluAtaskaita", Me, _
                _ListViewManager.GetCurrentFilterDescription(), _ListViewManager.GetDisplayOrderIndexes())
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, True, 0, "SkoluAtaskaita", Me, _
                _ListViewManager.GetCurrentFilterDescription(), _ListViewManager.GetDisplayOrderIndexes())
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function
    
End Class