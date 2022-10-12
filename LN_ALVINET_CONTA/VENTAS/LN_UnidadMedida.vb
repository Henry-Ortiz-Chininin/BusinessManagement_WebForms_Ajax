Imports AD_ALVINET_CONTA.CONFIG

Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.VENTAS

Namespace VENTAS


    Public Class LN_UnidadMedida

        Dim _adUnidadMedida As New AD_UnidadMedida()
#Region "Metodos y Funciones"

        Public Function Registrar(ByVal um As EN_UnidadMedida) As Boolean

            Return _adUnidadMedida.Registrar(um)

        End Function

        Public Function Eliminar(ByVal um As EN_UnidadMedida) As Boolean

            Return _adUnidadMedida.Eliminar(um)

        End Function

        Public Function Obtener(ByVal um As EN_UnidadMedida) As List(Of EN_UnidadMedida)

            Return _adUnidadMedida.Obtener(um)

        End Function

        Public Function Listar(ByVal um As EN_UnidadMedida) As List(Of EN_UnidadMedida)

            Return _adUnidadMedida.Listar(um)

        End Function

        Public Function Buscar(ByVal um As EN_UnidadMedida) As EN_UnidadMedida

            Return _adUnidadMedida.Buscar(um)

        End Function

#End Region

    End Class

End Namespace
