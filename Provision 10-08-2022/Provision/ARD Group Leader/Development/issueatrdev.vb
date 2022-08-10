Imports System.Data
Imports System.Data.SqlClient
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports System.Threading
Imports System.Diagnostics
Imports System.ComponentModel
Imports System
Imports System.Management


Public Class issueatrdev
    'Dim con As SqlConnection = New SqlConnection("Data Source=VE-IT\SQLEXPRESS;Initial Catalog=vensure;Integrated Security=True")
    Dim cmd1 As SqlCommand
    'Dim cmd2 As SqlCommand


    Private Sub issueatrdev_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadDefaultPrinter()
        LoadATRno()
        ' GetPrinterStatus()
        'Timer1.Enabled = True
        'Timer1.Start()
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 60, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub

    Private Sub LoadDefaultPrinter()
        Dim objSettings As New Printing.PrinterSettings
        Try

            TextBox4.Text = objSettings.PrinterName.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadATRno()
        Try

            If con.State = ConnectionState.Open Then con.Close()
            Dim qry As String
            qry = "SELECT * FROM productlistdoc where proname='" + TextBox1.Text + "' and test='" + TextBox2.Text + "'"
            cmd = New SqlCommand(qry, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            da.Fill(table)
            If table.Rows.Count = 0 Then
                MsgBox("ATR not available", vbCritical)
                Me.Close()
            Else
                Dim atrno As String
                Dim versno As String
                atrno = table.Rows(0)(10).ToString()
                versno = table.Rows(0)(11).ToString()
                If atrno = "" Then
                    MsgBox("ATR not available", vbCritical)
                    Me.Close()
                ElseIf atrno = "NA" Then
                    TextBox3.Text = "NA"
                    TextBox3.Text = "NA"
                Else
                    TextBox3.Text = atrno + "-" + versno
                End If

                Dim maxallowedtr As String = table.Rows(0)(16).ToString()
                Label1.Text = maxallowedtr
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim maxiss As String

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        If TextBox3.Text = "" Then
            MsgBox("ATR not available", vbCritical)
        ElseIf TextBox4.Text = "" Then
            MsgBox("Default Printer Not Set", vbCritical)
        ElseIf TextBox4.Text <> "Canon LBP6230/6240" Then
            MsgBox("Default Printer Not Set", vbCritical)
        ElseIf ListBox1.Items.Count = 0 Then
            MsgBox("Select TR Numbers before ATR isuue", vbCritical)
            ' ElseIf Label2.Text <> "Online" Then
            ' MsgBox("Printer is Offline", vbCritical)
        ElseIf ListBox1.Items.Count > Label1.Text Then
            MsgBox("Only " + Label1.Text + " TR Sheets are allowed in this ATR", vbCritical)

        Else
            Dim result As Integer = MessageBox.Show("Are you sure to print ATR", "Confirmation before printing", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.Yes Then

                Try
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim curValue As Integer
                    con.Open()
                    Dim cmd3 = New SqlCommand("select MAX(atrissueno) from atrissuelog where charindex('/22',atrissueno)>0", con)
                    maxiss = cmd3.ExecuteScalar()
                    Dim LastString_Year As String = DateTime.Now.Date.Year
                    LastString_Year = LastString_Year.Remove(1, 2)
                    If String.IsNullOrEmpty(maxiss) Then
                        maxiss = "0001/" + LastString_Year
                    Else
                        maxiss = maxiss.Substring(0, 4)
                        Int32.TryParse(maxiss, curValue)
                        curValue = curValue + 1
                        maxiss = curValue.ToString("D4") + "/" + LastString_Year
                    End If
                    openatr()
                    For Each item In ListBox1.Items
                        'add in atr issuence log
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd1 As New SqlCommand
                        cmd1.Connection = con
                        cmd1.CommandText = "insert into atrissuelog (proname,test,trno,atrno,atrissueno,issuedby,issueddate) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + item + "','" + TextBox3.Text + "','" + maxiss + "','" + homepageard.Label1.Text + "',@issueddate)"
                        cmd1.Parameters.AddWithValue("@issueddate", SqlDbType.Date).Value = DateTime.Now.Date
                        con.Open()
                        cmd1.ExecuteNonQuery()

                        'update in trdev 
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd2 As New SqlCommand
                        cmd2.Connection = con
                        cmd2.CommandText = "update trdev set lnbno='NA',atrno='" + TextBox3.Text + "',atrissueno='" + maxiss + "',atrissuedby='" + homepageard.Label1.Text + "',atrissueddate=@atrissueddate,Status='ATR Issued' where trno='" + item + "'"
                        cmd2.Parameters.AddWithValue("@atrissueddate", SqlDbType.Date).Value = DateTime.Now.Date
                        con.Open()
                        cmd2.ExecuteNonQuery()

                        'update in trrot
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd4 As New SqlCommand
                        cmd4.Connection = con
                        cmd4.CommandText = "update trrot set lnbno='NA',atrno='" + TextBox3.Text + "',atrissueno='" + maxiss + "',atrissuedby='" + homepageard.Label1.Text + "',atrissueddate=@atrissueddate,Status='ATR Issued' where trno='" + item + "'"
                        cmd4.Parameters.AddWithValue("@atrissueddate", SqlDbType.Date).Value = DateTime.Now.Date
                        con.Open()
                        cmd4.ExecuteNonQuery()

                        'update in trstb
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd5 As New SqlCommand
                        cmd5.Connection = con
                        cmd5.CommandText = "update trstb set lnbno='NA',atrno='" + TextBox3.Text + "',atrissueno='" + maxiss + "',atrissuedby='" + homepageard.Label1.Text + "',atrissueddate=@atrissueddate,Status='ATR Issued' where trno='" + item + "'"
                        cmd5.Parameters.AddWithValue("@atrissueddate", SqlDbType.Date).Value = DateTime.Now.Date
                        con.Open()
                        cmd5.ExecuteNonQuery()
                    Next

                    Dim f1 As newintimationarddev = DirectCast(Me.Owner, newintimationarddev)
                    f1.LoadIntimationDev()

                    Me.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If

        End If


    End Sub
    Dim totaltrs As String
    Private Sub openatr()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry2 As String
            qry2 = "select atrfile from productlistdoc where proname='" + TextBox1.Text + "' and test='" + TextBox2.Text + "'"
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
            Dim pages As Integer = reader.NumberOfPages

            FontFactory.RegisterDirectories()
            'Dim times As Font = FontFactory.GetFont("Times New Roman")

            Dim bf As BaseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, False)
            Dim timesnewroman As Font = New Font(bf, 11, Font.Bold, BaseColor.BLACK)

            'Cout Listbox TR Numbers
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
            Dim rect1 As Rectangle = New Rectangle(485, 820, 550, 40)
            Dim ct1 As ColumnText = New ColumnText(cb)
            ct1.SetSimpleColumn(rect1)
            ct1.AddElement(New Paragraph(maxiss, timesnewroman))
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

            For i As Integer = 1 To pages
                Dim page As PdfImportedPage = writer.GetImportedPage(reader, i)
                cb.AddTemplate(page, 0, 0)

                'issued by print on every page
                cb.Rectangle(195, 50, 180, 33)
                cb.Rectangle(192, 47, 186, 39)
                cb.Stroke()


                Dim bf1 As BaseFont = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
                cb.SetColorFill(BaseColor.BLACK)
                cb.SetFontAndSize(bf1, 10)
                cb.BeginText()
                cb.ShowTextAligned(1, "Issued By   : " + homepageard.Label1.Text, 265, 70, 0)
                cb.ShowTextAligned(1, "Issued Date : " + DateTime.Now.Date, 251, 55, 0)
                cb.EndText()


                document.NewPage()
            Next

            document.Close()
            fs.Close()
            writer.Close()
            reader.Close()

            Dim myProcess As Process = New Process
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
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
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If TextBox3.Text = "" Then
            MsgBox("ATR not available", vbCritical)
        ElseIf TextBox4.Text = "" Then
            MsgBox("Default Printer Not Set", vbCritical)
        ElseIf TextBox4.Text <> "Canon LBP6230/6240" Then
            MsgBox("Default Printer Not Set", vbCritical)
        ElseIf ListBox1.Items.Count = 0 Then
            MsgBox("Select TR Numbers before ATR isuue", vbCritical)
            ' ElseIf Label2.Text <> "Online" Then
            ' MsgBox("Printer is Offline", vbCritical)
        Else
            Dim form As New uptrinatrdev
            form.TextBox1.Text = TextBox1.Text
            form.TextBox2.Text = TextBox2.Text
            form.Label1.Text = Label1.Text
            For Each item In ListBox1.Items
                form.ListBox1.Items.Add(item)
            Next
            form.TextBox3.Text = TextBox3.Text

            form.ShowDialog()
            Me.Close()
        End If


    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs)
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "update productlistdoc set atrfile=@mdrfile where id=2"
        cmd1.Parameters.AddWithValue("@mdrfile", SqlDbType.VarBinary).Value = File.ReadAllBytes("D:\ATR-247-DS-04.pdf")
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub issueatrdev_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim f1 As newintimationarddev = DirectCast(Me.Owner, newintimationarddev)
        f1.LoadIntimationDev()
    End Sub

    Private Sub GunaGradientButton1_Click_1(sender As Object, e As EventArgs)
        Dim arno As String
        For i As Integer = 0 To ListBox1.Items.Count - 1
            arno = ListBox1.Items(i).Replace("T", "")
            totaltrs += arno + ";"
        Next
        totaltrs = totaltrs.Substring(0, totaltrs.Length - 1)

    End Sub
End Class