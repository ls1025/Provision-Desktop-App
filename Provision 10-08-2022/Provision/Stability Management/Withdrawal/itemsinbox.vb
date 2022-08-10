Imports System.Data.SqlClient
Public Class itemsinbox
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub itemsinbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadplnr()
        panel2hide()
        loadboxstatus()
        Label1.Hide()
    End Sub
    Private Sub loadboxstatus()
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim cmd As New SqlCommand
        cmd.Connection = con

        da = New SqlDataAdapter("Select boxsts from boxmaster where [withbox]= '" + GunaLabel1.Text + "' ", con)
        Dim table As New DataTable()
        da.Fill(table)

        Dim BoxStatus As String = table.Rows(0)(0).ToString

        If BoxStatus = "Empty" Then
            GunaRadioButton1.Checked = True
        ElseIf BoxStatus = "Space Available" Then
            GunaRadioButton2.Checked = True
        ElseIf BoxStatus = "Full" Then
            GunaRadioButton3.Checked = True
        End If
    End Sub
    Private Sub loadplnr()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select [ID],[proname],[strength],[cndn],[btn],[pctyp],[pccnt],[chrgdate],[ptn],[sch],[podate],[totalsampleqty],[availsampleqty] from plnr where withbox='" + GunaLabel1.Text + "' and [availsampleqty]<>0 ", con)
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
        panel2hide()
        Try
            If GunaRadioButton1.Checked = False And GunaRadioButton2.Checked = False And GunaRadioButton3.Checked = False Then
                MsgBox("Select Box Status", vbCritical)

            ElseIf GunaRadioButton1.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd1 As New SqlCommand("update boxmaster set [boxsts]='Empty',[proname]=NULL where [withbox]= '" + GunaLabel1.Text + "'", con)
                con.Open()
                cmd1.ExecuteNonQuery()
                con.Close()



            ElseIf GunaRadioButton2.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd1 As New SqlCommand("update boxmaster set [boxsts]='Space Available' where [withbox]= '" + GunaLabel1.Text + "'", con)
                con.Open()
                cmd1.ExecuteNonQuery()
                con.Close()
            ElseIf GunaRadioButton3.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd1 As New SqlCommand("update boxmaster set [boxsts]='Full' where [withbox]= '" + GunaLabel1.Text + "'", con)
                con.Open()
                cmd1.ExecuteNonQuery()
                con.Close()
            End If
            Dim f1 As box = DirectCast(Me.Owner, box)
            f1.loadData()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub panel2hide()
        Panel2.Hide()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        panel2hide()
    End Sub

    Private Sub GunaRadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton1.CheckedChanged
        panel2hide()
    End Sub

    Private Sub GunaRadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton2.CheckedChanged
        panel2hide()
    End Sub

    Private Sub GunaRadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles GunaRadioButton3.CheckedChanged
        panel2hide()
    End Sub

    Private Sub GunaCircleButton1_Click(sender As Object, e As EventArgs) Handles GunaCircleButton1.Click
        panel2hide()
    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click

        If DataGridView1.SelectedCells.Count > 0 Then
            Label1.Text = DataGridView1.SelectedCells(0).Value
            Panel2.Show()
        Else
            MsgBox("Select atleast one row to issue sample", vbCritical)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Enter Sample Qty to Issue", vbCritical)
            ElseIf TextBox2.Text = "" Then
                MsgBox("Enter Reference TR No.", vbCritical)
            ElseIf Convert.ToDouble(TextBox1.Text) > Convert.ToDouble(DataGridView1.SelectedCells(12).Value) Then
                MsgBox("Issued sample qty should not be greater then available sample qty", vbCritical)
            Else
                Dim toatalsample As Double = DataGridView1.SelectedCells(12).Value
                Dim issuesample As Double = TextBox1.Text

                Dim remainingsample As Double = toatalsample - issuesample

                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("update plnr set [availsampleqty]='" + remainingsample.ToString + "' where [ID]= '" + Label1.Text + "'", con)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd1 As New SqlCommand
                cmd1.Parameters.Clear()
                cmd1.Connection = con
                cmd1.CommandText = "insert into recon(ref_id,sampleqty,reftr,remark,issuedby,issuedon) values('" + Label1.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + homepage.Label1.Text + "',@issuedon)"
                cmd1.Parameters.AddWithValue("@issuedon", SqlDbType.Date).Value = DateTime.Now.Date

                con.Open()
                cmd1.ExecuteNonQuery()
                con.Close()
                loadplnr()

                If DataGridView1.Rows.Count = 0 Then
                    Dim cmd2 As New SqlCommand
                    cmd2.Connection = con
                    cmd2.CommandText = "update boxmaster set boxsts='Empty',proname=NULL where withbox= '" + GunaLabel1.Text + "'"

                    con.Open()
                    cmd2.ExecuteNonQuery()
                    con.Close()
                End If
                Dim f1 As box = DirectCast(Me.Owner, box)
                f1.loadData()
                MsgBox("Updated Successfully", vbInformation)
                panel2hide()


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'MsgBox(e.ColumnIndex)
    End Sub
End Class