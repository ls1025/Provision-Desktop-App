Imports System.Data.SqlClient
Imports SautinSoft
Imports System.IO
Public Class viewtrstatus
    Dim da As New SqlDataAdapter()

    Private Sub viewtrstatus_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Guna.UI.Lib.GraphicsHelper.ShadowForm(Me)
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadProductNameDev()
        LoadTestDev()

        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
    End Sub
    Private Sub LoadProductNameDev()
        Try
            ComboBox1.Items.Clear()

            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(productname) from trdev union select DISTINCT(productname) from trrot union select DISTINCT(productname) from trstb order by [productname] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("productname"))
            End While
            dr.Close()
            con.Close()

            For Row As Int16 = 0 To ComboBox1.Items.Count - 2
                For RowAgain As Int16 = ComboBox1.Items.Count - 1 To Row + 1 Step -1
                    If ComboBox1.Items(Row).ToString = ComboBox1.Items(RowAgain).ToString Then
                        ComboBox1.Items.RemoveAt(RowAgain)
                    End If
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadTestDev()
        Try
            ComboBox2.Items.Clear()

            'Load Test from Development
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(test) from trdev union select DISTINCT(test) from trrot union select DISTINCT(test) from trstb order by [test] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr("test"))
            End While
            dr.Close()
            con.Close()

            For Row As Int16 = 0 To ComboBox2.Items.Count - 2
                For RowAgain As Int16 = ComboBox2.Items.Count - 1 To Row + 1 Step -1
                    If ComboBox2.Items(Row).ToString = ComboBox2.Items(RowAgain).ToString Then
                        ComboBox2.Items.RemoveAt(RowAgain)
                    End If
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LoadDate()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd2 As New SqlCommand
        cmd2.Connection = con
        cmd2.CommandText = "select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trdev union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trrot union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trstb order by [trno] DESC"

        Dim dt1 As New DataTable
        Using dad As New SqlDataAdapter(cmd2)
            dad.Fill(dt1)
        End Using

        Dim bsData As BindingSource = New BindingSource()
        bsData.DataSource = dt1
        DataGridView1.DataSource = bsData

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
    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.DataSourceChanged
        dgv1_rowstyle()
    End Sub
    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            Dim form As New detailview
            form.Label1.Text = DataGridView1.SelectedCells(6).Value
            form.Owner = Me
            form.ShowDialog()
        End If

    End Sub
    Private Sub GunaGradientButton5_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If TextBox1.Text = "" Then
            DataGridView1.ColumnHeadersHeight = 30

            'LoadIntimationDev()
        Else
            Filterdata1(TextBox1.Text)
            dgv1_rowstyle()
        End If
    End Sub
    Private Sub Filterdata1(ValueTosearch As String)
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trdev where  ([btn] like '%" & ValueTosearch & "%' or [productcode] like '%" & ValueTosearch & "%' or [trno] like '%" & ValueTosearch & "%' or [atrissueno] like '%" & ValueTosearch & "%') union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trrot where ([btn] like '%" & ValueTosearch & "%' or [productcode] like '%" & ValueTosearch & "%' or [trno] like '%" & ValueTosearch & "%' or [atrissueno] like '%" & ValueTosearch & "%') union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trstb where ([btn] like '%" & ValueTosearch & "%' or [productcode] like '%" & ValueTosearch & "%' or [trno] like '%" & ValueTosearch & "%' or [atrissueno] like '%" & ValueTosearch & "%') order by [trno] DESC")
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
        ' LoadDate()
        LoadProductNameDev()
        LoadTestDev()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        'ComboBox5.SelectedIndex = -1
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
                Dim cmd As New SqlCommand("select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trdev where [productname] = '" + ComboBox1.Text + "' union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trrot where [productname] = '" + ComboBox1.Text + "' union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trstb where [productname] = '" + ComboBox1.Text + "' order by [trno] DESC")
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
                Dim cmd As New SqlCommand("select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trdev where [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trrot where [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trstb where [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' order by [trno] DESC")
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
                Dim cmd As New SqlCommand("select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trdev where [test] = '" + ComboBox2.Text + "' union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trrot where [test] = '" + ComboBox2.Text + "' union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trstb where [test] = '" + ComboBox2.Text + "' order by [trno] DESC")
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
                Dim cmd As New SqlCommand("select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trdev where [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trrot where [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trstb where [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' order by [trno] DESC")
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

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If ComboBox3.Text = "" Then
            MsgBox("Select Activity", vbCritical)
        ElseIf ComboBox3.Text = "New TR" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trdev where requestdate between @fromdate and @todate union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trrot where requestdate between @fromdate and @todate union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trstb where requestdate between @fromdate and @todate order by [trno] DESC")
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
        ElseIf ComboBox3.Text = "TR Printed" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trdev where trprintdate between @fromdate and @todate union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trrot where trprintdate between @fromdate and @todate union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trstb where trprintdate between @fromdate and @todate order by [trno] DESC")
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
        ElseIf ComboBox3.Text = "ATR Issued" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trdev where atrissueddate between @fromdate and @todate union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trrot where atrissueddate between @fromdate and @todate union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trstb where atrissueddate between @fromdate and @todate order by [trno] DESC")
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

        ElseIf ComboBox3.Text = "Data Sent to DQA" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trdev where datasentdate between @fromdate and @todate union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trrot where datasentdate between @fromdate and @todate union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trstb where datasentdate between @fromdate and @todate order by [trno] DESC")
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


        ElseIf ComboBox3.Text = "Released" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trdev where releaseddate IS NOT NULL and releaseddate between @fromdate and @todate union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trrot where releaseddate IS NOT NULL and releaseddate between @fromdate and @todate union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trstb where releaseddate IS NOT NULL and releaseddate between @fromdate and @todate order by [trno] DESC")
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
        ElseIf ComboBox3.Text = "Data Uploaded" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trdev where datauploaddate IS NOT NULL and datauploaddate between @fromdate and @todate union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trrot where datauploaddate IS NOT NULL and datauploaddate between @fromdate and @todate union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trstb where datauploaddate IS NOT NULL and datauploaddate between @fromdate and @todate order by [trno] DESC")
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
                Dim cmd As New SqlCommand("select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trdev where cancelleddate IS NOT NULL and cancelleddate between @fromdate and @todate union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trrot where cancelleddate IS NOT NULL and cancelleddate between @fromdate and @todate union select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trstb where cancelleddate IS NOT NULL and cancelleddate between @fromdate and @todate order by [trno] DESC")
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
    Dim trtype As String
    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        If ComboBox4.Text = "Development" Then
            trtype = "trdev"
        ElseIf ComboBox4.Text = "Routine" Then
            trtype = "trrot"
        ElseIf ComboBox4.Text = "Stability" Then
            trtype = "trstb"
        End If

        If ComboBox5.Text = "" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from " + trtype + " order by [trno] DESC")
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

        ElseIf ComboBox5.Text <> "" Then

            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from " + trtype + " where [Status] ='" + ComboBox5.Text + "' order by [trno] DESC")
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
    ' Dim status As String
    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        ' If ComboBox5.Text = "Cancelled" Then
        'status = "'Cancelled'"
        'ElseIf ComboBox5.Text = "Released" Then
        'tus = "'Released'"
        ' ElseIf ComboBox5.Text = "Data Uploaded" Then
        'status = "'Data Uploaded'"
        ' End If

        If ComboBox4.Text = "" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trdev where [Status] ='" + ComboBox5.Text + "' union Select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trrot where [Status] ='" + ComboBox5.Text + "' union Select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from trstb where [Status] ='" + ComboBox5.Text + "' order by [trno] DESC")
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

        ElseIf ComboBox4.Text <> "" Then

            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [id],[productcode],[productname],[strength],[btn],[test],[trno],[Status] from " + trtype + " where [Status] ='" + ComboBox5.Text + "' order by [trno] DESC")
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' MsgBox(e.ColumnIndex)
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            If DataGridView1.SelectedCells(6).Value.ToString.Contains("DT/") Then
                Try
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry1 As String
                    qry1 = "select datafile from trdev where trno='" + DataGridView1.SelectedCells(6).Value.ToString + "'"
                    cmd = New SqlCommand(qry1, con)
                    Dim sFilePath As String
                    Dim buffer As Byte()
                    con.Open()
                    buffer = cmd.ExecuteScalar()
                    con.Close()
                    sFilePath = System.IO.Path.GetTempFileName()
                    System.IO.File.Move(sFilePath, System.IO.Path.ChangeExtension(sFilePath, ".pdf"))
                    sFilePath = System.IO.Path.ChangeExtension(sFilePath, ".pdf")
                    System.IO.File.WriteAllBytes(sFilePath, buffer)
                    Dim act As Action(Of String) = New Action(Of String)(AddressOf OpenPDFFile)
                    act.BeginInvoke(sFilePath, Nothing, Nothing)
                Catch ex As Exception
                    MsgBox("Not Available", vbExclamation)
                End Try
            ElseIf DataGridView1.SelectedCells(6).Value.ToString.Contains("TR/") Then
                Try
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry1 As String
                    qry1 = "select datafile from trrot where trno='" + DataGridView1.SelectedCells(6).Value.ToString + "'"
                    cmd = New SqlCommand(qry1, con)
                    Dim sFilePath As String
                    Dim buffer As Byte()
                    con.Open()
                    buffer = cmd.ExecuteScalar()
                    con.Close()
                    sFilePath = System.IO.Path.GetTempFileName()
                    System.IO.File.Move(sFilePath, System.IO.Path.ChangeExtension(sFilePath, ".pdf"))
                    sFilePath = System.IO.Path.ChangeExtension(sFilePath, ".pdf")
                    System.IO.File.WriteAllBytes(sFilePath, buffer)
                    Dim act As Action(Of String) = New Action(Of String)(AddressOf OpenPDFFile)
                    act.BeginInvoke(sFilePath, Nothing, Nothing)
                Catch ex As Exception
                    MsgBox("Not Available", vbExclamation)
                End Try
            ElseIf DataGridView1.SelectedCells(6).Value.ToString.Contains("ST/") Then
                Try
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry1 As String
                    qry1 = "select datafile from trstb where trno='" + DataGridView1.SelectedCells(6).Value.ToString + "'"
                    cmd = New SqlCommand(qry1, con)
                    Dim sFilePath As String
                    Dim buffer As Byte()
                    con.Open()
                    buffer = cmd.ExecuteScalar()
                    con.Close()
                    sFilePath = System.IO.Path.GetTempFileName()
                    System.IO.File.Move(sFilePath, System.IO.Path.ChangeExtension(sFilePath, ".pdf"))
                    sFilePath = System.IO.Path.ChangeExtension(sFilePath, ".pdf")
                    System.IO.File.WriteAllBytes(sFilePath, buffer)
                    Dim act As Action(Of String) = New Action(Of String)(AddressOf OpenPDFFile)
                    act.BeginInvoke(sFilePath, Nothing, Nothing)
                Catch ex As Exception
                    MsgBox("Not Available", vbExclamation)
                End Try
            End If

        End If

    End Sub
    Private Shared Sub OpenPDFFile(ByVal sFilePath)
        Using p As New System.Diagnostics.Process
            p.StartInfo = New System.Diagnostics.ProcessStartInfo(sFilePath)
            p.Start()
            p.WaitForExit()
            Try
                System.IO.File.Delete(sFilePath)
            Catch
            End Try
        End Using
    End Sub

    Private Sub WithNoPrint()
        Try
            If DataGridView1.SelectedCells.Count > 0 Then
                If DataGridView1.SelectedCells(6).Value.ToString.Contains("DT/") Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry1 As String
                    qry1 = "select datafile from trdev where trno='" + DataGridView1.SelectedCells(6).Value.ToString + "'"
                    cmd = New SqlCommand(qry1, con)
                    Dim sFilePath As String
                    Dim buffer As Byte()
                    con.Open()
                    buffer = cmd.ExecuteScalar()
                    con.Close()
                    sFilePath = System.IO.Path.GetTempFileName()
                    System.IO.File.Move(sFilePath, System.IO.Path.ChangeExtension(sFilePath, ".pdf"))
                    sFilePath = System.IO.Path.ChangeExtension(sFilePath, ".pdf")
                    System.IO.File.WriteAllBytes(sFilePath, buffer)

                    Dim f As SautinSoft.PdfFocus = New SautinSoft.PdfFocus()
                    f.OpenPdf(sFilePath)

                    Dim Outputfile As String
                    Outputfile = System.IO.Path.GetTempFileName()
                    System.IO.File.Move(Outputfile, System.IO.Path.ChangeExtension(Outputfile, ".tiff"))
                    Outputfile = System.IO.Path.ChangeExtension(sFilePath, ".tiff")
                    'System.IO.File.WriteAllBytes(sFilePath, buffer)

                    If f.PageCount > 0 Then
                        f.ImageOptions.Dpi = 600
                        f.ToMultipageTiff(Outputfile)
                    End If
                    Dim form As New viewdata

                    'Dim path As String = "c:\test.tif"
                    If File.Exists(Outputfile) Then
                        form.GunaImageButton1.BackgroundImage = Image.FromFile(Outputfile)
                    End If
                    'form.TextBox1.Text = f.PageCount
                    form.Label1.Text = f.PageCount
                    form.ShowDialog()
                    'SplitePDF(sFilePath)

                ElseIf DataGridView1.SelectedCells(6).Value.ToString.Contains("TR/") Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry1 As String
                    qry1 = "select datafile from trrot where trno='" + DataGridView1.SelectedCells(6).Value.ToString + "'"
                    cmd = New SqlCommand(qry1, con)
                    Dim sFilePath As String
                    Dim buffer As Byte()
                    con.Open()
                    buffer = cmd.ExecuteScalar()
                    con.Close()
                    sFilePath = System.IO.Path.GetTempFileName()
                    System.IO.File.Move(sFilePath, System.IO.Path.ChangeExtension(sFilePath, ".pdf"))
                    sFilePath = System.IO.Path.ChangeExtension(sFilePath, ".pdf")
                    System.IO.File.WriteAllBytes(sFilePath, buffer)

                    Dim f As SautinSoft.PdfFocus = New SautinSoft.PdfFocus()
                    f.OpenPdf(sFilePath)

                    Dim Outputfile As String
                    Outputfile = System.IO.Path.GetTempFileName()
                    System.IO.File.Move(Outputfile, System.IO.Path.ChangeExtension(Outputfile, ".tiff"))
                    Outputfile = System.IO.Path.ChangeExtension(sFilePath, ".tiff")
                    'System.IO.File.WriteAllBytes(sFilePath, buffer)

                    If f.PageCount > 0 Then
                        f.ImageOptions.Dpi = 600
                        f.ToMultipageTiff(Outputfile)
                    End If
                    Dim form As New viewdata

                    'Dim path As String = "c:\test.tif"
                    If File.Exists(Outputfile) Then
                        form.GunaImageButton1.BackgroundImage = Image.FromFile(Outputfile)
                    End If
                    'form.TextBox1.Text = f.PageCount
                    form.Label1.Text = f.PageCount
                    form.ShowDialog()
                    'SplitePDF(sFilePath)

                ElseIf DataGridView1.SelectedCells(6).Value.ToString.Contains("ST/") Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry1 As String
                    qry1 = "select datafile from trstb where trno='" + DataGridView1.SelectedCells(6).Value.ToString + "'"
                    cmd = New SqlCommand(qry1, con)
                    Dim sFilePath As String
                    Dim buffer As Byte()
                    con.Open()
                    buffer = cmd.ExecuteScalar()
                    con.Close()
                    sFilePath = System.IO.Path.GetTempFileName()
                    System.IO.File.Move(sFilePath, System.IO.Path.ChangeExtension(sFilePath, ".pdf"))
                    sFilePath = System.IO.Path.ChangeExtension(sFilePath, ".pdf")
                    System.IO.File.WriteAllBytes(sFilePath, buffer)

                    Dim f As SautinSoft.PdfFocus = New SautinSoft.PdfFocus()
                    f.OpenPdf(sFilePath)

                    Dim Outputfile As String
                    Outputfile = System.IO.Path.GetTempFileName()
                    System.IO.File.Move(Outputfile, System.IO.Path.ChangeExtension(Outputfile, ".tiff"))
                    Outputfile = System.IO.Path.ChangeExtension(sFilePath, ".tiff")
                    'System.IO.File.WriteAllBytes(sFilePath, buffer)

                    If f.PageCount > 0 Then
                        f.ImageOptions.Dpi = 600
                        f.ToMultipageTiff(Outputfile)
                    End If
                    Dim form As New viewdata

                    'Dim path As String = "c:\test.tif"
                    If File.Exists(Outputfile) Then
                        form.GunaImageButton1.BackgroundImage = Image.FromFile(Outputfile)
                    End If
                    'form.TextBox1.Text = f.PageCount
                    form.Label1.Text = f.PageCount
                    form.ShowDialog()
                    'SplitePDF(sFilePath)
                End If
            End If


        Catch ex As Exception
            MsgBox("Not Available", vbExclamation)
        End Try
    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaGradientButton2_Click_1(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Dim form As New exportdataard
        form.ShowDialog()
    End Sub
End Class

