
Imports EN_ALVINET_CONTA.VENTAS
Imports AD_ALVINET_CONTA.VENTAS



Namespace VENTAS
    Public Class LN_Motivo


#Region "Variables"
        Private _objADDatos As New AD_Motivo
        Private _objError As New Exception
        Private _lstMotivos As List(Of EN_Motivo)
        Private _entMotivo As New EN_Motivo
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstMotivos As List(Of EN_Motivo)
            Get
                Return _lstMotivos
            End Get
        End Property

        Public Property entMotivo As EN_Motivo
            Get
                Return _entMotivo
            End Get
            Set(ByVal Value As EN_Motivo)
                _entMotivo = Value
            End Set
        End Property
#End Region


#Region "Metodo y Funciones"
        Public Function Buscar() As Boolean

            If _entMotivo.Descripcion <> "" Then

                _objADDatos.entMotivo = _entMotivo

                _objADDatos.Buscar()
                _lstMotivos = _objADDatos.lstMotivos
                Return (_lstMotivos.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function Obtener() As Boolean

            If _entMotivo.IdMotivo <> "" Then

                _objADDatos.entMotivo = _entMotivo

                _objADDatos.Obtener()
                _lstMotivos = _objADDatos.lstMotivos
                Return (_lstMotivos.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Registrar() As Boolean
            If entMotivo.IdMotivo <> "" Then

                _objADDatos.entMotivo = _entMotivo
                Return _objADDatos.Registrar()
            Else
                Return False
            End If
        End Function

        Public Function Listar() As Boolean

            'If entMotivo.IdMotivo <> "" Then
            _objADDatos.entMotivo = _entMotivo
            _objADDatos.Listar()
            _lstMotivos = _objADDatos.lstMotivos
            Return (_lstMotivos.Count > 0)
            'Else
            'Return False
            'End If
        End Function
        Public Function Eliminar() As Boolean
            If entMotivo.IdMotivo <> "" Then

                _objADDatos.entMotivo = _entMotivo
                Return _objADDatos.Eliminar()
            Else
                Return False
            End If
        End Function
#End Region




    End Class
End Namespace