Imports System
Imports System.Collections
Imports System.Collections.Generic



Public Interface IBoktipsGetBase

    Function BookTipsByTitle(title As String) As List(Of boktipsInfo)

    Function BookTipsByAuthor(author As String) As List(Of boktipsInfo)

    Function BookTipsByCategory(catid As Integer) As List(Of boktipsInfo)

    Function BookTipsByRandom(Optional antal As Integer = 1) As List(Of boktipsInfo)

    Function BookTipsByRandomInCategory(catid As Integer, Optional antal As Integer = 1) As List(Of boktipsInfo)

    Function BooktTipsByAgeInterval(age As Integer) As List(Of boktipsInfo)

    Function BookTipsLatest(Optional antal As Integer = 5) As List(Of boktipsInfo)

    Function BookTipsBySearch(Search As String) As List(Of boktipsInfo)

    Function BookTipsByRating(antal As Integer) As List(Of boktipsInfo)

End Interface


