Imports AD_ALVINET_CONTA
Imports EN_ALVINET_CONTA
Public Class LN_SubOperacion
#Region "Variables"
    Private _entSubOperacion As EN_SubOperacion
    Private _lstSubOperacion As List(Of EN_SubOperacion)
    Private _objADSubOperacion As New AD_SubOperacion
    Private _objError As New Exception

#End Region
#Region "Propiedades"
    Public ReadOnly Property lstSubOperacion() As List(Of EN_SubOperacion)
        Get
            Return _lstSubOperacion
        End Get

    End Property

    Public Property entSubOperacion() As EN_SubOperacion
        Get
            Return _entSubOperacion
        End Get
        Set(ByVal value As EN_SubOperacion)
            _entSubOperacion = value
        End Set
    End Property
    Public ReadOnly Property objError() As Exception
        Get
            Return _objError
        End Get
    End Property
#End Region
#Region "Metodos y Funciones"
    Public Function Registrar() As Boolean

        If _entSubOperacion.IdEmpresa <> "" AndAlso _entSubOperacion.SubOperacion <> "" _
           AndAlso _entSubOperacion.IdOperacion <> "" Then
            _objADSubOperacion.entOperacion = _entSubOperacion
            _objADSubOperacion.Registrar()
            Return True
        Else
            Return False
        End If

    End Function
    Public Function Eliminar() As Boolean
        If _entSubOperacion.IdSubOperacion <> "" Then
            _objADSubOperacion.entOperacion = _entSubOperacion
            _objADSubOperacion.Eliminar()
            Return True
        Else
            Return False
        End If

    End Function
    Public Function Listar() As Boolean
        Try
            If _entSubOperacion.Idempresa <> "" Then
                _objADSubOperacion.entOperacion = _entSubOperacion
                _objADSubOperacion.Listar()
                _lstSubOperacion = _objADSubOperacion.lstSubOperacion
                Return (_lstSubOperacion.Count > 0)
                Return True
            Else

                Return False
            End If

        Catch ex As Exception
            _objError = ex
            Return False
        End Try
    End Function
    Public Function Listar1() As Boolean
        Try
            If _entSubOperacion.IdOperacion <> "" Then
                _objADSubOperacion.entOperacion = _entSubOperacion
                _objADSubOperacion.Listar1()
                _lstSubOperacion = _objADSubOperacion.lstSubOperacion
                Return (_lstSubOperacion.Count > 0)
                Return True
            Else

                Return False
            End If

        Catch ex As Exception
            _objError = ex
            Return False
        End Try
    End Function
    Public Function ListarxOP() As Boolean
        Try
            If _entSubOperacion.IdOperacion <> "" Then
                _objADSubOperacion.entOperacion = _entSubOperacion
                _objADSubOperacion.ListarXop()
                _lstSubOperacion = _objADSubOperacion.lstSubOperacion
                Return (_lstSubOperacion.Count > 0)
                Return True
            Else

                Return False
            End If

        Catch ex As Exception
            _objError = ex
            Return False
        End Try
    End Function
    Public Function ListarN() As Boolean
        Try
            If _entSubOperacion.Idempresa <> "" Then
                _objADSubOperacion.entOperacion = _entSubOperacion
                _objADSubOperacion.ListarN()
                _lstSubOperacion = _objADSubOperacion.lstSubOperacion
                Return (_lstSubOperacion.Count > 0)
                Return True
            Else

                Return False
            End If

        Catch ex As Exception
            _objError = ex
            Return False
        End Try
    End Function

#End Region

End Class
