Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Public Class viewatrissuancelog
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton
    Private WithEvents boxlabel As New Label
    Private WithEvents conutlabel As New Label
    Private Sub viewatrissuancelog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        filterdata1(TextBox1.Text)

    End Sub
    Private Sub filterdata1(ValueTosearch As String)
        Try

            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select proname,test,atrissueno from atrissuelog where [atrno] IS NOT NULL and [proname] like '%" & ValueTosearch & "%' or [test] like '%" & ValueTosearch & "%' or [trno] like '%" & ValueTosearch & "%' or [atrissueno] like '%" & ValueTosearch & "%' Group by proname,test,atrissueno,issueddate"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            FlowLayoutPanel1.Controls.Clear()
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
                pic.Text = dr.Item("atrissueno").ToString + "_" + dr.Item("proname").ToString + "_" + dr.Item("test").ToString
                pic.Tag = dr.Item("atrissueno").ToString
                'pic.Name = dr.Item("test").ToString
                FlowLayoutPanel1.SuspendLayout()
                FlowLayoutPanel1.Controls.Add(pic)
                FlowLayoutPanel1.ResumeLayout()
                AddHandler pic.Click, AddressOf ViewIssuenceLog

            End While

            dr.Close()
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub loadData()
        Try











            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select proname,test,atrissueno from atrissuelog where [atrno] IS NOT NULL Group by proname,test,atrissueno,issueddate order by issueddate DESC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            FlowLayoutPanel1.Controls.Clear()
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
                pic.Text = dr.Item("atrissueno").ToString + "_" + dr.Item("proname").ToString + "_" + dr.Item("test").ToString
                pic.Tag = dr.Item("atrissueno").ToString
                'pic.Name = dr.Item("market").ToString

                FlowLayoutPanel1.SuspendLayout()
                FlowLayoutPanel1.Controls.Add(pic)
                FlowLayoutPanel1.ResumeLayout()
                AddHandler pic.Click, AddressOf ViewIssuenceLog

            End While

            dr.Close()
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ViewIssuenceLog(sender As Object, e As EventArgs)

        Dim form As New issuencelog
        form.Label4.Text = sender.tag.ToString
        form.Label2.Text = sender.Name.ToString
        form.ShowDialog()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        loadData()
        TextBox1.Clear()
    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New issueatrdqa
        form.Owner = Me
        form.ShowDialog()
    End Sub
End Class