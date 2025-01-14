﻿Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.My.Resources

Namespace ActiveReports

    ''' <summary>
    ''' Represents a report containing aggregated general information about 
    ''' <see cref="Documents.InvoiceMade">InvoiceMade</see>,
    ''' <see cref="Documents.InvoiceReceived">InvoiceReceived</see>
    ''' and <see cref="Documents.ProformaInvoiceMade">ProformaInvoiceMade</see>.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public NotInheritable Class InvoiceInfoItemList
        Inherits ReadOnlyListBase(Of InvoiceInfoItemList, InvoiceInfoItem)

#Region " Business Methods "

        Private _InfoTypes As InvoiceInfoType() = Nothing
        Private _DateFrom As Date = Today
        Private _DateTo As Date = Today
        Private _Person As PersonInfo = Nothing


        ''' <summary>
        ''' Gets a <see cref="InvoiceInfoType">type of the invoices</see> (made or received)
        ''' within the report.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property InfoTypes() As InvoiceInfoType()
            Get
                Return _InfoTypes
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="InvoiceInfoType">type of the invoices</see> (made or received)
        ''' within the report as a human readable string.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property InfoTypesHumanReadable() As String
            Get
                If _InfoTypes Is Nothing OrElse _InfoTypes.Length < 1 Then Return ""
                Dim result As New List(Of String)
                For Each t As InvoiceInfoType In _InfoTypes
                    result.Add(Utilities.ConvertLocalizedName(t))
                Next
                Return String.Join(", ", result.ToArray())
            End Get
        End Property

        ''' <summary>
        ''' Gets a start date of the report period.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DateFrom() As Date
            Get
                Return _DateFrom
            End Get
        End Property

        ''' <summary>
        ''' Gets an end date of the report period.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DateTo() As Date
            Get
                Return _DateTo
            End Get
        End Property

        ''' <summary>
        ''' Gets a person that the report is filtered by.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Person() As PersonInfo
            Get
                Return _Person
            End Get
        End Property


        ''' <summary>
        ''' Exports the report to a ffdata file.
        ''' </summary>
        ''' <param name="fileName">A name and path of the file to create.</param>
        ''' <param name="declarationForm">An implementation of a concrete 
        ''' declaration version to use.</param>
        ''' <param name="warnings">Out param. Returnes non critical errors 
        ''' encountered when exporting data.</param>
        ''' <remarks></remarks>
        Public Sub SaveToFfData(ByVal fileName As String, _
            ByVal declarationForm As IInvoiceRegisterDeclaration, ByRef warnings As String)

            warnings = ""

            If Count < 1 Then
                Throw New Exception(My.Resources.ActiveReports_InvoiceInfoItemList_ListIsEmpty)
            End If

            If StringIsNullOrEmpty(fileName) Then
                Throw New Exception(My.Resources.ActiveReports_InvoiceInfoItemList_FileNameNull)
            End If

            If declarationForm Is Nothing Then
                Throw New Exception(My.Resources.ActiveReports_InvoiceInfoItemList_DeclarationFormNull)
            End If

            If Array.IndexOf(_InfoTypes, declarationForm.Type) < 0 OrElse _InfoTypes.Length > 1 Then
                Throw New Exception(My.Resources.ActiveReports_InvoiceInfoItemList_DeclarationFormInvalid)
            End If

            If _DateFrom.Date < declarationForm.ValidFrom.Date OrElse _
                _DateTo.Date > declarationForm.ValidTo.Date Then
                warnings = String.Format(My.Resources.ActiveReports_InvoiceInfoItemList_DeclarationFormDateInvalid, _
                    declarationForm.ValidFrom.ToString("yyyy-MM-dd"), _
                    declarationForm.ValidTo.ToString("yyyy-MM-dd"), _
                    _DateFrom.ToString("yyyy-MM-dd"), _DateTo.ToString("yyyy-MM-dd"))
            End If

            ' Set culture params that were used when parsing declaration's
            ' numbers and dates to string
            Dim oldCulture As Globalization.CultureInfo = _
                DirectCast(Threading.Thread.CurrentThread.CurrentCulture.Clone, Globalization.CultureInfo)

            Threading.Thread.CurrentThread.CurrentCulture = _
                New Globalization.CultureInfo("lt-LT", False)

            Dim ffDataFormatDataSet As DataSet = Nothing

            Try

                ffDataFormatDataSet = declarationForm.GetFfDataDataSet(Me)

                If ffDataFormatDataSet Is Nothing Then
                    Throw New Exception(My.Resources.ActiveReports_InvoiceInfoItemList_UnknownErrorWhileExporting)
                End If

            Catch ex As Exception

                If Not ffDataFormatDataSet Is Nothing Then
                    ffDataFormatDataSet.Dispose()
                End If

                Threading.Thread.CurrentThread.CurrentCulture = oldCulture

                Throw

            End Try

            Try

                Using ffDataFileStream As IO.FileStream = New IO.FileStream(fileName, IO.FileMode.Create)
                    ffDataFormatDataSet.WriteXml(ffDataFileStream)
                    ffDataFileStream.Close()
                End Using

            Catch ex As Exception

                If Not ffDataFormatDataSet Is Nothing Then
                    ffDataFormatDataSet.Dispose()
                End If

                Threading.Thread.CurrentThread.CurrentCulture = oldCulture

                Throw

            End Try

            ffDataFormatDataSet.Dispose()

            Threading.Thread.CurrentThread.CurrentCulture = oldCulture

        End Sub

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return CanGetObjectInvoiceMade() OrElse CanGetObjectInvoiceReceived() OrElse _
                CanGetObjectProformaInvoiceMade()
        End Function

        Public Shared Function CanGetObjectInvoiceMade() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.InvoiceMadeInfolist1")
        End Function

        Public Shared Function CanGetObjectInvoiceReceived() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.InvoiceReceivedInfolist1")
        End Function

        Public Shared Function CanGetObjectProformaInvoiceMade() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.ProformaInvoiceMadeInfolist1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of InvoiceInfoItem) = Nothing

        ''' <summary>
        ''' Gets a new instance of the InvoiceInfoItemList report.
        ''' </summary>
        ''' <param name="nInfoTypes">types of invoices to look for.</param>
        ''' <param name="nDateFrom">a start date of the report period</param>
        ''' <param name="nDateTo">an end date of the report period</param>
        ''' <param name="nPerson">a person to filter the report by</param>
        ''' <remarks></remarks>
        Public Shared Function GetList(ByVal nInfoTypes As InvoiceInfoType(), ByVal nDateFrom As Date, _
            ByVal nDateTo As Date, ByVal nPerson As PersonInfo) As InvoiceInfoItemList

            Dim result As InvoiceInfoItemList = DataPortal.Fetch(Of InvoiceInfoItemList) _
                (New Criteria(nInfoTypes, nDateFrom, nDateTo, nPerson))

            Return result

        End Function

        ''' <summary>
        ''' Gets a sortable view of the report.
        ''' </summary>
        ''' <remarks>Used to implement autosort in a datagridview.</remarks>
        Public Function GetSortedList() As Csla.SortedBindingList(Of InvoiceInfoItem)
            If _SortedList Is Nothing Then
                _SortedList = New Csla.SortedBindingList(Of InvoiceInfoItem)(Me)
            End If
            Return _SortedList
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private ReadOnly _InfoTypes As InvoiceInfoType()
            Private ReadOnly _DateFrom As Date
            Private ReadOnly _DateTo As Date
            Private ReadOnly _Person As PersonInfo
            Public ReadOnly Property InfoTypes() As InvoiceInfoType()
                Get
                    Return _InfoTypes
                End Get
            End Property
            Public ReadOnly Property DateFrom() As Date
                Get
                    Return _DateFrom
                End Get
            End Property
            Public ReadOnly Property DateTo() As Date
                Get
                    Return _DateTo
                End Get
            End Property
            Public ReadOnly Property Person() As PersonInfo
                Get
                    Return _Person
                End Get
            End Property
            Public Sub New(ByVal nInfoTypes As InvoiceInfoType(), ByVal nDateFrom As Date, _
                ByVal nDateTo As Date, ByVal nPerson As PersonInfo)
                _InfoTypes = nInfoTypes
                _DateFrom = nDateFrom
                _DateTo = nDateTo
                _Person = nPerson
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If criteria.InfoTypes Is Nothing OrElse criteria.InfoTypes.Length < 1 Then
                Throw New Exception(ActiveReports_InvoiceInfoItemList_InvoiceTypesNotSpecified)
            End If

            If Not Array.IndexOf(criteria.InfoTypes, InvoiceInfoType.InvoiceMade) < 0 Then
                FetchInvoicesMade(criteria)
            End If

            If Not Array.IndexOf(criteria.InfoTypes, InvoiceInfoType.InvoiceReceived) < 0 Then
                FetchInvoicesReceived(criteria)
            End If

            If Not Array.IndexOf(criteria.InfoTypes, InvoiceInfoType.ProformaInvoiceMade) < 0 Then
                FetchProformaInvoicesMade(criteria)
            End If

            _InfoTypes = criteria.InfoTypes
            _DateFrom = criteria.DateFrom.Date
            _DateTo = criteria.DateTo.Date
            _Person = criteria.Person

        End Sub

        Private Sub FetchInvoicesMade(ByVal criteria As Criteria)

            If Not CanGetObjectInvoiceMade() Then
                Throw New System.Security.SecurityException(My.Resources.Common_SecuritySelectDenied)
            End If

            Dim myComm As New SQLCommand("FetchInvoiceInfoItemListForInvoiceMade")
            AddWithParams(myComm, criteria)

            Using myData As DataTable = myComm.Fetch

                myComm = New SQLCommand("FetchInvoiceSubtotalListForInvoiceMade")
                AddWithParams(myComm, criteria)

                Using subtotalsData As DataTable = myComm.Fetch()

                    AddItems(myData, InvoiceInfoType.InvoiceMade, subtotalsData)

                End Using

            End Using

        End Sub

        Private Sub FetchInvoicesReceived(ByVal criteria As Criteria)

            If Not CanGetObjectInvoiceReceived() Then
                Throw New System.Security.SecurityException(My.Resources.Common_SecuritySelectDenied)
            End If

            Dim myComm As New SQLCommand("FetchInvoiceInfoItemListForInvoiceReceived")
            AddWithParams(myComm, criteria)

            Using myData As DataTable = myComm.Fetch

                myComm = New SQLCommand("FetchInvoiceSubtotalListForInvoiceReceived")
                AddWithParams(myComm, criteria)

                Using subtotalsData As DataTable = myComm.Fetch()

                    AddItems(myData, InvoiceInfoType.InvoiceReceived, subtotalsData)

                End Using

            End Using

        End Sub

        Private Sub FetchProformaInvoicesMade(ByVal criteria As Criteria)

            If Not CanGetObjectProformaInvoiceMade() Then
                Throw New System.Security.SecurityException(My.Resources.Common_SecuritySelectDenied)
            End If

            Dim myComm As New SQLCommand("FetchInvoiceInfoItemListForProformaInvoiceMade")
            AddWithParams(myComm, criteria)

            Using myData As DataTable = myComm.Fetch

                AddItems(myData, InvoiceInfoType.ProformaInvoiceMade, Nothing)

            End Using

        End Sub

        Private Sub AddWithParams(ByVal myComm As SQLCommand, ByVal criteria As Criteria)

            myComm.AddParam("?DF", criteria.DateFrom.Date)
            myComm.AddParam("?DT", criteria.DateTo.Date)
            If Not criteria.Person Is Nothing AndAlso Not criteria.Person.IsEmpty Then
                myComm.AddParam("?PD", criteria.Person.ID)
            Else
                myComm.AddParam("?PD", 0)
            End If

        End Sub

        Private Sub AddItems(ByVal myData As DataTable, ByVal itemType As InvoiceInfoType, _
            ByVal subtotalsData As DataTable)

            RaiseListChangedEvents = False
            IsReadOnly = False

            For Each dr As DataRow In myData.Rows
                Add(InvoiceInfoItem.GetInvoiceInfoItem(dr, itemType, subtotalsData))
            Next

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace