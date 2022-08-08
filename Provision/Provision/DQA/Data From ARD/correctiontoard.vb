﻿Imports System.Data
Imports System.Data.SqlClient
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports System.Threading
Imports System.Diagnostics
Imports System.ComponentModel

Public Class correctiontoard
    'Dim con As SqlConnection = New SqlConnection("Data Source=VE-IT\SQLEXPRESS;Initial Catalog=vensure;Integrated Security=True")
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim cmd2 As SqlCommand

    Private Sub correctiontoard_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadTRs()
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 60, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

    End Sub
    Private Sub loadTRs()
        Try
            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim reader As SqlDataReader
            con.Open()
            Dim qry As String
            qry = "select (trno) from trdev where [productname]='" + TextBox1.Text + "' and [test]='" + TextBox2.Text + "' and [atrissueno]='" + TextBox3.Text + "' and Status='Data Sent to DQA' and lnbno='NA' union select (trno) from trrot where [productname]='" + TextBox1.Text + "' and [test]='" + TextBox2.Text + "' and [atrissueno]='" + TextBox3.Text + "' and Status='Data Sent to DQA' and lnbno='NA' union select (trno) from trstb where [productname]='" + TextBox1.Text + "' and [test]='" + TextBox2.Text + "' and [atrissueno]='" + TextBox3.Text + "' and Status='Data Sent to DQA' and lnbno='NA'"
            cmd = New SqlCommand(qry, con)
            reader = cmd.ExecuteReader
            While reader.Read
                ListBox1.Items.Add(reader("trno"))
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If ListBox1.Items.Count = 0 Then
            MsgBox("TR Number Not found", vbCritical)
        ElseIf TextBox3.Text = "" Then
            MsgBox("ATR Issuance Number Not found", vbCritical)
        ElseIf Guna2TextBox1.Text = "" Then
            MsgBox("Enter Correction Details", vbCritical)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure to Send this for corrections", "Confirmation before Release", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.Yes Then
                Try
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd1 As New SqlCommand
                    cmd1.Connection = con
                    cmd1.CommandText = "update trdev set Status='Corrections Sent to ARD' where atrissueno='" + TextBox3.Text + "'"
                    con.Open()
                    cmd1.ExecuteNonQuery()

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd2 As New SqlCommand
                    cmd2.Connection = con
                    cmd2.CommandText = "update trrot set Status='Corrections Sent to ARD' where atrissueno='" + TextBox3.Text + "'"
                    con.Open()
                    cmd2.ExecuteNonQuery()

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd3 As New SqlCommand
                    cmd3.Connection = con
                    cmd3.CommandText = "update trstb set Status='Corrections Sent to ARD' where atrissueno='" + TextBox3.Text + "'"
                    con.Open()
                    cmd3.ExecuteNonQuery()
                    InstertInRotation()

                    Dim f1 As datafromardatr = DirectCast(Me.Owner, datafromardatr)
                    f1.LoadATRData()
                    Me.Close()

                    MsgBox("Sent to ARD for Correction", vbInformation)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub
    Private Sub InstertInRotation()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            cmd1.CommandText = "insert into trcorrections (atrissueno,dqacomments,correctionsby,correctionsdate) values ('" + TextBox3.Text + "','" + Guna2TextBox1.Text + "','" + homepagedqa.Label1.Text + "',@correctionsdate)"
            cmd1.Parameters.AddWithValue("@correctionsdate", SqlDbType.Date).Value = DateTime.Now.Date
            con.Open()
            cmd1.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class