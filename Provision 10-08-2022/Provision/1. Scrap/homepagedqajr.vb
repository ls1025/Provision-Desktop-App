Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class homepagedqajr
    Dim currentchildForm As Form
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea

    End Sub
    Private Sub homepagedqajr_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.ShadowForm(Me)
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel4, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        Label2.Hide()


        OpenChildForm(New dashboardall())

    End Sub


    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        Me.Close()
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub OpenChildForm(childForm As Form)
        If currentchildForm IsNot Nothing Then
            currentchildForm.Close()
        End If
        currentchildForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        GunaPanel5.Controls.Add(childForm)
        GunaPanel5.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub
    Private Sub AButton1_Click(sender As Object, e As EventArgs) Handles AButton1.Click


        GunaLabel1.Text = AButton1.Text
        OpenChildForm(New dashboardall())
    End Sub
    Private Sub AButton2_Click(sender As Object, e As EventArgs) Handles AButton2.Click
        GunaLabel1.Text = AButton2.Text
        OpenChildForm(New viewreleaseddata())
    End Sub
    Private Sub AButton3_Click(sender As Object, e As EventArgs) Handles AButton3.Click
        GunaLabel1.Text = AButton3.Text
        OpenChildForm(New viewtrstatus())

    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Maximized Then
            FormBorderStyle = FormBorderStyle.None
        Else
            FormBorderStyle = FormBorderStyle.Sizable

        End If
    End Sub
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        ToolTip1.Show("Minimize", Button1)
    End Sub
    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover
        ToolTip1.Show("Maximize", Button2)
    End Sub
    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover
        ToolTip1.Show("Close", Button3)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MessageBox.Show("Are you sure to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        Else
        End If
    End Sub
    Private Sub AaaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AaaToolStripMenuItem.Click
        If MessageBox.Show("Are you sure to logout?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            login.Show()
            Me.Close()
        End If
    End Sub

    Private Sub AsdasdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsdasdToolStripMenuItem.Click
        Dim form As New changepwdqajr
        form.ShowDialog()
    End Sub

    Private Sub AsdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsdToolStripMenuItem.Click
        Dim form As New about
        form.ShowDialog()
    End Sub


End Class
