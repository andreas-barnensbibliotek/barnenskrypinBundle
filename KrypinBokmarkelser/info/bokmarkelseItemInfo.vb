Public Class bokmarkelseItemInfo

    Public Sub New()
        _awardname = ""
        _badgesrc = ""
        _beskrivning = ""
    End Sub

    Private _awardname As String
    Public Property AwardName() As String
        Get
            Return _awardname
        End Get
        Set(ByVal value As String)
            _awardname = value
        End Set
    End Property
    Private _badgesrc As String
    Public Property Badgesrc() As String
        Get
            Return _badgesrc
        End Get
        Set(ByVal value As String)
            _badgesrc = value
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
