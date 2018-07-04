Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BibbloMoney
<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub addevent()
        Dim retobj As Boolean = False

        Dim obj As New bibbloMoneyMainController

        obj.bibblomoneyEarnEvent(1, 7017)


    End Sub

End Class