Imports System.Data.SqlClient
Public Class newcancelreqstb
    Private Sub newcancelreqstb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 20, 5, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadProductNameStb()
        LoadTestStb()
        LoadTRNumbers()
    End Sub
    Private Sub LoadTRNumbers()
        Try
            CheckedListBox1.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select (trno) from trstb where Status<>'Released' and Status<>'Data Uploaded' and Status<>'Cancel Request' and Status<>'Cancelled' order by [trno] DESC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                CheckedListBox1.Items.Add(dr("trno"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadProductNameStb()
        Try
            ComboBox1.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(productname) from trstb where Status<>'Released' and Status<>'Data Uploaded' and Status<>'Cancel Request' and Status<>'Cancelled' order by [productname] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("productname"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadTestStb()
        Try
            ComboBox2.Items.Clear()
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(test) from trstb where Status<>'Released' and Status<>'Data Uploaded' and Status<>'Cancel Request' and Status<>'Cancelled' order by [test] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr("test"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        CheckedListBox1.Items.Clear()
        If ComboBox2.Text = "" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "select (trno) from trstb where Status<>'Released' and Status<>'Data Uploaded' and Status<>'Cancel Request' and Status<>'Cancelled' and productname='" + ComboBox1.Text + "' order by [trno] DESC"
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    CheckedListBox1.Items.Add(dr("trno"))
                End While
                dr.Close()
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        ElseIf ComboBox2.Text <> "" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "select (trno) from trstb where Status<>'Released' and Status<>'Data Uploaded' and Status<>'Cancel Request' and Status<>'Cancelled' and productname='" + ComboBox1.Text + "' and test= '" + ComboBox2.Text + "'order by [trno] DESC"
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    CheckedListBox1.Items.Add(dr("trno"))
                End While
                dr.Close()
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        CheckedListBox1.Items.Clear()
        If ComboBox1.Text = "" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "select (trno) from trstb where Status<>'Released' and Status<>'Data Uploaded' and Status<>'Cancel Request' and Status<>'Cancelled' and test='" + ComboBox2.Text + "' order by [trno] DESC"
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    CheckedListBox1.Items.Add(dr("trno"))
                End While
                dr.Close()
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        ElseIf ComboBox1.Text <> "" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "select (trno) from trstb where Status<>'Released' and Status<>'Data Uploaded' and Status<>'Cancel Request' and Status<>'Cancelled' and productname='" + ComboBox1.Text + "' and test= '" + ComboBox2.Text + "'order by [trno] DESC"
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    CheckedListBox1.Items.Add(dr("trno"))
                End While
                dr.Close()
                con.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        If CheckedListBox1.CheckedItems.Count < 1 Then
            MsgBox("You must select at least one TR Number to Cancel", vbCritical)
        Else
            Dim result As Integer = MessageBox.Show("Are you sure to Submit this for Cancel", "Confirmation before submit", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If result = DialogResult.Yes Then
                For i As Integer = 0 To CheckedListBox1.CheckedItems.Count - 1

                    Try
                        For Each item In CheckedListBox1.Items
                            If con.State = ConnectionState.Open Then con.Close()
                            Dim cmd1 As New SqlCommand
                            cmd1.Connection = con
                            cmd1.CommandText = "update trstb set creqstatus='Cancel Request',creqby='" + Homepagefrdj.Label1.Text + "',creqdate=@creqdate where trno='" + CheckedListBox1.CheckedItems(i) + "'"
                            cmd1.Parameters.AddWithValue("@creqdate", SqlDbType.Date).Value = DateTime.Now.Date
                            con.Open()
                            cmd1.ExecuteNonQuery()
                        Next

                        Dim f1 As viewcancelintstb = DirectCast(Me.Owner, viewcancelintstb)
                        f1.LoadCancelIntimationsStb()
                        Me.Close()
                        MsgBox("Cancel Request Submitted", vbInformation)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try

                Next
            End If
        End If
    End Sub
    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        Me.Close()
    End Sub

    Private Sub GunaCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBox1.CheckedChanged
        If GunaCheckBox1.Checked = True Then
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, True)
            Next
        ElseIf GunaCheckBox1.Checked = False Then
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, False)
            Next
        End If
    End Sub
End Class