Imports System.Data.SqlClient
Public Class viewmaterialconsumpcategory
    Private Sub viewmaterialconsumpcategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.FromArgb(4, 145, 199), 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

        LoadTotalStockDetails()
    End Sub
    Private Sub LoadTotalStockDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("select category,COUNT(*) AS 'itemlist',(CAST(SUM(recievedqty) AS varchar)+' '+CAST(unit AS varchar)) AS 'recievedqty',(CAST(SUM(remainingqty) AS varchar)+' '+CAST(unit AS varchar)) AS 'remainingqty',SUM(totalprice) AS 'price' from inventry_master where remainingqty<>'0' group by category,unit order by [category] ASC")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
            ' DataGridView1.CurrentCell = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("select category,COUNT(*) AS 'itemlist',(CAST(SUM(recievedqty) AS varchar)+' '+CAST(unit AS varchar)) AS 'recievedqty',(CAST(SUM(remainingqty) AS varchar)+' '+CAST(unit AS varchar)) AS 'remainingqty',SUM(totalprice) AS 'price' from inventry_master where ([itemcode] like '%" & TextBox1.Text & "%' or [material_name] like '%" & TextBox1.Text & "%' or [gen_name] like '%" & TextBox1.Text & "%' or [brand_name] like '%" & TextBox1.Text & "%') and remainingqty<>'0' group by category,unit order by [category] ASC")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DataGridView1.Cursor = Cursors.WaitCursor
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
            DataGridView1.Cursor = Cursors.Default
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function _GetLetters(s As String) As String
        Return New String(s.Where(Function(x As Char) System.Char.IsLetter(x)).ToArray)
    End Function
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' MsgBox(e.ColumnIndex)
        If e.ColumnIndex = 1 Then
            Dim form As New viewmaterialconsumpdetails
            form.Label1.Text = DataGridView1.SelectedCells(1).Value + " >> " + DataGridView1.SelectedCells(4).Value
            form.Label3.Text = DataGridView1.SelectedCells(1).Value
            Dim unit As String = DataGridView1.SelectedCells(4).Value
            unit = (unit.Substring(unit.Length - 3)).Replace(" ", String.Empty)
            form.Label4.Text = _GetLetters(unit)
            form.Owner = Me
            form.WindowState = FormWindowState.Maximized
            form.ShowDialog()
        End If
    End Sub
End Class