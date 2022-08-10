<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class exportdata
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(exportdata))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaRadioButton3 = New Guna.UI.WinForms.GunaRadioButton()
        Me.GunaRadioButton2 = New Guna.UI.WinForms.GunaRadioButton()
        Me.GunaRadioButton1 = New Guna.UI.WinForms.GunaRadioButton()
        Me.Button3 = New Guna.UI.WinForms.GunaGradientButton()
        Me.ComboBox3 = New Guna.UI.WinForms.GunaComboBox()
        Me.ComboBox2 = New Guna.UI.WinForms.GunaComboBox()
        Me.ComboBox1 = New Guna.UI.WinForms.GunaComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.DocumentMapWidth = 48
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 60)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.ShowPrintButton = False
        Me.ReportViewer1.Size = New System.Drawing.Size(1533, 703)
        Me.ReportViewer1.TabIndex = 0
        '
        'GunaPanel2
        '
        Me.GunaPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GunaPanel2.Controls.Add(Me.GunaRadioButton3)
        Me.GunaPanel2.Controls.Add(Me.GunaRadioButton2)
        Me.GunaPanel2.Controls.Add(Me.GunaRadioButton1)
        Me.GunaPanel2.Controls.Add(Me.Button3)
        Me.GunaPanel2.Controls.Add(Me.ComboBox3)
        Me.GunaPanel2.Controls.Add(Me.ComboBox2)
        Me.GunaPanel2.Controls.Add(Me.ComboBox1)
        Me.GunaPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(1533, 33)
        Me.GunaPanel2.TabIndex = 11
        '
        'GunaRadioButton3
        '
        Me.GunaRadioButton3.BaseColor = System.Drawing.SystemColors.Control
        Me.GunaRadioButton3.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaRadioButton3.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaRadioButton3.FillColor = System.Drawing.Color.White
        Me.GunaRadioButton3.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaRadioButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GunaRadioButton3.Location = New System.Drawing.Point(927, 3)
        Me.GunaRadioButton3.Name = "GunaRadioButton3"
        Me.GunaRadioButton3.Size = New System.Drawing.Size(95, 26)
        Me.GunaRadioButton3.TabIndex = 30
        Me.GunaRadioButton3.Text = "Stability"
        '
        'GunaRadioButton2
        '
        Me.GunaRadioButton2.BaseColor = System.Drawing.SystemColors.Control
        Me.GunaRadioButton2.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaRadioButton2.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaRadioButton2.FillColor = System.Drawing.Color.White
        Me.GunaRadioButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaRadioButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GunaRadioButton2.Location = New System.Drawing.Point(819, 3)
        Me.GunaRadioButton2.Name = "GunaRadioButton2"
        Me.GunaRadioButton2.Size = New System.Drawing.Size(92, 26)
        Me.GunaRadioButton2.TabIndex = 29
        Me.GunaRadioButton2.Text = "Routine"
        '
        'GunaRadioButton1
        '
        Me.GunaRadioButton1.BaseColor = System.Drawing.SystemColors.Control
        Me.GunaRadioButton1.Checked = True
        Me.GunaRadioButton1.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaRadioButton1.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaRadioButton1.FillColor = System.Drawing.Color.White
        Me.GunaRadioButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GunaRadioButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GunaRadioButton1.Location = New System.Drawing.Point(666, 4)
        Me.GunaRadioButton1.Name = "GunaRadioButton1"
        Me.GunaRadioButton1.Size = New System.Drawing.Size(136, 26)
        Me.GunaRadioButton1.TabIndex = 28
        Me.GunaRadioButton1.Text = "Development"
        '
        'Button3
        '
        Me.Button3.Animated = True
        Me.Button3.AnimationHoverSpeed = 0.07!
        Me.Button3.AnimationSpeed = 0.03!
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BaseColor1 = System.Drawing.Color.Transparent
        Me.Button3.BaseColor2 = System.Drawing.Color.Transparent
        Me.Button3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button3.BorderSize = 1
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.Button3.FocusedColor = System.Drawing.Color.Empty
        Me.Button3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageOffsetX = -5
        Me.Button3.ImageSize = New System.Drawing.Size(15, 15)
        Me.Button3.Location = New System.Drawing.Point(1046, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button3.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Button3.OnHoverBorderColor = System.Drawing.Color.White
        Me.Button3.OnHoverForeColor = System.Drawing.Color.White
        Me.Button3.OnHoverImage = CType(resources.GetObject("Button3.OnHoverImage"), System.Drawing.Image)
        Me.Button3.OnPressedColor = System.Drawing.Color.Black
        Me.Button3.Radius = 5
        Me.Button3.Size = New System.Drawing.Size(109, 33)
        Me.Button3.TabIndex = 22
        Me.Button3.Text = "Filter"
        Me.Button3.TextOffsetX = -3
        '
        'ComboBox3
        '
        Me.ComboBox3.BackColor = System.Drawing.Color.Transparent
        Me.ComboBox3.BaseColor = System.Drawing.Color.White
        Me.ComboBox3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.ComboBox3.BorderSize = 1
        Me.ComboBox3.Dock = System.Windows.Forms.DockStyle.Left
        Me.ComboBox3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FocusedColor = System.Drawing.Color.Empty
        Me.ComboBox3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ComboBox3.ForeColor = System.Drawing.Color.Black
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"Pending", "Cancelled", "Data Uploaded"})
        Me.ComboBox3.Location = New System.Drawing.Point(483, 0)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ComboBox3.OnHoverItemForeColor = System.Drawing.Color.White
        Me.ComboBox3.Radius = 5
        Me.ComboBox3.Size = New System.Drawing.Size(174, 31)
        Me.ComboBox3.TabIndex = 27
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.Transparent
        Me.ComboBox2.BaseColor = System.Drawing.Color.White
        Me.ComboBox2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.ComboBox2.BorderSize = 1
        Me.ComboBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.ComboBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FocusedColor = System.Drawing.Color.Empty
        Me.ComboBox2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ComboBox2.ForeColor = System.Drawing.Color.Black
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(290, 0)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ComboBox2.OnHoverItemForeColor = System.Drawing.Color.White
        Me.ComboBox2.Radius = 5
        Me.ComboBox2.Size = New System.Drawing.Size(193, 31)
        Me.ComboBox2.TabIndex = 12
        Me.ComboBox2.Tag = ""
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.Transparent
        Me.ComboBox1.BaseColor = System.Drawing.Color.White
        Me.ComboBox1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.ComboBox1.BorderSize = 1
        Me.ComboBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FocusedColor = System.Drawing.Color.Empty
        Me.ComboBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ComboBox1.ForeColor = System.Drawing.Color.Black
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(0, 0)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ComboBox1.OnHoverItemForeColor = System.Drawing.Color.White
        Me.ComboBox1.Radius = 5
        Me.ComboBox1.Size = New System.Drawing.Size(290, 31)
        Me.ComboBox1.TabIndex = 15
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GunaLabel3)
        Me.Panel1.Controls.Add(Me.GunaLabel1)
        Me.Panel1.Controls.Add(Me.GunaLabel2)
        Me.Panel1.Controls.Add(Me.GunaPanel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1533, 60)
        Me.Panel1.TabIndex = 12
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GunaLabel3.Location = New System.Drawing.Point(542, 34)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(49, 20)
        Me.GunaLabel3.TabIndex = 19
        Me.GunaLabel3.Text = "Status"
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GunaLabel1.Location = New System.Drawing.Point(330, 34)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(104, 20)
        Me.GunaLabel1.TabIndex = 18
        Me.GunaLabel1.Text = "Batch Number"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GunaLabel2.Location = New System.Drawing.Point(89, 34)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(104, 20)
        Me.GunaLabel2.TabIndex = 17
        Me.GunaLabel2.Text = "Product Name"
        '
        'exportdata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1533, 763)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "exportdata"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export Data"
        Me.GunaPanel2.ResumeLayout(False)
        Me.GunaPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Button3 As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents ComboBox3 As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents ComboBox2 As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents ComboBox1 As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaRadioButton1 As Guna.UI.WinForms.GunaRadioButton
    Friend WithEvents GunaRadioButton2 As Guna.UI.WinForms.GunaRadioButton
    Friend WithEvents GunaRadioButton3 As Guna.UI.WinForms.GunaRadioButton
End Class
