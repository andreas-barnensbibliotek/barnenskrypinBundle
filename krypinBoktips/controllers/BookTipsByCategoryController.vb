Public Class BookTipsByCategoryController

    Private _dalObj As New boktipsCategoryDAL
    Private _combiner As New boktipsImgSrcCombiner

    Public Function boktipsCategoryByName(CatName As String) As List(Of boktipsInfo)

        Dim combined As New List(Of boktipsInfo)

        If Not String.IsNullOrEmpty(CatName) Then

            Dim tmplist As List(Of boktipsInfo) = _dalObj.boktipsCategoryName(CatName)
            combined = _combiner.BoktipsImgSrcCombiner(tmplist)

        End If

        Return combined

    End Function


    Public Function boktipsCategoryByID(catId As Integer) As List(Of boktipsInfo)

        Dim combined As New List(Of boktipsInfo)

        If catId > 0 Then

            Dim tmplist As List(Of boktipsInfo) = _dalObj.boktipsCategoryID(catId)
            combined = _combiner.BoktipsImgSrcCombiner(tmplist)

        End If

        Return combined

    End Function


    Public Function boktipsCategoryByRandomInID(catId As Integer, antal As Integer) As List(Of boktipsInfo)

        Dim combined As New List(Of boktipsInfo)

        If catId > 0 Then

            Dim tmplist As List(Of boktipsInfo) = _dalObj.boktipsCategoryID(catId)
            combined = _combiner.BoktipsImgSrcCombiner(tmplist)

            Dim rnd As New RandomBoktips

            Return rnd.getRandomBoktips(antal, combined)

        Else

            Return combined

        End If

    End Function



End Class

