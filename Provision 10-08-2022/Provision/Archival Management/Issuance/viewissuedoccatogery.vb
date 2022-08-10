Imports System.Data.SqlClient
Imports System.IO
Public Class viewissuedoccatogery
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton
    Private WithEvents conutlabel As New Label
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Dim currentchildForm As Form
    Private Sub viewissuedoccatogery_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel2, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        Load_Handover_Docs()
    End Sub

    Public Sub Load_Handover_Docs()
        Try
            FlowLayoutPanel1.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select COUNT(catogery) AS 'Total', catogery from archival_issuance where doctype='" + Label1.Text + "' and [returnedby] IS NULL group by catogery"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Guna.UI.WinForms.GunaGradientButton
                pic.Width = 250
                pic.Height = 80

                pic.Radius = 25
                pic.Image = My.Resources.File_Image_New
                pic.ImageAlign = HorizontalAlignment.Left
                pic.ImageSize = New Size(50, 50)
                pic.ImageOffsetX = -5
                pic.Cursor = Cursors.Hand
                pic.TextAlign = HorizontalAlignment.Center
                pic.BorderSize = 1

                'Base Color
                pic.BaseColor1 = Color.Transparent
                pic.BaseColor2 = Color.Transparent
                pic.ForeColor = Color.FromArgb(17, 72, 114)
                pic.BorderColor = Color.Transparent

                'Mouse hover Color
                pic.OnHoverBaseColor1 = Color.LightGray
                pic.OnHoverBaseColor2 = Color.LightGray
                pic.OnHoverForeColor = Color.FromArgb(17, 72, 114)
                pic.OnHoverBorderColor = Color.Transparent

                pic.Font = New Font("Segoe UI Semibold", 12.0F)
                pic.Text = dr.Item("catogery").ToString + Environment.NewLine + dr.Item("Total").ToString

                pic.Tag = dr.Item("catogery").ToString


                pic.Controls.Add(conutlabel)

                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf View_Handover_Catogery

            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub View_Handover_Catogery(sender As Object, e As EventArgs)

        Dim form As New viewissueddocdetails
        form.Owner = Me
        form.Label1.Text = Label1.Text
        form.Label2.Text = sender.tag.ToString
        form.GunaLabel5.Text = Label1.Text + ">" + sender.tag.ToString
        form.ShowDialog()
    End Sub

End Class

