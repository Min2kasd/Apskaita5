﻿Imports ApskaitaObjects.Workers
Imports ApskaitaObjects.HelperLists
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists
Imports AccDataBindingsWinForms.Printing
Imports ApskaitaObjects.Attributes

Friend Class F_WorkTimeSheet
    Implements ISupportsPrinting, IObjectEditForm

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.WorkTimeClassInfoList)}

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of WorkTimeSheet)
    Private _GeneralListViewManager As DataListViewEditControlManager(Of WorkTimeItem)
    Private _SpecialListViewManager As DataListViewEditControlManager(Of SpecialWorkTimeItem)

    Private _DocumentToEdit As WorkTimeSheet = Nothing


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If _FormManager Is Nothing OrElse _FormManager.DataSource Is Nothing Then
                If _DocumentToEdit Is Nothing OrElse _DocumentToEdit.IsNew Then
                    Return Integer.MinValue
                Else
                    Return _DocumentToEdit.ID
                End If
            End If
            Return _FormManager.DataSource.ID
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(WorkTimeSheet)
        End Get
    End Property


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()


    End Sub

    Public Sub New(ByVal documentToEdit As WorkTimeSheet)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _DocumentToEdit = documentToEdit

    End Sub


    Private Sub F_WorkTimeSheet_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If _DocumentToEdit Is Nothing Then
            Using frm As New F_NewWorkTimeSheet
                frm.ShowDialog()
                _DocumentToEdit = frm.Result
            End Using
        End If

        If _DocumentToEdit Is Nothing Then
            Me.BeginInvoke(New MethodInvoker(AddressOf Me.Close))
            Exit Sub
        End If

        If Not SetDataSources() Then Exit Sub

        Try

            _FormManager = New CslaActionExtenderEditForm(Of WorkTimeSheet) _
                (Me, WorkTimeSheetBindingSource, _DocumentToEdit, _
                _RequiredCachedLists, IOkButton, IApplyButton, ICancelButton, _
                Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(GeneralItemListDataListView, SpecialItemListDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        ConfigureButtons()

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _GeneralListViewManager = New DataListViewEditControlManager(Of WorkTimeItem) _
                (GeneralItemListDataListView, Nothing, Nothing, Nothing, Nothing, _DocumentToEdit)

            ' use single control in order to save resources
            Dim workTimeClassComboBox As New AccListComboBox
            PrepareControl(workTimeClassComboBox, New WorkTimeClassFieldAttribute( _
                ValueRequiredLevel.Optional, False, True))

            For i As Integer = 1 To 31
                _GeneralListViewManager.AddCustomEditControl("DayType" & i.ToString, workTimeClassComboBox)
            Next

            _SpecialListViewManager = New DataListViewEditControlManager(Of SpecialWorkTimeItem) _
                (SpecialItemListDataListView, Nothing, AddressOf RemoveSpecialItems, _
                 Nothing, Nothing, _DocumentToEdit)

            SetupDefaultControls(Of HolidayPayReserve)(Me, _
                WorkTimeSheetBindingSource, _DocumentToEdit)

            PrepareControl(NewSpecialWorkTimeTypeAccGridComboBox, _
                New WorkTimeClassFieldAttribute(ValueRequiredLevel.Optional, True, False))

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Sub RemoveSpecialItems(ByVal items As SpecialWorkTimeItem())

        If items Is Nothing OrElse items.Length < 1 Then Exit Sub

        For Each item As SpecialWorkTimeItem In items
            _FormManager.DataSource.SpecialItemList.Remove(item)
        Next

    End Sub

    Private Sub RefreshButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshButton.Click

        Dim result As WorkTimeSheet = Nothing
        Using frm As New F_NewWorkTimeSheet
            frm.ShowDialog()
            result = frm.Result
        End Using
        If result Is Nothing Then Exit Sub

        _FormManager.AddNewDataSource(result)

    End Sub

    Private Sub AddNewSpecialWorkTimeButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AddNewSpecialWorkTimeButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Dim restInfo As WorkTimeClassInfo = Nothing
        Try
            restInfo = DirectCast(NewSpecialWorkTimeTypeAccGridComboBox.SelectedValue, WorkTimeClassInfo)
        Catch ex As Exception
        End Try

        Dim baseItem As WorkTimeItem = Nothing
        Try
            baseItem = DirectCast(GeneralItemListDataListView.SelectedItem.RowObject, WorkTimeItem)
        Catch ex As Exception
        End Try

        Try
            _FormManager.DataSource.SpecialItemList.AddNewSpecialWorkTimeItem(baseItem, restInfo)
        Catch ex As Exception
            ShowError(ex, New Object() {_FormManager.DataSource, baseItem, restInfo})
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

        Using frm As New F_SendObjToEmail(_FormManager.DataSource, 1)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Try
            PrintObject(_FormManager.DataSource, False, 1, "tabelis", Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try

    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Try
            PrintObject(_FormManager.DataSource, True, 1, "tabelis", Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try

    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


    Private Sub _FormManager_DataSourceStateHasChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles _FormManager.DataSourceStateHasChanged
        ConfigureButtons()
    End Sub

    Private Sub ConfigureButtons()

        NumberTextBox.ReadOnly = (_FormManager.DataSource Is Nothing)
        SubDivisionTextBox.ReadOnly = (_FormManager.DataSource Is Nothing)
        PreparedByPositionTextBox.ReadOnly = (_FormManager.DataSource Is Nothing)
        PreparedByNameTextBox.ReadOnly = (_FormManager.DataSource Is Nothing)
        SignedByPositionTextBox.ReadOnly = (_FormManager.DataSource Is Nothing)
        SignedByNameTextBox.ReadOnly = (_FormManager.DataSource Is Nothing)
        DateAccDatePicker.ReadOnly = (_FormManager.DataSource Is Nothing)
        NewSpecialWorkTimeTypeAccGridComboBox.Enabled = (Not _FormManager.DataSource Is Nothing)
        AddNewSpecialWorkTimeButton.Enabled = (Not _FormManager.DataSource Is Nothing)
        IOkButton.Enabled = (Not _FormManager.DataSource Is Nothing)
        IApplyButton.Enabled = (Not _FormManager.DataSource Is Nothing)
        ICancelButton.Enabled = (Not _FormManager.DataSource Is Nothing AndAlso Not _FormManager.DataSource.IsNew)
        RefreshButton.Enabled = (_FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.IsNew)

    End Sub

End Class