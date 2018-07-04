
Public Class krypinSkrivbokenMainController

    Private _dalobj As New skrivbokenDAL
    Public Function getSkrivbokByUserid(cmdtyp As commandTypeInfo) As List(Of skrivItemInfo)
        Return _dalobj.getskrivbokByUserid(cmdtyp)
    End Function

    Public Function getSkrivbokByCategory(cmdtyp As commandTypeInfo) As List(Of skrivItemInfo)
        Return _dalobj.getskrivbokByCategory(cmdtyp)
    End Function

    Public Function getSkrivbokBySkrivid(cmdtyp As commandTypeInfo) As List(Of skrivItemInfo)
        Return _dalobj.getskrivbokBySkrivid(cmdtyp.Skrivid)
    End Function

#Region "CRUD"


    Public Function CrudADDskrivboken(data As skrivItemInfo) As String

        Return _dalobj.addTextToSkrivboken(data)

    End Function
    Public Function CrudUpdateAllskrivboken(data As skrivItemInfo) As String
        Dim retStatus As String = "Error in CRUD Command - No Skrivid"

        If data.SkrivID > 0 Then
            retStatus = _dalobj.updateTextSkrivboken(data)
        End If

        Return retStatus
    End Function
    Public Function CrudUpdateApproveskrivboken(data As skrivItemInfo) As String
        Dim retStatus As String = "Error in CRUD Command - No Skrivid"

        If data.SkrivID > 0 Then
            retStatus = _dalobj.updateTextApprovedSkrivboken(data)
        End If

        Return retStatus
    End Function

    Public Function CrudUpdatePublishskrivboken(data As skrivItemInfo) As String
        Dim retStatus As String = "Error in CRUD Command - No Skrivid"

        If data.SkrivID > 0 Then
            retStatus = _dalobj.updateTextPublishStateSkrivboken(data)
        End If

        Return retStatus
    End Function

    Public Function CrudDeleteskrivboken(data As skrivItemInfo) As String
        Dim retStatus As String = "Error in CRUD Command - No Skrivid"

        If data.SkrivID > 0 Then
            retStatus = _dalobj.DeleteTextSkrivboken(data.SkrivID)
        End If

        Return retStatus
    End Function
#End Region

End Class
