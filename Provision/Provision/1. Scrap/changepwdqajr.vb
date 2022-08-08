Imports System.Data.SqlClient
Public Class changepwdqajr
    Dim cmd As New SqlCommand
    Dim cmd1 As New SqlCommand
    Dim cmd2 As New SqlCommand
    Private NameValid As Boolean
    Private Sub Button46_Click(sender As Object, e As EventArgs) Handles Button46.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If con.State = ConnectionState.Open Then con.Close()
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
            Dim cmd As New SqlCommand("update users set [status]='Active', [password]='" + TextBox2.Text + "' where fullname='" + homepagedqajr.Label1.Text + "'", con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Your Password has been Changed successfully", vbInformation)
            login.TextBox2.Text = ""
            Me.Close()

        End If

    End Sub
    Private Sub loginhstry()
        If con.State = ConnectionState.Open Then con.Close()
        con.Open()
        Dim qry1 As String
        qry1 = "select * from users where username='" + login.TextBox1.Text + "'"
        cmd1 = New SqlCommand(qry1, con)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd1)
        Dim table As New DataTable()
        da.Fill(table)
        Dim fullname As String
        fullname = table.Rows(0)(1).ToString()
        Dim username As String
        username = table.Rows(0)(2).ToString()
        Dim usertype As String
        usertype = table.Rows(0)(4).ToString()

        If con.State = ConnectionState.Open Then con.Close()
        Dim qry2 As String
        qry2 = "insert into loginhstry ([Full Name],Username,[User Type],Time,Activity) values ('" + fullname + "','" + username + "','" + usertype + "','" + Now + "','Intitial Password Changed')"
        cmd2 = New SqlCommand(qry2, con)
        con.Open()
        cmd2.ExecuteNonQuery()
        con.Close()
    End Sub

End Class