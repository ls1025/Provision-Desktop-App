Imports System.Data.SqlClient
Public Class exportyearlywithdrawal
    Private Sub export_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand("select *  from plnr where Year(podate)='" + TextBox1.Text + "' order by podate DESC", con)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)

        With Me.ReportViewer1.LocalReport
            .DataSources.Clear()
            .ReportPath = "D:\Provision Report\Report3.rdlc"
            For i = 0 To dt.Rows.Count - 1
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet3", dt))
            Next

        End With
        Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand("select *  from plnr where Year(podate)='" + TextBox1.Text + "' order by podate DESC", con)
        Dim da As New SqlDataAdapter(cmd)
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)

        With Me.ReportViewer1.LocalReport
            .DataSources.Clear()
            .ReportPath = "D:\Provision Report\Report3.rdlc"
            For i = 0 To dt.Rows.Count - 1
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet3", dt))
            Next

        End With
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class