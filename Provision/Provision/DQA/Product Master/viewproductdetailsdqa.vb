Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class viewproductdetailsdqa
    Public Sub dgv1_rowstyle()
        For i As Integer = 0 To DataGridView1.RowCount - 1
            If i Mod 2 = 0 Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If

        Next
        DataGridView1.CurrentCell = Nothing
    End Sub

    Private Sub viewproductdetailsdqa_Load(sender As Object, e As EventArgs) Handles Me.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadProductMaster()
        LoadPDSStatusAndClient()
    End Sub
    Public Sub LoadProductMaster()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select [id],[procode],[strength],[label],[productaddedby],[productaddeddate],[productstatus] from productmaster where [proname]='" + Label1.Text + "' and market='" + Label2.Text + "' order by [id] DESC")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
            dgv1_rowstyle()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadPDSStatusAndClient()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim da As New SqlDataAdapter()
            Dim dt As New DataTable()
            Dim table As New DataTable()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select client,pds from productmaster where [proname]= '" + Label1.Text + "' and [market]='" + Label2.Text + "'", con)
            da.Fill(table)

            GunaLabel3.Text = table.Rows(0)(0).ToString
            GunaLabel1.Text = table.Rows(0)(1).ToString
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.DataSourceChanged
        dgv1_rowstyle()
    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New addstrength
        form.TextBox1.Text = Label1.Text
        form.TextBox2.Text = Label2.Text
        form.GunaLabel4.Text = GunaLabel1.Text
        form.GunaLabel6.Text = GunaLabel3.Text
        form.Owner = Me
        form.ShowDialog()
    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Dim form As New viewattachments
        form.Label1.Text = Label1.Text
        form.Label2.Text = Label2.Text
        form.Label3.Text = GunaLabel3.Text
    End Sub
End Class