Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Public Class updatestbcompilation
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub updatestbcompilation_Load(sender As Object, e As EventArgs) Handles Me.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadStbCompilationDetails()
        LoadGeneral()
        LoadDissoDetails()
        LoadImpurityDetails()
        LoadTest()
        ' LoadDissoTimepoints()
    End Sub
    Private Sub LoadStbCompilationDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim da As New SqlDataAdapter()
            Dim table As New DataTable()
            Dim dt As New DataTable()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select * from stbcomp_master where [btn]= '" + TextBox2.Text + "' ", con)
            da.Fill(table)

            'Product Name and Strength
            TextBox1.Text = table.Rows(0)(2).ToString + " " + table.Rows(0)(3).ToString
            'Pack Style
            TextBox3.Text = table.Rows(0)(5).ToString
            'Label Claim
            TextBox4.Text = table.Rows(0)(6).ToString
            'Charging Date
            Label1.Text = table.Rows(0)(7).ToString

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadGeneral()
        Try
            DataGridView1.Rows.Clear()

            'Get PDS Details with product name
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds1 As DataSet = New DataSet
            Dim da1 As New SqlDataAdapter()
            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            da1 = New SqlDataAdapter("select [gen_cndn],[gen_period],[test],[gen_result],[gen_limit] from stbcomp_general where [btn]='" + TextBox2.Text + "' order by gen_seq ASC", con)
            Dim table1 As New DataTable()
            da1.Fill(table1)

            For i = 0 To table1.Rows.Count - 1
                DataGridView1.Rows.Add(table1.Rows(i)(0).ToString(), table1.Rows(i)(1).ToString(), table1.Rows(i)(2).ToString(), table1.Rows(i)(3).ToString(), table1.Rows(i)(4).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadDissoDetails()
        Try
            DataGridView2.Rows.Clear()

            'Get PDS Details with product name
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds1 As DataSet = New DataSet
            Dim da1 As New SqlDataAdapter()
            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            da1 = New SqlDataAdapter("select [disso_cndn],[disso_period],[timepoint],[min],[max],[avg],[rsd] from stbcomp_disso where [btn]='" + TextBox2.Text + "' order by disso_seq ASC", con)
            Dim table1 As New DataTable()
            da1.Fill(table1)

            For i = 0 To table1.Rows.Count - 1
                DataGridView2.Rows.Add(table1.Rows(i)(0).ToString(), table1.Rows(i)(1).ToString(), table1.Rows(i)(2).ToString(), table1.Rows(i)(3).ToString(), table1.Rows(i)(4).ToString(), table1.Rows(i)(5).ToString(), table1.Rows(i)(6).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadImpurityDetails()
        Try
            DataGridView3.Rows.Clear()

            'Get PDS Details with product name
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds1 As DataSet = New DataSet
            Dim da1 As New SqlDataAdapter()
            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            da1 = New SqlDataAdapter("select [impurity],[rrt],[imp_cndn],[imp_period],[imp_result],[imp_limit] from stbcomp_impurity where [btn]='" + TextBox2.Text + "' order by imp_seq ASC", con)
            Dim table1 As New DataTable()
            da1.Fill(table1)

            For i = 0 To table1.Rows.Count - 1
                DataGridView3.Rows.Add(table1.Rows(i)(0).ToString(), table1.Rows(i)(1).ToString(), table1.Rows(i)(2).ToString(), table1.Rows(i)(3).ToString(), table1.Rows(i)(4).ToString(), table1.Rows(i)(5).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadTest()
        If con.State = ConnectionState.Open Then con.Close()
        Dim reader As SqlDataReader
        Try
            con.Open()
            Dim qry As String
            qry = "SELECT DISTINCT(test) FROM testmaster order by test ASC"
            cmd1 = New SqlCommand(qry, con)
            reader = cmd1.ExecuteReader
            While reader.Read
                Dim Gen_Test As DataGridViewComboBoxColumn = DataGridView1.Columns(2)
                Gen_Test.Items.Add(reader("test"))
            End While
            con.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub LoadDissoTimepoints()
        If con.State = ConnectionState.Open Then con.Close()
        Dim reader As SqlDataReader
        Try
            con.Open()
            Dim qry As String
            qry = "SELECT DISTINCT(timepoint) FROM stbcomp_disso_timepoint order by timepoint ASC"
            cmd1 = New SqlCommand(qry, con)
            reader = cmd1.ExecuteReader
            While reader.Read
                Dim Disso_Timepoints As DataGridViewComboBoxColumn = DataGridView2.Columns(2)
                Disso_Timepoints.Items.Add(reader("timepoint"))
            End While
            con.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            UpdateGeneralTest()
            UpdateDissoTest()
            UpdateImpurities()

            MsgBox("Stability Compilation Details Updated Successfully", vbInformation)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub UpdateGeneralTest()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "delete from [stbcomp_general] where [btn]='" + TextBox2.Text + "'"
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()

        For i As Integer = 0 To DataGridView1.Rows.Count - 2
            Dim gen_period As Integer
            If DataGridView1.Rows(i).Cells(1).Value = "NA" Then
                gen_period = 0
            Else
                gen_period = Integer.Parse(Regex.Replace(DataGridView1.Rows(i).Cells(1).Value, "[^\d]", ""))
            End If

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "insert into stbcomp_general(btn,gen_cndn,gen_period,test,gen_result,gen_limit,gen_seq) values('" + TextBox2.Text + "','" + DataGridView1.Rows(i).Cells(0).Value + "','" + DataGridView1.Rows(i).Cells(1).Value + "','" + DataGridView1.Rows(i).Cells(2).Value + "','" + DataGridView1.Rows(i).Cells(3).Value + "','" + DataGridView1.Rows(i).Cells(4).Value + "','" + gen_period.ToString + "')"
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
    End Sub
    Private Sub UpdateDissoTest()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "delete from [stbcomp_disso] where [btn]='" + TextBox2.Text + "'"
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()

        For i As Integer = 0 To DataGridView2.Rows.Count - 2
            Dim disso_period As Integer
            If DataGridView2.Rows(i).Cells(1).Value = "NA" Then
                disso_period = 0
            Else
                disso_period = Integer.Parse(Regex.Replace(DataGridView2.Rows(i).Cells(1).Value, "[^\d]", ""))
            End If

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "insert into stbcomp_disso(btn,disso_cndn,disso_period,timepoint,min,max,avg,rsd,disso_seq) values('" + TextBox2.Text + "','" + DataGridView2.Rows(i).Cells(0).Value + "','" + DataGridView2.Rows(i).Cells(1).Value + "','" + DataGridView2.Rows(i).Cells(2).Value + "','" + DataGridView2.Rows(i).Cells(3).Value + "','" + DataGridView2.Rows(i).Cells(4).Value + "','" + DataGridView2.Rows(i).Cells(5).Value + "','" + DataGridView2.Rows(i).Cells(6).Value + "','" + disso_period.ToString + "')"
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
    End Sub
    Private Sub UpdateImpurities()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "delete from [stbcomp_impurity] where [btn]='" + TextBox2.Text + "'"
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()

        For i As Integer = 0 To DataGridView3.Rows.Count - 2
            Dim imp_period As Integer
            If DataGridView3.Rows(i).Cells(3).Value = "NA" Then
                imp_period = 0
            Else
                imp_period = Integer.Parse(Regex.Replace(DataGridView3.Rows(i).Cells(3).Value, "[^\d]", ""))
            End If

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "insert into stbcomp_impurity(btn,impurity,rrt,imp_cndn,imp_period,imp_result,imp_limit,imp_seq) values('" + TextBox2.Text + "','" + DataGridView3.Rows(i).Cells(0).Value + "','" + DataGridView3.Rows(i).Cells(1).Value + "','" + DataGridView3.Rows(i).Cells(2).Value + "','" + DataGridView3.Rows(i).Cells(3).Value + "','" + DataGridView3.Rows(i).Cells(4).Value + "','" + DataGridView3.Rows(i).Cells(5).Value + "','" + imp_period.ToString + "')"
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Public Sub dgv1_rowstyle()
        Try
            For i As Integer = 0 To DataGridView1.RowCount - 2
                If i Mod 2 = 0 Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
                Else
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
                End If
            Next
            DataGridView1.CurrentCell = Nothing
        Catch ex As Exception

        End Try

    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick

        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.DataSourceChanged
        dgv1_rowstyle()
    End Sub
    Public Sub dgv2_rowstyle()
        Try
            For i As Integer = 0 To DataGridView1.RowCount - 1
                If i Mod 2 = 0 Then
                    DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.White
                Else
                    DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
                End If
            Next
            DataGridView2.CurrentCell = Nothing
        Catch ex As Exception

        End Try

    End Sub
    Private Sub DataGridView2_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.ColumnHeaderMouseClick
        dgv2_rowstyle()
    End Sub
    Private Sub DataGridView2_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView2.DataSourceChanged
        dgv2_rowstyle()
    End Sub
    Public Sub dgv3_rowstyle()
        Try
            For i As Integer = 0 To DataGridView1.RowCount - 1
                If i Mod 2 = 0 Then
                    DataGridView3.Rows(i).DefaultCellStyle.BackColor = Color.White
                Else
                    DataGridView3.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
                End If
            Next
            DataGridView3.CurrentCell = Nothing
        Catch ex As Exception

        End Try

    End Sub
    Private Sub DataGridView3_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView3.ColumnHeaderMouseClick
        dgv3_rowstyle()
    End Sub
    Private Sub DataGridView3_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView3.DataSourceChanged
        dgv3_rowstyle()
    End Sub
    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        Try
            If DataGridView1.SelectedRows.Count > 0 Then
                DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
            Else
                MessageBox.Show("Select 1 atleast one row to delete")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Try
            If DataGridView2.SelectedRows.Count > 0 Then
                DataGridView2.Rows.Remove(DataGridView2.SelectedRows(0))
            Else
                MessageBox.Show("Select 1 atleast one row to delete")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub GunaGradientButton5_Click(sender As Object, e As EventArgs) Handles GunaGradientButton5.Click
        Try
            If DataGridView3.SelectedRows.Count > 0 Then
                DataGridView3.Rows.Remove(DataGridView3.SelectedRows(0))
            Else
                MessageBox.Show("Select 1 atleast one row to delete")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DataGridView2_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView2.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DataGridView3_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView3.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class