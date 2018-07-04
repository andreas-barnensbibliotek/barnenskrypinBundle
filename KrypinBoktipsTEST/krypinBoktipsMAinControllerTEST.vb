Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports krypinBoktips

<TestClass()> Public Class krypinBoktipsMAinControllerTEST

    <TestMethod()> Public Sub BookTipsByCategoryTEST()
        Dim boktipslista As New krypinBoktipsInfo

        Dim obj As New krypinBoktipsMainController

        boktipslista = obj.BookTipsLatest(1)

        Dim ret As String = boktipslista.Boktips(0).Title

    End Sub
    <TestMethod()> Public Sub BookTipsByRandomTEST()
        Dim boktipslista As New krypinBoktipsInfo
        Dim obj As New krypinBoktipsMainController

        boktipslista = obj.BookTipsByRandom(5)

        Dim ret As String = boktipslista.Boktips(0).Title

    End Sub

    <TestMethod()> Public Sub getBookTipsTEST()
        Dim status As New krypinBoktipsInfo

        Dim obj As New krypinBoktipsMainController

        status = obj.booktipByTipId(1463)


        Dim ret As krypinBoktipsInfo = status

    End Sub
    <TestMethod()> Public Sub addBookTipsTEST()
        Dim status As New krypinBoktipsInfo
        Dim obj As New krypinBoktipsMainCRUDController

        status = obj.addbooktip(boktipsTESTData)

        Dim ret As String = status.Status

    End Sub
    <TestMethod()> Public Sub EditBookTipsTEST()
        Dim status As New krypinBoktipsInfo
        Dim obj As New krypinBoktipsMainCRUDController

        status = obj.editbooktip(boktipsTESTData)


        Dim ret As String = status.Status

    End Sub
    <TestMethod()> Public Sub delBookTipsTEST()
        Dim status As New krypinBoktipsInfo
        Dim obj As New krypinBoktipsMainCRUDController

        status = obj.deletebooktip(boktipsTESTData)


        Dim ret As String = status.Status

    End Sub
    Private Function boktipsTESTData() As boktipsInfo
        Dim obj As New boktipsInfo
        obj.Approved = 1
        obj.Author = "Johanna Thydell"
        obj.Bookid = 11463
        obj.Title = "Ursäkta att man vill bli lite älskad"
        obj.Userage = 12
        obj.HighAge = 14
        obj.LowAge = 3
        obj.Review = "Detta är ett ÄNDRAT test boktips nr5"
        obj.Tiptype = 2
        obj.Userid = 7017
        obj.UserName = "Testlisa"
        obj.Category = 2
        obj.TipID = 1462

        Return obj


    End Function

End Class