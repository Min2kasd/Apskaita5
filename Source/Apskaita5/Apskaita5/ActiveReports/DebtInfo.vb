﻿Imports ApskaitaObjects.Attributes

Namespace ActiveReports

    ''' <summary>
    ''' Represents an item of a <see cref="DebtInfoList">DebtInfoList</see> report.
    ''' Contains information about a person and it's trade and settlement turnover.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="DebtInfoList">DebtInfoList</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class DebtInfo
        Inherits ReadOnlyBase(Of DebtInfo)

#Region " Business Methods "

        Private _PersonID As Integer = 0
        Private _PersonName As String = ""
        Private _PersonCode As String = ""
        Private _PersonVatCode As String = ""
        Private _PersonGroup As String = ""
        Private _PersonAddress As String = ""
        Private _DebtBegin As Double = 0
        Private _TurnoverDebet As Double = 0
        Private _TurnoverCredit As Double = 0
        Private _DebtEnd As Double = 0


        ''' <summary>
        ''' Gets an ID of the person.
        ''' </summary>
        ''' <remarks>Corresponds to the <see cref="General.Person.ID">Person.ID</see> property.</remarks>
        Public ReadOnly Property PersonID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonID
            End Get
        End Property

        ''' <summary>
        ''' Gets a name of the person.
        ''' </summary>
        ''' <remarks>Corresponds to the <see cref="General.Person.Name">Person.Name</see> property.</remarks>
        Public ReadOnly Property PersonName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonName.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a company/personal code of the person.
        ''' </summary>
        ''' <remarks>Corresponds to the <see cref="General.Person.Code">Person.Code</see> property.</remarks>
        Public ReadOnly Property PersonCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a VAT code of the person.
        ''' </summary>
        ''' <remarks>Corresponds to the <see cref="General.Person.CodeVAT">Person.CodeVAT</see> property.</remarks>
        Public ReadOnly Property PersonVatCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonVatCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets comma separated names of the <see cref="General.PersonGroup">groups</see> 
        ''' that the person is assigned to.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property PersonGroup() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonGroup.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets an address of the person.
        ''' </summary>
        ''' <remarks>Corresponds to the <see cref="General.Person.Address">Person.Address</see> property.</remarks>
        Public ReadOnly Property PersonAddress() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonAddress.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a person's debt at the <see cref="DebtInfoList.DateFrom">start of the report period</see>.
        ''' </summary>
        ''' <remarks>In case <see cref="DebtInfoList.IsBuyer">the report is fetched for buyers</see>
        ''' represents a debit balance for the person, otherwise - a credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property DebtBegin() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DebtBegin)
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID of the person.
        ''' </summary>
        ''' <remarks>Corresponds to the <see cref="General.Person.ID">Person.ID</see> property.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property TurnoverDebet() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TurnoverDebet)
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID of the person.
        ''' </summary>
        ''' <remarks>Corresponds to the <see cref="General.Person.ID">Person.ID</see> property.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property TurnoverCredit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TurnoverCredit)
            End Get
        End Property

        ''' <summary>
        ''' Gets a person's debt at the <see cref="DebtInfoList.DateTo">end of the report period</see>.
        ''' </summary>
        ''' <remarks>In case <see cref="DebtInfoList.IsBuyer">the report is fetched for buyers</see>
        ''' represents a debit balance for the person, otherwise - a credit balance.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property DebtEnd() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DebtEnd)
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _PersonID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.ActiveReports_DebtInfo_ToString, _
                _PersonName, _PersonCode, DblParser(_DebtEnd))
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetDebtInfo(ByVal dr As DataRow, ByVal nIsBuyer As Boolean) As DebtInfo
            Return New DebtInfo(dr, nIsBuyer)
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal nIsBuyer As Boolean)
            Fetch(dr, nIsBuyer)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow, ByVal nIsBuyer As Boolean)

            _PersonID = CIntSafe(dr.Item(0), 0)
            _PersonName = CStrSafe(dr.Item(1)).Trim
            _PersonCode = CStrSafe(dr.Item(2)).Trim
            _PersonVatCode = CStrSafe(dr.Item(3)).Trim
            _PersonAddress = CStrSafe(dr.Item(4)).Trim
            _PersonGroup = CStrSafe(dr.Item(5)).Trim

            If nIsBuyer Then
                _DebtBegin = CRound(CDblSafe(dr.Item(6), 2, 0) - CDblSafe(dr.Item(7), 2, 0))
            Else
                _DebtBegin = CRound(CDblSafe(dr.Item(7), 2, 0) - CDblSafe(dr.Item(6), 2, 0))
            End If

            _TurnoverDebet = CDblSafe(dr.Item(8), 2, 0)
            _TurnoverCredit = CDblSafe(dr.Item(9), 2, 0)

            If nIsBuyer Then
                _DebtEnd = CRound(_DebtBegin + _TurnoverDebet - _TurnoverCredit)
            Else
                _DebtEnd = CRound(_DebtBegin - _TurnoverDebet + _TurnoverCredit)
            End If

        End Sub

#End Region

    End Class

End Namespace
