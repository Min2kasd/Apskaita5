Namespace Goods

    <Serializable()> _
    Public Class GoodsOperationDiscount
        Inherits BusinessBase(Of GoodsOperationDiscount)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _GoodsInfo As GoodsSummary = Nothing
        Private _OperationLimitations As OperationalLimitList = Nothing
        Private _OldDate As Date = Today
        Private _Date As Date = Today
        Private _Description As String = ""
        Private _Warehouse As WarehouseInfo = Nothing
        Private _JournalEntryID As Integer = 0
        Private _JournalEntryDate As Date = Today
        Private _JournalEntryContent As String = ""
        Private _JournalEntryCorrespondence As String = ""
        Private _JournalEntryRelatedPerson As String = ""
        Private _JournalEntryType As DocumentType = DocumentType.None
        Private _JournalEntryTypeHumanReadable As String = ""
        Private _DocumentNumber As String = ""
        Private _AccountGoodsNetCosts As Long = 0
        Private _TotalValueChange As Double = 0
        Private _TotalGoodsValueChange As Double = 0
        Private _TotalNetValueChange As Double = 0
        Private _AccountPurchasesIsClosed As Boolean = False
        Private WithEvents _Consignments As ConsignmentItemList = Nothing
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now


        Private SuspendChildListChangedEvents As Boolean = False
        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _ConsignmentsSortedList As Csla.SortedBindingList(Of ConsignmentItem) = Nothing

        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property GoodsInfo() As GoodsSummary
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo
            End Get
        End Property

        Public ReadOnly Property OperationLimitations() As OperationalLimitList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationLimitations
            End Get
        End Property

        Public ReadOnly Property Warehouse() As WarehouseInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Warehouse
            End Get
        End Property

        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        Public ReadOnly Property JournalEntryDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryDate
            End Get
        End Property

        Public ReadOnly Property JournalEntryContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryContent.Trim
            End Get
        End Property

        Public ReadOnly Property JournalEntryCorrespondence() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryCorrespondence.Trim
            End Get
        End Property

        Public ReadOnly Property JournalEntryRelatedPerson() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryRelatedPerson.Trim
            End Get
        End Property

        Public ReadOnly Property JournalEntryType() As DocumentType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryType
            End Get
        End Property

        Public ReadOnly Property JournalEntryTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryTypeHumanReadable.Trim
            End Get
        End Property

        Public ReadOnly Property DocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber.Trim
            End Get
        End Property

        Public ReadOnly Property OldDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OldDate
            End Get
        End Property

        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If DateIsReadOnly Then Exit Property
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Description() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Description.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If DescriptionIsReadOnly Then Exit Property
                If value Is Nothing Then value = ""
                If _Description.Trim <> value.Trim Then
                    _Description = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property AccountGoodsNetCosts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic _
                    AndAlso Not _AccountPurchasesIsClosed Then
                    Return _GoodsInfo.AccountDiscounts
                ElseIf _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic _
                    AndAlso _AccountPurchasesIsClosed Then
                    Return _GoodsInfo.AccountSalesNetCosts
                Else
                    Return _AccountGoodsNetCosts
                End If
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountGoodsNetCostsIsReadOnly Then Exit Property
                If _AccountGoodsNetCosts <> value Then
                    _AccountGoodsNetCosts = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property AccountGoodsGeneral() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic _
                    AndAlso Not _AccountPurchasesIsClosed Then
                    Return _GoodsInfo.AccountDiscounts
                Else
                    If _Warehouse Is Nothing Then Return 0
                    Return _Warehouse.WarehouseAccount
                End If
            End Get
        End Property

        Public Property AccountPurchasesIsClosed() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountPurchasesIsClosed
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If AccountPurchasesIsClosedIsReadOnly Then Exit Property
                If _AccountPurchasesIsClosed <> value Then
                    _AccountPurchasesIsClosed = value
                    PropertyHasChanged()
                    PropertyHasChanged("AccountGoodsGeneral")
                    PropertyHasChanged("AccountGoodsNetCosts")
                    If Not _AccountPurchasesIsClosed Then Recalculate()
                End If
            End Set
        End Property

        Public Property TotalValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalValueChange)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If TotalValueChangeIsReadOnly Then Exit Property
                If CRound(_TotalValueChange) <> CRound(value) Then
                    _TotalValueChange = CRound(value)
                    PropertyHasChanged()
                    Recalculate()
                End If
            End Set
        End Property

        Public Property TotalGoodsValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalGoodsValueChange)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If TotalGoodsValueChangeIsReadOnly Then Exit Property
                If CRound(_TotalGoodsValueChange) <> CRound(value) Then
                    _TotalGoodsValueChange = CRound(value)
                    PropertyHasChanged()
                    Recalculate()
                End If
            End Set
        End Property

        Public ReadOnly Property TotalNetValueChange() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalNetValueChange)
            End Get
        End Property

        Public ReadOnly Property Consignments() As ConsignmentItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Consignments
            End Get
        End Property

        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property


        Public ReadOnly Property DateIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return IsChild OrElse (Not Me.IsNew AndAlso _JournalEntryID > 0 AndAlso ( _
                    _JournalEntryType = DocumentType.InvoiceMade OrElse _
                    _JournalEntryType = DocumentType.InvoiceReceived))
            End Get
        End Property

        Public ReadOnly Property DescriptionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not Me.IsChild AndAlso Not Me.IsNew AndAlso _JournalEntryID > 0 AndAlso ( _
                    _JournalEntryType = DocumentType.InvoiceMade OrElse _
                    _JournalEntryType = DocumentType.InvoiceReceived)
            End Get
        End Property

        Public ReadOnly Property AccountGoodsNetCostsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic _
                    OrElse Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso Not Me.IsNew AndAlso _JournalEntryID > 0 _
                    AndAlso (_JournalEntryType = DocumentType.InvoiceMade OrElse _
                    _JournalEntryType = DocumentType.InvoiceReceived))
            End Get
        End Property

        Public ReadOnly Property AccountPurchasesIsClosedIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethod <> GoodsAccountingMethod.Periodic _
                    OrElse Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso Not Me.IsNew AndAlso _JournalEntryID > 0 _
                    AndAlso (_JournalEntryType = DocumentType.InvoiceMade OrElse _
                    _JournalEntryType = DocumentType.InvoiceReceived))
            End Get
        End Property

        Public ReadOnly Property TotalValueChangeIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Me.IsChild OrElse Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsNew AndAlso _JournalEntryID > 0 AndAlso _
                    (_JournalEntryType = DocumentType.InvoiceMade OrElse _
                    _JournalEntryType = DocumentType.InvoiceReceived))
            End Get
        End Property

        Public ReadOnly Property TotalGoodsValueChangeIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (_GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic AndAlso _
                    Not _AccountPurchasesIsClosed) OrElse _
                    Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso Not Me.IsNew AndAlso _JournalEntryID > 0 _
                    AndAlso (_JournalEntryType = DocumentType.InvoiceMade OrElse _
                    _JournalEntryType = DocumentType.InvoiceReceived))
            End Get
        End Property

        Public ReadOnly Property AssociatedJournalEntryIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Me.IsChild OrElse (Not Me.IsNew AndAlso _JournalEntryID > 0 AndAlso _
                    (_JournalEntryType = DocumentType.InvoiceMade OrElse _
                    _JournalEntryType = DocumentType.InvoiceReceived))
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_Description.Trim) _
                    OrElse CRound(_TotalValueChange) > 0 _
                    OrElse CRound(_TotalGoodsValueChange) > 0)
            End Get
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _Consignments.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _Consignments.IsValid
            End Get
        End Property



        Public Overrides Function Save() As GoodsOperationDiscount

            If IsNew AndAlso Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")
            If Not IsNew AndAlso Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka duomenims pakeisti.")

            If _JournalEntryType = DocumentType.InvoiceMade Then Throw New Exception( _
                "Klaida. Ši operacija yra sudedamoji išrašytos sąskaitos faktūros dalis, " _
                & "ją keisti galima tik kartu su atitinkama sąskaita faktūra.")
            If _JournalEntryType = DocumentType.InvoiceReceived Then Throw New Exception( _
                "Klaida. Ši operacija yra sudedamoji gautos sąskaitos faktūros dalis, " _
                & "ją keisti galima tik kartu su atitinkama sąskaita faktūra.")

            Me.ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Duomenyse yra klaidų: " _
                & vbCrLf & Me.GetAllBrokenRules)

            Return MyBase.Save

        End Function


        Public Function GetSortedList() As Csla.SortedBindingList(Of ConsignmentItem)

            If _ConsignmentsSortedList Is Nothing Then
                _ConsignmentsSortedList = New Csla.SortedBindingList(Of ConsignmentItem)(_Consignments)
            End If

            Return _ConsignmentsSortedList

        End Function

        Public Sub LoadAssociatedJournalEntry(ByVal Entry As ActiveReports.JournalEntryInfo)

            If AssociatedJournalEntryIsReadOnly Then Exit Sub

            If Entry Is Nothing OrElse Not Entry.Id > 0 Then Exit Sub

            If Entry.DocType = DocumentType.InvoiceMade OrElse Entry.DocType = DocumentType.InvoiceReceived Then
                Throw New Exception("Prekių nuolaida pagal sąskaitą faktūrą " _
                    & "gali būti registruojamas tik per atitinkamą sąskaitą faktūrą.")
            ElseIf Entry.DocType = DocumentType.Amortization Then
                Throw New Exception("Prekių nuolaida negali būti pagal ilgalaikio turto amortizacijos dokumentą.")
            ElseIf Entry.DocType = DocumentType.ClosingEntries Then
                Throw New Exception("Prekių nuolaida negali būti pagal 5/6 klasių uždarymo dokumentą.")
            ElseIf Entry.DocType = DocumentType.GoodsProduction Then
                Throw New Exception("Prekių nuolaida negali būti pagal prekių gamybos dokumentą.")
            ElseIf Entry.DocType = DocumentType.GoodsRevalue Then
                Throw New Exception("Prekių nuolaida negali būti pagal prekių nukainojimo dokumentą.")
            ElseIf Entry.DocType = DocumentType.GoodsWriteOff Then
                Throw New Exception("Prekių nuolaida negali būti pagal prekių nurašymo dokumentą.")
            ElseIf Entry.DocType = DocumentType.ImprestSheet Then
                Throw New Exception("Prekių nuolaida negali būti pagal darbo užmokesčio avanso žiniaraštį.")
            ElseIf Entry.DocType = DocumentType.LongTermAssetAccountChange Then
                Throw New Exception("Prekių nuolaida negali būti pagal ilgalaikio turto apskaitos sąskaitos pakeitimo dokumentą.")
            ElseIf Entry.DocType = DocumentType.Offset Then
                Throw New Exception("Prekių nuolaida negali būti pagal užskaitos dokumentą.")
            ElseIf Entry.DocType = DocumentType.WageSheet Then
                Throw New Exception("Prekių nuolaida negali būti pagal darbo užmokesčio žiniaraštį.")
            ElseIf Entry.Date.Date <> _Date.Date Then
                Throw New Exception("Klaida. Susietas bendrojo žurnalo įrašas privalo būti tos pačios datos kaip ir operacija.")
            End If

            _JournalEntryID = Entry.Id
            _JournalEntryDate = Entry.Date
            _JournalEntryContent = Entry.Content
            _JournalEntryCorrespondence = Entry.BookEntries
            _JournalEntryRelatedPerson = Entry.Person
            _JournalEntryType = Entry.DocType
            _JournalEntryTypeHumanReadable = Entry.DocTypeHumanReadable
            _DocumentNumber = Entry.DocNumber

            PropertyHasChanged("JournalEntryID")
            PropertyHasChanged("JournalEntryDate")
            PropertyHasChanged("JournalEntryContent")
            PropertyHasChanged("JournalEntryCorrespondence")
            PropertyHasChanged("JournalEntryRelatedPerson")
            PropertyHasChanged("JournalEntryType")
            PropertyHasChanged("JournalEntryTypeHumanReadable")
            PropertyHasChanged("DocumentNumber")

        End Sub


        Friend Sub SetDate(ByVal value As Date)
            If Not IsChild Then Throw New InvalidOperationException( _
                "Klaida. Metodas SetDate gali būti naudojamas tik child objektui.")
            If _Date.Date <> value.Date Then
                _Date = value.Date
                PropertyHasChanged("Date")
            End If
        End Sub

        Friend Sub SetTotalValueChange(ByVal value As Double)

            If Not IsChild Then Throw New InvalidOperationException("Klaida. Metodas " _
                & "SetTotalValueChange gali būti taikomas tik Child objektui.")

            If Not _OperationLimitations.FinancialDataCanChange Then Exit Sub

            If CRound(_TotalValueChange) <> CRound(value) Then
                _TotalValueChange = CRound(value)
                PropertyHasChanged("TotalValueChange")
                Recalculate()
            End If

        End Sub

        Friend Sub SetAssociatedJournalEntryID(ByVal EntryID As Integer)
            If Not IsChild Then Throw New InvalidOperationException( _
                "Klaida. Metodas SetAssociatedJournalEntryID gali būti naudojamas tik child objektui.")
            If _JournalEntryID <> EntryID Then _JournalEntryID = EntryID
        End Sub


        Public Function GetAllBrokenRules() As String
            Dim result As String = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error).Trim
            result = AddWithNewLine(result, _Consignments.GetAllBrokenRules, False)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning).Trim
            result = AddWithNewLine(result, _Consignments.GetAllWarnings(), False)


            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function


        Private Sub Recalculate()

            If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic _
                AndAlso Not _AccountPurchasesIsClosed Then
                _TotalGoodsValueChange = CRound(_TotalValueChange)
                PropertyHasChanged("TotalGoodsValueChange")
            End If

            _TotalNetValueChange = CRound(_TotalValueChange - _TotalGoodsValueChange)
            PropertyHasChanged("TotalNetValueChange")

        End Sub


        Private Sub Consignments_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _Consignments.ListChanged

            If SuspendChildListChangedEvents Then Exit Sub

            If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic Then Exit Sub

            _TotalGoodsValueChange = _Consignments.GetTotalValueChange
            PropertyHasChanged("TotalGoodsValueChange")
            Recalculate()
            PropertyHasChanged("Date")

        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As GoodsOperationDiscount = DirectCast(MyBase.GetClone(), GoodsOperationDiscount)
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
        ''' Helper method. Takes care of Consignments loosing its handler. See GetClone method.
        ''' </summary>
        Friend Sub RestoreChildListsHandles()
            Try
                RemoveHandler _Consignments.ListChanged, AddressOf Consignments_Changed
            Catch ex As Exception
            End Try
            AddHandler _Consignments.ListChanged, AddressOf Consignments_Changed
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return "Goods.GoodsOperationDiscount"
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Description", "operacijos aprašymas", _
                Validation.RuleSeverity.Warning))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("TotalValueChange", _
                "bendra taikomos nuolaidos suma"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("AccountGoodsGeneral", "bendra prekių sąskaita"))

            ValidationRules.AddRule(AddressOf TotalNetValueChangeValidation, _
                New Validation.RuleArgs("TotalNetValueChange"))
            ValidationRules.AddRule(AddressOf DateValidation, New Validation.RuleArgs("Date"))
            ValidationRules.AddRule(AddressOf JournalEntryValidation, _
                New Validation.RuleArgs("JournalEntryID"))
            ValidationRules.AddRule(AddressOf AccountGoodsNetCostsValidation, _
                New Validation.RuleArgs("AccountGoodsNetCosts"))

            ValidationRules.AddDependantProperty("Date", "JournalEntryID", False)
            ValidationRules.AddDependantProperty("TotalNetValueChange", "AccountGoodsNetCosts", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property Date is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DateValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As GoodsOperationDiscount = DirectCast(target, GoodsOperationDiscount)

            If Not ValObj._OperationLimitations Is Nothing AndAlso _
                Not ValObj._OperationLimitations.ValidateOperationDate(ValObj._Date, _
                e.Description, e.Severity) Then Return False

            If ValObj._Date.Date < ValObj._Consignments.GetMaxDate.Date Then
                e.Description = "Operacijos data negali būti ankstesnė už paskutinės keičiamos partijos datą."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that associated journal entry is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function JournalEntryValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As GoodsOperationDiscount = DirectCast(target, GoodsOperationDiscount)

            If Not ValObj.IsChild AndAlso Not ValObj._JournalEntryID > 0 Then
                e.Description = "Nenurodytas susietas bendrojo žurnalo įrašas " & _
                    "(dokumentas, pagrindžiantis nuolaidą)."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf Not ValObj.IsChild AndAlso ValObj._JournalEntryDate.Date <> ValObj._Date.Date Then
                e.Description = "Susieto bendrojo žurnalo įrašo (dokumento, " & _
                    "pagrindžiančio įsigijimą) data nesutampa su operacijos data."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property TotalNetValueChange is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function TotalNetValueChangeValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As GoodsOperationDiscount = DirectCast(target, GoodsOperationDiscount)

            If ValObj.TotalNetValueChange < 0 Then
                e.Description = "Nuolaidos dalis, tenkanti nurašytoms prekėms, negali būti mažesnė už nulį."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountGoodsNetCosts is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountGoodsNetCostsValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As GoodsOperationDiscount = DirectCast(target, GoodsOperationDiscount)

            If ValObj._TotalNetValueChange > 0 AndAlso Not ValObj.AccountGoodsNetCosts > 0 Then
                e.Description = "Nenurodyta prekių pardavimo savikainos sąskaita."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Goods.GoodsOperationDiscount2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationDiscount1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationDiscount2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationDiscount3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationDiscount3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewGoodsOperationDiscount(ByVal nGoodsID As Integer, _
            ByVal nWarehouseID As Integer) As GoodsOperationDiscount
            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka naujiems duomenims įvesti.")
            Return DataPortal.Create(Of GoodsOperationDiscount)(New Criteria(nGoodsID, nWarehouseID))
        End Function

        Friend Shared Function NewGoodsOperationDiscountChild(ByVal nGoodsID As Integer, _
            ByVal nWarehouseID As Integer) As GoodsOperationDiscount
            Return New GoodsOperationDiscount(nGoodsID, nWarehouseID)
        End Function

        Public Shared Function GetGoodsOperationDiscount(ByVal nID As Integer) As GoodsOperationDiscount
            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")
            Return DataPortal.Fetch(Of GoodsOperationDiscount)(New Criteria(nID))
        End Function

        Friend Shared Function GetGoodsOperationDiscountChild(ByVal nID As Integer) As GoodsOperationDiscount
            Return New GoodsOperationDiscount(nID)
        End Function

        Public Shared Sub DeleteGoodsOperationDiscount(ByVal id As Integer)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka sąskaitos duomenų ištrynimui.")

            DataPortal.Delete(New Criteria(id, 0))

        End Sub

        Friend Sub DeleteGoodsOperationDiscountChild()
            If Not IsChild Then Throw New InvalidOperationException( _
                "Method DeleteGoodsOperationAcquisitionChild is only applicable to child object.")
            DoDelete()
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal nGoodsID As Integer, ByVal nWarehouseID As Integer)
            MarkAsChild()
            Create(nGoodsID, nWarehouseID)
        End Sub

        Private Sub New(ByVal nOperationID As Integer)
            MarkAsChild()
            Fetch(nOperationID)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private mId As Integer
            Private mWarehouseId As Integer
            Public ReadOnly Property Id() As Integer
                Get
                    Return mId
                End Get
            End Property
            Public ReadOnly Property WarehouseId() As Integer
                Get
                    Return mWarehouseId
                End Get
            End Property
            Public Sub New(ByVal id As Integer)
                mId = id
                mWarehouseId = 0
            End Sub
            Public Sub New(ByVal nGoodsID As Integer, ByVal nWarehouseID As Integer)
                mId = nGoodsID
                mWarehouseId = nWarehouseID
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
            Create(criteria.Id, criteria.WarehouseId)
        End Sub

        Private Sub Create(ByVal nGoodsID As Integer, ByVal nWarehouseID As Integer)

            _GoodsInfo = GoodsSummary.GetGoodsSummary(nGoodsID)
            _Warehouse = _GoodsInfo.DefaultWarehouse
            _AccountGoodsNetCosts = _GoodsInfo.AccountSalesNetCosts
            Dim wid As Integer = 0
            If Not _Warehouse Is Nothing AndAlso _Warehouse.ID > 0 Then wid = _Warehouse.ID
            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                nGoodsID, 0, GoodsOperationType.ConsignmentDiscount, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, Today, wid, Nothing)
            _Consignments = ConsignmentItemList.NewConsignmentItemList(nGoodsID, nWarehouseID, _
                True, True, _GoodsInfo.AccountingMethod)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)
            Fetch(criteria.Id)
        End Sub

        Private Sub Fetch(ByVal nOperationID As Integer)

            Dim obj As OperationPersistenceObject = OperationPersistenceObject. _
                GetOperationPersistenceObject(nOperationID, True)

            If obj.OperationType <> GoodsOperationType.ConsignmentDiscount Then Throw New Exception( _
                "Operacijos, kurios ID=" & nOperationID.ToString & " tipas yra ne " & _
                "nuolaida, o " & ConvertEnumHumanReadable(obj.OperationType) & ".")

            _ID = obj.ID
            _Date = obj.OperationDate
            _OldDate = _Date
            _Description = obj.Content
            _TotalValueChange = -obj.TotalValue
            _Warehouse = obj.Warehouse
            _JournalEntryID = obj.JournalEntryID
            _JournalEntryDate = obj.JournalEntryDate
            _JournalEntryContent = obj.JournalEntryContent
            _JournalEntryCorrespondence = obj.JournalEntryCorrespondence
            _JournalEntryRelatedPerson = obj.JournalEntryRelatedPerson
            _JournalEntryType = obj.JournalEntryType
            _JournalEntryTypeHumanReadable = obj.JournalEntryTypeHumanReadable
            _DocumentNumber = obj.DocNo
            _InsertDate = obj.InsertDate
            _UpdateDate = obj.UpdateDate
            _GoodsInfo = obj.GoodsInfo

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(obj.GoodsID, _
                obj.ID, GoodsOperationType.ConsignmentDiscount, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, obj.OperationDate, obj.WarehouseID, Nothing)

            _Consignments = ConsignmentItemList.GetConsignmentItemList(_ID, _GoodsInfo.ID, _
                _Warehouse.ID, True, _OperationLimitations.FinancialDataCanChange, _
                _GoodsInfo.AccountingMethod)

            If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Persistent Then
                _TotalNetValueChange = obj.AccountOperationValue
                _TotalGoodsValueChange = CRound(_TotalValueChange - _TotalNetValueChange)
                _AccountGoodsNetCosts = obj.AccountOperation
            Else
                If obj.AccountDiscounts > 0 Then
                    _AccountPurchasesIsClosed = False
                    _TotalGoodsValueChange = _TotalValueChange
                    _TotalNetValueChange = 0
                Else
                    _AccountPurchasesIsClosed = True
                    _TotalGoodsValueChange = obj.AccountGeneral
                    _TotalNetValueChange = CRound(_TotalValueChange - _TotalGoodsValueChange)
                End If
            End If

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            CheckIfCanUpdate()

            DoSave(False)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                _ID, GoodsOperationType.ConsignmentDiscount, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _Warehouse.ID, Nothing)

            ValidationRules.CheckRules()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            CheckIfCanUpdate()

            OperationPersistenceObject.CheckIfUpdateDateChanged(_ID, _UpdateDate)

            DoSave(False)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                _ID, GoodsOperationType.ConsignmentDiscount, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _Warehouse.ID, Nothing)

            ValidationRules.CheckRules()

        End Sub

        Friend Sub SaveChild(ByVal ParentJournalEntryID As Integer, ByVal ParentDate As Date, _
            ByVal ParentContent As String, ByVal ParentDocNo As String, ByVal FinancialDataReadOnly As Boolean)
            _Date = ParentDate
            _JournalEntryID = ParentJournalEntryID
            _Description = ParentContent
            _DocumentNumber = ParentDocNo
            DoSave(FinancialDataReadOnly)
        End Sub

        Private Sub DoSave(ByVal FinancialDataReadOnly As Boolean)

            Dim obj As OperationPersistenceObject = GetPersistenceObj()

            Dim TransactionExisted As Boolean = DatabaseAccess.TransactionExists
            If Not TransactionExisted Then DatabaseAccess.TransactionBegin()

            If IsNew Then
                _ID = obj.Save(_OperationLimitations.FinancialDataCanChange AndAlso Not FinancialDataReadOnly)
            Else
                obj.Save(_OperationLimitations.FinancialDataCanChange AndAlso Not FinancialDataReadOnly)
            End If

            If _GoodsInfo.AccountingMethod <> GoodsAccountingMethod.Periodic AndAlso _
                _OperationLimitations.FinancialDataCanChange AndAlso Not FinancialDataReadOnly Then _
                _Consignments.Update(_ID)

            If Not TransactionExisted Then DatabaseAccess.TransactionCommit()

            If IsNew Then _InsertDate = obj.InsertDate
            _UpdateDate = obj.UpdateDate
            _OldDate = _Date

            MarkOld()

        End Sub

        Private Function GetPersistenceObj() As OperationPersistenceObject

            Dim obj As OperationPersistenceObject
            If IsNew Then
                obj = OperationPersistenceObject.NewOperationPersistenceObject
            Else
                obj = OperationPersistenceObject.GetOperationPersistenceObject(_ID, False)
            End If

            obj.OperationType = GoodsOperationType.ConsignmentDiscount
            obj.GoodsID = _GoodsInfo.ID
            obj.JournalEntryID = _JournalEntryID
            obj.OperationDate = _Date
            obj.Content = _Description
            obj.DocNo = _DocumentNumber
            obj.WarehouseID = _Warehouse.ID
            obj.Warehouse = _Warehouse
            obj.TotalValue = -_TotalValueChange
            obj.Amount = 0
            obj.AmountInWarehouse = 0
            obj.UnitValue = 0
            obj.AmountInPurchases = 0

            If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic Then
                If _AccountPurchasesIsClosed Then
                    obj.AccountGeneral = -_TotalGoodsValueChange
                    obj.AccountSalesNetCosts = -_TotalNetValueChange
                Else
                    obj.AccountDiscounts = _TotalValueChange
                End If
            Else
                obj.AccountGeneral = -_TotalGoodsValueChange
                obj.AccountOperation = _AccountGoodsNetCosts
                obj.AccountOperationValue = _TotalNetValueChange
                If obj.AccountOperation = _GoodsInfo.AccountSalesNetCosts Then _
                    obj.AccountSalesNetCosts = _TotalNetValueChange
            End If

            Return obj

        End Function


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)

            Dim OperationToDelete As GoodsOperationDiscount = New GoodsOperationDiscount
            OperationToDelete.DataPortal_Fetch(DirectCast(criteria, Criteria))

            If OperationToDelete.JournalEntryType = DocumentType.InvoiceMade Then _
                Throw New Exception("Klaida. Ši operacija yra sudedamoji dalis išrašytos " _
                & "sąskaitos faktūros. Ją pašalinti galima tik kartu su sąskaita faktūra.")

            If OperationToDelete.JournalEntryType = DocumentType.InvoiceReceived Then _
                Throw New Exception("Klaida. Ši operacija yra sudedamoji dalis gautos " _
                & "sąskaitos faktūros. Ją pašalinti galima tik kartu su sąskaita faktūra.")

            If Not OperationToDelete._OperationLimitations.FinancialDataCanChange Then _
                Throw New Exception("Klaida. " & OperationToDelete._OperationLimitations. _
                FinancialDataCanChangeExplanation)

            OperationToDelete.DoDelete()

        End Sub

        Private Sub DoDelete()

            Dim TransactionExisted As Boolean = DatabaseAccess.TransactionExists
            If Not TransactionExisted Then DatabaseAccess.TransactionBegin()

            OperationPersistenceObject.DeleteConsignments(_ID)

            OperationPersistenceObject.DeleteConsignmentDiscards(_ID)

            OperationPersistenceObject.Delete(_ID)

            If Not TransactionExisted Then DatabaseAccess.TransactionCommit()

            MarkNew()

        End Sub


        Friend Sub CheckIfCanDelete()

            If IsNew Then Exit Sub

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                _ID, GoodsOperationType.ConsignmentDiscount, _GoodsInfo.ValuationMethod, _
                _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _Warehouse.ID, Nothing)

            If Not _OperationLimitations.FinancialDataCanChange Then _
                Throw New Exception("Prekių '" & _GoodsInfo.Name _
                    & "' nuolaidos operacijos pašalinti negalima: " & _
                    _OperationLimitations.FinancialDataCanChangeExplanation)

        End Sub

        Friend Sub CheckIfCanUpdate()

            If IsNew Then

                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                    _ID, GoodsOperationType.ConsignmentDiscount, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _Date, _Warehouse.ID, Nothing)

            Else

                _OperationLimitations = OperationalLimitList.GetOperationalLimitList(_GoodsInfo.ID, _
                    _ID, GoodsOperationType.ConsignmentDiscount, _GoodsInfo.ValuationMethod, _
                    _GoodsInfo.AccountingMethod, _GoodsInfo.Name, _OldDate, _Warehouse.ID, Nothing)

            End If

            ValidationRules.CheckRules()
            If Not IsValid Then Throw New Exception("Prekių '" & _GoodsInfo.Name _
                & "' nuolaidos operacijoje yra klaidų: " & BrokenRulesCollection.ToString)

        End Sub

        Friend Function GetTotalBookEntryList() As BookEntryInternalList

            Dim result As BookEntryInternalList = _
               BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            If _GoodsInfo.AccountingMethod = GoodsAccountingMethod.Periodic Then

                If _AccountPurchasesIsClosed Then

                    If CRound(_TotalGoodsValueChange) > 0 Then

                        Dim GeneralAccountBookEntry As BookEntryInternal = _
                            BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
                        GeneralAccountBookEntry.Account = _Warehouse.WarehouseAccount
                        GeneralAccountBookEntry.Ammount = CRound(_TotalGoodsValueChange)

                        result.Add(GeneralAccountBookEntry)

                    End If

                    If CRound(_TotalNetValueChange) > 0 Then

                        Dim NetCostsAccountBookEntry As BookEntryInternal = _
                            BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
                        NetCostsAccountBookEntry.Account = _GoodsInfo.AccountSalesNetCosts
                        NetCostsAccountBookEntry.Ammount = CRound(_TotalNetValueChange)

                        result.Add(NetCostsAccountBookEntry)

                    End If

                Else

                    Dim DiscountsAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
                    DiscountsAccountBookEntry.Account = _GoodsInfo.AccountDiscounts
                    DiscountsAccountBookEntry.Ammount = CRound(_TotalValueChange)

                    result.Add(DiscountsAccountBookEntry)

                End If

            Else

                If CRound(_TotalGoodsValueChange) > 0 Then

                    Dim GeneralAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
                    GeneralAccountBookEntry.Account = _Warehouse.WarehouseAccount
                    GeneralAccountBookEntry.Ammount = CRound(_TotalGoodsValueChange)

                    result.Add(GeneralAccountBookEntry)

                End If

                If CRound(_TotalNetValueChange) > 0 Then

                    Dim NetCostsAccountBookEntry As BookEntryInternal = _
                        BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas)
                    NetCostsAccountBookEntry.Account = _AccountGoodsNetCosts
                    NetCostsAccountBookEntry.Ammount = CRound(_TotalNetValueChange)

                    result.Add(NetCostsAccountBookEntry)

                End If

            End If

            Return result

        End Function

#End Region

    End Class

End Namespace