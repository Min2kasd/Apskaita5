﻿Namespace ActiveReports

    ''' <summary>
    ''' Represents a list of social security (SODRA) rates that were applied in a certain month.
    ''' </summary>
    ''' <remarks>Used as a datasource in declarations.</remarks>
    <Serializable()> _
    Public NotInheritable Class SodraRateInfo
        Inherits ReadOnlyBase(Of SodraRateInfo)

#Region " Business Methods "

        Private _Rates As List(Of Double)
        Private _Year As Integer = Today.Year
        Private _Month As Integer = Today.Month


        ''' <summary>
        ''' A list of (distinct) social security (SODRA) rates that were applied.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Rates() As List(Of Double)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Rates
            End Get
        End Property

        ''' <summary>
        ''' Year of the rates applied.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Year() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Year
            End Get
        End Property

        ''' <summary>
        ''' Month of the rates applied.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Month() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Month
            End Get
        End Property



        Protected Overrides Function GetIdValue() As Object
            Return _Year.ToString & "-" & _Month.ToString
        End Function

        Public Overrides Function ToString() As String
            Return _Year.ToString & "-" & _Month.ToString
        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Workers.Declaration1")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a list of social security (SODRA) rates that were applied in a certain month.
        ''' </summary>
        ''' <param name="nYear">Year of the rates applied.</param>
        ''' <param name="nMonth">Month of the rates applied.</param>
        ''' <remarks></remarks>
        Public Shared Function GetSodraRateInfo(ByVal nYear As Integer, ByVal nMonth As Integer) As SodraRateInfo
            Return DataPortal.Fetch(Of SodraRateInfo)(New Criteria(nYear, nMonth))
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _Year As Integer
            Private _Month As Integer
            Public ReadOnly Property Year() As Integer
                Get
                    Return _Year
                End Get
            End Property
            Public ReadOnly Property Month() As Integer
                Get
                    Return _Month
                End Get
            End Property
            Public Sub New(ByVal nYear As Integer, ByVal nMonth As Integer)
                _Year = nYear
                If nMonth < 1 Then nMonth = 1
                If nMonth > 12 Then nMonth = 12
                _Month = nMonth
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            Dim myComm As SQLCommand
            If criteria.Year < 2017 Then
                myComm = New SQLCommand("FetchDeclarationSAM(1)_2")
            Else
                myComm = New SQLCommand("FetchSodraRateInfo")
            End If
            myComm.AddParam("?YR", criteria.Year)
            myComm.AddParam("?MF", criteria.Month)
            myComm.AddParam("?MT", criteria.Month)

            Using myData As DataTable = myComm.Fetch

                _Rates = New List(Of Double)

                If criteria.Year < 2017 Then

                    If Not myData.Rows.Count > 0 Then

                        _Rates.Add(CRound(GetCurrentCompany.Rates.GetRate(General.DefaultRateType.SodraEmployee) + _
                            GetCurrentCompany.Rates.GetRate(General.DefaultRateType.SodraEmployer) + _
                            GetCurrentCompany.Rates.GetRate(General.DefaultRateType.PsdEmployee) + _
                            GetCurrentCompany.Rates.GetRate(General.DefaultRateType.PsdEmployer)))

                    Else

                        For Each dr As DataRow In myData.Rows
                            _Rates.Add(CRound(CDblSafe(dr.Item(0), 2, 0) + CDblSafe(dr.Item(1), 2, 0) _
                                + CDblSafe(dr.Item(2), 2, 0) + CDblSafe(dr.Item(3), 2, 0)))
                        Next
                        _Rates.Sort()

                    End If

                Else

                    If Not myData.Rows.Count > 0 Then

                        _Rates.Add(CRound(GetCurrentCompany.Rates.GetRate(General.DefaultRateType.SodraEmployee) + _
                            GetCurrentCompany.Rates.GetRate(General.DefaultRateType.SodraEmployer) + _
                            GetCurrentCompany.Rates.GetRate(General.DefaultRateType.PsdEmployee) + _
                            GetCurrentCompany.Rates.GetRate(General.DefaultRateType.PsdEmployer) + _
                            GetCurrentCompany.Rates.GetRate(General.DefaultRateType.GuaranteeFund)))

                    Else

                        For Each dr As DataRow In myData.Rows
                            _Rates.Add(CRound(CDblSafe(dr.Item(0), 2, 0) + CDblSafe(dr.Item(1), 2, 0) _
                                + CDblSafe(dr.Item(2), 2, 0) + CDblSafe(dr.Item(3), 2, 0) _
                                + CDblSafe(dr.Item(4), 2, 0)))
                        Next
                        _Rates.Sort()

                    End If

                End If

                _Year = criteria.Year
                _Month = criteria.Month

            End Using

        End Sub

#End Region

    End Class

End Namespace