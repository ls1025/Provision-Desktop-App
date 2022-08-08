Imports System.Data.SqlClient
Imports System.IO
Public Class viewstabilityprotocolfrdgl
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub viewstabilityprotocolfrdgl_Load(sender As Object, e As EventArgs) Handles Me.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel2, Color.FromArgb(4, 145, 199), 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadProtocols()

    End Sub
    Public Sub LoadProtocols()
        Try

            FlowLayoutPanel1.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select proname,strength,btn,ptn,status from stability_protocol where status='Submitted for Approval' group by proname,strength,btn,ptn,status order by proname ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Guna.UI.WinForms.GunaGradientButton
                pic.Width = 400
                pic.Height = 100
                pic.BorderSize = pic.BorderColor = Color.Transparent
                pic.Radius = 25
                pic.Image = Nothing
                pic.Font = New Font("Segoe UI Semibold", 10.0F)
                pic.Animated = True
                pic.AnimationHoverSpeed = 0.07
                pic.AnimationSpeed = 0.03
                pic.BackColor = Color.Transparent
                pic.Cursor = Cursors.Hand

                If dr.Item("status").ToString = "Approved" Then
                    pic.ForeColor = Color.FromArgb(0, 53, 92)
                    pic.BaseColor1 = Color.Aquamarine
                    pic.BaseColor2 = Color.MintCream

                    pic.OnHoverBaseColor1 = Color.MintCream
                    pic.OnHoverBaseColor2 = Color.Aquamarine

                    pic.OnHoverForeColor = Color.FromArgb(0, 53, 92)
                    pic.OnHoverBorderColor = Color.FromArgb(0, 53, 92)
                Else
                    pic.ForeColor = Color.FromArgb(0, 53, 92)
                    pic.BaseColor1 = Color.Crimson
                    pic.BaseColor2 = Color.LightPink

                    pic.OnHoverBaseColor1 = Color.LightPink
                    pic.OnHoverBaseColor2 = Color.Crimson

                    pic.OnHoverForeColor = Color.FromArgb(0, 53, 92)
                    pic.OnHoverBorderColor = Color.FromArgb(0, 53, 92)
                End If

                pic.Text = dr.Item("proname").ToString + " " + dr.Item("strength").ToString + Environment.NewLine + "Batch No: " + dr.Item("btn").ToString + "; Protocol No: " + dr.Item("ptn").ToString + Environment.NewLine + "( " + dr.Item("status").ToString + " )"
                pic.TextAlign = HorizontalAlignment.Center
                pic.Tag = dr.Item("ptn").ToString
                'pic.Name = dr.Item("test").ToString
                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf ViewDetailStabilityPlanner

            End While
            dr.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            LoadProtocols()
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
            cmd.CommandText = "Select proname,strength,btn,ptn,status from stability_protocol where status='Submitted for Approval' and [proname] like '%" & ValueTosearch & "%' or [btn] like '%" & ValueTosearch & "%' or [ptn] like '%" & ValueTosearch & "%' Group by proname,strength,btn,ptn,status order by proname ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Guna.UI.WinForms.GunaGradientButton
                pic.Width = 400
                pic.Height = 100
                pic.BorderSize = pic.BorderColor = Color.Transparent
                pic.Radius = 25
                pic.Image = Nothing
                pic.Font = New Font("Segoe UI Semibold", 10.0F)
                pic.Animated = True
                pic.AnimationHoverSpeed = 0.07
                pic.AnimationSpeed = 0.03
                pic.BackColor = Color.Transparent
                pic.Cursor = Cursors.Hand

                If dr.Item("status").ToString = "Approved" Then
                    pic.ForeColor = Color.FromArgb(0, 53, 92)
                    pic.BaseColor1 = Color.Aquamarine
                    pic.BaseColor2 = Color.MintCream

                    pic.OnHoverBaseColor1 = Color.MintCream
                    pic.OnHoverBaseColor2 = Color.Aquamarine

                    pic.OnHoverForeColor = Color.FromArgb(0, 53, 92)
                    pic.OnHoverBorderColor = Color.FromArgb(0, 53, 92)
                Else
                    pic.ForeColor = Color.FromArgb(0, 53, 92)
                    pic.BaseColor1 = Color.Crimson
                    pic.BaseColor2 = Color.LightPink

                    pic.OnHoverBaseColor1 = Color.LightPink
                    pic.OnHoverBaseColor2 = Color.Crimson

                    pic.OnHoverForeColor = Color.FromArgb(0, 53, 92)
                    pic.OnHoverBorderColor = Color.FromArgb(0, 53, 92)
                End If

                pic.Text = dr.Item("proname").ToString + " " + dr.Item("strength").ToString + Environment.NewLine + "Batch No: " + dr.Item("btn").ToString + "; Protocol No: " + dr.Item("ptn").ToString + Environment.NewLine + "( " + dr.Item("status").ToString + " )"
                pic.TextAlign = HorizontalAlignment.Center
                pic.Tag = dr.Item("ptn").ToString
                'pic.Name = dr.Item("test").ToString
                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf ViewDetailStabilityPlanner

            End While
            dr.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ViewDetailStabilityPlanner(sender As Object, e As EventArgs)

        Dim form As New detailviewprotocolfrdgl
        form.TextBox3.Text = sender.tag.ToString
        form.Owner = Me
        form.ShowDialog()

    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New addprotocol
        form.Owner = Me
        form.ShowDialog()
    End Sub

End Class

