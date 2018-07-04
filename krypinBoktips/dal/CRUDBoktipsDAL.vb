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

    Public Function AddBoktips(nyttboktips As boktipsInfo) As Boolean

        Dim boktipsObj As New tblAJBookTip
        Try

            With boktipsObj
                .Author = nyttboktips.Author
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
                .UserName = nyttboktips.UserName
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
                itm.Bookid = booktips.Bookid

            Next

            _linqObj.SubmitChanges()

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

End Class
