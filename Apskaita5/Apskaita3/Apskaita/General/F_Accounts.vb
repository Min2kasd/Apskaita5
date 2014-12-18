Public Class F_Accounts
    Implements ISupportsPrinting

    Private Obj As General.AccountList
    Private IsLoading As Boolean = True

    Private ObjIsRebinding As Boolean = True

    Private Sub F_F_Accounts_Closing(ByVal sender As Object, _
        ByVal e As FormClosingEventArgs) Handles Me.FormClosing

        If Not Obj Is Nothing AndAlso Obj.IsDirtyEnough Then
            Dim answ As String = Ask("Išsaugoti duomenis?", New ButtonStructure("Taip"), _
                New ButtonStructure("Ne"), New ButtonStructure("Atšaukti"))
            If answ <> "Taip" AndAlso answ <> "Ne" Then
                e.Cancel = True
                Exit Sub
            End If
            If answ = "Taip" Then
                If Not SaveObj() Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If

        GetDataGridViewLayOut(AccountListDataGridView)
        GetFormLayout(Me)

    End Sub

    Private Sub F_F_Accounts_Activated(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Activated

        If Me.WindowState = FormWindowState.Maximized AndAlso MyCustomSettings.AutoSizeForm Then _
            Me.WindowState = FormWindowState.Normal

        If IsLoading Then
            IsLoading = False
            Exit Sub
        End If

        If Not PrepareCache(Me, GetType(HelperLists.AssignableCRItemList)) Then Exit Sub

    End Sub

    Private Sub F_Accounts_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        Try

            Obj = LoadObject(Of General.AccountList)(Nothing, "GetAccountList", False)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti sąskaitų plano duomenų.", ex))
            DisableAllControls(Me)
            ObjIsRebinding = False
            Exit Sub
        End Try

        Obj.BeginEdit()
        AccountListBindingSource.DataSource = Obj

        Dim CM2 As New ContextMenu()
        Dim CMItem1 As New MenuItem("Overwrite", AddressOf PasteAccButton_Click)
        CM2.MenuItems.Add(CMItem1)
        Dim CMItem2 As New MenuItem("Informacija apie formatą", AddressOf PasteAccButton_Click)
        CM2.MenuItems.Add(CMItem2)
        PasteAccButton.ContextMenu = CM2

        OkButton.Enabled = General.AccountList.CanEditObject
        ApplyButton.Enabled = General.AccountList.CanEditObject
        TypicalButton.Visible = Not (Obj.Count > 0)

        SetDataGridViewLayOut(AccountListDataGridView)
        SetFormLayout(Me)
        ObjIsRebinding = False

    End Sub


    Private Sub OkButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles OkButton.Click
        If Not SaveObj() Then Exit Sub
        Me.Hide()
        Me.Close()
    End Sub

    Private Sub ApplyButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ApplyButton.Click
        SaveObj()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles CancelButton.Click
        CancelObj()
    End Sub


    Private Sub TypicalButton_Click(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles TypicalButton.Click

        If Not YesOrNo("Ar tikrai norite sukurti tipinę trumpą finansinės " & _
            "atskaitomybės struktūra ir sąskaitų planą?") Then Exit Sub

        Using bm As New BindingsManager(AccountListBindingSource, Nothing, Nothing, False, False)

            Try
                General.SetupTypicalAccountsCommand.TheCommand()
                If Not PrepareCache(Me, GetType(HelperLists.AssignableCRItemList)) Then Exit Sub
                Obj = LoadObject(Of General.AccountList)(Obj, "GetAccountList", False)
            Catch ex As Exception
                ShowError(ex)
                Exit Sub
            End Try

            Obj.BeginEdit()
            bm.SetNewDataSource(Obj)

        End Using

        MsgBox("Tipinė trumpa finansinės atskaitomybės struktūra ir sąskaitų planas sėkmingai sukurti.", _
            MsgBoxStyle.Information, "Info")

    End Sub

    Private Sub PasteAccButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles PasteAccButton.Click

        If Obj Is Nothing OrElse Not General.AccountList.CanEditObject Then Exit Sub

        If sender.Text.ToString.Trim.ToLower.Contains("informacija") Then
            MsgBox(General.Account.ColumnSequence, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If sender.Text.ToString.Trim.ToLower.Contains("overwrite") AndAlso Obj.Count > 0 AndAlso _
            Not YesOrNo("Ar tikrai norite perrašyti visą sąskaitų planą?") Then Exit Sub

        Try
            Using busy As New StatusBusy
                Dim associatedReportItems As String() = HelperLists.AssignableCRItemList.GetList.ToArray
                Obj.Paste(Clipboard.GetText, associatedReportItems, _
                    sender.Text.ToString.Trim.ToLower.Contains("overwrite"))
            End Using
        Catch ex As Exception
            ShowError(ex)
            Exit Sub
        End Try

    End Sub


    Public Function GetMailDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetMailDropDownItems
        Return Nothing
    End Function

    Public Function GetPrintDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintDropDownItems
        Return Nothing
    End Function

    Public Function GetPrintPreviewDropDownItems() As System.Windows.Forms.ToolStripDropDown _
        Implements ISupportsPrinting.GetPrintPreviewDropDownItems
        Return Nothing
    End Function

    Public Sub OnMailClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnMailClick
        If Obj Is Nothing Then Exit Sub

        Using frm As New F_SendObjToEmail(Obj, 0)
            frm.ShowDialog()
        End Using

    End Sub

    Public Sub OnPrintClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, False, 0)
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Sub OnPrintPreviewClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Implements ISupportsPrinting.OnPrintPreviewClick
        If Obj Is Nothing Then Exit Sub
        Try
            PrintObject(Obj, True, 0)
        Catch ex As Exception
            ShowError(ex)
        End Try
    End Sub

    Public Function SupportsEmailing() As Boolean _
        Implements ISupportsPrinting.SupportsEmailing
        Return True
    End Function


    Private Sub DataGridView_RowLeave(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles AccountListDataGridView.RowLeave

        Dim CurrentGrid As DataGridView
        Try
            CurrentGrid = DirectCast(sender, DataGridView)
        Catch ex As Exception
        End Try
        If CurrentGrid Is Nothing Then Exit Sub

        If CurrentGrid.Rows(e.RowIndex).IsNewRow AndAlso _
            e.RowIndex = CurrentGrid.Rows.Count - 1 Then CurrentGrid.CancelEdit()

    End Sub

    Private Sub DataGridView_DataError(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) _
        Handles AccountListDataGridView.DataError

        e.ThrowException = False
        e.Cancel = True

    End Sub


    Private Function SaveObj() As Boolean

        If Not Obj.IsDirty Then Return True

        If Not Obj.IsValid Then
            MsgBox("Formoje yra klaidų:" & vbCrLf & Obj.GetAllBrokenRules, MsgBoxStyle.Exclamation, "Klaida.")
            Return False
        End If

        Dim Question, Answer As String
        If Not String.IsNullOrEmpty(Obj.GetAllWarnings.Trim) Then
            Question = "DĖMESIO. Duomenyse gali būti klaidų: " & vbCrLf _
                & Obj.GetAllWarnings.Trim & vbCrLf
        Else
            Question = ""
        End If
        Question = Question & "Ar tikrai norite pakeisti duomenis?"
        Answer = "Duomenys sėkmingai pakeisti."

        If Not YesOrNo(Question) Then Return False

        Using bm As New BindingsManager(AccountListBindingSource, Nothing, Nothing, True, False)

            Obj.ApplyEdit()

            Try
                Obj = LoadObject(Of General.AccountList)(Obj, "Save", False)
            Catch ex As Exception
                ShowError(ex)
                Return False
            End Try

            Obj.BeginEdit()

            bm.SetNewDataSource(Obj)

        End Using

        MsgBox(Answer, MsgBoxStyle.Information, "Info")

        Return True

    End Function

    Private Sub CancelObj()
        If Obj Is Nothing Then Exit Sub
        Using bm As New BindingsManager(AccountListBindingSource, Nothing, Nothing, True, True)
            Obj.CancelEdit()
            Obj.BeginEdit()
        End Using
    End Sub


    Private Function SetDataSources() As Boolean

        If Not PrepareCache(Me, GetType(HelperLists.AssignableCRItemList)) Then Return False

        Try
            LoadAssignableCRItemListToCombo(DataGridViewTextBoxColumn3)
        Catch ex As Exception
            ShowError(ex)
            DisableAllControls(Me)
            Return False
        End Try

        Return True

    End Function

End Class