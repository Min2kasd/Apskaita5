﻿Imports ApskaitaObjects.Workers
Imports System.Security
Imports ApskaitaObjects.Attributes

Namespace ActiveReports

    ''' <summary>
    ''' Represents a calculation of VDU (average wage) for a labour contract.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public NotInheritable Class WorkersVDUInfo
        Inherits ReadOnlyBase(Of WorkersVDUInfo)

#Region " Business Methods "

        Private _Date As Date = Today
        Private _IncludeCurrentMonth As Boolean = False
        Private _PersonId As Integer = 0
        Private _PersonName As String = ""
        Private _PersonCode As String = ""
        Private _PersonCodeSodra As String = ""
        Private _WorkLoad As Double = 0
        Private _ContractSerial As String = ""
        Private _ContractNumber As Integer = 0
        Private _Position As String = ""
        Private _StandartHoursForTheCurrentMonth As Double = 0
        Private _StandartDaysForTheCurrentMonth As Integer = 0
        Private _ConventionalWage As Double = 0
        Private _WageType As WageType = WageType.Position
        Private _WageTypeHumanReadable As String = ""
        Private _ConventionalExtraPay As Double = 0
        Private _TotalScheduledDays As Integer = 0
        Private _TotalScheduledHours As Double = 0
        Private _TotalWorkDays As Integer = 0
        Private _TotalWorkHours As Double = 0
        Private _TotalWage As Double = 0
        Private _WageVDUHourly As Double = 0
        Private _WageVDUDaily As Double = 0
        Private _BonusYearly As Double = 0
        Private _BonusQuarterly As Double = 0
        Private _BonusBase As Double = 0
        Private _BonusVDUHourly As Double = 0
        Private _BonusVDUDaily As Double = 0
        Private _ApplicableVDUHourly As Double = 0
        Private _ApplicableVDUDaily As Double = 0
        Private _WageList As WageVDUInfoList = Nothing
        Private _BonusList As BonusVDUInfoList = Nothing


        ''' <summary>
        ''' Gets the date of the calculation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        ''' <summary>
        ''' Whether to include th current month when calculating.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IncludeCurrentMonth() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IncludeCurrentMonth
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.Person.ID">ID of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property PersonID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonId
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.Person.Name">name of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property PersonName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonName.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.Person.Code">personal code of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property PersonCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonCode.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a <see cref="General.Person.CodeSODRA">social security code of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks></remarks>
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
        ''' and <see cref="WageItem.ContractNumber">running number</see> pair.</remarks>
        Public ReadOnly Property ContractSerial() As String
            Get
                Return _ContractSerial
            End Get
        End Property

        ''' <summary>
        ''' Gets the running number of the current labour contract.
        ''' </summary>
        ''' <remarks>A labour contract is identified by a <see cref="WageItem.ContractSerial">serial number</see> 
        ''' and <see cref="WageItem.ContractNumber">running number</see> pair.</remarks>
        Public ReadOnly Property ContractNumber() As Integer
            Get
                Return _ContractNumber
            End Get
        End Property

        ''' <summary>
        ''' Gets the workers position for the current labour contract.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Position() As String
            Get
                Return _Position
            End Get
        End Property

        ''' <summary>
        ''' Gets the current applicable work load for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKLOAD)> _
        Public ReadOnly Property WorkLoad() As Double
            Get
                Return CRound(_WorkLoad, ROUNDWORKLOAD)
            End Get
        End Property


        ''' <summary>
        ''' Gets the total scheduled work hours for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Used to calculate VDU when no historical data is available.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public ReadOnly Property StandartHoursForTheCurrentMonth() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_StandartHoursForTheCurrentMonth, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the number of scheduled work days for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Used to calculate VDU when no historical data is available.</remarks>
        <IntegerField(ValueRequiredLevel.Optional, False)> _
        Public ReadOnly Property StandartDaysForTheCurrentMonth() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _StandartDaysForTheCurrentMonth
            End Get
        End Property

        ''' <summary>
        ''' Gets the current applicable wage for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Used to calculate VDU when no historical data is available.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
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
        ''' <remarks>Used to calculate VDU when no historical data is available.</remarks>
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
        ''' <remarks>Used to calculate VDU when no historical data is available.</remarks>
        Public ReadOnly Property WageTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WageTypeHumanReadable
            End Get
        End Property

        ''' <summary>
        ''' Gets the current applicable extra pay for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks>Used to calculate VDU when no historical data is available.
        ''' In case VDU is calculated for the <see cref="WageItem">WageItem</see>, 
        ''' <see cref="WageItem.OtherPayRelatedToWork">OtherPayRelatedToWork</see> is added to the conventional extra pay.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property ConventionalExtraPay() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_ConventionalExtraPay)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total amount of scheduled work days within calculation period.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TotalScheduledDays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TotalScheduledDays
            End Get
        End Property

        ''' <summary>
        ''' Gets the total amount of scheduled work hours within calculation period.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public ReadOnly Property TotalScheduledHours() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalScheduledHours, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total amount of actual work days within calculation period.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TotalWorkDays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TotalWorkDays
            End Get
        End Property

        ''' <summary>
        ''' Gets the total amount of actual work hours within calculation period.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public ReadOnly Property TotalWorkHours() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalWorkHours, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total amount of calculated wage within calculation period.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property TotalWage() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalWage)
            End Get
        End Property

        ''' <summary>
        ''' Gets the wage component of average hourly wage (hourly VDU).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property WageVDUHourly() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_WageVDUHourly)
            End Get
        End Property

        ''' <summary>
        ''' Gets the wage component of average daily wage (daily VDU).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property WageVDUDaily() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_WageVDUDaily)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total yearly bonus amount within calculation period (12 month).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property BonusYearly() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BonusYearly)
            End Get
        End Property

        ''' <summary>
        ''' Gets the last quarterly bonus amount within calculation period (12 month).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property BonusQuarterly() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BonusQuarterly)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total bonus amount within calculation period that is used as a base for VDU calculation.
        ''' </summary>
        ''' <remarks>Equals <see cref="BonusQuarterly">BonusQuarterly</see> plus 1/4 <see cref="BonusYearly">BonusYearly</see>.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property BonusBase() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BonusBase)
            End Get
        End Property

        ''' <summary>
        ''' Gets the bonus component of average hourly wage (hourly VDU).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property BonusVDUHourly() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BonusVDUHourly)
            End Get
        End Property

        ''' <summary>
        ''' Gets the bonus component of average daily wage (daily VDU).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property BonusVDUDaily() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_BonusVDUDaily)
            End Get
        End Property

        ''' <summary>
        ''' Gets the wage info that is used for calculating.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property WageList() As WageVDUInfoList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WageList
            End Get
        End Property

        ''' <summary>
        ''' Gets the bonus info that is used for calculating.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property BonusList() As BonusVDUInfoList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BonusList
            End Get
        End Property


        ''' <summary>
        ''' Gets applicable average hourly wage (hourly VDU) for the current labour contract.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property ApplicableVDUHourly() As Double
            Get
                Return CRound(_ApplicableVDUHourly)
            End Get
        End Property

        ''' <summary>
        ''' Gets applicable average daily wage (daily VDU) for the current labour contract.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, 2)> _
        Public ReadOnly Property ApplicableVDUDaily() As Double
            Get
                Return CRound(_ApplicableVDUDaily)
            End Get
        End Property


        Protected Overrides Function GetIdValue() As Object
            Return _ContractSerial & _ContractNumber.ToString & _Date.ToString("yyyyMMdd")
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.ActiveReports_WorkersVDUInfo_ToString, _PersonName, _
                _ContractSerial, _ContractNumber)
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("ActiveReports.WorkersVDUInfo1")
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function NewWorkersVDUInfo(ByVal sheet As WageSheet, _
            ByVal sheetItem As WageItem) As WorkersVDUInfo
            Return New WorkersVDUInfo(sheet, sheetItem)
        End Function

        Public Shared Function GetWorkersVDUInfo(ByVal nContractSerial As String, _
            ByVal nContractNumber As Integer, ByVal nDate As Date, ByVal nIncludeCurrentMonth As Boolean) As WorkersVDUInfo
            Return DataPortal.Fetch(Of WorkersVDUInfo)(New Criteria(nContractSerial, nContractNumber, nDate, nIncludeCurrentMonth))
        End Function

        Friend Shared Function GetWorkersVDUInfoChild(ByVal nDate As Date, _
            ByVal nStandartHoursForTheCurrentMonth As Double, _
            ByVal nStandartDaysForTheCurrentMonth As Integer, _
            ByVal dr As DataRow) As WorkersVDUInfo
            Return New WorkersVDUInfo(nDate, nStandartHoursForTheCurrentMonth, _
                nStandartDaysForTheCurrentMonth, dr)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal sheet As WageSheet, ByVal sheetItem As WageItem)
            Create(sheet, sheetItem)
        End Sub

        Private Sub New(ByVal nDate As Date, ByVal nStandartHoursForTheCurrentMonth As Double, _
            ByVal nStandartDaysForTheCurrentMonth As Integer, ByVal dr As DataRow)
            Fetch(nDate, nStandartHoursForTheCurrentMonth, nStandartDaysForTheCurrentMonth, dr)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private ReadOnly _ContractSerial As String = ""
            Private ReadOnly _ContractNumber As Integer = 0
            Private ReadOnly _Date As Date = Today
            Private ReadOnly _IncludeCurrentMonth As Boolean = False
            Public ReadOnly Property ContractSerial() As String
                Get
                    Return _ContractSerial.Trim
                End Get
            End Property
            Public ReadOnly Property ContractNumber() As Integer
                Get
                    Return _ContractNumber
                End Get
            End Property
            Public ReadOnly Property [Date]() As Date
                Get
                    Return _Date
                End Get
            End Property
            Public ReadOnly Property IncludeCurrentMonth() As Boolean
                Get
                    Return _IncludeCurrentMonth
                End Get
            End Property
            Public Sub New(ByVal nContractSerial As String, ByVal nContractNumber As Integer, _
                ByVal nDate As Date, ByVal nIncludeCurrentMonth As Boolean)
                _ContractSerial = nContractSerial
                _ContractNumber = nContractNumber
                _Date = nDate
                _IncludeCurrentMonth = nIncludeCurrentMonth
            End Sub
        End Class


        Private Sub Create(ByVal sheet As WageSheet, ByVal sheetItem As WageItem)

            If sheet.IsNonClosing Then
                _Date = sheet.Date
            Else
                _Date = New Date(sheet.Year, sheet.Month, Date.DaysInMonth(sheet.Year, sheet.Month))
            End If
            _IncludeCurrentMonth = False

            _PersonId = sheetItem.PersonID
            _PersonName = sheetItem.PersonName
            _PersonCode = sheetItem.PersonCode
            _PersonCodeSodra = sheetItem.PersonCodeSODRA
            _WorkLoad = sheetItem.WorkLoad
            _ContractSerial = sheetItem.ContractSerial
            _ContractNumber = sheetItem.ContractNumber
            _StandartHoursForTheCurrentMonth = sheetItem.StandartHours
            _StandartDaysForTheCurrentMonth = sheetItem.StandartDays
            _ConventionalWage = sheetItem.ConventionalWage
            _WageType = sheetItem.WageType
            _WageTypeHumanReadable = sheetItem.WageTypeHumanReadable
            _ConventionalExtraPay = CRound(sheetItem.ConventionalExtraPay + sheetItem.OtherPayRelatedToWork)
            _Position = ""

            _WageList = WageVDUInfoList.NewWageVDUInfoList()
            _BonusList = BonusVDUInfoList.NewBonusVDUInfoList()

        End Sub

        Private Sub Fetch(ByVal nDate As Date, ByVal nStandartHoursForTheCurrentMonth As Double, _
            ByVal nStandartDaysForTheCurrentMonth As Integer, ByVal dr As DataRow)

            _Date = nDate
            _IncludeCurrentMonth = False

            _PersonId = CIntSafe(dr.Item(0), 0)
            _PersonName = CStrSafe(dr.Item(1))
            _PersonCode = CStrSafe(dr.Item(2))
            _PersonCodeSodra = CStrSafe(dr.Item(3))
            _ContractSerial = CStrSafe(dr.Item(4))
            _ContractNumber = CIntSafe(dr.Item(5), 0)
            _WorkLoad = CDblSafe(dr.Item(9), ROUNDWORKLOAD, 0)
            _Position = CStrSafe(dr.Item(10))
            _ConventionalWage = CDblSafe(dr.Item(11), 2, 0)
            _WageType = Utilities.ConvertDatabaseCharID(Of WageType) _
                (CStrSafe(dr.Item(12)).Trim)
            _WageTypeHumanReadable = Utilities.ConvertLocalizedName(_WageType)
            _ConventionalExtraPay = CDblSafe(dr.Item(13), 2, 0)

            _StandartHoursForTheCurrentMonth = CRound(nStandartHoursForTheCurrentMonth * _WorkLoad, ROUNDWORKHOURS)
            _StandartDaysForTheCurrentMonth = Convert.ToInt32(Math.Ceiling(nStandartDaysForTheCurrentMonth * _WorkLoad))

            FetchDetails()

        End Sub

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            If Not criteria.ContractNumber > 0 Then
                Throw New Exception(My.Resources.ActiveReports_WorkersVDUInfo_ContractNumberNull)
            End If

            Dim myComm As New SQLCommand("FetchWorkersVDUInfoGeneral")
            myComm.AddParam("?DT", criteria.Date)
            myComm.AddParam("?CS", criteria.ContractSerial)
            myComm.AddParam("?CN", criteria.ContractNumber)

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.ActiveReports_WorkersVDUInfo_ContractNotFound, _
                    criteria.ContractSerial & criteria.ContractNumber.ToString()))

                Dim dr As DataRow = myData.Rows(0)

                Dim startDate As Date = CDateSafe(dr.Item(6), Date.MinValue)
                Dim endDate As Date = CDateSafe(dr.Item(7), Date.MaxValue)

                If endDate <> Date.MaxValue Then
                    If criteria.Date.Date > New Date(endDate.Year, endDate.Month, _
                        Date.DaysInMonth(endDate.Year, endDate.Month)) Then
                        Throw New Exception(String.Format(My.Resources.ActiveReports_WorkersVDUInfo_InvalidDate, _
                            endDate.ToString("yyyy-MM-dd")))
                    End If
                End If

                _PersonId = CIntSafe(dr.Item(0), 0)
                _PersonName = CStrSafe(dr.Item(1))
                _PersonCode = CStrSafe(dr.Item(2))
                _PersonCodeSodra = CStrSafe(dr.Item(3))
                _ContractSerial = CStrSafe(dr.Item(4))
                _ContractNumber = CIntSafe(dr.Item(5), 0)
                _ConventionalExtraPay = CDblSafe(dr.Item(8), 2, 0)
                _ConventionalWage = CDblSafe(dr.Item(9), 2, 0)
                _WageType = Utilities.ConvertDatabaseCharID(Of WageType)(CStrSafe(dr.Item(10)).Trim)
                _WageTypeHumanReadable = Utilities.ConvertLocalizedName(_WageType)
                _WorkLoad = CDblSafe(dr.Item(11), ROUNDWORKLOAD, 0)
                _Position = CStrSafe(dr.Item(12))

            End Using

            _Date = criteria.Date
            _IncludeCurrentMonth = criteria.IncludeCurrentMonth

            Dim wtl As DefaultWorkTimeInfoList = DefaultWorkTimeInfoList.GetListChild()
            Dim wt As DefaultWorkTimeInfo = wtl.GetDefaultWorkTimeInfo(_Date.Year, _Date.Month)

            _StandartHoursForTheCurrentMonth = CRound(wt.WorkHoursFor5WorkDayWeek * _WorkLoad, ROUNDWORKHOURS)
            _StandartDaysForTheCurrentMonth = Convert.ToInt32(Math.Ceiling(wt.WorkDaysFor5WorkDayWeek * _WorkLoad))

            FetchDetails()

        End Sub

        Friend Sub FetchDetails()

            _WageList = WageVDUInfoList.GetWageVDUInfoList(_ContractSerial, _ContractNumber, _
                _Date, _IncludeCurrentMonth)
            _BonusList = BonusVDUInfoList.GetBonusVDUInfoList(_ContractSerial, _ContractNumber, _
                _Date, _IncludeCurrentMonth)

            _TotalScheduledDays = _WageList.GetTotalScheduledDays()
            _TotalScheduledHours = _WageList.GetTotalScheduledHours()
            _TotalWorkDays = _WageList.GetTotalWorkDays()
            _TotalWorkHours = _WageList.GetTotalWorkHours()
            _TotalWage = _WageList.GetTotalWage()
            _WageVDUHourly = _WageList.GetAverageWagePerHour()
            _WageVDUDaily = _WageList.GetAverageWagePerDay()
            _BonusYearly = _BonusList.GetTotalYearlyBonus()
            _BonusQuarterly = _BonusList.GetTotalMonthlyBonus()
            _BonusBase = _BonusList.GetTotalBonusBase()
            _BonusVDUHourly = _BonusList.GetAverageWagePerHour(_TotalScheduledHours)
            _BonusVDUDaily = _BonusList.GetAverageWagePerDay(_TotalScheduledDays)

            _ApplicableVDUHourly = CRound(_WageVDUHourly + _BonusVDUHourly)
            _ApplicableVDUDaily = CRound(_WageVDUDaily + _BonusVDUDaily)

            If Not CRound(_ApplicableVDUDaily) > 0 OrElse Not CRound(_ApplicableVDUHourly) > 0 Then

                If Not CRound(_StandartHoursForTheCurrentMonth, ROUNDWORKHOURS) > 0 OrElse _
                   Not _StandartDaysForTheCurrentMonth > 0 Then
                    Throw New Exception(String.Format(My.Resources.ActiveReports_WorkersVDUInfo_CannotCalculateVDU, Me.ToString()))
                End If

                If _WageType = WageType.Hourly Then

                    _ApplicableVDUHourly = CRound(_ConventionalWage + CRound( _
                        _ConventionalExtraPay / _StandartHoursForTheCurrentMonth))
                    _ApplicableVDUDaily = CRound(((_ConventionalWage * _StandartHoursForTheCurrentMonth) _
                        + _ConventionalExtraPay) / _StandartDaysForTheCurrentMonth)

                Else

                    _ApplicableVDUHourly = CRound((_ConventionalWage + _ConventionalExtraPay) _
                        / _StandartHoursForTheCurrentMonth)
                    _ApplicableVDUDaily = CRound((_ConventionalWage + _ConventionalExtraPay) _
                        / _StandartDaysForTheCurrentMonth)

                End If

            End If

        End Sub

#End Region

    End Class

End Namespace