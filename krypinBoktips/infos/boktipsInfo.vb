


Public Class boktipsInfo
    Implements iBoktipsInfo

    ' local property declarations
    Private _TipID As Integer
    Private _Title As String
    Private _Bookid As Integer
    Private _Author As String
    Private _HighAge As Integer
    Private _LowAge As Integer
    Private _Review As String
    Private _UserName As String
    Private _Userid As Integer
    Private _Userage As Integer
    Private _tiptype As Integer
    Private _Approved As Integer
    Private _Category As String
    Private _imgsrc As String
    Private _Inserted As Date

    ' initialization
    Public Sub New()
        _TipID = 0
        _Title = ""
        _Bookid = 0
        _Author = ""
        _HighAge = 1
        _LowAge = 1
        _Review = ""
        _UserName = ""
        _Userid = 0
        _Userage = 1
        _tiptype = 0
        _Approved = 0
        _Category = "0"
        _Inserted = Date.Now.ToShortDateString

    End Sub

    ' public properties
    Public Property TipID() As Integer Implements iBoktipsInfo.TipID
        Get
            Return _TipID
        End Get
        Set(ByVal Value As Integer)
            _TipID = Value
        End Set
    End Property

    Public Property Title() As String Implements iBoktipsInfo.Title
        Get
            Return _Title
        End Get
        Set(ByVal Value As String)
            _Title = Value
        End Set
    End Property

    Public Property Bookid() As Integer Implements iBoktipsInfo.Bookid
        Get
            Return _Bookid
        End Get
        Set(ByVal Value As Integer)
            _Bookid = Value
        End Set
    End Property

    Public Property Author() As String Implements iBoktipsInfo.Author
        Get
            Return _Author
        End Get
        Set(ByVal Value As String)
            _Author = Value
        End Set
    End Property

    Public Property HighAge() As Integer Implements iBoktipsInfo.HighAge
        Get
            Return _HighAge
        End Get
        Set(ByVal Value As Integer)
            _HighAge = Value
        End Set
    End Property

    Public Property LowAge() As Integer Implements iBoktipsInfo.LowAge
        Get
            Return _LowAge
        End Get
        Set(ByVal Value As Integer)
            _LowAge = Value
        End Set
    End Property

    Public Property Review() As String Implements iBoktipsInfo.Review
        Get
            Return _Review
        End Get
        Set(ByVal Value As String)
            _Review = Value
        End Set
    End Property

    Public Property UserName() As String Implements iBoktipsInfo.UserName
        Get
            Return _UserName
        End Get
        Set(ByVal Value As String)
            _UserName = Value
        End Set
    End Property

    Public Property Userid() As Integer Implements iBoktipsInfo.Userid
        Get
            Return _Userid
        End Get
        Set(ByVal Value As Integer)
            _Userid = Value
        End Set
    End Property

    Public Property Userage() As Integer Implements iBoktipsInfo.Userage
        Get
            Return _Userage
        End Get
        Set(ByVal Value As Integer)
            _Userage = Value
        End Set
    End Property

    Public Property Tiptype() As Integer Implements iBoktipsInfo.tiptype
        Get
            Return _tiptype
        End Get
        Set(ByVal Value As Integer)
            _tiptype = Value
        End Set
    End Property

    Public Property Category() As String Implements iBoktipsInfo.Category
        Get
            Return _Category
        End Get
        Set(ByVal Value As String)
            _Category = Value
        End Set
    End Property

    Public Property ImgSrc() As String Implements iBoktipsInfo.imgsrc
        Get
            Return _imgsrc
        End Get
        Set(ByVal Value As String)
            _imgsrc = Value
        End Set
    End Property

    Public Property Approved() As Integer Implements iBoktipsInfo.Approved
        Get
            Return _Approved
        End Get
        Set(ByVal Value As Integer)
            _Approved = Value
        End Set
    End Property

    Public Property Inserted() As Date Implements iBoktipsInfo.Inserted
        Get
            Return _Inserted
        End Get
        Set(ByVal Value As Date)
            _Inserted = Value
        End Set
    End Property

End Class
