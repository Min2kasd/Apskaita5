Imports System.Configuration
Imports System.Globalization
Public Module Utilities

    Public Delegate Sub SaveCommonSettingsLocal(ByVal settingsXmlString As String)
    Public Delegate Function GetCommonSettingsLocal() As String

    Friend _SaveCommonSettingsLocal As SaveCommonSettingsLocal = Nothing
    Friend _GetCommonSettingsLocal As GetCommonSettingsLocal = Nothing

    Public Sub AttachLocalSettingsMethods(ByVal nSaveCommonSettingsLocal As SaveCommonSettingsLocal, _
        ByVal nGetCommonSettingsLocal As GetCommonSettingsLocal)

        _SaveCommonSettingsLocal = nSaveCommonSettingsLocal
        _GetCommonSettingsLocal = nGetCommonSettingsLocal

    End Sub

#Region " String manipulation methods "

    ''' <summary>
    ''' Gets a substring from Tab (CHR9) delimited string.
    ''' </summary>
    ''' <param name="SourceString">Tab (CHR9) delimited string.</param>
    ''' <param name="index">Number (index) of substring to retrieve.</param>
    Public Function GetElement(ByVal SourceString As String, ByVal index As Integer) As String
        Dim SubStrings As String() = SourceString.Split(Chr(9))
        If SubStrings.Length > index Then
            Return SubStrings(index)
        Else
            Return ""
        End If
    End Function

    ''' <summary>
    ''' Gets a Tab (CHR9) delimited string consisting of the elements provided.
    ''' </summary>
    ''' <param name="list">List of the elements.</param>
    Public Function ElementsToString(ByVal list As List(Of String)) As String
        If list Is Nothing OrElse list.Count < 1 Then Return ""
        If list.Count = 1 Then Return list(0)
        Return String.Join(Chr(9), list.ToArray)
    End Function

    ''' <summary>
    ''' Gets a list of elemnts in the Tab (CHR9) delimited string provided.
    ''' </summary>
    ''' <param name="SourceString">Tab (CHR9) delimited string containing elements.</param>
    Public Function StringToElements(ByVal SourceString As String) As List(Of String)
        If SourceString Is Nothing OrElse String.IsNullOrEmpty(SourceString.Trim) Then _
            Return New List(Of String)
        Return New List(Of String)(SourceString.Split(New Char() {Chr(9)}, StringSplitOptions.None))
    End Function

    ''' <summary>
    ''' Gets a string filled with blank spaces.
    ''' </summary>
    ''' <param name="Count">Number of blank spaces to add.</param>
    Public Function GetEmptyString(ByVal Count As Integer) As String
        Return String.Empty.PadRight(Count, " "c)
    End Function

    ''' <summary>
    ''' Gets a string which length does not exceeds maximum length provided.
    ''' </summary>
    ''' <param name="MaxLength">Maximum allowed length of the string.</param>
    ''' <param name="s">String to be checked.</param>
    Public Function GetLimitedLengthString(ByVal s As String, ByVal MaxLength As Integer) As String
        If s Is Nothing Then Return ""
        If s.Trim.Length <= MaxLength Then Return s.Trim
        Return s.Trim.Substring(0, MaxLength)
    End Function

    ''' <summary>
    ''' Gets a string which length is at least minimum length provided.
    ''' </summary>
    ''' <param name="s">Base string.</param>
    ''' <param name="MinLength">Minimum length of the string to be returned.</param>
    ''' <param name="CharToAdd">Char to be used when adding to the minimum lenght.</param>
    ''' <param name="AddAtTheBegining">If set to TRUE, chars are added at the begining of the string (if it's too short).</param>
    Public Function GetMinLengthString(ByVal s As String, ByVal MinLength As Integer, _
        ByVal CharToAdd As Char, Optional ByVal AddAtTheBegining As Boolean = True) As String
        If s.Trim.Length >= MinLength Then Return s.Trim
        If AddAtTheBegining Then Return s.Trim.PadLeft(MinLength, CharToAdd)
        Return s.Trim.PadRight(MinLength, CharToAdd)
    End Function

    ''' <summary>
    ''' Gets a numeric part (consisting of numbers) of the string.
    ''' </summary>
    ''' <param name="s">String which the numeric part is to be extracted from.</param>
    Public Function GetNumericPart(ByVal s As String) As String
        If s Is Nothing OrElse String.IsNullOrEmpty(s.Trim) Then Return ""
        s = s.Trim
        Dim result As String = ""
        For i As Integer = s.Length To 1 Step -1
            If Not Char.IsNumber(s.Chars(i - 1)) Then Return result
            result = s.Chars(i - 1) & result
        Next
        Return result
    End Function

    ''' <summary>
    ''' Gets a string that consists of the char repeated number of times.
    ''' </summary>
    ''' <param name="c">Char to be used when building the result.</param>
    ''' <param name="number">Number of times the char is to be repeated.</param>
    Public Function GetRepeatedCharString(ByVal c As Char, ByVal number As Integer) As String
        Return String.Empty.PadRight(number, c)
    End Function

    ''' <summary>
    ''' Adds a new string (line) separated by VbCrLf to the TargetString.
    ''' </summary>
    ''' <param name="TargetString">Cumulative string, containing lines separated by VbCrLf.</param>
    ''' <param name="NewLineString">String containing the new line to add.</param>
    ''' <param name="AllowAddEmptyLine">Add the new line even if it is empty.</param>
    ''' <returns>TargetString added with the NewLineString.</returns>
    Friend Function AddWithNewLine(ByVal TargetString As String, _
        ByVal NewLineString As String, ByVal AllowAddEmptyLine As Boolean) As String

        If NewLineString Is Nothing Then NewLineString = ""
        If TargetString Is Nothing Then TargetString = ""

        If AllowAddEmptyLine OrElse Not String.IsNullOrEmpty(NewLineString.Trim) Then
            If String.IsNullOrEmpty(TargetString.Trim) Then
                Return NewLineString.Trim
            Else
                Return TargetString.Trim & vbCrLf & NewLineString.Trim
            End If

        Else
            Return TargetString

        End If

    End Function

    ''' <summary>
    ''' Gets a string (column) value separated by delimiter from the value.
    ''' If value is nothing or empty, returns empty string.
    ''' If value field count is less then the index, returns empty string.
    ''' </summary>
    ''' <param name="value">String, containing fields separated by delimiter.</param>
    ''' <param name="delimiter">String that is used to delimit fields.</param>
    ''' <param name="index">Index of the field to return.</param>
    Friend Function GetField(ByVal value As String, ByVal delimiter As String, _
        ByVal index As Integer) As String
        If index < 0 Then Throw New ArgumentOutOfRangeException( _
            "Parameter index cannot be less then 0 in method Account.GetField.")
        If value Is Nothing OrElse String.IsNullOrEmpty(value.Trim) Then Return ""
        Dim values As String() = value.Split(New String() {delimiter}, StringSplitOptions.None)
        If values.Length < index + 1 Then Return ""
        Return values(index).Trim
    End Function

#End Region

#Region " Formating (parsing) methods "

    ''' <summary>
    ''' Converts number to its' letter representation, e.g. 1 to A, 2 to B etc..
    ''' </summary>
    ''' <param name="Number">Number to convert.</param>
    Public Function GetNumberInLetter(ByVal Number As Integer) As String
        Dim letters As String() = New String() {"A", "B", "C", "D", "E", "F", "G", "H", _
            "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "Z", "W"}
        If Number > letters.Length Then Return "X"
        Return letters(Number - 1)
    End Function

    ''' <summary>
    ''' Converts number to its' roman representation, e.g. 1 to I, 2 to II etc..
    ''' </summary>
    ''' <param name="Number">Number to convert.</param>
    Public Function GetRomanNumber(ByVal Number As Integer) As String

        If Number < 0 Then Number = -Number

        Dim sb As New System.Text.StringBuilder()

        While Number > 0
            If Number >= 1000 Then
                sb.Append("M")
                Number -= 1000
            ElseIf Number >= 900 Then
                sb.Append("CM")
                Number -= 900
            ElseIf Number >= 500 Then
                sb.Append("D")
                Number -= 500
            ElseIf Number >= 400 Then
                sb.Append("CD")
                Number -= 400
            ElseIf Number >= 100 Then
                sb.Append("C")
                Number -= 100
            ElseIf Number >= 90 Then
                sb.Append("XC")
                Number -= 90
            ElseIf Number >= 50 Then
                sb.Append("L")
                Number -= 50
            ElseIf Number >= 40 Then
                sb.Append("XL")
                Number -= 40
            ElseIf Number >= 10 Then
                sb.Append("X")
                Number -= 10
            ElseIf Number >= 9 Then
                sb.Append("IX")
                Number -= 9
            ElseIf Number >= 5 Then
                sb.Append("V")
                Number -= 5
            ElseIf Number >= 4 Then
                sb.Append("IV")
                Number -= 4
            ElseIf Number >= 1 Then
                sb.Append("I")
                Number -= 1
            Else
                Throw New Exception("Unexpected error.")
                ' <<-- shouldn't be possble to get here, but it ensures that we will never have an infinite loop (in case the computer is on crack that day).
            End If
        End While

        Return sb.ToString()

    End Function

    ''' <summary>
    ''' Gets a formated and rounded representation of the number.
    ''' </summary>
    ''' <param name="d">Number (double) to be formated.</param>
    ''' <param name="RoundOrder">Round order to be applied (default is 2).</param>
    Public Function DblParser(ByVal d As Double, Optional ByVal RoundOrder As Integer = 2) As String

        Dim formatString As String = "##,0"
        If RoundOrder > 0 Then formatString = formatString & "." _
            & GetRepeatedCharString("0", RoundOrder)

        Return d.ToString(formatString)

    End Function

    ''' <summary>
    ''' Gets a string that represents date formated by ffdata standarts.
    ''' </summary>
    ''' <param name="d">Date to format.</param>
    Public Function GetDateInFFDataFormat(ByVal d As Date) As String
        Return d.ToString("yyyy-MM-dd") 
    End Function

    ''' <summary>
    ''' Gets a string that represents number formated by ffdata standarts.
    ''' </summary>
    ''' <param name="n">Number to format.</param>
    Public Function GetNumberInFFDataFormat(ByVal n As Double) As String

        Dim result As String = CRound(n).ToString. _
            Replace(CChar(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator), ""). _
            Replace(CChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator), ",").Trim

        If result.IndexOf(",") < 0 Then result = result & ",00"
        If result.Substring(result.IndexOf(",")).Length < 2 Then result = result & "0"

        Return result
    End Function

    ''' <summary>
    ''' Gets a string that represents month name in lithuanian.
    ''' </summary>
    ''' <param name="MonthNumber">Number of the month.</param>
    Public Function GetLithuanianMonth(ByVal MonthNumber As Integer) As String
        Select Case MonthNumber
            Case 1
                Return "Sausio"
            Case 2
                Return "Vasario"
            Case 3
                Return "Kovo"
            Case 4
                Return "Balandžio"
            Case 5
                Return "Gegužės"
            Case 6
                Return "Birželio"
            Case 7
                Return "Liepos"
            Case 8
                Return "Rugpjūčio"
            Case 9
                Return "Rugsėjo"
            Case 10
                Return "Spalio"
            Case 11
                Return "Lapkričio"
            Case Else
                Return "Gruodžio"
        End Select
    End Function

    Public Function GetLithuanianDate(ByVal value As Date) As String
        Return value.Year.ToString & " m. " & GetLithuanianMonth(value.Month) & " mėn. " _
            & value.Day.ToString.PadLeft(2, "0"c) & " d."
    End Function

    ''' <summary>
    ''' Gets a string that represents number wording in lithuanian.
    ''' </summary>
    ''' <param name="NumberArg">Number to convert.</param>
    ''' <param name="intCase">Casing of the string to be returned (0-TitleCase; 1-UpperCase; 2-LowerCase)</param>
    ''' <param name="AddZero">Indicates whether zeros should be added.</param>
    Public Function SumLT(ByVal NumberArg As Double, Optional ByVal intCase As Integer = 0, _
       Optional ByVal AddZero As Boolean = True) As String
        '*----------------------------
        ' Funkcijos pirmasis argumentas – suma, užrašyta skaičiais
        ' Funkcijos antrasis (nebūtinas) argumentas – požymis, 
        ' nusakantis, kokiomis raidėmis bus gauta funkcijos reikšmė:
        ' 0 (arba praleistas) – pirmoji sakinio raidė didžioji, o kitos mažosios;
        ' 1 visas sakinys – didžiosios raidės;
        ' 2 visas sakinys – mažosios raidės.
        ' Funkcijos reikšmė – suma žodžiais.
        '*----------------------------

        Dim strSuma As String
        Dim strMillions As String
        Dim strThousands As String
        Dim strHundreds As String
        Dim m1 As String
        Dim m2 As String
        Dim t1 As String
        Dim t2 As String
        Dim r1 As String
        Dim r2 As String
        Dim v As String
        Dim d As String
        Dim strRez As String

        strSuma = Format(NumberArg, "000,000,000.00")
        strMillions = Mid(strSuma, 1, 3)
        strThousands = Mid(strSuma, 5, 3)
        strHundreds = Mid(strSuma, 9, 3)
        If NumberArg < 1 Then
            strRez = "NULIS LITŲ "
            GoTo pabaiga
        End If

        If strMillions <> "000" Then
            m1 = TrysSkaitmenys(strMillions)
            d = Mid(strMillions, 2, 1)
            v = Right(strMillions, 1)
            Select Case d
                Case "1"
                    m2 = "MILIJONŲ "
                Case Else
                    Select Case v
                        Case "0"
                            m2 = "MILIJONŲ "
                        Case "1"
                            m2 = "MILIJONAS "
                        Case Else
                            m2 = "MILIJONAI "
                    End Select
            End Select
        End If
        If strThousands <> "000" Then
            t1 = TrysSkaitmenys(strThousands)
            d = Mid(strThousands, 2, 1)
            v = Right(strThousands, 1)
            Select Case d
                Case "1"
                    t2 = "TŪKSTANČIŲ "
                Case Else
                    Select Case v
                        Case "0"
                            t2 = "TŪKSTANČIŲ "
                        Case "1"
                            t2 = "TŪKSTANTIS "
                        Case Else
                            t2 = "TŪKSTANČIAI "
                    End Select

            End Select
        End If

        r1 = TrysSkaitmenys(strHundreds)
        d = Mid(strHundreds, 2, 1)
        v = Right(strHundreds, 1)
        Select Case d
            Case "1"
                r2 = "LITŲ "
            Case Else
                Select Case v
                    Case "0"
                        r2 = "LITŲ "
                    Case "1"
                        r2 = "LITAS "
                    Case Else
                        r2 = "LITAI "
                End Select
        End Select

        strRez = m1 + m2 + t1 + t2 + r1 + r2 + " "

Pabaiga:

        Select Case intCase
            Case 0
                SumLT = UCase(Left(strRez, 1)) + LCase(Mid(strRez, 2))
            Case 1
                SumLT = UCase(strRez)
            Case 2
                SumLT = LCase(strRez)
        End Select
        If AddZero Then SumLT = SumLT + Right(strSuma, 2) + " ct"
    End Function
    Private Function TrysSkaitmenys(ByVal strNum3 As String) As String

        Dim s1 As String '* 1 'šimtai
        Dim d1 As String '* 1 'dešimtys
        Dim d2 As String '* 2 'dešimtys ir vienetai
        Dim v1 As String '* 1 'vienetai
        Dim s3 As String
        Dim d3 As String
        Dim v3 As String

        s1 = Left(strNum3, 1)
        d1 = Mid(strNum3, 2, 1)
        d2 = Mid(strNum3, 2, 2)
        v1 = Right(strNum3, 1)

        Select Case s1
            Case "1"
                s3 = "VIENAS ŠIMTAS "
            Case "2"
                s3 = "DU ŠIMTAI "
            Case "3"
                s3 = "TRYS ŠIMTAI "
            Case "4"
                s3 = "KETURI ŠIMTAI "
            Case "5"
                s3 = "PENKI ŠIMTAI "
            Case "6"
                s3 = "ŠEŠI ŠIMTAI "
            Case "7"
                s3 = "SEPTYNI ŠIMTAI "
            Case "8"
                s3 = "AŠTUONI ŠIMTAI "
            Case "9"
                s3 = "DEVYNI ŠIMTAI "
        End Select
        Select Case d1
            Case "1"
                Select Case d2
                    Case "10"
                        d3 = "DEšIMT "
                    Case "11"
                        d3 = "VIENUOLIKA "
                    Case "12"
                        d3 = "DVYLIKA "
                    Case "13"
                        d3 = "TRYLIKA "
                    Case "14"
                        d3 = "KETURIOLIKA "
                    Case "15"
                        d3 = "PENKIOLIKA "
                    Case "16"
                        d3 = "ŠEŠIOLIKA "
                    Case "17"
                        d3 = "SEPTYNIOLIKA "
                    Case "18"
                        d3 = "AŠTUONIOLIKA "
                    Case "19"
                        d3 = "DEVYNIOLIKA "
                End Select
            Case "2"
                d3 = "DVIDEŠIMT "
            Case "3"
                d3 = "TRISDEŠIMT "
            Case "4"
                d3 = "KETURIASDEŠIMT "
            Case "5"
                d3 = "PENKIASDEŠIMT "
            Case "6"
                d3 = "ŠEŠIASDEŠIMT "
            Case "7"
                d3 = "SEPTYNIASDEŠIMT "
            Case "8"
                d3 = "AŠTUONIASDEŠIMT "
            Case "9"
                d3 = "DEVYNIASDEŠIMT "
        End Select
        If d1 <> "1" Then
            Select Case v1
                Case "1"
                    v3 = "VIENAS "
                Case "2"
                    v3 = "DU "
                Case "3"
                    v3 = "TRYS "
                Case "4"
                    v3 = "KETURI "
                Case "5"
                    v3 = "PENKI "
                Case "6"
                    v3 = "ŠEŠI "
                Case "7"
                    v3 = "SEPTYNI "
                Case "8"
                    v3 = "AŠTUONI "
                Case "9"
                    v3 = "DEVYNI "
            End Select
        End If
        TrysSkaitmenys = s3 + d3 + v3
    End Function

    Dim nums() As String = {"", "One", "Two", "Three", "Four", "Five", "Six", _
        "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", _
        "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen"}
    Dim tens() As String = {"", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", _
        "Seventy", "Eighty", "Ninty"}

    ''' <summary>
    ''' Returns number in english.
    ''' </summary>
    ''' <param name="Number">Number to express in words</param>
    ''' <param name="Level">If level > 0 - zero is returned as empty string, else - as "Zero"</param>
    ''' <param name="CurrencyName">Currency name to use.</param>
    Public Function WriteNumberEN(ByVal Number As Double, Optional ByVal Level As Long = 0, _
        Optional ByVal CurrencyName As String = "") As String

        Dim FloatingPointPart As String = CInt(CRound(Number - Math.Floor(Number), 2) * 100).ToString
        Number = Math.Floor(Number)

        If (Level = 0) And (Number = 0) Then Return "Zero " & CurrencyName & " " _
            & FloatingPointPart & " ct."
        If (Level > 0) And (Number = 0) Then
            If CInt(FloatingPointPart) > 0 Then
                Return "Zero " & CurrencyName & " " & FloatingPointPart & " ct."
            Else
                Return ""
            End If
        End If

        Return WriteNumberENT(Number) & " " & CurrencyName & " " & FloatingPointPart & " ct."

    End Function
    Private Function WriteNumberENT(ByVal Number As Long, Optional ByVal Level As Long = 0) As String

        If Number < 0 Then Return "Minus " & WriteNumberENT(-Number)

        Dim result As String = ""

        Select Case Number
            Case Is < 20 : Return nums(Number) & " "
            Case 20 To 99 : Return tens(Number \ 10) & " " & WriteNumberENT(Number Mod 10, Level + 1)
            Case 100 To 999 : Return nums(Number \ 100) & " Hundred " & IIf(((Number Mod 1000) = 0), "and ", "") & WriteNumberENT(Number Mod 100, Level + 1)
            Case 1000 To 999999 : Return WriteNumberENT(Number \ 1000, Level + 1) & "Thousand " & IIf(Number Mod 1000 = 0, "", " ") & WriteNumberENT(Number Mod 1000, Level + 1)
            Case 10 ^ 6 To 10 ^ 12 - 1 : Return WriteNumberENT(Number \ 10 ^ 6, Level + 1) & "Million " & IIf(Number Mod 10 ^ 6 = 0, "", " ") & WriteNumberENT(Number Mod 10 ^ 6, Level + 1)
            Case Is >= 10 ^ 12 : Return WriteNumberENT(Number \ 10 ^ 12, Level + 1) & "Billion " & IIf(Number Mod 10 ^ 12 = 0, "", " ") & WriteNumberENT(Number Mod 10 ^ 12, Level + 1)
        End Select

    End Function

#End Region

    ''' <summary>
    ''' Returns all common information about current company and it's settings.
    ''' </summary>
    Public Function GetCurrentCompany() As ApskaitaObjects.Settings.CompanyInfo
        If Not IsLoggedInDB() Then _
            Throw New Exception("Klaida. Vartotojas neprisijungęs prie jokios įmonės.")
        If Not ApplicationContext.GlobalContext.Contains(KeyCompanyInfo) _
            OrElse Not TypeOf ApplicationContext.GlobalContext.Item(KeyCompanyInfo) _
            Is ApskaitaObjects.Settings.CompanyInfo Then Throw New Exception("Klaida. Nerasti bendri įmonės duomenys.")

        Return DirectCast(ApplicationContext.GlobalContext.Item(KeyCompanyInfo), _
            ApskaitaObjects.Settings.CompanyInfo)

    End Function

    ''' <summary>
    ''' Returns TRUE if the current user is in the role.
    ''' </summary>
    Public Function IsInRole(ByVal role As String) As Boolean
        Return ApplicationContext.User.IsInRole(role)
    End Function


    ''' <summary>
    ''' Gets a rounded value of d using Asymmetric Arithmetic Rounding algorithm
    ''' </summary>
    Public Function CRound(ByVal d As Double, ByVal r As Integer) As Double
        Dim i As Long = CLng(Math.Floor(d * Math.Pow(10, r)))
        If i + 0.5 > CType(d * Math.Pow(10, r), Decimal) Then
            Return i / Math.Pow(10, r)
        Else
            Return (i + 1) / Math.Pow(10, r)
        End If
    End Function
    Public Function CRound(ByVal d As Double) As Double
        Return CRound(d, 2)
    End Function


    Public Function ByteArrayToImage(ByVal source As Byte()) As System.Drawing.Image

        If source Is Nothing OrElse source.Length < 10 Then Return Nothing

        Dim result As System.Drawing.Image = Nothing

        Using MS As New IO.MemoryStream(source)
            Try
                result = System.Drawing.Image.FromStream(MS)
            Catch ex As Exception
            End Try
        End Using

        Return result

    End Function

    Public Function ImageToByteArray(ByVal source As System.Drawing.Image) As Byte()

        If source Is Nothing Then Return Nothing

        Dim result As Byte() = Nothing

        Dim ImageToSave As System.Drawing.Bitmap = New System.Drawing.Bitmap( _
            source.Width, source.Height, source.PixelFormat)
        Using gr As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(ImageToSave)
            gr.DrawImage(source, New System.Drawing.PointF(0, 0))
        End Using

        Using ms As New IO.MemoryStream
            Try
                ImageToSave.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                result = ms.ToArray
            Catch ex As Exception
            End Try
        End Using

        ImageToSave.Dispose()
        GC.Collect()

        Return result

    End Function


    Public Function GetAllBrokenRulesForList(ByVal List As Csla.Core.IExtendedBindingList) As String

        If List.Count < 1 Then Return ""

        If Not TypeOf List.Item(0) Is IGetErrorForListItem Then Throw New NotImplementedException( _
            "Klaida. Tipas '" & List.Item(0).GetType.FullName & "' neimplementuoja " _
            & "interfeiso IGetErrorForListItem.")

        Dim result As String = ""

        Dim ES As String
        For Each item As IGetErrorForListItem In List
            ES = item.GetErrorString
            result = AddWithNewLine(result, ES, False)
        Next

        Return result
    End Function

    Public Function GetAllWarningsForList(ByVal List As Csla.Core.IExtendedBindingList) As String

        If List.Count < 1 Then Return ""

        If Not TypeOf List.Item(0) Is IGetErrorForListItem Then Throw New NotImplementedException( _
            "Klaida. Tipas '" & List.Item(0).GetType.FullName & "' neimplementuoja " _
            & "interfeiso IGetErrorForListItem.")

        Dim result As String = ""

        Dim ES As String
        For Each item As IGetErrorForListItem In List
            ES = item.GetWarningString
            result = AddWithNewLine(result, ES, False)
        Next

        Return result
    End Function


    Public Function CurrenciesEquals(ByVal Currency1 As String, ByVal Currency2 As String) As Boolean

        If Currency1 Is Nothing OrElse String.IsNullOrEmpty(Currency1.Trim) Then _
            Currency1 = GetCurrentCompany.BaseCurrency
        If Currency2 Is Nothing OrElse String.IsNullOrEmpty(Currency2.Trim) Then _
            Currency2 = GetCurrentCompany.BaseCurrency

        Return (Currency1.Trim.ToUpper = Currency2.Trim.ToUpper)

    End Function

    Public Function GetCurrencySafe(ByVal currency As String) As String
        If currency Is Nothing OrElse String.IsNullOrEmpty(currency.Trim) Then _
            currency = GetCurrentCompany.BaseCurrency
        Return currency.Trim.ToUpper
    End Function

    Public Function ConvertCurrency(ByVal Amount As Double, ByVal OriginalCurrency As String, _
        ByVal OriginalCurrencyRate As Double, ByVal Currency As String, ByVal CurrencyRate As Double, _
        Optional ByVal AmountSignificantDigits As Integer = 2, _
        Optional ByVal CurrencyRateSignificantDigits As Integer = 6, _
        Optional ByVal DefaultAmount As Double = 0) As Double

        If CRound(Amount, AmountSignificantDigits) = 0 Then Return 0
        If CurrenciesEquals(OriginalCurrency, Currency) Then Return CRound(Amount, AmountSignificantDigits)

        If CurrenciesEquals(OriginalCurrency, GetCurrentCompany.BaseCurrency) Then OriginalCurrencyRate = 1
        If CurrenciesEquals(Currency, GetCurrentCompany.BaseCurrency) Then CurrencyRate = 1

        OriginalCurrencyRate = CRound(OriginalCurrencyRate, CurrencyRateSignificantDigits)
        CurrencyRate = CRound(CurrencyRate, CurrencyRateSignificantDigits)

        If Not CRound(CurrencyRate, CurrencyRateSignificantDigits) > 0 Then _
            Return CRound(DefaultAmount, AmountSignificantDigits)

        Return CRound(CRound(Amount * OriginalCurrencyRate, AmountSignificantDigits) _
            / CurrencyRate, AmountSignificantDigits)

    End Function

#Region " Language methods "

    Private _LanguageDictionary As Dictionary(Of String, String) = Nothing
    Public ReadOnly Property LanguageDictionary() As Dictionary(Of String, String)
        Get
            If _LanguageDictionary Is Nothing Then FetchLanguageDictionary()
            Return _LanguageDictionary
        End Get
    End Property
    Private Sub FetchLanguageDictionary()
        _LanguageDictionary = New Dictionary(Of String, String)
        For Each s As String In My.Resources.LanguageCodes.Split(New String() {vbCrLf}, _
            StringSplitOptions.RemoveEmptyEntries)
            _LanguageDictionary.Add(GetElement(s, 0).Trim.ToUpper, GetElement(s, 1).Trim.ToLower)
        Next
    End Sub

    Public Function GetLanguageName(ByVal LanguageCode As String, _
        Optional ByVal ThrowOnUnknownLanguage As Boolean = True) As String
        If String.IsNullOrEmpty(LanguageCode.Trim) Then Return ""
        If LanguageDictionary.ContainsKey(LanguageCode.Trim.ToUpper) Then _
            Return LanguageDictionary.Item(LanguageCode.Trim.ToUpper)
        If ThrowOnUnknownLanguage Then Throw New Exception( _
            "Klaida. Kalba, kurios kodas yra '" & LanguageCode & "', nežinoma.")
        Return ""
    End Function

    Public Function GetLanguageCode(ByVal LanguageName As String, _
        Optional ByVal ThrowOnUnknownLanguage As Boolean = True) As String
        If String.IsNullOrEmpty(LanguageName.Trim) Then Return ""
        If LanguageDictionary.ContainsValue(LanguageName.Trim.ToLower) Then
            For Each d As KeyValuePair(Of String, String) In _LanguageDictionary
                If d.Value = LanguageName.Trim.ToLower Then Return d.Key
            Next
        End If
        If ThrowOnUnknownLanguage Then Throw New Exception( _
            "Klaida. Kalba, kurios pavadinimas yra '" & LanguageName & "', nežinoma.")
        Return ""
    End Function

    Public Function GetLanguageList() As List(Of String)
        Dim result As New List(Of String)
        For Each d As KeyValuePair(Of String, String) In LanguageDictionary
            result.Add(d.Value)
        Next
        result.Sort()
        result.Insert(0, "")
        Return result
    End Function

#End Region

#Region " Enum conversion methods "

    Private CommonEnumMap As List(Of EnumMapItem) = Nothing

    Private Structure EnumMapItem
        Public EnumValue As [Enum]
        Public HumanReadableString As String
        Public DatabaseCode As Integer
        Public DatabaseStringCode As String
        Public Sub New(ByVal nEnumValue As Object, ByVal nHumanReadableString As String, _
            ByVal nDatabaseCode As Integer, Optional ByVal nDatabaseStringCode As String = "")
            EnumValue = nEnumValue
            HumanReadableString = nHumanReadableString
            DatabaseCode = nDatabaseCode
            DatabaseStringCode = nDatabaseStringCode
        End Sub
        Public Function IsMatch(ByVal ObjType As Type) As Boolean
            Return ObjType Is EnumValue.GetType
        End Function
        Public Function IsMatch(ByVal Obj As [Enum]) As Boolean
            Return Obj.GetType Is EnumValue.GetType AndAlso _
                 System.Enum.GetName(Obj.GetType, Obj) = _
                 System.Enum.GetName(Obj.GetType, EnumValue)
        End Function
        Public Function IsMatch(ByVal ObjType As Type, ByVal DbCode As Integer) As Boolean
            Return ObjType Is EnumValue.GetType AndAlso DbCode = DatabaseCode
        End Function
        Public Function IsMatch(ByVal ObjType As Type, ByVal DbStringCode As String, ByVal NullValue As Object) As Boolean
            Return ObjType Is EnumValue.GetType AndAlso DbStringCode.Trim.ToLower = DatabaseStringCode.Trim.ToLower
        End Function
        Public Function IsMatch(ByVal ObjType As Type, _
            ByVal HumanReadableValue As String) As Boolean
            Return ObjType Is EnumValue.GetType AndAlso _
                HumanReadableValue.Trim.ToLower = HumanReadableString.Trim.ToLower
        End Function
    End Structure

    Private Sub InitializeCommonEnumMap()

        CommonEnumMap = New List(Of EnumMapItem)

        '*** OPERATION CHRONOLOGY TYPE ***

        CommonEnumMap.Add(New EnumMapItem(OperationChronologyType.Overall, _
            "Iš visų operacijų", 0))
        CommonEnumMap.Add(New EnumMapItem(OperationChronologyType.LastBefore, _
            "Paskutinė prieš", 1))
        CommonEnumMap.Add(New EnumMapItem(OperationChronologyType.FirstAfter, _
            "Pirma po", 2))

        '*** FINANCIAL STATEMENT ITEM TYPE ***

        CommonEnumMap.Add(New EnumMapItem(General.FinancialStatementItemType.StatementOfFinancialPosition, _
            "Balanso ataskaitos eilutė", 0))
        CommonEnumMap.Add(New EnumMapItem(General.FinancialStatementItemType.StatementOfComprehensiveIncome, _
            "Pelno (nuostolio) ataskaitos eilutė", 1))
        CommonEnumMap.Add(New EnumMapItem(General.FinancialStatementItemType.HeaderStatementOfFinancialPosition, _
            "Balanso ataskaitos antraštės eilutė", 2))
        CommonEnumMap.Add(New EnumMapItem(General.FinancialStatementItemType.HeaderStatementOfComprehensiveIncome, _
            "Pelno (nuostolio) ataskaitos antraštės eilutė", 3))
        CommonEnumMap.Add(New EnumMapItem(General.FinancialStatementItemType.HeaderGeneral, _
            "Finansinių ataskaitų rinkinio antraštės eilutė", 4))

        '*** TAX TARIF TYPE ***

        CommonEnumMap.Add(New EnumMapItem(TaxTarifType.GPM, _
            "GPM", 0, "GPM"))
        CommonEnumMap.Add(New EnumMapItem(TaxTarifType.PSDForCompany, _
            "PSD įmonei", 1, "PSDP"))
        CommonEnumMap.Add(New EnumMapItem(TaxTarifType.PSDForPerson, _
            "PSD išskaič.", 2, "PSDI"))
        CommonEnumMap.Add(New EnumMapItem(TaxTarifType.SodraForCompany, _
            "SODRA įmonei", 3, "SODRAP"))
        CommonEnumMap.Add(New EnumMapItem(TaxTarifType.SodraForPerson, _
            "SODRA išskaič.", 4, "SODRAI"))
        CommonEnumMap.Add(New EnumMapItem(TaxTarifType.Vat, _
            "PVM", 5, "PVM"))

        '*** RATE TYPE ***

        CommonEnumMap.Add(New EnumMapItem(RateType.GpmWage, _
            "GPM darbo santykių", 0))
        CommonEnumMap.Add(New EnumMapItem(RateType.GuaranteeFund, _
            "Garantinis fondas", 1))
        CommonEnumMap.Add(New EnumMapItem(RateType.PsdEmployee, _
            "PSD darbuotojui", 2))
        CommonEnumMap.Add(New EnumMapItem(RateType.PsdEmployer, _
            "PSD darbdaviui", 3))
        CommonEnumMap.Add(New EnumMapItem(RateType.SodraEmployee, _
            "SODRA darbuotojui", 4))
        CommonEnumMap.Add(New EnumMapItem(RateType.SodraEmployer, _
            "SODRA darbdaviui", 5))
        CommonEnumMap.Add(New EnumMapItem(RateType.Vat, _
            "PVM", 6))
        CommonEnumMap.Add(New EnumMapItem(RateType.WageRateDeviations, _
            "Darbo užm. nenorm. sąlyg.", 7))
        CommonEnumMap.Add(New EnumMapItem(RateType.WageRateNight, _
            "Darbo užm. naktinis", 8))
        CommonEnumMap.Add(New EnumMapItem(RateType.WageRateOvertime, _
            "Darbo užm. viršv.", 9))
        CommonEnumMap.Add(New EnumMapItem(RateType.WageRatePublicHolidays, _
            "Darbo užm. švenčių", 10))
        CommonEnumMap.Add(New EnumMapItem(RateType.WageRateRestTime, _
            "Darbo užm. poilsio", 11))
        CommonEnumMap.Add(New EnumMapItem(RateType.WageRateSickLeave, _
            "Darbo užm. nedarbing.", 12))

        '*** DEFAULT ACCOUNT TYPE ***

        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.Bank, _
            "Banko", 0, "BK"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.Buyers, _
            "Pirkėjų", 1, "PR"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.Suppliers, _
            "Tiekėjų", 2, "TK"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.Till, _
            "Kasos", 3, "KS"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.VatPayable, _
            "Mokėtinas PVM", 4, "PV"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.VatReceivable, _
            "Gautinas PVM", 5, "PG"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.WageGpmPayable, _
            "Mokėtinas GPM darbo sant.", 6, "GP"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.WageGuaranteeFundPayable, _
            "Mokėtinos garant. įmokos", 7, "GR"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.WageImprestPayable, _
            "Mokėtini darbo užm. avansai", 8, "DA"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.WagePayable, _
            "Mokėtinas darbo užm.", 9, "DU"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.WagePsdPayable, _
            "Mokėtinas PSD darbo sant.", 10, "SS"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.WageSodraPayable, _
            "Mokėtina SODRA darbo sant.", 11, "SD"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.WageWithdraw, _
            "Išskaitų iš darbo užm.", 12, "IS"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.WagePsdPayableToVMI, _
            "Mokėtinas PSD darbo sant. VMI", 13, "SV"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.ClosingSummary, _
            "Uždarymo suvestinė", 14, "SU"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.CurrentProfit, _
            "Pelnas (nuostolis) einamasis", 15, "PL"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.FormerProfit, _
            "Pelnas (nuostolis) ankstesnis", 16, "PA"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.OtherGpmPayable, _
            "Mokėtinas GPM kitas", 17, "OG"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.OtherPsdPayable, _
            "Mokėtinas PSD kitas", 18, "OP"))
        CommonEnumMap.Add(New EnumMapItem(General.DefaultAccountType.OtherSodraPayable, _
            "Mokėtina SODRA kita", 19, "OS"))

        '*** GOODS OPERATION TYPE ***

        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsOperationType.Acquisition, _
            "Įsigijimas", 1))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsOperationType.Transfer, _
            "Perleidimas", 2))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsOperationType.Discard, _
            "Nurašymas", 3))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsOperationType.Inventorization, _
            "Inventorizacija", 4))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsOperationType.ConsignmentDiscount, _
            "Gauta Nuolaida", 5))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsOperationType.ConsignmentAdditionalCosts, _
            "Papildomi Kaštai", 6))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsOperationType.PriceCut, _
            "Nukainojimas", 7))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsOperationType.AccountSalesNetCostsChange, _
            "Pardavimo Savik. Sąsk. Pakeitimas", 9))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsOperationType.AccountPurchasesChange, _
            "Pardavimo Sąsk. Pakeitimas", 10))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsOperationType.AccountDiscountsChange, _
            "Nuolaidų Sąsk. Pakeitimas", 11))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsOperationType.AccountValueReductionChange, _
            "Nukainojimo Sąsk. Pakeitimas", 12))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsOperationType.ValuationMethodChange, _
            "Vertinimo Metodo Pakeitimas", 13))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsOperationType.TransferOfBalance, _
            "Likučių perkėlimas", 14))

        '*** GOODS COMPLEX OPERATION TYPE ***

        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsComplexOperationType.InternalTransfer, _
            "Vidinis judėjimas", 1))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsComplexOperationType.Production, _
            "Gamyba", 2))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsComplexOperationType.Inventorization, _
            "Inventorizacija", 3))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsComplexOperationType.BulkDiscard, _
            "Masinis nurašymas", 4))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsComplexOperationType.BulkPriceCut, _
            "Masinis nukainojimas", 5))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsComplexOperationType.TransferOfBalance, _
            "Likučių perkėlimas", 6))

        '*** PRODUCTION COMPONENT TYPE ***

        CommonEnumMap.Add(New EnumMapItem(Goods.ProductionComponentType.Component, _
            "Komplektuojančios prekės/žaliavos", 0, "a"))
        CommonEnumMap.Add(New EnumMapItem(Goods.ProductionComponentType.Costs, _
            "Gamybos savikainos sąnaudos", 1, "s"))

        '*** DOCUMENT SERIAL TYPE ***

        CommonEnumMap.Add(New EnumMapItem(Settings.DocumentSerialType.Invoice, _
            "Sąskaita - faktūra", 0, "sąskaita - faktūra"))
        CommonEnumMap.Add(New EnumMapItem(Settings.DocumentSerialType.LabourContract, _
            "Darbo sutartis", 1, "darbo sutartis"))
        CommonEnumMap.Add(New EnumMapItem(Settings.DocumentSerialType.TillIncomeOrder, _
            "Kasos pajamų orderis", 2, "kasos pajamų orderis"))
        CommonEnumMap.Add(New EnumMapItem(Settings.DocumentSerialType.TillSpendingsOrder, _
            "Kasos išlaidų orderis", 3, "kasos išlaidų orderis"))

        '*** DOCUMENT TYPE ***

        CommonEnumMap.Add(New EnumMapItem(DocumentType.ImprestSheet, _
            "Avanso žiniaraštis", 0, "av"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.WageSheet, _
            "Darbo užmokesčio žiniaraštis", 1, "du"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.TillSpendingOrder, _
            "Kasos išlaidų orderis", 2, "kio"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.TillIncomeOrder, _
            "Kasos pajamų orderis", 3, "kpo"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.InvoiceMade, _
            "Išrašyta sąskaita - faktūra", 4, "sf"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.InvoiceReceived, _
            "Gauta sąskaita - faktūra", 5, "sg"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.GoodsInternalTransfer, _
            "Prekių vidinis judėjimas", 6, "a"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.Amortization, _
            "Amortizacija", 7, "amo"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.BankOperation, _
            "Banko operacija", 8, "b"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.GoodsProduction, _
            "Gamyba", 9, "g"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.LongTermAssetDiscard, _
            "Ilgalaikio turto nurašymas", 10, "t"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.GoodsWriteOff, _
            "Atsargų nurašymas", 11, "tn"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.ClosingEntries, _
            "5/6 klasių uždarymas", 12, "uz"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.GoodsRevalue, _
            "Atsargų nukainojimas (atstatymas)", 13, "v"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.TransferOfBalance, _
            "Likučių perkėlimas", 14, "lik"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.AdvanceReport, _
            "Avanso apyskaita", 15, "ap"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.LongTermAssetAccountChange, _
            "Ilgalaikio turto apsk. sąsk. pakeitimas", 16, "tsp"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.Offset, "Užskaita", 17, "sk"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.None, "Nėra", 18, ""))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.GoodsInventorization, _
            "Atsargų inventorizacija", 19, "gi"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.GoodsAccountChange, _
            "Atsargų apskaitos sąsk. pakeitimas", 20, "ga"))
        CommonEnumMap.Add(New EnumMapItem(DocumentType.AccumulatedCosts, _
            "Sukauptos sąnaudos", 21, "ac"))

        '*** GOODS ACCOUNTING METHOD ***

        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsAccountingMethod.Persistent, _
            "Nuolat apskaitomos", 0))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsAccountingMethod.Periodic, _
            "Periodiškai apskaitomos", 1))

        '*** GOODS VALUATION METHOD ***

        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsValuationMethod.FIFO, _
            "FIFO", 0))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsValuationMethod.LIFO, _
            "LIFO", 1))
        CommonEnumMap.Add(New EnumMapItem(Goods.GoodsValuationMethod.Average, _
            "Vidurkių", 2))

        '*** BOOK ENTRY TYPE ***

        CommonEnumMap.Add(New EnumMapItem(BookEntryType.Debetas, _
            "Debetas", 0, "Debetas"))
        CommonEnumMap.Add(New EnumMapItem(BookEntryType.Kreditas, _
            "Kreditas", 1, "Kreditas"))

        '*** WAGE TYPE ***

        CommonEnumMap.Add(New EnumMapItem(Workers.WageType.Position, _
            "Pareiginis", 0, "p"))
        CommonEnumMap.Add(New EnumMapItem(Workers.WageType.Hourly, _
            "Valandinis", 1, "v"))

        '*** WORKER STATUS TYPE ***

        CommonEnumMap.Add(New EnumMapItem(Workers.WorkerStatusType.Employed, _
            "Įsidarbino", 0, "d"))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkerStatusType.ExtraPay, _
            "Priedas", 1, "i"))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkerStatusType.Fired, _
            "Atleistas", 2, "n"))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkerStatusType.Holiday, _
            "Kasmetinės atostogos", 3, "a"))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkerStatusType.HolidayCorrection, _
            "Atostogų korekcija", 4, "o"))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkerStatusType.NPD, _
            "Taikytinas NPD", 5, "p"))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkerStatusType.PNPD, _
            "Taikytinas PNPD", 6, "r"))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkerStatusType.Wage, _
            "Darbo užmokestis", 7, "u"))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkerStatusType.WorkLoad, _
            "Darbo krūvis (etatai)", 8, "k"))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkerStatusType.Position, _
            "Pareigos", 9, "f"))

        '*** BONUS TYPE ***

        CommonEnumMap.Add(New EnumMapItem(Workers.BonusType.k, _
            "Ketvirtinė", 0, "k"))
        CommonEnumMap.Add(New EnumMapItem(Workers.BonusType.m, _
            "Metinė", 1, "m"))

        '*** LONG TERM ASSET OPERATION TYPE ***

        CommonEnumMap.Add(New EnumMapItem(Assets.LtaOperationType.AccountChange, _
            "Apsk. sąsk. pakeitimas", 0, "aac"))
        CommonEnumMap.Add(New EnumMapItem(Assets.LtaOperationType.AcquisitionValueIncrease, _
            "Įsig. vertės padid.", 1, "avi"))
        CommonEnumMap.Add(New EnumMapItem(Assets.LtaOperationType.Amortization, _
            "Skaičiuoti amort.", 2, "amo"))
        CommonEnumMap.Add(New EnumMapItem(Assets.LtaOperationType.AmortizationPeriod, _
            "Naujas amort. laik.", 3, "alk"))
        CommonEnumMap.Add(New EnumMapItem(Assets.LtaOperationType.Discard, _
            "Nurašyti", 4, "nur"))
        CommonEnumMap.Add(New EnumMapItem(Assets.LtaOperationType.Transfer, _
            "Perleisti", 5, "per"))
        CommonEnumMap.Add(New EnumMapItem(Assets.LtaOperationType.UsingStart, _
            "Pradėti naudoti", 7, "nau"))
        CommonEnumMap.Add(New EnumMapItem(Assets.LtaOperationType.UsingEnd, _
            "Baigti naudoti", 6, "nau"))
        CommonEnumMap.Add(New EnumMapItem(Assets.LtaOperationType.ValueChange, _
            "Vertės pakeitimas", 8, "avd"))

        '*** LONG TERM ASSET ACCOUNT CHANGE TYPE ***

        CommonEnumMap.Add(New EnumMapItem(Assets.LtaAccountChangeType.AcquisitionAccount, _
            "Savikainos", 0, "aqs"))
        CommonEnumMap.Add(New EnumMapItem(Assets.LtaAccountChangeType.AmortizationAccount, _
            "Amortizacijos (kontrar.)", 1, "amr"))
        CommonEnumMap.Add(New EnumMapItem(Assets.LtaAccountChangeType.ValueDecreaseAccount, _
            "Vertės sumažėjimo", 2, "vld"))
        CommonEnumMap.Add(New EnumMapItem(Assets.LtaAccountChangeType.ValueIncreaseAccount, _
            "Vertės padidėjimo", 3, "vli"))
        CommonEnumMap.Add(New EnumMapItem(Assets.LtaAccountChangeType.ValueIncreaseAmortizationAccount, _
            "Vertės padidėjimo amort.", 4, "vam"))

        '*** CASH ACCOUNT TYPE ***

        CommonEnumMap.Add(New EnumMapItem(Documents.CashAccountType.BankAccount, _
            "Banko sąskaita", 0))
        CommonEnumMap.Add(New EnumMapItem(Documents.CashAccountType.PseudoBankAccount, _
            "Pseudo banko sąskaita", 1))
        CommonEnumMap.Add(New EnumMapItem(Documents.CashAccountType.Till, _
            "Kasa", 2))

        '*** INVOICE INFO TYPE ***

        CommonEnumMap.Add(New EnumMapItem(ActiveReports.InvoiceInfoType.InvoiceMade, _
            "Išrašytų sąskaitų faktūrų registras", 0))
        CommonEnumMap.Add(New EnumMapItem(ActiveReports.InvoiceInfoType.InvoiceReceived, _
            "Gautų sąskaitų faktūrų registras", 1))

        '*** TRADED ITEM TYPE ***

        CommonEnumMap.Add(New EnumMapItem(Documents.TradedItemType.Purchases, _
            "Perkamos", 0))
        CommonEnumMap.Add(New EnumMapItem(Documents.TradedItemType.Sales, _
            "Parduodamos", 1))
        CommonEnumMap.Add(New EnumMapItem(Documents.TradedItemType.All, _
            "Perkamos ir parduodamos", 2))

        '*** DECLARATION TYPE ***

        CommonEnumMap.Add(New EnumMapItem(DeclarationType.FR0572, "FR0572 v.2", 0))
        CommonEnumMap.Add(New EnumMapItem(DeclarationType.FR0572_3, "FR0572 v.3", 1))
        CommonEnumMap.Add(New EnumMapItem(DeclarationType.FR0573, "FR0573 v.2", 2))
        CommonEnumMap.Add(New EnumMapItem(DeclarationType.FR0573_3, "FR0573 v.3", 3))
        CommonEnumMap.Add(New EnumMapItem(DeclarationType.FR0671_1, "FR0671 v.1", 4))
        CommonEnumMap.Add(New EnumMapItem(DeclarationType.FR0671_2, "FR0671 v.2", 5))
        CommonEnumMap.Add(New EnumMapItem(DeclarationType.FR0672_1, "FR0672 v.1", 6))
        CommonEnumMap.Add(New EnumMapItem(DeclarationType.FR0672_2, "FR0672 v.2", 7))
        CommonEnumMap.Add(New EnumMapItem(DeclarationType.SAM_1, "SAM v.1", 8))
        CommonEnumMap.Add(New EnumMapItem(DeclarationType.SAM_2, "SAM v.2", 9))
        CommonEnumMap.Add(New EnumMapItem(DeclarationType.SAM_Aut_1, "SAM v.1 autor.", 10))
        CommonEnumMap.Add(New EnumMapItem(DeclarationType.SD13_1, "SD13 v.1", 11))
        CommonEnumMap.Add(New EnumMapItem(DeclarationType.SD13_2, "SD13 v.2", 12))
        CommonEnumMap.Add(New EnumMapItem(DeclarationType.FR0572_4, "FR0572 v.4", 13))
        CommonEnumMap.Add(New EnumMapItem(DeclarationType.SAM_3, "SAM v.3", 14))

        '*** INVOICE ATTACHED OBJECT TYPE ***

        CommonEnumMap.Add(New EnumMapItem(Documents.InvoiceAttachedObjectType.GoodsTransfer, _
            "Prekių pardavimas", 1))
        CommonEnumMap.Add(New EnumMapItem(Documents.InvoiceAttachedObjectType.Service, _
            "Paslauga", 2))
        CommonEnumMap.Add(New EnumMapItem(Documents.InvoiceAttachedObjectType.LongTermAssetSale, _
            "Ilgalaikio turto pardavimas", 3))
        CommonEnumMap.Add(New EnumMapItem(Documents.InvoiceAttachedObjectType.LongTermAssetPurchase, _
            "Ilgalaikio turto įgijimas", 4))
        CommonEnumMap.Add(New EnumMapItem(Documents.InvoiceAttachedObjectType.GoodsAcquisition, _
            "Prekių įsigijimas", 5))
        CommonEnumMap.Add(New EnumMapItem(Documents.InvoiceAttachedObjectType.LongTermAssetAcquisitionValueChange, _
            "Ilgalaikio turto įsig. savik. pokytis", 6))
        CommonEnumMap.Add(New EnumMapItem(Documents.InvoiceAttachedObjectType.GoodsConsignmentDiscount, _
            "Gauta prekių nuolaida", 7))
        CommonEnumMap.Add(New EnumMapItem(Documents.InvoiceAttachedObjectType.GoodsConsignmentAdditionalCosts, _
            "Prekių savikainos padidinimas", 8))

        '*** INVOICE TYPE ***

        CommonEnumMap.Add(New EnumMapItem(Documents.InvoiceType.Normal, "Normali", 0))
        CommonEnumMap.Add(New EnumMapItem(Documents.InvoiceType.Credit, "Kreditinė", 1))
        CommonEnumMap.Add(New EnumMapItem(Documents.InvoiceType.Debit, "Debetinė", 2))

        '*** WORK TIME TYPE ***

        CommonEnumMap.Add(New EnumMapItem(Workers.WorkTimeType.NightWork, "Darbas naktį", 0))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkTimeType.OtherExcluded, "Kitas neįskaitomas į darbo laiką", 1))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkTimeType.OtherIncluded, "Kitas įskaitomas į darbo laiką", 2))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkTimeType.OvertimeWork, "Viršvalandžiai", 3))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkTimeType.PublicHolidaysAndRestDayWork, "Darbas švenčių ir poilsio dienomis", 4))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkTimeType.Truancy, "Pravaikšta", 5))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkTimeType.UnusualWork, "Darbas ypatingomis sąlygomis", 6))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkTimeType.DownTime, "Prastova", 7))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkTimeType.SickDays, "Liga", 8))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkTimeType.AnnualHolidays, "Kasmetinės atostogos", 9))
        CommonEnumMap.Add(New EnumMapItem(Workers.WorkTimeType.OtherHolidays, "Kitos atostogos", 10))

        '*** INDIRECT RELATION TYPE ***

        CommonEnumMap.Add(New EnumMapItem(IndirectRelationType.PayoutToResident, _
            "Išmoka fiziniam asmeniui", 0))
        CommonEnumMap.Add(New EnumMapItem(IndirectRelationType.LongTermAssetsOperation, _
            "Operacija su ilgalaikiu turtu", 1))
        CommonEnumMap.Add(New EnumMapItem(IndirectRelationType.LongTermAssetsPurchase, _
            "Ilgalaikio turto įsigijimas", 2))
        CommonEnumMap.Add(New EnumMapItem(IndirectRelationType.GoodsOperation, _
            "Operacija su prekėmis", 3))

    End Sub

    Public Function ConvertEnumDatabaseCode(Of T)(ByVal DatabaseCode As Integer) As T

        If Not GetType(T).IsEnum Then Throw New ArgumentException( _
            "Klaida. Funkcija ApskaitaObjects.Utilities.ConvertEnumDatabaseCode " & _
            "gali konvertuoti tik enumeracijas, o nurodyto objekto tipas - " & _
            GetType(T).FullName & " .")

        If CommonEnumMap Is Nothing Then InitializeCommonEnumMap()

        For Each item As EnumMapItem In CommonEnumMap
            If item.IsMatch(GetType(T), DatabaseCode) Then Return _
                DirectCast(DirectCast(item.EnumValue, Object), T)
        Next

        Throw New Exception("Enumeracijos tipo " & GetType(T).FullName & _
            " vertė, duomenų bazėje pažymėta kodu " & DatabaseCode.ToString & ", nežinoma.")

    End Function

    Public Function ConvertEnumDatabaseCode(ByVal EnumValue As [Enum]) As Integer

        If CommonEnumMap Is Nothing Then InitializeCommonEnumMap()

        For Each item As EnumMapItem In CommonEnumMap
            If item.IsMatch(EnumValue) Then Return item.DatabaseCode
        Next

        Throw New Exception("Enumeracijos tipo " & EnumValue.ToString & _
            " kodas duomenų bazėje nežinomas.")

    End Function

    Public Function ConvertEnumDatabaseStringCode(Of T)(ByVal DatabaseStringCode As String) As T

        If Not GetType(T).IsEnum Then Throw New ArgumentException( _
            "Klaida. Funkcija ApskaitaObjects.Utilities.ConvertEnumDatabaseCode " & _
            "gali konvertuoti tik enumeracijas, o nurodyto objekto tipas - " & _
            GetType(T).FullName & " .")

        If CommonEnumMap Is Nothing Then InitializeCommonEnumMap()

        For Each item As EnumMapItem In CommonEnumMap
            If item.IsMatch(GetType(T), DatabaseStringCode, Nothing) Then _
                Return DirectCast(DirectCast(item.EnumValue, Object), T)
        Next

        Throw New Exception("Enumeracijos tipo " & GetType(T).ToString & _
            " vertė, duomenų bazėje pažymėta kodu " & DatabaseStringCode & ", nežinoma.")

    End Function

    Public Function ConvertEnumDatabaseStringCode(ByVal EnumValue As [Enum]) As String

        If CommonEnumMap Is Nothing Then InitializeCommonEnumMap()

        For Each item As EnumMapItem In CommonEnumMap
            If item.IsMatch(EnumValue) Then Return item.DatabaseStringCode
        Next

        Throw New Exception("Enumeracijos tipo " & EnumValue.ToString & _
            " kodas duomenų bazėje nežinomas.")

    End Function

    Public Function ConvertEnumHumanReadable(Of T)(ByVal HumanReadableString As String) As T

        If Not GetType(T).IsEnum Then Throw New ArgumentException( _
            "Klaida. Funkcija ApskaitaObjects.Utilities.ConvertEnumHumanReadable " & _
            "gali konvertuoti tik enumeracijas, o nurodyto objekto tipas - " & _
            GetType(T).ToString & " .")

        If CommonEnumMap Is Nothing Then InitializeCommonEnumMap()

        For Each item As EnumMapItem In CommonEnumMap
            If item.IsMatch(GetType(T), HumanReadableString) Then _
                Return DirectCast(DirectCast(item.EnumValue, Object), T)
        Next

        Throw New Exception("Enumeracijos tipo " & GetType(T).ToString & _
            " vertė, įvardinta kaip " & HumanReadableString.ToString & ", nežinoma.")

    End Function

    Public Function ConvertEnumHumanReadable(ByVal EnumValue As [Enum]) As String

        If CommonEnumMap Is Nothing Then InitializeCommonEnumMap()

        For Each item As EnumMapItem In CommonEnumMap
            If item.IsMatch(EnumValue) Then Return item.HumanReadableString
        Next

        Throw New Exception("Enumeracijos tipo " & EnumValue.ToString & _
            " pavadinimas ""žmonių kalba"" nežinomas.")

    End Function

    Public Function ConvertEnumDatabaseCodeToHumanReadable(Of T)(ByVal DatabaseCode As Integer) As String

        If CommonEnumMap Is Nothing Then InitializeCommonEnumMap()

        For Each item As EnumMapItem In CommonEnumMap
            If item.IsMatch(GetType(T), DatabaseCode) Then Return item.HumanReadableString
        Next

        Throw New Exception("Enumeracijos tipo " & GetType(T).ToString & _
            " vertė, duomenų bazėje pažymėta kodu " & DatabaseCode.ToString & ", nežinoma.")

    End Function

    Public Function GetEnumValuesHumanReadableList(ByVal EnumType As Type, _
        ByVal AddEmptyString As Boolean, ByVal ParamArray OnlySelectedValues As [Enum]()) As List(Of String)

        Dim result As New List(Of String)

        For Each v As [Enum] In [Enum].GetValues(EnumType)
            If OnlySelectedValues.Length < 1 OrElse Not Array.IndexOf(OnlySelectedValues, v) < 0 Then
                result.Add(ConvertEnumHumanReadable(v))
            End If
        Next

        result.Sort()
        If AddEmptyString Then result.Insert(0, "")

        Return result

    End Function

#End Region

End Module
