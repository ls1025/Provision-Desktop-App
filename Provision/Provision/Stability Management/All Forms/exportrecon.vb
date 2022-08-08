Imports System.Data.OleDb
Public Class exportrecon
    Private Sub exportrecon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        exportreport()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Private Sub exportreport()
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New OleDbCommand("select *  from plnr", con)
        Dim da As New OleDbDataAdapter(cmd)
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)

        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd1 As New OleDbCommand("select *  from recon", con)
        Dim da1 As New OleDbDataAdapter(cmd1)
        da1.SelectCommand = cmd1
        Dim dt1 As New DataTable
        da1.Fill(dt1)



        With Me.ReportViewer1.LocalReport
            .DataSources.Clear()
            .ReportPath = "D:\V-Ensure Softwares\Stability Planner A-63\Stability Planner\Report\Report2.rdlc"
            For i = 0 To dt.Rows.Count - 1
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", dt))
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("recon", dt))
            Next


        End With
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
End Class