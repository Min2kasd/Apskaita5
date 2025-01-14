﻿Imports Csla
Imports ApskaitaObjects
Imports ApskaitaObjects.Attributes
Imports AccCommon
Imports System.ComponentModel
Imports AccDataBindingsWinForms.CachedInfoLists
Imports AccControlsWinForms
Imports AccControlsWinForms.WebControls

Friend Class F_CurrencyRateChangeImpactCalculator

    <Serializable()> _
    Friend Class CurrencyRateCalculationItem
        Inherits BusinessBase(Of CurrencyRateCalculationItem)

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _Date As Date = Today
        Private _Sum As Double = 0
        Private _CurrencyCode As String = GetCurrentCompany.BaseCurrency
        Private _CurrencyRateStart As Double = 0
        Private _SumLTLStart As Double = 0
        Private _CurrencyRateEnd As Double = 0
        Private _SumLTLEnd As Double = 0
        Private _CurrencyRateChangeImpact As Double = 0


        Public Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Date)
                If _Date.Date <> value.Date Then
                    _Date = value.Date
                    PropertyHasChanged()
                End If
            End Set
        End Property

        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public Property Sum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Sum)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_Sum) <> CRound(value) Then
                    _Sum = CRound(value)
                    PropertyHasChanged()
                    Recalculate()
                End If
            End Set
        End Property

        <CurrencyField(ValueRequiredLevel.Mandatory)> _
        Public Property CurrencyCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrencyCode.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _CurrencyCode.Trim <> value.Trim Then
                    _CurrencyCode = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        <DoubleField(ValueRequiredLevel.Mandatory, False, 6)> _
        Public Property CurrencyRateStart() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateStart, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_CurrencyRateStart, 6) <> CRound(value, 6) Then
                    _CurrencyRateStart = CRound(value, 6)
                    PropertyHasChanged()
                    Recalculate()
                End If
            End Set
        End Property

        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property SumLTLStart() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTLStart)
            End Get
        End Property

        <DoubleField(ValueRequiredLevel.Mandatory, False, 6)> _
        Public Property CurrencyRateEnd() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateEnd, 6)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If CRound(_CurrencyRateEnd, 6) <> CRound(value, 6) Then
                    _CurrencyRateEnd = CRound(value, 6)
                    PropertyHasChanged()
                    Recalculate()
                End If
            End Set
        End Property

        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property SumLTLEnd() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SumLTLEnd)
            End Get
        End Property

        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property CurrencyRateChangeImpact() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_CurrencyRateChangeImpact)
            End Get
        End Property


        Private Sub Recalculate()
            _SumLTLStart = CRound(CRound(_Sum) * CRound(_CurrencyRateStart, 6))
            _SumLTLEnd = CRound(CRound(_Sum) * CRound(_CurrencyRateEnd, 6))
            _CurrencyRateChangeImpact = CRound(_SumLTLEnd - _SumLTLStart)
            PropertyHasChanged("SumLTLStart")
            PropertyHasChanged("SumLTLEnd")
            PropertyHasChanged("CurrencyRateChangeImpact")
        End Sub

        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return ""
        End Function

#End Region

#Region " Factory Methods "

        Public Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

#End Region

    End Class

    Private WithEvents Obj As New BindingList(Of CurrencyRateCalculationItem)
    Private _SuspendCalculations As Boolean = False
    Private _ListViewManager As DataListViewEditControlManager(Of CurrencyRateCalculationItem)


    Private Sub F_CurrencyRateChangeImpactCalculator_FormClosing(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        MyCustomSettings.GetFormLayout(Me)
        MyCustomSettings.GetListViewLayOut(ItemsDataListView)
    End Sub

    Private Sub F_CurrencyRateChangeImpactCalculator_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Me.Load

        _ListViewManager = New DataListViewEditControlManager(Of CurrencyRateCalculationItem) _
            (ItemsDataListView, Nothing, AddressOf OnItemsDelete, _
             AddressOf OnItemAdd, Nothing, Nothing)

        Obj.AllowEdit = True
        Obj.AllowNew = True
        Obj.AllowRemove = True
        F_CurrencyRateChangeImpactCalculator_CurrencyRateCalculationItemBindingSource.DataSource = Obj

        MyCustomSettings.SetListViewLayOut(ItemsDataListView)
        MyCustomSettings.SetFormLayout(Me)

    End Sub


    Private Sub OnItemsDelete(ByVal items As CurrencyRateCalculationItem())
        If items Is Nothing OrElse items.Length < 1 OrElse Obj Is Nothing Then Exit Sub
        For Each item As CurrencyRateCalculationItem In items
            Obj.Remove(item)
        Next
    End Sub

    Private Sub OnItemAdd()
        If Obj Is Nothing Then Exit Sub
        Obj.AddNew()
    End Sub

    Private Sub Obj_ListChanged(ByVal sender As Object, _
        ByVal e As System.ComponentModel.ListChangedEventArgs) Handles Obj.ListChanged

        If _SuspendCalculations Then Exit Sub

        Dim sumStart As Double = 0
        Dim sumEnd As Double = 0
        Dim sumDifference As Double = 0

        For Each i As CurrencyRateCalculationItem In Obj
            sumStart = CRound(sumStart + i.SumLTLStart)
            sumEnd = CRound(sumEnd + i.SumLTLEnd)
            sumDifference = CRound(sumDifference + i.CurrencyRateChangeImpact)
        Next

        SumStartAccTextBox.DecimalValue = sumStart
        SumEndAccTextBox.DecimalValue = sumEnd
        CurrencyRateChangeImpactAccTextBox.DecimalValue = sumDifference

    End Sub

    Private Sub GetCurrencyRatesButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles GetCurrencyRatesButton.Click

        If Obj Is Nothing Then Exit Sub

        Dim paramList As New List(Of CurrencyRate.CurrencyRateParam)

        For Each b As CurrencyRateCalculationItem In Obj
            paramList.Add(New CurrencyRate.CurrencyRateParam(b.Date, b.CurrencyCode))
            paramList.Add(New CurrencyRate.CurrencyRateParam(Me.CalculationDateAccDatePicker.Value.Date, _
                b.CurrencyCode))
        Next

        If paramList.Count < 1 Then Exit Sub

        If Not YesOrNo("Gauti valiutų kursus?") Then Exit Sub

        Dim factory As CurrencyRateFactoryBase = Nothing
        Dim result As List(Of CurrencyRate) = Nothing
        Dim baseCurrency As String = GetCurrentCompany.BaseCurrency
        Try
            factory = WebControls.GetCurrencyRateFactory(baseCurrency)
            result = WebControls.GetCurrencyRateListWithProgress(paramList.ToArray, factory)
        Catch ex As Exception
            ShowError(ex, paramList)
            Exit Sub
        End Try

        If Not result Is Nothing AndAlso result.Count > 0 Then

            _SuspendCalculations = True

            For Each b As CurrencyRateCalculationItem In Obj
                b.CurrencyRateStart = CurrencyRate.GetRate(result, b.Date, b.CurrencyCode, baseCurrency)
                b.CurrencyRateEnd = CurrencyRate.GetRate(result, Me.CalculationDateAccDatePicker.Value.Date, _
                    b.CurrencyCode, baseCurrency)
            Next

            _SuspendCalculations = False

            Obj_ListChanged(Obj, New System.ComponentModel.ListChangedEventArgs( _
                System.ComponentModel.ListChangedType.Reset, 0))

        End If

    End Sub

End Class