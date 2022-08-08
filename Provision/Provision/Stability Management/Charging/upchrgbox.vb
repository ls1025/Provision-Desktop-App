Imports System.Data.SqlClient

Imports System.IO
Public Class upchrgbox
    Private Sub upchrgbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Enter Box Number", vbCritical)
            Else

                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("update plnr set [chrgbox]='" + TextBox1.Text + "' where [ID]= '" + Label1.Text + "'", con)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Dim f1 As detailviewchrgplnr = DirectCast(Me.Owner, detailviewchrgplnr)
                f1.LoadChargingPlanner()

                MsgBox("Updated Successfully", vbInformation)
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