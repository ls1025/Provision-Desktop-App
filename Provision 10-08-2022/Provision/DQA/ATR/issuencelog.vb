Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class issuencelog
    Private Sub GunaLabel1_Click(sender As Object, e As EventArgs) Handles GunaLabel1.Click

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub issuencelog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLogDetailsDataGrid()
        LoadLogDetails()
        'LoadPDSVersionNo()
        ' LoadTest()
    End Sub

    Public Sub LoadLogDetailsDataGrid()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand("select [trno],[issuedby],[issueddate],[remarks] from atrissuelog where atrissueno='" + Label4.Text + "'")
        cmd.Connection = con
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table
        dgv1_rowstyle()
    End Sub
    Public Sub LoadLogDetails()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand("select [proname],[test],[trno],[atrno],[atrissueno],[issuedby],[issueddate] from atrissuelog where atrissueno='" + Label4.Text + "'")
        cmd.Connection = con
        Dim adapter As New SqlDataAdapter(cmd)
        Dim table As New DataTable()
        adapter.Fill(table)

        Dim Proname As String = table.Rows(0)(0).ToString
        Label1.Text = Proname

        Dim TestName As String = table.Rows(0)(1).ToString
        Label2.Text = TestName

        Dim ATRNo As String = table.Rows(0)(3).ToString
        Label3.Text = ATRNo

        'Dim UpDate As Date = Date.ParseExact(table.Rows(0)(8), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        ' Label6.Text = UpDate

        ' Dim Remark As String = table.Rows(0)(9).ToString
        ' Label7.Text = Remark

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