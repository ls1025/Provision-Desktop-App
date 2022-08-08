Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail

Public Class addprotocol
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub addprotocol_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        loadpackstyle()
        Panel7.Hide()
        Panel8.Hide()
        Panel19.Hide()
        Panel25.Hide()
        Panel31.Hide()
        Panel37.Hide()
        'hidecheck()
        DateTimePicker1.Value = DateTime.Now
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.FromArgb(4, 145, 199), 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

    End Sub
    Private Sub loadpackstyle()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select pack from pack order by [pack] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                GunaComboBox1.Items.Add(dr("pack"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SendMail_ProtocolReview()
        Try
            Dim email As New MailMessage()
            email.From = New MailAddress("frd1@v-ensure.com")
            email.To.Add("m.srivastava@v-ensure.com")
            email.CC.Add("saswat@v-ensure.com")
            email.CC.Add("g.pradhan@v-ensure.com")

            email.Subject = "Stability Protocol for Review"
            email.IsBodyHtml = True
            Dim sb As New System.Text.StringBuilder

            email.Body = "Hi..," +
            "<br />" +
            "<br />"
            email.Body += "You got new mail from provision for review of stability protcol. Please find the details below." +
            "<br />" +
            "<br />"
            sb.AppendLine("<html><body><" &
                "table border='1' cellpadding='10'>")
            sb.AppendLine("<tr>")
            'cteate table header
            sb.AppendLine("<align='center' valign='middle'><th>" + "Product Name" + "</th></td>")
            sb.AppendLine("<td align='center' valign='middle'>" + ComboBox1.Text + " " + GunaTextBox1.Text + "</td>")
            'create table body
            sb.AppendLine("<tr>")
            sb.AppendLine("<align='center' valign='middle'><th>" + "Protocol No." + "</th></td>")
            sb.AppendLine("<td align='center' valign='middle'>" + TextBox2.Text + "</td>")
            sb.AppendLine("</tr>")

            'table footer & end of html file
            sb.AppendLine("</table></body></html>")

            email.Body += sb.ToString() +
            "<br />" +
            "<br />"
            email.Body += "Regards," +
            "<br />" +
            Homepagefrdj.Label1.Text +
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
            If ComboBox1.Text = "" Then
                MsgBox("Select Product Name", vbCritical)
            ElseIf TextBox2.Text = "" Then
                MsgBox("Enter Protocol Number", vbCritical)
            ElseIf GunaComboBox1.Text = "" Then
                MsgBox("Enter Pack Style", vbCritical)
            ElseIf TextBox1.Text = "" Then
                MsgBox("Enter Batch Number", vbCritical)
            ElseIf GunaTextBox5.Text = "" Then
                MsgBox("Enter API Batch Number", vbCritical)
            ElseIf GunaTextBox6.Text = "" Then
                MsgBox("Enter Manufacturing Number", vbCritical)
            ElseIf GunaTextBox7.Text = "" Then
                MsgBox("Enter Expiry/Retest Number", vbCritical)
            ElseIf ComboBox2.Text = "" Then
                MsgBox("Select number Of Conditions", vbCritical)
            ElseIf DataGridView1.Rows.Count <= 0 Then
                MsgBox("Add Material Of Construction detials", vbCritical)
            ElseIf ComboBox2.Text = "1" Then
                If TextBox4.Text = "" Then
                    MsgBox("Enter Sample Quantity", vbCritical)
                ElseIf TextBox5.Text = "" Then
                    MsgBox("Enter pack count", vbCritical)
                ElseIf TextBox22.Text = "" Then
                    MsgBox("Enter Orientation", vbCritical)
                ElseIf ComboBox3.Text = "" Then
                    MsgBox("Select condition", vbCritical)
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False And CheckBox8.Checked = False And CheckBox9.Checked = False And CheckBox10.Checked = False And CheckBox11.Checked = False And CheckBox12.Checked = False And A7.Checked = False And A14.Checked = False And A21.Checked = False And A28.Checked = False Then
                    MsgBox("Select atleast one period", vbCritical)
                Else
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry As String
                    qry = "Select COUNT(ptn) from stability_protocol where ptn='" + TextBox2.Text + "'"
                    cmd1 = New SqlCommand(qry, con)
                    con.Open()
                    Dim SameProtocol As Integer
                    SameProtocol = cmd1.ExecuteScalar()
                    If SameProtocol = 0 Then
                        Me.Cursor = Cursors.WaitCursor
                        Add_Protocol()
                        Add_MaterialofConstruction()
                        one_batch()
                        SendMail_ProtocolReview()
                        MsgBox("Protocol Added Successfully", vbInformation)
                        Dim f1 As viewstabilityprotocol = DirectCast(Me.Owner, viewstabilityprotocol)
                        f1.LoadProtocols()
                        Me.Close()
                    Else
                        MsgBox("Protocol Already Added for this Batch", vbCritical)
                    End If
                End If
            ElseIf ComboBox2.Text = "2" Then
                If TextBox4.Text = "" Then
                    MsgBox("Enter First Sample Quantity", vbCritical)
                ElseIf TextBox5.Text = "" Then
                    MsgBox("Enter First pack count", vbCritical)
                ElseIf TextBox22.Text = "" Then
                    MsgBox("Enter First Orientation", vbCritical)
                ElseIf ComboBox3.Text = "" Then
                    MsgBox("Select First condition", vbCritical)
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False And CheckBox8.Checked = False And CheckBox9.Checked = False And CheckBox10.Checked = False And CheckBox11.Checked = False And CheckBox12.Checked = False And A7.Checked = False And A14.Checked = False And A21.Checked = False And A28.Checked = False Then
                    MsgBox("Select atleast one period in first entry", vbCritical)
                ElseIf TextBox7.Text = "" Then
                    MsgBox("Enter second Sample Quantity", vbCritical)
                ElseIf TextBox8.Text = "" Then
                    MsgBox("Enter second pack count", vbCritical)
                ElseIf TextBox23.Text = "" Then
                    MsgBox("Enter Second Orientation", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select second condition", vbCritical)
                ElseIf CheckBox13.Checked = False And CheckBox14.Checked = False And CheckBox15.Checked = False And CheckBox16.Checked = False And CheckBox17.Checked = False And CheckBox18.Checked = False And CheckBox19.Checked = False And CheckBox20.Checked = False And CheckBox21.Checked = False And CheckBox22.Checked = False And CheckBox23.Checked = False And CheckBox24.Checked = False And B7.Checked = False And B14.Checked = False And B21.Checked = False And B28.Checked = False Then
                    MsgBox("Select atleast one period in second entry", vbCritical)
                Else
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry As String
                    qry = "select COUNT(ptn) from stability_protocol where ptn='" + TextBox2.Text + "'"
                    cmd1 = New SqlCommand(qry, con)
                    con.Open()
                    Dim SameProtocol As Integer
                    SameProtocol = cmd1.ExecuteScalar()
                    If SameProtocol = 0 Then
                        Me.Cursor = Cursors.WaitCursor
                        Add_Protocol()
                        Add_MaterialofConstruction()
                        one_batch()
                        two_batch()
                        SendMail_ProtocolReview()
                        MsgBox("Protocol Added Successfully", vbInformation)
                        Dim f1 As viewstabilityprotocol = DirectCast(Me.Owner, viewstabilityprotocol)
                        f1.LoadProtocols()
                        Me.Close()
                    Else
                        MsgBox("Planne Already Added for this Batch", vbCritical)
                    End If
                End If
            ElseIf ComboBox2.Text = "3" Then
                If TextBox4.Text = "" Then
                    MsgBox("Enter First Sample Quantity", vbCritical)
                ElseIf TextBox5.Text = "" Then
                    MsgBox("Enter First pack count", vbCritical)
                ElseIf TextBox22.Text = "" Then
                    MsgBox("Enter First Orientation", vbCritical)
                ElseIf ComboBox3.Text = "" Then
                    MsgBox("Select First condition", vbCritical)
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False And CheckBox8.Checked = False And CheckBox9.Checked = False And CheckBox10.Checked = False And CheckBox11.Checked = False And CheckBox12.Checked = False And A7.Checked = False And A14.Checked = False And A21.Checked = False And A28.Checked = False Then
                    MsgBox("Select atleast one period in first entry", vbCritical)
                ElseIf TextBox7.Text = "" Then
                    MsgBox("Enter second Sample Quantity", vbCritical)
                ElseIf TextBox8.Text = "" Then
                    MsgBox("Enter second pack count", vbCritical)
                ElseIf TextBox23.Text = "" Then
                    MsgBox("Enter Second Orientation", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select second condition", vbCritical)
                ElseIf CheckBox13.Checked = False And CheckBox14.Checked = False And CheckBox15.Checked = False And CheckBox16.Checked = False And CheckBox17.Checked = False And CheckBox18.Checked = False And CheckBox19.Checked = False And CheckBox20.Checked = False And CheckBox21.Checked = False And CheckBox22.Checked = False And CheckBox23.Checked = False And CheckBox24.Checked = False And B7.Checked = False And B14.Checked = False And B21.Checked = False And B28.Checked = False Then
                    MsgBox("Select atleast one period in second entry", vbCritical)
                ElseIf TextBox10.Text = "" Then
                    MsgBox("Enter Third Sample Quantity", vbCritical)
                ElseIf TextBox11.Text = "" Then
                    MsgBox("Enter Third pack count", vbCritical)
                ElseIf TextBox24.Text = "" Then
                    MsgBox("Enter Third Orientation", vbCritical)
                ElseIf ComboBox5.Text = "" Then
                    MsgBox("Select Third condition", vbCritical)
                ElseIf CheckBox25.Checked = False And CheckBox26.Checked = False And CheckBox27.Checked = False And CheckBox28.Checked = False And CheckBox29.Checked = False And CheckBox30.Checked = False And CheckBox31.Checked = False And CheckBox32.Checked = False And CheckBox33.Checked = False And CheckBox34.Checked = False And CheckBox35.Checked = False And CheckBox36.Checked = False And C7.Checked = False And C14.Checked = False And C21.Checked = False And C28.Checked = False Then
                    MsgBox("Select atleast one period in third entry", vbCritical)
                Else
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry As String
                    qry = "select COUNT(ptn) from stability_protocol where ptn='" + TextBox2.Text + "'"
                    cmd1 = New SqlCommand(qry, con)
                    con.Open()
                    Dim SameProtocol As Integer
                    SameProtocol = cmd1.ExecuteScalar()
                    If SameProtocol = 0 Then
                        Me.Cursor = Cursors.WaitCursor
                        Add_Protocol()
                        Add_MaterialofConstruction()
                        one_batch()
                        two_batch()
                        three_batch()
                        SendMail_ProtocolReview()
                        MsgBox("Protocol Added Successfully", vbInformation)
                        Dim f1 As viewstabilityprotocol = DirectCast(Me.Owner, viewstabilityprotocol)
                        f1.LoadProtocols()
                        Me.Close()
                    Else
                        MsgBox("Planne Already Added for this Batch", vbCritical)
                    End If
                End If
            ElseIf ComboBox2.Text = "4" Then
                If TextBox4.Text = "" Then
                    MsgBox("Enter First Sample Quantity", vbCritical)
                ElseIf TextBox5.Text = "" Then
                    MsgBox("Enter First pack count", vbCritical)
                ElseIf TextBox22.Text = "" Then
                    MsgBox("Enter First Orientation", vbCritical)
                ElseIf ComboBox3.Text = "" Then
                    MsgBox("Select First condition", vbCritical)
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False And CheckBox8.Checked = False And CheckBox9.Checked = False And CheckBox10.Checked = False And CheckBox11.Checked = False And CheckBox12.Checked = False And A7.Checked = False And A14.Checked = False And A21.Checked = False And A28.Checked = False Then
                    MsgBox("Select atleast one period in first entry", vbCritical)
                ElseIf TextBox7.Text = "" Then
                    MsgBox("Enter second Sample Quantity", vbCritical)
                ElseIf TextBox8.Text = "" Then
                    MsgBox("Enter second pack count", vbCritical)
                ElseIf TextBox23.Text = "" Then
                    MsgBox("Enter Second Orientation", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select second condition", vbCritical)
                ElseIf CheckBox13.Checked = False And CheckBox14.Checked = False And CheckBox15.Checked = False And CheckBox16.Checked = False And CheckBox17.Checked = False And CheckBox18.Checked = False And CheckBox19.Checked = False And CheckBox20.Checked = False And CheckBox21.Checked = False And CheckBox22.Checked = False And CheckBox23.Checked = False And CheckBox24.Checked = False And B7.Checked = False And B14.Checked = False And B21.Checked = False And B28.Checked = False Then
                    MsgBox("Select atleast one period in second entry", vbCritical)
                ElseIf TextBox10.Text = "" Then
                    MsgBox("Enter Third Sample Quantity", vbCritical)
                ElseIf TextBox11.Text = "" Then
                    MsgBox("Enter Third pack count", vbCritical)
                ElseIf TextBox24.Text = "" Then
                    MsgBox("Enter Third Orientation", vbCritical)
                ElseIf ComboBox5.Text = "" Then
                    MsgBox("Select Third condition", vbCritical)
                ElseIf CheckBox25.Checked = False And CheckBox26.Checked = False And CheckBox27.Checked = False And CheckBox28.Checked = False And CheckBox29.Checked = False And CheckBox30.Checked = False And CheckBox31.Checked = False And CheckBox32.Checked = False And CheckBox33.Checked = False And CheckBox34.Checked = False And CheckBox35.Checked = False And CheckBox36.Checked = False And C7.Checked = False And C14.Checked = False And C21.Checked = False And C28.Checked = False Then
                    MsgBox("Select atleast one period in third entry", vbCritical)
                ElseIf TextBox13.Text = "" Then
                    MsgBox("Enter fourth Sample Quantity", vbCritical)
                ElseIf TextBox14.Text = "" Then
                    MsgBox("Enter fourth pack count", vbCritical)
                ElseIf TextBox25.Text = "" Then
                    MsgBox("Enter fourth Orientation", vbCritical)
                ElseIf ComboBox6.Text = "" Then
                    MsgBox("Select fourth condition", vbCritical)
                ElseIf CheckBox37.Checked = False And CheckBox38.Checked = False And CheckBox39.Checked = False And CheckBox40.Checked = False And CheckBox41.Checked = False And CheckBox42.Checked = False And CheckBox43.Checked = False And CheckBox44.Checked = False And CheckBox45.Checked = False And CheckBox46.Checked = False And CheckBox47.Checked = False And CheckBox48.Checked = False And D7.Checked = False And D14.Checked = False And D21.Checked = False And D28.Checked = False Then
                    MsgBox("Select atleast one period in fourth entry", vbCritical)
                Else
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry As String
                    qry = "select COUNT(ptn) from stability_protocol where ptn='" + TextBox2.Text + "'"
                    cmd1 = New SqlCommand(qry, con)
                    con.Open()
                    Dim SameProtocol As Integer
                    SameProtocol = cmd1.ExecuteScalar()
                    If SameProtocol = 0 Then
                        Me.Cursor = Cursors.WaitCursor
                        Add_Protocol()
                        Add_MaterialofConstruction()
                        one_batch()
                        two_batch()
                        three_batch()
                        foure_batch()
                        SendMail_ProtocolReview()
                        MsgBox("Protocol Added Successfully", vbInformation)
                        Dim f1 As viewstabilityprotocol = DirectCast(Me.Owner, viewstabilityprotocol)
                        f1.LoadProtocols()
                        Me.Close()
                    Else
                        MsgBox("Planne Already Added for this Batch", vbCritical)
                    End If
                End If
            ElseIf ComboBox2.Text = "5" Then
                If TextBox4.Text = "" Then
                    MsgBox("Enter First Sample Quantity", vbCritical)
                ElseIf TextBox5.Text = "" Then
                    MsgBox("Enter First pack count", vbCritical)
                ElseIf TextBox22.Text = "" Then
                    MsgBox("Enter First Orientation", vbCritical)
                ElseIf ComboBox3.Text = "" Then
                    MsgBox("Select First condition", vbCritical)
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False And CheckBox8.Checked = False And CheckBox9.Checked = False And CheckBox10.Checked = False And CheckBox11.Checked = False And CheckBox12.Checked = False And A7.Checked = False And A14.Checked = False And A21.Checked = False And A28.Checked = False Then
                    MsgBox("Select atleast one period in first entry", vbCritical)
                ElseIf TextBox7.Text = "" Then
                    MsgBox("Enter second Sample Quantity", vbCritical)
                ElseIf TextBox8.Text = "" Then
                    MsgBox("Enter second pack count", vbCritical)
                ElseIf TextBox23.Text = "" Then
                    MsgBox("Enter Second Orientation", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select second condition", vbCritical)
                ElseIf CheckBox13.Checked = False And CheckBox14.Checked = False And CheckBox15.Checked = False And CheckBox16.Checked = False And CheckBox17.Checked = False And CheckBox18.Checked = False And CheckBox19.Checked = False And CheckBox20.Checked = False And CheckBox21.Checked = False And CheckBox22.Checked = False And CheckBox23.Checked = False And CheckBox24.Checked = False And B7.Checked = False And B14.Checked = False And B21.Checked = False And B28.Checked = False Then
                    MsgBox("Select atleast one period in second entry", vbCritical)
                ElseIf TextBox10.Text = "" Then
                    MsgBox("Enter Third Sample Quantity", vbCritical)
                ElseIf TextBox11.Text = "" Then
                    MsgBox("Enter Third pack count", vbCritical)
                ElseIf TextBox24.Text = "" Then
                    MsgBox("Enter third Orientation", vbCritical)
                ElseIf ComboBox5.Text = "" Then
                    MsgBox("Select Third condition", vbCritical)
                ElseIf CheckBox25.Checked = False And CheckBox26.Checked = False And CheckBox27.Checked = False And CheckBox28.Checked = False And CheckBox29.Checked = False And CheckBox30.Checked = False And CheckBox31.Checked = False And CheckBox32.Checked = False And CheckBox33.Checked = False And CheckBox34.Checked = False And CheckBox35.Checked = False And CheckBox36.Checked = False And C7.Checked = False And C14.Checked = False And C21.Checked = False And C28.Checked = False Then
                    MsgBox("Select atleast one period in third entry", vbCritical)
                ElseIf TextBox13.Text = "" Then
                    MsgBox("Enter fourth Sample Quantity", vbCritical)
                ElseIf TextBox14.Text = "" Then
                    MsgBox("Enter fourth pack count", vbCritical)
                ElseIf TextBox25.Text = "" Then
                    MsgBox("Enter fourth Orientation", vbCritical)
                ElseIf ComboBox6.Text = "" Then
                    MsgBox("Select fourth condition", vbCritical)
                ElseIf CheckBox37.Checked = False And CheckBox38.Checked = False And CheckBox39.Checked = False And CheckBox40.Checked = False And CheckBox41.Checked = False And CheckBox42.Checked = False And CheckBox43.Checked = False And CheckBox44.Checked = False And CheckBox45.Checked = False And CheckBox46.Checked = False And CheckBox47.Checked = False And CheckBox48.Checked = False And D7.Checked = False And D14.Checked = False And D21.Checked = False And D28.Checked = False Then
                    MsgBox("Select atleast one period in fourth entry", vbCritical)
                ElseIf TextBox16.Text = "" Then
                    MsgBox("Enter fifth Sample Quantity", vbCritical)
                ElseIf TextBox17.Text = "" Then
                    MsgBox("Enter fifth pack count", vbCritical)
                ElseIf TextBox26.Text = "" Then
                    MsgBox("Enter fifth Orientation", vbCritical)
                ElseIf ComboBox7.Text = "" Then
                    MsgBox("Select fifth condition", vbCritical)
                ElseIf CheckBox49.Checked = False And CheckBox50.Checked = False And CheckBox51.Checked = False And CheckBox52.Checked = False And CheckBox53.Checked = False And CheckBox54.Checked = False And CheckBox55.Checked = False And CheckBox56.Checked = False And CheckBox57.Checked = False And CheckBox58.Checked = False And CheckBox59.Checked = False And CheckBox60.Checked = False And E7.Checked = False And E14.Checked = False And E21.Checked = False And E28.Checked = False Then
                    MsgBox("Select atleast one period in fifth entry", vbCritical)
                Else
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry As String
                    qry = "select COUNT(ptn) from stability_protocol where ptn='" + TextBox2.Text + "'"
                    cmd1 = New SqlCommand(qry, con)
                    con.Open()
                    Dim SameProtocol As Integer
                    SameProtocol = cmd1.ExecuteScalar()
                    If SameProtocol = 0 Then
                        Me.Cursor = Cursors.WaitCursor
                        Add_Protocol()
                        Add_MaterialofConstruction()
                        one_batch()
                        two_batch()
                        three_batch()
                        foure_batch()
                        five_batch()
                        SendMail_ProtocolReview()
                        MsgBox("Protocol Added Successfully", vbInformation)
                        Dim f1 As viewstabilityprotocol = DirectCast(Me.Owner, viewstabilityprotocol)
                        f1.LoadProtocols()
                        Me.Close()
                    Else
                        MsgBox("Planne Already Added for this Batch", vbCritical)
                    End If
                End If
            ElseIf ComboBox2.Text = "6" Then
                If TextBox4.Text = "" Then
                    MsgBox("Enter First Sample Quantity", vbCritical)
                ElseIf TextBox5.Text = "" Then
                    MsgBox("Enter First pack count", vbCritical)
                ElseIf TextBox22.Text = "" Then
                    MsgBox("Enter First Orientation", vbCritical)
                ElseIf ComboBox3.Text = "" Then
                    MsgBox("Select First condition", vbCritical)
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False And CheckBox8.Checked = False And CheckBox9.Checked = False And CheckBox10.Checked = False And CheckBox11.Checked = False And CheckBox12.Checked = False And A7.Checked = False And A14.Checked = False And A21.Checked = False And A28.Checked = False Then
                    MsgBox("Select atleast one period in first entry", vbCritical)
                ElseIf TextBox7.Text = "" Then
                    MsgBox("Enter second Sample Quantity", vbCritical)
                ElseIf TextBox8.Text = "" Then
                    MsgBox("Enter second pack count", vbCritical)
                ElseIf TextBox23.Text = "" Then
                    MsgBox("Enter second Orientation", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select second condition", vbCritical)
                ElseIf CheckBox13.Checked = False And CheckBox14.Checked = False And CheckBox15.Checked = False And CheckBox16.Checked = False And CheckBox17.Checked = False And CheckBox18.Checked = False And CheckBox19.Checked = False And CheckBox20.Checked = False And CheckBox21.Checked = False And CheckBox22.Checked = False And CheckBox23.Checked = False And CheckBox24.Checked = False And B7.Checked = False And B14.Checked = False And B21.Checked = False And B28.Checked = False Then
                    MsgBox("Select atleast one period in second entry", vbCritical)
                ElseIf TextBox10.Text = "" Then
                    MsgBox("Enter Third Sample Quantity", vbCritical)
                ElseIf TextBox11.Text = "" Then
                    MsgBox("Enter Third pack count", vbCritical)
                ElseIf TextBox24.Text = "" Then
                    MsgBox("Enter Third Orientation", vbCritical)
                ElseIf ComboBox5.Text = "" Then
                    MsgBox("Select Third condition", vbCritical)
                ElseIf CheckBox25.Checked = False And CheckBox26.Checked = False And CheckBox27.Checked = False And CheckBox28.Checked = False And CheckBox29.Checked = False And CheckBox30.Checked = False And CheckBox31.Checked = False And CheckBox32.Checked = False And CheckBox33.Checked = False And CheckBox34.Checked = False And CheckBox35.Checked = False And CheckBox36.Checked = False And C7.Checked = False And C14.Checked = False And C21.Checked = False And C28.Checked = False Then
                    MsgBox("Select atleast one period in third entry", vbCritical)
                ElseIf TextBox13.Text = "" Then
                    MsgBox("Enter fourth Sample Quantity", vbCritical)
                ElseIf TextBox14.Text = "" Then
                    MsgBox("Enter fourth pack count", vbCritical)
                ElseIf TextBox25.Text = "" Then
                    MsgBox("Enter fourth Orientation", vbCritical)
                ElseIf ComboBox6.Text = "" Then
                    MsgBox("Select fourth condition", vbCritical)
                ElseIf CheckBox37.Checked = False And CheckBox38.Checked = False And CheckBox39.Checked = False And CheckBox40.Checked = False And CheckBox41.Checked = False And CheckBox42.Checked = False And CheckBox43.Checked = False And CheckBox44.Checked = False And CheckBox45.Checked = False And CheckBox46.Checked = False And CheckBox47.Checked = False And CheckBox48.Checked = False And D7.Checked = False And D14.Checked = False And D21.Checked = False And D28.Checked = False Then
                    MsgBox("Select atleast one period in fourth entry", vbCritical)
                ElseIf TextBox16.Text = "" Then
                    MsgBox("Enter fifth Sample Quantity", vbCritical)
                ElseIf TextBox17.Text = "" Then
                    MsgBox("Enter fifth pack count", vbCritical)
                ElseIf TextBox26.Text = "" Then
                    MsgBox("Enter fifth Orientation", vbCritical)
                ElseIf ComboBox7.Text = "" Then
                    MsgBox("Select fifth condition", vbCritical)
                ElseIf CheckBox49.Checked = False And CheckBox50.Checked = False And CheckBox51.Checked = False And CheckBox52.Checked = False And CheckBox53.Checked = False And CheckBox54.Checked = False And CheckBox55.Checked = False And CheckBox56.Checked = False And CheckBox57.Checked = False And CheckBox58.Checked = False And CheckBox59.Checked = False And CheckBox60.Checked = False And E7.Checked = False And E14.Checked = False And E21.Checked = False And E28.Checked = False Then
                    MsgBox("Select atleast one period in fifth entry", vbCritical)
                ElseIf TextBox19.Text = "" Then
                    MsgBox("Enter sixth Sample Quantity", vbCritical)
                ElseIf TextBox20.Text = "" Then
                    MsgBox("Enter sixth pack count", vbCritical)
                ElseIf TextBox27.Text = "" Then
                    MsgBox("Enter sixth Orientation", vbCritical)
                ElseIf ComboBox8.Text = "" Then
                    MsgBox("Select sixth condition", vbCritical)
                ElseIf CheckBox61.Checked = False And CheckBox62.Checked = False And CheckBox63.Checked = False And CheckBox64.Checked = False And CheckBox65.Checked = False And CheckBox66.Checked = False And CheckBox67.Checked = False And CheckBox68.Checked = False And CheckBox69.Checked = False And CheckBox70.Checked = False And CheckBox71.Checked = False And CheckBox72.Checked = False And F7.Checked = False And F14.Checked = False And F21.Checked = False And F28.Checked = False Then
                    MsgBox("Select atleast one period in sixth entry", vbCritical)
                Else
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry As String
                    qry = "select COUNT(ptn) from stability_protocol where ptn='" + TextBox2.Text + "'"
                    cmd1 = New SqlCommand(qry, con)
                    con.Open()
                    Dim SameProtocol As Integer
                    SameProtocol = cmd1.ExecuteScalar()
                    If SameProtocol = 0 Then
                        Me.Cursor = Cursors.WaitCursor
                        Add_Protocol()
                        Add_MaterialofConstruction()
                        one_batch()
                        two_batch()
                        three_batch()
                        foure_batch()
                        five_batch()
                        six_batch()
                        SendMail_ProtocolReview()
                        MsgBox("Protocol Added Successfully", vbInformation)
                        Dim f1 As viewstabilityprotocol = DirectCast(Me.Owner, viewstabilityprotocol)
                        f1.LoadProtocols()
                        Me.Close()
                    Else
                        MsgBox("Planne Already Added for this Batch", vbCritical)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Add_Protocol()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand
        cmd.Parameters.Clear()
        cmd.Connection = con
        cmd.CommandText = "insert into stability_protocol(proname,strength,ptn,packstyle,btn,apibtn,mfg,exp,chrgdate,remarks,preparedby,prepareddate,status) values('" + ComboBox1.Text + "','" + GunaTextBox1.Text + "','" + TextBox2.Text + "','" + GunaComboBox1.Text + "','" + TextBox1.Text + "','" + GunaTextBox5.Text + "','" + GunaTextBox6.Text + "','" + GunaTextBox7.Text + "',@chrgdate,'" + GunaTextBox2.Text + "','" + Homepagefrdj.Label1.Text + "',@prepareddate,'Submitted for Review')"
        cmd.Parameters.AddWithValue("@chrgdate", SqlDbType.Date).Value = DateTime.Now.Date
        cmd.Parameters.AddWithValue("@prepareddate", SqlDbType.Date).Value = DateTime.Now.Date
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
    Private Sub Add_MaterialofConstruction()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Parameters.Clear()
            cmd.Connection = con
            cmd.CommandText = "insert into stability_protocol_mc(ptn,parameter,detail) values('" + TextBox2.Text + "', '" + DataGridView1.Rows(i).Cells(0).Value + "','" + DataGridView1.Rows(i).Cells(1).Value + "')"
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Next

    End Sub
    Private Sub one_batch()
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel46.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTime.Now.Date
                cb.Name = System.Text.RegularExpressions.Regex.Replace(cb.Name, "[^\d]", " ")
                podate = podate.AddDays(cb.Name)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into stability_protocol_sch(ptn,sampleqty,pccnt,ornt,cndn,sch,podate) values('" + TextBox2.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox22.Text + "','" + ComboBox3.Text + "','" + cb.Text + "',@podate)"
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel16.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTime.Now.Date
                podate = podate.AddMonths(cb.Text)
                ' MsgBox(podate)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into stability_protocol_sch(ptn,sampleqty,pccnt,ornt,cndn,sch,podate) values('" + TextBox2.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox22.Text + "','" + ComboBox3.Text + "','" + cb.Text + "M',@podate)"
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
    End Sub
    Private Sub two_batch()
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel47.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTime.Now.Date
                cb.Name = System.Text.RegularExpressions.Regex.Replace(cb.Name, "[^\d]", " ")
                podate = podate.AddDays(cb.Name)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into stability_protocol_sch(ptn,sampleqty,pccnt,ornt,cndn,sch,podate) values('" + TextBox2.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox23.Text + "','" + ComboBox4.Text + "','" + cb.Text + "',@podate)"
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel9.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTime.Now.Date
                podate = podate.AddMonths(cb.Text)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into stability_protocol_sch(ptn,sampleqty,pccnt,ornt,cndn,sch,podate) values('" + TextBox2.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox23.Text + "','" + ComboBox4.Text + "','" + cb.Text + "M',@podate)"
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
    End Sub
    Private Sub three_batch()
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel48.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTime.Now.Date
                cb.Name = System.Text.RegularExpressions.Regex.Replace(cb.Name, "[^\d]", " ")
                podate = podate.AddDays(cb.Name)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into stability_protocol_sch(ptn,sampleqty,pccnt,ornt,cndn,sch,podate) values('" + TextBox2.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + TextBox24.Text + "','" + ComboBox5.Text + "','" + cb.Text + "',@podate)"
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel20.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTime.Now.Date
                podate = podate.AddMonths(cb.Text)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into stability_protocol_sch(ptn,sampleqty,pccnt,ornt,cndn,sch,podate) values('" + TextBox2.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + TextBox24.Text + "','" + ComboBox5.Text + "','" + cb.Text + "M',@podate)"
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
    End Sub
    Private Sub foure_batch()
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel49.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTime.Now.Date
                cb.Name = System.Text.RegularExpressions.Regex.Replace(cb.Name, "[^\d]", " ")
                podate = podate.AddDays(cb.Name)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into stability_protocol_sch(ptn,sampleqty,pccnt,ornt,cndn,sch,podate) values('" + TextBox2.Text + "','" + TextBox13.Text + "','" + TextBox14.Text + "','" + TextBox25.Text + "','" + ComboBox6.Text + "','" + cb.Text + "',@podate)"
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel26.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTime.Now.Date
                podate = podate.AddMonths(cb.Text)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into stability_protocol_sch(ptn,sampleqty,pccnt,ornt,cndn,sch,podate) values('" + TextBox2.Text + "','" + TextBox13.Text + "','" + TextBox14.Text + "','" + TextBox25.Text + "','" + ComboBox6.Text + "','" + cb.Text + "M',@podate)"
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
    End Sub
    Private Sub five_batch()
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel50.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTime.Now.Date
                cb.Name = System.Text.RegularExpressions.Regex.Replace(cb.Name, "[^\d]", " ")
                podate = podate.AddDays(cb.Name)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into stability_protocol_sch(ptn,sampleqty,pccnt,ornt,cndn,sch,podate) values('" + TextBox2.Text + "','" + TextBox16.Text + "','" + TextBox17.Text + "','" + TextBox26.Text + "','" + ComboBox7.Text + "','" + cb.Text + "',@podate)"
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel32.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTime.Now.Date
                podate = podate.AddMonths(cb.Text)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into stability_protocol_sch(ptn,sampleqty,pccnt,ornt,cndn,sch,podate) values('" + TextBox2.Text + "','" + TextBox16.Text + "','" + TextBox17.Text + "','" + TextBox26.Text + "','" + ComboBox7.Text + "','" + cb.Text + "M',@podate)"
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
    End Sub
    Private Sub six_batch()
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel51.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTime.Now.Date
                cb.Name = System.Text.RegularExpressions.Regex.Replace(cb.Name, "[^\d]", " ")
                podate = podate.AddDays(cb.Name)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into stability_protocol_sch(ptn,sampleqty,pccnt,ornt,cndn,sch,podate) values('" + TextBox2.Text + "','" + TextBox19.Text + "','" + TextBox20.Text + "','" + TextBox27.Text + "','" + ComboBox8.Text + "','" + cb.Text + "',@podate)"
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel38.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTime.Now.Date
                podate = podate.AddMonths(cb.Text)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into stability_protocol_sch(ptn,sampleqty,pccnt,ornt,cndn,sch,podate) values('" + TextBox2.Text + "','" + TextBox19.Text + "','" + TextBox20.Text + "','" + TextBox27.Text + "','" + ComboBox8.Text + "','" + cb.Text + "M',@podate)"
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "1" Then
            Panel7.Show()
            Panel8.Hide()
            Panel19.Hide()
            Panel25.Hide()
            Panel31.Hide()
            Panel37.Hide()
        ElseIf ComboBox2.Text = "2" Then
            Panel7.Show()
            Panel8.Show()
            Panel19.Hide()
            Panel25.Hide()
            Panel31.Hide()
            Panel37.Hide()
        ElseIf ComboBox2.Text = "3" Then
            Panel7.Show()
            Panel8.Show()
            Panel19.Show()
            Panel25.Hide()
            Panel31.Hide()
            Panel37.Hide()
        ElseIf ComboBox2.Text = "4" Then
            Panel7.Show()
            Panel8.Show()
            Panel19.Show()
            Panel25.Show()
            Panel31.Hide()
            Panel37.Hide()
        ElseIf ComboBox2.Text = "5" Then
            Panel7.Show()
            Panel8.Show()
            Panel19.Show()
            Panel25.Show()
            Panel31.Show()
            Panel37.Hide()
        ElseIf ComboBox2.Text = "6" Then
            Panel7.Show()
            Panel8.Show()
            Panel19.Show()
            Panel25.Show()
            Panel31.Show()
            Panel37.Show()
        End If
        loadcond()
    End Sub
    Private Sub loadcond()
        Try
            ComboBox3.Items.Clear()
            ComboBox4.Items.Clear()
            ComboBox5.Items.Clear()
            ComboBox6.Items.Clear()
            ComboBox7.Items.Clear()
            ComboBox8.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select cond from chamber"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox3.Items.Add(dr("cond"))
                ComboBox4.Items.Add(dr("cond"))
                ComboBox5.Items.Add(dr("cond"))
                ComboBox6.Items.Add(dr("cond"))
                ComboBox7.Items.Add(dr("cond"))
                ComboBox8.Items.Add(dr("cond"))
            End While
            dr.Close()

            con.Close()
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        'If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = ".") AndAlso Not Char.IsControl(e.KeyChar) Then
        'e.Handled = True
        'End If
    End Sub
    Private Sub TextBox7_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        'If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = ".") AndAlso Not Char.IsControl(e.KeyChar) Then
        'e.Handled = True
        'End If
    End Sub
    Private Sub TextBox10_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        'If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = ".") AndAlso Not Char.IsControl(e.KeyChar) Then
        'e.Handled = True
        'End If
    End Sub
    Private Sub TextBox13_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        'If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = ".") AndAlso Not Char.IsControl(e.KeyChar) Then
        'e.Handled = True
        'End If
    End Sub
    Private Sub TextBox16_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox16.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        'If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = ".") AndAlso Not Char.IsControl(e.KeyChar) Then
        'e.Handled = True
        'End If
    End Sub
    Private Sub TextBox19_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox19.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        'If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = ".") AndAlso Not Char.IsControl(e.KeyChar) Then
        'e.Handled = True
        'End If
    End Sub
    Private Sub TextBox6_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox9_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox12_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox15_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox18_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox21_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        GetInstrumentID1()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        GetInstrumentID2()
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        GetInstrumentID3()
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        GetInstrumentID4()
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.SelectedIndexChanged
        GetInstrumentID5()
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox8.SelectedIndexChanged
        GetInstrumentID6()
    End Sub
    Dim instid1 As String
    Private Sub GetInstrumentID1()
        Try
            'select instrument no.
            If con.State = ConnectionState.Open Then con.Close()
            cmd1.Connection = con
            con.Open()
            cmd1.CommandText = "select instid from chamber where cond='" + ComboBox3.Text + "'"
            instid1 = cmd1.ExecuteScalar().ToString()
            con.Close()
            Label7.Text = instid1
        Catch ex As Exception

        End Try
    End Sub
    Dim instid2 As String
    Private Sub GetInstrumentID2()
        Try

            'select instrument no.
            If con.State = ConnectionState.Open Then con.Close()
            cmd1.Connection = con
            con.Open()
            cmd1.CommandText = "select instid from chamber where cond='" + ComboBox4.Text + "'"
            instid2 = cmd1.ExecuteScalar().ToString()
            con.Close()
            Label8.Text = instid2
        Catch ex As Exception

        End Try
    End Sub
    Dim instid3 As String
    Private Sub GetInstrumentID3()
        Try

            'select instrument no.
            If con.State = ConnectionState.Open Then con.Close()
            cmd1.Connection = con
            con.Open()
            cmd1.CommandText = "select instid from chamber where cond='" + ComboBox5.Text + "'"
            instid3 = cmd1.ExecuteScalar().ToString()
            con.Close()
            Label9.Text = instid3
        Catch ex As Exception

        End Try
    End Sub
    Dim instid4 As String
    Private Sub GetInstrumentID4()
        Try
            'select instrument no.
            If con.State = ConnectionState.Open Then con.Close()
            cmd1.Connection = con
            con.Open()
            cmd1.CommandText = "select instid from chamber where cond='" + ComboBox6.Text + "'"
            instid4 = cmd1.ExecuteScalar().ToString()
            con.Close()
            Label10.Text = instid4
        Catch ex As Exception

        End Try
    End Sub
    Dim instid5 As String
    Private Sub GetInstrumentID5()
        Try
            'select instrument no.
            If con.State = ConnectionState.Open Then con.Close()
            cmd1.Connection = con
            con.Open()
            cmd1.CommandText = "select instid from chamber where cond='" + ComboBox7.Text + "'"
            instid5 = cmd1.ExecuteScalar().ToString()
            con.Close()
            Label11.Text = instid5
        Catch ex As Exception

        End Try
    End Sub
    Dim instid6 As String
    Private Sub GetInstrumentID6()
        Try
            'select instrument no.
            If con.State = ConnectionState.Open Then con.Close()
            cmd1.Connection = con
            con.Open()
            cmd1.CommandText = "select instid from chamber where cond='" + ComboBox8.Text + "'"
            instid6 = cmd1.ExecuteScalar().ToString()
            con.Close()
            Label12.Text = instid6
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox2.Text = "SP/" + TextBox1.Text
    End Sub
    Private Sub Guna2TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Guna2TextBox1.KeyPress
        ' If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
        'e.Handled = True
        'End If
    End Sub
    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged
        Try
            If Guna2TextBox1.Text = "" Then
                ComboBox1.Items.Clear()
                GunaTextBox1.Clear()
                TextBox1.Clear()
            ElseIf Guna2TextBox1.Text = "NA" Or Guna2TextBox1.Text = "na" Then
                ComboBox1.Items.Clear()
                GunaTextBox1.Clear()
                TextBox1.Clear()
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT DISTINCT(proname) FROM productmaster where productstatus='Active'"
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    ComboBox1.Items.Add(dr("proname"))
                End While
                dr.Close()
                con.Close()
            Else
                ComboBox1.Items.Clear()
                GunaTextBox1.Clear()
                TextBox1.Clear()
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT proname FROM productmaster where procode='" + Guna2TextBox1.Text + "' and productstatus='Active'"
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    ComboBox1.Items.Add(dr("proname"))
                End While
                dr.Close()
                con.Close()
                TextBox1.Text = "V" + Guna2TextBox1.Text + "-"

            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try

            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            Dim qry As String
            qry = "SELECT strength FROM productmaster where procode='" + Guna2TextBox1.Text + "' and proname='" + ComboBox1.Text + "' and productstatus='Active'"
            cmd = New SqlCommand(qry, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            da.Fill(table)

            GunaTextBox1.Text = table.Rows(0)(0).ToString()


        Catch ex As Exception

        End Try
    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        If GunaTextBox3.Text = "" Then
            MsgBox("Enter Parmaeter", vbCritical)
        ElseIf GunaTextBox4.Text.Length < 3 Then
            MsgBox("Enter Parameter Details", vbCritical)
        Else
            For i = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(i).Cells(0).Value = GunaTextBox3.Text Then
                    MsgBox("Parmaeter Already Added to List", vbCritical)
                    Exit Sub
                End If
            Next
            DataGridView1.Rows.Add(GunaTextBox3.Text, GunaTextBox4.Text)
            GunaTextBox3.Text = ""
            GunaTextBox4.Text = ""
        End If
        DataGridView1.CurrentCell = Nothing
    End Sub
    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        If DataGridView1.SelectedRows.Count > 0 Then

            DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
        Else
            MessageBox.Show("Select 1 atleast one row to delete")
        End If
    End Sub
End Class