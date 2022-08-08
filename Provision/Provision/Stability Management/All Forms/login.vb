Imports System.Data.OleDb
Public Class login
    Dim cmd As OleDbCommand
    Dim cmd1 As OleDbCommand
    Dim cmd2 As OleDbCommand
    Dim cmd3 As OleDbCommand
    Public n1 As String
    'load username as per user ID
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea

    End Sub
    Public Sub loadusername()
        If con.State = ConnectionState.Open Then con.Close()
        Dim qry As String
        qry = "select [Full Name] from users where [username]='" + TextBox1.Text + "'"
        cmd = New OleDbCommand(qry, con)
        con.Open()
        n1 = cmd.ExecuteScalar().ToString()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        LoginMethod()
    End Sub
    Private Sub LoginMethod()
        Try
            If con.State = ConnectionState.Open Then con.Close()

            If TextBox1.Text = "" Then
                MsgBox("Please enter username..", MsgBoxStyle.Critical)
            ElseIf TextBox2.Text = "" Then
                MsgBox("Please enter password..", MsgBoxStyle.Critical)
            Else
                If con.State = ConnectionState.Open Then con.Close()
                Dim qry As String
                qry = "select Count(*) from users where username='" + TextBox1.Text + "'"
                cmd = New OleDbCommand(qry, con)
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
                    cmd1 = New OleDbCommand(qry1, con)
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter(cmd1)
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
                        MsgBox("You Password has been expired, Please change your password", vbExclamation, "Change Password")
                        changeinitialpw.ShowDialog()

                    ElseIf userstatus = "Renew" And password <> TextBox2.Text Then
                        MsgBox("Invalid Username or Password", vbCritical)
                    ElseIf userstatus = "Active" Then
                        If con.State = ConnectionState.Open Then con.Close()
                        If password <> TextBox2.Text Then
                            MsgBox("Invalid Password", vbCritical)
                        ElseIf password = TextBox2.Text Then
                            Try
                                If con.State = ConnectionState.Open Then con.Close()
                                Dim qry2 As String
                                qry2 = "select type from users where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'"
                                cmd2 = New OleDbCommand(qry2, con)
                                con.Open()
                                Dim type As String
                                type = cmd2.ExecuteScalar().ToString()

                                'MsgBox("You have successfully logged in as" + " " + fullname, vbInformation)
                                homepage.Show()
                                homepage.Label1.Text = fullname
                                homepage.Label2.Text = type
                                Me.Close()

                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub login_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBox1.Focus()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoginMethod()
        End If
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs)

    End Sub
End Class