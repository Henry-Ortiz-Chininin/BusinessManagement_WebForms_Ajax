Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG
    Public Class LN_CuentaEntidad
#Region "Variables"
        Private _objADCuentaEntidad As New AD_CuentaEntidad
        Private _objError As New Exception
        Private _lstCuentaEntidad As List(Of EN_CuentaEntidad)
        Private _entCuentaEntidad As New EN_CuentaEntidad
#End Region
#Region "Propiedades"

        Public ReadOnly Property objError() As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstCuentaEntidad() As List(Of EN_CuentaEntidad)
            Get
                Return _lstCuentaEntidad
            End Get
        End Property

        Public Property entCuentaEntidad() As EN_CuentaEntidad
            Get
                Return _entCuentaEntidad
            End Get
            Set(ByVal Value As EN_CuentaEntidad)
                _entCuentaEntidad = Value
            End Set
        End Property
#End Region
#Region "Metodos y Funciones "

        Public Function Registrar() As Boolean

            If entCuentaEntidad.IdEmpresa <> "" AndAlso _
                entCuentaEntidad.IdEntidadFinanciera <> "" AndAlso _
                entCuentaEntidad.IdMoneda <> "" AndAlso _
                entCuentaEntidad.NumeroCuenta <> "" Then

                _objADCuentaEntidad.entCuentaEntidad = _entCuentaEntidad
                Return _objADCuentaEntidad.Registrar()
            Else
                Return False
            End If
        End Function

        Public Function Listar() As Boolean
            If entCuentaEntidad.IdEmpresa <> "" Then
                _objADCuentaEntidad.entCuentaEntidad = entCuentaEntidad
                _objADCuentaEntidad.Listar()
                _lstCuentaEntidad = _objADCuentaEntidad.lstCuentaEntidad
                Return (_lstCuentaEntidad.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function ListarDetalle() As Boolean
            If entCuentaEntidad.IdEntidadFinanciera <> "" Then
                _objADCuentaEntidad.entCuentaEntidad = entCuentaEntidad
                _objADCuentaEntidad.ListarDetalle()
                _lstCuentaEntidad = _objADCuentaEntidad.lstCuentaEntidad
                Return (_lstCuentaEntidad.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function Eliminar() As Boolean

            If entCuentaEntidad.Secuencia <> "" AndAlso _
                entCuentaEntidad.IdEmpresa <> "" AndAlso _
                entCuentaEntidad.IdEntidadFinanciera <> "" Then

                _objADCuentaEntidad.entCuentaEntidad = entCuentaEntidad
                Return _objADCuentaEntidad.Eliminar
            Else
                Return False
            End If
        End Function
#End Region

    End Class
End Namespace