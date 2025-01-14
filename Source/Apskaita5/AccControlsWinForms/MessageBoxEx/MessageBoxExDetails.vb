﻿Imports System.Runtime.Serialization.Formatters.Binary
''' <summary>
''' (c) http://www.codeproject.com/Articles/9656/Dissecting-the-MessageBox
''' </summary>
Friend Class MessageBoxExDetails

    Friend _Exception As Exception = Nothing
    Private _BusinessObject As Object = Nothing


    Public Sub New(nException As Exception, nBusinessObject As Object)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _Exception = nException
        _BusinessObject = nBusinessObject

    End Sub


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.Hide()
        Me.Close()
    End Sub

    Private Sub MessageBoxExDetails_Load(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles MyBase.Load
        If _Exception Is Nothing Then Exit Sub
        ExDetails.Text = GetDescription()
    End Sub



    Private Function GetDescription()

        Dim builder As New Text.StringBuilder()

        builder.Append("Programos versija: ")
        If ApplicationVersion Is Nothing OrElse String.IsNullOrEmpty(ApplicationVersion.Trim()) Then
            builder.AppendLine("Nenurodyta")
        Else
            builder.AppendLine(ApplicationVersion)
        End If

        builder.Append("Windows versija: ")
        builder.AppendLine(Environment.OSVersion.VersionString)

        builder.Append(".NET versija: ")
        builder.AppendLine(Environment.Version.ToString)

        builder.AppendLine()
        builder.AppendLine()

        FormatExceptionString(_Exception, False, builder)

        If _BusinessObject IsNot Nothing Then

            builder.AppendLine()
            builder.AppendLine()

            builder.Append("Objekto tipas: ")
            builder.AppendLine(_BusinessObject.GetType().FullName)
            builder.AppendLine("Objekto būsena:")
            builder.Append("<Base64>")
            Try
                Dim formater As New BinaryFormatter()
                Using ms As New IO.MemoryStream()
                    formater.Serialize(ms, _BusinessObject)
                    builder.Append(Convert.ToBase64String(ms.ToArray()))
                End Using
            Catch ex As Exception
                builder.Append("Failed to serialize: ")
                builder.Append(ex.Message)
            End Try

            builder.Append("<\Base64>")

        End If

        Return builder.ToString()

    End Function

    Private Sub FormatExceptionString(ByVal ex As Exception, ByVal internal As Boolean, builder As Text.StringBuilder)

        If internal Then
            builder.AppendLine("Vidinės klaidos (internal exception) duomenys:")
        Else
            builder.AppendLine("Klaidos duomenys:")
        End If

        builder.Append("Klaidos tipas: ")
        builder.AppendLine(ex.GetType().FullName)

        builder.AppendLine("Klaidos tekstas:")
        builder.AppendLine(ex.Message)

        If ex.Source IsNot Nothing Then
            builder.AppendLine("Klaidos šaltinis(Ex.Source):")
            builder.AppendLine(ex.Source)
        End If

        If ex.TargetSite IsNot Nothing Then
            builder.AppendLine("Klaidos metodas (Ex.TargetSite):")
            builder.AppendLine(ex.TargetSite.Name)
        End If

        If ex.StackTrace IsNot Nothing AndAlso Not String.IsNullOrEmpty(ex.StackTrace) Then
            builder.AppendLine("Klaidos stekas:")
            builder.AppendLine(ex.StackTrace)
        End If

        If ex.InnerException IsNot Nothing Then
            builder.AppendLine()
            builder.AppendLine("----------------------------")
            FormatExceptionString(ex.InnerException, True, builder)
        End If

    End Sub

    Private Sub ReportButton_Click(sender As Object, e As EventArgs) Handles ReportButton.Click

        Dim mapi As New MAPI

        mapi.AddRecipientTo("programa.apskaita@gmail.com")

        mapi.SendMailPopup("Apskaita5 Error Report", ExDetails.Text)

        If Not mapi.GetLastError.Trim.ToLower.StartsWith("ok") Then

            Throw New Exception(String.Format("Klaida atidarant e-pašto klientą: {0}",
                mapi.GetLastError))

        End If

    End Sub

End Class