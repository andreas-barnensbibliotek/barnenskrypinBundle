Imports System
Imports System.Web
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Imports System.Configuration


Public Class mediafiles

    'Private _mediaBaseUrl As String = ConfigurationSettings.AppSettings("mediaBaseUrl") 'sätt en hänvisning till appsettings i webconfig
    Private _externSrcUrl As String = "http://image.bokus.com/images/"
    Public Delegate Function AsyncMethodCaller(ByVal isbn As String, ByVal typ As String) As String

    'ändrar bildurl så att dnn hittar, och kollar om bilderna existerar
    Public Function ResolveMediaUrl(ByVal isbn As String, ByVal typ As String) As String
        Dim trunctISBN As String = ""
        Dim srcImgMapp As String = ""

        Select Case typ
            Case "img"
                If isbn = "" Then
                    srcImgMapp = RandomImageDomainAdress() & "Portals/0/bokomslag/foto_saknas.jpgNO_ISBN"
                Else
                    trunctISBN = GetTrunctISBN(isbn)
                    srcImgMapp = RandomImageDomainAdress() & "Portals/0/bokomslag/" & trunctISBN.ToString

                    If chkIfUrlExist(srcImgMapp & ".jpg") Then 'om inte jpg kolla om filen finns i .gif
                        srcImgMapp = srcImgMapp & ".jpg"
                    Else
                        If chkIfUrlExist(srcImgMapp & ".gif") Then 'om bilden är i gif skicka tillbaka den
                            srcImgMapp = srcImgMapp & ".gif"
                        Else ' om bilden inte finns lokalt kolla externurl om den finns där och isåfall hämta


                            If Not testextimgurl(trunctISBN.ToString) = "err" Then 'externbild finns om inte felmeddelande (err) syns
                                srcImgMapp = testextimgurl(trunctISBN.ToString)
                            Else
                                srcImgMapp = RandomImageDomainAdress() & "Portals/0/bokomslag/foto_saknas.jpg_Gott_err"
                            End If

                        End If

                    End If
                End If

            Case "film"
                If Not isbn = "" Then
                    trunctISBN = GetTrunctISBN(isbn)
                    srcImgMapp = RandomImageDomainAdress() & "Portals/0/Video/tecken/" & trunctISBN.ToString

                    If chkIfUrlExist(srcImgMapp & ".flv") Then
                        srcImgMapp = srcImgMapp & ".flv"
                    Else
                        If chkIfUrlExist(srcImgMapp & ".swf") Then 'om bilden är i swf skicka tillbaka den
                            srcImgMapp = srcImgMapp & ".swf"
                        Else
                            srcImgMapp = ""
                        End If
                    End If
                End If

            Case "mp3"
                If Not isbn = "" Then
                    trunctISBN = GetTrunctISBN(isbn)
                    srcImgMapp = RandomImageDomainAdress() & "Portals/0/ljud/" & trunctISBN.ToString

                    If chkIfUrlExist(srcImgMapp & ".mp3") Then
                        srcImgMapp = srcImgMapp & ".mp3"
                    Else
                        srcImgMapp = ""
                    End If
                End If
            Case "mark"
                If isbn = "1" Then
                    srcImgMapp = RandomImageDomainAdress() & "/Portals/0/logor/LattLasa.gif"
                End If
            Case "bokjury"
                If isbn = "1" Then
                    srcImgMapp = RandomImageDomainAdress() & "/Portals/0/logor/bokjuryn.gif"
                End If
            Case Else
                srcImgMapp = RandomImageDomainAdress() & "Portals/0/bokomslag/foto_saknas.jpgNottANNAT"
        End Select

        Return srcImgMapp
    End Function

    'Public Function ResolveMediaUrl(ByVal bookid As Integer, ByVal typ As String) As String
    '    Dim obj As New BookDataHandlerDAL
    '    Dim book As BookDetailInfo = obj.getBookDetailData(bookid)
    '    Return ResolveMediaUrl(book.isbn, typ)
    'End Function

    Private Shared Function GetTrunctISBN(ByVal isbn As String) As String
        Dim trunctISBN As String
        trunctISBN = Join(Split(isbn, "-")) 'tabort alla - från isbn så att endast nr blir en sträng
        trunctISBN = Replace(trunctISBN, " ", "") 'tabort alla - från isbn så att endast nr blir en sträng
        Return trunctISBN
    End Function


    Private Function testextimgurl(ByVal isbn As String) As String
        Dim theurl As String = ""

        Dim req As System.Net.HttpWebRequest
        Dim res As System.Net.HttpWebResponse
        Dim r As System.IO.StreamReader
        Dim pge As String

        Try
            req = System.Net.WebRequest.Create(_externSrcUrl & isbn & ".gif")
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705)"

            'get page 
            res = req.GetResponse()
            r = New System.IO.StreamReader(res.GetResponseStream())
            pge = r.ReadToEnd
            r.Close()
            res.Close()

            theurl = res.ResponseUri.AbsoluteUri '_externSrcUrl & isbn & ".gif"
        Catch ex As Exception
            theurl = "err"
        End Try
        Return theurl
    End Function

    Private Function RandomImageDomainAdress() As String
        Dim MaxNumber As Integer = 3
        Dim MinNumber As Integer = 1
        Dim ret As String = ""
        'initialize random number generator
        Dim r As New Random(System.DateTime.Now.Millisecond)

        If MinNumber > MaxNumber Then
            Dim t As Integer = MinNumber
            MinNumber = MaxNumber
            MaxNumber = t
        End If

        Select Case r.Next(MinNumber, MaxNumber)
            Case 1
                ret = "http://www.barnensbibliotek.se/"
            Case 2
                ret = "http://www.barnensbibliotek.net/"
            Case 3
                ret = "http://www.barnensbibliotek.com/"
            Case 4
                ret = "http://www.barnensbibliotek.info/"
            Case Else
                ret = "http://www.barnensbibliotek.se/"
        End Select
        Return ret
    End Function

    Private Function chkIfUrlExist(ByVal url As String) As Boolean
        Dim bln As Boolean = False

        Try
            Dim res As System.Net.HttpWebResponse
            Dim req As System.Net.HttpWebRequest

            req = System.Net.WebRequest.Create(url)
            req.Method = "HEAD"
            'req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705)"
            res = req.GetResponse()
            If res.StatusCode = 200 Then
                bln = True
            End If

            'If Not res.ContentType = "text/HTML" Then
            '    Select Case res.ContentType
            '        Case "video/x-flv"
            '            bln = True
            '        Case "application/x-shockwave-flash"
            '            bln = True
            '        Case "image/gif"
            '            bln = True
            '        Case "image/jpeg"
            '            bln = True
            '        Case "audio/mpeg"
            '            bln = True
            '        Case Else
            '            bln = False
            '    End Select
            'End If
        Catch ex As Exception
            bln = False
        End Try
        Return bln

    End Function
End Class
