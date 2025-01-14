﻿Namespace Security.DatabaseTableAccess

    <Serializable()> _
Public Class DatabaseTableAccessRoleList
        Inherits BusinessListBase(Of DatabaseTableAccessRoleList, DatabaseTableAccessRole)

#Region " Business Methods "

        Private _Type As DatabaseStructureType = DatabaseStructureType.Other
        Private _FilePath As String = ""
        Private _IsNew As Boolean = True

        Friend ReadOnly Property [Type]() As DatabaseStructureType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
        End Property

        Public ReadOnly Property FilePath() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FilePath.Trim
            End Get
        End Property

        Public ReadOnly Property IsNew() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsNew
            End Get
        End Property

        Public ReadOnly Property DatabaseTableAccessRoleListSource() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _Type = DatabaseStructureType.GaugeFile Then _
                    Return "Gauge file on server."
                If IsNew Then Return "New file."
                Return "Local file: " & _FilePath & "."
            End Get
        End Property



        Protected Overrides Function AddNewCore() As Object
            Dim NewItem As DatabaseTableAccessRole = DatabaseTableAccessRole.NewRoleDatabaseAccess
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

            If Not IsAllRoleNamesUnique() Then
                If String.IsNullOrEmpty(result.Trim) Then
                    result = "Ne visos teisės (Role) turi unikalius pavadinimus."
                Else
                    result = result & vbCrLf & "Ne visos teisės (Role) turi unikalius pavadinimus."
                End If
            End If
            If Me.Count < 1 Then
                If String.IsNullOrEmpty(result.Trim) Then
                    result = "Duomenų bazėje privalo būti bent viena teisė (Role)."
                Else
                    result = result & vbCrLf & "Duomenų bazėje privalo būti bent viena teisė (Role)."
                End If
            End If

            Return result
        End Function

        Public Function IsAllRoleNamesUnique() As Boolean
            Dim i, j As Integer
            For i = 1 To Me.Count
                For j = i + 1 To Me.Count
                    If Me.Item(i - 1).RoleName.Trim.ToLower = Me.Item(j - 1).RoleName.Trim.ToLower Then Return False
                Next
            Next
            Return True
        End Function

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso Me.Count > 0 AndAlso IsAllRoleNamesUnique()
            End Get
        End Property

        Public Overrides Function Save() As DatabaseTableAccessRoleList

            If _Type <> DatabaseStructureType.GaugeFile Then
                Me.DoSave()
                Return Me
            End If

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                "Jūsų teisių nepakanka šiai operacijai atlikti.")

            If Not IsValid Then Throw New Exception("Vartotojų teisių struktūros apraše yra klaidų: " _
                    & vbCrLf & GetAllBrokenRules())

            Dim result As DatabaseTableAccessRoleList = MyBase.Save
            InvalidateCache()
            Return result

        End Function

        Public Function SaveAs(ByVal newFilePath As String) As DatabaseTableAccessRoleList
            _Type = DatabaseStructureType.Other
            _FilePath = newFilePath
            Me.DoSave()
            Return Me
        End Function

        Public Sub Paste(ByVal pasteString As String, ByVal overwrite As Boolean)

            If StringIsNullOrEmpty(pasteString) Then
                Throw New ArgumentNullException("Nothing to Paste.")
            End If

            Dim lineDelim As Char() = {ControlChars.Cr, ControlChars.Lf}
            Dim lines As String() = PasteString.Split(lineDelim, StringSplitOptions.RemoveEmptyEntries)

            Me.RaiseListChangedEvents = False

            If overwrite Then Me.Clear()

            Try
                For Each s As String In lines
                    Me.Add(DatabaseTableAccessRole.NewRoleDatabaseAccess(s))
                Next
            Catch ex As Exception

                Me.RaiseListChangedEvents = True

                Me.ResetBindings()

                Throw

            End Try

            Me.RaiseListChangedEvents = True

            Me.ResetBindings()

        End Sub



        Friend Sub AddAllTableAccessLevels(ByVal RoleName As String, _
            ByVal RoleLevel As RoleAccessType, ByRef TableAccessList As List(Of TableAccessLevel))

            For Each item As DatabaseTableAccessRole In Me
                If item.RoleName.ToLower = RoleName.Trim.ToLower Then
                    For Each tableName As String In item.TableAccessList.Split(New Char() {","c}, _
                        StringSplitOptions.RemoveEmptyEntries)
                        If RoleLevel = RoleAccessType.Update Then
                            AddTableAccessLevel(tableName, DatabaseTableAccessType.Update, _
                                TableAccessList)
                        ElseIf RoleLevel = RoleAccessType.Read Then
                            AddTableAccessLevel(tableName, DatabaseTableAccessType.Select, _
                                TableAccessList)
                        ElseIf RoleLevel = RoleAccessType.Write Then
                            AddTableAccessLevel(tableName, DatabaseTableAccessType.Insert, _
                                TableAccessList)
                        End If
                    Next
                    For Each tableName As String In item.ReadOnlyTableAccessList.Split(New Char() {","c}, _
                        StringSplitOptions.RemoveEmptyEntries)
                        AddTableAccessLevel(tableName.Trim, DatabaseTableAccessType.Select, TableAccessList)
                    Next
                    Exit Sub
                End If
            Next

            Throw New Exception("Klaida. Nežinoma vartotojo teisė, kurios kodas yra '" _
                & RoleName & "'.")

        End Sub

        Private Sub AddTableAccessLevel(ByVal TableName As String, _
            ByVal AccessLevel As DatabaseTableAccessType, _
            ByRef TableAccessList As List(Of TableAccessLevel))

            For Each item As TableAccessLevel In TableAccessList
                If item.TableName.Trim.ToLower = TableName.Trim.ToLower Then

                    If IsHigherDatabaseTableAccessType(AccessLevel, item.AccessLevel) Then _
                        item.AccessLevel = AccessLevel
                    Exit Sub

                End If
            Next
            TableAccessList.Add(New TableAccessLevel(TableName, AccessLevel))

        End Sub

        Private Shared Function IsHigherDatabaseTableAccessType( _
            ByVal FirstDatabasetableAccessType As DatabaseTableAccessType, _
            ByVal SecondDatabasetableAccessType As DatabaseTableAccessType) As Boolean

            If FirstDatabasetableAccessType = SecondDatabasetableAccessType Then Return False

            If FirstDatabasetableAccessType = DatabaseTableAccessType.Update Then
                Return True
            ElseIf FirstDatabasetableAccessType = DatabaseTableAccessType.Insert _
                AndAlso SecondDatabasetableAccessType <> DatabaseTableAccessType.Update Then
                Return True
            Else
                Return False
            End If

        End Function

        Private Sub MarkOld()
            _IsNew = False
        End Sub

        Friend Shared Function GetHelperListRoles(ByVal roles As List(Of String)) As List(Of String)

            If roles.Count < 1 OrElse (roles.Count = 1 AndAlso roles(0).Trim.ToLower _
                = Name_AdminRole.Trim.ToLower) Then Return New List(Of String)

            Dim gauge As DatabaseTableAccessRoleList = GetRoleDatabaseAccessListServerSide()

            Dim clearRoles As New List(Of String)
            For Each r As String In roles
                If r.Trim.ToLower = Name_AdminRole.Trim.ToLower Then Return New List(Of String)
                clearRoles.Add(r.Trim.ToLower.Substring(0, r.Trim.ToLower.Length - 1))
            Next

            Dim result As New List(Of String)

            For Each gaugeRole As DatabaseTableAccessRole In gauge
                If gaugeRole.IsHelperList Then
                    Dim parentRoles As New List(Of String)(gaugeRole.ParentRoles.Replace(" ", "") _
                        .Trim.ToLower.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries))
                    For Each r As String In clearRoles
                        If parentRoles.Contains(r) Then
                            result.Add(gaugeRole.RoleName & "1")
                            Exit For
                        End If
                    Next
                End If
            Next

            Return result

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanAddObject() As Boolean
            Return False
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole(Name_AdminRole)
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole(Name_AdminRole)
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return False
        End Function

#End Region

#Region " Factory Methods "

        <NotUndoable()> _
        <NonSerialized()> _
        Private Shared _Cache As DatabaseTableAccessRoleList = Nothing

        Public Shared Function NewRoleDatabaseAccessList() As DatabaseTableAccessRoleList
            Return New DatabaseTableAccessRoleList()
        End Function

        Public Shared Function GetRoleDatabaseAccessList() As DatabaseTableAccessRoleList

            If _Cache Is Nothing Then
                _Cache = DataPortal.Fetch(Of DatabaseTableAccessRoleList)(New Criteria())
            End If
            Return _Cache

        End Function

        Public Shared Function GetRoleDatabaseAccessList(ByVal nFilePath As String) As DatabaseTableAccessRoleList
            Return New DatabaseTableAccessRoleList(nFilePath)
        End Function

        Friend Shared Function GetRoleDatabaseAccessListServerSide() As DatabaseTableAccessRoleList

            Dim result As New DatabaseTableAccessRoleList
            result.FetchGauge()
            Return result

        End Function

        Friend Shared Function GetAllRolesServerSide() As List(Of String)

            Dim DTARList As New DatabaseTableAccessRoleList
            DTARList.DataPortal_Fetch(New Criteria)

            Dim result As New List(Of String)
            For Each item As DatabaseTableAccessRole In DTARList
                result.Add(item.RoleName)
            Next

            Return result

        End Function

        Public Shared Sub InvalidateCache()
            _Cache = Nothing
        End Sub


        Private Sub New()
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal nFilePath As String)
            Me.AllowEdit = True
            Me.AllowNew = True
            Me.AllowRemove = True
            FetchFromFile(nFilePath)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai operacijai atlikti.")

            FetchGauge()

        End Sub

        Private Sub FetchGauge()
            FetchFromFile(IO.Path.Combine(AppPath(), Path_RoleDatabaseAccessGauge))
            _Type = DatabaseStructureType.GaugeFile
            _FilePath = ""
        End Sub

        Private Sub FetchFromFile(ByVal nFilePath As String)

            Dim doc As New Xml.XmlDocument
            Dim enc As New Text.UTF8Encoding(False)
            doc.LoadXml(IO.File.ReadAllText(nFilePath, enc))

            RaiseListChangedEvents = False

            Dim ParentNodeFound As Boolean = False

            For Each node As Xml.XmlNode In doc.ChildNodes
                If node.LocalName = "RoleDatabaseAccessList" Then

                    For Each childnode As Xml.XmlNode In node.ChildNodes
                        If childnode.LocalName = "RoleDatabaseAccess" Then _
                            Add(DatabaseTableAccessRole.GetRoleDatabaseAccess(childnode))
                    Next

                    ParentNodeFound = True

                    Exit For

                End If
            Next

            RaiseListChangedEvents = False

            doc = Nothing

            If Not ParentNodeFound Then Throw New Exception( _
                "Klaida. Failo tagai arba formatas neatitinka standarto.")

            _FilePath = nFilePath

            MarkOld()

        End Sub

        Protected Overrides Sub DataPortal_Update()
            DoSave()
            InvalidateCache()
        End Sub

        Private Sub DoSave()

            Dim nFilePath As String
            If _Type = DatabaseStructureType.GaugeFile Then
                nFilePath = IO.Path.Combine(AppPath(), Path_RoleDatabaseAccessGauge)
            ElseIf _Type = DatabaseStructureType.Other Then
                nFilePath = _FilePath
            Else
                Throw New Exception("Klaida. Neįmanoma išsaugoti duomenų bazės veidrodžio (mirror).")
            End If

            Dim settings As New Xml.XmlWriterSettings
            settings.Encoding = New Text.UTF8Encoding(False)
            settings.Indent = True
            settings.NewLineOnAttributes = True
            settings.OmitXmlDeclaration = False

            Using writer As Xml.XmlWriter = Xml.XmlWriter.Create(nFilePath, settings)

                writer.WriteStartDocument()

                writer.WriteStartElement("RoleDatabaseAccessList")

                For Each item As DatabaseTableAccessRole In Me
                    item.Insert(writer)
                Next

                writer.WriteEndElement()

                writer.WriteEndDocument()
                writer.Flush()
                writer.Close()

            End Using

            settings = Nothing

            MarkOld()

        End Sub

#End Region

    End Class

End Namespace
