Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.VENTAS
Imports System.Data
Imports System.Data.SqlClient
Imports EN_ALVINET_CONTA
Imports AD_ALVINET_CONTA.GENERAL

Namespace VENTAS


    Public Class AD_NotaCredito



        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstNotasCredito As List(Of EN_NotaCredito)
        Private _entNotaCredito As New EN_NotaCredito
        Private _dtbAtributos As DataTable


#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstNotasCredito As List(Of EN_NotaCredito)
            Get
                Return _lstNotasCredito
            End Get
        End Property

        Public Property entNotaCredito As EN_NotaCredito
            Get
                Return _entNotaCredito
            End Get
            Set(ByVal Value As EN_NotaCredito)
                _entNotaCredito = Value
            End Set
        End Property

#End Region


#Region "METODOS Y FUNCIONES"

        Public Function Registrar(ByVal _dtbAtributos As DataTable) As Boolean

            Dim objGeneral As New Util
            Dim input As String = objGeneral.GeneraXML(_dtbAtributos)
            Dim output As String = input.Replace("ñ", "&#241;")
            output = output.Replace("Ñ", "&#209;")
            output = output.Replace(",", "")
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_NotaCredito_Registrar"

                _objConexion.AddParameter("var_IdNota", _entNotaCredito.Idnota)
                _objConexion.AddParameter("var_SerieNota", _entNotaCredito.SerieNota)
                _objConexion.AddParameter("var_NumeroNota", _entNotaCredito.NumeroNota)
                _objConexion.AddParameter("var_IdCliente", _entNotaCredito.Cliente)
                _objConexion.AddParameter("var_idVendedor", _entNotaCredito.idVendedor)
                _objConexion.AddParameter("var_idMotivo", _entNotaCredito.IdMotivo)
                _objConexion.AddParameter("var_TipoOperacion", _entNotaCredito.TipoOperacion)
                _objConexion.AddParameter("var_codMoneda", _entNotaCredito.idMoneda)

                _objConexion.AddParameter("var_FechaEmision", _entNotaCredito.FechaEmision)

                _objConexion.AddParameter("var_Estado", _entNotaCredito.Estado)

                _objConexion.AddParameter("xml_Atributos", output)

                _objConexion.AddParameter("var_Usuario", _entNotaCredito.Usuario)
                _objConexion.AddParameter("var_IdTipo", _entNotaCredito.IGV)

                _objConexion.AddParameter("num_TotalParcial", _entNotaCredito.totalParcial)
                _objConexion.AddParameter("num_Descuento", _entNotaCredito.Descuento)
                _objConexion.AddParameter("num_SubTotal", _entNotaCredito.Subtotal)
                _objConexion.AddParameter("num_IGV", _entNotaCredito.IGV)
                _objConexion.AddParameter("num_TipoCambio", _entNotaCredito.TipoCambio)
                _objConexion.AddParameter("var_Glosa", _entNotaCredito.Glosa)
                _objConexion.AddParameter("num_Total", _entNotaCredito.Total)


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
                _objConexion.Procedimiento = "SGC_uspe_NotaCredito_Eliminar"
                _objConexion.AddParameter("var_IdNota", _entNotaCredito.Idnota)

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
                _objConexion.Procedimiento = "SGC_uspe_NotaCredito_Obtener"
                _objConexion.AddParameter("var_IdNota", _entNotaCredito.Idnota)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstNotasCredito = New List(Of EN_NotaCredito)
                While odrDatos.Read
                    _entNotaCredito = New EN_NotaCredito

                    _entNotaCredito.Idnota = odrDatos("var_IdNota")
                    _entNotaCredito.SerieNota = odrDatos("var_SerieNota")
                    _entNotaCredito.Estado = odrDatos("var_Estado")
                    _entNotaCredito.NumeroNota = odrDatos("var_NumeroNota")

                    _entNotaCredito.IdCliente = odrDatos("var_IdCliente")
                    _entNotaCredito.Cliente = odrDatos("var_DesCliente")
                    _entNotaCredito.DireccionCliente = odrDatos("var_Direccion")
                    _entNotaCredito.idVendedor = odrDatos("var_idVendedor")
                    _entNotaCredito.idMoneda = odrDatos("var_codMoneda")
                    _entNotaCredito.IdMotivo = odrDatos("var_idMotivo")
                    _entNotaCredito.Glosa = odrDatos("var_Glosa")

                    _entNotaCredito.TipoOperacion = odrDatos("var_TipoOperacion")
                    _entNotaCredito.IGV = odrDatos("num_Igv")
                    _entNotaCredito.Subtotal = odrDatos("num_SubTotal")
                    _entNotaCredito.Descuento = odrDatos("num_Desc")


                    _entNotaCredito.Total = odrDatos("num_Total")
                    _entNotaCredito.totalParcial = odrDatos("num_TotalParcial")

                    _entNotaCredito.FechaEmision = odrDatos("dtm_FechaEmision")


                    _lstNotasCredito.Add(_entNotaCredito)
                End While

                Return (_lstNotasCredito.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function




        Public Function ObtenerAtributos() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_NotaCreditoAtributo_Obtener"
                _objConexion.AddParameter("var_IdNota", _entNotaCredito.Idnota)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstNotasCredito = New List(Of EN_NotaCredito)
                While odrDatos.Read
                    _entNotaCredito = New EN_NotaCredito

                    _lstNotasCredito.Add(_entNotaCredito)
                End While

                Return (_lstNotasCredito.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function



        Public Function SerieMayor() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_NotaCredito_ObtenerMayor"
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstNotasCredito = New List(Of EN_NotaCredito)
                While odrDatos.Read
                    _entNotaCredito = New EN_NotaCredito

                    _entNotaCredito.Maximo = odrDatos("var_Maximo")

                    _lstNotasCredito.Add(_entNotaCredito)
                End While

                Return (_lstNotasCredito.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function



        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_NotaCredito_Buscar"

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstNotasCredito = New List(Of EN_NotaCredito)

                While odrDatos.Read

                    _entNotaCredito = New EN_NotaCredito
                    _entNotaCredito.Idnota = odrDatos("var_IdNota")
                    _entNotaCredito.SerieNota = odrDatos("var_SerieNota")
                    _entNotaCredito.NumeroNota = odrDatos("var_NumeroNota")

                    _entNotaCredito.IdCliente = odrDatos("var_Cliente")
                    _entNotaCredito.FechaFin = odrDatos("var_FechaInicio")
                    _entNotaCredito.FechaFin = odrDatos("var_FechaFinal")

                    _lstNotasCredito.Add(_entNotaCredito)
                End While

                Return (_lstNotasCredito.Count > 0)

            Catch ex As Exception
                _objError = ex

                Return False
            End Try
        End Function

#End Region

    End Class
End Namespace