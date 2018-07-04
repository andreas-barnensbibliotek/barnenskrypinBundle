Imports System.Net

Public Class checkifimageExist
    Private _baseuri As String = "http://www.barnensbibliotek.se/Portals/0/bokomslag/"
    Public Function getimgurlbyIsbn(isbn As String) As String
        Dim retobj As String = cleanIsbn(isbn)
        Dim tmpimgSrc As String = _baseuri & retobj

        Dim testimgSrc = tmpimgSrc & ".gif"
        If DoesImageExistRemotely(testimgSrc) Then
            Return testimgSrc
        End If

        testimgSrc = tmpimgSrc & ".jpg"
        If DoesImageExistRemotely(testimgSrc) Then
            Return testimgSrc
        End If

        testimgSrc = tmpimgSrc & ".png"
        If DoesImageExistRemotely(testimgSrc) Then
            Return testimgSrc
        Else
            Return _baseuri & "foto_saknas.jpg"
        End If

    End Function

    Private Function cleanIsbn(isbn As String) As String
        Dim retobj As String = isbn.Replace("-", "")
        Return retobj.Replace(" ", "")
    End Function
    Private Function DoesImageExistRemotely(ByVal uriToImage As String) As Boolean

        Dim request As HttpWebRequest = CType(WebRequest.Create(uriToImage), HttpWebRequest)
        request.Method = "HEAD"

        Try

            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

                If response.StatusCode = HttpStatusCode.OK Then
                    Return True
                Else
                    Return False
                End If
            End Using

        Catch __unusedWebException1__ As WebException
            Return False
        Catch
            Return False
        End Try
    End Function
End Class
