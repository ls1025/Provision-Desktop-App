Imports System.Data.SqlClient
Public Class updateuser
    Private Sub updateuser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserDetails()
        AutoCompleteReporting()
    End Sub
    Private Sub LoadUserDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim da As New SqlDataAdapter()
            Dim table As New DataTable()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select * from users where [id]= '" + Label1.Text + "' ", con)
            da.Fill(table)

            TextBox1.Text = table.Rows(0)(1).ToString
            TextBox2.Text = table.Rows(0)(2).ToString
            ComboBox1.Text = table.Rows(0)(9).ToString
            ComboBox2.Text = table.Rows(0)(4).ToString
            TextBox3.Text = table.Rows(0)(5).ToString

            If table.Rows(0)(8).ToString = "Disabled" Then
                RadioButton2.Checked = True
            Else
                RadioButton1.Checked = True
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub AutoCompleteReporting()
        Try
            Dim cmd As New SqlCommand("select fullname from users where status<>'Disabled'", con)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataSet
            da.Fill(dt)
            Dim fullname As New AutoCompleteStringCollection
            For i As Integer = 0 To dt.Tables(0).Rows.Count - 1
                fullname.Add(dt.Tables(0).Rows(i)("fullname").ToString())
            Next
            TextBox3.AutoCompleteSource = AutoCompleteSource.CustomSource
            TextBox3.AutoCompleteCustomSource = fullname
            TextBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If RadioButton1.Checked = False And RadioButton2.Checked = False Then
                MsgBox("Select User Status", vbCritical)
            ElseIf RadioButton1.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                cmd.Connection = con
                con.Open()
                cmd.CommandText = "update users set [type]='" + ComboBox2.Text + ",[reportto]='" + TextBox3.Text + "',dep='" + ComboBox1.Text + "' where [id]='" + Label1.Text + "'"
                cmd.ExecuteNonQuery()
                con.Close()
            ElseIf RadioButton2.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                cmd.Connection = con
                con.Open()
                cmd.CommandText = "update users set [status]='Disabled' where [id]='" + Label1.Text + "'"
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