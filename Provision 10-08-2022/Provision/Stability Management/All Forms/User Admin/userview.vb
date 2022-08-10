Imports System.Data.OleDb
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp
Imports System.IO
Public Class userview
    Dim da As New OleDbDataAdapter()
    Dim dt As New DataTable()
    Private Sub userview_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadUserDetails()

        dgv1_rowstyle()
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel2, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub

    Public Sub LoadUserDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New OleDbCommand
            cmd.Connection = con
            da = New OleDbDataAdapter("Select [ID],[fullname],[username],[type],[status] from users order by [fullname] ASC", con)
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
            Dim cmd As New OleDbCommand("Select [ID],[fullname],[username],[type],[status] from users  where ([fullname] like '%" & ValueTosearch & "%' or [username] like '%" & ValueTosearch & "%') order by [fullname] ASC")
            cmd.Connection = con
            Dim adapter1 As New OleDbDataAdapter(cmd)
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
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New adduser
        form.Owner = Me
        form.ShowDialog()
    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            Dim form As New updateuser
            form.Label1.Text = DataGridView1.SelectedCells(0).Value
            form.TextBox1.Text = DataGridView1.SelectedCells(1).Value
            form.TextBox2.Text = DataGridView1.SelectedCells(2).Value
            form.ComboBox1.Text = DataGridView1.SelectedCells(3).Value
            If DataGridView1.SelectedCells(4).Value = "Active" Or DataGridView1.SelectedCells(4).Value = "Renew" Then
                form.RadioButton1.Checked = True
            Else
                form.RadioButton2.Checked = True
            End If
            form.Owner = Me
            form.ShowDialog()
        Else
            MsgBox("Select Row to Update User", vbExclamation)
        End If
    End Sub

    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            Dim result As Integer = MessageBox.Show("Are you to Rest Password for " + DataGridView1.SelectedCells(1).Value, "Confirmation before Update", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.Yes Then
                If con.State = ConnectionState.Open Then con.Close()
                cmd.Connection = con
                con.Open()
                cmd.CommandText = "update users set [password]='" + DataGridView1.SelectedCells(2).Value + "',[status]='Renew' where ID=" & DataGridView1.SelectedCells(0).Value & ""
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Password Reset Successfully", vbInformation)
            End If
        Else
                MsgBox("Select Row to Reset Password", vbExclamation)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' MsgBox(e.ColumnIndex)
    End Sub
End Class

