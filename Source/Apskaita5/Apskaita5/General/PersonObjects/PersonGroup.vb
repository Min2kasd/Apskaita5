﻿Imports ApskaitaObjects.Attributes

Namespace General

    ''' <summary>
    ''' Represents a person's group specific to the company.
    ''' </summary>
    ''' <remarks>Corresponding helper list (value object list) is <see cref="HelperLists.PersonGroupInfoList">HelperLists.PersonGroupInfoList</see>.
    ''' Values are stored in the database table persons_group.</remarks>
    <Serializable()> _
    Public NotInheritable Class PersonGroup
        Inherits BusinessBase(Of PersonGroup)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Name As String = ""
        Private _IsInUse As Boolean = False

        ''' <summary>
        ''' Gets an ID of the group (assigned automaticaly by DB AUTOINCREMENT).
        ''' Returns 0 for a new group.
        ''' </summary>
        ''' <remarks>Value is stored in the database field persons_group.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a name of the group.
        ''' </summary>
        ''' <remarks>Value is stored in the database field persons_group.Name.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 100, False)> _
        Public Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Name.Trim <> value.Trim Then
                    _Name = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Wheather the group has any person assigned to.
        ''' </summary>
        Public ReadOnly Property IsInUse() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsInUse
            End Get
        End Property



        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return _Name
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("Name"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringValueUniqueInCollectionValidation, _
                New Validation.RuleArgs("Name"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Get a new empty PersonGroup.
        ''' </summary>
        Friend Shared Function NewPersonGroup() As PersonGroup
            Dim result As New PersonGroup
            result.ValidationRules.CheckRules()
            Return result
        End Function

        ''' <summary>
        ''' Get an existing PersonGroup from database.
        ''' </summary>
        ''' <param name="dr">Datarow returned by database query.</param>
        Friend Shared Function GetPersonGroup(ByVal dr As DataRow) As PersonGroup
            Return New PersonGroup(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(0), 0)
            _Name = CStrSafe(dr.Item(1)).Trim
            _IsInUse = ConvertDbBoolean(CIntSafe(dr.Item(2), 0))

            MarkOld()

        End Sub

        Friend Sub Insert(ByVal parent As PersonGroupList)

            Dim myComm As New SQLCommand("InsertPersonsGroup")
            myComm.AddParam("?GN", _Name.Trim)

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As PersonGroupList)

            Dim myComm As New SQLCommand("UpdatePersonsGroup")
            myComm.AddParam("?GN", _Name)
            myComm.AddParam("?GD", _ID)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeletePersonsGroup")
            myComm.AddParam("?GD", _ID)
            myComm.Execute()

            MarkNew()

        End Sub


        Friend Sub CheckIfCanDelete()

            Dim myComm As New SQLCommand("GetPersonsBelongToGroup")
            myComm.AddParam("?GD", _ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then _
                    Throw New Exception(String.Format(My.Resources.General_PersonGroup_HasAssignedPersons, Me.ToString))

            End Using

        End Sub

#End Region

    End Class

End Namespace