Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports krypinBoklistor

<TestClass()> Public Class krypinBoklistorMainControllerTEST

    <TestMethod()> Public Sub getAllUserBooklistsTEST()

        Dim obj As New krypinBoklistorMainController
        Dim test As krypinBookListInfo = obj.getAllUserBooklists(7017)

        Dim antal As Integer = test.Booklists.Count

    End Sub

End Class