Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.OPERACION
Imports System.Data
Imports System.Data.SqlClient

Namespace OPERACION
    Public Class AD_OrdenServicio

#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstDatos As List(Of EN_OrdenServicio)
        Private _entDato As New EN_OrdenServicio
#End Region

#Region "Propiedades"
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

#End Region

        Public Sub New()
            _entDato = New EN_OrdenServicio
        End Sub

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_usp_OrdenServicio_Registrar"
                _objConexion.AddParameter("var_IdOrdenServicio", _entDato.IdOrdenServicio)
                _objConexion.AddParameter("var_FechaEmision", _entDato.FechaEmision)
                _objConexion.AddParameter("int_IdDepartamento", CInt(_entDato.IdDepartamento))
                _objConexion.AddParameter("var_IdCliente", _entDato.IdCliente)
                _objConexion.AddParameter("var_LugarOperacion", _entDato.LugarOperacion)
                _objConexion.AddParameter("var_TrabaSolicitado", _entDato.TrabaSolicitante)
                _objConexion.AddParameter("var_Telefono", _entDato.Telefono)
                _objConexion.AddParameter("var_TrabaEfectuado", _entDato.TrabajoEfectuado)
                _objConexion.AddParameter("var_Operador", _entDato.Operador)
                _objConexion.AddParameter("var_Riger", _entDato.Riger)
                _objConexion.AddParameter("var_Ayudante", _entDato.Ayudante)
                _objConexion.AddParameter("var_PlacaGrua", _entDato.Placa_Grua)
                _objConexion.AddParameter("var_TipoServicio", _entDato.TipoServicio)
                _objConexion.AddParameter("int_HoraSalidaBase", _entDato.HoraSalidaBase)
                _objConexion.AddParameter("int_HoraLlegadaObra", _entDato.HoraLlegadaObra)
                _objConexion.AddParameter("int_HoraInicioOpera", _entDato.HoraInicioOperacion)
                _objConexion.AddParameter("int_HoraTerminoOpera", _entDato.HoraTerminoOperacion)
                _objConexion.AddParameter("int_HoraSalidaObra", _entDato.HoraSalidaObra)
                _objConexion.AddParameter("int_HoraLlegadaBase", _entDato.HoraLlegadaBase)
                _objConexion.AddParameter("int_HorasRecorrido", _entDato.TiempoRecorrido)
                _objConexion.AddParameter("int_HorasTrabajo", _entDato.TiempoTrabajo)
                _objConexion.AddParameter("int_HorasFacturar", _entDato.TiempoFacturar)
                _objConexion.AddParameter("num_TarifaHora", _entDato.TarifaHora)
                _objConexion.AddParameter("var_IdMoneda", _entDato.IdMoneda)
                _objConexion.AddParameter("num_Igv", _entDato.Igv)
                _objConexion.AddParameter("num_TotalFacturar", _entDato.TotalFacturar)
                _objConexion.AddParameter("var_Observacion", _entDato.Observacion)
                _objConexion.AddParameter("chr_Estado", _entDato.Estado)
                _entDato.IdOrdenServicio = _objConexion.ObtenerValor()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False

            End Try
        End Function

        Public Function Buscar() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_usp_OrdenServicio_Buscar"
                _objConexion.AddParameter("var_IdOrdenServicio", _entDato.IdOrdenServicio)
                _objConexion.AddParameter("var_IdDepartamento", _entDato.IdDepartamento)
                _objConexion.AddParameter("var_IdCliente", _entDato.IdCliente)
                _objConexion.AddParameter("var_FechaInicio", _entDato.FechaInicio)
                _objConexion.AddParameter("var_FechaFinal", _entDato.FechaFinal)
                _objConexion.AddParameter("var_Tipo", _entDato.TipoServicio)
                _objConexion.AddParameter("var_Estado", _entDato.Estado)
                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstDatos = New List(Of EN_OrdenServicio)

                While odrDatos.Read

                    Dim entDato = New EN_OrdenServicio
                    entDato.IdOrdenServicio = odrDatos("var_IdOrdenServicio")
                    entDato.FechaEmision = odrDatos("dtm_FechaEmision")
                    entDato.IdDepartamento = odrDatos("int_IdDepartamento")
                    entDato.Departamento = odrDatos("var_Departamento")
                    entDato.IdCliente = odrDatos("var_IdCliente")
                    entDato.RazonSocial = odrDatos("var_RazonSocial")
                    entDato.LugarOperacion = odrDatos("var_LugarOperacion")
                    entDato.TrabaSolicitante = odrDatos("var_TrabaSolicitado")
                    entDato.Telefono = odrDatos("var_Telefono")
                    entDato.TrabajoEfectuado = odrDatos("var_TrabaEfectuado")
                    entDato.Operador = odrDatos("var_Operador")
                    entDato.Riger = odrDatos("var_Riger")
                    entDato.Ayudante = odrDatos("var_Ayudante")
                    entDato.Placa_Grua = odrDatos("var_PlacaGrua")
                    entDato.HoraSalidaBase = CInt(odrDatos("int_HoraSalidaBase"))
                    entDato.HoraLlegadaObra = CInt(odrDatos("int_HoraLlegadaObra"))
                    entDato.HoraInicioOperacion = CInt(odrDatos("int_HoraInicioOpera"))
                    entDato.HoraTerminoOperacion = CInt(odrDatos("int_HoraTerminoOpera"))
                    entDato.HoraSalidaObra = CInt(odrDatos("int_HoraSalidaObra"))
                    entDato.HoraLlegadaBase = CInt(odrDatos("int_HoraLlegadaBase"))
                    entDato.TarifaHora = CDbl(odrDatos("num_TarifaHora"))
                    entDato.ImporteTotal = CDbl(odrDatos("num_TotalFacturar"))
                    entDato.IdMoneda = odrDatos("var_IdMoneda")
                    entDato.Moneda = odrDatos("var_Moneda")
                    entDato.IdTipoServicio = odrDatos("var_IdTipoServicio")
                    entDato.TipoServicio = odrDatos("var_TipoServicio")
                    entDato.Igv = odrDatos("num_Igv")
                    entDato.Observacion = odrDatos("var_Observacion")
                    entDato.Estado = odrDatos("chr_Estado")
                    _lstDatos.Add(entDato)
                End While


                Return (_lstDatos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

    End Class
End Namespace

