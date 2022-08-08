Imports System.Data.OleDb
Public Class adduser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Enter Full Name", vbCritical)
            ElseIf TextBox2.Text = "" Then
                MsgBox("Enter User Name", vbCritical)
            ElseIf ComboBox1.Text = "" Then
                MsgBox("Select User Type", vbCritical)
            ElseIf TextBox1.Text = TextBox2.Text Then
                MsgBox("Full Name and User Name should not be same", vbCritical)
            Else

                Dim a As String
                If con.State = ConnectionState.Open Then con.Close()
                cmd.Connection = con
                con.Open()
                cmd.CommandText = "select count([fullname]) from users where fullname='" + TextBox1.Text + "'"
                a = cmd.ExecuteScalar().ToString()
                con.Close()

                If a > 0 Then
                    MsgBox("Full Name is alreday Exist", vbCritical)

                ElseIf a = 0 Then
                    Dim a1 As String
                    If con.State = ConnectionState.Open Then con.Close()
                    cmd1.Connection = con
                    con.Open()
                    cmd1.CommandText = "select count([username]) from users where username='" + TextBox2.Text + "'"
                    a1 = cmd1.ExecuteScalar().ToString()
                    con.Close()

                    If a1 > 0 Then
                        MsgBox("User Name is alreday Exist", vbCritical)
                    Else
                        If con.State = ConnectionState.Open Then con.Close()
                        cmd.Connection = con
                        con.Open()

                        cmd.CommandText = "insert into users([fullname],[username],[password],[type],[status]) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox2.Text + "','" + usertype + "','Renew')"
                        cmd.ExecuteNonQuery()
                        con.Close()
                        Dim f1 As userview = DirectCast(Me.Owner, userview)
                        f1.LoadUserDetails()
                        MsgBox("User added Susccessfully", vbInformation)
                        Me.Close()
                    End If

                End If



            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Dim usertype As String
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.Text = "Group Leader" Then
            usertype = "GL"
        ElseIf ComboBox1.Text = "Associate" Then
            usertype = "JR"
        ElseIf ComboBox1.Text = "IT" Then
            usertype = "IT"
        End If
    End Sub
End Class