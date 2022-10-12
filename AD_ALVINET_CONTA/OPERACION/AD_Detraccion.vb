Imports EN_ALVINET_CONTA
Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.OPERACION
Imports System.Data
Imports System.Data.SqlClient


Namespace OPERACION


    Public Class AD_Detraccion


#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstDetracciones As New List(Of EN_Detraccion)
        Private _entDetraccion As New EN_Detraccion

#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstDetracciones As List(Of EN_Detraccion)
            Get
                Return _lstDetracciones
            End Get
        End Property

        Public Property entDetraccion As EN_Detraccion
            Get
                Return _entDetraccion
            End Get
            Set(ByVal Value As EN_Detraccion)
                _entDetraccion = Value
            End Set
        End Property

#End Region



#Region "METODOS Y FUNCIONES"

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Detraccion_Registrar"
                _objConexion.AddParameter("var_IdDetraccion", _entDetraccion.IdDetraccion.ToString())
                _objConexion.AddParameter("var_NumeroConstancia", _entDetraccion.NumeroConstancia.ToString())
                _objConexion.AddParameter("var_IdEmpresa", _entDetraccion.IdEmpresa.ToString())
                _objConexion.AddParameter("var_NumeroCuentaDetracciones", _entDetraccion.NumeroCuentaDetracciones.ToString())
                _objConexion.AddParameter("var_IdEntidadFinanciera", _entDetraccion.IdEntidadFinanciera.ToString())
                _objConexion.AddParameter("chr_RucProveedor", _entDetraccion.RucProveedor.ToString())
                _objConexion.AddParameter("chr_RucAdquiriente", _entDetraccion.RucAdquiriente.ToString())
                _objConexion.AddParameter("var_IdOperacion", _entDetraccion.IdOperacion.ToString())
                _objConexion.AddParameter("var_BienoServicio", _entDetraccion.BienoServicio.ToString())
                _objConexion.AddParameter("dec_MontoDeposito", Convert.ToDecimal(_entDetraccion.MontoDeposito.ToString()))
                _objConexion.AddParameter("var_FechaPago", _entDetraccion.FechaPago.ToString())
                _objConexion.AddParameter("var_PeriodoTributario", _entDetraccion.PeriodoTributario.ToString)
                _objConexion.AddParameter("var_NumeroOperacion", _entDetraccion.NumeroOperacion)
                _objConexion.AddParameter("var_IdDocumentoCompra", _entDetraccion.IdDocumentoCompra)

                _objConexion.AddParameter("num_Saldo", _entDetraccion.Saldo)
                _objConexion.AddParameter("num_MontoDetraccion", _entDetraccion.MontoDetraccion)

                '_objConexion.EjecutarComando()

                _entDetraccion.IdDetraccion = _objConexion.EjecutarComandoSalida().ToString()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function ListarDetraccion() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "[dbo].[ERP_usp_Detraccion_Listar]"
                _objConexion.AddParameter("var_NumeroDocumento", entDetraccion.NumeroDetraccion)
                _objConexion.AddParameter("var_RazonSocial", entDetraccion.RazonSocial)
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                While odrDatos.Read
                    _entDetraccion = New EN_Detraccion

                    _entDetraccion.RucProveedor = odrDatos("RucProveedor")
                    _entDetraccion.RazonSocialProveedor = odrDatos("Proveedor")
                    _entDetraccion.Numero = odrDatos("var_NumeroDocumento")
                    _entDetraccion.Total = odrDatos("dec_Total")
                    _entDetraccion.Detraccion = odrDatos("var_Detraccion")
                    _entDetraccion.IdDetraccion = odrDatos("var_IdDetraccion")
                    _entDetraccion.MontoDeposito = odrDatos("dec_MontoDeposito")
                    _entDetraccion.NumeroDetraccion = odrDatos("var_NumeroDocumento")
                    _entDetraccion.NumeroConstancia = odrDatos("var_NumeroConstancia")
                    _entDetraccion.NumeroCuentaDetracciones = odrDatos("var_NumeroCuentaDetracciones")
                    _entDetraccion.PeriodoTributario = odrDatos("var_PeriodoTributario")
                    _entDetraccion.NumeroOperacion = odrDatos("var_NumeroOperacion")

                    _entDetraccion.FechaPago = odrDatos("dtm_FechaPago")
                    _entDetraccion.Ruc = odrDatos("chr_RUC")
                    _entDetraccion.RazonSocial = odrDatos("Empresa")
                    _entDetraccion.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entDetraccion.BienoServicio = odrDatos("var_IdBienServicio")

                    _entDetraccion.NumeroOperacion = odrDatos("var_NumeroOperacion")
                    _entDetraccion.IdEntidadFinanciera = odrDatos("var_IdEntidadFinanciera")
                    _entDetraccion.Operacion = odrDatos("Operacion")
                    _entDetraccion.IdOperacion = odrDatos("var_IdOperacion")
                    _entDetraccion.IdDocumentoCompra = odrDatos("var_IdDocumentoCompra")
                    _entDetraccion.Detraccion = odrDatos("var_Detraccion")
                    _entDetraccion.Saldo = odrDatos("num_Saldo")

                    _lstDetracciones.Add(_entDetraccion)

                End While
                Return (_lstDetracciones.Count > 0)
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Detracccion_Eliminar"
                _objConexion.AddParameter("var_NumeroConstancia", _entDetraccion.NumeroConstancia)
                '_objConexion.AddParameter("var_IdEmpresa", _entDetraccion.IdEmpresa)
                _objConexion.AddParameter("Chr_RucProveedor", _entDetraccion.RucProveedor)
                _objConexion.AddParameter("var_IdEntidadFinanciera", _entDetraccion.IdEntidadFinanciera)
                _objConexion.AddParameter("var_IdOperacion", _entDetraccion.IdOperacion)
                '_objConexion.AddParameter("var_BienoServicio", _entDetraccion.BienoServicio)
                _objConexion.AddParameter("var_IdDetraccion", _entDetraccion.IdDetraccion)

                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function





        Public Function Listar() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_Detraccion_Listar"
                _objConexion.AddParameter("var_IdEmpresa", _entDetraccion.IdEmpresa)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstDetracciones = New List(Of EN_Detraccion)

                While odrDatos.Read

                    _entDetraccion = New EN_Detraccion
                    _entDetraccion.NumeroConstancia = odrDatos("var_NumeroConstancia")
                    _entDetraccion.IdEmpresa = odrDatos("var_IdEmpresa")
                    _entDetraccion.RazonSocial = odrDatos("var_RazonSocial")
                    _entDetraccion.NumeroCuentaDetracciones = odrDatos("var_NumeroCuentaDetracciones")
                    _entDetraccion.IdEntidadFinanciera = odrDatos("var_IdEntidadFinanciera")
                    _entDetraccion.Descripcion = odrDatos("var_Descripcion")
                    _entDetraccion.RucProveedor = odrDatos("chr_RucProveedor")
                    _entDetraccion.RazonSocialProveedor = odrDatos("razonSocialProveedor")
                    _entDetraccion.RucAdquiriente = odrDatos("chr_RucAdquiriente")
                    _entDetraccion.IdOperacion = odrDatos("var_IdOperacion")
                    _entDetraccion.DescripcionOperacion = odrDatos("DescripcionOperacion")
                    _entDetraccion.BienoServicio = odrDatos("var_BienoServicio")
                    _entDetraccion.DescripcionServicio = odrDatos("DescripcionServicio")
                    _entDetraccion.MontoDeposito = odrDatos("dec_MontoDeposito")
                    _entDetraccion.FechaPago = odrDatos("dtm_FechaPago")
                    _entDetraccion.PeriodoTributario = odrDatos("var_PeriodoTributario")
                    _entDetraccion.NumeroOperacion = odrDatos("var_NumeroOperacion")

                    _entDetraccion.IdDocumentoCompra = odrDatos("var_IdDocumentoCompra")
                    _entDetraccion.Numero = odrDatos("var_NumeroDocumento")
                    _entDetraccion.Total = odrDatos("dec_Total")
                    _entDetraccion.MontoDetraccion = odrDatos("var_MontoDetraccion")
                    _entDetraccion.Detraccion = odrDatos("var_Detraccion")
                    _entDetraccion.Saldo = odrDatos("num_Saldo")

                    _lstDetracciones.Add(_entDetraccion)
                End While


                Return (_lstDetracciones.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "erp_usp_proveedor_Individual_buscar"
                _objConexion.AddParameter("var_IdEmpresa", _entDetraccion.IdEmpresa)
                _objConexion.AddParameter("varRuc", _entDetraccion.RucProveedor)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstDetracciones = New List(Of EN_Detraccion)

                While odrDatos.Read

                    _entDetraccion = New EN_Detraccion

                    _entDetraccion.RucProveedor = odrDatos("chr_RUC")
                    _entDetraccion.RazonSocialProveedor = odrDatos("var_RazonSocial")

                    _lstDetracciones.Add(_entDetraccion)
                End While

                Return (_lstDetracciones.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region



    End Class

End Namespace
