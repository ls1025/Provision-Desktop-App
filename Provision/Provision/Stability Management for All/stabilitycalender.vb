Imports System.Data.SqlClient
Public Class stabilitycalender
    Private listFlDay As New List(Of FlowLayoutPanel)
    Private currentDate As DateTime = DateTime.Today
    Private Sub stabilitycalender_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateDayPanel(42)
        DisplayCurrentDate()

        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub

    Private Sub opendatagridview(ByVal sender As Object, e As EventArgs)
        Dim day As Integer = CType(sender, FlowLayoutPanel).Tag
        If day <> 0 Then
            Dim form As New detailcalenderview

            With form
                '.AppID = 0
                '.Label5.Text = New Date(currentDate.Year, currentDate.Month, day)
                .Label5.Text = New Date(currentDate.Year, currentDate.Month, day).ToString("dd MMM yyyy")
                .Label6.Text = New Date(currentDate.Year, currentDate.Month, day).ToString("dd/MM/yyyy")
                .dgv1_rowstyle()
                .ShowDialog()
            End With
            DisplayCurrentDate()
        End If
    End Sub
    Private Sub AddAppointmentToFlDay(ByVal startDayAtFlNumber As Integer)
        Try


            Dim startDate As DateTime = New Date(currentDate.Year, currentDate.Month, 1)
            Dim endDate As DateTime = startDate.AddMonths(1).AddDays(-1)
            ' MsgBox(endDate.ToShortDateString())
            Dim cmd As New SqlCommand("select COUNT(ptn) as 'Total',podate from plnr where actpodate IS NULL and podate between '" + startDate.ToString("dd MMM yyyy") + "' and '" + endDate.ToString("dd MMM yyyy") + "' group by podate")

            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)

            For Each row As DataRow In table1.Rows
                Dim appDay As DateTime = DateTime.Parse(row("podate"))

                Dim lab As New Label
                lab.Tag = row("podate")
                lab.Name = row("podate")
                lab.Text = "Click Below (" + row("Total").ToString + ")"
                lab.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                lab.ForeColor = Color.FromArgb(13, 72, 114)

                lab.Size = New Size(100, 15)
                lab.TextAlign = ContentAlignment.MiddleCenter
                lab.BackColor = Color.Transparent
                ' AddHandler lab.Click, AddressOf opendatagridview
                'lab.BackColor = Color.Azure

                listFlDay((appDay.Day - 1) + (startDayAtFlNumber - 1)).Controls.Add(lab)
                'Exit For
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetFirstDayOfWeekOfCurrentDate() As Integer
        Dim firstDayOfMonth As DateTime = New Date(currentDate.Year, currentDate.Month, 1)
        Return firstDayOfMonth.DayOfWeek + 1
    End Function

    Private Function GetTotalDaysOfCurrentDate() As Integer
        Dim firstDayOfCurrentDate As DateTime = New Date(currentDate.Year, currentDate.Month, 1)
        Return firstDayOfCurrentDate.AddMonths(1).AddDays(-1).Day
    End Function
    Private Sub DisplayCurrentDate()
        lblMonthAndYear.Text = currentDate.ToString("MMMM yyyy")
        Label1.Text = New DateTime(currentDate.Year, currentDate.Month, 1)
        Label2.Text = New DateTime(currentDate.Year, currentDate.Month, 1).AddMonths(1).AddDays(-1)
        Button1.Text = "Export Withdrawal Planner for " + lblMonthAndYear.Text
        Button2.Text = "Export Withdrawal Planner for " + currentDate.ToString("yyyy")
        Label3.Text = currentDate.ToString("yyyy")
        'currentDate.ToString("MMMM yyyy")
        Dim firstDayAtFlNumber As Integer = GetFirstDayOfWeekOfCurrentDate()
        Dim totalDay As Integer = GetTotalDaysOfCurrentDate()
        AddLabelDayToFlDay(firstDayAtFlNumber, totalDay)
        AddAppointmentToFlDay(firstDayAtFlNumber)
    End Sub

    Private Sub PrevMonth()
        currentDate = currentDate.AddMonths(-1)
        DisplayCurrentDate()
    End Sub

    Private Sub NextMonth()
        currentDate = currentDate.AddMonths(1)
        DisplayCurrentDate()
    End Sub

    Private Sub Today()
        currentDate = DateTime.Today
        DisplayCurrentDate()
    End Sub

    Private Sub GenerateDayPanel(ByVal totalDays As Integer)
        flDays.Controls.Clear()
        listFlDay.Clear()
        For i As Integer = 1 To totalDays
            Dim fl As New FlowLayoutPanel
            fl.Name = "flDay" & i
            fl.Size = New Size(125, 90)
            fl.BackColor = Color.White
            fl.BorderStyle = BorderStyle.FixedSingle

            fl.Cursor = Cursors.Hand
            fl.AutoScroll = True
            AddHandler fl.Click, AddressOf opendatagridview
            flDays.Controls.Add(fl)
            listFlDay.Add(fl)

        Next
    End Sub

    Private Sub AddLabelDayToFlDay(ByVal startDayAtFlNumber As Integer, ByVal totalDaysInMonth As Integer)
        For Each fl As FlowLayoutPanel In listFlDay
            fl.Controls.Clear()
            fl.Tag = 0
            fl.BackColor = Color.White
            Guna.UI.Lib.GraphicsHelper.DrawLineShadow(fl, Color.Black, 50, 50, Guna.UI.WinForms.VerHorAlign.HorizontalBottom)
        Next

        For i As Integer = 1 To totalDaysInMonth
            Dim lbl As New Label
            lbl.Name = i & "lblDay"
            lbl.AutoSize = False
            lbl.BackColor = Color.Transparent
            lbl.TextAlign = ContentAlignment.MiddleRight
            lbl.ForeColor = Color.FromArgb(13, 72, 114)
            lbl.Size = New Size(110, 22)
            lbl.Text = i
            lbl.Font = New Font("Segoe UI", 12)
            listFlDay((i - 1) + (startDayAtFlNumber - 1)).Tag = i
            listFlDay((i - 1) + (startDayAtFlNumber - 1)).Controls.Add(lbl)

            listFlDay((i - 1) + (startDayAtFlNumber - 1)).BackColor = Color.FromArgb(126, 221, 214)
            If New Date(currentDate.Year, currentDate.Month, i) = Date.Today Then
                listFlDay((i - 1) + (startDayAtFlNumber - 1)).BackColor = Color.Aqua
            End If

        Next
    End Sub

    Private Sub btnPrevMonth_Click(sender As Object, e As EventArgs) Handles btnPrevMonth.Click
        PrevMonth()
    End Sub

    Private Sub btnNextMonth_Click(sender As Object, e As EventArgs) Handles btnNextMonth.Click
        NextMonth()
    End Sub

    Private Sub btnToday_Click(sender As Object, e As EventArgs) Handles btnToday.Click
        Today()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.AppStarting
        Dim form As New exportmonthlywithdrawal
        form.Label1.Text = Label1.Text
        form.Label2.Text = Label2.Text
        form.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Cursor = Cursors.AppStarting
        Dim form As New exportyearlywithdrawal
        form.TextBox1.Text = Label3.Text
        form.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub
End Class