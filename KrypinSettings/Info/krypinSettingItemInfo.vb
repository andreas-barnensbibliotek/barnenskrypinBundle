Public Class krypinSettingItemInfo

    Public Sub New()
        _settingID = 0
        _settingName = ""
        _settingSrc = ""
        _settingClass = ""
        _settingBeskrivning = ""
    End Sub

    Private _settingID As Integer
    Public Property SettingsID() As Integer
        Get
            Return _settingID
        End Get
        Set(ByVal value As Integer)
            _settingID = value
        End Set
    End Property

    Private _settingName As String
    Public Property SettingName() As String
        Get
            Return _settingName
        End Get
        Set(ByVal value As String)
            _settingName = value
        End Set
    End Property
    Private _settingSrc As String
    Public Property SettingSrc() As String
        Get
            Return _settingSrc
        End Get
        Set(ByVal value As String)
            _settingSrc = value
        End Set
    End Property
    Private _settingClass As String
    Public Property SettingClass() As String
        Get
            Return _settingClass
        End Get
        Set(ByVal value As String)
            _settingClass = value
        End Set
    End Property
    Private _settingBeskrivning As String
    Public Property SettingBeskrivning() As String
        Get
            Return _settingBeskrivning
        End Get
        Set(ByVal value As String)
            _settingBeskrivning = value
        End Set
    End Property
End Class
