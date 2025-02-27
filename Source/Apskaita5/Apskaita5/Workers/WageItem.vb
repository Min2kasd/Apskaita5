﻿Imports ApskaitaObjects.Attributes
Imports Csla.Validation

Namespace Workers

    ''' <summary>
    ''' Represents a wage calculation for a particular labour contract for a particular month.
    ''' </summary>
    ''' <remarks>Should only be used as a child of a <see cref="WageItemList">WageItemList</see>.
    ''' Values are stored in the database table du_ziniarastis_d.</remarks>
    <Serializable()> _
    Public NotInheritable Class WageItem
        Inherits BusinessBase(Of WageItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _FinancialDataCanChange As Boolean = True
        Private _PersonId As Integer = 0
        Private _PersonName As String = ""
        Private _PersonCode As String = ""
        Private _PersonCodeSodra As String = ""
        Private _ContractSerial As String = ""
        Private _ContractNumber As Integer = 0
        Private _WorkLoad As Double = 0
        Private _IsChecked As Boolean = False
        Private _ApplicableVduHourly As Double = 0
        Private _ApplicableVduDaily As Double = 0
        Private _NormalHoursWorked As Double = 0
        Private _HRHoursWorked As Double = 0
        Private _ONHoursWorked As Double = 0
        Private _SCHoursWorked As Double = 0
        Private _TotalHoursWorked As Double = 0
        Private _TruancyHours As Double = 0
        Private _TotalDaysWorked As Integer = 0
        Private _HolidayWD As Integer = 0
        Private _HolidayRD As Integer = 0
        Private _SickDays As Integer = 0
        Private _StandartHours As Double = 0
        Private _StandartDays As Integer = 0
        Private _ConventionalWage As Double = 0
        Private _WageType As WageType = WageType.Position
        Private _WageTypeHumanReadable As String = ""
        Private _ConventionalExtraPay As Double = 0
        Private _BonusPay As Double = 0
        Private _BonusType As BonusType = BonusType.k
        Private _OtherPayRelatedToWork As Double = 0
        Private _OtherPayNotRelatedToWork As Double = 0
        Private _PayOutWage As Double = 0
        Private _PayOutExtraPay As Double = 0
        Private _ActualHourlyPay As Double = 0
        Private _PayOutHR As Double = 0
        Private _PayOutON As Double = 0
        Private _PayOutSC As Double = 0
        Private _PayOutSickLeave As Double = 0
        Private _AnnualWorkingDaysRatio As Double = 0
        Private _UnusedHolidayDaysForCompensation As Double = 0
        Private _PayOutHoliday As Double = 0
        Private _PayOutUnusedHolidayCompensation As Double = 0
        Private _PayOutRedundancyPay As Double = 0
        Private _PayOutTotal As Double = 0
        Private _BaseGpm As Double = 0
        Private _BasePsd As Double = 0
        Private _BasePsdSickLeave As Double = 0
        Private _BaseSodra As Double = 0
        Private _BaseGuaranteeFund As Double = 0
        Private _DeductionGpm As Double = 0
        Private _DeductedGpmSickLeave As Double = 0
        Private _DeductionPsd As Double = 0
        Private _DeductionPsdSickLeave As Double = 0
        Private _DeductionSodra As Double = 0
        Private _DeductionImprest As Double = 0
        Private _ImprestPending As Double = 0
        Private _DeductionOtherApplicable As Double = 0
        Private _DeductionOther As Double = 0
        Private _ContributionSodra As Double = 0
        Private _ContributionPsd As Double = 0
        Private _ContributionGuaranteeFund As Double = 0
        Private _PayOutTotalAfterTaxes As Double = 0
        Private _PayableTotal As Double = 0
        Private _PayOutTotalAfterDeductions As Double = 0
        Private _BaseNPD As Double = 0
        Private _ApplicableNPD As Double = 0
        Private _ApplicablePNPD As Double = 0
        Private _NPD As Double = 0
        Private _PNPD As Double = 0
        Private _UsedNPD As Double = 0
        Private _NpdSickLeave As Double = 0
        Private _OtherIncome As Double = 0
        Private _HoursForVdu As Double = 0
        Private _DaysForVdu As Integer = 0
        Private _WageForVdu As Double = 0
        Private _PayedOutDate As SmartDate = New SmartDate(False)


        ''' <summary>
        ''' Gets an ID of the wage calculation item that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Returnes TRUE if the parent wage sheet allows financial changes due to business restrains.
        ''' </summary>
        ''' <remarks>Chronologic business restrains are provided by a <see cref="SheetChronologicValidator">SheetChronologicValidator</see>.</remarks>
        Public ReadOnly Property FinancialDataCanChange() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.Person.ID">ID of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.AK.</remarks>
        Public ReadOnly Property PersonID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonId
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.Person.Name">name of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.Person.Name">General.Person.Name</see>.</remarks>
        Public ReadOnly Property PersonName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonName.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.Person.Code">personal code of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.Person.Code">General.Person.Code</see>.</remarks>
        Public ReadOnly Property PersonCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.Person.CodeSODRA">social security code of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.Person.CodeSODRA">General.Person.CodeSODRA</see>.</remarks>
        Public ReadOnly Property PersonCodeSODRA() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonCodeSodra.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets the serial number (code) of the current labour contract.
        ''' </summary>
        ''' <remarks>A labour contract is identified by a <see cref="WageItem.ContractSerial">serial number</see> 
        ''' and <see cref="WageItem.ContractNumber">running number</see> pair.
        ''' Value is stored in the database table du_ziniarastis_d.DS_Serija.</remarks>
        Public ReadOnly Property ContractSerial() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractSerial.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets the running number of the current labour contract.
        ''' </summary>
        ''' <remarks>A labour contract is identified by a <see cref="WageItem.ContractSerial">serial number</see> 
        ''' and <see cref="WageItem.ContractNumber">running number</see> pair.
        ''' Value is stored in the database table du_ziniarastis_d.DS_NR.</remarks>
        Public ReadOnly Property ContractNumber() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractNumber
            End Get
        End Property

        ''' <summary>
        ''' Gets the current workload (ratio between contractual work hours and gauge work hours (40H/Week)) for the current labour contract.
        ''' </summary>
        ''' <remarks>Used to approximately calculate scheduled work hours.
        ''' Value is stored in the database table du_ziniarastis_d.Kruvis.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKLOAD, True, 0.005, 1.0, False)> _
        Public ReadOnly Property WorkLoad() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_WorkLoad, ROUNDWORKLOAD)
            End Get
        End Property


        ''' <summary>
        ''' Whether to include the item in the wage sheet.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property IsChecked() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsChecked
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _IsChecked <> value Then
                    _IsChecked = value
                    PropertyHasChanged()
                End If
            End Set
        End Property


        ''' <summary>
        ''' Gets or sets the currently applicable average wage per hour for the current labour contract.
        ''' </summary>
        ''' <remarks>Could be set manualy or calculated using <see cref="ActiveReports.WorkersVDUInfoList">WorkersVDUInfoList</see> object.
        ''' Value is stored in the database table du_ziniarastis_d.VDU_val.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property ApplicableVDUHourly() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ApplicableVduHourly)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_ApplicableVduHourly) <> CRound(value) Then
                    _ApplicableVduHourly = CRound(value)
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the currently applicable average wage per day for the current labour contract.
        ''' </summary>
        ''' <remarks>Could be set manualy or calculated using <see cref="ActiveReports.WorkersVDUInfoList">WorkersVDUInfoList</see> object.
        ''' Value is stored in the database table du_ziniarastis_d.VDU_dien.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property ApplicableVDUDaily() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ApplicableVduDaily)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_ApplicableVduDaily) <> CRound(value) Then
                    _ApplicableVduDaily = CRound(value)
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the actual work hours for the current labour contract for the current month, 
        ''' that are paid normaly, without applying special rates, e.g. overtime rate, etc.
        ''' (excluding hours that are accounted separately, e.g. <see cref="HRHoursWorked">work hours during public holidays and rest days</see>, etc.)
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Val.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, ROUNDWORKHOURS)> _
        Public Property NormalHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_NormalHoursWorked, ROUNDWORKHOURS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_NormalHoursWorked, ROUNDWORKHOURS) <> CRound(value, ROUNDWORKHOURS) Then
                    _NormalHoursWorked = CRound(value, ROUNDWORKHOURS)
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the actual work hours during public holidays and rest days 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.PS.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public Property HRHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_HRHoursWorked, ROUNDWORKHOURS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_HRHoursWorked, ROUNDWORKHOURS) <> CRound(value, ROUNDWORKHOURS) Then
                    _HRHoursWorked = CRound(value, ROUNDWORKHOURS)
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the actual overtime and night work hours for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.NV.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public Property ONHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ONHoursWorked, ROUNDWORKHOURS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_ONHoursWorked, ROUNDWORKHOURS) <> CRound(value, ROUNDWORKHOURS) Then
                    _ONHoursWorked = CRound(value, ROUNDWORKHOURS)
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the actual non-safe work hours for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.YS.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public Property SCHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_SCHoursWorked, ROUNDWORKHOURS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_SCHoursWorked, ROUNDWORKHOURS) <> CRound(value, ROUNDWORKHOURS) Then
                    _SCHoursWorked = CRound(value, ROUNDWORKHOURS)
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total actual work hours for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value equals <see cref="NormalHoursWorked">NormalHoursWorked</see> +
        ''' <see cref="HRHoursWorked">HRHoursWorked</see> +
        ''' <see cref="ONHoursWorked">ONHoursWorked</see> +
        ''' <see cref="SCHoursWorked">SCHoursWorked</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, ROUNDWORKHOURS)> _
        Public ReadOnly Property TotalHoursWorked() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalHoursWorked, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the total actual truancy hours for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Prav.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public Property TruancyHours() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TruancyHours, ROUNDWORKHOURS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_TruancyHours, ROUNDWORKHOURS) <> CRound(value, ROUNDWORKHOURS) Then
                    _TruancyHours = CRound(value, ROUNDWORKHOURS)
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the total actual work days for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Dien.</remarks>
        <IntegerField(ValueRequiredLevel.Recommended, False, True, 0, 31, False)> _
        Public Property TotalDaysWorked() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TotalDaysWorked
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _TotalDaysWorked <> value Then
                    _TotalDaysWorked = value
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the number of granted annual holiday days, that would normaly be considered as work days, 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Atost.</remarks>
        <IntegerField(ValueRequiredLevel.Optional, False)> _
        Public Property HolidayWD() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HolidayWD
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _HolidayWD <> value Then
                    _HolidayWD = value
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the number of granted annual holiday days, that would normaly be considered as rest days, 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Atost_n.</remarks>
        <IntegerField(ValueRequiredLevel.Optional, False)> _
        Public Property HolidayRD() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HolidayRD
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _HolidayRD <> value Then
                    _HolidayRD = value
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the amount of accumulated (unused) annual holiday days that shall be compensated when terminating the contract.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.HolidayDaysCompensated.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDACCUMULATEDHOLIDAY)> _
        Public Property UnusedHolidayDaysForCompensation() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnusedHolidayDaysForCompensation, ROUNDACCUMULATEDHOLIDAY)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_UnusedHolidayDaysForCompensation, ROUNDACCUMULATEDHOLIDAY) _
                    <> CRound(value, ROUNDACCUMULATEDHOLIDAY) Then
                    _UnusedHolidayDaysForCompensation = CRound(value, ROUNDACCUMULATEDHOLIDAY)
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the number of sick leave days, that are payed by the employer, 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Nedarb.</remarks>
        <IntegerField(ValueRequiredLevel.Optional, False, True, 0, 10, False)> _
        Public Property SickDays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SickDays
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _SickDays <> value Then
                    _SickDays = value
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the total scheduled work hours for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.D_val.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, ROUNDWORKHOURS, True, 0.0, 200.0, False)> _
        Public Property StandartHours() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_StandartHours, ROUNDWORKHOURS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_StandartHours, ROUNDWORKHOURS) <> CRound(value, ROUNDWORKHOURS) Then
                    _StandartHours = CRound(value, ROUNDWORKHOURS)
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the number of scheduled work days for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.D_dien.</remarks>
        <IntegerField(ValueRequiredLevel.Mandatory, False, True, 0, 31, False)> _
        Public Property StandartDays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _StandartDays
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _StandartDays <> value Then
                    _StandartDays = value
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the current applicable wage for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.DU.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property ConventionalWage() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ConventionalWage)
            End Get
        End Property

        ''' <summary>
        ''' Gets the <see cref="Workers.WageType">type</see> of the current applicable wage 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.DU_tipas.</remarks>
        Public ReadOnly Property WageType() As WageType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WageType
            End Get
        End Property

        ''' <summary>
        ''' Gets the human readable (regionalized) description of the <see cref="Workers.WageType">type</see> 
        ''' of the current applicable wage for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.DU_tipas.</remarks>
        <LocalizedEnumField(GetType(WageType), False, "")> _
        Public ReadOnly Property WageTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WageTypeHumanReadable
            End Get
        End Property

        ''' <summary>
        ''' Gets the current applicable extra pay for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Priedai.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property ConventionalExtraPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ConventionalExtraPay)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the bonus for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Premija.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property BonusPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BonusPay)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_BonusPay) <> CRound(value) Then
                    _BonusPay = CRound(value)
                    PropertyHasChanged()
                    RecalculateTotalPay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="Workers.BonusType">type</see> of the bonus for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Pr_tipas.</remarks>
        Public Property BonusType() As BonusType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BonusType
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As BonusType)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _BonusType <> value Then
                    _BonusType = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the amount of other types of pay, that are related to the work done 
        ''' (included in average salary, e.g. variable extra pay), for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Kitos_s.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property OtherPayRelatedToWork() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OtherPayRelatedToWork)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_OtherPayRelatedToWork) <> CRound(value) Then
                    _OtherPayRelatedToWork = CRound(value)
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the amount of other types of pay, that are NOT related to the work done 
        ''' (NOT included in average salary, e.g. various compensations), for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Kitos.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property OtherPayNotRelatedToWork() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OtherPayNotRelatedToWork)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_OtherPayNotRelatedToWork) <> CRound(value) Then
                    _OtherPayNotRelatedToWork = CRound(value)
                    PropertyHasChanged()
                    RecalculateTotalPay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total calculated amount of <see cref="ConventionalWage">wage</see> for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is calculated in proportion to the ratio of 
        ''' <see cref="NormalHoursWorked">NormalHoursWorked</see> and <see cref="StandartHours">StandartHours</see>.
        ''' Value is stored in the database table du_ziniarastis_d.CalculatedWage.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2)> _
        Public ReadOnly Property PayOutWage() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutWage)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total calculated amount of <see cref="ConventionalExtraPay">extra pay</see> for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is calculated in proportion to the ratio of 
        ''' <see cref="NormalHoursWorked">NormalHoursWorked</see> and <see cref="StandartHours">StandartHours</see>.
        ''' Value is stored in the database table du_ziniarastis_d.CalculatedExtraPay.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property PayOutExtraPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutExtraPay)
            End Get
        End Property

        ''' <summary>
        ''' Gets the base hourly pay for <see cref="PayOutHR">PayOutHR</see>, 
        ''' <see cref="PayOutON">PayOutON</see> and <see cref="PayOutSC">PayOutSC</see>.
        ''' </summary>
        ''' <remarks>Value equals (PayOutWage + PayOutExtraPay + OtherPayRelatedToWork) / NormalHoursWorked.
        ''' Value is stored in the database table du_ziniarastis_d.Kitos.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property ActualHourlyPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ActualHourlyPay)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated pay for work during public holidays and rest days.
        ''' </summary>
        ''' <remarks>Value equals <see cref="ActualHourlyPay">ActualHourlyPay</see> multiplied by
        ''' <see cref="CompanyWageRates.RateHR">CompanyWageRates.RateHR</see>.
        ''' Value is stored in the database table du_ziniarastis_d.CalculatedHR.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property PayOutHR() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutHR)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated pay for overtime and night work.
        ''' </summary>
        ''' <remarks>Value equals <see cref="ActualHourlyPay">ActualHourlyPay</see> multiplied by
        ''' <see cref="CompanyWageRates.RateON">CompanyWageRates.RateON</see>.
        ''' Value is stored in the database table du_ziniarastis_d.CalculatedON.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property PayOutON() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutON)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated pay for dangerous/unsafe work.
        ''' </summary>
        ''' <remarks>Value equals <see cref="ActualHourlyPay">ActualHourlyPay</see> multiplied by
        ''' <see cref="CompanyWageRates.RateSC">CompanyWageRates.RateSC</see>.
        ''' Value is stored in the database table du_ziniarastis_d.CalculatedSC.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property PayOutSC() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutSC)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated benefit (pay) for sick leave (payed by the employer).
        ''' </summary>
        ''' <remarks>Value equals <see cref="ApplicableVDUDaily">ApplicableVDUDaily</see> multiplied by
        ''' <see cref="CompanyWageRates.RateSickLeave">CompanyWageRates.RateSickLeave</see>.
        ''' Value is stored in the database table du_ziniarastis_d.CalculatedSickLeave.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property PayOutSickLeave() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutSickLeave)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the ratio of work and calendar days.
        ''' </summary>
        ''' <remarks>Used when calculating compensation for unused annual holidays.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKDAYSRATIO, True, 0.0027, 1.0, False)> _
        Public Property AnnualWorkingDaysRatio() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_AnnualWorkingDaysRatio, ROUNDWORKDAYSRATIO)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_AnnualWorkingDaysRatio, ROUNDWORKDAYSRATIO) <> CRound(value, ROUNDWORKDAYSRATIO) Then
                    _AnnualWorkingDaysRatio = CRound(value, ROUNDWORKDAYSRATIO)
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the calculated pay for the annual holidays.
        ''' </summary>
        ''' <remarks>Value equals <see cref="ApplicableVDUDaily">ApplicableVDUDaily</see>
        ''' multiplied by <see cref="HolidayWD">HolidayWD</see>.
        ''' Value is stored in the database table du_ziniarastis_d.P_Atost.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property PayOutHoliday() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutHoliday)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated compensation for the accumulated (unused) annual holidays.
        ''' </summary>
        ''' <remarks>Value equals <see cref="ApplicableVDUDaily">ApplicableVDUDaily</see>
        ''' multiplied by <see cref="UnusedHolidayDaysForCompensation">UnusedHolidayDaysForCompensation</see>
        ''' and multiplied by <see cref="AnnualWorkingDaysRatio">AnnualWorkingDaysRatio</see>.
        ''' Value is stored in the database table du_ziniarastis_d.P_Atost.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property PayOutUnusedHolidayCompensation() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutUnusedHolidayCompensation)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the amount of redundancy pay (compensation, benefits).
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.II.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property PayOutRedundancyPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutRedundancyPay)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_PayOutRedundancyPay) <> CRound(value) Then
                    _PayOutRedundancyPay = CRound(value)
                    PropertyHasChanged()
                    RecalculateTotalPay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the total calculated payments before deductions (tax, imprest, other).
        ''' </summary>
        ''' <remarks>Value equals sum of all the calculated pay outs.
        ''' Value is stored in the database table du_ziniarastis_d.DU_pr.
        ''' Due to the backward compartability du_ziniarastis_d.DU_pr value equals PayOutTotal - PayOutSickLeave.</remarks>
        <DoubleField(ValueRequiredLevel.Mandatory, False, 2)> _
        Public ReadOnly Property PayOutTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutTotal)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total taxable wage amount for the personal income tax (GPM) 
        ''' (for year 2019 and later - exluding sick leave pay).
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.BaseGPM.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property BaseGPM() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BaseGpm)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total taxable wage amount for the health insurance contribution (PSD).
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.BasePSD.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property BasePSD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BasePsd)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total taxable wage amount for the health insurance contribution (PSD), 
        ''' that is payable to the VMI.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.BasePSDSickLeave.
        ''' Only applicable for year 2009.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property BasePSDSickLeave() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BasePsdSickLeave)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total taxable wage amount for the social security insurance contribution (SODRA).
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.BaseSODRA.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property BaseSODRA() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BaseSodra)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total taxable wage amount for the guarantee fund (insolvency insurance) contribution.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.BaseGuaranteeFund.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property BaseGuaranteeFund() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BaseGuaranteeFund)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total calculated personal income tax (GPM), that is deducted from wage 
        ''' (for year 2019 and later - excluding GPM for sick leave).
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.
        ''' Value is stored in the database table du_ziniarastis_d.DeductedGPM.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)>
        Public ReadOnly Property DeductionGPM() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Get
                Return CRound(_DeductionGpm)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated personal income tax (GPM), that is deducted from sick leave 
        ''' (only applicable for year 2019 and later).
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.
        ''' Value is stored in the database table du_ziniarastis_d.DeductedGpmSickLeave.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)>
        Public ReadOnly Property DeductedGpmSickLeave() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Get
                Return CRound(_DeductedGpmSickLeave)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated health insurance contribution (PSD), that is deducted from wage and payed to SODRA.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.
        ''' Value is stored in the database table du_ziniarastis_d.DeductedPSD.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property DeductionPSD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionPsd)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated health insurance contribution (PSD), that is deducted from wage and payed to VMI.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.
        ''' Only applicable for year 2009.
        ''' Value is stored in the database table du_ziniarastis_d.DeductedPSDSickLeave.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property DeductionPSDSickLeave() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionPsdSickLeave)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated social security insurance contribution (SODRA), that is deducted from wage.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.
        ''' Value is stored in the database table du_ziniarastis_d.DeductedSODRA.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property DeductionSODRA() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionSodra)
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of imprest, that is deducted from wage.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.
        ''' Value is stored in the database table du_ziniarastis_d.Avans.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property DeductionImprest() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionImprest)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total amount of imprest, that was payed to the worker, but hasn't been deducted from wage yet.
        ''' </summary>
        ''' <remarks>Value is calculated by a database query that sums all the imprest payed (d_avansai_d.Suma)
        ''' before the current wage sheet date and subtracts the sum of all the imprest deducted from wage (du_ziniarastis_d.Avans).</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property ImprestPending() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ImprestPending)
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of other deductions (e.g. to lay damages) 
        ''' that has been actualy deducted from the wage (without making PayableTotal negative).
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Issk.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property DeductionOtherApplicable() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionOtherApplicable)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the amount of other deductions (e.g. to lay damages).
        ''' </summary>
        ''' <remarks>Value is not stored in the database, only <see cref="DeductionOtherApplicable">DeductionOtherApplicable</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property DeductionOther() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionOther)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_DeductionOther) <> CRound(value) Then
                    _DeductionOther = CRound(value)
                    PropertyHasChanged()
                    RecalculateDeductionsAndTaxes(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the calculated social security insurance contribution (SODRA), that is payed by the employer.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.
        ''' Value is stored in the database table du_ziniarastis_d.ContributionSODRA.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property ContributionSODRA() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ContributionSodra)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated health insurance contribution (PSD), that is payed by the employer.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.
        ''' Value is stored in the database table du_ziniarastis_d.ContributionPSD.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property ContributionPSD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ContributionPsd)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated guarantee fund (insolvency insurance) contribution.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.
        ''' Value is stored in the database table du_ziniarastis_d.ContributionGuaranteeFund.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property ContributionGuaranteeFund() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ContributionGuaranteeFund)
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of wage after tax deduction.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property PayOutTotalAfterTaxes() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutTotalAfterTaxes)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total netto wage.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.
        ''' Value is stored in the database table du_ziniarastis_d.PayableTotal.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property PayableTotal() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayableTotal)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total netto wage minus imprest (part of wage already payed in advance).
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.
        ''' Value is stored in the database table du_ziniarastis_d.DU_is.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property PayOutTotalAfterDeductions() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayOutTotalAfterDeductions)
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of the non-taxable personal income size (NPD) 
        ''' for the current labour contract for the current month, that is used as base for calculations.
        ''' </summary>
        ''' <remarks>Value is set by <see cref="Contract">Contract</see> or <see cref="ContractUpdate">ContractUpdate</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property BaseNPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BaseNPD)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total applicable for the current month non-taxable personal income size (NPD) 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value equals <see cref="BaseNPD">BaseNPD</see> for the year before 2009.
        ''' Value is calculated by the method <see cref="CalculateNpd">CalculateNpd</see> 
        ''' or set manualy for the year 2009 and later.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property ApplicableNPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ApplicableNPD)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If Not _FinancialDataCanChange OrElse (Not Parent Is Nothing AndAlso _
                    DirectCast(Parent, WageItemList).Year < 2009) Then Exit Property
                CanWriteProperty(True)
                If CRound(_ApplicableNPD) <> CRound(value) Then
                    _ApplicableNPD = CRound(value)
                    PropertyHasChanged()
                    RecalculateDeductionsAndTaxes(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets the (standard) applicable supplementary non-taxable personal income size (PNPD) 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is set by <see cref="Contract">Contract</see> or <see cref="ContractUpdate">ContractUpdate</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property ApplicablePNPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ApplicablePNPD)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total actual (applied) non-taxable personal income size (NPD) 
        ''' (for year 2019 and later - excluding NPD fraction for sick leave).
        ''' </summary>
        ''' <remarks>Value for the wage sheets before year 2009 is calculated automaticaly.
        ''' Value for the wage sheets after year 2008 could be set manualy or by invoking 
        ''' <see cref="CalculateNPD">CalculateNPD</see> method.
        ''' Value is automaticaly adjusted in order not to exceed personal income tax base.
        ''' Value is stored in the database table du_ziniarastis_d.NPD.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)>
        Public ReadOnly Property NPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Get
                Return CRound(_NPD)
            End Get
        End Property

        ''' <summary>
        ''' Gets the actual (applied) non-taxable personal income size (NPD) for the sick leave
        ''' (only applicable for the year 2019 and later).
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.
        ''' Value depends on whether on the <see cref="CompanyWageRates.ApplyNpdToSickLeave">CompanyWageRates.ApplyNpdToSickLeave</see>
        ''' setting for the given sheet.
        ''' Value is stored in the database table du_ziniarastis_d.NpdSickLeave.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)>
        Public ReadOnly Property NpdSickLeave() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)>
            Get
                Return CRound(_NpdSickLeave)
            End Get
        End Property

        ''' <summary>
        ''' Gets the actual (applied) supplementary non-taxable personal income size (PNPD).
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.
        ''' Value is stored in the database table du_ziniarastis_d.PNPD.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property PNPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PNPD)
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of the non-taxable personal income size (NPD), 
        ''' that has been already applied for the current month.
        ''' </summary>
        ''' <remarks>Value is calculated by a database query that sums all the NPD and PNPD 
        ''' applied for the current labour contract for the current month (du_ziniarastis_d.NPD, du_ziniarastis_d.PNPD).</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property UsedNPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UsedNPD)
            End Get
        End Property

        ''' <summary>
        ''' Gets the amount of other personal income (other wage or <see cref="PayOutNaturalPerson">PayOutNaturalPerson</see>), 
        ''' that has been already earned for the current month and should be taken into account when calculating NPD.
        ''' </summary>
        ''' <remarks>Value is calculated by a database query.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property OtherIncome() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OtherIncome)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the amount of work hours within the current item 
        ''' that should be used when calculating average salary.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.VDU_v.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, ROUNDWORKHOURS)> _
        Public Property HoursForVDU() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_HoursForVdu, ROUNDWORKHOURS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_HoursForVdu, ROUNDWORKHOURS) <> CRound(value, ROUNDWORKHOURS) Then
                    _HoursForVdu = CRound(value, ROUNDWORKHOURS)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the amount of work days within the current item 
        ''' that should be used when calculating average salary.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.VDU_d.</remarks>
        <IntegerField(ValueRequiredLevel.Recommended, False)> _
        Public Property DaysForVDU() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DaysForVdu
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _DaysForVdu <> value Then
                    _DaysForVdu = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the amount of wage within the current item 
        ''' that should be used when calculating average salary.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.VDU_u.</remarks>
        <DoubleField(ValueRequiredLevel.Recommended, False, 2)> _
        Public Property WageForVDU() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_WageForVdu)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_WageForVdu) <> CRound(value) Then
                    _WageForVdu = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the date when the wage within the current item has been payed.
        ''' Use an empty string if the wage is not payed.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Ismoketa.</remarks>
        Public Property PayedOutDate() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PayedOutDate.ToString()
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If value Is Nothing Then value = ""
                If _PayedOutDate <> New Csla.SmartDate(value.Trim, False).Date Then
                    _PayedOutDate = New Csla.SmartDate(value.Trim, False)
                    PropertyHasChanged()
                    PropertyHasChanged("IsPayedOut")
                    PropertyHasChanged("PayedOutTotalSum")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Whether the wage within the current item has already been payed.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Ismoketa (not null).</remarks>
        Public ReadOnly Property IsPayedOut() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _PayedOutDate.IsEmpty
            End Get
        End Property

        ''' <summary>
        ''' If <see cref="IsPayedOut">IsPayedOut</see> then equals <see cref="PayOutTotalAfterDeductions">PayOutTotalAfterDeductions</see>, 
        ''' else equals 0.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property PayedOutTotalSum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _PayedOutDate.IsEmpty Then
                    Return 0
                Else
                    Return CRound(_PayOutTotalAfterDeductions, 2)
                End If
            End Get
        End Property



        ''' <summary>
        ''' Calculates <see cref="NPD">NPD</see> by the formula as provided by <see cref="CompanyWageRates.NpdFormula">CompanyWageRates.NpdFormula</see>.
        ''' </summary>
        ''' <param name="parentRates"><see cref="CompanyWageRates">CompanyWageRates</see> of the parent WageSheet to use.</param>
        ''' <param name="parentYear">Year of the parent WageSheet.</param>
        ''' <param name="parentMonth">Month of the parent WageSheet.</param>
        ''' <param name="raisePropertyHasChanged">Whether to raise PropertyHasChanged events.</param>
        ''' <remarks></remarks>
        Friend Sub CalculateNpd(ByVal parentRates As CompanyWageRates, ByVal parentYear As Integer, _
            ByVal parentMonth As Integer, ByVal raisePropertyHasChanged As Boolean)

            If Not Parent Is Nothing Then
                parentRates = DirectCast(Parent, WageItemList).WageRates
                parentYear = DirectCast(Parent, WageItemList).Year
                parentMonth = DirectCast(Parent, WageItemList).Month
            End If
            If parentRates Is Nothing Then Exit Sub

            If Not parentYear > 2008 Then Throw New Exception( _
                My.Resources.Workers_WageItem_InvalidCalculateNpdInvoke)

            _ApplicableNPD = GetApplicableNPD(parentRates)

            If raisePropertyHasChanged Then PropertyHasChanged("ApplicableNPD")

            RecalculateDeductionsAndTaxes(parentRates, parentYear, parentMonth, False, raisePropertyHasChanged)

            If Not raisePropertyHasChanged Then Me.MarkDirty()

        End Sub

        Private Function GetApplicableNPD(ByVal parentRates As CompanyWageRates) As Double

            If parentRates Is Nothing Then Return 0.0

            If StringIsNullOrEmpty(parentRates.NPDFormula) Then _
                Throw New Exception(My.Resources.Workers_WageItem_NpdFormulaNull)

            Dim fObj As New FormulaSolver
            fObj.Param("NPD") = _BaseNPD
            fObj.Param("PAJ") = _OtherIncome + _PayOutTotal

            Dim result As Double

            If Not fObj.Solved(parentRates.NPDFormula.Trim, result) Then _
                Throw New Exception(My.Resources.Workers_WageItem_NpdFormulaInvalid)

            If result < 0 Then result = 0

            Return result

        End Function

        Friend Sub RecalculateDeductionsAndTaxes(ByVal parentRates As CompanyWageRates, _
            ByVal parentYear As Integer, ByVal parentMonth As Integer, _
            ByVal loadingOldItem As Boolean, ByVal raisePropertyHasChanged As Boolean)

            If Not Parent Is Nothing Then
                parentRates = DirectCast(Parent, WageItemList).WageRates
                parentYear = DirectCast(Parent, WageItemList).Year
                parentMonth = DirectCast(Parent, WageItemList).Month
            End If
            If parentRates Is Nothing Then Exit Sub

            If loadingOldItem Then

                If parentYear > 2008 Then

                    ' reverse calculate ApplicableNPD
                    If CRound(_UsedNPD) > CRound(_ApplicablePNPD) Then
                        _ApplicableNPD = CRound(_NPD + _NpdSickLeave - _ApplicablePNPD + _UsedNPD)
                    Else
                        _ApplicableNPD = CRound(_NPD + _NpdSickLeave)
                    End If
                    _NPD = CRound(_NPD + _NpdSickLeave)

                End If

            Else

                If CRound(_UsedNPD) > CRound(_ApplicablePNPD) Then
                    _NPD = CRound(_ApplicableNPD + _ApplicablePNPD - _UsedNPD)
                    If _NPD < 0 Then _NPD = 0
                    _PNPD = 0
                Else
                    _NPD = _ApplicableNPD
                    _PNPD = CRound(_ApplicablePNPD - _UsedNPD)
                End If

            End If

            If parentYear < 2019 OrElse Not PayOutSickLeave > 0 Then

                _NpdSickLeave = 0
                _DeductedGpmSickLeave = 0

                If CRound(_PayOutTotal) >= CRound(_NPD + _PNPD) Then
                    _BaseGpm = CRound(_PayOutTotal - _NPD - _PNPD)
                ElseIf CRound(_PayOutTotal) > CRound(_NPD) Then
                    _BaseGpm = 0
                    _PNPD = CRound(_PayOutTotal - _NPD)
                Else
                    _BaseGpm = 0
                    _PNPD = 0
                    _NPD = CRound(_PayOutTotal)
                End If

            ElseIf parentRates.ApplyNpdToSickLeave Then

                _NpdSickLeave = CRound(_NPD * _PayOutSickLeave / _PayOutTotal)
                If CRound(_NpdSickLeave - _PayOutSickLeave) > 0 Then _NpdSickLeave = _PayOutSickLeave
                _DeductedGpmSickLeave = CRound((_PayOutSickLeave - _NpdSickLeave) * parentRates.RateGPMSickLeave / 100)

                Dim payout As Double = CRound(_PayOutTotal - _PayOutSickLeave)
                Dim npdLeft As Double = CRound(_NPD - _NpdSickLeave)

                If CRound(payout) >= CRound(npdLeft + _PNPD) Then
                    _BaseGpm = CRound(payout - npdLeft - _PNPD)
                    _NPD = npdLeft
                ElseIf CRound(payout) > CRound(npdLeft) Then
                    _BaseGpm = 0
                    _NPD = npdLeft
                    _PNPD = CRound(payout - npdLeft)
                Else
                    _BaseGpm = 0
                    _PNPD = 0
                    _NPD = CRound(payout)
                End If

            Else

                _NpdSickLeave = 0
                _DeductedGpmSickLeave = CRound(_PayOutSickLeave * parentRates.RateGPMSickLeave / 100)

                Dim payout As Double = CRound(_PayOutTotal - _PayOutSickLeave)

                If CRound(payout) >= CRound(_NPD + _PNPD) Then
                    _BaseGpm = CRound(payout - _NPD - _PNPD)
                ElseIf CRound(payout) > CRound(_NPD) Then
                    _BaseGpm = 0
                    _PNPD = CRound(payout - _NPD)
                Else
                    _BaseGpm = 0
                    _PNPD = 0
                    _NPD = CRound(payout)
                End If

            End If

            _DeductionGpm = CRound(_BaseGpm * parentRates.RateGPM / 100)

            _BasePsd = CRound(_PayOutTotal - _PayOutSickLeave)
            If _BasePsd < 0 Then _BasePsd = 0

            If parentYear > 2008 Then
                _DeductionPsd = CRound(_BasePsd * parentRates.RatePSDEmployee / 100)
                _ContributionPsd = CRound(_BasePsd * parentRates.RatePSDEmployer / 100)
            Else
                _DeductionPsd = 0
                _ContributionPsd = 0
            End If
            If parentYear = 2009 Then
                _BasePsdSickLeave = _PayOutSickLeave
                _DeductionPsdSickLeave = CRound(_PayOutSickLeave * parentRates.RatePSDEmployee / 100)
            Else
                _BasePsdSickLeave = 0
                _DeductionPsdSickLeave = 0
            End If

            _BaseSodra = CRound(_PayOutTotal - _PayOutSickLeave)
            If _BaseSodra < 0 Then _BaseSodra = 0

            _DeductionSodra = CRound(_BaseSodra * parentRates.RateSODRAEmployee / 100)
            _ContributionSodra = CRound(_BaseSodra * parentRates.RateSODRAEmployer / 100)

            _BaseGuaranteeFund = _BaseSodra

            _ContributionGuaranteeFund = CRound(_BaseGuaranteeFund * parentRates.RateGuaranteeFund / 100)

            _PayOutTotalAfterTaxes = CRound(_PayOutTotal - _DeductionGpm - _DeductedGpmSickLeave -
                _DeductionPsd - _DeductionPsdSickLeave - _DeductionSodra)

            If Not loadingOldItem Then
                If CRound(_PayOutTotalAfterTaxes) >= CRound(_ImprestPending) Then
                    _DeductionImprest = CRound(_ImprestPending)
                Else
                    _DeductionImprest = CRound(_PayOutTotalAfterTaxes)
                End If
            End If

            Dim wageAfterTaxesAndImprest As Double = CRound(_PayOutTotalAfterTaxes - _DeductionImprest)

            If CRound(wageAfterTaxesAndImprest) >= CRound(_DeductionOther) Then
                _DeductionOtherApplicable = CRound(_DeductionOther)
            Else
                _DeductionOtherApplicable = CRound(wageAfterTaxesAndImprest)
            End If

            _PayOutTotalAfterDeductions = CRound(wageAfterTaxesAndImprest - _DeductionOtherApplicable)
            _PayableTotal = CRound(_PayOutTotalAfterDeductions + _DeductionImprest)

            If Not loadingOldItem AndAlso raisePropertyHasChanged Then
                PropertyHasChanged("NPD")
                PropertyHasChanged("PNPD")
                PropertyHasChanged("DeductionGPM")
                PropertyHasChanged("DeductionPSD")
                PropertyHasChanged("ContributionPSD")
                PropertyHasChanged("DeductionPSDSickLeave")
                PropertyHasChanged("DeductionSODRA")
                PropertyHasChanged("ContributionSODRA")
                PropertyHasChanged("ContributionGuaranteeFund")
                PropertyHasChanged("PayOutTotalAfterTaxes")
                PropertyHasChanged("PayableTotal")
                PropertyHasChanged("DeductionImprest")
                PropertyHasChanged("DeductionOtherApplicable")
                PropertyHasChanged("PayOutTotalAfterDeductions")
                PropertyHasChanged("PayedOutTotalSum")
                PropertyHasChanged("BaseGPM")
                PropertyHasChanged("BasePSD")
                PropertyHasChanged("BasePSDSickLeave")
                PropertyHasChanged("BaseSODRA")
                PropertyHasChanged("BaseGuaranteeFund")
                PropertyHasChanged("DeductedGpmSickLeave")
                PropertyHasChanged("NpdSickLeave")

            ElseIf Not loadingOldItem Then
                MarkDirty()
            End If

        End Sub

        Private Sub RecalculateTotalPay(ByVal parentRates As CompanyWageRates, _
            ByVal parentYear As Integer, ByVal parentMonth As Integer, _
            ByVal loadingOldItem As Boolean, ByVal raisePropertyHasChanged As Boolean)

            If Not Parent Is Nothing Then
                parentRates = DirectCast(Parent, WageItemList).WageRates
                parentYear = DirectCast(Parent, WageItemList).Year
                parentMonth = DirectCast(Parent, WageItemList).Month
            End If
            If parentRates Is Nothing Then Exit Sub

            _PayOutTotal = CRound(_BonusPay + _OtherPayRelatedToWork + _OtherPayNotRelatedToWork + _
                _PayOutWage + _PayOutExtraPay + _PayOutHR + _PayOutON + _PayOutSC + _PayOutSickLeave + _
                _PayOutHoliday + _PayOutUnusedHolidayCompensation + _PayOutRedundancyPay)

            If Not loadingOldItem Then
                _HoursForVdu = CRound(_TotalHoursWorked + _TruancyHours, 4)
                _DaysForVdu = Convert.ToInt32(Math.Ceiling(_TruancyHours / 8) + _TotalDaysWorked)
                _WageForVdu = CRound(_OtherPayRelatedToWork + _PayOutWage + _PayOutExtraPay + _
                    _PayOutHR + _PayOutON + _PayOutSC)

                If raisePropertyHasChanged Then
                    PropertyHasChanged("PayOutTotal")
                    PropertyHasChanged("HoursForVDU")
                    PropertyHasChanged("DaysForVDU")
                    PropertyHasChanged("WageForVDU")
                End If

            End If

            RecalculateDeductionsAndTaxes(parentRates, parentYear, parentMonth, loadingOldItem, raisePropertyHasChanged)

        End Sub

        Friend Sub RecalculatePay(ByVal parentRates As CompanyWageRates, _
            ByVal parentYear As Integer, ByVal parentMonth As Integer, _
            ByVal loadingOldItem As Boolean, ByVal raisePropertyHasChanged As Boolean)

            If Not Parent Is Nothing Then
                parentRates = DirectCast(Parent, WageItemList).WageRates
                parentYear = DirectCast(Parent, WageItemList).Year
                parentMonth = DirectCast(Parent, WageItemList).Month
            End If
            If parentRates Is Nothing Then Exit Sub

            _TotalHoursWorked = CRound(_NormalHoursWorked + _HRHoursWorked + _
                _ONHoursWorked + _SCHoursWorked, ROUNDWORKHOURS)

            If Not _StandartHours > 0 OrElse Not _NormalHoursWorked > 0 Then
                _PayOutWage = 0
                _PayOutExtraPay = 0
            Else
                If _WageType = WageType.Position Then
                    _PayOutWage = CRound(_ConventionalWage * _NormalHoursWorked / _StandartHours)
                Else
                    _PayOutWage = CRound(_ConventionalWage * _NormalHoursWorked)
                End If
                _PayOutExtraPay = CRound(_ConventionalExtraPay * _NormalHoursWorked / _StandartHours)
            End If

            If Not _NormalHoursWorked > 0 AndAlso Not _StandartHours > 0 Then
                _ActualHourlyPay = 0
            ElseIf Not _NormalHoursWorked > 0 Then
                _ActualHourlyPay = CRound((_ConventionalWage + _ConventionalExtraPay + _
                    _OtherPayRelatedToWork) / _StandartHours)
            Else
                _ActualHourlyPay = CRound((_PayOutWage + _PayOutExtraPay + _
                    _OtherPayRelatedToWork) / _NormalHoursWorked)
            End If

            If parentYear = 2008 AndAlso parentMonth = 6 Then
                _PayOutHR = CRound(_HRHoursWorked * _ApplicableVduHourly * parentRates.RateHR / 100)
                _PayOutON = CRound(_ONHoursWorked * _ApplicableVduHourly * parentRates.RateON / 100)
                _PayOutSC = CRound(_SCHoursWorked * _ApplicableVduHourly * parentRates.RateSC / 100)
            Else
                _PayOutHR = CRound(_HRHoursWorked * _ActualHourlyPay * parentRates.RateHR / 100)
                _PayOutON = CRound(_ONHoursWorked * _ActualHourlyPay * parentRates.RateON / 100)
                _PayOutSC = CRound(_SCHoursWorked * _ActualHourlyPay * parentRates.RateSC / 100)
            End If

            _PayOutSickLeave = CRound(_ApplicableVduDaily * _SickDays * parentRates.RateSickLeave / 100)

            If Not loadingOldItem Then

                If CRound(_UnusedHolidayDaysForCompensation) > 0 Then

                    _PayOutUnusedHolidayCompensation = _
                        CRound(_AnnualWorkingDaysRatio * _ApplicableVduDaily * _
                        _UnusedHolidayDaysForCompensation)
                    _PayOutHoliday = 0
                    _HolidayWD = 0
                    _HolidayRD = 0
                    If raisePropertyHasChanged Then
                        PropertyHasChanged("HolidayWD")
                        PropertyHasChanged("HolidayRD")
                    End If

                Else

                    _PayOutUnusedHolidayCompensation = 0
                    _PayOutHoliday = CRound(_HolidayWD * _ApplicableVduDaily)

                End If

            End If

            If Not loadingOldItem AndAlso raisePropertyHasChanged Then
                PropertyHasChanged("TotalHoursWorked")
                PropertyHasChanged("PayOutWage")
                PropertyHasChanged("PayOutExtraPay")
                PropertyHasChanged("ActualHourlyPay")
                PropertyHasChanged("PayOutHR")
                PropertyHasChanged("PayOutON")
                PropertyHasChanged("PayOutSC")
                PropertyHasChanged("PayOutSickLeave")
                PropertyHasChanged("PayOutHoliday")
                PropertyHasChanged("PayOutUnusedHolidayCompensation")
            ElseIf Not loadingOldItem Then
                MarkDirty()
            End If

            RecalculateTotalPay(parentRates, parentYear, parentMonth, loadingOldItem, raisePropertyHasChanged)

        End Sub

        Friend Sub UpdateApplicableVDU(ByVal infoVDU As ActiveReports.WorkersVDUInfo, ByVal raisePropertyHasChanged As Boolean)

            If infoVDU Is Nothing OrElse infoVDU.ContractNumber <> _ContractNumber OrElse _
                _ContractSerial.Trim.ToLower <> infoVDU.ContractSerial.Trim.ToLower Then Exit Sub

            _ApplicableVduDaily = infoVDU.ApplicableVDUDaily
            _ApplicableVduHourly = infoVDU.ApplicableVDUHourly

            If raisePropertyHasChanged Then
                PropertyHasChanged("ApplicableVDUDaily")
                PropertyHasChanged("ApplicableVDUHourly")
            Else
                ValidationRules.CheckRules("ApplicableVDUDaily")
                ValidationRules.CheckRules("ApplicableVDUHourly")
                MarkDirty()
            End If

            RecalculatePay(Nothing, 0, 0, False, raisePropertyHasChanged)

        End Sub


        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return String.Format(My.Resources.Common_ErrorInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error))
        End Function

        Public Function GetWarningString() As String _
            Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return String.Format(My.Resources.Common_WarningInItem, Me.ToString, _
                vbCrLf, Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning))
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Workers_WageItem_ToString, _PersonName, _
                _ContractSerial, _ContractNumber)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf DoubleRequiredWhenCheckedValidation, New RuleArgs("NormalHoursWorked"))
            ValidationRules.AddRule(AddressOf DoubleRequiredWhenCheckedValidation, New RuleArgs("TotalHoursWorked"))
            ValidationRules.AddRule(AddressOf DoubleRequiredWhenCheckedValidation, New RuleArgs("StandartHours"))
            ValidationRules.AddRule(AddressOf DoubleRequiredWhenCheckedValidation, New RuleArgs("ConventionalWage"))
            ValidationRules.AddRule(AddressOf DoubleRequiredWhenCheckedValidation, New RuleArgs("PayOutWage"))
            ValidationRules.AddRule(AddressOf DoubleRequiredWhenCheckedValidation, New RuleArgs("PayOutTotal"))
            ValidationRules.AddRule(AddressOf DoubleRequiredWhenCheckedValidation, New RuleArgs("HoursForVDU"))
            ValidationRules.AddRule(AddressOf DoubleRequiredWhenCheckedValidation, New RuleArgs("WageForVDU"))
            ValidationRules.AddRule(AddressOf IntegerRequiredWhenCheckedValidation, New RuleArgs("TotalDaysWorked"))
            ValidationRules.AddRule(AddressOf IntegerRequiredWhenCheckedValidation, New RuleArgs("StandartDays"))
            ValidationRules.AddRule(AddressOf IntegerRequiredWhenCheckedValidation, New RuleArgs("DaysForVDU"))

            ValidationRules.AddRule(AddressOf DoubleFieldValidation, New RuleArgs("HRHoursWorked"))
            ValidationRules.AddRule(AddressOf DoubleFieldValidation, New RuleArgs("ONHoursWorked"))
            ValidationRules.AddRule(AddressOf DoubleFieldValidation, New RuleArgs("SCHoursWorked"))
            ValidationRules.AddRule(AddressOf DoubleFieldValidation, New RuleArgs("TruancyHours"))
            ValidationRules.AddRule(AddressOf IntegerFieldValidation, New RuleArgs("HolidayWD"))
            ValidationRules.AddRule(AddressOf IntegerFieldValidation, New RuleArgs("HolidayRD"))
            ValidationRules.AddRule(AddressOf DoubleFieldValidation, New RuleArgs("UnusedHolidayDaysForCompensation"))
            ValidationRules.AddRule(AddressOf IntegerFieldValidation, New RuleArgs("SickDays"))
            ValidationRules.AddRule(AddressOf DoubleFieldValidation, New RuleArgs("BonusPay"))
            ValidationRules.AddRule(AddressOf DoubleFieldValidation, New RuleArgs("OtherPayRelatedToWork"))
            ValidationRules.AddRule(AddressOf DoubleFieldValidation, New RuleArgs("OtherPayNotRelatedToWork"))
            ValidationRules.AddRule(AddressOf DoubleFieldValidation, New RuleArgs("PayOutRedundancyPay"))
            ValidationRules.AddRule(AddressOf DoubleFieldValidation, New RuleArgs("DeductionOther"))
            ValidationRules.AddRule(AddressOf DoubleFieldValidation, New RuleArgs("ApplicableNPD"))

            ValidationRules.AddRule(AddressOf AnnualWorkingDaysRatioValidation, "AnnualWorkingDaysRatio")
            ValidationRules.AddRule(AddressOf ApplicableVduHourlyValidation, "ApplicableVDUHourly")
            ValidationRules.AddRule(AddressOf ApplicableVduDailyValidation, "ApplicableVDUDaily")

            ValidationRules.AddDependantProperty("UnusedHolidayDaysForCompensation", "AnnualWorkingDaysRatio", False)

            ValidationRules.AddDependantProperty("HRHoursWorked", "ApplicableVDUHourly", False)
            ValidationRules.AddDependantProperty("ONHoursWorked", "ApplicableVDUHourly", False)
            ValidationRules.AddDependantProperty("SCHoursWorked", "ApplicableVDUHourly", False)

            ValidationRules.AddDependantProperty("HolidayWD", "ApplicableVDUDaily", False)
            ValidationRules.AddDependantProperty("SickDays", "ApplicableVDUDaily", False)
            ValidationRules.AddDependantProperty("UnusedHolidayDaysForCompensation", "ApplicableVDUDaily", False)

            ValidationRules.AddDependantProperty("IsChecked", "NormalHoursWorked", False)
            ValidationRules.AddDependantProperty("IsChecked", "TotalHoursWorked", False)
            ValidationRules.AddDependantProperty("IsChecked", "StandartHours", False)
            ValidationRules.AddDependantProperty("IsChecked", "ConventionalWage", False)
            ValidationRules.AddDependantProperty("IsChecked", "PayOutWage", False)
            ValidationRules.AddDependantProperty("IsChecked", "PayOutTotal", False)
            ValidationRules.AddDependantProperty("IsChecked", "TotalDaysWorked", False)
            ValidationRules.AddDependantProperty("IsChecked", "StandartDays", False)
            ValidationRules.AddDependantProperty("IsChecked", "AnnualWorkingDaysRatio", False)
            ValidationRules.AddDependantProperty("IsChecked", "ApplicableVDUDaily", False)
            ValidationRules.AddDependantProperty("IsChecked", "ApplicableVDUHourly", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that required and recommended double values are set when the item is checked.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function DoubleRequiredWhenCheckedValidation( _
            ByVal target As Object, ByVal e As Validation.RuleArgs) As Boolean

            If Not DirectCast(target, WageItem).IsChecked Then Return True

            Return DoubleFieldValidation(target, e)

            'Dim val As Double = CDbl(CallByName(target, e.PropertyName, CallType.Get))

            'If valObj._IsChecked AndAlso Not val > 0 Then
            '    e.Description = "Pasirinktam darbuotojui " & valObj._PersonName & " pagal darbo sutartį " & _
            '        valObj._ContractSerial & valObj._ContractNumber & " " & _
            '        DirectCast(e, SimpleRuleArgs).HumanReadableName & _
            '        " turi būti didesnis už nulį."
            '    e.Severity = Validation.RuleSeverity.Error
            '    Return False
            'End If

            'Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that required and recommended integer values are set when the item is checked.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function IntegerRequiredWhenCheckedValidation( _
            ByVal target As Object, ByVal e As Validation.RuleArgs) As Boolean

            If Not DirectCast(target, WageItem).IsChecked Then Return True

            Return IntegerFieldValidation(target, e)

            'Dim val As Double = CDbl(CallByName(target, e.PropertyName, CallType.Get))

            'If valObj._IsChecked AndAlso Not val > 0 Then
            '    e.Description = "Pasirinktam darbuotojui " & valObj._PersonName & " pagal darbo sutartį " & _
            '        valObj._ContractSerial & valObj._ContractNumber & " " & _
            '        DirectCast(e, SimpleRuleArgs).HumanReadableName & _
            '        " turi būti didesnis už nulį."
            '    e.Severity = Validation.RuleSeverity.Error
            '    Return False
            'End If

            'Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that AnnualWorkingDaysRatio is >0 when unused holiday compensation present.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function AnnualWorkingDaysRatioValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As WageItem = DirectCast(target, WageItem)

            Dim maxAllowedValue As Double = CRound((1 - (1 / Math.Pow(10, ROUNDWORKDAYSRATIO))), ROUNDWORKDAYSRATIO)

            If CRound(valObj._AnnualWorkingDaysRatio, ROUNDWORKDAYSRATIO) < 0 Then
                e.Description = String.Format(My.Resources.Common_IntegerExceedsMinLimit, _
                    My.Resources.Workers_WageItem_AnnualWorkingDaysRatio, DblParser(0.0, ROUNDWORKDAYSRATIO))
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf CRound(valObj._AnnualWorkingDaysRatio, ROUNDWORKDAYSRATIO) > maxAllowedValue Then
                e.Description = String.Format(My.Resources.Common_IntegerExceedsMaxLimit, _
                    My.Resources.Workers_WageItem_AnnualWorkingDaysRatio, _
                    DblParser(maxAllowedValue, ROUNDWORKDAYSRATIO))
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            If Not valObj._IsChecked Then Return True

            If valObj._IsChecked AndAlso valObj._UnusedHolidayDaysForCompensation > 0 AndAlso _
                Not CRound(valObj._AnnualWorkingDaysRatio, ROUNDWORKDAYSRATIO) > 0 Then
                e.Description = String.Format(My.Resources.Common_FieldValueNull, _
                    My.Resources.Workers_WageItem_AnnualWorkingDaysRatio)
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that ApplicableVDUHourly is entered when needed.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function ApplicableVduHourlyValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As WageItem = DirectCast(target, WageItem)

            If CRound(valObj._ApplicableVduHourly) < 0 Then
                e.Description = String.Format(My.Resources.Common_IntegerExceedsMinLimit, _
                    My.Resources.Workers_WageItem_ApplicableVduHourly, DblParser(0.0, 2))
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            If Not valObj._IsChecked OrElse valObj.Parent Is Nothing Then Return True

            ' Hourly VDU is only used for year 2008 month 6
            If DirectCast(valObj.Parent, WageItemList).Year <> 2008 OrElse _
                DirectCast(valObj.Parent, WageItemList).Month <> 6 Then Return True

            If Not CRound(valObj._ApplicableVduHourly) > 0 AndAlso _
                (CRound(valObj._HRHoursWorked, ROUNDWORKHOURS) > 0 OrElse _
                 CRound(valObj._SCHoursWorked, ROUNDWORKHOURS) > 0 OrElse _
                 CRound(valObj._ONHoursWorked, ROUNDWORKHOURS) > 0) Then
                e.Description = String.Format(My.Resources.Common_FieldValueNull, _
                    My.Resources.Workers_WageItem_ApplicableVduHourly)
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that ApplicableVDUDaily is entered when needed.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function ApplicableVduDailyValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As WageItem = DirectCast(target, WageItem)

            If CRound(valObj._ApplicableVduDaily) < 0 Then
                e.Description = String.Format(My.Resources.Common_IntegerExceedsMinLimit, _
                    My.Resources.Workers_WageItem_ApplicableVduDaily, DblParser(0.0, 2))
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            If Not valObj._IsChecked Then Return True

            If Not CRound(valObj._ApplicableVduDaily) > 0 AndAlso (valObj._HolidayWD > 0 _
                OrElse valObj._SickDays > 0 OrElse CRound(valObj._UnusedHolidayDaysForCompensation, ROUNDACCUMULATEDHOLIDAY) > 0) Then
                e.Description = String.Format(My.Resources.Common_FieldValueNull, _
                    My.Resources.Workers_WageItem_ApplicableVduDaily)
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function GetWageItem(ByVal dr As DataRow, ByVal parentRates As CompanyWageRates, _
            ByVal parentYear As Integer, ByVal parentMonth As Integer, _
            ByVal nFinancialDataCanChange As Boolean) As WageItem
            Return New WageItem(dr, parentRates, parentYear, parentMonth, nFinancialDataCanChange)
        End Function

        Friend Shared Function NewWageItem(ByVal dr As DataRow, ByVal parentDays As Integer, _
            ByVal parentHours As Double, ByVal parentRates As CompanyWageRates, _
            ByVal parentYear As Integer, ByVal parentMonth As Integer) As WageItem
            Return New WageItem(dr, parentDays, parentHours, parentRates, parentYear, parentMonth)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal parentRates As CompanyWageRates, _
            ByVal parentYear As Integer, ByVal parentMonth As Integer, _
            ByVal nFinancialDataCanChange As Boolean)
            MarkAsChild()
            Fetch(dr, parentRates, parentYear, parentMonth, nFinancialDataCanChange)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal parentDays As Integer, _
            ByVal parentHours As Double, ByVal parentRates As CompanyWageRates, _
            ByVal parentYear As Integer, ByVal parentMonth As Integer)
            MarkAsChild()
            Create(dr, parentDays, parentHours, parentRates, parentYear, parentMonth)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal dr As DataRow, ByVal parentDays As Integer, _
            ByVal parentHours As Double, ByVal parentRates As CompanyWageRates, _
            ByVal parentYear As Integer, ByVal parentMonth As Integer)

            _PersonId = CIntSafe(dr.Item(0), 0)
            _PersonName = CStrSafe(dr.Item(1)).Trim
            _PersonCode = CStrSafe(dr.Item(2)).Trim
            _PersonCodeSodra = CStrSafe(dr.Item(3)).Trim
            _ContractSerial = CStrSafe(dr.Item(4)).Trim
            _ContractNumber = CIntSafe(dr.Item(5), 0)
            _WorkLoad = CDblSafe(dr.Item(6), ROUNDWORKLOAD, 0)
            _ConventionalWage = CDblSafe(dr.Item(7), 2, 0)
            _WageType = Utilities.ConvertDatabaseCharID(Of WageType)(CStrSafe(dr.Item(8)).Trim)
            _WageTypeHumanReadable = Utilities.ConvertLocalizedName(_WageType)
            _ConventionalExtraPay = CDblSafe(dr.Item(9), 2, 0)
            _BaseNPD = CDblSafe(dr.Item(10), 2, 0)
            If parentYear > 2008 Then
                _ApplicableNPD = 0
            Else
                _ApplicableNPD = _BaseNPD
            End If
            _ApplicablePNPD = CDblSafe(dr.Item(11), 2, 0)
            _ImprestPending = CRound(CDblSafe(dr.Item(13), 2, 0) - CDblSafe(dr.Item(12), 2, 0))
            _UsedNPD = CDblSafe(dr.Item(14), 2, 0)
            _OtherIncome = CDblSafe(dr.Item(15), 2, 0)
            _ONHoursWorked = CDblSafe(dr.Item(16), ROUNDWORKHOURS, 0) + _
                CDblSafe(dr.Item(17), ROUNDWORKHOURS, 0)
            _HRHoursWorked = CDblSafe(dr.Item(18), ROUNDWORKHOURS, 0)
            _SCHoursWorked = CDblSafe(dr.Item(19), ROUNDWORKHOURS, 0)
            _TruancyHours = CDblSafe(dr.Item(20), ROUNDWORKHOURS, 0)
            _StandartDays = CIntSafe(dr.Item(21), 0)
            _StandartHours = CDblSafe(dr.Item(22), ROUNDWORKHOURS, 0)
            _TotalDaysWorked = CIntSafe(dr.Item(23), 0)
            _TotalHoursWorked = CDblSafe(dr.Item(24), ROUNDWORKHOURS, 0)
            _NormalHoursWorked = CRound(_TotalHoursWorked - CDblSafe(dr.Item(17), _
                ROUNDWORKHOURS, 0), ROUNDWORKHOURS)
            _SickDays = CIntSafe(dr.Item(25), 0)
            _HolidayWD = CIntSafe(dr.Item(26), 0)

            If Not _StandartDays > 0 Then _StandartDays = Convert.ToInt32(Math.Ceiling(parentDays * _WorkLoad))
            If Not CRound(_StandartHours, ROUNDWORKHOURS) > 0 Then _StandartHours = _
                CRound(parentHours * _WorkLoad, ROUNDWORKHOURS)
            If Not _TotalDaysWorked > 0 Then _TotalDaysWorked = _StandartDays
            If Not CRound(_NormalHoursWorked, ROUNDWORKHOURS) > 0 Then _NormalHoursWorked = _StandartHours
            If Not CRound(_TotalHoursWorked, ROUNDWORKHOURS) > 0 Then _TotalHoursWorked = _StandartHours

            RecalculatePay(parentRates, parentYear, parentMonth, False, False)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow, ByVal parentRates As CompanyWageRates, _
            ByVal parentYear As Integer, ByVal parentMonth As Integer, _
            ByVal nFinancialDataCanChange As Boolean)

            _PersonId = CIntSafe(dr.Item(0), 0)
            _PersonName = CStrSafe(dr.Item(1)).Trim
            _PersonCode = CStrSafe(dr.Item(2)).Trim
            _PersonCodeSodra = CStrSafe(dr.Item(3)).Trim
            _ContractSerial = CStrSafe(dr.Item(4)).Trim
            _ContractNumber = CIntSafe(dr.Item(5), 0)
            _WorkLoad = CDblSafe(dr.Item(6), ROUNDWORKLOAD, 0)
            _ConventionalWage = CDblSafe(dr.Item(7), 2, 0)
            _WageType = Utilities.ConvertDatabaseCharID(Of WageType)(CStrSafe(dr.Item(8)).Trim)
            _WageTypeHumanReadable = Utilities.ConvertLocalizedName(_WageType)
            _ConventionalExtraPay = CDblSafe(dr.Item(9), 2, 0)
            _BaseNPD = CDblSafe(dr.Item(10), 2, 0)
            If parentYear < 2009 Then _ApplicableNPD = _BaseNPD
            _ApplicablePNPD = CDblSafe(dr.Item(11), 2, 0)
            _ImprestPending = CRound(CDblSafe(dr.Item(13), 2, 0) - CDblSafe(dr.Item(12), 2, 0))
            _UsedNPD = CDblSafe(dr.Item(14), 2, 0)
            _OtherIncome = CDblSafe(dr.Item(15), 2, 0)
            _TotalDaysWorked = CIntSafe(dr.Item(16), 0)
            _NormalHoursWorked = CDblSafe(dr.Item(17), ROUNDWORKHOURS, 0)
            _ONHoursWorked = CDblSafe(dr.Item(18), ROUNDWORKHOURS, 0)
            _HRHoursWorked = CDblSafe(dr.Item(19), ROUNDWORKHOURS, 0)
            _SCHoursWorked = CDblSafe(dr.Item(20), ROUNDWORKHOURS, 0)
            _StandartHours = CDblSafe(dr.Item(21), ROUNDWORKHOURS, 0)
            _StandartDays = CIntSafe(dr.Item(22), 0)
            _TruancyHours = CDblSafe(dr.Item(23), ROUNDWORKHOURS, 0)

            _SickDays = CIntSafe(dr.Item(27), 0)
            _ApplicableVduDaily = CDblSafe(dr.Item(28), 2, 0)
            _ApplicableVduHourly = CDblSafe(dr.Item(29), 2, 0)

            If CIntSafe(dr.Item(24), 0) = 0 Then ' holidays
                _HolidayWD = CIntSafe(dr.Item(25), 0)
                _HolidayRD = CIntSafe(dr.Item(26), 0)
                _PayOutHoliday = CDblSafe(dr.Item(35), 2, 0)
            Else ' unused holiday compensation
                _UnusedHolidayDaysForCompensation = CDblSafe(dr.Item(45), ROUNDACCUMULATEDHOLIDAY, 0)
                _PayOutUnusedHolidayCompensation = CDblSafe(dr.Item(35), 2, 0)
                ' PayOutUnusedHolidayCompensation = UnusedHolidayDaysForCompensation 
                ' * ApplicableVDUDaily * AnnualWorkingDaysRatio
                ' ->
                ' AnnualWorkingDaysRatio = PayOutUnusedHolidayCompensation
                ' / ApplicableVDUDaily / UnusedHolidayDaysForCompensation
                If Not CRound(_UnusedHolidayDaysForCompensation, ROUNDACCUMULATEDHOLIDAY) > 0 OrElse _
                    Not CRound(_ApplicableVduDaily, 2) > 0 Then
                    _AnnualWorkingDaysRatio = 0
                Else
                    _AnnualWorkingDaysRatio = CRound(_PayOutUnusedHolidayCompensation _
                        / _ApplicableVduDaily / _UnusedHolidayDaysForCompensation, _
                        ROUNDWORKDAYSRATIO)
                End If
            End If

            _BonusPay = CDblSafe(dr.Item(30), 2, 0)
            _BonusType = Utilities.ConvertDatabaseCharID(Of BonusType)(CStrSafe(dr.Item(31)))
            _OtherPayNotRelatedToWork = CDblSafe(dr.Item(32), 2, 0)
            _OtherPayRelatedToWork = CDblSafe(dr.Item(33), 2, 0)
            _PayOutRedundancyPay = CDblSafe(dr.Item(34), 2, 0)
            _DeductionOther = CDblSafe(dr.Item(36), 2, 0)
            _DeductionOtherApplicable = CDblSafe(dr.Item(36), 2, 0)
            _DeductionImprest = CDblSafe(dr.Item(37), 2, 0)
            _NPD = CDblSafe(dr.Item(38), 2, 0)
            _NpdSickLeave = CDblSafe(dr.Item(47), 2, 0)
            _PNPD = CDblSafe(dr.Item(39), 2, 0)
            _DaysForVdu = CIntSafe(dr.Item(40), 0)
            _HoursForVdu = CDblSafe(dr.Item(41), 4, 0)
            _WageForVdu = CDblSafe(dr.Item(42), 2, 0)
            _ID = CIntSafe(dr.Item(44), 0)
            If CDateSafe(dr.Item(43), Date.MaxValue) <> Date.MaxValue Then
                _PayedOutDate = New Csla.SmartDate(CDateSafe(dr.Item(43), Date.MinValue), False)
            End If

            _IsChecked = True

            RecalculatePay(parentRates, parentYear, parentMonth, True, False)

            _FinancialDataCanChange = nFinancialDataCanChange

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        ' ReSharper disable ParameterHidesMember
        Friend Sub Insert(ByVal parent As WageSheet)
            ' ReSharper restore ParameterHidesMember

            Dim myComm As New SQLCommand("InsertWageItem")
            myComm.AddParam("?BD", parent.ID)
            myComm.AddParam("?AK", _PersonId)
            myComm.AddParam("?DS", _ContractSerial)
            myComm.AddParam("?DN", _ContractNumber)
            myComm.AddParam("?KR", CRound(_WorkLoad, ROUNDWORKLOAD))
            myComm.AddParam("?WC", CRound(_ConventionalWage))
            myComm.AddParam("?WT", Utilities.ConvertDatabaseCharID(_WageType))
            myComm.AddParam("?PR", CRound(_ConventionalExtraPay))
            AddWithParams(myComm)

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        ' ReSharper disable ParameterHidesMember
        Friend Sub Update(ByVal parent As WageSheet)
            ' ReSharper restore ParameterHidesMember

            Dim myComm As New SQLCommand("UpdateWageItem")
            myComm.AddParam("?ID", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteWageItem")
            myComm.AddParam("?ID", _ID)

            myComm.Execute()

            MarkNew()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)

            myComm.AddParam("?PM", CRound(_BonusPay))
            myComm.AddParam("?PT", Utilities.ConvertDatabaseCharID(_BonusType))
            myComm.AddParam("?KN", CRound(_OtherPayNotRelatedToWork))
            myComm.AddParam("?FD", _TotalDaysWorked)
            myComm.AddParam("?FV", CRound(_NormalHoursWorked, ROUNDWORKHOURS))
            myComm.AddParam("?NV", CRound(_ONHoursWorked, ROUNDWORKHOURS))
            myComm.AddParam("?PS", CRound(_HRHoursWorked, ROUNDWORKHOURS))
            myComm.AddParam("?YS", CRound(_SCHoursWorked, ROUNDWORKHOURS))
            myComm.AddParam("?PV", CRound(_TruancyHours, ROUNDWORKHOURS))
            myComm.AddParam("?GV", CRound(_StandartHours, ROUNDWORKHOURS))
            myComm.AddParam("?GD", _StandartDays)
            If CRound(_UnusedHolidayDaysForCompensation) > 0 Then
                myComm.AddParam("?HW", 0)
                myComm.AddParam("?HP", CRound(_PayOutUnusedHolidayCompensation))
                myComm.AddParam("?HT", 1)
                myComm.AddParam("?HR", 0)
                myComm.AddParam("?AF", CRound(_UnusedHolidayDaysForCompensation, ROUNDACCUMULATEDHOLIDAY))
            Else
                myComm.AddParam("?HW", _HolidayWD)
                myComm.AddParam("?HP", CRound(_PayOutHoliday))
                myComm.AddParam("?HT", 0)
                myComm.AddParam("?HR", _HolidayRD)
                myComm.AddParam("?AF", 0)
            End If
            myComm.AddParam("?SC", _SickDays)
            myComm.AddParam("?RP", CRound(_PayOutRedundancyPay))
            myComm.AddParam("?NPD", CRound(_NPD))
            myComm.AddParam("?PNPD", CRound(_PNPD))
            myComm.AddParam("?DD", CRound(_DeductionOtherApplicable))
            myComm.AddParam("?VDU_d", _DaysForVdu)
            myComm.AddParam("?VDU_v", CRound(_HoursForVdu, ROUNDWORKHOURS))
            myComm.AddParam("?VDU_u", CRound(_WageForVdu))
            myComm.AddParam("?VDU_dien", CRound(_ApplicableVduDaily))
            myComm.AddParam("?VDU_val", CRound(_ApplicableVduHourly))
            myComm.AddParam("?KS", CRound(_OtherPayRelatedToWork))
            myComm.AddParam("?IM", CRound(_DeductionImprest))
            myComm.AddParam("?WP", CRound(_PayOutTotalAfterDeductions))
            ' inherited from previous version error, needed for backward compartability
            myComm.AddParam("?WO", CRound(_PayOutTotal - _PayOutSickLeave))

            If _PayedOutDate.IsEmpty Then
                myComm.AddParam("?BA", Nothing, GetType(Date))
            Else
                myComm.AddParam("?BA", _PayedOutDate.Date)
            End If

            ' values that are calculated (not fetched) internaly but exposed as
            ' precalculated for external usage
            myComm.AddParam("?AA", CRound(_BaseGpm))
            myComm.AddParam("?AB", CRound(_BasePsd))
            myComm.AddParam("?AC", CRound(_BasePsdSickLeave))
            myComm.AddParam("?AD", CRound(_BaseSodra))
            myComm.AddParam("?AE", CRound(_BaseGuaranteeFund))
            myComm.AddParam("?AG", CRound(_PayOutWage))
            myComm.AddParam("?AH", CRound(_PayOutExtraPay))
            myComm.AddParam("?AI", CRound(_PayOutHR))
            myComm.AddParam("?AJ", CRound(_PayOutON))
            myComm.AddParam("?AL", CRound(_PayOutSC))
            myComm.AddParam("?AM", CRound(_PayOutSickLeave))
            myComm.AddParam("?AN", CRound(_DeductionGpm))
            myComm.AddParam("?AO", CRound(_DeductionPsd))
            myComm.AddParam("?AP", CRound(_DeductionPsdSickLeave))
            myComm.AddParam("?AR", CRound(_DeductionSodra))
            myComm.AddParam("?AQ", CRound(_ContributionPsd))
            myComm.AddParam("?AV", CRound(_ContributionSodra))
            myComm.AddParam("?AZ", CRound(_ContributionGuaranteeFund))
            myComm.AddParam("?AW", CRound(_PayableTotal))
            myComm.AddParam("?BB", CRound(_NpdSickLeave))
            myComm.AddParam("?BC", CRound(_DeductedGpmSickLeave))

        End Sub

#End Region

    End Class

End Namespace