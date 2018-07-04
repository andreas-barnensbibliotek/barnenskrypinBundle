Public Class BooktipsByDateController

    Private _dalObj As New boktipsDateDAL
    Private _combiner As New boktipsImgSrcCombiner

    Public Function boktipsByDateLatest(antal As Integer) As List(Of boktipsInfo)

        Dim combined As New List(Of boktipsInfo)

        If antal > 0 Then

            Dim tmplist As List(Of boktipsInfo) = _dalObj.boktipsAuthorNameBaseInfo(antal)
            combined = _combiner.BoktipsImgSrcCombiner(tmplist)

        End If

        Return combined

    End Function
End Class
