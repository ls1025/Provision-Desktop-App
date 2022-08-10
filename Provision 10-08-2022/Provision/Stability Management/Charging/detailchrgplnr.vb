Imports System.Data.SqlClient
Public Class detailchrgplnr
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub detailchrgplnr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel3, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        loadwithdrawalplanner()
        GunaPanel2.Hide()
    End Sub
    Private Sub loadwithdrawalplanner()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con

            da = New SqlDataAdapter("Select * from plnr where [ID]= '" + Label1.Text + "' ", con)
            Dim table As New DataTable()
            da.Fill(table)

            GunaLabel12.Text = table.Rows(0)(1).ToString + " " + table.Rows(0)(2).ToString
            GunaLabel13.Text = table.Rows(0)(3).ToString
            GunaLabel14.Text = table.Rows(0)(4).ToString
            GunaLabel15.Text = table.Rows(0)(5).ToString
            GunaLabel16.Text = table.Rows(0)(6).ToString
            GunaLabel17.Text = table.Rows(0)(7).ToString

            If table.Rows(0)(8).ToString = "" Then
                GunaLabel18.Text = ""
            Else
                Dim chrgdate As Date = Date.ParseExact(table.Rows(0)(8), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                GunaLabel18.Text = chrgdate
            End If

            GunaLabel19.Text = table.Rows(0)(9).ToString
            GunaLabel20.Text = table.Rows(0)(10).ToString


            If table.Rows(0)(11).ToString = "" Then
                GunaLabel21.Text = ""
            Else
                Dim withdate As Date = Date.ParseExact(table.Rows(0)(11), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                GunaLabel21.Text = withdate
            End If

            GunaLabel22.Text = table.Rows(0)(16).ToString

            GunaLabel23.Text = table.Rows(0)(18).ToString

            If table.Rows(0)(19).ToString = "" Then
                GunaLabel24.Text = ""
            Else
                Dim withon As Date = Date.ParseExact(table.Rows(0)(19), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                GunaLabel24.Text = withon
            End If




        Catch ex As Exception

        End Try

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub GunaLabel7_Click(sender As Object, e As EventArgs) Handles GunaLabel7.Click

    End Sub

    Private Sub GunaLabel19_Click(sender As Object, e As EventArgs) Handles GunaLabel19.Click

    End Sub
End Class