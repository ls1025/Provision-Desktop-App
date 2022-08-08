Imports System.Data.SqlClient
Public Class addlicense
    Dim cmd1 As New SqlCommand
    Dim cmd2 As New SqlCommand
    Private Sub addlicense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
        LoadProductName()

    End Sub
    Private Sub LoadProductName()
        Try
            ComboBox1.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(proname) from productmaster order by [proname] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("proname"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            ComboBox2.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(strength) from productmaster where proname='" + ComboBox1.Text + "' order by [strength] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr("strength"))
                ComboBox2.Items.Add("NA")
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs)
        Dim form As New openproductlink
        form.Owner = Me
        form.ShowDialog()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If ComboBox1.Text = "" Then
                MsgBox("Select Product Name", vbExclamation)
            ElseIf ComboBox2.Text = "" Then
                MsgBox("Select Strenght Failed", vbCritical)
            ElseIf TextBox1.Text = "." Then
                MsgBox("Enter Market", vbCritical)
            ElseIf TextBox2.Text = "." Then
                MsgBox("Select License Type", vbCritical)
            ElseIf TextBox3.Text = "." Then
                MsgBox("Eneter Form Number", vbCritical)
            Else
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "insert into productlicense(proname,strength,market,licensetype,applyform,docfromfrd,doctoconsultant,appliedby,appliedon,licstatus) values('" + ComboBox1.Text + "','" + ComboBox2.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "',@docfromfrd,@doctoconsultant,'" + homepage.Label1.Text + "',@appliedon,'Licnese Applied')"
                cmd.Parameters.AddWithValue("@docfromfrd", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@doctoconsultant", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker2.Value.Date)
                cmd.Parameters.AddWithValue("@appliedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("License Added Successfully", vbInformation)
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


End Class