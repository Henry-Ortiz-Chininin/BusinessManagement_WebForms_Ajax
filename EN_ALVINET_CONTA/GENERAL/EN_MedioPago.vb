Imports EN_ALVINET_CONTA.CONFIG

Namespace GENERAL

    Public Class EN_MedioPago
        Inherits EN_Empresa


#Region "Variables"

        Private _strIdMedioPago As String = ""
        Private _strDescripcion As String = ""
        Private _strCodigosunat As String = ""
        Private _strSimbolo As String = ""
#End Region

#Region "Propiedades"

        Public Property Simbolo() As String
            Get
                Return _strSimbolo
            End Get
            Set(ByVal value As String)
                _strSimbolo = value
            End Set
        End Property

        Public Property IdMedioPago() As String
            Get
                Return _strIdMedioPago
            End Get
            Set(ByVal value As String)
                _strIdMedioPago = value
            End Set
        End Property

        Public Property CodigoSunat() As String
            Get
                Return _strCodigosunat
            End Get
            Set(ByVal value As String)
                _strCodigosunat = value
            End Set
        End Property

        Public Property MedioPago() As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property

#End Region

    End Class
End Namespace