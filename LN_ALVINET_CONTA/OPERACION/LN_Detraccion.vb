
Imports EN_ALVINET_CONTA.OPERACION
Imports AD_ALVINET_CONTA.OPERACION

Namespace OPERACION
    Public Class LN_Detraccion



#Region "Variables"
        Private _objADDetraccion As New AD_Detraccion
        Private _objError As New Exception
        Private _lstDetracciones As List(Of EN_Detraccion)
        Private _entDetraccion As New EN_Detraccion
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstDetracciones As List(Of EN_Detraccion)
            Get
                Return _lstDetracciones
            End Get
        End Property

        Public Property entDetraccion As EN_Detraccion
            Get
                Return _entDetraccion
            End Get
            Set(ByVal Value As EN_Detraccion)
                _entDetraccion = Value
            End Set
        End Property
#End Region

#Region "METODOS Y FUNCIONES"

        Public Function Registrar() As Boolean
            'If entDetraccion.NumeroConstancia <> "" AndAlso _
            'entDetraccion.Idempresa <> "" Then
            _objADDetraccion.entDetraccion = _entDetraccion
            Return _objADDetraccion.Registrar()
            'Else
            'Return False
            'End If
        End Function

        Public Function Listar() As Boolean
            _objADDetraccion.entDetraccion = entDetraccion
            If _objADDetraccion.Listar() = True Then
                _lstDetracciones = _objADDetraccion.lstDetracciones
                Return (_lstDetracciones.Count > 0)
            Else
                Return False
            End If
        End Function




        Public Function Eliminar() As Boolean

            If entDetraccion.NumeroConstancia <> "" AndAlso _
                entDetraccion.RucProveedor <> "" AndAlso _
                entDetraccion.IdEntidadFinanciera <> "" AndAlso _
                entDetraccion.IdOperacion <> "" Then
                'AndAlso _
                '                entDetraccion.BienoServicio <> "" 


                _objADDetraccion.entDetraccion = entDetraccion
                Return _objADDetraccion.Eliminar
            Else
                Return False
            End If
        End Function

        Public Function Buscar() As Boolean

            If _entDetraccion.IdEmpresa Then
                _objADDetraccion.entDetraccion = _entDetraccion
                _objADDetraccion.Buscar()
                _lstDetracciones = _objADDetraccion.lstDetracciones
                Return (_lstDetracciones.Count > 0)
                Return True
            Else
                Return False
            End If



        End Function


        Public Function ListarDetraccion() As Boolean
            _objADDetraccion.entDetraccion = _entDetraccion
            If _objADDetraccion.ListarDetraccion() Then
                _lstDetracciones = _objADDetraccion.lstDetracciones
                Return (_lstDetracciones.Count > 0)
                Return True
            Else
                Return False
            End If
        End Function

#End Region
    End Class
End Namespace
