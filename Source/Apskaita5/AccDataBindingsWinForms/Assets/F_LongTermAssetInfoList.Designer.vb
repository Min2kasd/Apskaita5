﻿Imports ApskaitaObjects.ActiveReports

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_LongTermAssetInfoList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_LongTermAssetInfoList))
        Me.LongTermAssetCustomGroupInfoComboBox = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.RefreshButton = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.LongTermAssetInfoListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.DateFromAccDatePicker = New AccControlsWinForms.AccDatePicker
        Me.DateToAccDatePicker = New AccControlsWinForms.AccDatePicker
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChangeItem_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteItem_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewItem_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ItemDetails_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.NewOperation_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BeginExploitation_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EndExploitation_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Amortization_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AmortizationPeriodChange_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Discard_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Transfer_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AcquisitionValueIncrease_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ValueChange_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AccountChange_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AcquisitionAccount_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AcquisitionAmortizationAccount_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ValueDecreaseAccount_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ValueIncreaseAccount_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ValueIncreaseAmortizationAccount_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LongTermAssetInfoListDataListView = New BrightIdeasSoftware.DataListView
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
        Me.OlvColumn11 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn12 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn13 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn14 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn15 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn16 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn17 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn18 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn19 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn20 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn21 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn22 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn23 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn24 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn25 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn26 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn27 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn28 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn29 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn30 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn31 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn32 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn33 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn34 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn35 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn36 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn37 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn38 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn39 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn40 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn41 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn42 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn43 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn44 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn45 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn46 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn47 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn48 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn49 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn50 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn51 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn52 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn53 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn54 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn55 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn56 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn57 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn58 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn59 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn60 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn61 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn62 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn63 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn64 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn65 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn66 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn67 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn68 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn69 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn70 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn71 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn72 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn73 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn74 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn75 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn76 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn77 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn78 = New BrightIdeasSoftware.OLVColumn
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        CType(Me.LongTermAssetInfoListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.LongTermAssetInfoListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LongTermAssetCustomGroupInfoComboBox
        '
        Me.LongTermAssetCustomGroupInfoComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LongTermAssetCustomGroupInfoComboBox.FormattingEnabled = True
        Me.LongTermAssetCustomGroupInfoComboBox.Location = New System.Drawing.Point(95, 3)
        Me.LongTermAssetCustomGroupInfoComboBox.Name = "LongTermAssetCustomGroupInfoComboBox"
        Me.LongTermAssetCustomGroupInfoComboBox.Size = New System.Drawing.Size(308, 21)
        Me.LongTermAssetCustomGroupInfoComboBox.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Grupės filtras:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(646, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Iki:"
        '
        'RefreshButton
        '
        Me.RefreshButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RefreshButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Button_Reload_icon_24p
        Me.RefreshButton.Location = New System.Drawing.Point(851, 0)
        Me.RefreshButton.Margin = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(35, 32)
        Me.RefreshButton.TabIndex = 3
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(429, 6)
        Me.Label10.Margin = New System.Windows.Forms.Padding(3, 6, 3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 78
        Me.Label10.Text = "Nuo:"
        '
        'LongTermAssetInfoListBindingSource
        '
        Me.LongTermAssetInfoListBindingSource.DataSource = GetType(ApskaitaObjects.ActiveReports.LongTermAssetInfo)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 11
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.RefreshButton, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LongTermAssetCustomGroupInfoComboBox, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DateFromAccDatePicker, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DateToAccDatePicker, 7, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(908, 35)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'DateFromAccDatePicker
        '
        Me.DateFromAccDatePicker.BoldedDates = Nothing
        Me.DateFromAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateFromAccDatePicker.Location = New System.Drawing.Point(469, 3)
        Me.DateFromAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateFromAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateFromAccDatePicker.Name = "DateFromAccDatePicker"
        Me.DateFromAccDatePicker.ReadOnly = False
        Me.DateFromAccDatePicker.ShowWeekNumbers = True
        Me.DateFromAccDatePicker.Size = New System.Drawing.Size(151, 29)
        Me.DateFromAccDatePicker.TabIndex = 1
        '
        'DateToAccDatePicker
        '
        Me.DateToAccDatePicker.BoldedDates = Nothing
        Me.DateToAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateToAccDatePicker.Location = New System.Drawing.Point(677, 3)
        Me.DateToAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateToAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateToAccDatePicker.Name = "DateToAccDatePicker"
        Me.DateToAccDatePicker.ReadOnly = False
        Me.DateToAccDatePicker.ShowWeekNumbers = True
        Me.DateToAccDatePicker.Size = New System.Drawing.Size(151, 29)
        Me.DateToAccDatePicker.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeItem_MenuItem, Me.DeleteItem_MenuItem, Me.NewItem_MenuItem, Me.ToolStripSeparator1, Me.ItemDetails_MenuItem, Me.ToolStripSeparator2, Me.NewOperation_MenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(187, 126)
        '
        'ChangeItem_MenuItem
        '
        Me.ChangeItem_MenuItem.Name = "ChangeItem_MenuItem"
        Me.ChangeItem_MenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ChangeItem_MenuItem.Text = "Keisti"
        '
        'DeleteItem_MenuItem
        '
        Me.DeleteItem_MenuItem.Name = "DeleteItem_MenuItem"
        Me.DeleteItem_MenuItem.Size = New System.Drawing.Size(186, 22)
        Me.DeleteItem_MenuItem.Text = "Ištrinti"
        '
        'NewItem_MenuItem
        '
        Me.NewItem_MenuItem.Name = "NewItem_MenuItem"
        Me.NewItem_MenuItem.Size = New System.Drawing.Size(186, 22)
        Me.NewItem_MenuItem.Text = "Naujas"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(183, 6)
        '
        'ItemDetails_MenuItem
        '
        Me.ItemDetails_MenuItem.Name = "ItemDetails_MenuItem"
        Me.ItemDetails_MenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ItemDetails_MenuItem.Text = "Operacijos su IT"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(183, 6)
        '
        'NewOperation_MenuItem
        '
        Me.NewOperation_MenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeginExploitation_MenuItem, Me.EndExploitation_MenuItem, Me.Amortization_MenuItem, Me.AmortizationPeriodChange_MenuItem, Me.Discard_MenuItem, Me.Transfer_MenuItem, Me.AcquisitionValueIncrease_MenuItem, Me.ValueChange_MenuItem, Me.AccountChange_MenuItem})
        Me.NewOperation_MenuItem.Name = "NewOperation_MenuItem"
        Me.NewOperation_MenuItem.Size = New System.Drawing.Size(186, 22)
        Me.NewOperation_MenuItem.Text = "Nauja Operacija su IT"
        '
        'BeginExploitation_MenuItem
        '
        Me.BeginExploitation_MenuItem.Name = "BeginExploitation_MenuItem"
        Me.BeginExploitation_MenuItem.Size = New System.Drawing.Size(311, 22)
        Me.BeginExploitation_MenuItem.Text = "Perdavimas į eksploataciją"
        '
        'EndExploitation_MenuItem
        '
        Me.EndExploitation_MenuItem.Name = "EndExploitation_MenuItem"
        Me.EndExploitation_MenuItem.Size = New System.Drawing.Size(311, 22)
        Me.EndExploitation_MenuItem.Text = "Išėmimas iš eksploatacijos"
        '
        'Amortization_MenuItem
        '
        Me.Amortization_MenuItem.Name = "Amortization_MenuItem"
        Me.Amortization_MenuItem.Size = New System.Drawing.Size(311, 22)
        Me.Amortization_MenuItem.Text = "Amortizacija"
        '
        'AmortizationPeriodChange_MenuItem
        '
        Me.AmortizationPeriodChange_MenuItem.Name = "AmortizationPeriodChange_MenuItem"
        Me.AmortizationPeriodChange_MenuItem.Size = New System.Drawing.Size(311, 22)
        Me.AmortizationPeriodChange_MenuItem.Text = "Amortizacijos laikotarpio pakeitimas"
        '
        'Discard_MenuItem
        '
        Me.Discard_MenuItem.Name = "Discard_MenuItem"
        Me.Discard_MenuItem.Size = New System.Drawing.Size(311, 22)
        Me.Discard_MenuItem.Text = "Nurašymas"
        '
        'Transfer_MenuItem
        '
        Me.Transfer_MenuItem.Name = "Transfer_MenuItem"
        Me.Transfer_MenuItem.Size = New System.Drawing.Size(311, 22)
        Me.Transfer_MenuItem.Text = "Nefaktūrinis perleidimas"
        '
        'AcquisitionValueIncrease_MenuItem
        '
        Me.AcquisitionValueIncrease_MenuItem.Name = "AcquisitionValueIncrease_MenuItem"
        Me.AcquisitionValueIncrease_MenuItem.Size = New System.Drawing.Size(311, 22)
        Me.AcquisitionValueIncrease_MenuItem.Text = "Nefaktūrinis įsigijimo savikainos padidinimas"
        '
        'ValueChange_MenuItem
        '
        Me.ValueChange_MenuItem.Name = "ValueChange_MenuItem"
        Me.ValueChange_MenuItem.Size = New System.Drawing.Size(311, 22)
        Me.ValueChange_MenuItem.Text = "Įvertinimas rinkos verte"
        '
        'AccountChange_MenuItem
        '
        Me.AccountChange_MenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AcquisitionAccount_MenuItem, Me.AcquisitionAmortizationAccount_MenuItem, Me.ValueDecreaseAccount_MenuItem, Me.ValueIncreaseAccount_MenuItem, Me.ValueIncreaseAmortizationAccount_MenuItem})
        Me.AccountChange_MenuItem.Name = "AccountChange_MenuItem"
        Me.AccountChange_MenuItem.Size = New System.Drawing.Size(311, 22)
        Me.AccountChange_MenuItem.Text = "Apskaitos sąskaitos pakeitimas"
        '
        'AcquisitionAccount_MenuItem
        '
        Me.AcquisitionAccount_MenuItem.Name = "AcquisitionAccount_MenuItem"
        Me.AcquisitionAccount_MenuItem.Size = New System.Drawing.Size(217, 22)
        Me.AcquisitionAccount_MenuItem.Text = "Įsigijimo savikainos"
        '
        'AcquisitionAmortizationAccount_MenuItem
        '
        Me.AcquisitionAmortizationAccount_MenuItem.Name = "AcquisitionAmortizationAccount_MenuItem"
        Me.AcquisitionAmortizationAccount_MenuItem.Size = New System.Drawing.Size(217, 22)
        Me.AcquisitionAmortizationAccount_MenuItem.Text = "Savikainos amortizacijos"
        '
        'ValueDecreaseAccount_MenuItem
        '
        Me.ValueDecreaseAccount_MenuItem.Name = "ValueDecreaseAccount_MenuItem"
        Me.ValueDecreaseAccount_MenuItem.Size = New System.Drawing.Size(217, 22)
        Me.ValueDecreaseAccount_MenuItem.Text = "Vertės sumažėjimo"
        '
        'ValueIncreaseAccount_MenuItem
        '
        Me.ValueIncreaseAccount_MenuItem.Name = "ValueIncreaseAccount_MenuItem"
        Me.ValueIncreaseAccount_MenuItem.Size = New System.Drawing.Size(217, 22)
        Me.ValueIncreaseAccount_MenuItem.Text = "Perkainojimo"
        '
        'ValueIncreaseAmortizationAccount_MenuItem
        '
        Me.ValueIncreaseAmortizationAccount_MenuItem.Name = "ValueIncreaseAmortizationAccount_MenuItem"
        Me.ValueIncreaseAmortizationAccount_MenuItem.Size = New System.Drawing.Size(217, 22)
        Me.ValueIncreaseAmortizationAccount_MenuItem.Text = "Perkainojimo amortizacijos"
        '
        'LongTermAssetInfoListDataListView
        '
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn5)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn6)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn7)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn8)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn9)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn10)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn11)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn12)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn13)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn14)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn15)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn16)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn17)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn18)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn19)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn20)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn21)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn22)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn23)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn24)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn25)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn26)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn27)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn28)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn29)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn30)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn31)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn32)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn33)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn34)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn35)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn36)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn37)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn38)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn39)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn40)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn41)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn42)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn43)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn44)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn45)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn46)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn47)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn48)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn49)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn50)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn51)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn52)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn53)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn54)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn55)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn56)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn57)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn58)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn59)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn60)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn61)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn62)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn63)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn64)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn65)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn66)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn67)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn68)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn69)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn70)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn71)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn72)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn73)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn74)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn75)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn76)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn77)
        Me.LongTermAssetInfoListDataListView.AllColumns.Add(Me.OlvColumn78)
        Me.LongTermAssetInfoListDataListView.AllowColumnReorder = True
        Me.LongTermAssetInfoListDataListView.AutoGenerateColumns = False
        Me.LongTermAssetInfoListDataListView.CausesValidation = False
        Me.LongTermAssetInfoListDataListView.CellEditUseWholeCell = False
        Me.LongTermAssetInfoListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2, Me.OlvColumn6, Me.OlvColumn8, Me.OlvColumn10, Me.OlvColumn11, Me.OlvColumn12, Me.OlvColumn13, Me.OlvColumn14, Me.OlvColumn15, Me.OlvColumn16, Me.OlvColumn18, Me.OlvColumn19, Me.OlvColumn21, Me.OlvColumn23, Me.OlvColumn25, Me.OlvColumn27, Me.OlvColumn29, Me.OlvColumn30, Me.OlvColumn31, Me.OlvColumn34, Me.OlvColumn36, Me.OlvColumn38, Me.OlvColumn40, Me.OlvColumn42, Me.OlvColumn44, Me.OlvColumn45, Me.OlvColumn46, Me.OlvColumn47, Me.OlvColumn49, Me.OlvColumn51, Me.OlvColumn53, Me.OlvColumn55, Me.OlvColumn57, Me.OlvColumn58, Me.OlvColumn59, Me.OlvColumn60, Me.OlvColumn61, Me.OlvColumn62, Me.OlvColumn63, Me.OlvColumn64, Me.OlvColumn65, Me.OlvColumn66, Me.OlvColumn68, Me.OlvColumn70, Me.OlvColumn72, Me.OlvColumn74, Me.OlvColumn76, Me.OlvColumn77, Me.OlvColumn78})
        Me.LongTermAssetInfoListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.LongTermAssetInfoListDataListView.DataSource = Me.LongTermAssetInfoListBindingSource
        Me.LongTermAssetInfoListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LongTermAssetInfoListDataListView.FullRowSelect = True
        Me.LongTermAssetInfoListDataListView.HasCollapsibleGroups = False
        Me.LongTermAssetInfoListDataListView.HeaderWordWrap = True
        Me.LongTermAssetInfoListDataListView.HideSelection = False
        Me.LongTermAssetInfoListDataListView.IncludeColumnHeadersInCopy = True
        Me.LongTermAssetInfoListDataListView.Location = New System.Drawing.Point(0, 35)
        Me.LongTermAssetInfoListDataListView.Name = "LongTermAssetInfoListDataListView"
        Me.LongTermAssetInfoListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.LongTermAssetInfoListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.LongTermAssetInfoListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.LongTermAssetInfoListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.LongTermAssetInfoListDataListView.ShowCommandMenuOnRightClick = True
        Me.LongTermAssetInfoListDataListView.ShowGroups = False
        Me.LongTermAssetInfoListDataListView.ShowImagesOnSubItems = True
        Me.LongTermAssetInfoListDataListView.ShowItemCountOnGroups = True
        Me.LongTermAssetInfoListDataListView.ShowItemToolTips = True
        Me.LongTermAssetInfoListDataListView.Size = New System.Drawing.Size(908, 370)
        Me.LongTermAssetInfoListDataListView.TabIndex = 4
        Me.LongTermAssetInfoListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.LongTermAssetInfoListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.LongTermAssetInfoListDataListView.UseCellFormatEvents = True
        Me.LongTermAssetInfoListDataListView.UseCompatibleStateImageBehavior = False
        Me.LongTermAssetInfoListDataListView.UseFilterIndicator = True
        Me.LongTermAssetInfoListDataListView.UseFiltering = True
        Me.LongTermAssetInfoListDataListView.UseHotItem = True
        Me.LongTermAssetInfoListDataListView.UseNotifyPropertyChanged = True
        Me.LongTermAssetInfoListDataListView.View = System.Windows.Forms.View.Details
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
        Me.OlvColumn2.Width = 248
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
        Me.OlvColumn3.AspectName = "MeasureUnit"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.DisplayIndex = 2
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsEditable = False
        Me.OlvColumn3.IsVisible = False
        Me.OlvColumn3.Text = "Mato vnt."
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 100
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "LegalGroup"
        Me.OlvColumn4.CellEditUseWholeCell = True
        Me.OlvColumn4.DisplayIndex = 3
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.IsEditable = False
        Me.OlvColumn4.IsVisible = False
        Me.OlvColumn4.Text = "PMĮ grupė"
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 100
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "CustomGroup"
        Me.OlvColumn5.CellEditUseWholeCell = True
        Me.OlvColumn5.DisplayIndex = 4
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.IsEditable = False
        Me.OlvColumn5.IsVisible = False
        Me.OlvColumn5.Text = "Grupė"
        Me.OlvColumn5.ToolTipText = ""
        Me.OlvColumn5.Width = 100
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "AcquisitionDate"
        Me.OlvColumn6.AspectToStringFormat = "{0:d}"
        Me.OlvColumn6.CellEditUseWholeCell = True
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.IsEditable = False
        Me.OlvColumn6.Text = "Įsigijimo data"
        Me.OlvColumn6.ToolTipText = ""
        Me.OlvColumn6.Width = 82
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "AcquisitionJournalEntryID"
        Me.OlvColumn7.CellEditUseWholeCell = True
        Me.OlvColumn7.DisplayIndex = 6
        Me.OlvColumn7.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.IsEditable = False
        Me.OlvColumn7.IsVisible = False
        Me.OlvColumn7.Text = "Įsigijimo BŽ ID"
        Me.OlvColumn7.ToolTipText = ""
        Me.OlvColumn7.Width = 100
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "AcquisitionJournalEntryDocNumber"
        Me.OlvColumn8.CellEditUseWholeCell = True
        Me.OlvColumn8.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.IsEditable = False
        Me.OlvColumn8.Text = "Įsigijimo dok. nr."
        Me.OlvColumn8.ToolTipText = ""
        Me.OlvColumn8.Width = 83
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "AcquisitionJournalEntryDocContent"
        Me.OlvColumn9.CellEditUseWholeCell = True
        Me.OlvColumn9.DisplayIndex = 8
        Me.OlvColumn9.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.IsEditable = False
        Me.OlvColumn9.IsVisible = False
        Me.OlvColumn9.Text = "Įsigijimo dok. turinys"
        Me.OlvColumn9.ToolTipText = ""
        Me.OlvColumn9.Width = 100
        '
        'OlvColumn10
        '
        Me.OlvColumn10.AspectName = "InventoryNumber"
        Me.OlvColumn10.CellEditUseWholeCell = True
        Me.OlvColumn10.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn10.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn10.IsEditable = False
        Me.OlvColumn10.Text = "Invent. Nr."
        Me.OlvColumn10.ToolTipText = ""
        Me.OlvColumn10.Width = 83
        '
        'OlvColumn11
        '
        Me.OlvColumn11.AspectName = "AccountAcquisition"
        Me.OlvColumn11.CellEditUseWholeCell = True
        Me.OlvColumn11.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn11.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn11.IsEditable = False
        Me.OlvColumn11.Text = "Savik. sąsk."
        Me.OlvColumn11.ToolTipText = ""
        Me.OlvColumn11.Width = 89
        '
        'OlvColumn12
        '
        Me.OlvColumn12.AspectName = "AccountAccumulatedAmortization"
        Me.OlvColumn12.CellEditUseWholeCell = True
        Me.OlvColumn12.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn12.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn12.IsEditable = False
        Me.OlvColumn12.Text = "Amort. sąsk."
        Me.OlvColumn12.ToolTipText = ""
        Me.OlvColumn12.Width = 86
        '
        'OlvColumn13
        '
        Me.OlvColumn13.AspectName = "AccountValueIncrease"
        Me.OlvColumn13.CellEditUseWholeCell = True
        Me.OlvColumn13.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn13.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn13.IsEditable = False
        Me.OlvColumn13.Text = "Pervert. sąsk."
        Me.OlvColumn13.ToolTipText = ""
        Me.OlvColumn13.Width = 88
        '
        'OlvColumn14
        '
        Me.OlvColumn14.AspectName = "AccountValueDecrease"
        Me.OlvColumn14.CellEditUseWholeCell = True
        Me.OlvColumn14.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn14.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn14.IsEditable = False
        Me.OlvColumn14.Text = "Vertės sumaž. sąsk."
        Me.OlvColumn14.ToolTipText = ""
        Me.OlvColumn14.Width = 88
        '
        'OlvColumn15
        '
        Me.OlvColumn15.AspectName = "AccountRevaluedPortionAmmortization"
        Me.OlvColumn15.CellEditUseWholeCell = True
        Me.OlvColumn15.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn15.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn15.IsEditable = False
        Me.OlvColumn15.Text = "Pervert. dalies amort. sąsk."
        Me.OlvColumn15.ToolTipText = ""
        Me.OlvColumn15.Width = 100
        '
        'OlvColumn16
        '
        Me.OlvColumn16.AspectName = "LiquidationUnitValue"
        Me.OlvColumn16.AspectToStringFormat = ""
        Me.OlvColumn16.CellEditUseWholeCell = True
        Me.OlvColumn16.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn16.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn16.IsEditable = False
        Me.OlvColumn16.Text = "Likvidac. vnt. vertė"
        Me.OlvColumn16.ToolTipText = ""
        Me.OlvColumn16.Width = 100
        '
        'OlvColumn17
        '
        Me.OlvColumn17.AspectName = "ContinuedUsage"
        Me.OlvColumn17.CellEditUseWholeCell = True
        Me.OlvColumn17.CheckBoxes = True
        Me.OlvColumn17.DisplayIndex = 16
        Me.OlvColumn17.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn17.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn17.IsEditable = False
        Me.OlvColumn17.IsVisible = False
        Me.OlvColumn17.Text = "Tęsiamas naudoj."
        Me.OlvColumn17.ToolTipText = ""
        Me.OlvColumn17.Width = 100
        '
        'OlvColumn18
        '
        Me.OlvColumn18.AspectName = "DefaultAmortizationPeriod"
        Me.OlvColumn18.CellEditUseWholeCell = True
        Me.OlvColumn18.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn18.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn18.IsEditable = False
        Me.OlvColumn18.Text = "Amort. laikas (m.)"
        Me.OlvColumn18.ToolTipText = ""
        Me.OlvColumn18.Width = 100
        '
        'OlvColumn19
        '
        Me.OlvColumn19.AspectName = "AcquisitionAccountValue"
        Me.OlvColumn19.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn19.CellEditUseWholeCell = True
        Me.OlvColumn19.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn19.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn19.IsEditable = False
        Me.OlvColumn19.Text = "Savik. sąsk. vertė"
        Me.OlvColumn19.ToolTipText = ""
        Me.OlvColumn19.Width = 100
        '
        'OlvColumn20
        '
        Me.OlvColumn20.AspectName = "AcquisitionAccountValuePerUnit"
        Me.OlvColumn20.AspectToStringFormat = ""
        Me.OlvColumn20.CellEditUseWholeCell = True
        Me.OlvColumn20.DisplayIndex = 19
        Me.OlvColumn20.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn20.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn20.IsEditable = False
        Me.OlvColumn20.IsVisible = False
        Me.OlvColumn20.Text = "Savik. sąsk. vertė vnt."
        Me.OlvColumn20.ToolTipText = ""
        Me.OlvColumn20.Width = 100
        '
        'OlvColumn21
        '
        Me.OlvColumn21.AspectName = "AmortizationAccountValue"
        Me.OlvColumn21.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn21.CellEditUseWholeCell = True
        Me.OlvColumn21.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn21.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn21.IsEditable = False
        Me.OlvColumn21.Text = "Amort. sąsk. vertė"
        Me.OlvColumn21.ToolTipText = ""
        Me.OlvColumn21.Width = 100
        '
        'OlvColumn22
        '
        Me.OlvColumn22.AspectName = "AmortizationAccountValuePerUnit"
        Me.OlvColumn22.AspectToStringFormat = ""
        Me.OlvColumn22.CellEditUseWholeCell = True
        Me.OlvColumn22.DisplayIndex = 21
        Me.OlvColumn22.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn22.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn22.IsEditable = False
        Me.OlvColumn22.IsVisible = False
        Me.OlvColumn22.Text = "Amort. sąsk. vertė vnt."
        Me.OlvColumn22.ToolTipText = ""
        Me.OlvColumn22.Width = 100
        '
        'OlvColumn23
        '
        Me.OlvColumn23.AspectName = "ValueDecreaseAccountValue"
        Me.OlvColumn23.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn23.CellEditUseWholeCell = True
        Me.OlvColumn23.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn23.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn23.IsEditable = False
        Me.OlvColumn23.Text = "Vertės sumaž. sąsk. vertė"
        Me.OlvColumn23.ToolTipText = ""
        Me.OlvColumn23.Width = 100
        '
        'OlvColumn24
        '
        Me.OlvColumn24.AspectName = "ValueDecreaseAccountValuePerUnit"
        Me.OlvColumn24.AspectToStringFormat = ""
        Me.OlvColumn24.CellEditUseWholeCell = True
        Me.OlvColumn24.DisplayIndex = 23
        Me.OlvColumn24.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn24.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn24.IsEditable = False
        Me.OlvColumn24.IsVisible = False
        Me.OlvColumn24.Text = "Vertės sumaž. sąsk. vertė vnt."
        Me.OlvColumn24.ToolTipText = ""
        Me.OlvColumn24.Width = 100
        '
        'OlvColumn25
        '
        Me.OlvColumn25.AspectName = "ValueIncreaseAccountValue"
        Me.OlvColumn25.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn25.CellEditUseWholeCell = True
        Me.OlvColumn25.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn25.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn25.IsEditable = False
        Me.OlvColumn25.Text = "Pervert. sąsk. vertė"
        Me.OlvColumn25.ToolTipText = ""
        Me.OlvColumn25.Width = 100
        '
        'OlvColumn26
        '
        Me.OlvColumn26.AspectName = "ValueIncreaseAccountValuePerUnit"
        Me.OlvColumn26.AspectToStringFormat = ""
        Me.OlvColumn26.CellEditUseWholeCell = True
        Me.OlvColumn26.DisplayIndex = 25
        Me.OlvColumn26.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn26.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn26.IsEditable = False
        Me.OlvColumn26.IsVisible = False
        Me.OlvColumn26.Text = "Pervert. sąsk. vertė vnt."
        Me.OlvColumn26.ToolTipText = ""
        Me.OlvColumn26.Width = 100
        '
        'OlvColumn27
        '
        Me.OlvColumn27.AspectName = "ValueIncreaseAmmortizationAccountValue"
        Me.OlvColumn27.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn27.CellEditUseWholeCell = True
        Me.OlvColumn27.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn27.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn27.IsEditable = False
        Me.OlvColumn27.Text = "Pervert. dalies amort. sąsk. vertė"
        Me.OlvColumn27.ToolTipText = ""
        Me.OlvColumn27.Width = 100
        '
        'OlvColumn28
        '
        Me.OlvColumn28.AspectName = "ValueIncreaseAmmortizationAccountValuePerUnit"
        Me.OlvColumn28.AspectToStringFormat = ""
        Me.OlvColumn28.CellEditUseWholeCell = True
        Me.OlvColumn28.DisplayIndex = 27
        Me.OlvColumn28.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn28.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn28.IsEditable = False
        Me.OlvColumn28.IsVisible = False
        Me.OlvColumn28.Text = "Pervert. dalies sąsk. vertė vnt."
        Me.OlvColumn28.ToolTipText = ""
        Me.OlvColumn28.Width = 100
        '
        'OlvColumn29
        '
        Me.OlvColumn29.AspectName = "ValuePerUnit"
        Me.OlvColumn29.AspectToStringFormat = ""
        Me.OlvColumn29.CellEditUseWholeCell = True
        Me.OlvColumn29.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn29.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn29.IsEditable = False
        Me.OlvColumn29.Text = "Vertė vnt."
        Me.OlvColumn29.ToolTipText = ""
        Me.OlvColumn29.Width = 100
        '
        'OlvColumn30
        '
        Me.OlvColumn30.AspectName = "Ammount"
        Me.OlvColumn30.CellEditUseWholeCell = True
        Me.OlvColumn30.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn30.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn30.IsEditable = False
        Me.OlvColumn30.Text = "Kiekis"
        Me.OlvColumn30.ToolTipText = ""
        Me.OlvColumn30.Width = 100
        '
        'OlvColumn31
        '
        Me.OlvColumn31.AspectName = "Value"
        Me.OlvColumn31.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn31.CellEditUseWholeCell = True
        Me.OlvColumn31.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn31.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn31.IsEditable = False
        Me.OlvColumn31.Text = "Vertė"
        Me.OlvColumn31.ToolTipText = ""
        Me.OlvColumn31.Width = 100
        '
        'OlvColumn32
        '
        Me.OlvColumn32.AspectName = "ValueRevaluedPortion"
        Me.OlvColumn32.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn32.CellEditUseWholeCell = True
        Me.OlvColumn32.DisplayIndex = 31
        Me.OlvColumn32.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn32.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn32.IsEditable = False
        Me.OlvColumn32.IsVisible = False
        Me.OlvColumn32.Text = "Pervert. dalies vertė"
        Me.OlvColumn32.ToolTipText = ""
        Me.OlvColumn32.Width = 100
        '
        'OlvColumn33
        '
        Me.OlvColumn33.AspectName = "ValueRevaluedPortionPerUnit"
        Me.OlvColumn33.AspectToStringFormat = ""
        Me.OlvColumn33.CellEditUseWholeCell = True
        Me.OlvColumn33.DisplayIndex = 32
        Me.OlvColumn33.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn33.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn33.IsEditable = False
        Me.OlvColumn33.IsVisible = False
        Me.OlvColumn33.Text = "Pervert. dalies vertė vnt."
        Me.OlvColumn33.ToolTipText = ""
        Me.OlvColumn33.Width = 100
        '
        'OlvColumn34
        '
        Me.OlvColumn34.AspectName = "BeforeAcquisitionAccountValue"
        Me.OlvColumn34.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn34.CellEditUseWholeCell = True
        Me.OlvColumn34.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn34.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn34.IsEditable = False
        Me.OlvColumn34.Text = "Laik. pr. savik. sąsk. vertė"
        Me.OlvColumn34.ToolTipText = ""
        Me.OlvColumn34.Width = 100
        '
        'OlvColumn35
        '
        Me.OlvColumn35.AspectName = "BeforeAcquisitionAccountValuePerUnit"
        Me.OlvColumn35.AspectToStringFormat = ""
        Me.OlvColumn35.CellEditUseWholeCell = True
        Me.OlvColumn35.DisplayIndex = 34
        Me.OlvColumn35.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn35.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn35.IsEditable = False
        Me.OlvColumn35.IsVisible = False
        Me.OlvColumn35.Text = "Laik. pr. savik. sąsk. vertė vnt."
        Me.OlvColumn35.ToolTipText = ""
        Me.OlvColumn35.Width = 100
        '
        'OlvColumn36
        '
        Me.OlvColumn36.AspectName = "BeforeAmortizationAccountValue"
        Me.OlvColumn36.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn36.CellEditUseWholeCell = True
        Me.OlvColumn36.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn36.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn36.IsEditable = False
        Me.OlvColumn36.Text = "Laik. pr. amort. sąsk. vertė"
        Me.OlvColumn36.ToolTipText = ""
        Me.OlvColumn36.Width = 100
        '
        'OlvColumn37
        '
        Me.OlvColumn37.AspectName = "BeforeAmortizationAccountValuePerUnit"
        Me.OlvColumn37.AspectToStringFormat = ""
        Me.OlvColumn37.CellEditUseWholeCell = True
        Me.OlvColumn37.DisplayIndex = 36
        Me.OlvColumn37.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn37.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn37.IsEditable = False
        Me.OlvColumn37.IsVisible = False
        Me.OlvColumn37.Text = "Laik. pr. amort. sąsk. vertė vnt."
        Me.OlvColumn37.ToolTipText = ""
        Me.OlvColumn37.Width = 100
        '
        'OlvColumn38
        '
        Me.OlvColumn38.AspectName = "BeforeValueDecreaseAccountValue"
        Me.OlvColumn38.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn38.CellEditUseWholeCell = True
        Me.OlvColumn38.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn38.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn38.IsEditable = False
        Me.OlvColumn38.Text = "Laik. pr. vertės sumaž. sąsk. vertė"
        Me.OlvColumn38.ToolTipText = ""
        Me.OlvColumn38.Width = 100
        '
        'OlvColumn39
        '
        Me.OlvColumn39.AspectName = "BeforeValueDecreaseAccountValuePerUnit"
        Me.OlvColumn39.AspectToStringFormat = ""
        Me.OlvColumn39.CellEditUseWholeCell = True
        Me.OlvColumn39.DisplayIndex = 38
        Me.OlvColumn39.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn39.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn39.IsEditable = False
        Me.OlvColumn39.IsVisible = False
        Me.OlvColumn39.Text = "Laik. pr. vertės sumaž. sąsk. vertė vnt."
        Me.OlvColumn39.ToolTipText = ""
        Me.OlvColumn39.Width = 100
        '
        'OlvColumn40
        '
        Me.OlvColumn40.AspectName = "BeforeValueIncreaseAccountValue"
        Me.OlvColumn40.AspectToStringFormat = ""
        Me.OlvColumn40.CellEditUseWholeCell = True
        Me.OlvColumn40.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn40.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn40.IsEditable = False
        Me.OlvColumn40.Text = "Laik. pr. pervert. sąsk. vertė"
        Me.OlvColumn40.ToolTipText = ""
        Me.OlvColumn40.Width = 100
        '
        'OlvColumn41
        '
        Me.OlvColumn41.AspectName = "BeforeValueIncreaseAccountValuePerUnit"
        Me.OlvColumn41.AspectToStringFormat = ""
        Me.OlvColumn41.CellEditUseWholeCell = True
        Me.OlvColumn41.DisplayIndex = 40
        Me.OlvColumn41.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn41.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn41.IsEditable = False
        Me.OlvColumn41.IsVisible = False
        Me.OlvColumn41.Text = "Laik. pr. pervert. sąsk. vertė vnt."
        Me.OlvColumn41.ToolTipText = ""
        Me.OlvColumn41.Width = 100
        '
        'OlvColumn42
        '
        Me.OlvColumn42.AspectName = "BeforeValueIncreaseAmmortizationAccountValue"
        Me.OlvColumn42.AspectToStringFormat = ""
        Me.OlvColumn42.CellEditUseWholeCell = True
        Me.OlvColumn42.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn42.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn42.IsEditable = False
        Me.OlvColumn42.Text = "Laik. pr. pervert. dalies amort. sąsk. vertė"
        Me.OlvColumn42.ToolTipText = ""
        Me.OlvColumn42.Width = 100
        '
        'OlvColumn43
        '
        Me.OlvColumn43.AspectName = "BeforeValueIncreaseAmmortizationAccountValuePerUnit"
        Me.OlvColumn43.AspectToStringFormat = ""
        Me.OlvColumn43.CellEditUseWholeCell = True
        Me.OlvColumn43.DisplayIndex = 42
        Me.OlvColumn43.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn43.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn43.IsEditable = False
        Me.OlvColumn43.IsVisible = False
        Me.OlvColumn43.Text = "Laik. pr. pervert. dalies amort. sąsk. vertė vnt."
        Me.OlvColumn43.ToolTipText = ""
        Me.OlvColumn43.Width = 100
        '
        'OlvColumn44
        '
        Me.OlvColumn44.AspectName = "BeforeValuePerUnit"
        Me.OlvColumn44.AspectToStringFormat = ""
        Me.OlvColumn44.CellEditUseWholeCell = True
        Me.OlvColumn44.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn44.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn44.IsEditable = False
        Me.OlvColumn44.Text = "Laik. pr. vertė vnt."
        Me.OlvColumn44.ToolTipText = ""
        Me.OlvColumn44.Width = 100
        '
        'OlvColumn45
        '
        Me.OlvColumn45.AspectName = "BeforeAmmount"
        Me.OlvColumn45.CellEditUseWholeCell = True
        Me.OlvColumn45.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn45.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn45.IsEditable = False
        Me.OlvColumn45.Text = "Laik. pr. kiekis"
        Me.OlvColumn45.ToolTipText = ""
        Me.OlvColumn45.Width = 100
        '
        'OlvColumn46
        '
        Me.OlvColumn46.AspectName = "BeforeValue"
        Me.OlvColumn46.AspectToStringFormat = ""
        Me.OlvColumn46.CellEditUseWholeCell = True
        Me.OlvColumn46.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn46.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn46.IsEditable = False
        Me.OlvColumn46.Text = "Laik. pr. vertė"
        Me.OlvColumn46.ToolTipText = ""
        Me.OlvColumn46.Width = 100
        '
        'OlvColumn47
        '
        Me.OlvColumn47.AspectName = "ChangeAcquisitionAccountValue"
        Me.OlvColumn47.AspectToStringFormat = ""
        Me.OlvColumn47.CellEditUseWholeCell = True
        Me.OlvColumn47.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn47.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn47.IsEditable = False
        Me.OlvColumn47.Text = "Pokytis per laik. savik. sąsk."
        Me.OlvColumn47.ToolTipText = ""
        Me.OlvColumn47.Width = 100
        '
        'OlvColumn48
        '
        Me.OlvColumn48.AspectName = "ChangeAcquisitionAccountValuePerUnit"
        Me.OlvColumn48.AspectToStringFormat = ""
        Me.OlvColumn48.CellEditUseWholeCell = True
        Me.OlvColumn48.DisplayIndex = 47
        Me.OlvColumn48.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn48.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn48.IsEditable = False
        Me.OlvColumn48.IsVisible = False
        Me.OlvColumn48.Text = "Pokytis per laik. savik. sąsk. vnt."
        Me.OlvColumn48.ToolTipText = ""
        Me.OlvColumn48.Width = 100
        '
        'OlvColumn49
        '
        Me.OlvColumn49.AspectName = "ChangeAmortizationAccountValue"
        Me.OlvColumn49.AspectToStringFormat = ""
        Me.OlvColumn49.CellEditUseWholeCell = True
        Me.OlvColumn49.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn49.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn49.IsEditable = False
        Me.OlvColumn49.Text = "Pokytis per laik. amort. sąsk."
        Me.OlvColumn49.ToolTipText = ""
        Me.OlvColumn49.Width = 100
        '
        'OlvColumn50
        '
        Me.OlvColumn50.AspectName = "ChangeAmortizationAccountValuePerUnit"
        Me.OlvColumn50.AspectToStringFormat = ""
        Me.OlvColumn50.CellEditUseWholeCell = True
        Me.OlvColumn50.DisplayIndex = 49
        Me.OlvColumn50.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn50.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn50.IsEditable = False
        Me.OlvColumn50.IsVisible = False
        Me.OlvColumn50.Text = "Pokytis per laik. amort. sąsk. vnt."
        Me.OlvColumn50.ToolTipText = ""
        Me.OlvColumn50.Width = 100
        '
        'OlvColumn51
        '
        Me.OlvColumn51.AspectName = "ChangeValueDecreaseAccountValue"
        Me.OlvColumn51.AspectToStringFormat = ""
        Me.OlvColumn51.CellEditUseWholeCell = True
        Me.OlvColumn51.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn51.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn51.IsEditable = False
        Me.OlvColumn51.Text = "Pokytis per laik. vertės sumaž. sąsk."
        Me.OlvColumn51.ToolTipText = ""
        Me.OlvColumn51.Width = 100
        '
        'OlvColumn52
        '
        Me.OlvColumn52.AspectName = "ChangeValueDecreaseAccountValuePerUnit"
        Me.OlvColumn52.AspectToStringFormat = ""
        Me.OlvColumn52.CellEditUseWholeCell = True
        Me.OlvColumn52.DisplayIndex = 51
        Me.OlvColumn52.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn52.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn52.IsEditable = False
        Me.OlvColumn52.IsVisible = False
        Me.OlvColumn52.Text = "Pokytis per laik. vertės sumaž. sąsk. vnt."
        Me.OlvColumn52.ToolTipText = ""
        Me.OlvColumn52.Width = 100
        '
        'OlvColumn53
        '
        Me.OlvColumn53.AspectName = "ChangeValueIncreaseAccountValue"
        Me.OlvColumn53.AspectToStringFormat = ""
        Me.OlvColumn53.CellEditUseWholeCell = True
        Me.OlvColumn53.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn53.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn53.IsEditable = False
        Me.OlvColumn53.Text = "Pokytis per laik. pervert. sąsk."
        Me.OlvColumn53.ToolTipText = ""
        Me.OlvColumn53.Width = 100
        '
        'OlvColumn54
        '
        Me.OlvColumn54.AspectName = "ChangeValueIncreaseAccountValuePerUnit"
        Me.OlvColumn54.AspectToStringFormat = ""
        Me.OlvColumn54.CellEditUseWholeCell = True
        Me.OlvColumn54.DisplayIndex = 53
        Me.OlvColumn54.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn54.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn54.IsEditable = False
        Me.OlvColumn54.IsVisible = False
        Me.OlvColumn54.Text = "Pokytis per laik. pervert. sąsk. vnt."
        Me.OlvColumn54.ToolTipText = ""
        Me.OlvColumn54.Width = 100
        '
        'OlvColumn55
        '
        Me.OlvColumn55.AspectName = "ChangeValueIncreaseAmmortizationAccountValue"
        Me.OlvColumn55.AspectToStringFormat = ""
        Me.OlvColumn55.CellEditUseWholeCell = True
        Me.OlvColumn55.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn55.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn55.IsEditable = False
        Me.OlvColumn55.Text = "Pokytis per laik. perkain. dalies amort. sąsk."
        Me.OlvColumn55.ToolTipText = ""
        Me.OlvColumn55.Width = 100
        '
        'OlvColumn56
        '
        Me.OlvColumn56.AspectName = "ChangeValueIncreaseAmmortizationAccountValuePerUnit"
        Me.OlvColumn56.AspectToStringFormat = ""
        Me.OlvColumn56.CellEditUseWholeCell = True
        Me.OlvColumn56.DisplayIndex = 55
        Me.OlvColumn56.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn56.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn56.IsEditable = False
        Me.OlvColumn56.IsVisible = False
        Me.OlvColumn56.Text = "Pokytis per laik. perkain. dalies amort. sąsk. vnt."
        Me.OlvColumn56.ToolTipText = ""
        Me.OlvColumn56.Width = 100
        '
        'OlvColumn57
        '
        Me.OlvColumn57.AspectName = "ChangeValuePerUnit"
        Me.OlvColumn57.AspectToStringFormat = ""
        Me.OlvColumn57.CellEditUseWholeCell = True
        Me.OlvColumn57.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn57.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn57.IsEditable = False
        Me.OlvColumn57.Text = "Pokytis per laik. vertės vnt."
        Me.OlvColumn57.ToolTipText = ""
        Me.OlvColumn57.Width = 100
        '
        'OlvColumn58
        '
        Me.OlvColumn58.AspectName = "ChangeAmmount"
        Me.OlvColumn58.CellEditUseWholeCell = True
        Me.OlvColumn58.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn58.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn58.IsEditable = False
        Me.OlvColumn58.Text = "Pokytis per laik. kiekio"
        Me.OlvColumn58.ToolTipText = ""
        Me.OlvColumn58.Width = 100
        '
        'OlvColumn59
        '
        Me.OlvColumn59.AspectName = "ChangeValue"
        Me.OlvColumn59.AspectToStringFormat = ""
        Me.OlvColumn59.CellEditUseWholeCell = True
        Me.OlvColumn59.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn59.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn59.IsEditable = False
        Me.OlvColumn59.Text = "Pokytis per laik. vertės"
        Me.OlvColumn59.ToolTipText = ""
        Me.OlvColumn59.Width = 100
        '
        'OlvColumn60
        '
        Me.OlvColumn60.AspectName = "ChangeAmmountAcquired"
        Me.OlvColumn60.CellEditUseWholeCell = True
        Me.OlvColumn60.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn60.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn60.IsEditable = False
        Me.OlvColumn60.Text = "Per laik. įsigyta kiekis"
        Me.OlvColumn60.ToolTipText = ""
        Me.OlvColumn60.Width = 100
        '
        'OlvColumn61
        '
        Me.OlvColumn61.AspectName = "ChangeValueAcquired"
        Me.OlvColumn61.AspectToStringFormat = ""
        Me.OlvColumn61.CellEditUseWholeCell = True
        Me.OlvColumn61.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn61.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn61.IsEditable = False
        Me.OlvColumn61.Text = "Per laik. įsigyta vertė"
        Me.OlvColumn61.ToolTipText = ""
        Me.OlvColumn61.Width = 100
        '
        'OlvColumn62
        '
        Me.OlvColumn62.AspectName = "ChangeAmmountTransfered"
        Me.OlvColumn62.CellEditUseWholeCell = True
        Me.OlvColumn62.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn62.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn62.IsEditable = False
        Me.OlvColumn62.Text = "Per laik. perleista kiekis"
        Me.OlvColumn62.ToolTipText = ""
        Me.OlvColumn62.Width = 100
        '
        'OlvColumn63
        '
        Me.OlvColumn63.AspectName = "ChangeValueTransfered"
        Me.OlvColumn63.AspectToStringFormat = ""
        Me.OlvColumn63.CellEditUseWholeCell = True
        Me.OlvColumn63.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn63.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn63.IsEditable = False
        Me.OlvColumn63.Text = "Per laik. perleista vertė"
        Me.OlvColumn63.ToolTipText = ""
        Me.OlvColumn63.Width = 100
        '
        'OlvColumn64
        '
        Me.OlvColumn64.AspectName = "ChangeAmmountDiscarded"
        Me.OlvColumn64.CellEditUseWholeCell = True
        Me.OlvColumn64.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn64.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn64.IsEditable = False
        Me.OlvColumn64.Text = "Per laik. nuraš. kiekis"
        Me.OlvColumn64.ToolTipText = ""
        Me.OlvColumn64.Width = 100
        '
        'OlvColumn65
        '
        Me.OlvColumn65.AspectName = "ChangeValueDiscarded"
        Me.OlvColumn65.AspectToStringFormat = ""
        Me.OlvColumn65.CellEditUseWholeCell = True
        Me.OlvColumn65.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn65.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn65.IsEditable = False
        Me.OlvColumn65.Text = "Per laik. nuraš. vertė"
        Me.OlvColumn65.ToolTipText = ""
        Me.OlvColumn65.Width = 100
        '
        'OlvColumn66
        '
        Me.OlvColumn66.AspectName = "AfterAcquisitionAccountValue"
        Me.OlvColumn66.AspectToStringFormat = ""
        Me.OlvColumn66.CellEditUseWholeCell = True
        Me.OlvColumn66.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn66.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn66.IsEditable = False
        Me.OlvColumn66.Text = "Po laik. savik. sąsk. vertė"
        Me.OlvColumn66.ToolTipText = ""
        Me.OlvColumn66.Width = 100
        '
        'OlvColumn67
        '
        Me.OlvColumn67.AspectName = "AfterAcquisitionAccountValuePerUnit"
        Me.OlvColumn67.AspectToStringFormat = ""
        Me.OlvColumn67.CellEditUseWholeCell = True
        Me.OlvColumn67.DisplayIndex = 66
        Me.OlvColumn67.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn67.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn67.IsEditable = False
        Me.OlvColumn67.IsVisible = False
        Me.OlvColumn67.Text = "Po laik. savik. sąsk. vertė vnt."
        Me.OlvColumn67.ToolTipText = ""
        Me.OlvColumn67.Width = 100
        '
        'OlvColumn68
        '
        Me.OlvColumn68.AspectName = "AfterAmortizationAccountValue"
        Me.OlvColumn68.AspectToStringFormat = ""
        Me.OlvColumn68.CellEditUseWholeCell = True
        Me.OlvColumn68.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn68.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn68.IsEditable = False
        Me.OlvColumn68.Text = "Po laik. amort. sąsk. vertė"
        Me.OlvColumn68.ToolTipText = ""
        Me.OlvColumn68.Width = 100
        '
        'OlvColumn69
        '
        Me.OlvColumn69.AspectName = "AfterAmortizationAccountValuePerUnit"
        Me.OlvColumn69.AspectToStringFormat = ""
        Me.OlvColumn69.CellEditUseWholeCell = True
        Me.OlvColumn69.DisplayIndex = 68
        Me.OlvColumn69.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn69.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn69.IsEditable = False
        Me.OlvColumn69.IsVisible = False
        Me.OlvColumn69.Text = "Po laik. amort. sąsk. vertė vnt."
        Me.OlvColumn69.ToolTipText = ""
        Me.OlvColumn69.Width = 100
        '
        'OlvColumn70
        '
        Me.OlvColumn70.AspectName = "AfterValueDecreaseAccountValue"
        Me.OlvColumn70.AspectToStringFormat = ""
        Me.OlvColumn70.CellEditUseWholeCell = True
        Me.OlvColumn70.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn70.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn70.IsEditable = False
        Me.OlvColumn70.Text = "Po laik. vertės sumaž. sąsk. vertė"
        Me.OlvColumn70.ToolTipText = ""
        Me.OlvColumn70.Width = 100
        '
        'OlvColumn71
        '
        Me.OlvColumn71.AspectName = "AfterValueDecreaseAccountValuePerUnit"
        Me.OlvColumn71.AspectToStringFormat = ""
        Me.OlvColumn71.CellEditUseWholeCell = True
        Me.OlvColumn71.DisplayIndex = 70
        Me.OlvColumn71.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn71.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn71.IsEditable = False
        Me.OlvColumn71.IsVisible = False
        Me.OlvColumn71.Text = "Po laik. vertės sumaž. sąsk. vertė vnt."
        Me.OlvColumn71.ToolTipText = ""
        Me.OlvColumn71.Width = 100
        '
        'OlvColumn72
        '
        Me.OlvColumn72.AspectName = "AfterValueIncreaseAccountValue"
        Me.OlvColumn72.AspectToStringFormat = ""
        Me.OlvColumn72.CellEditUseWholeCell = True
        Me.OlvColumn72.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn72.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn72.IsEditable = False
        Me.OlvColumn72.Text = "Po laik. pervert. sąsk. vertė"
        Me.OlvColumn72.ToolTipText = ""
        Me.OlvColumn72.Width = 100
        '
        'OlvColumn73
        '
        Me.OlvColumn73.AspectName = "AfterValueIncreaseAccountValuePerUnit"
        Me.OlvColumn73.AspectToStringFormat = ""
        Me.OlvColumn73.CellEditUseWholeCell = True
        Me.OlvColumn73.DisplayIndex = 72
        Me.OlvColumn73.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn73.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn73.IsEditable = False
        Me.OlvColumn73.IsVisible = False
        Me.OlvColumn73.Text = "Po laik. pervert. sąsk. vertė vnt."
        Me.OlvColumn73.ToolTipText = ""
        Me.OlvColumn73.Width = 100
        '
        'OlvColumn74
        '
        Me.OlvColumn74.AspectName = "AfterValueIncreaseAmmortizationAccountValue"
        Me.OlvColumn74.AspectToStringFormat = ""
        Me.OlvColumn74.CellEditUseWholeCell = True
        Me.OlvColumn74.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn74.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn74.IsEditable = False
        Me.OlvColumn74.Text = "Po laik. pervert. dalies amort. sąsk. vertė"
        Me.OlvColumn74.ToolTipText = ""
        Me.OlvColumn74.Width = 100
        '
        'OlvColumn75
        '
        Me.OlvColumn75.AspectName = "AfterValueIncreaseAmmortizationAccountValuePerUnit"
        Me.OlvColumn75.AspectToStringFormat = ""
        Me.OlvColumn75.CellEditUseWholeCell = True
        Me.OlvColumn75.DisplayIndex = 74
        Me.OlvColumn75.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn75.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn75.IsEditable = False
        Me.OlvColumn75.IsVisible = False
        Me.OlvColumn75.Text = "Po laik. pervert. dalies amort. sąsk. vertė vnt."
        Me.OlvColumn75.ToolTipText = ""
        Me.OlvColumn75.Width = 100
        '
        'OlvColumn76
        '
        Me.OlvColumn76.AspectName = "AfterValuePerUnit"
        Me.OlvColumn76.AspectToStringFormat = ""
        Me.OlvColumn76.CellEditUseWholeCell = True
        Me.OlvColumn76.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn76.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn76.IsEditable = False
        Me.OlvColumn76.Text = "Po laik. vertė vnt."
        Me.OlvColumn76.ToolTipText = ""
        Me.OlvColumn76.Width = 100
        '
        'OlvColumn77
        '
        Me.OlvColumn77.AspectName = "AfterAmmount"
        Me.OlvColumn77.CellEditUseWholeCell = True
        Me.OlvColumn77.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn77.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn77.IsEditable = False
        Me.OlvColumn77.Text = "Po laik. kiekis"
        Me.OlvColumn77.ToolTipText = ""
        Me.OlvColumn77.Width = 100
        '
        'OlvColumn78
        '
        Me.OlvColumn78.AspectName = "AfterValue"
        Me.OlvColumn78.AspectToStringFormat = ""
        Me.OlvColumn78.CellEditUseWholeCell = True
        Me.OlvColumn78.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn78.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn78.IsEditable = False
        Me.OlvColumn78.Text = "Po laik. vertė"
        Me.OlvColumn78.ToolTipText = ""
        Me.OlvColumn78.Width = 100
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(175, 69)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(132, 56)
        Me.ProgressFiller1.TabIndex = 5
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(328, 65)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(113, 59)
        Me.ProgressFiller2.TabIndex = 6
        Me.ProgressFiller2.Visible = False
        '
        'F_LongTermAssetInfoList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.ClientSize = New System.Drawing.Size(908, 405)
        Me.Controls.Add(Me.LongTermAssetInfoListDataListView)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_LongTermAssetInfoList"
        Me.ShowInTaskbar = False
        Me.Text = "Ilgalaikio turto katalogas"
        CType(Me.LongTermAssetInfoListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.LongTermAssetInfoListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LongTermAssetCustomGroupInfoComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LongTermAssetInfoListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ChangeItem_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemDetails_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteItem_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewItem_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewOperation_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeginExploitation_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EndExploitation_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Amortization_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AmortizationPeriodChange_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Discard_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Transfer_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcquisitionValueIncrease_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ValueChange_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountChange_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcquisitionAccount_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcquisitionAmortizationAccount_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ValueDecreaseAccount_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ValueIncreaseAccount_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ValueIncreaseAmortizationAccount_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LongTermAssetInfoListDataListView As BrightIdeasSoftware.DataListView
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
    Friend WithEvents OlvColumn19 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn20 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn21 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn22 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn23 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn24 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn25 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn26 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn27 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn28 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn29 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn30 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn31 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn32 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn33 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn34 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn35 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn36 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn37 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn38 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn39 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn40 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn41 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn42 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn43 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn44 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn45 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn46 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn47 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn48 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn49 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn50 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn51 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn52 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn53 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn54 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn55 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn56 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn57 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn58 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn59 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn60 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn61 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn62 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn63 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn64 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn65 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn66 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn67 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn68 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn69 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn70 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn71 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn72 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn73 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn74 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn75 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn76 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn77 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn78 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents DateFromAccDatePicker As AccControlsWinForms.AccDatePicker
    Friend WithEvents DateToAccDatePicker As AccControlsWinForms.AccDatePicker
End Class
