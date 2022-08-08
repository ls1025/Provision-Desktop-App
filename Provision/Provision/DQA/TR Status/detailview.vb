Imports System.Data.SqlClient
Public Class detailview

    Private Sub detailview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel3, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadIntimationDetails()

    End Sub
    Dim table As New DataTable()
    Private Sub LoadIntimationDetails()
        If Label1.Text.Contains("DT/") Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim ds As DataSet = New DataSet
                Dim da As New SqlDataAdapter()
                Dim dt As New DataTable()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                da = New SqlDataAdapter("Select * from trdev where [trno]= '" + Label1.Text + "' ", con)
                da.Fill(table)
            Catch ex As Exception
            End Try
        ElseIf Label1.Text.Contains("TR/") Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim ds As DataSet = New DataSet
                Dim da As New SqlDataAdapter()
                Dim dt As New DataTable()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                da = New SqlDataAdapter("Select * from trrot where [trno]= '" + Label1.Text + "' ", con)
                da.Fill(table)
            Catch ex As Exception
            End Try
        ElseIf Label1.Text.Contains("ST/") Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim ds As DataSet = New DataSet
                Dim da As New SqlDataAdapter()
                Dim dt As New DataTable()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                da = New SqlDataAdapter("Select * from trstb where [trno]= '" + Label1.Text + "' ", con)
                da.Fill(table)
            Catch ex As Exception
            End Try
        End If

        'Product Code
        Label2.Text = table.Rows(0)(1).ToString
        'Product Name
        Label4.Text = table.Rows(0)(2).ToString
        'Strength
        Label36.Text = table.Rows(0)(3).ToString
        'Market
        Label6.Text = table.Rows(0)(4).ToString
        'Label Claim
        Label5.Text = table.Rows(0)(6).ToString
        'Batch No.
        Label7.Text = table.Rows(0)(7).ToString
        'Batch Size
        Label8.Text = table.Rows(0)(8).ToString
        'Mfg Date
        Label9.Text = table.Rows(0)(9).ToString
        'Exp Date
        Label10.Text = table.Rows(0)(10).ToString
        'Sample Qty
        Label11.Text = table.Rows(0)(11).ToString
        'Pack
        Label12.Text = table.Rows(0)(12).ToString
        'Condition
        Label13.Text = table.Rows(0)(13).ToString
        'Period
        Label14.Text = table.Rows(0)(14).ToString
        'Test Name
        Label15.Text = table.Rows(0)(15).ToString
        'Test Details
        Label16.Text = table.Rows(0)(16).ToString
        'Remark
        Label17.Text = table.Rows(0)(17).ToString
        'Requested By
        Label18.Text = table.Rows(0)(19).ToString
        'Requested Date
        If table.Rows(0)(20).ToString = "" Then
            Label19.Text = ""
        Else
            Dim requestdate As Date = Date.ParseExact(table.Rows(0)(20), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Label19.Text = requestdate
        End If
        'Status
        Label31.Text = table.Rows(0)(21).ToString

        'Total Print Taken
        Label3.Text = table.Rows(0)(22).ToString
        'Lnb No.
        Label20.Text = table.Rows(0)(23).ToString
        'ATR No.
        Label21.Text = table.Rows(0)(24).ToString
        'ATR Issuance No.
        Label22.Text = table.Rows(0)(25).ToString
        'ATR Issued By
        Label23.Text = table.Rows(0)(26).ToString
        'ATR Issued Date
        If table.Rows(0)(27).ToString = "" Then
            Label24.Text = ""
        Else
            Dim atrissueddate As Date = Date.ParseExact(table.Rows(0)(27), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Label24.Text = atrissueddate
        End If
        'Data Sent By
        Label25.Text = table.Rows(0)(28).ToString
        'Data Sent Date
        If table.Rows(0)(29).ToString = "" Then
            Label26.Text = ""
        Else
            Dim datasentdate As Date = Date.ParseExact(table.Rows(0)(29), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Label26.Text = datasentdate
        End If
        'Released By
        Label27.Text = table.Rows(0)(30).ToString
        'released Date
        If table.Rows(0)(31).ToString = "" Then
            Label28.Text = ""
        Else
            Dim releaseddate As Date = Date.ParseExact(table.Rows(0)(31), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Label28.Text = releaseddate
        End If
        'Creq By
        Label32.Text = table.Rows(0)(32).ToString
        'Creq Date
        If table.Rows(0)(33).ToString = "" Then
            Label33.Text = ""
        Else
            Dim creqby As Date = Date.ParseExact(table.Rows(0)(33), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Label33.Text = creqby
        End If
        'Cancelled By
        Label34.Text = table.Rows(0)(34).ToString
        'Cancelled Date
        If table.Rows(0)(35).ToString = "" Then
            Label35.Text = ""
        Else
            Dim canby As Date = Date.ParseExact(table.Rows(0)(35), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Label35.Text = canby
        End If
        'Data Uploaded By
        Label29.Text = table.Rows(0)(36).ToString
        'data Uploaded date
        If table.Rows(0)(37).ToString = "" Then
            Label30.Text = ""
        Else
            Dim datuploaddate As Date = Date.ParseExact(table.Rows(0)(37), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
            Label30.Text = datuploaddate
        End If



    End Sub

End Class