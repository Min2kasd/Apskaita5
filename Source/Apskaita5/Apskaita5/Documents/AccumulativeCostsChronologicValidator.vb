﻿Namespace Documents

    <Serializable()> _
    Public NotInheritable Class AccumulativeCostsChronologicValidator
        Inherits ReadOnlyBase(Of SimpleChronologicValidator)
        Implements IChronologicValidator

#Region " Business Methods "

        Private _CurrentOperationID As Integer = 0
        Private _CurrentOperationDate As Date = Today
        Private _CurrentOperationName As String = My.Resources.Documents_AccumulativeCosts_TypeName
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
        Private _ParentFinancialDataCanChange As Boolean = True
        Private _ParentFinancialDataCanChangeExplanation As String = ""
        Private _AllChildrenFinancialDataCanChange As Boolean = True
        Private _AllChildrenFinancialDataCanChangeExplanation As String = ""


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

        Public ReadOnly Property ParentFinancialDataCanChange() As Boolean _
        Implements IChronologicValidator.ParentFinancialDataCanChange
            Get
                Return _ParentFinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property ParentFinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.ParentFinancialDataCanChangeExplanation
            Get
                Return _ParentFinancialDataCanChangeExplanation
            End Get
        End Property

        Public ReadOnly Property AllChildrenFinancialDataCanChange() As Boolean
            Get
                Return _AllChildrenFinancialDataCanChange
            End Get
        End Property

        Public ReadOnly Property AllChildrenFinancialDataCanChangeExplanation() As String
            Get
                Return _AllChildrenFinancialDataCanChangeExplanation
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

        Friend Shared Function NewAccumulativeCostsChronologicValidator() As AccumulativeCostsChronologicValidator
            Return New AccumulativeCostsChronologicValidator(True)
        End Function

        Friend Shared Function GetAccumulativeCostsChronologicValidator(ByVal nOperationID As Integer, _
            ByVal redistributionItems As AccumulativeCostsItemList) As AccumulativeCostsChronologicValidator
            Return New AccumulativeCostsChronologicValidator(nOperationID, redistributionItems)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub


        Private Sub New(ByVal createObject As Boolean)
            Create()
        End Sub

        Private Sub New(ByVal nOperationID As Integer, ByVal redistributionItems As AccumulativeCostsItemList)
            Fetch(nOperationID, redistributionItems)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create()

            Dim closingDate As Date = GetCurrentCompany.LastClosingDate

            If closingDate <> Date.MinValue AndAlso closingDate <> Date.MaxValue Then
                _MinDateApplicable = True
                _MinDate = closingDate.AddDays(1)
                _MinDateExplanation = "Operacijos data negali būti ankstesnė nei " _
                    & _MinDate.ToString("yyyy-MM-dd") & ", nes prieš tai yra registruota " _
                    & "likučių perkėlimo ir (ar) 5/6 klasių uždarymo operacija."
                _LimitsExplanation = _MinDateExplanation
            End If

            SetGeneralData()

        End Sub

        Private Sub Fetch(ByVal nOperationID As Integer, ByVal redistributionItems As AccumulativeCostsItemList)

            Dim myComm As New SQLCommand("FetchAccumulativeCostsChronologicValidator")
            myComm.AddParam("?PD", nOperationID)

            Using myData As DataTable = myComm.Fetch

                _CurrentOperationID = nOperationID

                If myData.Rows.Count < 1 Then Throw New Exception("Sukauptų sąnaudų objektas, kurio ID=" _
                    & nOperationID.ToString & ", nerastas.")

                Dim dr As DataRow = myData.Rows(0)

                _CurrentOperationDate = CDateSafe(dr.Item(0), Date.MinValue)

                If _CurrentOperationDate.Date = Date.MinValue.Date Then Throw New Exception( _
                    "Nepavyko gauti sukauptų sąnaudų operacijos datos. (ID=" & nOperationID.ToString & ")")

                Dim lastClosing As Date = CDateSafe(dr.Item(1), Date.MinValue)
                Dim transferDate As Date = CDateSafe(dr.Item(3), Date.MinValue)

                If lastClosing <> Date.MinValue OrElse transferDate <> Date.MinValue Then

                    _MinDateApplicable = True

                    If lastClosing > transferDate Then
                        _MinDate = lastClosing.AddDays(1)
                    Else
                        _MinDate = transferDate
                    End If

                    _MinDateExplanation = "Data negali būti ankstesnė nei " & _MinDate.ToString("yyyy-MM-dd") _
                        & " nes ankstesne data yra registruota 5/6 klasių uždarymo ir (ar) likučių perkėlimo operacija."

                End If

                _MaxDate = CDateSafe(dr.Item(2), Date.MaxValue)

                If _MaxDate <> Date.MaxValue Then

                    _MaxDateApplicable = True
                    _MaxDateExplanation = "Data negali būti vėlesnė nei " & _MaxDate.ToString("yyyy-MM-dd") _
                        & " nes vėlesne data yra registruota 5/6 klasių uždarymo ir (ar) likučių perkėlimo operacija."

                    _FinancialDataCanChange = False
                    _FinancialDataCanChangeExplanation = "Finansiniai operacijos duomenys " _
                        & "negali būti keičiami, nes vėlesne data yra registruota 5/6 klasių " _
                        & "uždarymo ir (ar) likučių perkėlimo operacija."

                End If

            End Using

            For Each c As AccumulativeCostsItem In redistributionItems

                If Not c.ChronologyValidator.FinancialDataCanChange Then

                    _AllChildrenFinancialDataCanChange = False
                    _AllChildrenFinancialDataCanChangeExplanation = AddWithNewLine( _
                        _AllChildrenFinancialDataCanChangeExplanation, _
                        c.ToString & ": " & c.ChronologyValidator.FinancialDataCanChangeExplanation, False)

                End If

            Next

            If Not _AllChildrenFinancialDataCanChange Then
                _AllChildrenFinancialDataCanChangeExplanation = AddWithNewLine( _
                "Sukauptų sąnaudų (pajamų) ir jų paskirstymo sąskaitos negali būti keičiamos:", _
                _AllChildrenFinancialDataCanChangeExplanation, False)
            End If

            SetGeneralData()

        End Sub

        Private Sub SetGeneralData()

            _LimitsExplanation = ""

            If _MinDateApplicable Then
                _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MinDateExplanation, False)
            End If

            If _MaxDateApplicable Then
                _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MaxDateExplanation, False)
            End If

            If Not _FinancialDataCanChange Then
                _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _FinancialDataCanChangeExplanation, False)
            End If

            If Not _AllChildrenFinancialDataCanChange Then
                _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _AllChildrenFinancialDataCanChangeExplanation, False)
            End If

            _BackgroundExplanation = _LimitsExplanation

        End Sub

#End Region

    End Class

End Namespace
