Imports EN_ALVINET_CONTA
Namespace REPORTE
    Public Class EN_Comprobante
        Inherits GENERAL.EN_Comprobante

        Private _dblTipoCambio As Double
        Private _strPeriodoInicial As String
        Private _strPeriodoFinal As String
        Private _strFechainicio As String
        Private _strFechaFinal As String


        Public Property TipoCambio As Double
            Get
                Return _dblTipoCambio
            End Get
            Set(ByVal value As Double)
                _dblTipoCambio = value
            End Set
        End Property
        Public Property PeriodoInicial As String
            Get
                Return _strPeriodoInicial
            End Get
            Set(ByVal value As String)
                _strPeriodoInicial = value
            End Set
        End Property
        Public Property PeriodoFinal As String
            Get
                Return _strPeriodoFinal
            End Get
            Set(ByVal value As String)
                _strPeriodoFinal = value
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

