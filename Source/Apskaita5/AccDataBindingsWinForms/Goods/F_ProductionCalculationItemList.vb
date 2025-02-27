﻿Imports ApskaitaObjects.ActiveReports
Imports AccControlsWinForms

Friend Class F_ProductionCalculationItemList

    Private _FormManager As CslaActionExtenderReportForm(Of ProductionCalculationItemList)
    Private _ListViewManager As DataListViewEditControlManager(Of ProductionCalculationItem)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_ProductionCalculationItemList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            _ListViewManager = New DataListViewEditControlManager(Of ProductionCalculationItem) _
                (ProductionCalculationItemListDataListView, ContextMenuStrip1, Nothing, _
                 Nothing, Nothing, Nothing)

            _ListViewManager.AddCancelButton = True
            _ListViewManager.AddButtonHandler("Keisti", "Keisti gamybos kalkuliacijos duomenis.", _
                AddressOf ChangeItem)
            _ListViewManager.AddButtonHandler("Ištrinti", "Pašalinti gamybos kalkuliacijos duomenis iš duomenų bazės.", _
                AddressOf DeleteItem)

            _ListViewManager.AddMenuItemHandler(ChangeItem_MenuItem, AddressOf ChangeItem)
            _ListViewManager.AddMenuItemHandler(DeleteItem_MenuItem, AddressOf DeleteItem)
            _ListViewManager.AddMenuItemHandler(NewItem_MenuItem, AddressOf NewItem)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            ' ProductionCalculationItemList.GetProductionCalculationItemList()
            _FormManager = New CslaActionExtenderReportForm(Of ProductionCalculationItemList) _
                (Me, ProductionCalculationItemListBindingSource, Nothing, Nothing, RefreshButton, _
                 ProgressFiller1, "GetProductionCalculationItemList", AddressOf GetReportParams)

            _FormManager.ManageDataListViewStates(ProductionCalculationItemListDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
        End Try

    End Sub


    Private Function GetReportParams() As Object()
        Return New Object() {}
    End Function

    Private Sub ChangeItem(ByVal item As ProductionCalculationItem)
        If item Is Nothing Then Exit Sub
        ' Goods.ProductionCalculation.GetProductionCalculation(item.ID)
        _QueryManager.InvokeQuery(Of Goods.ProductionCalculation)(Nothing, "GetProductionCalculation", True, _
            AddressOf OpenObjectEditForm, item.ID)
    End Sub

    Private Sub DeleteItem(ByVal item As ProductionCalculationItem)

        If item Is Nothing Then Exit Sub

        If CheckIfObjectEditFormOpen(Of Goods.ProductionCalculation)(item.ID, True, True) Then Exit Sub

        If Not YesOrNo("Ar tikrai norite pašalinti gamybos kalkuliacijos duomenis iš duomenų bazės?") Then Exit Sub

        'Goods.ProductionCalculation.DeleteProductionCalculation(item.ID)
        _QueryManager.InvokeQuery(Of Goods.ProductionCalculation)(Nothing, "DeleteProductionCalculation", False, _
            AddressOf OnItemDeleted, item.ID)

    End Sub

    Private Sub OnItemDeleted(ByVal result As Object, ByVal exceptionHandled As Boolean)
        If exceptionHandled Then Exit Sub
        If Not YesOrNo("Kalkuliacijos duomenys sėkmingai pašalinti iš įmonės duomenų bazės. Atnaujinti sąrašą?") Then Exit Sub
        RefreshButton.PerformClick()
    End Sub

    Private Sub NewItem(ByVal item As ProductionCalculationItem)
        OpenNewForm(Of Goods.ProductionCalculation)()
    End Sub

End Class