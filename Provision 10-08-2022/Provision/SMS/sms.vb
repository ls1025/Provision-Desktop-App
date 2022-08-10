Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Resources
Public Class sms
    Public Function sendSMS()
        Dim apikey = "Njg2NTU2NjQzMzRhNmY2NjQxNjM0NTc4NGU2ZTRjNTA="
        Dim message = "This is your message"
        Dim numbers = "917989227004"
        Dim strPost As String
        Dim sender = "TXTLCL"
        Dim url As String = "https://api.textlocal.in/send/?"
        ' Dim strPost As String

        strPost = url + "apikey=" + apikey _
        + "&numbers=" + numbers _
        + "&message=" + WebUtility.UrlEncode(message) _
        + "&sender=" + sender

        Dim request As WebRequest = WebRequest.Create(strPost)
        request.Method = "POST"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(strPost)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()

        Dim response As WebResponse = request.GetResponse()
        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        Console.WriteLine(responseFromServer)
        Console.ReadLine()

        reader.Close()
        dataStream.Close()
        response.Close()

        If responseFromServer.Length > 0 Then
            Return responseFromServer
        Else
            Return CType(response, HttpWebResponse).StatusDescription
        End If
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sendSMS()
    End Sub
End Class