Public Class skrivbokenDAL

    Private connectionObj As New connectionstringHandler
    Private _linqObj As New skrivbokenLinqDataContext(connectionObj.CurrentConnectionString)

    Public Function getskrivbokByUserid(cmdtyp As commandTypeInfo) As List(Of skrivItemInfo)
        ' cmdtyp.getpublishTyp 1 = hämtar användarens data (userid requred) som är antingen approved 1(default) el 0 och
        '                   publicerad 1,2 privat el 3 publik(default)
        ' cmdtyp.getpublishTyp 2 = hämtar användarens data (userid requred) oavsett om den är approved eller ej eller vilken publish den är

        Dim tmpobj As New List(Of skrivItemInfo)
        Dim arr = From p In _linqObj.AJ_BB_Krypin_skrivbok_byUserid(cmdtyp.GetPublishTyp, cmdtyp.Userid, cmdtyp.Approved, cmdtyp.Publish)
                  Select p

        For Each t In arr
            tmpobj.Add(fyllskrivobj(t))
        Next

        If tmpobj.Count <= 0 Then
            Dim noresult As New skrivItemInfo
            noresult.Title = "Finns inget att visa"
            tmpobj.Add(noresult)
        End If

        Return tmpobj

    End Function

    Public Function getskrivbokByCategory(cmdtyp As commandTypeInfo) As List(Of skrivItemInfo)
        ' cmdtyp.category hämtar vald kategori som är antingen approved 1(default) el 0 och
        '                   publicerad 1,2 privat el 3 publik(default)

        Dim tmpobj As New List(Of skrivItemInfo)
        Dim arr = From p In _linqObj.AJ_BB_Krypin_skrivbok_byCategory(cmdtyp.Category, cmdtyp.Approved, cmdtyp.Publish)
                  Select p

        For Each t In arr
            tmpobj.Add(fyllskrivobj(t))
        Next

        If tmpobj.Count <= 0 Then
            Dim noresult As New skrivItemInfo
            noresult.Title = "Finns inget att visa"
            tmpobj.Add(noresult)
        End If

        Return tmpobj

    End Function

    Public Function getskrivbokBySkrivid(skrivid As Integer) As List(Of skrivItemInfo)

        Dim tmpobj As New List(Of skrivItemInfo)
        Dim arr = From p In _linqObj.AJ_BB_Krypin_skrivbok_bySkrivID(skrivid)
                  Select p

        For Each t In arr
            tmpobj.Add(fyllskrivobj(t))
        Next

        If tmpobj.Count <= 0 Then
            Dim noresult As New skrivItemInfo
            noresult.Title = "Finns inget att visa"
            tmpobj.Add(noresult)
        End If

        Return tmpobj

    End Function

#Region "CRUD"
    'ADD
    Public Function addTextToSkrivboken(data As skrivItemInfo) As Integer
        Try
            Dim maindata As New tblAJBarnensSkriv
            With maindata
                .Approved = data.Approved
                .Category = data.Category
                .Gillar = data.Gillar
                .publish = data.Publish
                .Inserted = Date.Now
                .Story = data.Story
                .Title = data.Title
                .Userid = data.UserID

            End With

            _linqObj.tblAJBarnensSkrivs.InsertOnSubmit(maindata)
            _linqObj.SubmitChanges()

            Return maindata.SkrivID
        Catch ex As Exception
            Return 0
        End Try
    End Function

    'UPDATE
    Public Function updateTextSkrivboken(data As skrivItemInfo) As String
        Dim ret As String = "ERROR Inget skrivID angivet"

        Try
            Dim upd = From e In _linqObj.tblAJBarnensSkrivs
                      Where e.SkrivID = data.SkrivID
                      Select e

            If upd.Count > 0 Then
                For Each itm In upd
                    With itm
                        .Approved = data.Approved
                        .Category = data.Category
                        .Gillar = data.Gillar
                        .publish = data.Publish
                        .Story = data.Story
                        .Title = data.Title
                        .Userid = data.UserID

                    End With
                Next
                ret = "Success - Update skrivboken All!"
            End If
            _linqObj.SubmitChanges()

        Catch ex As Exception
            ret = "ERROR - Update skrivboken All!"
        End Try

        Return ret
    End Function
    ' approved
    Public Function updateTextApprovedSkrivboken(data As skrivItemInfo) As String
        Dim ret As String = "ERROR Inget skrivID angivet"

        Try
            Dim upd = From e In _linqObj.tblAJBarnensSkrivs
                      Where e.SkrivID = data.SkrivID
                      Select e
            If upd.Count > 0 Then

                For Each itm In upd
                    itm.Approved = data.Approved
                Next
                ret = "Success - Update skrivboken Text Approved!"
            End If
            _linqObj.SubmitChanges()

        Catch ex As Exception
            ret = "ERROR - Update skrivboken Text Approved!"
        End Try

        Return ret
    End Function
    ' approved
    Public Function updateTextPublishStateSkrivboken(data As skrivItemInfo) As String
        Dim ret As String = "ERROR Inget skrivID angivet"

        Try
            Dim upd = From e In _linqObj.tblAJBarnensSkrivs
                      Where e.SkrivID = data.SkrivID
                      Select e
            If upd.Count > 0 Then
                For Each itm In upd
                    itm.publish = data.Publish
                Next
                ret = "Success - Update skrivboken Text Publish!"
            End If
            _linqObj.SubmitChanges()

        Catch ex As Exception
            ret = "ERROR - Update skrivboken Text Publish!"
        End Try

        Return ret
    End Function
    'DELETE
    Public Function DeleteTextSkrivboken(skrivid As Integer) As String
        Dim ret As String = ""
        Try
            Dim itm = From c In _linqObj.tblAJBarnensSkrivs
                      Where c.SkrivID = skrivid
                      Select c


            _linqObj.tblAJBarnensSkrivs.DeleteAllOnSubmit(itm)
            _linqObj.SubmitChanges()
            ret = "Success - Skrivboken text DELETED"


        Catch ex As Exception
            ret = "ERROR - Skrivboken text DELETED"
        End Try

        Return ret
    End Function

#End Region

    Private Function fyllskrivobj(t As Object) As skrivItemInfo
        Dim skrivobj As New skrivItemInfo
        skrivobj.SkrivID = t.SkrivID
        skrivobj.UserID = t.UserID
        skrivobj.UserName = t.UserName
        skrivobj.Inserted = t.Inserted
        skrivobj.Title = t.Title
        skrivobj.Story = t.Story
        skrivobj.Category = t.Category
        skrivobj.Approved = t.Approved
        skrivobj.Gillar = t.Gillar
        skrivobj.Publish = t.Publish

        Return skrivobj
    End Function
End Class
