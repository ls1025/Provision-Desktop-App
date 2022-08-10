Imports System.Data.SqlClient
Public Class returndocument
    Dim cmd1 As New SqlCommand
    Dim cmd2 As New SqlCommand
    Private Sub returndocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label1.Text = "." Or Label1.Text = "" Then
            MsgBox("Authentication Failed", vbCritical)
        Else
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd3 As New SqlCommand
                cmd3.Connection = con
                cmd3.CommandText = "update archival_issuance set returnedby='" + Label1.Text + "',returnedto='" + homepage.Label1.Text + "',returndate=@returndate,remark='" + TextBox1.Text + "',status='Document Returned'"
                cmd3.Parameters.AddWithValue("@returndate", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd3.ExecuteNonQuery()
                con.Close()

                MsgBox("Document Returned Successfully", vbInformation)
                Dim f1 As viewissueddocdetails = DirectCast(Me.Owner, viewissueddocdetails)
                f1.LoadDocumentDetails()
                Me.Close()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New esignreturn
        form.Owner = Me
        form.ShowDialog()
    End Sub
End Class