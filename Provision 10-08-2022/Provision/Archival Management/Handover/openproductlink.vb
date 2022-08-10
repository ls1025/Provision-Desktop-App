Imports System.Data.SqlClient
Imports System.IO

Public Class openproductlink
    Private Sub openproductlink_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        Load_ProductName()
    End Sub
    Private Sub Load_ProductName()
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
        If TextBox1.Text = "" Then
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
                End While
                dr.Close()

                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else

        End If
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If TextBox1.Text = "" Then
                Load_ProductName()
            Else
                ComboBox1.Items.Clear()
                ComboBox2.Items.Clear()
                'ComboBox1.SelectedIndex = 1
                ' ComboBox2.SelectedIndex = 1

                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT proname,strength FROM productmaster where procode='" + TextBox1.Text + "'"
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    ComboBox1.Items.Add(dr("proname"))
                    ComboBox2.Items.Add(dr("strength"))
                End While
                dr.Close()
                con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MsgBox("Select Product", vbCritical)
        ElseIf ComboBox2.Text = "" Then
            Dim f1 As handover = DirectCast(Me.Owner, handover)
            f1.TextBox1.Text = ComboBox1.Text
            Me.Close()
        ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" Then
            Dim f1 As handover = DirectCast(Me.Owner, handover)
            f1.TextBox1.Text = ComboBox1.Text + " " + ComboBox2.Text
            Me.Close()
        End If

    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Me.Close()
    End Sub
End Class