Imports System.Data.SqlClient
Public Class exportrldrecon


    Private Sub export_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductName()
        LoadBatchNumber()
        LoadManufacturer()
    End Sub
    Private Sub LoadProductName()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(proname) from rld_master order by [proname] ASC"
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
    Private Sub LoadBatchNumber()
        Try
            ComboBox2.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(btn) from rld_master order by [btn] ASC"
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
    Private Sub LoadBatchNumberProname()
        Try
            ComboBox2.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(btn) from rld_master where proname='" + ComboBox1.Text + "' order by [btn] ASC"
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
    Private Sub LoadManufacturer()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(manfact) from rld_master order by manfact ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox3.Items.Add(dr("manfact"))
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
            Dim cmd As New SqlCommand("SELECT rld_master.proname, rld_master.strength, rld_master.brand, rld_master.cntry, rld_master.manfact, rld_master.btn, rld_master.packstyle, rld_master.receiptdate, rld_master.expdate, rld_master.receivedqty, 
                  rld_master.recformat, rld_master.balanceqty, rld_master.rldaddedby, rld_master.rldaddeddate, rld_recon.sampleqty, rld_recon.test, rld_recon.remark, rld_recon.issuedby, rld_recon.issuedon,rld_recon.issuedto
FROM     rld_master INNER JOIN
                  rld_recon ON rld_master.id = rld_recon.ref_id
WHERE  (rld_master.id IN
                      (SELECT ref_id
                       FROM      rld_recon AS rld_recon_1)) order by rld_master.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report2.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()

        ElseIf ComboBox1.Text <> "" And ComboBox2.Text = "" And ComboBox3.Text = "" Then
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("SELECT rld_master.proname, rld_master.strength, rld_master.brand, rld_master.cntry, rld_master.manfact, rld_master.btn, rld_master.packstyle, rld_master.receiptdate, rld_master.expdate, rld_master.receivedqty, 
                  rld_master.recformat, rld_master.balanceqty, rld_master.rldaddedby, rld_master.rldaddeddate, rld_recon.sampleqty, rld_recon.test, rld_recon.remark, rld_recon.issuedby, rld_recon.issuedon,rld_recon.issuedto
FROM     rld_master INNER JOIN
                  rld_recon ON rld_master.id = rld_recon.ref_id
WHERE  (rld_master.id IN
                      (SELECT ref_id
                       FROM      rld_recon AS rld_recon_1)) and rld_master.proname='" + ComboBox1.Text + "' order by rld_master.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report2.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()


        ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" And ComboBox3.Text = "" Then
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("SELECT rld_master.proname, rld_master.strength, rld_master.brand, rld_master.cntry, rld_master.manfact, rld_master.btn, rld_master.packstyle, rld_master.receiptdate, rld_master.expdate, rld_master.receivedqty, 
                  rld_master.recformat, rld_master.balanceqty, rld_master.rldaddedby, rld_master.rldaddeddate, rld_recon.sampleqty, rld_recon.test, rld_recon.remark, rld_recon.issuedby, rld_recon.issuedon,rld_recon.issuedto
FROM     rld_master INNER JOIN
                  rld_recon ON rld_master.id = rld_recon.ref_id
WHERE  (rld_master.id IN
                      (SELECT ref_id
                       FROM      rld_recon AS rld_recon_1)) and rld_master.btn='" + ComboBox2.Text + "' order by rld_master.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report2.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()

        ElseIf ComboBox1.Text = "" And ComboBox2.Text = "" And ComboBox3.Text <> "" Then
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("SELECT rld_master.proname, rld_master.strength, rld_master.brand, rld_master.cntry, rld_master.manfact, rld_master.btn, rld_master.packstyle, rld_master.receiptdate, rld_master.expdate, rld_master.receivedqty, 
                  rld_master.recformat, rld_master.balanceqty, rld_master.rldaddedby, rld_master.rldaddeddate, rld_recon.sampleqty, rld_recon.test, rld_recon.remark, rld_recon.issuedby, rld_recon.issuedon,rld_recon.issuedto
FROM     rld_master INNER JOIN
                  rld_recon ON rld_master.id = rld_recon.ref_id
WHERE  (rld_master.id IN
                      (SELECT ref_id
                       FROM      rld_recon AS rld_recon_1)) and rld_master.manfact='" + ComboBox3.Text + "' order by rld_master.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report2.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()

        ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" And ComboBox3.Text <> "" Then
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("SELECT rld_master.proname, rld_master.strength, rld_master.brand, rld_master.cntry, rld_master.manfact, rld_master.btn, rld_master.packstyle, rld_master.receiptdate, rld_master.expdate, rld_master.receivedqty, 
                  rld_master.recformat, rld_master.balanceqty, rld_master.rldaddedby, rld_master.rldaddeddate, rld_recon.sampleqty, rld_recon.test, rld_recon.remark, rld_recon.issuedby, rld_recon.issuedon,rld_recon.issuedto
FROM     rld_master INNER JOIN
                  rld_recon ON rld_master.id = rld_recon.ref_id
WHERE  (rld_master.id IN
                      (SELECT ref_id
                       FROM      rld_recon AS rld_recon_1)) and rld_master.btn='" + ComboBox2.Text + "' and rld_master.manfact='" + ComboBox3.Text + "' order by rld_master.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report2.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()

        ElseIf ComboBox1.Text <> "" And ComboBox2.Text = "" And ComboBox3.Text <> "" Then
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("SELECT rld_master.proname, rld_master.strength, rld_master.brand, rld_master.cntry, rld_master.manfact, rld_master.btn, rld_master.packstyle, rld_master.receiptdate, rld_master.expdate, rld_master.receivedqty, 
                  rld_master.recformat, rld_master.balanceqty, rld_master.rldaddedby, rld_master.rldaddeddate, rld_recon.sampleqty, rld_recon.test, rld_recon.remark, rld_recon.issuedby, rld_recon.issuedon,rld_recon.issuedto
FROM     rld_master INNER JOIN
                  rld_recon ON rld_master.id = rld_recon.ref_id
WHERE  (rld_master.id IN
                      (SELECT ref_id
                       FROM      rld_recon AS rld_recon_1)) and rld_master.proname='" + ComboBox1.Text + "' and rld_master.manfact='" + ComboBox3.Text + "' order by rld_master.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report2.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()

        ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" And ComboBox3.Text = "" Then
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("SELECT rld_master.proname, rld_master.strength, rld_master.brand, rld_master.cntry, rld_master.manfact, rld_master.btn, rld_master.packstyle, rld_master.receiptdate, rld_master.expdate, rld_master.receivedqty, 
                  rld_master.recformat, rld_master.balanceqty, rld_master.rldaddedby, rld_master.rldaddeddate, rld_recon.sampleqty, rld_recon.test, rld_recon.remark, rld_recon.issuedby, rld_recon.issuedon,rld_recon.issuedto
FROM     rld_master INNER JOIN
                  rld_recon ON rld_master.id = rld_recon.ref_id
WHERE  (rld_master.id IN
                      (SELECT ref_id
                       FROM      rld_recon AS rld_recon_1)) and rld_master.proname='" + ComboBox1.Text + "' and rld_master.btn='" + ComboBox2.Text + "' order by rld_master.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report2.rdlc"
                For i = 0 To dt.Rows.Count - 1
                    .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
                Next

            End With
            Me.ReportViewer1.RefreshReport()

        ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" And ComboBox3.Text <> "" Then
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("SELECT rld_master.proname, rld_master.strength, rld_master.brand, rld_master.cntry, rld_master.manfact, rld_master.btn, rld_master.packstyle, rld_master.receiptdate, rld_master.expdate, rld_master.receivedqty, 
                  rld_master.recformat, rld_master.balanceqty, rld_master.rldaddedby, rld_master.rldaddeddate, rld_recon.sampleqty, rld_recon.test, rld_recon.remark, rld_recon.issuedby, rld_recon.issuedon,rld_recon.issuedto
FROM     rld_master INNER JOIN
                  rld_recon ON rld_master.id = rld_recon.ref_id
WHERE  (rld_master.id IN
                      (SELECT ref_id
                       FROM      rld_recon AS rld_recon_1)) and rld_master.proname='" + ComboBox1.Text + "' and rld_master.btn='" + ComboBox2.Text + "' and rld_master.manfact='" + ComboBox3.Text + "' order by rld_master.proname ASC", con)
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)

            With Me.ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportPath = "D:\Provision Report\Report2.rdlc"
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1

        LoadProductName()
        LoadBatchNumber()
        LoadManufacturer()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        LoadBatchNumberProname()
    End Sub
End Class