Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class addmaterial
    Dim cmd1 As New SqlCommand
    Dim cmd2 As New SqlCommand
    Private _filename As String = String.Empty
    Private Sub addmaterial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna.UI.Lib.GraphicsHelper.DrawLineShadow(GunaPanel1, Color.FromArgb(4, 145, 199), 50, 100, Guna.UI.WinForms.VerHorAlign.HoriziontalTop)

        ' LoadGenericName()
        'LoadBrandName()
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
        DateTimePicker3.Value = DateTime.Now

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            ComboBox2.Items.Clear()

            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(category) from inventry_materialtype where type='" + ComboBox1.Text + "' order by [category] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox2.Items.Add(dr("category"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            If ComboBox2.Text = "Active" Then
                ComboBox3.Enabled = True
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                'date
                DateTimePicker1.Enabled = True
                DateTimePicker2.Enabled = True
                DateTimePicker3.Enabled = True

                CheckBox1.Enabled = True
                CheckBox2.Enabled = True
                CheckBox3.Enabled = True

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False

                TextBox1.Text = ""
                TextBox1.Enabled = True
            ElseIf ComboBox2.Text = "Excipients" Then
                ComboBox3.Enabled = False
                ComboBox4.Enabled = True
                ComboBox5.Enabled = True
                'date
                DateTimePicker1.Enabled = True
                DateTimePicker2.Enabled = True
                DateTimePicker3.Enabled = True

                CheckBox1.Enabled = True
                CheckBox2.Enabled = True
                CheckBox3.Enabled = True

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False

                TextBox1.Text = ""
                TextBox1.Enabled = False
            ElseIf ComboBox2.Text = "Solvents" Then
                ComboBox3.Enabled = True
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                'date
                DateTimePicker1.Enabled = True
                DateTimePicker2.Enabled = True
                DateTimePicker3.Enabled = True


                CheckBox1.Enabled = True
                CheckBox2.Enabled = True
                CheckBox3.Enabled = True

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False

                TextBox1.Text = ""
                TextBox1.Enabled = True
            ElseIf ComboBox2.Text = "Coating Material" Then
                ComboBox3.Enabled = False
                ComboBox4.Enabled = True
                ComboBox5.Enabled = True
                'date
                DateTimePicker1.Enabled = True
                DateTimePicker2.Enabled = True
                DateTimePicker3.Enabled = True

                CheckBox1.Enabled = True
                CheckBox2.Enabled = True
                CheckBox3.Enabled = True

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False

                TextBox1.Text = ""
                TextBox1.Enabled = True
            ElseIf ComboBox2.Text = "Colorants" Then
                ComboBox3.Enabled = False
                ComboBox4.Enabled = True
                ComboBox5.Enabled = True
                'date
                DateTimePicker1.Enabled = True
                DateTimePicker2.Enabled = True
                DateTimePicker3.Enabled = True


                CheckBox1.Enabled = True
                CheckBox2.Enabled = True
                CheckBox3.Enabled = True

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False

                TextBox1.Text = ""
                TextBox1.Enabled = True
            ElseIf ComboBox2.Text = "Capsule Shell" Then
                ComboBox3.Enabled = True
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                'date
                DateTimePicker1.Enabled = True
                DateTimePicker2.Enabled = True
                DateTimePicker3.Enabled = True


                CheckBox1.Enabled = True
                CheckBox2.Enabled = True
                CheckBox3.Enabled = True

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False

                TextBox1.Text = ""
                TextBox1.Enabled = True
            ElseIf ComboBox2.Text = "HDPE Bottle" Then
                ComboBox3.Enabled = True
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                'date
                DateTimePicker1.Enabled = True
                DateTimePicker2.Enabled = True
                DateTimePicker3.Enabled = True

                CheckBox1.Enabled = True
                CheckBox2.Enabled = True
                CheckBox3.Enabled = True

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False

                TextBox1.Text = ""
                TextBox1.Enabled = True
            ElseIf ComboBox2.Text = "Caps" Then
                ComboBox3.Enabled = True
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                'date
                DateTimePicker1.Enabled = True
                DateTimePicker2.Enabled = True
                DateTimePicker3.Enabled = True

                CheckBox1.Enabled = True
                CheckBox2.Enabled = True
                CheckBox3.Enabled = True

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False

                TextBox1.Text = ""
                TextBox1.Enabled = True
            ElseIf ComboBox2.Text = "Blister" Then
                ComboBox3.Enabled = True
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                'date
                DateTimePicker1.Enabled = True
                DateTimePicker2.Enabled = True
                DateTimePicker3.Enabled = True

                CheckBox1.Enabled = True
                CheckBox2.Enabled = True
                CheckBox3.Enabled = True

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False

                TextBox1.Text = ""
                TextBox1.Enabled = True
            ElseIf ComboBox2.Text = "Dessicants" Then
                ComboBox3.Enabled = False
                ComboBox4.Enabled = True
                ComboBox5.Enabled = True
                'date
                DateTimePicker1.Enabled = True
                DateTimePicker2.Enabled = True
                DateTimePicker3.Enabled = True

                CheckBox1.Enabled = True
                CheckBox2.Enabled = True
                CheckBox3.Enabled = True

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False

                TextBox1.Text = ""
                TextBox1.Enabled = True
            ElseIf ComboBox2.Text = "Ampoules" Then
                ComboBox3.Enabled = True
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False

                'date
                DateTimePicker1.Enabled = False
                DateTimePicker2.Enabled = False
                DateTimePicker3.Enabled = False

                CheckBox1.Enabled = False
                CheckBox2.Enabled = False
                CheckBox3.Enabled = False

                CheckBox1.Checked = True
                CheckBox2.Checked = True
                CheckBox3.Checked = True

                TextBox1.Text = ""
                TextBox1.Enabled = True
            ElseIf ComboBox2.Text = "PFS" Then
                ComboBox3.Enabled = True
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                'date
                DateTimePicker1.Enabled = True
                DateTimePicker2.Enabled = True
                DateTimePicker3.Enabled = True

                CheckBox1.Enabled = True
                CheckBox2.Enabled = True
                CheckBox3.Enabled = True

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False

                TextBox1.Text = ""
                TextBox1.Enabled = True
            ElseIf ComboBox2.Text = "Stopper" Then
                ComboBox3.Enabled = True
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                'date
                DateTimePicker1.Enabled = True
                DateTimePicker2.Enabled = True
                DateTimePicker3.Enabled = True

                CheckBox1.Enabled = True
                CheckBox2.Enabled = True
                CheckBox3.Enabled = True

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False

                TextBox1.Text = ""
                TextBox1.Enabled = True
            ElseIf ComboBox2.Text = "Seal" Then
                ComboBox3.Enabled = True
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                'date
                DateTimePicker1.Enabled = True
                DateTimePicker2.Enabled = True
                DateTimePicker3.Enabled = True

                CheckBox1.Enabled = True
                CheckBox2.Enabled = True
                CheckBox3.Enabled = True

                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False

                TextBox1.Text = ""
                TextBox1.Enabled = True
            ElseIf ComboBox2.Text = "Cartons" Then
                ComboBox3.Enabled = True
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False

                'date
                DateTimePicker1.Enabled = False
                DateTimePicker2.Enabled = False
                DateTimePicker3.Enabled = False

                CheckBox1.Enabled = False
                CheckBox2.Enabled = False
                CheckBox3.Enabled = False

                CheckBox1.Checked = True
                CheckBox2.Checked = True
                CheckBox3.Checked = True

                TextBox1.Text = "NA"
                TextBox1.Enabled = False
            End If
            LoadMaterialMsater()
            LoadGenericName()
            LoadBrandName()
            LoadManufacturer()
            LoadSupplier()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadMaterialMsater()
        Try
            ComboBox3.Items.Clear()
            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(material) from inventry_materialmaster where category='" + ComboBox2.Text + "' order by [material] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox3.Items.Add(dr("material"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadGenericName()
        Try
            ComboBox4.Items.Clear()
            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(generic) from inventry_generic order by [generic] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox4.Items.Add(dr("generic"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadBrandName()
        Try
            ComboBox5.Items.Clear()
            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(brand) from inventry_brand order by [brand] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox5.Items.Add(dr("brand"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadManufacturer()
        Try
            ComboBox6.Items.Clear()
            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(manuf) from inventry_manuf order by [manuf] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox6.Items.Add(dr("manuf"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadSupplier()
        Try
            ComboBox7.Items.Clear()
            'Load Proname from development
            If con.State = ConnectionState.Open Then con.Close()
            Dim cmd As New SqlCommand
            cmd.Connection = con
            cmd.CommandText = "select DISTINCT(suppl) from inventry_suppl order by [suppl] ASC"
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                ComboBox7.Items.Add(dr("suppl"))
            End While
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If ComboBox1.Text = "" Then
                MsgBox("Select Material Type", vbCritical)
            ElseIf ComboBox2.Text = "" Then
                MsgBox("Select Material Category", vbCritical)
            ElseIf ComboBox6.Text = "" Then
                MsgBox("Select Manufacturer", vbCritical)
            ElseIf ComboBox7.Text = "" Then
                MsgBox("Select Supplier", vbCritical)
            ElseIf ComboBox8.Text = "" Then
                MsgBox("Select Department", vbCritical)
            ElseIf ComboBox9.Text = "" Then
                MsgBox("Select Sample Type", vbCritical)
            ElseIf ComboBox9.Text = "Purchase" And TextBox3.Text = "" Then
                MsgBox("Enter PO Number", vbCritical)
            ElseIf TextBox4.Text = "" Then
                MsgBox("Enter Qty Recieved", vbCritical)
            ElseIf ComboBox10.Text = "" Then
                MsgBox("Select unit of Qty", vbCritical)
            ElseIf TextBox5.Text = "" Then
                MsgBox("Enter Price for Each unit", vbCritical)
            ElseIf TextBox6.Text = "" Then
                MsgBox("Enter Rack Location", vbCritical)
            ElseIf Label1.Text = "" Or Label1.Text = "." Then
                MsgBox("Upload COA", vbCritical)
            Else

                Dim ProductAddedby As String = Homepagefrdj.Label2.Text
                If ProductAddedby = "User Type" Then
                    ProductAddedby = Homepagefrdgl.Label1.Text
                Else
                    ProductAddedby = Homepagefrdj.Label1.Text
                End If
                GenerateMaetrialCode()
                If con.State = ConnectionState.Open Then con.Close()
                Dim cmd As New SqlCommand
                cmd.Connection = con
                cmd.CommandText = "insert into inventry_master(itemcode,type,category,material_name,gen_name,brand_name,btn,mfg,exp,retest,manufby,supplby,dep,sampletype,descrpt,po,recievedqty,unit,eachprice,totalprice,remainingqty,location,erpcode,coa,addedby,addedon) values('" + materialcode + "','" + ComboBox1.Text + "','" + ComboBox2.Text + "','" + ComboBox3.Text + "','" + ComboBox4.Text + "','" + ComboBox5.Text + "','" + TextBox1.Text + "',@mfg,@exp,@retest,'" + ComboBox6.Text + "','" + ComboBox7.Text + "','" + ComboBox8.Text + "','" + ComboBox9.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + ComboBox10.Text + "','" + TextBox5.Text + "','" + GunaLabel18.Text + "','" + TextBox4.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "',@attachment,'" + ProductAddedby + "',@addedon)"
                If CheckBox1.Checked = True Then
                    cmd.Parameters.AddWithValue("@mfg", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("@mfg", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker1.Value.Date)
                End If
                If CheckBox2.Checked = True Then
                    cmd.Parameters.AddWithValue("@exp", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("@exp", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker2.Value.Date)
                End If
                If CheckBox3.Checked = True Then
                    cmd.Parameters.AddWithValue("@retest", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("@retest", SqlDbType.Date).Value = Convert.ToDateTime(DateTimePicker3.Value.Date)
                End If
                cmd.Parameters.AddWithValue("@attachment", SqlDbType.VarBinary).Value = File.ReadAllBytes(Label1.Text)
                cmd.Parameters.AddWithValue("@addedon", SqlDbType.Date).Value = DateTime.Now.Date
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Stock Added Successfully", vbInformation)
                Me.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Dim materialcode As String
    Private Sub GenerateMaetrialCode()
        If con.State = ConnectionState.Open Then con.Close()
        Dim curValue As Integer
        con.Open()
        Dim cmd = New SqlCommand("Select MAX(itemcode) FROM inventry_master where category='" + ComboBox2.Text + "'", con)
        materialcode = cmd.ExecuteScalar().ToString()
        con.Close()
        If ComboBox2.Text = "Active" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "ACT000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "ACT" + curValue.ToString("D6")
            End If
        ElseIf ComboBox2.Text = "Excipients" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "EXP000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "EXP" + curValue.ToString("D6")
            End If
        ElseIf ComboBox2.Text = "Solvents" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "SOL000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "SOL" + curValue.ToString("D6")
            End If
        ElseIf ComboBox2.Text = "Coating Material" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "COT000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "COT" + curValue.ToString("D6")
            End If
        ElseIf ComboBox2.Text = "Colorants" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "COL000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "COL" + curValue.ToString("D6")
            End If
        ElseIf ComboBox2.Text = "Capsule Shell" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "CPS000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "CPS" + curValue.ToString("D6")
            End If
        ElseIf ComboBox2.Text = "HDPE Bottle" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "HDP000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "HDP" + curValue.ToString("D6")
            End If
        ElseIf ComboBox2.Text = "Caps" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "CAP000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "CAP" + curValue.ToString("D6")
            End If
        ElseIf ComboBox2.Text = "Blister" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "BLS000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "BLS" + curValue.ToString("D6")
            End If
        ElseIf ComboBox2.Text = "Dessicants" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "DES000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "DES" + curValue.ToString("D6")
            End If
        ElseIf ComboBox2.Text = "Ampoules" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "AMP000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "AMP" + curValue.ToString("D6")
            End If
        ElseIf ComboBox2.Text = "PFS" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "PFS000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "PFS" + curValue.ToString("D6")
            End If
        ElseIf ComboBox2.Text = "Stoppers" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "STP000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "STP" + curValue.ToString("D6")
            End If
        ElseIf ComboBox2.Text = "Seal" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "SEL000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "SEL" + curValue.ToString("D6")
            End If
        ElseIf ComboBox2.Text = "Cartons" Then
            If String.IsNullOrEmpty(materialcode) Then
                materialcode = "CRT000001"
            Else
                materialcode = materialcode.Substring(6)
                Int32.TryParse(materialcode, curValue)
                curValue = curValue + 1
                materialcode = "CRT" + curValue.ToString("D6")
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub GunaGradientButton4_Click(sender As Object, e As EventArgs) Handles GunaGradientButton1.Click
        With FileDialogs
            .FileName = ""
            .CheckFileExists = True : .CheckPathExists = True
            .Filter = "PDF Files (*.pdf)|*.pdf"
            .Multiselect = False : .ReadOnlyChecked = False
            .RestoreDirectory = True : .ShowHelp = False
            .Title = "Select File - Documnet Upload"
            .ShowDialog(Me)
            _filename = .FileName.ToString()
            Label1.Text = _filename
        End With
    End Sub
    Private Sub GunaCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            DateTimePicker1.Format = DateTimePickerFormat.Custom
            DateTimePicker1.CustomFormat = " "
        ElseIf CheckBox1.Checked = False Then
            DateTimePicker1.Format = DateTimePickerFormat.Short
            DateTimePicker1.Value = DateTime.Now
        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            DateTimePicker2.Format = DateTimePickerFormat.Custom
            DateTimePicker2.CustomFormat = " "
        ElseIf CheckBox2.Checked = False Then
            DateTimePicker2.Format = DateTimePickerFormat.Short
            DateTimePicker2.Value = DateTime.Now
        End If
    End Sub
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            DateTimePicker3.Format = DateTimePickerFormat.Custom
            DateTimePicker3.CustomFormat = " "
        ElseIf CheckBox3.Checked = False Then
            DateTimePicker3.Format = DateTimePickerFormat.Short
            DateTimePicker3.Value = DateTime.Now
        End If
    End Sub
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Try
            If TextBox4.Text = "" Then
            ElseIf TextBox5.Text = "" Then
            Else
                Dim qty As Double = TextBox4.Text
                Dim price As Double = TextBox5.Text
                Dim totalprice As Double = qty * price
                GunaLabel17.Text = totalprice.ToString("C2")
                GunaLabel18.Text = totalprice
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Try
            If TextBox4.Text = "" Then
            ElseIf TextBox5.Text = "" Then
            Else
                Dim qty As Double = TextBox4.Text
                Dim price As Double = TextBox5.Text
                Dim totalprice As Double = qty * price
                GunaLabel17.Text = totalprice.ToString("C2")
                GunaLabel18.Text = totalprice
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox9.SelectedIndexChanged
        If ComboBox9.Text = "Free" Then
            GunaLabel24.Visible = False
            TextBox3.Visible = False
            TextBox3.Text = ""
        Else
            GunaLabel24.Visible = True
            TextBox3.Visible = True
            TextBox3.Text = ""
        End If
    End Sub

    Private Sub GunaComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox1.SelectedIndexChanged
        GunaComboBox2.Items.Clear()
        TextBox6.Text = ""
        Dim maxrackno As Integer
        If GunaComboBox1.Text = "A" Then
            maxrackno = 20
        ElseIf GunaComboBox1.Text = "B" Or GunaComboBox1.Text = "C" Or GunaComboBox1.Text = "D" Then
            maxrackno = 12
        ElseIf GunaComboBox1.Text = "E" Then
            maxrackno = 8
        ElseIf GunaComboBox1.Text = "F" Then
            maxrackno = 16
        ElseIf GunaComboBox1.Text = "G" Then
            maxrackno = 5
        ElseIf GunaComboBox1.Text = "H" Then
            maxrackno = 5
        ElseIf GunaComboBox1.Text = "I" Then
            maxrackno = 10
        End If

        For i = 1 To maxrackno
            GunaComboBox2.Items.Add(GunaComboBox1.Text + "-" + i.ToString("00"))
        Next

    End Sub

    Private Sub GunaComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBox2.SelectedIndexChanged
        TextBox6.Text = GunaComboBox2.Text
    End Sub
End Class