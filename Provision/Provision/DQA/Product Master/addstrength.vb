Imports System.Data
Imports System.Data.SqlClient
    Imports System.IO
    Public Class addstrength
        Dim cmd1 As New SqlCommand
        Dim cmd2 As New SqlCommand
    Private _filename As String = String.Empty
    Private Sub addproduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.Black, 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End Sub
        Public Sub dgv1_rowstyle()
            For i As Integer = 0 To DataGridView1.RowCount - 1
                If i Mod 2 = 0 Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
                Else
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
                End If

            Next
        End Sub
        Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
            dgv1_rowstyle()
        End Sub
        Private Sub DataGridView1_DataSourceChanged(sender As Object, e As System.EventArgs)
            dgv1_rowstyle()
        End Sub
        Private Sub GunaGradientButton1_Click_1(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
            If TextBox3.Text = "" Then
                MsgBox("Enter Product Code", vbCritical)
            ElseIf TextBox3.Text.Length < 3 Then
                MsgBox("Product Code should be in 3 digits", vbCritical)
            ElseIf TextBox4.Text = "" Then
                MsgBox("Enter Strength", vbCritical)
            ElseIf TextBox5.Text = "" Then
                MsgBox("Enter Label Claim", vbCritical)

            Else
                For i = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Rows(i).Cells(0).Value = TextBox3.Text Then
                        MsgBox("Product Code Already Added to List", vbCritical)
                        Exit Sub
                    ElseIf DataGridView1.Rows(i).Cells(1).Value = TextBox4.Text Then
                        MsgBox("Strength Already Added to List", vbCritical)
                        Exit Sub
                    ElseIf DataGridView1.Rows(i).Cells(2).Value = TextBox5.Text Then
                        MsgBox("Label Claim Already Added to List", vbCritical)
                        Exit Sub
                    End If
                Next
                DataGridView1.Rows.Add(TextBox3.Text, TextBox4.Text, TextBox5.Text)
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
            End If
            DataGridView1.CurrentCell = Nothing
        End Sub
        Dim ProductAddedby As String = homepagedqa.Label2.Text
        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            Try
            If TextBox1.Text = "" Then
                MsgBox("Enter Product Name", vbCritical)
            ElseIf TextBox2.Text = "" Then
                MsgBox("Enter Market", vbCritical)
            ElseIf DataGridView1.Rows.Count = 0 Then
                MsgBox("Product Code Not Found", vbCritical)
            ElseIf GunaLabel7.Text = "." Or GunaLabel7.Text = "" Then
                MsgBox("Upload Product Initiation Form", vbCritical)
            Else

                For i = 0 To DataGridView1.Rows.Count - 1
                    If con.State = ConnectionState.Open Then con.Close()
                    Dim qry1 As String
                    qry1 = "select COUNT(procode) from productmaster where procode='" + DataGridView1.Rows(i).Cells(0).Value + "'"
                    cmd2 = New SqlCommand(qry1, con)
                    con.Open()
                    Dim SameProductCode As Integer
                    SameProductCode = cmd2.ExecuteScalar()
                    If SameProductCode = 0 Then
                        If ProductAddedby = "User Type" Then
                            If con.State = ConnectionState.Open Then con.Close()
                            Dim cmd3 As New SqlCommand
                            cmd3.Connection = con
                            cmd3.CommandText = "insert into  productmaster(procode,proname,strength,market,client,label,productaddedby,productaddeddate,productstatus,pds,lnb) values('" + DataGridView1.Rows(i).Cells(0).Value + "','" + TextBox1.Text + "','" + DataGridView1.Rows(i).Cells(1).Value + "','" + TextBox2.Text + "','" + GunaLabel6.Text + "','" + DataGridView1.Rows(i).Cells(2).Value + "','" + homepage.Label1.Text + "',@productaddeddate,'Active','" + GunaLabel4.Text + "','No')"
                            cmd3.Parameters.AddWithValue("@productaddeddate", SqlDbType.Date).Value = DateTime.Now.Date
                            con.Open()
                            cmd3.ExecuteNonQuery()
                            con.Close()
                            Insert_ProductInitiation_Form()
                        Else
                            If con.State = ConnectionState.Open Then con.Close()
                            Dim cmd3 As New SqlCommand
                            cmd3.Connection = con
                            cmd3.CommandText = "insert into  productmaster(procode,proname,strength,market,client,label,productaddedby,productaddeddate,productstatus,pds,lnb) values('" + DataGridView1.Rows(i).Cells(0).Value + "','" + TextBox1.Text + "','" + DataGridView1.Rows(i).Cells(1).Value + "','" + TextBox2.Text + "','" + GunaLabel6.Text + "','" + DataGridView1.Rows(i).Cells(2).Value + "','" + homepagedqa.Label1.Text + "',@productaddeddate,'Active','" + GunaLabel4.Text + "','No')"
                            cmd3.Parameters.AddWithValue("@productaddeddate", SqlDbType.Date).Value = DateTime.Now.Date
                            con.Open()
                            cmd3.ExecuteNonQuery()
                            con.Close()
                            Insert_ProductInitiation_Form()
                        End If
                    Else
                        MsgBox("Product Code " + DataGridView1.Rows(i).Cells(0).Value + " is alreay Exist", vbCritical)
                    End If
                Next
                MsgBox("Strength Added Successfully", vbInformation)
                Dim f1 As viewproductdetailsdqa = DirectCast(Me.Owner, viewproductdetailsdqa)
                f1.LoadProductMaster()
                Me.Close()

            End If

        Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub
    Private Sub Insert_ProductInitiation_Form()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd3 As New SqlCommand
            cmd3.Connection = con
            cmd3.CommandText = "insert into productinitiationform(proname,market,client,attachmentname,attachment) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + GunaLabel6.Text + "','" + Path.GetFileName(_filename) + "',@attachment)"
            cmd2.Parameters.AddWithValue("@attachment", SqlDbType.VarBinary).Value = File.ReadAllBytes(GunaLabel7.Text)
            con.Open()
            cmd3.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GunaGradientButton2_Click(sender As Object, e As EventArgs) Handles GunaGradientButton2.Click
            Me.Close()
        End Sub

        Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
            'MsgBox(e.ColumnIndex)

        End Sub

        Private Sub GunaGradientButton3_Click(sender As Object, e As EventArgs) Handles GunaGradientButton3.Click
            If DataGridView1.SelectedRows.Count > 0 Then

                DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
            Else
                MessageBox.Show("Select 1 atleast one row to delete")
            End If
        End Sub

    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs) Handles GunaGradientButton4.Click
        With FileDialogs
            .FileName = ""
            .CheckFileExists = True : .CheckPathExists = True
            .Filter = "PDF Files (*.pdf)|*.pdf"
            .Multiselect = False : .ReadOnlyChecked = False
            .RestoreDirectory = True : .ShowHelp = False
            .Title = "Select File - Documnet Upload"
            .ShowDialog(Me)
            _filename = .FileName.ToString()
            GunaLabel7.Text = _filename

        End With
    End Sub
End Class