Imports System.Data.SqlClient
Public Class viewreconciliation
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()


    Private Sub viewreconciliation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        loadwithdrawalplanner()
        GunaPanel2.Hide()
        loadreconcilation()
        calculate()
    End Sub
    Private Sub loadwithdrawalplanner()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con

            da = New SqlDataAdapter("Select * from plnr where [ID]= '" + Label1.Text + "' ", con)
            Dim table As New DataTable()
            da.Fill(table)
            'proname
            Label2.Text = table.Rows(0)(1).ToString + " " + table.Rows(0)(2).ToString
            'condition
            Label3.Text = table.Rows(0)(3).ToString
            'btn no
            Label4.Text = table.Rows(0)(4).ToString
            'packtype
            Label5.Text = table.Rows(0)(5).ToString
            'packcount
            Label6.Text = table.Rows(0)(6).ToString
            'charging box no
            'Label7.Text = table.Rows(0)(6).ToString
            'charging date
            If table.Rows(0)(8).ToString = "" Then
                Label8.Text = ""
            Else
                Dim chrgdate As Date = Date.ParseExact(table.Rows(0)(8), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label8.Text = chrgdate
            End If
            'protocl no
            Label9.Text = table.Rows(0)(9).ToString
            'period
            Label10.Text = table.Rows(0)(10).ToString

            'podate
            '  If table.Rows(0)(10).ToString = "" Then
            'Label11.Text = ""
            ' Else
            'Dim withdate As Date = Date.ParseExact(table.Rows(0)(10), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            'Label11.Text = withdate
            ' End If

            'Actual podate
            ' If table.Rows(0)(11).ToString = "" Then
            'Label12.Text = ""
            ' Else
            'Dim withdate As Date = Date.ParseExact(table.Rows(0)(11), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            ' Label12.Text = withdate
            '  End If
            'withrawal box
            ' Label15.Text = table.Rows(0)(12).ToString
            'remark
            Label16.Text = table.Rows(0)(14).ToString

            'sample qty
            GunaLabel9.Text = table.Rows(0)(17).ToString
            'added by
            ' Label13.Text = table.Rows(0)(16).ToString
            'added on
            ' If table.Rows(0)(17).ToString = "" Then
            'Label14.Text = ""
            ' Else
            'Dim withdate As Date = Date.ParseExact(table.Rows(0)(17), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            'abel14.Text = withdate
            ' End If
            'withdrawal by
            ' Label17.Text = table.Rows(0)(18).ToString
            'withdrawal on
            ' If table.Rows(0)(19).ToString = "" Then
            'Label18.Text = ""
            '  Else
            'Dim withdate As Date = Date.ParseExact(table.Rows(0)(19), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            'Label18.Text = withdate
            '  End If
            'updated by
            ' Label19.Text = table.Rows(0)(20).ToString
            'updated on
            ' If table.Rows(0)(21).ToString = "" Then
            'Label20.Text = ""
            '  Else
            'Dim withon As Date = Date.ParseExact(table.Rows(0)(21), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            'Label20.Text = withon
            '  End If



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
            da = New SqlDataAdapter("Select [ID],[sampleqty],[reftr],[issuedby],[issuedon],[remark] from recon where [ref_id]='" + Label1.Text + "' ", con)
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
                Dim avialsample As Double = GunaLabel9.Text
                Dim issuedsample As Double
                Dim totalsample As Double
                For index As Integer = 0 To DataGridView1.RowCount - 1
                    issuedsample += Val(DataGridView1.Rows(index).Cells(1).Value)

                    'if you have the other column to get the result you  could add a new one like these above (just change Cells(2) to the one you added)
                Next
                Label21.Text = issuedsample
                totalsample = avialsample + issuedsample
                GunaLabel11.Text = totalsample
            Else
                Label21.Text = "Not Yet Issued"
                GunaLabel11.Text = "NA"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class