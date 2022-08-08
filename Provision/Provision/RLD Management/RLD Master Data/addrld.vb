Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class addrld
    Private _filename As String = String.Empty
    Dim cmd1 As New SqlCommand
    Dim cmd2 As New SqlCommand
    Private Sub addrld_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox10_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Enter Product Code to Get the details", vbCritical)
            ElseIf TextBox2.Text = "" Then
                MsgBox("Product Name should not be blank. Enter Product Code to Get the product name", vbCritical)
            ElseIf TextBox3.Text = "" Then
                MsgBox("Strength should not be blank. Enter Product Code to Get the Strength", vbCritical)
            ElseIf TextBox4.Text = "" Then
                MsgBox("Country should not be blank. Enter Product Code to Get the Country", vbCritical)
            ElseIf TextBox5.Text = "" Then
                MsgBox("Enter Brand Name", vbCritical)
            ElseIf TextBox6.Text = "" Then
                MsgBox("Enter Manufacturer Name", vbCritical)
            ElseIf TextBox7.Text = "" Then
                MsgBox("Enter Batch Number", vbCritical)
            ElseIf TextBox9.Text = "" Then
                MsgBox("Enter Pack Style", vbCritical)
            ElseIf TextBox10.Text = "" Then
                MsgBox("Enter Received Qty.", vbCritical)
            ElseIf TextBox11.Text = "" Then
                MsgBox("Enter Unit of Qty.", vbCritical)
            ElseIf ComboBox1.Text = "" Then
                MsgBox("Select Storage Location", vbCritical)
                ' ElseIf Label1.Text = "" Or Label1.Text = "." Then
                '  MsgBox("Upload Invoice to update the RLD details", vbCritical)
            Else
                If con.State = ConnectionState.Open Then con.Close()
                Dim qry As String
                qry = "select COUNT(proname) from rld_master where btn='" + TextBox7.Text + "'"
                cmd1 = New SqlCommand(qry, con)
                con.Open()
                Dim SameRLDProduct As Integer
                SameRLDProduct = cmd1.ExecuteScalar()
                If SameRLDProduct = 0 Then
                    If Label1.Text = "." Then
                        AddRLDWithoutAttachment()
                    ElseIf Label1.Text = "" Then
                        AddRLDWithoutAttachment()
                    Else
                        AddRLDWithAttachment()
                    End If
                Else
                    MsgBox("RLD Details Alreay Exist", vbCritical)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub AddRLDWithoutAttachment()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "insert into rld_master(proname,strength,brand,cntry,manfact,btn,packstyle,receiptdate,expdate,receivedqty,recformat,balanceqty,rldaddedby,rldaddeddate,strlocation,remarks) values('" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox5.Text + "','" + TextBox4.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox9.Text + "',@receiptdate,@expdate,'" + TextBox10.Text + "','" + TextBox11.Text + "','" + TextBox10.Text + "','" + homepage.Label1.Text + "',@rldaddeddate,'" + ComboBox1.Text + "','" + TextBox12.Text + "')"
        'cmd.Parameters.AddWithValue("@docs", SqlDbType.VarBinary).Value = File.ReadAllBytes(Label1.Text)
        cmd.Parameters.AddWithValue("@receiptdate", SqlDbType.Date).Value = DateTimePicker1.Value.Date
        cmd.Parameters.AddWithValue("@expdate", SqlDbType.Date).Value = DateTimePicker2.Value.Date
        cmd.Parameters.AddWithValue("@rldaddeddate", SqlDbType.Date).Value = DateTime.Now.Date
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        MsgBox("RLD Added Successfully", vbInformation)
        Dim f1 As viewrldmasterdata = DirectCast(Me.Owner, viewrldmasterdata)
        f1.LoadRLDDetails()
        Me.Close()
    End Sub
    Private Sub AddRLDWithAttachment()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "insert into rld_master(proname,strength,brand,cntry,manfact,btn,packstyle,docs,receiptdate,expdate,receivedqty,recformat,balanceqty,rldaddedby,rldaddeddate,strlocation,remarks) values('" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox5.Text + "','" + TextBox4.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox9.Text + "',@docs,@receiptdate,@expdate,'" + TextBox10.Text + "','" + TextBox11.Text + "','" + TextBox10.Text + "','" + homepage.Label1.Text + "',@rldaddeddate,'" + ComboBox1.Text + "','" + TextBox12.Text + "')"
        cmd.Parameters.AddWithValue("@docs", SqlDbType.VarBinary).Value = File.ReadAllBytes(Label1.Text)
        cmd.Parameters.AddWithValue("@receiptdate", SqlDbType.Date).Value = DateTimePicker1.Value.Date
        cmd.Parameters.AddWithValue("@expdate", SqlDbType.Date).Value = DateTimePicker2.Value.Date
        cmd.Parameters.AddWithValue("@rldaddeddate", SqlDbType.Date).Value = DateTime.Now.Date
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        MsgBox("RLD Added Successfully", vbInformation)
        Dim f1 As viewrldmasterdata = DirectCast(Me.Owner, viewrldmasterdata)
        f1.LoadRLDDetails()
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        With FileDialogs
            .FileName = ""
            .CheckFileExists = True : .CheckPathExists = True
            .Filter = "PDF Files (*.pdf)|*.pdf"
            .Multiselect = False : .ReadOnlyChecked = False
            .RestoreDirectory = True : .ShowHelp = False
            .Title = "Select File - Documnet Upload"
            .ShowDialog(Me)
            _filename = .FileName.ToString()
            Label1.Text = _filename
        End With
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try

            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            Dim qry As String
            qry = "SELECT * FROM productmaster where procode='" + TextBox1.Text + "' and productstatus='Active'"
            cmd = New SqlCommand(qry, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            da.Fill(table)
            If TextBox1.Text = "" Then
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
            ElseIf table.Rows.Count = 0 Then
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
            Else
                TextBox2.Text = table.Rows(0)(2).ToString()
                TextBox3.Text = table.Rows(0)(3).ToString()
                TextBox4.Text = table.Rows(0)(4).ToString()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GunaLinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GunaLinkLabel1.LinkClicked
        Dim form As New viewproductmastersdqa
        form.FormBorderStyle = FormBorderStyle.FixedSingle
        form.WindowState = FormWindowState.Maximized
        form.ShowDialog()
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged

    End Sub
End Class