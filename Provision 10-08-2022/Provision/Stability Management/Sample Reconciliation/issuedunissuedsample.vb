Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp
Imports System.IO
Public Class issuedunissuedsample
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub viewwitdplanner_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadUnissuedProductName()
        LoadUnissuedConditions()
        LoadUnissuedDetails()
        LoadissuedProductName()
        LoadissuedConditions()
        LoadissuedDetails()
        dgv1_rowstyle()
        dgv2_rowstyle()
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel2, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub

    Private Sub LoadUnissuedProductName()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(proname) from plnr where [availsampleqty]<>0 order by [proname] ASC"
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

    Private Sub LoadUnissuedConditions()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(cndn) from plnr where [availsampleqty]<>0 and actpodate IS NOT NULL order by [cndn] ASC"
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

    Public Sub LoadUnissuedDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select [proname],[btn],[ptn],[pctyp],[cndn],[chrgdate],[sch],[availsampleqty] from plnr where [availsampleqty] <> 0 and actpodate IS NOT NULL order by [proname] ASC", con)
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)

            dgv1_rowstyle()

            DataGridView1.CurrentCell = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadissuedProductName()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(proname) from plnr WHERE ID IN  (SELECT ref_id FROM recon ) order by [proname] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox4.Items.Add(dr("proname"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadissuedConditions()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(cndn) from plnr WHERE ID IN  (SELECT ref_id FROM recon ) order by [cndn] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox6.Items.Add(dr("cndn"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub LoadissuedDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("SELECT proname,btn,ptn FROM plnr WHERE ID IN  (SELECT ref_id FROM recon ) group by proname,btn,ptn", con)
            da.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0)
            ' GunaLabel6.Text = "Records: " + DataGridView2.Rows.Count.ToString
            dgv2_rowstyle()
            DataGridView2.CurrentCell = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub dgv1_rowstyle()
        Dim tot As Double = 0#
        For i As Integer = 0 To DataGridView1.RowCount - 1
            If i Mod 2 = 0 Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If
            tot += Val(DataGridView1.Rows(i).Cells(7).Value)
        Next
        DataGridView1.CurrentCell = Nothing
        GunaLabel6.Text = "Unissued Samples: " + tot.ToString
    End Sub
    Public Sub dgv2_rowstyle()
        For i As Integer = 0 To DataGridView2.RowCount - 1
            If i Mod 2 = 0 Then
                DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If

        Next
        DataGridView2.CurrentCell = Nothing
    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.DataSourceChanged
        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView2_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.ColumnHeaderMouseClick
        dgv2_rowstyle()
    End Sub
    Private Sub DataGridView2_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView2.DataSourceChanged
        dgv2_rowstyle()
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
    Private Sub ComboBox4_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.DropDown
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
    Private Sub ComboBox5_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox5.DropDown
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
    Private Sub ComboBox6_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox6.DropDown
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
    Private Sub LoadUnissuedBatchNumber()
        Try
            ComboBox2.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(btn) from plnr where proname='" + ComboBox1.Text + "' and [availsampleqty]<>0"
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
        LoadUnissuedBatchNumber()

        ' Me.BeginInvoke(New Action(Sub() ComboBox1.Select(0, 0)))
        Try
            If ComboBox2.Text = "" And ComboBox3.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[btn],[ptn],[pctyp],[cndn],[chrgdate],[sch],[availsampleqty] from plnr where [availsampleqty]<>0 and [proname] = '" + ComboBox1.Text + "' order by [proname] ASC")
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
                Dim cmd As New SqlCommand("Select [proname],[btn],[ptn],[pctyp],[cndn],[chrgdate],[sch],[availsampleqty] from plnr where [availsampleqty]<>0 and [proname] = '" + ComboBox1.Text + "' and [btn]='" + ComboBox2.Text + "' and [cndn]='" + ComboBox3.Text + "' order by [proname] ASC")
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
                Dim cmd As New SqlCommand("Select [proname],[btn],[ptn],[pctyp],[cndn],[chrgdate],[sch],[availsampleqty] from plnr where [availsampleqty]<>0 and [proname] = '" + ComboBox1.Text + "' and [btn]='" + ComboBox2.Text + "' order by [proname] ASC")
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
                Dim cmd As New SqlCommand("Select [proname],[btn],[ptn],[pctyp],[cndn],[chrgdate],[sch],[availsampleqty] from plnr where [availsampleqty]<>0 and [proname] = '" + ComboBox1.Text + "' and [cndn]='" + ComboBox3.Text + "' order by [proname] ASC")
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
                Dim cmd As New SqlCommand("Select [proname],[btn],[ptn],[pctyp],[cndn],[chrgdate],[sch],[availsampleqty] from plnr where [availsampleqty]<>0 and [btn] = '" + ComboBox2.Text + "' order by [proname] ASC")
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
                Dim cmd As New SqlCommand("Select [proname],[btn],[ptn],[pctyp],[cndn],[chrgdate],[sch],[availsampleqty] from plnr where [availsampleqty]<>0 and [proname] = '" + ComboBox1.Text + "' and [btn]='" + ComboBox2.Text + "' and [cndn]='" + ComboBox3.Text + "' order by [proname] ASC")
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
                Dim cmd As New SqlCommand("Select [proname],[btn],[ptn],[pctyp],[cndn],[chrgdate],[sch],[availsampleqty] from plnr where [availsampleqty]<>0 and [proname] = '" + ComboBox1.Text + "' and [btn]='" + ComboBox2.Text + "' order by [proname] ASC")
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
                Dim cmd As New SqlCommand("Select [proname],[btn],[ptn],[pctyp],[cndn],[chrgdate],[sch],[availsampleqty] from plnr where [availsampleqty]<>0 and [btn] = '" + ComboBox2.Text + "' and [cndn]='" + ComboBox3.Text + "' order by [proname] ASC")
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
                Dim cmd As New SqlCommand("Select [proname],[btn],[ptn],[pctyp],[cndn],[chrgdate],[sch],[availsampleqty] from plnr where [availsampleqty]<>0 and [cndn] = '" + ComboBox3.Text + "' order by [proname] ASC")
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
                Dim cmd As New SqlCommand("Select [proname],[btn],[ptn],[pctyp],[cndn],[chrgdate],[sch],[availsampleqty] from plnr where [availsampleqty]<>0 and [proname] = '" + ComboBox1.Text + "' and [btn]='" + ComboBox2.Text + "' and [cndn]='" + ComboBox3.Text + "' order by [proname] ASC")
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
                Dim cmd As New SqlCommand("Select [proname],[btn],[ptn],[pctyp],[cndn],[chrgdate],[sch],[availsampleqty] from plnr where [availsampleqty]<>0 and [proname] = '" + ComboBox1.Text + "' and [cndn]='" + ComboBox3.Text + "' order by [proname] ASC")
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
            ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [proname],[btn],[ptn],[pctyp],[cndn],[chrgdate],[sch],[availsampleqty] from plnr where [availsampleqty]<>0 and [btn] = '" + ComboBox2.Text + "' and [cndn]='" + ComboBox3.Text + "' order by [proname] ASC")
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

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs)
        'unissued()
    End Sub
    Private Sub LoadissuedBatchNumber()
        Try
            ComboBox5.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(btn) from plnr where ID IN (SELECT ref_id FROM recon) and proname='" + ComboBox4.Text + "'"

            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox5.Items.Add(dr("btn"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TabControl1_MouseClick(sender As Object, e As MouseEventArgs) Handles TabControl1.MouseClick
        dgv2_rowstyle()
    End Sub
    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        LoadissuedBatchNumber()

        ' Me.BeginInvoke(New Action(Sub() ComboBox1.Select(0, 0)))
        Try
            If ComboBox5.Text = "" And ComboBox6.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("SELECT proname,btn,ptn FROM plnr WHERE ID IN (SELECT ref_id FROM recon ) and [proname] = '" + ComboBox4.Text + "' group by proname,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView2.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView2.DataSource = table1
                DataGridView2.Cursor = Cursors.Default
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgv2_rowstyle()
            ElseIf ComboBox5.Text <> "" And ComboBox6.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("SELECT proname,btn,ptn FROM plnr WHERE ID IN (SELECT ref_id FROM recon ) and [proname] = '" + ComboBox4.Text + "' and [btn]='" + ComboBox5.Text + "' and [cndn]='" + ComboBox6.Text + "' group by proname,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView2.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView2.DataSource = table1
                DataGridView2.Cursor = Cursors.Default
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgv2_rowstyle()
            ElseIf ComboBox5.Text <> "" And ComboBox6.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select proname,btn,ptn from plnr WHERE ID IN (SELECT ref_id FROM recon ) and [proname] = '" + ComboBox4.Text + "' and [btn]='" + ComboBox5.Text + "' group by proname,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView2.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView2.DataSource = table1
                DataGridView2.Cursor = Cursors.Default
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgv2_rowstyle()
            ElseIf ComboBox5.Text = "" And ComboBox6.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select proname,btn,ptn from plnr WHERE ID IN (SELECT ref_id FROM recon) and [proname] = '" + ComboBox4.Text + "' and [cndn]='" + ComboBox6.Text + "' group by proname,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView2.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView2.DataSource = table1
                DataGridView2.Cursor = Cursors.Default
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgv2_rowstyle()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged

        Try
            If ComboBox4.Text = "" And ComboBox6.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select proname,btn,ptn from plnr WHERE ID IN (SELECT ref_id FROM recon) and [btn] = '" + ComboBox5.Text + "' group by proname,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView2.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView2.DataSource = table1
                DataGridView2.Cursor = Cursors.Default
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgv2_rowstyle()
            ElseIf ComboBox4.Text <> "" And ComboBox6.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select proname,btn,ptn from plnr WHERE ID IN (SELECT ref_id FROM recon) and [proname] = '" + ComboBox4.Text + "' and [btn]='" + ComboBox5.Text + "' and [cndn]='" + ComboBox6.Text + "' group by proname,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView2.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView2.DataSource = table1
                DataGridView2.Cursor = Cursors.Default
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgv2_rowstyle()
            ElseIf ComboBox4.Text <> "" And ComboBox6.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select proname,btn,ptn from plnr WHERE ID IN (SELECT ref_id FROM recon) and [proname] = '" + ComboBox4.Text + "' and [btn]='" + ComboBox5.Text + "' group by proname,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView2.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView2.DataSource = table1
                DataGridView2.Cursor = Cursors.Default
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgv2_rowstyle()
            ElseIf ComboBox4.Text = "" And ComboBox6.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select proname,btn,ptn from plnr WHERE ID IN (SELECT ref_id FROM recon) and [btn] = '" + ComboBox5.Text + "' and [cndn]='" + ComboBox6.Text + "' group by proname,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView2.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView2.DataSource = table1
                DataGridView2.Cursor = Cursors.Default
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgv2_rowstyle()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged

        Try
            If ComboBox4.Text = "" And ComboBox5.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select proname,btn,ptn from plnr WHERE ID IN (SELECT ref_id FROM recon) and [cndn] = '" + ComboBox6.Text + "' group by proname,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView2.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView2.DataSource = table1
                DataGridView2.Cursor = Cursors.Default
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgv2_rowstyle()
            ElseIf ComboBox4.Text <> "" And ComboBox5.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select proname,btn,ptn from plnr WHERE ID IN (SELECT ref_id FROM recon) and [proname] = '" + ComboBox4.Text + "' and [btn]='" + ComboBox5.Text + "' and [cndn]='" + ComboBox6.Text + "' group by proname,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView2.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView2.DataSource = table1
                DataGridView2.Cursor = Cursors.Default
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgv2_rowstyle()
            ElseIf ComboBox4.Text <> "" And ComboBox5.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select proname,btn,ptn from plnr WHERE ID IN (SELECT ref_id FROM recon) and [proname] = '" + ComboBox4.Text + "' and [cndn]='" + ComboBox6.Text + "' group by proname,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView2.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView2.DataSource = table1
                DataGridView2.Cursor = Cursors.Default
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgv2_rowstyle()
            ElseIf ComboBox4.Text = "" And ComboBox5.Text Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select proname,btn,ptn from plnr WHERE ID IN (SELECT ref_id FROM recon) and [btn] = '" + ComboBox5.Text + "' and [cndn]='" + ComboBox6.Text + "' group by proname,btn,ptn order by [proname] ASC")
                cmd.Connection = con
                Dim adapter1 As New SqlDataAdapter(cmd)
                Dim table1 As New DataTable()
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
                DataGridView2.Cursor = Cursors.WaitCursor
                adapter1.Fill(table1)
                DataGridView2.DataSource = table1
                DataGridView2.Cursor = Cursors.Default
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgv2_rowstyle()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs) Handles GunaGradientButton4.Click
        ExportToPdfFile()
    End Sub
    Private Sub ExportToPdfFile()
        Try
            Dim doc As New Document(PageSize.A4.Rotate, 40.0F, 40.0F, 80.0F, 80)
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream("\\192.168.1.200\dqa\12. Stability Planner\Stability_Planner_Unissued_Sample_List.pdf", FileMode.Create))
            Dim pHeader As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

            writer.PageEvent = New HeaderFooter

            Dim pdfTable As New PdfPTable(8)
            pdfTable.TotalWidth = 780.0F
            pdfTable.LockedWidth = True
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER
            pdfTable.HeaderRows = 1

            Dim widths As Single() = New Single() {3.5F, 1.0F, 1.7F, 1.5F, 1.0F, 1.0F, 0.8F, 1.0F}
            pdfTable.SetWidths(widths)

            Dim pdfcell As PdfPCell = Nothing
            doc.Open()
            pdfcell = New PdfPCell(New Paragraph("Product Name", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER

            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Batch No.", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Protocol No.", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Pack Type", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Condition", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Charging Date", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Period", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Sample Qty", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            Dim dt As DataTable = GetDataTable()

            For i = 0 To dt.Rows.Count - 1
                For j As Integer = 0 To dt.Columns.Count - 1
                    pdfcell = New PdfPCell(New Paragraph(dt.Rows(i)(j).ToString, pRow))
                    pdfcell.MinimumHeight = 18
                    pdfcell.PaddingLeft = 5.0F
                    pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfTable.AddCell(pdfcell)
                Next
            Next

            'Unissued Sample Count
            Dim tabel As New PdfPTable(1)
            Dim cell As New PdfPCell(New Paragraph(GunaLabel6.Text, pHeader))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            tabel.TotalWidth = 780.0F
            tabel.LockedWidth = True
            cell.MinimumHeight = 20
            cell.PaddingLeft = 2.0F

            tabel.AddCell(cell)
            doc.Add(tabel)
            doc.Add(pdfTable)

            doc.Close()
            MsgBox("PDF Exported to \\192.168.1.200\dqa\12. Stability Planner\Stability_Planner_Unissued_Sample_List.pdf", vbInformation)
            Process.Start("\\192.168.1.200\dqa\12. Stability Planner\Stability_Planner_Unissued_Sample_List.pdf")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function GetDataTable()
        Dim datatable As New DataTable("dt")

        Dim datacolumn1 As New DataColumn(DataGridView1.Columns(0).HeaderText.ToString, GetType(String))
        Dim datacolumn2 As New DataColumn(DataGridView1.Columns(1).HeaderText.ToString, GetType(String))
        Dim datacolumn3 As New DataColumn(DataGridView1.Columns(2).HeaderText.ToString, GetType(String))
        Dim datacolumn4 As New DataColumn(DataGridView1.Columns(3).HeaderText.ToString, GetType(String))
        Dim datacolumn5 As New DataColumn(DataGridView1.Columns(4).HeaderText.ToString, GetType(String))
        Dim datacolumn6 As New DataColumn(DataGridView1.Columns(5).HeaderText.ToString, GetType(String))
        Dim datacolumn7 As New DataColumn(DataGridView1.Columns(6).HeaderText.ToString, GetType(String))
        Dim datacolumn8 As New DataColumn(DataGridView1.Columns(7).HeaderText.ToString, GetType(String))

        datatable.Columns.Add(datacolumn1)
        datatable.Columns.Add(datacolumn2)
        datatable.Columns.Add(datacolumn3)
        datatable.Columns.Add(datacolumn4)
        datatable.Columns.Add(datacolumn5)
        datatable.Columns.Add(datacolumn6)
        datatable.Columns.Add(datacolumn7)
        datatable.Columns.Add(datacolumn8)

        Dim row As DataRow
        For i = 0 To DataGridView1.Rows.Count - 1
            row = datatable.NewRow
            row(datacolumn1) = DataGridView1.Rows(i).Cells(0).Value
            row(datacolumn2) = DataGridView1.Rows(i).Cells(1).Value
            row(datacolumn3) = DataGridView1.Rows(i).Cells(2).Value
            row(datacolumn4) = DataGridView1.Rows(i).Cells(3).Value
            row(datacolumn5) = DataGridView1.Rows(i).Cells(4).Value

            'Charging Date
            If DataGridView1.Rows(i).Cells(5).Value.ToString = "" Then
                row(datacolumn6) = DataGridView1.Rows(i).Cells(5).Value
            Else
                row(datacolumn6) = (CType(DataGridView1.Rows(i).Cells(5).Value, DateTime)).ToString("dd/MM/yyyy")
            End If

            row(datacolumn7) = DataGridView1.Rows(i).Cells(6).Value
            row(datacolumn8) = DataGridView1.Rows(i).Cells(7).Value

            datatable.Rows.Add(row)
        Next

        datatable.AcceptChanges()
        Return datatable
    End Function
End Class
Class HeaderFooter
    Inherits PdfPageEventHelper
    Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)
        Dim HeaderFont As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font1 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font2 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim pdfCell As PdfPCell = Nothing
        Dim pdfHeader As New PdfPTable(1)
        pdfHeader.TotalWidth = document.PageSize.Width
        pdfHeader.DefaultCell.Border = 0

        pdfCell = New PdfPCell(New Paragraph("V-Ensure Pharma Technologies Pvt Ltd", HeaderFont))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.Border = 0
        pdfHeader.AddCell(pdfCell)

        pdfCell = New PdfPCell(New Paragraph("A-63, Kopar Khairane, Navi Mumbai", font1))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.Border = 0
        pdfHeader.AddCell(pdfCell)


        pdfCell = New PdfPCell(New Paragraph("Stability Planner", HeaderFont))
        pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
        pdfCell.Border = 0
        pdfHeader.AddCell(pdfCell)
        pdfHeader.WriteSelectedRows(0, -1, 0, document.GetTop(document.TopMargin) + 150, writer.DirectContent)

        Dim p1 As New PdfPTable(1)
        p1.TotalWidth = document.PageSize.Width
        p1.DefaultCell.Border = 0

        pdfCell = New PdfPCell(New Paragraph("Page: " & document.PageNumber, font1))
        pdfCell.Border = 0
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
        p1.AddCell(pdfCell)
        p1.WriteSelectedRows(0, -1, document.LeftMargin - 100, document.GetTop(document.TopMargin) + 100, writer.DirectContent)


    End Sub
End Class
