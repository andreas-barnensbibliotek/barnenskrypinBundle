Public Class userSubquestInfo

    Public Sub New()
        _id = 0
        _subquestid = 0
        _userquestid = 0
        _subquestcompleted = 0
        _subquestTriggerid = 0
    End Sub
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _subquestid As Integer
    Public Property subquestid() As Integer
        Get
            Return _subquestid
        End Get
        Set(ByVal value As Integer)
            _subquestid = value
        End Set
    End Property

    Private _userquestid As Integer
    Public Property Userquestid() As Integer
        Get
            Return _userquestid
        End Get
        Set(ByVal value As Integer)
            _userquestid = value
        End Set
    End Property
    Private _subquestTriggerid As Integer
    Public Property SubQuestTriggerID() As Integer
        Get
            Return _subquestTriggerid
        End Get
        Set(ByVal value As Integer)
            _subquestTriggerid = value
        End Set
    End Property
    Private _subquestcompleted As Integer
    Public Property SubQuestCompleted() As Integer
        Get
            Return _subquestcompleted
        End Get
        Set(ByVal value As Integer)
            _subquestcompleted = value
        End Set
    End Property
End Class

