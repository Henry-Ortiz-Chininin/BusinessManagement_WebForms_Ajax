
Namespace REPORTE
    Public Class EN_LibroDiario51

        Private _strIdOperacion As String
        Private _strIdContabilidad As String
        Private _strIdEjercicio As String
        Private _strIdAsiento As String
        Private _strCodigoUnico As String
        Private _dtmFecha As DateTime
        Private _strGlosa As String
        Private _strCuentaContable As String
        Private _strDenominacionCuenta As String
        Private _strEjercicio As String
        Private _strOperacion As String
        Private _intMes As Int16
        Private _dblDebe As Double
        Private _dblHaber As Double


        Public Property IdOperacion As String
            Get
                Return _strIdOperacion
            End Get
            Set(ByVal value As String)
                _strIdOperacion = value
            End Set
        End Property
        Public Property IdContabilidad As String
            Get
                Return _strIdContabilidad
            End Get
            Set(ByVal value As String)
                _strIdContabilidad = value
            End Set
        End Property
        Public Property IdEjercicio As String
            Get
                Return _strIdEjercicio
            End Get
            Set(ByVal value As String)
                _strIdEjercicio = value
            End Set
        End Property
        Public Property IdAsiento As String
            Get
                Return _strIdAsiento
            End Get
            Set(ByVal value As String)
                _strIdAsiento = value
            End Set
        End Property
        Public Property CodigoUnico As String
            Get
                Return _strCodigoUnico
            End Get
            Set(ByVal value As String)
                _strCodigoUnico = value
            End Set
        End Property
        Public Property Fecha As DateTime
            Get
                Return _dtmFecha
            End Get
            Set(ByVal value As DateTime)
                _dtmFecha = value
            End Set
        End Property
        Public Property Glosa As String
            Get
                Return _strGlosa
            End Get
            Set(ByVal value As String)
                _strGlosa = value
            End Set
        End Property
        Public Property CuentaContable As String
            Get
                Return _strCuentaContable
            End Get
            Set(ByVal value As String)
                _strCuentaContable = value
            End Set
        End Property
        Public Property DenominacionCuenta As String
            Get
                Return _strDenominacionCuenta
            End Get
            Set(ByVal value As String)
                _strDenominacionCuenta = value
            End Set
        End Property
        Public Property Ejercicio As String
            Get
                Return _strEjercicio
            End Get
            Set(ByVal value As String)
                _strEjercicio = value
            End Set
        End Property
        Public Property Operacion As String
            Get
                Return _strOperacion
            End Get
            Set(ByVal value As String)
                _strOperacion = value
            End Set
        End Property
        Public Property Mes As Int16
            Get
                Return _intMes
            End Get
            Set(ByVal value As Int16)
                _intMes = value
            End Set
        End Property
        Public Property Debe As Double
            Get
                Return _dblDebe
            End Get
            Set(ByVal value As Double)
                _dblDebe = value
            End Set
        End Property
        Public Property Haber As Double
            Get
                Return _dblHaber
            End Get
            Set(ByVal value As Double)
                _dblHaber = value
            End Set
        End Property

    End Class
End Namespace

