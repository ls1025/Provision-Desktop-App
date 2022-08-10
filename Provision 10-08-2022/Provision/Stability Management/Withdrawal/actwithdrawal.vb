Imports System.Data.SqlClient
Public Class actwithdrawal
    Private Sub actwithdrawal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        DateTimePicker1.Value = DateTime.Now
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DateTimePicker1.Text = " " Then
            MsgBox("Please select the date", vbCritical)
        Else
            If con.State = ConnectionState.Open Then con.Close()
            cmd.Parameters.Clear()
            cmd.Connection = con
            con.Open()
            cmd.CommandText = "update plnr set [chrgbox]=NULL,[actpodate]= @actpodate,remark='" + TextBox1.Text + "',[withby]='" + homepage.Label1.Text + "',[withon]=@withon  where [ID]= '" + Label4.Text + "'"
            cmd.Parameters.AddWithValue("@actpodate", SqlDbType.Date).Value = DateTimePicker1.Value.Date
            cmd.Parameters.AddWithValue("@withon", SqlDbType.Date).Value = DateTime.Now.Date
            cmd.ExecuteNonQuery()
            con.Close()
            currsch.DataGridView1.CurrentCell = Nothing

            Dim f1 As currsch = DirectCast(Me.Owner, currsch)
            f1.loadplnr()

            Me.Close()
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If homepage.Label2.Text = "GL" Then
        Else

            DateTimePicker1.MinDate = DateTime.Now.AddDays(-2)
            DateTimePicker1.MaxDate = DateTime.Now.AddDays(2)
        End If
    End Sub
End Class