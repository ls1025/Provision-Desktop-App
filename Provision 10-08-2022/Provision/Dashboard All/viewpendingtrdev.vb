Imports System.Data.SqlClient
Imports SautinSoft
Imports System.IO
Public Class viewpendingtrdev
    Dim da As New SqlDataAdapter()

    Private Sub viewpendingtrdev_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Guna.UI.Lib.GraphicsHelper.ShadowForm(Me)
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadIntimationDev()
    End Sub

    Public Sub LoadIntimationDev()
        Try

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select [ID],[productcode],[strength],[btn],[trno],[requestedby],[requestdate],[Status] from trdev where productname='" + Label1.Text + "' and test='" + Label2.Text + "' and (Status='New TR' or Status='TR Printed' or Status='ATR Issued' or Status='Data Sent to DQA' or Status='Released') order by [trno] DESC")
            ' cmd.Parameters.AddWithValue("@fromdate", SqlDbType.Date).Value = DateTime.Now.Date.AddDays(-2)
            'cmd.Parameters.AddWithValue("@todate", SqlDbType.Date).Value = DateTime.Now.Date
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
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
    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then

            If e.ColumnIndex = 0 Then

                Dim form As New detailview
                form.Label1.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString()
                form.ShowDialog()
            End If
        End If

    End Sub
End Class

