Imports System.Data.SqlClient
Public Class detailviewrld
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub detailviewrld_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadRLDDetails()
        GunaPanel2.Hide()
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
            If table.Rows(0)(10).ToString = "" Then
                Label10.Text = ""
            Else
                Dim expdate As Date = Date.ParseExact(table.Rows(0)(10), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label10.Text = expdate
            End If

            'recived qty
            Label11.Text = table.Rows(0)(11).ToString + " " + table.Rows(0)(12).ToString

            'balanace qty
            Label12.Text = table.Rows(0)(13).ToString

            'added by
            Label13.Text = table.Rows(0)(14).ToString
            'added on
            If table.Rows(0)(15).ToString = "" Then
                Label14.Text = ""
            Else
                Dim recdate As Date = Date.ParseExact(table.Rows(0)(15), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label14.Text = recdate
            End If
            'location
            Label15.Text = table.Rows(0)(16).ToString
            'remarks
            Label16.Text = table.Rows(0)(17).ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ViewInvoice()
    End Sub
    Private Sub ViewInvoice()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry1 As String
            qry1 = "select docs from rld_master where id='" + Label1.Text + "'"
            cmd = New SqlCommand(qry1, con)
            Dim sFilePath As String
            Dim buffer As Byte()
            con.Open()
            buffer = cmd.ExecuteScalar()
            con.Close()
            sFilePath = System.IO.Path.GetTempFileName()
            System.IO.File.Move(sFilePath, System.IO.Path.ChangeExtension(sFilePath, ".pdf"))
            sFilePath = System.IO.Path.ChangeExtension(sFilePath, ".pdf")
            System.IO.File.WriteAllBytes(sFilePath, buffer)
            'Form2.AxAcroPDF1.src = sFilePath + "#embedded=true&toolbar=0&navpanes=0"
            'Form2.ShowDialog()
            Dim act As Action(Of String) = New Action(Of String)(AddressOf OpenPDFFile)
            act.BeginInvoke(sFilePath, Nothing, Nothing)
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            MsgBox("Not Available", vbExclamation)
        End Try
    End Sub
    Private Shared Sub OpenPDFFile(ByVal sFilePath)
        Using p As New System.Diagnostics.Process
            p.StartInfo = New System.Diagnostics.ProcessStartInfo(sFilePath)
            p.Start()
            p.WaitForExit()
            Try
                System.IO.File.Delete(sFilePath)
            Catch
            End Try
        End Using
    End Sub
End Class