Imports barnenskrypinIMGHandler
Public Class boktipsImgSrcCombiner
    Implements IBoktipsCombiner

    Private _dalObj As New boktipsAuthorDAL
    Private _currBookid As Integer
    Private _currIgSrc As String

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

        Dim ret As String = ""

        If bookid > 0 Then
            If bookid = _currBookid Then
                ret = _currIgSrc
            Else
                Dim omslagSrc = _dalObj.BookidToISBN(bookid)
                Dim imgController As New checkImgExist

                ret = imgController.getimgurlbyIsbn(bookid)
                _currBookid = bookid
                _currIgSrc = ret
            End If

        End If

        Return ret

    End Function

End Class
