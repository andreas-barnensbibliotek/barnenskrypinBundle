Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class krypinbooklisInfo

    Private _blid As Integer
    Private _booklistname As String
    Private _userid As Integer
    Private _booklistitems As List(Of krypinbooklistItemDetailsInfo)
    Private _gruppid As Integer

    Public Sub New()
        _blid = 0
        _booklistname = ""
        _userid = 0
        _booklistitems = New List(Of krypinbooklistItemDetailsInfo)
        _gruppid = 0
    End Sub

    Public Property BlID() As Integer
        Get
            Return _blid
        End Get
        Set(ByVal Value As Integer)
            _blid = Value
        End Set
    End Property

    Public Property Booklistname() As String
        Get
            Return _booklistname
        End Get
        Set(ByVal Value As String)
            _booklistname = Value
        End Set
    End Property

    Public Property Userid() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal Value As Integer)
            _userid = Value
        End Set
    End Property

    Public Property BooklistItems() As List(Of krypinbooklistItemDetailsInfo)
        Get
            Return _booklistitems
        End Get
        Set(ByVal value As List(Of krypinbooklistItemDetailsInfo))
            _booklistitems = value
        End Set
    End Property
    Public Property gruppid() As Integer
        Get
            Return _gruppid
        End Get
        Set(ByVal Value As Integer)
            _gruppid = Value
        End Set
    End Property

End Class
