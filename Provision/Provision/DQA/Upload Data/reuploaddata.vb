Imports System.Data
Imports System.Data.SqlClient
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports System.Threading
Imports System.Diagnostics
Imports System.ComponentModel

Public Class reuploaddata
    Private _filename As String = String.Empty
    Private Sub reuploaddata_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 60, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Invalid TR Number", vbCritical)
        ElseIf Label1.Text = "" Then
            MsgBox("Invalid File Name", vbCritical)
        ElseIf Label1.Text = "." Then
            MsgBox("Invalid File Name", vbCritical)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure to Upload Data for this TR Numbers", "Confirmation before Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.Yes Then
                Try
                    ' For Each item In CheckedListBox1.Items
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd1 As New SqlCommand
                    cmd1.Connection = con
                    cmd1.CommandText = "update trdev set datauploadby='" + homepage.Label1.Text + "',datauploaddate=@datauploaddate,datafile=@datafile,Status='Data Uploaded' where trno='" + TextBox1.Text + "'"
                    cmd1.Parameters.AddWithValue("@datafile", SqlDbType.VarBinary).Value = File.ReadAllBytes(Label1.Text)
                    cmd1.Parameters.AddWithValue("@datauploaddate", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd1.ExecuteNonQuery()

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd2 As New SqlCommand
                    cmd2.Connection = con
                    cmd2.CommandText = "update trrot set datauploadby='" + homepage.Label1.Text + "',datauploaddate=@datauploaddate,datafile=@datafile,Status='Data Uploaded' where trno='" + TextBox1.Text + "'"
                    cmd2.Parameters.AddWithValue("@datafile", SqlDbType.VarBinary).Value = File.ReadAllBytes(Label1.Text)
                    cmd2.Parameters.AddWithValue("@datauploaddate", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd2.ExecuteNonQuery()

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd3 As New SqlCommand
                    cmd3.Connection = con
                    cmd3.CommandText = "update trstb set datauploadby='" + homepage.Label1.Text + "',datauploaddate=@datauploaddate,datafile=@datafile,Status='Data Uploaded' where trno='" + TextBox1.Text + "'"
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
                'End If


                MsgBox("Data Release for selected TR Numbers", vbInformation)
            End If
        End If
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
End Class