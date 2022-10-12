Namespace CONFIG



    Public Class EN_Articulo



#Region "VARIABLES"
        Private _strIdEmpresa As String = ""
        Private _strIdArticulo As String = ""
        Private _strIdSubFamilia As String = ""
        Private _strIdFamilia As String = ""
        Private _strDescripcion As String = ""
        Private _strIdUnidadMedida As String = ""
        Private _strDesUnidadMedida As String = ""
        Private _strEstado As String = ""
        Private _dtbDatos As DataTable
        Private _strUsuario As String = ""
        Private _exError As Exception


#End Region

#Region "PROPIEDADES"
        Public Property IdEmpresa() As String
            Get
                Return _strIdEmpresa
            End Get
            Set(ByVal value As String)
                _strIdEmpresa = value
            End Set
        End Property

        Public Property IdArticulo() As String
            Get
                Return _strIdArticulo
            End Get
            Set(ByVal value As String)
                _strIdArticulo = value
            End Set
        End Property
        Public Property IdSubFamilia() As String
            Get
                Return _strIdSubFamilia
            End Get
            Set(ByVal value As String)
                _strIdSubFamilia = value
            End Set
        End Property

        Public Property IdFamilia() As String
            Get
                Return _strIdFamilia
            End Get
            Set(ByVal value As String)
                _strIdFamilia = value
            End Set
        End Property
        Public Property IdUnidadMedida() As String
            Get
                Return _strIdUnidadMedida
            End Get
            Set(ByVal value As String)
                _strIdUnidadMedida = value
            End Set
        End Property
        Public Property DesUnidadMedida() As String
            Get
                Return _strDesUnidadMedida
            End Get
            Set(ByVal value As String)
                _strDesUnidadMedida = value
            End Set
        End Property

        Public Property Descripcion() As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property

        Public Property Estado() As String
            Get
                Return _strEstado
            End Get
            Set(ByVal value As String)
                _strEstado = value
            End Set
        End Property

        Public Property Datos() As DataTable
            Get
                Return _dtbDatos
            End Get
            Set(ByVal value As DataTable)
                _dtbDatos = value
            End Set
        End Property
        Public Property Usuario() As String
            Get
                Return _strUsuario
            End Get
            Set(ByVal value As String)
                _strUsuario = value
            End Set
        End Property
        Public ReadOnly Property exError() As String
            Get
                Return _exError.ToString
            End Get
        End Property
#End Region

    End Class

End Namespace