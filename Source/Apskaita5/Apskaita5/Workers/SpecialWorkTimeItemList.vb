﻿Namespace Workers

    ''' <summary>
    ''' Represents a list of specific type of work hours (overtime, night work, etc.) 
    ''' for a specific labour contract for a specific month.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="WorkTimeSheet">WorkTimeSheet</see>.
    ''' Values are stored in the database table specialworktimeitems.</remarks>
    <Serializable()> _
    Public NotInheritable Class SpecialWorkTimeItemList
        Inherits BusinessListBase(Of SpecialWorkTimeItemList, SpecialWorkTimeItem)

#Region " Business Methods "

        Private _DaysInMonth As Integer


        Friend ReadOnly Property DaysInMonth() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DaysInMonth
            End Get
        End Property


        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function HasWarnings() As Boolean
            For Each i As SpecialWorkTimeItem In Me
                If i.BrokenRulesCollection.WarningCount > 0 Then Return True
            Next
            Return False
        End Function


        ''' <summary>
        ''' Adds a new special work time item for a given <see cref="WorkTimeItem">general work time item</see>.
        ''' </summary>
        ''' <param name="baseItem">A <see cref="WorkTimeItem">general work time item</see> for which a special work time item should be created.</param>
        ''' <param name="newItemType">A type of work time.</param>
        ''' <remarks></remarks>
        Public Sub AddNewSpecialWorkTimeItem(ByVal baseItem As WorkTimeItem, _
            ByVal newItemType As WorkTimeClassInfo)

            If newItemType Is Nothing OrElse Not newItemType.ID > 0 Then Throw New Exception( _
                My.Resources.Workers_SpecialWorkTimeItem_TypeNull)

            If baseItem Is Nothing Then Throw New Exception(My.Resources.Workers_SpecialWorkTimeItem_WorkerNull)

            For Each i As SpecialWorkTimeItem In Me
                If i.ContractNumber = baseItem.ContractNumber AndAlso _
                    i.ContractSerial.Trim.ToUpper = baseItem.ContractSerial.Trim.ToUpper _
                    AndAlso i.Type.ID = newItemType.ID Then Throw New Exception( _
                    My.Resources.Workers_SpecialWorkTimeItemList_ItemAlreadyExists)
            Next

            Add(SpecialWorkTimeItem.NewSpecialWorkTimeItem(baseItem, newItemType))

        End Sub

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of SpecialWorkTimeItem) = Nothing

        Friend Shared Function NewSpecialWorkTimeItemList(ByVal parent As WorkTimeSheet) As SpecialWorkTimeItemList
            Dim result As SpecialWorkTimeItemList = New SpecialWorkTimeItemList
            result._DaysInMonth = Date.DaysInMonth(parent.Year, parent.Month)
            Return result
        End Function

        Friend Shared Function GetSpecialWorkTimeItemList(ByVal parent As WorkTimeSheet) As SpecialWorkTimeItemList
            Return New SpecialWorkTimeItemList(parent)
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of SpecialWorkTimeItem)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of SpecialWorkTimeItem)(Me)
            Return _SortedList
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal parent As WorkTimeSheet)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = False
            Me.AllowRemove = True
            Fetch(parent)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal parent As WorkTimeSheet)

            Dim myComm As New SQLCommand("FetchSpecialWorkTimeItemList")
            myComm.AddParam("?PD", parent.ID)

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                For Each dr As DataRow In myData.Rows
                    Add(SpecialWorkTimeItem.GetSpecialWorkTimeItem(dr))
                Next

                _DaysInMonth = Date.DaysInMonth(parent.Year, parent.Month)

                RaiseListChangedEvents = True

            End Using

        End Sub

        Friend Sub Update(ByVal parent As WorkTimeSheet)

            RaiseListChangedEvents = False

            For Each item As SpecialWorkTimeItem In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As SpecialWorkTimeItem In Me
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