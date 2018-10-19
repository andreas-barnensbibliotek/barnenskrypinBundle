Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports KrypinSettings

<TestClass()> Public Class krypinSettingsMainControllerTEST

    Private _obj As New krypinSettingsMainController

    <TestMethod()> Public Sub getusersettingTEST()
        Dim retobj As New ListUserSettingsInfo
        Dim TESTobj As New ListUserSettingsInfo
        Dim cmdobj As New CmdSettingsInfo
        cmdobj.Userid = 7017
        cmdobj.SettingCmdtyp = "get"
        cmdobj.SettingsIdValue = 0
        cmdobj.SettingValue = "0"

        retobj = _obj.KrypinSettings(cmdobj)

        TESTobj = retobj

    End Sub
    <TestMethod()> Public Sub setAvatarsettingTEST()
        Dim retobj As New ListUserSettingsInfo
        Dim TESTobj As New ListUserSettingsInfo
        Dim cmdobj As New CmdSettingsInfo
        cmdobj.Userid = 7017
        cmdobj.SettingCmdtyp = "settings"
        cmdobj.SettingsIdValue = 1
        cmdobj.SettingValue = "23"

        retobj = _obj.KrypinSettings(cmdobj)

        TESTobj = retobj

    End Sub
    <TestMethod()> Public Sub setSkinsettingTEST()
        Dim retobj As New ListUserSettingsInfo
        Dim TESTobj As New ListUserSettingsInfo
        Dim cmdobj As New CmdSettingsInfo
        cmdobj.Userid = 7017
        cmdobj.SettingCmdtyp = "settings"
        cmdobj.SettingsIdValue = 2
        cmdobj.SettingValue = "3"

        retobj = _obj.KrypinSettings(cmdobj)

        TESTobj = retobj

    End Sub

    <TestMethod()> Public Sub setlasernNUTEST()
        Dim retobj As New ListUserSettingsInfo
        Dim TESTobj As New ListUserSettingsInfo
        Dim cmdobj As New CmdSettingsInfo
        cmdobj.Userid = 7017
        cmdobj.SettingCmdtyp = "settings"
        cmdobj.SettingsIdValue = 1
        cmdobj.SettingValue = 17

        retobj = _obj.KrypinSettings(cmdobj)

        TESTobj = retobj

    End Sub

    <TestMethod()> Public Sub uppdaterasettingTEST()
        Dim retobj As New ListUserSettingsInfo
        Dim TESTobj As New ListUserSettingsInfo
        Dim cmdobj As New CmdSettingsInfo

        cmdobj.Userid = 105
        cmdobj.SettingCmdtyp = "updateraSettings"
        cmdobj.SettingsIdValue = 1
        cmdobj.SettingValue = 1

        retobj = _obj.KrypinSettings(cmdobj)

        TESTobj = retobj

    End Sub
End Class