Imports System.Data.OleDb
Public Class masters
    Dim da As New OleDbDataAdapter()
    Dim dt As New DataTable()
  
    Public Sub dgv1_rowstyle()
        For i As Integer = 0 To DataGridView1.RowCount - 1
            If i Mod 2 = 0 Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If

        Next
    End Sub
    Public Sub dgv2_rowstyle()
        For i As Integer = 0 To DataGridView2.RowCount - 1
            If i Mod 2 = 0 Then
                DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If

        Next
    End Sub
    Public Sub dgv3_rowstyle()
        For i As Integer = 0 To DataGridView3.RowCount - 1
            If i Mod 2 = 0 Then
                DataGridView3.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView3.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If

        Next
    End Sub
    Private Sub masters_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgv1_rowstyle()
        dgv2_rowstyle()
        loadproname()
        loadcondn()
        loadgenericname()
        loadpack()
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        DataGridView1.CurrentCell = Nothing
        DataGridView2.CurrentCell = Nothing
    End Sub
    Public Sub loadproname()
        Try


            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New OleDbCommand
            cmd.Connection = con
            da = New OleDbDataAdapter("Select proname from proname order by proname asc", con)
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            dgv1_rowstyle()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub loadcondn()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        da = New OleDbDataAdapter("Select instid,cond from chamber", con)
        da.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
    End Sub
    Public Sub loadgenericname()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        da = New OleDbDataAdapter("Select genericname from genericname order by genericname ASC", con)
        da.Fill(ds)
        DataGridView3.DataSource = ds.Tables(0)
    End Sub
    Public Sub loadpack()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim cmd As New OleDbCommand
        cmd.Connection = con
        da = New OleDbDataAdapter("Select pack from pack order by pack ASC", con)
        da.Fill(ds)
        DataGridView4.DataSource = ds.Tables(0)
    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.DataSourceChanged
        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView2_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.ColumnHeaderMouseClick
        dgv2_rowstyle()
    End Sub
    Private Sub DataGridView2_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView2.DataSourceChanged
        dgv2_rowstyle()
    End Sub
    Private Sub DataGridView3_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView3.ColumnHeaderMouseClick
        dgv3_rowstyle()
    End Sub
    Private Sub DataGridView3_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView3.DataSourceChanged
        dgv3_rowstyle()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form As New addpro()
        form.Owner = Me
        form.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim form As New addcon()
        form.Owner = Me
        form.ShowDialog()
    End Sub
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        filterdata(TextBox1.Text)
        dgv1_rowstyle()
    End Sub
    Private Sub filterdata(ValueTosearch As String)
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New OleDbCommand("Select proname from proname  where proname like '%" & ValueTosearch & "%'")
            cmd.Connection = con
            Dim adapter1 As New OleDbDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        filterdata1(TextBox2.Text)
        dgv2_rowstyle()
    End Sub
    Private Sub filterdata1(ValueTosearch As String)
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New OleDbCommand("Select instid,cond from chamber  where [instid] like '%" & ValueTosearch & "%' or [cond] like '%" & ValueTosearch & "%' ")
            cmd.Connection = con
            Dim adapter1 As New OleDbDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView2.DataSource = table1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs)
        TextBox1.Clear()
        TextBox2.Clear()
        loadproname()
        loadcondn()
        DataGridView1.CurrentCell = Nothing
        DataGridView2.CurrentCell = Nothing
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New addgenericname
        form.Owner = Me
        form.ShowDialog()
    End Sub
    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox3.TextChanged
        filterdata2(TextBox3.Text)
        dgv3_rowstyle()
    End Sub
    Private Sub filterdata2(ValueTosearch As String)
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New OleDbCommand("Select genericname from genericname where [genericname] like '%" & ValueTosearch & "%'")
            cmd.Connection = con
            Dim adapter1 As New OleDbDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView3.DataSource = table1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub TextBox4_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox4.TextChanged
        filterdata3(TextBox4.Text)
        dgv3_rowstyle()
    End Sub
    Private Sub filterdata3(ValueTosearch As String)
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New OleDbCommand("Select pack from pack where [pack] like '%" & ValueTosearch & "%'")
            cmd.Connection = con
            Dim adapter1 As New OleDbDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView4.DataSource = table1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Dim form As New addpack
        form.Owner = Me
        form.ShowDialog()
    End Sub
End Class