Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class addcommnetsdqa
    Private Sub addcommnetsdqa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.FromArgb(4, 145, 199), 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadComments()
    End Sub
    Public Sub LoadComments()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select id,comments,commentsby,commentsdate from stability_protocol_cmnts where ptn='" + Label1.Text + "'")
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Enter Comments", vbCritical)
        Else
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd3 As New SqlCommand
            cmd3.Connection = con
            cmd3.CommandText = "insert into stability_protocol_cmnts(ptn,comments,commentsby,commentsdate) values('" + Label1.Text + "','" + TextBox1.Text + "','" + homepage.Label1.Text + "',@commentsdate)"
            cmd3.Parameters.AddWithValue("@commentsdate", SqlDbType.Date).Value = DateTime.Now.Date
            con.Open()
            cmd3.ExecuteNonQuery()
            con.Close()
            LoadComments()
            UpdateProtocolStatus()
            SendMail_ProtocolComments()
            MsgBox("Comments Added", vbInformation)
            TextBox1.Clear()
        End If


    End Sub
    Private Sub SendMail_ProtocolComments()
        Try
            Dim email As New MailMessage()
            email.From = New MailAddress("m.srivastava@v-ensure.com")
            email.To.Add("frd1@v-ensure.com")
            email.CC.Add("saswat@v-ensure.com")
            email.CC.Add("g.pradhan@v-ensure.com")

            email.Subject = "Stability Protocol Review (Comments Added)"
            email.IsBodyHtml = True
            Dim sb As New System.Text.StringBuilder

            email.Body = "Hi..," +
            "<br />" +
            "<br />"
            email.Body += "You got new mail from provision for comments on your stability protcol. Please find the details below." +
            "<br />" +
            "<br />"
            sb.AppendLine("<html><body><" &
                "table border='1' cellpadding='10'>")
            sb.AppendLine("<tr>")
            'cteate table header
            sb.AppendLine("<align='center' valign='middle'><th>" + "Product Name" + "</th></td>")
            sb.AppendLine("<td align='center' valign='middle'>" + detailviewprotocoldqa.TextBox1.Text + "</td>")
            'create table body
            sb.AppendLine("<tr>")
            sb.AppendLine("<align='center' valign='middle'><th>" + "Protocol No." + "</th></td>")
            sb.AppendLine("<td align='center' valign='middle'>" + detailviewprotocoldqa.TextBox3.Text + "</td>")
            sb.AppendLine("</tr>")

            'table footer & end of html file
            sb.AppendLine("</table></body></html>")

            email.Body += sb.ToString() +
            "<br />" +
            "<br />"
            email.Body += "Regards," +
            "<br />" +
            homepage.Label1.Text +
            "<br />" +
            "This was an automated mail sent by the provision software"

            'email.Priority = MailPriority.Normal
            Dim smtp As New SmtpClient("smtp.gmail.com")
            smtp.Port = 587
            smtp.EnableSsl = True
            smtp.Credentials = New System.Net.NetworkCredential("m.srivastava@v-ensure.com", "zkaoqivgsltytcsh")
            smtp.Send(email)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub UpdateProtocolStatus()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd3 As New SqlCommand
        cmd3.Connection = con
        cmd3.CommandText = "update stability_protocol set status='Comments from Reviewer' where ptn='" + Label1.Text + "'"

        con.Open()
        cmd3.ExecuteNonQuery()
        con.Close()
    End Sub
    Private Sub addcommnetsdqa_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim f1 As detailviewprotocoldqa = DirectCast(Me.Owner, detailviewprotocoldqa)
        f1.Close()
    End Sub
End Class