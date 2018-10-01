Public Class BookTipsBookContextByBookIDController

    Private _dalObj As New BookContextDAL
    Private _combiner As New boktipsImgSrcCombiner

    Public Function bookContextByBookid(bookid As Integer) As List(Of boktipsInfo)

        Dim combined As New List(Of boktipsInfo)

        Dim tmplist As List(Of boktipsInfo) = _dalObj.getBooktipBookContextByBookID(bookid)
        combined = _combiner.BoktipsImgSrcCombiner(tmplist)

        Return combined

    End Function

End Class