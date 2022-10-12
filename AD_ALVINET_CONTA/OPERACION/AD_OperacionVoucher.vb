Imports EN_ALVINET_CONTA.OPERACION
Imports AD_ALVINET_CONTA.AccesoDatos
Imports System.Reflection

Namespace OPERACION

    Public Class AD_OperacionVoucher

        Private _objConexion As AccesoDatos.AccesoDatosSQLServer
        Private _entOperacion As EN_OperacionVoucher
        Private _lstOperacion As List(Of EN_OperacionVoucher)
        Private _entCuenta As EN_OperacionCuenta
        Private _lstCuenta As List(Of EN_OperacionCuenta)
        Private _strDatosCuenta As String
        Private _objError As New Exception

#Region "Propiedades"
        Public Property entOperacion() As EN_OperacionVoucher
            Get
                Return _entOperacion
            End Get
            Set(ByVal value As EN_OperacionVoucher)
                _entOperacion = value
            End Set
        End Property

        Public ReadOnly Property lstOperacion() As List(Of EN_OperacionVoucher)
            Get
                Return _lstOperacion
            End Get
        End Property

        Public Property entCuenta() As EN_OperacionCuenta
            Get
                Return _entCuenta
            End Get
            Set(ByVal value As EN_OperacionCuenta)
                _entCuenta = value
            End Set
        End Property

        Public Property lstCuenta() As List(Of EN_OperacionCuenta)
            Get
                Return _lstCuenta
            End Get
            Set(ByVal value As List(Of EN_OperacionCuenta))
                _lstCuenta = value
                _strDatosCuenta = ConvertirToXML(_lstCuenta)
            End Set
        End Property

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property
#End Region

#Region "METODOS Y FUNCIONES"

        Private Function ConvertirToXML(Of T)(ByVal list As IList(Of T)) As String
            _strDatosCuenta = "<root>"
            Dim dt As New DataTable()
            Dim propiedades As PropertyInfo() = GetType(T).GetProperties
            For Each item As T In list
                _strDatosCuenta = _strDatosCuenta & "<item>"
                For Each p As PropertyInfo In propiedades
                    _strDatosCuenta = _strDatosCuenta & "<" & p.Name & ">" & p.GetValue(item, Nothing) & "</" & p.Name & ">"
                Next
                _strDatosCuenta = _strDatosCuenta & "</item>"
            Next
            _strDatosCuenta = _strDatosCuenta & "</root>"
            Return _strDatosCuenta
        End Function

        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_OperacionContable_Agregar"
                _objConexion.AddParameter("var_IdEmpresa", _entOperacion.Idempresa)
                _objConexion.AddParameter("var_IdEjercicioEmpresa", _entOperacion.IdEjercicio)
                _objConexion.AddParameter("var_IdContabilidad", _entOperacion.IdContabilidad)
                _objConexion.AddParameter("var_IdOperacion", _entOperacion.IdOperacion)
                _objConexion.AddParameter("var_Fecha", _entOperacion.Fecha)
                _objConexion.AddParameter("var_IdCliente", _entOperacion.IdCliente)
                _objConexion.AddParameter("var_IdTipoDocumento", _entOperacion.IdTipoDocumento)
                _objConexion.AddParameter("var_NumeroDocumento", _entOperacion.NumeroDocumento)
                _objConexion.AddParameter("var_IdProveedor", _entOperacion.IdProveedor)
                _objConexion.AddParameter("xml_Cuentas", _strDatosCuenta)
                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False

            End Try
        End Function
#End Region
    End Class
End Namespace

