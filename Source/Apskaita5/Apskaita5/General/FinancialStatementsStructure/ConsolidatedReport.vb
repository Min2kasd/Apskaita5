﻿Imports System.IO
Imports System.Xml
Imports ApskaitaObjects.My.Resources

Namespace General

    ''' <summary>
    ''' Represents a structure of hierarchical consolidated financial statement reports
    ''' (balance sheet and income statement).
    ''' </summary>
    ''' <remarks>The actual data is managed by <see cref="ConsolidatedReportItemList">
    ''' ConsolidatedReportItemList</see> and <see cref="ConsolidatedReportItem">
    ''' ConsolidatedReportItem</see> classes. This class is only used to signal the root level
    ''' of the hierarchy and to provide common save interface.
    ''' Values are stored in the database table financialstatementsstructure.
    ''' Values are stored using <see href="https://en.wikipedia.org/wiki/Nested_set_model">
    ''' Nested set model</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class ConsolidatedReport
        Inherits BusinessBase(Of ConsolidatedReport)
        Implements IValidationMessageProvider

#Region " Business Methods "

        Private Const ParentElementName As String = "FinancialReportingStructure"

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _Children As ConsolidatedReportItem


        ''' <summary>
        ''' Gets a top level ConsolidatedReportItemList (2 items for BalanceSheet, 
        ''' 1 - for IncomeStatement).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Children() As ConsolidatedReportItem
            Get
                Return _Children
            End Get
        End Property


        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _Children.IsValid
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _Children.IsDirty
            End Get
        End Property


#Region " Old interface "

        ''' <summary>
        ''' Adds a new child item to the specified parent item and returns
        ''' a new item's guid. If the parent item is not found in the document, 
        ''' returns <see cref="Guid.Empty">Guid.Empty</see>.
        ''' </summary>
        ''' <param name="parentItemGuid"><see cref="ConsolidatedReportItem.Guid">
        ''' A Guid of the item</see> that a new child should be added to.</param>
        ''' <remarks></remarks>
        <Obsolete()> _
        Public Function AddChild(ByVal parentItemGuid As Guid) As Guid
            Dim result As Guid = _Children.AddChild(parentItemGuid)
            If result = Guid.Empty Then
                Throw New Exception(String.Format( _
                    My.Resources.General_ConsolidatedReport_ItemNotFound, _
                    parentItemGuid.ToString()))
            End If
            Return result
        End Function

        ''' <summary>
        ''' Removes an item from the document. Returns TRUE if the item is found
        ''' and successfuly removed.
        ''' </summary>
        ''' <param name="itemGuidToRemove"><see cref="ConsolidatedReportItem.Guid">
        ''' A Guid of the item</see> that should be removed.</param>
        ''' <remarks></remarks>
        <Obsolete()> _
        Public Sub RemoveChild(ByVal itemGuidToRemove As Guid)
            If Not _Children.RemoveChild(itemGuidToRemove) Then
                Throw New Exception(String.Format( _
                    My.Resources.General_ConsolidatedReport_ItemNotFound, _
                    itemGuidToRemove.ToString()))
            End If
        End Sub

        ''' <summary>
        ''' Moves an item up in the child list. Returns TRUE if the item is found
        ''' and successfuly moved.
        ''' </summary>
        ''' <param name="itemGuidToMove"><see cref="ConsolidatedReportItem.Guid">
        ''' A Guid of the item</see> that should be moved up in the child list.</param>
        ''' <remarks></remarks>
        <Obsolete()> _
        Public Function MoveChildUp(ByVal itemGuidToMove As Guid) As Boolean
            Dim success As Boolean = False
            If Not _Children.MoveChildUp(itemGuidToMove, success) Then
                Throw New Exception(String.Format( _
                    My.Resources.General_ConsolidatedReport_ItemNotFound, _
                    itemGuidToMove.ToString()))
            End If
            Return success
        End Function

        ''' <summary>
        ''' Moves an item down in the child list. Returns TRUE if the item is found
        ''' and successfuly moved.
        ''' </summary>
        ''' <param name="itemGuidToMove"><see cref="ConsolidatedReportItem.Guid">
        ''' A Guid of the item</see> that should be moved down in the child list.</param>
        ''' <remarks></remarks>
        <Obsolete()> _
        Public Function MoveChildDown(ByVal itemGuidToMove As Guid) As Boolean
            Dim success As Boolean = False
            If Not _Children.MoveChildDown(itemGuidToMove, success) Then
                Throw New Exception(String.Format( _
                    My.Resources.General_ConsolidatedReport_ItemNotFound, _
                    itemGuidToMove.ToString()))
            End If
            Return success
        End Function

        ''' <summary>
        ''' Sets <see cref="ConsolidatedReportItem.Name">item Name property</see> value.
        ''' </summary>
        ''' <param name="itemGuid">a guid of the item to set the value for</param>
        ''' <param name="newNameValue">a value to set</param>
        ''' <remarks></remarks>
        <Obsolete()> _
        Public Sub SetName(ByVal itemGuid As Guid, ByVal newNameValue As String)
            If Not _Children.SetName(itemGuid, newNameValue) Then
                Throw New Exception(String.Format( _
                    My.Resources.General_ConsolidatedReport_ItemNotFound, _
                    itemGuid.ToString()))
            End If
        End Sub

        ''' <summary>
        ''' Sets <see cref="ConsolidatedReportItem.IsCredit">item IsCredit property</see> value.
        ''' </summary>
        ''' <param name="itemGuid">a guid of the item to set the value for</param>
        ''' <param name="newIsCreditValue">a value to set</param>
        ''' <remarks></remarks>
        <Obsolete()> _
        Public Sub SetIsCredit(ByVal itemGuid As Guid, ByVal newIsCreditValue As Boolean)
            If Not _Children.SetIsCredit(itemGuid, newIsCreditValue) Then
                Throw New Exception(String.Format( _
                    My.Resources.General_ConsolidatedReport_ItemNotFound, _
                    itemGuid.ToString()))
            End If
        End Sub

        ''' <summary>
        ''' Gets a child item by it's <see cref="ConsolidatedReportItem.Guid">Guid property</see>.
        ''' </summary>
        ''' <param name="itemGuid">a Guid of the item to find</param>
        ''' <remarks></remarks>
        <Obsolete()> _
        Public Function GetChild(ByVal itemGuid As Guid) As ConsolidatedReportItem
            Dim result As ConsolidatedReportItem = _Children.GetChild(itemGuid)
            If result Is Nothing Then
                Throw New Exception(String.Format( _
                    My.Resources.General_ConsolidatedReport_ItemNotFound, _
                    itemGuid.ToString()))
            End If
            Return result
        End Function

#End Region


        ''' <summary>
        ''' Gets a (direct) parent item for the child item specified.
        ''' </summary>
        ''' <param name="ofChild">a child item to find a parent item for</param>
        Public Function GetParent(ByVal ofChild As ConsolidatedReportItem) As ConsolidatedReportItem
            If Object.ReferenceEquals(ofChild, _Children) Then Return Nothing
            Return _Children.GetParent(ofChild)
        End Function

        ''' <summary>
        ''' Gets a value indicating whether the source item can be moved 
        ''' </summary>
        ''' <param name="source">an item to be moved</param>
        ''' <param name="target">a target item to move to</param>
        ''' <param name="moveType">a type of the move action</param>
        ''' <param name="message">an explanation of why the item cannot be moved</param>
        Public Function CanMoveItem(ByVal source As ConsolidatedReportItem, ByVal target As ConsolidatedReportItem, _
            ByVal moveType As MoveItemType, ByRef message As String) As Boolean

            If source Is Nothing Then
                message = General_ConsolidatedReport_MoveSourceNull
                Return False
            End If

            If target Is Nothing Then
                message = General_ConsolidatedReport_MoveTargetNull
                Return False
            End If

            If source.IsRootItem Then
                message = General_ConsolidatedReport_CannotMoveHeader
                Return False
            End If

            If target.IsRootItem Then
                message = General_ConsolidatedReport_CannotMoveToHeader
                Return False
            End If

            If Object.ReferenceEquals(source, target) Then
                message = General_ConsolidatedReport_CannotMoveToItself
                Return False
            End If

            Dim sourceParent As ConsolidatedReportItem = GetParent(source)
            If sourceParent Is Nothing Then
                message = General_ConsolidatedReport_SourceParentNotFound
                Return False
            End If

            Dim targetParent As ConsolidatedReportItem = GetParent(target)
            If targetParent Is Nothing Then
                message = General_ConsolidatedReport_TargetParentNotFound
                Return False
            End If

            If Object.ReferenceEquals(sourceParent, targetParent) AndAlso moveType <> MoveItemType.ToItem Then Return True

            If target.Type <> source.Type Then

                message = General_ConsolidatedReport_CannotMoveToDifferentType
                Return False

            End If

            If source.IsParentOf(target) Then

                message = General_ConsolidatedReport_CannotMoveParentToChild
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Moves the source item to the new location in target item.
        ''' </summary>
        ''' <param name="source">an item to be moved</param>
        ''' <param name="target">a target item to move to</param>
        ''' <param name="moveType">a type of the move action</param>
        ''' <remarks></remarks>
        Public Sub MoveItem(ByVal source As ConsolidatedReportItem, ByVal target As ConsolidatedReportItem, _
            ByVal moveType As MoveItemType)

            Dim exceptionMessage As String = ""
            If Not CanMoveItem(source, target, moveType, exceptionMessage) Then
                Throw New Exception(exceptionMessage)
            End If

            Dim sourceParent As ConsolidatedReportItem = GetParent(source)
            Dim targetParent As ConsolidatedReportItem = GetParent(target)

            Dim indexToMove As Integer = targetParent.Children.IndexOf(target)
            If moveType = MoveItemType.BelowItem Then indexToMove += 1

            If Object.ReferenceEquals(sourceParent, targetParent) AndAlso moveType <> MoveItemType.ToItem Then

                sourceParent.Children.MoveToIndex(source, indexToMove)

            Else

                If moveType = MoveItemType.ToItem Then
                    sourceParent.Children.MoveToNewList(source, target.Children, -1)
                Else
                    sourceParent.Children.MoveToNewList(source, targetParent.Children, indexToMove)
                End If

            End If

        End Sub

        ''' <summary>
        ''' Gets a value indicating whether the child item can be removed.
        ''' </summary>
        ''' <param name="child">an item to be removed</param>
        ''' <param name="message">an explanation of why the item cannot be removed</param>
        Public Function CanRemoveItem(ByVal child As ConsolidatedReportItem, ByRef message As String) As Boolean

            message = ""

            If child Is Nothing Then
                message = General_ConsolidatedReport_ItemToRemoveNull
                Return False
            End If

            Dim childParent As ConsolidatedReportItem = GetParent(child)
            If childParent Is Nothing Then
                message = General_ConsolidatedReport_ItemToRemoveParentNotFound
                Return False
            End If

            If child.IsRootItem Then
                message = General_ConsolidatedReport_CannotRemoveHeader
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Gets a value indicating whether the user should be warned before removing the child item. 
        ''' </summary>
        ''' <param name="child">an item to be removed</param>
        ''' <param name="message">an explanation of why it is dangerous to remove the item</param>
        Public Function WarnBeforeRemoveItem(ByVal child As ConsolidatedReportItem, ByRef message As String) As Boolean

            message = ""

            If child Is Nothing Then Return False

            If child.HasAccountsAssigned Then
                message = General_ConsolidatedReport_WarningAssignedAccountsWillBeLostAfterRemovingItem
                Return True
            End If

            Return False

        End Function

        ''' <summary>
        ''' Removes the child item specified.
        ''' </summary>
        ''' <param name="child">an item to be removed</param>
        Public Sub RemoveItem(ByVal child As ConsolidatedReportItem)

            Dim exceptionMessage As String = ""
            If Not CanRemoveItem(child, exceptionMessage) Then
                Throw New Exception(exceptionMessage)
            End If

            Dim childParent As ConsolidatedReportItem = GetParent(child)
            childParent.Children.Remove(child)

        End Sub


        Friend Sub SetValues(ByVal source As ActiveReports.AccountTurnoverInfoList, _
            ByVal closingSummaryItemId As Integer)
            _Children.SetValues(source, closingSummaryItemId)
        End Sub

        Friend Function GetBalanceSheetInfoList() As List(Of ActiveReports.BalanceSheetInfo)

            Dim sorted As New SortedDictionary(Of Integer, ActiveReports.BalanceSheetInfo)

            _Children.AddBalanceStatementInfoItem(sorted, 0)

            Dim result As New List(Of ActiveReports.BalanceSheetInfo)
            For Each dr As KeyValuePair(Of Integer, ActiveReports.BalanceSheetInfo) In sorted
                result.Add(dr.Value)
            Next

            Return result

        End Function

        Friend Function GetIncomeStatementInfoList() As List(Of ActiveReports.IncomeStatementInfo)

            Dim sorted As New SortedDictionary(Of Integer, ActiveReports.IncomeStatementInfo)

            _Children.AddIncomeStatementInfoItem(sorted, 0)

            Dim result As New List(Of ActiveReports.IncomeStatementInfo)
            For Each dr As KeyValuePair(Of Integer, ActiveReports.IncomeStatementInfo) In sorted
                result.Add(dr.Value)
            Next

            Return result

        End Function


        Public Overrides Function Save() As ConsolidatedReport

            ' databindings don't work with TreeView control in .NET 2.0
            ' so we need to triger rules checking before saving
            CheckRules()

            Dim result As ConsolidatedReport
            result = MyBase.Save()
            AssignableCRItemList.InvalidateCache()
            Return result

        End Function


        ''' <summary>
        ''' Saves the current instance to an xml file.
        ''' </summary>
        ''' <param name="filePath">a full path to the file to save the data to</param>
        ''' <param name="encoding">a file encoding to use, default is UTF8</param>
        ''' <remarks></remarks>
        Public Sub SaveToFile(ByVal filePath As String, _
            Optional ByVal encoding As System.Text.Encoding = Nothing)

            If encoding Is Nothing Then
                encoding = System.Text.Encoding.UTF8
            End If

            Dim writer As New XmlTextWriter(filePath, encoding)

            WriteXmlData(writer)

        End Sub

        ''' <summary>
        ''' Converts the current instance data to an xml string. 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetXmlString() As String

            Dim result As String

            Using textWriter As New IO.StringWriter()

                Dim writer As New XmlTextWriter(textWriter)

                WriteXmlData(writer)

                result = textWriter.ToString()

            End Using

            Return result

        End Function

        Private Sub WriteXmlData(ByVal writer As XmlTextWriter)

            writer.Formatting = Formatting.Indented
            writer.Indentation = 2

            writer.WriteStartDocument(True)

            writer.WriteStartElement(ParentElementName)

            _Children.WriteXmlNode(CType(writer, XmlWriter))

            writer.WriteEndElement()

            writer.WriteEndDocument()

            writer.Close()

        End Sub


        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            End If
            If Not _Children.IsValid Then
                result = AddWithNewLine(result, _Children.GetErrorString(), False).Trim
            End If
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If Me.BrokenRulesCollection.WarningCount > 0 Then
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            End If
            If _Children.HasWarnings() Then
                result = AddWithNewLine(result, _Children.GetWarningString(), False)
            End If
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return Me.BrokenRulesCollection.WarningCount > 0 OrElse _Children.HasWarnings()
        End Function

        ''' <summary>
        ''' databindings don't work with TreeView control in .NET 2.0
        ''' so the GUI needs to triger rules checking before saving
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CheckRules()
            Me.ValidationRules.CheckRules()
            _Children.CheckRules()
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return My.Resources.General_ConsolidatedReport_ToString
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.AccountList3")
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.AccountList1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.AccountList3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            ' Consolidated report cannot be deleted without replacing it with a new one
            Return False
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Returns a new instance of ConsolidatedReport.
        ''' </summary>
        Public Shared Function NewConsolidatedReport() As ConsolidatedReport

            Dim result As New ConsolidatedReport
            result._Children = ConsolidatedReportItem.NewRootConsolidatedReportItem()
            result.ValidationRules.CheckRules()
            result.MarkNew()
            Return result

        End Function

        ''' <summary>
        ''' Gets a new instance of ConsolidatedReport from an xml file.
        ''' </summary>
        ''' <param name="filePath">a full path to the file containing the data</param>
        ''' <param name="encoding">a file encoding to use, use null value for default 
        ''' (UTF8) encoding</param>
        ''' <remarks>Use <see cref="SaveToFile">SaveToFile</see> method to 
        ''' save an instance data to an xml file.</remarks>
        Public Shared Function NewConsolidatedReport(ByVal filePath As String, _
            ByVal encoding As System.Text.Encoding) As ConsolidatedReport
            Return New ConsolidatedReport(filePath, encoding)
        End Function

        ''' <summary>
        ''' Gets a new instance of ConsolidatedReport from an xml string.
        ''' </summary>
        ''' <param name="xmlText">an xml string containing the data</param>
        ''' <remarks>Use <see cref="SaveToFile">SaveToFile</see> method to 
        ''' save an instance data to an xml file.</remarks>
        Public Shared Function NewConsolidatedReport(ByVal xmlText As String) As ConsolidatedReport
            Return New ConsolidatedReport(xmlText)
        End Function


        ''' <summary>
        ''' Gets an existing ConsolidatedReport instance from a database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function GetConsolidatedReport() As ConsolidatedReport
            Return DataPortal.Fetch(Of ConsolidatedReport)(New Criteria())
        End Function

        ''' <summary>
        ''' Gets an existing ConsolidatedReport instance from a database as a child object,
        ''' i.e. bypassing dataportal.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Shared Function GetConsolidatedReportChild() As ConsolidatedReport
            Dim result As New ConsolidatedReport
            result.MarkAsChild()
            result.DataPortal_Fetch(New Criteria())
            Return result
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal filePath As String, ByVal encoding As System.Text.Encoding)
            ' require use of factory methods
            Create(filePath, encoding)
        End Sub

        Private Sub New(ByVal xmlText As String)
            ' require use of factory methods
            Create(xmlText)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()
            End Sub
        End Class


        Private Sub Create(ByVal filePath As String, ByVal encoding As System.Text.Encoding)

            If encoding Is Nothing Then
                encoding = System.Text.Encoding.UTF8
            End If

            Dim xmlText As String = IO.File.ReadAllText(filePath, encoding)

            Create(xmlText)

        End Sub

        Private Sub Create(ByVal xmlText As String)

            Dim xmldoc As New XmlDataDocument()
            xmldoc.LoadXml(xmlText)

            If xmldoc.ChildNodes.Count <> 2 OrElse xmldoc.ChildNodes(1).ChildNodes.Count <> 1 OrElse _
                xmldoc.ChildNodes(1).Name.Trim.ToLower <> ParentElementName.Trim.ToLower() Then

                Throw New Exception(My.Resources.General_ConsolidatedReport_InvalidXmlContent)

            End If

            If xmldoc.ChildNodes(1).ChildNodes(0).Item(ConsolidatedReportItem.ChildrenNodeName).ChildNodes.Count <> 2 Then

                Throw New Exception(My.Resources.General_ConsolidatedReport_InvalidXmlContent)

            End If

            _Children = ConsolidatedReportItem.GetConsolidatedReportItem( _
                xmldoc.ChildNodes(1).ChildNodes(0), 0)

            'If _Children.Children(0).Type <> FinancialStatementItemType.HeaderStatementOfFinancialPosition _
            '    OrElse _Children.Children(1).Type <> FinancialStatementItemType.HeaderStatementOfComprehensiveIncome _
            '    OrElse _Children.Children(1).Children.Count <> 1 _
            '    OrElse _Children.Children(1).Children(0).Type <> FinancialStatementItemType.StatementOfComprehensiveIncome Then

            '    Throw New Exception(My.Resources.General_ConsolidatedReport_InvalidBaseStructureInXmlData)

            'End If

        End Sub


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As New SQLCommand("FetchConsolidatedReport")

            Using myData As DataTable = myComm.Fetch
                _Children = ConsolidatedReportItem.GetConsolidatedReportItem(myData, 0)
            End Using

            Me.MarkOld()

            Me.ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()
            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)
            DoSave()
        End Sub

        Protected Overrides Sub DataPortal_Update()
            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)
            DoSave()
        End Sub

        Friend Sub DoSave()

            Using transaction As New SqlTransaction

                Try

                    If IsNew Then

                        ' new structure -> clear old structure
                        Dim myComm As New SQLCommand("DeleteAllConsolidatedReportItems")
                        myComm.Execute()

                        myComm = New SQLCommand("UpdateAllConsolidatedReportAccounts")
                        myComm.Execute()

                    End If

                    _Children.SaveRootItem()

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub

#End Region

    End Class

End Namespace