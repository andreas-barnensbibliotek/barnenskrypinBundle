Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BibbloMoney
<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub addeventTEST()
        Dim retobj As Boolean = False
        Dim obj As New bibbloMoneyMainController

        obj.bibblomoneyEarnEvent(1, 7017)

    End Sub

#Region "bokmärkelser"
    <TestMethod()> Public Sub getBokmarkelseEventTEST()
        Dim retobj As New bokmarkelserReturnInfo
        Dim obj As New bibbloMoneyMainController

        retobj = obj.getUserbokmarkelser(7017)

    End Sub
    <TestMethod()> Public Sub getUserAwardgroupbokmarkelserTEST()
        Dim retobj As New bokmarkelserReturnInfo
        Dim obj As New bibbloMoneyMainController

        retobj = obj.getUserAwardgroupbokmarkelser(7017, 1)

    End Sub
    <TestMethod()> Public Sub setuserawardbyAwardGroupIDTEST()
        Dim retobj As New bokmarkelserReturnInfo
        Dim obj As New bibbloMoneyMainController

        retobj = obj.setuserawardbyAwardGroupID(7017, 2)  'boktips =2

    End Sub
    <TestMethod()> Public Sub setuserawardbyAwardgroupNameTEST()
        Dim retobj As New bokmarkelserReturnInfo
        Dim obj As New bibbloMoneyMainController

        retobj = obj.setuserawardbyAwardgroupName(7017, "boktips")

    End Sub

    <TestMethod()> Public Sub addnewAwardGroupTEST()

        Dim retobj As New bokmarkelserReturnInfo
        Dim obj As New bibbloMoneyMainController

        retobj = obj.addnewAwardGroup("nyreward", "ny rewardlevel", "ny beskrivning", "bildsrc", 1)

    End Sub

    <TestMethod()> Public Sub delAwardGroupbyAwardGroupNameTEST()

        Dim retobj As New bokmarkelserReturnInfo
        Dim obj As New bibbloMoneyMainController

        retobj = obj.delAwardGroupbyAwardGroupName("nyreward")

    End Sub

    <TestMethod()> Public Sub delAwardGroupbyAwardGroupIDTEST()

        Dim retobj As New bokmarkelserReturnInfo
        Dim obj As New bibbloMoneyMainController

        retobj = obj.delAwardGroupbyAwardGroupID(47)

    End Sub

#End Region
End Class