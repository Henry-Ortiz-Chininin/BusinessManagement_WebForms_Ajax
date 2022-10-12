Namespace CONFIG

    Public Class EN_EjercicioMes
        Inherits EN_EjercicioEmpresa

#Region "Variables"
        Private _strIdempresa As String = ""
        Private _strIdEjercicioMes As String = ""
        Private _strIdEjercicioEmpresa As String = ""
        Private _dtmFechaInicio As Date
        Private _dtmFechaFinal As Date
        Private _strDescripcion As String = ""
        Private _strEstado As String = ""
#End Region

#Region "Propiedades"

        Public Property IdEjercicioMes() As String
            Get
                Return _strIdEjercicioMes
            End Get
            Set(ByVal value As String)
                _strIdEjercicioMes = value
            End Set
        End Property

        Public Property EjercicioMes() As String
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