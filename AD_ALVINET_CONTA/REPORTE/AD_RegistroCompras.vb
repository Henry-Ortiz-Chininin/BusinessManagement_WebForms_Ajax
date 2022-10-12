Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA
Imports System.Data.SqlClient

Namespace REPORTE

    Public Class AD_RegistroCompras
#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _entComprobante As New EN_ALVINET_CONTA.GENERAL.EN_CompraDocumento

        Private _entBase As New EN_Base
        Private _dtbDatos As Data.DataTable


#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public Property entComprobante As EN_ALVINET_CONTA.GENERAL.EN_CompraDocumento
            Get
                Return _entComprobante
            End Get
            Set(ByVal Value As EN_ALVINET_CONTA.GENERAL.EN_CompraDocumento)
                _entComprobante = Value
            End Set
        End Property
        Public Property Base() As EN_Base
            Get
                Return _entBase
            End Get
            Set(ByVal value As EN_Base)
                _entBase = value
            End Set
        End Property

        Public ReadOnly Property Datos As DataTable
            Get
                Return _dtbDatos
            End Get
        End Property


#End Region
#Region "Metodos y Funciones"

        Public Function Obtener(ByVal pint_Agno As Int16, ByVal pint_Mes As Int16) As DataTable
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_LibroCompra_Obtener"
                _objConexion.AddParameter("int_Agno", pint_Agno)
                _objConexion.AddParameter("int_Mes", pint_Mes)
                _dtbDatos = _objConexion.ObtenerDataTable

                Return _dtbDatos
            Catch ex As Exception
                _objError = ex
                Return Nothing
            End Try

        End Function


#End Region
    End Class
End Namespace