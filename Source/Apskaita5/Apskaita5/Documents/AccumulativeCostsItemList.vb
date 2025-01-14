﻿Imports Csla.Validation

Namespace Documents

    ''' <summary>
    ''' Represents a collection of accumulated costs or revenue distribution items.
    ''' </summary>
    ''' <remarks>Should only be used as a child of a <see cref="AccumulativeCosts">AccumulativeCosts</see>.
    ''' Values are stored in the database table accumulativecostsitems.</remarks>
    <Serializable()> _
    Public NotInheritable Class AccumulativeCostsItemList
        Inherits BusinessListBase(Of AccumulativeCostsItemList, AccumulativeCostsItem)

#Region " Business Methods "

        Private _ParentValidator As IChronologicValidator = Nothing


        Protected Overrides Function AddNewCore() As Object
            Dim newItem As AccumulativeCostsItem = _
                AccumulativeCostsItem.NewAccumulativeCostsItem(_ParentValidator)
            Me.Add(newItem)
            Return newItem
        End Function


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
            For Each i As AccumulativeCostsItem In Me
                If i.BrokenRulesCollection.WarningCount > 0 Then Return True
            Next
            Return False
        End Function


        ''' <summary>
        ''' Gets the minimum (first) date of all the items within the list.
        ''' Returnes Date.MaxValue if no items in the list.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Function GetMinDate() As Date
            Dim result As Date = Date.MaxValue
            For Each a As AccumulativeCostsItem In Me
                If a.Date.Date < result.Date Then result = a.Date.Date
            Next
            Return result
        End Function

        ''' <summary>
        ''' Distributes the sum evenly accross all the items in the list.
        ''' </summary>
        ''' <param name="sumToDistribute">Total sum to distribute.</param>
        ''' <remarks></remarks>
        Friend Sub Distribute(ByVal sumToDistribute As Double)

            CheckIfCanDistribute(sumToDistribute)

            If Me.Count < 1 Then
                Throw New Exception(My.Resources.Documents_AccumulativeCostsItemList_ListEmpty)
            End If

            If Me.Count = 1 Then
                Me.Item(0).Sum = sumToDistribute
                Exit Sub
            End If

            Me.RaiseListChangedEvents = False

            Dim itemValue As Double = CRound(sumToDistribute / Me.Count)
            Dim lastItemCorrection As Double = CRound(CRound(sumToDistribute) - CRound(CRound(itemValue) * Me.Count))

            For i As Integer = 1 To Me.Count
                Me.Item(i - 1).Sum = itemValue
            Next

            Me.Item(Me.Count - 1).Sum = Me.Item(Me.Count - 1).Sum + lastItemCorrection

            Me.RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub

        ''' <summary>
        ''' Clears the current items, creates new items defined by <paramref name="periodCount">periodCount</paramref>
        ''' and distributes the sum evenly accross all the items.
        ''' </summary>
        ''' <param name="sumToDistribute">Total sum to distribute.</param>
        '''  <param name="startingDate">The date of the first item.</param>
        '''  <param name="periodLength">Length of a period in months.</param>
        ''' <param name="periodCount">Number of items to create.</param>
        ''' <remarks></remarks>
        Friend Sub Distribute(ByVal sumToDistribute As Double, ByVal startingDate As Date, _
            ByVal periodLength As Integer, ByVal periodCount As Integer)

            CheckIfCanDistribute(sumToDistribute)

            If periodLength < 1 Then periodLength = 1
            If periodCount < 1 Then periodCount = 1

            Me.RaiseListChangedEvents = False

            Me.Clear()

            If periodCount = 1 Then

                Dim newItem As AccumulativeCostsItem = AccumulativeCostsItem. _
                    NewAccumulativeCostsItem(_ParentValidator)
                newItem.Sum = sumToDistribute
                newItem.Date = startingDate
                Me.Add(newItem)

            Else

                Dim itemValue As Double = CRound(sumToDistribute / periodCount)
                Dim lastItemCorrection As Double = CRound(CRound(sumToDistribute) - CRound(CRound(itemValue) * periodCount))

                For i As Integer = 1 To periodCount

                    Dim newItem As AccumulativeCostsItem = AccumulativeCostsItem. _
                        NewAccumulativeCostsItem(_ParentValidator)
                    newItem.Sum = itemValue
                    newItem.Date = startingDate.AddMonths(periodLength * (i - 1))
                    Me.Add(newItem)

                Next

                Me.Item(Me.Count - 1).Sum = Me.Item(Me.Count - 1).Sum + lastItemCorrection

            End If

            Me.RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub

        Private Sub CheckIfCanDistribute(ByVal sumToDistribute As Double)

            If Not CRound(sumToDistribute) > 0 Then
                Throw New Exception(My.Resources.Documents_AccumulativeCostsItemList_NoSumToDistribute)
            End If

            Dim explanation As String = ""
            For Each a As AccumulativeCostsItem In Me
                If Not a.ChronologyValidator.FinancialDataCanChange Then
                    explanation = AddWithNewLine(explanation, a.ChronologyValidator.FinancialDataCanChangeExplanation, False)
                End If
            Next
            If Not StringIsNullOrEmpty(explanation) Then
                Throw New Exception(String.Format(My.Resources.Documents_AccumulativeCostsItemList_SomeItemsReadonly, vbCrLf, explanation))
            End If

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewAccumulativeCostsItemList(ByVal parentValidator As IChronologicValidator) As AccumulativeCostsItemList
            Return New AccumulativeCostsItemList(parentValidator)
        End Function

        Friend Shared Function GetAccumulativeCostsItemList(ByVal parentID As Integer, _
            ByVal parentValidator As IChronologicValidator) As AccumulativeCostsItemList
            Return New AccumulativeCostsItemList(parentID, parentValidator)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
        End Sub

        Private Sub New(ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Create(parentValidator)
        End Sub

        Private Sub New(ByVal parentID As Integer, ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            MarkAsChild()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Fetch(parentID, parentValidator)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal parentValidator As IChronologicValidator)
            _ParentValidator = parentValidator
        End Sub

        Private Sub Fetch(ByVal parentID As Integer, ByVal parentValidator As IChronologicValidator)

            Dim myComm As New SQLCommand("FetchAccumulativeCostsItemList")
            myComm.AddParam("?PD", parentID)

            Using myData As DataTable = myComm.Fetch

                Using closingsDataSource As DataTable = SimpleChronologicValidator.GetClosingsDataSource

                    RaiseListChangedEvents = False

                    For Each dr As DataRow In myData.Rows
                        Add(AccumulativeCostsItem.GetAccumulativeCostsItem(dr, _
                            closingsDataSource, parentValidator))
                    Next

                    _ParentValidator = parentValidator

                    RaiseListChangedEvents = True

                End Using

            End Using

        End Sub

        Friend Sub Update(ByVal parent As AccumulativeCosts)

            RaiseListChangedEvents = False

            For Each item As AccumulativeCostsItem In DeletedList
                If Not item.IsNew Then item.DeleteSelf()
            Next
            DeletedList.Clear()

            For Each item As AccumulativeCostsItem In Me
                If item.IsNew Then
                    item.Insert(parent)
                ElseIf item.IsDirty OrElse parent.ItemsUpdateRequired Then
                    item.Update(parent)
                End If
            Next

            RaiseListChangedEvents = True

        End Sub

        Friend Sub Delete(ByVal parent As AccumulativeCosts)

            Dim myComm As New SQLCommand("DeleteAccumulativeCostsItemList")
            myComm.AddParam("?PD", parent.ID)

            myComm.Execute()

            For Each a As AccumulativeCostsItem In Me
                General.JournalEntry.DeleteJournalEntryChild(a.ID)
            Next

        End Sub


        Friend Sub CheckIfCanUpdate(ByVal parent As AccumulativeCosts)

            For Each a As AccumulativeCostsItem In Me.DeletedList

                If Not a.IsNew Then

                    If Not a.ChronologyValidator.FinancialDataCanChange Then

                        Throw New Exception(String.Format(My.Resources.Documents_AccumulativeCostsItemList_CannotRemoveItem, _
                            a.ToString(), vbCrLf, a.ChronologyValidator.FinancialDataCanChangeExplanation))

                    End If

                    IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted(a.ID, _
                        DocumentType.AccumulatedCosts)

                End If

            Next

            For Each a As AccumulativeCostsItem In Me

                If Not a.IsValid Then
                    Throw New Exception(String.Format(My.Resources.Documents_AccumulativeCostsItemList_CannotUpdateItem, _
                        a.ToString(), vbCrLf, a.BrokenRulesCollection.ToString(RuleSeverity.Error)))
                ElseIf parent.ItemsUpdateRequired AndAlso Not a.IsNew AndAlso Not a.ChronologyValidator.FinancialDataCanChange Then
                    Throw New Exception(String.Format(My.Resources.Documents_AccumulativeCostsItemList_CannotUpdateItem, _
                        a.ToString(), vbCrLf, a.ChronologyValidator.FinancialDataCanChangeExplanation))
                End If

                a.PrepareChildJournalEntry(parent)

            Next

        End Sub

        Friend Sub CheckIfCanDelete()
            For Each a As AccumulativeCostsItem In Me
                If Not a.IsNew Then
                    If Not a.ChronologyValidator.FinancialDataCanChange Then
                        Throw New Exception(String.Format(My.Resources.Documents_AccumulativeCostsItemList_CannotRemoveItem, _
                            a.ToString(), vbCrLf, a.ChronologyValidator.FinancialDataCanChangeExplanation))
                    End If
                    IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted(a.ID, DocumentType.AccumulatedCosts)
                End If
            Next
        End Sub

#End Region

    End Class

End Namespace