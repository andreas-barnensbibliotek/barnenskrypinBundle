Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports barnenskrypinIMGHandler

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()

        Dim obj As New checkImgExist
        Dim url As String = obj.getimgurlbyIsbn("91-2966-2885")

        Dim retr As String = url


    End Sub

End Class