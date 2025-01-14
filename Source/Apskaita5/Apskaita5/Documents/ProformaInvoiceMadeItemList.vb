﻿Namespace Documents

    ''' <summary>
    ''' Represents a collection of lines (items) within a <see cref="ProformaInvoiceMade">proforma invoice made</see>.
    ''' </summary>
    ''' <remarks>Should only be used as a child of a <see cref="ProformaInvoiceMade">ProformaInvoiceMade</see>.
    ''' Values are stored in the database table ProformaInvoiceMadeItems.</remarks>
    <Serializable()> _
    Public NotInheritable Class ProformaInvoiceMadeItemList
        Inherits BusinessListBase(Of ProformaInvoiceMadeItemList, ProformaInvoiceMadeItem)

#Region " Business Methods "

        Private _LanguageCode As String = LanguageCodeLith.Trim.ToUpper


        ''' <summary>
        ''' Proxy to the <see cref="ProformaInvoiceMade.LanguageCode">parent invoice LanguageCode property.</see>
        ''' </summary>
        ''' <remarks>Used to pass parent invoice data to child items without creating circular reference.</remarks>
        Friend Property LanguageCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageCode.Trim
            End Get
            Set(ByVal value As String)

                If value Is Nothing Then value = ""

                If value.Trim.ToUpper() <> _LanguageCode.Trim.ToUpper() Then

                    _LanguageCode = value

                    RaiseListChangedEvents = False

                    For Each o As ProformaInvoiceMadeItem In Me
                        o.LanguageCode = value
                    Next

                    RaiseListChangedEvents = True

                    Me.ResetBindings()

                End If

            End Set
        End Property


        Friend Sub MarkAsCopy()

            RaiseListChangedEvents = False

            For Each i As ProformaInvoiceMadeItem In Me
                i.MarkAsCopy()
            Next

            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub


        ''' <summary>
        ''' Gets collection data as a data transfer object.
        ''' </summary>
        ''' <remarks>Used to implement data exchange with other applications.</remarks>
        Friend Function GetInvoiceItemInfoList() As List(Of InvoiceInfo.InvoiceItemInfo)

            Dim result As New List(Of InvoiceInfo.InvoiceItemInfo)

            For Each i As ProformaInvoiceMadeItem In Me
                result.Add(i.GetInvoiceItemInfo())
            Next

            Return result

        End Function


        Protected Overrides Function AddNewCore() As Object
            Dim newItem As ProformaInvoiceMadeItem = ProformaInvoiceMadeItem.NewProformaInvoiceMadeItem(_LanguageCode)
            Me.Add(newItem)
            Return newItem
        End Function


        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            Return result
        End Function

        Public Function HasWarnings() As Boolean
            For Each i As ProformaInvoiceMadeItem In Me
                If i.HasWarnings() Then Return True
            Next
            Return False
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewProformaInvoiceMadeItemList(ByVal parentInvoice As ProformaInvoiceMade) As ProformaInvoiceMadeItemList
            Return New ProformaInvoiceMadeItemList(parentInvoice)
        End Function

        Friend Shared Function NewProformaInvoiceMadeItemList(ByVal info As InvoiceInfo.InvoiceInfo) As ProformaInvoiceMadeItemList
            Return New ProformaInvoiceMadeItemList(info)
        End Function

        Friend Shared Function GetInvoiceMadeItemList(ByVal parentInvoice As ProformaInvoiceMade) As ProformaInvoiceMadeItemList
            Return New ProformaInvoiceMadeItemList(parentInvoice)
        End Function

        Friend Shared Function DoomyProformaInvoiceMadeItemList(ByVal r As Random, _
            ByVal parentInvoice As ProformaInvoiceMade) As ProformaInvoiceMadeItemList
            Return New ProformaInvoiceMadeItemList(r)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal parentInvoice As ProformaInvoiceMade)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            If parentInvoice.ID > 0 Then
                Fetch(parentInvoice)
            Else
                Create(parentInvoice)
            End If
        End Sub

        Private Sub New(ByVal info As InvoiceInfo.InvoiceInfo)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Create(info)
        End Sub

        Private Sub New(ByVal r As Random)
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Create(r)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal parentInvoice As ProformaInvoiceMade)

            RaiseListChangedEvents = False

            _LanguageCode = parentInvoice.LanguageCode

            RaiseListChangedEvents = True

        End Sub

        Private Sub Create(ByVal info As InvoiceInfo.InvoiceInfo)

            RaiseListChangedEvents = False

            _LanguageCode = info.LanguageCode

            If Not info Is Nothing Then

                For Each i As InvoiceInfo.InvoiceItemInfo In info.InvoiceItems
                    Add(ProformaInvoiceMadeItem.NewProformaInvoiceMadeItem(info.LanguageCode, i))
                Next

            End If

            RaiseListChangedEvents = True

        End Sub

        Private Sub Create(ByVal r As Random)

            Me.RaiseListChangedEvents = False

            _LanguageCode = My.Resources.Documents_ProformaInvoiceMade_DoomyInvoiceLanguage

            Dim lineCount As Integer = r.Next(5, 16)
            For i As Integer = 1 To lineCount
                Me.Add(ProformaInvoiceMadeItem.DoomyProformaInvoiceMadeItem(r))
            Next

            Me.RaiseListChangedEvents = True

        End Sub

        Friend Sub AddWithNewItems(ByVal info As InvoiceInfo.InvoiceInfo, ByVal parentInvoice As ProformaInvoiceMade)

            RaiseListChangedEvents = False

            Me.Clear()

            _LanguageCode = parentInvoice.LanguageCode

            If Not info Is Nothing Then

                For Each i As InvoiceInfo.InvoiceItemInfo In info.InvoiceItems
                    Add(ProformaInvoiceMadeItem.NewProformaInvoiceMadeItem(parentInvoice.LanguageCode, i))
                Next

            End If

            RaiseListChangedEvents = True

        End Sub


        Private Sub Fetch(ByVal parentInvoice As ProformaInvoiceMade)

            Dim myComm As New SQLCommand("FetchProformaInvoiceMadeItems")
            myComm.AddParam("?PD", parentInvoice.ID)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                _LanguageCode = parentInvoice.LanguageCode

                For Each dr As DataRow In myData.Rows
                    Add(ProformaInvoiceMadeItem.GetProformaInvoiceMadeItem(parentInvoice.LanguageCode, dr))
                Next

                RaiseListChangedEvents = True

            End Using

        End Sub

        Friend Sub Update(ByVal parent As ProformaInvoiceMade)

            RaiseListChangedEvents = False

            For Each item As ProformaInvoiceMadeItem In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As ProformaInvoiceMadeItem In Me
                If item.IsNew Then
                    item.Insert(parent)
                ElseIf item.IsDirty Then
                    item.Update(parent)
                End If
            Next

            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace