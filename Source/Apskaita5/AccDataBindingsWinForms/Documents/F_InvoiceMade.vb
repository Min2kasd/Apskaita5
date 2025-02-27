﻿Imports ApskaitaObjects.Documents
Imports ApskaitaObjects.Settings
Imports ApskaitaObjects.Documents.InvoiceAdapters
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.Printing
Imports AccDataBindingsWinForms.CachedInfoLists
Imports AccControlsWinForms.WebControls

Friend Class F_InvoiceMade
    Implements ISupportsPrinting, IObjectEditForm, ISupportsChronologicValidator

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.DocumentSerialInfoList), GetType(HelperLists.PersonInfoList), _
        GetType(HelperLists.AccountInfoList), GetType(HelperLists.CompanyRegionalInfoList), _
        GetType(HelperLists.TaxRateInfoList), GetType(AccDataAccessLayer.Security.UserProfile), _
        GetType(HelperLists.RegionalInfoDictionary), GetType(HelperLists.VatDeclarationSchemaInfoList)}

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of InvoiceMade)
    Private _ListViewManager As DataListViewEditControlManager(Of InvoiceMadeItem)
    Private _QueryManager As CslaActionExtenderQueryObject

    Private _DocumentToEdit As InvoiceMade = Nothing

    Private _PrintDropDown As Windows.Forms.ToolStripDropDown = Nothing
    Private _PrintPreviewDropDown As Windows.Forms.ToolStripDropDown = Nothing
    Private _EmailDropDown As Windows.Forms.ToolStripDropDown = Nothing


    Public ReadOnly Property ObjectID() As Integer _
        Implements IObjectEditForm.ObjectID
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

    Public ReadOnly Property ObjectType() As System.Type _
        Implements IObjectEditForm.ObjectType
        Get
            Return GetType(InvoiceMade)
        End Get
    End Property


    Public Sub New(ByVal documentToEdit As InvoiceMade)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _DocumentToEdit = documentToEdit

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()


    End Sub


    Private Sub F_InvoiceMade_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        If _DocumentToEdit Is Nothing Then
            _DocumentToEdit = InvoiceMade.NewInvoiceMade()
        End If

        Try

            _FormManager = New CslaActionExtenderEditForm(Of InvoiceMade) _
                (Me, InvoiceMadeBindingSource, _DocumentToEdit, _
                _RequiredCachedLists, IOkButton, IApplyButton, ICancelButton, _
                Nothing, ProgressFiller1)

            _FormManager.AddNewDataSourceButton(NewButton, "NewInvoiceMade")

            _FormManager.ManageDataListViewStates(InvoiceItemsDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        ConfigureButtons()

        Try
            If _FormManager.DataSource.IsNew AndAlso StringIsNullOrEmpty(_FormManager.DataSource.Serial) Then
                _FormManager.DataSource.Serial = HelperLists.DocumentSerialInfoList. _
                    GetCachedFilteredList(False, DocumentSerialType.Invoice)(0).Serial
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _ListViewManager = New DataListViewEditControlManager(Of InvoiceMadeItem) _
                (InvoiceItemsDataListView, Nothing, AddressOf OnItemsDelete, _
                 AddressOf OnItemAdd, Nothing, _DocumentToEdit)

            _ListViewManager.AddCancelButton = False
            _ListViewManager.AddButtonHandler("Susietas Objektas", "Redaguoti susietą objektą.", _
                AddressOf OnItemClicked)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            SetupDefaultControls(Of InvoiceMade)(Me, InvoiceMadeBindingSource, _DocumentToEdit)

            Dim adapters As List(Of TypeItem) = GetInvoiceAdapterTypes()
            NewAdapterTypeComboBox.DataSource = adapters

            Dim defaultAdapterType As Type = GetType(ServiceInvoiceAdapter)
            If MyCustomSettings.DefaultInvoiceMadeItemIsGoods Then
                defaultAdapterType = GetType(GoodsSaleInvoiceAdapter)
            End If
            For Each t As TypeItem In adapters
                If t.Type Is defaultAdapterType Then
                    NewAdapterTypeComboBox.SelectedItem = t
                    Exit For
                End If
            Next

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Sub OnItemsDelete(ByVal items As InvoiceMadeItem())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.ChronologyValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Keisti dokumento finansinių duomenų negalima, įskaitant eilučių pridėjimą ar ištrynimą:{0}{1}", vbCrLf, _
                _FormManager.DataSource.ChronologyValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        For Each item As InvoiceMadeItem In items
            If Not item.AttachedObjectValue Is Nothing AndAlso Not item.AttachedObjectValue. _
            ChronologyValidator.FinancialDataCanChange Then
                MsgBox(String.Format("Klaida. Eilutės pašalinti neleidžiama:{0}{1}", vbCrLf, _
                    item.AttachedObjectValue.ChronologyValidator.FinancialDataCanChangeExplanation), _
                    MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            End If
        Next
        For Each item As InvoiceMadeItem In items
            _FormManager.DataSource.InvoiceItemsSorted.Remove(item)
        Next
    End Sub

    Private Sub OnItemAdd()
        If _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.ChronologyValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Keisti dokumento finansinių duomenų negalima, įskaitant eilučių pridėjimą ar ištrynimą:{0}{1}", vbCrLf, _
                _FormManager.DataSource.ChronologyValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        _FormManager.DataSource.InvoiceItemsSorted.AddNew()
    End Sub

    Private Sub OnItemClicked(ByVal item As InvoiceMadeItem)

        If item Is Nothing OrElse item.AttachedObjectValue Is Nothing _
            OrElse item.AttachedObjectValue.Type = InvoiceAdapterType.Service Then Exit Sub

        OpenObjectEditForm(item.AttachedObjectValue.ValueObject)

    End Sub

    Private Sub GetCurrencyRatesButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles GetCurrencyRatesButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        If Not YesOrNo("Gauti valiutos kursą?") Then Exit Sub

        Dim factory As CurrencyRateFactoryBase = Nothing
        Dim result As CurrencyRate = Nothing
        Try
            factory = WebControls.GetCurrencyRateFactory(GetCurrentCompany.BaseCurrency)
            result = WebControls.GetCurrencyRateWithProgress(_FormManager.DataSource.CurrencyCode.Trim.ToUpper, _
                _FormManager.DataSource.Date, factory)
        Catch ex As Exception
            ShowError(ex, Nothing)
            Exit Sub
        End Try

        If Not result Is Nothing Then
            _FormManager.DataSource.CurrencyRate = result.Rate
        End If

    End Sub

    Private Sub AddAttachedObjectButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles AddAttachedObjectButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Dim selectedType As TypeItem = Nothing
        Try
            selectedType = DirectCast(NewAdapterTypeComboBox.SelectedItem, TypeItem)
        Catch ex As Exception
        End Try
        If selectedType Is Nothing Then Exit Sub

        Dim adapter As IInvoiceAdapter = GetNewInvoiceAdapter(selectedType.Type, False, _
            _FormManager.DataSource.ChronologyValidator.BaseValidator)
        If adapter Is Nothing Then Exit Sub

        Dim item As InvoiceMadeItem = Nothing

        Dim regionalDictionary As HelperLists.RegionalInfoDictionary
        Try
            regionalDictionary = HelperLists.RegionalInfoDictionary.GetList()
        Catch ex As Exception
            ShowError(ex, Nothing)
            Exit Sub
        End Try

        Dim asRegionalizable As IRegionalDataObject = Nothing
        Try
            asRegionalizable = DirectCast(adapter, IRegionalDataObject)
        Catch ex As Exception
        End Try

        Dim addExempt As Boolean = False

        If Not asRegionalizable Is Nothing Then

            Dim exempt As String = ""
            Dim exemptLT As String = ""
            Dim hasExempt As Boolean = False

            hasExempt = regionalDictionary.GetVatExempts(asRegionalizable.RegionalObjectType, _
                asRegionalizable.RegionalObjectID, _FormManager.DataSource.LanguageCode, exemptLT, exempt)

            If hasExempt Then

                Dim question As String = "Pasirinktam objektui yra priskirta PVM išimtis:"

                If LanguagesEquals(_FormManager.DataSource.LanguageCode, LanguageCodeLith, LanguageCodeLith) Then
                    question = AddWithNewLine(question, exemptLT, True)
                Else
                    question = AddWithNewLine(question, "Lietuvių kalba:", True)
                    question = AddWithNewLine(question, exemptLT, True)
                    question = AddWithNewLine(question, "Užsienio kalba:", True)
                    question = AddWithNewLine(question, exempt, True)
                End If

                question = AddWithNewLine(question, "", True)

                question = AddWithNewLine(question, "Pridėti prie sąskaitos faktūros PVM išimčių?", True)

                addExempt = YesOrNo(question)

            End If

        End If

        Try

            Using busy As New StatusBusy
                item = _FormManager.DataSource.AttachNewObject(adapter, regionalDictionary, addExempt)
            End Using

        Catch ex As Exception
            ShowError(ex, New Object() {_FormManager.DataSource, adapter, regionalDictionary, addExempt})
            Exit Sub
        End Try

        If item.AttachedObjectValue.Type <> InvoiceAdapterType.Service Then
            OpenObjectEditForm(item.AttachedObjectValue.ValueObject)
        End If

    End Sub

    Private Sub RefreshNumberButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles RefreshNumberButton.Click

        If _FormManager.DataSource Is Nothing OrElse StringIsNullOrEmpty(_FormManager.DataSource.Serial) Then Exit Sub

        If Not _FormManager.DataSource.IsNew Then
            If Not YesOrNo("DĖMESIO. Jūs redaguojate jau įtrauktą į duomenų bazę dokumentą. " _
                & "Ar tikrai norite suteikti jam naują numerį?") Then Exit Sub
        End If

        'CommandLastDocumentNumber.TheCommand(DocumentSerialType.Invoice, _
        '    _FormManager.DataSource.Serial.Trim, _FormManager.DataSource.Date, _
        '    _FormManager.DataSource.AddDateToNumberOptionWasUsed)
        _QueryManager.InvokeQuery(Of CommandLastDocumentNumber)(Nothing, "TheCommand", True, _
            AddressOf OnInvoiceNumberFetched, DocumentSerialType.Invoice, _
            _FormManager.DataSource.Serial.Trim, _FormManager.DataSource.Date, _
            _FormManager.DataSource.AddDateToNumberOptionWasUsed)

    End Sub

    Private Sub OnInvoiceNumberFetched(ByVal result As Object, ByVal exceptionHandled As Boolean)

        If result Is Nothing Then Exit Sub

        _FormManager.DataSource.Number = DirectCast(result, Integer) + 1

    End Sub

    Private Sub CopyInvoiceButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CopyInvoiceButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Dim info As InvoiceInfo.InvoiceInfo = Nothing
        Try
            Using busy As New StatusBusy
                info = _FormManager.DataSource.GetInvoiceInfo(InstanceGuid.ToString)
            End Using
        Catch ex As Exception
            ShowError(New Exception(String.Format("Klaida. Nepavyko generuoti InvoiceInfo objekto:{0}{1}",
                vbCrLf, ex.Message), ex), _FormManager.DataSource)
            Exit Sub
        End Try

        If info Is Nothing Then
            MsgBox("Klaida. Dėl nežinomų priežasčių nepavyko generuoti InvoiceInfo objekto.", _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Try
            Using busy As New StatusBusy
                System.Windows.Forms.Clipboard.SetText(InvoiceInfo.Factory. _
                    ToXmlString(Of InvoiceInfo.InvoiceInfo)(info), TextDataFormat.UnicodeText)
            End Using
        Catch ex As Exception
            ShowError(New Exception(String.Format("Klaida. Nepavyko serializuoti InvoiceInfo objekto:{0}{1}",
                vbCrLf, ex.Message), ex), info)
            Exit Sub
        End Try

        MsgBox("Sąskaita sėkmingai nukopijuota į ClipBoard'ą.", MsgBoxStyle.Information, "Info")

    End Sub

    Private Sub PasteInvoiceButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles PasteInvoiceButton.Click

        Dim clipboardText As String = System.Windows.Forms.Clipboard.GetText(TextDataFormat.UnicodeText)

        If StringIsNullOrEmpty(clipboardText) Then

            MsgBox("Klaida. ClipBoard'as tuščias, t.y. nebuvo nukopijuota jokia sąskaita.", _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub

        End If

        Dim info As InvoiceInfo.InvoiceInfo = Nothing
        Try
            Using busy As New StatusBusy
                info = InvoiceInfo.Factory.FromXmlString(Of InvoiceInfo.InvoiceInfo)(clipboardText)
            End Using
        Catch ex As Exception
            ShowError(New Exception(String.Format("Klaida. Nepavyko atkurti sąskaitos objekto. " _
                & "Teigtina, kad prieš tai į ClipBoard'ą buvo nukopijuota ne sąskaita, " _
                & "o šiaip kažkoks tekstas.{0}Klaidos tekstas:{1}", vbCrLf, ex.Message), ex), clipboardText)
            Exit Sub
        End Try

        If info Is Nothing Then
            MsgBox("Klaida. Dėl nežinomų priežasčių nepavyko atkurti sąskaitos objekto.", _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        Dim useExternalID As Boolean = False

        If InstanceGuid.ToString.Trim <> info.SystemGuid.Trim Then

            Dim answer As String

            If info.ExternalID Is Nothing OrElse String.IsNullOrEmpty(info.ExternalID.Trim) Then
                If Not MyCustomSettings.AlwaysUseExternalIdInvoicesMade Then
                    answer = Ask("Sąskaita yra kopijuojama iš išorinės sistemos. " _
                        & "Ką priskirti išoriniam ID?", New ButtonStructure("Nieko", _
                        "Nepriskirti jokio išorinio ID."), New ButtonStructure( _
                        "ID", "Sąskaitos ID laikyti išoriniu ID."), New ButtonStructure( _
                        "Atšaukti", "Atšaukti kopijavimą."))
                Else
                    answer = "ID"
                End If
            Else
                answer = Ask("Sąskaita yra kopijuojama iš išorinės sistemos. " _
                    & "Ką priskirti išoriniam ID?", New ButtonStructure("Nieko", _
                    "Nepriskirti jokio išorinio ID."), New ButtonStructure( _
                    "ID", "Sąskaitos ID laikyti išoriniu ID."), New ButtonStructure( _
                    "Išorinį ID", "Sąskaitos išorinį ID laikyti išoriniu ID."), _
                    New ButtonStructure("Atšaukti", "Atšaukti kopijavimą."))
            End If

            If answer = "Nieko" Then
                info.SystemGuid = InstanceGuid.ToString.Trim
            ElseIf answer = "Atšaukti" Then
                Exit Sub
            ElseIf answer = "Išorinį ID" Then
                useExternalID = True
            End If

        End If

        Dim newObj As InvoiceMade = Nothing
        Dim newPerson As InvoiceInfo.ClientInfo = Nothing
        Try
            Using busy As New StatusBusy
                Dim personList As HelperLists.PersonInfoList = HelperLists.PersonInfoList.GetList()
                Dim accountList As HelperLists.AccountInfoList = HelperLists.AccountInfoList.GetList()
                Dim vatSchemaList As HelperLists.VatDeclarationSchemaInfoList = _
                    HelperLists.VatDeclarationSchemaInfoList.GetList()
                Dim serviceList As HelperLists.ServiceInfoList = _
                        HelperLists.ServiceInfoList.GetList()
                newObj = InvoiceMade.NewInvoiceMade(info, InstanceGuid.ToString, _
                    useExternalID, personList, accountList, vatSchemaList, serviceList, newPerson)
            End Using
        Catch ex As Exception
            ShowError(New Exception(String.Format("Klaida. Nepavyko įkrauti kopijuojamos sąskaitos duomenų:{0}{1}",
                vbCrLf, ex.Message), ex), info)
            Exit Sub
        End Try

        If newObj Is Nothing Then
            MsgBox("Klaida. Dėl nežinomų priežasčių nepavyko įkrauti kopijuojamos sąskaitos duomenų.", _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If

        If Not StringIsNullOrEmpty(newObj.ExternalID) Then

            Dim existingInvoiceID As Integer = 0

            Try
                Using busy As New StatusBusy
                    existingInvoiceID = CommandDocumentIdByExternalId.TheCommand(Of InvoiceMade)( _
                        newObj.ExternalID)
                End Using
            Catch ex As Exception
                ShowError(ex, Nothing)
                Exit Sub
            End Try

            If existingInvoiceID > 0 Then
                If YesOrNo(String.Format("DĖMESIO. Sąskaita su tokiu išoriniu ID jau egzistuoja. " _
                    & "Įvesti sąskaitą iš naujo nebus leidžiama.{0}{1}Atidaryti egzistuojančią sąskaitą?", _
                    vbCrLf, vbCrLf)) Then
                    'InvoiceMade.GetInvoiceMade(existingInvoiceID)
                    _QueryManager.InvokeQuery(Of InvoiceMade)(Nothing, "GetInvoiceMade", True, _
                        AddressOf OpenObjectEditForm, existingInvoiceID)
                End If
                Exit Sub
            End If

        End If

        _FormManager.AddNewDataSource(newObj)

        If Not newPerson Is Nothing Then
            OpenObjectEditForm(newPerson)
        End If

    End Sub

    Private Sub ViewJournalEntryButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ViewJournalEntryButton.Click
        If _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.IsNew Then Exit Sub
        OpenJournalEntryEditForm(_QueryManager, _FormManager.DataSource.ID)
    End Sub


    Public Function GetMailDropDownItems() As System.Windows.Forms.ToolStripDropDown _
       Implements ISupportsPrinting.GetMailDropDownItems

        If _EmailDropDown Is Nothing Then
            _EmailDropDown = New ToolStripDropDown
            _EmailDropDown.Items.Add("Lietuvių klb.", Nothing, AddressOf OnMailClick)
        End If

        Return _EmailDropDown

    End Function

    Public Function GetPrintDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintDropDownItems

        If _PrintDropDown Is Nothing Then
            _PrintDropDown = New ToolStripDropDown
            _PrintDropDown.Items.Add("Lietuvių klb.", Nothing, AddressOf OnPrintClick)

        End If

        Return _PrintDropDown

    End Function

    Public Function GetPrintPreviewDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintPreviewDropDownItems

        If _PrintPreviewDropDown Is Nothing Then
            _PrintPreviewDropDown = New ToolStripDropDown
            _PrintPreviewDropDown.Items.Add("Lietuvių klb.", Nothing, AddressOf OnPrintPreviewClick)

        End If

        Return _PrintPreviewDropDown

    End Function

    Public Sub OnMailClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnMailClick
        If _FormManager.DataSource Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(_FormManager.DataSource, Convert.ToInt32(IIf(GetSenderText(sender).ToLower.Contains("lietuvių"), 1, 0)))
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, False, Convert.ToInt32(IIf(GetSenderText(sender).ToLower.Contains("lietuvių"), 1, 0)), _
                _FormManager.DataSource.GetFileName(), Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Dim r As Dictionary(Of Type, List(Of String)) = GetContainedValueObjectLists(_FormManager.DataSource)
        Try
            PrintObject(_FormManager.DataSource, True, Convert.ToInt32(IIf(GetSenderText(sender).ToLower.Contains("lietuvių"), 1, 0)), _
                _FormManager.DataSource.GetFileName(), Me, "")
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
        Return _FormManager.DataSource.ChronologyValidator.LimitsExplanation
    End Function

    Public Function HasChronologicContent() As Boolean _
        Implements ISupportsChronologicValidator.HasChronologicContent

        Return Not _FormManager.DataSource Is Nothing AndAlso _
            Not StringIsNullOrEmpty(_FormManager.DataSource.ChronologyValidator.LimitsExplanation)

    End Function


    Private Sub _FormManager_DataSourceStateHasChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles _FormManager.DataSourceStateHasChanged
        ConfigureButtons()
        Try
            If _FormManager.DataSource.IsNew AndAlso StringIsNullOrEmpty(_FormManager.DataSource.Serial) Then
                _FormManager.DataSource.Serial = HelperLists.DocumentSerialInfoList.
                    GetCachedFilteredList(False, DocumentSerialType.Invoice)(0).Serial
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ConfigureButtons()

        If _FormManager.DataSource Is Nothing Then Exit Sub

        CurrencyCodeComboBox.Enabled = Not _FormManager.DataSource.CurrencyCodeIsReadOnly
        GetCurrencyRatesButton.Enabled = Not _FormManager.DataSource.CurrencyRateIsReadOnly
        CurrencyRateAccTextBox.ReadOnly = _FormManager.DataSource.CurrencyRateIsReadOnly
        AccountPayerAccGridComboBox.Enabled = Not _FormManager.DataSource.AccountPayerIsReadOnly
        AddAttachedObjectButton.Enabled = _FormManager.DataSource.ChronologyValidator.BaseValidator.FinancialDataCanChange

        ICancelButton.Enabled = Not _FormManager.DataSource.IsNew

    End Sub

End Class