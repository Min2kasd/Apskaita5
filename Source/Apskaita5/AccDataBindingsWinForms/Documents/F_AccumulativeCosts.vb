﻿Imports ApskaitaObjects.Documents
Imports AccControlsWinForms
Imports AccDataBindingsWinForms.Printing
Imports AccDataBindingsWinForms.CachedInfoLists

Friend Class F_AccumulativeCosts
    Implements IObjectEditForm, ISupportsChronologicValidator

    Private ReadOnly _RequiredCachedLists As Type() = New Type() _
        {GetType(HelperLists.AccountInfoList)}

    Private WithEvents _FormManager As CslaActionExtenderEditForm(Of AccumulativeCosts)
    Private _ListViewManager As DataListViewEditControlManager(Of AccumulativeCostsItem)

    Private _DocumentToEdit As AccumulativeCosts = Nothing


    Public ReadOnly Property ObjectID() As Integer _
        Implements IObjectEditForm.ObjectID
        Get
            If _FormManager Is Nothing OrElse _FormManager.DataSource Is Nothing Then
                If _DocumentToEdit Is Nothing OrElse _DocumentToEdit.IsNew Then
                    Return Integer.MinValue
                Else
                    Return _DocumentToEdit.ID
                End If
            End If
            Return _FormManager.DataSource.ID
        End Get
    End Property

    Public ReadOnly Property ObjectType() As System.Type _
        Implements IObjectEditForm.ObjectType
        Get
            Return GetType(AccumulativeCosts)
        End Get
    End Property


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal documentToEdit As AccumulativeCosts)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _DocumentToEdit = documentToEdit

    End Sub


    Private Sub F_AccumulativeCosts_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        If _DocumentToEdit Is Nothing Then
            _DocumentToEdit = AccumulativeCosts.NewAccumulativeCosts()
        End If

        Try

            _FormManager = New CslaActionExtenderEditForm(Of AccumulativeCosts) _
                (Me, AccumulativeCostsBindingSource, _DocumentToEdit, _
                 _RequiredCachedLists, nOkButton, ApplyButton, nCancelButton, _
                 Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(ItemsDataListView)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

        ConfigureButtons()

    End Sub

    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, _RequiredCachedLists) Then Return False

        Try

            _ListViewManager = New DataListViewEditControlManager(Of AccumulativeCostsItem) _
                (ItemsDataListView, Nothing, AddressOf OnItemsDelete, _
                 AddressOf OnItemAdd, Nothing, _DocumentToEdit)

            SetupDefaultControls(Of AccumulativeCosts)(Me, _
                AccumulativeCostsBindingSource, _DocumentToEdit)

        Catch ex As Exception
            ShowError(ex, Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function


    Private Sub OnItemsDelete(ByVal items As AccumulativeCostsItem())
        If items Is Nothing OrElse items.Length < 1 OrElse _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.ChronologyValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Eilučių pašalinti neleidžiama:{0}{1}", vbCrLf, _
                _FormManager.DataSource.ChronologyValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        For Each item As AccumulativeCostsItem In items
            _FormManager.DataSource.Items.Remove(item)
        Next
    End Sub

    Private Sub OnItemAdd()
        If _FormManager.DataSource Is Nothing Then Exit Sub
        If Not _FormManager.DataSource.ChronologyValidator.FinancialDataCanChange Then
            MsgBox(String.Format("Klaida. Keisti dokumento finansinių duomenų negalima, įskaitant kontavimų pridėjimą:{0}{1}", vbCrLf, _
                _FormManager.DataSource.ChronologyValidator.FinancialDataCanChangeExplanation), _
                MsgBoxStyle.Exclamation, "Klaida")
            Exit Sub
        End If
        _FormManager.DataSource.Items.AddNew()
    End Sub

    Private Sub DistributeButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles DistributeButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        Try
            _FormManager.DataSource.Distribute()
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try

    End Sub

    Private Sub NewDistributionButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles NewDistributionButton.Click

        If _FormManager.DataSource Is Nothing Then Exit Sub

        If _FormManager.DataSource.Items.Count > 0 Then
            If Not YesOrNo("DĖMESIO. Operacijai jau yra sukurtų eilučių. Sukuriant naują " _
                & "paskirstymą jos bus prarastos. Ar tikrai norite tęsti?") Then Exit Sub
        End If

        Try
            _FormManager.DataSource.Distribute(FirstPeriodAccDatePicker.Value, _
                Convert.ToInt32(PeriodLengthNumericUpDown.Value), _
                Convert.ToInt32(PeriodCountNumericUpDown.Value))
        Catch ex As Exception
            ShowError(ex, _FormManager.DataSource)
        End Try

    End Sub


    Public Function ChronologicContent() As String _
        Implements ISupportsChronologicValidator.ChronologicContent
        If _FormManager.DataSource Is Nothing Then Return ""
        Return _FormManager.DataSource.ChronologyValidator.LimitsExplanation
    End Function

    Public Function HasChronologicContent() As Boolean _
        Implements ISupportsChronologicValidator.HasChronologicContent

        Return Not _FormManager.DataSource Is Nothing AndAlso _
            Not StringIsNullOrEmpty(_FormManager.DataSource.ChronologyValidator.LimitsExplanation)

    End Function


    Private Sub _FormManager_DataSourceStateHasChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles _FormManager.DataSourceStateHasChanged
        ConfigureButtons()
    End Sub

    Private Sub ConfigureButtons()

        If _FormManager.DataSource Is Nothing Then Exit Sub

        AccountCostsAccGridComboBox.Enabled = Not _FormManager.DataSource.AccountCostsIsReadOnly
        AccountAccumulatedCostsAccGridComboBox.Enabled = Not _FormManager.DataSource.AccountAccumulatedCostsIsReadOnly
        AccountDistributedCostsAccGridComboBox.Enabled = Not _FormManager.DataSource.AccountDistributedCostsIsReadOnly
        SumAccTextBox.ReadOnly = _FormManager.DataSource.SumIsReadOnly

        nCancelButton.Enabled = Not _FormManager.DataSource.IsNew

        EditedBaner.Visible = Not _FormManager.DataSource.IsNew

    End Sub

End Class