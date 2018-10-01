Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports krypinSkrivboken

<TestClass()> Public Class krypinSkrivbokenMainControllerTest


    <TestMethod()> Public Sub TESTgetbyuserid()
        ' cmdtyp.getpublishTyp 1 = hämtar användarens data (userid requred) som är antingen 
        '               Approved:
        '                   1 Ja(default) el 
        '                   0 Nej
        '               Publish:
        '                   1 publicerad,
        '                   2 privat,
        '                   3 publik(default) 
        ' cmdtyp.getpublishTyp 2 = hämtar användarens data (userid requred) oavsett om den är approved eller ej eller vilken publish den är


        Dim searchobj As New commandTypeInfo
        searchobj.Userid = 105
        searchobj.GetPublishTyp = 1
        'searchobj.Approved = 1
        'searchobj.Publish = 1

        Dim testar As New krypinSkrivbokenMainController
        Dim retobj As New skrivbokenJsonContainerInfo
        retobj = testar.getSkrivbokByUserid(searchobj)
        Dim texten As String = retobj.SkrivbokenList(0).Title

    End Sub
    <TestMethod()> Public Sub TESTgetbyCategory()
        ' cmdtyp.category hämtar vald kategori som är antingen
        '               Approved:
        '                   1 Ja(default) el 
        '                   0 Nej
        '               Publish:
        '                   1 publicerad,
        '                   2 privat,
        '                   3 publik(default) 

        Dim searchobj As New commandTypeInfo
        searchobj.Category = 10
        searchobj.GetPublishTyp = 2
        searchobj.Approved = 0

        searchobj.Userid = 105
        Dim testar As New krypinSkrivbokenMainController

        Dim retobj As New skrivbokenJsonContainerInfo
        retobj = testar.getSkrivbokByCategory(searchobj)
        Dim texten As String = retobj.SkrivbokenList(0).Title


    End Sub

    <TestMethod()> Public Sub TESTgetbySkrivid()
        Dim searchobj As New commandTypeInfo
        searchobj.Skrivid = 36
        searchobj.Userid = 14335


        Dim testar As New krypinSkrivbokenMainController

        Dim retobj As New skrivbokenJsonContainerInfo
        retobj = testar.getSkrivbokBySkrivid(searchobj)
        Dim texten As String = retobj.SkrivbokenList(0).Title

    End Sub

    <TestMethod()> Public Sub TEST_ADDSkrivbokentext()
        Dim crudcmdobj As New commandTypeInfo
        crudcmdobj.Crudtyp = "add"

        Dim cruddata As New skrivItemInfo
        With cruddata
            .Approved = 0
            .Category = 1
            .Gillar = 0
            .Publish = 1
            .Story = "Här kommer den långa texten: Ny"
            .UserID = 7017
        End With

        Dim testar As New krypinSkrivbokenMainController
        Dim infotext As String = testar.CrudADDskrivboken(cruddata)

        Dim texten As String = infotext

    End Sub

    <TestMethod()> Public Sub TEST_EDITSkrivbokentext()
        Dim crudcmdobj As New commandTypeInfo
        crudcmdobj.Crudtyp = "updateAll"

        Dim cruddata As New skrivItemInfo
        With cruddata
            .Approved = 1
            .Category = 1
            .Gillar = 0
            .Publish = 0
            .Story = "Här kommer den långa texten: updaterad"
            .SkrivID = 1777
            .UserID = 105
        End With

        Dim testar As New krypinSkrivbokenMainController
        Dim infotext As String = testar.CrudUpdateAllskrivboken(cruddata)

        Dim texten As String = infotext

    End Sub

    <TestMethod()> Public Sub TEST_EDITApprovedSkrivbokentext()
        Dim cruddata As New skrivItemInfo
        With cruddata
            .SkrivID = 1777
            .Approved = 1
        End With

        Dim testar As New krypinSkrivbokenMainController
        Dim infotext As String = testar.CrudUpdateApproveskrivboken(cruddata)

        Dim texten As String = infotext

    End Sub

    <TestMethod()> Public Sub TEST_EDITpublishedSkrivbokentext()
        Dim crudcmdobj As New commandTypeInfo
        crudcmdobj.Crudtyp = "updatePublish"

        Dim cruddata As New skrivItemInfo
        With cruddata
            .SkrivID = 1777
            .Publish = 4
        End With

        Dim testar As New krypinSkrivbokenMainController
        Dim infotext As String = testar.CrudUpdatePublishskrivboken(cruddata)

        Dim texten As String = infotext

    End Sub

    <TestMethod()> Public Sub TEST_DELETESkrivbokentext()

        Dim cruddata As New skrivItemInfo
        cruddata.SkrivID = 1777

        Dim testar As New krypinSkrivbokenMainController
        Dim infotext As String = testar.CrudDeleteskrivboken(cruddata)

        Dim texten As String = infotext

    End Sub
End Class