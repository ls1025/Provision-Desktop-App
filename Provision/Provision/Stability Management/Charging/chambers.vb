Imports System.Data.SqlClient
Public Class chambers
    Private WithEvents pic As New Guna.UI.WinForms.GunaButton
    Private WithEvents condlabel As New Label
    Private WithEvents conutlabel As New Label
    Private Sub chambers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub

    Sub loadData()
        Try
            FlowLayoutPanel1.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "Select COUNT(chrgbox) AS Total,MAX(chrgbox) as Maxno,cndn,instid from plnr where instid IS NOT NULL Group by cndn,instid order by instid ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Guna.UI.WinForms.GunaButton
                pic.Width = 200
                pic.Height = 300
                pic.BorderSize = 1
                pic.BorderColor = Color.Transparent
                pic.Radius = 25
                pic.BaseColor = Color.LightSeaGreen
                pic.OnHoverBaseColor = Color.LightSeaGreen
                pic.Image = Nothing
                pic.ForeColor = Color.FromArgb(17, 72, 114)
                pic.Cursor = Cursors.Hand
                pic.TextAlign = HorizontalAlignment.Center


                pic.Font = New Font("Segoe UI Semibold", 14.0F)



                pic.Text = dr.Item("instid").ToString

                pic.Tag = dr.Item("cndn").ToString

                conutlabel = New Label
                conutlabel.ForeColor = Color.Blue
                conutlabel.Font = New Font("Segoe UI Semibold", 10.0F)
                conutlabel.BackColor = Color.Transparent
                conutlabel.Text = "Latest Box No.: " + dr.Item("Maxno").ToString
                conutlabel.Dock = DockStyle.Top
                conutlabel.TextAlign = ContentAlignment.MiddleCenter

                condlabel = New Label
                condlabel.ForeColor = Color.Blue
                condlabel.Font = New Font("Segoe UI Semibold", 12.0F)
                condlabel.BackColor = Color.Transparent
                condlabel.Text = dr.Item("cndn").ToString
                condlabel.Dock = DockStyle.Bottom
                condlabel.TextAlign = ContentAlignment.MiddleCenter

                '  boxlabel = New Label
                ' boxlabel.ForeColor = Color.Blue
                ' boxlabel.BackColor = Color.LightGray
                'boxlabel.Text = "Box No.: " + dr.Item("withbox").ToString
                'boxlabel.Dock = DockStyle.Top
                'boxlabel.TextAlign = ContentAlignment.MiddleLeft

                pic.Controls.Add(conutlabel)
                pic.Controls.Add(condlabel)
                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf Pnale_Show

            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub Pnale_Show(sender As Object, e As EventArgs)
        Dim form As New boxinchamber
        form.GunaLabel1.Text = sender.tag.ToString
        form.ShowDialog()
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub
End Class