Imports AD_ALVINET_CONTA
Imports EN_ALVINET_CONTA
Public Class LN_Libro
#Region "Variables"
    Private _objADLibro As New AD_libro
    Private _objError As New Exception
    Private _lstLibros As List(Of EN_Libro)
    Private _entLibro As New EN_Libro
#End Region

#Region "Propiedades"
    Public ReadOnly Property objError As Exception
        Get
            Return _objError
        End Get
    End Property

    Public ReadOnly Property lstLibros As List(Of EN_Libro)
        Get
            Return _lstLibros
        End Get
    End Property

    Public Property entLibro As EN_Libro
        Get
            Return _entLibro
        End Get
        Set(ByVal Value As EN_Libro)
            _entLibro = Value
        End Set
    End Property
#End Region

#Region "Funciones"
    Public Function Registrar() As Boolean
        If entLibro.IdSunat <> "" AndAlso _
        entLibro.IdLibro <> "" AndAlso _
        entLibro.Descripcion <> "" AndAlso _
        entLibro.Estado <> "" Then
            _objADLibro.entLibro = _entLibro
            Return _objADLibro.Registrar()
        Else
            Return False
        End If
    End Function

    Public Function Listar() As Boolean

        _objADLibro.Listar()
        _lstLibros = _objADLibro.lstLibros
        Return (_lstLibros.Count > 0)

    End Function

    Public Function Eliminar() As Boolean
        If entLibro.IdSunat <> "" AndAlso _
            entLibro.IdLibro <> "" Then
            _objADLibro.entLibro = _entLibro
            Return _objADLibro.Eliminar()
        Else
            Return False
        End If
    End Function
#End Region
End Class
