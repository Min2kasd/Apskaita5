﻿Imports ApskaitaObjects.My.Resources
Imports Csla.Validation

Namespace Goods

    ''' <summary>
    ''' Represents a simple goods acquisition operation, registers acquisition 
    ''' of a single goods <see cref="ConsignmentPersistenceObject">consignment</see>.
    ''' </summary>
    ''' <remarks>See methodology for BAS No 9 ""Stores"" para. 8 for details.
    ''' Has an associated <see cref="General.JournalEntry">JournalEntry</see>, e.g. an invoice.
    ''' Values are stored using <see cref="OperationPersistenceObject">OperationPersistenceObject</see>.</remarks>
    <Serializable()> _
Public NotInheritable Class GoodsOperationAcquisition
        Inherits BusinessBase(Of GoodsOperationAcquisition)
        Implements IIsDirtyEnough, IGetErrorForListItem, IValidationMessageProvider

#Region " Business Methods "

        ''' <summary>
        ''' Types of the (journal entry) documents that could be attached 
        ''' to the operation, i.e. could be an acquisition base.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared ReadOnly AllowedJournalEntryTypes As DocumentType() _
            = New DocumentType() {DocumentType.BankOperation, _
            DocumentType.None, DocumentType.TillSpendingOrder, _
            DocumentType.AdvanceReport, DocumentType.LongTermAssetDiscard}

        ''' <summary>
        ''' Types of the (journal entry) documents that act as a parent
        ''' of the operation, i.e. the operation could only be changed
        ''' within the approprate document context.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared ReadOnly ParentJournalEntryTypes As DocumentType() _
            = New DocumentType() {DocumentType.InvoiceMade, _
            DocumentType.InvoiceReceived, DocumentType.GoodsInternalTransfer, _
            DocumentType.GoodsProduction, DocumentType.GoodsInventorization}

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _GoodsInfo As GoodsSummary = Nothing
        Private _OperationLimitations As OperationalLimitList = Nothing
        Private _ComplexOperationID As Integer = 0
        Private _ComplexOperationType As GoodsComplexOperationType = GoodsComplexOperationType.InternalTransfer
        Private _ComplexOperationHumanReadable As String = ""
        Private _Description As String = ""
        Private _Ammount As Double = 0
        Private _UnitCost As Double = 0
        Private _TotalCost As Double = 0
        Private _Warehouse As WarehouseInfo = Nothing
        Private _JournalEntryID As Integer = 0
        Private _JournalEntryDate As Date = Today
        Private _JournalEntryContent As String = ""
        Private _JournalEntryCorrespondence As String = ""
        Private _JournalEntryRelatedPerson As String = ""
        Private _JournalEntryType As DocumentType = DocumentType.None
        Private _JournalEntryTypeHumanReadable As String = ""
        Private _JournalEntryDocNo As String = ""
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now


        ''' <summary>
        ''' Gets an ID of the operation that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.ID">OperationPersistenceObject.ID</see>.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the operation was inserted into the database.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.InsertDate">OperationPersistenceObject.InsertDate</see>.</remarks>
        Public ReadOnly Property InsertDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _InsertDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the date and time when the operation was last updated.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.UpdateDate">OperationPersistenceObject.UpdateDate</see>.</remarks>
        Public ReadOnly Property UpdateDate() As DateTime
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="GoodsSummary">general information about the goods</see> 
        ''' that are acquired by the operation.
        ''' </summary>
        ''' <remarks>Is set when creating a new operation and cannot be changed afterwards.
        ''' Corresponds to <see cref="OperationPersistenceObject.GoodsInfo">OperationPersistenceObject.GoodsInfo</see>.</remarks>
        Public ReadOnly Property GoodsInfo() As GoodsSummary
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsItem.Name">name of the goods</see> 
        ''' that are acquired by the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsInfo">GoodsInfo</see> field
        ''' to enable databinding in a datagridview.</remarks>
        Public ReadOnly Property GoodsName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.Name
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsItem.MeasureUnit">measure unit of the goods</see> 
        ''' that are acquired by the operation.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsInfo">GoodsInfo</see> field
        ''' to enable databinding in a datagridview.</remarks>
        Public ReadOnly Property GoodsMeasureUnit() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.MeasureUnit
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="GoodsItem.AccountingMethod">accounting method for the goods</see> 
        ''' that are acquired by the operation as a localized human readable string.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsInfo">GoodsInfo</see> field
        ''' to enable databinding in a datagridview.</remarks>
        Public ReadOnly Property GoodsAccountingMethod() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.AccountingMethodHumanReadable
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="GoodsItem.DefaultValuationMethod">current valuation method 
        ''' for the goods</see> that are acquired by the operation as a localized 
        ''' human readable string.
        ''' </summary>
        ''' <remarks>A proxy property to the <see cref="GoodsInfo">GoodsInfo</see> field
        ''' to enable databinding in a datagridview.</remarks>
        Public ReadOnly Property GoodsValuationMethod() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _GoodsInfo.ValuationMethodHumanReadable
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="IChronologicValidator">IChronologicValidator</see> object 
        ''' that contains business restraints on updating the operation data.
        ''' </summary>
        ''' <remarks>A <see cref="OperationalLimitList">OperationalLimitList</see> 
        ''' is used to validate a goods operation chronological business rules.</remarks>
        Public ReadOnly Property OperationLimitations() As OperationalLimitList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OperationLimitations
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="ComplexOperationPersistenceObject.ID">ID of the complex 
        ''' goods operation</see> that the operation is a part of (if any).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.ComplexOperationID">OperationPersistenceObject.ComplexOperationID</see>.</remarks>
        Public ReadOnly Property ComplexOperationID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationID
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="ComplexOperationPersistenceObject.OperationType">type 
        ''' of the complex goods operation</see> that the operation is a part of.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.ComplexOperationType">OperationPersistenceObject.ComplexOperationType</see>.</remarks>
        Public ReadOnly Property ComplexOperationType() As GoodsComplexOperationType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationType
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="ComplexOperationPersistenceObject.OperationType">localized
        ''' human readable type of the complex goods operation</see> that the operation 
        ''' is a part of (if any).
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.ComplexOperationHumanReadable">OperationPersistenceObject.ComplexOperationHumanReadable</see>.</remarks>
        Public ReadOnly Property ComplexOperationHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationHumanReadable.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a content (description) of the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.Content">OperationPersistenceObject.Content</see>.</remarks>
        <StringField(ValueRequiredLevel.Recommended, 255)> _
        Public Property Description() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Description.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If DescriptionIsReadOnly Then Exit Property
                If value Is Nothing Then value = ""
                If _Description.Trim <> value.Trim Then
                    _Description = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an amount of the goods acquired by the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.Amount">OperationPersistenceObject.Amount</see>,
        ''' <see cref="ConsignmentPersistenceObject.Amount">ConsignmentPersistenceObject.Amount</see>
        ''' and (subject to the accounting method) <see cref="OperationPersistenceObject.AmountInWarehouse">OperationPersistenceObject.AmountInWarehouse</see>
        ''' or <see cref="OperationPersistenceObject.AmountInPurchases">OperationPersistenceObject.AmountInPurchases</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDAMOUNTGOODS)> _
        Public Property Ammount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Ammount, ROUNDAMOUNTGOODS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If AmmountIsReadOnly Then Exit Property
                If CRound(_Ammount, ROUNDAMOUNTGOODS) <> CRound(value, ROUNDAMOUNTGOODS) Then
                    _Ammount = CRound(value, ROUNDAMOUNTGOODS)
                    PropertyHasChanged()
                    SetTotalCostByUnitCostAndAmmount()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a value of the goods acquired per unit.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.UnitValue">OperationPersistenceObject.UnitValue</see>
        ''' and <see cref="ConsignmentPersistenceObject.UnitValue">ConsignmentPersistenceObject.UnitValue</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDUNITGOODS)> _
        Public Property UnitCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitCost, ROUNDUNITGOODS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If UnitCostIsReadOnly Then Exit Property
                If CRound(_UnitCost, ROUNDUNITGOODS) <> CRound(value, ROUNDUNITGOODS) Then
                    _UnitCost = CRound(value, ROUNDUNITGOODS)
                    PropertyHasChanged()
                    SetTotalCostByUnitCostAndAmmount()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a total value of the goods acquired.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.TotalValue">OperationPersistenceObject.TotalValue</see>
        ''' and <see cref="ConsignmentPersistenceObject.TotalValue">ConsignmentPersistenceObject.TotalValue</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public Property TotalCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalCost)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If TotalCostIsReadOnly Then Exit Property
                If CRound(_TotalCost) <> CRound(value) Then
                    _TotalCost = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a <see cref="Goods.Warehouse">warehouse</see> that the goods 
        ''' are acquired to.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.Warehouse">OperationPersistenceObject.Warehouse</see>
        ''' and <see cref="ConsignmentPersistenceObject.WarehouseID">ConsignmentPersistenceObject.WarehouseID</see>.</remarks>
        <WarehouseField(ValueRequiredLevel.Mandatory)> _
        Public Property Warehouse() As WarehouseInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Warehouse
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As WarehouseInfo)
                CanWriteProperty(True)
                If WarehouseIsReadOnly Then Exit Property
                If Not (_Warehouse Is Nothing AndAlso value Is Nothing) AndAlso _
                    (value Is Nothing OrElse _Warehouse Is Nothing OrElse _Warehouse.ID <> value.ID) Then
                    _Warehouse = value
                    _OperationLimitations.SetWarehouse(_Warehouse)
                    PropertyHasChanged()
                    PropertyHasChanged("AcquisitionAccount")
                    PropertyHasChanged("OperationLimitations")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.Account.ID">account</see> that the goods 
        ''' acquisition value is accounted in.
        ''' </summary>
        ''' <remarks>See methodology for BAS No 9 ""Stores"" para. 8 for details.
        ''' Value depends on the accounting method and the <see cref="Warehouse">warehouse</see>.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 2, 6)>
        Public ReadOnly Property AcquisitionAccount() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                    Return _GoodsInfo.AccountPurchases
                Else
                    If _Warehouse <> WarehouseInfo.Empty Then
                        Return _Warehouse.WarehouseAccount
                    Else
                        Return 0
                    End If
                End If
            End Get
        End Property


        ''' <summary>
        ''' Gets an <see cref="General.JournalEntry.ID">ID of the journal entry</see>
        ''' that is associated with the operation.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryID">OperationPersistenceObject.JournalEntryID</see>.</remarks>
        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.JournalEntry.Content">content of the journal entry</see>
        ''' that is associated with the operation.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryContent">OperationPersistenceObject.JournalEntryContent</see>.</remarks>
        Public ReadOnly Property JournalEntryContent() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryContent.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="ActiveReports.JournalEntryInfo.BookEntries">
        ''' description of the book entries of the journal entry</see>
        ''' that is associated with the operation.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryCorrespondence">OperationPersistenceObject.JournalEntryCorrespondence</see>.</remarks>
        Public ReadOnly Property JournalEntryCorrespondence() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryCorrespondence.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.JournalEntry.Person">person of the journal entry</see>
        ''' that is associated with the operation.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryRelatedPerson">OperationPersistenceObject.JournalEntryRelatedPerson</see>.</remarks>
        Public ReadOnly Property JournalEntryRelatedPerson() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryRelatedPerson.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.JournalEntry.DocType">type of the journal entry</see>
        ''' that is associated with the operation.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryType">OperationPersistenceObject.JournalEntryType</see>.</remarks>
        Public ReadOnly Property JournalEntryType() As DocumentType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryType
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.JournalEntry.DocType">type of the journal entry</see>,
        ''' that is associated with the operation, as a localized human readable string.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryTypeHumanReadable">OperationPersistenceObject.JournalEntryTypeHumanReadable</see>.</remarks>
        Public ReadOnly Property JournalEntryTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryTypeHumanReadable.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.JournalEntry.[Date]">date of the journal entry</see>
        ''' that is associated with the operation.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryDate">OperationPersistenceObject.JournalEntryDate</see>.</remarks>
        Public ReadOnly Property JournalEntryDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.JournalEntry.DocNumber">document number 
        ''' of the journal entry</see> that is associated with the operation.
        ''' </summary>
        ''' <remarks>Invoke method <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see>
        ''' to associate a journal entry with the operation.
        ''' Corresponds to <see cref="OperationPersistenceObject.JournalEntryDocNo">OperationPersistenceObject.JournalEntryDocNo</see>.</remarks>
        Public ReadOnly Property JournalEntryDocNo() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryDocNo.Trim
            End Get
        End Property


        ''' <summary>
        ''' Whether the <see cref="Description">Description</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DescriptionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return IsChild OrElse IsChildOperation
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="Ammount">Ammount</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AmmountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso IsChildOperation)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="UnitCost">UnitCost</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property UnitCostIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso IsChildOperation)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="TotalCost">TotalCost</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TotalCostIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso IsChildOperation)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="Warehouse">Warehouse</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property WarehouseIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange OrElse _
                    (Not Me.IsChild AndAlso IsChildOperation)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="LoadAssociatedJournalEntry">LoadAssociatedJournalEntry</see> 
        ''' method could be invoked (a new journal entry associated with the operation).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AssociatedJournalEntryIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return IsChild OrElse IsChildOperation
            End Get
        End Property

        ''' <summary>
        ''' Whether the operation is actualy a child of a complex goods operation or
        ''' other document.
        ''' </summary>
        ''' <remarks>The <see cref="GoodsOperationAdditionalCosts.IsChild">IsChild</see>
        ''' property defines the current state of the object, i.e. whether the object was
        ''' fetched/created as a child). The IsChildOperation property defines a 
        ''' persistence state of the object, i.e. whether the object was originaly
        ''' saved as a child object.</remarks>
        Public ReadOnly Property IsChildOperation() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ComplexOperationID > 0 OrElse (_JournalEntryID > 0 AndAlso _
                    Not Array.IndexOf(ParentJournalEntryTypes, _JournalEntryType) < 0) OrElse IsChild
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            Get
                If Not IsNew Then Return IsDirty
                Return (Not StringIsNullOrEmpty(_Description) _
                    OrElse CRound(_Ammount, ROUNDAMOUNTGOODS) > 0 _
                    OrElse CRound(_UnitCost, ROUNDUNITGOODS) > 0 _
                    OrElse CRound(_TotalCost, 2) > 0 OrElse _JournalEntryID > 0 _
                    OrElse _Warehouse <> WarehouseInfo.Empty)
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid
            End Get
        End Property


        Public Overrides Function Save() As GoodsOperationAcquisition
            Return MyBase.Save()
        End Function


        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then result = AddWithNewLine(result, _
                Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error), False)
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then
                result = AddWithNewLine(result, _
                    Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning), False)
            End If
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return MyBase.BrokenRulesCollection.WarningCount > 0
        End Function

        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.GetAllBrokenRules())
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If Not HasWarnings() Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.GetAllWarnings())
        End Function



        ''' <summary>
        ''' A helper method that calculates the <see cref="TotalCost">TotalCost</see>
        ''' by multiplying the <see cref="Ammount">Ammount</see> by the <see cref="UnitCost">UnitCost</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetTotalCostByUnitCostAndAmmount()
            TotalCost = CRound(_UnitCost * _Ammount)
        End Sub

        ''' <summary>
        ''' Associates a journal entry with the operation, i.e.
        ''' considers the journal entry as a base for the acquisition in the general ledger.
        ''' </summary>
        ''' <param name="entry">a journal entry to associate the operation with</param>
        ''' <remarks></remarks>
        Public Sub LoadAssociatedJournalEntry(ByVal entry As ActiveReports.JournalEntryInfo)

            If AssociatedJournalEntryIsReadOnly Then Exit Sub

            If entry Is Nothing OrElse Not entry.Id > 0 Then Exit Sub

            If Not Array.IndexOf(ParentJournalEntryTypes, entry.DocType) < 0 Then
                Throw New Exception(String.Format(Goods_GoodsOperationAcquisition_CannotAttachParentType, _
                    entry.DocTypeHumanReadable))
            ElseIf Array.IndexOf(AllowedJournalEntryTypes, entry.DocType) < 0 Then
                Throw New Exception(String.Format(Goods_GoodsOperationAcquisition_InvalidJournalEntryType, _
                    entry.DocTypeHumanReadable))
            End If

            _JournalEntryID = entry.Id
            _JournalEntryDate = entry.Date
            _JournalEntryContent = entry.Content
            _JournalEntryCorrespondence = entry.BookEntries
            _JournalEntryRelatedPerson = entry.Person
            _JournalEntryType = entry.DocType
            _JournalEntryTypeHumanReadable = entry.DocTypeHumanReadable
            _JournalEntryDocNo = entry.DocNumber

            PropertyHasChanged("JournalEntryID")
            PropertyHasChanged("JournalEntryDate")
            PropertyHasChanged("JournalEntryContent")
            PropertyHasChanged("JournalEntryCorrespondence")
            PropertyHasChanged("JournalEntryRelatedPerson")
            PropertyHasChanged("JournalEntryType")
            PropertyHasChanged("JournalEntryTypeHumanReadable")
            PropertyHasChanged("JournalEntryDocNo")

        End Sub


        ''' <summary>
        ''' Sets a new operation date as provided by the parent document.
        ''' </summary>
        ''' <param name="parentDate"></param>
        ''' <remarks></remarks>
        Friend Sub SetParentDate(ByVal parentDate As Date)
            If _JournalEntryDate.Date <> parentDate.Date Then
                _JournalEntryDate = parentDate.Date
                PropertyHasChanged("JournalEntryDate")
            End If
        End Sub

        ''' <summary>
        ''' Sets properties that are handled by a parent document 
        ''' and do not require realtime validation but do require validation before update.
        ''' </summary>
        ''' <param name="parentDocumentNumber">A parent document number.</param>
        ''' <param name="parentContent">A parent content.</param>
        ''' <remarks>Should be invoked before a parent document updates the operation.</remarks>
        Friend Sub SetParentProperties(ByVal parentDocumentNumber As String, _
            ByVal parentContent As String)

            ' nothing to do, method is kept for consistency accross the operations

        End Sub

        ''' <summary>
        ''' Sets <see cref="Description">Description</see> property.
        ''' </summary>
        ''' <param name="parentDescription">a parent content</param>
        ''' <remarks>If necessary, should be invoked before a parent document updates the operation.</remarks>
        Friend Sub SetDescription(ByVal parentDescription As String)

            If _Description.Trim <> parentDescription.Trim Then
                _Description = parentDescription.Trim
                PropertyHasChanged("Description")
            End If

        End Sub

        ''' <summary>
        ''' Sets the <see cref="Ammount">Ammount</see> property without 
        ''' <see cref="TotalCost">TotalCost</see> recalculation.
        ''' </summary>
        ''' <param name="value">a new amount value</param>
        ''' <remarks></remarks>
        Friend Sub SetAmount(ByVal value As Double)
            If CRound(_Ammount, ROUNDAMOUNTGOODS) <> CRound(value, ROUNDAMOUNTGOODS) Then
                _Ammount = CRound(value, ROUNDAMOUNTGOODS)
                PropertyHasChanged("Ammount")
            End If
        End Sub

        ''' <summary>
        ''' Sets the <see cref="UnitCost">UnitCost</see> property without 
        ''' <see cref="TotalCost">TotalCost</see> recalculation.
        ''' </summary>
        ''' <param name="value">a new unit cost value</param>
        ''' <remarks></remarks>
        Friend Sub SetUnitCost(ByVal value As Double)
            If CRound(_UnitCost, ROUNDUNITGOODS) <> CRound(value, ROUNDUNITGOODS) Then
                _UnitCost = CRound(value, ROUNDUNITGOODS)
                PropertyHasChanged("UnitCost")
            End If
        End Sub


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Goods_GoodsOperationAcquisition_ToString, _
                _GoodsInfo.Name, _ID.ToString)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New RuleArgs("UnitCost"))
            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New RuleArgs("Ammount"))
            ValidationRules.AddRule(AddressOf CommonValidation.ValueObjectFieldValidation,
                New RuleArgs("Warehouse"))

            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation,
                New CommonValidation.ChronologyRuleArgs("JournalEntryDate", "OperationLimitations"))


            ValidationRules.AddRule(AddressOf TotalCostValidation, New RuleArgs("TotalCost"))
            ValidationRules.AddRule(AddressOf DescriptionValidation, New RuleArgs("Description"))
            ValidationRules.AddRule(AddressOf JournalEntryValidation, New RuleArgs("JournalEntryID"))

            ValidationRules.AddDependantProperty("OperationLimitations", "JournalEntryDate", False)
            ValidationRules.AddDependantProperty("Warehouse", "JournalEntryDate", False)
            ValidationRules.AddDependantProperty("UnitCost", "TotalCost", False)
            ValidationRules.AddDependantProperty("Ammount", "TotalCost", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property TotalCost is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function TotalCostValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            If Not CommonValidation.DoubleFieldValidation(target, e) Then Return False

            Dim valObj As GoodsOperationAcquisition = DirectCast(target, GoodsOperationAcquisition)

            If valObj.Ammount > 0 AndAlso valObj.UnitCost > 0 AndAlso _
                Math.Abs((valObj._UnitCost * valObj._Ammount) - valObj._TotalCost) > 0.5 * valObj._UnitCost Then
                e.Description = Goods_GoodsOperationAcquisition_TotalCostInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True
        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property Description is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DescriptionValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean
            If DirectCast(target, GoodsOperationAcquisition).IsChild Then Return True
            Return CommonValidation.StringFieldValidation(target, e)
        End Function

        ''' <summary>
        ''' Rule ensuring that associated journal entry is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function JournalEntryValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As GoodsOperationAcquisition = DirectCast(target, GoodsOperationAcquisition)

            If valObj.IsChild Then Return True

            If Not valObj._JournalEntryID > 0 Then
                e.Description = Goods_GoodsOperationAcquisition_JournalEntryNull
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

            AuthorizationRules.AllowWrite("Goods.GoodsOperationAcquisition2")

        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAcquisition2")
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAcquisition1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAcquisition3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationAcquisition3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new GoodsOperationAcquisition instance.
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' to acquire</param>
        ''' <param name="warehouseID">an <see cref="Goods.Warehouse.ID">ID of the warehouse</see>
        ''' to place the acquired goods into</param>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsOperationAcquisition(ByVal goodsID As Integer, _
            ByVal warehouseID As Integer) As GoodsOperationAcquisition
            Return DataPortal.Create(Of GoodsOperationAcquisition) _
                (New Criteria(goodsID, warehouseID))
        End Function

        ''' <summary>
        ''' Gets a new GoodsOperationAcquisition instance as a child of a
        ''' parent document (complex goods operation, invoice, etc.).
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' to acquire</param>
        ''' <param name="warehouseID">an <see cref="Goods.Warehouse.ID">ID of the warehouse</see>
        ''' to place the acquired goods into</param>
        ''' <param name="parentValidator">a chronologic validator of the parent document (if any)</param>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsOperationAcquisitionChild(ByVal goodsID As Integer, _
            ByVal warehouseID As Integer, ByVal parentValidator As IChronologicValidator) As GoodsOperationAcquisition
            Return New GoodsOperationAcquisition(goodsID, warehouseID, parentValidator)
        End Function

        ''' <summary>
        ''' Gets a new GoodsOperationAcquisition instance as a child of a
        ''' parent document (complex goods operation, invoice, etc.).
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' to acquire</param>
        ''' <param name="parentWarehouse">a parent document <see cref="Goods.Warehouse">
        ''' warehouse</see> to place the acquired goods into</param>
        ''' <param name="parentValidator">a chronologic validator of the parent document (if any)</param>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsOperationAcquisitionChild(ByVal goodsID As Integer, _
            ByVal parentWarehouse As WarehouseInfo, ByVal parentValidator As IChronologicValidator) As GoodsOperationAcquisition
            Return New GoodsOperationAcquisition(goodsID, parentWarehouse, parentValidator)
        End Function

        ''' <summary>
        ''' Gets an existing GoodsOperationAcquisition instance from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID</see> of the operation to fetch</param>
        ''' <remarks></remarks>
        Public Shared Function GetGoodsOperationAcquisition(ByVal id As Integer) As GoodsOperationAcquisition
            Return DataPortal.Fetch(Of GoodsOperationAcquisition)(New Criteria(id))
        End Function

        ''' <summary>
        ''' Gets an existing GoodsOperationAcquisition instance as a child of a 
        ''' parent document using database query results.
        ''' </summary>
        ''' <param name="obj">a data persistence object holding the operation data</param>
        ''' <param name="limitationsDataSource">a datasource for the 
        ''' <see cref="OperationalLimitList">OperationalLimitList</see></param>
        ''' <param name="parentValidator">a chronologic validator of the parent document (if any)</param>
        ''' <remarks></remarks>
        Friend Shared Function GetGoodsOperationAcquisitionChild( _
            ByVal obj As OperationPersistenceObject, ByVal limitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator) As GoodsOperationAcquisition
            Return New GoodsOperationAcquisition(obj, limitationsDataSource, parentValidator)
        End Function

        ''' <summary>
        ''' Gets an existing GoodsOperationAcquisition instance as a child of a 
        ''' parent document from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID</see> of the operation to fetch</param>
        ''' <param name="parentValidator">a chronologic validator of the parent document (if any)</param>
        ''' <remarks></remarks>
        Friend Shared Function GetGoodsOperationAcquisitionChild(ByVal id As Integer, _
            ByVal parentValidator As IChronologicValidator) As GoodsOperationAcquisition
            Return New GoodsOperationAcquisition(id, parentValidator, False)
        End Function

        ''' <summary>
        ''' Deletes an existing GoodsOperationAcquisition instance from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID</see> of the operation to delete</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteGoodsOperationAcquisition(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
        End Sub

        ''' <summary>
        ''' Deletes an existing GoodsOperationAcquisition instance as a child
        ''' of a parent document from a database.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub DeleteGoodsOperationAcquisitionChild()
            If IsNew Then Exit Sub
            DoDelete()
        End Sub


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal goodsID As Integer, ByVal warehouseID As Integer,
            ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            MarkAsChild()
            Create(goodsID, warehouseID, parentValidator)
        End Sub

        Private Sub New(ByVal goodsID As Integer, ByVal parentWarehouse As WarehouseInfo, _
            ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            MarkAsChild()
            Create(goodsID, parentWarehouse, parentValidator)
        End Sub

        Private Sub New(ByVal nID As Integer, ByVal parentValidator As IChronologicValidator, _
            ByVal createNew As Boolean)
            ' require use of factory methods
            MarkAsChild()
            Fetch(nID, parentValidator)
        End Sub

        Private Sub New(ByVal obj As OperationPersistenceObject, _
            ByVal limitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            MarkAsChild()
            Fetch(obj, limitationsDataSource, parentValidator)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private mId As Integer
            Private mWarehouseId As Integer
            Public ReadOnly Property Id() As Integer
                Get
                    Return mId
                End Get
            End Property
            Public ReadOnly Property WarehouseId() As Integer
                Get
                    Return mWarehouseId
                End Get
            End Property
            Public Sub New(ByVal id As Integer)
                mId = id
                mWarehouseId = 0
            End Sub
            Public Sub New(ByVal nGoodsID As Integer, ByVal nWarehouseID As Integer)
                mId = nGoodsID
                mWarehouseId = nWarehouseID
            End Sub
        End Class


        Private Overloads Sub DataPortal_Create(ByVal criteria As Criteria)
            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)
            Create(criteria.Id, criteria.WarehouseId, Nothing)
        End Sub

        Private Sub Create(ByVal goodsID As Integer, ByVal warehouseID As Integer,
            ByVal parentValidator As IChronologicValidator)
            Dim curSummary As GoodsSummary = GoodsSummary.NewGoodsSummary(goodsID)
            Dim curWarehouse As WarehouseInfo = WarehouseInfoList.GetListChild.GetItem(
                warehouseID, curSummary.DefaultWarehouseID, False)
            Create(curSummary, curWarehouse, parentValidator)
        End Sub

        Private Sub Create(ByVal goodsID As Integer, ByVal parentWarehouse As WarehouseInfo, _
            ByVal parentValidator As IChronologicValidator)
            Dim curSummary As GoodsSummary = GoodsSummary.NewGoodsSummary(goodsID)
            Create(curSummary, parentWarehouse, parentValidator)
        End Sub

        Private Sub Create(ByVal summary As GoodsSummary, ByVal parentWarehouse As WarehouseInfo, _
            ByVal parentValidator As IChronologicValidator)

            _GoodsInfo = summary

            _Warehouse = parentWarehouse
            Dim wd As Integer = 0
            If _Warehouse <> WarehouseInfo.Empty Then
                wd = _Warehouse.ID
            End If

            _OperationLimitations = OperationalLimitList.NewOperationalLimitList( _
                _GoodsInfo, GoodsOperationType.Acquisition, wd, parentValidator)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException(
                My.Resources.Common_SecuritySelectDenied)

            Fetch(criteria.Id, Nothing)

        End Sub

        Private Sub Fetch(ByVal nID As Integer, ByVal parentValidator As IChronologicValidator)

            Dim obj As OperationPersistenceObject = OperationPersistenceObject. _
                GetOperationPersistenceObject(nID, GoodsOperationType.Acquisition)

            Fetch(obj, Nothing, parentValidator)

        End Sub

        Private Sub Fetch(ByVal obj As OperationPersistenceObject, _
            ByVal limitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator)

            If obj.OperationType <> GoodsOperationType.Acquisition Then
                Throw New Exception(String.Format(Goods_OperationPersistenceObject_OperationTypeMismatch, _
                    _ID.ToString, ConvertLocalizedName(obj.OperationType), _
                    ConvertLocalizedName(GoodsOperationType.Acquisition)))
            End If

            _ID = obj.ID
            _ComplexOperationID = obj.ComplexOperationID
            _ComplexOperationType = obj.ComplexOperationType
            _ComplexOperationHumanReadable = obj.ComplexOperationHumanReadable
            _Description = obj.Content
            _Ammount = obj.Amount
            _UnitCost = obj.UnitValue
            _TotalCost = obj.TotalValue
            _Warehouse = obj.Warehouse
            _JournalEntryID = obj.JournalEntryID
            _JournalEntryDate = obj.JournalEntryDate
            _JournalEntryContent = obj.JournalEntryContent
            _JournalEntryCorrespondence = obj.JournalEntryCorrespondence
            _JournalEntryRelatedPerson = obj.JournalEntryRelatedPerson
            _JournalEntryType = obj.JournalEntryType
            _JournalEntryTypeHumanReadable = obj.JournalEntryTypeHumanReadable
            _JournalEntryDocNo = obj.JournalEntryDocNo
            _InsertDate = obj.InsertDate
            _UpdateDate = obj.UpdateDate
            _GoodsInfo = obj.GoodsInfo

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(
                _GoodsInfo, GoodsOperationType.Acquisition, _ID, _JournalEntryDate,
                obj.WarehouseID, parentValidator, limitationsDataSource)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            CheckIfCanSaveRoot()

            CheckIfCanUpdate(Nothing, Nothing)

            DoSave(True, False)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(
                _GoodsInfo, GoodsOperationType.Acquisition, _ID, _JournalEntryDate,
                _Warehouse.ID, Nothing, Nothing)

            ValidationRules.CheckRules()

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException(
                My.Resources.Common_SecurityUpdateDenied)

            CheckIfCanSaveRoot()

            CheckIfCanUpdate(Nothing, Nothing)

            DoSave(True, False)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList(
                _GoodsInfo, GoodsOperationType.Acquisition, _ID, _JournalEntryDate,
                _Warehouse.ID, Nothing, Nothing)

            ValidationRules.CheckRules()

        End Sub

        Private Sub CheckIfCanSaveRoot()

            If _ComplexOperationID > 0 Then
                Throw New Exception(String.Format(Goods_GoodsOperationAcquisition_InvalidSaveChild,
                    _ComplexOperationHumanReadable))
            ElseIf Not Array.IndexOf(ParentJournalEntryTypes, _JournalEntryType) < 0 Then
                Throw New Exception(String.Format(Goods_GoodsOperationAcquisition_InvalidSaveChild,
                    _JournalEntryTypeHumanReadable))
            End If

        End Sub


        Friend Sub SaveChild(ByVal parentJournalEntryID As Integer,
            ByVal parentComplexOperationID As Integer, ByVal parentAlowsFinancialDataUpdate As Boolean,
            ByVal parentAllowsWarehouseUpdate As Boolean)

            _JournalEntryID = parentJournalEntryID
            _ComplexOperationID = parentComplexOperationID

            DoSave(parentAlowsFinancialDataUpdate, parentAllowsWarehouseUpdate)

        End Sub


        Private Sub DoSave(ByVal parentAlowsFinancialDataUpdate As Boolean,
            ByVal parentAllowsWarehouseUpdate As Boolean)

            If IsNew AndAlso Not parentAlowsFinancialDataUpdate Then
                Throw New Exception(My.Resources.Goods_GoodsOperationAcquisition_InvalidChildSaveState)
            End If

            Dim consignment As ConsignmentPersistenceObject = Nothing
            If _OperationLimitations.FinancialDataCanChange AndAlso (parentAlowsFinancialDataUpdate _
                OrElse parentAllowsWarehouseUpdate) Then
                consignment = GetConsignmentPersistenceObject(_OperationLimitations.FinancialDataCanChange _
                    AndAlso parentAlowsFinancialDataUpdate)
            End If

            Dim obj As OperationPersistenceObject = GetPersistenceObj()

            Using transaction As New SqlTransaction

                Try

                    obj = obj.Save(_OperationLimitations.FinancialDataCanChange _
                        AndAlso parentAlowsFinancialDataUpdate, _OperationLimitations.FinancialDataCanChange _
                        AndAlso parentAllowsWarehouseUpdate)

                    If IsNew Then
                        _ID = obj.ID
                        _InsertDate = obj.InsertDate
                    End If
                    _UpdateDate = obj.UpdateDate

                    If Not consignment Is Nothing Then
                        If IsNew Then
                            consignment.Insert(_ID, _Warehouse.ID)
                        Else
                            consignment.Update(_Warehouse.ID)
                        End If
                    End If

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkOld()

        End Sub

        Friend Function GetConsignmentPersistenceObject(ByVal updateFinancialData As Boolean) As ConsignmentPersistenceObject

            Dim result As ConsignmentPersistenceObject

            If IsNew Then
                result = ConsignmentPersistenceObject.NewConsignmentPersistenceObject
            Else

                Dim list As ConsignmentPersistenceObjectList = ConsignmentPersistenceObjectList.
                    GetConsignmentPersistenceObjectList(_ID)

                If list.Count < 1 Then
                    Throw New Exception(String.Format(Goods_GoodsOperationAcquisition_ConsignmentNotFound,
                        _GoodsInfo.Name))
                End If
                If list.Count > 1 Then
                    Throw New Exception(String.Format(Goods_GoodsOperationAcquisition_ConsignmentInvalid,
                        _GoodsInfo.Name))
                End If

                result = list(0)

            End If

            If IsNew OrElse updateFinancialData Then
                result.Amount = _Ammount
                result.TotalValue = _TotalCost
                result.UnitValue = _UnitCost
            End If

            Return result

        End Function

        Private Function GetPersistenceObj() As OperationPersistenceObject

            Dim obj As OperationPersistenceObject
            If IsNew Then
                obj = OperationPersistenceObject.NewOperationPersistenceObject( _
                    GoodsOperationType.Acquisition, _GoodsInfo.ID)
            Else
                obj = OperationPersistenceObject.GetOperationPersistenceObjectForSave( _
                    _ID, GoodsOperationType.Acquisition, _UpdateDate, IsChild)
            End If

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                obj.AccountPurchases = _TotalCost
                obj.AmountInWarehouse = 0
                obj.AmountInPurchases = _Ammount
            Else
                obj.AccountGeneral = _TotalCost
                obj.AmountInWarehouse = _Ammount
                obj.AmountInPurchases = 0
            End If
            obj.Amount = _Ammount
            obj.Content = _Description
            obj.DocNo = ""
            obj.JournalEntryID = _JournalEntryID
            obj.OperationDate = _JournalEntryDate
            obj.TotalValue = _TotalCost
            obj.UnitValue = _UnitCost
            obj.WarehouseID = _Warehouse.ID
            obj.ComplexOperationID = _ComplexOperationID

            Return obj

        End Function


        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            Dim operationToDelete As GoodsOperationAcquisition = New GoodsOperationAcquisition
            operationToDelete.DataPortal_Fetch(criteria)

            If operationToDelete.ComplexOperationID > 0 Then
                Throw New Exception(String.Format(Goods_GoodsOperationAcquisition_InvalidDeleteChild, _
                    operationToDelete._ComplexOperationHumanReadable))
            ElseIf Not Array.IndexOf(ParentJournalEntryTypes, operationToDelete._JournalEntryType) < 0 Then
                Throw New Exception(String.Format(Goods_GoodsOperationAcquisition_InvalidDeleteChild, _
                    operationToDelete._JournalEntryTypeHumanReadable))
            End If

            If Not operationToDelete._OperationLimitations.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsOperationAcquisition_InvalidDelete, _
                    operationToDelete._GoodsInfo.Name, vbCrLf, operationToDelete._OperationLimitations. _
                    FinancialDataCanChangeExplanation))
            End If

            operationToDelete.DoDelete()

        End Sub

        Private Sub DoDelete()

            Using transaction As New SqlTransaction

                Try

                    OperationPersistenceObject.Delete(_ID, True, False)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            MarkNew()

        End Sub


        Friend Sub CheckIfCanDelete(ByVal parentValidator As IChronologicValidator, _
            ByVal limitationsDataSource As DataTable)

            If IsNew Then Exit Sub

            _OperationLimitations = OperationalLimitList.GetUpdatedOperationalLimitList( _
                _OperationLimitations, parentValidator, limitationsDataSource)

            If Not _OperationLimitations.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsOperationAcquisition_InvalidDelete, _
                    _GoodsInfo.Name, vbCrLf, _OperationLimitations. _
                    FinancialDataCanChangeExplanation))
            End If

        End Sub

        Friend Sub CheckIfCanUpdate(ByVal parentValidator As IChronologicValidator, _
            ByVal limitationsDataSource As DataTable)

            _OperationLimitations = OperationalLimitList.GetUpdatedOperationalLimitList( _
                _OperationLimitations, parentValidator, limitationsDataSource)

            ValidationRules.CheckRules()
            If Not IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetErrorString()))
            End If

        End Sub

        ''' <summary>
        ''' Gets a list of book entries required for the goods acquisition.
        ''' WARNING. The book entries returned are not balanced.
        ''' </summary>
        ''' <returns></returns>
        Friend Function GetTotalBookEntryList() As BookEntryInternalList

            Dim result As BookEntryInternalList = _
               BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                AcquisitionAccount, CRound(_TotalCost, 2), Nothing))

            Return result

        End Function

#End Region

    End Class

End Namespace