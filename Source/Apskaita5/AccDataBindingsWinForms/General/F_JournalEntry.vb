﻿Imports AccControlsWinForms
Imports AccDataBindingsWinForms.Printing
Imports AccDataBindingsWinForms.CachedInfoLists
Imports ApskaitaObjects.General

Friend Class F_JournalEntry
    Implements ISupportsPrinting, IObjectEditForm, ISupportsChronologicValidator

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.PersonInfoList), GetType(HelperLists.AccountInfoList),
        GetType(HelperLists.TemplateJournalEntryInfoList)}

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of JournalEntry)
    Private _ListViewManagerCredit As DataListViewEditControlManager(Of BookEntry)
    Private _ListViewManagerDebit As DataListViewEditControlManager(Of BookEntry)
    Private _QueryManager As CslaActionExtenderQueryObject

    Private _JournalEntryToEdit As JournalEntry


    Public Sub New(ByVal journalEntryToEdit As General.JournalEntry)
        InitializeComponent()
        _JournalEntryToEdit = journalEntryToEdit
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If _FormManager Is Nothing OrElse _FormManager.DataSource Is Nothing Then
                If _JournalEntryToEdit Is Nothing OrElse _JournalEntryToEdit.IsNew Then
                    Return Integer.MinValue
                Else
                    Return _JournalEntryToEdit.ID
                End If
            ElseIf _FormManager.DataSource.IsNew Then
                Return Integer.MinValue
            End If
            Return _FormManager.DataSource.ID
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(General.JournalEntry)
        End Get
    End Property


    Private Sub F_GeneralLedgerEntry_Load(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles MyBase.Load

        If _JournalEntryToEdit Is Nothing Then
            _JournalEntryToEdit = JournalEntry.NewJournalEntry()
        End If

        If Not SetDataSources() Then Exit Sub

        Try

            _FormManager = New CslaActionExtenderEditForm(Of JournalEntry) _
                (Me, JournalEntryBindingSource, _JournalEntryToEdit,
                 _RequiredCachedLists, nOkButton, ApplyButton, nCancelButton,
                 Nothing, ProgressFiller1)

            _FormManager.AddNewDataSourceButton(NewItemButton, "NewJournalEntry")

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti bendrojo žurnalo įrašo duomenų.", ex), Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        If _JournalEntryToEdit.DocType <> DocumentType.None Then

            DisableAllControls(Me)
            ViewRelationsButton.Enabled = True
            ViewDocumentButton.Enabled = True
            ViewDocumentButton.Visible = (_JournalEntryToEdit.DocType <> DocumentType.ClosingEntries)

        ElseIf Not _JournalEntryToEdit.IsNew AndAlso Not General.JournalEntry.CanEditObject Then

            DisableAllControls(Me)
            ViewRelationsButton.Enabled = True
            MsgBox("Klaida. Jūsų teisių nepakanka informacijai redaguoti.",
                MsgBoxStyle.Exclamation, "Klaida")

        Else
            ConfigureButtons()
        End If

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _ListViewManagerCredit = New DataListViewEditControlManager(Of BookEntry) _
                (CreditListDataListView, Nothing, AddressOf OnItemsDeleteCredit,
                 AddressOf OnItemAddCredit, Nothing, _JournalEntryToEdit)

            _ListViewManagerDebit = New DataListViewEditControlManager(Of BookEntry) _
                (DebitListDataListView, Nothing, AddressOf OnItemsDeleteDebit,
                 AddressOf OnItemAddDebit, Nothing, _JournalEntryToEdit)

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            TemplateComboBox.DataSource = HelperLists.TemplateJournalEntryInfoList.GetCachedFilteredList(True)
            TemplateComboBox.ValueMember = "Name"
            TemplateComboBox.DisplayMember = "Name"

            SetupDefaultControls(Of JournalEntry)(Me,
                JournalEntryBindingSource, _JournalEntryToEdit)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Sub OnItemsDeleteCredit(ByVal items As BookEntry())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing _
            OrElse _FormManager.DataSource.DocType <> DocumentType.None Then Exit Sub
        If Not _FormManager.DataSource.ChronologyValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Eilučių pašalinti neleidžiama:{0}{1}", vbCrLf,
                _FormManager.DataSource.ChronologyValidator.FinancialDataCanChangeExplanation),
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        For Each item As BookEntry In items
            _FormManager.DataSource.CreditList.Remove(item)
        Next
    End Sub

    Private Sub OnItemsDeleteDebit(ByVal items As BookEntry())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing _
            OrElse _FormManager.DataSource.DocType <> DocumentType.None Then Exit Sub
        If Not _FormManager.DataSource.ChronologyValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Eilučių pašalinti neleidžiama:{0}{1}", vbCrLf,
                _FormManager.DataSource.ChronologyValidator.FinancialDataCanChangeExplanation),
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        For Each item As BookEntry In items
            _FormManager.DataSource.DebetList.Remove(item)
        Next
    End Sub

    Private Sub OnItemAddCredit()
        If _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.DocType <> DocumentType.None Then Exit Sub
        If Not _FormManager.DataSource.ChronologyValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Keisti dokumento finansinių duomenų negalima, įskaitant kontavimų pridėjimą:{0}{1}", vbCrLf,
                _FormManager.DataSource.ChronologyValidator.FinancialDataCanChangeExplanation),
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        _FormManager.DataSource.CreditList.AddNew()
    End Sub

    Private Sub OnItemAddDebit()
        If _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.DocType <> DocumentType.None Then Exit Sub
        If Not _FormManager.DataSource.ChronologyValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Keisti dokumento finansinių duomenų negalima, įskaitant kontavimų pridėjimą:{0}{1}", vbCrLf,
                _FormManager.DataSource.ChronologyValidator.FinancialDataCanChangeExplanation),
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        _FormManager.DataSource.DebetList.AddNew()
    End Sub


    Private Sub LoadTemplateButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles LoadTemplateButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        If Not _FormManager.DataSource.IsNew AndAlso Not General.JournalEntry.CanEditObject Then Exit Sub

        If Not _FormManager.DataSource.IsNew AndAlso Not YesOrNo("DĖMESIO. Jūs redaguojate jau " &
            "registruotą apskaitoje įrašą. Ar tikrai norite įkrauti šabloną?") Then Exit Sub

        If TemplateComboBox.SelectedIndex < 0 Then
            MsgBox("Klaida. Nepasirinktas šablonas.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        Dim template As HelperLists.TemplateJournalEntryInfo = Nothing
        Try
            template = DirectCast(TemplateComboBox.SelectedItem, HelperLists.TemplateJournalEntryInfo)
        Catch ex As Exception
        End Try
        If template Is Nothing Then
            MsgBox("Klaida. Nepasirinktas šablonas.", MsgBoxStyle.Exclamation, "Klaida.")
            Exit Sub
        End If

        _FormManager.DataSource.LoadJournalEntryFromTemplate(template)

    End Sub

    Private Sub ViewRelationsButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ViewRelationsButton.Click
        If _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.IsNew Then Exit Sub
        _QueryManager.InvokeQuery(Of HelperLists.IndirectRelationInfoList) _
            (Nothing, "GetIndirectRelationInfoList", True,
             AddressOf OpenObjectEditForm, _FormManager.DataSource.ID)
    End Sub

    Private Sub ViewDocumentButton_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles ViewDocumentButton.Click
        If _FormManager.DataSource Is Nothing OrElse _FormManager.DataSource.DocType = DocumentType.ClosingEntries _
            OrElse _FormManager.DataSource.DocType = DocumentType.None Then Exit Sub
        OpenObjectEditForm(_QueryManager, _FormManager.DataSource.ID, _FormManager.DataSource.DocType)
    End Sub

    Private Sub BalanceButton_Click(sender As Object, e As EventArgs) Handles BalanceButton.Click
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            _FormManager.DataSource.BalanceEntriesAmounts()
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
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

        Using frm As New F_SendObjToEmail(_FormManager.DataSource, 0)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, False, 0, "BuhalterinePazyma", Me, "")
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If _FormManager.DataSource Is Nothing Then Exit Sub
        Try
            PrintObject(_FormManager.DataSource, True, 0, "BuhalterinePazyma", Me, "")
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

        Return Not _FormManager.DataSource Is Nothing AndAlso
            Not StringIsNullOrEmpty(_FormManager.DataSource.ChronologyValidator.LimitsExplanation)

    End Function


    Private Sub ConfigureButtons() Handles _FormManager.DataSourceStateHasChanged

        If _FormManager.DataSource Is Nothing Then Exit Sub

        LoadTemplateButton.Enabled = _FormManager.DataSource.ChronologyValidator.FinancialDataCanChange
        TemplateComboBox.Enabled = _FormManager.DataSource.ChronologyValidator.FinancialDataCanChange

        nCancelButton.Enabled = Not _FormManager.DataSource.IsNew

        _ListViewManagerDebit.IsReadOnly = Not _FormManager.DataSource.ChronologyValidator.FinancialDataCanChange
        _ListViewManagerCredit.IsReadOnly = Not _FormManager.DataSource.ChronologyValidator.FinancialDataCanChange

    End Sub

End Class