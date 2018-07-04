
Public Class RandomBoktips

    Public Function getRandomBoktips(ByVal antaltips As Integer, ByVal rndList As List(Of boktipsInfo)) As List(Of boktipsInfo)

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

