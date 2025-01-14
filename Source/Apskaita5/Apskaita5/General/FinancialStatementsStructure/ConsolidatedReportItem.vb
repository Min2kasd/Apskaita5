﻿Imports ApskaitaObjects.Attributes
Imports ApskaitaObjects.My.Resources

Namespace General

    ''' <summary>
    ''' Represents a child item of a hierarchical consolidated financial statement report 
    ''' (balance sheet or income statement item).
    ''' </summary>
    ''' <remarks>Values are stored in the database table financialstatementsstructure.
    ''' Values are stored using <see href="https://en.wikipedia.org/wiki/Nested_set_model">
    ''' Nested set model</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class ConsolidatedReportItem
        Inherits BusinessBase(Of ConsolidatedReportItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private Const ItemNodeName As String = "ConsolidatedReportItem"
        Private Const NameNodeName As String = "Name"
        Private Const IsCreditNodeName As String = "IsCredit"
        Private Const TypeNodeName As String = "Type"
        Private Const VisibleIndexNodeName As String = "VisibleIndex"
        Private Const DisplayedNumberNodeName As String = "DisplayedNumber"
        Friend Const ChildrenNodeName As String = "Children"


        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Left As Integer = 0
        Private _Right As Integer = 0
        Private _Name As String = ""
        Private _Type As FinancialStatementItemType
        Private _IsCredit As Boolean = False
        Private _VisibleIndex As Integer = 0
        Private _DisplayedNumber As String = ""
        Private _HasAccountsAssigned As Boolean = False
        Private _Children As ConsolidatedReportItemList _
            = ConsolidatedReportItemList.NewConsolidatedReportItemList

        Private _ActualCurrentPeriodValue As Double = 0
        Private _ActualFormerPeriodValue As Double = 0
        Private _OptimizedCurrentPeriodValue As Double = 0
        Private _OptimizedFormerPeriodValue As Double = 0
        Private _RelatedAccounts As String = ""


        ''' <summary>
        ''' Gets an ID of ConsolidatedReportItem that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database field financialstatementsstructure.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets a GUID of ConsolidatedReportItem that uniquely identifies the item 
        ''' within the parent <see cref="ConsolidatedReport">ConsolidatedReport</see>.
        ''' </summary>
        ''' <remarks>Value is used to identify items within a TreeView control 
        ''' due to the lack of data binding support.
        ''' Value is not stored in the database.
        ''' Value is created when either a new <see cref="ConsolidatedReport">
        ''' ConsolidatedReport</see> is created/fetched or a new item is added.</remarks>
        Public ReadOnly Property Guid() As Guid
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Guid
            End Get
        End Property

        ''' <summary>
        ''' Whether the item is a root item, i.e. represents a root element in
        ''' a balance sheet or an income statement.
        ''' </summary>
        ''' <remarks>Root items are readonly. They cannot be changed or moved.</remarks>
        Public ReadOnly Property IsRootItem() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type = FinancialStatementItemType.HeaderGeneral OrElse _
                    _Type = FinancialStatementItemType.HeaderStatementOfComprehensiveIncome OrElse _
                    _Type = FinancialStatementItemType.HeaderStatementOfFinancialPosition
            End Get
        End Property

        ''' <summary>
        ''' Gets the left index within the nested set model.
        ''' </summary>
        ''' <remarks>Value is stored in the database field financialstatementsstructure.Lft.</remarks>
        Public Property Left() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Left
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Private Set(ByVal value As Integer)
                If _Left <> value Then
                    _Left = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the right index within the nested set model.
        ''' </summary>
        ''' <remarks>Value is stored in the database field financialstatementsstructure.Rgt.</remarks>
        Public Property Right() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Right
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Private Set(ByVal value As Integer)
                If _Right <> value Then
                    _Right = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a name of ConsolidatedReportItem, i.e. text of the line in a Consolidated Report.
        ''' </summary>
        ''' <remarks>Value is stored in the database field financialstatementsstructure.Name.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255, False)> _
        Public Property Name() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Name.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If NameIsReadOnly Then Exit Property
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Name.Trim <> value.Trim Then
                    _Name = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether credit balance is displayed as positive value.
        ''' </summary>
        ''' <remarks>Value is stored in the database field financialstatementsstructure.IsCredit.</remarks>
        Public Property IsCredit() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsCredit
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If IsCreditIsReadOnly Then Exit Property
                CanWriteProperty(True)
                If _IsCredit <> value Then
                    _IsCredit = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a sequential report line number in a 'printed' report.
        ''' </summary>
        ''' <remarks>Value is stored in the database field financialstatementsstructure.VisibleIndex.</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False)> _
        Public Property VisibleIndex() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _VisibleIndex
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                If VisibleIndexIsReadOnly Then Exit Property
                CanWriteProperty(True)
                If _VisibleIndex <> value Then
                    _VisibleIndex = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a number of the report line as diplayed in a 'printed' report.
        ''' </summary>
        ''' <remarks>Value is stored in the database field financialstatementsstructure.DisplayedNumber.</remarks>
        <StringField(ValueRequiredLevel.Recommended, 50, False)> _
        Public Property DisplayedNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DisplayedNumber.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If DisplayedNumberIsReadOnly Then Exit Property
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _DisplayedNumber.Trim <> value.Trim Then
                    _DisplayedNumber = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a type of ConsolidatedReportItem
        ''' </summary>
        ''' <remarks>Value is stored in the database field financialstatementsstructure.StatementType.</remarks>
        Public ReadOnly Property [Type]() As FinancialStatementItemType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
        End Property

        ''' <summary>
        ''' Whether the item currently have any accounts assigned.
        ''' </summary>
        Public ReadOnly Property HasAccountsAssigned() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HasAccountsAssigned
            End Get
        End Property

        ''' <summary>
        ''' Gets a list of child ConsolidatedReportItem.
        ''' </summary>
        Public ReadOnly Property Children() As ConsolidatedReportItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Children
            End Get
        End Property


        ''' <summary>
        ''' Whether <see cref="Name">Name</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property NameIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Me.IsRootItem
            End Get
        End Property

        ''' <summary>
        ''' Whether <see cref="IsCredit">IsCredit</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsCreditIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Me.IsRootItem
            End Get
        End Property

        ''' <summary>
        ''' Whether <see cref="VisibleIndex">VisibleIndex</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property VisibleIndexIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Me.IsRootItem
            End Get
        End Property

        ''' <summary>
        ''' Whether <see cref="DisplayedNumber">DisplayedNumber</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DisplayedNumberIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Me.IsRootItem
            End Get
        End Property


        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _Children.IsValid
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _Children.IsDirty
            End Get
        End Property



#Region "Old interface"

        Friend Function AddChild(ByVal parentItemGuid As Guid) As Guid

            If Me.Guid = parentItemGuid Then

                If IsRootItem Then
                    Throw New Exception(My.Resources.General_ConsolidatedReportItem_CannotChangeBaseItem)
                End If

                Dim newChild As ConsolidatedReportItem = ConsolidatedReportItem.NewConsolidatedReportItem()
                newChild._Children = ConsolidatedReportItemList.NewConsolidatedReportItemList
                newChild._IsCredit = _IsCredit
                newChild._Type = _Type

                _Children.Add(newChild)

                Return newChild.Guid

            End If

            Dim result As Guid = Guid.Empty
            For Each c As ConsolidatedReportItem In _Children
                result = c.AddChild(parentItemGuid)
                If result <> Guid.Empty Then Return result
            Next

            Return Guid.Empty

        End Function

        Friend Function RemoveChild(ByVal itemGuidToRemove As Guid) As Boolean

            For Each c As ConsolidatedReportItem In _Children

                If c.Guid = itemGuidToRemove Then

                    If IsRootItem OrElse c.IsRootItem Then
                        Throw New Exception(My.Resources.General_ConsolidatedReportItem_CannotChangeBaseItem)
                    End If

                    _Children.Remove(c)
                    Return True

                End If

            Next

            For Each c As ConsolidatedReportItem In _Children
                If c.RemoveChild(itemGuidToRemove) Then Return True
            Next

            Return False

        End Function

        Friend Function MoveChildUp(ByVal itemGuidToMove As Guid, ByRef success As Boolean) As Boolean

            For Each c As ConsolidatedReportItem In _Children

                If c._Guid = itemGuidToMove Then

                    If c.IsRootItem Then
                        Throw New Exception(My.Resources.General_ConsolidatedReportItem_CannotChangeBaseItem)
                    End If

                    Dim result As ConsolidatedReportItem = _Children.MoveUp(c)
                    If Not result Is Nothing Then
                        result.MarkDirty()
                        success = True
                    End If

                    Return True

                End If

            Next

            For Each c As ConsolidatedReportItem In _Children
                If c.MoveChildUp(itemGuidToMove, success) Then Return True
            Next

            Return False

        End Function

        Friend Function MoveChildDown(ByVal itemGuidToMove As Guid, ByRef success As Boolean) As Boolean

            For Each c As ConsolidatedReportItem In _Children

                If c._Guid = itemGuidToMove Then

                    If c.IsRootItem Then
                        Throw New Exception(My.Resources.General_ConsolidatedReportItem_CannotChangeBaseItem)
                    End If

                    Dim result As ConsolidatedReportItem = _Children.MoveDown(c)
                    If Not result Is Nothing Then
                        result.MarkDirty()
                        success = True
                    End If

                    Return True

                End If

            Next

            For Each c As ConsolidatedReportItem In _Children
                If c.MoveChildDown(itemGuidToMove, success) Then Return True
            Next

            Return False

        End Function

        Friend Function SetName(ByVal itemGuid As Guid, ByVal newNameValue As String) As Boolean

            If Me.Guid = itemGuid Then

                If Me.IsRootItem Then
                    Throw New Exception(My.Resources.General_ConsolidatedReportItem_CannotChangeBaseItem)
                End If

                Name = newNameValue
                Return True

            End If

            For Each c As ConsolidatedReportItem In _Children
                If c.SetName(itemGuid, newNameValue) Then Return True
            Next

            Return False

        End Function

        Friend Function SetIsCredit(ByVal itemGuid As Guid, ByVal newIsCreditValue As Boolean) As Boolean

            If Me.Guid = itemGuid Then

                If Me.IsRootItem Then
                    Throw New Exception(My.Resources.General_ConsolidatedReportItem_CannotChangeBaseItem)
                End If

                IsCredit = newIsCreditValue
                Return True

            End If

            For Each c As ConsolidatedReportItem In _Children
                If c.SetIsCredit(itemGuid, newIsCreditValue) Then Return True
            Next

            Return False

        End Function

        Friend Function GetChild(ByVal itemGuid As Guid) As ConsolidatedReportItem

            If itemGuid = Guid.Empty Then Return Nothing

            If itemGuid = Me._Guid Then Return Me

            Dim result As ConsolidatedReportItem = Nothing
            For Each c As ConsolidatedReportItem In Me._Children
                result = c.GetChild(itemGuid)
                If Not result Is Nothing Then Return result
            Next

            Return Nothing

        End Function

#End Region

        ''' <summary>
        ''' Gets a value indicating whether a child item can be added to this item. 
        ''' </summary>
        ''' <param name="message">an explanation of why a child item cannot be added</param>
        Public Function CanAddChild(ByRef message As String) As Boolean

            message = ""

            If _Type = FinancialStatementItemType.HeaderGeneral Then
                message = General_ConsolidatedReportItem_UserCannotAddHeaders
                Return False
            End If

            If _Type = FinancialStatementItemType.HeaderStatementOfComprehensiveIncome _
                AndAlso _Children.Count > 0 Then
                message = General_ConsolidatedReportItem_HeaderOfComprehensiveIncomeCanOnlyHaveOneRootItem
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Gets a value indicating whether the user should be warned before adding a new child item. 
        ''' </summary>
        ''' <param name="message">an explanation of why it is dangerous to remove the item</param>
        Public Function WarnBeforeAddingItem(ByRef message As String) As Boolean

            message = ""

            If _HasAccountsAssigned Then
                message = General_ConsolidatedReportItem_WarningAssignedAccountsWillBeLostAfterAddingChildItems
                Return True
            End If

            Return False

        End Function

        ''' <summary>
        ''' Adds a new child item for this item.
        ''' </summary>
        Public Function AddChild() As ConsolidatedReportItem

            Dim exceptionMessage As String = ""
            If Not CanAddChild(exceptionMessage) Then
                Throw New Exception(exceptionMessage)
            End If

            Dim newChild As ConsolidatedReportItem = ConsolidatedReportItem.NewConsolidatedReportItem()
            newChild._Children = ConsolidatedReportItemList.NewConsolidatedReportItemList

            If _Type = FinancialStatementItemType.HeaderStatementOfFinancialPosition Then

                newChild._IsCredit = False
                newChild._Type = FinancialStatementItemType.StatementOfFinancialPosition

            ElseIf _Type = FinancialStatementItemType.HeaderStatementOfComprehensiveIncome Then

                newChild._IsCredit = True
                newChild._Type = FinancialStatementItemType.StatementOfComprehensiveIncome

            Else

                newChild._IsCredit = _IsCredit
                newChild._Type = _Type

            End If

            _Children.Add(newChild)

            Return newChild

        End Function


        ''' <summary>
        ''' Gets a (direct) parent item for the child item specified.
        ''' </summary>
        ''' <param name="child">a child item to find a parent item for</param>
        Friend Function GetParent(ByVal child As ConsolidatedReportItem) As ConsolidatedReportItem

            If child Is Nothing Then Throw New ArgumentNullException("child")

            For Each c As ConsolidatedReportItem In Me._Children
                If Object.ReferenceEquals(child, c) Then Return Me
            Next

            For Each c As ConsolidatedReportItem In Me._Children
                Dim result As ConsolidatedReportItem = c.GetParent(child)
                If Not result Is Nothing Then Return result
            Next

            Return Nothing

        End Function

        ''' <summary>
        ''' Gets a value indicating whether the item is direct or indirect parent of the
        ''' child item specified.
        ''' </summary>
        ''' <param name="child">a child item to check</param>
        Friend Function IsParentOf(ByVal child As ConsolidatedReportItem) As Boolean
            For Each c As ConsolidatedReportItem In Me._Children
                If Object.ReferenceEquals(child, c) Then Return True
            Next
            For Each c As ConsolidatedReportItem In Me._Children
                Dim result As Boolean = c.IsParentOf(child)
                If result Then Return True
            Next
            Return False
        End Function


        Friend Function GetCurrentPeriodValue() As Double

            Dim result As Double = _ActualCurrentPeriodValue

            For Each child As ConsolidatedReportItem In _Children
                If child._IsCredit = _IsCredit Then
                    result = CRound(result + child.GetCurrentPeriodValue())
                Else
                    result = CRound(result - child.GetCurrentPeriodValue())
                End If
            Next

            Return result

        End Function

        Friend Function GetFormerPeriodValue() As Double

            Dim result As Double = _ActualFormerPeriodValue

            For Each child As ConsolidatedReportItem In _Children
                If child._IsCredit = _IsCredit Then
                    result = CRound(result + child.GetFormerPeriodValue())
                Else
                    result = CRound(result - child.GetFormerPeriodValue())
                End If
            Next

            Return result

        End Function

        Friend Function GetOptimizedCurrentPeriodValue() As Double

            Dim result As Double = _OptimizedCurrentPeriodValue

            For Each child As ConsolidatedReportItem In _Children
                If child._IsCredit = _IsCredit Then
                    result = CRound(result + child.GetOptimizedCurrentPeriodValue())
                Else
                    result = CRound(result - child.GetOptimizedCurrentPeriodValue())
                End If
            Next

            Return result

        End Function

        Friend Function GetOptimizedFormerPeriodValue() As Double

            Dim result As Double = _OptimizedFormerPeriodValue

            For Each child As ConsolidatedReportItem In _Children
                If child._IsCredit = _IsCredit Then
                    result = CRound(result + child.GetOptimizedFormerPeriodValue())
                Else
                    result = CRound(result - child.GetOptimizedFormerPeriodValue())
                End If
            Next

            Return result

        End Function

        Friend Function GetRelatedAccounts() As String
            Return _RelatedAccounts
        End Function

        Friend Sub SetValues(ByVal source As ActiveReports.AccountTurnoverInfoList, _
            ByVal closingSummaryItemId As Integer)

            If source Is Nothing Then Throw New ArgumentNullException("source")

            _ActualCurrentPeriodValue = 0.0
            _ActualFormerPeriodValue = 0.0
            _OptimizedCurrentPeriodValue = 0.0
            _OptimizedFormerPeriodValue = 0.0
            _RelatedAccounts = ""

            Dim relatedAccountsList As New List(Of String)

            For Each line As ActiveReports.AccountTurnoverInfo In source
                If line.FinancialStatementItemId = _ID Then

                    If _IsCredit Then

                        _ActualFormerPeriodValue = CRound(_ActualFormerPeriodValue _
                            + line.CreditBalanceCurrentPeriodStart _
                            - line.DebitBalanceCurrentPeriodStart)
                        _ActualCurrentPeriodValue = CRound(_ActualCurrentPeriodValue _
                            + line.CreditBalanceCurrentPeriodEnd _
                            - line.DebitBalanceCurrentPeriodEnd)

                    Else

                        _ActualFormerPeriodValue = CRound(_ActualFormerPeriodValue _
                            + line.DebitBalanceCurrentPeriodStart _
                            - line.CreditBalanceCurrentPeriodStart)
                        _ActualCurrentPeriodValue = CRound(_ActualCurrentPeriodValue _
                            + line.DebitBalanceCurrentPeriodEnd _
                            - line.CreditBalanceCurrentPeriodEnd)

                    End If

                    relatedAccountsList.Add(line.ID.ToString())

                    If _Type = FinancialStatementItemType.StatementOfComprehensiveIncome Then

                        ' calculate optimized values for income statement

                        If _IsCredit Then
                            _OptimizedCurrentPeriodValue = CRound(_OptimizedCurrentPeriodValue _
                                + line.CreditTurnoverCurrentPeriod _
                                - line.DebitTurnoverCurrentPeriod _
                                - line.CreditClosingCurrentPeriod _
                                + line.DebitClosingCurrentPeriod)
                            _OptimizedFormerPeriodValue = CRound(_OptimizedFormerPeriodValue _
                                + line.CreditTurnoverFormerPeriod _
                                - line.DebitTurnoverFormerPeriod _
                                - line.CreditClosingFormerPeriod _
                                + line.DebitClosingFormerPeriod)
                        Else
                            _OptimizedCurrentPeriodValue = CRound(_OptimizedCurrentPeriodValue _
                                - line.CreditTurnoverCurrentPeriod _
                                + line.DebitTurnoverCurrentPeriod _
                                + line.CreditClosingCurrentPeriod _
                                - line.DebitClosingCurrentPeriod)
                            _OptimizedFormerPeriodValue = CRound(_OptimizedFormerPeriodValue _
                                - line.CreditTurnoverFormerPeriod _
                                + line.DebitTurnoverFormerPeriod _
                                + line.CreditClosingFormerPeriod _
                                - line.DebitClosingFormerPeriod)
                        End If

                    End If

                End If
            Next

            If _Type <> FinancialStatementItemType.StatementOfComprehensiveIncome Then
                _OptimizedCurrentPeriodValue = _ActualCurrentPeriodValue
                _OptimizedFormerPeriodValue = _ActualFormerPeriodValue
            End If

            If relatedAccountsList.Count > 0 Then
                _RelatedAccounts = String.Join(", ", relatedAccountsList.ToArray())
            End If

            If _ID = closingSummaryItemId Then

                ' simulate closing of accounts for balance 

                Dim value As Double = source.GetCurrentPeriodClosingSum()

                If _IsCredit Then
                    _OptimizedCurrentPeriodValue = CRound(_OptimizedCurrentPeriodValue - value)
                Else
                    _OptimizedCurrentPeriodValue = CRound(_OptimizedCurrentPeriodValue + value)
                End If

                value = source.GetFormerPeriodClosingSum()

                If _IsCredit Then
                    _OptimizedFormerPeriodValue = CRound(_OptimizedFormerPeriodValue - value)
                Else
                    _OptimizedFormerPeriodValue = CRound(_OptimizedFormerPeriodValue + value)
                End If

            End If

            For Each child As ConsolidatedReportItem In _Children
                child.SetValues(source, closingSummaryItemId)
            Next

        End Sub

        Friend Sub AddBalanceStatementInfoItem(ByVal result As SortedDictionary(Of Integer, ActiveReports.BalanceSheetInfo), ByVal level As Integer)

            If _Type = FinancialStatementItemType.StatementOfComprehensiveIncome _
                OrElse _Type = FinancialStatementItemType.HeaderStatementOfComprehensiveIncome Then Exit Sub

            Try

                If _Type = FinancialStatementItemType.StatementOfFinancialPosition Then
                    result.Add(_VisibleIndex, ActiveReports.BalanceSheetInfo.GetBalanceSheetInfo(Me, level))
                End If

                For Each child As ConsolidatedReportItem In _Children
                    child.AddBalanceStatementInfoItem(result, level + 1)
                Next

            Catch ex As ArgumentException
                If ex.Message.ToLower().Contains("same key") Then
                    Throw New Exception(General_ConsolidatedReportItem_VisibleIndexesNotSet, ex)
                Else
                    Throw
                End If
            End Try

        End Sub

        Friend Sub AddIncomeStatementInfoItem(ByVal result As SortedDictionary(Of Integer, ActiveReports.IncomeStatementInfo), ByVal level As Integer)

            If _Type = FinancialStatementItemType.StatementOfFinancialPosition _
                OrElse _Type = FinancialStatementItemType.HeaderStatementOfFinancialPosition Then Exit Sub

            Try

                If _Type = FinancialStatementItemType.StatementOfComprehensiveIncome Then
                    result.Add(_VisibleIndex, ActiveReports.IncomeStatementInfo.GetIncomeStatementInfo(Me, level))
                End If

                For Each child As ConsolidatedReportItem In _Children
                    child.AddIncomeStatementInfoItem(result, level + 1)
                Next

            Catch ex As Exception
                If ex.Message.ToLower().Contains("same key") Then
                    Throw New Exception(General_ConsolidatedReportItem_VisibleIndexesNotSet, ex)
                Else
                    Throw
                End If
            End Try

        End Sub


        ''' <summary>
        ''' Gets a human readable desciption of all the validation errors.
        ''' Returns <see cref="String.Empty" /> if no errors.
        ''' </summary>
        ''' <returns>A human readable desciption of all the validation errors.
        ''' Returns <see cref="String.Empty" /> if no errors.</returns>
        ''' <remarks></remarks>
        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            Dim result As String = ""
            If Not MyBase.IsValid Then
                result = String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                    vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
            End If
            For Each c As ConsolidatedReportItem In _Children
                result = AddWithNewLine(result, c.GetErrorString(), False)
            Next
            Return result
        End Function

        ''' <summary>
        ''' Gets a human readable desciption of all the validation warnings.
        ''' Returns <see cref="String.Empty" /> if no warnings.
        ''' </summary>
        ''' <returns>A human readable desciption of all the validation warnings.
        ''' Returns <see cref="String.Empty" /> if no warnings.</returns>
        ''' <remarks></remarks>
        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            Dim result As String = ""
            If Me.BrokenRulesCollection.WarningCount > 0 Then
                result = String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                    vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
            End If
            For Each c As ConsolidatedReportItem In _Children
                result = AddWithNewLine(result, c.GetWarningString(), False)
            Next
            Return result
        End Function

        Public Function HasWarnings() As Boolean

            If Me.BrokenRulesCollection.WarningCount > 0 Then Return True

            For Each c As ConsolidatedReportItem In _Children
                If c.HasWarnings Then Return True
            Next

            Return False

        End Function

        Friend Sub CheckRules()
            Me.ValidationRules.CheckRules()
            For Each c As ConsolidatedReportItem In _Children
                c.CheckRules()
            Next
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.General_ConsolidatedReportItem_ToString, _
                Utilities.ConvertLocalizedName(_Type), _Name, _
                IIf(_IsCredit, " (-)", ""))
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("Name"))

            ValidationRules.AddRule(AddressOf VisibleIndexValidation, New Validation.RuleArgs("VisibleIndex"))
            ValidationRules.AddRule(AddressOf DisplayedNumberValidation, New Validation.RuleArgs("DisplayedNumber"))

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property VisibleIndex is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function VisibleIndexValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            If DirectCast(target, ConsolidatedReportItem)._Type _
                <> FinancialStatementItemType.StatementOfComprehensiveIncome AndAlso _
                DirectCast(target, ConsolidatedReportItem)._Type _
                <> FinancialStatementItemType.StatementOfFinancialPosition Then
                Return True
            End If

            Return CommonValidation.IntegerFieldValidation(target, e)

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property DisplayedNumber is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DisplayedNumberValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            If DirectCast(target, ConsolidatedReportItem)._Type _
                <> FinancialStatementItemType.StatementOfComprehensiveIncome AndAlso _
                DirectCast(target, ConsolidatedReportItem)._Type _
                <> FinancialStatementItemType.StatementOfFinancialPosition Then
                Return True
            End If

            Return CommonValidation.StringFieldValidation(target, e)

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new instance of ConsolidatedReportItem with default values set.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Shared Function NewConsolidatedReportItem() As ConsolidatedReportItem
            Return New ConsolidatedReportItem(False)
        End Function

        ''' <summary>
        ''' Gets a new root instance of ConsolidatedReportItem for a new
        ''' <see cref="ConsolidatedReport">ConsolidatedReport</see> instance.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Shared Function NewRootConsolidatedReportItem() As ConsolidatedReportItem
            Return New ConsolidatedReportItem(True)
        End Function

        ''' <summary>
        ''' Gets an existing instance of ConsolidatedReportItem from a database query.
        ''' </summary>
        ''' <param name="index"></param>
        ''' <param name="myData">Database query result data.</param>
        Friend Shared Function GetConsolidatedReportItem(ByVal myData As DataTable, _
            ByRef index As Integer) As ConsolidatedReportItem
            Return New ConsolidatedReportItem(myData, index)
        End Function

        ''' <summary>
        ''' Gets a new instance of ConsolidatedReportItem from xml data.
        ''' </summary>
        ''' <param name="node"><see cref="Xml.XmlNode">XmlNode</see> that contains information about item.</param>
        ''' <param name="level"></param>
        Friend Shared Function GetConsolidatedReportItem(ByVal node As Xml.XmlNode, _
            ByRef level As Integer) As ConsolidatedReportItem
            Return New ConsolidatedReportItem(node, level)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal createBaseStructure As Boolean)
            MarkAsChild()
            Create(createBaseStructure)
        End Sub

        Private Sub New(ByVal myData As DataTable, ByRef index As Integer)
            MarkAsChild()
            Fetch(myData, index)
        End Sub

        Private Sub New(ByVal node As Xml.XmlNode, ByRef level As Integer)
            MarkAsChild()
            Create(node, level)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal createBaseStructure As Boolean)

            _Children = ConsolidatedReportItemList.NewConsolidatedReportItemList

            If createBaseStructure Then
                AddRootStructure()
                CheckRules()
            Else
                Me.ValidationRules.CheckRules()
            End If

        End Sub

        Private Sub AddRootStructure()

            _Name = My.Resources.General_ConsolidatedReportItem_FinancialStatementsRootName
            _Type = FinancialStatementItemType.HeaderGeneral

            Dim newBalanceSheetItem As New ConsolidatedReportItem
            newBalanceSheetItem._Name = My.Resources.General_ConsolidatedReportItem_BalanceStatementRootName
            newBalanceSheetItem._Type = FinancialStatementItemType.HeaderStatementOfFinancialPosition
            newBalanceSheetItem._Children = ConsolidatedReportItemList.NewConsolidatedReportItemList

            Dim newAssetsItem As New ConsolidatedReportItem
            newAssetsItem._IsCredit = False
            newAssetsItem._Name = My.Resources.General_ConsolidatedReportItem_BalanceAssetsStatementRootName
            newAssetsItem._Type = FinancialStatementItemType.StatementOfFinancialPosition
            newAssetsItem._Children = ConsolidatedReportItemList.NewConsolidatedReportItemList

            Dim newCapitalItem As New ConsolidatedReportItem
            newCapitalItem._IsCredit = True
            newCapitalItem._Name = My.Resources.General_ConsolidatedReportItem_BalanceCapitalStatementRootName
            newCapitalItem._Type = FinancialStatementItemType.StatementOfFinancialPosition
            newBalanceSheetItem._Children = ConsolidatedReportItemList.NewConsolidatedReportItemList

            newBalanceSheetItem._Children.Add(newAssetsItem)
            newBalanceSheetItem._Children.Add(newCapitalItem)

            Dim newIncomeStatementItem As New ConsolidatedReportItem
            newIncomeStatementItem._IsCredit = True
            newIncomeStatementItem._Name = My.Resources.General_ConsolidatedReportItem_IncomeStatementRootName
            newIncomeStatementItem._Type = FinancialStatementItemType.HeaderStatementOfComprehensiveIncome
            newIncomeStatementItem._Children = ConsolidatedReportItemList.NewConsolidatedReportItemList

            Dim newIncomeStatementFirstItem As New ConsolidatedReportItem
            newIncomeStatementFirstItem._IsCredit = True
            newIncomeStatementFirstItem._Name = My.Resources.General_ConsolidatedReportItem_IncomeStatementFirstItemRootName
            newIncomeStatementFirstItem._Type = FinancialStatementItemType.StatementOfComprehensiveIncome
            newIncomeStatementFirstItem._Children = ConsolidatedReportItemList.NewConsolidatedReportItemList

            newIncomeStatementItem._Children.Add(newIncomeStatementFirstItem)

            _Children.Add(newBalanceSheetItem)
            _Children.Add(newIncomeStatementItem)

        End Sub

        Private Sub Create(ByVal node As Xml.XmlNode, ByRef level As Integer)

            _Name = node.Item(NameNodeName).InnerText.Trim
            _IsCredit = ConvertDbBoolean(CIntSafe(node.Item(IsCreditNodeName).InnerText.Trim, 0))
            _Type = Utilities.ConvertDatabaseID(Of FinancialStatementItemType) _
                (CIntSafe(node.Item(TypeNodeName).InnerText.Trim, 0))
            If Not node.Item(VisibleIndexNodeName) Is Nothing Then
                _VisibleIndex = CIntSafe(node.Item(VisibleIndexNodeName).InnerText.Trim, 0)
            End If
            If Not node.Item(DisplayedNumberNodeName) Is Nothing Then
                _DisplayedNumber = node.Item(DisplayedNumberNodeName).InnerText.Trim
            End If

            _Children = ConsolidatedReportItemList.NewConsolidatedReportItemList( _
                node.Item(ChildrenNodeName).ChildNodes, level)

            ValidationRules.CheckRules()

        End Sub


        Private Sub Fetch(ByVal myData As DataTable, ByRef index As Integer)

            If myData.Rows.Count < 1 Then
                Create(True)
                Exit Sub
            End If

            _ID = CIntSafe(myData.Rows(index).Item(0), 0)
            _Name = CStrSafe(myData.Rows(index).Item(1))
            _Type = Utilities.ConvertDatabaseID(Of FinancialStatementItemType) _
                (CIntSafe(myData.Rows(index).Item(3), 0))
            _IsCredit = ConvertDbBoolean(CIntSafe(myData.Rows(index).Item(4), 0))
            _HasAccountsAssigned = ConvertDbBoolean(CIntSafe(myData.Rows(index).Item(5), 0))
            _Left = CIntSafe(myData.Rows(index).Item(6), 0)
            _Right = CIntSafe(myData.Rows(index).Item(7), 0)
            _VisibleIndex = CIntSafe(myData.Rows(index).Item(8), 0)
            _DisplayedNumber = CStrSafe(myData.Rows(index).Item(9))
            _Children = ConsolidatedReportItemList.GetConsolidatedReportItemList( _
                myData, index, CIntSafe(myData.Rows(index).Item(2), 0))

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Friend Sub SaveRootItem()

            If _Type <> FinancialStatementItemType.HeaderGeneral Then
                Throw New InvalidOperationException( _
                    My.Resources.General_ConsolidatedReportItem_InvalidSaveOperation)
            End If

            UpdateNestedSetIndexes(1)

            Me.Update()

        End Sub

        Private Sub UpdateNestedSetIndexes(ByRef index As Integer)

            Me.Left = index

            For Each i As ConsolidatedReportItem In _Children
                index += 1
                i.UpdateNestedSetIndexes(index)
            Next

            index += 1

            Me.Right = index

        End Sub

        Friend Sub Update()

            Dim myComm As SQLCommand

            If IsNew OrElse MyBase.IsDirty Then

                If IsNew Then
                    myComm = New SQLCommand("InsertConsolidatedReportItem")
                Else
                    myComm = New SQLCommand("UpdateConsolidatedReportItem")
                    myComm.AddParam("?AA", _ID)
                End If
                myComm.AddParam("?AB", _Name.Trim)
                myComm.AddParam("?AC", ConvertDbBoolean(_IsCredit))
                myComm.AddParam("?AD", Utilities.ConvertDatabaseID(_Type))
                myComm.AddParam("?AE", _Left)
                myComm.AddParam("?AF", _Right)
                myComm.AddParam("?AG", _VisibleIndex)
                myComm.AddParam("?AH", _DisplayedNumber.Trim)

                myComm.Execute()

                If IsNew Then _ID = Convert.ToInt32(myComm.LastInsertID)

            End If

            If Not IsNew AndAlso _Children.HasNewChildren() Then

                myComm = New SQLCommand("RemoveAccountsReferences")
                myComm.AddParam("?CD", _ID)
                myComm.Execute()

            End If

            _Children.Update()

            MarkOld()

        End Sub


        Friend Sub DeleteSelf()

            _Children.DeleteSelf()

            If IsNew Then Exit Sub

            Dim myComm As New SQLCommand("DeleteConsolidatedReportItem")
            myComm.AddParam("?AA", _ID)

            myComm.Execute()

            myComm = New SQLCommand("RemoveAccountsReferences")
            myComm.AddParam("?CD", _ID)
            myComm.Execute()

            myComm.Execute()

            MarkNew()

        End Sub


        Friend Sub WriteXmlNode(ByRef writer As System.Xml.XmlWriter)

            writer.WriteStartElement(ItemNodeName)

            writer.WriteStartElement(NameNodeName)
            writer.WriteString(_Name.Trim)
            writer.WriteEndElement()

            writer.WriteStartElement(IsCreditNodeName)
            writer.WriteString(ConvertDbBoolean(_IsCredit).ToString)
            writer.WriteEndElement()

            writer.WriteStartElement(TypeNodeName)
            writer.WriteString(Utilities.ConvertDatabaseID(_Type).ToString)
            writer.WriteEndElement()

            writer.WriteStartElement(VisibleIndexNodeName)
            writer.WriteString(_VisibleIndex.ToString)
            writer.WriteEndElement()

            writer.WriteStartElement(DisplayedNumberNodeName)
            writer.WriteString(_DisplayedNumber.Trim)
            writer.WriteEndElement()

            writer.WriteStartElement(ChildrenNodeName)
            For Each c As ConsolidatedReportItem In _Children
                c.WriteXmlNode(writer)
            Next
            writer.WriteEndElement()

            writer.WriteEndElement()

            MarkNew()

        End Sub

#End Region

    End Class

End Namespace