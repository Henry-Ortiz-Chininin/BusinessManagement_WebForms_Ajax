Imports AccesoDatos

Namespace Proceso.Logistica
    Public Class ConsumoIQ
#Region "VARIABLES"
        Private _strIdLoteIQ As String
        Private _strIdOrden As String
        Private _strSecuencialRuta As String
        Private _strIdProceso As String
        Private _strIdOperacion As String
        Private _strCriterio As String

        Private _strFormula As String
        Private _strIdReceta As String
        Private _strReceta As String
        Private _strIdMaquina As String
        Private _strMaquina As String
        Private _dblPeso As Double
        Private _dblVolumen As Double
        Private _dblRelacionBano As Double
        Private _strFibra As String

        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdLoteIQ As String
            Get
                Return _strIdLoteIQ
            End Get
            Set(ByVal value As String)
                _strIdLoteIQ = value
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
        Public Property Criterio As String
            Get
                Return _strCriterio
            End Get
            Set(ByVal value As String)
                _strCriterio = value
            End Set
        End Property
        Public Property Fibra As String
            Get
                Return _strFibra
            End Get
            Set(ByVal value As String)
                _strFibra = value
            End Set
        End Property
        Public Property SecuencialRuta As String
            Get
                Return _strSecuencialRuta
            End Get
            Set(ByVal value As String)
                _strSecuencialRuta = value
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
        Public Property IdOperacion As String
            Get
                Return _strIdOperacion
            End Get
            Set(ByVal value As String)
                _strIdOperacion = value
            End Set
        End Property
        Public Property Formula As String
            Get
                Return _strFormula
            End Get
            Set(ByVal value As String)
                _strFormula = value
            End Set
        End Property
        Public Property IdReceta As String
            Get
                Return _strIdReceta
            End Get
            Set(ByVal value As String)
                _strIdReceta = value
            End Set
        End Property
        Public Property Receta As String
            Get
                Return _strReceta
            End Get
            Set(ByVal value As String)
                _strReceta = value
            End Set
        End Property
        Public Property IdMaquina As String
            Get
                Return _strIdMaquina
            End Get
            Set(ByVal value As String)
                _strIdMaquina = value
            End Set
        End Property
        Public Property Maquina As String
            Get
                Return _strMaquina
            End Get
            Set(ByVal value As String)
                _strMaquina = value
            End Set
        End Property
        Public Property Peso As Double
            Get
                Return _dblPeso
            End Get
            Set(ByVal value As Double)
                _dblPeso = value
            End Set
        End Property
        Public Property RelacionBano As Double
            Get
                Return _dblRelacionBano
            End Get
            Set(ByVal value As Double)
                _dblRelacionBano = value
            End Set
        End Property
        Public Property Volumen As Double
            Get
                Return _dblVolumen
            End Get
            Set(ByVal value As Double)
                _dblVolumen = value
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
        Public Function Registrar(ByVal dtbHojas As Data.DataTable) As Boolean
            Try
                Dim objUtil As New General.Util

                If dtbHojas.Columns.IndexOf("var_Articulo") >= 0 Then
                    dtbHojas.Columns.Remove("var_Articulo")
                End If

                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As Object = {"var_IdLoteIQ", _strIdLoteIQ, _
                                                 "var_Formula", _strFormula, _
                                                 "var_IdReceta", _strIdReceta, _
                                                 "var_IdMaquina", _strIdMaquina, _
                                                 "var_criterio", _strCriterio, _
                                                 "num_Peso", _dblPeso, _
                                                 "num_Volumen", _dblVolumen, _
                                                 "xml_Datos", objUtil.GeneraXML(dtbHojas), _
                                                "var_Usuario", _strUsuario, _
                                                 "chr_IdTipo", _strFibra}
                _strIdLoteIQ = _objConexion.ObtenerValor("SGC_usp_LoteIQ_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Registrarexcepciones() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As Object = {"var_IdPartidaIQ", _strIdLoteIQ, _
                                                 "var_IdOrden", _strIdOrden, _
                                                 "int_SecuencialRuta", _strSecuencialRuta, _
                                                 "chr_IdProceso", _strIdProceso, _
                                                 "var_IdOperacion", _strIdOperacion, _
                                                 "var_IdMaquina", _strIdMaquina, _
                                                "var_Usuario", _strUsuario}
                _objConexion.ObtenerValor("SGC_uspo_IQRutaEX_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdLoteIQ", _strIdLoteIQ}
                _objConexion.EjecutarComando("SGC_usp_LoteIQ_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdLoteIQ", _strIdLoteIQ, _
                                                 "var_Formula", _strFormula, _
                                                 "var_IdReceta", _strIdReceta, _
                                                 "var_IdMaquina", _strIdMaquina}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_LoteIQ_Buscar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer

                Dim objParametros() As String = {"var_IdLoteIQ", _strIdLoteIQ}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_LoteIQ_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdLoteIQ = _dtbDatos.Rows(0)("var_IdLoteIQ")
                    _strFormula = _dtbDatos.Rows(0)("var_Formula")
                    _strIdReceta = _dtbDatos.Rows(0)("var_IdReceta")
                    _strIdMaquina = _dtbDatos.Rows(0)("var_IdMaquina")
                    _dblPeso = _dtbDatos.Rows(0)("num_Peso")
                    _dblVolumen = _dtbDatos.Rows(0)("num_Volumen")
                    _strFibra = _dtbDatos.Rows(0)("chr_IdTipo")
                    _strCriterio = _dtbDatos.Rows(0)("var_criterio")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function IQListarEX() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdPartidaIQ", _strIdLoteIQ, _
                                                 "var_IdOrden", _strIdOrden}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_IQRutaEX_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function HTDisponible(ByVal pstrIdOrden As String, ByVal pstrDesArticulo As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdOrden", pstrIdOrden, _
                                                 "var_DesArticulo", pstrDesArticulo}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_LoteIQ_HTDisponible_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Reporte() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdLoteIQ", _strIdLoteIQ}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_LoteIQ_Reporte", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Cabecera2() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As Object = {"var_IdLoteIQ", _strIdLoteIQ}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_LoteIQ_ReporteCabecera2", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdLoteIQ = _dtbDatos.Rows(0)("var_IdLoteIQ")
                    _strFormula = _dtbDatos.Rows(0)("var_Formula")
                    _strIdReceta = _dtbDatos.Rows(0)("var_IdReceta")
                    _strReceta = _dtbDatos.Rows(0)("var_Receta")
                    _strIdMaquina = _dtbDatos.Rows(0)("var_IdMaquina")
                    _strMaquina = _dtbDatos.Rows(0)("var_Maquina")
                    _dblPeso = _dtbDatos.Rows(0)("num_Peso")
                    _dblVolumen = _dtbDatos.Rows(0)("num_Volumen")
                    _dblRelacionBano = _dtbDatos.Rows(0)("var_RelacionBano")
                    _strFibra = _dtbDatos.Rows(0)("chr_IdTipo")
                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function Cabecera1() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdLoteIQ", _strIdLoteIQ}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspo_LoteIQ_ReporteCabecera1", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
        Public Function HTAsignada(ByVal pstrIdLoteIQ As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                Dim objParametros() As String = {"var_IdLoteIQ", pstrIdLoteIQ}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usp_LoteIQ_HTAsignada_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace

