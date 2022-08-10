<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class exportrecon
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(exportrecon))
        Me.DataTable1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet4 = New Provision.DataSet4()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New Guna.UI.WinForms.GunaGradientButton()
        Me.Button1 = New Guna.UI.WinForms.GunaGradientButton()
        Me.ComboBox3 = New Guna.UI.WinForms.GunaComboBox()
        Me.ComboBox2 = New Guna.UI.WinForms.GunaComboBox()
        Me.ComboBox1 = New Guna.UI.WinForms.GunaComboBox()
        Me.GunaLabel1 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel3 = New Guna.UI.WinForms.GunaLabel()
        Me.GunaLabel2 = New Guna.UI.WinForms.GunaLabel()
        Me.DataTable1TableAdapter = New Provision.DataSet4TableAdapters.DataTable1TableAdapter()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataTable1BindingSource
        '
        Me.DataTable1BindingSource.DataMember = "DataTable1"
        Me.DataTable1BindingSource.DataSource = Me.DataSet4
        '
        'DataSet4
        '
        Me.DataSet4.DataSetName = "DataSet4"
        Me.DataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.DataTable1BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Provision.Report4.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 63)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1380, 700)
        Me.ReportViewer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.ComboBox3)
        Me.Panel1.Controls.Add(Me.ComboBox2)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.GunaLabel1)
        Me.Panel1.Controls.Add(Me.GunaLabel3)
        Me.Panel1.Controls.Add(Me.GunaLabel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1380, 63)
        Me.Panel1.TabIndex = 1
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
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.Button2.FocusedColor = System.Drawing.Color.Empty
        Me.Button2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageOffsetX = -5
        Me.Button2.ImageSize = New System.Drawing.Size(15, 15)
        Me.Button2.Location = New System.Drawing.Point(820, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button2.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Button2.OnHoverBorderColor = System.Drawing.Color.White
        Me.Button2.OnHoverForeColor = System.Drawing.Color.White
        Me.Button2.OnHoverImage = CType(resources.GetObject("Button2.OnHoverImage"), System.Drawing.Image)
        Me.Button2.OnPressedColor = System.Drawing.Color.Black
        Me.Button2.Radius = 5
        Me.Button2.Size = New System.Drawing.Size(95, 31)
        Me.Button2.TabIndex = 38
        Me.Button2.Text = "Refresh"
        Me.Button2.TextOffsetX = -5
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
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.Button1.FocusedColor = System.Drawing.Color.Empty
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageOffsetX = -5
        Me.Button1.ImageSize = New System.Drawing.Size(15, 15)
        Me.Button1.Location = New System.Drawing.Point(685, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Button1.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.Button1.OnHoverBorderColor = System.Drawing.Color.White
        Me.Button1.OnHoverForeColor = System.Drawing.Color.White
        Me.Button1.OnHoverImage = CType(resources.GetObject("Button1.OnHoverImage"), System.Drawing.Image)
        Me.Button1.OnPressedColor = System.Drawing.Color.Black
        Me.Button1.Radius = 5
        Me.Button1.Size = New System.Drawing.Size(129, 31)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "Get Details"
        Me.Button1.TextOffsetX = -3
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
        Me.ComboBox3.Location = New System.Drawing.Point(487, 0)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ComboBox3.OnHoverItemForeColor = System.Drawing.Color.White
        Me.ComboBox3.Radius = 5
        Me.ComboBox3.Size = New System.Drawing.Size(192, 31)
        Me.ComboBox3.TabIndex = 35
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
        Me.ComboBox2.Location = New System.Drawing.Point(318, 0)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ComboBox2.OnHoverItemForeColor = System.Drawing.Color.White
        Me.ComboBox2.Radius = 5
        Me.ComboBox2.Size = New System.Drawing.Size(169, 31)
        Me.ComboBox2.TabIndex = 32
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
        Me.ComboBox1.Size = New System.Drawing.Size(318, 31)
        Me.ComboBox1.TabIndex = 31
        Me.ComboBox1.Tag = ""
        '
        'GunaLabel1
        '
        Me.GunaLabel1.AutoSize = True
        Me.GunaLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel1.Location = New System.Drawing.Point(543, 35)
        Me.GunaLabel1.Name = "GunaLabel1"
        Me.GunaLabel1.Size = New System.Drawing.Size(74, 20)
        Me.GunaLabel1.TabIndex = 36
        Me.GunaLabel1.Text = "Condition"
        '
        'GunaLabel3
        '
        Me.GunaLabel3.AutoSize = True
        Me.GunaLabel3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel3.Location = New System.Drawing.Point(352, 35)
        Me.GunaLabel3.Name = "GunaLabel3"
        Me.GunaLabel3.Size = New System.Drawing.Size(104, 20)
        Me.GunaLabel3.TabIndex = 34
        Me.GunaLabel3.Text = "Batch Number"
        '
        'GunaLabel2
        '
        Me.GunaLabel2.AutoSize = True
        Me.GunaLabel2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaLabel2.Location = New System.Drawing.Point(98, 35)
        Me.GunaLabel2.Name = "GunaLabel2"
        Me.GunaLabel2.Size = New System.Drawing.Size(104, 20)
        Me.GunaLabel2.TabIndex = 33
        Me.GunaLabel2.Text = "Product Name"
        '
        'DataTable1TableAdapter
        '
        Me.DataTable1TableAdapter.ClearBeforeFill = True
        '
        'exportrecon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1380, 763)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "exportrecon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export"
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ComboBox3 As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents ComboBox2 As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents ComboBox1 As Guna.UI.WinForms.GunaComboBox
    Friend WithEvents GunaLabel1 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel3 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents GunaLabel2 As Guna.UI.WinForms.GunaLabel
    Friend WithEvents DataTable1BindingSource As BindingSource
    Friend WithEvents DataSet4 As DataSet4
    Friend WithEvents DataTable1TableAdapter As DataSet4TableAdapters.DataTable1TableAdapter
    Friend WithEvents Button2 As Guna.UI.WinForms.GunaGradientButton
    Friend WithEvents Button1 As Guna.UI.WinForms.GunaGradientButton
End Class
