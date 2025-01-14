﻿Namespace Assets

    ''' <summary>
    ''' Represents an <see cref="IChronologicValidator">IChronologicValidator</see> instance 
    ''' that is used to validate long term asset acquisition data chronologic restrains.
    ''' </summary>
    ''' <remarks>Should only be used as a child of <see cref="LongTermAsset">a long term asset</see>.</remarks>
    <Serializable()> _
    Public NotInheritable Class AcquisitionChronologicValidator
        Inherits ReadOnlyBase(Of AcquisitionChronologicValidator)
        Implements IChronologicValidator

#Region " Business Methods "

        Private _CurrentOperationID As Integer = 0
        Private _CurrentOperationDate As Date = Today
        Private _FinancialDataCanChange As Boolean = True
        Private _MinDateApplicable As Boolean = False
        Private _MaxDateApplicable As Boolean = False
        Private _MinDate As Date = Date.MinValue
        Private _MaxDate As Date = Date.MaxValue
        Private _FinancialDataCanChangeExplanation As String = ""
        Private _MinDateExplanation As String = ""
        Private _MaxDateExplanation As String = ""
        Private _LimitsExplanation As String = ""
        Private _BackgroundExplanation As String = ""
        Private _AmortizationIsCalculated As Boolean = False
        Private _IsContinuedUsage As Boolean = False
        Private _ParentFinancialDataCanChange As Boolean = True
        Private _ParentFinancialDataCanChangeExplanation As String = ""


        ''' <summary>
        ''' Gets an <see cref="LongTermAsset.ID">ID of the validated (parent) long term asset object</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentOperationID() As Integer _
            Implements IChronologicValidator.CurrentOperationID
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationID
            End Get
        End Property

        ''' <summary>
        ''' Gets the <see cref="LongTermAsset.AcquisitionDate">current date of the 
        ''' validated (parent) long term asset object</see>
        ''' (<see cref="Today">Today</see> for a new object). 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentOperationDate() As Date _
            Implements IChronologicValidator.CurrentOperationDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CurrentOperationDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable name of the validated (parent) long term asset object. 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentOperationName() As String _
            Implements IChronologicValidator.CurrentOperationName
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return My.Resources.Assets_LongTermAsset_TypeName
            End Get
        End Property

        ''' <summary>
        ''' Wheather the financial data of the validated (parent) long term asset object 
        ''' is allowed to be changed.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property FinancialDataCanChange() As Boolean _
            Implements IChronologicValidator.FinancialDataCanChange
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Wheather there is a minimum allowed acquisition date for the validated (parent) asset.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MinDateApplicable() As Boolean _
            Implements IChronologicValidator.MinDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateApplicable
            End Get
        End Property

        ''' <summary>
        ''' Wheather there is a maximum allowed acquisition date for the validated (parent) asset.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MaxDateApplicable() As Boolean _
            Implements IChronologicValidator.MaxDateApplicable
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateApplicable
            End Get
        End Property

        ''' <summary>
        ''' Gets a minimum allowed acquisition date for the validated (parent) asset.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MinDate() As Date _
            Implements IChronologicValidator.MinDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a maximum allowed acquisition date for the validated (parent) asset.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MaxDate() As Date _
            Implements IChronologicValidator.MaxDate
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDate
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of why the financial data 
        ''' of the validated (parent) asset is NOT allowed to be changed.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property FinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.FinancialDataCanChangeExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _FinancialDataCanChangeExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of why there is a minimum allowed acquisition date 
        ''' for the validated (parent) asset.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MinDateExplanation() As String _
            Implements IChronologicValidator.MinDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MinDateExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of why there is a maximum allowed acquisition date 
        ''' for the validated (parent) asset.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property MaxDateExplanation() As String _
            Implements IChronologicValidator.MaxDateExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _MaxDateExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of all the applicable business rules restrains.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property LimitsExplanation() As String _
            Implements IChronologicValidator.LimitsExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LimitsExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' A human readable explanation of the applicable business rules restrains.
        ''' </summary>
        ''' <remarks>More exhaustive than <see cref="LimitsExplanation">LimitsExplanation</see>.</remarks>
        Public ReadOnly Property BackgroundExplanation() As String _
            Implements IChronologicValidator.BackgroundExplanation
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BackgroundExplanation.Trim
            End Get
        End Property

        ''' <summary>
        ''' Whether there were any amortization (depreciation) calculations for the validated (parent) asset. 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AmortizationIsCalculated() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AmortizationIsCalculated
            End Get
        End Property

        ''' <summary>
        ''' Whether the validated asset currently has <see cref="LongTermAsset.ContinuedUsage">
        ''' ContinuedUsage</see> property set to true. 
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsContinuedUsage() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsContinuedUsage
            End Get
        End Property

        ''' <summary>
        ''' Wheather the financial data of the validated (parent) long term asset 
        ''' is allowed to be changed by the operation's parent document.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ParentFinancialDataCanChange() As Boolean _
        Implements IChronologicValidator.ParentFinancialDataCanChange
            Get
                Return _ParentFinancialDataCanChange
            End Get
        End Property

        ''' <summary>
        ''' Gets a human readable explanation of why the financial data 
        ''' of the validated (parent) asset is NOT allowed to be changed
        ''' by the operation's parent document.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property ParentFinancialDataCanChangeExplanation() As String _
            Implements IChronologicValidator.ParentFinancialDataCanChangeExplanation
            Get
                Return _ParentFinancialDataCanChangeExplanation
            End Get
        End Property


        Public Function ValidateOperationDate(ByVal operationDate As Date, ByRef errorMessage As String, _
            ByRef errorSeverity As Csla.Validation.RuleSeverity) As Boolean _
            Implements IChronologicValidator.ValidateOperationDate

            If _MinDateApplicable AndAlso operationDate.Date < _MinDate.Date Then
                errorMessage = _MinDateExplanation
                errorSeverity = Validation.RuleSeverity.Error
                Return False
            ElseIf _MaxDateApplicable AndAlso operationDate.Date > _MaxDate.Date Then
                errorMessage = _MaxDateExplanation
                errorSeverity = Validation.RuleSeverity.Error
                Return False
            End If

            Return True

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _CurrentOperationID
        End Function

        Public Overrides Function ToString() As String
            Return My.Resources.Assets_AcquisitionChronologicValidator_ToString
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a new AcquisitionChronologicValidator instance for a new long term asset.
        ''' </summary>
        ''' <param name="parentChronologyValidator">The operation's parent document 
        ''' IChronologicValidator if any.</param>
        ''' <remarks></remarks>
        Friend Shared Function NewAcquisitionChronologicValidator( _
            ByVal parentChronologyValidator As IChronologicValidator) As AcquisitionChronologicValidator
            Return New AcquisitionChronologicValidator(parentChronologyValidator)
        End Function

        ''' <summary>
        ''' Gets a new AcquisitionChronologicValidator instance for an existing long term asset.
        ''' </summary>
        ''' <param name="assetID">an ID of the validated asset</param>
        ''' <param name="acquisitionDate">a current acquisition date of the validated asset</param>
        ''' <param name="isContinuedUsage">whether the validated asset currently has
        ''' <see cref="LongTermAsset.ContinuedUsage">ContinuedUsage</see> property set to true.</param>
        ''' <param name="parentChronologyValidator">The operation's parent document 
        ''' IChronologicValidator if any.</param>
        ''' <remarks></remarks>
        Friend Shared Function GetAcquisitionChronologicValidator(ByVal assetID As Integer, _
            ByVal acquisitionDate As Date, ByVal isContinuedUsage As Boolean, _
            ByVal parentChronologyValidator As IChronologicValidator) As AcquisitionChronologicValidator
            Return New AcquisitionChronologicValidator(assetID, acquisitionDate, _
                isContinuedUsage, parentChronologyValidator)
        End Function

        ''' <summary>
        ''' Gets a new AcquisitionChronologicValidator instance for an existing long term asset
        ''' using data of an existing AcquisitionChronologicValidator instance, i.e. reloads
        ''' only acquisition chronologic limitations.
        ''' </summary>
        ''' <param name="currentValidator">an existing AcquisitionChronologicValidator instance
        ''' that needs to reload limitations.</param>
        ''' <remarks></remarks>
        Friend Shared Function GetAcquisitionChronologicValidator( _
            ByVal currentValidator As AcquisitionChronologicValidator) As AcquisitionChronologicValidator
            Return New AcquisitionChronologicValidator(currentValidator.CurrentOperationID, _
                currentValidator.CurrentOperationDate, currentValidator.IsContinuedUsage, _
                Nothing)
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

        Private Sub New(ByVal parentChronologyValidator As IChronologicValidator)
            Create(parentChronologyValidator)
        End Sub

        Private Sub New(ByVal assetID As Integer, ByVal acquisitionDate As Date, _
            ByVal isContinuedUsage As Boolean, ByVal parentChronologyValidator As IChronologicValidator)
            Fetch(assetID, acquisitionDate, isContinuedUsage, parentChronologyValidator)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Create(ByVal parentChronologyValidator As IChronologicValidator)
            IncludeParentChronologyValidator(parentChronologyValidator)
        End Sub

        Private Sub Fetch(ByVal assetID As Integer, ByVal acquisitionDate As Date, _
            ByVal nIsContinuedUsage As Boolean, ByVal parentChronologyValidator As IChronologicValidator)

            Dim myComm As New SQLCommand("FetchLongTermAssetUpdateLimitingFactors")
            myComm.AddParam("?AD", assetID)

            Dim cOpType As LtaOperationType
            Using myData As DataTable = myComm.Fetch

                _CurrentOperationID = assetID
                _CurrentOperationDate = acquisitionDate
                _IsContinuedUsage = nIsContinuedUsage

                For Each dr As DataRow In myData.Rows

                    cOpType = Utilities.ConvertDatabaseCharID(Of LtaOperationType)(CStrSafe(dr.Item(0)))

                    If nIsContinuedUsage AndAlso cOpType = LtaOperationType.Amortization Then

                        _AmortizationIsCalculated = True
                        _FinancialDataCanChange = False
                        _FinancialDataCanChangeExplanation = My.Resources.Assets_AcquisitionChronologicValidator_AmortizationExistsExplanation

                        _MinDateApplicable = True
                        _MaxDateApplicable = True
                        _MinDate = acquisitionDate
                        _MaxDate = acquisitionDate
                        _MinDateExplanation = My.Resources.Assets_AcquisitionChronologicValidator_AmortizationExistsExplanationForDate
                        _MaxDateExplanation = My.Resources.Assets_AcquisitionChronologicValidator_AmortizationExistsExplanationForDate

                        Exit For

                    ElseIf cOpType = LtaOperationType.Amortization Then

                        _AmortizationIsCalculated = True

                    End If

                    If _FinancialDataCanChange AndAlso cOpType <> LtaOperationType.AmortizationPeriod _
                        AndAlso cOpType <> LtaOperationType.UsingEnd _
                        AndAlso cOpType <> LtaOperationType.UsingStart Then

                        _FinancialDataCanChange = False
                        _FinancialDataCanChangeExplanation = String.Format( _
                            My.Resources.Assets_AcquisitionChronologicValidator_FinancialDataCanChangeExplanation, _
                            _MaxDate.ToString("yyyy-MM-dd"), Utilities.ConvertLocalizedName(cOpType))

                    End If

                    If CDateSafe(dr.Item(1), Date.MinValue).Date > _MinDate.Date Then

                        _MaxDateApplicable = True
                        _MaxDate = CDateSafe(dr.Item(1), Date.MinValue).Date
                        _MaxDateExplanation = String.Format( _
                            My.Resources.Assets_AcquisitionChronologicValidator_MaxDateExplanation, _
                            _MaxDate.ToString("yyyy-MM-dd"), Utilities.ConvertLocalizedName(cOpType))

                    End If

                Next

            End Using

            _LimitsExplanation = ""
            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _FinancialDataCanChangeExplanation, False)
            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MinDateExplanation, False)
            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, _MaxDateExplanation, False)

            IncludeParentChronologyValidator(parentChronologyValidator)

        End Sub


        Private Sub IncludeParentChronologyValidator(ByVal parentChronologyValidator As IChronologicValidator)

            If parentChronologyValidator Is Nothing Then Exit Sub

            If Not parentChronologyValidator.FinancialDataCanChange Then
                _ParentFinancialDataCanChange = False
                _ParentFinancialDataCanChangeExplanation = parentChronologyValidator.FinancialDataCanChangeExplanation
            End If

            _LimitsExplanation = AddWithNewLine(_LimitsExplanation, parentChronologyValidator.LimitsExplanation, False)

        End Sub

#End Region

    End Class

End Namespace