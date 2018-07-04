Public Class krypinBoktipsInfo
    Public Sub New()
        _booktips = New List(Of boktipsInfo)
        _status = "ok"
    End Sub

    Private _booktips As List(Of boktipsInfo)
    Public Property Boktips() As List(Of boktipsInfo)
        Get
            Return _booktips
        End Get
        Set(ByVal value As List(Of boktipsInfo))
            _booktips = value
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
