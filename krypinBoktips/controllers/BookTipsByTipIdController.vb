Public Class BookTipsByTipIdController
    Private _dalobj As New CRUDBoktipsDAL

    Public Function getbooktip(tipid As Integer) As boktipsInfo
        Dim retobj As New boktipsInfo
        Return _dalobj.GetBoktips(tipid)

    End Function

End Class
