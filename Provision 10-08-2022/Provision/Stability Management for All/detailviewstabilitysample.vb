Imports System.Data.SqlClient
Public Class detailviewstabilitysample
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub detailviewstabilitysample_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel3, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadChargingPlanner()

    End Sub
    Public Sub LoadChargingPlanner()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select ID,pccnt,cndn,sch,podate,totalsampleqty,availsampleqty from plnr where proname='" + Label6.Text + "' and ptn= '" + Label3.Text + "'")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
            GunaLabel2.Text = "Records: " + DataGridView1.Rows.Count.ToString
            dgv1_rowstyle()
            DataGridView1.CurrentCell = Nothing

        Catch ex As Exception

        End Try

    End Sub
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
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.DataSourceChanged
        dgv1_rowstyle()
    End Sub


End Class