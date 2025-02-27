﻿Imports ApskaitaObjects.ActiveReports
Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.Goods
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists
Imports AccDataBindingsWinForms.Printing
Imports ApskaitaObjects.Attributes

Public Class F_GoodsTurnoverInfoList
    Implements ISupportsPrinting

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.GoodsGroupInfoList), GetType(HelperLists.WarehouseInfoList)}

    Private _FormManager As CslaActionExtenderReportForm(Of GoodsTurnoverInfoList)
    Private _ListViewManager As DataListViewEditControlManager(Of GoodsTurnoverInfo)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_GoodsTurnoverInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Exit Function

        Try

            _ListViewManager = New DataListViewEditControlManager(Of GoodsTurnoverInfo) _
                (GoodsTurnoverInfoListDataListView, ContextMenuStrip1, Nothing, _
                 Nothing, Nothing, Nothing)

            _ListViewManager.AddCancelButton = True
            _ListViewManager.AddButtonHandler("Keisti", "Keisti prekės bendrus duomenis.", _
                AddressOf ChangeItem)
            _ListViewManager.AddButtonHandler("Ištrinti", "Pašalinti prekės duomenis iš duomenų bazės.", _
                AddressOf DeleteItem)
            _ListViewManager.AddButtonHandler("Operacijos", "Rodyti operacijas su prekėmis.", _
                AddressOf ItemDetails)

            _ListViewManager.AddMenuItemHandler(ChangeItem_MenuItem, AddressOf ChangeItem)
            _ListViewManager.AddMenuItemHandler(DeleteItem_MenuItem, AddressOf DeleteItem)
            _ListViewManager.AddMenuItemHandler(ItemDetails_MenuItem, AddressOf ItemDetails)

            NewOperation_MenuItem.DropDownItems.Clear()
            For Each t As TypeItem In GoodsOperationManager.GetSimpleOperationTypes()
                Dim menuItem As New ToolStripMenuItem(t.Name)
                menuItem.Tag = t.Type
                AddHandler menuItem.Click, AddressOf NewOperationMenuItem_Click
                NewOperation_MenuItem.DropDownItems.Add(menuItem)
            Next

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            'GoodsTurnoverInfoList.GetGoodsTurnoverInfoList(dateFrom, dateTo, group, Warehouse, _
            '    textCriteria, includeWithoutTurnover)
            _FormManager = New CslaActionExtenderReportForm(Of GoodsTurnoverInfoList) _
                (Me, GoodsTurnoverInfoListBindingSource, Nothing, _RequiredCachedLists, RefreshButton, _
                 ProgressFiller1, "GetGoodsTurnoverInfoList", AddressOf GetReportParams)

            _FormManager.ManageDataListViewStates(GoodsTurnoverInfoListDataListView)

            PrepareControl(GoodsGroupInfoAccGridComboBox, _
                New GoodsGroupFieldAttribute(ValueRequiredLevel.Optional))
            PrepareControl(WarehouseInfoAccGridComboBox, _
                New WarehouseFieldAttribute(ValueRequiredLevel.Optional))

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        DateFromAccDatePicker.Value = Today.Subtract(New TimeSpan(30, 0, 0, 0))

        Return True

    End Function


    Private Function GetReportParams() As Object()

        Dim warehouse As WarehouseInfo = Nothing
        Try
            warehouse = DirectCast(WarehouseInfoAccGridComboBox.SelectedValue, WarehouseInfo)
        Catch ex As Exception
        End Try
        Dim group As GoodsGroupInfo = Nothing
        Try
            group = DirectCast(GoodsGroupInfoAccGridComboBox.SelectedValue, GoodsGroupInfo)
        Catch ex As Exception
        End Try

        'GoodsTurnoverInfoList.GetGoodsTurnoverInfoList(DateFromDateTimePicker.Value.Date, _
        '    DateToDateTimePicker.Value.Date, group, warehouse, _
        '    NameOrCodeFragmentTextBox.Text, IncludeWithoutTurnoverCheckBox.Checked)
        Return New Object() {DateFromAccDatePicker.Value.Date, _
            DateToAccDatePicker.Value.Date, group, warehouse, _
            NameOrCodeFragmentTextBox.Text, IncludeWithoutTurnoverCheckBox.Checked}

    End Function

   Private Sub ChangeItem(ByVal item As GoodsTurnoverInfo)
        If item Is Nothing Then Exit Sub
        'GoodsItem.GetGoodsItem(item.ID)
        _QueryManager.InvokeQuery(Of GoodsItem)(Nothing, "GetGoodsItem", True, _
            AddressOf OpenObjectEditForm, item.ID)
    End Sub

    Private Sub DeleteItem(ByVal item As GoodsTurnoverInfo)

        If item Is Nothing Then Exit Sub

        If CheckIfObjectEditFormOpen(Of GoodsItem)(item.ID, True, True) Then Exit Sub

        If Not YesOrNo("Ar tikrai norite pašalinti pasirinktos prekės duomenis iš duomenų bazės?") Then Exit Sub

        ' GoodsItem.DeleteGoodsItem(item.ID)
        _QueryManager.InvokeQuery(Of GoodsItem)(Nothing, "DeleteGoodsItem", False, _
            AddressOf OnItemDeleted, item.ID)

    End Sub

    Private Sub OnItemDeleted(ByVal result As Object, ByVal exceptionHandled As Boolean)
        If exceptionHandled Then Exit Sub
        If Not YesOrNo("Prekės duomenys sėkmingai pašalinti iš duomenų bazės." _
            & vbCrLf & "Atnaujinti ataskaitą?") Then Exit Sub
        RefreshButton.PerformClick()
    End Sub

    Private Sub ItemDetails(ByVal item As GoodsTurnoverInfo)
        If item Is Nothing Then Exit Sub
        
        Dim wd As Integer = 0
        If Not _FormManager.DataSource.Warehouse Is Nothing AndAlso _FormManager.DataSource.Warehouse.ID > 0 Then
            wd = _FormManager.DataSource.Warehouse.ID
        End If

        GoodsOperationManager.ShowGoodsOperationInfoList(_FormManager.DataSource.DateFrom, _
            _FormManager.DataSource.DateTo, item.ID, wd)

    End Sub

    Private Sub NewOperationMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ContextMenuStrip1.Tag Is Nothing Then Exit Sub

        Dim goodsID As Integer = 0
        Try
            goodsID = DirectCast(ContextMenuStrip1.Tag, GoodsTurnoverInfo).ID
        Catch ex As Exception
        End Try
        If Not goodsID > 0 Then Exit Sub

        Dim operationType As Type = Nothing
        Try
            operationType = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Type)
        Catch ex As Exception
        End Try

        If Not goodsID > 0 OrElse operationType Is Nothing Then Exit Sub

        GoodsOperationManager.StartNewGoodsOperation(goodsID, operationType)

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
            PrintObject(_FormManager.DataSource, False, 0, "PrekiuApyvarta", Me, _
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
            PrintObject(_FormManager.DataSource, True, 0, "PrekiuApyvarta", Me, _
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