
Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.GENERAL


Namespace GENERAL
    Public Class LN_Detalle
        Dim _adDetalle As New AD_Detalle()

        Public Function Listar(ByVal detalleDocumento As EN_CompraDetalle) As List(Of EN_CompraDetalle)

            Return _adDetalle.Listar(detalleDocumento)

        End Function
    End Class
End Namespace

