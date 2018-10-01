Public Class BookTipsByTipIdController
    Private _dalobj As New CRUDBoktipsDAL
    Private _combiner As New boktipsImgSrcCombiner
    Public Function getbooktipByTipid(tipid As Integer) As boktipsInfo
        Dim retobj As New boktipsInfo
        retobj = _dalobj.GetBoktips(tipid)
        Return _combiner.BoktipsImgSrcCombinerSingel(retobj)

    End Function


End Class
