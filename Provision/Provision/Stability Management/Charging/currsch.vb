Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp
Imports System.IO
Public Class currsch
    Private Panel1Captured As Boolean
    Private Panel1Grabbed As Point

    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private currentDate As DateTime = DateTime.Today
    Private Sub currsch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadplnr()
        dgv1_rowstyle()

        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

        DataGridView1.CurrentCell = Nothing
    End Sub
    Private Sub DataGridView1_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseMove
        If e.RowIndex >= 0 Then

            If e.ColumnIndex = 9 Then
                DataGridView1.Cursor = Cursors.Hand
            End If
        End If
    End Sub
    Private Sub DataGridView1_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseLeave
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 9 Then
                DataGridView1.Cursor = Cursors.Default
            End If
        End If
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.RowIndex >= 0 Then
            'MsgBox(e.ColumnIndex)

            If e.ColumnIndex = 11 Then


                If DataGridView1.Item(e.ColumnIndex, e.RowIndex).Value.ToString() = "" Then
                    Dim form As New actwithdrawal

                    form.Label4.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
                    form.Owner = Me
                    form.ShowDialog()

                    ' Panel2.Show()
                    ' Dim idn As Integer = DataGridView1.Rows(e.RowIndex).Cells(1).Value
                    ' Label4.Text = idn
                Else
                    ' Panel2.Hide()
                    MsgBox("Already Pulled Out", vbCritical)

                End If
            ElseIf e.ColumnIndex = 0 Then
                'Panel2.Hide()
                Dim form As New detailchrgplnr
                form.Label1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
                form.ShowDialog()
            End If
        End If
    End Sub
    Public Sub loadplnr()
        Dim WithDrawal As Date
        WithDrawal = Date.Parse(Label5.Text)
        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("Select [ID],[proname],[strength],[cndn],[btn],[ptn],[chrgdate],[sch],[totalsampleqty],[availsampleqty],[actpodate],[chrgbox] from plnr where actpodate IS NULL and [podate] = '" + Label5.Text + "' order by [sch] ASC", con)
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
        DataGridView1.CurrentCell = Nothing
        dgv1_rowstyle()
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
    Private Sub DataGridView1_Resize(sender As Object, e As EventArgs) Handles DataGridView1.Resize
        dgv1_rowstyle()
    End Sub

    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs)
        Panel1Captured = True
        Panel1Grabbed = e.Location
    End Sub

    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs) Handles GunaGradientButton4.Click
        exportopdf()
    End Sub
    Private Sub exportopdf()
        Try
            Dim doc As New Document(PageSize.A4.Rotate, 40.0F, 40.0F, 80.0F, 80)
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream("\\192.168.1.200\dqa\12. Stability Planner\Stability_Daily_Withdrawal_Planner.pdf", FileMode.Create))
            'Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream("D:\Stability Planner\Stability Scheduled Planner.pdf", FileMode.Create))
            Dim pHeader As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

            writer.PageEvent = New HeaderFooter

            Dim pdfTable As New PdfPTable(9)
            pdfTable.TotalWidth = 780.0F
            pdfTable.LockedWidth = True
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER
            pdfTable.HeaderRows = 1

            Dim widths As Single() = New Single() {3.0F, 1.3F, 1.5F, 1.8F, 1.3F, 0.8F, 1.0F, 1.0F, 1.2}
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

            pdfcell = New PdfPCell(New Paragraph("Protocol No.", pColumn))
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

            pdfcell = New PdfPCell(New Paragraph("Total Sample Qty", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Available Qty", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Charging Box No.", pColumn))
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

            'Withdrawal Date
            Dim tabel As New PdfPTable(1)
            Dim cell As New PdfPCell(New Paragraph("Withdrawal Date : " + Label6.Text, pHeader))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            tabel.TotalWidth = 780.0F
            tabel.LockedWidth = True
            cell.MinimumHeight = 20
            cell.PaddingLeft = 2.0F

            tabel.AddCell(cell)
            doc.Add(tabel)
            doc.Add(pdfTable)

            doc.Close()
            MsgBox("PDF Exported to \\192.168.1.200\dqa\12. Stability Planner\Stability_Daily_Withdrawal_Planner.pdf", vbInformation)
            Process.Start("\\192.168.1.200\dqa\12. Stability Planner\Stability_Daily_Withdrawal_Planner.pdf")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function GetDataTable()
        Dim datatable As New DataTable("dt")

        Dim datacolumn1 As New DataColumn(DataGridView1.Columns(2).HeaderText.ToString, GetType(String))
        Dim datacolumn2 As New DataColumn(DataGridView1.Columns(3).HeaderText.ToString, GetType(String))
        Dim datacolumn3 As New DataColumn(DataGridView1.Columns(4).HeaderText.ToString, GetType(String))
        Dim datacolumn4 As New DataColumn(DataGridView1.Columns(5).HeaderText.ToString, GetType(String))
        Dim datacolumn5 As New DataColumn(DataGridView1.Columns(6).HeaderText.ToString, GetType(String))
        Dim datacolumn6 As New DataColumn(DataGridView1.Columns(7).HeaderText.ToString, GetType(String))
        Dim datacolumn7 As New DataColumn(DataGridView1.Columns(8).HeaderText.ToString, GetType(String))
        Dim datacolumn8 As New DataColumn(DataGridView1.Columns(9).HeaderText.ToString, GetType(String))
        Dim datacolumn9 As New DataColumn(DataGridView1.Columns(11).HeaderText.ToString, GetType(String))

        datatable.Columns.Add(datacolumn1)
        datatable.Columns.Add(datacolumn2)
        datatable.Columns.Add(datacolumn3)
        datatable.Columns.Add(datacolumn4)
        datatable.Columns.Add(datacolumn5)
        datatable.Columns.Add(datacolumn6)
        datatable.Columns.Add(datacolumn7)
        datatable.Columns.Add(datacolumn8)
        datatable.Columns.Add(datacolumn9)

        Dim row As DataRow
        For i = 0 To DataGridView1.Rows.Count - 1
            row = datatable.NewRow
            row(datacolumn1) = DataGridView1.Rows(i).Cells(2).Value + " " + DataGridView1.Rows(i).Cells(3).Value
            row(datacolumn2) = DataGridView1.Rows(i).Cells(4).Value
            row(datacolumn3) = DataGridView1.Rows(i).Cells(5).Value

            row(datacolumn4) = DataGridView1.Rows(i).Cells(6).Value

            If DataGridView1.Rows(i).Cells(7).Value.ToString = "" Then
                row(datacolumn5) = DataGridView1.Rows(i).Cells(7).Value
            Else
                row(datacolumn5) = (CType(DataGridView1.Rows(i).Cells(7).Value, DateTime)).ToString("dd/MM/yyyy")
            End If

            row(datacolumn6) = DataGridView1.Rows(i).Cells(8).Value

            row(datacolumn7) = DataGridView1.Rows(i).Cells(9).Value
            row(datacolumn8) = DataGridView1.Rows(i).Cells(10).Value

            row(datacolumn9) = DataGridView1.Rows(i).Cells(12).Value

            datatable.Rows.Add(row)
        Next
        datatable.AcceptChanges()
        Return datatable
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'MsgBox(e.ColumnIndex)
    End Sub
End Class

