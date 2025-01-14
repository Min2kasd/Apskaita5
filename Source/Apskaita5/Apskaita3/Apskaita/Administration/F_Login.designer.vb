﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Login
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
        Dim ApplicationServerURLLabel As System.Windows.Forms.Label
        Dim ConnectionTechnologyHumanReadableLabel As System.Windows.Forms.Label
        Dim NameLabel As System.Windows.Forms.Label
        Dim SqlServerAddressLabel As System.Windows.Forms.Label
        Dim SqlServerPortLabel As System.Windows.Forms.Label
        Dim SqlServerTypeHumanReadableLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim DatabaseNamingConventionLabel As System.Windows.Forms.Label
        Dim SslCertificateFileLabel As System.Windows.Forms.Label
        Dim SslCertificatePasswordLabel As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_Login))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.LocalUserListAccGridComboBox = New AccControlsWinForms.AccListComboBox
        Me.NewUserCheckBox = New System.Windows.Forms.CheckBox
        Me.LoginWithoutServerButton = New System.Windows.Forms.Button
        Me.LoginButton = New System.Windows.Forms.Button
        Me.PasswordTextBox = New System.Windows.Forms.TextBox
        Me.NameTextBox = New System.Windows.Forms.TextBox
        Me.LocalUserBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SqlConnectionCharSetTextBox = New System.Windows.Forms.TextBox
        Me.CannotSetGrantsCheckBox = New System.Windows.Forms.CheckBox
        Me.OpenCertificateFileButton = New System.Windows.Forms.Button
        Me.SslCertificatePasswordTextBox = New System.Windows.Forms.TextBox
        Me.SslCertificateFileTextBox = New System.Windows.Forms.TextBox
        Me.SslCertificateInstalledCheckBox = New System.Windows.Forms.CheckBox
        Me.UseSSLCheckBox = New System.Windows.Forms.CheckBox
        Me.DatabaseNamingConventionTextBox = New System.Windows.Forms.TextBox
        Me.SqlServerPortAccBox = New AccControlsWinForms.AccTextBox
        Me.SqlServerAddressTextBox = New System.Windows.Forms.TextBox
        Me.SqlServerTypeHumanReadableComboBox = New System.Windows.Forms.ComboBox
        Me.ConnectionTechnologyHumanReadableComboBox = New System.Windows.Forms.ComboBox
        Me.ApplicationServerURLTextBox = New System.Windows.Forms.TextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        ApplicationServerURLLabel = New System.Windows.Forms.Label
        ConnectionTechnologyHumanReadableLabel = New System.Windows.Forms.Label
        NameLabel = New System.Windows.Forms.Label
        SqlServerAddressLabel = New System.Windows.Forms.Label
        SqlServerPortLabel = New System.Windows.Forms.Label
        SqlServerTypeHumanReadableLabel = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        DatabaseNamingConventionLabel = New System.Windows.Forms.Label
        SslCertificateFileLabel = New System.Windows.Forms.Label
        SslCertificatePasswordLabel = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.LocalUserBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ApplicationServerURLLabel
        '
        ApplicationServerURLLabel.AutoSize = True
        ApplicationServerURLLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ApplicationServerURLLabel.Location = New System.Drawing.Point(2, 37)
        ApplicationServerURLLabel.Name = "ApplicationServerURLLabel"
        ApplicationServerURLLabel.Size = New System.Drawing.Size(148, 13)
        ApplicationServerURLLabel.TabIndex = 0
        ApplicationServerURLLabel.Text = "Programos serverio URL:"
        '
        'ConnectionTechnologyHumanReadableLabel
        '
        ConnectionTechnologyHumanReadableLabel.AutoSize = True
        ConnectionTechnologyHumanReadableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ConnectionTechnologyHumanReadableLabel.Location = New System.Drawing.Point(35, 10)
        ConnectionTechnologyHumanReadableLabel.Name = "ConnectionTechnologyHumanReadableLabel"
        ConnectionTechnologyHumanReadableLabel.Size = New System.Drawing.Size(115, 13)
        ConnectionTechnologyHumanReadableLabel.TabIndex = 4
        ConnectionTechnologyHumanReadableLabel.Text = "Ryšio technologija:"
        '
        'NameLabel
        '
        NameLabel.AutoSize = True
        NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NameLabel.Location = New System.Drawing.Point(66, 14)
        NameLabel.Name = "NameLabel"
        NameLabel.Size = New System.Drawing.Size(104, 13)
        NameLabel.TabIndex = 8
        NameLabel.Text = "Vartotojo vardas:"
        '
        'SqlServerAddressLabel
        '
        SqlServerAddressLabel.AutoSize = True
        SqlServerAddressLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SqlServerAddressLabel.Location = New System.Drawing.Point(18, 63)
        SqlServerAddressLabel.Name = "SqlServerAddressLabel"
        SqlServerAddressLabel.Size = New System.Drawing.Size(132, 13)
        SqlServerAddressLabel.TabIndex = 10
        SqlServerAddressLabel.Text = "SQL serverio adresas:"
        '
        'SqlServerPortLabel
        '
        SqlServerPortLabel.AutoSize = True
        SqlServerPortLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SqlServerPortLabel.Location = New System.Drawing.Point(27, 89)
        SqlServerPortLabel.Name = "SqlServerPortLabel"
        SqlServerPortLabel.Size = New System.Drawing.Size(123, 13)
        SqlServerPortLabel.TabIndex = 12
        SqlServerPortLabel.Text = "SQL serverio portas:"
        '
        'SqlServerTypeHumanReadableLabel
        '
        SqlServerTypeHumanReadableLabel.AutoSize = True
        SqlServerTypeHumanReadableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SqlServerTypeHumanReadableLabel.Location = New System.Drawing.Point(35, 115)
        SqlServerTypeHumanReadableLabel.Name = "SqlServerTypeHumanReadableLabel"
        SqlServerTypeHumanReadableLabel.Size = New System.Drawing.Size(115, 13)
        SqlServerTypeHumanReadableLabel.TabIndex = 16
        SqlServerTypeHumanReadableLabel.Text = "SQL serverio tipas:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(94, 40)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(76, 13)
        Label1.TabIndex = 13
        Label1.Text = "Slaptažodis:"
        '
        'DatabaseNamingConventionLabel
        '
        DatabaseNamingConventionLabel.AutoSize = True
        DatabaseNamingConventionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DatabaseNamingConventionLabel.Location = New System.Drawing.Point(23, 142)
        DatabaseNamingConventionLabel.Name = "DatabaseNamingConventionLabel"
        DatabaseNamingConventionLabel.Size = New System.Drawing.Size(127, 13)
        DatabaseNamingConventionLabel.TabIndex = 16
        DatabaseNamingConventionLabel.Text = "DB pavadinimo bazė:"
        '
        'SslCertificateFileLabel
        '
        SslCertificateFileLabel.AutoSize = True
        SslCertificateFileLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SslCertificateFileLabel.Location = New System.Drawing.Point(22, 234)
        SslCertificateFileLabel.Name = "SslCertificateFileLabel"
        SslCertificateFileLabel.Size = New System.Drawing.Size(128, 13)
        SslCertificateFileLabel.TabIndex = 19
        SslCertificateFileLabel.Text = "SSL sertifikato failas:"
        '
        'SslCertificatePasswordLabel
        '
        SslCertificatePasswordLabel.AutoSize = True
        SslCertificatePasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SslCertificatePasswordLabel.Location = New System.Drawing.Point(24, 260)
        SslCertificatePasswordLabel.Name = "SslCertificatePasswordLabel"
        SslCertificatePasswordLabel.Size = New System.Drawing.Size(126, 13)
        SslCertificatePasswordLabel.TabIndex = 20
        SslCertificatePasswordLabel.Text = "SSL sert. failo slapt.:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(66, 286)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(84, 13)
        Label2.TabIndex = 22
        Label2.Text = "SQL CharSet:"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.LocalUserListAccGridComboBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.NewUserCheckBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LoginWithoutServerButton)
        Me.SplitContainer1.Panel1.Controls.Add(Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LoginButton)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PasswordTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.NameTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(NameLabel)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.SqlConnectionCharSetTextBox)
        Me.SplitContainer1.Panel2.Controls.Add(Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CannotSetGrantsCheckBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.OpenCertificateFileButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.SslCertificatePasswordTextBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.SslCertificateFileTextBox)
        Me.SplitContainer1.Panel2.Controls.Add(SslCertificatePasswordLabel)
        Me.SplitContainer1.Panel2.Controls.Add(SslCertificateFileLabel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.SslCertificateInstalledCheckBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.UseSSLCheckBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DatabaseNamingConventionTextBox)
        Me.SplitContainer1.Panel2.Controls.Add(DatabaseNamingConventionLabel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.SqlServerPortAccBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.SqlServerAddressTextBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.SqlServerTypeHumanReadableComboBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ConnectionTechnologyHumanReadableComboBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ApplicationServerURLTextBox)
        Me.SplitContainer1.Panel2.Controls.Add(ApplicationServerURLLabel)
        Me.SplitContainer1.Panel2.Controls.Add(ConnectionTechnologyHumanReadableLabel)
        Me.SplitContainer1.Panel2.Controls.Add(SqlServerAddressLabel)
        Me.SplitContainer1.Panel2.Controls.Add(SqlServerPortLabel)
        Me.SplitContainer1.Panel2.Controls.Add(SqlServerTypeHumanReadableLabel)
        Me.SplitContainer1.Panel2Collapsed = True
        Me.SplitContainer1.Size = New System.Drawing.Size(632, 102)
        Me.SplitContainer1.SplitterDistance = 77
        Me.SplitContainer1.TabIndex = 0
        '
        'LocalUserListAccGridComboBox
        '
        Me.LocalUserListAccGridComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LocalUserListAccGridComboBox.EmptyValueString = ""
        Me.LocalUserListAccGridComboBox.InstantBinding = True
        Me.LocalUserListAccGridComboBox.Location = New System.Drawing.Point(176, 10)
        Me.LocalUserListAccGridComboBox.Name = "LocalUserListAccGridComboBox"
        Me.LocalUserListAccGridComboBox.Size = New System.Drawing.Size(427, 21)
        Me.LocalUserListAccGridComboBox.TabIndex = 3
        '
        'NewUserCheckBox
        '
        Me.NewUserCheckBox.AutoSize = True
        Me.NewUserCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewUserCheckBox.Location = New System.Drawing.Point(5, 67)
        Me.NewUserCheckBox.Name = "NewUserCheckBox"
        Me.NewUserCheckBox.Size = New System.Drawing.Size(125, 17)
        Me.NewUserCheckBox.TabIndex = 4
        Me.NewUserCheckBox.Text = "Naujas vartotojas"
        Me.NewUserCheckBox.UseVisualStyleBackColor = True
        '
        'LoginWithoutServerButton
        '
        Me.LoginWithoutServerButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoginWithoutServerButton.Location = New System.Drawing.Point(176, 63)
        Me.LoginWithoutServerButton.Name = "LoginWithoutServerButton"
        Me.LoginWithoutServerButton.Size = New System.Drawing.Size(93, 23)
        Me.LoginWithoutServerButton.TabIndex = 2
        Me.LoginWithoutServerButton.Text = "Be serverio"
        Me.LoginWithoutServerButton.UseVisualStyleBackColor = True
        '
        'LoginButton
        '
        Me.LoginButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LoginButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoginButton.Location = New System.Drawing.Point(545, 63)
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.Size = New System.Drawing.Size(75, 23)
        Me.LoginButton.TabIndex = 1
        Me.LoginButton.Text = "Login"
        Me.LoginButton.UseVisualStyleBackColor = True
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PasswordTextBox.Location = New System.Drawing.Point(176, 37)
        Me.PasswordTextBox.MaxLength = 50
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(427, 20)
        Me.PasswordTextBox.TabIndex = 0
        Me.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NameTextBox
        '
        Me.NameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LocalUserBindingSource, "Name", True))
        Me.NameTextBox.Location = New System.Drawing.Point(176, 11)
        Me.NameTextBox.MaxLength = 50
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(427, 20)
        Me.NameTextBox.TabIndex = 9
        Me.NameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NameTextBox.Visible = False
        '
        'LocalUserBindingSource
        '
        Me.LocalUserBindingSource.DataSource = GetType(AccDataAccessLayer.Security.LocalUser)
        '
        'SqlConnectionCharSetTextBox
        '
        Me.SqlConnectionCharSetTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SqlConnectionCharSetTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LocalUserBindingSource, "SqlConnectionCharSet", True))
        Me.SqlConnectionCharSetTextBox.Location = New System.Drawing.Point(147, 283)
        Me.SqlConnectionCharSetTextBox.MaxLength = 255
        Me.SqlConnectionCharSetTextBox.Name = "SqlConnectionCharSetTextBox"
        Me.SqlConnectionCharSetTextBox.Size = New System.Drawing.Size(701, 20)
        Me.SqlConnectionCharSetTextBox.TabIndex = 23
        Me.SqlConnectionCharSetTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CannotSetGrantsCheckBox
        '
        Me.CannotSetGrantsCheckBox.AutoSize = True
        Me.CannotSetGrantsCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.LocalUserBindingSource, "CannotSetGrants", True))
        Me.CannotSetGrantsCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CannotSetGrantsCheckBox.Location = New System.Drawing.Point(147, 165)
        Me.CannotSetGrantsCheckBox.Name = "CannotSetGrantsCheckBox"
        Me.CannotSetGrantsCheckBox.Size = New System.Drawing.Size(231, 17)
        Me.CannotSetGrantsCheckBox.TabIndex = 6
        Me.CannotSetGrantsCheckBox.Text = "Tik vidinis vartotojų administravimas"
        '
        'OpenCertificateFileButton
        '
        Me.OpenCertificateFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OpenCertificateFileButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenCertificateFileButton.Image = Global.ApskaitaWUI.My.Resources.Resources.folder_open_icon_16p
        Me.OpenCertificateFileButton.Location = New System.Drawing.Point(1289, 228)
        Me.OpenCertificateFileButton.Name = "OpenCertificateFileButton"
        Me.OpenCertificateFileButton.Size = New System.Drawing.Size(24, 24)
        Me.OpenCertificateFileButton.TabIndex = 9
        Me.OpenCertificateFileButton.UseVisualStyleBackColor = True
        '
        'SslCertificatePasswordTextBox
        '
        Me.SslCertificatePasswordTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SslCertificatePasswordTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LocalUserBindingSource, "SslCertificatePassword", True))
        Me.SslCertificatePasswordTextBox.Location = New System.Drawing.Point(147, 257)
        Me.SslCertificatePasswordTextBox.Name = "SslCertificatePasswordTextBox"
        Me.SslCertificatePasswordTextBox.Size = New System.Drawing.Size(1166, 20)
        Me.SslCertificatePasswordTextBox.TabIndex = 10
        Me.SslCertificatePasswordTextBox.UseSystemPasswordChar = True
        '
        'SslCertificateFileTextBox
        '
        Me.SslCertificateFileTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SslCertificateFileTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LocalUserBindingSource, "SslCertificateFile", True))
        Me.SslCertificateFileTextBox.Location = New System.Drawing.Point(147, 231)
        Me.SslCertificateFileTextBox.Name = "SslCertificateFileTextBox"
        Me.SslCertificateFileTextBox.ReadOnly = True
        Me.SslCertificateFileTextBox.Size = New System.Drawing.Size(1141, 20)
        Me.SslCertificateFileTextBox.TabIndex = 20
        '
        'SslCertificateInstalledCheckBox
        '
        Me.SslCertificateInstalledCheckBox.AutoSize = True
        Me.SslCertificateInstalledCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.LocalUserBindingSource, "SslCertificateInstalled", True))
        Me.SslCertificateInstalledCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SslCertificateInstalledCheckBox.Location = New System.Drawing.Point(147, 208)
        Me.SslCertificateInstalledCheckBox.Name = "SslCertificateInstalledCheckBox"
        Me.SslCertificateInstalledCheckBox.Size = New System.Drawing.Size(183, 17)
        Me.SslCertificateInstalledCheckBox.TabIndex = 8
        Me.SslCertificateInstalledCheckBox.Text = "SSL sertifikatas instaliuotas"
        '
        'UseSSLCheckBox
        '
        Me.UseSSLCheckBox.AutoSize = True
        Me.UseSSLCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.LocalUserBindingSource, "UseSSL", True))
        Me.UseSSLCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UseSSLCheckBox.Location = New System.Drawing.Point(147, 185)
        Me.UseSSLCheckBox.Name = "UseSSLCheckBox"
        Me.UseSSLCheckBox.Size = New System.Drawing.Size(97, 17)
        Me.UseSSLCheckBox.TabIndex = 7
        Me.UseSSLCheckBox.Text = "Naudoti SSL"
        '
        'DatabaseNamingConventionTextBox
        '
        Me.DatabaseNamingConventionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DatabaseNamingConventionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LocalUserBindingSource, "DatabaseNamingConvention", True))
        Me.DatabaseNamingConventionTextBox.Location = New System.Drawing.Point(147, 139)
        Me.DatabaseNamingConventionTextBox.Name = "DatabaseNamingConventionTextBox"
        Me.DatabaseNamingConventionTextBox.Size = New System.Drawing.Size(1166, 20)
        Me.DatabaseNamingConventionTextBox.TabIndex = 5
        '
        'SqlServerPortAccBox
        '
        Me.SqlServerPortAccBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SqlServerPortAccBox.DataBindings.Add(New System.Windows.Forms.Binding("DecimalValue", Me.LocalUserBindingSource, "SqlServerPort", True))
        Me.SqlServerPortAccBox.DecimalLength = 0
        Me.SqlServerPortAccBox.Location = New System.Drawing.Point(147, 86)
        Me.SqlServerPortAccBox.Name = "SqlServerPortAccBox"
        Me.SqlServerPortAccBox.NegativeValue = False
        Me.SqlServerPortAccBox.Size = New System.Drawing.Size(1166, 20)
        Me.SqlServerPortAccBox.TabIndex = 3
        Me.SqlServerPortAccBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SqlServerAddressTextBox
        '
        Me.SqlServerAddressTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SqlServerAddressTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LocalUserBindingSource, "SqlServerAddress", True))
        Me.SqlServerAddressTextBox.Location = New System.Drawing.Point(147, 60)
        Me.SqlServerAddressTextBox.MaxLength = 254
        Me.SqlServerAddressTextBox.Name = "SqlServerAddressTextBox"
        Me.SqlServerAddressTextBox.Size = New System.Drawing.Size(1166, 20)
        Me.SqlServerAddressTextBox.TabIndex = 2
        '
        'SqlServerTypeHumanReadableComboBox
        '
        Me.SqlServerTypeHumanReadableComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SqlServerTypeHumanReadableComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LocalUserBindingSource, "SqlServerTypeHumanReadable", True))
        Me.SqlServerTypeHumanReadableComboBox.FormattingEnabled = True
        Me.SqlServerTypeHumanReadableComboBox.Location = New System.Drawing.Point(147, 112)
        Me.SqlServerTypeHumanReadableComboBox.Name = "SqlServerTypeHumanReadableComboBox"
        Me.SqlServerTypeHumanReadableComboBox.Size = New System.Drawing.Size(1166, 21)
        Me.SqlServerTypeHumanReadableComboBox.TabIndex = 4
        '
        'ConnectionTechnologyHumanReadableComboBox
        '
        Me.ConnectionTechnologyHumanReadableComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConnectionTechnologyHumanReadableComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LocalUserBindingSource, "ConnectionTechnologyHumanReadable", True))
        Me.ConnectionTechnologyHumanReadableComboBox.FormattingEnabled = True
        Me.ConnectionTechnologyHumanReadableComboBox.Location = New System.Drawing.Point(147, 7)
        Me.ConnectionTechnologyHumanReadableComboBox.Name = "ConnectionTechnologyHumanReadableComboBox"
        Me.ConnectionTechnologyHumanReadableComboBox.Size = New System.Drawing.Size(1166, 21)
        Me.ConnectionTechnologyHumanReadableComboBox.TabIndex = 0
        '
        'ApplicationServerURLTextBox
        '
        Me.ApplicationServerURLTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplicationServerURLTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LocalUserBindingSource, "ApplicationServerURL", True))
        Me.ApplicationServerURLTextBox.Location = New System.Drawing.Point(147, 34)
        Me.ApplicationServerURLTextBox.MaxLength = 254
        Me.ApplicationServerURLTextBox.Name = "ApplicationServerURLTextBox"
        Me.ApplicationServerURLTextBox.Size = New System.Drawing.Size(1166, 20)
        Me.ApplicationServerURLTextBox.TabIndex = 1
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.DataSource = Me.LocalUserBindingSource
        '
        'F_Login
        '
        Me.AcceptButton = Me.LoginButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 102)
        Me.Controls.Add(Me.SplitContainer1)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "F_Login"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.LocalUserBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ConnectionTechnologyHumanReadableComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents LocalUserBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ApplicationServerURLTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SqlServerAddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SqlServerTypeHumanReadableComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents LoginButton As System.Windows.Forms.Button
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NewUserCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents LoginWithoutServerButton As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents SqlServerPortAccBox As AccControlsWinForms.AccTextBox
    Friend WithEvents DatabaseNamingConventionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SslCertificateInstalledCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents UseSSLCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents OpenCertificateFileButton As System.Windows.Forms.Button
    Friend WithEvents SslCertificatePasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SslCertificateFileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CannotSetGrantsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents LocalUserListAccGridComboBox As AccControlsWinForms.AccListComboBox
    Friend WithEvents SqlConnectionCharSetTextBox As System.Windows.Forms.TextBox
End Class
