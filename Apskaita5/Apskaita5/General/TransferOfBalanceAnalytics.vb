Namespace General

    <Serializable()> _
    Public Class TransferOfBalanceAnalytics
        Inherits BusinessBase(Of TransferOfBalanceAnalytics)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Friend Const ColumnCount As Integer = 4
        Public Const ColumnSequence As String = "Likučių perkėlimo analitikos duomenys " _
            & "privalo būti išdėstyti 4 stulpeliais: tipas (Debetas/Kreditas), sąskaita, " _
            & "suma ir asmens ar įmonės kodas."

        Private _ID As Guid = Guid.NewGuid
        Private _EntryType As BookEntryType = BookEntryType.Debetas
        Private _Account As Long = 0
        Private _Ammount As Double = 0
        Private _Person As PersonInfo = Nothing
        Private _FinancialDataCanChange As Boolean = True


        Public ReadOnly Property ID() As Guid
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        Public Property EntryType() As BookEntryType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _EntryType
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As BookEntryType)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _EntryType <> value Then
                    _EntryType = value
                    PropertyHasChanged()
                    PropertyHasChanged("EntryTypeHumanReadable")
                End If
            End Set
        End Property

        Public Property EntryTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ConvertEnumHumanReadable(_EntryType)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value Is Nothing Then value = ""
                If _EntryType <> ConvertEnumHumanReadable(Of BookEntryType)(value) Then
                    _EntryType = ConvertEnumHumanReadable(Of BookEntryType)(value)
                    PropertyHasChanged()
                    PropertyHasChanged("EntryType")
                End If
            End Set
        End Property

        Public Property Account() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Account
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _Account <> value Then
                    _Account = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Ammount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Ammount)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_Ammount) <> CRound(value) Then
                    _Ammount = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Person() As PersonInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Person
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As PersonInfo)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If Not (_Person Is Nothing AndAlso value Is Nothing) AndAlso Not _
                    (Not _Person Is Nothing AndAlso Not value Is Nothing AndAlso _Person = value) Then
                    _Person = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        
        Public Function GetErrorString() As String _
        Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & Me.ToString & "': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
        Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & Me.ToString & "' gali būti klaida: " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            If Not _Person Is Nothing Then Return EntryTypeHumanReadable & " " _
                & _Account.ToString & "=" & _Ammount.ToString("##,#.00") & " : " _
                & _Person.ToString
            Return EntryTypeHumanReadable & " " & _Account.ToString & "=" _
                & _Ammount.ToString("##,#.00") & " : kontrahentas nenurodytas"
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Account", "apskaitos sąskaita"))
            ValidationRules.AddRule(AddressOf CommonValidation.PositiveNumberRequired, _
                New CommonValidation.SimpleRuleArgs("Ammount", "suma"))
            ValidationRules.AddRule(AddressOf CommonValidation.InfoObjectRequired, _
                New CommonValidation.InfoObjectRequiredRuleArgs("Person", "kontrahentas", ""))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewTransferOfBalanceAnalytics() As TransferOfBalanceAnalytics
            Dim result As New TransferOfBalanceAnalytics
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function NewTransferOfBalanceAnalytics(ByVal pasteString As String, _
            ByVal personsInfo As PersonInfoList) As TransferOfBalanceAnalytics
            Return New TransferOfBalanceAnalytics(pasteString, personsInfo)
        End Function

        Friend Shared Function GetTransferOfBalanceAnalytics(ByVal BookEntryItem As BookEntryInternal, _
            ByVal nFinancialDataCanChange As Boolean) As TransferOfBalanceAnalytics
            Return New TransferOfBalanceAnalytics(BookEntryItem, nFinancialDataCanChange)
        End Function

        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal BookEntryItem As BookEntryInternal, ByVal nFinancialDataCanChange As Boolean)
            MarkAsChild()
            Fetch(BookEntryItem, nFinancialDataCanChange)
        End Sub

        Private Sub New(ByVal pasteString As String, ByVal personsInfo As PersonInfoList)
            MarkAsChild()
            Create(pasteString, personsInfo)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal pasteString As String, ByVal personsInfo As PersonInfoList)

            Try
                _EntryType = ConvertEnumHumanReadable(Of BookEntryType) _
                    (GetField(pasteString, vbTab, 0))
            Catch ex As Exception
                Try
                    _EntryType = ConvertEnumDatabaseStringCode(Of BookEntryType) _
                        (GetField(pasteString, vbTab, 0))
                Catch ex2 As Exception
                    Try
                        _EntryType = [Enum].Parse(GetType(BookEntryType), GetField(pasteString, vbTab, 0))
                    Catch ex3 As Exception
                    End Try
                End Try
            End Try

            Long.TryParse(GetField(pasteString, vbTab, 1), _Account)
            Double.TryParse(GetField(pasteString, vbTab, 2), _Ammount)

            If Not personsInfo Is Nothing Then
                Dim PersonCode As String = GetField(pasteString, vbTab, 3).Trim.ToLower
                If Not String.IsNullOrEmpty(PersonCode.Trim) Then _
                    _Person = personsInfo.GetPersonInfo(PersonCode)
            End If

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal BookEntryItem As BookEntryInternal, ByVal nFinancialDataCanChange As Boolean)

            _Ammount = BookEntryItem.Ammount
            _EntryType = BookEntryItem.EntryType
            _Account = BookEntryItem.Account
            _Person = BookEntryItem.Person
            _FinancialDataCanChange = nFinancialDataCanChange

            MarkOld()

        End Sub

#End Region

    End Class

End Namespace