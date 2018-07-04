Public Class bokmarkelserController

    Private _dalobj As New bokmarkelserDal

#Region "hämta bokmärkelser"
    Public Function getUserAwards(userid As Integer) As List(Of bokmarkelserAwardsInfo)

        Dim earnobj As New transaktionController
        Dim itmobj As New List(Of bokmarkelserAwardsInfo)

        For Each itm In _dalobj.getUserAwards(userid)
            If itm.UserLevel >= itm.Occures Then

                itmobj.Add(itm)
            Else
                'ToLevelUpX
                If itm.Counter >= (itm.UserLevel * 10) Then
                    Dim nylevel As Integer = itm.UserLevel + 1

                    'ADD award to BIBBLOMONEY LIBRARY earn bibblomoney if levelup
                    earnobj.earnevent(itm.EarnFuncID, userid)

                    _dalobj.updateLevelToUser(userid, itm.AwardGroup, nylevel)

                    itm.UserLevel = nylevel

                    itmobj.Add(itm)
                Else
                    itmobj.Add(itm)

                End If

            End If

        Next

        Return itmobj

    End Function
    Public Function getUserValdAward(userid As Integer, awardgroup As Integer) As List(Of bokmarkelserAwardsInfo)
        Dim itmobj As New List(Of bokmarkelserAwardsInfo)

        For Each itm In _dalobj.getvaldUserAwards(userid, awardgroup)
            If itm.UserLevel >= itm.Occures Then

                itmobj.Add(itm)
            Else

                If itm.Counter >= (itm.UserLevel * 10) Then
                    Dim nylevel As Integer = itm.UserLevel + 1

                    _dalobj.updateLevelToUser(userid, itm.AwardGroup, nylevel)

                    itm.UserLevel = nylevel

                    itmobj.Add(itm)
                Else
                    itmobj.Add(itm)

                End If

            End If

        Next

        Return itmobj

    End Function
#End Region

#Region "ADD/Lägg till eller uppdatera användarens bokmärkelser"
    Public Function setBokmarkelse(userid As Integer, awardgroupName As String) As Boolean

        Return setBokmarkelse(userid, _dalobj.awardNameToAwardId(awardgroupName))

    End Function

    Public Function setBokmarkelse(userid As Integer, awardgroup As Integer) As Boolean
        Try
            ' tabort alla som tidigare har badge för aktuell awardgroup badge får endast finnas en gång
            If checkIfAwardOccuresOnceRule(awardgroup) Then
                newBadgeholderdeleteOther(awardgroup)
            End If

            'kolla om user har award sedan tidigare
            If CheckuserAward(userid, awardgroup) Then
                ' om user har denna award sedan tidigare adda 1 till counter
                ' TODO lägg till PointsEarned från tblAjBokmarkelseGrupper och räkna ut ny level
                appendPointToUserAward(userid, awardgroup, 1)

            Else
                ' om inte har denna lägg till 
                AddAwardTyptoUser(userid, awardgroup, 1)

            End If

            Return True
        Catch ex As Exception

            Return False
        End Try

    End Function
#End Region

#Region "Skapa ny och tabort bokmärkelse awardgroup"

    Public Function addAwardOccureOnceGroup(awardgroupnamn As String, awardname As String, beskrivning As String, badgesrc As String) As Boolean
        Dim ret As Boolean = False
        Dim nyttAwardgroupid As Integer = _dalobj.addNyAwardgroup(awardgroupnamn, 1) 'occureonce = 0 false, = 1 true

        If nyttAwardgroupid > 0 Then
            ret = _dalobj.addNyAwardbokmarkelse(awardname, beskrivning, badgesrc, 1, nyttAwardgroupid, 1)

        End If

        Return ret

    End Function

    Public Function delAwardgroup(awardgroupName As String) As Boolean
        Try

            Dim awardid As Integer = _dalobj.awardNameToAwardId(awardgroupName)
            _dalobj.DelAwardGrupp(awardid)
            _dalobj.DelAwardOccuresOnce(awardid)
            _dalobj.Delbokmarkelse(awardid)

            Return True

        Catch ex As Exception
            Return False

        End Try

    End Function
#End Region

#Region "Private funktioner"
    Private Function CheckuserAward(userid As Integer, awardgroup As Integer) As Boolean

        Return _dalobj.checkifUserhasAwardTyp(userid, awardgroup)

    End Function

    Private Function appendPointToUserAward(userid As Integer, awardgroup As Integer, pointtoadd As Integer) As Boolean

        Return _dalobj.EditAwardPointToUser(userid, awardgroup, pointtoadd)

    End Function

    Private Function AddAwardTyptoUser(userid As Integer, awardgroup As Integer, pointtoadd As Integer) As Boolean

        Return _dalobj.addAwardToUser(userid, awardgroup, pointtoadd)

    End Function
    Private Function checkIfAwardOccuresOnceRule(awardgroup As Integer) As Boolean
        Return _dalobj.isAwardOccuresOnceRule(awardgroup)

    End Function

    Private Function newBadgeholderdeleteOther(awardgroup As Integer) As Boolean
        Return _dalobj.DelAwardOccuresOnce(awardgroup)
    End Function
#End Region


End Class



