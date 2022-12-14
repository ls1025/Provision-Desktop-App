Imports System.Data.SqlClient
Imports System.IO
'Imports System.Windows.Forms.DataVisualization.Charting

Public Class dashboardfrd
    Private WithEvents pic As New Button
    Dim dt As New DataTable()
    Dim instrumentpercent As Integer
    Dim analystpercent As Integer
    Dim productpercent As Integer

    Private Sub dashboardfrd_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Enabled = True

    End Sub
    '#####################Development#########################'
    Private Sub LoadIntimationDevYear()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select Year([requestdate]) AS Year from trdev where requestdate IS NOT NULL Group By Year([requestdate])"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("Year"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadIntimationDevYearWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT COUNT(trno) AS 'Total' ,Year([requestdate]) AS 'Year' from trdev where requestdate IS NOT NULL Group By Year([requestdate])", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart1.Series(0).Points.Clear()
        Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            Chart1.Series(0).Points.AddXY(table.Rows(i)(1).ToString, table.Rows(i)(0).ToString)
        Next
    End Sub
    Private Sub LoadIntimationDevMonthWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT COUNT(trno) AS 'Total' ,Month([requestdate]) AS 'Month' from trdev where requestdate IS NOT NULL and Year(requestdate)='" + ComboBox1.Text + "' Group By Month([requestdate]), year([requestdate])", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart1.Series(0).Points.Clear()
        Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 7.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            If table.Rows(i)(1).ToString = "1" Then
                Chart1.Series(0).Points.AddXY("Jan", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "2" Then
                Chart1.Series(0).Points.AddXY("Feb", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "3" Then
                Chart1.Series(0).Points.AddXY("Mar", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "4" Then
                Chart1.Series(0).Points.AddXY("Apr", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "5" Then
                Chart1.Series(0).Points.AddXY("May", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "6" Then
                Chart1.Series(0).Points.AddXY("Jun", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "7" Then
                Chart1.Series(0).Points.AddXY("Jul", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "8" Then
                Chart1.Series(0).Points.AddXY("Aug", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "9" Then
                Chart1.Series(0).Points.AddXY("Spe", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "10" Then
                Chart1.Series(0).Points.AddXY("Oct", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "11" Then
                Chart1.Series(0).Points.AddXY("Nov", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "12" Then
                Chart1.Series(0).Points.AddXY("Dec", table.Rows(i)(0).ToString)
            End If
        Next
    End Sub
    Private Sub LoadCancelIntimationDevYearWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT COUNT(trno) AS 'Total' ,Year([requestdate]) AS 'Year' from trdev where Status='Cancelled' Group By Year([requestdate])", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart1.Series(1).Points.Clear()
        Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            Chart1.Series(1).Points.AddXY(table.Rows(i)(1).ToString, table.Rows(i)(0).ToString)
        Next
    End Sub
    Private Sub LoadCancelIntimationDevMonthWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT COUNT(trno) AS 'Total' ,Month([requestdate]) AS 'Month' from trdev where Year(requestdate)='" + ComboBox1.Text + "' and Status='Cancelled' Group By Month([requestdate]), year([requestdate])", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart1.Series(1).Points.Clear()
        Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 7.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            If table.Rows(i)(1).ToString = "1" Then
                Chart1.Series(1).Points.AddXY("Jan", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "2" Then
                Chart1.Series(1).Points.AddXY("Feb", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "3" Then
                Chart1.Series(1).Points.AddXY("Mar", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "4" Then
                Chart1.Series(1).Points.AddXY("Apr", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "5" Then
                Chart1.Series(1).Points.AddXY("May", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "6" Then
                Chart1.Series(1).Points.AddXY("Jun", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "7" Then
                Chart1.Series(1).Points.AddXY("Jul", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "8" Then
                Chart1.Series(1).Points.AddXY("Aug", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "9" Then
                Chart1.Series(1).Points.AddXY("Spe", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "10" Then
                Chart1.Series(1).Points.AddXY("Oct", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "11" Then
                Chart1.Series(1).Points.AddXY("Nov", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "12" Then
                Chart1.Series(1).Points.AddXY("Dec", table.Rows(i)(0).ToString)
            End If
        Next
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        GunaRadioButton2.Checked = True
    End Sub
    Private Sub GunaRadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton1.CheckedChanged
        If GunaRadioButton1.Checked = True Then
            ComboBox1.SelectedIndex = -1
            LoadIntimationDevYearWise()
            LoadCancelIntimationDevYearWise()
        End If
    End Sub
    Private Sub GunaRadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton2.CheckedChanged
        If GunaRadioButton2.Checked = True Then
            If ComboBox1.Text = "" Then
            Else
                LoadIntimationDevMonthWise()
                LoadCancelIntimationDevMonthWise()
            End If
        End If
    End Sub
    Private Sub LoadRecentlyReleasedDataDev()
        Try

            FlowLayoutPanel1.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select productname,test from trdev where Status='Data Uploaded' and datauploaddate between @fromdate and @todate Group by productname,test order by productname ASC"
            cmd.Parameters.AddWithValue("@fromdate", SqlDbType.Date).Value = DateTime.Now.Date.AddDays(-4)
            cmd.Parameters.AddWithValue("@todate", SqlDbType.Date).Value = DateTime.Now.Date
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Button
                pic.Dock = DockStyle.Top
                pic.AutoSize = True
                pic.ForeColor = Color.FromArgb(0, 53, 92)
                pic.FlatStyle = FlatStyle.Flat
                pic.FlatAppearance.BorderSize = 0
                pic.Cursor = Cursors.Hand
                pic.Font = New Font("Segoe UI Semibold", 9.0F)
                pic.BackColor = Color.Aquamarine
                pic.Text = dr.Item("productname").ToString + "_" + dr.Item("test").ToString
                pic.Tag = dr.Item("productname").ToString
                pic.Name = dr.Item("test").ToString

                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf OpenReleasedDataDev

            End While
            dr.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub OpenReleasedDataDev(sender As Object, e As EventArgs)
        Dim form As New viewreleasedtrdev
        form.Label1.Text = sender.tag.ToString
        form.Label2.Text = sender.Name.ToString()
        form.ShowDialog()
    End Sub
    '#####################Routine#########################'
    Private Sub LoadIntimationRotYear()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select Year([requestdate]) AS Year from trrot where requestdate IS NOT NULL Group By Year([requestdate])"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr("Year"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadIntimationRotYearWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT COUNT(trno) AS 'Total' ,Year([requestdate]) AS 'Year' from trrot where requestdate IS NOT NULL Group By Year([requestdate])", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart2.Series(0).Points.Clear()
        Chart2.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            Chart2.Series(0).Points.AddXY(table.Rows(i)(1).ToString, table.Rows(i)(0).ToString)
        Next
    End Sub
    Private Sub LoadIntimationRotMonthWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT COUNT(trno) AS 'Total' ,Month([requestdate]) AS 'Month' from trrot where requestdate IS NOT NULL and Year(requestdate)='" + ComboBox2.Text + "' Group By Month([requestdate]), year([requestdate])", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart2.Series(0).Points.Clear()
        Chart2.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 7.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            If table.Rows(i)(1).ToString = "1" Then
                Chart2.Series(0).Points.AddXY("Jan", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "2" Then
                Chart2.Series(0).Points.AddXY("Feb", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "3" Then
                Chart2.Series(0).Points.AddXY("Mar", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "4" Then
                Chart2.Series(0).Points.AddXY("Apr", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "5" Then
                Chart2.Series(0).Points.AddXY("May", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "6" Then
                Chart2.Series(0).Points.AddXY("Jun", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "7" Then
                Chart2.Series(0).Points.AddXY("Jul", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "8" Then
                Chart2.Series(0).Points.AddXY("Aug", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "9" Then
                Chart2.Series(0).Points.AddXY("Spe", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "10" Then
                Chart2.Series(0).Points.AddXY("Oct", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "11" Then
                Chart2.Series(0).Points.AddXY("Nov", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "12" Then
                Chart2.Series(0).Points.AddXY("Dec", table.Rows(i)(0).ToString)
            End If
        Next
    End Sub
    Private Sub LoadCancelIntimationRotYearWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT COUNT(trno) AS 'Total' ,Year([requestdate]) AS 'Year' from trrot where Status='Cancelled' Group By Year([requestdate])", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart2.Series(1).Points.Clear()
        Chart2.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            Chart2.Series(1).Points.AddXY(table.Rows(i)(1).ToString, table.Rows(i)(0).ToString)
        Next
    End Sub
    Private Sub LoadCancelIntimationRotMonthWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT COUNT(trno) AS 'Total' ,Month([requestdate]) AS 'Month' from trrot where Year(requestdate)='" + ComboBox2.Text + "' and Status='Cancelled' Group By Month([requestdate]), year([requestdate])", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart2.Series(1).Points.Clear()
        Chart2.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 7.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            If table.Rows(i)(1).ToString = "1" Then
                Chart2.Series(1).Points.AddXY("Jan", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "2" Then
                Chart2.Series(1).Points.AddXY("Feb", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "3" Then
                Chart2.Series(1).Points.AddXY("Mar", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "4" Then
                Chart2.Series(1).Points.AddXY("Apr", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "5" Then
                Chart2.Series(1).Points.AddXY("May", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "6" Then
                Chart2.Series(1).Points.AddXY("Jun", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "7" Then
                Chart2.Series(1).Points.AddXY("Jul", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "8" Then
                Chart2.Series(1).Points.AddXY("Aug", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "9" Then
                Chart2.Series(1).Points.AddXY("Spe", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "10" Then
                Chart2.Series(1).Points.AddXY("Oct", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "11" Then
                Chart2.Series(1).Points.AddXY("Nov", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "12" Then
                Chart2.Series(1).Points.AddXY("Dec", table.Rows(i)(0).ToString)
            End If
        Next
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        GunaRadioButton3.Checked = True
    End Sub


    Private Sub GunaRadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton4.CheckedChanged
        If GunaRadioButton4.Checked = True Then
            ComboBox2.SelectedIndex = -1
            LoadIntimationRotYearWise()
            LoadCancelIntimationRotYearWise()
        End If
    End Sub

    Private Sub GunaRadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton3.CheckedChanged
        If GunaRadioButton3.Checked = True Then
            If ComboBox2.Text = "" Then
            Else
                LoadIntimationRotMonthWise()
                LoadCancelIntimationRotMonthWise()
            End If
        End If
    End Sub
    Private Sub LoadRecentlyReleasedDataRot()
        Try

            FlowLayoutPanel2.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select productname,test from trrot where Status='Data Uploaded' and datauploaddate between @fromdate and @todate Group by productname,test order by productname ASC"
            cmd.Parameters.AddWithValue("@fromdate", SqlDbType.Date).Value = DateTime.Now.Date.AddDays(-4)
            cmd.Parameters.AddWithValue("@todate", SqlDbType.Date).Value = DateTime.Now.Date
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Button
                pic.Dock = DockStyle.Top
                pic.AutoSize = True
                pic.ForeColor = Color.FromArgb(0, 53, 92)
                pic.FlatStyle = FlatStyle.Flat
                pic.FlatAppearance.BorderSize = 0
                pic.Cursor = Cursors.Hand
                pic.Font = New Font("Segoe UI Semibold", 9.0F)
                pic.BackColor = Color.Aquamarine
                pic.Text = dr.Item("productname").ToString + "_" + dr.Item("test").ToString
                pic.Tag = dr.Item("productname").ToString
                pic.Name = dr.Item("test").ToString

                FlowLayoutPanel2.Controls.Add(pic)
                AddHandler pic.Click, AddressOf OpenReleasedDataRot


            End While
            dr.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub OpenReleasedDataRot(sender As Object, e As EventArgs)
        Dim form As New viewreleasedtrrot
        form.Label1.Text = sender.tag.ToString
        form.Label2.Text = sender.Name.ToString()
        form.ShowDialog()
    End Sub

    '#####################Stability#########################'
    Private Sub LoadIntimationStbYear()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select Year([requestdate]) AS Year from trstb where requestdate IS NOT NULL Group By Year([requestdate])"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox3.Items.Add(dr("Year"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadIntimationStbYearWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT COUNT(trno) AS 'Total' ,Year([requestdate]) AS 'Year' from trstb where requestdate IS NOT NULL Group By Year([requestdate])", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart3.Series(0).Points.Clear()
        Chart3.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            Chart3.Series(0).Points.AddXY(table.Rows(i)(1).ToString, table.Rows(i)(0).ToString)
        Next
    End Sub
    Private Sub LoadIntimationstbMonthWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT COUNT(trno) AS 'Total' ,Month([requestdate]) AS 'Month' from trstb where requestdate IS NOT NULL and Year(requestdate)='" + ComboBox3.Text + "' Group By Month([requestdate]), year([requestdate])", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart3.Series(0).Points.Clear()
        Chart3.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 7.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            If table.Rows(i)(1).ToString = "1" Then
                Chart3.Series(0).Points.AddXY("Jan", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "2" Then
                Chart3.Series(0).Points.AddXY("Feb", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "3" Then
                Chart3.Series(0).Points.AddXY("Mar", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "4" Then
                Chart3.Series(0).Points.AddXY("Apr", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "5" Then
                Chart3.Series(0).Points.AddXY("May", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "6" Then
                Chart3.Series(0).Points.AddXY("Jun", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "7" Then
                Chart3.Series(0).Points.AddXY("Jul", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "8" Then
                Chart3.Series(0).Points.AddXY("Aug", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "9" Then
                Chart3.Series(0).Points.AddXY("Spe", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "10" Then
                Chart3.Series(0).Points.AddXY("Oct", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "11" Then
                Chart3.Series(0).Points.AddXY("Nov", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "12" Then
                Chart3.Series(0).Points.AddXY("Dec", table.Rows(i)(0).ToString)
            End If
        Next
    End Sub
    Private Sub LoadCancelIntimationStbYearWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT COUNT(trno) AS 'Total' ,Year([requestdate]) AS 'Year' from trstb where Status='Cancelled' Group By Year([requestdate])", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart3.Series(1).Points.Clear()
        Chart3.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            Chart3.Series(1).Points.AddXY(table.Rows(i)(1).ToString, table.Rows(i)(0).ToString)
        Next
    End Sub
    Private Sub LoadCancelIntimationStbMonthWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT COUNT(trno) AS 'Total' ,Month([requestdate]) AS 'Month' from trstb where Year(requestdate)='" + ComboBox3.Text + "' and Status='Cancelled' Group By Month([requestdate]), year([requestdate])", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart3.Series(1).Points.Clear()
        Chart3.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 7.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            If table.Rows(i)(1).ToString = "1" Then
                Chart3.Series(1).Points.AddXY("Jan", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "2" Then
                Chart3.Series(1).Points.AddXY("Feb", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "3" Then
                Chart3.Series(1).Points.AddXY("Mar", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "4" Then
                Chart3.Series(1).Points.AddXY("Apr", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "5" Then
                Chart3.Series(1).Points.AddXY("May", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "6" Then
                Chart3.Series(1).Points.AddXY("Jun", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "7" Then
                Chart3.Series(1).Points.AddXY("Jul", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "8" Then
                Chart3.Series(1).Points.AddXY("Aug", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "9" Then
                Chart3.Series(1).Points.AddXY("Spe", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "10" Then
                Chart3.Series(1).Points.AddXY("Oct", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "11" Then
                Chart3.Series(1).Points.AddXY("Nov", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "12" Then
                Chart3.Series(1).Points.AddXY("Dec", table.Rows(i)(0).ToString)
            End If
        Next
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        GunaRadioButton5.Checked = True
    End Sub


    Private Sub GunaRadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton6.CheckedChanged
        If GunaRadioButton6.Checked = True Then
            ComboBox3.SelectedIndex = -1
            LoadIntimationStbYearWise()
            LoadCancelIntimationStbYearWise()
        End If
    End Sub

    Private Sub GunaRadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton5.CheckedChanged
        If GunaRadioButton5.Checked = True Then
            If ComboBox3.Text = "" Then
            Else
                LoadIntimationstbMonthWise()
                LoadCancelIntimationStbMonthWise()
            End If
        End If
    End Sub
    Private Sub LoadRecentlyReleasedDataStb()
        Try

            FlowLayoutPanel3.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select productname,test from trstb where Status='Data Uploaded' and datauploaddate between @fromdate and @todate Group by productname,test order by productname ASC"
            cmd.Parameters.AddWithValue("@fromdate", SqlDbType.Date).Value = DateTime.Now.Date.AddDays(-4)
            cmd.Parameters.AddWithValue("@todate", SqlDbType.Date).Value = DateTime.Now.Date
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Button
                pic.Dock = DockStyle.Top
                pic.AutoSize = True
                pic.ForeColor = Color.FromArgb(0, 53, 92)
                pic.FlatStyle = FlatStyle.Flat
                pic.FlatAppearance.BorderSize = 0
                pic.Cursor = Cursors.Hand
                pic.Font = New Font("Segoe UI Semibold", 9.0F)
                pic.BackColor = Color.Aquamarine
                pic.Text = dr.Item("productname").ToString + "_" + dr.Item("test").ToString
                pic.Tag = dr.Item("productname").ToString
                pic.Name = dr.Item("test").ToString

                FlowLayoutPanel3.Controls.Add(pic)
                AddHandler pic.Click, AddressOf OpenReleasedDataStb

            End While
            dr.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub OpenReleasedDataStb(sender As Object, e As EventArgs)
        Dim form As New viewreleasedtrstb
        form.Label1.Text = sender.tag.ToString
        form.Label2.Text = sender.Name.ToString()
        form.ShowDialog()
    End Sub

    '############### CC Timer#############################'
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            'Development
            LoadIntimationDevYear()
            LoadIntimationDevYearWise()
            LoadCancelIntimationDevYearWise()

            'Routine
            LoadIntimationRotYear()
            LoadIntimationRotYearWise()
            LoadCancelIntimationRotYearWise()

            'Stability
            LoadIntimationStbYear()
            LoadIntimationStbYearWise()
            LoadCancelIntimationStbYearWise()

            LoadRecentlyReleasedDataDev()
            LoadRecentlyReleasedDataRot()
            LoadRecentlyReleasedDataStb()
            Timer1.Stop()

        Catch ex As Exception

        End Try
    End Sub

End Class