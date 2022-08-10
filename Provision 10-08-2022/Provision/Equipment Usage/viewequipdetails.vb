Imports System.Data.SqlClient
Public Class viewequipdetails
    Private Sub viewequipdetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.FromArgb(4, 145, 199), 50, 300, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        Load_EquipmentDetails()
    End Sub
    Private Sub Load_EquipmentDetails()


        If con.State = ConnectionState.Open Then con.Close()
        Dim ds As DataSet = New DataSet
        Dim da As New SqlDataAdapter()
        Dim table As New DataTable()

        Dim cmd As New SqlCommand
        cmd.Connection = con
        da = New SqlDataAdapter("Select * from instrument_usage where [id]= '" + Label1.Text + "' ", con)
        da.Fill(table)

        'Instruemnt Name
        Label2.Text = table.Rows(0)(1).ToString
        'Instruemnt ID
        Label3.Text = table.Rows(0)(2).ToString
        'Product Name
        Label4.Text = table.Rows(0)(3).ToString
        'Batch Number
        Label5.Text = table.Rows(0)(4).ToString
        'remark
        Label6.Text = table.Rows(0)(5).ToString
        'Started by
        Label7.Text = table.Rows(0)(6).ToString

        'Start Date
        Label8.Text = table.Rows(0)(7).ToString

    End Sub
End Class