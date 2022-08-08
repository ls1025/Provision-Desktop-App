Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class viewproductmastersdqa
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton
    Private WithEvents boxlabel As New Label
    Private WithEvents conutlabel As New Label
    Private Sub viewproductmastersdqa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductMaster()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            LoadProductMaster()
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
            cmd.CommandText = "Select proname,market,pds from productmaster where [proname] like '%" & ValueTosearch & "%' or [procode] like '%" & ValueTosearch & "%' or [market] like '%" & ValueTosearch & "%' and [productstatus]='Active' Group by proname,market,pds"
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
                If dr.Item("pds").ToString = "Yes" Then

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
                ElseIf dr.Item("pds").ToString = "No" Then

                    pic.Animated = True
                    pic.AnimationHoverSpeed = 0.07
                    pic.AnimationSpeed = 0.03
                    pic.BackColor = Color.Transparent
                    pic.BaseColor1 = Color.Yellow
                    pic.BaseColor2 = Color.MintCream

                    pic.OnHoverBaseColor1 = Color.MintCream
                    pic.OnHoverBaseColor2 = Color.Yellow
                    pic.OnHoverForeColor = Color.FromArgb(0, 53, 92)
                    pic.OnHoverBorderColor = Color.FromArgb(0, 53, 92)
                End If



                pic.Text = dr.Item("proname").ToString + "_" + dr.Item("market").ToString

                pic.Tag = dr.Item("proname").ToString
                pic.Name = dr.Item("market").ToString
                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf ViewProductDetails

            End While
            dr.Close()
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub LoadProductMaster()
        Try

            FlowLayoutPanel1.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select proname,market,pds from productmaster where [productstatus]='Active' Group by proname,market,pds order by proname ASC"
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
                If dr.Item("pds").ToString = "Yes" Then

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
                ElseIf dr.Item("pds").ToString = "No" Then

                    pic.Animated = True
                    pic.AnimationHoverSpeed = 0.07
                    pic.AnimationSpeed = 0.03
                    pic.BackColor = Color.Transparent
                    pic.BaseColor1 = Color.Yellow
                    pic.BaseColor2 = Color.MintCream

                    pic.OnHoverBaseColor1 = Color.MintCream
                    pic.OnHoverBaseColor2 = Color.Yellow
                    pic.OnHoverForeColor = Color.FromArgb(0, 53, 92)
                    pic.OnHoverBorderColor = Color.FromArgb(0, 53, 92)
                End If

                pic.Text = dr.Item("proname").ToString + "_" + dr.Item("market").ToString

                pic.Tag = dr.Item("proname").ToString
                pic.Name = dr.Item("market").ToString

                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf ViewProductDetails


            End While
            dr.Close()
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ViewProductDetails(sender As Object, e As EventArgs)

        Dim form As New viewproductdetails
        form.Label1.Text = sender.tag.ToString
        form.Label2.Text = sender.Name.ToString
        form.ShowDialog()

    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) 
        Dim form As New addproduct
        form.Owner = Me
        form.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadProductMaster()
        TextBox1.Clear()
    End Sub
End Class