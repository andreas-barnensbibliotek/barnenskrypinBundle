Public Class CmdSettingsInfo

    Public Sub New()
        _userid = 0
        _settingcmdtyp = ""
        _settingIdValue = 0
        _settingValue = ""

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

    Private _settingcmdtyp As String
    Public Property SettingCmdtyp() As String
        Get
            Return _settingcmdtyp
        End Get
        Set(ByVal value As String)
            _settingcmdtyp = value
        End Set
    End Property

    Private _settingIdValue As Integer
    Public Property SettingsIdValue() As Integer
        Get
            Return _settingIdValue
        End Get
        Set(ByVal value As Integer)
            _settingIdValue = value
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
