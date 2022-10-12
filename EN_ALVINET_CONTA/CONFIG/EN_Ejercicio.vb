Namespace CONFIG

    Public Class EN_Ejercicio
        Inherits EN_PlanContable
#Region "Variables"
        Private _strIdEmpresa As String = ""
        Private _strIdEjercicio As String = ""
        Private _dtmFechaIncio As Date
        Private _dtmFechaFinal As Date
        Private _strDescripcion As String = ""
        Private _strAgno As String = ""
#End Region

#Region "Propiedades"

        Public Property IdEjercicio() As String
            Get
                Return _strIdEjercicio
            End Get
            Set(ByVal value As String)
                _strIdEjercicio = value
            End Set
        End Property

        Public Property FechaInicio() As Date
            Get
                Return _dtmFechaIncio
            End Get
            Set(ByVal value As Date)
                _dtmFechaIncio = value
            End Set
        End Property

        Public Property FechaFinal() As Date
            Get
                Return _dtmFechaFinal
            End Get
            Set(ByVal value As Date)
                _dtmFechaFinal = value
            End Set
        End Property

        Public Property Ejercicio() As String
            Get
                Return _strDescripcion
            End Get
            Set(ByVal value As String)
                _strDescripcion = value
            End Set
        End Property

        Public Property Agno() As String
            Get
                Return _strAgno
            End Get
            Set(ByVal value As String)
                _strAgno = value
            End Set
        End Property

#End Region

    End Class
End Namespace