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
            Dim TipObj As New boktipsInfo
            TipObj.Userid = x.Userid
            TipObj.title = x.Title
            TipObj.Author = x.Author
            TipObj.Bookid = x.Bookid
            TipObj.Inserted = x.Inserted
            TipObj.Category = x.Category
            TipObj.HighAge = x.HighAge
            TipObj.LowAge = x.LowAge
            TipObj.Review = x.Review
            TipObj.UserName = x.UserName
            TipObj.Tiptype = x.tiptype
            TipObj.Userage = x.Userage
            TipObj.Approved = x.Approved
            TipObj.TipID = x.TipID

            retAllaTip.Add(TipObj)
        Next

        Return retAllaTip
    End Function


End Class
