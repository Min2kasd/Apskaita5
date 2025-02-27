﻿Namespace Assets

    ''' <summary>
    ''' Represents a collection of info objects that provide calculations 
    ''' of long term asset amortization/depreciation.
    ''' </summary>
    ''' <remarks>Used to fetch long term asset amortization/depreciation
    ''' calculations for multiple assets in one request.</remarks>
    <Serializable()> _
Public NotInheritable Class LongTermAssetAmortizationCalculationList
        Inherits ReadOnlyListBase(Of LongTermAssetAmortizationCalculationList,  _
            LongTermAssetAmortizationCalculation)

#Region " Authorization Rules "

        Public Shared Function CanGetObject() As Boolean
            Return ApplicationContext.User.IsInRole("Assets.LongTermAssetOperation2")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new instance of LongTermAssetAmortizationCalculationList.
        ''' </summary>
        ''' <param name="assetIDs">An array of long term asset id's that the
        ''' amortization/depreciation calculations are fetched for.</param>
        ''' <param name="editedAmortizationOperationIDs">An array of the 
        ''' currently edited long term asset operations id's (the operations
        ''' should be ignored when calculating). The operations id's
        ''' should match asset id's in count and order.</param>
        ''' <param name="dateTo">A date that the amortization/depreciation 
        ''' calculations are fetched for.</param>
        ''' <remarks></remarks>
        Public Shared Function GetList(ByVal assetIDs As Integer(), _
            ByVal editedAmortizationOperationIDs As Integer(), _
            ByVal dateTo As Date) As LongTermAssetAmortizationCalculationList
            Return DataPortal.Fetch(Of LongTermAssetAmortizationCalculationList)( _
                New Criteria(assetIDs, editedAmortizationOperationIDs, dateTo))
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Private _AssetID As Integer()
            Private _EditedAmortizationOperationID As Integer()
            Private _DateTo As Date
            Public ReadOnly Property AssetID() As Integer()
                Get
                    Return _AssetID
                End Get
            End Property
            Public ReadOnly Property EditedAmortizationOperationID() As Integer()
                Get
                    Return _EditedAmortizationOperationID
                End Get
            End Property
            Public ReadOnly Property DateTo() As Date
                Get
                    Return _DateTo
                End Get
            End Property
            Public Sub New(ByVal nAssetID As Integer(), ByVal nEditedAmortizationOperationID As Integer(), _
                ByVal nDateTo As Date)
                _AssetID = nAssetID
                _EditedAmortizationOperationID = nEditedAmortizationOperationID
                _DateTo = nDateTo.Date
            End Sub
        End Class

        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            RaiseListChangedEvents = False
            IsReadOnly = False

            For i As Integer = 1 To criteria.AssetID.Length
                Add(LongTermAssetAmortizationCalculation. _
                    GetLongTermAssetAmortizationCalculationChild( _
                    criteria.AssetID(i - 1), criteria.EditedAmortizationOperationID(i - 1), _
                    criteria.DateTo))
            Next

            IsReadOnly = True
            RaiseListChangedEvents = True

        End Sub

#End Region

    End Class

End Namespace