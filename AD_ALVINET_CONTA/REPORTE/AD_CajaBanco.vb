Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA
Imports System.Data.SqlClient

Namespace REPORTE

    Public Class AD_CajaBanco
#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _entCajaBanco As New EN_CajaBanco

        Private _entBase As New EN_Base
        Private _dtbDatos As Data.DataTable


#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public Property entCajaBanco As EN_CajaBanco
            Get
                Return _entCajaBanco
            End Get
            Set(ByVal Value As EN_CajaBanco)
                _entCajaBanco = Value
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
       
        Public Function Buscar(ByVal pstrFechaInicio As String, ByVal pstrFechFinal As String) As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_utb_CajaBanco_Buscar"
                _objConexion.AddParameter("var_IdMovimiento", _entCajaBanco.IdMovimiento)
                _objConexion.AddParameter("var_IdEntidadFinanciera", _entCajaBanco.IdEntidadFinanciera)
                _objConexion.AddParameter("var_IdTipoComprobante", _entCajaBanco.IdTipoComprobante)
                _objConexion.AddParameter("var_Comprobante", _entCajaBanco.Comprobante)
                _objConexion.AddParameter("var_FechaInicio", pstrFechaInicio)
                _objConexion.AddParameter("var_FechaFinal", pstrFechFinal)
                _objConexion.AddParameter("var_IdMoneda", _entCajaBanco.IdMoneda)
                _objConexion.AddParameter("var_IdCliente", _entCajaBanco.IdCliente)
                _objConexion.AddParameter("var_IdProveedor", _entCajaBanco.IdProveedor)
                _objConexion.AddParameter("var_IdTipoDocumento", _entCajaBanco.IdTipoDocumento)
                _objConexion.AddParameter("var_NumeroDocumento", _entCajaBanco.NumeroDocumento)
                _objConexion.AddParameter("var_IdOperacion", _entCajaBanco.IdOperacion)
                _objConexion.AddParameter("var_IdSubOperacion", _entCajaBanco.IdSubOperacion)
                _dtbDatos = _objConexion.ObtenerDataTable
                
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
            Return True

        End Function


#End Region
    End Class
End Namespace