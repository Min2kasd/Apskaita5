﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_WarehouseList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_WarehouseList))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.nCancelButton = New System.Windows.Forms.Button
        Me.ApplyButton = New System.Windows.Forms.Button
        Me.nOkButton = New System.Windows.Forms.Button
        Me.WarehouseListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WarehouseListDataListView = New BrightIdeasSoftware.DataListView
        Me.OlvColumn1 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn2 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn3 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn4 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn5 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn6 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn7 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn8 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn9 = New BrightIdeasSoftware.OLVColumn
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.Panel2.SuspendLayout()
        CType(Me.WarehouseListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WarehouseListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.nCancelButton)
        Me.Panel2.Controls.Add(Me.ApplyButton)
        Me.Panel2.Controls.Add(Me.nOkButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 387)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Panel2.Size = New System.Drawing.Size(925, 37)
        Me.Panel2.TabIndex = 7
        '
        'nCancelButton
        '
        Me.nCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.nCancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nCancelButton.Location = New System.Drawing.Point(838, 7)
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
        Me.ApplyButton.Location = New System.Drawing.Point(757, 7)
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
        Me.nOkButton.Location = New System.Drawing.Point(676, 7)
        Me.nOkButton.Name = "nOkButton"
        Me.nOkButton.Size = New System.Drawing.Size(75, 23)
        Me.nOkButton.TabIndex = 0
        Me.nOkButton.Text = "OK"
        Me.nOkButton.UseVisualStyleBackColor = True
        '
        'WarehouseListBindingSource
        '
        Me.WarehouseListBindingSource.DataSource = GetType(ApskaitaObjects.Goods.Warehouse)
        '
        'WarehouseListDataListView
        '
        Me.WarehouseListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.WarehouseListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.WarehouseListDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.WarehouseListDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.WarehouseListDataListView.AllColumns.Add(Me.OlvColumn5)
        Me.WarehouseListDataListView.AllColumns.Add(Me.OlvColumn6)
        Me.WarehouseListDataListView.AllColumns.Add(Me.OlvColumn7)
        Me.WarehouseListDataListView.AllColumns.Add(Me.OlvColumn8)
        Me.WarehouseListDataListView.AllColumns.Add(Me.OlvColumn9)
        Me.WarehouseListDataListView.AllowColumnReorder = True
        Me.WarehouseListDataListView.AutoGenerateColumns = False
        Me.WarehouseListDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.WarehouseListDataListView.CellEditEnterChangesRows = True
        Me.WarehouseListDataListView.CellEditTabChangesRows = True
        Me.WarehouseListDataListView.CellEditUseWholeCell = False
        Me.WarehouseListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn5, Me.OlvColumn6, Me.OlvColumn7, Me.OlvColumn9})
        Me.WarehouseListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.WarehouseListDataListView.DataSource = Me.WarehouseListBindingSource
        Me.WarehouseListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WarehouseListDataListView.FullRowSelect = True
        Me.WarehouseListDataListView.HasCollapsibleGroups = False
        Me.WarehouseListDataListView.HeaderWordWrap = True
        Me.WarehouseListDataListView.HideSelection = False
        Me.WarehouseListDataListView.IncludeColumnHeadersInCopy = True
        Me.WarehouseListDataListView.Location = New System.Drawing.Point(0, 0)
        Me.WarehouseListDataListView.Name = "WarehouseListDataListView"
        Me.WarehouseListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.WarehouseListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.WarehouseListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.WarehouseListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.WarehouseListDataListView.ShowCommandMenuOnRightClick = True
        Me.WarehouseListDataListView.ShowGroups = False
        Me.WarehouseListDataListView.ShowImagesOnSubItems = True
        Me.WarehouseListDataListView.ShowItemCountOnGroups = True
        Me.WarehouseListDataListView.ShowItemToolTips = True
        Me.WarehouseListDataListView.Size = New System.Drawing.Size(925, 387)
        Me.WarehouseListDataListView.TabIndex = 8
        Me.WarehouseListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.WarehouseListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.WarehouseListDataListView.UseCellFormatEvents = True
        Me.WarehouseListDataListView.UseCompatibleStateImageBehavior = False
        Me.WarehouseListDataListView.UseFilterIndicator = True
        Me.WarehouseListDataListView.UseFiltering = True
        Me.WarehouseListDataListView.UseHotItem = True
        Me.WarehouseListDataListView.UseNotifyPropertyChanged = True
        Me.WarehouseListDataListView.View = System.Windows.Forms.View.Details
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
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "Name"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.Text = "Pavadinimas"
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 210
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "Location"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.Text = "Vieta"
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 178
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "Description"
        Me.OlvColumn4.CellEditUseWholeCell = True
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.Text = "Aprašymas"
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 276
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "WarehouseAccount"
        Me.OlvColumn5.CellEditUseWholeCell = True
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.Text = "Apskaitos Sąsk."
        Me.OlvColumn5.ToolTipText = ""
        Me.OlvColumn5.Width = 100
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "IsProduction"
        Me.OlvColumn6.CellEditUseWholeCell = True
        Me.OlvColumn6.CheckBoxes = True
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.Text = "Gamyba"
        Me.OlvColumn6.ToolTipText = ""
        Me.OlvColumn6.Width = 52
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "IsObsolete"
        Me.OlvColumn7.CellEditUseWholeCell = True
        Me.OlvColumn7.CheckBoxes = True
        Me.OlvColumn7.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.Text = "Nebenaudojama"
        Me.OlvColumn7.ToolTipText = ""
        Me.OlvColumn7.Width = 50
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "LastOperationDate"
        Me.OlvColumn8.AspectToStringFormat = "{0:d}"
        Me.OlvColumn8.CellEditUseWholeCell = True
        Me.OlvColumn8.DisplayIndex = 7
        Me.OlvColumn8.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.IsEditable = False
        Me.OlvColumn8.IsVisible = False
        Me.OlvColumn8.Text = "Paskutinės Op. Data"
        Me.OlvColumn8.ToolTipText = ""
        Me.OlvColumn8.Width = 100
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "ContainsGoods"
        Me.OlvColumn9.CellEditUseWholeCell = True
        Me.OlvColumn9.CheckBoxes = True
        Me.OlvColumn9.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.IsEditable = False
        Me.OlvColumn9.Text = "Yra Prekių"
        Me.OlvColumn9.ToolTipText = ""
        Me.OlvColumn9.Width = 53
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(149, 15)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(169, 62)
        Me.ProgressFiller1.TabIndex = 9
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(338, 11)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(236, 65)
        Me.ProgressFiller2.TabIndex = 10
        Me.ProgressFiller2.Visible = False
        '
        'F_WarehouseList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 424)
        Me.Controls.Add(Me.WarehouseListDataListView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_WarehouseList"
        Me.ShowInTaskbar = False
        Me.Text = "Sandėliai"
        Me.Panel2.ResumeLayout(False)
        CType(Me.WarehouseListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WarehouseListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents nCancelButton As System.Windows.Forms.Button
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents nOkButton As System.Windows.Forms.Button
    Friend WithEvents WarehouseListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents WarehouseListDataListView As BrightIdeasSoftware.DataListView
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
End Class
