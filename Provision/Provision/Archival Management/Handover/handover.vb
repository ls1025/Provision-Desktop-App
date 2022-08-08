Imports System.Data.SqlClient
Public Class handover
    Dim cmd1 As New SqlCommand
    Dim cmd2 As New SqlCommand
    Private Sub handover_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadDocType()
        Load_Test()
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
    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Dim form As New openproductlink
        form.Owner = Me
        form.ShowDialog()

    End Sub
    Dim docversion_status As String
    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        If ComboBox1.Text = "" Then
            MsgBox("Select Document Type", vbCritical)
        ElseIf ComboBox2.Text = "" Then
            MsgBox("Select Document Catogery", vbCritical)
        ElseIf TextBox1.Text = "" Then
            MsgBox("Enter Document Name", vbCritical)
        ElseIf TextBox2.Text = "" Then
            MsgBox("Enter Document Number", vbCritical)
        ElseIf ComboBox3.Text = "" Then
            MsgBox("Select Test", vbCritical)
        ElseIf GunaRadioButton1.Checked = False And GunaRadioButton2.Checked = False And GunaRadioButton3.Checked = False And GunaRadioButton4.Checked = False Then
            MsgBox("Select Document Version Status. If there is no version then select NA", vbCritical)
        Else
            Dim samedoctype As String
            If con.State = ConnectionState.Open Then con.Close()
            cmd.Connection = con
            con.Open()
            cmd.CommandText = "select count([docno]) from archival_master where docno='" + TextBox2.Text + "' and docno<>'NA'"
            samedoctype = cmd.ExecuteScalar().ToString()
            con.Close()
            If samedoctype > 0 Then
                MsgBox("Document Number is alreday Exist", vbCritical)
                Exit Sub
            End If
            For i = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(i).Cells(3).Value = TextBox2.Text Then
                    MsgBox("Document Number is Already Added to List", vbCritical)
                    Exit Sub
                End If
            Next
            For Each RadioButton As Guna.UI.WinForms.GunaRadioButton In GunaGroupBox1.Controls.OfType(Of Guna.UI.WinForms.GunaRadioButton)()
                If RadioButton.Checked = True Then
                    docversion_status = RadioButton.Text
                End If
            Next
            DataGridView1.Rows.Add(ComboBox1.Text, ComboBox2.Text, TextBox1.Text, TextBox2.Text, ComboBox3.Text, docversion_status, TextBox3.Text)

        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If DataGridView1.Rows.Count < 1 Then
                MsgBox("Atleast one dicument should be added to the list", vbExclamation)
            ElseIf Label1.Text = "" Then
                MsgBox("Authentication Failed", vbCritical)
            ElseIf Label1.Text = "." Then
                MsgBox("Authentication Failed", vbCritical)
            Else
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd3 As New SqlCommand
                    cmd3.Connection = con
                    cmd3.CommandText = "insert into archival_master(doctype,catogery,docname,docno,test,verstatus,remarks,handoverby,recievedby,recieveddate,status) values('" + DataGridView1.Rows(i).Cells(0).Value + "','" + DataGridView1.Rows(i).Cells(1).Value + "','" + DataGridView1.Rows(i).Cells(2).Value + "','" + DataGridView1.Rows(i).Cells(3).Value + "','" + DataGridView1.Rows(i).Cells(4).Value + "','" + DataGridView1.Rows(i).Cells(5).Value + "','" + DataGridView1.Rows(i).Cells(6).Value + "','" + Label1.Text + "','" + homepage.Label1.Text + "',@recieveddate,'handover')"
                    cmd3.Parameters.AddWithValue("@recieveddate", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd3.ExecuteNonQuery()
                    con.Close()
                Next
                MsgBox("Document Handover Successfully", vbInformation)
                Dim f1 As viewhandoverdoctype = DirectCast(Me.Owner, viewhandoverdoctype)
                f1.Load_Handover_Docs()
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New esigndochandover
        form.Owner = Me
        form.ShowDialog()
    End Sub

End Class