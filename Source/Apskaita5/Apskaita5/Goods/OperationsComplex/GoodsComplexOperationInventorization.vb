﻿Imports ApskaitaObjects.My.Resources
Imports Csla.Validation

Namespace Goods

    ''' <summary>
    ''' Represents a complex goods inventory operation, that is composed of 
    ''' a collection of <see cref="GoodsInventorizationItem">goods inventory 
    ''' operations (per goods type)</see> in a warehouse.
    ''' </summary>
    ''' <remarks>See methodology for BAS No 9 ""Stores"" para. 40 for details.
    ''' Encapsulates a <see cref="General.JournalEntry">JournalEntry</see>
    ''' of type <see cref="DocumentType.GoodsInventorization">DocumentType.GoodsInventorization</see>.
    ''' Values are stored using <see cref="ComplexOperationPersistenceObject">ComplexOperationPersistenceObject</see>.</remarks>    
    <Serializable()> _
    Public NotInheritable Class GoodsComplexOperationInventorization
        Inherits BusinessBase(Of GoodsComplexOperationInventorization)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _JournalEntryID As Integer = 0
        Private _OperationalLimit As ComplexChronologicValidator = Nothing
        Private _Date As Date = Today
        Private _DocumentNumber As String = ""
        Private _Content As String = ""
        Private _WarehouseID As Integer = 0
        Private _WarehouseName As String = ""
        Private _WarehouseAccount As Long = 0
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private WithEvents _Items As GoodsInventorizationItemList


        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _ItemsSortedList As Csla.SortedBindingList(Of GoodsInventorizationItem) = Nothing


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
        ''' Gets a date of the operation.
        ''' </summary>
        ''' <remarks>Value is set when the operation is created and cannot be changed 
        ''' afterwards (because all the inventorization data is entirely period dependent).
        ''' Corresponds to <see cref="ComplexOperationPersistenceObject.OperationDate">ComplexOperationPersistenceObject.OperationDate</see>.</remarks>
        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="Goods.Warehouse.ID">ID of the warehouse</see> that the goods 
        ''' are inventoried in.
        ''' </summary>
        ''' <remarks>Value is set when the operation is created and cannot be changed 
        ''' afterwards (because all the inventorization data is entirely warehouse dependent).
        ''' Corresponds to <see cref="ComplexOperationPersistenceObject.Warehouse">ComplexOperationPersistenceObject.Warehouse</see>.</remarks>
        Public ReadOnly Property WarehouseID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WarehouseID
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="Goods.Warehouse.Name">name of the warehouse</see> 
        ''' that the goods are inventoried in.
        ''' </summary>
        ''' <remarks>Value is set when the operation is created and cannot be changed 
        ''' afterwards (because all the inventorization data is entirely warehouse dependent).
        ''' Corresponds to <see cref="ComplexOperationPersistenceObject.Warehouse">ComplexOperationPersistenceObject.Warehouse</see>.</remarks>
        Public ReadOnly Property WarehouseName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WarehouseName.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="Goods.Warehouse.WarehouseAccount">account of the warehouse</see> 
        ''' that the goods are inventoried in.
        ''' </summary>
        ''' <remarks>Value is set when the operation is created and cannot be changed 
        ''' afterwards (because all the inventorization data is entirely warehouse dependent).
        ''' Corresponds to <see cref="ComplexOperationPersistenceObject.Warehouse">ComplexOperationPersistenceObject.Warehouse</see>.</remarks>
        Public ReadOnly Property WarehouseAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WarehouseAccount
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
        ''' Gets or sets a content (description) of the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="ComplexOperationPersistenceObject.Content">ComplexOperationPersistenceObject.Content</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 255)> _
        Public Property Content() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Content.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _Content.Trim <> value.Trim Then
                    _Content = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a collection of child goods inventory operations that the
        ''' complex operation is composed of.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Items() As GoodsInventorizationItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Items
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable view of the collection of child goods inventory operations 
        ''' that the complex operation is composed of.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a datagridview</remarks>
        Public ReadOnly Property ItemsSorted() As Csla.SortedBindingList(Of GoodsInventorizationItem)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _ItemsSortedList Is Nothing Then
                    _ItemsSortedList = New Csla.SortedBindingList(Of GoodsInventorizationItem)(_Items)
                End If
                Return _ItemsSortedList
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_DocumentNumber.Trim) _
                    OrElse Not String.IsNullOrEmpty(_Content.Trim))
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


        Public Overrides Function Save() As GoodsComplexOperationInventorization
            Return MyBase.Save
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(Goods_GoodsComplexOperationInventorization_ToString, _
                _Date.ToString("yyyy-MM-dd"), _DocumentNumber, _ID.ToString)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New RuleArgs("DocumentNumber"))
            ValidationRules.AddRule(AddressOf CommonValidation.StringFieldValidation, _
                New RuleArgs("Content"))
            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "OperationalLimit"))

        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Goods.GoodsOperationInventorization2")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationInventorization1")
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationInventorization2")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationInventorization3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationInventorization3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new GoodsComplexOperationInventorization instance.
        ''' </summary>
        ''' <param name="operationWarehouseID">an <see cref="Goods.Warehouse.ID">
        ''' ID of the warehouse</see> to inventory the goods in</param>
        ''' <param name="operationDate">a date to inventory the goods at</param>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsComplexOperationInventorization(ByVal operationDate As Date, _
            ByVal operationWarehouseID As Integer) As GoodsComplexOperationInventorization
            Return DataPortal.Create(Of GoodsComplexOperationInventorization) _
                (New Criteria(operationDate, operationWarehouseID))
        End Function

        ''' <summary>
        ''' Gets an existing GoodsComplexOperationInventorization instance from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID of the operation</see> to fetch</param>
        ''' <remarks></remarks>
        Public Shared Function GetGoodsComplexOperationInventorization(ByVal id As Integer) As GoodsComplexOperationInventorization
            Return DataPortal.Fetch(Of GoodsComplexOperationInventorization)(New Criteria(id))
        End Function

        ''' <summary>
        ''' Deletes an existing GoodsComplexOperationInventorization instance from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID of the operation</see> to delete</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteGoodsComplexOperationInventorization(ByVal id As Integer)
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
            Private _OperationDate As Date
            Private _OperationWarehouseID As Integer
            Public ReadOnly Property ID() As Integer
                Get
                    Return _ID
                End Get
            End Property
            Public ReadOnly Property OperationDate() As Date
                Get
                    Return _OperationDate
                End Get
            End Property
            Public ReadOnly Property OperationWarehouseID() As Integer
                Get
                    Return _OperationWarehouseID
                End Get
            End Property
            Public Sub New(ByVal nID As Integer)
                _ID = nID
                _OperationDate = Today
                _OperationWarehouseID = 0
            End Sub
            Public Sub New(ByVal nOperationDate As Date, ByVal nWarehouseID As Integer)
                _ID = 0
                _OperationDate = nOperationDate
                _OperationWarehouseID = nWarehouseID
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            If criteria.OperationWarehouseID < 1 Then
                Throw New Exception(Goods_GoodsComplexOperationInventorization_WarehouseNull)
            End If

            Dim lastInventorizationDate As Date = GetPreviousInventorizationDate( _
                0, criteria.OperationWarehouseID)

            If lastInventorizationDate.Date >= criteria.OperationDate.Date Then _
                Throw New Exception(String.Format(Goods_GoodsComplexOperationInventorization_InvalidDateForNewOperation, _
                lastInventorizationDate.ToString("yyyy-MM-dd")))

            _Date = criteria.OperationDate

            Dim myComm As New SQLCommand("CreateGoodsComplexOperationInventorizationItems")
            myComm.AddParam("?WD", criteria.OperationWarehouseID)
            If lastInventorizationDate = Date.MinValue Then
                myComm.AddParam("?DF", New Date(1970, 1, 1))
            Else
                myComm.AddParam("?DF", lastInventorizationDate.Date)
            End If
            myComm.AddParam("?DT", criteria.OperationDate.Date)

            Using myData As DataTable = myComm.Fetch

                Using limitationsDataSource As DataTable = OperationalLimitList. _
                    GetDataSourceForNewInventorization(criteria.OperationWarehouseID)

                    Dim consignmentDictionary As Dictionary(Of Integer, ConsignmentPersistenceObjectList) _
                        = ConsignmentPersistenceObjectList.GetConsignmentPersistenceObjectList( _
                        criteria.OperationWarehouseID, -1)

                    _Items = GoodsInventorizationItemList.NewGoodsInventorizationItemList( _
                        myData, consignmentDictionary, limitationsDataSource, criteria.OperationDate, _
                        criteria.OperationWarehouseID)

                End Using

            End Using

            Dim baseValidator As SimpleChronologicValidator = SimpleChronologicValidator. _
                NewSimpleChronologicValidator(ConvertLocalizedName(GoodsOperationType.Inventorization), Nothing)

            _OperationalLimit = ComplexChronologicValidator.GetComplexChronologicValidator( _
                 _ID, _Date, baseValidator.CurrentOperationName, baseValidator, _
                 Nothing, _Items.GetLimitations())

            ValidationRules.CheckRules()

        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim obj As ComplexOperationPersistenceObject = ComplexOperationPersistenceObject. _
                GetComplexOperationPersistenceObject(criteria.ID, GoodsComplexOperationType.Inventorization, True)

            _ID = obj.ID
            _JournalEntryID = obj.JournalEntryID
            _Date = obj.OperationDate
            _DocumentNumber = obj.DocNo
            _Content = obj.Content
            _WarehouseID = obj.WarehouseID
            _WarehouseName = obj.Warehouse.Name
            _WarehouseAccount = obj.Warehouse.WarehouseAccount
            _InsertDate = obj.InsertDate
            _UpdateDate = obj.UpdateDate

            Dim lastInventorizationDate As Date = GetPreviousInventorizationDate( _
                _ID, _WarehouseID)

            Dim myComm As New SQLCommand("FetchGoodsComplexOperationInventorizationItems")
            myComm.AddParam("?WD", _WarehouseID)
            If lastInventorizationDate = Date.MinValue Then
                myComm.AddParam("?DF", New Date(1970, 1, 1))
            Else
                myComm.AddParam("?DF", lastInventorizationDate.Date)
            End If
            myComm.AddParam("?DT", _Date.Date)
            myComm.AddParam("?CD", _ID)

            Using myData As DataTable = myComm.Fetch

                Using limitationsDataSource As DataTable = OperationalLimitList. _
                    GetDataSourceForComplexOperation(_ID, _Date)

                    Dim consignmentDictionary As Dictionary(Of Integer, ConsignmentPersistenceObjectList) _
                        = ConsignmentPersistenceObjectList.GetConsignmentPersistenceObjectList( _
                        _WarehouseID, _ID)

                    _Items = GoodsInventorizationItemList.GetGoodsInventorizationItemList(myData, _
                        consignmentDictionary, limitationsDataSource, _Date, _WarehouseID)

                End Using

            End Using

            Dim baseValidator As IChronologicValidator
            If _JournalEntryID > 0 Then
                baseValidator = SimpleChronologicValidator.GetSimpleChronologicValidator( _
                    _JournalEntryID, Nothing)
            Else
                baseValidator = EmptyChronologicValidator.NewEmptyChronologicValidator( _
                    Utilities.ConvertLocalizedName(GoodsOperationType.Inventorization), Nothing)
            End If

            _OperationalLimit = ComplexChronologicValidator.GetComplexChronologicValidator( _
                 _ID, _Date, baseValidator.CurrentOperationName, baseValidator, _
                 Nothing, _Items.GetLimitations())

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            _Items.PrepareOperationConsignments(Me)

            CheckIfCanUpdate()

            DoSave()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            _Items.PrepareOperationConsignments(Me)

            CheckIfCanUpdate()

            DoSave()

        End Sub

        Private Sub DoSave()

            Dim obj As ComplexOperationPersistenceObject = GetPersistenceObj()

            Dim entry As General.JournalEntry = GetJournalEntry()

            Using transaction As New SqlTransaction

                Try

                    If Not entry Is Nothing Then
                        entry = entry.SaveChild
                        _JournalEntryID = entry.ID
                        obj.JournalEntryID = _JournalEntryID
                    ElseIf entry Is Nothing AndAlso _JournalEntryID > 0 Then
                        General.JournalEntry.DeleteJournalEntryChild(_JournalEntryID)
                        _JournalEntryID = 0
                        obj.JournalEntryID = 0
                    End If

                    obj = obj.SaveChild(_OperationalLimit.FinancialDataCanChange, _
                        _OperationalLimit.FinancialDataCanChange, False)

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
                    GoodsComplexOperationType.Inventorization, 0)
            Else
                obj = ComplexOperationPersistenceObject.GetComplexOperationPersistenceObject( _
                    _ID, GoodsComplexOperationType.Inventorization)
                If obj.UpdateDate <> _UpdateDate Then Throw New Exception( _
                    My.Resources.Common_UpdateDateHasChanged)
            End If

            obj.AccountOperation = 0
            obj.WarehouseID = _WarehouseID
            obj.SecondaryWarehouse = Nothing
            obj.Content = _Content
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

            Dim operationToDelete As GoodsComplexOperationInventorization _
                = New GoodsComplexOperationInventorization
            operationToDelete.DataPortal_Fetch(DirectCast(criteria, Criteria))

            If Not operationToDelete._OperationalLimit.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsComplexOperationInventorization_DeleteInvalid, _
                    vbCrLf, operationToDelete._OperationalLimit.FinancialDataCanChangeExplanation))
            End If

            If operationToDelete.JournalEntryID > 0 Then
                IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted( _
                    operationToDelete.JournalEntryID, DocumentType.GoodsInventorization)
            End If

            Using transaction As New SqlTransaction

                Try

                    ComplexOperationPersistenceObject.Delete(operationToDelete.ID, _
                        True, True, True)

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


        Private Function GetPreviousInventorizationDate(ByVal operationID As Integer, _
            ByVal operationWarehouseID As Integer) As Date

            Dim myComm As New SQLCommand("FetchLastInventorizationDate")
            myComm.AddParam("?WD", operationWarehouseID)
            myComm.AddParam("?CD", operationID)

            Dim result As Date = Date.MinValue

            Using myData As DataTable = myComm.Fetch

                If Not myData.Rows.Count > 0 Then
                    Throw New Exception(String.Format(Goods_GoodsComplexOperationInventorization_WarehouseNotFound, _
                        operationWarehouseID.ToString))
                End If

                _WarehouseID = CIntSafe(myData.Rows(0).Item(0), 0)
                _WarehouseName = CStrSafe(myData.Rows(0).Item(1))
                _WarehouseAccount = CLongSafe(myData.Rows(0).Item(2), 0)

                result = CDateSafe(myData.Rows(0).Item(3), Date.MinValue)

            End Using

            Return result

        End Function

        Private Function GetJournalEntry() As General.JournalEntry

            Dim result As General.JournalEntry
            If IsNew OrElse Not _JournalEntryID > 0 Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.GoodsInventorization)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_JournalEntryID, DocumentType.GoodsInventorization)
            End If

            result.Content = _Content
            result.Date = _Date
            result.DocNumber = _DocumentNumber

            Dim fullBookEntryList As BookEntryInternalList = _Items.GetTotalBookEntryList(Me)

            fullBookEntryList.Aggregate()

            If Not fullBookEntryList.Count > 0 Then Return Nothing

            If _OperationalLimit.BaseValidator.FinancialDataCanChange Then

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
                Throw New Exception(Goods_GoodsComplexOperationInventorization_ListEmpty)
            End If

            If IsNew Then
                _Items.CheckIfCanUpdate(Nothing)
            Else
                Using myData As DataTable = OperationalLimitList.GetDataSourceForComplexOperation(_ID, _Date)
                    _Items.CheckIfCanUpdate(myData)
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