Imports System.Data
Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp
Imports System.IO
Public Class runbackup
    Dim dt As New DataTable()
    Dim ds As DataSet = New DataSet
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ExportDevelopmentLog_Part1()

        ExportRoutineLog_Part1()

        ExportStabilityLog_Part1()

        ExportATRIssuanceLog()

        'SQLBackup()
        MsgBox("Data Exported Successfully", vbInformation)
        Me.Close()
    End Sub

    Dim table As New DataTable()
    Public Sub ExportDevelopmentLog_Part1()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim da As New SqlDataAdapter()

            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select [ID],[productname],[strength],[trno],[btn],[sampleqty],[test],[requestedby],[requestdate],[trprintby],[trprintdate],[releasedby],[releaseddate],[Status] from trdev order by trno ASC", con)
            da.Fill(table)

            Dim doc As New Document(PageSize.A4.Rotate, 0.5F, 20.0F, 50.0F, 50)
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream("\\192.168.1.200\it\Provision Backup\Development_Intimation_Log_" + Date.Today.ToString("ddMMyyyy") + ".pdf", FileMode.Create))
            Dim pHeader As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

            writer.PageEvent = New HeaderFooterDev

            Dim pdfTable As New PdfPTable(14)
            pdfTable.TotalWidth = 780.0F
            pdfTable.LockedWidth = True
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER
            pdfTable.HeaderRows = 1

            Dim widths As Single() = New Single() {0.7F, 2.5F, 0.0F, 1.2F, 1.1F, 1.0F, 1.0F, 1.3F, 0.0F, 1.0F, 0.0F, 1.0F, 0.0F, 1.0F}
            pdfTable.SetWidths(widths)

            Dim pdfcell As PdfPCell = Nothing
            doc.Open()

            pdfcell = New PdfPCell(New Paragraph("ID", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Product Name", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Strength", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("TR No", pColumn))
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

            pdfcell = New PdfPCell(New Paragraph("Sample Qty", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Test Name", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Sample Send by FRD", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("FRD Date", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Sample Received by ARD", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("ARD Date", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Data Released by DQA", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("DQA Date", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Status", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            Dim dt As DataTable = GetIntimationDevelopment_Log1()

            For i = 0 To dt.Rows.Count - 1
                For j As Integer = 0 To dt.Columns.Count - 1
                    pdfcell = New PdfPCell(New Paragraph(dt.Rows(i)(j).ToString, pRow))
                    pdfcell.MinimumHeight = 18
                    pdfcell.PaddingLeft = 5.0F
                    pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfTable.AddCell(pdfcell)
                Next
            Next

            doc.Add(pdfTable)

            doc.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function GetIntimationDevelopment_Log1()
        Dim datatable As New DataTable("dt")

        Dim datacolumn1 As New DataColumn(table.Columns(0).ToString, GetType(String))
        Dim datacolumn2 As New DataColumn(table.Columns(1).ToString, GetType(String))
        Dim datacolumn3 As New DataColumn(table.Columns(2).ToString, GetType(String))
        Dim datacolumn4 As New DataColumn(table.Columns(3).ToString, GetType(String))
        Dim datacolumn5 As New DataColumn(table.Columns(4).ToString, GetType(String))
        Dim datacolumn6 As New DataColumn(table.Columns(5).ToString, GetType(String))
        Dim datacolumn7 As New DataColumn(table.Columns(6).ToString, GetType(String))
        Dim datacolumn8 As New DataColumn(table.Columns(7).ToString, GetType(String))
        Dim datacolumn9 As New DataColumn(table.Columns(8).ToString, GetType(String))
        Dim datacolumn10 As New DataColumn(table.Columns(9).ToString, GetType(String))
        Dim datacolumn11 As New DataColumn(table.Columns(10).ToString, GetType(String))
        Dim datacolumn12 As New DataColumn(table.Columns(11).ToString, GetType(String))
        Dim datacolumn13 As New DataColumn(table.Columns(12).ToString, GetType(String))
        Dim datacolumn14 As New DataColumn(table.Columns(13).ToString, GetType(String))

        datatable.Columns.Add(datacolumn1)
        datatable.Columns.Add(datacolumn2)
        datatable.Columns.Add(datacolumn3)
        datatable.Columns.Add(datacolumn4)
        datatable.Columns.Add(datacolumn5)
        datatable.Columns.Add(datacolumn6)
        datatable.Columns.Add(datacolumn7)
        datatable.Columns.Add(datacolumn8)
        datatable.Columns.Add(datacolumn9)
        datatable.Columns.Add(datacolumn10)
        datatable.Columns.Add(datacolumn11)
        datatable.Columns.Add(datacolumn12)
        datatable.Columns.Add(datacolumn13)
        datatable.Columns.Add(datacolumn14)

        Dim row As DataRow
        For i = 0 To table.Rows.Count - 1
            row = datatable.NewRow
            row(datacolumn1) = table.Rows(i)(0)
            row(datacolumn2) = table.Rows(i)(1) + " " + table.Rows(i)(2)
            ' row(datacolumn3) = table.Rows(i)(2)
            row(datacolumn4) = table.Rows(i)(3)
            row(datacolumn5) = table.Rows(i)(4)
            row(datacolumn6) = table.Rows(i)(5)
            row(datacolumn7) = table.Rows(i)(6)

            'Requested by with Date
            row(datacolumn8) = table.Rows(i)(7) + Environment.NewLine + (CType(table.Rows(i)(8), DateTime)).ToString("dd/MM/yyyy")

            'TR Printed By with Date
            If table.Rows(i)(9).ToString = "" Then
                row(datacolumn10) = table.Rows(i)(9)
            Else
                row(datacolumn10) = table.Rows(i)(9) + Environment.NewLine + (CType(table.Rows(i)(10), DateTime)).ToString("dd/MM/yyyy")
            End If

            'Data Released By with Date
            If table.Rows(i)(11).ToString = "" Then
                row(datacolumn12) = table.Rows(i)(11)
            Else
                row(datacolumn12) = table.Rows(i)(11) + Environment.NewLine + (CType(table.Rows(i)(12), DateTime)).ToString("dd/MM/yyyy")
            End If

            row(datacolumn14) = table.Rows(i)(13)

            datatable.Rows.Add(row)
        Next
        datatable.AcceptChanges()
        Return datatable
    End Function
    Class HeaderFooterDev
        Inherits PdfPageEventHelper
        Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)
            Dim HeaderFont As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font1 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font2 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pdfCell As PdfPCell = Nothing
            Dim pdfHeader As New PdfPTable(1)
            pdfHeader.TotalWidth = document.PageSize.Width
            pdfHeader.DefaultCell.Border = 0

            pdfCell = New PdfPCell(New Paragraph("V-Ensure Pharma Technologies Pvt Ltd", HeaderFont))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.Border = 0
            pdfHeader.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("A-63, Kopar Khairane, Navi Mumbai", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.Border = 0
            pdfHeader.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("Development Intimation Log", HeaderFont))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.Border = 0
            pdfHeader.AddCell(pdfCell)
            pdfHeader.WriteSelectedRows(0, -1, 0, document.GetTop(document.TopMargin) + 100, writer.DirectContent)

            Dim p1 As New PdfPTable(1)
            p1.TotalWidth = document.PageSize.Width
            p1.DefaultCell.Border = 0

            pdfCell = New PdfPCell(New Paragraph("Page: " & document.PageNumber, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            p1.AddCell(pdfCell)
            p1.WriteSelectedRows(0, -1, document.LeftMargin - 100, document.GetTop(document.TopMargin) + 70, writer.DirectContent)

        End Sub
    End Class
    Dim table1 As New DataTable()
    Public Sub ExportRoutineLog_Part1()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim da As New SqlDataAdapter()

            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select [ID],[productname],[strength],[trno],[btn],[sampleqty],[test],[requestedby],[requestdate],[trprintby],[trprintdate],[releasedby],[releaseddate],[Status] from trrot order by trno ASC", con)
            da.Fill(table1)

            Dim doc As New Document(PageSize.A4.Rotate, 0.5F, 20.0F, 50.0F, 50)
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream("\\192.168.1.200\it\Provision Backup\Routine_Intimation_Log_" + Date.Today.ToString("ddMMyyyy") + ".pdf", FileMode.Create))
            Dim pHeader As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

            writer.PageEvent = New HeaderFooterRot

            Dim pdfTable As New PdfPTable(14)
            pdfTable.TotalWidth = 780.0F
            pdfTable.LockedWidth = True
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER
            pdfTable.HeaderRows = 1

            Dim widths As Single() = New Single() {0.7F, 2.5F, 0.0F, 1.2F, 1.1F, 1.0F, 1.0F, 1.3F, 0.0F, 1.0F, 0.0F, 1.0F, 0.0F, 1.0F}
            pdfTable.SetWidths(widths)

            Dim pdfcell As PdfPCell = Nothing
            doc.Open()

            pdfcell = New PdfPCell(New Paragraph("ID", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Product Name", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Strength", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("TR No", pColumn))
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

            pdfcell = New PdfPCell(New Paragraph("Sample Qty", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Test Name", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Sample Send by FRD", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("FRD Date", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Sample Received by ARD", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("ARD Date", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Data Released by DQA", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("DQA Date", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Status", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            Dim dt As DataTable = GetIntimationRoutine_Log1()

            For i = 0 To dt.Rows.Count - 1
                For j As Integer = 0 To dt.Columns.Count - 1
                    pdfcell = New PdfPCell(New Paragraph(dt.Rows(i)(j).ToString, pRow))
                    pdfcell.MinimumHeight = 18
                    pdfcell.PaddingLeft = 5.0F
                    pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfTable.AddCell(pdfcell)
                Next
            Next

            doc.Add(pdfTable)

            doc.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function GetIntimationRoutine_Log1()
        Dim datatable As New DataTable("dt")

        Dim datacolumn1 As New DataColumn(table1.Columns(0).ToString, GetType(String))
        Dim datacolumn2 As New DataColumn(table1.Columns(1).ToString, GetType(String))
        Dim datacolumn3 As New DataColumn(table1.Columns(2).ToString, GetType(String))
        Dim datacolumn4 As New DataColumn(table1.Columns(3).ToString, GetType(String))
        Dim datacolumn5 As New DataColumn(table1.Columns(4).ToString, GetType(String))
        Dim datacolumn6 As New DataColumn(table1.Columns(5).ToString, GetType(String))
        Dim datacolumn7 As New DataColumn(table1.Columns(6).ToString, GetType(String))
        Dim datacolumn8 As New DataColumn(table1.Columns(7).ToString, GetType(String))
        Dim datacolumn9 As New DataColumn(table1.Columns(8).ToString, GetType(String))
        Dim datacolumn10 As New DataColumn(table1.Columns(9).ToString, GetType(String))
        Dim datacolumn11 As New DataColumn(table1.Columns(10).ToString, GetType(String))
        Dim datacolumn12 As New DataColumn(table1.Columns(11).ToString, GetType(String))
        Dim datacolumn13 As New DataColumn(table1.Columns(12).ToString, GetType(String))
        Dim datacolumn14 As New DataColumn(table1.Columns(13).ToString, GetType(String))

        datatable.Columns.Add(datacolumn1)
        datatable.Columns.Add(datacolumn2)
        datatable.Columns.Add(datacolumn3)
        datatable.Columns.Add(datacolumn4)
        datatable.Columns.Add(datacolumn5)
        datatable.Columns.Add(datacolumn6)
        datatable.Columns.Add(datacolumn7)
        datatable.Columns.Add(datacolumn8)
        datatable.Columns.Add(datacolumn9)
        datatable.Columns.Add(datacolumn10)
        datatable.Columns.Add(datacolumn11)
        datatable.Columns.Add(datacolumn12)
        datatable.Columns.Add(datacolumn13)
        datatable.Columns.Add(datacolumn14)

        Dim row As DataRow
        For i = 0 To table1.Rows.Count - 1
            row = datatable.NewRow
            row(datacolumn1) = table1.Rows(i)(0)
            row(datacolumn2) = table1.Rows(i)(1) + " " + table1.Rows(i)(2)
            ' row(datacolumn3) = table.Rows(i)(2)
            row(datacolumn4) = table1.Rows(i)(3)
            row(datacolumn5) = table1.Rows(i)(4)
            row(datacolumn6) = table1.Rows(i)(5)
            row(datacolumn7) = table1.Rows(i)(6)

            'Requested by with Date
            row(datacolumn8) = table1.Rows(i)(7) + Environment.NewLine + (CType(table1.Rows(i)(8), DateTime)).ToString("dd/MM/yyyy")

            'TR Printed By with Date
            If table1.Rows(i)(9).ToString = "" Then
                row(datacolumn10) = table1.Rows(i)(9)
            Else
                row(datacolumn10) = table1.Rows(i)(9) + Environment.NewLine + (CType(table1.Rows(i)(10), DateTime)).ToString("dd/MM/yyyy")
            End If

            'Data Released By with Date
            If table1.Rows(i)(11).ToString = "" Then
                row(datacolumn12) = table1.Rows(i)(11)
            Else
                row(datacolumn12) = table1.Rows(i)(11) + Environment.NewLine + (CType(table1.Rows(i)(12), DateTime)).ToString("dd/MM/yyyy")
            End If

            row(datacolumn14) = table1.Rows(i)(13)

            datatable.Rows.Add(row)
        Next
        datatable.AcceptChanges()
        Return datatable
    End Function
    Class HeaderFooterRot
        Inherits PdfPageEventHelper
        Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)
            Dim HeaderFont As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font1 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font2 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pdfCell As PdfPCell = Nothing
            Dim pdfHeader As New PdfPTable(1)
            pdfHeader.TotalWidth = document.PageSize.Width
            pdfHeader.DefaultCell.Border = 0

            pdfCell = New PdfPCell(New Paragraph("V-Ensure Pharma Technologies Pvt Ltd", HeaderFont))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.Border = 0
            pdfHeader.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("A-63, Kopar Khairane, Navi Mumbai", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.Border = 0
            pdfHeader.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("Routine Intimation Log", HeaderFont))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.Border = 0
            pdfHeader.AddCell(pdfCell)
            pdfHeader.WriteSelectedRows(0, -1, 0, document.GetTop(document.TopMargin) + 100, writer.DirectContent)

            Dim p1 As New PdfPTable(1)
            p1.TotalWidth = document.PageSize.Width
            p1.DefaultCell.Border = 0

            pdfCell = New PdfPCell(New Paragraph("Page: " & document.PageNumber, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            p1.AddCell(pdfCell)
            p1.WriteSelectedRows(0, -1, document.LeftMargin - 100, document.GetTop(document.TopMargin) + 70, writer.DirectContent)

        End Sub
    End Class
    Dim table2 As New DataTable()
    Public Sub ExportStabilityLog_Part1()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim da As New SqlDataAdapter()

            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select [ID],[productname],[strength],[trno],[btn],[sampleqty],[pack],[cndn],[test],[requestedby],[requestdate],[trprintby],[trprintdate],[releasedby],[releaseddate],[Status] from trstb order by trno ASC", con)
            da.Fill(table2)

            Dim doc As New Document(PageSize.A4.Rotate, 0.5F, 20.0F, 50.0F, 50)
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream("\\192.168.1.200\it\Provision Backup\Stability_Intimation_Log_" + Date.Today.ToString("ddMMyyyy") + ".pdf", FileMode.Create))
            Dim pHeader As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

            writer.PageEvent = New HeaderFooterStb

            Dim pdfTable As New PdfPTable(16)
            pdfTable.TotalWidth = 780.0F
            pdfTable.LockedWidth = True
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER
            pdfTable.HeaderRows = 1

            Dim widths As Single() = New Single() {0.7F, 2.5F, 0.0F, 1.1F, 1.0F, 1.0F, 1.0F, 1.2F, 1.0F, 1.3F, 0.0F, 1.0F, 0.0F, 1.0F, 0.0F, 1.0F}
            pdfTable.SetWidths(widths)

            Dim pdfcell As PdfPCell = Nothing
            doc.Open()

            pdfcell = New PdfPCell(New Paragraph("ID", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Product Name", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Strength", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("TR No", pColumn))
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

            pdfcell = New PdfPCell(New Paragraph("Sample Qty", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)


            pdfcell = New PdfPCell(New Paragraph("Pack Style", pColumn))
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

            pdfcell = New PdfPCell(New Paragraph("Test Name", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Sample Send by FRD", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("FRD Date", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Sample Received by ARD", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("ARD Date", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Data Released by DQA", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("DQA Date", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Status", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            Dim dt As DataTable = GetIntimationStability_Log1()

            For i = 0 To dt.Rows.Count - 1
                For j As Integer = 0 To dt.Columns.Count - 1
                    pdfcell = New PdfPCell(New Paragraph(dt.Rows(i)(j).ToString, pRow))
                    pdfcell.MinimumHeight = 18
                    pdfcell.PaddingLeft = 5.0F
                    pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfTable.AddCell(pdfcell)
                Next
            Next

            doc.Add(pdfTable)

            doc.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function GetIntimationStability_Log1()
        Dim datatable As New DataTable("dt")

        Dim datacolumn1 As New DataColumn(table2.Columns(0).ToString, GetType(String))
        Dim datacolumn2 As New DataColumn(table2.Columns(1).ToString, GetType(String))
        Dim datacolumn3 As New DataColumn(table2.Columns(2).ToString, GetType(String))
        Dim datacolumn4 As New DataColumn(table2.Columns(3).ToString, GetType(String))
        Dim datacolumn5 As New DataColumn(table2.Columns(4).ToString, GetType(String))
        Dim datacolumn6 As New DataColumn(table2.Columns(5).ToString, GetType(String))
        Dim datacolumn7 As New DataColumn(table2.Columns(6).ToString, GetType(String))
        Dim datacolumn8 As New DataColumn(table2.Columns(7).ToString, GetType(String))
        Dim datacolumn9 As New DataColumn(table2.Columns(8).ToString, GetType(String))
        Dim datacolumn10 As New DataColumn(table2.Columns(9).ToString, GetType(String))
        Dim datacolumn11 As New DataColumn(table2.Columns(10).ToString, GetType(String))
        Dim datacolumn12 As New DataColumn(table2.Columns(11).ToString, GetType(String))
        Dim datacolumn13 As New DataColumn(table2.Columns(12).ToString, GetType(String))
        Dim datacolumn14 As New DataColumn(table2.Columns(13).ToString, GetType(String))
        Dim datacolumn15 As New DataColumn(table2.Columns(14).ToString, GetType(String))
        Dim datacolumn16 As New DataColumn(table2.Columns(15).ToString, GetType(String))

        datatable.Columns.Add(datacolumn1)
        datatable.Columns.Add(datacolumn2)
        datatable.Columns.Add(datacolumn3)
        datatable.Columns.Add(datacolumn4)
        datatable.Columns.Add(datacolumn5)
        datatable.Columns.Add(datacolumn6)
        datatable.Columns.Add(datacolumn7)
        datatable.Columns.Add(datacolumn8)
        datatable.Columns.Add(datacolumn9)
        datatable.Columns.Add(datacolumn10)
        datatable.Columns.Add(datacolumn11)
        datatable.Columns.Add(datacolumn12)
        datatable.Columns.Add(datacolumn13)
        datatable.Columns.Add(datacolumn14)
        datatable.Columns.Add(datacolumn15)
        datatable.Columns.Add(datacolumn16)

        Dim row As DataRow
        For i = 0 To table2.Rows.Count - 1
            row = datatable.NewRow
            row(datacolumn1) = table2.Rows(i)(0)
            row(datacolumn2) = table2.Rows(i)(1) + " " + table2.Rows(i)(2)
            ' row(datacolumn3) = table2.Rows(i)(2)
            row(datacolumn4) = table2.Rows(i)(3)
            row(datacolumn5) = table2.Rows(i)(4)
            row(datacolumn6) = table2.Rows(i)(5)
            row(datacolumn7) = table2.Rows(i)(6)

            row(datacolumn8) = table2.Rows(i)(7)
            row(datacolumn9) = table2.Rows(i)(8)


            'Requested by with Date
            row(datacolumn10) = table2.Rows(i)(9) + Environment.NewLine + (CType(table2.Rows(i)(10), DateTime)).ToString("dd/MM/yyyy")

            'TR Printed By with Date
            If table2.Rows(i)(11).ToString = "" Then
                row(datacolumn12) = table2.Rows(i)(11)
            Else
                row(datacolumn12) = table2.Rows(i)(11) + Environment.NewLine + (CType(table2.Rows(i)(12), DateTime)).ToString("dd/MM/yyyy")
            End If

            'Data Released By with Date
            If table2.Rows(i)(13).ToString = "" Then
                row(datacolumn14) = table2.Rows(i)(13)
            Else
                row(datacolumn14) = table2.Rows(i)(13) + Environment.NewLine + (CType(table2.Rows(i)(14), DateTime)).ToString("dd/MM/yyyy")
            End If

            row(datacolumn16) = table2.Rows(i)(15)

            datatable.Rows.Add(row)
        Next
        datatable.AcceptChanges()
        Return datatable
    End Function
    Class HeaderFooterStb
        Inherits PdfPageEventHelper
        Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)
            Dim HeaderFont As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font1 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font2 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pdfCell As PdfPCell = Nothing
            Dim pdfHeader As New PdfPTable(1)
            pdfHeader.TotalWidth = document.PageSize.Width
            pdfHeader.DefaultCell.Border = 0

            pdfCell = New PdfPCell(New Paragraph("V-Ensure Pharma Technologies Pvt Ltd", HeaderFont))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.Border = 0
            pdfHeader.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("A-63, Kopar Khairane, Navi Mumbai", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.Border = 0
            pdfHeader.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("Stability Intimation Log", HeaderFont))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.Border = 0
            pdfHeader.AddCell(pdfCell)
            pdfHeader.WriteSelectedRows(0, -1, 0, document.GetTop(document.TopMargin) + 100, writer.DirectContent)

            Dim p1 As New PdfPTable(1)
            p1.TotalWidth = document.PageSize.Width
            p1.DefaultCell.Border = 0

            pdfCell = New PdfPCell(New Paragraph("Page: " & document.PageNumber, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            p1.AddCell(pdfCell)
            p1.WriteSelectedRows(0, -1, document.LeftMargin - 100, document.GetTop(document.TopMargin) + 70, writer.DirectContent)

        End Sub
    End Class
    Dim table3 As New DataTable()
    Public Sub ExportATRIssuanceLog()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim da As New SqlDataAdapter()

            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select [ID],[proname],[test],[trno],[atrno],[atrissueno],[issuedby],[issueddate] from atrissuelog where atrno IS NOT NULL order by id ASC", con)
            da.Fill(table3)

            Dim doc As New Document(PageSize.A4.Rotate, 0.5F, 20.0F, 50.0F, 50)
            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream("\\192.168.1.200\it\Provision Backup\ATR_Issuance_Log_" + Date.Today.ToString("ddMMyyyy") + ".pdf", FileMode.Create))
            Dim pHeader As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pColumn As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pRow As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

            writer.PageEvent = New HeaderFooterATR

            Dim pdfTable As New PdfPTable(8)
            pdfTable.TotalWidth = 780.0F
            pdfTable.LockedWidth = True
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER
            pdfTable.HeaderRows = 1

            Dim widths As Single() = New Single() {0.7F, 2.2F, 1.0F, 0.8F, 1.1F, 1.0F, 1.3F, 1.3F}
            pdfTable.SetWidths(widths)

            Dim pdfcell As PdfPCell = Nothing
            doc.Open()

            pdfcell = New PdfPCell(New Paragraph("ID", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Product Name", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("Test", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("TR No", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("ATR Number", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("ATR Issuance No.", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("ATR Issued By", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)

            pdfcell = New PdfPCell(New Paragraph("ATR Issued Date", pColumn))
            pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfcell.MinimumHeight = 18
            pdfcell.PaddingLeft = 5.0F
            pdfcell.BackgroundColor = BaseColor.LIGHT_GRAY
            pdfTable.AddCell(pdfcell)


            Dim dt As DataTable = GetATRIssuance_Log()

            For i = 0 To dt.Rows.Count - 1
                For j As Integer = 0 To dt.Columns.Count - 1
                    pdfcell = New PdfPCell(New Paragraph(dt.Rows(i)(j).ToString, pRow))
                    pdfcell.MinimumHeight = 18
                    pdfcell.PaddingLeft = 5.0F
                    pdfcell.HorizontalAlignment = Element.ALIGN_CENTER
                    pdfTable.AddCell(pdfcell)
                Next
            Next

            doc.Add(pdfTable)

            doc.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function GetATRIssuance_Log()
        Dim datatable As New DataTable("dt")

        Dim datacolumn1 As New DataColumn(table3.Columns(0).ToString, GetType(String))
        Dim datacolumn2 As New DataColumn(table3.Columns(1).ToString, GetType(String))
        Dim datacolumn3 As New DataColumn(table3.Columns(2).ToString, GetType(String))
        Dim datacolumn4 As New DataColumn(table3.Columns(3).ToString, GetType(String))
        Dim datacolumn5 As New DataColumn(table3.Columns(4).ToString, GetType(String))
        Dim datacolumn6 As New DataColumn(table3.Columns(5).ToString, GetType(String))
        Dim datacolumn7 As New DataColumn(table3.Columns(6).ToString, GetType(String))
        Dim datacolumn8 As New DataColumn(table3.Columns(7).ToString, GetType(String))

        datatable.Columns.Add(datacolumn1)
        datatable.Columns.Add(datacolumn2)
        datatable.Columns.Add(datacolumn3)
        datatable.Columns.Add(datacolumn4)
        datatable.Columns.Add(datacolumn5)
        datatable.Columns.Add(datacolumn6)
        datatable.Columns.Add(datacolumn7)
        datatable.Columns.Add(datacolumn8)

        Dim row As DataRow
        For i = 0 To table3.Rows.Count - 1
            row = datatable.NewRow
            row(datacolumn1) = table3.Rows(i)(0)
            row(datacolumn2) = table3.Rows(i)(1)
            row(datacolumn3) = table3.Rows(i)(2)
            row(datacolumn4) = table3.Rows(i)(3)
            row(datacolumn5) = table3.Rows(i)(4)
            row(datacolumn6) = table3.Rows(i)(5)
            row(datacolumn7) = table3.Rows(i)(6)

            If table3.Rows(i)(7).ToString = "" Then
                row(datacolumn8) = table3.Rows(i)(7)
            Else
                row(datacolumn8) = (CType(table3.Rows(i)(7), DateTime)).ToString("dd/MM/yyyy")
            End If


            datatable.Rows.Add(row)
        Next
        datatable.AcceptChanges()
        Return datatable
    End Function
    Class HeaderFooterATR
        Inherits PdfPageEventHelper
        Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)
            Dim HeaderFont As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font1 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim font2 As New Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pdfCell As PdfPCell = Nothing
            Dim pdfHeader As New PdfPTable(1)
            pdfHeader.TotalWidth = document.PageSize.Width
            pdfHeader.DefaultCell.Border = 0

            pdfCell = New PdfPCell(New Paragraph("V-Ensure Pharma Technologies Pvt Ltd", HeaderFont))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.Border = 0
            pdfHeader.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("A-63, Kopar Khairane, Navi Mumbai", font1))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.Border = 0
            pdfHeader.AddCell(pdfCell)

            pdfCell = New PdfPCell(New Paragraph("ATR Issuance Log", HeaderFont))
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER
            pdfCell.Border = 0
            pdfHeader.AddCell(pdfCell)
            pdfHeader.WriteSelectedRows(0, -1, 0, document.GetTop(document.TopMargin) + 100, writer.DirectContent)

            Dim p1 As New PdfPTable(1)
            p1.TotalWidth = document.PageSize.Width
            p1.DefaultCell.Border = 0

            pdfCell = New PdfPCell(New Paragraph("Page: " & document.PageNumber, font1))
            pdfCell.Border = 0
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT
            p1.AddCell(pdfCell)
            p1.WriteSelectedRows(0, -1, document.LeftMargin - 100, document.GetTop(document.TopMargin) + 70, writer.DirectContent)

        End Sub
    End Class

    Private Sub SQLBackup()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "BACKUP DATABASE provision TO DISK='\\192.168.1.200\it\Provision Backup\Provision_SQLBackup" + Date.Today.ToString("ddMMyyyy") + ".BAK'"
        '"\\192.168.1.200\it\Provision Backup\ATR_Issuance_Log_" + Date.Today.ToString("ddMMyyyy") + ".pdf"
        con.Open()
        cmd1.ExecuteNonQuery()
    End Sub
    Private Sub runbackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class