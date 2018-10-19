Imports ajBarnensKrypin_v2.Linq

Public Class krypinCreateDAL

#Region "DATA LINQ SETUP"
    Private connectionObj As New connectionstringHandler
    Private _linqObj As New KrypinCreateLinqDataContext(connectionObj.CurrentConnectionString)
#End Region

    Public Function chkIfKrypinExists(userid As Integer) As Boolean
        Dim retobj As Boolean = False

        Dim testobj = From t In _linqObj.AjKrypinExists(userid)

        If testobj.Count > 0 Then
            retobj = True
        End If
        Return retobj

    End Function

    Public Function CreateNewKrypin(krypinobj As NyttKrypinDefaultValuesInfo) As Boolean

        Dim retobj As Boolean = False

        Try
            Dim b As New tblAJKrypinUserData

            b.UserId = krypinobj.Userid
            b.Avatar = krypinobj.Avatar
            b.BBUserMess = krypinobj.BBMess
            b.KrypinBehorighet = krypinobj.Behorighet
            b.LaserJustnu = krypinobj.Laserjustnu
            b.ValdUserCss = krypinobj.Css
            _linqObj.tblAJKrypinUserDatas.InsertOnSubmit(b)
            _linqObj.SubmitChanges()

            retobj = True
        Catch ex As Exception
            retobj = False
        End Try

        Return retobj

    End Function

    Public Function CreateNewKrypinSettings(userid As Integer, typid As Integer, value As String) As Boolean

        Dim retobj As Boolean = False

        Try
            Dim b As New tblAjKrypinUserSetting

            b.userid = userid
            b.settingTypID = typid
            b.settingValue = value

            _linqObj.tblAjKrypinUserSettings.InsertOnSubmit(b)
            _linqObj.SubmitChanges()

            retobj = True
        Catch ex As Exception
            retobj = False
        End Try

        Return retobj

    End Function
End Class
