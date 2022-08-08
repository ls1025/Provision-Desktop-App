﻿
Imports System.Data.SqlClient
    Imports iTextSharp.text
    Imports iTextSharp.text.pdf
    Imports iTextSharp
    Imports System.IO
Imports System.ComponentModel

Public Class viewcancelintstbfrdgl
    Dim da As New SqlDataAdapter()
    Private Sub viewcancelintstbfrdgl_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Guna.UI.Lib.GraphicsHelper.ShadowForm(Me)
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadProductNameStb()
        LoadTestStb()
        LoadCancelIntimationsStb()
        DataGridView1.ClearSelection()

        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
    End Sub
    Private Sub LoadProductNameStb()
        Try
            ComboBox1.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(productname) from trstb where creqby is NOT NULL order by [productname] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("productname"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadTestStb()
        Try
            ComboBox2.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(test) from trstb where creqby is NOT NULL order by [test] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr("test"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LoadCancelIntimationsStb()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select [ID],[trno],[creqby],[creqdate],[cancelledby],[cancelleddate],[creqstatus] from trstb where creqby is NOT NULL order by [creqdate] DESC")
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
            dgv1_rowstyle()
            'DataGridView1.CurrentCell = Nothing
            GunaLabel6.Text = "Records: " + DataGridView1.Rows.Count.ToString

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

    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        dgv1_rowstyle()

    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.DataSourceChanged
        dgv1_rowstyle()

    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New newcancelreqstbfrdgl
        form.Owner = Me
        form.ShowDialog()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If TextBox1.Text = "" Then
            DataGridView1.ColumnHeadersHeight = 30
            DataGridView1.CurrentCell = Nothing
        Else
            Filterdata1(TextBox1.Text)
            dgv1_rowstyle()
            DataGridView1.CurrentCell = Nothing
        End If
    End Sub

    Private Sub Filterdata1(ValueTosearch As String)
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select [ID],[trno],[creqby],[creqdate],[cancelledby],[cancelleddate],[creqstatus] from trstb where creqby is NOT NULL and ([productcode] like '%" & ValueTosearch & "%' or [btn] like '%" & ValueTosearch & "%' or [creqstatus] like '%" & ValueTosearch & "%') order by [creqdate] DESC")
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadCancelIntimationsStb()
        LoadProductNameStb()
        LoadTestStb()
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
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            If ComboBox2.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [ID],[trno],[creqby],[creqdate],[cancelledby],[cancelleddate],[creqstatus] from trstb where creqby is NOT NULL and [productname] = '" + ComboBox1.Text + "' order by [creqdate] DESC")
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
            ElseIf ComboBox2.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [ID],[trno],[creqby],[creqdate],[cancelledby],[cancelleddate],[creqstatus] from trstb where creqby is NOT NULL and [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' order by [creqdate] DESC")
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

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            If ComboBox1.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [ID],[trno],[creqby],[creqdate],[cancelledby],[cancelleddate],[creqstatus] from trstb where creqby is NOT NULL and [test] = '" + ComboBox2.Text + "' order by [creqdate] DESC")
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
            ElseIf ComboBox1.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [ID],[trno],[creqby],[creqdate],[cancelledby],[cancelleddate],[creqstatus] from trstb where creqby is NOT NULL and [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' order by [creqdate] DESC")
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox3.Text = "" Then
            MsgBox("Select Activity", vbCritical)
        ElseIf ComboBox3.Text = "Cancell Request" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [ID],[trno],[creqby],[creqdate],[cancelledby],[cancelleddate],[creqstatus] from trstb where Status='Cancel request' and creqby is NOT NULL and creqdate between @fromdate and @todate order by [creqdate] DESC")
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@fromdate", SqlDbType.Date).Value = DateTimePicker1.Value.Date
                cmd.Parameters.AddWithValue("@todate", SqlDbType.Date).Value = DateTimePicker2.Value.Date
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
        ElseIf ComboBox3.Text = "Cancelled" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [ID],[trno],[creqby],[creqdate],[cancelledby],[cancelleddate],[creqstatus] from trstb where Status='Cancelled' and creqby is NOT NULL and cancelleddate between @fromdate and @todate order by [creqdate] DESC")
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@fromdate", SqlDbType.Date).Value = DateTimePicker1.Value.Date
                cmd.Parameters.AddWithValue("@todate", SqlDbType.Date).Value = DateTimePicker2.Value.Date
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

    Private Sub viewcancelintstbfrdgl_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        '  Dim f1 As viewintimationstbfrdgl = DirectCast(Me.Owner, viewintimationstbfrdgl)
        '  f1.LoadIntimationStb()
    End Sub

    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click

        Dim result As Integer = MessageBox.Show("Are you sure to Cancel the selected TR numbers", "Confirmation before submit", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If result = DialogResult.Yes Then
            For i As Integer = 0 To DataGridView1.Rows.Count() - 1
                Dim check As Boolean = DataGridView1.Rows(i).Cells(0).Value
                If check = True Then
                    If DataGridView1.Rows(i).Cells(7).Value = "Cancelled" Then
                        MsgBox("Some of the TRs are already cancelled", vbExclamation)
                        Exit Sub
                    Else
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd1 As New SqlCommand
                        cmd1.Connection = con
                        cmd1.CommandText = "update trstb set creqstatus='Approved',Status='Cancelled',cancelledby='" + Homepagefrdgl.Label1.Text + "',cancelleddate=@cancelleddate where trno='" + DataGridView1.Rows(i).Cells(2).Value + "'"
                        cmd1.Parameters.AddWithValue("@cancelleddate", SqlDbType.Date).Value = DateTime.Now.Date
                        con.Open()
                        cmd1.ExecuteNonQuery()
                    End If


                End If
            Next
            'MsgBox("Intimation Cancelled Successfully", vbInformation)
            LoadCancelIntimationsStb()
        End If

    End Sub
    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Dim result As Integer = MessageBox.Show("Are you sure to Reject the Cancel request for selected TR numbers", "Confirmation before submit", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If result = DialogResult.Yes Then
            For i As Integer = 0 To DataGridView1.Rows.Count() - 1
                Dim check As Boolean = DataGridView1.Rows(i).Cells(0).Value
                If check = True Then
                    If DataGridView1.Rows(i).Cells(7).Value = "Cancelled" Then
                        MsgBox("Some of the TRs already cancelled. You cannot Reject", vbExclamation)
                        Exit Sub
                    Else
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd1 As New SqlCommand
                        cmd1.Connection = con
                        cmd1.CommandText = "update trstb set creqstatus='Rejected',creqrejectedby='" + Homepagefrdgl.Label1.Text + "',creqrejectedon=@creqrejectedon where trno='" + DataGridView1.Rows(i).Cells(2).Value + "'"
                        cmd1.Parameters.AddWithValue("@creqrejectedon", SqlDbType.Date).Value = DateTime.Now.Date
                        con.Open()
                        cmd1.ExecuteNonQuery()
                    End If

                End If
            Next
            'MsgBox("Intimation Cancelled Successfully", vbInformation)
            LoadCancelIntimationsStb()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'MsgBox(e.ColumnIndex)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        checkall()
    End Sub
    Private Sub checkall()
        If DataGridView1.Rows.Count = 0 Then
            'MsgBox("No Data to Select", vbCritical)

        Else

            If CheckBox1.Checked = True Then

                Dim i As Integer = 0
                For i = 0 To DataGridView1.RowCount - 1
                    DataGridView1.Rows(i).Cells(0).Value = True
                Next
            ElseIf CheckBox1.Checked = False Then
                Dim i As Integer = 0
                For i = 0 To DataGridView1.RowCount - 1
                    DataGridView1.Rows(i).Cells(0).Value = False
                Next
            End If
        End If
    End Sub


End Class

