﻿Imports ApskaitaObjects.Attributes

Namespace General

    ''' <summary>
    ''' Represents ledger account, also known as T-account http://en.wikipedia.org/wiki/Debits_and_credits#T-accounts".
    ''' Can only be used as a child object for <see cref="General.AccountList"/>
    ''' </summary>
    ''' <remarks>Related helper object (value object list) is <see cref="HelperLists.AccountInfoList">AccountInfoList</see>.
    ''' Values are stored in the database table saskaitupl.</remarks>
    <Serializable()> _
    Public NotInheritable Class Account
        Inherits BusinessBase(Of Account)
        Implements IGetErrorForListItem

#Region " Business Methods "

        ''' <summary>
        ''' All possible account classes as provided by <see cref="General.Account.GetAccountClass">GetAccountClass</see> method.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared ReadOnly AccountClassList As Integer() = New Integer() {1, 2, 3, 4, 5, 6}

        Private Const ColumnCount As Integer = 3

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Long = 0
        Private _OldID As Long = 0
        Private _Name As String = ""
        Private _AssociatedReportItem As AssignableCRItem = Nothing
        Private _Comments As String = ""
        Private _Class As Byte = 0
        Private _SaftCode As CodeInfo = Nothing


        ''' <summary>
        ''' Account ID - <see cref="Long">Long</see> number that identifies account (required).
        ''' </summary>
        ''' <value></value>
        ''' <returns>Account ID (<see cref="Long">Long</see> number that identifies account).</returns>
        ''' <remarks>Value is stored in the database field saskaitupl.Saskaitosnr.</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False)>
        Public Property ID() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Get
                Return _ID
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If _ID <> value Then
                    _ID = value
                    PropertyHasChanged()
                    _Class = GetAccountClass(_ID)
                    PropertyHasChanged("Class")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Account name - a short description of an account (required).
        ''' </summary>
        ''' <value></value>
        ''' <returns>short description of an account</returns>
        ''' <remarks>Value is stored in the database field saskaitupl.Saskaita.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255, False)>
        Public Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Get
                Return _Name.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Name.Trim <> value.Trim Then
                    _Name = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Associated <see cref="General.ConsolidatedReportItem">ConsolidatedReportItem</see>. (required)
        ''' </summary>
        ''' <value></value>
        ''' <returns>Associated <see cref="General.ConsolidatedReportItem" />.</returns>
        ''' <remarks>Use <see cref="HelperLists.AssignableCRItemList" /> as DataSource.
        ''' Value is stored in the database field saskaitupl.fs_id.</remarks>
        <AssignableCRItemFieldAttribute(ValueRequiredLevel.Recommended)>
        Public Property AssociatedReportItem() As AssignableCRItem
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Get
                Return _AssociatedReportItem
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Set(ByVal value As AssignableCRItem)
                CanWriteProperty(True)
                If Not (_AssociatedReportItem Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _AssociatedReportItem Is Nothing AndAlso
                    Not value Is Nothing AndAlso _AssociatedReportItem = value) Then
                    _AssociatedReportItem = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an account code according to the state approved classification.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>Value is stored in the database fields saskaitupl.SaftCode and saskaitupl.SaftDescription.</remarks>
        <CodeAndNameField(ValueRequiredLevel.Recommended, Settings.CodeType.SaftAccountType)>
        Public Property SaftCode As CodeInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Get
                Return _SaftCode
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Set(ByVal value As CodeInfo)
                CanWriteProperty(True)
                If _SaftCode <> value Then
                    _SaftCode = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Accountant comments about the account.
        ''' </summary>
        ''' <value></value>
        ''' <remarks>Value is stored in the database field saskaitupl.Rusis.</remarks>
        <StringField(ValueRequiredLevel.Optional, 255, False)>
        Public Property Comments() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Get
                Return _Comments.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Comments.Trim <> value.Trim Then
                    _Comments = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' <see href="http://en.wikipedia.org/wiki/Debits_and_credits#Accounts_pertaining_to_the_five_accounting_elements">Class of account</see>. 
        ''' Maped by the first number ("prefix") in the <see cref="ID" /> and values of <see cref="General.Company.AccountClassPrefix11" />,
        ''' <see cref="General.Company.AccountClassPrefix12" />, <see cref="General.Company.AccountClassPrefix21" />, etc.
        ''' </summary>
        ''' <value></value>
        ''' <returns>Base class of account:
        ''' 0 - Invalid account, i.e. not <see cref="ID">ID</see> > 0.
        ''' 1 - Long term assets;
        ''' 2 - Short term assets;
        ''' 3 - Equity;
        ''' 4 - Liabilities;
        ''' 5 - Income/Revenue;
        ''' 6 - Expenses.</returns>
        ''' <remarks>Maping method <see cref="GetAccountClass" /> is invoked in the <see cref="ID" /> property setter.</remarks>
        Public ReadOnly Property [Class]() As Byte
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Get
                Return _Class
            End Get
        End Property


        ''' <summary>
        ''' Gets a human readable description of all the validation errors.
        ''' Returns <see cref="String.Empty" /> if no errors.
        ''' </summary>
        ''' <returns>A human readable description of all the validation errors.
        ''' Returns <see cref="String.Empty" /> if no errors.</returns>
        ''' <remarks></remarks>
        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString,
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
        End Function

        ''' <summary>
        ''' Gets a human readable description of all the validation warnings.
        ''' Returns <see cref="String.Empty" /> if no warnings.
        ''' </summary>
        ''' <returns>A human readable description of all the validation warnings.
        ''' Returns <see cref="String.Empty" /> if no warnings.</returns>
        ''' <remarks></remarks>
        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString,
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
        End Function


        ''' <summary>
        ''' Forces all validation rules to be applied to the Account instance.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub ValidateChild()
            Me.ValidationRules.CheckRules()
        End Sub


        ''' <summary>
        ''' Maps an account <see cref="ID" /> to the base class.
        ''' Maped by the first number ("prefix") in the <see cref="ID" /> and values of <see cref="General.Company.AccountClassPrefix11" />,
        ''' <see cref="General.Company.AccountClassPrefix12" />, <see cref="General.Company.AccountClassPrefix21" />, etc.
        ''' </summary>
        ''' <param name="accountID"></param>
        ''' <returns>Base class of account identified by <paramref name="accountID" />:
        ''' 0 - Invalid account, i.e. not <see cref="ID" /> > 0.
        ''' 1 - Long term assets;
        ''' 2 - Short term assets;
        ''' 3 - Equity;
        ''' 4 - Liabilities;
        ''' 5 - Income/Revenue;
        ''' 6 - Expense.</returns>
        ''' <remarks></remarks>
        Public Shared Function GetAccountClass(ByVal accountID As Long) As Byte

            If Not accountID > 0 Then Return 0

            Dim accountPrefix As Integer = CIntSafe(accountID.ToString.Substring(0, 1), 0)

            If Not accountPrefix > 0 Then Return 0

            Dim currentCompany As ApskaitaObjects.Settings.CompanyInfo = GetCurrentCompany()

            If accountPrefix = currentCompany.AccountClassPrefix11 _
                OrElse (currentCompany.AccountClassPrefix12 > 0 AndAlso
                accountPrefix = currentCompany.AccountClassPrefix12) Then
                Return 1
            ElseIf accountPrefix = currentCompany.AccountClassPrefix21 _
                OrElse (currentCompany.AccountClassPrefix22 > 0 AndAlso
                accountPrefix = currentCompany.AccountClassPrefix22) Then
                Return 2
            ElseIf accountPrefix = currentCompany.AccountClassPrefix31 _
                OrElse (currentCompany.AccountClassPrefix32 > 0 AndAlso
                accountPrefix = currentCompany.AccountClassPrefix32) Then
                Return 3
            ElseIf accountPrefix = currentCompany.AccountClassPrefix41 _
                OrElse (currentCompany.AccountClassPrefix42 > 0 AndAlso
                accountPrefix = currentCompany.AccountClassPrefix42) Then
                Return 4
            ElseIf accountPrefix = currentCompany.AccountClassPrefix51 _
                OrElse (currentCompany.AccountClassPrefix52 > 0 AndAlso
                accountPrefix = currentCompany.AccountClassPrefix52) Then
                Return 5
            ElseIf accountPrefix = currentCompany.AccountClassPrefix61 _
                OrElse (currentCompany.AccountClassPrefix62 > 0 AndAlso
                accountPrefix = currentCompany.AccountClassPrefix62) Then
                Return 6
            Else
                Return 0
            End If

        End Function

        ''' <summary>
        ''' Gets expected fields count in (tab delimited) paste string.
        ''' </summary>
        Public Shared Function GetPasteStringColumnCount() As Integer
            Return ColumnCount
        End Function

        ''' <summary>
        ''' Gets an array of expected fields sequence in (tab delimited) paste string.
        ''' </summary>
        Public Shared Function GetPasteStringColumns() As String()
            Return My.Resources.General_Account_PasteColumns.Split(New String() {"<BR>"},
                StringSplitOptions.RemoveEmptyEntries)
        End Function

        ''' <summary>
        ''' Gets a human readable description of expected fields sequence in (tab delimited) paste string.
        ''' </summary>
        Public Shared Function GetPasteStringColumnsDescription() As String
            Return String.Format(My.Resources.General_Account_PasteColumnsDescription, ColumnCount,
                String.Join(", ", My.Resources.General_Account_PasteColumns.Split(New String() {"<BR>"},
                StringSplitOptions.RemoveEmptyEntries)))
        End Function

        Friend Function ConvertToTabSeparatedString() As String

            Dim result As String

            If _AssociatedReportItem Is Nothing OrElse _AssociatedReportItem.IsEmpty Then
                result = _ID.ToString & vbTab & _Name.ToString & vbTab
            Else
                result = _ID.ToString & vbTab & _Name.ToString & vbTab & _AssociatedReportItem.Name
            End If

            Dim currentDefault As ApskaitaObjects.Settings.CompanyAccountInfo _
                = GetCurrentCompany.Accounts.GetAccountInfo(_ID)
            If Not currentDefault Is Nothing Then
                result = result & vbTab & Utilities.ConvertDatabaseCharID(currentDefault.Type)
            Else
                result = result & vbTab
            End If

            If _SaftCode <> CodeInfo.Empty Then
                result = result & vbTab & _SaftCode.Code & vbTab & _SaftCode.Name
            End If

            Return result

        End Function

        ''' <summary>
        ''' Gets a datatable which columns corresponds to the required imported data 
        ''' (propert name, data type and regionalized caption).
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetDataTableSpecification() As DataTable

            Dim result As New DataTable

            Dim idColumn As New DataColumn("ID", GetType(Long))
            idColumn.Caption = GetResourcesPropertyName(GetType(Account), "ID")
            result.Columns.Add(idColumn)

            Dim nameColumn As New DataColumn("Name", GetType(String))
            nameColumn.Caption = GetResourcesPropertyName(GetType(Account), "Name")
            result.Columns.Add(nameColumn)

            Dim associatedReportItemColumn As New DataColumn("AssociatedReportItem", GetType(String))
            associatedReportItemColumn.Caption = GetResourcesPropertyName(GetType(Account), "AssociatedReportItem")
            result.Columns.Add(associatedReportItemColumn)

            Dim commentsColumn As New DataColumn("Comments", GetType(String))
            commentsColumn.Caption = GetResourcesPropertyName(GetType(Account), "Comments")
            result.Columns.Add(commentsColumn)

            Dim saftCodeColumn As New DataColumn("SaftCode", GetType(String))
            saftCodeColumn.Caption = GetResourcesPropertyName(GetType(Account), "SaftCode")
            result.Columns.Add(saftCodeColumn)

            Dim saftDescriptionColumn As New DataColumn("SaftDescription", GetType(String))
            saftDescriptionColumn.Caption = My.Resources.General_Account_SaftCodeDescription
            result.Columns.Add(saftDescriptionColumn)

            Dim defaultAccountTypeColumn As New DataColumn("DefaultAccountType", GetType(String))
            defaultAccountTypeColumn.Caption = My.Resources.General_Account_DefaultAccountType
            result.Columns.Add(defaultAccountTypeColumn)

            Return result

        End Function



        ''' <summary>
        ''' Inherited method used to differentiate between accounts.
        ''' Having in mind that <see cref="ID" /> properties might get invalid or duplicate 
        ''' while editing the <see cref="General.AccountList" />, a private <see cref="Guid" /> 
        ''' is used for the purpose of differentiating between accounts.
        ''' </summary>
        ''' <returns>A <see cref="Guid" /> that is assigned every time 
        ''' an Account gets fetched or created, i.e. not persisted.</returns>
        ''' <remarks></remarks>
        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        ''' <summary>
        ''' Gets a human readable description of the Account instance.
        ''' </summary>
        ''' <returns>A human readable description of the Account instance:
        ''' <see cref="ID" /> - <see cref="Name" /></returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return String.Format("{0} - {1}", _ID.ToString, _Name)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringValueUniqueInCollectionValidation,
                New Validation.RuleArgs("ID"))

            ValidationRules.AddRule(AddressOf CommonValidation.AccountFieldValidation,
                New Csla.Validation.RuleArgs("ID"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation,
                New Csla.Validation.RuleArgs("Name"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation,
                New Csla.Validation.RuleArgs("Comments"))
            ValidationRules.AddRule(AddressOf CommonValidation.ValueObjectFieldValidation,
                New Csla.Validation.RuleArgs("AssociatedReportItem"))
            ValidationRules.AddRule(AddressOf CommonValidation.CodeAndNameFieldValidation,
                New Csla.Validation.RuleArgs("SaftCode"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Get a new empty account instance.
        ''' </summary>
        Friend Shared Function NewAccount() As Account
            Dim result As New Account
            result.ValidationRules.CheckRules()
            Return result
        End Function

        ''' <summary>
        ''' Get a new account instance by paste string.
        ''' </summary>
        ''' <param name="pasteString">Tab delimited string containing account fields.</param>
        ''' <param name="associatedReportItems">Available <see cref="HelperLists.AssignableCRItemList">AssociatedReportItems</see> to validate pasted data.</param>
        Friend Shared Function NewAccount(ByVal pasteString As String,
            ByVal associatedReportItems As AssignableCRItemList, saftCodeItems As CodeInfoList) As Account
            Return New Account(pasteString, associatedReportItems, saftCodeItems)
        End Function

        ''' <summary>
        ''' Get a new account instance by a datarow in the template datatable, 
        ''' see <see cref="GetDataTableSpecification()">GetDataTableSpecification</see> method.
        ''' </summary>
        ''' <param name="dr">a template datarow that contains account data</param>
        ''' <param name="associatedReportItems">Available <see cref="AssignableCRItemList">AssociatedReportItems</see> to validate pasted data.</param>
        ''' <param name="saftCodeItems">Available <see cref="CodeInfoList">SAF-T code items</see> to validate pasted data.</param>
        Friend Shared Function NewAccount(ByVal dr As DataRow, ByVal associatedReportItems As AssignableCRItemList,
            saftCodeItems As CodeInfoList) As Account
            Return New Account(dr, associatedReportItems, saftCodeItems)
        End Function

        ''' <summary>
        ''' Get an existing account by a database query.
        ''' </summary>
        ''' <param name="dr">DataRow containing account data.</param>
        Friend Shared Function GetAccount(ByVal dr As DataRow) As Account
            Return New Account(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal pasteString As String, ByVal associatedReportItems As AssignableCRItemList, saftCodeItems As CodeInfoList)
            MarkAsChild()
            Create(pasteString, associatedReportItems, saftCodeItems)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal associatedReportItems As AssignableCRItemList,
            saftCodeItems As CodeInfoList)
            MarkAsChild()
            Create(dr, associatedReportItems, saftCodeItems)
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal pasteString As String, ByVal associatedReportItems As AssignableCRItemList,
            saftCodeItems As CodeInfoList)

            _ID = CLongSafe(GetField(pasteString, vbTab, 0), 0)
            _OldID = _ID
            _Name = GetField(pasteString, vbTab, 1)
            _AssociatedReportItem = associatedReportItems.GetItemByName(GetField(pasteString, vbTab, 2))
            _SaftCode = saftCodeItems.GetItemByCode(Settings.CodeType.SaftAccountType,
                GetField(pasteString, vbTab, 4), GetField(pasteString, vbTab, 5))
            _Class = GetAccountClass(_ID)

            ValidationRules.CheckRules()

        End Sub

        Private Sub Create(ByVal dr As DataRow, ByVal associatedReportItems As AssignableCRItemList,
            saftCodeItems As CodeInfoList)

            _ID = DirectCast(dr.Item("ID"), Long)
            _OldID = _ID
            _Name = DirectCast(dr.Item("Name"), String)
            _AssociatedReportItem = associatedReportItems.GetItemByName(DirectCast(dr.Item("AssociatedReportItem"), String))
            _SaftCode = saftCodeItems.GetItemByCode(Settings.CodeType.SaftAccountType,
                DirectCast(dr.Item("SaftCode"), String), DirectCast(dr.Item("SaftDescription"), String))
            _Class = GetAccountClass(_ID)

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CLongSafe(dr.Item(0), 0)
            _OldID = _ID
            _Name = CStrSafe(dr.Item(1))
            _Comments = CStrSafe(dr.Item(2))
            Dim code As String = CStrSafe(dr.Item(3))
            If Not String.IsNullOrEmpty(code.Trim) Then
                _SaftCode = CodeInfo.GetCodeInfo(code, CStrSafe(dr.Item(4)), Settings.CodeType.SaftAccountType)
            End If
            _AssociatedReportItem = AssignableCRItem.GetAssignableCRItem(dr, 5)
            _Class = GetAccountClass(_ID)

            MarkOld()
            ValidationRules.CheckRules()

        End Sub


        Friend Sub Insert(ByVal parent As AccountList)

            Dim myComm As New SQLCommand("InsertAccount")
            AddWithParams(myComm)

            myComm.Execute()

            Me.MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As AccountList)

            Dim myComm As New SQLCommand("UpdateAccount")
            AddWithParams(myComm)
            myComm.AddParam("?TN", _OldID)

            myComm.Execute()

            ' UPDATE account numbers in other tables if it has changed
            If _ID <> _OldID AndAlso Not IsNew Then

                For i As Integer = 1 To 52

                    myComm = New SQLCommand("UpdateAccountsInDocuments" & i.ToString)
                    myComm.AddParam("?AA", _ID)
                    myComm.AddParam("?AB", _OldID)

                    myComm.Execute()

                Next

            End If

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteAccount")
            myComm.AddParam("?NR", _OldID)

            myComm.Execute()

            MarkNew()

        End Sub


        Private Sub AddWithParams(ByRef myComm As SQLCommand)
            myComm.AddParam("?SN", _ID)
            myComm.AddParam("?SP", _Name)
            myComm.AddParam("?CM", _Comments)
            If _AssociatedReportItem Is Nothing OrElse _AssociatedReportItem.IsEmpty Then
                myComm.AddParam("?FD", 0)
            Else
                myComm.AddParam("?FD", _AssociatedReportItem.ID)
            End If
            If _SaftCode = CodeInfo.Empty Then
                myComm.AddParam("?SC", "")
                myComm.AddParam("?SD", "")
            Else
                myComm.AddParam("?SC", _SaftCode.Code)
                myComm.AddParam("?SD", _SaftCode.Name)
            End If
        End Sub

        Friend Sub CheckIfCanDelete()

            Dim myComm As New SQLCommand("AccountWasUsed")
            myComm.AddParam("?CD", _OldID)
            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then Exit Sub

                Dim typeDictionary As New Dictionary(Of String, String)
                typeDictionary.Add("HolidayPayReserves".Trim.ToLower, My.Resources.General_Account_WasUsedByHolidayReserve)
                typeDictionary.Add("AccumulativeCosts".Trim.ToLower, My.Resources.General_Account_WasUsedByAccumulatedCosts)
                typeDictionary.Add("AdvanceReports".Trim.ToLower, My.Resources.General_Account_WasUsedByAdvanceReport)
                typeDictionary.Add("Asmenys".Trim.ToLower, My.Resources.General_Account_WasUsedByPerson)
                typeDictionary.Add("BankOperations".Trim.ToLower, My.Resources.General_Account_WasUsedByBankOperation)
                typeDictionary.Add("bzdata".Trim.ToLower, My.Resources.General_Account_WasUsedByGeneralLedgerEntry)
                typeDictionary.Add("CashAccounts".Trim.ToLower, My.Resources.General_Account_WasUsedByCashAccount)
                typeDictionary.Add("CompanyAccounts".Trim.ToLower, My.Resources.General_Account_WasUsedByDefaultAccounts)
                typeDictionary.Add("du_ziniarastis".Trim.ToLower, My.Resources.General_Account_WasUsedByWageSheet)
                typeDictionary.Add("goods".Trim.ToLower, My.Resources.General_Account_WasUsedByGoodsItem)
                typeDictionary.Add("goodscomplexoperations".Trim.ToLower, My.Resources.General_Account_WasUsedByComplexGoodsOperation)
                typeDictionary.Add("goodsoperations".Trim.ToLower, My.Resources.General_Account_WasUsedByGoodsOperation)
                typeDictionary.Add("goodsaccounts".Trim.ToLower, My.Resources.General_Account_WasUsedByGoodsAccountChangeOperation)
                typeDictionary.Add("InvoicesMade".Trim.ToLower, My.Resources.General_Account_WasUsedByInvoiceMade)
                typeDictionary.Add("InvoicesReceived".Trim.ToLower, My.Resources.General_Account_WasUsedByInvoiceReceived)
                typeDictionary.Add("kalkuliac_d".Trim.ToLower, My.Resources.General_Account_WasUsedByProductionCalculation)
                typeDictionary.Add("kio".Trim.ToLower, My.Resources.General_Account_WasUsedByTillSpendingsOrder)
                typeDictionary.Add("kpo".Trim.ToLower, My.Resources.General_Account_WasUsedByTillIncomeOrder)
                typeDictionary.Add("OffsetItems".Trim.ToLower, My.Resources.General_Account_WasUsedByOffset)
                typeDictionary.Add("Paslaugos".Trim.ToLower, My.Resources.General_Account_WasUsedByService)
                typeDictionary.Add("Tipines_data".Trim.ToLower, My.Resources.General_Account_WasUsedByGeneralLedgerTemplate)
                typeDictionary.Add("Turtas".Trim.ToLower, My.Resources.General_Account_WasUsedByAsset)
                typeDictionary.Add("Turtas_op".Trim.ToLower, My.Resources.General_Account_WasUsedByAssetOperation)
                typeDictionary.Add("warehouses".Trim.ToLower, My.Resources.General_Account_WasUsedByGoodsWarehouse)
                typeDictionary.Add("sharesclasses", My.Resources.General_Account_WasUsedBySharesClass)

                Dim result As String = String.Format(My.Resources.General_Account_WasUsedError, _OldID.ToString) _
                    & vbCrLf

                Dim typeString As String
                For Each dr As DataRow In myData.Rows
                    typeString = typeDictionary.Item(CStrSafe(dr.Item(0)).Trim.ToLower)
                    If typeString Is Nothing OrElse String.IsNullOrEmpty(typeString.Trim) Then _
                        typeString = My.Resources.General_Account_WasUsedByUndefined
                    result = AddWithNewLine(result, String.Format(My.Resources.General_Account_WasUsedItem, _
                        typeString, CIntSafe(dr.Item(1), 0).ToString, CIntSafe(dr.Item(2), 0).ToString, _
                        CDateSafe(dr.Item(3), Date.MinValue).ToString("yyyy-MM-dd")), False)
                Next

                Throw New Exception(result)

            End Using

        End Sub

#End Region

    End Class

End Namespace