Imports AD_ALVINET_CONTA.REPORTE

Namespace REPORTE
    Public Class LN_LibroCompra


        Public Function Obtener(ByVal pint_Agno As Int16, ByVal pint_Mes As Int16) As DataTable
            Dim objConexion As New AD_RegistroCompras

            Return objConexion.Obtener(pint_Agno, pint_Mes)

        End Function

    End Class
End Namespace

