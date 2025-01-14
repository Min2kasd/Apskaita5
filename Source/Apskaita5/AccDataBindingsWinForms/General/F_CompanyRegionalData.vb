﻿Imports ApskaitaObjects.General
Imports System.Drawing
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.Printing
Imports AccDataBindingsWinForms.CachedInfoLists

Friend Class F_CompanyRegionalData
    Implements IObjectEditForm

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of CompanyRegionalData)
    Private _RegionalDataToEdit As CompanyRegionalData = Nothing
    Private _InvoiceFormDataSet As AccControlsWinForms.ReportData
    Private _ProformaInvoiceFormDataSet As AccControlsWinForms.ReportData


    Public ReadOnly Property ObjectID() As Integer Implements IObjectEditForm.ObjectID
        Get
            If _FormManager Is Nothing OrElse _FormManager.DataSource Is Nothing Then
                If _RegionalDataToEdit Is Nothing OrElse _RegionalDataToEdit.IsNew Then
                    Return Integer.MinValue
                Else
                    Return _RegionalDataToEdit.ID
                End If
            ElseIf _FormManager.DataSource.IsNew Then
                Return Integer.MinValue
            End If
            Return _FormManager.DataSource.ID
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type Implements IObjectEditForm.ObjectType
        Get
            Return GetType(CompanyRegionalData)
        End Get
    End Property


    Public Sub New(ByVal regionalDataToEdit As CompanyRegionalData)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _RegionalDataToEdit = regionalDataToEdit

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub


    Private Sub F_CompanyRegionalData_FormClosed(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        DisposeBindingSources(InvoiceFormReportViewer)
        DisposeBindingSources(ProformaInvoiceFormReportViewer)
        If Not _InvoiceFormDataSet Is Nothing Then _InvoiceFormDataSet.Dispose()
        If Not _ProformaInvoiceFormDataSet Is Nothing Then _ProformaInvoiceFormDataSet.Dispose()

    End Sub

    Private Sub F_CompanyRegionalData_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Load

        If Not SetDataSources() Then Exit Sub

        If _RegionalDataToEdit Is Nothing Then
            _RegionalDataToEdit = CompanyRegionalData.NewCompanyRegionalData
        End If

        Try

            _FormManager = New CslaActionExtenderEditForm(Of CompanyRegionalData) _
                (Me, CompanyRegionalDataBindingSource, _RegionalDataToEdit, _
                 Nothing, IOkButton, IApplyButton, ICancelButton, Nothing, ProgressFiller1)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti įmonės regioninių nustatymų duomenų.", ex), Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        UpdateReportDataSetWithRegionalData(_InvoiceFormDataSet, _FormManager.DataSource)
        UpdateReportDataSetWithRegionalData(_ProformaInvoiceFormDataSet, _FormManager.DataSource)
        InitializeReportViewer(InvoiceFormReportViewer, _InvoiceFormDataSet, _FormManager.DataSource.InvoiceForm)
        InitializeReportViewer(ProformaInvoiceFormReportViewer, _ProformaInvoiceFormDataSet, _FormManager.DataSource.ProformaInvoiceForm)
        If Not _FormManager.DataSource.InvoiceForm Is Nothing AndAlso _FormManager.DataSource.InvoiceForm.Length > 50 Then
            Me.InvoiceFormReportViewer.RefreshReport()
        End If
        If Not _FormManager.DataSource.ProformaInvoiceForm Is Nothing AndAlso _FormManager.DataSource.ProformaInvoiceForm.Length > 50 Then
            Me.ProformaInvoiceFormReportViewer.RefreshReport()
        End If

        ConfigureControls()

    End Sub

    Private Function SetDataSources() As Boolean

        Try

            Dim doomyInvoice As Documents.InvoiceMade = Documents.InvoiceMade.DoomyInvoiceMade
            _InvoiceFormDataSet = MapObjToReport(doomyInvoice, "", 1, 0, "", Nothing)

            Dim doomyProformaInvoice As Documents.ProformaInvoiceMade = Documents.ProformaInvoiceMade.DoomyProformaInvoiceMade()
            _ProformaInvoiceFormDataSet = MapObjToReport(doomyProformaInvoice, "", 1, 0, "", Nothing)

            SetupDefaultControls(Of CompanyRegionalData)(Me, _
                CompanyRegionalDataBindingSource, _RegionalDataToEdit)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        IOkButton.Enabled = CompanyRegionalData.CanEditObject
        OpenImageButton.Enabled = CompanyRegionalData.CanEditObject
        ClearLogoButton.Enabled = CompanyRegionalData.CanEditObject
        IApplyButton.Enabled = CompanyRegionalData.CanEditObject
        OpenInvoiceFormButton.Enabled = CompanyRegionalData.CanEditObject
        ClearInvoiceFormButton.Enabled = CompanyRegionalData.CanEditObject
        OpenProformaInvoiceFormButton.Enabled = CompanyRegionalData.CanEditObject
        ClearProformaInvoiceFormButton.Enabled = CompanyRegionalData.CanEditObject

        Return True

    End Function


    Private Sub OnReportRenderingComplete(ByVal sender As Object, _
        ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) _
        Handles InvoiceFormReportViewer.RenderingComplete, ProformaInvoiceFormReportViewer.RenderingComplete

        Dim viewer As Microsoft.Reporting.WinForms.ReportViewer = _
            CType(sender, Microsoft.Reporting.WinForms.ReportViewer)
        Try
            viewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            viewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
            viewer.ZoomPercent = 75
        Catch ex As Exception
        End Try

    End Sub

    Private Sub InvoiceFormReportViewer_ReportError(ByVal sender As Object, _
        ByVal e As Microsoft.Reporting.WinForms.ReportErrorEventArgs) _
        Handles InvoiceFormReportViewer.ReportError
        e.Handled = True
    End Sub


    Private Sub _FormManager_DataSourceStateHasChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles _FormManager.DataSourceStateHasChanged
        ConfigureControls()
    End Sub

    Private Sub OpenImageButton_Click(ByVal sender As System.Object, _
                ByVal e As System.EventArgs) Handles OpenImageButton.Click
        Using opf As New OpenFileDialog
            opf.Multiselect = False
            If opf.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
            If IO.File.Exists(opf.FileName) Then
                Try
                    _FormManager.DataSource.LogoImage = DirectCast(Bitmap.FromFile(opf.FileName).Clone, Image)
                Catch ex As Exception
                    ShowError(New Exception("Klaida. Neatpažintas paveikslėlio formatas: " & ex.Message, ex), Nothing)
                End Try
            End If
        End Using
    End Sub

    Private Sub ClearLogoButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ClearLogoButton.Click
        _FormManager.DataSource.LogoImage = Nothing
    End Sub

    Private Sub OpenInvoiceFormButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OpenInvoiceFormButton.Click
        If Not OpenForm(_FormManager.DataSource.InvoiceForm) Then Exit Sub
        InitializeReportViewer(InvoiceFormReportViewer, _InvoiceFormDataSet, _FormManager.DataSource.InvoiceForm)
    End Sub

    Private Sub ClearInvoiceFormButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ClearInvoiceFormButton.Click
        _FormManager.DataSource.InvoiceForm = Nothing
        InitializeReportViewer(InvoiceFormReportViewer, _InvoiceFormDataSet, _FormManager.DataSource.InvoiceForm)
    End Sub

    Private Sub OpenProformaInvoiceFormButton_Click(ByVal sender As System.Object, _
       ByVal e As System.EventArgs) Handles OpenProformaInvoiceFormButton.Click
        If Not OpenForm(_FormManager.DataSource.ProformaInvoiceForm) Then Exit Sub
        InitializeReportViewer(ProformaInvoiceFormReportViewer, _ProformaInvoiceFormDataSet, _FormManager.DataSource.ProformaInvoiceForm)
    End Sub

    Private Sub ClearProformaInvoiceFormButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ClearProformaInvoiceFormButton.Click
        _FormManager.DataSource.ProformaInvoiceForm = Nothing
        InitializeReportViewer(ProformaInvoiceFormReportViewer, _ProformaInvoiceFormDataSet, _FormManager.DataSource.ProformaInvoiceForm)
    End Sub


    Private Sub ConfigureControls()
        LanguageNameComboBox.Enabled = _FormManager.DataSource.IsNew
        ICancelButton.Enabled = _FormManager.DataSource.IsNew
    End Sub

    Private Sub DisposeBindingSources(ByVal viewer As Microsoft.Reporting.WinForms.ReportViewer)
        For Each ds As Microsoft.Reporting.WinForms.ReportDataSource _
            In viewer.LocalReport.DataSources
            CType(ds.Value, BindingSource).Dispose()
        Next
        If viewer.LocalReport.DataSources.Count > 0 Then _
            InvoiceFormReportViewer.LocalReport.DataSources.Clear()
    End Sub

    Private Sub InitializeReportViewer(ByRef viewer As Microsoft.Reporting.WinForms.ReportViewer, _
        ByVal datasource As AccControlsWinForms.ReportData, ByVal reportByteArray As Byte())

        DisposeBindingSources(viewer)

        viewer.Reset()

        If Not reportByteArray Is Nothing AndAlso reportByteArray.Length > 50 Then

            Dim tblGeneral As BindingSource = New BindingSource(datasource, "TableGeneral")
            Dim tbl1 As BindingSource = New BindingSource(datasource, "Table1")
            Dim tbl2 As BindingSource = New BindingSource(datasource, "Table2")
            Dim tbl3 As BindingSource = New BindingSource(datasource, "Table3")
            Dim tbl4 As BindingSource = New BindingSource(datasource, "Table4")
            Dim tbl5 As BindingSource = New BindingSource(datasource, "Table5")
            Dim tbl6 As BindingSource = New BindingSource(datasource, "Table6")
            Dim tblCompany As BindingSource = New BindingSource(datasource, "TableCompany")

            Dim newSourceGeneral As New Microsoft.Reporting.WinForms.ReportDataSource
            newSourceGeneral.Value = tblGeneral
            newSourceGeneral.Name = "ReportData_TableGeneral"

            Dim newSourceCompany As New Microsoft.Reporting.WinForms.ReportDataSource
            newSourceCompany.Value = tblCompany
            newSourceCompany.Name = "ReportData_TableCompany"

            viewer.LocalReport.DataSources.Add(newSourceGeneral)
            viewer.LocalReport.DataSources.Add(newSourceCompany)

            For i As Integer = 1 To 6

                Dim newSource As New Microsoft.Reporting.WinForms.ReportDataSource

                If i = 1 Then
                    newSource.Value = tbl1
                    newSource.Name = "ReportData_Table1"
                ElseIf i = 2 Then
                    newSource.Value = tbl2
                    newSource.Name = "ReportData_Table2"
                ElseIf i = 3 Then
                    newSource.Value = tbl3
                    newSource.Name = "ReportData_Table3"
                ElseIf i = 4 Then
                    newSource.Value = tbl4
                    newSource.Name = "ReportData_Table4"
                ElseIf i = 5 Then
                    newSource.Value = tbl5
                    newSource.Name = "ReportData_Table5"
                Else
                    newSource.Value = tbl6
                    newSource.Name = "ReportData_Table6"
                End If

                viewer.LocalReport.DataSources.Add(newSource)

            Next

            Dim fileStream As New IO.MemoryStream(reportByteArray)
            viewer.LocalReport.LoadReportDefinition(fileStream)

            viewer.RefreshReport()

        End If

    End Sub

    Private Function OpenForm(ByRef rdlcStream As Byte()) As Boolean

        Using opf As New OpenFileDialog
            opf.Multiselect = False
            opf.Filter = "Report Files (*.rdlc)|*.rdlc|All Files (*.*)|*.*"

            If opf.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then Return False

            If Not String.IsNullOrEmpty(opf.FileName) AndAlso IO.File.Exists(opf.FileName) Then

                Try
                    Using fs As New IO.FileStream(opf.FileName, IO.FileMode.Open)
                        Dim length As Integer = Convert.ToInt32(fs.Length - 1)
                        Dim bytes(length) As Byte
                        fs.Read(bytes, 0, length + 1)
                        rdlcStream = bytes
                        fs.Close()
                    End Using
                Catch ex As Exception
                    ShowError(ex, Nothing)
                    Return False
                End Try

            Else
                Return False
            End If

        End Using

        Return True

    End Function

End Class