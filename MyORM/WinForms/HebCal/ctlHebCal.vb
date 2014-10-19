Imports System.Globalization

Public Class ctlHebCal

    Shared Monthes() As String = {"", "תשרי", "חשוון", "כסלו", "טבת", "שבט", "אדר", "ניסן", "אייר", "סיון", "תמוז", "אב", "אלול"}
    Shared LMonthes() As String = {"", "תשרי", "חשוון", "כסלו", "טבת", "שבט", "אדר א'", "אדר ב'", "ניסן", "אייר", "סיון", "תמוז", "אב", "אלול"}

    Private m_Value As Date

    Public Const FirstYear As Integer = 1584
    Public Const LastYear As Integer = 2238

    Public Event DayClick(ByVal greg As Date, ByVal heb As String)
    Public Event DayDoubleClick(ByVal greg As Date, ByVal heb As String)

    Dim HCal As New Globalization.HebrewCalendar
    Dim bIn As Boolean

    Private Sub OnAnyControlKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, YearCmb.KeyDown, MonthesCmb.KeyDown
        If e.KeyCode = Keys.Space Then
            InitDate()
        End If
    End Sub

    Private Sub HebDTPicker_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call InitDate(m_Value)

        For Each ctl As Control In Pan.AllControls()
            If ctl.GetType() = GetType(TextBox) Then
                AddHandler ctl.KeyDown, AddressOf OnAnyControlKeyDown
            End If
        Next

    End Sub

    Private Sub InitDate(Optional ByVal D As Date = Nothing)

        bIn = True

        For I As Integer = 1 To 42
            If Controls("Pan").Controls("txt" & I.ToString) Is Nothing Then Continue For
            CType(Controls("Pan").Controls("txt" & I.ToString), Windows.Forms.TextBox).Clear()
            Me.Controls("Pan").Controls("txt" & I.ToString).BackColor = Drawing.Color.White
        Next

        Call PaintAllDaysBlack()

        If D = Date.MinValue Then
            D = Now
        End If

        ListYears()
        ListMonths(HCal.GetYear(D))
        ListDays(HCal.GetYear(D), HCal.GetMonth(D), HCal.GetDayOfMonth(D))
        Me.GregLbl.Text = D.ToString("MM/yyyy")

        YearCmb.SelectedIndex = HCal.GetYear(D) - HCal.GetYear(New Date(FirstYear, 1, 1))

        MonthesCmb.SelectedIndex = HCal.GetMonth(D) - 1

        m_Value = D

        bIn = False
    End Sub

    Private Sub ListMonths(ByVal iYear As Integer)

        MonthesCmb.Items.Clear()

        Dim List As New List(Of String)

        If HCal.IsLeapYear(iYear) Then
            List.AddRange(LMonthes)
        Else
            List.AddRange(Monthes)
        End If

        List.RemoveAt(0)

        MonthesCmb.Items.AddRange(List.ToArray)

    End Sub

    Private Sub ListDays(ByVal iYear As Integer, ByVal iMonth As Integer, ByVal iDay As Integer)

        Dim GregDate As Date = HCal.ToDateTime(iYear, iMonth, 1, 0, 0, 0, 0)

        Dim FirstWeekday As Integer = GregDate.DayOfWeek + 1

        Dim GregDay As Integer = GregDate.Day

        Dim CurrDay As Integer = 1

        Dim sTag As String = ""

        For I As Integer = FirstWeekday To FirstWeekday + (HCal.GetDaysInMonth(iYear, iMonth) - 1)

            If New Date(GregDate.Year, GregDate.Month, GregDay) = Today Then
                Me.Controls("Pan").Controls("txt" & I.ToString).BackColor = Drawing.Color.LightSalmon
            End If

            Me.Controls("Pan").Controls("txt" & I.ToString).Visible = True
            Me.Controls("Pan").Controls("txt" & I.ToString).Text = NumToChar(CurrDay) & "       " & GregDay

            Me.Controls("Pan").Controls("txt" & I.ToString).Tag = New Date(GregDate.Year, GregDate.Month, GregDay)

            CurrDay += 1
            GregDay += 1

            If GregDay > Date.DaysInMonth(GregDate.Year, GregDate.Month) Then
                GregDay = 1
                GregDate = DateAdd(DateInterval.Month, 1, New Date(GregDate.Year, GregDate.Month, GregDay))
            End If


            If CurrDay - 1 = iDay Then
                Me.Controls("Pan").Controls("txt" & I.ToString).Font = _
                   New System.Drawing.Font(Me.Controls("Pan").Controls("txt" & I.ToString).Font.FontFamily, _
                   Me.Controls("Pan").Controls("txt" & I.ToString).Font.Size, Drawing.FontStyle.Bold)
                Me.Controls("Pan").Controls("txt" & I.ToString).ForeColor = Drawing.Color.Red
            End If

        Next

    End Sub

    Private Sub ListYears()

        YearCmb.Items.Clear()
        Dim lst As New List(Of String)

        For i As Integer = HCal.GetYear(New Date(FirstYear, 1, 1)) To HCal.GetYear(New Date(LastYear, 1, 1))
            lst.Add(NumToChar(i))
        Next
        YearCmb.Items.AddRange(lst.ToArray)

    End Sub


    Public Shared Function Gimatria(ByVal Str As String) As Integer
        Dim Sum As Integer, i As Integer
        For i = Len(Str) To 1 Step -1
            If Mid(Str, i, 1) = "א" Then Sum = Sum + 1
            If Mid(Str, i, 1) = "ב" Then Sum = Sum + 2
            If Mid(Str, i, 1) = "ג" Then Sum = Sum + 3
            If Mid(Str, i, 1) = "ד" Then Sum = Sum + 4
            If Mid(Str, i, 1) = "ה" Then Sum = Sum + 5
            If Mid(Str, i, 1) = "ו" Then Sum = Sum + 6
            If Mid(Str, i, 1) = "ז" Then Sum = Sum + 7
            If Mid(Str, i, 1) = "ח" Then Sum = Sum + 8
            If Mid(Str, i, 1) = "ט" Then Sum = Sum + 9
            If Mid(Str, i, 1) = "י" Then Sum = Sum + 10
            If Mid(Str, i, 1) = "כ" Then Sum = Sum + 20
            If Mid(Str, i, 1) = "ך" Then Sum = Sum + 20
            If Mid(Str, i, 1) = "ל" Then Sum = Sum + 30
            If Mid(Str, i, 1) = "מ" Then Sum = Sum + 40
            If Mid(Str, i, 1) = "ם" Then Sum = Sum + 40
            If Mid(Str, i, 1) = "נ" Then Sum = Sum + 50
            If Mid(Str, i, 1) = "ן" Then Sum = Sum + 50
            If Mid(Str, i, 1) = "ס" Then Sum = Sum + 60
            If Mid(Str, i, 1) = "ע" Then Sum = Sum + 70
            If Mid(Str, i, 1) = "פ" Then Sum = Sum + 80
            If Mid(Str, i, 1) = "ף" Then Sum = Sum + 80
            If Mid(Str, i, 1) = "צ" Then Sum = Sum + 90
            If Mid(Str, i, 1) = "ץ" Then Sum = Sum + 90
            If Mid(Str, i, 1) = "ק" Then Sum = Sum + 100
            If Mid(Str, i, 1) = "ר" Then Sum = Sum + 200
            If Mid(Str, i, 1) = "ש" Then Sum = Sum + 300
            If Mid(Str, i, 1) = "ת" Then Sum = Sum + 400
        Next
        Gimatria = Sum
    End Function

    Private Sub YearCmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YearCmb.SelectedIndexChanged
        If bIn Then Exit Sub
        If MonthesCmb.SelectedIndex = -1 Then Exit Sub

        Dim Year As Integer = Gimatria(YearCmb.Text.Replace("""", "")) + 5000

        Dim befindex As Integer = MonthesCmb.SelectedIndex

        Dim WasLeap As Boolean = MonthesCmb.Items.Count = 13
        Dim IsLeap As Boolean = HCal.IsLeapYear(Year)

        ListMonths(Year)

        If WasLeap And Not IsLeap Then
            If befindex > 5 Then befindex -= 1
        ElseIf IsLeap And Not WasLeap Then
            If befindex > 5 Then befindex += 1
        End If

        MonthesCmb.SelectedIndex = befindex

        InitDate(HCal.ToDateTime(Gimatria(YearCmb.Text.Replace("""", "")) + 5000, MonthesCmb.SelectedIndex + 1, 1, 0, 0, 0, 0))

    End Sub

    Private Sub MonthesCmb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MonthesCmb.SelectedIndexChanged

        If bIn Then Exit Sub

        InitDate(HCal.ToDateTime(Gimatria(YearCmb.Text.Replace("""", "")) + 5000, MonthesCmb.SelectedIndex + 1, 1, 0, 0, 0, 0))

    End Sub

    Private Sub OnDayClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt9.Click, txt8.Click, txt7.Click, txt6.Click, txt5.Click, txt4.Click, txt36.Click, txt35.Click, txt34.Click, txt33.Click, txt32.Click, txt31.Click, txt30.Click, txt3.Click, txt29.Click, txt28.Click, txt27.Click, txt26.Click, txt25.Click, txt24.Click, txt23.Click, txt22.Click, txt21.Click, txt20.Click, txt2.Click, txt19.Click, txt18.Click, txt17.Click, txt16.Click, txt15.Click, txt14.Click, txt13.Click, txt12.Click, txt11.Click, txt10.Click, txt1.Click
        Try
            Call PaintAllDaysBlack()

            sender.ForeColor = Drawing.Color.Red

            sender.Font = New System.Drawing.Font(CType(sender.Font.FontFamily, Drawing.FontFamily), sender.Font.Size, Drawing.FontStyle.Bold)
            MonthesCmb.Select()

            m_Value = sender.tag
            GregLbl.Text = m_Value.ToString("MM/yyyy")
            RaiseEvent DayClick(sender.tag, GregToHeb(sender.tag))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub OnDayDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt9.DoubleClick, txt8.DoubleClick, txt7.DoubleClick, txt6.DoubleClick, txt5.DoubleClick, txt4.DoubleClick, txt36.DoubleClick, txt35.DoubleClick, txt34.DoubleClick, txt33.DoubleClick, txt32.DoubleClick, txt31.DoubleClick, txt30.DoubleClick, txt3.DoubleClick, txt29.DoubleClick, txt28.DoubleClick, txt27.DoubleClick, txt26.DoubleClick, txt25.DoubleClick, txt24.DoubleClick, txt23.DoubleClick, txt22.DoubleClick, txt21.DoubleClick, txt20.DoubleClick, txt2.DoubleClick, txt19.DoubleClick, txt18.DoubleClick, txt17.DoubleClick, txt16.DoubleClick, txt15.DoubleClick, txt14.DoubleClick, txt13.DoubleClick, txt12.DoubleClick, txt11.DoubleClick, txt10.DoubleClick, txt1.DoubleClick
        RaiseEvent DayDoubleClick(sender.tag, GregToHeb(sender.tag))
    End Sub


    Public Sub About()
        MsgBox("Created By Jossef Rosset - J.R.Softs All Rights Reserved")
    End Sub

    Private Sub PaintAllDaysBlack()

        For I As Integer = 1 To 36
            Me.Controls("Pan").Controls("txt" & I.ToString).ForeColor = Drawing.Color.Black
        Next

    End Sub

    Public ReadOnly Property HebValue() As String
        Get
            Return GregToHeb(m_Value)
        End Get
    End Property

    Public Property Value() As Date
        Get
            Return m_Value
        End Get
        Set(ByVal value As Date)
            m_Value = value
        End Set
    End Property

    Public Shared Function NumToChar(ByVal value As Integer) As String
        ' פונקציה זו מחשבת את הערך באותיות עבריות עבור המספר
        ' שמועבר אליה כארגומנט

        Dim TillYod() As String = {"", "א", "ב", "ג", "ד", "ה", "ו", "ז", "ח", "ט"}

        Dim TillKuf() As String = {"", "י", "כ", "ל", "מ", "נ", "ס", "ע", "פ", "צ"}

        Dim TillElef() As String = {"", "ק", "ר", "ש", "ת", "תק", "תר", "תש", "תת", "תתק", "תתר"}

        Dim HebChars As String

        HebChars = TillYod(value Mod 10)
        HebChars = TillKuf(Int((value Mod 100) / 10)) & HebChars
        HebChars = TillElef(Int((value Mod 1000) / 100)) & HebChars

        HebChars = Replace(HebChars, "יה", "טו")
        HebChars = Replace(HebChars, "יו", "טז")

        If HebChars.Length = 1 Then
            NumToChar = HebChars & "'"
        Else
            NumToChar = HebChars.Substring(0, HebChars.Length - 1) & """" & HebChars.Substring(HebChars.Length - 1, 1)
        End If

    End Function

    Public Shared Function GregToHeb(ByVal Value As Date) As String

        Dim Hcal As New Globalization.HebrewCalendar

        Dim month As String

        If Hcal.IsLeapYear(Hcal.GetYear(Value)) Then
            month = LMonthes(Hcal.GetMonth(Value))
        Else
            month = Monthes(Hcal.GetMonth(Value))
        End If

        Return NumToChar(Hcal.GetDayOfMonth(Value)) & " " & month & " " & NumToChar(Hcal.GetYear(Value))

    End Function
End Class
