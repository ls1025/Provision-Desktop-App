Imports System.Data.SqlClient
Public Class updatetrrot
    Private Sub updatetrrot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadIntimationDetails()
        LoadCondition()

    End Sub
    Private Sub LoadIntimationDetails()

        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim da As New SqlDataAdapter()
            Dim dt As New DataTable()
            Dim table As New DataTable()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select * from trrot where [trno]= '" + Label1.Text + "' ", con)
            da.Fill(table)



            'Product Code
            Label2.Text = table.Rows(0)(1).ToString
            'Product Name
            Label4.Text = table.Rows(0)(2).ToString
            'Strength
            Label36.Text = table.Rows(0)(3).ToString
            'Market
            Label6.Text = table.Rows(0)(4).ToString
            'Label Claim
            TextBox1.Text = table.Rows(0)(6).ToString
            'Batch No.
            TextBox2.Text = table.Rows(0)(7).ToString
            'Batch Size
            TextBox3.Text = table.Rows(0)(8).ToString
            'Mfg Date
            TextBox4.Text = table.Rows(0)(9).ToString
            'Exp Date
            TextBox5.Text = table.Rows(0)(10).ToString
            'Sample Qty
            TextBox6.Text = table.Rows(0)(11).ToString
            'Pack
            TextBox7.Text = table.Rows(0)(12).ToString
            'Condition
            ComboBox1.Text = table.Rows(0)(13).ToString
            'Period
            TextBox8.Text = table.Rows(0)(14).ToString
            'Test Name
            Label15.Text = table.Rows(0)(15).ToString
            'Test Details
            TextBox9.Text = table.Rows(0)(16).ToString
            'Remark
            TextBox10.Text = table.Rows(0)(17).ToString
            'Requested By
            Label18.Text = table.Rows(0)(19).ToString
            'Requested Date
            If table.Rows(0)(20).ToString = "" Then
                Label19.Text = ""
            Else
                Dim requestdate As Date = Date.ParseExact(table.Rows(0)(20), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label19.Text = requestdate
            End If
            'Status
            Label31.Text = table.Rows(0)(21).ToString

            'Total Print Taken
            Label3.Text = table.Rows(0)(22).ToString

        Catch ex As Exception
        End Try

    End Sub
    Private Sub LoadCondition()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select cond from conditions"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("cond"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Label31.Text = "New TR" Or Label31.Text = "TR Printed" Or Label31.Text = "ATR Issued" Or Label31.Text = "Data Sent to DQA" Then

                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd1 As New SqlCommand
                cmd1.Connection = con
                cmd1.CommandText = "update trrot set label='" + TextBox1.Text + "',btn='" + TextBox2.Text + "',btsize='" + TextBox3.Text + "',mfgdate='" + TextBox4.Text + "',expdate='" + TextBox5.Text + "',sampleqty='" + TextBox6.Text + "',pack='" + TextBox7.Text + "',cndn='" + ComboBox1.Text + "',period='" + TextBox8.Text + "',testdetails='" + TextBox9.Text + "',remarks='" + TextBox10.Text + "' where trno='" + Label1.Text + "'"
                'cmd1.Parameters.AddWithValue("@requestdate", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd1.ExecuteNonQuery()
                con.Close()

                Dim f1 As viewintimationrotfrdgl = DirectCast(Me.Owner, viewintimationrotfrdgl)
                f1.LoadIntimationRot()
                MsgBox("TR Details Updated", vbInformation)
                Me.Close()
            Else
                MsgBox("Updation not allowed. Current TR Status is " + Label31.Text, vbCritical)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Me.Close()
    End Sub
End Class