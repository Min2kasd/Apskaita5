﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Friend Class F_CompanyRegionalData
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
        Dim AddressLabel As System.Windows.Forms.Label
        Dim BankLabel As System.Windows.Forms.Label
        Dim BankAccountLabel As System.Windows.Forms.Label
        Dim BankAddressLabel As System.Windows.Forms.Label
        Dim BankSWIFTLabel As System.Windows.Forms.Label
        Dim ContactsLabel As System.Windows.Forms.Label
        Dim DiscountNameLabel As System.Windows.Forms.Label
        Dim HeadTitleLabel As System.Windows.Forms.Label
        Dim InvoiceInfoLineLabel As System.Windows.Forms.Label
        Dim LanguageNameLabel As System.Windows.Forms.Label
        Dim LogoImageLabel As System.Windows.Forms.Label
        Dim MeasureUnitInvoiceMadeLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_CompanyRegionalData))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ICancelButton = New System.Windows.Forms.Button
        Me.IOkButton = New System.Windows.Forms.Button
        Me.IApplyButton = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.ClearLogoButton = New System.Windows.Forms.Button
        Me.OpenImageButton = New System.Windows.Forms.Button
        Me.AddressTextBox = New System.Windows.Forms.TextBox
        Me.CompanyRegionalDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BankTextBox = New System.Windows.Forms.TextBox
        Me.BankAccountTextBox = New System.Windows.Forms.TextBox
        Me.BankAddressTextBox = New System.Windows.Forms.TextBox
        Me.BankSWIFTTextBox = New System.Windows.Forms.TextBox
        Me.ContactsTextBox = New System.Windows.Forms.TextBox
        Me.DiscountNameTextBox = New System.Windows.Forms.TextBox
        Me.HeadTitleTextBox = New System.Windows.Forms.TextBox
        Me.InvoiceInfoLineTextBox = New System.Windows.Forms.TextBox
        Me.LanguageNameComboBox = New System.Windows.Forms.ComboBox
        Me.LogoImagePictureBox = New System.Windows.Forms.PictureBox
        Me.MeasureUnitInvoiceMadeTextBox = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.InvoiceFormReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.OpenInvoiceFormButton = New System.Windows.Forms.Button
        Me.ClearInvoiceFormButton = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.OpenProformaInvoiceFormButton = New System.Windows.Forms.Button
        Me.ClearProformaInvoiceFormButton = New System.Windows.Forms.Button
        Me.ProformaInvoiceFormReportViewer = New Microsoft.Reporting.WinForms.ReportViewer
        Me.ProgressFiller1 = New AccControlsWinForms.ProgressFiller
        Me.ErrorWarnInfoProvider1 = New AccControlsWinForms.ErrorWarnInfoProvider(Me.components)
        AddressLabel = New System.Windows.Forms.Label
        BankLabel = New System.Windows.Forms.Label
        BankAccountLabel = New System.Windows.Forms.Label
        BankAddressLabel = New System.Windows.Forms.Label
        BankSWIFTLabel = New System.Windows.Forms.Label
        ContactsLabel = New System.Windows.Forms.Label
        DiscountNameLabel = New System.Windows.Forms.Label
        HeadTitleLabel = New System.Windows.Forms.Label
        InvoiceInfoLineLabel = New System.Windows.Forms.Label
        LanguageNameLabel = New System.Windows.Forms.Label
        LogoImageLabel = New System.Windows.Forms.Label
        MeasureUnitInvoiceMadeLabel = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.CompanyRegionalDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoImagePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AddressLabel
        '
        AddressLabel.AutoSize = True
        AddressLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AddressLabel.Location = New System.Drawing.Point(92, 36)
        AddressLabel.Name = "AddressLabel"
        AddressLabel.Size = New System.Drawing.Size(56, 13)
        AddressLabel.TabIndex = 0
        AddressLabel.Text = "Adresas:"
        '
        'BankLabel
        '
        BankLabel.AutoSize = True
        BankLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BankLabel.Location = New System.Drawing.Point(95, 88)
        BankLabel.Name = "BankLabel"
        BankLabel.Size = New System.Drawing.Size(53, 13)
        BankLabel.TabIndex = 2
        BankLabel.Text = "Bankas:"
        '
        'BankAccountLabel
        '
        BankAccountLabel.AutoSize = True
        BankAccountLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BankAccountLabel.Location = New System.Drawing.Point(50, 62)
        BankAccountLabel.Name = "BankAccountLabel"
        BankAccountLabel.Size = New System.Drawing.Size(98, 13)
        BankAccountLabel.TabIndex = 4
        BankAccountLabel.Text = "Banko sąskaita:"
        '
        'BankAddressLabel
        '
        BankAddressLabel.AutoSize = True
        BankAddressLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BankAddressLabel.Location = New System.Drawing.Point(53, 114)
        BankAddressLabel.Name = "BankAddressLabel"
        BankAddressLabel.Size = New System.Drawing.Size(95, 13)
        BankAddressLabel.TabIndex = 6
        BankAddressLabel.Text = "Banko adresas:"
        '
        'BankSWIFTLabel
        '
        BankSWIFTLabel.AutoSize = True
        BankSWIFTLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        BankSWIFTLabel.Location = New System.Drawing.Point(538, 88)
        BankSWIFTLabel.Name = "BankSWIFTLabel"
        BankSWIFTLabel.Size = New System.Drawing.Size(90, 13)
        BankSWIFTLabel.TabIndex = 8
        BankSWIFTLabel.Text = "Banko SWIFT:"
        '
        'ContactsLabel
        '
        ContactsLabel.AutoSize = True
        ContactsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContactsLabel.Location = New System.Drawing.Point(83, 140)
        ContactsLabel.Name = "ContactsLabel"
        ContactsLabel.Size = New System.Drawing.Size(65, 13)
        ContactsLabel.TabIndex = 10
        ContactsLabel.Text = "Kontaktai:"
        '
        'DiscountNameLabel
        '
        DiscountNameLabel.AutoSize = True
        DiscountNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DiscountNameLabel.Location = New System.Drawing.Point(7, 192)
        DiscountNameLabel.Name = "DiscountNameLabel"
        DiscountNameLabel.Size = New System.Drawing.Size(141, 13)
        DiscountNameLabel.TabIndex = 12
        DiscountNameLabel.Text = "Nuolaidos pavadinimas:"
        '
        'HeadTitleLabel
        '
        HeadTitleLabel.AutoSize = True
        HeadTitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        HeadTitleLabel.Location = New System.Drawing.Point(42, 218)
        HeadTitleLabel.Name = "HeadTitleLabel"
        HeadTitleLabel.Size = New System.Drawing.Size(106, 13)
        HeadTitleLabel.TabIndex = 14
        HeadTitleLabel.Text = "Vadovo pareigos:"
        '
        'InvoiceInfoLineLabel
        '
        InvoiceInfoLineLabel.AutoSize = True
        InvoiceInfoLineLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        InvoiceInfoLineLabel.Location = New System.Drawing.Point(36, 166)
        InvoiceInfoLineLabel.Name = "InvoiceInfoLineLabel"
        InvoiceInfoLineLabel.Size = New System.Drawing.Size(112, 13)
        InvoiceInfoLineLabel.TabIndex = 18
        InvoiceInfoLineLabel.Text = "Sąskaitos info eil.:"
        '
        'LanguageNameLabel
        '
        LanguageNameLabel.AutoSize = True
        LanguageNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LanguageNameLabel.Location = New System.Drawing.Point(105, 9)
        LanguageNameLabel.Name = "LanguageNameLabel"
        LanguageNameLabel.Size = New System.Drawing.Size(43, 13)
        LanguageNameLabel.TabIndex = 24
        LanguageNameLabel.Text = "Kalba:"
        '
        'LogoImageLabel
        '
        LogoImageLabel.AutoSize = True
        LogoImageLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        LogoImageLabel.Location = New System.Drawing.Point(109, 241)
        LogoImageLabel.Name = "LogoImageLabel"
        LogoImageLabel.Size = New System.Drawing.Size(39, 13)
        LogoImageLabel.TabIndex = 26
        LogoImageLabel.Text = "Logo:"
        '
        'MeasureUnitInvoiceMadeLabel
        '
        MeasureUnitInvoiceMadeLabel.AutoSize = True
        MeasureUnitInvoiceMadeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        MeasureUnitInvoiceMadeLabel.Location = New System.Drawing.Point(514, 192)
        MeasureUnitInvoiceMadeLabel.Name = "MeasureUnitInvoiceMadeLabel"
        MeasureUnitInvoiceMadeLabel.Size = New System.Drawing.Size(133, 13)
        MeasureUnitInvoiceMadeLabel.TabIndex = 28
        MeasureUnitInvoiceMadeLabel.Text = "Mato vnt. išraš. sąsk.:"
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.Controls.Add(Me.ICancelButton)
        Me.Panel2.Controls.Add(Me.IOkButton)
        Me.Panel2.Controls.Add(Me.IApplyButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 449)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(809, 32)
        Me.Panel2.TabIndex = 1
        '
        'ICancelButton
        '
        Me.ICancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ICancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ICancelButton.Location = New System.Drawing.Point(708, 6)
        Me.ICancelButton.Name = "ICancelButton"
        Me.ICancelButton.Size = New System.Drawing.Size(89, 23)
        Me.ICancelButton.TabIndex = 2
        Me.ICancelButton.Text = "Atšaukti"
        Me.ICancelButton.UseVisualStyleBackColor = True
        '
        'IOkButton
        '
        Me.IOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IOkButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IOkButton.Location = New System.Drawing.Point(502, 6)
        Me.IOkButton.Name = "IOkButton"
        Me.IOkButton.Size = New System.Drawing.Size(89, 23)
        Me.IOkButton.TabIndex = 0
        Me.IOkButton.Text = "Ok"
        Me.IOkButton.UseVisualStyleBackColor = True
        '
        'IApplyButton
        '
        Me.IApplyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IApplyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IApplyButton.Location = New System.Drawing.Point(606, 6)
        Me.IApplyButton.Name = "IApplyButton"
        Me.IApplyButton.Size = New System.Drawing.Size(89, 23)
        Me.IApplyButton.TabIndex = 1
        Me.IApplyButton.Text = "Išsaugoti"
        Me.IApplyButton.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(809, 449)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.Controls.Add(Me.ClearLogoButton)
        Me.TabPage1.Controls.Add(Me.OpenImageButton)
        Me.TabPage1.Controls.Add(AddressLabel)
        Me.TabPage1.Controls.Add(Me.AddressTextBox)
        Me.TabPage1.Controls.Add(BankLabel)
        Me.TabPage1.Controls.Add(Me.BankTextBox)
        Me.TabPage1.Controls.Add(BankAccountLabel)
        Me.TabPage1.Controls.Add(Me.BankAccountTextBox)
        Me.TabPage1.Controls.Add(BankAddressLabel)
        Me.TabPage1.Controls.Add(Me.BankAddressTextBox)
        Me.TabPage1.Controls.Add(BankSWIFTLabel)
        Me.TabPage1.Controls.Add(Me.BankSWIFTTextBox)
        Me.TabPage1.Controls.Add(ContactsLabel)
        Me.TabPage1.Controls.Add(Me.ContactsTextBox)
        Me.TabPage1.Controls.Add(DiscountNameLabel)
        Me.TabPage1.Controls.Add(Me.DiscountNameTextBox)
        Me.TabPage1.Controls.Add(HeadTitleLabel)
        Me.TabPage1.Controls.Add(Me.HeadTitleTextBox)
        Me.TabPage1.Controls.Add(InvoiceInfoLineLabel)
        Me.TabPage1.Controls.Add(Me.InvoiceInfoLineTextBox)
        Me.TabPage1.Controls.Add(LanguageNameLabel)
        Me.TabPage1.Controls.Add(Me.LanguageNameComboBox)
        Me.TabPage1.Controls.Add(LogoImageLabel)
        Me.TabPage1.Controls.Add(Me.LogoImagePictureBox)
        Me.TabPage1.Controls.Add(MeasureUnitInvoiceMadeLabel)
        Me.TabPage1.Controls.Add(Me.MeasureUnitInvoiceMadeTextBox)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(801, 423)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Bendri duomenys"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ClearLogoButton
        '
        Me.ClearLogoButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearLogoButton.Location = New System.Drawing.Point(18, 257)
        Me.ClearLogoButton.Name = "ClearLogoButton"
        Me.ClearLogoButton.Size = New System.Drawing.Size(92, 26)
        Me.ClearLogoButton.TabIndex = 11
        Me.ClearLogoButton.Text = "Be logotipo"
        Me.ClearLogoButton.UseVisualStyleBackColor = True
        '
        'OpenImageButton
        '
        Me.OpenImageButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenImageButton.Location = New System.Drawing.Point(116, 257)
        Me.OpenImageButton.Name = "OpenImageButton"
        Me.OpenImageButton.Size = New System.Drawing.Size(32, 26)
        Me.OpenImageButton.TabIndex = 12
        Me.OpenImageButton.Text = "..."
        Me.OpenImageButton.UseVisualStyleBackColor = True
        '
        'AddressTextBox
        '
        Me.AddressTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyRegionalDataBindingSource, "Address", True))
        Me.AddressTextBox.Location = New System.Drawing.Point(151, 33)
        Me.AddressTextBox.MaxLength = 255
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.Size = New System.Drawing.Size(620, 20)
        Me.AddressTextBox.TabIndex = 1
        '
        'CompanyRegionalDataBindingSource
        '
        Me.CompanyRegionalDataBindingSource.DataSource = GetType(ApskaitaObjects.General.CompanyRegionalData)
        '
        'BankTextBox
        '
        Me.BankTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyRegionalDataBindingSource, "Bank", True))
        Me.BankTextBox.Location = New System.Drawing.Point(151, 85)
        Me.BankTextBox.MaxLength = 255
        Me.BankTextBox.Name = "BankTextBox"
        Me.BankTextBox.Size = New System.Drawing.Size(377, 20)
        Me.BankTextBox.TabIndex = 3
        '
        'BankAccountTextBox
        '
        Me.BankAccountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyRegionalDataBindingSource, "BankAccount", True))
        Me.BankAccountTextBox.Location = New System.Drawing.Point(151, 59)
        Me.BankAccountTextBox.MaxLength = 255
        Me.BankAccountTextBox.Name = "BankAccountTextBox"
        Me.BankAccountTextBox.Size = New System.Drawing.Size(620, 20)
        Me.BankAccountTextBox.TabIndex = 2
        '
        'BankAddressTextBox
        '
        Me.BankAddressTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyRegionalDataBindingSource, "BankAddress", True))
        Me.BankAddressTextBox.Location = New System.Drawing.Point(151, 111)
        Me.BankAddressTextBox.MaxLength = 255
        Me.BankAddressTextBox.Name = "BankAddressTextBox"
        Me.BankAddressTextBox.Size = New System.Drawing.Size(620, 20)
        Me.BankAddressTextBox.TabIndex = 5
        '
        'BankSWIFTTextBox
        '
        Me.BankSWIFTTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyRegionalDataBindingSource, "BankSWIFT", True))
        Me.BankSWIFTTextBox.Location = New System.Drawing.Point(631, 85)
        Me.BankSWIFTTextBox.MaxLength = 100
        Me.BankSWIFTTextBox.Name = "BankSWIFTTextBox"
        Me.BankSWIFTTextBox.Size = New System.Drawing.Size(140, 20)
        Me.BankSWIFTTextBox.TabIndex = 4
        '
        'ContactsTextBox
        '
        Me.ContactsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyRegionalDataBindingSource, "Contacts", True))
        Me.ContactsTextBox.Location = New System.Drawing.Point(151, 137)
        Me.ContactsTextBox.MaxLength = 255
        Me.ContactsTextBox.Name = "ContactsTextBox"
        Me.ContactsTextBox.Size = New System.Drawing.Size(620, 20)
        Me.ContactsTextBox.TabIndex = 6
        '
        'DiscountNameTextBox
        '
        Me.DiscountNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyRegionalDataBindingSource, "DiscountName", True))
        Me.DiscountNameTextBox.Location = New System.Drawing.Point(151, 189)
        Me.DiscountNameTextBox.MaxLength = 255
        Me.DiscountNameTextBox.Name = "DiscountNameTextBox"
        Me.DiscountNameTextBox.Size = New System.Drawing.Size(340, 20)
        Me.DiscountNameTextBox.TabIndex = 8
        '
        'HeadTitleTextBox
        '
        Me.HeadTitleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyRegionalDataBindingSource, "HeadTitle", True))
        Me.HeadTitleTextBox.Location = New System.Drawing.Point(151, 215)
        Me.HeadTitleTextBox.MaxLength = 100
        Me.HeadTitleTextBox.Name = "HeadTitleTextBox"
        Me.HeadTitleTextBox.Size = New System.Drawing.Size(620, 20)
        Me.HeadTitleTextBox.TabIndex = 10
        '
        'InvoiceInfoLineTextBox
        '
        Me.InvoiceInfoLineTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyRegionalDataBindingSource, "InvoiceInfoLine", True))
        Me.InvoiceInfoLineTextBox.Location = New System.Drawing.Point(151, 163)
        Me.InvoiceInfoLineTextBox.MaxLength = 255
        Me.InvoiceInfoLineTextBox.Name = "InvoiceInfoLineTextBox"
        Me.InvoiceInfoLineTextBox.Size = New System.Drawing.Size(620, 20)
        Me.InvoiceInfoLineTextBox.TabIndex = 7
        '
        'LanguageNameComboBox
        '
        Me.LanguageNameComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyRegionalDataBindingSource, "LanguageName", True))
        Me.LanguageNameComboBox.FormattingEnabled = True
        Me.LanguageNameComboBox.Location = New System.Drawing.Point(151, 6)
        Me.LanguageNameComboBox.Name = "LanguageNameComboBox"
        Me.LanguageNameComboBox.Size = New System.Drawing.Size(620, 21)
        Me.LanguageNameComboBox.TabIndex = 0
        '
        'LogoImagePictureBox
        '
        Me.LogoImagePictureBox.BackColor = System.Drawing.Color.White
        Me.LogoImagePictureBox.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.CompanyRegionalDataBindingSource, "LogoImage", True))
        Me.LogoImagePictureBox.Location = New System.Drawing.Point(151, 241)
        Me.LogoImagePictureBox.MaximumSize = New System.Drawing.Size(620, 90)
        Me.LogoImagePictureBox.Name = "LogoImagePictureBox"
        Me.LogoImagePictureBox.Size = New System.Drawing.Size(620, 90)
        Me.LogoImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.LogoImagePictureBox.TabIndex = 27
        Me.LogoImagePictureBox.TabStop = False
        '
        'MeasureUnitInvoiceMadeTextBox
        '
        Me.MeasureUnitInvoiceMadeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CompanyRegionalDataBindingSource, "MeasureUnitInvoiceMade", True))
        Me.MeasureUnitInvoiceMadeTextBox.Location = New System.Drawing.Point(650, 189)
        Me.MeasureUnitInvoiceMadeTextBox.MaxLength = 100
        Me.MeasureUnitInvoiceMadeTextBox.Name = "MeasureUnitInvoiceMadeTextBox"
        Me.MeasureUnitInvoiceMadeTextBox.Size = New System.Drawing.Size(121, 20)
        Me.MeasureUnitInvoiceMadeTextBox.TabIndex = 9
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.InvoiceFormReportViewer)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(801, 423)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Sąskaitos forma"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'InvoiceFormReportViewer
        '
        Me.InvoiceFormReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InvoiceFormReportViewer.Location = New System.Drawing.Point(3, 36)
        Me.InvoiceFormReportViewer.Name = "InvoiceFormReportViewer"
        Me.InvoiceFormReportViewer.Size = New System.Drawing.Size(795, 384)
        Me.InvoiceFormReportViewer.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.OpenInvoiceFormButton)
        Me.Panel1.Controls.Add(Me.ClearInvoiceFormButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(795, 33)
        Me.Panel1.TabIndex = 0
        '
        'OpenInvoiceFormButton
        '
        Me.OpenInvoiceFormButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenInvoiceFormButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenInvoiceFormButton.Location = New System.Drawing.Point(664, 7)
        Me.OpenInvoiceFormButton.Name = "OpenInvoiceFormButton"
        Me.OpenInvoiceFormButton.Size = New System.Drawing.Size(33, 23)
        Me.OpenInvoiceFormButton.TabIndex = 15
        Me.OpenInvoiceFormButton.Text = "..."
        Me.OpenInvoiceFormButton.UseVisualStyleBackColor = True
        '
        'ClearInvoiceFormButton
        '
        Me.ClearInvoiceFormButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClearInvoiceFormButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearInvoiceFormButton.Location = New System.Drawing.Point(703, 7)
        Me.ClearInvoiceFormButton.Name = "ClearInvoiceFormButton"
        Me.ClearInvoiceFormButton.Size = New System.Drawing.Size(89, 23)
        Me.ClearInvoiceFormButton.TabIndex = 14
        Me.ClearInvoiceFormButton.Text = "Išvalyti"
        Me.ClearInvoiceFormButton.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel3)
        Me.TabPage3.Controls.Add(Me.ProformaInvoiceFormReportViewer)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(801, 423)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Išankstinės sąskaitos forma"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.OpenProformaInvoiceFormButton)
        Me.Panel3.Controls.Add(Me.ClearProformaInvoiceFormButton)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(795, 30)
        Me.Panel3.TabIndex = 0
        '
        'OpenProformaInvoiceFormButton
        '
        Me.OpenProformaInvoiceFormButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenProformaInvoiceFormButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenProformaInvoiceFormButton.Location = New System.Drawing.Point(664, 3)
        Me.OpenProformaInvoiceFormButton.Name = "OpenProformaInvoiceFormButton"
        Me.OpenProformaInvoiceFormButton.Size = New System.Drawing.Size(33, 23)
        Me.OpenProformaInvoiceFormButton.TabIndex = 17
        Me.OpenProformaInvoiceFormButton.Text = "..."
        Me.OpenProformaInvoiceFormButton.UseVisualStyleBackColor = True
        '
        'ClearProformaInvoiceFormButton
        '
        Me.ClearProformaInvoiceFormButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClearProformaInvoiceFormButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearProformaInvoiceFormButton.Location = New System.Drawing.Point(703, 3)
        Me.ClearProformaInvoiceFormButton.Name = "ClearProformaInvoiceFormButton"
        Me.ClearProformaInvoiceFormButton.Size = New System.Drawing.Size(89, 23)
        Me.ClearProformaInvoiceFormButton.TabIndex = 16
        Me.ClearProformaInvoiceFormButton.Text = "Išvalyti"
        Me.ClearProformaInvoiceFormButton.UseVisualStyleBackColor = True
        '
        'ProformaInvoiceFormReportViewer
        '
        Me.ProformaInvoiceFormReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProformaInvoiceFormReportViewer.Location = New System.Drawing.Point(3, 3)
        Me.ProformaInvoiceFormReportViewer.Name = "ProformaInvoiceFormReportViewer"
        Me.ProformaInvoiceFormReportViewer.Size = New System.Drawing.Size(795, 417)
        Me.ProformaInvoiceFormReportViewer.TabIndex = 1
        '
        'ProgressFiller1
        '
        Me.ProgressFiller1.Location = New System.Drawing.Point(262, 38)
        Me.ProgressFiller1.Name = "ProgressFiller1"
        Me.ProgressFiller1.Size = New System.Drawing.Size(422, 191)
        Me.ProgressFiller1.TabIndex = 2
        Me.ProgressFiller1.Visible = False
        '
        'ErrorWarnInfoProvider1
        '
        Me.ErrorWarnInfoProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleInformation = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.BlinkStyleWarning = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorWarnInfoProvider1.ContainerControl = Me
        Me.ErrorWarnInfoProvider1.DataSource = Me.CompanyRegionalDataBindingSource
        '
        'F_CompanyRegionalData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 481)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ProgressFiller1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_CompanyRegionalData"
        Me.ShowInTaskbar = False
        Me.Text = "Regioniniai įmonės duomenys"
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.CompanyRegionalDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoImagePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.ErrorWarnInfoProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ICancelButton As System.Windows.Forms.Button
    Friend WithEvents IOkButton As System.Windows.Forms.Button
    Friend WithEvents IApplyButton As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents AddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CompanyRegionalDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BankTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BankAccountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BankAddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BankSWIFTTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ContactsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DiscountNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents HeadTitleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents InvoiceInfoLineTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LanguageNameComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents LogoImagePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents MeasureUnitInvoiceMadeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ClearLogoButton As System.Windows.Forms.Button
    Friend WithEvents OpenImageButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents OpenInvoiceFormButton As System.Windows.Forms.Button
    Friend WithEvents ClearInvoiceFormButton As System.Windows.Forms.Button
    Friend WithEvents ProgressFiller1 As AccControlsWinForms.ProgressFiller
    Friend WithEvents ErrorWarnInfoProvider1 As AccControlsWinForms.ErrorWarnInfoProvider
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Private WithEvents InvoiceFormReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents OpenProformaInvoiceFormButton As System.Windows.Forms.Button
    Friend WithEvents ClearProformaInvoiceFormButton As System.Windows.Forms.Button
    Private WithEvents ProformaInvoiceFormReportViewer As Microsoft.Reporting.WinForms.ReportViewer
End Class
