Imports System.Text.RegularExpressions
Namespace General

    <Serializable()> _
    Public Class ImportedPersonList
        Inherits BusinessListBase(Of ImportedPersonList, ImportedPerson)

#Region " Business Methods "

        Public Function GetAllBrokenRules() As String
            Dim result As String = GetAllBrokenRulesForList(Me)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = GetAllWarningsForList(Me)
            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Overrides Function Save() As ImportedPersonList

            If Not Me.Count > 0 Then Throw New Exception("Klaida. Neįkrauta nė viena eilutė.")

            If Not Me.IsValid Then Throw New Exception("Įkrautuose duomenyse yra klaidų: " _
                & vbCrLf & GetAllBrokenRules())

            Dim result As ImportedPersonList = MyBase.Save()
            HelperLists.PersonInfoList.InvalidateCache()
            Return result

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.Person2")
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of ImportedPerson) = Nothing

        Public Shared Function GetImportedPersonList(ByVal Source As String) As ImportedPersonList
            Return DataPortal.Fetch(Of ImportedPersonList)(New Criteria( _
                Source, vbCrLf, vbTab, "", ""))
        End Function

        Public Function GetSortedList() As Csla.SortedBindingList(Of ImportedPerson)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of ImportedPerson)(Me)
            Return _SortedList
        End Function


        Private Sub New()
            ' require use of factory methods
            Me.AllowEdit = False
            Me.AllowNew = False
            Me.AllowRemove = True
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _Source As String
            Private _LineDelimiter As String
            Private _ColumnDelimiter As String
            Private _ColumnWrapper As String
            Private _EscapeString As String
            Public ReadOnly Property Source() As String
                Get
                    Return _Source
                End Get
            End Property
            Public ReadOnly Property LineDelimiter() As String
                Get
                    Return _LineDelimiter
                End Get
            End Property
            Public ReadOnly Property ColumnDelimiter() As String
                Get
                    Return _ColumnDelimiter
                End Get
            End Property
            Public ReadOnly Property ColumnWrapper() As String
                Get
                    Return _ColumnWrapper
                End Get
            End Property
            Public ReadOnly Property EscapeString() As String
                Get
                    Return _EscapeString
                End Get
            End Property
            Public Sub New(ByVal nSource As String, ByVal nLineDelimiter As String, _
                ByVal nColumnDelimiter As String, ByVal nColumnWrapper As String, _
                ByVal nEscapeString As String)
                _Source = nSource
                _LineDelimiter = nLineDelimiter
                _ColumnDelimiter = nColumnDelimiter
                _ColumnWrapper = nColumnWrapper
                _EscapeString = nEscapeString
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiems duomenims gauti.")

            If criteria.Source Is Nothing OrElse String.IsNullOrEmpty(criteria.Source.Trim) Then _
                Throw New Exception("Klaida. Nenurodytas importos šaltinis (gautas tuščias tekstas).")
            If criteria.LineDelimiter Is Nothing OrElse String.IsNullOrEmpty(criteria.LineDelimiter) Then _
                Throw New Exception("Klaida. Nenurodytas eilučių skirtukas.")
            If criteria.ColumnDelimiter Is Nothing OrElse String.IsNullOrEmpty(criteria.ColumnDelimiter) Then _
                Throw New Exception("Klaida. Nenurodytas stulpelių skirtukas.")

            Dim LineDelimiter As String = criteria.LineDelimiter
            If LineDelimiter <> vbCrLf AndAlso LineDelimiter <> vbCr AndAlso LineDelimiter <> vbLf Then
                LineDelimiter = LineDelimiter.Trim.ToUpper
                LineDelimiter = LineDelimiter.Replace("\R\N", vbCrLf)
                LineDelimiter = LineDelimiter.Replace("\R", vbCr)
                LineDelimiter = LineDelimiter.Replace("\N", vbLf)
            End If

            Dim ColumnDelimiter As String = criteria.ColumnDelimiter
            If ColumnDelimiter <> vbTab Then
                ColumnDelimiter = ColumnDelimiter.Trim.ToUpper
                ColumnDelimiter = ColumnDelimiter.Replace("\T", vbTab)
            End If

            Dim PIL As PersonInfoList = PersonInfoList.GetListServerSide
            Dim PersonCodeList As New List(Of String)
            For Each pi As PersonInfo In PIL
                PersonCodeList.Add(pi.Code.Trim.ToUpper)
            Next

            Dim AIL As AccountInfoList = AccountInfoList.GetListServerSide
            Dim AccountList As New List(Of Long)
            For Each pi As AccountInfo In AIL
                AccountList.Add(pi.ID)
            Next

            Dim AlreadyPresentCodes As New List(Of String)

            RaiseListChangedEvents = True

            For Each s As String In criteria.Source.Split(New String() {LineDelimiter}, _
                StringSplitOptions.RemoveEmptyEntries)
                Add(ImportedPerson.GetImportedPerson(s.Split(New String() {ColumnDelimiter}, _
                    StringSplitOptions.None), AccountList, PersonCodeList, AlreadyPresentCodes))
            Next

            RaiseListChangedEvents = False

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                "Klaida. Jūsų teisių nepakanka šiai operacijai.")

            DatabaseAccess.TransactionBegin()

            RaiseListChangedEvents = False

            DeletedList.Clear()

            For Each item As ImportedPerson In Me
                If item.IsValid Then item.Insert()
            Next

            Me.Clear()
            DeletedList.Clear()

            RaiseListChangedEvents = True

            DatabaseAccess.TransactionCommit()

        End Sub

#End Region

    End Class

End Namespace