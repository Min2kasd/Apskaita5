﻿Imports ApskaitaObjects.Assets

Namespace ActiveReports

    ''' <summary>
    ''' Represents a report that contains information about long term asset complex documents,
    ''' e.g. <see cref="Assets.ComplexOperationDiscard">ComplexOperationDiscard</see>.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public NotInheritable Class LongTermAssetComplexDocumentInfoList
        Inherits ReadOnlyListBase(Of LongTermAssetComplexDocumentInfoList, LongTermAssetComplexDocumentInfo)

#Region " Business Methods "

        Private _DateFrom As Date = Today
        Private _DateTo As Date = Today

        ''' <summary>
        ''' The start of the report period.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DateFrom() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateFrom.Date
            End Get
        End Property

        ''' <summary>
        ''' The end of the report period.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DateTo() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateTo.Date
            End Get
        End Property

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Assets.LongTermAssetOperationInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of LongTermAssetComplexDocumentInfo) = Nothing

        ''' <summary>
        ''' Gets a new instance of LongTermAssetComplexDocumentInfoList report.
        ''' </summary>
        ''' <param name="dateFrom">The start of the report period.</param>
        ''' <param name="dateTo">The end of the report period.</param>
        ''' <remarks></remarks>
        Public Shared Function GetLongTermAssetComplexDocumentInfoList( _
            ByVal dateFrom As Date, ByVal dateTo As Date) As LongTermAssetComplexDocumentInfoList
            Return DataPortal.Fetch(Of LongTermAssetComplexDocumentInfoList) _
                (New Criteria(dateFrom, dateTo))
        End Function

        ''' <summary>
        ''' Gets a sortable view of the report.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a datagridview.</remarks>
        Public Function GetSortedList() As Csla.SortedBindingList(Of LongTermAssetComplexDocumentInfo)
            If _SortedList Is Nothing Then _SortedList = _
                New Csla.SortedBindingList(Of LongTermAssetComplexDocumentInfo)(Me)
            Return _SortedList
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _DateFrom As Date
            Private _DateTo As Date
            Public ReadOnly Property DateFrom() As Date
                Get
                    Return _DateFrom.Date
                End Get
            End Property
            Public ReadOnly Property DateTo() As Date
                Get
                    Return _DateTo.Date
                End Get
            End Property
            Public Sub New(ByVal nDateFrom As Date, ByVal nDateTo As Date)
                _DateFrom = nDateFrom.Date
                _DateTo = nDateTo.Date
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchLongTermAssetComplexDocumentInfoList")
            myComm.AddParam("?DF", criteria.DateFrom.Date)
            myComm.AddParam("?DT", criteria.DateTo.Date)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(LongTermAssetComplexDocumentInfo.GetLongTermAssetComplexDocumentInfo(dr))
                Next

                _DateFrom = criteria.DateFrom.Date
                _DateTo = criteria.DateTo.Date

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace