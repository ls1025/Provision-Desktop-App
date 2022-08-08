Imports System.Data
Imports System.Data.SqlClient
Public Class login

    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim cmd2 As SqlCommand
    Dim cmd3 As SqlCommand
    Public n1 As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea

    End Sub
    Private Sub login_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        LoginValidation()
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

                    Dim groupleader As String
                    groupleader = table.Rows(0)(5).ToString()

                    ' Dim manager As String
                    ' manager = table.Rows(0)(9).ToString()

                    Dim userstatus As String
                    userstatus = table.Rows(0)(8).ToString()


                    If userstatus = "Disabled" Then
                        MsgBox("This User ID was Disabled", vbCritical)
                    ElseIf userstatus = "Renew" And password = TextBox2.Text Then
                        MsgBox("Welcome to Provision. This is your initial login, Please change your password", vbExclamation, "Change Password")
                        changeinitialpw.ShowDialog()
                    ElseIf userstatus = "Renew" And password <> TextBox2.Text Then
                        MsgBox("Invalid Password", vbCritical, )
                    ElseIf userstatus = "Active" Then
                        If con.State = ConnectionState.Open Then con.Close()
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
                                    'MsgBox("You have successfully logged in as" + " " + fullname, vbInformation)
                                    Homepagefrdj.Show()
                                    Homepagefrdj.Label1.Text = fullname
                                    Homepagefrdj.Label2.Text = type
                                    TextBox1.Text = ""
                                    TextBox2.Text = ""
                                    Me.Hide()
                                ElseIf type = "ARD GL" Then
                                    'MsgBox("You have successfully logged in as" + " " + fullname, vbInformation)
                                    homepageard.Show()
                                    homepageard.Label1.Text = fullname
                                    homepageard.Label2.Text = type
                                    TextBox1.Text = ""
                                    TextBox2.Text = ""
                                    Me.Hide()
                                ElseIf type = "DQA" Then
                                    'MsgBox("You have successfully logged in as" + " " + fullname, vbInformation)
                                    homepagedqa.Show()
                                    homepagedqa.Label1.Text = fullname
                                    homepagedqa.Label2.Text = type
                                    TextBox1.Text = ""
                                    TextBox2.Text = ""
                                    Me.Hide()
                                ElseIf type = "FRD GL" Then
                                    'MsgBox("You have successfully logged in as" + " " + fullname, vbInformation)
                                    Homepagefrdgl.Show()
                                    Homepagefrdgl.Label1.Text = fullname
                                    Homepagefrdgl.Label2.Text = type
                                    TextBox1.Text = ""
                                    TextBox2.Text = ""
                                    Me.Hide()
                                ElseIf type = "IT" Then
                                    ' MsgBox("You have successfully logged in as" + " " + fullname, vbInformation)
                                    homepageit.Show()
                                    homepageit.Label1.Text = fullname
                                    homepageit.Label2.Text = type
                                    TextBox1.Text = ""
                                    TextBox2.Text = ""
                                    Me.Hide()
                                    'Stabilit Managment
                                ElseIf type = "GL" Then
                                    ' MsgBox("You have successfully logged in as" + " " + fullname, vbInformation)
                                    homepage.Show()
                                    homepage.Label1.Text = fullname
                                    homepage.Label2.Text = type
                                    TextBox1.Text = ""
                                    TextBox2.Text = ""
                                    Me.Hide()
                                ElseIf type = "JR" Then
                                    ' MsgBox("You have successfully logged in as" + " " + fullname, vbInformation)
                                    homepage.Show()
                                    homepage.Label1.Text = fullname
                                    homepage.Label2.Text = type
                                    TextBox1.Text = ""
                                    TextBox2.Text = ""
                                    Me.Hide()

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
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoginValidation()
        End If
    End Sub
    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoginValidation()
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

End Class