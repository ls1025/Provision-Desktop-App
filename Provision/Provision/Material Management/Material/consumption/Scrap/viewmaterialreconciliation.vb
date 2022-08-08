Imports System.Data.SqlClient
Public Class viewmaterialreconciliation
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()


    Private Sub viewmaterialreconciliation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

        GunaPanel2.Hide()
        loadreconcilation()
        calculate()
    End Sub

    Public Sub loadreconcilation()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select id,consumedqty,(CAST(consumedqty AS varchar)+' '+CAST(unit AS varchar)) AS 'consumed_qty',[proname],[btn],[remarks],[consumedby],[consumedon] from inventry_recon where [ref_id]='" + Label1.Text + "' ", con)
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
    Private Sub calculate()
        Try
            If DataGridView1.RowCount > 0 Then
                Dim avialsample As Double = GunaLabel9.Text
                Dim issuedsample As Double
                Dim totalsample As Double
                For index As Integer = 0 To DataGridView1.RowCount - 1
                    issuedsample += Val(DataGridView1.Rows(index).Cells(1).Value)
                Next
                Label21.Text = issuedsample
                totalsample = avialsample + issuedsample
                GunaLabel11.Text = totalsample
                GunaLabel9.Text += " " + Label2.Text
                Label21.Text += " " + Label2.Text
                GunaLabel11.Text += " " + Label2.Text
            Else
                Label21.Text = "Not Yet Issued"
                GunaLabel11.Text = "NA"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        MsgBox(e.ColumnIndex)
    End Sub
End Class