Imports System.Data.SqlClient
Imports System.IO
Public Class viewarchivedoctype
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton
    Private WithEvents conutlabel As New Label
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Dim currentchildForm As Form
    Private Sub viewarchivedoctype_Load(sender As Object, e As EventArgs) Handles Me.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel2, Color.FromArgb(4, 145, 199), 50, 300, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        '  OpenChildForm(New viewhandoverdoctype)
        Load_Archive_Docs()
    End Sub

    Public Sub Load_Archive_Docs()
        Try
            FlowLayoutPanel1.Controls.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select COUNT(doctype) AS 'Total', doctype from archival_master where status='archived' group by doctype order by doctype ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                pic = New Guna.UI.WinForms.GunaGradientButton
                pic.Width = 380
                pic.Height = 60

                pic.Radius = 25
                pic.Image = My.Resources.File_Image_New
                pic.ImageAlign = HorizontalAlignment.Left
                pic.ImageSize = New Size(30, 30)
                pic.ImageOffsetX = -5
                pic.Cursor = Cursors.Hand
                pic.TextAlign = HorizontalAlignment.Left
                pic.BorderSize = 1

                'Base Color
                pic.BaseColor1 = Color.Transparent
                pic.BaseColor2 = Color.Transparent
                pic.ForeColor = Color.FromArgb(17, 72, 114)
                pic.BorderColor = Color.Transparent

                'Mouse hover Color
                pic.OnHoverBaseColor1 = Color.LightGray
                pic.OnHoverBaseColor2 = Color.LightGray
                pic.OnHoverForeColor = Color.FromArgb(17, 72, 114)
                pic.OnHoverBorderColor = Color.Transparent

                pic.Font = New Font("Segoe UI Semibold", 12.0F)
                pic.Text = dr.Item("doctype").ToString + " ( " + dr.Item("Total").ToString + " )"

                pic.Tag = dr.Item("doctype").ToString

                pic.Controls.Add(conutlabel)

                FlowLayoutPanel1.Controls.Add(pic)
                AddHandler pic.Click, AddressOf View_Handover_Catogery

            End While
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub View_Handover_Catogery(sender As Object, e As EventArgs)
        
        Label1.Text = sender.tag.ToString

        Dim formaaa As New viewarchivecatogery
        formaaa.Label1.Text = sender.tag.ToString
        OpenChildFormSub(formaaa)

    End Sub
    Private Sub OpenChildFormSub(childForm As Form)
        If currentchildForm IsNot Nothing Then
            currentchildForm.Close()
        End If
        currentchildForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        childForm.Dock = DockStyle.Fill

        Panel1.Controls.Add(childForm)
        Panel1.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs)
        Dim form As New handover
        form.Owner = Me
        form.ShowDialog()
    End Sub
    Private Sub OpenChildForm(childForm As Form)
        If currentchildForm IsNot Nothing Then
            currentchildForm.Close()
        End If
        currentchildForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        childForm.Dock = DockStyle.Fill

        homepage.GunaPanel5.Controls.Add(childForm)
        homepage.GunaPanel5.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label1.Text = ""
        OpenChildForm(New viewarchivedoctype())
    End Sub
End Class

