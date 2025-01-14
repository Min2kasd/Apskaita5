﻿Namespace HelperLists

    ''' <summary>
    ''' Represents a collection of value objects containing the names of available 
    ''' <see cref="General.ConsolidatedReportItem">ConsolidatedReportItems</see>
    ''' that could be assigned to a <see cref="General.Account.AssociatedReportItem">Account.AssociatedReportItem</see>.
    ''' </summary>
    ''' <remarks>Only the items without child items could be assigned to an account.</remarks>
    <Serializable()> _
    Public NotInheritable Class AssignableCRItemList
        Inherits ReadOnlyListBase(Of AssignableCRItemList, AssignableCRItem)

#Region " Business Methods "

        ''' <summary>
        ''' Gets an assignable consolidated report item by it's name.
        ''' Returns nothing if no item with the name specified if found.
        ''' Returns nothing if the specified name is null or empty.
        ''' </summary>
        ''' <param name="itemName">a name of an assignable consolidated report item to find</param>
        ''' <remarks></remarks>
        Public Function GetItemByName(ByVal itemName As String) As AssignableCRItem
            If StringIsNullOrEmpty(itemName) Then Return Nothing
            For Each c As AssignableCRItem In Me
                If c.Name.Trim.ToUpper = itemName.Trim.ToUpper Then Return c
            Next
            Return Nothing
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.AssignableCRItemList1")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a current assignable ConsolidatedReportItem name list from database.
        ''' </summary>
        ''' <remarks>Result is cached.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function GetList() As AssignableCRItemList

            Dim result As AssignableCRItemList = CacheManager.GetItemFromCache(Of AssignableCRItemList)( _
                GetType(AssignableCRItemList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of AssignableCRItemList)(New Criteria())
                CacheManager.AddCacheItem(GetType(AssignableCRItemList), result, Nothing)
            End If

            Return result

        End Function

        ''' <summary>
        ''' Gets a filtered view of the current assignable ConsolidatedReportItem name list.
        ''' </summary>
        ''' <param name="showEmpty">Wheather to include a placeholder object.</param>
        ''' <remarks>Result is cached.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function GetCachedFilteredList(ByVal showEmpty As Boolean) As AssignableCRItemList

            Dim filterToApply(0) As Object
            filterToApply(0) = ConvertDbBoolean(showEmpty)

            Dim result As AssignableCRItemList = CacheManager.GetItemFromCache(Of AssignableCRItemList) _
                (GetType(AssignableCRItemList), Nothing)

            If result Is Nothing Then result = AssignableCRItemList.GetList

            Return result

        End Function

        ''' <summary>
        ''' Invalidates the current assignable ConsolidatedReportItem name list cache 
        ''' so that the next <see cref="GetList">GetList</see> call would hit the database.
        ''' </summary>
        ''' <remarks>Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(AssignableCRItemList))
        End Sub

        ''' <summary>
        ''' Returnes true if the cache does not contain a current assignable ConsolidatedReportItem name list.
        ''' </summary>
        ''' <remarks>Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(AssignableCRItemList))
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
        ''' Gets a current assignable ConsolidatedReportItem name list from database bypassing dataportal.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>Should only be called server side.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Private Shared Function GetListOnServer() As AssignableCRItemList
            Dim result As New AssignableCRItemList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function

        ''' <summary>
        ''' Gets a current assignable ConsolidatedReportItem name list from database bypassing dataportal.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>Should only be called server side.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Friend Shared Function GetListChild() As AssignableCRItemList
            Dim result As New AssignableCRItemList
            result.DoFetch()
            Return result
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

            DoFetch()

        End Sub

        Private Sub DoFetch()

            RaiseListChangedEvents = False
            IsReadOnly = False

            Dim myComm As New SQLCommand("FetchAssignableCRItemList")

            Using myData As DataTable = myComm.Fetch
                Add(AssignableCRItem.Empty())
                For Each dr As DataRow In myData.Rows
                    Add(AssignableCRItem.GetAssignableCRItem(dr, 0))
                Next
            End Using

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace