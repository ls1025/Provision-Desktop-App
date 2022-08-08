Imports System.Data
Imports System.Data.SqlClient
    Imports System.IO
    Public Class issuelnb
        Dim cmd1 As New SqlCommand
        Dim cmd2 As New SqlCommand

    Private Sub addproduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        TextBox3.Text = "FRD/" + TextBox2.Text + "/"
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Enter Product Name", vbCritical)
            ElseIf TextBox2.Text = "" Then
                MsgBox("Enter Product Number", vbCritical)
            ElseIf TextBox3.Text = "" Then
                MsgBox("Enter LNB Number", vbCritical)
                'ElseIf GunaTextBox1.Text = "" Then
            ElseIf Label1.Text = "." Or Label1.Text = "" Then
                MsgBox("Enter Username.", vbCritical)
            Else
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("update productmaster set [lnb]='Yes' where [procode]= '" + TextBox2.Text + "'", con)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd1 As New SqlCommand
                cmd1.Parameters.Clear()
                cmd1.Connection = con
                cmd1.CommandText = "insert into productlnb(procode,lnbno,issuedby,issuedto,issueddate,remark) values('" + TextBox2.Text + "','" + TextBox3.Text + "','" + homepage.Label1.Text + "','" + Label1.Text + "',@issueddate,'" + TextBox4.Text + "')"
                cmd1.Parameters.AddWithValue("@issueddate", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd1.ExecuteNonQuery()
                con.Close()

                MsgBox("LNB Issued Successfully", vbInformation)
                Dim f1 As viewlnbdetails = DirectCast(Me.Owner, viewlnbdetails)
                f1.LoadLNBDetails()
                Me.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Me.Close()
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New esignlnb
        form.Owner = Me
        form.ShowDialog()
    End Sub
End Class