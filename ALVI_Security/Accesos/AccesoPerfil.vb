Imports AccesoDatos

Namespace Accesos
    Public Class AccesoPerfil
#Region "VARIABLES"
        Private _strIdAccesoTipo As String
        Private _intIdGrupo As Int16
        Private _intSecuencia As Int16

        Private _strEstado As String
        Private _dtbDatos As DataTable
        Private _strUsuario As String
        Private _exError As Exception
        Private _objConexion As AccesoDatos.AccesoDatosSQLServer
        ' AccesoDatosVBSQLServer

#End Region

#Region "PROPIEDADES"

        Public Property IdAccesoTipo() As String
            Get
                Return _strIdAccesoTipo
            End Get
            Set(ByVal value As String)
                _strIdAccesoTipo = value
            End Set
        End Property
        Public Property IdGrupo() As Int16
            Get
                Return _intIdGrupo
            End Get
            Set(ByVal value As Int16)
                _intIdGrupo = value
            End Set
        End Property
        Public Property Secuencia() As Int16
            Get
                Return _intSecuencia
            End Get
            Set(ByVal value As Int16)
                _intSecuencia = value
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
        Public Function Registrar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_IdAccesoTipo", _strIdAccesoTipo, _
                                                 "int_IdGrupo", _intIdGrupo, _
                                                 "int_Secuencia", _intSecuencia, _
                                                "var_Usuario", _strUsuario}
                _objConexion.EjecutarComando("SGC_usps_AccesoPerfil_Registrar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Eliminar() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_IdAccesoTipo", _strIdAccesoTipo, _
                                                 "int_IdGrupo", _intIdGrupo, _
                                                 "int_Secuencia", _intSecuencia}
                _objConexion.EjecutarComando("SGC_usps_AccesoPerfil_Eliminar", objParametros)

                Return True
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Obtener() As Boolean
            Try
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                Dim objParametros() As String = {"chr_IdAccesoTipo", _strIdAccesoTipo, _
                                                 "int_IdGrupo", _intIdGrupo, _
                                                 "int_Secuencia", _intSecuencia}
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usps_AccesoPerfil_Obtener", objParametros)
                If _dtbDatos.Rows.Count > 0 Then
                    _strIdAccesoTipo = _dtbDatos.Rows(0)("chr_IdAccesoTipo")
                    _intIdGrupo = _dtbDatos.Rows(0)("int_IdGrupo")
                    _intSecuencia = _dtbDatos.Rows(0)("int_Secuencia")

                End If
                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function Listar() As Boolean
            Try
                Dim objParametros() As String = {"chr_IdAccesoTipo", _strIdAccesoTipo, _
                                                 "int_IdGrupo", _intIdGrupo}
                _objConexion = New AccesoDatos.AccesoDatosSQLServer
                _dtbDatos = _objConexion.ObtenerDataTable("SGC_usps_AccesoPerfil_Listar", objParametros)

                Return (_dtbDatos.Rows.Count > 0)
            Catch ex As Exception
                Me._exError = ex
                Return False
            End Try
        End Function

        Public Function FiltrarAccesos(ByVal dtbDatosOrigen As DataTable, ByVal pint_IdGrupo As Int16, _
                                       ByVal pstrIdAccesoTipo As String, ByVal pstrDiscriminante As String) As Data.DataTable
            Dim dtbDatos As Data.DataTable = dtbDatosOrigen

            Dim objAccesoGrupo As New ALVI_Security.Accesos.AccesoPerfil
            objAccesoGrupo.IdGrupo = pint_IdGrupo
            objAccesoGrupo.IdAccesoTipo = pstrIdAccesoTipo
            If objAccesoGrupo.Listar = True Then
                Dim objAccesoValor As New ALVI_Security.Accesos.Acceso

                dtbDatos = dtbDatosOrigen.Clone
                For Each dtrItem As Data.DataRow In objAccesoGrupo.Datos.Rows
                    objAccesoValor.IdAccesoTipo = dtrItem("chr_IdAccesoTipo")
                    objAccesoValor.Secuencia = dtrItem("int_Secuencia")
                    If objAccesoValor.Obtener Then
                        For Each dtrDato As Data.DataRow In dtbDatosOrigen.Select(pstrDiscriminante & "='" & objAccesoValor.Descripcion & "'")
                            dtbDatos.LoadDataRow(dtrDato.ItemArray, True)
                            dtbDatos.AcceptChanges()
                        Next
                    End If
                Next
            End If

            Return dtbDatos
        End Function

#End Region
    End Class

End Namespace