Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class viewstbcompilation
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton
    Private WithEvents boxlabel As New Label
    Private WithEvents conutlabel As New Label
    Private Sub viewstbcompilation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadStabilityCompilation()
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            loadStabilityCompilation()
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
            cmd.CommandText = "Select proname,strength,btn from stbcomp_master where [proname] like '%" & ValueTosearch & "%' or [btn] like '%" & ValueTosearch & "%' Group by proname,strength,btn order by proname ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Guna.UI.WinForms.GunaGradientButton
                pic.Width = 400
                pic.Height = 100
                pic.BorderSize = pic.BorderColor = Color.Transparent
                pic.Radius = 25
                pic.Image = Nothing
                pic.ForeColor = Color.FromArgb(0, 53, 92)
                pic.Cursor = Cursors.Hand



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
                pic.Text = dr.Item("proname").ToString + "_" + dr.Item("strength").ToString + Environment.NewLine + dr.Item("btn").ToString
                pic.TextAlign = HorizontalAlignment.Center
                pic.Tag = dr.Item("btn").ToString
                'pic.Name = dr.Item("test").ToString
                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf Mouse_Click

            End While
            dr.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub loadStabilityCompilation()
        Try

            FlowLayoutPanel1.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select proname,strength,btn from stbcomp_master Group by proname,strength,btn order by proname ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Guna.UI.WinForms.GunaGradientButton
                pic.Width = 400
                pic.Height = 100
                pic.BorderSize = 1
                pic.BorderColor = Color.Transparent
                pic.Radius = 25
                pic.Image = Nothing
                pic.ForeColor = Color.FromArgb(0, 53, 92)
                pic.Cursor = Cursors.Hand

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
                pic.Text = dr.Item("proname").ToString + "_" + dr.Item("strength").ToString + Environment.NewLine + dr.Item("btn").ToString
                pic.TextAlign = HorizontalAlignment.Center
                pic.Tag = dr.Item("btn").ToString
                'pic.Name = dr.Item("market").ToString

                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf Mouse_Click
            End While
            dr.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Mouse_Click(sender As Object, e As EventArgs)
        Dim form As New viewuptrendform
        form.Label1.Text = sender.tag.ToString
        form.ShowDialog()
    End Sub
    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs)
        MsgBox(sender.Tag)
    End Sub

    Private Sub ViewTrendToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) 
        Dim form As New addpds
        form.Owner = Me
        form.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        loadStabilityCompilation()
        TextBox1.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form As New addstbcompilation
        form.Owner = Me
        form.ShowDialog()
    End Sub


End Class