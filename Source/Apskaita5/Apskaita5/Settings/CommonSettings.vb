﻿Imports ApskaitaObjects.Attributes
Imports Csla.Validation
Imports ApskaitaObjects.Settings.XmlProxies

Namespace Settings

    ''' <summary>
    ''' Represents a common application settings that define background accross 
    ''' all of the databases. Contains tax rates, codes, names, work time gauge amounts etc.
    ''' </summary>
    ''' <remarks>Is persisted either to the <see cref="SETTINGSFILENAME">settings 
    ''' xml file</see> (for server environment) or to the application settings 
    ''' (for client environment). In order to be available in client environment
    ''' a client application must provide methods to read and write settings as 
    ''' an xml string: <see cref="Utilities.GetCommonSettingsLocal">Utilities.GetCommonSettingsLocal</see> 
    ''' and <see cref="Utilities.SaveCommonSettingsLocal">Utilities.SaveCommonSettingsLocal</see>.
    ''' The methods (delegates) should be set at the client application startup by invoking 
    ''' <see cref="Utilities.AttachLocalSettingsMethods">Utilities.AttachLocalSettingsMethods</see>
    ''' method.</remarks>
    <Serializable()> _
    Public NotInheritable Class CommonSettings
        Inherits BusinessBase(Of CommonSettings)
        Implements IIsDirtyEnough, IValidationMessageProvider

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _CodeWageGPM As String = ""
        Private _TaxRates As TaxRateList
        Private _Codes As CodeList
        Private _Names As NameList
        Private _DefaultWorkTimes As DefaultWorkTimeList
        Private _PublicHolidays As PublicHolidayList

        ' used to implement automatic sort in datagridview
        <NotUndoable()> _
        <NonSerialized()> _
        Private _TaxRatesSortedList As Csla.SortedBindingList(Of TaxRate) = Nothing
        <NotUndoable()> _
        <NonSerialized()> _
        Private _CodesSortedList As Csla.SortedBindingList(Of Code) = Nothing
        <NotUndoable()> _
        <NonSerialized()> _
        Private _NamesSortedList As Csla.SortedBindingList(Of Name) = Nothing
        <NotUndoable()> _
        <NonSerialized()> _
        Private _DefaultWorkTimesSortedList As Csla.SortedBindingList(Of DefaultWorkTime) = Nothing
        <NotUndoable()> _
        <NonSerialized()> _
        Private _PublicHolidaysSortedList As Csla.SortedBindingList(Of PublicHoliday) = Nothing


        ''' <summary>
        ''' Gets or sets a code for wage used in personal income tax declaration.
        ''' </summary>
        ''' <remarks></remarks>
        <StringField(ValueRequiredLevel.Recommended, 30)> _
        Public Property CodeWageGPM() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CodeWageGPM
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If value Is Nothing Then value = ""
                If _CodeWageGPM <> value.Trim Then
                    _CodeWageGPM = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a list of possible tax rates for different taxes.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property TaxRates() As TaxRateList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _TaxRates
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable view of possible tax rates for different taxes.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a datagridview.</remarks>
        Public ReadOnly Property TaxRatesSorted() As Csla.SortedBindingList(Of TaxRate)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _TaxRatesSortedList Is Nothing Then
                    _TaxRatesSortedList = New Csla.SortedBindingList(Of TaxRate)(_TaxRates)
                End If
                Return _TaxRatesSortedList
            End Get
        End Property

        ''' <summary>
        ''' Gets a list of possible codes (income type, municipalities, etc.) 
        ''' for use in business objects.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Codes() As CodeList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Codes
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable view of possible codes (income type, municipalities, etc.) 
        ''' for use in business objects.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a datagridview.</remarks>
        Public ReadOnly Property CodesSorted() As Csla.SortedBindingList(Of Code)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _CodesSortedList Is Nothing Then
                    _CodesSortedList = New Csla.SortedBindingList(Of Code)(_Codes)
                End If
                Return _CodesSortedList
            End Get
        End Property

        ''' <summary>
        ''' Gets a list of possible names (single string values, e.g. long term asset
        ''' legal groups, institutions, etc.) for use in business objects.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property Names() As NameList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Names
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable view of possible names (single string values, e.g. long term asset
        ''' legal groups, institutions, etc.) for use in business objects.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a datagridview.</remarks>
        Public ReadOnly Property NamesSorted() As Csla.SortedBindingList(Of Name)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _NamesSortedList Is Nothing Then
                    _NamesSortedList = New Csla.SortedBindingList(Of Name)(_Names)
                End If
                Return _NamesSortedList
            End Get
        End Property

        ''' <summary>
        ''' Gets a list of work time gauge amounts for different months.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DefaultWorkTimes() As DefaultWorkTimeList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultWorkTimes
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable view of work time gauge amounts for different months.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a datagridview.</remarks>
        Public ReadOnly Property DefaultWorkTimesSorted() As Csla.SortedBindingList(Of DefaultWorkTime)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _DefaultWorkTimesSortedList Is Nothing Then
                    _DefaultWorkTimesSortedList = New Csla.SortedBindingList(Of DefaultWorkTime)(_DefaultWorkTimes)
                End If
                Return _DefaultWorkTimesSortedList
            End Get
        End Property

        ''' <summary>
        ''' Gets a list of public holiday dates.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property PublicHolidays() As PublicHolidayList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _PublicHolidays
            End Get
        End Property

        ''' <summary>
        ''' Gets a sortable view of public holiday dates.
        ''' </summary>
        ''' <remarks>Used to implement auto sort in a datagridview.</remarks>
        Public ReadOnly Property PublicHolidaysSorted() As Csla.SortedBindingList(Of PublicHoliday)
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                If _PublicHolidaysSortedList Is Nothing Then
                    _PublicHolidaysSortedList = New Csla.SortedBindingList(Of PublicHoliday)(_PublicHolidays)
                End If
                Return _PublicHolidaysSortedList
            End Get
        End Property


        Public ReadOnly Property IsDirtyEnough() As Boolean Implements IIsDirtyEnough.IsDirtyEnough
            Get
                Return IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _TaxRates.IsDirty OrElse _
                    _DefaultWorkTimes.IsDirty OrElse _Codes.IsDirty OrElse _
                    _Names.IsDirty OrElse _PublicHolidays.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean _
            Implements IValidationMessageProvider.IsValid
            Get
                Return MyBase.IsValid AndAlso _TaxRates.IsValid AndAlso _
                    _DefaultWorkTimes.IsValid AndAlso _Codes.IsValid AndAlso _
                    _Names.IsValid AndAlso _PublicHolidays.IsValid
            End Get
        End Property



        Public Function GetAllBrokenRules() As String _
            Implements IValidationMessageProvider.GetAllBrokenRules
            Dim result As String = ""
            If Not MyBase.IsValid Then result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            If Not _TaxRates.IsValid Then
                result = AddWithNewLine(result, _TaxRates.GetAllBrokenRules, False)
            End If
            If Not _Codes.IsValid Then
                result = AddWithNewLine(result, _Codes.GetAllBrokenRules, False)
            End If
            If Not _Names.IsValid Then
                result = AddWithNewLine(result, _Names.GetAllBrokenRules, False)
            End If
            If Not _DefaultWorkTimes.IsValid Then
                result = AddWithNewLine(result, _DefaultWorkTimes.GetAllBrokenRules, False)
            End If
            If Not _PublicHolidays.IsValid Then
                result = AddWithNewLine(result, _PublicHolidays.GetAllBrokenRules, False)
            End If
            Return result
        End Function

        Public Function GetAllWarnings() As String _
            Implements IValidationMessageProvider.GetAllWarnings
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then _
                result = Me.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            If _TaxRates.HasWarnings() Then
                result = AddWithNewLine(result, _TaxRates.GetAllWarnings(), False)
            End If
            If _Codes.HasWarnings() Then
                result = AddWithNewLine(result, _Codes.GetAllWarnings(), False)
            End If
            If _Names.HasWarnings() Then
                result = AddWithNewLine(result, _Names.GetAllWarnings(), False)
            End If
            If _DefaultWorkTimes.HasWarnings() Then
                result = AddWithNewLine(result, _DefaultWorkTimes.GetAllWarnings(), False)
            End If
            If _PublicHolidays.HasWarnings() Then
                result = AddWithNewLine(result, _PublicHolidays.GetAllWarnings(), False)
            End If
            Return result
        End Function

        Public Function HasWarnings() As Boolean _
            Implements IValidationMessageProvider.HasWarnings
            Return MyBase.BrokenRulesCollection.WarningCount > 0 OrElse _
                _TaxRates.HasWarnings() OrElse _DefaultWorkTimes.HasWarnings() OrElse _
                _Codes.HasWarnings() OrElse _Names.HasWarnings() OrElse _PublicHolidays.HasWarnings()
        End Function


        Public Overrides Function Save() As CommonSettings

            If Not Me.IsValid Then
                Throw New Exception(String.Format(My.Resources.Common_ContainsErrors, vbCrLf, _
                    GetAllBrokenRules()))
            End If

            Dim result As CommonSettings = MyBase.Save
            HelperLists.CodeInfoList.InvalidateCache()
            HelperLists.DefaultWorkTimeInfoList.InvalidateCache()
            HelperLists.NameInfoList.InvalidateCache()
            HelperLists.TaxRateInfoList.InvalidateCache()
            Return result

        End Function


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return My.Resources.Settings_CommonSettings_ToString
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New RuleArgs("CodeWageGPM"))
        End Sub

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return True
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return ApplicationContext.User.IsInRole("General.CommonSettings3")
        End Function

#End Region

#Region " Factory Methods "

        ''' <summary>
        ''' Gets a common settings from server or local storage.
        ''' </summary>
        ''' <remarks>In order to be available in client environment a client application must provide 
        ''' methods to read and write settings as an xml string: 
        ''' <see cref="Utilities.GetCommonSettingsLocal">Utilities.GetCommonSettingsLocal</see> 
        ''' and <see cref="Utilities.SaveCommonSettingsLocal">Utilities.SaveCommonSettingsLocal</see>.
        ''' The methods (delegates) should be set at the client application startup by invoking 
        ''' <see cref="Utilities.AttachLocalSettingsMethods">Utilities.AttachLocalSettingsMethods</see>
        ''' method.</remarks>
        Public Shared Function GetCommonSettings() As CommonSettings
            Return DataPortal.Fetch(Of CommonSettings)(New Criteria())
        End Function


        Private Sub New()
            ' require use of factory methods
        End Sub

#End Region

#Region " Data Access "

        <Serializable()> _
        Private Class Criteria
            Public Sub New()
            End Sub
        End Class


        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            If Not CanGetObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecuritySelectDenied)

            DoFetch()

        End Sub

        Private Sub DoFetch()

            Dim proxy As CommonSettingsProxy = GetCurrentProxy()

            _CodeWageGPM = proxy.CodeWageGPM

            _Codes = CodeList.GetCodeList(proxy.Codes)
            _TaxRates = TaxRateList.GetTaxRateList(proxy.TaxRates)
            _DefaultWorkTimes = DefaultWorkTimeList.GetDefaultWorkTimeList(proxy.DefaultWorkTimes)
            _Names = NameList.GetNameList(proxy.Names)
            _PublicHolidays = PublicHolidayList.GetPublicHolidayList(proxy.PublicHolidays)

            MarkOld()

        End Sub

        Friend Shared Function GetCurrentProxy() As CommonSettingsProxy
            Dim xmlString As String = GetXmlString()
            Return FromXmlString(Of CommonSettingsProxy)(xmlString)
        End Function

        Private Shared Function GetDefaultPath() As String
            Return IO.Path.Combine(AccDataAccessLayer.Utilities.AppPath, SETTINGSFILENAME)
        End Function

        Private Shared Function GetXmlString() As String

            Dim result As String = ""

            If GetCurrentIdentity.ConnectionType <> AccDataAccessLayer.ConnectionType.Local _
                OrElse AccDataAccessLayer.Security.IsWebServer(GetCurrentIdentity.IsWebServerImpersonation) Then

                result = GetXmlStringFromDefaultFile()
                ValidateXmlString(result, True)

            ElseIf Utilities._GetCommonSettingsLocal Is Nothing Then

                Throw New Exception(My.Resources.Settings_CommonSettings_LocalAccessMethodNull)

            ElseIf StringIsNullOrEmpty(Utilities._GetCommonSettingsLocal.Invoke) Then

                ' initialize with default values
                InitializeDefaultSettings()
                result = Utilities._GetCommonSettingsLocal.Invoke

            Else

                result = Utilities._GetCommonSettingsLocal.Invoke

                ' if local settings invalid try to recover from initial file
                If Not ValidateXmlString(result, False) Then
                    InitializeDefaultSettings()
                    result = Utilities._GetCommonSettingsLocal.Invoke
                End If

            End If

            Return result

        End Function

        Private Shared Function GetXmlStringFromDefaultFile() As String

            Try

                Return IO.File.ReadAllText(GetDefaultPath(), System.Text.Encoding.Unicode)

            Catch ex As Exception

                Throw New Exception(String.Format( _
                    My.Resources.Settings_CommonSettings_FailedToReadSettingsFile, _
                    GetDefaultPath(), ex.Message), ex)

            End Try

        End Function

        Private Shared Function ValidateXmlString(ByVal xmlString As String, _
            ByVal throwOnInvalid As Boolean) As Boolean

            Dim proxy As CommonSettingsProxy = Nothing

            Try
                proxy = FromXmlString(Of CommonSettingsProxy)(xmlString)
            Catch ex As Exception
                If throwOnInvalid Then
                    Throw New Exception(String.Format(My.Resources.Settings_CommonSettings_FailedToDeserializeSettingsFile, _
                        ex.Message, GetDefaultPath()), ex)
                End If
                Return False
            End Try

            If proxy Is Nothing Then
                If throwOnInvalid Then
                    Throw New Exception(String.Format(My.Resources.Settings_CommonSettings_FailedToDeserializeSettingsFileUnknownReason, _
                        GetDefaultPath()))
                End If
                Return False
            End If

            Return True

        End Function

        Private Shared Sub InitializeDefaultSettings()

            If Utilities._SaveCommonSettingsLocal Is Nothing Then
                Throw New Exception(My.Resources.Settings_CommonSettings_LocalModifyMethodNull)
            End If

            Dim result As String = GetXmlStringFromDefaultFile()

            ValidateXmlString(result, True)

            Utilities._SaveCommonSettingsLocal.Invoke(result)

        End Sub


        Protected Overrides Sub DataPortal_Update()

            If Not CanEditObject() Then Throw New System.Security.SecurityException( _
                My.Resources.Common_SecurityUpdateDenied)

            If GetCurrentIdentity.ConnectionType <> AccDataAccessLayer.ConnectionType.Local _
                OrElse AccDataAccessLayer.Security.IsWebServer(GetCurrentIdentity.IsWebServerImpersonation) Then

                Try

                    IO.File.WriteAllText(GetDefaultPath(), ToXmlString(Of CommonSettingsProxy) _
                        (GetProxy(True)), System.Text.Encoding.Unicode)

                Catch ex As Exception

                    Throw New Exception(String.Format( _
                        My.Resources.Settings_CommonSettings_FailedToWriteSettingsFile, _
                        GetDefaultPath(), ex.Message), ex)

                End Try

            Else

                If Utilities._SaveCommonSettingsLocal Is Nothing Then
                    Throw New Exception(My.Resources.Settings_CommonSettings_LocalModifyMethodNull)
                End If

                Utilities._SaveCommonSettingsLocal(ToXmlString(Of CommonSettingsProxy)(GetProxy(True)))

            End If

        End Sub

        Private Function GetProxy(ByVal markItemOld As Boolean) As CommonSettingsProxy

            Dim result As New CommonSettingsProxy

            result.CodeWageGPM = _CodeWageGPM
            result.Codes = _Codes.GetProxyList(markItemOld)
            result.DefaultWorkTimes = _DefaultWorkTimes.GetProxyList(markItemOld)
            result.Names = _Names.GetProxyList(markItemOld)
            result.PublicHolidays = _PublicHolidays.GetProxyList(markItemOld)
            result.TaxRates = _TaxRates.GetProxyList(markItemOld)

            If markItemOld Then MarkOld()

            Return result

        End Function


        ''' <summary>
        ''' For developing use.
        ''' </summary>
        ''' <param name="filePath"></param>
        Public Sub SaveToFile(filePath As String)

            IO.File.WriteAllText(filePath, ToXmlString(Of CommonSettingsProxy) _
                (GetProxy(False)), System.Text.Encoding.Unicode)
            Dim xmlString As String = IO.File.ReadAllText(GetDefaultPath(), System.Text.Encoding.Unicode)
            ValidateXmlString(xmlString, True)

        End Sub

#End Region

    End Class

End Namespace