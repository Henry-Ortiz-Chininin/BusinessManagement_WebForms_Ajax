Imports AD_ALVINET_CONTA.AccesoDatos
Imports EN_ALVINET_CONTA.VENTAS
Imports System.Data
Imports System.Data.SqlClient

Namespace VENTAS

    Public Class AD_Impuesto


        Private _objConexion As AccesoDatosSQLServer
        Private _objError As New Exception
        Private _lstImpuestos As List(Of EN_Impuesto)
        Private _entImpuesto As New EN_Impuesto




#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstImpuestos As List(Of EN_Impuesto)
            Get
                Return _lstImpuestos
            End Get
        End Property

        Public Property entImpuesto As EN_Impuesto
            Get
                Return _entImpuesto
            End Get
            Set(ByVal Value As EN_Impuesto)
                _entImpuesto = Value
            End Set
        End Property

#End Region


#Region "METODOS Y FUNCIONES"

        Public Function Registrar() As Boolean


            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Impuesto_Registrar"
                _objConexion.AddParameter("int_Secuencia", _entImpuesto.Codigo)
                _objConexion.AddParameter("num_Impuesto1", _entImpuesto.Impuesto1)
                _objConexion.AddParameter("num_Impuesto2", _entImpuesto.Impuesto2)
                _objConexion.AddParameter("num_Impuesto3", _entImpuesto.Impuesto3)
                _objConexion.AddParameter("num_Detraccion", _entImpuesto.Detraccion)


                _objConexion.AddParameter("num_Percepcion", _entImpuesto.Percepcion)
                _objConexion.AddParameter("num_Retencion", _entImpuesto.Retencion)
                _objConexion.AddParameter("var_FechaCaducidad", _entImpuesto.FechaCaducidad)
                _objConexion.AddParameter("chr_Estado", _entImpuesto.Estado)
                _objConexion.AddParameter("var_Usuario", _entImpuesto.Usuario)



                _objConexion.EjecutarComando()
                Return True
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function


        Public Function Buscar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Impuesto_Buscar"
                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()
                _lstImpuestos = New List(Of EN_Impuesto)

                While odrDatos.Read

                    _entImpuesto = New EN_Impuesto
                    _entImpuesto.FechaInicio = odrDatos("var_FechaInicio")
                    _entImpuesto.FechaFin = odrDatos("var_FechaFin")
                    _entImpuesto.IdTipo = odrDatos("var_IdTipo")



                    _lstImpuestos.Add(_entImpuesto)
                End While

                Return (_lstImpuestos.Count > 0)

            Catch ex As Exception
                _objError = ex

                Return False
            End Try
        End Function



        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Impuesto_Eliminar"
                _objConexion.AddParameter("int_Secuencia", _entImpuesto.Codigo)

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
                _objConexion.Procedimiento = "SGC_uspe_Impuesto_Obtener"
                _objConexion.AddParameter("int_Secuencia", _entImpuesto.Codigo)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstImpuestos = New List(Of EN_Impuesto)
                While odrDatos.Read
                    _entImpuesto = New EN_Impuesto

                    _entImpuesto.Codigo = odrDatos("int_Secuencia")
                    _entImpuesto.Impuesto1 = odrDatos("num_Impuesto1")
                    _entImpuesto.Impuesto2 = odrDatos("num_Impuesto2")
                    _entImpuesto.Impuesto3 = odrDatos("num_Impuesto3")



                    _entImpuesto.Detraccion = odrDatos("num_Detraccion")
                    _entImpuesto.Percepcion = odrDatos("num_Percepcion")
                    _entImpuesto.Retencion = odrDatos("num_Retencion")
                    _entImpuesto.FechaCaducidad = odrDatos("dtm_FechaVencimiento")
                    _entImpuesto.Estado = odrDatos("chr_Estado")


                    _lstImpuestos.Add(_entImpuesto)
                End While

                Return (_lstImpuestos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function





        Public Function ObtenerImpuesto1() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Impuesto_ObtenerImpuesto1"
                _objConexion.AddParameter("var_IdEmpresa", _entImpuesto.IdEmpresa)

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstImpuestos = New List(Of EN_Impuesto)
                While odrDatos.Read
                    _entImpuesto = New EN_Impuesto


                    _entImpuesto.Impuesto1 = odrDatos("num_Impuesto1")


                    _lstImpuestos.Add(_entImpuesto)
                End While

                Return (_lstImpuestos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function


        Public Function ObtenerImpuesto2() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Impuesto_ObtenerImpuesto2"

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstImpuestos = New List(Of EN_Impuesto)
                While odrDatos.Read
                    _entImpuesto = New EN_Impuesto


                    _entImpuesto.Impuesto2 = odrDatos("num_Impuesto2")


                    _lstImpuestos.Add(_entImpuesto)
                End While

                Return (_lstImpuestos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function


        Public Function ObtenerImpuesto3() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Impuesto_ObtenerImpuesto3"

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstImpuestos = New List(Of EN_Impuesto)
                While odrDatos.Read
                    _entImpuesto = New EN_Impuesto


                    _entImpuesto.Impuesto3 = odrDatos("num_Impuesto3")


                    _lstImpuestos.Add(_entImpuesto)
                End While

                Return (_lstImpuestos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function




        Public Function ObtenerDetraccion() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Impuesto_ObtenerDetraccion"

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstImpuestos = New List(Of EN_Impuesto)
                While odrDatos.Read
                    _entImpuesto = New EN_Impuesto


                    _entImpuesto.Detraccion = odrDatos("num_Detraccion")


                    _lstImpuestos.Add(_entImpuesto)
                End While

                Return (_lstImpuestos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function



        Public Function ObtenerPercepcion() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Impuesto_ObtenerPercepcion"

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstImpuestos = New List(Of EN_Impuesto)
                While odrDatos.Read
                    _entImpuesto = New EN_Impuesto


                    _entImpuesto.Percepcion = odrDatos("num_Percepcion")


                    _lstImpuestos.Add(_entImpuesto)
                End While

                Return (_lstImpuestos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

        Public Function ObtenerRetencion() As Boolean
            Try

                _objConexion = New AccesoDatosSQLServer
                _objConexion.Procedimiento = "SGC_uspe_Impuesto_ObtenerRetencion"

                _objConexion.EjecutarComando()

                Dim odrDatos As SqlDataReader = _objConexion.ObtenerDataReader()

                _lstImpuestos = New List(Of EN_Impuesto)
                While odrDatos.Read
                    _entImpuesto = New EN_Impuesto


                    _entImpuesto.Retencion = odrDatos("num_Retencion")


                    _lstImpuestos.Add(_entImpuesto)
                End While

                Return (_lstImpuestos.Count > 0)
            Catch ex As Exception
                _objError = ex
                Return False
            End Try
        End Function

#End Region


    End Class
End Namespace