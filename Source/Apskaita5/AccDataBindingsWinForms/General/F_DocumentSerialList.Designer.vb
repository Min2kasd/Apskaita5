﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_DocumentSerialList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_DocumentSerialList))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.DocumentSerialListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DocumentSerialListDataListView = New BrightIdeasSoftware.DataListView
        Me.OlvColumn2 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn1 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn3 = New BrightIdeasSoftware.OLVColumn
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.Panel2.SuspendLayout()
        CType(Me.DocumentSerialListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocumentSerialListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 350)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(484, 32)
        Me.Panel2.TabIndex = 53
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(383, 6)
        Me.ICancelButton.Name = "ICancelButton"
        Me.ICancelButton.Size = New System.Drawing.Size(89, 23)
        Me.ICancelButton.TabIndex = 14
        Me.ICancelButton.Text = "Atšaukti"
        Me.ICancelButton.UseVisualStyleBackColor = True
        '
        'IOkButton
        '
        Me.IOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IOkButton.Location = New System.Drawing.Point(177, 6)
        Me.IOkButton.Name = "IOkButton"
        Me.IOkButton.Size = New System.Drawing.Size(89, 23)
        Me.IOkButton.TabIndex = 13
        Me.IOkButton.Text = "Ok"
        Me.IOkButton.UseVisualStyleBackColor = True
        '
        'IApplyButton
        '
        Me.IApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IApplyButton.Location = New System.Drawing.Point(281, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 12
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'DocumentSerialListBindingSource
        '
        Me.DocumentSerialListBindingSource.DataSource = GetType(ApskaitaObjects.Settings.DocumentSerial)
        '
        'DocumentSerialListDataListView
        '
        Me.DocumentSerialListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.DocumentSerialListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.DocumentSerialListDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.DocumentSerialListDataListView.AllowColumnReorder = True
        Me.DocumentSerialListDataListView.AutoGenerateColumns = False
        Me.DocumentSerialListDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.DocumentSerialListDataListView.CellEditEnterChangesRows = True
        Me.DocumentSerialListDataListView.CellEditTabChangesRows = True
        Me.DocumentSerialListDataListView.CellEditUseWholeCell = False
        Me.DocumentSerialListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2, Me.OlvColumn1, Me.OlvColumn3})
        Me.DocumentSerialListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.DocumentSerialListDataListView.DataSource = Me.DocumentSerialListBindingSource
        Me.DocumentSerialListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentSerialListDataListView.FullRowSelect = True
        Me.DocumentSerialListDataListView.HasCollapsibleGroups = False
        Me.DocumentSerialListDataListView.HeaderWordWrap = True
        Me.DocumentSerialListDataListView.HideSelection = False
        Me.DocumentSerialListDataListView.IncludeColumnHeadersInCopy = True
        Me.DocumentSerialListDataListView.Location = New System.Drawing.Point(0, 0)
        Me.DocumentSerialListDataListView.Name = "DocumentSerialListDataListView"
        Me.DocumentSerialListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.DocumentSerialListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.DocumentSerialListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.DocumentSerialListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.DocumentSerialListDataListView.ShowCommandMenuOnRightClick = True
        Me.DocumentSerialListDataListView.ShowGroups = False
        Me.DocumentSerialListDataListView.ShowImagesOnSubItems = True
        Me.DocumentSerialListDataListView.ShowItemCountOnGroups = True
        Me.DocumentSerialListDataListView.ShowItemToolTips = True
        Me.DocumentSerialListDataListView.Size = New System.Drawing.Size(484, 350)
        Me.DocumentSerialListDataListView.TabIndex = 54
        Me.DocumentSerialListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.DocumentSerialListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.DocumentSerialListDataListView.UseCellFormatEvents = True
        Me.DocumentSerialListDataListView.UseCompatibleStateImageBehavior = False
        Me.DocumentSerialListDataListView.UseFilterIndicator = True
        Me.DocumentSerialListDataListView.UseFiltering = True
        Me.DocumentSerialListDataListView.UseHotItem = True
        Me.DocumentSerialListDataListView.UseNotifyPropertyChanged = True
        Me.DocumentSerialListDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "DocumentTypeHumanReadable"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.Text = "Dokumentas"
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 100
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "Serial"
        Me.OlvColumn1.CellEditUseWholeCell = True
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.Text = "Serija"
        Me.OlvColumn1.ToolTipText = ""
        Me.OlvColumn1.Width = 100
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "WasUsed"
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
        Me.ProgressFiller1.Location = New System.Drawing.Point(192, 24)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(422, 191)
        Me.ProgressFiller1.TabIndex = 55
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(150, 101)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(422, 191)
        Me.ProgressFiller2.TabIndex = 56
        Me.ProgressFiller2.Visible = False
        '
        'F_DocumentSerialList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 382)
        Me.Controls.Add(Me.DocumentSerialListDataListView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_DocumentSerialList"
        Me.ShowInTaskbar = False
        Me.Text = "Dokumentų serijos"
        Me.Panel2.ResumeLayout(False)
        CType(Me.DocumentSerialListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocumentSerialListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents DocumentSerialListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DocumentSerialListDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
End Class
