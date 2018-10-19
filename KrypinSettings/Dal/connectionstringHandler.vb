Public Class connectionstringHandler

    Private _connectionstring As String

    Public Sub New()
        '_connectionstring = "Data Source=.\SQLEXPRESS;Initial Catalog=AJDNNDatabase_v5;Persist Security Info=True;User ID=forfAdmin2;Password=Barnbib1;"
        _connectionstring = "Data Source=DE-2697;Initial Catalog=AJDNNDatabase;User ID=forfAdmin2;Password=Barnbib1;"
    End Sub
    Public ReadOnly Property CurrentConnectionString() As String
        Get
            Return _connectionstring
        End Get

    End Property

End Class
