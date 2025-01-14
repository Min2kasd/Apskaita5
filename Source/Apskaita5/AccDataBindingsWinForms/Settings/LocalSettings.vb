﻿Imports ApskaitaObjects
Imports AccCommon
Imports Csla
Imports System.Drawing

Namespace Settings

    ''' <summary>
    ''' Represents a class that is used to edit the <see cref="MyCustomSettings">
    ''' program settings</see> in a user GUI. Provides validation, dirty state management, etc.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
Public Class LocalSettings
        Inherits BusinessBase(Of LocalSettings)
        Implements IIsDirtyEnough

#Region " Business Methods "

        Private _UseThreadingForDataTransfer As Boolean = False
        Private _AutoReloadData As Boolean = False
        Private _UserName As String = ""
        Private _UserEmailAccount As String = ""
        Private _SmtpServer As String = ""
        Private _UserEmail As String = ""
        Private _UserEmailPassword As String = ""
        Private _UseSslForEmail As Boolean = False
        Private _UseAuthForEmail As Boolean = False
        Private _SmtpPort As String = ""
        Private _ShowToolStrip As Boolean = True
        Private _AutoUpdate As Boolean = True
        Private _EmailMessageText As String = ""
        Private _CacheTimeout As Integer = 0
        Private _SignInvoicesWithCompanySignature As Boolean = False
        Private _SignInvoicesWithLocalUserSignature As Boolean = False
        Private _SignInvoicesWithRemoteUserSignature As Boolean = False
        Private _AllwaysLoginAsLocalUser As Boolean = False
        Private _ShowDefaultMailClientWindow As Boolean = False
        Private _UseDefaultEmailClient As Boolean = True
        Private _AutoSizeForm As Boolean = False
        Private _AutoSizeDataGridViewColumns As Boolean = False
        Private _AllwaysShowWageSettings As Boolean = False
        Private _SQLQueryTimeOut As Integer = 0
        Private _UserSignature As Byte() = Nothing
        Private _BankDocumentPrefix As String = ""
        Private _IgnoreWrongIBAN As Boolean = False
        Private _UpdateUrl As String = ""
        Private _IsPortableInstalation As Boolean = False
        Private _DontSignInvoices As Boolean = True
        Private _LastUpdateDate As Date = Today
        Private _LocalUsers As AccDataAccessLayer.Security.LocalUserList
        Private _AlwaysUseExternalIdInvoicesMade As Boolean = True
        Private _AlwaysUseExternalIdInvoicesReceived As Boolean = True
        Private _DefaultInvoiceReceivedItemIsGoods As Boolean = False
        Private _DefaultInvoiceMadeItemIsGoods As Boolean = False
        Private _CheckInvoiceReceivedNumber As Boolean = True
        Private _CheckInvoiceReceivedNumberWithDate As Boolean = False
        Private _CheckInvoiceReceivedNumberWithSupplier As Boolean = False
        Private _EditListViewWithDoubleClick As Boolean = False
        Private _UseHotTracking As Boolean = True
        Private _ShowEmptyListMessage As Boolean = True
        Private _ShowGridLines As Boolean = False
        Private _DefaultActionByDoubleClick As Boolean = False


        ''' <summary>
        ''' Gets or sets whether data operations should be invoked on a separate thread.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property UseThreadingForDataTransfer() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UseThreadingForDataTransfer
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _UseThreadingForDataTransfer <> value Then
                    _UseThreadingForDataTransfer = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether data in a report should be automaticaly reloaded 
        ''' when a related business object changes.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AutoReloadData() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AutoReloadData
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _AutoReloadData <> value Then
                    _AutoReloadData = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a name (first and last) of the program user (an accountant).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property UserName() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UserName.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _UserName.Trim <> value.Trim Then
                    _UserName = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a user email account.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseEmbededEmailClient">UseEmbededEmailClient</see> 
        ''' is set to TRUE.</remarks>
        Public Property UserEmailAccount() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UserEmailAccount.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _UserEmailAccount.Trim <> value.Trim Then
                    _UserEmailAccount = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a user email SMTP server address.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseEmbededEmailClient">UseEmbededEmailClient</see> 
        ''' is set to TRUE.</remarks>
        Public Property SmtpServer() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SmtpServer.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _SmtpServer.Trim <> value.Trim Then
                    _SmtpServer = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a user email address.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseEmbededEmailClient">UseEmbededEmailClient</see> 
        ''' is set to TRUE.</remarks>
        Public Property UserEmail() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UserEmail.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _UserEmail.Trim <> value.Trim Then
                    _UserEmail = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a user email password.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseEmbededEmailClient">UseEmbededEmailClient</see> 
        ''' is set to TRUE.</remarks>
        Public Property UserEmailPassword() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UserEmailPassword.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _UserEmailPassword.Trim <> value.Trim Then
                    _UserEmailPassword = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the user email is accessed via SSL.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseEmbededEmailClient">UseEmbededEmailClient</see> 
        ''' is set to TRUE.</remarks>
        Public Property UseSslForEmail() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UseSslForEmail
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _UseSslForEmail <> value Then
                    _UseSslForEmail = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the user email is accessed using AUTH protocol.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseEmbededEmailClient">UseEmbededEmailClient</see> 
        ''' is set to TRUE.</remarks>
        Public Property UseAuthForEmail() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UseAuthForEmail
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _UseAuthForEmail <> value Then
                    _UseAuthForEmail = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a user email SMTP server port.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseEmbededEmailClient">UseEmbededEmailClient</see> 
        ''' is set to TRUE.</remarks>
        Public Property SmtpPort() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SmtpPort.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _SmtpPort.Trim <> value.Trim Then
                    _SmtpPort = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the tools strip should be shown on the GUI.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShowToolStrip() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ShowToolStrip
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _ShowToolStrip <> value Then
                    _ShowToolStrip = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the program should automaticaly check for updates
        ''' every time the program is started.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AutoUpdate() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AutoUpdate
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _AutoUpdate <> value Then
                    _AutoUpdate = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a default email text used when sending documents/emails 
        ''' from the program.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property EmailMessageText() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _EmailMessageText.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _EmailMessageText.Trim <> value.Trim Then
                    _EmailMessageText = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a timeout in seconds for the application cached data.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CacheTimeout() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CacheTimeout
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                If value < 0 Then value = 0
                If _CacheTimeout <> value Then
                    _CacheTimeout = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the invoices should be signed with the
        ''' <see cref="General.Company.HeadPersonSignature">company's head signature</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property SignInvoicesWithCompanySignature() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SignInvoicesWithCompanySignature
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _SignInvoicesWithCompanySignature <> value Then
                    If Not value Then
                        PropertyHasChanged()
                        Exit Property
                    End If
                    _SignInvoicesWithCompanySignature = value
                    PropertyHasChanged()
                    If _SignInvoicesWithCompanySignature Then
                        _SignInvoicesWithLocalUserSignature = False
                        _SignInvoicesWithRemoteUserSignature = False
                        _DontSignInvoices = False
                        PropertyHasChanged("SignInvoicesWithLocalUserSignature")
                        PropertyHasChanged("SignInvoicesWithRemoteUserSignature")
                        PropertyHasChanged("DontSignInvoices")
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the invoices should be signed with the
        ''' <see cref="UserSignature">program user signature</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property SignInvoicesWithLocalUserSignature() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SignInvoicesWithLocalUserSignature
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _SignInvoicesWithLocalUserSignature <> value Then
                    If Not value Then
                        PropertyHasChanged()
                        Exit Property
                    End If
                    _SignInvoicesWithLocalUserSignature = value
                    PropertyHasChanged()
                    If _SignInvoicesWithLocalUserSignature Then
                        _SignInvoicesWithCompanySignature = False
                        _SignInvoicesWithRemoteUserSignature = False
                        _DontSignInvoices = False
                        PropertyHasChanged("SignInvoicesWithCompanySignature")
                        PropertyHasChanged("SignInvoicesWithRemoteUserSignature")
                        PropertyHasChanged("DontSignInvoices")
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the invoices should be signed with the
        ''' <see cref="AccDataAccessLayer.Security.UserProfile.Signature">
        ''' remote user signature</see> (current user data on server).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property SignInvoicesWithRemoteUserSignature() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SignInvoicesWithRemoteUserSignature
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _SignInvoicesWithRemoteUserSignature <> value Then
                    If Not value Then
                        PropertyHasChanged()
                        Exit Property
                    End If
                    _SignInvoicesWithRemoteUserSignature = value
                    PropertyHasChanged()
                    If _SignInvoicesWithRemoteUserSignature Then
                        _SignInvoicesWithCompanySignature = False
                        _SignInvoicesWithLocalUserSignature = False
                        _DontSignInvoices = False
                        PropertyHasChanged("SignInvoicesWithCompanySignature")
                        PropertyHasChanged("SignInvoicesWithLocalUserSignature")
                        PropertyHasChanged("DontSignInvoices")
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the invoices should NOT be signed.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DontSignInvoices() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DontSignInvoices
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _DontSignInvoices <> value Then
                    If Not value Then
                        PropertyHasChanged()
                        Exit Property
                    End If
                    _DontSignInvoices = value
                    PropertyHasChanged()
                    If _DontSignInvoices Then
                        _SignInvoicesWithCompanySignature = False
                        _SignInvoicesWithLocalUserSignature = False
                        _SignInvoicesWithRemoteUserSignature = False
                        PropertyHasChanged("SignInvoicesWithCompanySignature")
                        PropertyHasChanged("SignInvoicesWithLocalUserSignature")
                        PropertyHasChanged("SignInvoicesWithRemoteUserSignature")
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to display (remote) login dialog when the program starts.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AllwaysLoginAsLocalUser() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AllwaysLoginAsLocalUser
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _AllwaysLoginAsLocalUser <> value Then
                    _AllwaysLoginAsLocalUser = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether an email window of the default email program
        ''' should be displayed before sending an email message.
        ''' </summary>
        ''' <remarks>Only applicable when <see cref="UseDefaultEmailClient">UseDefaultEmailClient</see>
        ''' is set to TRUE.</remarks>
        Public Property ShowDefaultMailClientWindow() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ShowDefaultMailClientWindow
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _ShowDefaultMailClientWindow <> value Then
                    _ShowDefaultMailClientWindow = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether emails should be sent using a default email program
        ''' (that is installed on the user computer).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property UseDefaultEmailClient() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UseDefaultEmailClient
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _UseDefaultEmailClient <> value Then
                    If Not value Then
                        PropertyHasChanged()
                        Exit Property
                    End If
                    _UseDefaultEmailClient = value
                    PropertyHasChanged()
                    PropertyHasChanged("UseEmbededEmailClient")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether emails should be sent using an embeded email client.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property UseEmbededEmailClient() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return Not _UseDefaultEmailClient
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _UseDefaultEmailClient = value Then
                    If Not value Then
                        PropertyHasChanged()
                        Exit Property
                    End If
                    _UseDefaultEmailClient = Not value
                    PropertyHasChanged()
                    PropertyHasChanged("UseDefaultEmailClient")
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether forms should be autosized (as oposed to user sized).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AutoSizeForm() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AutoSizeForm
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _AutoSizeForm <> value Then
                    _AutoSizeForm = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether table columns should be autosized (as oposed to user sized).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AutoSizeDataGridViewColumns() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AutoSizeDataGridViewColumns
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _AutoSizeDataGridViewColumns <> value Then
                    _AutoSizeDataGridViewColumns = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether company settings should be displayed every time
        ''' before creating a new <see cref="Workers.WageSheet">WageSheet</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AllwaysShowWageSettings() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AllwaysShowWageSettings
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _AllwaysShowWageSettings <> value Then
                    _AllwaysShowWageSettings = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an SQL query time out in seconds. 
        ''' A value of 0 indicates a default timeout (depends on a server type).
        ''' </summary>
        ''' <remarks>Only used localy, not passed to a remote server.</remarks>
        Public Property SQLQueryTimeOut() As Integer
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _SQLQueryTimeOut
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Integer)
                If value < 0 Then value = 0
                If _SQLQueryTimeOut <> value Then
                    _SQLQueryTimeOut = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a signature (facsimile) of the program user (an accountant).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property UserSignature() As Image
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return ByteArrayToImage(_UserSignature)
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Image)

                If value Is Nothing AndAlso (_UserSignature Is Nothing OrElse _
                                             Not _UserSignature.Length > 50) Then Exit Property

                If value Is Nothing Then
                    _UserSignature = Nothing
                    PropertyHasChanged()
                    Exit Property
                End If

                Dim valueArray As Byte() = ImageToByteArray(value)

                If _UserSignature Is Nothing OrElse valueArray Is Nothing OrElse _
                   Not _UserSignature.Equals(valueArray) Then
                    _UserSignature = valueArray
                    PropertyHasChanged()
                End If

            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a default <see cref="Documents.BankOperationItemList">
        ''' bank operation document number prefix</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property BankDocumentPrefix() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _BankDocumentPrefix.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _BankDocumentPrefix.Trim <> value.Trim Then
                    _BankDocumentPrefix = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether <see cref="Documents.BankOperationItemList">
        ''' to ignore IBAN number mismatch when importing bank operations data</see>.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property IgnoreWrongIBAN() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IgnoreWrongIBAN
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _IgnoreWrongIBAN <> value Then
                    _IgnoreWrongIBAN = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets an url where the program update files are located.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property UpdateUrl() As String
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UpdateUrl.Trim
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As String)
                If value Is Nothing Then value = ""
                If _UpdateUrl.Trim <> value.Trim Then
                    _UpdateUrl = value.Trim
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets a list of user data in the (remote) login form.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property LocalUsers() As AccDataAccessLayer.Security.LocalUserList
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LocalUsers
            End Get
        End Property

        ''' <summary>
        ''' Indicates whether the current program is running as portable,
        ''' i.e. all resources including settings are stored in the application folder.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property IsPortableInstalation() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _IsPortableInstalation
            End Get
        End Property

        ''' <summary>
        ''' Gets a date when the application was last updated.
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property LastUpdateDate() As Date
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _LastUpdateDate
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets whether to add <see cref="Documents.InvoiceMade.ExternalID">
        ''' an external ID of the invoice made</see> without the user confirmation
        ''' when copying an invoice from an external source.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AlwaysUseExternalIdInvoicesMade() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AlwaysUseExternalIdInvoicesMade
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _AlwaysUseExternalIdInvoicesMade <> value Then
                    _AlwaysUseExternalIdInvoicesMade = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to add <see cref="Documents.InvoiceReceived.ExternalID">
        ''' an external ID of the invoice received</see> without the user confirmation
        ''' when copying an invoice from an external source.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property AlwaysUseExternalIdInvoicesReceived() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _AlwaysUseExternalIdInvoicesReceived
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _AlwaysUseExternalIdInvoicesReceived <> value Then
                    _AlwaysUseExternalIdInvoicesReceived = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the default new item in an invoice received
        ''' should be goods purchase (as oposed to a service bought).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DefaultInvoiceReceivedItemIsGoods() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultInvoiceReceivedItemIsGoods
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _DefaultInvoiceReceivedItemIsGoods <> value Then
                    _DefaultInvoiceReceivedItemIsGoods = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether the default new item in an invoice made
        ''' should be goods sale (as oposed to a service sold).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DefaultInvoiceMadeItemIsGoods() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultInvoiceMadeItemIsGoods
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                If _DefaultInvoiceMadeItemIsGoods <> value Then
                    _DefaultInvoiceMadeItemIsGoods = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to check if the invoice received number is unique.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CheckInvoiceReceivedNumber() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CheckInvoiceReceivedNumber
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _CheckInvoiceReceivedNumber <> value Then
                    _CheckInvoiceReceivedNumber = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to check the invoice received number uniqueness
        ''' taking into account the invoice date.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CheckInvoiceReceivedNumberWithDate() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CheckInvoiceReceivedNumberWithDate
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _CheckInvoiceReceivedNumberWithDate <> value Then
                    _CheckInvoiceReceivedNumberWithDate = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to check the invoice received number uniqueness
        ''' taking into account the supplier.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CheckInvoiceReceivedNumberWithSupplier() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _CheckInvoiceReceivedNumberWithSupplier
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _CheckInvoiceReceivedNumberWithSupplier <> value Then
                    _CheckInvoiceReceivedNumberWithSupplier = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether ObjectListView edit is initiated on double click (instead of single click).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property EditListViewWithDoubleClick() As Boolean
            Get
                Return _EditListViewWithDoubleClick
            End Get
            Set(ByVal value As Boolean)
                If _EditListViewWithDoubleClick <> value Then
                    _EditListViewWithDoubleClick = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to use hot item traking in the ObjectListView's. (CPU intensive)
        ''' </summary>
        ''' <remarks></remarks>
        Public Property UseHotTracking() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _UseHotTracking
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _UseHotTracking <> value Then
                    _UseHotTracking = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to show a default empty list message in the ObjectListView's.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShowEmptyListMessage() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ShowEmptyListMessage
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _ShowEmptyListMessage <> value Then
                    _ShowEmptyListMessage = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to show gridlines in the ObjectListView's.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ShowGridLines() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _ShowGridLines
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _ShowGridLines <> value Then
                    _ShowGridLines = value
                    PropertyHasChanged()
                End If
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets whether to perform a default action when 
        ''' an ObjectListView is double clicked (as oposed to showing 
        ''' a meniu of available actions).
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DefaultActionByDoubleClick() As Boolean
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Get
                Return _DefaultActionByDoubleClick
            End Get
            <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.NoInlining)> _
            Set(ByVal value As Boolean)
                CanWriteProperty(True)
                If _DefaultActionByDoubleClick <> value Then
                    _DefaultActionByDoubleClick = value
                    PropertyHasChanged()
                End If
            End Set
        End Property


        Public Overrides ReadOnly Property IsDirty() As Boolean
            Get
                Return MyBase.IsDirty OrElse _LocalUsers.IsDirty
            End Get
        End Property

        Public ReadOnly Property IsDirtyEnough() As Boolean _
            Implements ApskaitaObjects.IIsDirtyEnough.IsDirtyEnough
            Get
                Return MyBase.IsDirty OrElse _LocalUsers.IsDirty
            End Get
        End Property

        Public Overrides ReadOnly Property IsValid() As Boolean
            Get
                Return MyBase.IsValid AndAlso _LocalUsers.IsValid
            End Get
        End Property


        Public Function GetAllErrors() As String
            Dim result As String = ""
            If Not MyBase.IsValid Then result = MyBase.BrokenRulesCollection.ToString(Validation.RuleSeverity.Error)
            If Not _LocalUsers.IsValid Then
                If String.IsNullOrEmpty(result.Trim) Then
                    result = _LocalUsers.GetAllBrokenRules
                Else
                    result = result & vbCrLf & _LocalUsers.GetAllBrokenRules
                End If
            End If
            Return result
        End Function

        Public Function GetAllWarnings() As String
            Dim result As String = ""
            If MyBase.BrokenRulesCollection.WarningCount > 0 Then _
                result = MyBase.BrokenRulesCollection.ToString(Validation.RuleSeverity.Warning)
            Return result
        End Function


        Public Overrides Function Save() As LocalSettings
            Return MyBase.Save
        End Function


        Protected Overrides Function GetIdValue() As Object
            Return 1
        End Function

        Public Overrides Function ToString() As String
            Return "LocalSettings"
        End Function

#End Region

#Region " Validation Rules "

        Protected Overrides Sub AddBusinessRules()

            ValidationRules.AddRule(AddressOf MailCredentialsValidation, _
                                    New Validation.RuleArgs("SmtpServer"))
            ValidationRules.AddRule(AddressOf MailCredentialsValidation, _
                                    New Validation.RuleArgs("UserEmail"))
            ValidationRules.AddRule(AddressOf MailCredentialsValidation, _
                                    New Validation.RuleArgs("SmtpPort"))
            ValidationRules.AddRule(AddressOf MailCredentialsValidation, _
                                    New Validation.RuleArgs("UserEmailAccount"))
            ValidationRules.AddRule(AddressOf MailCredentialsValidation, _
                                    New Validation.RuleArgs("UserEmailPassword"))

            ValidationRules.AddRule(AddressOf UpdateUrlValidation, _
                                    New Validation.RuleArgs("UpdateUrl"))

            ValidationRules.AddDependantProperty("UseDefaultEmailClient", "SmtpServer", False)
            ValidationRules.AddDependantProperty("UseDefaultEmailClient", "UserEmail", False)
            ValidationRules.AddDependantProperty("UseDefaultEmailClient", "SmtpPort", False)
            ValidationRules.AddDependantProperty("UseDefaultEmailClient", "UserEmailAccount", False)
            ValidationRules.AddDependantProperty("UseDefaultEmailClient", "UserEmailPassword", False)
            ValidationRules.AddDependantProperty("UseAuthForEmail", "UserEmailAccount", False)
            ValidationRules.AddDependantProperty("UseAuthForEmail", "UserEmailPassword", False)

        End Sub

        ''' <summary>
        ''' Rule ensuring that the value of property SmtpServer is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function MailCredentialsValidation(ByVal target As Object, _
                                                          ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As LocalSettings = DirectCast(target, LocalSettings)

            If Not valObj._UseDefaultEmailClient Then

                Select Case e.PropertyName.Trim.ToLower

                    Case "smtpserver"

                        If valObj._SmtpServer Is Nothing OrElse String.IsNullOrEmpty(valObj._SmtpServer.Trim) Then
                            e.Description = "Nenurodytas SMTP serverio adresas."
                            e.Severity = Validation.RuleSeverity.Error
                            Return False
                        End If

                    Case "useremail"

                        If valObj._UserEmail Is Nothing OrElse String.IsNullOrEmpty(valObj._UserEmail.Trim) Then
                            e.Description = "Nenurodytas e-pašto adresas."
                            e.Severity = Validation.RuleSeverity.Error
                            Return False
                        End If

                    Case "smtpport"

                        If valObj._SmtpPort Is Nothing OrElse String.IsNullOrEmpty(valObj._SmtpPort.Trim) Then
                            e.Description = "Nenurodytas SMTP serverio portas."
                            e.Severity = Validation.RuleSeverity.Error
                            Return False
                        End If

                    Case Else

                        If valObj._UseAuthForEmail Then

                            Select Case e.PropertyName.Trim.ToLower

                                Case "useremailaccount"

                                    If valObj._UserEmailAccount Is Nothing OrElse String.IsNullOrEmpty(valObj._UserEmailAccount.Trim) Then
                                        e.Description = "Nenurodytas e-pašto account'as."
                                        e.Severity = Validation.RuleSeverity.Error
                                        Return False
                                    End If

                                Case "useremailpassword"

                                    If valObj._UserEmailPassword Is Nothing OrElse String.IsNullOrEmpty(valObj._UserEmailPassword.Trim) Then
                                        e.Description = "Nenurodytas e-pašto slaptažodis."
                                        e.Severity = Validation.RuleSeverity.Error
                                        Return False
                                    End If

                            End Select

                        End If

                End Select

            End If

            Return True

        End Function

        ''' <summary>
        ''' Rule ensuring that the value of property UpdateUrl is valid.
        ''' </summary>
        ''' <param name="target">Object containing the data to validate</param>
        ''' <param name="e">Arguments parameter specifying the name of the string
        ''' property to validate</param>
        ''' <returns><see langword="false" /> if the rule is broken</returns>
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")> _
        Private Shared Function UpdateUrlValidation(ByVal target As Object, _
            ByVal e As Validation.RuleArgs) As Boolean

            Dim valObj As LocalSettings = DirectCast(target, LocalSettings)

            If StringIsNullOrEmpty(valObj._UpdateUrl) Then
                e.Description = "Nenurodyta atnaujinimų serverio URL (nebus gaunami atnaujinimai)."
                e.Severity = Validation.RuleSeverity.Warning
                Return False
            End If

            Return True

        End Function

#End Region

#Region " Authorization Rules "

        Protected Overrides Sub AddAuthorizationRules()
            AuthorizationRules.AllowWrite("")
        End Sub

        Public Shared Function CanGetObject() As Boolean
            Return True
        End Function

        Public Shared Function CanAddObject() As Boolean
            Return False
        End Function

        Public Shared Function CanEditObject() As Boolean
            Return True
        End Function

        Public Shared Function CanDeleteObject() As Boolean
            Return False
        End Function

#End Region

#Region " Factory Methods "

        Public Shared Function GetLocalSettings() As LocalSettings
            Return DataPortal.Fetch(Of LocalSettings)(New Criteria())
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


        <RunLocal()> _
        Private Overloads Sub DataPortal_Fetch(ByVal criteria As Criteria)

            _UseThreadingForDataTransfer = MyCustomSettings.UseThreadingForDataTransfer
            _AutoReloadData = MyCustomSettings.AutoReloadData
            _UserName = MyCustomSettings.UserName
            _UserEmailAccount = MyCustomSettings.UserEmailAccount
            _SmtpServer = MyCustomSettings.SmtpServer
            _UserEmail = MyCustomSettings.UserEmail
            _UserEmailPassword = MyCustomSettings.UserEmailPassword
            _UseSslForEmail = MyCustomSettings.UseSslForEmail
            _UseAuthForEmail = MyCustomSettings.UseAuthForEmail
            _SmtpPort = MyCustomSettings.SmtpPort
            _ShowToolStrip = MyCustomSettings.ShowToolStrip
            _AutoUpdate = MyCustomSettings.AutoUpdate
            _EmailMessageText = MyCustomSettings.EmailMessageText
            _CacheTimeout = MyCustomSettings.CacheTimeout
            _SignInvoicesWithCompanySignature = MyCustomSettings.SignInvoicesWithCompanySignature
            _SignInvoicesWithLocalUserSignature = MyCustomSettings.SignInvoicesWithLocalUserSignature
            _SignInvoicesWithRemoteUserSignature = MyCustomSettings.SignInvoicesWithRemoteUserSignature
            _DontSignInvoices = (Not _SignInvoicesWithCompanySignature AndAlso _
                Not _SignInvoicesWithLocalUserSignature AndAlso _
                Not _SignInvoicesWithRemoteUserSignature)
            _AllwaysLoginAsLocalUser = MyCustomSettings.AllwaysLoginAsLocalUser
            _ShowDefaultMailClientWindow = MyCustomSettings.ShowDefaultMailClientWindow
            _UseDefaultEmailClient = MyCustomSettings.UseDefaultEmailClient
            _AutoSizeForm = MyCustomSettings.AutoSizeForm
            _AutoSizeDataGridViewColumns = MyCustomSettings.AutoSizeDataGridViewColumns
            _AllwaysShowWageSettings = MyCustomSettings.AllwaysShowWageSettings
            _SQLQueryTimeOut = MyCustomSettings.SQLQueryTimeOut
            _BankDocumentPrefix = MyCustomSettings.BankDocumentPrefix
            _IgnoreWrongIBAN = MyCustomSettings.IgnoreWrongIBAN
            _UpdateUrl = MyCustomSettings.UpdateUrl
            _IsPortableInstalation = MyCustomSettings.IsPortableInstalation
            _LastUpdateDate = MyCustomSettings.LastUpdateDate
            _AlwaysUseExternalIdInvoicesMade = MyCustomSettings.AlwaysUseExternalIdInvoicesMade
            _AlwaysUseExternalIdInvoicesReceived = MyCustomSettings.AlwaysUseExternalIdInvoicesReceived
            _DefaultInvoiceMadeItemIsGoods = MyCustomSettings.DefaultInvoiceMadeItemIsGoods
            _DefaultInvoiceReceivedItemIsGoods = MyCustomSettings.DefaultInvoiceReceivedItemIsGoods
            _CheckInvoiceReceivedNumber = MyCustomSettings.CheckInvoiceReceivedNumber
            _CheckInvoiceReceivedNumberWithDate = MyCustomSettings.CheckInvoiceReceivedNumberWithDate
            _CheckInvoiceReceivedNumberWithSupplier = MyCustomSettings.CheckInvoiceReceivedNumberWithSupplier
            _EditListViewWithDoubleClick = MyCustomSettings.EditListViewWithDoubleClick
            _UseHotTracking = MyCustomSettings.UseHotTracking
            _ShowEmptyListMessage = MyCustomSettings.ShowEmptyListMessage
            _ShowGridLines = MyCustomSettings.ShowGridLines
            _DefaultActionByDoubleClick = MyCustomSettings.DefaultActionByDoubleClick
            _LocalUsers = AccDataAccessLayer.Security.LocalUserList.GetLocalUserList(MyCustomSettings.LocalUsers)

            _UserSignature = Convert.FromBase64String(MyCustomSettings.UserSignature)

            ValidationRules.CheckRules()

            MarkOld()

        End Sub

        <RunLocal()> _
        Protected Overrides Sub DataPortal_Update()

            Me.ValidationRules.CheckRules()
            If Not IsValid Then
                Throw New Exception(String.Format("Duomenyse yra klaidų:{0}{1}", vbCrLf, Me.GetAllErrors))
            End If

            MyCustomSettings.UseThreadingForDataTransfer = _UseThreadingForDataTransfer
            MyCustomSettings.AutoReloadData = _AutoReloadData
            MyCustomSettings.UserName = _UserName
            MyCustomSettings.UserEmailAccount = _UserEmailAccount
            MyCustomSettings.SmtpServer = _SmtpServer
            MyCustomSettings.UserEmail = _UserEmail
            MyCustomSettings.UserEmailPassword = _UserEmailPassword
            MyCustomSettings.UseSslForEmail = _UseSslForEmail
            MyCustomSettings.UseAuthForEmail = _UseAuthForEmail
            MyCustomSettings.SmtpPort = _SmtpPort
            MyCustomSettings.ShowToolStrip = _ShowToolStrip
            MyCustomSettings.AutoUpdate = _AutoUpdate
            MyCustomSettings.EmailMessageText = _EmailMessageText
            MyCustomSettings.CacheTimeout = _CacheTimeout
            MyCustomSettings.SignInvoicesWithCompanySignature = _SignInvoicesWithCompanySignature
            MyCustomSettings.SignInvoicesWithLocalUserSignature = _SignInvoicesWithLocalUserSignature
            MyCustomSettings.SignInvoicesWithRemoteUserSignature = _SignInvoicesWithRemoteUserSignature
            MyCustomSettings.AllwaysLoginAsLocalUser = _AllwaysLoginAsLocalUser
            MyCustomSettings.ShowDefaultMailClientWindow = _ShowDefaultMailClientWindow
            MyCustomSettings.UseDefaultEmailClient = _UseDefaultEmailClient
            MyCustomSettings.AutoSizeForm = _AutoSizeForm
            MyCustomSettings.AutoSizeDataGridViewColumns = _AutoSizeDataGridViewColumns
            MyCustomSettings.AllwaysShowWageSettings = _AllwaysShowWageSettings
            MyCustomSettings.SQLQueryTimeOut = _SQLQueryTimeOut
            MyCustomSettings.BankDocumentPrefix = _BankDocumentPrefix
            MyCustomSettings.IgnoreWrongIBAN = _IgnoreWrongIBAN
            MyCustomSettings.UpdateUrl = _UpdateUrl
            MyCustomSettings.AlwaysUseExternalIdInvoicesMade = _AlwaysUseExternalIdInvoicesMade
            MyCustomSettings.AlwaysUseExternalIdInvoicesReceived = _AlwaysUseExternalIdInvoicesReceived
            MyCustomSettings.DefaultInvoiceMadeItemIsGoods = _DefaultInvoiceMadeItemIsGoods
            MyCustomSettings.DefaultInvoiceReceivedItemIsGoods = _DefaultInvoiceReceivedItemIsGoods
            MyCustomSettings.CheckInvoiceReceivedNumber = _CheckInvoiceReceivedNumber
            MyCustomSettings.CheckInvoiceReceivedNumberWithDate = _CheckInvoiceReceivedNumberWithDate
            MyCustomSettings.CheckInvoiceReceivedNumberWithSupplier = _CheckInvoiceReceivedNumberWithSupplier
            MyCustomSettings.EditListViewWithDoubleClick = _EditListViewWithDoubleClick
            MyCustomSettings.UseHotTracking = _UseHotTracking
            MyCustomSettings.ShowEmptyListMessage = _ShowEmptyListMessage
            MyCustomSettings.ShowGridLines = _ShowGridLines
            MyCustomSettings.DefaultActionByDoubleClick = _DefaultActionByDoubleClick

            MyCustomSettings.LocalUsers = _LocalUsers.GetSettingsString

            If _UserSignature Is Nothing OrElse _UserSignature.Length < 50 Then
                MyCustomSettings.UserSignature = ""
            Else
                MyCustomSettings.UserSignature = Convert.ToBase64String(_UserSignature)
            End If

            MyCustomSettings.Save()

            MarkOld()

        End Sub

#End Region

    End Class

End Namespace