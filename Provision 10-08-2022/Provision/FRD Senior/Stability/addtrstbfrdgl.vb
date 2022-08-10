Imports System.Data
Imports System.Data.SqlClient


Public Class addtrstbfrdgl
    Dim da As New SqlDataAdapter()
    Private Sub addtrstbfrdgl_Load(sender As Object, e As EventArgs) Handles Me.Load

        Panel7.Hide()
        Panel2.Hide()
        Panel13.Hide()
        Panel19.Hide()
        Panel24.Hide()
        Panel29.Hide()

        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

    End Sub
    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        Dim senderComboBox As ComboBox = DirectCast(sender, ComboBox)
        Dim width As Integer = senderComboBox.DropDownWidth
        Dim g As Graphics = senderComboBox.CreateGraphics()
        Dim font As System.Drawing.Font = senderComboBox.Font
        Dim vertScrollBarWidth As Integer = If(senderComboBox.Items.Count > senderComboBox.MaxDropDownItems, SystemInformation.VerticalScrollBarWidth, 0)

        Dim newWidth As Integer
        For Each s As String In DirectCast(sender, ComboBox).Items
            newWidth = CInt(g.MeasureString(s, font).Width) + vertScrollBarWidth
            If width < newWidth Then
                width = newWidth
            End If
        Next s
        senderComboBox.DropDownWidth = width
    End Sub
    Private Sub LoadContion()
        Try
            ComboBox1.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(cndn) from plnr where proname='" + TextBox2.Text + "' and strength='" + TextBox3.Text + "'"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("cndn"))
            End While
            dr.Close()

            con.Close()
            ComboBox1.Items.Add("2-8°C")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
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
            Dim reader As SqlDataReader
            con.Open()
            Dim qry As String
            qry = "select test from productlistdoc where proname='" + TextBox2.Text + "' and market='" + TextBox4.Text + "' and stpno IS NOT NULL order by test ASC"
            cmd1 = New SqlCommand(qry, con)
            reader = cmd1.ExecuteReader
            While reader.Read
                ComboBox3.Items.Add(reader("test"))
                ComboBox4.Items.Add(reader("test"))
                ComboBox5.Items.Add(reader("test"))
                ComboBox6.Items.Add(reader("test"))
                ComboBox7.Items.Add(reader("test"))
                ComboBox8.Items.Add(reader("test"))
            End While
            con.Close()
        Catch ex As SqlException
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
            qry = "SELECT * FROM productmaster where procode='" + TextBox1.Text + "' and productstatus='Active'"
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
                LoadContion()
                GetSampleDetails()

            End If
            ClearFields()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave

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
            ElseIf ComboBox9.Text = "" Then
                MsgBox("Enter Batch Number", vbCritical)
            ElseIf TextBox6.Text = "" Then
                MsgBox("Enter Batch Size", vbCritical)
            ElseIf ComboBox1.Text = "" Then
                MsgBox("Select Condition", vbCritical)
            ElseIf GunaTextBox1.Text = "" Then
                MsgBox("Select Manufacturing Date", vbCritical)
            ElseIf GunaTextBox2.Text = "" Then
                MsgBox("Select Expiry Date", vbCritical)
            ElseIf ComboBox10.Text = "" Then
                MsgBox("Enter Pack Style", vbCritical)
            ElseIf ComboBox11.Text = "" Then
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
                    Dim f1 As viewintimationstbfrdgl = DirectCast(Me.Owner, viewintimationstbfrdgl)
                    f1.LoadIntimationStb()
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
                    Dim f1 As viewintimationstbfrdgl = DirectCast(Me.Owner, viewintimationstbfrdgl)
                    f1.LoadIntimationStb()
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
                    Dim f1 As viewintimationstbfrdgl = DirectCast(Me.Owner, viewintimationstbfrdgl)
                    f1.LoadIntimationStb()
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
                    Dim f1 As viewintimationstbfrdgl = DirectCast(Me.Owner, viewintimationstbfrdgl)
                    f1.LoadIntimationStb()
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
                    Dim f1 As viewintimationstbfrdgl = DirectCast(Me.Owner, viewintimationstbfrdgl)
                    f1.LoadIntimationStb()
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

                    Dim f1 As viewintimationstbfrdgl = DirectCast(Me.Owner, viewintimationstbfrdgl)
                    f1.LoadIntimationStb()
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
        Dim cmd = New SqlCommand("Select MAX(trno) FROM trstb", con)
        a = cmd.ExecuteScalar().ToString()
        con.Close()
        Dim LastString_Year As String = DateTime.Now.Date.Year
        LastString_Year = LastString_Year.Remove(1, 2)
        If String.IsNullOrEmpty(a) Then
            a = "ST/" + LastString_Year + "/0001"
            'TextBox1.Text = result
        ElseIf a.Length = 10 Then
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "ST/" + LastString_Year + "/" + curValue.ToString("D4")
            'TextBox1.Text = result
        ElseIf a.Length > 10 Then
            a = a.Substring(0, a.Length - 3)
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "ST/" + LastString_Year + "/" + curValue.ToString("D4")
        End If

        'End Using

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "insert into trstb (productcode,productname,strength,market,trno,label,btn,btsize,mfgdate,expdate,sampleqty,pack,cndn,period,test,testdetails,remarks,reportingto,requestedby,requestdate,Status) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + a + "','" + TextBox10.Text + "','" + ComboBox9.Text + "','" + TextBox6.Text + "','" + GunaTextBox1.Text + "','" + GunaTextBox2.Text + "','" + TextBox11.Text + "','" + ComboBox10.Text + "','" + ComboBox1.Text + "','" + ComboBox11.Text + "','" + ComboBox3.Text + "','" + TextBox9.Text + "','" + TextBox12.Text + "','" + reportername + "','" + Homepagefrdgl.Label1.Text + "',@requestdate,'New TR')"
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
        Dim cmd = New SqlCommand("Select MAX(trno) FROM trstb", con)
        a = cmd.ExecuteScalar().ToString()
        con.Close()
        Dim LastString_Year As String = DateTime.Now.Date.Year
        LastString_Year = LastString_Year.Remove(1, 2)
        If String.IsNullOrEmpty(a) Then
            a = "ST/" + LastString_Year + "/0001"
            'TextBox1.Text = result
        ElseIf a.Length = 10 Then
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "ST/" + LastString_Year + "/" + curValue.ToString("D4")
            'TextBox1.Text = result
        ElseIf a.Length > 10 Then
            a = a.Substring(0, a.Length - 3)
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "ST/" + LastString_Year + "/" + curValue.ToString("D4")
        End If

        'End Using

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "insert into trstb (productcode,productname,strength,market,trno,label,btn,btsize,mfgdate,expdate,sampleqty,pack,cndn,period,test,testdetails,remarks,reportingto,requestedby,requestdate,Status) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + a + "','" + TextBox14.Text + "','" + ComboBox9.Text + "','" + TextBox6.Text + "','" + GunaTextBox1.Text + "','" + GunaTextBox2.Text + "','" + TextBox15.Text + "','" + ComboBox10.Text + "','" + ComboBox1.Text + "','" + ComboBox11.Text + "','" + ComboBox4.Text + "','" + TextBox13.Text + "','" + TextBox16.Text + "','" + reportername + "','" + Homepagefrdgl.Label1.Text + "',@requestdate,'New TR')"
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
        Dim cmd = New SqlCommand("Select MAX(trno) FROM trstb", con)
        a = cmd.ExecuteScalar().ToString()
        con.Close()
        Dim LastString_Year As String = DateTime.Now.Date.Year
        LastString_Year = LastString_Year.Remove(1, 2)
        If String.IsNullOrEmpty(a) Then
            a = "ST/" + LastString_Year + "/0001"
            'TextBox1.Text = result
        ElseIf a.Length = 10 Then
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "ST/" + LastString_Year + "/" + curValue.ToString("D4")
            'TextBox1.Text = result
        ElseIf a.Length > 10 Then
            a = a.Substring(0, a.Length - 3)
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "ST/" + LastString_Year + "/" + curValue.ToString("D4")
        End If

        'End Using

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "insert into trstb (productcode,productname,strength,market,trno,label,btn,btsize,mfgdate,expdate,sampleqty,pack,cndn,period,test,testdetails,remarks,reportingto,requestedby,requestdate,Status) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + a + "','" + TextBox18.Text + "','" + ComboBox9.Text + "','" + TextBox6.Text + "','" + GunaTextBox1.Text + "','" + GunaTextBox2.Text + "','" + TextBox19.Text + "','" + ComboBox10.Text + "','" + ComboBox1.Text + "','" + ComboBox11.Text + "','" + ComboBox5.Text + "','" + TextBox17.Text + "','" + TextBox20.Text + "','" + reportername + "','" + Homepagefrdgl.Label1.Text + "',@requestdate,'New TR')"
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
        Dim cmd = New SqlCommand("Select MAX(trno) FROM trstb", con)
        a = cmd.ExecuteScalar().ToString()
        con.Close()
        Dim LastString_Year As String = DateTime.Now.Date.Year
        LastString_Year = LastString_Year.Remove(1, 2)
        If String.IsNullOrEmpty(a) Then
            a = "ST/" + LastString_Year + "/0001"
            'TextBox1.Text = result
        ElseIf a.Length = 10 Then
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "ST/" + LastString_Year + "/" + curValue.ToString("D4")
            'TextBox1.Text = result
        ElseIf a.Length > 10 Then
            a = a.Substring(0, a.Length - 3)
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "ST/" + LastString_Year + "/" + curValue.ToString("D4")
        End If

        'End Using

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "insert into trstb (productcode,productname,strength,market,trno,label,btn,btsize,mfgdate,expdate,sampleqty,pack,cndn,period,test,testdetails,remarks,reportingto,requestedby,requestdate,Status) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + a + "','" + TextBox22.Text + "','" + ComboBox9.Text + "','" + TextBox6.Text + "','" + GunaTextBox1.Text + "','" + GunaTextBox2.Text + "','" + TextBox23.Text + "','" + ComboBox10.Text + "','" + ComboBox1.Text + "','" + ComboBox11.Text + "','" + ComboBox6.Text + "','" + TextBox21.Text + "','" + TextBox24.Text + "','" + reportername + "','" + Homepagefrdgl.Label1.Text + "',@requestdate,'New TR')"
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
        Dim cmd = New SqlCommand("Select MAX(trno) FROM trstb", con)
        a = cmd.ExecuteScalar().ToString()
        con.Close()
        Dim LastString_Year As String = DateTime.Now.Date.Year
        LastString_Year = LastString_Year.Remove(1, 2)
        If String.IsNullOrEmpty(a) Then
            a = "ST/" + LastString_Year + "/0001"
            'TextBox1.Text = result
        ElseIf a.Length = 10 Then
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "ST/" + LastString_Year + "/" + curValue.ToString("D4")
            'TextBox1.Text = result
        ElseIf a.Length > 10 Then
            a = a.Substring(0, a.Length - 3)
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "ST/" + LastString_Year + "/" + curValue.ToString("D4")
        End If

        'End Using

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "insert into trstb (productcode,productname,strength,market,trno,label,btn,btsize,mfgdate,expdate,sampleqty,pack,cndn,period,test,testdetails,remarks,reportingto,requestedby,requestdate,Status) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + a + "','" + TextBox26.Text + "','" + ComboBox9.Text + "','" + TextBox6.Text + "','" + GunaTextBox1.Text + "','" + GunaTextBox2.Text + "','" + TextBox27.Text + "','" + ComboBox10.Text + "','" + ComboBox1.Text + "','" + ComboBox11.Text + "','" + ComboBox7.Text + "','" + TextBox25.Text + "','" + TextBox28.Text + "','" + reportername + "','" + Homepagefrdgl.Label1.Text + "',@requestdate,'New TR')"
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
        Dim cmd = New SqlCommand("Select MAX(trno) FROM trstb", con)
        a = cmd.ExecuteScalar().ToString()
        con.Close()
        Dim LastString_Year As String = DateTime.Now.Date.Year
        LastString_Year = LastString_Year.Remove(1, 2)
        If String.IsNullOrEmpty(a) Then
            a = "ST/" + LastString_Year + "/0001"
            'TextBox1.Text = result
        ElseIf a.Length = 10 Then
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "ST/" + LastString_Year + "/" + curValue.ToString("D4")
            'TextBox1.Text = result
        ElseIf a.Length > 10 Then
            a = a.Substring(0, a.Length - 3)
            a = a.Substring(6)
            Int32.TryParse(a, curValue)
            curValue = curValue + 1
            a = "ST/" + LastString_Year + "/" + curValue.ToString("D4")
        End If

        'End Using

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New SqlCommand
        cmd1.Connection = con
        cmd1.CommandText = "insert into trstb (productcode,productname,strength,market,trno,label,btn,btsize,mfgdate,expdate,sampleqty,pack,cndn,period,test,testdetails,remarks,reportingto,requestedby,requestdate,Status) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + a + "','" + TextBox30.Text + "','" + ComboBox9.Text + "','" + TextBox6.Text + "','" + GunaTextBox1.Text + "','" + GunaTextBox2.Text + "','" + TextBox31.Text + "','" + ComboBox10.Text + "','" + ComboBox1.Text + "','" + ComboBox11.Text + "','" + ComboBox8.Text + "','" + TextBox29.Text + "','" + TextBox32.Text + "','" + reportername + "','" + Homepagefrdgl.Label1.Text + "',@requestdate,'New TR')"
        cmd1.Parameters.AddWithValue("@requestdate", SqlDbType.Date).Value = DateTime.Now.Date
        con.Open()
        cmd1.ExecuteNonQuery()
        con.Close()
    End Sub
    Dim reportername As String

    Private Sub GetGroupleadername()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            Dim qry As String
            qry = "select * from users where fullname='" + Homepagefrdj.Label1.Text + "'"
            cmd = New SqlCommand(qry, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            da.Fill(table)
            reportername = table.Rows(0)(5).ToString()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GunaLinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GunaLinkLabel1.LinkClicked
        Try
            PrintPreviewDialog1.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GunaLinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GunaLinkLabel2.LinkClicked
        Try
            PrintPreviewDialog2.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GunaLinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GunaLinkLabel3.LinkClicked
        Try
            PrintPreviewDialog3.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GunaLinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GunaLinkLabel4.LinkClicked
        Try
            PrintPreviewDialog4.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GunaLinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GunaLinkLabel5.LinkClicked
        Try
            PrintPreviewDialog5.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GunaLinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GunaLinkLabel6.LinkClicked
        Try
            PrintPreviewDialog6.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load
        CType(PrintPreviewDialog1.Controls(1), ToolStrip).Items(0).Enabled = False
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1.5
        DirectCast(PrintPreviewDialog1, Form).WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PrintPreviewDialog2_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog2.Load
        CType(PrintPreviewDialog2.Controls(1), ToolStrip).Items(0).Enabled = False
        PrintPreviewDialog2.PrintPreviewControl.Zoom = 1.5
        DirectCast(PrintPreviewDialog2, Form).WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PrintPreviewDialog3_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog3.Load
        CType(PrintPreviewDialog3.Controls(1), ToolStrip).Items(0).Enabled = False
        PrintPreviewDialog3.PrintPreviewControl.Zoom = 1.5
        DirectCast(PrintPreviewDialog3, Form).WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PrintPreviewDialog4_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog4.Load
        CType(PrintPreviewDialog4.Controls(1), ToolStrip).Items(0).Enabled = False
        PrintPreviewDialog4.PrintPreviewControl.Zoom = 1.5
        DirectCast(PrintPreviewDialog4, Form).WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PrintPreviewDialog5_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog5.Load
        CType(PrintPreviewDialog5.Controls(1), ToolStrip).Items(0).Enabled = False
        PrintPreviewDialog5.PrintPreviewControl.Zoom = 1.5
        DirectCast(PrintPreviewDialog5, Form).WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PrintPreviewDialog6_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog6.Load
        CType(PrintPreviewDialog6.Controls(1), ToolStrip).Items(0).Enabled = False
        PrintPreviewDialog6.PrintPreviewControl.Zoom = 1.5
        DirectCast(PrintPreviewDialog6, Form).WindowState = FormWindowState.Maximized
    End Sub
    Private Sub PrintDocument1_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try

            Dim ReportFont1 As Font = New Drawing.Font("Times New Roman", 10, FontStyle.Bold)
            Dim ReportFont2 As Font = New Drawing.Font("Times New Roman", 12, FontStyle.Bold)
            Dim ReportFont3 As Font = New Drawing.Font("Times New Roman", 11, FontStyle.Bold)
            Dim ReportFont4 As Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold)
            Dim ReportFont5 As Font = New Drawing.Font("Times New Roman", 10)
            Dim blackPen As New Pen(Color.Black, 1)
            e.Graphics.DrawString("Test Request No :", ReportFont1, Brushes.Black, 23, 39)
            e.Graphics.DrawString("As per the sequance", ReportFont5, Brushes.Black, 137, 40)

            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 590, 39)
            e.Graphics.DrawString(DateTime.Now.Date, ReportFont5, Brushes.Black, 633, 40)


            e.Graphics.DrawString("FORMULATION RESEARCH AND DEVELOPMENT", ReportFont2, Brushes.Black, 204, 108)
            e.Graphics.DrawString("V-Ensure Pharma Technologies Pvt Ltd", ReportFont3, Brushes.Black, 273, 130)
            e.Graphics.DrawString("Navi Mumbai", ReportFont3, Brushes.Black, 345, 151)
            e.Graphics.DrawString("TEST REQUISITION SHEET", ReportFont4, Brushes.Black, 259, 180)

            e.Graphics.DrawString("Print Copy No. :", ReportFont1, Brushes.Black, 610, 151)
            e.Graphics.DrawString("1", ReportFont5, Brushes.Black, 722, 151)

            e.Graphics.DrawString("Product Code :", ReportFont1, Brushes.Black, 23, 223)
            e.Graphics.DrawString(TextBox1.Text, ReportFont5, Brushes.Black, 132, 223)



            e.Graphics.DrawString("Product Name :", ReportFont1, Brushes.Black, 225, 223)

            'e.Graphics.DrawRectangle(blackPen, 326, 210, 445, 40)
            'Dim rect1 As Rectangle = New Rectangle(326, 210, 445, 40)
            Dim StringFormat As StringFormat = New StringFormat()
            StringFormat.Alignment = StringAlignment.Near
            StringFormat.LineAlignment = StringAlignment.Center

            e.Graphics.DrawString(TextBox2.Text + " " + TextBox3.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(326, 210, 445, 40), StringFormat)

            ' e.Graphics.DrawString(proname + " " + str, ReportFont5, Brushes.Black, 326, 223)

            e.Graphics.DrawString("Label Claim :", ReportFont1, Brushes.Black, 23, 262)

            e.Graphics.DrawString(TextBox10.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(112, 250, 670, 40), StringFormat)

            e.Graphics.DrawString("Batch No. :", ReportFont1, Brushes.Black, 23, 302)
            e.Graphics.DrawString(ComboBox9.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 295, 100, 30), StringFormat)

            e.Graphics.DrawString("Batch Size :", ReportFont1, Brushes.Black, 225, 302)
            e.Graphics.DrawString(TextBox6.Text, ReportFont5, Brushes.Black, 300, 302)

            e.Graphics.DrawString("Mfg Date :", ReportFont1, Brushes.Black, 440, 302)

            e.Graphics.DrawString(GunaTextBox1.Text, ReportFont5, Brushes.Black, 513, 302)

            e.Graphics.DrawString("Exp Date :", ReportFont1, Brushes.Black, 621, 302)
            e.Graphics.DrawString(GunaTextBox2.Text, ReportFont5, Brushes.Black, 690, 303)

            e.Graphics.DrawString("Sample Qty : ", ReportFont1, Brushes.Black, 23, 342)
            e.Graphics.DrawString(TextBox11.Text, ReportFont5, Brushes.Black, 111, 342)

            e.Graphics.DrawString("Pack :", ReportFont1, Brushes.Black, 280, 342)
            e.Graphics.DrawString(ComboBox10.Text, ReportFont5, Brushes.Black, 325, 342)


            e.Graphics.DrawString("Condition :", ReportFont1, Brushes.Black, 23, 381)
            e.Graphics.DrawString(ComboBox1.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 375, 200, 30), StringFormat)

            e.Graphics.DrawString("Period :", ReportFont1, Brushes.Black, 280, 381)
            e.Graphics.DrawString(ComboBox11.Text, ReportFont5, Brushes.Black, 335, 381)

            e.Graphics.DrawString("Test Requested :", ReportFont1, Brushes.Black, 23, 420)
            e.Graphics.DrawString(ComboBox3.Text, ReportFont5, Brushes.Black, 133, 420)

            e.Graphics.DrawString("Details of Test :", ReportFont1, Brushes.Black, 23, 470)

            e.Graphics.DrawString(TextBox9.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(130, 450, 645, 50), StringFormat)

            e.Graphics.DrawString("Remarks :", ReportFont1, Brushes.Black, 23, 510)
            If String.IsNullOrEmpty(TextBox12.Text) Then
                e.Graphics.DrawString("Nil", ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            Else
                e.Graphics.DrawString(TextBox12.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            End If

            e.Graphics.DrawString("Sent By :", ReportFont1, Brushes.Black, 23, 550)
            e.Graphics.DrawString(Homepagefrdj.Label1.Text, ReportFont5, Brushes.Black, 90, 550)
            e.Graphics.DrawString("Recieved By :", ReportFont1, Brushes.Black, 285, 550)

            e.Graphics.DrawString("AR No :", ReportFont1, Brushes.Black, 515, 550)

            e.Graphics.DrawString("STP No. :", ReportFont1, Brushes.Black, 23, 589)
            e.Graphics.DrawString("LNB Reference No :", ReportFont1, Brushes.Black, 515, 589)

            e.Graphics.DrawString("Sr No.", ReportFont1, Brushes.Black, 23, 623)
            e.Graphics.DrawString("Test", ReportFont1, Brushes.Black, 175, 623)
            e.Graphics.DrawString("Condition", ReportFont1, Brushes.Black, 390, 623)
            e.Graphics.DrawString("Result", ReportFont1, Brushes.Black, 635, 623)


            e.Graphics.DrawString("Analysed By :", ReportFont1, Brushes.Black, 26, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 26, 958)
            e.Graphics.DrawString("Checked By :", ReportFont1, Brushes.Black, 280, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 280, 958)
            e.Graphics.DrawString("Released By :", ReportFont1, Brushes.Black, 540, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 540, 958)

            If con.State = ConnectionState.Open Then con.Close()
            Dim qry1 As String
            qry1 = "select trformatno from formatno where srno='1'"
            cmd1 = New SqlCommand(qry1, con)
            con.Open()
            Dim annexno As String
            annexno = cmd1.ExecuteScalar().ToString()
            con.Close()
            e.Graphics.DrawString(annexno, ReportFont3, Brushes.Black, 650, 1000)



            e.Graphics.DrawImage(PictureBox1.Image, 300, 65, PictureBox1.Width, PictureBox1.Height)

            'square 1
            e.Graphics.DrawRectangle(blackPen, 15, 35, 760, 855)

            'from 2nd top
            'line.1
            e.Graphics.DrawLine(blackPen, 15.0F, 63.0F, 775.0F, 63.0F)
            'line 2
            e.Graphics.DrawLine(blackPen, 15.0F, 173.0F, 775.0F, 173.0F)
            'line 3
            e.Graphics.DrawLine(blackPen, 15.0F, 211.0F, 775.0F, 211.0F)
            'line 4
            e.Graphics.DrawLine(blackPen, 15.0F, 250.0F, 775.0F, 250.0F)
            'line 5
            e.Graphics.DrawLine(blackPen, 15.0F, 290.0F, 775.0F, 290.0F)
            'line 6
            e.Graphics.DrawLine(blackPen, 15.0F, 330.0F, 775.0F, 330.0F)
            'line 7
            e.Graphics.DrawLine(blackPen, 15.0F, 370.0F, 775.0F, 370.0F)
            'line 8
            e.Graphics.DrawLine(blackPen, 15.0F, 410.0F, 775.0F, 410.0F)
            'line 9
            e.Graphics.DrawLine(blackPen, 15.0F, 450.0F, 775.0F, 450.0F)
            'line 10
            e.Graphics.DrawLine(blackPen, 15.0F, 500.0F, 775.0F, 500.0F)
            'line 11
            e.Graphics.DrawLine(blackPen, 15.0F, 540.0F, 775.0F, 540.0F)
            'line 12
            e.Graphics.DrawLine(blackPen, 15.0F, 580.0F, 775.0F, 580.0F)
            'line 13
            e.Graphics.DrawLine(blackPen, 15.0F, 615.0F, 775.0F, 615.0F)
            'line 14
            e.Graphics.DrawLine(blackPen, 15.0F, 645.0F, 775.0F, 645.0F)
            'line 15
            e.Graphics.DrawLine(blackPen, 15.0F, 945.0F, 775.0F, 945.0F)


            'from left side
            'at product name
            e.Graphics.DrawLine(blackPen, 218.0F, 211.0F, 218.0F, 250.0F)
            'at bacth size
            e.Graphics.DrawLine(blackPen, 218.0F, 290.0F, 218.0F, 330.0F)
            'at mfg date
            e.Graphics.DrawLine(blackPen, 430.0F, 290.0F, 430.0F, 330.0F)
            'at Exp Date
            e.Graphics.DrawLine(blackPen, 610.0F, 290.0F, 610.0F, 330.0F)
            'at pack
            e.Graphics.DrawLine(blackPen, 270.0F, 330.0F, 270.0F, 410.0F)
            'at Recieved by
            e.Graphics.DrawLine(blackPen, 280.0F, 540.0F, 280.0F, 580.0F)
            'at AR No.
            e.Graphics.DrawLine(blackPen, 510.0F, 540.0F, 510.0F, 615.0F)

            'at test
            e.Graphics.DrawLine(blackPen, 70.0F, 615.0F, 70.0F, 890.0F)
            'at condition
            e.Graphics.DrawLine(blackPen, 310.0F, 615.0F, 310.0F, 890.0F)
            'at result
            e.Graphics.DrawLine(blackPen, 550.0F, 615.0F, 550.0F, 890.0F)
            'at checked by
            e.Graphics.DrawLine(blackPen, 275.0F, 900.0F, 275.0F, 990.0F)
            'at released by
            e.Graphics.DrawLine(blackPen, 535.0F, 900.0F, 535.0F, 990.0F)
            'square 2
            e.Graphics.DrawRectangle(blackPen, 15, 900, 760, 90)

            'for number of pages
            'pageNo = pageNo + 1
            'e.HasMorePages = pageNo <= 3
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub PrintDocument2_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
        Try

            Dim ReportFont1 As Font = New Drawing.Font("Times New Roman", 10, FontStyle.Bold)
            Dim ReportFont2 As Font = New Drawing.Font("Times New Roman", 12, FontStyle.Bold)
            Dim ReportFont3 As Font = New Drawing.Font("Times New Roman", 11, FontStyle.Bold)
            Dim ReportFont4 As Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold)
            Dim ReportFont5 As Font = New Drawing.Font("Times New Roman", 10)
            Dim blackPen As New Pen(Color.Black, 1)
            e.Graphics.DrawString("Test Request No :", ReportFont1, Brushes.Black, 23, 39)
            e.Graphics.DrawString("As per the sequance", ReportFont5, Brushes.Black, 137, 40)

            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 590, 39)
            e.Graphics.DrawString(DateTime.Now.Date, ReportFont5, Brushes.Black, 633, 40)


            e.Graphics.DrawString("FORMULATION RESEARCH AND DEVELOPMENT", ReportFont2, Brushes.Black, 204, 108)
            e.Graphics.DrawString("V-Ensure Pharma Technologies Pvt Ltd", ReportFont3, Brushes.Black, 273, 130)
            e.Graphics.DrawString("Navi Mumbai", ReportFont3, Brushes.Black, 345, 151)
            e.Graphics.DrawString("TEST REQUISITION SHEET", ReportFont4, Brushes.Black, 259, 180)

            e.Graphics.DrawString("Print Copy No. :", ReportFont1, Brushes.Black, 610, 151)
            e.Graphics.DrawString("1", ReportFont5, Brushes.Black, 722, 151)

            e.Graphics.DrawString("Product Code :", ReportFont1, Brushes.Black, 23, 223)
            e.Graphics.DrawString(TextBox1.Text, ReportFont5, Brushes.Black, 132, 223)

            e.Graphics.DrawString("Product Name :", ReportFont1, Brushes.Black, 225, 223)

            Dim StringFormat As StringFormat = New StringFormat()
            StringFormat.Alignment = StringAlignment.Near
            StringFormat.LineAlignment = StringAlignment.Center

            e.Graphics.DrawString(TextBox2.Text + " " + TextBox3.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(326, 210, 445, 40), StringFormat)

            e.Graphics.DrawString("Label Claim :", ReportFont1, Brushes.Black, 23, 262)

            e.Graphics.DrawString(TextBox14.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(112, 250, 670, 40), StringFormat)

            e.Graphics.DrawString("Batch No. :", ReportFont1, Brushes.Black, 23, 302)
            e.Graphics.DrawString(ComboBox9.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 295, 100, 30), StringFormat)

            e.Graphics.DrawString("Batch Size :", ReportFont1, Brushes.Black, 225, 302)
            e.Graphics.DrawString(TextBox6.Text, ReportFont5, Brushes.Black, 300, 302)

            e.Graphics.DrawString("Mfg Date :", ReportFont1, Brushes.Black, 440, 302)
            e.Graphics.DrawString(GunaTextBox1.Text, ReportFont5, Brushes.Black, 513, 302)

            e.Graphics.DrawString("Exp Date :", ReportFont1, Brushes.Black, 621, 302)
            e.Graphics.DrawString(GunaTextBox2.Text, ReportFont5, Brushes.Black, 690, 303)

            e.Graphics.DrawString("Sample Qty : ", ReportFont1, Brushes.Black, 23, 342)
            e.Graphics.DrawString(TextBox15.Text, ReportFont5, Brushes.Black, 111, 342)

            e.Graphics.DrawString("Pack :", ReportFont1, Brushes.Black, 280, 342)
            e.Graphics.DrawString(ComboBox10.Text, ReportFont5, Brushes.Black, 325, 342)

            e.Graphics.DrawString("Condition :", ReportFont1, Brushes.Black, 23, 381)
            e.Graphics.DrawString(ComboBox1.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 375, 200, 30), StringFormat)

            e.Graphics.DrawString("Period :", ReportFont1, Brushes.Black, 280, 381)
            e.Graphics.DrawString(ComboBox11.Text, ReportFont5, Brushes.Black, 335, 381)

            e.Graphics.DrawString("Test Requested :", ReportFont1, Brushes.Black, 23, 420)
            e.Graphics.DrawString(ComboBox4.Text, ReportFont5, Brushes.Black, 133, 420)

            e.Graphics.DrawString("Details of Test :", ReportFont1, Brushes.Black, 23, 470)
            e.Graphics.DrawString(TextBox13.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(130, 450, 645, 50), StringFormat)

            e.Graphics.DrawString("Remarks :", ReportFont1, Brushes.Black, 23, 510)
            If String.IsNullOrEmpty(TextBox16.Text) Then
                e.Graphics.DrawString("Nil", ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            Else
                e.Graphics.DrawString(TextBox16.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            End If

            e.Graphics.DrawString("Sent By :", ReportFont1, Brushes.Black, 23, 550)
            e.Graphics.DrawString(Homepagefrdj.Label1.Text, ReportFont5, Brushes.Black, 90, 550)
            e.Graphics.DrawString("Recieved By :", ReportFont1, Brushes.Black, 285, 550)

            e.Graphics.DrawString("AR No :", ReportFont1, Brushes.Black, 515, 550)

            e.Graphics.DrawString("STP No. :", ReportFont1, Brushes.Black, 23, 589)
            e.Graphics.DrawString("LNB Reference No :", ReportFont1, Brushes.Black, 515, 589)

            e.Graphics.DrawString("Sr No.", ReportFont1, Brushes.Black, 23, 623)
            e.Graphics.DrawString("Test", ReportFont1, Brushes.Black, 175, 623)
            e.Graphics.DrawString("Condition", ReportFont1, Brushes.Black, 390, 623)
            e.Graphics.DrawString("Result", ReportFont1, Brushes.Black, 635, 623)


            e.Graphics.DrawString("Analysed By :", ReportFont1, Brushes.Black, 26, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 26, 958)
            e.Graphics.DrawString("Checked By :", ReportFont1, Brushes.Black, 280, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 280, 958)
            e.Graphics.DrawString("Released By :", ReportFont1, Brushes.Black, 540, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 540, 958)

            If con.State = ConnectionState.Open Then con.Close()
            Dim qry1 As String
            qry1 = "select trformatno from formatno where srno='1'"
            cmd1 = New SqlCommand(qry1, con)
            con.Open()
            Dim annexno As String
            annexno = cmd1.ExecuteScalar().ToString()
            con.Close()
            e.Graphics.DrawString(annexno, ReportFont3, Brushes.Black, 650, 1000)



            e.Graphics.DrawImage(PictureBox1.Image, 300, 65, PictureBox1.Width, PictureBox1.Height)

            'square 1
            e.Graphics.DrawRectangle(blackPen, 15, 35, 760, 855)

            'from 2nd top
            'line.1
            e.Graphics.DrawLine(blackPen, 15.0F, 63.0F, 775.0F, 63.0F)
            'line 2
            e.Graphics.DrawLine(blackPen, 15.0F, 173.0F, 775.0F, 173.0F)
            'line 3
            e.Graphics.DrawLine(blackPen, 15.0F, 211.0F, 775.0F, 211.0F)
            'line 4
            e.Graphics.DrawLine(blackPen, 15.0F, 250.0F, 775.0F, 250.0F)
            'line 5
            e.Graphics.DrawLine(blackPen, 15.0F, 290.0F, 775.0F, 290.0F)
            'line 6
            e.Graphics.DrawLine(blackPen, 15.0F, 330.0F, 775.0F, 330.0F)
            'line 7
            e.Graphics.DrawLine(blackPen, 15.0F, 370.0F, 775.0F, 370.0F)
            'line 8
            e.Graphics.DrawLine(blackPen, 15.0F, 410.0F, 775.0F, 410.0F)
            'line 9
            e.Graphics.DrawLine(blackPen, 15.0F, 450.0F, 775.0F, 450.0F)
            'line 10
            e.Graphics.DrawLine(blackPen, 15.0F, 500.0F, 775.0F, 500.0F)
            'line 11
            e.Graphics.DrawLine(blackPen, 15.0F, 540.0F, 775.0F, 540.0F)
            'line 12
            e.Graphics.DrawLine(blackPen, 15.0F, 580.0F, 775.0F, 580.0F)
            'line 13
            e.Graphics.DrawLine(blackPen, 15.0F, 615.0F, 775.0F, 615.0F)
            'line 14
            e.Graphics.DrawLine(blackPen, 15.0F, 645.0F, 775.0F, 645.0F)
            'line 15
            e.Graphics.DrawLine(blackPen, 15.0F, 945.0F, 775.0F, 945.0F)


            'from left side
            'at product name
            e.Graphics.DrawLine(blackPen, 218.0F, 211.0F, 218.0F, 250.0F)
            'at bacth size
            e.Graphics.DrawLine(blackPen, 218.0F, 290.0F, 218.0F, 330.0F)
            'at mfg date
            e.Graphics.DrawLine(blackPen, 430.0F, 290.0F, 430.0F, 330.0F)
            'at Exp Date
            e.Graphics.DrawLine(blackPen, 610.0F, 290.0F, 610.0F, 330.0F)
            'at pack
            e.Graphics.DrawLine(blackPen, 270.0F, 330.0F, 270.0F, 410.0F)
            'at Recieved by
            e.Graphics.DrawLine(blackPen, 280.0F, 540.0F, 280.0F, 580.0F)
            'at AR No.
            e.Graphics.DrawLine(blackPen, 510.0F, 540.0F, 510.0F, 615.0F)

            'at test
            e.Graphics.DrawLine(blackPen, 70.0F, 615.0F, 70.0F, 890.0F)
            'at condition
            e.Graphics.DrawLine(blackPen, 310.0F, 615.0F, 310.0F, 890.0F)
            'at result
            e.Graphics.DrawLine(blackPen, 550.0F, 615.0F, 550.0F, 890.0F)
            'at checked by
            e.Graphics.DrawLine(blackPen, 275.0F, 900.0F, 275.0F, 990.0F)
            'at released by
            e.Graphics.DrawLine(blackPen, 535.0F, 900.0F, 535.0F, 990.0F)
            'square 2
            e.Graphics.DrawRectangle(blackPen, 15, 900, 760, 90)

            'for number of pages
            'pageNo = pageNo + 1
            'e.HasMorePages = pageNo <= 3
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub PrintDocument3_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument3.PrintPage
        Try

            Dim ReportFont1 As Font = New Drawing.Font("Times New Roman", 10, FontStyle.Bold)
            Dim ReportFont2 As Font = New Drawing.Font("Times New Roman", 12, FontStyle.Bold)
            Dim ReportFont3 As Font = New Drawing.Font("Times New Roman", 11, FontStyle.Bold)
            Dim ReportFont4 As Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold)
            Dim ReportFont5 As Font = New Drawing.Font("Times New Roman", 10)
            Dim blackPen As New Pen(Color.Black, 1)
            e.Graphics.DrawString("Test Request No :", ReportFont1, Brushes.Black, 23, 39)
            e.Graphics.DrawString("As per the sequance", ReportFont5, Brushes.Black, 137, 40)

            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 590, 39)
            e.Graphics.DrawString(DateTime.Now.Date, ReportFont5, Brushes.Black, 633, 40)


            e.Graphics.DrawString("FORMULATION RESEARCH AND DEVELOPMENT", ReportFont2, Brushes.Black, 204, 108)
            e.Graphics.DrawString("V-Ensure Pharma Technologies Pvt Ltd", ReportFont3, Brushes.Black, 273, 130)
            e.Graphics.DrawString("Navi Mumbai", ReportFont3, Brushes.Black, 345, 151)
            e.Graphics.DrawString("TEST REQUISITION SHEET", ReportFont4, Brushes.Black, 259, 180)

            e.Graphics.DrawString("Print Copy No. :", ReportFont1, Brushes.Black, 610, 151)
            e.Graphics.DrawString("1", ReportFont5, Brushes.Black, 722, 151)

            e.Graphics.DrawString("Product Code :", ReportFont1, Brushes.Black, 23, 223)
            e.Graphics.DrawString(TextBox1.Text, ReportFont5, Brushes.Black, 132, 223)

            e.Graphics.DrawString("Product Name :", ReportFont1, Brushes.Black, 225, 223)

            Dim StringFormat As StringFormat = New StringFormat()
            StringFormat.Alignment = StringAlignment.Near
            StringFormat.LineAlignment = StringAlignment.Center

            e.Graphics.DrawString(TextBox2.Text + " " + TextBox3.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(326, 210, 445, 40), StringFormat)

            e.Graphics.DrawString("Label Claim :", ReportFont1, Brushes.Black, 23, 262)
            e.Graphics.DrawString(TextBox18.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(112, 250, 670, 40), StringFormat)

            e.Graphics.DrawString("Batch No. :", ReportFont1, Brushes.Black, 23, 302)
            e.Graphics.DrawString(ComboBox9.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 295, 100, 30), StringFormat)

            e.Graphics.DrawString("Batch Size :", ReportFont1, Brushes.Black, 225, 302)
            e.Graphics.DrawString(TextBox6.Text, ReportFont5, Brushes.Black, 300, 302)

            e.Graphics.DrawString("Mfg Date :", ReportFont1, Brushes.Black, 440, 302)
            e.Graphics.DrawString(GunaTextBox1.Text, ReportFont5, Brushes.Black, 513, 302)

            e.Graphics.DrawString("Exp Date :", ReportFont1, Brushes.Black, 621, 302)
            e.Graphics.DrawString(GunaTextBox2.Text, ReportFont5, Brushes.Black, 690, 303)

            e.Graphics.DrawString("Sample Qty : ", ReportFont1, Brushes.Black, 23, 342)
            e.Graphics.DrawString(TextBox19.Text, ReportFont5, Brushes.Black, 111, 342)

            e.Graphics.DrawString("Pack :", ReportFont1, Brushes.Black, 280, 342)
            e.Graphics.DrawString(ComboBox10.Text, ReportFont5, Brushes.Black, 325, 342)

            e.Graphics.DrawString("Condition :", ReportFont1, Brushes.Black, 23, 381)
            e.Graphics.DrawString(ComboBox1.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 375, 200, 30), StringFormat)

            e.Graphics.DrawString("Period :", ReportFont1, Brushes.Black, 280, 381)
            e.Graphics.DrawString(ComboBox11.Text, ReportFont5, Brushes.Black, 335, 381)

            e.Graphics.DrawString("Test Requested :", ReportFont1, Brushes.Black, 23, 420)
            e.Graphics.DrawString(ComboBox5.Text, ReportFont5, Brushes.Black, 133, 420)

            e.Graphics.DrawString("Details of Test :", ReportFont1, Brushes.Black, 23, 470)
            e.Graphics.DrawString(TextBox17.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(130, 450, 645, 50), StringFormat)

            e.Graphics.DrawString("Remarks :", ReportFont1, Brushes.Black, 23, 510)
            If String.IsNullOrEmpty(TextBox20.Text) Then
                e.Graphics.DrawString("Nil", ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            Else
                e.Graphics.DrawString(TextBox20.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            End If

            e.Graphics.DrawString("Sent By :", ReportFont1, Brushes.Black, 23, 550)
            e.Graphics.DrawString(Homepagefrdj.Label1.Text, ReportFont5, Brushes.Black, 90, 550)
            e.Graphics.DrawString("Recieved By :", ReportFont1, Brushes.Black, 285, 550)

            e.Graphics.DrawString("AR No :", ReportFont1, Brushes.Black, 515, 550)

            e.Graphics.DrawString("STP No. :", ReportFont1, Brushes.Black, 23, 589)
            e.Graphics.DrawString("LNB Reference No :", ReportFont1, Brushes.Black, 515, 589)

            e.Graphics.DrawString("Sr No.", ReportFont1, Brushes.Black, 23, 623)
            e.Graphics.DrawString("Test", ReportFont1, Brushes.Black, 175, 623)
            e.Graphics.DrawString("Condition", ReportFont1, Brushes.Black, 390, 623)
            e.Graphics.DrawString("Result", ReportFont1, Brushes.Black, 635, 623)


            e.Graphics.DrawString("Analysed By :", ReportFont1, Brushes.Black, 26, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 26, 958)
            e.Graphics.DrawString("Checked By :", ReportFont1, Brushes.Black, 280, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 280, 958)
            e.Graphics.DrawString("Released By :", ReportFont1, Brushes.Black, 540, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 540, 958)

            If con.State = ConnectionState.Open Then con.Close()
            Dim qry1 As String
            qry1 = "select trformatno from formatno where srno='1'"
            cmd1 = New SqlCommand(qry1, con)
            con.Open()
            Dim annexno As String
            annexno = cmd1.ExecuteScalar().ToString()
            con.Close()
            e.Graphics.DrawString(annexno, ReportFont3, Brushes.Black, 650, 1000)



            e.Graphics.DrawImage(PictureBox1.Image, 300, 65, PictureBox1.Width, PictureBox1.Height)

            'square 1
            e.Graphics.DrawRectangle(blackPen, 15, 35, 760, 855)

            'from 2nd top
            'line.1
            e.Graphics.DrawLine(blackPen, 15.0F, 63.0F, 775.0F, 63.0F)
            'line 2
            e.Graphics.DrawLine(blackPen, 15.0F, 173.0F, 775.0F, 173.0F)
            'line 3
            e.Graphics.DrawLine(blackPen, 15.0F, 211.0F, 775.0F, 211.0F)
            'line 4
            e.Graphics.DrawLine(blackPen, 15.0F, 250.0F, 775.0F, 250.0F)
            'line 5
            e.Graphics.DrawLine(blackPen, 15.0F, 290.0F, 775.0F, 290.0F)
            'line 6
            e.Graphics.DrawLine(blackPen, 15.0F, 330.0F, 775.0F, 330.0F)
            'line 7
            e.Graphics.DrawLine(blackPen, 15.0F, 370.0F, 775.0F, 370.0F)
            'line 8
            e.Graphics.DrawLine(blackPen, 15.0F, 410.0F, 775.0F, 410.0F)
            'line 9
            e.Graphics.DrawLine(blackPen, 15.0F, 450.0F, 775.0F, 450.0F)
            'line 10
            e.Graphics.DrawLine(blackPen, 15.0F, 500.0F, 775.0F, 500.0F)
            'line 11
            e.Graphics.DrawLine(blackPen, 15.0F, 540.0F, 775.0F, 540.0F)
            'line 12
            e.Graphics.DrawLine(blackPen, 15.0F, 580.0F, 775.0F, 580.0F)
            'line 13
            e.Graphics.DrawLine(blackPen, 15.0F, 615.0F, 775.0F, 615.0F)
            'line 14
            e.Graphics.DrawLine(blackPen, 15.0F, 645.0F, 775.0F, 645.0F)
            'line 15
            e.Graphics.DrawLine(blackPen, 15.0F, 945.0F, 775.0F, 945.0F)


            'from left side
            'at product name
            e.Graphics.DrawLine(blackPen, 218.0F, 211.0F, 218.0F, 250.0F)
            'at bacth size
            e.Graphics.DrawLine(blackPen, 218.0F, 290.0F, 218.0F, 330.0F)
            'at mfg date
            e.Graphics.DrawLine(blackPen, 430.0F, 290.0F, 430.0F, 330.0F)
            'at Exp Date
            e.Graphics.DrawLine(blackPen, 610.0F, 290.0F, 610.0F, 330.0F)
            'at pack
            e.Graphics.DrawLine(blackPen, 270.0F, 330.0F, 270.0F, 410.0F)
            'at Recieved by
            e.Graphics.DrawLine(blackPen, 280.0F, 540.0F, 280.0F, 580.0F)
            'at AR No.
            e.Graphics.DrawLine(blackPen, 510.0F, 540.0F, 510.0F, 615.0F)

            'at test
            e.Graphics.DrawLine(blackPen, 70.0F, 615.0F, 70.0F, 890.0F)
            'at condition
            e.Graphics.DrawLine(blackPen, 310.0F, 615.0F, 310.0F, 890.0F)
            'at result
            e.Graphics.DrawLine(blackPen, 550.0F, 615.0F, 550.0F, 890.0F)
            'at checked by
            e.Graphics.DrawLine(blackPen, 275.0F, 900.0F, 275.0F, 990.0F)
            'at released by
            e.Graphics.DrawLine(blackPen, 535.0F, 900.0F, 535.0F, 990.0F)
            'square 2
            e.Graphics.DrawRectangle(blackPen, 15, 900, 760, 90)

            'for number of pages
            'pageNo = pageNo + 1
            'e.HasMorePages = pageNo <= 3
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub PrintDocument4_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument4.PrintPage
        Try
            Dim ReportFont1 As Font = New Drawing.Font("Times New Roman", 10, FontStyle.Bold)
            Dim ReportFont2 As Font = New Drawing.Font("Times New Roman", 12, FontStyle.Bold)
            Dim ReportFont3 As Font = New Drawing.Font("Times New Roman", 11, FontStyle.Bold)
            Dim ReportFont4 As Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold)
            Dim ReportFont5 As Font = New Drawing.Font("Times New Roman", 10)
            Dim blackPen As New Pen(Color.Black, 1)
            e.Graphics.DrawString("Test Request No :", ReportFont1, Brushes.Black, 23, 39)
            e.Graphics.DrawString("As per the sequance", ReportFont5, Brushes.Black, 137, 40)

            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 590, 39)
            e.Graphics.DrawString(DateTime.Now.Date, ReportFont5, Brushes.Black, 633, 40)


            e.Graphics.DrawString("FORMULATION RESEARCH AND DEVELOPMENT", ReportFont2, Brushes.Black, 204, 108)
            e.Graphics.DrawString("V-Ensure Pharma Technologies Pvt Ltd", ReportFont3, Brushes.Black, 273, 130)
            e.Graphics.DrawString("Navi Mumbai", ReportFont3, Brushes.Black, 345, 151)
            e.Graphics.DrawString("TEST REQUISITION SHEET", ReportFont4, Brushes.Black, 259, 180)

            e.Graphics.DrawString("Print Copy No. :", ReportFont1, Brushes.Black, 610, 151)
            e.Graphics.DrawString("1", ReportFont5, Brushes.Black, 722, 151)

            e.Graphics.DrawString("Product Code :", ReportFont1, Brushes.Black, 23, 223)
            e.Graphics.DrawString(TextBox1.Text, ReportFont5, Brushes.Black, 132, 223)

            e.Graphics.DrawString("Product Name :", ReportFont1, Brushes.Black, 225, 223)

            Dim StringFormat As StringFormat = New StringFormat()
            StringFormat.Alignment = StringAlignment.Near
            StringFormat.LineAlignment = StringAlignment.Center

            e.Graphics.DrawString(TextBox2.Text + " " + TextBox3.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(326, 210, 445, 40), StringFormat)

            e.Graphics.DrawString("Label Claim :", ReportFont1, Brushes.Black, 23, 262)
            e.Graphics.DrawString(TextBox22.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(112, 250, 670, 40), StringFormat)

            e.Graphics.DrawString("Batch No. :", ReportFont1, Brushes.Black, 23, 302)
            e.Graphics.DrawString(ComboBox9.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 295, 100, 30), StringFormat)

            e.Graphics.DrawString("Batch Size :", ReportFont1, Brushes.Black, 225, 302)
            e.Graphics.DrawString(TextBox6.Text, ReportFont5, Brushes.Black, 300, 302)

            e.Graphics.DrawString("Mfg Date :", ReportFont1, Brushes.Black, 440, 302)
            e.Graphics.DrawString(GunaTextBox1.Text, ReportFont5, Brushes.Black, 513, 302)

            e.Graphics.DrawString("Exp Date :", ReportFont1, Brushes.Black, 621, 302)
            e.Graphics.DrawString(GunaTextBox2.Text, ReportFont5, Brushes.Black, 690, 303)

            e.Graphics.DrawString("Sample Qty : ", ReportFont1, Brushes.Black, 23, 342)
            e.Graphics.DrawString(TextBox23.Text, ReportFont5, Brushes.Black, 111, 342)

            e.Graphics.DrawString("Pack :", ReportFont1, Brushes.Black, 280, 342)
            e.Graphics.DrawString(ComboBox10.Text, ReportFont5, Brushes.Black, 325, 342)

            e.Graphics.DrawString("Condition :", ReportFont1, Brushes.Black, 23, 381)
            e.Graphics.DrawString(ComboBox1.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 375, 200, 30), StringFormat)

            e.Graphics.DrawString("Period :", ReportFont1, Brushes.Black, 280, 381)
            e.Graphics.DrawString(ComboBox11.Text, ReportFont5, Brushes.Black, 335, 381)

            e.Graphics.DrawString("Test Requested :", ReportFont1, Brushes.Black, 23, 420)
            e.Graphics.DrawString(ComboBox6.Text, ReportFont5, Brushes.Black, 133, 420)

            e.Graphics.DrawString("Details of Test :", ReportFont1, Brushes.Black, 23, 470)
            e.Graphics.DrawString(TextBox21.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(130, 450, 645, 50), StringFormat)

            e.Graphics.DrawString("Remarks :", ReportFont1, Brushes.Black, 23, 510)
            If String.IsNullOrEmpty(TextBox24.Text) Then
                e.Graphics.DrawString("Nil", ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            Else
                e.Graphics.DrawString(TextBox24.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            End If

            e.Graphics.DrawString("Sent By :", ReportFont1, Brushes.Black, 23, 550)
            e.Graphics.DrawString(Homepagefrdj.Label1.Text, ReportFont5, Brushes.Black, 90, 550)
            e.Graphics.DrawString("Recieved By :", ReportFont1, Brushes.Black, 285, 550)

            e.Graphics.DrawString("AR No :", ReportFont1, Brushes.Black, 515, 550)

            e.Graphics.DrawString("STP No. :", ReportFont1, Brushes.Black, 23, 589)
            e.Graphics.DrawString("LNB Reference No :", ReportFont1, Brushes.Black, 515, 589)

            e.Graphics.DrawString("Sr No.", ReportFont1, Brushes.Black, 23, 623)
            e.Graphics.DrawString("Test", ReportFont1, Brushes.Black, 175, 623)
            e.Graphics.DrawString("Condition", ReportFont1, Brushes.Black, 390, 623)
            e.Graphics.DrawString("Result", ReportFont1, Brushes.Black, 635, 623)


            e.Graphics.DrawString("Analysed By :", ReportFont1, Brushes.Black, 26, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 26, 958)
            e.Graphics.DrawString("Checked By :", ReportFont1, Brushes.Black, 280, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 280, 958)
            e.Graphics.DrawString("Released By :", ReportFont1, Brushes.Black, 540, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 540, 958)

            If con.State = ConnectionState.Open Then con.Close()
            Dim qry1 As String
            qry1 = "select trformatno from formatno where srno='1'"
            cmd1 = New SqlCommand(qry1, con)
            con.Open()
            Dim annexno As String
            annexno = cmd1.ExecuteScalar().ToString()
            con.Close()
            e.Graphics.DrawString(annexno, ReportFont3, Brushes.Black, 650, 1000)



            e.Graphics.DrawImage(PictureBox1.Image, 300, 65, PictureBox1.Width, PictureBox1.Height)

            'square 1
            e.Graphics.DrawRectangle(blackPen, 15, 35, 760, 855)

            'from 2nd top
            'line.1
            e.Graphics.DrawLine(blackPen, 15.0F, 63.0F, 775.0F, 63.0F)
            'line 2
            e.Graphics.DrawLine(blackPen, 15.0F, 173.0F, 775.0F, 173.0F)
            'line 3
            e.Graphics.DrawLine(blackPen, 15.0F, 211.0F, 775.0F, 211.0F)
            'line 4
            e.Graphics.DrawLine(blackPen, 15.0F, 250.0F, 775.0F, 250.0F)
            'line 5
            e.Graphics.DrawLine(blackPen, 15.0F, 290.0F, 775.0F, 290.0F)
            'line 6
            e.Graphics.DrawLine(blackPen, 15.0F, 330.0F, 775.0F, 330.0F)
            'line 7
            e.Graphics.DrawLine(blackPen, 15.0F, 370.0F, 775.0F, 370.0F)
            'line 8
            e.Graphics.DrawLine(blackPen, 15.0F, 410.0F, 775.0F, 410.0F)
            'line 9
            e.Graphics.DrawLine(blackPen, 15.0F, 450.0F, 775.0F, 450.0F)
            'line 10
            e.Graphics.DrawLine(blackPen, 15.0F, 500.0F, 775.0F, 500.0F)
            'line 11
            e.Graphics.DrawLine(blackPen, 15.0F, 540.0F, 775.0F, 540.0F)
            'line 12
            e.Graphics.DrawLine(blackPen, 15.0F, 580.0F, 775.0F, 580.0F)
            'line 13
            e.Graphics.DrawLine(blackPen, 15.0F, 615.0F, 775.0F, 615.0F)
            'line 14
            e.Graphics.DrawLine(blackPen, 15.0F, 645.0F, 775.0F, 645.0F)
            'line 15
            e.Graphics.DrawLine(blackPen, 15.0F, 945.0F, 775.0F, 945.0F)


            'from left side
            'at product name
            e.Graphics.DrawLine(blackPen, 218.0F, 211.0F, 218.0F, 250.0F)
            'at bacth size
            e.Graphics.DrawLine(blackPen, 218.0F, 290.0F, 218.0F, 330.0F)
            'at mfg date
            e.Graphics.DrawLine(blackPen, 430.0F, 290.0F, 430.0F, 330.0F)
            'at Exp Date
            e.Graphics.DrawLine(blackPen, 610.0F, 290.0F, 610.0F, 330.0F)
            'at pack
            e.Graphics.DrawLine(blackPen, 270.0F, 330.0F, 270.0F, 410.0F)
            'at Recieved by
            e.Graphics.DrawLine(blackPen, 280.0F, 540.0F, 280.0F, 580.0F)
            'at AR No.
            e.Graphics.DrawLine(blackPen, 510.0F, 540.0F, 510.0F, 615.0F)

            'at test
            e.Graphics.DrawLine(blackPen, 70.0F, 615.0F, 70.0F, 890.0F)
            'at condition
            e.Graphics.DrawLine(blackPen, 310.0F, 615.0F, 310.0F, 890.0F)
            'at result
            e.Graphics.DrawLine(blackPen, 550.0F, 615.0F, 550.0F, 890.0F)
            'at checked by
            e.Graphics.DrawLine(blackPen, 275.0F, 900.0F, 275.0F, 990.0F)
            'at released by
            e.Graphics.DrawLine(blackPen, 535.0F, 900.0F, 535.0F, 990.0F)
            'square 2
            e.Graphics.DrawRectangle(blackPen, 15, 900, 760, 90)

            'for number of pages
            'pageNo = pageNo + 1
            'e.HasMorePages = pageNo <= 3
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub PrintDocument5_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument5.PrintPage
        Try
            Dim ReportFont1 As Font = New Drawing.Font("Times New Roman", 10, FontStyle.Bold)
            Dim ReportFont2 As Font = New Drawing.Font("Times New Roman", 12, FontStyle.Bold)
            Dim ReportFont3 As Font = New Drawing.Font("Times New Roman", 11, FontStyle.Bold)
            Dim ReportFont4 As Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold)
            Dim ReportFont5 As Font = New Drawing.Font("Times New Roman", 10)
            Dim blackPen As New Pen(Color.Black, 1)
            e.Graphics.DrawString("Test Request No :", ReportFont1, Brushes.Black, 23, 39)
            e.Graphics.DrawString("As per the sequance", ReportFont5, Brushes.Black, 137, 40)

            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 590, 39)
            e.Graphics.DrawString(DateTime.Now.Date, ReportFont5, Brushes.Black, 633, 40)


            e.Graphics.DrawString("FORMULATION RESEARCH AND DEVELOPMENT", ReportFont2, Brushes.Black, 204, 108)
            e.Graphics.DrawString("V-Ensure Pharma Technologies Pvt Ltd", ReportFont3, Brushes.Black, 273, 130)
            e.Graphics.DrawString("Navi Mumbai", ReportFont3, Brushes.Black, 345, 151)
            e.Graphics.DrawString("TEST REQUISITION SHEET", ReportFont4, Brushes.Black, 259, 180)

            e.Graphics.DrawString("Print Copy No. :", ReportFont1, Brushes.Black, 610, 151)
            e.Graphics.DrawString("1", ReportFont5, Brushes.Black, 722, 151)

            e.Graphics.DrawString("Product Code :", ReportFont1, Brushes.Black, 23, 223)
            e.Graphics.DrawString(TextBox1.Text, ReportFont5, Brushes.Black, 132, 223)

            e.Graphics.DrawString("Product Name :", ReportFont1, Brushes.Black, 225, 223)

            Dim StringFormat As StringFormat = New StringFormat()
            StringFormat.Alignment = StringAlignment.Near
            StringFormat.LineAlignment = StringAlignment.Center

            e.Graphics.DrawString(TextBox2.Text + " " + TextBox3.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(326, 210, 445, 40), StringFormat)

            e.Graphics.DrawString("Label Claim :", ReportFont1, Brushes.Black, 23, 262)
            e.Graphics.DrawString(TextBox26.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(112, 250, 670, 40), StringFormat)

            e.Graphics.DrawString("Batch No. :", ReportFont1, Brushes.Black, 23, 302)
            e.Graphics.DrawString(ComboBox9.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 295, 100, 30), StringFormat)

            e.Graphics.DrawString("Batch Size :", ReportFont1, Brushes.Black, 225, 302)
            e.Graphics.DrawString(TextBox6.Text, ReportFont5, Brushes.Black, 300, 302)

            e.Graphics.DrawString("Mfg Date :", ReportFont1, Brushes.Black, 440, 302)
            e.Graphics.DrawString(GunaTextBox1.Text, ReportFont5, Brushes.Black, 513, 302)

            e.Graphics.DrawString("Exp Date :", ReportFont1, Brushes.Black, 621, 302)
            e.Graphics.DrawString(GunaTextBox2.Text, ReportFont5, Brushes.Black, 690, 303)

            e.Graphics.DrawString("Sample Qty : ", ReportFont1, Brushes.Black, 23, 342)
            e.Graphics.DrawString(TextBox27.Text, ReportFont5, Brushes.Black, 111, 342)

            e.Graphics.DrawString("Pack :", ReportFont1, Brushes.Black, 280, 342)
            e.Graphics.DrawString(ComboBox10.Text, ReportFont5, Brushes.Black, 325, 342)

            e.Graphics.DrawString("Condition :", ReportFont1, Brushes.Black, 23, 381)
            e.Graphics.DrawString(ComboBox1.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 375, 200, 30), StringFormat)

            e.Graphics.DrawString("Period :", ReportFont1, Brushes.Black, 280, 381)
            e.Graphics.DrawString(ComboBox11.Text, ReportFont5, Brushes.Black, 335, 381)

            e.Graphics.DrawString("Test Requested :", ReportFont1, Brushes.Black, 23, 420)
            e.Graphics.DrawString(ComboBox7.Text, ReportFont5, Brushes.Black, 133, 420)

            e.Graphics.DrawString("Details of Test :", ReportFont1, Brushes.Black, 23, 470)
            e.Graphics.DrawString(TextBox25.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(130, 450, 645, 50), StringFormat)

            e.Graphics.DrawString("Remarks :", ReportFont1, Brushes.Black, 23, 510)
            If String.IsNullOrEmpty(TextBox28.Text) Then
                e.Graphics.DrawString("Nil", ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            Else
                e.Graphics.DrawString(TextBox28.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            End If

            e.Graphics.DrawString("Sent By :", ReportFont1, Brushes.Black, 23, 550)
            e.Graphics.DrawString(Homepagefrdj.Label1.Text, ReportFont5, Brushes.Black, 90, 550)
            e.Graphics.DrawString("Recieved By :", ReportFont1, Brushes.Black, 285, 550)

            e.Graphics.DrawString("AR No :", ReportFont1, Brushes.Black, 515, 550)

            e.Graphics.DrawString("STP No. :", ReportFont1, Brushes.Black, 23, 589)
            e.Graphics.DrawString("LNB Reference No :", ReportFont1, Brushes.Black, 515, 589)

            e.Graphics.DrawString("Sr No.", ReportFont1, Brushes.Black, 23, 623)
            e.Graphics.DrawString("Test", ReportFont1, Brushes.Black, 175, 623)
            e.Graphics.DrawString("Condition", ReportFont1, Brushes.Black, 390, 623)
            e.Graphics.DrawString("Result", ReportFont1, Brushes.Black, 635, 623)


            e.Graphics.DrawString("Analysed By :", ReportFont1, Brushes.Black, 26, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 26, 958)
            e.Graphics.DrawString("Checked By :", ReportFont1, Brushes.Black, 280, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 280, 958)
            e.Graphics.DrawString("Released By :", ReportFont1, Brushes.Black, 540, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 540, 958)

            If con.State = ConnectionState.Open Then con.Close()
            Dim qry1 As String
            qry1 = "select trformatno from formatno where srno='1'"
            cmd1 = New SqlCommand(qry1, con)
            con.Open()
            Dim annexno As String
            annexno = cmd1.ExecuteScalar().ToString()
            con.Close()
            e.Graphics.DrawString(annexno, ReportFont3, Brushes.Black, 650, 1000)



            e.Graphics.DrawImage(PictureBox1.Image, 300, 65, PictureBox1.Width, PictureBox1.Height)

            'square 1
            e.Graphics.DrawRectangle(blackPen, 15, 35, 760, 855)

            'from 2nd top
            'line.1
            e.Graphics.DrawLine(blackPen, 15.0F, 63.0F, 775.0F, 63.0F)
            'line 2
            e.Graphics.DrawLine(blackPen, 15.0F, 173.0F, 775.0F, 173.0F)
            'line 3
            e.Graphics.DrawLine(blackPen, 15.0F, 211.0F, 775.0F, 211.0F)
            'line 4
            e.Graphics.DrawLine(blackPen, 15.0F, 250.0F, 775.0F, 250.0F)
            'line 5
            e.Graphics.DrawLine(blackPen, 15.0F, 290.0F, 775.0F, 290.0F)
            'line 6
            e.Graphics.DrawLine(blackPen, 15.0F, 330.0F, 775.0F, 330.0F)
            'line 7
            e.Graphics.DrawLine(blackPen, 15.0F, 370.0F, 775.0F, 370.0F)
            'line 8
            e.Graphics.DrawLine(blackPen, 15.0F, 410.0F, 775.0F, 410.0F)
            'line 9
            e.Graphics.DrawLine(blackPen, 15.0F, 450.0F, 775.0F, 450.0F)
            'line 10
            e.Graphics.DrawLine(blackPen, 15.0F, 500.0F, 775.0F, 500.0F)
            'line 11
            e.Graphics.DrawLine(blackPen, 15.0F, 540.0F, 775.0F, 540.0F)
            'line 12
            e.Graphics.DrawLine(blackPen, 15.0F, 580.0F, 775.0F, 580.0F)
            'line 13
            e.Graphics.DrawLine(blackPen, 15.0F, 615.0F, 775.0F, 615.0F)
            'line 14
            e.Graphics.DrawLine(blackPen, 15.0F, 645.0F, 775.0F, 645.0F)
            'line 15
            e.Graphics.DrawLine(blackPen, 15.0F, 945.0F, 775.0F, 945.0F)


            'from left side
            'at product name
            e.Graphics.DrawLine(blackPen, 218.0F, 211.0F, 218.0F, 250.0F)
            'at bacth size
            e.Graphics.DrawLine(blackPen, 218.0F, 290.0F, 218.0F, 330.0F)
            'at mfg date
            e.Graphics.DrawLine(blackPen, 430.0F, 290.0F, 430.0F, 330.0F)
            'at Exp Date
            e.Graphics.DrawLine(blackPen, 610.0F, 290.0F, 610.0F, 330.0F)
            'at pack
            e.Graphics.DrawLine(blackPen, 270.0F, 330.0F, 270.0F, 410.0F)
            'at Recieved by
            e.Graphics.DrawLine(blackPen, 280.0F, 540.0F, 280.0F, 580.0F)
            'at AR No.
            e.Graphics.DrawLine(blackPen, 510.0F, 540.0F, 510.0F, 615.0F)

            'at test
            e.Graphics.DrawLine(blackPen, 70.0F, 615.0F, 70.0F, 890.0F)
            'at condition
            e.Graphics.DrawLine(blackPen, 310.0F, 615.0F, 310.0F, 890.0F)
            'at result
            e.Graphics.DrawLine(blackPen, 550.0F, 615.0F, 550.0F, 890.0F)
            'at checked by
            e.Graphics.DrawLine(blackPen, 275.0F, 900.0F, 275.0F, 990.0F)
            'at released by
            e.Graphics.DrawLine(blackPen, 535.0F, 900.0F, 535.0F, 990.0F)
            'square 2
            e.Graphics.DrawRectangle(blackPen, 15, 900, 760, 90)

            'for number of pages
            'pageNo = pageNo + 1
            'e.HasMorePages = pageNo <= 3
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub PrintDocument6_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument6.PrintPage
        Try
            Dim ReportFont1 As Font = New Drawing.Font("Times New Roman", 10, FontStyle.Bold)
            Dim ReportFont2 As Font = New Drawing.Font("Times New Roman", 12, FontStyle.Bold)
            Dim ReportFont3 As Font = New Drawing.Font("Times New Roman", 11, FontStyle.Bold)
            Dim ReportFont4 As Font = New Drawing.Font("Times New Roman", 16, FontStyle.Bold)
            Dim ReportFont5 As Font = New Drawing.Font("Times New Roman", 10)
            Dim blackPen As New Pen(Color.Black, 1)
            e.Graphics.DrawString("Test Request No :", ReportFont1, Brushes.Black, 23, 39)
            e.Graphics.DrawString("As per the sequance", ReportFont5, Brushes.Black, 137, 40)

            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 590, 39)
            e.Graphics.DrawString(DateTime.Now.Date, ReportFont5, Brushes.Black, 633, 40)


            e.Graphics.DrawString("FORMULATION RESEARCH AND DEVELOPMENT", ReportFont2, Brushes.Black, 204, 108)
            e.Graphics.DrawString("V-Ensure Pharma Technologies Pvt Ltd", ReportFont3, Brushes.Black, 273, 130)
            e.Graphics.DrawString("Navi Mumbai", ReportFont3, Brushes.Black, 345, 151)
            e.Graphics.DrawString("TEST REQUISITION SHEET", ReportFont4, Brushes.Black, 259, 180)

            e.Graphics.DrawString("Print Copy No. :", ReportFont1, Brushes.Black, 610, 151)
            e.Graphics.DrawString("1", ReportFont5, Brushes.Black, 722, 151)

            e.Graphics.DrawString("Product Code :", ReportFont1, Brushes.Black, 23, 223)
            e.Graphics.DrawString(TextBox1.Text, ReportFont5, Brushes.Black, 132, 223)

            e.Graphics.DrawString("Product Name :", ReportFont1, Brushes.Black, 225, 223)

            Dim StringFormat As StringFormat = New StringFormat()
            StringFormat.Alignment = StringAlignment.Near
            StringFormat.LineAlignment = StringAlignment.Center

            e.Graphics.DrawString(TextBox2.Text + " " + TextBox3.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(326, 210, 445, 40), StringFormat)

            e.Graphics.DrawString("Label Claim :", ReportFont1, Brushes.Black, 23, 262)
            e.Graphics.DrawString(TextBox30.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(112, 250, 670, 40), StringFormat)

            e.Graphics.DrawString("Batch No. :", ReportFont1, Brushes.Black, 23, 302)
            e.Graphics.DrawString(ComboBox9.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 295, 100, 30), StringFormat)

            e.Graphics.DrawString("Batch Size :", ReportFont1, Brushes.Black, 225, 302)
            e.Graphics.DrawString(TextBox6.Text, ReportFont5, Brushes.Black, 300, 302)

            e.Graphics.DrawString("Mfg Date :", ReportFont1, Brushes.Black, 440, 302)
            e.Graphics.DrawString(GunaTextBox1.Text, ReportFont5, Brushes.Black, 513, 302)

            e.Graphics.DrawString("Exp Date :", ReportFont1, Brushes.Black, 621, 302)
            e.Graphics.DrawString(GunaTextBox2.Text, ReportFont5, Brushes.Black, 690, 303)

            e.Graphics.DrawString("Sample Qty : ", ReportFont1, Brushes.Black, 23, 342)
            e.Graphics.DrawString(TextBox31.Text, ReportFont5, Brushes.Black, 111, 342)

            e.Graphics.DrawString("Pack :", ReportFont1, Brushes.Black, 280, 342)
            e.Graphics.DrawString(ComboBox10.Text, ReportFont5, Brushes.Black, 325, 342)

            e.Graphics.DrawString("Condition :", ReportFont1, Brushes.Black, 23, 381)
            e.Graphics.DrawString(ComboBox1.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 375, 200, 30), StringFormat)

            e.Graphics.DrawString("Period :", ReportFont1, Brushes.Black, 280, 381)
            e.Graphics.DrawString(ComboBox11.Text, ReportFont5, Brushes.Black, 335, 381)

            e.Graphics.DrawString("Test Requested :", ReportFont1, Brushes.Black, 23, 420)
            e.Graphics.DrawString(ComboBox7.Text, ReportFont5, Brushes.Black, 133, 420)

            e.Graphics.DrawString("Details of Test :", ReportFont1, Brushes.Black, 23, 470)
            e.Graphics.DrawString(TextBox29.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(130, 450, 645, 50), StringFormat)

            e.Graphics.DrawString("Remarks :", ReportFont1, Brushes.Black, 23, 510)
            If String.IsNullOrEmpty(TextBox32.Text) Then
                e.Graphics.DrawString("Nil", ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            Else
                e.Graphics.DrawString(TextBox32.Text, ReportFont5, Brushes.Black, New System.Drawing.Rectangle(100, 500, 670, 40), StringFormat)
            End If

            e.Graphics.DrawString("Sent By :", ReportFont1, Brushes.Black, 23, 550)
            e.Graphics.DrawString(Homepagefrdj.Label1.Text, ReportFont5, Brushes.Black, 90, 550)
            e.Graphics.DrawString("Recieved By :", ReportFont1, Brushes.Black, 285, 550)

            e.Graphics.DrawString("AR No :", ReportFont1, Brushes.Black, 515, 550)

            e.Graphics.DrawString("STP No. :", ReportFont1, Brushes.Black, 23, 589)
            e.Graphics.DrawString("LNB Reference No :", ReportFont1, Brushes.Black, 515, 589)

            e.Graphics.DrawString("Sr No.", ReportFont1, Brushes.Black, 23, 623)
            e.Graphics.DrawString("Test", ReportFont1, Brushes.Black, 175, 623)
            e.Graphics.DrawString("Condition", ReportFont1, Brushes.Black, 390, 623)
            e.Graphics.DrawString("Result", ReportFont1, Brushes.Black, 635, 623)


            e.Graphics.DrawString("Analysed By :", ReportFont1, Brushes.Black, 26, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 26, 958)
            e.Graphics.DrawString("Checked By :", ReportFont1, Brushes.Black, 280, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 280, 958)
            e.Graphics.DrawString("Released By :", ReportFont1, Brushes.Black, 540, 913)
            e.Graphics.DrawString("Date :", ReportFont1, Brushes.Black, 540, 958)

            If con.State = ConnectionState.Open Then con.Close()
            Dim qry1 As String
            qry1 = "select trformatno from formatno where srno='1'"
            cmd1 = New SqlCommand(qry1, con)
            con.Open()
            Dim annexno As String
            annexno = cmd1.ExecuteScalar().ToString()
            con.Close()
            e.Graphics.DrawString(annexno, ReportFont3, Brushes.Black, 650, 1000)



            e.Graphics.DrawImage(PictureBox1.Image, 300, 65, PictureBox1.Width, PictureBox1.Height)

            'square 1
            e.Graphics.DrawRectangle(blackPen, 15, 35, 760, 855)

            'from 2nd top
            'line.1
            e.Graphics.DrawLine(blackPen, 15.0F, 63.0F, 775.0F, 63.0F)
            'line 2
            e.Graphics.DrawLine(blackPen, 15.0F, 173.0F, 775.0F, 173.0F)
            'line 3
            e.Graphics.DrawLine(blackPen, 15.0F, 211.0F, 775.0F, 211.0F)
            'line 4
            e.Graphics.DrawLine(blackPen, 15.0F, 250.0F, 775.0F, 250.0F)
            'line 5
            e.Graphics.DrawLine(blackPen, 15.0F, 290.0F, 775.0F, 290.0F)
            'line 6
            e.Graphics.DrawLine(blackPen, 15.0F, 330.0F, 775.0F, 330.0F)
            'line 7
            e.Graphics.DrawLine(blackPen, 15.0F, 370.0F, 775.0F, 370.0F)
            'line 8
            e.Graphics.DrawLine(blackPen, 15.0F, 410.0F, 775.0F, 410.0F)
            'line 9
            e.Graphics.DrawLine(blackPen, 15.0F, 450.0F, 775.0F, 450.0F)
            'line 10
            e.Graphics.DrawLine(blackPen, 15.0F, 500.0F, 775.0F, 500.0F)
            'line 11
            e.Graphics.DrawLine(blackPen, 15.0F, 540.0F, 775.0F, 540.0F)
            'line 12
            e.Graphics.DrawLine(blackPen, 15.0F, 580.0F, 775.0F, 580.0F)
            'line 13
            e.Graphics.DrawLine(blackPen, 15.0F, 615.0F, 775.0F, 615.0F)
            'line 14
            e.Graphics.DrawLine(blackPen, 15.0F, 645.0F, 775.0F, 645.0F)
            'line 15
            e.Graphics.DrawLine(blackPen, 15.0F, 945.0F, 775.0F, 945.0F)


            'from left side
            'at product name
            e.Graphics.DrawLine(blackPen, 218.0F, 211.0F, 218.0F, 250.0F)
            'at bacth size
            e.Graphics.DrawLine(blackPen, 218.0F, 290.0F, 218.0F, 330.0F)
            'at mfg date
            e.Graphics.DrawLine(blackPen, 430.0F, 290.0F, 430.0F, 330.0F)
            'at Exp Date
            e.Graphics.DrawLine(blackPen, 610.0F, 290.0F, 610.0F, 330.0F)
            'at pack
            e.Graphics.DrawLine(blackPen, 270.0F, 330.0F, 270.0F, 410.0F)
            'at Recieved by
            e.Graphics.DrawLine(blackPen, 280.0F, 540.0F, 280.0F, 580.0F)
            'at AR No.
            e.Graphics.DrawLine(blackPen, 510.0F, 540.0F, 510.0F, 615.0F)

            'at test
            e.Graphics.DrawLine(blackPen, 70.0F, 615.0F, 70.0F, 890.0F)
            'at condition
            e.Graphics.DrawLine(blackPen, 310.0F, 615.0F, 310.0F, 890.0F)
            'at result
            e.Graphics.DrawLine(blackPen, 550.0F, 615.0F, 550.0F, 890.0F)
            'at checked by
            e.Graphics.DrawLine(blackPen, 275.0F, 900.0F, 275.0F, 990.0F)
            'at released by
            e.Graphics.DrawLine(blackPen, 535.0F, 900.0F, 535.0F, 990.0F)
            'square 2
            e.Graphics.DrawRectangle(blackPen, 15, 900, 760, 90)

            'for number of pages
            'pageNo = pageNo + 1
            'e.HasMorePages = pageNo <= 3
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub LoadBatchFromPlnr()
        Try
            ComboBox9.Items.Clear()
            ComboBox9.Text = ""
            ComboBox10.Items.Clear()
            ComboBox10.Text = ""
            ComboBox11.Items.Clear()
            ComboBox11.Text = ""
            If con.State = ConnectionState.Open Then con.Close()
            Dim reader As SqlDataReader
            con.Open()
            Dim qry As String
            qry = "select DISTINCT(btn) from plnr where proname='" + TextBox2.Text + "' and strength='" + TextBox3.Text + "' and cndn='" + ComboBox1.Text + "' order by btn ASC"
            cmd1 = New SqlCommand(qry, con)
            reader = cmd1.ExecuteReader
            While reader.Read
                ComboBox9.Items.Add(reader("btn"))

            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        LoadBatchFromPlnr()
        GetSampleDetails()
        ClearFields()
    End Sub
    Private Sub LoadPackStyle()
        Try
            ComboBox10.Items.Clear()
            ComboBox10.Text = ""
            ComboBox11.Items.Clear()
            ComboBox11.Text = ""
            If con.State = ConnectionState.Open Then con.Close()
            Dim reader As SqlDataReader
            con.Open()
            Dim qry As String
            qry = "select DISTINCT(pctyp) from plnr where proname='" + TextBox2.Text + "' and strength='" + TextBox3.Text + "' and cndn='" + ComboBox1.Text + "' and btn='" + ComboBox9.Text + "' order by pctyp ASC"
            cmd1 = New SqlCommand(qry, con)
            reader = cmd1.ExecuteReader
            While reader.Read
                ComboBox10.Items.Add(reader("pctyp"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged
        LoadPackStyle()
        GetSampleDetails()
    End Sub
    Private Sub LoadPeriod()
        Try
            ComboBox11.Items.Clear()
            ComboBox11.Text = ""
            If con.State = ConnectionState.Open Then con.Close()
            Dim reader As SqlDataReader
            con.Open()
            Dim qry As String
            qry = "select DISTINCT(sch) from plnr where proname='" + TextBox2.Text + "' and strength='" + TextBox3.Text + "' and cndn='" + ComboBox1.Text + "' and btn='" + ComboBox9.Text + "' and pctyp='" + ComboBox10.Text + "' order by sch ASC"
            cmd1 = New SqlCommand(qry, con)
            reader = cmd1.ExecuteReader
            While reader.Read
                ComboBox11.Items.Add(reader("sch"))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox10.SelectedIndexChanged
        LoadPeriod()
        GetSampleDetails()
    End Sub

    Private Sub ComboBox11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox11.SelectedIndexChanged
        GetSampleDetails()

    End Sub
    Private Sub GetSampleDetails()
        Try
            GunaLabel13.Text = "."
            GunaLabel14.Text = "."
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con

            da = New SqlDataAdapter("select chrgdate,totalsampleqty,availsampleqty from plnr where proname='" + TextBox2.Text + "' and strength='" + TextBox3.Text + "' and cndn='" + ComboBox1.Text + "' and btn='" + ComboBox9.Text + "' and pctyp='" + ComboBox10.Text + "' and sch='" + ComboBox11.Text + "' order by sch ASC", con)
            Dim table As New DataTable()
            da.Fill(table)

            If table.Rows.Count = 1 Then
                GunaLabel13.Text = table.Rows(0)(1).ToString()
                GunaLabel14.Text = table.Rows(0)(2).ToString()

                Dim chrgdate As Date = Date.ParseExact(table.Rows(0)(0), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                TextBox12.Text = "Charging Date: " + chrgdate
                TextBox16.Text = "Charging Date: " + chrgdate
                TextBox20.Text = "Charging Date: " + chrgdate
                TextBox24.Text = "Charging Date: " + chrgdate
                TextBox28.Text = "Charging Date: " + chrgdate
                TextBox32.Text = "Charging Date: " + chrgdate
            Else
                'For i As Integer = 0 To table.Rows.Count - 1
                'Dim totlasample As Double
                GunaLabel13.Text = table.Compute("Sum(totalsampleqty)", "").ToString
                GunaLabel14.Text = table.Compute("Sum(availsampleqty)", "").ToString
                TextBox12.Text = "Multiple Protocols Available"
                TextBox16.Text = "Multiple Protocols Available"
                TextBox20.Text = "Multiple Protocols Available"
                TextBox24.Text = "Multiple Protocols Available"
                TextBox28.Text = "Multiple Protocols Available"
                TextBox32.Text = "Multiple Protocols Available"
                'Next
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ClearFields()
        ComboBox9.Text = ""
        ComboBox10.Text = ""
        ComboBox11.Text = ""
        GunaLabel13.Text = "."
        GunaLabel14.Text = "."
        TextBox12.Text = ""
        TextBox16.Text = ""
        TextBox20.Text = ""
        TextBox24.Text = ""
        TextBox28.Text = ""
        TextBox32.Text = ""
    End Sub

End Class