﻿Imports ApskaitaObjects.Attributes

Namespace ActiveReports

    ''' <summary>
    ''' Represents an item of the work time sheet report. Contains information about a work time sheet. 
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="WorkTimeSheetInfoList">WorkTimeSheetInfoList</see>.
    ''' Values are stored in the database tables worktimesheets, dayworktimes, worktimeitems and specialworktimeitems.</remarks>
    <Serializable()> _
    Public NotInheritable Class WorkTimeSheetInfo
        Inherits ReadOnlyBase(Of WorkTimeSheetInfo)

#Region " Business Methods "

        Private _ID As Integer = 0
        Private _Date As Date = Today
        Private _Year As Integer = 0
        Private _Month As Integer = 0
        Private _SubDivision As String = ""
        Private _WorkersCount As Integer = 0
        Private _TotalWorkDays As Integer = 0
        Private _TotalWorkTime As Double = 0
        Private _NightWork As Double = 0
        Private _OvertimeWork As Double = 0
        Private _PublicHolidaysAndRestDayWork As Double = 0
        Private _UnusualWork As Double = 0
        Private _Truancy As Double = 0
        Private _DownTime As Double = 0
        Private _SickDays As Integer = 0
        Private _AnnualHolidays As Integer = 0
        Private _OtherHolidays As Integer = 0
        Private _OtherIncluded As Double = 0
        Private _OtherExcluded As Double = 0


        ''' <summary>
        ''' Gets an ID of the sheet that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database table worktimesheets.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets the date of the sheet.
        ''' </summary>
        ''' <remarks>Value is stored in the database field worktimesheets.SheetDate.</remarks>
        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        ''' <summary>
        ''' Gets the year of the sheet.
        ''' </summary>
        ''' <remarks>Value is stored in the database field worktimesheets.SheetYear.</remarks>
        Public ReadOnly Property Year() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Year
            End Get
        End Property

        ''' <summary>
        ''' Gets the month of the sheet.
        ''' </summary>
        ''' <remarks>Value is stored in the database field worktimesheets.SheetMonth.</remarks>
        Public ReadOnly Property Month() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Month
            End Get
        End Property

        ''' <summary>
        ''' Gets the subdivision of the company that the sheet is ment for.
        ''' </summary>
        ''' <remarks>Value is stored in the database field worktimesheets.SubDivision.</remarks>
        Public ReadOnly Property SubDivision() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SubDivision.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets the total workers count within the sheet.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property WorkersCount() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WorkersCount
            End Get
        End Property

        ''' <summary>
        ''' Gets the total general work days within the sheet.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TotalWorkDays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TotalWorkDays
            End Get
        End Property

        ''' <summary>
        ''' Gets the total general work hours within the sheet.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public ReadOnly Property TotalWorkTime() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalWorkTime, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total night work hours within the sheet.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public ReadOnly Property NightWork() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_NightWork, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total overtime hours within the sheet.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public ReadOnly Property OvertimeWork() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OvertimeWork, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total work hours during public holiday and (or) rest days within the sheet.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public ReadOnly Property PublicHolidaysAndRestDayWork() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_PublicHolidaysAndRestDayWork, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total unusual (specific) work hours within the sheet.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public ReadOnly Property UnusualWork() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_UnusualWork, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total truancy hours within the sheet.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public ReadOnly Property Truancy() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Truancy, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total downtime hours within the sheet.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public ReadOnly Property DownTime() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_DownTime, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total sickness days within the sheet.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SickDays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SickDays
            End Get
        End Property

        ''' <summary>
        ''' Gets the total annual holiday days within the sheet.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AnnualHolidays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AnnualHolidays
            End Get
        End Property

        ''' <summary>
        ''' Gets the total days of other holiday within the sheet.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property OtherHolidays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _OtherHolidays
            End Get
        End Property

        ''' <summary>
        ''' Gets the total other hours, that are included into work time, within the sheet.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public ReadOnly Property OtherIncluded() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OtherIncluded, ROUNDWORKHOURS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total other hours, that are not included into work time, within the sheet.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS)> _
        Public ReadOnly Property OtherExcluded() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_OtherExcluded, ROUNDWORKHOURS)
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _ID
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Workers_WorkTimeSheet_ToString, _
                _Date.ToString("yyyy-MM-dd"), _Year.ToString(), _Month.ToString(), _ID.ToString())
        End Function

#End Region

#Region " Factory Methods "

        Friend Shared Function GetWorkTimeSheetInfo(ByVal dr As DataRow) As WorkTimeSheetInfo
            Return New WorkTimeSheetInfo(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal dr As DataRow)
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(0), 0)
            _Date = CDateSafe(dr.Item(1), Today)
            _Year = CIntSafe(dr.Item(2), 0)
            _Month = CIntSafe(dr.Item(3), 0)
            _SubDivision = CStrSafe(dr.Item(4)).Trim
            _WorkersCount = CIntSafe(dr.Item(5), 0)
            _TotalWorkDays = CIntSafe(dr.Item(6), 0)
            _TotalWorkTime = CDblSafe(dr.Item(7), ROUNDWORKHOURS, 0)
            _NightWork = CDblSafe(dr.Item(8), ROUNDWORKHOURS, 0)
            _OvertimeWork = CDblSafe(dr.Item(9), ROUNDWORKHOURS, 0)
            _PublicHolidaysAndRestDayWork = CDblSafe(dr.Item(10), ROUNDWORKHOURS, 0)
            _UnusualWork = CDblSafe(dr.Item(11), ROUNDWORKHOURS, 0)
            _Truancy = CDblSafe(dr.Item(12), ROUNDWORKHOURS, 0)
            _DownTime = CDblSafe(dr.Item(13), ROUNDWORKHOURS, 0)
            _OtherExcluded = CDblSafe(dr.Item(14), ROUNDWORKHOURS, 0)
            _OtherIncluded = CDblSafe(dr.Item(15), ROUNDWORKHOURS, 0)
            _SickDays = CIntSafe(dr.Item(16), 0)
            _AnnualHolidays = CIntSafe(dr.Item(17), 0)
            _OtherHolidays = CIntSafe(dr.Item(18), 0)

        End Sub

#End Region

    End Class

End Namespace