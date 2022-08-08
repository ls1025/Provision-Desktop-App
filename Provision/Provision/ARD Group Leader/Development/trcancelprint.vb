Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.Drawing.Graphics
Imports System
Imports System.Management
Public Class trcancelprint
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim cmd2 As SqlCommand
    Dim cmd3 As SqlCommand
    'Private pageNo As Integer = 1
    Private Sub trcancelprint_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 60, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        PictureBox1.Hide()
        LoadDefaultPrinter()
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            If Label1.Text.Contains("DT/") Then
                PrintDialog1.Document = PrintDocument1
                Dim d = PrintDialog1.ShowDialog()
                If d = Windows.Forms.DialogResult.OK Then
                    PrintDialog1.PrinterSettings.Copies = CInt(1)
                    PrintDocument1.Print()
                    Dim curValue As Integer
                    Dim result As String
                    'Using con As SqlConnection = New SqlConnection("Data Source=VE-IT\SQLEXPRESS;Initial Catalog=vensure;Integrated Security=True;")
                    If con.State = ConnectionState.Open Then con.Close()
                    con.Open()
                    Dim cmd = New SqlCommand("Select MAX(prints) FROM trdev where trno='" + Label1.Text + "'", con)
                    result = cmd.ExecuteScalar().ToString()
                    If String.IsNullOrEmpty(result) Then
                        result = "1"
                    Else
                        Int32.TryParse(result, curValue)
                        curValue = result + 1
                        result = curValue
                    End If

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry1 As String
                    qry1 = "update trdev set prints='" + result + "' where trno='" + Label1.Text + "'"
                    cmd1 = New SqlCommand(qry1, con)
                    con.Open()
                    cmd1.ExecuteNonQuery()
                    con.Close()
                    Dim f1 As viewcancelintimations = DirectCast(Me.Owner, viewcancelintimations)
                    f1.LoadCancelIntimations()
                    Me.Close()
                End If
            ElseIf Label1.Text.Contains("TR/") Then
                PrintDialog1.Document = PrintDocument2
                Dim d = PrintDialog1.ShowDialog()
                If d = Windows.Forms.DialogResult.OK Then
                    PrintDialog1.PrinterSettings.Copies = CInt(1)
                    PrintDocument2.Print()
                    Dim curValue As Integer
                    Dim result As String
                    'Using con As SqlConnection = New SqlConnection("Data Source=VE-IT\SQLEXPRESS;Initial Catalog=vensure;Integrated Security=True;")
                    If con.State = ConnectionState.Open Then con.Close()
                    con.Open()
                    Dim cmd = New SqlCommand("Select MAX(prints) FROM trrot where trno='" + Label1.Text + "'", con)
                    result = cmd.ExecuteScalar().ToString()
                    If String.IsNullOrEmpty(result) Then
                        result = "1"
                    Else
                        Int32.TryParse(result, curValue)
                        curValue = result + 1
                        result = curValue
                    End If

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry1 As String
                    qry1 = "update trrot set prints='" + result + "' where trno='" + Label1.Text + "'"
                    cmd1 = New SqlCommand(qry1, con)
                    con.Open()
                    cmd1.ExecuteNonQuery()
                    con.Close()
                    Dim f1 As viewcancelintimations = DirectCast(Me.Owner, viewcancelintimations)
                    f1.LoadCancelIntimations()
                    Me.Close()
                End If
            ElseIf Label1.Text.Contains("ST/") Then
                PrintDialog1.Document = PrintDocument3
                Dim d = PrintDialog1.ShowDialog()
                If d = Windows.Forms.DialogResult.OK Then
                    PrintDialog1.PrinterSettings.Copies = CInt(1)
                    PrintDocument3.Print()
                    Dim curValue As Integer
                    Dim result As String
                    'Using con As SqlConnection = New SqlConnection("Data Source=VE-IT\SQLEXPRESS;Initial Catalog=vensure;Integrated Security=True;")
                    If con.State = ConnectionState.Open Then con.Close()
                    con.Open()
                    Dim cmd = New SqlCommand("Select MAX(prints) FROM trstb where trno='" + Label1.Text + "'", con)
                    result = cmd.ExecuteScalar().ToString()
                    If String.IsNullOrEmpty(result) Then
                        result = "1"
                    Else
                        Int32.TryParse(result, curValue)
                        curValue = result + 1
                        result = curValue
                    End If

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry1 As String
                    qry1 = "update trstb set prints='" + result + "' where trno='" + Label1.Text + "'"
                    cmd1 = New SqlCommand(qry1, con)
                    con.Open()
                    cmd1.ExecuteNonQuery()
                    con.Close()
                    Dim f1 As viewcancelintimations = DirectCast(Me.Owner, viewcancelintimations)
                    f1.LoadCancelIntimations()
                    Me.Close()
                End If
            End If
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            If Label1.Text.Contains("DT/") = True Then
                PrintPreviewDialog1.ShowDialog()
            ElseIf Label1.Text.Contains("TR/") Then
                PrintPreviewDialog2.ShowDialog()
            ElseIf Label1.Text.Contains("ST/") Then
                PrintPreviewDialog3.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub PrintPreviewDialog1_Load(sender As System.Object, e As System.EventArgs) Handles PrintPreviewDialog1.Load
        CType(PrintPreviewDialog1.Controls(1), ToolStrip).Items(0).Enabled = False
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1.5
        DirectCast(PrintPreviewDialog1, Form).WindowState = FormWindowState.Maximized
    End Sub
    Private Sub PrintDocument1_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry As String
            qry = "SELECT * FROM trdev where trno='" + Label1.Text + "'"
            cmd = New SqlCommand(qry, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            da.Fill(table)
            ' From trdev table index
            'TR No
            Dim trno As String
            trno = table.Rows(0)(5).ToString

            ' Request Date
            Dim reqdate As DateTime
            reqdate = DateTime.Parse(table.Rows(0)(20).ToString)
            ' Product Code
            Dim procode As String
            procode = table.Rows(0)(1).ToString

            'Product Name
            Dim proname As String
            proname = table.Rows(0)(2).ToString

            'Strength
            Dim str As String
            str = table.Rows(0)(3).ToString

            'Lable Claim
            Dim lblclaim As String
            lblclaim = table.Rows(0)(6).ToString

            'Batch No
            Dim btno As String
            btno = table.Rows(0)(7).ToString

            'Batch Size
            Dim bsize As String
            bsize = table.Rows(0)(8).ToString

            'Mfg
            Dim mfg As String
            mfg = table.Rows(0)(9).ToString

            'exp
            Dim exp As String
            exp = table.Rows(0)(10).ToString

            'Sample Qty
            Dim smplqty As String
            smplqty = table.Rows(0)(11).ToString

            'Pack
            Dim pack As String
            pack = table.Rows(0)(12).ToString

            'Condition
            Dim cond As String
            cond = table.Rows(0)(13).ToString

            'Period
            Dim period As String
            period = table.Rows(0)(14).ToString

            'Test Requested
            Dim testreqd As String
            testreqd = table.Rows(0)(15).ToString

            'Details of Test
            Dim dettest As String
            dettest = table.Rows(0)(16).ToString

            'Remarks
            Dim rmrk As String
            rmrk = table.Rows(0)(17).ToString

            'Requested By
            Dim reqby As String
            reqby = table.Rows(0)(19).ToString

            Dim ReportFont1 As Font = New Drawing.Font("Times New Roman", 10, FontStyle.Bold)
            Dim ReportFont2 As Font = New Drawing.Font("Times New Roman", 12, FontStyle.Bold)
            Dim ReportFont3 As Font = New Drawing.Font("Times New Roman", 11, FontStyle.Bold)
            Dim ReportFont4 As Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold)
            Dim ReportFont5 As Font = New Drawing.Font("Times New Roman", 10)
            Dim blackPen As New Pen(Color.Black, 1)
            e.Graphics.DrawString("Test Request No :", ReportFont1, Brushes.Black, 23, 39)
            e.Graphics.DrawString(Label1.Text, ReportFont5, Brushes.Black, 137, 40)

            e.Graphics.DrawString("Request Date :", ReportFont1, Brushes.Black, 537, 39)
            e.Graphics.DrawString(reqdate.ToString("dd/MM/yyyy"), ReportFont5, Brushes.Black, 633, 40)


            e.Graphics.DrawString("FORMULATION RESEARCH AND DEVELOPMENT", ReportFont2, Brushes.Black, 204, 108)
            e.Graphics.DrawString("V-Ensure Pharma Technologies Pvt Ltd", ReportFont3, Brushes.Black, 273, 130)
            e.Graphics.DrawString("Navi Mumbai", ReportFont3, Brushes.Black, 345, 151)
            e.Graphics.DrawString("TEST REQUISITION SHEET", ReportFont4, Brushes.Black, 259, 180)

            e.Graphics.DrawString("Print Copy No. :", ReportFont1, Brushes.Black, 610, 151)
            e.Graphics.DrawString(Label2.Text, ReportFont5, Brushes.Black, 722, 151)

            e.Graphics.DrawString("Product Code :", ReportFont1, Brushes.Black, 23, 223)
            e.Graphics.DrawString(procode, ReportFont5, Brushes.Black, 132, 223)



            e.Graphics.DrawString("Product Name :", ReportFont1, Brushes.Black, 225, 223)

            'e.Graphics.DrawRectangle(blackPen, 326, 210, 445, 40)
            'Dim rect1 As Rectangle = New Rectangle(326, 210, 445, 40)
            Dim StringFormat As StringFormat = New StringFormat()
            StringFormat.Alignment = StringAlignment.Near
            StringFormat.LineAlignment = StringAlignment.Center

            e.Graphics.DrawString(proname, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(326, 210, 445, 40), StringFormat)

            ' e.Graphics.DrawString(proname + " " + str, ReportFont5, Brushes.Black, 326, 223)

            e.Graphics.DrawString("Label Claim :", ReportFont1, Brushes.Black, 23, 262)

            e.Graphics.DrawString(lblclaim, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(112, 250, 670, 40), StringFormat)

            e.Graphics.DrawString("Batch No. :", ReportFont1, Brushes.Black, 23, 302)
            e.Graphics.DrawString(btno, ReportFont5, Brushes.Black, 100, 302)

            e.Graphics.DrawString("Batch Size :", ReportFont1, Brushes.Black, 225, 302)
            e.Graphics.DrawString(bsize, ReportFont5, Brushes.Black, 300, 302)

            e.Graphics.DrawString("Mfg Date :", ReportFont1, Brushes.Black, 440, 302)
            If String.IsNullOrEmpty(mfg) Or mfg = " " Then
                e.Graphics.DrawString("NA", ReportFont5, Brushes.Black, 513, 302)
            Else
                e.Graphics.DrawString(mfg, ReportFont5, Brushes.Black, 513, 302)
            End If


            e.Graphics.DrawString("Exp Date :", ReportFont1, Brushes.Black, 621, 302)
            If String.IsNullOrEmpty(exp) Or exp = " " Then
                e.Graphics.DrawString("NA", ReportFont5, Brushes.Black, 690, 303)
            Else
                e.Graphics.DrawString(exp, ReportFont5, Brushes.Black, 690, 303)
            End If


            e.Graphics.DrawString("Sample Qty : ", ReportFont1, Brushes.Black, 23, 342)
            e.Graphics.DrawString(smplqty, ReportFont5, Brushes.Black, 111, 342)

            e.Graphics.DrawString("Pack :", ReportFont1, Brushes.Black, 280, 342)
            e.Graphics.DrawString(pack, ReportFont5, Brushes.Black, 325, 342)

            e.Graphics.DrawString("Period :", ReportFont1, Brushes.Black, 23, 381)
            e.Graphics.DrawString(period, ReportFont5, Brushes.Black, 80, 381)

            e.Graphics.DrawString("Condition :", ReportFont1, Brushes.Black, 280, 381)
            e.Graphics.DrawString(cond, ReportFont5, Brushes.Black, 355, 381)

            e.Graphics.DrawString("Test Requested :", ReportFont1, Brushes.Black, 23, 420)
            e.Graphics.DrawString(testreqd, ReportFont5, Brushes.Black, 133, 420)

            e.Graphics.DrawString("Details of Test :", ReportFont1, Brushes.Black, 23, 470)

            e.Graphics.DrawString(dettest, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(130, 450, 645, 50), StringFormat)

            e.Graphics.DrawString("Remarks :", ReportFont1, Brushes.Black, 23, 510)
            If String.IsNullOrEmpty(rmrk) Then
                e.Graphics.DrawString("Nil", ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            Else
                e.Graphics.DrawString(rmrk, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            End If

            e.Graphics.DrawString("Requested By :", ReportFont1, Brushes.Black, 23, 550)
            e.Graphics.DrawString(reqby, ReportFont5, Brushes.Black, 114, 550)
            e.Graphics.DrawString("Recieved By :", ReportFont1, Brushes.Black, 285, 550)
            e.Graphics.DrawString(homepageard.Label1.Text, ReportFont5, Brushes.Black, 370, 550)
            e.Graphics.DrawString("AR No :", ReportFont1, Brushes.Black, 515, 550)
            Dim arno As String
            arno = trno.Replace("T", "")
            e.Graphics.DrawString(arno, ReportFont5, Brushes.Black, 570, 550)

            e.Graphics.DrawString("AR No :", ReportFont1, Brushes.Black, 515, 550)

            e.Graphics.DrawString("STP No. :", ReportFont1, Brushes.Black, 23, 589)
            e.Graphics.DrawString("LNB Reference No :", ReportFont1, Brushes.Black, 515, 589)

            e.Graphics.DrawString("Sr No.", ReportFont1, Brushes.Black, 23, 623)
            e.Graphics.DrawString("Test", ReportFont1, Brushes.Black, 175, 623)
            e.Graphics.DrawString("Condition", ReportFont1, Brushes.Black, 390, 623)
            e.Graphics.DrawString("Result", ReportFont1, Brushes.Black, 635, 623)


            e.Graphics.DrawString("Analysed By :", ReportFont1, Brushes.Black, 26, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 26, 958)
            e.Graphics.DrawString("Checked By :", ReportFont1, Brushes.Black, 280, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 280, 958)
            e.Graphics.DrawString("Released By :", ReportFont1, Brushes.Black, 540, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 540, 958)

            'Print Cancelled Water Mark
            e.Graphics.DrawString("Cancelled", New Font("Time New Romans", 60, FontStyle.Regular), Brushes.LightGray, New PointF(200, 400))

            If con.State = ConnectionState.Open Then con.Close()
            Dim qry1 As String
            qry1 = "select trformatno from formatno where srno='1'"
            cmd1 = New SqlCommand(qry1, con)
            con.Open()
            Dim annexno As String
            annexno = cmd1.ExecuteScalar().ToString()
            con.Close()
            e.Graphics.DrawString(annexno, ReportFont3, Brushes.Black, 650, 1000)



            e.Graphics.DrawImage(PictureBox1.Image, 300, 65, PictureBox1.Width, PictureBox1.Height)

            'square 1
            e.Graphics.DrawRectangle(blackPen, 15, 35, 760, 855)

            'from 2nd top
            'line.1
            e.Graphics.DrawLine(blackPen, 15.0F, 63.0F, 775.0F, 63.0F)
            'line 2
            e.Graphics.DrawLine(blackPen, 15.0F, 173.0F, 775.0F, 173.0F)
            'line 3
            e.Graphics.DrawLine(blackPen, 15.0F, 211.0F, 775.0F, 211.0F)
            'line 4
            e.Graphics.DrawLine(blackPen, 15.0F, 250.0F, 775.0F, 250.0F)
            'line 5
            e.Graphics.DrawLine(blackPen, 15.0F, 290.0F, 775.0F, 290.0F)
            'line 6
            e.Graphics.DrawLine(blackPen, 15.0F, 330.0F, 775.0F, 330.0F)
            'line 7
            e.Graphics.DrawLine(blackPen, 15.0F, 370.0F, 775.0F, 370.0F)
            'line 8
            e.Graphics.DrawLine(blackPen, 15.0F, 410.0F, 775.0F, 410.0F)
            'line 9
            e.Graphics.DrawLine(blackPen, 15.0F, 450.0F, 775.0F, 450.0F)
            'line 10
            e.Graphics.DrawLine(blackPen, 15.0F, 500.0F, 775.0F, 500.0F)
            'line 11
            e.Graphics.DrawLine(blackPen, 15.0F, 540.0F, 775.0F, 540.0F)
            'line 12
            e.Graphics.DrawLine(blackPen, 15.0F, 580.0F, 775.0F, 580.0F)
            'line 13
            e.Graphics.DrawLine(blackPen, 15.0F, 615.0F, 775.0F, 615.0F)
            'line 14
            e.Graphics.DrawLine(blackPen, 15.0F, 645.0F, 775.0F, 645.0F)
            'line 15
            e.Graphics.DrawLine(blackPen, 15.0F, 945.0F, 775.0F, 945.0F)


            'from left side
            'at product name
            e.Graphics.DrawLine(blackPen, 218.0F, 211.0F, 218.0F, 250.0F)
            'at bacth size
            e.Graphics.DrawLine(blackPen, 218.0F, 290.0F, 218.0F, 330.0F)
            'at mfg date
            e.Graphics.DrawLine(blackPen, 430.0F, 290.0F, 430.0F, 330.0F)
            'at Exp Date
            e.Graphics.DrawLine(blackPen, 610.0F, 290.0F, 610.0F, 330.0F)
            'at pack
            e.Graphics.DrawLine(blackPen, 270.0F, 330.0F, 270.0F, 410.0F)
            'at Recieved by
            e.Graphics.DrawLine(blackPen, 280.0F, 540.0F, 280.0F, 580.0F)
            'at AR No.
            e.Graphics.DrawLine(blackPen, 510.0F, 540.0F, 510.0F, 615.0F)

            'at test
            e.Graphics.DrawLine(blackPen, 70.0F, 615.0F, 70.0F, 890.0F)
            'at condition
            e.Graphics.DrawLine(blackPen, 310.0F, 615.0F, 310.0F, 890.0F)
            'at result
            e.Graphics.DrawLine(blackPen, 550.0F, 615.0F, 550.0F, 890.0F)
            'at checked by
            e.Graphics.DrawLine(blackPen, 275.0F, 900.0F, 275.0F, 990.0F)
            'at released by
            e.Graphics.DrawLine(blackPen, 535.0F, 900.0F, 535.0F, 990.0F)
            'square 2
            e.Graphics.DrawRectangle(blackPen, 15, 900, 760, 90)

            'for number of pages
            'pageNo = pageNo + 1
            'e.HasMorePages = pageNo <= 3
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub PrintPreviewDialog2_Load(sender As System.Object, e As System.EventArgs) Handles PrintPreviewDialog2.Load
        CType(PrintPreviewDialog2.Controls(1), ToolStrip).Items(0).Enabled = False
        PrintPreviewDialog2.PrintPreviewControl.Zoom = 1.5
        DirectCast(PrintPreviewDialog2, Form).WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PrintDocument2_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry As String
            qry = "SELECT * FROM trrot where trno='" + Label1.Text + "'"
            cmd = New SqlCommand(qry, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            da.Fill(table)
            ' From trdev table index
            'TR No
            Dim trno As String
            trno = table.Rows(0)(5).ToString

            ' Request Date
            Dim reqdate As DateTime
            reqdate = DateTime.Parse(table.Rows(0)(20).ToString)
            ' Product Code
            Dim procode As String
            procode = table.Rows(0)(1).ToString

            'Product Name
            Dim proname As String
            proname = table.Rows(0)(2).ToString

            'Strength
            Dim str As String
            str = table.Rows(0)(3).ToString

            'Lable Claim
            Dim lblclaim As String
            lblclaim = table.Rows(0)(6).ToString

            'Batch No
            Dim btno As String
            btno = table.Rows(0)(7).ToString

            'Batch Size
            Dim bsize As String
            bsize = table.Rows(0)(8).ToString

            'Mfg
            Dim mfg As String
            mfg = table.Rows(0)(9).ToString

            'exp
            Dim exp As String
            exp = table.Rows(0)(10).ToString

            'Sample Qty
            Dim smplqty As String
            smplqty = table.Rows(0)(11).ToString

            'Pack
            Dim pack As String
            pack = table.Rows(0)(12).ToString

            'Condition
            Dim cond As String
            cond = table.Rows(0)(13).ToString

            'Period
            Dim period As String
            period = table.Rows(0)(14).ToString

            'Test Requested
            Dim testreqd As String
            testreqd = table.Rows(0)(15).ToString

            'Details of Test
            Dim dettest As String
            dettest = table.Rows(0)(16).ToString

            'Remarks
            Dim rmrk As String
            rmrk = table.Rows(0)(17).ToString

            'Requested By
            Dim reqby As String
            reqby = table.Rows(0)(19).ToString

            Dim ReportFont1 As Font = New Drawing.Font("Times New Roman", 10, FontStyle.Bold)
            Dim ReportFont2 As Font = New Drawing.Font("Times New Roman", 12, FontStyle.Bold)
            Dim ReportFont3 As Font = New Drawing.Font("Times New Roman", 11, FontStyle.Bold)
            Dim ReportFont4 As Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold)
            Dim ReportFont5 As Font = New Drawing.Font("Times New Roman", 10)
            Dim blackPen As New Pen(Color.Black, 1)
            e.Graphics.DrawString("Test Request No :", ReportFont1, Brushes.Black, 23, 39)
            e.Graphics.DrawString(Label1.Text, ReportFont5, Brushes.Black, 137, 40)

            e.Graphics.DrawString("Request Date :", ReportFont1, Brushes.Black, 537, 39)
            e.Graphics.DrawString(reqdate.ToString("dd/MM/yyyy"), ReportFont5, Brushes.Black, 633, 40)


            e.Graphics.DrawString("FORMULATION RESEARCH AND DEVELOPMENT", ReportFont2, Brushes.Black, 204, 108)
            e.Graphics.DrawString("V-Ensure Pharma Technologies Pvt Ltd", ReportFont3, Brushes.Black, 273, 130)
            e.Graphics.DrawString("Navi Mumbai", ReportFont3, Brushes.Black, 345, 151)
            e.Graphics.DrawString("TEST REQUISITION SHEET", ReportFont4, Brushes.Black, 259, 180)

            e.Graphics.DrawString("Print Copy No. :", ReportFont1, Brushes.Black, 610, 151)
            e.Graphics.DrawString(Label2.Text, ReportFont5, Brushes.Black, 722, 151)

            e.Graphics.DrawString("Product Code :", ReportFont1, Brushes.Black, 23, 223)
            e.Graphics.DrawString(procode, ReportFont5, Brushes.Black, 132, 223)



            e.Graphics.DrawString("Product Name :", ReportFont1, Brushes.Black, 225, 223)

            'e.Graphics.DrawRectangle(blackPen, 326, 210, 445, 40)
            'Dim rect1 As Rectangle = New Rectangle(326, 210, 445, 40)
            Dim StringFormat As StringFormat = New StringFormat()
            StringFormat.Alignment = StringAlignment.Near
            StringFormat.LineAlignment = StringAlignment.Center

            e.Graphics.DrawString(proname, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(326, 210, 445, 40), StringFormat)

            ' e.Graphics.DrawString(proname + " " + str, ReportFont5, Brushes.Black, 326, 223)

            e.Graphics.DrawString("Label Claim :", ReportFont1, Brushes.Black, 23, 262)

            e.Graphics.DrawString(lblclaim, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(112, 250, 670, 40), StringFormat)

            e.Graphics.DrawString("Batch No. :", ReportFont1, Brushes.Black, 23, 302)
            e.Graphics.DrawString(btno, ReportFont5, Brushes.Black, 100, 302)

            e.Graphics.DrawString("Batch Size :", ReportFont1, Brushes.Black, 225, 302)
            e.Graphics.DrawString(bsize, ReportFont5, Brushes.Black, 300, 302)

            e.Graphics.DrawString("Mfg Date :", ReportFont1, Brushes.Black, 440, 302)
            If String.IsNullOrEmpty(mfg) Or mfg = " " Then
                e.Graphics.DrawString("NA", ReportFont5, Brushes.Black, 513, 302)
            Else
                e.Graphics.DrawString(mfg, ReportFont5, Brushes.Black, 513, 302)
            End If

            e.Graphics.DrawString("Exp Date :", ReportFont1, Brushes.Black, 621, 302)
            If String.IsNullOrEmpty(exp) Or exp = " " Then
                e.Graphics.DrawString("NA", ReportFont5, Brushes.Black, 690, 303)
            Else
                e.Graphics.DrawString(exp, ReportFont5, Brushes.Black, 690, 303)
            End If

            e.Graphics.DrawString("Sample Qty :", ReportFont1, Brushes.Black, 23, 342)
            e.Graphics.DrawString(smplqty, ReportFont5, Brushes.Black, 111, 342)

            e.Graphics.DrawString("Pack :", ReportFont1, Brushes.Black, 280, 342)
            e.Graphics.DrawString(pack, ReportFont5, Brushes.Black, 325, 342)

            e.Graphics.DrawString("Period :", ReportFont1, Brushes.Black, 23, 381)
            e.Graphics.DrawString(period, ReportFont5, Brushes.Black, 80, 381)

            e.Graphics.DrawString("Condition :", ReportFont1, Brushes.Black, 280, 381)
            e.Graphics.DrawString(cond, ReportFont5, Brushes.Black, 355, 381)

            e.Graphics.DrawString("Test Requested :", ReportFont1, Brushes.Black, 23, 420)
            e.Graphics.DrawString(testreqd, ReportFont5, Brushes.Black, 133, 420)

            e.Graphics.DrawString("Details of Test :", ReportFont1, Brushes.Black, 23, 470)

            e.Graphics.DrawString(dettest, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(130, 450, 645, 50), StringFormat)

            e.Graphics.DrawString("Remarks :", ReportFont1, Brushes.Black, 23, 510)
            If String.IsNullOrEmpty(rmrk) Then
                e.Graphics.DrawString("NA", ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            Else
                e.Graphics.DrawString(rmrk, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            End If


            e.Graphics.DrawString("Requested By :", ReportFont1, Brushes.Black, 23, 550)
            e.Graphics.DrawString(reqby, ReportFont5, Brushes.Black, 114, 550)
            e.Graphics.DrawString("Recieved By :", ReportFont1, Brushes.Black, 285, 550)
            e.Graphics.DrawString(homepageard.Label1.Text, ReportFont5, Brushes.Black, 370, 550)
            e.Graphics.DrawString("AR No :", ReportFont1, Brushes.Black, 515, 550)
            Dim arno As String
            arno = trno.Replace("T", "")
            e.Graphics.DrawString(arno, ReportFont5, Brushes.Black, 570, 550)

            e.Graphics.DrawString("STP No. :", ReportFont1, Brushes.Black, 23, 589)
            e.Graphics.DrawString("LNB Reference No :", ReportFont1, Brushes.Black, 515, 589)

            e.Graphics.DrawString("Sr No.", ReportFont1, Brushes.Black, 23, 623)
            e.Graphics.DrawString("Test", ReportFont1, Brushes.Black, 175, 623)
            e.Graphics.DrawString("Condition", ReportFont1, Brushes.Black, 390, 623)
            e.Graphics.DrawString("Result", ReportFont1, Brushes.Black, 635, 623)


            e.Graphics.DrawString("Analysed By :", ReportFont1, Brushes.Black, 26, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 26, 958)
            e.Graphics.DrawString("Checked By :", ReportFont1, Brushes.Black, 280, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 280, 958)
            e.Graphics.DrawString("Released By :", ReportFont1, Brushes.Black, 540, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 540, 958)

            'Print Cancelled Water Mark
            e.Graphics.DrawString("Cancelled", New Font("Time New Romans", 60, FontStyle.Regular), Brushes.LightGray, New PointF(200, 400))

            If con.State = ConnectionState.Open Then con.Close()
            Dim qry1 As String
            qry1 = "select trformatno from formatno where srno='1'"
            cmd1 = New SqlCommand(qry1, con)
            con.Open()
            Dim annexno As String
            annexno = cmd1.ExecuteScalar().ToString()
            con.Close()
            e.Graphics.DrawString(annexno, ReportFont3, Brushes.Black, 650, 1000)



            e.Graphics.DrawImage(PictureBox1.Image, 300, 65, PictureBox1.Width, PictureBox1.Height)

            'square 1
            e.Graphics.DrawRectangle(blackPen, 15, 35, 760, 855)

            'from 2nd top
            'line.1
            e.Graphics.DrawLine(blackPen, 15.0F, 63.0F, 775.0F, 63.0F)
            'line 2
            e.Graphics.DrawLine(blackPen, 15.0F, 173.0F, 775.0F, 173.0F)
            'line 3
            e.Graphics.DrawLine(blackPen, 15.0F, 211.0F, 775.0F, 211.0F)
            'line 4
            e.Graphics.DrawLine(blackPen, 15.0F, 250.0F, 775.0F, 250.0F)
            'line 5
            e.Graphics.DrawLine(blackPen, 15.0F, 290.0F, 775.0F, 290.0F)
            'line 6
            e.Graphics.DrawLine(blackPen, 15.0F, 330.0F, 775.0F, 330.0F)
            'line 7
            e.Graphics.DrawLine(blackPen, 15.0F, 370.0F, 775.0F, 370.0F)
            'line 8
            e.Graphics.DrawLine(blackPen, 15.0F, 410.0F, 775.0F, 410.0F)
            'line 9
            e.Graphics.DrawLine(blackPen, 15.0F, 450.0F, 775.0F, 450.0F)
            'line 10
            e.Graphics.DrawLine(blackPen, 15.0F, 500.0F, 775.0F, 500.0F)
            'line 11
            e.Graphics.DrawLine(blackPen, 15.0F, 540.0F, 775.0F, 540.0F)
            'line 12
            e.Graphics.DrawLine(blackPen, 15.0F, 580.0F, 775.0F, 580.0F)
            'line 13
            e.Graphics.DrawLine(blackPen, 15.0F, 615.0F, 775.0F, 615.0F)
            'line 14
            e.Graphics.DrawLine(blackPen, 15.0F, 645.0F, 775.0F, 645.0F)
            'line 15
            e.Graphics.DrawLine(blackPen, 15.0F, 945.0F, 775.0F, 945.0F)


            'from left side
            'at product name
            e.Graphics.DrawLine(blackPen, 218.0F, 211.0F, 218.0F, 250.0F)
            'at bacth size
            e.Graphics.DrawLine(blackPen, 218.0F, 290.0F, 218.0F, 330.0F)
            'at mfg date
            e.Graphics.DrawLine(blackPen, 430.0F, 290.0F, 430.0F, 330.0F)
            'at Exp Date
            e.Graphics.DrawLine(blackPen, 610.0F, 290.0F, 610.0F, 330.0F)
            'at pack
            e.Graphics.DrawLine(blackPen, 270.0F, 330.0F, 270.0F, 410.0F)
            'at Recieved by
            e.Graphics.DrawLine(blackPen, 280.0F, 540.0F, 280.0F, 580.0F)
            'at AR No.
            e.Graphics.DrawLine(blackPen, 510.0F, 540.0F, 510.0F, 615.0F)

            'at test
            e.Graphics.DrawLine(blackPen, 70.0F, 615.0F, 70.0F, 890.0F)
            'at condition
            e.Graphics.DrawLine(blackPen, 310.0F, 615.0F, 310.0F, 890.0F)
            'at result
            e.Graphics.DrawLine(blackPen, 550.0F, 615.0F, 550.0F, 890.0F)
            'at checked by
            e.Graphics.DrawLine(blackPen, 275.0F, 900.0F, 275.0F, 990.0F)
            'at released by
            e.Graphics.DrawLine(blackPen, 535.0F, 900.0F, 535.0F, 990.0F)
            'square 2
            e.Graphics.DrawRectangle(blackPen, 15, 900, 760, 90)

            'for number of pages
            'pageNo = pageNo + 1
            'e.HasMorePages = pageNo <= 3
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub PrintPreviewDialog3_Load(sender As System.Object, e As System.EventArgs) Handles PrintPreviewDialog3.Load
        CType(PrintPreviewDialog3.Controls(1), ToolStrip).Items(0).Enabled = False
        PrintPreviewDialog3.PrintPreviewControl.Zoom = 1.5
        DirectCast(PrintPreviewDialog3, Form).WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PrintDocument3_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument3.PrintPage
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry As String
            qry = "SELECT * FROM trstb where trno='" + Label1.Text + "'"
            cmd = New SqlCommand(qry, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            da.Fill(table)
            ' From trdev table index
            'TR No
            Dim trno As String
            trno = table.Rows(0)(5).ToString

            ' Request Date
            Dim reqdate As DateTime
            reqdate = DateTime.Parse(table.Rows(0)(20).ToString)
            ' Product Code
            Dim procode As String
            procode = table.Rows(0)(1).ToString

            'Product Name
            Dim proname As String
            proname = table.Rows(0)(2).ToString

            'Strength
            Dim str As String
            str = table.Rows(0)(3).ToString

            'Lable Claim
            Dim lblclaim As String
            lblclaim = table.Rows(0)(6).ToString

            'Batch No
            Dim btno As String
            btno = table.Rows(0)(7).ToString

            'Batch Size
            Dim bsize As String
            bsize = table.Rows(0)(8).ToString

            'Mfg
            Dim mfg As String
            mfg = table.Rows(0)(9).ToString

            'exp
            Dim exp As String
            exp = table.Rows(0)(10).ToString

            'Sample Qty
            Dim smplqty As String
            smplqty = table.Rows(0)(11).ToString

            'Pack
            Dim pack As String
            pack = table.Rows(0)(12).ToString

            'Condition
            Dim cond As String
            cond = table.Rows(0)(13).ToString

            'Period
            Dim period As String
            period = table.Rows(0)(14).ToString

            'Test Requested
            Dim testreqd As String
            testreqd = table.Rows(0)(15).ToString

            'Details of Test
            Dim dettest As String
            dettest = table.Rows(0)(16).ToString

            'Remarks
            Dim rmrk As String
            rmrk = table.Rows(0)(17).ToString

            'Requested By
            Dim reqby As String
            reqby = table.Rows(0)(19).ToString

            Dim ReportFont1 As Font = New Drawing.Font("Times New Roman", 10, FontStyle.Bold)
            Dim ReportFont2 As Font = New Drawing.Font("Times New Roman", 12, FontStyle.Bold)
            Dim ReportFont3 As Font = New Drawing.Font("Times New Roman", 11, FontStyle.Bold)
            Dim ReportFont4 As Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold)
            Dim ReportFont5 As Font = New Drawing.Font("Times New Roman", 10)
            Dim blackPen As New Pen(Color.Black, 1)
            e.Graphics.DrawString("Test Request No :", ReportFont1, Brushes.Black, 23, 39)
            e.Graphics.DrawString(Label1.Text, ReportFont5, Brushes.Black, 137, 40)

            e.Graphics.DrawString("Request Date :", ReportFont1, Brushes.Black, 537, 39)
            e.Graphics.DrawString(reqdate.ToString("dd/MM/yyyy"), ReportFont5, Brushes.Black, 633, 40)


            e.Graphics.DrawString("FORMULATION RESEARCH AND DEVELOPMENT", ReportFont2, Brushes.Black, 204, 108)
            e.Graphics.DrawString("V-Ensure Pharma Technologies Pvt Ltd", ReportFont3, Brushes.Black, 273, 130)
            e.Graphics.DrawString("Navi Mumbai", ReportFont3, Brushes.Black, 345, 151)
            e.Graphics.DrawString("TEST REQUISITION SHEET", ReportFont4, Brushes.Black, 259, 180)

            e.Graphics.DrawString("Print Copy No. :", ReportFont1, Brushes.Black, 610, 151)
            e.Graphics.DrawString(Label2.Text, ReportFont5, Brushes.Black, 722, 151)

            e.Graphics.DrawString("Product Code :", ReportFont1, Brushes.Black, 23, 223)
            e.Graphics.DrawString(procode, ReportFont5, Brushes.Black, 132, 223)



            e.Graphics.DrawString("Product Name :", ReportFont1, Brushes.Black, 225, 223)

            'e.Graphics.DrawRectangle(blackPen, 326, 210, 445, 40)
            'Dim rect1 As Rectangle = New Rectangle(326, 210, 445, 40)
            Dim StringFormat As StringFormat = New StringFormat()
            StringFormat.Alignment = StringAlignment.Near
            StringFormat.LineAlignment = StringAlignment.Center

            e.Graphics.DrawString(proname, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(326, 210, 445, 40), StringFormat)

            ' e.Graphics.DrawString(proname + " " + str, ReportFont5, Brushes.Black, 326, 223)

            e.Graphics.DrawString("Label Claim :", ReportFont1, Brushes.Black, 23, 262)

            e.Graphics.DrawString(lblclaim, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(112, 250, 670, 40), StringFormat)

            e.Graphics.DrawString("Batch No. :", ReportFont1, Brushes.Black, 23, 302)
            e.Graphics.DrawString(btno, ReportFont5, Brushes.Black, 100, 302)

            e.Graphics.DrawString("Batch Size :", ReportFont1, Brushes.Black, 225, 302)
            e.Graphics.DrawString(bsize, ReportFont5, Brushes.Black, 300, 302)

            e.Graphics.DrawString("Mfg Date :", ReportFont1, Brushes.Black, 440, 302)

            If String.IsNullOrEmpty(mfg) Or mfg = " " Then
                e.Graphics.DrawString("NA", ReportFont5, Brushes.Black, 513, 302)
            Else
                e.Graphics.DrawString(mfg, ReportFont5, Brushes.Black, 513, 302)
            End If

            e.Graphics.DrawString("Exp Date :", ReportFont1, Brushes.Black, 621, 302)
            If String.IsNullOrEmpty(exp) Or exp = " " Then
                e.Graphics.DrawString("NA", ReportFont5, Brushes.Black, 690, 303)
            Else
                e.Graphics.DrawString(exp, ReportFont5, Brushes.Black, 690, 303)
            End If

            e.Graphics.DrawString("Sample Qty :", ReportFont1, Brushes.Black, 23, 342)
            e.Graphics.DrawString(smplqty, ReportFont5, Brushes.Black, 111, 342)

            e.Graphics.DrawString("Pack :", ReportFont1, Brushes.Black, 280, 342)
            e.Graphics.DrawString(pack, ReportFont5, Brushes.Black, 325, 342)

            e.Graphics.DrawString("Period :", ReportFont1, Brushes.Black, 23, 381)
            e.Graphics.DrawString(period, ReportFont5, Brushes.Black, 80, 381)

            e.Graphics.DrawString("Condition :", ReportFont1, Brushes.Black, 280, 381)
            e.Graphics.DrawString(cond, ReportFont5, Brushes.Black, 355, 381)

            e.Graphics.DrawString("Test Requested :", ReportFont1, Brushes.Black, 23, 420)
            e.Graphics.DrawString(testreqd, ReportFont5, Brushes.Black, 133, 420)

            e.Graphics.DrawString("Details of Test :", ReportFont1, Brushes.Black, 23, 470)

            e.Graphics.DrawString(dettest, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(130, 450, 645, 50), StringFormat)

            e.Graphics.DrawString("Remarks :", ReportFont1, Brushes.Black, 23, 510)

            If String.IsNullOrEmpty(rmrk) Then
                e.Graphics.DrawString("Nil", ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            Else
                e.Graphics.DrawString(rmrk, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            End If

            e.Graphics.DrawString("Requested By :", ReportFont1, Brushes.Black, 23, 550)
            e.Graphics.DrawString(reqby, ReportFont5, Brushes.Black, 114, 550)
            e.Graphics.DrawString("Recieved By :", ReportFont1, Brushes.Black, 285, 550)
            e.Graphics.DrawString(homepageard.Label1.Text, ReportFont5, Brushes.Black, 370, 550)
            e.Graphics.DrawString("AR No :", ReportFont1, Brushes.Black, 515, 550)
            Dim arno As String
            arno = trno.Replace("T", "")
            e.Graphics.DrawString(arno, ReportFont5, Brushes.Black, 570, 550)

            e.Graphics.DrawString("STP No. :", ReportFont1, Brushes.Black, 23, 589)
            e.Graphics.DrawString("LNB Reference No :", ReportFont1, Brushes.Black, 515, 589)

            e.Graphics.DrawString("Sr No.", ReportFont1, Brushes.Black, 23, 623)
            e.Graphics.DrawString("Test", ReportFont1, Brushes.Black, 175, 623)
            e.Graphics.DrawString("Condition", ReportFont1, Brushes.Black, 390, 623)
            e.Graphics.DrawString("Result", ReportFont1, Brushes.Black, 635, 623)


            e.Graphics.DrawString("Analysed By :", ReportFont1, Brushes.Black, 26, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 26, 958)
            e.Graphics.DrawString("Checked By :", ReportFont1, Brushes.Black, 280, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 280, 958)
            e.Graphics.DrawString("Released By :", ReportFont1, Brushes.Black, 540, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 540, 958)

            'Print Cancelled Water Mark
            e.Graphics.DrawString("Cancelled", New Font("Time New Romans", 60, FontStyle.Regular), Brushes.LightGray, New PointF(200, 450))

            If con.State = ConnectionState.Open Then con.Close()
            Dim qry1 As String
            qry1 = "select trformatno from formatno where srno='1'"
            cmd1 = New SqlCommand(qry1, con)
            con.Open()
            Dim annexno As String
            annexno = cmd1.ExecuteScalar().ToString()
            con.Close()
            e.Graphics.DrawString(annexno, ReportFont3, Brushes.Black, 650, 1000)



            e.Graphics.DrawImage(PictureBox1.Image, 300, 65, PictureBox1.Width, PictureBox1.Height)

            'square 1
            e.Graphics.DrawRectangle(blackPen, 15, 35, 760, 855)

            'from 2nd top
            'line.1
            e.Graphics.DrawLine(blackPen, 15.0F, 63.0F, 775.0F, 63.0F)
            'line 2
            e.Graphics.DrawLine(blackPen, 15.0F, 173.0F, 775.0F, 173.0F)
            'line 3
            e.Graphics.DrawLine(blackPen, 15.0F, 211.0F, 775.0F, 211.0F)
            'line 4
            e.Graphics.DrawLine(blackPen, 15.0F, 250.0F, 775.0F, 250.0F)
            'line 5
            e.Graphics.DrawLine(blackPen, 15.0F, 290.0F, 775.0F, 290.0F)
            'line 6
            e.Graphics.DrawLine(blackPen, 15.0F, 330.0F, 775.0F, 330.0F)
            'line 7
            e.Graphics.DrawLine(blackPen, 15.0F, 370.0F, 775.0F, 370.0F)
            'line 8
            e.Graphics.DrawLine(blackPen, 15.0F, 410.0F, 775.0F, 410.0F)
            'line 9
            e.Graphics.DrawLine(blackPen, 15.0F, 450.0F, 775.0F, 450.0F)
            'line 10
            e.Graphics.DrawLine(blackPen, 15.0F, 500.0F, 775.0F, 500.0F)
            'line 11
            e.Graphics.DrawLine(blackPen, 15.0F, 540.0F, 775.0F, 540.0F)
            'line 12
            e.Graphics.DrawLine(blackPen, 15.0F, 580.0F, 775.0F, 580.0F)
            'line 13
            e.Graphics.DrawLine(blackPen, 15.0F, 615.0F, 775.0F, 615.0F)
            'line 14
            e.Graphics.DrawLine(blackPen, 15.0F, 645.0F, 775.0F, 645.0F)
            'line 15
            e.Graphics.DrawLine(blackPen, 15.0F, 945.0F, 775.0F, 945.0F)


            'from left side
            'at product name
            e.Graphics.DrawLine(blackPen, 218.0F, 211.0F, 218.0F, 250.0F)
            'at bacth size
            e.Graphics.DrawLine(blackPen, 218.0F, 290.0F, 218.0F, 330.0F)
            'at mfg date
            e.Graphics.DrawLine(blackPen, 430.0F, 290.0F, 430.0F, 330.0F)
            'at Exp Date
            e.Graphics.DrawLine(blackPen, 610.0F, 290.0F, 610.0F, 330.0F)
            'at pack
            e.Graphics.DrawLine(blackPen, 270.0F, 330.0F, 270.0F, 410.0F)
            'at Recieved by
            e.Graphics.DrawLine(blackPen, 280.0F, 540.0F, 280.0F, 580.0F)
            'at AR No.
            e.Graphics.DrawLine(blackPen, 510.0F, 540.0F, 510.0F, 615.0F)

            'at test
            e.Graphics.DrawLine(blackPen, 70.0F, 615.0F, 70.0F, 890.0F)
            'at condition
            e.Graphics.DrawLine(blackPen, 310.0F, 615.0F, 310.0F, 890.0F)
            'at result
            e.Graphics.DrawLine(blackPen, 550.0F, 615.0F, 550.0F, 890.0F)
            'at checked by
            e.Graphics.DrawLine(blackPen, 275.0F, 900.0F, 275.0F, 990.0F)
            'at released by
            e.Graphics.DrawLine(blackPen, 535.0F, 900.0F, 535.0F, 990.0F)
            'square 2
            e.Graphics.DrawRectangle(blackPen, 15, 900, 760, 90)

            'for number of pages
            'pageNo = pageNo + 1
            'e.HasMorePages = pageNo <= 3
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Dim PrinterStatus As String
    Private Sub GetPrinterStatus()
        Try
            Dim scope As ManagementScope = New ManagementScope("\root\cimv2")
            scope.Connect()
            Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_Printer")
            Dim collection As ManagementObjectCollection = searcher.Get
            For Each printer As ManagementObject In collection
                'MessageBox.Show(printer("WorkOffline").ToString(), cbPrinters.Text)
                If printer("Name").ToString() = Label3.Text Then

                    If printer("WorkOffline").ToString().ToLower().Equals("true") Then

                        PrinterStatus = "Offline"
                        'Label4.Text = PrinterStatus
                        'Label4.ForeColor = Color.Red
                    Else
                        PrinterStatus = "Online"
                        'Label4.Text = PrinterStatus
                        'Label4.ForeColor = Color.Green
                    End If

                End If
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadDefaultPrinter()
        Dim objSettings As New Printing.PrinterSettings
        Try

            Label3.Text = objSettings.PrinterName.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class