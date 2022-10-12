
Imports AccesoDatos
Imports ALVI_LOGIC

Namespace Maestros.Requisicion
    Public Class Conceptos

        Private _strIdCodigo As String
        Private _strNombre As String
        Private _strDescripcion As String
        Private _dblPorcentaje As Double
        Private _dblImporte As Double
        Private _strEstado As String
        Private _strDireccion As String
        'para el listar se usa el datatable'
        Private _dtbDatos As DataTable

        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
        Private _strUsuario As String


        'PROPIEDADES 



        Public Property IdCodigo As String
            Get
                Return _strIdCodigo
            End Get
            Set(ByVal value As String)
                _strIdCodigo = value
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


        Public Property Usuario() As String
            Get
                Return _strUsuario
            End Get
            Set(ByVal value As String)
                _strUsuario = value
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

        Public Property Dirrecion As String
            Get
                Return _strDireccion
            End Get
            Set(ByVal value As String)
                _strDireccion = value
            End Set
        End Property




        Public Property Porcentaje As Double
            Get
                Return _dblPorcentaje
            End Get
            Set(ByVal value As Double)
                _dblPorcentaje = value
            End Set
        End Property




        Public Property Importe As Double
            Get
                Return _dblImporte
            End Get
            Set(ByVal value As Double)
                _dblImporte = value
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



        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdConcepto", _strIdCodigo, _
                                                 "var_Descripcion", _strDescripcion, _
                                                 "dec_Porcentaje", _dblPorcentaje, _
                                                 "num_Importe", _dblImporte, _
                                                  "var_Direccion", _strDireccion, _
                                                 "chr_Estado", _strEstado, _
                                                   "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usp_ConceptoDocumento_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function


        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_ConceptosDocumentos _Listar")

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function



        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdConcepto", _strIdCodigo}
                _objConexion.EjecutarComando("SGC_usp_ConceptosDocumentos_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function





        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdConcepto", _strIdCodigo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_ConceptosDocumentos_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdCodigo = _dtbDatos.Rows(0)("var_IdConcepto")

                    _strDescripcion = _dtbDatos.Rows(0)("var_Descripcion")
                    _dblPorcentaje = _dtbDatos.Rows(0)("dec_Porcentaje")
                    _dblImporte = _dtbDatos.Rows(0)("num_Importe")
                    _strDireccion = _dtbDatos.Rows(0)("var_Direccion")

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
                Dim objParametros() As String = {
                                                  "var_Descripcion", _strDescripcion
                                                  }
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_ConceptosDocumentos_Buscar", objParametros)
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function





    End Class

End Namespace

