Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.AccesoDatos
Imports System.Data
Imports System.Data.SqlClient

Namespace CONFIG


    Public Class AD_FormaPago

#Region "Variables"
        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstFormaPago As List(Of EN_FormaPago)
        Private _entFormaPago As New EN_FormaPago

#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstFormaPago As List(Of EN_FormaPago)
            Get
                Return _lstFormaPago
            End Get
        End Property

        Public Property entFormaPago As EN_FormaPago
            Get
                Return _entFormaPago
            End Get
            Set(ByVal Value As EN_FormaPago)
                _entFormaPago = Value
            End Set
        End Property

#End Region


#Region "METODOS Y FUNCIONES"

        Public Function Listar() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer

                _objConexion.Procedimiento = "SGC_uspe_Cuota_Listar"

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstFormaPago = New List(Of EN_FormaPago)

                While odrDatos.Read
                    _entFormaPago = New EN_FormaPago


                    _entFormaPago.IdCuota = odrDatos("var_idCuota")
                    _entFormaPago.Descripcion = odrDatos("var_Descripcion")
                    _entFormaPago.Estado = odrDatos("chr_Estado")
                    _entFormaPago.UsuarioCreacion = IIf(IsDBNull(odrDatos("var_UsuarioCreacion")), "", odrDatos("var_UsuarioCreacion"))
                    _entFormaPago.FechaCreacion = odrDatos("dtm_FechaCreacion")
                    _entFormaPago.UsuarioModificacion = IIf(IsDBNull(odrDatos("var_UsuarioModificacion")), "", odrDatos("var_UsuarioModificacion"))
                    _entFormaPago.FechaModificacion = odrDatos("dtm_FechaModificacion")

                    _lstFormaPago.Add(_entFormaPago)
                End While

                Return (_lstFormaPago.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function


#End Region
    End Class
End Namespace