
Imports AccesoDatos
Imports System.Data.SqlClient
Imports System.Data



Namespace Maestros.Requisicion
    Public Class Requisicion

        Private _strIdRequision As String
        Private _strIdCorrelativo As String
        Private _strIdSolicitante As String
        Private _strNombre As String
        Private _strApellidos As String
        Private _strTipo As String
        Private _strIdCodigoProyecto As String
        Private _strNombreProyecto As String
        Private _strIdCentroCosto As String
        Private _strDescripcion As String
        Private _strFechaPlazo As String
        Private _strReferencia As String
        Private _strMotivo As String
        Private _strProveedores As String
        Private _strUsuario As String

        Private _strIdUnidadMedida As String
        Private _strDescripcionUnidadMedida As String

        Private _strIdArticulo As String
        Private _strDescripcionArticulo As String

        Private _intCantidad As Integer

        Private _strEstado As String
        Private _dtbDatos As DataTable

        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer



        Public Property IdSolicitante() As String
            Get
                Return _strIdSolicitante
            End Get
            Set(ByVal value As String)
                _strIdSolicitante = value
            End Set
        End Property


        Public Property Usuario() As String
            Get
                Return _strUsuario
            End Get
            Set(ByVal value As String)
                _strUsuario = value
            End Set
        End Property

        Public Property IdCorrelativo() As String
            Get
                Return _strIdCorrelativo
            End Get
            Set(ByVal value As String)
                _strIdCorrelativo = value
            End Set
        End Property


        Public Property IdRequisicion() As String
            Get
                Return _strIdRequision
            End Get
            Set(ByVal value As String)
                _strIdRequision = value
            End Set
        End Property

        Public Property IdCentroCosto() As String
            Get
                Return _strIdCentroCosto
            End Get
            Set(ByVal value As String)
                _strIdCentroCosto = value
            End Set
        End Property

        Public Property IdCodigoPROYECTO As String
            Get
                Return _strIdCodigoProyecto
            End Get
            Set(ByVal value As String)
                _strIdCodigoProyecto = value
            End Set
        End Property

        Public Property Tipo() As String
            Get
                Return _strTipo
            End Get
            Set(ByVal value As String)
                _strTipo = value
            End Set
        End Property



        Public Property Nombre() As String
            Get
                Return _strNombre
            End Get
            Set(ByVal value As String)
                _strNombre = value
            End Set
        End Property


        Public Property Apellidos() As String
            Get
                Return _strApellidos
            End Get
            Set(ByVal value As String)
                _strApellidos = value
            End Set
        End Property

        Public Property Descripcion() As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property


        Public Property NombreProyecto() As String
            Get
                Return _strNombreProyecto
            End Get
            Set(ByVal value As String)
                _strNombreProyecto = value
            End Set
        End Property


        Public Property FechaPlazo() As String
            Get
                Return _strFechaPlazo
            End Get
            Set(ByVal value As String)
                _strFechaPlazo = value
            End Set
        End Property


        Public Property Referencia() As String
            Get
                Return _strReferencia
            End Get
            Set(ByVal value As String)
                _strReferencia = value
            End Set
        End Property


        Public Property Motivo() As String
            Get
                Return _strMotivo
            End Get
            Set(ByVal value As String)
                _strMotivo = value
            End Set
        End Property



        Public Property Proveedores() As String
            Get
                Return _strProveedores
            End Get
            Set(ByVal value As String)
                _strProveedores = value
            End Set
        End Property


        Public Property IdUnidadMedida() As String
            Get
                Return _strIdUnidadMedida
            End Get
            Set(ByVal value As String)
                _strIdUnidadMedida = value
            End Set
        End Property
        Public Property DescripcionUnidadMedida() As String
            Get
                Return _strDescripcionUnidadMedida
            End Get
            Set(ByVal value As String)
                _strDescripcionUnidadMedida = value
            End Set
        End Property



        Public Property IdArticulo() As String
            Get
                Return _strIdArticulo
            End Get
            Set(ByVal value As String)
                _strIdArticulo = value
            End Set
        End Property




        Public Property Estado() As String
            Get
                Return _strEstado
            End Get
            Set(ByVal value As String)
                _strEstado = value
            End Set
        End Property

        Public Property DescripcionArticulo() As String
            Get
                Return _strDescripcionArticulo
            End Get
            Set(ByVal value As String)
                _strDescripcionArticulo = value
            End Set
        End Property


        Public Property Cantidad() As Integer
            Get
                Return _intCantidad
            End Get
            Set(ByVal value As Integer)
                _intCantidad = value
            End Set
        End Property



        Public Function Registrar(ByVal dtbdatos As Data.DataTable) As Boolean
            Try
                Dim objUtil As New General.Util

                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdRequisicion", _strIdRequision, _
                                                 "var_IdTipoOperacion", _strTipo, _
                                                 "var_IdSolicitante", _strIdSolicitante, _
                                                 "var_IdProyecto", _strIdCodigoProyecto, _
                                                 "var_IdCentroCostoDestino", _strIdCentroCosto, _
                                                 "dtm_FechaPlazo", _strFechaPlazo, _
                                                  "var_Doc_Referencia", _strReferencia, _
                                                 "var_Motivo", _strMotivo, _
                                                 "chr_Estado", _strEstado, _
                                                  "var_UsuarioCreacion", _strUsuario, _
                                                 "var_ProveedorSugerido", _strProveedores, _
                                                 "xml_Datos", objUtil.GeneraXML(dtbdatos)}

                _strIdRequision = _objConexion.ObtenerValor("SGC_usp_Requisicion_Registrar", objParametros)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function RegistrarEstado(ByVal dtbdatos As Data.DataTable) As Boolean
            Try
                Dim objUtil As New General.Util

                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdRequisicion", _strIdRequision, _
                                                 "xml_Datos", objUtil.GeneraXML(dtbdatos)}

                _strIdRequision = _objConexion.ObtenerValor("SGC_usp_RequisicionAprobacion_Registrar", objParametros)
                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function RegistrarDetalle() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdRequisicion", _strIdRequision,
                                                 "var_IdDetalle", _strIdCorrelativo, _
                                                 "var_IdProyecto", _strIdUnidadMedida, _
                                                 "var_IdCentroCostoDestino", _strIdArticulo, _
                                                 "dtm_FechaPlazo", _intCantidad, _
                                                  "var_Doc_Referencia", _strDescripcion
                                                  }
                _objConexion.EjecutarComando("SGC_uspe_RequisicionDetalle_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

 
        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdRequisicion", _strIdRequision}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Requisicion_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdRequision = _dtbDatos.Rows(0)("var_IdRequisicion")
                    _strTipo = _dtbDatos.Rows(0)("var_IdTipoOperacion")
                    _strIdSolicitante = _dtbDatos.Rows(0)("var_IdSolicitante")
                    _strIdCodigoProyecto = _dtbDatos.Rows(0)("var_IdProyecto")
                    _strIdCentroCosto = _dtbDatos.Rows(0)("var_IdCentroCostoDestino")
                    _strFechaPlazo = _dtbDatos.Rows(0)("dtm_FechaPlazo")
                    _strReferencia = _dtbDatos.Rows(0)("var_Doc_Referencia")
                    _strMotivo = _dtbDatos.Rows(0)("var_Motivo")
                    _strProveedores = _dtbDatos.Rows(0)("var_ProveedorSugerido")
                    _strTipo = _dtbDatos.Rows(0)("var_IdTipoOperacion")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Actualizar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdRequisicion", _strIdRequision,
                                                 "chr_IdEstado", _strEstado}
                _objConexion.EjecutarComando("SCP_usp_Requisicion_Actualizar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function








    End Class

End Namespace
