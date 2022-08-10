Imports System.Data.SqlClient
Public Class issuepartwithsample
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Enter sample Qty to Issue", vbCritical)
        ElseIf TextBox2.Text = "" Then
            MsgBox("Enter Reference AR No.", vbCritical)
        ElseIf TextBox3.Text = "" Then
            MsgBox("Enter remarks", vbCritical)
        ElseIf Convert.ToDouble(TextBox1.Text) > Convert.ToDouble(Label2.Text) Then
            MsgBox("Issued sample qty should not be greater then Total sample qty", vbCritical)
            'ElseIf Convert.ToDouble(TextBox1.Text) = Convert.ToDouble(Label2.Text) Then
            'MsgBox("Not allowed to remove Total Samples from the chamber directly.", vbCritical)
        Else
            Try
                Dim result As Integer = MessageBox.Show("Are you to Update the details", "Confirmation before Update", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                If result = DialogResult.Yes Then
                    Dim toatalsample As Double = Label2.Text
                    Dim issuesample As Double = TextBox1.Text

                    Dim remainingsample As Double = toatalsample - issuesample

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("update plnr_partwith set [remainqty]='" + remainingsample.ToString + "' where [ref_id]= '" + Label1.Text + "' ", con)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd1 As New SqlCommand
                    cmd1.Connection = con
                    cmd1.CommandText = "insert into recon(ref_id,sampleqty,reftr,remark,issuedby,issuedon) values('" + Label1.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + homepage.Label1.Text + "',@issuedon)"
                    cmd1.Parameters.AddWithValue("@issuedon", SqlDbType.Date).Value = DateTime.Now.Date
                    con.Open()
                    cmd1.ExecuteNonQuery()
                    con.Close()
                    Dim f1 As viewpartwithsample = DirectCast(Me.Owner, viewpartwithsample)
                    f1.LaodPartWithdrawalSample()
                    MsgBox("Sample Issued Successfully", vbInformation)
                    Me.Close()

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub issuepartwithsample_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class