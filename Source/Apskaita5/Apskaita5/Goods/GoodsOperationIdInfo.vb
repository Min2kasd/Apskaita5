﻿Namespace Goods

    ''' <summary>
    ''' Represents a helper object that could be used to fetch a goods
    ''' operation id's and type by a journal entry ID.
    ''' </summary>
    ''' <remarks>Used to provide goods operation access from other
    ''' program modules, e.g. to open operation form from a general ledger.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsOperationIdInfo
        Inherits ReadOnlyBase(Of GoodsOperationIdInfo)

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Type As GoodsOperationType = GoodsOperationType.Discard
        Private _ComplexType As GoodsComplexOperationType = GoodsComplexOperationType.BulkDiscard
        Private _IsComplex As Boolean = False
        Private _JournalEntryID As Integer = 0
        Private _DocumentType As DocumentType = DocumentType.GoodsWriteOff


        ''' <summary>
        ''' An ID of the goods operation, e.g. <see cref="GoodsOperationAcquisition.ID">
        ''' GoodsOperationAcquisition.ID</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' A type of the simple goods operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property [Type]() As GoodsOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
        End Property

        ''' <summary>
        ''' A type of the complex goods operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ComplexType() As GoodsComplexOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexType
            End Get
        End Property

        ''' <summary>
        ''' Whether the goods operation is a complex operation, e.g. 
        ''' <see cref="GoodsComplexOperationDiscard">GoodsComplexOperationDiscard</see>
        ''' versus <see cref="GoodsOperationDiscard">GoodsOperationDiscard</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsComplex() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsComplex
            End Get
        End Property

        ''' <summary>
        ''' An ID of the <see cref="General.JournalEntry.ID">journal entry</see> 
        ''' that is encapsulated by or associated with the goods operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        ''' <summary>
        ''' A document type of the <see cref="General.JournalEntry.DocType">journal entry</see> 
        ''' that is encapsulated by or associated with the goods operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DocumentType() As DocumentType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentType
            End Get
        End Property


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            If _IsComplex Then
                Return String.Format(My.Resources.Goods_GoodsOperationIdInfo_ToString, _
                    Utilities.ConvertLocalizedName(_ComplexType), _ID.ToString, _JournalEntryID.ToString)
            Else
                Return String.Format(My.Resources.Goods_GoodsOperationIdInfo_ToString, _
                    Utilities.ConvertLocalizedName(_Type), _ID.ToString, _JournalEntryID.ToString)
            End If
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("HelperLists.GoodsOperationIdInfo1")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new GoodsOperationIdInfo instance, i.e. readonly goods operation 
        ''' identification data.
        ''' </summary>
        ''' <param name="journalEntryID">an ID of the <see cref="General.JournalEntry.ID">journal entry</see> to look by</param>
        ''' <param name="documentType">an expected document type of the <see cref="General.JournalEntry.DocType">journal entry</see></param>
        ''' <remarks></remarks>
        Public Shared Function GetGoodsOperationIdInfo(ByVal journalEntryID As Integer, _
            ByVal documentType As DocumentType) As GoodsOperationIdInfo
            Return DataPortal.Fetch(Of GoodsOperationIdInfo)(New Criteria(journalEntryID, documentType))
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Private _DocumentType As DocumentType
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public ReadOnly Property DocumentType() As DocumentType
                Get
                    Return _DocumentType
                End Get
            End Property
            Public Sub New(ByVal nID As Integer, ByVal nDocumentType As DocumentType)
                _ID = nID
                _DocumentType = nDocumentType
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchGoodsOperationIdInfo")
            myComm.AddParam("?JD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Goods_GoodsOperationIdInfo_OperationNotFound, _
                    criteria.ID.ToString()))

                _JournalEntryID = criteria.ID
                _DocumentType = criteria.DocumentType

                ' find a complex operation if any
                For Each dr As DataRow In myData.Rows
                    If CIntSafe(dr.Item(0), 0) > 0 Then

                        _ID = CIntSafe(dr.Item(1), 0)
                        _ComplexType = ConvertDatabaseID(Of GoodsComplexOperationType) _
                            (CIntSafe(dr.Item(2), 0))
                        _IsComplex = True

                        Exit Sub

                    End If
                Next

                ' find a simple operation if any
                For Each dr As DataRow In myData.Rows

                    If criteria.DocumentType = DocumentType.GoodsAccountChange Then

                        Dim t As GoodsOperationType = ConvertDatabaseID(Of GoodsOperationType) _
                            (CIntSafe(dr.Item(2), 0))

                        If t = GoodsOperationType.AccountDiscountsChange OrElse _
                            t = GoodsOperationType.AccountPurchasesChange OrElse _
                            t = GoodsOperationType.AccountSalesNetCostsChange OrElse _
                            t = GoodsOperationType.AccountValueReductionChange Then

                            _ID = CIntSafe(dr.Item(1), 0)
                            _Type = t
                            _IsComplex = False

                            Exit Sub

                        End If

                    ElseIf criteria.DocumentType = DocumentType.GoodsRevalue AndAlso _
                        ConvertDatabaseID(Of GoodsOperationType)(CIntSafe(dr.Item(2), 0)) _
                        = GoodsOperationType.PriceCut Then

                        _ID = CIntSafe(dr.Item(1), 0)
                        _Type = GoodsOperationType.PriceCut
                        _IsComplex = False

                        Exit Sub

                    ElseIf criteria.DocumentType = DocumentType.GoodsWriteOff AndAlso _
                        ConvertDatabaseID(Of GoodsOperationType)(CIntSafe(dr.Item(2), 0)) _
                        = GoodsOperationType.Discard Then

                        _ID = CIntSafe(dr.Item(1), 0)
                        _Type = GoodsOperationType.Discard
                        _IsComplex = False

                        Exit Sub

                    End If

                Next

                Dim foundTypes As String = ""
                For Each dr As DataRow In myData.Rows

                    If ConvertDbBoolean(CIntSafe(dr.Item(0), 0)) Then
                        foundTypes = AddWithNewLine(foundTypes, Utilities.ConvertLocalizedName( _
                            Utilities.ConvertDatabaseID(Of GoodsComplexOperationType)(CIntSafe(dr.Item(2), 0))), False)
                    Else
                        foundTypes = AddWithNewLine(foundTypes, Utilities.ConvertLocalizedName( _
                            Utilities.ConvertDatabaseID(Of GoodsOperationType)(CIntSafe(dr.Item(2), 0))), False)
                    End If

                Next

                Throw New Exception(String.Format(My.Resources.Goods_GoodsOperationIdInfo_InvalidOperationType, _
                    Utilities.ConvertLocalizedName(criteria.DocumentType), vbCrLf, foundTypes))

            End Using

        End Sub

#End Region

    End Class

End Namespace