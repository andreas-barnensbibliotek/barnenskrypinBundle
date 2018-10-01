Imports barnenskrypinIMGHandler
Public Class boktipsImgSrcCombiner
    Implements IBoktipsCombiner

    Private _dalObj As New boktipsAuthorDAL
    Private _currBookid As Integer
    Private _currIgSrc As String

    Public Function BoktipsImgSrcCombinerSingel(itm As boktipsInfo) As boktipsInfo

        itm.ImgSrc = getExternBokomslagURL(itm.Bookid)

        Return itm

    End Function
    Public Function BoktipsImgSrcCombiner(DalTmpObj As List(Of boktipsInfo)) As List(Of boktipsInfo)

        Dim retObj As New List(Of boktipsInfo)

        For Each bt In DalTmpObj
            Dim itm As New boktipsInfo
            itm = bt
            itm.ImgSrc = getExternBokomslagURL(bt.Bookid)

            retObj.Add(itm)
        Next

        Return retObj

    End Function

    Public Function getExternBokomslagURL(bookid As Integer) As String Implements IBoktipsCombiner.getExternBokomslagURL
        Dim imgController As New checkImgExist
        Dim ret As String = ""

        If bookid > 0 Then
            If bookid = _currBookid Then
                ret = _currIgSrc
            Else
                Dim isbn = _dalObj.BookidToISBN(bookid)


                ret = imgController.getimgurlbyIsbn(isbn)
                _currBookid = bookid
                _currIgSrc = ret
            End If
        Else
            ret = imgController.getimgurlbyIsbn("") ' skickar tom sträng till funktionen som returnerar bild saknas
        End If

        Return ret

    End Function

End Class
