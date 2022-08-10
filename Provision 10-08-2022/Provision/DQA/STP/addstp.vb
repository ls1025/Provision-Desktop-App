Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class addstp
    Private _filename As String = String.Empty
    Private Sub addstp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

    End Sub
    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        With FileDialogs
            .FileName = ""
            .CheckFileExists = True : .CheckPathExists = True
            .Filter = "PDF Files (*.pdf)|*.pdf"
            .Multiselect = False : .ReadOnlyChecked = False
            .RestoreDirectory = True : .ShowHelp = False
            .Title = "Select File - STP Upload"
            .ShowDialog(Me)
            _filename = .FileName.ToString()
            GunaLabel7.Text = _filename
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Enter Product Name", vbCritical)
            ElseIf TextBox3.Text = "" Then
                MsgBox("Enter STP Number", vbCritical)
            ElseIf TextBox4.Text = "" Then
                MsgBox("Enter STP Version Number", vbCritical)
            ElseIf GunaLabel7.Text = "." Or GunaLabel7.Text = "" Then
                MsgBox("Upload Document", vbCritical)
            Else
                Dim result1 As Integer = MessageBox.Show("Are you sure to Upddate STP", "Confirmation before Add", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                If result1 = DialogResult.Yes Then

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd2 As New SqlCommand
                    cmd2.Connection = con
                    cmd2.CommandText = "insert into  stphstry(proname,market,test,stpno,stpversion,stpfile,stpuploadedby,stpuploadeddate,stpremarks) values('" + Label2.Text + "','" + Label3.Text + "','" + TextBox1.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "',@file,'" + homepagedqa.Label1.Text + "',@uploadeddate,'" + TextBox2.Text + "')"
                    cmd2.Parameters.AddWithValue("@file", SqlDbType.VarBinary).Value = File.ReadAllBytes(GunaLabel7.Text)
                    cmd2.Parameters.AddWithValue("@uploadeddate", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd2.ExecuteNonQuery()
                    con.Close()

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd3 As New SqlCommand
                    cmd3.Connection = con
                    cmd3.CommandText = "update productlistdoc set stpno='" + TextBox3.Text + "',stpversion='" + TextBox4.Text + "',stpfile=@file,stpuploadedby='" + homepagedqa.Label1.Text + "',stpuploadeddate=@uploadeddate,stpremarks='" + TextBox2.Text + "' where id='" + Label1.Text + "'"
                    cmd3.Parameters.AddWithValue("@file", SqlDbType.VarBinary).Value = File.ReadAllBytes(GunaLabel7.Text)
                    cmd3.Parameters.AddWithValue("@uploadeddate", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd3.ExecuteNonQuery()
                    con.Close()

                    MsgBox("STP Added Successfully", vbInformation)

                    Dim f1 As viewstpdetails = DirectCast(Me.Owner, viewstpdetails)
                    f1.LoadTestDetails()
                    Me.Close()
                End If


            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Me.Close()
    End Sub
    Private Sub GunaGradientButton3_Click_1(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        Try
            Dim result1 As Integer = MessageBox.Show("Are you sure to mark this Test as Not Applicable", "Confirmation before Update", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result1 = DialogResult.Yes Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd3 As New SqlCommand
                cmd3.Connection = con
                cmd3.CommandText = "update productlistdoc set stpno='NA',stpuploadedby='" + homepagedqa.Label1.Text + "',stpuploadeddate=@uploadeddate,stpremarks='Not Applicable' where id='" + Label1.Text + "'"
                cmd3.Parameters.AddWithValue("@uploadeddate", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd3.ExecuteNonQuery()
                con.Close()

                MsgBox("STP Marked as Not Applicable", vbInformation)

                Dim f1 As viewstpdetails = DirectCast(Me.Owner, viewstpdetails)
                f1.LoadTestDetails()
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class