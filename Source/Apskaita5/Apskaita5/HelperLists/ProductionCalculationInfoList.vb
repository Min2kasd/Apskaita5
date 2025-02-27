﻿Namespace HelperLists

    ''' <summary>
    ''' Represents a list of <see cref="Goods.ProductionCalculation">goods production 
    ''' template (calculation)</see> value objects.
    ''' </summary>
    ''' <remarks>Exists a single instance per company.</remarks>
    <Serializable()> _
    Public NotInheritable Class ProductionCalculationInfoList
        Inherits ReadOnlyListBase(Of ProductionCalculationInfoList, ProductionCalculationInfo)

#Region " Business Methods "

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.ProductionCalculationInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a current goods production template (calculation) info value object list 
        ''' from a database.
        ''' </summary>
        ''' <remarks>Result is cached.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function GetList() As ProductionCalculationInfoList

            Dim result As ProductionCalculationInfoList = _
                CacheManager.GetItemFromCache(Of ProductionCalculationInfoList)( _
                GetType(ProductionCalculationInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of ProductionCalculationInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(ProductionCalculationInfoList), result, Nothing)
            End If

            Return result

        End Function

        ''' <summary>
        ''' Gets a filtered view of the current goods production template (calculation) 
        ''' info value object list.
        ''' </summary>
        ''' <param name="showEmpty">Wheather to include a placeholder object.</param>
        ''' <param name="showObsolete">Wheather to include templates that are obsolete (no loger in use).</param>
        ''' <remarks>Result is cached.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function GetCachedFilteredList(ByVal showEmpty As Boolean, _
            ByVal showObsolete As Boolean, ByVal valueObjectIds As List(Of String)) _
            As Csla.FilteredBindingList(Of ProductionCalculationInfo)

            Dim filterToApply(2) As Object
            filterToApply(0) = showEmpty
            filterToApply(1) = showObsolete
            filterToApply(2) = valueObjectIds

            Dim result As Csla.FilteredBindingList(Of ProductionCalculationInfo) = _
                CacheManager.GetItemFromCache(Of Csla.FilteredBindingList(Of ProductionCalculationInfo)) _
                (GetType(ProductionCalculationInfoList), filterToApply)

            If result Is Nothing Then

                Dim baseList As ProductionCalculationInfoList = ProductionCalculationInfoList.GetList
                result = New Csla.FilteredBindingList(Of ProductionCalculationInfo) _
                    (baseList, AddressOf ProductionCalculationInfoListFilter)
                result.ApplyFilter("", filterToApply)
                CacheManager.AddCacheItem(GetType(ProductionCalculationInfoList), result, filterToApply)

            End If

            Return result

        End Function

        ''' <summary>
        ''' Invalidates the current goods production template (calculation) info 
        ''' value object list cache so that the next <see cref="GetList">GetList</see> 
        ''' call would hit the database.
        ''' </summary>
        ''' <remarks>Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(ProductionCalculationInfoList))
        End Sub

        ''' <summary>
        ''' Returnes true if the cache does not contain a current goods production 
        ''' template (calculation) info value object list.
        ''' </summary>
        ''' <remarks>Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(ProductionCalculationInfoList))
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
        ''' Gets a current goods production template (calculation) info value object 
        ''' list from a database bypassing the dataportal.
        ''' </summary>
        ''' <remarks>Should only be called server side.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Private Shared Function GetListOnServer() As ProductionCalculationInfoList
            Dim result As New ProductionCalculationInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        Private Shared Function ProductionCalculationInfoListFilter(ByVal item As Object, _
            ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing OrElse Not TypeOf filterValue Is Object() _
                OrElse Not DirectCast(filterValue, Object()).Length > 0 Then Return True

            Dim filterArray As Object() = DirectCast(filterValue, Object())

            Dim showEmpty As Boolean = DirectCast(filterArray(0), Boolean)
            Dim showObsolete As Boolean = DirectCast(filterArray(1), Boolean)
            Dim valueObjectIds As List(Of String) = DirectCast(filterArray(2), List(Of String))

            ' no criteria to apply
            If showEmpty AndAlso showObsolete Then Return True

            Dim current As ProductionCalculationInfo = _
                DirectCast(item, ProductionCalculationInfo)

            If current.IsEmpty Then

                Return showEmpty

            Else

                If Not valueObjectIds Is Nothing AndAlso valueObjectIds.Contains( _
                    current.GetValueObjectIdString()) Then
                    Return True
                End If

                If Not showObsolete AndAlso current.IsObsolete Then Return False

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

            Dim myComm As New SQLCommand("FetchProductionCalculationInfoList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                Add(ProductionCalculationInfo.Empty())

                For Each dr As DataRow In myData.Rows
                    Add(ProductionCalculationInfo.GetProductionCalculationInfo(dr))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace