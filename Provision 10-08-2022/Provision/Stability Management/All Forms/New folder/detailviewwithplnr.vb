Imports System.Data.OleDb
Public Class detailviewwithplnr
    Dim da As New OleDbDataAdapter()
    Dim dt As New DataTable()
    Private Sub detailviewwithplnr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel3, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        loadwithdrawalplanner()
        GunaPanel2.Hide()
    End Sub
    Private Sub loadwithdrawalplanner()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New OleDbCommand
            cmd.Connection = con

            da = New OleDbDataAdapter("Select * from plnr where [ID]= " & Label1.Text & " ", con)
            Dim table As New DataTable()
            da.Fill(table)

            GunaLabel12.Text = table.Rows(0)(1).ToString
            GunaLabel13.Text = table.Rows(0)(2).ToString
            GunaLabel14.Text = table.Rows(0)(3).ToString
            GunaLabel15.Text = table.Rows(0)(4).ToString
            GunaLabel16.Text = table.Rows(0)(5).ToString
            'GunaLabel17.Text = table.Rows(0)(6).ToString

            If table.Rows(0)(7).ToString = "" Then
                GunaLabel18.Text = ""
            Else
                Dim chrgdate As Date = Date.ParseExact(table.Rows(0)(7), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                GunaLabel18.Text = chrgdate
            End If

            GunaLabel19.Text = table.Rows(0)(8).ToString
            GunaLabel20.Text = table.Rows(0)(9).ToString


            If table.Rows(0)(10).ToString = "" Then
                GunaLabel21.Text = ""
            Else
                Dim withdate As Date = Date.ParseExact(table.Rows(0)(10), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                GunaLabel21.Text = withdate
            End If

            GunaLabel22.Text = table.Rows(0)(15).ToString

            GunaLabel23.Text = table.Rows(0)(17).ToString

            If table.Rows(0)(18).ToString = "" Then
                GunaLabel24.Text = ""
            Else
                Dim withon As Date = Date.ParseExact(table.Rows(0)(18), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                GunaLabel24.Text = withon
            End If

            GunaLabel25.Text = table.Rows(0)(13).ToString

            If table.Rows(0)(11).ToString = "" Then
                GunaLabel26.Text = ""
            Else
                Dim withon As Date = Date.ParseExact(table.Rows(0)(11), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                GunaLabel26.Text = withon
            End If

            GunaLabel27.Text = table.Rows(0)(19).ToString
            If table.Rows(0)(20).ToString = "" Then
                GunaLabel28.Text = ""
            Else
                Dim withon As Date = Date.ParseExact(table.Rows(0)(20), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                GunaLabel28.Text = withon
            End If
            GunaLabel29.Text = table.Rows(0)(12).ToString

            GunaLabel30.Text = table.Rows(0)(21).ToString
            If table.Rows(0)(22).ToString = "" Then
                GunaLabel31.Text = ""
            Else
                Dim withon As Date = Date.ParseExact(table.Rows(0)(22), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                GunaLabel31.Text = withon
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaLabel26_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaLabel25_Click(sender As Object, e As EventArgs)

    End Sub
End Class