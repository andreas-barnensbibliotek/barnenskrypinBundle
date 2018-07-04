
Public Class BookTipsByAuthorController

    Private _dalObj As New boktipsAuthorDAL
    Private _combiner As New boktipsImgSrcCombiner

    Public Function boktipsAuthorsByName(namn As String) As List(Of boktipsInfo)

        Dim sfix As New searchfixer
        Dim combined As New List(Of boktipsInfo)

        If Not String.IsNullOrEmpty(namn) Then

            Dim tmplist As List(Of boktipsInfo) = _dalObj.boktipsAuthorNameBaseInfo(sfix.searchStringFixer(namn))
            combined = _combiner.BoktipsImgSrcCombiner(tmplist)

        End If

        Return combined

    End Function


    Public Function boktipsAuthorsByID(ID As Integer) As List(Of boktipsInfo)

        Dim combined As New List(Of boktipsInfo)

        If Not ID <= 0 Then

            Dim tmplist As List(Of boktipsInfo) = _dalObj.boktipsAuthorIDBaseInfo(ID)
            combined = _combiner.BoktipsImgSrcCombiner(tmplist)

        End If

        Return combined

    End Function


End Class


