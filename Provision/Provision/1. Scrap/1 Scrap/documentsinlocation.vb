Imports System.Data.SqlClient
Public Class documentsinlocation
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub documentsinlocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDocuments()
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel2, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
    Public Sub LoadDocuments()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select [ID],[doctype],[docname],[docno],[arcno] from archival_master where location='" + GunaLabel1.Text + "'", con)
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DataGridView1.Cursor = Cursors.WaitCursor
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            DataGridView1.Cursor = Cursors.Default
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgv1_rowstyle()
            DataGridView1.CurrentCell = Nothing
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
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'MsgBox(e.ColumnIndex)
    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click

        If DataGridView1.SelectedCells.Count > 0 Then
            Dim form As New issuedocument
            form.Label5.Text = DataGridView1.SelectedCells(0).Value

            form.Label1.Text = DataGridView1.SelectedCells(1).Value
            form.aLabel2.Text = DataGridView1.SelectedCells(2).Value
            form.Label3.Text = DataGridView1.SelectedCells(3).Value
            form.Label4.Text = DataGridView1.SelectedCells(4).Value
            form.ShowDialog()
        Else
            MsgBox("Select atleast one row to issue sample", vbCritical)
        End If
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            Dim form As New changelocation
            form.Label1.Text = DataGridView1.SelectedCells(0).Value
            form.Owner = Me
            form.ShowDialog()
        Else
            MsgBox("Select atleast one row to issue sample", vbCritical)
        End If
    End Sub
End Class