Imports System.Data.SqlClient
Public Class viewcorrectionsdocs
    Private Sub viewcorrectionsdocs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDocumentDetails()
    End Sub
    Public Sub LoadDocumentDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("SELECT archival_master.id,archival_correction.id,archival_master.doctype,archival_master.catogery,archival_master.docname,archival_master.docno,archival_correction.corrections,archival_correction.returnby,archival_correction.returnto,archival_correction.returndate FROM archival_master INNER JOIN archival_correction on archival_master.id=archival_correction.ref_id where archival_correction.handoverby IS NULL")
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
            
            If e.ColumnIndex = 0 Then
                'Panel2.Hide()
                Dim form As New handovercorrections
                form.Label2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
                form.Label3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
                form.Owner = Me
                form.ShowDialog()
            End If
        End If
    End Sub
End Class