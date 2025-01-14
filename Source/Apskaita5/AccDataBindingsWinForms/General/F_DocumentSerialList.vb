﻿Imports ApskaitaObjects.Settings
Imports AccControlsWinForms

Friend Class F_DocumentSerialList
    Implements ISingleInstanceForm

    Private _FormManager As CslaActionExtenderEditForm(Of DocumentSerialList)
    Private _ListViewManager As DataListViewEditControlManager(Of DocumentSerial)
    Private _QueryManager As CslaActionExtenderQueryObject


    Private Sub F_DocumentSerialList_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load

        If Not SetDataSources() Then Exit Sub

        Try

            _QueryManager = New CslaActionExtenderQueryObject(Me, ProgressFiller2)

            ' DocumentSerialList.GetDocumentSerialList()
            _QueryManager.InvokeQuery(Of DocumentSerialList)(Nothing, "GetDocumentSerialList",
                True, AddressOf OnDataSourceLoaded)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti dokumentų serijų duomenų.", ex), Nothing)
            DisableAllControls(Me)
        End Try

    End Sub

    Private Function SetDataSources() As Boolean

        Try

            _ListViewManager = New DataListViewEditControlManager(Of DocumentSerial) _
                (DocumentSerialListDataListView, Nothing, AddressOf DeleteItems, _
                 AddressOf AddNewSerial, Nothing, Nothing)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti dokumentų serijų duomenų.", ex), Nothing)
            DisableAllControls(Me)
            Return False
        End Try

        IOkButton.Enabled = DocumentSerialList.CanEditObject
        IApplyButton.Enabled = DocumentSerialList.CanEditObject

        Return True

    End Function

    Private Sub OnDataSourceLoaded(ByVal source As Object, ByVal exceptionHandled As Boolean)

        If exceptionHandled Then

            DisableAllControls(Me)
            Exit Sub

        ElseIf source Is Nothing Then

            ShowError(New Exception("Klaida. Nepavyko gauti dokumentų serijų duomenų."), Nothing)
            DisableAllControls(Me)
            Exit Sub

        End If

        Try

            _FormManager = New CslaActionExtenderEditForm(Of DocumentSerialList) _
                (Me, DocumentSerialListBindingSource, DirectCast(source, DocumentSerialList), _
                 Nothing, IOkButton, IApplyButton, ICancelButton, Nothing, ProgressFiller1)

            _FormManager.ManageDataListViewStates(DocumentSerialListDataListView)

        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko gauti dokumentų serijų duomenų.", ex), Nothing)
            DisableAllControls(Me)
            Exit Sub
        End Try

    End Sub


    Private Sub DeleteItems(ByVal items As DocumentSerial())
        If items Is Nothing OrElse items.Length < 1 Then Exit Sub

        For Each item As DocumentSerial In items
            If item.WasUsed Then
                MsgBox(String.Format("Klaida. Dokumento {0} serija {1} buvo naudojama registruojant dokumentus. Jos pašalinti neleidžiama.", _
                item.DocumentTypeHumanReadable, item.SerialOld), MsgBoxStyle.Exclamation, "Klaida")
                Exit Sub
            End If
        Next

        For Each item As DocumentSerial In items
            _FormManager.DataSource.Remove(item)
        Next

    End Sub

    Private Sub AddNewSerial()
        _FormManager.DataSource.AddNew()
    End Sub


    Private Sub DocumentSerialListDataListView_CellEditStarting(ByVal sender As Object, _
        ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles DocumentSerialListDataListView.CellEditStarting

        If e.RowObject Is Nothing OrElse DirectCast(e.RowObject, DocumentSerial).WasUsed Then
            e.Cancel = True
        End If

    End Sub

End Class