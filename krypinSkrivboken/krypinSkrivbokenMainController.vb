
Public Class krypinSkrivbokenMainController

    Private _dalobj As New skrivbokenDAL
    Private _safeobj As New skrivbokenSecurity
    Private Enum valdtyp
        byuserid = 1
        bycategory = 2
        byskrivid = 3
        byadmin = 4
    End Enum

    Public Function getSkrivbokByUserid(cmdtyp As commandTypeInfo) As skrivbokenJsonContainerInfo

        Dim retobj As New skrivbokenJsonContainerInfo

        If _safeobj.safeuser(valdtyp.byuserid, cmdtyp) Then
            Try
                retobj.SkrivbokenList = _dalobj.getskrivbokByUserid(cmdtyp)
                retobj.SkrivbokenListCount = retobj.SkrivbokenList.Count
                retobj.SkrivItemCount = retobj.SkrivbokenListCount
                retobj.Status = "Users item in Skrivboken collected!"
            Catch ex As Exception
                retobj.Status = "ERR Failed to get Users item from Skrivboken!"
            End Try
        Else
            retobj.Status = "User not authorized!"
        End If
        Return retobj

    End Function

    Public Function getSkrivbokByCategory(cmdtyp As commandTypeInfo) As skrivbokenJsonContainerInfo

        Dim retobj As New skrivbokenJsonContainerInfo
        If _safeobj.safeuser(valdtyp.bycategory, cmdtyp) Then
            Try
                retobj.SkrivbokenList = _dalobj.getskrivbokByCategory(cmdtyp)
                retobj.SkrivbokenListCount = retobj.SkrivbokenList.Count
                retobj.SkrivItemCount = retobj.SkrivbokenListCount
                retobj.Status = "Users item by Category is collected!"
            Catch ex As Exception
                retobj.Status = "ERR Failed to get item by Category!"
            End Try
        Else
            retobj.Status = "User not authorized!"
        End If

        Return retobj
    End Function

    Public Function getSkrivbokByAdmin(cmdtyp As commandTypeInfo) As skrivbokenJsonContainerInfo

        Dim retobj As New skrivbokenJsonContainerInfo
        If _safeobj.safeuser(valdtyp.byadmin, cmdtyp) And cmdtyp.Approved > 0 Then
            Try
                If cmdtyp.Approved > 2 Then
                    retobj.SkrivbokenList = _dalobj.getskrivbokenAdminALLA()
                Else
                    retobj.SkrivbokenList = _dalobj.getskrivbokenAdmin(cmdtyp.Approved)
                End If
                retobj.SkrivbokenListCount = retobj.SkrivbokenList.Count
                retobj.SkrivItemCount = retobj.SkrivbokenListCount
                retobj.Status = "Users item by Admin is collected!"
            Catch ex As Exception
                retobj.Status = "ERR Failed to get item by Admin!"
            End Try
        Else
            retobj.Status = "User not authorized!"
        End If

        Return retobj
    End Function


    Public Function getSkrivbokBySkrivid(cmdtyp As commandTypeInfo) As skrivbokenJsonContainerInfo

        Dim retobj As New skrivbokenJsonContainerInfo
        Dim tmpobj As New skrivbokenJsonContainerInfo
        Try
            tmpobj.SkrivbokenList = _dalobj.getskrivbokBySkrivid(cmdtyp.Skrivid)
            tmpobj.SkrivbokenListCount = tmpobj.SkrivbokenList.Count
            tmpobj.SkrivItemCount = tmpobj.SkrivbokenListCount
            tmpobj.Status = "Item by SkrivID is collected!"
        Catch ex As Exception
            retobj.Status = "ERR Failed to get item by SkrivID!"
        End Try
        cmdtyp.Approved = tmpobj.SkrivbokenList.First.Approved
        cmdtyp.Publish = tmpobj.SkrivbokenList.First.Publish
        cmdtyp.Category = tmpobj.SkrivbokenList.First.Category

        If tmpobj.SkrivbokenListCount > 0 Then
            If _safeobj.safeuser(valdtyp.byskrivid, cmdtyp) Then
                retobj = tmpobj
            Else
                retobj.Status = "User not authorized!"
            End If
        Else
            retobj.Status = "Det finns inget att visa"
        End If

        Return retobj
    End Function

#Region "CRUD"
    Public Function CrudADDskrivboken(data As skrivItemInfo) As String
        Dim retStatus As String = "Error in CRUD Command - No ADD"
        If _safeobj.isuserloggedIn(data.UserID) Then
            retStatus = "Item added to skrivboken with skrivid:" & _dalobj.addTextToSkrivboken(data)
        Else
            retStatus = "User not authorized!"
        End If

        Return retStatus
    End Function
    Public Function CrudUpdateAllskrivboken(data As skrivItemInfo) As String
        Dim retStatus As String = "Error in CRUD Command - No Skrivid"

        If data.SkrivID > 0 Then
            If _safeobj.isUserAuthorized(data) Then
                retStatus = _dalobj.updateTextSkrivboken(data)
            Else
                retStatus = "User not authorized!"
            End If
        End If

        Return retStatus
    End Function
    Public Function CrudUpdateApproveskrivboken(data As skrivItemInfo) As String
        Dim retStatus As String = "Error in CRUD Command - No Skrivid"

        If _safeobj.isuserinAdmin(data.UserID) Then 'ENDAST ADMIN FÅR GÖRA DETTA
            If data.SkrivID > 0 Then
                retStatus = _dalobj.updateTextApprovedSkrivboken(data)
            End If
        Else
            retStatus = "User not authorized to approve!"
        End If

        Return retStatus
    End Function

    Public Function CrudUpdatePublishskrivboken(data As skrivItemInfo) As String
        Dim retStatus As String = "Error in CRUD Command - No Skrivid"

        If data.SkrivID > 0 Then
            If _safeobj.isUserAuthorized(data) Then
                retStatus = _dalobj.updateTextPublishStateSkrivboken(data)
            Else
                retStatus = "User not authorized!"
            End If
        End If
        Return retStatus
    End Function

    Public Function CrudDeleteskrivboken(data As skrivItemInfo) As String
        Dim retStatus As String = "Error in CRUD Command - No Skrivid"

        If data.SkrivID > 0 Then

            If _safeobj.isUserAuthorized(data) Then
                retStatus = _dalobj.DeleteTextSkrivboken(data.SkrivID)
            Else
                retStatus = "User not authorized!"
            End If
        End If

        Return retStatus
    End Function
#End Region

End Class
