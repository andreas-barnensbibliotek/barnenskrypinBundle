Public Class subquestinfo
    Public Sub New()
        _qtriggid = 0
        _qid = 0
        _tvalue = ""
        _tname = ""
        _completed = 0
    End Sub
    Private _qtriggid As Integer
    Public Property QtrigId() As Integer
        Get
            Return _qtriggid
        End Get
        Set(ByVal value As Integer)
            _qtriggid = value
        End Set
    End Property

    Private _qid As Integer
    Public Property Qid() As Integer
        Get
            Return _qid
        End Get
        Set(ByVal value As Integer)
            _qid = value
        End Set
    End Property
    Private _tname As String
    Public Property TName() As String
        Get
            Return _tname
        End Get
        Set(ByVal value As String)
            _tname = value
        End Set
    End Property
    Private _tvalue As String
    Public Property TValue() As String
        Get
            Return _tvalue
        End Get
        Set(ByVal value As String)
            _tvalue = value
        End Set
    End Property

    Private _completed As Integer
    Public Property Completed() As Integer
        Get
            Return _completed
        End Get
        Set(ByVal value As Integer)
            _completed = value
        End Set
    End Property
End Class
