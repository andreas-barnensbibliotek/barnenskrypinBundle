﻿Public Class userActiveQuestlistInfo
    Inherits QuestInfo

    Public Sub New()

    End Sub

    Private newPropertyValue As String
    Public Property NewProperty() As String
        Get
            Return newPropertyValue
        End Get
        Set(ByVal value As String)
            newPropertyValue = value
        End Set
    End Property

End Class
