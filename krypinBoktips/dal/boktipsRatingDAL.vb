﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Imports System.Configuration
Imports System.Text

Public Class boktipsRatingDAL

#Region "DATA LINQ SETUP"
    Private connectionObj As New connectionstringHandler
    Private _linqObj As New LinqDataModelDataContext(connectionObj.CurrentConnectionString)
#End Region
    Public Function boktipsByRating(antal As Integer) As List(Of boktipsInfo)

        Dim bookRatingObj = From bt In _linqObj.ajkat_BoktipsByRating(antal)
                        Select bt

        Dim baslistaBoktips As New List(Of boktipsInfo)

        Try

            For Each x In bookRatingObj

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
End Class
