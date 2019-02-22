Public Class CRUDBoktipsDAL

#Region "DATA LINQ SETUP"
    Private connectionObj As New connectionstringHandler
    Private _linqObj As New LinqDataModelDataContext(connectionObj.CurrentConnectionString)
#End Region

    Public Function GetBoktips(tipid As Integer) As boktipsInfo

        Dim boktipsObj = (From i In _linqObj.tblAJBookTips
                          Where i.TipID = tipid).FirstOrDefault()

        Dim retobj As New boktipsInfo
        With retobj
            .TipID = boktipsObj.TipID
            .Author = boktipsObj.Author
            .Bookid = boktipsObj.Bookid
            .Category = boktipsObj.Category
            .HighAge = boktipsObj.HighAge
            .Inserted = boktipsObj.Inserted
            .LowAge = boktipsObj.LowAge
            .Review = boktipsObj.Review
            .Tiptype = boktipsObj.tiptype
            .Title = boktipsObj.Title
            .Userage = boktipsObj.userage
            .Userid = boktipsObj.Userid
            .UserName = boktipsObj.UserName
            .Approved = boktipsObj.Approved

        End With

        Return retobj

    End Function

    Public Function GetBoktipsApproveList() As List(Of boktipsInfo)
        Dim retobj As New List(Of boktipsInfo)

        Dim boktipsObj = From i In _linqObj.AJBoktipsApprove(1, 0, 0)

        For Each x In boktipsObj
            Dim itm As New boktipsInfo
            With itm
                .TipID = x.TipID
                .Author = x.Author
                .Bookid = x.Bookid
                .Category = x.Category
                .HighAge = x.HighAge
                .Inserted = x.Inserted
                .LowAge = x.LowAge
                .Review = x.Review
                .Tiptype = x.tiptype
                .Title = x.Title
                .Userage = x.userage
                .Userid = x.Userid
                .UserName = x.UserName
                .Approved = x.Approved
            End With

            retobj.Add(itm)
        Next

        Return retobj

    End Function

    Public Function GetBoktipsALL() As List(Of boktipsInfo)
        Dim retobj As New List(Of boktipsInfo)

        Dim boktipsObj = From i In _linqObj.tblAJBookTips
                         Select i
                         Order By i.Inserted Descending


        For Each x In boktipsObj
            Dim itm As New boktipsInfo
            With itm
                .TipID = x.TipID
                .Author = x.Author
                .Bookid = x.Bookid
                .Category = x.Category
                .HighAge = x.HighAge
                .Inserted = x.Inserted
                .LowAge = x.LowAge
                .Review = x.Review
                .Tiptype = x.tiptype
                .Title = x.Title
                .Userage = x.userage
                .Userid = x.Userid
                .UserName = x.UserName
                .Approved = x.Approved
            End With

            retobj.Add(itm)
        Next

        Return retobj

    End Function

    Public Function AddBoktips(nyttboktips As boktipsInfo) As Boolean

        Dim boktipsObj As New tblAJBookTip
        Try

            With boktipsObj
                .Author = "-"
                .Bookid = nyttboktips.Bookid
                .Category = nyttboktips.Category
                .HighAge = nyttboktips.HighAge
                .Inserted = Date.Now
                .LowAge = nyttboktips.LowAge
                .Review = nyttboktips.Review
                .tiptype = nyttboktips.Tiptype
                .Title = nyttboktips.Title
                .userage = nyttboktips.Userage
                .Userid = nyttboktips.Userid
                .UserName = Getusername(nyttboktips.Userid)
                .Approved = nyttboktips.Approved
            End With

            _linqObj.tblAJBookTips.InsertOnSubmit(boktipsObj)
            _linqObj.SubmitChanges()
            Dim tipid As Integer = boktipsObj.TipID

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EditBoktips(booktips As boktipsInfo) As Boolean
        Dim ret As Boolean = False

        Try
            Dim upd = From e In _linqObj.tblAJBookTips
                      Where e.TipID = booktips.TipID
                      Select e

            For Each itm In upd
                itm.Category = booktips.Category
                itm.HighAge = booktips.HighAge
                itm.LowAge = booktips.LowAge
                itm.Review = booktips.Review
                itm.tiptype = booktips.Tiptype
                itm.Title = booktips.Title
                itm.userage = booktips.Userage
                itm.UserName = Getusername(itm.Userid)
                itm.Bookid = booktips.Bookid

            Next

            _linqObj.SubmitChanges()
            ret = True
        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

    Public Function ApproveBoktips(tipid As Integer, val As Integer) As Boolean
        Dim ret As Boolean = False

        Try
            Dim upd = From e In _linqObj.tblAJBookTips
                      Where e.TipID = tipid
                      Select e

            For Each itm In upd
                itm.Approved = val
            Next

            _linqObj.SubmitChanges()
            ret = True
        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function


    Public Function DeleteBoktips(tipid As Integer) As Boolean
        Dim deleted As Boolean = False
        Try
            Dim itm = From e In _linqObj.tblAJBookTips
                      Where e.TipID = tipid
                      Select e

            For Each i In itm
                _linqObj.tblAJBookTips.DeleteOnSubmit(i)
            Next

            _linqObj.SubmitChanges()
            deleted = True
        Catch ex As Exception
            deleted = False
        End Try

        Return deleted
    End Function

    Private Function Getusername(UsrID As Integer) As String
        Dim retstr As String = ""

        Dim boktipsObj = From i In _linqObj.Users
                         Select i
                         Where i.UserID = UsrID


        For Each x In boktipsObj
            retstr = x.Username
        Next

        Return retstr

    End Function
End Class
