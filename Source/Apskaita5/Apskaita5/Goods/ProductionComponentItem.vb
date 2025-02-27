﻿Imports ApskaitaObjects.Attributes

Namespace Goods

    ''' <summary>
    ''' Represents production template (""recipe"") component item, i.e. 
    ''' goods (components, stock, etc.) that are consumed when producing 
    ''' the product goods. (when applying the template).
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="ProductionComponentItemList">ProductionComponentItemList</see>.
    ''' Values are stored in the database table kalkuliac_d.</remarks>
    <Serializable()> _
    Public NotInheritable Class ProductionComponentItem
        Inherits BusinessBase(Of ProductionComponentItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Goods As GoodsInfo = Nothing
        Private _Amount As Double = 0
        Private _NormativeUnitCost As Double = 0


        ''' <summary>
        ''' Gets an ID of the template production component item
        ''' that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Data is stored in database field kalkuliac_d.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets goods that are the component of (stock for) the goods produced.
        ''' </summary>
        ''' <remarks>Data is stored in database field kalkuliac_d.P_ID.</remarks>
        <GoodsField(ValueRequiredLevel.Mandatory)> _
        Public Property Goods() As GoodsInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Goods
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As GoodsInfo)
                CanWriteProperty(True)
                If Not (_Goods Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Goods Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _Goods.ID = value.ID) Then
                    _Goods = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an amount of component (stock) goods needed to produce a 
        ''' <see cref="ProductionCalculation.Amount">standard amount of goods</see>.
        ''' </summary>
        ''' <remarks>Data is stored in database field kalkuliac_d.Kiek.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDAMOUNTGOODS)> _
        Public Property Amount() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Amount, ROUNDAMOUNTGOODS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Amount, ROUNDAMOUNTGOODS) <> CRound(value, ROUNDAMOUNTGOODS) Then
                    _Amount = CRound(value, ROUNDAMOUNTGOODS)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets standard (normative) costs of the component (stock) goods per unit.
        ''' Only applicable when the component (stock) goods are accounted
        ''' using <see cref="GoodsAccountingMethod.Periodic">Periodic</see>
        ''' accounting method (because in this case the actual costs cannot be
        ''' calculated).
        ''' </summary>
        ''' <remarks>Data is stored in database field kalkuliac_d.NormativeUnitCost.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDUNITGOODS)> _
        Public Property NormativeUnitCost() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_NormativeUnitCost, ROUNDUNITGOODS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_NormativeUnitCost, ROUNDUNITGOODS) <> CRound(value, ROUNDUNITGOODS) Then
                    _NormativeUnitCost = CRound(value, ROUNDUNITGOODS)
                    PropertyHasChanged()
                End If
            End Set
        End Property



        ''' <summary>
        ''' Gets a human readable description of all the validation errors.
        ''' Returns <see cref="String.Empty" /> if no errors.
        ''' </summary>
        ''' <returns>A human readable description of all the validation errors.
        ''' Returns <see cref="String.Empty" /> if no errors.</returns>
        ''' <remarks></remarks>
        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
        End Function

        ''' <summary>
        ''' Gets a human readable description of all the validation warnings.
        ''' Returns <see cref="String.Empty" /> if no warnings.
        ''' </summary>
        ''' <returns>A human readable description of all the validation warnings.
        ''' Returns <see cref="String.Empty" /> if no warnings.</returns>
        ''' <remarks></remarks>
        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
        End Function

        ''' <summary>
        ''' Whether there are any validation warnings.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function HasWarnings() As Boolean
            Return Me.BrokenRulesCollection.WarningCount > 0
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            If _Goods Is Nothing OrElse _Goods.IsEmpty Then
                Return String.Format(My.Resources.Goods_ProductionComponentItem_ToString, _
                    "", DblParser(_Amount, ROUNDUNITGOODS))
            Else
                Return String.Format(My.Resources.Goods_ProductionComponentItem_ToString, _
                    _Goods.Name, DblParser(_Amount, ROUNDUNITGOODS))
            End If
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.ValueObjectFieldValidation, _
                New Csla.Validation.RuleArgs("Goods"))
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.DoubleFieldValidation, _
                New Csla.Validation.RuleArgs("Amount"))

            ValidationRules.AddRule(AddressOf NormativeUnitCostValidation, _
                New Csla.Validation.RuleArgs("NormativeUnitCost"))

            ValidationRules.AddDependantProperty("Goods", "NormativeUnitCost", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property NormativeUnitCost is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function NormativeUnitCostValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As ProductionComponentItem = DirectCast(target, ProductionComponentItem)

            If Not valObj._Goods Is Nothing AndAlso Not valObj._Goods.IsEmpty _
                AndAlso valObj._Goods.AccountingMethod = GoodsAccountingMethod.Periodic Then

                Return CommonValidation.CommonValidation.DoubleFieldValidation(target, e)

            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewProductionComponentItem() As ProductionComponentItem
            Dim result As New ProductionComponentItem
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function GetProductionComponentItem(ByVal dr As DataRow) As ProductionComponentItem
            Return New ProductionComponentItem(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(1), 0)
            _Amount = CDblSafe(dr.Item(3), ROUNDAMOUNTGOODS, 0)
            _NormativeUnitCost = CDblSafe(dr.Item(4), ROUNDUNITGOODS, 0)
            _Goods = GoodsInfo.GetGoodsInfo(dr, 5)

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert(ByVal parent As ProductionCalculation)

            Dim myComm As New SQLCommand("InsertProductionItem")
            AddWithParams(myComm)
            myComm.AddParam("?AA", parent.ID)
            myComm.AddParam("?AB", Utilities.ConvertDatabaseCharID(ProductionComponentType.Component))

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As ProductionCalculation)

            Dim myComm As New SQLCommand("UpdateProductionItem")
            myComm.AddParam("?CD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteProductionItem")
            myComm.AddParam("?CD", _ID)

            myComm.Execute()

            MarkNew()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?AC", _Goods.ID)
            myComm.AddParam("?AD", 0)
            myComm.AddParam("?AE", CRound(_Amount, 6))
            myComm.AddParam("?AF", CRound(_NormativeUnitCost, 6))

        End Sub

#End Region

    End Class

End Namespace
