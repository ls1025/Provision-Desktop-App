Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class viewproductatrard
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton

    Private Sub viewproductatrard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
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
            cmd.CommandText = "Select proname,market from productlistdoc where [proname] like '%" & ValueTosearch & "%' or [market] like '%" & ValueTosearch & "%' Group by proname,market"
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
                pic.Text = dr.Item("proname").ToString + "_" + dr.Item("market").ToString

                pic.Tag = dr.Item("proname").ToString
                pic.Name = dr.Item("market").ToString
                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf viewatr

            End While
            dr.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub loadData()
        Try

            FlowLayoutPanel1.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select proname,market from productlistdoc Group by [proname],[market] order by proname ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Guna.UI.WinForms.GunaGradientButton
                pic.Width = 550
                pic.Height = 50
                pic.BorderSize = 1
                pic.BorderColor = Color.Transparent
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
                pic.Text = dr.Item("proname").ToString + "_" + dr.Item("market").ToString

                pic.Tag = dr.Item("proname").ToString
                pic.Name = dr.Item("market").ToString

                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf viewatr


            End While
            dr.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub viewatr(sender As Object, e As EventArgs)

        Dim form As New viewatrdetailsard
        form.Label1.Text = sender.tag.ToString
        form.Label2.Text = sender.Name.ToString
        form.ShowDialog()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        loadData()
        TextBox1.Clear()
    End Sub
End Class