﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_Offset
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
        Me.components = New System.ComponentModel.Container
        Dim ContentLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim DocumentNumberLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim SumCreditLabel As System.Windows.Forms.Label
        Dim SumDebitLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_Offset))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.ContentTextBox = New System.Windows.Forms.TextBox
        Me.OffsetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.DocumentNumberTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.SumDebitAccTextBox = New AccControlsWinForms.AccTextBox
        Me.SumCreditAccTextBox = New AccControlsWinForms.AccTextBox
        Me.BalanceSumAccTextBox = New AccControlsWinForms.AccTextBox
        Me.BalanceAccountAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.GetCurrencyRatesButton = New System.Windows.Forms.Button
        Me.BalanceButton = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.ItemListSortedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemListDataListView = New BrightIdeasSoftware.DataListView
        Me.OlvColumn2 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn1 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn3 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn4 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn5 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn6 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn7 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn8 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn9 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn10 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn11 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn12 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn13 = New BrightIdeasSoftware.OLVColumn
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.ErrorWarnInfoProvider1 = New AccControlsWinForms.ErrorWarnInfoProvider(Me.components)
        Me.DateAccDatePicker = New AccControlsWinForms.AccDatePicker
        ContentLabel = New System.Windows.Forms.Label
        DateLabel = New System.Windows.Forms.Label
        DocumentNumberLabel = New System.Windows.Forms.Label
        IDLabel = New System.Windows.Forms.Label
        SumCreditLabel = New System.Windows.Forms.Label
        SumDebitLabel = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.OffsetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ItemListSortedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContentLabel
        '
        ContentLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ContentLabel.AutoSize = True
        ContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContentLabel.Location = New System.Drawing.Point(3, 27)
        ContentLabel.Name = "ContentLabel"
        ContentLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        ContentLabel.Size = New System.Drawing.Size(52, 18)
        ContentLabel.TabIndex = 4
        ContentLabel.Text = "Turinys:"
        '
        'DateLabel
        '
        DateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DateLabel.AutoSize = True
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(215, 0)
        DateLabel.Name = "DateLabel"
        DateLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        DateLabel.Size = New System.Drawing.Size(38, 18)
        DateLabel.TabIndex = 6
        DateLabel.Text = "Data:"
        '
        'DocumentNumberLabel
        '
        DocumentNumberLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DocumentNumberLabel.AutoSize = True
        DocumentNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DocumentNumberLabel.Location = New System.Drawing.Point(475, 0)
        DocumentNumberLabel.Name = "DocumentNumberLabel"
        DocumentNumberLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        DocumentNumberLabel.Size = New System.Drawing.Size(59, 18)
        DocumentNumberLabel.TabIndex = 8
        DocumentNumberLabel.Text = "Dok. Nr.:"
        '
        'IDLabel
        '
        IDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(31, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        IDLabel.Size = New System.Drawing.Size(24, 18)
        IDLabel.TabIndex = 10
        IDLabel.Text = "ID:"
        '
        'SumCreditLabel
        '
        SumCreditLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SumCreditLabel.AutoSize = True
        SumCreditLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumCreditLabel.Location = New System.Drawing.Point(218, 0)
        SumCreditLabel.Name = "SumCreditLabel"
        SumCreditLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        SumCreditLabel.Size = New System.Drawing.Size(57, 18)
        SumCreditLabel.TabIndex = 12
        SumCreditLabel.Text = "Kreditas:"
        '
        'SumDebitLabel
        '
        SumDebitLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SumDebitLabel.AutoSize = True
        SumDebitLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumDebitLabel.Location = New System.Drawing.Point(3, 0)
        SumDebitLabel.Name = "SumDebitLabel"
        SumDebitLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        SumDebitLabel.Size = New System.Drawing.Size(58, 18)
        SumDebitLabel.TabIndex = 14
        SumDebitLabel.Text = "Debetas:"
        '
        'Label1
        '
        Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(432, 0)
        Label1.Name = "Label1"
        Label1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Label1.Size = New System.Drawing.Size(88, 18)
        Label1.TabIndex = 18
        Label1.Text = "Balansavimas:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(ContentLabel, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(815, 55)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.ContentTextBox, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(58, 27)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(757, 28)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'ContentTextBox
        '
        Me.ContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OffsetBindingSource, "Content", True))
        Me.ContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentTextBox.Location = New System.Drawing.Point(3, 3)
        Me.ContentTextBox.MaxLength = 255
        Me.ContentTextBox.Name = "ContentTextBox"
        Me.ContentTextBox.Size = New System.Drawing.Size(731, 20)
        Me.ContentTextBox.TabIndex = 0
        '
        'OffsetBindingSource
        '
        Me.OffsetBindingSource.DataSource = GetType(ApskaitaObjects.Documents.Offset)
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoScroll = True
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ViewJournalEntryButton, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.IDTextBox, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(DateLabel, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DocumentNumberTextBox, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(DocumentNumberLabel, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DateAccDatePicker, 4, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(58, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(757, 27)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(188, 0)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 90
        Me.ViewJournalEntryButton.TabStop = False
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = True
        '
        'IDTextBox
        '
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OffsetBindingSource, "ID", True))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Location = New System.Drawing.Point(3, 3)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(162, 20)
        Me.IDTextBox.TabIndex = 11
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DocumentNumberTextBox
        '
        Me.DocumentNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OffsetBindingSource, "DocumentNumber", True))
        Me.DocumentNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentNumberTextBox.Location = New System.Drawing.Point(540, 3)
        Me.DocumentNumberTextBox.MaxLength = 50
        Me.DocumentNumberTextBox.Name = "DocumentNumberTextBox"
        Me.DocumentNumberTextBox.Size = New System.Drawing.Size(190, 20)
        Me.DocumentNumberTextBox.TabIndex = 1
        Me.DocumentNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 10
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.SumDebitAccTextBox, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(SumCreditLabel, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(SumDebitLabel, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.SumCreditAccTextBox, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Label1, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BalanceSumAccTextBox, 7, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.BalanceAccountAccGridComboBox, 8, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.GetCurrencyRatesButton, 8, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.BalanceButton, 6, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 55)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(815, 54)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'SumDebitAccTextBox
        '
        Me.SumDebitAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.OffsetBindingSource, "SumDebit", True))
        Me.SumDebitAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumDebitAccTextBox.Location = New System.Drawing.Point(67, 3)
        Me.SumDebitAccTextBox.Name = "SumDebitAccTextBox"
        Me.SumDebitAccTextBox.ReadOnly = True
        Me.SumDebitAccTextBox.Size = New System.Drawing.Size(130, 20)
        Me.SumDebitAccTextBox.TabIndex = 16
        Me.SumDebitAccTextBox.TabStop = False
        Me.SumDebitAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumCreditAccTextBox
        '
        Me.SumCreditAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.OffsetBindingSource, "SumCredit", True))
        Me.SumCreditAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumCreditAccTextBox.Location = New System.Drawing.Point(281, 3)
        Me.SumCreditAccTextBox.Name = "SumCreditAccTextBox"
        Me.SumCreditAccTextBox.ReadOnly = True
        Me.SumCreditAccTextBox.Size = New System.Drawing.Size(130, 20)
        Me.SumCreditAccTextBox.TabIndex = 15
        Me.SumCreditAccTextBox.TabStop = False
        Me.SumCreditAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BalanceSumAccTextBox
        '
        Me.BalanceSumAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.OffsetBindingSource, "BalanceSum", True))
        Me.BalanceSumAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BalanceSumAccTextBox.Location = New System.Drawing.Point(526, 3)
        Me.BalanceSumAccTextBox.Name = "BalanceSumAccTextBox"
        Me.BalanceSumAccTextBox.Size = New System.Drawing.Size(130, 20)
        Me.BalanceSumAccTextBox.TabIndex = 0
        Me.BalanceSumAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BalanceAccountAccGridComboBox
        '
        Me.BalanceAccountAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.OffsetBindingSource, "BalanceAccount", True))
        Me.BalanceAccountAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BalanceAccountAccGridComboBox.EmptyValueString = ""
        Me.BalanceAccountAccGridComboBox.InstantBinding = True
        Me.BalanceAccountAccGridComboBox.Location = New System.Drawing.Point(662, 3)
        Me.BalanceAccountAccGridComboBox.Name = "BalanceAccountAccGridComboBox"
        Me.BalanceAccountAccGridComboBox.Size = New System.Drawing.Size(130, 21)
        Me.BalanceAccountAccGridComboBox.TabIndex = 1
        '
        'GetCurrencyRatesButton
        '
        Me.GetCurrencyRatesButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GetCurrencyRatesButton.AutoSize = True
        Me.GetCurrencyRatesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GetCurrencyRatesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetCurrencyRatesButton.Location = New System.Drawing.Point(750, 30)
        Me.GetCurrencyRatesButton.Name = "GetCurrencyRatesButton"
        Me.GetCurrencyRatesButton.Size = New System.Drawing.Size(42, 21)
        Me.GetCurrencyRatesButton.TabIndex = 3
        Me.GetCurrencyRatesButton.Text = "$->€"
        Me.GetCurrencyRatesButton.UseVisualStyleBackColor = True
        '
        'BalanceButton
        '
        Me.BalanceButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BalanceButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BalanceButton.Location = New System.Drawing.Point(432, 30)
        Me.BalanceButton.Name = "BalanceButton"
        Me.BalanceButton.Size = New System.Drawing.Size(88, 21)
        Me.BalanceButton.TabIndex = 2
        Me.BalanceButton.Text = "Balansuoti"
        Me.BalanceButton.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 439)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(815, 32)
        Me.Panel2.TabIndex = 3
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(714, 6)
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
        Me.IOkButton.Location = New System.Drawing.Point(508, 6)
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
        Me.IApplyButton.Location = New System.Drawing.Point(612, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 2
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'ItemListSortedBindingSource
        '
        Me.ItemListSortedBindingSource.DataMember = "ItemList"
        Me.ItemListSortedBindingSource.DataSource = Me.OffsetBindingSource
        '
        'ItemListDataListView
        '
        Me.ItemListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.ItemListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.ItemListDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.ItemListDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.ItemListDataListView.AllColumns.Add(Me.OlvColumn5)
        Me.ItemListDataListView.AllColumns.Add(Me.OlvColumn6)
        Me.ItemListDataListView.AllColumns.Add(Me.OlvColumn7)
        Me.ItemListDataListView.AllColumns.Add(Me.OlvColumn8)
        Me.ItemListDataListView.AllColumns.Add(Me.OlvColumn9)
        Me.ItemListDataListView.AllColumns.Add(Me.OlvColumn10)
        Me.ItemListDataListView.AllColumns.Add(Me.OlvColumn11)
        Me.ItemListDataListView.AllColumns.Add(Me.OlvColumn12)
        Me.ItemListDataListView.AllColumns.Add(Me.OlvColumn13)
        Me.ItemListDataListView.AllowColumnReorder = True
        Me.ItemListDataListView.AutoGenerateColumns = False
        Me.ItemListDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.ItemListDataListView.CellEditEnterChangesRows = True
        Me.ItemListDataListView.CellEditTabChangesRows = True
        Me.ItemListDataListView.CellEditUseWholeCell = False
        Me.ItemListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn5, Me.OlvColumn6, Me.OlvColumn7, Me.OlvColumn8, Me.OlvColumn9, Me.OlvColumn10})
        Me.ItemListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.ItemListDataListView.DataSource = Me.ItemListSortedBindingSource
        Me.ItemListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemListDataListView.FullRowSelect = True
        Me.ItemListDataListView.HasCollapsibleGroups = False
        Me.ItemListDataListView.HeaderWordWrap = True
        Me.ItemListDataListView.HideSelection = False
        Me.ItemListDataListView.IncludeColumnHeadersInCopy = True
        Me.ItemListDataListView.Location = New System.Drawing.Point(0, 109)
        Me.ItemListDataListView.Name = "ItemListDataListView"
        Me.ItemListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.ItemListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.ItemListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.ItemListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.ItemListDataListView.ShowCommandMenuOnRightClick = True
        Me.ItemListDataListView.ShowGroups = False
        Me.ItemListDataListView.ShowImagesOnSubItems = True
        Me.ItemListDataListView.ShowItemCountOnGroups = True
        Me.ItemListDataListView.ShowItemToolTips = True
        Me.ItemListDataListView.Size = New System.Drawing.Size(815, 330)
        Me.ItemListDataListView.TabIndex = 4
        Me.ItemListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.ItemListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.ItemListDataListView.UseCellFormatEvents = True
        Me.ItemListDataListView.UseCompatibleStateImageBehavior = False
        Me.ItemListDataListView.UseFilterIndicator = True
        Me.ItemListDataListView.UseFiltering = True
        Me.ItemListDataListView.UseHotItem = True
        Me.ItemListDataListView.UseNotifyPropertyChanged = True
        Me.ItemListDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "TypeHumanReadable"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.Text = "Tipas"
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 82
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
        Me.OlvColumn3.AspectName = "Person"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.Text = "Kontrahentas"
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 182
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "Account"
        Me.OlvColumn4.CellEditUseWholeCell = True
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.Text = "Koresp. sąsk."
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 85
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "Sum"
        Me.OlvColumn5.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn5.CellEditUseWholeCell = True
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.Text = "Suma"
        Me.OlvColumn5.ToolTipText = ""
        Me.OlvColumn5.Width = 79
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "CurrencyCode"
        Me.OlvColumn6.CellEditUseWholeCell = True
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.Text = "Valiuta"
        Me.OlvColumn6.ToolTipText = ""
        Me.OlvColumn6.Width = 48
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "CurrencyRate"
        Me.OlvColumn7.AspectToStringFormat = "{0:##,0.000000}"
        Me.OlvColumn7.CellEditUseWholeCell = True
        Me.OlvColumn7.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.Text = "Kursas"
        Me.OlvColumn7.ToolTipText = ""
        Me.OlvColumn7.Width = 72
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "SumLTL"
        Me.OlvColumn8.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn8.CellEditUseWholeCell = True
        Me.OlvColumn8.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.IsEditable = False
        Me.OlvColumn8.Text = "Suma LTL"
        Me.OlvColumn8.ToolTipText = ""
        Me.OlvColumn8.Width = 78
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "CurrencyRateChangeImpact"
        Me.OlvColumn9.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn9.CellEditUseWholeCell = True
        Me.OlvColumn9.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.Text = "Val. kurso pasik. įtaka"
        Me.OlvColumn9.ToolTipText = ""
        Me.OlvColumn9.Width = 82
        '
        'OlvColumn10
        '
        Me.OlvColumn10.AspectName = "AccountCurrencyRateChangeImpact"
        Me.OlvColumn10.CellEditUseWholeCell = True
        Me.OlvColumn10.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn10.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn10.Text = "Val. kurso pasik. įtakos sąsk."
        Me.OlvColumn10.ToolTipText = ""
        Me.OlvColumn10.Width = 98
        '
        'OlvColumn11
        '
        Me.OlvColumn11.AspectName = "Comments"
        Me.OlvColumn11.CellEditUseWholeCell = True
        Me.OlvColumn11.DisplayIndex = 10
        Me.OlvColumn11.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn11.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn11.IsVisible = False
        Me.OlvColumn11.Text = "Komentarai"
        Me.OlvColumn11.ToolTipText = ""
        Me.OlvColumn11.Width = 100
        '
        'OlvColumn12
        '
        Me.OlvColumn12.AspectName = "Debit"
        Me.OlvColumn12.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn12.CellEditUseWholeCell = True
        Me.OlvColumn12.DisplayIndex = 11
        Me.OlvColumn12.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn12.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn12.IsEditable = False
        Me.OlvColumn12.IsVisible = False
        Me.OlvColumn12.Text = "Debetas"
        Me.OlvColumn12.ToolTipText = ""
        Me.OlvColumn12.Width = 100
        '
        'OlvColumn13
        '
        Me.OlvColumn13.AspectName = "Credit"
        Me.OlvColumn13.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn13.CellEditUseWholeCell = True
        Me.OlvColumn13.DisplayIndex = 12
        Me.OlvColumn13.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn13.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn13.IsEditable = False
        Me.OlvColumn13.IsVisible = False
        Me.OlvColumn13.Text = "Kreditas"
        Me.OlvColumn13.ToolTipText = ""
        Me.OlvColumn13.Width = 100
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(146, 122)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(123, 62)
        Me.ProgressFiller1.TabIndex = 5
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(286, 119)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(187, 74)
        Me.ProgressFiller2.TabIndex = 6
        Me.ProgressFiller2.Visible = False
        '
        'ErrorWarnInfoProvider1
        '
        Me.ErrorWarnInfoProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleInformation = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleWarning = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.ContainerControl = Me
        Me.ErrorWarnInfoProvider1.DataSource = Me.OffsetBindingSource
        '
        'DateAccDatePicker
        '
        Me.DateAccDatePicker.BoldedDates = Nothing
        Me.DateAccDatePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.OffsetBindingSource, "Date", True))
        Me.DateAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateAccDatePicker.Location = New System.Drawing.Point(259, 3)
        Me.DateAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateAccDatePicker.Name = "DateAccDatePicker"
        Me.DateAccDatePicker.ReadOnly = False
        Me.DateAccDatePicker.ShowWeekNumbers = True
        Me.DateAccDatePicker.Size = New System.Drawing.Size(190, 21)
        Me.DateAccDatePicker.TabIndex = 0
        '
        'F_Offset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 471)
        Me.Controls.Add(Me.ItemListDataListView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_Offset"
        Me.ShowInTaskbar = False
        Me.Text = "Užskaitos dokumentas"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        CType(Me.OffsetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ItemListSortedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OffsetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DocumentNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents SumDebitAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents SumCreditAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents ItemListSortedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GetCurrencyRatesButton As System.Windows.Forms.Button
    Friend WithEvents BalanceSumAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents BalanceAccountAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents BalanceButton As System.Windows.Forms.Button
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
    Friend WithEvents ItemListDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn5 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn6 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn7 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn8 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn9 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn10 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn11 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn12 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn13 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ErrorWarnInfoProvider1 As AccControlsWinForms.ErrorWarnInfoProvider
    Friend WithEvents DateAccDatePicker As AccControlsWinForms.AccDatePicker
End Class
