﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_ImportedGoodsItemList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_ImportedGoodsItemList))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PasteButton = New System.Windows.Forms.Button()
        Me.OpenFileButton = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ApplyButton = New System.Windows.Forms.Button()
        Me.ImportedGoodsItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ImportedGoodsItemListDataListView = New BrightIdeasSoftware.DataListView()
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn5 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn6 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn7 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn8 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn9 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn10 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn11 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn12 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn13 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn14 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn15 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn16 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn17 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn18 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller()
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller()
        Me.nOkButton = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ImportedGoodsItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImportedGoodsItemListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.PasteButton)
        Me.Panel1.Controls.Add(Me.OpenFileButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Panel1.Size = New System.Drawing.Size(873, 45)
        Me.Panel1.TabIndex = 2
        '
        'PasteButton
        '
        Me.PasteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PasteButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Paste_icon_24p
        Me.PasteButton.Location = New System.Drawing.Point(780, 9)
        Me.PasteButton.Name = "PasteButton"
        Me.PasteButton.Size = New System.Drawing.Size(35, 30)
        Me.PasteButton.TabIndex = 8
        Me.PasteButton.UseVisualStyleBackColor = True
        '
        'OpenFileButton
        '
        Me.OpenFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenFileButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.folder_open_icon_24p
        Me.OpenFileButton.Location = New System.Drawing.Point(831, 9)
        Me.OpenFileButton.Name = "OpenFileButton"
        Me.OpenFileButton.Size = New System.Drawing.Size(30, 30)
        Me.OpenFileButton.TabIndex = 5
        Me.OpenFileButton.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.ApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 496)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(873, 39)
        Me.Panel2.TabIndex = 4
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplyButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplyButton.Location = New System.Drawing.Point(755, 11)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(106, 25)
        Me.ApplyButton.TabIndex = 67
        Me.ApplyButton.Text = "Importuoti"
        Me.ApplyButton.UseVisualStyleBackColor = True
        '
        'ImportedGoodsItemListBindingSource
        '
        Me.ImportedGoodsItemListBindingSource.DataSource = GetType(ApskaitaObjects.Goods.ImportedGoodsItem)
        '
        'ImportedGoodsItemListDataListView
        '
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn5)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn6)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn7)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn8)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn9)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn10)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn11)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn12)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn13)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn14)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn15)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn16)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn17)
        Me.ImportedGoodsItemListDataListView.AllColumns.Add(Me.OlvColumn18)
        Me.ImportedGoodsItemListDataListView.AllowColumnReorder = True
        Me.ImportedGoodsItemListDataListView.AutoGenerateColumns = False
        Me.ImportedGoodsItemListDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.ImportedGoodsItemListDataListView.CellEditEnterChangesRows = True
        Me.ImportedGoodsItemListDataListView.CellEditTabChangesRows = True
        Me.ImportedGoodsItemListDataListView.CellEditUseWholeCell = False
        Me.ImportedGoodsItemListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1, Me.OlvColumn2, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn5, Me.OlvColumn6, Me.OlvColumn7, Me.OlvColumn8, Me.OlvColumn9, Me.OlvColumn10, Me.OlvColumn11, Me.OlvColumn12, Me.OlvColumn13, Me.OlvColumn14, Me.OlvColumn15, Me.OlvColumn16, Me.OlvColumn17, Me.OlvColumn18})
        Me.ImportedGoodsItemListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.ImportedGoodsItemListDataListView.DataSource = Me.ImportedGoodsItemListBindingSource
        Me.ImportedGoodsItemListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImportedGoodsItemListDataListView.FullRowSelect = True
        Me.ImportedGoodsItemListDataListView.HasCollapsibleGroups = False
        Me.ImportedGoodsItemListDataListView.HeaderWordWrap = True
        Me.ImportedGoodsItemListDataListView.HideSelection = False
        Me.ImportedGoodsItemListDataListView.HighlightBackgroundColor = System.Drawing.Color.PaleGreen
        Me.ImportedGoodsItemListDataListView.HighlightForegroundColor = System.Drawing.Color.Black
        Me.ImportedGoodsItemListDataListView.IncludeColumnHeadersInCopy = True
        Me.ImportedGoodsItemListDataListView.Location = New System.Drawing.Point(0, 45)
        Me.ImportedGoodsItemListDataListView.Name = "ImportedGoodsItemListDataListView"
        Me.ImportedGoodsItemListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.ImportedGoodsItemListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.ImportedGoodsItemListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.ImportedGoodsItemListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.ImportedGoodsItemListDataListView.ShowCommandMenuOnRightClick = True
        Me.ImportedGoodsItemListDataListView.ShowGroups = False
        Me.ImportedGoodsItemListDataListView.ShowImagesOnSubItems = True
        Me.ImportedGoodsItemListDataListView.ShowItemCountOnGroups = True
        Me.ImportedGoodsItemListDataListView.ShowItemToolTips = True
        Me.ImportedGoodsItemListDataListView.Size = New System.Drawing.Size(873, 451)
        Me.ImportedGoodsItemListDataListView.TabIndex = 5
        Me.ImportedGoodsItemListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.ImportedGoodsItemListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.ImportedGoodsItemListDataListView.UseCellFormatEvents = True
        Me.ImportedGoodsItemListDataListView.UseCompatibleStateImageBehavior = False
        Me.ImportedGoodsItemListDataListView.UseFilterIndicator = True
        Me.ImportedGoodsItemListDataListView.UseFiltering = True
        Me.ImportedGoodsItemListDataListView.UseHotItem = True
        Me.ImportedGoodsItemListDataListView.UseNotifyPropertyChanged = True
        Me.ImportedGoodsItemListDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "Name"
        Me.OlvColumn1.CellEditUseWholeCell = True
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.IsEditable = False
        Me.OlvColumn1.Text = "Pavadinimas"
        Me.OlvColumn1.ToolTipText = "Prekės pavadinimas"
        Me.OlvColumn1.Width = 254
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "MeasureUnit"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.IsEditable = False
        Me.OlvColumn2.Text = "Mato Vnt."
        Me.OlvColumn2.ToolTipText = "Mato Vnt."
        Me.OlvColumn2.Width = 63
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "InternalCode"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsEditable = False
        Me.OlvColumn3.Text = "Vidinis Kodas"
        Me.OlvColumn3.ToolTipText = "Vidinis Kodas"
        Me.OlvColumn3.Width = 80
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "Barcode"
        Me.OlvColumn4.CellEditUseWholeCell = True
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.IsEditable = False
        Me.OlvColumn4.Text = "Barkodas"
        Me.OlvColumn4.ToolTipText = "Barkodas"
        Me.OlvColumn4.Width = 100
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "GroupInfo"
        Me.OlvColumn5.CellEditUseWholeCell = True
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.IsEditable = False
        Me.OlvColumn5.Text = "Grupė"
        Me.OlvColumn5.ToolTipText = "Prekių grupė"
        Me.OlvColumn5.Width = 199
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "TypeHumanReadable"
        Me.OlvColumn6.CellEditUseWholeCell = True
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.IsEditable = False
        Me.OlvColumn6.Text = "Prekybos Tipas"
        Me.OlvColumn6.ToolTipText = "Prekės funkcijos sąskaitose faktūrose (0 - perkamos, 1 - parduodamos, 2 - perkamo" &
    "s ir parduodamos)"
        Me.OlvColumn6.Width = 124
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "ContentInvoice"
        Me.OlvColumn7.CellEditUseWholeCell = True
        Me.OlvColumn7.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.IsEditable = False
        Me.OlvColumn7.Text = "Pavadinimas Sąskaitoje"
        Me.OlvColumn7.ToolTipText = "Prekės pavadinimas išrašomos sąskaitos faktūros eilutėje"
        Me.OlvColumn7.Width = 100
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "DefaultAccountingMethodHumanReadable"
        Me.OlvColumn8.CellEditUseWholeCell = True
        Me.OlvColumn8.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.IsEditable = False
        Me.OlvColumn8.Text = "Apskaitos Metodas"
        Me.OlvColumn8.ToolTipText = "Apskaitos metodas (0 - nuolat, 1 periodiškai)"
        Me.OlvColumn8.Width = 100
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "DefaultValuationMethodHumanReadable"
        Me.OlvColumn9.CellEditUseWholeCell = True
        Me.OlvColumn9.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.IsEditable = False
        Me.OlvColumn9.Text = "Vertinimo Metodas"
        Me.OlvColumn9.ToolTipText = "Vertinimo metodas (0 - FIFO, 1 - LIFO, 2 - vidurkių)"
        Me.OlvColumn9.Width = 100
        '
        'OlvColumn10
        '
        Me.OlvColumn10.AspectName = "AccountSalesNetCosts"
        Me.OlvColumn10.CellEditUseWholeCell = True
        Me.OlvColumn10.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn10.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn10.IsEditable = False
        Me.OlvColumn10.Text = "Pardavimo savik. sąsk."
        Me.OlvColumn10.ToolTipText = "Pardavimo savik. sąsk."
        Me.OlvColumn10.Width = 100
        '
        'OlvColumn11
        '
        Me.OlvColumn11.AspectName = "AccountPurchases"
        Me.OlvColumn11.CellEditUseWholeCell = True
        Me.OlvColumn11.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn11.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn11.IsEditable = False
        Me.OlvColumn11.Text = "Pirkimų Sąsk."
        Me.OlvColumn11.ToolTipText = "Pirkimų Sąsk."
        Me.OlvColumn11.Width = 100
        '
        'OlvColumn12
        '
        Me.OlvColumn12.AspectName = "AccountDiscounts"
        Me.OlvColumn12.CellEditUseWholeCell = True
        Me.OlvColumn12.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn12.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn12.IsEditable = False
        Me.OlvColumn12.Text = "Nuolaidų sąsk."
        Me.OlvColumn12.ToolTipText = "Nuolaidų sąsk."
        Me.OlvColumn12.Width = 100
        '
        'OlvColumn13
        '
        Me.OlvColumn13.AspectName = "AccountValueReduction"
        Me.OlvColumn13.CellEditUseWholeCell = True
        Me.OlvColumn13.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn13.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn13.IsEditable = False
        Me.OlvColumn13.Text = "Nukainojimo Sąsk."
        Me.OlvColumn13.ToolTipText = "Nukainojimo Sąsk."
        Me.OlvColumn13.Width = 100
        '
        'OlvColumn14
        '
        Me.OlvColumn14.AspectName = "DefaultVatRateSales"
        Me.OlvColumn14.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn14.CellEditUseWholeCell = True
        Me.OlvColumn14.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn14.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn14.IsEditable = False
        Me.OlvColumn14.Text = "Pardavimo PVM"
        Me.OlvColumn14.ToolTipText = "Pardavimo PVM tarifas"
        Me.OlvColumn14.Width = 100
        '
        'OlvColumn15
        '
        Me.OlvColumn15.AspectName = "DefaultVatRatePurchase"
        Me.OlvColumn15.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn15.CellEditUseWholeCell = True
        Me.OlvColumn15.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn15.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn15.IsEditable = False
        Me.OlvColumn15.Text = "Pirkimo PVM"
        Me.OlvColumn15.ToolTipText = "Pirkimo PVM tarifas"
        Me.OlvColumn15.Width = 100
        '
        'OlvColumn16
        '
        Me.OlvColumn16.AspectName = "ValuePerUnitSales"
        Me.OlvColumn16.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn16.CellEditUseWholeCell = True
        Me.OlvColumn16.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn16.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn16.IsEditable = False
        Me.OlvColumn16.Text = "Vnt. Kaina Pardavimams"
        Me.OlvColumn16.ToolTipText = "Vnt. kaina išrašomose sąskaitose faktūrose bazine valiuta pgl. nutylėjimą"
        Me.OlvColumn16.Width = 100
        '
        'OlvColumn17
        '
        Me.OlvColumn17.AspectName = "ValuePerUnitPurchases"
        Me.OlvColumn17.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn17.CellEditUseWholeCell = True
        Me.OlvColumn17.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn17.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn17.IsEditable = False
        Me.OlvColumn17.Text = "Vnt. Kaina Pirkimams"
        Me.OlvColumn17.ToolTipText = "Vnt. kaina gaunamose sąskaitose faktūrose bazine valiuta pgl. nutylėjimą"
        Me.OlvColumn17.Width = 100
        '
        'OlvColumn18
        '
        Me.OlvColumn18.AspectName = "IsObsolete"
        Me.OlvColumn18.CellEditUseWholeCell = True
        Me.OlvColumn18.CheckBoxes = True
        Me.OlvColumn18.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn18.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn18.IsEditable = False
        Me.OlvColumn18.IsHeaderVertical = True
        Me.OlvColumn18.Text = "Istoriniai"
        Me.OlvColumn18.ToolTipText = "Istoriniai duomenys"
        Me.OlvColumn18.Width = 100
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(165, 74)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(186, 74)
        Me.ProgressFiller1.TabIndex = 6
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(370, 68)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(200, 79)
        Me.ProgressFiller2.TabIndex = 7
        Me.ProgressFiller2.Visible = False
        '
        'nOkButton
        '
        Me.nOkButton.Location = New System.Drawing.Point(626, 85)
        Me.nOkButton.Name = "nOkButton"
        Me.nOkButton.Size = New System.Drawing.Size(75, 23)
        Me.nOkButton.TabIndex = 8
        Me.nOkButton.Text = "Ok"
        Me.nOkButton.UseVisualStyleBackColor = True
        Me.nOkButton.Visible = False
        '
        'F_ImportedGoodsItemList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 535)
        Me.Controls.Add(Me.ImportedGoodsItemListDataListView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.nOkButton)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_ImportedGoodsItemList"
        Me.ShowInTaskbar = False
        Me.Text = "Prekių duomenų importas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.ImportedGoodsItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImportedGoodsItemListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PasteButton As System.Windows.Forms.Button
    Friend WithEvents OpenFileButton As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents ImportedGoodsItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ImportedGoodsItemListDataListView As BrightIdeasSoftware.DataListView
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
    Friend WithEvents OlvColumn14 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn15 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn16 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn17 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn18 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents nOkButton As System.Windows.Forms.Button
End Class
