Public Class bibbloMoneyMainController
    Public Sub bibblomoneyEarnEvent(earnfuncid As Integer, userid As Integer)
        Dim transobj As New transaktionController
        If earnfuncid > 0 And userid > 0 Then
            transobj.earnevent(earnfuncid, userid)

        End If
    End Sub
    'Public Function getUserbokmarkelser(userid As Integer) As bokmarkelserReturnInfo
    '    Dim retobj As New bokmarkelserReturnInfo
    '    Dim bokmarkelseObj As New bokmarkelserController
    '    Dim Helperconvertobj As New convertBmAwardInfoToBmReturnInfo

    '    Try
    '        retobj = Helperconvertobj.convert(bokmarkelseObj.getUserAwards(userid))
    '        retobj.Userid = userid
    '        retobj.Status = "Bokmärkelselista hämtad"

    '    Catch ex As Exception
    '        retobj.Userid = 0
    '        retobj.Status = "ERROR Bokmärkelselista hämtades inte!"

    '    End Try

    '    Return retobj

    'End Function

    'Public Function setuseraward(userid As Integer, awardid As Integer) As bokmarkelserReturnInfo
    '    Dim bokmarkelseObj As New bokmarkelserController
    '    Dim retobj As New bokmarkelserReturnInfo

    '    retobj.Bokmarkelser = New List(Of bokmarkelseItemInfo)
    '    retobj.Userid = userid

    '    If bokmarkelseObj.setBokmarkelse(userid, awardid) Then
    '        retobj.Status = "Award set to user"
    '    Else
    '        retobj.Status = "ERROR Award sattes INTE till user"
    '    End If

    '    Return retobj
    'End Function

End Class
