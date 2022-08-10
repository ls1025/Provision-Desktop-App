Imports System.Data.SqlClient
Public Class esignlnb

    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim cmd2 As SqlCommand
    Dim cmd3 As SqlCommand
    Private Sub esignlnb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
    Private Sub LoginValidation()
        Try

            If TextBox1.Text = "" Then
                MsgBox("Please enter username..", MsgBoxStyle.Critical)
            ElseIf TextBox2.Text = "" Then
                MsgBox("Please enter password..", MsgBoxStyle.Critical)
            Else
                If con.State = ConnectionState.Open Then con.Close()
                Dim qry As String
                qry = "select Count(*) from users where username='" + TextBox1.Text + "'"
                cmd = New SqlCommand(qry, con)
                con.Open()
                Dim a As String
                a = cmd.ExecuteScalar().ToString()
                con.Close()

                If a = 0 Then
                    MsgBox("User ID not Exist", vbCritical)
                ElseIf a > 0 Then

                    If con.State = ConnectionState.Open Then con.Close()
                    con.Open()
                    Dim qry1 As String
                    qry1 = "select * from users where username='" + TextBox1.Text + "'"
                    cmd1 = New SqlCommand(qry1, con)
                    Dim da As SqlDataAdapter = New SqlDataAdapter(cmd1)
                    Dim table As New DataTable()
                    da.Fill(table)

                    Dim fullname As String
                    fullname = table.Rows(0)(1).ToString

                    Dim password As String
                    password = table.Rows(0)(3).ToString()


                    Dim userstatus As String
                    userstatus = table.Rows(0)(8).ToString()


                    If userstatus = "Disabled" Then
                        MsgBox("This User ID was Disabled", vbCritical)
                    ElseIf userstatus = "Renew" And password = TextBox2.Text Then
                        MsgBox("This is new account. Change the passwoerd from login page", vbExclamation, "Change Password")
                    ElseIf userstatus = "Renew" And password <> TextBox2.Text Then
                        MsgBox("Invalid Password", vbCritical, )
                    ElseIf userstatus = "Active" Or userstatus = "esign" Then
                        If password <> TextBox2.Text Then
                            MsgBox("Invalid Password", vbCritical)
                        ElseIf password = TextBox2.Text Then
                            Try
                                If con.State = ConnectionState.Open Then con.Close()
                                Dim qry2 As String
                                qry2 = "select type from users where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'"
                                cmd2 = New SqlCommand(qry2, con)
                                con.Open()
                                Dim type As String
                                type = cmd2.ExecuteScalar().ToString()

                                If type = "FRD Scientist" Then
                                    MsgBox("Authenticate successfully as" + " " + fullname, vbInformation)
                                    Dim f1 As issuelnb = DirectCast(Me.Owner, issuelnb)
                                    f1.Label1.Text = fullname
                                    Me.Close()

                                ElseIf type = "FRD GL" Then
                                    MsgBox("Authenticate successfully as" + " " + fullname, vbInformation)
                                    Dim f1 As issuelnb = DirectCast(Me.Owner, issuelnb)
                                    f1.Label1.Text = fullname
                                    Me.Close()

                                Else
                                    MsgBox("Authentication Failue as this user is not allowed to receive Product LNB", vbCritical)
                                    Me.Close()
                                End If
                            Catch ex As SqlException
                                MessageBox.Show(ex.Message)
                            End Try
                        End If
                    Else
                        MsgBox("Unknown User", vbCritical)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoginValidation()
    End Sub
    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoginValidation()
        End If
    End Sub
End Class