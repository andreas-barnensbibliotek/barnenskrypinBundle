Public Class BooktTipsByRandomController
    Private _combiner As New boktipsImgSrcCombiner

    Public Function getRandomBoktips(ByVal antal As Integer) As List(Of boktipsInfo)
        Dim tipobj As New boktipsGetAllDAL

        Dim rndlist As List(Of boktipsInfo) = tipobj.getBokTipsAlla()

        If antal < 1 Then
            antal = 1
        End If

        Dim newlist As List(Of boktipsInfo) = GenerateRandomBoktips(antal, rndlist)

        rndlist = _combiner.BoktipsImgSrcCombiner(newlist)

        Return rndlist

    End Function

    Private Function GenerateRandomBoktips(ByVal antaltips As Integer, ByVal rndList As List(Of boktipsInfo)) As List(Of boktipsInfo)
        Dim retlist As New List(Of boktipsInfo)
        Dim tipHolder As New boktipsInfo

        If antaltips > rndList.Count Then
            antaltips = rndList.Count
        End If

        Dim RandString As New Random()

        For i As Int16 = 1 To antaltips
            tipHolder = rndList(RandString.Next(0, rndList.Count))
            retlist.Add(tipHolder)
        Next

        Return retlist
    End Function
End Class
