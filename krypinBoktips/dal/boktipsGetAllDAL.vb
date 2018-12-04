Public Class boktipsGetAllDAL

#Region "DATA LINQ SETUP"
    Private connectionObj As New connectionstringHandler
    Private _linqObj As New LinqDataModelDataContext(connectionObj.CurrentConnectionString)
#End Region

    Public Function getBokTipsAlla() As List(Of boktipsInfo)

        Dim retAllaTip As New List(Of boktipsInfo)

        Dim tips = From p In _linqObj.AJBoktipsGet(1, 0, 0)
                   Select p

        For Each x In tips
            Dim TipObj As New boktipsInfo With {
                .Userid = x.Userid,
                .Title = x.Title,
                .Author = x.Author,
                .Bookid = x.Bookid,
                .Inserted = x.Inserted,
                .Category = x.Category,
                .HighAge = x.HighAge,
                .LowAge = x.LowAge,
                .Review = x.Review,
                .UserName = x.UserName,
                .Tiptype = x.tiptype,
                .Userage = x.Userage,
                .Approved = x.Approved,
                .TipID = x.TipID
            }

            retAllaTip.Add(TipObj)
        Next

        Return retAllaTip
    End Function



End Class
