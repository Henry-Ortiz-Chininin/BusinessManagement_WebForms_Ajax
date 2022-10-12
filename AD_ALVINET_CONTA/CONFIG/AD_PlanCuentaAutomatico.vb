Imports EN_ALVINET_CONTA
Imports AD_ALVINET_CONTA.AccesoDatos
Imports System.Data.SqlClient

Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data


Public Class AD_PlanCuentaAutomatico
#Region "Variables"


    Private _entPlanCuentaAutomatico As EN_PanCuentaAutomatico
    Private _objError As New Exception
    Private _objConexion As AccesoDatosSQLServer
    Private _lstPlanCuentaautomatico As New List(Of EN_PanCuentaAutomatico)



#End Region
#Region "Propiedades"
    Public Property objError() As Exception
        Get
            Return _objError
        End Get
        Set(ByVal value As Exception)
            _objError = value
        End Set
    End Property
    Public ReadOnly Property lstPlanCuentaautomatico() As List(Of EN_PanCuentaAutomatico)
        Get
            Return _lstPlanCuentaautomatico
        End Get

    End Property
    Public Property entPlanCuentaAutomatico() As EN_PanCuentaAutomatico
        Get
            Return _entPlanCuentaAutomatico
        End Get
        Set(ByVal value As EN_PanCuentaAutomatico)
            _entPlanCuentaAutomatico = value
        End Set
    End Property

#End Region
#Region "Metodos y Funciones"
    Public Function Registrar() As Boolean
        Try
            _objConexion = New AccesoDatosSQLServer
            _objConexion.Procedimiento = "ERP_usp_PlancuantaAutomatico_Registrar"
            _objConexion.AddParameter("var_IdOperacion", _entPlanCuentaAutomatico.IdOperacion.ToString())
            _objConexion.AddParameter("var_IdCuenta", _entPlanCuentaAutomatico.IdCuenta.ToString())
            _objConexion.AddParameter("var_Nombre", _entPlanCuentaAutomatico.Nombre.ToString())
            _objConexion.EjecutarComando()
            Return True
        Catch ex As Exception
            _objError = ex
            Return False
        End Try
    End Function


    Public Function Eliminar() As Boolean
        Try
            _objConexion = New AccesoDatosSQLServer
            _objConexion.Procedimiento = "ERP_usp_PlancuantaAutomatico_Eliminar"
            _objConexion.AddParameter("var_IdCuenta", _entPlanCuentaAutomatico.IdCuenta)
            _objConexion.AddParameter("var_IdOperacion", _entPlanCuentaAutomatico.IdOperacion)
            _objConexion.EjecutarComando()
            Return True
        Catch ex As Exception
            _objError = ex
            Return False
        End Try


    End Function
    Public Function Listar2() As Boolean
        Try

            _objConexion = New AccesoDatosSQLServer
            _objConexion.Procedimiento = "ERP_usp_PlancuantaAutomatico_Listar"
            '_objConexion.AddParameter("var_Id", _entPlanCuentaAutomatico.IdPlanCuentaAutomatico)
            Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

            _lstPlanCuentaautomatico = New List(Of EN_PanCuentaAutomatico)
            While odrDatos.Read
                _entPlanCuentaAutomatico = New EN_PanCuentaAutomatico

                _entPlanCuentaAutomatico.IdPlanCuentaAutomatico = odrDatos("var_Id")
                _entPlanCuentaAutomatico.Nombre = odrDatos("var_Nombre")
                _entPlanCuentaAutomatico.IdCuenta = odrDatos("var_IdCuenta")
                _entPlanCuentaAutomatico.IdOperacion = odrDatos("var_IdOperacion")
                _entPlanCuentaAutomatico.Descripcion = odrDatos("var_Descripcion")


                _lstPlanCuentaautomatico.Add(_entPlanCuentaAutomatico)
            End While

            Return (_lstPlanCuentaautomatico.Count > 0)
        Catch ex As Exception
            _objError = ex
            Return False
        End Try
    End Function
    Public Function Buscar() As Boolean
        Try
            _objConexion = New AccesoDatosSQLServer
            _objConexion.Procedimiento = "ERP_usp_PlancuantaAutomatico_Buscar"
            _objConexion.AddParameter("tipo", _entPlanCuentaAutomatico.Tipo)
            _objConexion.AddParameter("var_IdCuenta", _entPlanCuentaAutomatico.IdCuenta)
            _objConexion.AddParameter("var_Nombre", _entPlanCuentaAutomatico.Nombre)
            _objConexion.EjecutarComando()

            Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

            _lstPlanCuentaautomatico = New List(Of EN_PanCuentaAutomatico)

            While odrDatos.Read

                _entPlanCuentaAutomatico = New EN_PanCuentaAutomatico


                _entPlanCuentaAutomatico.IdCuenta = odrDatos("var_IdCuenta")
                _entPlanCuentaAutomatico.Nombre = odrDatos("var_Nombre")


                _lstPlanCuentaautomatico.Add(_entPlanCuentaAutomatico)
            End While

            Return (_lstPlanCuentaautomatico.Count > 0)
        Catch ex As Exception

            _objError = ex
            Return False

        End Try
    End Function



    Public Function Listar() As Boolean
        Try
            _objConexion = New AccesoDatosSQLServer
            _objConexion.Procedimiento = "dbo.ERP_usp_PlanCuenta_Automatico_Listar"
            _objConexion.AddParameter("var_IdSubOperacion", _entPlanCuentaAutomatico.IdSubOperacion)
            Dim odrdatos As SqlDataReader = _objConexion.ObtenerDataReader

            If Not odrdatos Is Nothing Then

                While odrdatos.Read
                    _entPlanCuentaAutomatico = New EN_PanCuentaAutomatico
                    _entPlanCuentaAutomatico.IdCuenta = odrdatos("var_IdCuenta")
                    _entPlanCuentaAutomatico.IdOperacion = odrdatos("var_IdOperacion")
                    _entPlanCuentaAutomatico.Nombre = odrdatos("var_Nombre")
                    _entPlanCuentaAutomatico.IdOperacionCuenta = odrdatos("var_IdOperacionCuenta")
                    _lstPlanCuentaautomatico.Add(_entPlanCuentaAutomatico)

                End While

            End If
            Return (_lstPlanCuentaautomatico.Count > 0)
        Catch ex As Exception
            _objError = ex
            Return False
        End Try


    End Function
    Public Function DiferenciaListar() As Boolean
        Try
            _objConexion = New AccesoDatosSQLServer
            _objConexion.Procedimiento = "[dbo].[ERP_usp_PlanCuenta_Buscar_Automatico]"
            _objConexion.AddParameter("var_IdCuenta", _entPlanCuentaAutomatico.IdCuenta)
            Dim odrdatos As SqlDataReader = _objConexion.ObtenerDataReader

            If Not odrdatos Is Nothing Then

                While odrdatos.Read
                    _entPlanCuentaAutomatico = New EN_PanCuentaAutomatico
                    _entPlanCuentaAutomatico.IdCuenta = odrdatos("var_IdCuenta")
                    _entPlanCuentaAutomatico.Cuenta = odrdatos("var_DiferenciaCambio")
                    _entPlanCuentaAutomatico.Descripcion = odrdatos("Descripcion")
                    _lstPlanCuentaautomatico.Add(_entPlanCuentaAutomatico)

                End While

            End If
            Return (_lstPlanCuentaautomatico.Count > 0)
        Catch ex As Exception
            _objError = ex
            Return False
        End Try


    End Function
    Public Function MovimientoListar() As Boolean
        Try
            _objConexion = New AccesoDatosSQLServer
            _objConexion.Procedimiento = "[dbo].[ERP_usp_Asientos_Buscar]"
            _objConexion.AddParameter("var_Movimiento", _entPlanCuentaAutomatico.IdSubOperacion)
            Dim odrdatos As SqlDataReader = _objConexion.ObtenerDataReader

            If Not odrdatos Is Nothing Then

                While odrdatos.Read
                    _entPlanCuentaAutomatico = New EN_PanCuentaAutomatico
                    _entPlanCuentaAutomatico.IdCuenta = odrdatos("var_IdCuenta")
                    _entPlanCuentaAutomatico.IdOperacion = odrdatos("var_IdOperacion")
                    _entPlanCuentaAutomatico.Nombre = odrdatos("var_Nombre")
                    _entPlanCuentaAutomatico.IdOperacionCuenta = odrdatos("var_IdOperacionCuenta")

                    _lstPlanCuentaautomatico.Add(_entPlanCuentaAutomatico)

                End While

            End If
            Return (_lstPlanCuentaautomatico.Count > 0)
        Catch ex As Exception
            _objError = ex
            Return False
        End Try


    End Function
    Public Function BuscarGenerado() As Boolean
        Try
            _objConexion = New AccesoDatosSQLServer
            _objConexion.Procedimiento = "[dbo].[ERP_usp_AsientoAutomatico_Listar]"
            _objConexion.AddParameter("var_IdBanco", _entPlanCuentaAutomatico.IdBanco)
            _objConexion.AddParameter("var_IdCaja", _entPlanCuentaAutomatico.IdCaja)
            Dim odrdatos As SqlDataReader = _objConexion.ObtenerDataReader

            If Not odrdatos Is Nothing Then

                While odrdatos.Read
                    _entPlanCuentaAutomatico = New EN_PanCuentaAutomatico
                    _entPlanCuentaAutomatico.Id = odrdatos("var_Id")


                    _entPlanCuentaAutomatico.Cargo = odrdatos("var_EsCargo")

                    If _entPlanCuentaAutomatico.Cargo = "D" Then
                        _entPlanCuentaAutomatico.EsCargo = odrdatos("dec_Importe")
                        _entPlanCuentaAutomatico.EsAbono = ""
                    ElseIf _entPlanCuentaAutomatico.Cargo = "H" Then
                        _entPlanCuentaAutomatico.EsAbono = odrdatos("dec_Importe")
                        _entPlanCuentaAutomatico.EsCargo = ""
                    End If
                    _entPlanCuentaAutomatico.IdCuenta = odrdatos("var_IdCuenta")
                    _entPlanCuentaAutomatico.Observacion = odrdatos("var_Observacion")
                    _entPlanCuentaAutomatico.Clave = odrdatos("var_IdAsiento")
                    _lstPlanCuentaautomatico.Add(_entPlanCuentaAutomatico)
                End While

            End If
            Return (_lstPlanCuentaautomatico.Count > 0)
        Catch ex As Exception
            _objError = ex
            Return False
        End Try


    End Function
#End Region
End Class
