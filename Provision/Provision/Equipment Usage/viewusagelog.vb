Imports System.Data.SqlClient
Public Class viewusagelog
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub viewusagelog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadEquipmentLogs()
    End Sub
    Public Sub LoadEquipmentLogs()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            Dim ds As DataSet = New DataSet
            Dim adapter As New SqlDataAdapter
            Dim sql As String
            sql = "SELECT id,instr_name,instr_id,proname,btn,remark,startedby,starttime,endedby,endtime,cleancheckby,cleaningcheckon from instrument_usage where instr_use IS NULL order by id DESC"
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
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        ' MsgBox(e.ColumnIndex)
    End Sub
    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaGradientButton3_Click_1(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        MsgBox("Coming Soon", vbExclamation)
        'If DataGridView1.SelectedCells.Count > 0 Then
        'Dim form As New updateequipdetails
        'Form.Label1.Text = DataGridView1.SelectedCells(0).Value
        'Form.Owner = Me
        'Form.ShowDialog()
        'End If
    End Sub
End Class