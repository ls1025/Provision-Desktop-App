Imports System.Data.SqlClient
Public Class updatechrgdetails
    Dim da As New SqlDataAdapter()
    Dim dt As New DataTable()
    Private Sub updatechrgdetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadDetails()
    End Sub
    Private Sub LoadDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim cmd As New SqlCommand
            cmd.Connection = con

            da = New SqlDataAdapter("Select * from plnr where [ID]= '" + Label1.Text + "' ", con)
            Dim table As New DataTable()
            da.Fill(table)

            'Product Name
            Label2.Text = table.Rows(0)(1).ToString() + " " + table.Rows(0)(2).ToString()
            'Condition
            TextBox1.Text = table.Rows(0)(3).ToString()
            'Batch No.
            TextBox2.Text = table.Rows(0)(4).ToString()
            'Pack Type
            TextBox4.Text = table.Rows(0)(5).ToString()
            'Pack Count
            TextBox5.Text = table.Rows(0)(6).ToString()
            'Charging Box Number
            TextBox6.Text = table.Rows(0)(7).ToString()
            'Charging Date
            If table.Rows(0)(8).ToString = "" Then
                Label3.Text = ""
            Else
                Dim chrgdate As Date = Date.ParseExact(table.Rows(0)(8), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label3.Text = chrgdate
            End If

            'Protocol No.
            TextBox3.Text = table.Rows(0)(9).ToString()
            'Period
            Label4.Text = table.Rows(0)(10).ToString()
            'Withdrawal date
            If table.Rows(0)(11).ToString = "" Then
                Label5.Text = ""
            Else
                Dim withdate As Date = Date.ParseExact(table.Rows(0)(11), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label5.Text = withdate
            End If
            'Withdrawal Box No.
            'TextBox7.Text = table.Rows(0)(12).ToString()
            'Remarks
            ' TextBox8.Text = table.Rows(0)(13).ToString()
            'Total Sample Qty
            TextBox7.Text = table.Rows(0)(16).ToString()
            'Available Sample Qty
            TextBox8.Text = table.Rows(0)(17).ToString()
            'Added By
            Label6.Text = table.Rows(0)(18).ToString()
            'Added On
            If table.Rows(0)(19).ToString = "" Then
                Label7.Text = ""
            Else
                Dim AddedOn As Date = Date.ParseExact(table.Rows(0)(19), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                Label7.Text = AddedOn
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim result As Integer = MessageBox.Show("Are you to Update the details", "Confirmation before Update", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If result = DialogResult.Yes Then
            Try

                If TextBox7.Text = "" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("update plnr set [cndn]='" + TextBox1.Text + "',[btn]='" + TextBox2.Text + "',[pctyp]='" + TextBox4.Text + "',[pccnt]='" + TextBox5.Text + "',[chrgbox]='" + TextBox6.Text + "',[ptn]='" + TextBox3.Text + "', where [ID]= " & Label1.Text & "", con)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf TextBox8.Text = "" Then
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("update plnr set [cndn]='" + TextBox1.Text + "',[btn]='" + TextBox2.Text + "',[pctyp]='" + TextBox4.Text + "',[pccnt]='" + TextBox5.Text + "',[chrgbox]='" + TextBox6.Text + "',[ptn]='" + TextBox3.Text + "',[availsampleqty]='" + TextBox8.Text + "' where [ID]= " & Label1.Text & "", con)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim cmd As New SqlCommand("update plnr set [cndn]='" + TextBox1.Text + "',[btn]='" + TextBox2.Text + "',[pctyp]='" + TextBox4.Text + "',[pccnt]='" + TextBox5.Text + "',[chrgbox]='" + TextBox6.Text + "',[ptn]='" + TextBox3.Text + "',[totalsampleqty]='" + TextBox7.Text + "',[availsampleqty]='" + TextBox8.Text + "' where [ID]= " & Label1.Text & "", con)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If

                '  Dim f1 As viewcorrections = DirectCast(Me.Owner, viewcorrections)
                '  f1.loadplnr()

                MsgBox("Updated Successfully", vbInformation)
                Me.Close()
            Catch ex As Exception

            End Try
        End If


    End Sub

    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Me.Close()
    End Sub
End Class