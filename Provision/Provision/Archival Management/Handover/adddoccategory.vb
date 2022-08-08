
Imports System.Data.SqlClient
Public Class adddoccategory
    Private Sub adddcotype_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadDocumentType()
        LoadDocumentCategory()
    End Sub
    Private Sub LoadDocumentType()
        Try
            ComboBox1.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(doctype) from archival_doctype order by [doctype] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("doctype"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadDocumentCategory()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim da As New SqlDataAdapter()
            Dim dt As New DataTable()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select [id],[doctype],[catogery],[addedby],[addedon] from archival_catogery order by [doctype] ASC", con)
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)

            dgv1_rowstyle()

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MsgBox("Select Document Type", vbCritical)
        ElseIf TextBox1.Text = "" Then
            MsgBox("Enter Document Category", vbCritical)
        Else
            Dim samedoctype As String
            If con.State = ConnectionState.Open Then con.Close()
            cmd.Connection = con
            con.Open()
            cmd.CommandText = "select count([catogery]) from archival_catogery where doctype='" + ComboBox1.Text + "' and catogery='" + TextBox1.Text + "'"
            samedoctype = cmd.ExecuteScalar().ToString()
            con.Close()

            If samedoctype > 0 Then
                MsgBox("Document Category is alreday Exist", vbCritical)
            Else
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd3 As New SqlCommand
                cmd3.Connection = con
                cmd3.CommandText = "insert into archival_catogery(doctype,catogery,addedby,addedon) values('" + ComboBox1.Text + "','" + TextBox1.Text + "','" + homepage.Label1.Text + "',@addedon)"
                cmd3.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd3.ExecuteNonQuery()
                con.Close()
                LoadDocumentCategory()
                MsgBox("Document Category Added", vbInformation)
                ComboBox1.SelectedIndex = -1
                TextBox1.Clear()
            End If
        End If
    End Sub
End Class
