Imports Microsoft.VisualBasic

Public Class NyttKrypinDefaultValuesInfo

    Public Sub New()
        _userid = 0
        _avatar = "defautlavatar_gubbeGlad2.gif"
        _bbmess = ""
        _behorighet = 2
        _laserjustnu = 0
        _css = 2

    End Sub

    Private _userid As Integer
    Public Property Userid() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal value As Integer)
            _userid = value
        End Set
    End Property
    Private _avatar As String
    Public Property Avatar() As String
        Get
            Return _avatar
        End Get
        Set(ByVal value As String)
            _avatar = value
        End Set
    End Property
    Private _bbmess As String
    Public Property BBMess() As String
        Get
            Return _bbmess
        End Get
        Set(ByVal value As String)
            _bbmess = value
        End Set
    End Property
    Private _behorighet As Integer
    Public Property Behorighet() As Integer
        Get
            Return _behorighet
        End Get
        Set(ByVal value As Integer)
            _behorighet = value
        End Set
    End Property
    Private _css As Integer
    Public Property Css() As Integer
        Get
            Return _css
        End Get
        Set(ByVal value As Integer)
            _css = value
        End Set
    End Property
    Private _laserjustnu As Integer
    Public Property Laserjustnu() As Integer
        Get
            Return _laserjustnu
        End Get
        Set(ByVal value As Integer)
            _laserjustnu = value
        End Set
    End Property
End Class
