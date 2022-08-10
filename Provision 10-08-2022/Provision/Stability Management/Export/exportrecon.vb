Imports System.Data.SqlClient
Public Class exportrecon


    Private Sub export_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadProductName()
        LoadConditions()
    End Sub
    Private Sub LoadProductName()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(proname) from plnr order by [proname] ASC"
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

    Private Sub LoadConditions()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(cndn) from plnr order by [cndn] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox3.Items.Add(dr("cndn"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadBatchNumber()
        Try
            ComboBox2.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(btn) from plnr where proname='" + ComboBox1.Text + "'"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr("btn"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If ComboBox1.Text = "" And ComboBox2.Text = "" And ComboBox3.Text = "" Then
            If con.State = ConnectionState.Open Then con.Close()
            '  ' da = New SqlDataAdapter("SELECT plnr.proname,plnr.strength,plnr.btn,plnr.ptn,plnr.cndn,plnr.chrgdate,plnr.sch,recon.remark FROM plnr INNER JOIN recon on plnr.ID=recon.ref_id  WHERE plnr.actpodate IS NULL and plnr.ID IN  (SELECT Ref_id FROM recon ) order by [proname] ASC", con)
            Dim cmd As New SqlCommand("SELECT plnr.proname, plnr.strength, plnr.cndn, plnr.btn, plnr.pctyp, plnr.pccnt, plnr.chrgdate, plnr.ptn, plnr.sch, plnr.podate, plnr.totalsampleqty, plnr.availsampleqty, recon.ref_id, recon.sampleqty, recon.reftr, recon.remark, recon.issuedby,recon.issuedon FROM plnr INNER JOIN recon ON plnr.ID=recon.ref_id where plnr.ID IN (SELECT Ref_id FROM recon ) order by plnr.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report4.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()

        ElseIf ComboBox1.Text <> "" And ComboBox2.Text = "" And ComboBox3.Text = "" Then
            If con.State = ConnectionState.Open Then con.Close()
            '  ' da = New SqlDataAdapter("SELECT plnr.proname,plnr.strength,plnr.btn,plnr.ptn,plnr.cndn,plnr.chrgdate,plnr.sch,recon.remark FROM plnr INNER JOIN recon on plnr.ID=recon.ref_id  WHERE plnr.actpodate IS NULL and plnr.ID IN  (SELECT Ref_id FROM recon ) order by [proname] ASC", con)
            Dim cmd As New SqlCommand("SELECT plnr.proname, plnr.strength, plnr.cndn, plnr.btn, plnr.pctyp, plnr.pccnt, plnr.chrgdate, plnr.ptn, plnr.sch, plnr.podate, plnr.totalsampleqty, plnr.availsampleqty, recon.ref_id, recon.sampleqty, recon.reftr, recon.remark, recon.issuedby,recon.issuedon FROM plnr INNER JOIN recon ON plnr.ID=recon.ref_id where plnr.ID IN (SELECT Ref_id FROM recon ) and plnr.proname='" + ComboBox1.Text + "' order by plnr.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report4.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()

        ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" And ComboBox3.Text = "" Then
            If con.State = ConnectionState.Open Then con.Close()
            '  ' da = New SqlDataAdapter("SELECT plnr.proname,plnr.strength,plnr.btn,plnr.ptn,plnr.cndn,plnr.chrgdate,plnr.sch,recon.remark FROM plnr INNER JOIN recon on plnr.ID=recon.ref_id  WHERE plnr.actpodate IS NULL and plnr.ID IN  (SELECT Ref_id FROM recon ) order by [proname] ASC", con)
            Dim cmd As New SqlCommand("SELECT plnr.proname, plnr.strength, plnr.cndn, plnr.btn, plnr.pctyp, plnr.pccnt, plnr.chrgdate, plnr.ptn, plnr.sch, plnr.podate, plnr.totalsampleqty, plnr.availsampleqty, recon.ref_id, recon.sampleqty, recon.reftr, recon.remark, recon.issuedby,recon.issuedon FROM plnr INNER JOIN recon ON plnr.ID=recon.ref_id where plnr.ID IN (SELECT Ref_id FROM recon ) and plnr.btn='" + ComboBox2.Text + "' order by plnr.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report4.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()

        ElseIf ComboBox1.Text = "" And ComboBox2.Text = "" And ComboBox3.Text <> "" Then
            If con.State = ConnectionState.Open Then con.Close()
            '  ' da = New SqlDataAdapter("SELECT plnr.proname,plnr.strength,plnr.btn,plnr.ptn,plnr.cndn,plnr.chrgdate,plnr.sch,recon.remark FROM plnr INNER JOIN recon on plnr.ID=recon.ref_id  WHERE plnr.actpodate IS NULL and plnr.ID IN  (SELECT Ref_id FROM recon ) order by [proname] ASC", con)
            Dim cmd As New SqlCommand("SELECT plnr.proname, plnr.strength, plnr.cndn, plnr.btn, plnr.pctyp, plnr.pccnt, plnr.chrgdate, plnr.ptn, plnr.sch, plnr.podate, plnr.totalsampleqty, plnr.availsampleqty, recon.ref_id, recon.sampleqty, recon.reftr, recon.remark, recon.issuedby,recon.issuedon FROM plnr INNER JOIN recon ON plnr.ID=recon.ref_id where plnr.ID IN (SELECT Ref_id FROM recon ) and plnr.cndn='" + ComboBox3.Text + "' order by plnr.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report4.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()

        ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" And ComboBox3.Text <> "" Then
            If con.State = ConnectionState.Open Then con.Close()
            '  ' da = New SqlDataAdapter("SELECT plnr.proname,plnr.strength,plnr.btn,plnr.ptn,plnr.cndn,plnr.chrgdate,plnr.sch,recon.remark FROM plnr INNER JOIN recon on plnr.ID=recon.ref_id  WHERE plnr.actpodate IS NULL and plnr.ID IN  (SELECT Ref_id FROM recon ) order by [proname] ASC", con)
            Dim cmd As New SqlCommand("SELECT plnr.proname, plnr.strength, plnr.cndn, plnr.btn, plnr.pctyp, plnr.pccnt, plnr.chrgdate, plnr.ptn, plnr.sch, plnr.podate, plnr.totalsampleqty, plnr.availsampleqty, recon.ref_id, recon.sampleqty, recon.reftr, recon.remark, recon.issuedby,recon.issuedon FROM plnr INNER JOIN recon ON plnr.ID=recon.ref_id where plnr.ID IN (SELECT Ref_id FROM recon ) and plnr.btn='" + ComboBox2.Text + "' and plnr.cndn='" + ComboBox3.Text + "' order by plnr.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report4.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()

        ElseIf ComboBox1.Text <> "" And ComboBox2.Text = "" And ComboBox3.Text <> "" Then
            If con.State = ConnectionState.Open Then con.Close()
            '  ' da = New SqlDataAdapter("SELECT plnr.proname,plnr.strength,plnr.btn,plnr.ptn,plnr.cndn,plnr.chrgdate,plnr.sch,recon.remark FROM plnr INNER JOIN recon on plnr.ID=recon.ref_id  WHERE plnr.actpodate IS NULL and plnr.ID IN  (SELECT Ref_id FROM recon ) order by [proname] ASC", con)
            Dim cmd As New SqlCommand("SELECT plnr.proname, plnr.strength, plnr.cndn, plnr.btn, plnr.pctyp, plnr.pccnt, plnr.chrgdate, plnr.ptn, plnr.sch, plnr.podate, plnr.totalsampleqty, plnr.availsampleqty, recon.ref_id, recon.sampleqty, recon.reftr, recon.remark, recon.issuedby,recon.issuedon FROM plnr INNER JOIN recon ON plnr.ID=recon.ref_id where plnr.ID IN (SELECT Ref_id FROM recon ) and plnr.proname='" + ComboBox1.Text + "' and plnr.cndn='" + ComboBox3.Text + "' order by plnr.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report4.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()

        ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" And ComboBox3.Text = "" Then
            If con.State = ConnectionState.Open Then con.Close()
            '  ' da = New SqlDataAdapter("SELECT plnr.proname,plnr.strength,plnr.btn,plnr.ptn,plnr.cndn,plnr.chrgdate,plnr.sch,recon.remark FROM plnr INNER JOIN recon on plnr.ID=recon.ref_id  WHERE plnr.actpodate IS NULL and plnr.ID IN  (SELECT Ref_id FROM recon ) order by [proname] ASC", con)
            Dim cmd As New SqlCommand("SELECT plnr.proname, plnr.strength, plnr.cndn, plnr.btn, plnr.pctyp, plnr.pccnt, plnr.chrgdate, plnr.ptn, plnr.sch, plnr.podate, plnr.totalsampleqty, plnr.availsampleqty, recon.ref_id, recon.sampleqty, recon.reftr, recon.remark, recon.issuedby,recon.issuedon FROM plnr INNER JOIN recon ON plnr.ID=recon.ref_id where plnr.ID IN (SELECT Ref_id FROM recon ) and plnr.proname='" + ComboBox1.Text + "' and plnr.btn='" + ComboBox2.Text + "' order by plnr.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report4.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()

        ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" And ComboBox3.Text <> "" Then
            If con.State = ConnectionState.Open Then con.Close()
            '  ' da = New SqlDataAdapter("SELECT plnr.proname,plnr.strength,plnr.btn,plnr.ptn,plnr.cndn,plnr.chrgdate,plnr.sch,recon.remark FROM plnr INNER JOIN recon on plnr.ID=recon.ref_id  WHERE plnr.actpodate IS NULL and plnr.ID IN  (SELECT Ref_id FROM recon ) order by [proname] ASC", con)
            Dim cmd As New SqlCommand("SELECT plnr.proname, plnr.strength, plnr.cndn, plnr.btn, plnr.pctyp, plnr.pccnt, plnr.chrgdate, plnr.ptn, plnr.sch, plnr.podate, plnr.totalsampleqty, plnr.availsampleqty, recon.ref_id, recon.sampleqty, recon.reftr, recon.remark, recon.issuedby,recon.issuedon FROM plnr INNER JOIN recon ON plnr.ID=recon.ref_id where plnr.ID IN (SELECT Ref_id FROM recon ) and plnr.proname='" + ComboBox1.Text + "' and plnr.btn='" + ComboBox2.Text + "' and plnr.cndn='" + ComboBox3.Text + "' order by plnr.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report4.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()
        End If

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
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        LoadBatchNumber()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
    End Sub

End Class