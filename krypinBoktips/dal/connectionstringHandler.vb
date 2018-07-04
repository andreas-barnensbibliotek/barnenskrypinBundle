Public Class connectionstringHandler

    Private _connectionstring As String

    Public Sub New()
        _connectionstring = "Data Source=.\SQLEXPRESS;Initial Catalog=AJDNNDatabase_v5;Persist Security Info=True;User ID=forfAdmin2;Password=Barnbib1;"
        '_connectionString = "Data Source=DE-1896;Initial Catalog=kulturkatalogenDB_DEV;User ID=kulturkatalogenDB;Password=L0rda1f"
    End Sub
    Public ReadOnly Property CurrentConnectionString() As String
        Get
            Return _connectionstring
        End Get

    End Property

End Class
