Imports System.Data.SqlClient
Public Class materialconsumpt
    Private Sub materialconsumpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.FromArgb(4, 145, 199), 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Enter Comsumption Qty", vbCritical)
            ' ElseIf TextBox2.Text = "" Then
            '  MsgBox("Enter Product Name", vbCritical)
            'ElseIf TextBox3.Text = "" Then
            ' MsgBox("Enter Batch Number", vbCritical)
        ElseIf TextBox4.Text = "" Then
            MsgBox("Enter Remarks", vbCritical)
        ElseIf Convert.ToDouble(TextBox1.Text) > Convert.ToDouble(Label2.Text) Then
            MsgBox("Cosumption qty should not be greater then available qty", vbCritical)
            'ElseIf Convert.ToDouble(TextBox1.Text) = Convert.ToDouble(Label2.Text) Then
            'MsgBox("Not allowed to remove Total Samples from the chamber directly.", vbCritical)
        Else
            Try
                Dim result As Integer = MessageBox.Show("Are you sure to consume this qty", "Confirmation before Update", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                If result = DialogResult.Yes Then
                    Dim availabelqty As Double = Label2.Text
                    Dim consumedqty As Double = TextBox1.Text
                    Dim remainingsample As Double = availabelqty - consumedqty

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("update inventry_master set [remainingqty]='" + remainingsample.ToString + "' where [id]= '" + Label1.Text + "' ", con)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    Dim Consumedby As String = Homepagefrdj.Label2.Text
                    If Consumedby = "User Type" Then
                        Consumedby = Homepagefrdgl.Label1.Text
                    Else
                        Consumedby = Homepagefrdj.Label1.Text
                    End If


                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd1 As New SqlCommand
                    cmd1.Connection = con
                    cmd1.CommandText = "insert into inventry_recon(ref_id,consumedqty,unit,proname,btn,remarks,consumedby,consumedon) values('" + Label1.Text + "','" + TextBox1.Text + "','" + GunaLabel3.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + Consumedby + "',@consumedon)"
                    cmd1.Parameters.AddWithValue("@consumedon", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd1.ExecuteNonQuery()
                    con.Close()
                    Dim f1 As viewmaterialconsumpdetails = DirectCast(Me.Owner, viewmaterialconsumpdetails)
                    f1.LoadMaterialDetails()
                    MsgBox("Material Consumed Successfully", vbInformation)
                    Me.Close()

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
        End If



    End Sub
End Class