Imports System
Imports System.Management
Imports System.Drawing.Imaging
Public Class viewdata
    Private _originalSize As Size = Nothing
    Private _scale As Single = 1
    Private _scaleDelta As Single = 0.00005
    Dim mouseIsDown As Boolean = False
    Private Sub viewdata_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub AxAcroPDF1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.P Then
            e.SuppressKeyPress = True
            MessageBox.Show("This Document is Protected !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GunaImageButton1.Refresh()
        GunaImageButton1.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipNone)
        If TextBox1.Text = 1 Then
        Else
            Dim CurrentPage As Double = TextBox1.Text
            Dim MinusPage As Double = CurrentPage - 1

            TextBox1.Text = MinusPage
            GunaImageButton1.BackgroundImage.SelectActiveFrame(FrameDimension.Page, MinusPage - 1)
            GunaImageButton1.Refresh()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GunaImageButton1.Refresh()
        GunaImageButton1.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipNone)
        If TextBox1.Text = Label1.Text Then
        Else
            Dim CurrentPage As Double = TextBox1.Text
            Dim AddPage As Double = CurrentPage + 1
            TextBox1.Text = AddPage
            GunaImageButton1.BackgroundImage.SelectActiveFrame(FrameDimension.Page, AddPage - 1)
            GunaImageButton1.Refresh()
        End If
    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        GunaImageButton1.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GunaImageButton1.Top = (GunaImageButton1.Top + (GunaImageButton1.Height * 0.025))
        GunaImageButton1.Left = (GunaImageButton1.Left + (GunaImageButton1.Width * 0.025))
        GunaImageButton1.Height = (GunaImageButton1.Height - (GunaImageButton1.Height * 0.05))
        GunaImageButton1.Width = (GunaImageButton1.Width - (GunaImageButton1.Width * 0.05))
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GunaImageButton1.Top = (GunaImageButton1.Top - (GunaImageButton1.Height * 0.025))
        GunaImageButton1.Left = (GunaImageButton1.Left - (GunaImageButton1.Width * 0.025))
        GunaImageButton1.Height = (GunaImageButton1.Height + (GunaImageButton1.Height * 0.05))
        GunaImageButton1.Width = (GunaImageButton1.Width + (GunaImageButton1.Width * 0.05))
    End Sub
End Class