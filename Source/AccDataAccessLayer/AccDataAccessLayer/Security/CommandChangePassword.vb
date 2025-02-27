﻿Imports AccDataAccessLayer.DatabaseAccess
Namespace Security

    <Serializable()> _
    Public Class CommandChangePassword
        Inherits CommandBase

#Region " Authorization Rules "

        Public Shared Function CanExecuteCommand() As Boolean
            Return True
        End Function

#End Region

#Region " Client-side Code "

        Private mResult As Boolean
        Private NewPassword As String

        Public ReadOnly Property Result() As Boolean
            Get
                Return mResult
            End Get
        End Property

#End Region

#Region " Factory Methods "

        Public Shared Function TheCommand(ByVal OldPassword As String, _
            ByVal _NewPassword As String, ByVal _NewPassword2 As String) As Boolean

            Dim CurrentIdentity As AccIdentity = GetCurrentIdentity()
            If CurrentIdentity.IsLocalUser AndAlso Not CurrentIdentity.IsAuthenticatedWithDB Then _
                Throw New Exception("Klaida. Vietinis vartotojas neprisijungęs prie jokios duomenų bazės.")

            Dim ErrorString As String = ""
            If CurrentIdentity.Password.Trim <> OldPassword.Trim Then
                Throw New Exception("Klaida. Neteisingai įvestas esamas slaptažodis.")
            ElseIf Not UserAdministration.User.IsPasswordValid(_NewPassword, _
                _NewPassword2, ErrorString, CurrentIdentity.IsLocalUser, True) Then
                Throw New Exception(ErrorString)
            End If

            Dim cmd As New CommandChangePassword
            cmd.NewPassword = _NewPassword.Trim
            cmd = DataPortal.Execute(Of CommandChangePassword)(cmd)

            Return cmd.Result

        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Server-side Code "

        Protected Overrides Sub DataPortal_Execute()

            mResult = False

            Dim SqlCommandManager As SqlServerSpecificMethods.ISqlCommandManager = GetSqlCommandManager()

            SqlCommandManager.ChangePassword(NewPassword)

            mResult = True

            GetCurrentIdentity.Password = NewPassword

        End Sub

#End Region

    End Class

End Namespace
