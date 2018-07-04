Public Class krypinBoktipsMainCRUDController
    Private _dalobj As New CRUDBoktipsDAL


    Public Function getbooktip(tipid As Integer) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo

        Try
            retobj.Boktips.Add(_dalobj.GetBoktips(tipid))
            retobj.Status = "Boktips id:" & tipid & " är hämtat"

        Catch ex As Exception
            retobj.Status = "ERROR Boktips id:" & tipid & " gick inte att hämta!"
        End Try

        Return retobj

    End Function

    Public Function addbooktip(newbooktip As boktipsInfo) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo

        If _dalobj.AddBoktips(newbooktip) Then
            retobj.Status = "Boktipset är inlagt!"
        Else
            retobj.Status = "ERROR ADD Boktips"
        End If

        Return retobj

    End Function

    Public Function editbooktip(booktip As boktipsInfo) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo

        If _dalobj.EditBoktips(booktip) Then
            retobj.Status = "Boktipset är ändrat!"
        Else
            retobj.Status = "ERROR EDIT Boktips"
        End If

        Return retobj

    End Function

    Public Function deletebooktip(booktip As boktipsInfo) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo

        If _dalobj.DeleteBoktips(booktip.TipID) Then
            retobj.Status = "Boktipset är nu borttaget!"
        Else
            retobj.Status = "ERROR DELETE Boktips"
        End If

        Return retobj

    End Function
End Class
