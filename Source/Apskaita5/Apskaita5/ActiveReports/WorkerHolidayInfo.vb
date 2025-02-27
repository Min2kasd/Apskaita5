﻿Imports ApskaitaObjects.Attributes

Namespace ActiveReports

    ''' <summary>
    ''' Represents a calculation of worker's holiday.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
Public NotInheritable Class WorkerHolidayInfo
        Inherits ReadOnlyBase(Of WorkerHolidayInfo)

#Region " Business Methods "

        Private _Date As Date = Today
        Private _IsForCompensation As Boolean = False
        Private _PersonID As Integer = 0
        Private _PersonName As String = ""
        Private _PersonCode As String = ""
        Private _PersonCodeSodra As String = ""
        Private _ContractSerial As String = ""
        Private _ContractNumber As Integer = 0
        Private _ContractDate As Date = Today
        Private _ContractTerminationDate As Date = Date.MaxValue
        Private _Position As String = ""
        Private _HolidayRate As Integer = 0
        Private _WorkLoad As Double = 0
        Private _TotalWorkPeriodInDays As Integer = 0
        Private _TotalWorkPeriodInYears As Double = 0
        Private _TotalCumulatedHolidayDays As Double = 0
        Private _TotalHolidayDaysGranted As Integer = 0
        Private _TotalHolidayDaysCompensated As Double = 0
        Private _TotalHolidayDaysCorrection As Double = 0
        Private _CompensationIsGranted As Boolean = False
        Private _TotalHolidayDaysUsed As Double = 0
        Private _TotalUnusedHolidayDays As Double = 0
        Private _HolidaySpentList As HolidaySpentItemList = Nothing
        Private _HolidayCalculatedList As HolidayCalculationPeriodList = Nothing


        ''' <summary>
        ''' Gets a date of the calculation.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property [Date]() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Date
            End Get
        End Property

        ''' <summary>
        ''' Whether the calculation is for compensation (i.e. for all the work period ignoring the calculation date).
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsForCompensation() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsForCompensation
            End Get
        End Property

        ''' <summary>
        ''' Gets an <see cref="General.Person.ID">ID of the person</see> (worker) that is assigned to the current labour contract.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property PersonID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonID
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
        Public ReadOnly Property PersonCodeSodra() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PersonCodeSodra.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets the serial number (code) of the current labour contract.
        ''' </summary>
        ''' <remarks>A labour contract is identified by a <see cref="Workers.WageItem.ContractSerial">serial number</see> 
        ''' and <see cref="Workers.WageItem.ContractNumber">running number</see> pair.</remarks>
        Public ReadOnly Property ContractSerial() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractSerial.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets the running number of the current labour contract.
        ''' </summary>
        ''' <remarks>A labour contract is identified by a <see cref="Workers.WageItem.ContractSerial">serial number</see> 
        ''' and <see cref="Workers.WageItem.ContractNumber">running number</see> pair.</remarks>
        Public ReadOnly Property ContractNumber() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractNumber
            End Get
        End Property

        ''' <summary>
        ''' Gets the date of the current labour contract.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ContractDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ContractDate
            End Get
        End Property

        ''' <summary>
        ''' Gets the termination date of the current labour contract.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ContractTerminationDate() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _ContractTerminationDate = Date.MaxValue Then Return ""
                Return _ContractTerminationDate.ToString("yyyy-MM-dd")
            End Get
        End Property

        ''' <summary>
        ''' Whether the current labour contract is terminated.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ContractIsTerminated() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return (_ContractTerminationDate <> Date.MaxValue)
            End Get
        End Property

        ''' <summary>
        ''' Gets the workers position for the current labour contract.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Position() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Position.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets the holiday rate (holiday days per work year) for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property HolidayRate() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HolidayRate
            End Get
        End Property

        ''' <summary>
        ''' Gets the current applicable work load for the current labour contract for the current month.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKLOAD)> _
        Public ReadOnly Property WorkLoad() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_WorkLoad, ROUNDWORKLOAD)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total length in days of all the periods that the holiday days are calculated for.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TotalWorkPeriodInDays() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TotalWorkPeriodInDays
            End Get
        End Property

        ''' <summary>
        ''' Gets the total length in years of all the periods that the holiday days are calculated for.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKYEARS)> _
        Public ReadOnly Property TotalWorkPeriodInYears() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalWorkPeriodInYears, ROUNDWORKYEARS)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total calculated holiday days.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDACCUMULATEDHOLIDAY)> _
        Public ReadOnly Property TotalCumulatedHolidayDays() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalCumulatedHolidayDays, ROUNDACCUMULATEDHOLIDAY)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total holiday days that were granted to the worker.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TotalHolidayDaysGranted() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TotalHolidayDaysGranted
            End Get
        End Property

        ''' <summary>
        ''' Gets the total holiday days that were compensated for the worker.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDACCUMULATEDHOLIDAY)> _
        Public ReadOnly Property TotalHolidayDaysCompensated() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalHolidayDaysCompensated, ROUNDACCUMULATEDHOLIDAY)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total holiday days in technical (manual) corrections.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDACCUMULATEDHOLIDAY)> _
        Public ReadOnly Property TotalHolidayDaysCorrection() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalHolidayDaysCorrection, ROUNDACCUMULATEDHOLIDAY)
            End Get
        End Property

        ''' <summary>
        ''' Whether a compensation was granted for the worker for the unused holiday days.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CompensationIsGranted() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CompensationIsGranted
            End Get
        End Property

        ''' <summary>
        ''' Gets the total holiday days in technical (manual) corrections.
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDACCUMULATEDHOLIDAY)> _
        Public ReadOnly Property TotalHolidayDaysUsed() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalHolidayDaysUsed)
            End Get
        End Property

        ''' <summary>
        ''' Gets the total unused holiday days (<see cref="TotalCumulatedHolidayDays">TotalCumulatedHolidayDays</see> - <see cref="TotalHolidayDaysUsed">TotalHolidayDaysUsed</see>).
        ''' </summary>
        ''' <remarks></remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDACCUMULATEDHOLIDAY)> _
        Public ReadOnly Property TotalUnusedHolidayDays() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_TotalUnusedHolidayDays, ROUNDACCUMULATEDHOLIDAY)
            End Get
        End Property

        ''' <summary>
        ''' A list of info about the used holiday days.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property HolidaySpentList() As HolidaySpentItemList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HolidaySpentList
            End Get
        End Property

        ''' <summary>
        ''' A list of info about the calculated holiday days.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property HolidayCalculatedList() As HolidayCalculationPeriodList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _HolidayCalculatedList
            End Get
        End Property


        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.ActiveReports_WorkerHolidayInfo_ToString, _PersonName, _
                _ContractSerial, _ContractNumber)
        End Function

        Protected Overrides Function GetIdValue() As Object
            Return _ContractSerial & _ContractNumber.ToString & _Date.ToString("yyyyMMdd")
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

            ' TODO: add authorization rules
            'AuthorizationRules.AllowRead("", "")

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("ActiveReports.WorkerHolidayInfo1")
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetWorkerHolidayInfo(ByVal nDate As Date, _
            ByVal nContractSerial As String, ByVal nContractNumber As Integer, _
            ByVal nIsForCompensation As Boolean) As WorkerHolidayInfo
            Return DataPortal.Fetch(Of WorkerHolidayInfo)(New Criteria(nDate, _
                nContractSerial, nContractNumber, nIsForCompensation))
        End Function

        Friend Shared Function GetWorkerHolidayInfoChild(ByVal nDate As Date, _
            ByVal nContractSerial As String, ByVal nContractNumber As Integer, _
            ByVal nIsForCompensation As Boolean) As WorkerHolidayInfo
            Return New WorkerHolidayInfo(nDate, nContractSerial, nContractNumber, _
                nIsForCompensation)
        End Function

        Friend Shared Function GetWorkerHolidayInfoChild(ByVal nDate As Date, _
            ByVal dr As DataRow) As WorkerHolidayInfo
            Return New WorkerHolidayInfo(nDate, dr)
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal nDate As Date, ByVal nContractSerial As String, _
            ByVal nContractNumber As Integer, ByVal nIsForCompensation As Boolean)
            Fetch(nDate, nContractSerial, nContractNumber, nIsForCompensation)
        End Sub

        Private Sub New(ByVal nDate As Date, ByVal dr As DataRow)
            Fetch(nDate, dr)
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _ContractNumber As Integer = 0
            Private _ContractSerial As String = ""
            Private _Date As Date = Today
            Private _IsForCompensation As Boolean = False
            Public ReadOnly Property ContractNumber() As Integer
                Get
                    Return _ContractNumber
                End Get
            End Property
            Public ReadOnly Property ContractSerial() As String
                Get
                    Return _ContractSerial
                End Get
            End Property
            Public ReadOnly Property IsForCompensation() As Boolean
                Get
                    Return _IsForCompensation
                End Get
            End Property
            Public ReadOnly Property [Date]() As Date
                Get
                    Return _Date
                End Get
            End Property
            Public Sub New(ByVal nDate As Date, ByVal nContractSerial As String, _
                ByVal nContractNumber As Integer, ByVal nIsForCompensation As Boolean)
                _Date = nDate
                _ContractNumber = nContractNumber
                _ContractSerial = nContractSerial
                _IsForCompensation = nIsForCompensation
            End Sub
        End Class


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Fetch(criteria.Date, criteria.ContractSerial, criteria.ContractNumber, _
                  criteria.IsForCompensation)

        End Sub

        Private Sub Fetch(ByVal nDate As Date, ByVal nContractSerial As String, _
            ByVal nContractNumber As Integer, ByVal nIsForCompensation As Boolean)

            If Not nContractNumber > 0 Then
                Throw New Exception(My.Resources.ActiveReports_WorkerHolidayInfo_ContractNumberNull)
            End If

            _Date = nDate.Date
            _ContractNumber = nContractNumber
            _ContractSerial = nContractSerial
            _IsForCompensation = nIsForCompensation

            Dim myComm As New SQLCommand("FetchWorkerHolidayInfoGeneral")
            myComm.AddParam("?DT", nDate)
            myComm.AddParam("?CS", nContractSerial)
            myComm.AddParam("?CN", nContractNumber)
            myComm.AddParam("?UH", ConvertDbBoolean(nIsForCompensation))

            Using myData As DataTable = myComm.Fetch

                If myData.Rows.Count < 1 Then Throw New Exception(String.Format( _
                    My.Resources.ActiveReports_WorkerHolidayInfo_ContractNotFound, _
                    nContractSerial & nContractNumber.ToString()))

                Dim dr As DataRow = myData.Rows(0)

                _PersonID = CIntSafe(dr.Item(0), 0)
                _PersonName = CStrSafe(dr.Item(1))
                _PersonCode = CStrSafe(dr.Item(2))
                _PersonCodeSodra = CStrSafe(dr.Item(3))
                _ContractSerial = CStrSafe(dr.Item(4))
                _ContractNumber = CIntSafe(dr.Item(5), 0)
                _ContractDate = CDateSafe(dr.Item(6), Date.MinValue)
                _ContractTerminationDate = CDateSafe(dr.Item(7), Date.MaxValue)
                _HolidayRate = CIntSafe(dr.Item(8), 0)
                _WorkLoad = CDblSafe(dr.Item(9), ROUNDWORKLOAD, 0)
                _Position = CStrSafe(dr.Item(10))

            End Using

            If nIsForCompensation AndAlso _ContractTerminationDate = Date.MaxValue Then
                Throw New Exception(My.Resources.ActiveReports_WorkerHolidayInfo_ContractIsNotTerminated)
            End If

            FetchDetails(nDate, nContractSerial, nContractNumber, nIsForCompensation)

        End Sub

        Private Sub Fetch(ByVal nDate As Date, ByVal dr As DataRow)

            _Date = nDate.Date
            _IsForCompensation = False
            _PersonID = CIntSafe(dr.Item(0), 0)
            _PersonName = CStrSafe(dr.Item(1))
            _PersonCode = CStrSafe(dr.Item(2))
            _PersonCodeSodra = CStrSafe(dr.Item(3))
            _ContractSerial = CStrSafe(dr.Item(4))
            _ContractNumber = CIntSafe(dr.Item(5), 0)
            _ContractDate = CDateSafe(dr.Item(6), Date.MinValue)
            _ContractTerminationDate = CDateSafe(dr.Item(7), Date.MaxValue)
            _HolidayRate = CIntSafe(dr.Item(8), 0)
            _WorkLoad = CDblSafe(dr.Item(9), ROUNDWORKLOAD, 0)
            _Position = CStrSafe(dr.Item(10))

            FetchDetails(nDate, _ContractSerial, _ContractNumber, False)

        End Sub

        Private Sub FetchDetails(ByVal nDate As Date, ByVal nContractSerial As String, _
            ByVal nContractNumber As Integer, ByVal nIsForCompensation As Boolean)

            Dim myComm As New SQLCommand("FetchHolidaySpentItemList")
            myComm.AddParam("?DT", nDate)
            myComm.AddParam("?CS", nContractSerial)
            myComm.AddParam("?CN", nContractNumber)
            myComm.AddParam("?UH", ConvertDbBoolean(nIsForCompensation))

            Using myData As DataTable = myComm.Fetch
                _HolidaySpentList = HolidaySpentItemList.GetHolidaySpentItemList(myData)
            End Using

            myComm = New SQLCommand("FetchHolidayCalculationPeriodList")
            myComm.AddParam("?DT", nDate)
            myComm.AddParam("?CS", nContractSerial)
            myComm.AddParam("?CN", nContractNumber)
            myComm.AddParam("?UH", ConvertDbBoolean(nIsForCompensation))

            Using myData As DataTable = myComm.Fetch
                _HolidayCalculatedList = HolidayCalculationPeriodList.GetHolidayCalculationPeriodList( _
                    myData, nDate, nIsForCompensation)
            End Using

            _TotalWorkPeriodInDays = _HolidayCalculatedList.GetTotalPeriodInDays()
            _TotalWorkPeriodInYears = _HolidayCalculatedList.GetTotalPeriodInYears()
            _TotalCumulatedHolidayDays = _HolidayCalculatedList.GetTotalCumulatedHolidayDays()
            _TotalHolidayDaysGranted = _HolidaySpentList.GetSpent()
            _TotalHolidayDaysCompensated = _HolidaySpentList.GetCompensated()
            _TotalHolidayDaysCorrection = _HolidaySpentList.GetCorrections()
            _CompensationIsGranted = _HolidaySpentList.IncludesCompensation()
            _TotalHolidayDaysUsed = _HolidaySpentList.GetTotal()
            _TotalUnusedHolidayDays = CRound(_TotalCumulatedHolidayDays - _
                _TotalHolidayDaysUsed, ROUNDACCUMULATEDHOLIDAY)

        End Sub

#End Region

    End Class

End Namespace