Imports System.Data.SqlClient
Public Class viewrldrecon
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()


    Private Sub viewrldrecon_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadRLDDetails()
        GunaPanel2.Hide()
        loadreconcilation()
        calculate()
    End Sub
    Private Sub LoadRLDDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con

            da = New SqlDataAdapter("Select * from rld_master where id= '" + Label1.Text + "' ", con)
            Dim table As New DataTable()
            da.Fill(table)
            'proname
            Label2.Text = table.Rows(0)(1).ToString + " " + table.Rows(0)(2).ToString
            'brand
            Label3.Text = table.Rows(0)(3).ToString
            'cntry
            Label4.Text = table.Rows(0)(4).ToString
            'manufacturer
            Label5.Text = table.Rows(0)(5).ToString
            'btn
            Label6.Text = table.Rows(0)(6).ToString

            'pack style
            Label8.Text = table.Rows(0)(7).ToString
            'reciept date
            If table.Rows(0)(9).ToString = "" Then
                Label9.Text = ""
            Else
                Dim recdate As Date = Date.ParseExact(table.Rows(0)(9), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label9.Text = recdate
            End If
            'exp date
            Label10.Text = table.Rows(0)(10).ToString

            'recived qty
            Label12.Text = table.Rows(0)(11).ToString

            'recievd format
            Label11.Text = table.Rows(0)(12).ToString

            'balanace qty
            Label14.Text = table.Rows(0)(13).ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub loadreconcilation()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select [id],[sampleqty],[test],[remark],[issuedto],[issuedby],[issuedon] from rld_recon where [ref_id]='" + Label1.Text + "' order by issuedon DESC", con)
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
    Private Sub calculate()
        Try
            If DataGridView1.RowCount > 0 Then
                Dim avialsample As Double = Label12.Text
                Dim issuedsample As Double
                '  Dim totalsample As Double
                For index As Integer = 0 To DataGridView1.RowCount - 1
                    issuedsample += Val(DataGridView1.Rows(index).Cells(1).Value)

                    'if you have the other column to get the result you  could add a new one like these above (just change Cells(2) to the one you added)
                Next
                Label13.Text = issuedsample
                ' totalsample = avialsample + issuedsample
                'Label14.Text = totalsample
            Else
                Label13.Text = "Not Yet Issued"
                Label14.Text = "NA"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class