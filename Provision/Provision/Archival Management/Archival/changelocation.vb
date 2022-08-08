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
            Dim cmd3 As New SqlCommand
            cmd3.Connection = con
            cmd3.CommandText = "update archival_master set location='" + TextBox1.Text + "' where id='" + Label1.Text + "'"

            con.Open()
            cmd3.ExecuteNonQuery()
            con.Close()

            MsgBox("Location Changed", vbInformation)
            Dim f1 As viewarchivedocdetails = DirectCast(Me.Owner, viewarchivedocdetails)
            f1.LoadDocumentDetails()
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class