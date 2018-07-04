Imports System.Text
Public Class BookTipsByTitleController

    Private _dalObj As New boktipsTitleDAL
    Private _combiner As New boktipsImgSrcCombiner


    Public Function boktipsByTitle(title As String) As List(Of boktipsInfo)

        Dim combined As New List(Of boktipsInfo)

        If Not String.IsNullOrEmpty(title) Then
            title &= "%"
            Dim tmplist As List(Of boktipsInfo) = _dalObj.boktipsBookTitleInfo(title)
            combined = _combiner.BoktipsImgSrcCombiner(tmplist)

        End If

        Return combined

    End Function

    Public Function basicTitleList() As String
        Dim sb As New stringBuilder
        Dim dallist As List(Of boktipsInfo) = _dalObj.boktipsTitelList()

        For Each itm In dallist

            sb.Append(itm.Title & ",")

        Next

        Return sb.ToString

    End Function

End Class
