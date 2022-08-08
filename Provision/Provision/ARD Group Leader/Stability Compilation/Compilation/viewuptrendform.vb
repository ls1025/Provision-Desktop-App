Public Class viewuptrendform
    Private Sub viewuptrendform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form As New updatestbcompilation
        form.TextBox2.Text = Label1.Text
        form.ShowDialog()
        Me.Close()
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New exportstbcompilation
        form.Label1.Text = Label1.Text
        form.ShowDialog()
        Me.Close()

    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Dim form As New viewtrend
        form.Label1.Text = Label1.Text
        form.ShowDialog()
        Me.Close()
    End Sub
End Class