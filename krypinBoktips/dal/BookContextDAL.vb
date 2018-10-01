Public Class BookContextDAL

#Region "DATA LINQ SETUP"
    Private connectionObj As New connectionstringHandler
    Private _linqObj As New LinqDataModelDataContext(connectionObj.CurrentConnectionString)
#End Region
    Public Function getBooktipBookContextByBookID(bookid As Integer) As List(Of boktipsInfo)

        Dim bookContextObj = From i In _linqObj.tblAjKatalogBooks
                             Where i.bookID = bookid
                             Select i

        Dim bookContextList As New List(Of boktipsInfo)

        Try
            For Each x In bookContextObj

                Dim tmp As New boktipsInfo
                tmp.Title = x.Title
                tmp.Bookid = x.bookID

                bookContextList.Add(tmp)
            Next

        Catch ex As Exception
        End Try

        Return bookContextList

    End Function
End Class
