Imports System.Net

Public Class checkifimageExist
    Private _baseuri As String = "http://www.barnensbibliotek.se/Portals/0/bokomslag/"
    Private _externbaseuri As String = "http://image.bokus.com/images/"

    Public Function getimgurlbyIsbn(isbn As String) As String
            Dim retobj As String = cleanIsbn(isbn)
            Dim tmpimgSrc As String = _baseuri & retobj

        Dim testimgSrc = tmpimgSrc & ".jpg"


        ' Create array of three integers.
        Dim filetyp() As String = {".jpg", ".gif", ".png"}
        Dim baseurltyp() As String = {_baseuri, _externbaseuri}
        Dim checkurltyp() As String = {}


        For Each url As String In baseurltyp
            For Each imgtyp As String In filetyp
                Array.Resize(checkurltyp, checkurltyp.Length + 1)
                checkurltyp(checkurltyp.Length - 1) = url & retobj & imgtyp
            Next

        Next

        For Each chkitem As String In checkurltyp
            If DoesImageExistRemotely(chkitem) Then

                Return testimgSrc

            End If
        Next

        Return _baseuri & "foto_saknas.jpg"

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
