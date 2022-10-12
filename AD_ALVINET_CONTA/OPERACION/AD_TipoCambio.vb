Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.OPERACION
Imports System.Data
Imports System.Data.SqlClient

Namespace OPERACION

    Public Class AD_TipoCambio
#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstTipoCambios As List(Of EN_TipoCambio)
        Private _entTipoCambio As New EN_TipoCambio
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstTipoCambios As List(Of EN_TipoCambio)
            Get
                Return _lstTipoCambios
            End Get
        End Property

        Public Property entTipoCambio As EN_TipoCambio
            Get
                Return _entTipoCambio
            End Get
            Set(ByVal Value As EN_TipoCambio)
                _entTipoCambio = Value
            End Set
        End Property

#End Region
#Region "Funciones"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_TipoCambio_Registrar"
                _objConexion.AddParameter("var_IdEmpresa", _entTipoCambio.IdEmpresa)
                _objConexion.AddParameter("var_IdTipoCambio", _entTipoCambio.IdTipoCambio)
                _objConexion.AddParameter("var_IdMoneda", _entTipoCambio.IdMoneda)
                _objConexion.AddParameter("dtm_fecha", _entTipoCambio.Fecha)
                _objConexion.AddParameter("mo_Compra", _entTipoCambio.Compra)
                _objConexion.AddParameter("mo_Venta", _entTipoCambio.Venta)
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
                _objConexion.Procedimiento = "ERP_usp_TipoCambio_Eliminar"
                _objConexion.AddParameter("var_idEmpresa", _entTipoCambio.IdEmpresa)
                _objConexion.AddParameter("var_IdTipoCambio", _entTipoCambio.IdTipoCambio)

                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function ListarMax() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_TipoCambio_Listar_Max"
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstTipoCambios = New List(Of EN_TipoCambio)

                While odrDatos.Read

                    _entTipoCambio = New EN_TipoCambio
                    _entTipoCambio.Compra = odrDatos("mo_compra")
                    _entTipoCambio.Venta = odrDatos("mo_Venta")
                    _lstTipoCambios.Add(_entTipoCambio)
                End While
                Return (_lstTipoCambios.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function TipoCambioPorFecha() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_TipoCambioPorFecha"
                _objConexion.AddParameter("var_IdEmpresa", _entTipoCambio.IdEmpresa)
                _objConexion.AddParameter("var_Fecha", _entTipoCambio.Fecha)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstTipoCambios = New List(Of EN_TipoCambio)

                While odrDatos.Read

                    _entTipoCambio = New EN_TipoCambio
                    _entTipoCambio.Compra = odrDatos("mo_compra")
                    _entTipoCambio.Venta = odrDatos("mo_Venta")
                    _lstTipoCambios.Add(_entTipoCambio)
                End While
                Return (_lstTipoCambios.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Listar() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[ERP_usp_TipoCambio_Listarr]"
                _objConexion.AddParameter("var_IdEmpresa", _entTipoCambio.IdEmpresa)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstTipoCambios = New List(Of EN_TipoCambio)

                While odrDatos.Read

                    _entTipoCambio = New EN_TipoCambio
                    _entTipoCambio.IdTipoCambio = odrDatos("var_IdTipoCambio")

                    _entTipoCambio.IdEmpresa = odrDatos("var_idEmpresa")
                    _entTipoCambio.RazonSocial = odrDatos("var_RazonSocial")

                    _entTipoCambio.IdMoneda = odrDatos("var_IdMoneda")
                    _entTipoCambio.DescMoneda = odrDatos("var_Descripcion")

                    _entTipoCambio.FechaString = odrDatos("dtm_Fecha")
                    _entTipoCambio.Compra = odrDatos("mo_compra")
                    _entTipoCambio.Venta = odrDatos("mo_Venta")

                    _lstTipoCambios.Add(_entTipoCambio)
                End While


                Return (_lstTipoCambios.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace