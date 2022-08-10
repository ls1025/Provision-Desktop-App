Imports System.ComponentModel
Imports System.Data.SqlClient
Imports Zuby.ADGV

Public Class viewmaterialdetails
    Private WithEvents pic As New Guna.UI.WinForms.GunaGradientButton
    Private WithEvents conutlabel As New Label
    Private Sub viewmaterialdetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)
        LoadMaterialDetails()
    End Sub
    Public Sub LoadMaterialDetails()
        If Label2.Text = "Total Stock" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                con.Open()
                Dim ds As DataSet = New DataSet
                Dim adapter As New SqlDataAdapter
                Dim sql As String
                sql = "Select [id],[itemcode],[material_name],[gen_name],[brand_name],[btn],[mfg],[exp],[retest],[manufby],[supplby],[dep],(CAST(recievedqty AS varchar)+' '+CAST(unit AS varchar) +' '+CAST(sampletype AS varchar)) AS 'recievedqty',[po],(CAST(remainingqty AS varchar)+' '+CAST(unit AS varchar)) AS 'remainingqty',[eachprice],[totalprice],[erpcode],[location],[descrpt] from inventry_master where remainingqty<>'0' and category='" + Label3.Text + "' and unit='" + Label4.Text + "' order by [addedon] DESC"
                adapter.SelectCommand = New SqlCommand(sql, con)
                adapter.Fill(ds, sql)
                AdvancedDataGridView1.DataSource = ds.Tables(sql)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        ElseIf Label2.Text = "Low Stock" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                con.Open()
                Dim ds As DataSet = New DataSet
                Dim adapter As New SqlDataAdapter
                Dim sql As String
                sql = "Select [id],[itemcode],[material_name],[gen_name],[brand_name],[btn],[mfg],[exp],[retest],[manufby],[supplby],[dep],(CAST(recievedqty AS varchar)+' '+CAST(unit AS varchar) +' '+CAST(sampletype AS varchar)) AS 'recievedqty',[po],(CAST(remainingqty AS varchar)+' '+CAST(unit AS varchar)) AS 'remainingqty',[eachprice],[totalprice],[erpcode],[location],[descrpt] from inventry_master where remainingqty<>'0' and remainingqty<=(recievedqty*10/100) and category='" + Label3.Text + "' and unit='" + Label4.Text + "' order by [addedon] DESC"
                adapter.SelectCommand = New SqlCommand(sql, con)
                adapter.Fill(ds, sql)
                AdvancedDataGridView1.DataSource = ds.Tables(sql)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        ElseIf Label2.Text = "Out of Stock" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                con.Open()
                Dim ds As DataSet = New DataSet
                Dim adapter As New SqlDataAdapter
                Dim sql As String
                sql = "Select [id],[itemcode],[material_name],[gen_name],[brand_name],[btn],[mfg],[exp],[retest],[manufby],[supplby],[dep],(CAST(recievedqty AS varchar)+' '+CAST(unit AS varchar) +' '+CAST(sampletype AS varchar)) AS 'recievedqty',[po],(CAST(remainingqty AS varchar)+' '+CAST(unit AS varchar)) AS 'remainingqty',[eachprice],[totalprice],[erpcode],[location],[descrpt] from inventry_master where remainingqty='0' and category='" + Label3.Text + "' and unit='" + Label4.Text + "' order by [addedon] DESC"
                adapter.SelectCommand = New SqlCommand(sql, con)
                adapter.Fill(ds, sql)
                AdvancedDataGridView1.DataSource = ds.Tables(sql)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        ElseIf Label2.Text = "Most Consumed Stock" Then
        ElseIf Label2.Text = "Raw Material" Or Label1.Text = "Packaging Material" Then
            Try
                If con.State = ConnectionState.Open Then con.Close()
                con.Open()
                Dim ds As DataSet = New DataSet
                Dim adapter As New SqlDataAdapter
                Dim sql As String
                sql = "Select [id],[itemcode],[material_name],[gen_name],[brand_name],[btn],[mfg],[exp],[retest],[manufby],[supplby],[dep],(CAST(recievedqty AS varchar)+' '+CAST(unit AS varchar) +' '+CAST(sampletype AS varchar)) AS 'recievedqty',[po],(CAST(remainingqty AS varchar)+' '+CAST(unit AS varchar)) AS 'remainingqty',[eachprice],[totalprice],[erpcode],[location],[descrpt] from inventry_master where type='" + Label2.Text + "' and category='" + Label3.Text + "' and unit='" + Label4.Text + "' and remainingqty<>'0' and category='" + Label3.Text + "' and unit='" + Label4.Text + "' order by [addedon] DESC"
                adapter.SelectCommand = New SqlCommand(sql, con)
                adapter.Fill(ds, sql)
                AdvancedDataGridView1.DataSource = ds.Tables(sql)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
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
                Try
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry1 As String
                    qry1 = "select coa from inventry_master where id='" + AdvancedDataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString() + "'"
                    cmd = New SqlCommand(qry1, con)
                    Dim sFilePath As String
                    Dim buffer As Byte()
                    con.Open()
                    buffer = cmd.ExecuteScalar()
                    con.Close()
                    sFilePath = System.IO.Path.GetTempFileName()
                    System.IO.File.Move(sFilePath, System.IO.Path.ChangeExtension(sFilePath, ".pdf"))
                    sFilePath = System.IO.Path.ChangeExtension(sFilePath, ".pdf")
                    System.IO.File.WriteAllBytes(sFilePath, buffer)
                    Dim act As Action(Of String) = New Action(Of String)(AddressOf OpenPDFFile)
                    act.BeginInvoke(sFilePath, Nothing, Nothing)
                Catch ex As Exception
                    MsgBox("Not Available", vbExclamation)
                End Try
            End If
        End If
    End Sub
    Private Shared Sub OpenPDFFile(ByVal sFilePath)
        Using p As New System.Diagnostics.Process
            p.StartInfo = New System.Diagnostics.ProcessStartInfo(sFilePath)
            p.Start()
            p.WaitForExit()
            Try
                System.IO.File.Delete(sFilePath)
            Catch
            End Try
        End Using
    End Sub
    Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
        LoadMaterialDetails()
    End Sub
    Private Sub AdvancedDataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles AdvancedDataGridView1.CellClick
        ' MsgBox(e.ColumnIndex)
    End Sub
End Class