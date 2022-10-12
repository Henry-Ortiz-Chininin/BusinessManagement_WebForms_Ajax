Imports AccesoDatos
Namespace Proceso.Produccion.RegistroProduccion
    Public Class ManoObra
#Region "VARIABLES"
        Private _strIdProduccion As String
        Private _strIdPersonal As String
        Private _strIdProceso As String
        Private _strIdOrden As String
        Private _dblCantidad As Double
        Private _strIdUnidadMedida As String
        Private _dblCostoUnitario As Double

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdProduccion As String
            Get
                Return _strIdProduccion
            End Get
            Set(ByVal value As String)
                _strIdProduccion = value
            End Set
        End Property
        Public Property IdPersonal As String
            Get
                Return _strIdPersonal
            End Get
            Set(ByVal value As String)
                _strIdPersonal = value
            End Set
        End Property
        Public Property IdProceso As String
            Get
                Return _strIdProceso
            End Get
            Set(ByVal value As String)
                _strIdProceso = value
            End Set
        End Property
        Public Property IdOrden As String
            Get
                Return _strIdOrden
            End Get
            Set(ByVal value As String)
                _strIdOrden = value
            End Set
        End Property
        Public Property Cantidad As Double
            Get
                Return _dblCantidad
            End Get
            Set(ByVal value As Double)
                _dblCantidad = value
            End Set
        End Property
        Public Property IdUnidadMedida As String
            Get
                Return _strIdUnidadMedida
            End Get
            Set(ByVal value As String)
                _strIdUnidadMedida = value
            End Set
        End Property
        Public Property CostoUnitario As Double
            Get
                Return _dblCostoUnitario
            End Get
            Set(ByVal value As Double)
                _dblCostoUnitario = value
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

        Public Property Datos() As DataTable
            Get
                Return _dtbDatos
            End Get
            Set(ByVal value As DataTable)
                _dtbDatos = value
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
        Public ReadOnly Property exError() As String
            Get
                Return _exError.ToString
            End Get
        End Property
#End Region

#Region "METODOS Y FUNCIONES"
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdProduccion", _strIdProduccion, _
                                                 "var_IdPersonal", _strIdPersonal, _
                                                 "chr_IdProceso", _strIdProceso, _
                                                 "var_IdOrden", _strIdOrden, _
                                                 "num_Cantidad", _dblCantidad, _
                                                 "var_IdUnidadMedida", _strIdUnidadMedida, _
                                                 "num_CostoUnitario", _dblCostoUnitario, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_ProduccionPersonal_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdProduccion", _strIdProduccion}
                _objConexion.EjecutarComando("SGC_usp_ProduccionPersonal_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdProduccion", _strIdProduccion, _
                                                 "var_IdPersonal", _strIdPersonal, _
                                                 "var_IdProceso", _strIdProceso, _
                                                 "var_IdOrden", _strIdOrden}

                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_ProduccionPersonal_Buscar", objParametros)
                If _dtbDatos.Rows.Count = 1 Then
                    _strIdOrden = _dtbDatos.Rows(0)("var_IdOrden")
                    _strIdPersonal = _dtbDatos.Rows(0)("var_IdPersonal")
                    _strIdProceso = _dtbDatos.Rows(0)("chr_IdProceso")
                    _strIdProduccion = _dtbDatos.Rows(0)("chr_IdProduccion")
                    _strIdUnidadMedida = _dtbDatos.Rows(0)("var_IdUnidadMedida")
                    _dblCantidad = _dtbDatos.Rows(0)("num_Cantidad")
                    _dblCostoUnitario = _dtbDatos.Rows(0)("num_CostoUnitario")

                    '_strEstado = _dtbDatos.Rows(0)("chr_Estado")

                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


#End Region
    End Class
End Namespace

