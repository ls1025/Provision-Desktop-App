Imports System.ComponentModel
Imports System.Data.SqlClient
Imports Zuby.ADGV

Public Class viewmaterialconsumpdetails
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton
    Private WithEvents conutlabel As New Label
    Private Sub viewmaterialconsumpdetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadMaterialDetails()
    End Sub
    Public Sub LoadMaterialDetails()

        Try
            If con.State = ConnectionState.Open Then con.Close()
            con.Open()
            Dim ds As DataSet = New DataSet
            Dim adapter As New SqlDataAdapter
            Dim sql As String
            sql = "Select [id],[itemcode],[material_name],[gen_name],[brand_name],[btn],[mfg],[exp],[retest],[manufby],[supplby],(CAST(recievedqty AS varchar)+' '+CAST(unit AS varchar) +' '+CAST(sampletype AS varchar)) AS 'recievedqty',remainingqty,unit,[location] from inventry_master where remainingqty<>'0' and category='" + Label3.Text + "' and unit='" + Label4.Text + "' order by [addedon] DESC"
            adapter.SelectCommand = New SqlCommand(sql, con)
            adapter.Fill(ds, sql)
            AdvancedDataGridView1.DataSource = ds.Tables(sql)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Try
            For i As Integer = 2 To 10
                Dim j = i
                If AdvancedDataGridView1.Rows.Cast(Of DataGridViewRow)().All(Function(row) row.Cells(j).Value Is DBNull.Value) Then
                    'The column is empty.
                    AdvancedDataGridView1.Columns(i).Visible = False
                ElseIf AdvancedDataGridView1.Rows.Cast(Of DataGridViewRow)().All(Function(row) row.Cells(j).Value = "") Then
                    'The column is empty.
                    AdvancedDataGridView1.Columns(i).Visible = False
                End If
            Next
        Catch ex As Exception
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
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles AdvancedDataGridView1.CellClick
        If AdvancedDataGridView1.SelectedCells.Count > 0 Then
            If e.ColumnIndex = 0 Then
                Dim form As New materialconsumpt
                form.Label1.Text = AdvancedDataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString()
                form.Label2.Text = AdvancedDataGridView1.Rows(e.RowIndex).Cells(14).Value.ToString()
                form.Label3.Text = AdvancedDataGridView1.Rows(e.RowIndex).Cells(15).Value.ToString()
                form.Owner = Me
                form.ShowDialog()

            ElseIf e.ColumnIndex = 1 Then
                Dim form As New viewmaterialreconciliation
                form.Label1.Text = AdvancedDataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString()
                form.GunaLabel9.Text = AdvancedDataGridView1.Rows(e.RowIndex).Cells(14).Value.ToString()
                form.Label2.Text = AdvancedDataGridView1.Rows(e.RowIndex).Cells(15).Value.ToString()

                form.ShowDialog()
            End If
        End If
    End Sub

    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        LoadMaterialDetails()
    End Sub
    Private Sub AdvancedDataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles AdvancedDataGridView1.CellClick
        'MsgBox(e.ColumnIndex)
    End Sub

End Class