﻿Namespace HelperLists

    ''' <summary>
    ''' Represents a list of <see cref="General.Account">ledger account</see> value objects.
    ''' </summary>
    ''' <remarks>Exists a single instance per company.</remarks>
    <Serializable()> _
    Public NotInheritable Class AccountInfoList
        Inherits ReadOnlyListBase(Of AccountInfoList, AccountInfo)

#Region " Business Methods "

        ''' <summary>
        ''' Gets an account value object by <see cref="General.Account.ID">an account ID</see>.
        ''' Returns null if the <paramref name="accountID">accountID</paramref> does not match any account.
        ''' </summary>
        ''' <param name="accountID">An ID of the account to get.</param>
        ''' <remarks></remarks>
        Public Function GetAccountByID(ByVal accountID As Long) As AccountInfo
            For Each i As AccountInfo In Me
                If i.ID = accountID Then Return i
            Next
            Return Nothing
        End Function

        ''' <summary>
        ''' Gets an account <see cref="AccountInfo.Name">name</see> by <see cref="General.Account.ID">an account ID</see>.
        ''' Returns an empty string if the <paramref name="accountID">accountID</paramref> does not match any account.
        ''' </summary>
        ''' <param name="accountID">An ID of the account to get.</param>
        ''' <remarks></remarks>
        Public Function GetAccountNameByID(ByVal AccountID As Long) As String
            For Each i As AccountInfo In Me
                If i.ID = AccountID Then Return i.Name
            Next
            Return ""
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.AccountInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a current account value object list from database.
        ''' </summary>
        ''' <remarks>Result is cached.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function GetList() As AccountInfoList

            Dim result As AccountInfoList = CacheManager.GetItemFromCache(Of AccountInfoList)( _
                GetType(AccountInfoList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of AccountInfoList)(New Criteria())
                CacheManager.AddCacheItem(GetType(AccountInfoList), result, Nothing)
            End If

            Return result

        End Function

        ''' <summary>
        ''' Gets a filtered view of the current account value object list.
        ''' </summary>
        ''' <param name="showEmpty">Wheather to include a placeholder object.</param>
        ''' <param name="classFilter">A list of accounts' classes to include.</param>
        ''' <remarks>Result is cached.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function GetCachedFilteredList(ByVal showEmpty As Boolean, _
            ByVal ParamArray classFilter As Integer()) As Csla.FilteredBindingList(Of AccountInfo)


            Dim FilterToApply As Object()

            If classFilter Is Nothing OrElse classFilter.Length < 1 Then

                FilterToApply = GetNewFilter(showEmpty)

            Else

                Dim FilterList As New List(Of Integer)(classFilter)

                Dim i, j As Integer

                For i = FilterList.Count To 1 Step -1
                    If FilterList(i - 1) < 1 OrElse FilterList(i - 1) > 6 Then FilterList.RemoveAt(i - 1)
                Next

                For i = FilterList.Count To 1 Step -1
                    For j = i - 1 To 1 Step -1
                        If FilterList(i - 1) = FilterList(j - 1) Then
                            FilterList.RemoveAt(i - 1)
                            Exit For
                        End If
                    Next
                Next

                FilterList.Sort()

                If FilterList.Count < 1 Then
                    FilterToApply = GetNewFilter(showEmpty)
                Else
                    Dim NewFilterToApply(FilterList.Count) As Object
                    FilterToApply = NewFilterToApply
                    FilterToApply(0) = ConvertDbBoolean(showEmpty)
                    For i = 1 To FilterList.Count
                        FilterToApply(i) = FilterList(i - 1)
                    Next
                End If

            End If

            Dim result As Csla.FilteredBindingList(Of AccountInfo) = _
                CacheManager.GetItemFromCache(Of Csla.FilteredBindingList(Of AccountInfo)) _
                (GetType(AccountInfoList), FilterToApply)

            If result Is Nothing Then

                Dim BaseList As AccountInfoList = AccountInfoList.GetList
                result = New Csla.FilteredBindingList(Of AccountInfo)(BaseList, AddressOf AccountInfoListFilter)
                result.ApplyFilter("", FilterToApply)
                CacheManager.AddCacheItem(GetType(AccountInfoList), result, FilterToApply)

            End If

            Return result

        End Function

        ''' <summary>
        ''' Invalidates the current account value object list cache 
        ''' so that the next <see cref="GetList">GetList</see> call would hit the database.
        ''' </summary>
        ''' <remarks>Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(AccountInfoList))
        End Sub

        ''' <summary>
        ''' Returnes true if the cache does not contain a current account value object list.
        ''' </summary>
        ''' <remarks>Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(AccountInfoList))
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
        ''' Gets a current account value object list from database bypassing dataportal.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>Should only be called server side.
        ''' Required by <see cref="AccDataAccessLayer.CacheManager">AccDataAccessLayer.CacheManager</see>.</remarks>
        Private Shared Function GetListOnServer() As AccountInfoList
            Dim result As New AccountInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function

        ''' <summary>
        ''' Gets a current account value object list from database bypassing dataportal.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>Should only be invoked server side.</remarks>
        Friend Shared Function GetListChild() As AccountInfoList
            Dim result As New AccountInfoList
            result.DataPortal_Fetch(New Criteria)
            Return result
        End Function


        Private Shared Function GetNewFilter(ByVal ShowEmpty As Boolean) As Object()
            Dim NewFilter(6) As Object
            NewFilter(0) = ConvertDbBoolean(ShowEmpty)
            NewFilter(1) = 1
            NewFilter(2) = 2
            NewFilter(3) = 3
            NewFilter(4) = 4
            NewFilter(5) = 5
            NewFilter(6) = 6
            Return NewFilter
        End Function

        Private Shared Function AccountInfoListFilter(ByVal item As Object, ByVal filterValue As Object) As Boolean

            If filterValue Is Nothing OrElse Not TypeOf filterValue Is Object() _
                OrElse Not DirectCast(filterValue, Object()).Length > 0 Then Return True

            Dim ShowEmpty As Boolean = ConvertDbBoolean( _
                DirectCast(DirectCast(filterValue, Object())(0), Integer))

            Dim ClassFilter As Integer() = Nothing
            If DirectCast(filterValue, Object()).Length > 1 Then
                Dim NewClassFilter(DirectCast(filterValue, Object()).Length - 2) As Integer
                ClassFilter = NewClassFilter
                For i As Integer = 2 To DirectCast(filterValue, Object()).Length
                    ClassFilter(i - 2) = CIntSafe(DirectCast(filterValue, Object())(i - 1), 0)
                Next
            End If

            ' no criteria to apply
            If ShowEmpty AndAlso (ClassFilter Is Nothing OrElse ClassFilter.Length = 6) Then Return True

            Dim CI As AccountInfo = DirectCast(item, AccountInfo)

            If Not ShowEmpty AndAlso Not CI.ID > 0 Then Return False
            If Not ClassFilter Is Nothing AndAlso CI.ID > 0 AndAlso Array.IndexOf(ClassFilter, _
                Convert.ToInt32(CI.Class)) < 0 Then Return False

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

            Dim myComm As New SQLCommand("GetAccountList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                Add(AccountInfo.Empty)
                For Each dr As DataRow In myData.Rows
                    Add(AccountInfo.GetAccountInfo(dr))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace