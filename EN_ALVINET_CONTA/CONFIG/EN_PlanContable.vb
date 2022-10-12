Namespace CONFIG

    Public Class EN_PlanContable
        Inherits EN_Contabilidad
#Region "Variables"
        Private _strIdPlanContable As String = ""
        Private _strFormato As String = ""
        Private _intLongitudNivel1 As Integer = 0
        Private _intLongitudNivel2 As Integer = 0
        Private _intLongitudNivel3 As Integer = 0
        Private _intLongitudNivel4 As Integer = 0
        Private _intLongitudNivel5 As Integer = 0
        Private _intLongitudNivel6 As Integer = 0
        Private _intLongitudNivel7 As Integer = 0
        Private _intLongitudNivel8 As Integer = 0
        Private _strEstado As String = ""


#End Region

#Region "Propiedades"

        Public Property IdPlanContable() As String
            Get
                Return _strIdPlanContable
            End Get
            Set(ByVal value As String)
                _strIdPlanContable = value
            End Set
        End Property

        Public Property Formato() As String
            Get
                Return _strFormato
            End Get
            Set(ByVal value As String)
                _strFormato = value
            End Set
        End Property

        Public Property LongitudNivel1() As Integer
            Get
                Return _intLongitudNivel1
            End Get
            Set(ByVal value As Integer)
                _intLongitudNivel1 = value
            End Set
        End Property

        Public Property LongitudNivel2() As Integer
            Get
                Return _intLongitudNivel2
            End Get
            Set(ByVal value As Integer)
                _intLongitudNivel2 = value
            End Set
        End Property

        Public Property LongitudNivel3() As Integer
            Get
                Return _intLongitudNivel3
            End Get
            Set(ByVal value As Integer)
                _intLongitudNivel3 = value
            End Set
        End Property

        Public Property LongitudNivel4() As Integer
            Get
                Return _intLongitudNivel4
            End Get
            Set(ByVal value As Integer)
                _intLongitudNivel4 = value
            End Set
        End Property
        Public Property LongitudNivel5() As Integer
            Get
                Return _intLongitudNivel5
            End Get
            Set(ByVal value As Integer)
                _intLongitudNivel5 = value
            End Set
        End Property
        Public Property LongitudNivel6() As Integer
            Get
                Return _intLongitudNivel6
            End Get
            Set(ByVal value As Integer)
                _intLongitudNivel6 = value
            End Set
        End Property

        Public Property LongitudNivel7() As Integer
            Get
                Return _intLongitudNivel7
            End Get
            Set(ByVal value As Integer)
                _intLongitudNivel7 = value
            End Set
        End Property
        Public Property LongitudNivel8() As Integer
            Get
                Return _intLongitudNivel8
            End Get
            Set(ByVal value As Integer)
                _intLongitudNivel8 = value
            End Set
        End Property


#End Region

    End Class
End Namespace