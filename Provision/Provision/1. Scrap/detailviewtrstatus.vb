Imports System.Data.SqlClient
Public Class detailviewtrstatus
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub detailviewtrstatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel3, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadTRDetails()

    End Sub
    Public Sub LoadTRDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select id,trno,testdetails,requestedby,requestdate,Status from trdev where productname= '" + Label1.Text + "' and strength='" + Label2.Text + "' and btn='" + Label3.Text + "' and test='" + Label4.Text + "' union Select id,trno,testdetails,requestedby,requestdate,Status from trrot where productname= '" + Label1.Text + "' and strength='" + Label2.Text + "' and btn='" + Label3.Text + "' and test='" + Label4.Text + "' union Select id,trno,testdetails,requestedby,requestdate,Status from trstb where productname= '" + Label1.Text + "' and strength='" + Label2.Text + "' and btn='" + Label3.Text + "' and test='" + Label4.Text + "'")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
            GunaLabel2.Text = "Records: " + DataGridView1.Rows.Count.ToString
            dgv1_rowstyle()
            DataGridView1.CurrentCell = Nothing

        Catch ex As Exception

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
                If DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString.Contains("DT/") Then
                    Try
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim qry1 As String
                        qry1 = "select datafile from trdev where trno='" + DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString + "'"
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
                ElseIf DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString.Contains("TR/") Then
                    Try
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim qry1 As String
                        qry1 = "select datafile from trrot where trno='" + DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString + "'"
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
                ElseIf DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString.Contains("ST/") Then
                    Try
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim qry1 As String
                        qry1 = "select datafile from trstb where trno='" + DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString + "'"
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

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            Dim form As New detailview
            form.Label1.Text = DataGridView1.SelectedCells(2).Value.ToString
            form.ShowDialog()
        End If

    End Sub

End Class