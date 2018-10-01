Public Class krypinBoktipsMainController

    Public Function BookTipsByAuthor(author As String) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo
        Dim authorObj As New BookTipsByAuthorController

        Try
            retobj.Boktips = authorObj.boktipsAuthorsByName(author)
            retobj.Status = "Boktips by authorname completed"
        Catch ex As Exception
            retobj.Status = "ERROR boktipsAuthorsByName"


        End Try
        Return retobj
    End Function


    Public Function BookTipsByCategory(catid As Integer) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo
        Dim catObj As New BookTipsByCategoryController

        Try
            retobj.Boktips = catObj.boktipsCategoryByID(catid)
            retobj.Status = "Boktips by category completed"
        Catch ex As Exception
            retobj.Status = "ERROR boktipsCategoryByID"


        End Try
        Return retobj
    End Function


    Public Function BookTipsByRandomInCategory(catid As Integer, Optional antal As Integer = 1) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo
        Dim catRndObj As New BookTipsByCategoryController

        Try
            retobj.Boktips = catRndObj.boktipsCategoryByRandomInID(catid, antal)
            retobj.Status = "Boktips by category random completed"

        Catch ex As Exception
            retobj.Status = "ERROR boktipsCategoryByRandomInID"

        End Try
        Return retobj
    End Function


    Public Function BooktTipsByAgeInterval(age As Integer) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo
        Dim ageValObj As New BookTipsByAgeIntervallController

        Try
            retobj.Boktips = ageValObj.boktipsAgeInterval(age)
            retobj.Status = "Boktips by Age interval completed"
        Catch ex As Exception
            retobj.Status = "ERROR boktipsAgeInterval"

        End Try

        Return retobj
    End Function


    Public Function BookTipsLatest(Optional antal As Integer = 5) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo
        Dim ageValObj As New BooktipsByDateController

        Try
            retobj.Boktips = ageValObj.boktipsByDateLatest(antal)
            retobj.Status = "Boktips by latest completed"
        Catch ex As Exception
            retobj.Status = "ERROR boktipsByDateLatest"

        End Try

        Return retobj

    End Function

    Public Function BookTipsBySearch(Search As String) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo
        Dim bookTipSearchObj As New BookTipsBySearchController

        Try
            retobj.Boktips = bookTipSearchObj.boktipsBySearch(Search)
            retobj.Status = "Boktips by textsearch completed"
        Catch ex As Exception
            retobj.Status = "ERROR boktipsBySearch"

        End Try

        Return retobj

    End Function

    Public Function BookTipsByTitle(title As String) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo
        Dim bookTitleObj As New BookTipsByTitleController

        Try
            retobj.Boktips = bookTitleObj.boktipsByTitle(title)
            retobj.Status = "Boktips by title completed"
        Catch ex As Exception
            retobj.Status = "ERROR boktipsByTitle"

        End Try

        Return retobj

    End Function

    Public Function BookTipsByRating(antal As Integer) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo
        Dim bookRatingObj As New BookTipsByRatingController

        Try
            retobj.Boktips = bookRatingObj.boktipsByRating(antal)
            retobj.Status = "Boktips by rating completed"
        Catch ex As Exception
            retobj.Status = "ERROR boktipsByRating"

        End Try

        Return retobj

    End Function

    Public Function boktipsTitellist() As String
        Dim obj As New BookTipsByTitleController

        Try
            Return obj.basicTitleList

        Catch ex As Exception

            Return ""

        End Try

    End Function
    Public Function booktipByTipId(tipid As Integer) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo
        Dim booktiplist As New List(Of boktipsInfo)
        Dim obj As New BookTipsByTipIdController

        Try
            booktiplist.Add(obj.getbooktipByTipid(tipid))
            retobj.Boktips = booktiplist
            retobj.Status = "Boktips by boktips id completed"
        Catch ex As Exception
            retobj.Status = "ERROR booktipByTipId"

        End Try

        Return retobj

    End Function

    Public Function booktipByUserId(userid As Integer) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo
        Dim booktiplist As New List(Of boktipsInfo)
        Dim obj As New BookTipsByUserIdController

        Try
            booktiplist = obj.getbooktipByUserid(userid)
            retobj.Boktips = booktiplist
            retobj.Status = "Boktips by userid completed"
        Catch ex As Exception
            retobj.Status = "ERROR booktipByTipId"

        End Try

        Return retobj

    End Function

    Public Function boktipsGetBookContextByBookID(bookid As Integer) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo
        Dim bookcontextObj As New BookTipsBookContextByBookIDController

        Try
            retobj.Boktips = bookcontextObj.bookContextByBookid(bookid)
            retobj.Status = "Boktips book context collected"

        Catch ex As Exception
            retobj.Status = "ERROR bookContextByBookid"

        End Try
        Return retobj
    End Function
#Region "Externa Resurser"
    Public Function BookTipsByRandom(Optional antal As Integer = 1) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo
        Dim obj As New BooktTipsByRandomController

        Try
            retobj.Boktips = obj.getRandomBoktips(antal)
            retobj.Status = "Boktips by Random completed"
        Catch ex As Exception
            retobj.Status = "ERROR getRandomBoktips"

        End Try

        Return retobj
    End Function


#End Region


End Class
