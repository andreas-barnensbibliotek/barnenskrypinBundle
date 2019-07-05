Public Class cmdInfo
    Public Sub New()
        _cmdtyp = ""
        _QTriggerID = 0
        _questID = 0
        _uquestID = 0
        _svar = ""
        _userid = 0
    End Sub
    Private _cmdtyp As String
    Public Property cmdtyp() As String
        Get
            Return _cmdtyp
        End Get
        Set(ByVal value As String)
            _cmdtyp = value
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

    Private _questID As Integer
    Public Property QuestID() As Integer
        Get
            Return _questID
        End Get
        Set(ByVal value As Integer)
            _questID = value
        End Set
    End Property

    Private _uquestID As Integer
    Public Property uQuestID() As Integer
        Get
            Return _uquestID
        End Get
        Set(ByVal value As Integer)
            _uquestID = value
        End Set
    End Property
    Private _QTriggerID As Integer
    Public Property QTriggerID() As Integer
        Get
            Return _QTriggerID
        End Get
        Set(ByVal value As Integer)
            _QTriggerID = value
        End Set
    End Property

    Private _svar As String
    Public Property Svar() As String
        Get
            Return _svar
        End Get
        Set(ByVal value As String)
            _svar = value
        End Set
    End Property
End Class
