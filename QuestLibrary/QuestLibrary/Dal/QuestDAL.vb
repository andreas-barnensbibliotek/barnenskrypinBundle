Public Class QuestDAL

#Region "DATA LINQ SETUP"
    Private connectionObj As New connectionstringHandler
    Private _linqObj As New QuestLinqDataContext(connectionObj.CurrentConnectionString)
#End Region

    Public Function activeQuestList(cmdtyp As cmdInfo) As List(Of QuestInfo)
        Dim retobj As New List(Of QuestInfo)

        Dim db = From q In _linqObj.tbl_aj_Quests
                 Where q.Active = 1
                 Select q

        For Each itm In db
            Dim tmpobj As New QuestInfo
            tmpobj.Aid = itm.Aid
            tmpobj.Uppdrag = itm.Uppdrag
            tmpobj.questbeskrivning = itm.Beskrivning
            tmpobj.QuestBadgeSrc = questbadges(itm.Aid)
            cmdtyp.QuestID = itm.QuestId
            tmpobj.QuestCompleted = isQuestcompleted(cmdtyp)
            tmpobj.QuestID = itm.QuestId
            tmpobj.Subquestlist = subQuestSubQuestlist(cmdtyp)
            tmpobj.Statuscode = 1

            retobj.Add(tmpobj)
        Next

        Return retobj

    End Function

    Public Function subQuestSubQuestlist(cmdtyp As cmdInfo) As List(Of subquestinfo)
        Dim subQlist As New List(Of subquestinfo)
        Dim db = From sq In _linqObj.tbl_aj_QuestTriggers
                 Where sq.QID = cmdtyp.QuestID
                 Select sq

        For Each itm In db
            Dim tmpobj As New subquestinfo
            tmpobj.Qid = itm.QID
            tmpobj.QtrigId = itm.QtriggerID
            tmpobj.TName = itm.TName
            tmpobj.TValue = itm.TValue


            subQlist.Add(tmpobj)
        Next

        Return subQlist

    End Function

    Public Function userQuestList(cmdtyp As cmdInfo) As List(Of UserQuestInfo)
        Dim retobj As New List(Of UserQuestInfo)

        Dim db = From q In _linqObj.tbl_aj_QuestUsers
                 Where q.Userid = cmdtyp.Userid
                 Select q

        For Each itm In db
            Dim tmpobj As New UserQuestInfo
            tmpobj.UQuestID = itm.UQuestID
            tmpobj.QuestID = itm.Questid
            tmpobj.QuestCompleted = itm.Completed
            tmpobj.Userid = itm.Userid
            retobj.Add(tmpobj)
        Next

        Return retobj

    End Function

    Public Function Questbyid(cmdtyp As cmdInfo) As QuestInfo
        Dim retobj As New QuestInfo
        Try
            Dim db = (From q In _linqObj.tbl_aj_Quests
                      Where q.QuestId = cmdtyp.QuestID
                      Select q).SingleOrDefault

            retobj.Aid = db.Aid
            retobj.Uppdrag = db.Uppdrag
            retobj.questbeskrivning = db.Beskrivning
            retobj.QuestBadgeSrc = questbadges(db.Aid)
            retobj.QuestID = db.QuestId
            retobj.QuestCompleted = isQuestcompleted(cmdtyp)
        Catch ex As Exception
            retobj.Statuscode = 0
            retobj.Status = "ERROR: Quest hittades ej!"
        End Try
        Return retobj

    End Function


    Public Function userQuest(cmdtyp As cmdInfo) As UserQuestInfo
        Dim retobj As New UserQuestInfo

        Try
            Dim db = (From q In _linqObj.tbl_aj_QuestUsers
                      Where q.Userid = cmdtyp.Userid And q.Questid = cmdtyp.QuestID
                      Select q).SingleOrDefault

            retobj.UQuestID = db.UQuestID
            retobj.QuestID = db.Questid
            retobj.QuestCompleted = db.Completed
            retobj.Userid = db.Userid
            retobj.Statuscode = 1

        Catch ex As Exception
            retobj.Statuscode = 0
        End Try

        Return retobj

    End Function


    'Kolla hur många subquest som finns för en quest
    Public Function QuestSubQuestCount(cmdtyp As cmdInfo) As Integer
        Dim db = From sq In _linqObj.tbl_aj_QuestTriggers
                 Where sq.QID = cmdtyp.QuestID
                 Select sq

        Return db.Count
    End Function

    'Kolla hur många subquest användaren completed i en quest
    Public Function userQuestSubQuestCount(cmdtyp As cmdInfo) As Integer
        Dim db = From sq In _linqObj.tbl_aj_QuestUserToTriggers
                 Where sq.UserQuestID = cmdtyp.uQuestID And sq.Completed = 1
                 Select sq

        Return db.Count
    End Function

    Public Function registerQuestToUser(cmdtyp As cmdInfo) As Boolean
        Try
            Dim quest As New tbl_aj_QuestUser
            quest.Userid = cmdtyp.Userid
            quest.Questid = cmdtyp.QuestID
            quest.Completed = 0
            quest.datum = Date.Now.Date
            quest.tid = Date.Now

            _linqObj.tbl_aj_QuestUsers.InsertOnSubmit(quest)
            _linqObj.SubmitChanges()

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function RemoveQuestFromUser(cmdtyp As cmdInfo) As Boolean
        Dim removed As Boolean = False
        Try
            Dim itm = From e In _linqObj.tbl_aj_QuestUsers
                      Where e.Questid = cmdtyp.QuestID And e.Userid = cmdtyp.Userid
                      Select e

            For Each i In itm
                _linqObj.tbl_aj_QuestUsers.DeleteOnSubmit(i)
                removed = True
            Next

            _linqObj.SubmitChanges()

        Catch ex As Exception
            removed = False
        End Try

        Return removed
    End Function

    Public Function registerSubQuestToUser(cmdobj As cmdInfo, completed As Integer) As Boolean
        Try
            Dim quest As New tbl_aj_QuestUserToTrigger
            quest.UserQuestID = cmdobj.uQuestID
            quest.QTriggerID = cmdobj.QTriggerID
            quest.Completed = completed
            quest.Time = Date.Now

            _linqObj.tbl_aj_QuestUserToTriggers.InsertOnSubmit(quest)
            _linqObj.SubmitChanges()

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function updateUserQuestToCompleted(cmdtyp As cmdInfo, complete As Integer) As Boolean
        Dim retobj As Boolean = False
        Try
            Dim questlist = From i In _linqObj.tbl_aj_QuestUsers
                            Select i
                            Where i.UQuestID = cmdtyp.uQuestID

            For Each itm In questlist
                itm.Completed = complete
                retobj = True
            Next

            _linqObj.SubmitChanges()
        Catch ex As Exception

        End Try

        Return retobj

    End Function


    Public Function updateSubQuestToUser(cmdtyp As cmdInfo, complete As Integer) As Boolean
        Dim retobj As Boolean = False
        Try
            Dim questlist = From i In _linqObj.tbl_aj_QuestUserToTriggers
                            Select i
                            Where i.QTriggerID = cmdtyp.QTriggerID

            For Each itm In questlist
                itm.Completed = complete
                retobj = True
            Next

            _linqObj.SubmitChanges()
        Catch ex As Exception

        End Try

        Return retobj

    End Function

    Public Function isQuestRegisterToUser(cmdtyp As cmdInfo) As UserQuestInfo
        Dim retobj As New UserQuestInfo
        retobj.QuestCompleted = -1 'Finns inte med i listan

        Dim questlist = From i In _linqObj.tbl_aj_QuestUsers
                        Select i
                        Where i.Userid = cmdtyp.Userid And i.Questid = cmdtyp.QuestID

        For Each x In questlist
            retobj.Userid = x.Userid
            retobj.QuestID = x.Questid
            retobj.UQuestID = x.UQuestID
            retobj.QuestCompleted = x.Completed

            Dim questobj As QuestInfo = Questbyid(cmdtyp)
            retobj.Uppdrag = questobj.Uppdrag
            retobj.questbeskrivning = questobj.questbeskrivning
            retobj.QuestBadgeSrc = questobj.QuestBadgeSrc
            retobj.AID = questobj.Aid

            retobj.Statuscode = 1
        Next

        Return retobj

    End Function

    Public Function isSubQuestRegistedToUser(cmdtyp As cmdInfo) As userSubquestInfo
        Dim retsubquest As New userSubquestInfo

        Dim questlist = From i In _linqObj.tbl_aj_QuestUserToTriggers
                        Select i
                        Where i.QTriggerID = cmdtyp.QTriggerID And i.UserQuestID = cmdtyp.uQuestID

        For Each x In questlist
            retsubquest.Id = x.id
            retsubquest.subquestid = x.QTriggerID
            retsubquest.Userquestid = x.UserQuestID
            retsubquest.SubQuestCompleted = x.Completed
        Next

        Return retsubquest

    End Function

    Public Function isRequestedQuestAQuest(cmdtyp As cmdInfo) As Boolean
        Dim retobj As Boolean = False
        Dim questlist = From i In _linqObj.tbl_aj_Quests
                        Select i
                        Where i.QuestId = cmdtyp.QuestID

        For Each x In questlist
            retobj = True
        Next

        Return retobj

    End Function

    Public Function GetsubQuest(Qtriggerid As Integer) As subquestinfo
        Dim retobj As New subquestinfo

        Dim QObj = (From i In _linqObj.tbl_aj_QuestTriggers
                    Where i.QtriggerID = Qtriggerid).FirstOrDefault()

        With retobj
            .Qid = QObj.QID
            .QtrigId = QObj.QtriggerID
            .TName = QObj.TName
            .TValue = QObj.TValue

        End With

        Return retobj

    End Function

    Public Function GetQuest(Qid As Integer) As UserQuestInfo
        Dim retobj As New UserQuestInfo

        Dim QObj = (From i In _linqObj.tbl_aj_Quests
                    Where i.QuestId = Qid).FirstOrDefault()

        With retobj
            .QuestID = QObj.QuestId
            .Uppdrag = QObj.Uppdrag
            .questbeskrivning = QObj.Beskrivning

        End With

        Return retobj

    End Function

    Public Function TestifCorrectInSubquest(cmdtyp As cmdInfo) As Boolean
        Dim retobj As Boolean = False

        Dim QObj = From i In _linqObj.tbl_aj_QuestTriggers
                   Where i.QtriggerID = cmdtyp.QTriggerID And i.TValue = cmdtyp.Svar

        For Each itm In QObj
            retobj = True
            Exit For
        Next

        Return retobj

    End Function
    Private Function isQuestcompleted(cmdtyp As cmdInfo) As Integer
        Dim retobj As Integer = -1  'Finns inte med i listan

        Dim questlist = From i In _linqObj.tbl_aj_QuestUsers
                        Select i
                        Where i.Userid = cmdtyp.Userid And i.Questid = cmdtyp.QuestID

        For Each x In questlist
            retobj = x.Completed
        Next

        Return retobj

    End Function

    Public Function isUserSubQuestcompleted(userid As Integer, questid As Integer, triggerid As Integer) As Integer
        Dim retobj As Integer = -1  'Finns inte med i listan

        Dim questlist = From i In _linqObj.aj_quest_isUserSubQuestCompleted(userid, questid, triggerid)

        For Each x In questlist
            retobj = x.Completed
        Next

        Return retobj

    End Function

    Public Function questbadges(Awardid As Integer) As String

        Dim questlist = (From i In _linqObj.tblAjBokmarkelsers
                         Where i.Awardgroup = Awardid).FirstOrDefault()

        Return questlist.Badgesrc

    End Function

End Class
