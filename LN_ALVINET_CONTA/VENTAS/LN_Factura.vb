Imports EN_ALVINET_CONTA.VENTAS
Imports AD_ALVINET_CONTA.VENTAS
Imports EN_ALVINET_CONTA.OPERACION



Namespace VENTAS
    Public Class LN_Factura

#Region "Variables"
        Private _objADFactura As New AD_Factura
        Private _objENFactura As New EN_Factura
        Private _objError As New Exception
        Private _lstFacturas As New List(Of EN_Factura)
        Private _entFactura As New EN_ALVINET_CONTA.VENTAS.EN_Factura

#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstfacturas As List(Of EN_Factura)
            Get
                Return _lstFacturas
            End Get
        End Property

        Public Property entFactura As EN_Factura
            Get
                Return _entFactura
            End Get
            Set(ByVal Value As EN_Factura)
                _entFactura = Value
            End Set
        End Property
#End Region

#Region "Metodo y Funciones"
        Public Function Buscar(ByVal enFactura As EN_Factura) As List(Of EN_Factura)

            'If _entFactura.IdComprobante <> "" Then
            '    _objADDatos.entFactura = _entFactura
            '    _objADDatos.Buscar()
            '    _lstFacturas = _objADDatos.lstFacturas
            '    Return (_lstFacturas.Count > 0)
            'Else
            '    Return False
            'End If

            Return _objADFactura.Buscar(enFactura)


        End Function
        Public Function BuscarxId(ByVal enFactura As EN_Factura) As List(Of EN_Factura)
            Return _objADFactura.BuscarxId(enFactura)
        End Function

        Public Function Obtener() As Boolean

            If _entFactura.Correlativo <> "" Then

                _objADFactura.entFactura = _entFactura

                _objADFactura.Obtener()
                _entFactura = _objADFactura.entFactura
                Return (_entFactura.Correlativo <> Nothing)
            Else
                Return False
            End If

            Return False
        End Function

        Public Function Registrar(ByVal dtbAtributos As DataTable) As Boolean

            If entFactura.IdComprobante <> "" Then
                _objADFactura.entFactura = _entFactura
                Return _objADFactura.Registrar(dtbAtributos)
            Else
                Return False
            End If
            'Return False
        End Function

        Public Function Eliminar() As Boolean
            If entFactura.IdComprobante <> "" Then

                _objADFactura.entFactura = _entFactura
                Return _objADFactura.Eliminar()
            Else
                Return False
            End If

            Return False

        End Function

        Public Function ObtenerAtributos() As Boolean

            If _entFactura.NumeroDocumento <> "" Then
                _objADFactura.entFactura = _entFactura
                _objADFactura.ObtenerAtributos(_entFactura)
                _lstFacturas = _objADFactura.lstfacturas
                Return (_lstFacturas.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function MaxID() As Integer
            'If _entFactura.Maximo <> "" Then
            '    _objAD_Factura.entFactura = _entFactura
            '    _objAD_Factura.MaxID(enFactura)
            '    _lstFacturas = _objAD_Factura.lstfacturas
            '    Return (_lstFacturas.Count > 0)
            'Else
            '    Return False
            'End If
            'Return False

            Return _objADFactura.MaxID()
        End Function
        Public Function BuscarArticulos(ByVal enFactura As EN_Factura) As List(Of EN_Factura)

            'If _entFactura.IdComprobante <> "" Then
            '    _objADDatos.entFactura = _entFactura
            '    _objADDatos.BuscarArticulos()
            '    _lstFacturas = _objADDatos.lstFacturas
            '    Return (_lstFacturas.Count > 0)
            'Else
            '    Return False
            'End If
            Return _objADFactura.BuscarArticulos(enFactura)
        End Function


        Public Function BuscarXDocumento() As Boolean

            If _entFactura.IdTipoDocumento <> "" Then
                _objADFactura.entFactura = _entFactura

                If _objADFactura.BuscarXDocumento Then
                    _lstFacturas = _objADFactura.lstfacturas
                End If
                Return (_lstFacturas.Count > 0)
            Else
                Return False
            End If
            Return False
        End Function
        Public Function ActualizarImporte() As Boolean
            _objADFactura.entFactura = _entFactura
            If _objADFactura.ActualizarImporte Then
                Return True
            End If
            Return False

            Return False
        End Function


        Public Function ListarCuenta() As List(Of EN_Factura)

            _objADFactura.entFactura = _entFactura
            Return _objADFactura.ListarCuenta()
        End Function
        Public Function ListarCuentaVenta() As List(Of EN_VoucherCuenta)
            _objADFactura.entFactura = _entFactura
            Return _objADFactura.ListarCuentaVenta()
        End Function

#End Region




    End Class
End Namespace