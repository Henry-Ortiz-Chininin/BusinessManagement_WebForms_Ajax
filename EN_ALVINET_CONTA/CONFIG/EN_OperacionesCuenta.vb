
Namespace CONFIG

    Public Class EN_OperacionesCuenta
        Inherits EN_PlanCuenta
#Region "Variables"

        Private _strIdEjercicio As String

        Private _strIdSubOperacion As String = ""
        Private _strSubOperacion As String = ""
        Private _strIdOperacion As String = ""
        Private _strEsCargo As String = ""
        Private _strEsAbono As String = ""
        Private _strEsObligatorio As String = ""
        Private _strObservacion As String = ""
        Private _strFlag As String = ""
        Private _strDesOperacion As String = ""
        Private _strNombre As String = ""
        Private _strTipoMovimiento As String = ""
        Private _strIdOperacionCuenta As String = ""
#End Region

#Region "Propiedades"
        Public Property SubOperacion As String
            Get
                Return _strSubOperacion
            End Get
            Set(ByVal value As String)
                _strSubOperacion = value
            End Set
        End Property
        Public Property IdEjercicio As String
            Get
                Return _strIdEjercicio
            End Get
            Set(ByVal value As String)
                _strIdEjercicio = value
            End Set
        End Property

        Public Property IdOperacionCuenta() As String
            Get
                Return _strIdOperacionCuenta
            End Get
            Set(ByVal value As String)
                _strIdOperacionCuenta = value
            End Set
        End Property
        Public Property Operacion() As String
            Get
                Return _strDesOperacion
            End Get
            Set(ByVal value As String)
                _strDesOperacion = value
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
        Public Property IdSubOperacion As String
            Get
                Return _strIdSubOperacion
            End Get
            Set(ByVal value As String)
                _strIdSubOperacion = value
            End Set
        End Property

        Public Property TipoMovimiento() As String
            Get
                Return _strTipoMovimiento
            End Get
            Set(ByVal value As String)
                _strTipoMovimiento = value
            End Set
        End Property

        Public Property Observacion() As String
            Get
                Return _strObservacion
            End Get
            Set(ByVal value As String)
                _strObservacion = value
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

        Public Property EsCargo() As String
            Get
                Return _strEsCargo
            End Get
            Set(ByVal value As String)
                _strEsCargo = value
            End Set
        End Property

        Public Property EsAbono() As String
            Get
                Return _strEsAbono
            End Get
            Set(ByVal value As String)
                _strEsAbono = value
            End Set
        End Property

        Public Property EsObligatorio() As String
            Get
                Return _strEsObligatorio
            End Get
            Set(ByVal value As String)
                _strEsObligatorio = value
            End Set
        End Property


#End Region


    End Class
End Namespace