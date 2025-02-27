﻿Namespace DatabaseAccess.DatabaseStructure

    <Serializable()> _
Public Class DatabaseStoredProcedureList
        Inherits BusinessListBase(Of DatabaseStoredProcedureList, DatabaseStoredProcedure)

#Region " Business Methods "

        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As DatabaseStoredProcedure = DatabaseStoredProcedure.NewDatabaseStoredProcedure
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

            If Not IsAllStoredProcedureNamesUnique() Then
                If String.IsNullOrEmpty(result.Trim) Then
                    result = "Ne visos procedūros turi unikalius pavadinimus."
                Else
                    result = result & vbCrLf & "Ne visos procedūros turi unikalius pavadinimus."
                End If
            End If

            Return result
        End Function

        Public Function IsAllStoredProcedureNamesUnique() As Boolean
            Dim i, j As Integer
            For i = 1 To Me.Count
                For j = i + 1 To Me.Count
                    If Me.Item(i - 1).Name.Trim.ToLower = Me.Item(j - 1).Name.Trim.ToLower Then Return False
                Next
            Next
            Return True
        End Function


        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso IsAllStoredProcedureNamesUnique()
            End Get
        End Property

#End Region

#Region " Factory Methods "

        Friend Shared Function NewDatabaseStoredProcedureList() As DatabaseStoredProcedureList
            Return New DatabaseStoredProcedureList
        End Function

        Friend Shared Function GetDatabaseStoredProcedureList( _
          ByVal node As Xml.XmlNode) As DatabaseStoredProcedureList
            Return New DatabaseStoredProcedureList(node)
        End Function

        Friend Shared Function GetDatabaseStoredProcedureList( _
            ByVal DatabaseName As String, ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator) _
            As DatabaseStoredProcedureList
            Return New DatabaseStoredProcedureList(DatabaseName, SqlGenerator)
        End Function

        Private Sub New()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            MarkAsChild()
        End Sub

        Private Sub New(ByVal node As Xml.XmlNode)
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            MarkAsChild()
            Fetch(node)
        End Sub

        Private Sub New(ByVal DatabaseName As String, ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator)
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            MarkAsChild()
            Fetch(DatabaseName, SqlGenerator)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal node As Xml.XmlNode)

            RaiseListChangedEvents = False

            For Each childnode As Xml.XmlNode In node.ChildNodes
                If childnode.LocalName = "DatabaseStoredProcedure" Then _
                    Add(DatabaseStoredProcedure.GetDatabaseStoredProcedure(childnode))
            Next

            RaiseListChangedEvents = True

        End Sub

        Private Sub Fetch(ByVal DatabaseName As String, ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator)

            If Not SqlGenerator.SupportsStoredProcedures Then Exit Sub

            Dim myComm As New SQLCommand("RawSQL", SqlGenerator.GetShowProceduresStatement(DatabaseName))

            Using myData As DataTable = myComm.Fetch

                RaiseListChangedEvents = False

                If SqlGenerator.ShowProceduresResultsIncludeCreateTableStatements Then

                    For Each dr As DataRow In myData.Rows
                        Add(DatabaseStoredProcedure.GetDatabaseStoredProcedure(dr, SqlGenerator))
                    Next

                Else

                    For Each dr As DataRow In myData.Rows

                        myComm = New SQLCommand("RawSQL", _
                            SqlGenerator.GetShowCreateProcedureStatement( _
                            DatabaseName, dr.Item(1).ToString.Trim))

                        Using tableData As DataTable = myComm.Fetch
                            Add(DatabaseStoredProcedure.GetDatabaseStoredProcedure( _
                                tableData.Rows(0), SqlGenerator))
                        End Using

                    Next

                End If

                RaiseListChangedEvents = True

            End Using

        End Sub



        Friend Sub Update(ByVal writer As Xml.XmlWriter)

            RaiseListChangedEvents = False

            DeletedList.Clear()

            writer.WriteStartElement("DatabaseStoredProcedureList")

            For Each item As DatabaseStoredProcedure In Me
                item.Insert(writer)
            Next

            writer.WriteEndElement()

            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace