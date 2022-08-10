Imports System.Data.SqlClient
Public Class viewpartwithsample
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub viewpartwithsample_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LaodPartWithdrawalSample()
    End Sub
    Public Sub LaodPartWithdrawalSample()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            Dim ds As DataSet = New DataSet
            Dim adapter As New SqlDataAdapter
            Dim sql As String

            sql = "SELECT plnr.ID,plnr.proname,plnr.strength,plnr.btn,plnr.ptn,plnr.cndn,plnr.chrgdate,plnr.sch,plnr.totalsampleqty,plnr_partwith.sampleqty,plnr_partwith.remainqty,plnr_partwith.withdate,plnr_partwith.filenote FROM plnr INNER JOIN plnr_partwith on plnr.ID=plnr_partwith.ref_id order by plnr_partwith.withdate DESC"

            adapter.SelectCommand = New SqlCommand(sql, con)
            adapter.Fill(ds, sql)
            DataGridView1.DataSource = ds.Tables(sql)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
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

    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            If DataGridView1.SelectedCells(10).Value = 0 Then
                MsgBox("No Samples Available", vbExclamation)
            Else
                Dim form As New issuepartwithsample
                form.Label1.Text = DataGridView1.SelectedCells(0).Value

                form.Label2.Text = DataGridView1.SelectedCells(10).Value
                form.Owner = Me
                form.ShowDialog()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        ' MsgBox(e.ColumnIndex)
    End Sub
End Class