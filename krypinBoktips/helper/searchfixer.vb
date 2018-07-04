Imports System.Text
Public Class searchfixer

    Public Function searchStringFixer(incstr As String) As String

        Dim str As New StringBuilder("%")

        If incstr.Length >= 4 Then
            str.Append(incstr.Substring(0, incstr.Length - 1))

        Else
            str.Append(incstr)

        End If

        str.Append("%")
        str.Replace(" ", "%")

        Return str.ToString

    End Function
End Class
