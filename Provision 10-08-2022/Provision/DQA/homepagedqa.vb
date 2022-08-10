Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class homepagedqa
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
    Private Sub homepagedqa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.ShadowForm(Me)
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel4, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        Label2.Hide()
        Panel2.Visible = False
        Panel3.Visible = False
        OpenChildForm(New dashboardall())

    End Sub
    Private Sub hidemenu()
        If Panel2.Visible <> True Then
            Panel2.Visible = False
        End If
    End Sub

    Private Sub showsubmenu(ByVal submenu As Panel)
        If submenu.Visible = False Then
            hidemenu()
            submenu.Visible = True
        Else
            submenu.Visible = False
        End If
    End Sub
    Private Sub hidemenudoc()
        If Panel3.Visible <> True Then
            Panel3.Visible = False
        End If
    End Sub
    Private Sub showsubmenudoc(ByVal submenu As Panel)
        If submenu.Visible = False Then
            hidemenu()
            submenu.Visible = True
        Else
            submenu.Visible = False
        End If
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
        Panel2.Hide()
        Panel3.Hide()
        GunaLabel1.Text = AButton1.Text
        OpenChildForm(New dashboardall())
    End Sub
    Private Sub AButton2_Click(sender As Object, e As EventArgs) Handles AButton2.Click
        showsubmenu(Panel2)
        GunaLabel1.Text = AButton2.Text
    End Sub
    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        GunaLabel1.Text = AButton2.Text + "-" + GunaAdvenceButton1.Text
        OpenChildForm(New datafromardlnb())
    End Sub

    Private Sub GunaAdvenceButton2_Click_1(sender As Object, e As EventArgs) Handles GunaAdvenceButton2.Click
        GunaLabel1.Text = AButton2.Text + "-" + GunaAdvenceButton2.Text
        OpenChildForm(New datafromardatr())
    End Sub
    Private Sub AButton3_Click(sender As Object, e As EventArgs) Handles AButton3.Click
        showsubmenudoc(Panel3)
        GunaLabel1.Text = AButton3.Text
        ' OpenChildForm(New sampleview())
    End Sub
    Private Sub GunaAdvenceButton7_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton7.Click
        GunaLabel1.Text = AButton3.Text + "-" + GunaAdvenceButton7.Text
        OpenChildForm(New viewproductpds())
    End Sub
    Private Sub GunaAdvenceButton6_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton6.Click
        GunaLabel1.Text = AButton3.Text + "-" + GunaAdvenceButton6.Text
        OpenChildForm(New viewproductstp())
    End Sub
    Private Sub GunaAdvenceButton5_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton5.Click
        GunaLabel1.Text = AButton3.Text + "-" + GunaAdvenceButton5.Text
        OpenChildForm(New viewproductatr())
    End Sub
    Private Sub AButto4_Click(sender As Object, e As EventArgs) Handles AButton4.Click
        Panel2.Hide()
        Panel3.Hide()
        GunaLabel1.Text = AButton4.Text
        OpenChildForm(New viewatrissuancelog())
    End Sub
    Private Sub AButton5_Click(sender As Object, e As EventArgs) Handles AButton5.Click
        Panel2.Hide()
        Panel3.Hide()
        GunaLabel1.Text = AButton5.Text
        'OpenChildForm(Nothing)
        Dim form As New viewtestmaster
        form.ShowDialog()
    End Sub
    Private Sub GunaAdvenceButton3_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton3.Click
        Panel2.Hide()
        Panel3.Hide()
        GunaLabel1.Text = GunaAdvenceButton3.Text
        OpenChildForm(New viewproductmastersdqa())
    End Sub
    Private Sub AButton6_Click(sender As Object, e As EventArgs) Handles AButton6.Click
        Panel2.Hide()
        Panel3.Hide()
        GunaLabel1.Text = AButton5.Text
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
        Dim form As New changepwdqa
        form.ShowDialog()
    End Sub

    Private Sub AsdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsdToolStripMenuItem.Click
        Dim form As New about
        form.ShowDialog()
    End Sub

End Class
