Imports System.Data.OleDb
Public Class addpack
    Private Sub addpack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Generic Name should not be empty", vbCritical)

            Else
                Dim a As String
                If con.State = ConnectionState.Open Then con.Close()
                cmd.Connection = con
                con.Open()
                cmd.CommandText = "select count([pack]) from pack where pack='" + TextBox1.Text + "'"
                a = cmd.ExecuteScalar().ToString()
                con.Close()

                If a > 0 Then
                    MsgBox("This Pack Style is Alreday Exist", vbCritical)
                Else
                    If con.State = ConnectionState.Open Then con.Close()
                    cmd.Connection = con
                    con.Open()
                    cmd.CommandText = "insert into pack(pack) values('" + TextBox1.Text + "')"
                    cmd.ExecuteNonQuery()
                    con.Close()
                    Dim f1 As masters = DirectCast(Me.Owner, masters)
                    f1.loadpack()
                    MsgBox("Pack Style added Susccessfully", vbInformation)
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class