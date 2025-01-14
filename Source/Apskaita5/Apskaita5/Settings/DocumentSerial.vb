﻿Imports ApskaitaObjects.Attributes

Namespace Settings

    ''' <summary>
    ''' Represents a serial for a certain document type.
    ''' </summary>
    ''' <remarks>Values are stored in the database table serijos.</remarks>
    <Serializable()> _
    Public NotInheritable Class DocumentSerial
        Inherits BusinessBase(Of DocumentSerial)
        Implements IGetErrorForListItem

#Region " Business Methods "

        Private ReadOnly _Guid As Guid = Guid.NewGuid
        Private _ID As Integer = 0
        Private _Serial As String = ""
        Private _SerialOld As String = ""
        Private _DocumentType As DocumentSerialType = DocumentSerialType.Invoice
        Private _DocumentTypeHumanReadable As String = Utilities.ConvertLocalizedName(DocumentSerialType.Invoice)
        Private _DocumentTypeOld As DocumentSerialType
        Private _WasUsed As Boolean = False


        ''' <summary>
        ''' Gets an ID of the serial that is assigned by a database (AUTOINCREMENT).
        ''' </summary>
        ''' <remarks>Value is stored in the database table serijos.Serijos_ID.</remarks>
        Public ReadOnly Property ID() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ID
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a serial.
        ''' </summary>
        ''' <remarks>Value is stored in the database table serijos.Serija.</remarks>
        <StringField(ValueRequiredLevel.Mandatory, 10, True)> _
        Public Property Serial() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _Serial.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If _WasUsed Then Exit Property
                If value Is Nothing Then value = ""
                If _Serial.Trim <> value.Trim Then
                    _Serial = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a serial value before user update (as in database) .
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property SerialOld() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SerialOld.Trim
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a document type that the serial is ment for.
        ''' </summary>
        ''' <remarks>Value is stored in the database table serijos.Serijos_dok.</remarks>
        Public Property DocumentType() As DocumentSerialType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentType
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As DocumentSerialType)
                CanWriteProperty(True)
                If _WasUsed Then Exit Property
                If _DocumentType <> value Then
                    _DocumentType = value
                    _DocumentTypeHumanReadable = Utilities.ConvertLocalizedName(value)
                    PropertyHasChanged()
                    PropertyHasChanged("DocumentTypeHumanReadable")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a document type before user update (as in database) .
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property DocumentTypeOld() As DocumentSerialType
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentTypeOld
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets a document type that the serial is ment for as a localized human readable string.
        ''' </summary>
        ''' <remarks>Value is stored in the database table serijos.Serijos_dok.</remarks>
        <LocalizedEnumField(GetType(DocumentSerialType), False, "")> _
        Public Property DocumentTypeHumanReadable() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DocumentTypeHumanReadable
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                CanWriteProperty(True)
                If _WasUsed Then Exit Property

                If value Is Nothing Then value = ""

                Dim enumValue As DocumentSerialType = _
                    Utilities.ConvertLocalizedName(Of DocumentSerialType)(value)

                If enumValue <> _DocumentType Then
                    _DocumentType = enumValue
                    _DocumentTypeHumanReadable = Utilities.ConvertLocalizedName(enumValue)
                    PropertyHasChanged()
                    PropertyHasChanged("DocumentType")
                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets the serial was used in some document.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property WasUsed() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _WasUsed
            End Get
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return Me.IsNew OrElse _DocumentType <> _DocumentTypeOld OrElse _
                    _Serial.Trim.ToLower() <> _SerialOld.Trim.ToLower()
            End Get
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


        Protected Overrides Function GetIdValue() As Object
            Return _Guid
        End Function

        Public Overrides Function ToString() As String
            Return String.Format(My.Resources.Settings_DocumentSerial_ToString, _
                _Serial, _DocumentTypeHumanReadable)
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()
            ValidationRules.AddRule(AddressOf CommonValidation.CommonValidation.StringFieldValidation, _
                New Validation.RuleArgs("Serial"))
            ValidationRules.AddRule(AddressOf SerialUniqueValidation, New Validation.RuleArgs("Serial"))
        End Sub

        ''' <summary>
        ''' Rule ensuring the serial of a document is unique.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function SerialUniqueValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As DocumentSerial = DirectCast(target, DocumentSerial)

            If valObj.Parent Is Nothing OrElse StringIsNullOrEmpty(valObj._Serial) Then Return True

            For Each i As DocumentSerial In DirectCast(valObj.Parent, DocumentSerialList)
                If Not Object.ReferenceEquals(i, valObj) AndAlso i._DocumentType = _
                    valObj._DocumentType AndAlso i._Serial.Trim.ToLower = valObj._Serial.Trim.ToLower Then
                    e.Description = My.Resources.Settings_DocumentSerial_ItemNotUnique
                    e.Severity = Validation.RuleSeverity.Error
                    Return False
                End If
            Next

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()

        End Sub

#End Region

#Region " Factory Methods "

        Friend Shared Function NewDocumentSerial() As DocumentSerial
            Dim result As New DocumentSerial
            result.ValidationRules.CheckRules()
            Return result
        End Function

        Friend Shared Function GetDocumentSerial(ByVal dr As DataRow) As DocumentSerial
            Return New DocumentSerial(dr)
        End Function


        Private Sub New()
            ' require use of factory methods
            MarkAsChild()
        End Sub

        Private Sub New(ByVal dr As DataRow)
            MarkAsChild()
            Fetch(dr)
        End Sub

#End Region

#Region " Data Access "

        Private Sub Fetch(ByVal dr As DataRow)

            _ID = CIntSafe(dr.Item(0), 0)
            _DocumentType = Utilities.ConvertDatabaseCharID(Of DocumentSerialType)(CStrSafe(dr.Item(1)))
            _DocumentTypeHumanReadable = Utilities.ConvertLocalizedName(_DocumentType)
            _DocumentTypeOld = _DocumentType
            _Serial = CStrSafe(dr.Item(2)).Trim
            _SerialOld = _Serial
            _WasUsed = ConvertDbBoolean(CIntSafe(dr.Item(3), 0))

            MarkOld()

        End Sub

        Friend Sub Insert(ByVal parent As DocumentSerialList)

            Dim myComm As New SQLCommand("InsertDocumentSerial")
            myComm.AddParam("?SD", Utilities.ConvertDatabaseCharID(_DocumentType))
            myComm.AddParam("?SR", _Serial.Trim)

            myComm.Execute()
            _ID = Convert.ToInt32(myComm.LastInsertID)

            MarkOld()

        End Sub

        Friend Sub Update(ByVal parent As DocumentSerialList)

            Dim myComm As New SQLCommand("UpdateDocumentSerial")
            myComm.AddParam("?SD", Utilities.ConvertDatabaseCharID(_DocumentType))
            myComm.AddParam("?SR", _Serial.Trim)
            myComm.AddParam("?SN", _ID)

            myComm.Execute()

            MarkOld()

        End Sub

        Friend Sub DeleteSelf()

            Dim myComm As New SQLCommand("DeleteDocumentSerial")
            myComm.AddParam("?SN", _ID)

            myComm.Execute()

            MarkNew()

        End Sub

        Friend Sub CheckIfCanUpdateOrDelete()

            If IsNew Then Exit Sub

            If Not Me.IsDirty AndAlso Not Me.IsDeleted Then Exit Sub

            Dim myComm As SQLCommand

            Select Case _DocumentTypeOld
                Case DocumentSerialType.TillIncomeOrder
                    myComm = New SQLCommand("DocumentSerialExists1")
                Case DocumentSerialType.Invoice
                    myComm = New SQLCommand("DocumentSerialExists2")
                Case DocumentSerialType.TillSpendingsOrder
                    myComm = New SQLCommand("DocumentSerialExists3")
                Case DocumentSerialType.LabourContract
                    myComm = New SQLCommand("DocumentSerialExists4")
                Case Else
                    Throw New NotImplementedException(String.Format(My.Resources.Common_DocumentTypeNotImplemented, _
                        _DocumentType.ToString, Me.GetType().FullName, "CheckIfCanUpdateOrDelete"))
            End Select

            myComm.AddParam("?SR", _SerialOld)

            Using myData As DataTable = myComm.Fetch
                If myData.Rows.Count > 0 Then
                    If ConvertDbBoolean(CIntSafe(myData.Rows(0).Item(0), 0)) Then
                        Throw New Exception(String.Format(My.Resources.Settings_DocumentSerial_ItemWasUsed, _
                            _DocumentTypeOld, _SerialOld))
                    End If
                End If
            End Using

        End Sub

#End Region

    End Class

End Namespace
