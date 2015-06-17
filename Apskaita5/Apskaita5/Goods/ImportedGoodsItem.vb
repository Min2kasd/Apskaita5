Namespace Goods

    <Serializable()> _
    Public Class ImportedGoodsItem
        Inherits BusinessBase(Of ImportedGoodsItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Friend Const ColumnCount As Integer = 18
        Public Const ColumnSequence As String = "Prekės duomenys privalo būti išdėstyti " _
            & "18 stulpelių: pavadinimas, mato vienetas, vidinis kodas, barkodas, " _
            & "grupės pavadinimas, pavadinimas sąskaitoje faktūroje, prekybos tipas(" _
            & "0 - perkamos, 1 - parduodamos, 2 - perkamos ir parduodamos), " _
            & "apskaitos metodas(0 - nuolat, 1 periodiškai), vertinimo metodas(" _
            & "0 - FIFO, 1 - LIFO, 2 - vidurkių), pardavimo savikainos sąskaita, " _
            & "pirkimų sąskaita, nuolaidų sąskaita, nukainojimo sąskaita, " _
            & "pardavimo PVM tarifas, pirkimo PVM tarifas, vnt kaina parduodant, " _
            & "vnt kaina perkant, istorinių duomenų žyma(1/0)."

        Private _GUID As Guid = Guid.NewGuid
        Private _Name As String = ""
        Private _TradedType As Documents.TradedItemType = Documents.TradedItemType.All
        Private _DefaultAccountingMethod As GoodsAccountingMethod = GoodsAccountingMethod.Persistent
        Private _DefaultValuationMethod As GoodsValuationMethod = GoodsValuationMethod.FIFO
        Private _AccountSalesNetCosts As Long = 0
        Private _AccountPurchases As Long = 0
        Private _AccountDiscounts As Long = 0
        Private _AccountValueReduction As Long = 0
        Private _DefaultVatRateSales As Double = 0
        Private _DefaultVatRatePurchase As Double = 0
        Private _GroupInfo As GoodsGroupInfo = Nothing
        Private _IsObsolete As Boolean = False
        Private _ContentInvoice As String = ""
        Private _MeasureUnit As String = ""
        Private _ValuePerUnitSales As Double = 0
        Private _ValuePerUnitPurchases As Double = 0
        Private _InternalCode As String = ""
        Private _Barcode As String = ""
        Private _AlreadyPresent As Boolean = False
        Private _NotUniqueName As Boolean = False


        Public ReadOnly Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
        End Property

        Public ReadOnly Property TypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ConvertEnumHumanReadable(_TradedType)
            End Get
        End Property

        Public ReadOnly Property AccountSalesNetCosts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountSalesNetCosts
            End Get
        End Property

        Public ReadOnly Property AccountPurchases() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountPurchases
            End Get
        End Property

        Public ReadOnly Property AccountDiscounts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountDiscounts
            End Get
        End Property

        Public ReadOnly Property AccountValueReduction() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountValueReduction
            End Get
        End Property

        Public ReadOnly Property DefaultVatRateSales() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DefaultVatRateSales)
            End Get
        End Property

        Public ReadOnly Property DefaultVatRatePurchase() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DefaultVatRatePurchase)
            End Get
        End Property

        Public ReadOnly Property DefaultAccountingMethodHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ConvertEnumHumanReadable(_DefaultAccountingMethod)
            End Get
        End Property

        Public ReadOnly Property DefaultValuationMethodHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ConvertEnumHumanReadable(_DefaultValuationMethod)
            End Get
        End Property

        Public ReadOnly Property GroupInfo() As GoodsGroupInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GroupInfo
            End Get
        End Property

        Public ReadOnly Property IsObsolete() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsObsolete
            End Get
        End Property

        Public ReadOnly Property ContentInvoice() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContentInvoice.Trim
            End Get
        End Property

        Public ReadOnly Property MeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MeasureUnit.Trim
            End Get
        End Property

        Public ReadOnly Property ValuePerUnitSales() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValuePerUnitSales, ROUNDUNITINVOICEMADE)
            End Get
        End Property

        Public ReadOnly Property ValuePerUnitPurchases() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ValuePerUnitPurchases, ROUNDUNITINVOICERECEIVED)
            End Get
        End Property

        Public ReadOnly Property InternalCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InternalCode.Trim
            End Get
        End Property

        Public ReadOnly Property Barcode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Barcode.Trim
            End Get
        End Property

        Public ReadOnly Property AlreadyPresent() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AlreadyPresent
            End Get
        End Property

        Public ReadOnly Property NotUniqueName() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NotUniqueName
            End Get
        End Property


        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & _Name & "': " & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
        Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & _Name & "' gali būti klaida: " & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _GUID
        End Function

        Public Overrides Function ToString() As String
            Return _Name
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Name", "prekės pavadinimas"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("AccountValueReduction", "nukainojimo sąskaita"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("MeasureUnit", "prekės mato vienetas"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("ContentInvoice", "pavadinimas sąskaitoje"))

            ValidationRules.AddRule(AddressOf AccountSalesNetCostsValidation, _
                New Validation.RuleArgs("AccountSalesNetCosts"))
            ValidationRules.AddRule(AddressOf AccountPurchasesValidation, _
                New Validation.RuleArgs("AccountPurchases"))
            ValidationRules.AddRule(AddressOf AccountDiscountsValidation, _
                New Validation.RuleArgs("AccountDiscounts"))
            ValidationRules.AddRule(AddressOf AlreadyPresentValidation, _
                New Validation.RuleArgs("AlreadyPresent"))
            ValidationRules.AddRule(AddressOf NotUniqueCodeValidation, _
                New Validation.RuleArgs("NotUniqueCode"))

            ValidationRules.AddDependantProperty("AccountingMethod", "AccountSalesNetCosts", False)
            ValidationRules.AddDependantProperty("AccountingMethod", "AccountPurchases", False)
            ValidationRules.AddDependantProperty("AccountingMethod", "AccountDiscounts", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property AccountSalesNetCosts is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountSalesNetCostsValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As ImportedGoodsItem = DirectCast(target, ImportedGoodsItem)

            If ValObj._DefaultAccountingMethod = GoodsAccountingMethod.Periodic AndAlso _
                Not ValObj._AccountSalesNetCosts > 0 Then
                e.Description = "Nenurodyta pardavimų sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountPurchases is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountPurchasesValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As ImportedGoodsItem = DirectCast(target, ImportedGoodsItem)

            If ValObj._DefaultAccountingMethod = GoodsAccountingMethod.Periodic AndAlso _
                Not ValObj._AccountPurchases > 0 Then
                e.Description = "Nenurodyta pirkimų sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountDiscounts is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountDiscountsValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As ImportedGoodsItem = DirectCast(target, ImportedGoodsItem)

            If ValObj._DefaultAccountingMethod = GoodsAccountingMethod.Periodic AndAlso _
                Not ValObj._AccountDiscounts > 0 Then
                e.Description = "Nenurodyta gautų nuolaidų sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        Private Shared Function AlreadyPresentValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As ImportedGoodsItem = DirectCast(target, ImportedGoodsItem)

            If ValObj._AlreadyPresent Then
                e.Description = "Prekė su tokiu pavadinimu ir grupe jau yra įtraukta į duomenų bazę."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        Private Shared Function NotUniqueCodeValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As ImportedGoodsItem = DirectCast(target, ImportedGoodsItem)

            If ValObj._NotUniqueName Then
                e.Description = "Importuojamuose duomenyse tokia prekės pavadinimo ir grupės kombinacija neunikali."
                e.Severity = Validation.RuleSeverity.Error
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

        Friend Shared Function GetImportedGoodsItem(ByVal s As String(), _
            ByVal groups As GoodsGroupInfoList, ByVal accountList As List(Of Long), _
            ByVal goodsInDatabase As List(Of String), _
            ByRef previousGoods As List(Of String)) As ImportedGoodsItem
            Return New ImportedGoodsItem(s, groups, accountList, goodsInDatabase, previousGoods)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal s As String(), ByVal groups As GoodsGroupInfoList, _
            ByVal accountList As List(Of Long), ByVal goodsInDatabase As List(Of String), _
            ByRef previousGoods As List(Of String))
            MarkAsChild()
            Fetch(s, groups, accountList, goodsInDatabase, previousGoods)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal s As String(), ByVal groups As GoodsGroupInfoList, _
            ByVal accountList As List(Of Long), ByVal goodsInDatabase As List(Of String), _
            ByRef previousGoods As List(Of String))

            _Name = CStrSafe(GetItem(s, 0)).Trim
            _MeasureUnit = CStrSafe(GetItem(s, 1)).Trim
            _InternalCode = CStrSafe(GetItem(s, 2)).Trim
            _Barcode = CStrSafe(GetItem(s, 3)).Trim
            _GroupInfo = groups.GetGoodsGroupInfoByName(CStrSafe(GetItem(s, 4)).Trim)
            _ContentInvoice = CStrSafe(GetItem(s, 5)).Trim
            _TradedType = EnumValueAttribute.ConvertDatabaseID(Of Documents.TradedItemType) _
                (CIntSafe(GetItem(s, 6), 2))
            _DefaultAccountingMethod = ConvertEnumDatabaseCode(Of GoodsAccountingMethod) _
                (CIntSafe(GetItem(s, 7), 0))
            _DefaultValuationMethod = ConvertEnumDatabaseCode(Of GoodsValuationMethod) _
                (CIntSafe(GetItem(s, 8)))
            _AccountSalesNetCosts = CLongSafe(GetItem(s, 9), 0)
            _AccountPurchases = CLongSafe(GetItem(s, 10), 0)
            _AccountDiscounts = CLongSafe(GetItem(s, 11), 0)
            _AccountValueReduction = CLongSafe(GetItem(s, 12), 0)
            Double.TryParse(CStrSafe(GetItem(s, 13)), _DefaultVatRateSales)
            _DefaultVatRateSales = CRound(_DefaultVatRateSales)
            Double.TryParse(CStrSafe(GetItem(s, 14)), _DefaultVatRatePurchase)
            _DefaultVatRatePurchase = CRound(_DefaultVatRatePurchase)
            Double.TryParse(CStrSafe(GetItem(s, 15)), _ValuePerUnitSales)
            _ValuePerUnitSales = CRound(_ValuePerUnitSales, ROUNDUNITINVOICEMADE)
            Double.TryParse(CStrSafe(GetItem(s, 16)), _ValuePerUnitPurchases)
            _ValuePerUnitPurchases = CRound(_ValuePerUnitPurchases, ROUNDUNITINVOICERECEIVED)
            _IsObsolete = ConvertDbBoolean(CIntSafe(GetItem(s, 17), 0))

            If Not accountList.Contains(_AccountSalesNetCosts) Then _AccountSalesNetCosts = 0
            If Not accountList.Contains(_AccountPurchases) Then _AccountPurchases = 0
            If Not accountList.Contains(_AccountDiscounts) Then _AccountDiscounts = 0
            If Not accountList.Contains(_AccountValueReduction) Then _AccountValueReduction = 0

            If Not String.IsNullOrEmpty(_Name.Trim) Then

                Dim groupedName As String = _Name.Trim.ToUpper
                If Not _GroupInfo Is Nothing AndAlso _GroupInfo.ID > 0 Then _
                    groupedName = groupedName & _GroupInfo.Name.Trim.ToUpper

                If goodsInDatabase.Contains(groupedName) Then
                    _AlreadyPresent = True
                Else
                    _AlreadyPresent = False
                End If

                If previousGoods.Contains(groupedName) Then
                    _NotUniqueName = True
                Else
                    _NotUniqueName = False
                    previousGoods.Add(groupedName)
                End If

            End If

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert()

            Dim item As GoodsItem = GoodsItem.NewGoodsItem

            item.AccountDiscounts = _AccountDiscounts
            item.AccountingMethod = _DefaultAccountingMethod
            item.AccountPurchases = _AccountPurchases
            item.AccountSalesNetCosts = _AccountSalesNetCosts
            item.AccountValueReduction = _AccountValueReduction
            item.Barcode = _Barcode
            item.DefaultValuationMethod = _DefaultValuationMethod
            item.DefaultVatRatePurchase = _DefaultVatRatePurchase
            item.DefaultVatRateSales = _DefaultVatRateSales
            item.Group = _GroupInfo
            item.InternalCode = _InternalCode
            item.IsObsolete = _IsObsolete
            item.MeasureUnit = _MeasureUnit
            item.Name = _Name
            item.TradedType = _TradedType

            item.RegionalContents.AddNew()
            item.RegionalContents(0).ContentInvoice = _ContentInvoice
            item.RegionalContents(0).MeasureUnit = _MeasureUnit
            item.RegionalContents(0).LanguageCode = LanguageCodeLith

            If Not CRound(_ValuePerUnitPurchases, 4) > 0 AndAlso _
                Not CRound(_ValuePerUnitSales, ROUNDUNITINVOICEMADE) > 0 Then
                item.RegionalPrices.AddNew()
                item.RegionalPrices(0).CurrencyCode = GetCurrentCompany.BaseCurrency
                item.RegionalPrices(0).ValuePerUnitPurchases = _ValuePerUnitPurchases
                item.RegionalPrices(0).ValuePerUnitSales = _ValuePerUnitSales
            End If

            item.DoInsert()

            MarkOld()

        End Sub

        Private Function GetItem(ByVal s As String(), ByVal index As Integer) As String
            If s Is Nothing OrElse index + 1 > s.Length Then Return ""
            Return s(index)
        End Function

#End Region

    End Class

End Namespace