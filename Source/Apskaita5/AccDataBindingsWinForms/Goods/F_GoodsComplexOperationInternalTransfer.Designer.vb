﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_GoodsComplexOperationInternalTransfer
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
        Dim IDLabel As System.Windows.Forms.Label
        Dim InsertDateLabel As System.Windows.Forms.Label
        Dim UpdateDateLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim DocumentNumberLabel As System.Windows.Forms.Label
        Dim JournalEntryIDLabel As System.Windows.Forms.Label
        Dim WarehouseFromLabel As System.Windows.Forms.Label
        Dim WarehouseToLabel As System.Windows.Forms.Label
        Dim ContentLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_GoodsComplexOperationInternalTransfer))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel
        Me.ContentTextBox = New System.Windows.Forms.TextBox
        Me.GoodsComplexOperationInternalTransferBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.WarehouseToAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.JournalEntryIDTextBox = New System.Windows.Forms.TextBox
        Me.DocumentNumberTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.WarehouseFromAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button
        Me.UpdateDateTextBox = New System.Windows.Forms.TextBox
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.InsertDateTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.AddNewItemsButton = New System.Windows.Forms.Button
        Me.RefreshCostsButton = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.EditedBaner = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.nCancelButton = New System.Windows.Forms.Button
        Me.ApplyButton = New System.Windows.Forms.Button
        Me.nOkButton = New System.Windows.Forms.Button
        Me.ItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.OlvColumn10 = New BrightIdeasSoftware.OLVColumn
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.ErrorWarnInfoProvider1 = New AccControlsWinForms.ErrorWarnInfoProvider(Me.components)
        Me.DateAccDatePicker = New AccControlsWinForms.AccDatePicker
        IDLabel = New System.Windows.Forms.Label
        InsertDateLabel = New System.Windows.Forms.Label
        UpdateDateLabel = New System.Windows.Forms.Label
        DateLabel = New System.Windows.Forms.Label
        DocumentNumberLabel = New System.Windows.Forms.Label
        JournalEntryIDLabel = New System.Windows.Forms.Label
        WarehouseFromLabel = New System.Windows.Forms.Label
        WarehouseToLabel = New System.Windows.Forms.Label
        ContentLabel = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        CType(Me.GoodsComplexOperationInternalTransferBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.EditedBaner.SuspendLayout()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IDLabel
        '
        IDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(53, 6)
        IDLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(24, 13)
        IDLabel.TabIndex = 5
        IDLabel.Text = "ID:"
        '
        'InsertDateLabel
        '
        InsertDateLabel.AutoSize = True
        InsertDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        InsertDateLabel.Location = New System.Drawing.Point(184, 3)
        InsertDateLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        InsertDateLabel.Name = "InsertDateLabel"
        InsertDateLabel.Size = New System.Drawing.Size(55, 13)
        InsertDateLabel.TabIndex = 6
        InsertDateLabel.Text = "Įtraukta:"
        '
        'UpdateDateLabel
        '
        UpdateDateLabel.AutoSize = True
        UpdateDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UpdateDateLabel.Location = New System.Drawing.Point(449, 3)
        UpdateDateLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        UpdateDateLabel.Name = "UpdateDateLabel"
        UpdateDateLabel.Size = New System.Drawing.Size(60, 13)
        UpdateDateLabel.TabIndex = 8
        UpdateDateLabel.Text = "Pakeista:"
        '
        'DateLabel
        '
        DateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DateLabel.AutoSize = True
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(39, 36)
        DateLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(38, 13)
        DateLabel.TabIndex = 4
        DateLabel.Text = "Data:"
        '
        'DocumentNumberLabel
        '
        DocumentNumberLabel.AutoSize = True
        DocumentNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DocumentNumberLabel.Location = New System.Drawing.Point(213, 3)
        DocumentNumberLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        DocumentNumberLabel.Name = "DocumentNumberLabel"
        DocumentNumberLabel.Size = New System.Drawing.Size(59, 13)
        DocumentNumberLabel.TabIndex = 6
        DocumentNumberLabel.Text = "Dok. Nr.:"
        '
        'JournalEntryIDLabel
        '
        JournalEntryIDLabel.AutoSize = True
        JournalEntryIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        JournalEntryIDLabel.Location = New System.Drawing.Point(488, 3)
        JournalEntryIDLabel.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        JournalEntryIDLabel.Name = "JournalEntryIDLabel"
        JournalEntryIDLabel.Size = New System.Drawing.Size(44, 13)
        JournalEntryIDLabel.TabIndex = 8
        JournalEntryIDLabel.Text = "BŽ ID:"
        '
        'WarehouseFromLabel
        '
        WarehouseFromLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        WarehouseFromLabel.AutoSize = True
        WarehouseFromLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        WarehouseFromLabel.Location = New System.Drawing.Point(3, 66)
        WarehouseFromLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        WarehouseFromLabel.Name = "WarehouseFromLabel"
        WarehouseFromLabel.Size = New System.Drawing.Size(74, 13)
        WarehouseFromLabel.TabIndex = 5
        WarehouseFromLabel.Text = "Iš Sandėlio:"
        '
        'WarehouseToLabel
        '
        WarehouseToLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        WarehouseToLabel.AutoSize = True
        WarehouseToLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        WarehouseToLabel.Location = New System.Drawing.Point(16, 96)
        WarehouseToLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        WarehouseToLabel.Name = "WarehouseToLabel"
        WarehouseToLabel.Size = New System.Drawing.Size(61, 13)
        WarehouseToLabel.TabIndex = 7
        WarehouseToLabel.Text = "Į Sandėlį:"
        '
        'ContentLabel
        '
        ContentLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ContentLabel.AutoSize = True
        ContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContentLabel.Location = New System.Drawing.Point(6, 126)
        ContentLabel.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        ContentLabel.Name = "ContentLabel"
        ContentLabel.Size = New System.Drawing.Size(71, 13)
        ContentLabel.TabIndex = 9
        ContentLabel.Text = "Aprašymas:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel7, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(ContentLabel, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel6, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(WarehouseToLabel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(DateLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(WarehouseFromLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 5)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(804, 180)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.ContentTextBox, 0, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(80, 123)
        Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(724, 24)
        Me.TableLayoutPanel7.TabIndex = 4
        '
        'ContentTextBox
        '
        Me.ContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsComplexOperationInternalTransferBindingSource, "Content", True))
        Me.ContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentTextBox.Location = New System.Drawing.Point(2, 1)
        Me.ContentTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.ContentTextBox.MaxLength = 255
        Me.ContentTextBox.Name = "ContentTextBox"
        Me.ContentTextBox.Size = New System.Drawing.Size(700, 20)
        Me.ContentTextBox.TabIndex = 0
        '
        'GoodsComplexOperationInternalTransferBindingSource
        '
        Me.GoodsComplexOperationInternalTransferBindingSource.DataSource = GetType(ApskaitaObjects.Goods.GoodsComplexOperationInternalTransfer)
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.WarehouseToAccGridComboBox, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(80, 93)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(724, 24)
        Me.TableLayoutPanel6.TabIndex = 3
        '
        'WarehouseToAccGridComboBox
        '
        Me.WarehouseToAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.GoodsComplexOperationInternalTransferBindingSource, "WarehouseTo", True))
        Me.WarehouseToAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WarehouseToAccGridComboBox.EmptyValueString = ""
        Me.WarehouseToAccGridComboBox.Location = New System.Drawing.Point(2, 1)
        Me.WarehouseToAccGridComboBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.WarehouseToAccGridComboBox.Name = "WarehouseToAccGridComboBox"
        Me.WarehouseToAccGridComboBox.Size = New System.Drawing.Size(700, 21)
        Me.WarehouseToAccGridComboBox.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoScroll = True
        Me.TableLayoutPanel4.ColumnCount = 8
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.JournalEntryIDTextBox, 6, 0)
        Me.TableLayoutPanel4.Controls.Add(JournalEntryIDLabel, 5, 0)
        Me.TableLayoutPanel4.Controls.Add(DocumentNumberLabel, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.DocumentNumberTextBox, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.DateAccDatePicker, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(80, 33)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(724, 24)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'JournalEntryIDTextBox
        '
        Me.JournalEntryIDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsComplexOperationInternalTransferBindingSource, "JournalEntryID", True))
        Me.JournalEntryIDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JournalEntryIDTextBox.Location = New System.Drawing.Point(537, 1)
        Me.JournalEntryIDTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.JournalEntryIDTextBox.Name = "JournalEntryIDTextBox"
        Me.JournalEntryIDTextBox.ReadOnly = True
        Me.JournalEntryIDTextBox.Size = New System.Drawing.Size(159, 20)
        Me.JournalEntryIDTextBox.TabIndex = 9
        Me.JournalEntryIDTextBox.TabStop = False
        Me.JournalEntryIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DocumentNumberTextBox
        '
        Me.DocumentNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsComplexOperationInternalTransferBindingSource, "DocumentNumber", True))
        Me.DocumentNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentNumberTextBox.Location = New System.Drawing.Point(277, 1)
        Me.DocumentNumberTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.DocumentNumberTextBox.MaxLength = 50
        Me.DocumentNumberTextBox.Name = "DocumentNumberTextBox"
        Me.DocumentNumberTextBox.Size = New System.Drawing.Size(186, 20)
        Me.DocumentNumberTextBox.TabIndex = 1
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.WarehouseFromAccGridComboBox, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(80, 63)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(724, 24)
        Me.TableLayoutPanel5.TabIndex = 2
        '
        'WarehouseFromAccGridComboBox
        '
        Me.WarehouseFromAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.GoodsComplexOperationInternalTransferBindingSource, "WarehouseFrom", True))
        Me.WarehouseFromAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WarehouseFromAccGridComboBox.EmptyValueString = ""
        Me.WarehouseFromAccGridComboBox.InstantBinding = True
        Me.WarehouseFromAccGridComboBox.Location = New System.Drawing.Point(2, 1)
        Me.WarehouseFromAccGridComboBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.WarehouseFromAccGridComboBox.Name = "WarehouseFromAccGridComboBox"
        Me.WarehouseFromAccGridComboBox.Size = New System.Drawing.Size(700, 21)
        Me.WarehouseFromAccGridComboBox.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 8
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.ViewJournalEntryButton, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.UpdateDateTextBox, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(UpdateDateLabel, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.IDTextBox, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(InsertDateLabel, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.InsertDateTextBox, 3, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(80, 3)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(724, 24)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(157, 0)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 91
        Me.ViewJournalEntryButton.TabStop = False
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = True
        '
        'UpdateDateTextBox
        '
        Me.UpdateDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsComplexOperationInternalTransferBindingSource, "UpdateDate", True))
        Me.UpdateDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UpdateDateTextBox.Location = New System.Drawing.Point(514, 1)
        Me.UpdateDateTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.UpdateDateTextBox.Name = "UpdateDateTextBox"
        Me.UpdateDateTextBox.ReadOnly = True
        Me.UpdateDateTextBox.Size = New System.Drawing.Size(180, 20)
        Me.UpdateDateTextBox.TabIndex = 9
        Me.UpdateDateTextBox.TabStop = False
        Me.UpdateDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IDTextBox
        '
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsComplexOperationInternalTransferBindingSource, "ID", True))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Location = New System.Drawing.Point(2, 1)
        Me.IDTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(153, 20)
        Me.IDTextBox.TabIndex = 6
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'InsertDateTextBox
        '
        Me.InsertDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GoodsComplexOperationInternalTransferBindingSource, "InsertDate", True))
        Me.InsertDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InsertDateTextBox.Location = New System.Drawing.Point(244, 1)
        Me.InsertDateTextBox.Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
        Me.InsertDateTextBox.Name = "InsertDateTextBox"
        Me.InsertDateTextBox.ReadOnly = True
        Me.InsertDateTextBox.Size = New System.Drawing.Size(180, 20)
        Me.InsertDateTextBox.TabIndex = 7
        Me.InsertDateTextBox.TabStop = False
        Me.InsertDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 7
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.AddNewItemsButton, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.RefreshCostsButton, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(80, 150)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(724, 46)
        Me.TableLayoutPanel2.TabIndex = 59
        '
        'AddNewItemsButton
        '
        Me.AddNewItemsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddNewItemsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddNewItemsButton.Location = New System.Drawing.Point(625, 3)
        Me.AddNewItemsButton.Name = "AddNewItemsButton"
        Me.AddNewItemsButton.Size = New System.Drawing.Size(70, 23)
        Me.AddNewItemsButton.TabIndex = 5
        Me.AddNewItemsButton.Text = "Pridėti"
        Me.AddNewItemsButton.UseVisualStyleBackColor = True
        '
        'RefreshCostsButton
        '
        Me.RefreshCostsButton.AutoSize = True
        Me.RefreshCostsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RefreshCostsButton.Location = New System.Drawing.Point(504, 3)
        Me.RefreshCostsButton.Name = "RefreshCostsButton"
        Me.RefreshCostsButton.Size = New System.Drawing.Size(95, 23)
        Me.RefreshCostsButton.TabIndex = 52
        Me.RefreshCostsButton.Text = "Gauti Savik."
        Me.RefreshCostsButton.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.EditedBaner)
        Me.Panel2.Controls.Add(Me.nCancelButton)
        Me.Panel2.Controls.Add(Me.ApplyButton)
        Me.Panel2.Controls.Add(Me.nOkButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 521)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Panel2.Size = New System.Drawing.Size(804, 37)
        Me.Panel2.TabIndex = 2
        '
        'EditedBaner
        '
        Me.EditedBaner.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditedBaner.BackColor = System.Drawing.Color.Red
        Me.EditedBaner.Controls.Add(Me.Label4)
        Me.EditedBaner.Location = New System.Drawing.Point(453, 5)
        Me.EditedBaner.Name = "EditedBaner"
        Me.EditedBaner.Size = New System.Drawing.Size(83, 25)
        Me.EditedBaner.TabIndex = 51
        Me.EditedBaner.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "TAISOMA"
        '
        'nCancelButton
        '
        Me.nCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.nCancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nCancelButton.Location = New System.Drawing.Point(717, 7)
        Me.nCancelButton.Name = "nCancelButton"
        Me.nCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.nCancelButton.TabIndex = 3
        Me.nCancelButton.Text = "Atšaukti"
        Me.nCancelButton.UseVisualStyleBackColor = True
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButton.Location = New System.Drawing.Point(636, 7)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.ApplyButton.TabIndex = 2
        Me.ApplyButton.Text = "Taikyti"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'nOkButton
        '
        Me.nOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nOkButton.Location = New System.Drawing.Point(555, 7)
        Me.nOkButton.Name = "nOkButton"
        Me.nOkButton.Size = New System.Drawing.Size(75, 23)
        Me.nOkButton.TabIndex = 1
        Me.nOkButton.Text = "OK"
        Me.nOkButton.UseVisualStyleBackColor = True
        '
        'ItemsBindingSource
        '
        Me.ItemsBindingSource.DataMember = "Items"
        Me.ItemsBindingSource.DataSource = Me.GoodsComplexOperationInternalTransferBindingSource
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
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn10)
        Me.ItemsDataListView.AllowColumnReorder = True
        Me.ItemsDataListView.AutoGenerateColumns = False
        Me.ItemsDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.ItemsDataListView.CellEditEnterChangesRows = True
        Me.ItemsDataListView.CellEditTabChangesRows = True
        Me.ItemsDataListView.CellEditUseWholeCell = False
        Me.ItemsDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn5, Me.OlvColumn6, Me.OlvColumn7, Me.OlvColumn8, Me.OlvColumn9, Me.OlvColumn10})
        Me.ItemsDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.ItemsDataListView.DataSource = Me.ItemsBindingSource
        Me.ItemsDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemsDataListView.FullRowSelect = True
        Me.ItemsDataListView.HasCollapsibleGroups = False
        Me.ItemsDataListView.HeaderWordWrap = True
        Me.ItemsDataListView.HideSelection = False
        Me.ItemsDataListView.IncludeColumnHeadersInCopy = True
        Me.ItemsDataListView.Location = New System.Drawing.Point(0, 180)
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
        Me.ItemsDataListView.Size = New System.Drawing.Size(804, 341)
        Me.ItemsDataListView.TabIndex = 3
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
        Me.OlvColumn2.AspectName = "GoodsName"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.IsEditable = False
        Me.OlvColumn2.Text = "Prekė"
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 281
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
        Me.OlvColumn3.AspectName = "GoodsMeasureUnit"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsEditable = False
        Me.OlvColumn3.Text = "Mato Vnt."
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 64
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "GoodsAccountingMethod"
        Me.OlvColumn4.CellEditUseWholeCell = True
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.IsEditable = False
        Me.OlvColumn4.Text = "Apskaitos Metodas"
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 100
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "GoodsValuationMethod"
        Me.OlvColumn5.CellEditUseWholeCell = True
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.IsEditable = False
        Me.OlvColumn5.Text = "Vertinimo Metodas"
        Me.OlvColumn5.ToolTipText = ""
        Me.OlvColumn5.Width = 100
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "Amount"
        Me.OlvColumn6.AspectToStringFormat = "{0:##,0.000000}"
        Me.OlvColumn6.CellEditUseWholeCell = True
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.Text = "Kiekis"
        Me.OlvColumn6.ToolTipText = ""
        Me.OlvColumn6.Width = 95
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "UnitCost"
        Me.OlvColumn7.AspectToStringFormat = "{0:##,0.000000}"
        Me.OlvColumn7.CellEditUseWholeCell = True
        Me.OlvColumn7.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.IsEditable = False
        Me.OlvColumn7.Text = "Vnt. Savikaina"
        Me.OlvColumn7.ToolTipText = ""
        Me.OlvColumn7.Width = 83
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "TotalCost"
        Me.OlvColumn8.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn8.CellEditUseWholeCell = True
        Me.OlvColumn8.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.IsEditable = False
        Me.OlvColumn8.Text = "Viso Savikaina"
        Me.OlvColumn8.ToolTipText = ""
        Me.OlvColumn8.Width = 90
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "Remarks"
        Me.OlvColumn9.CellEditUseWholeCell = True
        Me.OlvColumn9.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.Text = "Pastabos"
        Me.OlvColumn9.ToolTipText = ""
        Me.OlvColumn9.Width = 220
        '
        'OlvColumn10
        '
        Me.OlvColumn10.AspectName = "AmountCanChange"
        Me.OlvColumn10.CellEditUseWholeCell = True
        Me.OlvColumn10.CheckBoxes = True
        Me.OlvColumn10.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn10.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn10.IsEditable = False
        Me.OlvColumn10.Text = "Neribota"
        Me.OlvColumn10.ToolTipText = ""
        Me.OlvColumn10.Width = 100
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(152, 216)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(146, 69)
        Me.ProgressFiller1.TabIndex = 4
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(317, 215)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(178, 69)
        Me.ProgressFiller2.TabIndex = 5
        Me.ProgressFiller2.Visible = False
        '
        'ErrorWarnInfoProvider1
        '
        Me.ErrorWarnInfoProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleInformation = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleWarning = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.ContainerControl = Me
        Me.ErrorWarnInfoProvider1.DataSource = Me.GoodsComplexOperationInternalTransferBindingSource
        '
        'DateAccDatePicker
        '
        Me.DateAccDatePicker.BoldedDates = Nothing
        Me.DateAccDatePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.GoodsComplexOperationInternalTransferBindingSource, "Date", True))
        Me.DateAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateAccDatePicker.Location = New System.Drawing.Point(0, 0)
        Me.DateAccDatePicker.Margin = New System.Windows.Forms.Padding(0)
        Me.DateAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateAccDatePicker.Name = "DateAccDatePicker"
        Me.DateAccDatePicker.ReadOnly = False
        Me.DateAccDatePicker.ShowWeekNumbers = True
        Me.DateAccDatePicker.Size = New System.Drawing.Size(190, 24)
        Me.DateAccDatePicker.TabIndex = 0
        '
        'F_GoodsComplexOperationInternalTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 558)
        Me.Controls.Add(Me.ItemsDataListView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_GoodsComplexOperationInternalTransfer"
        Me.ShowInTaskbar = False
        Me.Text = "Vidinis Prekių Judėjimas"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        CType(Me.GoodsComplexOperationInternalTransferBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.EditedBaner.ResumeLayout(False)
        Me.EditedBaner.PerformLayout()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents UpdateDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GoodsComplexOperationInternalTransferBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InsertDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DocumentNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents JournalEntryIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents WarehouseToAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents WarehouseFromAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents EditedBaner As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nCancelButton As System.Windows.Forms.Button
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents nOkButton As System.Windows.Forms.Button
    Friend WithEvents ItemsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RefreshCostsButton As System.Windows.Forms.Button
    Friend WithEvents AddNewItemsButton As System.Windows.Forms.Button
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
    Friend WithEvents OlvColumn10 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ErrorWarnInfoProvider1 As AccControlsWinForms.ErrorWarnInfoProvider
    Friend WithEvents DateAccDatePicker As AccControlsWinForms.AccDatePicker
End Class
