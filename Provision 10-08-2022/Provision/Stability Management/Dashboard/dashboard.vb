Imports System.Data.SqlClient
Imports System.IO
'Imports System.Windows.Forms.DataVisualization.Charting

Public Class dashboard

    Dim instrumentpercent As Integer
    Dim analystpercent As Integer
    Dim productpercent As Integer
    Private Sub dashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Enabled = True


    End Sub
    '#####################Charging Auto#########################'
    Dim ccperc As Integer
    Private Sub LoadChargingYear()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select Year([chrgdate]) AS 'Year' from plnr Group By Year([chrgdate]) order by 'Year' ASC"
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
    Private Sub LoadChargingGraphYearWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim dt As New DataTable()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT SUM(totalsampleqty) AS 'Total' ,Year([chrgdate]) AS 'Year' from plnr Group By Year([chrgdate]) order by 'Year' ASC", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart1.Series(0).Points.Clear()
        Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            Chart1.Series("Series1").Points.AddXY(table.Rows(i)(1).ToString, table.Rows(i)(0).ToString)
        Next
    End Sub

    Private Sub LoadChargingGraphMonthWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim dt As New DataTable()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT SUM(totalsampleqty) AS 'Total',Month([chrgdate]) AS 'Month' from plnr where Year(chrgdate)='" + ComboBox1.Text + "' Group By Month([chrgdate]), year([chrgdate]) order by 'Month' ASC", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart1.Series(0).Points.Clear()
        Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 7.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            If table.Rows(i)(1).ToString = "1" Then
                Chart1.Series("Series1").Points.AddXY("Jan", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "2" Then
                Chart1.Series("Series1").Points.AddXY("Feb", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "3" Then
                Chart1.Series("Series1").Points.AddXY("Mar", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "4" Then
                Chart1.Series("Series1").Points.AddXY("Apr", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "5" Then
                Chart1.Series("Series1").Points.AddXY("May", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "6" Then
                Chart1.Series("Series1").Points.AddXY("Jun", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "7" Then
                Chart1.Series("Series1").Points.AddXY("Jul", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "8" Then
                Chart1.Series("Series1").Points.AddXY("Aug", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "9" Then
                Chart1.Series("Series1").Points.AddXY("Spe", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "10" Then
                Chart1.Series("Series1").Points.AddXY("Oct", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "11" Then
                Chart1.Series("Series1").Points.AddXY("Nov", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "12" Then
                Chart1.Series("Series1").Points.AddXY("Dec", table.Rows(i)(0).ToString)
            End If
        Next
    End Sub
    '#####################Withdrawal Auto#########################'

    Private Sub LoadWithdrawalYear()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select Year([withon]) AS 'Year' from plnr where withon IS NOT NULL Group By Year([withon]) order by 'Year' ASC"
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
    Private Sub LoadWithdrawalGraphYearWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim dt As New DataTable()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT SUM(totalsampleqty) AS 'Total' ,Year([withon]) AS 'Year' from plnr where withon IS NOT NULL Group By Year([withon]) order by 'Year' ASC", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart2.Series(0).Points.Clear()
        Chart2.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            Chart2.Series("Series1").Points.AddXY(table.Rows(i)(1).ToString, table.Rows(i)(0).ToString)
        Next
    End Sub

    Private Sub LoadWithdrawalGraphMonthWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim dt As New DataTable()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT SUM(totalsampleqty) AS 'Total' ,Month([withon]) AS 'Month' from plnr where Year(withon)='" + ComboBox2.Text + "' and withon IS NOT NULL Group By Month([withon]), year([withon]) order by 'Month' ASC", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart2.Series(0).Points.Clear()
        Chart2.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 7.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            If table.Rows(i)(1).ToString = "1" Then
                Chart2.Series("Series1").Points.AddXY("Jan", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "2" Then
                Chart2.Series("Series1").Points.AddXY("Feb", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "3" Then
                Chart2.Series("Series1").Points.AddXY("Mar", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "4" Then
                Chart2.Series("Series1").Points.AddXY("Apr", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "5" Then
                Chart2.Series("Series1").Points.AddXY("May", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "6" Then
                Chart2.Series("Series1").Points.AddXY("Jun", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "7" Then
                Chart2.Series("Series1").Points.AddXY("Jul", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "8" Then
                Chart2.Series("Series1").Points.AddXY("Aug", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "9" Then
                Chart2.Series("Series1").Points.AddXY("Spe", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "10" Then
                Chart2.Series("Series1").Points.AddXY("Oct", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "11" Then
                Chart2.Series("Series1").Points.AddXY("Nov", table.Rows(i)(0).ToString)
            End If
            If table.Rows(i)(1).ToString = "12" Then
                Chart2.Series("Series1").Points.AddXY("Dec", table.Rows(i)(0).ToString)
            End If
        Next
    End Sub
    '################### Sample Issuanc#################'
    Private Sub LoadIssuedSample()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim dt As New DataTable()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT SUM(sampleqty) AS 'Total' from recon", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart3.Series(0).Points.Clear()
        Chart3.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            Chart3.Series("Series1").Points.AddXY("Issued Sample", table.Rows(i)(0).ToString)
        Next
        'Chart3.Series("Series1").Color = Color.LightGreen
    End Sub
    Private Sub LoadUnIssuedSample()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim dt As New DataTable()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("SELECT SUM(availsampleqty) AS 'Total' from plnr where actpodate IS NOT NULL", con)
        Dim table As New DataTable()
        da.Fill(table)
        ' Chart3.Series(0).Points.Clear()
        Chart3.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        For i As Integer = 0 To table.Rows.Count - 1
            Chart3.Series("Series1").Points.AddXY("Un Issued Sample", table.Rows(i)(0).ToString)
        Next
        'Chart3.Series("Series1").Color = Color.Red
    End Sub
    '##############Chamber Capacity###################1'
    Private Sub LoadChmaberCapacity()

        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim dt As New DataTable()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("select COUNT(DISTINCT(chrgbox)) AS 'Total',cndn from  plnr where chrgbox IS NOT NULL group by cndn", con)
        Dim table As New DataTable()
        da.Fill(table)
        Chart4.Series(0).Points.Clear()
        Chart4.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
        For i As Integer = 0 To table.Rows.Count - 1

            Chart4.Series("Series1").Points.AddXY(table.Rows(i)(1).ToString + " ( " + table.Rows(i)(0).ToString + " )", table.Rows(i)(0).ToString)
            ' MsgBox(table.Rows(i)(0).ToString)
        Next
        '25/60
        If table.Rows(0)(0) <= 50 Then
            Chart4.Series("Series1").Points(0).Color = Color.Green
        ElseIf table.Rows(0)(0) > 50 And table.Rows(0)(0) < 99 Then
            Chart4.Series("Series1").Points(0).Color = Color.Orange
        ElseIf table.Rows(0)(0) >= 100 Then
            Chart4.Series("Series1").Points(0).Color = Color.Red
        End If

        '30/75
        If table.Rows(1)(0) <= 50 Then
            Chart4.Series("Series1").Points(1).Color = Color.Green
        ElseIf table.Rows(1)(0) > 50 And table.Rows(1)(0) < 99 Then
            Chart4.Series("Series1").Points(1).Color = Color.Orange
        ElseIf table.Rows(1)(0) >= 100 Then
            Chart4.Series("Series1").Points(1).Color = Color.Red
        End If

        '40/60
        If table.Rows(2)(0) <= 50 Then
            Chart4.Series("Series1").Points(2).Color = Color.Green
        ElseIf table.Rows(2)(0) > 50 And table.Rows(2)(0) < 99 Then
            Chart4.Series("Series1").Points(2).Color = Color.Orange
        ElseIf table.Rows(2)(0) >= 100 Then
            Chart4.Series("Series1").Points(2).Color = Color.Red
        End If

        ' Chart4.Series("Series1").Points(1).Color = Color.White
        'Chart3.Series("Series1").Color = Color.LightGreen
    End Sub
    Dim tooltip As ToolTip = New ToolTip()
    Dim prevPosition As Point? = Nothing
    Private Sub Chart4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim pos = e.Location
        If prevPosition.HasValue AndAlso pos = prevPosition.Value Then Return
        tooltip.RemoveAll()
        prevPosition = pos
        Dim results = Chart4.HitTest(pos.X, pos.Y, False, System.Windows.Forms.DataVisualization.Charting.ChartElementType.PlottingArea)

        For Each result In results

            If result.ChartElementType = System.Windows.Forms.DataVisualization.Charting.ChartElementType.PlottingArea Then
                Chart4.Series(0).ToolTip = "X=#VALX, Y=#VALY"
            End If
        Next


    End Sub
    '############### CC Timer#############################'
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            LoadChargingYear()
            LoadChargingGraphYearWise()

            LoadWithdrawalYear()
            LoadWithdrawalGraphYearWise()

            LoadIssuedSample()
            LoadUnIssuedSample()

            LoadChmaberCapacity()

            Timer1.Stop()

        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        GunaRadioButton2.Checked = True
    End Sub
    Private Sub GunaRadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton1.CheckedChanged
        If GunaRadioButton1.Checked = True Then
            ComboBox1.SelectedIndex = -1
            LoadChargingGraphYearWise()
        End If
    End Sub
    Private Sub GunaRadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton2.CheckedChanged
        If GunaRadioButton2.Checked = True Then
            If ComboBox1.Text = "" Then
            Else
                LoadChargingGraphMonthWise()
            End If
        End If
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        GunaRadioButton3.Checked = True
    End Sub
    Private Sub GunaRadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton4.CheckedChanged
        If GunaRadioButton4.Checked = True Then
            ComboBox2.SelectedIndex = -1
            LoadWithdrawalGraphYearWise()
        End If
    End Sub
    Private Sub GunaRadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton3.CheckedChanged
        If GunaRadioButton3.Checked = True Then
            If ComboBox2.Text = "" Then
            Else
                LoadWithdrawalGraphMonthWise()
            End If
        End If
    End Sub


    Private Function pieHitPointIndex(ByVal pie As System.Windows.Forms.DataVisualization.Charting.Chart, ByVal e As MouseEventArgs) As Integer
        Dim hitPiece As System.Windows.Forms.DataVisualization.Charting.HitTestResult = pie.HitTest(e.X, e.Y, System.Windows.Forms.DataVisualization.Charting.ChartElementType.DataPoint)
        Dim hitLegend As System.Windows.Forms.DataVisualization.Charting.HitTestResult = pie.HitTest(e.X, e.Y, System.Windows.Forms.DataVisualization.Charting.ChartElementType.LegendItem)
        Dim pointIndex As Integer = -1
        If hitPiece.Series IsNot Nothing Then pointIndex = hitPiece.PointIndex
        If hitLegend.Series IsNot Nothing Then pointIndex = hitLegend.PointIndex
        Return pointIndex
    End Function
    Private Sub Chart3_MouseClick111(sender As Object, e As MouseEventArgs) Handles Chart3.MouseClick
        Dim result As System.Windows.Forms.DataVisualization.Charting.HitTestResult = Chart3.HitTest(e.X, e.Y)

        If result.ChartElementType = System.Windows.Forms.DataVisualization.Charting.ChartElementType.DataPoint Then
            Me.Cursor = Cursors.AppStarting
            Dim selectedDataPoint As System.Windows.Forms.DataVisualization.Charting.DataPoint = CType(result.Object, System.Windows.Forms.DataVisualization.Charting.DataPoint)
            'Dim value As String = selectedDataPoint.YValues(0).ToString
            'MessageBox.Show(result.Series.Name & ": Y-value： " + selectedDataPoint.YValues(0).ToString)
            'ElseIf result.ChartElementType <> System.Windows.Forms.DataVisualization.Charting.ChartElementType.[Nothing] Then
            ' Dim elementType As String = result.ChartElementType.ToString()
            ' MessageBox.Show(Me, "Selected Element is: " & elementType)

            Dim form As New issuedunissuedsample
            form.ShowDialog()
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub chart3_GetToolTipText(sender As Object, e As System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs) Handles Chart3.GetToolTipText
        ' Check selected chart element and set tooltip text for it
        Select Case e.HitTestResult.ChartElementType
            Case System.Windows.Forms.DataVisualization.Charting.ChartElementType.DataPoint
                Dim dataPoint = e.HitTestResult.Series.Points(e.HitTestResult.PointIndex)
                e.Text = dataPoint.YValues(0).ToString
                ToolTip1.SetToolTip(Chart3, e.Text)
                Exit Select
        End Select
    End Sub
    Private Sub Chart3_MouseMove(sender As Object, e As MouseEventArgs) Handles Chart3.MouseMove
        Dim pie As System.Windows.Forms.DataVisualization.Charting.Chart = CType(sender, System.Windows.Forms.DataVisualization.Charting.Chart)
        Dim pointIndex As Integer = pieHitPointIndex(pie, e)

        If pointIndex >= 0 Then
            Cursor = Cursors.Hand
        Else
            Cursor = Cursors.[Default]
        End If
    End Sub

    Private Sub Chart3_Click(sender As Object, e As EventArgs) Handles Chart3.Click

    End Sub
End Class