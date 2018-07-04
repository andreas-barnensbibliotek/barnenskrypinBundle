Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Imports System.Configuration
Imports System.Text


Public Class boktipsAuthorDAL

#Region "DATA LINQ SETUP"
    Private connectionObj As New connectionstringHandler
    Private _linqObj As New LinqDataModelDataContext(connectionObj.CurrentConnectionString)
#End Region

    Public Enum ProcTyp
        authorNamn = 1
        authorID = 2
    End Enum

    Public Function boktipsAuthorNameBaseInfo(name As String) As List(Of boktipsInfo)

        Dim authorObj = From bt In _linqObj.ajKat_BoktipsByAuthor(ProcTyp.authorNamn, name, 1)
                        Select bt

        Dim baslistaBoktips As New List(Of boktipsInfo)

        Try

            For Each x In authorObj

                Dim tmp As New boktipsInfo
                tmp.TipID = x.TipID
                tmp.Tiptype = x.tiptype
                tmp.Title = x.Title
                tmp.Userage = x.userage
                tmp.Userid = x.Userid
                tmp.UserName = x.UserName
                tmp.Approved = x.Approved
                tmp.Author = x.Author
                tmp.HighAge = x.HighAge
                tmp.LowAge = x.LowAge
                tmp.Inserted = x.Inserted
                tmp.Category = x.Category
                tmp.Review = x.Review
                tmp.Bookid = x.Bookid

                baslistaBoktips.Add(tmp)

            Next

        Catch ex As Exception

        End Try

        Return baslistaBoktips

    End Function


    Public Function boktipsAuthorIDBaseInfo(forfID As Integer) As List(Of boktipsInfo)

        Dim authorObj = From bt In _linqObj.ajKat_BoktipsByAuthor(ProcTyp.authorID, String.Empty, forfID)
                        Select bt

        Dim baslistaBoktips As New List(Of boktipsInfo)

        Try

            For Each x In authorObj

                Dim tmp As New boktipsInfo
                tmp.TipID = x.TipID
                tmp.Tiptype = x.tiptype
                tmp.Title = x.Title
                tmp.Userage = x.userage
                tmp.Userid = x.Userid
                tmp.UserName = x.UserName
                tmp.Approved = x.Approved
                tmp.Author = x.Author
                tmp.HighAge = x.HighAge
                tmp.LowAge = x.LowAge
                tmp.Inserted = x.Inserted
                tmp.Category = x.Category
                tmp.Review = x.Review
                tmp.Bookid = x.Bookid

                baslistaBoktips.Add(tmp)

            Next

        Catch ex As Exception

        End Try

        Return baslistaBoktips

    End Function


    Function BookidToISBN(bookid As Integer) As String

        Dim retstr As String = ""

        Dim authorObj = From bt In _linqObj.ajkat_BoktipsBookidToISBN(bookid)
                        Select bt

        Try
            For Each x In authorObj
                retstr = x.isbn
            Next
        Catch ex As Exception

        End Try

        Return retstr

    End Function


End Class

