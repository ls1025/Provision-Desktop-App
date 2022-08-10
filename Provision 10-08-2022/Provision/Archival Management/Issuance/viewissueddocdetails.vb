Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class viewissueddocdetails
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton
    Private WithEvents conutlabel As New Label
    Private Sub viewissueddocdetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadDocumentDetails()
        Load_DocumentName()
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
    End Sub
    Private Sub Load_DocumentName()
        Try
            ComboBox1.Items.Clear()
            ComboBox1.Items.Add("Search by Document Name")
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(docname) from archival_issuance where [doctype]='" + Label1.Text + "' and [catogery]='" + Label2.Text + "' and [returnedby] IS NULL order by [docname] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox1.Items.Add(dr("docname"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Load_DocumentNumber()
        ComboBox2.SelectedIndex = 0
    End Sub
    Private Sub Load_DocumentNumber()
        Try
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("Search by Document Number")
            If con.State = ConnectionState.Open Then con.Close()
            'Dim reader As SqlDataReader

            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(docno) from archival_issuance where [doctype]='" + Label1.Text + "' and [catogery]='" + Label2.Text + "' and [docname]='" + ComboBox1.Text + "' and [returnedby] IS NULL order by [docno] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr("docno"))
            End While
            dr.Close()

            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LoadDocumentDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select [id],[ref_id],[docname],[docno],[arcno],[location],[issuedby],[issuedto],[issueddate],[remark],[status] from archival_issuance where [doctype]='" + Label1.Text + "' and [catogery]='" + Label2.Text + "' and [returnedby] IS NULL order by [id] DESC")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
            dgv1_rowstyle()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub dgv1_rowstyle()
        For i As Integer = 0 To DataGridView1.RowCount - 1
            If i Mod 2 = 0 Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If

        Next
        DataGridView1.CurrentCell = Nothing
    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.DataSourceChanged
        dgv1_rowstyle()
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
    Private Sub ComboBox2_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.DropDown
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
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.SelectedCells.Count > 0 Then
            GunaTextBox1.Text = DataGridView1.SelectedCells(9).Value
            Label3.Text = DataGridView1.SelectedCells(6).Value
            Label4.Text = DataGridView1.SelectedCells(7).Value
            Label5.Text = DataGridView1.SelectedCells(8).Value
            Label6.Text = DataGridView1.SelectedCells(10).Value
        End If
    End Sub
    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            Dim form As New returndocument
            form.Label2.Text = DataGridView1.SelectedCells(0).Value
            form.Owner = Me
            form.ShowDialog()
        End If
    End Sub

    Private Sub viewissueddocdetails_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim f1 As viewissuedoccatogery = DirectCast(Me.Owner, viewissuedoccatogery)
        f1.Load_Handover_Docs()

    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        If GunaTextBox1.Text = "" Then
            MsgBox("Enter Remarks", vbCritical)
        Else
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "update archival_master set [remarks]='" + GunaTextBox1.Text + "' where [id]='" + DataGridView1.SelectedCells(0).Value.ToString + "'"
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox("Remark Updated Successfully", vbInformation)
            LoadDocumentDetails()
        End If
    End Sub
End Class