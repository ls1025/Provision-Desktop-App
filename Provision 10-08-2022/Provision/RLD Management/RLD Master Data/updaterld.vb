Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class updaterld

    Dim cmd1 As New SqlCommand
    Dim cmd2 As New SqlCommand
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub updaterld_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadRLDDetails()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If ComboBox1.Text = "" Then
                MsgBox("Select Storage Location", vbCritical)
            Else
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "update rld_master set strlocation='" + ComboBox1.Text + "',remarks='" + TextBox12.Text + "' where id='" + Label1.Text + "'"
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("RLD Added Successfully", vbInformation)
                Dim f1 As viewrldmasterdata = DirectCast(Me.Owner, viewrldmasterdata)
                f1.LoadRLDDetails()
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
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
            TextBox2.Text = table.Rows(0)(1).ToString
            'Strength
            TextBox3.Text = table.Rows(0)(2).ToString
            'brand
            TextBox5.Text = table.Rows(0)(3).ToString
            'cntry
            TextBox4.Text = table.Rows(0)(4).ToString
            'manufacturer
            TextBox6.Text = table.Rows(0)(5).ToString
            'btn
            TextBox7.Text = table.Rows(0)(6).ToString
            'pack style
            TextBox9.Text = table.Rows(0)(7).ToString
            'reciept date
            If table.Rows(0)(9).ToString = "" Then
                Label2.Text = ""
            Else
                Dim recdate As Date = Date.ParseExact(table.Rows(0)(9), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label2.Text = recdate
            End If
            'exp date
            If table.Rows(0)(10).ToString = "" Then
                Label3.Text = ""
            Else
                Dim expdate As Date = Date.ParseExact(table.Rows(0)(10), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label3.Text = expdate
            End If
            'recived qty
            Label4.Text = table.Rows(0)(11).ToString + " " + table.Rows(0)(12).ToString

            'balanace qty
            Label5.Text = table.Rows(0)(13).ToString


            'location
            ComboBox1.Text = table.Rows(0)(16).ToString
            'remarks
            TextBox12.Text = table.Rows(0)(17).ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class