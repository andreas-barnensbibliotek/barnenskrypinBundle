Public Class krypinbooklistcontroller

    Private _dal As New krypinBooklistDAL

    Public Function getAllUserBooklists(userid As Integer) As String

        If userid > 0 Then
            Return _jsonhandler.createFraganJsonp(getandcombineBooklistAnditem(userid))

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

    Public Function getAllUserGroupBooklists(userid As Integer) As String

        If userid > 0 Then
            Return _jsonhandler.createFraganJsonp(getandcombineGroupBooklistAnditemlist(userid))

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

    Public Function getUserValdBooklists(userid As Integer, blid As Integer) As String

        If userid > 0 And blid > 0 Then
            Return _jsonhandler.createFraganJsonp(getandcombineValdBooklistAnditem(userid, blid))

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

    Public Function addBooklist(userid As Integer, blnamn As String) As String

        If userid > 0 And Not String.IsNullOrEmpty(blnamn) Then
            Dim lbobj As New krypinbooklisInfo
            lbobj.Booklistname = blnamn
            lbobj.Userid = userid
            lbobj.gruppid = 0

            Return _jsonhandler.createFraganJsonp(getandcombineValdBooklistAnditem(userid, _dal.addNyBooklist(lbobj)))

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

    Public Function addGroupBooklist(grpid As Integer, blnamn As String) As String

        If grpid > 0 And Not String.IsNullOrEmpty(blnamn) Then
            Dim lbobj As New krypinbooklisInfo
            lbobj.Booklistname = blnamn
            lbobj.gruppid = grpid
            Dim nytmpobj As New List(Of krypinbooklistItemDetailsInfo)
            Dim nytmpitm As New krypinbooklistItemDetailsInfo
            nytmpobj.Add(nytmpitm)
            lbobj.BooklistItems = nytmpobj

            Return _jsonhandler.createFraganJsonp(getandcombineValdBooklistAnditem(grpid, _dal.addNyBooklistToGroup(lbobj)))

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

    Public Function addBookidToBooklist(blid As Integer, userid As Integer, bookid As Integer) As String

        If userid > 0 And blid > 0 And bookid > 0 Then
            If blid = 1000000000 Then
                If _dal.addBookItemToMyBooks(userid, bookid) Then
                    Return _jsonhandler.createFraganJsonp(getandcombineValdBooklistAnditem(userid, blid))
                Else
                    Return _jsonhandler.createEmptyFraganJson("Error")
                End If
            Else
                If _dal.addBookItemToBooklist(blid, bookid) Then
                    If Not _dal.checkIfInMyBooklistItems(userid, bookid) Then
                        _dal.addBookItemToMyBooks(userid, bookid)
                    End If

                    Return _jsonhandler.createFraganJsonp(getandcombineValdBooklistAnditem(userid, blid))
                Else
                    Return _jsonhandler.createEmptyFraganJson("Error")
                End If

            End If

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

    Public Function editBooklist(blid As Integer, userid As Integer, blnamn As String) As String

        If Not String.IsNullOrEmpty(blnamn) And userid > 0 And blid > 0 Then

            _dal.EditBooklistname(blid, blnamn)

            Return _jsonhandler.createFraganJsonp(getandcombineValdBooklistAnditem(userid, blid))

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

    Public Function delBooklist(blid As Integer, userid As Integer) As String

        If userid > 0 And blid > 0 Then

            If _dal.DelBooklist(blid, userid) Then
                _dal.DelAllBooksFromBooklist(blid)
                Return _jsonhandler.createEmptyFraganJson("Boklistan borttagen")

            Else
                Return _jsonhandler.createEmptyFraganJson("Error")
            End If

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

    Public Function delBookidFromBooklist(blid As Integer, bookid As Integer, userid As Integer) As String

        If bookid > 0 And blid > 0 Then
            If blid = 1000000000 Then
                If _dal.DelBookItemFromMyBooks(userid, bookid) Then

                    Return _jsonhandler.createEmptyFraganJson("Bok borttagen ur boklistan")
                Else
                    Return _jsonhandler.createEmptyFraganJson("Boken fanns inte i boklistan")
                End If
            Else
                If _dal.DelBookItemFromBooklist(blid, bookid) Then

                    Return _jsonhandler.createEmptyFraganJson("Bok borttagen ur boklistan")
                Else
                    Return _jsonhandler.createEmptyFraganJson("Boken fanns inte i boklistan")
                End If

            End If

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

    Private Function getandcombineBooklistAnditem(userid As Integer) As List(Of krypinbooklisInfo)

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

#Region "Krypin Group handlers"
    Public Function getAllUserBooklistsFromGroup(groupid As Integer) As String

        If groupid > 0 Then
            Return _jsonhandler.createFraganJsonp(getandcombineBooklistAnditemFromGroup(groupid))

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

    Public Function getGroupValdBooklists(groupid As Integer, blid As Integer) As String

        If groupid > 0 And blid > 0 Then
            Return _jsonhandler.createFraganJsonp(combineBooklistsFromGroup(groupid, blid))

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

    Private Function getandcombineBooklistAnditemFromGroup(groupid As Integer) As List(Of krypinbooklisInfo)

        Dim boklistor As New List(Of krypinbooklisInfo)

        boklistor = _dal.getallBooklistFromGroup(groupid)

        For Each itm In boklistor
            itm.BooklistItems = _dal.getBooklistItems(itm.BlID)

        Next

        Return boklistor

    End Function

    Private Function getandcombineBooklistAnditemFromUsersGrouplist(userid As Integer) As List(Of krypinbooklisInfo)

        Dim boklistor As New List(Of krypinbooklisInfo)

        boklistor = _dal.getallGroupBooklistFromUser(userid)

        For Each itm In boklistor
            itm.BooklistItems = _dal.getBooklistItems(itm.BlID)

        Next

        Return boklistor

    End Function

    Private Function combineBooklistsFromGroup(ByVal groupid As Integer, ByVal blid As Integer) As List(Of krypinbooklisInfo)
        Dim boklistor As List(Of krypinbooklisInfo)
        boklistor = _dal.getValdBooklistFromGroup(blid, groupid)

        For Each itm In boklistor
            itm.BooklistItems = _dal.getBooklistItems(itm.BlID)
        Next
        Return boklistor
    End Function

    Public Function addBooklistToGroup(groupid As Integer, blnamn As String) As String

        If groupid > 0 And Not String.IsNullOrEmpty(blnamn) Then
            Dim lbobj As New krypinbooklisInfo
            lbobj.Booklistname = blnamn
            lbobj.gruppid = groupid
            lbobj.Userid = 0

            Return _jsonhandler.createFraganJsonp(combineBooklistsFromGroup(groupid, _dal.addNyBooklistToGroup(lbobj)))

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

    Public Function editBooklistToGroup(blid As Integer, goupid As Integer, blnamn As String) As String

        If Not String.IsNullOrEmpty(blnamn) And goupid > 0 And blid > 0 Then

            _dal.EditBooklistname(blid, blnamn)

            Return _jsonhandler.createFraganJsonp(combineBooklistsFromGroup(goupid, blid))

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

    Public Function delBooklistGroup(blid As Integer, groupid As Integer) As String

        If groupid > 0 And blid > 0 Then

            If _dal.DelBooklistFromGroup(blid, groupid) Then
                _dal.DelAllBooksFromBooklist(blid)
                Return _jsonhandler.createEmptyFraganJson("Boklistan borttagen")

            Else
                Return _jsonhandler.createEmptyFraganJson("Error")
            End If

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

    Public Function delBookidFromBooklistGroup(blid As Integer, bookid As Integer) As String

        If bookid > 0 And blid > 0 Then
            If _dal.DelBookItemFromBooklist(blid, bookid) Then

                Return _jsonhandler.createEmptyFraganJson("Bok borttagen ur boklistan")
            Else
                Return _jsonhandler.createEmptyFraganJson("Boken fanns inte i boklistan")
            End If

        Else
            Return _jsonhandler.createEmptyFraganJson("Det saknas uppgifter")

        End If

    End Function

#End Region
End Class
