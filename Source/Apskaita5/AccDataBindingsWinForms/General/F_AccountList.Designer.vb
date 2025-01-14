﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class F_AccountList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_AccountList))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.AddFromTypicalAccountsAccButton = New AccControlsWinForms.AccButton()
        Me.CopyToClipboardButton = New System.Windows.Forms.Button()
        Me.SaveFileButton = New System.Windows.Forms.Button()
        Me.OpenFileAccButton = New AccControlsWinForms.AccButton()
        Me.PasteAccButton = New AccControlsWinForms.AccButton()
        Me.nCancelButton = New System.Windows.Forms.Button()
        Me.ApplyButton = New System.Windows.Forms.Button()
        Me.nOkButton = New System.Windows.Forms.Button()
        Me.AccountListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AccountListDataListView = New BrightIdeasSoftware.DataListView()
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn6 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn5 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller()
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2.SuspendLayout()
        CType(Me.AccountListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.AddFromTypicalAccountsAccButton)
        Me.Panel2.Controls.Add(Me.CopyToClipboardButton)
        Me.Panel2.Controls.Add(Me.SaveFileButton)
        Me.Panel2.Controls.Add(Me.OpenFileAccButton)
        Me.Panel2.Controls.Add(Me.PasteAccButton)
        Me.Panel2.Controls.Add(Me.nCancelButton)
        Me.Panel2.Controls.Add(Me.ApplyButton)
        Me.Panel2.Controls.Add(Me.nOkButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 428)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(764, 39)
        Me.Panel2.TabIndex = 2
        '
        'AddFromTypicalAccountsAccButton
        '
        Me.AddFromTypicalAccountsAccButton.BorderStyleDown = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.AddFromTypicalAccountsAccButton.BorderStyleNormal = System.Windows.Forms.Border3DStyle.Flat
        Me.AddFromTypicalAccountsAccButton.BorderStyleUp = System.Windows.Forms.Border3DStyle.RaisedOuter
        Me.AddFromTypicalAccountsAccButton.ButtonStyle = AccControlsWinForms.rsButtonStyle.Button
        Me.AddFromTypicalAccountsAccButton.Checked = False
        Me.AddFromTypicalAccountsAccButton.DropDownSepWidth = 12
        Me.AddFromTypicalAccountsAccButton.FocusRectangle = False
        Me.AddFromTypicalAccountsAccButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.book_add_icon
        Me.AddFromTypicalAccountsAccButton.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AddFromTypicalAccountsAccButton.ImagePadding = 2
        Me.AddFromTypicalAccountsAccButton.Location = New System.Drawing.Point(176, 6)
        Me.AddFromTypicalAccountsAccButton.Name = "AddFromTypicalAccountsAccButton"
        Me.AddFromTypicalAccountsAccButton.Size = New System.Drawing.Size(29, 25)
        Me.AddFromTypicalAccountsAccButton.TabIndex = 77
        Me.AddFromTypicalAccountsAccButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AddFromTypicalAccountsAccButton.TextPadding = 2
        Me.ToolTip1.SetToolTip(Me.AddFromTypicalAccountsAccButton, "Pridėti naują sąskaitą iš pavyzdinio sąskaitų plano")
        '
        'CopyToClipboardButton
        '
        Me.CopyToClipboardButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Actions_edit_copy_icon_16p
        Me.CopyToClipboardButton.Location = New System.Drawing.Point(12, 6)
        Me.CopyToClipboardButton.Name = "CopyToClipboardButton"
        Me.CopyToClipboardButton.Size = New System.Drawing.Size(35, 25)
        Me.CopyToClipboardButton.TabIndex = 76
        Me.ToolTip1.SetToolTip(Me.CopyToClipboardButton, "Kopijuoti sąskaitų planą į clipboard'ą")
        Me.CopyToClipboardButton.UseVisualStyleBackColor = True
        '
        'SaveFileButton
        '
        Me.SaveFileButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Actions_document_save_icon_16p
        Me.SaveFileButton.Location = New System.Drawing.Point(135, 6)
        Me.SaveFileButton.Name = "SaveFileButton"
        Me.SaveFileButton.Size = New System.Drawing.Size(35, 25)
        Me.SaveFileButton.TabIndex = 75
        Me.ToolTip1.SetToolTip(Me.SaveFileButton, "Išsaugoti sąskaitų plano duomenis faile")
        Me.SaveFileButton.UseVisualStyleBackColor = True
        '
        'OpenFileAccButton
        '
        Me.OpenFileAccButton.BorderStyleDown = System.Windows.Forms.Border3DStyle.Flat
        Me.OpenFileAccButton.BorderStyleNormal = System.Windows.Forms.Border3DStyle.Flat
        Me.OpenFileAccButton.BorderStyleUp = System.Windows.Forms.Border3DStyle.Flat
        Me.OpenFileAccButton.ButtonStyle = AccControlsWinForms.rsButtonStyle.DropDownWithSep
        Me.OpenFileAccButton.Checked = False
        Me.OpenFileAccButton.DropDownSepWidth = 12
        Me.OpenFileAccButton.FocusRectangle = False
        Me.OpenFileAccButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.folder_open_icon_16p
        Me.OpenFileAccButton.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.OpenFileAccButton.ImagePadding = 2
        Me.OpenFileAccButton.Location = New System.Drawing.Point(94, 6)
        Me.OpenFileAccButton.Name = "OpenFileAccButton"
        Me.OpenFileAccButton.Size = New System.Drawing.Size(35, 25)
        Me.OpenFileAccButton.TabIndex = 74
        Me.OpenFileAccButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.OpenFileAccButton.TextPadding = 2
        Me.ToolTip1.SetToolTip(Me.OpenFileAccButton, "Atidaryti failą su sąskaitų plano duomenimis")
        '
        'PasteAccButton
        '
        Me.PasteAccButton.BorderStyleDown = System.Windows.Forms.Border3DStyle.Flat
        Me.PasteAccButton.BorderStyleNormal = System.Windows.Forms.Border3DStyle.Flat
        Me.PasteAccButton.BorderStyleUp = System.Windows.Forms.Border3DStyle.Flat
        Me.PasteAccButton.ButtonStyle = AccControlsWinForms.rsButtonStyle.DropDownWithSep
        Me.PasteAccButton.Checked = False
        Me.PasteAccButton.DropDownSepWidth = 12
        Me.PasteAccButton.FocusRectangle = False
        Me.PasteAccButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Paste_icon_16p
        Me.PasteAccButton.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.PasteAccButton.ImagePadding = 2
        Me.PasteAccButton.Location = New System.Drawing.Point(53, 6)
        Me.PasteAccButton.Name = "PasteAccButton"
        Me.PasteAccButton.Size = New System.Drawing.Size(35, 25)
        Me.PasteAccButton.TabIndex = 70
        Me.PasteAccButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.PasteAccButton.TextPadding = 2
        Me.ToolTip1.SetToolTip(Me.PasteAccButton, "Paste'inti sąskaitų planą iš clipboard'o")
        '
        'nCancelButton
        '
        Me.nCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nCancelButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nCancelButton.Location = New System.Drawing.Point(674, 11)
        Me.nCancelButton.Name = "nCancelButton"
        Me.nCancelButton.Size = New System.Drawing.Size(78, 25)
        Me.nCancelButton.TabIndex = 68
        Me.nCancelButton.Text = "Atšaukti"
        Me.nCancelButton.UseVisualStyleBackColor = True
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplyButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButton.Location = New System.Drawing.Point(590, 11)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(78, 25)
        Me.ApplyButton.TabIndex = 67
        Me.ApplyButton.Text = "Išsaugoti"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'nOkButton
        '
        Me.nOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nOkButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nOkButton.Location = New System.Drawing.Point(506, 11)
        Me.nOkButton.Name = "nOkButton"
        Me.nOkButton.Size = New System.Drawing.Size(78, 25)
        Me.nOkButton.TabIndex = 66
        Me.nOkButton.Text = "OK"
        Me.nOkButton.UseVisualStyleBackColor = True
        '
        'AccountListBindingSource
        '
        Me.AccountListBindingSource.DataSource = GetType(ApskaitaObjects.General.Account)
        '
        'AccountListDataListView
        '
        Me.AccountListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.AccountListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.AccountListDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.AccountListDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.AccountListDataListView.AllColumns.Add(Me.OlvColumn6)
        Me.AccountListDataListView.AllColumns.Add(Me.OlvColumn5)
        Me.AccountListDataListView.AllowColumnReorder = True
        Me.AccountListDataListView.AutoGenerateColumns = False
        Me.AccountListDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.AccountListDataListView.CellEditEnterChangesRows = True
        Me.AccountListDataListView.CellEditTabChangesRows = True
        Me.AccountListDataListView.CellEditUseWholeCell = False
        Me.AccountListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1, Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn6, Me.OlvColumn5})
        Me.AccountListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.AccountListDataListView.DataSource = Me.AccountListBindingSource
        Me.AccountListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountListDataListView.FullRowSelect = True
        Me.AccountListDataListView.HasCollapsibleGroups = False
        Me.AccountListDataListView.HeaderWordWrap = True
        Me.AccountListDataListView.HideSelection = False
        Me.AccountListDataListView.HighlightBackgroundColor = System.Drawing.Color.PaleGreen
        Me.AccountListDataListView.HighlightForegroundColor = System.Drawing.Color.Black
        Me.AccountListDataListView.IncludeColumnHeadersInCopy = True
        Me.AccountListDataListView.Location = New System.Drawing.Point(0, 0)
        Me.AccountListDataListView.Name = "AccountListDataListView"
        Me.AccountListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.AccountListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.AccountListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.AccountListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.AccountListDataListView.ShowCommandMenuOnRightClick = True
        Me.AccountListDataListView.ShowGroups = False
        Me.AccountListDataListView.ShowImagesOnSubItems = True
        Me.AccountListDataListView.ShowItemCountOnGroups = True
        Me.AccountListDataListView.ShowItemToolTips = True
        Me.AccountListDataListView.Size = New System.Drawing.Size(764, 428)
        Me.AccountListDataListView.TabIndex = 3
        Me.AccountListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.AccountListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.AccountListDataListView.UseCellFormatEvents = True
        Me.AccountListDataListView.UseCompatibleStateImageBehavior = False
        Me.AccountListDataListView.UseFilterIndicator = True
        Me.AccountListDataListView.UseFiltering = True
        Me.AccountListDataListView.UseHotItem = True
        Me.AccountListDataListView.UseNotifyPropertyChanged = True
        Me.AccountListDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "Class"
        Me.OlvColumn1.AutoCompleteEditor = False
        Me.OlvColumn1.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None
        Me.OlvColumn1.CellEditUseWholeCell = True
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.IsEditable = False
        Me.OlvColumn1.Text = "Klasė"
        Me.OlvColumn1.ToolTipText = ""
        Me.OlvColumn1.Width = 48
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "ID"
        Me.OlvColumn2.AspectToStringFormat = "{0:##}"
        Me.OlvColumn2.AutoCompleteEditor = False
        Me.OlvColumn2.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.Groupable = False
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.Hideable = False
        Me.OlvColumn2.Sortable = False
        Me.OlvColumn2.Text = "Sąskaitos Nr."
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 99
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "Name"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.Text = "Sąskaitos pavadinimas"
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 236
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "AssociatedReportItem"
        Me.OlvColumn4.CellEditUseWholeCell = True
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.Text = "Atskaitomybės eil."
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 212
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "SaftCode"
        Me.OlvColumn6.CellEditUseWholeCell = True
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.Text = "SAF-T Kodas"
        Me.OlvColumn6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.Width = 106
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "Comments"
        Me.OlvColumn5.CellEditUseWholeCell = True
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.Text = "Pastabos"
        Me.OlvColumn5.ToolTipText = ""
        Me.OlvColumn5.Width = 84
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(300, 190)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(422, 191)
        Me.ProgressFiller1.TabIndex = 4
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(314, 177)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(422, 191)
        Me.ProgressFiller2.TabIndex = 5
        Me.ProgressFiller2.Visible = False
        '
        'F_AccountList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 467)
        Me.Controls.Add(Me.AccountListDataListView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_AccountList"
        Me.ShowInTaskbar = False
        Me.Text = "Sąskaitų planas"
        Me.Panel2.ResumeLayout(False)
        CType(Me.AccountListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents nCancelButton As System.Windows.Forms.Button
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents nOkButton As System.Windows.Forms.Button
    Friend WithEvents AccountListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PasteAccButton As AccControlsWinForms.AccButton
    Friend WithEvents OpenFileAccButton As AccControlsWinForms.AccButton
    Friend WithEvents SaveFileButton As System.Windows.Forms.Button
    Friend WithEvents CopyToClipboardButton As System.Windows.Forms.Button
    Friend WithEvents AccountListDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn5 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents AddFromTypicalAccountsAccButton As AccControlsWinForms.AccButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents OlvColumn6 As BrightIdeasSoftware.OLVColumn
End Class