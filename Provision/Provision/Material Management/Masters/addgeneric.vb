Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class addgeneric
    Dim Addedby As String = Homepagefrdj.Label2.Text
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Enter Generic Name", vbCritical)
        Else
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry As String
            qry = "select COUNT(generic) from inventry_generic where generic='" + TextBox1.Text + "'"
            cmd1 = New SqlCommand(qry, con)
            con.Open()
            Dim SameTest As Integer
            SameTest = cmd1.ExecuteScalar()
            If SameTest = 0 Then
                If Addedby = "User Type" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd1 As New SqlCommand
                    cmd1.Connection = con
                    cmd1.CommandText = "insert into inventry_generic(generic,addedby,addedon) values('" + TextBox1.Text + "','" + Homepagefrdgl.Label1.Text + "',@addedon)"
                    cmd1.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd1.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Generic Name Added", vbInformation)
                    Dim f1 As viewgenmaster = DirectCast(Me.Owner, viewgenmaster)
                    f1.LoadGenericMaster()
                    Me.Close()
                Else
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd1 As New SqlCommand
                    cmd1.Connection = con
                    cmd1.CommandText = "insert into inventry_generic(generic,addedby,addedon) values('" + TextBox1.Text + "','" + Homepagefrdj.Label1.Text + "',@addedon)"
                    cmd1.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd1.ExecuteNonQuery()
                    con.Close()
                    MsgBox("Generic Name Added", vbInformation)
                    Dim f1 As viewgenmaster = DirectCast(Me.Owner, viewgenmaster)
                    f1.LoadGenericMaster()
                    Me.Close()
                End If

            Else
                MsgBox("Generic Name already exist", vbCritical)
            End If
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub addgeneric_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
End Class