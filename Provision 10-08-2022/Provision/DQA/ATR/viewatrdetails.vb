Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class viewatrdetails
    Private Sub viewatrdetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTestDetails()
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
    Public Sub LoadTestDetails()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand("select [id],[test],[atrno],[atrversion],[maxtrallowed],[atruploadedby],[atruploadeddate],[atrremarks] from productlistdoc where proname='" + Label1.Text + "' and market='" + Label2.Text + "' and stpno<>'NA'")
        cmd.Connection = con
        Dim adapter1 As New SqlDataAdapter(cmd)
        Dim table1 As New DataTable()
        adapter1.Fill(table1)
        DataGridView1.DataSource = table1
        dgv1_rowstyle()

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
    Dim VerNo As String
    Dim TestName As String

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                If DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString() = "" Then
                    MsgBox("Not Updated Yet", vbExclamation)
                Else
                    Dim form As New atrhstry
                    form.Label1.Text = Label1.Text
                    form.Label2.Text = Label2.Text
                    form.Label3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString()
                    form.Label4.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString()
                    form.ShowDialog()
                End If

            ElseIf e.ColumnIndex = 1 Then

                Dim form As New addatr
                form.Owner = Me
                form.Label1.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString()
                form.TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString()
                'ATR Number
                If DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString() = "" Then
                    form.TextBox3.Text = "ATR/"
                    form.TextBox3.ReadOnly = False
                Else
                    form.TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString()
                    form.TextBox3.ReadOnly = True
                End If
                'ATR Version Number
                If DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString() = "" Then
                    form.TextBox4.ReadOnly = False
                Else
                    form.TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString()
                    Dim currentVersion As String = DataGridView1.Rows(e.RowIndex).Cells(5).Value
                    Dim curValue As Int32 = 5
                    Int32.TryParse(DataGridView1.Rows(e.RowIndex).Cells(5).Value, curValue)
                    curValue = currentVersion + 1
                    currentVersion = curValue.ToString("D2")
                    form.TextBox4.Text = currentVersion
                    form.TextBox4.ReadOnly = True
                End If
                'Max TR Allowed
                form.TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString()
                form.Label2.Text = Label1.Text
                form.Label3.Text = Label2.Text
                form.ShowDialog()
                'MsgBox(DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString())
            End If

        End If

    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'MsgBox(e.ColumnIndex)
    End Sub
End Class