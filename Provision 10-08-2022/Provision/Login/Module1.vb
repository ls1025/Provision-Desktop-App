Imports System.Data
Imports System.Data.SqlClient
'Imports iTextSharp.text
'Imports iTextSharp.text.pdf
'Imports iTextSharp
Imports System.IO
Module Module1
    Public con As New SqlConnection("Data Source=SHIVA\SQLEXPRESS;Initial Catalog=sbs;User ID=sa;Password=cymbalta@123")
    ' Public con As New SqlConnection("Data Source=SHIVA\SQLEXPRESS;Initial Catalog=sbs;Integrated Security=True")


    Public cmd As New SqlCommand
    Public cmd1 As New SqlCommand
    Public Function QueryAsDataTable(ByVal sql As String) As DataTable
        Try
            Dim da As New SqlDataAdapter(sql, con)
            Dim ds As New DataSet
            da.Fill(ds, "result")
            Return ds.Tables("result")
        Catch ex As Exception

        End Try

    End Function
End Module
