﻿Imports ApskaitaObjects.My.Resources

Namespace ActiveReports

    ''' <summary>
    ''' Represents a goods operation report, contains information about goods turnover
    ''' and operations for the given goods within the report period and subject
    ''' to the report filters.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsOperationInfoListParent
        Inherits ReadOnlyBase(Of GoodsOperationInfoListParent)

#Region " Business Methods "

        Private _GoodsTurnoverInfo As GoodsTurnoverInfo = Nothing
        Private _DateFrom As Date = Today
        Private _DateTo As Date = Today
        Private _Warehouse As WarehouseInfo = Nothing
        Private _Items As GoodsOperationInfoList = Nothing

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _ItemsSortedList As Csla.SortedBindingList(Of GoodsOperationInfo) = Nothing


        ''' <summary>
        ''' Gets a goods turnover information for the report period.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property GoodsTurnoverInfo() As GoodsTurnoverInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsTurnoverInfo
            End Get
        End Property

        ''' <summary>
        ''' Gets the starting date of the report period.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DateFrom() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateFrom
            End Get
        End Property

        ''' <summary>
        ''' Gets the ending date of the report period.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DateTo() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DateTo
            End Get
        End Property

        ''' <summary>
        ''' Gets the warehouse that the report is filtered by (if any).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Warehouse() As WarehouseInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Warehouse
            End Get
        End Property

        ''' <summary>
        ''' Gets a collection of items in the report, contains information 
        ''' about goods operations within the report period and subject to 
        ''' the report filter criterias.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Items() As GoodsOperationInfoList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Items
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable collection of items in the report, contains information 
        ''' about goods operations within the report period and subject to 
        ''' the report filter criterias.
        ''' </summary>
        ''' <remarks>Used to implement autosort in a datagridview.</remarks>
        Public ReadOnly Property ItemsSorted() As Csla.SortedBindingList(Of GoodsOperationInfo)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get

                If _ItemsSortedList Is Nothing Then
                    _ItemsSortedList = New Csla.SortedBindingList(Of GoodsOperationInfo)(_Items)
                End If

                Return _ItemsSortedList

            End Get
        End Property


        Protected Overrides Function GetIdValue() As Object
            If _GoodsTurnoverInfo Is Nothing Then Return 0
            Return _GoodsTurnoverInfo.ID
        End Function

        Public Overrides Function ToString() As String
            If _GoodsTurnoverInfo Is Nothing Then Return ""
            Return String.Format(ActiveReports_GoodsOperationInfoListParent_ToString, _
                _GoodsTurnoverInfo.Name)
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new goods operation report instance.
        ''' </summary>
        ''' <param name="dateFrom">starting date of the report period</param>
        ''' <param name="dateTo">ending date of the report period</param>
        ''' <param name="goodsID">an <see cref="Goods.GoodsItem.ID">ID of the goods</see>
        ''' to fetch the report for</param>
        ''' <param name="warehouse">a warehouse to filter the report by (if any)</param>
        ''' <remarks></remarks>
        Public Shared Function GetGoodsTurnoverInfoListParent(ByVal dateFrom As Date, _
            ByVal dateTo As Date, ByVal goodsID As Integer, ByVal warehouse As WarehouseInfo) _
            As GoodsOperationInfoListParent
            Return DataPortal.Fetch(Of GoodsOperationInfoListParent) _
                (New Criteria(dateFrom, dateTo, goodsID, warehouse))
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _DateFrom As Date = Today
            Private _DateTo As Date = Today
            Private _GoodsID As Integer = 0
            Private _Warehouse As WarehouseInfo = Nothing
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
            Public ReadOnly Property GoodsID() As Integer
                Get
                    Return _GoodsID
                End Get
            End Property
            Public ReadOnly Property Warehouse() As WarehouseInfo
                Get
                    Return _Warehouse
                End Get
            End Property
            Public Sub New(ByVal nDateFrom As Date, ByVal nDateTo As Date, _
                ByVal nGoodsID As Integer, ByVal nWarehouse As WarehouseInfo)
                _DateFrom = nDateFrom
                _DateTo = nDateTo
                _GoodsID = nGoodsID
                _Warehouse = nWarehouse
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            If Not criteria.GoodsID > 0 Then
                Throw New Exception(ActiveReports_GoodsOperationInfoListParent_GoodsIdNull)
            End If

            Dim myComm As New SQLCommand("FetchGoodsOperationInfoListParent")
            myComm.AddParam("?DF", criteria.DateFrom.Date)
            myComm.AddParam("?DT", criteria.DateTo.Date)
            myComm.AddParam("?GD", criteria.GoodsID)
            If Not criteria.Warehouse Is Nothing AndAlso Not criteria.Warehouse.IsEmpty Then
                myComm.AddParam("?WD", criteria.Warehouse.ID)
            Else
                myComm.AddParam("?WD", 0)
            End If

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Common_ObjectNotFound, My.Resources.Goods_GoodsItem_TypeName, _
                    criteria.GoodsID.ToString()))

                _DateFrom = criteria.DateFrom
                _DateTo = criteria.DateTo
                _Warehouse = criteria.Warehouse

                _GoodsTurnoverInfo = GoodsTurnoverInfo.GetGoodsTurnoverInfo(myData.Rows(0))

            End Using

            myComm = New SQLCommand("FetchGoodsOperationInfoList")
            myComm.AddParam("?DF", criteria.DateFrom.Date)
            myComm.AddParam("?DT", criteria.DateTo.Date)
            myComm.AddParam("?GD", criteria.GoodsID)
            If Not criteria.Warehouse Is Nothing AndAlso Not criteria.Warehouse.IsEmpty Then
                myComm.AddParam("?WD", criteria.Warehouse.ID)
            Else
                myComm.AddParam("?WD", 0)
            End If

            Using myData As DataTable = myComm.Fetch
                _Items = GoodsOperationInfoList.GetGoodsOperationInfoList(myData)
            End Using

        End Sub

#End Region

    End Class

End Namespace