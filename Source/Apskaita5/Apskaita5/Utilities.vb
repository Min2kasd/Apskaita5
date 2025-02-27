﻿Imports ApskaitaObjects.Attributes
Imports System.Reflection
Imports Csla.Core

''' <summary>
''' Provides shared common functions.
''' </summary>
''' <remarks></remarks>
Public Module Utilities

    Public Delegate Sub SaveCommonSettingsLocal(ByVal settingsXmlString As String)
    Public Delegate Function GetCommonSettingsLocal() As String

    Friend _SaveCommonSettingsLocal As SaveCommonSettingsLocal = Nothing
    Friend _GetCommonSettingsLocal As GetCommonSettingsLocal = Nothing

    ''' <summary>
    ''' Attaches common settings persistence handlers for a client application that has
    ''' it's own common settings persistence mechanism, e.g. using My.Settings.
    ''' </summary>
    ''' <param name="nSaveCommonSettingsLocal">a handler that saves the xml string containing common settings data</param>
    ''' <param name="nGetCommonSettingsLocal">a handler that retrieves the xml string containing common settings data</param>
    ''' <remarks>In order for common settings to be available in client environment
    ''' a client application must provide methods to read and write settings as 
    ''' an xml string: <see cref="SaveCommonSettingsLocal">SaveCommonSettingsLocal</see> 
    ''' and <see cref="GetCommonSettingsLocal">GetCommonSettingsLocal</see>.
    ''' The methods (delegates) should be set at the client application startup by invoking 
    ''' this method.</remarks>
    Public Sub AttachLocalSettingsMethods(ByVal nSaveCommonSettingsLocal As SaveCommonSettingsLocal, _
        ByVal nGetCommonSettingsLocal As GetCommonSettingsLocal)

        _SaveCommonSettingsLocal = nSaveCommonSettingsLocal
        _GetCommonSettingsLocal = nGetCommonSettingsLocal

    End Sub

    ''' <summary>
    ''' Returns all common information about current company and it's settings.
    ''' </summary>
    Public Function GetCurrentCompany() As ApskaitaObjects.Settings.CompanyInfo
        If Not IsLoggedInDB() Then _
            Throw New Exception("Klaida. Vartotojas neprisijungęs prie jokios įmonės.")
        If Not ApplicationContext.GlobalContext.Contains(KEY_COMPANY_INFO) _
            OrElse Not TypeOf ApplicationContext.GlobalContext.Item(KEY_COMPANY_INFO) _
            Is ApskaitaObjects.Settings.CompanyInfo Then Throw New Exception("Klaida. Nerasti bendri įmonės duomenys.")

        Return DirectCast(ApplicationContext.GlobalContext.Item(KEY_COMPANY_INFO),  _
            ApskaitaObjects.Settings.CompanyInfo)

    End Function

    ''' <summary>
    ''' Returns TRUE if the current user is in the role.
    ''' </summary>
    Public Function UserIsInAdminRole() As Boolean
        Return ApplicationContext.User.IsInRole(AccDataAccessLayer.ProjectConstants.Name_AdminRole)
    End Function


    ''' <summary>
    ''' Helper method to aggregate error messages in a child object collection.
    ''' </summary>
    ''' <param name="list">a list of child objects to aggregate the error messages for</param>
    ''' <remarks>a child should implement <see cref="IGetErrorForListItem">IGetErrorForListItem</see>
    ''' interface in order to use this method</remarks>
    Public Function GetAllBrokenRulesForList(ByVal list As Csla.Core.IExtendedBindingList) As String

        If list Is Nothing OrElse list.Count < 1 Then Return ""

        If Not TypeOf list.Item(0) Is IGetErrorForListItem Then
            Throw New NotImplementedException(String.Format(My.Resources.Common_TypeDoesNotImplementInterface, _
                list.Item(0).GetType.FullName, GetType(IGetErrorForListItem).FullName))
        End If

        Dim result As String = ""

        Dim currentError As String
        For Each item As IGetErrorForListItem In list
            currentError = item.GetErrorString
            result = AddWithNewLine(result, currentError, False)
        Next

        Return result

    End Function

    ''' <summary>
    ''' Helper method to aggregate warning messages in a child object collection.
    ''' </summary>
    ''' <param name="list">a list of child objects to aggregate the warning messages for</param>
    ''' <remarks>a child should implement <see cref="IGetErrorForListItem">IGetErrorForListItem</see>
    ''' interface in order to use this method</remarks>
    Public Function GetAllWarningsForList(ByVal list As Csla.Core.IExtendedBindingList) As String

        If list Is Nothing OrElse list.Count < 1 Then Return ""

        If Not TypeOf list.Item(0) Is IGetErrorForListItem Then
            Throw New NotImplementedException(String.Format(My.Resources.Common_TypeDoesNotImplementInterface, _
                list.Item(0).GetType.FullName, GetType(IGetErrorForListItem).FullName))
        End If

        Dim result As String = ""

        Dim currentWarning As String
        For Each item As IGetErrorForListItem In list
            currentWarning = item.GetWarningString
            result = AddWithNewLine(result, currentWarning, False)
        Next

        Return result

    End Function


    ''' <summary>
    ''' Retuns whether an exception is an SQL exception.
    ''' </summary>
    ''' <param name="e">an exception to evaluate</param>
    ''' <remarks>a proxy method to <see cref="AccDataAccessLayer.Utilities.IsSqlException">AccDataAccessLayer.Utilities.IsSqlException</see></remarks>
    Public Function IsSqlException(ByVal e As Exception) As Boolean
        Return AccDataAccessLayer.Utilities.IsSqlException(e)
    End Function


    ''' <summary>
    ''' Gets a datatable which columns correspond to public properties of the type requested.
    ''' </summary>
    ''' <param name="forType">a type to get the specification for</param>
    ''' <param name="excludedProperties">names of the properties that should be excluded from the specification</param>
    ''' <returns></returns>
    Public Function GetDataTableSpecification(forType As Type, excludedProperties As String()) As DataTable

        Dim result As New DataTable

        For Each prop As PropertyInfo In forType.GetProperties(
                BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.DeclaredOnly)
            If Array.IndexOf(excludedProperties, prop.Name) < 0 Then
                Dim col As New DataColumn(prop.Name, prop.PropertyType)
                col.Caption = GetResourcesPropertyName(forType, prop.Name)
                result.Columns.Add(col)
            End If
        Next

        Return result

    End Function

    ''' <summary>
    ''' Gets a datatable which columns correspond to the properties of the type requested.
    ''' </summary>
    ''' <param name="forType">a type to get the specification for</param>
    ''' <param name="properties">names of the properties that should be included in the specification</param>
    ''' <returns></returns>
    Public Function GetDataTableSpecificationForProperties(forType As Type, ByVal properties As String()) As DataTable

        Dim result As New DataTable

        For Each prop As PropertyInfo In forType.GetProperties(
                BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.DeclaredOnly)
            If Not Array.IndexOf(properties, prop.Name) < 0 Then
                Dim col As New DataColumn(prop.Name, prop.PropertyType)
                col.Caption = GetResourcesPropertyName(forType, prop.Name)
                result.Columns.Add(col)
            End If
        Next

        Return result

    End Function

    ''' <summary>
    ''' Gets a datarow content description as a string. Values are formated as ColumnName=|ColumnValue|.
    ''' </summary>
    ''' <param name="dr">a datarow to get the content description for</param>
    ''' <returns></returns>
    Public Function DataRowToString(dr As DataRow) As String
        If dr Is Nothing Then Throw New ArgumentNullException("dr")
        Dim result As String = String.Empty
        Dim colName As String
        For Each col As DataColumn In dr.Table.Columns
            If String.IsNullOrEmpty(col.Caption.Trim) Then
                colName = col.ColumnName
            Else
                colName = col.Caption
            End If
            If dr.Item(col) Is Nothing Then
                If String.IsNullOrEmpty(result) Then
                    result = String.Format("{0}=null", colName)
                Else
                    result = String.Format("{0};{1}=null", result, colName)
                End If
            Else
                If String.IsNullOrEmpty(result) Then
                    result = String.Format("{0}=|{1}|", colName, dr.Item(col).ToString)
                Else
                    result = String.Format("{0};{1}=|{2}|", result, colName, dr.Item(col).ToString)
                End If
            End If
        Next
        Return result
    End Function


#Region " Enum conversion methods "

    ''' <summary>
    ''' Converts an ENUM value to the localized human readable name.
    ''' </summary>
    ''' <param name="enumValue">An ENUM value to convert.</param>
    ''' <remarks>Convention for the naming of the resource is full type name excluding assembly name
    ''' and an ENUM value name with "." replaced by "_", e.g. General_DefaultAccountType_Till.</remarks>
    Public Function ConvertLocalizedName(ByVal enumValue As [Enum]) As String

        If enumValue Is Nothing Then Throw New ArgumentNullException("enumValue")

        Dim resourceName As String = GetResourceName(enumValue)
        Dim defaultName As String = GetEnumValueName(enumValue)

        Return GetResourceValue(resourceName, defaultName)

    End Function

    ''' <summary>
    ''' Converts a localized human readable name to an ENUM value.
    ''' </summary>
    ''' <typeparam name="T">Type of the ENUM.</typeparam>
    ''' <param name="localizedName">A localized human readable name to convert.</param>
    ''' <remarks>Convention for the naming of the resource is full type name excluding assembly name
    ''' and an ENUM value name with "." replaced by "_", e.g. General_DefaultAccountType_Till.</remarks>
    Public Function ConvertLocalizedName(Of T)(ByVal localizedName As String) As T

        If StringIsNullOrEmpty(localizedName) Then Throw New ArgumentNullException("localizedName")

        If Not GetType(T).IsEnum Then Throw New InvalidOperationException(String.Format( _
            My.Resources.EnumValueAttribute_InvalidType, "ConvertLocalizedName", GetType(T).FullName))

        For Each value As [Enum] In [Enum].GetValues(GetType(T))

            If ConvertLocalizedName(value).Trim.ToLower = localizedName.Trim.ToLower Then
                Return DirectCast(DirectCast(value, Object), T)
            End If

        Next

        Return Nothing

    End Function

    ''' <summary>
    ''' Converts an ENUM value to the database integer value using <see cref="EnumValueAttribute.DatabaseID">DatabaseID</see> property.
    ''' </summary>
    ''' <param name="enumValue">An ENUM value to convert.</param>
    ''' <remarks></remarks>
    Public Function ConvertDatabaseID(ByVal enumValue As [Enum]) As Integer

        If enumValue Is Nothing Then Throw New ArgumentNullException("enumValue")

        Dim enumAttribute As EnumValueAttribute = GetEnumValueAttribute(enumValue)

        If enumAttribute Is Nothing Then
            Throw New NotImplementedException(My.Resources.EnumValueAttribute_AttributeNull)
        End If

        Return enumAttribute.DatabaseID

    End Function

    ''' <summary>
    ''' Converts a database integer value to an ENUM value using <see cref="EnumValueAttribute.DatabaseID">DatabaseID</see> property.
    ''' </summary>
    ''' <typeparam name="T">Type of the ENUM.</typeparam>
    ''' <param name="valueDatabaseID">A database integer value that encodes an ENUM value.</param>
    ''' <remarks></remarks>
    Public Function ConvertDatabaseID(Of T)(ByVal valueDatabaseID As Integer) As T

        If Not GetType(T).IsEnum Then Throw New InvalidOperationException(String.Format( _
            My.Resources.EnumValueAttribute_InvalidType, "ConvertDatabaseID", GetType(T).FullName))

        Dim enumAttribute As EnumValueAttribute

        For Each value As [Enum] In [Enum].GetValues(GetType(T))

            enumAttribute = GetEnumValueAttribute(value)

            If Not enumAttribute Is Nothing AndAlso enumAttribute.DatabaseID = valueDatabaseID Then
                Return DirectCast(DirectCast(value, Object), T)
            End If

        Next

        Return Nothing

    End Function

    ''' <summary>
    ''' Converts an ENUM value to the database string value using <see cref="EnumValueAttribute.DatabaseCharCode">DatabaseCharCode</see> property.
    ''' </summary>
    ''' <param name="enumValue">An ENUM value to convert.</param>
    ''' <remarks>Only used for backwards compartability in some objects. Not to be used for a new objects.</remarks>
    Public Function ConvertDatabaseCharID(ByVal enumValue As [Enum]) As String

        If enumValue Is Nothing Then Throw New ArgumentNullException("enumValue")

        Dim enumAttribute As EnumValueAttribute = GetEnumValueAttribute(enumValue)

        If enumAttribute Is Nothing Then
            Throw New NotImplementedException(My.Resources.EnumValueAttribute_AttributeNull)
        End If

        Return enumAttribute.DatabaseCharCode

    End Function

    ''' <summary>
    ''' Converts a database string value to an ENUM value using <see cref="EnumValueAttribute.DatabaseCharCode">DatabaseCharCode</see> property.
    ''' </summary>
    ''' <typeparam name="T">Type of the ENUM.</typeparam>
    ''' <param name="valueDatabaseCharID">A database string value that encodes an ENUM value.</param>
    ''' <remarks>Only used for backwards compartability in some objects. Not to be used for a new objects.</remarks>
    Public Function ConvertDatabaseCharID(Of T)(ByVal valueDatabaseCharID As String) As T

        If valueDatabaseCharID Is Nothing Then Throw New ArgumentNullException("valueDatabaseCharID")

        If Not GetType(T).IsEnum Then Throw New InvalidOperationException(String.Format( _
            My.Resources.EnumValueAttribute_InvalidType, "ConvertDatabaseCharID", GetType(T).FullName))

        Dim enumAttribute As EnumValueAttribute

        For Each value As [Enum] In [Enum].GetValues(GetType(T))

            enumAttribute = GetEnumValueAttribute(value)

            If Not enumAttribute Is Nothing AndAlso enumAttribute.DatabaseCharCode.Trim.ToLower _
                                                    = valueDatabaseCharID.Trim.ToLower Then
                Return DirectCast(DirectCast(value, Object), T)
            End If

        Next

        Return Nothing

    End Function

    ''' <summary>
    ''' Gets a list of localized human readable names of ENUM values.
    ''' </summary>
    ''' <param name="enumType">Type of the ENUM.</param>
    ''' <remarks>Convention for the naming of the resource is full type name excluding assembly name
    ''' and an ENUM value name with "." replaced by "_", e.g. General_DefaultAccountType_Till.</remarks>
    Public Function GetLocalizedNameList(ByVal enumType As Type) As List(Of String)

        If enumType Is Nothing Then
            Throw New ArgumentNullException("enumType")
        End If

        If Not enumType.IsEnum Then
            Throw New InvalidOperationException(String.Format(My.Resources.EnumValueAttribute_InvalidType, _
                "GetLocalizedNameList", enumType.FullName))
        End If

        Dim result As New List(Of String)

        For Each value As [Enum] In [Enum].GetValues(enumType)
            result.Add(ConvertLocalizedName(value).Trim)
        Next

        Return result

    End Function

    Private Function GetResourceName(ByVal enumValue As [Enum]) As String

        If enumValue Is Nothing Then Return ""

        Return enumValue.GetType.FullName.Substring(enumValue.GetType.FullName.IndexOf(".") + 1) _
                   .Replace(".", "_") & "_" & [Enum].GetName(enumValue.GetType, enumValue)

    End Function

    Private Function GetResourceValue(ByVal resourceName As String, _
                                             ByVal defaultValue As String) As String

        Dim result As String = defaultValue
        Try
            result = My.Resources.ResourceManager.GetString(resourceName)
        Catch ex As Exception
        End Try

        Return result

    End Function

    Private Function GetEnumValueName(ByVal enumValue As [Enum]) As String

        Dim result As String = "undefined"

        Try
            result = [Enum].GetName(enumValue.GetType, enumValue)
        Catch e As Exception
        End Try

        Return result

    End Function

    Private Function GetEnumValueAttribute(ByVal enumValue As [Enum]) As EnumValueAttribute

        Dim fi As System.Reflection.FieldInfo = enumValue.GetType().GetField(enumValue.ToString())

        Dim result As Object() = fi.GetCustomAttributes(GetType(EnumValueAttribute), True)

        If result Is Nothing OrElse result.Length < 1 Then Return Nothing

        Return DirectCast(result(0), EnumValueAttribute)

    End Function

#End Region

End Module
