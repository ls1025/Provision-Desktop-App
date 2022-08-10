Imports System.Data.SqlClient
Public Class viewarcdetail
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Dim cmd1 As New SqlCommand
    Dim cmd2 As New SqlCommand
    Private Sub viewarcdetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadHandoverDetails()

    End Sub

    Private Sub LoadHandoverDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select id,docname,docno,pages,arcno,location,archivedby,archiveddate from archival_master where doctype='" + Label1.Text + "' and receivedby='" + Label2.Text + "' and receiveddate='" & CDate(Label3.Text).ToString("yyyy-MM-dd") & "' and status='" + Label4.Text + "'", con)
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            dgv1_rowstyle()
            DataGridView1.CurrentCell = Nothing
            'GunaLabel1.Text = "Total Documents: " + DataGridView1.Rows.Count.ToString
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
End Class