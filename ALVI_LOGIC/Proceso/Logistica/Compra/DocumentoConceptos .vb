

Imports AccesoDatos
Imports ALVI_LOGIC
Namespace Proceso.Logistica
    Public Class DocumentoConceptos
        Private _strIdDocumentoCompra As String
        Private _strConcepto As String
        Private _dblImporte As Double
        Private _strMoneda As String
        Private _dblTipoCambio As Double
        Private _dblImporteTotal As Double
        Private _exError As Exception
        Private _objConexion As AccesoDatosSQLServer
        Private _dtbDatos As DataTable

        Public Property IdDocumentoCompra() As String
            Get
                Return _strIdDocumentoCompra
            End Get
            Set(ByVal value As String)
                _strIdDocumentoCompra = value
            End Set
        End Property


        Public Property Concepto() As String
            Get
                Return _strConcepto
            End Get
            Set(ByVal value As String)
                _strConcepto = value
            End Set
        End Property


        Public Property Moneda() As String
            Get
                Return _strMoneda
            End Get
            Set(ByVal value As String)
                _strMoneda = value
            End Set
        End Property



        Public Property TipoCambio() As String
            Get
                Return _dblTipoCambio
            End Get
            Set(ByVal value As String)
                _dblTipoCambio = value
            End Set
        End Property


        Public Property ImporteTotal() As Double
            Get
                Return _dblImporteTotal
            End Get
            Set(ByVal value As Double)
                _dblImporteTotal = value
            End Set
        End Property


        Public Property Importe() As Double
            Get
                Return _dblImporte
            End Get
            Set(ByVal value As Double)
                _dblImporte = value
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





        Public Function Listar() As Boolean
            Try
                Dim objParametros() As String = {"var_IdDocumentoCompra", _strIdDocumentoCompra}
                _objConexion = New AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_uspa_DocumentoCompraConceptos_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function
    End Class
End Namespace
