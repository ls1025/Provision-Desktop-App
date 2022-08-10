Imports System.Data.SqlClient
Public Class exportmonthlywithdrawal
    Private Sub export_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If con.State = ConnectionState.Open Then con.Close()
        Dim cmd As New SqlCommand("select *  from plnr where podate between @fromdate and @todate order by podate DESC", con)
        cmd.Parameters.AddWithValue("@fromdate", SqlDbType.Date).Value = Convert.ToDateTime(Label1.Text)
        cmd.Parameters.AddWithValue("@todate", SqlDbType.Date).Value = Convert.ToDateTime(Label2.Text)
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