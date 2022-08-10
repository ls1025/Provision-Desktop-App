Imports System.Data
Imports System.Data.SqlClient
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports System.Threading
Imports System.Diagnostics
Imports System.ComponentModel

Public Class uploaddata
    Private _filename As String = String.Empty
    Private Sub uploaddata_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 60, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TextBox4.Text = "" Then
            MsgBox("Invalid TR Number", vbCritical)
        ElseIf Label1.Text = "" Then
            MsgBox("Invalid File Name", vbCritical)
        ElseIf Label1.Text = "." Then
            MsgBox("Invalid File Name", vbCritical)
        ElseIf GunaCheckBox1.Checked = False Then
            Dim result As Integer = MessageBox.Show("Are you sure to Upload Data for this TR Numbers", "Confirmation before Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.Yes Then
                Upload_Data()
                MsgBox("Data Uploaded for selected TR Numbers", vbInformation)
            End If

        ElseIf GunaCheckBox1.Checked = True And (Label3.Text = "." Or Label3.Text = "") Then
            MsgBox("Authentication Failed.", vbInformation)
        ElseIf GunaCheckBox1.Checked = True And (Label3.Text <> "." Or Label3.Text <> "") Then
            Dim result As Integer = MessageBox.Show("Are you sure to Upload and Archive the Document for this TR Numbers", "Confirmation before Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.Yes Then
                Upload_Data()
                Handover_Documents()
                MsgBox("Data Uploaded and Document handovered for archival", vbInformation)
            End If
        End If
    End Sub
    Private Sub Upload_Data()
        Try
            ' For Each item In CheckedListBox1.Items
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd1 As New SqlCommand
            cmd1.Connection = con
            cmd1.CommandText = "update trdev set datauploadby='" + homepage.Label1.Text + "',datauploaddate=@datauploaddate,datafile=@datafile,Status='Data Uploaded' where trno='" + TextBox4.Text + "'"
            cmd1.Parameters.AddWithValue("@datafile", SqlDbType.VarBinary).Value = File.ReadAllBytes(Label1.Text)
            cmd1.Parameters.AddWithValue("@datauploaddate", SqlDbType.Date).Value = DateTime.Now.Date
            con.Open()
            cmd1.ExecuteNonQuery()

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd2 As New SqlCommand
            cmd2.Connection = con
            cmd2.CommandText = "update trrot set datauploadby='" + homepage.Label1.Text + "',datauploaddate=@datauploaddate,datafile=@datafile,Status='Data Uploaded' where trno='" + TextBox4.Text + "'"
            cmd2.Parameters.AddWithValue("@datafile", SqlDbType.VarBinary).Value = File.ReadAllBytes(Label1.Text)
            cmd2.Parameters.AddWithValue("@datauploaddate", SqlDbType.Date).Value = DateTime.Now.Date
            con.Open()
            cmd2.ExecuteNonQuery()

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd3 As New SqlCommand
            cmd3.Connection = con
            cmd3.CommandText = "update trstb set datauploadby='" + homepage.Label1.Text + "',datauploaddate=@datauploaddate,datafile=@datafile,Status='Data Uploaded' where trno='" + TextBox4.Text + "'"
            cmd3.Parameters.AddWithValue("@datafile", SqlDbType.VarBinary).Value = File.ReadAllBytes(Label1.Text)
            cmd3.Parameters.AddWithValue("@datauploaddate", SqlDbType.Date).Value = DateTime.Now.Date
            con.Open()
            cmd3.ExecuteNonQuery()


            Dim f1 As viewreleaseddata = DirectCast(Me.Owner, viewreleaseddata)
            f1.LoadReleasedData()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Handover_Documents()
        Try
            If TextBox4.Text.Contains("TR/") Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "insert into archival_master(doctype,catogery,docname,docno,test,verstatus,remarks,handoverby,recievedby,recieveddate,status) values('Analytical Reports','Routine','" + TextBox1.Text + "','" + TextBox4.Text + "','" + TextBox2.Text + "','NA','" + TextBox3.Text + "','" + Label3.Text + "','" + homepage.Label1.Text + "',@recieveddate,'handover')"
                cmd.Parameters.AddWithValue("@recieveddate", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()

            ElseIf TextBox4.Text.Contains("DT/") Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "insert into archival_master(doctype,catogery,docname,docno,test,verstatus,remarks,handoverby,recievedby,recieveddate,status) values('Analytical Reports','Development','" + TextBox1.Text + "','" + TextBox4.Text + "','" + TextBox2.Text + "','NA','" + TextBox3.Text + "','" + Label3.Text + "','" + homepage.Label1.Text + "',@recieveddate,'handover')"
                cmd.Parameters.AddWithValue("@recieveddate", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
            ElseIf TextBox4.Text.Contains("ST/") Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "insert into archival_master(doctype,catogery,docname,docno,test,verstatus,remarks,handoverby,recievedby,recieveddate,status) values('Analytical Reports','Stability','" + TextBox1.Text + "','" + TextBox4.Text + "','" + TextBox2.Text + "','NA','" + TextBox3.Text + "','" + Label3.Text + "','" + homepage.Label1.Text + "',@recieveddate,'handover')"
                cmd.Parameters.AddWithValue("@recieveddate", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        With FileDialogs
            .FileName = ""
            .CheckFileExists = True : .CheckPathExists = True
            .Filter = "PDF Files (*.pdf)|*.pdf"
            .Multiselect = False : .ReadOnlyChecked = False
            .RestoreDirectory = True : .ShowHelp = False
            .Title = "Select File - PDS Upload"
            .ShowDialog(Me)
            _filename = .FileName.ToString()
            Label1.Text = _filename
        End With
    End Sub

    Private Sub GunaCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox1.CheckedChanged
        If GunaCheckBox1.Checked = True Then
            Try
                If TextBox4.Text.Contains("DT/") Then
                    If con.State = ConnectionState.Open Then con.Close()
                    cmd.Connection = con
                    con.Open()
                    cmd.CommandText = "select releasedby from trdev where trno='" + TextBox4.Text + "'"
                    Label3.Text = cmd.ExecuteScalar().ToString()
                ElseIf TextBox4.Text.Contains("TR/") Then
                    If con.State = ConnectionState.Open Then con.Close()
                    cmd.Connection = con
                    con.Open()
                    cmd.CommandText = "select releasedby from trrot where trno='" + TextBox4.Text + "'"
                    Label3.Text = cmd.ExecuteScalar().ToString()
                ElseIf TextBox4.Text.Contains("ST/") Then
                    If con.State = ConnectionState.Open Then con.Close()
                    cmd.Connection = con
                    con.Open()
                    cmd.CommandText = "select releasedby from trstb where trno='" + TextBox4.Text + "'"
                    Label3.Text = cmd.ExecuteScalar().ToString()
                End If
                Label2.Visible = True
                Label3.Visible = True
                Button1.Text = "Upload and Archive"
                Button1.Width = 202
            Catch ex As Exception

            End Try

        ElseIf GunaCheckBox1.Checked = False Then
            Label2.Visible = False
            Label3.Visible = False
            Button1.Text = "Upload"
            Button1.Width = 135
        End If
    End Sub
End Class