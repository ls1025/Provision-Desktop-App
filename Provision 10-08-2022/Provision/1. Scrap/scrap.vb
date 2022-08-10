Imports System.Data.SqlClient
Imports System.IO
Public Class scrap
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub updatestbcompilation_Load(sender As Object, e As EventArgs) Handles Me.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadStbCompilationDetails()
        LoadGeneral()
        LoadDisso()
        LoadImpurity()

        LoadCondition()
        LoadPeriod()
        LoadTest()
    End Sub
    Private Sub LoadStbCompilationDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim da As New SqlDataAdapter()
            Dim table As New DataTable()
            Dim dt As New DataTable()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select * from stbcomp_master where [btn]= '" + TextBox2.Text + "' ", con)
            da.Fill(table)

            'Product Name and Strength
            TextBox1.Text = table.Rows(0)(2).ToString + " " + table.Rows(0)(3).ToString
            'Pack Style
            TextBox3.Text = table.Rows(0)(5).ToString
            'Label Claim
            TextBox4.Text = table.Rows(0)(6).ToString
            'Charging Date
            Label1.Text = table.Rows(0)(7).ToString

        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadGeneral()
        Try
            DataGridView1.Rows.Clear()

            'Get PDS Details with product name
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds1 As DataSet = New DataSet
            Dim da1 As New SqlDataAdapter()
            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            da1 = New SqlDataAdapter("select [gen_cndn],[gen_period],[test],[gen_result] from stbcomp_general where [btn]='" + TextBox2.Text + "' order by gen_cndn ASC", con)
            Dim table1 As New DataTable()
            da1.Fill(table1)

            For i = 0 To table1.Rows.Count - 1
                DataGridView1.Rows.Add(table1.Rows(i)(0).ToString(), table1.Rows(i)(1).ToString(), table1.Rows(i)(2).ToString(), table1.Rows(i)(3).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadDisso()
        Try
            DataGridView2.Rows.Clear()

            'Get PDS Details with product name
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds1 As DataSet = New DataSet
            Dim da1 As New SqlDataAdapter()
            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            da1 = New SqlDataAdapter("select [disso_cndn],[disso_period],[timepoint],[min],[max] from stbcomp_disso where [btn]='" + TextBox2.Text + "' order by timepoint ASC", con)
            Dim table1 As New DataTable()
            da1.Fill(table1)

            For i = 0 To table1.Rows.Count - 1
                DataGridView2.Rows.Add(table1.Rows(i)(0).ToString(), table1.Rows(i)(1).ToString(), table1.Rows(i)(2).ToString(), table1.Rows(i)(3).ToString(), table1.Rows(i)(4).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadImpurity()
        Try
            DataGridView3.Rows.Clear()

            'Get PDS Details with product name
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds1 As DataSet = New DataSet
            Dim da1 As New SqlDataAdapter()
            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            da1 = New SqlDataAdapter("select [impurity],[imp_cndn],[imp_period],[imp_result] from stbcomp_impurity where [btn]='" + TextBox2.Text + "' order by imp_cndn ASC", con)
            Dim table1 As New DataTable()
            da1.Fill(table1)

            For i = 0 To table1.Rows.Count - 1
                DataGridView3.Rows.Add(table1.Rows(i)(0).ToString(), table1.Rows(i)(1).ToString(), table1.Rows(i)(2).ToString(), table1.Rows(i)(3).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadCondition()

        ComboBox1.Items.Clear()
        ComboBox4.Items.Clear()
        GunaComboBox4.Items.Clear()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "SELECT DISTINCT(cndn) from plnr order by cndn ASC"
        con.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        While dr.Read
            ComboBox1.Items.Add(dr("cndn"))
            ComboBox4.Items.Add(dr("cndn"))
            GunaComboBox4.Items.Add(dr("cndn"))
        End While
        dr.Close()
        con.Close()
    End Sub
    Private Sub LoadPeriod()
        ComboBox2.Items.Clear()
        ComboBox5.Items.Clear()
        GunaComboBox3.Items.Clear()
        ComboBox2.Items.Add("Initial")
        ComboBox5.Items.Add("Initial")
        GunaComboBox3.Items.Add("Initial")
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "SELECT DISTINCT(sch) from plnr order by sch ASC"
        con.Open()

        Dim dr As SqlDataReader = cmd.ExecuteReader
        While dr.Read
            ComboBox2.Items.Add(dr("sch"))
            ComboBox5.Items.Add(dr("sch"))
            GunaComboBox3.Items.Add(dr("sch"))
        End While

        dr.Close()
        con.Close()

    End Sub
    Private Sub LoadTest()
        ComboBox3.Items.Clear()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "SELECT DISTINCT(test) FROM testmaster order by test ASC"
        con.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        While dr.Read
            ComboBox3.Items.Add(dr("test"))
        End While
        dr.Close()
        con.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            UpdateGeneralTest()
            UpdateDissoTest()
            UpdateImpurities()

            MsgBox("Stability Compilation Details Updated Successfully", vbInformation)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub UpdateGeneralTest()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "delete from [stbcomp_general] where [btn]='" + TextBox2.Text + "'"
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "insert into stbcomp_general(btn,gen_cndn,gen_period,test,gen_result) values('" + TextBox2.Text + "','" + DataGridView1.Rows(i).Cells(0).Value + "','" + DataGridView1.Rows(i).Cells(1).Value + "','" + DataGridView1.Rows(i).Cells(2).Value + "','" + DataGridView1.Rows(i).Cells(3).Value + "')"
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
    End Sub
    Private Sub UpdateDissoTest()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "delete from [stbcomp_disso] where [btn]='" + TextBox2.Text + "'"
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()

        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "insert into stbcomp_disso(btn,disso_cndn,disso_period,timepoint,min,max) values('" + TextBox2.Text + "','" + DataGridView2.Rows(i).Cells(0).Value + "','" + DataGridView2.Rows(i).Cells(1).Value + "','" + DataGridView2.Rows(i).Cells(2).Value + "','" + DataGridView2.Rows(i).Cells(3).Value + "','" + DataGridView2.Rows(i).Cells(4).Value + "')"
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
    End Sub
    Private Sub UpdateImpurities()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "delete from [stbcomp_impurity] where [btn]='" + TextBox2.Text + "'"
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()

        For i As Integer = 0 To DataGridView3.Rows.Count - 1
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "insert into stbcomp_impurity(btn,impurity,imp_cndn,imp_period,imp_result) values('" + TextBox2.Text + "','" + DataGridView3.Rows(i).Cells(0).Value + "','" + DataGridView3.Rows(i).Cells(1).Value + "','" + DataGridView3.Rows(i).Cells(2).Value + "','" + DataGridView3.Rows(i).Cells(3).Value + "')"
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
    End Sub

    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs)
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
        Try
            If TextBox1.Text = "" Then
                ComboBox1.Items.Clear()
                ComboBox2.SelectedIndex = -1
                ComboBox3.SelectedIndex = -1
                TextBox2.Clear()

                TextBox4.Clear()
            ElseIf TextBox1.Text = "NA" Or TextBox1.Text = "na" Then
                ComboBox1.Items.Clear()
                TextBox2.Clear()

                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT DISTINCT(proname) FROM productmaster where productstatus='Active'"
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    ComboBox1.Items.Add(dr("proname"))
                End While
                dr.Close()
                con.Close()
            Else
                ComboBox1.Items.Clear()
                TextBox2.Clear()

                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT proname FROM productmaster where procode='" + TextBox1.Text + "' and productstatus='Active'"
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    ComboBox1.Items.Add(dr("proname"))
                End While
                dr.Close()
                con.Close()
            End If
        Catch ex As Exception

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
    Public Sub dgv2_rowstyle()
        For i As Integer = 0 To DataGridView1.RowCount - 1
            If i Mod 2 = 0 Then
                DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If
        Next
        DataGridView2.CurrentCell = Nothing
    End Sub
    Private Sub DataGridView2_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.ColumnHeaderMouseClick
        dgv2_rowstyle()
    End Sub
    Private Sub DataGridView2_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView2.DataSourceChanged
        dgv2_rowstyle()
    End Sub
    Public Sub dgv3_rowstyle()
        For i As Integer = 0 To DataGridView1.RowCount - 1
            If i Mod 2 = 0 Then
                DataGridView3.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView3.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If
        Next
        DataGridView3.CurrentCell = Nothing
    End Sub
    Private Sub DataGridView3_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView3.ColumnHeaderMouseClick
        dgv3_rowstyle()
    End Sub
    Private Sub DataGridView3_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView3.DataSourceChanged
        dgv3_rowstyle()
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Try
            If ComboBox1.Text = "" Then
                MsgBox("Selct Condition", vbCritical)
            ElseIf ComboBox2.Text = "" Then
                MsgBox("Select Period", vbCritical)
            ElseIf ComboBox3.Text = "" Then
                MsgBox("Select Test", vbCritical)
            ElseIf TextBox5.Text = "" Then
                MsgBox("Enter Result", vbCritical)
            Else
                For i = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Rows(i).Cells(0).Value = ComboBox1.Text And DataGridView1.Rows(i).Cells(1).Value = ComboBox2.Text And DataGridView1.Rows(i).Cells(2).Value = ComboBox3.Text Then
                        MsgBox("Result Already Added", vbCritical)
                        Exit Sub
                    End If
                Next
                DataGridView1.Rows.Add(ComboBox1.Text, ComboBox2.Text, ComboBox3.Text, TextBox5.Text)
                ComboBox1.SelectedIndex = -1
                ComboBox2.SelectedIndex = -1
                ComboBox3.SelectedIndex = -1
                TextBox5.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
        Else
            MessageBox.Show("Select 1 atleast one row to delete")
        End If
    End Sub

    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs) Handles GunaGradientButton4.Click
        Try
            If GunaComboBox4.Text = "" Then
                MsgBox("Select Condition", vbCritical)
            ElseIf GunaComboBox3.Text = "" Then
                MsgBox("Select Period", vbCritical)
            ElseIf TextBox6.Text = "" Then
                MsgBox("Enter Time Point", vbCritical)
            ElseIf TextBox7.Text = "" Then
                MsgBox("Enter Minimum Value", vbCritical)
            ElseIf TextBox8.Text = "" Then
                MsgBox("Enter Maximum Value", vbCritical)
            Else
                For i = 0 To DataGridView2.Rows.Count - 1
                    If DataGridView2.Rows(i).Cells(0).Value = GunaComboBox4.Text And DataGridView2.Rows(i).Cells(1).Value = GunaComboBox3.Text And DataGridView2.Rows(i).Cells(2).Value = TextBox6.Text And DataGridView2.Rows(i).Cells(3).Value = TextBox7.Text And DataGridView2.Rows(i).Cells(4).Value = TextBox8.Text Then
                        MsgBox("Time Point Already Added", vbCritical)
                        Exit Sub
                    End If
                Next

                DataGridView2.Rows.Add(GunaComboBox4.Text, GunaComboBox3.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text)
                TextBox6.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        If DataGridView2.SelectedRows.Count > 0 Then
            DataGridView2.Rows.Remove(DataGridView2.SelectedRows(0))
        Else
            MessageBox.Show("Select 1 atleast one row to delete")
        End If
    End Sub
    Private Sub GunaTextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub GunaTextBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub GunaGradientButton6_Click(sender As Object, e As EventArgs) Handles GunaGradientButton6.Click
        Try
            If TextBox9.Text = "" Then
                MsgBox("Enter Impurity", vbCritical)
            ElseIf ComboBox4.Text = "" Then
                MsgBox("Select Condition", vbCritical)
            ElseIf ComboBox5.Text = "" Then
                MsgBox("Select Period", vbCritical)
            ElseIf TextBox10.Text = "" Then
                MsgBox("Enter Result", vbCritical)
            Else
                For i = 0 To DataGridView3.Rows.Count - 1
                    If DataGridView3.Rows(i).Cells(0).Value = TextBox9.Text And DataGridView3.Rows(i).Cells(1).Value = TextBox9.Text And DataGridView3.Rows(i).Cells(2).Value = ComboBox5.Text Then
                        MsgBox("Impurity Details Already Added", vbCritical)
                        Exit Sub
                    End If
                Next

                DataGridView3.Rows.Add(TextBox9.Text, TextBox9.Text, TextBox7.Text, TextBox10.Text)
                TextBox9.Text = ""
                ComboBox4.SelectedIndex = -1
                ComboBox5.SelectedIndex = -1
                TextBox10.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GunaGradientButton5_Click(sender As Object, e As EventArgs) Handles GunaGradientButton5.Click
        If DataGridView3.SelectedRows.Count > 0 Then
            DataGridView3.Rows.Remove(DataGridView3.SelectedRows(0))
        Else
            MessageBox.Show("Select 1 atleast one row to delete")
        End If
    End Sub
End Class