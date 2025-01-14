﻿''' <summary>
''' Represents an <see cref="IChronologicValidator">IChronologicValidator</see> instance that is used 
''' to validate complex parent objects chronologic restrains by aggregating their child items' 
''' <see cref="IChronologicValidator">chronologic validators</see> choosing the most strict terms.
''' </summary>
''' <remarks></remarks>
<Serializable()> _
Public NotInheritable Class ComplexChronologicValidator
    Inherits ReadOnlyBase(Of ComplexChronologicValidator)
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
    Private _ParentFinancialDataCanChange As Boolean = True
    Private _ParentFinancialDataCanChangeExplanation As String = ""
    Private _ChildrenFinancialDataCanChange As Boolean = True
    Private _ChildrenFinancialDataCanChangeExplanation As String = ""
    Private _BaseValidator As IChronologicValidator = Nothing

    ''' <summary>
    ''' Gets an ID of the validated (parent) object. 
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentOperationID() As Integer _
        Implements IChronologicValidator.CurrentOperationID
        <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Get
            Return _CurrentOperationID
        End Get
    End Property

    ''' <summary>
    ''' Gets the current date of the validated (parent) object (<see cref="Today">Today</see> for a new object). 
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentOperationDate() As Date _
        Implements IChronologicValidator.CurrentOperationDate
        <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Get
            Return _CurrentOperationDate
        End Get
    End Property

    ''' <summary>
    ''' Gets the human readable name of the validated (parent) object. 
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentOperationName() As String _
        Implements IChronologicValidator.CurrentOperationName
        <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Get
            Return _CurrentOperationName.Trim
        End Get
    End Property

    ''' <summary>
    ''' Wheather the financial data of the validated object is allowed to be changed
    ''' by the <see cref="BaseValidator">BaseValidator</see>,
    ''' i.e. not taking into account the child objects validators.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property FinancialDataCanChange() As Boolean _
        Implements IChronologicValidator.FinancialDataCanChange
        <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Get
            Return _FinancialDataCanChange
        End Get
    End Property

    ''' <summary>
    ''' Wheather there is a minimum allowed date for the validated (parent) object.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property MinDateApplicable() As Boolean _
        Implements IChronologicValidator.MinDateApplicable
        <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Get
            Return _MinDateApplicable
        End Get
    End Property

    ''' <summary>
    ''' Wheather there is a maximum allowed date for the validated (parent) object.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property MaxDateApplicable() As Boolean _
        Implements IChronologicValidator.MaxDateApplicable
        <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Get
            Return _MaxDateApplicable
        End Get
    End Property

    ''' <summary>
    ''' Gets a minimum allowed date for the validated (parent) object.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property MinDate() As Date _
        Implements IChronologicValidator.MinDate
        <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Get
            Return _MinDate
        End Get
    End Property

    ''' <summary>
    ''' Gets a maximum allowed date for the validated (parent) object.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property MaxDate() As Date _
        Implements IChronologicValidator.MaxDate
        <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Get
            Return _MaxDate
        End Get
    End Property

    ''' <summary>
    ''' Gets a human readable explanation of why the financial data of the validated object 
    ''' is NOT allowed to be changed by the <see cref="BaseValidator">BaseValidator</see>,
    ''' i.e. not taking into account the child objects validators.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property FinancialDataCanChangeExplanation() As String _
        Implements IChronologicValidator.FinancialDataCanChangeExplanation
        <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Get
            Return _FinancialDataCanChangeExplanation.Trim
        End Get
    End Property

    ''' <summary>
    ''' Gets a human readable explanation of why there is a minimum allowed date 
    ''' for the validated (parent) object.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property MinDateExplanation() As String _
        Implements IChronologicValidator.MinDateExplanation
        <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Get
            Return _MinDateExplanation.Trim
        End Get
    End Property

    ''' <summary>
    ''' Gets a human readable explanation of why there is a maximum allowed date 
    ''' for the validated (parent) object.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property MaxDateExplanation() As String _
        Implements IChronologicValidator.MaxDateExplanation
        <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Get
            Return _MaxDateExplanation.Trim
        End Get
    End Property

    ''' <summary>
    ''' A human readable explanation of all the applicable business rules restrains.
    ''' </summary>
    Public ReadOnly Property LimitsExplanation() As String _
        Implements IChronologicValidator.LimitsExplanation
        <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Get
            Return _LimitsExplanation.Trim
        End Get
    End Property

    ''' <summary>
    ''' A human readable explanation of the applicable business rules restrains.
    ''' </summary>
    ''' <remarks>More exhaustive than <see cref="LimitsExplanation">LimitsExplanation</see>.</remarks>
    Public ReadOnly Property BackgroundExplanation() As String _
        Implements IChronologicValidator.BackgroundExplanation
        <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
        Get
            Return _BackgroundExplanation.Trim
        End Get
    End Property

    ''' <summary>
    ''' Wheather the financial data of the validated object is allowed 
    ''' to be changed by it's parent document.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property ParentFinancialDataCanChange() As Boolean _
        Implements IChronologicValidator.ParentFinancialDataCanChange
        Get
            Return _ParentFinancialDataCanChange
        End Get
    End Property

    ''' <summary>
    ''' Gets a human readable explanation of why the financial data of the validated object 
    ''' is NOT allowed to be changed by its parent document.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property ParentFinancialDataCanChangeExplanation() As String _
        Implements IChronologicValidator.ParentFinancialDataCanChangeExplanation
        Get
            Return _ParentFinancialDataCanChangeExplanation
        End Get
    End Property

    ''' <summary>
    ''' Gets a IChronologicValidator of the document (object) itself, 
    ''' i.e. without taking into account child objects.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property BaseValidator() As IChronologicValidator
        Get
            Return _BaseValidator
        End Get
    End Property

    ''' <summary>
    ''' Wheather the financial data of all the child objects is allowed to be changed
    ''' by their validators.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property ChildrenFinancialDataCanChange() As Boolean
        Get
            Return _ChildrenFinancialDataCanChange
        End Get
    End Property

    ''' <summary>
    ''' Gets a human readable explanation of why the financial data of any of the child object 
    ''' is NOT allowed to be changed by it's own validator.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property ChildrenFinancialDataCanChangeExplanation() As String
        Get
            Return _ChildrenFinancialDataCanChangeExplanation
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


    ''' <summary>
    ''' Aggregates a new child object validator when a new child is added.
    ''' </summary>
    ''' <param name="newValidationItem">An IChronologicValidator instance of a new child object.</param>
    ''' <remarks></remarks>
    Public Sub MergeNewValidationItem(ByVal newValidationItem As IChronologicValidator)
        AddValidationItem(newValidationItem)
        FetchLimitsExplanation()
    End Sub


    Protected Overrides Function GetIdValue() As Object
        Return _CurrentOperationID
    End Function

    Public Overrides Function ToString() As String
        Return _CurrentOperationName
    End Function

#End Region

#Region " Factory Methods "

    ''' <summary>
    ''' Gets a new ComplexChronologicValidator instance for a new operation (object).
    ''' </summary>
    ''' <param name="operationName">A name of the validated operation (object).</param>
    ''' <param name="baseValidator">A base validator for the validated operation (object), 
    ''' that validates chronological rules for the document itself (without taking 
    ''' into account child operations). Could be null.</param>
    ''' <param name="parentValidator">A parent document (if any) IChronologicValidator.</param>
    ''' <param name="itemValidators">A collection of child operations validators
    ''' (if any for a new document).</param>
    ''' <remarks></remarks>
    Friend Shared Function NewComplexChronologicValidator(ByVal operationName As String, _
        ByVal baseValidator As IChronologicValidator, ByVal parentValidator As IChronologicValidator, _
        ByVal itemValidators As IChronologicValidator()) As ComplexChronologicValidator
        Return New ComplexChronologicValidator(operationName, baseValidator, parentValidator, _
            itemValidators)
    End Function


    ''' <summary>
    ''' Gets a new ComplexChronologicValidator instance for an existing operation (object).
    ''' </summary>
    ''' <param name="operationID">An ID of the validated operation (object).</param>
    ''' <param name="operationDate">A date of the validated operation (object).</param>
    ''' <param name="operationName">A name of the validated operation (object).</param>
    ''' <param name="baseValidator">A base validator for the validated operation (object), 
    ''' that validates chronological rules for the document itself (without taking 
    ''' into account child operations). Could be null.</param>
    ''' <param name="parentValidator">A parent document (if any) IChronologicValidator.</param>
    ''' <param name="itemValidators">A collection of child operations validators.</param>
    ''' <remarks></remarks>
    Friend Shared Function GetComplexChronologicValidator(ByVal operationID As Integer, _
        ByVal operationDate As Date, ByVal operationName As String, _
        ByVal baseValidator As IChronologicValidator, ByVal parentValidator As IChronologicValidator, _
        ByVal itemValidators As IChronologicValidator()) As ComplexChronologicValidator
        Return New ComplexChronologicValidator(operationID, operationDate, operationName, _
            baseValidator, parentValidator, itemValidators)
    End Function

    ''' <summary>
    ''' Gets a new ComplexChronologicValidator instance for an existing operation (object)
    ''' using current validator general data. Overload is used to reload data when
    ''' child object collection changes (child objects are removed, child validators are reloaded, etc.).
    ''' </summary>
    ''' <param name="currentValidator">The current ComplexChronologicValidator instance.</param>
    ''' <param name="itemValidators">A collection of child operations validators.</param>
    ''' <remarks></remarks>
    Friend Shared Function GetComplexChronologicValidator(ByVal currentValidator As ComplexChronologicValidator, _
        ByVal itemValidators As IChronologicValidator()) As ComplexChronologicValidator

        Dim result As ComplexChronologicValidator = GetComplexChronologicValidator( _
            currentValidator.CurrentOperationID, currentValidator.CurrentOperationDate, _
            currentValidator.CurrentOperationName, currentValidator.BaseValidator, _
            Nothing, itemValidators)

        result._ParentFinancialDataCanChange = currentValidator.ParentFinancialDataCanChange
        result._ParentFinancialDataCanChangeExplanation = currentValidator.ParentFinancialDataCanChangeExplanation

        Return result

    End Function

    ''' <summary>
    ''' Gets a new ComplexChronologicValidator instance for an existing operation (object),
    ''' that encapsulates a journal entry, and sets a <see cref="SimpleChronologicValidator">
    ''' SimpleChronologicValidator</see> as a <see cref="BaseValidator">BaseValidator</see>.
    ''' </summary>
    ''' <param name="journalEntryID">An ID of the encapsulated journal entry.</param>
    ''' <param name="parentValidator">A parent document (if any) IChronologicValidator.</param>
    ''' <param name="itemValidators">A collection of child operations validators.</param>
    ''' <remarks></remarks>
    Friend Shared Function GetComplexChronologicValidator(ByVal journalEntryID As Integer, _
        ByVal parentValidator As IChronologicValidator, _
        ByVal itemValidators As IChronologicValidator()) As ComplexChronologicValidator
        Return New ComplexChronologicValidator(journalEntryID, parentValidator, itemValidators)
    End Function


    Private Sub New()
        ' require use of factory methods
    End Sub

    Private Sub New(ByVal nOperationName As String, ByVal baseValidator As IChronologicValidator, _
        ByVal parentValidator As IChronologicValidator, ByVal itemValidators As IChronologicValidator())
        Create(nOperationName, baseValidator, parentValidator, itemValidators)
    End Sub

    Private Sub New(ByVal nOperationID As Integer, ByVal nOperationDate As Date, _
        ByVal nOperationName As String, ByVal baseValidator As IChronologicValidator, _
        ByVal parentValidator As IChronologicValidator, ByVal itemValidators As IChronologicValidator())
        Fetch(nOperationID, nOperationDate, nOperationName, baseValidator, parentValidator, itemValidators)
    End Sub

    Private Sub New(ByVal journalEntryID As Integer, ByVal parentValidator As IChronologicValidator, _
        ByVal itemValidators As IChronologicValidator())
        Fetch(journalEntryID, parentValidator, itemValidators)
    End Sub

#End Region

#Region " Data Access "

    Private Sub Create(ByVal nOperationName As String, ByVal nBaseValidator As IChronologicValidator, _
        ByVal parentValidator As IChronologicValidator, ByVal itemValidators As IChronologicValidator())

        _CurrentOperationID = 0
        _CurrentOperationDate = Today
        If StringIsNullOrEmpty(nOperationName) Then
            _CurrentOperationName = ""
        Else
            _CurrentOperationName = nOperationName
        End If

        AddParentValidator(parentValidator)

        AddBaseValidator(nBaseValidator)

        AggregateValidations(itemValidators)

        FetchLimitsExplanation()

    End Sub


    Private Sub Fetch(ByVal nOperationID As Integer, ByVal nOperationDate As Date, _
        ByVal nOperationName As String, ByVal nBaseValidator As IChronologicValidator, _
        ByVal parentValidator As IChronologicValidator, ByVal itemValidators As IChronologicValidator())

        _CurrentOperationID = nOperationID
        _CurrentOperationDate = nOperationDate
        If StringIsNullOrEmpty(nOperationName) Then
            _CurrentOperationName = ""
        Else
            _CurrentOperationName = nOperationName
        End If

        AddParentValidator(parentValidator)

        AddBaseValidator(nBaseValidator)

        AggregateValidations(itemValidators)

        FetchLimitsExplanation()

    End Sub

    Private Sub Fetch(ByVal journalEntryID As Integer, ByVal parentValidator As IChronologicValidator, _
        ByVal itemValidators As IChronologicValidator())
        Dim nBaseValidator As SimpleChronologicValidator = _
            SimpleChronologicValidator.GetSimpleChronologicValidator(journalEntryID, parentValidator)
        Fetch(nBaseValidator.CurrentOperationID, nBaseValidator.CurrentOperationDate, _
            nBaseValidator.CurrentOperationName, nBaseValidator, parentValidator, itemValidators)
    End Sub


    Private Sub SetDefaultState()

        _FinancialDataCanChange = True
        _FinancialDataCanChangeExplanation = ""
        _MinDateApplicable = False
        _MaxDateApplicable = False
        _MinDate = Date.MinValue
        _MaxDate = Date.MaxValue
        _MinDateExplanation = ""
        _MaxDateExplanation = ""
        _LimitsExplanation = ""
        _BackgroundExplanation = ""
        _ParentFinancialDataCanChange = True
        _ParentFinancialDataCanChangeExplanation = ""
        _ChildrenFinancialDataCanChange = True
        _ChildrenFinancialDataCanChangeExplanation = ""
        _BaseValidator = Nothing

    End Sub

    Private Sub AggregateValidations(ByVal itemValidators As IChronologicValidator())

        If itemValidators Is Nothing OrElse itemValidators.Length < 1 Then Exit Sub

        For Each i As IChronologicValidator In itemValidators
            AddValidationItem(i)
        Next

    End Sub

    Private Sub AddValidationItem(ByVal validation As IChronologicValidator)

        If validation.MinDateApplicable AndAlso validation.MinDate.Date > _MinDate.Date Then
            _MinDateApplicable = True
            _MinDate = validation.MinDate
            _MinDateExplanation = String.Format(My.Resources.ComplexChronologicValidator_ChildLimitation, _
                validation.CurrentOperationName, validation.MinDateExplanation)
        End If

        If validation.MaxDateApplicable AndAlso validation.MaxDate.Date < _MaxDate.Date Then
            _MaxDateApplicable = True
            _MaxDate = validation.MaxDate
            _MaxDateExplanation = String.Format(My.Resources.ComplexChronologicValidator_ChildLimitation, _
                validation.CurrentOperationName, validation.MaxDateExplanation)
        End If

        If Not validation.FinancialDataCanChange Then
            _ChildrenFinancialDataCanChange = False
            _ChildrenFinancialDataCanChangeExplanation = AddWithNewLine( _
                _ChildrenFinancialDataCanChangeExplanation, _
                String.Format(My.Resources.ComplexChronologicValidator_ChildLimitation, _
                validation.CurrentOperationName, validation.FinancialDataCanChangeExplanation), False)
        End If

        If validation.MinDateApplicable OrElse validation.MaxDateApplicable _
            OrElse Not validation.FinancialDataCanChange Then
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                String.Format(My.Resources.ComplexChronologicValidator_ChildLimitation, _
                validation.CurrentOperationName, ""), False)
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                validation.FinancialDataCanChangeExplanation, False)
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                validation.MinDateExplanation, False)
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                validation.MaxDateExplanation, False)
            _BackgroundExplanation = _BackgroundExplanation & vbCrLf & vbCrLf
        End If

    End Sub

    Private Sub AddBaseValidator(ByVal nBaseValidator As IChronologicValidator)

        _BaseValidator = nBaseValidator

        If _BaseValidator Is Nothing Then Exit Sub

        If _BaseValidator.MinDateApplicable AndAlso _BaseValidator.MinDate.Date > _MinDate.Date Then
            _MinDateApplicable = True
            _MinDate = _BaseValidator.MinDate
            _MinDateExplanation = String.Format(My.Resources.ComplexChronologicValidator_ParentLimitation, _
                _BaseValidator.MinDateExplanation)
        End If

        If _BaseValidator.MaxDateApplicable AndAlso _BaseValidator.MaxDate.Date < _MaxDate.Date Then
            _MaxDateApplicable = True
            _MaxDate = _BaseValidator.MaxDate
            _MaxDateExplanation = String.Format(My.Resources.ComplexChronologicValidator_ParentLimitation, _
                _BaseValidator.MaxDateExplanation)
        End If

        If Not _BaseValidator.FinancialDataCanChange Then
            _FinancialDataCanChange = False
            _FinancialDataCanChangeExplanation = AddWithNewLine(_FinancialDataCanChangeExplanation, _
                String.Format(My.Resources.ComplexChronologicValidator_ParentLimitation, _
                _BaseValidator.FinancialDataCanChangeExplanation), False)
        End If

        If _BaseValidator.MinDateApplicable OrElse _BaseValidator.MaxDateApplicable _
            OrElse Not _BaseValidator.FinancialDataCanChange Then

            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                String.Format(My.Resources.ComplexChronologicValidator_ParentLimitation, ""), False)
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                _BaseValidator.FinancialDataCanChangeExplanation, False)
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                _BaseValidator.MinDateExplanation, False)
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                _BaseValidator.MaxDateExplanation, False)
            _BackgroundExplanation = _BackgroundExplanation & vbCrLf & vbCrLf

        End If

    End Sub

    Private Sub AddParentValidator(ByVal nParentValidator As IChronologicValidator)

        If nParentValidator Is Nothing Then Exit Sub

        If Not _BaseValidator.FinancialDataCanChange Then

            _ParentFinancialDataCanChange = False
            _ParentFinancialDataCanChangeExplanation = nParentValidator.FinancialDataCanChangeExplanation

            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                String.Format(My.Resources.ComplexChronologicValidator_ParentLimitation, ""), False)
            _BackgroundExplanation = AddWithNewLine(_BackgroundExplanation, _
                nParentValidator.FinancialDataCanChangeExplanation, False)

        End If

    End Sub

    Private Sub FetchLimitsExplanation()

        _LimitsExplanation = ""

        If Not _ParentFinancialDataCanChange Then
            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _
                String.Format(My.Resources.ComplexChronologicValidator_ParentLimitation, _
                vbCrLf & _ParentFinancialDataCanChangeExplanation), False)
        End If

        If Not _FinancialDataCanChange Then
            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _
                String.Format(My.Resources.ComplexChronologicValidator_ParentLimitation, _
                vbCrLf & _FinancialDataCanChangeExplanation), False)
        End If

        If _MinDateApplicable Then
            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MinDateExplanation, False)
        End If

        If _MaxDateApplicable Then
            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MaxDateExplanation, False)
        End If

    End Sub

#End Region

End Class