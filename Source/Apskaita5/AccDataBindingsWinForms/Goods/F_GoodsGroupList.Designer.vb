﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_GoodsGroupList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_GoodsGroupList))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.nCancelButton = New System.Windows.Forms.Button
        Me.ApplyButton = New System.Windows.Forms.Button
        Me.nOkButton = New System.Windows.Forms.Button
        Me.GoodsGroupListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GoodsGroupListDataListView = New BrightIdeasSoftware.DataListView
        Me.OlvColumn1 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn2 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn3 = New BrightIdeasSoftware.OLVColumn
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.Panel2.SuspendLayout()
        CType(Me.GoodsGroupListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GoodsGroupListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.Controls.Add(Me.nCancelButton)
        Me.Panel2.Controls.Add(Me.ApplyButton)
        Me.Panel2.Controls.Add(Me.nOkButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 364)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.Panel2.Size = New System.Drawing.Size(447, 37)
        Me.Panel2.TabIndex = 8
        '
        'nCancelButton
        '
        Me.nCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.nCancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nCancelButton.Location = New System.Drawing.Point(360, 7)
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
        Me.ApplyButton.Location = New System.Drawing.Point(279, 7)
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
        Me.nOkButton.Location = New System.Drawing.Point(198, 7)
        Me.nOkButton.Name = "nOkButton"
        Me.nOkButton.Size = New System.Drawing.Size(75, 23)
        Me.nOkButton.TabIndex = 0
        Me.nOkButton.Text = "OK"
        Me.nOkButton.UseVisualStyleBackColor = True
        '
        'GoodsGroupListBindingSource
        '
        Me.GoodsGroupListBindingSource.DataSource = GetType(ApskaitaObjects.Goods.GoodsGroup)
        '
        'GoodsGroupListDataListView
        '
        Me.GoodsGroupListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.GoodsGroupListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.GoodsGroupListDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.GoodsGroupListDataListView.AllowColumnReorder = True
        Me.GoodsGroupListDataListView.AutoGenerateColumns = False
        Me.GoodsGroupListDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.GoodsGroupListDataListView.CellEditEnterChangesRows = True
        Me.GoodsGroupListDataListView.CellEditTabChangesRows = True
        Me.GoodsGroupListDataListView.CellEditUseWholeCell = False
        Me.GoodsGroupListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2, Me.OlvColumn3})
        Me.GoodsGroupListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.GoodsGroupListDataListView.DataSource = Me.GoodsGroupListBindingSource
        Me.GoodsGroupListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GoodsGroupListDataListView.FullRowSelect = True
        Me.GoodsGroupListDataListView.HasCollapsibleGroups = False
        Me.GoodsGroupListDataListView.HeaderWordWrap = True
        Me.GoodsGroupListDataListView.HideSelection = False
        Me.GoodsGroupListDataListView.IncludeColumnHeadersInCopy = True
        Me.GoodsGroupListDataListView.Location = New System.Drawing.Point(0, 0)
        Me.GoodsGroupListDataListView.Name = "GoodsGroupListDataListView"
        Me.GoodsGroupListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.GoodsGroupListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.GoodsGroupListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.GoodsGroupListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.GoodsGroupListDataListView.ShowCommandMenuOnRightClick = True
        Me.GoodsGroupListDataListView.ShowGroups = False
        Me.GoodsGroupListDataListView.ShowImagesOnSubItems = True
        Me.GoodsGroupListDataListView.ShowItemCountOnGroups = True
        Me.GoodsGroupListDataListView.ShowItemToolTips = True
        Me.GoodsGroupListDataListView.Size = New System.Drawing.Size(447, 364)
        Me.GoodsGroupListDataListView.TabIndex = 9
        Me.GoodsGroupListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.GoodsGroupListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.GoodsGroupListDataListView.UseCellFormatEvents = True
        Me.GoodsGroupListDataListView.UseCompatibleStateImageBehavior = False
        Me.GoodsGroupListDataListView.UseFilterIndicator = True
        Me.GoodsGroupListDataListView.UseFiltering = True
        Me.GoodsGroupListDataListView.UseHotItem = True
        Me.GoodsGroupListDataListView.UseNotifyPropertyChanged = True
        Me.GoodsGroupListDataListView.View = System.Windows.Forms.View.Details
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
        Me.OlvColumn2.Width = 341
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "IsInUse"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.CheckBoxes = True
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsEditable = False
        Me.OlvColumn3.Text = "Naudojama"
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 100
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(143, 46)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(164, 43)
        Me.ProgressFiller1.TabIndex = 10
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(142, 106)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(181, 56)
        Me.ProgressFiller2.TabIndex = 11
        Me.ProgressFiller2.Visible = False
        '
        'F_GoodsGroupList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 401)
        Me.Controls.Add(Me.GoodsGroupListDataListView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_GoodsGroupList"
        Me.ShowInTaskbar = False
        Me.Text = "Prekių Grupės"
        Me.Panel2.ResumeLayout(False)
        CType(Me.GoodsGroupListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GoodsGroupListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents nCancelButton As System.Windows.Forms.Button
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents nOkButton As System.Windows.Forms.Button
    Friend WithEvents GoodsGroupListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GoodsGroupListDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
End Class
