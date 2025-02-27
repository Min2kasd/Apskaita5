﻿Imports ApskaitaObjects.Assets

Namespace ActiveReports

    ''' <summary>
    ''' Represents an item of <see cref="ActiveReports.LongTermAssetComplexDocumentInfoList">LongTermAssetComplexDocumentInfoList</see> report.
    ''' Contains information about a long term asset complex documents,
    ''' e.g. <see cref="Assets.ComplexOperationDiscard">ComplexOperationDiscard</see>.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="ActiveReports.LongTermAssetComplexDocumentInfoList">LongTermAssetComplexDocumentInfoList</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class LongTermAssetComplexDocumentInfo
        Inherits ReadOnlyBase(Of LongTermAssetComplexDocumentInfo)

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Type As LtaOperationType = LtaOperationType.Discard
        Private _OperationType As String = ""
        Private _Date As Date = Today
        Private _Content As String = ""
        Private _DocumentNumber As String = ""
        Private _AttachedJournalEntryID As Integer = 0
        Private _AttachedJournalEntry As String = ""
        Private _CorrespondingAccount As Long = 0


        ''' <summary>
        ''' Gets an ID of the complex operation that is assigned by the <see cref="OperationPersistenceObject.GetNewComplexOperationID">
        ''' OperationPersistenceObject.GetNewComplexOperationID</see> method.
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.IsComplexAct.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets a type of the long term asset complex operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property [Type]() As LtaOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
        End Property

        ''' <summary>
        ''' Gets a type of the long term asset complex operation as a human readable
        ''' (localized) string.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property OperationType() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationType.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a date of the long term asset complex operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.OperationDate
        ''' (same for all the child operations).</remarks>
        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        ''' <summary>
        ''' Gets a content (description) of the long term asset complex operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.Content.
        ''' (same for all the child operations)</remarks>
        Public ReadOnly Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a number of the long term asset complex operation document.
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.ActNumber.
        ''' (same for all the child operations)</remarks>
        Public ReadOnly Property DocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.JournalEntry.ID">ID of the journal entry</see> 
        ''' that is encapsulated by or attached to the long term asset complex operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field turtas_op.JE_ID.
        ''' (same for all the child operations)</remarks>
        Public ReadOnly Property AttachedJournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AttachedJournalEntryID
            End Get
        End Property

        ''' <summary>
        ''' Gets a description of the journal entry that is encapsulated by or attached to 
        ''' the long term asset complex operation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AttachedJournalEntry() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AttachedJournalEntry.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.Account.ID">account</see> which balance was affected
        ''' by the long term asset complex operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="Assets.OperationPersistenceObject.AccountCorresponding">OperationPersistenceObject.AccountCorresponding</see>.</remarks>
        Public ReadOnly Property CorrespondingAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CorrespondingAccount
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Assets_LongTermAssetComplexDocumentInfo_ToString, _
                _Date.ToString("yyyy-MM-dd"), _OperationType, _DocumentNumber, _ID.ToString())
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetLongTermAssetComplexDocumentInfo(ByVal dr As DataRow) As LongTermAssetComplexDocumentInfo
            Return New LongTermAssetComplexDocumentInfo(dr)
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

            _ID = CIntSafe(dr.Item(0), 0)
            _Type = Utilities.ConvertDatabaseCharID(Of LtaOperationType) _
                (CStrSafe(dr.Item(1)).Trim)
            _OperationType = Utilities.ConvertLocalizedName(_Type)
            _Date = CDateSafe(dr.Item(2), Today)
            If CIntSafe(dr.Item(3), 0) > 0 Then
                _AttachedJournalEntryID = CIntSafe(dr.Item(3), 0)
                _AttachedJournalEntry = String.Format(My.Resources.Assets_LongTermAssetComplexDocumentInfo_JournalEntryDescription, _
                    CStrSafe(dr.Item(4)), GetLimitedLengthString(CStrSafe(dr.Item(5)), 100))
            Else
                _AttachedJournalEntryID = 0
                _AttachedJournalEntry = My.Resources.Assets_LongTermAssetComplexDocumentInfo_NullJournalEntryDescription
            End If
            _Content = CStrSafe(dr.Item(6)).Trim
            _CorrespondingAccount = CLongSafe(dr.Item(7), 0)
            _DocumentNumber = CStrSafe(dr.Item(8))

        End Sub

#End Region

    End Class

End Namespace