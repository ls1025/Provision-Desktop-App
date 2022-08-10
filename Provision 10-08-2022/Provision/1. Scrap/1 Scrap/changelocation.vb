Imports System.Data.SqlClient
Public Class changelocation
    Private Sub changelocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Enter Location", vbCritical)
        Else
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            con.Open()
            cmd1.CommandText = "update [archival_master] set [location]='" + TextBox1.Text + "' where [id]='" + Label1.Text + "'"
            cmd1.ExecuteNonQuery()
            con.Close()
            MsgBox("Location Changed", vbInformation)
            Dim f1 As documentsinlocation = DirectCast(Me.Owner, documentsinlocation)
            f1.LoadDocuments()
            Me.Close()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class