Imports EN_ALVINET_CONTA.CONFIG

Public Class EN_PanCuentaAutomatico
    Inherits EN_MovimientoBancario

#Region "Reariables"
    Private _strNombre As String = ""
    Private _strIdCuenta As String = ""
    Private _strIOperacion As String = ""
    Private _strId As String = ""

    Private _strIdPlanCuentaAutomatico As String = ""
    Private _strCuenta As String = ""
    Private _strIdOperacion As String = ""
    Private _strDescripcion As String = ""
    Private _strTipo As String = ""
    Private _intCriterioBusqueda As String = 0
    Private _strParametro As String = ""
    Private _strSubParametro As String = ""
    Private _strIdOperacionCuenta As String = ""
#End Region
#Region "Propiedades"
   
    Public Property Id() As String
        Get
            Return _strId
        End Get
        Set(ByVal value As String)
            _strId = value
        End Set
    End Property

   

    Public Property Cuenta() As String
        Get
            Return _strCuenta
        End Get
        Set(ByVal value As String)
            _strCuenta = value
        End Set
    End Property
    Public Property IdPlanCuentaAutomatico() As String
        Get
            Return _strIdPlanCuentaAutomatico
        End Get
        Set(ByVal value As String)
            _strIdPlanCuentaAutomatico = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _strNombre
        End Get
        Set(ByVal value As String)
            _strNombre = value
        End Set
    End Property

    Public Property IdCuenta() As String
        Get
            Return _strIdCuenta
        End Get
        Set(ByVal value As String)
            _strIdCuenta = value
        End Set
    End Property


    Public Property IdOperacionCuenta() As String
        Get
            Return _strIdOperacionCuenta
        End Get
        Set(ByVal value As String)
            _strIdOperacionCuenta = value
        End Set
    End Property

    Public Property IdOperacion() As String
        Get
            Return _strIdOperacion
        End Get
        Set(ByVal value As String)
            _strIdOperacion = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return _strTipo
        End Get
        Set(ByVal value As String)
            _strTipo = value
        End Set
    End Property






    Public Property Descripcion() As String
        Get
            Return _strDescripcion
        End Get
        Set(ByVal value As String)
            _strDescripcion = value
        End Set
    End Property

    Public Property CriterioBusqueda() As Integer
        Get
            Return _intCriterioBusqueda
        End Get
        Set(ByVal value As Integer)
            _intCriterioBusqueda = value
        End Set
    End Property



    Public Property Parametro() As String
        Get
            Return _strParametro
        End Get
        Set(ByVal value As String)
            _strParametro = value
        End Set
    End Property

    Public Property SubParametro() As String
        Get
            Return _strSubParametro
        End Get
        Set(ByVal value As String)
            _strSubParametro = value
        End Set
    End Property
#End Region




End Class
