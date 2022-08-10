Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class viewpdsdetailsfrd
    Private Sub GunaLabel1_Click(sender As Object, e As EventArgs) Handles GunaLabel1.Click

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub viewpdsdetailsfrd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPDSDetails()
        LoadPDSVersionNo()
        LoadTest()
    End Sub

    Dim TestName As String
    Public Sub LoadPDSDetails()
        If con.State = ConnectionState.Open Then con.Close()
        con.Open()
        Dim qry1 As String
        qry1 = "select * from productlistpds where proname='" + Label1.Text + "' and market='" + Label2.Text + "' and status='Active'"
        cmd1 = New SqlCommand(qry1, con)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd1)
        Dim table As New DataTable()
        da.Fill(table)

        TestName = table.Rows(0)(3).ToString

        Dim PDSNo As String = table.Rows(0)(4).ToString
        Label3.Text = PDSNo

        Dim VerNo As String = table.Rows(0)(5).ToString
        Label4.Text = VerNo

        Dim Upby As String = table.Rows(0)(7).ToString
        Label5.Text = Upby

        Dim UpDate As Date = Date.ParseExact(table.Rows(0)(8), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Label6.Text = UpDate

        Dim Remark As String = table.Rows(0)(9).ToString
        Label7.Text = Remark

    End Sub
    Public Sub LoadPDSVersionNo()
        ComboBox1.Items.Clear()

        'Load Proname from development
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = "select * from productlistpds where proname='" + Label1.Text + "' and market='" + Label2.Text + "' order by version DESC"
        con.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        While dr.Read
            ComboBox1.Items.Add(dr("version"))
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub LoadTest()
        If con.State = ConnectionState.Open Then con.Close()
        con.Open()
        Dim qry As String
        qry = "select test from productlistpds where pdsno='" + Label3.Text + "' and version='" + Label4.Text + "' and status='Active'"
        cmd1 = New SqlCommand(qry, con)
        Dim s As String = cmd1.ExecuteScalar.ToString()
        'Dim substring As String
        Dim sp As String() = s.Split(";"c)

        For Each item As String In sp
            DataGridView1.Rows.Add(item)
            'ListBox1.Items.Add(item)
        Next
        con.Close()

    End Sub

    Public Sub LoadPDSDetailsasPerVersion()

        DataGridView1.Rows.Clear()
        If con.State = ConnectionState.Open Then con.Close()
        con.Open()
        Dim qry1 As String
        qry1 = "select * from productlistpds where pdsno='" + Label3.Text + "' and version='" + ComboBox1.Text + "'"
        cmd1 = New SqlCommand(qry1, con)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd1)
        Dim table As New DataTable()
        da.Fill(table)

        Dim TestName As String = table.Rows(0)(3).ToString
        'Dim substring As String
        Dim sp As String() = TestName.Split(";"c)

        For Each item As String In sp
            DataGridView1.Rows.Add(item)
            'ListBox1.Items.Add(item)
        Next

        Dim PDSNo As String = table.Rows(0)(4).ToString
        Label3.Text = PDSNo

        Dim VerNo As String = table.Rows(0)(5).ToString
        Label4.Text = VerNo

        Dim Upby As String = table.Rows(0)(7).ToString
        Label5.Text = Upby

        Dim UpDate As Date = Date.ParseExact(table.Rows(0)(8), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        Label6.Text = UpDate

        Dim Remark As String = table.Rows(0)(9).ToString
        Label7.Text = Remark


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        LoadPDSDetailsasPerVersion()
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        ViewPDSFile()
    End Sub
    Private Sub ViewPDSFile()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry1 As String
            qry1 = "select pdsfile from productlistpds where pdsno='" + Label3.Text + "' and version='" + Label4.Text + "'"
            cmd = New SqlCommand(qry1, con)
            Dim sFilePath As String
            Dim buffer As Byte()
            con.Open()
            buffer = cmd.ExecuteScalar()
            con.Close()
            sFilePath = System.IO.Path.GetTempFileName()
            System.IO.File.Move(sFilePath, System.IO.Path.ChangeExtension(sFilePath, ".pdf"))
            sFilePath = System.IO.Path.ChangeExtension(sFilePath, ".pdf")
            System.IO.File.WriteAllBytes(sFilePath, buffer)
            Dim act As Action(Of String) = New Action(Of String)(AddressOf OpenPDFFile)
            act.BeginInvoke(sFilePath, Nothing, Nothing)
        Catch ex As Exception
            MsgBox("Not Available", vbExclamation)
        End Try
    End Sub
    Private Shared Sub OpenPDFFile(ByVal sFilePath)
        Using p As New System.Diagnostics.Process
            p.StartInfo = New System.Diagnostics.ProcessStartInfo(sFilePath)
            p.Start()
            p.WaitForExit()
            Try
                System.IO.File.Delete(sFilePath)
            Catch
            End Try
        End Using
    End Sub

End Class