﻿Imports ApskaitaObjects.Goods
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.Printing
Imports AccDataBindingsWinForms.CachedInfoLists

Friend Class F_GoodsOperationDiscard
    Implements IObjectEditForm, ISupportsPrinting, ISupportsChronologicValidator

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.GoodsInfoList), GetType(HelperLists.WarehouseInfoList), _
         GetType(HelperLists.AccountInfoList)}

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of GoodsOperationDiscard)
    Private _QueryManager As CslaActionExtenderQueryObject

    Private _DocumentToEdit As GoodsOperationDiscard = Nothing
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
            Return GetType(GoodsOperationDiscard)
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

    Public Sub New(ByVal documentToEdit As GoodsOperationDiscard)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _DocumentToEdit = documentToEdit

    End Sub


    Private Sub F_GoodsOperationDiscard_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If _DocumentToEdit Is Nothing Then
            Using frm As New F_NewGoodsOperation(Of GoodsOperationDiscard)(_GoodsID)
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
            _FormManager = New CslaActionExtenderEditForm(Of GoodsOperationDiscard) _
                (Me, GoodsOperationDiscardBindingSource, _DocumentToEdit, _
                _RequiredCachedLists, nOkButton, ApplyButton, nCancelButton, _
                Nothing, ProgressFiller1)
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

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            SetupDefaultControls(Of GoodsOperationDiscard)(Me, _
                GoodsOperationDiscardBindingSource, _DocumentToEdit)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Sub RefreshCostsInfoButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshCostsInfoButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        If _FormManager.DataSource.Warehouse Is Nothing OrElse _FormManager.DataSource.Warehouse.IsEmpty Then
            MsgBox("Klaida. Nepasirinktas sandėlis.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        ElseIf _FormManager.DataSource.GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic Then
            MsgBox("Klaida. Taikant periodinį prekių apskaitos metodą operacijos " _
                & "savikaina neskaičiuojama.", MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Try

            Dim param As GoodsCostParam = GoodsCostParam.NewGoodsCostParam( _
                _FormManager.DataSource.GoodsInfo.ID, _FormManager.DataSource.Warehouse.ID, _
                _FormManager.DataSource.Ammount, _FormManager.DataSource.ID, 0, _
                _FormManager.DataSource.GoodsInfo.ValuationMethod, _FormManager.DataSource.Date)

            'GoodsCostItem.GetGoodsCostItem(param, True)
            _QueryManager.InvokeQuery(Of GoodsCostItem)(Nothing, "GetGoodsCostItem", True, _
                AddressOf OnCostItemFetched, param, True)

        Catch ex As Exception
            ShowError(ex, Nothing)
        End Try

    End Sub

    Private Sub OnCostItemFetched(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If result Is Nothing Then Exit Sub

        Try
            _FormManager.DataSource.LoadCostInfo(DirectCast(result, GoodsCostItem))
        Catch ex As Exception
            ShowError(ex, New Object() {_FormManager.DataSource, result})
            Exit Sub
        End Try

    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click
        If _FormManager.DataSource Is Nothing OrElse Not _FormManager.DataSource.JournalEntryID > 0 Then Exit Sub
        OpenJournalEntryEditForm(_QueryManager, _FormManager.DataSource.JournalEntryID)
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
            PrintObject(_FormManager.DataSource, False, 0, "PrekesNurasymas", Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, True, 0, "PrekesNurasymas", Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


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

        If _FormManager.DataSource Is Nothing Then Exit Sub

        WarehouseAccGridComboBox.Enabled = Not _FormManager.DataSource Is Nothing AndAlso Not _FormManager.DataSource.WarehouseIsReadOnly
        AccountGoodsDiscardCostsAccGridComboBox.Enabled = Not _FormManager.DataSource Is Nothing AndAlso _
            Not _FormManager.DataSource.AccountGoodsDiscardCostsIsReadOnly
        AmmountAccTextBox.ReadOnly = _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.AmmountIsReadOnly
        DateAccDatePicker.ReadOnly = _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.DateIsReadOnly
        DocumentNumberTextBox.ReadOnly = _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.DocumentNumberIsReadOnly
        DescriptionTextBox.ReadOnly = _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.DescriptionIsReadOnly

        nCancelButton.Enabled = Not _FormManager.DataSource Is Nothing AndAlso Not _FormManager.DataSource.IsNew

        EditedBaner.Visible = Not _FormManager.DataSource Is Nothing AndAlso Not _FormManager.DataSource.IsNew

    End Sub

End Class