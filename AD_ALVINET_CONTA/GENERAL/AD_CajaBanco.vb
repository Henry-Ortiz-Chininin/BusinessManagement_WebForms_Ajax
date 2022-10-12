Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA
Imports System.Data.SqlClient

Namespace GENERAL

    Public Class AD_CajaBanco
#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstCajaBanco As List(Of EN_CajaBanco)
        Private _entCajaBanco As New EN_CajaBanco


        Private _entDepartamento As EN_Departamento
        Private _lstDepartamento As New List(Of EN_Departamento)

        Private _entBase As New EN_Base

#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property
        Public ReadOnly Property lstCajaBanco As List(Of EN_CajaBanco)
            Get
                Return _lstCajaBanco
            End Get
        End Property
        Public Property entCajaBanco As EN_CajaBanco
            Get
                Return _entCajaBanco
            End Get
            Set(ByVal Value As EN_CajaBanco)
                _entCajaBanco = Value
            End Set
        End Property
        Public Property Base() As EN_Base
            Get
                Return _entBase
            End Get
            Set(ByVal value As EN_Base)
                _entBase = value
            End Set
        End Property
        Public Property entDepartamento() As EN_Departamento
            Get
                Return _entDepartamento
            End Get
            Set(ByVal value As EN_Departamento)
                _entDepartamento = value
            End Set
        End Property
        Public ReadOnly Property lstDepartamento() As List(Of EN_Departamento)
            Get
                Return _lstDepartamento
            End Get

        End Property
        Public Property entBase() As EN_Base
            Get
                Return _entBase
            End Get
            Set(ByVal value As EN_Base)
                _entBase = value
            End Set
        End Property

#End Region
#Region "Metodos y Funciones"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_utb_CajaBanco_Registrar"
                _objConexion.AddParameter("var_IdMovimiento", _entCajaBanco.IdMovimiento)
                _objConexion.AddParameter("var_IdEntidadFinanciera", _entCajaBanco.IdEntidadFinanciera)
                _objConexion.AddParameter("var_IdTipoComprobante", _entCajaBanco.IdTipoComprobante)
                _objConexion.AddParameter("var_Comprobante", _entCajaBanco.Comprobante)
                _objConexion.AddParameter("dec_Importe", _entCajaBanco.Importe)
                _objConexion.AddParameter("var_Fecha", _entCajaBanco.Fecha)
                _objConexion.AddParameter("var_IdMoneda", _entCajaBanco.IdMoneda)
                _objConexion.AddParameter("var_Observacion", _entCajaBanco.Observacion)
                _objConexion.AddParameter("var_IdMedioPago", _entCajaBanco.IdMedioPago)
                _objConexion.AddParameter("var_IdCliente", _entCajaBanco.IdCliente)
                _objConexion.AddParameter("var_IdProveedor", _entCajaBanco.IdProveedor)
                _objConexion.AddParameter("var_IdTipoDocumento", _entCajaBanco.IdTipoDocumento)
                _objConexion.AddParameter("var_NumeroDocumento", _entCajaBanco.NumeroDocumento)
                _objConexion.AddParameter("var_IdOperacion", _entCajaBanco.IdOperacion)
                _objConexion.AddParameter("var_IdSubOperacion", _entCajaBanco.IdSubOperacion)
                Base.Salida = _objConexion.EjecutarComandoSalida()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[ERP_utb_Movimiento_Caja_Banco_Eliminar]"
                _objConexion.AddParameter("var_Id", _entCajaBanco.IdMovimiento)
                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try


        End Function

        Public Function Buscar(ByVal pstrFechaInicio As String, ByVal pstrFechFinal As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_utb_CajaBanco_Buscar"
                _objConexion.AddParameter("var_IdMovimiento", _entCajaBanco.IdMovimiento)
                _objConexion.AddParameter("var_IdEntidadFinanciera", _entCajaBanco.IdEntidadFinanciera)
                _objConexion.AddParameter("var_IdTipoComprobante", _entCajaBanco.IdTipoComprobante)
                _objConexion.AddParameter("var_Comprobante", _entCajaBanco.Comprobante)
                _objConexion.AddParameter("var_FechaInicio", pstrFechaInicio)
                _objConexion.AddParameter("var_FechaFinal", pstrFechFinal)
                _objConexion.AddParameter("var_IdMoneda", _entCajaBanco.IdMoneda)
                _objConexion.AddParameter("var_Observacion", _entCajaBanco.Observacion)
                _objConexion.AddParameter("var_IdMedioPago", _entCajaBanco.IdMedioPago)
                _objConexion.AddParameter("var_IdCliente", _entCajaBanco.IdCliente)
                _objConexion.AddParameter("var_IdProveedor", _entCajaBanco.IdProveedor)
                _objConexion.AddParameter("var_IdTipoDocumento", _entCajaBanco.IdTipoDocumento)
                _objConexion.AddParameter("var_NumeroDocumento", _entCajaBanco.NumeroDocumento)
                _objConexion.AddParameter("var_IdOperacion", _entCajaBanco.IdOperacion)
                _objConexion.AddParameter("var_IdSubOperacion", _entCajaBanco.IdSubOperacion)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader
                _lstCajaBanco = New List(Of EN_CajaBanco)
                If Not odrDatos Is Nothing Then

                    While odrDatos.Read
                        _entCajaBanco = New EN_CajaBanco
                        _entCajaBanco.IdMovimiento = odrDatos("var_IdMovimiento")
                        _entCajaBanco.IdEntidadFinanciera = odrDatos("var_IdEntidadFinanciera")
                        _entCajaBanco.IdTipoComprobante = odrDatos("var_IdTipoComprobante")
                        _entCajaBanco.Comprobante = odrDatos("var_Comprobante")
                        _entCajaBanco.Importe = odrDatos("dec_Importe")
                        _entCajaBanco.Fecha = odrDatos("dtm_Fecha")
                        _entCajaBanco.IdMoneda = odrDatos("var_IdMoneda")
                        _entCajaBanco.Observacion = odrDatos("var_Observacion")
                        _entCajaBanco.IdMedioPago = odrDatos("var_IdMedioPago")
                        _entCajaBanco.IdCliente = odrDatos("var_IdCliente")
                        _entCajaBanco.IdProveedor = odrDatos("var_IdProveedor")
                        _entCajaBanco.IdTipoDocumento = odrDatos("var_IdTipoDocumento")
                        _entCajaBanco.NumeroDocumento = odrDatos("var_NumeroDocumento")
                        _entCajaBanco.IdOperacion = odrDatos("var_IdOperacion")
                        _entCajaBanco.IdSubOperacion = odrDatos("var_IdSubOperacion")
                        _lstCajaBanco.Add(_entCajaBanco)
                    End While

                End If
                Return (_lstCajaBanco.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
            Return True

        End Function


        Public Function Listar() As Boolean
            'Try
            '    _objConexion = New AccesoDatosSQLServer
            '    _objConexion.Procedimiento = "[dbo].[ERP_utb_Movimiento_Caja_Banco_Listar]"
            '    _objConexion.AddParameter("int_Criterio", _entBase.CriterioBusqueda)
            '    _objConexion.AddParameter("var_Parametro", _entBase.Parametro)
            '    _objConexion.AddParameter("var_CajaBanco", _entBase.SubParametro)
            '    Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader
            '    _lstCajaBanco = New List(Of EN_CajaBanco)
            '    If Not odrDatos Is Nothing Then

            '        While odrDatos.Read
            '            _entCajaBanco = New EN_CajaBanco
            '            _entCajaBanco.Id = odrDatos("var_Id")
            '            _entCajaBanco.Nombre = odrDatos("var_Nombre")
            '            _entCajaBanco.Numerodoc = odrDatos("var_NumeroDocumento")
            '            _entCajaBanco.Cuenta = odrDatos("var_NumeroCuenta")
            '            _entCajaBanco.Tipo = odrDatos("var_Tipo")
            '            _entCajaBanco.EntidadFinanciera = odrDatos("var_DescripcionEntidad")
            '            _entCajaBanco.IdEntidadFinanciera = odrDatos("var_IdEntidadFinanciera")
            '            _entCajaBanco.Telefono = odrDatos("var_Telefono")
            '            _entCajaBanco.Direccion = odrDatos("var_Direcion")
            '            _entCajaBanco.SobreGiro = odrDatos("var_SobreGiro")
            '            _entCajaBanco.Descripcion = odrDatos("var_DescripcionMoneda")
            '            _entCajaBanco.IdMoneda = odrDatos("var_IdMoneda")
            '            _entCajaBanco.Simbolo = odrDatos("var_Simbolo")
            '            _entCajaBanco.IdDepartamento = odrDatos("var_IdDepartamento")
            '            _entCajaBanco.NomDepartamento = odrDatos("var_NombreDepartamento")
            '            _entCajaBanco.Limite = odrDatos("var_Limite")
            '            _entCajaBanco.Observacion = odrDatos("var_Observacion")
            '            _lstCajaBanco.Add(_entCajaBanco)
            '        End While

            '    End If
            '    Return (_lstCajaBanco.Count > 0)
            'Catch ex As Exception
            '    _objError = ex
            '    Return False
            'End Try
            Return True

        End Function
        Public Function ListarDepartamento() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[ERP_utb_Movimiento_Departamento_Listar]"
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader
                _lstCajaBanco = New List(Of EN_CajaBanco)
                If Not odrDatos Is Nothing Then
                    While odrDatos.Read
                        _entDepartamento = New EN_Departamento
                        _entDepartamento.IdDepartamento = odrDatos("var_Id")
                        _entDepartamento.NomDepartamento = odrDatos("var_Nombre")
                        _lstDepartamento.Add(_entDepartamento)
                    End While
                End If
                Return (_lstDepartamento.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace