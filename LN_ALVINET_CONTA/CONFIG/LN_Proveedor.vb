Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG
    Public Class LN_Proveedor
#Region "Variables"
        Private _objADProveedor As New AD_Proveedor
        Private _objError As New Exception
        Private _lstProveedores As List(Of EN_Proveedor)
        Private _entProveedor As New EN_Proveedor
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstProveedores As List(Of EN_Proveedor)
            Get
                Return _lstProveedores
            End Get
        End Property

        Public Property entProveedor As EN_Proveedor
            Get
                Return _entProveedor
            End Get
            Set(ByVal Value As EN_Proveedor)
                _entProveedor = Value
            End Set
        End Property


#End Region
#Region "Metodos y Funciones"

        Public Function Registrar() As Boolean

            If entProveedor.IdEmpresa <> "" AndAlso _
             entProveedor.RazonSocial <> "" AndAlso _
             entProveedor.Ruc <> "" AndAlso _
             entProveedor.Direccion <> "" AndAlso _
             entProveedor.ENacional <> "" AndAlso _
             entProveedor.Retencion <> "" AndAlso _
             entProveedor.Detraccion <> "" AndAlso _
             entProveedor.Telefono <> "" AndAlso _
             entProveedor.DNI <> "" Then

                _objADProveedor.entProveedor = _entProveedor
                Return _objADProveedor.Registrar()

            Else
                Return False
            End If
        End Function

        Public Function Listar() As Boolean

            If entProveedor.IdEmpresa <> "" Then
                _objADProveedor.entProveedor = entProveedor
                _objADProveedor.Listar()
                _lstProveedores = _objADProveedor.lstProveedores
                Return (_lstProveedores.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function Eliminar() As Boolean

            If entProveedor.IdEmpresa <> "" AndAlso _
                entProveedor.IdProveedor <> "" Then

                _objADProveedor.entProveedor = _entProveedor
                Return _objADProveedor.Eliminar()
            Else
                Return False
            End If
        End Function

        Public Function Buscar() As Boolean

            If _entProveedor.IdEmpresa <> "" Then
                _objADProveedor.entProveedor = _entProveedor
                _objADProveedor.Buscar()
                _lstProveedores = _objADProveedor.lstProveedores
                Return (_lstProveedores.Count > 0)
                Return True
            Else
                Return False
            End If



        End Function

#End Region
    End Class
End Namespace