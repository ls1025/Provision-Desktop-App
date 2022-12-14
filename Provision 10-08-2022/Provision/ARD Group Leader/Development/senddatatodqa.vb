Imports System.Data
Imports System.Data.SqlClient
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports System.Threading
Imports System.Diagnostics
Imports System.ComponentModel

Public Class senddatatodqa
    'Dim con As SqlConnection = New SqlConnection("Data Source=VE-IT\SQLEXPRESS;Initial Catalog=vensure;Integrated Security=True")
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim cmd2 As SqlCommand

    Private Sub senddatatodqa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadTRs()
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 60, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        Dim checked As Boolean = True   ' Set to True or False, as required.
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, checked)
        Next
    End Sub
    Private Sub loadTRs()
        Try
            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim reader As SqlDataReader
            con.Open()
            Dim qry As String
            qry = "select (trno) from trdev where [productname]='" + TextBox1.Text + "' and [test]='" + TextBox2.Text + "' and [atrissueno]='" + TextBox3.Text + "' and Status='ATR Issued' union select (trno) from trrot where [productname]='" + TextBox1.Text + "' and [test]='" + TextBox2.Text + "' and [atrissueno]='" + TextBox3.Text + "' and Status='ATR Issued' union select (trno) from trstb where [productname]='" + TextBox1.Text + "' and [test]='" + TextBox2.Text + "' and [atrissueno]='" + TextBox3.Text + "' and Status='ATR Issued'"
            cmd = New SqlCommand(qry, con)
            reader = cmd.ExecuteReader
            While reader.Read
                CheckedListBox1.Items.Add(reader("trno"))
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If CheckedListBox1.CheckedItems.Count = 0 Then
            MsgBox("You must select at least one TR Number to release the data", vbCritical)
            Return
        Else
            Dim result As Integer = MessageBox.Show("Are you sure to Send the data to DQA for selected TR Numbers", "Confirmation before Release", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.Yes Then
                For i As Integer = 0 To CheckedListBox1.CheckedItems.Count - 1
                    'If CheckedListBox1.GetItemChecked(i) Then
                    ' MsgBox(CheckedListBox1.CheckedItems(i))

                    Try
                        ' For Each item In CheckedListBox1.Items
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd1 As New SqlCommand
                        cmd1.Connection = con
                        cmd1.CommandText = "update trdev set datasentby='" + homepageard.Label1.Text + "',datasentdate=@datasentdate,Status='Data Sent to DQA' where trno='" + CheckedListBox1.CheckedItems(i) + "'"
                        cmd1.Parameters.AddWithValue("@datasentdate", SqlDbType.Date).Value = DateTime.Now.Date
                        con.Open()
                        cmd1.ExecuteNonQuery()

                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd2 As New SqlCommand
                        cmd2.Connection = con
                        cmd2.CommandText = "update trrot set datasentby='" + homepageard.Label1.Text + "',datasentdate=@datasentdate,Status='Data Sent to DQA' where trno='" + CheckedListBox1.CheckedItems(i) + "'"
                        cmd2.Parameters.AddWithValue("@datasentdate", SqlDbType.Date).Value = DateTime.Now.Date
                        con.Open()
                        cmd2.ExecuteNonQuery()

                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd3 As New SqlCommand
                        cmd3.Connection = con
                        cmd3.CommandText = "update trstb set datasentby='" + homepageard.Label1.Text + "',datasentdate=@datasentdate,Status='Data Sent to DQA' where trno='" + CheckedListBox1.CheckedItems(i) + "'"
                        cmd3.Parameters.AddWithValue("@datasentdate", SqlDbType.Date).Value = DateTime.Now.Date
                        con.Open()
                        cmd3.ExecuteNonQuery()
                        ' Next

                        Dim f1 As viewatrissued = DirectCast(Me.Owner, viewatrissued)
                        f1.LoadATRDetails()
                        Me.Close()

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                    'End If

                Next
                MsgBox("Data Sent to DQA for selected TR", vbInformation)
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class