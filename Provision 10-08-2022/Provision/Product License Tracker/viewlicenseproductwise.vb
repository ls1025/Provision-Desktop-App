Imports System.Data.SqlClient
Imports System.IO
Public Class viewlicenseproductwise
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton
    Private Sub viewlicenseproductwise_Load(sender As Object, e As EventArgs) Handles Me.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel2, Color.FromArgb(4, 145, 199), 50, 300, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        '  OpenChildForm(New viewlicenseproductwise)
        LoadProductLicense()
    End Sub
    Public Sub LoadProductLicense()
        Try
            FlowLayoutPanel1.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select proname,strength from productlicense group by proname,strength order by proname ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Guna.UI.WinForms.GunaGradientButton
                pic.Width = 550
                pic.Height = 50
                pic.BorderSize = pic.BorderColor = Color.Transparent
                pic.Radius = 25
                pic.Image = Nothing
                pic.ForeColor = Color.FromArgb(0, 53, 92)
                pic.Cursor = Cursors.Hand
                pic.TextAlign = HorizontalAlignment.Left

                pic.Font = New Font("Segoe UI Semibold", 10.0F)
                pic.Animated = True
                pic.AnimationHoverSpeed = 0.07
                pic.AnimationSpeed = 0.03
                pic.BackColor = Color.Transparent
                pic.BaseColor1 = Color.Aquamarine
                pic.BaseColor2 = Color.MintCream

                pic.OnHoverBaseColor1 = Color.MintCream
                pic.OnHoverBaseColor2 = Color.Aquamarine
                pic.OnHoverForeColor = Color.FromArgb(0, 53, 92)
                pic.OnHoverBorderColor = Color.FromArgb(0, 53, 92)

                pic.Text = dr.Item("proname").ToString + " " + dr.Item("strength").ToString
                pic.Tag = dr.Item("proname").ToString
                pic.Name = dr.Item("strength").ToString
                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf View_License_Details

            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub View_License_Details(sender As Object, e As EventArgs)
        Dim form As New viewlicensedetails
        form.Label1.Text = sender.tag.ToString
        form.Label2.Text = sender.Name.ToString
        form.GunaLabel5.Text = sender.tag.ToString + " " + sender.Name.ToString
        form.ShowDialog()

    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New addlicense
        form.Owner = Me
        form.ShowDialog()
    End Sub
    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Dim form As New adddcotype
        form.ShowDialog()
    End Sub
    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        Dim form As New adddoccategory
        form.ShowDialog()
    End Sub
    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs) Handles GunaGradientButton4.Click
        Dim form As New viewcorrectionsdocs
        form.ShowDialog()
    End Sub
End Class

