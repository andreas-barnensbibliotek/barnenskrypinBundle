Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports KrypinBokmarkelser
<TestClass()> Public Class KrypinBokmarkelserMainControllerTEST
    'Användning
    ' setuseraward används för att ge användaren poäng och bibblomoney om användaren får ett bokmärke. värden userid och bokmarkelse id
    'som visar vilket märke som skall tilldelas.
    <TestMethod()> Public Sub TestMethod1()
        Dim testobj As New KrypinBokmarkelserMainController

        Dim ret As bokmarkelserReturnInfo = testobj.setuseraward(7017, 1)

        Dim visa As bokmarkelserReturnInfo = ret


    End Sub

    <TestMethod()> Public Sub TestMethod2()
        Dim testobj As New KrypinBokmarkelserMainController

        Dim ret As bokmarkelserReturnInfo = testobj.getUserbokmarkelser(7017)

        Dim visa As bokmarkelserReturnInfo = ret


    End Sub

End Class