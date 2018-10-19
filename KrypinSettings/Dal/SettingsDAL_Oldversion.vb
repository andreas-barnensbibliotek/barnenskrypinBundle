Public Class SettingsDAL_Oldversion
#Region "DATA LINQ SETUP"
    Private connectionObj As New connectionstringHandler
    Private _linqObj As New KrypinSettingsLinqDataContext(connectionObj.CurrentConnectionString)
#End Region


#Region "Get setting data"
    Public Function getusersettings(userid As Integer) As KrypinUserSettingsInfo
        Dim retobj As New KrypinUserSettingsInfo

        Dim tmpAvatar = New KrypinSettingInfo
        Dim tmpSkin = New KrypinSettingInfo
        Dim tmplaserjustnu = New KrypinSettingInfo

        Dim itm = (From i In _linqObj.AjKrypinGetUserKrypin(userid)).FirstOrDefault()

        retobj.Userid = userid
        retobj.Displaynamn = itm.DisplayName

        tmpAvatar.SettingTypNamn = "Avatar"
        tmpAvatar.CurrentSetting = itm.Avatar
        tmpAvatar.SettingOptionList = getAvatarlist()
        retobj.SettingsList.Add(tmpAvatar)

        tmpSkin.SettingTypNamn = "Skin"
        tmpSkin.CurrentSetting = itm.ValdUserCss
        tmpSkin.SettingOptionList = getSkinlist()
        retobj.SettingsList.Add(tmpSkin)

        tmplaserjustnu.SettingTypNamn = "Laserjustnu"
        tmplaserjustnu.CurrentSetting = itm.LaserJustnu
        retobj.SettingsList.Add(tmplaserjustnu)

        Return retobj

    End Function

    Public Function getAvatarlist() As List(Of krypinSettingItemInfo)
        Dim obj As New List(Of krypinSettingItemInfo)
        Dim items = From i In _linqObj.tblAjKrypinAvatars

        For Each itm In items
            Dim tmp As New krypinSettingItemInfo
            tmp.SettingsID = itm.Avatarid
            tmp.SettingName = itm.Avatarnamn
            tmp.SettingSrc = itm.Avatarsrc
            tmp.SettingBeskrivning = itm.Beskrivning
            obj.Add(tmp)
        Next
        Return obj

    End Function

    Public Function getSkinlist() As List(Of krypinSettingItemInfo)
        Dim obj As New List(Of krypinSettingItemInfo)
        Dim items = From i In _linqObj.tblAJKrypinSkins

        For Each itm In items
            Dim tmp As New krypinSettingItemInfo
            tmp.SettingsID = itm.skinID
            tmp.SettingName = itm.Skinnamn
            tmp.SettingSrc = itm.Skinsrc
            tmp.SettingClass = itm.Skinclass
            obj.Add(tmp)
        Next
        Return obj

    End Function

#End Region

#Region "CRUD funktioner"
    Public Function UpdateAvatar(cmdobj As CmdSettingsInfo) As Boolean
        Dim ret As Boolean = False

        Try
            Dim upd = From e In _linqObj.tblAJKrypinUserDatas
                      Where e.UserId = cmdobj.Userid
                      Select e

            For Each itm In upd
                itm.Avatar = cmdobj.SettingValue
            Next

            _linqObj.SubmitChanges()

            ret = True

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function
    Public Function UpdateSkin(cmdobj As CmdSettingsInfo) As Boolean
        Dim ret As Boolean = False

        Try
            Dim upd = From e In _linqObj.tblAJKrypinUserDatas
                      Where e.UserId = cmdobj.Userid
                      Select e

            For Each itm In upd
                itm.ValdUserCss = cmdobj.SettingsIdValue
            Next

            _linqObj.SubmitChanges()

            ret = True

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function


    Public Function UpdateSettingItem(cmdobj As CmdSettingsInfo) As Boolean
        Dim ret As Boolean = False

        Try
            Dim upd = From e In _linqObj.tblAJKrypinUserDatas
                      Where e.UserId = cmdobj.Userid
                      Select e

            For Each itm In upd

                Select Case cmdobj.SettingCmdtyp.ToLower
                    Case "avatar"
                        itm.Avatar = cmdobj.SettingValue
                    Case "skin"
                        itm.ValdUserCss = cmdobj.SettingsIdValue
                    Case "laserjustnu"
                        itm.LaserJustnu = cmdobj.SettingsIdValue

                End Select
            Next

            _linqObj.SubmitChanges()

            ret = True

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function
#End Region


End Class
