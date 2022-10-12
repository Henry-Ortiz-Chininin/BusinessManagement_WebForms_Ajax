Imports EN_ALVINET_CONTA.OPERACION
Imports AD_ALVINET_CONTA.OPERACION

Namespace OPERACION
    Public Class LN_OrdenServicio
#Region "Variables"
        Private _objConexion As AD_OrdenServicio
        Private _objError As New Exception
        Private _lstDatos As List(Of EN_OrdenServicio)
        Private _entDato As New EN_OrdenServicio
#End Region

        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstDatos As List(Of EN_OrdenServicio)
            Get
                Return _lstDatos
            End Get
        End Property

        Public Property entDato As EN_OrdenServicio
            Get
                Return _entDato
            End Get
            Set(ByVal Value As EN_OrdenServicio)
                _entDato = Value
            End Set
        End Property

#Region "Metodos y Funciones "
        Public Sub New()
            _entDato = New EN_OrdenServicio

        End Sub
        Public Function Registrar() As Boolean
            Dim _bolValidar As Boolean = True
            If _entDato.FechaEmision = "" Then
                _objError = New Exception("Falta fecha emisión, ")
                _entDato.Mensaje += " - Falta fecha emisión \n"
                _bolValidar = False
            End If
            If _entDato.IdDepartamento = "" Then
                _objError = New Exception("Seleccionar departamento, ")
                entDato.Mensaje += " - Seleccionar departamento \n"
                _bolValidar = False
            End If
            If _entDato.IdCliente = "" Then
                _objError = New Exception("Falta Cliente, ")
                entDato.Mensaje += " - Falta Cliente \n"
                _bolValidar = False
            End If
            If _entDato.LugarOperacion = "" Then
                _objError = New Exception("Falta lugar operación, ")
                entDato.Mensaje += " - Falta lugar operación \n"
                _bolValidar = False
            End If
            If _entDato.TrabaSolicitante = "" Then
                _objError = New Exception("Falta trabajo solicitado, ")
                entDato.Mensaje += " - Falta trabajo solicitado \n"
                _bolValidar = False
            End If
            If _entDato.Telefono = "" Then
                _objError = New Exception("Falta telefono, ")
                entDato.Mensaje += " - Falta telefono \n"
                _bolValidar = False
            End If
            If _entDato.TrabajoEfectuado = "" Then
                _objError = New Exception("Falta trabajo efectuado, ")
                entDato.Mensaje += " - Falta trabajo efectuado \n"
                _bolValidar = False
            End If
            If _entDato.Operador = "" Then
                _objError = New Exception("Falta operador")
                entDato.Mensaje += " - Falta operador \n"
                _bolValidar = False
            End If
            If _entDato.Riger = "" Then
                _objError = New Exception("Falta riger, ")
                entDato.Mensaje += " - Falta riger \n"
                _bolValidar = False
            End If
            If _entDato.Ayudante = "" Then
                _objError = New Exception("Falta ayudante, ")
                entDato.Mensaje += " - Falta ayudante \n"
                _bolValidar = False
            End If
            If _entDato.TarifaHora <= 0 Then
                _objError = New Exception("Falta tarifa, ")
                entDato.Mensaje += " - Falta tarifa \n"
                _bolValidar = False
            End If
            If _entDato.TiempoFacturar <= 0 Then
                _objError = New Exception("Tiempos no validos, ")
                entDato.Mensaje += " - Tiempos no validos \n"
                _bolValidar = False
            End If
            If _entDato.Placa_Grua = "" Then
                _objError = New Exception("Falta placa grua, ")
                entDato.Mensaje += " - Falta placa grua \n"
                _bolValidar = False
            End If
            If _entDato.TipoServicio = "" Then
                _objError = New Exception("Seleccionar tipo de servicio,")
                entDato.Mensaje += " - Seleccionar tipo de servicio \n"
                _bolValidar = False
            End If
            If _entDato.Estado = "" Then
                _objError = New Exception("Seleccionar estado, ")
                entDato.Mensaje += " - Seleccionar estado \n"
                _bolValidar = False
            End If
            If _entDato.IdMoneda = "" Then
                _objError = New Exception("Seleccionar moneda, ")
                entDato.Mensaje += " - Seleccionar moneda \n"
                _bolValidar = False
            End If
            If _bolValidar Then
                _objConexion = New AD_ALVINET_CONTA.OPERACION.AD_OrdenServicio
                _objConexion.entDato = _entDato
                Return _objConexion.Registrar()
            Else
                Return False
            End If
        End Function

        Public Function Buscar() As Boolean
            _objConexion = New AD_OrdenServicio
            _objConexion.entDato = _entDato
            If _objConexion.Buscar() = True Then
                _lstDatos = _objConexion.lstDatos
                Return (_lstDatos.Count > 0)
            Else
                Return False
            End If
        End Function

#End Region


    End Class
End Namespace

