
Namespace VENTAS
    Public Class EN_Impuesto
        Inherits GENERAL.EN_Empresa

#Region "VARIABLES"
        Private _strIdEmpresa As String = ""
        Private _intCodigo As String = ""
        Private _dblImpuesto1 As Double = 0
        Private _dblImpuesto2 As Double = 0
        Private _dblImpuesto3 As Double = 0
        Private _dblDetraccion As Double = 0
        Private _dblPercepcion As Double = 0
        Private _dblRetencion As Double = 0
        Private _strFechaCaducidad As String = ""
        Private _strFechaInicio As String = ""
        Private _strFechaFin As String = ""
        Private _strIdTipo As String = ""

        Private _strEstado As String = ""
        Private _dtbDatos As DataTable
        Private _strUsuario As String = ""


#End Region
#Region "PROPIEDADES"
        Public Property IdEmpresa() As String
            Get
                Return _strIdEmpresa
            End Get
            Set(ByVal value As String)
                _strIdEmpresa = value
            End Set
        End Property
        Public Property Codigo() As String
            Get
                Return _intCodigo
            End Get
            Set(ByVal value As String)
                _intCodigo = value
            End Set
        End Property
        Public Property Impuesto1() As Double
            Get
                Return _dblImpuesto1
            End Get
            Set(ByVal value As Double)
                _dblImpuesto1 = value
            End Set
        End Property
        Public Property Impuesto2() As Double
            Get
                Return _dblImpuesto2
            End Get
            Set(ByVal value As Double)
                _dblImpuesto2 = value
            End Set
        End Property
        Public Property Impuesto3() As Double
            Get
                Return _dblImpuesto3
            End Get
            Set(ByVal value As Double)
                _dblImpuesto3 = value
            End Set
        End Property
        Public Property Detraccion() As Double
            Get
                Return _dblDetraccion
            End Get
            Set(ByVal value As Double)
                _dblDetraccion = value
            End Set
        End Property
        Public Property Percepcion() As Double
            Get
                Return _dblPercepcion
            End Get
            Set(ByVal value As Double)
                _dblPercepcion = value
            End Set
        End Property
        Public Property Retencion() As Double
            Get
                Return _dblRetencion
            End Get
            Set(ByVal value As Double)
                _dblRetencion = value
            End Set
        End Property
        Public Property FechaCaducidad() As String
            Get
                Return _strFechaCaducidad
            End Get
            Set(ByVal value As String)
                _strFechaCaducidad = value
            End Set
        End Property
        Public Property IdTipo() As String
            Get
                Return _strIdTipo
            End Get
            Set(ByVal value As String)
                _strIdTipo = value
            End Set
        End Property
        Public Property FechaInicio() As String
            Get
                Return _strFechaInicio
            End Get
            Set(ByVal value As String)
                _strFechaInicio = value
            End Set
        End Property
        Public Property FechaFin() As String
            Get
                Return _strFechaFin
            End Get
            Set(ByVal value As String)
                _strFechaFin = value
            End Set
        End Property
        Public Property Estado() As String
            Get
                Return _strEstado
            End Get
            Set(ByVal value As String)
                _strEstado = value
            End Set
        End Property
        Public Property Datos() As DataTable
            Get
                Return _dtbDatos
            End Get
            Set(ByVal value As DataTable)
                _dtbDatos = value
            End Set
        End Property
        Public Property Usuario() As String
            Get
                Return _strUsuario
            End Get
            Set(ByVal value As String)
                _strUsuario = value
            End Set
        End Property

#End Region

    End Class
End Namespace