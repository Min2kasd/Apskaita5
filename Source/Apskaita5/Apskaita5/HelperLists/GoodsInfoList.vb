﻿Namespace HelperLists

    ''' <summary>
    ''' Represents a list of <see cref="Goods.GoodsItem">goods</see> value objects.
    ''' </summary>
    ''' <remarks>Exists a single instance per company.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsInfoList
        Inherits ReadOnlyListBase(Of GoodsInfoList, GoodsInfo)

#Region " Business Methods "

        ''' <summary>
        ''' Gets a goods info instance by the goods ID.
        ''' Returns null if there is no goods with the id value requested.
        ''' </summary>
        ''' <param name="id">a <see cref="Goods.GoodsItem.ID">goods id</see> to look for</param>
        ''' <remarks></remarks>
        Public Function GetItem(ByVal id As Integer) As GoodsInfo
            If Not id > 0 Then Return Nothing
            For Each i As GoodsInfo In Me
                If i.ID = id Then Return i
            Next
            Return Nothing
        End Function

        ''' <summary>
        ''' Gets a goods info instance by the goods name.
        ''' Returns null if there is no goods with the name requested.
        ''' </summary>
        ''' <param name="name">a <see cref="Goods.GoodsItem.Name">goods name</see> to look for</param>
        ''' <remarks></remarks>
        Public Function GetItem(ByVal name As String) As GoodsInfo
            If StringIsNullOrEmpty(name) Then Return Nothing
            For Each i As GoodsInfo In Me
                If i.Name.Trim.ToLower = name.Trim.ToLower Then Return i
            Next
            Return Nothing
        End Function

        ''' <summary>
        ''' Gets a goods info instance by the goods barcode.
        ''' Returns null if there is no goods with the barcode requested.
        ''' </summary>
        ''' <param name="barcode">a <see cref="Goods.GoodsItem.Barcode">goods barcode</see> to look for</param>
        ''' <remarks></remarks>
        Public Function GetItemByBarCode(ByVal barcode As String) As GoodsInfo
            If StringIsNullOrEmpty(barcode) Then Return Nothing
            For Each i As GoodsInfo In Me
                If Not String.IsNullOrEmpty(i.GoodsBarcode.Trim) AndAlso _
                    i.GoodsBarcode.Trim.ToLower = barcode.Trim.ToLower Then Return i
            Next
            Return Nothing
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.GoodsInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a current goods info value object list from database.
        ''' </summary>
        ''' <remarks>Result is cached.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function GetList() As GoodsInfoList

            Dim result As GoodsInfoList = CacheManager.GetItemFromCache(Of GoodsInfoList)( _
                GetType(GoodsInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of GoodsInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(GoodsInfoList), result, Nothing)
            End If

            Return result

        End Function

        ''' <summary>
        ''' Gets a filtered view of the current goods info value object list.
        ''' </summary>
        ''' <param name="showEmpty">Wheather to include a placeholder object.</param>
        ''' <param name="showObsolete">Wheather to include goods that are obsolete (no loger in use).</param>
        ''' <param name="tradedType">a trade type to filter by</param>
        ''' <remarks>Result is cached.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function GetCachedFilteredList(ByVal showObsolete As Boolean, _
            ByVal showEmpty As Boolean, ByVal tradedType As Documents.TradedItemType, _
            ByVal usedObjectsIds As List(Of String)) As Csla.FilteredBindingList(Of GoodsInfo)

            Dim filterToApply(3) As Object
            filterToApply(0) = showObsolete
            filterToApply(1) = showEmpty
            filterToApply(2) = tradedType
            filterToApply(3) = usedObjectsIds

            Dim result As Csla.FilteredBindingList(Of GoodsInfo) = _
                CacheManager.GetItemFromCache(Of Csla.FilteredBindingList(Of GoodsInfo)) _
                (GetType(GoodsInfoList), filterToApply)

            If result Is Nothing Then

                Dim baseList As GoodsInfoList = GoodsInfoList.GetList
                result = New Csla.FilteredBindingList(Of GoodsInfo)(baseList, _
                    AddressOf GoodsInfoFilter)
                result.ApplyFilter("", filterToApply)
                CacheManager.AddCacheItem(GetType(GoodsInfoList), result, filterToApply)

            End If

            Return result

        End Function

        ''' <summary>
        ''' Invalidates the current goods info value object list cache 
        ''' so that the next <see cref="GetList">GetList</see> call would hit the database.
        ''' </summary>
        ''' <remarks>Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(GoodsInfoList))
        End Sub

        ''' <summary>
        ''' Returnes true if the cache does not contain a current goods info value object list.
        ''' </summary>
        ''' <remarks>Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(GoodsInfoList))
        End Function

        ''' <summary>
        ''' Returns true if the collection is common across all the databases.
        ''' I.e. cache is not to be cleared on changing databases.
        ''' </summary>
        ''' <remarks>Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        ''' <summary>
        ''' Gets a current goods info value object list from database bypassing dataportal.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>Should only be called server side.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Private Shared Function GetListOnServer() As GoodsInfoList
            Dim result As New GoodsInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function

        ''' <summary>
        ''' Gets a current goods info value object list from database bypassing dataportal.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>Should only be called server side.</remarks>
        Friend Shared Function GetListChild() As GoodsInfoList
            Dim result As New GoodsInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        Private Shared Function GoodsInfoFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing Then Return True

            Dim filterArray As Object() = DirectCast(filterValue, Object())

            Dim showObsolete As Boolean = DirectCast(filterArray(0), Boolean)
            Dim showEmpty As Boolean = DirectCast(filterArray(1), Boolean)
            Dim tradedType As Documents.TradedItemType = _
                DirectCast(filterArray(2), Documents.TradedItemType)
            Dim usedObjectsIds As List(Of String) = DirectCast(filterArray(3), List(Of String))

            ' no criteria to apply
            If showObsolete AndAlso showEmpty AndAlso _
                tradedType = Documents.TradedItemType.All Then Return True

            Dim current As GoodsInfo = DirectCast(item, GoodsInfo)

            If current.IsEmpty Then

                Return showEmpty

            Else

                If Not usedObjectsIds Is Nothing AndAlso usedObjectsIds.Contains( _
                    current.GetValueObjectIdString()) Then
                    Return True
                End If

                If Not showObsolete AndAlso current.IsObsolete Then Return False

                If tradedType <> Documents.TradedItemType.All AndAlso _
                    current.TradeItemType <> Documents.TradedItemType.All AndAlso _
                    current.TradeItemType <> tradedType Then Return False

            End If

            Return True

        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchGoodsInfoList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                Add(GoodsInfo.Empty)

                For Each dr As DataRow In myData.Rows
                    Add(GoodsInfo.GetGoodsInfo(dr, 0))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace