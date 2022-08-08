Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class addpds
    Private _filename As String = String.Empty
    Private Sub addpds_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadTest()
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            Dim qry As String
            qry = "SELECT * FROM productmaster where procode='" + TextBox1.Text + "'"
            cmd = New SqlCommand(qry, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            da.Fill(table)
            If TextBox1.Text = "" Then
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""

            ElseIf table.Rows.Count = 0 Then
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""

            Else
                TextBox2.Text = table.Rows(0)(2).ToString()
                TextBox3.Text = table.Rows(0)(4).ToString()
                TextBox4.Text = "PDS/" + TextBox1.Text

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadTest()
        Try
            'CheckedListBox1.Items.Clear()
            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim reader As SqlDataReader
            con.Open()
            Dim qry As String
            qry = "select (test) from testmaster order by test ASC"
            cmd = New SqlCommand(qry, con)
            reader = cmd.ExecuteReader
            While reader.Read
                CheckedListBox1.Items.Add(reader("test"))
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged
        Try
            TextBox7.Clear()
            For i As Integer = 0 To CheckedListBox1.CheckedItems.Count - 1
                TextBox7.Text += CheckedListBox1.CheckedItems(i) + ";"
            Next
            TextBox7.Text = TextBox7.Text.Substring(0, TextBox7.Text.Length - 1)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        With FileDialogs
            .FileName = ""
            .CheckFileExists = True : .CheckPathExists = True
            .Filter = "PDF Files (*.pdf)|*.pdf"
            .Multiselect = False : .ReadOnlyChecked = False
            .RestoreDirectory = True : .ShowHelp = False
            .Title = "Select File - Documnet Upload"
            .ShowDialog(Me)
            _filename = .FileName.ToString()
            GunaLabel7.Text = _filename
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Enter Product Code", vbCritical)
            ElseIf TextBox2.Text = "" Then
                MsgBox("Enter Product Name", vbCritical)
            ElseIf TextBox3.Text = "" Then
                MsgBox("Enter Market", vbCritical)
            ElseIf TextBox4.Text = "" Then
                MsgBox("Enter PDS Number", vbCritical)
            ElseIf TextBox5.Text = "" Then
                MsgBox("Enter PDS Version Number", vbCritical)
            ElseIf TextBox7.Text = "" Then
                MsgBox("Add Test", vbCritical)
            ElseIf GunaLabel7.Text = "." Or GunaLabel7.Text = "" Then
                MsgBox("Upload Document", vbCritical)
            Else

                If con.State = ConnectionState.Open Then con.Close()
                Dim qry As String
                qry = "select COUNT(proname) from productlistpds where proname='" + TextBox2.Text + "' and market='" + TextBox3.Text + "' "
                cmd1 = New SqlCommand(qry, con)
                con.Open()
                Dim a As String
                a = cmd1.ExecuteScalar().ToString()
                con.Close()
                If a = 0 Then
                    Dim result As Integer = MessageBox.Show("Are you sure to Add PDS", "Confirmation before Add", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                    If result = DialogResult.Yes Then

                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd2 As New SqlCommand
                        cmd2.Connection = con
                        cmd2.CommandText = "insert into  productlistpds(proname,market,test,pdsno,version,pdsfile,pdsuploadedby,pdsuploadeddate,remarks,status) values('" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox7.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "',@file,'" + homepagedqa.Label1.Text + "',@uploadeddate,'" + TextBox8.Text + "','Active')"
                        cmd2.Parameters.AddWithValue("@file", SqlDbType.VarBinary).Value = File.ReadAllBytes(GunaLabel7.Text)
                        cmd2.Parameters.AddWithValue("@uploadeddate", SqlDbType.Date).Value = DateTime.Now.Date
                        con.Open()
                        cmd2.ExecuteNonQuery()
                        con.Close()


                        Dim TestName As String() = TextBox7.Text.Split(";"c)
                        For Each item As String In TestName
                            If con.State = ConnectionState.Open Then con.Close()
                            Dim cmd3 As New SqlCommand
                            cmd3.Connection = con
                            cmd3.CommandText = "insert into  productlistdoc(proname,market,test) values('" + TextBox2.Text + "','" + TextBox3.Text + "','" + item + "')"
                            con.Open()
                            cmd3.ExecuteNonQuery()
                            con.Close()
                        Next

                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd4 As New SqlCommand
                        cmd4.Connection = con
                        cmd4.CommandText = "update productmaster set pds='Yes' where proname='" + TextBox2.Text + "' and market='" + TextBox3.Text + "'"
                        'cmd4.Parameters.AddWithValue("@file", SqlDbType.VarBinary).Value = File.ReadAllBytes(GunaLabel7.Text)
                        ' cmd4.Parameters.AddWithValue("@uploadeddate", SqlDbType.Date).Value = DateTime.Now.Date
                        con.Open()
                        cmd4.ExecuteNonQuery()
                        con.Close()

                        MsgBox("PDS Added Successfully", vbInformation)

                        Dim f1 As viewproductpds = DirectCast(Me.Owner, viewproductpds)
                        f1.loadData()
                        Me.Close()
                    End If

                ElseIf a > 0 Then
                    MsgBox("PDS is Already Available", vbCritical)
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Me.Close()
    End Sub
End Class