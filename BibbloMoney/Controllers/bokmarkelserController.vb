Public Class bokmarkelserController

    Private _dalobj As New bokmarkelserDal
    Private _transobj As New transaktionController

#Region "hämta bokmärkelser"
    Public Function getUserAwards(userid As Integer) As List(Of bokmarkelserAwardsInfo)

        Return _dalobj.getUserAwards(userid)

    End Function
    Public Function getUserValdAward(userid As Integer, awardgroupid As Integer) As List(Of bokmarkelserAwardsInfo)
        Dim retobj As New List(Of bokmarkelserAwardsInfo)
        retobj.Add(_dalobj.getvaldUserAwards(userid, awardgroupid))

        Return retobj
    End Function


#End Region

#Region "ADD/Lägg till eller uppdatera användarens bokmärkelser"
    Public Function setBokmarkelse(userid As Integer, awardgroupName As String) As Boolean

        Return setBokmarkelse(userid, _dalobj.awardNameToAwardId(awardgroupName))

    End Function

    'Public Function setBokmarkelse_old(userid As Integer, awardgroupid As Integer) As Boolean
    '    Try
    '        ' tabort alla som tidigare har badge för aktuell awardgroup badge får endast finnas en gång
    '        If checkIfAwardOccuresOnceRule(awardgroupid) Then
    '            newBadgeholderdeleteOther(awardgroupid)
    '        End If


    '        'kolla om user har award sedan tidigare
    '        If CheckuserAward(userid, awardgroupid) Then
    '            ' om user har denna award sedan tidigare adda 1 till counter
    '            ' TODO lägg till PointsEarned från tblAjBokmarkelseGrupper och räkna ut ny level
    '            appendPointToUserAward(userid, awardgroupid, 1)

    '        Else
    '            ' om inte har denna lägg till 
    '            AddAwardTyptoUser(userid, awardgroupid, 1)

    '        End If

    '        Return True
    '    Catch ex As Exception

    '        Return False
    '    End Try

    'End Function

    Public Function setBokmarkelse(userid As Integer, awardgroupid As Integer) As Boolean
        Try
            ' tabort alla som tidigare har badge för aktuell awardgroup badge får endast finnas en gång
            If checkIfAwardOccuresOnceRule(awardgroupid) Then
                newBadgeholderdeleteOther(awardgroupid)
            End If


            'kolla om user har award sedan tidigare
            If CheckuserAward(userid, awardgroupid) Then
                ' om user har denna award sedan tidigare adda 1 till counter

                appendPointToUserAward(userid, awardgroupid, 1)
                ' TODO lägg till PointsEarned från tblAjBokmarkelseGrupper och räkna ut ny level
                Dim itm As bokmarkelserAwardsInfo = _dalobj.getvaldUserAwards(userid, awardgroupid)

                If itm.UserLevel < itm.Occures Then

                    If itm.Counter >= (itm.UserLevel * itm.TolevelUp) Then
                        Dim nylevel As Integer = itm.UserLevel + 1

                        'Update level för bokmärkelsen
                        _dalobj.updateLevelToUser(itm.Userid, itm.AwardGroup, nylevel)

                        'Earn FUNKTION adda rätt antal bibblomoney hämtat från earnFuncid
                        _transobj.earnevent(itm.EarnFuncID, userid)

                    End If

                End If




            Else
                ' om inte har denna lägg till 
                AddAwardTyptoUser(userid, awardgroupid, 1)

            End If

            Return True
        Catch ex As Exception

            Return False
        End Try

    End Function


#End Region

#Region "Skapa ny och tabort bokmärkelse awardgroup"

    Public Function addNewAwardGroup(awardgroupnamn As String, awardname As String, beskrivning As String, badgesrc As String, occures As Integer) As Boolean
        Dim ret As Boolean = False

        If _dalobj.awardNameToAwardId(awardgroupnamn) <= 0 Then 'kolla så att namnet inte redan finns is return false!!

            Dim nyttAwardgroupid As Integer = _dalobj.addNyAwardgroup(awardgroupnamn, occures) 'occureonce = 0 false, = 1 true

            If nyttAwardgroupid > 0 Then
                ret = _dalobj.addNyAwardbokmarkelse(awardname, beskrivning, badgesrc, 1, nyttAwardgroupid, occures)

            End If
        End If

        Return ret

    End Function

    Public Function delAwardgroupbyAwardGroupName(awardgroupName As String) As Boolean
        Dim awardgroupid = _dalobj.awardNameToAwardId(awardgroupName)
        Return delAwardgroup(awardgroupid)

    End Function

    Public Function delAwardgroupbyID(awardgroupid As Integer) As Boolean
        Return delAwardgroup(awardgroupid)

    End Function

#End Region

#Region "Private funktioner"
    'Private Function checkuserawards(itmlistobj As List(Of bokmarkelserAwardsInfo)) As List(Of bokmarkelserAwardsInfo)
    '    Dim itmobj As New List(Of bokmarkelserAwardsInfo)

    '    For Each itm In itmlistobj
    '        If itm.UserLevel >= itm.Occures Then

    '            itmobj.Add(itm)
    '        Else

    '            If itm.Counter >= (itm.UserLevel * itm.TolevelUp) Then
    '                Dim nylevel As Integer = itm.UserLevel + 1

    '                _dalobj.updateLevelToUser(itm.Userid, itm.AwardGroup, nylevel)

    '                itm.UserLevel = nylevel

    '                itmobj.Add(itm)
    '            Else
    '                itmobj.Add(itm)

    '            End If

    '        End If

    '    Next

    '    Return itmobj
    'End Function
    Private Function delAwardgroup(awardgroupid As Integer) As Boolean
        Try

            _dalobj.DelAwardGrupp(awardgroupid)
            _dalobj.DelAwardOccuresOnce(awardgroupid)
            _dalobj.Delbokmarkelse(awardgroupid)

            Return True

        Catch ex As Exception
            Return False

        End Try

    End Function
    Private Function CheckuserAward(userid As Integer, awardgroup As Integer) As Boolean

        Return _dalobj.checkifUserhasAwardTyp(userid, awardgroup)

    End Function
    Private Function getCheckuserAward(userid As Integer, awardgroup As Integer) As Boolean

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



