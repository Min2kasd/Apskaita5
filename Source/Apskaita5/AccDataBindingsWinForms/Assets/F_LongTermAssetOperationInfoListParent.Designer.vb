﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_LongTermAssetOperationInfoListParent
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
        Dim NameLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim InventoryNumberLabel As System.Windows.Forms.Label
        Dim LegalGroupLabel As System.Windows.Forms.Label
        Dim MeasureUnitLabel As System.Windows.Forms.Label
        Dim LiquidationUnitValueLabel As System.Windows.Forms.Label
        Dim DefaultAmortizationPeriodLabel As System.Windows.Forms.Label
        Dim CustomGroupLabel As System.Windows.Forms.Label
        Dim AcquisitionJournalEntryDocNumberLabel As System.Windows.Forms.Label
        Dim AcquisitionDateLabel As System.Windows.Forms.Label
        Dim AccountAcquisitionLabel As System.Windows.Forms.Label
        Dim AccountAccumulatedAmortizationLabel As System.Windows.Forms.Label
        Dim AccountValueDecreaseLabel As System.Windows.Forms.Label
        Dim AccountValueIncreaseLabel As System.Windows.Forms.Label
        Dim AccountRevaluedPortionAmmortizationLabel As System.Windows.Forms.Label
        Dim AmmountLabel As System.Windows.Forms.Label
        Dim ValueLabel As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_LongTermAssetOperationInfoListParent))
        Me.RefreshButton = New System.Windows.Forms.Button
        Me.ValueAccBox = New AccControlsWinForms.AccTextBox
        Me.LongTermAssetOperationInfoListParentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ValuePerUnitAccBox = New AccControlsWinForms.AccTextBox
        Me.AmmountTextBox = New System.Windows.Forms.TextBox
        Me.ValueIncreaseAmmortizationAccountValuePerUnitAccBox = New AccControlsWinForms.AccTextBox
        Me.ValueIncreaseAccountValuePerUnitAccBox = New AccControlsWinForms.AccTextBox
        Me.ValueDecreaseAccountValuePerUnitAccBox = New AccControlsWinForms.AccTextBox
        Me.AmortizationAccountValuePerUnitAccBox = New AccControlsWinForms.AccTextBox
        Me.AcquisitionAccountValuePerUnitAccBox = New AccControlsWinForms.AccTextBox
        Me.ValueIncreaseAmmortizationAccountValueAccBox = New AccControlsWinForms.AccTextBox
        Me.ValueIncreaseAccountValueAccBox = New AccControlsWinForms.AccTextBox
        Me.ValueDecreaseAccountValueAccBox = New AccControlsWinForms.AccTextBox
        Me.AmortizationAccountValueAccBox = New AccControlsWinForms.AccTextBox
        Me.AcquisitionAccountValueAccBox = New AccControlsWinForms.AccTextBox
        Me.AccountRevaluedPortionAmmortizationTextBox = New System.Windows.Forms.TextBox
        Me.AccountValueIncreaseTextBox = New System.Windows.Forms.TextBox
        Me.AccountValueDecreaseTextBox = New System.Windows.Forms.TextBox
        Me.AccountAccumulatedAmortizationTextBox = New System.Windows.Forms.TextBox
        Me.AccountAcquisitionTextBox = New System.Windows.Forms.TextBox
        Me.LiquidationUnitValueAccBox = New AccControlsWinForms.AccTextBox
        Me.AcquisitionDateDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.AcquisitionJournalEntryDocNumberTextBox = New System.Windows.Forms.TextBox
        Me.CustomGroupTextBox = New System.Windows.Forms.TextBox
        Me.DefaultAmortizationPeriodTextBox = New System.Windows.Forms.TextBox
        Me.MeasureUnitTextBox = New System.Windows.Forms.TextBox
        Me.LegalGroupTextBox = New System.Windows.Forms.TextBox
        Me.InventoryNumberTextBox = New System.Windows.Forms.TextBox
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.OperationListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChangeItem_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteItem_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewOperation_MenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.CurrentValueIncreaseAmmortizationAccountValuePerUnitAccTextBox = New AccControlsWinForms.AccTextBox
        Me.CurrentValueIncreaseAmmortizationAccountValueAccTextBox = New AccControlsWinForms.AccTextBox
        Me.CurrentValueIncreaseAccountValuePerUnitAccTextBox = New AccControlsWinForms.AccTextBox
        Me.CurrentValueIncreaseAccountValueAccTextBox = New AccControlsWinForms.AccTextBox
        Me.CurrentValueDecreaseAccountValuePerUnitAccTextBox = New AccControlsWinForms.AccTextBox
        Me.CurrentValueDecreaseAccountValueAccTextBox = New AccControlsWinForms.AccTextBox
        Me.CurrentValuePerUnitAccTextBox = New AccControlsWinForms.AccTextBox
        Me.CurrentValueAccTextBox = New AccControlsWinForms.AccTextBox
        Me.CurrentAmountAccTextBox = New AccControlsWinForms.AccTextBox
        Me.CurrentAmortizationAccountValuePerUnitAccTextBox = New AccControlsWinForms.AccTextBox
        Me.CurrentAmortizationAccountValueAccTextBox = New AccControlsWinForms.AccTextBox
        Me.CurrentAcquisitionAccountValuePerUnitAccTextBox = New AccControlsWinForms.AccTextBox
        Me.CurrentAcquisitionAccountValueAccTextBox = New AccControlsWinForms.AccTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.AssetInfoListAccListComboBox = New AccControlsWinForms.AccListComboBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.CurrentlyOperationalCheckBox = New System.Windows.Forms.CheckBox
        Me.OperationListDataListView = New BrightIdeasSoftware.DataListView
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
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        NameLabel = New System.Windows.Forms.Label
        IDLabel = New System.Windows.Forms.Label
        InventoryNumberLabel = New System.Windows.Forms.Label
        LegalGroupLabel = New System.Windows.Forms.Label
        MeasureUnitLabel = New System.Windows.Forms.Label
        LiquidationUnitValueLabel = New System.Windows.Forms.Label
        DefaultAmortizationPeriodLabel = New System.Windows.Forms.Label
        CustomGroupLabel = New System.Windows.Forms.Label
        AcquisitionJournalEntryDocNumberLabel = New System.Windows.Forms.Label
        AcquisitionDateLabel = New System.Windows.Forms.Label
        AccountAcquisitionLabel = New System.Windows.Forms.Label
        AccountAccumulatedAmortizationLabel = New System.Windows.Forms.Label
        AccountValueDecreaseLabel = New System.Windows.Forms.Label
        AccountValueIncreaseLabel = New System.Windows.Forms.Label
        AccountRevaluedPortionAmmortizationLabel = New System.Windows.Forms.Label
        AmmountLabel = New System.Windows.Forms.Label
        ValueLabel = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        Label5 = New System.Windows.Forms.Label
        Label6 = New System.Windows.Forms.Label
        Label7 = New System.Windows.Forms.Label
        Label8 = New System.Windows.Forms.Label
        Label9 = New System.Windows.Forms.Label
        CType(Me.LongTermAssetOperationInfoListParentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OperationListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.OperationListDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.Dock = System.Windows.Forms.DockStyle.Fill
        NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel.Location = New System.Drawing.Point(3, 0)
        NameLabel.Name = "NameLabel"
        NameLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        NameLabel.Size = New System.Drawing.Size(85, 26)
        NameLabel.TabIndex = 0
        NameLabel.Text = "Pavadinimas:"
        NameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'IDLabel
        '
        IDLabel.AutoSize = True
        IDLabel.Dock = System.Windows.Forms.DockStyle.Fill
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(494, 26)
        IDLabel.Name = "IDLabel"
        IDLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        IDLabel.Size = New System.Drawing.Size(100, 26)
        IDLabel.TabIndex = 2
        IDLabel.Text = "ID:"
        IDLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'InventoryNumberLabel
        '
        InventoryNumberLabel.AutoSize = True
        InventoryNumberLabel.Dock = System.Windows.Forms.DockStyle.Fill
        InventoryNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        InventoryNumberLabel.Location = New System.Drawing.Point(3, 52)
        InventoryNumberLabel.Name = "InventoryNumberLabel"
        InventoryNumberLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        InventoryNumberLabel.Size = New System.Drawing.Size(85, 26)
        InventoryNumberLabel.TabIndex = 4
        InventoryNumberLabel.Text = "Invent. Nr.:"
        InventoryNumberLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LegalGroupLabel
        '
        LegalGroupLabel.AutoSize = True
        LegalGroupLabel.Dock = System.Windows.Forms.DockStyle.Fill
        LegalGroupLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LegalGroupLabel.Location = New System.Drawing.Point(3, 78)
        LegalGroupLabel.Name = "LegalGroupLabel"
        LegalGroupLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        LegalGroupLabel.Size = New System.Drawing.Size(85, 30)
        LegalGroupLabel.TabIndex = 6
        LegalGroupLabel.Text = "PMĮ grupė:"
        LegalGroupLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'MeasureUnitLabel
        '
        MeasureUnitLabel.AutoSize = True
        MeasureUnitLabel.Dock = System.Windows.Forms.DockStyle.Fill
        MeasureUnitLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        MeasureUnitLabel.Location = New System.Drawing.Point(3, 108)
        MeasureUnitLabel.Name = "MeasureUnitLabel"
        MeasureUnitLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        MeasureUnitLabel.Size = New System.Drawing.Size(85, 26)
        MeasureUnitLabel.TabIndex = 8
        MeasureUnitLabel.Text = "Mato vnt.:"
        MeasureUnitLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LiquidationUnitValueLabel
        '
        LiquidationUnitValueLabel.AutoSize = True
        LiquidationUnitValueLabel.Dock = System.Windows.Forms.DockStyle.Fill
        LiquidationUnitValueLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LiquidationUnitValueLabel.Location = New System.Drawing.Point(243, 108)
        LiquidationUnitValueLabel.Name = "LiquidationUnitValueLabel"
        LiquidationUnitValueLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        LiquidationUnitValueLabel.Size = New System.Drawing.Size(96, 26)
        LiquidationUnitValueLabel.TabIndex = 10
        LiquidationUnitValueLabel.Text = "Likvidac. vertė:"
        LiquidationUnitValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'DefaultAmortizationPeriodLabel
        '
        DefaultAmortizationPeriodLabel.AutoSize = True
        DefaultAmortizationPeriodLabel.Dock = System.Windows.Forms.DockStyle.Fill
        DefaultAmortizationPeriodLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DefaultAmortizationPeriodLabel.Location = New System.Drawing.Point(494, 108)
        DefaultAmortizationPeriodLabel.Name = "DefaultAmortizationPeriodLabel"
        DefaultAmortizationPeriodLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        DefaultAmortizationPeriodLabel.Size = New System.Drawing.Size(100, 26)
        DefaultAmortizationPeriodLabel.TabIndex = 12
        DefaultAmortizationPeriodLabel.Text = "Amort. laik. (m.):"
        DefaultAmortizationPeriodLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CustomGroupLabel
        '
        CustomGroupLabel.AutoSize = True
        CustomGroupLabel.Dock = System.Windows.Forms.DockStyle.Fill
        CustomGroupLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CustomGroupLabel.Location = New System.Drawing.Point(243, 52)
        CustomGroupLabel.Name = "CustomGroupLabel"
        CustomGroupLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        CustomGroupLabel.Size = New System.Drawing.Size(96, 26)
        CustomGroupLabel.TabIndex = 14
        CustomGroupLabel.Text = "Grupė:"
        CustomGroupLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AcquisitionJournalEntryDocNumberLabel
        '
        AcquisitionJournalEntryDocNumberLabel.AutoSize = True
        AcquisitionJournalEntryDocNumberLabel.Dock = System.Windows.Forms.DockStyle.Fill
        AcquisitionJournalEntryDocNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AcquisitionJournalEntryDocNumberLabel.Location = New System.Drawing.Point(243, 26)
        AcquisitionJournalEntryDocNumberLabel.Name = "AcquisitionJournalEntryDocNumberLabel"
        AcquisitionJournalEntryDocNumberLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        AcquisitionJournalEntryDocNumberLabel.Size = New System.Drawing.Size(96, 26)
        AcquisitionJournalEntryDocNumberLabel.TabIndex = 18
        AcquisitionJournalEntryDocNumberLabel.Text = "Dok. Nr.:"
        AcquisitionJournalEntryDocNumberLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AcquisitionDateLabel
        '
        AcquisitionDateLabel.AutoSize = True
        AcquisitionDateLabel.Dock = System.Windows.Forms.DockStyle.Fill
        AcquisitionDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AcquisitionDateLabel.Location = New System.Drawing.Point(3, 26)
        AcquisitionDateLabel.Name = "AcquisitionDateLabel"
        AcquisitionDateLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        AcquisitionDateLabel.Size = New System.Drawing.Size(85, 26)
        AcquisitionDateLabel.TabIndex = 20
        AcquisitionDateLabel.Text = "Įsigijimo data:"
        AcquisitionDateLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AccountAcquisitionLabel
        '
        AccountAcquisitionLabel.AutoSize = True
        AccountAcquisitionLabel.Dock = System.Windows.Forms.DockStyle.Fill
        AccountAcquisitionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountAcquisitionLabel.Location = New System.Drawing.Point(3, 26)
        AccountAcquisitionLabel.Name = "AccountAcquisitionLabel"
        AccountAcquisitionLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        AccountAcquisitionLabel.Size = New System.Drawing.Size(147, 26)
        AccountAcquisitionLabel.TabIndex = 22
        AccountAcquisitionLabel.Text = "Įsig. Savikaina:"
        AccountAcquisitionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AccountAccumulatedAmortizationLabel
        '
        AccountAccumulatedAmortizationLabel.AutoSize = True
        AccountAccumulatedAmortizationLabel.Dock = System.Windows.Forms.DockStyle.Fill
        AccountAccumulatedAmortizationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountAccumulatedAmortizationLabel.Location = New System.Drawing.Point(3, 52)
        AccountAccumulatedAmortizationLabel.Name = "AccountAccumulatedAmortizationLabel"
        AccountAccumulatedAmortizationLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        AccountAccumulatedAmortizationLabel.Size = New System.Drawing.Size(147, 26)
        AccountAccumulatedAmortizationLabel.TabIndex = 23
        AccountAccumulatedAmortizationLabel.Text = "Įsig. Savik. Amortizacija:"
        AccountAccumulatedAmortizationLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AccountValueDecreaseLabel
        '
        AccountValueDecreaseLabel.AutoSize = True
        AccountValueDecreaseLabel.Dock = System.Windows.Forms.DockStyle.Fill
        AccountValueDecreaseLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountValueDecreaseLabel.Location = New System.Drawing.Point(3, 78)
        AccountValueDecreaseLabel.Name = "AccountValueDecreaseLabel"
        AccountValueDecreaseLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        AccountValueDecreaseLabel.Size = New System.Drawing.Size(147, 26)
        AccountValueDecreaseLabel.TabIndex = 25
        AccountValueDecreaseLabel.Text = "Vertės sumaž.:"
        AccountValueDecreaseLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AccountValueIncreaseLabel
        '
        AccountValueIncreaseLabel.AutoSize = True
        AccountValueIncreaseLabel.Dock = System.Windows.Forms.DockStyle.Fill
        AccountValueIncreaseLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountValueIncreaseLabel.Location = New System.Drawing.Point(3, 104)
        AccountValueIncreaseLabel.Name = "AccountValueIncreaseLabel"
        AccountValueIncreaseLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        AccountValueIncreaseLabel.Size = New System.Drawing.Size(147, 26)
        AccountValueIncreaseLabel.TabIndex = 27
        AccountValueIncreaseLabel.Text = "Pervertinimo:"
        AccountValueIncreaseLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AccountRevaluedPortionAmmortizationLabel
        '
        AccountRevaluedPortionAmmortizationLabel.AutoSize = True
        AccountRevaluedPortionAmmortizationLabel.Dock = System.Windows.Forms.DockStyle.Fill
        AccountRevaluedPortionAmmortizationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountRevaluedPortionAmmortizationLabel.Location = New System.Drawing.Point(3, 130)
        AccountRevaluedPortionAmmortizationLabel.Name = "AccountRevaluedPortionAmmortizationLabel"
        AccountRevaluedPortionAmmortizationLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        AccountRevaluedPortionAmmortizationLabel.Size = New System.Drawing.Size(147, 26)
        AccountRevaluedPortionAmmortizationLabel.TabIndex = 29
        AccountRevaluedPortionAmmortizationLabel.Text = "Pervert. dalies amort.:"
        AccountRevaluedPortionAmmortizationLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AmmountLabel
        '
        AmmountLabel.AutoSize = True
        AmmountLabel.Dock = System.Windows.Forms.DockStyle.Fill
        AmmountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AmmountLabel.Location = New System.Drawing.Point(3, 182)
        AmmountLabel.Name = "AmmountLabel"
        AmmountLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        AmmountLabel.Size = New System.Drawing.Size(147, 26)
        AmmountLabel.TabIndex = 48
        AmmountLabel.Text = "Kiekis:"
        AmmountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ValueLabel
        '
        ValueLabel.AutoSize = True
        ValueLabel.Dock = System.Windows.Forms.DockStyle.Fill
        ValueLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ValueLabel.Location = New System.Drawing.Point(3, 156)
        ValueLabel.Name = "ValueLabel"
        ValueLabel.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        ValueLabel.Size = New System.Drawing.Size(147, 26)
        ValueLabel.TabIndex = 50
        ValueLabel.Text = "Balansinė Vertė:"
        ValueLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Label4.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Label4, 3)
        Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label4.Location = New System.Drawing.Point(257, 0)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(206, 13)
        Label4.TabIndex = 43
        Label4.Text = "Vertės Įsigijimo Dienai"
        Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label5
        '
        Label5.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Label5, 3)
        Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label5.Location = New System.Drawing.Point(489, 0)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(206, 13)
        Label5.TabIndex = 44
        Label5.Text = "Einamosios Vertės"
        Label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.Location = New System.Drawing.Point(257, 13)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(95, 13)
        Label6.TabIndex = 45
        Label6.Text = "Viso"
        Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.Location = New System.Drawing.Point(368, 13)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(95, 13)
        Label7.TabIndex = 46
        Label7.Text = "Vienetui"
        Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.Location = New System.Drawing.Point(489, 13)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(95, 13)
        Label8.TabIndex = 47
        Label8.Text = "Viso"
        Label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label9.Location = New System.Drawing.Point(600, 13)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(95, 13)
        Label9.TabIndex = 48
        Label9.Text = "Vienetui"
        Label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'RefreshButton
        '
        Me.RefreshButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RefreshButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Button_Reload_icon_24p
        Me.RefreshButton.Location = New System.Drawing.Point(729, 333)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(33, 33)
        Me.RefreshButton.TabIndex = 0
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'ValueAccBox
        '
        Me.ValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "Value", True))
        Me.ValueAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ValueAccBox.Location = New System.Drawing.Point(257, 159)
        Me.ValueAccBox.Name = "ValueAccBox"
        Me.ValueAccBox.NegativeValue = False
        Me.ValueAccBox.ReadOnly = True
        Me.ValueAccBox.Size = New System.Drawing.Size(95, 20)
        Me.ValueAccBox.TabIndex = 54
        Me.ValueAccBox.TabStop = False
        Me.ValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LongTermAssetOperationInfoListParentBindingSource
        '
        Me.LongTermAssetOperationInfoListParentBindingSource.DataSource = GetType(ApskaitaObjects.ActiveReports.LongTermAssetOperationInfoListParent)
        '
        'ValuePerUnitAccBox
        '
        Me.ValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "ValuePerUnit", True))
        Me.ValuePerUnitAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ValuePerUnitAccBox.Location = New System.Drawing.Point(368, 159)
        Me.ValuePerUnitAccBox.Name = "ValuePerUnitAccBox"
        Me.ValuePerUnitAccBox.NegativeValue = False
        Me.ValuePerUnitAccBox.ReadOnly = True
        Me.ValuePerUnitAccBox.Size = New System.Drawing.Size(95, 20)
        Me.ValuePerUnitAccBox.TabIndex = 53
        Me.ValuePerUnitAccBox.TabStop = False
        Me.ValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AmmountTextBox
        '
        Me.AmmountTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.AmmountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationInfoListParentBindingSource, "Ammount", True))
        Me.AmmountTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AmmountTextBox.Location = New System.Drawing.Point(257, 185)
        Me.AmmountTextBox.Name = "AmmountTextBox"
        Me.AmmountTextBox.ReadOnly = True
        Me.AmmountTextBox.Size = New System.Drawing.Size(95, 20)
        Me.AmmountTextBox.TabIndex = 49
        Me.AmmountTextBox.TabStop = False
        Me.AmmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ValueIncreaseAmmortizationAccountValuePerUnitAccBox
        '
        Me.ValueIncreaseAmmortizationAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "ValueIncreaseAmmortizationAccountValuePerUnit", True))
        Me.ValueIncreaseAmmortizationAccountValuePerUnitAccBox.DecimalLength = 4
        Me.ValueIncreaseAmmortizationAccountValuePerUnitAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ValueIncreaseAmmortizationAccountValuePerUnitAccBox.Location = New System.Drawing.Point(368, 133)
        Me.ValueIncreaseAmmortizationAccountValuePerUnitAccBox.Name = "ValueIncreaseAmmortizationAccountValuePerUnitAccBox"
        Me.ValueIncreaseAmmortizationAccountValuePerUnitAccBox.NegativeValue = False
        Me.ValueIncreaseAmmortizationAccountValuePerUnitAccBox.ReadOnly = True
        Me.ValueIncreaseAmmortizationAccountValuePerUnitAccBox.Size = New System.Drawing.Size(95, 20)
        Me.ValueIncreaseAmmortizationAccountValuePerUnitAccBox.TabIndex = 47
        Me.ValueIncreaseAmmortizationAccountValuePerUnitAccBox.TabStop = False
        Me.ValueIncreaseAmmortizationAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ValueIncreaseAccountValuePerUnitAccBox
        '
        Me.ValueIncreaseAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "ValueIncreaseAccountValuePerUnit", True))
        Me.ValueIncreaseAccountValuePerUnitAccBox.DecimalLength = 4
        Me.ValueIncreaseAccountValuePerUnitAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ValueIncreaseAccountValuePerUnitAccBox.Location = New System.Drawing.Point(368, 107)
        Me.ValueIncreaseAccountValuePerUnitAccBox.Name = "ValueIncreaseAccountValuePerUnitAccBox"
        Me.ValueIncreaseAccountValuePerUnitAccBox.NegativeValue = False
        Me.ValueIncreaseAccountValuePerUnitAccBox.ReadOnly = True
        Me.ValueIncreaseAccountValuePerUnitAccBox.Size = New System.Drawing.Size(95, 20)
        Me.ValueIncreaseAccountValuePerUnitAccBox.TabIndex = 46
        Me.ValueIncreaseAccountValuePerUnitAccBox.TabStop = False
        Me.ValueIncreaseAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ValueDecreaseAccountValuePerUnitAccBox
        '
        Me.ValueDecreaseAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "ValueDecreaseAccountValuePerUnit", True))
        Me.ValueDecreaseAccountValuePerUnitAccBox.DecimalLength = 4
        Me.ValueDecreaseAccountValuePerUnitAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ValueDecreaseAccountValuePerUnitAccBox.Location = New System.Drawing.Point(368, 81)
        Me.ValueDecreaseAccountValuePerUnitAccBox.Name = "ValueDecreaseAccountValuePerUnitAccBox"
        Me.ValueDecreaseAccountValuePerUnitAccBox.ReadOnly = True
        Me.ValueDecreaseAccountValuePerUnitAccBox.Size = New System.Drawing.Size(95, 20)
        Me.ValueDecreaseAccountValuePerUnitAccBox.TabIndex = 45
        Me.ValueDecreaseAccountValuePerUnitAccBox.TabStop = False
        Me.ValueDecreaseAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AmortizationAccountValuePerUnitAccBox
        '
        Me.AmortizationAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "AmortizationAccountValuePerUnit", True))
        Me.AmortizationAccountValuePerUnitAccBox.DecimalLength = 4
        Me.AmortizationAccountValuePerUnitAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AmortizationAccountValuePerUnitAccBox.Location = New System.Drawing.Point(368, 55)
        Me.AmortizationAccountValuePerUnitAccBox.Name = "AmortizationAccountValuePerUnitAccBox"
        Me.AmortizationAccountValuePerUnitAccBox.NegativeValue = False
        Me.AmortizationAccountValuePerUnitAccBox.ReadOnly = True
        Me.AmortizationAccountValuePerUnitAccBox.Size = New System.Drawing.Size(95, 20)
        Me.AmortizationAccountValuePerUnitAccBox.TabIndex = 44
        Me.AmortizationAccountValuePerUnitAccBox.TabStop = False
        Me.AmortizationAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AcquisitionAccountValuePerUnitAccBox
        '
        Me.AcquisitionAccountValuePerUnitAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "AcquisitionAccountValuePerUnit", True))
        Me.AcquisitionAccountValuePerUnitAccBox.DecimalLength = 4
        Me.AcquisitionAccountValuePerUnitAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AcquisitionAccountValuePerUnitAccBox.Location = New System.Drawing.Point(368, 29)
        Me.AcquisitionAccountValuePerUnitAccBox.Name = "AcquisitionAccountValuePerUnitAccBox"
        Me.AcquisitionAccountValuePerUnitAccBox.NegativeValue = False
        Me.AcquisitionAccountValuePerUnitAccBox.ReadOnly = True
        Me.AcquisitionAccountValuePerUnitAccBox.Size = New System.Drawing.Size(95, 20)
        Me.AcquisitionAccountValuePerUnitAccBox.TabIndex = 43
        Me.AcquisitionAccountValuePerUnitAccBox.TabStop = False
        Me.AcquisitionAccountValuePerUnitAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ValueIncreaseAmmortizationAccountValueAccBox
        '
        Me.ValueIncreaseAmmortizationAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "ValueIncreaseAmmortizationAccountValue", True))
        Me.ValueIncreaseAmmortizationAccountValueAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ValueIncreaseAmmortizationAccountValueAccBox.Location = New System.Drawing.Point(257, 133)
        Me.ValueIncreaseAmmortizationAccountValueAccBox.Name = "ValueIncreaseAmmortizationAccountValueAccBox"
        Me.ValueIncreaseAmmortizationAccountValueAccBox.NegativeValue = False
        Me.ValueIncreaseAmmortizationAccountValueAccBox.ReadOnly = True
        Me.ValueIncreaseAmmortizationAccountValueAccBox.Size = New System.Drawing.Size(95, 20)
        Me.ValueIncreaseAmmortizationAccountValueAccBox.TabIndex = 41
        Me.ValueIncreaseAmmortizationAccountValueAccBox.TabStop = False
        Me.ValueIncreaseAmmortizationAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ValueIncreaseAccountValueAccBox
        '
        Me.ValueIncreaseAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "ValueIncreaseAccountValue", True))
        Me.ValueIncreaseAccountValueAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ValueIncreaseAccountValueAccBox.Location = New System.Drawing.Point(257, 107)
        Me.ValueIncreaseAccountValueAccBox.Name = "ValueIncreaseAccountValueAccBox"
        Me.ValueIncreaseAccountValueAccBox.NegativeValue = False
        Me.ValueIncreaseAccountValueAccBox.ReadOnly = True
        Me.ValueIncreaseAccountValueAccBox.Size = New System.Drawing.Size(95, 20)
        Me.ValueIncreaseAccountValueAccBox.TabIndex = 39
        Me.ValueIncreaseAccountValueAccBox.TabStop = False
        Me.ValueIncreaseAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ValueDecreaseAccountValueAccBox
        '
        Me.ValueDecreaseAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "ValueDecreaseAccountValue", True))
        Me.ValueDecreaseAccountValueAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ValueDecreaseAccountValueAccBox.Location = New System.Drawing.Point(257, 81)
        Me.ValueDecreaseAccountValueAccBox.Name = "ValueDecreaseAccountValueAccBox"
        Me.ValueDecreaseAccountValueAccBox.NegativeValue = False
        Me.ValueDecreaseAccountValueAccBox.ReadOnly = True
        Me.ValueDecreaseAccountValueAccBox.Size = New System.Drawing.Size(95, 20)
        Me.ValueDecreaseAccountValueAccBox.TabIndex = 37
        Me.ValueDecreaseAccountValueAccBox.TabStop = False
        Me.ValueDecreaseAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AmortizationAccountValueAccBox
        '
        Me.AmortizationAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "AmortizationAccountValue", True))
        Me.AmortizationAccountValueAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AmortizationAccountValueAccBox.Location = New System.Drawing.Point(257, 55)
        Me.AmortizationAccountValueAccBox.Name = "AmortizationAccountValueAccBox"
        Me.AmortizationAccountValueAccBox.NegativeValue = False
        Me.AmortizationAccountValueAccBox.ReadOnly = True
        Me.AmortizationAccountValueAccBox.Size = New System.Drawing.Size(95, 20)
        Me.AmortizationAccountValueAccBox.TabIndex = 35
        Me.AmortizationAccountValueAccBox.TabStop = False
        Me.AmortizationAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AcquisitionAccountValueAccBox
        '
        Me.AcquisitionAccountValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "AcquisitionAccountValue", True))
        Me.AcquisitionAccountValueAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AcquisitionAccountValueAccBox.Location = New System.Drawing.Point(257, 29)
        Me.AcquisitionAccountValueAccBox.Name = "AcquisitionAccountValueAccBox"
        Me.AcquisitionAccountValueAccBox.NegativeValue = False
        Me.AcquisitionAccountValueAccBox.ReadOnly = True
        Me.AcquisitionAccountValueAccBox.Size = New System.Drawing.Size(95, 20)
        Me.AcquisitionAccountValueAccBox.TabIndex = 33
        Me.AcquisitionAccountValueAccBox.TabStop = False
        Me.AcquisitionAccountValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccountRevaluedPortionAmmortizationTextBox
        '
        Me.AccountRevaluedPortionAmmortizationTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.AccountRevaluedPortionAmmortizationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationInfoListParentBindingSource, "AccountRevaluedPortionAmmortization", True))
        Me.AccountRevaluedPortionAmmortizationTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountRevaluedPortionAmmortizationTextBox.Location = New System.Drawing.Point(156, 133)
        Me.AccountRevaluedPortionAmmortizationTextBox.Name = "AccountRevaluedPortionAmmortizationTextBox"
        Me.AccountRevaluedPortionAmmortizationTextBox.ReadOnly = True
        Me.AccountRevaluedPortionAmmortizationTextBox.Size = New System.Drawing.Size(95, 20)
        Me.AccountRevaluedPortionAmmortizationTextBox.TabIndex = 30
        Me.AccountRevaluedPortionAmmortizationTextBox.TabStop = False
        Me.AccountRevaluedPortionAmmortizationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccountValueIncreaseTextBox
        '
        Me.AccountValueIncreaseTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.AccountValueIncreaseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationInfoListParentBindingSource, "AccountValueIncrease", True))
        Me.AccountValueIncreaseTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountValueIncreaseTextBox.Location = New System.Drawing.Point(156, 107)
        Me.AccountValueIncreaseTextBox.Name = "AccountValueIncreaseTextBox"
        Me.AccountValueIncreaseTextBox.ReadOnly = True
        Me.AccountValueIncreaseTextBox.Size = New System.Drawing.Size(95, 20)
        Me.AccountValueIncreaseTextBox.TabIndex = 28
        Me.AccountValueIncreaseTextBox.TabStop = False
        Me.AccountValueIncreaseTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccountValueDecreaseTextBox
        '
        Me.AccountValueDecreaseTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.AccountValueDecreaseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationInfoListParentBindingSource, "AccountValueDecrease", True))
        Me.AccountValueDecreaseTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountValueDecreaseTextBox.Location = New System.Drawing.Point(156, 81)
        Me.AccountValueDecreaseTextBox.Name = "AccountValueDecreaseTextBox"
        Me.AccountValueDecreaseTextBox.ReadOnly = True
        Me.AccountValueDecreaseTextBox.Size = New System.Drawing.Size(95, 20)
        Me.AccountValueDecreaseTextBox.TabIndex = 26
        Me.AccountValueDecreaseTextBox.TabStop = False
        Me.AccountValueDecreaseTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccountAccumulatedAmortizationTextBox
        '
        Me.AccountAccumulatedAmortizationTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.AccountAccumulatedAmortizationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationInfoListParentBindingSource, "AccountAccumulatedAmortization", True))
        Me.AccountAccumulatedAmortizationTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountAccumulatedAmortizationTextBox.Location = New System.Drawing.Point(156, 55)
        Me.AccountAccumulatedAmortizationTextBox.Name = "AccountAccumulatedAmortizationTextBox"
        Me.AccountAccumulatedAmortizationTextBox.ReadOnly = True
        Me.AccountAccumulatedAmortizationTextBox.Size = New System.Drawing.Size(95, 20)
        Me.AccountAccumulatedAmortizationTextBox.TabIndex = 24
        Me.AccountAccumulatedAmortizationTextBox.TabStop = False
        Me.AccountAccumulatedAmortizationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AccountAcquisitionTextBox
        '
        Me.AccountAcquisitionTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.AccountAcquisitionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationInfoListParentBindingSource, "AccountAcquisition", True))
        Me.AccountAcquisitionTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountAcquisitionTextBox.Location = New System.Drawing.Point(156, 29)
        Me.AccountAcquisitionTextBox.Name = "AccountAcquisitionTextBox"
        Me.AccountAcquisitionTextBox.ReadOnly = True
        Me.AccountAcquisitionTextBox.Size = New System.Drawing.Size(95, 20)
        Me.AccountAcquisitionTextBox.TabIndex = 23
        Me.AccountAcquisitionTextBox.TabStop = False
        Me.AccountAcquisitionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LiquidationUnitValueAccBox
        '
        Me.LiquidationUnitValueAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "LiquidationUnitValue", True))
        Me.LiquidationUnitValueAccBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LiquidationUnitValueAccBox.Location = New System.Drawing.Point(345, 111)
        Me.LiquidationUnitValueAccBox.Name = "LiquidationUnitValueAccBox"
        Me.LiquidationUnitValueAccBox.NegativeValue = False
        Me.LiquidationUnitValueAccBox.ReadOnly = True
        Me.LiquidationUnitValueAccBox.Size = New System.Drawing.Size(123, 20)
        Me.LiquidationUnitValueAccBox.TabIndex = 22
        Me.LiquidationUnitValueAccBox.TabStop = False
        Me.LiquidationUnitValueAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AcquisitionDateDateTimePicker
        '
        Me.AcquisitionDateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.LongTermAssetOperationInfoListParentBindingSource, "AcquisitionDate", True))
        Me.AcquisitionDateDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AcquisitionDateDateTimePicker.Enabled = False
        Me.AcquisitionDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.AcquisitionDateDateTimePicker.Location = New System.Drawing.Point(94, 29)
        Me.AcquisitionDateDateTimePicker.Name = "AcquisitionDateDateTimePicker"
        Me.AcquisitionDateDateTimePicker.Size = New System.Drawing.Size(123, 20)
        Me.AcquisitionDateDateTimePicker.TabIndex = 21
        Me.AcquisitionDateDateTimePicker.TabStop = False
        '
        'AcquisitionJournalEntryDocNumberTextBox
        '
        Me.AcquisitionJournalEntryDocNumberTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.AcquisitionJournalEntryDocNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationInfoListParentBindingSource, "AcquisitionJournalEntryDocNumber", True))
        Me.AcquisitionJournalEntryDocNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AcquisitionJournalEntryDocNumberTextBox.Location = New System.Drawing.Point(345, 29)
        Me.AcquisitionJournalEntryDocNumberTextBox.Name = "AcquisitionJournalEntryDocNumberTextBox"
        Me.AcquisitionJournalEntryDocNumberTextBox.ReadOnly = True
        Me.AcquisitionJournalEntryDocNumberTextBox.Size = New System.Drawing.Size(123, 20)
        Me.AcquisitionJournalEntryDocNumberTextBox.TabIndex = 19
        Me.AcquisitionJournalEntryDocNumberTextBox.TabStop = False
        Me.AcquisitionJournalEntryDocNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CustomGroupTextBox
        '
        Me.CustomGroupTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel2.SetColumnSpan(Me.CustomGroupTextBox, 4)
        Me.CustomGroupTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationInfoListParentBindingSource, "CustomGroup", True))
        Me.CustomGroupTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomGroupTextBox.Location = New System.Drawing.Point(345, 55)
        Me.CustomGroupTextBox.Name = "CustomGroupTextBox"
        Me.CustomGroupTextBox.ReadOnly = True
        Me.CustomGroupTextBox.Size = New System.Drawing.Size(378, 20)
        Me.CustomGroupTextBox.TabIndex = 15
        Me.CustomGroupTextBox.TabStop = False
        '
        'DefaultAmortizationPeriodTextBox
        '
        Me.DefaultAmortizationPeriodTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.DefaultAmortizationPeriodTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationInfoListParentBindingSource, "DefaultAmortizationPeriod", True))
        Me.DefaultAmortizationPeriodTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DefaultAmortizationPeriodTextBox.Location = New System.Drawing.Point(600, 111)
        Me.DefaultAmortizationPeriodTextBox.Name = "DefaultAmortizationPeriodTextBox"
        Me.DefaultAmortizationPeriodTextBox.ReadOnly = True
        Me.DefaultAmortizationPeriodTextBox.Size = New System.Drawing.Size(123, 20)
        Me.DefaultAmortizationPeriodTextBox.TabIndex = 13
        Me.DefaultAmortizationPeriodTextBox.TabStop = False
        Me.DefaultAmortizationPeriodTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MeasureUnitTextBox
        '
        Me.MeasureUnitTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.MeasureUnitTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationInfoListParentBindingSource, "MeasureUnit", True))
        Me.MeasureUnitTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MeasureUnitTextBox.Location = New System.Drawing.Point(94, 111)
        Me.MeasureUnitTextBox.Name = "MeasureUnitTextBox"
        Me.MeasureUnitTextBox.ReadOnly = True
        Me.MeasureUnitTextBox.Size = New System.Drawing.Size(123, 20)
        Me.MeasureUnitTextBox.TabIndex = 9
        Me.MeasureUnitTextBox.TabStop = False
        Me.MeasureUnitTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LegalGroupTextBox
        '
        Me.LegalGroupTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel2.SetColumnSpan(Me.LegalGroupTextBox, 4)
        Me.LegalGroupTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationInfoListParentBindingSource, "LegalGroup", True))
        Me.LegalGroupTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LegalGroupTextBox.Location = New System.Drawing.Point(94, 81)
        Me.LegalGroupTextBox.Name = "LegalGroupTextBox"
        Me.LegalGroupTextBox.ReadOnly = True
        Me.LegalGroupTextBox.Size = New System.Drawing.Size(374, 20)
        Me.LegalGroupTextBox.TabIndex = 7
        Me.LegalGroupTextBox.TabStop = False
        '
        'InventoryNumberTextBox
        '
        Me.InventoryNumberTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.InventoryNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationInfoListParentBindingSource, "InventoryNumber", True))
        Me.InventoryNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InventoryNumberTextBox.Location = New System.Drawing.Point(94, 55)
        Me.InventoryNumberTextBox.Name = "InventoryNumberTextBox"
        Me.InventoryNumberTextBox.ReadOnly = True
        Me.InventoryNumberTextBox.Size = New System.Drawing.Size(123, 20)
        Me.InventoryNumberTextBox.TabIndex = 5
        Me.InventoryNumberTextBox.TabStop = False
        Me.InventoryNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IDTextBox
        '
        Me.IDTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationInfoListParentBindingSource, "ID", True))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Location = New System.Drawing.Point(600, 29)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(123, 20)
        Me.IDTextBox.TabIndex = 3
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NameTextBox
        '
        Me.NameTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel2.SetColumnSpan(Me.NameTextBox, 7)
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LongTermAssetOperationInfoListParentBindingSource, "Name", True))
        Me.NameTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NameTextBox.Location = New System.Drawing.Point(94, 3)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.ReadOnly = True
        Me.NameTextBox.Size = New System.Drawing.Size(629, 20)
        Me.NameTextBox.TabIndex = 1
        Me.NameTextBox.TabStop = False
        '
        'OperationListBindingSource
        '
        Me.OperationListBindingSource.DataMember = "OperationList"
        Me.OperationListBindingSource.DataSource = Me.LongTermAssetOperationInfoListParentBindingSource
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeItem_MenuItem, Me.DeleteItem_MenuItem, Me.NewOperation_MenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(159, 92)
        '
        'ChangeItem_MenuItem
        '
        Me.ChangeItem_MenuItem.Name = "ChangeItem_MenuItem"
        Me.ChangeItem_MenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ChangeItem_MenuItem.Text = "Keisti"
        '
        'DeleteItem_MenuItem
        '
        Me.DeleteItem_MenuItem.Name = "DeleteItem_MenuItem"
        Me.DeleteItem_MenuItem.Size = New System.Drawing.Size(158, 22)
        Me.DeleteItem_MenuItem.Text = "Ištrinti"
        '
        'NewOperation_MenuItem
        '
        Me.NewOperation_MenuItem.Name = "NewOperation_MenuItem"
        Me.NewOperation_MenuItem.Size = New System.Drawing.Size(158, 22)
        Me.NewOperation_MenuItem.Text = "Nauja Operacija"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 10
        Me.TableLayoutPanel2.SetColumnSpan(Me.TableLayoutPanel1, 8)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.Controls.Add(Label4, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CurrentValueIncreaseAmmortizationAccountValuePerUnitAccTextBox, 8, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.CurrentValueIncreaseAmmortizationAccountValueAccTextBox, 6, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.CurrentValueIncreaseAccountValuePerUnitAccTextBox, 8, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.CurrentValueIncreaseAccountValueAccTextBox, 6, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.CurrentValueDecreaseAccountValuePerUnitAccTextBox, 8, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.CurrentValueDecreaseAccountValueAccTextBox, 6, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.CurrentValuePerUnitAccTextBox, 8, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.CurrentValueAccTextBox, 6, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.CurrentAmountAccTextBox, 6, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.CurrentAmortizationAccountValuePerUnitAccTextBox, 8, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CurrentAmortizationAccountValueAccTextBox, 6, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.CurrentAcquisitionAccountValuePerUnitAccTextBox, 8, 2)
        Me.TableLayoutPanel1.Controls.Add(Label5, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.AmmountTextBox, 2, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.CurrentAcquisitionAccountValueAccTextBox, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(AmmountLabel, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Label6, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ValuePerUnitAccBox, 4, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.ValueAccBox, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Label7, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Label8, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Label9, 8, 1)
        Me.TableLayoutPanel1.Controls.Add(AccountAcquisitionLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(ValueLabel, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.AccountAcquisitionTextBox, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.AcquisitionAccountValueAccBox, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.AcquisitionAccountValuePerUnitAccBox, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(AccountAccumulatedAmortizationLabel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.AccountAccumulatedAmortizationTextBox, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ValueIncreaseAmmortizationAccountValuePerUnitAccBox, 4, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.AmortizationAccountValueAccBox, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ValueIncreaseAccountValuePerUnitAccBox, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ValueIncreaseAmmortizationAccountValueAccBox, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.AmortizationAccountValuePerUnitAccBox, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.AccountRevaluedPortionAmmortizationTextBox, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.ValueDecreaseAccountValuePerUnitAccBox, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(AccountValueDecreaseLabel, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(AccountRevaluedPortionAmmortizationLabel, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.ValueIncreaseAccountValueAccBox, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.AccountValueDecreaseTextBox, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ValueDecreaseAccountValueAccBox, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(AccountValueIncreaseLabel, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.AccountValueIncreaseTextBox, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.AssetInfoListAccListComboBox, 4, 9)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 137)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(720, 229)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'CurrentValueIncreaseAmmortizationAccountValuePerUnitAccTextBox
        '
        Me.CurrentValueIncreaseAmmortizationAccountValuePerUnitAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "CurrentValueIncreaseAmmortizationAccountValuePerUnit", True))
        Me.CurrentValueIncreaseAmmortizationAccountValuePerUnitAccTextBox.DecimalLength = 4
        Me.CurrentValueIncreaseAmmortizationAccountValuePerUnitAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentValueIncreaseAmmortizationAccountValuePerUnitAccTextBox.Location = New System.Drawing.Point(600, 133)
        Me.CurrentValueIncreaseAmmortizationAccountValuePerUnitAccTextBox.Name = "CurrentValueIncreaseAmmortizationAccountValuePerUnitAccTextBox"
        Me.CurrentValueIncreaseAmmortizationAccountValuePerUnitAccTextBox.Size = New System.Drawing.Size(95, 20)
        Me.CurrentValueIncreaseAmmortizationAccountValuePerUnitAccTextBox.TabIndex = 25
        Me.CurrentValueIncreaseAmmortizationAccountValuePerUnitAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentValueIncreaseAmmortizationAccountValueAccTextBox
        '
        Me.CurrentValueIncreaseAmmortizationAccountValueAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "CurrentValueIncreaseAmmortizationAccountValue", True))
        Me.CurrentValueIncreaseAmmortizationAccountValueAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentValueIncreaseAmmortizationAccountValueAccTextBox.Location = New System.Drawing.Point(489, 133)
        Me.CurrentValueIncreaseAmmortizationAccountValueAccTextBox.Name = "CurrentValueIncreaseAmmortizationAccountValueAccTextBox"
        Me.CurrentValueIncreaseAmmortizationAccountValueAccTextBox.Size = New System.Drawing.Size(95, 20)
        Me.CurrentValueIncreaseAmmortizationAccountValueAccTextBox.TabIndex = 23
        Me.CurrentValueIncreaseAmmortizationAccountValueAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentValueIncreaseAccountValuePerUnitAccTextBox
        '
        Me.CurrentValueIncreaseAccountValuePerUnitAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "CurrentValueIncreaseAccountValuePerUnit", True))
        Me.CurrentValueIncreaseAccountValuePerUnitAccTextBox.DecimalLength = 4
        Me.CurrentValueIncreaseAccountValuePerUnitAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentValueIncreaseAccountValuePerUnitAccTextBox.Location = New System.Drawing.Point(600, 107)
        Me.CurrentValueIncreaseAccountValuePerUnitAccTextBox.Name = "CurrentValueIncreaseAccountValuePerUnitAccTextBox"
        Me.CurrentValueIncreaseAccountValuePerUnitAccTextBox.Size = New System.Drawing.Size(95, 20)
        Me.CurrentValueIncreaseAccountValuePerUnitAccTextBox.TabIndex = 25
        Me.CurrentValueIncreaseAccountValuePerUnitAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentValueIncreaseAccountValueAccTextBox
        '
        Me.CurrentValueIncreaseAccountValueAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "CurrentValueIncreaseAccountValue", True))
        Me.CurrentValueIncreaseAccountValueAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentValueIncreaseAccountValueAccTextBox.Location = New System.Drawing.Point(489, 107)
        Me.CurrentValueIncreaseAccountValueAccTextBox.Name = "CurrentValueIncreaseAccountValueAccTextBox"
        Me.CurrentValueIncreaseAccountValueAccTextBox.Size = New System.Drawing.Size(95, 20)
        Me.CurrentValueIncreaseAccountValueAccTextBox.TabIndex = 23
        Me.CurrentValueIncreaseAccountValueAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentValueDecreaseAccountValuePerUnitAccTextBox
        '
        Me.CurrentValueDecreaseAccountValuePerUnitAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "CurrentValueDecreaseAccountValuePerUnit", True))
        Me.CurrentValueDecreaseAccountValuePerUnitAccTextBox.DecimalLength = 4
        Me.CurrentValueDecreaseAccountValuePerUnitAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentValueDecreaseAccountValuePerUnitAccTextBox.Location = New System.Drawing.Point(600, 81)
        Me.CurrentValueDecreaseAccountValuePerUnitAccTextBox.Name = "CurrentValueDecreaseAccountValuePerUnitAccTextBox"
        Me.CurrentValueDecreaseAccountValuePerUnitAccTextBox.Size = New System.Drawing.Size(95, 20)
        Me.CurrentValueDecreaseAccountValuePerUnitAccTextBox.TabIndex = 25
        Me.CurrentValueDecreaseAccountValuePerUnitAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentValueDecreaseAccountValueAccTextBox
        '
        Me.CurrentValueDecreaseAccountValueAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "CurrentValueDecreaseAccountValue", True))
        Me.CurrentValueDecreaseAccountValueAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentValueDecreaseAccountValueAccTextBox.Location = New System.Drawing.Point(489, 81)
        Me.CurrentValueDecreaseAccountValueAccTextBox.Name = "CurrentValueDecreaseAccountValueAccTextBox"
        Me.CurrentValueDecreaseAccountValueAccTextBox.Size = New System.Drawing.Size(95, 20)
        Me.CurrentValueDecreaseAccountValueAccTextBox.TabIndex = 23
        Me.CurrentValueDecreaseAccountValueAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentValuePerUnitAccTextBox
        '
        Me.CurrentValuePerUnitAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "CurrentValuePerUnit", True))
        Me.CurrentValuePerUnitAccTextBox.DecimalLength = 4
        Me.CurrentValuePerUnitAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentValuePerUnitAccTextBox.Location = New System.Drawing.Point(600, 159)
        Me.CurrentValuePerUnitAccTextBox.Name = "CurrentValuePerUnitAccTextBox"
        Me.CurrentValuePerUnitAccTextBox.Size = New System.Drawing.Size(95, 20)
        Me.CurrentValuePerUnitAccTextBox.TabIndex = 25
        Me.CurrentValuePerUnitAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentValueAccTextBox
        '
        Me.CurrentValueAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "CurrentValue", True))
        Me.CurrentValueAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentValueAccTextBox.Location = New System.Drawing.Point(489, 159)
        Me.CurrentValueAccTextBox.Name = "CurrentValueAccTextBox"
        Me.CurrentValueAccTextBox.Size = New System.Drawing.Size(95, 20)
        Me.CurrentValueAccTextBox.TabIndex = 23
        Me.CurrentValueAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAmountAccTextBox
        '
        Me.CurrentAmountAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "CurrentAmount", True))
        Me.CurrentAmountAccTextBox.DecimalLength = 0
        Me.CurrentAmountAccTextBox.Location = New System.Drawing.Point(489, 185)
        Me.CurrentAmountAccTextBox.Name = "CurrentAmountAccTextBox"
        Me.CurrentAmountAccTextBox.Size = New System.Drawing.Size(95, 20)
        Me.CurrentAmountAccTextBox.TabIndex = 23
        Me.CurrentAmountAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAmortizationAccountValuePerUnitAccTextBox
        '
        Me.CurrentAmortizationAccountValuePerUnitAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "CurrentAmortizationAccountValuePerUnit", True))
        Me.CurrentAmortizationAccountValuePerUnitAccTextBox.DecimalLength = 4
        Me.CurrentAmortizationAccountValuePerUnitAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentAmortizationAccountValuePerUnitAccTextBox.Location = New System.Drawing.Point(600, 55)
        Me.CurrentAmortizationAccountValuePerUnitAccTextBox.Name = "CurrentAmortizationAccountValuePerUnitAccTextBox"
        Me.CurrentAmortizationAccountValuePerUnitAccTextBox.Size = New System.Drawing.Size(95, 20)
        Me.CurrentAmortizationAccountValuePerUnitAccTextBox.TabIndex = 25
        Me.CurrentAmortizationAccountValuePerUnitAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAmortizationAccountValueAccTextBox
        '
        Me.CurrentAmortizationAccountValueAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "CurrentAmortizationAccountValue", True))
        Me.CurrentAmortizationAccountValueAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentAmortizationAccountValueAccTextBox.Location = New System.Drawing.Point(489, 55)
        Me.CurrentAmortizationAccountValueAccTextBox.Name = "CurrentAmortizationAccountValueAccTextBox"
        Me.CurrentAmortizationAccountValueAccTextBox.Size = New System.Drawing.Size(95, 20)
        Me.CurrentAmortizationAccountValueAccTextBox.TabIndex = 23
        Me.CurrentAmortizationAccountValueAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAcquisitionAccountValuePerUnitAccTextBox
        '
        Me.CurrentAcquisitionAccountValuePerUnitAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "CurrentAcquisitionAccountValuePerUnit", True))
        Me.CurrentAcquisitionAccountValuePerUnitAccTextBox.DecimalLength = 4
        Me.CurrentAcquisitionAccountValuePerUnitAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentAcquisitionAccountValuePerUnitAccTextBox.Location = New System.Drawing.Point(600, 29)
        Me.CurrentAcquisitionAccountValuePerUnitAccTextBox.Name = "CurrentAcquisitionAccountValuePerUnitAccTextBox"
        Me.CurrentAcquisitionAccountValuePerUnitAccTextBox.Size = New System.Drawing.Size(95, 20)
        Me.CurrentAcquisitionAccountValuePerUnitAccTextBox.TabIndex = 25
        Me.CurrentAcquisitionAccountValuePerUnitAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CurrentAcquisitionAccountValueAccTextBox
        '
        Me.CurrentAcquisitionAccountValueAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LongTermAssetOperationInfoListParentBindingSource, "CurrentAcquisitionAccountValue", True))
        Me.CurrentAcquisitionAccountValueAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentAcquisitionAccountValueAccTextBox.Location = New System.Drawing.Point(489, 29)
        Me.CurrentAcquisitionAccountValueAccTextBox.Name = "CurrentAcquisitionAccountValueAccTextBox"
        Me.CurrentAcquisitionAccountValueAccTextBox.Size = New System.Drawing.Size(95, 20)
        Me.CurrentAcquisitionAccountValueAccTextBox.TabIndex = 23
        Me.CurrentAcquisitionAccountValueAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(156, 208)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(196, 21)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Ilgalaikiam Turtui:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'AssetInfoListAccListComboBox
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.AssetInfoListAccListComboBox, 5)
        Me.AssetInfoListAccListComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AssetInfoListAccListComboBox.EmptyValueString = ""
        Me.AssetInfoListAccListComboBox.InstantBinding = True
        Me.AssetInfoListAccListComboBox.Location = New System.Drawing.Point(365, 208)
        Me.AssetInfoListAccListComboBox.Margin = New System.Windows.Forms.Padding(0)
        Me.AssetInfoListAccListComboBox.Name = "AssetInfoListAccListComboBox"
        Me.AssetInfoListAccListComboBox.Size = New System.Drawing.Size(333, 21)
        Me.AssetInfoListAccListComboBox.TabIndex = 56
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.Controls.Add(NameLabel, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.RefreshButton, 8, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.NameTextBox, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DefaultAmortizationPeriodTextBox, 7, 4)
        Me.TableLayoutPanel2.Controls.Add(DefaultAmortizationPeriodLabel, 6, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.LiquidationUnitValueAccBox, 4, 4)
        Me.TableLayoutPanel2.Controls.Add(AcquisitionDateLabel, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.AcquisitionJournalEntryDocNumberTextBox, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(LiquidationUnitValueLabel, 3, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.CustomGroupTextBox, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.MeasureUnitTextBox, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(MeasureUnitLabel, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(CustomGroupLabel, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(AcquisitionJournalEntryDocNumberLabel, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.AcquisitionDateDateTimePicker, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(IDLabel, 6, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LegalGroupTextBox, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(LegalGroupLabel, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.IDTextBox, 7, 1)
        Me.TableLayoutPanel2.Controls.Add(InventoryNumberLabel, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.InventoryNumberTextBox, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.CurrentlyOperationalCheckBox, 6, 3)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(766, 369)
        Me.TableLayoutPanel2.TabIndex = 23
        '
        'CurrentlyOperationalCheckBox
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.CurrentlyOperationalCheckBox, 2)
        Me.CurrentlyOperationalCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.LongTermAssetOperationInfoListParentBindingSource, "CurrentlyOperational", True))
        Me.CurrentlyOperationalCheckBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrentlyOperationalCheckBox.Enabled = False
        Me.CurrentlyOperationalCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentlyOperationalCheckBox.Location = New System.Drawing.Point(494, 81)
        Me.CurrentlyOperationalCheckBox.Name = "CurrentlyOperationalCheckBox"
        Me.CurrentlyOperationalCheckBox.Size = New System.Drawing.Size(229, 24)
        Me.CurrentlyOperationalCheckBox.TabIndex = 23
        Me.CurrentlyOperationalCheckBox.Text = "Eksploatuojamas"
        Me.CurrentlyOperationalCheckBox.UseVisualStyleBackColor = True
        '
        'OperationListDataListView
        '
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn5)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn6)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn7)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn8)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn9)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn10)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn11)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn12)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn13)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn14)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn15)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn16)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn17)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn18)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn19)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn20)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn21)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn22)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn23)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn24)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn25)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn26)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn27)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn28)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn29)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn30)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn31)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn32)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn33)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn34)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn35)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn36)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn37)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn38)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn39)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn40)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn41)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn42)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn43)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn44)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn45)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn46)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn47)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn48)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn49)
        Me.OperationListDataListView.AllColumns.Add(Me.OlvColumn50)
        Me.OperationListDataListView.AllowColumnReorder = True
        Me.OperationListDataListView.AutoGenerateColumns = False
        Me.OperationListDataListView.CausesValidation = False
        Me.OperationListDataListView.CellEditUseWholeCell = False
        Me.OperationListDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2, Me.OlvColumn4, Me.OlvColumn6, Me.OlvColumn8, Me.OlvColumn9, Me.OlvColumn10, Me.OlvColumn11, Me.OlvColumn13, Me.OlvColumn15, Me.OlvColumn17, Me.OlvColumn19, Me.OlvColumn21, Me.OlvColumn22, Me.OlvColumn23, Me.OlvColumn24, Me.OlvColumn26, Me.OlvColumn28, Me.OlvColumn30, Me.OlvColumn32, Me.OlvColumn34, Me.OlvColumn35, Me.OlvColumn36, Me.OlvColumn37, Me.OlvColumn39, Me.OlvColumn41, Me.OlvColumn43, Me.OlvColumn45, Me.OlvColumn47, Me.OlvColumn48, Me.OlvColumn49, Me.OlvColumn50})
        Me.OperationListDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.OperationListDataListView.DataSource = Me.OperationListBindingSource
        Me.OperationListDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OperationListDataListView.FullRowSelect = True
        Me.OperationListDataListView.HasCollapsibleGroups = False
        Me.OperationListDataListView.HeaderWordWrap = True
        Me.OperationListDataListView.HideSelection = False
        Me.OperationListDataListView.IncludeColumnHeadersInCopy = True
        Me.OperationListDataListView.Location = New System.Drawing.Point(0, 369)
        Me.OperationListDataListView.Name = "OperationListDataListView"
        Me.OperationListDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.OperationListDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.OperationListDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.OperationListDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.OperationListDataListView.ShowCommandMenuOnRightClick = True
        Me.OperationListDataListView.ShowGroups = False
        Me.OperationListDataListView.ShowImagesOnSubItems = True
        Me.OperationListDataListView.ShowItemCountOnGroups = True
        Me.OperationListDataListView.ShowItemToolTips = True
        Me.OperationListDataListView.Size = New System.Drawing.Size(766, 214)
        Me.OperationListDataListView.TabIndex = 24
        Me.OperationListDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.OperationListDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.OperationListDataListView.UseCellFormatEvents = True
        Me.OperationListDataListView.UseCompatibleStateImageBehavior = False
        Me.OperationListDataListView.UseFilterIndicator = True
        Me.OperationListDataListView.UseFiltering = True
        Me.OperationListDataListView.UseHotItem = True
        Me.OperationListDataListView.UseNotifyPropertyChanged = True
        Me.OperationListDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "Date"
        Me.OlvColumn2.AspectToStringFormat = "{0:d}"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.IsEditable = False
        Me.OlvColumn2.Text = "Data"
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 75
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
        Me.OlvColumn3.AspectName = "AttachedJournalEntryID"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.DisplayIndex = 2
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsEditable = False
        Me.OlvColumn3.IsVisible = False
        Me.OlvColumn3.Text = "Susietos BŽ ID"
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 100
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "AttachedJournalEntry"
        Me.OlvColumn4.CellEditUseWholeCell = True
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.IsEditable = False
        Me.OlvColumn4.Text = "Susietas BŽ"
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 144
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "IsComplexAct"
        Me.OlvColumn5.CellEditUseWholeCell = True
        Me.OlvColumn5.CheckBoxes = True
        Me.OlvColumn5.DisplayIndex = 4
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.IsEditable = False
        Me.OlvColumn5.IsVisible = False
        Me.OlvColumn5.Text = "Kompleks. dok."
        Me.OlvColumn5.ToolTipText = ""
        Me.OlvColumn5.Width = 100
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "OperationType"
        Me.OlvColumn6.CellEditUseWholeCell = True
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.IsEditable = False
        Me.OlvColumn6.Text = "Operacijos tipas"
        Me.OlvColumn6.ToolTipText = ""
        Me.OlvColumn6.Width = 100
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "AccountChangeType"
        Me.OlvColumn7.CellEditUseWholeCell = True
        Me.OlvColumn7.DisplayIndex = 6
        Me.OlvColumn7.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.IsEditable = False
        Me.OlvColumn7.IsVisible = False
        Me.OlvColumn7.Text = "Sąsk. pakeitimo oper. tipas"
        Me.OlvColumn7.ToolTipText = ""
        Me.OlvColumn7.Width = 100
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "Content"
        Me.OlvColumn8.CellEditUseWholeCell = True
        Me.OlvColumn8.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.IsEditable = False
        Me.OlvColumn8.Text = "Turinys (aprašas)"
        Me.OlvColumn8.ToolTipText = ""
        Me.OlvColumn8.Width = 266
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "ActNumber"
        Me.OlvColumn9.CellEditUseWholeCell = True
        Me.OlvColumn9.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.IsEditable = False
        Me.OlvColumn9.Text = "Akto Nr."
        Me.OlvColumn9.ToolTipText = ""
        Me.OlvColumn9.Width = 64
        '
        'OlvColumn10
        '
        Me.OlvColumn10.AspectName = "CorrespondingAccount"
        Me.OlvColumn10.CellEditUseWholeCell = True
        Me.OlvColumn10.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn10.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn10.IsEditable = False
        Me.OlvColumn10.Text = "Koresp. sąsk."
        Me.OlvColumn10.ToolTipText = ""
        Me.OlvColumn10.Width = 87
        '
        'OlvColumn11
        '
        Me.OlvColumn11.AspectName = "BeforeOperationAcquisitionAccountValue"
        Me.OlvColumn11.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn11.CellEditUseWholeCell = True
        Me.OlvColumn11.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn11.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn11.IsEditable = False
        Me.OlvColumn11.Text = "Prieš oper. savik. sąsk. vertė"
        Me.OlvColumn11.ToolTipText = ""
        Me.OlvColumn11.Width = 100
        '
        'OlvColumn12
        '
        Me.OlvColumn12.AspectName = "BeforeOperationAcquisitionAccountValuePerUnit"
        Me.OlvColumn12.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn12.CellEditUseWholeCell = True
        Me.OlvColumn12.DisplayIndex = 11
        Me.OlvColumn12.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn12.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn12.IsEditable = False
        Me.OlvColumn12.IsVisible = False
        Me.OlvColumn12.Text = "Prieš oper. savik. sąsk. vertė vnt."
        Me.OlvColumn12.ToolTipText = ""
        Me.OlvColumn12.Width = 100
        '
        'OlvColumn13
        '
        Me.OlvColumn13.AspectName = "BeforeOperationAmortizationAccountValue"
        Me.OlvColumn13.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn13.CellEditUseWholeCell = True
        Me.OlvColumn13.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn13.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn13.IsEditable = False
        Me.OlvColumn13.Text = "Prieš oper. amort. sąsk. vertė"
        Me.OlvColumn13.ToolTipText = ""
        Me.OlvColumn13.Width = 100
        '
        'OlvColumn14
        '
        Me.OlvColumn14.AspectName = "BeforeOperationAmortizationAccountValuePerUnit"
        Me.OlvColumn14.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn14.CellEditUseWholeCell = True
        Me.OlvColumn14.DisplayIndex = 13
        Me.OlvColumn14.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn14.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn14.IsEditable = False
        Me.OlvColumn14.IsVisible = False
        Me.OlvColumn14.Text = "Prieš oper. amort. sąsk. vertė vnt."
        Me.OlvColumn14.ToolTipText = ""
        Me.OlvColumn14.Width = 100
        '
        'OlvColumn15
        '
        Me.OlvColumn15.AspectName = "BeforeOperationValueDecreaseAccountValue"
        Me.OlvColumn15.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn15.CellEditUseWholeCell = True
        Me.OlvColumn15.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn15.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn15.IsEditable = False
        Me.OlvColumn15.Text = "Prieš oper. vertės sumaž. sąsk. vertė"
        Me.OlvColumn15.ToolTipText = ""
        Me.OlvColumn15.Width = 100
        '
        'OlvColumn16
        '
        Me.OlvColumn16.AspectName = "BeforeOperationValueDecreaseAccountValuePerUnit"
        Me.OlvColumn16.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn16.CellEditUseWholeCell = True
        Me.OlvColumn16.DisplayIndex = 15
        Me.OlvColumn16.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn16.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn16.IsEditable = False
        Me.OlvColumn16.IsVisible = False
        Me.OlvColumn16.Text = "Prieš oper. vertės sumaž. sąsk. vertė vnt."
        Me.OlvColumn16.ToolTipText = ""
        Me.OlvColumn16.Width = 100
        '
        'OlvColumn17
        '
        Me.OlvColumn17.AspectName = "BeforeOperationValueIncreaseAccountValue"
        Me.OlvColumn17.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn17.CellEditUseWholeCell = True
        Me.OlvColumn17.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn17.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn17.IsEditable = False
        Me.OlvColumn17.Text = "Prieš oper. perkain. sąsk. vertė"
        Me.OlvColumn17.ToolTipText = ""
        Me.OlvColumn17.Width = 100
        '
        'OlvColumn18
        '
        Me.OlvColumn18.AspectName = "BeforeOperationValueIncreaseAccountValuePerUnit"
        Me.OlvColumn18.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn18.CellEditUseWholeCell = True
        Me.OlvColumn18.DisplayIndex = 17
        Me.OlvColumn18.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn18.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn18.IsEditable = False
        Me.OlvColumn18.IsVisible = False
        Me.OlvColumn18.Text = "Prieš oper. perkain. sąsk. vertė vnt."
        Me.OlvColumn18.ToolTipText = ""
        Me.OlvColumn18.Width = 100
        '
        'OlvColumn19
        '
        Me.OlvColumn19.AspectName = "BeforeOperationValueIncreaseAmmortizationAccountValue"
        Me.OlvColumn19.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn19.CellEditUseWholeCell = True
        Me.OlvColumn19.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn19.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn19.IsEditable = False
        Me.OlvColumn19.Text = "Prieš oper. perkain. dalies amort. sąsk. vertė"
        Me.OlvColumn19.ToolTipText = ""
        Me.OlvColumn19.Width = 100
        '
        'OlvColumn20
        '
        Me.OlvColumn20.AspectName = "BeforeOperationValueIncreaseAmmortizationAccountValuePerUnit"
        Me.OlvColumn20.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn20.CellEditUseWholeCell = True
        Me.OlvColumn20.DisplayIndex = 19
        Me.OlvColumn20.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn20.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn20.IsEditable = False
        Me.OlvColumn20.IsVisible = False
        Me.OlvColumn20.Text = "Prieš oper. perkain. dalies amort. sąsk. vertė vnt."
        Me.OlvColumn20.ToolTipText = ""
        Me.OlvColumn20.Width = 100
        '
        'OlvColumn21
        '
        Me.OlvColumn21.AspectName = "BeforeOperationValue"
        Me.OlvColumn21.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn21.CellEditUseWholeCell = True
        Me.OlvColumn21.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn21.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn21.IsEditable = False
        Me.OlvColumn21.Text = "Prieš oper.  vertė"
        Me.OlvColumn21.ToolTipText = ""
        Me.OlvColumn21.Width = 100
        '
        'OlvColumn22
        '
        Me.OlvColumn22.AspectName = "BeforeOperationValuePerUnit"
        Me.OlvColumn22.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn22.CellEditUseWholeCell = True
        Me.OlvColumn22.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn22.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn22.IsEditable = False
        Me.OlvColumn22.Text = "Prieš oper. vertė vnt."
        Me.OlvColumn22.ToolTipText = ""
        Me.OlvColumn22.Width = 100
        '
        'OlvColumn23
        '
        Me.OlvColumn23.AspectName = "BeforeOperationAmmount"
        Me.OlvColumn23.CellEditUseWholeCell = True
        Me.OlvColumn23.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn23.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn23.IsEditable = False
        Me.OlvColumn23.Text = "Prieš oper. kiekis"
        Me.OlvColumn23.ToolTipText = ""
        Me.OlvColumn23.Width = 100
        '
        'OlvColumn24
        '
        Me.OlvColumn24.AspectName = "OperationAcquisitionAccountValueChange"
        Me.OlvColumn24.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn24.CellEditUseWholeCell = True
        Me.OlvColumn24.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn24.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn24.IsEditable = False
        Me.OlvColumn24.Text = "Pokytis savik. sąsk."
        Me.OlvColumn24.ToolTipText = ""
        Me.OlvColumn24.Width = 100
        '
        'OlvColumn25
        '
        Me.OlvColumn25.AspectName = "OperationAcquisitionAccountValueChangePerUnit"
        Me.OlvColumn25.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn25.CellEditUseWholeCell = True
        Me.OlvColumn25.DisplayIndex = 24
        Me.OlvColumn25.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn25.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn25.IsEditable = False
        Me.OlvColumn25.IsVisible = False
        Me.OlvColumn25.Text = "Pokytis savik. sąsk. vnt."
        Me.OlvColumn25.ToolTipText = ""
        Me.OlvColumn25.Width = 100
        '
        'OlvColumn26
        '
        Me.OlvColumn26.AspectName = "OperationAmortizationAccountValueChange"
        Me.OlvColumn26.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn26.CellEditUseWholeCell = True
        Me.OlvColumn26.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn26.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn26.IsEditable = False
        Me.OlvColumn26.Text = "Pokytis amort. sąsk."
        Me.OlvColumn26.ToolTipText = ""
        Me.OlvColumn26.Width = 100
        '
        'OlvColumn27
        '
        Me.OlvColumn27.AspectName = "OperationAmortizationAccountValueChangePerUnit"
        Me.OlvColumn27.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn27.CellEditUseWholeCell = True
        Me.OlvColumn27.DisplayIndex = 26
        Me.OlvColumn27.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn27.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn27.IsEditable = False
        Me.OlvColumn27.IsVisible = False
        Me.OlvColumn27.Text = "Pokytis amort. sąsk. vnt."
        Me.OlvColumn27.ToolTipText = ""
        Me.OlvColumn27.Width = 100
        '
        'OlvColumn28
        '
        Me.OlvColumn28.AspectName = "OperationValueDecreaseAccountValueChange"
        Me.OlvColumn28.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn28.CellEditUseWholeCell = True
        Me.OlvColumn28.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn28.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn28.IsEditable = False
        Me.OlvColumn28.Text = "Pokytis vertės sumaž. sąsk."
        Me.OlvColumn28.ToolTipText = ""
        Me.OlvColumn28.Width = 100
        '
        'OlvColumn29
        '
        Me.OlvColumn29.AspectName = "OperationValueDecreaseAccountValueChangePerUnit"
        Me.OlvColumn29.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn29.CellEditUseWholeCell = True
        Me.OlvColumn29.DisplayIndex = 28
        Me.OlvColumn29.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn29.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn29.IsEditable = False
        Me.OlvColumn29.IsVisible = False
        Me.OlvColumn29.Text = "Pokytis vertės sumaž. sąsk. vnt."
        Me.OlvColumn29.ToolTipText = ""
        Me.OlvColumn29.Width = 100
        '
        'OlvColumn30
        '
        Me.OlvColumn30.AspectName = "OperationValueIncreaseAccountValueChange"
        Me.OlvColumn30.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn30.CellEditUseWholeCell = True
        Me.OlvColumn30.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn30.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn30.IsEditable = False
        Me.OlvColumn30.Text = "Pokytis perkain. sąsk."
        Me.OlvColumn30.ToolTipText = ""
        Me.OlvColumn30.Width = 100
        '
        'OlvColumn31
        '
        Me.OlvColumn31.AspectName = "OperationValueIncreaseAccountValueChangePerUnit"
        Me.OlvColumn31.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn31.CellEditUseWholeCell = True
        Me.OlvColumn31.DisplayIndex = 30
        Me.OlvColumn31.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn31.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn31.IsEditable = False
        Me.OlvColumn31.IsVisible = False
        Me.OlvColumn31.Text = "Pokytis perkain. sąsk. vnt."
        Me.OlvColumn31.ToolTipText = ""
        Me.OlvColumn31.Width = 100
        '
        'OlvColumn32
        '
        Me.OlvColumn32.AspectName = "OperationValueIncreaseAmmortizationAccountValueChange"
        Me.OlvColumn32.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn32.CellEditUseWholeCell = True
        Me.OlvColumn32.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn32.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn32.IsEditable = False
        Me.OlvColumn32.Text = "Pokytis perkain. dalies amort. sąsk."
        Me.OlvColumn32.ToolTipText = ""
        Me.OlvColumn32.Width = 100
        '
        'OlvColumn33
        '
        Me.OlvColumn33.AspectName = "OperationValueIncreaseAmmortizationAccountValueChangePerUnit"
        Me.OlvColumn33.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn33.CellEditUseWholeCell = True
        Me.OlvColumn33.DisplayIndex = 32
        Me.OlvColumn33.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn33.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn33.IsEditable = False
        Me.OlvColumn33.IsVisible = False
        Me.OlvColumn33.Text = "Pokytis perkain. dalies amort. sąsk. vnt."
        Me.OlvColumn33.ToolTipText = ""
        Me.OlvColumn33.Width = 100
        '
        'OlvColumn34
        '
        Me.OlvColumn34.AspectName = "OperationValueChange"
        Me.OlvColumn34.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn34.CellEditUseWholeCell = True
        Me.OlvColumn34.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn34.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn34.IsEditable = False
        Me.OlvColumn34.Text = "Pokytis vertės"
        Me.OlvColumn34.ToolTipText = ""
        Me.OlvColumn34.Width = 100
        '
        'OlvColumn35
        '
        Me.OlvColumn35.AspectName = "OperationValueChangePerUnit"
        Me.OlvColumn35.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn35.CellEditUseWholeCell = True
        Me.OlvColumn35.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn35.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn35.IsEditable = False
        Me.OlvColumn35.Text = "Pokytis vertės vnt."
        Me.OlvColumn35.ToolTipText = ""
        Me.OlvColumn35.Width = 100
        '
        'OlvColumn36
        '
        Me.OlvColumn36.AspectName = "OperationAmmountChange"
        Me.OlvColumn36.CellEditUseWholeCell = True
        Me.OlvColumn36.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn36.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn36.IsEditable = False
        Me.OlvColumn36.Text = "Pokytis kiekio"
        Me.OlvColumn36.ToolTipText = ""
        Me.OlvColumn36.Width = 100
        '
        'OlvColumn37
        '
        Me.OlvColumn37.AspectName = "AfterOperationAcquisitionAccountValue"
        Me.OlvColumn37.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn37.CellEditUseWholeCell = True
        Me.OlvColumn37.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn37.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn37.IsEditable = False
        Me.OlvColumn37.Text = "Po oper. savik. sąsk. vertė"
        Me.OlvColumn37.ToolTipText = ""
        Me.OlvColumn37.Width = 100
        '
        'OlvColumn38
        '
        Me.OlvColumn38.AspectName = "AfterOperationAcquisitionAccountValuePerUnit"
        Me.OlvColumn38.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn38.CellEditUseWholeCell = True
        Me.OlvColumn38.DisplayIndex = 37
        Me.OlvColumn38.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn38.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn38.IsEditable = False
        Me.OlvColumn38.IsVisible = False
        Me.OlvColumn38.Text = "Po oper. savik. sąsk. vertė vnt."
        Me.OlvColumn38.ToolTipText = ""
        Me.OlvColumn38.Width = 100
        '
        'OlvColumn39
        '
        Me.OlvColumn39.AspectName = "AfterOperationAmortizationAccountValue"
        Me.OlvColumn39.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn39.CellEditUseWholeCell = True
        Me.OlvColumn39.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn39.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn39.IsEditable = False
        Me.OlvColumn39.Text = "Po oper. amort. sąsk. vertė"
        Me.OlvColumn39.ToolTipText = ""
        Me.OlvColumn39.Width = 100
        '
        'OlvColumn40
        '
        Me.OlvColumn40.AspectName = "AfterOperationAmortizationAccountValuePerUnit"
        Me.OlvColumn40.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn40.CellEditUseWholeCell = True
        Me.OlvColumn40.DisplayIndex = 39
        Me.OlvColumn40.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn40.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn40.IsEditable = False
        Me.OlvColumn40.IsVisible = False
        Me.OlvColumn40.Text = "Po oper. amort. sąsk. vertė vnt."
        Me.OlvColumn40.ToolTipText = ""
        Me.OlvColumn40.Width = 100
        '
        'OlvColumn41
        '
        Me.OlvColumn41.AspectName = "AfterOperationValueDecreaseAccountValue"
        Me.OlvColumn41.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn41.CellEditUseWholeCell = True
        Me.OlvColumn41.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn41.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn41.IsEditable = False
        Me.OlvColumn41.Text = "Po oper. vertės sumaž. sąsk. vertė"
        Me.OlvColumn41.ToolTipText = ""
        Me.OlvColumn41.Width = 100
        '
        'OlvColumn42
        '
        Me.OlvColumn42.AspectName = "AfterOperationValueDecreaseAccountValuePerUnit"
        Me.OlvColumn42.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn42.CellEditUseWholeCell = True
        Me.OlvColumn42.DisplayIndex = 41
        Me.OlvColumn42.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn42.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn42.IsEditable = False
        Me.OlvColumn42.IsVisible = False
        Me.OlvColumn42.Text = "Po oper. vertės sumaž. sąsk. vertė vnt."
        Me.OlvColumn42.ToolTipText = ""
        Me.OlvColumn42.Width = 100
        '
        'OlvColumn43
        '
        Me.OlvColumn43.AspectName = "AfterOperationValueIncreaseAccountValue"
        Me.OlvColumn43.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn43.CellEditUseWholeCell = True
        Me.OlvColumn43.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn43.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn43.IsEditable = False
        Me.OlvColumn43.Text = "Po oper. perkain. sąsk. vertė"
        Me.OlvColumn43.ToolTipText = ""
        Me.OlvColumn43.Width = 100
        '
        'OlvColumn44
        '
        Me.OlvColumn44.AspectName = "AfterOperationValueIncreaseAccountValuePerUnit"
        Me.OlvColumn44.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn44.CellEditUseWholeCell = True
        Me.OlvColumn44.DisplayIndex = 43
        Me.OlvColumn44.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn44.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn44.IsEditable = False
        Me.OlvColumn44.IsVisible = False
        Me.OlvColumn44.Text = "Po oper. perkain. sąsk. vertė vnt."
        Me.OlvColumn44.ToolTipText = ""
        Me.OlvColumn44.Width = 100
        '
        'OlvColumn45
        '
        Me.OlvColumn45.AspectName = "AfterOperationValueIncreaseAmmortizationAccountValue"
        Me.OlvColumn45.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn45.CellEditUseWholeCell = True
        Me.OlvColumn45.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn45.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn45.IsEditable = False
        Me.OlvColumn45.Text = "Po oper. perkain. dalies amort. sąsk. vertė"
        Me.OlvColumn45.ToolTipText = ""
        Me.OlvColumn45.Width = 100
        '
        'OlvColumn46
        '
        Me.OlvColumn46.AspectName = "AfterOperationValueIncreaseAmmortizationAccountValuePerUnit"
        Me.OlvColumn46.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn46.CellEditUseWholeCell = True
        Me.OlvColumn46.DisplayIndex = 45
        Me.OlvColumn46.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn46.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn46.IsEditable = False
        Me.OlvColumn46.IsVisible = False
        Me.OlvColumn46.Text = "Po oper. perkain. dalies amort. sąsk. vertė vnt."
        Me.OlvColumn46.ToolTipText = ""
        Me.OlvColumn46.Width = 100
        '
        'OlvColumn47
        '
        Me.OlvColumn47.AspectName = "AfterOperationValue"
        Me.OlvColumn47.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn47.CellEditUseWholeCell = True
        Me.OlvColumn47.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn47.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn47.IsEditable = False
        Me.OlvColumn47.Text = "Po oper. vertė"
        Me.OlvColumn47.ToolTipText = ""
        Me.OlvColumn47.Width = 100
        '
        'OlvColumn48
        '
        Me.OlvColumn48.AspectName = "AfterOperationValuePerUnit"
        Me.OlvColumn48.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn48.CellEditUseWholeCell = True
        Me.OlvColumn48.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn48.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn48.IsEditable = False
        Me.OlvColumn48.Text = "Po oper. vertė vnt."
        Me.OlvColumn48.ToolTipText = ""
        Me.OlvColumn48.Width = 100
        '
        'OlvColumn49
        '
        Me.OlvColumn49.AspectName = "AfterOperationAmmount"
        Me.OlvColumn49.CellEditUseWholeCell = True
        Me.OlvColumn49.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn49.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn49.IsEditable = False
        Me.OlvColumn49.Text = "Po oper. kiekis"
        Me.OlvColumn49.ToolTipText = ""
        Me.OlvColumn49.Width = 100
        '
        'OlvColumn50
        '
        Me.OlvColumn50.AspectName = "NewAmortizationPeriod"
        Me.OlvColumn50.CellEditUseWholeCell = True
        Me.OlvColumn50.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn50.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn50.IsEditable = False
        Me.OlvColumn50.Text = "Naujas amort. laik."
        Me.OlvColumn50.ToolTipText = ""
        Me.OlvColumn50.Width = 100
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(154, 393)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(99, 43)
        Me.ProgressFiller1.TabIndex = 25
        Me.ProgressFiller1.Visible = False
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(293, 397)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(174, 51)
        Me.ProgressFiller2.TabIndex = 26
        Me.ProgressFiller2.Visible = False
        '
        'F_LongTermAssetOperationInfoListParent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.ClientSize = New System.Drawing.Size(766, 583)
        Me.Controls.Add(Me.OperationListDataListView)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_LongTermAssetOperationInfoListParent"
        Me.ShowInTaskbar = False
        Me.Text = "Operacijų su ilgalaikiu turtu suvestinė"
        CType(Me.LongTermAssetOperationInfoListParentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OperationListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.OperationListDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LongTermAssetOperationInfoListParentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AcquisitionDateDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents AcquisitionJournalEntryDocNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CustomGroupTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DefaultAmortizationPeriodTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MeasureUnitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LegalGroupTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InventoryNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LiquidationUnitValueAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents AccountRevaluedPortionAmmortizationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AccountValueIncreaseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AccountValueDecreaseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AccountAccumulatedAmortizationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AccountAcquisitionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ValueIncreaseAmmortizationAccountValuePerUnitAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents ValueIncreaseAccountValuePerUnitAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents ValueDecreaseAccountValuePerUnitAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents AmortizationAccountValuePerUnitAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents AcquisitionAccountValuePerUnitAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents ValueIncreaseAmmortizationAccountValueAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents ValueIncreaseAccountValueAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents ValueDecreaseAccountValueAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents AmortizationAccountValueAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents AcquisitionAccountValueAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents AmmountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ValueAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents ValuePerUnitAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents OperationListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ChangeItem_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteItem_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewOperation_MenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CurrentValueAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrentAmountAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrentAmortizationAccountValuePerUnitAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrentAmortizationAccountValueAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrentAcquisitionAccountValuePerUnitAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrentAcquisitionAccountValueAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrentValueIncreaseAmmortizationAccountValuePerUnitAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrentValueIncreaseAmmortizationAccountValueAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrentValueIncreaseAccountValuePerUnitAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrentValueIncreaseAccountValueAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrentValueDecreaseAccountValuePerUnitAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrentValueDecreaseAccountValueAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents CurrentValuePerUnitAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CurrentlyOperationalCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents OperationListDataListView As BrightIdeasSoftware.DataListView
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
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AssetInfoListAccListComboBox As AccControlsWinForms.AccListComboBox
End Class
