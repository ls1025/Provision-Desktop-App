Imports System.Data.SqlClient
Public Class viewtrstatusfrdgl
    Dim da As New SqlDataAdapter()

    Private Sub viewtrstatusfrdgl_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Guna.UI.Lib.GraphicsHelper.ShadowForm(Me)
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

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
            cmd.CommandText = "select DISTINCT(productname) from trdev where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') union select DISTINCT(productname) from trrot where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') union select DISTINCT(productname) from trstb where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') order by [productname] ASC"
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
            cmd.CommandText = "select DISTINCT(test) from trdev where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') union select DISTINCT(test) from trrot where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') union select DISTINCT(test) from trstb where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') order by [test] ASC"
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
    Public Sub LoadDateGroupWise()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd2 As New SqlCommand
        cmd2.Connection = con
        cmd2.CommandText = "select [productname],[strength],[btn],[test] from trdev where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trrot where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trstb where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') group by [productname],[strength],[btn],[test]"

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
            Dim cmd As New SqlCommand("select [productname],[strength],[btn],[test] from trdev where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and ([btn] like '%" & ValueTosearch & "%' or [productcode] like '%" & ValueTosearch & "%' or [trno] like '%" & ValueTosearch & "%') group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trrot where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and ([atrissueno] like '%" & ValueTosearch & "%' or [productcode] like '%" & ValueTosearch & "%' or [trno] like '%" & ValueTosearch & "%') group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trstb where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and ([atrissueno] like '%" & ValueTosearch & "%' or [productcode] like '%" & ValueTosearch & "%' or [trno] like '%" & ValueTosearch & "%') group by [productname],[strength],[btn],[test]")
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
        LoadDateGroupWise()
        LoadProductNameDev()
        LoadTestDev()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1

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
                Dim cmd As New SqlCommand("select [productname],[strength],[btn],[test] from trdev where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and [productname] = '" + ComboBox1.Text + "' group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trrot where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and [productname] = '" + ComboBox1.Text + "' group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trstb where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and [productname] = '" + ComboBox1.Text + "' group by [productname],[strength],[btn],[test]")
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
                Dim cmd As New SqlCommand("select [productname],[strength],[btn],[test] from trdev where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trrot where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trstb where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' group by [productname],[strength],[btn],[test]")
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
                Dim cmd As New SqlCommand("select [productname],[strength],[btn],[test] from trdev where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and [test] = '" + ComboBox2.Text + "' group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trrot where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and [test] = '" + ComboBox2.Text + "' group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trstb where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and [test] = '" + ComboBox2.Text + "' group by [productname],[strength],[btn],[test]")
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
                Dim cmd As New SqlCommand("select [productname],[strength],[btn],[test] from trdev where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trrot where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trstb where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' group by [productname],[strength],[btn],[test]")
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
        ElseIf ComboBox3.Text = "Intimation" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select [productname],[strength],[btn],[test] from trdev where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and requestdate between @fromdate and @todate group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trrot where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and requestdate between @fromdate and @todate group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trstb where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and requestdate between @fromdate and @todate group by [productname],[strength],[btn],[test]")
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
                Dim cmd As New SqlCommand("select [productname],[strength],[btn],[test] from trdev where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and cancelleddate IS NOT NULL and cancelleddate between @fromdate and @todate group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trrot where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and cancelleddate IS NOT NULL and cancelleddate between @fromdate and @todate group by [productname],[strength],[btn],[test] union select [productname],[strength],[btn],[test] from trstb where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') and cancelleddate IS NOT NULL and cancelleddate between @fromdate and @todate group by [productname],[strength],[btn],[test]")
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
    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        If ComboBox4.Text = "Development" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [productname],[strength],[btn],[test] from trdev where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') group by [productname],[strength],[btn],[test]")
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
        ElseIf ComboBox4.Text = "Routine" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [productname],[strength],[btn],[test] from trrot where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') group by [productname],[strength],[btn],[test]")
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
        ElseIf ComboBox4.Text = "Stability" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [productname],[strength],[btn],[test] from trstb where (reportingto='" + Homepagefrdgl.Label1.Text + "' or requestedby='" + Homepagefrdgl.Label1.Text + "') group by [productname],[strength],[btn],[test]")
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
End Class

