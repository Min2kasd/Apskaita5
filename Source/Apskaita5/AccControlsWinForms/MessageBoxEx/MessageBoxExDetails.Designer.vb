﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageBoxExDetails
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.OK = New System.Windows.Forms.Button()
        Me.ExDetails = New System.Windows.Forms.TextBox()
        Me.ReportButton = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.ReportButton)
        Me.Panel1.Controls.Add(Me.OK)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 290)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(338, 29)
        Me.Panel1.TabIndex = 0
        '
        'OK
        '
        Me.OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK.Location = New System.Drawing.Point(265, 3)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(70, 23)
        Me.OK.TabIndex = 0
        Me.OK.Text = "Ok"
        Me.OK.UseVisualStyleBackColor = True
        '
        'ExDetails
        '
        Me.ExDetails.CausesValidation = False
        Me.ExDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExDetails.Location = New System.Drawing.Point(0, 0)
        Me.ExDetails.Multiline = True
        Me.ExDetails.Name = "ExDetails"
        Me.ExDetails.ReadOnly = True
        Me.ExDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ExDetails.Size = New System.Drawing.Size(338, 290)
        Me.ExDetails.TabIndex = 1
        '
        'ReportButton
        '
        Me.ReportButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ReportButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportButton.Location = New System.Drawing.Point(180, 3)
        Me.ReportButton.Name = "ReportButton"
        Me.ReportButton.Size = New System.Drawing.Size(70, 23)
        Me.ReportButton.TabIndex = 1
        Me.ReportButton.Text = "Pranešti"
        Me.ReportButton.UseVisualStyleBackColor = True
        '
        'MessageBoxExDetails
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.OK
        Me.ClientSize = New System.Drawing.Size(338, 319)
        Me.ControlBox = False
        Me.Controls.Add(Me.ExDetails)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MessageBoxExDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detali info apie klaidą"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents ExDetails As System.Windows.Forms.TextBox
    Friend WithEvents ReportButton As Windows.Forms.Button
End Class
