Imports System.Data.SqlClient
Public Class viewissuancehistory
    Private Sub viewissuancehistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadDocumentDetails()
        LoadDocumentAudit
    End Sub
    Public Sub LoadDocumentDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            Dim ds As DataSet = New DataSet
            Dim adapter As New SqlDataAdapter
            Dim sql As String
            sql = "Select [id],[issuedby],[issuedto],[issueddate],[returnedby],[returnedto],[returndate],[remark],[status] from archival_issuance where [ref_id]='" + Label1.Text + "' order by [issueddate] DESC"
            adapter.SelectCommand = New SqlCommand(sql, con)
            adapter.Fill(ds, sql)
            AdvancedDataGridView1.DataSource = ds.Tables(sql)
            dgv1_rowstyle()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LoadDocumentAudit()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            Dim ds As DataSet = New DataSet
            Dim adapter As New SqlDataAdapter
            Dim sql As String
            sql = "Select [id],[corrections],[returnby],[returnto],[returndate],[handoverby],[handoverto],[handoverdate] from archival_correction where [ref_id]='" + Label1.Text + "' order by [returndate] DESC"
            adapter.SelectCommand = New SqlCommand(sql, con)
            adapter.Fill(ds, sql)
            AdvancedDataGridView2.DataSource = ds.Tables(sql)
            dgv1_rowstyle()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub dgv1_rowstyle()
        For i As Integer = 0 To AdvancedDataGridView1.RowCount - 1
            If i Mod 2 = 0 Then
                AdvancedDataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                AdvancedDataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If
        Next
        AdvancedDataGridView1.CurrentCell = Nothing
    End Sub
    Private Sub AdvancedDataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles AdvancedDataGridView1.ColumnHeaderMouseClick
        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles AdvancedDataGridView1.DataSourceChanged
        dgv1_rowstyle()
    End Sub
    Public Sub dgv2_rowstyle()
        For i As Integer = 0 To AdvancedDataGridView2.RowCount - 1
            If i Mod 2 = 0 Then
                AdvancedDataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                AdvancedDataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If
        Next
        AdvancedDataGridView2.CurrentCell = Nothing
    End Sub
    Private Sub AdvancedDataGridView2_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles AdvancedDataGridView2.ColumnHeaderMouseClick
        dgv2_rowstyle()
    End Sub
    Private Sub DataGridView2_DataSourceChanged(sender As Object, e As System.EventArgs) Handles AdvancedDataGridView2.DataSourceChanged
        dgv2_rowstyle()
    End Sub

End Class