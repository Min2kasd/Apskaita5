﻿Imports Csla.Validation

Friend Module CommonValidation

#Region " StringRequired "

    ''' <summary>
    ''' Rule ensuring a non empty string is present.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against string property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function StringRequired(ByVal target As Object, _
      ByVal e As RuleArgs) As Boolean

        Dim ForHuman As String = DirectCast(e, StringRequiredRuleArgs).HumanReadableName
        Dim value As String = _
          CStr(CallByName(target, e.PropertyName, CallType.Get))
        If String.IsNullOrEmpty(value.Trim) Then
            e.Description = "Nenurodyta " & ForHuman & "."
            e.Severity = DirectCast(e, StringRequiredRuleArgs).ApplySeverity
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class StringRequiredRuleArgs
        Inherits RuleArgs

        Private _HumanReadableName As String = ""
        ''' <summary>
        ''' Get the human readable property name.
        ''' </summary>
        Public ReadOnly Property HumanReadableName() As String
            Get
                Return _HumanReadableName
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="HumanReadable">Human readable name of the property.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        Public Sub New(ByVal propertyName As String, ByVal HumanReadable As String, _
            Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)
            MyBase.New(propertyName)
            _HumanReadableName = HumanReadable
            _ApplySeverity = SeverityToApply
        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?HumanReadableName=" & _HumanReadableName & _
                "&SeverityToApply=" & _ApplySeverity.ToString
        End Function

    End Class

#End Region

#Region " NumberBetween "

    ''' <summary>
    ''' Rule ensuring a number is between given values.
    ''' </summary>
    ''' <param name="target">Object containing the data to validate</param>
    ''' <param name="e">Arguments parameter specifying the name of the string
    ''' property to validate</param>
    ''' <returns><see langword="false" /> if the rule is broken</returns>
    ''' <remarks>
    ''' This implementation uses late binding, and will only work
    ''' against double or integer property values.
    ''' </remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
    Public Function NumberBetween(ByVal target As Object, _
      ByVal e As RuleArgs) As Boolean

        Dim ForHuman As String = DirectCast(e, NumberBetweenRuleArgs).HumanReadableName
        Dim value As Double = CDbl(CallByName(target, e.PropertyName, CallType.Get))

        If value < DirectCast(e, NumberBetweenRuleArgs).MinimumValue Then
            e.Description = ForHuman & " negali būti mažesnis nei " & _
                DirectCast(e, NumberBetweenRuleArgs).MinimumValue.ToString & "."
            e.Severity = DirectCast(e, NumberBetweenRuleArgs).ApplySeverity
            Return False
        ElseIf value > DirectCast(e, NumberBetweenRuleArgs).MaximumValue Then
            e.Description = ForHuman & " negali būti didesnis nei " & _
                DirectCast(e, NumberBetweenRuleArgs).MaximumValue.ToString & "."
            e.Severity = DirectCast(e, NumberBetweenRuleArgs).ApplySeverity
            Return False
        Else
            Return True
        End If

    End Function

    ''' <summary>
    ''' Custom object required by the rule method.
    ''' </summary>
    Public Class NumberBetweenRuleArgs
        Inherits RuleArgs

        Private _HumanReadableName As String = ""
        ''' <summary>
        ''' Get the human readable property name.
        ''' </summary>
        Public ReadOnly Property HumanReadableName() As String
            Get
                Return _HumanReadableName
            End Get
        End Property

        Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
        ''' <summary>
        ''' Severity to apply to the rule.
        ''' </summary>
        Public ReadOnly Property ApplySeverity() As RuleSeverity
            Get
                Return _ApplySeverity
            End Get
        End Property

        Private _MinimumValue As Double
        ''' <summary>
        ''' Minimum value allowed
        ''' </summary>
        Public ReadOnly Property MinimumValue() As Double
            Get
                Return _MinimumValue
            End Get
        End Property

        Private _MaximumValue As Double
        ''' <summary>
        ''' Maximum value allowed
        ''' </summary>
        Public ReadOnly Property MaximumValue() As Double
            Get
                Return _MaximumValue
            End Get
        End Property

        ''' <summary>
        ''' Create a new object.
        ''' </summary>
        ''' <param name="propertyName">Name of the property to validate.</param>
        ''' <param name="HumanReadable">Human readable name of the property.</param>
        ''' <param name="SeverityToApply">Severity of the error to apply.</param>
        ''' <param name="MinValue">Minimal value allowed.</param>
        ''' <param name="MaxValue">Maximum value allowed.</param>
        Public Sub New(ByVal propertyName As String, ByVal HumanReadable As String, _
        ByVal MinValue As Double, ByVal MaxValue As Double, _
            Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)
            MyBase.New(propertyName)
            _HumanReadableName = HumanReadable
            _ApplySeverity = SeverityToApply
            _MinimumValue = MinValue
            _MaximumValue = MaxValue
        End Sub

        ''' <summary>
        ''' Returns a string representation of the object.
        ''' </summary>
        Public Overrides Function ToString() As String
            Return MyBase.ToString & "?HumanReadableName=" & _HumanReadableName & _
                "&SeverityToApply=" & _ApplySeverity.ToString & _
                "&MinimumValue=" & _MinimumValue.ToString & _
                "&MaximumValue=" & _MaximumValue.ToString
        End Function

    End Class

#End Region

End Module
