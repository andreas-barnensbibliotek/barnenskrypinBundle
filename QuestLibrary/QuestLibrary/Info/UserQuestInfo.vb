Public Class UserQuestInfo
    Public Sub New()
        _questid = 0
        _uquestid = 0
        _usersubquestlist = New List(Of userSubquestInfo)
        _subquestlist = New List(Of subquestinfo)
        _activequests = New List(Of QuestInfo)
        _questProgressstatus = New questprogressInfo
        _userid = 0
        _aid = 0
        _uppdrag = ""
        _questbeskrivning = ""
        _questBadgesrc = ""
        _questcompleted = 0
        _statuscode = 0
        _status = ""
    End Sub

    Private _aid As Integer
    Public Property AID() As Integer
        Get
            Return _aid
        End Get
        Set(ByVal value As Integer)
            _aid = value
        End Set
    End Property

    Private _uquestid As Integer
    Public Property UQuestID() As Integer
        Get
            Return _uquestid
        End Get
        Set(ByVal value As Integer)
            _uquestid = value
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

    Private _questid As Integer
    Public Property QuestID() As Integer
        Get
            Return _questid
        End Get
        Set(ByVal value As Integer)
            _questid = value
        End Set
    End Property

    Private _usersubquestlist As List(Of userSubquestInfo)
    Public Property UserSubquestlist() As List(Of userSubquestInfo)
        Get
            Return _usersubquestlist
        End Get
        Set(ByVal value As List(Of userSubquestInfo))
            _usersubquestlist = value
        End Set
    End Property

    Private _subquestlist As List(Of subquestinfo)
    Public Property Subquestlist() As List(Of subquestinfo)
        Get
            Return _subquestlist
        End Get
        Set(ByVal value As List(Of subquestinfo))
            _subquestlist = value
        End Set
    End Property

    Private _questProgressstatus As questprogressInfo
    Public Property QuestProggressStatus() As questprogressInfo
        Get
            Return _questProgressstatus
        End Get
        Set(ByVal value As questprogressInfo)
            _questProgressstatus = value
        End Set
    End Property

    Private _activequests As List(Of QuestInfo)
    Public Property ActiveQuests() As List(Of QuestInfo)
        Get
            Return _activequests
        End Get
        Set(ByVal value As List(Of QuestInfo))
            _activequests = value
        End Set
    End Property

    Private _uppdrag As String
    Public Property Uppdrag() As String
        Get
            Return _uppdrag
        End Get
        Set(ByVal value As String)
            _uppdrag = value
        End Set
    End Property
    Private _questbeskrivning As String
    Public Property questbeskrivning() As String
        Get
            Return _questbeskrivning
        End Get
        Set(ByVal value As String)
            _questbeskrivning = value
        End Set
    End Property
    Private _questBadgesrc As String
    Public Property QuestBadgeSrc() As String
        Get
            Return _questBadgesrc
        End Get
        Set(ByVal value As String)
            _questBadgesrc = value
        End Set
    End Property
    Private _questcompleted As Integer
    Public Property QuestCompleted() As Integer
        Get
            Return _questcompleted
        End Get
        Set(ByVal value As Integer)
            _questcompleted = value
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
