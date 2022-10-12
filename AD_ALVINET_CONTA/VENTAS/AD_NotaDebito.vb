Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.VENTAS
Imports System.Data
Imports System.Data.SqlClient
Imports EN_ALVINET_CONTA
Imports AD_ALVINET_CONTA.GENERAL

Namespace VENTAS


    Public Class AD_NotaDebito


        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstNotasDebito As List(Of EN_NotaDebito)
        Private _entNotaDebito As New EN_NotaDebito


#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstNotasDebito As List(Of EN_NotaDebito)
            Get
                Return _lstNotasDebito
            End Get
        End Property

        Public Property entNotaDebito As EN_NotaDebito
            Get
                Return _entNotaDebito
            End Get
            Set(ByVal Value As EN_NotaDebito)
                _entNotaDebito = Value
            End Set
        End Property

#End Region


#Region "METODOS Y FUNCIONES"


        Public Function Registrar(ByVal _dtbAtributos As DataTable) As Boolean


            Try
                Dim objGeneral As New Util
                Dim input As String = objGeneral.GeneraXML(_dtbAtributos)
                Dim output As String = input.Replace("ñ", "&#241;")
                output = output.Replace("Ñ", "&#209;")
                output = output.Replace(",", "")
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Notadebito_Registrar"

                _objConexion.AddParameter("var_IdNota", _entNotaDebito.Idnota)
                _objConexion.AddParameter("var_SerieNota", _entNotaDebito.SerieNota)
                _objConexion.AddParameter("var_NumeroNota", _entNotaDebito.NumeroNota)
                _objConexion.AddParameter("var_IdCliente", _entNotaDebito.Cliente)
                _objConexion.AddParameter("var_idVendedor", _entNotaDebito.idVendedor)
                _objConexion.AddParameter("var_idMotivo", _entNotaDebito.IdMotivo)
                _objConexion.AddParameter("var_TipoOperacion", _entNotaDebito.TipoOperacion)
                _objConexion.AddParameter("var_codMoneda", _entNotaDebito.idMoneda)
                _objConexion.AddParameter("var_FechaEmision", _entNotaDebito.FechaEmision)
                _objConexion.AddParameter("var_Estado", _entNotaDebito.Estado)
                _objConexion.AddParameter("xml_Atributos", output)
                _objConexion.AddParameter("var_Usuario", _entNotaDebito.Usuario)
                _objConexion.AddParameter("var_IdTipo", _entNotaDebito.IGV)
                _objConexion.AddParameter("num_TotalParcial", _entNotaDebito.totalParcial)
                _objConexion.AddParameter("num_Descuento", _entNotaDebito.Descuento)
                _objConexion.AddParameter("num_SubTotal", _entNotaDebito.Subtotal)
                _objConexion.AddParameter("num_IGV", _entNotaDebito.IGV)
                _objConexion.AddParameter("num_TipoCambio", _entNotaDebito.TipoCambio)
                _objConexion.AddParameter("var_Glosa", _entNotaDebito.Glosa)
                _objConexion.AddParameter("num_Total", _entNotaDebito.Total)


                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function




        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Notadebito_Eliminar"
                _objConexion.AddParameter("var_IdNota", _entNotaDebito.Idnota)

                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Notadebito_Obtener"
                _objConexion.AddParameter("var_IdNota", _entNotaDebito.Idnota)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstNotasDebito = New List(Of EN_NotaDebito)
                While odrDatos.Read
                    _entNotaDebito = New EN_NotaDebito
                    _entNotaDebito.Idnota = odrDatos("var_IdNota")
                    _entNotaDebito.SerieNota = odrDatos("var_SerieNota")
                    _entNotaDebito.Estado = odrDatos("var_Estado")
                    _entNotaDebito.NumeroNota = odrDatos("var_NumeroNota")
                    _entNotaDebito.IdCliente = odrDatos("var_IdCliente")
                    _entNotaDebito.Cliente = odrDatos("var_DesCliente")
                    _entNotaDebito.DireccionCliente = odrDatos("var_Direccion")
                    _entNotaDebito.idVendedor = odrDatos("var_idVendedor")
                    _entNotaDebito.idMoneda = odrDatos("var_codMoneda")
                    _entNotaDebito.IdMotivo = odrDatos("var_idMotivo")
                    _entNotaDebito.Glosa = odrDatos("var_Glosa")
                    _entNotaDebito.TipoOperacion = odrDatos("var_TipoOperacion")
                    _entNotaDebito.IGV = odrDatos("num_Igv")
                    _entNotaDebito.Subtotal = odrDatos("num_SubTotal")
                    _entNotaDebito.Descuento = odrDatos("num_Desc")
                    _entNotaDebito.Total = odrDatos("num_Total")
                    _entNotaDebito.totalParcial = odrDatos("num_TotalParcial")
                    _entNotaDebito.FechaEmision = odrDatos("dtm_FechaEmision")


                    _lstNotasDebito.Add(_entNotaDebito)
                End While

                Return (_lstNotasDebito.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function



        Public Function ObtenerAtributos() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_NotadebitoAtributo_Obtener"
                _objConexion.AddParameter("var_IdNota", _entNotaDebito.Idnota)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstNotasDebito = New List(Of EN_NotaDebito)
                While odrDatos.Read
                    _entNotaDebito = New EN_NotaDebito

                    _lstNotasDebito.Add(_entNotaDebito)
                End While

                Return (_lstNotasDebito.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try

        End Function
        Public Function SerieMayor() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Notadebito_ObtenerMayor"
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstNotasDebito = New List(Of EN_NotaDebito)
                While odrDatos.Read
                    _entNotaDebito = New EN_NotaDebito

                    _entNotaDebito.Maximo = odrDatos("var_Maximo")

                    _lstNotasDebito.Add(_entNotaDebito)
                End While

                Return (_lstNotasDebito.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function


        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Notadebito_Buscar"

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstNotasDebito = New List(Of EN_NotaDebito)

                While odrDatos.Read

                    _entNotaDebito = New EN_NotaDebito
                    _entNotaDebito.Idnota = odrDatos("var_IdNota")
                    _entNotaDebito.SerieNota = odrDatos("var_SerieNota")
                    _entNotaDebito.NumeroNota = odrDatos("var_NumeroNota")

                    _entNotaDebito.IdCliente = odrDatos("var_Cliente")
                    _entNotaDebito.FechaFin = odrDatos("var_FechaInicio")
                    _entNotaDebito.FechaFin = odrDatos("var_FechaFinal")

                    _lstNotasDebito.Add(_entNotaDebito)
                End While

                Return (_lstNotasDebito.Count > 0)

            Catch ex As Exception
                _objError = ex

                Return False
            End Try
        End Function




#End Region


    End Class
End Namespace