﻿Imports ApskaitaObjects.My.Resources
Imports Csla.Validation
Imports System.IO

Namespace Goods

    ''' <summary>
    ''' Represents a simple goods discard operation (when goods are consumed, 
    ''' damaged, lost, etc.).
    ''' </summary>
    ''' <remarks>See methodology for BAS No 9 ""Stores"" para. 40 for details.
    ''' Encapsulates a <see cref="General.JournalEntry">JournalEntry</see> of type
    ''' <see cref="DocumentType.GoodsWriteOff">DocumentType.GoodsWriteOff</see>.
    ''' Values are stored using <see cref="OperationPersistenceObject">OperationPersistenceObject</see>.</remarks>
    <Serializable()> _
Public NotInheritable Class GoodsOperationDiscard
        Inherits BusinessBase(Of GoodsOperationDiscard)
        Implements IIsDirtyEnough, IGetErrorForListItem, IValidationMessageProvider

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _InsertDate As DateTime = Now
        Private _UpdateDate As DateTime = Now
        Private _JournalEntryID As Integer = 0
        Private _JournalEntryType As DocumentType = DocumentType.GoodsWriteOff
        Private _GoodsInfo As GoodsSummary = Nothing
        Private _OperationLimitations As OperationalLimitList = Nothing
        Private _ComplexOperationID As Integer = 0
        Private _ComplexOperationType As GoodsComplexOperationType = GoodsComplexOperationType.InternalTransfer
        Private _ComplexOperationHumanReadable As String = ""
        Private _Warehouse As WarehouseInfo = Nothing
        Private _OldWarehouseID As Integer = 0
        Private _DocumentNumber As String = ""
        Private _Date As Date = Today
        Private _Description As String = ""
        Private _Ammount As Double = 0
        Private _UnitCost As Double = 0
        Private _TotalCost As Double = 0
        Private _AccountGoodsDiscardCosts As Long = 0
        Private _NormativeUnitValue As Double = 0
        Private _NormativeTotalValue As Double = 0


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
        ''' Gets an <see cref="General.JournalEntry.ID">ID of the journal entry</see>
        ''' that is encapsulated by the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.JournalEntryID">OperationPersistenceObject.JournalEntryID</see>.</remarks>
        Public ReadOnly Property JournalEntryID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryID
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.JournalEntry.DocType">type of the journal entry</see>
        ''' that is encapsulated by the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.JournalEntryType">OperationPersistenceObject.JournalEntryType</see>.</remarks>
        Public ReadOnly Property JournalEntryType() As DocumentType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _JournalEntryType
            End Get
        End Property

        ''' <summary>
        ''' Gets <see cref="GoodsSummary">general information about the goods</see> 
        ''' that are discarded by the operation.
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
        ''' that are discarded by the operation.
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
        ''' that are discarded by the operation.
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
        ''' that are discarded by the operation as a localized human readable string.
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
        ''' for the goods</see> that are discarded by the operation as a localized 
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
        ''' Gets or sets a <see cref="Goods.Warehouse">warehouse</see> that the goods 
        ''' are discarded from.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.Warehouse">OperationPersistenceObject.Warehouse</see>.</remarks>
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
                    PropertyHasChanged("OperationLimitations")

                    SetNullCosts()

                End If
            End Set
        End Property

        Public ReadOnly Property OldWarehouseID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OldWarehouseID
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a document number of the operation.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.DocNo">OperationPersistenceObject.DocNo</see>.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 30)> _
        Public Property DocumentNumber() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentNumber.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If DocumentNumberIsReadOnly Then Exit Property
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
        ''' <remarks>Corresponds to <see cref="OperationPersistenceObject.OperationDate">OperationPersistenceObject.OperationDate</see>.</remarks>
        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                CanWriteProperty(True)
                If DateIsReadOnly Then Exit Property
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
                End If
            End Set
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
        ''' Gets or sets an amount of the goods discarded by the operation.
        ''' </summary>
        ''' <remarks>Corresponds to minus <see cref="OperationPersistenceObject.Amount">OperationPersistenceObject.Amount</see>,
        ''' <see cref="ConsignmentDiscardPersistenceObject.Amount">ConsignmentDiscardPersistenceObject.Amount</see>
        ''' and (subject to the accounting method) minus 
        ''' <see cref="OperationPersistenceObject.AmountInWarehouse">OperationPersistenceObject.AmountInWarehouse</see>.</remarks>
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

                    SetNullCosts()

                    If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                        _NormativeTotalValue = CRound(_NormativeUnitValue * _Ammount)
                        PropertyHasChanged("NormativeTotalValue")
                    End If

                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an <see cref="General.Account.ID">account</see> for discard costs.
        ''' </summary>
        ''' <remarks>Only applicable if the discarded goods are accounted using
        ''' <see cref="Goods.GoodsAccountingMethod.Persistent">Persistent</see> accounting method.
        ''' Corresponds to <see cref="OperationPersistenceObject.AccountOperation">OperationPersistenceObject.AccountOperation</see>.</remarks>
        <AccountField(ValueRequiredLevel.Mandatory, False, 1, 2, 6)> _
        Public Property AccountGoodsDiscardCosts() As Long
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AccountGoodsDiscardCosts
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Long)
                CanWriteProperty(True)
                If AccountGoodsDiscardCostsIsReadOnly Then Exit Property
                If _AccountGoodsDiscardCosts <> value Then
                    _AccountGoodsDiscardCosts = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a discarded goods value per unit.
        ''' </summary>
        ''' <remarks>Only applicable if the goods are accounted using
        ''' <see cref="Goods.GoodsAccountingMethod.Persistent">Persistent accounting method</see>.
        ''' Use <see cref="GoodsCostItem">goods cost query object</see> to fetch
        ''' costs for a discarded amount.
        ''' Is calculated as <see cref="TotalCost">TotalCost</see>
        ''' divided by <see cref="Ammount">Ammount</see>.
        ''' Final value is set by <see cref="ConsignmentDiscardPersistenceObjectList">
        ''' consignment discards persistence object</see>.
        ''' Corresponds to <see cref="OperationPersistenceObject.UnitValue">OperationPersistenceObject.UnitValue</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, ROUNDUNITGOODS)> _
        Public ReadOnly Property UnitCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnitCost, ROUNDUNITGOODS)
            End Get
        End Property

        ''' <summary>
        ''' Gets a total discarded goods value.
        ''' </summary>
        ''' <remarks>Only applicable if the goods are accounted using
        ''' <see cref="Goods.GoodsAccountingMethod.Persistent">Persistent accounting method</see>.
        ''' Use <see cref="GoodsCostItem">goods cost query object</see> to fetch
        ''' costs for a discarded amount.
        ''' Final value is set by <see cref="ConsignmentDiscardPersistenceObjectList">
        ''' consignment discards persistence object</see>.
        ''' Corresponds to minus <see cref="OperationPersistenceObject.TotalValue">OperationPersistenceObject.TotalValue</see>,
        ''' <see cref="OperationPersistenceObject.AccountOperationValue">OperationPersistenceObject.AccountOperationValue</see>,
        ''' <see cref="ConsignmentDiscardPersistenceObject.TotalValue">ConsignmentDiscardPersistenceObject.TotalValue</see>
        ''' and subject to the <see cref="GoodsItem.AccountingMethod">accounting method 
        ''' of the goods</see> minus <see cref="OperationPersistenceObject.AccountGeneral">OperationPersistenceObject.AccountGeneral</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2)> _
        Public ReadOnly Property TotalCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalCost)
            End Get
        End Property

        ''' <summary>
        ''' Gets normative unit costs of the goods that are discarded by the operation.
        ''' </summary>
        ''' <remarks>Only applicable if the goods are accounted using
        ''' <see cref="Goods.GoodsAccountingMethod.Periodic">Periodic accounting method</see>.
        ''' Is only used when it is necessary to add <see cref="General.BookEntry">
        ''' book entries</see> to discard goods that are not normaly required
        ''' for the periodic accounting method, e.g. <see cref="GoodsComplexOperationProduction">
        ''' GoodsComplexOperationProduction</see>.
        ''' Corresponds to <see cref="OperationPersistenceObject.UnitValue">OperationPersistenceObject.UnitValue</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDUNITGOODS)> _
        Public Property NormativeUnitValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_NormativeUnitValue, ROUNDUNITGOODS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Friend Set(ByVal value As Double)
                CanWriteProperty(True)
                If NormativeUnitValueIsReadOnly Then Exit Property
                If CRound(_NormativeUnitValue, ROUNDUNITGOODS) _
                    <> CRound(value, ROUNDUNITGOODS) Then
                    _NormativeUnitValue = CRound(value, ROUNDUNITGOODS)
                    PropertyHasChanged()
                    _NormativeTotalValue = CRound(_NormativeUnitValue * _Ammount)
                    PropertyHasChanged("NormativeTotalValue")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets total normative costs of the goods that are discarded by the operation.
        ''' </summary>
        ''' <remarks>Only applicable if the goods are accounted using
        ''' <see cref="Goods.GoodsAccountingMethod.Periodic">Periodic accounting method</see>.
        ''' Is only used when it is necessary to add <see cref="General.BookEntry">
        ''' book entries</see> to discard goods that are not normaly required
        ''' for the periodic accounting method, e.g. <see cref="GoodsComplexOperationProduction">
        ''' GoodsComplexOperationProduction</see>.
        ''' Corresponds to <see cref="OperationPersistenceObject.TotalValue">OperationPersistenceObject.TotalValue</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property NormativeTotalValue() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_NormativeTotalValue, 2)
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements IIsDirtyEnough.IsDirtyEnough
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If Not IsNew Then Return IsDirty
                Return (Not String.IsNullOrEmpty(_Description.Trim) _
                    OrElse Not String.IsNullOrEmpty(_DocumentNumber.Trim) _
                    OrElse CRound(_Ammount, ROUNDAMOUNTGOODS) > 0)
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid
            End Get
        End Property


        ''' <summary>
        ''' Whether the <see cref="Warehouse">Warehouse</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property WarehouseIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange _
                    OrElse IsChild OrElse _ComplexOperationID > 0
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="DocumentNumber">DocumentNumber</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DocumentNumberIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return IsChild OrElse _ComplexOperationID > 0
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="Date">Date</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DateIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return IsChild OrElse _ComplexOperationID > 0
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="Description">Description</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DescriptionIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not Me.IsChild AndAlso _ComplexOperationID > 0
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="Ammount">Ammount</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AmmountIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange _
                    OrElse (Not Me.IsChild AndAlso _ComplexOperationID > 0)
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="NormativeUnitValue">NormativeUnitValue</see> property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property NormativeUnitValueIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange _
                    OrElse Not Me.IsChild OrElse _GoodsInfo.AccountingMethod _
                    <> Goods.GoodsAccountingMethod.Periodic
            End Get
        End Property

        ''' <summary>
        ''' Whether the <see cref="AccountGoodsDiscardCosts">AccountGoodsDiscardCosts</see> 
        ''' property is readonly.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AccountGoodsDiscardCostsIsReadOnly() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _OperationLimitations.FinancialDataCanChange _
                    OrElse (Not Me.IsChild AndAlso _ComplexOperationID > 0)
            End Get
        End Property



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
        ''' Loads <see cref="UnitCost">UnitCost</see> and <see cref="TotalCost">TotalCost</see>
        ''' values from a <see cref="GoodsCostItem">query object</see>.
        ''' </summary>
        ''' <param name="costInfo">a query object</param>
        ''' <remarks></remarks>
        Public Sub LoadCostInfo(ByVal costInfo As GoodsCostItem)

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                Throw New Exception(Goods_GoodsOperationDiscard_LoadCostInfoInvalid)
            End If
            If costInfo.GoodsID <> _GoodsInfo.ID Then
                Throw New ArgumentException(Goods_GoodsOperationDiscard_GoodsIdMismatch, "costInfo")
            End If
            If Not _Warehouse Is Nothing AndAlso costInfo.WarehouseID <> _Warehouse.ID Then
                Throw New ArgumentException(Goods_GoodsOperationDiscard_WarehouseIdMismatch, "costInfo")
            End If
            If costInfo.Amount <> CRound(_Ammount, ROUNDAMOUNTGOODS) Then
                Throw New ArgumentException(Goods_GoodsOperationDiscard_AmountMismatch, "costInfo")
            End If
            If costInfo.ValuationMethod <> _GoodsInfo.ValuationMethod Then
                Throw New ArgumentException(Goods_GoodsOperationDiscard_ValuationMethodMismatch, "costInfo")
            End If
            If Not _OperationLimitations.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsOperationDiscard_CannotChangeFinancialData, _
                    _GoodsInfo.Name, vbCrLf, _OperationLimitations.FinancialDataCanChangeExplanation))
            End If
            If costInfo.NotEnoughInStock Then
                Throw New Exception(String.Format(Goods_GoodsOperationDiscard_NotEnoughInStock, _
                    _GoodsInfo.Name))
            End If

            _UnitCost = costInfo.UnitCosts
            _TotalCost = costInfo.TotalCosts
            PropertyHasChanged("UnitCost")
            PropertyHasChanged("TotalCost")

        End Sub

        ''' <summary>
        ''' Gets a param object for a <see cref="GoodsCostItem">query object</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Function GetGoodsCostParam() As GoodsCostParam
            If _Warehouse Is Nothing OrElse _Warehouse.IsEmpty Then
                Throw New Exception(Goods_GoodsOperationDiscard_WarehouseNull)
            End If
            Return GoodsCostParam.NewGoodsCostParam(_GoodsInfo.ID, _Warehouse.ID, _
                _Ammount, _ID, 0, _GoodsInfo.ValuationMethod, _Date)
        End Function


        ''' <summary>
        ''' Sets a new operation date as provided by the parent document.
        ''' </summary>
        ''' <param name="parentDate"></param>
        ''' <remarks></remarks>
        Friend Sub SetParentDate(ByVal parentDate As Date)
            If _Date.Date <> parentDate.Date Then
                _Date = parentDate.Date
                PropertyHasChanged("Date")
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

            If _DocumentNumber.Trim <> parentDocumentNumber.Trim Then
                _DocumentNumber = parentDocumentNumber.Trim
                PropertyHasChanged("DocumentNumber")
            End If

        End Sub

        ''' <summary>
        ''' Sets a <see cref="Warehouse">warehouse</see> that is handled by a parent document.
        ''' </summary>
        ''' <param name="newWarehouse"></param>
        ''' <remarks>Should be invoked before a parent document updates the operation.</remarks>
        Friend Sub SetParentWarehouse(ByVal newWarehouse As WarehouseInfo)
            If Not (_Warehouse Is Nothing AndAlso newWarehouse Is Nothing) AndAlso _
                (newWarehouse Is Nothing OrElse _Warehouse Is Nothing OrElse _Warehouse.ID _
                 <> newWarehouse.ID) Then

                If Not _OperationLimitations.FinancialDataCanChange Then
                    Throw New Exception(String.Format(Goods_GoodsOperationDiscard_CannotChangeFinancialData, _
                        vbCrLf, _OperationLimitations.FinancialDataCanChangeExplanation))
                End If

                _Warehouse = newWarehouse
                _OperationLimitations.SetWarehouse(_Warehouse)

                PropertyHasChanged("Warehouse")
                PropertyHasChanged("OperationLimitations")

                SetNullCosts()

            End If
        End Sub

        Private Sub SetNullCosts()

            _UnitCost = 0
            _TotalCost = 0
            PropertyHasChanged("UnitCost")
            PropertyHasChanged("TotalCost")

        End Sub


        Public Overrides Function Save() As GoodsOperationDiscard
            Return MyBase.Save()
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Goods_GoodsOperationDiscard_ToString, _
                _GoodsInfo.Name, _ID.ToString)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.DoubleFieldValidation, _
                New RuleArgs("Ammount"))

            ValidationRules.AddRule(AddressOf CommonValidation.ChronologyValidation, _
                New CommonValidation.ChronologyRuleArgs("Date", "OperationLimitations"))

            ValidationRules.AddRule(AddressOf RootStringFieldValidation, New RuleArgs("DocumentNumber"))
            ValidationRules.AddRule(AddressOf RootStringFieldValidation, New RuleArgs("Description"))
            ValidationRules.AddRule(AddressOf WarehouseValidation, New RuleArgs("Warehouse"))
            ValidationRules.AddRule(AddressOf CostsValidation, New RuleArgs("UnitCost"))
            ValidationRules.AddRule(AddressOf CostsValidation, New RuleArgs("TotalCost"))
            ValidationRules.AddRule(AddressOf AccountGoodsDiscardCostsValidation, _
                New RuleArgs("AccountGoodsDiscardCosts"))

            ValidationRules.AddDependantProperty("Warehouse", "Date", False)
            ValidationRules.AddDependantProperty("OperationLimitations", "Date", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the values of string properties are only validated for a root object.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function RootStringFieldValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean
            If DirectCast(target, GoodsOperationDiscard).IsChild Then Return True
            Return CommonValidation.StringFieldValidation(target, e)
        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property Warehouse is is only validated for a root object.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function WarehouseValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean
            If DirectCast(target, GoodsOperationDiscard).IsChild Then Return True
            Return CommonValidation.ValueObjectFieldValidation(target, e)
        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property UnitCost is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function CostsValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As GoodsOperationDiscard = DirectCast(target, GoodsOperationDiscard)

            If valObj.IsChild Then Return True

            If valObj._GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Persistent Then
                Return CommonValidation.DoubleFieldValidation(target, e)
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property AccountGoodsDiscardCosts is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AccountGoodsDiscardCostsValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As GoodsOperationDiscard = DirectCast(target, GoodsOperationDiscard)

            If valObj._GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Persistent Then
                Return CommonValidation.AccountFieldValidation(target, e)
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("Goods.GoodsOperationDiscard2")
        End Sub

        Public Shared Function CanAddObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationDiscard2")
        End Function

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationDiscard1")
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationDiscard3")
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return ApplicationContext.User.IsInRole("Goods.GoodsOperationDiscard3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new GoodsOperationDiscard instance.
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' to discard</param>
        ''' <param name="warehouseID">an <see cref="Goods.Warehouse.ID">ID of the warehouse</see>
        ''' to discard the goods from</param>
        ''' <remarks></remarks>
        Public Shared Function NewGoodsOperationDiscard(ByVal goodsID As Integer, _
            ByVal warehouseID As Integer) As GoodsOperationDiscard
            Return DataPortal.Create(Of GoodsOperationDiscard) _
                (New Criteria(goodsID, warehouseID))
        End Function

        ''' <summary>
        ''' Gets a new GoodsOperationDiscard instance as a child of a
        ''' parent document (complex goods operation, invoice, etc.).
        ''' </summary>
        ''' <param name="summary">a <see cref="GoodsSummary">general info about
        ''' the goods to discard</see></param>
        ''' <param name="warehouseID">an <see cref="Goods.Warehouse.ID">ID of the warehouse</see>
        ''' to discard the goods from</param>
        ''' <param name="parentValidator">a chronologic validator of the parent document (if any)</param>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsOperationDiscardChild(ByVal summary As GoodsSummary, _
            ByVal warehouseID As Integer, ByVal parentValidator As IChronologicValidator) As GoodsOperationDiscard
            Return New GoodsOperationDiscard(summary, warehouseID, parentValidator)
        End Function

        ''' <summary>
        ''' Gets a new GoodsOperationDiscard instance as a child of a
        ''' parent document (complex goods operation, invoice, etc.).
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' to discard</param>
        ''' <param name="warehouseID">an <see cref="Goods.Warehouse.ID">ID of the warehouse</see>
        ''' to discard the goods from</param>
        ''' <param name="parentValidator">a chronologic validator of the parent document (if any)</param>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsOperationDiscardChild(ByVal goodsID As Integer, _
            ByVal warehouseID As Integer, ByVal parentValidator As IChronologicValidator) As GoodsOperationDiscard
            Return New GoodsOperationDiscard(goodsID, warehouseID, parentValidator)
        End Function

        ''' <summary>
        ''' Gets a new GoodsOperationDiscard instance as a child of a
        ''' parent document (complex goods operation, invoice, etc.).
        ''' </summary>
        ''' <param name="goodsID">an <see cref="GoodsItem.ID">ID of the goods</see>
        ''' to discard</param>
        ''' <param name="parentWarehouse">a parent document <see cref="Goods.Warehouse">
        ''' warehouse</see> to discard the goods from</param>
        ''' <param name="parentValidator">a chronologic validator of the parent document (if any)</param>
        ''' <remarks></remarks>
        Friend Shared Function NewGoodsOperationDiscardChild(ByVal goodsID As Integer, _
            ByVal parentWarehouse As WarehouseInfo, ByVal parentValidator As IChronologicValidator) As GoodsOperationDiscard
            Return New GoodsOperationDiscard(goodsID, parentWarehouse, parentValidator)
        End Function

        ''' <summary>
        ''' Gets an existing GoodsOperationDiscard instance from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID of the operation</see> to fetch</param>
        ''' <remarks></remarks>
        Public Shared Function GetGoodsOperationDiscard(ByVal id As Integer) As GoodsOperationDiscard
            Return DataPortal.Fetch(Of GoodsOperationDiscard)(New Criteria(id))
        End Function

        ''' <summary>
        ''' Gets an existing GoodsOperationDiscard instance as a child of a 
        ''' parent document from a database.
        ''' </summary>
        ''' <param name="obj">a persistence object containing the operation data</param>
        ''' <param name="parentValidator">a chronologic validator of the parent document (if any)</param>
        ''' <param name="limitationsDataSource">a datasource for the 
        ''' <see cref="OperationalLimitList">chronologic validator</see></param>
        ''' <remarks></remarks>
        Friend Shared Function GetGoodsOperationDiscardChild(ByVal obj As OperationPersistenceObject, _
            ByVal parentValidator As IChronologicValidator, _
            ByVal limitationsDataSource As DataTable) As GoodsOperationDiscard
            Return New GoodsOperationDiscard(obj, parentValidator, limitationsDataSource)
        End Function

        ''' <summary>
        ''' Deletes an existing GoodsOperationDiscard instance from a database.
        ''' </summary>
        ''' <param name="id">an <see cref="ID">ID of the operation</see> to delete</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteGoodsOperationDiscard(ByVal id As Integer)
            DataPortal.Delete(New Criteria(id))
        End Sub

        ''' <summary>
        ''' Deletes an existing GoodsOperationDiscard instance as a child
        ''' of a parent document from a database.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub DeleteGoodsOperationDiscardChild()
            DoDelete(False)
        End Sub



        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal summary As GoodsSummary, ByVal warehouseID As Integer, _
            ByVal parentValidator As IChronologicValidator)
            ' require use of factory methods
            MarkAsChild()
            Dim curWarehouse As WarehouseInfo = WarehouseInfoList.GetListChild.GetItem( _
                warehouseID, summary.DefaultWarehouseID, False)
            Create(summary, curWarehouse, parentValidator)
        End Sub

        Private Sub New(ByVal goodsID As Integer, ByVal warehouseID As Integer, _
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

        Private Sub New(ByVal obj As OperationPersistenceObject, _
            ByVal parentValidator As IChronologicValidator, _
            ByVal limitationsDataSource As DataTable)
            ' require use of factory methods
            MarkAsChild()
            Fetch(obj, parentValidator, limitationsDataSource)
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

        Private Sub Create(ByVal goodsID As Integer, ByVal warehouseID As Integer, _
            ByVal parentValidator As IChronologicValidator)
            Dim curSummary As GoodsSummary = GoodsSummary.NewGoodsSummary(goodsID)
            Dim curWarehouse As WarehouseInfo = WarehouseInfoList.GetListChild.GetItem( _
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
            If Not _Warehouse Is Nothing AndAlso Not _Warehouse.IsEmpty Then
                wd = _Warehouse.ID
            End If

            _OperationLimitations = OperationalLimitList.NewOperationalLimitList( _
                _GoodsInfo, GoodsOperationType.Discard, wd, parentValidator)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Fetch(criteria.Id)

        End Sub

        Private Sub Fetch(ByVal operationID As Integer)
            Dim obj As OperationPersistenceObject = OperationPersistenceObject. _
                GetOperationPersistenceObject(operationID, GoodsOperationType.Discard)
            Fetch(obj, Nothing, Nothing)
        End Sub

        Private Sub Fetch(ByVal obj As OperationPersistenceObject, _
            ByVal parentValidator As IChronologicValidator, _
            ByVal limitationsDataSource As DataTable)

            If obj.OperationType <> GoodsOperationType.Discard Then
                Throw New Exception(String.Format(Goods_OperationPersistenceObject_OperationTypeMismatch, _
                    _ID.ToString, ConvertLocalizedName(obj.OperationType), _
                    ConvertLocalizedName(GoodsOperationType.Discard)))
            End If

            _ID = obj.ID
            _GoodsInfo = obj.GoodsInfo
            _ComplexOperationID = obj.ComplexOperationID
            _ComplexOperationType = obj.ComplexOperationType
            _ComplexOperationHumanReadable = obj.ComplexOperationHumanReadable
            _Date = obj.OperationDate
            _Description = obj.Content
            _Ammount = -obj.Amount
            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                _NormativeUnitValue = obj.UnitValue
                _NormativeTotalValue = -obj.AccountOperationValue
            Else
                _UnitCost = obj.UnitValue
            End If
            _TotalCost = -obj.TotalValue
            _Warehouse = obj.Warehouse
            _OldWarehouseID = Warehouse.ID
            _JournalEntryID = obj.JournalEntryID
            If _JournalEntryID > 0 Then _JournalEntryType = obj.JournalEntryType
            _DocumentNumber = obj.DocNo
            _AccountGoodsDiscardCosts = obj.AccountOperation
            _InsertDate = obj.InsertDate
            _UpdateDate = obj.UpdateDate

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo, GoodsOperationType.Discard, _ID, _Date, obj.WarehouseID, _
                parentValidator, Nothing)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub


        Protected Overrides Sub DataPortal_Insert()

            If Not CanAddObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityInsertDenied)

            CheckIfCanSaveRoot()

            CheckIfCanUpdate(Nothing, Nothing)

            DoSave(False)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo, GoodsOperationType.Discard, _ID, _Date, _Warehouse.ID, _
                Nothing, Nothing)

        End Sub

        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            CheckIfCanSaveRoot()

            CheckIfCanUpdate(Nothing, Nothing)

            DoSave(False)

            _OperationLimitations = OperationalLimitList.GetOperationalLimitList( _
                _GoodsInfo, GoodsOperationType.Discard, _ID, _Date, _Warehouse.ID, _
                Nothing, Nothing)

        End Sub

        ''' <summary>
        ''' Saves a child GoodsOperationDiscard instance to a database.
        ''' </summary>
        ''' <param name="parentJournalEntryID">an <see cref="General.JournalEntry.ID">
        ''' ID of the journal entry</see> of the parent document</param>
        ''' <param name="parentComplexOperationID">an <see cref="ComplexOperationPersistenceObject.ID">
        ''' ID of the parent complex goods operation</see></param>
        ''' <param name="financialDataReadOnly">whether the parent document allows
        ''' the operation to change it's financial data</param>
        ''' <remarks></remarks>
        Friend Sub SaveChild(ByVal parentJournalEntryID As Integer, _
            ByVal parentComplexOperationID As Integer, _
            ByVal financialDataReadOnly As Boolean)
            _JournalEntryID = parentJournalEntryID
            _ComplexOperationID = parentComplexOperationID
            DoSave(financialDataReadOnly)
        End Sub

        Private Sub DoSave(ByVal financialDataReadOnly As Boolean)

            Dim discards As ConsignmentDiscardPersistenceObjectList = Nothing
            If Not financialDataReadOnly Then
                discards = GetDiscardList()
            End If

            Dim obj As OperationPersistenceObject = GetPersistenceObj()

            Dim entry As General.JournalEntry = Nothing
            If Not IsChild AndAlso _GoodsInfo.AccountingMethod <> _
                Goods.GoodsAccountingMethod.Periodic Then
                entry = GetJournalEntry()
            End If

            Using transaction As New SqlTransaction

                Try

                    If Not entry Is Nothing Then
                        entry = entry.SaveChild()
                        If IsNew Then
                            _JournalEntryID = entry.ID
                            obj.JournalEntryID = _JournalEntryID
                        End If
                    ElseIf entry Is Nothing AndAlso Not IsChild AndAlso _JournalEntryID > 0 Then
                        General.JournalEntry.DeleteJournalEntryChild(_JournalEntryID)
                        _JournalEntryID = 0
                        obj.JournalEntryID = 0
                    End If

                    obj = obj.Save(_OperationLimitations.FinancialDataCanChange _
                        AndAlso Not financialDataReadOnly, False)

                    If IsNew Then
                        _ID = obj.ID
                        _InsertDate = obj.InsertDate
                    End If
                    _UpdateDate = obj.UpdateDate

                    If Not discards Is Nothing Then
                        discards.Update(_ID)
                    End If

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

            _OldWarehouseID = _Warehouse.ID

            MarkOld()

        End Sub

        Private Function GetPersistenceObj() As OperationPersistenceObject

            Dim obj As OperationPersistenceObject
            If IsNew Then
                obj = OperationPersistenceObject.NewOperationPersistenceObject( _
                    GoodsOperationType.Discard, _GoodsInfo.ID)
            Else
                obj = OperationPersistenceObject.GetOperationPersistenceObjectForSave( _
                    _ID, GoodsOperationType.Discard, _UpdateDate, IsChild)
            End If

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Persistent Then

                obj.UnitValue = _UnitCost
                obj.AccountGeneral = -_TotalCost
                obj.AccountOperationValue = _TotalCost
                obj.AmountInWarehouse = -_Ammount

            Else

                obj.UnitValue = _NormativeUnitValue
                obj.AccountOperationValue = -_NormativeTotalValue
                obj.AmountInWarehouse = 0

            End If

            obj.AmountInPurchases = 0
            obj.AccountOperation = _AccountGoodsDiscardCosts
            obj.Amount = -_Ammount
            obj.Content = _Description
            obj.DocNo = _DocumentNumber
            obj.JournalEntryID = _JournalEntryID
            obj.OperationDate = _Date
            obj.TotalValue = -_TotalCost
            obj.Warehouse = _Warehouse
            obj.WarehouseID = _Warehouse.ID
            obj.ComplexOperationID = _ComplexOperationID

            Return obj

        End Function

        Private Function GetJournalEntry() As General.JournalEntry

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then _
                Throw New InvalidOperationException(Goods_GoodsOperationDiscard_InvalidGetJournalEntry)

            Dim result As General.JournalEntry = Nothing

            If IsNew Then
                result = General.JournalEntry.NewJournalEntryChild(DocumentType.GoodsWriteOff)
            Else
                result = General.JournalEntry.GetJournalEntryChild(_JournalEntryID, _
                    DocumentType.GoodsWriteOff)
            End If

            result.Date = _Date.Date
            result.Person = Nothing
            result.Content = String.Format(Goods_GoodsOperationDiscard_JournalEntryContent, _Description)
            result.DocNumber = _DocumentNumber

            If _OperationLimitations.FinancialDataCanChange Then

                Dim commonBookEntryList As BookEntryInternalList = GetTotalBookEntryList(False)

                result.DebetList.LoadBookEntryListFromInternalList(commonBookEntryList, False, False)
                result.CreditList.LoadBookEntryListFromInternalList(commonBookEntryList, False, False)

            End If

            If Not result.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_FailedToCreateJournalEntry, _
                    vbCrLf, result.ToString, vbCrLf, result.GetAllBrokenRules))
            End If

            Return result

        End Function



        Protected Overrides Sub DataPortal_DeleteSelf()
            DataPortal_Delete(New Criteria(_ID))
        End Sub

        Private Overloads Sub DataPortal_Delete(ByVal criteria As Criteria)

            If Not CanDeleteObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            Dim operationToDelete As GoodsOperationDiscard = New GoodsOperationDiscard
            operationToDelete.Fetch(criteria.Id)

            If operationToDelete.ComplexOperationID > 0 Then
                Throw New Exception(String.Format(Goods_GoodsOperationDiscard_InvalidDeleteChild, _
                    operationToDelete._ComplexOperationHumanReadable))
            ElseIf operationToDelete._JournalEntryType <> DocumentType.GoodsWriteOff Then
                Throw New Exception(String.Format(Goods_GoodsOperationDiscard_InvalidDeleteChild, _
                    ConvertLocalizedName(operationToDelete._JournalEntryType)))
            End If

            If Not operationToDelete._OperationLimitations.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsOperationDiscard_InvalidDelete, _
                    operationToDelete._GoodsInfo.Name, vbCrLf, operationToDelete. _
                    _OperationLimitations.FinancialDataCanChangeExplanation))
            End If

            If operationToDelete.JournalEntryID > 0 Then
                IndirectRelationInfoList.CheckIfJournalEntryCanBeDeleted( _
                    operationToDelete.JournalEntryID, DocumentType.GoodsWriteOff)
            End If

            operationToDelete.DoDelete(True)

        End Sub

        Private Sub DoDelete(ByVal deleteEncapsulatedJournalEntry As Boolean)

            Using transaction As New SqlTransaction

                Try

                    OperationPersistenceObject.Delete(_ID, False, True)

                    If deleteEncapsulatedJournalEntry AndAlso _JournalEntryID > 0 Then _
                        General.JournalEntry.DeleteJournalEntryChild(_JournalEntryID)

                    transaction.Commit()

                Catch ex As Exception
                    transaction.SetNonSqlException(ex)
                    Throw
                End Try

            End Using

        End Sub


        Friend Sub CheckIfCanDelete(ByVal limitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator)

            If IsNew Then Exit Sub

            _OperationLimitations = OperationalLimitList.GetUpdatedOperationalLimitList( _
                _OperationLimitations, parentValidator, limitationsDataSource)

            If Not _OperationLimitations.FinancialDataCanChange Then
                Throw New Exception(String.Format(Goods_GoodsOperationDiscard_InvalidDelete, _
                    _GoodsInfo.Name, vbCrLf, _OperationLimitations.FinancialDataCanChangeExplanation))
            End If

        End Sub

        Friend Sub CheckIfCanUpdate(ByVal limitationsDataSource As DataTable, _
            ByVal parentValidator As IChronologicValidator)

            _OperationLimitations = OperationalLimitList.GetUpdatedOperationalLimitList( _
                _OperationLimitations, parentValidator, limitationsDataSource)

            ValidationRules.CheckRules()
            If Not IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                        GetErrorString()))
            End If

        End Sub

        ''' <summary>
        ''' Gets a total book entry list required for the goods discard.
        ''' </summary>
        ''' <param name="preloadCostsValues">whether to preload 
        ''' <see cref="TotalCost">TotalCost</see> and <see cref="UnitCost">UnitCost</see> values</param>
        ''' <remarks>The method inter alia preloads <see cref="TotalCost">TotalCost</see> and
        ''' <see cref="UnitCost">UnitCost</see> values in order to fetch correct 
        ''' book entries. However preload yields invalid results if a parent operation 
        ''' contains multiple discard (or transfer) operations with the same goods 
        ''' in the same warehouse. (they are not ""visible"" to each other 
        ''' therefore the consignments to discard overlap) In the latter case
        ''' a journal entry has to be saved twice by the parent operation -
        ''' before the discard (or transfer) operations (to pass an ID of the journal entry)
        ''' and after the discard (or transfer) operations (to get correct book entries values).</remarks>
        Friend Function GetTotalBookEntryList(ByVal preloadCostsValues As Boolean) As BookEntryInternalList

            Dim result As BookEntryInternalList = _
               BookEntryInternalList.NewBookEntryInternalList(BookEntryType.Debetas)

            If _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                Return result
            End If

            If preloadCostsValues AndAlso _OperationLimitations.FinancialDataCanChange Then
                GetDiscardList()
            End If

            result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Kreditas, _
                _Warehouse.WarehouseAccount, _TotalCost, Nothing))

            result.Add(BookEntryInternal.NewBookEntryInternal(BookEntryType.Debetas, _
                _AccountGoodsDiscardCosts, _TotalCost, Nothing))

            Return result

        End Function

        ''' <summary>
        ''' Fetches the final <see cref="TotalCost">TotalCost</see> and
        ''' <see cref="UnitCost">UnitCost</see> values. However it yields invalid
        ''' results if a parent operation contains multiple discard (or transfer)
        ''' operations with the same goods in the same warehouse. (they are not 
        ''' ""visible"" to each other therefore the consignments to discard overlap) 
        ''' In the latter case a journal entry has to be saved twice by the parent operation -
        ''' before the discard (or transfer) operations (to pass an ID of the journal entry)
        ''' and after the discard (or transfer) operations (to get correct book entries values).
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub PreloadCosts()
            GetDiscardList()
        End Sub

        Private Function GetDiscardList() As ConsignmentDiscardPersistenceObjectList

            Dim result As ConsignmentDiscardPersistenceObjectList = Nothing

            If Not _OperationLimitations.FinancialDataCanChange OrElse _
                _GoodsInfo.AccountingMethod = Goods.GoodsAccountingMethod.Periodic Then
                Return result
            End If

            Dim consignments As ConsignmentPersistenceObjectList = _
                ConsignmentPersistenceObjectList.NewConsignmentPersistenceObjectList( _
                _GoodsInfo.ID, _Warehouse.ID, _ID, 0, (_GoodsInfo.ValuationMethod _
                = Goods.GoodsValuationMethod.LIFO))

            consignments.RemoveLateEntries(_Date)

            Dim discards As ConsignmentDiscardPersistenceObjectList = _
                ConsignmentDiscardPersistenceObjectList.NewConsignmentDiscardPersistenceObjectList( _
                consignments, _Ammount, _GoodsInfo.Name)

            If Not IsNew Then

                Dim currentDiscards As ConsignmentDiscardPersistenceObjectList = _
                    ConsignmentDiscardPersistenceObjectList. _
                    GetConsignmentDiscardPersistenceObjectList(_ID)

                currentDiscards.MergeChangedList(discards)

                result = currentDiscards

            Else

                result = discards

            End If

            _TotalCost = result.GetTotalValue
            _Ammount = result.GetTotalAmount

            If Not CRound(_Ammount, ROUNDAMOUNTGOODS) > 0 Then
                Throw New InvalidDataException(Goods_GoodsOperationDiscard_InvalidAmountInDiscardList)
            End If

            _UnitCost = CRound(_TotalCost / _Ammount, ROUNDUNITGOODS)

            Return result

        End Function

        Private Sub CheckIfCanSaveRoot()

            If _ComplexOperationID > 0 Then
                Throw New Exception(String.Format(Goods_GoodsOperationDiscard_InvalidSaveChild, _
                    _ComplexOperationHumanReadable))
            ElseIf _JournalEntryType <> DocumentType.GoodsWriteOff Then
                Throw New Exception(String.Format(Goods_GoodsOperationDiscard_InvalidSaveChild, _
                    ConvertLocalizedName(_JournalEntryType)))
            End If

        End Sub

#End Region

    End Class

End Namespace