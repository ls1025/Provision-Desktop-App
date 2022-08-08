Imports System.Data.SqlClient
Public Class updateequipdetails
    Private Sub updateequipdetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadDocType()
        Load_Test()
        Load_Document_Catogery()
        Load_Archival_Details()
    End Sub
    Private Sub Load_Archival_Details()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim da As New SqlDataAdapter()
            Dim dt As New DataTable()
            Dim cmd As New SqlCommand
            cmd.Connection = con

            da = New SqlDataAdapter("Select * from  archival_master where [id]= '" + Label1.Text + "' ", con)
            Dim table As New DataTable()
            da.Fill(table)

            ComboBox1.Text = table.Rows(0)(1).ToString
            ComboBox2.Text = table.Rows(0)(2).ToString
            TextBox1.Text = table.Rows(0)(3).ToString
            TextBox2.Text = table.Rows(0)(4).ToString
            ComboBox3.Text = table.Rows(0)(5).ToString
            If table.Rows(0)(6).ToString = "Current" Then
                RadioButton1.Checked = True
            ElseIf table.Rows(0)(6).ToString = "Superseded" Then
                RadioButton2.Checked = True
            ElseIf table.Rows(0)(6).ToString = "Obsoleted" Then
                RadioButton3.Checked = True
            ElseIf table.Rows(0)(6).ToString = "NA" Then
                RadioButton4.Checked = True
            End If
            TextBox3.Text = table.Rows(0)(11).ToString
            TextBox4.Text = table.Rows(0)(7).ToString
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadDocType()
        Try
            ComboBox1.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(doctype) from archival_doctype order by [doctype] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("doctype"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.SelectedIndex = -1
        Load_Document_Catogery()
    End Sub

    Private Sub Load_Document_Catogery()
        Try
            ComboBox2.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(catogery) from archival_catogery where doctype='" + ComboBox1.Text + "' order by [catogery] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr("catogery"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Load_Test()
        Try
            ComboBox3.Items.Clear()
            ComboBox3.Items.Add("NA")
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(test) from testmaster order by [test] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read

                ComboBox3.Items.Add(dr("test"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Dim docversion_status As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each cb As Guna.UI.WinForms.GunaRadioButton In GunaPanel1.Controls.OfType(Of Guna.UI.WinForms.GunaRadioButton)()
            If cb.Checked = True Then
                docversion_status = cb.Text
            End If
        Next

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd3 As New SqlCommand
        cmd3.Connection = con
        cmd3.CommandText = "update archival_master set doctype='" + ComboBox1.Text + "',catogery='" + ComboBox2.Text + "',docname='" + TextBox1.Text + "',docno='" + TextBox2.Text + "',test='" + ComboBox3.Text + "',verstatus='" + docversion_status + "',remarks='" + TextBox4.Text + "',arcno='" + TextBox3.Text + "' where id='" + Label1.Text + "'"

        con.Open()
        cmd3.ExecuteNonQuery()
        con.Close()
        MsgBox("Document Details Updated Successfully", vbInformation)

        Dim f1 As viewarchivedocdetails = DirectCast(Me.Owner, viewarchivedocdetails)
        f1.LoadDocumentDetails()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class