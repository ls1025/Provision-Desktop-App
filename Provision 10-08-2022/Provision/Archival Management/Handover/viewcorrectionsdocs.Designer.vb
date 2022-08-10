<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewcorrectionsdocs
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewcorrectionsdocs))
        Me.GunaPanel1 = New Guna.UI.WinForms.GunaPanel()
        Me.DataGridView1 = New Zuby.ADGV.AdvancedDataGridView()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GunaPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GunaPanel1
        '
        Me.GunaPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.GunaPanel1.Controls.Add(Me.DataGridView1)
        Me.GunaPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GunaPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GunaPanel1.Name = "GunaPanel1"
        Me.GunaPanel1.Size = New System.Drawing.Size(1458, 646)
        Me.GunaPanel1.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column20, Me.Column21, Me.Column22, Me.Column23, Me.Column24, Me.Column1})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.FilterAndSortEnabled = True
        Me.DataGridView1.FilterStringChangedInvokeBeforeDatasourceUpdate = True
        Me.DataGridView1.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.DataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridView1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1458, 646)
        Me.DataGridView1.SortStringChangedInvokeBeforeDatasourceUpdate = True
        Me.DataGridView1.TabIndex = 140
        Me.DataGridView1.TabStop = False
        '
        'Column14
        '
        Me.Column14.DataPropertyName = "id"
        Me.Column14.HeaderText = "id"
        Me.Column14.MinimumWidth = 22
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Column14.Visible = False
        '
        'Column15
        '
        Me.Column15.DataPropertyName = "id1"
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column15.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column15.FillWeight = 218.825!
        Me.Column15.HeaderText = "co_id"
        Me.Column15.MinimumWidth = 22
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Column15.Visible = False
        '
        'Column16
        '
        Me.Column16.DataPropertyName = "doctype"
        Me.Column16.FillWeight = 98.38272!
        Me.Column16.HeaderText = "Document Type"
        Me.Column16.MinimumWidth = 22
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Column17
        '
        Me.Column17.DataPropertyName = "catogery"
        Me.Column17.FillWeight = 97.1519!
        Me.Column17.HeaderText = "Category"
        Me.Column17.MinimumWidth = 22
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Column18
        '
        Me.Column18.DataPropertyName = "docname"
        Me.Column18.FillWeight = 98.66644!
        Me.Column18.HeaderText = "Document Name"
        Me.Column18.MinimumWidth = 22
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Column20
        '
        Me.Column20.DataPropertyName = "docno"
        Me.Column20.FillWeight = 94.8049!
        Me.Column20.HeaderText = "Document No."
        Me.Column20.MinimumWidth = 22
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        Me.Column20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Column21
        '
        Me.Column21.DataPropertyName = "corrections"
        Me.Column21.FillWeight = 95.30003!
        Me.Column21.HeaderText = "Corrections"
        Me.Column21.MinimumWidth = 22
        Me.Column21.Name = "Column21"
        Me.Column21.ReadOnly = True
        Me.Column21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Column22
        '
        Me.Column22.DataPropertyName = "returnby"
        Me.Column22.FillWeight = 94.86582!
        Me.Column22.HeaderText = "Return By"
        Me.Column22.MinimumWidth = 22
        Me.Column22.Name = "Column22"
        Me.Column22.ReadOnly = True
        Me.Column22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Column23
        '
        Me.Column23.DataPropertyName = "returnto"
        Me.Column23.FillWeight = 94.91921!
        Me.Column23.HeaderText = "Return To"
        Me.Column23.MinimumWidth = 22
        Me.Column23.Name = "Column23"
        Me.Column23.ReadOnly = True
        Me.Column23.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Column24
        '
        Me.Column24.DataPropertyName = "returndate"
        Me.Column24.FillWeight = 44.42292!
        Me.Column24.HeaderText = "Return Date"
        Me.Column24.MinimumWidth = 22
        Me.Column24.Name = "Column24"
        Me.Column24.ReadOnly = True
        Me.Column24.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Column1
        '
        Me.Column1.FillWeight = 62.6611!
        Me.Column1.HeaderText = "Handover"
        Me.Column1.MinimumWidth = 22
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Column1.Text = "Handover"
        Me.Column1.UseColumnTextForButtonValue = True
        '
        'viewcorrectionsdocs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1458, 646)
        Me.Controls.Add(Me.GunaPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "viewcorrectionsdocs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Correction Documents"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GunaPanel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GunaPanel1 As Guna.UI.WinForms.GunaPanel
    Friend WithEvents DataGridView1 As Zuby.ADGV.AdvancedDataGridView
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents Column20 As DataGridViewTextBoxColumn
    Friend WithEvents Column21 As DataGridViewTextBoxColumn
    Friend WithEvents Column22 As DataGridViewTextBoxColumn
    Friend WithEvents Column23 As DataGridViewTextBoxColumn
    Friend WithEvents Column24 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewButtonColumn
End Class
