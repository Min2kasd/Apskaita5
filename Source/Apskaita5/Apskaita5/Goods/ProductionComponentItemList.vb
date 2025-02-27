﻿Namespace Goods

    ''' <summary>
    ''' Represents a list of production template (""recipe"") component items 
    ''' for a certain production template (calculation).
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="ProductionCalculation">ProductionCalculation</see>.
    ''' Values are stored in the database table kalkuliac_d.</remarks>
    <Serializable()> _
    Public NotInheritable Class ProductionComponentItemList
        Inherits BusinessListBase(Of ProductionComponentItemList, ProductionComponentItem)

#Region " Business Methods "

        Protected Overrides Function AddNewCore() As Object
            Dim newItem As ProductionComponentItem = ProductionComponentItem.NewProductionComponentItem
            Me.Add(newItem)
            Return newItem
        End Function

        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            Return result
        End Function

        Public Function HasWarnings() As Boolean
            For Each i As ProductionComponentItem In Me
                If i.HasWarnings() Then Return True
            Next
            Return False
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewProductionComponentItemList() As ProductionComponentItemList
            Return New ProductionComponentItemList
        End Function

        Friend Shared Function GetProductionComponentItemList(ByVal myData As DataTable) As ProductionComponentItemList
            Return New ProductionComponentItemList(myData)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal myData As DataTable)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Fetch(myData)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal myData As DataTable)

            RaiseListChangedEvents = False

            For Each dr As DataRow In myData.Rows
                If Utilities.ConvertDatabaseCharID(Of ProductionComponentType) _
                    (CStrSafe(dr.Item(0))) = ProductionComponentType.Component Then _
                    Add(ProductionComponentItem.GetProductionComponentItem(dr))
            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Update(ByVal parent As ProductionCalculation)

            RaiseListChangedEvents = False

            For Each item As ProductionComponentItem In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As ProductionComponentItem In Me
                If item.IsNew Then
                    item.Insert(parent)
                ElseIf item.IsDirty Then
                    item.Update(parent)
                End If
            Next

            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace