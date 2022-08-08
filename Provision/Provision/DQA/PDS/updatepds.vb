Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class updatepds
    Private _filename As String = String.Empty
    Private Sub updatepds_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadTest()
        'LoadCurrentTest()
    End Sub
    Private Sub LoadCurrentTest()
        If con.State = ConnectionState.Open Then con.Close()
        con.Open()
        Dim qry1 As String
        qry1 = "select * from productlistpds where pdsno='" + TextBox3.Text + "' and status='Active'"
        cmd1 = New SqlCommand(qry1, con)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd1)
        Dim table As New DataTable()
        da.Fill(table)

        Dim TestName As String = table.Rows(0)(3).ToString
        TextBox6.Text = TestName

    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
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
            TextBox6.Clear()
            For i As Integer = 0 To CheckedListBox1.CheckedItems.Count - 1
                TextBox6.Text += CheckedListBox1.CheckedItems(i) + ";"
            Next

            TextBox6.Text = TextBox6.Text.Substring(0, TextBox6.Text.Length - 1)
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
            .Title = "Select File - PDS Upload"
            .ShowDialog(Me)
            _filename = .FileName.ToString()
            GunaLabel7.Text = _filename
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Enter Product Name", vbCritical)
            ElseIf TextBox2.Text = "" Then
                MsgBox("Enter Market", vbCritical)
            ElseIf TextBox3.Text = "" Then
                MsgBox("Enter PDS Number", vbCritical)
            ElseIf TextBox4.Text = "" Then
                MsgBox("Enter PDS Version Number", vbCritical)
            ElseIf TextBox6.Text = "" Then
                MsgBox("Add Test", vbCritical)
            ElseIf GunaLabel7.Text = "." Or GunaLabel7.Text = "" Then
                MsgBox("Upload Document", vbCritical)
            Else
                Dim result1 As Integer = MessageBox.Show("Are you sure to Updated PDS", "Confirmation before Add", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                If result1 = DialogResult.Yes Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd1 As New SqlCommand
                    cmd1.Connection = con
                    cmd1.CommandText = "update productlistpds set status=NULL where pdsno='" + TextBox3.Text + "'"
                    con.Open()
                    cmd1.ExecuteNonQuery()
                    con.Close()

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd2 As New SqlCommand
                    cmd2.Connection = con
                    cmd2.CommandText = "insert into  productlistpds(proname,market,test,pdsno,version,pdsfile,pdsuploadedby,pdsuploadeddate,remarks,status) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox6.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "',@file,'" + homepagedqa.Label1.Text + "',@uploadeddate,'" + TextBox8.Text + "','Active')"
                    cmd2.Parameters.AddWithValue("@file", SqlDbType.VarBinary).Value = File.ReadAllBytes(GunaLabel7.Text)
                    cmd2.Parameters.AddWithValue("@uploadeddate", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd2.ExecuteNonQuery()
                    con.Close()

                    Dim TestName As String() = TextBox6.Text.Split(";"c)

                    For Each item In TestName
                        ListBox1.Items.Add(item)
                    Next
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim reader As SqlDataReader
                    con.Open()
                    Dim qry As String
                    qry = "select test from productlistdoc where proname='" + TextBox1.Text + "' and market='" + TextBox2.Text + "'"
                    cmd = New SqlCommand(qry, con)
                    reader = cmd.ExecuteReader
                    While reader.Read
                        ListBox2.Items.Add(reader("test"))
                    End While

                    Dim unique As Boolean = True

                    For i As Integer = 0 To ListBox1.Items.Count - 1
                        For j As Integer = 0 To ListBox2.Items.Count - 1
                            If (ListBox1.Items(i) = ListBox2.Items(j)) Then
                                unique = False
                            Else
                                ListBox2.SelectedIndex = j
                            End If
                        Next
                        If (unique) Then
                            ListBox3.Items.Add(ListBox1.Items(i))
                        Else
                            ListBox1.SelectedIndex = i
                            unique = True
                        End If
                    Next

                    For Each Testitem In ListBox3.Items
                        If con.State = ConnectionState.Open Then con.Close()
                        Dim cmd4 As New SqlCommand
                        cmd4.Connection = con
                        cmd4.CommandText = "insert into  productlistdoc(proname,market,test) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + Testitem + "')"
                        con.Open()
                        cmd4.ExecuteNonQuery()
                        con.Close()
                    Next

                    MsgBox("PDS Updated Successfully", vbInformation)

                    Dim f1 As viewpdsdetails = DirectCast(Me.Owner, viewpdsdetails)
                    f1.LoadPDSDetails()
                    f1.LoadPDSVersionNo()
                    ' f1.LoadPDSDetailsasPerVersion()
                    Me.Close()
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