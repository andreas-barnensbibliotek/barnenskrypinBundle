Imports System.Text
Public Class BookTipsBySearchController

    Private _combiner As New boktipsImgSrcCombiner

    Public Function boktipsBySearch(searchstring As String) As List(Of boktipsInfo)

        Dim sfix As New searchfixer
        Dim combined As New List(Of boktipsInfo)

        If Not String.IsNullOrEmpty(searchstring) Then

            Dim tmplist As List(Of boktipsInfo) = doSearchBoktips(sfix.searchStringFixer(searchstring))

            combined = _combiner.BoktipsImgSrcCombiner(tmplist)

        End If

        Return combined

    End Function


    Private Function doSearchBoktips(searchstring As String) As List(Of boktipsInfo)

        Dim _dalObj As New boktipsTitleDAL

        Dim tmplist As List(Of boktipsInfo) = _dalObj.boktipsBookTitleInfo(searchstring)

        If tmplist.Count <= 0 Then

            Dim AuthorDalObj As New boktipsAuthorDAL
            tmplist = AuthorDalObj.boktipsAuthorNameBaseInfo(searchstring)

        End If

        Return tmplist

    End Function

  

End Class
