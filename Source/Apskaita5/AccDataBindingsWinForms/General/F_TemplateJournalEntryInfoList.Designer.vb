﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_TemplateJournalEntryInfoList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_TemplateJournalEntryInfoList))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RefreshButton = New System.Windows.Forms.Button
        Me.NewTemplateButton = New System.Windows.Forms.Button
        Me.TemplateJournalEntryListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChangeItem_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteItem_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewItem_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TemplateJournalEntryListDataListView = New BrightIdeasSoftware.DataListView
        Me.OlvColumn2 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn1 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn3 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn4 = New BrightIdeasSoftware.OLVColumn
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.Panel1.SuspendLayout()
        CType(Me.TemplateJournalEntryListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.TemplateJournalEntryListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.RefreshButton)
        Me.Panel1.Controls.Add(Me.NewTemplateButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 388)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(666, 35)
        Me.Panel1.TabIndex = 1
        '
        'RefreshButton
        '
        Me.RefreshButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RefreshButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Button_Reload_icon_16p
        Me.RefreshButton.Location = New System.Drawing.Point(586, 6)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(26, 26)
        Me.RefreshButton.TabIndex = 5
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'NewTemplateButton
        '
        Me.NewTemplateButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewTemplateButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewTemplateButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Action_file_new_icon_16p
        Me.NewTemplateButton.Location = New System.Drawing.Point(628, 6)
        Me.NewTemplateButton.Name = "NewTemplateButton"
        Me.NewTemplateButton.Size = New System.Drawing.Size(26, 26)
        Me.NewTemplateButton.TabIndex = 2
        Me.NewTemplateButton.UseVisualStyleBackColor = True
        '
        'TemplateJournalEntryListBindingSource
        '
        Me.TemplateJournalEntryListBindingSource.DataSource = GetType(ApskaitaObjects.HelperLists.TemplateJournalEntryInfo)
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeItem_MenuItem, Me.DeleteItem_MenuItem, Me.NewItem_MenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(111, 70)
        '
        'ChangeItem_MenuItem
        '
        Me.ChangeItem_MenuItem.Name = "ChangeItem_MenuItem"
        Me.ChangeItem_MenuItem.Size = New System.Drawing.Size(110, 22)
        Me.ChangeItem_MenuItem.Text = "Keisti"
        '
        'DeleteItem_MenuItem
        '
        Me.DeleteItem_MenuItem.Name = "DeleteItem_MenuItem"
        Me.DeleteItem_MenuItem.Size = New System.Drawing.Size(110, 22)
        Me.DeleteItem_MenuItem.Text = "Ištrinti"
        '
        'NewItem_MenuItem
        '
        Me.NewItem_MenuItem.Name = "NewItem_MenuItem"
        Me.NewItem_MenuItem.Size = New System.Drawing.Size(110, 22)
        Me.NewItem_MenuItem.Text = "Naujas"
        '
        'TemplateJournalEntryListDataListView
        '
        Me.TemplateJournalEntryListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.TemplateJournalEntryListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.TemplateJournalEntryListDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.TemplateJournalEntryListDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.TemplateJournalEntryListDataListView.AllowColumnReorder = True
        Me.TemplateJournalEntryListDataListView.AutoGenerateColumns = False
        Me.TemplateJournalEntryListDataListView.CausesValidation = False
        Me.TemplateJournalEntryListDataListView.CellEditUseWholeCell = False
        Me.TemplateJournalEntryListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4})
        Me.TemplateJournalEntryListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.TemplateJournalEntryListDataListView.DataSource = Me.TemplateJournalEntryListBindingSource
        Me.TemplateJournalEntryListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TemplateJournalEntryListDataListView.FullRowSelect = True
        Me.TemplateJournalEntryListDataListView.HasCollapsibleGroups = False
        Me.TemplateJournalEntryListDataListView.HeaderWordWrap = True
        Me.TemplateJournalEntryListDataListView.HideSelection = False
        Me.TemplateJournalEntryListDataListView.IncludeColumnHeadersInCopy = True
        Me.TemplateJournalEntryListDataListView.Location = New System.Drawing.Point(0, 0)
        Me.TemplateJournalEntryListDataListView.Name = "TemplateJournalEntryListDataListView"
        Me.TemplateJournalEntryListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.TemplateJournalEntryListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.TemplateJournalEntryListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.TemplateJournalEntryListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.TemplateJournalEntryListDataListView.ShowCommandMenuOnRightClick = True
        Me.TemplateJournalEntryListDataListView.ShowGroups = False
        Me.TemplateJournalEntryListDataListView.ShowImagesOnSubItems = True
        Me.TemplateJournalEntryListDataListView.ShowItemCountOnGroups = True
        Me.TemplateJournalEntryListDataListView.ShowItemToolTips = True
        Me.TemplateJournalEntryListDataListView.Size = New System.Drawing.Size(666, 388)
        Me.TemplateJournalEntryListDataListView.TabIndex = 4
        Me.TemplateJournalEntryListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.TemplateJournalEntryListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.TemplateJournalEntryListDataListView.UseCellFormatEvents = True
        Me.TemplateJournalEntryListDataListView.UseCompatibleStateImageBehavior = False
        Me.TemplateJournalEntryListDataListView.UseFilterIndicator = True
        Me.TemplateJournalEntryListDataListView.UseFiltering = True
        Me.TemplateJournalEntryListDataListView.UseHotItem = True
        Me.TemplateJournalEntryListDataListView.UseNotifyPropertyChanged = True
        Me.TemplateJournalEntryListDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "Name"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.IsEditable = False
        Me.OlvColumn2.Text = "Pavadinimas"
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 123
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
        Me.OlvColumn3.AspectName = "Content"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsEditable = False
        Me.OlvColumn3.Text = "Operacijos turinys"
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 304
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "CorespondationListString"
        Me.OlvColumn4.CellEditUseWholeCell = True
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.IsEditable = False
        Me.OlvColumn4.Text = "Korespondencijos"
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 232
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(191, 33)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(229, 55)
        Me.ProgressFiller1.TabIndex = 5
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(267, 114)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(175, 32)
        Me.ProgressFiller2.TabIndex = 6
        Me.ProgressFiller2.Visible = False
        '
        'F_Templates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 423)
        Me.Controls.Add(Me.TemplateJournalEntryListDataListView)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_Templates"
        Me.Text = "Tipinių operacijų sąrašas"
        Me.Panel1.ResumeLayout(False)
        CType(Me.TemplateJournalEntryListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.TemplateJournalEntryListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents NewTemplateButton As System.Windows.Forms.Button
    Friend WithEvents TemplateJournalEntryListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ChangeItem_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteItem_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewItem_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TemplateJournalEntryListDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
End Class
