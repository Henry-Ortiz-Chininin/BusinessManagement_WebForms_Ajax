Imports EN_ALVINET_CONTA.VENTAS
Imports AD_ALVINET_CONTA.VENTAS




Namespace VENTAS
    Public Class LN_AtributoMotivo


#Region "Variables"
        Private _objADAtributoMotivo As New AD_AtributoMotivo
        Private _objError As New Exception
        Private _lstAtributosMotivo As List(Of EN_AtributoMotivo)
        Private _entAtributoMotivo As New EN_AtributoMotivo
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstAtributosMotivo As List(Of EN_AtributoMotivo)
            Get
                Return _lstAtributosMotivo
            End Get
        End Property

        Public Property entAtributoMotivo As EN_AtributoMotivo
            Get
                Return _entAtributoMotivo
            End Get
            Set(ByVal Value As EN_AtributoMotivo)
                _entAtributoMotivo = Value
            End Set
        End Property
#End Region


#Region "Metodo y Funciones"
        Public Function Buscar() As Boolean

            If _entAtributoMotivo.IdMotivo <> "" Then

                _objADAtributoMotivo.entAtributoMotivo = _entAtributoMotivo

                _objADAtributoMotivo.Buscar()
                _lstAtributosMotivo = _objADAtributoMotivo.lstAtributosMotivo
                Return (_lstAtributosMotivo.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function Obtener() As Boolean

            If _entAtributoMotivo.IdMotivo <> "" Then

                _objADAtributoMotivo.entAtributoMotivo = _entAtributoMotivo

                _objADAtributoMotivo.Obtener()
                _lstAtributosMotivo = _objADAtributoMotivo.lstAtributosMotivo
                Return (_lstAtributosMotivo.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Registrar() As Boolean
            If entAtributoMotivo.IdMotivo <> "" AndAlso _
            entAtributoMotivo.IdMotivoAtributo <> "" Then
                _objADAtributoMotivo.entAtributoMotivo = _entAtributoMotivo
                Return _objADAtributoMotivo.Registrar()
            Else
                Return False
            End If
        End Function



        Public Function Listar() As Boolean

            If entAtributoMotivo.IdMotivo <> "" Then
                _objADAtributoMotivo.entAtributoMotivo = _entAtributoMotivo
                _objADAtributoMotivo.Listar()
                _lstAtributosMotivo = _objADAtributoMotivo.lstAtributosMotivo
                Return (_lstAtributosMotivo.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Eliminar() As Boolean
            If entAtributoMotivo.IdMotivo <> "" AndAlso _
                entAtributoMotivo.IdMotivoAtributo <> "" Then
                _objADAtributoMotivo.entAtributoMotivo = _entAtributoMotivo
                Return _objADAtributoMotivo.Eliminar()
            Else
                Return False
            End If
        End Function
#End Region



    End Class
End Namespace