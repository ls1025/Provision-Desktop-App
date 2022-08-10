Imports System.Data.OleDb
Public Class changepw
    Dim cmd As New OleDbCommand
    Dim cmd1 As New OleDbCommand
    Dim cmd2 As New OleDbCommand
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
            'ElseIf ValidatePassword(TextBox1.Text) = False Then
            ' MsgBox("Password Should Contain Atleast 1 Character, 1 Number and 1 Special Character", vbCritical)
            'TextBox1.Focus()
        ElseIf TextBox1.Text <> TextBox2.Text Then
            MsgBox("New Password and Confirm Password Not Matching", vbCritical)
        Else
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New OleDbCommand("update users set [status]='Active', [password]='" + TextBox2.Text + "' where fullname='" + homepage.Label1.Text + "'", con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Your Password has been Changed successfully", vbInformation)
            'loginhstry()
            Me.Close()

        End If

    End Sub
    Private Sub loginhstry()
        If con.State = ConnectionState.Open Then con.Close()
        con.Open()
        Dim qry1 As String
        qry1 = "select * from users where username='" + login.TextBox1.Text + "'"
        cmd1 = New OleDbCommand(qry1, con)
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd1)
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
        cmd2 = New OleDbCommand(qry2, con)
        con.Open()
        cmd2.ExecuteNonQuery()
        con.Close()
    End Sub


    Private Function ValidatePassword(ByVal sPass) As Boolean
        Dim regEx
        regEx = CreateObject("vbscript.regexp")
        'At least 8 characters
        'At least 1 number
        'At least 1 lowercase letter
        'At least 1 uppercase letter
        'At least 1 special character. Special charaters include !@#$&#37;^&+=
        regEx.Pattern = "^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[!@#$%^&+=]).*$"
        ValidatePassword = regEx.Test(sPass)
        regEx = Nothing
    End Function

    Private Sub changepward_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class