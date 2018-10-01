Public Class boktipsByUseridDAL

#Region "DATA LINQ SETUP"
    Private connectionObj As New connectionstringHandler
    Private _linqObj As New LinqDataModelDataContext(connectionObj.CurrentConnectionString)
#End Region

    Public Function getBoktipsByUserid(userid As Integer) As List(Of boktipsInfo)

        Dim retAllaUserTip As New List(Of boktipsInfo)

        Dim tips = From e In _linqObj.tblAJBookTips
                   Where e.Userid = userid
                   Select e

        For Each x In tips
                Dim TipObj As New boktipsInfo
                TipObj.Userid = x.Userid
                TipObj.Title = x.Title
                TipObj.Author = x.Author
                TipObj.Bookid = x.Bookid
                TipObj.Inserted = x.Inserted
                TipObj.Category = x.Category
                TipObj.HighAge = x.HighAge
                TipObj.LowAge = x.LowAge
                TipObj.Review = x.Review
                TipObj.UserName = x.UserName
                TipObj.Tiptype = x.tiptype
                TipObj.Userage = x.userage
                TipObj.Approved = x.Approved
                TipObj.TipID = x.TipID

            retAllaUserTip.Add(TipObj)
        Next

        Return retAllaUserTip
    End Function


End Class
