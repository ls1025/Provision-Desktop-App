Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class Homepagefrdj
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
    Private Sub Homepagefrdj_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.ShadowForm(Me)
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel4, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        'Label2.Hide()
        Panel2.Visible = False
        Panel3.Visible = False
        Panel5.Visible = False
        OpenChildForm(New dashboardfrd())

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
    Private Sub showsubmenudoc(ByVal submenu As Panel)
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
    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        Me.Close()
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
        Panel5.Hide()
        GunaLabel1.Text = AButton1.Text
        OpenChildForm(New dashboardfrd())
    End Sub
    Private Sub AButto2_Click(sender As Object, e As EventArgs) Handles AButton2.Click
        Panel2.Hide()
        Panel3.Hide()
        Panel5.Hide()
        GunaLabel1.Text = AButton2.Text
        OpenChildForm(New viewproductmastersdqa())
    End Sub
    Private Sub AButton3_Click(sender As Object, e As EventArgs) Handles AButton3.Click
        Panel3.Hide()
        Panel5.Hide()
        showsubmenu(Panel2)
    End Sub

    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        Panel3.Hide()
        Panel5.Hide()
        GunaLabel1.Text = AButton3.Text + "-" + GunaAdvenceButton1.Text
        OpenChildForm(New Viewintimationdev())
    End Sub

    Private Sub GunaAdvenceButton2_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton2.Click
        Panel3.Hide()
        Panel5.Hide()
        GunaLabel1.Text = AButton3.Text + "-" + GunaAdvenceButton2.Text
        OpenChildForm(New Viewintimationrot())
    End Sub

    Private Sub GunaAdvenceButton3_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton3.Click
        Panel3.Hide()
        Panel5.Hide()
        GunaLabel1.Text = AButton3.Text + "-" + GunaAdvenceButton3.Text
        OpenChildForm(New viewintimationstb())
    End Sub
    Private Sub AButton4_Click(sender As Object, e As EventArgs) Handles AButton4.Click
        Panel2.Hide()
        Panel5.Hide()
        showsubmenudoc(Panel3)
        ' OpenChildForm(New sampleview())
    End Sub
    Private Sub GunaAdvenceButton5_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton5.Click
        Panel2.Hide()
        Panel5.Hide()
        GunaLabel1.Text = AButton4.Text + "-" + GunaAdvenceButton5.Text
        OpenChildForm(New viewproductpdsfrd())
    End Sub
    Private Sub GunaAdvenceButton4_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton4.Click
        Panel2.Hide()
        Panel5.Hide()
        GunaLabel1.Text = AButton4.Text + "-" + GunaAdvenceButton4.Text
        OpenChildForm(New viewproductstpfrd())
    End Sub
    Private Sub AButton5_Click(sender As Object, e As EventArgs) Handles AButton5.Click
        Panel2.Hide()
        Panel3.Hide()
        Panel5.Hide()
        GunaLabel1.Text = AButton5.Text
        OpenChildForm(New viewtrstatusfrdj())
    End Sub
    Private Sub ShowSubMenuStability(ByVal submenu As Panel)
        If submenu.Visible = False Then
            HideShowSubMenuStability()
            submenu.Visible = True
        Else
            submenu.Visible = False
        End If
    End Sub
    Private Sub HideShowSubMenuStability()
        If Panel5.Visible <> True Then
            Panel5.Visible = False
        End If
    End Sub
    Private Sub GunaAdvenceButton8_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton8.Click
        Panel2.Hide()
        Panel3.Hide()
        ShowSubMenuStability(Panel5)
    End Sub
    Private Sub GunaAdvenceButton9_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton9.Click
        Panel2.Hide()
        Panel3.Hide()
        GunaLabel1.Text = GunaAdvenceButton9.Text
        OpenChildForm(New viewstabilityprotocol())
    End Sub
    Private Sub GunaAdvenceButton7_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton7.Click
        Panel2.Hide()
        Panel3.Hide()
        GunaLabel1.Text = GunaAdvenceButton7.Text
        OpenChildForm(New viewstabilitysampledetails())
    End Sub
    Private Sub GunaAdvenceButton6_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton6.Click
        Panel2.Hide()
        Panel3.Hide()
        GunaLabel1.Text = GunaAdvenceButton6.Text
        OpenChildForm(New viewrldmasterdatafrd())
    End Sub
    Private Sub GunaAdvenceButton10_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton10.Click
        Panel2.Hide()
        Panel3.Hide()
        OpenChildForm(New inventrydashboard())
    End Sub
    Private Sub GunaAdvenceButton11_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton11.Click
        'Panel2.Hide()
        'Panel3.Hide()
        'GunaLabel1.Text = GunaAdvenceButton11.Text
        'OpenChildForm(New viewmaterials())
    End Sub
    Private Sub GunaAdvenceButton12_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton12.Click
        Panel2.Hide()
        Panel3.Hide()
        GunaLabel1.Text = GunaAdvenceButton12.Text
        OpenChildForm(New viewequipusage())
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
        Dim form As New changepwfrdj
        form.ShowDialog()
    End Sub

    Private Sub AsdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsdToolStripMenuItem.Click
        Dim form As New about
        form.ShowDialog()
    End Sub


End Class
