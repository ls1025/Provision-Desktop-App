Imports System.Data.SqlClient
Imports System.IO
Public Class viewequipusage
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton
    Private WithEvents boxlabel As New Label
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Dim currentchildForm As Form
    Private Sub viewequipusage_Load(sender As Object, e As EventArgs) Handles Me.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel2, Color.FromArgb(4, 145, 199), 50, 300, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        '  OpenChildForm(New viewequipusage)
        Load_Running_Equipment()
    End Sub

    Public Sub Load_Running_Equipment()
        Try
            FlowLayoutPanel1.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select id,instr_name,instr_id,proname,btn,startedby,starttime from instrument_usage where endedby IS NULL group by id,instr_name,instr_id,proname,btn,startedby,starttime order by starttime DESC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Guna.UI.WinForms.GunaGradientButton
                pic.Width = 200
                pic.Height = 250
                'pic.Size = New Size(pic., 80)
                pic.AutoSize = True
                pic.Radius = 25

                pic.Cursor = Cursors.Hand
                pic.TextAlign = HorizontalAlignment.Left
                pic.BorderSize = 1

                'Base Color
                pic.BaseColor1 = Color.Transparent
                pic.BaseColor2 = Color.Transparent
                pic.ForeColor = Color.FromArgb(17, 72, 114)
                pic.BorderColor = Color.Transparent

                'Mouse hover Color
                pic.OnHoverBaseColor1 = Color.Transparent
                pic.OnHoverBaseColor2 = Color.Transparent
                pic.OnHoverForeColor = Color.FromArgb(17, 72, 114)
                pic.OnHoverBorderColor = Color.Transparent

                pic.Font = New Font("Segoe UI Semibold", 12.0F)
                'pic.Text = dr.Item("instr_name").ToString


                'Get Equipement Image
                pic.BackgroundImage = My.Resources.ResourceManager.GetObject(dr.Item("instr_id").ToString)
                pic.BackgroundImageLayout = ImageLayout.Stretch

                pic.Image = Nothing
                ' boxlabel = New Label
                ' boxlabel.ForeColor = Color.Blue
                ' boxlabel.BackColor = Color.Transparent
                ' boxlabel.Text = dr.Item("proname").ToString + Environment.NewLine + dr.Item("btn").ToString
                ' boxlabel.Dock = DockStyle.Bottom
                ' boxlabel.AutoSize = True
                ' boxlabel.TextAlign = ContentAlignment.MiddleCenter
                ' pic.Controls.Add(boxlabel)
                pic.Tag = dr.Item("id").ToString
                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf View_Details

            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub View_Details(sender As Object, e As EventArgs)
        Dim form As New viewequipdetails
        form.Label1.Text = sender.tag.ToString
        form.ShowDialog()

    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New viewusagelog
        form.Owner = Me
        form.ShowDialog()
    End Sub

End Class

