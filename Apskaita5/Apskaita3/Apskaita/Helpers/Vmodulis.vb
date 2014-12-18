Imports MsgBoxLT
Imports System.Globalization
Imports ApskaitaObjects

Module ValdymoModulis ' Ivairios bendro pobudzio proceduros

    Private Splash As System.Threading.Thread
    Private SplashForm As ProgressSplashScreen

#Region "***DARBAS SU STRINGAIS***"

    Public Function palyginimas(ByVal vienas As String, ByVal du As String) As Boolean
        'palygina su buhalteriniu saskaitu numerius
        'jei vienas daugiau uz du buhalterine prasme, tada TRUE
        Dim ik As Integer 'techninis
        Dim milgis As Integer 'maziausias saskaitos nr ilgis
        Dim rasta As Boolean 'techninis

        If Len(vienas) >= Len(du) Then 'nustato maziausia saskaitu nr ilgi
            milgis = Len(du)
        Else
            milgis = Len(vienas)
        End If

        rasta = False
        ik = 1
        While rasta = False 'kol neatradom rezultato
            If ik > milgis Then 'jei minimalaus ilgio ribose saskaitos identiskos
                If Len(vienas) > Len(du) Then 'tai subsaskaita mazesne uz saskaita
                    palyginimas = True
                Else
                    palyginimas = False
                End If
                rasta = True
            ElseIf CInt(du.Chars(ik - 1).ToString) > CInt(vienas.Chars(ik - 1).ToString) Then
                palyginimas = False 'jei antra auksciau pirmos
                rasta = True
            ElseIf CInt(vienas.Chars(ik - 1).ToString) > CInt(du.Chars(ik - 1).ToString) Then
                palyginimas = True 'jei pirma auksciau antros
                rasta = True
            Else 'jei dar vienodos, ziurim sekanti elementa
                ik = ik + 1
            End If
        End While

    End Function

    Public Function zodis(ByVal s As String, ByVal l As Integer) As String
        'iskirti zodi l is sakinio s, kurio zodziai gali buti atskirti ";" ar " "
        Dim i As Integer 'techninis
        Dim pertraukimas As Integer = 0 'kiek zodziu praejo
        Dim pavad As String = "" 'zodis
        For i = 1 To s.Length
            If s.Substring(i - 1, 1) = ";" Or s.Substring(i - 1, 1) = " " Then
                pertraukimas = pertraukimas + 1 'sekantis zodis
            Else
                If pertraukimas = l Then 'suzinom l-taji zodi
                    pavad = pavad & s.Substring(i - 1, 1)
                End If
            End If
        Next
        zodis = pavad
    End Function

    Public Sub Rusiuoti(ByRef datatbl As DataTable, ByVal col As Integer, _
                ByVal nuo As Integer, ByVal iki As Integer)
        'surusiuoja "datatbl" buhalteriskai pgl saskaitas
        'col - saskaitos column'as, nuo ir iki - pirmas ir paskutinis rusiuojamas column
        Dim darbinis As New DataTable 'techniniai
        Dim i, w, j As Integer

        For i = 1 To (iki - nuo + 1) 'sukuriam mirror datatable
            darbinis.Columns.Add()
        Next
        darbinis.Rows.Add()

        For w = 1 To datatbl.Rows.Count
            For i = w + 1 To datatbl.Rows.Count
                If palyginimas(datatbl.Rows(w - 1).Item(col).ToString, datatbl.Rows(i - 1).Item(col).ToString) = True Then
                    For j = nuo To iki
                        darbinis.Rows(0).Item(j - nuo) = datatbl.Rows(w - 1).Item(j)
                        datatbl.Rows(w - 1).Item(j) = datatbl.Rows(i - 1).Item(j)
                        datatbl.Rows(i - 1).Item(j) = darbinis.Rows(0).Item(j - nuo)
                    Next
                End If
            Next
        Next
    End Sub

    Public Function skaidyti(ByVal s As String, ByVal m As Integer, _
            ByRef p As String) As String
        If s.Length <= m Then
            p = ""
            skaidyti = s
            Exit Function
        End If
        Dim i As Integer = 0
        Dim z, sk As Integer
        Dim zod As String = "a"
        While zod <> ""
            zod = zodis(s, i)
            i = i + 1
        End While
        z = i - 1
        For i = 1 To z
            If i = 1 Then
                zod = zod & zodis(s, z - i)
            Else
                zod = zod & " " & zodis(s, z - i)
            End If
            If zod.Length > m Then
                sk = z - i
                Exit For
            End If
        Next
        zod = ""
        For i = 0 To sk
            If i = 0 Then
                zod = zod + zodis(s, i)
            Else
                zod = zod + " " + zodis(s, i)
            End If
        Next
        p = zod
        zod = ""
        For i = sk + 2 To z
            If i = sk + 2 Then
                zod = zod + zodis(s, i - 1)
            Else
                zod = zod + " " + zodis(s, i - 1)
            End If
        Next
        skaidyti = zod
    End Function

    Public Function skaidyti2(ByVal s As String, ByVal ilg As Integer, ByRef eil2 As String) As String
        Dim zodziai As New List(Of String)
        Dim i As Integer
        Dim t As String = ""
        Dim t2 As String = ""
        For i = 1 To s.Length
            If s.Substring(i - 1, 1) = " " Or i = s.Length Then
                If i = s.Length Then t = t & s.Substring(i - 1, 1)
                zodziai.Add(t)
                t = ""
            Else
                t = t & s.Substring(i - 1, 1)
            End If
        Next
        Dim sekanti As Boolean = False
        For i = 1 To zodziai.Count
            If (t & zodziai.Item(i - 1)).Length > ilg Or sekanti Then
                If Not sekanti Then
                    t2 = zodziai.Item(i - 1)
                ElseIf (t2 & zodziai.Item(i - 1)).Length > ilg Then
                    t2 = t2 & " (...)"
                    Exit For
                Else
                    t2 = t2 & " " & zodziai.Item(i - 1)
                End If
                sekanti = True
            Else
                If i = 1 Then
                    t = zodziai.Item(i - 1)
                Else
                    t = t & " " & zodziai.Item(i - 1)
                End If
            End If
        Next
        eil2 = t2
        skaidyti2 = t
    End Function

    Public Function ProcToStr(ByVal c As Double) As String
        ' pavercia desimtaini proc i string ekvivalenta: "0,18" -> "18 %"
        ProcToStr = CStr(c * 100) & " %"
    End Function

    Public Function StrToProc(ByVal s As String) As Double
        ' pavercia procentu stringa i desimtaini proc "18 %" -> "0,18"
        Dim i As Integer
        Dim tmp As String = ""
        For i = 1 To s.Length
            If s.Substring(i - 1, 1) <> " " Then
                tmp = tmp & s.Substring(i - 1, 1)
            Else
                Exit For
            End If
        Next

        Try
            StrToProc = CDbl(tmp) / 100
        Catch ex As Exception
            StrToProc = 0
        End Try
    End Function

    Public Function Get_Element(ByVal s As String, ByVal Nr As Integer) As String
        ' is stringo eilutes iskiria elementus atskirtus TAB
        Dim i, j As Integer
        Dim tm As String = ""
        j = 0
        For i = 1 To s.Length
            If s.Substring(i - 1, 1) <> Chr(9) Then
                tm = tm & s.Substring(i - 1, 1)
            Else
                j = j + 1
                If j = Nr Then ' reikiamas elementas
                    Get_Element = tm
                    Exit Function
                End If
                tm = ""
            End If
        Next
        If j + 1 = Nr Then ' paskutinis elementas
            Get_Element = tm
        Else
            Get_Element = ""
        End If
    End Function

    Public Function StringNotLonger(ByVal InputString As String, ByVal MaxLength As Integer) As String
        If InputString.Length > MaxLength Then
            Return InputString.Substring(0, MaxLength)
        Else
            Return InputString
        End If
    End Function

    Public Function GetStringPart(ByVal InputString As String, Optional ByVal Ending As Boolean = False) As String
        Dim s As String = ""
        If Not Ending Then
            For i As Integer = 1 To InputString.Length
                If Char.IsLetter(InputString.Chars(i - 1)) Then s = s & InputString.Chars(i - 1)
                If Char.IsNumber(InputString.Chars(i - 1)) Then Return s
            Next
        Else
            For i As Integer = InputString.Length To 1 Step -1
                If Char.IsLetter(InputString.Chars(i - 1)) Then s = InputString.Chars(i - 1) & s
                If Char.IsNumber(InputString.Chars(i - 1)) Then Return s
            Next
        End If
        Return s
    End Function

    Public Function GetNumericPart(ByVal InputString As String, Optional ByVal Ending As Boolean = False) As String
        Dim s As String = ""
        If Not Ending Then
            For i As Integer = 1 To InputString.Length
                If Char.IsNumber(InputString.Chars(i - 1)) Then s = s & InputString.Chars(i - 1)
            Next
        Else
            For i As Integer = InputString.Length To 1 Step -1
                If Char.IsLetter(InputString.Chars(i - 1)) Then Return s
                If Char.IsNumber(InputString.Chars(i - 1)) Then s = InputString.Chars(i - 1) & s
            Next
        End If
        Return s
    End Function

#End Region

#Region "***DARBAS SU CONTROLSAIS***"

    Public Sub NormalizuotiMTGC(ByRef b As MTGCComboBox)
        ' sutvarko, kad MTGC combo text atitiktu selected
        Dim tmp As MTGCComboBoxItem = b.SelectedItem
        Try
            If b.Text <> tmp.Col1.ToString Then b.Text = tmp.Col1.ToString
        Catch ex As Exception
            b.Text = ""
            b.SelectedIndex = -1
        End Try
    End Sub

    Public Sub NormalizuotiCombo(ByRef b As ComboBox)
        ' sutvarko, kad combo textas ir selected sutaptu
        Try
            If b.SelectedItem.ToString <> b.Text Then b.Text = b.SelectedItem.ToString
        Catch ex As Exception
            b.Text = ""
            b.SelectedItem = -1
        End Try
    End Sub

    Public Sub NormalizuotiTXT(ByRef b As TextBox, ByVal r As Integer)
        ' suapvalina textboxo reiksme iki r zenklu arba nulina, jei klaida
        Try
            b.Text = Math.Round(CDbl(b.Text), r).ToString
        Catch ex As Exception
            b.Text = "0"
        End Try
    End Sub

    Public Sub PasirinktiCombo(ByRef c As ComboBox, ByVal s As String)
        ' pasirenka ComboBoxo item'a, kurio verte yra s
        Dim i As Integer

        For i = 1 To c.Items.Count
            Try
                If c.Items.Item(i - 1).ToString = s Then
                    c.SelectedIndex = i - 1
                    Exit Sub
                End If
            Catch ex As Exception
            End Try
        Next
        c.SelectedIndex = -1
    End Sub

    Public Sub PasirinktiMTGC(ByRef c As MTGCComboBox, ByVal s As String, _
        Optional ByVal St As Integer = 1)
        ' pasirenka MTGC combo item'a, kurio pirmo stulpelio verte lygi s
        Dim i As Integer

        For i = 1 To c.Items.Count
            Try
                Dim tmp As MTGCComboBoxItem = c.Items.Item(i - 1)
                If St = 1 Then
                    If CStr(tmp.Col1) = s Then
                        c.SelectedIndex = i - 1
                        Exit Sub
                    End If
                ElseIf St = 2 Then
                    If CStr(tmp.Col2) = s Then
                        c.SelectedIndex = i - 1
                        Exit Sub
                    End If
                ElseIf St = 3 Then
                    If CStr(tmp.Col3) = s Then
                        c.SelectedIndex = i - 1
                        Exit Sub
                    End If
                Else
                    If CStr(tmp.Col4) = s Then
                        c.SelectedIndex = i - 1
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
            End Try
        Next
        c.SelectedIndex = -1
    End Sub

#End Region

#Region "***DARBAS SU DATOM***"

    Public Function data_p(ByVal mt As Integer, ByVal mn As Byte) As Date
        'duoda pasirinkto men paskutines dienos data
        Try
            If mt < Today.Year - 10 Or mt > Today.Year Then
                data_p = Nothing
                Exit Function
            End If
        Catch ex As Exception
            data_p = Nothing
            Exit Function
        End Try
        Try
            data_p = Date.Parse(mt.ToString & "-" & mn.ToString & "-" _
                & Date.DaysInMonth(mt, mn).ToString)
        Catch ex As Exception
            MsgBox("Neatpažinta klaida modulyje VModulis procedūra data_p: " & ex.Message)
        End Try
    End Function

    Public Function data_r(ByVal mt As Integer, ByVal mn As Byte) As Date
        'duoda pasirinkto metu mt men mn pirmos dienos data
        Try
            If mt < Today.Year - 10 Or mt > Today.Year Then
                data_r = Nothing
                Exit Function
            End If
        Catch ex As Exception
            data_r = Nothing
            Exit Function
        End Try
        data_r = Date.Parse(mt.ToString & "-" & mn.ToString & "-01")
    End Function

    Public Function Savaites_d_LT(ByVal dat As Date) As Byte
        Select Case dat.DayOfWeek
            Case DayOfWeek.Monday
                Savaites_d_LT = 1
            Case DayOfWeek.Tuesday
                Savaites_d_LT = 2
            Case DayOfWeek.Wednesday
                Savaites_d_LT = 3
            Case DayOfWeek.Thursday
                Savaites_d_LT = 4
            Case DayOfWeek.Friday
                Savaites_d_LT = 5
            Case DayOfWeek.Saturday
                Savaites_d_LT = 6
            Case DayOfWeek.Sunday
                Savaites_d_LT = 7
            Case Else
                Savaites_d_LT = 8
        End Select
    End Function

    'Public Function D_val_sk(ByVal Mt As Integer, ByVal mn As Byte, _
    '        Optional ByRef dienu As Integer = 0) As Integer
    '    'duoda pasirinkto metu "mt" men "mn" darbo val ir dienu skaiciu
    '    Dim sk, sk2, sk3, sk4 As Integer
    '    Dim t_data As Date
    '    Dim s_diena As Byte
    '    sk = Date.DaysInMonth(Mt, mn)
    '    'suzinom dienu skaiciu menesyje
    '    t_data = Date.Parse(Mt.ToString & "-" & mn.ToString _
    '            & "-" & "01") 'suformuojam pirmos men dienos data
    '    s_diena = Savaites_d_LT(t_data) 'pirmos menesio dienos savaites diena
    '    sk2 = sk - 7 + s_diena - 1 'menesio dienu skaicius atmetus 1 savaite
    '    sk3 = Math.Floor(sk2 / 7) 'cielu savaiciu skaicius
    '    sk4 = sk2 - sk3 * 7 'paskutines savaites dienu skaicius
    '    D_val_sk = 40 * sk3 'cielu savaiciu darbo val skaicius
    '    'jei pirmoj darbo savaitej buvo darbo dienu, pripliusuojam po 8 h kiekvienai
    '    If 6 - s_diena > 0 Then D_val_sk = D_val_sk + (6 - s_diena) * 8
    '    If sk4 <= 5 Then 'jei paskutinej savaitej iki penktadienio
    '        D_val_sk = D_val_sk + sk4 * 8 'pliusuojam pgl fakta po 8 h
    '    Else 'jei apima ir sestadieni
    '        D_val_sk = D_val_sk + 40 'tik 40 val
    '    End If
    '    Dim i As Integer
    '    Dim men As Integer
    '    Try
    '        For i = 1 To MyCustomSettings.Sventes.Count
    '            t_data = Date.Parse(Mt.ToString & "-" _
    '                & StrToMen(zodis(My.Settings.Sventes.Item(i - 1), 0)).ToString & "-" _
    '                & zodis(My.Settings.Sventes.Item(i - 1), 1).ToString)
    '            'suformuojam sventes data
    '            If t_data >= data_r(Mt, mn) And t_data <= data_p(Mt, mn) Then
    '                If t_data.DayOfWeek <> DayOfWeek.Saturday _
    '                    Or t_data.DayOfWeek <> DayOfWeek.Sunday Then 'jei pirm - penktad
    '                    D_val_sk = D_val_sk - 8
    '                ElseIf t_data.DayOfWeek = DayOfWeek.Saturday Then 'sestadienis
    '                    If t_data.Day < Date.DaysInMonth(t_data.Year, t_data.Month) - 1 Then _
    '                        D_val_sk = D_val_sk - 8
    '                    'jei tas pats menuo bus pirmadieni, tai ivyksta perkelimas
    '                ElseIf t_data.DayOfWeek = DayOfWeek.Sunday Then 'sekmadienis
    '                    If My.Settings.Sventes.Contains(MenToStr(mn) _
    '                            & " " & (t_data.Day - 1).ToString) And t_data.Day > 1 Then
    '                        'jei sestadieni buvo svente, o sestadienis buvo to pacio men
    '                        If t_data.Day < Date.DaysInMonth(t_data.Year, t_data.Month) - 2 Then _
    '                            D_val_sk = D_val_sk - 8
    '                        'jei tas pats menuo bus antradieni, tai ivyksta perkelimas
    '                    Else
    '                        If t_data.Day < Date.DaysInMonth(t_data.Year, t_data.Month) - 1 Then _
    '                            D_val_sk = D_val_sk - 8
    '                        'jei tas pats menuo bus pirmadieni, tai ivyksta perkelimas
    '                    End If
    '                End If
    '                If t_data.Day > 1 And t_data.DayOfWeek <> DayOfWeek.Sunday _
    '                        And t_data.DayOfWeek <> DayOfWeek.Monday Then
    '                    If Not My.Settings.Sventes.Contains(MenToStr(mn) _
    '                            & " " & (t_data.Day - 1).ToString) Then
    '                        'jei priessventine diena buvo ne sestadienis, sekmadienis ir ne sventine
    '                        D_val_sk = D_val_sk - 1
    '                        'sutrumpinama diena pries svente
    '                    End If
    '                End If
    '            End If
    '        Next
    '        Dim met As Integer
    '        If mn = 12 Then 'sekantis menuo
    '            men = 1
    '        Else
    '            men = mn + 1
    '        End If
    '        t_data = data_p(Mt, mn)
    '        If My.Settings.Sventes.Contains(MenToStr(men) & " 1") _
    '                And t_data.DayOfWeek <> DayOfWeek.Sunday _
    '                And t_data.DayOfWeek <> DayOfWeek.Saturday Then
    '            'jei sekancio men pirma diena sventine, o pasirinkto men paskutine - darbo
    '            'tada trumpinam darbo laika
    '            D_val_sk = D_val_sk - 1
    '        End If
    '        If mn = 1 Then 'praejes menuo
    '            men = 12
    '            met = Mt - 1
    '        Else
    '            men = mn - 1
    '            met = Mt
    '        End If
    '        t_data = data_r(Mt, mn)
    '        If t_data.DayOfWeek = DayOfWeek.Monday Then 'jei pirma men diena - pirmadienis
    '            If My.Settings.Sventes.Contains(MenToStr(men) & " " _
    '                    & Date.DaysInMonth(met, men).ToString) Then
    '                D_val_sk = D_val_sk - 8
    '                'perkelta diena uz sekmadieni
    '            End If
    '            If My.Settings.Sventes.Contains(MenToStr(men) & " " _
    '                    & (Date.DaysInMonth(met, men) - 1).ToString) Then
    '                D_val_sk = D_val_sk - 8
    '                'perkelta diena uz sestadieni
    '            End If
    '        ElseIf t_data.DayOfWeek = DayOfWeek.Tuesday Then
    '            If My.Settings.Sventes.Contains(MenToStr(men) & " " _
    '                & Date.DaysInMonth(met, men).ToString) Then
    '                D_val_sk = D_val_sk - 8
    '                'perkelta diena uz sekmadieni
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    '    If My.Settings.Motinos_diena And mn = 5 Then D_val_sk = D_val_sk - 8
    '    'motinos diena visada yra pirma geguzes sekmadieni
    '    'atitinkamai po jo sekantis pirmadienis bus nedarbo diena
    '    If mn = 3 Or mn = 4 Then 'VELYKOS
    '        If Velykos(Mt).Month = 4 And mn = 4 Then
    '            D_val_sk = D_val_sk - 16
    '        ElseIf Velykos(Mt).Month = 3 And Velykos(Mt).Day = 31 And mn = 4 Then
    '            D_val_sk = D_val_sk - 16
    '        ElseIf Velykos(Mt).Month = 3 And Velykos(Mt).Day = 30 And mn = 4 Then
    '            D_val_sk = D_val_sk - 8
    '        ElseIf Velykos(Mt).Month = 3 And Velykos(Mt).Day = 30 And mn = 3 Then
    '            D_val_sk = D_val_sk - 8
    '        ElseIf Velykos(Mt).Month = 3 And Velykos(Mt).Day < 30 And mn = 3 Then
    '            D_val_sk = D_val_sk - 16
    '        End If
    '    End If
    '    dienu = Math.Ceiling(D_val_sk / 8)
    'End Function

    'Public Function M_Koef(ByVal met As Integer) As Double
    '    Dim i As Integer
    '    Dim nd, dd, temp As Integer
    '    dd = 0
    '    nd = 0
    '    For i = 1 To 12
    '        D_val_sk(met, i, temp)
    '        dd = dd + temp
    '        nd = nd + Date.DaysInMonth(met, i)
    '    Next
    '    Return Math.Round(Math.Ceiling(Math.Round(dd / nd, 2) * 20) * 0.05, 2)
    'End Function

    Public Function Velykos(ByVal met As Integer) As Date
        Dim c, n, k, i, j, l, m, d As Integer
        c = Math.Floor(met / 100)
        n = met - 19 * Math.Floor(met / 19)
        k = Math.Floor((c - 17) / 25)
        i = c - Math.Floor(c / 4) - Math.Floor((c - k) / 3) + 19 * n + 15
        i = i - 30 * Math.Floor(i / 30)
        i = i - Math.Floor(i / 28) * (1 - Math.Floor(i / 28) * Math.Floor(29 / (i + 1)) _
                * Math.Floor((21 - n) / 11))
        j = met + Math.Floor(met / 4) + i + 2 - c + Math.Floor(c / 4)
        j = j - 7 * Math.Floor(j / 7)
        l = i - j
        m = 3 + Math.Floor((l + 40) / 44)
        d = l + 28 - 31 * Math.Floor(m / 4)
        Velykos = Date.Parse(met.ToString & "-" & m.ToString & "-" & d.ToString)
    End Function

    Public Function MenToStr(ByVal m As Integer) As String
        Select Case m
            Case 1
                MenToStr = "Sausio"
            Case 2
                MenToStr = "Vasario"
            Case 3
                MenToStr = "Kovo"
            Case 4
                MenToStr = "Balandžio"
            Case 5
                MenToStr = "Gegužės"
            Case 6
                MenToStr = "Birželio"
            Case 7
                MenToStr = "Liepos"
            Case 8
                MenToStr = "Rugpjūčio"
            Case 9
                MenToStr = "Rugsėjo"
            Case 10
                MenToStr = "Spalio"
            Case 11
                MenToStr = "Lapkričio"
            Case 12
                MenToStr = "Gruodžio"
            Case Else
                MenToStr = "klaida"
        End Select
    End Function

    Public Function StrToMen(ByVal s As String) As Integer
        Select Case s
            Case "Sausio"
                StrToMen = 1
            Case "Vasario"
                StrToMen = 2
            Case "Kovo"
                StrToMen = 3
            Case "Balandžio"
                StrToMen = 4
            Case "Gegužės"
                StrToMen = 5
            Case "Birželio"
                StrToMen = 6
            Case "Liepos"
                StrToMen = 7
            Case "Rugpjūčio"
                StrToMen = 8
            Case "Rugsėjo"
                StrToMen = 9
            Case "Spalio"
                StrToMen = 10
            Case "Lapkričio"
                StrToMen = 11
            Case "Gruodžio"
                StrToMen = 12
            Case Else
                StrToMen = 0
        End Select
    End Function

    Public Function DataToString(ByVal d As Date) As String
        ' konvertuoja data i liet stringa
        Dim s As String = ""
        s = s & d.Year.ToString & " m. "
        s = s & MenToStr(d.Month) & " mėn. "
        s = s & d.Day.ToString & " d."
        DataToString = s
    End Function

#End Region

    Public Function SumLT(ByVal NumberArg As Double, Optional ByVal intCase As Integer = 0, _
        Optional ByVal AddZero As Boolean = True, Optional ByVal CurrencyCode As String = "") As String
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

        If Not String.IsNullOrEmpty(CurrencyCode.Trim) AndAlso CurrencyCode.Trim.ToUpper <> "LTL" Then _
            strRez = strRez.Replace("LITŲ", CurrencyCode.Trim.ToUpper). _
                Replace("LITAS", CurrencyCode.Trim.ToUpper). _
                Replace("LITAI", CurrencyCode.Trim.ToUpper)

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

    Public Sub Nulinti_dt(ByRef myDta As DataTable, ByVal s As String)
        'DBNull reiksmes pakeicia i reiksme s
        Dim i, j As Integer
        For i = 1 To myDta.Rows.Count
            For j = 1 To myDta.Columns.Count
                If myDta.Rows(i - 1).Item(j - 1).GetType.Name = "DBNull" Then
                    If myDta.Columns(j - 1).DataType.FullName = "System.DateTime" Then
                        myDta.Rows(i - 1).Item(j - 1) = Today
                    ElseIf myDta.Columns(j - 1).DataType.FullName = "System.String" Then
                        myDta.Rows(i - 1).Item(j - 1) = ""
                    Else
                        myDta.Rows(i - 1).Item(j - 1) = 0
                    End If
                End If
            Next
        Next
    End Sub

    Public Sub SetFormLayout(ByRef nForm As Form)
        FormSettings.SetFormProperties(nForm, MyCustomSettings.AutoSizeForm, _
            MyCustomSettings.FormPropertiesList)
    End Sub

    Public Sub SetDataGridViewLayOut(ByRef nDataGridView As DataGridView)
        FormSettings.SetDataGridViewProperties(nDataGridView, _
            MyCustomSettings.AutoSizeDataGridViewColumns, MyCustomSettings.DataGridViewColumnPropertiesList)
    End Sub

    Public Sub GetFormLayout(ByVal nForm As Form)
        FormSettings.GetFormProperties(nForm, MyCustomSettings.AutoSizeForm, MyCustomSettings.FormPropertiesList)
        Try
            MyCustomSettings.FormPropertiesList = FormSettings.GetFormPropertiesStringCollection( _
                MyCustomSettings.FormPropertiesList)
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko išsaugoti programos nustatymų: " & ex.Message, ex))
        End Try
    End Sub

    Public Sub GetDataGridViewLayOut(ByRef nDataGridView As DataGridView)
        FormSettings.GetDataGridViewProperties(nDataGridView, MyCustomSettings.AutoSizeDataGridViewColumns, _
            MyCustomSettings.DataGridViewColumnPropertiesList)
        Try
            MyCustomSettings.DataGridViewColumnPropertiesList = FormSettings.GetColumnPropertiesStringCollection( _
                 MyCustomSettings.DataGridViewColumnPropertiesList)
        Catch ex As Exception
            ShowError(New Exception("Klaida. Nepavyko išsaugoti programos nustatymų: " & ex.Message, ex))
        End Try
    End Sub

    Public Function ConvertHtmlTableToDataTable(ByVal HtmlText As String) As DataTable

        Dim result As New DataTable

        Dim ptrnTR As String = "[\<TR>[\w*\W*]*?</TR>"
        Dim ptrnTD As String = "<TD\s?[\w*\W*]*?>[\w*\W*]*?</TD>"
        Dim ptrnTag As String = "[\[<][\W*\w*]*?>"

        Dim TR As System.Text.RegularExpressions.Match
        Dim TD As System.Text.RegularExpressions.Match
        Dim Tag As System.Text.RegularExpressions.Match
        Dim TRs As System.Text.RegularExpressions.MatchCollection = _
            System.Text.RegularExpressions.Regex.Matches(HtmlText, ptrnTR)

        Dim i As Integer

        For Each TR In TRs

            If result.Columns.Count < 1 Then result.Columns.Add()
            result.Rows.Add()
            Dim TDs As System.Text.RegularExpressions.MatchCollection = _
                System.Text.RegularExpressions.Regex.Matches(TR.Value, ptrnTD)

            i = 0
            For Each TD In TDs

                Dim TDvalue As String = TD.Value
                Dim TAGs As System.Text.RegularExpressions.MatchCollection = _
                    System.Text.RegularExpressions.Regex.Matches(TD.Value, ptrnTag)

                For Each Tag In TAGs
                    TDvalue = TDvalue.Replace(Tag.Value, "")
                Next

                If result.Columns.Count < i + 1 Then result.Columns.Add()

                result.Rows(result.Rows.Count - 1).Item(i) = TDvalue
                i += 1

            Next

        Next

        Return result

    End Function

    Public Function StripHtmlTags(ByVal HtmlSource As String) As String
        Dim oReg = New System.Text.RegularExpressions.Regex("")
        Return oReg.Replace(HtmlSource, "<[^<>]+>", "")
    End Function

    Public Function GetFileEncoding(ByVal FilePath As String, _
            ByVal ThrowOnFail As Boolean) As System.Text.Encoding

        Using afile As System.IO.FileStream = New System.IO.FileStream(FilePath, _
                IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)

            If afile.CanSeek Then

                Dim bom As Byte() = New Byte(3) {} ' Get the byte-order mark, if there is one

                afile.Read(bom, 0, 4)

                afile.Close()

                If (bom(0) = &HEF AndAlso bom(1) = &HBB AndAlso bom(2) = &HBF) OrElse _
                    (bom(0) = &HFF AndAlso bom(1) = &HFE) OrElse (bom(0) = &HFE AndAlso _
                    bom(1) = &HFF) OrElse (bom(0) = 0 AndAlso bom(1) = 0 AndAlso _
                    bom(2) = &HFE AndAlso bom(3) = &HFF) Then ' ucs-4

                    Return System.Text.Encoding.Unicode

                Else

                    Return System.Text.Encoding.Default

                End If

            Else

                afile.Close()

                If ThrowOnFail Then Throw New NotImplementedException( _
                    "Klaida. Nepavyko nustatyti failo koduotės.")

                Return System.Text.Encoding.Default

            End If

        End Using

    End Function

    Public Function LoadObjectFromCombo(Of T)(ByVal Combo As ComboBox, ByVal IdPropertyName As String) As T

        If Combo Is Nothing Then Throw New ArgumentNullException( _
            "Klaida. Metodui LoadObjectFromCombo nenurodytas ComboBox'as")
        If IdPropertyName Is Nothing Then IdPropertyName = ""
        IdPropertyName = IdPropertyName.Trim

        Dim result As T = Nothing

        If TypeOf Combo Is AccControls.AccGridComboBox Then

            If DirectCast(Combo, AccGridComboBox).SelectedValue Is Nothing OrElse _
                Not TypeOf DirectCast(Combo, AccGridComboBox).SelectedValue Is T Then Return result

            result = DirectCast(DirectCast(Combo, AccGridComboBox).SelectedValue, T)

        ElseIf TypeOf Combo Is ComboBox Then

            If DirectCast(Combo, ComboBox).SelectedIndex < 0 OrElse _
                DirectCast(Combo, ComboBox).SelectedItem Is Nothing OrElse _
                Not TypeOf DirectCast(Combo, ComboBox).SelectedItem Is T Then Return result

            result = DirectCast(DirectCast(Combo, ComboBox).SelectedItem, T)

        Else
            Throw New NotImplementedException("Klaida. Control tipas '" _
                & Combo.GetType.FullName & "' neimplementuotas metode LoadObjectFromCombo.")
        End If

        If Not String.IsNullOrEmpty(IdPropertyName.Trim) AndAlso _
            Not result.GetType.GetProperty(IdPropertyName.Trim) Is Nothing AndAlso _
            Not result.GetType.GetProperty(IdPropertyName.Trim).GetValue(result, Nothing) Is Nothing AndAlso _
            Not Convert.ToInt16(result.GetType.GetProperty(IdPropertyName.Trim).GetValue(result, Nothing)) > 0 Then _
            Return Nothing

        Return result

    End Function

End Module

Public Class FormulaSolver

    Private pos, bracket, ebene As Integer
    Private res As Double
    Public F_Error As Boolean = False
    Private Params As Dictionary(Of String, Double) = Nothing

    Public Property Param(ByVal key As String) As Double
        Get
            If Params Is Nothing OrElse Not Params.ContainsKey(key) Then
                F_Error = True
                MsgBox("Klaida. Tokio parametro nėra parametrų sąraše.")
                Return 0
            End If
            Return Params.Item(key)
        End Get
        Set(ByVal value As Double)
            If Params Is Nothing Then Params = New Dictionary(Of String, Double)
            If Not Params.ContainsKey(key) Then
                Params.Add(key, value)
            Else
                Params.Item(key) = value
            End If
        End Set
    End Property

    Public Sub ClearParams()
        If Params Is Nothing Then Params = New Dictionary(Of String, Double)
        Params.Clear()
    End Sub

    Private Function TryVariable(ByVal VarStr As String, ByRef Value As Double) As Boolean
        Dim tre As Double = Param(VarStr)
        If F_Error Then
            Value = tre
            Return False
        Else
            Value = tre
            Return True
        End If
    End Function

    Private Function GetBracket(ByVal Str As String, ByVal start As Integer) As Integer
        res = start
        For i As Integer = start To Str.Length - 1
            Select Case Str.Substring(i, 1)
                Case "("
                    bracket = bracket + 1
                Case ")"
                    bracket = bracket - 1
            End Select
            If bracket = 0 Then
                res = i
                Exit For
            End If
        Next
        Return res
    End Function

    Private Function Solve(ByVal Formula As String) As Double
        If Formula.Length = 0 Then Return GenerateError()
        If Formula.StartsWith("(") And GetBracket(Formula, 0) = Formula.Length - 1 _
            Then Formula = Formula.Substring(1, Formula.Length - 2)
        If Double.TryParse(Formula, System.Globalization.NumberStyles.Float, Nothing, res) Then Return res
        If Formula.Length = 2 AndAlso Formula.ToUpper = "PI" Then Return Math.PI
        If Formula.Length = 3 AndAlso TryVariable(Formula, res) Then Return res

        Dim zc As String

        If Formula.Length > 4 AndAlso Formula.Substring(3, 1) = "(" Then
            pos = GetBracket(Formula, 3)
            If pos <> Formula.Length - 1 Then GoTo cont
            zc = Formula.Substring(4, pos - 4)
            Select Case Formula.Substring(0, 3).ToLower
                Case "sqr"
                    Return Math.Sqrt(Solve(zc))
                Case "sin"
                    Return Math.Sin(Solve(zc) * Math.PI / 180)
                Case "cos"
                    Return Math.Cos(Solve(zc) * Math.PI / 180)
                Case "tan"
                    Return Math.Tan(Solve(zc) * Math.PI / 180)
                Case "log"
                    Return Math.Log10(Solve(zc))
                Case "abs"
                    Return Math.Abs(Solve(zc))
                Case "imz"
                    Dim tres As Double = Solve(zc)
                    Return IIf(tres > 0, tres, 0)
            End Select
        End If

cont:
        pos = 0
        ebene = 6
        bracket = 0

        For i As Integer = Formula.Length - 1 To 0 Step -1
            Select Case Formula.Substring(i, 1)
                Case "("
                    bracket += 1
                    Exit Select
                Case ")"
                    bracket -= 1
                    Exit Select
                Case "+"
                    If bracket = 0 And ebene > 0 Then
                        pos = i
                        ebene = 0
                    End If
                    Exit Select
                Case "-"
                    If bracket = 0 And ebene > 1 Then
                        pos = i
                        ebene = 1
                    End If
                    Exit Select
                Case "*"
                    If bracket = 0 And ebene > 2 Then
                        pos = i
                        ebene = 2
                    End If
                    Exit Select
                Case "%"
                    If bracket = 0 And ebene > 3 Then
                        pos = i
                        ebene = 3
                    End If
                    Exit Select
                Case "/"
                    If bracket = 0 And ebene > 4 Then
                        pos = i
                        ebene = 4
                    End If
                    Exit Select
                Case "^"
                    If bracket = 0 And ebene > 5 Then
                        pos = i
                        ebene = 5
                    End If
                    Exit Select
            End Select
        Next

        If pos = 0 OrElse pos = Formula.Length - 1 Then Return GenerateError()

        zc = Formula.Substring(pos, 1)
        Dim t1, t2 As String
        t1 = Formula.Substring(0, pos)
        t2 = Formula.Substring(pos + 1, Formula.Length - (pos + 1))
        Select Case zc
            Case "+"
                Return CRound(Solve(t1) + Solve(t2))
            Case "-"
                Return CRound(Solve(t1) - Solve(t2))
            Case "*"
                Return CRound(Solve(t1) * Solve(t2))
            Case "/"
                Return CRound(Solve(t1) / Solve(t2))
            Case "%"
                Return Math.IEEERemainder(Solve(t1), Solve(t2))
            Case "^"
                Return Math.Pow(Solve(t1), Solve(t2))
        End Select
        Return GenerateError()
    End Function

    Private Function GenerateError() As Double
        F_Error = True
        Return 0
    End Function

    Public Function Solved(ByVal Formula As String, ByRef result As Double) As Boolean
        If String.IsNullOrEmpty(Formula) Then
            result = 0
            Return False
        End If
        If CChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) <> CChar(",") Then _
            Formula = Formula.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        F_Error = False
        result = Solve(Formula)
        Return Not F_Error
    End Function

End Class
