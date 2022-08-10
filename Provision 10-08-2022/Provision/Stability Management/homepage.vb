Imports System.ComponentModel
Imports System.Runtime.InteropServices
Public Class homepage
    Dim currentchildForm As Form
    Public Sub New()
        'This call is required by the designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call.
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea
    End Sub
    Private Sub homepage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.ShadowForm(Me)
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel4, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
        OpenChildForm(New dashboard())
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
    'Dashboard
    Private Sub AButton1_Click(sender As Object, e As EventArgs) Handles AButton1.Click
        GunaLabel1.Text = AButton1.Text
        OpenChildForm(New dashboard())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
    End Sub
    'Masters
    Private Sub AButton2_Click(sender As Object, e As EventArgs) Handles AButton2.Click
        GunaLabel1.Text = AButton2.Text
        OpenChildForm(New masters())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
    End Sub
    Private Sub hidemenuanalysis()
        If Panel4.Visible <> True Then
            Panel4.Visible = False
        End If
    End Sub
    Private Sub showsubmenuanalysis(ByVal submenu As Panel)
        If submenu.Visible = False Then
            hidemenu()
            submenu.Visible = True
        Else
            submenu.Visible = False
        End If
    End Sub
    'Analysis Management
    Private Sub AButton3_Click(sender As Object, e As EventArgs) Handles AButton3.Click
        showsubmenuanalysis(Panel4)
        GunaLabel1.Text = AButton3.Text
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
    End Sub
    'Analysis Management-Released Date
    Private Sub GunaAdvenceButton7_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton7.Click
        GunaLabel1.Text = AButton3.Text + " - " + GunaAdvenceButton7.Text
        OpenChildForm(New viewreleaseddata())

        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
    End Sub
    'Analysis Management-Intimation Status
    Private Sub GunaAdvenceButton9_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton9.Click
        GunaLabel1.Text = AButton3.Text + " - " + GunaAdvenceButton9.Text
        OpenChildForm(New viewtrstatus())
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
    End Sub
    Private Sub hidemenuplanner()
        If Panel2.Visible <> True Then
            Panel2.Visible = False
        End If
    End Sub
    Private Sub showsubmenuplanner(ByVal submenu As Panel)
        If submenu.Visible = False Then
            hidemenu()
            submenu.Visible = True
        Else
            submenu.Visible = False
        End If
    End Sub

    'Stability Management
    Private Sub AButton4_Click(sender As Object, e As EventArgs) Handles AButton4.Click

        showsubmenuplanner(Panel2)
        GunaLabel1.Text = AButton4.Text
        Panel3.Visible = False
        Panel1.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
    End Sub
    'Stability Management-Charging
    Private Sub GunaAdvenceButton14_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton14.Click
        GunaLabel1.Text = AButton4.Text + " - " + GunaAdvenceButton14.Text
        OpenChildForm(New viewstabilityprotocoldqa())
        Panel1.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
    End Sub
    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        GunaLabel1.Text = AButton4.Text + " - " + GunaAdvenceButton1.Text
        OpenChildForm(New viewchrgplanner())
        Panel1.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
    End Sub
    'Stability Management-Withdrawal
    Private Sub GunaAdvenceButton3_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton3.Click
        GunaLabel1.Text = AButton4.Text + " - " + GunaAdvenceButton3.Text
        OpenChildForm(New viewwitdplanner())
        Panel1.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
    End Sub
    'Stability Planner-Reconciliation
    Private Sub GunaAdvenceButton4_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton4.Click
        GunaLabel1.Text = AButton4.Text + " - " + GunaAdvenceButton4.Text
        OpenChildForm(New sampleview())
        Panel1.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
    End Sub
    Private Sub hidemenurld()
        If Panel1.Visible <> True Then
            Panel1.Visible = False
        End If
    End Sub
    Private Sub showsubmenurld(ByVal submenu As Panel)
        If submenu.Visible = False Then
            hidemenu()
            submenu.Visible = True
        Else
            submenu.Visible = False
        End If
    End Sub
    'RLD Management
    Private Sub AButton5_Click(sender As Object, e As EventArgs) Handles AButton5.Click
        GunaLabel1.Text = AButton5.Text 
        showsubmenurld(Panel1)
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
    End Sub
    'RLD Management-RLD Master Details
    Private Sub GunaAdvenceButton6_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton6.Click
        GunaLabel1.Text = "RLD Master Details"
        OpenChildForm(New viewrldmasterdata())
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        Panel7.Visible = False
    End Sub
    Private Sub hidemenuarchival()
        If Panel5.Visible <> True Then
            Panel5.Visible = False
        End If
    End Sub
    Private Sub showsubmenuarchival(ByVal submenu As Panel)
        If submenu.Visible = False Then
            hidemenu()
            submenu.Visible = True
        Else
            submenu.Visible = False
        End If
    End Sub
    'Archival Management
    Private Sub AButton6_Click(sender As Object, e As EventArgs) Handles AButton6.Click
        GunaLabel1.Text = AButton6.Text
        showsubmenuarchival(Panel5)
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel7.Visible = False
    End Sub

    Private Sub GunaAdvenceButton8_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton8.Click
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel7.Visible = False
        GunaLabel1.Text = GunaAdvenceButton8.Text
        OpenChildForm(New viewhandoverdoctype())
    End Sub
    Private Sub GunaAdvenceButton12_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton12.Click
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel7.Visible = False
        GunaLabel1.Text = GunaAdvenceButton12.Text
        OpenChildForm(New viewarchivedoctype())
    End Sub
    Private Sub GunaAdvenceButton13_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton13.Click
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel7.Visible = False
        GunaLabel1.Text = GunaAdvenceButton13.Text
        OpenChildForm(New viewlocationmain())
    End Sub
    Private Sub GunaAdvenceButton10_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton10.Click
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel7.Visible = False
        GunaLabel1.Text = GunaAdvenceButton10.Text
        OpenChildForm(New viewissuedoctype())
    End Sub
    Private Sub hidemenu()
        If Panel3.Visible <> True Then
            Panel3.Visible = False
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
    Private Sub hidemenuProduct()
        If Panel7.Visible <> True Then
            Panel7.Visible = False
        End If
    End Sub
    Private Sub showsubmenuproduct(ByVal submenu As Panel)
        If submenu.Visible = False Then
            hidemenuProduct()
            submenu.Visible = True
        Else
            submenu.Visible = False
        End If
    End Sub
    Private Sub AButton7_Click(sender As Object, e As EventArgs) Handles AButton7.Click
        GunaLabel1.Text = AButton7.Text
        showsubmenuproduct(Panel7)
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
    End Sub
    Private Sub GunaAdvenceButton15_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton15.Click
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        GunaLabel1.Text = AButton7.Text + "-" + GunaAdvenceButton15.Text
        OpenChildForm(New viewproductmasters())
    End Sub

    Private Sub GunaAdvenceButton16_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton16.Click
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        GunaLabel1.Text = AButton7.Text + "-" + GunaAdvenceButton16.Text
        OpenChildForm(New viewlnbmaster)
    End Sub

    Private Sub GunaAdvenceButton17_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton17.Click
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        GunaLabel1.Text = AButton7.Text + "-" + GunaAdvenceButton17.Text
        OpenChildForm(New viewlicenseproductwise)
    End Sub


    'Corrections
    Private Sub AButton8_Click(sender As Object, e As EventArgs) Handles AButton8.Click
        Panel2.Visible = False
        Panel1.Visible = False
        Panel4.Visible = False
        If Label2.Text = "GL" Then
            showsubmenu(Panel3)
            GunaLabel1.Text = AButton8.Text
        Else
            MsgBox("Access Denied. You are not authorized", vbExclamation)
        End If
    End Sub
    'Correction-Charging
    Private Sub GunaAdvenceButton5_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton5.Click
        Panel1.Visible = False
        Panel2.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        If Label2.Text = "GL" Then
            GunaLabel1.Text = AButton8.Text + "-" + GunaAdvenceButton5.Text
            OpenChildForm(New viewchrgcorrections())
        Else
            MsgBox("Access Denied. You are not authorized", vbExclamation)
        End If

    End Sub
    Private Sub GunaAdvenceButton11_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton11.Click
        Panel1.Visible = False
        Panel2.Visible = False
        Panel4.Visible = False
        Panel5.Visible = False
        GunaLabel1.Text = GunaAdvenceButton11.Text
        OpenChildForm(New viewequipusage())
    End Sub
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub GunaPanel3_MouseDown(sender As Object, e As MouseEventArgs) Handles GunaPanel3.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
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
            Me.Close()
            Application.Exit()
        Else
        End If
    End Sub



    Private Sub GunaPanel5_Paint(sender As Object, e As PaintEventArgs) Handles GunaPanel5.Paint

    End Sub

    Private Sub GunaCircleButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub homepage_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'ExpportChargingPlanner()
        ' ExpportWithdrawalPlanner()
        '  ExportReconcilationDataTable()
    End Sub

    Private Sub AaaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AaaToolStripMenuItem.Click
        If MessageBox.Show("Are you sure to logout?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            login.Show()
            Me.Close()
        Else

        End If
    End Sub

    Private Sub AsdasdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsdasdToolStripMenuItem.Click
        Dim form As New changepw
        form.ShowDialog()
    End Sub

    Private Sub AsdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsdToolStripMenuItem.Click
        Dim form As New about
        form.ShowDialog()
    End Sub


End Class
