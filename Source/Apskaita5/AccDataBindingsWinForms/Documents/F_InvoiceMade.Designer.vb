﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_InvoiceMade
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
        Dim AccountPayerLabel As System.Windows.Forms.Label
        Dim CommentsInternalLabel As System.Windows.Forms.Label
        Dim ContentLabel As System.Windows.Forms.Label
        Dim CurrencyCodeLabel As System.Windows.Forms.Label
        Dim CurrencyRateLabel As System.Windows.Forms.Label
        Dim DateLabel As System.Windows.Forms.Label
        Dim FullNumberLabel As System.Windows.Forms.Label
        Dim IDLabel As System.Windows.Forms.Label
        Dim LanguageNameLabel As System.Windows.Forms.Label
        Dim NumberLabel As System.Windows.Forms.Label
        Dim PayerLabel As System.Windows.Forms.Label
        Dim SerialLabel As System.Windows.Forms.Label
        Dim SumLabel As System.Windows.Forms.Label
        Dim SumDiscountLabel As System.Windows.Forms.Label
        Dim SumDiscountVatLabel As System.Windows.Forms.Label
        Dim SumTotalLabel As System.Windows.Forms.Label
        Dim SumVatLabel As System.Windows.Forms.Label
        Dim SumTotalLTLLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim TypeHumanReadableLabel As System.Windows.Forms.Label
        Dim UpdateDateLabel As System.Windows.Forms.Label
        Dim InsertDateLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_InvoiceMade))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel14 = New System.Windows.Forms.TableLayoutPanel
        Me.TypeHumanReadableComboBox = New System.Windows.Forms.ComboBox
        Me.InvoiceMadeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AddAttachedObjectButton = New System.Windows.Forms.Button
        Me.NewAdapterTypeComboBox = New System.Windows.Forms.ComboBox
        Me.CopyInvoiceButton = New System.Windows.Forms.Button
        Me.PasteInvoiceButton = New System.Windows.Forms.Button
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel
        Me.SumDiscountAccTextBox = New AccControlsWinForms.AccTextBox
        Me.SumTotalLTLAccTextBox = New AccControlsWinForms.AccTextBox
        Me.SumDiscountVatAccTextBox = New AccControlsWinForms.AccTextBox
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel
        Me.CommentsInternalTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel
        Me.SumAccTextBox = New AccControlsWinForms.AccTextBox
        Me.SumVatAccTextBox = New AccControlsWinForms.AccTextBox
        Me.SumTotalAccTextBox = New AccControlsWinForms.AccTextBox
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.SerialComboBox = New System.Windows.Forms.ComboBox
        Me.AccountPayerAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.NumberAccTextBox = New AccControlsWinForms.AccTextBox
        Me.RefreshNumberButton = New System.Windows.Forms.Button
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel
        Me.ContentTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.CurrencyCodeComboBox = New System.Windows.Forms.ComboBox
        Me.CurrencyRateAccTextBox = New AccControlsWinForms.AccTextBox
        Me.GetCurrencyRatesButton = New System.Windows.Forms.Button
        Me.DateAccDatePicker = New AccControlsWinForms.AccDatePicker
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.ViewJournalEntryButton = New System.Windows.Forms.Button
        Me.IDTextBox = New System.Windows.Forms.TextBox
        Me.InsertDateTextBox = New System.Windows.Forms.TextBox
        Me.UpdateDateTextBox = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.PayerAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.LanguageNameComboBox = New System.Windows.Forms.ComboBox
        Me.FullNumberTextBox = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel13 = New System.Windows.Forms.TableLayoutPanel
        Me.VatExemptInfoAltLngTextBox = New System.Windows.Forms.TextBox
        Me.VatExemptInfoTextBox = New System.Windows.Forms.TextBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TableLayoutPanel12 = New System.Windows.Forms.TableLayoutPanel
        Me.CustomInfoAltLngTextBox = New System.Windows.Forms.TextBox
        Me.CustomInfoTextBox = New System.Windows.Forms.TextBox
        Me.InvoiceItemsSortedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.NewButton = New System.Windows.Forms.Button
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.InvoiceItemsDataListView = New BrightIdeasSoftware.DataListView
        Me.OlvColumn1 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn2 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn3 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn4 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn5 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn6 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn7 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn8 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn9 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn10 = New BrightIdeasSoftware.OLVColumn
        Me.OlvColumn33 = New BrightIdeasSoftware.OLVColumn
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
        Me.ProgressFiller2 = New AccControlsWinForms.ProgressFiller
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ErrorWarnInfoProvider1 = New AccControlsWinForms.ErrorWarnInfoProvider(Me.components)
        AccountPayerLabel = New System.Windows.Forms.Label
        CommentsInternalLabel = New System.Windows.Forms.Label
        ContentLabel = New System.Windows.Forms.Label
        CurrencyCodeLabel = New System.Windows.Forms.Label
        CurrencyRateLabel = New System.Windows.Forms.Label
        DateLabel = New System.Windows.Forms.Label
        FullNumberLabel = New System.Windows.Forms.Label
        IDLabel = New System.Windows.Forms.Label
        LanguageNameLabel = New System.Windows.Forms.Label
        NumberLabel = New System.Windows.Forms.Label
        PayerLabel = New System.Windows.Forms.Label
        SerialLabel = New System.Windows.Forms.Label
        SumLabel = New System.Windows.Forms.Label
        SumDiscountLabel = New System.Windows.Forms.Label
        SumDiscountVatLabel = New System.Windows.Forms.Label
        SumTotalLabel = New System.Windows.Forms.Label
        SumVatLabel = New System.Windows.Forms.Label
        SumTotalLTLLabel = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        TypeHumanReadableLabel = New System.Windows.Forms.Label
        UpdateDateLabel = New System.Windows.Forms.Label
        InsertDateLabel = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel14.SuspendLayout()
        CType(Me.InvoiceMadeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel13.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TableLayoutPanel12.SuspendLayout()
        CType(Me.InvoiceItemsSortedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.InvoiceItemsDataListView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AccountPayerLabel
        '
        AccountPayerLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        AccountPayerLabel.AutoSize = True
        AccountPayerLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AccountPayerLabel.Location = New System.Drawing.Point(497, 3)
        AccountPayerLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        AccountPayerLabel.Name = "AccountPayerLabel"
        AccountPayerLabel.Size = New System.Drawing.Size(84, 13)
        AccountPayerLabel.TabIndex = 2
        AccountPayerLabel.Text = "Pirkėjo sąsk.:"
        '
        'CommentsInternalLabel
        '
        CommentsInternalLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CommentsInternalLabel.AutoSize = True
        CommentsInternalLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CommentsInternalLabel.Location = New System.Drawing.Point(18, 186)
        CommentsInternalLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        CommentsInternalLabel.Name = "CommentsInternalLabel"
        CommentsInternalLabel.Size = New System.Drawing.Size(74, 13)
        CommentsInternalLabel.TabIndex = 4
        CommentsInternalLabel.Text = "Komentarai:"
        '
        'ContentLabel
        '
        ContentLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ContentLabel.AutoSize = True
        ContentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContentLabel.Location = New System.Drawing.Point(40, 156)
        ContentLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        ContentLabel.Name = "ContentLabel"
        ContentLabel.Size = New System.Drawing.Size(52, 13)
        ContentLabel.TabIndex = 6
        ContentLabel.Text = "Turinys:"
        '
        'CurrencyCodeLabel
        '
        CurrencyCodeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CurrencyCodeLabel.AutoSize = True
        CurrencyCodeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyCodeLabel.Location = New System.Drawing.Point(217, 3)
        CurrencyCodeLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        CurrencyCodeLabel.Name = "CurrencyCodeLabel"
        CurrencyCodeLabel.Size = New System.Drawing.Size(50, 13)
        CurrencyCodeLabel.TabIndex = 8
        CurrencyCodeLabel.Text = "Valiuta:"
        '
        'CurrencyRateLabel
        '
        CurrencyRateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CurrencyRateLabel.AutoSize = True
        CurrencyRateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CurrencyRateLabel.Location = New System.Drawing.Point(484, 3)
        CurrencyRateLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        CurrencyRateLabel.Name = "CurrencyRateLabel"
        CurrencyRateLabel.Size = New System.Drawing.Size(49, 13)
        CurrencyRateLabel.TabIndex = 10
        CurrencyRateLabel.Text = "Kursas:"
        '
        'DateLabel
        '
        DateLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DateLabel.AutoSize = True
        DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateLabel.Location = New System.Drawing.Point(54, 36)
        DateLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(38, 13)
        DateLabel.TabIndex = 12
        DateLabel.Text = "Data:"
        '
        'FullNumberLabel
        '
        FullNumberLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        FullNumberLabel.AutoSize = True
        FullNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FullNumberLabel.Location = New System.Drawing.Point(0, 96)
        FullNumberLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        FullNumberLabel.Name = "FullNumberLabel"
        FullNumberLabel.Size = New System.Drawing.Size(92, 13)
        FullNumberLabel.TabIndex = 14
        FullNumberLabel.Text = "Pilnas numeris:"
        '
        'IDLabel
        '
        IDLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        IDLabel.AutoSize = True
        IDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDLabel.Location = New System.Drawing.Point(68, 6)
        IDLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        IDLabel.Name = "IDLabel"
        IDLabel.Size = New System.Drawing.Size(24, 13)
        IDLabel.TabIndex = 16
        IDLabel.Text = "ID:"
        '
        'LanguageNameLabel
        '
        LanguageNameLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        LanguageNameLabel.AutoSize = True
        LanguageNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LanguageNameLabel.Location = New System.Drawing.Point(375, 3)
        LanguageNameLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        LanguageNameLabel.Name = "LanguageNameLabel"
        LanguageNameLabel.Size = New System.Drawing.Size(43, 13)
        LanguageNameLabel.TabIndex = 18
        LanguageNameLabel.Text = "Kalba:"
        '
        'NumberLabel
        '
        NumberLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        NumberLabel.AutoSize = True
        NumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NumberLabel.Location = New System.Drawing.Point(209, 3)
        NumberLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        NumberLabel.Name = "NumberLabel"
        NumberLabel.Size = New System.Drawing.Size(56, 13)
        NumberLabel.TabIndex = 20
        NumberLabel.Text = "Numeris:"
        '
        'PayerLabel
        '
        PayerLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        PayerLabel.AutoSize = True
        PayerLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        PayerLabel.Location = New System.Drawing.Point(36, 126)
        PayerLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        PayerLabel.Name = "PayerLabel"
        PayerLabel.Size = New System.Drawing.Size(56, 13)
        PayerLabel.TabIndex = 22
        PayerLabel.Text = "Pirkėjas:"
        '
        'SerialLabel
        '
        SerialLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SerialLabel.AutoSize = True
        SerialLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerialLabel.Location = New System.Drawing.Point(49, 66)
        SerialLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        SerialLabel.Name = "SerialLabel"
        SerialLabel.Size = New System.Drawing.Size(43, 13)
        SerialLabel.TabIndex = 24
        SerialLabel.Text = "Serija:"
        '
        'SumLabel
        '
        SumLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SumLabel.AutoSize = True
        SumLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumLabel.Location = New System.Drawing.Point(50, 216)
        SumLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        SumLabel.Name = "SumLabel"
        SumLabel.Size = New System.Drawing.Size(42, 13)
        SumLabel.TabIndex = 26
        SumLabel.Text = "Suma:"
        '
        'SumDiscountLabel
        '
        SumDiscountLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SumDiscountLabel.AutoSize = True
        SumDiscountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumDiscountLabel.Location = New System.Drawing.Point(31, 246)
        SumDiscountLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        SumDiscountLabel.Name = "SumDiscountLabel"
        SumDiscountLabel.Size = New System.Drawing.Size(61, 13)
        SumDiscountLabel.TabIndex = 28
        SumDiscountLabel.Text = "Nuolaida:"
        '
        'SumDiscountVatLabel
        '
        SumDiscountVatLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SumDiscountVatLabel.AutoSize = True
        SumDiscountVatLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumDiscountVatLabel.Location = New System.Drawing.Point(202, 3)
        SumDiscountVatLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        SumDiscountVatLabel.Name = "SumDiscountVatLabel"
        SumDiscountVatLabel.Size = New System.Drawing.Size(91, 13)
        SumDiscountVatLabel.TabIndex = 32
        SumDiscountVatLabel.Text = "Nuolaida PVM:"
        '
        'SumTotalLabel
        '
        SumTotalLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SumTotalLabel.AutoSize = True
        SumTotalLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumTotalLabel.Location = New System.Drawing.Point(506, 3)
        SumTotalLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        SumTotalLabel.Name = "SumTotalLabel"
        SumTotalLabel.Size = New System.Drawing.Size(70, 13)
        SumTotalLabel.TabIndex = 38
        SumTotalLabel.Text = "Suma Viso:"
        '
        'SumVatLabel
        '
        SumVatLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SumVatLabel.AutoSize = True
        SumVatLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumVatLabel.Location = New System.Drawing.Point(217, 3)
        SumVatLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        SumVatLabel.Name = "SumVatLabel"
        SumVatLabel.Size = New System.Drawing.Size(72, 13)
        SumVatLabel.TabIndex = 42
        SumVatLabel.Text = "Suma PVM:"
        '
        'SumTotalLTLLabel
        '
        SumTotalLTLLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        SumTotalLTLLabel.AutoSize = True
        SumTotalLTLLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SumTotalLTLLabel.Location = New System.Drawing.Point(495, 3)
        SumTotalLTLLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        SumTotalLTLLabel.Name = "SumTotalLTLLabel"
        SumTotalLTLLabel.Size = New System.Drawing.Size(96, 13)
        SumTotalLTLLabel.TabIndex = 49
        SumTotalLTLLabel.Text = "Suma Viso LTL:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(0, 6)
        Label1.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(87, 13)
        Label1.TabIndex = 17
        Label1.Text = "Lietuvių kalba"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(0, 157)
        Label2.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(90, 13)
        Label2.TabIndex = 18
        Label2.Text = "Užsienio kalba"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(0, 6)
        Label3.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(87, 13)
        Label3.TabIndex = 18
        Label3.Text = "Lietuvių kalba"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label4.Location = New System.Drawing.Point(0, 160)
        Label4.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(90, 13)
        Label4.TabIndex = 19
        Label4.Text = "Užsienio kalba"
        '
        'TypeHumanReadableLabel
        '
        TypeHumanReadableLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        TypeHumanReadableLabel.AutoSize = True
        TypeHumanReadableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TypeHumanReadableLabel.Location = New System.Drawing.Point(50, 276)
        TypeHumanReadableLabel.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        TypeHumanReadableLabel.Name = "TypeHumanReadableLabel"
        TypeHumanReadableLabel.Size = New System.Drawing.Size(42, 13)
        TypeHumanReadableLabel.TabIndex = 55
        TypeHumanReadableLabel.Text = "Tipas:"
        '
        'UpdateDateLabel
        '
        UpdateDateLabel.AutoSize = True
        UpdateDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        UpdateDateLabel.Location = New System.Drawing.Point(503, 3)
        UpdateDateLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        UpdateDateLabel.Name = "UpdateDateLabel"
        UpdateDateLabel.Size = New System.Drawing.Size(60, 13)
        UpdateDateLabel.TabIndex = 56
        UpdateDateLabel.Text = "Pakeista:"
        '
        'InsertDateLabel
        '
        InsertDateLabel.AutoSize = True
        InsertDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        InsertDateLabel.Location = New System.Drawing.Point(221, 3)
        InsertDateLabel.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        InsertDateLabel.Name = "InsertDateLabel"
        InsertDateLabel.Size = New System.Drawing.Size(55, 13)
        InsertDateLabel.TabIndex = 57
        InsertDateLabel.Text = "Įtraukta:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(899, 335)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(891, 309)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Bendra Informacija"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel14, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(TypeHumanReadableLabel, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel10, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel9, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel7, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(SumDiscountLabel, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(SumLabel, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel8, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel6, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(IDLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(DateLabel, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(SerialLabel, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(FullNumberLabel, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(PayerLabel, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(ContentLabel, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(CommentsInternalLabel, 0, 6)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(885, 303)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel14
        '
        Me.TableLayoutPanel14.ColumnCount = 11
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel14.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel14.Controls.Add(Me.TypeHumanReadableComboBox, 0, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.AddAttachedObjectButton, 5, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.NewAdapterTypeComboBox, 4, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.CopyInvoiceButton, 7, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.PasteInvoiceButton, 9, 0)
        Me.TableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel14.Location = New System.Drawing.Point(92, 273)
        Me.TableLayoutPanel14.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel14.Name = "TableLayoutPanel14"
        Me.TableLayoutPanel14.RowCount = 1
        Me.TableLayoutPanel14.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel14.Size = New System.Drawing.Size(793, 29)
        Me.TableLayoutPanel14.TabIndex = 9
        '
        'TypeHumanReadableComboBox
        '
        Me.TypeHumanReadableComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceMadeBindingSource, "TypeHumanReadable", True))
        Me.TypeHumanReadableComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TypeHumanReadableComboBox.FormattingEnabled = True
        Me.TypeHumanReadableComboBox.Location = New System.Drawing.Point(0, 0)
        Me.TypeHumanReadableComboBox.Margin = New System.Windows.Forms.Padding(0)
        Me.TypeHumanReadableComboBox.Name = "TypeHumanReadableComboBox"
        Me.TypeHumanReadableComboBox.Size = New System.Drawing.Size(198, 21)
        Me.TypeHumanReadableComboBox.TabIndex = 0
        '
        'InvoiceMadeBindingSource
        '
        Me.InvoiceMadeBindingSource.DataSource = GetType(ApskaitaObjects.Documents.InvoiceMade)
        '
        'AddAttachedObjectButton
        '
        Me.AddAttachedObjectButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddAttachedObjectButton.Location = New System.Drawing.Point(636, 0)
        Me.AddAttachedObjectButton.Margin = New System.Windows.Forms.Padding(0)
        Me.AddAttachedObjectButton.Name = "AddAttachedObjectButton"
        Me.AddAttachedObjectButton.Size = New System.Drawing.Size(30, 29)
        Me.AddAttachedObjectButton.TabIndex = 3
        Me.AddAttachedObjectButton.Text = "+"
        Me.AddAttachedObjectButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.AddAttachedObjectButton.UseVisualStyleBackColor = True
        '
        'NewAdapterTypeComboBox
        '
        Me.NewAdapterTypeComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NewAdapterTypeComboBox.DropDownWidth = 300
        Me.NewAdapterTypeComboBox.FormattingEnabled = True
        Me.NewAdapterTypeComboBox.Location = New System.Drawing.Point(440, 3)
        Me.NewAdapterTypeComboBox.Name = "NewAdapterTypeComboBox"
        Me.NewAdapterTypeComboBox.Size = New System.Drawing.Size(193, 21)
        Me.NewAdapterTypeComboBox.TabIndex = 4
        '
        'CopyInvoiceButton
        '
        Me.CopyInvoiceButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyInvoiceButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Actions_edit_copy_icon_16p
        Me.CopyInvoiceButton.Location = New System.Drawing.Point(686, 0)
        Me.CopyInvoiceButton.Margin = New System.Windows.Forms.Padding(0)
        Me.CopyInvoiceButton.Name = "CopyInvoiceButton"
        Me.CopyInvoiceButton.Size = New System.Drawing.Size(30, 29)
        Me.CopyInvoiceButton.TabIndex = 1
        Me.CopyInvoiceButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CopyInvoiceButton.UseVisualStyleBackColor = True
        '
        'PasteInvoiceButton
        '
        Me.PasteInvoiceButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasteInvoiceButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Paste_icon_16p
        Me.PasteInvoiceButton.Location = New System.Drawing.Point(731, 0)
        Me.PasteInvoiceButton.Margin = New System.Windows.Forms.Padding(0)
        Me.PasteInvoiceButton.Name = "PasteInvoiceButton"
        Me.PasteInvoiceButton.Size = New System.Drawing.Size(30, 29)
        Me.PasteInvoiceButton.TabIndex = 2
        Me.PasteInvoiceButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.PasteInvoiceButton.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.ColumnCount = 8
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.Controls.Add(SumTotalLTLLabel, 5, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.SumDiscountAccTextBox, 0, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.SumTotalLTLAccTextBox, 6, 0)
        Me.TableLayoutPanel10.Controls.Add(SumDiscountVatLabel, 2, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.SumDiscountVatAccTextBox, 3, 0)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(92, 243)
        Me.TableLayoutPanel10.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(793, 24)
        Me.TableLayoutPanel10.TabIndex = 8
        '
        'SumDiscountAccTextBox
        '
        Me.SumDiscountAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceMadeBindingSource, "SumDiscount", True))
        Me.SumDiscountAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumDiscountAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SumDiscountAccTextBox.Location = New System.Drawing.Point(0, 0)
        Me.SumDiscountAccTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.SumDiscountAccTextBox.Name = "SumDiscountAccTextBox"
        Me.SumDiscountAccTextBox.ReadOnly = True
        Me.SumDiscountAccTextBox.Size = New System.Drawing.Size(182, 20)
        Me.SumDiscountAccTextBox.TabIndex = 29
        Me.SumDiscountAccTextBox.TabStop = False
        Me.SumDiscountAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumTotalLTLAccTextBox
        '
        Me.SumTotalLTLAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceMadeBindingSource, "SumTotalLTL", True))
        Me.SumTotalLTLAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumTotalLTLAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SumTotalLTLAccTextBox.Location = New System.Drawing.Point(591, 0)
        Me.SumTotalLTLAccTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.SumTotalLTLAccTextBox.Name = "SumTotalLTLAccTextBox"
        Me.SumTotalLTLAccTextBox.ReadOnly = True
        Me.SumTotalLTLAccTextBox.Size = New System.Drawing.Size(182, 20)
        Me.SumTotalLTLAccTextBox.TabIndex = 50
        Me.SumTotalLTLAccTextBox.TabStop = False
        Me.SumTotalLTLAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumDiscountVatAccTextBox
        '
        Me.SumDiscountVatAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceMadeBindingSource, "SumDiscountVat", True))
        Me.SumDiscountVatAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumDiscountVatAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SumDiscountVatAccTextBox.Location = New System.Drawing.Point(293, 0)
        Me.SumDiscountVatAccTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.SumDiscountVatAccTextBox.Name = "SumDiscountVatAccTextBox"
        Me.SumDiscountVatAccTextBox.ReadOnly = True
        Me.SumDiscountVatAccTextBox.Size = New System.Drawing.Size(182, 20)
        Me.SumDiscountVatAccTextBox.TabIndex = 33
        Me.SumDiscountVatAccTextBox.TabStop = False
        Me.SumDiscountVatAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 2
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.CommentsInternalTextBox, 0, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(92, 183)
        Me.TableLayoutPanel9.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(793, 24)
        Me.TableLayoutPanel9.TabIndex = 6
        '
        'CommentsInternalTextBox
        '
        Me.CommentsInternalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceMadeBindingSource, "CommentsInternal", True))
        Me.CommentsInternalTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CommentsInternalTextBox.Location = New System.Drawing.Point(0, 0)
        Me.CommentsInternalTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.CommentsInternalTextBox.MaxLength = 255
        Me.CommentsInternalTextBox.Name = "CommentsInternalTextBox"
        Me.CommentsInternalTextBox.Size = New System.Drawing.Size(773, 20)
        Me.CommentsInternalTextBox.TabIndex = 0
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 8
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.SumAccTextBox, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(SumTotalLabel, 5, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.SumVatAccTextBox, 3, 0)
        Me.TableLayoutPanel7.Controls.Add(SumVatLabel, 2, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.SumTotalAccTextBox, 6, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(92, 213)
        Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(793, 24)
        Me.TableLayoutPanel7.TabIndex = 7
        '
        'SumAccTextBox
        '
        Me.SumAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceMadeBindingSource, "Sum", True))
        Me.SumAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SumAccTextBox.Location = New System.Drawing.Point(0, 0)
        Me.SumAccTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.SumAccTextBox.Name = "SumAccTextBox"
        Me.SumAccTextBox.ReadOnly = True
        Me.SumAccTextBox.Size = New System.Drawing.Size(197, 20)
        Me.SumAccTextBox.TabIndex = 27
        Me.SumAccTextBox.TabStop = False
        Me.SumAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumVatAccTextBox
        '
        Me.SumVatAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceMadeBindingSource, "SumVat", True))
        Me.SumVatAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumVatAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SumVatAccTextBox.Location = New System.Drawing.Point(289, 0)
        Me.SumVatAccTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.SumVatAccTextBox.Name = "SumVatAccTextBox"
        Me.SumVatAccTextBox.ReadOnly = True
        Me.SumVatAccTextBox.Size = New System.Drawing.Size(197, 20)
        Me.SumVatAccTextBox.TabIndex = 43
        Me.SumVatAccTextBox.TabStop = False
        Me.SumVatAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SumTotalAccTextBox
        '
        Me.SumTotalAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceMadeBindingSource, "SumTotal", True))
        Me.SumTotalAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SumTotalAccTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SumTotalAccTextBox.Location = New System.Drawing.Point(576, 0)
        Me.SumTotalAccTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.SumTotalAccTextBox.Name = "SumTotalAccTextBox"
        Me.SumTotalAccTextBox.ReadOnly = True
        Me.SumTotalAccTextBox.Size = New System.Drawing.Size(197, 20)
        Me.SumTotalAccTextBox.TabIndex = 39
        Me.SumTotalAccTextBox.TabStop = False
        Me.SumTotalAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 9
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33628!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33186!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33186!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.SerialComboBox, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(NumberLabel, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.AccountPayerAccGridComboBox, 7, 0)
        Me.TableLayoutPanel4.Controls.Add(AccountPayerLabel, 6, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.NumberAccTextBox, 4, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.RefreshNumberButton, 3, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(92, 63)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(793, 24)
        Me.TableLayoutPanel4.TabIndex = 2
        '
        'SerialComboBox
        '
        Me.SerialComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceMadeBindingSource, "Serial", True))
        Me.SerialComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SerialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SerialComboBox.FormattingEnabled = True
        Me.SerialComboBox.Location = New System.Drawing.Point(0, 0)
        Me.SerialComboBox.Margin = New System.Windows.Forms.Padding(0)
        Me.SerialComboBox.Name = "SerialComboBox"
        Me.SerialComboBox.Size = New System.Drawing.Size(189, 21)
        Me.SerialComboBox.TabIndex = 0
        '
        'AccountPayerAccGridComboBox
        '
        Me.AccountPayerAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.InvoiceMadeBindingSource, "AccountPayer", True))
        Me.AccountPayerAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccountPayerAccGridComboBox.EmptyValueString = ""
        Me.AccountPayerAccGridComboBox.InstantBinding = True
        Me.AccountPayerAccGridComboBox.Location = New System.Drawing.Point(581, 0)
        Me.AccountPayerAccGridComboBox.Margin = New System.Windows.Forms.Padding(0)
        Me.AccountPayerAccGridComboBox.Name = "AccountPayerAccGridComboBox"
        Me.AccountPayerAccGridComboBox.Size = New System.Drawing.Size(188, 21)
        Me.AccountPayerAccGridComboBox.TabIndex = 3
        '
        'NumberAccTextBox
        '
        Me.NumberAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceMadeBindingSource, "Number", True))
        Me.NumberAccTextBox.DecimalLength = 0
        Me.NumberAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NumberAccTextBox.Location = New System.Drawing.Point(289, 0)
        Me.NumberAccTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.NumberAccTextBox.Name = "NumberAccTextBox"
        Me.NumberAccTextBox.NegativeValue = False
        Me.NumberAccTextBox.Size = New System.Drawing.Size(188, 20)
        Me.NumberAccTextBox.TabIndex = 2
        Me.NumberAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RefreshNumberButton
        '
        Me.RefreshNumberButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RefreshNumberButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.Button_Reload_icon_16p
        Me.RefreshNumberButton.Location = New System.Drawing.Point(265, 0)
        Me.RefreshNumberButton.Margin = New System.Windows.Forms.Padding(0)
        Me.RefreshNumberButton.Name = "RefreshNumberButton"
        Me.RefreshNumberButton.Size = New System.Drawing.Size(24, 24)
        Me.RefreshNumberButton.TabIndex = 1
        Me.RefreshNumberButton.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.ContentTextBox, 0, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(92, 153)
        Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(793, 24)
        Me.TableLayoutPanel8.TabIndex = 5
        '
        'ContentTextBox
        '
        Me.ContentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceMadeBindingSource, "Content", True))
        Me.ContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ContentTextBox.Location = New System.Drawing.Point(0, 0)
        Me.ContentTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.ContentTextBox.MaxLength = 255
        Me.ContentTextBox.Name = "ContentTextBox"
        Me.ContentTextBox.Size = New System.Drawing.Size(773, 20)
        Me.ContentTextBox.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoScroll = True
        Me.TableLayoutPanel2.ColumnCount = 9
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33444!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33444!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33112!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.CurrencyCodeComboBox, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(CurrencyCodeLabel, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(CurrencyRateLabel, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.CurrencyRateAccTextBox, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GetCurrencyRatesButton, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DateAccDatePicker, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(92, 33)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(793, 24)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'CurrencyCodeComboBox
        '
        Me.CurrencyCodeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceMadeBindingSource, "CurrencyCode", True))
        Me.CurrencyCodeComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyCodeComboBox.FormattingEnabled = True
        Me.CurrencyCodeComboBox.Location = New System.Drawing.Point(267, 0)
        Me.CurrencyCodeComboBox.Margin = New System.Windows.Forms.Padding(0)
        Me.CurrencyCodeComboBox.Name = "CurrencyCodeComboBox"
        Me.CurrencyCodeComboBox.Size = New System.Drawing.Size(197, 21)
        Me.CurrencyCodeComboBox.TabIndex = 1
        '
        'CurrencyRateAccTextBox
        '
        Me.CurrencyRateAccTextBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.InvoiceMadeBindingSource, "CurrencyRate", True))
        Me.CurrencyRateAccTextBox.DecimalLength = 6
        Me.CurrencyRateAccTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyRateAccTextBox.Location = New System.Drawing.Point(575, 0)
        Me.CurrencyRateAccTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.CurrencyRateAccTextBox.Name = "CurrencyRateAccTextBox"
        Me.CurrencyRateAccTextBox.NegativeValue = False
        Me.CurrencyRateAccTextBox.Size = New System.Drawing.Size(196, 20)
        Me.CurrencyRateAccTextBox.TabIndex = 3
        Me.CurrencyRateAccTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GetCurrencyRatesButton
        '
        Me.GetCurrencyRatesButton.AutoSize = True
        Me.GetCurrencyRatesButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GetCurrencyRatesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetCurrencyRatesButton.Location = New System.Drawing.Point(533, 0)
        Me.GetCurrencyRatesButton.Margin = New System.Windows.Forms.Padding(0)
        Me.GetCurrencyRatesButton.Name = "GetCurrencyRatesButton"
        Me.GetCurrencyRatesButton.Size = New System.Drawing.Size(42, 23)
        Me.GetCurrencyRatesButton.TabIndex = 2
        Me.GetCurrencyRatesButton.Text = "$->€"
        Me.GetCurrencyRatesButton.UseVisualStyleBackColor = True
        '
        'DateAccDatePicker
        '
        Me.DateAccDatePicker.BoldedDates = Nothing
        Me.DateAccDatePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.InvoiceMadeBindingSource, "Date", True))
        Me.DateAccDatePicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DateAccDatePicker.Location = New System.Drawing.Point(0, 0)
        Me.DateAccDatePicker.Margin = New System.Windows.Forms.Padding(0)
        Me.DateAccDatePicker.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.DateAccDatePicker.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.DateAccDatePicker.Name = "DateAccDatePicker"
        Me.DateAccDatePicker.ReadOnly = False
        Me.DateAccDatePicker.ShowWeekNumbers = True
        Me.DateAccDatePicker.Size = New System.Drawing.Size(197, 24)
        Me.DateAccDatePicker.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 9
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.ViewJournalEntryButton, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.IDTextBox, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(InsertDateLabel, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.InsertDateTextBox, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(UpdateDateLabel, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.UpdateDateTextBox, 7, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(92, 3)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(793, 24)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'ViewJournalEntryButton
        '
        Me.ViewJournalEntryButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ViewJournalEntryButton.Image = Global.AccDataBindingsWinForms.My.Resources.Resources.lektuvelis_16
        Me.ViewJournalEntryButton.Location = New System.Drawing.Point(197, 0)
        Me.ViewJournalEntryButton.Margin = New System.Windows.Forms.Padding(0)
        Me.ViewJournalEntryButton.Name = "ViewJournalEntryButton"
        Me.ViewJournalEntryButton.Size = New System.Drawing.Size(24, 24)
        Me.ViewJournalEntryButton.TabIndex = 90
        Me.ViewJournalEntryButton.TabStop = False
        Me.ViewJournalEntryButton.UseVisualStyleBackColor = True
        '
        'IDTextBox
        '
        Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceMadeBindingSource, "ID", True))
        Me.IDTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IDTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IDTextBox.Location = New System.Drawing.Point(0, 0)
        Me.IDTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.IDTextBox.Name = "IDTextBox"
        Me.IDTextBox.ReadOnly = True
        Me.IDTextBox.Size = New System.Drawing.Size(177, 20)
        Me.IDTextBox.TabIndex = 17
        Me.IDTextBox.TabStop = False
        Me.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'InsertDateTextBox
        '
        Me.InsertDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceMadeBindingSource, "InsertDate", True))
        Me.InsertDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InsertDateTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsertDateTextBox.Location = New System.Drawing.Point(276, 0)
        Me.InsertDateTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.InsertDateTextBox.Name = "InsertDateTextBox"
        Me.InsertDateTextBox.ReadOnly = True
        Me.InsertDateTextBox.Size = New System.Drawing.Size(207, 20)
        Me.InsertDateTextBox.TabIndex = 58
        Me.InsertDateTextBox.TabStop = False
        Me.InsertDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'UpdateDateTextBox
        '
        Me.UpdateDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceMadeBindingSource, "UpdateDate", True))
        Me.UpdateDateTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UpdateDateTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateDateTextBox.Location = New System.Drawing.Point(563, 0)
        Me.UpdateDateTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.UpdateDateTextBox.Name = "UpdateDateTextBox"
        Me.UpdateDateTextBox.ReadOnly = True
        Me.UpdateDateTextBox.Size = New System.Drawing.Size(207, 20)
        Me.UpdateDateTextBox.TabIndex = 57
        Me.UpdateDateTextBox.TabStop = False
        Me.UpdateDateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.PayerAccGridComboBox, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(92, 123)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(793, 24)
        Me.TableLayoutPanel6.TabIndex = 4
        '
        'PayerAccGridComboBox
        '
        Me.PayerAccGridComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.InvoiceMadeBindingSource, "Payer", True))
        Me.PayerAccGridComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PayerAccGridComboBox.EmptyValueString = ""
        Me.PayerAccGridComboBox.InstantBinding = True
        Me.PayerAccGridComboBox.Location = New System.Drawing.Point(0, 0)
        Me.PayerAccGridComboBox.Margin = New System.Windows.Forms.Padding(0)
        Me.PayerAccGridComboBox.Name = "PayerAccGridComboBox"
        Me.PayerAccGridComboBox.Size = New System.Drawing.Size(773, 21)
        Me.PayerAccGridComboBox.TabIndex = 0
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 5
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.LanguageNameComboBox, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.FullNumberTextBox, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(LanguageNameLabel, 2, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(92, 93)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(793, 24)
        Me.TableLayoutPanel5.TabIndex = 3
        '
        'LanguageNameComboBox
        '
        Me.LanguageNameComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceMadeBindingSource, "LanguageName", True))
        Me.LanguageNameComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LanguageNameComboBox.FormattingEnabled = True
        Me.LanguageNameComboBox.Location = New System.Drawing.Point(418, 0)
        Me.LanguageNameComboBox.Margin = New System.Windows.Forms.Padding(0)
        Me.LanguageNameComboBox.Name = "LanguageNameComboBox"
        Me.LanguageNameComboBox.Size = New System.Drawing.Size(355, 21)
        Me.LanguageNameComboBox.TabIndex = 0
        '
        'FullNumberTextBox
        '
        Me.FullNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceMadeBindingSource, "FullNumber", True))
        Me.FullNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FullNumberTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FullNumberTextBox.Location = New System.Drawing.Point(0, 0)
        Me.FullNumberTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.FullNumberTextBox.Name = "FullNumberTextBox"
        Me.FullNumberTextBox.ReadOnly = True
        Me.FullNumberTextBox.Size = New System.Drawing.Size(355, 20)
        Me.FullNumberTextBox.TabIndex = 15
        Me.FullNumberTextBox.TabStop = False
        Me.FullNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel13)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(891, 309)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "PVM Išimtys"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel13
        '
        Me.TableLayoutPanel13.ColumnCount = 2
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel13.Controls.Add(Label1, 0, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.VatExemptInfoAltLngTextBox, 0, 3)
        Me.TableLayoutPanel13.Controls.Add(Label2, 0, 2)
        Me.TableLayoutPanel13.Controls.Add(Me.VatExemptInfoTextBox, 0, 1)
        Me.TableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel13.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel13.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel13.Name = "TableLayoutPanel13"
        Me.TableLayoutPanel13.RowCount = 4
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel13.Size = New System.Drawing.Size(885, 303)
        Me.TableLayoutPanel13.TabIndex = 0
        '
        'VatExemptInfoAltLngTextBox
        '
        Me.VatExemptInfoAltLngTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceMadeBindingSource, "VatExemptInfoAltLng", True))
        Me.VatExemptInfoAltLngTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VatExemptInfoAltLngTextBox.Location = New System.Drawing.Point(0, 181)
        Me.VatExemptInfoAltLngTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.VatExemptInfoAltLngTextBox.MaxLength = 255
        Me.VatExemptInfoAltLngTextBox.Multiline = True
        Me.VatExemptInfoAltLngTextBox.Name = "VatExemptInfoAltLngTextBox"
        Me.VatExemptInfoAltLngTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.VatExemptInfoAltLngTextBox.Size = New System.Drawing.Size(865, 122)
        Me.VatExemptInfoAltLngTextBox.TabIndex = 1
        '
        'VatExemptInfoTextBox
        '
        Me.VatExemptInfoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceMadeBindingSource, "VatExemptInfo", True))
        Me.VatExemptInfoTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VatExemptInfoTextBox.Location = New System.Drawing.Point(0, 30)
        Me.VatExemptInfoTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.VatExemptInfoTextBox.MaxLength = 255
        Me.VatExemptInfoTextBox.Multiline = True
        Me.VatExemptInfoTextBox.Name = "VatExemptInfoTextBox"
        Me.VatExemptInfoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.VatExemptInfoTextBox.Size = New System.Drawing.Size(865, 121)
        Me.VatExemptInfoTextBox.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.TableLayoutPanel12)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(891, 309)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Papildoma Info"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel12
        '
        Me.TableLayoutPanel12.ColumnCount = 2
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel12.Controls.Add(Label3, 0, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.CustomInfoAltLngTextBox, 0, 3)
        Me.TableLayoutPanel12.Controls.Add(Label4, 0, 2)
        Me.TableLayoutPanel12.Controls.Add(Me.CustomInfoTextBox, 0, 1)
        Me.TableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel12.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel12.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel12.Name = "TableLayoutPanel12"
        Me.TableLayoutPanel12.RowCount = 4
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel12.Size = New System.Drawing.Size(891, 309)
        Me.TableLayoutPanel12.TabIndex = 0
        '
        'CustomInfoAltLngTextBox
        '
        Me.CustomInfoAltLngTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceMadeBindingSource, "CustomInfoAltLng", True))
        Me.CustomInfoAltLngTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomInfoAltLngTextBox.Location = New System.Drawing.Point(0, 184)
        Me.CustomInfoAltLngTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomInfoAltLngTextBox.MaxLength = 255
        Me.CustomInfoAltLngTextBox.Multiline = True
        Me.CustomInfoAltLngTextBox.Name = "CustomInfoAltLngTextBox"
        Me.CustomInfoAltLngTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.CustomInfoAltLngTextBox.Size = New System.Drawing.Size(871, 125)
        Me.CustomInfoAltLngTextBox.TabIndex = 1
        '
        'CustomInfoTextBox
        '
        Me.CustomInfoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceMadeBindingSource, "CustomInfo", True))
        Me.CustomInfoTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CustomInfoTextBox.Location = New System.Drawing.Point(0, 30)
        Me.CustomInfoTextBox.Margin = New System.Windows.Forms.Padding(0)
        Me.CustomInfoTextBox.MaxLength = 255
        Me.CustomInfoTextBox.Multiline = True
        Me.CustomInfoTextBox.Name = "CustomInfoTextBox"
        Me.CustomInfoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.CustomInfoTextBox.Size = New System.Drawing.Size(871, 124)
        Me.CustomInfoTextBox.TabIndex = 0
        '
        'InvoiceItemsSortedBindingSource
        '
        Me.InvoiceItemsSortedBindingSource.AllowNew = True
        Me.InvoiceItemsSortedBindingSource.DataMember = "InvoiceItems"
        Me.InvoiceItemsSortedBindingSource.DataSource = Me.InvoiceMadeBindingSource
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.NewButton)
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 592)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(899, 32)
        Me.Panel2.TabIndex = 2
        '
        'NewButton
        '
        Me.NewButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NewButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewButton.Location = New System.Drawing.Point(798, 6)
        Me.NewButton.Name = "NewButton"
        Me.NewButton.Size = New System.Drawing.Size(89, 23)
        Me.NewButton.TabIndex = 4
        Me.NewButton.Text = "Nauja"
        Me.NewButton.UseVisualStyleBackColor = True
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(695, 6)
        Me.ICancelButton.Name = "ICancelButton"
        Me.ICancelButton.Size = New System.Drawing.Size(89, 23)
        Me.ICancelButton.TabIndex = 3
        Me.ICancelButton.Text = "Atšaukti"
        Me.ICancelButton.UseVisualStyleBackColor = True
        '
        'IOkButton
        '
        Me.IOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IOkButton.Location = New System.Drawing.Point(489, 6)
        Me.IOkButton.Name = "IOkButton"
        Me.IOkButton.Size = New System.Drawing.Size(89, 23)
        Me.IOkButton.TabIndex = 1
        Me.IOkButton.Text = "Ok"
        Me.IOkButton.UseVisualStyleBackColor = True
        '
        'IApplyButton
        '
        Me.IApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IApplyButton.Location = New System.Drawing.Point(593, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 2
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'InvoiceItemsDataListView
        '
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn1)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn2)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn3)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn4)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn5)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn6)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn7)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn8)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn9)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn10)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn33)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn11)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn12)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn13)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn14)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn15)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn16)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn17)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn18)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn19)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn20)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn21)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn22)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn23)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn24)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn25)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn26)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn27)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn28)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn29)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn30)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn31)
        Me.InvoiceItemsDataListView.AllColumns.Add(Me.OlvColumn32)
        Me.InvoiceItemsDataListView.AllowColumnReorder = True
        Me.InvoiceItemsDataListView.AutoGenerateColumns = False
        Me.InvoiceItemsDataListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClickAlways
        Me.InvoiceItemsDataListView.CellEditEnterChangesRows = True
        Me.InvoiceItemsDataListView.CellEditTabChangesRows = True
        Me.InvoiceItemsDataListView.CellEditUseWholeCell = False
        Me.InvoiceItemsDataListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1, Me.OlvColumn3, Me.OlvColumn4, Me.OlvColumn5, Me.OlvColumn7, Me.OlvColumn8, Me.OlvColumn9, Me.OlvColumn33, Me.OlvColumn11, Me.OlvColumn13, Me.OlvColumn15, Me.OlvColumn16, Me.OlvColumn32})
        Me.InvoiceItemsDataListView.Cursor = System.Windows.Forms.Cursors.Default
        Me.InvoiceItemsDataListView.DataSource = Me.InvoiceItemsSortedBindingSource
        Me.InvoiceItemsDataListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InvoiceItemsDataListView.FullRowSelect = True
        Me.InvoiceItemsDataListView.HasCollapsibleGroups = False
        Me.InvoiceItemsDataListView.HeaderWordWrap = True
        Me.InvoiceItemsDataListView.HideSelection = False
        Me.InvoiceItemsDataListView.IncludeColumnHeadersInCopy = True
        Me.InvoiceItemsDataListView.Location = New System.Drawing.Point(0, 335)
        Me.InvoiceItemsDataListView.Name = "InvoiceItemsDataListView"
        Me.InvoiceItemsDataListView.RenderNonEditableCheckboxesAsDisabled = True
        Me.InvoiceItemsDataListView.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu
        Me.InvoiceItemsDataListView.SelectedBackColor = System.Drawing.Color.PaleGreen
        Me.InvoiceItemsDataListView.SelectedForeColor = System.Drawing.Color.Black
        Me.InvoiceItemsDataListView.ShowCommandMenuOnRightClick = True
        Me.InvoiceItemsDataListView.ShowGroups = False
        Me.InvoiceItemsDataListView.ShowImagesOnSubItems = True
        Me.InvoiceItemsDataListView.ShowItemCountOnGroups = True
        Me.InvoiceItemsDataListView.ShowItemToolTips = True
        Me.InvoiceItemsDataListView.Size = New System.Drawing.Size(899, 257)
        Me.InvoiceItemsDataListView.TabIndex = 3
        Me.InvoiceItemsDataListView.UnfocusedSelectedBackColor = System.Drawing.Color.PaleGreen
        Me.InvoiceItemsDataListView.UnfocusedSelectedForeColor = System.Drawing.Color.Black
        Me.InvoiceItemsDataListView.UseCellFormatEvents = True
        Me.InvoiceItemsDataListView.UseCompatibleStateImageBehavior = False
        Me.InvoiceItemsDataListView.UseFilterIndicator = True
        Me.InvoiceItemsDataListView.UseFiltering = True
        Me.InvoiceItemsDataListView.UseHotItem = True
        Me.InvoiceItemsDataListView.UseNotifyPropertyChanged = True
        Me.InvoiceItemsDataListView.View = System.Windows.Forms.View.Details
        '
        'OlvColumn1
        '
        Me.OlvColumn1.AspectName = "NameInvoice"
        Me.OlvColumn1.CellEditUseWholeCell = True
        Me.OlvColumn1.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn1.Text = "Turinys lietuviškai"
        Me.OlvColumn1.ToolTipText = ""
        Me.OlvColumn1.Width = 183
        '
        'OlvColumn2
        '
        Me.OlvColumn2.AspectName = "NameInvoiceAltLng"
        Me.OlvColumn2.CellEditUseWholeCell = True
        Me.OlvColumn2.DisplayIndex = 1
        Me.OlvColumn2.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn2.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn2.IsVisible = False
        Me.OlvColumn2.Text = "Turinys užs. klb."
        Me.OlvColumn2.ToolTipText = ""
        Me.OlvColumn2.Width = 100
        '
        'OlvColumn3
        '
        Me.OlvColumn3.AspectName = "AccountIncome"
        Me.OlvColumn3.CellEditUseWholeCell = True
        Me.OlvColumn3.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn3.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn3.Text = "Pajamų sąsk."
        Me.OlvColumn3.ToolTipText = ""
        Me.OlvColumn3.Width = 79
        '
        'OlvColumn4
        '
        Me.OlvColumn4.AspectName = "AccountVat"
        Me.OlvColumn4.CellEditUseWholeCell = True
        Me.OlvColumn4.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn4.Text = "PVM sąsk."
        Me.OlvColumn4.ToolTipText = ""
        Me.OlvColumn4.Width = 75
        '
        'OlvColumn5
        '
        Me.OlvColumn5.AspectName = "MeasureUnit"
        Me.OlvColumn5.CellEditUseWholeCell = True
        Me.OlvColumn5.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn5.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn5.Text = "Mato Vnt. lietuviškai"
        Me.OlvColumn5.ToolTipText = ""
        Me.OlvColumn5.Width = 64
        '
        'OlvColumn6
        '
        Me.OlvColumn6.AspectName = "MeasureUnitAltLng"
        Me.OlvColumn6.CellEditUseWholeCell = True
        Me.OlvColumn6.DisplayIndex = 5
        Me.OlvColumn6.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn6.IsVisible = False
        Me.OlvColumn6.Text = "Mato Vnt. užs. klb."
        Me.OlvColumn6.ToolTipText = ""
        Me.OlvColumn6.Width = 100
        '
        'OlvColumn7
        '
        Me.OlvColumn7.AspectName = "Ammount"
        Me.OlvColumn7.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn7.CellEditUseWholeCell = True
        Me.OlvColumn7.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn7.Text = "Kiekis"
        Me.OlvColumn7.ToolTipText = ""
        Me.OlvColumn7.Width = 61
        '
        'OlvColumn8
        '
        Me.OlvColumn8.AspectName = "UnitValue"
        Me.OlvColumn8.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn8.CellEditUseWholeCell = True
        Me.OlvColumn8.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn8.Text = "Vnt. Kaina"
        Me.OlvColumn8.ToolTipText = ""
        Me.OlvColumn8.Width = 66
        '
        'OlvColumn9
        '
        Me.OlvColumn9.AspectName = "Sum"
        Me.OlvColumn9.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn9.CellEditUseWholeCell = True
        Me.OlvColumn9.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn9.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn9.IsEditable = False
        Me.OlvColumn9.Text = "Suma"
        Me.OlvColumn9.ToolTipText = ""
        Me.OlvColumn9.Width = 73
        '
        'OlvColumn10
        '
        Me.OlvColumn10.AspectName = "SumCorrection"
        Me.OlvColumn10.CellEditUseWholeCell = True
        Me.OlvColumn10.DisplayIndex = 9
        Me.OlvColumn10.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn10.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn10.IsVisible = False
        Me.OlvColumn10.Text = "Sumos kor."
        Me.OlvColumn10.ToolTipText = ""
        Me.OlvColumn10.Width = 100
        '
        'OlvColumn33
        '
        Me.OlvColumn33.AspectName = "DeclarationSchema"
        Me.OlvColumn33.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.OlvColumn33.Text = "PVM Deklaravimo Schema"
        '
        'OlvColumn11
        '
        Me.OlvColumn11.AspectName = "VatRate"
        Me.OlvColumn11.CellEditUseWholeCell = True
        Me.OlvColumn11.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn11.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn11.Text = "PVM tarifas"
        Me.OlvColumn11.ToolTipText = ""
        Me.OlvColumn11.Width = 59
        '
        'OlvColumn12
        '
        Me.OlvColumn12.AspectName = "VatIsVirtual"
        Me.OlvColumn12.CellEditUseWholeCell = True
        Me.OlvColumn12.CheckBoxes = True
        Me.OlvColumn12.DisplayIndex = 11
        Me.OlvColumn12.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn12.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn12.IsVisible = False
        Me.OlvColumn12.Text = "Netiesioginis PVM"
        Me.OlvColumn12.ToolTipText = ""
        Me.OlvColumn12.Width = 100
        '
        'OlvColumn13
        '
        Me.OlvColumn13.AspectName = "SumVat"
        Me.OlvColumn13.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn13.CellEditUseWholeCell = True
        Me.OlvColumn13.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn13.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn13.IsEditable = False
        Me.OlvColumn13.Text = "Suma PVM"
        Me.OlvColumn13.ToolTipText = ""
        Me.OlvColumn13.Width = 70
        '
        'OlvColumn14
        '
        Me.OlvColumn14.AspectName = "SumVatCorrection"
        Me.OlvColumn14.CellEditUseWholeCell = True
        Me.OlvColumn14.DisplayIndex = 13
        Me.OlvColumn14.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn14.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn14.IsVisible = False
        Me.OlvColumn14.Text = "Sumos PVM kor."
        Me.OlvColumn14.ToolTipText = ""
        Me.OlvColumn14.Width = 100
        '
        'OlvColumn15
        '
        Me.OlvColumn15.AspectName = "IncludeVatInObject"
        Me.OlvColumn15.CellEditUseWholeCell = True
        Me.OlvColumn15.CheckBoxes = True
        Me.OlvColumn15.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn15.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn15.Text = "Įtraukti PVM į Objektą"
        Me.OlvColumn15.ToolTipText = ""
        Me.OlvColumn15.Width = 63
        '
        'OlvColumn16
        '
        Me.OlvColumn16.AspectName = "SumTotal"
        Me.OlvColumn16.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn16.CellEditUseWholeCell = True
        Me.OlvColumn16.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn16.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn16.IsEditable = False
        Me.OlvColumn16.Text = "Suma Viso"
        Me.OlvColumn16.ToolTipText = ""
        Me.OlvColumn16.Width = 84
        '
        'OlvColumn17
        '
        Me.OlvColumn17.AspectName = "UnitValueLTL"
        Me.OlvColumn17.AspectToStringFormat = "{0:##,0.0000}"
        Me.OlvColumn17.CellEditUseWholeCell = True
        Me.OlvColumn17.DisplayIndex = 16
        Me.OlvColumn17.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn17.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn17.IsEditable = False
        Me.OlvColumn17.IsVisible = False
        Me.OlvColumn17.Text = "Vnt. Kaina LTL"
        Me.OlvColumn17.ToolTipText = ""
        Me.OlvColumn17.Width = 100
        '
        'OlvColumn18
        '
        Me.OlvColumn18.AspectName = "UnitValueLTLCorrection"
        Me.OlvColumn18.CellEditUseWholeCell = True
        Me.OlvColumn18.DisplayIndex = 17
        Me.OlvColumn18.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn18.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn18.IsVisible = False
        Me.OlvColumn18.Text = "Vnt. Kaina LTL kor."
        Me.OlvColumn18.ToolTipText = ""
        Me.OlvColumn18.Width = 100
        '
        'OlvColumn19
        '
        Me.OlvColumn19.AspectName = "SumLTL"
        Me.OlvColumn19.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn19.CellEditUseWholeCell = True
        Me.OlvColumn19.DisplayIndex = 18
        Me.OlvColumn19.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn19.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn19.IsEditable = False
        Me.OlvColumn19.IsVisible = False
        Me.OlvColumn19.Text = "Suma LTL"
        Me.OlvColumn19.ToolTipText = ""
        Me.OlvColumn19.Width = 100
        '
        'OlvColumn20
        '
        Me.OlvColumn20.AspectName = "SumCorrectionLTL"
        Me.OlvColumn20.CellEditUseWholeCell = True
        Me.OlvColumn20.DisplayIndex = 19
        Me.OlvColumn20.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn20.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn20.IsVisible = False
        Me.OlvColumn20.Text = "Sumos LTL kor."
        Me.OlvColumn20.ToolTipText = ""
        Me.OlvColumn20.Width = 100
        '
        'OlvColumn21
        '
        Me.OlvColumn21.AspectName = "SumVatLTL"
        Me.OlvColumn21.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn21.CellEditUseWholeCell = True
        Me.OlvColumn21.DisplayIndex = 20
        Me.OlvColumn21.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn21.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn21.IsEditable = False
        Me.OlvColumn21.IsVisible = False
        Me.OlvColumn21.Text = "Suma PVM LTL"
        Me.OlvColumn21.ToolTipText = ""
        Me.OlvColumn21.Width = 100
        '
        'OlvColumn22
        '
        Me.OlvColumn22.AspectName = "SumVatCorrectionLTL"
        Me.OlvColumn22.CellEditUseWholeCell = True
        Me.OlvColumn22.DisplayIndex = 21
        Me.OlvColumn22.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn22.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn22.IsVisible = False
        Me.OlvColumn22.Text = "Sumos PVM LTL kor."
        Me.OlvColumn22.ToolTipText = ""
        Me.OlvColumn22.Width = 100
        '
        'OlvColumn23
        '
        Me.OlvColumn23.AspectName = "SumTotalLTL"
        Me.OlvColumn23.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn23.CellEditUseWholeCell = True
        Me.OlvColumn23.DisplayIndex = 22
        Me.OlvColumn23.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn23.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn23.IsEditable = False
        Me.OlvColumn23.IsVisible = False
        Me.OlvColumn23.Text = "Suma Viso LTL"
        Me.OlvColumn23.ToolTipText = ""
        Me.OlvColumn23.Width = 100
        '
        'OlvColumn24
        '
        Me.OlvColumn24.AspectName = "AccountDiscount"
        Me.OlvColumn24.CellEditUseWholeCell = True
        Me.OlvColumn24.DisplayIndex = 23
        Me.OlvColumn24.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn24.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn24.IsVisible = False
        Me.OlvColumn24.Text = "Nuolaidos sąsk."
        Me.OlvColumn24.ToolTipText = ""
        Me.OlvColumn24.Width = 100
        '
        'OlvColumn25
        '
        Me.OlvColumn25.AspectName = "Discount"
        Me.OlvColumn25.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn25.CellEditUseWholeCell = True
        Me.OlvColumn25.DisplayIndex = 24
        Me.OlvColumn25.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn25.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn25.IsVisible = False
        Me.OlvColumn25.Text = "Nuolaida"
        Me.OlvColumn25.ToolTipText = ""
        Me.OlvColumn25.Width = 100
        '
        'OlvColumn26
        '
        Me.OlvColumn26.AspectName = "DiscountVat"
        Me.OlvColumn26.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn26.CellEditUseWholeCell = True
        Me.OlvColumn26.DisplayIndex = 25
        Me.OlvColumn26.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn26.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn26.IsEditable = False
        Me.OlvColumn26.IsVisible = False
        Me.OlvColumn26.Text = "Nuolaidos PVM"
        Me.OlvColumn26.ToolTipText = ""
        Me.OlvColumn26.Width = 100
        '
        'OlvColumn27
        '
        Me.OlvColumn27.AspectName = "DiscountVatCorrection"
        Me.OlvColumn27.CellEditUseWholeCell = True
        Me.OlvColumn27.DisplayIndex = 26
        Me.OlvColumn27.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn27.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn27.IsVisible = False
        Me.OlvColumn27.Text = "Nuolaidos PVM kor."
        Me.OlvColumn27.ToolTipText = ""
        Me.OlvColumn27.Width = 100
        '
        'OlvColumn28
        '
        Me.OlvColumn28.AspectName = "DiscountLTL"
        Me.OlvColumn28.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn28.CellEditUseWholeCell = True
        Me.OlvColumn28.DisplayIndex = 27
        Me.OlvColumn28.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn28.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn28.IsEditable = False
        Me.OlvColumn28.IsVisible = False
        Me.OlvColumn28.Text = "Nuolaida LTL"
        Me.OlvColumn28.ToolTipText = ""
        Me.OlvColumn28.Width = 100
        '
        'OlvColumn29
        '
        Me.OlvColumn29.AspectName = "DiscountCorrectionLTL"
        Me.OlvColumn29.CellEditUseWholeCell = True
        Me.OlvColumn29.DisplayIndex = 28
        Me.OlvColumn29.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn29.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn29.IsVisible = False
        Me.OlvColumn29.Text = "Nuolaidos LTL kor."
        Me.OlvColumn29.ToolTipText = ""
        Me.OlvColumn29.Width = 100
        '
        'OlvColumn30
        '
        Me.OlvColumn30.AspectName = "DiscountVatLTL"
        Me.OlvColumn30.AspectToStringFormat = "{0:##,0.00}"
        Me.OlvColumn30.CellEditUseWholeCell = True
        Me.OlvColumn30.DisplayIndex = 29
        Me.OlvColumn30.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn30.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn30.IsEditable = False
        Me.OlvColumn30.IsVisible = False
        Me.OlvColumn30.Text = "Nuolaidos PVM LTL"
        Me.OlvColumn30.ToolTipText = ""
        Me.OlvColumn30.Width = 100
        '
        'OlvColumn31
        '
        Me.OlvColumn31.AspectName = "DiscountVatLTLCorrection"
        Me.OlvColumn31.CellEditUseWholeCell = True
        Me.OlvColumn31.DisplayIndex = 30
        Me.OlvColumn31.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn31.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn31.IsVisible = False
        Me.OlvColumn31.Text = "Nuolaidos PVM LTL kor."
        Me.OlvColumn31.ToolTipText = ""
        Me.OlvColumn31.Width = 100
        '
        'OlvColumn32
        '
        Me.OlvColumn32.AspectName = "AttachedObject"
        Me.OlvColumn32.CellEditUseWholeCell = True
        Me.OlvColumn32.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OlvColumn32.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.OlvColumn32.IsEditable = False
        Me.OlvColumn32.Text = "Susietas objektas"
        Me.OlvColumn32.ToolTipText = ""
        Me.OlvColumn32.Width = 100
        '
        'ProgressFiller2
        '
        Me.ProgressFiller2.Location = New System.Drawing.Point(308, 347)
        Me.ProgressFiller2.Name = "ProgressFiller2"
        Me.ProgressFiller2.Size = New System.Drawing.Size(191, 101)
        Me.ProgressFiller2.TabIndex = 5
        Me.ProgressFiller2.Visible = False
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(147, 351)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(139, 98)
        Me.ProgressFiller1.TabIndex = 4
        Me.ProgressFiller1.Visible = False
        '
        'ErrorWarnInfoProvider1
        '
        Me.ErrorWarnInfoProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleInformation = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleWarning = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.ContainerControl = Me
        Me.ErrorWarnInfoProvider1.DataSource = Me.InvoiceMadeBindingSource
        '
        'F_InvoiceMade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 624)
        Me.Controls.Add(Me.InvoiceItemsDataListView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ProgressFiller2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_InvoiceMade"
        Me.ShowInTaskbar = False
        Me.Text = "Išrašyta sąskaita faktūra"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel14.ResumeLayout(False)
        CType(Me.InvoiceMadeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel10.PerformLayout()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel13.ResumeLayout(False)
        Me.TableLayoutPanel13.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TableLayoutPanel12.ResumeLayout(False)
        Me.TableLayoutPanel12.PerformLayout()
        CType(Me.InvoiceItemsSortedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.InvoiceItemsDataListView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents InvoiceMadeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AccountPayerAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents CommentsInternalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ContentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrencyCodeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CurrencyRateAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents FullNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LanguageNameComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents NumberAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents PayerAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents SerialComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents SumAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents SumDiscountAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents SumDiscountVatAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents SumTotalAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents SumVatAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents SumTotalLTLAccTextBox As AccControlsWinForms.AccTextBox
    Friend WithEvents TableLayoutPanel13 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents VatExemptInfoAltLngTextBox As System.Windows.Forms.TextBox
    Friend WithEvents VatExemptInfoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel12 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents CustomInfoAltLngTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CustomInfoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InvoiceItemsSortedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents GetCurrencyRatesButton As System.Windows.Forms.Button
    Friend WithEvents UpdateDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InsertDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TypeHumanReadableComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RefreshNumberButton As System.Windows.Forms.Button
    Friend WithEvents CopyInvoiceButton As System.Windows.Forms.Button
    Friend WithEvents PasteInvoiceButton As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel14 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents AddAttachedObjectButton As System.Windows.Forms.Button
    Friend WithEvents NewButton As System.Windows.Forms.Button
    Friend WithEvents ViewJournalEntryButton As System.Windows.Forms.Button
    Friend WithEvents InvoiceItemsDataListView As BrightIdeasSoftware.DataListView
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
    Friend WithEvents ProgressFiller2 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents NewAdapterTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ErrorWarnInfoProvider1 As AccControlsWinForms.ErrorWarnInfoProvider
    Friend WithEvents OlvColumn33 As BrightIdeasSoftware.OLVColumn
    Friend WithEvents DateAccDatePicker As AccControlsWinForms.AccDatePicker
End Class
