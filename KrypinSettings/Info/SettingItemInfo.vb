Public Class SettingItemInfo

    Public Sub New()
        _settingID = 0
        _settingUserid = 0
        _settingTypID = 0
        _settingValue = ""
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

    Private _settingUserid As Integer
    Public Property SettingUserID() As Integer
        Get
            Return _settingUserid
        End Get
        Set(ByVal value As Integer)
            _settingUserid = value
        End Set
    End Property
    Private _settingTypID As Integer
    Public Property SettingTypID() As Integer
        Get
            Return _settingTypID
        End Get
        Set(ByVal value As Integer)
            _settingTypID = value
        End Set
    End Property
    Private _settingValue As String
    Public Property SettingValue() As String
        Get
            Return _settingValue
        End Get
        Set(ByVal value As String)
            _settingValue = value
        End Set
    End Property
End Class
