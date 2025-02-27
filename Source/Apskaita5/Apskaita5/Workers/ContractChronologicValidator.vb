﻿Namespace Workers

    <Serializable()> _
    Public NotInheritable Class ContractChronologicValidator
        Inherits ReadOnlyBase(Of SimpleChronologicValidator)
        Implements IChronologicValidator

#Region " Business Methods "

        Private Const DatePlaceHolder As String = "<#DATE#>"

        Private _CurrentOperationID As Integer = 0
        Private _CurrentOperationDate As Date = Today
        Private _CurrentOperationName As String = "darbo sutartis"
        Private _FinancialDataCanChange As Boolean = True
        Private _MinDateApplicable As Boolean = False
        Private _MaxDateApplicable As Boolean = False
        Private _MinDate As Date = Date.MinValue
        Private _MaxDate As Date = Date.MaxValue
        Private _FinancialDataCanChangeExplanation As String = ""
        Private _MinDateExplanation As String = ""
        Private _MaxDateExplanation As String = ""
        Private _LimitsExplanation As String = ""
        Private _BackgroundExplanation As String = ""
        Private _TerminationCanBeCanceled As Boolean = True
        Private _TerminationCanBeCanceledExplanation As String = ""
        Private _ContractDate As Date = Date.MinValue
        Private _ContractTerminationDate As Date = Date.MaxValue


        Public ReadOnly Property CurrentOperationID() As Integer _
            Implements IChronologicValidator.CurrentOperationID
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationID
            End Get
        End Property

        Public ReadOnly Property CurrentOperationDate() As Date _
            Implements IChronologicValidator.CurrentOperationDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationDate
            End Get
        End Property

        Public ReadOnly Property CurrentOperationName() As String _
            Implements IChronologicValidator.CurrentOperationName
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationName.Trim
            End Get
        End Property

        Public ReadOnly Property FinancialDataCanChange() As Boolean _
            Implements IChronologicValidator.FinancialDataCanChange
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property MinDateApplicable() As Boolean _
            Implements IChronologicValidator.MinDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateApplicable
            End Get
        End Property

        Public ReadOnly Property MaxDateApplicable() As Boolean _
            Implements IChronologicValidator.MaxDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateApplicable
            End Get
        End Property

        Public ReadOnly Property MinDate() As Date _
            Implements IChronologicValidator.MinDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDate
            End Get
        End Property

        Public ReadOnly Property MaxDate() As Date _
            Implements IChronologicValidator.MaxDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDate
            End Get
        End Property

        Public ReadOnly Property FinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.FinancialDataCanChangeExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChangeExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property MinDateExplanation() As String _
            Implements IChronologicValidator.MinDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property MaxDateExplanation() As String _
            Implements IChronologicValidator.MaxDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property LimitsExplanation() As String _
            Implements IChronologicValidator.LimitsExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LimitsExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property BackgroundExplanation() As String _
            Implements IChronologicValidator.BackgroundExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BackgroundExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property TerminationCanBeCanceled() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TerminationCanBeCanceled
            End Get
        End Property

        Public ReadOnly Property TerminationCanBeCanceledExplanation() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TerminationCanBeCanceledExplanation.Trim
            End Get
        End Property

        Public ReadOnly Property ContractDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractDate
            End Get
        End Property

        Public ReadOnly Property ContractTerminationDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractTerminationDate
            End Get
        End Property

        Public ReadOnly Property ParentFinancialDataCanChange() As Boolean _
        Implements IChronologicValidator.ParentFinancialDataCanChange
            Get
                Return True
            End Get
        End Property

        Public ReadOnly Property ParentFinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.ParentFinancialDataCanChangeExplanation
            Get
                Return ""
            End Get
        End Property


        Public Function ValidateOperationDate(ByVal operationDate As Date, ByRef errorMessage As String, _
            ByRef errorSeverity As Csla.Validation.RuleSeverity) As Boolean _
            Implements IChronologicValidator.ValidateOperationDate

            If _MinDateApplicable AndAlso operationDate.Date < _MinDate.Date Then
                errorMessage = _MinDateExplanation
                errorSeverity = Validation.RuleSeverity.Error
                Return False
            ElseIf _MaxDateApplicable AndAlso operationDate.Date > _MaxDate.Date Then
                errorMessage = _MaxDateExplanation
                errorSeverity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _CurrentOperationID
        End Function

        Public Overrides Function ToString() As String
            Return _CurrentOperationName
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewContractChronologicValidator() As ContractChronologicValidator
            Return New ContractChronologicValidator()
        End Function

        Friend Shared Function NewContractChronologicValidator(ByVal ContractSerial As String, _
            ByVal ContractNumber As Integer) As ContractChronologicValidator
            Return New ContractChronologicValidator(ContractSerial, ContractNumber)
        End Function

        Friend Shared Function GetContractChronologicValidator(ByVal nID As Integer) As ContractChronologicValidator
            Return New ContractChronologicValidator(nID)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal ContractSerial As String, ByVal ContractNumber As Integer)
            Create(ContractSerial, ContractNumber)
        End Sub

        Private Sub New(ByVal nID As Integer)
            Fetch(nID)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal ContractSerial As String, ByVal ContractNumber As Integer)

            Dim myComm As New SQLCommand("CreateContractChronologicValidator")
            myComm.AddParam("?DS", ContractSerial.Trim)
            myComm.AddParam("?DN", ContractNumber)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception("Darbo sutartis, kurios ID=" _
                    & ContractSerial & ContractNumber.ToString & ", nerasta.")

                Dim dr As DataRow = myData.Rows(0)

                _CurrentOperationName = "darbo sutarties pakeitimas"
                _ContractDate = CDateSafe(dr.Item(0), Date.MinValue)
                _ContractTerminationDate = CDateSafe(dr.Item(4), Date.MaxValue)

                If _ContractDate = Date.MinValue Then Throw New Exception( _
                    "Nepavyko gauti darbo sutarties datos. (ID=" & ContractSerial _
                    & ContractNumber.ToString & ")")

                SetMinDateApplicable(_ContractDate, "Minimali leidžiama data yra darbo sutarties " _
                    & "sudarymo data - " & DatePlaceHolder & ".")
                SetMaxDateApplicable(_ContractTerminationDate, "Maksimali leidžiama data yra darbo sutarties " _
                    & "nutraukimo data - " & DatePlaceHolder & ".")

                SetMinDateApplicable(CDateSafe(dr.Item(2), Date.MinValue), _
                    "Minimali leidžiama data yra " & DatePlaceHolder _
                    & ", nes ankstesne data yra registruotas darbo užmokesčio žiniaraštis.")

                SetMinDateApplicable(CDateSafe(dr.Item(3), Date.MinValue), _
                    "Minimali leidžiama data yra " & DatePlaceHolder _
                    & ", nes ankstesne data yra registruotas darbo sutarties pakeitimas.")

            End Using

            SetLimitsExplanation()

        End Sub

        Private Sub Fetch(ByVal nID As Integer)

            _CurrentOperationID = nID

            Dim myComm As New SQLCommand("FetchContractChronologicValidator")
            myComm.AddParam("?CD", nID)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception("Darbo sutartis ar jos pakeitimas, kurios ID=" _
                    & nID.ToString & ", nerasta.")

                Dim dr As DataRow = myData.Rows(0)

                _CurrentOperationDate = CDateSafe(dr.Item(0), Date.MinValue)

                If _CurrentOperationDate = Date.MinValue Then Throw New Exception( _
                    "Nepavyko gauti darbo sutarties ar jos pakeitimo datos. (ID=" & nID.ToString & ")")

                _ContractDate = CDateSafe(dr.Item(9), Date.MinValue)
                _ContractTerminationDate = CDateSafe(dr.Item(10), Date.MaxValue)

                If Utilities.ConvertDatabaseCharID(Of WorkerStatusType)(CStrSafe(dr.Item(1))) _
                    = WorkerStatusType.Employed Then
                    _CurrentOperationName = "darbo sutartis"
                Else
                    _CurrentOperationName = "darbo sutarties pakeitimas"
                    SetMinDateApplicable(_ContractDate, "Minimali leidžiama data yra darbo sutarties " _
                        & "sudarymo data - " & DatePlaceHolder & ".")
                    SetMaxDateApplicable(_ContractTerminationDate, "Maksimali leidžiama data yra darbo sutarties " _
                        & "nutraukimo data - " & DatePlaceHolder & ".")
                End If

                SetMaxDateApplicable(CDateSafe(dr.Item(2), Date.MinValue), "Maksimali leidžiama " _
                    & "data yra " & DatePlaceHolder & ", nes vėlesne data yra " _
                    & "registruotas avanso žiniaraštis.")

                SetMaxDateApplicable(CDateSafe(dr.Item(3), Date.MinValue), "Maksimali leidžiama " _
                    & "data yra " & DatePlaceHolder & ", nes vėlesne data yra " _
                    & "registruotas darbo užmokesčio žiniaraštis.")

                SetMaxDateApplicable(CDateSafe(dr.Item(4), Date.MinValue), "Maksimali leidžiama " _
                    & "data yra " & DatePlaceHolder & ", nes vėlesne data yra " _
                    & "registruotas darbo sutarties pakeitimas.")

                SetMaxDateApplicable(CDateSafe(dr.Item(5), Date.MinValue), "Maksimali leidžiama " _
                    & "data yra " & DatePlaceHolder & ", nes vėlesne data yra " _
                    & "registruotas darbo laiko apskaitos žiniaraštis.")

                If CDateSafe(dr.Item(3), Date.MinValue) <> Date.MinValue Then
                    _FinancialDataCanChange = False
                    _FinancialDataCanChangeExplanation = "Finansiniai parametrai " _
                        & "negali būti keičiami, nes darbuotojui buvo skaičiuotas darbo užmokestis. " _
                        & "Pirmas darbo užmokesčio žiniaraštis - " & CDateSafe(dr.Item(2), _
                        Date.MinValue).ToString("yyyy-MM-dd") & "."
                End If

                SetMinDateApplicable(CDateSafe(dr.Item(6), Date.MinValue), _
                    "Minimali leidžiama data yra " & DatePlaceHolder _
                    & ", nes ankstesne data yra registruotas darbo užmokesčio žiniaraštis.")

                SetMinDateApplicable(CDateSafe(dr.Item(7), Date.MinValue), _
                    "Minimali leidžiama data yra " & DatePlaceHolder _
                    & ", nes ankstesne data yra registruotas darbo sutarties pakeitimas.")

                If CDateSafe(dr.Item(8), Date.MinValue) <> Date.MinValue Then
                    _TerminationCanBeCanceled = False
                    _TerminationCanBeCanceledExplanation = "Darbo sutarties nutraukimas negali " _
                        & "būti panaikintas, nes " & CDateSafe(dr.Item(8), Date.MinValue).ToString("yyyy-MM-dd") _
                        & " darbo užmokesčio žiniaraštyje yra paskaičiuota atostogų kompensacija."
                End If

            End Using

            SetLimitsExplanation()

        End Sub

        Private Sub SetMaxDateApplicable(ByVal nDate As Date, ByVal nExplanation As String)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue Then Exit Sub

            If Not nDate.Date < _MaxDate.Date Then Exit Sub

            _MaxDateApplicable = True
            _MaxDate = nDate.Date.AddDays(-1)
            _MaxDateExplanation = nExplanation.Replace(DatePlaceHolder, nDate.ToString("yyyy-MM-dd"))

        End Sub

        Private Sub SetMinDateApplicable(ByVal nDate As Date, ByVal nExplanation As String)

            If nDate = Date.MaxValue OrElse nDate = Date.MinValue Then Exit Sub

            If Not nDate.Date > _MinDate.Date Then Exit Sub

            _MinDateApplicable = True
            _MinDate = nDate.Date.AddDays(1)
            _MinDateExplanation = nExplanation.Replace(DatePlaceHolder, nDate.ToString("yyyy-MM-dd"))

        End Sub

        Private Sub SetLimitsExplanation()

            _LimitsExplanation = ""
            If Not _FinancialDataCanChange Then _LimitsExplanation = _FinancialDataCanChangeExplanation
            If Not _TerminationCanBeCanceled Then _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _
                _TerminationCanBeCanceledExplanation, False)
            If _MinDateApplicable Then _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _
                _MinDateExplanation, False)
            If _MaxDateApplicable Then _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _
                 _MaxDateExplanation, False)

        End Sub

#End Region

    End Class

End Namespace