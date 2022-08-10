Imports System.Data.SqlClient
Public Class issuerldsample
    Private Sub issuerldsample_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTest()
        LoadRLDDetails()
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
    End Sub
    Private Sub LoadTest()
        Try
            ComboBox1.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(test) from testmaster order by [test] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("test"))
            End While
            dr.Close()
            ComboBox1.Items.Add("NA")
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadRLDDetails()
        If con.State = ConnectionState.Open Then con.Close()
        con.Open()
        Dim qry1 As String
        qry1 = "select receivedqty,balanceqty from rld_master where id='" + Label1.Text + "'"
        cmd1 = New SqlCommand(qry1, con)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd1)
        Dim table As New DataTable()
        da.Fill(table)

        Label2.Text = table.Rows(0)(0).ToString
        Label3.Text = table.Rows(0)(1).ToString

    End Sub
    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        Dim senderComboBox As ComboBox = DirectCast(sender, ComboBox)
        Dim width As Integer = senderComboBox.DropDownWidth
        Dim g As Graphics = senderComboBox.CreateGraphics()
        Dim font As System.Drawing.Font = senderComboBox.Font
        Dim vertScrollBarWidth As Integer = If(senderComboBox.Items.Count > senderComboBox.MaxDropDownItems, SystemInformation.VerticalScrollBarWidth, 0)

        Dim newWidth As Integer
        For Each s As String In DirectCast(sender, ComboBox).Items
            newWidth = CInt(g.MeasureString(s, font).Width) + vertScrollBarWidth
            If width < newWidth Then
                width = newWidth
            End If
        Next s
        senderComboBox.DropDownWidth = width
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                MsgBox("Enter Sample Qty to Issue", vbCritical)
            ElseIf Convert.ToDouble(TextBox1.Text) > Convert.ToDouble(Label3.Text) Then
                MsgBox("Issued sample qty should not be greater then available sample qty", vbCritical)
            ElseIf ComboBox1.Text = "" Then
                MsgBox("Select Test", vbCritical)
            ElseIf TextBox2.Text = "" Then
                MsgBox("Enter Remarks", vbCritical)
            ElseIf Label4.Text = "." Or Label4.Text = "" Then
                MsgBox("Authenticate for Username.", vbCritical)
            Else
                Dim availablesample As Double = Label3.Text
                Dim issuesample As Double = TextBox1.Text
                Dim remainingsample As Double = availablesample - issuesample

                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand("update rld_master set [balanceqty]='" + remainingsample.ToString + "' where [ID]= '" + Label1.Text + "'", con)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd1 As New SqlCommand
                cmd1.Parameters.Clear()
                cmd1.Connection = con
                cmd1.CommandText = "insert into rld_recon(ref_id,sampleqty,test,remark,issuedby,issuedon,issuedto) values('" + Label1.Text + "','" + TextBox1.Text + "','" + ComboBox1.Text + "','" + TextBox2.Text + "','" + homepage.Label1.Text + "',@issuedon,'" + Label4.Text + "')"
                cmd1.Parameters.AddWithValue("@issuedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd1.ExecuteNonQuery()
                con.Close()

                MsgBox("Sample Issued Successfully", vbInformation)
                Dim f1 As viewrldmasterdata = DirectCast(Me.Owner, viewrldmasterdata)
                f1.LoadRLDDetails()
                Me.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New esignrld
        form.Owner = Me
        form.ShowDialog()
    End Sub
End Class