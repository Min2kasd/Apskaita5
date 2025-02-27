﻿Imports ApskaitaObjects.My.Resources

Namespace HelperLists

    ''' <summary>
    ''' Represents a <see cref="General.PersonGroup">person's group</see> value object.
    ''' </summary>
    ''' <remarks>Values are stored in the database table persons_group.</remarks>
    <Serializable()> _
Public NotInheritable Class PersonGroupInfo
        Inherits ReadOnlyBase(Of PersonGroupInfo)
        Implements IValueObject, IComparable

#Region " Business Methods "

        Private _ID As Integer = -1
        Private _Name As String = HelperLists_PersonGroupInfo_EmptyPersonGroupString


        ''' <summary>
        ''' Whether an object is a palace holder (does not represent a real person group).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsEmpty() As Boolean _
            Implements IValueObject.IsEmpty
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ID > 0
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID of the group (assigned automaticaly by DB AUTOINCREMENT).
        ''' Returns 0 for a new group.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.PersonGroup.ID">PersonGroup.ID</see> property.
        ''' Value is stored in the database field persons_group.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets a name of the group.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.PersonGroup.Name">PersonGroup.Name</see> property.
        ''' Value is stored in the database field persons_group.Name.</remarks>
        Public ReadOnly Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
        End Property


        Public Shared Operator =(ByVal a As PersonGroupInfo, ByVal b As PersonGroupInfo) As Boolean

            Dim aId, bId As Integer
            If a Is Nothing OrElse a.IsEmpty Then
                aId = 0
            Else
                aId = a.ID
            End If
            If b Is Nothing OrElse b.IsEmpty Then
                bId = 0
            Else
                bId = b.ID
            End If

            Return aId = bId

        End Operator

        Public Shared Operator <>(ByVal a As PersonGroupInfo, ByVal b As PersonGroupInfo) As Boolean
            Return Not a = b
        End Operator

        Public Shared Operator >(ByVal a As PersonGroupInfo, ByVal b As PersonGroupInfo) As Boolean

            Dim aToString, bToString As String
            If a Is Nothing OrElse a.IsEmpty Then
                aToString = ""
            Else
                aToString = a.ToString
            End If
            If b Is Nothing OrElse b.IsEmpty Then
                bToString = ""
            Else
                bToString = b.ToString
            End If

            Return aToString > bToString

        End Operator

        Public Shared Operator <(ByVal a As PersonGroupInfo, ByVal b As PersonGroupInfo) As Boolean

            Dim aToString, bToString As String
            If a Is Nothing OrElse a.IsEmpty Then
                aToString = ""
            Else
                aToString = a.ToString
            End If
            If b Is Nothing OrElse b.IsEmpty Then
                bToString = ""
            Else
                bToString = b.ToString
            End If

            Return aToString < bToString

        End Operator

        Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
            Dim tmp As PersonGroupInfo = TryCast(obj, PersonGroupInfo)
            If Me = tmp Then Return 0
            If Me > tmp Then Return 1
            Return -1
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return _Name
        End Function

#End Region

#Region " Factory Methods "

        Private Shared _Empty As PersonGroupInfo = Nothing

        ''' <summary>
        ''' Gets an empty PersonGroupInfo (placeholder).
        ''' </summary>
        Public Shared Function Empty() As PersonGroupInfo
            If _Empty Is Nothing Then
                _Empty = New PersonGroupInfo
            End If
            Return _Empty
        End Function

        ''' <summary>
        ''' Gets an existing person group info by a database query.
        ''' </summary>
        ''' <param name="dr">DataRow containing person group data.</param>
        Friend Shared Function GetPersonGroupInfo(ByVal dr As DataRow) As PersonGroupInfo
            Return New PersonGroupInfo(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal dr As DataRow)
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)
            _ID = CInt(dr.Item(0))
            _Name = dr.Item(1).ToString.Trim
        End Sub

#End Region

    End Class

End Namespace
