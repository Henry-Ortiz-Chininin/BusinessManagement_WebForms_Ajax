
Namespace REPORTE
    Public Class EN_Voucher
        Inherits OPERACION.EN_Voucher

        Private _strCuentaInicio As String
        Private _strCuentaFinal As String

        Private _strFechainicio As String
        Private _strFechaFinal As String

        Public Property CuentaInicio As String
            Get
                Return _strCuentaInicio
            End Get
            Set(ByVal value As String)
                _strCuentaInicio = value
            End Set
        End Property
        Public Property CuentaFinal As String
            Get
                Return _strCuentaFinal
            End Get
            Set(ByVal value As String)
                _strCuentaFinal = value
            End Set
        End Property

        Public Property Fechainicio As String
            Get
                Return _strFechainicio
            End Get
            Set(ByVal value As String)
                _strFechainicio = value
            End Set
        End Property
        Public Property FechaFinal As String
            Get
                Return _strFechaFinal
            End Get
            Set(ByVal value As String)
                _strFechaFinal = value
            End Set
        End Property
    End Class
End Namespace

