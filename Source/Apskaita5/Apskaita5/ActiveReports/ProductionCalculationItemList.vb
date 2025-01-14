﻿Namespace ActiveReports

    ''' <summary>
    ''' Represents a goods production template (calculation) report. 
    ''' Contains information about <see cref="Goods.ProductionCalculation">
    ''' goods production templates (calculations)</see>.
    ''' </summary>
    ''' <remarks>Values are stored in the database table kalkuliac and kalkuliac_d.</remarks>
    <Serializable()> _
    Public NotInheritable Class ProductionCalculationItemList
        Inherits ReadOnlyListBase(Of ProductionCalculationItemList, ProductionCalculationItem)

#Region " Business Methods "

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.ProductionCalculationItemInfoList1")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of ProductionCalculationItem) = Nothing

        ''' <summary>
        ''' Gets a goods production template (calculation) report instance.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function GetProductionCalculationItemList() As ProductionCalculationItemList
            Return DataPortal.Fetch(Of ProductionCalculationItemList)(New Criteria())
        End Function

        ''' <summary>
        ''' Gets a sortable view of the goods production template (calculation) report.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a datagridview.</remarks>
        Public Function GetSortedList() As Csla.SortedBindingList(Of ProductionCalculationItem)
            If _SortedList Is Nothing Then
                _SortedList = New Csla.SortedBindingList(Of ProductionCalculationItem)(Me)
            End If
            Return _SortedList
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

            Dim myComm As New SQLCommand("FetchProductionCalculationItemList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False
                IsReadOnly = False

                For Each dr As DataRow In myData.Rows
                    Add(ProductionCalculationItem.GetProductionCalculationItem(dr))
                Next

                IsReadOnly = True
                RaiseListChangedEvents = True

            End Using

        End Sub

#End Region

    End Class

End Namespace