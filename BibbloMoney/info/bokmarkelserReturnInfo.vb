Public Class bokmarkelserReturnInfo
    Public Sub New()
        _bokmarkelser = New List(Of bokmarkelserAwardsInfo)
        _userid = 0
        _status = ""
    End Sub
    Private _bokmarkelser As List(Of bokmarkelserAwardsInfo)
    Public Property Bokmarkelser() As List(Of bokmarkelserAwardsInfo)
        Get
            Return _bokmarkelser
        End Get
        Set(ByVal value As List(Of bokmarkelserAwardsInfo))
            _bokmarkelser = value
        End Set
    End Property

    Private _userid As Integer
    Public Property Userid() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal value As Integer)
            _userid = value
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
