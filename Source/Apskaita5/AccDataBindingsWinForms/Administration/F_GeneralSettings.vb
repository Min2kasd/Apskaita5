﻿Imports ApskaitaObjects.Settings
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists
Imports ApskaitaObjects.Attributes

Friend Class F_GeneralSettings
    Implements ISingleInstanceForm

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of ApskaitaObjects.Settings.CommonSettings)
    Private _TaxRateListViewManager As DataListViewEditControlManager(Of TaxRate)
    Private _NameListViewManager As DataListViewEditControlManager(Of Name)
    Private _CodeListViewManager As DataListViewEditControlManager(Of Code)
    Private _DefaultWorkTimeListViewManager As DataListViewEditControlManager(Of DefaultWorkTime)
    Private _PublicHolidayListViewManager As DataListViewEditControlManager(Of PublicHoliday)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_GeneralSettings_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            PrepareControl(PastedCodeTypeComboBox, New LocalizedEnumFieldAttribute(
                GetType(CodeType), False, ""))

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            'ApskaitaObjects.Settings.CommonSettings.GetCommonSettings()
            _QueryManager.InvokeQuery(Of CommonSettings)(Nothing,
                "GetCommonSettings", True, AddressOf OnDataSourceLoaded)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

    End Sub

    Private Sub OnDataSourceLoaded(ByVal source As Object, ByVal exceptionHandled As Boolean)

        If exceptionHandled Then

            DisableAllControls(Me)
            Exit Sub

        ElseIf source Is Nothing Then

            ShowError(New Exception("Klaida. Nepavyko gauti bendrų nustatymų duomenų."), Nothing)
            DisableAllControls(Me)
            Exit Sub

        End If

        Dim result As CommonSettings = DirectCast(source, CommonSettings)

        Try

            _TaxRateListViewManager = New DataListViewEditControlManager(Of TaxRate) _
                (TaxRatesDataListView, Nothing, AddressOf OnTaxItemsDelete, _
                 AddressOf OnTaxItemAdd, Nothing, result)

            _NameListViewManager = New DataListViewEditControlManager(Of Name) _
                (NamesDataListView, Nothing, AddressOf OnNameItemsDelete, _
                 AddressOf OnNameItemAdd, Nothing, result)

            _CodeListViewManager = New DataListViewEditControlManager(Of Code) _
                (CodesDataListView, Nothing, AddressOf OnCodeItemsDelete, _
                 AddressOf OnCodeItemAdd, Nothing, result)

            _DefaultWorkTimeListViewManager = New DataListViewEditControlManager(Of DefaultWorkTime) _
                (DefaultWorkTimesDataListView, Nothing, AddressOf OnWorkTimeItemsDelete, _
                 AddressOf OnWorkTimeItemAdd, Nothing, result)

            _PublicHolidayListViewManager = New DataListViewEditControlManager(Of PublicHoliday) _
                (PublicHolidaysDataListView, Nothing, AddressOf OnPublicHolidayItemsDelete, _
                 AddressOf OnPublicHolidayItemAdd, Nothing, result)

            _FormManager = New CslaActionExtenderEditForm(Of CommonSettings) _
                (Me, CommonSettingsBindingSource, result, Nothing, nOkButton,
                 ApplyButton, nCancelButton, Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(TaxRatesDataListView, CodesDataListView, _
                NamesDataListView, PublicHolidaysDataListView, DefaultWorkTimesDataListView)

        Catch ex As Exception
            ShowError(ex, result)
            DisableAllControls(Me)
            Exit Sub
        End Try

        nOkButton.Enabled = CommonSettings.CanEditObject
        ApplyButton.Enabled = CommonSettings.CanEditObject

    End Sub


    Private Sub OnTaxItemsDelete(ByVal items As TaxRate())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        For Each item As TaxRate In items
            _FormManager.DataSource.TaxRates.Remove(item)
        Next
    End Sub

    Private Sub OnTaxItemAdd()
        _FormManager.DataSource.TaxRates.AddNew()
    End Sub

    Private Sub OnNameItemsDelete(ByVal items As Name())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        For Each item As Name In items
            _FormManager.DataSource.Names.Remove(item)
        Next
    End Sub

    Private Sub OnNameItemAdd()
        _FormManager.DataSource.Names.AddNew()
    End Sub

    Private Sub OnCodeItemsDelete(ByVal items As Code())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        For Each item As Code In items
            _FormManager.DataSource.Codes.Remove(item)
        Next
    End Sub

    Private Sub OnCodeItemAdd()
        _FormManager.DataSource.Codes.AddNew()
    End Sub

    Private Sub OnWorkTimeItemsDelete(ByVal items As DefaultWorkTime())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        For Each item As DefaultWorkTime In items
            _FormManager.DataSource.DefaultWorkTimes.Remove(item)
        Next
    End Sub

    Private Sub OnWorkTimeItemAdd()
        _FormManager.DataSource.DefaultWorkTimes.AddNew()
    End Sub

    Private Sub OnPublicHolidayItemsDelete(ByVal items As PublicHoliday())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        For Each item As PublicHoliday In items
            _FormManager.DataSource.PublicHolidays.Remove(item)
        Next
    End Sub

    Private Sub OnPublicHolidayItemAdd()
        _FormManager.DataSource.PublicHolidays.AddNew()
    End Sub


    Private Sub PasteCodesButton_Click(sender As Object, e As EventArgs) Handles PasteCodesButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Dim source As String = Clipboard.GetText()

        If source Is Nothing OrElse String.IsNullOrEmpty(source.Trim) Then
            MsgBox("Klaida. Clipboard'as tuščias, nėra ką kopijuoti.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        ElseIf Not source.Contains(vbtab) Then
            MsgBox("Klaida. Clipboard'e kodas ir jo pavadinimas/aprašymas nėra atskirti tab simboliais.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        If PastedCodeTypeComboBox.SelectedIndex < 0 Then
            MsgBox("Klaida. Nepasirinktas paste'inamų kodų tipas.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Try

            Dim pastedType As CodeType = ConvertLocalizedName(Of CodeType) _
                (PastedCodeTypeComboBox.SelectedItem.ToString)

            Dim lineSeparator As String = Nothing
            Dim hasLines As Boolean = True
            If source.Contains(vbCrLf) Then
                lineSeparator = vbCrLf
            ElseIf source.Contains(vbLf) Then
                lineSeparator = vbLf
            ElseIf source.Contains(vbCr) Then
                lineSeparator = vbCr
            Else
                hasLines = False
            End If

            Using busy As New StatusBusy
                If hasLines Then
                    For Each line As String In source.Split(New String() {lineSeparator}, StringSplitOptions.RemoveEmptyEntries)
                        AddNewCodeFromString(line, pastedType)
                    Next
                Else
                    AddNewCodeFromString(source, pastedType)
                End If
            End Using

        Catch ex As Exception
            ShowError(ex, source)
        End Try

    End Sub

    Private Sub AddNewCodeFromString(line As String, pastedType As CodeType)
        Dim fields As String() = line.Split(New Char() {vbTab}, StringSplitOptions.None)
        Dim newCode As Code = _FormManager.DataSource.Codes.AddNew()
        newCode.Type = pastedType
        If fields.Length > 1 Then
            newCode.Code = fields(0)
            newCode.Name = fields(1)
        Else
            newCode.Code = line
        End If
    End Sub

    Private Sub PasteDefaultWorkTimeItemsButton_Click(sender As Object, e As EventArgs) _
        Handles PasteDefaultWorkTimeItemsButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Dim data As DataTable = F_DataImport.GetImportedData(DefaultWorkTime.GetDataTableSpecification)
        If data Is Nothing Then Exit Sub

        Try
            Using busy As New StatusBusy
                _FormManager.DataSource.DefaultWorkTimes.AddImportedItems(data)
            End Using
        Catch ex As Exception
            ShowError(ex, data)
        End Try

    End Sub

End Class