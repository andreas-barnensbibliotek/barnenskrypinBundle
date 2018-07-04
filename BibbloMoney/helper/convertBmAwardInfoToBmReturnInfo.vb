Public Class convertBmAwardInfoToBmReturnInfo
    Public Function convert(tmpobj As List(Of bokmarkelserAwardsInfo)) As bokmarkelserReturnInfo
        Dim retobj As New bokmarkelserReturnInfo
        Dim retlist As New List(Of bokmarkelseItemInfo)

        For Each itm In tmpobj
            Dim tmp As New bokmarkelseItemInfo
            tmp.AwardName = itm.AwardName
            tmp.Badgesrc = itm.Badgesrc
            tmp.Beskrivning = itm.Beskrivning
            retlist.Add(tmp)
        Next
        retobj.Bokmarkelser = retlist

        Return retobj

    End Function
End Class
