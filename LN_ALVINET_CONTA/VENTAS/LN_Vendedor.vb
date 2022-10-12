Imports EN_ALVINET_CONTA.VENTAS
Imports AD_ALVINET_CONTA.VENTAS
Imports AD_ALVINET_CONTA


Namespace VENTAS
    Public Class LN_Vendedor

#Region "Variables"
        Private _objADDatos As New AD_Vendedor
        Private _objError As New Exception
        Private _lstVendedores As List(Of EN_Vendedor)
        Private _entVendedor As New EN_Vendedor
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property


        Public ReadOnly Property lstVendedores As List(Of EN_Vendedor)
            Get
                Return _lstVendedores
            End Get
        End Property

        Public Property entVendedor As EN_Vendedor
            Get
                Return _entVendedor
            End Get
            Set(ByVal Value As EN_Vendedor)
                _entVendedor = Value
            End Set
        End Property
#End Region


#Region "Metodo y Funciones"


        Public Function Obtener() As Boolean

            If _entVendedor.IdVendedor <> "" Then

                _objADDatos.entVendedor = _entVendedor

                _objADDatos.Obtener()
                _lstVendedores = _objADDatos.lstVendedores
                Return (_lstVendedores.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Registrar() As Boolean
            If entVendedor.IdVendedor <> "" Then
                _objADDatos.entVendedor = _entVendedor
                Return _objADDatos.Registrar()
            Else
                Return False
            End If
        End Function

        Public Function Eliminar() As Boolean
            If entVendedor.IdVendedor <> "" Then
                _objADDatos.entVendedor = _entVendedor
                Return _objADDatos.Eliminar()
            Else
                Return False
            End If
        End Function



        Public Function Listar() As Boolean

            'If entVendedor.IdVendedor <> "" Then
            _objADDatos.entVendedor = _entVendedor
            _objADDatos.Listar()
            _lstVendedores = _objADDatos.lstVendedores
            Return (_lstVendedores.Count > 0)
            'Else
            'Return False
            'End If
        End Function
#End Region


    End Class
End Namespace