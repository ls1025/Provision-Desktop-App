Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class viewdocdetails
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton
    Private WithEvents conutlabel As New Label
    Private Sub viewdocdetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadDocumentDetails()
    End Sub
    Private Sub viewdocdetails_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim f1 As viewhandoverdcatogery = DirectCast(Me.Owner, viewhandoverdcatogery)
        f1.Load_Handover_Docs()

    End Sub
    Public Sub LoadDocumentDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("Select [id],[docname],[docno],[test],[verstatus],[remarks],[handoverby],[recievedby],[recieveddate] from archival_master where [doctype]='" + Label1.Text + "' and [catogery]='" + Label2.Text + "' and status='handover' order by [docno] DESC")
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

        If e.ColumnIndex = 0 Then
            If CheckBox1.Checked = True Then
                CheckBox1.Checked = False
            ElseIf CheckBox1.Checked = False Then
                CheckBox1.Checked = True
            End If

            If CheckBox1.Checked = True Then
                Dim i As Integer = 0
                For i = 0 To DataGridView1.RowCount - 1
                    DataGridView1.Rows(i).Cells(0).Value = True
                Next
            ElseIf CheckBox1.Checked = False Then
                Dim i As Integer = 0
                For i = 0 To DataGridView1.RowCount - 1
                    DataGridView1.Rows(i).Cells(0).Value = False
                Next
            End If
        End If
    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles DataGridView1.DataSourceChanged
        dgv1_rowstyle()
    End Sub
    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs)
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
    Private Sub ComboBox2_DropDown(ByVal sender As Object, ByVal e As System.EventArgs)
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
            GunaTextBox1.Text = DataGridView1.SelectedCells(6).Value
            Label3.Text = DataGridView1.SelectedCells(7).Value
            Label4.Text = DataGridView1.SelectedCells(8).Value
            Label5.Text = DataGridView1.SelectedCells(9).Value
        End If
    End Sub
    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click

        Dim form As New archivedoc
        For i As Integer = 0 To DataGridView1.Rows.Count() - 1
            Dim check As Boolean = DataGridView1.Rows(i).Cells(0).Value
            If check = True Then
                Dim row As DataGridViewRow = DataGridView1.Rows(i)
                form.ListBox1.Items.Add(row.Cells(3).Value.ToString)
                form.ListBox2.Items.Add(row.Cells(1).Value.ToString)
            End If
        Next
        form.Owner = Me
        form.ShowDialog()

    End Sub
    Private Sub GunaGradientButton5_Click(sender As Object, e As EventArgs) Handles GunaGradientButton5.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            Dim form As New updatehandoverdocdetial
            form.Label1.Text = DataGridView1.SelectedCells(1).Value
            form.Owner = Me
            form.ShowDialog()
        End If
    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            Dim form As New returnforcorrections
            form.Label1.Text = DataGridView1.SelectedCells(1).Value
            form.Owner = Me
            form.ShowDialog()
        End If
    End Sub
End Class