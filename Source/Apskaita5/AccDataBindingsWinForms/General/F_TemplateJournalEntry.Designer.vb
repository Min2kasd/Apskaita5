﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_TemplateJournalEntry
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
        Dim IDLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_TemplateJournalEntry))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel16 = New System.Windows.Forms.Panel
        Me.ContentTextBox = New System.Windows.Forms.TextBox
        Me.TemplateJournalEntryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.EditedBaner = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.NewItemButton = New System.Windows.Forms.Button
        Me.nCancelButton = New System.Windows.Forms.Button
        Me.ApplyButton = New System.Windows.Forms.Button
        Me.nOkButton = New System.Windows.Forms.Button
        Me.DebetListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CreditListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.CreditListDataListView = New BrightIdeasSoftware.DataListView
        Me.OlvColumn2 = New BrightIdeasSoftware.OLVColumn
        Me.DebetListDataListView = New BrightIdeasSoftware.DataListView
        Me.OlvColumn1 = New BrightIdeasSoftware.OLVColumn
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ErrorWarnInfoProvider1 = New AccControlsWinForms.ErrorWarnInfoProvider(Me.components)
        ContentLabel = New System.Windows.Forms.Label
        IDLabel = New System.Windows.Forms.Label
        NameLabel = New System.Windows.Forms.Label
        CType(Me.TemplateJournalEntryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.EditedBaner.SuspendLayout()
        CType(Me.DebetListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreditListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.CreditListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DebetListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContentLabel
        '
        ContentLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ContentLabel.AutoSize = True
        ContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContentLabel.Location = New System.Drawing.Point(33, 52)
        ContentLabel.Name = "ContentLabel"
        ContentLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        ContentLabel.Size = New System.Drawing.Size(52, 18)
        ContentLabel.TabIndex = 0
        ContentLabel.Text = "Turinys:"
        '
        'IDLabel
        '
        IDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(61, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        IDLabel.Size = New System.Drawing.Size(24, 18)
        IDLabel.TabIndex = 2
        IDLabel.Text = "ID:"
        '
        'NameLabel
        '
        NameLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        NameLabel.AutoSize = True
        NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel.Location = New System.Drawing.Point(3, 26)
        NameLabel.Name = "NameLabel"
        NameLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        NameLabel.Size = New System.Drawing.Size(82, 18)
        NameLabel.TabIndex = 4
        NameLabel.Text = "Pavadinimas:"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(578, 0)
        Me.Panel1.TabIndex = 0
        '
        'Panel16
        '
        Me.Panel16.AutoSize = True
        Me.Panel16.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel16.Location = New System.Drawing.Point(449, 94)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(0, 0)
        Me.Panel16.TabIndex = 8
        '
        'ContentTextBox
        '
        Me.ContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TemplateJournalEntryBindingSource, "Content", True))
        Me.ContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentTextBox.Location = New System.Drawing.Point(91, 55)
        Me.ContentTextBox.MaxLength = 255
        Me.ContentTextBox.Multiline = True
        Me.ContentTextBox.Name = "ContentTextBox"
        Me.ContentTextBox.Size = New System.Drawing.Size(464, 50)
        Me.ContentTextBox.TabIndex = 1
        '
        'TemplateJournalEntryBindingSource
        '
        Me.TemplateJournalEntryBindingSource.DataSource = GetType(ApskaitaObjects.General.TemplateJournalEntry)
        '
        'IDTextBox
        '
        Me.IDTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TemplateJournalEntryBindingSource, "ID", True))
        Me.IDTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IDTextBox.Location = New System.Drawing.Point(91, 3)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(172, 20)
        Me.IDTextBox.TabIndex = 3
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NameTextBox
        '
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TemplateJournalEntryBindingSource, "Name", True))
        Me.NameTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NameTextBox.Location = New System.Drawing.Point(91, 29)
        Me.NameTextBox.MaxLength = 100
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(464, 20)
        Me.NameTextBox.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.Controls.Add(Me.EditedBaner)
        Me.Panel3.Controls.Add(Me.NewItemButton)
        Me.Panel3.Controls.Add(Me.nCancelButton)
        Me.Panel3.Controls.Add(Me.ApplyButton)
        Me.Panel3.Controls.Add(Me.nOkButton)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 381)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.Panel3.Size = New System.Drawing.Size(578, 42)
        Me.Panel3.TabIndex = 2
        '
        'EditedBaner
        '
        Me.EditedBaner.BackColor = System.Drawing.Color.Red
        Me.EditedBaner.Controls.Add(Me.Label4)
        Me.EditedBaner.Location = New System.Drawing.Point(40, 9)
        Me.EditedBaner.Name = "EditedBaner"
        Me.EditedBaner.Size = New System.Drawing.Size(83, 25)
        Me.EditedBaner.TabIndex = 52
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
        'NewItemButton
        '
        Me.NewItemButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewItemButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.NewItemButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewItemButton.Location = New System.Drawing.Point(496, 11)
        Me.NewItemButton.Name = "NewItemButton"
        Me.NewItemButton.Size = New System.Drawing.Size(75, 23)
        Me.NewItemButton.TabIndex = 3
        Me.NewItemButton.Text = "Naujas"
        Me.NewItemButton.UseVisualStyleBackColor = True
        '
        'nCancelButton
        '
        Me.nCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.nCancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nCancelButton.Location = New System.Drawing.Point(415, 11)
        Me.nCancelButton.Name = "nCancelButton"
        Me.nCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.nCancelButton.TabIndex = 2
        Me.nCancelButton.Text = "Atšaukti"
        Me.nCancelButton.UseVisualStyleBackColor = True
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButton.Location = New System.Drawing.Point(334, 11)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(75, 23)
        Me.ApplyButton.TabIndex = 1
        Me.ApplyButton.Text = "Taikyti"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'nOkButton
        '
        Me.nOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nOkButton.Location = New System.Drawing.Point(253, 11)
        Me.nOkButton.Name = "nOkButton"
        Me.nOkButton.Size = New System.Drawing.Size(75, 23)
        Me.nOkButton.TabIndex = 0
        Me.nOkButton.Text = "OK"
        Me.nOkButton.UseVisualStyleBackColor = True
        '
        'DebetListBindingSource
        '
        Me.DebetListBindingSource.DataMember = "DebetList"
        Me.DebetListBindingSource.DataSource = Me.TemplateJournalEntryBindingSource
        '
        'CreditListBindingSource
        '
        Me.CreditListBindingSource.DataMember = "CreditList"
        Me.CreditListBindingSource.DataSource = Me.TemplateJournalEntryBindingSource
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.IDTextBox, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ContentTextBox, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(ContentLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(NameLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.NameTextBox, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(578, 113)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.CreditListDataListView, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.DebetListDataListView, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 113)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(578, 268)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'CreditListDataListView
        '
        Me.CreditListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.CreditListDataListView.AllowColumnReorder = True
        Me.CreditListDataListView.AutoGenerateColumns = False
        Me.CreditListDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.CreditListDataListView.CellEditEnterChangesRows = True
        Me.CreditListDataListView.CellEditTabChangesRows = True
        Me.CreditListDataListView.CellEditUseWholeCell = False
        Me.CreditListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2})
        Me.CreditListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.CreditListDataListView.DataSource = Me.CreditListBindingSource
        Me.CreditListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CreditListDataListView.FullRowSelect = True
        Me.CreditListDataListView.HasCollapsibleGroups = False
        Me.CreditListDataListView.HeaderWordWrap = True
        Me.CreditListDataListView.HideSelection = False
        Me.CreditListDataListView.IncludeColumnHeadersInCopy = True
        Me.CreditListDataListView.Location = New System.Drawing.Point(292, 3)
        Me.CreditListDataListView.Name = "CreditListDataListView"
        Me.CreditListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.CreditListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.CreditListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.CreditListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.CreditListDataListView.ShowCommandMenuOnRightClick = True
        Me.CreditListDataListView.ShowGroups = False
        Me.CreditListDataListView.ShowImagesOnSubItems = True
        Me.CreditListDataListView.ShowItemCountOnGroups = True
        Me.CreditListDataListView.ShowItemToolTips = True
        Me.CreditListDataListView.Size = New System.Drawing.Size(283, 262)
        Me.CreditListDataListView.TabIndex = 9
        Me.CreditListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.CreditListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.CreditListDataListView.UseCellFormatEvents = True
        Me.CreditListDataListView.UseCompatibleStateImageBehavior = False
        Me.CreditListDataListView.UseFilterIndicator = True
        Me.CreditListDataListView.UseFiltering = True
        Me.CreditListDataListView.UseHotItem = True
        Me.CreditListDataListView.UseNotifyPropertyChanged = True
        Me.CreditListDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "Account"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.Text = "Kredituojamos Sąsk."
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 143
        '
        'DebetListDataListView
        '
        Me.DebetListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.DebetListDataListView.AllowColumnReorder = True
        Me.DebetListDataListView.AutoGenerateColumns = False
        Me.DebetListDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.DebetListDataListView.CellEditEnterChangesRows = True
        Me.DebetListDataListView.CellEditTabChangesRows = True
        Me.DebetListDataListView.CellEditUseWholeCell = False
        Me.DebetListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1})
        Me.DebetListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.DebetListDataListView.DataSource = Me.DebetListBindingSource
        Me.DebetListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DebetListDataListView.FullRowSelect = True
        Me.DebetListDataListView.HasCollapsibleGroups = False
        Me.DebetListDataListView.HeaderWordWrap = True
        Me.DebetListDataListView.HideSelection = False
        Me.DebetListDataListView.IncludeColumnHeadersInCopy = True
        Me.DebetListDataListView.Location = New System.Drawing.Point(3, 3)
        Me.DebetListDataListView.Name = "DebetListDataListView"
        Me.DebetListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.DebetListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.DebetListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.DebetListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.DebetListDataListView.ShowCommandMenuOnRightClick = True
        Me.DebetListDataListView.ShowGroups = False
        Me.DebetListDataListView.ShowImagesOnSubItems = True
        Me.DebetListDataListView.ShowItemCountOnGroups = True
        Me.DebetListDataListView.ShowItemToolTips = True
        Me.DebetListDataListView.Size = New System.Drawing.Size(283, 262)
        Me.DebetListDataListView.TabIndex = 8
        Me.DebetListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.DebetListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.DebetListDataListView.UseCellFormatEvents = True
        Me.DebetListDataListView.UseCompatibleStateImageBehavior = False
        Me.DebetListDataListView.UseFilterIndicator = True
        Me.DebetListDataListView.UseFiltering = True
        Me.DebetListDataListView.UseHotItem = True
        Me.DebetListDataListView.UseNotifyPropertyChanged = True
        Me.DebetListDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "Account"
        Me.OlvColumn1.CellEditUseWholeCell = True
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.Text = "Debetuojamos Sąsk."
        Me.OlvColumn1.ToolTipText = ""
        Me.OlvColumn1.Width = 141
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(172, 157)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(257, 78)
        Me.ProgressFiller1.TabIndex = 9
        Me.ProgressFiller1.Visible = False
        '
        'ErrorWarnInfoProvider1
        '
        Me.ErrorWarnInfoProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleInformation = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleWarning = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.ContainerControl = Me
        Me.ErrorWarnInfoProvider1.DataSource = Me.TemplateJournalEntryBindingSource
        '
        'F_TemplateJournalEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 423)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel16)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_TemplateJournalEntry"
        Me.Text = "Bendrojo žurnalo operacijos šablonas"
        CType(Me.TemplateJournalEntryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.EditedBaner.ResumeLayout(False)
        Me.EditedBaner.PerformLayout()
        CType(Me.DebetListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreditListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.CreditListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DebetListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents ContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TemplateJournalEntryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents NewItemButton As System.Windows.Forms.Button
    Friend WithEvents nCancelButton As System.Windows.Forms.Button
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents nOkButton As System.Windows.Forms.Button
    Friend WithEvents EditedBaner As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DebetListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CreditListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CreditListDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents DebetListDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ErrorWarnInfoProvider1 As AccControlsWinForms.ErrorWarnInfoProvider
End Class
