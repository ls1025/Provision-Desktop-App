Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp
Imports System.IO
Public Class boxinchamber
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub boxinchamber_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadplnr()
        loadproname()

        LoadTotalBoxsinChamber()
    End Sub
    Private Sub LoadTotalBoxsinChamber()
        Dim a As String
        If con.State = ConnectionState.Open Then con.Close()
        cmd.Connection = con
        con.Open()
        cmd.CommandText = "select count(DISTINCT(chrgbox)) from plnr where cndn='" + GunaLabel1.Text + "' and chrgbox IS NOT NULL"
        a = cmd.ExecuteScalar().ToString()
        con.Close()
        GunaLabel3.Text = a
    End Sub

    Private Sub loadplnr()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select [ID],[proname],[strength],[cndn],[btn],[chrgdate],[sch],[podate],[totalsampleqty],[availsampleqty],[chrgbox] from plnr where cndn='" + GunaLabel1.Text + "' and [chrgbox] IS NOT NULL order by [proname] ASC", con)
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
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs)
        dgv1_rowstyle()
    End Sub
    Private Sub loadproname()
        Try
            ComboBox1.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(proname) from plnr where cndn='" + GunaLabel1.Text + "' and [chrgbox] IS NOT NULL order by [proname] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("proname"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub loadbatch()
        Try
            ComboBox2.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(btn) from plnr where proname='" + ComboBox1.Text + "' and cndn='" + GunaLabel1.Text + "' and [chrgbox] IS NOT NULL"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr("btn"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        loadbatch()
        ' Me.BeginInvoke(New Action(Sub() ComboBox1.Select(0, 0)))
        Try
            If ComboBox2.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [ID],[proname],[strength],[cndn],[btn],[chrgdate],[sch],[podate],[totalsampleqty],[availsampleqty],[chrgbox] from plnr where cndn='" + GunaLabel1.Text + "' and [chrgbox] IS NOT NULL and [proname] = '" + ComboBox1.Text + "' order by [proname] ASC")
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
            ElseIf ComboBox2.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [ID],[proname],[strength],[cndn],[btn],[chrgdate],[sch],[podate],[totalsampleqty],[availsampleqty],[chrgbox] from plnr where cndn='" + GunaLabel1.Text + "' and [proname] = '" + ComboBox1.Text + "' and [btn]='" + ComboBox2.Text + "' order by [proname] ASC")
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
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboBox2_TextChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            If ComboBox1.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [ID],[proname],[strength],[cndn],[btn],[chrgdate],[sch],[podate],[totalsampleqty],[availsampleqty],[chrgbox] from plnr where cndn='" + GunaLabel1.Text + "' and [btn] = '" + ComboBox2.Text + "' order by [proname] ASC")
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
            ElseIf ComboBox1.Text <> "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("Select [ID],[proname],[strength],[cndn],[btn],[chrgdate],[sch],[podate],[totalsampleqty],[availsampleqty],[chrgbox] from plnr where cndn='" + GunaLabel1.Text + "' and [proname] = '" + ComboBox1.Text + "' and [btn]='" + ComboBox2.Text + "' order by [proname] ASC")
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
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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

    Private Sub dgvMyName_ToolTip(sender As Object, e As DataGridViewCellToolTipTextNeededEventArgs) Handles DataGridView1.CellToolTipTextNeeded

    End Sub

    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs) Handles GunaGradientButton4.Click
        exportopdf()
    End Sub
    Private Sub exportopdf()
        Try

            Dim doc As New Document(PageSize.A4.Rotate, 40.0F, 40.0F, 80.0F, 80)
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream("\\192.168.1.200\dqa\12. Stability Planner\Stability_Samples_In_Chamber.pdf", FileMode.Create))
            Dim pHeader As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

            writer.PageEvent = New HeaderFooter

            Dim pdfTable As New PdfPTable(8)
            pdfTable.TotalWidth = 780.0F
            pdfTable.LockedWidth = True
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER
            pdfTable.HeaderRows = 1

            Dim widths As Single() = New Single() {3.0F, 1.3F, 1.3F, 1.5F, 1.3F, 1.3F, 1.5F, 1.2F}
            pdfTable.SetWidths(widths)

            Dim pdfcell As PdfPCell = Nothing
            doc.Open()
            pdfcell = New PdfPCell(New Paragraph("Product Name", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Condition", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Batch Number", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Charging Date", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Period", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Withdrawal Date", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Total Sample Qty", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Available Qty.", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            Dim dt As DataTable = GetDataTable()

            For i = 0 To dt.Rows.Count - 1
                For j As Integer = 0 To dt.Columns.Count - 1
                    pdfcell = New PdfPCell(New Paragraph(dt.Rows(i)(j).ToString, pRow))
                    pdfcell.MinimumHeight = 18
                    pdfcell.PaddingLeft = 5.0F
                    pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfTable.AddCell(pdfcell)
                Next
            Next

            'Header
            Dim tabel As New PdfPTable(1)
            Dim cell As New PdfPCell(New Paragraph("Sample Details in " + GunaLabel1.Text, pHeader))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            tabel.TotalWidth = 780.0F
            tabel.LockedWidth = True
            cell.MinimumHeight = 20
            cell.PaddingLeft = 2.0F

            tabel.AddCell(cell)
            doc.Add(tabel)
            doc.Add(pdfTable)
            doc.Close()

            MsgBox("PDF Exported to \\192.168.1.200\dqa\12. Stability Planner\Stability_Samples_In_Chamber.pdf", vbInformation)
            Process.Start("\\192.168.1.200\dqa\12. Stability Planner\Stability_Samples_In_Chamber.pdf")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'MessageBox.Show("Failed to save !!!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function GetDataTable()
        Dim datatable As New DataTable("dt")

        Dim datacolumn1 As New DataColumn(DataGridView1.Columns(0).HeaderText.ToString, GetType(String))
        Dim datacolumn2 As New DataColumn(DataGridView1.Columns(1).HeaderText.ToString, GetType(String))
        Dim datacolumn3 As New DataColumn(DataGridView1.Columns(2).HeaderText.ToString, GetType(String))
        Dim datacolumn4 As New DataColumn(DataGridView1.Columns(3).HeaderText.ToString, GetType(String))
        Dim datacolumn5 As New DataColumn(DataGridView1.Columns(4).HeaderText.ToString, GetType(String))
        Dim datacolumn6 As New DataColumn(DataGridView1.Columns(5).HeaderText.ToString, GetType(String))
        Dim datacolumn7 As New DataColumn(DataGridView1.Columns(6).HeaderText.ToString, GetType(String))
        Dim datacolumn8 As New DataColumn(DataGridView1.Columns(7).HeaderText.ToString, GetType(String))


        datatable.Columns.Add(datacolumn1)
        datatable.Columns.Add(datacolumn2)
        datatable.Columns.Add(datacolumn3)
        datatable.Columns.Add(datacolumn4)
        datatable.Columns.Add(datacolumn5)
        datatable.Columns.Add(datacolumn6)
        datatable.Columns.Add(datacolumn7)
        datatable.Columns.Add(datacolumn8)


        Dim row As DataRow
        For i = 0 To DataGridView1.Rows.Count - 1
            row = datatable.NewRow
            row(datacolumn1) = DataGridView1.Rows(i).Cells(1).Value + " " + DataGridView1.Rows(i).Cells(2).Value
            row(datacolumn2) = DataGridView1.Rows(i).Cells(3).Value
            row(datacolumn3) = DataGridView1.Rows(i).Cells(4).Value

            'Charging Date
            If DataGridView1.Rows(i).Cells(5).Value.ToString = "" Then
                row(datacolumn4) = DataGridView1.Rows(i).Cells(5).Value
            Else
                row(datacolumn4) = (CType(DataGridView1.Rows(i).Cells(5).Value, DateTime)).ToString("dd MMM yyyy")
            End If

            row(datacolumn5) = DataGridView1.Rows(i).Cells(6).Value

            'Withdrawal Date
            If DataGridView1.Rows(i).Cells(7).Value.ToString = "" Then
                row(datacolumn6) = DataGridView1.Rows(i).Cells(7).Value
            Else
                row(datacolumn6) = (CType(DataGridView1.Rows(i).Cells(7).Value, DateTime)).ToString("dd MMM yyyy")
            End If

            row(datacolumn7) = DataGridView1.Rows(i).Cells(8).Value


            row(datacolumn8) = DataGridView1.Rows(i).Cells(9).Value
            datatable.Rows.Add(row)
        Next
        datatable.AcceptChanges()
        Return datatable
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' MsgBox(e.ColumnIndex)
    End Sub
End Class
