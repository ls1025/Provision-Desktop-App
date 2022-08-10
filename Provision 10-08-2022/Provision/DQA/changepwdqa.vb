Imports System.Data.SqlClient
Public Class changepwdqa
    Dim cmd As New SqlCommand
    Dim cmd1 As New SqlCommand
    Dim cmd2 As New SqlCommand
    Private NameValid As Boolean
    Private Sub Button46_Click(sender As Object, e As EventArgs) Handles Button46.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Please Enter Password", vbCritical)
        ElseIf TextBox2.Text = "" Then
            MsgBox("Please Enter Confirm Password", vbCritical)
        ElseIf TextBox1.TextLength < 6 Or TextBox2.TextLength < 6 Then
            MsgBox("Password should contain atlease 6 characters", vbCritical)
        ElseIf TextBox1.Text <> TextBox2.Text Then
            MsgBox("New Password and Confirm Password Not Matching", vbCritical)
        Else
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("update users set [status]='Active', [password]='" + TextBox2.Text + "' where fullname='" + homepagedqa.Label1.Text + "'", con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Your Password has been Changed successfully", vbInformation)
            login.TextBox2.Text = ""
            Me.Close()

        End If

    End Sub


End Class