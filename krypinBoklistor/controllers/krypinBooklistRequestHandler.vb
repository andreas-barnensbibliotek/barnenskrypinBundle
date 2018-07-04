Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports YourCompany.Modules.AJBarnboksKatalog

Public Class krypinBooklistRequestHandler

    Public Function createFraganJsonp(obj As List(Of krypinbooklisInfo)) As String

        Dim sb As New StringBuilder
        Dim isbnToimgurl As New clsImageHandler

        Dim i As Integer = 0
        sb.Append("{") '{1-1}        
        sb.Append("""barnenskrypin"" : {") '{2-1}
        Dim totantallistor As Integer = obj.Count

        sb.Append("""boklistorstatus"" : ""true"", ")
        sb.Append("""boklistor"" : ")
        If totantallistor > 0 Then

            For Each listor In obj

                If i = 0 Then
                    sb.Append("[{") '{5-1}
                Else
                    sb.Append("{") '{5-2} {5-1}
                End If
                sb.AppendFormat("""booklistid"" : ""{0}"", ", obj(i).BlID)
                sb.AppendFormat("""groupid"" : ""{0}"", ", obj(i).gruppid)


                If obj(i).BooklistItems.Count <= 0 Then
                    getemptybookItems(sb)
                Else
                    sb.Append("""bookitems"" : [") '{4-1}

                    Dim y As Integer = 1
                    For Each x In obj(i).BooklistItems

                        If y = 1 Then
                            sb.Append("{") '{5-1}
                        Else
                            sb.Append("}, {") '{5-2} {5-1}
                        End If

                        sb.AppendFormat("""bookid"" :""{0}"", ", x.Bookid)
                        sb.AppendFormat("""booktitle"" : ""{0}"", ", convertFromHtmlToChar(x.title))
                        sb.AppendFormat("""bookauthor"" : ""{0}"", ", convertFromHtmlToChar(x.Forfattare))
                        sb.AppendFormat("""bookisbn"" : ""{0}"", ", x.isbn)
                        sb.AppendFormat("""bookimgsrc"" : ""{0}""", isbnToimgurl.resolveImgUrl(x.isbn, "img"))
                        y += 1
                    Next

                    sb.Append("}") '{5-2}
                    sb.Append("] ") '{4-2}

                End If
                sb.AppendFormat(",""booklistnamn"" : ""{0}""", obj(i).Booklistname)
                sb.Append("}") '{3-2}

                If Not totantallistor = i + 1 Then
                    sb.Append(", ")
                Else
                    sb.Append("]")
                End If
                i += 1
            Next
        Else
            sb.Append("{") '{2-2}
            getemptybookItems(sb)
            sb.Append("}") '{2-2}
        End If
        sb.Append("}") '{2-2}
        sb.Append("}") '{1-2}

        Return sb.ToString
    End Function

    Private Shared Sub getemptybookItems(ByVal sb As StringBuilder)
        sb.Append("""bookitems"" : [{") '{4-1}
        sb.AppendFormat("""bookid"" :""{0}"", ", "")
        sb.AppendFormat("""booktitle"" : ""{0}"", ", "")
        sb.AppendFormat("""bookauthor"" : ""{0}"", ", "")
        sb.AppendFormat("""bookisbn"" : ""{0}"", ", "")
        sb.AppendFormat("""bookimgsrc"" : ""{0}""", "")
        sb.Append("}] ") '{4-2}
    End Sub

    Public Function createEmptyFraganJson(status As String) As String

        Dim sb As New StringBuilder
        sb.Append("({") '{1-1}        
        sb.Append("""barnenskrypin"" : {") '{2-1}
        If String.IsNullOrEmpty(status) Then
            sb.Append("""boklistorstatus"" : ""true"", ")
        Else
            sb.AppendFormat("""boklistorstatus"" :""{0}"", ", status)
        End If
        sb.Append("""boklistorstatus"" : ""true"", ")
        sb.Append("""boklistor"" : {") '{3-1}

        sb.AppendFormat("""booklistid"" : ""{0}"", ", "0")
        sb.AppendFormat("""groupid"" : ""{0}"", ", "0")
        sb.Append("""bookitems"" :[ {") '{4-1}
        sb.AppendFormat("""bookid"" :""{0}"", ", "")
        sb.AppendFormat("""booktitle"" : ""{0}"", ", "")
        sb.AppendFormat("""bookauthor"" : ""{0}"", ", "")
        sb.AppendFormat("""bookisbn"" : ""{0}"", ", "")
        sb.AppendFormat("""bookimgsrc"" : ""{0}""", "")
        sb.Append("}],") '{4-2}

        sb.AppendFormat("""booklistnamn"" : ""{0}""", "")
        sb.Append("}") '{3-2}
        sb.Append("}") '{2-2}
        sb.Append("})") '{1-2}
        Return sb.ToString
    End Function

    Private Function convertFromHtmlToChar(retUrl As String) As String
        Dim ret As String = retUrl
        If Not String.IsNullOrEmpty(ret) Then


            ret = ret.Replace("1233", "å")
            ret = ret.Replace("1323", "ä")
            ret = ret.Replace("3213", "ö")
        End If
        Return ret

    End Function
End Class
