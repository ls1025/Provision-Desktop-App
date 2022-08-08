Imports System.Data.SqlClient
Public Class detailviewwithplnr
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub detailviewwithplnr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel3, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        loadwithdrawalplanner()

    End Sub
    Public Sub loadwithdrawalplanner()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select ID,cndn,sch,podate,actpodate,withbox,withby,withon,remark from plnr where proname='" + Label4.Text + "' and ptn= '" + Label3.Text + "' and [actpodate] IS NOT NULL")
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.RowIndex >= 0 Then


            If e.ColumnIndex = 5 Then
                Dim form As New upwithbox
                form.Owner = Me
                form.Label1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
                form.Label2.Text = Label4.Text
                form.ShowDialog()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' MessageBox.Show(e.ColumnIndex)
    End Sub
End Class