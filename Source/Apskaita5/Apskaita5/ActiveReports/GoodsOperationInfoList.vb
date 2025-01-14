﻿Namespace ActiveReports

    ''' <summary>
    ''' Represents a collection of items in a <see cref="GoodsOperationInfoListParent">
    ''' goods operation report</see>, contains information about goods operations
    ''' within the report period and subject to the report filter criterias.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="GoodsOperationInfoListParent">GoodsOperationInfoListParent</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsOperationInfoList
        Inherits ReadOnlyListBase(Of GoodsOperationInfoList, GoodsOperationInfo)

#Region " Business Methods "

#End Region

#Region " Factory Methods "

        Friend Shared Function GetGoodsOperationInfoList(ByVal myData As DataTable) As GoodsOperationInfoList
            Return New GoodsOperationInfoList(myData)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal myData As DataTable)
            ' require use of factory methods
            Fetch(myData)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal myData As DataTable)

            RaiseListChangedEvents = False
            IsReadOnly = False

            For Each dr As DataRow In myData.Rows
                Add(GoodsOperationInfo.GetGoodsOperationInfo(dr))
            Next

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace