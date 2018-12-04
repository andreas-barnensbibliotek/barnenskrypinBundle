Public Class BookTipsByUserIdController
    Private _dalobj As New boktipsByUseridDAL
    Private _combiner As New boktipsImgSrcCombiner

    Public Function getbooktipByUserid(userid As Integer) As List(Of boktipsInfo)
        Dim retobj As New boktipsInfo
        Dim tmplist As List(Of boktipsInfo) = _dalobj.getBoktipsByUserid(userid)

        Return _combiner.BoktipsImgSrcCombiner(tmplist)

    End Function

    Public Function getbooktipLatestByUserid(userid As Integer) As List(Of boktipsInfo)
        Dim retobj As New boktipsInfo
        Dim tmplist As List(Of boktipsInfo) = _dalobj.getLatestBokTipsByUserid(userid)

        Return _combiner.BoktipsImgSrcCombiner(tmplist)

    End Function
End Class
