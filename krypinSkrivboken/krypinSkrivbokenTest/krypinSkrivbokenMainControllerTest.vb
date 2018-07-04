Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports krypinSkrivboken

<TestClass()> Public Class krypinSkrivbokenMainControllerTest

    <TestMethod()> Public Sub TESTgetbyuserid()
        Dim searchobj As New commandTypeInfo
        searchobj.Userid = 14286
        searchobj.GetPublishTyp = 1

        Dim testar As New krypinSkrivbokenMainController
        Dim listan As List(Of skrivItemInfo) = testar.getSkrivbokByUserid(searchobj)

        Dim texten As String = listan(0).Title

    End Sub
    <TestMethod()> Public Sub TESTgetbyCategory()
        Dim searchobj As New commandTypeInfo
        searchobj.Category = 12
        searchobj.GetPublishTyp = 1

        Dim testar As New krypinSkrivbokenMainController
        Dim listan As List(Of skrivItemInfo) = testar.getSkrivbokByCategory(searchobj)

        Dim texten As String = listan(0).Title

    End Sub

    <TestMethod()> Public Sub TESTgetbySkrivid()
        Dim searchobj As New commandTypeInfo
        searchobj.Skrivid = 198

        Dim testar As New krypinSkrivbokenMainController
        Dim listan As List(Of skrivItemInfo) = testar.getSkrivbokBySkrivid(searchobj)

        Dim texten As String = listan(0).Title

    End Sub

    <TestMethod()> Public Sub TEST_ADDSkrivbokentext()
        Dim crudcmdobj As New commandTypeInfo
        crudcmdobj.Crudtyp = "add"

        Dim cruddata As New skrivItemInfo
        With cruddata
            .Approved = 1
            .Category = 1
            .Gillar = 0
            .Publish = 0
            .Story = "Här kommer den långa texten: Ny"
            .UserID = 105
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