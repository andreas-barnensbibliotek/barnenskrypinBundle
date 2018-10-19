Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports barnenskrypinCreateKrypinLibrary
<TestClass()> Public Class CreateKrypinMainControllerTEST
    Private _obj As New CreateKrypinMainController
    Private _userid As Integer = 9713
    <TestMethod()> Public Sub chkktypinexistTEST()

        Dim retobj As Boolean = False
        retobj = _obj.chkifkrypinExists(_userid)

        Dim retobjTEST As Boolean = retobj

    End Sub
    <TestMethod()> Public Sub CreateNyttKrypinTEST()
        Dim retobj As Boolean = False
        retobj = _obj.CreateNewkrypin(_userid)

        Dim retobjTEST As Boolean = retobj

    End Sub

End Class