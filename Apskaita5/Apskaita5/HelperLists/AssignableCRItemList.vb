Namespace HelperLists

    <Serializable()> _
    Public Class AssignableCRItemList
        Inherits ReadOnlyListBase(Of AssignableCRItemList, String)

        Public Function ToArray() As String()
            Dim result As New List(Of String)
            For Each i As String In Me
                result.Add(i)
            Next
            Return result.ToArray
        End Function

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.AssignableCRItemList1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetList() As AssignableCRItemList

            Dim result As AssignableCRItemList = CacheManager.GetItemFromCache( _
                GetType(AssignableCRItemList), GetType(AssignableCRItemList), Nothing)

            If result Is Nothing Then
                result = DataPortal.Fetch(Of AssignableCRItemList)(New Criteria())
                CacheManager.AddCacheItem(GetType(AssignableCRItemList), result, Nothing)
            End If

            Return result

        End Function

        Public Shared Function GetCachedFilteredList(ByVal ShowEmpty As Boolean) _
            As AssignableCRItemList

            Dim FilterToApply(0) As Object
            FilterToApply(0) = ConvertDbBoolean(ShowEmpty)

            Dim result As AssignableCRItemList = _
                CacheManager.GetItemFromCache(GetType(AssignableCRItemList), _
                GetType(AssignableCRItemList), Nothing)

            If result Is Nothing Then result = AssignableCRItemList.GetList

            Return result

        End Function

        Public Shared Sub InvalidateCache()
            CacheManager.InvalidateCache(GetType(AssignableCRItemList))
        End Sub

        Public Shared Function CacheIsInvalidated() As Boolean
            Return CacheManager.CacheIsInvalidated(GetType(AssignableCRItemList))
        End Function

        Private Shared Function IsApplicationWideCache() As Boolean
            Return False
        End Function

        Private Shared Function GetListOnServer() As AssignableCRItemList
            Dim result As New AssignableCRItemList
            result.DataPortal_Fetch(New Criteria)
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
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            RaiseListChangedEvents = False
            IsReadOnly = False
            ' load values

            Dim myComm As New SQLCommand("FetchAssignableCRItemList")

            Using myData As DataTable = myComm.Fetch
                Add("")
                For Each dr As DataRow In myData.Rows
                    Add(dr.Item(0).ToString)
                Next
            End Using

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace