﻿Imports ApskaitaObjects.Documents.InvoiceAdapters
Namespace Documents

    ''' <summary>
    ''' Represents a collection of lines (items) within an <see cref="InvoiceMade">invoice made</see>.
    ''' </summary>
    ''' <remarks>Should only be used as a child of a <see cref="InvoiceMade">InvoiceMade</see>.
    ''' Values are stored in the database table sfd.</remarks>
    <Serializable()> _
    Public NotInheritable Class InvoiceMadeItemList
        Inherits BusinessListBase(Of InvoiceMadeItemList, InvoiceMadeItem)

#Region " Business Methods "

        Private _CopyInProgress As Boolean = False
        Private _LanguageCode As String = LanguageCodeLith.Trim.ToUpper
        Private _CurrencyRate As Double = 1
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency


        ''' <summary>
        ''' Proxy to the <see cref="InvoiceMade.LanguageCode">parent invoice LanguageCode property.</see>
        ''' </summary>
        ''' <remarks>Used to pass parent invoice data to child items without creating circular reference.</remarks>
        Friend ReadOnly Property LanguageCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LanguageCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Proxy to the <see cref="InvoiceMade.CurrencyRate">parent invoice CurrencyRate property.</see>
        ''' </summary>
        ''' <remarks>Used to pass parent invoice data to child items without creating circular reference.</remarks>
        Friend ReadOnly Property CurrencyRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRate, ROUNDCURRENCYRATE)
            End Get
        End Property

        ''' <summary>
        ''' Proxy to the <see cref="InvoiceMade.CurrencyCode">parent invoice CurrencyCode property.</see>
        ''' </summary>
        ''' <remarks>Used to pass parent invoice data to child items without creating circular reference.</remarks>
        Friend ReadOnly Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
        End Property


        ''' <summary>
        ''' Updates items within the collection with a new language code.
        ''' </summary>
        ''' <param name="newLanguageCode">A new language code of the parent invoice.</param>
        ''' <remarks></remarks>
        Friend Sub UpdateLanguage(ByVal newLanguageCode As String)

            If newLanguageCode Is Nothing Then newLanguageCode = ""

            _LanguageCode = newLanguageCode

            RaiseListChangedEvents = False

            For Each o As InvoiceMadeItem In Me
                o.UpdateLanguage()
            Next

            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub

        ''' <summary>
        ''' Updates items within the collection with a new currency data.
        ''' </summary>
        ''' <param name="newCurrencyRate">A new currency rate of the parent invoice.</param>
        ''' <param name="newCurrencyCode">A new currency code of the parent invoice.</param>
        ''' <remarks></remarks>
        Friend Sub UpdateCurrencyRate(ByVal newCurrencyRate As Double, ByVal newCurrencyCode As String)

            RaiseListChangedEvents = False

            _CurrencyRate = newCurrencyRate
            _CurrencyCode = newCurrencyCode

            For Each o As InvoiceMadeItem In Me
                o.UpdateCurrencyRate(newCurrencyRate, newCurrencyCode)
            Next

            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub

        ''' <summary>
        ''' Updates items within the collection with a new invoice date.
        ''' </summary>
        ''' <param name="newDate">A new date of the parent invoice.</param>
        ''' <remarks>Only affects items with an attached operation.</remarks>
        Friend Sub UpdateDate(ByVal newDate As Date)

            RaiseListChangedEvents = False

            For Each o As InvoiceMadeItem In Me
                o.SetAttachedObjectInvoiceDate(newDate)
            Next

            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub

        ''' <summary>
        ''' Checks whether a new IInvoiceAdapter, that the user is trying to add,
        ''' is compatible with the existing ones. Throws an exception if not.
        ''' </summary>
        ''' <param name="newAdapter">a new IInvoiceAdapter, that the user is trying to add</param>
        ''' <remarks></remarks>
        Friend Sub CheckIfNewAdapterCompatibleWithTheExistingAdapters(ByVal newAdapter As IInvoiceAdapter)

            If newAdapter Is Nothing Then Exit Sub

            For Each i As InvoiceMadeItem In Me
                If Not i.AttachedObjectValue Is Nothing Then
                    InvoiceAdapterFactory.AdaptersCompatible(newAdapter, _
                        i.AttachedObjectValue, "", True)
                End If
            Next

        End Sub


        Friend Sub MarkAsCopy()

            RaiseListChangedEvents = False

            _CopyInProgress = True

            Me.AllowNew = True
            Me.AllowRemove = True

            For i As Integer = Me.Count To 1 Step -1
                If Not Me.Item(i - 1).CanBeCopied Then
                    Me.RemoveAt(i - 1)
                Else
                    Me.Item(i - 1).MarkAsCopy()
                End If
            Next
            Me.DeletedList.Clear()

            _CopyInProgress = False

            RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub


        ''' <summary>
        ''' Gets collection data as a data transfer object.
        ''' </summary>
        ''' <remarks>Used to implement data exchange with other applications.</remarks>
        Friend Function GetInvoiceItemInfoList() As List(Of InvoiceInfo.InvoiceItemInfo)

            Dim result As New List(Of InvoiceInfo.InvoiceItemInfo)

            For Each i As InvoiceMadeItem In Me
                result.Add(i.GetInvoiceItemInfo())
            Next

            Return result

        End Function

        ''' <summary>
        ''' Gets a collection of <see cref="IChronologicValidator">IChronologicValidator</see>
        ''' contained within the attached operations.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Function GetChronologyValidators() As IChronologicValidator()

            Dim result As New List(Of IChronologicValidator)
            For Each i As InvoiceMadeItem In Me
                If Not i.AttachedObjectValue Is Nothing Then
                    result.Add(i.AttachedObjectValue.ChronologyValidator)
                End If
            Next
            Return result.ToArray

        End Function


        Protected Overrides Function AddNewCore() As Object
            Dim newItem As InvoiceMadeItem = InvoiceMadeItem.NewInvoiceMadeItem()
            Me.Add(newItem)
            newItem.UpdateLanguage() ' to triger language related validation
            Return newItem
        End Function

        Protected Overrides Sub RemoveItem(ByVal index As Integer)

            If Not _CopyInProgress Then


                If index < 0 OrElse index >= Me.Count Then

                    Throw New IndexOutOfRangeException(String.Format(My.Resources.Common_IndexOutOfRange, _
                        index.ToString, Me.Count.ToString))

                End If

                If Not Me.Item(index).AttachedObjectValue Is Nothing AndAlso _
                   Not Me.Item(index).AttachedObjectValue.ChronologyValidator.FinancialDataCanChange Then

                    Throw New Exception(String.Format(My.Resources.Documents_InvoiceMadeItem_InvalidItemDelete, _
                        Me.Item(index).ToString(), vbCrLf, Me.Item(index).AttachedObjectValue.ChronologyValidator.FinancialDataCanChangeExplanation))

                End If

            End If

            MyBase.RemoveItem(index)

        End Sub


        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            Return result
        End Function

        Public Function HasWarnings() As Boolean
            For Each i As InvoiceMadeItem In Me
                If i.HasWarnings() Then Return True
            Next
            Return False
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewInvoiceMadeItemList(ByVal parentInvoice As InvoiceMade) As InvoiceMadeItemList
            Return New InvoiceMadeItemList(parentInvoice)
        End Function

        Friend Shared Function NewInvoiceMadeItemList(ByVal info As InvoiceInfo.InvoiceInfo, _
            ByVal parentInvoice As InvoiceMade, ByVal accountList As AccountInfoList, _
            ByVal vatSchemaList As VatDeclarationSchemaInfoList, serviceList As ServiceInfoList) As InvoiceMadeItemList
            Return New InvoiceMadeItemList(info, parentInvoice, accountList, vatSchemaList, serviceList)
        End Function

        Friend Shared Function NewInvoiceMadeItemList(ByVal proformaList As ProformaInvoiceMadeItemList, _
            ByVal parentInvoice As InvoiceMade, ByVal baseChronologyValidator As SimpleChronologicValidator) As InvoiceMadeItemList
            Return New InvoiceMadeItemList(proformaList, parentInvoice, baseChronologyValidator)
        End Function

        Friend Shared Function GetInvoiceMadeItemList(ByVal parentInvoice As InvoiceMade, _
            ByVal baseChronologyValidator As SimpleChronologicValidator) As InvoiceMadeItemList
            Return New InvoiceMadeItemList(parentInvoice, baseChronologyValidator)
        End Function

        Friend Shared Function DoomyInvoiceMadeItemList(ByVal r As Random, ByVal parentInvoice As InvoiceMade) As InvoiceMadeItemList
            Return New InvoiceMadeItemList(r, parentInvoice)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal parentInvoice As InvoiceMade)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Create(parentInvoice)
        End Sub

        Private Sub New(ByVal proformaList As ProformaInvoiceMadeItemList, _
            ByVal parentInvoice As InvoiceMade, ByVal baseChronologyValidator As SimpleChronologicValidator)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Create(proformaList, parentInvoice, baseChronologyValidator)
        End Sub

        Private Sub New(ByVal info As InvoiceInfo.InvoiceInfo, ByVal parentInvoice As InvoiceMade, _
            ByVal accountList As AccountInfoList, ByVal vatSchemaList As VatDeclarationSchemaInfoList, _
            serviceList As ServiceInfoList)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Create(info, parentInvoice, accountList, vatSchemaList, serviceList)
        End Sub

        Private Sub New(ByVal r As Random, ByVal parentInvoice As InvoiceMade)
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Create(r, parentInvoice)
        End Sub

        Private Sub New(ByVal parentInvoice As InvoiceMade, _
            ByVal baseChronologyValidator As SimpleChronologicValidator)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = baseChronologyValidator.FinancialDataCanChange
            Me.AllowRemove = baseChronologyValidator.FinancialDataCanChange
            Fetch(parentInvoice, baseChronologyValidator)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal parentInvoice As InvoiceMade)

            RaiseListChangedEvents = False

            Me._CurrencyCode = parentInvoice.CurrencyCode
            Me._CurrencyRate = parentInvoice.CurrencyRate
            Me._LanguageCode = parentInvoice.LanguageCode

            RaiseListChangedEvents = True

        End Sub

        Private Sub Create(ByVal info As InvoiceInfo.InvoiceInfo, ByVal parentInvoice As InvoiceMade, _
            ByVal accountList As AccountInfoList, ByVal vatSchemaList As VatDeclarationSchemaInfoList, _
            serviceList As ServiceInfoList)

            RaiseListChangedEvents = False

            Me._CurrencyCode = parentInvoice.CurrencyCode
            Me._CurrencyRate = parentInvoice.CurrencyRate
            Me._LanguageCode = parentInvoice.LanguageCode

            If Not info Is Nothing Then

                For Each i As InvoiceInfo.InvoiceItemInfo In info.InvoiceItems
                    Add(InvoiceMadeItem.NewInvoiceMadeItem(i, parentInvoice.CurrencyRate, _
                        accountList, vatSchemaList, serviceList))
                Next

            End If

            RaiseListChangedEvents = True

        End Sub

        Private Sub Create(ByVal proformaList As ProformaInvoiceMadeItemList, _
            ByVal parentInvoice As InvoiceMade, ByVal baseChronologyValidator As SimpleChronologicValidator)

            RaiseListChangedEvents = False

            Me._CurrencyCode = parentInvoice.CurrencyCode
            Me._CurrencyRate = parentInvoice.CurrencyRate
            Me._LanguageCode = parentInvoice.LanguageCode

            For Each i As ProformaInvoiceMadeItem In proformaList
                Dim newItem As InvoiceMadeItem = InvoiceMadeItem.NewInvoiceMadeItem(i, _
                    baseChronologyValidator, IsBaseCurrency(Me._CurrencyCode, GetCurrentCompany.BaseCurrency))
                Me.Add(newItem)
                newItem.UpdateLanguage() ' to triger language related validation
            Next

            RaiseListChangedEvents = True

        End Sub

        Private Sub Create(ByVal r As Random, ByVal parentInvoice As InvoiceMade)

            Me.RaiseListChangedEvents = False

            _CurrencyCode = parentInvoice.CurrencyCode
            _CurrencyRate = parentInvoice.CurrencyRate
            _LanguageCode = parentInvoice.LanguageCode

            Dim lineCount As Integer = r.Next(5, 16)
            For i As Integer = 1 To lineCount
                Me.Add(InvoiceMadeItem.DoomyInvoiceMadeItem(r))
            Next

            Me.RaiseListChangedEvents = True

        End Sub

        Friend Sub AddWithNewItems(ByVal info As InvoiceInfo.InvoiceInfo, ByVal parentInvoice As InvoiceMade, _
            ByVal accountList As AccountInfoList, ByVal vatSchemaList As VatDeclarationSchemaInfoList, _
            serviceList As ServiceInfoList)

            RaiseListChangedEvents = False

            Me.Clear()

            Me._CurrencyCode = parentInvoice.CurrencyCode
            Me._CurrencyRate = parentInvoice.CurrencyRate
            Me._LanguageCode = parentInvoice.LanguageCode

            If Not info Is Nothing Then

                For Each i As InvoiceInfo.InvoiceItemInfo In info.InvoiceItems
                    Add(InvoiceMadeItem.NewInvoiceMadeItem(i, parentInvoice.CurrencyRate, _
                        accountList, vatSchemaList, serviceList))
                Next

            End If

            RaiseListChangedEvents = True

        End Sub


        Private Sub Fetch(ByVal parentInvoice As InvoiceMade, _
            ByVal baseChronologyValidator As SimpleChronologicValidator)

            Dim myComm As New SQLCommand("FetchInvoiceMadeItemList")
            myComm.AddParam("?MD", parentInvoice.ID)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                _LanguageCode = parentInvoice.LanguageCode
                _CurrencyRate = parentInvoice.CurrencyRate
                _CurrencyCode = parentInvoice.CurrencyCode

                For Each dr As DataRow In myData.Rows
                    Add(InvoiceMadeItem.GetInvoiceMadeItem(dr, parentInvoice.CurrencyRate, baseChronologyValidator))
                Next

                RaiseListChangedEvents = True

            End Using

        End Sub


        Friend Sub Update(ByVal parent As InvoiceMade)

            RaiseListChangedEvents = False

            For Each item As InvoiceMadeItem In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As InvoiceMadeItem In Me
                If item.IsNew Then
                    item.Insert(parent)
                ElseIf item.IsDirty Then
                    item.Update(parent)
                End If
            Next

            RaiseListChangedEvents = True

        End Sub


        Friend Sub CheckIfCanUpdate(ByVal parentInvoice As InvoiceMade)

            For Each item As InvoiceMadeItem In DeletedList
                If Not item.IsNew Then
                    item.CheckIfCanDelete(parentInvoice.ChronologyValidator.BaseValidator)
                End If
            Next

            For Each item As InvoiceMadeItem In Me
                item.SetParentData(parentInvoice)
                If item.IsDirty Then
                    item.CheckIfCanUpdate(parentInvoice.ChronologyValidator.BaseValidator)
                End If
            Next

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

        End Sub

#End Region

    End Class

End Namespace