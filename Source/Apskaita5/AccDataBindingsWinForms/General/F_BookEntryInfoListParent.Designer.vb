﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_BookEntryInfoListParent
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
        Dim CreditBalanceEndLabel As System.Windows.Forms.Label
        Dim CreditBalanceStartLabel As System.Windows.Forms.Label
        Dim CreditTurnoverLabel As System.Windows.Forms.Label
        Dim DebetBalanceEndLabel As System.Windows.Forms.Label
        Dim DebetBalanceStartLabel As System.Windows.Forms.Label
        Dim DebetTurnoverLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_BookEntryInfoListParent))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.PersonAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.PersonGroupComboBox = New AccControlsWinForms.AccListComboBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.AccountAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.IncludeSubAccountsCheckBox = New System.Windows.Forms.CheckBox
        Me.DateFromAccDatePicker = New AccControlsWinForms.AccDatePicker
        Me.DateToAccDatePicker = New AccControlsWinForms.AccDatePicker
        Me.ClearButton = New System.Windows.Forms.Button
        Me.RefreshButton = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.ItemsDataListView = New BrightIdeasSoftware.DataListView
        Me.OlvColumn2 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn1 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn3 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn4 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn5 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn6 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn7 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn8 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn9 = New BrightIdeasSoftware.OLVColumn
        Me.ItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BookEntryInfoListParentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.CreditBalanceEndAccBox = New AccControlsWinForms.AccTextBox
        Me.CreditTurnoverAccBox = New AccControlsWinForms.AccTextBox
        Me.DebetBalanceEndAccBox = New AccControlsWinForms.AccTextBox
        Me.DebetTurnoverAccBox = New AccControlsWinForms.AccTextBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.CreditBalanceStartAccBox = New AccControlsWinForms.AccTextBox
        Me.DebetBalanceStartAccBox = New AccControlsWinForms.AccTextBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyJournalEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.CorrespondationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RelationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CreditBalanceEndLabel = New System.Windows.Forms.Label
        CreditBalanceStartLabel = New System.Windows.Forms.Label
        CreditTurnoverLabel = New System.Windows.Forms.Label
        DebetBalanceEndLabel = New System.Windows.Forms.Label
        DebetBalanceStartLabel = New System.Windows.Forms.Label
        DebetTurnoverLabel = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.ItemsDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BookEntryInfoListParentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CreditBalanceEndLabel
        '
        CreditBalanceEndLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CreditBalanceEndLabel.AutoSize = True
        CreditBalanceEndLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CreditBalanceEndLabel.Location = New System.Drawing.Point(321, 32)
        CreditBalanceEndLabel.Name = "CreditBalanceEndLabel"
        CreditBalanceEndLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        CreditBalanceEndLabel.Size = New System.Drawing.Size(147, 18)
        CreditBalanceEndLabel.TabIndex = 2
        CreditBalanceEndLabel.Text = "Kredito likutis pabaigoje:"
        '
        'CreditBalanceStartLabel
        '
        CreditBalanceStartLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CreditBalanceStartLabel.AutoSize = True
        CreditBalanceStartLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CreditBalanceStartLabel.Location = New System.Drawing.Point(323, 3)
        CreditBalanceStartLabel.Name = "CreditBalanceStartLabel"
        CreditBalanceStartLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        CreditBalanceStartLabel.Size = New System.Drawing.Size(143, 18)
        CreditBalanceStartLabel.TabIndex = 4
        CreditBalanceStartLabel.Text = "Kredito likutis pradžioje:"
        '
        'CreditTurnoverLabel
        '
        CreditTurnoverLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CreditTurnoverLabel.AutoSize = True
        CreditTurnoverLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CreditTurnoverLabel.Location = New System.Drawing.Point(364, 3)
        CreditTurnoverLabel.Name = "CreditTurnoverLabel"
        CreditTurnoverLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        CreditTurnoverLabel.Size = New System.Drawing.Size(104, 18)
        CreditTurnoverLabel.TabIndex = 6
        CreditTurnoverLabel.Text = "Kredito apyvarta:"
        '
        'DebetBalanceEndLabel
        '
        DebetBalanceEndLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DebetBalanceEndLabel.AutoSize = True
        DebetBalanceEndLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DebetBalanceEndLabel.Location = New System.Drawing.Point(6, 32)
        DebetBalanceEndLabel.Name = "DebetBalanceEndLabel"
        DebetBalanceEndLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        DebetBalanceEndLabel.Size = New System.Drawing.Size(148, 18)
        DebetBalanceEndLabel.TabIndex = 12
        DebetBalanceEndLabel.Text = "Debeto likutis pabaigoje:"
        '
        'DebetBalanceStartLabel
        '
        DebetBalanceStartLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DebetBalanceStartLabel.AutoSize = True
        DebetBalanceStartLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DebetBalanceStartLabel.Location = New System.Drawing.Point(6, 3)
        DebetBalanceStartLabel.Name = "DebetBalanceStartLabel"
        DebetBalanceStartLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        DebetBalanceStartLabel.Size = New System.Drawing.Size(144, 18)
        DebetBalanceStartLabel.TabIndex = 14
        DebetBalanceStartLabel.Text = "Debeto likutis pradžioje:"
        '
        'DebetTurnoverLabel
        '
        DebetTurnoverLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DebetTurnoverLabel.AutoSize = True
        DebetTurnoverLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DebetTurnoverLabel.Location = New System.Drawing.Point(49, 3)
        DebetTurnoverLabel.Name = "DebetTurnoverLabel"
        DebetTurnoverLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        DebetTurnoverLabel.Size = New System.Drawing.Size(105, 18)
        DebetTurnoverLabel.TabIndex = 16
        DebetTurnoverLabel.Text = "Debeto apyvarta:"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.ClearButton)
        Me.Panel1.Controls.Add(Me.RefreshButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(771, 178)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(747, 130)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro kriterijai"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.PersonAccGridComboBox, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.PersonGroupComboBox, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 70)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(741, 57)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'PersonAccGridComboBox
        '
        Me.PersonAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonAccGridComboBox.EmptyValueString = ""
        Me.PersonAccGridComboBox.InstantBinding = True
        Me.PersonAccGridComboBox.Location = New System.Drawing.Point(108, 31)
        Me.PersonAccGridComboBox.Name = "PersonAccGridComboBox"
        Me.PersonAccGridComboBox.Size = New System.Drawing.Size(630, 21)
        Me.PersonAccGridComboBox.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(99, 29)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Asmuo:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label6.Size = New System.Drawing.Size(99, 28)
        Me.Label6.TabIndex = 56
        Me.Label6.Text = "Asm. grupė:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PersonGroupComboBox
        '
        Me.PersonGroupComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PersonGroupComboBox.EmptyValueString = ""
        Me.PersonGroupComboBox.InstantBinding = True
        Me.PersonGroupComboBox.Location = New System.Drawing.Point(108, 3)
        Me.PersonGroupComboBox.Name = "PersonGroupComboBox"
        Me.PersonGroupComboBox.Size = New System.Drawing.Size(630, 21)
        Me.PersonGroupComboBox.TabIndex = 57
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.AccountAccGridComboBox, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.IncludeSubAccountsCheckBox, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DateFromAccDatePicker, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DateToAccDatePicker, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(741, 54)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(99, 27)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Data nuo:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AccountAccGridComboBox
        '
        Me.AccountAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountAccGridComboBox.EmptyValueString = ""
        Me.AccountAccGridComboBox.InstantBinding = True
        Me.AccountAccGridComboBox.Location = New System.Drawing.Point(551, 3)
        Me.AccountAccGridComboBox.Name = "AccountAccGridComboBox"
        Me.AccountAccGridComboBox.Size = New System.Drawing.Size(187, 21)
        Me.AccountAccGridComboBox.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(251, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label13.Size = New System.Drawing.Size(72, 27)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "Data iki:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(472, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(73, 27)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Sąskaita:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'IncludeSubAccountsCheckBox
        '
        Me.IncludeSubAccountsCheckBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IncludeSubAccountsCheckBox.AutoSize = True
        Me.IncludeSubAccountsCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IncludeSubAccountsCheckBox.Location = New System.Drawing.Point(551, 30)
        Me.IncludeSubAccountsCheckBox.Name = "IncludeSubAccountsCheckBox"
        Me.IncludeSubAccountsCheckBox.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.IncludeSubAccountsCheckBox.Size = New System.Drawing.Size(187, 20)
        Me.IncludeSubAccountsCheckBox.TabIndex = 3
        Me.IncludeSubAccountsCheckBox.Text = "Įtraukti subsąskaitas"
        Me.IncludeSubAccountsCheckBox.UseVisualStyleBackColor = True
        '
        'DateFromAccDatePicker
        '
        Me.DateFromAccDatePicker.BoldedDates = Nothing
        Me.DateFromAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateFromAccDatePicker.Location = New System.Drawing.Point(108, 3)
        Me.DateFromAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateFromAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateFromAccDatePicker.Name = "DateFromAccDatePicker"
        Me.DateFromAccDatePicker.ReadOnly = False
        Me.DateFromAccDatePicker.ShowWeekNumbers = True
        Me.DateFromAccDatePicker.Size = New System.Drawing.Size(137, 21)
        Me.DateFromAccDatePicker.TabIndex = 0
        '
        'DateToAccDatePicker
        '
        Me.DateToAccDatePicker.BoldedDates = Nothing
        Me.DateToAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateToAccDatePicker.Location = New System.Drawing.Point(329, 3)
        Me.DateToAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateToAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateToAccDatePicker.Name = "DateToAccDatePicker"
        Me.DateToAccDatePicker.ReadOnly = False
        Me.DateToAccDatePicker.ShowWeekNumbers = True
        Me.DateToAccDatePicker.Size = New System.Drawing.Size(137, 21)
        Me.DateToAccDatePicker.TabIndex = 1
        '
        'ClearButton
        '
        Me.ClearButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClearButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearButton.Location = New System.Drawing.Point(624, 145)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(68, 26)
        Me.ClearButton.TabIndex = 1
        Me.ClearButton.Text = "Išvalyti"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'RefreshButton
        '
        Me.RefreshButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RefreshButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Button_Reload_icon_24p
        Me.RefreshButton.Location = New System.Drawing.Point(717, 142)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(33, 33)
        Me.RefreshButton.TabIndex = 2
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ItemsDataListView)
        Me.Panel3.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel3.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.ProgressFiller1)
        Me.Panel3.Controls.Add(Me.ProgressFiller2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 178)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(771, 388)
        Me.Panel3.TabIndex = 1
        '
        'ItemsDataListView
        '
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn5)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn6)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn7)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn8)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn9)
        Me.ItemsDataListView.AllowColumnReorder = True
        Me.ItemsDataListView.AutoGenerateColumns = False
        Me.ItemsDataListView.CausesValidation = False
        Me.ItemsDataListView.CellEditUseWholeCell = False
        Me.ItemsDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn5, Me.OlvColumn6, Me.OlvColumn7, Me.OlvColumn8, Me.OlvColumn9})
        Me.ItemsDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.ItemsDataListView.DataSource = Me.ItemsBindingSource
        Me.ItemsDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemsDataListView.FullRowSelect = True
        Me.ItemsDataListView.HasCollapsibleGroups = False
        Me.ItemsDataListView.HeaderWordWrap = True
        Me.ItemsDataListView.HideSelection = False
        Me.ItemsDataListView.IncludeColumnHeadersInCopy = True
        Me.ItemsDataListView.Location = New System.Drawing.Point(0, 30)
        Me.ItemsDataListView.Name = "ItemsDataListView"
        Me.ItemsDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.ItemsDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.ItemsDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.ItemsDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.ItemsDataListView.ShowCommandMenuOnRightClick = True
        Me.ItemsDataListView.ShowGroups = False
        Me.ItemsDataListView.ShowImagesOnSubItems = True
        Me.ItemsDataListView.ShowItemCountOnGroups = True
        Me.ItemsDataListView.ShowItemToolTips = True
        Me.ItemsDataListView.Size = New System.Drawing.Size(771, 292)
        Me.ItemsDataListView.TabIndex = 4
        Me.ItemsDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.ItemsDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.ItemsDataListView.UseCellFormatEvents = True
        Me.ItemsDataListView.UseCompatibleStateImageBehavior = False
        Me.ItemsDataListView.UseFilterIndicator = True
        Me.ItemsDataListView.UseFiltering = True
        Me.ItemsDataListView.UseHotItem = True
        Me.ItemsDataListView.UseNotifyPropertyChanged = True
        Me.ItemsDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "JournalEntryDate"
        Me.OlvColumn2.AspectToStringFormat = "{0:d}"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.IsEditable = False
        Me.OlvColumn2.Text = "Data"
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 77
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "JournalEntryID"
        Me.OlvColumn1.CellEditUseWholeCell = True
        Me.OlvColumn1.DisplayIndex = 1
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.IsEditable = False
        Me.OlvColumn1.IsVisible = False
        Me.OlvColumn1.Text = "BŽ ID"
        Me.OlvColumn1.ToolTipText = ""
        Me.OlvColumn1.Width = 65
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "DocTypeHumanReadable"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsEditable = False
        Me.OlvColumn3.Text = "Dok. tipas"
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 108
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "DocNumber"
        Me.OlvColumn4.CellEditUseWholeCell = True
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.IsEditable = False
        Me.OlvColumn4.Text = "Dok. Nr."
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 80
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "Content"
        Me.OlvColumn5.CellEditUseWholeCell = True
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.IsEditable = False
        Me.OlvColumn5.Text = "Operacijos turinys"
        Me.OlvColumn5.ToolTipText = ""
        Me.OlvColumn5.Width = 243
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "DebetTurnover"
        Me.OlvColumn6.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn6.CellEditUseWholeCell = True
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.IsEditable = False
        Me.OlvColumn6.Text = "Debetas"
        Me.OlvColumn6.ToolTipText = ""
        Me.OlvColumn6.Width = 106
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "CreditTurnover"
        Me.OlvColumn7.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn7.CellEditUseWholeCell = True
        Me.OlvColumn7.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.IsEditable = False
        Me.OlvColumn7.Text = "Kreditas"
        Me.OlvColumn7.ToolTipText = ""
        Me.OlvColumn7.Width = 105
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "Person"
        Me.OlvColumn8.CellEditUseWholeCell = True
        Me.OlvColumn8.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.IsEditable = False
        Me.OlvColumn8.Text = "Susietas asmuo"
        Me.OlvColumn8.ToolTipText = ""
        Me.OlvColumn8.Width = 120
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "BookEntriesString"
        Me.OlvColumn9.CellEditUseWholeCell = True
        Me.OlvColumn9.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.IsEditable = False
        Me.OlvColumn9.Text = "Korespondencijos"
        Me.OlvColumn9.ToolTipText = ""
        Me.OlvColumn9.Width = 10
        '
        'ItemsBindingSource
        '
        Me.ItemsBindingSource.DataMember = "Items"
        Me.ItemsBindingSource.DataSource = Me.BookEntryInfoListParentBindingSource
        '
        'BookEntryInfoListParentBindingSource
        '
        Me.BookEntryInfoListParentBindingSource.DataSource = GetType(ApskaitaObjects.ActiveReports.BookEntryInfoListParent)
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel4.ColumnCount = 5
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.CreditBalanceEndAccBox, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(CreditBalanceEndLabel, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.CreditTurnoverAccBox, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(DebetTurnoverLabel, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(DebetBalanceEndLabel, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(CreditTurnoverLabel, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.DebetBalanceEndAccBox, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.DebetTurnoverAccBox, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 322)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(771, 61)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'CreditBalanceEndAccBox
        '
        Me.CreditBalanceEndAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BookEntryInfoListParentBindingSource, "CreditBalanceEnd", True))
        Me.CreditBalanceEndAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CreditBalanceEndAccBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreditBalanceEndAccBox.Location = New System.Drawing.Point(477, 35)
        Me.CreditBalanceEndAccBox.Name = "CreditBalanceEndAccBox"
        Me.CreditBalanceEndAccBox.NegativeValue = False
        Me.CreditBalanceEndAccBox.ReadOnly = True
        Me.CreditBalanceEndAccBox.Size = New System.Drawing.Size(149, 20)
        Me.CreditBalanceEndAccBox.TabIndex = 3
        Me.CreditBalanceEndAccBox.TabStop = False
        Me.CreditBalanceEndAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CreditTurnoverAccBox
        '
        Me.CreditTurnoverAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BookEntryInfoListParentBindingSource, "CreditTurnover", True))
        Me.CreditTurnoverAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CreditTurnoverAccBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreditTurnoverAccBox.Location = New System.Drawing.Point(477, 6)
        Me.CreditTurnoverAccBox.Name = "CreditTurnoverAccBox"
        Me.CreditTurnoverAccBox.NegativeValue = False
        Me.CreditTurnoverAccBox.ReadOnly = True
        Me.CreditTurnoverAccBox.Size = New System.Drawing.Size(149, 20)
        Me.CreditTurnoverAccBox.TabIndex = 7
        Me.CreditTurnoverAccBox.TabStop = False
        Me.CreditTurnoverAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DebetBalanceEndAccBox
        '
        Me.DebetBalanceEndAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BookEntryInfoListParentBindingSource, "DebetBalanceEnd", True))
        Me.DebetBalanceEndAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DebetBalanceEndAccBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebetBalanceEndAccBox.Location = New System.Drawing.Point(163, 35)
        Me.DebetBalanceEndAccBox.Name = "DebetBalanceEndAccBox"
        Me.DebetBalanceEndAccBox.NegativeValue = False
        Me.DebetBalanceEndAccBox.ReadOnly = True
        Me.DebetBalanceEndAccBox.Size = New System.Drawing.Size(149, 20)
        Me.DebetBalanceEndAccBox.TabIndex = 13
        Me.DebetBalanceEndAccBox.TabStop = False
        Me.DebetBalanceEndAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DebetTurnoverAccBox
        '
        Me.DebetTurnoverAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BookEntryInfoListParentBindingSource, "DebetTurnover", True))
        Me.DebetTurnoverAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DebetTurnoverAccBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebetTurnoverAccBox.Location = New System.Drawing.Point(163, 6)
        Me.DebetTurnoverAccBox.Name = "DebetTurnoverAccBox"
        Me.DebetTurnoverAccBox.NegativeValue = False
        Me.DebetTurnoverAccBox.ReadOnly = True
        Me.DebetTurnoverAccBox.Size = New System.Drawing.Size(149, 20)
        Me.DebetTurnoverAccBox.TabIndex = 17
        Me.DebetTurnoverAccBox.TabStop = False
        Me.DebetTurnoverAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.CreditBalanceStartAccBox, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(CreditBalanceStartLabel, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(DebetBalanceStartLabel, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.DebetBalanceStartAccBox, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(771, 30)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'CreditBalanceStartAccBox
        '
        Me.CreditBalanceStartAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BookEntryInfoListParentBindingSource, "CreditBalanceStart", True))
        Me.CreditBalanceStartAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CreditBalanceStartAccBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreditBalanceStartAccBox.Location = New System.Drawing.Point(475, 6)
        Me.CreditBalanceStartAccBox.Name = "CreditBalanceStartAccBox"
        Me.CreditBalanceStartAccBox.NegativeValue = False
        Me.CreditBalanceStartAccBox.ReadOnly = True
        Me.CreditBalanceStartAccBox.Size = New System.Drawing.Size(155, 20)
        Me.CreditBalanceStartAccBox.TabIndex = 5
        Me.CreditBalanceStartAccBox.TabStop = False
        Me.CreditBalanceStartAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DebetBalanceStartAccBox
        '
        Me.DebetBalanceStartAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.BookEntryInfoListParentBindingSource, "DebetBalanceStart", True))
        Me.DebetBalanceStartAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DebetBalanceStartAccBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebetBalanceStartAccBox.Location = New System.Drawing.Point(159, 6)
        Me.DebetBalanceStartAccBox.Name = "DebetBalanceStartAccBox"
        Me.DebetBalanceStartAccBox.NegativeValue = False
        Me.DebetBalanceStartAccBox.ReadOnly = True
        Me.DebetBalanceStartAccBox.Size = New System.Drawing.Size(155, 20)
        Me.DebetBalanceStartAccBox.TabIndex = 15
        Me.DebetBalanceStartAccBox.TabStop = False
        Me.DebetBalanceStartAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel5
        '
        Me.Panel5.AutoSize = True
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 383)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.Panel5.Size = New System.Drawing.Size(771, 5)
        Me.Panel5.TabIndex = 1
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(456, 76)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(422, 191)
        Me.ProgressFiller1.TabIndex = 5
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(251, 84)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(422, 191)
        Me.ProgressFiller2.TabIndex = 6
        Me.ProgressFiller2.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.CopyJournalEntryToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripSeparator1, Me.CorrespondationsToolStripMenuItem, Me.RelationsToolStripMenuItem, Me.ToolStripSeparator2, Me.CancelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(169, 148)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.AutoToolTip = True
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.EditToolStripMenuItem.Text = "Keisti"
        '
        'CopyJournalEntryToolStripMenuItem
        '
        Me.CopyJournalEntryToolStripMenuItem.Name = "CopyJournalEntryToolStripMenuItem"
        Me.CopyJournalEntryToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.CopyJournalEntryToolStripMenuItem.Text = "Kopijuoti"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.AutoToolTip = True
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DeleteToolStripMenuItem.Text = "Ištrinti"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(165, 6)
        '
        'CorrespondationsToolStripMenuItem
        '
        Me.CorrespondationsToolStripMenuItem.AutoToolTip = True
        Me.CorrespondationsToolStripMenuItem.Name = "CorrespondationsToolStripMenuItem"
        Me.CorrespondationsToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.CorrespondationsToolStripMenuItem.Text = "Korespondencijos"
        '
        'RelationsToolStripMenuItem
        '
        Me.RelationsToolStripMenuItem.AutoToolTip = True
        Me.RelationsToolStripMenuItem.Name = "RelationsToolStripMenuItem"
        Me.RelationsToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.RelationsToolStripMenuItem.Text = "Ryšiai"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(165, 6)
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.AutoToolTip = True
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.CancelToolStripMenuItem.Text = "Atšaukti"
        '
        'F_BookEntryInfoListParent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 566)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_BookEntryInfoListParent"
        Me.Text = "Sąskaitos apyvartos žiniaraštis"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.ItemsDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BookEntryInfoListParentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents IncludeSubAccountsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ClearButton As System.Windows.Forms.Button
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CreditBalanceEndAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents BookEntryInfoListParentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CreditBalanceStartAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CreditTurnoverAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents DebetBalanceEndAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents DebetBalanceStartAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents DebetTurnoverAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents ItemsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AccountAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents PersonAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CorrespondationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RelationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemsDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn5 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn6 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn7 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn8 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn9 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents PersonGroupComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents CopyJournalEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateFromAccDatePicker As AccControlsWinForms.AccDatePicker
    Friend WithEvents DateToAccDatePicker As AccControlsWinForms.AccDatePicker
End Class
