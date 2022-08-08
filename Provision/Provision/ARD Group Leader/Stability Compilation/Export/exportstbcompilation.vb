Imports System.Data.SqlClient
Public Class exportstbcompilation


    Private Sub exportstbcompilation_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If con.State = ConnectionState.Open Then con.Close()
        '  ' da = New SqlDataAdapter("SELECT plnr.proname,plnr.strength,plnr.btn,plnr.ptn,plnr.cndn,plnr.chrgdate,plnr.sch,recon.remark FROM plnr INNER JOIN recon on plnr.ID=recon.ref_id  WHERE plnr.actpodate IS NULL and plnr.ID IN  (SELECT Ref_id FROM recon ) order by [proname] ASC", con)
        Dim cmd As New SqlCommand("SELECT stbcomp_master.proname, stbcomp_master.strength, stbcomp_master.btn, stbcomp_master.packstyle, stbcomp_master.label, stbcomp_master.chrgdate, stbcomp_master.addedby, stbcomp_master.addedon, stbcomp_general.gen_cndn, 
                  stbcomp_general.gen_period, stbcomp_general.test, stbcomp_general.gen_result, stbcomp_general.gen_limit, stbcomp_disso.disso_cndn, stbcomp_disso.disso_period, stbcomp_disso.timepoint, stbcomp_disso.min, stbcomp_disso.max, 
                  stbcomp_disso.avg, stbcomp_disso.rsd, stbcomp_impurity.impurity, stbcomp_impurity.rrt, stbcomp_impurity.imp_cndn, stbcomp_impurity.imp_period, stbcomp_impurity.imp_result, stbcomp_impurity.imp_limit, stbcomp_general.gen_seq, 
                  stbcomp_disso.disso_seq, stbcomp_impurity.imp_seq
FROM     stbcomp_master left outer join
                  stbcomp_general ON stbcomp_master.btn = stbcomp_general.btn left outer join
                  stbcomp_disso ON stbcomp_master.btn = stbcomp_disso.btn left outer join
                  stbcomp_impurity ON stbcomp_master.btn = stbcomp_impurity.btn where stbcomp_master.btn='" + Label1.Text + "' order by LEN(gen_period),disso_period,imp_period ASC", con)
        Dim da As New SqlDataAdapter(cmd)

        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)

        With Me.ReportViewer1.LocalReport
            .DataSources.Clear()
            .ReportPath = "D:\Provision Report\Report5.rdlc"
            For i = 0 To dt.Rows.Count - 1
                .DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt))
            Next

        End With
        Me.ReportViewer1.RefreshReport()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox2_DropDown(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox3_DropDown(sender As Object, e As EventArgs)

    End Sub
End Class