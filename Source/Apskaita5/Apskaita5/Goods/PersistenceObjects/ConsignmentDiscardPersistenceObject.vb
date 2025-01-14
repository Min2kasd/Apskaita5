﻿Imports ApskaitaObjects.My.Resources

Namespace Goods

    ''' <summary>
    ''' Represents a <see cref="ConsignmentPersistenceObject">goods consignment</see>
    ''' discard transaction item.
    ''' </summary>
    ''' <remarks>Discards a certain amount of goods in a <see cref="ConsignmentPersistenceObject">
    ''' goods consignment</see> when the goods are transfered from a warehouse
    ''' or discarded.
    ''' Should only be used as a parent of <see cref="ConsignmentDiscardPersistenceObjectList">ConsignmentDiscardPersistenceObjectList</see>.
    ''' Values are stored in the database table consignmentdiscards.</remarks>
    <Serializable()> _
    Friend Class ConsignmentDiscardPersistenceObject
        Inherits BusinessBase(Of ConsignmentDiscardPersistenceObject)

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _ParentID As Integer = 0
        Private _ConsignmentID As Integer = 0
        Private _Amount As Double = 0
        Private _TotalValue As Double = 0


        ''' <summary>
        ''' Gets an ID of the consignment discard item that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database field consignmentdiscards.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID of the parent goods operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field consignmentdiscards.ParentID.</remarks>
        Public ReadOnly Property ParentID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ParentID
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID of the goods consignment that the goods are beeing discarded from.
        ''' </summary>
        ''' <remarks>Value is stored in the database field consignmentdiscards.ConsignmentID.</remarks>
        Public ReadOnly Property ConsignmentID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ConsignmentID
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets an amount of the goods discarded.
        ''' </summary>
        ''' <remarks>Value is stored in the database field consignmentdiscards.Amount.</remarks>
        Public Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount, ROUNDAMOUNTGOODS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Amount, ROUNDAMOUNTGOODS) <> CRound(value, ROUNDAMOUNTGOODS) Then
                    _Amount = CRound(value, ROUNDAMOUNTGOODS)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a total value of the goods discarded.
        ''' </summary>
        ''' <remarks>Value is stored in the database field consignmentdiscards.Amount.</remarks>
        Public Property TotalValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValue)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_TotalValue) <> CRound(value) Then
                    _TotalValue = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(Goods_ConsignmentDiscardPersistenceObject_ToString, _
                _ConsignmentID.ToString, DblParser(_Amount, ROUNDAMOUNTGOODS), _
                DblParser(_TotalValue, 2), _ID.ToString)
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new ConsignmentDiscardPersistenceObject instance
        ''' that discards a specified amount of the goods from the consignment specified.
        ''' Retuns amount left to discard as an out parameter.
        ''' </summary>
        ''' <param name="acquisitionConsignement">a goods consignment that the
        ''' good should be discarded from</param>
        ''' <param name="amountToWithdraw">an amount of the goods to discard;
        ''' the value is reduced by the actual amount of the goods that
        ''' is ""taken out"" from the consignment.</param>
        ''' <remarks>Used in goods operations that need to discard a specified
        ''' amount of goods from the consignments available, e.g.
        ''' <see cref="GoodsOperationDiscard">GoodsOperationDiscard</see>.
        ''' Used to iterate through available consignments and to
        ''' generate a consignments discard list based on the amount
        ''' that needs to be discarded.</remarks>
        Friend Shared Function NewConsignmentDiscardPersistenceObject( _
            ByVal acquisitionConsignement As ConsignmentPersistenceObject, _
            ByRef amountToWithdraw As Double) As ConsignmentDiscardPersistenceObject

            Dim result As New ConsignmentDiscardPersistenceObject

            If Not CRound(amountToWithdraw, ROUNDAMOUNTGOODS) >= 0 Then
                Throw New ArgumentException(Goods_ConsignmentDiscardPersistenceObject_AmountInvalid)
            End If
            If acquisitionConsignement Is Nothing OrElse Not acquisitionConsignement.ID > 0 _
               OrElse Not acquisitionConsignement.ParentID > 0 Then
                Throw New ArgumentNullException(Goods_ConsignmentDiscardPersistenceObject_ConsignmentInvalid)
            End If

            result._ConsignmentID = acquisitionConsignement.ID

            If CRound(amountToWithdraw, ROUNDAMOUNTGOODS) >= acquisitionConsignement.AmountLeft Then
                result._Amount = acquisitionConsignement.AmountLeft
                result._TotalValue = acquisitionConsignement.TotalValueLeft
                amountToWithdraw = CRound(amountToWithdraw - acquisitionConsignement.AmountLeft, ROUNDAMOUNTGOODS)
            Else
                result._Amount = CRound(amountToWithdraw, ROUNDAMOUNTGOODS)
                result._TotalValue = CRound(CRound(amountToWithdraw, ROUNDAMOUNTGOODS) _
                    * acquisitionConsignement.UnitValue, 2)
                amountToWithdraw = 0
            End If

            Return result

        End Function

        ''' <summary>
        ''' Gets a new ConsignmentDiscardPersistenceObject instance
        ''' that discards the whole consignment specified.</summary>
        ''' <param name="acquisitionConsignement">a goods consignment that the
        ''' good should be discarded entirely</param>
        ''' <remarks>Used in goods operations that need to modify existing
        ''' consignments, i.e. discard an existing consignment and
        ''' add a modified consignment instead, e.g. <see cref="GoodsOperationAdditionalCosts">GoodsOperationAdditionalCosts</see>.</remarks>
        Friend Shared Function NewConsignmentDiscardPersistenceObject( _
            ByVal acquisitionConsignement As ConsignmentItem) As ConsignmentDiscardPersistenceObject

            Dim result As New ConsignmentDiscardPersistenceObject

            If acquisitionConsignement Is Nothing OrElse Not acquisitionConsignement.ID > 0 _
                OrElse Not acquisitionConsignement.ParentID > 0 Then
                Throw New ArgumentNullException(Goods_ConsignmentDiscardPersistenceObject_ConsignmentInvalid)
            End If

            result._ConsignmentID = acquisitionConsignement.ID
            result._Amount = acquisitionConsignement.AmountLeft
            result._TotalValue = acquisitionConsignement.TotalValueLeft

            Return result

        End Function

        ''' <summary>
        ''' Gets an existing ConsignmentDiscardPersistenceObject instance from a database.
        ''' </summary>
        ''' <param name="dr">a database query result</param>
        ''' <remarks></remarks>
        Friend Shared Function GetConsignmentDiscardPersistenceObject(ByVal dr As DataRow) _
            As ConsignmentDiscardPersistenceObject
            Return New ConsignmentDiscardPersistenceObject(dr)
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
            _ParentID = CIntSafe(dr.Item(1), 0)
            _ConsignmentID = CIntSafe(dr.Item(2), 0)
            _Amount = CDblSafe(dr.Item(3), ROUNDAMOUNTGOODS, 0)
            _TotalValue = CDblSafe(dr.Item(4), 2, 0)

            MarkOld()

        End Sub

        Friend Sub Insert(ByVal nparentID As Integer)

            _ParentID = nparentID

            Dim myComm As New SQLCommand("InsertConsignmentDiscardPersistenceObject")
            AddWithParams(myComm)
            myComm.AddParam("?AA", _ParentID)
            myComm.AddParam("?AB", _ConsignmentID)

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update()

            Dim myComm As New SQLCommand("UpdateConsignmentDiscardPersistenceObject")
            myComm.AddParam("?CD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()
            DeleteSelf(_ID)
            MarkNew()
        End Sub

        Friend Shared Sub DeleteSelf(ByVal consignmentDiscardID As Integer)

            Dim myComm As New SQLCommand("DeleteConsignmentDiscardPersistenceObject")
            myComm.AddParam("?CD", consignmentDiscardID)

            myComm.Execute()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AC", CRound(_Amount, ROUNDAMOUNTGOODS))
            myComm.AddParam("?AD", CRound(_TotalValue))

        End Sub


#End Region

    End Class

End Namespace