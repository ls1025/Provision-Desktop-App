Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Public Class addstbcompilation
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub addstbcompilation_Load(sender As Object, e As EventArgs) Handles Me.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Enter Product Code", vbCritical)
            ElseIf ComboBox1.Text = "" Then
                MsgBox("Enter Product Name", vbCritical)
            ElseIf ComboBox2.Text = "" Then
                MsgBox("Select Batch Number", vbCritical)
            ElseIf ComboBox3.Text = "" Then
                MsgBox("Select Pack Style", vbCritical)
            ElseIf TextBox3.Text = "" Then
                MsgBox("Enter Label Claim", vbCritical)
            Else
                If con.State = ConnectionState.Open Then con.Close()
                Dim qry As String
                qry = "select COUNT(btn) from stbcomp_master where btn='" + ComboBox2.Text + "'"
                cmd1 = New SqlCommand(qry, con)
                con.Open()
                Dim SameTest As Integer
                SameTest = cmd1.ExecuteScalar()
                If SameTest = 0 Then

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd1 As New SqlCommand
                    cmd1.Connection = con
                    cmd1.CommandText = "insert into stbcomp_master(procode,proname,strength,btn,packstyle,label,chrgdate,addedby,addedon) values('" + TextBox1.Text + "','" + ComboBox1.Text + "','" + TextBox2.Text + "','" + ComboBox2.Text + "','" + ComboBox3.Text + "','" + TextBox3.Text + "','" + Label1.Text + "','" + homepageard.Label1.Text + "',@addedon)"
                    cmd1.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd1.ExecuteNonQuery()
                    con.Close()

                    AddGeneralTest()
                    AddDissoTest()
                    AddImpurities()

                    MsgBox("Stability Compilation Details Added Successfully", vbInformation)
                    Dim f1 As viewstbcompilation = DirectCast(Me.Owner, viewstbcompilation)
                    f1.loadStabilityCompilation()
                    Me.Close()
                Else
                    MsgBox("Stability Compilation for this Batch number is Already Exist", vbCritical)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub AddGeneralTest()
        For i As Integer = 0 To DataGridView1.Rows.Count - 2
            Dim gen_period As Integer
            If DataGridView1.Rows(i).Cells(0).Value = "Initial" Then
                gen_period = 0
            Else
                gen_period = Integer.Parse(Regex.Replace(DataGridView1.Rows(i).Cells(1).Value, "[^\d]", ""))
            End If

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "insert into stbcomp_general(btn,gen_cndn,gen_period,test,gen_result,gen_limit,gen_seq) values('" + ComboBox2.Text + "','" + DataGridView1.Rows(i).Cells(0).Value + "','" + DataGridView1.Rows(i).Cells(1).Value + "','" + DataGridView1.Rows(i).Cells(2).Value + "','" + DataGridView1.Rows(i).Cells(3).Value + "','" + DataGridView1.Rows(i).Cells(4).Value + "','" + gen_period.ToString + "')"
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
    End Sub
    Private Sub AddDissoTest()

        For i As Integer = 0 To DataGridView2.Rows.Count - 2
            Dim disso_period As Integer
            If DataGridView2.Rows(i).Cells(0).Value = "Initial" Then
                disso_period = 0
            Else
                disso_period = Integer.Parse(Regex.Replace(DataGridView2.Rows(i).Cells(1).Value, "[^\d]", ""))
            End If

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "insert into stbcomp_disso(btn,disso_cndn,disso_period,timepoint,min,max,avg,rsd,disso_seq) values('" + ComboBox2.Text + "','" + DataGridView1.Rows(i).Cells(0).Value + "','" + DataGridView1.Rows(i).Cells(1).Value + "','" + DataGridView2.Rows(i).Cells(2).Value + "','" + DataGridView2.Rows(i).Cells(3).Value + "','" + DataGridView2.Rows(i).Cells(4).Value + "','" + DataGridView2.Rows(i).Cells(5).Value + "','" + DataGridView2.Rows(i).Cells(6).Value + "','" + disso_period.ToString + "')"
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
    End Sub
    Private Sub AddImpurities()
        For i As Integer = 0 To DataGridView3.Rows.Count - 2
            Dim imp_period As Integer
            If DataGridView3.Rows(i).Cells(1).Value = "Initial" Then
                imp_period = 0
            Else
                imp_period = Integer.Parse(Regex.Replace(DataGridView3.Rows(i).Cells(2).Value, "[^\d]", ""))
            End If

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "insert into stbcomp_impurity(btn,impurity,imp_cndn,imp_period,imp_result,imp_limit,imp_seq) values('" + ComboBox2.Text + "','" + DataGridView3.Rows(i).Cells(0).Value + "','" + DataGridView3.Rows(i).Cells(1).Value + "','" + DataGridView3.Rows(i).Cells(2).Value + "','" + DataGridView3.Rows(i).Cells(3).Value + "','" + DataGridView3.Rows(i).Cells(4).Value + "','" + imp_period.ToString + "')"
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If TextBox1.Text = "" Then
                ComboBox1.Items.Clear()
                ComboBox2.SelectedIndex = -1
                ComboBox3.SelectedIndex = -1
                TextBox2.Clear()

                TextBox3.Clear()
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
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            Dim qry As String
            qry = "SELECT strength,label FROM productmaster where procode='" + TextBox1.Text + "' and proname='" + ComboBox1.Text + "' and productstatus='Active'"
            cmd = New SqlCommand(qry, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            da.Fill(table)

            TextBox2.Text = table.Rows(0)(0).ToString()
            TextBox3.Text = table.Rows(0)(1).ToString()

            LoadBatchNumbers()
            LoadPackStyle()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadBatchNumbers()
        ComboBox2.Items.Clear()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "SELECT DISTINCT(btn) FROM plnr where proname='" + ComboBox1.Text + "' and strength='" + TextBox2.Text + "'"
        con.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        While dr.Read
            ComboBox2.Items.Add(dr("btn"))
        End While
        dr.Close()
        con.Close()
    End Sub
    Private Sub LoadPackStyle()
        ComboBox3.Items.Clear()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "SELECT DISTINCT(pctyp) FROM plnr where proname='" + ComboBox1.Text + "'"
        con.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        While dr.Read
            ComboBox3.Items.Add(dr("pctyp"))
        End While
        dr.Close()
        con.Close()
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        LoadChargingDate()
        LoadtrstbDetails()
        ' LoadCondition()
        ' LoadPeriod()
        LoadTest()
        ' LoadDissoTimepoints()

    End Sub
    Private Sub LoadChargingDate()
        Try

            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            Dim qry As String
            qry = "SELECT chrgdate FROM plnr where btn='" + ComboBox2.Text + "'"
            cmd = New SqlCommand(qry, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            da.Fill(table)
            If table.Rows(0)(0).ToString = "" Then
                Label1.Text = ""
            Else
                Dim requestdate As Date = Date.ParseExact(table.Rows(0)(0), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label1.Text = requestdate
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadtrstbDetails()
        Try
            DataGridView1.Rows.Clear()

            'Get PDS Details with product name
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds1 As DataSet = New DataSet
            Dim da1 As New SqlDataAdapter()
            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            da1 = New SqlDataAdapter("select [cndn],[period],[test] from trstb where [btn]='" + ComboBox2.Text + "' and (Status='Data Uploaded' or Status='Released') and test<>'Dissolution' group by [cndn],[period],[test] order by cndn ASC", con)
            Dim table1 As New DataTable()
            da1.Fill(table1)

            For i = 0 To table1.Rows.Count - 1
                DataGridView1.Rows.Add(table1.Rows(i)(0).ToString(), table1.Rows(i)(1).ToString(), table1.Rows(i)(2).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadCondition()
        If con.State = ConnectionState.Open Then con.Close()
        Dim reader As SqlDataReader
        Try

            con.Open()
            Dim qry As String
            qry = "SELECT cond from conditions where stb_comp='yes'"
            cmd1 = New SqlCommand(qry, con)
            reader = cmd1.ExecuteReader
            While reader.Read
                Dim Gen_Condition As DataGridViewComboBoxColumn = DataGridView1.Columns(0)
                Gen_Condition.Items.Clear()
                ' Gen_Condition.Items.Add("Initial")
                Gen_Condition.Items.Add(reader("cond"))
                Dim Disso_Condition As DataGridViewComboBoxColumn = DataGridView2.Columns(0)
                Disso_Condition.Items.Clear()
                ' Disso_Condition.Items.Add("Initial")
                Disso_Condition.Items.Add(reader("cond"))
                Dim Imp_Condition As DataGridViewComboBoxColumn = DataGridView3.Columns(2)
                Imp_Condition.Items.Clear()
                ' Imp_Condition.Items.Add("Initial")
                Imp_Condition.Items.Add(reader("cond"))
            End While
            con.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadPeriod()
        If con.State = ConnectionState.Open Then con.Close()
        Dim reader As SqlDataReader

        Try
            con.Open()
            Dim qry As String
            qry = "SELECT sch from plnr group by sch order by sch ASC"
            cmd1 = New SqlCommand(qry, con)
            reader = cmd1.ExecuteReader
            While reader.Read
                Dim Gen_Period As DataGridViewComboBoxColumn = DataGridView1.Columns(1)
                Gen_Period.Items.Clear()
                'Gen_Period.Items.Add("NA")
                Gen_Period.Items.Add(reader("sch"))
                Dim Disso_Period As DataGridViewComboBoxColumn = DataGridView2.Columns(1)
                Disso_Period.Items.Clear()
                ' Disso_Period.Items.Add("NA")
                Disso_Period.Items.Add(reader("sch"))
                Dim Imp_Period As DataGridViewComboBoxColumn = DataGridView3.Columns(3)
                Imp_Period.Items.Clear()
                ' Imp_Period.Items.Add("NA")
                Imp_Period.Items.Add(reader("sch"))
            End While
            con.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Private Sub LoadTest()
        If con.State = ConnectionState.Open Then con.Close()
        Dim reader As SqlDataReader
        Try
            con.Open()
            Dim qry As String
            qry = "SELECT DISTINCT(test) FROM testmaster order by test ASC"
            cmd1 = New SqlCommand(qry, con)
            reader = cmd1.ExecuteReader
            While reader.Read
                Dim Gen_Test As DataGridViewComboBoxColumn = DataGridView1.Columns(2)
                Gen_Test.Items.Add(reader("test"))
            End While
            con.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub LoadDissoTimepoints()
        If con.State = ConnectionState.Open Then con.Close()
        Dim reader As SqlDataReader
        Try
            con.Open()
            Dim qry As String
            qry = "SELECT DISTINCT(timepoint) FROM stbcomp_disso_timepoint order by timepoint ASC"
            cmd1 = New SqlCommand(qry, con)
            reader = cmd1.ExecuteReader
            While reader.Read
                Dim Disso_Timepoints As DataGridViewComboBoxColumn = DataGridView2.Columns(2)
                Disso_Timepoints.Items.Add(reader("timepoint"))
            End While
            con.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub dgv1_rowstyle()
        For i As Integer = 0 To DataGridView1.RowCount - 2
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
    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        Try
            If DataGridView1.SelectedRows.Count > 0 Then
                DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
            Else
                MessageBox.Show("Select 1 atleast one row to delete")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Try
            If DataGridView2.SelectedRows.Count > 0 Then
                DataGridView2.Rows.Remove(DataGridView2.SelectedRows(0))
            Else
                MessageBox.Show("Select 1 atleast one row to delete")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub GunaGradientButton5_Click(sender As Object, e As EventArgs) Handles GunaGradientButton5.Click
        Try
            If DataGridView3.SelectedRows.Count > 0 Then
                DataGridView3.Rows.Remove(DataGridView3.SelectedRows(0))
            Else
                MessageBox.Show("Select 1 atleast one row to delete")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DataGridView2_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView2.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DataGridView3_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView3.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class