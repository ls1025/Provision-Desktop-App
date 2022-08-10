Imports System.Data.SqlClient
Imports SautinSoft
Imports System.IO
Public Class viewreleasedtrstb
    Dim da As New SqlDataAdapter()

    Private Sub viewreleasedtrstb_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Guna.UI.Lib.GraphicsHelper.ShadowForm(Me)
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadIntimationStb()
    End Sub

    Public Sub LoadIntimationStb()
        Try

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("select trstb.id,trstb.productcode, trstb.strength,trstb.btn, trstb.trno,trstb.requestedby, trstb.requestdate,trstb.datauploaddate,viewtraudit.viewedby,viewtraudit.vieweddate 
from trstb
 OUTER APPLY (Select TOP 1 viewtraudit.viewedby,viewtraudit.vieweddate  from viewtraudit where viewtraudit.trno=trstb.trno order by vieweddate DESC)  viewtraudit
 
 where

			trstb.productname = '" + Label1.Text + "' AND 
				trstb.test = '" + Label2.Text + "' AND 
					trstb.datauploaddate BETWEEN @fromdate AND @todate  order by trstb.datauploaddate DESC
")
            cmd.Parameters.AddWithValue("@fromdate", SqlDbType.Date).Value = DateTime.Now.Date.AddDays(-4)
            cmd.Parameters.AddWithValue("@todate", SqlDbType.Date).Value = DateTime.Now.Date
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

            If e.ColumnIndex = 1 Then
                Try
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry1 As String
                    qry1 = "select datafile from trstb where trno='" + DataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString() + "'"
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


                    Dim viewedby As String
                    If Homepagefrdgl.Label2.Text = "User Type" Then
                        viewedby = Homepagefrdj.Label1.Text
                    Else
                        viewedby = Homepagefrdgl.Label1.Text
                    End If


                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd2 As New SqlCommand
                    cmd2.Connection = con
                    cmd2.CommandText = "insert into viewtraudit(trno,viewedby,vieweddate) values('" + DataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString() + "','" + viewedby + "',@vieweddate)"
                    cmd2.Parameters.AddWithValue("@vieweddate", SqlDbType.DateTime).Value = DateTime.Now
                    con.Open()
                    cmd2.ExecuteNonQuery()
                    con.Close()


                    LoadIntimationStb()
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
    Private Sub WithNoPrint()
        Try

            If con.State = ConnectionState.Open Then con.Close()
            Dim qry1 As String
            qry1 = "select datafile from trstb where trno=''"
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

            Dim f As SautinSoft.PdfFocus = New SautinSoft.PdfFocus()
            f.OpenPdf(sFilePath)

            Dim Outputfile As String
            Outputfile = System.IO.Path.GetTempFileName()
            System.IO.File.Move(Outputfile, System.IO.Path.ChangeExtension(Outputfile, ".tiff"))
            Outputfile = System.IO.Path.ChangeExtension(sFilePath, ".tiff")
            'System.IO.File.WriteAllBytes(sFilePath, buffer)

            If f.PageCount > 0 Then
                f.ImageOptions.Dpi = 600
                f.ToMultipageTiff(Outputfile)
            End If
            Dim form As New viewdata

            'Dim path As String = "c:\test.tif"
            If File.Exists(Outputfile) Then
                form.GunaImageButton1.BackgroundImage = Image.FromFile(Outputfile)
            End If
            'form.TextBox1.Text = f.PageCount
            form.Label1.Text = f.PageCount
            form.ShowDialog()
            'SplitePDF(sFilePath)
        Catch ex As Exception
            MsgBox("Not Available", vbExclamation)
        End Try
    End Sub
End Class

