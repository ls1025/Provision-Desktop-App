Imports System.Data.SqlClient
Public Class returnforcorrections
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New esigndoccorrection
        form.Owner = Me
        form.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Enter Correction Details", vbCritical)
        ElseIf GunaLabel1.Text = "" Then
            MsgBox("Authentication Failed", vbCritical)
        ElseIf GunaLabel1.Text = "." Then
            MsgBox("Authentication Failed", vbCritical)
        Else
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "insert into archival_correction(ref_id,corrections,returnby,returnto,returndate) values('" + Label1.Text + "','" + TextBox1.Text + "','" + homepage.Label1.Text + "','" + GunaLabel1.Text + "',@returndate)"
            cmd.Parameters.AddWithValue("@returndate", SqlDbType.Date).Value = DateTime.Now.Date
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            cmd1.CommandText = "update archival_master set status='Corrections' where id='" + Label1.Text + "'"
            con.Open()
            cmd1.ExecuteNonQuery()
            con.Close()

            Dim f1 As viewdocdetails = DirectCast(Me.Owner, viewdocdetails)
            f1.LoadDocumentDetails()
            Me.Close()
        End If
    End Sub
End Class