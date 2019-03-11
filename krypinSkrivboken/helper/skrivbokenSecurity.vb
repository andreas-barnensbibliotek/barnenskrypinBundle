Public Class skrivbokenSecurity

    Private _dalobj As New skrivbokenDAL
    Private Enum valdtyp
        byuserid = 1
        bycategory = 2
        byskrivid = 3
    End Enum
    Public Function safeuser(valtyp As Integer, cmdtyp As commandTypeInfo) As Boolean
        Dim ret As Boolean = False
        If cmdtyp.Publish = 3 And cmdtyp.Approved = 1 Then
            If (valtyp = valdtyp.byskrivid) Then
                If _dalobj.checkIFuserIsSecureBySkrivID(cmdtyp) Then
                    ret = True
                Else
                    If isuserinAdmin(cmdtyp.Userid) Then
                        ret = True
                    End If
                End If
            Else
                ret = True
            End If

        Else
            Try
                If _dalobj.checkIFuserIsSecure(valtyp, cmdtyp) Then
                    ret = True
                Else
                    If isuserinAdmin(cmdtyp.Userid) Then
                        ret = True
                    End If
                End If

            Catch ex As Exception

            End Try
        End If

        Return ret

    End Function
    Public Function isuserinAdmin(userid As Integer) As Boolean
        Dim ret As Boolean = False
        If _dalobj.checkUserAdminRoll(userid) Then
            ret = True
        Else
            If userid = 1 Then 'host... kolla upp säkrare sätt!!!!
                ret = True
            End If
        End If
        Return ret
    End Function

    Public Function isUserAuthorized(data As skrivItemInfo) As Boolean
        Dim ret As Boolean = False
        Dim tempcmdtyp As New commandTypeInfo
        tempcmdtyp.Skrivid = data.SkrivID
        tempcmdtyp.Userid = data.UserID

        If _dalobj.checkIFuserIsSecure(valdtyp.byskrivid, tempcmdtyp) Then
            ret = True
        Else
            If isuserinAdmin(tempcmdtyp.Userid) Then
                ret = True
            End If
        End If
        Return ret

    End Function
    Public Function isuserloggedIn(userid As Integer) As Boolean
        'OBS ALLWAYS TRUE
        Dim ret As Boolean = True
        If _dalobj.isUserOnline(userid) Then
            ret = True
        End If
        Return ret
    End Function

End Class
