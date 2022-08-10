Imports System.Data.SqlClient
Public Class issuedocument
    Dim cmd1 As New SqlCommand
    Dim cmd2 As New SqlCommand
    Private Sub issuedocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

    End Sub

    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs)
        If DataGridView1.SelectedRows.Count > 0 Then

            DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
        Else
            MessageBox.Show("Select 1 atleast one row to delete")
        End If
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
    Private Sub TextBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Label1.Text = "" Then
                MsgBox("Select Document Type", vbCritical)
            ElseIf Label6.Text = "." Or Label6.Text = "" Then
                MsgBox("Authenticate for issuing user name.", vbCritical)
            Else
                If con.State = ConnectionState.Open Then con.Close()
                Dim qry As String
                qry = "select COUNT(docname) from archival_issuance where ref_id='" + Label5.Text + "' and status='Document Issued'"
                cmd1 = New SqlCommand(qry, con)
                con.Open()
                Dim SameProductCount As Integer
                SameProductCount = cmd1.ExecuteScalar()
                If SameProductCount = 0 Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd3 As New SqlCommand
                    cmd3.Connection = con
                    cmd3.CommandText = "insert into archival_issuance(ref_id,doctype,docname,docno,location,issuedby,issuedto,issueddate,remark,status) values('" + Label5.Text + "','" + Label1.Text + "','" + aLabel2.Text + "','" + Label3.Text + "','" + Label4.Text + "','" + homepage.Label1.Text + "','" + Label6.Text + "',@issueddate,'" + TextBox2.Text + "','Document Issued')"
                    cmd3.Parameters.AddWithValue("@issueddate", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd3.ExecuteNonQuery()
                    con.Close()

                    MsgBox("Document Issued Successfully", vbInformation)
                    Dim f1 As viewdocissuance = DirectCast(Me.Owner, viewdocissuance)
                    f1.LoadIssuanceDetails()
                    Me.Close()
                Else
                    MsgBox("This Document is Already Issued", vbCritical)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New esignissuance
        form.Owner = Me
        form.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If DataGridView1.SelectedCells.Count > 0 Then
            Label5.Text = DataGridView1.SelectedCells(0).Value
            Label1.Text = DataGridView1.SelectedCells(1).Value
            aLabel2.Text = DataGridView1.SelectedCells(2).Value
            Label3.Text = DataGridView1.SelectedCells(3).Value
            Label4.Text = DataGridView1.SelectedCells(4).Value

        End If

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
            Dim cmd As New SqlCommand("Select id,doctype,docname,docno,location from archival_master where ([docname] like '%" & ValueTosearch & "%' or [location] like '%" & ValueTosearch & "%' or [docno] like '%" & ValueTosearch & "%' or [arcno] like '%" & ValueTosearch & "%') order by docname ASC")
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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class