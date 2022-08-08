Imports System.Data.SqlClient
Public Class inventrydashboard
    Private Sub inventrydashboard_Load(sender As Object, e As EventArgs) Handles Me.Load


        LoadTotalStockCount()
        LoadTotalStockDetails()
        LoadOutofStockCount()
        LoadLowStockCount()
        LoadRawmaterialCount()
        LoadPackagingmaterialCount()
    End Sub
    '=======Total Stock=============
    Private Sub LoadTotalStockCount()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry As String
            qry = "select COUNT(*) from inventry_master where remainingqty<>'0'"
            cmd1 = New SqlCommand(qry, con)
            con.Open()

            AButton2.Text = "Total Stock" + Environment.NewLine + Environment.NewLine + cmd1.ExecuteScalar().ToString

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadTotalStockDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("select category,COUNT(*) AS 'itemlist',(CAST(SUM(recievedqty) AS varchar)+' '+CAST(unit AS varchar)) AS 'recievedqty',(CAST(SUM(remainingqty) AS varchar)+' '+CAST(unit AS varchar)) AS 'remainingqty',SUM(totalprice) AS 'price' from inventry_master where remainingqty<>'0' group by category,unit order by [category] ASC")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
            ' DataGridView1.CurrentCell = Nothing
            Label1.Text = "Total Stock"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    '=======Low Stock=============
    Private Sub LoadLowStockCount()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry As String
            qry = "select COUNT(*) from inventry_master where remainingqty<>'0' and remainingqty<=(recievedqty*10/100)"
            cmd1 = New SqlCommand(qry, con)
            con.Open()

            GunaAdvenceButton1.Text = "Low Stock" + Environment.NewLine + Environment.NewLine + cmd1.ExecuteScalar().ToString

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadLowStockDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("select category,COUNT(*) AS 'itemlist',(CAST(SUM(recievedqty) AS varchar)+' '+CAST(unit AS varchar)) AS 'recievedqty',(CAST(SUM(remainingqty) AS varchar)+' '+CAST(unit AS varchar)) AS 'remainingqty',SUM(totalprice) AS 'price' from inventry_master where remainingqty<>'0' and remainingqty<=(recievedqty*10/100) group by category,unit order by [category] ASC")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
            Label1.Text = "Low Stock"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    '=======Out of Stock=============
    Private Sub LoadOutofStockCount()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry As String
            qry = "select COUNT(*) from inventry_master where remainingqty='0'"
            cmd1 = New SqlCommand(qry, con)
            con.Open()

            GunaAdvenceButton2.Text = "Out of Stock" + Environment.NewLine + Environment.NewLine + cmd1.ExecuteScalar().ToString

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadOutofStockDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("select category,COUNT(*) AS 'itemlist',(CAST(SUM(recievedqty) AS varchar)+' '+CAST(unit AS varchar)) AS 'recievedqty',(CAST(SUM(remainingqty) AS varchar)+' '+CAST(unit AS varchar)) AS 'remainingqty',SUM(totalprice) AS 'price' from inventry_master where remainingqty='0' group by category,unit order by [category] ASC")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
            Label1.Text = "Out of Stock"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    '=======Most Consumed Stock=============

    '=======Ram Materials=============
    Private Sub LoadRawmaterialCount()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry As String
            qry = "select COUNT(*) from inventry_master where remainingqty<>'0' and type='Raw Material'"
            cmd1 = New SqlCommand(qry, con)
            con.Open()

            GunaAdvenceButton4.Text = "RM " + cmd1.ExecuteScalar().ToString

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadRawmaterialDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("select category,COUNT(*) AS 'itemlist',(CAST(SUM(recievedqty) AS varchar)+' '+CAST(unit AS varchar)) AS 'recievedqty',(CAST(SUM(remainingqty) AS varchar)+' '+CAST(unit AS varchar)) AS 'remainingqty',SUM(totalprice) AS 'price' from inventry_master where remainingqty<>'0' and type='Raw Material' group by category,unit order by [category] ASC")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
            Label1.Text = "Raw Material"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    '=======Packaging Materials=============
    Private Sub LoadPackagingmaterialCount()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim qry As String
            qry = "select COUNT(*) from inventry_master where remainingqty<>'0' and type='Packaging Material'"
            cmd1 = New SqlCommand(qry, con)
            con.Open()

            GunaAdvenceButton5.Text = "PM " + cmd1.ExecuteScalar().ToString

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadPackagingmaterialDetails()
        Try
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand("select category,COUNT(*) AS 'itemlist',(CAST(SUM(recievedqty) AS varchar)+' '+CAST(unit AS varchar)) AS 'recievedqty',(CAST(SUM(remainingqty) AS varchar)+' '+CAST(unit AS varchar)) AS 'remainingqty',SUM(totalprice) AS 'price' from inventry_master where remainingqty<>'0' and type='Packaging Material' group by category,unit order by [category] ASC")
            cmd.Connection = con
            Dim adapter1 As New SqlDataAdapter(cmd)
            Dim table1 As New DataTable()
            adapter1.Fill(table1)
            DataGridView1.DataSource = table1
            Label1.Text = "Packaging Material"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub ShowSubmenuMaster(ByVal submenu As Panel)
        If submenu.Visible = False Then
            HideShowSubMenuMaster()
            submenu.Visible = True
        Else
            submenu.Visible = False
        End If
    End Sub
    Private Sub HideShowSubMenuMaster()
        If Panel2.Visible <> True Then
            Panel2.Visible = False
        End If
    End Sub
    Private Sub Master_Click(sender As Object, e As EventArgs) Handles Master.Click
        Panel3.Visible = False
        ShowSubmenuMaster(Panel2)
    End Sub
    Private Sub Master_MouseHover(sender As Object, e As EventArgs) Handles Master.MouseHover
        Panel3.Visible = False
        ShowSubmenuMaster(Panel2)
    End Sub
    Private Sub ShowSubmenuGeneral(ByVal submenu As Panel)
        If submenu.Visible = False Then
            HideShowSubMenuGeneral()
            submenu.Visible = True
        Else
            submenu.Visible = False
        End If
    End Sub
    Private Sub HideShowSubMenuGeneral()
        If Panel3.Visible <> True Then
            Panel3.Visible = False
        End If
    End Sub
    Private Sub General_Click(sender As Object, e As EventArgs) Handles General.Click
        Panel2.Visible = False
        ShowSubmenuGeneral(Panel3)
    End Sub
    Private Sub General_MouseHover(sender As Object, e As EventArgs) Handles General.MouseHover
        Panel2.Visible = False
        ShowSubmenuGeneral(Panel3)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form As New viewbrandmaster
        form.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim form As New viewgenmaster
        form.ShowDialog()
    End Sub
    Private Sub GunaGradientButton1_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        Dim form As New viewmaterialnamemaster
        form.ShowDialog()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim form As New viewmanufmaster
        form.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim form As New viewsuplmaster
        form.ShowDialog()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim addmaterial As New addmaterial
        addmaterial.ShowDialog()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim form As New materialconsumption
        form.ShowDialog()
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

    End Sub

    Private Function _GetLetters(s As String) As String
        Return New String(s.Where(Function(x As Char) System.Char.IsLetter(x)).ToArray)
    End Function
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' MsgBox(e.ColumnIndex)
        If e.ColumnIndex = 1 Then
            Dim form As New viewmaterialdetails
            form.Label1.Text = Label1.Text + " >> " + DataGridView1.SelectedCells(1).Value + " >> " + DataGridView1.SelectedCells(4).Value
            form.Label2.Text = Label1.Text
            form.Label3.Text = DataGridView1.SelectedCells(1).Value
            Dim unit As String = DataGridView1.SelectedCells(4).Value
            unit = (unit.Substring(unit.Length - 3)).Replace(" ", String.Empty)
            form.Label4.Text = _GetLetters(unit)
            form.Owner = Me
            form.WindowState = FormWindowState.Maximized
            form.ShowDialog()
        End If
    End Sub

    Private Sub AButton2_Click(sender As Object, e As EventArgs) Handles AButton2.Click
        LoadTotalStockCount()
        LoadTotalStockDetails()
        Label1.Visible = True
        DataGridView1.Visible = True
    End Sub

    Private Sub GunaAdvenceButton1_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton1.Click
        LoadLowStockCount()
        LoadLowStockDetails()
        Label1.Visible = True
        DataGridView1.Visible = True
    End Sub

    Private Sub GunaAdvenceButton2_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton2.Click
        LoadOutofStockCount()
        LoadOutofStockDetails()
        Label1.Visible = True
        DataGridView1.Visible = True
    End Sub

    Private Sub GunaAdvenceButton3_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton3.Click

    End Sub

    Private Sub GunaAdvenceButton4_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton4.Click
        LoadRawmaterialCount()
        LoadRawmaterialDetails()
        Label1.Visible = True
        DataGridView1.Visible = True
    End Sub

    Private Sub GunaAdvenceButton5_Click(sender As Object, e As EventArgs) Handles GunaAdvenceButton5.Click
        LoadPackagingmaterialCount()
        LoadPackagingmaterialDetails()
        Label1.Visible = True
        DataGridView1.Visible = True
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        ' If e.ColumnIndex = 5 Then
        ' DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ' End If
    End Sub
End Class