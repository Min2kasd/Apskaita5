﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_WageSheet
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
        Dim CostAccountLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim YearLabel As System.Windows.Forms.Label
        Dim MonthLabel As System.Windows.Forms.Label
        Dim NumberLabel As System.Windows.Forms.Label
        Dim RemarksLabel As System.Windows.Forms.Label
        Dim RateSODRAEmployeeLabel As System.Windows.Forms.Label
        Dim RateSODRAEmployerLabel As System.Windows.Forms.Label
        Dim RatePSDEmployeeLabel As System.Windows.Forms.Label
        Dim RatePSDEmployerLabel As System.Windows.Forms.Label
        Dim RateGPMLabel As System.Windows.Forms.Label
        Dim RateGuaranteeFundLabel As System.Windows.Forms.Label
        Dim NPDFormulaLabel As System.Windows.Forms.Label
        Dim RateONLabel As System.Windows.Forms.Label
        Dim RateHRLabel As System.Windows.Forms.Label
        Dim RateSCLabel As System.Windows.Forms.Label
        Dim RateSickLeaveLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_WageSheet))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ExportPaymentsButton = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.SetPaymentDateButton = New System.Windows.Forms.Button()
        Me.NewWageSheetButton = New System.Windows.Forms.Button()
        Me.nCancelButton = New System.Windows.Forms.Button()
        Me.ApplyButton = New System.Windows.Forms.Button()
        Me.nOkButton = New System.Windows.Forms.Button()
        Me.IDTextBox = New System.Windows.Forms.TextBox()
        Me.IsNonClosingCheckBox = New System.Windows.Forms.CheckBox()
        Me.YearTextBox = New System.Windows.Forms.TextBox()
        Me.MonthTextBox = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CalculateNPDButton = New System.Windows.Forms.Button()
        Me.GetVDUButton = New System.Windows.Forms.Button()
        Me.RefreshWageTarifButton = New System.Windows.Forms.Button()
        Me.RefreshTaxesButton = New System.Windows.Forms.Button()
        Me.ItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.RemarksTextBox = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel12 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.NPDFormulaTextBox = New System.Windows.Forms.TextBox()
        Me.ApplyNpdToSickLeaveCheckBox = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel()
        Me.ItemsDataListView = New BrightIdeasSoftware.DataListView()
        Me.OlvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn5 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn6 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn7 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn8 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn9 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn10 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn11 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn12 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn13 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn14 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn15 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn16 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn17 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn18 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn19 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn20 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn21 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn22 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn23 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn24 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn25 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn26 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn27 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn28 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn29 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn30 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn31 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn32 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn33 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn34 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn35 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn36 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn37 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn38 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn39 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn40 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn41 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn42 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn43 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn44 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn45 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn46 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn47 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn48 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn49 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn50 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn51 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn52 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn53 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn54 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn55 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn56 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn57 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn58 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn59 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn60 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn61 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn62 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn63 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn64 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn65 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn66 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn67 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn68 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn69 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn70 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn71 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn72 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.OlvColumn73 = CType(New BrightIdeasSoftware.OLVColumn(),BrightIdeasSoftware.OLVColumn)
        Me.WageSheetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CostAccountAccListComboBox = New AccControlsWinForms.AccListComboBox()
        Me.DateAccDatePicker = New AccControlsWinForms.AccDatePicker()
        Me.NumberAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.RateSODRAEmployerAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.RateGuaranteeFundAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.RatePSDEmployerAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.RatePSDEmployeeAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.RateSODRAEmployeeAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.RateGPMAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.RateGPMSickLeaveAccTextBox = New AccControlsWinForms.AccTextBox()
        Me.RateSickLeaveAccTextBox1 = New AccControlsWinForms.AccTextBox()
        Me.RateSCAccTextBox1 = New AccControlsWinForms.AccTextBox()
        Me.RateONAccTextBox1 = New AccControlsWinForms.AccTextBox()
        Me.RateHRAccTextBox1 = New AccControlsWinForms.AccTextBox()
        Me.PaymentDateAccDatePicker = New AccControlsWinForms.AccDatePicker()
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller()
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller()
        Me.ErrorWarnInfoProvider1 = New AccControlsWinForms.ErrorWarnInfoProvider(Me.components)
        CostAccountLabel = New System.Windows.Forms.Label()
        DateLabel = New System.Windows.Forms.Label()
        IDLabel = New System.Windows.Forms.Label()
        YearLabel = New System.Windows.Forms.Label()
        MonthLabel = New System.Windows.Forms.Label()
        NumberLabel = New System.Windows.Forms.Label()
        RemarksLabel = New System.Windows.Forms.Label()
        RateSODRAEmployeeLabel = New System.Windows.Forms.Label()
        RateSODRAEmployerLabel = New System.Windows.Forms.Label()
        RatePSDEmployeeLabel = New System.Windows.Forms.Label()
        RatePSDEmployerLabel = New System.Windows.Forms.Label()
        RateGPMLabel = New System.Windows.Forms.Label()
        RateGuaranteeFundLabel = New System.Windows.Forms.Label()
        NPDFormulaLabel = New System.Windows.Forms.Label()
        RateONLabel = New System.Windows.Forms.Label()
        RateHRLabel = New System.Windows.Forms.Label()
        RateSCLabel = New System.Windows.Forms.Label()
        RateSickLeaveLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout
        Me.GroupBox3.SuspendLayout
        CType(Me.ItemsBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel2.SuspendLayout
        Me.TableLayoutPanel6.SuspendLayout
        Me.TableLayoutPanel5.SuspendLayout
        Me.TableLayoutPanel3.SuspendLayout
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.TabPage2.SuspendLayout
        Me.TableLayoutPanel12.SuspendLayout
        Me.GroupBox1.SuspendLayout
        Me.TableLayoutPanel8.SuspendLayout
        Me.TableLayoutPanel7.SuspendLayout
        Me.TableLayoutPanel10.SuspendLayout
        Me.TableLayoutPanel9.SuspendLayout
        Me.GroupBox2.SuspendLayout
        Me.TableLayoutPanel11.SuspendLayout
        CType(Me.ItemsDataListView,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.WageSheetBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.ErrorWarnInfoProvider1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'CostAccountLabel
        '
        CostAccountLabel.AutoSize = true
        CostAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        CostAccountLabel.Location = New System.Drawing.Point(386, 3)
        CostAccountLabel.Margin = New System.Windows.Forms.Padding(1, 3, 1, 0)
        CostAccountLabel.Name = "CostAccountLabel"
        CostAccountLabel.Size = New System.Drawing.Size(95, 13)
        CostAccountLabel.TabIndex = 6
        CostAccountLabel.Text = "Sąnaudų sąsk.:"
        '
        'DateLabel
        '
        DateLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        DateLabel.AutoSize = true
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DateLabel.Location = New System.Drawing.Point(2, 37)
        DateLabel.Margin = New System.Windows.Forms.Padding(2, 6, 1, 0)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(63, 13)
        DateLabel.TabIndex = 8
        DateLabel.Text = "Data:"
        DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'IDLabel
        '
        IDLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        IDLabel.AutoSize = true
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        IDLabel.Location = New System.Drawing.Point(2, 6)
        IDLabel.Margin = New System.Windows.Forms.Padding(2, 6, 1, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(63, 13)
        IDLabel.TabIndex = 18
        IDLabel.Text = "ID:"
        IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'YearLabel
        '
        YearLabel.AutoSize = true
        YearLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        YearLabel.Location = New System.Drawing.Point(225, 3)
        YearLabel.Margin = New System.Windows.Forms.Padding(1, 3, 1, 0)
        YearLabel.Name = "YearLabel"
        YearLabel.Size = New System.Drawing.Size(42, 13)
        YearLabel.TabIndex = 26
        YearLabel.Text = "Metai:"
        '
        'MonthLabel
        '
        MonthLabel.AutoSize = true
        MonthLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        MonthLabel.Location = New System.Drawing.Point(489, 3)
        MonthLabel.Margin = New System.Windows.Forms.Padding(1, 3, 1, 0)
        MonthLabel.Name = "MonthLabel"
        MonthLabel.Size = New System.Drawing.Size(49, 13)
        MonthLabel.TabIndex = 32
        MonthLabel.Text = "Mėnuo:"
        '
        'NumberLabel
        '
        NumberLabel.AutoSize = true
        NumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        NumberLabel.Location = New System.Drawing.Point(178, 3)
        NumberLabel.Margin = New System.Windows.Forms.Padding(1, 3, 1, 0)
        NumberLabel.Name = "NumberLabel"
        NumberLabel.Size = New System.Drawing.Size(28, 13)
        NumberLabel.TabIndex = 36
        NumberLabel.Text = "Nr.:"
        '
        'RemarksLabel
        '
        RemarksLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        RemarksLabel.AutoSize = true
        RemarksLabel.Location = New System.Drawing.Point(2, 68)
        RemarksLabel.Margin = New System.Windows.Forms.Padding(2, 6, 1, 0)
        RemarksLabel.Name = "RemarksLabel"
        RemarksLabel.Size = New System.Drawing.Size(63, 13)
        RemarksLabel.TabIndex = 71
        RemarksLabel.Text = "Pastabos:"
        RemarksLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RateSODRAEmployeeLabel
        '
        RateSODRAEmployeeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        RateSODRAEmployeeLabel.AutoSize = true
        RateSODRAEmployeeLabel.Location = New System.Drawing.Point(1, 6)
        RateSODRAEmployeeLabel.Margin = New System.Windows.Forms.Padding(1, 6, 1, 0)
        RateSODRAEmployeeLabel.Name = "RateSODRAEmployeeLabel"
        RateSODRAEmployeeLabel.Size = New System.Drawing.Size(127, 13)
        RateSODRAEmployeeLabel.TabIndex = 74
        RateSODRAEmployeeLabel.Text = "Darbuotojui: SODRA:"
        '
        'RateSODRAEmployerLabel
        '
        RateSODRAEmployerLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        RateSODRAEmployerLabel.AutoSize = true
        RateSODRAEmployerLabel.Location = New System.Drawing.Point(5, 39)
        RateSODRAEmployerLabel.Margin = New System.Windows.Forms.Padding(1, 6, 1, 0)
        RateSODRAEmployerLabel.Name = "RateSODRAEmployerLabel"
        RateSODRAEmployerLabel.Size = New System.Drawing.Size(123, 13)
        RateSODRAEmployerLabel.TabIndex = 75
        RateSODRAEmployerLabel.Text = "Darbdaviui: SODRA:"
        '
        'RatePSDEmployeeLabel
        '
        RatePSDEmployeeLabel.AutoSize = true
        RatePSDEmployeeLabel.Location = New System.Drawing.Point(77, 0)
        RatePSDEmployeeLabel.Name = "RatePSDEmployeeLabel"
        RatePSDEmployeeLabel.Size = New System.Drawing.Size(36, 13)
        RatePSDEmployeeLabel.TabIndex = 74
        RatePSDEmployeeLabel.Text = "PSD:"
        '
        'RatePSDEmployerLabel
        '
        RatePSDEmployerLabel.AutoSize = true
        RatePSDEmployerLabel.Location = New System.Drawing.Point(112, 0)
        RatePSDEmployerLabel.Name = "RatePSDEmployerLabel"
        RatePSDEmployerLabel.Size = New System.Drawing.Size(36, 13)
        RatePSDEmployerLabel.TabIndex = 75
        RatePSDEmployerLabel.Text = "PSD:"
        '
        'RateGPMLabel
        '
        RateGPMLabel.AutoSize = true
        RateGPMLabel.Location = New System.Drawing.Point(193, 0)
        RateGPMLabel.Name = "RateGPMLabel"
        RateGPMLabel.Size = New System.Drawing.Size(38, 13)
        RateGPMLabel.TabIndex = 74
        RateGPMLabel.Text = "GPM:"
        '
        'RateGuaranteeFundLabel
        '
        RateGuaranteeFundLabel.AutoSize = true
        RateGuaranteeFundLabel.Location = New System.Drawing.Point(264, 0)
        RateGuaranteeFundLabel.Name = "RateGuaranteeFundLabel"
        RateGuaranteeFundLabel.Size = New System.Drawing.Size(68, 13)
        RateGuaranteeFundLabel.TabIndex = 75
        RateGuaranteeFundLabel.Text = "Garantinis:"
        '
        'NPDFormulaLabel
        '
        NPDFormulaLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        NPDFormulaLabel.AutoSize = true
        NPDFormulaLabel.Location = New System.Drawing.Point(43, 72)
        NPDFormulaLabel.Margin = New System.Windows.Forms.Padding(1, 6, 1, 0)
        NPDFormulaLabel.Name = "NPDFormulaLabel"
        NPDFormulaLabel.Size = New System.Drawing.Size(85, 13)
        NPDFormulaLabel.TabIndex = 76
        NPDFormulaLabel.Text = "NPD Formulė:"
        '
        'RateONLabel
        '
        RateONLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        RateONLabel.AutoSize = true
        RateONLabel.Location = New System.Drawing.Point(4, 3)
        RateONLabel.Margin = New System.Windows.Forms.Padding(1, 3, 1, 1)
        RateONLabel.Name = "RateONLabel"
        RateONLabel.Size = New System.Drawing.Size(134, 13)
        RateONLabel.TabIndex = 75
        RateONLabel.Text = "Viršvalandžiai ir Naktį:"
        '
        'RateHRLabel
        '
        RateHRLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        RateHRLabel.AutoSize = true
        RateHRLabel.Location = New System.Drawing.Point(15, 28)
        RateHRLabel.Margin = New System.Windows.Forms.Padding(1, 3, 1, 1)
        RateHRLabel.Name = "RateHRLabel"
        RateHRLabel.Size = New System.Drawing.Size(123, 13)
        RateHRLabel.TabIndex = 75
        RateHRLabel.Text = "Švenčių ir poilsio d.:"
        '
        'RateSCLabel
        '
        RateSCLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        RateSCLabel.AutoSize = true
        RateSCLabel.Location = New System.Drawing.Point(1, 53)
        RateSCLabel.Margin = New System.Windows.Forms.Padding(1, 3, 1, 1)
        RateSCLabel.Name = "RateSCLabel"
        RateSCLabel.Size = New System.Drawing.Size(137, 13)
        RateSCLabel.TabIndex = 75
        RateSCLabel.Text = "Ypatingomis sąlygomis:"
        '
        'RateSickLeaveLabel
        '
        RateSickLeaveLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        RateSickLeaveLabel.AutoSize = true
        RateSickLeaveLabel.Location = New System.Drawing.Point(1, 78)
        RateSickLeaveLabel.Margin = New System.Windows.Forms.Padding(1, 3, 1, 1)
        RateSickLeaveLabel.Name = "RateSickLeaveLabel"
        RateSickLeaveLabel.Size = New System.Drawing.Size(137, 13)
        RateSickLeaveLabel.TabIndex = 75
        RateSickLeaveLabel.Text = "Nedarbingumo apmok.:"
        '
        'Label1
        '
        Label1.AutoSize = true
        Label1.Location = New System.Drawing.Point(311, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(62, 13)
        Label1.TabIndex = 79
        Label1.Text = "GPM liga:"
        '
        'Panel1
        '
        Me.Panel1.AutoSize = true
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.ExportPaymentsButton)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.NewWageSheetButton)
        Me.Panel1.Controls.Add(Me.nCancelButton)
        Me.Panel1.Controls.Add(Me.ApplyButton)
        Me.Panel1.Controls.Add(Me.nOkButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 445)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(928, 46)
        Me.Panel1.TabIndex = 2
        '
        'ExportPaymentsButton
        '
        Me.ExportPaymentsButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ExportPaymentsButton.AutoSize = true
        Me.ExportPaymentsButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.credit_card_24
        Me.ExportPaymentsButton.Location = New System.Drawing.Point(279, 10)
        Me.ExportPaymentsButton.Name = "ExportPaymentsButton"
        Me.ExportPaymentsButton.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.ExportPaymentsButton.Size = New System.Drawing.Size(53, 33)
        Me.ExportPaymentsButton.TabIndex = 7
        Me.ExportPaymentsButton.UseVisualStyleBackColor = true
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PaymentDateAccDatePicker)
        Me.GroupBox3.Controls.Add(Me.SetPaymentDateButton)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 40)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = false
        Me.GroupBox3.Text = "Bendra Išmokėjimo Data"
        '
        'SetPaymentDateButton
        '
        Me.SetPaymentDateButton.Location = New System.Drawing.Point(125, 15)
        Me.SetPaymentDateButton.Name = "SetPaymentDateButton"
        Me.SetPaymentDateButton.Size = New System.Drawing.Size(69, 23)
        Me.SetPaymentDateButton.TabIndex = 6
        Me.SetPaymentDateButton.Text = "Nustatyti"
        Me.SetPaymentDateButton.UseVisualStyleBackColor = true
        '
        'NewWageSheetButton
        '
        Me.NewWageSheetButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Action_file_new_icon_16p
        Me.NewWageSheetButton.Location = New System.Drawing.Point(226, 14)
        Me.NewWageSheetButton.Margin = New System.Windows.Forms.Padding(0)
        Me.NewWageSheetButton.Name = "NewWageSheetButton"
        Me.NewWageSheetButton.Size = New System.Drawing.Size(30, 27)
        Me.NewWageSheetButton.TabIndex = 4
        Me.NewWageSheetButton.UseVisualStyleBackColor = true
        '
        'nCancelButton
        '
        Me.nCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.nCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.nCancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.nCancelButton.Location = New System.Drawing.Point(831, 14)
        Me.nCancelButton.Name = "nCancelButton"
        Me.nCancelButton.Size = New System.Drawing.Size(87, 23)
        Me.nCancelButton.TabIndex = 3
        Me.nCancelButton.Text = "Atšaukti"
        Me.nCancelButton.UseVisualStyleBackColor = true
        '
        'ApplyButton
        '
        Me.ApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.ApplyButton.Location = New System.Drawing.Point(736, 14)
        Me.ApplyButton.Name = "ApplyButton"
        Me.ApplyButton.Size = New System.Drawing.Size(87, 23)
        Me.ApplyButton.TabIndex = 2
        Me.ApplyButton.Text = "Taikyti"
        Me.ApplyButton.UseVisualStyleBackColor = true
        '
        'nOkButton
        '
        Me.nOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.nOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.nOkButton.Location = New System.Drawing.Point(642, 14)
        Me.nOkButton.Name = "nOkButton"
        Me.nOkButton.Size = New System.Drawing.Size(87, 23)
        Me.nOkButton.TabIndex = 1
        Me.nOkButton.Text = "OK"
        Me.nOkButton.UseVisualStyleBackColor = true
        '
        'IDTextBox
        '
        Me.IDTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.WageSheetBindingSource, "ID", true))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.IDTextBox.Location = New System.Drawing.Point(2, 0)
        Me.IDTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = true
        Me.IDTextBox.Size = New System.Drawing.Size(196, 20)
        Me.IDTextBox.TabIndex = 19
        Me.IDTextBox.TabStop = false
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IsNonClosingCheckBox
        '
        Me.IsNonClosingCheckBox.AutoSize = true
        Me.IsNonClosingCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.WageSheetBindingSource, "IsNonClosing", true))
        Me.IsNonClosingCheckBox.Location = New System.Drawing.Point(663, 3)
        Me.IsNonClosingCheckBox.Name = "IsNonClosingCheckBox"
        Me.IsNonClosingCheckBox.Size = New System.Drawing.Size(64, 17)
        Me.IsNonClosingCheckBox.TabIndex = 3
        Me.IsNonClosingCheckBox.Text = "Dalinis"
        '
        'YearTextBox
        '
        Me.YearTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.YearTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.WageSheetBindingSource, "Year", true))
        Me.YearTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.YearTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.YearTextBox.Location = New System.Drawing.Point(270, 0)
        Me.YearTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.YearTextBox.Name = "YearTextBox"
        Me.YearTextBox.ReadOnly = true
        Me.YearTextBox.Size = New System.Drawing.Size(196, 20)
        Me.YearTextBox.TabIndex = 27
        Me.YearTextBox.TabStop = false
        Me.YearTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MonthTextBox
        '
        Me.MonthTextBox.BackColor = System.Drawing.SystemColors.Info
        Me.MonthTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.WageSheetBindingSource, "Month", true))
        Me.MonthTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MonthTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.MonthTextBox.Location = New System.Drawing.Point(541, 0)
        Me.MonthTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MonthTextBox.Name = "MonthTextBox"
        Me.MonthTextBox.ReadOnly = true
        Me.MonthTextBox.Size = New System.Drawing.Size(196, 20)
        Me.MonthTextBox.TabIndex = 33
        Me.MonthTextBox.TabStop = false
        Me.MonthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.AutoSize = true
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Panel2.Size = New System.Drawing.Size(928, 3)
        Me.Panel2.TabIndex = 70
        '
        'CalculateNPDButton
        '
        Me.CalculateNPDButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.CalculateNPDButton.Location = New System.Drawing.Point(830, 34)
        Me.CalculateNPDButton.Name = "CalculateNPDButton"
        Me.CalculateNPDButton.Size = New System.Drawing.Size(81, 25)
        Me.CalculateNPDButton.TabIndex = 4
        Me.CalculateNPDButton.Text = "Gauti NPD"
        Me.CalculateNPDButton.UseVisualStyleBackColor = true
        '
        'GetVDUButton
        '
        Me.GetVDUButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.GetVDUButton.Location = New System.Drawing.Point(830, 3)
        Me.GetVDUButton.Name = "GetVDUButton"
        Me.GetVDUButton.Size = New System.Drawing.Size(81, 25)
        Me.GetVDUButton.TabIndex = 3
        Me.GetVDUButton.Text = "Gauti VDU"
        Me.GetVDUButton.UseVisualStyleBackColor = true
        '
        'RefreshWageTarifButton
        '
        Me.RefreshWageTarifButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Button_Reload_icon_16p
        Me.RefreshWageTarifButton.Location = New System.Drawing.Point(257, 0)
        Me.RefreshWageTarifButton.Margin = New System.Windows.Forms.Padding(0)
        Me.RefreshWageTarifButton.Name = "RefreshWageTarifButton"
        Me.RefreshWageTarifButton.Size = New System.Drawing.Size(24, 24)
        Me.RefreshWageTarifButton.TabIndex = 76
        Me.RefreshWageTarifButton.UseVisualStyleBackColor = true
        '
        'RefreshTaxesButton
        '
        Me.RefreshTaxesButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Button_Reload_icon_16p
        Me.RefreshTaxesButton.Location = New System.Drawing.Point(585, 0)
        Me.RefreshTaxesButton.Margin = New System.Windows.Forms.Padding(0)
        Me.RefreshTaxesButton.Name = "RefreshTaxesButton"
        Me.RefreshTaxesButton.Size = New System.Drawing.Size(24, 24)
        Me.RefreshTaxesButton.TabIndex = 76
        Me.RefreshTaxesButton.UseVisualStyleBackColor = true
        '
        'ItemsBindingSource
        '
        Me.ItemsBindingSource.DataMember = "Items"
        Me.ItemsBindingSource.DataSource = Me.WageSheetBindingSource
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel6, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.CalculateNPDButton, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(RemarksLabel, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.GetVDUButton, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel5, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(DateLabel, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(914, 125)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel6.Controls.Add(Me.RemarksTextBox, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(66, 65)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(761, 57)
        Me.TableLayoutPanel6.TabIndex = 2
        '
        'RemarksTextBox
        '
        Me.RemarksTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.WageSheetBindingSource, "Remarks", true))
        Me.RemarksTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RemarksTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RemarksTextBox.Location = New System.Drawing.Point(2, 0)
        Me.RemarksTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.RemarksTextBox.MaxLength = 255
        Me.RemarksTextBox.Multiline = true
        Me.RemarksTextBox.Name = "RemarksTextBox"
        Me.RemarksTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.RemarksTextBox.Size = New System.Drawing.Size(737, 57)
        Me.RemarksTextBox.TabIndex = 0
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.AutoScroll = true
        Me.TableLayoutPanel5.ColumnCount = 10
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel5.Controls.Add(Me.DateAccDatePicker, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.CostAccountAccListComboBox, 6, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.NumberAccTextBox, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(NumberLabel, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(CostAccountLabel, 5, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.IsNonClosingCheckBox, 8, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(66, 34)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(761, 25)
        Me.TableLayoutPanel5.TabIndex = 1
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 9
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.ViewJournalEntryButton, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.IDTextBox, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(YearLabel, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.YearTextBox, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(MonthLabel, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.MonthTextBox, 6, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(66, 3)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(761, 25)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(200, 0)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 90
        Me.ViewJournalEntryButton.TabStop = false
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = true
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(928, 157)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(920, 131)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Bendri duomenys"
        Me.TabPage1.UseVisualStyleBackColor = true
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel12)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(920, 131)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Tarifai"
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'TableLayoutPanel12
        '
        Me.TableLayoutPanel12.ColumnCount = 2
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68!))
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32!))
        Me.TableLayoutPanel12.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.GroupBox2, 1, 0)
        Me.TableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel12.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel12.Name = "TableLayoutPanel12"
        Me.TableLayoutPanel12.RowCount = 1
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel12.Size = New System.Drawing.Size(914, 125)
        Me.TableLayoutPanel12.TabIndex = 76
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel8)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(615, 119)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Mokesčių Tarifai"
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 3
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel7, 1, 2)
        Me.TableLayoutPanel8.Controls.Add(Me.RefreshTaxesButton, 2, 0)
        Me.TableLayoutPanel8.Controls.Add(NPDFormulaLabel, 0, 2)
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel10, 1, 1)
        Me.TableLayoutPanel8.Controls.Add(RateSODRAEmployeeLabel, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel9, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(RateSODRAEmployerLabel, 0, 1)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 3
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(609, 100)
        Me.TableLayoutPanel8.TabIndex = 75
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 3
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.Controls.Add(Me.NPDFormulaTextBox, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.ApplyNpdToSickLeaveCheckBox, 2, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(129, 69)
        Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(456, 28)
        Me.TableLayoutPanel7.TabIndex = 76
        '
        'NPDFormulaTextBox
        '
        Me.NPDFormulaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.WageSheetBindingSource, "WageRates.NPDFormula", true))
        Me.NPDFormulaTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NPDFormulaTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.NPDFormulaTextBox.Location = New System.Drawing.Point(3, 3)
        Me.NPDFormulaTextBox.MaxLength = 255
        Me.NPDFormulaTextBox.Name = "NPDFormulaTextBox"
        Me.NPDFormulaTextBox.Size = New System.Drawing.Size(334, 20)
        Me.NPDFormulaTextBox.TabIndex = 73
        '
        'ApplyNpdToSickLeaveCheckBox
        '
        Me.ApplyNpdToSickLeaveCheckBox.AutoSize = true
        Me.ApplyNpdToSickLeaveCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.WageSheetBindingSource, "WageRates.ApplyNpdToSickLeave", true))
        Me.ApplyNpdToSickLeaveCheckBox.Location = New System.Drawing.Point(358, 3)
        Me.ApplyNpdToSickLeaveCheckBox.Name = "ApplyNpdToSickLeaveCheckBox"
        Me.ApplyNpdToSickLeaveCheckBox.Size = New System.Drawing.Size(95, 17)
        Me.ApplyNpdToSickLeaveCheckBox.TabIndex = 6
        Me.ApplyNpdToSickLeaveCheckBox.Text = "Taikyti Ligai"
        Me.ApplyNpdToSickLeaveCheckBox.UseVisualStyleBackColor = true
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 8
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30!))
        Me.TableLayoutPanel10.Controls.Add(RateGuaranteeFundLabel, 5, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.RateSODRAEmployerAccTextBox, 0, 0)
        Me.TableLayoutPanel10.Controls.Add(RatePSDEmployerLabel, 2, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.RateGuaranteeFundAccTextBox, 6, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.RatePSDEmployerAccTextBox, 3, 0)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(129, 36)
        Me.TableLayoutPanel10.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(456, 27)
        Me.TableLayoutPanel10.TabIndex = 77
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.AutoScroll = true
        Me.TableLayoutPanel9.ColumnCount = 11
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21!))
        Me.TableLayoutPanel9.Controls.Add(RatePSDEmployeeLabel, 2, 0)
        Me.TableLayoutPanel9.Controls.Add(RateGPMLabel, 5, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.RatePSDEmployeeAccTextBox, 3, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.RateSODRAEmployeeAccTextBox, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.RateGPMAccTextBox, 6, 0)
        Me.TableLayoutPanel9.Controls.Add(Label1, 8, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.RateGPMSickLeaveAccTextBox, 9, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(129, 3)
        Me.TableLayoutPanel9.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(456, 27)
        Me.TableLayoutPanel9.TabIndex = 76
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel11)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(624, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(287, 119)
        Me.GroupBox2.TabIndex = 75
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Darbo Apmokėjimo Tarifai"
        '
        'TableLayoutPanel11
        '
        Me.TableLayoutPanel11.ColumnCount = 4
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel11.Controls.Add(RateSickLeaveLabel, 0, 3)
        Me.TableLayoutPanel11.Controls.Add(Me.RateSickLeaveAccTextBox1, 1, 3)
        Me.TableLayoutPanel11.Controls.Add(Me.RateSCAccTextBox1, 1, 2)
        Me.TableLayoutPanel11.Controls.Add(Me.RateONAccTextBox1, 1, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.RateHRAccTextBox1, 1, 1)
        Me.TableLayoutPanel11.Controls.Add(RateSCLabel, 0, 2)
        Me.TableLayoutPanel11.Controls.Add(RateHRLabel, 0, 1)
        Me.TableLayoutPanel11.Controls.Add(RateONLabel, 0, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.RefreshWageTarifButton, 3, 0)
        Me.TableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel11.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        Me.TableLayoutPanel11.RowCount = 4
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.TableLayoutPanel11.Size = New System.Drawing.Size(281, 100)
        Me.TableLayoutPanel11.TabIndex = 76
        '
        'ItemsDataListView
        '
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn5)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn6)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn7)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn8)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn9)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn10)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn11)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn12)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn13)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn14)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn15)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn16)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn17)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn18)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn19)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn20)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn21)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn22)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn23)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn24)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn25)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn26)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn27)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn28)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn29)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn30)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn31)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn32)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn33)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn34)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn35)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn36)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn37)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn38)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn39)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn40)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn41)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn42)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn43)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn44)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn45)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn46)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn47)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn48)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn49)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn50)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn51)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn52)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn53)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn54)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn55)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn56)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn57)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn58)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn59)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn60)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn61)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn62)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn63)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn64)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn65)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn66)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn67)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn68)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn69)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn70)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn71)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn72)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.ItemsDataListView.AllColumns.Add(Me.OlvColumn73)
        Me.ItemsDataListView.AllowColumnReorder = true
        Me.ItemsDataListView.AutoGenerateColumns = false
        Me.ItemsDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.ItemsDataListView.CellEditEnterChangesRows = true
        Me.ItemsDataListView.CellEditTabChangesRows = true
        Me.ItemsDataListView.CellEditUseWholeCell = false
        Me.ItemsDataListView.CheckBoxes = true
        Me.ItemsDataListView.CheckedAspectName = "IsChecked"
        Me.ItemsDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn4, Me.OlvColumn7, Me.OlvColumn8, Me.OlvColumn9, Me.OlvColumn10, Me.OlvColumn11, Me.OlvColumn12, Me.OlvColumn15, Me.OlvColumn20, Me.OlvColumn21, Me.OlvColumn25, Me.OlvColumn26, Me.OlvColumn27, Me.OlvColumn28, Me.OlvColumn29, Me.OlvColumn30, Me.OlvColumn31, Me.OlvColumn32, Me.OlvColumn43, Me.OlvColumn45, Me.OlvColumn46, Me.OlvColumn47, Me.OlvColumn48, Me.OlvColumn50, Me.OlvColumn52, Me.OlvColumn56, Me.OlvColumn59, Me.OlvColumn60, Me.OlvColumn61, Me.OlvColumn62, Me.OlvColumn63, Me.OlvColumn65, Me.OlvColumn66, Me.OlvColumn2, Me.OlvColumn73})
        Me.ItemsDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.ItemsDataListView.DataSource = Me.ItemsBindingSource
        Me.ItemsDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemsDataListView.FullRowSelect = true
        Me.ItemsDataListView.HasCollapsibleGroups = false
        Me.ItemsDataListView.HeaderWordWrap = true
        Me.ItemsDataListView.HideSelection = false
        Me.ItemsDataListView.HighlightBackgroundColor = System.Drawing.Color.PaleGreen
        Me.ItemsDataListView.HighlightForegroundColor = System.Drawing.Color.Black
        Me.ItemsDataListView.IncludeColumnHeadersInCopy = true
        Me.ItemsDataListView.Location = New System.Drawing.Point(0, 160)
        Me.ItemsDataListView.Name = "ItemsDataListView"
        Me.ItemsDataListView.RenderNonEditableCheckboxesAsDisabled = true
        Me.ItemsDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.ItemsDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.ItemsDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.ItemsDataListView.ShowCommandMenuOnRightClick = true
        Me.ItemsDataListView.ShowGroups = false
        Me.ItemsDataListView.ShowImagesOnSubItems = true
        Me.ItemsDataListView.ShowItemCountOnGroups = true
        Me.ItemsDataListView.ShowItemToolTips = true
        Me.ItemsDataListView.Size = New System.Drawing.Size(928, 285)
        Me.ItemsDataListView.TabIndex = 71
        Me.ItemsDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.ItemsDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.ItemsDataListView.UseCellFormatEvents = true
        Me.ItemsDataListView.UseCompatibleStateImageBehavior = false
        Me.ItemsDataListView.UseFilterIndicator = true
        Me.ItemsDataListView.UseFiltering = true
        Me.ItemsDataListView.UseHotItem = true
        Me.ItemsDataListView.UseNotifyPropertyChanged = true
        Me.ItemsDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "PersonName"
        Me.OlvColumn4.CellEditUseWholeCell = true
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.IsEditable = false
        Me.OlvColumn4.Text = "Vardas, Pavardė"
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 126
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "ID"
        Me.OlvColumn1.CellEditUseWholeCell = true
        Me.OlvColumn1.DisplayIndex = 1
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.IsEditable = false
        Me.OlvColumn1.IsVisible = false
        Me.OlvColumn1.Text = "ID"
        Me.OlvColumn1.ToolTipText = ""
        Me.OlvColumn1.Width = 45
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "PersonID"
        Me.OlvColumn3.CellEditUseWholeCell = true
        Me.OlvColumn3.DisplayIndex = 2
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.IsEditable = false
        Me.OlvColumn3.IsVisible = false
        Me.OlvColumn3.Text = "Asmens ID"
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 92
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "PersonCode"
        Me.OlvColumn5.CellEditUseWholeCell = true
        Me.OlvColumn5.DisplayIndex = 3
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.IsEditable = false
        Me.OlvColumn5.IsVisible = false
        Me.OlvColumn5.Text = "Asm. kodas"
        Me.OlvColumn5.ToolTipText = ""
        Me.OlvColumn5.Width = 97
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "PersonCodeSODRA"
        Me.OlvColumn6.CellEditUseWholeCell = true
        Me.OlvColumn6.DisplayIndex = 5
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.IsEditable = false
        Me.OlvColumn6.IsVisible = false
        Me.OlvColumn6.Text = "SODRA kodas"
        Me.OlvColumn6.ToolTipText = ""
        Me.OlvColumn6.Width = 113
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "ContractSerial"
        Me.OlvColumn7.CellEditUseWholeCell = true
        Me.OlvColumn7.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.IsEditable = false
        Me.OlvColumn7.Text = "DS Ser."
        Me.OlvColumn7.ToolTipText = ""
        Me.OlvColumn7.Width = 41
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "ContractNumber"
        Me.OlvColumn8.CellEditUseWholeCell = true
        Me.OlvColumn8.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.IsEditable = false
        Me.OlvColumn8.Text = "DS NR."
        Me.OlvColumn8.ToolTipText = ""
        Me.OlvColumn8.Width = 52
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "WorkLoad"
        Me.OlvColumn9.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn9.CellEditUseWholeCell = true
        Me.OlvColumn9.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.IsEditable = false
        Me.OlvColumn9.Text = "Krūvis"
        Me.OlvColumn9.ToolTipText = ""
        Me.OlvColumn9.Width = 51
        '
        'OlvColumn10
        '
        Me.OlvColumn10.AspectName = "ConventionalWage"
        Me.OlvColumn10.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn10.CellEditUseWholeCell = true
        Me.OlvColumn10.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn10.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn10.IsEditable = false
        Me.OlvColumn10.Text = "Nustat. DU"
        Me.OlvColumn10.ToolTipText = ""
        Me.OlvColumn10.Width = 79
        '
        'OlvColumn11
        '
        Me.OlvColumn11.AspectName = "WageTypeHumanReadable"
        Me.OlvColumn11.CellEditUseWholeCell = true
        Me.OlvColumn11.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn11.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn11.IsEditable = false
        Me.OlvColumn11.Text = "DU tipas"
        Me.OlvColumn11.ToolTipText = ""
        Me.OlvColumn11.Width = 66
        '
        'OlvColumn12
        '
        Me.OlvColumn12.AspectName = "ConventionalExtraPay"
        Me.OlvColumn12.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn12.CellEditUseWholeCell = true
        Me.OlvColumn12.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn12.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn12.IsEditable = false
        Me.OlvColumn12.Text = "Nustat. pried."
        Me.OlvColumn12.ToolTipText = ""
        Me.OlvColumn12.Width = 80
        '
        'OlvColumn13
        '
        Me.OlvColumn13.AspectName = "ApplicableVDUHourly"
        Me.OlvColumn13.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn13.CellEditUseWholeCell = true
        Me.OlvColumn13.DisplayIndex = 12
        Me.OlvColumn13.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn13.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn13.IsVisible = false
        Me.OlvColumn13.Text = "Val. VDU"
        Me.OlvColumn13.ToolTipText = ""
        Me.OlvColumn13.Width = 84
        '
        'OlvColumn14
        '
        Me.OlvColumn14.AspectName = "ApplicableVDUDaily"
        Me.OlvColumn14.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn14.CellEditUseWholeCell = true
        Me.OlvColumn14.DisplayIndex = 13
        Me.OlvColumn14.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn14.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn14.IsVisible = false
        Me.OlvColumn14.Text = "Dien. VDU"
        Me.OlvColumn14.ToolTipText = ""
        Me.OlvColumn14.Width = 92
        '
        'OlvColumn15
        '
        Me.OlvColumn15.AspectName = "NormalHoursWorked"
        Me.OlvColumn15.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn15.CellEditUseWholeCell = true
        Me.OlvColumn15.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn15.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn15.Text = "Normalių d.v."
        Me.OlvColumn15.ToolTipText = ""
        Me.OlvColumn15.Width = 74
        '
        'OlvColumn16
        '
        Me.OlvColumn16.AspectName = "HRHoursWorked"
        Me.OlvColumn16.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn16.CellEditUseWholeCell = true
        Me.OlvColumn16.DisplayIndex = 15
        Me.OlvColumn16.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn16.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn16.IsVisible = false
        Me.OlvColumn16.Text = "Poils. šv. d.v."
        Me.OlvColumn16.ToolTipText = ""
        Me.OlvColumn16.Width = 110
        '
        'OlvColumn17
        '
        Me.OlvColumn17.AspectName = "ONHoursWorked"
        Me.OlvColumn17.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn17.CellEditUseWholeCell = true
        Me.OlvColumn17.DisplayIndex = 16
        Me.OlvColumn17.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn17.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn17.IsVisible = false
        Me.OlvColumn17.Text = "Viršv. nakt. d.v."
        Me.OlvColumn17.ToolTipText = ""
        Me.OlvColumn17.Width = 123
        '
        'OlvColumn18
        '
        Me.OlvColumn18.AspectName = "SCHoursWorked"
        Me.OlvColumn18.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn18.CellEditUseWholeCell = true
        Me.OlvColumn18.DisplayIndex = 17
        Me.OlvColumn18.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn18.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn18.IsVisible = false
        Me.OlvColumn18.Text = "Yp. sąl. d.v."
        Me.OlvColumn18.ToolTipText = ""
        Me.OlvColumn18.Width = 101
        '
        'OlvColumn19
        '
        Me.OlvColumn19.AspectName = "TotalHoursWorked"
        Me.OlvColumn19.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn19.CellEditUseWholeCell = true
        Me.OlvColumn19.DisplayIndex = 18
        Me.OlvColumn19.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn19.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn19.IsEditable = false
        Me.OlvColumn19.IsVisible = false
        Me.OlvColumn19.Text = "Viso d.v."
        Me.OlvColumn19.ToolTipText = ""
        Me.OlvColumn19.Width = 82
        '
        'OlvColumn20
        '
        Me.OlvColumn20.AspectName = "TruancyHours"
        Me.OlvColumn20.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn20.CellEditUseWholeCell = true
        Me.OlvColumn20.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn20.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn20.Text = "Prav. val."
        Me.OlvColumn20.ToolTipText = ""
        Me.OlvColumn20.Width = 71
        '
        'OlvColumn21
        '
        Me.OlvColumn21.AspectName = "TotalDaysWorked"
        Me.OlvColumn21.AspectToStringFormat = "{0:##}"
        Me.OlvColumn21.CellEditUseWholeCell = true
        Me.OlvColumn21.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn21.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn21.Text = "Viso d.d."
        Me.OlvColumn21.ToolTipText = ""
        Me.OlvColumn21.Width = 50
        '
        'OlvColumn22
        '
        Me.OlvColumn22.AspectName = "HolidayWD"
        Me.OlvColumn22.AspectToStringFormat = "{0:##}"
        Me.OlvColumn22.CellEditUseWholeCell = true
        Me.OlvColumn22.DisplayIndex = 21
        Me.OlvColumn22.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn22.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn22.IsVisible = false
        Me.OlvColumn22.Text = "Atost. d.d."
        Me.OlvColumn22.ToolTipText = ""
        Me.OlvColumn22.Width = 91
        '
        'OlvColumn23
        '
        Me.OlvColumn23.AspectName = "HolidayRD"
        Me.OlvColumn23.AspectToStringFormat = "{0:##}"
        Me.OlvColumn23.CellEditUseWholeCell = true
        Me.OlvColumn23.DisplayIndex = 22
        Me.OlvColumn23.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn23.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn23.IsVisible = false
        Me.OlvColumn23.Text = "Atost. n.d."
        Me.OlvColumn23.ToolTipText = ""
        Me.OlvColumn23.Width = 91
        '
        'OlvColumn24
        '
        Me.OlvColumn24.AspectName = "SickDays"
        Me.OlvColumn24.AspectToStringFormat = "{0:##}"
        Me.OlvColumn24.CellEditUseWholeCell = true
        Me.OlvColumn24.DisplayIndex = 23
        Me.OlvColumn24.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn24.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn24.IsVisible = false
        Me.OlvColumn24.Text = "Nedarb. dien."
        Me.OlvColumn24.ToolTipText = ""
        Me.OlvColumn24.Width = 109
        '
        'OlvColumn25
        '
        Me.OlvColumn25.AspectName = "StandartHours"
        Me.OlvColumn25.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn25.CellEditUseWholeCell = true
        Me.OlvColumn25.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn25.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn25.Text = "Grafike d.v."
        Me.OlvColumn25.ToolTipText = ""
        Me.OlvColumn25.Width = 66
        '
        'OlvColumn26
        '
        Me.OlvColumn26.AspectName = "StandartDays"
        Me.OlvColumn26.AspectToStringFormat = "{0:##}"
        Me.OlvColumn26.CellEditUseWholeCell = true
        Me.OlvColumn26.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn26.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn26.Text = "Grafike d.d."
        Me.OlvColumn26.ToolTipText = ""
        Me.OlvColumn26.Width = 59
        '
        'OlvColumn27
        '
        Me.OlvColumn27.AspectName = "BonusPay"
        Me.OlvColumn27.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn27.CellEditUseWholeCell = true
        Me.OlvColumn27.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn27.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn27.Text = "Premija"
        Me.OlvColumn27.ToolTipText = ""
        Me.OlvColumn27.Width = 73
        '
        'OlvColumn28
        '
        Me.OlvColumn28.AspectName = "BonusType"
        Me.OlvColumn28.CellEditUseWholeCell = true
        Me.OlvColumn28.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn28.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn28.Text = "Prem. tip."
        Me.OlvColumn28.ToolTipText = ""
        Me.OlvColumn28.Width = 86
        '
        'OlvColumn29
        '
        Me.OlvColumn29.AspectName = "OtherPayRelatedToWork"
        Me.OlvColumn29.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn29.CellEditUseWholeCell = true
        Me.OlvColumn29.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn29.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn29.Text = "Kitos išm. susij. su atl. darbu"
        Me.OlvColumn29.ToolTipText = ""
        Me.OlvColumn29.Width = 194
        '
        'OlvColumn30
        '
        Me.OlvColumn30.AspectName = "OtherPayNotRelatedToWork"
        Me.OlvColumn30.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn30.CellEditUseWholeCell = true
        Me.OlvColumn30.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn30.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn30.Text = "Kitos išm. nesusij. su atl. darbu"
        Me.OlvColumn30.ToolTipText = ""
        Me.OlvColumn30.Width = 208
        '
        'OlvColumn31
        '
        Me.OlvColumn31.AspectName = "PayOutWage"
        Me.OlvColumn31.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn31.CellEditUseWholeCell = true
        Me.OlvColumn31.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn31.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn31.IsEditable = false
        Me.OlvColumn31.Text = "Prisk. DU"
        Me.OlvColumn31.ToolTipText = ""
        Me.OlvColumn31.Width = 86
        '
        'OlvColumn32
        '
        Me.OlvColumn32.AspectName = "PayOutExtraPay"
        Me.OlvColumn32.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn32.CellEditUseWholeCell = true
        Me.OlvColumn32.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn32.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn32.IsEditable = false
        Me.OlvColumn32.Text = "Prisk. pried."
        Me.OlvColumn32.ToolTipText = ""
        Me.OlvColumn32.Width = 100
        '
        'OlvColumn33
        '
        Me.OlvColumn33.AspectName = "ActualHourlyPay"
        Me.OlvColumn33.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn33.CellEditUseWholeCell = true
        Me.OlvColumn33.DisplayIndex = 32
        Me.OlvColumn33.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn33.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn33.IsEditable = false
        Me.OlvColumn33.IsVisible = false
        Me.OlvColumn33.Text = "Apsk. val. DU"
        Me.OlvColumn33.ToolTipText = ""
        Me.OlvColumn33.Width = 111
        '
        'OlvColumn34
        '
        Me.OlvColumn34.AspectName = "PayOutHR"
        Me.OlvColumn34.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn34.CellEditUseWholeCell = true
        Me.OlvColumn34.DisplayIndex = 33
        Me.OlvColumn34.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn34.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn34.IsEditable = false
        Me.OlvColumn34.IsVisible = false
        Me.OlvColumn34.Text = "Prisk. poils. šv. apm."
        Me.OlvColumn34.ToolTipText = ""
        Me.OlvColumn34.Width = 150
        '
        'OlvColumn35
        '
        Me.OlvColumn35.AspectName = "PayOutON"
        Me.OlvColumn35.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn35.CellEditUseWholeCell = true
        Me.OlvColumn35.DisplayIndex = 34
        Me.OlvColumn35.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn35.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn35.IsEditable = false
        Me.OlvColumn35.IsVisible = false
        Me.OlvColumn35.Text = "Prisk. viršv. nakt. apm."
        Me.OlvColumn35.ToolTipText = ""
        Me.OlvColumn35.Width = 163
        '
        'OlvColumn36
        '
        Me.OlvColumn36.AspectName = "PayOutSC"
        Me.OlvColumn36.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn36.CellEditUseWholeCell = true
        Me.OlvColumn36.DisplayIndex = 35
        Me.OlvColumn36.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn36.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn36.IsEditable = false
        Me.OlvColumn36.IsVisible = false
        Me.OlvColumn36.Text = "Prisk. yp. sąl. apm."
        Me.OlvColumn36.ToolTipText = ""
        Me.OlvColumn36.Width = 140
        '
        'OlvColumn37
        '
        Me.OlvColumn37.AspectName = "PayOutSickLeave"
        Me.OlvColumn37.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn37.CellEditUseWholeCell = true
        Me.OlvColumn37.DisplayIndex = 36
        Me.OlvColumn37.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn37.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn37.IsEditable = false
        Me.OlvColumn37.IsVisible = false
        Me.OlvColumn37.Text = "Nedarb. apm."
        Me.OlvColumn37.ToolTipText = ""
        Me.OlvColumn37.Width = 108
        '
        'OlvColumn38
        '
        Me.OlvColumn38.AspectName = "AnnualWorkingDaysRatio"
        Me.OlvColumn38.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn38.CellEditUseWholeCell = true
        Me.OlvColumn38.DisplayIndex = 37
        Me.OlvColumn38.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn38.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn38.IsVisible = false
        Me.OlvColumn38.Text = "Metinis d.d. koef."
        Me.OlvColumn38.ToolTipText = ""
        Me.OlvColumn38.Width = 131
        '
        'OlvColumn39
        '
        Me.OlvColumn39.AspectName = "UnusedHolidayDaysForCompensation"
        Me.OlvColumn39.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn39.CellEditUseWholeCell = true
        Me.OlvColumn39.DisplayIndex = 38
        Me.OlvColumn39.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn39.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn39.IsVisible = false
        Me.OlvColumn39.Text = "Nepan. atost. k.d."
        Me.OlvColumn39.ToolTipText = ""
        Me.OlvColumn39.Width = 135
        '
        'OlvColumn40
        '
        Me.OlvColumn40.AspectName = "PayOutHoliday"
        Me.OlvColumn40.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn40.CellEditUseWholeCell = true
        Me.OlvColumn40.DisplayIndex = 39
        Me.OlvColumn40.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn40.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn40.IsEditable = false
        Me.OlvColumn40.IsVisible = false
        Me.OlvColumn40.Text = "Prisk. už sut. atost."
        Me.OlvColumn40.ToolTipText = ""
        Me.OlvColumn40.Width = 142
        '
        'OlvColumn41
        '
        Me.OlvColumn41.AspectName = "PayOutUnusedHolidayCompensation"
        Me.OlvColumn41.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn41.CellEditUseWholeCell = true
        Me.OlvColumn41.DisplayIndex = 40
        Me.OlvColumn41.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn41.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn41.IsEditable = false
        Me.OlvColumn41.IsVisible = false
        Me.OlvColumn41.Text = "Kompens. už nepan. atost."
        Me.OlvColumn41.ToolTipText = ""
        Me.OlvColumn41.Width = 183
        '
        'OlvColumn42
        '
        Me.OlvColumn42.AspectName = "PayOutRedundancyPay"
        Me.OlvColumn42.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn42.CellEditUseWholeCell = true
        Me.OlvColumn42.DisplayIndex = 41
        Me.OlvColumn42.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn42.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn42.IsVisible = false
        Me.OlvColumn42.Text = "Išeit. išm."
        Me.OlvColumn42.ToolTipText = ""
        Me.OlvColumn42.Width = 86
        '
        'OlvColumn43
        '
        Me.OlvColumn43.AspectName = "PayOutTotal"
        Me.OlvColumn43.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn43.CellEditUseWholeCell = true
        Me.OlvColumn43.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn43.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn43.IsEditable = false
        Me.OlvColumn43.Text = "Prisk. viso"
        Me.OlvColumn43.ToolTipText = ""
        Me.OlvColumn43.Width = 91
        '
        'OlvColumn44
        '
        Me.OlvColumn44.AspectName = "BaseNPD"
        Me.OlvColumn44.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn44.CellEditUseWholeCell = true
        Me.OlvColumn44.DisplayIndex = 43
        Me.OlvColumn44.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn44.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn44.IsEditable = false
        Me.OlvColumn44.IsVisible = false
        Me.OlvColumn44.Text = "Bazinis NPD"
        Me.OlvColumn44.ToolTipText = ""
        Me.OlvColumn44.Width = 100
        '
        'OlvColumn45
        '
        Me.OlvColumn45.AspectName = "ApplicableNPD"
        Me.OlvColumn45.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn45.CellEditUseWholeCell = true
        Me.OlvColumn45.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn45.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn45.Text = "Taikytinas NPD"
        Me.OlvColumn45.ToolTipText = ""
        Me.OlvColumn45.Width = 100
        '
        'OlvColumn46
        '
        Me.OlvColumn46.AspectName = "NPD"
        Me.OlvColumn46.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn46.CellEditUseWholeCell = true
        Me.OlvColumn46.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn46.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn46.IsEditable = false
        Me.OlvColumn46.Text = "Pritaikytas NPD Viso"
        Me.OlvColumn46.ToolTipText = ""
        Me.OlvColumn46.Width = 58
        '
        'OlvColumn47
        '
        Me.OlvColumn47.AspectName = "ApplicablePNPD"
        Me.OlvColumn47.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn47.CellEditUseWholeCell = true
        Me.OlvColumn47.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn47.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn47.IsEditable = false
        Me.OlvColumn47.Text = "Taikytinas PNPD"
        Me.OlvColumn47.ToolTipText = ""
        Me.OlvColumn47.Width = 100
        '
        'OlvColumn48
        '
        Me.OlvColumn48.AspectName = "PNPD"
        Me.OlvColumn48.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn48.CellEditUseWholeCell = true
        Me.OlvColumn48.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn48.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn48.IsEditable = false
        Me.OlvColumn48.Text = "Pritaikytas PNPD"
        Me.OlvColumn48.ToolTipText = ""
        Me.OlvColumn48.Width = 66
        '
        'OlvColumn49
        '
        Me.OlvColumn49.AspectName = "BaseGPM"
        Me.OlvColumn49.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn49.CellEditUseWholeCell = true
        Me.OlvColumn49.DisplayIndex = 48
        Me.OlvColumn49.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn49.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn49.IsEditable = false
        Me.OlvColumn49.IsVisible = false
        Me.OlvColumn49.Text = "GPM Bazė"
        Me.OlvColumn49.ToolTipText = ""
        Me.OlvColumn49.Width = 100
        '
        'OlvColumn50
        '
        Me.OlvColumn50.AspectName = "DeductionGPM"
        Me.OlvColumn50.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn50.CellEditUseWholeCell = true
        Me.OlvColumn50.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn50.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn50.IsEditable = false
        Me.OlvColumn50.Text = "Išsk. GPM Viso"
        Me.OlvColumn50.ToolTipText = ""
        Me.OlvColumn50.Width = 90
        '
        'OlvColumn51
        '
        Me.OlvColumn51.AspectName = "BasePSD"
        Me.OlvColumn51.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn51.CellEditUseWholeCell = true
        Me.OlvColumn51.DisplayIndex = 50
        Me.OlvColumn51.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn51.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn51.IsEditable = false
        Me.OlvColumn51.IsVisible = false
        Me.OlvColumn51.Text = "PSD Bazė"
        Me.OlvColumn51.ToolTipText = ""
        Me.OlvColumn51.Width = 100
        '
        'OlvColumn52
        '
        Me.OlvColumn52.AspectName = "DeductionPSD"
        Me.OlvColumn52.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn52.CellEditUseWholeCell = true
        Me.OlvColumn52.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn52.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn52.IsEditable = false
        Me.OlvColumn52.Text = "Išsk. PSD"
        Me.OlvColumn52.ToolTipText = ""
        Me.OlvColumn52.Width = 88
        '
        'OlvColumn53
        '
        Me.OlvColumn53.AspectName = "BasePSDSickLeave"
        Me.OlvColumn53.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn53.CellEditUseWholeCell = true
        Me.OlvColumn53.DisplayIndex = 52
        Me.OlvColumn53.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn53.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn53.IsEditable = false
        Me.OlvColumn53.IsVisible = false
        Me.OlvColumn53.Text = "PSD Bazė nedarb."
        Me.OlvColumn53.ToolTipText = ""
        Me.OlvColumn53.Width = 100
        '
        'OlvColumn54
        '
        Me.OlvColumn54.AspectName = "DeductionPSDSickLeave"
        Me.OlvColumn54.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn54.CellEditUseWholeCell = true
        Me.OlvColumn54.DisplayIndex = 53
        Me.OlvColumn54.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn54.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn54.IsEditable = false
        Me.OlvColumn54.IsVisible = false
        Me.OlvColumn54.Text = "Išsk. PSD nedarb."
        Me.OlvColumn54.ToolTipText = ""
        Me.OlvColumn54.Width = 135
        '
        'OlvColumn55
        '
        Me.OlvColumn55.AspectName = "BaseSODRA"
        Me.OlvColumn55.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn55.CellEditUseWholeCell = true
        Me.OlvColumn55.DisplayIndex = 54
        Me.OlvColumn55.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn55.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn55.IsEditable = false
        Me.OlvColumn55.IsVisible = false
        Me.OlvColumn55.Text = "SODRA Bazė"
        Me.OlvColumn55.ToolTipText = ""
        Me.OlvColumn55.Width = 100
        '
        'OlvColumn56
        '
        Me.OlvColumn56.AspectName = "DeductionSODRA"
        Me.OlvColumn56.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn56.CellEditUseWholeCell = true
        Me.OlvColumn56.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn56.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn56.IsEditable = false
        Me.OlvColumn56.Text = "Išsk. SODRA"
        Me.OlvColumn56.ToolTipText = ""
        Me.OlvColumn56.Width = 106
        '
        'OlvColumn57
        '
        Me.OlvColumn57.AspectName = "PayOutTotalAfterTaxes"
        Me.OlvColumn57.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn57.CellEditUseWholeCell = true
        Me.OlvColumn57.DisplayIndex = 56
        Me.OlvColumn57.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn57.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn57.IsEditable = false
        Me.OlvColumn57.IsVisible = false
        Me.OlvColumn57.Text = "Mokėtina po mok."
        Me.OlvColumn57.ToolTipText = ""
        Me.OlvColumn57.Width = 133
        '
        'OlvColumn58
        '
        Me.OlvColumn58.AspectName = "ImprestPending"
        Me.OlvColumn58.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn58.CellEditUseWholeCell = true
        Me.OlvColumn58.DisplayIndex = 57
        Me.OlvColumn58.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn58.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn58.IsEditable = false
        Me.OlvColumn58.IsVisible = false
        Me.OlvColumn58.Text = "Neužsk. avans."
        Me.OlvColumn58.ToolTipText = ""
        Me.OlvColumn58.Width = 120
        '
        'OlvColumn59
        '
        Me.OlvColumn59.AspectName = "DeductionImprest"
        Me.OlvColumn59.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn59.CellEditUseWholeCell = true
        Me.OlvColumn59.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn59.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn59.IsEditable = false
        Me.OlvColumn59.Text = "Išsk. avanso"
        Me.OlvColumn59.ToolTipText = ""
        Me.OlvColumn59.Width = 104
        '
        'OlvColumn60
        '
        Me.OlvColumn60.AspectName = "DeductionOther"
        Me.OlvColumn60.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn60.CellEditUseWholeCell = true
        Me.OlvColumn60.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn60.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn60.Text = "Kt. išsk."
        Me.OlvColumn60.ToolTipText = ""
        Me.OlvColumn60.Width = 78
        '
        'OlvColumn61
        '
        Me.OlvColumn61.AspectName = "DeductionOtherApplicable"
        Me.OlvColumn61.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn61.CellEditUseWholeCell = true
        Me.OlvColumn61.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn61.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn61.IsEditable = false
        Me.OlvColumn61.Text = "Kt. išsk. pritaik."
        Me.OlvColumn61.ToolTipText = ""
        Me.OlvColumn61.Width = 121
        '
        'OlvColumn62
        '
        Me.OlvColumn62.AspectName = "ContributionSODRA"
        Me.OlvColumn62.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn62.CellEditUseWholeCell = true
        Me.OlvColumn62.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn62.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn62.IsEditable = false
        Me.OlvColumn62.Text = "Prisk. SODRA"
        Me.OlvColumn62.ToolTipText = ""
        Me.OlvColumn62.Width = 111
        '
        'OlvColumn63
        '
        Me.OlvColumn63.AspectName = "ContributionPSD"
        Me.OlvColumn63.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn63.CellEditUseWholeCell = true
        Me.OlvColumn63.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn63.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn63.IsEditable = false
        Me.OlvColumn63.Text = "Prisk. PSD"
        Me.OlvColumn63.ToolTipText = ""
        Me.OlvColumn63.Width = 93
        '
        'OlvColumn64
        '
        Me.OlvColumn64.AspectName = "BaseGuaranteeFund"
        Me.OlvColumn64.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn64.CellEditUseWholeCell = true
        Me.OlvColumn64.DisplayIndex = 63
        Me.OlvColumn64.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn64.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn64.IsEditable = false
        Me.OlvColumn64.IsVisible = false
        Me.OlvColumn64.Text = "Gar. Fondo Bazė"
        Me.OlvColumn64.ToolTipText = ""
        Me.OlvColumn64.Width = 100
        '
        'OlvColumn65
        '
        Me.OlvColumn65.AspectName = "ContributionGuaranteeFund"
        Me.OlvColumn65.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn65.CellEditUseWholeCell = true
        Me.OlvColumn65.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn65.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn65.IsEditable = false
        Me.OlvColumn65.Text = "Prisk gar. fond."
        Me.OlvColumn65.ToolTipText = ""
        Me.OlvColumn65.Width = 119
        '
        'OlvColumn66
        '
        Me.OlvColumn66.AspectName = "PayOutTotalAfterDeductions"
        Me.OlvColumn66.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn66.CellEditUseWholeCell = true
        Me.OlvColumn66.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn66.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn66.IsEditable = false
        Me.OlvColumn66.Text = "Mokėtina"
        Me.OlvColumn66.ToolTipText = ""
        Me.OlvColumn66.Width = 84
        '
        'OlvColumn67
        '
        Me.OlvColumn67.AspectName = "UsedNPD"
        Me.OlvColumn67.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn67.CellEditUseWholeCell = true
        Me.OlvColumn67.DisplayIndex = 66
        Me.OlvColumn67.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn67.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn67.IsEditable = false
        Me.OlvColumn67.IsVisible = false
        Me.OlvColumn67.Text = "Panaud. NPD"
        Me.OlvColumn67.ToolTipText = ""
        Me.OlvColumn67.Width = 109
        '
        'OlvColumn68
        '
        Me.OlvColumn68.AspectName = "OtherIncome"
        Me.OlvColumn68.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn68.CellEditUseWholeCell = true
        Me.OlvColumn68.DisplayIndex = 67
        Me.OlvColumn68.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn68.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn68.IsEditable = false
        Me.OlvColumn68.IsVisible = false
        Me.OlvColumn68.Text = "Kt. pajamos"
        Me.OlvColumn68.ToolTipText = ""
        Me.OlvColumn68.Width = 98
        '
        'OlvColumn69
        '
        Me.OlvColumn69.AspectName = "HoursForVDU"
        Me.OlvColumn69.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn69.CellEditUseWholeCell = true
        Me.OlvColumn69.DisplayIndex = 68
        Me.OlvColumn69.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn69.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn69.IsVisible = false
        Me.OlvColumn69.Text = "Val. VDU skaičiavimui"
        Me.OlvColumn69.ToolTipText = ""
        Me.OlvColumn69.Width = 157
        '
        'OlvColumn70
        '
        Me.OlvColumn70.AspectName = "DaysForVDU"
        Me.OlvColumn70.AspectToStringFormat = "{0:##}"
        Me.OlvColumn70.CellEditUseWholeCell = true
        Me.OlvColumn70.DisplayIndex = 69
        Me.OlvColumn70.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn70.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn70.IsVisible = false
        Me.OlvColumn70.Text = "D.d. VDU skaičiavimui"
        Me.OlvColumn70.ToolTipText = ""
        Me.OlvColumn70.Width = 159
        '
        'OlvColumn71
        '
        Me.OlvColumn71.AspectName = "WageForVDU"
        Me.OlvColumn71.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn71.CellEditUseWholeCell = true
        Me.OlvColumn71.DisplayIndex = 70
        Me.OlvColumn71.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn71.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn71.IsVisible = false
        Me.OlvColumn71.Text = "DU VDU skaičiavimui"
        Me.OlvColumn71.ToolTipText = ""
        Me.OlvColumn71.Width = 153
        '
        'OlvColumn72
        '
        Me.OlvColumn72.AspectName = "PayedOutDate"
        Me.OlvColumn72.AspectToStringFormat = "{0:yyyy-MM-dd}"
        Me.OlvColumn72.CellEditUseWholeCell = true
        Me.OlvColumn72.DisplayIndex = 71
        Me.OlvColumn72.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.OlvColumn72.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn72.IsVisible = false
        Me.OlvColumn72.Text = "Išmokėjimo data"
        Me.OlvColumn72.ToolTipText = ""
        Me.OlvColumn72.Width = 100
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "NpdSickLeave"
        Me.OlvColumn2.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn2.AutoCompleteEditor = false
        Me.OlvColumn2.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None
        Me.OlvColumn2.CellEditUseWholeCell = true
        Me.OlvColumn2.Groupable = false
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.Text = "Pritaikytas NPD Ligai"
        Me.OlvColumn2.Width = 40
        '
        'OlvColumn73
        '
        Me.OlvColumn73.AspectName = "DeductedGpmSickLeave"
        Me.OlvColumn73.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn73.AutoCompleteEditor = false
        Me.OlvColumn73.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None
        Me.OlvColumn73.Groupable = false
        Me.OlvColumn73.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.OlvColumn73.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn73.Text = "Išskaičiuota GPM Liga"
        Me.OlvColumn73.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn73.Width = 40
        '
        'WageSheetBindingSource
        '
        Me.WageSheetBindingSource.DataSource = GetType(ApskaitaObjects.Workers.WageSheet)
        '
        'CostAccountAccListComboBox
        '
        Me.CostAccountAccListComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.WageSheetBindingSource, "CostAccount", true))
        Me.CostAccountAccListComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CostAccountAccListComboBox.EmptyValueString = ""
        Me.CostAccountAccListComboBox.Location = New System.Drawing.Point(485, 3)
        Me.CostAccountAccListComboBox.Name = "CostAccountAccListComboBox"
        Me.CostAccountAccListComboBox.Size = New System.Drawing.Size(152, 20)
        Me.CostAccountAccListComboBox.TabIndex = 75
        '
        'DateAccDatePicker
        '
        Me.DateAccDatePicker.BoldedDates = Nothing
        Me.DateAccDatePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.WageSheetBindingSource, "Date", true))
        Me.DateAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateAccDatePicker.Location = New System.Drawing.Point(3, 3)
        Me.DateAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateAccDatePicker.Name = "DateAccDatePicker"
        Me.DateAccDatePicker.ShowWeekNumbers = true
        Me.DateAccDatePicker.Size = New System.Drawing.Size(151, 20)
        Me.DateAccDatePicker.TabIndex = 74
        '
        'NumberAccTextBox
        '
        Me.NumberAccTextBox.ButtonVisible = false
        Me.NumberAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "Number", true))
        Me.NumberAccTextBox.DecimalLength = 0
        Me.NumberAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NumberAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.NumberAccTextBox.Location = New System.Drawing.Point(209, 0)
        Me.NumberAccTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.NumberAccTextBox.Name = "NumberAccTextBox"
        Me.NumberAccTextBox.NegativeValue = false
        Me.NumberAccTextBox.Size = New System.Drawing.Size(154, 20)
        Me.NumberAccTextBox.TabIndex = 1
        Me.NumberAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RateSODRAEmployerAccTextBox
        '
        Me.RateSODRAEmployerAccTextBox.ButtonVisible = false
        Me.RateSODRAEmployerAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "WageRates.RateSODRAEmployer", true))
        Me.RateSODRAEmployerAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RateSODRAEmployerAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RateSODRAEmployerAccTextBox.Location = New System.Drawing.Point(3, 3)
        Me.RateSODRAEmployerAccTextBox.Name = "RateSODRAEmployerAccTextBox"
        Me.RateSODRAEmployerAccTextBox.NegativeValue = false
        Me.RateSODRAEmployerAccTextBox.Size = New System.Drawing.Size(83, 20)
        Me.RateSODRAEmployerAccTextBox.TabIndex = 79
        Me.RateSODRAEmployerAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RateGuaranteeFundAccTextBox
        '
        Me.RateGuaranteeFundAccTextBox.ButtonVisible = false
        Me.RateGuaranteeFundAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "WageRates.RateGuaranteeFund", true))
        Me.RateGuaranteeFundAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RateGuaranteeFundAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RateGuaranteeFundAccTextBox.Location = New System.Drawing.Point(338, 3)
        Me.RateGuaranteeFundAccTextBox.Name = "RateGuaranteeFundAccTextBox"
        Me.RateGuaranteeFundAccTextBox.NegativeValue = false
        Me.RateGuaranteeFundAccTextBox.Size = New System.Drawing.Size(84, 20)
        Me.RateGuaranteeFundAccTextBox.TabIndex = 75
        Me.RateGuaranteeFundAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RatePSDEmployerAccTextBox
        '
        Me.RatePSDEmployerAccTextBox.ButtonVisible = false
        Me.RatePSDEmployerAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "WageRates.RatePSDEmployer", true))
        Me.RatePSDEmployerAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RatePSDEmployerAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RatePSDEmployerAccTextBox.Location = New System.Drawing.Point(154, 3)
        Me.RatePSDEmployerAccTextBox.Name = "RatePSDEmployerAccTextBox"
        Me.RatePSDEmployerAccTextBox.NegativeValue = false
        Me.RatePSDEmployerAccTextBox.Size = New System.Drawing.Size(84, 20)
        Me.RatePSDEmployerAccTextBox.TabIndex = 77
        Me.RatePSDEmployerAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RatePSDEmployeeAccTextBox
        '
        Me.RatePSDEmployeeAccTextBox.ButtonVisible = false
        Me.RatePSDEmployeeAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "WageRates.RatePSDEmployee", true))
        Me.RatePSDEmployeeAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RatePSDEmployeeAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RatePSDEmployeeAccTextBox.Location = New System.Drawing.Point(119, 3)
        Me.RatePSDEmployeeAccTextBox.Name = "RatePSDEmployeeAccTextBox"
        Me.RatePSDEmployeeAccTextBox.NegativeValue = false
        Me.RatePSDEmployeeAccTextBox.Size = New System.Drawing.Size(53, 20)
        Me.RatePSDEmployeeAccTextBox.TabIndex = 76
        Me.RatePSDEmployeeAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RateSODRAEmployeeAccTextBox
        '
        Me.RateSODRAEmployeeAccTextBox.ButtonVisible = false
        Me.RateSODRAEmployeeAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "WageRates.RateSODRAEmployee", true))
        Me.RateSODRAEmployeeAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RateSODRAEmployeeAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RateSODRAEmployeeAccTextBox.Location = New System.Drawing.Point(3, 3)
        Me.RateSODRAEmployeeAccTextBox.Name = "RateSODRAEmployeeAccTextBox"
        Me.RateSODRAEmployeeAccTextBox.NegativeValue = false
        Me.RateSODRAEmployeeAccTextBox.Size = New System.Drawing.Size(53, 20)
        Me.RateSODRAEmployeeAccTextBox.TabIndex = 78
        Me.RateSODRAEmployeeAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RateGPMAccTextBox
        '
        Me.RateGPMAccTextBox.ButtonVisible = false
        Me.RateGPMAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "WageRates.RateGPM", true))
        Me.RateGPMAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RateGPMAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RateGPMAccTextBox.Location = New System.Drawing.Point(237, 3)
        Me.RateGPMAccTextBox.Name = "RateGPMAccTextBox"
        Me.RateGPMAccTextBox.NegativeValue = false
        Me.RateGPMAccTextBox.Size = New System.Drawing.Size(53, 20)
        Me.RateGPMAccTextBox.TabIndex = 74
        Me.RateGPMAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RateGPMSickLeaveAccTextBox
        '
        Me.RateGPMSickLeaveAccTextBox.ButtonVisible = false
        Me.RateGPMSickLeaveAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "WageRates.RateGPMSickLeave", true))
        Me.RateGPMSickLeaveAccTextBox.DisableDropDown = true
        Me.RateGPMSickLeaveAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RateGPMSickLeaveAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RateGPMSickLeaveAccTextBox.Location = New System.Drawing.Point(379, 3)
        Me.RateGPMSickLeaveAccTextBox.Name = "RateGPMSickLeaveAccTextBox"
        Me.RateGPMSickLeaveAccTextBox.NegativeValue = false
        Me.RateGPMSickLeaveAccTextBox.Size = New System.Drawing.Size(53, 20)
        Me.RateGPMSickLeaveAccTextBox.TabIndex = 80
        Me.RateGPMSickLeaveAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RateSickLeaveAccTextBox1
        '
        Me.RateSickLeaveAccTextBox1.ButtonVisible = false
        Me.RateSickLeaveAccTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "WageRates.RateSickLeave", true))
        Me.RateSickLeaveAccTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RateSickLeaveAccTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RateSickLeaveAccTextBox1.Location = New System.Drawing.Point(142, 78)
        Me.RateSickLeaveAccTextBox1.Name = "RateSickLeaveAccTextBox1"
        Me.RateSickLeaveAccTextBox1.NegativeValue = false
        Me.RateSickLeaveAccTextBox1.Size = New System.Drawing.Size(92, 20)
        Me.RateSickLeaveAccTextBox1.TabIndex = 76
        Me.RateSickLeaveAccTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RateSCAccTextBox1
        '
        Me.RateSCAccTextBox1.ButtonVisible = false
        Me.RateSCAccTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "WageRates.RateSC", true))
        Me.RateSCAccTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RateSCAccTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RateSCAccTextBox1.Location = New System.Drawing.Point(142, 53)
        Me.RateSCAccTextBox1.Name = "RateSCAccTextBox1"
        Me.RateSCAccTextBox1.NegativeValue = false
        Me.RateSCAccTextBox1.Size = New System.Drawing.Size(92, 20)
        Me.RateSCAccTextBox1.TabIndex = 75
        Me.RateSCAccTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RateONAccTextBox1
        '
        Me.RateONAccTextBox1.ButtonVisible = false
        Me.RateONAccTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "WageRates.RateON", true))
        Me.RateONAccTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RateONAccTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RateONAccTextBox1.Location = New System.Drawing.Point(142, 3)
        Me.RateONAccTextBox1.Name = "RateONAccTextBox1"
        Me.RateONAccTextBox1.NegativeValue = false
        Me.RateONAccTextBox1.Size = New System.Drawing.Size(92, 20)
        Me.RateONAccTextBox1.TabIndex = 74
        Me.RateONAccTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RateHRAccTextBox1
        '
        Me.RateHRAccTextBox1.ButtonVisible = false
        Me.RateHRAccTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.WageSheetBindingSource, "WageRates.RateHR", true))
        Me.RateHRAccTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RateHRAccTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.RateHRAccTextBox1.Location = New System.Drawing.Point(142, 28)
        Me.RateHRAccTextBox1.Name = "RateHRAccTextBox1"
        Me.RateHRAccTextBox1.NegativeValue = false
        Me.RateHRAccTextBox1.Size = New System.Drawing.Size(92, 20)
        Me.RateHRAccTextBox1.TabIndex = 73
        Me.RateHRAccTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PaymentDateAccDatePicker
        '
        Me.PaymentDateAccDatePicker.BoldedDates = Nothing
        Me.PaymentDateAccDatePicker.Location = New System.Drawing.Point(6, 15)
        Me.PaymentDateAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.PaymentDateAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.PaymentDateAccDatePicker.Name = "PaymentDateAccDatePicker"
        Me.PaymentDateAccDatePicker.ShowWeekNumbers = true
        Me.PaymentDateAccDatePicker.Size = New System.Drawing.Size(113, 20)
        Me.PaymentDateAccDatePicker.TabIndex = 6
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(398, 180)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(185, 45)
        Me.ProgressFiller2.TabIndex = 73
        Me.ProgressFiller2.Visible = false
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(157, 180)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(193, 45)
        Me.ProgressFiller1.TabIndex = 72
        Me.ProgressFiller1.Visible = false
        '
        'ErrorWarnInfoProvider1
        '
        Me.ErrorWarnInfoProvider1.ContainerControl = Me
        Me.ErrorWarnInfoProvider1.DataSource = Me.WageSheetBindingSource
        '
        'F_WageSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = true
        Me.ClientSize = New System.Drawing.Size(928, 491)
        Me.Controls.Add(Me.ItemsDataListView)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "F_WageSheet"
        Me.ShowInTaskbar = false
        Me.Text = "Darbo užmokesčio žiniaraštis"
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        CType(Me.ItemsBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel2.ResumeLayout(false)
        Me.TableLayoutPanel2.PerformLayout
        Me.TableLayoutPanel6.ResumeLayout(false)
        Me.TableLayoutPanel6.PerformLayout
        Me.TableLayoutPanel5.ResumeLayout(false)
        Me.TableLayoutPanel5.PerformLayout
        Me.TableLayoutPanel3.ResumeLayout(false)
        Me.TableLayoutPanel3.PerformLayout
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage2.ResumeLayout(false)
        Me.TableLayoutPanel12.ResumeLayout(false)
        Me.GroupBox1.ResumeLayout(false)
        Me.TableLayoutPanel8.ResumeLayout(false)
        Me.TableLayoutPanel8.PerformLayout
        Me.TableLayoutPanel7.ResumeLayout(false)
        Me.TableLayoutPanel7.PerformLayout
        Me.TableLayoutPanel10.ResumeLayout(false)
        Me.TableLayoutPanel10.PerformLayout
        Me.TableLayoutPanel9.ResumeLayout(false)
        Me.TableLayoutPanel9.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.TableLayoutPanel11.ResumeLayout(false)
        Me.TableLayoutPanel11.PerformLayout
        CType(Me.ItemsDataListView,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.WageSheetBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.ErrorWarnInfoProvider1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents NewWageSheetButton As System.Windows.Forms.Button
    Friend WithEvents nCancelButton As System.Windows.Forms.Button
    Friend WithEvents ApplyButton As System.Windows.Forms.Button
    Friend WithEvents nOkButton As System.Windows.Forms.Button
    Friend WithEvents WageSheetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IsNonClosingCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents YearTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MonthTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RefreshTaxesButton As System.Windows.Forms.Button
    Friend WithEvents RefreshWageTarifButton As System.Windows.Forms.Button
    Friend WithEvents CalculateNPDButton As System.Windows.Forms.Button
    Friend WithEvents GetVDUButton As System.Windows.Forms.Button
    Friend WithEvents ItemsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents NumberAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents RemarksTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel11 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel12 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents NPDFormulaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RateSODRAEmployerAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents RateSODRAEmployeeAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents RatePSDEmployerAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents RatePSDEmployeeAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents RateGuaranteeFundAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents RateGPMAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents RateSickLeaveAccTextBox1 As AccControlsWinForms.AccTextBox
    Friend WithEvents RateSCAccTextBox1 As AccControlsWinForms.AccTextBox
    Friend WithEvents RateONAccTextBox1 As AccControlsWinForms.AccTextBox
    Friend WithEvents RateHRAccTextBox1 As AccControlsWinForms.AccTextBox
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents SetPaymentDateButton As System.Windows.Forms.Button
    Friend WithEvents ItemsDataListView As BrightIdeasSoftware.DataListView
    Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
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
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ErrorWarnInfoProvider1 As AccControlsWinForms.ErrorWarnInfoProvider
    Friend WithEvents PaymentDateAccDatePicker As AccControlsWinForms.AccDatePicker
    Friend WithEvents RateGPMSickLeaveAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents ApplyNpdToSickLeaveCheckBox As CheckBox
    Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents OlvColumn73 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ExportPaymentsButton As Button
    Friend WithEvents CostAccountAccListComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents DateAccDatePicker As AccControlsWinForms.AccDatePicker
End Class
