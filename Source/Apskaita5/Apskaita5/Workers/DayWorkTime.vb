﻿Imports ApskaitaObjects.Attributes

Namespace Workers

    ''' <summary>
    ''' Represents normal work time duration or rest time for a certain labour contract for a certain day.
    ''' </summary>
    ''' <remarks>Should only be used as a child of a <see cref="DayWorkTimeList">DayWorkTimeList</see>.
    ''' Values are stored in the database table dayworktimes.</remarks>
    <Serializable()> _
    Public NotInheritable Class DayWorkTime
        Inherits BusinessBase(Of DayWorkTime)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _DayNumber As Integer = 0
        Private _Type As WorkTimeClassInfo = Nothing
        Private _Length As Double = 0
        Private _DayCount As Integer = 31


        ''' <summary>
        ''' Gets an ID of the work time item that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database table dayworktimes.ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets a day which the work time duration is set for.
        ''' </summary>
        ''' <remarks>Value is stored in the database table dayworktimes.DayNumber.</remarks>
        Public ReadOnly Property DayNumber() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DayNumber
            End Get
        End Property

        ''' <summary>
        ''' Gets a days count within the current month.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DayCount() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DayCount
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a type of the work time.
        ''' </summary>
        ''' <remarks>Use <see cref="HelperLists.WorkTimeClassInfoList">WorkTimeClassInfoList</see> for datasource.
        ''' Value is stored in the database table column dayworktimes.TypeID.</remarks>
        <WorkTimeClassField(ValueRequiredLevel.Optional, False, True)> _
        Public Property [Type]() As WorkTimeClassInfo
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Type
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As WorkTimeClassInfo)
                CanWriteProperty(True)
                If Not (_Type Is Nothing AndAlso value Is Nothing) _
                    AndAlso Not (Not _Type Is Nothing AndAlso Not value Is Nothing _
                    AndAlso _Type = value) AndAlso Not _DayNumber > _DayCount Then
                    _Type = value
                    PropertyHasChanged()
                    PropertyHasChanged("TypeCode")
                    If Not _Type Is Nothing AndAlso _Type.ID > 0 Then Length = 0
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a type code of the work time.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TypeCode() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _Type Is Nothing OrElse Not _Type.ID > 0 Then Return ""
                Return _Type.Code
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a duration of the work time in hours.
        ''' </summary>
        ''' <remarks>Value is stored in the database table column dayworktimes.Length.</remarks>
        <DoubleField(ValueRequiredLevel.Optional, False, ROUNDWORKHOURS, True, 0.0, 24.0, True)> _
        Public Property Length() As Double
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return CRound(_Length, ROUNDWORKHOURS)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Double)
                CanWriteProperty(True)
                If CRound(_Length, ROUNDWORKHOURS) <> CRound(value, ROUNDWORKHOURS) _
                    AndAlso Not _DayNumber > _DayCount Then
                    _Length = CRound(value, ROUNDWORKHOURS)
                    PropertyHasChanged()
                End If
            End Set
        End Property



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


        Friend Function SetLength(ByVal value As Double) As Boolean
            If CRound(_Length, ROUNDWORKHOURS) <> CRound(value, ROUNDWORKHOURS) _
                AndAlso Not _DayNumber > _DayCount Then
                _Length = CRound(value, ROUNDWORKHOURS)
                PropertyHasChanged("Length")
                Return True
            Else
                Return False
            End If
        End Function

        Friend Function SetType(ByVal value As WorkTimeClassInfo) As Boolean
            If Not (_Type Is Nothing AndAlso value Is Nothing) _
                AndAlso Not (Not _Type Is Nothing AndAlso Not value Is Nothing _
                AndAlso _Type = value) AndAlso Not _DayNumber > _DayCount Then
                _Type = value
                PropertyHasChanged("Type")
                PropertyHasChanged("TypeCode")
                If Not _Type Is Nothing AndAlso _Type.ID > 0 Then Length = 0
                Return True
            Else
                Return False
            End If
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Workers_DayWorkTime_ToString, _DayNumber.ToString())
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf LengthValidation, New Validation.RuleArgs("Length"))
            ValidationRules.AddDependantProperty("Type", "Length", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property Length is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function LengthValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As DayWorkTime = DirectCast(target, DayWorkTime)

            If valObj._DayNumber > valObj._DayCount Then Return True

            If (valObj._Type Is Nothing OrElse valObj._Type.IsEmpty) _
                AndAlso Not CRound(valObj._Length, ROUNDWORKHOURS) > 0 Then
                e.Description = My.Resources.Workers_DayWorkTime_ValueNull
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf (valObj._Type Is Nothing OrElse valObj._Type.IsEmpty) _
                AndAlso CRound(valObj._Length, ROUNDWORKHOURS) > 24 Then
                e.Description = My.Resources.Workers_DayWorkTime_ValueInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf Not valObj._Type Is Nothing AndAlso Not valObj._Type.IsEmpty _
                AndAlso Not valObj._Type.WithoutWorkHours Then
                e.Description = My.Resources.Workers_DayWorkTime_TypeInvalid
                e.Severity = Validation.RuleSeverity.Error
                Return False
            ElseIf CRound(valObj._Length, ROUNDWORKHOURS) < 0 Then
                e.Description = My.Resources.Workers_DayWorkTime_ValueNegative
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

        ''' <summary>
        ''' Gets a new DayWorkTime instance.
        ''' </summary>
        ''' <param name="nDayNumber">Day number for the new instance.</param>
        ''' <param name="cYear">Year for the new instance.</param>
        ''' <param name="cMonth">Month for the new instance.</param>
        ''' <param name="workLoad">Workers workload at the day (ratio between contractual work hours and gauge work hours (40H/Week)).</param>
        ''' <param name="hasContract">Whether the worker has a valid contract at the day.</param>
        ''' <param name="restDayInfo">Default type for a rest day.</param>
        ''' <param name="publicHolydaysInfo">Default type for a public holiday day.</param>
        ''' <remarks></remarks>
        Friend Shared Function NewDayWorkTime(ByVal nDayNumber As Integer, _
            ByVal cYear As Integer, ByVal cMonth As Integer, ByVal workLoad As Double, _
            ByVal hasContract As Boolean, ByVal restDayInfo As WorkTimeClassInfo, _
            ByVal publicHolydaysInfo As WorkTimeClassInfo, _
            ByVal cWorkTimeList As DefaultWorkTimeInfoList) As DayWorkTime
            Return New DayWorkTime(nDayNumber, cYear, cMonth, workLoad, hasContract, _
                restDayInfo, publicHolydaysInfo, cWorkTimeList)
        End Function

        ''' <summary>
        ''' Gets an existing DayWorkTime instance from a database.
        ''' </summary>
        ''' <param name="dr">Database query result.</param>
        ''' <param name="cMaxDayCount">Number of days within the current month.</param>
        ''' <remarks></remarks>
        Friend Shared Function GetDayWorkTime(ByVal dr As DataRow, ByVal cMaxDayCount As Integer) As DayWorkTime
            Return New DayWorkTime(dr, cMaxDayCount)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal nDayNumber As Integer, ByVal cYear As Integer, _
            ByVal cMonth As Integer, ByVal workLoad As Double, ByVal hasContract As Boolean, _
            ByVal restDayInfo As WorkTimeClassInfo, _
            ByVal publicHolydaysInfo As WorkTimeClassInfo, _
            ByVal cWorkTimeList As DefaultWorkTimeInfoList)
            MarkAsChild()
            Create(nDayNumber, cYear, cMonth, workLoad, hasContract, _
                restDayInfo, publicHolydaysInfo, cWorkTimeList)
        End Sub

        Private Sub New(ByVal dr As DataRow, ByVal cMaxDayCount As Integer)
            MarkAsChild()
            Fetch(dr, cMaxDayCount)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal nDayNumber As Integer, ByVal cYear As Integer, _
            ByVal cMonth As Integer, ByVal workLoad As Double, ByVal hasContract As Boolean, _
            ByVal restDayInfo As WorkTimeClassInfo, _
            ByVal publicHolydaysInfo As WorkTimeClassInfo, _
            ByVal cWorkTimeList As DefaultWorkTimeInfoList)

            _DayNumber = nDayNumber
            _DayCount = Date.DaysInMonth(cYear, cMonth)
            If hasContract AndAlso _DayNumber <= _DayCount Then
                If cWorkTimeList.IsPublicHolidays(cYear, cMonth, nDayNumber) Then
                    _Type = publicHolydaysInfo
                ElseIf (New Date(cYear, cMonth, _DayNumber)).DayOfWeek = DayOfWeek.Sunday _
                    OrElse (New Date(cYear, cMonth, _DayNumber)).DayOfWeek = DayOfWeek.Saturday Then
                    _Type = restDayInfo
                Else
                    _Length = CRound(8 * workLoad, ROUNDWORKHOURS)
                End If
            End If

            ValidationRules.CheckRules()

        End Sub

        Private Sub Fetch(ByVal dr As DataRow, ByVal cMaxDayCount As Integer)

            _ID = CIntSafe(dr.Item(1), 0)
            _DayNumber = CIntSafe(dr.Item(2), 0)
            _Length = CDblSafe(dr.Item(3), ROUNDWORKHOURS, 0)
            _Type = WorkTimeClassInfo.GetWorkTimeClassInfo(dr, 4)
            _DayCount = cMaxDayCount

            MarkOld()
            ValidationRules.CheckRules()

        End Sub

        Friend Sub Insert(ByVal parent As WorkTimeItem)

            Dim myComm As New SQLCommand("InsertDayWorkTime")
            AddWithParams(myComm)
            myComm.AddParam("?AA", _DayNumber)
            myComm.AddParam("?PD", parent.ID)

            myComm.Execute()

            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As WorkTimeItem)

            Dim myComm As New SQLCommand("UpdateDayWorkTime")
            myComm.AddParam("?CD", _ID)
            AddWithParams(myComm)

            myComm.Execute()

            MarkOld()

        End Sub

        Private Sub AddWithParams(ByRef myComm As SQLCommand)
            myComm.AddParam("?AB", CRound(_Length, ROUNDWORKHOURS))
            If _Type Is Nothing OrElse Not _Type.ID > 0 Then
                myComm.AddParam("?AC", 0)
            Else
                myComm.AddParam("?AC", _Type.ID)
            End If
        End Sub

#End Region

    End Class

End Namespace