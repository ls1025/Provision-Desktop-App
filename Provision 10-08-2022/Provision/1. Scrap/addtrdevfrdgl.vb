Imports System.Data
Imports System.Data.SqlClient


Public Class addtrdevfrdgl
    Dim da As New SqlDataAdapter()
    Private Sub addtrdevfrdgl_Load(sender As Object, e As EventArgs) Handles Me.Load

        Panel7.Hide()
        Panel2.Hide()
        Panel13.Hide()
        Panel19.Hide()
        Panel24.Hide()
        Panel29.Hide()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = " "

        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = " "

        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "1" Then
            Panel7.Show()
            Panel2.Hide()
            Panel13.Hide()
            Panel19.Hide()
            Panel24.Hide()
            Panel29.Hide()
        ElseIf ComboBox2.Text = "2" Then
            Panel7.Show()
            Panel2.Show()
            Panel13.Hide()
            Panel19.Hide()
            Panel24.Hide()
            Panel29.Hide()
        ElseIf ComboBox2.Text = "3" Then
            Panel7.Show()
            Panel2.Show()
            Panel13.Show()
            Panel19.Hide()
            Panel24.Hide()
            Panel29.Hide()
        ElseIf ComboBox2.Text = "4" Then
            Panel7.Show()
            Panel2.Show()
            Panel13.Show()
            Panel19.Show()
            Panel24.Hide()
            Panel29.Hide()
        ElseIf ComboBox2.Text = "5" Then
            Panel7.Show()
            Panel2.Show()
            Panel13.Show()
            Panel19.Show()
            Panel24.Show()
            Panel29.Hide()
        ElseIf ComboBox2.Text = "6" Then
            Panel7.Show()
            Panel2.Show()
            Panel13.Show()
            Panel19.Show()
            Panel24.Show()
            Panel29.Show()
        End If
        Loadtest()
    End Sub
    Private Sub Loadtest()
        Try
            ComboBox3.Items.Clear()
            ComboBox4.Items.Clear()
            ComboBox5.Items.Clear()
            ComboBox6.Items.Clear()
            ComboBox7.Items.Clear()
            ComboBox8.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select test from testmaster"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox3.Items.Add(dr("test"))
                ComboBox4.Items.Add(dr("test"))
                ComboBox5.Items.Add(dr("test"))
                ComboBox6.Items.Add(dr("test"))
                ComboBox7.Items.Add(dr("test"))
                ComboBox8.Items.Add(dr("test"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
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
                TextBox10.Text = ""
                TextBox14.Text = ""
                TextBox18.Text = ""
                TextBox22.Text = ""
                TextBox26.Text = ""
                TextBox30.Text = ""
            ElseIf table.Rows.Count = 0 Then
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox10.Text = ""
                TextBox14.Text = ""
                TextBox18.Text = ""
                TextBox22.Text = ""
                TextBox26.Text = ""
                TextBox30.Text = ""
            Else
                TextBox2.Text = table.Rows(0)(2).ToString()
                TextBox3.Text = table.Rows(0)(3).ToString()
                TextBox4.Text = table.Rows(0)(4).ToString()
                TextBox10.Text = table.Rows(0)(6).ToString()
                TextBox14.Text = table.Rows(0)(6).ToString()
                TextBox18.Text = table.Rows(0)(6).ToString()
                TextBox22.Text = table.Rows(0)(6).ToString()
                TextBox26.Text = table.Rows(0)(6).ToString()
                TextBox30.Text = table.Rows(0)(6).ToString()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            GetGroupleadername()

            If TextBox1.Text = "" Then
                MsgBox("Enter Product Code", vbCritical)
            ElseIf TextBox2.Text = "" Then
                MsgBox("Enter Product Name", vbCritical)
            ElseIf TextBox3.Text = "" Then
                MsgBox("Enter Product Strength", vbCritical)
            ElseIf TextBox4.Text = "" Then
                MsgBox("Enter Market", vbCritical)
            ElseIf TextBox5.Text = "" Then
                MsgBox("Enter Batch Number", vbCritical)
            ElseIf TextBox6.Text = "" Then
                MsgBox("Enter Batch Size", vbCritical)
            ElseIf ComboBox1.Text = "" Then
                MsgBox("Select Condition", vbCritical)
            ElseIf DateTimePicker1.Text = " " Then
                MsgBox("Select Manufacturing date", vbCritical)
            ElseIf DateTimePicker2.Text = " " Then
                MsgBox("Select Expiry date", vbCritical)
            ElseIf TextBox7.Text = "" Then
                MsgBox("Enter Pack Style", vbCritical)
            ElseIf TextBox8.Text = "" Then
                MsgBox("Enter Period", vbCritical)
            ElseIf ComboBox2.Text = "1" Then
                If ComboBox3.Text = "" Then
                    MsgBox("Select Test", vbCritical)
                ElseIf TextBox9.Text = "" Then
                    MsgBox("Enter Details of Test", vbCritical)
                ElseIf TextBox10.Text = "" Then
                    MsgBox("Enter Label Claim", vbCritical)
                ElseIf TextBox11.Text = "" Then
                    MsgBox("Enter Sample Qty", vbCritical)
                Else
                    Me.Cursor = Cursors.AppStarting
                    firsttest()
                    Dim f1 As viewintimationdevfrdgl = DirectCast(Me.Owner, viewintimationdevfrdgl)
                    f1.LoadIntimationDev()
                    MsgBox(ComboBox2.Text + " Intimation Added Successfully", vbInformation)
                    Me.Cursor = Cursors.Default
                    Me.Close()
                End If
            ElseIf ComboBox2.Text = "2" Then
                If ComboBox3.Text = "" Then
                    MsgBox("Select First Test", vbCritical)
                ElseIf TextBox9.Text = "" Then
                    MsgBox("Enter First Details of Test", vbCritical)
                ElseIf TextBox10.Text = "" Then
                    MsgBox("Enter First Label Claim", vbCritical)
                ElseIf TextBox11.Text = "" Then
                    MsgBox("Enter First Sample Qty", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select Second Test", vbCritical)
                ElseIf TextBox13.Text = "" Then
                    MsgBox("Enter Second Details of Test", vbCritical)
                ElseIf TextBox14.Text = "" Then
                    MsgBox("Enter Second Label Claim", vbCritical)
                ElseIf TextBox15.Text = "" Then
                    MsgBox("Enter Second Sample Qty", vbCritical)

                Else
                    Me.Cursor = Cursors.AppStarting
                    firsttest()
                    secondtest()

                    Dim f1 As viewintimationdevfrdgl = DirectCast(Me.Owner, viewintimationdevfrdgl)
                    f1.LoadIntimationDev()
                    MsgBox(ComboBox2.Text + " Intimations Added Successfully", vbInformation)
                    Me.Cursor = Cursors.Default
                    Me.Close()
                End If
            ElseIf ComboBox2.Text = "3" Then
                If ComboBox3.Text = "" Then
                    MsgBox("Select First Test", vbCritical)
                ElseIf TextBox9.Text = "" Then
                    MsgBox("Enter First Details of Test", vbCritical)
                ElseIf TextBox10.Text = "" Then
                    MsgBox("Enter First Label Claim", vbCritical)
                ElseIf TextBox11.Text = "" Then
                    MsgBox("Enter First Sample Qty", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select Second Test", vbCritical)
                ElseIf TextBox13.Text = "" Then
                    MsgBox("Enter Second Details of Test", vbCritical)
                ElseIf TextBox14.Text = "" Then
                    MsgBox("Enter Second Label Claim", vbCritical)
                ElseIf TextBox15.Text = "" Then
                    MsgBox("Enter Second Sample Qty", vbCritical)
                ElseIf ComboBox5.Text = "" Then
                    MsgBox("Select Third Test", vbCritical)
                ElseIf TextBox17.Text = "" Then
                    MsgBox("Enter Third Details of Test", vbCritical)
                ElseIf TextBox18.Text = "" Then
                    MsgBox("Enter Third Label Claim", vbCritical)
                ElseIf TextBox19.Text = "" Then
                    MsgBox("Enter Third Sample Qty", vbCritical)
                Else
                    Me.Cursor = Cursors.AppStarting
                    firsttest()
                    secondtest()
                    thirdtest()

                    Dim f1 As viewintimationdevfrdgl = DirectCast(Me.Owner, viewintimationdevfrdgl)
                    f1.LoadIntimationDev()
                    MsgBox(ComboBox2.Text + " Intimations Added Successfully", vbInformation)
                    Me.Cursor = Cursors.Default
                    Me.Close()

                End If
            ElseIf ComboBox2.Text = "4" Then
                If ComboBox3.Text = "" Then
                    MsgBox("Select First Test", vbCritical)
                ElseIf TextBox9.Text = "" Then
                    MsgBox("Enter First Details of Test", vbCritical)
                ElseIf TextBox10.Text = "" Then
                    MsgBox("Enter First Label Claim", vbCritical)
                ElseIf TextBox11.Text = "" Then
                    MsgBox("Enter First Sample Qty", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select Second Test", vbCritical)
                ElseIf TextBox13.Text = "" Then
                    MsgBox("Enter Second Details of Test", vbCritical)
                ElseIf TextBox14.Text = "" Then
                    MsgBox("Enter Second Label Claim", vbCritical)
                ElseIf TextBox15.Text = "" Then
                    MsgBox("Enter Second Sample Qty", vbCritical)
                ElseIf ComboBox5.Text = "" Then
                    MsgBox("Select Third Test", vbCritical)
                ElseIf TextBox17.Text = "" Then
                    MsgBox("Enter Third Details of Test", vbCritical)
                ElseIf TextBox18.Text = "" Then
                    MsgBox("Enter Third Label Claim", vbCritical)
                ElseIf TextBox19.Text = "" Then
                    MsgBox("Enter Third Sample Qty", vbCritical)
                ElseIf ComboBox6.Text = "" Then
                    MsgBox("Select Fourth Test", vbCritical)
                ElseIf TextBox21.Text = "" Then
                    MsgBox("Enter Fourth Details of Test", vbCritical)
                ElseIf TextBox22.Text = "" Then
                    MsgBox("Enter Fourth Label Claim", vbCritical)
                ElseIf TextBox23.Text = "" Then
                    MsgBox("Enter Fourth Sample Qty", vbCritical)

                Else
                    Me.Cursor = Cursors.AppStarting
                    firsttest()
                    secondtest()
                    thirdtest()
                    fourthtest()
                    Dim f1 As viewintimationdevfrdgl = DirectCast(Me.Owner, viewintimationdevfrdgl)
                    f1.LoadIntimationDev()
                    MsgBox(ComboBox2.Text + " Intimations Added Successfully", vbInformation)
                    Me.Cursor = Cursors.Default
                    Me.Close()

                End If
            ElseIf ComboBox2.Text = "5" Then
                If ComboBox3.Text = "" Then
                    MsgBox("Select First Test", vbCritical)
                ElseIf TextBox9.Text = "" Then
                    MsgBox("Enter First Details of Test", vbCritical)
                ElseIf TextBox10.Text = "" Then
                    MsgBox("Enter First Label Claim", vbCritical)
                ElseIf TextBox11.Text = "" Then
                    MsgBox("Enter First Sample Qty", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select Second Test", vbCritical)
                ElseIf TextBox13.Text = "" Then
                    MsgBox("Enter Second Details of Test", vbCritical)
                ElseIf TextBox14.Text = "" Then
                    MsgBox("Enter Second Label Claim", vbCritical)
                ElseIf TextBox15.Text = "" Then
                    MsgBox("Enter Second Sample Qty", vbCritical)
                ElseIf ComboBox5.Text = "" Then
                    MsgBox("Select Third Test", vbCritical)
                ElseIf TextBox17.Text = "" Then
                    MsgBox("Enter Third Details of Test", vbCritical)
                ElseIf TextBox18.Text = "" Then
                    MsgBox("Enter Third Label Claim", vbCritical)
                ElseIf TextBox19.Text = "" Then
                    MsgBox("Enter Third Sample Qty", vbCritical)
                ElseIf ComboBox6.Text = "" Then
                    MsgBox("Select Fourth Test", vbCritical)
                ElseIf TextBox21.Text = "" Then
                    MsgBox("Enter Fourth Details of Test", vbCritical)
                ElseIf TextBox22.Text = "" Then
                    MsgBox("Enter Fourth Label Claim", vbCritical)
                ElseIf TextBox23.Text = "" Then
                    MsgBox("Enter Fourth Sample Qty", vbCritical)
                ElseIf ComboBox7.Text = "" Then
                    MsgBox("Select Fifth Test", vbCritical)
                ElseIf TextBox25.Text = "" Then
                    MsgBox("Enter Fifth Details of Test", vbCritical)
                ElseIf TextBox26.Text = "" Then
                    MsgBox("Enter Fifth Label Claim", vbCritical)
                ElseIf TextBox27.Text = "" Then
                    MsgBox("Enter Fifth Sample Qty", vbCritical)
                Else
                    Me.Cursor = Cursors.AppStarting
                    firsttest()
                    secondtest()
                    thirdtest()
                    fourthtest()
                    fifthtest()

                    Dim f1 As viewintimationdevfrdgl = DirectCast(Me.Owner, viewintimationdevfrdgl)
                    f1.LoadIntimationDev()
                    MsgBox(ComboBox2.Text + " Intimations Added Successfully", vbInformation)
                    Me.Cursor = Cursors.Default
                    Me.Close()

                End If
            ElseIf ComboBox2.Text = "6" Then
                If ComboBox3.Text = "" Then
                    MsgBox("Select First Test", vbCritical)
                ElseIf TextBox9.Text = "" Then
                    MsgBox("Enter First Details of Test", vbCritical)
                ElseIf TextBox10.Text = "" Then
                    MsgBox("Enter First Label Claim", vbCritical)
                ElseIf TextBox11.Text = "" Then
                    MsgBox("Enter First Sample Qty", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select Second Test", vbCritical)
                ElseIf TextBox13.Text = "" Then
                    MsgBox("Enter Second Details of Test", vbCritical)
                ElseIf TextBox14.Text = "" Then
                    MsgBox("Enter Second Label Claim", vbCritical)
                ElseIf TextBox15.Text = "" Then
                    MsgBox("Enter Second Sample Qty", vbCritical)
                ElseIf ComboBox5.Text = "" Then
                    MsgBox("Select Third Test", vbCritical)
                ElseIf TextBox17.Text = "" Then
                    MsgBox("Enter Third Details of Test", vbCritical)
                ElseIf TextBox18.Text = "" Then
                    MsgBox("Enter Third Label Claim", vbCritical)
                ElseIf TextBox19.Text = "" Then
                    MsgBox("Enter Third Sample Qty", vbCritical)
                ElseIf ComboBox6.Text = "" Then
                    MsgBox("Select Fourth Test", vbCritical)
                ElseIf TextBox21.Text = "" Then
                    MsgBox("Enter Fourth Details of Test", vbCritical)
                ElseIf TextBox22.Text = "" Then
                    MsgBox("Enter Fourth Label Claim", vbCritical)
                ElseIf TextBox23.Text = "" Then
                    MsgBox("Enter Fourth Sample Qty", vbCritical)
                ElseIf ComboBox7.Text = "" Then
                    MsgBox("Select Fifth Test", vbCritical)
                ElseIf TextBox25.Text = "" Then
                    MsgBox("Enter Fifth Details of Test", vbCritical)
                ElseIf TextBox26.Text = "" Then
                    MsgBox("Enter Fifth Label Claim", vbCritical)
                ElseIf TextBox27.Text = "" Then
                    MsgBox("Enter Fifth Sample Qty", vbCritical)
                ElseIf ComboBox8.Text = "" Then
                    MsgBox("Select Sixth Test", vbCritical)
                ElseIf TextBox29.Text = "" Then
                    MsgBox("Enter Sixth Details of Test", vbCritical)
                ElseIf TextBox30.Text = "" Then
                    MsgBox("Enter Sixth Label Claim", vbCritical)
                ElseIf TextBox31.Text = "" Then
                    MsgBox("Enter Sixth Sample Qty", vbCritical)

                Else
                    Me.Cursor = Cursors.AppStarting
                    firsttest()
                    secondtest()
                    thirdtest()
                    fourthtest()
                    fifthtest()
                    sixthtest()

                    Dim f1 As viewintimationdevfrdgl = DirectCast(Me.Owner, viewintimationdevfrdgl)
                    f1.LoadIntimationDev()
                    MsgBox(ComboBox2.Text + " Intimations Added Successfully", vbInformation)
                    Me.Cursor = Cursors.Default
                    Me.Close()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub firsttest()
        If con.State = ConnectionState.Open Then con.Close()
        Dim curValue As Integer
        Dim a As String

        ' Using con As SqlConnection = New SqlConnection("Data Source=VE-IT\SQLEXPRESS;Initial Catalog=vensure;Integrated Security=True;")
        con.Open()
        Dim cmd = New SqlCommand("Select MAX(trno) FROM trdev", con)
        a = cmd.ExecuteScalar().ToString()
        con.Close()

        If String.IsNullOrEmpty(a) Then
            a = "DT/21/0001"
            'TextBox1.Text = result
        ElseIf a.Length = 10 Then
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "DT/21/" + curValue.ToString("D4")
            'TextBox1.Text = result
        ElseIf a.Length > 10 Then
            a = a.Substring(0, a.Length - 3)
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "DT/21/" + curValue.ToString("D4")
        End If

        'End Using

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "insert into trdev (productcode,productname,strength,market,trno,label,btn,btsize,mfgdate,expdate,sampleqty,pack,cndn,period,test,testdetails,remarks,reportingto,requestedby,requestdate,Status) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + a + "','" + TextBox10.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + DateTimePicker1.Text + "','" + DateTimePicker2.Text + "','" + TextBox11.Text + "','" + TextBox7.Text + "','" + ComboBox1.Text + "','" + TextBox8.Text + "','" + ComboBox3.Text + "','" + TextBox9.Text + "','" + TextBox12.Text + "','" + reportername + "','" + Homepagefrdgl.Label1.Text + "',@requestdate,'New TR')"
        cmd1.Parameters.AddWithValue("@requestdate", SqlDbType.Date).Value = DateTime.Now.Date
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()


    End Sub
    Private Sub secondtest()
        If con.State = ConnectionState.Open Then con.Close()
        Dim curValue As Integer
        Dim a As String

        ' Using con As SqlConnection = New SqlConnection("Data Source=VE-IT\SQLEXPRESS;Initial Catalog=vensure;Integrated Security=True;")
        con.Open()
        Dim cmd = New SqlCommand("Select MAX(trno) FROM trdev", con)
        a = cmd.ExecuteScalar().ToString()
        con.Close()

        If String.IsNullOrEmpty(a) Then
            a = "DT/21/0001"
            'TextBox1.Text = result
        ElseIf a.Length = 10 Then
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "DT/21/" + curValue.ToString("D4")
            'TextBox1.Text = result
        ElseIf a.Length > 10 Then
            a = a.Substring(0, a.Length - 3)
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "DT/21/" + curValue.ToString("D4")
        End If

        'End Using

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "insert into trdev (productcode,productname,strength,market,trno,label,btn,btsize,mfgdate,expdate,sampleqty,pack,cndn,period,test,testdetails,remarks,reportingto,requestedby,requestdate,Status) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + a + "','" + TextBox14.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + DateTimePicker1.Text + "','" + DateTimePicker2.Text + "','" + TextBox15.Text + "','" + TextBox7.Text + "','" + ComboBox1.Text + "','" + TextBox8.Text + "','" + ComboBox4.Text + "','" + TextBox13.Text + "','" + TextBox16.Text + "','" + reportername + "','" + Homepagefrdgl.Label1.Text + "',@requestdate,'New TR')"
        cmd1.Parameters.AddWithValue("@requestdate", SqlDbType.Date).Value = DateTime.Now.Date
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()
    End Sub
    Private Sub thirdtest()
        If con.State = ConnectionState.Open Then con.Close()
        Dim curValue As Integer
        Dim a As String

        ' Using con As SqlConnection = New SqlConnection("Data Source=VE-IT\SQLEXPRESS;Initial Catalog=vensure;Integrated Security=True;")
        con.Open()
        Dim cmd = New SqlCommand("Select MAX(trno) FROM trdev", con)
        a = cmd.ExecuteScalar().ToString()
        con.Close()

        If String.IsNullOrEmpty(a) Then
            a = "DT/21/0001"
            'TextBox1.Text = result
        ElseIf a.Length = 10 Then
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "DT/21/" + curValue.ToString("D4")
            'TextBox1.Text = result
        ElseIf a.Length > 10 Then
            a = a.Substring(0, a.Length - 3)
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "DT/21/" + curValue.ToString("D4")
        End If

        'End Using

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "insert into trdev (productcode,productname,strength,market,trno,label,btn,btsize,mfgdate,expdate,sampleqty,pack,cndn,period,test,testdetails,remarks,reportingto,requestedby,requestdate,Status) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + a + "','" + TextBox18.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + DateTimePicker1.Text + "','" + DateTimePicker2.Text + "','" + TextBox19.Text + "','" + TextBox7.Text + "','" + ComboBox1.Text + "','" + TextBox8.Text + "','" + ComboBox5.Text + "','" + TextBox17.Text + "','" + TextBox20.Text + "','" + reportername + "','" + Homepagefrdgl.Label1.Text + "',@requestdate,'New TR')"
        cmd1.Parameters.AddWithValue("@requestdate", SqlDbType.Date).Value = DateTime.Now.Date
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()
    End Sub
    Private Sub fourthtest()
        If con.State = ConnectionState.Open Then con.Close()
        Dim curValue As Integer
        Dim a As String

        ' Using con As SqlConnection = New SqlConnection("Data Source=VE-IT\SQLEXPRESS;Initial Catalog=vensure;Integrated Security=True;")
        con.Open()
        Dim cmd = New SqlCommand("Select MAX(trno) FROM trdev", con)
        a = cmd.ExecuteScalar().ToString()
        con.Close()

        If String.IsNullOrEmpty(a) Then
            a = "DT/21/0001"
            'TextBox1.Text = result
        ElseIf a.Length = 10 Then
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "DT/21/" + curValue.ToString("D4")
            'TextBox1.Text = result
        ElseIf a.Length > 10 Then
            a = a.Substring(0, a.Length - 3)
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "DT/21/" + curValue.ToString("D4")
        End If

        'End Using

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "insert into trdev (productcode,productname,strength,market,trno,label,btn,btsize,mfgdate,expdate,sampleqty,pack,cndn,period,test,testdetails,remarks,reportingto,requestedby,requestdate,Status) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + a + "','" + TextBox22.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + DateTimePicker1.Text + "','" + DateTimePicker2.Text + "','" + TextBox23.Text + "','" + TextBox7.Text + "','" + ComboBox1.Text + "','" + TextBox8.Text + "','" + ComboBox6.Text + "','" + TextBox21.Text + "','" + TextBox24.Text + "','" + reportername + "','" + Homepagefrdgl.Label1.Text + "',@requestdate,'New TR')"
        cmd1.Parameters.AddWithValue("@requestdate", SqlDbType.Date).Value = DateTime.Now.Date
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()
    End Sub
    Private Sub fifthtest()
        If con.State = ConnectionState.Open Then con.Close()
        Dim curValue As Integer
        Dim a As String

        ' Using con As SqlConnection = New SqlConnection("Data Source=VE-IT\SQLEXPRESS;Initial Catalog=vensure;Integrated Security=True;")
        con.Open()
        Dim cmd = New SqlCommand("Select MAX(trno) FROM trdev", con)
        a = cmd.ExecuteScalar().ToString()
        con.Close()

        If String.IsNullOrEmpty(a) Then
            a = "DT/21/0001"
            'TextBox1.Text = result
        ElseIf a.Length = 10 Then
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "DT/21/" + curValue.ToString("D4")
            'TextBox1.Text = result
        ElseIf a.Length > 10 Then
            a = a.Substring(0, a.Length - 3)
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "DT/21/" + curValue.ToString("D4")
        End If

        'End Using

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "insert into trdev (productcode,productname,strength,market,trno,label,btn,btsize,mfgdate,expdate,sampleqty,pack,cndn,period,test,testdetails,remarks,reportingto,requestedby,requestdate,Status) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + a + "','" + TextBox26.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + DateTimePicker1.Text + "','" + DateTimePicker2.Text + "','" + TextBox27.Text + "','" + TextBox7.Text + "','" + ComboBox1.Text + "','" + TextBox8.Text + "','" + ComboBox7.Text + "','" + TextBox25.Text + "','" + TextBox28.Text + "','" + reportername + "','" + Homepagefrdgl.Label1.Text + "',@requestdate,'New TR')"
        cmd1.Parameters.AddWithValue("@requestdate", SqlDbType.Date).Value = DateTime.Now.Date
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()
    End Sub
    Private Sub sixthtest()
        If con.State = ConnectionState.Open Then con.Close()
        Dim curValue As Integer
        Dim a As String

        ' Using con As SqlConnection = New SqlConnection("Data Source=VE-IT\SQLEXPRESS;Initial Catalog=vensure;Integrated Security=True;")
        con.Open()
        Dim cmd = New SqlCommand("Select MAX(trno) FROM trdev", con)
        a = cmd.ExecuteScalar().ToString()
        con.Close()

        If String.IsNullOrEmpty(a) Then
            a = "DT/21/0001"
            'TextBox1.Text = result
        ElseIf a.Length = 10 Then
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "DT/21/" + curValue.ToString("D4")
            'TextBox1.Text = result
        ElseIf a.Length > 10 Then
            a = a.Substring(0, a.Length - 3)
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "DT/21/" + curValue.ToString("D4")
        End If

        'End Using

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "insert into trdev (productcode,productname,strength,market,trno,label,btn,btsize,mfgdate,expdate,sampleqty,pack,cndn,period,test,testdetails,remarks,reportingto,requestedby,requestdate,Status) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + a + "','" + TextBox30.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + DateTimePicker1.Text + "','" + DateTimePicker2.Text + "','" + TextBox31.Text + "','" + TextBox7.Text + "','" + ComboBox1.Text + "','" + TextBox8.Text + "','" + ComboBox8.Text + "','" + TextBox29.Text + "','" + TextBox32.Text + "','" + reportername + "','" + Homepagefrdgl.Label1.Text + "',@requestdate,'New TR')"
        cmd1.Parameters.AddWithValue("@requestdate", SqlDbType.Date).Value = DateTime.Now.Date
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()
    End Sub
    Dim reportername As String
    Private Sub GetGroupleadername()
        If con.State = ConnectionState.Open Then con.Close()
        Dim qry1 As String
        qry1 = "select reportto from users where fullname='" + Homepagefrdgl.Label1.Text + "'"
        cmd1 = New SqlCommand(qry1, con)
        con.Open()
        reportername = cmd1.ExecuteScalar().ToString()
    End Sub
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "MM/yyyy"
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "MM/yyyy"
    End Sub
End Class