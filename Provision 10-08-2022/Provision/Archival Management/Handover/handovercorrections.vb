Imports System.Data.SqlClient
Public Class handovercorrections
    Private Sub handovercorrections_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Label1.Text = "" Then
            MsgBox("Authentication Failed", vbCritical)
        ElseIf Label1.Text = "." Then
            MsgBox("Authentication Failed", vbCritical)
        Else
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "update archival_master set status='handover' where id='" + Label2.Text + "'"
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            cmd1.CommandText = "update archival_correction set handoverby='" + Label1.Text + "',handoverto='" + homepage.Label1.Text + "',handoverdate=@handoverdate where id='" + Label3.Text + "'"
            cmd1.Parameters.AddWithValue("@handoverdate", SqlDbType.Date).Value = DateTime.Now.Date
            con.Open()
            cmd1.ExecuteNonQuery()
            con.Close()

            MsgBox("Document Handover Successfully", vbInformation)
            Dim f1 As viewcorrectionsdocs = DirectCast(Me.Owner, viewcorrectionsdocs)
            f1.LoadDocumentDetails()
            Me.Close()
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New esigndoccorrectionhandover
        form.Owner = Me
        form.ShowDialog()
    End Sub
End Class