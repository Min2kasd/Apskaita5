﻿Imports ApskaitaObjects.My.Resources

Namespace Goods

    ''' <summary>
    ''' Represents a helper object to bulk import <see cref="GoodsItem">general goods data</see>.
    ''' </summary>
    ''' <remarks><see cref="GoodsItem">GoodsItem</see> cannot be used directly because it contains
    ''' non flat hierarchy (multiple price and regional content entries per single goods item).</remarks>
    <Serializable()> _
    Public NotInheritable Class ImportedGoodsItemList
        Inherits BusinessListBase(Of ImportedGoodsItemList, ImportedGoodsItem)
        Implements IValidationMessageProvider, IIsDirtyEnough

#Region " Business Methods "

        Private _ImportWarnings As String = ""


        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid
            End Get
        End Property

        Public ReadOnly Property IsDirtyEnough() As Boolean Implements IIsDirtyEnough.IsDirtyEnough
            Get
                Return Me.Count > 0
            End Get
        End Property

        ''' <summary>
        ''' Gets a description of non critical errors encountered when parsing data.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ImportWarnings() As String
            Get
                Return _ImportWarnings
            End Get
        End Property


        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = GetAllBrokenRulesForList(Me)

            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = GetAllWarningsForList(Me)
            'Dim GeneralErrorString As String = ""
            'SomeGeneralValidationSub(GeneralErrorString)
            'AddWithNewLine(result, GeneralErrorString, False)

            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            For Each i As ImportedGoodsItem In Me
                If i.HasWarnings() Then Return True
            Next
            Return False
        End Function


        Public Overrides Function Save() As ImportedGoodsItemList

            Dim result As ImportedGoodsItemList = MyBase.Save()
            HelperLists.GoodsInfoList.InvalidateCache()
            Return result

        End Function

#End Region

#Region " Authorization Rules "

        Public Shared Function CanAddObject() As Boolean
            Return GoodsItem.CanAddObject()
        End Function

#End Region

#Region " Factory Methods "

        ' used to implement automatic sort in datagridview
        <NonSerialized()> _
        Private _SortedList As Csla.SortedBindingList(Of ImportedGoodsItem) = Nothing

        ''' <summary>
        ''' Gets a new empty ImportedGoodsItemList instance.
        ''' </summary>
        ''' <remarks>Used to support ""empty binding"".</remarks>
        Public Shared Function NewImportedGoodsItemList() As ImportedGoodsItemList
            Return New ImportedGoodsItemList
        End Function

        ''' <summary>
        ''' Parses source string data and creates a new ImportedGoodsItemList.
        ''' </summary>
        ''' <param name="source">A CrLf and Tab delimited string that contains general goods data.</param>
        ''' <remarks></remarks>
        Public Shared Function GetImportedGoodsItemList(ByVal source As String) As ImportedGoodsItemList
            Return DataPortal.Fetch(Of ImportedGoodsItemList)(New Criteria(
                source, vbCrLf, vbTab, "", ""))
        End Function

        ''' <summary>
        ''' Creates a new ImportedGoodsItemList using data in the template datatable.
        ''' </summary>
        ''' <param name="table">a template datatable containing the data to import,
        ''' see <see cref="ImportedGoodsItem.GetDataTableSpecification()">ImportedGoodsItem.GetDataTableSpecification()</see> method.</param>
        ''' <remarks></remarks>
        Public Shared Function GetImportedGoodsItemList(ByVal table As DataTable) As ImportedGoodsItemList
            Return DataPortal.Fetch(Of ImportedGoodsItemList)(New Criteria(table))
        End Function

        ''' <summary>
        ''' Gets a sorted view of the collection.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a datagridview.</remarks>
        Public Function GetSortedList() As Csla.SortedBindingList(Of ImportedGoodsItem)
            If _SortedList Is Nothing Then _SortedList = New Csla.SortedBindingList(Of ImportedGoodsItem)(Me)
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

        <Serializable()>
        Private Class Criteria
            Private _Table As DataTable = Nothing
            Private _Source As String
            Private _LineDelimiter As String
            Private _ColumnDelimiter As String
            Private _ColumnWrapper As String
            Private _EscapeString As String
            Public ReadOnly Property Table() As DataTable
                Get
                    Return _Table
                End Get
            End Property
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
            Public Sub New(ByVal nSource As String, ByVal nLineDelimiter As String,
                ByVal nColumnDelimiter As String, ByVal nColumnWrapper As String,
                ByVal nEscapeString As String)
                _Source = nSource
                _LineDelimiter = nLineDelimiter
                _ColumnDelimiter = nColumnDelimiter
                _ColumnWrapper = nColumnWrapper
                _EscapeString = nEscapeString
            End Sub
            Public Sub New(nTable As DataTable)
                _Table = nTable
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            If criteria.Table Is Nothing Then
                FetchFromString(criteria)
            Else
                FetchFromDataTable(criteria.Table)
            End If

        End Sub

        Private Sub FetchFromString(criteria As Criteria)

            If StringIsNullOrEmpty(criteria.Source) Then _
                Throw New Exception(Goods_ImportedGoodsItemList_SourceNull)
            If criteria.LineDelimiter Is Nothing OrElse String.IsNullOrEmpty(criteria.LineDelimiter) Then _
                Throw New Exception(Goods_ImportedGoodsItemList_LineDelimiterNull)
            If criteria.ColumnDelimiter Is Nothing OrElse String.IsNullOrEmpty(criteria.ColumnDelimiter) Then _
                Throw New Exception(Goods_ImportedGoodsItemList_ColumnDelimiterNull)

            Dim lineDelimiter As String = criteria.LineDelimiter
            If lineDelimiter <> vbCrLf AndAlso lineDelimiter <> vbCr AndAlso lineDelimiter <> vbLf Then
                lineDelimiter = lineDelimiter.Trim.ToUpper
                lineDelimiter = lineDelimiter.Replace("\R\N", vbCrLf)
                lineDelimiter = lineDelimiter.Replace("\R", vbCr)
                lineDelimiter = lineDelimiter.Replace("\N", vbLf)
            End If

            Dim columnDelimiter As String = criteria.ColumnDelimiter
            If columnDelimiter <> vbTab Then
                columnDelimiter = columnDelimiter.Trim.ToUpper
                columnDelimiter = columnDelimiter.Replace("\T", vbTab)
            End If

            Dim goodsInDatabase As List(Of String) = GetGoodsInDatabase()
            Dim groups As GoodsGroupInfoList = GoodsGroupInfoList.GetGoodsGroupInfoListChild

            Dim ail As AccountInfoList = AccountInfoList.GetListChild
            Dim accountList As New List(Of Long)
            For Each pi As AccountInfo In ail
                accountList.Add(pi.ID)
            Next

            Dim previousGoods As New List(Of String)

            RaiseListChangedEvents = True

            For Each s As String In criteria.Source.Split(New String() {lineDelimiter},
                StringSplitOptions.RemoveEmptyEntries)

                Dim fieldArray As String() = s.Split(New String() {columnDelimiter}, StringSplitOptions.None)
                Dim name As String = CStrSafe(ImportedGoodsItem.GetItem(fieldArray, 0)).Trim

                If Not String.IsNullOrEmpty(name.Trim) Then

                    Dim groupInfo As GoodsGroupInfo = groups.GetItem(CStrSafe(
                        ImportedGoodsItem.GetItem(fieldArray, 4)).Trim)

                    Dim groupedName As String = name.Trim.ToUpper

                    Dim groupName As String = Goods_ImportedGoodsItemList_EmptyGroupName
                    If Not groupInfo Is Nothing AndAlso Not groupInfo.IsEmpty Then
                        groupedName = groupedName & groupInfo.Name.Trim.ToUpper
                        groupName = groupInfo.Name
                    End If

                    If goodsInDatabase.Contains(groupedName) Then
                        _ImportWarnings = AddWithNewLine(_ImportWarnings, String.Format(
                            Goods_ImportedGoodsItemList_GoodsItemAlreadyExists,
                            name, groupName), False)
                    ElseIf previousGoods.Contains(groupedName) Then
                        _ImportWarnings = AddWithNewLine(_ImportWarnings, String.Format(
                            Goods_ImportedGoodsItemList_DuplicateGoodsItemInSource,
                            name, groupName), False)
                    Else
                        Add(ImportedGoodsItem.GetImportedGoodsItem(fieldArray, groups, accountList))
                        previousGoods.Add(groupedName)
                    End If

                Else

                    _ImportWarnings = AddWithNewLine(_ImportWarnings, String.Format(
                        Goods_ImportedGoodsItemList_GoodsNameNull, s), False)

                End If

            Next

            RaiseListChangedEvents = False

        End Sub

        Private Sub FetchFromDataTable(table As DataTable)

            Dim goodsInDatabase As List(Of String) = GetGoodsInDatabase()
            Dim groups As GoodsGroupInfoList = GoodsGroupInfoList.GetGoodsGroupInfoListChild

            Dim ail As AccountInfoList = AccountInfoList.GetListChild
            Dim accountList As New List(Of Long)
            For Each pi As AccountInfo In ail
                accountList.Add(pi.ID)
            Next

            Dim previousGoods As New List(Of String)

            RaiseListChangedEvents = True

            For Each dr As DataRow In table.Rows

                Dim name As String = DirectCast(dr.Item("Name"), String)

                If Not StringIsNullOrEmpty(name) Then

                    Dim groupInfo As GoodsGroupInfo = groups.GetItem(DirectCast(dr.Item("GroupInfo"), String))

                    Dim groupedName As String = name.Trim.ToUpper

                    Dim groupName As String = Goods_ImportedGoodsItemList_EmptyGroupName
                    If Not groupInfo Is Nothing AndAlso Not groupInfo.IsEmpty Then
                        groupedName = groupedName & groupInfo.Name.Trim.ToUpper
                        groupName = groupInfo.Name
                    End If

                    If goodsInDatabase.Contains(groupedName) Then
                        _ImportWarnings = AddWithNewLine(_ImportWarnings, String.Format(
                            Goods_ImportedGoodsItemList_GoodsItemAlreadyExists,
                            name, groupName), False)
                    ElseIf previousGoods.Contains(groupedName) Then
                        _ImportWarnings = AddWithNewLine(_ImportWarnings, String.Format(
                            Goods_ImportedGoodsItemList_DuplicateGoodsItemInSource,
                            name, groupName), False)
                    Else
                        Add(ImportedGoodsItem.GetImportedGoodsItem(dr, groups, accountList))
                        previousGoods.Add(groupedName)
                    End If

                Else

                    _ImportWarnings = AddWithNewLine(_ImportWarnings, String.Format(
                        Goods_ImportedGoodsItemList_GoodsNameNull, DataRowToString(dr)), False)

                End If

            Next

            RaiseListChangedEvents = False

        End Sub

        Private Function GetGoodsInDatabase() As List(Of String)

            Dim result As List(Of String)

            Dim myComm As New SQLCommand("FetchGoodsNameGroupList")
            Using myData As DataTable = myComm.Fetch
                result = New List(Of String)
                For Each dr As DataRow In myData.Rows
                    result.Add(CStrSafe(dr.Item(0)).Trim.ToUpper & CStrSafe(dr.Item(1)).Trim.ToUpper)
                Next
            End Using

            Return result

        End Function

        Protected Overrides Sub DataPortal_Update()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            If Not Me.Count > 0 Then Throw New Exception(Goods_ImportedGoodsItemList_ListEmpty)

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Using transaction As New SqlTransaction

                Try

                    RaiseListChangedEvents = False

                    For i As Integer = Me.Count To 1 Step -1
                        If Item(i - 1).IsValid Then
                            Item(i - 1).Insert()
                            RemoveAt(i - 1)
                        End If
                    Next

                    DeletedList.Clear()

                    RaiseListChangedEvents = True

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

        End Sub

#End Region

    End Class

End Namespace