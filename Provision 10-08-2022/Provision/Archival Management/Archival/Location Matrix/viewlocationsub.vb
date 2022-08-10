Imports System.Data.SqlClient
Imports System.IO
Public Class viewlocationsub
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton
    Private WithEvents conutlabel As New Label
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Dim currentchildForm As Form
    Private Sub viewlocationsub_Load(sender As Object, e As EventArgs) Handles Me.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel2, Color.FromArgb(4, 145, 199), 50, 300, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        Load_Archive_Category()
    End Sub

    Public Sub Load_Archive_Category()
        Try
            FlowLayoutPanel1.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "SELECT  location,COUNT(location) AS 'Total' from archival_master where location IS NOT NULL and LEFT(location,1)='" + Label1.Text + "' group by location order by location ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Guna.UI.WinForms.GunaGradientButton
                pic.Width = 400
                pic.Height = 150

                pic.Radius = 5
                pic.Image = Nothing
                ' pic.ImageAlign = HorizontalAlignment.Center
                '  pic.ImageSize = New Size(80, 80)
                ' pic.ImageOffsetX = -5
                pic.Cursor = Cursors.Hand
                pic.TextAlign = HorizontalAlignment.Center
                pic.BorderSize = 1

                'Base Color
                pic.BaseColor1 = Color.Gainsboro
                pic.BaseColor2 = Color.Gainsboro
                pic.ForeColor = Color.FromArgb(17, 72, 114)
                pic.BorderColor = Color.Transparent

                'Mouse hover Color
                pic.OnHoverBaseColor1 = Color.Silver
                pic.OnHoverBaseColor2 = Color.Silver
                pic.OnHoverForeColor = Color.FromArgb(17, 72, 114)
                pic.OnHoverBorderColor = Color.Transparent

                pic.Font = New Font("Segoe UI Semibold", 12.0F)
                pic.Text = dr.Item("location").ToString + Environment.NewLine + dr.Item("Total").ToString

                pic.Tag = dr.Item("location").ToString



                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf View_Handover_Catogery

            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub View_Handover_Catogery(sender As Object, e As EventArgs)

        Dim form As New viewlocationdocdetails
        form.Owner = Me
        form.Label1.Text = Label1.Text
        form.Label2.Text = sender.tag.ToString
        form.GunaLabel5.Text = Label1.Text + ">" + sender.tag.ToString
        form.WindowState = FormWindowState.Maximized
        form.ShowDialog()
    End Sub

End Class

