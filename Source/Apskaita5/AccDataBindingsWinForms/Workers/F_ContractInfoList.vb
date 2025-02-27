﻿Imports AccControlsWinForms
Imports AccDataBindingsWinForms.Printing
Imports ApskaitaObjects.ActiveReports
Imports ApskaitaObjects.Workers

Friend Class F_ContractInfoList
    Implements ISupportsPrinting

    Private _FormManager As CslaActionExtenderReportForm(Of ContractInfoList)
    Private _ListViewManager As DataListViewEditControlManager(Of ContractInfo)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_LabourContractInfoList_FormClosed(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        BrightIdeasSoftware.TreeListView.IgnoreMissingAspects = False
    End Sub


    Private Sub F_LabourContractInfoList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        ContractInfoListObjectTreeView.CanExpandGetter = AddressOf CanExpand
        ContractInfoListObjectTreeView.ChildrenGetter = AddressOf ChildrenGetter

    End Sub

    Private Function SetDataSources() As Boolean

        Try

            _ListViewManager = New DataListViewEditControlManager(Of ContractInfo) _
                (ContractInfoListObjectTreeView, Nothing, Nothing, _
                 Nothing, Nothing, Nothing)

            ContractInfoList.GetContractInfoList(Not NotOriginalDataCheckBox.Checked, AtDateCheckBox.Checked, _
                AtDateAccDatePicker.Value, AddWorkersWithoutContractCheckBox.Checked)
            _FormManager = New CslaActionExtenderReportForm(Of ContractInfoList) _
                (Me, ContractInfoListBindingSource, Nothing, Nothing, _
                 RefreshButton, ProgressFiller1, "GetContractInfoList", _
                 AddressOf GetReportParams)

            _FormManager.ManageDataListViewStates(ContractInfoListObjectTreeView)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            BrightIdeasSoftware.TreeListView.IgnoreMissingAspects = True

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Function CanExpand(ByVal item As Object) As Boolean
        If item Is Nothing Then Return False
        If TypeOf item Is ContractInfo Then
            Return (DirectCast(item, ContractInfo).UpdatesList.Count > 0)
        Else
            Return False
        End If
    End Function

    Private Function ChildrenGetter(ByVal item As Object) As LabourContractUpdateInfoList
        If item Is Nothing OrElse Not TypeOf item Is ContractInfo Then Return Nothing
        Return DirectCast(item, ContractInfo).UpdatesList
    End Function

    Private Function GetReportParams() As Object()
        Return New Object() {Not NotOriginalDataCheckBox.Checked, AtDateCheckBox.Checked, _
            AtDateAccDatePicker.Value, AddWorkersWithoutContractCheckBox.Checked}
    End Function


    Private Sub ContractInfoListBindingSource_DataSourceChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles ContractInfoListBindingSource.DataSourceChanged
        If Not ContractInfoListBindingSource.DataSource Is Nothing Then
            Try

                ContractInfoListObjectTreeView.SetObjects(ContractInfoListBindingSource.DataSource)

                If DirectCast(ContractInfoListBindingSource.DataSource, ContractInfoList).Count < 1 _
                    AndAlso Not AddWorkersWithoutContractCheckBox.Checked Then
                    If YesOrNo("Darbo sutarčių pagal nurodytus parametrus nerasta. Pridėti darbuotojus be darbo sutarčių?") Then
                        AddWorkersWithoutContractCheckBox.Checked = True
                        RefreshButton.PerformClick()
                    End If
                End If

            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ContractInfoListObjectTreeView_CellClick(ByVal sender As Object, _
        ByVal e As BrightIdeasSoftware.CellClickEventArgs) Handles ContractInfoListObjectTreeView.CellClick

        If e.Model Is Nothing OrElse e.ClickCount <> 2 Then Exit Sub

        Dim result As String = ""

        If TypeOf e.Model Is ContractInfo Then

            Dim item As ContractInfo = DirectCast(e.Model, ContractInfo)

            Dim contractID As Integer = 0
            Integer.TryParse(DirectCast(e.Model, ContractInfo).ID, contractID)

            If contractID > 0 Then
                result = Ask("", New ButtonStructure("Keisti", "Keisti darbo sutarties duomenis"), _
                    New ButtonStructure("Ištrinti", "Ištrinti darbo sutarties duomenis"), _
                    New ButtonStructure("Nauja Sutartis", "Nauja darbo sutartis"), _
                    New ButtonStructure("Naujas Pakeitimas", "Naujas darbo sutarties pakeitimas"), _
                    New ButtonStructure("Atšaukti", "Nieko nedaryti"))
            Else
                result = Ask("", New ButtonStructure("Nauja Sutartis", "Nauja darbo sutartis"), _
                    New ButtonStructure("Atšaukti", "Nieko nedaryti"))
            End If

            If result <> "Naujas Pakeitimas" AndAlso result <> "Nauja Sutartis" _
                AndAlso result <> "Ištrinti" AndAlso result <> "Keisti" Then Exit Sub

            If result = "Naujas Pakeitimas" Then

                ' ContractUpdate.NewContractUpdate(item.Serial, item.Number)
                _QueryManager.InvokeQuery(Of ContractUpdate)(Nothing, "NewContractUpdate", True, _
                    AddressOf OpenObjectEditForm, item.Serial, CInt(item.Number))

            ElseIf result = "Nauja Sutartis" Then

                ' Contract.NewContract(item.PersonID)
                _QueryManager.InvokeQuery(Of Contract)(Nothing, "NewContract", True, _
                    AddressOf OpenObjectEditForm, item.PersonID)

            ElseIf result = "Ištrinti" Then

                If CheckIfObjectEditFormOpen(Of Contract)(contractID, True, True) Then Exit Sub

                ' Contract.DeleteContract(contractID)
                _QueryManager.InvokeQuery(Of Contract)(Nothing, "DeleteContract", True, _
                    AddressOf OnItemDeleted, contractID)

            ElseIf result = "Keisti" Then
                ' Contract.GetContract(contractID)
                _QueryManager.InvokeQuery(Of Contract)(Nothing, "GetContract", True, _
                    AddressOf OpenObjectEditForm, contractID)
            End If

        ElseIf TypeOf e.Model Is LabourContractUpdateInfo Then

            Dim item As LabourContractUpdateInfo = DirectCast(e.Model, LabourContractUpdateInfo)

            result = Ask("", New ButtonStructure("Keisti", "Keisti darbo sutarties pakeitimo duomenis"), _
                New ButtonStructure("Ištrinti", "Ištrinti darbo sutarties pakeitimo duomenis"), _
                New ButtonStructure("Atšaukti", "Nieko nedaryti"))

            If result <> "Ištrinti" AndAlso result <> "Keisti" Then Exit Sub

            If result = "Ištrinti" Then

                If CheckIfObjectEditFormOpen(Of ContractUpdate)(item.ID, True, True) Then Exit Sub

                ' ContractUpdate.DeleteContractUpdate(item.ID)
                _QueryManager.InvokeQuery(Of ContractUpdate)(Nothing, "DeleteContractUpdate", True, _
                    AddressOf OnSubItemDeleted, item.ID)

            ElseIf result = "Keisti" Then
                ' ContractUpdate.GetContractUpdate(item.ID)
                _QueryManager.InvokeQuery(Of ContractUpdate)(Nothing, "GetContractUpdate", True, _
                    AddressOf OpenObjectEditForm, item.ID)
            End If

        End If

    End Sub

    Private Sub ContractInfoListObjectTreeView_CellRightClick(ByVal sender As Object, _
        ByVal e As BrightIdeasSoftware.CellRightClickEventArgs) Handles ContractInfoListObjectTreeView.CellRightClick

        If e.Model Is Nothing Then Exit Sub

        If TypeOf e.Model Is ContractInfo Then

            Dim contractID As Integer = 0
            Integer.TryParse(DirectCast(e.Model, ContractInfo).ID, contractID)

            ChangeItem_MenuItem.Enabled = (contractID > 0)
            DeleteItem_MenuItem.Enabled = (contractID > 0)
            NewItemUpdate_MenuItem.Enabled = (contractID > 0)

            ContextMenuStrip1.Tag = DirectCast(e.Model, ContractInfo)

            e.MenuStrip = ContextMenuStrip1

        ElseIf TypeOf e.Model Is LabourContractUpdateInfo Then

            ContextMenuStrip2.Tag = DirectCast(e.Model, LabourContractUpdateInfo)

            e.MenuStrip = ContextMenuStrip2

        End If

    End Sub

    Private Sub MenuItem_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ChangeItem_MenuItem.Click, _
        DeleteItem_MenuItem.Click, NewItem_MenuItem.Click, NewItemUpdate_MenuItem.Click, _
        ItemGeneral_MenuItem.Click

        If ContextMenuStrip1.Tag Is Nothing Then Exit Sub

        Dim item As ContractInfo = Nothing
        Try
            item = DirectCast(ContextMenuStrip1.Tag, ContractInfo)
        Catch ex As Exception
        End Try
        If item Is Nothing Then Exit Sub

        Dim contractID As Integer = 0
        Integer.TryParse(item.ID, contractID)

        If sender Is ChangeItem_MenuItem Then

            If Not contractID > 0 Then Exit Sub

            ' Contract.GetContract(contractID)
            _QueryManager.InvokeQuery(Of Contract)(Nothing, "GetContract", True, _
                AddressOf OpenObjectEditForm, contractID)

        ElseIf sender Is DeleteItem_MenuItem Then

            If Not contractID > 0 Then Exit Sub

            If CheckIfObjectEditFormOpen(Of Contract)(contractID, True, True) Then Exit Sub

            ' Contract.DeleteContract(contractID)
            _QueryManager.InvokeQuery(Of Contract)(Nothing, "DeleteContract", True, _
                AddressOf OnItemDeleted, contractID)

        ElseIf sender Is NewItem_MenuItem Then

            ' Contract.NewContract(item.PersonID)
            _QueryManager.InvokeQuery(Of Contract)(Nothing, "NewContract", True, _
                AddressOf OpenObjectEditForm, item.PersonID)

        ElseIf sender Is NewItemUpdate_MenuItem Then

            If Not contractID > 0 Then Exit Sub

            ' ContractUpdate.NewContractUpdate(item.Serial, item.Number)
            _QueryManager.InvokeQuery(Of ContractUpdate)(Nothing, "NewContractUpdate", True, _
                AddressOf OpenObjectEditForm, item.Serial, CInt(item.Number))

        ElseIf sender Is ItemGeneral_MenuItem Then

            ' General.Person.GetPerson(item.PersonID)
            _QueryManager.InvokeQuery(Of General.Person)(Nothing, "GetPerson", True, _
                AddressOf OpenObjectEditForm, item.PersonID)

        End If

    End Sub

    Private Sub OnItemDeleted(ByVal result As Object, ByVal exceptionHandled As Boolean)
        If exceptionHandled Then Exit Sub
        If Not YesOrNo("Darbo sutarties duomenys sėkmingai pašalinti iš duomenų bazės. Atnaujinti sąrašą?") Then Exit Sub
        RefreshButton.PerformClick()
    End Sub

    Private Sub MenuSubItem_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ChangeSubItem_MenuItem.Click, DeleteSubItem_MenuItem.Click

        If ContextMenuStrip2.Tag Is Nothing Then Exit Sub

        Dim item As LabourContractUpdateInfo = Nothing
        Try
            item = DirectCast(ContextMenuStrip2.Tag, LabourContractUpdateInfo)
        Catch ex As Exception
        End Try
        If item Is Nothing Then Exit Sub

        If sender Is ChangeSubItem_MenuItem Then

            ' ContractUpdate.GetContractUpdate(item.ID)
            _QueryManager.InvokeQuery(Of ContractUpdate)(Nothing, "GetContractUpdate", True, _
                AddressOf OpenObjectEditForm, item.ID)

        ElseIf sender Is DeleteSubItem_MenuItem Then

            If CheckIfObjectEditFormOpen(Of ContractUpdate)(item.ID, True, True) Then Exit Sub

            ' ContractUpdate.DeleteContractUpdate(item.ID)
            _QueryManager.InvokeQuery(Of ContractUpdate)(Nothing, "DeleteContractUpdate", True, _
                AddressOf OnSubItemDeleted, item.ID)

        End If

    End Sub

    Private Sub OnSubItemDeleted(ByVal result As Object, ByVal exceptionHandled As Boolean)
        If exceptionHandled Then Exit Sub
        If Not YesOrNo("Darbo sutarties pakeitimo duomenys sėkmingai pašalinti iš duomenų bazės. Atnaujinti sąrašą?") Then Exit Sub
        RefreshButton.PerformClick()
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
            PrintObject(_FormManager.DataSource, False, 0, "", Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, True, 0, "", Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function

End Class