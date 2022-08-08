Imports System.Data.SqlClient
Public Class morematerialdetails

    Private Sub morematerialdetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.FromArgb(4, 145, 199), 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

        LoadIntimationDetails()

    End Sub

    Private Sub LoadIntimationDetails()

        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim da As New SqlDataAdapter()
            Dim table As New DataTable()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select * from inventry_master where [id]= '" + Label1.Text + "' ", con)
            da.Fill(table)

            'Material Code
            Label2.Text = table.Rows(0)(1).ToString
            'material type
            Label3.Text = table.Rows(0)(2).ToString
            'category
            Label4.Text = table.Rows(0)(3).ToString
            'material name
            Label5.Text = table.Rows(0)(4).ToString
            'generic name
            Label6.Text = table.Rows(0)(5).ToString
            'brand name
            Label7.Text = table.Rows(0)(6).ToString
            'Batch No.
            Label8.Text = table.Rows(0)(7).ToString
            'mfg
            If table.Rows(0)(8).ToString = "" Then
                Label9.Text = ""
            Else
                Dim requestdate As Date = Date.ParseExact(table.Rows(0)(8), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label9.Text = requestdate
            End If
            'exp
            If table.Rows(0)(9).ToString = "" Then
                Label10.Text = ""
            Else
                Dim requestdate As Date = Date.ParseExact(table.Rows(0)(9), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label10.Text = requestdate
            End If
            'retest
            If table.Rows(0)(10).ToString = "" Then
                Label11.Text = ""
            Else
                Dim requestdate As Date = Date.ParseExact(table.Rows(0)(10), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label11.Text = requestdate
            End If
            'mfg by
            Label12.Text = table.Rows(0)(11).ToString
            'supply by
            Label13.Text = table.Rows(0)(12).ToString
            'department
            Label14.Text = table.Rows(0)(13).ToString
            'sample type
            Label15.Text = table.Rows(0)(14).ToString
            'ponumber
            Label16.Text = table.Rows(0)(16).ToString
            'description
            Label17.Text = table.Rows(0)(15).ToString
            'recieved qty
            Label18.Text = table.Rows(0)(17).ToString + " " + table.Rows(0)(18).ToString
            'remaining qty
            Label19.Text = table.Rows(0)(21).ToString + " " + table.Rows(0)(18).ToString
            'each price
            Label20.Text = table.Rows(0)(19).ToString
            'total price
            Label21.Text = table.Rows(0)(20).ToString
            'location
            Label22.Text = table.Rows(0)(22).ToString
            'erp code
            Label23.Text = table.Rows(0)(23).ToString
            'stock added By
            Label24.Text = table.Rows(0)(25).ToString
            'stock added Date
            If table.Rows(0)(26).ToString = "" Then
                Label25.Text = ""
            Else
                Dim atrissueddate As Date = Date.ParseExact(table.Rows(0)(26), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label25.Text = atrissueddate
            End If


        Catch ex As Exception
        End Try

    End Sub

End Class