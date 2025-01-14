﻿Imports ApskaitaObjects.My.Resources
Imports Csla.Validation

Namespace Goods

    ''' <summary>
    ''' Represents a complex goods price cut operation (when the balance value 
    ''' is reduced to the market value or restored to the acquisition value),
    ''' that is composed of a collection of <see cref="GoodsOperationPriceCut">
    ''' simple goods price cut operations</see>, i.e. sets a price cut for multiple goods.
    ''' </summary>
    ''' <remarks>See methodology for BAS No 9 ""Stores"" para. 24 - 33 for details.
    ''' Encapsulates a <see cref="General.JournalEntry">JournalEntry</see>
    ''' of type <see cref="DocumentType.GoodsRevalue">DocumentType.GoodsRevalue</see>.
    ''' Values are stored using <see cref="ComplexOperationPersistenceObject">ComplexOperationPersistenceObject</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class GoodsComplexOperationPriceCut
        Inherits BusinessBase(Of GoodsComplexOperationPriceCut)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _JournalEntryID As Integer = 0
        Private _OperationalLimit As ComplexChronologicValidator = Nothing
        Private _DocumentNumber As String = ""
        Private _Date As Date = Today
        Private _Description As String = ""
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private WithEvents _Items As GoodsPriceCutItemList

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _ItemsSortedList As Csla.SortedBindingList(Of GoodsOperationPriceCut) = Nothing


        ''' <summary>
        ''' Gets an ID of the operation that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.ID">ComplexOperationPersistenceObject.ID</see>.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.JournalEntry.ID">ID of the journal entry</see>
        ''' that is encapsulated by the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.JournalEntryID">ComplexOperationPersistenceObject.JournalEntryID</see>.</remarks>
        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the operation was inserted into the database.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.InsertDate">ComplexOperationPersistenceObject.InsertDate</see>.</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the operation was last updated.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.UpdateDate">ComplexOperationPersistenceObject.UpdateDate</see>.</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="IChronologicValidator">IChronologicValidator</see> object 
        ''' that contains business restraints on updating the operation data.
        ''' </summary>
        ''' <remarks>A <see cref="ComplexChronologicValidator">ComplexChronologicValidator</see> 
        ''' is used to validate a complex goods operation chronological business rules.</remarks>
        Public ReadOnly Property OperationalLimit() As ComplexChronologicValidator
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationalLimit
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a document number of the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.DocNo">ComplexOperationPersistenceObject.DocNo</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 30)> _
        Public Property DocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _DocumentNumber.Trim <> value.Trim Then
                    _DocumentNumber = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a date of the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.OperationDate">ComplexOperationPersistenceObject.OperationDate</see>.</remarks>
        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
                    _Items.SetParentDate(_Date)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a content (description) of the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.Content">ComplexOperationPersistenceObject.Content</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
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

        ''' <summary>
        ''' Gets a collection of child goods price cut operations that the
        ''' complex operation is composed of.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Items() As GoodsPriceCutItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Items
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable view of the collection of child goods price cut operations 
        ''' that the complex operation is composed of.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a datagridview</remarks>
        Public ReadOnly Property ItemsSorted() As Csla.SortedBindingList(Of GoodsOperationPriceCut)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _ItemsSortedList Is Nothing Then
                    _ItemsSortedList = New Csla.SortedBindingList(Of GoodsOperationPriceCut)(_Items)
                End If
                Return _ItemsSortedList
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_DocumentNumber.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Description.Trim) _
                    OrElse _Items.Count > 0)
            End Get
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _Items.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _Items.IsValid
            End Get
        End Property



        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then
                result = AddWithNewLine(result, _
                    Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error), False)
            End If
            If Not _Items.IsValid Then
                result = AddWithNewLine(result, _Items.GetAllBrokenRules(), False)
            End If
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If Not MyBase.BrokenRulesCollection.WarningCount > 0 Then
                result = AddWithNewLine(result, _
                    Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning), False)
            End If
            If _Items.HasWarnings() Then
                result = AddWithNewLine(result, _Items.GetAllWarnings(), False)
            End If
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return (MyBase.BrokenRulesCollection.WarningCount > 0 OrElse _Items.HasWarnings())
        End Function


        ''' <summary>
        ''' Sets the same <see cref="GoodsOperationPriceCut.AccountPriceCutCosts">
        ''' price cut costs account</see> for all the items.
        ''' </summary>
        ''' <param name="costsAccount"></param>
        ''' <remarks></remarks>
        Public Sub SetCommonAccountPriceCutCosts(ByVal costsAccount As Long)
            _Items.SetCommonAccountPriceCutCosts(costsAccount)
        End Sub

        ''' <summary>
        ''' Adds items in the list to the current collection.
        ''' </summary>
        ''' <param name="list"></param>
        ''' <remarks>Invoke <see cref="GoodsPriceCutItemList.NewGoodsPriceCutItemList">GoodsPriceCutItemList.NewGoodsPriceCutItemList</see>
        ''' to get a list of new operations by goods ID's.</remarks>
        Public Sub AddRange(ByVal list As GoodsPriceCutItemList)

            If Not _OperationalLimit.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsComplexOperationPriceCut_FinancialDataCannotChange, _
                    vbCrLf, _OperationalLimit.FinancialDataCanChangeExplanation))
            End If

            list.SetParentDate(_Date)

            _Items.AddRange(list)

            For Each i As GoodsOperationPriceCut In list
                _OperationalLimit.MergeNewValidationItem(i.OperationLimitations)
            Next

        End Sub

        ''' <summary>
        ''' Sets new initial amount and value of the goods in the warehouses.
        ''' </summary>
        ''' <param name="values">a query object containing information about amount 
        ''' and value of the goods in the warehouses at a certain date.</param>
        ''' <param name="warnings">an out parameter that returns a description of 
        ''' non critical errors encountered while seting the data</param>
        ''' <remarks></remarks>
        Public Sub RefreshValuesInWarehouse(ByVal values As GoodsPriceInWarehouseItemList, _
            ByRef warnings As String)
            If Not _OperationalLimit.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsComplexOperationPriceCut_FinancialDataCannotChange, _
                    vbCrLf, _OperationalLimit.FinancialDataCanChangeExplanation))
            End If
            warnings = ""
            _Items.RefreshValuesInWarehouse(values, warnings)
        End Sub

        ''' <summary>
        ''' Sets new initial amount and value of the goods in the warehouses.
        ''' </summary>
        ''' <param name="value">a query object containing information about amount 
        ''' and value of the goods in the warehouses at a certain date.</param>
        ''' <remarks></remarks>
        Public Sub RefreshValuesInWarehouse(ByVal value As GoodsPriceInWarehouseItem)
            If Not _OperationalLimit.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsComplexOperationPriceCut_FinancialDataCannotChange, _
                    vbCrLf, _OperationalLimit.FinancialDataCanChangeExplanation))
            End If
            _Items.RefreshValuesInWarehouse(value)
        End Sub

        ''' <summary>
        ''' Gets an array of param objects for a <see cref="GoodsPriceInWarehouseItemList">query object</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetGoodsPriceInWarehouseParams() As GoodsPriceInWarehouseParam()
            Return _Items.GetGoodsPriceInWarehouseParams
        End Function


        Private Sub Items_Changed(ByVal sender As Object, _
            ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _Items.ListChanged

            If e.ListChangedType = ComponentModel.ListChangedType.ItemAdded Then

                Try
                    _OperationalLimit.MergeNewValidationItem(_Items(e.NewIndex).OperationLimitations)
                    PropertyHasChanged("OperationalLimit")
                Catch ex As Exception
                End Try

            ElseIf e.ListChangedType = ComponentModel.ListChangedType.ItemDeleted Then

                _OperationalLimit = ComplexChronologicValidator.GetComplexChronologicValidator( _
                    _OperationalLimit, _Items.GetLimitations())

                PropertyHasChanged("OperationalLimit")

            End If

        End Sub

        ''' <summary>
        ''' Helper method. Takes care of child lists loosing their handlers.
        ''' </summary>
        Protected Overrides Function GetClone() As Object
            Dim result As GoodsComplexOperationPriceCut = DirectCast(MyBase.GetClone(), GoodsComplexOperationPriceCut)
            result.RestoreChildListsHandles()
            Return result
        End Function

        Protected Overrides Sub OnDeserialized(ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.OnDeserialized(context)
            RestoreChildListsHandles()
        End Sub

        Protected Overrides Sub UndoChangesComplete()
            MyBase.UndoChangesComplete()
            RestoreChildListsHandles()
        End Sub

        ''' <summary>
        ''' Helper method. Takes care of ReportItems loosing its handler. See GetClone method.
        ''' </summary>
        Friend Sub RestoreChildListsHandles()
            Try
                RemoveHandler _Items.ListChanged, AddressOf Items_Changed
            Catch ex As Exception
            End Try
            AddHandler _Items.ListChanged, AddressOf Items_Changed
        End Sub


        Public Overrides Function Save() As GoodsComplexOperationPriceCut
            Return MyBase.Save
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Goods_GoodsComplexOperationPriceCut_ToString, _
                _Date.ToString("yyyy-MM-dd"), _DocumentNumber, _Description, _ID.ToString)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New RuleArgs("DocumentNumber"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New RuleArgs("Description"))

            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "OperationalLimit"))
            ValidationRules.AddDependantProperty("OperationalLimit", "Date", False)

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Goods.GoodsOperationPriceCut2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationPriceCut1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationPriceCut2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationPriceCut3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationPriceCut3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new GoodsComplexOperationPriceCut instance.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsComplexOperationPriceCut() As GoodsComplexOperationPriceCut

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            Dim result As New GoodsComplexOperationPriceCut
            result.Create()
            Return result

        End Function

        ''' <summary>
        ''' Gets an existing GoodsComplexOperationPriceCut instance from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID of the operation</see> to fetch</param>
        ''' <remarks></remarks>
        Public Shared Function GetGoodsComplexOperationPriceCut(ByVal id As Integer) As GoodsComplexOperationPriceCut
            Return DataPortal.Fetch(Of GoodsComplexOperationPriceCut)(New Criteria(id))
        End Function

        ''' <summary>
        ''' Deletes an existing GoodsComplexOperationPriceCut instance from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID of the operation</see> to delete</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteGoodsComplexOperationPriceCut(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ID As Integer
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public Sub New(ByVal nID As Integer)
                _ID = nID
            End Sub
        End Class


        Private Sub Create()

            _Items = GoodsPriceCutItemList.NewGoodsPriceCutItemList

            Dim baseValidator As SimpleChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator(ConvertLocalizedName(GoodsComplexOperationType.BulkPriceCut), Nothing)

            _OperationalLimit = ComplexChronologicValidator.NewComplexChronologicValidator( _
                baseValidator.CurrentOperationName, baseValidator, Nothing, Nothing)

            ValidationRules.CheckRules()

        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim obj As ComplexOperationPersistenceObject = ComplexOperationPersistenceObject. _
                GetComplexOperationPersistenceObject(criteria.ID, _
                GoodsComplexOperationType.BulkPriceCut, True)

            _ID = obj.ID
            _JournalEntryID = obj.JournalEntryID
            _DocumentNumber = obj.DocNo
            _Date = obj.OperationDate
            _Description = obj.Content
            _InsertDate = obj.InsertDate
            _UpdateDate = obj.UpdateDate

            Dim baseValidator As SimpleChronologicValidator = SimpleChronologicValidator. _
                GetSimpleChronologicValidator(_ID, _Date, Utilities.ConvertLocalizedName( _
                GoodsComplexOperationType.BulkPriceCut), Nothing)

            Dim myComm As New SQLCommand("FetchGoodsComplexOperationPriceCut")
            myComm.AddParam("?CD", criteria.ID)

            Using myData As DataTable = myComm.Fetch
                Using limitationsDataSource As DataTable = OperationalLimitList. _
                    GetDataSourceForComplexOperation(_ID, _Date)
                    _Items = GoodsPriceCutItemList.GetGoodsPriceCutItemList(myData, _
                        limitationsDataSource, baseValidator)
                End Using
            End Using

            _OperationalLimit = ComplexChronologicValidator.GetComplexChronologicValidator( _
                _ID, _Date, baseValidator.CurrentOperationName, baseValidator, _
                Nothing, _Items.GetLimitations())

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            CheckIfCanUpdate()
            DoSave()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            CheckIfCanUpdate()
            DoSave()

        End Sub

        Private Sub DoSave()

            Dim obj As ComplexOperationPersistenceObject = GetPersistenceObj()

            Dim entry As General.JournalEntry = GetJournalEntry()

            Using transaction As New SqlTransaction

                Try

                    If Not entry Is Nothing Then
                        entry = entry.SaveChild()
                        _JournalEntryID = entry.ID
                    ElseIf _JournalEntryID > 0 Then
                        IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted( _
                            _JournalEntryID, DocumentType.GoodsRevalue)
                        General.JournalEntry.DeleteJournalEntryChild(_JournalEntryID)
                        _JournalEntryID = 0
                    Else
                        _JournalEntryID = 0
                    End If
                    obj.JournalEntryID = _JournalEntryID

                    obj = obj.SaveChild(_OperationalLimit.FinancialDataCanChange, True, True)

                    If IsNew Then
                        _ID = obj.ID
                        _InsertDate = obj.InsertDate
                    End If
                    _UpdateDate = obj.UpdateDate

                    _Items.Update(Me)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub

        Private Function GetPersistenceObj() As ComplexOperationPersistenceObject

            Dim obj As ComplexOperationPersistenceObject
            If IsNew Then
                obj = ComplexOperationPersistenceObject.NewComplexOperationPersistenceObject( _
                    GoodsComplexOperationType.BulkPriceCut, 0)
            Else
                obj = ComplexOperationPersistenceObject.GetComplexOperationPersistenceObject( _
                    _ID, GoodsComplexOperationType.BulkPriceCut)
                If obj.UpdateDate <> _UpdateDate Then Throw New Exception( _
                    My.Resources.Common_UpdateDateHasChanged)
            End If

            obj.AccountOperation = 0
            obj.Warehouse = Nothing
            obj.SecondaryWarehouse = Nothing
            obj.Content = _Description
            obj.DocNo = _DocumentNumber
            obj.JournalEntryID = _JournalEntryID
            obj.OperationDate = _Date

            Return obj

        End Function


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Protected Overrides Sub DataPortal_Delete(ByVal criteria As Object)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            Dim operationToDelete As GoodsComplexOperationPriceCut = _
                New GoodsComplexOperationPriceCut
            operationToDelete.DataPortal_Fetch(DirectCast(criteria, Criteria))

            If Not operationToDelete._OperationalLimit.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsComplexOperationPriceCut_InvalidDelete, _
                    vbCrLf, operationToDelete._OperationalLimit.FinancialDataCanChangeExplanation))
            End If

            If operationToDelete.JournalEntryID > 0 Then
                IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted( _
                    operationToDelete.JournalEntryID, DocumentType.GoodsRevalue)
            End If

            Using transaction As New SqlTransaction

                Try

                    ComplexOperationPersistenceObject.Delete(operationToDelete.ID, _
                        True, False, False)

                    If operationToDelete.JournalEntryID > 0 Then
                        General.JournalEntry.DeleteJournalEntryChild(operationToDelete.JournalEntryID)
                    End If

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

        End Sub


        Private Function GetJournalEntry() As General.JournalEntry

            Dim result As General.JournalEntry
            If IsNew OrElse Not _JournalEntryID > 0 Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.GoodsRevalue)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_JournalEntryID, DocumentType.GoodsRevalue)
            End If

            result.Content = _Description
            result.Date = _Date
            result.DocNumber = _DocumentNumber

            Dim fullBookEntryList As BookEntryInternalList = _Items.GetTotalBookEntryList()
            fullBookEntryList.Aggregate()

            ' in theory price cut total costs can sum to zero 
            ' (if all the goods accounts match and some goods have price cut 
            ' while others price restored)
            If fullBookEntryList.Count < 1 Then Return Nothing

            If _OperationalLimit.FinancialDataCanChange Then

                result.DebetList.Clear()
                result.CreditList.Clear()

                result.DebetList.LoadBookEntryListFromInternalList(fullBookEntryList, False, False)
                result.CreditList.LoadBookEntryListFromInternalList(fullBookEntryList, False, False)

            End If

            If Not result.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_FailedToCreateJournalEntry, _
                    vbCrLf, result.ToString, vbCrLf, result.GetAllBrokenRules))
            End If

            Return result

        End Function

        Private Sub CheckIfCanUpdate()

            If Not _Items.Count > 0 Then
                Throw New Exception(Goods_GoodsComplexOperationPriceCut_ListEmpty)
            End If

            If IsNew Then
                _Items.CheckIfCanUpdate(Nothing, Me)
            Else
                Using myData As DataTable = OperationalLimitList. _
                    GetDataSourceForComplexOperation(_ID, _OperationalLimit.CurrentOperationDate)
                    _Items.CheckIfCanUpdate(myData, Me)
                End Using
            End If

            Me.ValidationRules.CheckRules()
            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

        End Sub

#End Region

    End Class

End Namespace