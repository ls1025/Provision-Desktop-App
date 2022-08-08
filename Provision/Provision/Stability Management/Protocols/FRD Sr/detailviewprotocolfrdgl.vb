Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class detailviewprotocolfrdgl
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub detailviewprotocolfrdgl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.FromArgb(4, 145, 199), 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadProtocol_Master()

        If Label7.Text = "Submitted for Approval" Then
            Button1.Visible = True
        Else
            Label7.Visible = False
        End If
    End Sub
    Public Sub LoadProtocol_Master()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con

            da = New SqlDataAdapter("Select * from  stability_protocol where [ptn]= '" + TextBox3.Text + "' ", con)
            Dim table As New DataTable()
            da.Fill(table)

            TextBox1.Text = table.Rows(0)(1).ToString + " " + table.Rows(0)(2).ToString
            TextBox2.Text = table.Rows(0)(5).ToString
            TextBox3.Text = table.Rows(0)(3).ToString
            TextBox4.Text = table.Rows(0)(4).ToString

            If table.Rows(0)(9).ToString = "" Then
                Label1.Text = ""
            Else
                Dim chrgdate As Date = Date.ParseExact(table.Rows(0)(9), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label1.Text = chrgdate
            End If


            Label2.Text = table.Rows(0)(6).ToString
            Label3.Text = table.Rows(0)(7).ToString
            Label4.Text = table.Rows(0)(8).ToString

            TextBox5.Text = table.Rows(0)(10).ToString

            Label5.Text = table.Rows(0)(11).ToString


            If table.Rows(0)(12).ToString = "" Then
                Label6.Text = ""
            Else
                Dim withon As Date = Date.ParseExact(table.Rows(0)(12), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label6.Text = withon
            End If


            Label7.Text = table.Rows(0)(17).ToString

            If Label7.Text = "Approved" Then
                Label7.ForeColor = Color.Green
            Else
                Label7.ForeColor = Color.Red
            End If


            LoadProtocol_Schedule()
            LoadProtocol_MC()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub LoadProtocol_Schedule()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select id,sampleqty,pccnt,ornt,cndn,sch,podate from stability_protocol_sch where ptn='" + TextBox3.Text + "'")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
            dgv1_rowstyle()
            DataGridView1.CurrentCell = Nothing

        Catch ex As Exception

        End Try
    End Sub
    Public Sub LoadProtocol_MC()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select id,parameter,detail from stability_protocol_mc where ptn='" + TextBox3.Text + "'")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView2.DataSource = table1
            dgv1_rowstyle()
            DataGridView2.CurrentCell = Nothing

        Catch ex As Exception

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
    Public Sub dgv2_rowstyle()
        For i As Integer = 0 To DataGridView2.RowCount - 1
            If i Mod 2 = 0 Then
                DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If

        Next
        DataGridView2.CurrentCell = Nothing
    End Sub
    Private Sub DataGridView2_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView2.ColumnHeaderMouseClick
        dgv2_rowstyle()
    End Sub
    Private Sub DataGridView2_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView2.DataSourceChanged
        dgv2_rowstyle()
    End Sub
    Private Sub SendMail_ProtocolApproved()
        Try
            Dim email As New MailMessage()
            email.From = New MailAddress("saswat@v-ensure.com")
            email.To.Add("frd1@v-ensure.com")
            email.CC.Add("m.srivastava@v-ensure.com")
            email.CC.Add("g.pradhan@v-ensure.com")

            email.Subject = "Stability Protocol Approved"
            email.IsBodyHtml = True
            Dim sb As New System.Text.StringBuilder

            email.Body = "Hi..," +
            "<br />" +
            "<br />"
            email.Body += "Your stability protcol has been approved by '" + Homepagefrdgl.Label1.Text + "'. Please find the details below." +
            "<br />" +
            "<br />"
            sb.AppendLine("<html><body><" &
                "table border='1' cellpadding='10'>")
            sb.AppendLine("<tr>")
            'cteate table header
            sb.AppendLine("<align='center' valign='middle'><th>" + "Product Name" + "</th></td>")
            sb.AppendLine("<td align='center' valign='middle'>" + TextBox1.Text + "</td>")
            'create table body
            sb.AppendLine("<tr>")
            sb.AppendLine("<align='center' valign='middle'><th>" + "Protocol No." + "</th></td>")
            sb.AppendLine("<td align='center' valign='middle'>" + TextBox3.Text + "</td>")
            sb.AppendLine("</tr>")

            'table footer & end of html file
            sb.AppendLine("</table></body></html>")

            email.Body += sb.ToString() +
            "<br />" +
            "<br />"
            email.Body += "Regards," +
            "<br />" +
            Homepagefrdgl.Label1.Text +
            "<br />" +
            "This was an automated mail sent by the provision software"

            'email.Priority = MailPriority.Normal
            Dim smtp As New SmtpClient("smtp.gmail.com")
            smtp.Port = 587
            smtp.EnableSsl = True
            smtp.Credentials = New System.Net.NetworkCredential("frd1@v-ensure.com", "iertksvdwuuuqezx")
            smtp.Send(email)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Parameters.Clear()
            cmd.Connection = con
            cmd.CommandText = "update stability_protocol set approvedby='" + Homepagefrdgl.Label1.Text + "',approveddate=@approveddate,status='Approved' where ptn='" + TextBox3.Text + "'"
            cmd.Parameters.AddWithValue("@approveddate", SqlDbType.Date).Value = DateTime.Now.Date
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            UpadteInPlnr()
            SendMail_ProtocolApproved()
            MsgBox("Protocol Approved Successfully", vbInformation)
            Dim f1 As viewstabilityprotocolfrdgl = DirectCast(Me.Owner, viewstabilityprotocolfrdgl)
            f1.LoadProtocols()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub UpadteInPlnr()
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub GunaCircleButton1_MouseHover(sender As Object, e As EventArgs) Handles GunaCircleButton1.MouseHover
        Guna2HtmlToolTip1.Show("View or Add Comments", GunaCircleButton1)
    End Sub

    Private Sub GunaCircleButton1_Click(sender As Object, e As EventArgs) Handles GunaCircleButton1.Click

        Dim form As New viewcomments
        form.Label1.Text = TextBox3.Text
        form.Panel1.Hide()
        form.ShowDialog()


    End Sub
End Class