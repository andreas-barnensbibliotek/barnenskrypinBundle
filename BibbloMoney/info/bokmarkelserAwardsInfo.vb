Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class bokmarkelserAwardsInfo

    Private _user As Integer
    Public Property Userid() As Integer
        Get
            Return _user
        End Get
        Set(ByVal value As Integer)
            _user = value
        End Set
    End Property

    Private _aid As Integer
    Public Property Awardid() As Integer
        Get
            Return _aid
        End Get
        Set(ByVal value As Integer)
            _aid = value
        End Set
    End Property

    Private _counter As Integer
    Public Property Counter() As Integer
        Get
            Return _counter
        End Get
        Set(ByVal value As Integer)
            _counter = value
        End Set
    End Property

    Private _UserLevel As Integer
    Public Property UserLevel() As Integer
        Get
            Return _UserLevel
        End Get
        Set(ByVal value As Integer)
            _UserLevel = value
        End Set
    End Property

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

    Private _occurs As Integer
    Public Property Occures() As Integer
        Get
            Return _occurs
        End Get
        Set(ByVal value As Integer)
            _occurs = value
        End Set
    End Property

    Private _awardgroup As Integer
    Public Property AwardGroup() As Integer
        Get
            Return _awardgroup
        End Get
        Set(ByVal value As Integer)
            _awardgroup = value
        End Set
    End Property
    Private _tolevelUp As Integer
    Public Property TolevelUp() As Integer
        Get
            Return _tolevelUp
        End Get
        Set(ByVal value As Integer)
            _tolevelUp = value
        End Set
    End Property
    Private _earnfuncID As Integer
    Public Property EarnFuncID() As Integer
        Get
            Return _earnfuncID
        End Get
        Set(ByVal value As Integer)
            _earnfuncID = value
        End Set
    End Property
End Class
