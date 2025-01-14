﻿Namespace Assets

    ''' <summary>
    ''' Represents a list of user defined long term asset groups used in company.
    ''' </summary>
    ''' <remarks>Exists a single instance per company.
    ''' Values are stored in the database table longtermassetcustomgroups.</remarks>
    <Serializable()> _
Public NotInheritable Class LongTermAssetCustomGroupList
        Inherits BusinessListBase(Of LongTermAssetCustomGroupList, LongTermAssetCustomGroup)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

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
            Dim newItem As LongTermAssetCustomGroup = LongTermAssetCustomGroup.NewLongTermAssetCustomGroup
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
            For Each i As LongTermAssetCustomGroup In Me
                If i.BrokenRulesCollection.WarningCount > 0 Then Return True
            Next
            Return False
        End Function


        Public Overrides Function Save() As LongTermAssetCustomGroupList

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim result As LongTermAssetCustomGroupList = MyBase.Save
            LongTermAssetCustomGroupInfoList.InvalidateCache()
            Return result

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanAddObject() As Boolean
            Return False
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Assets.LongTermAssetCustomGroupList1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Assets.LongTermAssetCustomGroupList3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return False
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of LongTermAssetCustomGroup) = Nothing


        ''' <summary>
        ''' Gets a LongTermAssetCustomGroupList instance from a database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function GetLongTermAssetCustomGroupList() As LongTermAssetCustomGroupList
            Return DataPortal.Fetch(Of LongTermAssetCustomGroupList)(New Criteria())
        End Function


        ''' <summary>
        ''' Gets a sortable view of the LongTermAssetCustomGroupList instance.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a datagridview.</remarks>
        Public Function GetSortedList() As Csla.SortedBindingList(Of LongTermAssetCustomGroup)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of LongTermAssetCustomGroup)(Me)
            Return _SortedList
        End Function


        Private Sub New()
            ' require use of factory methods
            AllowNew = True
            AllowRemove = True
            AllowEdit = True
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

            Dim myComm As New SQLCommand("FetchLongTermAssetCustomGroupList")

            Using myData As DataTable = myComm.Fetch
                RaiseListChangedEvents = False
                For Each dr As DataRow In myData.Rows
                    Add(LongTermAssetCustomGroup.GetLongTermAssetCustomGroup(dr))
                Next
                RaiseListChangedEvents = True
            End Using

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            For Each item As LongTermAssetCustomGroup In DeletedList
                If Not item.IsNew Then item.CheckIfItemCanBeDeleted()
            Next

            Using transaction As New SqlTransaction

                Try

                    RaiseListChangedEvents = False
                    For Each item As LongTermAssetCustomGroup In DeletedList
                        If Not item.IsNew Then item.DeleteSelf()
                    Next
                    DeletedList.Clear()

                    For Each item As LongTermAssetCustomGroup In Me
                        If item.IsNew Then
                            item.Insert(Me)
                        Else
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