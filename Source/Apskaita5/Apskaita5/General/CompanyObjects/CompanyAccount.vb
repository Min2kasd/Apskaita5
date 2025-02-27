﻿Imports ApskaitaObjects.Attributes

Namespace General

    ''' <summary>
    ''' Represents company specific default <see cref="General.Account">account</see> 
    ''' that is used by other objects for initialization.
    ''' </summary>
    ''' <remarks>Related helper object is <see cref="Settings.CompanyInfo">CompanyInfo</see>, 
    ''' method <see cref="Settings.CompanyInfo.GetDefaultAccount">GetDefaultAccount</see>.
    ''' Values are stored in the database table companyaccounts.</remarks>
    <Serializable()> _
    Public NotInheritable Class CompanyAccount
        Inherits BusinessBase(Of CompanyAccount)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Type As DefaultAccountType = DefaultAccountType.Bank
        Private _TypeHumanReadable As String = ""
        Private _Value As Long = 0

        ''' <summary>
        ''' Gets an ID of the company account (assigned automaticaly by DB AUTOINCREMENT).
        ''' Returns 0 for a new company account.
        ''' </summary>
        ''' <remarks>Value is stored in the database field companyaccounts.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.DefaultAccountType">type</see> of the company account.
        ''' </summary>
        ''' <remarks>Value is stored in the database field companyaccounts.Code.</remarks>
        Public ReadOnly Property [Type]() As DefaultAccountType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable <see cref="General.DefaultAccountType">type</see> of the company account.
        ''' </summary>
        ''' <remarks>Value is stored in the database field companyaccounts.Code.</remarks>
        Public ReadOnly Property TypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TypeHumanReadable.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="General.Account.ID">account</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field companyaccounts.AccountValue.</remarks>
        <AccountField(ValueRequiredLevel.Recommended, False)> _
        Public Property Value() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Value
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _Value <> value Then
                    _Value = value
                    PropertyHasChanged()
                End If
            End Set
        End Property



        ''' <summary>
        ''' Gets a human readable desciption of all the validation errors.
        ''' Returns <see cref="String.Empty" /> if no errors.
        ''' </summary>
        ''' <returns>A human readable desciption of all the validation errors.
        ''' Returns <see cref="String.Empty" /> if no errors.</returns>
        ''' <remarks></remarks>
        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
        End Function

        ''' <summary>
        ''' Gets a human readable desciption of all the validation warnings.
        ''' Returns <see cref="String.Empty" /> if no warnings.
        ''' </summary>
        ''' <returns>A human readable desciption of all the validation warnings.
        ''' Returns <see cref="String.Empty" /> if no warnings.</returns>
        ''' <remarks></remarks>
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
            Return String.Format("{0} = {1}", _TypeHumanReadable, _Value.ToString)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf ValueValidation, New Csla.Validation.RuleArgs("Value"))
        End Sub

        Private Shared Function ValueValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As CompanyAccount = DirectCast(target, CompanyAccount)

            If ValObj._Value < 0 Then
                e.Description = String.Format(My.Resources.General_CompanyAccount_ValueInvalid, _
                    ValObj._TypeHumanReadable)
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf Not ValObj._Value > 0 Then
                e.Description = String.Format(My.Resources.General_CompanyAccount_ValueNull, _
                    ValObj._TypeHumanReadable)
                e.Severity = Validation.RuleSeverity.Warning
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new instance of CompanyAccount of the provided type.
        ''' </summary>
        ''' <param name="OfType">Type of a new CompanyAccount.</param>
        ''' <remarks></remarks>
        Friend Shared Function NewCompanyAccount(ByVal ofType As DefaultAccountType) As CompanyAccount
            Return New CompanyAccount(ofType)
        End Function

        ''' <summary>
        ''' Gets an existing instance of CompanyAccount by a database query.
        ''' </summary>
        ''' <param name="dr">Database query result.</param>
        ''' <remarks></remarks>
        Friend Shared Function GetCompanyAccount(ByVal dr As DataRow) As CompanyAccount
            Return New CompanyAccount(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal ofType As DefaultAccountType)
            MarkAsChild()
            Create(ofType)
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal ofType As DefaultAccountType)

            _Type = ofType
            _TypeHumanReadable = Utilities.ConvertLocalizedName(ofType)

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(0), 0)
            _Type = Utilities.ConvertDatabaseID(Of DefaultAccountType)(CIntSafe(dr.Item(1), 0))
            _TypeHumanReadable = Utilities.ConvertLocalizedName(_Type)
            _Value = CIntSafe(dr.Item(2), 0)

            ValidationRules.CheckRules()
            MarkOld()

        End Sub

        Friend Sub Insert(ByVal parent As CompanyAccountList)

            Dim myComm As New SQLCommand("InsertCompanyAccount")
            myComm.AddParam("?AA", Utilities.ConvertDatabaseID(_Type))
            myComm.AddParam("?AB", _Value)

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As CompanyAccountList)

            Dim myComm As New SQLCommand("UpdateCompanyAccount")
            myComm.AddParam("?AB", _Value)
            myComm.AddParam("?AD", _ID)

            myComm.Execute()

            MarkOld()

        End Sub

#End Region

    End Class

End Namespace