
Imports EN_ALVINET_CONTA.CONFIG
Imports AD_ALVINET_CONTA.CONFIG

Namespace CONFIG

    Public Class LN_Articulo

        Dim adArticulo As New AD_Articulo()


        Public Function Registrar(ByVal ar As EN_Articulo) As Boolean

            Return adArticulo.Registrar(ar)

        End Function

        Public Function Eliminar(ByVal ar As EN_Articulo) As Boolean

            Return adArticulo.Eliminar(ar)

        End Function

        Public Function Obtener(ByVal ar As EN_Articulo) As EN_Articulo

            Return adArticulo.Obtener(ar)

        End Function

        Public Function Listar(ByVal ar As EN_Articulo) As List(Of EN_Articulo)

            Return adArticulo.Listar(ar)

        End Function

       
        'OTRAS FUNCIONES
        Public Function Buscar(ByVal ar As EN_Articulo) As EN_Articulo

            Return adArticulo.Buscar(ar)

        End Function

        Public Function Buscar1(ByVal ar As EN_Articulo) As EN_Articulo

            Return adArticulo.Buscar1(ar)

        End Function

        Public Function Obtener1(ByVal ar As EN_Articulo) As EN_Articulo

            Return adArticulo.Obtener1(ar)

        End Function

    End Class

End Namespace


