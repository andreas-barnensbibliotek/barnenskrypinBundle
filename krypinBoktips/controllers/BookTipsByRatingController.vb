Public Class BookTipsByRatingController

    Private _dalObj As New boktipsRatingDAL
    Private _combiner As New boktipsImgSrcCombiner

    Public Function boktipsByRating(antal As Integer) As List(Of boktipsInfo)

        Dim combined As New List(Of boktipsInfo)

        If antal <= 0 Then
            antal = 5
        End If

        Dim tmplist As List(Of boktipsInfo) = _dalObj.boktipsByRating(antal)
        combined = _combiner.BoktipsImgSrcCombiner(tmplist)

        Return combined

    End Function
End Class
