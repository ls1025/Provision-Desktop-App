Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class stphstry
    Private Sub stphstry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadSTPHistory()
    End Sub
    Public Sub LoadSTPHistory()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand("select [id],[stpversion],[stpuploadedby],[stpuploadeddate],[stpremarks] from stphstry where test='" + Label3.Text + "' and stpno='" + Label4.Text + "' order by stpversion DESC")
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
    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then

            If e.ColumnIndex = 0 Then
                Try
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry1 As String
                    qry1 = "select stpfile from stphstry where stpno='" + Label4.Text + "' and stpversion='" + DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString() + "'"
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
                    Dim act As Action(Of String) = New Action(Of String)(AddressOf OpenPDFFile)
                    act.BeginInvoke(sFilePath, Nothing, Nothing)
                Catch ex As Exception
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
End Class