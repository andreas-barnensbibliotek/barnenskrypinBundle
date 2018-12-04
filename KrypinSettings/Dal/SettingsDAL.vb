Public Class SettingsDAL
#Region "DATA LINQ SETUP"
    Private connectionObj As New connectionstringHandler
    Private _linqObj As New KrypinSettingsLinqDataContext(connectionObj.CurrentConnectionString)
#End Region


#Region "Get setting data"
    Public Function getusersettings(userid As Integer) As ListUserSettingsInfo
        Dim retobj As New ListUserSettingsInfo

        Dim itm = (From i In _linqObj.AjKrypinGetUserKrypin(userid)).FirstOrDefault()

        retobj.Userid = userid
        retobj.Displaynamn = itm.DisplayName
        retobj.LaserJustNu = getlaserjustnuSetting(userid)
        retobj.SettingsList = getsettingsdetailList(userid)

        Return retobj

    End Function
    Public Function getLaserjustnu(userid As Integer) As ListUserSettingsInfo
        Dim retobj As New ListUserSettingsInfo

        Dim itm = (From i In _linqObj.AjKrypinGetUserKrypin(userid)).FirstOrDefault()

        retobj.Userid = userid
        retobj.Displaynamn = itm.DisplayName
        retobj.LaserJustNu = getlaserjustnuSetting(userid)

        Return retobj

    End Function
    Public Function getsettingsdetailList(userid As Integer) As List(Of KrypinSettingInfo)
        Dim obj As New List(Of KrypinSettingInfo)
        Dim items = From i In _linqObj.tblAjKrypinUserSettings
                    Where i.userid = userid
                    Select i

        For Each itm In items
            Dim tmp As New KrypinSettingInfo
            tmp.SettingsID = itm.settingID
            tmp.SettingUserID = itm.userid
            tmp.SettingValue = itm.settingValue
            tmp.SettingTypID = itm.settingTypID
            tmp.SettingOptionList = SelectSettingsList(itm.settingTypID)
            obj.Add(tmp)
        Next
        Return obj

    End Function


    Public Function getsettingslist(userid As Integer) As List(Of SettingItemInfo)
        Dim obj As New List(Of SettingItemInfo)
        Dim items = From i In _linqObj.tblAjKrypinUserSettings
                    Where i.userid = userid
                    Select i

        For Each itm In items
            Dim tmp As New SettingItemInfo
            tmp.SettingsID = itm.settingID
            tmp.SettingUserID = itm.userid
            tmp.SettingValue = itm.settingValue
            tmp.SettingTypID = itm.settingTypID

            obj.Add(tmp)
        Next
        Return obj

    End Function

    Public Function chkIfSettingItemExist(cmdobj As CmdSettingsInfo) As Boolean
        Dim ret As Boolean = False

        Try
            Dim chk = From e In _linqObj.tblAjKrypinUserSettings
                      Where e.userid = cmdobj.Userid And e.settingTypID = cmdobj.SettingsIdValue
                      Select e

            For Each itm In chk
                ret = True
                Exit For
            Next

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

#End Region
#Region "Full list av settings"
    Public Function SelectSettingsList(val As Integer) As List(Of krypinSettingItemInfo)
        Dim retobj As New List(Of krypinSettingItemInfo)
        Select Case val
            Case 1
                retobj = getAvatarlist()
            Case 2
                retobj = getSkinlist()
        End Select

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
    Public Function addSettingItem(cmdobj As CmdSettingsInfo) As Boolean

        Try
            Dim tblsettings As New tblAjKrypinUserSetting

            tblsettings.userid = cmdobj.Userid
            tblsettings.settingTypID = cmdobj.SettingsIdValue
            tblsettings.settingValue = cmdobj.SettingValue

            _linqObj.tblAjKrypinUserSettings.InsertOnSubmit(tblsettings)
            _linqObj.SubmitChanges()

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function UpdateSettingItem(cmdobj As CmdSettingsInfo) As Boolean
        Dim ret As Boolean = False

        Try
            Dim upd = From e In _linqObj.tblAjKrypinUserSettings
                      Where e.userid = cmdobj.Userid And e.settingTypID = cmdobj.SettingsIdValue
                      Select e

            For Each itm In upd
                itm.settingValue = cmdobj.SettingValue

            Next

            _linqObj.SubmitChanges()

            ret = True

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

#End Region


#Region "uppdate settings on server"
    Public Function getUserSettingsToCopy() As List(Of updateSettingInfo)

        Dim retobj As New List(Of updateSettingInfo)

        Try

            Dim obj = From i In _linqObj.AJKrypin_updateAvatarSetting

            For Each itm In obj
                Dim ny As New updateSettingInfo
                ny.Userid = itm.UserId
                ny.Avatarid = itm.Avatarid
                ny.ValdUserCss = itm.ValdUserCss
                ny.LaserJustnu = itm.LaserJustnu

                retobj.Add(ny)

            Next
            Return retobj
        Catch ex As Exception
            Return retobj
        End Try
    End Function

    Private Function getlaserjustnuSetting(userid As Integer) As Integer
        Dim itm = (From e In _linqObj.tblAjKrypinUserSettings
                   Where e.userid = userid And e.settingTypID = 3
                   Select e).FirstOrDefault()

        Return itm.settingValue

    End Function


    Private Function chkifSettingExist(userid As Integer, settingtyp As Integer) As Boolean
        Dim itm = From e In _linqObj.tblAjKrypinUserSettings
                  Where e.userid = userid And e.settingTypID = settingtyp
                  Select e

        If itm.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function addUpdatesettings(itm As updateSettingInfo) As Boolean

        Try

            If Not chkifSettingExist(itm.Userid, 1) Then
                Dim tblsettings As New tblAjKrypinUserSetting

                tblsettings.userid = itm.Userid
                tblsettings.settingTypID = 1 'avatar
                tblsettings.settingValue = itm.Avatarid

                _linqObj.tblAjKrypinUserSettings.InsertOnSubmit(tblsettings)
                _linqObj.SubmitChanges()
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function addsettingscss(itm As updateSettingInfo) As Boolean

        Try

            If Not chkifSettingExist(itm.Userid, 2) Then
                Dim tblsettings As New tblAjKrypinUserSetting

                tblsettings.userid = itm.Userid
                tblsettings.settingTypID = 2 'styles
                tblsettings.settingValue = itm.ValdUserCss

                _linqObj.tblAjKrypinUserSettings.InsertOnSubmit(tblsettings)
                _linqObj.SubmitChanges()
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function addsettingslaser(itm As updateSettingInfo) As Boolean

        Try

            If Not chkifSettingExist(itm.Userid, 3) Then
                Dim tblsettings As New tblAjKrypinUserSetting

                tblsettings.userid = itm.Userid
                tblsettings.settingTypID = 3 'laserjustnu
                tblsettings.settingValue = itm.LaserJustnu

                _linqObj.tblAjKrypinUserSettings.InsertOnSubmit(tblsettings)
                _linqObj.SubmitChanges()
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function
#End Region
End Class
