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

    Public Function getLatestBokTipsByUserid(userid As Integer) As List(Of boktipsInfo)

        Dim retAllaTip As New List(Of boktipsInfo)

        Dim tips = (From p In _linqObj.tblAJBookTips
                    Where p.Userid = userid
                    Order By p.Inserted).First()

        Dim TipObj As New boktipsInfo With {
            .Userid = tips.Userid,
            .Title = tips.Title,
            .Author = tips.Author,
            .Bookid = tips.Bookid,
            .Inserted = tips.Inserted,
            .Category = tips.Category,
            .HighAge = tips.HighAge,
            .LowAge = tips.LowAge,
            .Review = tips.Review,
            .UserName = tips.UserName,
            .Tiptype = tips.tiptype,
            .Userage = tips.userage,
            .Approved = tips.Approved,
            .TipID = tips.TipID
        }

        retAllaTip.Add(TipObj)

        Return retAllaTip
    End Function
End Class
