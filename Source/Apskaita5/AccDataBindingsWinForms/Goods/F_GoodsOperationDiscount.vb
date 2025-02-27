﻿Imports ApskaitaObjects.Goods
Imports ApskaitaObjects.Documents.InvoiceAdapters
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists

Friend Class F_GoodsOperationDiscount
    Implements IObjectEditForm, ISupportsChronologicValidator

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.GoodsInfoList), GetType(HelperLists.WarehouseInfoList), _
         GetType(HelperLists.AccountInfoList)}

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of GoodsOperationDiscount)
    Private _ListViewManager As DataListViewEditControlManager(Of ConsignmentItem)
    Private _QueryManager As CslaActionExtenderQueryObject

    Private _DocumentToEdit As GoodsOperationDiscount = Nothing
    Private _GoodsID As Integer = 0


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
            Return GetType(GoodsOperationDiscount)
        End Get
    End Property


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal goodsID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _GoodsID = goodsID

    End Sub

    Public Sub New(ByVal documentToEdit As GoodsOperationDiscount)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _DocumentToEdit = documentToEdit

    End Sub


    Private Sub F_GoodsOperationDiscount_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If _DocumentToEdit Is Nothing Then
            Using frm As New F_NewGoodsOperation(Of GoodsOperationDiscount)(_GoodsID)
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

            _FormManager = New CslaActionExtenderEditForm(Of GoodsOperationDiscount) _
                (Me, GoodsOperationDiscountBindingSource, _DocumentToEdit, _
                _RequiredCachedLists, nOkButton, ApplyButton, nCancelButton, _
                Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(ConsignmentsDataListView)

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

            _ListViewManager = New DataListViewEditControlManager(Of ConsignmentItem) _
                (ConsignmentsDataListView, Nothing, Nothing, Nothing, _
                 Nothing, _DocumentToEdit)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            SetupDefaultControls(Of GoodsOperationDiscount)(Me, _
                GoodsOperationDiscountBindingSource, _DocumentToEdit)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Sub AttachJournalEntryInfoButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AttachJournalEntryInfoButton.Click

        If _FormManager.DataSource Is Nothing OrElse _FormManager.IsChild Then Exit Sub

        Using dlg As New F_JournalEntryInfoList(_FormManager.DataSource.Date.AddMonths(-1), _
            _FormManager.DataSource.Date, True)

            If dlg.ShowDialog() <> DialogResult.OK OrElse dlg.SelectedEntries Is Nothing _
                OrElse dlg.SelectedEntries.Count < 1 Then Exit Sub

            Try
                _FormManager.DataSource.LoadAssociatedJournalEntry(dlg.SelectedEntries(0))
            Catch ex As Exception
                ShowError(ex, New Object() {_FormManager.DataSource, dlg.SelectedEntries})
                Exit Sub
            End Try

        End Using

    End Sub

    Private Sub AccountPurchasesIsClosedCheckBox_CheckStateChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles AccountPurchasesIsClosedCheckBox.CheckStateChanged

        If _FormManager.DataSource Is Nothing Then Exit Sub

        _FormManager.DataSource.AccountPurchasesIsClosed = AccountPurchasesIsClosedCheckBox.Checked
        TotalGoodsValueChangeAccTextBox.ReadOnly = _FormManager.DataSource.TotalGoodsValueChangeIsReadOnly

    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click
        If _FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.JournalEntryID > 0 Then Exit Sub
        OpenJournalEntryEditForm(_QueryManager, _FormManager.DataSource.JournalEntryID)
    End Sub


    Public Function ChronologicContent() As String _
            Implements ISupportsChronologicValidator.ChronologicContent
        If _FormManager.DataSource Is Nothing Then Return ""
        Return _FormManager.DataSource.OperationLimitations.LimitsExplanation
    End Function

    Public Function HasChronologicContent() As Boolean _
        Implements ISupportsChronologicValidator.HasChronologicContent

        Return Not _FormManager.DataSource Is Nothing AndAlso _
            Not StringIsNullOrEmpty(_FormManager.DataSource.OperationLimitations.LimitsExplanation)

    End Function


    Private Sub _FormManager_DataSourceStateHasChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles _FormManager.DataSourceStateHasChanged
        ConfigureButtons()
    End Sub

    Private Sub ConfigureButtons()

        TotalGoodsValueChangeAccTextBox.ReadOnly = _FormManager.DataSource Is Nothing _
            OrElse _FormManager.DataSource.TotalGoodsValueChangeIsReadOnly
        TotalValueChangeAccTextBox.ReadOnly = _FormManager.DataSource Is Nothing _
            OrElse _FormManager.DataSource.TotalValueChangeIsReadOnly
        AccountGoodsNetCostsAccGridComboBox.Enabled = Not _FormManager.DataSource Is Nothing _
            AndAlso Not _FormManager.DataSource.AccountGoodsNetCostsIsReadOnly
        AccountPurchasesIsClosedCheckBox.Enabled = Not _FormManager.DataSource Is Nothing _
            AndAlso Not _FormManager.DataSource.AccountPurchasesIsClosedIsReadOnly
        DateAccDatePicker.ReadOnly = _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.DateIsReadOnly
        DescriptionTextBox.ReadOnly = _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.DescriptionIsReadOnly

        ApplyButton.Enabled = Not _FormManager.DataSource Is Nothing AndAlso Not _FormManager.IsChild
        nCancelButton.Enabled = Not _FormManager.DataSource Is Nothing AndAlso (_FormManager.IsChild _
            OrElse Not _FormManager.DataSource.IsNew)

        EditedBaner.Visible = Not _FormManager.DataSource Is Nothing AndAlso Not _FormManager.DataSource.IsNew

        AttachJournalEntryInfoButton.Enabled = Not _FormManager.DataSource Is Nothing AndAlso _
            Not _FormManager.DataSource.AssociatedJournalEntryIsReadOnly

        ViewJournalEntryButton.Visible = Not _FormManager.DataSource Is Nothing

    End Sub

End Class