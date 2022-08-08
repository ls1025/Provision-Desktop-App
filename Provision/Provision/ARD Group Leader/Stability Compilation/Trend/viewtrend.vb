
Imports System.Data.SqlClient

Public Class viewtrend
    Public Property Year As Integer
    Public Property Month As Integer
    Public Property Value As Double
    Private Sub viewtrend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadTest()
        LoadCondition()
    End Sub
    Private Sub LoadTest()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(test) from stbcomp_general where btn='" + Label1.Text + "' order by test ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("test"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadCondition()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(gen_cndn) from stbcomp_general where btn='" + Label1.Text + "' and gen_cndn<>'Initial' order by gen_cndn ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr("gen_cndn"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim da As New SqlDataAdapter()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("SELECT gen_seq,gen_period,SUM(CAST(gen_result AS float)) as 'Total' from stbcomp_general where test='" + ComboBox1.Text + "' and gen_cndn='" + ComboBox2.Text + "' or gen_cndn='Initial' Group By gen_period,gen_seq  order by gen_seq ASC", con)
            Dim table As New DataTable()
            da.Fill(table)
            Chart1.Series(0).Points.Clear()
            Chart1.Series(0).Name = ComboBox1.Text + "-" + ComboBox2.Text
            Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
            For i As Integer = 0 To table.Rows.Count - 1
                If table.Rows(i)(1).ToString = "NA" Then
                    Chart1.Series(0).Points.AddXY("Initial", table.Rows(i)(2).ToString)
                Else
                    Chart1.Series(0).Points.AddXY(table.Rows(i)(1).ToString, table.Rows(i)(2).ToString)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim da As New SqlDataAdapter()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("SELECT gen_seq,gen_period,SUM(CAST(gen_result AS float)) as 'Total' from stbcomp_general where test='" + ComboBox1.Text + "' and gen_cndn='" + ComboBox2.Text + "' or gen_cndn='Initial' Group By gen_period,gen_seq  order by gen_seq ASC", con)
            Dim table As New DataTable()
            da.Fill(table)
            Chart1.Series(0).Points.Clear()
            Chart1.Series(0).Name = ComboBox1.Text + "-" + ComboBox2.Text
            Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
            For i As Integer = 0 To table.Rows.Count - 1
                If table.Rows(i)(1).ToString = "NA" Then
                    Chart1.Series(0).Points.AddXY("Initial", table.Rows(i)(2).ToString)
                Else
                    Chart1.Series(0).Points.AddXY(table.Rows(i)(1).ToString, table.Rows(i)(2).ToString)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
End Class