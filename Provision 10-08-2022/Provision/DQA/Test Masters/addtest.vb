Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class addtest
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Enter Test Name", vbCritical)
        Else
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry As String
            qry = "select COUNT(test) from testmaster where test='" + TextBox1.Text + "'"
            cmd1 = New SqlCommand(qry, con)
            con.Open()
            Dim SameTest As Integer
            SameTest = cmd1.ExecuteScalar()
            If SameTest = 0 Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd1 As New SqlCommand
                cmd1.Connection = con
                cmd1.CommandText = "insert into  testmaster(test,testaddedby,testaddeddate) values('" + TextBox1.Text + "','" + homepagedqa.Label1.Text + "',@testaddeddate)"
                cmd1.Parameters.AddWithValue("@testaddeddate", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd1.ExecuteNonQuery()
                con.Close()
                MsgBox("Test Added", vbInformation)
                Dim f1 As viewtestmaster = DirectCast(Me.Owner, viewtestmaster)
                f1.LoadTestMaster()
                Me.Close()
            Else
                MsgBox("Test Name already exist", vbCritical)
            End If
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub addtest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
End Class