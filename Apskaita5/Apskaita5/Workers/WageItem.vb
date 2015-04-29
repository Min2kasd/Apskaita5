Namespace Workers

    ''' <summary>
    ''' Represents a wage calculation for a particular labour contract for a particular month.
    ''' </summary>
    ''' <remarks>Should only be used as a child of a <see cref="WageItemList">WageItemList</see>.
    ''' Values are stored in the database table du_ziniarastis_d.</remarks>
    <Serializable()> _
    Public Class WageItem
        Inherits BusinessBase(Of WageItem)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _FinancialDataCanChange As Boolean = True
        Private _PersonID As Integer = 0
        Private _PersonName As String = ""
        Private _PersonCode As String = ""
        Private _PersonCodeSODRA As String = ""
        Private _ContractSerial As String = ""
        Private _ContractNumber As Integer = 0
        Private _WorkLoad As Double = 0
        Private _IsChecked As Boolean = False
        Private _ApplicableVDUHourly As Double = 0
        Private _ApplicableVDUDaily As Double = 0
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
        Private _DeductionGPM As Double = 0
        Private _DeductionPSD As Double = 0
        Private _DeductionPSDSickLeave As Double = 0
        Private _DeductionSODRA As Double = 0
        Private _DeductionImprest As Double = 0
        Private _ImprestPending As Double = 0
        Private _DeductionOtherApplicable As Double = 0
        Private _DeductionOther As Double = 0
        Private _ContributionSODRA As Double = 0
        Private _ContributionPSD As Double = 0
        Private _ContributionGuaranteeFund As Double = 0
        Private _PayOutTotalAfterTaxes As Double = 0
        Private _PayableTotal As Double = 0
        Private _PayOutTotalAfterDeductions As Double = 0
        Private _ApplicableNPD As Double = 0
        Private _ApplicablePNPD As Double = 0
        Private _NPD As Double = 0
        Private _PNPD As Double = 0
        Private _UsedNPD As Double = 0
        Private _OtherIncome As Double = 0
        Private _HoursForVDU As Double = 0
        Private _DaysForVDU As Integer = 0
        Private _WageForVDU As Double = 0
        Private _IsPayedOut As Boolean = False
        Private _PayedOutDate As Date = Date.MaxValue
        Private _PayedOutTotalSum As Double = 0


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
                Return _PersonID
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.Person.Name">name of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.Person.Name">General.Person.Name</see>.</remarks>
        Public ReadOnly Property PersonName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonName.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.Person.Code">personal code of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.Person.Code">General.Person.Code</see>.</remarks>
        Public ReadOnly Property PersonCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.Person.CodeSODRA">social security code of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks>Corresponds to <see cref="General.Person.CodeSODRA">General.Person.CodeSODRA</see>.</remarks>
        Public ReadOnly Property PersonCodeSODRA() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonCodeSODRA.Trim
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
        ''' <remarks>Could be set manualy or calculated using <see cref="WorkersVDUInfoList">WorkersVDUInfoList</see> object.
        ''' Value is stored in the database table du_ziniarastis_d.VDU_val.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property ApplicableVDUHourly() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ApplicableVDUHourly)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_ApplicableVDUHourly) <> CRound(value) Then
                    _ApplicableVDUHourly = CRound(value)
                    PropertyHasChanged()
                    RecalculatePay(Nothing, 0, 0, False, True)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the currently applicable average wage per day for the current labour contract.
        ''' </summary>
        ''' <remarks>Could be set manualy or calculated using <see cref="WorkersVDUInfoList">WorkersVDUInfoList</see> object.
        ''' Value is stored in the database table du_ziniarastis_d.VDU_dien.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property ApplicableVDUDaily() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ApplicableVDUDaily)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_ApplicableVDUDaily) <> CRound(value) Then
                    _ApplicableVDUDaily = CRound(value)
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
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
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
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Atost.</remarks>
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
        ''' <see cref="NormalHoursWorked">NormalHoursWorked</see> and <see cref="StandartHours">StandartHours</see>.</remarks>
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
        ''' <see cref="NormalHoursWorked">NormalHoursWorked</see> and <see cref="StandartHours">StandartHours</see>.</remarks>
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
        ''' <remarks>Value equals (PayOutWage + PayOutExtraPay + OtherPayRelatedToWork) / NormalHoursWorked.</remarks>
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
        ''' <see cref="CompanyWageRates.RateHR">CompanyWageRates.RateHR</see>.</remarks>
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
        ''' <see cref="CompanyWageRates.RateON">CompanyWageRates.RateON</see>.</remarks>
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
        ''' <see cref="CompanyWageRates.RateSC">CompanyWageRates.RateSC</see>.</remarks>
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
        ''' <see cref="CompanyWageRates.RateSickLeave">CompanyWageRates.RateSickLeave</see>.</remarks>
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
        ''' multiplied by <see cref="HolidayWD">HolidayWD</see>.</remarks>
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
        ''' and multiplied by <see cref="AnnualWorkingDaysRatio">AnnualWorkingDaysRatio</see>.</remarks>
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
        ''' Gets the calculated personal income tax (GPM), that is deducted from wage.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property DeductionGPM() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionGPM)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated health insurance contribution (PSD), that is deducted from wage and payed to SODRA.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property DeductionPSD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionPSD)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated health insurance contribution (PSD), that is deducted from wage and payed to VMI.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property DeductionPSDSickLeave() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionPSDSickLeave)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated social security insurance contribution (SODRA), that is deducted from wage.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property DeductionSODRA() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DeductionSODRA)
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
        ''' that could (and will) be deducted without making PayableTotal negative.
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
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Issk.</remarks>
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
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property ContributionSODRA() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ContributionSODRA)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated health insurance contribution (PSD), that is payed by the employer.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property ContributionPSD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ContributionPSD)
            End Get
        End Property

        ''' <summary>
        ''' Gets the calculated guarantee fund (insolvency insurance) contribution.
        ''' </summary>
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.</remarks>
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
        ''' <remarks>Value is calculated by the method <see cref="RecalculateDeductionsAndTaxes">RecalculateDeductionsAndTaxes</see>.</remarks>
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
        ''' Gets the (standard) applicable non-taxable personal income size (NPD) 
        ''' for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Value is set by <see cref="Contract">Contract</see> or <see cref="ContractUpdate">ContractUpdate</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property ApplicableNPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ApplicableNPD)
            End Get
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
        ''' Gets or sets the actual (applied) non-taxable personal income size (NPD).
        ''' </summary>
        ''' <remarks>Value for the wage sheets before year 2009 is calculated automaticaly.
        ''' Value for the wage sheets after year 2008 could be set manualy or by invoking 
        ''' <see cref="CalculateNPD">CalculateNPD</see> method.
        ''' Value is automaticaly adjusted in order not to exceed personal income tax base.
        ''' Value is stored in the database table du_ziniarastis_d.NPD.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property NPD() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_NPD)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                If Not _FinancialDataCanChange OrElse (Not Parent Is Nothing AndAlso _
                    DirectCast(Parent, WageItemList).Year < 2009) Then Exit Property
                CanWriteProperty(True)
                If CRound(_NPD) <> CRound(value) Then
                    _NPD = CRound(value)
                    PropertyHasChanged()
                    RecalculateDeductionsAndTaxes(Nothing, 0, 0, False, True)
                End If
            End Set
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
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property HoursForVDU() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_HoursForVDU, 4)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_HoursForVDU, 4) <> CRound(value, 4) Then
                    _HoursForVDU = CRound(value, 4)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the amount of work days within the current item 
        ''' that should be used when calculating average salary.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.VDU_d.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property DaysForVDU() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DaysForVDU
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If _DaysForVDU <> value Then
                    _DaysForVDU = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the amount of wage within the current item 
        ''' that should be used when calculating average salary.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.VDU_u.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public Property WageForVDU() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_WageForVDU)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If Not _FinancialDataCanChange Then Exit Property
                If CRound(_WageForVDU) <> CRound(value) Then
                    _WageForVDU = CRound(value)
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' The date when the wage within the current item has been payed.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Ismoketa.</remarks>
        Public ReadOnly Property PayedOutDate() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _PayedOutDate <> Date.MaxValue Then Return _PayedOutDate.ToString("yyyy-MM-dd")
                Return ""
            End Get
        End Property

        ''' <summary>
        ''' Whether the wage within the current item has already been payed.
        ''' </summary>
        ''' <remarks>Value is stored in the database table du_ziniarastis_d.Ismoketa (not null).</remarks>
        Public ReadOnly Property IsPayedOut() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsPayedOut
            End Get
        End Property

        Public ReadOnly Property PayedOutTotalSum() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PayedOutTotalSum)
            End Get
        End Property



        Friend Sub CalculateNPD(ByVal WO As CompanyWageRates, ByVal ParentYear As Integer, _
            ByVal ParentMonth As Integer, ByVal RaisePropertyHasChanged As Boolean)

            If Not Parent Is Nothing Then
                WO = DirectCast(Parent, WageItemList).WageRates
                ParentYear = DirectCast(Parent, WageItemList).Year
                ParentMonth = DirectCast(Parent, WageItemList).Month
            End If
            If WO Is Nothing Then Exit Sub

            If Not ParentYear > 2008 Then Throw New Exception( _
                "Klaida. NPD skaičiavimo funkcija taikoma tik po 2008 metų.")

            If String.IsNullOrEmpty(WO.NPDFormula.Trim) Then _
                Throw New Exception("Klaida. Nenustatyta NPD skaičiavimo formulė.")

            Dim FObj As New FormulaSolver
            FObj.Param("NPD") = _ApplicableNPD
            FObj.Param("PAJ") = _OtherIncome + _PayOutTotal

            Dim result As Double
            If Not FObj.Solved(WO.NPDFormula.Trim, result) Then _
                Throw New Exception("Klaida. Nepavyko pritaikyti formulės NPD skaičiavimui.")

            If result < 0 Then result = 0

            _NPD = result

            RecalculateDeductionsAndTaxes(WO, ParentYear, ParentMonth, False, RaisePropertyHasChanged)

            If Not RaisePropertyHasChanged Then Me.MarkDirty()

        End Sub

        Friend Sub RecalculateDeductionsAndTaxes(ByVal WO As CompanyWageRates, _
            ByVal ParentYear As Integer, ByVal ParentMonth As Integer, _
            ByVal LoadingOldItem As Boolean, ByVal RaisePropertyHasChanged As Boolean)

            If Not Parent Is Nothing Then
                WO = DirectCast(Parent, WageItemList).WageRates
                ParentYear = DirectCast(Parent, WageItemList).Year
                ParentMonth = DirectCast(Parent, WageItemList).Month
            End If
            If WO Is Nothing Then Exit Sub

            If Not LoadingOldItem Then
                If ParentYear > 2008 Then

                    If _UsedNPD > _ApplicablePNPD Then
                        _NPD = CRound(_NPD + _ApplicablePNPD - _UsedNPD)
                        If _NPD < 0 Then _NPD = 0
                        _PNPD = 0
                    Else
                        _PNPD = CRound(_ApplicablePNPD - _UsedNPD)
                    End If

                Else

                    If _UsedNPD > _ApplicablePNPD Then
                        _NPD = CRound(_ApplicableNPD + _ApplicablePNPD - _UsedNPD)
                        If _NPD < 0 Then _NPD = 0
                        _PNPD = 0
                    Else
                        _PNPD = CRound(_ApplicablePNPD - _UsedNPD)
                        _NPD = _ApplicableNPD
                    End If

                End If
            End If

            Dim TaxBase As Double

            If CRound(_PayOutTotal) >= CRound(_NPD + _PNPD) Then
                TaxBase = CRound(_PayOutTotal - _NPD - _PNPD)
            ElseIf CRound(_PayOutTotal) > CRound(_NPD) Then
                TaxBase = 0
                _PNPD = CRound(_PayOutTotal - _NPD)
            Else
                TaxBase = 0
                _PNPD = 0
                _NPD = CRound(_PayOutTotal)
            End If

            _DeductionGPM = CRound(TaxBase * WO.RateGPM / 100)

            TaxBase = CRound(_PayOutTotal - _PayOutSickLeave)
            If TaxBase < 0 Then TaxBase = 0

            If ParentYear > 2008 Then
                _DeductionPSD = CRound(TaxBase * WO.RatePSDEmployee / 100)
                _ContributionPSD = CRound(TaxBase * WO.RatePSDEmployer / 100)
            Else
                _DeductionPSD = 0
                _ContributionPSD = 0
            End If
            If ParentYear = 2009 Then
                _DeductionPSDSickLeave = CRound(_PayOutSickLeave * WO.RatePSDEmployee / 100)
            Else
                _DeductionPSDSickLeave = 0
            End If

            _DeductionSODRA = CRound(TaxBase * WO.RateSODRAEmployee / 100)
            _ContributionSODRA = CRound(TaxBase * WO.RateSODRAEmployer / 100)

            _ContributionGuaranteeFund = CRound(TaxBase * WO.RateGuaranteeFund / 100)

            _PayOutTotalAfterTaxes = CRound(_PayOutTotal - _DeductionGPM - _
                _DeductionPSD - _DeductionPSDSickLeave - _DeductionSODRA)

            If Not LoadingOldItem Then
                If CRound(_PayOutTotalAfterTaxes) >= CRound(_ImprestPending) Then
                    _DeductionImprest = CRound(_ImprestPending)
                Else
                    _DeductionImprest = CRound(_PayOutTotalAfterTaxes)
                End If
            End If

            Dim WageAfterTaxesAndImprest As Double = CRound(_PayOutTotalAfterTaxes - _DeductionImprest)

            If CRound(WageAfterTaxesAndImprest) >= CRound(_DeductionOther) Then
                _DeductionOtherApplicable = CRound(_DeductionOther)
            Else
                _DeductionOtherApplicable = CRound(WageAfterTaxesAndImprest)
            End If

            _PayOutTotalAfterDeductions = CRound(WageAfterTaxesAndImprest - _DeductionOtherApplicable)
            _PayableTotal = CRound(_PayOutTotalAfterDeductions + _DeductionImprest)

            If Not LoadingOldItem AndAlso RaisePropertyHasChanged Then
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
            ElseIf Not LoadingOldItem Then
                MarkDirty()
            End If

        End Sub

        Private Sub RecalculateTotalPay(ByVal WO As CompanyWageRates, _
            ByVal ParentYear As Integer, ByVal ParentMonth As Integer, _
            ByVal LoadingOldItem As Boolean, ByVal RaisePropertyHasChanged As Boolean)

            If Not Parent Is Nothing Then
                WO = DirectCast(Parent, WageItemList).WageRates
                ParentYear = DirectCast(Parent, WageItemList).Year
                ParentMonth = DirectCast(Parent, WageItemList).Month
            End If
            If WO Is Nothing Then Exit Sub

            _PayOutTotal = CRound(_BonusPay + _OtherPayRelatedToWork + _OtherPayNotRelatedToWork + _
                _PayOutWage + _PayOutExtraPay + _PayOutHR + _PayOutON + _PayOutSC + _PayOutSickLeave + _
                _PayOutHoliday + _PayOutUnusedHolidayCompensation + _PayOutRedundancyPay)

            If Not LoadingOldItem Then
                _HoursForVDU = CRound(_TotalHoursWorked + _TruancyHours, 4)
                _DaysForVDU = Convert.ToInt32(Math.Ceiling(_TruancyHours / 8) + _TotalDaysWorked)
                _WageForVDU = CRound(_OtherPayRelatedToWork + _PayOutWage + _PayOutExtraPay + _
                    _PayOutHR + _PayOutON + _PayOutSC)

                If RaisePropertyHasChanged Then
                    PropertyHasChanged("PayOutTotal")
                    PropertyHasChanged("HoursForVDU")
                    PropertyHasChanged("DaysForVDU")
                    PropertyHasChanged("WageForVDU")
                End If

            End If

            RecalculateDeductionsAndTaxes(WO, ParentYear, ParentMonth, LoadingOldItem, RaisePropertyHasChanged)

        End Sub

        Friend Sub RecalculatePay(ByVal WO As CompanyWageRates, _
            ByVal ParentYear As Integer, ByVal ParentMonth As Integer, _
            ByVal LoadingOldItem As Boolean, ByVal RaisePropertyHasChanged As Boolean)

            If Not Parent Is Nothing Then
                WO = DirectCast(Parent, WageItemList).WageRates
                ParentYear = DirectCast(Parent, WageItemList).Year
                ParentMonth = DirectCast(Parent, WageItemList).Month
            End If
            If WO Is Nothing Then Exit Sub

            _TotalHoursWorked = CRound(_NormalHoursWorked + _HRHoursWorked + _
                _ONHoursWorked + _SCHoursWorked, 4)

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
                _ActualHourlyPay = CRound((PayOutWage + PayOutExtraPay + _
                    _OtherPayRelatedToWork) / _NormalHoursWorked)
            End If

            If ParentYear = 2008 AndAlso ParentMonth = 6 Then
                _PayOutHR = CRound(_HRHoursWorked * _ApplicableVDUHourly * WO.RateHR / 100)
                _PayOutON = CRound(_ONHoursWorked * _ApplicableVDUHourly * WO.RateON / 100)
                _PayOutSC = CRound(_SCHoursWorked * _ApplicableVDUHourly * WO.RateSC / 100)
            Else
                _PayOutHR = CRound(_HRHoursWorked * _ActualHourlyPay * WO.RateHR / 100)
                _PayOutON = CRound(_ONHoursWorked * _ActualHourlyPay * WO.RateON / 100)
                _PayOutSC = CRound(_SCHoursWorked * _ActualHourlyPay * WO.RateSC / 100)
            End If

            _PayOutSickLeave = CRound(_ApplicableVDUDaily * _SickDays * WO.RateSickLeave / 100)

            If Not LoadingOldItem Then
                If CRound(_UnusedHolidayDaysForCompensation) > 0 Then
                    _PayOutUnusedHolidayCompensation = _
                        CRound(_AnnualWorkingDaysRatio * _ApplicableVDUDaily * _
                        _UnusedHolidayDaysForCompensation)
                    _PayOutHoliday = 0
                    _HolidayWD = 0
                    _HolidayRD = 0
                    If RaisePropertyHasChanged Then
                        PropertyHasChanged("HolidayWD")
                        PropertyHasChanged("HolidayRD")
                    End If
                Else
                    _PayOutUnusedHolidayCompensation = 0
                    _PayOutHoliday = CRound(_HolidayWD * _ApplicableVDUDaily)
                End If

            End If

            If Not LoadingOldItem AndAlso RaisePropertyHasChanged Then
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
            ElseIf Not LoadingOldItem Then
                MarkDirty()
            End If

            RecalculateTotalPay(WO, ParentYear, ParentMonth, LoadingOldItem, RaisePropertyHasChanged)

        End Sub

        Friend Sub UpdateApplicableVDU(ByVal InfoVDU As WorkersVDUInfo, ByVal RaisePropertyHasChanged As Boolean)

            If InfoVDU Is Nothing OrElse _ContractSerial.Trim.ToLower <> _
                InfoVDU.ContractSerial.Trim.ToLower OrElse _
                _ContractNumber <> InfoVDU.ContractNumber Then Exit Sub

            If InfoVDU.ApplicableVDUDaily > 0 AndAlso InfoVDU.ApplicableVDUHourly > 0 Then

                _ApplicableVDUDaily = InfoVDU.ApplicableVDUDaily
                _ApplicableVDUHourly = InfoVDU.ApplicableVDUHourly

            Else

                If Not _StandartHours > 0 OrElse Not _StandartDays > 0 Then _
                    Throw New Exception("Klaida. Darbuotojui " & _PersonName & " pagal darbo sutartį Nr. " & _
                    _ContractSerial & _ContractNumber.ToString & " per paskutinius 12 mėnesių nebuvo " & _
                    "priskaičiuota jokių išmokų. Apskaičiuoti VDU pagal nustatytą DU nėra galimybių, " & _
                    "nes nenurodyta valandų ir (ar) dienų skaičius pagal grafiką.")

                If _WageType = WageType.Hourly Then

                    _ApplicableVDUHourly = CRound(_ConventionalWage + CRound((_OtherPayRelatedToWork + _
                        _ConventionalExtraPay) / _StandartHours))
                    _ApplicableVDUDaily = CRound((_OtherPayRelatedToWork + _
                        (_ConventionalWage * _StandartHours) + _ConventionalExtraPay) / _StandartDays)

                Else

                    _ApplicableVDUHourly = CRound((_OtherPayRelatedToWork + _
                        _ConventionalWage + _ConventionalExtraPay) / _StandartHours)
                    _ApplicableVDUDaily = CRound((_OtherPayRelatedToWork + _
                        _ConventionalWage + _ConventionalExtraPay) / _StandartDays)

                End If

            End If

            If RaisePropertyHasChanged Then
                PropertyHasChanged("ApplicableVDUDaily")
                PropertyHasChanged("ApplicableVDUHourly")
            End If

            RecalculatePay(Nothing, 0, 0, False, RaisePropertyHasChanged)

        End Sub


        Public Function GetErrorString() As String _
            Implements IGetErrorForListItem.GetErrorString
            If IsValid Then Return ""
            Return "Klaida (-os) eilutėje '" & Me.ToString & "': " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
        End Function

        Public Function GetWarningString() As String _
        Implements IGetErrorForListItem.GetWarningString
            If BrokenRulesCollection.WarningCount < 1 Then Return ""
            Return "Eilutėje '" & Me.ToString & "' gali būti klaida: " _
                & Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return _PersonName & " darbo sutartis Nr. " & _ContractSerial & _ContractNumber
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf PositiveNumberRequiredWhenCheckedValidation, _
                New CommonValidation.SimpleRuleArgs("PayOutTotal", _
                "visas priskaičiuotas darbo užmokestis"))
            ValidationRules.AddRule(AddressOf AnnualWorkingDaysRatioValidation, "AnnualWorkingDaysRatio")
            ValidationRules.AddRule(AddressOf ApplicableVDUHourlyValidation, "ApplicableVDUHourly")
            ValidationRules.AddRule(AddressOf ApplicableVDUDailyValidation, "ApplicableVDUDaily")
            ValidationRules.AddRule(AddressOf PositiveNumberRequiredWhenCheckedValidation, _
                New CommonValidation.SimpleRuleArgs("StandartHours", "darbo valandų skaičius grafike"))
            ValidationRules.AddRule(AddressOf PositiveNumberRequiredWhenCheckedValidation, _
                New CommonValidation.SimpleRuleArgs("StandartDays", "darbo dienų skaičius grafike"))
            ValidationRules.AddRule(AddressOf PositiveNumberRequiredWhenCheckedValidation, _
                New CommonValidation.SimpleRuleArgs("ConventionalWage", _
                "nustatytas darbo užmokestis (klaidingai sutvarkyti darbuotojo statuso duomenys)"))


            ValidationRules.AddDependantProperty("UnusedHolidayDaysForCompensation", "AnnualWorkingDaysRatio", False)

            ValidationRules.AddDependantProperty("HRHoursWorked", "ApplicableVDUHourly", False)
            ValidationRules.AddDependantProperty("ONHoursWorked", "ApplicableVDUHourly", False)
            ValidationRules.AddDependantProperty("SCHoursWorked", "ApplicableVDUHourly", False)

            ValidationRules.AddDependantProperty("HolidayWD", "ApplicableVDUDaily", False)
            ValidationRules.AddDependantProperty("SickDays", "ApplicableVDUDaily", False)
            ValidationRules.AddDependantProperty("UnusedHolidayDaysForCompensation", "ApplicableVDUDaily", False)

            ValidationRules.AddDependantProperty("IsChecked", "PayOutTotal", False)
            ValidationRules.AddDependantProperty("IsChecked", "AnnualWorkingDaysRatio", False)
            ValidationRules.AddDependantProperty("IsChecked", "ApplicableVDUHourly", False)
            ValidationRules.AddDependantProperty("IsChecked", "ApplicableVDUDaily", False)
            ValidationRules.AddDependantProperty("IsChecked", "StandartHours", False)
            ValidationRules.AddDependantProperty("IsChecked", "StandartDays", False)
            ValidationRules.AddDependantProperty("IsChecked", "ConventionalWage", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that calculated total wage before taxes is >0.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function PositiveNumberRequiredWhenCheckedValidation( _
            ByVal target As Object, ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As WageItem = DirectCast(target, WageItem)
            Dim Val As Double = CDbl(CallByName(target, e.PropertyName, CallType.Get))

            If ValObj._IsChecked AndAlso Not Val > 0 Then
                e.Description = "Pasirinktam darbuotojui " & ValObj._PersonName & " pagal darbo sutartį " & _
                    ValObj._ContractSerial & ValObj._ContractNumber & " " & _
                    DirectCast(e, SimpleRuleArgs).HumanReadableName & _
                    " turi būti didesnis už nulį."
                e.Severity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True
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

            Dim ValObj As WageItem = DirectCast(target, WageItem)

            If ValObj._IsChecked AndAlso ValObj._UnusedHolidayDaysForCompensation > 0 AndAlso _
                Not CRound(ValObj._AnnualWorkingDaysRatio, 4) > 0 Then
                e.Description = "Pasirinktam darbuotojui " & ValObj._PersonName & " pagal darbo sutartį " & _
                    ValObj._ContractSerial & ValObj._ContractNumber & " nenurodytas darbo dienų koeficientas." & _
                    "(reikalingas kompensacijai už nepanaudotas atostogas apskaičiuoti)"
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
        Private Shared Function ApplicableVDUHourlyValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As WageItem = DirectCast(target, WageItem)
            If ValObj.Parent Is Nothing Then Return True

            If Not ValObj._IsChecked OrElse ValObj.Parent Is Nothing OrElse _
                Not (DirectCast(ValObj.Parent, WageItemList).Year = 2008 AndAlso _
                DirectCast(ValObj.Parent, WageItemList).Month = 6) Then Return True

            If Not CRound(ValObj._ApplicableVDUHourly) > 0 AndAlso (ValObj._HRHoursWorked > 0 _
                OrElse ValObj._SCHoursWorked > 0 OrElse ValObj._ONHoursWorked > 0) Then
                e.Description = "Pasirinktam darbuotojui " & ValObj.PersonName & " pagal darbo sutartį " & _
                    ValObj.ContractSerial & ValObj.ContractNumber & " nenurodytas valandinis VDU" & _
                    "(2006 m. birželį seimas buvo truputį sukvailiojęs)."
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
        Private Shared Function ApplicableVDUDailyValidation(ByVal target As Object, _
          ByVal e As Validation.RuleArgs) As Boolean

            Dim ValObj As WageItem = DirectCast(target, WageItem)

            If Not ValObj._IsChecked Then Return True

            If Not CRound(ValObj._ApplicableVDUDaily) > 0 AndAlso (ValObj._HolidayWD > 0 _
                OrElse ValObj._SickDays > 0 OrElse ValObj._UnusedHolidayDaysForCompensation > 0) Then
                e.Description = "Pasirinktam darbuotojui " & ValObj.PersonName & " pagal darbo sutartį " & _
                    ValObj.ContractSerial & ValObj.ContractNumber & " nenurodytas dienos VDU."
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

        Friend Shared Function GetWageItem(ByVal dr As DataRow, ByVal ParentWO As CompanyWageRates, _
            ByVal ParentYear As Integer, ByVal ParentMonth As Integer, _
            ByVal nFinancialDataCanChange As Boolean) As WageItem
            Return New WageItem(dr, ParentWO, ParentYear, ParentMonth, nFinancialDataCanChange)
        End Function

        Friend Shared Function NewWageItem(ByVal dr As DataRow, ByVal ParentDays As Integer, _
            ByVal ParentHours As Double, ByVal ParentWO As CompanyWageRates, _
            ByVal ParentYear As Integer, ByVal ParentMonth As Integer) As WageItem
            Return New WageItem(dr, ParentDays, ParentHours, ParentWO, ParentYear, ParentMonth)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub


        Private Sub New(ByVal dr As DataRow, ByVal ParentWO As CompanyWageRates, _
            ByVal ParentYear As Integer, ByVal ParentMonth As Integer, _
            ByVal nFinancialDataCanChange As Boolean)
            MarkAsChild()
            Fetch(dr, ParentWO, ParentYear, ParentMonth, nFinancialDataCanChange)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal ParentDays As Integer, _
            ByVal ParentHours As Double, ByVal ParentWO As CompanyWageRates, _
            ByVal ParentYear As Integer, ByVal ParentMonth As Integer)
            MarkAsChild()
            Create(dr, ParentDays, ParentHours, ParentWO, ParentYear, ParentMonth)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal dr As DataRow, ByVal ParentDays As Integer, _
            ByVal ParentHours As Double, ByVal ParentWO As CompanyWageRates, _
            ByVal ParentYear As Integer, ByVal ParentMonth As Integer)

            _PersonID = CIntSafe(dr.Item(0), 0)
            _PersonName = CStrSafe(dr.Item(1)).Trim
            _PersonCode = CStrSafe(dr.Item(2)).Trim
            _PersonCodeSODRA = CStrSafe(dr.Item(3)).Trim
            _ContractSerial = CStrSafe(dr.Item(4)).Trim
            _ContractNumber = CIntSafe(dr.Item(5), 0)
            _WorkLoad = CDblSafe(dr.Item(6), 4, 0)
            _ConventionalWage = CDblSafe(dr.Item(7), 2, 0)
            _WageType = ConvertEnumDatabaseStringCode(Of WageType)(CStrSafe(dr.Item(8)).Trim)
            _WageTypeHumanReadable = ConvertEnumHumanReadable(_WageType)
            _ConventionalExtraPay = CDblSafe(dr.Item(9), 2, 0)
            _ApplicableNPD = CDblSafe(dr.Item(10), 2, 0)
            _ApplicablePNPD = CDblSafe(dr.Item(11), 2, 0)
            _ImprestPending = CRound(CDblSafe(dr.Item(12), 2, 0) - CDblSafe(dr.Item(13), 2, 0))
            _UsedNPD = CDblSafe(dr.Item(14), 2, 0)
            _OtherIncome = CDblSafe(dr.Item(15), 2, 0)
            _ONHoursWorked = CDblSafe(dr.Item(16), ROUNDWORKTIME, 0) + _
                CDblSafe(dr.Item(17), ROUNDWORKTIME, 0)
            _HRHoursWorked = CDblSafe(dr.Item(18), ROUNDWORKTIME, 0)
            _SCHoursWorked = CDblSafe(dr.Item(19), ROUNDWORKTIME, 0)
            _TruancyHours = CDblSafe(dr.Item(20), ROUNDWORKTIME, 0)
            _StandartDays = CIntSafe(dr.Item(21), 0)
            _StandartHours = CDblSafe(dr.Item(22), ROUNDWORKTIME, 0)
            _TotalDaysWorked = CIntSafe(dr.Item(23), 0)
            _TotalHoursWorked = CDblSafe(dr.Item(24), ROUNDWORKTIME, 0)
            _NormalHoursWorked = CRound(_TotalHoursWorked - CDblSafe(dr.Item(17), _
                ROUNDWORKTIME, 0), ROUNDWORKTIME)
            _SickDays = CIntSafe(dr.Item(25), 0)
            _HolidayWD = CIntSafe(dr.Item(26), 0)

            If Not _StandartDays > 0 Then _StandartDays = Convert.ToInt32(Math.Ceiling(ParentDays * _WorkLoad))
            If Not CRound(_StandartHours, ROUNDWORKTIME) > 0 Then _StandartHours = _
                CRound(ParentHours * _WorkLoad, ROUNDWORKTIME)
            If Not _TotalDaysWorked > 0 Then _TotalDaysWorked = _StandartDays
            If Not CRound(_NormalHoursWorked, ROUNDWORKTIME) > 0 Then _NormalHoursWorked = _StandartHours
            If Not CRound(_TotalHoursWorked, ROUNDWORKTIME) > 0 Then _TotalHoursWorked = _StandartHours

            RecalculatePay(ParentWO, ParentYear, ParentMonth, False, False)

            MarkNew()

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow, ByVal ParentWO As CompanyWageRates, _
            ByVal ParentYear As Integer, ByVal ParentMonth As Integer, _
            ByVal nFinancialDataCanChange As Boolean)

            _PersonID = CIntSafe(dr.Item(0), 0)
            _PersonName = CStrSafe(dr.Item(1)).Trim
            _PersonCode = CStrSafe(dr.Item(2)).Trim
            _PersonCodeSODRA = CStrSafe(dr.Item(3)).Trim
            _ContractSerial = CStrSafe(dr.Item(4)).Trim
            _ContractNumber = CIntSafe(dr.Item(5), 0)
            _WorkLoad = CDblSafe(dr.Item(6), ROUNDWORKLOAD, 0)
            _ConventionalWage = CDblSafe(dr.Item(7), 2, 0)
            _WageType = ConvertEnumDatabaseStringCode(Of WageType)(CStrSafe(dr.Item(8)).Trim)
            _WageTypeHumanReadable = ConvertEnumHumanReadable(_WageType)
            _ConventionalExtraPay = CDblSafe(dr.Item(9), 2, 0)
            _ApplicableNPD = CDblSafe(dr.Item(10), 2, 0)
            _ApplicablePNPD = CDblSafe(dr.Item(11), 2, 0)
            _ImprestPending = CRound(CDblSafe(dr.Item(12), 2, 0) - CDblSafe(dr.Item(13), 2, 0))
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

            If CInt(dr.Item(24)) = 0 Then ' holidays
                _HolidayWD = CIntSafe(dr.Item(25), 0)
                _HolidayRD = CIntSafe(dr.Item(26), 0)
                _PayOutHoliday = CDblSafe(dr.Item(35), 2, 0)
            Else ' unused holiday compensation
                _UnusedHolidayDaysForCompensation = CDblSafe(dr.Item(25), ROUNDACCUMULATEDHOLIDAY, 0)
                _PayOutUnusedHolidayCompensation = CDblSafe(dr.Item(35), 2, 0)
                ' PayOutUnusedHolidayCompensation = UnusedHolidayDaysForCompensation 
                ' * ApplicableVDUDaily * AnnualWorkingDaysRatio
                ' ->
                ' AnnualWorkingDaysRatio = PayOutUnusedHolidayCompensation
                ' / ApplicableVDUDaily / UnusedHolidayDaysForCompensation
                _AnnualWorkingDaysRatio = CRound(CDblSafe(dr.Item(35), 2, 0) / CDblSafe(dr.Item(25), 2, 0) _
                    / CDblSafe(dr.Item(28), 4, 0), ROUNDWORKDAYSRATIO)
            End If

            _SickDays = CIntSafe(dr.Item(27), 0)
            _ApplicableVDUDaily = CDblSafe(dr.Item(28), 2, 0)
            _ApplicableVDUHourly = CDblSafe(dr.Item(29), 2, 0)
            _BonusPay = CDblSafe(dr.Item(30), 2, 0)
            _BonusType = ConvertEnumDatabaseStringCode(Of BonusType)(CStrSafe(dr.Item(31)))
            _OtherPayNotRelatedToWork = CDblSafe(dr.Item(32), 2, 0)
            _OtherPayRelatedToWork = CDblSafe(dr.Item(33), 2, 0)
            _PayOutRedundancyPay = CDblSafe(dr.Item(34), 2, 0)
            _DeductionOther = CDblSafe(dr.Item(36), 2, 0)
            _DeductionOtherApplicable = CDblSafe(dr.Item(36), 2, 0)
            _DeductionImprest = CDblSafe(dr.Item(37), 2, 0)
            _NPD = CDblSafe(dr.Item(38), 2, 0)
            _PNPD = CDblSafe(dr.Item(39), 2, 0)
            _DaysForVDU = CIntSafe(dr.Item(40), 0)
            _HoursForVDU = CDblSafe(dr.Item(41), 4, 0)
            _WageForVDU = CDblSafe(dr.Item(42), 2, 0)
            _PayedOutDate = CDateSafe(dr.Item(43), Date.MaxValue)
            _IsPayedOut = (_PayedOutDate <> Date.MaxValue)
            _ID = CIntSafe(dr.Item(44), 0)
            _IsChecked = True

            RecalculatePay(ParentWO, ParentYear, ParentMonth, True, False)

            _FinancialDataCanChange = nFinancialDataCanChange

            MarkOld()

            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert(ByVal parent As WageSheet)

            Dim myComm As New SQLCommand("InsertWageItem")
            myComm.AddParam("?BD", parent.ID)
            myComm.AddParam("?AK", _PersonID)
            myComm.AddParam("?DS", _ContractSerial)
            myComm.AddParam("?DN", _ContractNumber)
            myComm.AddParam("?KR", CRound(_WorkLoad, 4))
            myComm.AddParam("?WC", CRound(_ConventionalWage))
            myComm.AddParam("?WT", ConvertEnumDatabaseStringCode(_WageType))
            myComm.AddParam("?PR", CRound(_ConventionalExtraPay))
            AddWithParams(myComm)

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As WageSheet)

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
            myComm.AddParam("?PT", ConvertEnumDatabaseStringCode(_BonusType))
            myComm.AddParam("?KN", CRound(_OtherPayNotRelatedToWork))
            myComm.AddParam("?FD", _TotalDaysWorked)
            myComm.AddParam("?FV", CRound(_NormalHoursWorked, 4))
            myComm.AddParam("?NV", CRound(_ONHoursWorked, 4))
            myComm.AddParam("?PS", CRound(_HRHoursWorked, 4))
            myComm.AddParam("?YS", CRound(_SCHoursWorked, 4))
            myComm.AddParam("?PV", CRound(_TruancyHours, 4))
            myComm.AddParam("?GV", CRound(_StandartHours, 4))
            myComm.AddParam("?GD", _StandartDays)
            If CRound(_UnusedHolidayDaysForCompensation) > 0 Then
                myComm.AddParam("?HW", CRound(_UnusedHolidayDaysForCompensation, 4))
                myComm.AddParam("?HP", CRound(_PayOutUnusedHolidayCompensation))
                myComm.AddParam("?HT", 1)
                myComm.AddParam("?HR", 0)
            Else
                myComm.AddParam("?HW", _HolidayWD)
                myComm.AddParam("?HP", CRound(_PayOutHoliday))
                myComm.AddParam("?HT", 0)
                myComm.AddParam("?HR", _HolidayRD)
            End If
            myComm.AddParam("?SC", _SickDays)
            myComm.AddParam("?RP", CRound(_PayOutRedundancyPay))
            myComm.AddParam("?NPD", CRound(_NPD))
            myComm.AddParam("?PNPD", CRound(_PNPD))
            myComm.AddParam("?DD", CRound(_DeductionOtherApplicable))
            myComm.AddParam("?VDU_d", _DaysForVDU)
            myComm.AddParam("?VDU_v", CRound(_HoursForVDU, 4))
            myComm.AddParam("?VDU_u", CRound(_WageForVDU))
            myComm.AddParam("?VDU_dien", CRound(_ApplicableVDUDaily))
            myComm.AddParam("?VDU_val", CRound(_ApplicableVDUHourly))
            myComm.AddParam("?KS", CRound(_OtherPayRelatedToWork))
            myComm.AddParam("?IM", CRound(_DeductionImprest))
            myComm.AddParam("?WP", CRound(_PayOutTotalAfterDeductions))
            ' inherited from previous version error, needed for backward compartability
            myComm.AddParam("?WO", CRound(_PayOutTotal - _PayOutSickLeave))

        End Sub

#End Region

    End Class

End Namespace