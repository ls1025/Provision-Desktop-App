Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class exportdata
    Private Sub exportdata_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadProductName()


    End Sub
    Private Sub LoadProductName()
        Try
            ComboBox1.Items.Clear()

            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(productname) from trdev union select DISTINCT(productname) from trrot union select DISTINCT(productname) from trstb order by [productname] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("productname"))
            End While
            dr.Close()
            con.Close()

            For Row As Int16 = 0 To ComboBox1.Items.Count - 2
                For RowAgain As Int16 = ComboBox1.Items.Count - 1 To Row + 1 Step -1
                    If ComboBox1.Items(Row).ToString = ComboBox1.Items(RowAgain).ToString Then
                        ComboBox1.Items.RemoveAt(RowAgain)
                    End If
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadBatchNo()
        Try
            ComboBox2.Items.Clear()

            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(btn) from trdev where productname='" + ComboBox1.Text + "' union select DISTINCT(btn) from trrot where productname='" + ComboBox1.Text + "' union select DISTINCT(btn) from trstb where productname='" + ComboBox1.Text + "' order by [btn] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr("btn"))
            End While
            dr.Close()
            con.Close()

            For Row As Int16 = 0 To ComboBox2.Items.Count - 2
                For RowAgain As Int16 = ComboBox2.Items.Count - 1 To Row + 1 Step -1
                    If ComboBox2.Items(Row).ToString = ComboBox2.Items(RowAgain).ToString Then
                        ComboBox2.Items.RemoveAt(RowAgain)
                    End If
                Next
            Next
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
    Private Sub ComboBox2_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.DropDown
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
    Private Sub ComboBox3_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.DropDown
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
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If GunaRadioButton1.Checked = False And GunaRadioButton2.Checked = False And GunaRadioButton3.Checked = False Then
            MsgBox("Select whether intimation type is Development or Routine or Stability", vbCritical)
        ElseIf GunaRadioButton1.Checked = True Then
            '1
            If ComboBox1.Text = "" And ComboBox2.Text = "" And ComboBox3.Text = "" Then

                '2
            ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" And ComboBox3.Text <> "" Then
                If ComboBox3.Text = "Pending" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trdev where productname='" + ComboBox1.Text + "' and btn='" + ComboBox2.Text + "' and [Status]<>'Cancelled' and [Status]<>'Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Cancelled" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trdev where productname='" + ComboBox1.Text + "' and btn='" + ComboBox2.Text + "' and [Status]='Cancelled' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Data Uploaded" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trdev where productname='" + ComboBox1.Text + "' and btn='" + ComboBox2.Text + "' and [Status]='Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                End If
                '3
            ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" And ComboBox3.Text <> "" Then
                If ComboBox3.Text = "Pending" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trdev where btn='" + ComboBox2.Text + "' and [Status]<>'Cancelled' and [Status]<>'Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Cancelled" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trdev where btn='" + ComboBox2.Text + "' and [Status]='Cancelled' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Data Uploaded" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trdev where btn='" + ComboBox2.Text + "' and [Status]='Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                End If
                '4
            ElseIf ComboBox1.Text <> "" And ComboBox2.Text = "" And ComboBox3.Text <> "" Then
                If ComboBox3.Text = "Pending" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trdev where productname='" + ComboBox1.Text + "' and [Status]<>'Cancelled' and [Status]<>'Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Cancelled" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trdev where productname='" + ComboBox1.Text + "' and [Status]='Cancelled' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Data Uploaded" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trdev where productname='" + ComboBox1.Text + "' and [Status]='Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                End If
                '5
            ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" And ComboBox3.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select *  from trdev where productname='" + ComboBox1.Text + "' and btn='" + ComboBox2.Text + "' order by productname ASC", con)
                Dim da As New SqlDataAdapter(cmd)
                da.SelectCommand = cmd
                Dim dt As New DataTable
                da.Fill(dt)
                With Me.ReportViewer1.LocalReport
                    .DataSources.Clear()
                    .ReportPath = "D:\Provision Report\Report1.rdlc"
                    For i = 0 To dt.Rows.Count - 1
                        .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                    Next
                End With
                Me.ReportViewer1.RefreshReport()
                '6
            ElseIf ComboBox1.Text <> "" And ComboBox2.Text = "" And ComboBox3.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select *  from trdev where productname='" + ComboBox1.Text + "' order by productname ASC", con)
                Dim da As New SqlDataAdapter(cmd)
                da.SelectCommand = cmd
                Dim dt As New DataTable
                da.Fill(dt)
                With Me.ReportViewer1.LocalReport
                    .DataSources.Clear()
                    .ReportPath = "D:\Provision Report\Report1.rdlc"
                    For i = 0 To dt.Rows.Count - 1
                        .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                    Next
                End With
                Me.ReportViewer1.RefreshReport()
                '7
            ElseIf ComboBox1.Text = "" And ComboBox2.Text = "" And ComboBox3.Text <> "" Then
                If ComboBox3.Text = "Pending" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trdev where [Status]<>'Cancelled' and [Status]<>'Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Cancelled" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trdev where [Status]='Cancelled' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Data Uploaded" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trdev where [Status]='Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                End If
                '8
            ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" And ComboBox3.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select *  from trdev where btn='" + ComboBox2.Text + "' order by productname ASC", con)
                Dim da As New SqlDataAdapter(cmd)
                da.SelectCommand = cmd
                Dim dt As New DataTable
                da.Fill(dt)
                With Me.ReportViewer1.LocalReport
                    .DataSources.Clear()
                    .ReportPath = "D:\Provision Report\Report1.rdlc"
                    For i = 0 To dt.Rows.Count - 1
                        .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                    Next
                End With
                Me.ReportViewer1.RefreshReport()
            End If



        ElseIf GunaRadioButton2.Checked = True Then
            If ComboBox1.Text = "" And ComboBox2.Text = "" And ComboBox3.Text = "" Then

                '2
            ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" And ComboBox3.Text <> "" Then
                If ComboBox3.Text = "Pending" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trrot where productname='" + ComboBox1.Text + "' and btn='" + ComboBox2.Text + "' and [Status]<>'Cancelled' and [Status]<>'Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Cancelled" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trrot where productname='" + ComboBox1.Text + "' and btn='" + ComboBox2.Text + "' and [Status]='Cancelled' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Data Uploaded" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trrot where productname='" + ComboBox1.Text + "' and btn='" + ComboBox2.Text + "' and [Status]='Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                End If
                '3
            ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" And ComboBox3.Text <> "" Then
                If ComboBox3.Text = "Pending" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trrot where btn='" + ComboBox2.Text + "' and [Status]<>'Cancelled' and [Status]<>'Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Cancelled" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trrot where btn='" + ComboBox2.Text + "' and [Status]='Cancelled' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Data Uploaded" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trrot where btn='" + ComboBox2.Text + "' and [Status]='Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                End If
                '4
            ElseIf ComboBox1.Text <> "" And ComboBox2.Text = "" And ComboBox3.Text <> "" Then
                If ComboBox3.Text = "Pending" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trrot where productname='" + ComboBox1.Text + "' and [Status]<>'Cancelled' and [Status]<>'Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Cancelled" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trrot where productname='" + ComboBox1.Text + "' and [Status]='Cancelled' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Data Uploaded" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trrot where productname='" + ComboBox1.Text + "' and [Status]='Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                End If
                '5
            ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" And ComboBox3.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select *  from trrot where productname='" + ComboBox1.Text + "' and btn='" + ComboBox2.Text + "' order by productname ASC", con)
                Dim da As New SqlDataAdapter(cmd)
                da.SelectCommand = cmd
                Dim dt As New DataTable
                da.Fill(dt)
                With Me.ReportViewer1.LocalReport
                    .DataSources.Clear()
                    .ReportPath = "D:\Provision Report\Report1.rdlc"
                    For i = 0 To dt.Rows.Count - 1
                        .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                    Next
                End With
                Me.ReportViewer1.RefreshReport()
                '6
            ElseIf ComboBox1.Text <> "" And ComboBox2.Text = "" And ComboBox3.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select *  from trrot where productname='" + ComboBox1.Text + "' order by productname ASC", con)
                Dim da As New SqlDataAdapter(cmd)
                da.SelectCommand = cmd
                Dim dt As New DataTable
                da.Fill(dt)
                With Me.ReportViewer1.LocalReport
                    .DataSources.Clear()
                    .ReportPath = "D:\Provision Report\Report1.rdlc"
                    For i = 0 To dt.Rows.Count - 1
                        .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                    Next
                End With
                Me.ReportViewer1.RefreshReport()
                '7
            ElseIf ComboBox1.Text = "" And ComboBox2.Text = "" And ComboBox3.Text <> "" Then
                If ComboBox3.Text = "Pending" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trrot where [Status]<>'Cancelled' and [Status]<>'Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Cancelled" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trrot where [Status]='Cancelled' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Data Uploaded" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trrot where [Status]='Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                End If
                '8
            ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" And ComboBox3.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select *  from trrot where btn='" + ComboBox2.Text + "' order by productname ASC", con)
                Dim da As New SqlDataAdapter(cmd)
                da.SelectCommand = cmd
                Dim dt As New DataTable
                da.Fill(dt)
                With Me.ReportViewer1.LocalReport
                    .DataSources.Clear()
                    .ReportPath = "D:\Provision Report\Report1.rdlc"
                    For i = 0 To dt.Rows.Count - 1
                        .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                    Next
                End With
                Me.ReportViewer1.RefreshReport()
            End If



        ElseIf GunaRadioButton3.Checked = True Then
            If ComboBox1.Text = "" And ComboBox2.Text = "" And ComboBox3.Text = "" Then

                '2
            ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" And ComboBox3.Text <> "" Then
                If ComboBox3.Text = "Pending" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trstb where productname='" + ComboBox1.Text + "' and btn='" + ComboBox2.Text + "' and [Status]<>'Cancelled' and [Status]<>'Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Cancelled" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trstb where productname='" + ComboBox1.Text + "' and btn='" + ComboBox2.Text + "' and [Status]='Cancelled' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Data Uploaded" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trstb where productname='" + ComboBox1.Text + "' and btn='" + ComboBox2.Text + "' and [Status]='Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                End If
                '3
            ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" And ComboBox3.Text <> "" Then
                If ComboBox3.Text = "Pending" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trstb where btn='" + ComboBox2.Text + "' and [Status]<>'Cancelled' and [Status]<>'Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Cancelled" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trstb where btn='" + ComboBox2.Text + "' and [Status]='Cancelled' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Data Uploaded" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trstb where btn='" + ComboBox2.Text + "' and [Status]='Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                End If
                '4
            ElseIf ComboBox1.Text <> "" And ComboBox2.Text = "" And ComboBox3.Text <> "" Then
                If ComboBox3.Text = "Pending" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trstb where productname='" + ComboBox1.Text + "' and [Status]<>'Cancelled' and [Status]<>'Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Cancelled" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trstb where productname='" + ComboBox1.Text + "' and [Status]='Cancelled' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Data Uploaded" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trstb where productname='" + ComboBox1.Text + "' and [Status]='Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                End If
                '5
            ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" And ComboBox3.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select *  from trstb where productname='" + ComboBox1.Text + "' and btn='" + ComboBox2.Text + "' order by productname ASC", con)
                Dim da As New SqlDataAdapter(cmd)
                da.SelectCommand = cmd
                Dim dt As New DataTable
                da.Fill(dt)
                With Me.ReportViewer1.LocalReport
                    .DataSources.Clear()
                    .ReportPath = "D:\Provision Report\Report1.rdlc"
                    For i = 0 To dt.Rows.Count - 1
                        .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                    Next
                End With
                Me.ReportViewer1.RefreshReport()
                '6
            ElseIf ComboBox1.Text <> "" And ComboBox2.Text = "" And ComboBox3.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select *  from trstb where productname='" + ComboBox1.Text + "' order by productname ASC", con)
                Dim da As New SqlDataAdapter(cmd)
                da.SelectCommand = cmd
                Dim dt As New DataTable
                da.Fill(dt)
                With Me.ReportViewer1.LocalReport
                    .DataSources.Clear()
                    .ReportPath = "D:\Provision Report\Report1.rdlc"
                    For i = 0 To dt.Rows.Count - 1
                        .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                    Next
                End With
                Me.ReportViewer1.RefreshReport()
                '7
            ElseIf ComboBox1.Text = "" And ComboBox2.Text = "" And ComboBox3.Text <> "" Then
                If ComboBox3.Text = "Pending" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trstb where [Status]<>'Cancelled' and [Status]<>'Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Cancelled" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trstb where [Status]='Cancelled' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                ElseIf ComboBox3.Text = "Data Uploaded" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("select *  from trstb where [Status]='Data Uploaded' order by productname ASC", con)
                    Dim da As New SqlDataAdapter(cmd)
                    da.SelectCommand = cmd
                    Dim dt As New DataTable
                    da.Fill(dt)
                    With Me.ReportViewer1.LocalReport
                        .DataSources.Clear()
                        .ReportPath = "D:\Provision Report\Report1.rdlc"
                        For i = 0 To dt.Rows.Count - 1
                            .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                        Next
                    End With
                    Me.ReportViewer1.RefreshReport()
                End If
                '8
            ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" And ComboBox3.Text = "" Then
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("select *  from trstb where btn='" + ComboBox2.Text + "' order by productname ASC", con)
                Dim da As New SqlDataAdapter(cmd)
                da.SelectCommand = cmd
                Dim dt As New DataTable
                da.Fill(dt)
                With Me.ReportViewer1.LocalReport
                    .DataSources.Clear()
                    .ReportPath = "D:\Provision Report\Report1.rdlc"
                    For i = 0 To dt.Rows.Count - 1
                        .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                    Next
                End With
                Me.ReportViewer1.RefreshReport()
            End If
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        LoadBatchNo()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        ' String exportOption = "Excel"
        ' String exportOption = "Word"

        Dim exportOption As String = "Word"
        Dim extension As RenderingExtension = ReportViewer1.LocalReport.ListRenderingExtensions().ToList().Find(Function(x) x.Name.Equals(exportOption, StringComparison.CurrentCultureIgnoreCase))
        If extension IsNot Nothing Then
            Dim fieldInfo As System.Reflection.FieldInfo = extension.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
            fieldInfo.SetValue(extension, False)
        End If

    End Sub
End Class