Public Class bankSaldoInfo
    Private _userid As Integer
    Public Property Userid() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal value As Integer)
            _userid = value
        End Set
    End Property
    Private _banksaldo As Integer
    Public Property BankSaldo() As Integer
        Get
            Return _banksaldo
        End Get
        Set(ByVal value As Integer)
            _banksaldo = value
        End Set
    End Property
    Private _transaktioner As List(Of transactionInfo)
    Public Property Transaktioner() As List(Of transactionInfo)
        Get
            Return _transaktioner
        End Get
        Set(ByVal value As List(Of transactionInfo))
            _transaktioner = value
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
