﻿Imports ApskaitaObjects.General
Imports ApskaitaObjects.HelperLists
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists
Imports System.Drawing
Imports ApskaitaObjects.Attributes


Friend Class F_Company
    Implements ISingleInstanceForm

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(CompanyRegionalInfoList), GetType(AccountInfoList), GetType(VatDeclarationSchemaInfoList)}

    Private _FormManager As CslaActionExtenderEditForm(Of Company)
    Private _TaxRatesListViewManager As DataListViewEditControlManager(Of CompanyRate)
    Private _AccountsListViewManager As DataListViewEditControlManager(Of CompanyAccount)
    Private _RegionalListViewManager As DataListViewEditControlManager(Of CompanyRegionalInfo)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_Company_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            ' Company.GetCompany()
            _QueryManager.InvokeQuery(Of Company)(Nothing, "GetCompany", _
                True, AddressOf OnDataSourceLoaded)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
        End Try

    End Sub

    Private Sub OnDataSourceLoaded(ByVal source As Object, ByVal exceptionHandled As Boolean)

        If exceptionHandled Then

            DisableAllControls(Me)
            Exit Sub

        ElseIf source Is Nothing Then

            ShowError(New Exception("Klaida. Nepavyko gauti įmonės duomenų."), Nothing)
            DisableAllControls(Me)
            Exit Sub

        End If

        If Not SetDataSources(DirectCast(source, Company)) Then Exit Sub

        Try

            _FormManager = New CslaActionExtenderEditForm(Of Company) _
                (Me, CompanyBindingSource, DirectCast(source, Company), _
                 _RequiredCachedLists, nOkButton, SaveCompanyButton, nCancelButton, _
                 Nothing, ProgressFiller1)
            _FormManager.ManageDataListViewStates(CompanyRegionalInfoListDataListView)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti įmonės duomenų.", ex), Nothing)
            DisableAllControls(Me)
        End Try

    End Sub

    Private Function SetDataSources(ByVal source As Company) As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _TaxRatesListViewManager = New DataListViewEditControlManager(Of CompanyRate) _
                (DefaultTaxRatesDataListView, Nothing, Nothing, Nothing, Nothing, Nothing)
            _AccountsListViewManager = New DataListViewEditControlManager(Of CompanyAccount) _
                (AccountsDataListView, Nothing, Nothing, Nothing, Nothing, Nothing)

            _RegionalListViewManager = New DataListViewEditControlManager(Of CompanyRegionalInfo) _
                (CompanyRegionalInfoListDataListView, ContextMenuStrip1, Nothing, Nothing, _
                 AddressOf IsActionAvailable, Nothing)

            _RegionalListViewManager.AddButtonHandler("Keisti", "Keisti įmonės regioninius nustatymus pasirinktai kalbai", _
                AddressOf EditRegionalInfo)
            _RegionalListViewManager.AddButtonHandler("Ištrinti", "Ištrinti įmonės regioninius nustatymus pasirinktai kalbai", _
                AddressOf DeleteRegionalInfo)
            _RegionalListViewManager.AddButtonHandler("Nauji", "Sukurti įmonės regioninius nustatymus naujai kalbai", _
                AddressOf AddNewRegionalInfo)
            _RegionalListViewManager.AddCancelButton = True

            _RegionalListViewManager.AddMenuItemHandler(EditItem_MenuItem, AddressOf EditRegionalInfo)
            _RegionalListViewManager.AddMenuItemHandler(DeleteItem_MenuItem, AddressOf DeleteRegionalInfo)
            _RegionalListViewManager.AddMenuItemHandler(NewItem_MenuItem, AddressOf AddNewRegionalInfo)

            CompanyRegionalInfoListBindingSource.DataSource = _
                GetBindingSource(New CompanyRegionalInfoFieldAttribute( _
                ValueRequiredLevel.Mandatory), Nothing)

            SetupDefaultControls(Of Company)(Me, CompanyBindingSource, source)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti įmonės duomenų.", ex), Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        nOkButton.Enabled = ApskaitaObjects.General.Company.CanEditObject
        SaveCompanyButton.Enabled = General.Company.CanEditObject
        OpenImageButton.Enabled = General.Company.CanEditObject
        ClearLogoButton.Enabled = General.Company.CanEditObject

        Return True

    End Function


    Private Function IsActionAvailable(ByVal item As CompanyRegionalInfo, ByVal action As String) As Boolean
        If item Is Nothing Then Return False
        If action.Trim.ToLower = "DeleteRegionalInfo".ToLower AndAlso item.LanguageCode.Trim.ToUpper = LanguageCodeLith.Trim.ToUpper Then
            Return False
        End If
        Return True
    End Function

    Private Sub EditRegionalInfo(ByVal info As CompanyRegionalInfo)
        If info Is Nothing Then Exit Sub
        ' CompanyRegionalData.GetCompanyRegionalData(info.ID)
        _QueryManager.InvokeQuery(Of CompanyRegionalData)(Nothing, "GetCompanyRegionalData", _
            False, AddressOf OpenObjectEditForm, info.ID)
    End Sub

    Private Sub AddNewRegionalInfo(ByVal info As CompanyRegionalInfo)
        OpenNewForm(Of General.CompanyRegionalData)()
    End Sub

    Private Sub DeleteRegionalInfo(ByVal info As CompanyRegionalInfo)

        If info Is Nothing OrElse info.LanguageCode.Trim.ToUpper = LanguageCodeLith.Trim.ToUpper Then Exit Sub

        If Not YesOrNo(String.Format("Ar tikrai norite pašalinti regionius nustatymus {0}.", info.LanguageName)) Then Exit Sub

        _QueryManager.InvokeQuery(Of CompanyRegionalData)(Nothing, "DeleteCompanyRegionalData", _
            False, AddressOf OnDeletedRegionalInfo, info.ID)

    End Sub

    Private Sub OnDeletedRegionalInfo(ByVal result As Object, ByVal exceptionHandled As Boolean)
        If exceptionHandled Then Exit Sub
        MsgBox("Regioniniai nustatymai sėkmingai pašalinti.", MsgBoxStyle.Information, "Info")
        _QueryManager.InvokeQuery(Of CompanyRegionalInfoList)(Nothing, "GetList", _
            False, AddressOf OnRegionalInfoListRefresh)
    End Sub

    Private Sub OnRegionalInfoListRefresh(ByVal result As Object, ByVal exceptionHandled As Boolean)

    End Sub


    Private Sub OpenImageButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OpenImageButton.Click
        Using opf As New OpenFileDialog
            opf.Multiselect = False
            If opf.ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
            If IO.File.Exists(opf.FileName) Then
                Try
                    _FormManager.DataSource.HeadPersonSignature = DirectCast(Bitmap.FromFile(opf.FileName).Clone, Image)
                Catch ex As Exception
                    ShowError(New Exception("Klaida. Neatpažintas paveikslėlio formatas: " & ex.Message, ex), Nothing)
                End Try
            End If
        End Using
    End Sub

    Private Sub ClearLogoButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ClearLogoButton.Click
        _FormManager.DataSource.HeadPersonSignature = Nothing
    End Sub

    Private Sub NewRegionDataButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewRegionDataButton.Click
        AddNewRegionalInfo(Nothing)
    End Sub


End Class