
Imports System.IO
Public Class backup

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            '  Dim sfd As New SaveFileDialog With {.Filter = "Access Database | "}

            '  If sfd.ShowDialog = 1 Then


            'set the destination and a file name with the date and time
            Dim backupfiledestination As String = "\\192.168.2.200\DQA\" & Format(Now(), "dd MMM yyyy HH mm ss") & ".bck"
                'location of the database file that you want to backup
                Dim databaseFile As String = "D:\Stability Planner\stb_pln.accdb"

                'create a backup by using Filecopy Command to copy the file from  location to destination
                FileCopy(databaseFile, backupfiledestination)
            MsgBox("Backup Completed Successfully in \\192.168.2.200\DQA Folder", vbInformation)
            '  End If
        Catch ex As Exception
            'catch an error  
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim pwD As New PasswordDialogBox
        If pwD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                OpenFileDialog1.Filter = "Access | *.bck"
                If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                    Dim msgText As String
                    msgText = "Are you sure you want to restore your database? It will overwite your database since the backup have made."
                    'validate if you want to restore or not
                    If MessageBox.Show(msgText, "Restore", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then


                        Dim sourcepath As String = OpenFileDialog1.FileName
                        Dim DestPath As String = "D:\Stability Planner\"

                        'copy backup file to the E:\Stability Planner path
                        Dim file = New FileInfo(OpenFileDialog1.FileName)
                        file.CopyTo(Path.Combine(DestPath, file.Name), True)

                        'delete olde databse file
                        Dim FileToDelete As String
                        FileToDelete = "D:\Stability Planner\stb_pln.accdb"
                        System.IO.File.Delete(FileToDelete)

                        'Rename the copied database file to stb_pln
                        My.Computer.FileSystem.RenameFile("D:\Stability Planner\" & file.Name, "stb_pln.accdb")
                        MsgBox("Database Successfully Restored", vbInformation)

                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            'MessageBox.Show("The user entered the following password: '" & pwD.Password & "'", "Password Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ' MessageBox.Show("The user cancelled.", "User Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If



    End Sub
    Private Sub backup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
End Class
Public Class PasswordDialogBox
    Inherits Form
    Friend WithEvents tbPassword As New TextBox With {.PasswordChar = "*"c, .Parent = Me}
    Friend WithEvents Label1 As New Label With {.Parent = Me}
    Friend WithEvents okButton As New Button With {.Text = "OK", .Parent = Me}
    Friend Shadows WithEvents cancelButton As New Button With {.Text = "Cancel", .Parent = Me}
    Public Property Password As String
    Sub New()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Size = New Size(300, 200)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Enter Password"
        tbPassword.Font = New Font(Font.FontFamily, 10)
        tbPassword.Left = Me.ClientRectangle.Width \ 2 - tbPassword.ClientRectangle.Width \ 2
        tbPassword.Top = Me.ClientRectangle.Height \ 2 - tbPassword.ClientRectangle.Height \ 2
        Label1.AutoSize = True
        Label1.Text = Environment.NewLine + "Please enter a password to restore"
        Label1.Left = (Me.ClientRectangle.Width \ 2) - (Label1.ClientRectangle.Width \ 2)
        'okButton.Left = Me.ClientRectangle.Width - 5 - okButton.ClientRectangle.Width
        'okButton.Top = Me.ClientRectangle.Height - 5 - okButton.Height
        cancelButton.Left = Me.ClientRectangle.Width - 5 - okButton.ClientRectangle.Width
        cancelButton.Top = Me.ClientRectangle.Height - 5 - okButton.Height
        'cancelButton.Left = 5
        ' cancelButton.Top = Me.ClientRectangle.Height - 5 - cancelButton.Height
        okButton.Left = 5
        okButton.Top = Me.ClientRectangle.Height - 5 - cancelButton.Height
    End Sub
    Private Sub okButton_Click(sender As Object, e As EventArgs) Handles okButton.Click
        If tbPassword.Text = "" Then
            MessageBox.Show("Password is invalid, please re-enter your password or cancel.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf PasswordMeetsCriteria(tbPassword.Text) Then
            Me.Password = tbPassword.Text
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MessageBox.Show("Password is invalid, please re-enter your password or cancel.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Function PasswordMeetsCriteria(password As String) As Boolean
        Dim validCharacters As String = "kalavathi1991"
        For Each c As Char In password
            If validCharacters.IndexOf(c) = -1 Then Return False
        Next
        Return True
    End Function
    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class