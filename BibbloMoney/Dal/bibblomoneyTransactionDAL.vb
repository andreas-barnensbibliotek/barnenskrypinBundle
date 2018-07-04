Public Class bibblomoneyTransactionDAL

#Region "DATA LINQ SETUP"
    Private connectionObj As New connectionstringHandler
    Private _linqObj As New bibblomoneyLinqDataContext(connectionObj.CurrentConnectionString)
#End Region

    Public Function getBMEarnFunc(earnid As Integer) As transactionInfo
        Dim retobj As New transactionInfo
        Try
            Dim earnObj = (From t In _linqObj.AJBibbloMoneyGetEarnFunction(earnid)
                           Select t).FirstOrDefault()


            retobj.EarnFuncID = earnObj.EarnfuncID
            retobj.Amount = earnObj.bibmoney
            retobj.Bonus = earnObj.bonusX
            retobj.Beskrivning = earnObj.EarnFunctionName

        Catch ex As Exception
            retobj.Beskrivning = "ERROR getBMEarnFunc"
        End Try

        Return retobj

    End Function

    Public Function BMAddToBANK(bmBankObj As transactionInfo) As Boolean
        Dim tmpObj As New tblAJ_Bank
        Try

            With tmpObj
                .Bibmoney = (bmBankObj.Amount * bmBankObj.Bonus)
                .beskrivning = bmBankObj.Beskrivning
                .bankUserid = bmBankObj.Userid

            End With

            _linqObj.tblAJ_Banks.InsertOnSubmit(tmpObj)
            _linqObj.SubmitChanges()

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function BMUpdateToBANK(bmBankObj As transactionInfo) As Boolean
        Dim ret As Boolean = False
        Try
            Dim upd = From i In _linqObj.tblAJ_Banks
                      Where i.bankUserid = bmBankObj.Userid
                      Select i

            For Each bankObj In upd
                bankObj.Bibmoney += bmBankObj.Amount
                bankObj.Beskrivning = bmBankObj.Beskrivning

            Next

            _linqObj.SubmitChanges()
            ret = True

        Catch ex As Exception
            ret = False
        End Try

        Return ret

    End Function

    Public Function BMIsUserInBank(userid As Integer) As Boolean
        Dim retobj As Boolean = False

        Dim bankObj = From i In _linqObj.tblAJ_Banks
                      Where i.bankUserid = userid

        Try
            For Each x In bankObj
                retobj = True
                Exit For
            Next

        Catch
            retobj = False
        End Try

        Return retobj

    End Function


    Public Function BM_AddToLog(logobj As transactionInfo) As Boolean
        Dim tmpObj As New tblAJ_bibblimoneyEarnedLog
        Try

            With tmpObj
                .amount = logobj.Amount
                .beskrivning = logobj.Beskrivning
                .EarnfuncID = logobj.EarnFuncID
                .userid = logobj.Userid
                .loggdate = Date.Now
                .timestamp = Date.Now
            End With

            _linqObj.tblAJ_bibblimoneyEarnedLogs.InsertOnSubmit(tmpObj)
            _linqObj.SubmitChanges()

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class
