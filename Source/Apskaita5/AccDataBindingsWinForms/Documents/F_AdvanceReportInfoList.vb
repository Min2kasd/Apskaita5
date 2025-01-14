﻿Imports ApskaitaObjects.ActiveReports
Imports ApskaitaObjects.Documents
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists
Imports AccDataBindingsWinForms.Printing
Imports ApskaitaObjects.Attributes

Friend Class F_AdvanceReportInfoList
    Implements ISupportsPrinting

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.PersonInfoList)}

    Private _FormManager As CslaActionExtenderReportForm(Of AdvanceReportInfoList)
    Private _ListViewManager As DataListViewEditControlManager(Of AdvanceReportInfo)
    Private _QueryManager As CslaActionExtenderQueryObject

    Private _SelectedEntries As List(Of AdvanceReportInfo) = Nothing
    Private _DateFrom As Date = Today
    Private _DateTo As Date = Today
    Private _OnlyAllowSingleSelection As Boolean = False


    Public ReadOnly Property SelectedEntries() As List(Of AdvanceReportInfo)
        Get
            Return _SelectedEntries
        End Get
    End Property


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ''' <summary>
    ''' Use to show the form as modal dialog for advance report info selection.
    ''' </summary>
    ''' <param name="dateFrom">prefered period start date</param>
    ''' <param name="dateTo">prefered period end date</param>
    ''' <param name="onlyAllowSingleSelection">whether only to allow user to select a single document 
    ''' (not multiple)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal onlyAllowSingleSelection As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _DateFrom = dateFrom
        _DateTo = dateTo
        _OnlyAllowSingleSelection = onlyAllowSingleSelection

    End Sub


    Private Sub F_AdvanceReportInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        Me.Panel1.Visible = Me.Modal
        Me.AdvanceReportInfoListDataListView.CheckBoxes = Me.Modal
        Me.MinimizeBox = Not Me.Modal
        Me.MaximizeBox = Not Me.Modal

        If Me.Modal Then
            If _OnlyAllowSingleSelection Then
                Me.Text = "Pasirinkite avanso apyskaitą..."
            Else
                Me.Text = "Pasirinkite avanso apyskaitas..."
            End If
        End If

        If Me.Modal AndAlso Me.WindowState = FormWindowState.Maximized Then Me.WindowState = FormWindowState.Normal

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            If Me.Modal Then

                _ListViewManager = New DataListViewEditControlManager(Of AdvanceReportInfo) _
                    (AdvanceReportInfoListDataListView, Nothing, Nothing, Nothing, Nothing, Nothing)

                _ListViewManager.AddCancelButton = False
                _ListViewManager.AddButtonHandler("Pasirinkti", "Pasirinkti", AddressOf SelectItem)

            Else

                _ListViewManager = New DataListViewEditControlManager(Of AdvanceReportInfo) _
                (AdvanceReportInfoListDataListView, ContextMenuStrip1, Nothing, _
                 Nothing, Nothing, Nothing)

                _ListViewManager.AddCancelButton = True
                _ListViewManager.AddButtonHandler("Keisti", "Keisti avanso apyskaitos duomenis.", _
                    AddressOf ChangeItem)
                _ListViewManager.AddButtonHandler("Ištrinti", "Pašalinti avanso apyskaitos duomenis iš duomenų bazės.", _
                    AddressOf DeleteItem)
                _ListViewManager.AddButtonHandler("Orderis", "Atidaryti susietą/naują kasos orderį.", _
                    AddressOf AttachedOrder)

                _ListViewManager.AddMenuItemHandler(ChangeItem_MenuItem, AddressOf ChangeItem)
                _ListViewManager.AddMenuItemHandler(DeleteItem_MenuItem, AddressOf DeleteItem)
                _ListViewManager.AddMenuItemHandler(NewItem_MenuItem, AddressOf NewItem)
                _ListViewManager.AddMenuItemHandler(AttachedOrder_MenuItem, AddressOf AttachedOrder)

            End If

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            ' AdvanceReportInfoList.GetAdvanceReportInfoList(dateFrom, dateTo, person)
            _FormManager = New CslaActionExtenderReportForm(Of AdvanceReportInfoList) _
                (Me, AdvanceReportInfoListBindingSource, Nothing, _RequiredCachedLists, RefreshButton, _
                 ProgressFiller1, "GetAdvanceReportInfoList", AddressOf GetReportParams)

            _FormManager.ManageDataListViewStates(AdvanceReportInfoListDataListView)

            PrepareControl(PersonInfoAccGridComboBox, New PersonFieldAttribute( _
                ValueRequiredLevel.Optional, False, False, True, False))

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        If Me.Modal Then
            Me.DateFromAccDatePicker.Value = _DateFrom
            Me.DateToAccDatePicker.Value = _DateTo
        Else
            DateFromAccDatePicker.Value = Today.AddMonths(-1)
        End If

        Return True

    End Function


    Private Function GetReportParams() As Object()

        Dim personFilter As HelperLists.PersonInfo = Nothing
        Try
            personFilter = DirectCast(PersonInfoAccGridComboBox.SelectedValue, HelperLists.PersonInfo)
        Catch ex As Exception
        End Try

        'AdvanceReportInfoList.GetAdvanceReportInfoList(DateFromDateTimePicker.Value.Date, _
        '  DateToDateTimePicker.Value.Date, personFilter)
        Return New Object() {DateFromAccDatePicker.Value.Date, _
          DateToAccDatePicker.Value.Date, personFilter}

    End Function

    Private Sub ChangeItem(ByVal item As AdvanceReportInfo)
        If item Is Nothing Then Exit Sub
        ' AdvanceReport.GetAdvanceReport(item.ID)
        _QueryManager.InvokeQuery(Of AdvanceReport)(Nothing, "GetAdvanceReport", True, _
            AddressOf OpenObjectEditForm, item.ID)
    End Sub

    Private Sub DeleteItem(ByVal item As AdvanceReportInfo)

        If item Is Nothing Then Exit Sub

        If CheckIfObjectEditFormOpen(Of AdvanceReport)(item.ID, True, True) Then Exit Sub

        If Not YesOrNo("Ar tikrai norite pašalinti dokumento duomenis iš duomenų bazės?") Then Exit Sub

        ' AdvanceReport.DeleteAdvanceReport(item.ID)
        _QueryManager.InvokeQuery(Of AdvanceReport)(Nothing, "DeleteAdvanceReport", False, _
            AddressOf OnItemDeleted, item.ID)

    End Sub

    Private Sub OnItemDeleted(ByVal result As Object, ByVal exceptionHandled As Boolean)
        If exceptionHandled Then Exit Sub
        If Not YesOrNo("Dokumento duomenys sėkmingai pašalinti iš įmonės duomenų bazės. Atnaujinti sąrašą?") Then Exit Sub
        RefreshButton.PerformClick()
    End Sub

    Private Sub NewItem(ByVal item As AdvanceReportInfo)
        OpenNewForm(Of AdvanceReport)()
    End Sub

    Private Sub AttachedOrder(ByVal item As AdvanceReportInfo)

        If item.TillOrderID > 0 Then

            If item.IsIncomeTillOrder Then
                ' TillIncomeOrder.GetTillIncomeOrder(item.TillOrderID)
                _QueryManager.InvokeQuery(Of TillIncomeOrder)(Nothing, "GetTillIncomeOrder", True, _
                    AddressOf OpenObjectEditForm, item.TillOrderID)
            Else
                ' TillSpendingsOrder.GetTillSpendingsOrder(item.TillOrderID)
                _QueryManager.InvokeQuery(Of TillSpendingsOrder)(Nothing, "GetTillSpendingsOrder", True, _
                    AddressOf OpenObjectEditForm, item.TillOrderID)
            End If

        Else

            Dim personList As HelperLists.PersonInfoList = HelperLists.PersonInfoList.GetList()

            If item.IsIncomeTillOrder Then

                Dim result As TillIncomeOrder = Nothing
                Try
                    result = TillIncomeOrder.NewTillIncomeOrder()
                    result.LoadAdvanceReport(item, personList)
                Catch ex As Exception
                    ShowError(ex, New Object() {result, item})
                    Exit Sub
                End Try
                OpenObjectEditForm(result)

            Else

                Dim result As TillSpendingsOrder = Nothing
                Try
                    result = TillSpendingsOrder.NewTillSpendingsOrder()
                    result.LoadAdvanceReport(item, personList)
                Catch ex As Exception
                    ShowError(ex, New Object() {result, item})
                    Exit Sub
                End Try
                OpenObjectEditForm(result)

            End If

        End If

    End Sub

    Private Sub SelectItem(ByVal item As AdvanceReportInfo)

        If item Is Nothing Then Exit Sub

        _SelectedEntries = New List(Of AdvanceReportInfo)
        _SelectedEntries.Add(item)

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub


    Private Sub nOkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles nOkButton.Click

        If Not Me.Modal Then Exit Sub

        If Me.AdvanceReportInfoListDataListView.CheckedObjects Is Nothing OrElse _
            Me.AdvanceReportInfoListDataListView.CheckedObjects.Count < 1 Then
            MsgBox("Klaida. Nepasirinkta nė viena apyskaita.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        ElseIf _OnlyAllowSingleSelection AndAlso Me.AdvanceReportInfoListDataListView.CheckedObjects.Count > 1 Then
            MsgBox("Klaida. Leidžiama pasirinkti tik vieną apyskaitą.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        _SelectedEntries = New List(Of AdvanceReportInfo)
        For Each selectedItem As Object In Me.AdvanceReportInfoListDataListView.CheckedObjects
            _SelectedEntries.Add(DirectCast(selectedItem, AdvanceReportInfo))
        Next

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub nCancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles nCancelButton.Click
        If Not Me.Modal Then Exit Sub
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
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
            PrintObject(_FormManager.DataSource, False, 0, "AvansoApyskaituSarasas", Me, _
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
            PrintObject(_FormManager.DataSource, True, 0, "AvansoApyskaituSarasas", Me, _
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