Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp
Imports System.IO
Public Class viewintimationstbfrdgl
    Dim da As New SqlDataAdapter()

    Private Sub viewintimationstbfrdgl_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Guna.UI.Lib.GraphicsHelper.ShadowForm(Me)
        'Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
        TextBox1.Focus()
    End Sub
    Private Sub LoadProductNameStb()
        Try
            ComboBox1.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(productname) from trstb order by [productname] ASC"
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
            cmd.CommandText = "select DISTINCT(test) from trstb order by [test] ASC"
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
    Public Sub LoadIntimationStb()
        Try

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select [ID],[productcode],[productname],[strength],[btn],[test],[trno],[requestedby],[requestdate],[Status] from trstb order by [trno] DESC")
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
            DataGridView1.CurrentCell = Nothing
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
        DataGridView1.CurrentCell = Nothing
    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.DataSourceChanged
        dgv1_rowstyle()
    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New addtrstbfrdgl
        form.Owner = Me
        form.ShowDialog()
    End Sub
    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click

        Dim form As New viewcancelintstbfrdgl
        form.Owner = Me
        form.ShowDialog()
    End Sub

    Private Sub GunaGradientButton5_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If TextBox1.Text = "" Then
            DataGridView1.ColumnHeadersHeight = 30
        Else
            Filterdata1(TextBox1.Text)
            dgv1_rowstyle()
        End If
    End Sub
    Private Sub Filterdata1(ValueTosearch As String)
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select [ID],[productcode],[productname],[strength],[btn],[test],[trno],[requestedby],[requestdate],[Status] from trstb where ([trno] like '%" & ValueTosearch & "%' or [productcode] like '%" & ValueTosearch & "%' or [btn] like '%" & ValueTosearch & "%' or [Status] like '%" & ValueTosearch & "%') order by [trno] DESC")
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
        LoadIntimationStb()
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
                Dim cmd As New SqlCommand("Select [ID],[productcode],[productname],[strength],[btn],[test],[trno],[requestedby],[requestdate],[Status] from trstb where [productname] = '" + ComboBox1.Text + "' order by [trno] DESC")
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
                Dim cmd As New SqlCommand("Select [ID],[productcode],[productname],[strength],[btn],[test],[trno],[requestedby],[requestdate],[Status] from trstb where [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' order by [trno] DESC")
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
                Dim cmd As New SqlCommand("Select [ID],[productcode],[productname],[strength],[btn],[test],[trno],[requestedby],[requestdate],[Status] from trstb where [test] = '" + ComboBox2.Text + "' order by [trno] DESC")
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
                Dim cmd As New SqlCommand("Select [ID],[productcode],[productname],[strength],[btn],[test],[trno],[requestedby],[requestdate],[Status] from trstb where [productname] = '" + ComboBox1.Text + "' and [test]='" + ComboBox2.Text + "' order by [trno] DESC")
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
        ElseIf ComboBox3.Text = "Intimation" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [ID],[productcode],[productname],[strength],[btn],[test],[trno],[requestedby],[requestdate],[Status] from trstb where requestdate between @fromdate and @todate order by [trno] DESC")
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
                Dim cmd As New SqlCommand("Select [ID],[productcode],[productname],[strength],[btn],[test],[trno],[requestedby],[requestdate],[Status] from trstb where releaseddate between @fromdate and @todate order by [trno] DESC")
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

    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs) 
        For i As Integer = 0 To DataGridView1.Rows.Count() - 1
            Dim check As Boolean = DataGridView1.Rows(i).Cells(0).Value
            If check = True Then

                Try
                    Dim sr As DataGridViewRow = DataGridView1.Rows(i)
                    If sr.Cells(7).Value.Contains("DT/") Then
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim qry As String
                        qry = "SELECT prints FROM trdev where trno='" + sr.Cells(7).Value.ToString() + "'"
                        cmd = New SqlCommand(qry, con)
                        con.Open()
                        Dim totalprints As String
                        totalprints = cmd.ExecuteScalar().ToString()
                        Dim form As New trprintdev
                        If totalprints = "" Then
                            form.Label2.Text = "1"
                            form.Label1.Text = sr.Cells(7).Value.ToString()
                            form.Owner = Me
                            form.ShowDialog()
                        Else
                            MsgBox("You Can Only view the TR Sheet after 1 Print Outs", vbExclamation)
                            form.Label2.Text = "NA"
                            form.Label1.Text = sr.Cells(7).Value.ToString()
                            form.Button1.Hide()
                            form.GunaLabel5.Hide()
                            form.Label3.Hide()

                            form.Owner = Me
                            form.ShowDialog()
                        End If
                    ElseIf sr.Cells(7).Value.Contains("TR/") Then
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim qry As String
                        qry = "SELECT prints FROM trrot where trno='" + sr.Cells(7).Value.ToString() + "'"
                        cmd = New SqlCommand(qry, con)
                        con.Open()
                        Dim totalprints As String
                        totalprints = cmd.ExecuteScalar().ToString()
                        Dim form As New trprintdev
                        If totalprints = "" Then
                            form.Label2.Text = "1"
                            form.Label1.Text = sr.Cells(7).Value.ToString()
                            form.Owner = Me
                            form.ShowDialog()
                        Else
                            MsgBox("You Can Only view the TR Sheet after 1 Print Outs", vbExclamation)
                            form.Label2.Text = "NA"
                            form.Label1.Text = sr.Cells(7).Value.ToString()
                            form.Button1.Hide()
                            form.GunaLabel5.Hide()
                            form.Label3.Hide()

                            form.Owner = Me
                            form.ShowDialog()
                        End If
                    ElseIf sr.Cells(7).Value.Contains("ST/") Then
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim qry As String
                        qry = "SELECT prints FROM trstb where trno='" + sr.Cells(7).Value.ToString() + "'"
                        cmd = New SqlCommand(qry, con)
                        con.Open()
                        Dim totalprints As String
                        totalprints = cmd.ExecuteScalar().ToString()
                        Dim form As New trprintdev
                        If totalprints = "" Then
                            form.Label2.Text = "1"
                            form.Label1.Text = sr.Cells(7).Value.ToString()
                            form.Owner = Me
                            form.ShowDialog()
                        Else
                            MsgBox("You Can Only view the TR Sheet after 1 Print Outs", vbExclamation)
                            form.Label2.Text = "NA"
                            form.Label1.Text = sr.Cells(7).Value.ToString()
                            form.Button1.Hide()
                            form.GunaLabel5.Hide()
                            form.Label3.Hide()

                            form.Owner = Me
                            form.ShowDialog()
                        End If
                    End If
                Catch ex As Exception
                    ' MessageBox.Show(ex.Message)
                End Try
            End If
        Next
    End Sub

    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            Dim form As New updatetrstb
            form.Label1.Text = DataGridView1.SelectedCells(6).Value
            form.Owner = Me
            form.ShowDialog()
        End If
    End Sub
End Class

