Imports System.Data
Imports System.Data.SqlClient
Public Class materialconsumption
    Dim da As New SqlDataAdapter()
    Private Sub materialconsumption_Load(sender As Object, e As EventArgs) Handles Me.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.FromArgb(4, 145, 199), 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

        Panel7.Visible=False
        Panel2.Visible = False
        Panel13.Visible = False
        Panel19.Visible = False
        Panel24.Visible = False
        Panel29.Visible = False

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "N" Or e.KeyChar = "n" Or e.KeyChar = "A" Or e.KeyChar = "a")
        End If

    End Sub
    Private Sub TextBox6_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            Dim qry As String
            qry = "SELECT * FROM productmaster where procode='" + TextBox1.Text + "' and productstatus='Active'"
            cmd = New SqlCommand(qry, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            da.Fill(table)
            If TextBox1.Text = "na" Or TextBox1.Text = "NA" Then
                TextBox2.Text = "NA"
                TextBox3.Text = "NA"
            ElseIf TextBox1.Text = "" Then
                TextBox2.Text = ""
                TextBox3.Text = ""
            ElseIf table.Rows.Count = 0 Then
                TextBox2.Text = ""
                TextBox3.Text = ""
            Else
                TextBox2.Text = table.Rows(0)(2).ToString()
                TextBox3.Text = table.Rows(0)(3).ToString()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text = "1" Then
            Panel7.Visible = True
            Load_Category()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Load_Category()
        Try

            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(category) from inventry_master where remainingqty<>'0' order by [category] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox3.Items.Add(dr("category"))
            End While
            dr.Close()
            con.Close()




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Try
            If ComboBox3.Text = "Active" Or ComboBox3.Text = "Solvents" Or ComboBox3.Text = "Capsule Shell" Or ComboBox3.Text = "HDPE Bottle" Or ComboBox3.Text = "Caps" Or ComboBox3.Text = "Blister" Or ComboBox3.Text = "Ampoules" Or ComboBox3.Text = "PFS" Or ComboBox3.Text = "Stoppers" Or ComboBox3.Text = "Seal" Or ComboBox3.Text = "Cartons" Then
                GunaComboBox1.Items.Clear()

                'Load Proname from development
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "select DISTINCT(material_name) from inventry_master where category='" + ComboBox3.Text + "' and remainingqty<>'0' order by [material_name] ASC"
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    GunaComboBox1.Items.Add(dr("material_name"))
                End While
                dr.Close()
                con.Close()
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox1.SelectedIndexChanged
        Try
            If ComboBox3.Text = "Active" Or ComboBox3.Text = "Solvents" Or ComboBox3.Text = "Capsule Shell" Or ComboBox3.Text = "HDPE Bottle" Or ComboBox3.Text = "Caps" Or ComboBox3.Text = "Blister" Or ComboBox3.Text = "Ampoules" Or ComboBox3.Text = "PFS" Or ComboBox3.Text = "Stoppers" Or ComboBox3.Text = "Seal" Or ComboBox3.Text = "Cartons" Then
                GunaComboBox2.Items.Clear()

                'Load Proname from development
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "select itemcode from inventry_master where category='" + ComboBox3.Text + "' and material_name='" + GunaComboBox1.Text + "' and remainingqty<>'0' order by [material_name] ASC"
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    GunaComboBox2.Items.Add(dr("itemcode"))
                End While
                dr.Close()
                con.Close()
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        If Label1.Text = "" Or Label1.Text = "." Then
            MsgBox("Select Material Code", vbCritical)
        Else
            Dim form As New morematerialdetails
            form.Label1.Text = Label1.Text
            form.ShowDialog()
        End If


    End Sub

    Private Sub GunaComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox2.SelectedIndexChanged
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim ds As DataSet = New DataSet
            Dim da As New SqlDataAdapter()
            Dim table As New DataTable()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            da = New SqlDataAdapter("Select id,remainingqty,unit from inventry_master where [itemcode]= '" + GunaComboBox2.Text + "' ", con)
            da.Fill(table)

            Label1.Text = table.Rows(0)(0).ToString
            GunaTextBox1.Text = table.Rows(0)(1).ToString + " " + table.Rows(0)(2).ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class