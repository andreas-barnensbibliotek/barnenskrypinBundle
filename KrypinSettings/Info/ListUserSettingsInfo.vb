Public Class ListUserSettingsInfo
    Public Sub New()
        _userid = 0
        _displaynamn = ""
        _settingsList = New List(Of KrypinSettingInfo)
        _Status = ""
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
    Private Property _displaynamn As String
    Public Property Displaynamn() As String
        Get
            Return _displaynamn
        End Get
        Set(ByVal value As String)
            _displaynamn = value
        End Set
    End Property
    Private _laserjustnu As String
    Public Property LaserJustNu() As String
        Get
            Return _laserjustnu
        End Get
        Set(ByVal value As String)
            _laserjustnu = value
        End Set
    End Property
    Private _laserjustnuSrc As String
    Public Property LaserJustNuSrc() As String
        Get
            Return _laserjustnuSrc
        End Get
        Set(ByVal value As String)
            _laserjustnuSrc = value
        End Set
    End Property
    Private _settingsList As List(Of KrypinSettingInfo)
    Public Property SettingsList() As List(Of KrypinSettingInfo)
        Get
            Return _settingsList
        End Get
        Set(ByVal value As List(Of KrypinSettingInfo))
            _settingsList = value
        End Set
    End Property
    Private _Status As String
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property

End Class
