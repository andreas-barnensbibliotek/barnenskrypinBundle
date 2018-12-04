Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Public Class krypinbooklistItemDetailsInfo
    Private _bookID As Integer = 0
    Private _title As String = "Lägg till"
    Private _isbn As String = ""
    Private _forfattare As String = ""
    Private _imageurl As String = ""
    Private _lasernu As Boolean = False

    Public Property Bookid() As Integer
        Get
            Return _bookID
        End Get
        Set(ByVal Value As Integer)
            _bookID = Value
        End Set
    End Property

    Public Property title() As String
        Get
            Return _title
        End Get
        Set(ByVal Value As String)
            _title = Value
        End Set
    End Property

    Public Property isbn() As String
        Get
            Return _isbn
        End Get
        Set(ByVal Value As String)
            _isbn = Value
        End Set
    End Property
    Public Property imageurl() As String
        Get
            Return _imageurl
        End Get
        Set(ByVal Value As String)
            _imageurl = Value
        End Set
    End Property

    Public Property Forfattare() As String
        Get
            Return _forfattare
        End Get
        Set(ByVal value As String)
            _forfattare = value
        End Set
    End Property


    Public Property Lasernu() As Boolean
        Get
            Return _lasernu
        End Get
        Set(ByVal value As Boolean)
            _lasernu = value
        End Set
    End Property

End Class
