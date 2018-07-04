Public Class commandTypeInfo
    Public Sub New()
        _crudtyp = ""
        _getPublishTyp = 0
        _category = 0
        _skrivid = 0
        _userid = 0
        _approved = 1
        _publish = 3
    End Sub

    Private _crudtyp As String
    Public Property Crudtyp() As String
        Get
            Return _crudtyp
        End Get
        Set(ByVal value As String)
            _crudtyp = value
        End Set
    End Property

    Private _getPublishTyp As Integer
    Public Property GetPublishTyp() As Integer
        Get
            Return _getPublishTyp
        End Get
        Set(ByVal value As Integer)
            _getPublishTyp = value
        End Set
    End Property

    Private _skrivid As Integer
    Public Property Skrivid() As Integer
        Get
            Return _skrivid
        End Get
        Set(ByVal value As Integer)
            _skrivid = value
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

    Private _category As Integer
    Public Property Category() As Integer
        Get
            Return _category
        End Get
        Set(ByVal value As Integer)
            _category = value
        End Set
    End Property
    Private _approved As Integer
    Public Property Approved() As Integer
        Get
            Return _approved
        End Get
        Set(ByVal value As Integer)
            _approved = value
        End Set
    End Property

    Private _publish As Integer
    Public Property Publish() As Integer
        Get
            Return _publish
        End Get
        Set(ByVal value As Integer)
            _publish = value
        End Set
    End Property
End Class
