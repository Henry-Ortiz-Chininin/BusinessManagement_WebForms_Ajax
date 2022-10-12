Imports System.Xml.XPath

Namespace OPERACION
    Public Class EN_OrdenServicio
#Region "VARIABLE"
        Private _strIdOrdenServicio As String = ""
        Private _strFechaEmision As String = ""
        Private _strIdDepartamento As String = ""
        Private _strDepartamento As String = ""
        Private _strIdCliente As String = ""
        Private _strRazonSocial As String = ""
        Private _strLugarOperacion As String = ""
        Private _strTrabaSolicitado As String = ""
        Private _strTelefono As String = ""
        Private _strTrabajoEfectuado As String = ""
        Private _strOperador As String = ""
        Private _strLicencia As String = ""
        Private _strRiger As String = ""
        Private _strAyudante As String = ""
        Private _strPlaca_Grua As String = ""
        Private _strIdTipoServicio As String = ""
        Private _strTipoServicio As String = ""
        Private _intHoraSalidaBase As Integer = 0
        Private _intHoraLlegadaObra As Integer = 0
        Private _intHoraInicioOperacion As Integer = 0
        Private _intHoraTerminoOperacion As Integer = 0
        Private _intHoraSalidaObra As Integer = 0
        Private _intHoraLlegadaBase As Integer = 0
        Private _dblTarifaHora As Double = 0
        Private _dblImporteTotal As Double = 0
        Private _strIdMoneda As String = ""
        Private _strMoneda As String = ""
        Private _dblIgv As Double = 0
        Private _strObservacion As String = ""
        Private _strEstado As String = ""

        Private _strFechaInicial As String = ""
        Private _strFechaFinal As String = ""
        Private _strMensaje As String = ""
#End Region

#Region "PROPIEDADES"
        Public Property IdOrdenServicio() As String
            Get
                Return _strIdOrdenServicio
            End Get
            Set(ByVal value As String)
                _strIdOrdenServicio = value
            End Set
        End Property
        Public Property RazonSocial() As String
            Get
                Return _strRazonSocial
            End Get
            Set(ByVal value As String)
                _strRazonSocial = value
            End Set
        End Property
        Public Property IdCliente() As String
            Get
                Return _strIdCliente
            End Get
            Set(ByVal value As String)
                _strIdCliente = value
            End Set
        End Property
        Public Property IdDepartamento() As String
            Get
                Return _strIdDepartamento
            End Get
            Set(ByVal value As String)
                _strIdDepartamento = value
            End Set
        End Property
        Public Property Departamento() As String
            Get
                Return _strDepartamento
            End Get
            Set(ByVal value As String)
                _strDepartamento = value
            End Set
        End Property
        Public Property FechaEmision() As String
            Get
                Return _strFechaEmision
            End Get
            Set(ByVal value As String)
                _strFechaEmision = value
            End Set
        End Property
        Public Property LugarOperacion() As String
            Get
                Return _strLugarOperacion
            End Get
            Set(ByVal value As String)
                _strLugarOperacion = value
            End Set
        End Property
        Public Property TrabaSolicitante() As String
            Get
                Return _strTrabaSolicitado
            End Get
            Set(ByVal value As String)
                _strTrabaSolicitado = value
            End Set
        End Property
        Public Property Telefono() As String
            Get
                Return _strTelefono
            End Get
            Set(ByVal value As String)
                _strTelefono = value
            End Set
        End Property
        Public Property TrabajoEfectuado() As String
            Get
                Return _strTrabajoEfectuado
            End Get
            Set(ByVal value As String)
                _strTrabajoEfectuado = value
            End Set
        End Property
        Public Property Operador() As String
            Get
                Return _strOperador
            End Get
            Set(ByVal value As String)
                _strOperador = value
            End Set
        End Property
        Public Property Licencia() As String
            Get
                Return _strLicencia
            End Get
            Set(ByVal value As String)
                _strLicencia = value
            End Set
        End Property
        Public Property Riger() As String
            Get
                Return _strRiger
            End Get
            Set(ByVal value As String)
                _strRiger = value
            End Set
        End Property
        Public Property Ayudante() As String
            Get
                Return _strAyudante
            End Get
            Set(ByVal value As String)
                _strAyudante = value
            End Set
        End Property
        Public Property Placa_Grua() As String
            Get
                Return _strPlaca_Grua
            End Get
            Set(ByVal value As String)
                _strPlaca_Grua = value
            End Set
        End Property
        Public Property IdTipoServicio() As String
            Get
                Return _strIdTipoServicio
            End Get
            Set(ByVal value As String)
                _strIdTipoServicio = value
            End Set
        End Property
        Public Property TipoServicio() As String
            Get
                Return _strTipoServicio
            End Get
            Set(ByVal value As String)
                _strTipoServicio = value
            End Set
        End Property
        Public Property HoraSalidaBase() As Integer
            Get
                Return _intHoraSalidaBase
            End Get
            Set(ByVal value As Integer)
                _intHoraSalidaBase = value
            End Set
        End Property
        Public Property HoraLlegadaObra() As Integer
            Get
                Return _intHoraLlegadaObra
            End Get
            Set(ByVal value As Integer)
                _intHoraLlegadaObra = value
            End Set
        End Property
        Public Property HoraInicioOperacion() As Integer
            Get
                Return _intHoraInicioOperacion
            End Get
            Set(ByVal value As Integer)
                _intHoraInicioOperacion = value
            End Set
        End Property
        Public Property HoraTerminoOperacion() As Integer
            Get
                Return _intHoraTerminoOperacion
            End Get
            Set(ByVal value As Integer)
                _intHoraTerminoOperacion = value
            End Set
        End Property
        Public Property HoraSalidaObra() As Integer
            Get
                Return _intHoraSalidaObra
            End Get
            Set(ByVal value As Integer)
                _intHoraSalidaObra = value
            End Set
        End Property
        Public Property HoraLlegadaBase() As Integer
            Get
                Return _intHoraLlegadaBase
            End Get
            Set(ByVal value As Integer)
                _intHoraLlegadaBase = value
            End Set
        End Property
        Public ReadOnly Property TiempoRecorrido() As Integer
            Get
                Return (HoraLlegadaObra - HoraSalidaBase) + (HoraLlegadaBase - HoraSalidaObra)
            End Get
        End Property
        Public ReadOnly Property TiempoTrabajo() As Integer
            Get
                Return (HoraTerminoOperacion - HoraInicioOperacion)
            End Get
        End Property
        Public Property TarifaHora() As Double
            Get
                Return _dblTarifaHora
            End Get
            Set(ByVal value As Double)
                _dblTarifaHora = value
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
                Return _strMoneda
            End Get
            Set(ByVal value As String)
                _strMoneda = value
            End Set
        End Property
        Public Property Igv() As Double
            Get
                Return _dblIgv
            End Get
            Set(ByVal value As Double)
                _dblIgv = value
            End Set
        End Property
        Public Property Observacion() As String
            Get
                Return _strObservacion
            End Get
            Set(ByVal value As String)
                _strObservacion = value
            End Set
        End Property
        Public Property Estado As String
            Get
                Return _strEstado
            End Get
            Set(ByVal value As String)
                _strEstado = value
            End Set
        End Property
        Public ReadOnly Property TiempoFacturar As Double
            Get
                Return TiempoRecorrido + TiempoTrabajo
            End Get
        End Property
        Public ReadOnly Property TotalFacturar As Double
            Get
                Return (TarifaHora * Int(CDec(TiempoFacturar / 3600))) + (TarifaHora * ((TiempoFacturar Mod 3600) / 60))
            End Get
        End Property
        Public Property FechaFinal() As String
            Get
                Return _strFechaFinal
            End Get
            Set(ByVal value As String)
                _strFechaFinal = value
            End Set
        End Property
        Public Property FechaInicio() As String
            Get
                Return _strFechaInicial
            End Get
            Set(ByVal value As String)
                _strFechaInicial = value
            End Set
        End Property
        Public Property Mensaje() As String
            Get
                Return _strMensaje
            End Get
            Set(ByVal value As String)
                _strMensaje = value
            End Set
        End Property
        Public Property ImporteTotal() As Double
            Get
                Return _dblImporteTotal
            End Get
            Set(ByVal value As Double)
                _dblImporteTotal = value
            End Set
        End Property
#End Region

    End Class

End Namespace
