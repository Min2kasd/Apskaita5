﻿Imports ApskaitaObjects.General
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.CachedInfoLists
Imports ApskaitaObjects.Attributes

Friend Class F_ClosingEntriesCommand
    Implements ISingleInstanceForm

    Private Loading As Boolean = True
    Private JournalEntryID As Integer = 0
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_ClosingEntriesCommand_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If Loading Then
            Loading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Exit Sub

    End Sub

    Private Sub F_ClosingEntriesCommand_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        MyCustomSettings.GetFormLayout(Me)
    End Sub

    Private Sub F_ClosingEntriesCommand_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller1)

        MyCustomSettings.SetFormLayout(Me)

        Dim CC As ApskaitaObjects.Settings.CompanyInfo = GetCurrentCompany()
        ConsolidatedAccountAccGridComboBox.SelectedValue = _
            CC.GetDefaultAccount(DefaultAccountType.ClosingSummary)
        CurrentProfitAccountAccGridComboBox.SelectedValue = _
            CC.GetDefaultAccount(DefaultAccountType.CurrentProfit)
        FormerProfitAccountAccGridComboBox.SelectedValue = _
            CC.GetDefaultAccount(DefaultAccountType.FormerProfit)

    End Sub


    Private Sub IOkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles IOkButton.Click
        If SaveObj() Then
            Me.Close()
        End If
    End Sub

    Private Sub ICancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ICancelButton.Click
        Me.Close()
    End Sub


    Private Function SaveObj() As Boolean

        If Not YesOrNo("DĖMESIO. Uždarius 5/6 klases nebebus leidžiama taisyti ar įvesti " & _
            "įrašų/dokumentų ankstesne nei uždarymo data. Ar tikrai norite tęsti?") Then Return False

        Using busy As New StatusBusy

            Dim nConsolidatedAccount As Long = 0
            Dim nCurrentProfitAccount As Long = 0
            Dim nFormerProfitAccount As Long = 0
            Try
                nConsolidatedAccount = Long.Parse(ConsolidatedAccountAccGridComboBox.SelectedValue.ToString)
            Catch ex As Exception
            End Try
            Try
                nCurrentProfitAccount = Long.Parse(CurrentProfitAccountAccGridComboBox.SelectedValue.ToString)
            Catch ex As Exception
            End Try
            Try
                nFormerProfitAccount = Long.Parse(FormerProfitAccountAccGridComboBox.SelectedValue.ToString)
            Catch ex As Exception
            End Try

            Try
                JournalEntryID = General.ClosingEntriesCommand.TheCommand( _
                    ClosingDateAccDatePicker.Value.Date, nConsolidatedAccount, _
                    nCurrentProfitAccount, nFormerProfitAccount)
            Catch ex As Exception
                ShowError(ex, New Object() {ClosingDateAccDatePicker.Value.Date, nConsolidatedAccount,
                    nCurrentProfitAccount, nFormerProfitAccount})
                Return False
            End Try

        End Using

        If YesOrNo("Penktos/šeštos klasės uždarymo įrašas sėkmingai padarytas." _
            & vbCrLf & "Rodyti šio įrašo kontavimus?") Then
            OpenObjectEditForm(_QueryManager, JournalEntryID, DocumentType.None)
        End If

        Return True

    End Function

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.AccountInfoList)) Then Return False

        Try

            PrepareControl(ConsolidatedAccountAccGridComboBox, New AccountFieldAttribute( _
                ValueRequiredLevel.Optional, False, 3))
            PrepareControl(CurrentProfitAccountAccGridComboBox, New AccountFieldAttribute( _
                ValueRequiredLevel.Optional, False, 3))
            PrepareControl(FormerProfitAccountAccGridComboBox, New AccountFieldAttribute( _
                ValueRequiredLevel.Optional, False, 3))

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

End Class