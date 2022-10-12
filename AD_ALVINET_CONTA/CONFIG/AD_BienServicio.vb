Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.AccesoDatos
Imports System.Data
Imports System.Data.SqlClient

Namespace CONFIG
    Public Class AD_BienServicio
#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstBienServicio As List(Of EN_BienServicio)
        Private _entBienServicio As New EN_BienServicio

#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstBienServicio As List(Of EN_BienServicio)
            Get
                Return _lstBienServicio
            End Get
        End Property

        Public Property entBienServicio As EN_BienServicio
            Get
                Return _entBienServicio
            End Get
            Set(ByVal Value As EN_BienServicio)
                _entBienServicio = Value
            End Set
        End Property

#End Region
#Region "METODOS Y FUNCIONES"

        Public Function Listar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "ERP_usp_BienServicio_Listar"
                _objConexion.AddParameter("var_IdEmpresa ", _entBienServicio.IdEmpresa)

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstBienServicio = New List(Of EN_BienServicio)
                While odrDatos.Read
                    _entBienServicio = New EN_BienServicio
                    _entBienServicio.IdBienServicio = odrDatos("var_IdBienServicio")
                    _entBienServicio.Descripcion = odrDatos("var_Descripcion")
                    _lstBienServicio.Add(_entBienServicio)
                End While
                Return (_lstBienServicio.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function
#End Region
    End Class
End Namespace
