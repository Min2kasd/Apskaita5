﻿Imports ApskaitaObjects.Attributes
Imports Csla.Validation
Imports System.Reflection
Imports ApskaitaObjects.My.Resources

Namespace CommonValidation

    Public Module CommonValidation

#Region " BusinessAttributeValidation "

        ''' <summary>
        ''' Rule ensuring a property value matches requirements set by 
        ''' <see cref="Attributes.IValidationRuleProvider">IValidationRuleProvider</see> 
        ''' and <see cref="Attributes.BusinessFieldAttribute">BusinessFieldAttribute</see>
        ''' of the property.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function BusinessAttributeValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim attrib As IValidationRuleProvider = Nothing
            For Each a As Attribute In target.GetType.GetProperty( _
                e.PropertyName).GetCustomAttributes(True)
                If GetType(IValidationRuleProvider).IsAssignableFrom(a.GetType) Then
                    attrib = CType(a, IValidationRuleProvider)
                    Exit For
                End If
            Next

            If attrib Is Nothing OrElse attrib.GetValidationRule Is Nothing Then
                Return True
            End If

            Return attrib.GetValidationRule.Invoke(target, e)

        End Function

#End Region

#Region " StringFieldValidation "

        ''' <summary>
        ''' Rule ensuring a <see cref="String">String</see> field value matches requirements 
        ''' set by <see cref="StringFieldAttribute">StringFieldAttribute</see> of the property.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function StringFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim attrib As StringFieldAttribute = GetAttribute(Of StringFieldAttribute)(target.GetType, e.PropertyName)

            If attrib Is Nothing Then Return True

            Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)
            Dim value As String = CallByName(target, e.PropertyName, CallType.Get).ToString

            If attrib.ValueRequired <> ValueRequiredLevel.Optional AndAlso StringIsNullOrEmpty(value) Then

                e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
                If attrib.ValueRequired = ValueRequiredLevel.Mandatory Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If
                Return False

            End If

            If Not StringIsNullOrEmpty(value) AndAlso value.Trim.Length > attrib.MaxLength Then
                e.Description = String.Format(My.Resources.Common_StringExceedsMaxLength, _
                    propName, attrib.MaxLength.ToString)
                If attrib.ErrorIfExceedsMaxLength Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If
                Return False
            End If

            Return True

        End Function

#End Region

#Region " IntegerFieldValidation "

        ''' <summary>
        ''' Rule ensuring a <see cref="Integer">Integer</see> field value matches requirements 
        ''' set by <see cref="IntegerFieldAttribute">IntegerFieldAttribute</see> of the property.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function IntegerFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim attrib As IntegerFieldAttribute = GetAttribute(Of IntegerFieldAttribute)(target.GetType, e.PropertyName)

            If attrib Is Nothing Then Return True

            Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

            Dim value As Integer = DirectCast(CallByName(target, e.PropertyName, CallType.Get), Integer)

            If attrib.ValueRequired <> ValueRequiredLevel.Optional AndAlso value = 0 Then

                e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
                If attrib.ValueRequired = ValueRequiredLevel.Mandatory Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If
                Return False

            End If

            If Not attrib.AllowNegative AndAlso value < 0 Then

                e.Description = String.Format(My.Resources.Common_IntegerCannotBeNegative, propName)
                e.Severity = RuleSeverity.Error
                Return False

            End If

            If attrib.WithinRange AndAlso (value < attrib.MinValue OrElse value > attrib.MaxValue) Then

                If value < attrib.MinValue Then
                    e.Description = String.Format(My.Resources.Common_IntegerExceedsMinLimit, _
                                                  propName, attrib.MinValue.ToString)

                ElseIf value > attrib.MaxValue Then
                    e.Description = String.Format(My.Resources.Common_IntegerExceedsMaxLimit, _
                                                  propName, attrib.MaxValue.ToString)

                End If

                If attrib.ErrorIfExceedsRange Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If

                Return False

            End If

            Return True

        End Function

#End Region

#Region " DoubleFieldValidation "

        ''' <summary>
        ''' Rule ensuring a <see cref="Double">Double</see> field value matches requirements 
        ''' set by <see cref="DoubleFieldAttribute">DoubleFieldAttribute</see> of the property.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function DoubleFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim attrib As DoubleFieldAttribute = GetAttribute(Of DoubleFieldAttribute)(target.GetType, e.PropertyName)

            If attrib Is Nothing Then Return True

            Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

            Dim value As Double = DirectCast(CallByName(target, e.PropertyName, CallType.Get), Double)

            If attrib.ValueRequired <> ValueRequiredLevel.Optional AndAlso CRound(value, attrib.Round) = 0 Then

                e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
                If attrib.ValueRequired = ValueRequiredLevel.Mandatory Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If
                Return False

            End If

            If Not attrib.AllowNegative AndAlso CRound(value, attrib.Round) < 0 Then

                e.Description = String.Format(My.Resources.Common_IntegerCannotBeNegative, propName)
                e.Severity = RuleSeverity.Error
                Return False

            End If

            If attrib.WithinRange AndAlso (CRound(value, attrib.Round) < attrib.MinValue _
                                           OrElse CRound(value, attrib.Round) > attrib.MaxValue) Then

                If CRound(value, attrib.Round) < attrib.MinValue Then
                    e.Description = String.Format(My.Resources.Common_IntegerExceedsMinLimit, _
                                                  propName, attrib.MinValue.ToString)

                ElseIf CRound(value, attrib.Round) > attrib.MaxValue Then
                    e.Description = String.Format(My.Resources.Common_IntegerExceedsMaxLimit, _
                                                  propName, attrib.MaxValue.ToString)

                End If

                If attrib.ErrorIfExceedsRange Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If

                Return False

            End If

            Return True

        End Function

#End Region

#Region " AccountFieldValidation "

        ''' <summary>
        ''' Rule ensuring a <see cref="General.Account.ID">Account ID</see> field value matches requirements 
        ''' set by <see cref="AccountFieldAttribute">AccountFieldAttribute</see> of the property.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function AccountFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim attrib As AccountFieldAttribute = GetAttribute(Of AccountFieldAttribute)(target.GetType, e.PropertyName)

            If attrib Is Nothing Then Return True

            Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

            Dim value As Long = DirectCast(CallByName(target, e.PropertyName, CallType.Get), Long)

            If value < 0 Then

                e.Description = String.Format(My.Resources.Common_AccountCannotBeNegative, propName)
                e.Severity = RuleSeverity.Error
                Return False

            End If

            If attrib.ValueRequired <> ValueRequiredLevel.Optional AndAlso Not value > 0 Then

                e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
                If attrib.ValueRequired = ValueRequiredLevel.Mandatory Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If
                Return False

            End If

            Dim accountPrefix As Integer = Convert.ToInt32(General.Account.GetAccountClass(value))

            If value > 0 AndAlso Array.IndexOf(attrib.AcceptedClasses, accountPrefix) < 0 Then

                e.Description = String.Format(My.Resources.Common_AccountClassInvalid, _
                                              accountPrefix.ToString, attrib.GetAcceptedClassesString, propName)

                If attrib.ErrorOnClassMismatch Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If

                Return False

            End If

            Return True

        End Function

#End Region

#Region " ValueObjectFieldValidation "

        ''' <summary>
        ''' Rule ensuring that a <see cref="HelperLists">value object</see> field value is not null or empty.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate (ExtendedRuleArgs)</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function ValueObjectFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim attrib As ValueObjectFieldAttribute = GetAttribute(Of ValueObjectFieldAttribute)(target.GetType, e.PropertyName)

            If attrib Is Nothing OrElse attrib.ValueRequired = ValueRequiredLevel.Optional Then Return True

            Dim value As IValueObject = DirectCast(CallByName(target, e.PropertyName, CallType.Get), IValueObject)

            If value Is Nothing OrElse value.IsEmpty Then

                Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

                e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
                If attrib.ValueRequired = ValueRequiredLevel.Mandatory Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If
                Return False

            End If

            Return True

        End Function

#End Region

#Region " PersonFieldValidation "

        ''' <summary>
        ''' Rule ensuring a <see cref="HelperLists.PersonInfo">PersonInfo</see> field value matches requirements 
        ''' set by <see cref="PersonFieldAttribute">PersonFieldAttribute</see> of the property.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function PersonFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim attrib As PersonFieldAttribute = GetAttribute(Of PersonFieldAttribute)(target.GetType, e.PropertyName)

            If attrib Is Nothing Then Return True

            Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

            Dim value As PersonInfo = DirectCast(CallByName(target, e.PropertyName, CallType.Get), PersonInfo)

            If attrib.ValueRequired <> ValueRequiredLevel.Optional AndAlso value = PersonInfo.Empty() Then

                e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
                If attrib.ValueRequired = ValueRequiredLevel.Mandatory Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If
                Return False

            End If

            If attrib.AllowAll OrElse value = PersonInfo.Empty() Then Return True

            Dim allowedGroup As Boolean = (attrib.AllowBuyers AndAlso value.IsClient) OrElse _
                (attrib.AllowSuppliers AndAlso value.IsSupplier) OrElse (attrib.AllowWorkers AndAlso value.IsWorker)

            If Not allowedGroup Then

                Dim allowedGroups As New List(Of String)
                If attrib.AllowBuyers Then allowedGroups.Add(Common_PersonBaseGroupNameBuyers)
                If attrib.AllowSuppliers Then allowedGroups.Add(Common_PersonBaseGroupNameSuppliers)
                If attrib.AllowWorkers Then allowedGroups.Add(Common_PersonBaseGroupNameWorkers)

                e.Description = String.Format(Common_PersonBaseGroupInvalid, _
                    String.Join(", ", allowedGroups.ToArray()))

                If attrib.ErrorOnTypeMismatch Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If

                Return False

            End If

            Return True

        End Function

#End Region

#Region " CashAccountFieldValidation "

        ''' <summary>
        ''' Rule ensuring a <see cref="HelperLists.CashAccountInfo">CashAccountInfo</see> field value 
        ''' matches requirements set by <see cref="CashAccountFieldAttribute">CashAccountFieldAttribute</see>
        ''' of the property.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function CashAccountFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim attrib As CashAccountFieldAttribute = GetAttribute(Of CashAccountFieldAttribute)(target.GetType, e.PropertyName)

            If attrib Is Nothing Then Return True

            Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

            Dim value As CashAccountInfo = DirectCast(CallByName(target, e.PropertyName, CallType.Get), CashAccountInfo)

            If attrib.ValueRequired <> ValueRequiredLevel.Optional AndAlso value = CashAccountInfo.Empty() Then

                e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
                If attrib.ValueRequired = ValueRequiredLevel.Mandatory Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If
                Return False

            End If

            If value <> CashAccountInfo.Empty() AndAlso Not attrib.AcceptedTypes Is Nothing AndAlso _
                attrib.AcceptedTypes.Length > 0 AndAlso Array.IndexOf(attrib.AcceptedTypes, value.Type) < 0 Then

                Dim allowedTypes As New List(Of String)
                For Each allowedType As Documents.CashAccountType In attrib.AcceptedTypes
                    allowedTypes.Add(ConvertLocalizedName(allowedType))
                Next

                e.Description = String.Format(Common_CashAccountTypeInvalid, _
                    String.Join(", ", allowedTypes.ToArray()))

                If attrib.ErrorOnTypeMismatch Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If

                Return False

            End If

            Return True

        End Function

#End Region

#Region " VatDeclarationSchemaFieldValidation "

        ''' <summary>
        ''' Rule ensuring that a <see cref="HelperLists.VatDeclarationSchemaInfo">
        ''' VAT declaration schema</see> field value is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate (ExtendedRuleArgs)</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function VatDeclarationSchemaFieldValidation(ByVal target As Object, _
            ByVal e As VatDeclarationSchemaFieldRuleArgs) As Boolean

            If Not GetCurrentIdentity.IsAuthenticatedWithDB OrElse StringIsNullOrEmpty(GetCurrentCompany.CodeVat) OrElse _
                Not GetCurrentCompany.UseVatDeclarationSchemas Then Return True

            Dim attrib As VatDeclarationSchemaFieldAttribute = _
                GetAttribute(Of VatDeclarationSchemaFieldAttribute) _
                (target.GetType, e.PropertyName)

            If attrib Is Nothing OrElse attrib.ValueRequired = ValueRequiredLevel.Optional Then Return True

            Dim value As VatDeclarationSchemaInfo = DirectCast(CallByName(target, _
                e.PropertyName, CallType.Get), VatDeclarationSchemaInfo)

            Dim rateValue As Double = -1
            If Not StringIsNullOrEmpty(e.VatRatePropertyName) Then
                rateValue = DirectCast(CallByName(target, e.VatRatePropertyName, _
                    CallType.Get), Double)
            End If

            If value = VatDeclarationSchemaInfo.Empty Then

                Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

                e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
                If attrib.ValueRequired = ValueRequiredLevel.Mandatory Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If
                Return False

            ElseIf rateValue >= 0 AndAlso value.VatRate <> CRound(rateValue) Then

                e.Description = String.Format(Common_VatRateMismatch, _
                    DblParser(value.VatRate), DblParser(rateValue))
                e.Severity = RuleSeverity.Warning
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Custom object required by the rule method.
        ''' </summary>
        Public Class VatDeclarationSchemaFieldRuleArgs
            Inherits RuleArgs

            Private _VatRatePropertyName As String = ""
            ''' <summary>
            ''' Get the property name that is holding object date.
            ''' </summary>
            Public ReadOnly Property VatRatePropertyName() As String
                Get
                    Return _VatRatePropertyName
                End Get
            End Property


            ''' <summary>
            ''' Create a new object.
            ''' </summary>
            ''' <param name="nPropertyName">the name of the property 
            ''' that is holding VAT declaration schema</param>
            ''' <param name="nVatRatePropertyName">the name of the property 
            ''' that is holding VAT rate (if any)</param>
            Public Sub New(ByVal nPropertyName As String, ByVal nVatRatePropertyName As String)

                MyBase.New(nPropertyName)
                _VatRatePropertyName = nVatRatePropertyName

            End Sub

            ''' <summary>
            ''' Returns a string representation of the object.
            ''' </summary>
            Public Overrides Function ToString() As String
                Return MyBase.ToString & "?VatRatePropertyName=" & _VatRatePropertyName
            End Function

        End Class

#End Region

#Region " CodeFieldValidation "

        ''' <summary>
        ''' Rule ensuring a <see cref="HelperLists.CodeInfo">code (string or integer)</see> field value 
        ''' matches requirements set by <see cref="CodeFieldAttribute">CodeFieldAttribute</see>
        ''' of the property.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function CodeFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim attrib As CodeFieldAttribute = GetAttribute(Of CodeFieldAttribute)(target.GetType, e.PropertyName)

            If attrib Is Nothing Then Return True

            Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

            Dim valueNull As Boolean

            If target.GetType.GetProperty(e.PropertyName).PropertyType Is GetType(Integer) Then

                Dim value As Integer = DirectCast(CallByName(target, e.PropertyName, CallType.Get), Integer)
                valueNull = value < 1

            Else

                Dim value As String = DirectCast(CallByName(target, e.PropertyName, CallType.Get), String)
                valueNull = StringIsNullOrEmpty(value)

            End If

            If attrib.ValueRequired <> ValueRequiredLevel.Optional AndAlso valueNull Then

                e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
                If attrib.ValueRequired = ValueRequiredLevel.Mandatory Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If
                Return False

            End If

            Return True

        End Function

#End Region

#Region " CodeFieldValidation "

        ''' <summary>
        ''' Rule ensuring a <see cref="HelperLists.CodeInfo">code and name</see> field value 
        ''' matches requirements set by <see cref="CodeFieldAttribute">CodeFieldAttribute</see>
        ''' of the property.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")>
        Public Function CodeAndNameFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim attrib As CodeAndNameFieldAttribute = GetAttribute(Of CodeAndNameFieldAttribute)(target.GetType, e.PropertyName)

            If attrib Is Nothing Then Return True

            Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

            Dim valueNull As Boolean

            Dim value As CodeInfo = DirectCast(CallByName(target, e.PropertyName, CallType.Get), CodeInfo)
            valueNull = (value = CodeInfo.Empty OrElse String.IsNullOrEmpty(value.Name.Trim) _
                OrElse (Array.IndexOf(CodeInfo.IntegerCodeTypes, value.Type) < 0 AndAlso
                String.IsNullOrEmpty(value.Code.Trim)) OrElse
                (Array.IndexOf(CodeInfo.IntegerCodeTypes, value.Type) >= 0 AndAlso value.CodeInt < 1))

            If value <> CodeInfo.Empty AndAlso attrib.Type <> value.Type Then

                e.Description = String.Format(My.Resources.Common_CodeTypeMismatch, propName,
                    attrib.Type, value.Type)
                e.Severity = RuleSeverity.Error
                Return False

            ElseIf attrib.ValueRequired <> ValueRequiredLevel.Optional AndAlso valueNull Then

                e.Description = String.Format(My.Resources.Common_FieldValueNull, propName)
                If attrib.ValueRequired = ValueRequiredLevel.Mandatory Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If
                Return False

            End If

            Return True

        End Function

#End Region

#Region " LanguageCodeFieldValidation "

        ''' <summary>
        ''' Rule ensuring a valid language code is entered (accepts ExtendedRuleArgs).
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate (ExtendedRuleArgs OR RuleArgs)</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function LanguageCodeValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim attr As LanguageCodeFieldAttribute = GetAttribute(Of LanguageCodeFieldAttribute)(target.GetType, e.PropertyName)

            If attr Is Nothing Then Return True

            Dim value As String = Convert.ToString(CallByName(target, e.PropertyName, CallType.Get))

            If StringIsNullOrEmpty(value) AndAlso attr.ValueRequired <> ValueRequiredLevel.Optional Then
                e.Description = My.Resources.Common_LanguageCodeNull
                If attr.ValueRequired = ValueRequiredLevel.Mandatory Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If
                Return False
            End If

            If Not IsLanguageCodeValid(value) Then
                e.Description = String.Format(My.Resources.Common_LanguageCodeInvalid, value.Trim)
                e.Severity = RuleSeverity.Error
                Return False
            Else

            End If

            Return True

        End Function

#End Region

#Region " LanguageNameFieldValidation "

        ''' <summary>
        ''' Rule ensuring a valid language name is entered (accepts ExtendedRuleArgs).
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate (ExtendedRuleArgs OR RuleArgs)</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function LanguageNameValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim attr As LanguageNameFieldAttribute = GetAttribute(Of LanguageNameFieldAttribute)(target.GetType, e.PropertyName)

            If attr Is Nothing Then Return True

            Dim value As String = Convert.ToString(CallByName(target, e.PropertyName, CallType.Get))

            If StringIsNullOrEmpty(value) AndAlso attr.ValueRequired <> ValueRequiredLevel.Optional Then
                e.Description = My.Resources.Common_LanguageNameNull
                If attr.ValueRequired = ValueRequiredLevel.Mandatory Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If
                Return False
            End If

            Try
                If Not StringIsNullOrEmpty(value) Then GetLanguageCode(value, True)
            Catch ex As Exception
                e.Description = String.Format(My.Resources.Common_LanguageNameInvalid, value.Trim)
                e.Severity = RuleSeverity.Error
                Return False
            End Try

            Return True

        End Function

#End Region

#Region " CurrencyFieldValidation "

        ''' <summary>
        ''' Rule ensuring a valid currency code is entered (accepts ExtendedRuleArgs).
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate (RuleArgs OR ExtendedRuleArgs)</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function CurrencyFieldValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim attr As CurrencyFieldAttribute = GetAttribute(Of CurrencyFieldAttribute)(target.GetType, e.PropertyName)

            If attr Is Nothing Then Return True

            Dim value As String = Convert.ToString(CallByName(target, e.PropertyName, CallType.Get))

            If StringIsNullOrEmpty(value) AndAlso attr.ValueRequired <> ValueRequiredLevel.Optional Then
                e.Description = My.Resources.Common_CurrencyCodeNull
                If attr.ValueRequired = ValueRequiredLevel.Mandatory Then
                    e.Severity = RuleSeverity.Error
                Else
                    e.Severity = RuleSeverity.Warning
                End If
                Return False
            End If

            If Not StringIsNullOrEmpty(value) AndAlso Array.IndexOf(CurrencyCodes, value.Trim.ToUpper) < 0 Then
                e.Description = String.Format(My.Resources.Common_CurrencyCodeInvalid, value.Trim)
                e.Severity = RuleSeverity.Error
                Return False
            Else

            End If

            Return True

        End Function

#End Region

#Region " ChronologyValidation "

        ''' <summary>
        ''' Rule ensuring that the chronology requirements are kept (requires ChronologyRuleArgs).
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate (ChronologyRuleArgs)</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function ChronologyValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim objectDate As Date = DirectCast((CallByName(target, DirectCast(e, ChronologyRuleArgs). _
                DatePropertyName, CallType.Get)), Date)

            Dim validationObject As IChronologicValidator = _
                DirectCast((CallByName(target, DirectCast(e, ChronologyRuleArgs). _
                    ValidatorPropertyName, CallType.Get)), IChronologicValidator)

            If Not validationObject Is Nothing AndAlso Not validationObject. _
                ValidateOperationDate(objectDate, e.Description, e.Severity) Then
                Return False
            End If

            If objectDate.Date > Today.Date Then

                e.Description = ValidationRules_FutureDate
                e.Severity = RuleSeverity.Warning
                Return False

            ElseIf objectDate.Date < Today.AddYears(-5) Then

                e.Description = ValidationRules_DeepPastDate
                e.Severity = RuleSeverity.Warning
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Custom object required by the rule method.
        ''' </summary>
        Public Class ChronologyRuleArgs
            Inherits RuleArgs

            Private _DatePropertyName As String = ""
            ''' <summary>
            ''' Get the property name that is holding object date.
            ''' </summary>
            Public ReadOnly Property DatePropertyName() As String
                Get
                    Return _DatePropertyName
                End Get
            End Property

            Private _ValidatorPropertyName As String = ""
            ''' <summary>
            ''' Get the property name that is holding IChronologicValidator.
            ''' </summary>
            Public ReadOnly Property ValidatorPropertyName() As String
                Get
                    Return _ValidatorPropertyName
                End Get
            End Property

            ''' <summary>
            ''' Create a new object.
            ''' </summary>
            ''' <param name="nDatePropertyName">The property name that is holding object date.</param>
            ''' <param name="nValidatorPropertyName">The property name that is holding IChronologicValidator.</param>
            Public Sub New(ByVal nDatePropertyName As String, ByVal nValidatorPropertyName As String)

                MyBase.New(nDatePropertyName)
                _DatePropertyName = nDatePropertyName
                _ValidatorPropertyName = nValidatorPropertyName

            End Sub

            ''' <summary>
            ''' Returns a string representation of the object.
            ''' </summary>
            Public Overrides Function ToString() As String
                Return MyBase.ToString & "?DatePropertyName=" & _DatePropertyName _
                       & "&ValidatorPropertyName=" & _ValidatorPropertyName
            End Function

        End Class

#End Region

#Region " StringValueUniqueInCollectionValidation "

        ''' <summary>
        ''' Rule ensuring a property's value is unique in collection.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function StringValueUniqueInCollectionValidation(ByVal target As Object, _
                                                                ByVal e As RuleArgs) As Boolean

            If Not TypeOf target Is Csla.Core.BusinessBase Then Return True

            Dim parent As ICollection = Nothing
            Try
                Dim fi As PropertyInfo = target.GetType.GetProperty("Parent", _
                                                                    BindingFlags.NonPublic Or BindingFlags.Instance)
                parent = DirectCast(fi.GetValue(target, Nothing), ICollection)
            Catch ex As Exception
                Return True
            End Try

            If parent Is Nothing Then Return True

            Dim value As String = Convert.ToString(CallByName(target, e.PropertyName, CallType.Get))

            If StringIsNullOrEmpty(value) Then Return True

            For Each obj As Object In parent
                If Not Object.ReferenceEquals(obj, target) Then
                    Dim secondValue As String = ""
                    Try
                        secondValue = Convert.ToString(CallByName(obj, e.PropertyName, CallType.Get))
                    Catch ex As Exception
                    End Try
                    If Not StringIsNullOrEmpty(secondValue) AndAlso secondValue.Trim.ToLower = value.Trim.ToLower Then
                        e.Description = String.Format(My.Resources.Common_StringValueNotUniqueInCollection, _
                                                      GetResourcesPropertyName(target.GetType, e.PropertyName))
                        e.Severity = RuleSeverity.Error
                        Return False
                    End If
                End If
            Next

            Return True

        End Function

#End Region

#Region " AltLanguageValidation "

        ''' <summary>
        ''' Rule ensuring the value in alt language is provided when reference 
        ''' property's value contains foreign language code (or reference property
        ''' holds object that has LanguageCode property) (accepts ReferencePropertyRuleArgs).
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        ''' <remarks>
        ''' This implementation uses late binding, and will only work
        ''' against string property values.
        ''' </remarks>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Public Function AltLanguageValidation(ByVal target As Object, ByVal e As RuleArgs) As Boolean

            Dim value As String = DirectCast(CallByName(target, e.PropertyName, CallType.Get), String)
            If Not StringIsNullOrEmpty(value) Then Return True

            Dim args As ReferencePropertyRuleArgs = DirectCast(e, ReferencePropertyRuleArgs)
            Dim referenceObject As Object = CallByName(target, args.ReferencePropertyName, CallType.Get)

            If referenceObject Is Nothing Then Return True

            Dim foreignLanguageSet As Boolean = False
            Dim languageCode As String = ""

            If TypeOf referenceObject Is String Then

                languageCode = DirectCast(referenceObject, String).Trim
                foreignLanguageSet = (Not String.IsNullOrEmpty(languageCode) _
                    AndAlso languageCode.Trim.ToUpper <> LanguageCodeLith.Trim.ToUpper)

            Else

                Try
                    languageCode = DirectCast(CallByName(referenceObject, "LanguageCode", CallType.Get), String)
                    foreignLanguageSet = (Not StringIsNullOrEmpty(languageCode) _
                        AndAlso languageCode.Trim.ToUpper <> LanguageCodeLith.Trim.ToUpper)
                Catch ex As Exception
                End Try

            End If

            If foreignLanguageSet AndAlso String.IsNullOrEmpty(value) Then

                Dim propName As String = GetResourcesPropertyName(target.GetType, e.PropertyName)

                e.Description = String.Format("Nenurodyta {0} ({1}).", propName, _
                    GetLanguageName(languageCode, False))
                e.Severity = RuleSeverity.Error
                Return False

            End If

            Return True

        End Function

        ''' <summary>
        ''' Custom object required by the rule method.
        ''' </summary>
        Public Class ReferencePropertyRuleArgs
            Inherits RuleArgs

            Private _ApplySeverity As RuleSeverity = RuleSeverity.Error
            ''' <summary>
            ''' Severity to apply to the rule.
            ''' </summary>
            Public ReadOnly Property ApplySeverity() As RuleSeverity
                Get
                    Return _ApplySeverity
                End Get
            End Property

            Private _ReferencePropertyName As String = ""
            Public ReadOnly Property ReferencePropertyName() As String
                Get
                    Return _ReferencePropertyName
                End Get
            End Property

            ''' <summary>
            ''' Create a new object.
            ''' </summary>
            ''' <param name="propertyName">Name of the property to validate.</param>
            ''' <param name="SeverityToApply">Severity of the error to apply.</param>
            Public Sub New(ByVal propertyName As String, ByVal nReferencePropertyName As String, _
                Optional ByVal SeverityToApply As RuleSeverity = RuleSeverity.Error)

                MyBase.New(propertyName)
                _ApplySeverity = SeverityToApply
                _ReferencePropertyName = nReferencePropertyName

            End Sub

            ''' <summary>
            ''' Returns a string representation of the object.
            ''' </summary>
            Public Overrides Function ToString() As String
                Return MyBase.ToString & "?ApplySeverity=" & _ApplySeverity.ToString _
                       & "&ReferencePropertyName=" & _ReferencePropertyName
            End Function

        End Class

#End Region


        ''' <summary>
        ''' Gets an attribute of the property of the requested type. Returns null if no attribute 
        ''' of the requested type exists for the property.
        ''' </summary>
        ''' <typeparam name="T">a type of the attribute to get</typeparam>
        ''' <param name="targetType">a type that the property belongs to</param>
        ''' <param name="propertyName">a name of the property to get the attribute for</param>
        ''' <remarks></remarks>
        Public Function GetAttribute(Of T As Attribute)(ByVal targetType As Type, ByVal propertyName As String) As T

            Dim propInfo As PropertyInfo = targetType.GetProperty(propertyName)

            If propInfo Is Nothing Then Return Nothing

            For Each attr As Attribute In Attribute.GetCustomAttributes(propInfo)
                If TypeOf attr Is T OrElse GetType(T).IsAssignableFrom(attr.GetType) Then
                    Return CType(attr, T)
                End If
            Next

            Return Nothing

        End Function

        ''' <summary>
        ''' Gets a human readable localized name of the property requested.
        ''' </summary>
        ''' <param name="targetType">a type that the property belongs to</param>
        ''' <param name="propertyName">a name of the property to get a human readable name for</param>
        ''' <remarks></remarks>
        Public Function GetResourcesPropertyName(ByVal targetType As Type, ByVal propertyName As String) As String

            If targetType.Assembly.FullName <> GetType(BookEntryInternal).Assembly.FullName Then
                Return AccPluginManager.PluginManager.Current.GetLocalizedPropertyName(targetType, propertyName)
            End If

            ' ReSharper disable VBStringIndexOfIsCultureSpecific.1
            Dim resourceName As String = targetType.FullName.Substring(targetType.FullName.IndexOf(".") + 1) _
                .Replace(".", "_") & "_" & propertyName
            ' ReSharper restore VBStringIndexOfIsCultureSpecific.1

            Dim result As String = My.Resources.ResourceManager.GetString(resourceName)

            If String.IsNullOrEmpty(result) Then
                result = propertyName
            End If

            Return result

        End Function

        ''' <summary>
        ''' Gets a human readable localized name of the type requested. 
        ''' </summary>
        ''' <param name="targetType">a type to get a human readable name for</param>
        ''' <remarks></remarks>
        Public Function GetResourcesTypeName(ByVal targetType As Type) As String

            ' ReSharper disable VBStringIndexOfIsCultureSpecific.1
            Dim resourceName As String = targetType.FullName.Substring(targetType.FullName.IndexOf(".") + 1) _
                .Replace(".", "_") & "_TypeName"
            ' ReSharper restore VBStringIndexOfIsCultureSpecific.1

            Dim result As String = My.Resources.ResourceManager.GetString(resourceName)

            If String.IsNullOrEmpty(result) Then
                result = targetType.Name
            End If

            Return result

        End Function

    End Module

End Namespace