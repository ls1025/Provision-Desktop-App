Imports System.Data.SqlClient
Public Class addcon
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Condition should not be empty", vbCritical)
            Else
                Dim a As String
                If con.State = ConnectionState.Open Then con.Close()
                cmd.Connection = con
                con.Open()
                cmd.CommandText = "select count([instid]) from chamber where instid='" + TextBox1.Text + "'"
                a = cmd.ExecuteScalar().ToString()
                con.Close()

                If a > 0 Then
                    MsgBox("This Chamber is alreday Exist", vbCritical)
                Else
                    If con.State = ConnectionState.Open Then con.Close()
                    cmd.Connection = con
                    con.Open()
                    cmd.CommandText = "insert into chamber(instid,cond) values('" + TextBox1.Text + "','" + TextBox2.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    Dim f1 As masters = DirectCast(Me.Owner, masters)
                    f1.loadcondn()
                    MsgBox("Chamber added Susccessfully", vbInformation)
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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

        'CheckBox10.CheckedChanged, CheckBox11.CheckedChanged,
        'CheckBox12.CheckedChanged, CheckBox13.CheckedChanged

        Dim currentCheckBox = DirectCast(sender, CheckBox)
        Dim textToAddOrRemove As String = currentCheckBox.Text & ","
        If currentCheckBox.Checked Then
            ' Add the text.
            '   TextBox2.Text &= textToAddOrRemove
        Else
            ' Remove the text.
            '  TextBox2.Text = TextBox2.Text.Replace(textToAddOrRemove, String.Empty)
        End If

    End Sub

    Private Sub addcon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
End Class