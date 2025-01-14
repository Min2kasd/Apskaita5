﻿Namespace DatabaseAccess.DatabaseStructure

    <Serializable()> _
Public Class DatabaseTable
        Inherits BusinessBase(Of DatabaseTable)

#Region " Business Methods "

        Private _GID As Guid = Guid.NewGuid
        Private _Name As String = ""
        Private _Description As String = ""
        Private _FieldList As DatabaseFieldList = Nothing
        Private _EngineName As String = ""
        Private _CharsetName As String = ""

        Public Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Name.Trim <> value.Trim Then
                    _Name = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Description() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Description.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Description.Trim <> value.Trim Then
                    _Description = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property EngineName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _EngineName.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _EngineName.Trim <> value.Trim Then
                    _EngineName = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property CharsetName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CharsetName.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CharsetName.Trim <> value.Trim Then
                    _CharsetName = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public ReadOnly Property FieldList() As DatabaseFieldList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FieldList
            End Get
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _FieldList.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _FieldList.IsValid
            End Get
        End Property

        Public Function GetAddTableStatement(ByVal DatabaseName As String, _
            ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator) As String

            Dim result As String = SqlGenerator.GetCreateTableStatementHeader(DatabaseName, Me)

            For Each item As DatabaseField In _FieldList
                result = result & item.GetFieldDbDefinition(SqlGenerator) & _
                    SqlGenerator.GetCreateTableStatementFieldSeparator
            Next

            If SqlGenerator.CreateStatementContainsIndexes Then

                For Each item As DatabaseField In _FieldList
                    If Not String.IsNullOrEmpty(item.IndexName.Trim) AndAlso Not item.PrimaryKey Then
                        result = result & item.GetIndexDbDefinition(SqlGenerator) & _
                    SqlGenerator.GetCreateTableStatementFieldSeparator
                    End If
                Next

            End If

            result = result.Substring(0, result.Length - _
                SqlGenerator.GetCreateTableStatementFieldSeparator.Length) & _
                SqlGenerator.GetCreateTableStatementTail(Me)

            Return result.Trim

        End Function

        Public Function GetDropTableStatement(ByVal DatabaseName As String, _
            ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator) As String
            Return SqlGenerator.GetDropTableStatement(DatabaseName, _Name)
        End Function

        Public Function GetAllBrokenRules() As String

            Dim result As String = _FieldList.GetAllBrokenRules.Trim

            If Not MyBase.IsValid Then
                If String.IsNullOrEmpty(result) Then
                    result = Me.BrokenRulesCollection.ToString
                Else
                    result = Me.BrokenRulesCollection.ToString & vbCrLf & result
                End If
            End If

            Return result

        End Function

        Public Shared Operator =(ByVal FirstDatabaseTable As DatabaseTable, _
            ByVal SecondDatabaseTable As DatabaseTable) As Boolean
            Return (FirstDatabaseTable.Name.Trim.ToLower = SecondDatabaseTable.Name.Trim.ToLower)
        End Operator

        Public Shared Operator <>(ByVal FirstDatabaseTable As DatabaseTable, _
            ByVal SecondDatabaseTable As DatabaseTable) As Boolean
            Return (FirstDatabaseTable.Name.Trim.ToLower <> SecondDatabaseTable.Name.Trim.ToLower)
        End Operator

        Protected Overrides Function GetIdValue() As Object
            Return _GID
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.StringRequiredRuleArgs("Name", "lentelės pavadinimas"))
        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite(Name_AdminRole)
        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewDatabaseTable() As DatabaseTable
            Return New DatabaseTable
        End Function

        Friend Shared Function GetDatabaseTable(ByVal node As Xml.XmlNode) As DatabaseTable
            Return New DatabaseTable(node)
        End Function

        Friend Shared Function GetDatabaseTable(ByVal dr As DataRow, _
            ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator) As DatabaseTable
            Return New DatabaseTable(dr, SqlGenerator)
        End Function

        Private Sub New()
            MarkAsChild()
            _FieldList = DatabaseFieldList.NewDatabaseFieldList
            ValidationRules.CheckRules()
        End Sub

        Private Sub New(ByVal node As Xml.XmlNode)
            MarkAsChild()
            Fetch(node)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator)
            MarkAsChild()
            Fetch(dr, SqlGenerator)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal node As Xml.XmlNode)

            _Name = node.Attributes.GetNamedItem("Name").Value
            _Description = node.Attributes.GetNamedItem("Description").Value
            _EngineName = node.Attributes.GetNamedItem("EngineName").Value
            _CharsetName = node.Attributes.GetNamedItem("CharsetName").Value

            For Each childnode As Xml.XmlNode In node.ChildNodes
                If childnode.LocalName = "DatabaseFieldList" Then
                    _FieldList = DatabaseFieldList.GetDatabaseFieldList(childnode)
                    Exit For
                End If
            Next

            If _FieldList Is Nothing Then _FieldList = DatabaseFieldList.NewDatabaseFieldList
            'Throw New Exception("Klaida. Lentelės '" & _Name & "' XML apibrėžime nerastas laukų sąrašas.")

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow, ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator)

            Dim dbDefinition As String
            If TypeOf dr.Item(1) Is Byte() Then
                dbDefinition = System.Text.Encoding.UTF8.GetString(DirectCast(dr.Item(1), Byte()))
            Else
                dbDefinition = dr.Item(1).ToString()
            End If

            SqlGenerator.FetchDatabaseTableFromDbDefinition(dbDefinition, _
                _Name, _EngineName, _CharsetName)

            Dim columnsString As String = dbDefinition
            columnsString = columnsString.Substring(columnsString.IndexOf( _
                SqlGenerator.GetCreateTableStatementLeftBracket) + 1, _
                columnsString.LastIndexOf(SqlGenerator.GetCreateTableStatementRightBracket) _
                - columnsString.IndexOf(SqlGenerator.GetCreateTableStatementLeftBracket) - 1).Trim

            Dim columnsStringArray As String() = SplitFields(columnsString, _
                SqlGenerator.GetCreateTableStatementFieldSeparator.Trim, _
                SqlGenerator.GetCreateTableStatementLeftBracket.Trim, _
                SqlGenerator.GetCreateTableStatementRightBracket.Trim)

            _FieldList = DatabaseFieldList.GetDatabaseFieldList(columnsStringArray, SqlGenerator)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Private Function SplitFields(ByVal DatabaseString As String, _
            ByVal FieldSeparator As String, ByVal LeftBracket As String, _
            ByVal RightBracket As String) As String()

            Dim FieldList As New List(Of String)

            Dim FieldString As String = ""
            Dim BracketArea As Boolean = False
            For Each c As Char In DatabaseString
                If c = LeftBracket.Trim Then
                    BracketArea = True
                ElseIf c = RightBracket.Trim Then
                    BracketArea = False
                End If
                If Not BracketArea AndAlso c = FieldSeparator.Trim Then
                    If Not String.IsNullOrEmpty(FieldString.Trim) Then _
                        FieldList.Add(DirectCast(FieldString.Clone, String))
                    FieldString = ""
                Else
                    FieldString = FieldString & c
                End If
            Next
            If Not String.IsNullOrEmpty(FieldString.Trim) Then _
                FieldList.Add(DirectCast(FieldString.Clone, String))

            Return FieldList.ToArray

        End Function


        Friend Sub Insert(ByVal writer As Xml.XmlWriter)

            writer.WriteStartElement("DatabaseTable")

            writer.WriteStartAttribute("Name")
            writer.WriteValue(_Name)
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("Description")
            writer.WriteValue(_Description)
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("EngineName")
            writer.WriteValue(_EngineName)
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("CharsetName")
            writer.WriteValue(_CharsetName)
            writer.WriteEndAttribute()

            _FieldList.Update(writer)

            writer.WriteEndElement()

            MarkOld()

        End Sub

#End Region

    End Class

End Namespace