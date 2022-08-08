Imports System.Data.SqlClient
Imports System.IO

Public Class addplanner
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub addplanner_Load(sender As Object, e As EventArgs) Handles Me.Load

        'loadproname()
        loadpackstyle()
        Panel7.Hide()
        Panel8.Hide()
        Panel19.Hide()
        Panel25.Hide()
        Panel31.Hide()
        Panel37.Hide()
        'hidecheck()
        DateTimePicker1.Value = DateTime.Now
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
    Private Sub loadproname()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select proname from proname order by [proname] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("proname"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub loadpackstyle()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select pack from pack order by [pack] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                GunaComboBox1.Items.Add(dr("pack"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Dim CountProtocol As String
    Private Sub CountProtoclNumbers()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            cmd.Connection = con
            con.Open()
            cmd.CommandText = "select count([ptn]) from plnr where ptn='" + TextBox2.Text + "'"
            CountProtocol = cmd.ExecuteScalar().ToString()
            con.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            CountProtoclNumbers()
            If ComboBox1.Text = "" Then
                MsgBox("Select Product Name", vbCritical)
            ElseIf TextBox1.Text = "" Then
                MsgBox("Enter Batch Number", vbCritical)
            ElseIf TextBox2.Text = "" Then
                MsgBox("Enter Protocol Number", vbCritical)
            ElseIf GunaComboBox1.Text = "" Then
                MsgBox("Enter Pack Style", vbCritical)
            ElseIf ComboBox2.Text = "" Then
                MsgBox("select number of Conditions", vbCritical)
            ElseIf DateTimePicker1.Text = " " Then
                MsgBox("Select charging date", vbCritical)
            ElseIf CountProtocol > 0 Then
                MsgBox("Protocl Already Added", vbCritical)
            ElseIf ComboBox2.Text = "1" Then
                If TextBox4.Text = "" Then
                    MsgBox("Enter Sample Quantity", vbCritical)
                ElseIf TextBox5.Text = "" Then
                    MsgBox("Enter pack count", vbCritical)
                ElseIf ComboBox3.Text = "" Then
                    MsgBox("Select condition", vbCritical)
                ElseIf TextBox6.Text = "" Then
                    MsgBox("Enter Box Number", vbCritical)
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False And CheckBox8.Checked = False And CheckBox9.Checked = False And CheckBox10.Checked = False And CheckBox11.Checked = False And CheckBox12.Checked = False And A7.Checked = False And A14.Checked = False And A21.Checked = False And A28.Checked = False Then
                    MsgBox("Select atleast one period", vbCritical)
                Else
                    Me.Cursor = Cursors.WaitCursor
                    one_batch()

                    MsgBox("Plan Added Successfully", vbInformation)
                    Dim f1 As viewchrgplanner = DirectCast(Me.Owner, viewchrgplanner)
                    f1.loadplnr()
                    Me.Close()
                End If
            ElseIf ComboBox2.Text = "2" Then
                If TextBox4.Text = "" Then
                    MsgBox("Enter First Sample Quantity", vbCritical)
                ElseIf TextBox5.Text = "" Then
                    MsgBox("Enter First pack count", vbCritical)
                ElseIf ComboBox3.Text = "" Then
                    MsgBox("Select First condition", vbCritical)
                ElseIf TextBox6.Text = "" Then
                    MsgBox("Enter First Box Number", vbCritical)
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False And CheckBox8.Checked = False And CheckBox9.Checked = False And CheckBox10.Checked = False And CheckBox11.Checked = False And CheckBox12.Checked = False And A7.Checked = False And A14.Checked = False And A21.Checked = False And A28.Checked = False Then
                    MsgBox("Select atleast one period in first entry", vbCritical)
                ElseIf TextBox7.Text = "" Then
                    MsgBox("Enter second Sample Quantity", vbCritical)
                ElseIf TextBox8.Text = "" Then
                    MsgBox("Enter second pack count", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select second condition", vbCritical)
                ElseIf TextBox9.Text = "" Then
                    MsgBox("Enter second Box Number", vbCritical)
                ElseIf CheckBox13.Checked = False And CheckBox14.Checked = False And CheckBox15.Checked = False And CheckBox16.Checked = False And CheckBox17.Checked = False And CheckBox18.Checked = False And CheckBox19.Checked = False And CheckBox20.Checked = False And CheckBox21.Checked = False And CheckBox22.Checked = False And CheckBox23.Checked = False And CheckBox24.Checked = False And B7.Checked = False And B14.Checked = False And B21.Checked = False And B28.Checked = False Then
                    MsgBox("Select atleast one period in second entry", vbCritical)
                Else
                    Me.Cursor = Cursors.WaitCursor
                    one_batch()
                    two_batch()


                    MsgBox("Plan Added Successfully", vbInformation)
                    Dim f1 As viewchrgplanner = DirectCast(Me.Owner, viewchrgplanner)
                    f1.loadplnr()
                    Me.Close()
                End If
            ElseIf ComboBox2.Text = "3" Then
                If TextBox4.Text = "" Then
                    MsgBox("Enter First Sample Quantity", vbCritical)
                ElseIf TextBox5.Text = "" Then
                    MsgBox("Enter First pack count", vbCritical)
                ElseIf ComboBox3.Text = "" Then
                    MsgBox("Select First condition", vbCritical)
                ElseIf TextBox6.Text = "" Then
                    MsgBox("Enter First Box Number", vbCritical)
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False And CheckBox8.Checked = False And CheckBox9.Checked = False And CheckBox10.Checked = False And CheckBox11.Checked = False And CheckBox12.Checked = False And A7.Checked = False And A14.Checked = False And A21.Checked = False And A28.Checked = False Then
                    MsgBox("Select atleast one period in first entry", vbCritical)
                ElseIf TextBox7.Text = "" Then
                    MsgBox("Enter second Sample Quantity", vbCritical)
                ElseIf TextBox8.Text = "" Then
                    MsgBox("Enter second pack count", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select second condition", vbCritical)
                ElseIf TextBox9.Text = "" Then
                    MsgBox("Enter second Box Number", vbCritical)
                ElseIf CheckBox13.Checked = False And CheckBox14.Checked = False And CheckBox15.Checked = False And CheckBox16.Checked = False And CheckBox17.Checked = False And CheckBox18.Checked = False And CheckBox19.Checked = False And CheckBox20.Checked = False And CheckBox21.Checked = False And CheckBox22.Checked = False And CheckBox23.Checked = False And CheckBox24.Checked = False And B7.Checked = False And B14.Checked = False And B21.Checked = False And B28.Checked = False Then
                    MsgBox("Select atleast one period in second entry", vbCritical)
                ElseIf TextBox10.Text = "" Then
                    MsgBox("Enter Third Sample Quantity", vbCritical)
                ElseIf TextBox11.Text = "" Then
                    MsgBox("Enter Third pack count", vbCritical)
                ElseIf ComboBox5.Text = "" Then
                    MsgBox("Select Third condition", vbCritical)
                ElseIf TextBox12.Text = "" Then
                    MsgBox("Enter Third Box Number", vbCritical)
                ElseIf CheckBox25.Checked = False And CheckBox26.Checked = False And CheckBox27.Checked = False And CheckBox28.Checked = False And CheckBox29.Checked = False And CheckBox30.Checked = False And CheckBox31.Checked = False And CheckBox32.Checked = False And CheckBox33.Checked = False And CheckBox34.Checked = False And CheckBox35.Checked = False And CheckBox36.Checked = False And C7.Checked = False And C14.Checked = False And C21.Checked = False And C28.Checked = False Then
                    MsgBox("Select atleast one period in third entry", vbCritical)
                Else
                    Me.Cursor = Cursors.WaitCursor
                    one_batch()
                    two_batch()
                    three_batch()


                    MsgBox("Plan Added Successfully", vbInformation)
                    Dim f1 As viewchrgplanner = DirectCast(Me.Owner, viewchrgplanner)
                    f1.loadplnr()
                    Me.Close()
                End If
            ElseIf ComboBox2.Text = "4" Then
                If TextBox4.Text = "" Then
                    MsgBox("Enter First Sample Quantity", vbCritical)
                ElseIf TextBox5.Text = "" Then
                    MsgBox("Enter First pack count", vbCritical)
                ElseIf ComboBox3.Text = "" Then
                    MsgBox("Select First condition", vbCritical)
                ElseIf TextBox6.Text = "" Then
                    MsgBox("Enter First Box Number", vbCritical)
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False And CheckBox8.Checked = False And CheckBox9.Checked = False And CheckBox10.Checked = False And CheckBox11.Checked = False And CheckBox12.Checked = False And A7.Checked = False And A14.Checked = False And A21.Checked = False And A28.Checked = False Then
                    MsgBox("Select atleast one period in first entry", vbCritical)
                ElseIf TextBox7.Text = "" Then
                    MsgBox("Enter second Sample Quantity", vbCritical)
                ElseIf TextBox8.Text = "" Then
                    MsgBox("Enter second pack count", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select second condition", vbCritical)
                ElseIf TextBox9.Text = "" Then
                    MsgBox("Enter second Box Number", vbCritical)
                ElseIf CheckBox13.Checked = False And CheckBox14.Checked = False And CheckBox15.Checked = False And CheckBox16.Checked = False And CheckBox17.Checked = False And CheckBox18.Checked = False And CheckBox19.Checked = False And CheckBox20.Checked = False And CheckBox21.Checked = False And CheckBox22.Checked = False And CheckBox23.Checked = False And CheckBox24.Checked = False And B7.Checked = False And B14.Checked = False And B21.Checked = False And B28.Checked = False Then
                    MsgBox("Select atleast one period in second entry", vbCritical)
                ElseIf TextBox10.Text = "" Then
                    MsgBox("Enter Third Sample Quantity", vbCritical)
                ElseIf TextBox11.Text = "" Then
                    MsgBox("Enter Third pack count", vbCritical)
                ElseIf ComboBox5.Text = "" Then
                    MsgBox("Select Third condition", vbCritical)
                ElseIf TextBox12.Text = "" Then
                    MsgBox("Enter Third Box Number", vbCritical)
                ElseIf CheckBox25.Checked = False And CheckBox26.Checked = False And CheckBox27.Checked = False And CheckBox28.Checked = False And CheckBox29.Checked = False And CheckBox30.Checked = False And CheckBox31.Checked = False And CheckBox32.Checked = False And CheckBox33.Checked = False And CheckBox34.Checked = False And CheckBox35.Checked = False And CheckBox36.Checked = False And C7.Checked = False And C14.Checked = False And C21.Checked = False And C28.Checked = False Then
                    MsgBox("Select atleast one period in third entry", vbCritical)
                ElseIf TextBox13.Text = "" Then
                    MsgBox("Enter fourth Sample Quantity", vbCritical)
                ElseIf TextBox14.Text = "" Then
                    MsgBox("Enter fourth pack count", vbCritical)
                ElseIf ComboBox6.Text = "" Then
                    MsgBox("Select fourth condition", vbCritical)
                ElseIf TextBox15.Text = "" Then
                    MsgBox("Enter fourth Box Number", vbCritical)
                ElseIf CheckBox37.Checked = False And CheckBox38.Checked = False And CheckBox39.Checked = False And CheckBox40.Checked = False And CheckBox41.Checked = False And CheckBox42.Checked = False And CheckBox43.Checked = False And CheckBox44.Checked = False And CheckBox45.Checked = False And CheckBox46.Checked = False And CheckBox47.Checked = False And CheckBox48.Checked = False And D7.Checked = False And D14.Checked = False And D21.Checked = False And D28.Checked = False Then
                    MsgBox("Select atleast one period in fourth entry", vbCritical)
                Else
                    Me.Cursor = Cursors.WaitCursor
                    one_batch()
                    two_batch()
                    three_batch()
                    foure_batch()


                    MsgBox("Plan Added Successfully", vbInformation)
                    Dim f1 As viewchrgplanner = DirectCast(Me.Owner, viewchrgplanner)
                    f1.loadplnr()
                    Me.Close()
                End If
            ElseIf ComboBox2.Text = "5" Then
                If TextBox4.Text = "" Then
                    MsgBox("Enter First Sample Quantity", vbCritical)
                ElseIf TextBox5.Text = "" Then
                    MsgBox("Enter First pack count", vbCritical)
                ElseIf ComboBox3.Text = "" Then
                    MsgBox("Select First condition", vbCritical)
                ElseIf TextBox6.Text = "" Then
                    MsgBox("Enter First Box Number", vbCritical)
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False And CheckBox8.Checked = False And CheckBox9.Checked = False And CheckBox10.Checked = False And CheckBox11.Checked = False And CheckBox12.Checked = False And A7.Checked = False And A14.Checked = False And A21.Checked = False And A28.Checked = False Then
                    MsgBox("Select atleast one period in first entry", vbCritical)
                ElseIf TextBox7.Text = "" Then
                    MsgBox("Enter second Sample Quantity", vbCritical)
                ElseIf TextBox8.Text = "" Then
                    MsgBox("Enter second pack count", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select second condition", vbCritical)
                ElseIf TextBox9.Text = "" Then
                    MsgBox("Enter second Box Number", vbCritical)
                ElseIf CheckBox13.Checked = False And CheckBox14.Checked = False And CheckBox15.Checked = False And CheckBox16.Checked = False And CheckBox17.Checked = False And CheckBox18.Checked = False And CheckBox19.Checked = False And CheckBox20.Checked = False And CheckBox21.Checked = False And CheckBox22.Checked = False And CheckBox23.Checked = False And CheckBox24.Checked = False And B7.Checked = False And B14.Checked = False And B21.Checked = False And B28.Checked = False Then
                    MsgBox("Select atleast one period in second entry", vbCritical)
                ElseIf TextBox10.Text = "" Then
                    MsgBox("Enter Third Sample Quantity", vbCritical)
                ElseIf TextBox11.Text = "" Then
                    MsgBox("Enter Third pack count", vbCritical)
                ElseIf ComboBox5.Text = "" Then
                    MsgBox("Select Third condition", vbCritical)
                ElseIf TextBox12.Text = "" Then
                    MsgBox("Enter Third Box Number", vbCritical)
                ElseIf CheckBox25.Checked = False And CheckBox26.Checked = False And CheckBox27.Checked = False And CheckBox28.Checked = False And CheckBox29.Checked = False And CheckBox30.Checked = False And CheckBox31.Checked = False And CheckBox32.Checked = False And CheckBox33.Checked = False And CheckBox34.Checked = False And CheckBox35.Checked = False And CheckBox36.Checked = False And C7.Checked = False And C14.Checked = False And C21.Checked = False And C28.Checked = False Then
                    MsgBox("Select atleast one period in third entry", vbCritical)
                ElseIf TextBox13.Text = "" Then
                    MsgBox("Enter fourth Sample Quantity", vbCritical)
                ElseIf TextBox14.Text = "" Then
                    MsgBox("Enter fourth pack count", vbCritical)
                ElseIf ComboBox6.Text = "" Then
                    MsgBox("Select fourth condition", vbCritical)
                ElseIf TextBox15.Text = "" Then
                    MsgBox("Enter fourth Box Number", vbCritical)
                ElseIf CheckBox37.Checked = False And CheckBox38.Checked = False And CheckBox39.Checked = False And CheckBox40.Checked = False And CheckBox41.Checked = False And CheckBox42.Checked = False And CheckBox43.Checked = False And CheckBox44.Checked = False And CheckBox45.Checked = False And CheckBox46.Checked = False And CheckBox47.Checked = False And CheckBox48.Checked = False And D7.Checked = False And D14.Checked = False And D21.Checked = False And D28.Checked = False Then
                    MsgBox("Select atleast one period in fourth entry", vbCritical)
                ElseIf TextBox16.Text = "" Then
                    MsgBox("Enter fifth Sample Quantity", vbCritical)
                ElseIf TextBox17.Text = "" Then
                    MsgBox("Enter fifth pack count", vbCritical)
                ElseIf ComboBox7.Text = "" Then
                    MsgBox("Select fifth condition", vbCritical)
                ElseIf TextBox18.Text = "" Then
                    MsgBox("Enter fifth Box Number", vbCritical)
                ElseIf CheckBox49.Checked = False And CheckBox50.Checked = False And CheckBox51.Checked = False And CheckBox52.Checked = False And CheckBox53.Checked = False And CheckBox54.Checked = False And CheckBox55.Checked = False And CheckBox56.Checked = False And CheckBox57.Checked = False And CheckBox58.Checked = False And CheckBox59.Checked = False And CheckBox60.Checked = False And E7.Checked = False And E14.Checked = False And E21.Checked = False And E28.Checked = False Then
                    MsgBox("Select atleast one period in fifth entry", vbCritical)
                Else
                    Me.Cursor = Cursors.WaitCursor
                    one_batch()
                    two_batch()
                    three_batch()
                    foure_batch()
                    five_batch()

                    MsgBox("Plan Added Successfully", vbInformation)
                    Dim f1 As viewchrgplanner = DirectCast(Me.Owner, viewchrgplanner)
                    f1.loadplnr()
                    Me.Close()
                End If
            ElseIf ComboBox2.Text = "6" Then
                If TextBox4.Text = "" Then
                    MsgBox("Enter First Sample Quantity", vbCritical)
                ElseIf TextBox5.Text = "" Then
                    MsgBox("Enter First pack count", vbCritical)
                ElseIf ComboBox3.Text = "" Then
                    MsgBox("Select First condition", vbCritical)
                ElseIf TextBox6.Text = "" Then
                    MsgBox("Enter First Box Number", vbCritical)
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False And CheckBox8.Checked = False And CheckBox9.Checked = False And CheckBox10.Checked = False And CheckBox11.Checked = False And CheckBox12.Checked = False And A7.Checked = False And A14.Checked = False And A21.Checked = False And A28.Checked = False Then
                    MsgBox("Select atleast one period in first entry", vbCritical)
                ElseIf TextBox7.Text = "" Then
                    MsgBox("Enter second Sample Quantity", vbCritical)
                ElseIf TextBox8.Text = "" Then
                    MsgBox("Enter second pack count", vbCritical)
                ElseIf ComboBox4.Text = "" Then
                    MsgBox("Select second condition", vbCritical)
                ElseIf TextBox9.Text = "" Then
                    MsgBox("Enter second Box Number", vbCritical)
                ElseIf CheckBox13.Checked = False And CheckBox14.Checked = False And CheckBox15.Checked = False And CheckBox16.Checked = False And CheckBox17.Checked = False And CheckBox18.Checked = False And CheckBox19.Checked = False And CheckBox20.Checked = False And CheckBox21.Checked = False And CheckBox22.Checked = False And CheckBox23.Checked = False And CheckBox24.Checked = False And B7.Checked = False And B14.Checked = False And B21.Checked = False And B28.Checked = False Then
                    MsgBox("Select atleast one period in second entry", vbCritical)
                ElseIf TextBox10.Text = "" Then
                    MsgBox("Enter Third Sample Quantity", vbCritical)
                ElseIf TextBox11.Text = "" Then
                    MsgBox("Enter Third pack count", vbCritical)
                ElseIf ComboBox5.Text = "" Then
                    MsgBox("Select Third condition", vbCritical)
                ElseIf TextBox12.Text = "" Then
                    MsgBox("Enter Third Box Number", vbCritical)
                ElseIf CheckBox25.Checked = False And CheckBox26.Checked = False And CheckBox27.Checked = False And CheckBox28.Checked = False And CheckBox29.Checked = False And CheckBox30.Checked = False And CheckBox31.Checked = False And CheckBox32.Checked = False And CheckBox33.Checked = False And CheckBox34.Checked = False And CheckBox35.Checked = False And CheckBox36.Checked = False And C7.Checked = False And C14.Checked = False And C21.Checked = False And C28.Checked = False Then
                    MsgBox("Select atleast one period in third entry", vbCritical)
                ElseIf TextBox13.Text = "" Then
                    MsgBox("Enter fourth Sample Quantity", vbCritical)
                ElseIf TextBox14.Text = "" Then
                    MsgBox("Enter fourth pack count", vbCritical)
                ElseIf ComboBox6.Text = "" Then
                    MsgBox("Select fourth condition", vbCritical)
                ElseIf TextBox15.Text = "" Then
                    MsgBox("Enter fourth Box Number", vbCritical)
                ElseIf CheckBox37.Checked = False And CheckBox38.Checked = False And CheckBox39.Checked = False And CheckBox40.Checked = False And CheckBox41.Checked = False And CheckBox42.Checked = False And CheckBox43.Checked = False And CheckBox44.Checked = False And CheckBox45.Checked = False And CheckBox46.Checked = False And CheckBox47.Checked = False And CheckBox48.Checked = False And D7.Checked = False And D14.Checked = False And D21.Checked = False And D28.Checked = False Then
                    MsgBox("Select atleast one period in fourth entry", vbCritical)
                ElseIf TextBox16.Text = "" Then
                    MsgBox("Enter fifth Sample Quantity", vbCritical)
                ElseIf TextBox17.Text = "" Then
                    MsgBox("Enter fifth pack count", vbCritical)
                ElseIf ComboBox7.Text = "" Then
                    MsgBox("Select fifth condition", vbCritical)
                ElseIf TextBox18.Text = "" Then
                    MsgBox("Enter fifth Box Number", vbCritical)
                ElseIf CheckBox49.Checked = False And CheckBox50.Checked = False And CheckBox51.Checked = False And CheckBox52.Checked = False And CheckBox53.Checked = False And CheckBox54.Checked = False And CheckBox55.Checked = False And CheckBox56.Checked = False And CheckBox57.Checked = False And CheckBox58.Checked = False And CheckBox59.Checked = False And CheckBox60.Checked = False And E7.Checked = False And E14.Checked = False And E21.Checked = False And E28.Checked = False Then
                    MsgBox("Select atleast one period in fifth entry", vbCritical)
                ElseIf TextBox19.Text = "" Then
                    MsgBox("Enter fifth Sample Quantity", vbCritical)
                ElseIf TextBox20.Text = "" Then
                    MsgBox("Enter fifth pack count", vbCritical)
                ElseIf ComboBox8.Text = "" Then
                    MsgBox("Select fifth condition", vbCritical)
                ElseIf TextBox21.Text = "" Then
                    MsgBox("Enter fifth Box Number", vbCritical)
                ElseIf CheckBox61.Checked = False And CheckBox62.Checked = False And CheckBox63.Checked = False And CheckBox64.Checked = False And CheckBox65.Checked = False And CheckBox66.Checked = False And CheckBox67.Checked = False And CheckBox68.Checked = False And CheckBox69.Checked = False And CheckBox70.Checked = False And CheckBox71.Checked = False And CheckBox72.Checked = False And F7.Checked = False And F14.Checked = False And F21.Checked = False And F28.Checked = False Then
                    MsgBox("Select atleast one period in sixth entry", vbCritical)
                Else
                    Me.Cursor = Cursors.WaitCursor
                    one_batch()
                    two_batch()
                    three_batch()
                    foure_batch()
                    five_batch()
                    six_batch()

                    MsgBox("Plan Added Successfully", vbInformation)
                    Dim f1 As viewchrgplanner = DirectCast(Me.Owner, viewchrgplanner)
                    f1.loadplnr()
                    Me.Close()
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub one_batch()
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel46.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTimePicker1.Value.Date
                cb.Name = System.Text.RegularExpressions.Regex.Replace(cb.Name, "[^\d]", " ")
                podate = podate.AddDays(cb.Name)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into plnr(proname,strength,cndn,btn,pctyp,pccnt,chrgbox,chrgdate,ptn,sch,podate,instid,totalsampleqty,availsampleqty,addedby,addedon,remarks) values('" + ComboBox1.Text + "','" + GunaTextBox1.Text + "','" + ComboBox3.Text + "','" + TextBox1.Text + "','" + GunaComboBox1.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "',@chrgdate,'" + TextBox2.Text + "','" + cb.Text + "',@podate,'" + instid1 + "','" + TextBox4.Text + "','" + TextBox4.Text + "','" + homepage.Label1.Text + "',@addedon,'" + GunaTextBox2.Text + "')"
                cmd.Parameters.AddWithValue("@chrgdate", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                cmd.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel16.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()

                Dim podate As Date = DateTimePicker1.Value.Date
                podate = podate.AddMonths(cb.Text)
                ' MsgBox(podate)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into plnr(proname,strength,cndn,btn,pctyp,pccnt,chrgbox,chrgdate,ptn,sch,podate,instid,totalsampleqty,availsampleqty,addedby,addedon,remarks) values('" + ComboBox1.Text + "','" + GunaTextBox1.Text + "','" + ComboBox3.Text + "','" + TextBox1.Text + "','" + GunaComboBox1.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "',@chrgdate,'" + TextBox2.Text + "','" + cb.Text + "M',@podate,'" + instid1 + "','" + TextBox4.Text + "','" + TextBox4.Text + "','" + homepage.Label1.Text + "',@addedon,'" + GunaTextBox2.Text + "')"
                cmd.Parameters.AddWithValue("@chrgdate", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                cmd.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
    End Sub
    Private Sub two_batch()
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel47.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTimePicker1.Value.Date
                cb.Name = System.Text.RegularExpressions.Regex.Replace(cb.Name, "[^\d]", " ")
                podate = podate.AddDays(cb.Name)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into plnr(proname,strength,cndn,btn,pctyp,pccnt,chrgbox,chrgdate,ptn,sch,podate,instid,totalsampleqty,availsampleqty,addedby,addedon,remarks) values('" + ComboBox1.Text + "','" + GunaTextBox1.Text + "','" + ComboBox4.Text + "','" + TextBox1.Text + "','" + GunaComboBox1.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "',@chrgdate,'" + TextBox2.Text + "','" + cb.Text + "',@podate,'" + instid2 + "','" + TextBox7.Text + "','" + TextBox7.Text + "','" + homepage.Label1.Text + "',@addedon,'" + GunaTextBox2.Text + "')"
                cmd.Parameters.AddWithValue("@chrgdate", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                cmd.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel9.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTimePicker1.Value.Date
                podate = podate.AddMonths(cb.Text)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into plnr(proname,strength,cndn,btn,pctyp,pccnt,chrgbox,chrgdate,ptn,sch,podate,instid,totalsampleqty,availsampleqty,addedby,addedon,remarks) values('" + ComboBox1.Text + "','" + GunaTextBox1.Text + "','" + ComboBox4.Text + "','" + TextBox1.Text + "','" + GunaComboBox1.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "',@chrgdate,'" + TextBox2.Text + "','" + cb.Text + "M',@podate,'" + instid2 + "','" + TextBox7.Text + "','" + TextBox7.Text + "','" + homepage.Label1.Text + "',@addedon,'" + GunaTextBox2.Text + "')"
                cmd.Parameters.AddWithValue("@chrgdate", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                cmd.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
    End Sub
    Private Sub three_batch()
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel48.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTimePicker1.Value.Date
                cb.Name = System.Text.RegularExpressions.Regex.Replace(cb.Name, "[^\d]", " ")
                podate = podate.AddDays(cb.Name)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into plnr(proname,strength,cndn,btn,pctyp,pccnt,chrgbox,chrgdate,ptn,sch,podate,instid,totalsampleqty,availsampleqty,addedby,addedon,remarks) values('" + ComboBox1.Text + "','" + GunaTextBox1.Text + "','" + ComboBox5.Text + "','" + TextBox1.Text + "','" + GunaComboBox1.Text + "','" + TextBox11.Text + "','" + TextBox12.Text + "',@chrgdate,'" + TextBox2.Text + "','" + cb.Text + "',@podate,'" + instid3 + "','" + TextBox10.Text + "','" + TextBox10.Text + "','" + homepage.Label1.Text + "',@addedon,'" + GunaTextBox2.Text + "')"
                cmd.Parameters.AddWithValue("@chrgdate", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                cmd.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel20.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTimePicker1.Value.Date
                podate = podate.AddMonths(cb.Text)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into plnr(proname,strength,cndn,btn,pctyp,pccnt,chrgbox,chrgdate,ptn,sch,podate,instid,totalsampleqty,availsampleqty,addedby,addedon,remarks) values('" + ComboBox1.Text + "','" + GunaTextBox1.Text + "','" + ComboBox5.Text + "','" + TextBox1.Text + "','" + GunaComboBox1.Text + "','" + TextBox11.Text + "','" + TextBox12.Text + "',@chrgdate,'" + TextBox2.Text + "','" + cb.Text + "M',@podate,'" + instid3 + "','" + TextBox10.Text + "','" + TextBox10.Text + "','" + homepage.Label1.Text + "',@addedon,'" + GunaTextBox2.Text + "')"
                cmd.Parameters.AddWithValue("@chrgdate", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                cmd.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
    End Sub
    Private Sub foure_batch()
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel49.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTimePicker1.Value.Date
                cb.Name = System.Text.RegularExpressions.Regex.Replace(cb.Name, "[^\d]", " ")
                podate = podate.AddDays(cb.Name)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into plnr(proname,strength,cndn,btn,pctyp,pccnt,chrgbox,chrgdate,ptn,sch,podate,instid,totalsampleqty,availsampleqty,addedby,addedon,remarks) values('" + ComboBox1.Text + "','" + GunaTextBox1.Text + "','" + ComboBox6.Text + "','" + TextBox1.Text + "','" + GunaComboBox1.Text + "','" + TextBox14.Text + "','" + TextBox15.Text + "',@chrgdate,'" + TextBox2.Text + "','" + cb.Text + "',@podate,'" + instid4 + "','" + TextBox13.Text + "','" + TextBox13.Text + "','" + homepage.Label1.Text + "',@addedon,'" + GunaTextBox2.Text + "')"
                cmd.Parameters.AddWithValue("@chrgdate", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                cmd.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel26.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTimePicker1.Value.Date
                podate = podate.AddMonths(cb.Text)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into plnr(proname,strength,cndn,btn,pctyp,pccnt,chrgbox,chrgdate,ptn,sch,podate,instid,totalsampleqty,availsampleqty,addedby,addedon,remarks) values('" + ComboBox1.Text + "','" + GunaTextBox1.Text + "','" + ComboBox6.Text + "','" + TextBox1.Text + "','" + GunaComboBox1.Text + "','" + TextBox14.Text + "','" + TextBox15.Text + "',@chrgdate,'" + TextBox2.Text + "','" + cb.Text + "M',@podate,'" + instid4 + "','" + TextBox13.Text + "','" + TextBox13.Text + "','" + homepage.Label1.Text + "',@addedon,'" + GunaTextBox2.Text + "')"
                cmd.Parameters.AddWithValue("@chrgdate", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                cmd.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
    End Sub
    Private Sub five_batch()
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel50.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTimePicker1.Value.Date
                cb.Name = System.Text.RegularExpressions.Regex.Replace(cb.Name, "[^\d]", " ")
                podate = podate.AddDays(cb.Name)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into plnr(proname,strength,cndn,btn,pctyp,pccnt,chrgbox,chrgdate,ptn,sch,podate,instid,totalsampleqty,availsampleqty,addedby,addedon,remarks) values('" + ComboBox1.Text + "','" + GunaTextBox1.Text + "','" + ComboBox7.Text + "','" + TextBox1.Text + "','" + GunaComboBox1.Text + "','" + TextBox17.Text + "','" + TextBox18.Text + "',@chrgdate,'" + TextBox2.Text + "','" + cb.Text + "',@podate,'" + instid5 + "','" + TextBox16.Text + "','" + TextBox16.Text + "','" + homepage.Label1.Text + "',@addedon,'" + GunaTextBox2.Text + "')"
                cmd.Parameters.AddWithValue("@chrgdate", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                cmd.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel32.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTimePicker1.Value.Date
                podate = podate.AddMonths(cb.Text)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into plnr(proname,strength,cndn,btn,pctyp,pccnt,chrgbox,chrgdate,ptn,sch,podate,instid,totalsampleqty,availsampleqty,addedby,addedon,remarks) values('" + ComboBox1.Text + "','" + GunaTextBox1.Text + "','" + ComboBox7.Text + "','" + TextBox1.Text + "','" + GunaComboBox1.Text + "','" + TextBox17.Text + "','" + TextBox18.Text + "',@chrgdate,'" + TextBox2.Text + "','" + cb.Text + "M',@podate,'" + instid5 + "','" + TextBox16.Text + "','" + TextBox16.Text + "','" + homepage.Label1.Text + "',@addedon,'" + GunaTextBox2.Text + "')"
                cmd.Parameters.AddWithValue("@chrgdate", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                cmd.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
    End Sub
    Private Sub six_batch()
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel51.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTimePicker1.Value.Date
                cb.Name = System.Text.RegularExpressions.Regex.Replace(cb.Name, "[^\d]", " ")
                podate = podate.AddDays(cb.Name)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into plnr(proname,strength,cndn,btn,pctyp,pccnt,chrgbox,chrgdate,ptn,sch,podate,instid,totalsampleqty,availsampleqty,addedby,addedon,remarks) values('" + ComboBox1.Text + "','" + GunaTextBox1.Text + "','" + ComboBox8.Text + "','" + TextBox1.Text + "','" + GunaComboBox1.Text + "','" + TextBox20.Text + "','" + TextBox21.Text + "',@chrgdate,'" + TextBox2.Text + "','" + cb.Text + "',@podate,'" + instid6 + "','" + TextBox19.Text + "','" + TextBox19.Text + "','" + homepage.Label1.Text + "',@addedon,'" + GunaTextBox2.Text + "')"
                cmd.Parameters.AddWithValue("@chrgdate", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                cmd.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        For Each cb As Guna.UI.WinForms.GunaCheckBox In Panel38.Controls.OfType(Of Guna.UI.WinForms.GunaCheckBox)()
            If cb.Checked = True Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim podate As Date = DateTimePicker1.Value.Date
                podate = podate.AddMonths(cb.Text)
                Dim cmd As New SqlCommand
                cmd.Parameters.Clear()
                cmd.Connection = con
                cmd.CommandText = "insert into plnr(proname,strength,cndn,btn,pctyp,pccnt,chrgbox,chrgdate,ptn,sch,podate,instid,totalsampleqty,availsampleqty,addedby,addedon,remarks) values('" + ComboBox1.Text + "','" + GunaTextBox1.Text + "','" + ComboBox8.Text + "','" + TextBox1.Text + "','" + GunaComboBox1.Text + "','" + TextBox20.Text + "','" + TextBox21.Text + "',@chrgdate,'" + TextBox2.Text + "','" + cb.Text + "M',@podate,'" + instid6 + "','" + TextBox19.Text + "','" + TextBox19.Text + "','" + homepage.Label1.Text + "',@addedon,'" + GunaTextBox2.Text + "')"
                cmd.Parameters.AddWithValue("@chrgdate", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@podate", SqlDbType.Date).Value = Convert.ToDateTime(podate)
                cmd.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "1" Then
            Panel7.Show()
            Panel8.Hide()
            Panel19.Hide()
            Panel25.Hide()
            Panel31.Hide()
            Panel37.Hide()
        ElseIf ComboBox2.Text = "2" Then
            Panel7.Show()
            Panel8.Show()
            Panel19.Hide()
            Panel25.Hide()
            Panel31.Hide()
            Panel37.Hide()
        ElseIf ComboBox2.Text = "3" Then
            Panel7.Show()
            Panel8.Show()
            Panel19.Show()
            Panel25.Hide()
            Panel31.Hide()
            Panel37.Hide()
        ElseIf ComboBox2.Text = "4" Then
            Panel7.Show()
            Panel8.Show()
            Panel19.Show()
            Panel25.Show()
            Panel31.Hide()
            Panel37.Hide()
        ElseIf ComboBox2.Text = "5" Then
            Panel7.Show()
            Panel8.Show()
            Panel19.Show()
            Panel25.Show()
            Panel31.Show()
            Panel37.Hide()
        ElseIf ComboBox2.Text = "6" Then
            Panel7.Show()
            Panel8.Show()
            Panel19.Show()
            Panel25.Show()
            Panel31.Show()
            Panel37.Show()
        End If
        loadcond()
    End Sub
    Private Sub loadcond()
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
            cmd.CommandText = "select cond from chamber"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox3.Items.Add(dr("cond"))
                ComboBox4.Items.Add(dr("cond"))
                ComboBox5.Items.Add(dr("cond"))
                ComboBox6.Items.Add(dr("cond"))
                ComboBox7.Items.Add(dr("cond"))
                ComboBox8.Items.Add(dr("cond"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        'If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = ".") AndAlso Not Char.IsControl(e.KeyChar) Then
        'e.Handled = True
        'End If
    End Sub
    Private Sub TextBox7_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        'If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = ".") AndAlso Not Char.IsControl(e.KeyChar) Then
        'e.Handled = True
        'End If
    End Sub
    Private Sub TextBox10_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        'If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = ".") AndAlso Not Char.IsControl(e.KeyChar) Then
        'e.Handled = True
        'End If
    End Sub
    Private Sub TextBox13_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        'If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = ".") AndAlso Not Char.IsControl(e.KeyChar) Then
        'e.Handled = True
        'End If
    End Sub
    Private Sub TextBox16_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox16.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        'If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = ".") AndAlso Not Char.IsControl(e.KeyChar) Then
        'e.Handled = True
        'End If
    End Sub
    Private Sub TextBox19_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox19.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        'If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = ".") AndAlso Not Char.IsControl(e.KeyChar) Then
        'e.Handled = True
        'End If
    End Sub
    Private Sub TextBox6_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox9_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox12_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox12.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox15_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox15.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox18_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox18.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox21_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox21.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        latestno1()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        latestno2()
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        latestno3()
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        latestno4()
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.SelectedIndexChanged
        latestno5()
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox8.SelectedIndexChanged
        latestno6()
    End Sub
    Dim instid1 As String
    Private Sub latestno1()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            cmd.Connection = con
            con.Open()
            cmd.CommandText = "select MAX(chrgbox) from plnr where cndn='" + ComboBox3.Text + "' and chrgbox IS NOT NULL"
            Label1.Text = cmd.ExecuteScalar().ToString()

            If Label1.Text = "" Then
                TextBox6.Text = 1
            Else
                TextBox6.Text = cmd.ExecuteScalar() + 1
            End If

            con.Close()

            'select instrument no.
            If con.State = ConnectionState.Open Then con.Close()
            cmd1.Connection = con
            con.Open()
            cmd1.CommandText = "select instid from chamber where cond='" + ComboBox3.Text + "'"
            instid1 = cmd1.ExecuteScalar().ToString()
            con.Close()
            Label7.Text = instid1
        Catch ex As Exception

        End Try
    End Sub
    Dim instid2 As String
    Private Sub latestno2()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            cmd.Connection = con
            con.Open()
            cmd.CommandText = "select MAX(chrgbox) from plnr where cndn='" + ComboBox4.Text + "' and chrgbox IS NOT NULL"
            Label2.Text = cmd.ExecuteScalar().ToString()

            If Label2.Text = "" Then
                TextBox9.Text = 1
            Else
                TextBox9.Text = cmd.ExecuteScalar() + 1
            End If
            con.Close()

            'select instrument no.
            If con.State = ConnectionState.Open Then con.Close()
            cmd1.Connection = con
            con.Open()
            cmd1.CommandText = "select instid from chamber where cond='" + ComboBox4.Text + "'"
            instid2 = cmd1.ExecuteScalar().ToString()
            con.Close()
            Label8.Text = instid2
        Catch ex As Exception

        End Try
    End Sub
    Dim instid3 As String
    Private Sub latestno3()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            cmd.Connection = con
            con.Open()
            cmd.CommandText = "select MAX(chrgbox) from plnr where cndn='" + ComboBox5.Text + "' and chrgbox IS NOT NULL"
            Label3.Text = cmd.ExecuteScalar().ToString()
            If Label3.Text = "" Then
                TextBox12.Text = 1
            Else
                TextBox12.Text = cmd.ExecuteScalar() + 1
            End If
            con.Close()

            'select instrument no.
            If con.State = ConnectionState.Open Then con.Close()
            cmd1.Connection = con
            con.Open()
            cmd1.CommandText = "select instid from chamber where cond='" + ComboBox5.Text + "'"
            instid3 = cmd1.ExecuteScalar().ToString()
            con.Close()
            Label9.Text = instid3
        Catch ex As Exception

        End Try
    End Sub
    Dim instid4 As String
    Private Sub latestno4()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            cmd.Connection = con
            con.Open()
            cmd.CommandText = "select MAX(chrgbox) from plnr where cndn='" + ComboBox6.Text + "' and chrgbox IS NOT NULL"
            Label4.Text = cmd.ExecuteScalar().ToString()
            If Label4.Text = "" Then
                TextBox15.Text = 1
            Else
                TextBox15.Text = cmd.ExecuteScalar() + 1
            End If
            con.Close()

            'select instrument no.
            If con.State = ConnectionState.Open Then con.Close()
            cmd1.Connection = con
            con.Open()
            cmd1.CommandText = "select instid from chamber where cond='" + ComboBox6.Text + "'"
            instid4 = cmd1.ExecuteScalar().ToString()
            con.Close()
            Label10.Text = instid4
        Catch ex As Exception

        End Try
    End Sub
    Dim instid5 As String
    Private Sub latestno5()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            cmd.Connection = con
            con.Open()
            cmd.CommandText = "select MAX(chrgbox) from plnr where cndn='" + ComboBox7.Text + "' and chrgbox IS NOT NULL"
            Label5.Text = cmd.ExecuteScalar().ToString()
            If Label5.Text = "" Then
                TextBox18.Text = 1
            Else
                TextBox18.Text = cmd.ExecuteScalar() + 1
            End If
            con.Close()

            'select instrument no.
            If con.State = ConnectionState.Open Then con.Close()
            cmd1.Connection = con
            con.Open()
            cmd1.CommandText = "select instid from chamber where cond='" + ComboBox7.Text + "'"
            instid5 = cmd1.ExecuteScalar().ToString()
            con.Close()
            Label11.Text = instid5
        Catch ex As Exception

        End Try
    End Sub
    Dim instid6 As String
    Private Sub latestno6()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            cmd.Connection = con
            con.Open()
            cmd.CommandText = "select MAX(chrgbox) from plnr where cndn='" + ComboBox8.Text + "' and chrgbox IS NOT NULL"
            Label6.Text = cmd.ExecuteScalar().ToString()
            If Label6.Text = "" Then
                TextBox21.Text = 1
            Else
                TextBox21.Text = cmd.ExecuteScalar() + 1
            End If
            con.Close()

            'select instrument no.
            If con.State = ConnectionState.Open Then con.Close()
            cmd1.Connection = con
            con.Open()
            cmd1.CommandText = "select instid from chamber where cond='" + ComboBox8.Text + "'"
            instid6 = cmd1.ExecuteScalar().ToString()
            con.Close()
            Label12.Text = instid6
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If homepage.Label2.Text = "GL" Then
        Else

            DateTimePicker1.MinDate = DateTime.Now.AddDays(-1)
            DateTimePicker1.MaxDate = DateTime.Now.AddDays(1)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox2.Text = "SP/" + TextBox1.Text
    End Sub
    Private Sub Guna2TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Guna2TextBox1.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "N" Or e.KeyChar = "n" Or e.KeyChar = "A" Or e.KeyChar = "a")
        End If

    End Sub
    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged
        Try
            If Guna2TextBox1.Text = "" Then
                ComboBox1.Items.Clear()
                GunaTextBox1.Clear()
                TextBox1.Clear()
            ElseIf Guna2TextBox1.Text = "NA" Or Guna2TextBox1.Text = "na" Then
                ComboBox1.Items.Clear()
                GunaTextBox1.Clear()
                TextBox1.Clear()
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT DISTINCT(proname) FROM productmaster where productstatus='Active'"
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    ComboBox1.Items.Add(dr("proname"))
                End While
                dr.Close()
                con.Close()
            Else
                ComboBox1.Items.Clear()
                GunaTextBox1.Clear()
                TextBox1.Clear()
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "SELECT proname FROM productmaster where procode='" + Guna2TextBox1.Text + "' and productstatus='Active'"
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    ComboBox1.Items.Add(dr("proname"))
                End While
                dr.Close()
                con.Close()
                TextBox1.Text = "V" + Guna2TextBox1.Text

            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            If Guna2TextBox1.Text = "" Or Guna2TextBox1.Text = "NA" Or Guna2TextBox1.Text = "na" Then
                GunaTextBox1.Text = ""
            Else
                If con.State = ConnectionState.Open Then con.Close()
                con.Open()
                Dim qry As String
                qry = "SELECT strength FROM productmaster where procode='" + Guna2TextBox1.Text + "' and proname='" + ComboBox1.Text + "' and productstatus='Active'"
                cmd = New SqlCommand(qry, con)
                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim table As New DataTable()
                da.Fill(table)

                GunaTextBox1.Text = table.Rows(0)(0).ToString()
            End If

        Catch ex As Exception

        End Try
    End Sub


End Class