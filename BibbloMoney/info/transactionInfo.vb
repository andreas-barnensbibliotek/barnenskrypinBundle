Public Class transactionInfo

    Public Sub New()
        _earnfuncid = 0
        _userid = 0
        _amount = 0
        _bonus = 0
    End Sub

    Private _earnfuncid As Integer
    Public Property EarnFuncID() As Integer
        Get
            Return _earnfuncid
        End Get
        Set(ByVal value As Integer)
            _earnfuncid = value
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

    Private _amount As Integer
    Public Property Amount() As Integer
        Get
            Return _amount
        End Get
        Set(ByVal value As Integer)
            _amount = value
        End Set
    End Property

    Private _bonus As Integer
    Public Property Bonus() As Integer
        Get
            Return _bonus
        End Get
        Set(ByVal value As Integer)
            _bonus = value
        End Set
    End Property

    Private _beskrivning As String
    Public Property Beskrivning() As String
        Get
            Return _beskrivning
        End Get
        Set(ByVal value As String)
            _beskrivning = value
        End Set
    End Property
End Class
