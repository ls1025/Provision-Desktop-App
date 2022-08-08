Imports System.Data
Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp
Imports System.IO
Module Module1
    Public con As New SqlConnection("Data Source=SHIVA\SQLEXPRESS;Initial Catalog=provision;User ID=sa;Password=cymbalta@123")
    'Public con As New SqlConnection("Data Source=V-ENSURE-DC\TMSM;Initial Catalog=provision;User ID=shiva;Password=cymbalta@1")
    Public cmd As New SqlCommand
    Public cmd1 As New SqlCommand
    Public cmd2 As New SqlCommand

End Module
