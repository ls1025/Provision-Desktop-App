Imports System.Data.SqlClient
Public Class issuedocument
    Dim cmd1 As New SqlCommand
    Dim cmd2 As New SqlCommand
    Private Sub issuedocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label1.Text = "." Or Label1.Text = "" Then
            MsgBox("Authentication Failed", vbCritical)
        ElseIf Label1.Text = homepage.Label1.Text Then
            MsgBox("Authentication Failed. Cannot be issued to self", vbCritical)
        Else
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry As String
            qry = "select COUNT(docname) from archival_issuance where ref_id='" + Label2.Text + "' and status='Document Issued'"
            cmd1 = New SqlCommand(qry, con)
            con.Open()
            Dim SameProductCount As Integer
            SameProductCount = cmd1.ExecuteScalar()
            If SameProductCount = 0 Then

                Try
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd3 As New SqlCommand
                    cmd3.Connection = con
                    cmd3.CommandText = "insert into archival_issuance(ref_id,doctype,catogery,docname,docno,arcno,location,issuedby,issuedto,issueddate,remark,status) values ('" + Label2.Text + "','" + Label3.Text + "','" + Label4.Text + "','" + Label5.Text + "','" + Label6.Text + "','" + Label7.Text + "','" + Label8.Text + "','" + homepage.Label1.Text + "','" + Label1.Text + "',@issueddate,'" + TextBox1.Text + "','Document Issued')"
                    cmd3.Parameters.AddWithValue("@issueddate", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd3.ExecuteNonQuery()
                    con.Close()

                    MsgBox("Document Issued Successfully", vbInformation)
                    Me.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Else
                MsgBox("This Document is Already Issued", vbCritical)

            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New esignissuance
        form.Owner = Me
        form.ShowDialog()
    End Sub
End Class