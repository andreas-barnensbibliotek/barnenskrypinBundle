Public Class skrivbokenJsonContainerInfo

    Public Sub New()
        _skrivitemCount = 0
        _skrivbokenList = New List(Of skrivItemInfo)
        _skrivbokenListCount = 0
        _status = ""
    End Sub

    Private _skrivbokenList As List(Of skrivItemInfo)
    Public Property SkrivbokenList() As List(Of skrivItemInfo)
        Get
            Return _skrivbokenList
        End Get
        Set(ByVal value As List(Of skrivItemInfo))
            _skrivbokenList = value
        End Set
    End Property

    Private _skrivbokenListCount As String
    Public Property SkrivbokenListCount() As String
        Get
            Return _skrivbokenListCount
        End Get
        Set(ByVal value As String)
            _skrivbokenListCount = value
        End Set
    End Property

    Private _skrivitemCount As String
    Public Property SkrivItemCount() As String
        Get
            Return _skrivitemCount
        End Get
        Set(ByVal value As String)
            _skrivitemCount = value
        End Set
    End Property

    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property
End Class
