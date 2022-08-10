Imports System.Data.SqlClient

Imports System.IO
Public Class upwithbox

    Private Sub upwithbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        CurrentBoxNumber()
    End Sub
    Private Sub CurrentBoxNumber()
        Try
            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim reader As SqlDataReader
            con.Open()
            Dim qry As String
            qry = "select DISTINCT(withbox) from plnr where [proname]='" + Label2.Text + "' and withbox IS NOT NULL order by withbox DESC"
            cmd = New SqlCommand(qry, con)
            reader = cmd.ExecuteReader
            While reader.Read
                ListBox1.Items.Add(reader("withbox"))
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Enter Box Number", vbCritical)
            Else

                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("update plnr set [withbox]='" + TextBox1.Text + "',[upboxby]='" + homepage.Label1.Text + "',[upboxon]=@upboxon where [ID]= '" + Label1.Text + "'", con)
                cmd.Parameters.AddWithValue("@upboxon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                UpDateBoxStatus()

                Dim f1 As detailviewwithplnr = DirectCast(Me.Owner, detailviewwithplnr)
                f1.loadwithdrawalplanner()

                MsgBox("Updated Successfully", vbInformation)
                Me.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub UpDateBoxStatus()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim da As New SqlDataAdapter()
            Dim dt As New DataTable()
            Dim cmd As New SqlCommand
            cmd.Connection = con

            da = New SqlDataAdapter("Select proname from boxmaster where withbox= '" + TextBox1.Text + "' ", con)
            Dim table As New DataTable()
            da.Fill(table)

            If table.Rows.Count = 0 Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd1 As New SqlCommand
                cmd1.Connection = con
                cmd1.CommandText = "insert into boxmaster(withbox,ref_id,boxsts,proname) values('" + TextBox1.Text + "','" + Label1.Text + "','Space Available','" + Label2.Text + "')"
                con.Open()
                cmd1.ExecuteNonQuery()
                con.Close()
            ElseIf table.Rows.Count > 0 Then
                If String.IsNullOrEmpty(table.Rows(0)(0).ToString) Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd1 As New SqlCommand
                    cmd1.Connection = con
                    cmd1.CommandText = "delete from boxmaster where withbox='" + TextBox1.Text + "'"
                    con.Open()
                    cmd1.ExecuteNonQuery()
                    con.Close()

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd2 As New SqlCommand
                    cmd2.Connection = con
                    cmd2.CommandText = "insert into boxmaster(withbox,ref_id,boxsts,proname) values('" + TextBox1.Text + "','" + Label1.Text + "','Space Available','" + Label2.Text + "')"
                    con.Open()
                    cmd2.ExecuteNonQuery()
                    con.Close()
                End If
            Else

            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub GunaLinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GunaLinkLabel1.LinkClicked
        Dim form As New box
        form.ShowDialog()
    End Sub
End Class