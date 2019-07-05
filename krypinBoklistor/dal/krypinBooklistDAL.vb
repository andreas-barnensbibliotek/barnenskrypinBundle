Imports System.Net
Imports barnenskrypinIMGHandler
Public Class krypinBooklistDAL

    Private connectionObj As New connectionstringHandler
    Private _linqobj As New krypinBooklistLinqDataContext(connectionObj.CurrentConnectionString)
    Private _imghandler As New checkImgExist

    Private Enum gettyp
        getAllUserBooklistsAndBookitems = 1
        getValdBooklistAndBookItemsViaListID = 2
        getValdBooklistAndBookItemsViaListNamn = 3
        getAllUserBooklists = 4 '1
        getAllBookItemsFromValdUserBooklist = 5
    End Enum


    Public Function getallBooklistFromUser(usrid As Integer) As List(Of krypinbooklisInfo)

        Dim tmpbooklistor As New List(Of krypinbooklisInfo)

        Dim bl = From t In _linqobj.AjBooklist(1, usrid, 0, "")

        For Each t In bl
            Dim tmpbl As New krypinbooklisInfo
            tmpbl.BlID = t.id
            tmpbl.Booklistname = WebUtility.HtmlDecode(t.boklistnamn)
            tmpbl.Userid = t.Userid


            tmpbooklistor.Add(tmpbl)
        Next

        Dim mybookslist As New krypinbooklisInfo
        mybookslist.BlID = 1000000000
        mybookslist.Booklistname = "Mina Böcker"
        mybookslist.Userid = usrid
        tmpbooklistor.Add(mybookslist)

        '    Dim tmpGruppbooklistor As New List(Of krypinbooklisInfo)
        ' Dim Grupp_linqobj As New krypinBooklistLinqDataContext
        Dim Gruppbl = From t In _linqobj.AjBooklist(3, usrid, 0, "")

        For Each t In Gruppbl
            Dim tmpbl As New krypinbooklisInfo
            tmpbl.BlID = t.id
            tmpbl.Booklistname = WebUtility.HtmlDecode(t.boklistnamn)
            tmpbl.Userid = t.Userid
            If Not String.IsNullOrEmpty(t.gruppid.ToString) Then
                tmpbl.gruppid = t.gruppid
            End If
            tmpbooklistor.Add(tmpbl)
        Next

        Return tmpbooklistor

    End Function

    Public Function getValdBooklistFromUser(blid As Integer, usrid As Integer) As List(Of krypinbooklisInfo)

        Dim tmpbooklistor As New List(Of krypinbooklisInfo)

        Dim bl = From c In _linqobj.tblAJBookLists
                 Where c.id = blid And c.Userid = usrid
                 Select c


        For Each t In bl
            Dim tmpbl As New krypinbooklisInfo
            tmpbl.BlID = t.id
            tmpbl.Booklistname = WebUtility.UrlDecode(t.boklistnamn)
            tmpbl.Userid = t.Userid
            tmpbooklistor.Add(tmpbl)

        Next

        Return tmpbooklistor

    End Function


    Public Function getBooklistItems(booklistID As Integer) As List(Of krypinbooklistItemDetailsInfo)

        Dim tmpbookitemlistor As New List(Of krypinbooklistItemDetailsInfo)

        Dim bl = From t In _linqobj.AjBooklistExtended(1, booklistID)

        For Each t In bl
            Dim tmpbl As New krypinbooklistItemDetailsInfo
            tmpbl.Bookid = t.bookid
            tmpbl.Forfattare = t.namn
            tmpbl.title = t.Title
            tmpbl.isbn = t.isbn
            tmpbl.imageurl = _imghandler.getimgurlbyIsbn(t.isbn)

            tmpbookitemlistor.Add(tmpbl)
        Next

        Return tmpbookitemlistor

    End Function

    Public Function getMyBooklistItems(userID As Integer) As List(Of krypinbooklistItemDetailsInfo)

        Dim tmpbookitemlistor As New List(Of krypinbooklistItemDetailsInfo)

        Dim bl = From t In _linqobj.AjBooklistExtended(2, userID)

        For Each t In bl
            Dim tmpbl As New krypinbooklistItemDetailsInfo
            tmpbl.Bookid = t.bookid
            tmpbl.Forfattare = t.namn
            tmpbl.title = t.Title
            tmpbl.isbn = t.isbn
            tmpbl.imageurl = _imghandler.getimgurlbyIsbn(t.isbn)
            tmpbookitemlistor.Add(tmpbl)
        Next

        Return tmpbookitemlistor

    End Function

    Public Function addNyBooklist(obj As krypinbooklisInfo) As Integer
        Dim Inlagd As Integer

        Try
            Dim b As New tblAJBookList
            b.boklistnamn = obj.Booklistname
            b.Userid = obj.Userid
            b.Dela = 1
            b.Datum = Date.Now
            b.gruppid = 0 ' 0= personliglista tillhör ingen grupp

            _linqobj.tblAJBookLists.InsertOnSubmit(b)
            _linqobj.SubmitChanges()

            Inlagd = b.id

        Catch ex As Exception
            Inlagd = 0
        End Try

        Return Inlagd
    End Function

    Public Function EditBooklistname(blid As Integer, booklistnamn As String) As Boolean
        Dim Inlagd As Boolean = False


        Try
            Dim ebl = (From c In _linqobj.tblAJBookLists
                       Where c.id = blid
                       Select c).First()

            ebl.boklistnamn = booklistnamn
            _linqobj.SubmitChanges()

            Inlagd = True
        Catch ex As Exception
            Inlagd = False
        End Try

        Return Inlagd
    End Function


    Public Function addBookItemToBooklist(blid As Integer, bookid As Integer) As Boolean
        Dim Inlagd As Boolean = False

        Try
            Dim b As New tblAJBookListItem
            b.blid = blid
            b.bookid = bookid

            _linqobj.tblAJBookListItems.InsertOnSubmit(b)
            _linqobj.SubmitChanges()
            Inlagd = True
        Catch ex As Exception
            Inlagd = False
        End Try

        Return Inlagd
    End Function

    Public Function addBookItemToMyBooks(userid As Integer, bookid As Integer) As Boolean
        Dim Inlagd As Boolean = False

        Try
            Dim b As New tblAjKatalogMyBook
            b.Userid = userid
            b.Bookid = bookid

            _linqobj.tblAjKatalogMyBooks.InsertOnSubmit(b)
            _linqobj.SubmitChanges()
            Inlagd = True
        Catch ex As Exception
            Inlagd = False
        End Try

        Return Inlagd
    End Function

    Public Function checkIfInMyBooklistItems(userid As Integer, bookid As Integer) As Boolean

        Dim ret As Boolean = False


        Dim bl = From c In _linqobj.tblAjKatalogMyBooks
                 Where c.Bookid = bookid And c.Userid = userid
                 Select c

        For Each i In bl
            ret = True
        Next

        Return ret

    End Function

    Public Function DelBookItemFromBooklist(blid As Integer, bookid As Integer) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim itm = From c In _linqobj.tblAJBookListItems
                      Where c.bookid = bookid AndAlso c.blid = blid
                      Select c

            For Each i In itm
                _linqobj.tblAJBookListItems.DeleteOnSubmit(i)
            Next

            _linqobj.SubmitChanges()
            deleted = True
        Catch ex As Exception
            deleted = False
        End Try

        Return deleted
    End Function

    Public Function DelBookItemFromMyBooks(userid As Integer, bookid As Integer) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim itm = From c In _linqobj.tblAjKatalogMyBooks
                      Where c.Bookid = bookid AndAlso c.Userid = userid
                      Select c

            For Each i In itm
                _linqobj.tblAjKatalogMyBooks.DeleteOnSubmit(i)
            Next

            _linqobj.SubmitChanges()
            deleted = True
        Catch ex As Exception
            deleted = False
        End Try

        Return deleted
    End Function


    Public Function DelBooklist(blid As Integer, userid As Integer) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim itm = From c In _linqobj.tblAJBookLists
                      Where c.id = blid AndAlso c.Userid = userid
                      Select c
            If Not itm.Count Then

                For Each i In itm
                    _linqobj.tblAJBookLists.DeleteOnSubmit(i)
                Next

                _linqobj.SubmitChanges()
                deleted = True

            End If
        Catch ex As Exception
            deleted = False
        End Try

        Return deleted
    End Function


    Public Function DelAllBooksFromBooklist(blid As Integer) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim itm = From c In _linqobj.tblAJBookListItems
                      Where c.blid = blid
                      Select c

            For Each i In itm
                _linqobj.tblAJBookListItems.DeleteOnSubmit(i)
            Next

            _linqobj.SubmitChanges()
            deleted = True
        Catch ex As Exception
            deleted = False
        End Try

        Return deleted
    End Function

#Region "Krypin Group boklist handler"
    Public Function getallBooklistFromGroup(groupid As Integer) As List(Of krypinbooklisInfo)

        Dim tmpbooklistor As New List(Of krypinbooklisInfo)

        Dim bl = From t In _linqobj.AjBooklist(2, groupid, 0, "")

        For Each t In bl
            Dim tmpbl As New krypinbooklisInfo
            tmpbl.BlID = t.id
            tmpbl.Booklistname = t.boklistnamn
            tmpbl.Userid = t.Userid
            tmpbl.gruppid = groupid
            tmpbooklistor.Add(tmpbl)
        Next

        Return tmpbooklistor

    End Function

    Public Function getallGroupBooklistFromUser(userid As Integer) As List(Of krypinbooklisInfo)

        Dim tmpbooklistor As New List(Of krypinbooklisInfo)

        Dim bl = From t In _linqobj.AJKrypinGroupUserBooklist(userid)

        For Each t In bl
            Dim tmpbl As New krypinbooklisInfo
            tmpbl.BlID = t.id
            tmpbl.Booklistname = t.boklistnamn
            tmpbl.Userid = t.userid
            tmpbl.gruppid = t.gruppid
            tmpbooklistor.Add(tmpbl)
        Next

        Return tmpbooklistor

    End Function

    Public Function getValdBooklistFromGroup(blid As Integer, groupid As Integer) As List(Of krypinbooklisInfo)

        Dim tmpbooklistor As New List(Of krypinbooklisInfo)

        Dim bl = From c In _linqobj.tblAJBookLists
                 Where c.id = blid And c.gruppid = groupid
                 Select c

        For Each t In bl
            Dim tmpbl As New krypinbooklisInfo
            tmpbl.BlID = t.id
            tmpbl.Booklistname = t.boklistnamn
            tmpbl.Userid = t.Userid
            tmpbl.gruppid = groupid
            tmpbooklistor.Add(tmpbl)

        Next

        Return tmpbooklistor

    End Function


    Public Function addNyBooklistToGroup(obj As krypinbooklisInfo) As Integer
        Dim Inlagd As Integer

        Try
            Dim b As New tblAJBookList
            b.boklistnamn = obj.Booklistname
            b.Userid = 0 ' 0= Grupplista tillhör ingen specifik användare
            b.Dela = 1
            b.Datum = Date.Now
            b.gruppid = obj.gruppid

            _linqobj.tblAJBookLists.InsertOnSubmit(b)
            _linqobj.SubmitChanges()

            Inlagd = b.id

        Catch ex As Exception
            Inlagd = 0
        End Try

        Return Inlagd
    End Function


    Public Function DelBooklistFromGroup(blid As Integer, groupid As Integer) As Boolean
        Dim deleted As Boolean = False

        Try
            Dim itm = From c In _linqobj.tblAJBookLists
                      Where c.id = blid AndAlso c.gruppid = groupid
                      Select c

            For Each i In itm
                _linqobj.tblAJBookLists.DeleteOnSubmit(i)
            Next

            _linqobj.SubmitChanges()
            deleted = True
        Catch ex As Exception
            deleted = False
        End Try

        Return deleted
    End Function


#End Region
    Public Function getlaserjustnuSetting(userid As Integer) As Integer
        Dim itm = (From e In _linqobj.tblAjKrypinUserSettings
                   Where e.userid = userid And e.settingTypID = 3
                   Select e).FirstOrDefault()

        Return itm.settingValue

    End Function


End Class
