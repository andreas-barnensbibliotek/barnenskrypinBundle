Public Class bibbloMoneyMainController

#Region "Bibblomoney handlers"
    Public Sub bibblomoneyEarnEvent(earnfuncid As Integer, userid As Integer)
        Dim transobj As New transaktionController
        If earnfuncid > 0 And userid > 0 Then
            transobj.earnevent(earnfuncid, userid)

        End If
    End Sub
#End Region

#Region "Bokmärkelser handlers"
    Public Function getUserbokmarkelser(userid As Integer) As bokmarkelserReturnInfo
        Dim retobj As New bokmarkelserReturnInfo
        Dim bokmarkelseObj As New bokmarkelserController

        Try
            retobj.Bokmarkelser = bokmarkelseObj.getUserAwards(userid)
            retobj.Userid = userid
            retobj.Status = "Bokmärkelselista hämtad"

        Catch ex As Exception
            retobj.Userid = 0
            retobj.Status = "ERROR Bokmärkelselista hämtades inte!"

        End Try

        Return retobj

    End Function

    Public Function getUserAwardgroupbokmarkelser(userid As Integer, awardgroupID As Integer) As bokmarkelserReturnInfo
        Dim retobj As New bokmarkelserReturnInfo
        Dim bokmarkelseObj As New bokmarkelserController

        Try
            retobj.Bokmarkelser = bokmarkelseObj.getUserValdAward(userid, awardgroupID)
            retobj.Userid = userid
            retobj.Status = "Bokmärkelselista by awardgroupId hämtad"

        Catch ex As Exception
            retobj.Userid = 0
            retobj.Status = "ERROR Bokmärkelselista by awardgroupId hämtades inte!"

        End Try

        Return retobj

    End Function

    Public Function setuserawardbyAwardGroupID(userid As Integer, awardid As Integer) As bokmarkelserReturnInfo
        Dim bokmarkelseObj As New bokmarkelserController
        Dim retobj As New bokmarkelserReturnInfo

        If bokmarkelseObj.setBokmarkelse(userid, awardid) Then
            retobj.Bokmarkelser = bokmarkelseObj.getUserAwards(userid)
            retobj.Userid = userid
            retobj.Status = "Award set to user OK, Bokmärkelselista hämtad"
        Else
            retobj.Status = "ERROR Award NOT set for user"
        End If

        Return retobj
    End Function
    Public Function setuserawardbyAwardgroupName(userid As Integer, awardName As String) As bokmarkelserReturnInfo
        Dim bokmarkelseObj As New bokmarkelserController
        Dim retobj As New bokmarkelserReturnInfo

        If bokmarkelseObj.setBokmarkelse(userid, awardName) Then
            retobj.Bokmarkelser = bokmarkelseObj.getUserAwards(userid)
            retobj.Userid = userid
            retobj.Status = "Award set to user by awardName OK, Bokmärkelselista hämtad "
        Else
            retobj.Status = "ERROR Award by awardName NOT set for user"
        End If

        Return retobj
    End Function


    Public Function addnewAwardGroup(awardgroupnamn As String, awardname As String, beskrivning As String, badgesrc As String, Optional occures As Integer = 0) As bokmarkelserReturnInfo
        Dim isNewAwardGroupCreated As Boolean = False
        Dim retobj As New bokmarkelserReturnInfo
        Dim bokmarkelseObj As New bokmarkelserController

        'occures 1 = visas bara engång bara en användare kan ha denna bokmärkelse
        isNewAwardGroupCreated = bokmarkelseObj.addNewAwardGroup(awardgroupnamn, awardname, beskrivning, badgesrc, occures)

        If isNewAwardGroupCreated Then
            retobj.Status = "Ny Awardgroup med namn: " & awardgroupnamn & " skapad!"
        Else
            retobj.Status = "Awardgroup med namn: " & awardgroupnamn & " finns redan!"
        End If

        Return retobj

    End Function
    Public Function delAwardGroupbyAwardGroupName(awardgroupnamn As String) As bokmarkelserReturnInfo
        Dim isAwardGroupDeleted As Boolean = False
        Dim retobj As New bokmarkelserReturnInfo
        Dim bokmarkelseObj As New bokmarkelserController
        isAwardGroupDeleted = bokmarkelseObj.delAwardgroupbyAwardGroupName(awardgroupnamn)

        If isAwardGroupDeleted Then
            retobj.Status = "Awardgroup med namn" & awardgroupnamn & " är borttagen!"
        Else
            retobj.Status = "ERROR Awardgroup med namn" & awardgroupnamn & " gick inte att tabort!"
        End If

        Return retobj

    End Function
    Public Function delAwardGroupbyAwardGroupID(awardgroupID As Integer) As bokmarkelserReturnInfo
        Dim isAwardGroupDeleted As Boolean = False
        Dim retobj As New bokmarkelserReturnInfo
        Dim bokmarkelseObj As New bokmarkelserController
        isAwardGroupDeleted = bokmarkelseObj.delAwardgroupbyID(awardgroupID)

        If isAwardGroupDeleted Then
            retobj.Status = "Awardgroup med awardID" & awardgroupID & " är borttagen!"
        Else
            retobj.Status = "ERROR Awardgroup med awardID" & awardgroupID & " gick inte att tabort!"
        End If

        Return retobj

    End Function
#End Region



End Class
