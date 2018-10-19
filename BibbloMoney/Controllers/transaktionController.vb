Imports BibbloMoney

Public Class transaktionController
    Private _Dal As New bibblomoneyTransactionDAL
    Public Function earnevent(earnfunkid As Integer, userid As Integer) As Boolean
        Dim retobj As Boolean = False
        Dim transactionObj As New transactionInfo

        Try
            transactionObj = _Dal.getBMEarnFunc(earnfunkid)
            transactionObj.Userid = userid

            If transactionObj.EarnFuncID > 0 Then
                addLog(transactionObj)

                If transactionObj.Userid > 0 Then
                    retobj = updateBibblomoneyBANK(transactionObj)
                End If

            End If
        Catch ex As Exception
            retobj = False
        End Try
        Return retobj
    End Function

    Private Function updateBibblomoneyBANK(earnObj As transactionInfo) As Boolean
        Dim retobj As Boolean = False
        If earnObj.Userid > 0 Then
            If _Dal.BMIsUserInBank(earnObj.Userid) Then
                retobj = _Dal.BMUpdateToBANK(earnObj)
            Else
                retobj = _Dal.BMAddToBANK(earnObj)
            End If

        End If
        Return retobj
    End Function

    Private Sub addLog(transobj As transactionInfo)
        _Dal.BM_AddToLog(transobj)
    End Sub

#Region "användarens banksaldo"

    Public Function usersaldo(userid As Integer, Optional typ As String = "standard") As bankSaldoInfo
        Dim retobj As New bankSaldoInfo

        If typ = "standard" Then
            retobj = _Dal.BMGetUserSaldoFromBANK(userid)
        Else
            If typ = "standard" Then
                retobj = _Dal.BMGetUserSaldoFromBANK(userid)

            End If
        End If

        Return retobj
    End Function

#End Region
End Class
