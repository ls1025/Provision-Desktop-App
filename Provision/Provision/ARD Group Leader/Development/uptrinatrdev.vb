Imports System.Data
Imports System.Data.SqlClient
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports System.Threading
Imports System.Diagnostics
Imports System
Imports System.Management
Public Class uptrinatrdev
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim cmd2 As SqlCommand
    Private Sub uptrinatrdev_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 60, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

        LoadDefaultPrinter()
        'GetPrinterStatus()
        loadrunningatrissno()
        'Timer1.Enabled = True
        ' Timer1.Start()
    End Sub
    Dim PrinterStatus As String
    Private Sub GetPrinterStatus()
        Try
            Dim scope As ManagementScope = New ManagementScope("\root\cimv2")
            scope.Connect()
            Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_Printer")
            Dim collection As ManagementObjectCollection = searcher.Get
            For Each printer As ManagementObject In collection

                If printer("Name").ToString() = TextBox5.Text Then
                    If printer("WorkOffline").ToString().ToLower().Equals("true") Then
                        PrinterStatus = "Offline"
                        ' Label2.Text = PrinterStatus
                        'Label2.ForeColor = Color.Red
                    Else
                        PrinterStatus = "Online"
                        ' Label2.Text = PrinterStatus
                        ' Label2.ForeColor = Color.Green
                    End If

                End If
            Next
            ' Label2.Text = PrinterStatus
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadDefaultPrinter()
        Dim objSettings As New Printing.PrinterSettings
        Try

            TextBox5.Text = objSettings.PrinterName.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub loadrunningatrissno()
        ListBox2.Items.Clear()
        Try
            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim reader As SqlDataReader
            con.Open()
            Dim qry As String
            qry = "select DISTINCT(atrissueno) from trdev where [productname]='" + TextBox1.Text + "' and [test]='" + TextBox2.Text + "' and [atrissueno] IS NOT NULL and [Status]='ATR Issued' union select DISTINCT(atrissueno) from trrot where [productname]='" + TextBox1.Text + "' and [test]='" + TextBox2.Text + "' and [atrissueno] IS NOT NULL and [Status]='ATR Issued' union select DISTINCT(atrissueno) from trstb where [productname]='" + TextBox1.Text + "' and [test]='" + TextBox2.Text + "' and [atrissueno] IS NOT NULL and [Status]='ATR Issued'"
            cmd = New SqlCommand(qry, con)
            reader = cmd.ExecuteReader
            While reader.Read
                ListBox2.Items.Add(reader("atrissueno"))
            End While

            For Row As Int16 = 0 To ListBox2.Items.Count - 2
                For RowAgain As Int16 = ListBox2.Items.Count - 1 To Row + 1 Step -1
                    If ListBox2.Items(Row).ToString = ListBox2.Items(RowAgain).ToString Then
                        ListBox2.Items.RemoveAt(RowAgain)
                    End If
                Next
            Next

        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Dim TotalTRCount As Integer
    Dim a As Integer
    Private Sub CountTR()
        If con.State = ConnectionState.Open Then con.Close()
        Dim qry As String
        qry = "select COUNT(trno) from atrissuelog where atrissueno='" + TextBox4.Text + "' "
        cmd1 = New SqlCommand(qry, con)
        con.Open()
        a = cmd1.ExecuteScalar()
        con.Close()

        Dim currentTRCount As Integer = ListBox1.Items.Count
        TotalTRCount = a + currentTRCount

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'CountTR()
        'MsgBox(Label1.Text)
        If con.State = ConnectionState.Open Then con.Close()
        If TextBox3.Text = "" Then
            MsgBox("ATR is Not Avialable", vbCritical)
        ElseIf TextBox4.Text = "" Then
            MsgBox("Please select running ATR issuance number", vbCritical)
        ElseIf TextBox5.Text = "" Then
            MsgBox("Default Printer Not Set", vbCritical)
        ElseIf TextBox5.Text <> "Canon LBP6230/6240" Then
            MsgBox("Default Printer Not Set", vbCritical)
        ElseIf TotalTRCount > Label1.Text Then
            MsgBox("Only " + Label1.Text + " TR Sheets are allowed in this ATR", vbCritical)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure to submit", "Confirmation before sending", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.Yes Then
                openatr()
                For Each item In ListBox1.Items
                    If con.State = ConnectionState.Open Then con.Close()
                    'add atr issuence log
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd1 As New SqlCommand
                    cmd1.Connection = con
                    cmd1.CommandText = "insert into atrissuelog (proname,test,trno,atrno,atrissueno,issuedby,issueddate) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + item + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + homepageard.Label1.Text + "',@issueddate)"
                    cmd1.Parameters.AddWithValue("@issueddate", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd1.ExecuteNonQuery()

                    'update in trdev 
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd2 As New SqlCommand
                    cmd2.Connection = con
                    cmd2.CommandText = "update trdev set lnbno='NA',atrno='" + TextBox3.Text + "',atrissueno='" + TextBox4.Text + "',atrissuedby='" + homepageard.Label1.Text + "',atrissueddate=@atrissueddate,Status='ATR Issued' where trno='" + item + "'"
                    cmd2.Parameters.AddWithValue("@atrissueddate", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd2.ExecuteNonQuery()

                    'update in routine 
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd4 As New SqlCommand
                    cmd4.Connection = con
                    cmd4.CommandText = "update trrot set lnbno='NA',atrno='" + TextBox3.Text + "',atrissueno='" + TextBox4.Text + "',atrissuedby='" + homepageard.Label1.Text + "',atrissueddate=@atrissueddate,Status='ATR Issued' where trno='" + item + "'"
                    cmd4.Parameters.AddWithValue("@atrissueddate", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd4.ExecuteNonQuery()

                    'update in stability 
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd5 As New SqlCommand
                    cmd5.Connection = con
                    cmd5.CommandText = "update trstb set lnbno='NA',atrno='" + TextBox3.Text + "',atrissueno='" + TextBox4.Text + "',atrissuedby='" + homepageard.Label1.Text + "',atrissueddate=@atrissueddate,Status='ATR Issued' where trno='" + item + "'"
                    cmd5.Parameters.AddWithValue("@atrissueddate", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd5.ExecuteNonQuery()
                Next

                Me.Close()

            End If



        End If

    End Sub
    Dim totaltrs As String
    Private Sub openatr()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry2 As String
            qry2 = "select atrfile from productlistdoc where proname='" + TextBox1.Text + "' and Test='" + TextBox2.Text + "'"
            cmd1 = New SqlCommand(qry2, con)
            Dim sFilePath As String
            Dim buffer As Byte()
            con.Open()
            buffer = cmd1.ExecuteScalar()
            con.Close()
            sFilePath = System.IO.Path.GetTempFileName()
            System.IO.File.Move(sFilePath, System.IO.Path.ChangeExtension(sFilePath, ".pdf"))
            sFilePath = System.IO.Path.ChangeExtension(sFilePath, ".pdf")
            System.IO.File.WriteAllBytes(sFilePath, buffer)

            Dim oldFile As String = sFilePath

            Dim newfile As String = System.IO.Path.GetTempFileName()
            System.IO.File.Move(newfile, System.IO.Path.ChangeExtension(newfile, ".pdf"))
            newfile = System.IO.Path.ChangeExtension(newfile, ".pdf")


            Dim reader As New PdfReader(oldFile)
            Dim size As Rectangle = reader.GetPageSizeWithRotation(1)
            Dim document As New Document(size)
            ' Create the writer
            Dim fs As New FileStream(newfile, FileMode.Create, FileAccess.Write)
            Dim writer As PdfWriter = PdfWriter.GetInstance(document, fs)
            document.Open()
            Dim cb As PdfContentByte = writer.DirectContent

            FontFactory.RegisterDirectories()
            'Dim times As Font = FontFactory.GetFont("Times New Roman")

            Dim bf As BaseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False)
            Dim timesnewroman As Font = New Font(bf, 11, Font.Bold, BaseColor.BLACK)

            'Count Listbox TR Numbers
            cb.BeginText()
            Dim rect As Rectangle = New Rectangle(175, 610, 557, 80)
            Dim ct As ColumnText = New ColumnText(cb)

            Dim arno As String
            For i As Integer = 0 To ListBox1.Items.Count - 1
                arno = ListBox1.Items(i).Replace("T", "")
                totaltrs += arno + ";"
            Next
            totaltrs = totaltrs.Substring(0, totaltrs.Length - 1)

            ct.SetSimpleColumn(rect)
            ct.AddElement(New Paragraph(totaltrs, timesnewroman))
            ct.Go()
            cb.EndText()

            'atr issuance number print
            cb.BeginText()
            Dim rect1 As Rectangle = New Rectangle(485, 820, 550, 60)
            Dim ct1 As ColumnText = New ColumnText(cb)
            ct1.SetSimpleColumn(rect1)
            ct1.AddElement(New Paragraph(TextBox4.Text, timesnewroman))
            ct1.Go()
            cb.EndText()

            'date print
            cb.BeginText()
            Dim rect3 As Rectangle = New Rectangle(175, 538, 550, 60)
            Dim ct3 As ColumnText = New ColumnText(cb)
            ct3.SetSimpleColumn(rect3)
            ct3.AddElement(New Paragraph(Today.Date, timesnewroman))
            ct3.Go()
            cb.EndText()

            Dim gs1 As PdfGState = New PdfGState()
            gs1.BlendMode = New PdfName("Darken")
            cb.SetGState(gs1)

            Dim page As PdfImportedPage = writer.GetImportedPage(reader, 1)
            cb.AddTemplate(page, 0, 0)
            cb.Rectangle(195, 50, 180, 33)
            cb.Rectangle(192, 47, 186, 39)
            cb.Stroke()


            Dim bf1 As BaseFont = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
            cb.SetColorFill(BaseColor.BLACK)
            cb.SetFontAndSize(bf1, 10)
            cb.BeginText()
            cb.ShowTextAligned(1, "Amendment", 300, 150, 0)
            cb.ShowTextAligned(1, "Issued By   : " + homepageard.Label1.Text, 265, 70, 0)
            cb.ShowTextAligned(1, "Issued Date : " + DateTime.Now.Date, 251, 55, 0)
            cb.EndText()

            document.Close()
            fs.Close()
            writer.Close()
            reader.Close()

            Dim myProcess As Process = New Process
            'myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            myProcess.StartInfo.FileName = newfile
            myProcess.StartInfo.Verb = "Print"
            myProcess.StartInfo.UseShellExecute = True
            myProcess.Start()
            myProcess.WaitForInputIdle()

            If myProcess.Responding Then
                myProcess.CloseMainWindow()
            Else
                myProcess.Kill()
            End If

            MsgBox("ATR Issued Successfully", vbInformation)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        TextBox4.Text = ListBox2.SelectedItem
        CountTR()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GetPrinterStatus()
    End Sub
End Class