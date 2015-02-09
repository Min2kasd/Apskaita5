Namespace Assets

    <Serializable()> _
Public Class LongTermAssetComplexDocument
        Inherits BusinessBase(Of LongTermAssetComplexDocument)

#Region " Business Methods "

        Private _ID As Integer = -1
        Private _ChronologicValidator As ComplexChronologicValidator
        Private _Type As LtaOperationType = LtaOperationType.Discard
        Private _Date As Date = Today
        Private _OldDate As Date = Today
        Private _Content As String = ""
        Private _AccountCorresponding As Integer = 0
        Private _ActNumber As Integer = 0
        Private _JournalEntryID As Integer = -1
        Private _JournalEntryType As DocumentType = DocumentType.None
        Private _JournalEntryContent As String = ""
        Private _JournalEntryDocNumber As String = ""
        Private _ChildList As LongTermAssetOperationChildList

        <NonSerialized()> _
        <NotUndoable()> _
        Private _ChildSortedList As SortedBindingList(Of LongTermAssetOperationChild) = Nothing


        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property ChronologicValidator() As ComplexChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ChronologicValidator
            End Get
        End Property

        Public Property [Type]() As LtaOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As LtaOperationType)
                CanWriteProperty(True)
                If _Type <> value Then
                    OnTypeChanged(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property TypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ConvertEnumHumanReadable(_Type)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If String.IsNullOrEmpty(value) Then value = ""
                If ConvertEnumHumanReadable(Of LtaOperationType)(value.Trim) <> _Type Then
                    Me.Type = ConvertEnumHumanReadable(Of LtaOperationType)(value.Trim)
                End If
            End Set
        End Property

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
                    _ChildList.UpdateDate(value.Date)
                End If
            End Set
        End Property

        Public ReadOnly Property OldDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OldDate
            End Get
        End Property

        Public Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If _Content.Trim <> value.Trim Then
                    _Content = value.Trim
                    PropertyHasChanged()
                    _ChildList.UpdateContent(value.Trim)
                End If
            End Set
        End Property

        Public Property AccountCorresponding() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountCorresponding
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _AccountCorresponding <> value Then
                    _AccountCorresponding = value
                    PropertyHasChanged()
                    _ChildList.UpdateAccountCorresponding(value)
                End If
            End Set
        End Property

        Public Property ActNumber() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ActNumber
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _ActNumber <> value Then
                    _ActNumber = value
                    PropertyHasChanged()
                    _ChildList.UpdateActNumber(value)
                End If
            End Set
        End Property

        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        Public ReadOnly Property JournalEntryType() As DocumentType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryType
            End Get
        End Property

        Public ReadOnly Property JournalEntryContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryContent.Trim
            End Get
        End Property

        Public ReadOnly Property JournalEntryDocNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryDocNumber.Trim
            End Get
        End Property

        Public ReadOnly Property ChildList() As Csla.SortedBindingList(Of LongTermAssetOperationChild)
            Get
                Return _ChildList.GetSortedList
            End Get
        End Property



        Public Sub SetAttachedJournalEntry(ByVal JournalEntryInfo As ActiveReports.JournalEntryInfo)
            SetAttachedJournalEntry(JournalEntryInfo.Id, JournalEntryInfo.Content, _
                JournalEntryInfo.DocType, JournalEntryInfo.DocNumber)
        End Sub

        Public Sub SetAttachedJournalEntry(ByVal nJournalEntryID As Integer, _
            ByVal nJournalEntryContent As String, ByVal nJournalEntryType As DocumentType, _
            ByVal nJournalEntryDocNumber As String)

            If _Type <> LtaOperationType.AcquisitionValueIncrease AndAlso _
                _Type <> LtaOperationType.Transfer AndAlso _Type <> LtaOperationType.ValueChange Then _
                Throw New Exception("Klaida. Susietas bendrojo žurnalo įrašas gali būti " _
                & "priskiriamas tik įsigijimo savikainos padidinimo, pervertinimo ir perleidimo operacijoms.")

            If Not nJournalEntryID > 0 Then
                _JournalEntryType = DocumentType.None
                _JournalEntryContent = ""
                _JournalEntryID = -1
                _JournalEntryDocNumber = ""
                PropertyHasChanged("JournalEntryID")
                PropertyHasChanged("JournalEntryContent")
                PropertyHasChanged("JournalEntryType")
                PropertyHasChanged("JournalEntryDocNumber")
                _ChildList.UpdateJournalEntry(nJournalEntryID, nJournalEntryContent, _
                    nJournalEntryType, nJournalEntryDocNumber)
                Exit Sub
            End If

            If _Type = LtaOperationType.Transfer AndAlso _
                (nJournalEntryType = DocumentType.InvoiceMade OrElse _
                nJournalEntryType = DocumentType.InvoiceReceived) Then _
                Throw New Exception("Turto perleidimo operacijas, pagrįstas sąskaitomis - faktūromis, " & _
                "galima tvarkyti tik išrašant arba keičiant sąskaitas - faktūras.")

            _JournalEntryType = nJournalEntryType
            _JournalEntryContent = nJournalEntryContent
            _JournalEntryID = nJournalEntryID
            _JournalEntryDocNumber = nJournalEntryDocNumber
            PropertyHasChanged("JournalEntryID")
            PropertyHasChanged("JournalEntryContent")
            PropertyHasChanged("JournalEntryType")
            PropertyHasChanged("JournalEntryDocNumber")

            _ChildList.UpdateJournalEntry(nJournalEntryID, nJournalEntryContent, _
                    nJournalEntryType, nJournalEntryDocNumber)

        End Sub

        Public Sub GetItemsIdsForAmortizationCalculationList( _
            ByRef nAssetID As Integer(), ByRef nOperationID As Integer())

            If _Type <> LtaOperationType.Amortization Then Throw New Exception( _
                "Klaida. Amortizaciją galima skaičiuoti tik amortizacijos skaičiavimo " _
                & "dokumente, o Jūs tą bandote daryti '" & TypeHumanReadable & "' dokumente.")

            Dim resultAssetID As New List(Of Integer)
            Dim resultOperationID As New List(Of Integer)

            For Each item As LongTermAssetOperationChild In _ChildList
                If item.IsChecked Then
                    resultAssetID.Add(item.AssetID)
                    resultOperationID.Add(item.ID)
                End If
            Next

            If resultAssetID.Count < 1 Then Throw New Exception( _
                "Klaida. Dokumente nepasirinkta jokio turto.")

            nAssetID = resultAssetID.ToArray
            nOperationID = resultOperationID.ToArray

        End Sub

        Public Sub SetAmortizationCalculation(ByVal AmortizationCalculationList _
            As LongTermAssetAmortizationCalculationList)

            For Each item As LongTermAssetOperationChild In _ChildList
                For Each calculationItem As LongTermAssetAmortizationCalculation _
                    In AmortizationCalculationList

                    If item.IsChecked AndAlso item.AssetID = calculationItem.AssetID Then
                        item.SetAmortizationCalculation(calculationItem)
                        Exit For
                    End If

                Next
            Next

        End Sub

        ''' <summary>
        ''' Calculates amortization for an amortization operation and updates properties.
        ''' </summary>
        ''' <remarks>Uses LongTermAssetAmortizationCalculationList.GetLongTermAssetAmortizationCalculationList
        ''' call synchronously which can be a lengthy operation. For asynchronous call use 
        ''' SetAmortizationCalculation instead. </remarks>
        Public Sub CalculateAmortization()

            If _Type <> LtaOperationType.Amortization Then Throw New Exception( _
                "Klaida. Amortizaciją leidžiama skaičiuoti, tik jei operacijos tipas yra amortizacija.")

            Dim AmortizationCalculationList As LongTermAssetAmortizationCalculationList
            Dim nAssetID As Integer() = Nothing
            Dim nOperationID As Integer() = Nothing

            GetItemsIdsForAmortizationCalculationList(nAssetID, nOperationID)

            AmortizationCalculationList = LongTermAssetAmortizationCalculationList. _
                GetList(nAssetID, nOperationID, _Date)

            SetAmortizationCalculation(AmortizationCalculationList)

        End Sub


        Public Function GetAllBrokenRules() As String
            Dim result As String = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error).Trim
            result = AddWithNewLine(result, _ChildList.GetAllBrokenRules, False)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning).Trim
            result = AddWithNewLine(result, _ChildList.GetAllWarnings(), False)


            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function


        Public Function GetSortedList() As SortedBindingList(Of LongTermAssetOperationChild)

            If _ChildSortedList Is Nothing Then
                _ChildSortedList = New SortedBindingList(Of LongTermAssetOperationChild)(_ChildList)
            End If

            Return _ChildSortedList

        End Function

        Private Sub OnTypeChanged(ByVal value As LtaOperationType)

            If Not IsNew Then Throw New Exception("Klaida. Įtrauktos į duomenų bazę " & _
                "operacijos tipas negali būti keičiamas.")

            If value = LtaOperationType.AccountChange _
                OrElse value = LtaOperationType.AcquisitionValueIncrease _
                OrElse value = LtaOperationType.AmortizationPeriod _
                OrElse value = LtaOperationType.Transfer Then Throw _
                New NotSupportedException("Klaida. Operacijos tipas '" & _
                ConvertEnumHumanReadable(value) & "' kompleksiniame dokumente nepalaikomas.")

            _Type = value
            _AccountCorresponding = 0
            _ActNumber = 0
            _JournalEntryID = -1
            _JournalEntryType = DocumentType.None
            _JournalEntryContent = ""
            _JournalEntryDocNumber = ""

            PropertyHasChanged("JournalEntryContent")
            PropertyHasChanged("JournalEntryID")
            PropertyHasChanged("JournalEntryDocNumber")
            PropertyHasChanged("TypeHumanReadable")
            PropertyHasChanged("AccountCorresponding")
            PropertyHasChanged("ActNumber")

            _ChildList.UpdateType(value)

            _ChronologicValidator.ReloadValidationItems(_ChildList.GetChronologyValidators)

        End Sub


        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _ChildList.IsValid
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _ChildList.IsDirty
            End Get
        End Property

        Public Overrides Function Save() As LongTermAssetComplexDocument

            If _Type = LtaOperationType.Transfer AndAlso (_JournalEntryType = DocumentType.InvoiceMade _
                OrElse _JournalEntryType = DocumentType.InvoiceReceived) Then Throw New Exception( _
                "Turto perleidimo operacijas, pagrįstas sąskaitomis - faktūromis, " & _
                "galima tvarkyti tik išrašant arba keičiant sąskaitas - faktūras.")

            If Not _ChildList.IsAnyItemChecked Then Throw New Exception( _
                "Klaida. Dokumente nepasirinkta jokio turto.")

            ValidationRules.CheckRules()
            _ChildList.ForceCheckRules()
            If Not Me.IsValid Then Throw New Exception( _
                "Duomenyse yra klaidų: " & vbCrLf & Me.BrokenRulesCollection.ToString)

            Return MyBase.Save()
        End Function

        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.SimpleRuleArgs("Content", _
                "operacijos pagrindas (aprašas)"))
            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "ChronologicValidator"))

            ValidationRules.AddRule(AddressOf AccountCorrespondingValidation, "AccountCorresponding")
            ValidationRules.AddRule(AddressOf ActNumberValidation, "ActNumber")
            ValidationRules.AddRule(AddressOf JournalEntryIdValidation, "JournalEntryID")

        End Sub

        ''' <summary>
        ''' Rule ensuring that the corresponding account is provided when necessary.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountCorrespondingValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As LongTermAssetComplexDocument = DirectCast(target, LongTermAssetComplexDocument)

            If ValObj._Type = LtaOperationType.AccountChange OrElse _
                ValObj._Type = LtaOperationType.Amortization OrElse _
                ValObj._Type = LtaOperationType.Discard Then

                If Not ValObj._AccountCorresponding > 0 Then

                    If ValObj.Type = LtaOperationType.AccountChange Then
                        e.Description = "Nepasirinkta nauja sąskaita."
                    Else
                        e.Description = "Nepasirinkta koresponduojanti sąnaudų sąskaita."
                    End If

                    e.Severity = Csla.Validation.RuleSeverity.Error
                    Return False

                End If

            End If

            Return True
        End Function

        ''' <summary>
        ''' Rule ensuring that the act number is provided when necessary.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function ActNumberValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As LongTermAssetComplexDocument = DirectCast(target, LongTermAssetComplexDocument)

            If (ValObj._Type = LtaOperationType.Discard OrElse ValObj._Type = LtaOperationType.UsingEnd OrElse _
                ValObj._Type = LtaOperationType.UsingStart) AndAlso Not ValObj._ActNumber > 0 Then

                e.Description = "Nenurodytas akto numeris."
                e.Severity = Csla.Validation.RuleSeverity.Error
                Return False

            End If

            Return True
        End Function

        ''' <summary>
        ''' Rule ensuring that the related general ledger entry is provided when necessary.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function JournalEntryIdValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As LongTermAssetComplexDocument = DirectCast(target, LongTermAssetComplexDocument)

            If ValObj._Type = LtaOperationType.ValueChange OrElse _
                ValObj._Type = LtaOperationType.AcquisitionValueIncrease OrElse _
                ValObj._Type = LtaOperationType.Transfer Then

                If Not ValObj._JournalEntryID > 0 Then
                    e.Description = "Nenurodyta pagrindžianti bendrojo žurnalo operacija (dokumentas)."
                    e.Severity = Csla.Validation.RuleSeverity.Error
                    Return False
                End If

                If ValObj._Type = LtaOperationType.Transfer AndAlso _
                (ValObj._JournalEntryType = DocumentType.InvoiceMade OrElse _
                ValObj._JournalEntryType = DocumentType.InvoiceReceived) Then

                    e.Description = "Turto perleidimo operacijas, pagrįstas sąskaitomis - faktūromis, " & _
                        "galima tvarkyti tik išrašant arba keičiant sąskaitas - faktūras."
                    e.Severity = Csla.Validation.RuleSeverity.Error
                    Return False

                End If

            End If

            Return True
        End Function


#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Assets.LongTermAssetOperation2")
        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Assets.LongTermAssetOperation2")
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Assets.LongTermAssetOperation1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Assets.LongTermAssetOperation3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Assets.LongTermAssetOperation3")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function NewLongTermAssetComplexDocument( _
            ByVal nCustomAssetGroup As LongTermAssetCustomGroupInfo) As LongTermAssetComplexDocument
            Return DataPortal.Create(Of LongTermAssetComplexDocument)( _
                New Criteria(-1, nCustomAssetGroup))
        End Function

        Public Shared Function GetLongTermAssetComplexDocument(ByVal id As Integer) _
            As LongTermAssetComplexDocument
            Return DataPortal.Fetch(Of LongTermAssetComplexDocument)(New Criteria(id, Nothing))
        End Function

        Public Shared Sub DeleteLongTermAssetComplexDocument(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id, Nothing))
        End Sub

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Private _CustomAssetGroup As LongTermAssetCustomGroupInfo
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public ReadOnly Property CustomAssetGroup() As LongTermAssetCustomGroupInfo
                <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
                Get
                    Return _CustomAssetGroup
                End Get
            End Property
            Public ReadOnly Property IsFetchOperation() As Boolean
                Get
                    Return (_ID > 0)
                End Get
            End Property
            Public Sub New(ByVal nID As Integer, ByVal nCustomAssetGroup As LongTermAssetCustomGroupInfo)
                _CustomAssetGroup = nCustomAssetGroup
                _ID = nID
            End Sub
        End Class

        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Jūsų teisių nepakanka naujų IT operacijų įtraukimui.")

            Dim myComm As New SQLCommand("CreateLongTermAssetComplexDocumentBackground")
            If criteria.CustomAssetGroup Is Nothing Then
                myComm.AddParam("?GR", 0)
            Else
                myComm.AddParam("?GR", criteria.CustomAssetGroup.ID)
            End If

            Dim baseValidator As SimpleChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator("kompleksinė operacija su ilgalaikiu turtu")

            Using myData As DataTable = myComm.Fetch
                Using ChronologyDataSource As DataTable = OperationChronologicValidator. _
                    GetDataSourceForNewComplexDocument
                    _ChildList = LongTermAssetOperationChildList.NewLongTermAssetOperationChildList( _
                        myData, ChronologyDataSource, baseValidator)
                End Using
            End Using

            _ChronologicValidator = ComplexChronologicValidator.NewComplexChronologicValidator( _
                ConvertEnumHumanReadable(_Type), baseValidator, _ChildList.GetChronologyValidators)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Jūsų teisių nepakanka šiai informacijai gauti.")

            Dim myComm As New SQLCommand("FetchLongTermAssetOperationChildListParent")
            myComm.AddParam("?OD", criteria.ID)

            Dim parentValidator As IChronologicValidator

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception( _
                    "Klaida. Nerasti kompleksinio turto dokumento duomenys pagal ID=" _
                    & criteria.ID.ToString & ".")

                parentValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                    criteria.ID, CDateSafe(myData.Rows(0).Item(3), Today), _
                    ConvertEnumHumanReadable(ConvertEnumDatabaseStringCode(Of LtaOperationType) _
                    (CStrSafe(myData.Rows(0).Item(1)))))

                myComm = New SQLCommand("FetchLongTermAssetComplexDocumentBackground")
                myComm.AddParam("?OD", criteria.ID)
                myComm.AddParam("?DT", CDateSafe(myData.Rows(0).Item(3), Today))

                Using BackgroundData As DataTable = myComm.Fetch

                    Using ChronologyDataSource As DataTable = OperationChronologicValidator. _
                        GetDataSourceForOldComplexDocument(criteria.ID, CDateSafe(myData.Rows(0).Item(3), Today))
                        _ChildList = LongTermAssetOperationChildList.GetLongTermAssetOperationChildList( _
                            myData, BackgroundData, ChronologyDataSource, parentValidator)
                    End Using

                End Using

            End Using

            _ID = criteria.ID
            _Type = _ChildList(0).Type
            _Date = _ChildList(0).Date
            _OldDate = _ChildList(0).Date
            _Content = _ChildList(0).Content
            _AccountCorresponding = _ChildList(0).AccountCorresponding
            _ActNumber = _ChildList(0).ActNumber
            _JournalEntryID = _ChildList(0).JournalEntryID
            _JournalEntryType = _ChildList(0).JournalEntryType
            _JournalEntryContent = _ChildList(0).JournalEntryContent
            _JournalEntryDocNumber = _ChildList(0).JournalEntryDocNumber

            _ChronologicValidator = ComplexChronologicValidator.GetComplexChronologicValidator( _
                _ID, _Date, ConvertEnumHumanReadable(_Type), parentValidator, _ChildList.GetChronologyValidators)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub



        Protected Overrides Sub DataPortal_Insert()
            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Jūsų teisių nepakanka IT operacijų duomenų įvedimui.")
            DoSave()
        End Sub

        Protected Overrides Sub DataPortal_Update()
            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Jūsų teisių nepakanka IT operacijų duomenų keitimui.")
            DoSave()
        End Sub

        Private Sub DoSave()

            CheckAllRules()

            SetOperationID()

            Dim JE As General.JournalEntry = GetJournalEntryForDocument()

            TransactionBegin()

            If Not JE Is Nothing Then
                JE = JE.SaveServerSide()
                _JournalEntryID = JE.ID
                _JournalEntryType = JE.DocType
                _JournalEntryContent = JE.Content
                _JournalEntryDocNumber = JE.DocNumber
                _ChildList.UpdateJournalEntry(_JournalEntryID, _JournalEntryContent, _
                    _JournalEntryType, _JournalEntryDocNumber)
            End If

            _ChildList.Update(Me)

            TransactionCommit()

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Private Function GetJournalEntryForDocument() As General.JournalEntry

            If _Type <> LtaOperationType.Amortization AndAlso _
                _Type <> LtaOperationType.Discard Then Return Nothing

            Dim result As General.JournalEntry = Nothing

            If IsNew Then
                If _Date.Date <= GetCurrentCompany.LastClosingDate.Date Then Throw New Exception( _
                    "Klaida. Neleidžiama koreguoti operacijų po uždarymo (" _
                    & GetCurrentCompany.LastClosingDate & ").")
                If _Type = LtaOperationType.Amortization Then
                    result = General.JournalEntry.NewJournalEntryChild(DocumentType.Amortization)
                ElseIf _Type = LtaOperationType.Discard Then
                    result = General.JournalEntry.NewJournalEntryChild(DocumentType.LongTermAssetDiscard)
                End If
            Else
                If _OldDate.Date <= GetCurrentCompany.LastClosingDate.Date OrElse _
                    _Date.Date <= GetCurrentCompany.LastClosingDate.Date Then Throw New Exception( _
                    "Klaida. Neleidžiama koreguoti operacijų po uždarymo (" _
                & GetCurrentCompany.LastClosingDate & ").")
                If _Type = LtaOperationType.Amortization Then
                    result = General.JournalEntry.GetJournalEntryChild(_JournalEntryID, _
                        DocumentType.Amortization)
                ElseIf _Type = LtaOperationType.Discard Then
                    result = General.JournalEntry.GetJournalEntryChild(_JournalEntryID, _
                        DocumentType.LongTermAssetDiscard)
                End If
            End If

            result.Date = _Date.Date
            result.Person = Nothing
            If _Type = LtaOperationType.Amortization Then
                result.Content = _Content & " (IT amortizacijos priskaičiavimas)"
                result.DocNumber = "nėra"
            ElseIf _Type = LtaOperationType.Discard Then
                result.Content = _Content & "(IT nurašymas kompleksiniu dokumentu)"
                result.DocNumber = _ActNumber.ToString
            End If

            Dim CommonBookEntryList As BookEntryInternalList = _
                BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            Dim AmortizationCosts As Double = 0
            Dim DiscardCosts As Double = 0
            For Each item As LongTermAssetOperationChild In _ChildList
                If item.IsChecked Then
                    If _Type = LtaOperationType.Amortization Then
                        For Each b As BookEntryInternal In item.GetBookEntryListForAmortization
                            CommonBookEntryList.Add(b.Clone)
                        Next
                        AmortizationCosts = CRound(AmortizationCosts - item.TotalValueChange)
                    ElseIf _Type = LtaOperationType.Discard Then
                        For Each b As BookEntryInternal In item.GetBookEntryListForDiscard
                            CommonBookEntryList.Add(b.Clone)
                        Next
                        DiscardCosts = CRound(DiscardCosts - item.TotalValueChange)
                    End If
                End If
            Next

            CommonBookEntryList.Aggregate()

            result.CreditList.LoadBookEntryListFromInternalList(CommonBookEntryList, False)
            result.DebetList.LoadBookEntryListFromInternalList(CommonBookEntryList, False)

            If _Type = LtaOperationType.Amortization Then
                Dim DebetBookEntry As General.BookEntry = General.BookEntry.NewBookEntry()
                DebetBookEntry.Account = _AccountCorresponding
                DebetBookEntry.Amount = CRound(AmortizationCosts)
                result.DebetList.Add(DebetBookEntry)

            ElseIf _Type = LtaOperationType.Discard Then
                Dim DebetBookEntry As General.BookEntry = General.BookEntry.NewBookEntry()
                DebetBookEntry.Account = _AccountCorresponding
                DebetBookEntry.Amount = CRound(DiscardCosts)
                result.DebetList.Add(DebetBookEntry)
            End If

            If Not result.IsValid Then Throw New Exception( _
                "Klaida. Nepavyko suformuoti bendrojo žurnalo įrašo dokumentui: " _
                & result.GetAllBrokenRules)

            Return result

        End Function


        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                "Jūsų teisių nepakanka IT operacijų duomenų pašalinimui.")

            Dim nOperationType As LtaOperationType
            Dim nJournalEntryID As Integer

            Dim myComm As New SQLCommand("FetchLongTermAssetOperationChildListParentChildrenID")
            myComm.AddParam("?OD", criteria.ID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception( _
                    "Klaida. Nerasti kompleksinio turto dokumento duomenys pagal ID=" _
                    & criteria.ID.ToString & ".")

                For Each dr As DataRow In myData.Rows
                    LongTermAssetOperation.CheckIfCanDelete(CIntSafe(dr.Item(0), 0), True, _
                        False, False, nOperationType, nJournalEntryID)
                Next

                If nOperationType = LtaOperationType.AccountChange Then
                    IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted( _
                        nJournalEntryID, DocumentType.LongTermAssetAccountChange)
                ElseIf nOperationType = LtaOperationType.Amortization Then
                    IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted( _
                        nJournalEntryID, DocumentType.Amortization)
                ElseIf nOperationType = LtaOperationType.Discard Then
                    IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted( _
                        nJournalEntryID, DocumentType.LongTermAssetDiscard)
                End If

                DatabaseAccess.TransactionBegin()

                If nOperationType = LtaOperationType.AccountChange OrElse _
                    nOperationType = LtaOperationType.Amortization OrElse _
                    nOperationType = LtaOperationType.Discard Then _
                    General.JournalEntry.DoDelete(nJournalEntryID)

                For Each dr As DataRow In myData.Rows
                    LongTermAssetOperation.DeleteLongTermAssetOperationChild(CIntSafe(dr.Item(0), 0))
                Next

                DatabaseAccess.TransactionCommit()

            End Using

        End Sub


        Private Sub SetOperationID()

            If Not IsNew Then Exit Sub

            Dim myComm As New SQLCommand("FetchLongTermAssetOperationChildListParentLastNumber")
            Using myData As DataTable = myComm.Fetch
                Try
                    _ID = CInt(myData.Rows(0).Item(0)) + 1
                Catch ex As Exception
                    _ID = 1
                End Try
            End Using

        End Sub

        Private Sub CheckAllRules()

            If IsNew Then
                Using ChronologyDataSource As DataTable = OperationChronologicValidator. _
                    GetDataSourceForNewComplexDocument
                    _ChildList.CheckAllRules(Me, ChronologyDataSource)
                End Using
            Else
                Using ChronologyDataSource As DataTable = OperationChronologicValidator. _
                    GetDataSourceForOldComplexDocument(_ID, _OldDate)
                    _ChildList.CheckAllRules(Me, ChronologyDataSource)
                End Using
            End If

        End Sub

#End Region

    End Class

End Namespace