Imports System.ComponentModel
Imports System.Data.SqlClient
Imports Zuby.ADGV

Public Class viewarchivedocdetails
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton
    Private WithEvents conutlabel As New Label
    Private Sub viewarchivedocdetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ProvisionDataSet11.archival_master' table. You can move, or remove it, as needed.
        ' Me.Archival_masterTableAdapter.Fill(Me.ProvisionDataSet11.archival_master)
        'TODO: This line of code loads data into the 'ProvisionDataSet1.archival_master' table. You can move, or remove it, as needed.
        ' Me.Archival_masterTableAdapter.Fill(Me.ProvisionDataSet1.archival_master)

        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadDocumentDetails()


    End Sub

    Public Sub LoadDocumentDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            Dim ds As DataSet = New DataSet
            Dim adapter As New SqlDataAdapter
            Dim sql As String

            sql = "Select [id],[docname],[docno],[test],[verstatus],[handoverby],[recievedby],[recieveddate],[arcno],[location],[remarks],[archivedby],[archiveddate] from archival_master where [doctype]='" + Label1.Text + "' and [catogery]='" + Label2.Text + "' and status='archived' order by [docno] DESC"

            adapter.SelectCommand = New SqlCommand(sql, con)
            adapter.Fill(ds, sql)
            AdvancedDataGridView1.DataSource = ds.Tables(sql)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub AdvancedDataGridView1_SortStringChanged(sender As Object, e As AdvancedDataGridView.SortEventArgs) Handles AdvancedDataGridView1.SortStringChanged
        '  Me.ArchivalmasterBindingSource1.Sort = Me.AdvancedDataGridView1.SortString
    End Sub
    Private Sub AdvancedDataGridView1_FilterStringChanged(sender As Object, e As AdvancedDataGridView.SortEventArgs)
        'Me.ArchivalmasterBindingSource1.Filter = Me.AdvancedDataGridView1.FilterString
    End Sub
    Public Sub dgv1_rowstyle()
        For i As Integer = 0 To AdvancedDataGridView1.RowCount - 1
            If i Mod 2 = 0 Then
                AdvancedDataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            Else
                AdvancedDataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
            End If

        Next
        AdvancedDataGridView1.CurrentCell = Nothing
    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles AdvancedDataGridView1.ColumnHeaderMouseClick
        dgv1_rowstyle()
    End Sub
    Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs) Handles AdvancedDataGridView1.DataSourceChanged
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
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles AdvancedDataGridView1.CellClick
        If AdvancedDataGridView1.SelectedCells.Count > 0 Then

            Label3.Text = AdvancedDataGridView1.SelectedCells(5).Value
            Label4.Text = AdvancedDataGridView1.SelectedCells(6).Value
            Label5.Text = AdvancedDataGridView1.SelectedCells(7).Value
            Label6.Text = AdvancedDataGridView1.SelectedCells(11).Value
            Label7.Text = AdvancedDataGridView1.SelectedCells(12).Value

        End If
    End Sub
    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
        If AdvancedDataGridView1.SelectedCells.Count > 0 Then
            Dim form As New issuedocument
            'Ref_id
            form.Label2.Text = AdvancedDataGridView1.SelectedCells(0).Value
            'Doc Type
            form.Label3.Text = Label1.Text
            'Catogery
            form.Label4.Text = Label2.Text
            'Docname
            form.Label5.Text = AdvancedDataGridView1.SelectedCells(1).Value
            'Doc Number
            form.Label6.Text = AdvancedDataGridView1.SelectedCells(2).Value
            'Archival No.
            form.Label7.Text = AdvancedDataGridView1.SelectedCells(9).Value
            'Location
            form.Label8.Text = AdvancedDataGridView1.SelectedCells(10).Value
            form.Owner = Me
            form.ShowDialog()
        End If
    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        If AdvancedDataGridView1.SelectedCells.Count > 0 Then
            Dim form As New viewissuancehistory
            form.Label1.Text = AdvancedDataGridView1.SelectedCells(0).Value
            form.Owner = Me
            form.ShowDialog()
        End If
    End Sub
    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        If AdvancedDataGridView1.SelectedCells.Count > 0 Then
            Dim form As New changelocation
            form.Label1.Text = AdvancedDataGridView1.SelectedCells(0).Value
            form.Owner = Me
            form.ShowDialog()
        End If
    End Sub
    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs) Handles GunaGradientButton4.Click
        LoadDocumentDetails()
    End Sub
    Private Sub GunaGradientButton5_Click(sender As Object, e As EventArgs) Handles GunaGradientButton5.Click
        If AdvancedDataGridView1.SelectedCells.Count > 0 Then
            If homepage.Label2.Text = "GL" Then
                Dim form As New updatedocdetial
                form.Label1.Text = AdvancedDataGridView1.SelectedCells(0).Value
                form.Owner = Me
                form.ShowDialog()
            Else
                MsgBox("Access Denied", vbCritical)
            End If


        End If
    End Sub
End Class