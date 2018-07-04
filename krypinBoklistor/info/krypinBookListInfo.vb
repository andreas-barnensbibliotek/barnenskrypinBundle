Public Class krypinBookListInfo
    Public Sub New()
        _booklists = New List(Of krypinbooklisInfo)
        _status = "ok"
    End Sub

    Private _booklists As List(Of krypinbooklisInfo)
    Public Property Booklists() As List(Of krypinbooklisInfo)
        Get
            Return _booklists
        End Get
        Set(ByVal value As List(Of krypinbooklisInfo))
            _booklists = value
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
