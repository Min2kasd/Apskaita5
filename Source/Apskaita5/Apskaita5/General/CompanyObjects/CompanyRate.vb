﻿Imports ApskaitaObjects.Attributes

Namespace General

    ''' <summary>
    ''' Represents a company specific default rate (tax, wage, etc.), 
    ''' that is used by other objects for initialization.
    ''' </summary>
    ''' <remarks>Related helper object is <see cref="ApskaitaObjects.Settings.CompanyInfo">CompanyInfo</see>, 
    ''' method <see cref="ApskaitaObjects.Settings.CompanyInfo.GetDefaultRate">GetDefaultRate</see>.
    ''' Values are stored in the database table companyrates.</remarks>
    <Serializable()> _
    Public NotInheritable Class CompanyRate
        Inherits BusinessBase(Of CompanyRate)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Type As DefaultRateType = DefaultRateType.Vat
        Private _TypeHumanReadable As String = ""
        Private _Value As Double = 0

        ''' <summary>
        ''' Gets an ID of the company rate (assigned automaticaly by DB AUTOINCREMENT).
        ''' Returns 0 for a new company rate.
        ''' </summary>
        ''' <remarks>Value is stored in the database field companyrates.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="DefaultRateType">rate type</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field companyrates.Code.</remarks>
        Public ReadOnly Property [Type]() As DefaultRateType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable (localized) description of <see cref="DefaultRateType">rate type</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field companyrates.Code.</remarks>
        Public ReadOnly Property TypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TypeHumanReadable.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the rate value.
        ''' </summary>
        ''' <remarks>Value is stored in the database field companyrates.RateValue.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2)> _
        Public Property Value() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Value)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If value < 0 Then value = 0
                If CRound(_Value) <> CRound(value) Then
                    _Value = CRound(value)
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
            Return String.Format("{0} = {1} %", _TypeHumanReadable, _Value.ToString("##,0.00"))
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf ValueValidation, New Validation.RuleArgs("Value"))
        End Sub

        Private Shared Function ValueValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As CompanyRate = DirectCast(target, CompanyRate)

            If CRound(ValObj._Value, 2) < 0 Then
                e.Description = String.Format(My.Resources.General_CompanyRate_ValueInvalid, _
                    ValObj._TypeHumanReadable)
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf Not CRound(ValObj._Value, 2) > 0 Then
                e.Description = String.Format(My.Resources.General_CompanyRate_ValueNull, _
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
        ''' Gets a new instance of CompanyRate of the provided type.
        ''' </summary>
        ''' <param name="ofType">Type of a new CompanyRate.</param>
        ''' <remarks></remarks>
        Friend Shared Function NewCompanyRate(ByVal ofType As DefaultRateType) As CompanyRate
            Return New CompanyRate(ofType)
        End Function

        ''' <summary>
        ''' Gets an existing instance of CompanyRate by a database query.
        ''' </summary>
        ''' <param name="dr">Database query result.</param>
        ''' <remarks></remarks>
        Friend Shared Function GetCompanyRate(ByVal dr As DataRow) As CompanyRate
            Return New CompanyRate(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal ofType As DefaultRateType)
            MarkAsChild()
            Create(ofType)
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal ofType As DefaultRateType)

            _Type = ofType
            _TypeHumanReadable = Utilities.ConvertLocalizedName(ofType)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(0), 0)
            _Type = Utilities.ConvertDatabaseID(Of DefaultRateType)(CIntSafe(dr.Item(1), 0))
            _TypeHumanReadable = Utilities.ConvertLocalizedName(_Type)
            _Value = CDblSafe(dr.Item(2), 2, 0)

            ValidationRules.CheckRules()
            MarkOld()

        End Sub

        Friend Sub Insert(ByVal parent As CompanyRateList)

            Dim myComm As New SQLCommand("InsertCompanyRate")
            myComm.AddParam("?AA", Utilities.ConvertDatabaseID(_Type))
            myComm.AddParam("?AB", CRound(_Value))

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As CompanyRateList)

            Dim myComm As New SQLCommand("UpdateCompanyRate")
            myComm.AddParam("?RD", _ID)
            myComm.AddParam("?AB", CRound(_Value))

            myComm.Execute()

            MarkOld()

        End Sub

#End Region

    End Class

End Namespace