<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Offset
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_Offset))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.ContentTextBox = New System.Windows.Forms.TextBox
        Me.OffsetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.DocumentNumberTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.SumDebitAccTextBox = New AccControls.AccTextBox
        Me.SumCreditAccTextBox = New AccControls.AccTextBox
        Me.BalanceSumAccTextBox = New AccControls.AccTextBox
        Me.BalanceAccountAccGridComboBox = New AccControls.AccGridComboBox
        Me.GetCurrencyRatesButton = New System.Windows.Forms.Button
        Me.BalanceButton = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LimitationsButton = New System.Windows.Forms.Button
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.ItemListSortedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemListDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn4 = New AccControls.DataGridViewAccGridComboBoxColumn
        Me.DataGridViewTextBoxColumn5 = New AccControls.DataGridViewAccGridComboBoxColumn
        Me.DataGridViewTextBoxColumn6 = New AccControls.DataGridViewAccTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn8 = New AccControls.DataGridViewAccTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New AccControls.DataGridViewAccTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New AccControls.DataGridViewAccGridComboBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
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
        CType(Me.ItemListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        DateLabel.Location = New System.Drawing.Point(203, 0)
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
        DocumentNumberLabel.Location = New System.Drawing.Point(449, 0)
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
        SumCreditLabel.Location = New System.Drawing.Point(207, 0)
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
        Label1.Location = New System.Drawing.Point(410, 0)
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(772, 55)
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
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(714, 28)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'ContentTextBox
        '
        Me.ContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OffsetBindingSource, "Content", True))
        Me.ContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentTextBox.Location = New System.Drawing.Point(3, 3)
        Me.ContentTextBox.MaxLength = 255
        Me.ContentTextBox.Name = "ContentTextBox"
        Me.ContentTextBox.Size = New System.Drawing.Size(688, 20)
        Me.ContentTextBox.TabIndex = 0
        '
        'OffsetBindingSource
        '
        Me.OffsetBindingSource.DataSource = GetType(ApskaitaObjects.Documents.Offset)
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ViewJournalEntryButton, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.IDTextBox, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(DateLabel, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DateDateTimePicker, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DocumentNumberTextBox, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(DocumentNumberLabel, 6, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(58, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(714, 27)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.ApskaitaWUI.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(176, 0)
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
        Me.IDTextBox.Size = New System.Drawing.Size(150, 20)
        Me.IDTextBox.TabIndex = 11
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.OffsetBindingSource, "Date", True))
        Me.DateDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateDateTimePicker.Location = New System.Drawing.Point(247, 3)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(176, 20)
        Me.DateDateTimePicker.TabIndex = 0
        '
        'DocumentNumberTextBox
        '
        Me.DocumentNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OffsetBindingSource, "DocumentNumber", True))
        Me.DocumentNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentNumberTextBox.Location = New System.Drawing.Point(514, 3)
        Me.DocumentNumberTextBox.MaxLength = 50
        Me.DocumentNumberTextBox.Name = "DocumentNumberTextBox"
        Me.DocumentNumberTextBox.Size = New System.Drawing.Size(176, 20)
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
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
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
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(772, 54)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'SumDebitAccTextBox
        '
        Me.SumDebitAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.OffsetBindingSource, "SumDebit", True))
        Me.SumDebitAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumDebitAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumDebitAccTextBox.Location = New System.Drawing.Point(67, 3)
        Me.SumDebitAccTextBox.Name = "SumDebitAccTextBox"
        Me.SumDebitAccTextBox.ReadOnly = True
        Me.SumDebitAccTextBox.Size = New System.Drawing.Size(119, 20)
        Me.SumDebitAccTextBox.TabIndex = 16
        Me.SumDebitAccTextBox.TabStop = False
        Me.SumDebitAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumCreditAccTextBox
        '
        Me.SumCreditAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.OffsetBindingSource, "SumCredit", True))
        Me.SumCreditAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumCreditAccTextBox.KeepBackColorWhenReadOnly = False
        Me.SumCreditAccTextBox.Location = New System.Drawing.Point(270, 3)
        Me.SumCreditAccTextBox.Name = "SumCreditAccTextBox"
        Me.SumCreditAccTextBox.ReadOnly = True
        Me.SumCreditAccTextBox.Size = New System.Drawing.Size(119, 20)
        Me.SumCreditAccTextBox.TabIndex = 15
        Me.SumCreditAccTextBox.TabStop = False
        Me.SumCreditAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BalanceSumAccTextBox
        '
        Me.BalanceSumAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.OffsetBindingSource, "BalanceSum", True))
        Me.BalanceSumAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BalanceSumAccTextBox.KeepBackColorWhenReadOnly = False
        Me.BalanceSumAccTextBox.Location = New System.Drawing.Point(504, 3)
        Me.BalanceSumAccTextBox.Name = "BalanceSumAccTextBox"
        Me.BalanceSumAccTextBox.Size = New System.Drawing.Size(119, 20)
        Me.BalanceSumAccTextBox.TabIndex = 0
        Me.BalanceSumAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BalanceAccountAccGridComboBox
        '
        Me.BalanceAccountAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.OffsetBindingSource, "BalanceAccount", True))
        Me.BalanceAccountAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BalanceAccountAccGridComboBox.EmptyValueString = ""
        Me.BalanceAccountAccGridComboBox.FilterPropertyName = ""
        Me.BalanceAccountAccGridComboBox.FormattingEnabled = True
        Me.BalanceAccountAccGridComboBox.InstantBinding = True
        Me.BalanceAccountAccGridComboBox.Location = New System.Drawing.Point(629, 3)
        Me.BalanceAccountAccGridComboBox.Name = "BalanceAccountAccGridComboBox"
        Me.BalanceAccountAccGridComboBox.Size = New System.Drawing.Size(119, 21)
        Me.BalanceAccountAccGridComboBox.TabIndex = 1
        '
        'GetCurrencyRatesButton
        '
        Me.GetCurrencyRatesButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GetCurrencyRatesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetCurrencyRatesButton.Location = New System.Drawing.Point(685, 30)
        Me.GetCurrencyRatesButton.Name = "GetCurrencyRatesButton"
        Me.GetCurrencyRatesButton.Size = New System.Drawing.Size(63, 21)
        Me.GetCurrencyRatesButton.TabIndex = 3
        Me.GetCurrencyRatesButton.Text = "$->LTL"
        Me.GetCurrencyRatesButton.UseVisualStyleBackColor = True
        '
        'BalanceButton
        '
        Me.BalanceButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BalanceButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BalanceButton.Location = New System.Drawing.Point(410, 30)
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
        Me.Panel2.Controls.Add(Me.LimitationsButton)
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 439)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(772, 32)
        Me.Panel2.TabIndex = 3
        '
        'LimitationsButton
        '
        Me.LimitationsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LimitationsButton.Image = Global.ApskaitaWUI.My.Resources.Resources.Action_lock_icon_24p
        Me.LimitationsButton.Location = New System.Drawing.Point(12, 5)
        Me.LimitationsButton.Name = "LimitationsButton"
        Me.LimitationsButton.Size = New System.Drawing.Size(32, 24)
        Me.LimitationsButton.TabIndex = 0
        Me.LimitationsButton.UseVisualStyleBackColor = True
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(671, 6)
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
        Me.IOkButton.Location = New System.Drawing.Point(465, 6)
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
        Me.IApplyButton.Location = New System.Drawing.Point(569, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 2
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'ItemListSortedBindingSource
        '
        Me.ItemListSortedBindingSource.DataMember = "ItemListSorted"
        Me.ItemListSortedBindingSource.DataSource = Me.OffsetBindingSource
        '
        'ItemListDataGridView
        '
        Me.ItemListDataGridView.AllowUserToOrderColumns = True
        Me.ItemListDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ItemListDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ItemListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ItemListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14})
        Me.ItemListDataGridView.DataSource = Me.ItemListSortedBindingSource
        Me.ItemListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemListDataGridView.Location = New System.Drawing.Point(0, 109)
        Me.ItemListDataGridView.Name = "ItemListDataGridView"
        Me.ItemListDataGridView.RowHeadersWidth = 20
        Me.ItemListDataGridView.Size = New System.Drawing.Size(772, 330)
        Me.ItemListDataGridView.TabIndex = 2
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "TypeHumanReadable"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Tipas"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.CloseOnSingleClick = True
        Me.DataGridViewTextBoxColumn4.ComboDataGridView = Nothing
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Person"
        Me.DataGridViewTextBoxColumn4.EmptyValueString = ""
        Me.DataGridViewTextBoxColumn4.FilterPropertyName = ""
        Me.DataGridViewTextBoxColumn4.HeaderText = "Kontrahentas"
        Me.DataGridViewTextBoxColumn4.InstantBinding = True
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.ValueMember = ""
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.CloseOnSingleClick = True
        Me.DataGridViewTextBoxColumn5.ComboDataGridView = Nothing
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Account"
        Me.DataGridViewTextBoxColumn5.EmptyValueString = ""
        Me.DataGridViewTextBoxColumn5.FilterPropertyName = ""
        Me.DataGridViewTextBoxColumn5.HeaderText = "Koresp. sąsk."
        Me.DataGridViewTextBoxColumn5.InstantBinding = True
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.ValueMember = ""
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AllowNegative = False
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Sum"
        DataGridViewCellStyle2.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn6.HeaderText = "Suma"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "CurrencyCode"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Valiuta"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AllowNegative = False
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "CurrencyRate"
        Me.DataGridViewTextBoxColumn8.DecimalLength = 6
        DataGridViewCellStyle3.Format = "##,0.000000"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn8.HeaderText = "Kursas"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "SumLTL"
        DataGridViewCellStyle4.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn9.HeaderText = "Suma LTL"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "CurrencyRateChangeImpact"
        DataGridViewCellStyle5.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn10.HeaderText = "Val. kurso pasik. įtaka"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.CloseOnSingleClick = True
        Me.DataGridViewTextBoxColumn11.ComboDataGridView = Nothing
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "AccountCurrencyRateChangeImpact"
        Me.DataGridViewTextBoxColumn11.EmptyValueString = ""
        Me.DataGridViewTextBoxColumn11.FilterPropertyName = ""
        Me.DataGridViewTextBoxColumn11.HeaderText = "Val. kurso pasik. įtakos sąsk."
        Me.DataGridViewTextBoxColumn11.InstantBinding = True
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn11.ValueMember = ""
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Comments"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Komentarai"
        Me.DataGridViewTextBoxColumn12.MaxInputLength = 255
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Debit"
        DataGridViewCellStyle6.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn13.HeaderText = "Debetas"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Credit"
        DataGridViewCellStyle7.Format = "##,0.00"
        Me.DataGridViewTextBoxColumn14.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn14.HeaderText = "Kreditas"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.OffsetBindingSource
        '
        'F_Offset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 471)
        Me.Controls.Add(Me.ItemListDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.TableLayoutPanel1)
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
        CType(Me.ItemListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OffsetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents DocumentNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents SumDebitAccTextBox As AccControls.AccTextBox
    Friend WithEvents SumCreditAccTextBox As AccControls.AccTextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents ItemListSortedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents GetCurrencyRatesButton As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As AccControls.DataGridViewAccGridComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As AccControls.DataGridViewAccGridComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As AccControls.DataGridViewAccTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As AccControls.DataGridViewAccGridComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents BalanceSumAccTextBox As AccControls.AccTextBox
    Friend WithEvents BalanceAccountAccGridComboBox As AccControls.AccGridComboBox
    Friend WithEvents BalanceButton As System.Windows.Forms.Button
    Friend WithEvents LimitationsButton As System.Windows.Forms.Button
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
End Class
