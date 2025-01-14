﻿Imports System.Globalization

Friend Class FormulaSolver

    Private pos, bracket, ebene As Integer
    Private res As Double
    Public F_Error As Boolean = False
    Private Params As Dictionary(Of String, Double) = Nothing

    Public Property Param(ByVal key As String) As Double
        Get
            If Params Is Nothing OrElse Not Params.ContainsKey(key) Then
                F_Error = True
                MsgBox("Klaida. Tokio parametro nėra parametrų sąraše.")
                Return 0
            End If
            Return Params.Item(key)
        End Get
        Set(ByVal value As Double)
            If Params Is Nothing Then Params = New Dictionary(Of String, Double)
            If Not Params.ContainsKey(key) Then
                Params.Add(key, value)
            Else
                Params.Item(key) = value
            End If
        End Set
    End Property

    Public Sub ClearParams()
        If Params Is Nothing Then Params = New Dictionary(Of String, Double)
        Params.Clear()
    End Sub

    Private Function TryVariable(ByVal VarStr As String, ByRef Value As Double) As Boolean
        Dim tre As Double = Param(VarStr)
        If F_Error Then
            Value = tre
            Return False
        Else
            Value = tre
            Return True
        End If
    End Function

    Private Function GetBracket(ByVal Str As String, ByVal start As Integer) As Integer
        Dim result As Integer = start
        For i As Integer = start To Str.Length - 1
            Select Case Str.Substring(i, 1)
                Case "("
                    bracket = bracket + 1
                Case ")"
                    bracket = bracket - 1
            End Select
            If bracket = 0 Then
                result = i
                Exit For
            End If
        Next
        Return result
    End Function

    Private Function Solve(ByVal Formula As String) As Double
        If Formula.Length = 0 Then Return GenerateError()
        If Formula.StartsWith("(") And GetBracket(Formula, 0) = Formula.Length - 1 _
            Then Formula = Formula.Substring(1, Formula.Length - 2)
        If Double.TryParse(Formula, System.Globalization.NumberStyles.Float, Nothing, res) Then Return res
        If Formula.Length = 2 AndAlso Formula.ToUpper = "PI" Then Return Math.PI
        If Formula.Length = 3 AndAlso TryVariable(Formula, res) Then Return res

        Dim zc As String

        If Formula.Length > 4 AndAlso Formula.Substring(3, 1) = "(" Then
            pos = GetBracket(Formula, 3)
            If pos <> Formula.Length - 1 Then GoTo cont
            zc = Formula.Substring(4, pos - 4)
            Select Case Formula.Substring(0, 3).ToLower
                Case "sqr"
                    Return Math.Sqrt(Solve(zc))
                Case "sin"
                    Return Math.Sin(Solve(zc) * Math.PI / 180)
                Case "cos"
                    Return Math.Cos(Solve(zc) * Math.PI / 180)
                Case "tan"
                    Return Math.Tan(Solve(zc) * Math.PI / 180)
                Case "log"
                    Return Math.Log10(Solve(zc))
                Case "abs"
                    Return Math.Abs(Solve(zc))
                Case "imz"
                    Dim tres As Double = Solve(zc)
                    Return Convert.ToDouble(IIf(tres > 0, tres, 0))
            End Select
        End If

cont:
        pos = 0
        ebene = 6
        bracket = 0

        For i As Integer = Formula.Length - 1 To 0 Step -1
            Select Case Formula.Substring(i, 1)
                Case "("
                    bracket += 1
                    Exit Select
                Case ")"
                    bracket -= 1
                    Exit Select
                Case "+"
                    If bracket = 0 And ebene > 0 Then
                        pos = i
                        ebene = 0
                    End If
                    Exit Select
                Case "-"
                    If bracket = 0 And ebene > 1 Then
                        pos = i
                        ebene = 1
                    End If
                    Exit Select
                Case "*"
                    If bracket = 0 And ebene > 2 Then
                        pos = i
                        ebene = 2
                    End If
                    Exit Select
                Case "%"
                    If bracket = 0 And ebene > 3 Then
                        pos = i
                        ebene = 3
                    End If
                    Exit Select
                Case "/"
                    If bracket = 0 And ebene > 4 Then
                        pos = i
                        ebene = 4
                    End If
                    Exit Select
                Case "^"
                    If bracket = 0 And ebene > 5 Then
                        pos = i
                        ebene = 5
                    End If
                    Exit Select
            End Select
        Next

        If pos = 0 OrElse pos = Formula.Length - 1 Then Return GenerateError()

        zc = Formula.Substring(pos, 1)
        Dim t1, t2 As String
        t1 = Formula.Substring(0, pos)
        t2 = Formula.Substring(pos + 1, Formula.Length - (pos + 1))
        Select Case zc
            Case "+"
                Return CRound(Solve(t1) + Solve(t2))
            Case "-"
                Return CRound(Solve(t1) - Solve(t2))
            Case "*"
                Return CRound(Solve(t1) * Solve(t2))
            Case "/"
                Return CRound(Solve(t1) / Solve(t2))
            Case "%"
                Return Math.IEEERemainder(Solve(t1), Solve(t2))
            Case "^"
                Return Math.Pow(Solve(t1), Solve(t2))
        End Select
        Return GenerateError()
    End Function

    Private Function GenerateError() As Double
        F_Error = True
        Return 0
    End Function

    Public Function Solved(ByVal Formula As String, ByRef result As Double) As Boolean
        If String.IsNullOrEmpty(Formula) Then
            result = 0
            Return False
        End If
        If CChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) <> CChar(",") Then _
            Formula = Formula.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        F_Error = False
        result = Solve(Formula)
        Return Not F_Error
    End Function

End Class
