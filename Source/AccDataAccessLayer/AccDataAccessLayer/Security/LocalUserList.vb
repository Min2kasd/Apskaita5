﻿Namespace Security

    <Serializable()> _
    Public Class LocalUserList
        Inherits BusinessListBase(Of LocalUserList, LocalUser)

#Region " Business Methods "

        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As LocalUser = LocalUser.NewLocalUser
            Me.Add(NewItem)
            Return NewItem
        End Function

        Public Function GetAllBrokenRules() As String
            Dim result As String = ""
            For i As Integer = 1 To Me.Count
                If Not String.IsNullOrEmpty(Me.Item(i - 1).BrokenRulesCollection.ToString.Trim) Then
                    If String.IsNullOrEmpty(result.Trim) Then
                        result = result & Me.Item(i - 1).BrokenRulesCollection.ToString
                    Else
                        result = result & vbCrLf & Me.Item(i - 1).BrokenRulesCollection.ToString
                    End If
                End If
            Next
            Return result
        End Function

        ''' <summary>
        ''' Returns object's string representation that could be saved to My.Settings.
        ''' </summary>
        Public Function GetSettingsString() As String

            'If Not IsValid Then Throw New Exception("Vartotojų duomenyse yra klaidų: " & _
            '    vbCrLf & GetAllBrokenRules())

            If Me.Count < 1 Then Return ""

            Dim result As String = Me.Item(0).ToSettingsString

            For i As Integer = 2 To Me.Count
                result = result & vbCrLf & Me.Item(i - 1).ToSettingsString
            Next

            Return result

        End Function

        ''' <summary>
        ''' Does nothing, because direct save from dll to exe settings is not possible.
        ''' Use GetSettingsString instead (add the string result to My.Settings appropriate slot)
        ''' </summary>
        Public Overrides Function Save() As LocalUserList
            ' do nothing, because direct save from dll to exe settings is not possible
            Return Me
        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanAddObject() As Boolean
            Return False
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return True
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return True
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return False
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetLocalUserList(ByVal SettingsString As String) As LocalUserList
            Return New LocalUserList(SettingsString)
        End Function

        Private Sub New(ByVal SettingsString As String)
            ' require use of factory methods
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            Fetch(SettingsString)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal SettingsString As String)

            Dim lineSeparator As String
            If Not SettingsString.IndexOf(vbCrLf) < 0 Then
                lineSeparator = vbCrLf
            ElseIf Not SettingsString.IndexOf(vbLf) < 0 Then
                lineSeparator = vbLf
            ElseIf Not SettingsString.IndexOf(vbCr) < 0 Then
                lineSeparator = vbCr
            Else
                lineSeparator = vbCrLf
            End If

            Dim LocalUserStringArray As String() = SettingsString.Split( _
                New String() {lineSeparator}, StringSplitOptions.RemoveEmptyEntries)

            RaiseListChangedEvents = False

            For Each s As String In LocalUserStringArray
                Add(LocalUser.GetLocalUser(s))
            Next

            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace