﻿Namespace Documents

    ''' <summary>
    ''' Represents a list of accounts that is used for money transactions (bank, till, etc.)
    ''' </summary>
    ''' <remarks>Exists only one instance per company.
    ''' Provides additional data on top of <see cref="General.Account">General.Account</see> 
    ''' in order to support money transactions (currencies, specific data import functionality, etc.)
    ''' Values are stored in the database table cashaccounts.</remarks>
    <Serializable()> _
    Public NotInheritable Class CashAccountList
        Inherits BusinessListBase(Of CashAccountList, CashAccount)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        ''' <summary>
        ''' Returnes TRUE if the object was changed by the user.
        ''' </summary>
        ''' <remarks>In this case it's the same as <see cref="CashAccountList.IsDirty">IsDirty</see>
        ''' because the list is for all the company and is never new.</remarks>
        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                Return IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid
            End Get
        End Property


        Protected Overrides Function AddNewCore() As Object
            Dim newItem As CashAccount = CashAccount.NewCashAccount
            Me.Add(newItem)
            Return newItem
        End Function


        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = GetAllBrokenRulesForList(Me)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = GetAllWarningsForList(Me)
            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            For Each i As CashAccount In Me
                If i.BrokenRulesCollection.WarningCount > 0 Then Return True
            Next
            Return False
        End Function


        Protected Overrides Sub RemoveItem(ByVal index As Integer)
            If Me.Item(index).IsInUse Then Throw New Exception( _
                String.Format(My.Resources.Documents_CashAccountList_RemoveInvalid, _
                Me.Item(index).ToString()))
            MyBase.RemoveItem(index)
        End Sub


        Public Overrides Function Save() As CashAccountList

            If Not Me.Count > 0 AndAlso Not Me.DeletedList.Count > 0 Then _
                Throw New Exception(My.Resources.Documents_CashAccountList_ListEmpty)

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim result As CashAccountList = MyBase.Save()
            HelperLists.CashAccountInfoList.InvalidateCache()
            Return result

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.CashAccountList1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.CashAccountList3")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.CashAccountList3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.CashAccountList3")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of CashAccount) = Nothing

        Public Shared Function GetCashAccountList() As CashAccountList
            Return DataPortal.Fetch(Of CashAccountList)(New Criteria())
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of CashAccount)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of CashAccount)(Me)
            Return _SortedList
        End Function

        Private Sub New()
            ' require use of factory methods
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
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

            Dim myComm As New SQLCommand("FetchCashAccountList")

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                For Each dr As DataRow In myData.Rows
                    Add(CashAccount.GetCashAccount(dr))
                Next

                RaiseListChangedEvents = True

            End Using

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            For Each item As CashAccount In DeletedList
                If Not item.IsNew Then
                    item.CheckIfInUse()
                    If item.IsInUse Then Throw New Exception(String.Format( _
                        My.Resources.Documents_CashAccountList_RemoveInvalid, _
                        item.ToString()))
                End If
            Next

            If Not Me.Count > 0 AndAlso Not Me.DeletedList.Count > 0 Then _
                Throw New Exception(My.Resources.Documents_CashAccountList_ListEmpty)

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Using transaction As New SqlTransaction

                Try

                    RaiseListChangedEvents = False

                    For Each item As CashAccount In DeletedList
                        If Not item.IsNew Then item.DeleteSelf()
                    Next
                    DeletedList.Clear()

                    For Each item As CashAccount In Me
                        If item.IsNew Then
                            item.Insert(Me)
                        ElseIf item.IsDirty Then
                            item.Update(Me)
                        End If
                    Next

                    RaiseListChangedEvents = True

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

        End Sub

#End Region

    End Class

End Namespace