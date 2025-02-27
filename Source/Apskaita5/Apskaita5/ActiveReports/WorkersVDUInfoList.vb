﻿Namespace ActiveReports

    ''' <summary>
    ''' Represents a list of VDU (average wage) calculations. 
    ''' Used to fetch multiple calculations for a <see cref="Workers.WageSheet">WageSheet</see>.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public NotInheritable Class WorkersVDUInfoList
        Inherits ReadOnlyListBase(Of WorkersVDUInfoList, WorkersVDUInfo)

        Public Function GetWorkersVDUInfo(ByVal nSerial As String, _
            ByVal nNumber As Integer) As WorkersVDUInfo
            For Each s As WorkersVDUInfo In Me
                If s.ContractSerial.Trim.ToLower = nSerial.Trim.ToLower AndAlso _
                    s.ContractNumber = nNumber Then Return s
            Next
            Return Nothing
        End Function

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return WorkersVDUInfo.CanGetObject()
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a list of calculations for the provided list of contracts.
        ''' </summary>
        ''' <param name="workersToFetch">A list of labour contracts.</param>
        ''' <remarks></remarks>
        Public Shared Function GetList(ByVal workersToFetch As WorkersVDUInfo()) As WorkersVDUInfoList
            Return DataPortal.Fetch(Of WorkersVDUInfoList)(New Criteria(workersToFetch))
        End Function

        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private ReadOnly _WorkersToFetch As WorkersVDUInfo()
            Public ReadOnly Property WorkersToFetch() As WorkersVDUInfo()
                Get
                    Return _WorkersToFetch
                End Get
            End Property
            Public Sub New(ByVal nWorkersToFetch As WorkersVDUInfo())
                _WorkersToFetch = nWorkersToFetch
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            If criteria.WorkersToFetch Is Nothing OrElse criteria.WorkersToFetch.Length < 1 Then
                Throw New Exception(My.Resources.ActiveReports_WorkersVDUInfoList_ContractListEmpty)
            End If

            For Each i As WorkersVDUInfo In criteria.WorkersToFetch
                i.FetchDetails()
            Next

            RaiseListChangedEvents = False
            IsReadOnly = False
            For Each i As WorkersVDUInfo In criteria.WorkersToFetch
                Add(i)
            Next
            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace