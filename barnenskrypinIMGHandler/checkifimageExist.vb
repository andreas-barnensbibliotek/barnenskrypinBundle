Imports System.Net
Imports System.IO
Public Class checkImgExist
    Private _baseuri As String = "http://www.barnensbibliotek.se/Portals/0/bokomslag/"
    Private _externbaseuri As String = "http://image.bokus.com/images/"
    'Private _filesystemURI As String = "d:\wwwroot\dotnetnuke_v5\Portals\0\Bokomslag\"
    Private _filesystemURI As String = "D:\websites\barnensbibliotek.se\www.barnensbibliotek.se\Portals\0\Bokomslag\"

    Public Function getimgurlbyIsbn(isbn As String) As String
        If Not String.IsNullOrEmpty(isbn) Then
            Dim retobj As String = cleanIsbn(isbn)
            Dim tmpimgSrc As String = _baseuri & retobj
            Dim testimgSrc = ""

            Dim filetyp() As String = {".jpg", ".gif", ".png"}
            Dim baseurltyp() As String = {_externbaseuri}
            Dim checkurltyp() As String = {}


            For Each imgtyp As String In filetyp

                If (File.Exists(_filesystemURI & retobj & imgtyp)) Then
                    Return _baseuri & retobj & imgtyp 'om filen finns i filsystemet ge den då rätt url för browsern
                End If

            Next


            For Each url As String In baseurltyp
                For Each imgtyp As String In filetyp

                    Dim tmp As String = url & retobj & imgtyp

                    If DoesImageExistRemotely(tmp) Then
                        Return tmp
                    End If

                Next
            Next
        End If
        ' om bilden inte hittas skicka tillbaka detta
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
