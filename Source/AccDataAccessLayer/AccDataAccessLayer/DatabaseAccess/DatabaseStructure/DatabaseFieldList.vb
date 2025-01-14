﻿Namespace DatabaseAccess.DatabaseStructure

    <Serializable()> _
Public Class DatabaseFieldList
        Inherits BusinessListBase(Of DatabaseFieldList, DatabaseField)

#Region " Business Methods "

        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As DatabaseField = DatabaseField.NewDatabaseField
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
            If Not IsAllFieldNamesUnique() Then
                If String.IsNullOrEmpty(result.Trim) Then
                    result = "Ne visi lentelės laukai turi unikalius pavadinimus."
                Else
                    result = result & vbCrLf & "Ne visi lentelės laukai turi unikalius pavadinimus."
                End If
            End If
            If Me.Count < 1 Then
                If String.IsNullOrEmpty(result.Trim) Then
                    result = "Lentelėje privalo būti bent vienas laukas."
                Else
                    result = result & vbCrLf & "Lentelėje privalo būti bent vienas laukas."
                End If
            End If
            If Not IsSinglePrimaryKey() Then
                If String.IsNullOrEmpty(result.Trim) Then
                    result = "Lentelėje gali būti tik vienas pagrindinis laukas (PrimaryKey)."
                Else
                    result = result & vbCrLf & "Lentelėje gali būti tik vienas pagrindinis laukas (PrimaryKey)."
                End If
            End If
            Return result
        End Function

        Public Function IsAllFieldNamesUnique() As Boolean
            Dim i, j As Integer
            For i = 1 To Me.Count
                For j = i + 1 To Me.Count
                    If Me.Item(i - 1).Name.Trim.ToLower = Me.Item(j - 1).Name.Trim.ToLower Then Return False
                Next
            Next
            Return True
        End Function

        Public Function IsSinglePrimaryKey() As Boolean
            Dim counter As Integer = 0
            For Each item As DatabaseField In Me
                If item.PrimaryKey Then counter += 1
            Next
            Return (counter < 2)
        End Function

        Public Function GetColumnByName(ByVal ColName As String, _
            Optional ByVal ThrowOnNotFound As Boolean = False) As DatabaseField
            For Each i As DatabaseField In Me
                If i.Name.Trim.ToLower = ColName.Trim.ToLower Then Return i
            Next
            If ThrowOnNotFound Then Throw New Exception("Klaida. Stulpelis '" & _
                ColName.Trim & "' nerastas.")
            Return Nothing
        End Function

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso Me.Count > 0 AndAlso IsAllFieldNamesUnique() _
                    AndAlso IsSinglePrimaryKey()
            End Get
        End Property

#End Region

#Region " Factory Methods "

        Friend Shared Function NewDatabaseFieldList() As DatabaseFieldList
            Return New DatabaseFieldList
        End Function

        Friend Shared Function GetDatabaseFieldList(ByVal node As Xml.XmlNode) As DatabaseFieldList
            Return New DatabaseFieldList(node)
        End Function

        Friend Shared Function GetDatabaseFieldList(ByVal FieldsString As String(), _
            ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator) As DatabaseFieldList
            Return New DatabaseFieldList(FieldsString, SqlGenerator)
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

        Private Sub New(ByVal FieldsString As String(), ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator)
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            MarkAsChild()
            Fetch(FieldsString, SqlGenerator)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal node As Xml.XmlNode)

            RaiseListChangedEvents = False

            For Each childnode As Xml.XmlNode In node.ChildNodes
                If childnode.LocalName = "DatabaseField" Then _
                    Add(DatabaseField.GetDatabaseField(childnode))
            Next

            RaiseListChangedEvents = True

        End Sub

        Private Sub Fetch(ByVal FieldsString As String(), ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator)

            RaiseListChangedEvents = False

            For Each s As String In FieldsString
                If SqlGenerator.IsValidFieldDbDefinition(s) Then _
                    Add(DatabaseField.GetDatabaseField(s, SqlGenerator))
            Next

            If SqlGenerator.CreateStatementContainsIndexes Then
                For Each s As String In FieldsString
                    If SqlGenerator.IsPrimaryKeyDbDefinition(s) Then
                        Me.GetColumnByName(SqlGenerator.GetIndexColumnNameFromDbDefinition(s), True).SetPrimaryKey()
                    ElseIf SqlGenerator.IsValidIndexDbDefinition(s) Then
                        Me.GetColumnByName(SqlGenerator.GetIndexColumnNameFromDbDefinition(s), True). _
                            SetIndex(SqlGenerator.GetIndexNameFromDbDefinition(s), _
                            SqlGenerator.IsIndexUniqueInDbDefinition(s))
                    End If
                Next
            End If

            RaiseListChangedEvents = True

        End Sub



        Friend Sub Update(ByVal writer As Xml.XmlWriter)

            RaiseListChangedEvents = False

            DeletedList.Clear()

            writer.WriteStartElement("DatabaseFieldList")

            For Each item As DatabaseField In Me
                item.Insert(writer)
            Next

            writer.WriteEndElement()

            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace