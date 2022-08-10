<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dashboard
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
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.GunaPanel3 = New Guna.UI.WinForms.GunaPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Guna2Panel6 = New Guna.UI2.WinForms.Guna2Panel()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.Guna2Panel5 = New Guna.UI2.WinForms.Guna2Panel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.Chart4 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart3 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GunaPanel2 = New Guna.UI.WinForms.GunaPanel()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.GunaRadioButton3 = New Guna.UI.WinForms.GunaRadioButton()
        Me.GunaRadioButton4 = New Guna.UI.WinForms.GunaRadioButton()
        Me.ComboBox2 = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel8 = New Guna.UI.WinForms.GunaLabel()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GunaRadioButton2 = New Guna.UI.WinForms.GunaRadioButton()
        Me.GunaRadioButton1 = New Guna.UI.WinForms.GunaRadioButton()
        Me.ComboBox1 = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Guna2GradientPanel1 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.Guna2Panel4 = New Guna.UI2.WinForms.Guna2Panel()
        Me.GunaLabel16 = New Guna.UI.WinForms.GunaLabel()
        Me.Guna2Panel3 = New Guna.UI2.WinForms.Guna2Panel()
        Me.GunaLabel15 = New Guna.UI.WinForms.GunaLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GunaPanel1.SuspendLayout()
        Me.GunaPanel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Guna2Panel6.SuspendLayout()
        Me.Guna2Panel5.SuspendLayout()
        CType(Me.Chart4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaPanel2.SuspendLayout()
        Me.Guna2Panel2.SuspendLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2GradientPanel1.SuspendLayout()
        Me.Guna2Panel4.SuspendLayout()
        Me.Guna2Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'GunaPanel1
        '
        Me.GunaPanel1.Controls.Add(Me.GunaPanel3)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(1650, 883)
        Me.GunaPanel1.TabIndex = 27
        '
        'GunaPanel3
        '
        Me.GunaPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GunaPanel3.Controls.Add(Me.Panel4)
        Me.GunaPanel3.Controls.Add(Me.GunaPanel2)
        Me.GunaPanel3.Controls.Add(Me.Guna2GradientPanel1)
        Me.GunaPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GunaPanel3.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel3.Name = "GunaPanel3"
        Me.GunaPanel3.Size = New System.Drawing.Size(1650, 883)
        Me.GunaPanel3.TabIndex = 28
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.Chart4)
        Me.Panel4.Controls.Add(Me.Chart3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 408)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1650, 475)
        Me.Panel4.TabIndex = 47
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Guna2Panel6)
        Me.Panel1.Controls.Add(Me.Guna2Panel5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1650, 38)
        Me.Panel1.TabIndex = 46
        '
        'Guna2Panel6
        '
        Me.Guna2Panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Guna2Panel6.BorderRadius = 10
        Me.Guna2Panel6.BorderThickness = 1
        Me.Guna2Panel6.Controls.Add(Me.GunaLabel1)
        Me.Guna2Panel6.Location = New System.Drawing.Point(826, 0)
        Me.Guna2Panel6.Name = "Guna2Panel6"
        Me.Guna2Panel6.ShadowDecoration.Parent = Me.Guna2Panel6
        Me.Guna2Panel6.Size = New System.Drawing.Size(826, 38)
        Me.Guna2Panel6.TabIndex = 46
        '
        'GunaLabel1
        '
        Me.GunaLabel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.GunaLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.GunaLabel1.Location = New System.Drawing.Point(355, 9)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(133, 20)
        Me.GunaLabel1.TabIndex = 29
        Me.GunaLabel1.Text = "Chamber Capacity"
        '
        'Guna2Panel5
        '
        Me.Guna2Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Guna2Panel5.BorderRadius = 10
        Me.Guna2Panel5.BorderThickness = 1
        Me.Guna2Panel5.Controls.Add(Me.GunaLabel3)
        Me.Guna2Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Guna2Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel5.Name = "Guna2Panel5"
        Me.Guna2Panel5.ShadowDecoration.Parent = Me.Guna2Panel5
        Me.Guna2Panel5.Size = New System.Drawing.Size(826, 38)
        Me.Guna2Panel5.TabIndex = 45
        '
        'GunaLabel3
        '
        Me.GunaLabel3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.GunaLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.GunaLabel3.Location = New System.Drawing.Point(355, 9)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(120, 20)
        Me.GunaLabel3.TabIndex = 29
        Me.GunaLabel3.Text = "Sample Issuance"
        '
        'Chart4
        '
        Me.Chart4.BackColor = System.Drawing.Color.Transparent
        Me.Chart4.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        ChartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.MajorTickMark.Enabled = False
        ChartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea1.AxisY.LabelStyle.Format = "0"
        ChartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.BorderColor = System.Drawing.Color.DimGray
        ChartArea1.Name = "ChartArea1"
        ChartArea1.Position.Auto = False
        ChartArea1.Position.Height = 94.0!
        ChartArea1.Position.Width = 94.0!
        ChartArea1.Position.Y = 5.0!
        Me.Chart4.ChartAreas.Add(ChartArea1)
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Legend1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Legend1"
        Legend1.ShadowColor = System.Drawing.Color.Silver
        Legend1.ShadowOffset = 20
        Me.Chart4.Legends.Add(Legend1)
        Me.Chart4.Location = New System.Drawing.Point(832, 62)
        Me.Chart4.Name = "Chart4"
        Me.Chart4.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(114, Byte), Integer))
        Series1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.IsValueShownAsLabel = True
        Series1.LabelForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series1.ShadowColor = System.Drawing.Color.Gray
        Series1.ShadowOffset = 15
        Me.Chart4.Series.Add(Series1)
        Me.Chart4.Size = New System.Drawing.Size(714, 338)
        Me.Chart4.TabIndex = 10
        Me.Chart4.Text = "Chart4"
        '
        'Chart3
        '
        Me.Chart3.BackColor = System.Drawing.Color.Transparent
        Me.Chart3.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea2.AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        ChartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea2.AxisX.MajorGrid.Enabled = False
        ChartArea2.AxisX.MajorTickMark.Enabled = False
        ChartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White
        ChartArea2.AxisY.IsLabelAutoFit = False
        ChartArea2.AxisY.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea2.AxisY.LabelStyle.Format = "0"
        ChartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea2.AxisY.MajorGrid.Enabled = False
        ChartArea2.BackColor = System.Drawing.Color.Transparent
        ChartArea2.BorderColor = System.Drawing.Color.DimGray
        ChartArea2.Name = "ChartArea1"
        ChartArea2.Position.Auto = False
        ChartArea2.Position.Height = 94.0!
        ChartArea2.Position.Width = 94.0!
        ChartArea2.Position.Y = 5.0!
        Me.Chart3.ChartAreas.Add(ChartArea2)
        Legend2.BackColor = System.Drawing.Color.Transparent
        Legend2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Legend2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Legend2.IsTextAutoFit = False
        Legend2.Name = "Legend1"
        Legend2.ShadowColor = System.Drawing.Color.Silver
        Legend2.ShadowOffset = 20
        Me.Chart3.Legends.Add(Legend2)
        Me.Chart3.Location = New System.Drawing.Point(84, 62)
        Me.Chart3.Name = "Chart3"
        Me.Chart3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series2.Color = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(114, Byte), Integer))
        Series2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series2.IsValueShownAsLabel = True
        Series2.LabelForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Series2.ShadowColor = System.Drawing.Color.Gray
        Series2.ShadowOffset = 15
        Me.Chart3.Series.Add(Series2)
        Me.Chart3.Size = New System.Drawing.Size(714, 338)
        Me.Chart3.TabIndex = 9
        Me.Chart3.Text = "Chart3"
        '
        'GunaPanel2
        '
        Me.GunaPanel2.Controls.Add(Me.Guna2Panel2)
        Me.GunaPanel2.Controls.Add(Me.Guna2Panel1)
        Me.GunaPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaPanel2.Location = New System.Drawing.Point(0, 36)
        Me.GunaPanel2.Name = "GunaPanel2"
        Me.GunaPanel2.Size = New System.Drawing.Size(1650, 372)
        Me.GunaPanel2.TabIndex = 44
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Guna2Panel2.BorderRadius = 10
        Me.Guna2Panel2.BorderThickness = 1
        Me.Guna2Panel2.Controls.Add(Me.GunaRadioButton3)
        Me.Guna2Panel2.Controls.Add(Me.GunaRadioButton4)
        Me.Guna2Panel2.Controls.Add(Me.ComboBox2)
        Me.Guna2Panel2.Controls.Add(Me.GunaLabel8)
        Me.Guna2Panel2.Controls.Add(Me.Chart2)
        Me.Guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel2.Location = New System.Drawing.Point(826, 0)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.ShadowDecoration.Parent = Me.Guna2Panel2
        Me.Guna2Panel2.Size = New System.Drawing.Size(824, 372)
        Me.Guna2Panel2.TabIndex = 44
        '
        'GunaRadioButton3
        '
        Me.GunaRadioButton3.BaseColor = System.Drawing.SystemColors.Control
        Me.GunaRadioButton3.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaRadioButton3.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaRadioButton3.FillColor = System.Drawing.Color.White
        Me.GunaRadioButton3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.GunaRadioButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.GunaRadioButton3.Location = New System.Drawing.Point(285, 7)
        Me.GunaRadioButton3.Name = "GunaRadioButton3"
        Me.GunaRadioButton3.Size = New System.Drawing.Size(109, 24)
        Me.GunaRadioButton3.TabIndex = 48
        Me.GunaRadioButton3.Text = "Monthwise"
        '
        'GunaRadioButton4
        '
        Me.GunaRadioButton4.BaseColor = System.Drawing.SystemColors.Control
        Me.GunaRadioButton4.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaRadioButton4.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaRadioButton4.FillColor = System.Drawing.Color.White
        Me.GunaRadioButton4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.GunaRadioButton4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.GunaRadioButton4.Location = New System.Drawing.Point(165, 7)
        Me.GunaRadioButton4.Name = "GunaRadioButton4"
        Me.GunaRadioButton4.Size = New System.Drawing.Size(92, 24)
        Me.GunaRadioButton4.TabIndex = 47
        Me.GunaRadioButton4.Text = "Yearwise"
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
        Me.ComboBox2.Location = New System.Drawing.Point(449, 4)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ComboBox2.OnHoverItemForeColor = System.Drawing.Color.White
        Me.ComboBox2.Radius = 5
        Me.ComboBox2.Size = New System.Drawing.Size(135, 31)
        Me.ComboBox2.TabIndex = 44
        '
        'GunaLabel8
        '
        Me.GunaLabel8.AutoSize = True
        Me.GunaLabel8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.GunaLabel8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.GunaLabel8.Location = New System.Drawing.Point(7, 7)
        Me.GunaLabel8.Name = "GunaLabel8"
        Me.GunaLabel8.Size = New System.Drawing.Size(133, 20)
        Me.GunaLabel8.TabIndex = 26
        Me.GunaLabel8.Text = "Withdrawal Graph"
        '
        'Chart2
        '
        Me.Chart2.BackColor = System.Drawing.Color.Transparent
        Me.Chart2.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea3.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea3.AxisX.MajorGrid.Enabled = False
        ChartArea3.AxisX.MajorTickMark.Enabled = False
        ChartArea3.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White
        ChartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea3.AxisY.LabelStyle.Format = "0"
        ChartArea3.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea3.AxisY.MajorGrid.Enabled = False
        ChartArea3.BackColor = System.Drawing.Color.Transparent
        ChartArea3.BorderColor = System.Drawing.Color.DimGray
        ChartArea3.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea3)
        Me.Chart2.Location = New System.Drawing.Point(6, 45)
        Me.Chart2.Name = "Chart2"
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series3.IsValueShownAsLabel = True
        Series3.LabelForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        Series3.Name = "Series1"
        Me.Chart2.Series.Add(Series3)
        Me.Chart2.Size = New System.Drawing.Size(785, 315)
        Me.Chart2.TabIndex = 9
        Me.Chart2.Text = "Chart2"
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Guna2Panel1.BorderRadius = 10
        Me.Guna2Panel1.BorderThickness = 1
        Me.Guna2Panel1.Controls.Add(Me.Panel3)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.ShadowDecoration.Parent = Me.Guna2Panel1
        Me.Guna2Panel1.Size = New System.Drawing.Size(826, 372)
        Me.Guna2Panel1.TabIndex = 43
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GunaRadioButton2)
        Me.Panel3.Controls.Add(Me.GunaRadioButton1)
        Me.Panel3.Controls.Add(Me.ComboBox1)
        Me.Panel3.Controls.Add(Me.GunaLabel2)
        Me.Panel3.Controls.Add(Me.Chart1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(826, 372)
        Me.Panel3.TabIndex = 44
        '
        'GunaRadioButton2
        '
        Me.GunaRadioButton2.BaseColor = System.Drawing.SystemColors.Control
        Me.GunaRadioButton2.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaRadioButton2.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaRadioButton2.FillColor = System.Drawing.Color.White
        Me.GunaRadioButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.GunaRadioButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.GunaRadioButton2.Location = New System.Drawing.Point(257, 7)
        Me.GunaRadioButton2.Name = "GunaRadioButton2"
        Me.GunaRadioButton2.Size = New System.Drawing.Size(109, 24)
        Me.GunaRadioButton2.TabIndex = 46
        Me.GunaRadioButton2.Text = "Monthwise"
        '
        'GunaRadioButton1
        '
        Me.GunaRadioButton1.BaseColor = System.Drawing.SystemColors.Control
        Me.GunaRadioButton1.CheckedOffColor = System.Drawing.Color.Gray
        Me.GunaRadioButton1.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaRadioButton1.FillColor = System.Drawing.Color.White
        Me.GunaRadioButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.GunaRadioButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.GunaRadioButton1.Location = New System.Drawing.Point(142, 7)
        Me.GunaRadioButton1.Name = "GunaRadioButton1"
        Me.GunaRadioButton1.Size = New System.Drawing.Size(92, 24)
        Me.GunaRadioButton1.TabIndex = 45
        Me.GunaRadioButton1.Text = "Yearwise"
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
        Me.ComboBox1.Location = New System.Drawing.Point(391, 4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ComboBox1.OnHoverItemForeColor = System.Drawing.Color.White
        Me.ComboBox1.Radius = 5
        Me.ComboBox1.Size = New System.Drawing.Size(135, 31)
        Me.ComboBox1.TabIndex = 27
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.GunaLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.GunaLabel2.Location = New System.Drawing.Point(7, 7)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(118, 20)
        Me.GunaLabel2.TabIndex = 26
        Me.GunaLabel2.Text = "Charging Graph"
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.Transparent
        Me.Chart1.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea4.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea4.AxisX.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        ChartArea4.AxisX.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea4.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea4.AxisX.MajorGrid.Enabled = False
        ChartArea4.AxisX.MajorTickMark.Enabled = False
        ChartArea4.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White
        ChartArea4.AxisY.IsLabelAutoFit = False
        ChartArea4.AxisY.LabelStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea4.AxisY.LabelStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea4.AxisY.LabelStyle.Format = "0"
        ChartArea4.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        ChartArea4.AxisY.MajorGrid.Enabled = False
        ChartArea4.BackColor = System.Drawing.Color.Transparent
        ChartArea4.BorderColor = System.Drawing.Color.DimGray
        ChartArea4.Name = "ChartArea1"
        ChartArea4.Position.Auto = False
        ChartArea4.Position.Height = 94.0!
        ChartArea4.Position.Width = 94.0!
        ChartArea4.Position.Y = 5.0!
        Me.Chart1.ChartAreas.Add(ChartArea4)
        Me.Chart1.Location = New System.Drawing.Point(5, 45)
        Me.Chart1.Name = "Chart1"
        Series4.ChartArea = "ChartArea1"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series4.IsValueShownAsLabel = True
        Series4.LabelForeColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(102, Byte), Integer))
        Series4.Name = "Series1"
        Me.Chart1.Series.Add(Series4)
        Me.Chart1.Size = New System.Drawing.Size(787, 315)
        Me.Chart1.TabIndex = 9
        Me.Chart1.Text = "Chart1"
        '
        'Guna2GradientPanel1
        '
        Me.Guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Guna2GradientPanel1.BorderRadius = 10
        Me.Guna2GradientPanel1.Controls.Add(Me.Guna2Panel4)
        Me.Guna2GradientPanel1.Controls.Add(Me.Guna2Panel3)
        Me.Guna2GradientPanel1.CustomBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2GradientPanel1.Name = "Guna2GradientPanel1"
        Me.Guna2GradientPanel1.ShadowDecoration.Parent = Me.Guna2GradientPanel1
        Me.Guna2GradientPanel1.Size = New System.Drawing.Size(1650, 36)
        Me.Guna2GradientPanel1.TabIndex = 27
        '
        'Guna2Panel4
        '
        Me.Guna2Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Guna2Panel4.BorderRadius = 10
        Me.Guna2Panel4.BorderThickness = 1
        Me.Guna2Panel4.Controls.Add(Me.GunaLabel16)
        Me.Guna2Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel4.Location = New System.Drawing.Point(826, 0)
        Me.Guna2Panel4.Name = "Guna2Panel4"
        Me.Guna2Panel4.ShadowDecoration.Parent = Me.Guna2Panel4
        Me.Guna2Panel4.Size = New System.Drawing.Size(824, 36)
        Me.Guna2Panel4.TabIndex = 45
        '
        'GunaLabel16
        '
        Me.GunaLabel16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GunaLabel16.AutoSize = True
        Me.GunaLabel16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.GunaLabel16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.GunaLabel16.Location = New System.Drawing.Point(375, 8)
        Me.GunaLabel16.Name = "GunaLabel16"
        Me.GunaLabel16.Size = New System.Drawing.Size(87, 20)
        Me.GunaLabel16.TabIndex = 30
        Me.GunaLabel16.Text = "Withdrawal"
        '
        'Guna2Panel3
        '
        Me.Guna2Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Panel3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Guna2Panel3.BorderRadius = 10
        Me.Guna2Panel3.BorderThickness = 1
        Me.Guna2Panel3.Controls.Add(Me.GunaLabel15)
        Me.Guna2Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Guna2Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Panel3.Name = "Guna2Panel3"
        Me.Guna2Panel3.ShadowDecoration.Parent = Me.Guna2Panel3
        Me.Guna2Panel3.Size = New System.Drawing.Size(826, 36)
        Me.Guna2Panel3.TabIndex = 44
        '
        'GunaLabel15
        '
        Me.GunaLabel15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GunaLabel15.AutoSize = True
        Me.GunaLabel15.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.GunaLabel15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.GunaLabel15.Location = New System.Drawing.Point(355, 8)
        Me.GunaLabel15.Name = "GunaLabel15"
        Me.GunaLabel15.Size = New System.Drawing.Size(72, 20)
        Me.GunaLabel15.TabIndex = 29
        Me.GunaLabel15.Text = "Charging"
        '
        'dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1650, 883)
        Me.Controls.Add(Me.GunaPanel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "dashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "dashboard"
        Me.GunaPanel1.ResumeLayout(False)
        Me.GunaPanel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Guna2Panel6.ResumeLayout(False)
        Me.Guna2Panel6.PerformLayout()
        Me.Guna2Panel5.ResumeLayout(False)
        Me.Guna2Panel5.PerformLayout()
        CType(Me.Chart4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaPanel2.ResumeLayout(False)
        Me.Guna2Panel2.ResumeLayout(False)
        Me.Guna2Panel2.PerformLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2GradientPanel1.ResumeLayout(False)
        Me.Guna2Panel4.ResumeLayout(False)
        Me.Guna2Panel4.PerformLayout()
        Me.Guna2Panel3.ResumeLayout(False)
        Me.Guna2Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents GunaPanel3 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Guna2GradientPanel1 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents GunaPanel2 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents GunaLabel8 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Guna2Panel3 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel4 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents GunaLabel16 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel15 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ComboBox1 As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents ComboBox2 As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaRadioButton2 As Guna.UI.WinForms.GunaRadioButton
    Friend WithEvents GunaRadioButton3 As Guna.UI.WinForms.GunaRadioButton
    Friend WithEvents GunaRadioButton4 As Guna.UI.WinForms.GunaRadioButton
    Friend WithEvents GunaRadioButton1 As Guna.UI.WinForms.GunaRadioButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Chart3 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Guna2Panel5 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Chart4 As DataVisualization.Charting.Chart
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Guna2Panel6 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
End Class
