﻿Namespace DatabaseAccess.DatabaseStructure

    <Serializable()> _
Public Class DatabaseField
        Inherits BusinessBase(Of DatabaseField)

#Region " Business Methods "

        Private _GID As Guid = Guid.NewGuid
        Private _Name As String = ""
        Private _Type As DatabaseFieldType = DatabaseFieldType.Char
        Private _Length As Integer = 255
        Private _NotNull As Boolean = True
        Private _Autoincrement As Boolean = False
        Private _Unique As Boolean = False
        Private _PrimaryKey As Boolean = False
        Private _Unsigned As Boolean = False
        Private _EnumValues As String = ""
        Private _IndexName As String = ""
        Private _Description As String = ""


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

        Public Property [Type]() As DatabaseFieldType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As DatabaseFieldType)
                CanWriteProperty(True)
                If _Type <> value Then
                    _Type = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Length() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Length
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If _Length <> value Then
                    _Length = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property NotNull() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _NotNull
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _NotNull <> value Then
                    _NotNull = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Autoincrement() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Autoincrement
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _Autoincrement <> value Then
                    _Autoincrement = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property PrimaryKey() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PrimaryKey
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _PrimaryKey <> value Then
                    _PrimaryKey = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Unique() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Unique
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _Unique <> value Then
                    _Unique = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property Unsigned() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Unsigned
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _Unsigned <> value Then
                    _Unsigned = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property EnumValues() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _EnumValues.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _EnumValues.Trim <> value.Trim Then
                    _EnumValues = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        Public Property IndexName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IndexName.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _IndexName.Trim <> value.Trim Then
                    _IndexName = value.Trim
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

        Public ReadOnly Property Indexed() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _PrimaryKey AndAlso Not String.IsNullOrEmpty(_IndexName.Trim)
            End Get
        End Property


        Public Function GetModifyFieldStatement(ByVal DatabaseName As String, _
            ByVal TableName As String, ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator) As String
            Return SqlGenerator.GetModifyFieldStatement(DatabaseName, TableName, Me)
        End Function

        Public Function GetAddFieldStatement(ByVal DatabaseName As String, _
            ByVal TableName As String, ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator) As String
            Return SqlGenerator.GetAddFieldStatement(DatabaseName, TableName, Me)
        End Function

        Public Function GetDropFieldStatement(ByVal DatabaseName As String, _
            ByVal TableName As String, ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator) As String
            Return SqlGenerator.GetDropFieldStatement(DatabaseName, TableName, Me)
        End Function

        Public Function GetCreateIndexStatement(ByVal DatabaseName As String, _
            ByVal TableName As String, ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator) As String
            Return SqlGenerator.GetCreateIndexStatement(DatabaseName, TableName, Me)
        End Function

        Public Function GetDropIndexStatement(ByVal DatabaseName As String, _
            ByVal TableName As String, ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator) As String
            Return SqlGenerator.GetDropIndexStatement(DatabaseName, TableName, Me)
        End Function

        Public Function GetFieldDbDefinition(ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator) As String
            Return SqlGenerator.GetFieldDbDefinition(Me)
        End Function

        Public Function GetIndexDbDefinition(ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator) As String
            Return SqlGenerator.GetIndexDbDefinition(Me)
        End Function

        Protected Overrides Function GetIdValue() As Object
            Return _GID
        End Function

        Public Shared Function AreFieldsDifferent(ByVal FirstDatabaseField As DatabaseField, _
            ByVal SecondDatabaseField As DatabaseField, ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator) As Boolean

            If FirstDatabaseField.Name.Trim.ToLower <> SecondDatabaseField.Name.Trim.ToLower Then _
                Throw New ArgumentException("Cannot compare columns with diferent names. Method DatabaseField.AreFieldsDifferent .")

            If Not SqlGenerator.DatabaseFieldTypesSimilar(FirstDatabaseField.Type, SecondDatabaseField.Type) _
                OrElse FirstDatabaseField.NotNull <> SecondDatabaseField.NotNull _
                OrElse FirstDatabaseField.PrimaryKey <> SecondDatabaseField.PrimaryKey _
                OrElse (SqlGenerator.SupportsUniqueFields AndAlso _
                FirstDatabaseField._Unique <> SecondDatabaseField._Unique) Then Return True

            If DatabaseFieldTypeIsInteger(FirstDatabaseField.Type) AndAlso _
                FirstDatabaseField.Unsigned <> SecondDatabaseField.Unsigned AndAlso _
                SqlGenerator.SupportsUsignedFields Then Return True

            If FirstDatabaseField.Type = DatabaseFieldType.Char AndAlso _
                SqlGenerator.SupportsCharLength AndAlso _
                FirstDatabaseField.Length <> SecondDatabaseField.Length Then Return True

            If FirstDatabaseField.Type = DatabaseFieldType.VarChar AndAlso _
                SqlGenerator.SupportsVarCharLength AndAlso _
                FirstDatabaseField.Length <> SecondDatabaseField.Length Then Return True

            If FirstDatabaseField.Type = DatabaseFieldType.Enum AndAlso _
                SqlGenerator.SupportsEnumFields AndAlso _
                FirstDatabaseField.EnumValues.Trim.Replace(" ", "").ToLower <> _
                SecondDatabaseField.EnumValues.Trim.Replace(" ", "").ToLower Then Return True

            Return False

        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringRequired, _
                New CommonValidation.StringRequiredRuleArgs("Name", "lauko pavadinimas"))
            ValidationRules.AddRule(AddressOf LengthValidation, _
                New Validation.RuleArgs("Length"))
            ValidationRules.AddRule(AddressOf AutoincrementValidation, _
                New Validation.RuleArgs("Autoincrement"))
            ValidationRules.AddRule(AddressOf UnsignedValidation, _
                New Validation.RuleArgs("Unsigned"))
            ValidationRules.AddRule(AddressOf EnumValuesValidation, _
                New Validation.RuleArgs("EnumValues"))

            ValidationRules.AddDependantProperty("Type", "Length")
            ValidationRules.AddDependantProperty("Type", "Autoincrement")
            ValidationRules.AddDependantProperty("Type", "Unsigned")
            ValidationRules.AddDependantProperty("Type", "EnumValues")

        End Sub

        ''' <summary>
        ''' Rule ensuring that a field Length is provided, when necessary.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function LengthValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As DatabaseField = DirectCast(target, DatabaseField)

            If (ValObj._Type = DatabaseFieldType.Char OrElse ValObj._Type = DatabaseFieldType.VarChar) _
                AndAlso Not ValObj._Length > 0 Then
                e.Description = "Nenurodytas lauko simbolių skaičius (ilgis)."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True
        End Function

        ''' <summary>
        ''' Rule ensuring that a field can have an autoincrement property.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AutoincrementValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As DatabaseField = DirectCast(target, DatabaseField)

            If Not DatabaseFieldTypeIsInteger(ValObj._Type) AndAlso ValObj._Autoincrement Then
                e.Description = "Savybė AUTOINCREMENT gali būti priskiriama tik " _
                    & "BIGINT, INT arba SMALLINT tipų laukui."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True
        End Function

        ''' <summary>
        ''' Rule ensuring that a field can have an unsigned property.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function UnsignedValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As DatabaseField = DirectCast(target, DatabaseField)

            If Not DatabaseFieldTypeIsInteger(ValObj._Type) AndAlso ValObj._Unsigned Then
                e.Description = "Savybė UNSIGNED gali būti priskiriama tik " _
                    & "BIGINT, INT, SMALLINT arba TINYINT tipų laukui."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True
        End Function

        ''' <summary>
        ''' Rule ensuring that enum values are provided when necessary.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function EnumValuesValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As DatabaseField = DirectCast(target, DatabaseField)

            If ValObj._Type <> DatabaseFieldType.Enum Then Return True

            If Not ValObj._EnumValues.Trim.Split(New Char() {","c}, _
                StringSplitOptions.RemoveEmptyEntries).Length > 1 Then
                e.Description = "Lauko tipui ENUM privalo būti priskirtos mažiausiai " _
                    & "dvi alternatyvios reikšmės, atskirtos kableliais."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite(Name_AdminRole)
        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewDatabaseField() As DatabaseField
            Return New DatabaseField
        End Function

        Friend Shared Function GetDatabaseField(ByVal node As Xml.XmlNode) As DatabaseField
            Return New DatabaseField(node)
        End Function

        Friend Shared Function GetDatabaseField(ByVal FieldString As String, _
            ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator) As DatabaseField
            Return New DatabaseField(FieldString, SqlGenerator)
        End Function

        Private Sub New()
            MarkAsChild()
            ValidationRules.CheckRules()
        End Sub

        Private Sub New(ByVal node As Xml.XmlNode)
            MarkAsChild()
            Fetch(node)
        End Sub

        Private Sub New(ByVal FieldString As String, ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator)
            MarkAsChild()
            Fetch(FieldString, SqlGenerator)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal node As Xml.XmlNode)

            _Name = node.Attributes.GetNamedItem("Name").Value.Trim
            _Type = DirectCast([Enum].Parse(GetType(DatabaseFieldType), node.Attributes.GetNamedItem("Type").Value.Trim), DatabaseFieldType)
            _Length = CInt(node.Attributes.GetNamedItem("Length").Value.Trim)
            _NotNull = ConvertDbBoolean(CInt(node.Attributes.GetNamedItem("NotNull").Value.Trim))
            _Autoincrement = ConvertDbBoolean(CInt(node.Attributes.GetNamedItem("Autoincrement").Value.Trim))
            _PrimaryKey = ConvertDbBoolean(CInt(node.Attributes.GetNamedItem("PrimaryKey").Value.Trim))
            _Unsigned = ConvertDbBoolean(CInt(node.Attributes.GetNamedItem("Unsigned").Value.Trim))
            _EnumValues = node.Attributes.GetNamedItem("EnumValues").Value.Trim
            _Description = node.Attributes.GetNamedItem("Description").Value.Trim
            _Unique = ConvertDbBoolean(CInt(node.Attributes.GetNamedItem("Unique").Value.Trim))
            _IndexName = node.Attributes.GetNamedItem("IndexName").Value.Trim
            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal FieldString As String, ByVal SqlGenerator As SqlServerSpecificMethods.ISqlGenerator)

            SqlGenerator.FetchDatabaseFieldFromDbDefinition(FieldString, _Name, _NotNull, _
                _Autoincrement, _PrimaryKey, _Unsigned, _Type, _Length, _EnumValues, _Unique)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Friend Sub SetPrimaryKey()
            _PrimaryKey = True
        End Sub

        Friend Sub SetIndex(ByVal nIndexName As String, ByVal nUnique As Boolean)
            _IndexName = nIndexName
            _Unique = nUnique
        End Sub


        Friend Sub Insert(ByVal writer As Xml.XmlWriter)

            writer.WriteStartElement("DatabaseField")

            writer.WriteStartAttribute("Name")
            writer.WriteValue(_Name)
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("Type")
            writer.WriteValue(_Type.ToString)
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("Length")
            writer.WriteValue(_Length)
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("NotNull")
            writer.WriteValue(ConvertDbBoolean(_NotNull))
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("Autoincrement")
            writer.WriteValue(ConvertDbBoolean(_Autoincrement))
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("Unique")
            writer.WriteValue(ConvertDbBoolean(_Unique))
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("PrimaryKey")
            writer.WriteValue(ConvertDbBoolean(_PrimaryKey))
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("Unsigned")
            writer.WriteValue(ConvertDbBoolean(_Unsigned))
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("EnumValues")
            writer.WriteValue(_EnumValues)
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("Description")
            writer.WriteValue(_Description)
            writer.WriteEndAttribute()

            writer.WriteStartAttribute("IndexName")
            writer.WriteValue(_IndexName)
            writer.WriteEndAttribute()

            writer.WriteEndElement()

            MarkOld()
        End Sub

#End Region

    End Class

End Namespace