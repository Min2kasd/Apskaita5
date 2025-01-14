﻿Imports System.Security
Imports ApskaitaObjects.My.Resources

Namespace Goods

    ''' <summary>
    ''' Represents a collection of calculation of total goods value 
    ''' to be discarded for a given amount. Used to fetch calculations
    ''' for multiple goods in a single query.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsCostItemList
        Inherits ReadOnlyListBase(Of GoodsCostItemList, GoodsCostItem)

#Region " Business Methods "

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.GoodsCostItemList1")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new collection of goods value calculations for the given parameters.
        ''' </summary>
        ''' <param name="goodsCostParams">a collection of parameters for 
        ''' goods value calculations</param>
        ''' <remarks></remarks>
        Public Shared Function GetGoodsCostItemList(ByVal goodsCostParams As GoodsCostParam()) As GoodsCostItemList
            Return DataPortal.Fetch(Of GoodsCostItemList)(New Criteria(goodsCostParams))
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _GoodsCostParams As GoodsCostParam()
            Public ReadOnly Property GoodsCostParams() As GoodsCostParam()
                Get
                    Return _GoodsCostParams
                End Get
            End Property
            Public Sub New(ByVal nGoodsCostParams As GoodsCostParam())
                _GoodsCostParams = nGoodsCostParams
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            If criteria.GoodsCostParams Is Nothing OrElse _
                criteria.GoodsCostParams.Length < 1 Then
                Throw New ArgumentException(Goods_GoodsCostItemList_ParamListNull)
            End If

            RaiseListChangedEvents = False
            IsReadOnly = False

            For Each param As GoodsCostParam In criteria.GoodsCostParams
                Add(GoodsCostItem.GetGoodsCostItemChild(param))
            Next

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace