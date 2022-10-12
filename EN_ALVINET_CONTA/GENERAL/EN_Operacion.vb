Namespace CONFIG

    Public Class EN_Operacion
        Inherits EN_Ejercicio
#Region "Variables"
        Private _strIdEmpresa As String = ""
        Private _strIdContabilidad As String = ""
        Private _strIdOperacion As String = ""
        Private _strDescripcion As String = ""
        Private _strIdSunat As String = ""
        Private _strCodEmpresa As String = ""
        Private _strCodContabilidad As String = ""
        Private _strFlag As String = ""
#End Region

#Region "Propiedades"

        Public Property Idempresa() As String
            Get
                Return _strIdEmpresa
            End Get
            Set(ByVal value As String)
                _strIdEmpresa = value
            End Set
        End Property

        Public Property IdContabilidad() As String
            Get
                Return _strIdContabilidad
            End Get
            Set(ByVal value As String)
                _strIdContabilidad = value
            End Set
        End Property

        Public Property Flag() As String
            Get
                Return _strFlag
            End Get
            Set(ByVal value As String)
                _strFlag = value
            End Set
        End Property

        Public Property IdOperacion() As String
            Get
                Return _strIdOperacion
            End Get
            Set(ByVal value As String)
                _strIdOperacion = value
            End Set
        End Property


        Public Property IdSunat() As String
            Get
                Return _strIdSunat
            End Get
            Set(ByVal value As String)
                _strIdSunat = value
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

        Public Property codEmpresa() As String
            Get
                Return _strCodEmpresa
            End Get
            Set(ByVal value As String)
                _strCodEmpresa = value
            End Set
        End Property

        Public Property codContabilidad() As String
            Get
                Return _strCodContabilidad
            End Get
            Set(ByVal value As String)
                _strCodContabilidad = value
            End Set
        End Property

#End Region

    End Class
End Namespace