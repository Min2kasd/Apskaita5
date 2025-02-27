﻿Namespace General

    ''' <summary>
    ''' Represents an <see cref="IChronologicValidator">IChronologicValidator</see> instance that is used to validate <see cref="General.TransferOfBalance">TransferOfBalance</see> chronologic restrains.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public NotInheritable Class TransferOfBalanceChronologicValidator
        Inherits ReadOnlyBase(Of SimpleChronologicValidator)
        Implements IChronologicValidator

#Region " Business Methods "

        Private _CurrentOperationID As Integer = 0
        Private _CurrentOperationDate As Date = Today
        Private _CurrentOperationName As String = ""
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

        ''' <summary>
        ''' <see cref="General.TransferOfBalance.ID">TransferOfBalance.ID</see>
        ''' </summary>
        Public ReadOnly Property CurrentOperationID() As Integer _
            Implements IChronologicValidator.CurrentOperationID
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationID
            End Get
        End Property

        ''' <summary>
        ''' <see cref="General.TransferOfBalance.Date">TransferOfBalance.Date</see>
        ''' </summary>
        Public ReadOnly Property CurrentOperationDate() As Date _
            Implements IChronologicValidator.CurrentOperationDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable name of the validated operation.
        ''' </summary>
        Public ReadOnly Property CurrentOperationName() As String _
            Implements IChronologicValidator.CurrentOperationName
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationName.Trim
            End Get
        End Property

        ''' <summary>
        ''' Wheather existing business rules restrains allow changes of financial data of <see cref="General.TransferOfBalance">TransferOfBalance</see>.
        ''' </summary>
        Public ReadOnly Property FinancialDataCanChange() As Boolean _
            Implements IChronologicValidator.FinancialDataCanChange
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Wheather existing business rules restrains the minimum date of <see cref="General.TransferOfBalance">TransferOfBalance</see>.
        ''' </summary>
        Public ReadOnly Property MinDateApplicable() As Boolean _
            Implements IChronologicValidator.MinDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateApplicable
            End Get
        End Property

        ''' <summary>
        ''' Wheather existing business rules restrains the maximum date of <see cref="General.TransferOfBalance">TransferOfBalance</see>.
        ''' </summary>
        Public ReadOnly Property MaxDateApplicable() As Boolean _
            Implements IChronologicValidator.MaxDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateApplicable
            End Get
        End Property

        ''' <summary>
        ''' Gets a minimum allowed operation date.
        ''' </summary>
        Public ReadOnly Property MinDate() As Date _
            Implements IChronologicValidator.MinDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a maximum allowed operation date.
        ''' </summary>
        Public ReadOnly Property MaxDate() As Date _
            Implements IChronologicValidator.MaxDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDate
            End Get
        End Property

        ''' <summary>
        ''' Human readable explanation of the applicable business rules restrains that deny changes of financial data of <see cref="General.TransferOfBalance">TransferOfBalance</see>.
        ''' </summary>
        Public ReadOnly Property FinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.FinancialDataCanChangeExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChangeExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Human readable explanation of the applicable business rules restrains that limit minimum date of <see cref="General.TransferOfBalance">TransferOfBalance</see>.
        ''' </summary>
        Public ReadOnly Property MinDateExplanation() As String _
            Implements IChronologicValidator.MinDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Human readable explanation of the applicable business rules restrains that limit maximum date of <see cref="General.TransferOfBalance">TransferOfBalance</see>.
        ''' </summary>
        Public ReadOnly Property MaxDateExplanation() As String _
            Implements IChronologicValidator.MaxDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Human readable explanation of the applicable business rules restrains applicable to <see cref="General.TransferOfBalance">TransferOfBalance</see>.
        ''' </summary>
        Public ReadOnly Property LimitsExplanation() As String _
            Implements IChronologicValidator.LimitsExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LimitsExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Human readable explanation of the applicable business rules restrains applicable to <see cref="General.TransferOfBalance">TransferOfBalance</see>.
        ''' </summary>
        ''' <remarks>More exhaustive than <see cref="LimitsExplanation">LimitsExplanation</see>.
        ''' Not used currently.</remarks>
        Public ReadOnly Property BackgroundExplanation() As String _
            Implements IChronologicValidator.BackgroundExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BackgroundExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Not applicable to <see cref="General.TransferOfBalance">TransferOfBalance</see>.
        ''' </summary>
        Public ReadOnly Property ParentFinancialDataCanChange() As Boolean _
        Implements IChronologicValidator.ParentFinancialDataCanChange
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Not applicable to <see cref="General.TransferOfBalance">TransferOfBalance</see>.
        ''' </summary>
        Public ReadOnly Property ParentFinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.ParentFinancialDataCanChangeExplanation
            Get
                Return _FinancialDataCanChangeExplanation
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

        ''' <summary>
        ''' Gets an instance of TransferOfBalanceChronologicValidator.
        ''' </summary>
        ''' <remarks>Is single instance per company object as well as the parent <see cref="General.TransferOfBalance">TransferOfBalance</see>.</remarks>
        Friend Shared Function GetTransferOfBalanceChronologicValidator() As TransferOfBalanceChronologicValidator
            Return New TransferOfBalanceChronologicValidator(My.Resources.General_TransferOfBalance_TypeName)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal nOperationName As String)
            Fetch(nOperationName)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal nOperationName As String)

            Dim myComm As New SQLCommand("FetchTransferOfBalanceChronologicValidator")

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Exit Sub

                _CurrentOperationDate = CDateSafe(myData.Rows(0).Item(3), Date.MinValue)
                _CurrentOperationID = CIntSafe(myData.Rows(0).Item(2))
                _CurrentOperationName = nOperationName

                If CDateSafe(myData.Rows(0).Item(0), Date.MinValue) <> Date.MinValue Then
                    _MaxDateApplicable = True
                    _MaxDate = CDateSafe(myData.Rows(0).Item(0), Date.MinValue)
                    _MaxDateExplanation = String.Format(My.Resources.General_TransferOfBalanceChronologicValidator_MaxDateLimit, _
                        _MaxDate.ToString("yyyy-MM-dd"))
                End If

                If CDateSafe(myData.Rows(0).Item(1), Date.MaxValue) <> Date.MaxValue Then
                    _FinancialDataCanChange = False
                    _FinancialDataCanChangeExplanation = My.Resources.General_TransferOfBalanceChronologicValidator_ClosingLimit
                End If

            End Using

            _LimitsExplanation = ""
            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _FinancialDataCanChangeExplanation, False)
            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MinDateExplanation, False)
            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MaxDateExplanation, False)

        End Sub

#End Region

    End Class

End Namespace