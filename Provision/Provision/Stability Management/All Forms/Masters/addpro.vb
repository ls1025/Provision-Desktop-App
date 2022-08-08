Imports System.Data.OleDb
Public Class addpro
   
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Product Name should not be empty", vbCritical)
            ElseIf ComboBox1.Text = "" Then
                MsgBox("Select Generic Name", vbCritical)
            Else
                Dim a As String
                If con.State = ConnectionState.Open Then con.Close()
                cmd.Connection = con
                con.Open()
                cmd.CommandText = "select count([proname]) from proname where proname='" + TextBox1.Text + "'"
                a = cmd.ExecuteScalar().ToString()
                con.Close()

                If a > 0 Then
                    MsgBox("This Product Name is Alreday Exist", vbCritical)
                Else
                    If con.State = ConnectionState.Open Then con.Close()
                    cmd.Connection = con
                    con.Open()
                    cmd.CommandText = "insert into proname(proname,genericname) values('" + TextBox1.Text + "','" + ComboBox1.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    Dim f1 As masters = DirectCast(Me.Owner, masters)
                    f1.loadproname()
                    MsgBox("Product Name addedd Susccessfully", vbInformation)
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub addpro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadGenericNmae()
    End Sub
    Private Sub LoadGenericNmae()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New OleDbCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(genericname) from genericname order by genericname ASC"
            con.Open()
            Dim dr As OleDbDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("genericname"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class