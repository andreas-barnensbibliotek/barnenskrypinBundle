Public Class bokmarkelserReturnInfo
    Private _bokmarkelser As List(Of bokmarkelseItemInfo)
    Public Property Bokmarkelser() As List(Of bokmarkelseItemInfo)
        Get
            Return _bokmarkelser
        End Get
        Set(ByVal value As List(Of bokmarkelseItemInfo))
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
