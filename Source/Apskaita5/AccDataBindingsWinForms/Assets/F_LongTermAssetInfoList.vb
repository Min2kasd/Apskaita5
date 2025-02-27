﻿Imports ApskaitaObjects.ActiveReports
Imports ApskaitaObjects.Assets
Imports ApskaitaObjects.HelperLists
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists
Imports AccDataBindingsWinForms.Printing
Imports ApskaitaObjects.Attributes

Friend Class F_LongTermAssetInfoList
    Implements ISupportsPrinting

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(LongTermAssetCustomGroupInfoList)}

    Private _FormManager As CslaActionExtenderReportForm(Of LongTermAssetInfoList)
    Private _ListViewManager As DataListViewEditControlManager(Of LongTermAssetInfo)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_LongTermAssetInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _ListViewManager = New DataListViewEditControlManager(Of LongTermAssetInfo) _
                (LongTermAssetInfoListDataListView, ContextMenuStrip1, Nothing, _
                 Nothing, Nothing, Nothing)

            _ListViewManager.AddCancelButton = True
            _ListViewManager.AddButtonHandler("Keisti", "Keisti ilgalaikio turto duomenis.", _
                AddressOf ChangeItem)
            _ListViewManager.AddButtonHandler("Ištrinti", "Pašalinti ilgalaikio turto duomenis iš duomenų bazės.", _
                AddressOf DeleteItem)
            _ListViewManager.AddButtonHandler("Operacijos", "Rodyti operacijas su ilgalaikiu turtu.", _
                AddressOf ItemDetails)

            _ListViewManager.AddMenuItemHandler(ChangeItem_MenuItem, AddressOf ChangeItem)
            _ListViewManager.AddMenuItemHandler(DeleteItem_MenuItem, AddressOf DeleteItem)
            _ListViewManager.AddMenuItemHandler(NewItem_MenuItem, AddressOf NewItem)
            _ListViewManager.AddMenuItemHandler(ItemDetails_MenuItem, AddressOf ItemDetails)

            NewOperation_MenuItem.DropDownItems.Clear()
            For Each t As TypeItem In AssetOperationManager.GetSimpleOperationTypes()
                Dim menuItem As New ToolStripMenuItem(t.Name)
                menuItem.Tag = t.Type
                AddHandler menuItem.Click, AddressOf NewOperationMenuItem_Click
                NewOperation_MenuItem.DropDownItems.Add(menuItem)
            Next

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            ' LongTermAssetInfoList.GetLongTermAssetInfoList(dateFrom, dateTo, assetGroup)
            _FormManager = New CslaActionExtenderReportForm(Of LongTermAssetInfoList) _
                (Me, LongTermAssetInfoListBindingSource, Nothing, _RequiredCachedLists, RefreshButton, _
                 ProgressFiller1, "GetLongTermAssetInfoList", AddressOf GetReportParams)

            _FormManager.ManageDataListViewStates(LongTermAssetInfoListDataListView)

            PrepareControl(LongTermAssetCustomGroupInfoComboBox, _
                New LongTermAssetCustomGroupFieldAttribute(ValueRequiredLevel.Optional))

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        DateFromAccDatePicker.Value = Today.AddMonths(-3)

        Return True

    End Function


    Private Function GetReportParams() As Object()

        Dim customGroupFilter As LongTermAssetCustomGroupInfo = Nothing
        Try
            customGroupFilter = CType(LongTermAssetCustomGroupInfoComboBox.SelectedItem, LongTermAssetCustomGroupInfo)
        Catch ex As Exception
        End Try

        'LongTermAssetInfoList.GetLongTermAssetInfoList(DateFromDateTimePicker.Value.Date, _
        '    DateToDateTimePicker.Value.Date, customGroupFilter)
        Return New Object() {DateFromAccDatePicker.Value.Date, _
            DateToAccDatePicker.Value.Date, customGroupFilter}

    End Function

    Private Sub ChangeItem(ByVal item As LongTermAssetInfo)
        If item Is Nothing Then Exit Sub
        'LongTermAsset.GetLongTermAsset(item.ID)
        _QueryManager.InvokeQuery(Of LongTermAsset)(Nothing, "GetLongTermAsset", True, _
            AddressOf OpenObjectEditForm, item.ID)
    End Sub

    Private Sub DeleteItem(ByVal item As LongTermAssetInfo)

        If item Is Nothing Then Exit Sub

        If CheckIfObjectEditFormOpen(Of LongTermAsset)(item.ID, True, True) Then Exit Sub

        If Not YesOrNo("Ar tikrai norite pašalinti pasirinkto IT duomenis iš apskaitos?") Then Exit Sub

        'LongTermAsset.DeleteLongTermAsset(item.ID)
        _QueryManager.InvokeQuery(Of LongTermAsset)(Nothing, "DeleteLongTermAsset", False, _
            AddressOf OnItemDeleted, item.ID)

    End Sub

    Private Sub OnItemDeleted(ByVal result As Object, ByVal exceptionHandled As Boolean)
        If exceptionHandled Then Exit Sub
        If Not YesOrNo("Ilgalaikio turto duomenys sėkmingai pašalinti iš įmonės duomenų bazės. Atnaujinti sąrašą?") Then Exit Sub
        RefreshButton.PerformClick()
    End Sub

    Private Sub NewItem(ByVal item As LongTermAssetInfo)
        OpenNewForm(Of LongTermAsset)()
    End Sub

    Private Sub ItemDetails(ByVal item As LongTermAssetInfo)
        If item Is Nothing Then Exit Sub
        AssetOperationManager.ShowAssetOperationInfoList(item.ID)
    End Sub

    Private Sub NewOperationMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If ContextMenuStrip1.Tag Is Nothing Then Exit Sub

        Dim assetID As Integer = 0
        Try
            assetID = DirectCast(ContextMenuStrip1.Tag, LongTermAssetInfo).ID
        Catch ex As Exception
        End Try
        If Not assetID > 0 Then Exit Sub

        Dim operationType As Type = Nothing
        Try
            operationType = DirectCast(DirectCast(sender, ToolStripMenuItem).Tag, Type)
        Catch ex As Exception
        End Try

        If Not assetID > 0 OrElse operationType Is Nothing Then Exit Sub

        AssetOperationManager.StartNewAssetOperation(assetID, operationType)

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
            PrintObject(_FormManager.DataSource, False, 0, "ITSuvestine", Me, _
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
            PrintObject(_FormManager.DataSource, True, 0, "ITSuvestine", Me, _
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