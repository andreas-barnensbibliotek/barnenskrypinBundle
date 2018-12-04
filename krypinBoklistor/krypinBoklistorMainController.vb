Public Class krypinBoklistorMainController

    Private _dal As New krypinBooklistDAL

    Public Function getAllUserBooklists(userid As Integer) As krypinBookListInfo
        Dim ret As New krypinBookListInfo
        If userid > 0 Then
            ret.Booklists = addLaserjustnu(userid, getandcombineBooklistAnditem(userid))
        Else
            ret.Status = "Det saknas uppgifter"
        End If

        Return ret

    End Function

    Public Function getAllUserGroupBooklists(userid As Integer) As krypinBookListInfo
        Dim ret As New krypinBookListInfo
        If userid > 0 Then
            ret.Booklists = getandcombineGroupBooklistAnditemlist(userid)
        Else
            ret.Status = "Det saknas uppgifter"
        End If

        Return ret

    End Function

    Public Function getUserValdBooklists(userid As Integer, blid As Integer) As krypinBookListInfo
        Dim ret As New krypinBookListInfo
        If userid > 0 And blid > 0 Then
            ret.Booklists = addLaserjustnu(userid, getandcombineValdBooklistAnditem(userid, blid))

        Else
            ret.Status = "Det saknas uppgifter"
        End If
        Return ret

    End Function

    Public Function addBooklist(userid As Integer, blnamn As String) As krypinBookListInfo
        Dim ret As New krypinBookListInfo
        If userid > 0 And Not String.IsNullOrEmpty(blnamn) Then
            Dim lbobj As New krypinbooklisInfo
            lbobj.Booklistname = blnamn
            lbobj.Userid = userid
            lbobj.gruppid = 0

            ret.Booklists = addLaserjustnu(userid, getandcombineValdBooklistAnditem(userid, _dal.addNyBooklist(lbobj)))

        Else
            ret.Status = "Det saknas uppgifter"

        End If
        Return ret

    End Function

    Public Function addGroupBooklist(grpid As Integer, blnamn As String) As krypinBookListInfo
        Dim ret As New krypinBookListInfo

        If grpid > 0 And Not String.IsNullOrEmpty(blnamn) Then
            Dim lbobj As New krypinbooklisInfo
            lbobj.Booklistname = blnamn
            lbobj.gruppid = grpid
            Dim nytmpobj As New List(Of krypinbooklistItemDetailsInfo)
            Dim nytmpitm As New krypinbooklistItemDetailsInfo
            nytmpobj.Add(nytmpitm)
            lbobj.BooklistItems = nytmpobj

            ret.Booklists = getandcombineValdBooklistAnditem(grpid, _dal.addNyBooklistToGroup(lbobj))

        Else
            ret.Status = "Det saknas uppgifter"
        End If

        Return ret

    End Function

    Public Function addBookidToBooklist(blid As Integer, userid As Integer, bookid As Integer) As krypinBookListInfo
        Dim ret As New krypinBookListInfo
        If userid > 0 And blid > 0 And bookid > 0 Then
            If blid = 1000000000 Then
                If _dal.addBookItemToMyBooks(userid, bookid) Then
                    ret.Booklists = getandcombineValdBooklistAnditem(userid, blid)
                Else
                    ret.Status = "Error"
                End If
            Else
                If _dal.addBookItemToBooklist(blid, bookid) Then
                    If Not _dal.checkIfInMyBooklistItems(userid, bookid) Then
                        _dal.addBookItemToMyBooks(userid, bookid)
                    End If

                    ret.Booklists = addLaserjustnu(userid, getandcombineValdBooklistAnditem(userid, blid))
                Else
                    ret.Status = "Error"
                End If
            End If
        Else
            ret.Status = "Det saknas uppgifter"
        End If

        Return ret

    End Function

    Public Function editBooklist(blid As Integer, userid As Integer, blnamn As String) As krypinBookListInfo
        Dim ret As New krypinBookListInfo

        If Not String.IsNullOrEmpty(blnamn) And userid > 0 And blid > 0 Then

            _dal.EditBooklistname(blid, blnamn)

            ret.Booklists = addLaserjustnu(userid, getandcombineValdBooklistAnditem(userid, blid))

        Else
            ret.Status = "Det saknas uppgifter"
        End If

        Return ret
    End Function

    Public Function delBooklist(blid As Integer, userid As Integer) As krypinBookListInfo
        Dim ret As New krypinBookListInfo

        If userid > 0 And blid > 0 Then

            If _dal.DelBooklist(blid, userid) Then
                _dal.DelAllBooksFromBooklist(blid)
                ret.Status = "Boklistan borttagen"

            Else
                ret.Status = "Error"
            End If

        Else
            ret.Status = "Det saknas uppgifter"

        End If
        Return ret

    End Function

    Public Function delBookidFromBooklist(blid As Integer, bookid As Integer, userid As Integer) As krypinBookListInfo
        Dim ret As New krypinBookListInfo

        If bookid > 0 And blid > 0 Then
            If blid = 1000000000 Then
                If _dal.DelBookItemFromMyBooks(userid, bookid) Then

                    ret.Status = "Bok borttagen ur boklistan"
                Else
                    ret.Status = "Boken fanns inte i boklistan"
                End If
            Else
                If _dal.DelBookItemFromBooklist(blid, bookid) Then

                    ret.Status = "Bok borttagen ur boklistan"
                Else
                    ret.Status = "Boken fanns inte i boklistan"
                End If

            End If

        Else
            ret.Status = "Det saknas uppgifter"

        End If
        Return ret

    End Function

#Region "PRIVATA Funktioner"

    Private Function getandcombineBooklistAnditem(userid As Integer) As List(Of krypinbooklisInfo)
        Dim ret As New krypinBookListInfo

        Dim behorigattaddabookstoalllists As Boolean = False

        Dim boklistor As New List(Of krypinbooklisInfo)
        Dim groupboklistor As New List(Of krypinbooklisInfo)

        boklistor = _dal.getallBooklistFromUser(userid)

        If behorigattaddabookstoalllists Then ' lägg till böcker från alla grupper som anv är meddlem även där man inte är gruppadmin
            groupboklistor = getandcombineGroupBooklistAnditemlist(userid)
            boklistor.AddRange(groupboklistor)
        End If

        For Each itm In boklistor
            If itm.BlID = 1000000000 Then
                itm.BooklistItems = _dal.getMyBooklistItems(userid)
            Else
                itm.BooklistItems = _dal.getBooklistItems(itm.BlID)
            End If

        Next
        ret.Booklists = boklistor

        Return boklistor

    End Function

    Private Function getandcombineGroupBooklistAnditemlist(userid As Integer) As List(Of krypinbooklisInfo)

        Dim boklistor As New List(Of krypinbooklisInfo)

        boklistor = _dal.getallGroupBooklistFromUser(userid)

        For Each itm In boklistor
            If itm.BlID = 1000000000 Then
                itm.BooklistItems = _dal.getMyBooklistItems(userid)
            Else
                itm.BooklistItems = _dal.getBooklistItems(itm.BlID)
            End If

        Next

        Return boklistor

    End Function

    Private Function getandcombineValdBooklistAnditem(userid As Integer, blid As Integer) As List(Of krypinbooklisInfo)

        Dim boklistor As New List(Of krypinbooklisInfo)
        If blid = 1000000000 Then
            boklistor = combineMybooklist(userid)

        Else
            boklistor = combineBooklists(userid, blid)

        End If

        Return boklistor

    End Function

    Private Function combineBooklists(ByVal userid As Integer, ByVal blid As Integer) As List(Of krypinbooklisInfo)
        Dim boklistor As List(Of krypinbooklisInfo)
        boklistor = _dal.getValdBooklistFromUser(blid, userid)

        For Each itm In boklistor
            itm.BooklistItems = _dal.getBooklistItems(itm.BlID)
        Next

        Return boklistor
    End Function

    Private Function combineMybooklist(ByRef userid As Integer) As List(Of krypinbooklisInfo)
        Dim mybooks As New List(Of krypinbooklisInfo)
        Dim mybookslist As New krypinbooklisInfo
        mybookslist.BlID = 1000000000
        mybookslist.Booklistname = "Mina Böcker"
        mybookslist.Userid = userid
        mybooks.Add(mybookslist)


        For Each itm In mybooks
            itm.BooklistItems = _dal.getMyBooklistItems(itm.Userid)
        Next

        Return mybooks
    End Function

#End Region
    Private Function addLaserjustnu(userid As Integer, boklistan As List(Of krypinbooklisInfo)) As List(Of krypinbooklisInfo)
        Dim valdjustnubookid = _dal.getlaserjustnuSetting(userid)

        If valdjustnubookid > 0 Then
            For Each item In boklistan
                For Each x In item.BooklistItems
                    If valdjustnubookid = x.Bookid Then
                        x.Lasernu = True
                        Exit For
                    End If
                Next
            Next
        End If

        Return boklistan

    End Function
End Class
