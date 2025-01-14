﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_BankOperation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim AccountLabel As System.Windows.Forms.Label
        Dim ContentLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim DocumentNumberLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim OriginalContentLabel As System.Windows.Forms.Label
        Dim OriginalPersonLabel As System.Windows.Forms.Label
        Dim UniqueCodeLabel As System.Windows.Forms.Label
        Dim PersonLabel As System.Windows.Forms.Label
        Dim CreditCashAccountLabel As System.Windows.Forms.Label
        Dim UniqueCodeInCreditAccountLabel As System.Windows.Forms.Label
        Dim CurrencyRateLabel As System.Windows.Forms.Label
        Dim AccountCurrencyLabel As System.Windows.Forms.Label
        Dim CurrencyRateInAccountLabel As System.Windows.Forms.Label
        Dim CurrencyCodeLabel As System.Windows.Forms.Label
        Dim AccountCurrencyRateChangeImpactLabel As System.Windows.Forms.Label
        Dim SumLabel As System.Windows.Forms.Label
        Dim SumInAccountLabel As System.Windows.Forms.Label
        Dim SumLTLLabel As System.Windows.Forms.Label
        Dim CurrencyRateChangeImpactLabel As System.Windows.Forms.Label
        Dim BankCurrencyConversionCostsLabel As System.Windows.Forms.Label
        Dim SumCorespondencesLabel As System.Windows.Forms.Label
        Dim AccountBankCurrencyConversionCostsLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_BankOperation))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CreditCashAccountAccGridComboBox = New AccControlsWinForms.AccListComboBox()
        Me.BankOperationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UniqueCodeInCreditAccountTextBox = New System.Windows.Forms.TextBox()
        Me.IsTransferBetweenAccountsCheckBox = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button()
        Me.JournalEntryIDTextBox = New System.Windows.Forms.TextBox()
        Me.DocumentNumberTextBox = New System.Windows.Forms.TextBox()
        Me.DateAccDatePicker = New AccControlsWinForms.AccDatePicker()
        Me.PersonAccGridComboBox = New AccControlsWinForms.AccListComboBox()
        Me.AccountAccGridComboBox = New AccControlsWinForms.AccListComboBox()
        Me.ContentTextBox = New System.Windows.Forms.TextBox()
        Me.OriginalContentTextBox = New System.Windows.Forms.TextBox()
        Me.OriginalPersonTextBox = New System.Windows.Forms.TextBox()
        Me.UniqueCodeTextBox = New System.Windows.Forms.TextBox()
        Me.BookEntryItemsSortedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ReconcileButton = New System.Windows.Forms.Button()
        Me.ICancelButton = New System.Windows.Forms.Button()
        Me.IOkButton = New System.Windows.Forms.Button()
        Me.IApplyButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.BookEntryItemsDataListView = New BrightIdeasSoftware.DataListView()
        Me.OlvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CalculateCurrencyRateChangeImpactButton = New System.Windows.Forms.Button()
        Me.IsDebitRadioButton = New System.Windows.Forms.RadioButton()
        Me.AccountBankCurrencyConversionCostsAccGridComboBox = New AccControlsWinForms.AccListComboBox()
        Me.SumCorespondencesAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.BankCurrencyConversionCostsAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.IsCreditRadioButton = New System.Windows.Forms.RadioButton()
        Me.CurrencyRateChangeImpactAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.SumInAccountAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.GetCurrencyRatesButton = New System.Windows.Forms.Button()
        Me.SumAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.CurrencyRateInAccountAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.AccountCurrencyRateChangeImpactAccGridComboBox = New AccControlsWinForms.AccListComboBox()
        Me.SumLTLAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.CurrencyCodeComboBox = New System.Windows.Forms.ComboBox()
        Me.CurrencyRateAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.AccountCurrencyTextBox = New System.Windows.Forms.TextBox()
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller()
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller()
        Me.ErrorWarnInfoProvider1 = New AccControlsWinForms.ErrorWarnInfoProvider(Me.components)
        AccountLabel = New System.Windows.Forms.Label()
        ContentLabel = New System.Windows.Forms.Label()
        DateLabel = New System.Windows.Forms.Label()
        DocumentNumberLabel = New System.Windows.Forms.Label()
        IDLabel = New System.Windows.Forms.Label()
        OriginalContentLabel = New System.Windows.Forms.Label()
        OriginalPersonLabel = New System.Windows.Forms.Label()
        UniqueCodeLabel = New System.Windows.Forms.Label()
        PersonLabel = New System.Windows.Forms.Label()
        CreditCashAccountLabel = New System.Windows.Forms.Label()
        UniqueCodeInCreditAccountLabel = New System.Windows.Forms.Label()
        CurrencyRateLabel = New System.Windows.Forms.Label()
        AccountCurrencyLabel = New System.Windows.Forms.Label()
        CurrencyRateInAccountLabel = New System.Windows.Forms.Label()
        CurrencyCodeLabel = New System.Windows.Forms.Label()
        AccountCurrencyRateChangeImpactLabel = New System.Windows.Forms.Label()
        SumLabel = New System.Windows.Forms.Label()
        SumInAccountLabel = New System.Windows.Forms.Label()
        SumLTLLabel = New System.Windows.Forms.Label()
        CurrencyRateChangeImpactLabel = New System.Windows.Forms.Label()
        BankCurrencyConversionCostsLabel = New System.Windows.Forms.Label()
        SumCorespondencesLabel = New System.Windows.Forms.Label()
        AccountBankCurrencyConversionCostsLabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BankOperationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.BookEntryItemsSortedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.BookEntryItemsDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AccountLabel
        '
        AccountLabel.AutoSize = True
        AccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountLabel.Location = New System.Drawing.Point(102, 32)
        AccountLabel.Name = "AccountLabel"
        AccountLabel.Size = New System.Drawing.Size(60, 13)
        AccountLabel.TabIndex = 0
        AccountLabel.Text = "Sąskaita:"
        '
        'ContentLabel
        '
        ContentLabel.AutoSize = True
        ContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContentLabel.Location = New System.Drawing.Point(110, 59)
        ContentLabel.Name = "ContentLabel"
        ContentLabel.Size = New System.Drawing.Size(52, 13)
        ContentLabel.TabIndex = 6
        ContentLabel.Text = "Turinys:"
        '
        'DateLabel
        '
        DateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DateLabel.AutoSize = True
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(314, 0)
        DateLabel.Name = "DateLabel"
        DateLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        DateLabel.Size = New System.Drawing.Size(38, 18)
        DateLabel.TabIndex = 18
        DateLabel.Text = "Data:"
        '
        'DocumentNumberLabel
        '
        DocumentNumberLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DocumentNumberLabel.AutoSize = True
        DocumentNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DocumentNumberLabel.Location = New System.Drawing.Point(445, 0)
        DocumentNumberLabel.Name = "DocumentNumberLabel"
        DocumentNumberLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        DocumentNumberLabel.Size = New System.Drawing.Size(85, 18)
        DocumentNumberLabel.TabIndex = 20
        DocumentNumberLabel.Text = "Dok. numeris:"
        '
        'IDLabel
        '
        IDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(135, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        IDLabel.Size = New System.Drawing.Size(24, 18)
        IDLabel.TabIndex = 22
        IDLabel.Text = "ID:"
        '
        'OriginalContentLabel
        '
        OriginalContentLabel.AutoSize = True
        OriginalContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        OriginalContentLabel.Location = New System.Drawing.Point(83, 85)
        OriginalContentLabel.Name = "OriginalContentLabel"
        OriginalContentLabel.Size = New System.Drawing.Size(79, 13)
        OriginalContentLabel.TabIndex = 28
        OriginalContentLabel.Text = "Orig. turinys:"
        '
        'OriginalPersonLabel
        '
        OriginalPersonLabel.AutoSize = True
        OriginalPersonLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        OriginalPersonLabel.Location = New System.Drawing.Point(46, 138)
        OriginalPersonLabel.Name = "OriginalPersonLabel"
        OriginalPersonLabel.Size = New System.Drawing.Size(116, 13)
        OriginalPersonLabel.TabIndex = 30
        OriginalPersonLabel.Text = "Orig. kontrahentas:"
        '
        'UniqueCodeLabel
        '
        UniqueCodeLabel.AutoSize = True
        UniqueCodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UniqueCodeLabel.Location = New System.Drawing.Point(85, 164)
        UniqueCodeLabel.Name = "UniqueCodeLabel"
        UniqueCodeLabel.Size = New System.Drawing.Size(77, 13)
        UniqueCodeLabel.TabIndex = 40
        UniqueCodeLabel.Text = "Unikalus ID:"
        '
        'PersonLabel
        '
        PersonLabel.AutoSize = True
        PersonLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PersonLabel.Location = New System.Drawing.Point(76, 111)
        PersonLabel.Name = "PersonLabel"
        PersonLabel.Size = New System.Drawing.Size(86, 13)
        PersonLabel.TabIndex = 42
        PersonLabel.Text = "Kontrahentas:"
        '
        'CreditCashAccountLabel
        '
        CreditCashAccountLabel.AutoSize = True
        CreditCashAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CreditCashAccountLabel.Location = New System.Drawing.Point(35, 22)
        CreditCashAccountLabel.Name = "CreditCashAccountLabel"
        CreditCashAccountLabel.Size = New System.Drawing.Size(118, 13)
        CreditCashAccountLabel.TabIndex = 43
        CreditCashAccountLabel.Text = "Kredituojama sąsk.:"
        '
        'UniqueCodeInCreditAccountLabel
        '
        UniqueCodeInCreditAccountLabel.AutoSize = True
        UniqueCodeInCreditAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UniqueCodeInCreditAccountLabel.Location = New System.Drawing.Point(76, 49)
        UniqueCodeInCreditAccountLabel.Name = "UniqueCodeInCreditAccountLabel"
        UniqueCodeInCreditAccountLabel.Size = New System.Drawing.Size(77, 13)
        UniqueCodeInCreditAccountLabel.TabIndex = 44
        UniqueCodeInCreditAccountLabel.Text = "Unikalus ID:"
        '
        'CurrencyRateLabel
        '
        CurrencyRateLabel.AutoSize = True
        CurrencyRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyRateLabel.Location = New System.Drawing.Point(109, 92)
        CurrencyRateLabel.Name = "CurrencyRateLabel"
        CurrencyRateLabel.Size = New System.Drawing.Size(49, 13)
        CurrencyRateLabel.TabIndex = 12
        CurrencyRateLabel.Text = "Kursas:"
        '
        'AccountCurrencyLabel
        '
        AccountCurrencyLabel.AutoSize = True
        AccountCurrencyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountCurrencyLabel.Location = New System.Drawing.Point(75, 223)
        AccountCurrencyLabel.Name = "AccountCurrencyLabel"
        AccountCurrencyLabel.Size = New System.Drawing.Size(84, 13)
        AccountCurrencyLabel.TabIndex = 2
        AccountCurrencyLabel.Text = "Valiuta sąsk.:"
        '
        'CurrencyRateInAccountLabel
        '
        CurrencyRateInAccountLabel.AutoSize = True
        CurrencyRateInAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyRateInAccountLabel.Location = New System.Drawing.Point(50, 249)
        CurrencyRateInAccountLabel.Name = "CurrencyRateInAccountLabel"
        CurrencyRateInAccountLabel.Size = New System.Drawing.Size(108, 13)
        CurrencyRateInAccountLabel.TabIndex = 16
        CurrencyRateInAccountLabel.Text = "Kursas sąsk. val.:"
        '
        'CurrencyCodeLabel
        '
        CurrencyCodeLabel.AutoSize = True
        CurrencyCodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyCodeLabel.Location = New System.Drawing.Point(108, 65)
        CurrencyCodeLabel.Name = "CurrencyCodeLabel"
        CurrencyCodeLabel.Size = New System.Drawing.Size(50, 13)
        CurrencyCodeLabel.TabIndex = 10
        CurrencyCodeLabel.Text = "Valiuta:"
        '
        'AccountCurrencyRateChangeImpactLabel
        '
        AccountCurrencyRateChangeImpactLabel.AutoSize = True
        AccountCurrencyRateChangeImpactLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountCurrencyRateChangeImpactLabel.Location = New System.Drawing.Point(5, 170)
        AccountCurrencyRateChangeImpactLabel.Name = "AccountCurrencyRateChangeImpactLabel"
        AccountCurrencyRateChangeImpactLabel.Size = New System.Drawing.Size(153, 13)
        AccountCurrencyRateChangeImpactLabel.TabIndex = 4
        AccountCurrencyRateChangeImpactLabel.Text = "Kurso pasik. įtakos sąsk.:"
        '
        'SumLabel
        '
        SumLabel.AutoSize = True
        SumLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumLabel.Location = New System.Drawing.Point(116, 39)
        SumLabel.Name = "SumLabel"
        SumLabel.Size = New System.Drawing.Size(42, 13)
        SumLabel.TabIndex = 32
        SumLabel.Text = "Suma:"
        '
        'SumInAccountLabel
        '
        SumInAccountLabel.AutoSize = True
        SumInAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumInAccountLabel.Location = New System.Drawing.Point(82, 275)
        SumInAccountLabel.Name = "SumInAccountLabel"
        SumInAccountLabel.Size = New System.Drawing.Size(76, 13)
        SumInAccountLabel.TabIndex = 36
        SumInAccountLabel.Text = "Suma sąsk.:"
        '
        'SumLTLLabel
        '
        SumLTLLabel.AutoSize = True
        SumLTLLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumLTLLabel.Location = New System.Drawing.Point(91, 118)
        SumLTLLabel.Name = "SumLTLLabel"
        SumLTLLabel.Size = New System.Drawing.Size(68, 13)
        SumLTLLabel.TabIndex = 38
        SumLTLLabel.Text = "Suma LTL:"
        '
        'CurrencyRateChangeImpactLabel
        '
        CurrencyRateChangeImpactLabel.AutoSize = True
        CurrencyRateChangeImpactLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyRateChangeImpactLabel.Location = New System.Drawing.Point(3, 144)
        CurrencyRateChangeImpactLabel.Name = "CurrencyRateChangeImpactLabel"
        CurrencyRateChangeImpactLabel.Size = New System.Drawing.Size(142, 13)
        CurrencyRateChangeImpactLabel.TabIndex = 14
        CurrencyRateChangeImpactLabel.Text = "Kurso pasikeitimo įtaka:"
        '
        'BankCurrencyConversionCostsLabel
        '
        BankCurrencyConversionCostsLabel.AutoSize = True
        BankCurrencyConversionCostsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BankCurrencyConversionCostsLabel.Location = New System.Drawing.Point(3, 301)
        BankCurrencyConversionCostsLabel.Name = "BankCurrencyConversionCostsLabel"
        BankCurrencyConversionCostsLabel.Size = New System.Drawing.Size(156, 13)
        BankCurrencyConversionCostsLabel.TabIndex = 39
        BankCurrencyConversionCostsLabel.Text = "Banko konvert. sąnaudos:"
        '
        'SumCorespondencesLabel
        '
        SumCorespondencesLabel.AutoSize = True
        SumCorespondencesLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumCorespondencesLabel.Location = New System.Drawing.Point(70, 197)
        SumCorespondencesLabel.Name = "SumCorespondencesLabel"
        SumCorespondencesLabel.Size = New System.Drawing.Size(88, 13)
        SumCorespondencesLabel.TabIndex = 34
        SumCorespondencesLabel.Text = "Suma koresp.:"
        '
        'AccountBankCurrencyConversionCostsLabel
        '
        AccountBankCurrencyConversionCostsLabel.AutoSize = True
        AccountBankCurrencyConversionCostsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountBankCurrencyConversionCostsLabel.Location = New System.Drawing.Point(14, 327)
        AccountBankCurrencyConversionCostsLabel.Name = "AccountBankCurrencyConversionCostsLabel"
        AccountBankCurrencyConversionCostsLabel.Size = New System.Drawing.Size(145, 13)
        AccountBankCurrencyConversionCostsLabel.TabIndex = 40
        AccountBankCurrencyConversionCostsLabel.Text = "Banko konv. sąn. sąsk.:"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Controls.Add(PersonLabel)
        Me.Panel1.Controls.Add(Me.PersonAccGridComboBox)
        Me.Panel1.Controls.Add(AccountLabel)
        Me.Panel1.Controls.Add(Me.AccountAccGridComboBox)
        Me.Panel1.Controls.Add(ContentLabel)
        Me.Panel1.Controls.Add(Me.ContentTextBox)
        Me.Panel1.Controls.Add(OriginalContentLabel)
        Me.Panel1.Controls.Add(Me.OriginalContentTextBox)
        Me.Panel1.Controls.Add(OriginalPersonLabel)
        Me.Panel1.Controls.Add(Me.OriginalPersonTextBox)
        Me.Panel1.Controls.Add(UniqueCodeLabel)
        Me.Panel1.Controls.Add(Me.UniqueCodeTextBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(620, 261)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.CreditCashAccountAccGridComboBox)
        Me.GroupBox1.Controls.Add(UniqueCodeInCreditAccountLabel)
        Me.GroupBox1.Controls.Add(CreditCashAccountLabel)
        Me.GroupBox1.Controls.Add(Me.UniqueCodeInCreditAccountTextBox)
        Me.GroupBox1.Controls.Add(Me.IsTransferBetweenAccountsCheckBox)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 187)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(612, 71)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pavedimas tarp įmonės sąskaitų"
        '
        'CreditCashAccountAccGridComboBox
        '
        Me.CreditCashAccountAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CreditCashAccountAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.BankOperationBindingSource, "CreditCashAccount", True))
        Me.CreditCashAccountAccGridComboBox.EmptyValueString = ""
        Me.CreditCashAccountAccGridComboBox.Enabled = False
        Me.CreditCashAccountAccGridComboBox.Location = New System.Drawing.Point(158, 19)
        Me.CreditCashAccountAccGridComboBox.Name = "CreditCashAccountAccGridComboBox"
        Me.CreditCashAccountAccGridComboBox.Size = New System.Drawing.Size(437, 20)
        Me.CreditCashAccountAccGridComboBox.TabIndex = 1
        '
        'BankOperationBindingSource
        '
        Me.BankOperationBindingSource.DataSource = GetType(ApskaitaObjects.Documents.BankOperation)
        '
        'UniqueCodeInCreditAccountTextBox
        '
        Me.UniqueCodeInCreditAccountTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UniqueCodeInCreditAccountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "UniqueCodeInCreditAccount", True))
        Me.UniqueCodeInCreditAccountTextBox.Location = New System.Drawing.Point(158, 46)
        Me.UniqueCodeInCreditAccountTextBox.MaxLength = 255
        Me.UniqueCodeInCreditAccountTextBox.Name = "UniqueCodeInCreditAccountTextBox"
        Me.UniqueCodeInCreditAccountTextBox.ReadOnly = True
        Me.UniqueCodeInCreditAccountTextBox.Size = New System.Drawing.Size(437, 20)
        Me.UniqueCodeInCreditAccountTextBox.TabIndex = 2
        '
        'IsTransferBetweenAccountsCheckBox
        '
        Me.IsTransferBetweenAccountsCheckBox.AutoSize = True
        Me.IsTransferBetweenAccountsCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BankOperationBindingSource, "IsTransferBetweenAccounts", True))
        Me.IsTransferBetweenAccountsCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsTransferBetweenAccountsCheckBox.Location = New System.Drawing.Point(13, 22)
        Me.IsTransferBetweenAccountsCheckBox.Name = "IsTransferBetweenAccountsCheckBox"
        Me.IsTransferBetweenAccountsCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.IsTransferBetweenAccountsCheckBox.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 9
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ViewJournalEntryButton, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.JournalEntryIDTextBox, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DocumentNumberTextBox, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(DocumentNumberLabel, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(DateLabel, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DateAccDatePicker, 4, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(620, 26)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(287, 0)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 90
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = True
        '
        'JournalEntryIDTextBox
        '
        Me.JournalEntryIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "JournalEntryID", True))
        Me.JournalEntryIDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JournalEntryIDTextBox.Location = New System.Drawing.Point(165, 3)
        Me.JournalEntryIDTextBox.Name = "JournalEntryIDTextBox"
        Me.JournalEntryIDTextBox.ReadOnly = True
        Me.JournalEntryIDTextBox.Size = New System.Drawing.Size(119, 20)
        Me.JournalEntryIDTextBox.TabIndex = 42
        Me.JournalEntryIDTextBox.TabStop = False
        Me.JournalEntryIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DocumentNumberTextBox
        '
        Me.DocumentNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "DocumentNumber", True))
        Me.DocumentNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentNumberTextBox.Location = New System.Drawing.Point(536, 3)
        Me.DocumentNumberTextBox.MaxLength = 50
        Me.DocumentNumberTextBox.Name = "DocumentNumberTextBox"
        Me.DocumentNumberTextBox.Size = New System.Drawing.Size(61, 20)
        Me.DocumentNumberTextBox.TabIndex = 1
        Me.DocumentNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateAccDatePicker
        '
        Me.DateAccDatePicker.BoldedDates = Nothing
        Me.DateAccDatePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.BankOperationBindingSource, "Date", True))
        Me.DateAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateAccDatePicker.Location = New System.Drawing.Point(358, 3)
        Me.DateAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateAccDatePicker.Name = "DateAccDatePicker"
        Me.DateAccDatePicker.ShowWeekNumbers = True
        Me.DateAccDatePicker.Size = New System.Drawing.Size(61, 20)
        Me.DateAccDatePicker.TabIndex = 0
        '
        'PersonAccGridComboBox
        '
        Me.PersonAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PersonAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.BankOperationBindingSource, "Person", True))
        Me.PersonAccGridComboBox.EmptyValueString = ""
        Me.PersonAccGridComboBox.Location = New System.Drawing.Point(163, 108)
        Me.PersonAccGridComboBox.Name = "PersonAccGridComboBox"
        Me.PersonAccGridComboBox.Size = New System.Drawing.Size(437, 20)
        Me.PersonAccGridComboBox.TabIndex = 3
        '
        'AccountAccGridComboBox
        '
        Me.AccountAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AccountAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.BankOperationBindingSource, "Account", True))
        Me.AccountAccGridComboBox.EmptyValueString = ""
        Me.AccountAccGridComboBox.Location = New System.Drawing.Point(163, 29)
        Me.AccountAccGridComboBox.Name = "AccountAccGridComboBox"
        Me.AccountAccGridComboBox.Size = New System.Drawing.Size(437, 20)
        Me.AccountAccGridComboBox.TabIndex = 1
        '
        'ContentTextBox
        '
        Me.ContentTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "Content", True))
        Me.ContentTextBox.Location = New System.Drawing.Point(163, 56)
        Me.ContentTextBox.MaxLength = 255
        Me.ContentTextBox.Name = "ContentTextBox"
        Me.ContentTextBox.Size = New System.Drawing.Size(437, 20)
        Me.ContentTextBox.TabIndex = 2
        '
        'OriginalContentTextBox
        '
        Me.OriginalContentTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OriginalContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "OriginalContent", True))
        Me.OriginalContentTextBox.Location = New System.Drawing.Point(163, 82)
        Me.OriginalContentTextBox.Name = "OriginalContentTextBox"
        Me.OriginalContentTextBox.ReadOnly = True
        Me.OriginalContentTextBox.Size = New System.Drawing.Size(437, 20)
        Me.OriginalContentTextBox.TabIndex = 29
        Me.OriginalContentTextBox.TabStop = False
        '
        'OriginalPersonTextBox
        '
        Me.OriginalPersonTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OriginalPersonTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "OriginalPerson", True))
        Me.OriginalPersonTextBox.Location = New System.Drawing.Point(163, 135)
        Me.OriginalPersonTextBox.Name = "OriginalPersonTextBox"
        Me.OriginalPersonTextBox.ReadOnly = True
        Me.OriginalPersonTextBox.Size = New System.Drawing.Size(437, 20)
        Me.OriginalPersonTextBox.TabIndex = 31
        Me.OriginalPersonTextBox.TabStop = False
        '
        'UniqueCodeTextBox
        '
        Me.UniqueCodeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UniqueCodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "UniqueCode", True))
        Me.UniqueCodeTextBox.Location = New System.Drawing.Point(163, 161)
        Me.UniqueCodeTextBox.MaxLength = 255
        Me.UniqueCodeTextBox.Name = "UniqueCodeTextBox"
        Me.UniqueCodeTextBox.Size = New System.Drawing.Size(437, 20)
        Me.UniqueCodeTextBox.TabIndex = 4
        '
        'BookEntryItemsSortedBindingSource
        '
        Me.BookEntryItemsSortedBindingSource.DataMember = "BookEntryItems"
        Me.BookEntryItemsSortedBindingSource.DataSource = Me.BankOperationBindingSource
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.ReconcileButton)
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 620)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(620, 32)
        Me.Panel2.TabIndex = 1
        '
        'ReconcileButton
        '
        Me.ReconcileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReconcileButton.Location = New System.Drawing.Point(3, 6)
        Me.ReconcileButton.Name = "ReconcileButton"
        Me.ReconcileButton.Size = New System.Drawing.Size(109, 23)
        Me.ReconcileButton.TabIndex = 42
        Me.ReconcileButton.Text = "Dengti $ Sąskaitas"
        Me.ReconcileButton.UseVisualStyleBackColor = True
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(519, 6)
        Me.ICancelButton.Name = "ICancelButton"
        Me.ICancelButton.Size = New System.Drawing.Size(89, 23)
        Me.ICancelButton.TabIndex = 3
        Me.ICancelButton.Text = "Atšaukti"
        Me.ICancelButton.UseVisualStyleBackColor = True
        '
        'IOkButton
        '
        Me.IOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IOkButton.Location = New System.Drawing.Point(313, 6)
        Me.IOkButton.Name = "IOkButton"
        Me.IOkButton.Size = New System.Drawing.Size(89, 23)
        Me.IOkButton.TabIndex = 1
        Me.IOkButton.Text = "Ok"
        Me.IOkButton.UseVisualStyleBackColor = True
        '
        'IApplyButton
        '
        Me.IApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IApplyButton.Location = New System.Drawing.Point(417, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 2
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.90503!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.09497!))
        Me.TableLayoutPanel2.Controls.Add(Me.BookEntryItemsDataListView, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 261)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(620, 359)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'BookEntryItemsDataListView
        '
        Me.BookEntryItemsDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.BookEntryItemsDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.BookEntryItemsDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.BookEntryItemsDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.BookEntryItemsDataListView.AllowColumnReorder = True
        Me.BookEntryItemsDataListView.AutoGenerateColumns = False
        Me.BookEntryItemsDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.BookEntryItemsDataListView.CellEditEnterChangesRows = True
        Me.BookEntryItemsDataListView.CellEditTabChangesRows = True
        Me.BookEntryItemsDataListView.CellEditUseWholeCell = False
        Me.BookEntryItemsDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4})
        Me.BookEntryItemsDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.BookEntryItemsDataListView.DataSource = Me.BookEntryItemsSortedBindingSource
        Me.BookEntryItemsDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BookEntryItemsDataListView.FullRowSelect = True
        Me.BookEntryItemsDataListView.HasCollapsibleGroups = False
        Me.BookEntryItemsDataListView.HeaderWordWrap = True
        Me.BookEntryItemsDataListView.HideSelection = False
        Me.BookEntryItemsDataListView.HighlightBackgroundColor = System.Drawing.Color.PaleGreen
        Me.BookEntryItemsDataListView.HighlightForegroundColor = System.Drawing.Color.Black
        Me.BookEntryItemsDataListView.IncludeColumnHeadersInCopy = True
        Me.BookEntryItemsDataListView.Location = New System.Drawing.Point(300, 3)
        Me.BookEntryItemsDataListView.Name = "BookEntryItemsDataListView"
        Me.BookEntryItemsDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.BookEntryItemsDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.BookEntryItemsDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.BookEntryItemsDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.BookEntryItemsDataListView.ShowCommandMenuOnRightClick = True
        Me.BookEntryItemsDataListView.ShowGroups = False
        Me.BookEntryItemsDataListView.ShowImagesOnSubItems = True
        Me.BookEntryItemsDataListView.ShowItemCountOnGroups = True
        Me.BookEntryItemsDataListView.ShowItemToolTips = True
        Me.BookEntryItemsDataListView.Size = New System.Drawing.Size(317, 353)
        Me.BookEntryItemsDataListView.TabIndex = 3
        Me.BookEntryItemsDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.BookEntryItemsDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.BookEntryItemsDataListView.UseCellFormatEvents = True
        Me.BookEntryItemsDataListView.UseCompatibleStateImageBehavior = False
        Me.BookEntryItemsDataListView.UseFilterIndicator = True
        Me.BookEntryItemsDataListView.UseFiltering = True
        Me.BookEntryItemsDataListView.UseHotItem = True
        Me.BookEntryItemsDataListView.UseNotifyPropertyChanged = True
        Me.BookEntryItemsDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "Account"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.Text = "Sąskaita"
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 102
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "ID"
        Me.OlvColumn1.CellEditUseWholeCell = True
        Me.OlvColumn1.DisplayIndex = 1
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.IsEditable = False
        Me.OlvColumn1.IsVisible = False
        Me.OlvColumn1.Text = "ID"
        Me.OlvColumn1.ToolTipText = ""
        Me.OlvColumn1.Width = 100
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "Amount"
        Me.OlvColumn3.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.Text = "Suma"
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 100
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "Person"
        Me.OlvColumn4.CellEditUseWholeCell = True
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.Text = "Kontrahentas"
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 177
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.AutoSize = True
        Me.Panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel3.Controls.Add(Me.CalculateCurrencyRateChangeImpactButton)
        Me.Panel3.Controls.Add(AccountBankCurrencyConversionCostsLabel)
        Me.Panel3.Controls.Add(Me.IsDebitRadioButton)
        Me.Panel3.Controls.Add(Me.AccountBankCurrencyConversionCostsAccGridComboBox)
        Me.Panel3.Controls.Add(SumCorespondencesLabel)
        Me.Panel3.Controls.Add(BankCurrencyConversionCostsLabel)
        Me.Panel3.Controls.Add(Me.SumCorespondencesAccTextBox)
        Me.Panel3.Controls.Add(Me.BankCurrencyConversionCostsAccTextBox)
        Me.Panel3.Controls.Add(CurrencyRateChangeImpactLabel)
        Me.Panel3.Controls.Add(Me.IsCreditRadioButton)
        Me.Panel3.Controls.Add(Me.CurrencyRateChangeImpactAccTextBox)
        Me.Panel3.Controls.Add(Me.SumInAccountAccTextBox)
        Me.Panel3.Controls.Add(Me.GetCurrencyRatesButton)
        Me.Panel3.Controls.Add(SumLTLLabel)
        Me.Panel3.Controls.Add(Me.SumAccTextBox)
        Me.Panel3.Controls.Add(SumInAccountLabel)
        Me.Panel3.Controls.Add(SumLabel)
        Me.Panel3.Controls.Add(AccountCurrencyRateChangeImpactLabel)
        Me.Panel3.Controls.Add(CurrencyCodeLabel)
        Me.Panel3.Controls.Add(Me.CurrencyRateInAccountAccTextBox)
        Me.Panel3.Controls.Add(Me.AccountCurrencyRateChangeImpactAccGridComboBox)
        Me.Panel3.Controls.Add(Me.SumLTLAccTextBox)
        Me.Panel3.Controls.Add(Me.CurrencyCodeComboBox)
        Me.Panel3.Controls.Add(CurrencyRateInAccountLabel)
        Me.Panel3.Controls.Add(AccountCurrencyLabel)
        Me.Panel3.Controls.Add(CurrencyRateLabel)
        Me.Panel3.Controls.Add(Me.CurrencyRateAccTextBox)
        Me.Panel3.Controls.Add(Me.AccountCurrencyTextBox)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(291, 353)
        Me.Panel3.TabIndex = 0
        '
        'CalculateCurrencyRateChangeImpactButton
        '
        Me.CalculateCurrencyRateChangeImpactButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.calculator_16
        Me.CalculateCurrencyRateChangeImpactButton.Location = New System.Drawing.Point(144, 141)
        Me.CalculateCurrencyRateChangeImpactButton.Name = "CalculateCurrencyRateChangeImpactButton"
        Me.CalculateCurrencyRateChangeImpactButton.Size = New System.Drawing.Size(20, 20)
        Me.CalculateCurrencyRateChangeImpactButton.TabIndex = 41
        Me.CalculateCurrencyRateChangeImpactButton.UseVisualStyleBackColor = True
        '
        'IsDebitRadioButton
        '
        Me.IsDebitRadioButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IsDebitRadioButton.AutoSize = True
        Me.IsDebitRadioButton.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BankOperationBindingSource, "IsDebit", True))
        Me.IsDebitRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsDebitRadioButton.Location = New System.Drawing.Point(114, 12)
        Me.IsDebitRadioButton.Name = "IsDebitRadioButton"
        Me.IsDebitRadioButton.Size = New System.Drawing.Size(72, 17)
        Me.IsDebitRadioButton.TabIndex = 0
        Me.IsDebitRadioButton.Text = "Debetas"
        '
        'AccountBankCurrencyConversionCostsAccGridComboBox
        '
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.BankOperationBindingSource, "AccountBankCurrencyConversionCosts", True))
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.EmptyValueString = ""
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.Location = New System.Drawing.Point(163, 324)
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.Name = "AccountBankCurrencyConversionCostsAccGridComboBox"
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.Size = New System.Drawing.Size(110, 20)
        Me.AccountBankCurrencyConversionCostsAccGridComboBox.TabIndex = 10
        '
        'SumCorespondencesAccTextBox
        '
        Me.SumCorespondencesAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SumCorespondencesAccTextBox.ButtonVisible = False
        Me.SumCorespondencesAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "SumCorespondences", True))
        Me.SumCorespondencesAccTextBox.Location = New System.Drawing.Point(164, 194)
        Me.SumCorespondencesAccTextBox.Name = "SumCorespondencesAccTextBox"
        Me.SumCorespondencesAccTextBox.ReadOnly = True
        Me.SumCorespondencesAccTextBox.Size = New System.Drawing.Size(109, 20)
        Me.SumCorespondencesAccTextBox.TabIndex = 35
        Me.SumCorespondencesAccTextBox.TabStop = False
        Me.SumCorespondencesAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BankCurrencyConversionCostsAccTextBox
        '
        Me.BankCurrencyConversionCostsAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BankCurrencyConversionCostsAccTextBox.ButtonVisible = False
        Me.BankCurrencyConversionCostsAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "BankCurrencyConversionCosts", True))
        Me.BankCurrencyConversionCostsAccTextBox.Location = New System.Drawing.Point(164, 298)
        Me.BankCurrencyConversionCostsAccTextBox.Name = "BankCurrencyConversionCostsAccTextBox"
        Me.BankCurrencyConversionCostsAccTextBox.ReadOnly = True
        Me.BankCurrencyConversionCostsAccTextBox.Size = New System.Drawing.Size(109, 20)
        Me.BankCurrencyConversionCostsAccTextBox.TabIndex = 9
        Me.BankCurrencyConversionCostsAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IsCreditRadioButton
        '
        Me.IsCreditRadioButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IsCreditRadioButton.AutoSize = True
        Me.IsCreditRadioButton.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.BankOperationBindingSource, "IsCredit", True))
        Me.IsCreditRadioButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsCreditRadioButton.Location = New System.Drawing.Point(202, 12)
        Me.IsCreditRadioButton.Name = "IsCreditRadioButton"
        Me.IsCreditRadioButton.Size = New System.Drawing.Size(71, 17)
        Me.IsCreditRadioButton.TabIndex = 1
        Me.IsCreditRadioButton.Text = "Kreditas"
        '
        'CurrencyRateChangeImpactAccTextBox
        '
        Me.CurrencyRateChangeImpactAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrencyRateChangeImpactAccTextBox.ButtonVisible = False
        Me.CurrencyRateChangeImpactAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "CurrencyRateChangeImpact", True))
        Me.CurrencyRateChangeImpactAccTextBox.Location = New System.Drawing.Point(164, 141)
        Me.CurrencyRateChangeImpactAccTextBox.Name = "CurrencyRateChangeImpactAccTextBox"
        Me.CurrencyRateChangeImpactAccTextBox.Size = New System.Drawing.Size(109, 20)
        Me.CurrencyRateChangeImpactAccTextBox.TabIndex = 6
        Me.CurrencyRateChangeImpactAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumInAccountAccTextBox
        '
        Me.SumInAccountAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SumInAccountAccTextBox.ButtonVisible = False
        Me.SumInAccountAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "SumInAccount", True))
        Me.SumInAccountAccTextBox.Location = New System.Drawing.Point(164, 272)
        Me.SumInAccountAccTextBox.Name = "SumInAccountAccTextBox"
        Me.SumInAccountAccTextBox.Size = New System.Drawing.Size(109, 20)
        Me.SumInAccountAccTextBox.TabIndex = 9
        Me.SumInAccountAccTextBox.TabStop = False
        Me.SumInAccountAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GetCurrencyRatesButton
        '
        Me.GetCurrencyRatesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetCurrencyRatesButton.Location = New System.Drawing.Point(53, 60)
        Me.GetCurrencyRatesButton.Name = "GetCurrencyRatesButton"
        Me.GetCurrencyRatesButton.Size = New System.Drawing.Size(46, 23)
        Me.GetCurrencyRatesButton.TabIndex = 4
        Me.GetCurrencyRatesButton.Text = "$->€"
        Me.GetCurrencyRatesButton.UseVisualStyleBackColor = True
        '
        'SumAccTextBox
        '
        Me.SumAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SumAccTextBox.ButtonVisible = False
        Me.SumAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "Sum", True))
        Me.SumAccTextBox.Location = New System.Drawing.Point(163, 36)
        Me.SumAccTextBox.Name = "SumAccTextBox"
        Me.SumAccTextBox.Size = New System.Drawing.Size(110, 20)
        Me.SumAccTextBox.TabIndex = 2
        Me.SumAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrencyRateInAccountAccTextBox
        '
        Me.CurrencyRateInAccountAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrencyRateInAccountAccTextBox.ButtonVisible = False
        Me.CurrencyRateInAccountAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "CurrencyRateInAccount", True))
        Me.CurrencyRateInAccountAccTextBox.DecimalLength = 6
        Me.CurrencyRateInAccountAccTextBox.Location = New System.Drawing.Point(164, 246)
        Me.CurrencyRateInAccountAccTextBox.Name = "CurrencyRateInAccountAccTextBox"
        Me.CurrencyRateInAccountAccTextBox.NegativeValue = False
        Me.CurrencyRateInAccountAccTextBox.Size = New System.Drawing.Size(109, 20)
        Me.CurrencyRateInAccountAccTextBox.TabIndex = 8
        Me.CurrencyRateInAccountAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccountCurrencyRateChangeImpactAccGridComboBox
        '
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.BankOperationBindingSource, "AccountCurrencyRateChangeImpact", True))
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.EmptyValueString = ""
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.Location = New System.Drawing.Point(163, 167)
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.Name = "AccountCurrencyRateChangeImpactAccGridComboBox"
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.Size = New System.Drawing.Size(110, 20)
        Me.AccountCurrencyRateChangeImpactAccGridComboBox.TabIndex = 7
        '
        'SumLTLAccTextBox
        '
        Me.SumLTLAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SumLTLAccTextBox.ButtonVisible = False
        Me.SumLTLAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "SumLTL", True))
        Me.SumLTLAccTextBox.Location = New System.Drawing.Point(163, 115)
        Me.SumLTLAccTextBox.Name = "SumLTLAccTextBox"
        Me.SumLTLAccTextBox.ReadOnly = True
        Me.SumLTLAccTextBox.Size = New System.Drawing.Size(110, 20)
        Me.SumLTLAccTextBox.TabIndex = 39
        Me.SumLTLAccTextBox.TabStop = False
        Me.SumLTLAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrencyCodeComboBox
        '
        Me.CurrencyCodeComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrencyCodeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "CurrencyCode", True))
        Me.CurrencyCodeComboBox.FormattingEnabled = True
        Me.CurrencyCodeComboBox.Location = New System.Drawing.Point(163, 62)
        Me.CurrencyCodeComboBox.Name = "CurrencyCodeComboBox"
        Me.CurrencyCodeComboBox.Size = New System.Drawing.Size(110, 21)
        Me.CurrencyCodeComboBox.TabIndex = 3
        '
        'CurrencyRateAccTextBox
        '
        Me.CurrencyRateAccTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CurrencyRateAccTextBox.ButtonVisible = False
        Me.CurrencyRateAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BankOperationBindingSource, "CurrencyRate", True))
        Me.CurrencyRateAccTextBox.DecimalLength = 6
        Me.CurrencyRateAccTextBox.Location = New System.Drawing.Point(163, 89)
        Me.CurrencyRateAccTextBox.Name = "CurrencyRateAccTextBox"
        Me.CurrencyRateAccTextBox.NegativeValue = False
        Me.CurrencyRateAccTextBox.Size = New System.Drawing.Size(110, 20)
        Me.CurrencyRateAccTextBox.TabIndex = 5
        Me.CurrencyRateAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccountCurrencyTextBox
        '
        Me.AccountCurrencyTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AccountCurrencyTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BankOperationBindingSource, "AccountCurrency", True))
        Me.AccountCurrencyTextBox.Location = New System.Drawing.Point(164, 220)
        Me.AccountCurrencyTextBox.Name = "AccountCurrencyTextBox"
        Me.AccountCurrencyTextBox.ReadOnly = True
        Me.AccountCurrencyTextBox.Size = New System.Drawing.Size(109, 20)
        Me.AccountCurrencyTextBox.TabIndex = 3
        Me.AccountCurrencyTextBox.TabStop = False
        Me.AccountCurrencyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(138, 274)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(163, 80)
        Me.ProgressFiller1.TabIndex = 2
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(317, 272)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(173, 82)
        Me.ProgressFiller2.TabIndex = 3
        Me.ProgressFiller2.Visible = False
        '
        'ErrorWarnInfoProvider1
        '
        Me.ErrorWarnInfoProvider1.ContainerControl = Me
        Me.ErrorWarnInfoProvider1.DataSource = Me.BankOperationBindingSource
        '
        'F_BankOperation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(620, 652)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_BankOperation"
        Me.ShowInTaskbar = False
        Me.Text = "Banko operacija"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.BankOperationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.BookEntryItemsSortedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.BookEntryItemsDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AccountAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents BankOperationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DocumentNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OriginalContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OriginalPersonTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UniqueCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PersonAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents BookEntryItemsSortedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents IsTransferBetweenAccountsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents UniqueCodeInCreditAccountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CreditCashAccountAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents JournalEntryIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
    Friend WithEvents BookEntryItemsDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CalculateCurrencyRateChangeImpactButton As System.Windows.Forms.Button
    Friend WithEvents IsDebitRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AccountBankCurrencyConversionCostsAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents SumCorespondencesAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents BankCurrencyConversionCostsAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents IsCreditRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents CurrencyRateChangeImpactAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents SumInAccountAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents GetCurrencyRatesButton As System.Windows.Forms.Button
    Friend WithEvents SumAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrencyRateInAccountAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents AccountCurrencyRateChangeImpactAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents SumLTLAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrencyCodeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CurrencyRateAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents AccountCurrencyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ErrorWarnInfoProvider1 As AccControlsWinForms.ErrorWarnInfoProvider
    Friend WithEvents DateAccDatePicker As AccControlsWinForms.AccDatePicker
    Friend WithEvents ReconcileButton As Button
End Class
