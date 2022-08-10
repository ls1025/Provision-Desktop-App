Imports System.Data.SqlClient
Public Class archivedoc
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Then
            MsgBox("Enter Archival Number", vbCritical)
        ElseIf TextBox2.Text = "" Then
            MsgBox("Enter Archival Location", vbCritical)
        ElseIf ListBox1.Items.Count = 0 Then
            MsgBox("No document has been selected", vbCritical)
        Else

            For i As Integer = 0 To ListBox2.Items.Count - 1
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "update archival_master set [arcno]='" + TextBox1.Text + "',[location]='" + TextBox2.Text + "',[archivedby]='" + homepage.Label1.Text + "',[archiveddate]=@archiveddate,status='archived' where [id]='" + ListBox2.Items(i).ToString + "'"
                cmd.Parameters.AddWithValue("@archiveddate", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next

            ' Next
            MsgBox("Document Archived Successfully", vbInformation)

            Dim f1 As viewdocdetails = DirectCast(Me.Owner, viewdocdetails)
            f1.LoadDocumentDetails()
            Me.Close()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub archivedoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class