Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class viewproductdetails
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

    Private Sub viewproductdetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadProductMaster()
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


    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.DataSourceChanged
        dgv1_rowstyle()
    End Sub


End Class