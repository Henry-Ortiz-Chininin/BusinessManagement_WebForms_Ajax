Namespace GENERAL

    Public Class EN_Moneda
        Inherits EN_Empresa

#Region "Variables"
        Private _strIdEmpresa As String = ""
        Private _strIdMoneda As String = ""
        Private _strDescripcion As String = ""
        Private _strSimbolo As String = ""
        Private _strIdSunat As String = ""
        Private _strRazonSocial As String = ""
      


#End Region

#Region "Propiedades"

       
        Public Property IdSunat() As String
            Get
                Return _strIdSunat
            End Get
            Set(ByVal value As String)
                _strIdSunat = value
            End Set
        End Property

        Public Property IdMoneda() As String
            Get
                Return _strIdMoneda
            End Get
            Set(ByVal value As String)
                _strIdMoneda = value
            End Set
        End Property

        Public Property Moneda() As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property

        Public Property Simbolo() As String
            Get
                Return _strSimbolo
            End Get
            Set(ByVal value As String)
                _strSimbolo = value
            End Set
        End Property

#End Region

    End Class
End Namespace