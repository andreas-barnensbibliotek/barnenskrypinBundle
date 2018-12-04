Imports barnensbibliotekLibrary35

Public Class krypinSettingsHandler
    Private _dalobj As New SettingsDAL
    Public Function getusersettings2(cmdtyp As CmdSettingsInfo) As ListUserSettingsInfo
        Dim retobj As New ListUserSettingsInfo

        Try
            retobj = _dalobj.getusersettings(cmdtyp.Userid)
            retobj.Status = "Användarens settings hämtades"

        Catch ex As Exception
            retobj.Status = "Error användarens settings hämtades inte!"
        End Try

        Return retobj

    End Function

    Public Function getusersettings(cmdtyp As CmdSettingsInfo) As ListUserSettingsInfo
        Dim retobj As New ListUserSettingsInfo

        Try
            retobj = _dalobj.getusersettings(cmdtyp.Userid)
            retobj.Status = "Användarens settings hämtades"

        Catch ex As Exception
            retobj.Status = "Error användarens settings hämtades inte!"
        End Try

        Return retobj

    End Function
    Public Function getuserlasernu(cmdtyp As CmdSettingsInfo) As ListUserSettingsInfo
        Dim retobj As New ListUserSettingsInfo

        Try
            retobj = _dalobj.getLaserjustnu(cmdtyp.Userid)
            retobj.LaserJustNuSrc = getlaserjustnubyBookid(retobj.LaserJustNu)
            retobj.Status = "Användarens settings hämtades"

        Catch ex As Exception
            retobj.Status = "Error användarens settings hämtades inte!"
        End Try

        Return retobj

    End Function
    Public Function setusersettings(cmdtyp As CmdSettingsInfo) As ListUserSettingsInfo
        Dim retobj As New ListUserSettingsInfo
        Dim tmpstatus As String = "Error " & cmdtyp.SettingCmdtyp & " " & cmdtyp.SettingsIdValue & " uppdaterades inte!"

        Try
            If _dalobj.chkIfSettingItemExist(cmdtyp) = True Then
                If _dalobj.UpdateSettingItem(cmdtyp) Then
                    tmpstatus = cmdtyp.SettingCmdtyp & " " & cmdtyp.SettingsIdValue & " uppdaterades!"
                End If
            Else
                If _dalobj.addSettingItem(cmdtyp) Then
                    tmpstatus = cmdtyp.SettingCmdtyp & " " & cmdtyp.SettingsIdValue & " har lagts till!"
                End If
            End If

        Catch ex As Exception
            tmpstatus = "Error När cmdtyp" & cmdtyp.SettingCmdtyp & " " & cmdtyp.SettingsIdValue & " skulle köras!"
        End Try

        retobj = _dalobj.getusersettings(cmdtyp.Userid)
        retobj.Status = tmpstatus

        Return retobj

    End Function

    Public Function updaterasettings() As String
        Dim retobj As Boolean = False
        Dim rakna As Integer = 0
        Dim failed As Integer = 0
        Dim antalet As Integer = 0

        Dim usersettinglist As List(Of updateSettingInfo) = _dalobj.getUserSettingsToCopy()
        antalet = usersettinglist.Count

        For Each itm In usersettinglist

            retobj = _dalobj.addUpdatesettings(itm)
            If retobj = True Then
                rakna += 1
            Else
                failed += 1
            End If
            retobj = _dalobj.addsettingscss(itm)
            retobj = _dalobj.addsettingslaser(itm)

        Next

        Return "antalkrypin: " & antalet & " klara: " & rakna.ToString & " fel: " & failed.ToString

    End Function
    Private Function getlaserjustnubyBookid(bookid As Integer) As String
        Dim imgobj As New BarnensBiblioteksLibraryController
        Dim bookitem As New APIBarnensbibliotekDAL.BookDetailInfo

        bookitem = imgobj.BookDetailData(bookid)
        Return bookitem.ImgSrc

    End Function
End Class
