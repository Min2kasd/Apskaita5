﻿Imports ApskaitaObjects.Attributes

Namespace Documents

    ''' <summary>
    ''' Represents an offset item, an accounting entry that needs to be canceled 
    ''' with an equal but opposite entry.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="OffsetItemList">OffsetItemList</see>.
    ''' Values are stored in the database table offsetitems.</remarks>
    <Serializable()> _
    Public NotInheritable Class OffsetItem
        Inherits BusinessBase(Of OffsetItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _FinancialDataCanChange As Boolean = True
        Private _Type As BookEntryType = BookEntryType.Debetas
        Private _TypeHumanReadable As String = Utilities.ConvertLocalizedName(BookEntryType.Debetas)
        Private _Person As PersonInfo = Nothing
        Private _Account As Long = 0
        Private _Sum As Double = 0
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _CurrencyRate As Double = 1
        Private _SumLTL As Double = 0
        Private _CurrencyRateChangeImpact As Double = 0
        Private _AccountCurrencyRateChangeImpact As Long = 0
        Private _Comments As String = ""
        Private _Debit As Double = 0
        Private _Credit As Double = 0


        ''' <summary>
        ''' Gets an ID of the item that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database field offsetitems.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Returnes TRUE if the parent imprest offset operation allows financial changes due to business restrains.
        ''' </summary>
        ''' <remarks>Chronologic business restrains are provided by a <see cref="SimpleChronologicValidator">SimpleChronologicValidator</see>.</remarks>
        Public ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the type of the accounting entry.
        ''' </summary>
        ''' <remarks>Value is stored in the database field offsetitems.OffsetType.</remarks>
        Public Property [Type]() As BookEntryType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As BookEntryType)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _Type <> value Then
                    _Type = value
                    _TypeHumanReadable = Utilities.ConvertLocalizedName(_Type)
                    PropertyHasChanged()
                    PropertyHasChanged("TypeHumanReadable")
                    Recalculate(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the type of the accounting entry as a localized human readable string.
        ''' </summary>
        ''' <remarks>Value is stored in the database field offsetitems.OffsetType.</remarks>
        <LocalizedEnumField(GetType(BookEntryType), False, "")> _
        Public Property TypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TypeHumanReadable.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value Is Nothing Then value = ""
                Dim enumValue As BookEntryType = Utilities.ConvertLocalizedName(Of BookEntryType)(value)
                If _Type <> enumValue Then
                    _Type = enumValue
                    _TypeHumanReadable = Utilities.ConvertLocalizedName(enumValue)
                    PropertyHasChanged()
                    PropertyHasChanged("Type")
                    Recalculate(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="General.Person">person</see> of the accounting entry.
        ''' </summary>
        ''' <remarks>Value is stored in the database field offsetitems.PersonID.</remarks>
        <PersonField(ValueRequiredLevel.Mandatory)> _
        Public Property Person() As PersonInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Person
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As PersonInfo)
                CanWriteProperty(True)
                If PersonIsReadOnly Then Exit Property
                If Not (_Person Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Person Is Nothing AndAlso Not value Is Nothing AndAlso _Person = value) Then
                    _Person = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="General.Account.ID">account</see> of the accounting entry.
        ''' </summary>
        ''' <remarks>Value is stored in the database field offsetitems.Account.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 2, 4)> _
        Public Property Account() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountIsReadOnly Then Exit Property
                If _Account <> value Then
                    _Account = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the sum of the accounting entry in the <see cref="CurrencyCode">item's currency</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field offsetitems.SumOriginal.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If SumIsReadOnly Then Exit Property
                If CRound(_Sum) <> CRound(value) Then
                    _Sum = CRound(value)
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the currency of the accounting entry.
        ''' </summary>
        ''' <remarks>Value is stored in the database field offsetitems.CurrencyCode.</remarks>
        <CurrencyFieldAttribute(ValueRequiredLevel.Mandatory)> _
        Public Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)

                CanWriteProperty(True)

                If CurrencyCodeIsReadOnly Then Exit Property

                If value Is Nothing Then value = ""

                If Not CurrenciesEquals(_CurrencyCode, value, GetCurrentCompany.BaseCurrency) Then

                    _CurrencyCode = value.Trim
                    PropertyHasChanged()

                    Dim newCurrencyRate As Double = 0.0

                    If IsBaseCurrency(_CurrencyCode, GetCurrentCompany.BaseCurrency) Then

                        newCurrencyRate = 1

                        _CurrencyRateChangeImpact = 0.0
                        _AccountCurrencyRateChangeImpact = 0

                        PropertyHasChanged("CurrencyRateChangeImpact")
                        PropertyHasChanged("AccountCurrencyRateChangeImpact")

                    End If

                    If CRound(_CurrencyRate) <> CRound(newCurrencyRate) Then
                        _CurrencyRate = newCurrencyRate
                        PropertyHasChanged("CurrencyRate")
                    End If

                    Recalculate(True)

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the currency rate of the accounting entry.
        ''' </summary>
        ''' <remarks>Value is stored in the database field offsetitems.CurrencyRate.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDCURRENCYRATE)> _
        Public Property CurrencyRate() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRate, ROUNDCURRENCYRATE)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CurrencyRateIsReadOnly Then Exit Property
                If CRound(_CurrencyRate, ROUNDCURRENCYRATE) <> CRound(value, ROUNDCURRENCYRATE) Then
                    _CurrencyRate = CRound(value, ROUNDCURRENCYRATE)
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the sum of the accounting entry in the base currency.
        ''' </summary>
        ''' <remarks>Calculated as a product of <see cref="Sum">Sum</see> and 
        ''' <see cref="CurrencyRate">CurrencyRate</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property SumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the sum of the currency rate change effect. 
        ''' Positive value is treated as revenue, negative value is treated as costs.
        ''' </summary>
        ''' <remarks>Value is stored in the database table offsetitems.CurrencyRateChangeImpact.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public Property CurrencyRateChangeImpact() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateChangeImpact)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CurrencyRateChangeImpactIsReadOnly Then Exit Property
                If CRound(_CurrencyRateChangeImpact) <> CRound(value) Then
                    _CurrencyRateChangeImpact = CRound(value)
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="General.Account.ID">account</see> for the currency rate change effect.
        ''' </summary>
        ''' <remarks>Value is stored in the database table offsetitems.AccountCurrencyRateChangeImpact.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 5, 6)> _
        Public Property AccountCurrencyRateChangeImpact() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountCurrencyRateChangeImpact
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountCurrencyRateChangeImpactIsReadOnly Then Exit Property
                If _AccountCurrencyRateChangeImpact <> value Then
                    _AccountCurrencyRateChangeImpact = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the user comments for the accounting entry.
        ''' </summary>
        ''' <remarks>Value is stored in the database field offsetitems.Comments.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255)> _
        Public Property Comments() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Comments.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Comments <> value.Trim Then
                    _Comments = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a total debit entry sum.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property Debit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Debit)
            End Get
        End Property

        ''' <summary>
        ''' Gets a total credit entry sum.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property Credit() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Credit)
            End Get
        End Property


        ''' <summary>
        ''' Gets whether the <see cref="Person">Person</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property PersonIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="Account">Account</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="Sum">Sum</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="CurrencyCode">CurrencyCode</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrencyCodeIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="CurrencyRate">CurrencyRate</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrencyRateIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (Not _FinancialDataCanChange OrElse IsBaseCurrency(_CurrencyCode, GetCurrentCompany().BaseCurrency))
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="CurrencyRateChangeImpact">CurrencyRateChangeImpact</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrencyRateChangeImpactIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (Not _FinancialDataCanChange OrElse IsBaseCurrency(_CurrencyCode, GetCurrentCompany().BaseCurrency))
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="AccountCurrencyRateChangeImpact">AccountCurrencyRateChangeImpact</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountCurrencyRateChangeImpactIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (Not _FinancialDataCanChange OrElse IsBaseCurrency(_CurrencyCode, GetCurrentCompany().BaseCurrency))
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


        Private Sub Recalculate(ByVal raisePropertyChangedEvents As Boolean)

            _SumLTL = CRound(_Sum * _CurrencyRate)

            If _Type = BookEntryType.Debetas Then

                _Debit = CRound(_SumLTL + Math.Abs(_CurrencyRateChangeImpact))
                _Credit = Math.Abs(_CurrencyRateChangeImpact)

            Else

                _Credit = CRound(_SumLTL + Math.Abs(_CurrencyRateChangeImpact))
                _Debit = Math.Abs(_CurrencyRateChangeImpact)

            End If

            If raisePropertyChangedEvents Then
                PropertyHasChanged("SumLTL")
                PropertyHasChanged("Debit")
                PropertyHasChanged("Credit")
            End If


        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String

            Dim personString As String = My.Resources.Documents_OffsetItem_NullPersonName
            If Not _Person Is Nothing AndAlso Not _Person.IsEmpty Then
                personString = _Person.ToString
            End If

            Return String.Format(My.Resources.Documents_OffsetItem_ToString, _
                _Account.ToString(), DblParser(_Sum), _CurrencyCode, personString)

        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Validation.RuleArgs("Sum"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Validation.RuleArgs("CurrencyRate"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("Comments"))
            ValidationRules.AddRule(AddressOf CommonValidation.AccountFieldValidation, _
                New Validation.RuleArgs("Account"))
            ValidationRules.AddRule(AddressOf CommonValidation.PersonFieldValidation, _
                New Validation.RuleArgs("Person"))
            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyFieldValidation, _
                New Validation.RuleArgs("CurrencyCode"))


            ValidationRules.AddRule(AddressOf AccountCurrencyRateChangeImpactValidation, _
                New Validation.RuleArgs("AccountCurrencyRateChangeImpact"))

            ValidationRules.AddDependantProperty("CurrencyRateChangeImpact", _
                "AccountCurrencyRateChangeImpact", False)
            ValidationRules.AddDependantProperty("CurrencyCode", _
                "AccountCurrencyRateChangeImpact", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property AccountCurrencyRateChangeImpact is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountCurrencyRateChangeImpactValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As OffsetItem = DirectCast(target, OffsetItem)

            If CRound(valObj._CurrencyRateChangeImpact) = 0.0 Then Return True

            If IsBaseCurrency(valObj._CurrencyCode, GetCurrentCompany.BaseCurrency) Then

                e.Description = "Valiutos kurso pasikeitimo įtaka gali atsirasti tik jei naudojama valiuta."
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return CommonValidation.CommonValidation.AccountFieldValidation(target, e)

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewOffsetItem() As OffsetItem
            Dim result As New OffsetItem
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function GetOffsetItem(ByVal dr As DataRow, ByVal nFinancialDataCanChange As Boolean) As OffsetItem
            Return New OffsetItem(dr, nFinancialDataCanChange)
        End Function

        Friend Shared Function GetBalanceOffsetItem(ByVal itemID As Integer, ByVal balanceSum As Double, _
            ByVal balanceAccount As Long) As OffsetItem
            If (CRound(balanceSum) = 0 OrElse Not balanceAccount > 0) AndAlso Not itemID > 0 Then Return Nothing
            Return New OffsetItem(itemID, balanceSum, balanceAccount)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal nFinancialDataCanChange As Boolean)
            MarkAsChild()
            Fetch(dr, nFinancialDataCanChange)
        End Sub

        Private Sub New(ByVal itemID As Integer, ByVal balanceSum As Double, ByVal balanceAccount As Long)
            Create(itemID, balanceSum, balanceAccount)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal itemID As Integer, ByVal balanceSum As Double, ByVal balanceAccount As Long)

            _ID = itemID

            If CRound(balanceSum) > 0 Then
                _Type = BookEntryType.Kreditas
                _Sum = CRound(balanceSum)
            Else
                _Type = BookEntryType.Debetas
                _Sum = CRound(-balanceSum)
            End If

            _Account = balanceAccount
            _Comments = My.Resources.Documents_OffsetItem_BalanceItemComment
            _CurrencyCode = GetCurrentCompany.BaseCurrency
            _CurrencyRate = 1

            Recalculate(False)

            If _ID > 0 Then
                MarkOld()
                MarkDirty()
            End If

        End Sub

        Private Sub Fetch(ByVal dr As DataRow, ByVal nFinancialDataCanChange As Boolean)

            _ID = CIntSafe(dr.Item(0), 0)
            _Sum = CDblSafe(dr.Item(1), 2, 0)
            _CurrencyCode = CStrSafe(dr.Item(2)).Trim
            _CurrencyRate = CDblSafe(dr.Item(3), ROUNDCURRENCYRATE, 0)
            _CurrencyRateChangeImpact = CDblSafe(dr.Item(4), 2, 0)
            _Type = Utilities.ConvertDatabaseCharID(Of BookEntryType)(CStrSafe(dr.Item(5)))
            _TypeHumanReadable = Utilities.ConvertLocalizedName(_Type)
            _Account = CLongSafe(dr.Item(6), 0)
            _AccountCurrencyRateChangeImpact = CLongSafe(dr.Item(7), 0)
            _Comments = CStrSafe(dr.Item(8)).Trim
            _Person = PersonInfo.GetPersonInfo(dr, 9)

            Recalculate(False)

            _FinancialDataCanChange = nFinancialDataCanChange

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert(ByVal parent As Offset)

            Dim myComm As New SQLCommand("InsertOffsetItem")
            myComm.AddParam("?AA", parent.ID)
            AddWithParams(myComm)
            myComm.AddParam("?AJ", _Comments.Trim)

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As Offset)

            Dim myComm As SQLCommand
            If parent.ChronologicValidator.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateOffsetItem")
                AddWithParams(myComm)
            Else
                myComm = New SQLCommand("UpdateOffsetItemNonFinancial")
            End If
            myComm.AddParam("?CD", _ID)
            myComm.AddParam("?AJ", _Comments.Trim)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteOffsetItem")
            myComm.AddParam("?CD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub


        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AB", CRound(_Sum))
            myComm.AddParam("?AC", _CurrencyCode.Trim)
            myComm.AddParam("?AD", CRound(_CurrencyRate, ROUNDCURRENCYRATE))
            myComm.AddParam("?AE", CRound(_CurrencyRateChangeImpact))
            myComm.AddParam("?AF", Utilities.ConvertDatabaseCharID(_Type))
            If Not _Person Is Nothing AndAlso Not _Person.IsEmpty Then
                myComm.AddParam("?AG", _Person.ID)
            Else
                myComm.AddParam("?AG", 0)
            End If
            myComm.AddParam("?AH", _Account)
            myComm.AddParam("?AI", _AccountCurrencyRateChangeImpact)

        End Sub

        Friend Function GetBookEntryList() As BookEntryInternalList

            Dim result As BookEntryInternalList = BookEntryInternalList. _
                NewBookEntryInternalList(BookEntryType.Debetas)

            result.Add(BookEntryInternal.NewBookEntryInternal(_Type, _Account, _SumLTL, _Person))

            If CRound(_CurrencyRateChangeImpact) <> 0.0 AndAlso _AccountCurrencyRateChangeImpact > 0 Then

                If CRound(_CurrencyRateChangeImpact) > 0 Then
                    result.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, _AccountCurrencyRateChangeImpact, _
                        _CurrencyRateChangeImpact, Nothing))
                    result.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, _Account, _CurrencyRateChangeImpact, _Person))
                Else
                    result.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, _AccountCurrencyRateChangeImpact, _
                        -_CurrencyRateChangeImpact, Nothing))
                    result.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, _Account, -_CurrencyRateChangeImpact, _Person))
                End If

            End If

            Return result

        End Function

#End Region

    End Class

End Namespace