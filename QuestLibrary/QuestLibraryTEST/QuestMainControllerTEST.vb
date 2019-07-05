Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports QuestLibrary

<TestClass()> Public Class QuestMainControllerTEST
    'StatusCode: 
    ' 3 = Fel svar i subquest
    ' 2 = Quest registrerad men subquesten är inte completed (visa)
    ' 1 = ok frågan genomfördes som den skulle.  användare är inloggad( userid finns med)
    ' 0 = Något blev fel. kolla statustexten!
    ' -1 = Användaren är inte inloggad
    ' Registrera Quest. 
    ' 1. lägg till ny bokmärkelse grupp (tblAjBokmarkelseGrupper) för att få AwardgruppID
    ' 2. lägg till bokmärkelse i (tblAjBokmarkelser). Ange levels (antalet subfrågor som questen skall ha) lägg till bokmärkelsebilden mm.
    ' 3. lägg till ny quest i tbl_aj_Quests koppla till bokmärket via AwardgruppID= AID
    ' 4. lägg till subquest i tbl_aj_QuestTrigger. lägg till lika många som angets i levels i tblAjBokmarkelser
    ' Klart!

    ' Utför Quest/subquest, Dessa värden måste skickas till servern
    ' 1. Userid,
    ' 2. UserQuestid (uQuestID från tbl_aj_QuestUser)=
    ' 3. QuestID
    ' 4. QTriggerID (tbl_aj_QuestTrigger)
    ' 5. Svar (Tvalue från tbl_aj_QuestTrigger)

    'Lista alla befintliga och Activa quests. vid koll korrigeras frågande användares uppdrag om dom är slutförda 
    'om questcompleted =  -1 Questen är inte registrerad hos användaren
    'om questcompleted = 0 Questen är registrerad men inte klar 
    'om questcompleted = 1 Questen är registrerad och KLAR!

    <TestMethod()> Public Sub ListaQuestTEST()
        Dim obj As New QuestMainController
        Dim retobj As New UserQuestInfo

        Dim cmdobj As New cmdInfo

        cmdobj.Userid = 7017

        retobj = obj.getActiveQuestList(cmdobj)
    End Sub

    'Kolla om quests finns och om den är slutförd
    <TestMethod()> Public Sub checkQueststatusTEST()
        Dim obj As New QuestMainController
        Dim retobj As New UserQuestInfo

        Dim cmdobj As New cmdInfo

        cmdobj.Userid = 7017
        cmdobj.QuestID = 5

        retobj = obj.checkQuestStatus(cmdobj)


    End Sub

    'Registrera quest till användaren.
    'kolla om questen finns i userquestlistan om inte finns regga den då
    <TestMethod()> Public Sub registerQuestTEST()
        Dim obj As New QuestMainController
        Dim retobj As New UserQuestInfo

        Dim cmdobj As New cmdInfo

        cmdobj.Userid = 7017
        cmdobj.QuestID = 4

        retobj = obj.RegisterQuest(cmdobj)

    End Sub

    'Registrera quest till användaren.
    'kolla om questen finns i userquestlistan om inte finns regga den då
    <TestMethod()> Public Sub getQuestInfoTEST()
        Dim obj As New QuestMainController
        Dim retobj As New UserQuestInfo

        Dim cmdobj As New cmdInfo
        cmdobj.Userid = 7017
        cmdobj.QuestID = 6

        retobj = obj.getQuestInfo(cmdobj)

    End Sub

    ' tabort quest från användaren
    <TestMethod()> Public Sub TabortQuestTEST()
        Dim obj As New QuestMainController
        Dim retobj As New UserQuestInfo

        Dim cmdobj As New cmdInfo

        cmdobj.Userid = 7017
        cmdobj.QuestID = 1

        retobj = obj.removeQuestFromUser(cmdobj)

    End Sub

    'Användaren gör quest, om quest uppfylld check as completed, om questsvar är fel (statuscode =2) inget utförs!
    <TestMethod()> Public Sub UtforSubQuestTEST()
        Dim obj As New QuestMainController
        Dim retobj As New UserQuestInfo

        Dim cmdobj As New cmdInfo

        cmdobj.Userid = 7017
        cmdobj.QuestID = 7
        cmdobj.QTriggerID = 15
        cmdobj.uQuestID = 33
        cmdobj.Svar = "silver" '"nisse" '

        retobj = obj.CompleteSubQuest(cmdobj)

    End Sub

    'Ska subquest visas eller inte, om visas skicka med questbeskrivning. 
    ' Request: Userid, QuestID, Qtriggerid
    ' Response: uQuestID, QTriggerID, QuestID, questbeskrivning, aid, subquestsvar,
    ' DETTA är det som admin placerar på sida för att köra en quest, 
    <TestMethod()> Public Sub SubQuestVisasEllerKlarTEST()
        Dim obj As New QuestMainController
        Dim retobj As New UserQuestInfo

        Dim cmdobj As New cmdInfo
        cmdobj.Userid = 7017
        cmdobj.QuestID = 4
        cmdobj.QTriggerID = 7

        retobj = obj.getSubQuest(cmdobj)

    End Sub


End Class