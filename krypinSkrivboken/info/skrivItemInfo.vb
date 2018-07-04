Public Class skrivItemInfo

    Private _SkrivId As Integer
        Public Property SkrivID() As Integer
            Get
                Return _SkrivId
            End Get
            Set(ByVal value As Integer)
                _SkrivId = value
            End Set
        End Property

        Private _UserId As Integer
        Public Property UserID() As Integer
            Get
                Return _UserId
            End Get
            Set(ByVal value As Integer)
                _UserId = value
            End Set
        End Property

        Private _UserName As String
        Public Property UserName() As String
            Get
                Return _UserName
            End Get
            Set(ByVal Value As String)
                _UserName = Value
            End Set
        End Property

        Private _Title As String
        Public Property Title() As String
            Get
                Return _Title
            End Get
            Set(ByVal value As String)
                _Title = value
            End Set
        End Property

        Private _Story As String
        Public Property Story() As String
            Get
                Return _Story
            End Get
            Set(ByVal value As String)
                _Story = value
            End Set
        End Property

        Private _Category As Integer
        Public Property Category() As Integer
            Get
                Return _Category
            End Get
            Set(ByVal value As Integer)
                _Category = value
            End Set
        End Property

        Private _Approved As Integer
        Public Property Approved() As Integer
            Get
                Return _Approved
            End Get
            Set(ByVal value As Integer)
                _Approved = value
            End Set
        End Property

        Private _Gillar As Integer
        Public Property Gillar() As Integer
            Get
                Return _Gillar
            End Get
            Set(ByVal value As Integer)
                _Gillar = value
            End Set
        End Property

        Private _publish As Integer
        Public Property Publish() As Integer
            Get
                Return _publish
            End Get
            Set(ByVal value As Integer)
                _publish = value
            End Set
        End Property

        Private _Inserted As Date
        Public Property Inserted() As Date
            Get
                Return _Inserted
            End Get
            Set(ByVal value As Date)
                _Inserted = value
            End Set
        End Property

End Class