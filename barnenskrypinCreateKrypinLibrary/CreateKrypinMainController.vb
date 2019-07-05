Public Class CreateKrypinMainController

    Private _dal As New krypinCreateDAL

    Public Function chkifkrypinExists(userid As Integer) As Boolean

        Return _dal.chkIfKrypinExists(userid)

    End Function

    Public Function CreateNewkrypin(userid As Integer) As Boolean
        Dim retobj As Boolean = False
        Dim newobj As New NyttKrypinDefaultValuesInfo
        newobj.Userid = userid
        Try
            'Skapa krypin och lägg till default settings
            retobj = _dal.CreateNewKrypin(newobj)
            If retobj = True Then

                retobj = _dal.CreateNewKrypinSettings(userid, 1, "33") 'avatar default:id 33, defautlavatar_gubbeGlad.gif

                If retobj = True Then

                    retobj = _dal.CreateNewKrypinSettings(userid, 2, "9") ' skintyp

                    If retobj = True Then

                        retobj = _dal.CreateNewKrypinSettings(userid, 3, "0") ' läser just nu

                    End If
                End If

            End If

        Catch ex As Exception

        End Try
        Return retobj

    End Function


End Class
