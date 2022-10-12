Namespace OPERACION

    Public Class EN_OperacionCuenta
        Inherits CONFIG.EN_OperacionesCuenta

        Private _dblImporteDebe As Double
        Private _strIdAsiento As String
        Private _dblImporteHaber As Double
        Private _dblImporteCuenta As Double
        Private _strIdCliente As String
        Private _strIdProveedor As String
        Private _strIdTipoDocumento As String
        Private _strNumeroDocumento As String
        Private _strIdCentroCosto As String
        Private _strIdCuentaGasto As String
        Private _strGlosa As String
        Private _strCuentaEntidad As String
        Private _strIdEntidadFinanciera As String

        Public Property Importe As Double
            Get 
                Return _dblImporteCuenta
            End Get
            Set(ByVal value As Double)
                _dblImporteCuenta = value
                If EsCargo = "S" Then
                    _dblImporteDebe = NumeroDocumento
                End If
                If EsAbono = "S" Then
                    _dblImporteHaber = NumeroDocumento
                End If
            End Set
        End Property
        Public Property ImporteDebe As Double
            Get
                Return _dblImporteDebe
            End Get
            Set(ByVal value As Double)
                _dblImporteDebe = value
            End Set
        End Property

        Public Property ImporteHaber As Double
            Get
                Return _dblImporteHaber
            End Get
            Set(ByVal value As Double)
                _dblImporteHaber = value
            End Set
        End Property

        Public Property Glosa As String
            Get
                Return _strGlosa
            End Get
            Set(ByVal value As String)
                _strGlosa = value
            End Set
        End Property

        Public Property IdCliente As String
            Get
                Return _strIdCliente
            End Get
            Set(ByVal value As String)
                _strIdCliente = value
            End Set
        End Property
        Public Property IdProveedor As String
            Get
                Return _strIdProveedor
            End Get
            Set(ByVal value As String)
                _strIdProveedor = value
            End Set
        End Property
        Public Property IdTipoDocumento As String
            Get
                Return _strIdTipoDocumento
            End Get
            Set(ByVal value As String)
                _strIdTipoDocumento = value
            End Set
        End Property
        Public Property NumeroDocumento As String
            Get
                Return _strNumeroDocumento
            End Get
            Set(ByVal value As String)
                _strNumeroDocumento = value
            End Set
        End Property
        Public Property IdCentroCosto As String
            Get
                Return _strIdCentroCosto
            End Get
            Set(ByVal value As String)
                _strIdCentroCosto = value
            End Set
        End Property
        Public Property IdCuentaGasto As String
            Get
                Return _strIdCuentaGasto
            End Get
            Set(ByVal value As String)
                _strIdCuentaGasto = value
            End Set
        End Property
        Public Property CuentaEntidad As String
            Get
                Return _strCuentaEntidad
            End Get
            Set(ByVal value As String)
                _strCuentaEntidad = value
            End Set
        End Property
        Public Property IdEntidadFinanciera As String
            Get
                Return _strIdEntidadFinanciera
            End Get
            Set(ByVal value As String)
                _strIdEntidadFinanciera = value
            End Set
        End Property
    End Class

End Namespace
