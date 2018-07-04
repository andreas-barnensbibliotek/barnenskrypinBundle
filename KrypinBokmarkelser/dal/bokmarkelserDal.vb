Public Class bokmarkelserDal

#Region "DATA LINQ SETUP"
    Private connectionObj As New connectionstringHandler
    Private _linqObj As New bokmarkelserLinqDataContext(connectionObj.CurrentConnectionString)
#End Region
    Public Function checkifUserhasAwardTyp(usrid As Integer, awardgroup As Integer) As Boolean
        Dim ret As Boolean = False

        Dim bl = From t In _linqObj.tblAjBokmarkelserPointCounters
                 Where t.Userid = usrid And t.Aid = awardgroup
                 Select t


        For Each t In bl
            ret = True
        Next

        Return ret

    End Function

    Public Function EditAwardPointToUser(userid As Integer, awardgroup As Integer, pointtoadd As Integer) As Boolean

        Dim ret As Boolean = False

        Dim bl = (From t In _linqobj.tblAjBokmarkelserPointCounters
                  Where t.Userid = userid And t.Aid = awardgroup
                  Select t).First()
        Try

            bl.Counters += pointtoadd
            _linqobj.SubmitChanges()

            ret = True
        Catch ex As Exception
            ret = False
        End Try

        Return ret

    End Function

    Public Function addAwardToUser(userid As Integer, awardgroup As Integer, pointtoadd As Integer) As Boolean

        Dim Inlagd As Boolean = False

        Try
            Dim b As New tblAjBokmarkelserPointCounter
            b.Aid = awardgroup
            b.Userid = userid
            b.Counters = pointtoadd
            b.Levels = 1

            _linqobj.tblAjBokmarkelserPointCounters.InsertOnSubmit(b)
            _linqobj.SubmitChanges()

            Inlagd = True

        Catch ex As Exception
            Inlagd = False
        End Try

        Return Inlagd
    End Function
    Public Function getUserAwards(usrid As Integer) As List(Of bokmarkelserAwardsInfo)

        Dim retobj As New List(Of bokmarkelserAwardsInfo)

        Dim bl = From t In _linqObj.ajbokmarkelser(1, usrid, 0)

        For Each t In bl
            Dim tmp As New bokmarkelserAwardsInfo
            tmp.Awardid = t.Aid
            tmp.AwardName = t.Awardname
            tmp.Userid = t.Userid
            tmp.Badgesrc = t.Badgesrc
            tmp.Beskrivning = t.Beskrivning
            tmp.Counter = t.Counters
            tmp.UserLevel = t.Levels
            tmp.Occures = t.Occurs
            tmp.AwardGroup = t.Awardgroup
            tmp.EarnFuncID = t.BibblimoneyEarnID

            retobj.Add(tmp)
        Next

        Return retobj

    End Function

    Public Function getvaldUserAwards(usrid As Integer, awardid As Integer) As List(Of bokmarkelserAwardsInfo)

        Dim retobj As New List(Of bokmarkelserAwardsInfo)

        Dim bl = From t In _linqobj.ajbokmarkelser(2, usrid, awardid)

        For Each t In bl
            Dim tmp As New bokmarkelserAwardsInfo
            tmp.Awardid = t.Aid
            tmp.AwardName = t.Awardname
            tmp.Userid = t.Userid
            tmp.Badgesrc = t.Badgesrc
            tmp.Beskrivning = t.Beskrivning
            tmp.Counter = t.Counters
            tmp.UserLevel = t.Levels
            tmp.Occures = t.Occurs
            tmp.AwardGroup = t.Awardgroup
            tmp.EarnFuncID = t.BibblimoneyEarnID

            retobj.Add(tmp)
        Next

        Return retobj

    End Function

    Public Function updateLevelToUser(userid As Integer, awardgroup As Integer, level As Integer) As Boolean

        Dim ret As Boolean = False

        Dim bl = (From t In _linqobj.tblAjBokmarkelserPointCounters
                  Where t.Userid = userid And t.Aid = awardgroup
                  Select t).First()
        Try

            bl.Levels = level
            _linqobj.SubmitChanges()

            ret = True
        Catch ex As Exception
            ret = False
        End Try

        Return ret

    End Function

    Public Function isAwardOccuresOnceRule(awardgroup As Integer) As Boolean
        Dim ret As Boolean = False

        Dim bl = From t In _linqObj.tblAjBokmarkelseGruppers
                 Where t.AwardGroupID = awardgroup And t.Occures = 1
                 Select t

        For Each t In bl
            ret = True
        Next

        Return ret

    End Function


    Public Function DelAwardOccuresOnce(awardgroup As Integer) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim itm = From c In _linqobj.tblAjBokmarkelserPointCounters
                      Where c.Aid = awardgroup
                      Select c

            For Each i In itm
                _linqobj.tblAjBokmarkelserPointCounters.DeleteOnSubmit(i)
            Next

            _linqobj.SubmitChanges()
            deleted = True
        Catch ex As Exception
            deleted = False
        End Try

        Return deleted
    End Function

    Public Function DelAwardGrupp(awardgroup As Integer) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim itm = From c In _linqobj.tblAjBokmarkelseGruppers
                      Where c.AwardGroupID = awardgroup
                      Select c

            For Each i In itm
                _linqobj.tblAjBokmarkelseGruppers.DeleteOnSubmit(i)
            Next

            _linqobj.SubmitChanges()
            deleted = True
        Catch ex As Exception
            deleted = False
        End Try

        Return deleted
    End Function

    Public Function Delbokmarkelse(awardgroup As Integer) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim itm = From c In _linqobj.tblAjBokmarkelsers
                      Where c.Awardgroup = awardgroup
                      Select c

            For Each i In itm
                _linqobj.tblAjBokmarkelsers.DeleteOnSubmit(i)
            Next

            _linqobj.SubmitChanges()
            deleted = True
        Catch ex As Exception
            deleted = False
        End Try

        Return deleted
    End Function

    Public Function addNyAwardgroup(awardgroupnamn As String, Optional occuresOnce As Integer = 0) As Integer
        Dim Inlagd As Integer

        Try
            Dim b As New tblAjBokmarkelseGrupper
            b.AwardGroup = awardgroupnamn
            b.Occures = occuresOnce

            _linqobj.tblAjBokmarkelseGruppers.InsertOnSubmit(b)
            _linqobj.SubmitChanges()

            Inlagd = b.AwardGroupID

        Catch ex As Exception
            Inlagd = 0
        End Try

        Return Inlagd

    End Function

    Public Function addNyAwardbokmarkelse(awardname As String, beskrivning As String, badgesrc As String, lev As Integer, Awardgroup As Integer, Optional occures As Integer = 0) As Integer
        Dim Inlagd As Integer

        Try
            Dim t As New tblAjBokmarkelser

            t.Awardname = awardname
            t.Levels = lev
            t.Beskrivning = beskrivning
            t.Badgesrc = badgesrc
            t.Occurs = occures
            t.Awardgroup = Awardgroup

            _linqObj.tblAjBokmarkelsers.InsertOnSubmit(t)
            _linqobj.SubmitChanges()

        Catch ex As Exception
            Inlagd = 0
        End Try

        Return Inlagd

    End Function

    Public Function awardNameToAwardId(awardgroupname As String) As Integer
        Dim ret As Integer = 0

        Dim bl = (From t In _linqobj.tblAjBokmarkelseGruppers
                  Where t.AwardGroup = awardgroupname
                  Select t).First()

        ret = bl.AwardGroupID

        Return ret

    End Function

    Public Function getEarnFuncIdFronAwardId(awardGroupId As Integer) As Integer
        Dim ret As Integer = 0

        Dim bl = (From t In _linqObj.tblAjBokmarkelseGruppers
                  Where t.AwardGroupID = awardGroupId
                  Select t).First()

        ret = bl.BibblimoneyEarnID

        Return ret

    End Function
End Class
