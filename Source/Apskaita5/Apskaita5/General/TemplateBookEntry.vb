﻿Imports ApskaitaObjects.Attributes

Namespace General

    ''' <summary>
    ''' Represents a template for a single <see cref="General.BookEntry">ledger transaction</see> that credits or debits certain <see cref="General.Account">Account</see>.
    ''' Can only be used as a child object for <see cref="General.TemplateBookEntryList">TemplateBookEntryList</see>
    ''' </summary>
    ''' <remarks>Related helper object (value object list) is <see cref="HelperLists.TemplateJournalEntryInfoList">TemplateJournalEntryInfoList</see>
    ''' Values are stored in the database table tipines_data.</remarks>
    <Serializable()> _
    Public NotInheritable Class TemplateBookEntry
        Inherits BusinessBase(Of TemplateBookEntry)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Account As Long = 0

        ''' <summary>
        ''' Returns an ID of the template entry that is asigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database field tipines_data.D_ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Represents <see cref="General.Account.ID">the number of the account</see> that is affected by the transaction.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.AccountInfoList">AccountInfoList</see> for the datasource.
        ''' Value is stored in the database field tipines_data.T_saskaita.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False)> _
        Public Property Account() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _Account <> value Then
                    _Account = value
                    PropertyHasChanged()
                End If
            End Set
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
            Return _Account.ToString
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.AccountFieldValidation, _
                New Csla.Validation.RuleArgs("Account"))
        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Get a new empty TemplateBookEntry.
        ''' </summary>
        Friend Shared Function NewTemplateBookEntry() As TemplateBookEntry
            Dim result As New TemplateBookEntry
            result.ValidationRules.CheckRules()
            Return result
        End Function

        ''' <summary>
        ''' Get an existing TemplateBookEntry from database.
        ''' </summary>
        ''' <param name="dr">DataRow returned by database query.</param>
        Friend Shared Function GetTemplateBookEntry(ByVal dr As DataRow) As TemplateBookEntry
            Return New TemplateBookEntry(dr)
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

            _ID = CIntSafe(dr.Item(0))
            _Account = CLongSafe(dr.Item(2))

            MarkOld()

        End Sub

        Friend Sub Insert(ByVal parentlist As TemplateBookEntryList, _
            ByVal parent As TemplateJournalEntry)

            Dim myComm As New SQLCommand("InsertTemplateBookEntry")
            myComm.AddParam("?AA", _Account)
            myComm.AddParam("?LD", parent.ID)
            myComm.AddParam("?TP", Utilities.ConvertDatabaseCharID(parentlist.Type))

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parentlist As TemplateBookEntryList, _
            ByVal parent As TemplateJournalEntry)

            Dim myComm As New SQLCommand("UpdateTemplateBookEntry")
            myComm.AddParam("?AA", _Account)
            myComm.AddParam("?TD", _ID)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteTemplateBookEntry")
            myComm.AddParam("?TD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub

#End Region

    End Class

End Namespace