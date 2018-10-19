Public Class krypinSettingsMainController
    Public Function KrypinSettings(cmdtyp As CmdSettingsInfo) As ListUserSettingsInfo
        Dim handlerobj As New krypinSettingsHandler
        Dim retobj As New ListUserSettingsInfo

        Select Case cmdtyp.SettingCmdtyp.ToLower
            Case "get"
                retobj = handlerobj.getusersettings(cmdtyp)

            'Case "updaterasettings"
            '    retobj.Status = "uppdaterade: " & handlerobj.updaterasettings()

            Case "settings"
                If cmdtyp.Userid > 0 And cmdtyp.SettingsIdValue > 0 And Not String.IsNullOrEmpty(cmdtyp.SettingValue) Then
                    retobj = handlerobj.setusersettings(cmdtyp)
                Else
                    retobj.Status = "Error anrop saknar inputvalues!"
                End If

        End Select
        Return retobj

    End Function
End Class
