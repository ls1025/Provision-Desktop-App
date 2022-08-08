Imports System.Data.SqlClient
Public Class adduser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Enter Full Name", vbCritical)
            ElseIf TextBox2.Text = "" Then
                MsgBox("Enter User Name", vbCritical)
            ElseIf ComboBox1.Text = "" Then
                MsgBox("Select Department", vbCritical)
            ElseIf ComboBox2.Text = "" Then
                MsgBox("Select User Type", vbCritical)
            ElseIf TextBox3.Text = "" Then
                MsgBox("Enter Reporting To", vbCritical)
            ElseIf TextBox1.Text = TextBox2.Text Then
                MsgBox("Full Name and User Name should not be same", vbCritical)
            Else

                If con.State = ConnectionState.Open Then con.Close()
                Dim ds As DataSet = New DataSet
                Dim da As New SqlDataAdapter()
                Dim dt As New DataTable()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                Dim table As New DataTable()
                da = New SqlDataAdapter("Select fullname,username from users", con)
                da.Fill(table)

                If TextBox1.Text = table.Rows(0)(0).ToString Then
                    MsgBox("Full Name is alreday Exist", vbCritical)
                ElseIf TextBox1.Text = table.Rows(0)(0).ToString Then
                    MsgBox("User Name is alreday Exist", vbCritical)
                Else
                    If con.State = ConnectionState.Open Then con.Close()
                    cmd.Connection = con
                    con.Open()
                    cmd.CommandText = "insert into users([fullname],[username],[password],[type],[reportto],[status],[dep]) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox2.Text + "','" + ComboBox2.Text + "','" + TextBox3.Text + "','Renew','" + ComboBox1.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    Dim f1 As userview = DirectCast(Me.Owner, userview)
                    f1.LoadUserDetails()
                    MsgBox("User added Susccessfully", vbInformation)
                    Me.Close()
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub AutoCompleteReporting()
        Try
            Dim cmd As New SqlCommand("select fullname from users where dep='" + ComboBox1.Text + "' and status<>'Disabled'", con)
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



    Private Sub adduser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        AutoCompleteReporting()
    End Sub
End Class