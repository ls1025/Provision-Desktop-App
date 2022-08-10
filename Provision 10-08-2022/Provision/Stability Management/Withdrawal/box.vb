Imports System.Data.SqlClient
Public Class box

    Private WithEvents pic As New Guna.UI.WinForms.GunaButton
    Private WithEvents boxlabel As New Label
    Private WithEvents ProductLabel As New Label

    Private Sub calender_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
    Public Sub loadData()
        Try

            FlowLayoutPanel1.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select withbox,boxsts,proname from boxmaster Group by withbox,boxsts,proname order by withbox desc"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Guna.UI.WinForms.GunaButton
                pic.Width = 220
                pic.Height = 100
                pic.BorderSize = 1
                pic.BorderColor = Color.Transparent
                pic.Radius = 10
                pic.Image = Nothing
                pic.ForeColor = Color.FromArgb(17, 72, 114)
                pic.Cursor = Cursors.Hand
                pic.TextAlign = HorizontalAlignment.Center
                pic.Font = New Font("Segoe UI Semibold", 14.0F)

                '13, 72, 114
                If dr.Item("boxsts").ToString = "Empty" Then
                    pic.BaseColor = Color.LightGreen
                    pic.OnHoverBaseColor = Color.LightGreen
                ElseIf dr.Item("boxsts").ToString = "Space Available" Then
                    pic.BaseColor = Color.Orange
                    pic.OnHoverBaseColor = Color.Orange
                ElseIf dr.Item("boxsts").ToString = "Full" Then
                    pic.BaseColor = Color.Red
                    pic.OnHoverBaseColor = Color.Red
                End If
                pic.Text = dr.Item("withbox").ToString
                pic.Tag = dr.Item("withbox").ToString
                ProductLabel = New Label
                ProductLabel.ForeColor = Color.FromArgb(0, 53, 92)
                ProductLabel.Font = New Font("Segoe UI Semibold", 8.0F)
                ProductLabel.BackColor = Color.Transparent
                ProductLabel.Text = dr.Item("proname").ToString

                ProductLabel.Dock = DockStyle.Top
                ProductLabel.TextAlign = ContentAlignment.MiddleCenter

                pic.Controls.Add(ProductLabel)

                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf Pnale_Show

            End While
            dr.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            loadData()
        Else
            filterdata1(TextBox1.Text)
        End If
    End Sub
    Private Sub filterdata1(ValueTosearch As String)
        Try

            FlowLayoutPanel1.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select withbox,boxsts,proname from boxmaster where [withbox] like '%" & ValueTosearch & "%' or [proname] like '%" & ValueTosearch & "%' Group by withbox,boxsts,proname order by withbox desc"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Guna.UI.WinForms.GunaButton
                pic.Width = 220
                pic.Height = 100
                pic.BorderSize = 1
                pic.BorderColor = Color.Transparent
                pic.Radius = 10
                pic.Image = Nothing
                pic.ForeColor = Color.FromArgb(17, 72, 114)
                pic.Cursor = Cursors.Hand
                pic.TextAlign = HorizontalAlignment.Center

                pic.Font = New Font("Segoe UI Semibold", 14.0F)

                '13, 72, 114
                If dr.Item("boxsts").ToString = "Empty" Then
                    pic.BaseColor = Color.LightGreen
                    pic.OnHoverBaseColor = Color.LightGreen
                ElseIf dr.Item("boxsts").ToString = "Space Available" Then
                    pic.BaseColor = Color.Orange
                    pic.OnHoverBaseColor = Color.Orange
                ElseIf dr.Item("boxsts").ToString = "Full" Then
                    pic.BaseColor = Color.Red
                    pic.OnHoverBaseColor = Color.Red
                End If
                pic.Text = dr.Item("withbox").ToString

                pic.Tag = dr.Item("withbox").ToString


                ProductLabel = New Label
                ProductLabel.ForeColor = Color.FromArgb(0, 53, 92)
                ProductLabel.Font = New Font("Segoe UI Semibold", 8.0F)
                ProductLabel.BackColor = Color.Transparent
                ProductLabel.Text = dr.Item("proname").ToString

                ProductLabel.Dock = DockStyle.Top
                ProductLabel.TextAlign = ContentAlignment.MiddleCenter

                pic.Controls.Add(ProductLabel)



                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf Pnale_Show


            End While
            dr.Close()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Pnale_Show(sender As Object, e As EventArgs)
        Dim form As New itemsinbox
        form.GunaLabel1.Text = sender.tag.ToString
        form.Owner = Me
        form.ShowDialog()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        loadData()
    End Sub
End Class