Imports System.Data.OleDb
Public Class updateuser
    Private Sub updateuser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If RadioButton1.Checked = False And RadioButton2.Checked = False Then
                MsgBox("Select User Status", vbCritical)
            ElseIf RadioButton1.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                cmd.Connection = con
                con.Open()
                cmd.CommandText = "update users set [type]='" + ComboBox1.Text + "',[status]='Active' where ID=" & Label1.Text & ""
                cmd.ExecuteNonQuery()
                con.Close()
            ElseIf RadioButton2.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                cmd.Connection = con
                con.Open()
                cmd.CommandText = "update users set [type]='" + ComboBox1.Text + "',[status]='Disabled' where ID=" & Label1.Text & ""
                cmd.ExecuteNonQuery()
                con.Close()
            End If
            Dim f1 As userview = DirectCast(Me.Owner, userview)
            f1.LoadUserDetails()
            MsgBox("User Updated Susccessfully", vbInformation)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class