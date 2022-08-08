﻿Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp
Imports System.IO
Public Class viewwitdplanner
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub viewwitdplanner_Load(sender As Object, e As EventArgs) Handles Me.Load
        'changecolor()

        loadproname()
        loadcond()
        dgv1_rowstyle()
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel2, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
    Private Sub loadproname()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(proname) from plnr where [actpodate] IS NOT NULL order by [proname] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("proname"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub loadcond()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(cndn) from plnr order by [cndn] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox3.Items.Add(dr("cndn"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub changecolor()
        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
            If IsDBNull(Me.DataGridView1.Rows(i).Cells("Column8").Value) Then
            ElseIf Me.DataGridView1.Rows(i).Cells("Column8").Value = Date.Today.AddDays(-2) Then
                DataGridView1.Rows(i).Cells("Column8").Style.BackColor = Color.Red
            End If
        Next
    End Sub
    Public Sub loadplnr()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select [proname],[strength],[btn],[ptn] from plnr where [actpodate] IS NOT NULL group by proname,strength,btn,ptn order by [proname] ASC ", con)
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DataGridView1.Cursor = Cursors.WaitCursor
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            DataGridView1.Cursor = Cursors.Default
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgv1_rowstyle()
            DataGridView1.CurrentCell = Nothing
            GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
            DataGridView1.ColumnHeadersHeight = 30
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub dgv1_rowstyle()
        For i As Integer = 0 To DataGridView1.RowCount - 1
            If i Mod 2 = 0 Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If

        Next
        DataGridView1.CurrentCell = Nothing
        DataGridView1.ColumnHeadersHeight = 30
    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.DataSourceChanged
        dgv1_rowstyle()
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            'loadplnr()
        Else
            filterdata1(TextBox1.Text)
            dgv1_rowstyle()
        End If


    End Sub
    Private Sub filterdata1(ValueTosearch As String)
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where ([actpodate] IS NOT NULL) and ([ptn] like '%" & ValueTosearch & "%' or [remark] like '%" & ValueTosearch & "%') group by proname,strength,btn,ptn order by [proname] ASC")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DataGridView1.Cursor = Cursors.WaitCursor
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
            DataGridView1.Cursor = Cursors.Default
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
            dgv1_rowstyle()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs)
        Dim form As New calender
        form.ShowDialog()
    End Sub
    Private Sub Button1_MouseHover(sender As Object, e As EventArgs)
        ' ToolTip1.Show("Export to PDF", Button1)
    End Sub
    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        Dim senderComboBox As ComboBox = DirectCast(sender, ComboBox)
        Dim width As Integer = senderComboBox.DropDownWidth
        Dim g As Graphics = senderComboBox.CreateGraphics()
        Dim font As System.Drawing.Font = senderComboBox.Font
        Dim vertScrollBarWidth As Integer = If(senderComboBox.Items.Count > senderComboBox.MaxDropDownItems, SystemInformation.VerticalScrollBarWidth, 0)

        Dim newWidth As Integer
        For Each s As String In DirectCast(sender, ComboBox).Items
            newWidth = CInt(g.MeasureString(s, font).Width) + vertScrollBarWidth
            If width < newWidth Then
                width = newWidth
            End If
        Next s
        senderComboBox.DropDownWidth = width
    End Sub
    Private Sub ComboBox2_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.DropDown
        Dim senderComboBox As ComboBox = DirectCast(sender, ComboBox)
        Dim width As Integer = senderComboBox.DropDownWidth
        Dim g As Graphics = senderComboBox.CreateGraphics()
        Dim font As System.Drawing.Font = senderComboBox.Font
        Dim vertScrollBarWidth As Integer = If(senderComboBox.Items.Count > senderComboBox.MaxDropDownItems, SystemInformation.VerticalScrollBarWidth, 0)

        Dim newWidth As Integer
        For Each s As String In DirectCast(sender, ComboBox).Items
            newWidth = CInt(g.MeasureString(s, font).Width) + vertScrollBarWidth
            If width < newWidth Then
                width = newWidth
            End If
        Next s
        senderComboBox.DropDownWidth = width
    End Sub
    Private Sub ComboBox3_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.DropDown
        Dim senderComboBox As ComboBox = DirectCast(sender, ComboBox)
        Dim width As Integer = senderComboBox.DropDownWidth
        Dim g As Graphics = senderComboBox.CreateGraphics()
        Dim font As System.Drawing.Font = senderComboBox.Font
        Dim vertScrollBarWidth As Integer = If(senderComboBox.Items.Count > senderComboBox.MaxDropDownItems, SystemInformation.VerticalScrollBarWidth, 0)

        Dim newWidth As Integer
        For Each s As String In DirectCast(sender, ComboBox).Items
            newWidth = CInt(g.MeasureString(s, font).Width) + vertScrollBarWidth
            If width < newWidth Then
                width = newWidth
            End If
        Next s
        senderComboBox.DropDownWidth = width
    End Sub
    Private Sub loadbatch()
        Try
            ComboBox2.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(btn) from plnr where proname='" + ComboBox1.Text + "' and [actpodate] IS NOT NULL"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr("btn"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        loadbatch()

        ' Me.BeginInvoke(New Action(Sub() ComboBox1.Select(0, 0)))
        Try
            If ComboBox2.Text = "" And ComboBox3.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where [actpodate] IS NOT NULL and [proname] = '" + ComboBox1.Text + "' group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            ElseIf ComboBox2.Text <> "" And ComboBox3.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where [actpodate] IS NOT NULL and [proname] = '" + ComboBox1.Text + "' and [btn]='" + ComboBox2.Text + "' and [cndn]='" + ComboBox3.Text + "' group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            ElseIf ComboBox2.Text <> "" And ComboBox3.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where [actpodate] IS NOT NULL and [proname] = '" + ComboBox1.Text + "' and [btn]='" + ComboBox2.Text + "' group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            ElseIf ComboBox2.Text = "" And ComboBox3.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where [actpodate] IS NOT NULL and [proname] = '" + ComboBox1.Text + "' and [cndn]='" + ComboBox3.Text + "' group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboBox2_TextChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        Try
            If ComboBox1.Text = "" And ComboBox3.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where [actpodate] IS NOT NULL and [btn] = '" + ComboBox2.Text + "' group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            ElseIf ComboBox1.Text <> "" And ComboBox3.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where [actpodate] IS NOT NULL and [proname] = '" + ComboBox1.Text + "' and [btn]='" + ComboBox2.Text + "' and [cndn]='" + ComboBox3.Text + "' group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            ElseIf ComboBox1.Text <> "" And ComboBox3.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where [actpodate] IS NOT NULL and [proname] = '" + ComboBox1.Text + "' and [btn]='" + ComboBox2.Text + "' group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            ElseIf ComboBox1.Text = "" And ComboBox3.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where [actpodate] IS NOT NULL and [btn] = '" + ComboBox2.Text + "' and [cndn]='" + ComboBox3.Text + "' group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

        Try
            If ComboBox1.Text = "" And ComboBox2.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where [actpodate] IS NOT NULL and [cndn] = '" + ComboBox3.Text + "' group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where [actpodate] IS NOT NULL and [proname] = '" + ComboBox1.Text + "' and [btn]='" + ComboBox2.Text + "' and [cndn]='" + ComboBox3.Text + "' group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            ElseIf ComboBox1.Text <> "" And ComboBox2.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where [actpodate] IS NOT NULL and [proname] = '" + ComboBox1.Text + "' and [cndn]='" + ComboBox3.Text + "' group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" Or ComboBox2.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where [actpodate] IS NOT NULL and [btn] = '" + ComboBox2.Text + "' and [cndn]='" + ComboBox3.Text + "' group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        TextBox1.Text = ""
        TextBox3.Text = ""
        loadplnr()

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If DateTimePicker1.Text = " " And DateTimePicker2.Text = " " Then
            MsgBox("Select pull out date from and pull out date To", vbCritical)
        ElseIf DateTimePicker1.Text = " " Then
            MsgBox("Select pull out date from", vbCritical)
        ElseIf DateTimePicker2.Text = " " Then
            MsgBox("Select pull out date To", vbCritical)
        ElseIf ComboBox4.Text = "" Then
            MsgBox("Select Activity", vbCritical)
        ElseIf ComboBox4.Text = "Charged" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where chrgdate between @fromdate and @todate and actpodate IS NOT NULL group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Parameters.AddWithValue("@fromdate", SqlDbType.Date).Value = DateTimePicker1.Value.Date
                cmd.Parameters.AddWithValue("@todate", SqlDbType.Date).Value = DateTimePicker2.Value.Date
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        ElseIf ComboBox4.Text = "Withdrawal Date" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where podate between @fromdate and @todate and actpodate IS NOT NULL group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Parameters.AddWithValue("@fromdate", SqlDbType.Date).Value = DateTimePicker1.Value.Date
                cmd.Parameters.AddWithValue("@todate", SqlDbType.Date).Value = DateTimePicker2.Value.Date
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        ElseIf ComboBox4.Text = "Withdrawal On" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr  where actpodate between @fromdate and @todate and actpodate IS NOT NULL group by proname,strength,btn,ptn order by [proname] ASC")
                cmd.Parameters.AddWithValue("@fromdate", SqlDbType.Date).Value = DateTimePicker1.Value.Date
                cmd.Parameters.AddWithValue("@todate", SqlDbType.Date).Value = DateTimePicker2.Value.Date
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView1.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView1.DataSource = table1
                DataGridView1.Cursor = Cursors.Default
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
                dgv1_rowstyle()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub
    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            Dim form As New detailviewwithplnr
            form.Label4.Text = DataGridView1.SelectedCells(0).Value

            form.Label1.Text = DataGridView1.SelectedCells(0).Value + " " + DataGridView1.SelectedCells(1).Value
            form.Label2.Text = DataGridView1.SelectedCells(2).Value
            form.Label3.Text = DataGridView1.SelectedCells(3).Value
            form.ShowDialog()
        End If
    End Sub
    Private Sub GunaGradientButton5_Click(sender As Object, e As EventArgs) Handles GunaGradientButton5.Click
        Dim form As New box
        form.ShowDialog()
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub




    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        If TextBox3.Text = "" Then
            ' loadplnr()
        Else
            filterdatadelaydays(TextBox3.Text)
            dgv1_rowstyle()
        End If


    End Sub
    Private Sub filterdatadelaydays(ValueTosearch As String)
        Try
            Dim days As Integer = TextBox3.Text

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select [proname],[strength],[btn],[ptn] from plnr where [actpodate]>DateAdd('d'," & days & ",[podate]) and actpodate IS NOT NULL group by proname,strength,btn,ptn order by [proname] ASC")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            DataGridView1.Cursor = Cursors.WaitCursor
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
            DataGridView1.Cursor = Cursors.Default
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString
            dgv1_rowstyle()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GunaPanel2_Paint(sender As Object, e As PaintEventArgs) Handles GunaPanel2.Paint

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New viewpartwithsample

        form.ShowDialog()
    End Sub
End Class
