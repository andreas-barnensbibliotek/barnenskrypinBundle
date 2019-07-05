Public Class activeQuestlist
    Public Sub New()
        _questlist = New List(Of QuestInfo)
        _statuscode = 0
        _status = ""
    End Sub

    Private _questlist As List(Of QuestInfo)
    Public Property ActiveQuestlist() As List(Of QuestInfo)
        Get
            Return _questlist
        End Get
        Set(ByVal value As List(Of QuestInfo))
            _questlist = value
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
