Public Class KrypinSettingInfo
    Inherits SettingItemInfo

    Private _settingsOptionList As List(Of krypinSettingItemInfo)
    Public Property SettingOptionList() As List(Of krypinSettingItemInfo)
        Get
            Return _settingsOptionList
        End Get
        Set(ByVal value As List(Of krypinSettingItemInfo))
            _settingsOptionList = value
        End Set
    End Property
End Class
