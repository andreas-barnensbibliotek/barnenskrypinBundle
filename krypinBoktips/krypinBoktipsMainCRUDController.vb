Public Class krypinBoktipsMainCRUDController
    Private _dalobj As New CRUDBoktipsDAL

    Public Function getbooktipAll() As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo

        Try
            retobj.Boktips = _dalobj.GetBoktipsALL()
            retobj.Status = "Alla Boktips är hämtade"

        Catch ex As Exception
            retobj.Status = "ERROR Det gick inte att hämta Alla Boktips!"
        End Try

        Return retobj

    End Function

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

    Public Function getbooksToApprove() As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo

        Try
            retobj.Boktips = _dalobj.GetBoktipsApproveList()
            retobj.Status = "Lista på ej godkända boktips är hämtat"

        Catch ex As Exception
            retobj.Status = "ERROR Lista på ej godkända boktips gick inte att hämta!"
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

    Public Function ApproveBooktip(tipid As Integer, value As Integer) As krypinBoktipsInfo
        Dim retobj As New krypinBoktipsInfo

        If value > 1 Or value < 0 Then
            value = 0
        End If

        If _dalobj.ApproveBoktips(tipid, value) Then
            retobj.Status = "Boktipset är ändrat! approve: " & value
        Else
            retobj.Status = "ERROR EDIT Boktips"
        End If

        Return retobj

    End Function
End Class
