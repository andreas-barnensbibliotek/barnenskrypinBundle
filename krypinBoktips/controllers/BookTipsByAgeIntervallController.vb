

Public Class BookTipsByAgeIntervallController

    Private _dalObj As New boktipsAgeIntervallDAL
    Private _combiner As New boktipsImgSrcCombiner

    Public Function boktipsAgeInterval(age As Integer) As List(Of boktipsInfo)

        Dim combined As New List(Of boktipsInfo)

        If age > 0 Then

            Dim tmplist As List(Of boktipsInfo) = _dalObj.boktipsAgeIntervalMinMax(age)
            combined = _combiner.BoktipsImgSrcCombiner(tmplist)

        End If

        Return combined

    End Function

End Class


