Imports KrypinBokmarkelser
Public Class QuestMainController
    Private _dalobj As New QuestDAL


#Region "USER EVENT"

    'Registrera quest till användaren.
    'kolla om questen finns i userquestlistan om inte finns regga den då
    Public Function RegisterQuest(cmdtyp As cmdInfo) As UserQuestInfo

        Dim retobj As UserQuestInfo = SecuretyQuestCheck(cmdtyp)

        If retobj.Statuscode = 1 Then
            If _dalobj.registerQuestToUser(cmdtyp) Then

                retobj.Status = "Uppdraget registrerat!"
            Else
                retobj.Status = "ERROR vid registrering"
            End If
        End If

        Return retobj
    End Function

    Public Function CompleteSubQuest(cmdtyp As cmdInfo) As UserQuestInfo
        Dim retobj As UserQuestInfo = SecuretyQuestCheck(cmdtyp)
        Dim usersubquest As New userSubquestInfo
        ' ex 7017 uQuestID=1, qtriggerid=1, svar= "1233".

        If retobj.Statuscode = 1 Then

            If _dalobj.TestifCorrectInSubquest(cmdtyp) Then
                usersubquest = _dalobj.isSubQuestRegistedToUser(cmdtyp)

                AddToAward(cmdtyp) 'Svaret är korrekt lägg till point i till bokmärkelsen

                If usersubquest.Id > 0 Then
                    If _dalobj.updateSubQuestToUser(cmdtyp, 1) Then

                        retobj.Status = "Subquest updated to Completed!"
                    Else
                        retobj.Status = "ERROR Fel vid uppdatering to Completed!"
                    End If
                Else
                    _dalobj.registerSubQuestToUser(cmdtyp, 1)
                    retobj.Status = "Subquest added to Completed!"
                End If


            Else
                retobj.Status = "Subquest fel svar!"
                retobj.Statuscode = 3

            End If

        Else
            retobj.Status = "ERROR vid registrering av subquest"

        End If

        Return retobj
    End Function

    Public Function isuserinquest(cmdtyp As cmdInfo) As UserQuestInfo
        Dim retobj As New UserQuestInfo
        retobj.Status = "ERROR Användaren har inte registrerat uppdraget"

        retobj = _dalobj.isQuestRegisterToUser(cmdtyp)

        If retobj.Statuscode = 1 Then
            retobj.Status = "Uppdraget är registrerat"
        End If

        Return retobj

    End Function
#End Region


#Region "Quest EVENT"

    Public Function getQuestInfo(cmdtyp As cmdInfo) As UserQuestInfo
        Dim userQuestobj As New UserQuestInfo
        Dim questobj As New QuestInfo

        questobj = _dalobj.Questbyid(cmdtyp)

        userQuestobj.QuestID = questobj.QuestID
        userQuestobj.questbeskrivning = questobj.questbeskrivning
        userQuestobj.Uppdrag = questobj.Uppdrag
        userQuestobj.QuestBadgeSrc = questobj.QuestBadgeSrc
        userQuestobj.Subquestlist = userSubquestcompletedList(cmdtyp)
        userQuestobj.QuestCompleted = questobj.QuestCompleted

        Return userQuestobj

    End Function
    Private Function userSubquestcompletedList(cmdtyp As cmdInfo) As List(Of subquestinfo)

        Dim allsubquests As List(Of subquestinfo) = _dalobj.subQuestSubQuestlist(cmdtyp)

        For Each itm In allsubquests

            itm.Completed = _dalobj.isUserSubQuestcompleted(cmdtyp.Userid, cmdtyp.QuestID, itm.QtrigId)
        Next

        Return allsubquests

    End Function
    Public Function getSubQuest(cmdtyp As cmdInfo) As UserQuestInfo
        Dim userQuestobj As New UserQuestInfo
        Dim subquestObj As New userSubquestInfo
        ' ex 7017 QuestID=1, subquestID=1 Hämta questid beskrivning, och subquesten return

        If cmdtyp.Userid > 0 Then

            userQuestobj = _dalobj.isQuestRegisterToUser(cmdtyp)

            If userQuestobj.Statuscode = 1 Then ' användare har questen registrerad 

                Select Case userQuestobj.QuestCompleted

                    Case 1
                        userQuestobj.Status = "Quest completed!"
                        userQuestobj.Statuscode = 1

                    Case 0 ' Quest ej klar kolla om SUBQUEST är klar---
                        cmdtyp.uQuestID = userQuestobj.UQuestID
                        subquestObj = _dalobj.isSubQuestRegistedToUser(cmdtyp)

                        If subquestObj.SubQuestCompleted = 0 Then ' subquest finns inte i listan eller är inte klar VISA upp för ANVÄNDAREN.
                            'Hämta questuppgifterna
                            'Return qtriggerid och uquestid
                            userQuestobj.Subquestlist.Add(_dalobj.GetsubQuest(cmdtyp.QTriggerID))
                            userQuestobj.Statuscode = 2
                            userQuestobj.Status = "User subquest ready to complete"

                        Else
                            userQuestobj = New UserQuestInfo
                            userQuestobj.Status = "Subquest completed!"
                            userQuestobj.Statuscode = 1

                        End If

                    Case Else
                        userQuestobj.Status = "ERROR Quest finns inte!"
                        userQuestobj.Statuscode = -1

                End Select

            Else
                userQuestobj.Status = "Quest in not registered!"
                userQuestobj.Statuscode = 0

            End If

        Else
            userQuestobj.Status = "Error User not logged in"
            userQuestobj.Statuscode = -1

        End If

        Return userQuestobj ' om statuscode = 2 VISA ELSE visa inte

    End Function

    Public Function removeQuestFromUser(cmdtyp As cmdInfo) As UserQuestInfo
        Dim retobj As UserQuestInfo = SecuretyQuestCheck(cmdtyp)

        If retobj.Statuscode = 1 Then
            If _dalobj.RemoveQuestFromUser(cmdtyp) Then
                retobj.Status = "Uppdraget avregistrerat!"
            Else
                retobj.Status = "Finns inget uppdrag att avregistrering!"
            End If
        End If

        Return retobj

    End Function

#End Region

#Region "List EVENT"

    Public Function getActiveQuestList(cmdtyp As cmdInfo) As UserQuestInfo
        Dim retobj As New UserQuestInfo

        If cmdtyp.Userid > 0 Then

            'Kolla och uppdatera completed quests
            CorrectCompletedQuest(cmdtyp)

            retobj.ActiveQuests = _dalobj.activeQuestList(cmdtyp)
            retobj.Statuscode = 1
            retobj.Status = "Active questlist hämtad"
        Else
            retobj.Status = "Error: Användaren måste vara inloggad"
        End If

        Return retobj
    End Function

    Public Function checkQuestStatus(cmdtyp As cmdInfo) As UserQuestInfo
        Dim retobj As New UserQuestInfo

        Try
            If cmdtyp.Userid > 0 Then
                retobj = _dalobj.userQuest(cmdtyp)

                If retobj.Statuscode > 0 Then
                    retobj.QuestProggressStatus.subQuestCompleted = _dalobj.userQuestSubQuestCount(cmdtyp)
                    retobj.QuestProggressStatus.SubQuestTotal = _dalobj.QuestSubQuestCount(cmdtyp)

                    retobj.Statuscode = 1
                    retobj.Status = "Quest Progress status collected!"
                Else
                    retobj.Status = "Uppdraget är inte registrerat"
                End If

            Else
                retobj.Status = "Error: Användaren måste vara inloggad"
                retobj.Statuscode = -1
            End If
        Catch ex As Exception
            retobj.Status = "Error: collecting quest Progress!"
        End Try

        Return retobj
    End Function

#End Region

#Region "helper functions"
    Public Sub CorrectCompletedQuest(cmdtyp As cmdInfo)
        Dim userquestlist As New List(Of UserQuestInfo)
        userquestlist = _dalobj.userQuestList(cmdtyp)

        For Each itm In userquestlist
            cmdtyp.uQuestID = itm.UQuestID
            cmdtyp.QuestID = itm.QuestID
            If _dalobj.userQuestSubQuestCount(cmdtyp) >= _dalobj.QuestSubQuestCount(cmdtyp) Then
                _dalobj.updateUserQuestToCompleted(cmdtyp, 1)

            End If
        Next

    End Sub

    Public Sub AddToAward(cmdtyp As cmdInfo)

        Dim bokmarkelseHandler As New KrypinBokmarkelserMainController
        bokmarkelseHandler.setuseraward(cmdtyp.Userid, _dalobj.Questbyid(cmdtyp).Aid)

    End Sub
#End Region

#Region "Privatefunction"
    Private Function SecuretyQuestCheck(cmdtyp As cmdInfo) As UserQuestInfo
        Dim questobj As New UserQuestInfo
        If cmdtyp.Userid > 0 Then

            Dim regobj As UserQuestInfo = _dalobj.isQuestRegisterToUser(cmdtyp)
            If regobj.Statuscode = 0 Then 'Uppdraget är inte registrerat

                If _dalobj.isRequestedQuestAQuest(cmdtyp) Then
                    questobj.Statuscode = 1 'statuscode 1 = testen är ok
                Else
                    questobj.Status = "ERROR, Uppdraget finns inte!"
                End If

            Else
                If regobj.QuestCompleted = 0 Then
                    questobj.Statuscode = 1
                    questobj.Status = "Uppdraget finns men är inte completed"
                Else
                    questobj.Status = "ERROR, Användaren har redan uppdraget registrerat!"
                End If
            End If

        Else
            questobj.Status = "ERROR, Uppdraget(quest) gick inte att registrera!"
        End If

        Return questobj

    End Function


#End Region


End Class
