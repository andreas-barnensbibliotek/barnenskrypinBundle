Public Class questprogressInfo
    Public Sub New()
        _questid = 0
        _status = ""
        _statuscode = 0
        _subquestcompleted = 0
        _subquestTotal = 0
    End Sub
    Private _questid As Integer
    Public Property Questid() As Integer
        Get
            Return _questid
        End Get
        Set(ByVal value As Integer)
            _questid = value
        End Set
    End Property

    Private _subquestcompleted As Integer
    Public Property subQuestCompleted() As Integer
        Get
            Return _subquestcompleted
        End Get
        Set(ByVal value As Integer)
            _subquestcompleted = value
        End Set
    End Property
    Private _subquestTotal As Integer
    Public Property SubQuestTotal() As Integer
        Get
            Return _subquestTotal
        End Get
        Set(ByVal value As Integer)
            _subquestTotal = value
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
    Private _statuscode As Integer
    Public Property Statuscode() As Integer
        Get
            Return _statuscode
        End Get
        Set(ByVal value As Integer)
            _statuscode = value
        End Set
    End Property
End Class
