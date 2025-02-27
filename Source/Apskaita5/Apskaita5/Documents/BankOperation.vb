﻿Imports ApskaitaObjects.HelperLists
Imports ApskaitaObjects.Attributes
Imports ApskaitaObjects.My.Resources

Namespace Documents

    ''' <summary>
    ''' Represents a bank operation (transaction).
    ''' </summary>
    ''' <remarks>Encapsulates a <see cref="General.JournalEntry">JournalEntry</see> of type <see cref="DocumentType.AdvanceReport">DocumentType.AdvanceReport</see>.
    ''' Values are stored in the database table bankoperations.</remarks>
    <Serializable()> _
    Public NotInheritable Class BankOperation
        Inherits BusinessBase(Of BankOperation)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Private _ImportedItemGuid As Guid = Guid.Empty
        Private _JournalEntryID As Integer = 0
        Private _ID As Integer = 0
        Private _ChronologicValidator As SimpleChronologicValidator
        Private _IsDebit As Boolean = True
        Private _Account As CashAccountInfo = Nothing
        Private _Date As Date = Today
        Private _DocumentNumber As String = ""
        Private _Person As PersonInfo = Nothing
        Private _OriginalPerson As String = ""
        Private _Content As String = ""
        Private _OriginalContent As String = ""
        Private _UniqueCode As String = ""
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _CurrencyRate As Double = 1
        Private _CurrencyRateInAccount As Double = 1
        Private _Sum As Double = 0
        Private _SumLTL As Double = 0
        Private _SumInAccount As Double = 0
        Private _SumCorespondences As Double = 0
        Private _AccountBankCurrencyConversionCosts As Long = 0
        Private _BankCurrencyConversionCosts As Double = 0
        Private _AccountCurrencyRateChangeImpact As Long = 0
        Private _CurrencyRateChangeImpact As Double = 0
        Private _IsTransferBetweenAccounts As Boolean = False
        Private _CreditTransferOperationID As Integer = 0
        Private _UniqueCodeInCreditAccount As String = ""
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private _CreditCashAccount As CashAccountInfo = Nothing
        Private WithEvents _BookEntryItems As General.BookEntryList

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _BookEntryItemsSortedList As Csla.SortedBindingList(Of General.BookEntry) = Nothing


        ''' <summary>
        ''' Gets an <see cref="BankOperationItem.ItemGuid">imported bank operation GUID</see>
        ''' which data was used to create the bank operation.
        ''' </summary>
        ''' <remarks>Used for data exchange between this object and <see cref="BankOperationItem">BankOperationItem</see>.</remarks>
        Public ReadOnly Property ImportedItemGuid() As Guid
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ImportedItemGuid
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="General.JournalEntry.ID">an ID of the journal entry</see> that is created 
        ''' by the bank operation.
        ''' </summary>
        ''' <remarks>Value is stored in the database field bankoperations.ParentID.</remarks>
        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        ''' <summary>
        ''' Gets an ID of the item that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>A bank operation can contain two entries in bankoperations table
        ''' if it's a transfer between company's bank accounts.
        ''' In case of a transfer between company's own accounts
        ''' gets an ID of the debit entry in bankoperations table.
        ''' Value is stored in the database field bankoperations.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="IChronologicValidator">IChronologicValidator</see> object that contains business restraints on updating the operation.
        ''' </summary>
        ''' <remarks>A <see cref="SimpleChronologicValidator">SimpleChronologicValidator</see> is used to validate an bank operation chronological business rules.</remarks>
        Public ReadOnly Property ChronologicValidator() As SimpleChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologicValidator
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the bank operation was inserted into the database.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.InsertDate">journal entry InsertDate property</see>.</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the bank operation was last updated.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.UpdateDate">journal entry UpdateDate property</see>.</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets whether the money is transfered into the bank account.
        ''' </summary>
        ''' <remarks>Value is stored as a sign of sum values in the database sum fields.
        ''' If the sum is positive, the operation is debit and vice versa.</remarks>
        Public Property IsDebit() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsDebit
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)

                If IsDebitIsReadOnly Then Exit Property

                If _IsDebit <> value Then

                    _IsDebit = value
                    PropertyHasChanged()
                    PropertyHasChanged("IsCredit")

                    If Not _Person Is Nothing AndAlso Not _Person.IsEmpty AndAlso _BookEntryItems.Count = 1 Then
                        If _IsDebit Then
                            _BookEntryItems(0).Account = _Person.AccountAgainstBankBuyer
                        Else
                            _BookEntryItems(0).Account = _Person.AccountAgainstBankSupplyer
                        End If
                    End If

                    Recalculate(True)

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the money is transfered from the bank account.
        ''' </summary>
        ''' <remarks>Value is stored as a sign of sum values in the database sum fields.
        ''' If the sum is negative, the operation is credit and vice versa.</remarks>
        Public Property IsCredit() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _IsDebit
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)

                If IsCreditIsReadOnly Then Exit Property

                If _IsDebit = value Then

                    _IsDebit = Not value
                    PropertyHasChanged()
                    PropertyHasChanged("IsDebit")

                    If Not _Person Is Nothing AndAlso Not _Person.IsEmpty AndAlso _BookEntryItems.Count = 1 Then
                        If _IsDebit Then
                            _BookEntryItems(0).Account = _Person.AccountAgainstBankBuyer
                        Else
                            _BookEntryItems(0).Account = _Person.AccountAgainstBankSupplyer
                        End If
                    End If

                    Recalculate(True)

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a <see cref="CashAccount">cash (bank) account</see>.
        ''' In case of a transfer between company's own accounts gets or sets a 
        ''' debited <see cref="CashAccount">cash (bank) account</see>.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.CashAccountInfoList">CashAccountInfoList</see> as a datasource.
        ''' Value is stored in the database field bankoperations.CashAccountID.</remarks>
        <CashAccountFieldAttribute(ValueRequiredLevel.Mandatory, True, CashAccountType.BankAccount, CashAccountType.PseudoBankAccount)> _
        Public Property Account() As HelperLists.CashAccountInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As CashAccountInfo)

                CanWriteProperty(True)

                If AccountIsReadOnly Then Exit Property

                If Not (_Account Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Account Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _Account = value) Then

                    Dim baseCurrency As String = GetCurrentCompany().BaseCurrency

                    Dim oldCurrencyCode As String
                    If _Account Is Nothing OrElse _Account.IsEmpty Then
                        oldCurrencyCode = baseCurrency
                    Else
                        oldCurrencyCode = _Account.CurrencyCode.Trim.ToUpper
                    End If

                    _Account = value
                    PropertyHasChanged()

                    If Not CurrenciesEquals(oldCurrencyCode, Me.AccountCurrency, baseCurrency) Then

                        PropertyHasChanged("AccountCurrency")

                        If CurrenciesEquals(_CurrencyCode, Me.AccountCurrency, baseCurrency) Then

                            _CurrencyRateInAccount = _CurrencyRate

                        Else

                            If IsBaseCurrency(Me.AccountCurrency, baseCurrency) Then
                                _CurrencyRateInAccount = 1.0
                            Else
                                _CurrencyRateInAccount = 0.0
                            End If

                        End If

                        PropertyHasChanged("CurrencyRateInAccount")

                        Recalculate(True)

                        PropertyHasChanged("CurrencyRateInAccountIsReadOnly")
                        PropertyHasChanged("SumInAccountIsReadOnly")

                    End If

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets a currency for the selected <see cref="Account">Account</see>.
        ''' Returns BaseCurrency in case <see cref="Account">Account</see> is null or empty.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="CashAccount.CurrencyCode">CashAccount.CurrencyCode</see>.
        ''' Provides a proxy in case <see cref="Account">Account</see> is null or empty.</remarks>
        <CurrencyField(ValueRequiredLevel.Mandatory)> _
        Public ReadOnly Property AccountCurrency() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If Not _Account Is Nothing AndAlso Not _Account.IsEmpty Then Return _Account.CurrencyCode
                Return GetCurrentCompany.BaseCurrency
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the date of the bank operation.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.Date">journal entry Date property</see>.</remarks>
        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the bank operation number.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.DocNumber">journal entry DocNumber property</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 30)> _
        Public Property DocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _DocumentNumber.Trim <> value.Trim Then
                    _DocumentNumber = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a <see cref="General.Person">person</see> who transfers money into the 
        ''' bank account or whom money is transfered to.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.PersonInfoList">PersonInfoList</see> as a datasource.
        ''' Value is handled by the encapsulated <see cref="General.JournalEntry.Person">journal entry Person property</see>.</remarks>
        <PersonFieldAttribute(ValueRequiredLevel.Mandatory)> _
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

                    If Not _Person Is Nothing AndAlso Not _Person.IsEmpty AndAlso _
                        _ChronologicValidator.FinancialDataCanChange Then

                        If _BookEntryItems.Count < 1 Then

                            Dim entry As General.BookEntry = General.BookEntry.NewBookEntry()
                            If _IsDebit Then
                                entry.Account = _Person.AccountAgainstBankBuyer
                            Else
                                entry.Account = _Person.AccountAgainstBankSupplyer
                            End If
                            entry.Amount = _SumLTL
                            _BookEntryItems.Add(entry)

                        ElseIf _BookEntryItems.Count = 1 Then

                            If _IsDebit Then
                                _BookEntryItems(0).Account = _Person.AccountAgainstBankBuyer
                            Else
                                _BookEntryItems(0).Account = _Person.AccountAgainstBankSupplyer
                            End If

                        End If

                    End If

                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets an original person data (description) as it was specified in the import source.
        ''' </summary>
        ''' <remarks>Friend setter should only be used by the <see cref="BankOperationItem">BankOperationItem</see>.
        ''' Value is stored in the database field bankoperations.OriginalPerson.</remarks>
        Public Property OriginalPerson() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OriginalPerson.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Friend Set(ByVal value As String)
                _OriginalPerson = value.Trim
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the content (description) of the bank operation.
        ''' </summary>
        ''' <remarks>Value is handled by the encapsulated <see cref="General.JournalEntry.Content">journal entry Content property</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Content.Trim <> value.Trim Then
                    _Content = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets an original content data (description) as it was specified in the import source.
        ''' </summary>
        ''' <remarks>Friend setter should only be used by the <see cref="BankOperationItem">BankOperationItem</see>.
        ''' Value is stored in the database field bankoperations.OriginalContent.</remarks>
        Public Property OriginalContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OriginalContent.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Friend Set(ByVal value As String)
                _OriginalContent = value.Trim
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a unique code of the bank operation (usualy specified by the bank in the imported data).
        ''' In case of a transfer between company's own accounts gets or sets a unique code 
        ''' of the bank operation in the debited bank account (usualy specified by the bank 
        ''' in the imported data).
        ''' </summary>
        ''' <remarks>Used to identify already imported operations when importing data if the 
        ''' <see cref="CashAccount.EnforceUniqueOperationID">CashAccount.EnforceUniqueOperationID</see> 
        ''' property is set to true.
        ''' Value is stored in the database field bankoperations.U_ID.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property UniqueCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UniqueCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _UniqueCode.Trim <> value.Trim Then
                    _UniqueCode = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a currency of the money transfered.
        ''' </summary>
        ''' <remarks>Due to automatic conversions by a bank 
        ''' one can transfer USD from EUR bank account and vice versa.
        ''' Value is stored in the database field bankoperations.CurrencyCode.</remarks>
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

                    _CurrencyCode = GetCurrencySafe(value, GetCurrentCompany.BaseCurrency)
                    PropertyHasChanged()

                    If Not CurrencyRateIsReadOnly Then

                        If IsBaseCurrency(_CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                            _CurrencyRate = 1.0
                        Else
                            _CurrencyRate = 0.0
                        End If
                        PropertyHasChanged("CurrencyRate")

                    End If

                    If Not CurrencyRateInAccountIsReadOnly AndAlso CurrenciesEquals( _
                        Me.AccountCurrency, _CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                        _CurrencyRateInAccount = _CurrencyRate
                        PropertyHasChanged("CurrencyRateInAccount")
                    End If

                    Recalculate(True)

                    PropertyHasChanged("CurrencyRateIsReadOnly")
                    PropertyHasChanged("SumInAccountIsReadOnly")

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a currency rate for the money transfered.
        ''' </summary>
        ''' <remarks>Due to automatic conversions by a bank 
        ''' one can transfer USD from EUR bank account and vice versa.
        ''' Value is stored in the database field bankoperations.CurrencyRate.</remarks>
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

                    If CurrenciesEquals(AccountCurrency, _CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                        _CurrencyRateInAccount = _CurrencyRate
                        PropertyHasChanged("CurrencyRateInAccount")
                    End If

                    Recalculate(True)

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a currency rate for the <see cref="AccountCurrency">AccountCurrency</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field bankoperations.CurrencyRateInAccount.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDCURRENCYRATE)> _
        Public Property CurrencyRateInAccount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateInAccount, ROUNDCURRENCYRATE)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)

                If CurrencyRateInAccountIsReadOnly Then Exit Property

                If CRound(_CurrencyRateInAccount, ROUNDCURRENCYRATE) <> CRound(value, ROUNDCURRENCYRATE) Then

                    _CurrencyRateInAccount = CRound(value, ROUNDCURRENCYRATE)
                    PropertyHasChanged()

                    Recalculate(True)

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the (original) sum of bank transfer in <see cref="CurrencyCode">CurrencyCode</see>.
        ''' </summary>
        ''' <remarks>Value is stored in the database field bankoperations.SumOriginal.</remarks>
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
                    SetSumInAccount()
                    Recalculate(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the sum of bank transfer in base currency.
        ''' </summary>
        ''' <remarks>Value is stored in the database field bankoperations.SumLTL.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property SumLTL() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTL)
            End Get
        End Property

        ''' <summary>
        ''' Gets the sum of bank transfer in <see cref="AccountCurrency">AccountCurrency</see>,
        ''' i.e. the sum that was actualy added to the acount balance in the account currency.
        ''' </summary>
        ''' <remarks>Value is stored in the database field bankoperations.SumInAccount.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public Property SumInAccount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumInAccount)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If SumInAccountIsReadOnly Then Exit Property
                If CRound(_SumInAccount) <> CRound(value) Then
                    _SumInAccount = CRound(value)
                    PropertyHasChanged()
                    Recalculate(True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total sum of book entries in the <see cref="BookEntryItems">BookEntryItems</see>.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property SumCorespondences() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumCorespondences)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="General.Account.ID">account</see> for the currency conversion
        ''' costs incured by a bank when converting currency from <see cref="AccountCurrency">AccountCurrency</see>
        ''' to <see cref="CurrencyCode">CurrencyCode</see> and vice versa.
        ''' </summary>
        ''' <remarks>Due to automatic conversions by a bank 
        ''' one can transfer USD from EUR bank account and vice versa.
        ''' Value is stored in the database field bankoperations.AccountBankCurrencyConversionCosts.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, True, 5, 6)> _
        Public Property AccountBankCurrencyConversionCosts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountBankCurrencyConversionCosts
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountBankCurrencyConversionCostsIsReadOnly Then Exit Property
                If _AccountBankCurrencyConversionCosts <> value Then
                    _AccountBankCurrencyConversionCosts = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the costs (revenue) of the currency conversion incured by a bank 
        ''' when converting currency from <see cref="AccountCurrency">AccountCurrency</see>
        ''' to <see cref="CurrencyCode">CurrencyCode</see> and vice versa.
        ''' Positive value is treated as costs, negative value is treated as revenue.
        ''' </summary>
        ''' <remarks>Due to automatic conversions by a bank 
        ''' one can transfer USD from EUR bank account and vice versa.
        ''' Value is calculated as a difference between <see cref="SumLTL">SumLTL</see>
        ''' and <see cref="SumInAccount">SumInAccount</see> converted to the base currency.
        ''' See <see cref="SetBankCurrencyConversionCosts">SetBankCurrencyConversionCosts</see> method for details.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, True, 2)> _
        Public ReadOnly Property BankCurrencyConversionCosts() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BankCurrencyConversionCosts)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="General.Account.ID">account</see> for the currency rate change effect.
        ''' </summary>
        ''' <remarks>Value is stored in the database field bankoperations.AccountCurrencyRateChangeImpact.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, True, 5, 6)> _
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
        ''' Gets or sets the sum of the currency rate change effect. 
        ''' Positive value is treated as revenue, negative value is treated as costs.
        ''' </summary>
        ''' <remarks>Value is stored in the database field bankoperations.CurrencyRateChangeImpact.</remarks>
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
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the bank operation is a transfer between company's own accounts.
        ''' </summary>
        ''' <remarks>In case of a transfer between company's own accounts
        ''' the bank operation contains two entries in bankoperations table.</remarks>
        Public Property IsTransferBetweenAccounts() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsTransferBetweenAccounts
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)

                CanWriteProperty(True)

                If IsTransferBetweenAccountsIsReadOnly Then Exit Property

                If _IsTransferBetweenAccounts <> value Then

                    _IsTransferBetweenAccounts = value
                    PropertyHasChanged()

                    If value AndAlso Not _IsDebit Then
                        _IsDebit = True
                        PropertyHasChanged("IsDebit")
                        PropertyHasChanged("IsCredit")
                    End If

                    If value Then

                        Dim baseCurrency As String = GetCurrentCompany().BaseCurrency

                        If _CreditCashAccount Is Nothing OrElse _CreditCashAccount.IsEmpty Then

                            If Not IsBaseCurrency(_CurrencyCode, baseCurrency) Then
                                _CurrencyCode = GetCurrentCompany.BaseCurrency
                                PropertyHasChanged("CurrencyCode")
                            End If
                            If CRound(_CurrencyRate, ROUNDCURRENCYRATE) <> 1.0 Then
                                _CurrencyRate = 1.0
                                PropertyHasChanged("CurrencyRate")
                            End If

                        Else

                            If IsBaseCurrency(_CreditCashAccount.CurrencyCode, baseCurrency) Then

                                _CurrencyCode = baseCurrency
                                PropertyHasChanged("CurrencyCode")

                                If CRound(_CurrencyRate, ROUNDCURRENCYRATE) <> 1.0 Then
                                    _CurrencyRate = 1.0
                                    PropertyHasChanged("CurrencyRate")
                                End If

                            Else

                                _CurrencyCode = _CreditCashAccount.CurrencyCode
                                PropertyHasChanged("CurrencyCode")

                                If CRound(_CurrencyRate, ROUNDCURRENCYRATE) <> 0.0 Then
                                    _CurrencyRate = 0.0
                                    PropertyHasChanged("CurrencyRate")
                                End If

                            End If

                        End If

                        If _AccountCurrencyRateChangeImpact > 0 Then
                            _AccountCurrencyRateChangeImpact = 0
                            PropertyHasChanged("AccountCurrencyRateChangeImpact")
                        End If

                        If CRound(_CurrencyRateChangeImpact) <> 0 Then
                            _CurrencyRateChangeImpact = 0.0
                            PropertyHasChanged("CurrencyRateChangeImpact")
                        End If

                        _BookEntryItems.Clear()

                        _Person = Nothing
                        PropertyHasChanged("Person")

                        Recalculate(True)

                        PropertyHasChanged("BookEntryItemsIsReadOnly")
                        PropertyHasChanged("IsDebitIsReadOnly")
                        PropertyHasChanged("IsCreditIsReadOnly")
                        PropertyHasChanged("PersonIsReadOnly")
                        PropertyHasChanged("CurrencyCodeIsReadOnly")
                        PropertyHasChanged("AccountCurrencyRateChangeImpactIsReadOnly")
                        PropertyHasChanged("CurrencyRateChangeImpactIsReadOnly")
                        PropertyHasChanged("CreditCashAccountIsReadOnly")
                        PropertyHasChanged("UniqueCodeInCreditAccountIsReadOnly")
                        PropertyHasChanged("CurrencyRateIsReadOnly")
                        PropertyHasChanged("SumInAccountIsReadOnly")

                    End If

                End If

            End Set
        End Property

        ''' <summary>
        ''' In case of a transfer between company's own accounts
        ''' gets an ID of the credit entry in bankoperations table.
        ''' </summary>
        ''' <remarks>Value is stored in the database field bankoperations.ID.</remarks>
        Public ReadOnly Property CreditTransferOperationID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CreditTransferOperationID
            End Get
        End Property

        ''' <summary>
        ''' In case of a transfer between company's own accounts gets or sets a unique code 
        ''' of the bank operation in the credited bank account (usualy specified by the bank 
        ''' in the imported data).
        ''' </summary>
        ''' <remarks>Used to identify already imported operations when importing data if the 
        ''' <see cref="CashAccount.EnforceUniqueOperationID">CashAccount.EnforceUniqueOperationID</see> 
        ''' property is set to true.
        ''' Value is stored in the database field bankoperations.U_ID.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property UniqueCodeInCreditAccount() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UniqueCodeInCreditAccount.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If UniqueCodeInCreditAccountIsReadOnly Then Exit Property
                If value Is Nothing Then value = ""
                If _UniqueCodeInCreditAccount.Trim <> value.Trim Then
                    _UniqueCodeInCreditAccount = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' In case of a transfer between company's own accounts gets or sets a 
        ''' credited <see cref="CashAccount">cash (bank) account</see>.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.CashAccountInfoList">CashAccountInfoList</see> as a datasource.
        ''' Value is stored in the database field bankoperations.CashAccountID.</remarks>
        <CashAccountFieldAttribute(ValueRequiredLevel.Mandatory, True, CashAccountType.BankAccount, CashAccountType.PseudoBankAccount)> _
        Public Property CreditCashAccount() As CashAccountInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CreditCashAccount
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As CashAccountInfo)
                CanWriteProperty(True)

                If CreditCashAccountIsReadOnly Then Exit Property

                If Not (_CreditCashAccount Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _CreditCashAccount Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _CreditCashAccount = value) Then

                    _CreditCashAccount = value
                    PropertyHasChanged()

                    Dim baseCurrency As String = GetCurrentCompany().BaseCurrency

                    If _CreditCashAccount Is Nothing OrElse _CreditCashAccount.IsEmpty Then

                        If Not IsBaseCurrency(_CurrencyCode, baseCurrency) Then
                            _CurrencyCode = baseCurrency
                            PropertyHasChanged("CurrencyCode")
                        End If
                        If CRound(_CurrencyRate, ROUNDCURRENCYRATE) <> 1.0 Then
                            _CurrencyRate = 1.0
                            PropertyHasChanged("CurrencyRate")
                        End If

                    Else

                        If Not CurrenciesEquals(_CurrencyCode, _CreditCashAccount.CurrencyCode, baseCurrency) Then
                            _CurrencyCode = CreditCashAccount.CurrencyCode.Trim.ToUpper
                            PropertyHasChanged("CurrencyCode")
                        End If

                        If IsBaseCurrency(_CreditCashAccount.CurrencyCode, baseCurrency) Then

                            _CurrencyCode = baseCurrency
                            PropertyHasChanged("CurrencyCode")

                            If CRound(_CurrencyRate, ROUNDCURRENCYRATE) <> 1.0 Then
                                _CurrencyRate = 1.0
                                PropertyHasChanged("CurrencyRate")
                            End If

                        Else

                            _CurrencyCode = CreditCashAccount.CurrencyCode.Trim.ToUpper
                            PropertyHasChanged("CurrencyCode")

                            If CRound(_CurrencyRate, ROUNDCURRENCYRATE) <> 0.0 Then
                                _CurrencyRate = 0.0
                                PropertyHasChanged("CurrencyRate")
                            End If

                        End If

                    End If

                    Recalculate(True)

                    PropertyHasChanged("CurrencyRateIsReadOnly")
                    PropertyHasChanged("SumInAccountIsReadOnly")

                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets a list of <see cref="General.BookEntry">book entries</see> that a user needs 
        ''' to make by the bank operation. 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property BookEntryItems() As General.BookEntryList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BookEntryItems
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable list of <see cref="General.BookEntry">book entries</see> 
        ''' that a user needs to make by the bank operation. 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property BookEntryItemsSorted() As Csla.SortedBindingList(Of General.BookEntry)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _BookEntryItemsSortedList Is Nothing Then _BookEntryItemsSortedList = _
                    New Csla.SortedBindingList(Of General.BookEntry)(_BookEntryItems)
                Return _BookEntryItemsSortedList
            End Get
        End Property


        ''' <summary>
        ''' Gets whether the <see cref="BookEntryItems">BookEntryItems</see> is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property BookEntryItemsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange OrElse _IsTransferBetweenAccounts
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="IsDebit">IsDebit</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsDebitIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange OrElse _IsTransferBetweenAccounts
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="IsCredit">IsCredit</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsCreditIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange OrElse _IsTransferBetweenAccounts
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="Account">Account</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="Person">Person</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property PersonIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsTransferBetweenAccounts
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="CurrencyCode">CurrencyCode</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrencyCodeIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange OrElse _IsTransferBetweenAccounts
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="CurrencyRate">CurrencyRate</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrencyRateIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (Not _ChronologicValidator.FinancialDataCanChange OrElse _
                    IsBaseCurrency(_CurrencyCode, GetCurrentCompany().BaseCurrency))
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="CurrencyRateInAccount">CurrencyRateInAccount</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrencyRateInAccountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (Not _ChronologicValidator.FinancialDataCanChange OrElse _
                    CurrenciesEquals(Me.AccountCurrency, _CurrencyCode, GetCurrentCompany.BaseCurrency) OrElse _
                    IsBaseCurrency(Me.AccountCurrency, GetCurrentCompany.BaseCurrency))
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="Sum">Sum</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="AccountBankCurrencyConversionCosts">AccountBankCurrencyConversionCosts</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountBankCurrencyConversionCostsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="SumInAccount">SumInAccount</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SumInAccountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (Not _ChronologicValidator.FinancialDataCanChange OrElse _
                    CurrenciesEquals(Me.AccountCurrency, _CurrencyCode, GetCurrentCompany.BaseCurrency))
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="AccountCurrencyRateChangeImpact">AccountCurrencyRateChangeImpact</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountCurrencyRateChangeImpactIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange OrElse _IsTransferBetweenAccounts
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="CurrencyRateChangeImpact">CurrencyRateChangeImpact</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrencyRateChangeImpactIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange OrElse _IsTransferBetweenAccounts
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="IsTransferBetweenAccounts">IsTransferBetweenAccounts</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsTransferBetweenAccountsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="CreditCashAccount">CreditCashAccount</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CreditCashAccountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _ChronologicValidator.FinancialDataCanChange OrElse Not _IsTransferBetweenAccounts
            End Get
        End Property

        ''' <summary>
        ''' Gets whether the <see cref="UniqueCodeInCreditAccount">UniqueCodeInCreditAccount</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property UniqueCodeInCreditAccountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _IsTransferBetweenAccounts
            End Get
        End Property


        ''' <summary>
        ''' Returnes TRUE if the object is new and contains some user provided data 
        ''' OR
        ''' object is not new and was changed by the user.
        ''' </summary>
        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_DocumentNumber.Trim) _
                OrElse Not String.IsNullOrEmpty(_Content.Trim) _
                OrElse Not String.IsNullOrEmpty(_UniqueCode.Trim) _
                OrElse CRound(_Sum) > 0 OrElse _BookEntryItems.Count > 0)
            End Get
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _BookEntryItems.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _BookEntryItems.IsValid
            End Get
        End Property



        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            If Not _BookEntryItems.IsValid Then result = AddWithNewLine(result, _
                _BookEntryItems.GetAllBrokenRules, False)
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            End If
            If _BookEntryItems.HasWarnings() Then
                result = AddWithNewLine(result, _BookEntryItems.GetAllWarnings, False)
            End If
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return (MyBase.BrokenRulesCollection.WarningCount > 0 OrElse _BookEntryItems.HasWarnings())
        End Function


        Public Overrides Function Save() As BankOperation

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Return MyBase.Save

        End Function


        Private Sub BookEntryItems_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _BookEntryItems.ListChanged

            If _IsTransferBetweenAccounts Then Exit Sub

            _SumCorespondences = _BookEntryItems.GetSum
            PropertyHasChanged("SumCorespondences")

            If IsBaseCurrency(_CurrencyCode, GetCurrentCompany.BaseCurrency) Then

                If _IsDebit OrElse _IsTransferBetweenAccounts Then
                    _Sum = CRound(_SumCorespondences + _CurrencyRateChangeImpact)
                    _SumLTL = CRound(_SumCorespondences + _CurrencyRateChangeImpact)
                Else
                    _Sum = CRound(_SumCorespondences - _CurrencyRateChangeImpact)
                    _SumLTL = CRound(_SumCorespondences - _CurrencyRateChangeImpact)
                End If

                PropertyHasChanged("Sum")
                PropertyHasChanged("SumLTL")

                If IsBaseCurrency(Me.AccountCurrency, GetCurrentCompany.BaseCurrency) Then
                    _SumInAccount = _Sum
                    PropertyHasChanged("SumInAccount")
                End If

            End If

        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As BankOperation = DirectCast(MyBase.GetClone(), BankOperation)
            result.RestoreChildListsHandles()
            Return result
        End Function

        Protected Overrides Sub OnDeserialized(ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            RestoreChildListsHandles()
        End Sub

        Protected Overrides Sub UndoChangesComplete()
            MyBase.UndoChangesComplete()
            RestoreChildListsHandles()
        End Sub

        ''' <summary>
        ''' Helper method. Takes care of TaskTimeSpans loosing its handler. See GetClone method.
        ''' </summary>
        Friend Sub RestoreChildListsHandles()
            Try
                RemoveHandler _BookEntryItems.ListChanged, AddressOf BookEntryItems_Changed
            Catch ex As Exception
            End Try
            AddHandler _BookEntryItems.ListChanged, AddressOf BookEntryItems_Changed
        End Sub


        ''' <summary>
        ''' Sets the <see cref="CurrencyRateChangeImpact">CurrencyRateChangeImpact</see> property
        ''' to balance the diference between <see cref="SumLTL">SumLTL</see> and 
        ''' <see cref="SumCorespondences">SumCorespondences</see>.
        ''' </summary>
        ''' <remarks>Helper method for increased usability.</remarks>
        Public Sub CalculateCurrencyRateChangeImpact()

            If CurrencyRateChangeImpactIsReadOnly Then Exit Sub

            Dim valueCurrencyRateChangeImpact As Double

            If _IsDebit Then
                valueCurrencyRateChangeImpact = CRound(_SumLTL - _SumCorespondences)
            Else
                valueCurrencyRateChangeImpact = CRound(_SumCorespondences - _SumLTL)
            End If

            CurrencyRateChangeImpact = valueCurrencyRateChangeImpact

        End Sub

        ''' <summary>
        ''' Calculates reconciliated amounts for invoices in foreign currency.
        ''' </summary>
        ''' <param name="invoices">invoices to reconciliate</param>
        Public Sub CalculateReconciliation(invoices As ActiveReports.InvoiceInfoItem())

            If IsBaseCurrency(_CurrencyCode, GetCurrentCompany.BaseCurrency) Then _
                Throw New Exception(Documents_BankOperation_Reconciliation_InvalidCurrency)

            If Not _Sum > 0 Then Throw New Exception(Documents_BankOperation_Reconciliation_AmountNull)
            If Not _CurrencyRate > 0 Then Throw New Exception(Documents_BankOperation_Reconciliation_CurrencyRateNull)

            If invoices Is Nothing OrElse invoices.Length < 1 Then Throw New Exception(Documents_BankOperation_Reconciliation_InvoicesNull)

            For Each invoice As ActiveReports.InvoiceInfoItem In invoices
                If Not CurrenciesEquals(invoice.CurrencyCode, _CurrencyCode, GetCurrentCompany.BaseCurrency) Then _
                    Throw New Exception(Documents_BankOperation_Reconciliation_InvalidInvoiceCurrency)
            Next

            Dim list As New List(Of ActiveReports.InvoiceInfoItem)(invoices)
            list.Sort(AddressOf CompareInvoicesByDate)

            Dim remainingCurrency As Double = _Sum
            Dim currentAmount As Double
            Dim entries As New Dictionary(Of Long, Double)
            For Each invoice As ActiveReports.InvoiceInfoItem In invoices

                If CRound(Math.Abs(invoice.TotalSum), 2) <= CRound(remainingCurrency, 2) Then
                    currentAmount = invoice.TotalSumLTL
                Else
                    currentAmount = CRound(invoice.TotalSumLTL * remainingCurrency / Math.Abs(invoice.TotalSum), 2)
                End If

                ' so that amounts receivable are positive numbers and vice versa
                If invoice.Type = ActiveReports.InvoiceInfoType.InvoiceReceived Then currentAmount = -currentAmount

                If _IsDebit AndAlso currentAmount < 0 Then Throw New Exception(Documents_BankOperation_Reconciliation_NotesPayableInvalid)
                If Not _IsDebit AndAlso currentAmount > 0 Then Throw New Exception(Documents_BankOperation_Reconciliation_NotesReceivableInvalid)

                If currentAmount < 0 Then currentAmount = -currentAmount

                If entries.ContainsKey(invoice.PersonAccount) Then
                    entries(invoice.PersonAccount) = CRound(entries(invoice.PersonAccount) + currentAmount)
                Else
                    entries.Add(invoice.PersonAccount, currentAmount)
                End If

                remainingCurrency = CRound(remainingCurrency - Math.Abs(invoice.TotalSum), 2)

                If Not CRound(remainingCurrency, 2) > 0 Then Exit For

            Next

            If remainingCurrency > 0 Then
                entries.Add(0, ConvertCurrency(remainingCurrency, _CurrencyCode, _CurrencyRate,
                    GetCurrentCompany.BaseCurrency, 1.0, GetCurrentCompany.BaseCurrency, 2, ROUNDCURRENCYRATE, 0.0))
            End If

            _BookEntryItems.Clear()
            For Each entry As KeyValuePair(Of Long, Double) In entries
                Dim newEntry As General.BookEntry = General.BookEntry.NewBookEntry()
                newEntry.Account = entry.Key
                newEntry.Amount = entry.Value
                _BookEntryItems.Add(newEntry)
            Next

        End Sub

        Private Shared Function CompareInvoicesByDate(firstItem As ActiveReports.InvoiceInfoItem,
            secondItem As ActiveReports.InvoiceInfoItem) As Integer
            If firstItem Is Nothing AndAlso secondItem Is Nothing Then Return 0
            If firstItem Is Nothing Then Return -1
            If secondItem Is Nothing Then Return 1
            Return firstItem.ActualDate.CompareTo(secondItem.ActualDate)
        End Function


        Private Sub Recalculate(ByVal raisePropertyChangedEvents As Boolean)

            Dim baseCurrency As String = GetCurrentCompany().BaseCurrency

            Dim selectedCurrency As String = GetCurrencySafe(_CurrencyCode, GetCurrentCompany.BaseCurrency)

            If _IsTransferBetweenAccounts Then
                If _CreditCashAccount Is Nothing OrElse _CreditCashAccount.IsEmpty Then
                    selectedCurrency = baseCurrency
                Else
                    selectedCurrency = _CreditCashAccount.CurrencyCode
                End If
            End If

            _SumLTL = ConvertToBaseCurrency(_Sum, selectedCurrency, _CurrencyRate, _
                baseCurrency, 2, ROUNDCURRENCYRATE)

            If _IsTransferBetweenAccounts Then
                _SumCorespondences = _SumLTL
            End If

            If CurrenciesEquals(AccountCurrency, selectedCurrency, baseCurrency) Then

                _SumInAccount = _Sum
                If raisePropertyChangedEvents Then
                    PropertyHasChanged("SumInAccount")
                End If

            End If

            If raisePropertyChangedEvents Then
                PropertyHasChanged("SumLTL")
                If _IsTransferBetweenAccounts Then
                    PropertyHasChanged("SumCorespondences")
                End If
            End If

            SetBankCurrencyConversionCosts(raisePropertyChangedEvents)

        End Sub

        Private Sub SetBankCurrencyConversionCosts(ByVal raisePropertyChangedEvents As Boolean)

            Dim baseCurrency As String = GetCurrentCompany().BaseCurrency

            Dim selectedCurrency As String = GetCurrencySafe(_CurrencyCode, GetCurrentCompany.BaseCurrency)

            If _IsTransferBetweenAccounts Then
                If _CreditCashAccount Is Nothing OrElse _CreditCashAccount.IsEmpty Then
                    selectedCurrency = baseCurrency
                Else
                    selectedCurrency = _CreditCashAccount.CurrencyCode
                End If
            End If

            If Not CurrenciesEquals(AccountCurrency, selectedCurrency, baseCurrency) AndAlso _
                CRound(_SumInAccount) > 0 AndAlso (CRound(_CurrencyRateInAccount, ROUNDCURRENCYRATE) > 0 _
                OrElse IsBaseCurrency(AccountCurrency, baseCurrency)) Then

                Dim diff As Double = CRound(_SumLTL - ConvertToBaseCurrency(_SumInAccount, _
                    AccountCurrency, _CurrencyRateInAccount, baseCurrency, 2, ROUNDCURRENCYRATE), 2)

                If _IsDebit OrElse _IsTransferBetweenAccounts Then

                    _BankCurrencyConversionCosts = diff

                Else

                    _BankCurrencyConversionCosts = -diff

                End If

            Else

                _BankCurrencyConversionCosts = 0

            End If

            If raisePropertyChangedEvents Then
                PropertyHasChanged("BankCurrencyConversionCosts")
            End If

        End Sub

        Private Sub SetSumInAccount()

            If CRound(_SumInAccount, 2) > 0 Then Exit Sub

            Dim baseCurrency As String = GetCurrentCompany().BaseCurrency

            Dim selectedCurrency As String = GetCurrencySafe(_CurrencyCode, baseCurrency)

            If _IsTransferBetweenAccounts Then
                If _CreditCashAccount Is Nothing OrElse _CreditCashAccount.IsEmpty Then
                    selectedCurrency = baseCurrency
                Else
                    selectedCurrency = _CreditCashAccount.CurrencyCode
                End If
            End If

            Dim valueSumInAccount As Double = ConvertCurrency(_Sum, selectedCurrency, _
                _CurrencyRate, AccountCurrency, _CurrencyRateInAccount, baseCurrency, _
                2, ROUNDCURRENCYRATE, 0)

            If CRound(valueSumInAccount) > 0 Then
                _SumInAccount = valueSumInAccount
                PropertyHasChanged("SumInAccount")
            End If

        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            If _IsDebit Then
                Return String.Format(My.Resources.Documents_BankOperation_ToString, _
                    _Date.ToString("yyyy-MM-dd"), _DocumentNumber, DblParser(_Sum), _
                    _CurrencyCode, _ID.ToString())
            Else
                Return String.Format(My.Resources.Documents_BankOperation_ToString, _
                    _Date.ToString("yyyy-MM-dd"), _DocumentNumber, DblParser(-_Sum), _
                    _CurrencyCode, _ID.ToString())
            End If
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("Content"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("DocumentNumber"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Validation.RuleArgs("Sum"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Validation.RuleArgs("CurrencyRate"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Validation.RuleArgs("CurrencyRateInAccount"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New Validation.RuleArgs("SumInAccount"))
            ValidationRules.AddRule(AddressOf CommonValidation.CurrencyFieldValidation, _
                New Validation.RuleArgs("CurrencyCode"))
            ValidationRules.AddRule(AddressOf CashAccountFieldValidation, _
                New Validation.RuleArgs("Account"))
            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "ChronologicValidator"))

            ValidationRules.AddRule(AddressOf UniqueCodeValidation, New Validation.RuleArgs("UniqueCode"))
            ValidationRules.AddRule(AddressOf PersonValidation, New Validation.RuleArgs("Person"))
            ValidationRules.AddRule(AddressOf AccountCurrencyRateChangeImpactValidation, _
                New Validation.RuleArgs("AccountCurrencyRateChangeImpact"))
            ValidationRules.AddRule(AddressOf AccountBankCurrencyConversionCostsValidation, _
                New Validation.RuleArgs("AccountBankCurrencyConversionCosts"))
            ValidationRules.AddRule(AddressOf SumLTLValidation, New Validation.RuleArgs("SumLTL"))
            ValidationRules.AddRule(AddressOf CreditCashAccountValidation, _
                New Validation.RuleArgs("CreditCashAccount"))
            ValidationRules.AddRule(AddressOf UniqueCodeInCreditAccountValidation, _
                New Validation.RuleArgs("UniqueCodeInCreditAccount"))

            ValidationRules.AddDependantProperty("Account", "UniqueCode", False)
            ValidationRules.AddDependantProperty("AccountCurrency", "CurrencyRateInAccount", False)
            ValidationRules.AddDependantProperty("IsTransferBetweenAccounts", "Person", False)
            ValidationRules.AddDependantProperty("CurrencyRateChangeImpact", "AccountCurrencyRateChangeImpact", False)
            ValidationRules.AddDependantProperty("BankCurrencyConversionCosts", "AccountBankCurrencyConversionCosts", False)
            ValidationRules.AddDependantProperty("Account", "CreditCashAccount", False)
            ValidationRules.AddDependantProperty("IsTransferBetweenAccounts", "CreditCashAccount", False)
            ValidationRules.AddDependantProperty("CreditCashAccount", "UniqueCodeInCreditAccount", False)
            ValidationRules.AddDependantProperty("IsTransferBetweenAccounts", "UniqueCodeInCreditAccount", False)
            ValidationRules.AddDependantProperty("CurrencyRateChangeImpact", "SumLTL", False)
            ValidationRules.AddDependantProperty("SumCorespondences", "SumLTL", False)
            ValidationRules.AddDependantProperty("IsDebit", "SumLTL", False)

            ValidationRules.AddDependantProperty("AccountCurrencyRateChangeImpact", "AccountBankCurrencyConversionCosts", False)

        End Sub


        ''' <summary>
        ''' Rule ensuring that a sum of bank operation is provided.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SumLTLValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As BankOperation = DirectCast(target, BankOperation)

            If Not CommonValidation.CommonValidation.DoubleFieldValidation(target, e) Then Return False

            If valObj._IsDebit AndAlso CRound(valObj._SumLTL) _
                <> CRound(valObj._SumCorespondences + valObj._CurrencyRateChangeImpact) Then

                e.Description = My.Resources.Documents_BankOperation_InvalidSumLtlForDebit
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf Not valObj._IsDebit AndAlso CRound(valObj._SumLTL) _
                <> CRound(valObj._SumCorespondences - valObj._CurrencyRateChangeImpact) Then

                e.Description = My.Resources.Documents_BankOperation_InvalidSumLtlForCredit
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property UniqueCode is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function UniqueCodeValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As BankOperation = DirectCast(target, BankOperation)

            If Not valObj._Account Is Nothing AndAlso Not valObj._Account.IsEmpty AndAlso _
                valObj._Account.EnforceUniqueOperationID Then
                Return CommonValidation.CommonValidation.StringFieldValidation(target, e)
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that a CreditCashAccount is set when necessary.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function CreditCashAccountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As BankOperation = DirectCast(target, BankOperation)

            If Not valObj._IsTransferBetweenAccounts Then Return True

            If Not CommonValidation.CashAccountFieldValidation(target, e) Then Return False

            If valObj._CreditCashAccount <> CashAccountInfo.Empty AndAlso valObj._Account <> CashAccountInfo.Empty _
                AndAlso valObj._Account.ID = valObj._CreditCashAccount.ID Then

                e.Description = My.Resources.Documents_BankOperation_InvalidCreditCashAccount
                e.Severity = Validation.RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that a UniqueCodeInCreditAccount is set when necessary.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function UniqueCodeInCreditAccountValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As BankOperation = DirectCast(target, BankOperation)

            If valObj._IsTransferBetweenAccounts AndAlso Not valObj._CreditCashAccount Is Nothing _
                AndAlso Not valObj._CreditCashAccount.IsEmpty AndAlso _
                valObj._CreditCashAccount.EnforceUniqueOperationID Then

                Return CommonValidation.CommonValidation.StringFieldValidation(target, e)

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that a Person is set when necessary or vice versa.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function PersonValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As BankOperation = DirectCast(target, BankOperation)

            If Not valObj._IsTransferBetweenAccounts Then

                Return CommonValidation.PersonFieldValidation(target, e)

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that a valid currency rate change impact account is set when necessary.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountCurrencyRateChangeImpactValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As BankOperation = DirectCast(target, BankOperation)

            If CRound(valObj._CurrencyRateChangeImpact) <> 0 Then

                Return CommonValidation.AccountFieldValidation(target, e)

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that a valid AccountBankCurrencyConversionCosts is set when necessary.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountBankCurrencyConversionCostsValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As BankOperation = DirectCast(target, BankOperation)

            If valObj._AccountBankCurrencyConversionCosts > 0 AndAlso _
                valObj._AccountCurrencyRateChangeImpact > 0 AndAlso _
                valObj._AccountBankCurrencyConversionCosts = valObj._AccountCurrencyRateChangeImpact Then

                e.Description = Documents_BankOperation_InvalidAccountBankCurrencyConversionCosts
                e.Severity = Validation.RuleSeverity.Error
                Return False

            ElseIf CRound(valObj._BankCurrencyConversionCosts) <> 0 Then

                Return CommonValidation.AccountFieldValidation(target, e)

            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Documents.BankOperation2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.BankOperation1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.BankOperation2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.BankOperation3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Documents.BankOperation3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new instance of BankOperation.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function NewBankOperation() As BankOperation

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Dim result As New BankOperation
            result._ChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator(My.Resources.Documents_BankOperation_TypeName, Nothing)
            result._BookEntryItems = General.BookEntryList.NewBookEntryList(BookEntryType.Kreditas)
            result.ValidationRules.CheckRules()
            Return result

        End Function

        ''' <summary>
        ''' Gets a new instance of BankOperation using imported data.
        ''' </summary>
        ''' <param name="importedBankOperation">imported bank operation data</param>
        ''' <param name="importToAccount">cash account to import the data to</param>
        ''' <remarks></remarks>
        Public Shared Function NewBankOperation(ByVal importedBankOperation As BankOperationItem, _
            ByVal importToAccount As CashAccountInfo) As BankOperation
            Return New BankOperation(importedBankOperation, importToAccount, False)
        End Function

        ''' <summary>
        ''' Gets a new instance of BankOperation using imported data, validates it and prepares for insert.
        ''' </summary>
        ''' <param name="importedBankOperation">imported bank operation data</param>
        ''' <param name="importToAccount">cash account to import the data to</param>
        ''' <remarks>Should only be used by <see cref="BankOperationItemList">BankOperationItemList</see>.</remarks>
        Friend Shared Function NewBankOperationForInsert(ByVal importedBankOperation As BankOperationItem, _
            ByVal importToAccount As CashAccountInfo) As BankOperation
            Return New BankOperation(importedBankOperation, importToAccount, True)
        End Function

        ''' <summary>
        ''' Gets an existing instance of BankOperation from a database.
        ''' </summary>
        ''' <param name="nID">An ID of the BankOperation to get.</param>
        ''' <remarks></remarks>
        Public Shared Function GetBankOperation(ByVal nID As Integer) As BankOperation
            Return DataPortal.Fetch(Of BankOperation)(New Criteria(nID))
        End Function

        ''' <summary>
        ''' Deletes an existing instance of BankOperation from a database.
        ''' </summary>
        ''' <param name="id">An ID of the BankOperation to delete.</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteBankOperation(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal importedBankOperation As BankOperationItem, _
            ByVal importToAccount As CashAccountInfo, ByVal validateAndPrepare As Boolean)
            Create(importedBankOperation, importToAccount, validateAndPrepare)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public Sub New(ByVal nID As Integer)
                _ID = nID
            End Sub
        End Class


        Private Sub Create(ByVal importedBankOperation As BankOperationItem, _
            ByVal importToAccount As CashAccountInfo, ByVal validateAndPrepare As Boolean)

            _ChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator(My.Resources.Documents_BankOperation_TypeName, Nothing)

            _Account = importToAccount
            _Person = importedBankOperation.Person
            _Content = importedBankOperation.Content
            _CurrencyCode = importedBankOperation.Currency
            _CurrencyRate = importedBankOperation.CurrencyRate
            _CurrencyRateInAccount = importedBankOperation.CurrencyRateInAccount
            _Date = importedBankOperation.Date
            _DocumentNumber = importedBankOperation.DocumentNumber
            _OriginalPerson = String.Format("{0} ({1})", importedBankOperation.PersonName, _
                importedBankOperation.PersonCode)
            _OriginalContent = importedBankOperation.ContentOriginal
            _Sum = importedBankOperation.OriginalSum
            _SumInAccount = importedBankOperation.SumInAccount
            _SumLTL = importedBankOperation.SumLTL
            _IsDebit = importedBankOperation.Inflow
            If importedBankOperation.Inflow Then
                _BookEntryItems = General.BookEntryList.NewBookEntryList(BookEntryType.Kreditas)
            Else
                _BookEntryItems = General.BookEntryList.NewBookEntryList(BookEntryType.Debetas)
            End If
            _UniqueCode = importedBankOperation.UniqueCode
            _AccountBankCurrencyConversionCosts = importedBankOperation.AccountBankCurrencyConversionCosts
            _BankCurrencyConversionCosts = importedBankOperation.BankCurrencyConversionCosts

            Dim correspondingBookEntry As General.BookEntry = General.BookEntry.NewBookEntry
            correspondingBookEntry.Amount = importedBankOperation.SumLTL
            If importedBankOperation.IsBankCosts Then
                correspondingBookEntry.Account = importToAccount.BankFeeCostsAccount
                _Person = PersonInfo.GetPersonInfoChild(importToAccount.ManagingPersonID, False)
            Else
                correspondingBookEntry.Account = importedBankOperation.AccountCorresponding
            End If
            _BookEntryItems.Add(correspondingBookEntry)

            _ImportedItemGuid = importedBankOperation.ItemGuid

            If validateAndPrepare Then
                PrepareForInsert()
            End If

        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchBankOperation")
            myComm.AddParam("?BD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.Common_ObjectNotFound, My.Resources.Documents_BankOperation_TypeName, _
                    criteria.ID.ToString()))

                Dim dr As DataRow = myData.Rows(0)

                _JournalEntryID = criteria.ID

                _ID = CIntSafe(dr.Item(0), 0)
                _Date = CDateSafe(dr.Item(1), Today)
                _DocumentNumber = CStrSafe(dr.Item(2)).Trim
                _Content = CStrSafe(dr.Item(3)).Trim
                _UniqueCode = CStrSafe(dr.Item(4)).Trim
                _CurrencyCode = GetCurrencySafe(CStrSafe(dr.Item(5)), GetCurrentCompany.BaseCurrency)
                _CurrencyRate = CDblSafe(dr.Item(6), ROUNDCURRENCYRATE, 0)
                _CurrencyRateInAccount = CDblSafe(dr.Item(7), ROUNDCURRENCYRATE, 0)
                _IsDebit = (CDblSafe(dr.Item(8), 2, 0) > 0)
                _Sum = Math.Abs(CDblSafe(dr.Item(8), 2, 0))
                _SumLTL = Math.Abs(CDblSafe(dr.Item(9), 2, 0))
                _SumInAccount = Math.Abs(CDblSafe(dr.Item(10), 2, 0))
                _AccountCurrencyRateChangeImpact = CLongSafe(dr.Item(11), 0)
                _CurrencyRateChangeImpact = CDblSafe(dr.Item(12), 2, 0)
                _OriginalPerson = CStrSafe(dr.Item(13)).Trim
                _OriginalContent = CStrSafe(dr.Item(14)).Trim
                _AccountBankCurrencyConversionCosts = CLongSafe(dr.Item(15), 0)
                _InsertDate = CTimeStampSafe(dr.Item(16))
                _UpdateDate = CTimeStampSafe(dr.Item(17))
                _Account = CashAccountInfo.GetCashAccountInfo(dr, 18)
                _Person = PersonInfo.GetPersonInfo(dr, 32)

                If myData.Rows.Count > 1 Then

                    _IsTransferBetweenAccounts = True
                    _CreditTransferOperationID = CIntSafe(myData.Rows(1).Item(0), 0)
                    _UniqueCodeInCreditAccount = CStrSafe(myData.Rows(1).Item(4)).Trim
                    _CreditCashAccount = CashAccountInfo.GetCashAccountInfo(myData.Rows(1), 18)

                End If

            End Using

            _ChronologicValidator = SimpleChronologicValidator. _
                GetSimpleChronologicValidator(_JournalEntryID, _Date, _
                My.Resources.Documents_BankOperation_TypeName, Nothing)

            If Not _IsTransferBetweenAccounts Then

                If _IsDebit Then
                    _BookEntryItems = General.BookEntryList.GetBookEntryList( _
                        _JournalEntryID, BookEntryType.Kreditas, _ChronologicValidator, _
                        _AccountCurrencyRateChangeImpact, _AccountBankCurrencyConversionCosts)
                Else
                    _BookEntryItems = General.BookEntryList.GetBookEntryList( _
                        _JournalEntryID, BookEntryType.Debetas, _ChronologicValidator, _
                        _AccountCurrencyRateChangeImpact, _AccountBankCurrencyConversionCosts)
                End If

                _SumCorespondences = _BookEntryItems.GetSum

            Else

                _BookEntryItems = General.BookEntryList.NewBookEntryList(BookEntryType.Kreditas)
                _SumCorespondences = _SumLTL

            End If

            SetBankCurrencyConversionCosts(False)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        <NonSerialized(), NotUndoable()> _
        Private _UnderlyingJournalEntry As General.JournalEntry = Nothing

        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            PrepareForInsert()

            DoInsert()

        End Sub

        Private Sub PrepareForInsert()

            PrepareForInsertUpdate()

            CheckIfUniqueCodeIsUnique()

            _UnderlyingJournalEntry = GetJournalEntry()

        End Sub

        Friend Sub DoInsert()

            If _UnderlyingJournalEntry Is Nothing Then
                Throw New Exception("Underlying Journal Entry should be prepared before invoking Insert BankOperation.")
            ElseIf Not _UnderlyingJournalEntry Is Nothing AndAlso Not _UnderlyingJournalEntry.IsNew Then
                Throw New Exception("Underlying Journal Entry should be new when invoking Insert BankOperation.")
            End If

            Using transaction As New SqlTransaction

                Try

                    _UnderlyingJournalEntry = _UnderlyingJournalEntry.SaveChild()

                    _JournalEntryID = _UnderlyingJournalEntry.ID
                    _InsertDate = _UnderlyingJournalEntry.InsertDate
                    _UpdateDate = _UnderlyingJournalEntry.UpdateDate

                    Dim myComm As New SQLCommand("InsertBankOperation")
                    AddWithParams(myComm)
                    myComm.AddParam("?AA", _JournalEntryID)
                    myComm.AddParam("?AB", _OriginalPerson.Trim)
                    myComm.AddParam("?AC", _OriginalContent.Trim)
                    myComm.AddParam("?AE", _UniqueCode.Trim)

                    myComm.Execute()

                    _ID = Convert.ToInt32(myComm.LastInsertID)

                    If _IsTransferBetweenAccounts Then

                        myComm = New SQLCommand("InsertBankOperation")
                        AddWithParamsCreditForTransfer(myComm)
                        myComm.AddParam("?AA", _JournalEntryID)
                        myComm.AddParam("?AB", _OriginalPerson.Trim)
                        myComm.AddParam("?AC", _OriginalContent.Trim)
                        myComm.AddParam("?AE", _UniqueCodeInCreditAccount.Trim)

                        myComm.Execute()

                        _CreditTransferOperationID = Convert.ToInt32(myComm.LastInsertID)

                    End If

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub


        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            _ChronologicValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                _JournalEntryID, _ChronologicValidator.CurrentOperationDate, _
                My.Resources.Documents_BankOperation_TypeName, Nothing)

            PrepareForInsertUpdate()

            CheckIfUniqueCodeIsUnique()

            Dim myComm As New SQLCommand("UpdateBankOperation")
            If _ChronologicValidator.FinancialDataCanChange Then
                myComm = New SQLCommand("UpdateBankOperation")
                AddWithParams(myComm)
            Else
                myComm = New SQLCommand("UpdateBankOperationNonFinancial")
            End If
            myComm.AddParam("?AE", _UniqueCode.Trim)
            myComm.AddParam("?BD", _ID)

            Dim entry As General.JournalEntry = GetJournalEntry()

            Using transaction As New SqlTransaction

                Try

                    entry = entry.SaveChild()
                    _UpdateDate = entry.UpdateDate

                    myComm.Execute()

                    If _ChronologicValidator.FinancialDataCanChange AndAlso Not _IsTransferBetweenAccounts _
                        AndAlso _CreditTransferOperationID > 0 Then

                        myComm = New SQLCommand("DeleteCreditAccountBankOperation")
                        myComm.AddParam("?BD", _CreditTransferOperationID)

                    ElseIf _ChronologicValidator.FinancialDataCanChange AndAlso _IsTransferBetweenAccounts _
                        AndAlso Not _CreditTransferOperationID > 0 Then

                        myComm = New SQLCommand("InsertBankOperation")
                        AddWithParamsCreditForTransfer(myComm)
                        myComm.AddParam("?AA", _JournalEntryID)
                        myComm.AddParam("?AB", _OriginalPerson.Trim)
                        myComm.AddParam("?AC", _OriginalContent.Trim)
                        myComm.AddParam("?AE", _UniqueCodeInCreditAccount.Trim)

                    ElseIf _IsTransferBetweenAccounts AndAlso _CreditTransferOperationID > 0 Then

                        If _ChronologicValidator.FinancialDataCanChange Then
                            myComm = New SQLCommand("UpdateBankOperation")
                            AddWithParamsCreditForTransfer(myComm)
                        Else
                            myComm = New SQLCommand("UpdateBankOperationNonFinancial")
                        End If
                        myComm.AddParam("?BD", _CreditTransferOperationID)
                        myComm.AddParam("?AE", _UniqueCodeInCreditAccount.Trim)

                    End If

                    myComm.Execute()

                    If _IsTransferBetweenAccounts AndAlso Not _CreditTransferOperationID > 0 Then _
                        _CreditTransferOperationID = Convert.ToInt32(myComm.LastInsertID)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted(DirectCast(criteria, Criteria).ID, _
                DocumentType.BankOperation)

            Dim myComm As New SQLCommand("DeleteBankOperation")
            myComm.AddParam("?BD", DirectCast(criteria, Criteria).ID)

            Using transaction As New SqlTransaction

                Try

                    General.JournalEntry.DeleteJournalEntryChild(DirectCast(criteria, Criteria).ID)

                    myComm.Execute()

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkNew()

        End Sub



        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            Dim operationSign As Integer = 1
            If Not _IsDebit AndAlso Not _IsTransferBetweenAccounts Then operationSign = -1

            Dim baseCurrency As String = GetCurrentCompany().BaseCurrency

            myComm.AddParam("?AD", _Account.ID)
            myComm.AddParam("?AF", GetCurrencySafe(_CurrencyCode, baseCurrency))
            If IsBaseCurrency(_CurrencyCode, baseCurrency) Then
                myComm.AddParam("?AG", 1.0)
            Else
                myComm.AddParam("?AG", CRound(_CurrencyRate, ROUNDCURRENCYRATE))
            End If
            If IsBaseCurrency(Me.AccountCurrency, baseCurrency) Then
                myComm.AddParam("?AH", 1.0)
            ElseIf CurrenciesEquals(Me.AccountCurrency, _CurrencyCode, baseCurrency) Then
                myComm.AddParam("?AH", CRound(_CurrencyRate, ROUNDCURRENCYRATE))
            Else
                myComm.AddParam("?AH", CRound(_CurrencyRateInAccount, ROUNDCURRENCYRATE))
            End If
            myComm.AddParam("?AI", CRound(operationSign * _Sum))
            myComm.AddParam("?AJ", CRound(operationSign * _SumLTL))
            myComm.AddParam("?AK", CRound(operationSign * _SumInAccount))
            myComm.AddParam("?AL", _AccountCurrencyRateChangeImpact)
            myComm.AddParam("?AM", CRound(_CurrencyRateChangeImpact))
            If CurrenciesEquals(Me.AccountCurrency, _CurrencyCode, baseCurrency) Then
                myComm.AddParam("?AN", 0)
            Else
                myComm.AddParam("?AN", _AccountBankCurrencyConversionCosts)
            End If

        End Sub

        Private Sub AddWithParamsCreditForTransfer(ByRef myComm As SQLCommand)

            myComm.AddParam("?AD", _CreditCashAccount.ID)
            myComm.AddParam("?AF", _CreditCashAccount.CurrencyCode.Trim)
            If IsBaseCurrency(_CreditCashAccount.CurrencyCode, GetCurrentCompany.BaseCurrency) Then
                myComm.AddParam("?AG", 1.0)
                myComm.AddParam("?AH", 1.0)
            Else
                myComm.AddParam("?AG", CRound(_CurrencyRate, ROUNDCURRENCYRATE))
                myComm.AddParam("?AH", CRound(_CurrencyRate, ROUNDCURRENCYRATE))
            End If
            myComm.AddParam("?AI", -CRound(_Sum))
            myComm.AddParam("?AJ", -CRound(_SumLTL))
            myComm.AddParam("?AK", -CRound(_Sum)) ' SumInAccount
            myComm.AddParam("?AL", 0) ' AccountCurrencyRateChangeImpact
            myComm.AddParam("?AM", 0) ' CurrencyRateChangeImpact
            myComm.AddParam("?AN", 0) ' AccountBankCurrencyConversionCosts

        End Sub

        Friend Sub CheckIfUniqueCodeIsUnique()

            Dim myComm As SQLCommand

            If Not _Account Is Nothing AndAlso Not _Account.IsEmpty _
                AndAlso _Account.EnforceUniqueOperationID Then

                myComm = New SQLCommand("CheckIfBankOperationUniqueCodeIsUnique")
                myComm.AddParam("?OD", _ID)
                myComm.AddParam("?UC", _UniqueCode.Trim)
                myComm.AddParam("?AD", _Account.ID)

                Using myData As DataTable = myComm.Fetch
                    If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then
                        If _IsTransferBetweenAccounts Then
                            Throw New Exception(My.Resources.Documents_BankOperation_UniqueCodeInvalidDebit)
                        Else
                            Throw New Exception(My.Resources.Documents_BankOperation_UniqueCodeInvalid)
                        End If
                    End If
                End Using

            End If

            If _IsTransferBetweenAccounts AndAlso Not _CreditCashAccount Is Nothing AndAlso _
                Not _CreditCashAccount.IsEmpty AndAlso _CreditCashAccount.EnforceUniqueOperationID Then

                myComm = New SQLCommand("CheckIfBankOperationUniqueCodeIsUnique")
                myComm.AddParam("?OD", _CreditTransferOperationID)
                myComm.AddParam("?UC", Me._UniqueCodeInCreditAccount.Trim)
                myComm.AddParam("?AD", _CreditCashAccount.ID)

                Using myData As DataTable = myComm.Fetch
                    If myData.Rows.Count > 0 AndAlso CIntSafe(myData.Rows(0).Item(0), 0) > 0 Then _
                        Throw New Exception(My.Resources.Documents_BankOperation_UniqueCodeInvalidCredit)
                End Using

            End If

        End Sub

        Private Function GetJournalEntry() As General.JournalEntry

            Dim result As General.JournalEntry
            If IsNew Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.BankOperation)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_JournalEntryID, DocumentType.BankOperation)
                If result.UpdateDate <> _UpdateDate Then Throw New Exception( _
                    My.Resources.Common_UpdateDateHasChanged)
            End If

            result.Content = _Content
            result.Date = _Date
            result.DocNumber = _DocumentNumber
            result.Person = _Person

            If _ChronologicValidator.FinancialDataCanChange Then

                Dim fullBookEntryList As BookEntryInternalList = BookEntryInternalList. _
                NewBookEntryInternalList(BookEntryType.Debetas)

                If _IsDebit Then
                    fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Debetas, _Account.Account, CRound(_SumLTL), Nothing))
                Else
                    fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, _Account.Account, CRound(_SumLTL), Nothing))
                End If

                If Not CurrenciesEquals(AccountCurrency, _CurrencyCode, GetCurrentCompany.BaseCurrency) _
                    AndAlso _AccountBankCurrencyConversionCosts <> 0 Then

                    If CRound(_BankCurrencyConversionCosts) > 0 Then

                        fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Debetas, _AccountBankCurrencyConversionCosts, _
                            CRound(_BankCurrencyConversionCosts), Nothing))
                        fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Kreditas, _Account.Account, _
                            CRound(_BankCurrencyConversionCosts), Nothing))

                    ElseIf CRound(_BankCurrencyConversionCosts) < 0 Then

                        fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Kreditas, _AccountBankCurrencyConversionCosts, _
                            CRound(-_BankCurrencyConversionCosts), Nothing))
                        fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Debetas, _Account.Account, _
                            CRound(-_BankCurrencyConversionCosts), Nothing))

                    End If

                End If

                If _IsTransferBetweenAccounts Then

                    fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                        BookEntryType.Kreditas, _CreditCashAccount.Account, CRound(_SumLTL), Nothing))

                Else

                    If CRound(_CurrencyRateChangeImpact) > 0 AndAlso _AccountCurrencyRateChangeImpact > 0 Then
                        fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Kreditas, _AccountCurrencyRateChangeImpact, _
                            CRound(_CurrencyRateChangeImpact), Nothing))
                    ElseIf CRound(_CurrencyRateChangeImpact) < 0 AndAlso _AccountCurrencyRateChangeImpact > 0 Then
                        fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                            BookEntryType.Debetas, _AccountCurrencyRateChangeImpact, _
                            CRound(-_CurrencyRateChangeImpact), Nothing))
                    Else
                        _AccountCurrencyRateChangeImpact = 0
                        _CurrencyRateChangeImpact = 0
                    End If

                    Dim entryType As BookEntryType
                    If _IsDebit Then
                        entryType = BookEntryType.Kreditas
                    Else
                        entryType = BookEntryType.Debetas
                    End If

                    For Each i As General.BookEntry In _BookEntryItems

                        If i.Account <> _AccountCurrencyRateChangeImpact AndAlso _
                            i.Account <> _AccountBankCurrencyConversionCosts Then
                            fullBookEntryList.Add(BookEntryInternal.NewBookEntryInternal( _
                                entryType, i.Account, i.Amount, i.Person))
                        End If

                    Next

                End If

                fullBookEntryList.Aggregate()

                result.DebetList.Clear()
                result.CreditList.Clear()

                result.DebetList.LoadBookEntryListFromInternalList(fullBookEntryList, False, False)
                result.CreditList.LoadBookEntryListFromInternalList(fullBookEntryList, False, False)

            End If

            If Not result.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_FailedToCreateJournalEntry, _
                    vbCrLf, result.ToString, vbCrLf, result.GetAllBrokenRules))
            End If

            Return result

        End Function

        ''' <summary>
        ''' Repairs possible trivial errors, e.g. LTL rate not equal to 1, etc.
        ''' </summary>
        Private Sub PrepareForInsertUpdate()

            Dim baseCurrency As String = GetCurrentCompany().BaseCurrency

            _CurrencyCode = GetCurrencySafe(_CurrencyCode, baseCurrency)

            If _IsTransferBetweenAccounts Then

                If Not _IsDebit Then _IsDebit = True

                ' For transfers between accounts operation currency should always be 
                ' the same as credited account currency
                If Not CurrenciesEquals(_CreditCashAccount.CurrencyCode, _CurrencyCode, baseCurrency) Then
                    _CurrencyCode = GetCurrencySafe(_CreditCashAccount.CurrencyCode, baseCurrency)
                End If

                ' CurrencyRateChangeImpact is impossible when transfering between company's own accounts
                _AccountCurrencyRateChangeImpact = 0
                _CurrencyRateChangeImpact = 0

            Else

                ' Remove currency rate change effect BookEntries that was entered into
                ' the correspondences list instead of currency rate change effect field
                ' by some stupid user
                If _AccountCurrencyRateChangeImpact > 0 AndAlso _
                    _BookEntryItems.GetSumInAccount(_AccountCurrencyRateChangeImpact) > 0 Then

                    If _IsDebit Then
                        _CurrencyRateChangeImpact = CRound(_CurrencyRateChangeImpact _
                            + _BookEntryItems.GetSumInAccount(_AccountCurrencyRateChangeImpact))
                    Else
                        _CurrencyRateChangeImpact = CRound(_CurrencyRateChangeImpact _
                            - _BookEntryItems.GetSumInAccount(_AccountCurrencyRateChangeImpact))
                    End If

                End If

                ' only account and impact together make sense
                If _AccountCurrencyRateChangeImpact = 0 Then
                    _CurrencyRateChangeImpact = 0
                ElseIf CRound(_CurrencyRateChangeImpact) = 0.0 Then
                    _AccountCurrencyRateChangeImpact = 0
                End If

            End If

            ' LTL rate is always 1 (should be unless some stupid user)
            If IsBaseCurrency(_CurrencyCode, baseCurrency) Then _CurrencyRate = 1.0

            If IsBaseCurrency(AccountCurrency, baseCurrency) Then
                ' LTL rate is always 1 (should be unless some stupid user)
                _CurrencyRateInAccount = 1.0
            ElseIf CurrenciesEquals(AccountCurrency, _CurrencyCode, baseCurrency) Then
                ' if operation currency is the same as account currency, the rates should be equal
                _CurrencyRateInAccount = CRound(_CurrencyRate, ROUNDCURRENCYRATE)
            End If

            ' bank currency conversion costs can only happen if such a conversion 
            ' is done by a bank, i.e. operation currency is different from account currency
            If CurrenciesEquals(AccountCurrency, _CurrencyCode, baseCurrency) Then
                _AccountBankCurrencyConversionCosts = 0
                _BankCurrencyConversionCosts = 0
            End If

            ' Remove currency conversion costs BookEntries that was entered into
            ' the correspondences list instead of currency conversion costs field
            ' by some stupid user
            If _AccountBankCurrencyConversionCosts > 0 AndAlso _
                _BookEntryItems.GetSumInAccount(_AccountBankCurrencyConversionCosts) > 0 Then

                If _IsDebit Then
                    _BankCurrencyConversionCosts = CRound(_BankCurrencyConversionCosts _
                        - _BookEntryItems.GetSumInAccount(_AccountBankCurrencyConversionCosts))
                Else
                    _BankCurrencyConversionCosts = CRound(_BankCurrencyConversionCosts _
                        + _BookEntryItems.GetSumInAccount(_AccountBankCurrencyConversionCosts))
                End If

            End If

            _BookEntryItems.RemoveReservedAccounts(_AccountCurrencyRateChangeImpact, _
                _AccountBankCurrencyConversionCosts)

            If Not _IsTransferBetweenAccounts Then
                _SumCorespondences = _BookEntryItems.GetSum
            End If

            Recalculate(False)

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

        End Sub

#End Region

    End Class

End Namespace