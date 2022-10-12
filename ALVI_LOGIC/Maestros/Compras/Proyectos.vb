
Imports AccesoDatos
Imports ALVI_LOGIC


Namespace Maestros.Compras



    Public Class Proyectos

        'variables

        Private _strIdCodigo As String
        Private _strNombre As String
        Private _strDescripcion As String
        Private _dblPresupuesto As Double
        Private _dblEjecutado As Double

        'para el listar se usa el datatable'
        Private _dtbDatos As DataTable

        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

        Private _strEstadoProyecto As String
        Private _strUsuario As String
        Private _strEstado As String

        'PROPIEDADES 



        Public Property IdCodigo As String
            Get
                Return _strIdCodigo
            End Get
            Set(ByVal value As String)
                _strIdCodigo = value
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

        Public Property EstadoProyecto() As String
            Get
                Return _strEstadoProyecto
            End Get
            Set(ByVal value As String)
                _strEstadoProyecto = value
            End Set
        End Property


        Public Property Nombre As String
            Get
                Return _strNombre
            End Get
            Set(ByVal value As String)
                _strNombre = value
            End Set
        End Property



        Public Property Descripcion As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property




        Public Property Presupuesto As Double
            Get
                Return _dblPresupuesto
            End Get
            Set(ByVal value As Double)
                _dblPresupuesto = value
            End Set
        End Property




        Public Property Ejecutado As Double
            Get
                Return _dblEjecutado
            End Get
            Set(ByVal value As Double)
                _dblEjecutado = value
            End Set
        End Property





        Public Property Estado As String
            Get
                Return _strEstado
            End Get
            Set(ByVal value As String)
                _strEstado = value
            End Set
        End Property




        Public ReadOnly Property exError() As String
            Get
                Return _exError.ToString
            End Get
        End Property



        Public Property Datos() As DataTable
            Get
                Return _dtbDatos
            End Get
            Set(ByVal value As DataTable)
                _dtbDatos = value
            End Set
        End Property


        'metodos y funciones

       Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdProyecto", _strIdCodigo, _
                                                 "var_Nombre", _strNombre, _
                                                 "var_Descripcion", _strDescripcion, _
                                                 "num_ImpPresupuesto", _dblPresupuesto, _
                                                 "num_ImpUtilizado", _dblEjecutado, _
                                                 "chr_IdEstado", _strEstado, _
                                                   "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_Proyecto_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Proyecto_Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function




        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdProyecto", _strIdCodigo}
                _objConexion.EjecutarComando("SGC_usp_Proyecto_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function





        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdProyecto", _strIdCodigo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Proyecto_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdCodigo = _dtbDatos.Rows(0)("var_IdProyecto")
                    _strNombre = _dtbDatos.Rows(0)("var_Nombre")
                    _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
                    _dblPresupuesto = _dtbDatos.Rows(0)("num_ImpPresupuesto")
                    _dblEjecutado = _dtbDatos.Rows(0)("num_ImpUtilizado")
                    _strEstado = _dtbDatos.Rows(0)("chr_IdEstado")

                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function




        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_Nombre", _strNombre, _
                                                  "var_Descripcion", _strDescripcion, _
                                                  "chr_IdEstado", _strEstado}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Proyecto_Buscar", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


        Public Function Buscar1() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_Nombre", _strNombre, _
                                                  "var_IdProyecto", _strIdCodigo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_Proyecto_Buscar1", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


    End Class

End Namespace

