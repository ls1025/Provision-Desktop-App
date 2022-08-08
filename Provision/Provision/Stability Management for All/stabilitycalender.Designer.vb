<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class stabilitycalender
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnPrevMonth = New Guna.UI.WinForms.GunaGradientButton()
        Me.btnNextMonth = New Guna.UI.WinForms.GunaGradientButton()
        Me.btnToday = New Guna.UI.WinForms.GunaGradientButton()
        Me.lblMonthAndYear = New Guna.UI.WinForms.GunaLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GunaGradientButton7 = New Guna.UI.WinForms.GunaGradientButton()
        Me.GunaGradientButton6 = New Guna.UI.WinForms.GunaGradientButton()
        Me.GunaGradientButton5 = New Guna.UI.WinForms.GunaGradientButton()
        Me.GunaGradientButton4 = New Guna.UI.WinForms.GunaGradientButton()
        Me.GunaGradientButton3 = New Guna.UI.WinForms.GunaGradientButton()
        Me.GunaGradientButton2 = New Guna.UI.WinForms.GunaGradientButton()
        Me.GunaGradientButton1 = New Guna.UI.WinForms.GunaGradientButton()
        Me.flDays = New System.Windows.Forms.FlowLayoutPanel()
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.Button2 = New Guna.UI.WinForms.GunaGradientButton()
        Me.Button1 = New Guna.UI.WinForms.GunaGradientButton()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GunaPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.lblMonthAndYear)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1232, 58)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(98, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 17)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(220, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 17)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(220, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnPrevMonth)
        Me.Panel4.Controls.Add(Me.btnNextMonth)
        Me.Panel4.Controls.Add(Me.btnToday)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(987, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(245, 58)
        Me.Panel4.TabIndex = 3
        '
        'btnPrevMonth
        '
        Me.btnPrevMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrevMonth.AnimationHoverSpeed = 0.07!
        Me.btnPrevMonth.AnimationSpeed = 0.03!
        Me.btnPrevMonth.BackColor = System.Drawing.Color.Transparent
        Me.btnPrevMonth.BaseColor1 = System.Drawing.Color.Transparent
        Me.btnPrevMonth.BaseColor2 = System.Drawing.Color.Transparent
        Me.btnPrevMonth.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.btnPrevMonth.BorderSize = 1
        Me.btnPrevMonth.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrevMonth.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnPrevMonth.FocusedColor = System.Drawing.Color.Empty
        Me.btnPrevMonth.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevMonth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.btnPrevMonth.Image = Global.Provision.My.Resources.Resources.arrow_pointing_left_50px
        Me.btnPrevMonth.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.btnPrevMonth.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnPrevMonth.Location = New System.Drawing.Point(15, 9)
        Me.btnPrevMonth.Name = "btnPrevMonth"
        Me.btnPrevMonth.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.btnPrevMonth.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.btnPrevMonth.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.btnPrevMonth.OnHoverForeColor = System.Drawing.Color.White
        Me.btnPrevMonth.OnHoverImage = Global.Provision.My.Resources.Resources.arrow_pointing_left_50px_1
        Me.btnPrevMonth.OnPressedColor = System.Drawing.Color.Black
        Me.btnPrevMonth.Radius = 5
        Me.btnPrevMonth.Size = New System.Drawing.Size(59, 42)
        Me.btnPrevMonth.TabIndex = 7
        Me.btnPrevMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnNextMonth
        '
        Me.btnNextMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNextMonth.AnimationHoverSpeed = 0.07!
        Me.btnNextMonth.AnimationSpeed = 0.03!
        Me.btnNextMonth.BackColor = System.Drawing.Color.Transparent
        Me.btnNextMonth.BaseColor1 = System.Drawing.Color.Transparent
        Me.btnNextMonth.BaseColor2 = System.Drawing.Color.Transparent
        Me.btnNextMonth.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.btnNextMonth.BorderSize = 1
        Me.btnNextMonth.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNextMonth.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnNextMonth.FocusedColor = System.Drawing.Color.Empty
        Me.btnNextMonth.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextMonth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.btnNextMonth.Image = Global.Provision.My.Resources.Resources.arrow_50px
        Me.btnNextMonth.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.btnNextMonth.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnNextMonth.Location = New System.Drawing.Point(176, 8)
        Me.btnNextMonth.Name = "btnNextMonth"
        Me.btnNextMonth.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.btnNextMonth.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.btnNextMonth.OnHoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.btnNextMonth.OnHoverForeColor = System.Drawing.Color.White
        Me.btnNextMonth.OnHoverImage = Global.Provision.My.Resources.Resources.arrow_50px_1
        Me.btnNextMonth.OnPressedColor = System.Drawing.Color.Black
        Me.btnNextMonth.Radius = 5
        Me.btnNextMonth.Size = New System.Drawing.Size(59, 42)
        Me.btnNextMonth.TabIndex = 6
        Me.btnNextMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnToday
        '
        Me.btnToday.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnToday.AnimationHoverSpeed = 0.07!
        Me.btnToday.AnimationSpeed = 0.03!
        Me.btnToday.BackColor = System.Drawing.Color.Transparent
        Me.btnToday.BaseColor1 = System.Drawing.Color.Transparent
        Me.btnToday.BaseColor2 = System.Drawing.Color.Transparent
        Me.btnToday.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.btnToday.BorderSize = 1
        Me.btnToday.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnToday.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnToday.FocusedColor = System.Drawing.Color.Empty
        Me.btnToday.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToday.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.btnToday.Image = Nothing
        Me.btnToday.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnToday.Location = New System.Drawing.Point(80, 9)
        Me.btnToday.Name = "btnToday"
        Me.btnToday.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.btnToday.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.btnToday.OnHoverBorderColor = System.Drawing.Color.White
        Me.btnToday.OnHoverForeColor = System.Drawing.Color.White
        Me.btnToday.OnHoverImage = Nothing
        Me.btnToday.OnPressedColor = System.Drawing.Color.Black
        Me.btnToday.Radius = 5
        Me.btnToday.Size = New System.Drawing.Size(90, 42)
        Me.btnToday.TabIndex = 5
        Me.btnToday.Text = "Today"
        Me.btnToday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMonthAndYear
        '
        Me.lblMonthAndYear.AutoSize = True
        Me.lblMonthAndYear.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!)
        Me.lblMonthAndYear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.lblMonthAndYear.Location = New System.Drawing.Point(8, 8)
        Me.lblMonthAndYear.Name = "lblMonthAndYear"
        Me.lblMonthAndYear.Size = New System.Drawing.Size(199, 41)
        Me.lblMonthAndYear.TabIndex = 2
        Me.lblMonthAndYear.Text = "August, 2020"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.GunaGradientButton7)
        Me.Panel3.Controls.Add(Me.GunaGradientButton6)
        Me.Panel3.Controls.Add(Me.GunaGradientButton5)
        Me.Panel3.Controls.Add(Me.GunaGradientButton4)
        Me.Panel3.Controls.Add(Me.GunaGradientButton3)
        Me.Panel3.Controls.Add(Me.GunaGradientButton2)
        Me.Panel3.Controls.Add(Me.GunaGradientButton1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 58)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1232, 41)
        Me.Panel3.TabIndex = 1
        '
        'GunaGradientButton7
        '
        Me.GunaGradientButton7.AnimationHoverSpeed = 0.07!
        Me.GunaGradientButton7.AnimationSpeed = 0.03!
        Me.GunaGradientButton7.BackColor = System.Drawing.Color.Transparent
        Me.GunaGradientButton7.BaseColor1 = System.Drawing.Color.DarkTurquoise
        Me.GunaGradientButton7.BaseColor2 = System.Drawing.Color.Fuchsia
        Me.GunaGradientButton7.BorderColor = System.Drawing.Color.Black
        Me.GunaGradientButton7.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaGradientButton7.FocusedColor = System.Drawing.Color.Empty
        Me.GunaGradientButton7.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.GunaGradientButton7.ForeColor = System.Drawing.Color.White
        Me.GunaGradientButton7.Image = Nothing
        Me.GunaGradientButton7.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaGradientButton7.Location = New System.Drawing.Point(1052, 2)
        Me.GunaGradientButton7.Name = "GunaGradientButton7"
        Me.GunaGradientButton7.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.GunaGradientButton7.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaGradientButton7.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaGradientButton7.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaGradientButton7.OnHoverImage = Nothing
        Me.GunaGradientButton7.OnPressedColor = System.Drawing.Color.Black
        Me.GunaGradientButton7.Radius = 5
        Me.GunaGradientButton7.Size = New System.Drawing.Size(165, 37)
        Me.GunaGradientButton7.TabIndex = 12
        Me.GunaGradientButton7.Text = "Saturday"
        Me.GunaGradientButton7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaGradientButton6
        '
        Me.GunaGradientButton6.AnimationHoverSpeed = 0.07!
        Me.GunaGradientButton6.AnimationSpeed = 0.03!
        Me.GunaGradientButton6.BackColor = System.Drawing.Color.Transparent
        Me.GunaGradientButton6.BaseColor1 = System.Drawing.Color.Chartreuse
        Me.GunaGradientButton6.BaseColor2 = System.Drawing.Color.LightGreen
        Me.GunaGradientButton6.BorderColor = System.Drawing.Color.Black
        Me.GunaGradientButton6.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaGradientButton6.FocusedColor = System.Drawing.Color.Empty
        Me.GunaGradientButton6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.GunaGradientButton6.ForeColor = System.Drawing.Color.White
        Me.GunaGradientButton6.Image = Nothing
        Me.GunaGradientButton6.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaGradientButton6.Location = New System.Drawing.Point(879, 2)
        Me.GunaGradientButton6.Name = "GunaGradientButton6"
        Me.GunaGradientButton6.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.GunaGradientButton6.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaGradientButton6.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaGradientButton6.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaGradientButton6.OnHoverImage = Nothing
        Me.GunaGradientButton6.OnPressedColor = System.Drawing.Color.Black
        Me.GunaGradientButton6.Radius = 5
        Me.GunaGradientButton6.Size = New System.Drawing.Size(165, 37)
        Me.GunaGradientButton6.TabIndex = 11
        Me.GunaGradientButton6.Text = "Friday"
        Me.GunaGradientButton6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaGradientButton5
        '
        Me.GunaGradientButton5.AnimationHoverSpeed = 0.07!
        Me.GunaGradientButton5.AnimationSpeed = 0.03!
        Me.GunaGradientButton5.BackColor = System.Drawing.Color.Transparent
        Me.GunaGradientButton5.BaseColor1 = System.Drawing.Color.Orange
        Me.GunaGradientButton5.BaseColor2 = System.Drawing.Color.SandyBrown
        Me.GunaGradientButton5.BorderColor = System.Drawing.Color.Black
        Me.GunaGradientButton5.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaGradientButton5.FocusedColor = System.Drawing.Color.Empty
        Me.GunaGradientButton5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.GunaGradientButton5.ForeColor = System.Drawing.Color.White
        Me.GunaGradientButton5.Image = Nothing
        Me.GunaGradientButton5.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaGradientButton5.Location = New System.Drawing.Point(704, 2)
        Me.GunaGradientButton5.Name = "GunaGradientButton5"
        Me.GunaGradientButton5.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.GunaGradientButton5.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaGradientButton5.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaGradientButton5.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaGradientButton5.OnHoverImage = Nothing
        Me.GunaGradientButton5.OnPressedColor = System.Drawing.Color.Black
        Me.GunaGradientButton5.Radius = 5
        Me.GunaGradientButton5.Size = New System.Drawing.Size(166, 37)
        Me.GunaGradientButton5.TabIndex = 10
        Me.GunaGradientButton5.Text = "Thursday"
        Me.GunaGradientButton5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaGradientButton4
        '
        Me.GunaGradientButton4.AnimationHoverSpeed = 0.07!
        Me.GunaGradientButton4.AnimationSpeed = 0.03!
        Me.GunaGradientButton4.BackColor = System.Drawing.Color.Transparent
        Me.GunaGradientButton4.BaseColor1 = System.Drawing.Color.MediumSpringGreen
        Me.GunaGradientButton4.BaseColor2 = System.Drawing.Color.LightSeaGreen
        Me.GunaGradientButton4.BorderColor = System.Drawing.Color.Black
        Me.GunaGradientButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaGradientButton4.FocusedColor = System.Drawing.Color.Empty
        Me.GunaGradientButton4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.GunaGradientButton4.ForeColor = System.Drawing.Color.White
        Me.GunaGradientButton4.Image = Nothing
        Me.GunaGradientButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaGradientButton4.Location = New System.Drawing.Point(528, 2)
        Me.GunaGradientButton4.Name = "GunaGradientButton4"
        Me.GunaGradientButton4.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.GunaGradientButton4.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaGradientButton4.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaGradientButton4.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaGradientButton4.OnHoverImage = Nothing
        Me.GunaGradientButton4.OnPressedColor = System.Drawing.Color.Black
        Me.GunaGradientButton4.Radius = 5
        Me.GunaGradientButton4.Size = New System.Drawing.Size(166, 37)
        Me.GunaGradientButton4.TabIndex = 9
        Me.GunaGradientButton4.Text = "Wednesday"
        Me.GunaGradientButton4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaGradientButton3
        '
        Me.GunaGradientButton3.AnimationHoverSpeed = 0.07!
        Me.GunaGradientButton3.AnimationSpeed = 0.03!
        Me.GunaGradientButton3.BackColor = System.Drawing.Color.Transparent
        Me.GunaGradientButton3.BaseColor1 = System.Drawing.Color.SlateBlue
        Me.GunaGradientButton3.BaseColor2 = System.Drawing.Color.MediumOrchid
        Me.GunaGradientButton3.BorderColor = System.Drawing.Color.Black
        Me.GunaGradientButton3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaGradientButton3.FocusedColor = System.Drawing.Color.Empty
        Me.GunaGradientButton3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.GunaGradientButton3.ForeColor = System.Drawing.Color.White
        Me.GunaGradientButton3.Image = Nothing
        Me.GunaGradientButton3.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaGradientButton3.Location = New System.Drawing.Point(353, 2)
        Me.GunaGradientButton3.Name = "GunaGradientButton3"
        Me.GunaGradientButton3.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.GunaGradientButton3.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaGradientButton3.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaGradientButton3.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaGradientButton3.OnHoverImage = Nothing
        Me.GunaGradientButton3.OnPressedColor = System.Drawing.Color.Black
        Me.GunaGradientButton3.Radius = 5
        Me.GunaGradientButton3.Size = New System.Drawing.Size(166, 37)
        Me.GunaGradientButton3.TabIndex = 8
        Me.GunaGradientButton3.Text = "Tuesday"
        Me.GunaGradientButton3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaGradientButton2
        '
        Me.GunaGradientButton2.AnimationHoverSpeed = 0.07!
        Me.GunaGradientButton2.AnimationSpeed = 0.03!
        Me.GunaGradientButton2.BackColor = System.Drawing.Color.Transparent
        Me.GunaGradientButton2.BaseColor1 = System.Drawing.Color.DarkTurquoise
        Me.GunaGradientButton2.BaseColor2 = System.Drawing.Color.DeepSkyBlue
        Me.GunaGradientButton2.BorderColor = System.Drawing.Color.Black
        Me.GunaGradientButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaGradientButton2.FocusedColor = System.Drawing.Color.Empty
        Me.GunaGradientButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.GunaGradientButton2.ForeColor = System.Drawing.Color.White
        Me.GunaGradientButton2.Image = Nothing
        Me.GunaGradientButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaGradientButton2.Location = New System.Drawing.Point(178, 2)
        Me.GunaGradientButton2.Name = "GunaGradientButton2"
        Me.GunaGradientButton2.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.GunaGradientButton2.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaGradientButton2.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaGradientButton2.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaGradientButton2.OnHoverImage = Nothing
        Me.GunaGradientButton2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaGradientButton2.Radius = 5
        Me.GunaGradientButton2.Size = New System.Drawing.Size(166, 37)
        Me.GunaGradientButton2.TabIndex = 7
        Me.GunaGradientButton2.Text = "Monday"
        Me.GunaGradientButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaGradientButton1
        '
        Me.GunaGradientButton1.AnimationHoverSpeed = 0.07!
        Me.GunaGradientButton1.AnimationSpeed = 0.03!
        Me.GunaGradientButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaGradientButton1.BaseColor1 = System.Drawing.Color.Crimson
        Me.GunaGradientButton1.BaseColor2 = System.Drawing.Color.DeepPink
        Me.GunaGradientButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaGradientButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaGradientButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaGradientButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!)
        Me.GunaGradientButton1.ForeColor = System.Drawing.Color.White
        Me.GunaGradientButton1.Image = Nothing
        Me.GunaGradientButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaGradientButton1.Location = New System.Drawing.Point(5, 3)
        Me.GunaGradientButton1.Name = "GunaGradientButton1"
        Me.GunaGradientButton1.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.GunaGradientButton1.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaGradientButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaGradientButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaGradientButton1.OnHoverImage = Nothing
        Me.GunaGradientButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaGradientButton1.Radius = 5
        Me.GunaGradientButton1.Size = New System.Drawing.Size(165, 37)
        Me.GunaGradientButton1.TabIndex = 4
        Me.GunaGradientButton1.Text = "Sunday"
        Me.GunaGradientButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'flDays
        '
        Me.flDays.BackColor = System.Drawing.Color.Transparent
        Me.flDays.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flDays.Location = New System.Drawing.Point(0, 99)
        Me.flDays.Margin = New System.Windows.Forms.Padding(4)
        Me.flDays.Name = "flDays"
        Me.flDays.Size = New System.Drawing.Size(1232, 712)
        Me.flDays.TabIndex = 2
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.flDays)
        Me.GunaPanel1.Controls.Add(Me.Panel3)
        Me.GunaPanel1.Controls.Add(Me.Panel1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(1232, 811)
        Me.GunaPanel1.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Animated = True
        Me.Button2.AnimationHoverSpeed = 0.07!
        Me.Button2.AnimationSpeed = 0.03!
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BaseColor1 = System.Drawing.Color.Transparent
        Me.Button2.BaseColor2 = System.Drawing.Color.Transparent
        Me.Button2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button2.BorderSize = 1
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.Button2.FocusedColor = System.Drawing.Color.Empty
        Me.Button2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button2.Image = Nothing
        Me.Button2.ImageSize = New System.Drawing.Size(20, 20)
        Me.Button2.Location = New System.Drawing.Point(658, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button2.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Button2.OnHoverBorderColor = System.Drawing.Color.White
        Me.Button2.OnHoverForeColor = System.Drawing.Color.White
        Me.Button2.OnHoverImage = Nothing
        Me.Button2.OnPressedColor = System.Drawing.Color.Black
        Me.Button2.Radius = 5
        Me.Button2.Size = New System.Drawing.Size(330, 42)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "Export"
        Me.Button2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.Animated = True
        Me.Button1.AnimationHoverSpeed = 0.07!
        Me.Button1.AnimationSpeed = 0.03!
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BaseColor1 = System.Drawing.Color.Transparent
        Me.Button1.BaseColor2 = System.Drawing.Color.Transparent
        Me.Button1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button1.BorderSize = 1
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.Button1.FocusedColor = System.Drawing.Color.Empty
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button1.Image = Nothing
        Me.Button1.ImageSize = New System.Drawing.Size(20, 20)
        Me.Button1.Location = New System.Drawing.Point(245, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button1.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Button1.OnHoverBorderColor = System.Drawing.Color.White
        Me.Button1.OnHoverForeColor = System.Drawing.Color.White
        Me.Button1.OnHoverImage = Nothing
        Me.Button1.OnPressedColor = System.Drawing.Color.Black
        Me.Button1.Radius = 5
        Me.Button1.Size = New System.Drawing.Size(407, 42)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "Export"
        Me.Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'stabilitycalender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1232, 811)
        Me.Controls.Add(Me.GunaPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "stabilitycalender"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stability Calender"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GunaPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents flDays As FlowLayoutPanel
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents lblMonthAndYear As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnPrevMonth As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents btnNextMonth As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents btnToday As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents GunaGradientButton1 As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents GunaGradientButton2 As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents GunaGradientButton3 As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents GunaGradientButton4 As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents GunaGradientButton5 As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents GunaGradientButton6 As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents GunaGradientButton7 As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents Button1 As Guna.UI.WinForms.GunaGradientButton
End Class
