Public Class updateSettingInfo

    Private _userid As Integer
    Public Property Userid() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal value As Integer)
            _userid = value
        End Set
    End Property
    Private _Avatarid As Integer
    Public Property Avatarid() As Integer
        Get
            Return _Avatarid
        End Get
        Set(ByVal value As Integer)
            _Avatarid = value
        End Set
    End Property
    Private _ValdUserCss As Integer
    Public Property ValdUserCss() As Integer
        Get
            Return _ValdUserCss
        End Get
        Set(ByVal value As Integer)
            _ValdUserCss = value
        End Set
    End Property
    Private _LaserJustnu As Integer
    Public Property LaserJustnu() As Integer
        Get
            Return _LaserJustnu
        End Get
        Set(ByVal value As Integer)
            _LaserJustnu = value
        End Set
    End Property

End Class
