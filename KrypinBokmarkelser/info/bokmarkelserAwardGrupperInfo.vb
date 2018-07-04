Public Class bokmarkelserAwardGrupperInfo

    Public Sub New()
        _awardgroup = ""
        _awardgroupid = 0
        _bibblomonyEarnID = 0
        _occures = 0
        _pointEarned = 0
        _ToLevelup = 0

    End Sub


    Private _awardgroupid As Integer
    Public Property AwardGroupID() As Integer
        Get
            Return _awardgroupid
        End Get
        Set(ByVal value As Integer)
            _awardgroupid = value
        End Set
    End Property
    Private _awardgroup As String
    Public Property AwardGroup() As String
        Get
            Return _awardgroup
        End Get
        Set(ByVal value As String)
            _awardgroup = value
        End Set
    End Property

    Private _occures As Integer
    Public Property Occures() As Integer
        Get
            Return _occures
        End Get
        Set(ByVal value As Integer)
            _occures = value
        End Set
    End Property
    Private _pointEarned As Integer
    Public Property PointEarned() As Integer
        Get
            Return _pointEarned
        End Get
        Set(ByVal value As Integer)
            _pointEarned = value
        End Set
    End Property
    Private _ToLevelup As Integer
    Public Property ToLevelUp() As Integer
        Get
            Return _ToLevelup
        End Get
        Set(ByVal value As Integer)
            _ToLevelup = value
        End Set
    End Property

    Private _bibblomonyEarnID As Integer
    Public Property BibblomoneyEarnID() As Integer
        Get
            Return _bibblomonyEarnID
        End Get
        Set(ByVal value As Integer)
            _bibblomonyEarnID = value
        End Set
    End Property
End Class
