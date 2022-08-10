<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class updateuser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(updateuser))
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.TextBox3 = New Guna.UI.WinForms.GunaTextBox()
        Me.ComboBox1 = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel6 = New Guna.UI.WinForms.GunaLabel()
        Me.ComboBox2 = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel5 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel4 = New Guna.UI.WinForms.GunaLabel()
        Me.Label1 = New Guna.UI.WinForms.GunaLabel()
        Me.RadioButton2 = New Guna.UI.WinForms.GunaRadioButton()
        Me.RadioButton1 = New Guna.UI.WinForms.GunaRadioButton()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.TextBox2 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.Button2 = New Guna.UI.WinForms.GunaGradientButton()
        Me.Button1 = New Guna.UI.WinForms.GunaGradientButton()
        Me.TextBox1 = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.TextBox3)
        Me.GunaPanel1.Controls.Add(Me.ComboBox1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel6)
        Me.GunaPanel1.Controls.Add(Me.ComboBox2)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel5)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel4)
        Me.GunaPanel1.Controls.Add(Me.Label1)
        Me.GunaPanel1.Controls.Add(Me.RadioButton2)
        Me.GunaPanel1.Controls.Add(Me.RadioButton1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel3)
        Me.GunaPanel1.Controls.Add(Me.TextBox2)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel1)
        Me.GunaPanel1.Controls.Add(Me.Button2)
        Me.GunaPanel1.Controls.Add(Me.Button1)
        Me.GunaPanel1.Controls.Add(Me.TextBox1)
        Me.GunaPanel1.Controls.Add(Me.GunaLabel2)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(527, 447)
        Me.GunaPanel1.TabIndex = 18
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.Transparent
        Me.TextBox3.BaseColor = System.Drawing.Color.White
        Me.TextBox3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.TextBox3.BorderSize = 1
        Me.TextBox3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox3.FocusedBaseColor = System.Drawing.Color.White
        Me.TextBox3.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextBox3.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.TextBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBox3.Location = New System.Drawing.Point(144, 242)
        Me.TextBox3.MaxLength = 32768
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBox3.Radius = 5
        Me.TextBox3.SelectedText = ""
        Me.TextBox3.Size = New System.Drawing.Size(355, 32)
        Me.TextBox3.TabIndex = 38
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.Transparent
        Me.ComboBox1.BaseColor = System.Drawing.Color.White
        Me.ComboBox1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.ComboBox1.BorderSize = 1
        Me.ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FocusedColor = System.Drawing.Color.Empty
        Me.ComboBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ComboBox1.ForeColor = System.Drawing.Color.Black
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"ARD", "DQA", "FRD", "IT"})
        Me.ComboBox1.Location = New System.Drawing.Point(144, 133)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ComboBox1.OnHoverItemForeColor = System.Drawing.Color.White
        Me.ComboBox1.Radius = 5
        Me.ComboBox1.Size = New System.Drawing.Size(355, 31)
        Me.ComboBox1.TabIndex = 37
        '
        'GunaLabel6
        '
        Me.GunaLabel6.AutoSize = True
        Me.GunaLabel6.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel6.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GunaLabel6.Location = New System.Drawing.Point(18, 141)
        Me.GunaLabel6.Name = "GunaLabel6"
        Me.GunaLabel6.Size = New System.Drawing.Size(102, 23)
        Me.GunaLabel6.TabIndex = 36
        Me.GunaLabel6.Text = "Department"
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.Transparent
        Me.ComboBox2.BaseColor = System.Drawing.Color.White
        Me.ComboBox2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.ComboBox2.BorderSize = 1
        Me.ComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FocusedColor = System.Drawing.Color.Empty
        Me.ComboBox2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ComboBox2.ForeColor = System.Drawing.Color.Black
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"FRD Scientist", "FRD GL", "ARD GL", "DQA", "DQA JR", "IT"})
        Me.ComboBox2.Location = New System.Drawing.Point(144, 188)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ComboBox2.OnHoverItemForeColor = System.Drawing.Color.White
        Me.ComboBox2.Radius = 5
        Me.ComboBox2.Size = New System.Drawing.Size(355, 31)
        Me.ComboBox2.TabIndex = 35
        '
        'GunaLabel5
        '
        Me.GunaLabel5.AutoSize = True
        Me.GunaLabel5.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel5.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GunaLabel5.Location = New System.Drawing.Point(12, 251)
        Me.GunaLabel5.Name = "GunaLabel5"
        Me.GunaLabel5.Size = New System.Drawing.Size(108, 23)
        Me.GunaLabel5.TabIndex = 33
        Me.GunaLabel5.Text = "Reporting To"
        '
        'GunaLabel4
        '
        Me.GunaLabel4.AutoSize = True
        Me.GunaLabel4.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GunaLabel4.Location = New System.Drawing.Point(15, 315)
        Me.GunaLabel4.Name = "GunaLabel4"
        Me.GunaLabel4.Size = New System.Drawing.Size(96, 23)
        Me.GunaLabel4.TabIndex = 32
        Me.GunaLabel4.Text = "User Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(237, 354)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 23)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Label1"
        Me.Label1.Visible = False
        '
        'RadioButton2
        '
        Me.RadioButton2.BaseColor = System.Drawing.SystemColors.Control
        Me.RadioButton2.CheckedOffColor = System.Drawing.Color.Gray
        Me.RadioButton2.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RadioButton2.FillColor = System.Drawing.Color.White
        Me.RadioButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.RadioButton2.Location = New System.Drawing.Point(328, 312)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(89, 26)
        Me.RadioButton2.TabIndex = 29
        Me.RadioButton2.Text = "Disable"
        '
        'RadioButton1
        '
        Me.RadioButton1.BaseColor = System.Drawing.SystemColors.Control
        Me.RadioButton1.CheckedOffColor = System.Drawing.Color.Gray
        Me.RadioButton1.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RadioButton1.FillColor = System.Drawing.Color.White
        Me.RadioButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadioButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.RadioButton1.Location = New System.Drawing.Point(144, 312)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(83, 26)
        Me.RadioButton1.TabIndex = 28
        Me.RadioButton1.Text = "Enable"
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GunaLabel3.Location = New System.Drawing.Point(35, 196)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(85, 23)
        Me.GunaLabel3.TabIndex = 27
        Me.GunaLabel3.Text = "User Type"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Transparent
        Me.TextBox2.BaseColor = System.Drawing.Color.White
        Me.TextBox2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.TextBox2.BorderSize = 1
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox2.Enabled = False
        Me.TextBox2.FocusedBaseColor = System.Drawing.Color.White
        Me.TextBox2.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextBox2.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.TextBox2.Location = New System.Drawing.Point(144, 78)
        Me.TextBox2.MaxLength = 32768
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBox2.Radius = 5
        Me.TextBox2.SelectedText = ""
        Me.TextBox2.Size = New System.Drawing.Size(355, 33)
        Me.TextBox2.TabIndex = 18
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GunaLabel1.Location = New System.Drawing.Point(25, 87)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(95, 23)
        Me.GunaLabel1.TabIndex = 19
        Me.GunaLabel1.Text = "User Name"
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
        Me.Button2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button2.Image = Nothing
        Me.Button2.ImageSize = New System.Drawing.Size(20, 20)
        Me.Button2.Location = New System.Drawing.Point(381, 375)
        Me.Button2.Name = "Button2"
        Me.Button2.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button2.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Button2.OnHoverBorderColor = System.Drawing.Color.White
        Me.Button2.OnHoverForeColor = System.Drawing.Color.White
        Me.Button2.OnHoverImage = Nothing
        Me.Button2.OnPressedColor = System.Drawing.Color.Black
        Me.Button2.Radius = 5
        Me.Button2.Size = New System.Drawing.Size(118, 42)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Close"
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
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button1.Image = Nothing
        Me.Button1.ImageSize = New System.Drawing.Size(20, 20)
        Me.Button1.Location = New System.Drawing.Point(31, 375)
        Me.Button1.Name = "Button1"
        Me.Button1.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button1.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Button1.OnHoverBorderColor = System.Drawing.Color.White
        Me.Button1.OnHoverForeColor = System.Drawing.Color.White
        Me.Button1.OnHoverImage = Nothing
        Me.Button1.OnPressedColor = System.Drawing.Color.Black
        Me.Button1.Radius = 5
        Me.Button1.Size = New System.Drawing.Size(125, 42)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Update"
        Me.Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Transparent
        Me.TextBox1.BaseColor = System.Drawing.Color.White
        Me.TextBox1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.TextBox1.BorderSize = 1
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox1.Enabled = False
        Me.TextBox1.FocusedBaseColor = System.Drawing.Color.White
        Me.TextBox1.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TextBox1.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.TextBox1.Location = New System.Drawing.Point(144, 21)
        Me.TextBox1.MaxLength = 32768
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBox1.Radius = 5
        Me.TextBox1.SelectedText = ""
        Me.TextBox1.Size = New System.Drawing.Size(355, 33)
        Me.TextBox1.TabIndex = 14
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.BackColor = System.Drawing.Color.Transparent
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GunaLabel2.Location = New System.Drawing.Point(32, 30)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(88, 23)
        Me.GunaLabel2.TabIndex = 15
        Me.GunaLabel2.Text = "Full Name"
        '
        'updateuser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 447)
        Me.Controls.Add(Me.GunaPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "updateuser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update User"
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents TextBox2 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Button2 As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents Button1 As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents TextBox1 As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents RadioButton2 As Guna.UI.WinForms.GunaRadioButton
    Friend WithEvents RadioButton1 As Guna.UI.WinForms.GunaRadioButton
    Friend WithEvents Label1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel4 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel5 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents ComboBox2 As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents ComboBox1 As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel6 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents TextBox3 As Guna.UI.WinForms.GunaTextBox
End Class
