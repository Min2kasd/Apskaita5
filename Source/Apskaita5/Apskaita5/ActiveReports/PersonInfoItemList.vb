﻿Namespace ActiveReports

    ''' <summary>
    ''' Represents a person report. Contains information about persons that the company operates with (clients, suppliers, workers, etc.).
    ''' </summary>
    ''' <remarks>Values are stored in the database table asmenys.</remarks>
    <Serializable()> _
Public NotInheritable Class PersonInfoItemList
        Inherits ReadOnlyListBase(Of PersonInfoItemList, PersonInfoItem)

#Region " Business Methods "

        Private _ShowClients As Boolean = True
        Private _ShowSuppliers As Boolean = True
        Private _ShowWorkers As Boolean = True
        Private _LikeString As String = ""


        ''' <summary>
        ''' Whether the report includes clients.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ShowClients() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ShowClients
            End Get
        End Property

        ''' <summary>
        ''' Whether the report includes suppliers.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ShowSuppliers() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ShowSuppliers
            End Get
        End Property

        ''' <summary>
        ''' Whether the report includes workers.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ShowWorkers() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ShowWorkers
            End Get
        End Property

        ''' <summary>
        ''' Search string (to search in name).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property LikeString() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LikeString.Trim
            End Get
        End Property

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.PersonInfoItemList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement sorting in gridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of PersonInfoItem) = Nothing

        ''' <summary>
        ''' Gets a new instance of the person report.
        ''' </summary>
        ''' <param name="nShowClients">Whether the report includes clients.</param>
        ''' <param name="nShowSuppliers">Whether the report includes suppliers.</param>
        ''' <param name="nShowWorkers">Whether the report includes workers.</param>
        ''' <param name="nLikeString">Search string (to search in name).</param>
        ''' <remarks></remarks>
        Public Shared Function GetList(ByVal nShowClients As Boolean, _
            ByVal nShowSuppliers As Boolean, ByVal nShowWorkers As Boolean, _
            ByVal nLikeString As String) As PersonInfoItemList

            Return DataPortal.Fetch(Of PersonInfoItemList)(New Criteria(nShowClients, _
                nShowSuppliers, nShowWorkers, nLikeString))

        End Function

        ''' <summary>
        ''' Gets a sortable view of the report.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a datagridview.</remarks>
        Public Function GetSortedList() As Csla.SortedBindingList(Of PersonInfoItem)

            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of PersonInfoItem)(Me)

            Return _SortedList

        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ShowClients As Boolean
            Private _ShowSuppliers As Boolean
            Private _ShowWorkers As Boolean
            Private _LikeString As String
            Public ReadOnly Property ShowClients() As Boolean
                Get
                    Return _ShowClients
                End Get
            End Property
            Public ReadOnly Property ShowSuppliers() As Boolean
                Get
                    Return _ShowSuppliers
                End Get
            End Property
            Public ReadOnly Property ShowWorkers() As Boolean
                Get
                    Return _ShowWorkers
                End Get
            End Property
            Public ReadOnly Property LikeString() As String
                Get
                    Return _LikeString.Trim
                End Get
            End Property
            Public Sub New(ByVal nShowClients As Boolean, ByVal nShowSuppliers As Boolean, _
                ByVal nShowWorkers As Boolean, ByVal nLikeString As String)
                _ShowClients = nShowClients
                _ShowSuppliers = nShowSuppliers
                _ShowWorkers = nShowWorkers
                _LikeString = nLikeString
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchPersonInfoItemList")
            myComm.AddParam("?IC", ConvertDbBoolean(criteria.ShowClients))
            myComm.AddParam("?IP", ConvertDbBoolean(criteria.ShowSuppliers))
            myComm.AddParam("?IW", ConvertDbBoolean(criteria.ShowWorkers))
            Dim curWildCard As String = GetWildcart()
            If criteria.LikeString Is Nothing OrElse String.IsNullOrEmpty(criteria.LikeString.Trim) Then
                _LikeString = curWildCard
            ElseIf criteria.LikeString.Contains(curWildCard) Then
                _LikeString = criteria.LikeString.Trim
            Else
                _LikeString = curWildCard & criteria.LikeString.Trim & curWildCard
            End If
            myComm.AddParam("?LS", _LikeString)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(PersonInfoItem.GetPersonInfoItem(dr))
                Next

                _ShowClients = criteria.ShowClients
                _ShowSuppliers = criteria.ShowSuppliers
                _ShowWorkers = criteria.ShowWorkers

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace