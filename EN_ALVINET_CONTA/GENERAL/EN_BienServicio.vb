Namespace CONFIG


    Public Class EN_BienServicio
        Private _strDescripcion As String
        Public Property Descripcion() As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property

        Private _strIdBienServicio As String
        Public Property IdBienServicio() As String
            Get
                Return _strIdBienServicio
            End Get
            Set(ByVal value As String)
                _strIdBienServicio = value
            End Set
        End Property

        Private _strIdEmpresa As String
        Public Property IdEmpresa() As String
            Get
                Return _strIdEmpresa
            End Get
            Set(ByVal value As String)
                _strIdEmpresa = value
            End Set
        End Property

    End Class
End Namespace