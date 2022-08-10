Imports System.Data
Imports System.Data.SqlClient
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports System.Threading
Imports System.Diagnostics
Imports System.ComponentModel

Public Class setlnb
    'Dim con As SqlConnection = New SqlConnection("Data Source=VE-IT\SQLEXPRESS;Initial Catalog=vensure;Integrated Security=True")
    Dim cmd1 As SqlCommand
    Dim cmd2 As SqlCommand

    Private Sub setlnb_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 60, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Enter LNB Number", vbCritical)
        ElseIf ListBox1.items.Count = 0 Then
            MsgBox("Select TR numbers to Update LNB Number", vbCritical)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure to Update LNB Number", "Confirmation before Update", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.Yes Then
                Try
                    For Each item In ListBox1.Items
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd1 As New SqlCommand
                        cmd1.Connection = con
                        cmd1.CommandText = "update trdev set lnbno='" + TextBox1.Text + "',atrno='NA',atrissueno='NA',datasentby='" + homepageard.Label1.Text + "',datasentdate=@datasentdate,Status='Data Sent to DQA' where trno='" + item + "'"
                        cmd1.Parameters.AddWithValue("@datasentdate", SqlDbType.Date).Value = DateTime.Now.Date
                        con.Open()
                        cmd1.ExecuteNonQuery()

                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd2 As New SqlCommand
                        cmd2.Connection = con
                        cmd2.CommandText = "update trrot set lnbno='" + TextBox1.Text + "',atrno='NA',atrissueno='NA',datasentby='" + homepageard.Label1.Text + "',datasentdate=@datasentdate,Status='Data Sent to DQA' where trno='" + item + "'"
                        cmd2.Parameters.AddWithValue("@datasentdate", SqlDbType.Date).Value = DateTime.Now.Date
                        con.Open()
                        cmd2.ExecuteNonQuery()

                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd3 As New SqlCommand
                        cmd3.Connection = con
                        cmd3.CommandText = "update trstb set lnbno='" + TextBox1.Text + "',atrno='NA',atrissueno='NA',datasentby='" + homepageard.Label1.Text + "',datasentdate=@datasentdate,Status='Data Sent to DQA' where trno='" + item + "'"
                        cmd3.Parameters.AddWithValue("@datasentdate", SqlDbType.Date).Value = DateTime.Now.Date
                        con.Open()
                        cmd3.ExecuteNonQuery()
                    Next

                    Dim f1 As newintimationarddev = DirectCast(Me.Owner, newintimationarddev)
                    f1.LoadIntimationDev()
                    Me.Close()
                    MsgBox("LNB No. Updated", vbInformation)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If





    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class