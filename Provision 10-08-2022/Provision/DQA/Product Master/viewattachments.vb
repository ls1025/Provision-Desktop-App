Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class viewattachments
    Private Sub viewattachments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAttachments()
    End Sub
    Public Sub LoadAttachments()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select [id],[attachmentname] from productinitiationform where [proname]='" + Label1.Text + "' and market='" + Label2.Text + "' and client='" + Label3.Text + "' order by [id] DESC")
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
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.RowIndex >= 0 Then
            'MsgBox(e.ColumnIndex)

            If e.ColumnIndex = 0 Then

                Try
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry1 As String
                    qry1 = "select attachment from productinitiationform where id='" + DataGridView1.Rows(e.RowIndex).Cells(1).Value + "'"
                    cmd = New SqlCommand(qry1, con)
                    Dim sFilePath As String
                    Dim buffer As Byte()
                    con.Open()
                    buffer = cmd.ExecuteScalar()
                    con.Close()
                    sFilePath = System.IO.Path.GetTempFileName()
                    System.IO.File.Move(sFilePath, System.IO.Path.ChangeExtension(sFilePath, ".pdf"))
                    sFilePath = System.IO.Path.ChangeExtension(sFilePath, ".pdf")
                    System.IO.File.WriteAllBytes(sFilePath, buffer)
                    'Form2.AxAcroPDF1.src = sFilePath + "#embedded=true&toolbar=0&navpanes=0"
                    'Form2.ShowDialog()
                    Dim act As Action(Of String) = New Action(Of String)(AddressOf OpenPDFFile)
                    act.BeginInvoke(sFilePath, Nothing, Nothing)
                Catch ex As Exception
                    'MessageBox.Show(ex.Message)
                    MsgBox("Not Available", vbExclamation)
                End Try

            End If
        End If
    End Sub
    Private Shared Sub OpenPDFFile(ByVal sFilePath)
        Using p As New System.Diagnostics.Process
            p.StartInfo = New System.Diagnostics.ProcessStartInfo(sFilePath)
            p.Start()
            p.WaitForExit()
            Try
                System.IO.File.Delete(sFilePath)
            Catch
            End Try
        End Using
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
        MsgBox(e.ColumnIndex)
    End Sub
End Class