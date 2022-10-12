
Imports EN_ALVINET_CONTA.GENERAL
Imports AD_ALVINET_CONTA.GENERAL

Namespace GENERAL
    Public Class LN_DocumentoCompra

        Dim _objADDocumentoCompras As New AD_DocumentoCompra
        Private _lstDocumentoCompras As New List(Of EN_DocumentoCompra)
        Private _objENDocumentoCompras As EN_DocumentoCompra
        Private _objError As New Exception
        Public Property objError() As Exception
            Get
                Return _objError
            End Get
            Set(ByVal value As Exception)
                _objError = value
            End Set
        End Property

        Public ReadOnly Property lstDocumentoCompra() As List(Of EN_DocumentoCompra)
            Get
                Return _lstDocumentoCompras
            End Get
        End Property
        Public Property objENDocumentoCompras() As EN_DocumentoCompra
            Get
                Return _objENDocumentoCompras
            End Get
            Set(ByVal value As EN_DocumentoCompra)
                _objENDocumentoCompras = value
            End Set
        End Property


        Public Property objADDocumentoCompra() As AD_DocumentoCompra
            Get
                Return _objADDocumentoCompras
            End Get
            Set(ByVal value As AD_DocumentoCompra)
                _objADDocumentoCompras = value
            End Set
        End Property


        Public Function Registrar(ByVal dtbdatos As Data.DataTable) As Boolean

            If _objENDocumentoCompras.Idempresa <> "" AndAlso _objENDocumentoCompras.FechaEmision <> "" AndAlso
                _objENDocumentoCompras.FechaVencimiento <> "" AndAlso _objENDocumentoCompras.Numero <> "" AndAlso _
                _objENDocumentoCompras.IdProveedor <> "" AndAlso _
                _objENDocumentoCompras.Operacion <> "" AndAlso _objENDocumentoCompras.TipoDocumento <> "" AndAlso _
                _objENDocumentoCompras.Subtotal <> 0 AndAlso _objENDocumentoCompras.Total <> 0 Then

                _objADDocumentoCompras.objENDocumentoCompras = _objENDocumentoCompras
                If _objADDocumentoCompras.Registrar(dtbdatos) Then
                    Return True
                Else
                    Return False
                End If

            Else
                Return False
            End If
        End Function
        Public Function Validar(ByVal objENDocumentoCompra As EN_DocumentoCompra) As Boolean

            If objENDocumentoCompra.Numero <> "" AndAlso _
               objENDocumentoCompra.IdProveedor <> "" AndAlso _
               objENDocumentoCompra.IdTipoDocumento <> "" Then
                If _objADDocumentoCompras.Validar(objENDocumentoCompra) Then
                    Return True
                Else
                    Return False
                End If

            Else
                Return False
            End If
        End Function
        Public Function BuscarDocumento(ByVal enDocumentoCompra As EN_DocumentoCompra) As List(Of EN_DocumentoCompra)
            _lstDocumentoCompras = objADDocumentoCompra.BuscarDocumento(enDocumentoCompra)
            Return _lstDocumentoCompras
        End Function

        Public Function Obtener(ByVal enDocumentoCompra As EN_DocumentoCompra) As EN_DocumentoCompra

            Return _objADDocumentoCompras.Obtener(enDocumentoCompra)

        End Function

        Public Function Listar(ByVal enDocumentoCompra As EN_DocumentoCompra) As List(Of EN_DocumentoCompra)
            Return _objADDocumentoCompras.Listar(enDocumentoCompra)
        End Function


        Public Function Buscar(ByVal enDocumentoCompra As EN_DocumentoCompra) As EN_DocumentoCompra

            Return _objADDocumentoCompras.Buscar(enDocumentoCompra)

        End Function
        Public Function BuscarxDocumento() As Boolean
            _objADDocumentoCompras.objENDocumentoCompras = objENDocumentoCompras
            _objADDocumentoCompras.BuscarxDocumento()
            _lstDocumentoCompras = New List(Of EN_DocumentoCompra)
            _lstDocumentoCompras = _objADDocumentoCompras.lstDocumentoCompra
            Return (_lstDocumentoCompras.Count > 0)

        End Function
        Public Function DocumentoListar() As Boolean
            _objADDocumentoCompras.objENDocumentoCompras = objENDocumentoCompras
            _objADDocumentoCompras.DocumentosListar()
            _lstDocumentoCompras = New List(Of EN_DocumentoCompra)
            _lstDocumentoCompras = _objADDocumentoCompras.lstDocumentoCompra
            Return (_lstDocumentoCompras.Count > 0)

        End Function
        Public Function BuscarxDocumentoDetalle() As Boolean
            _objADDocumentoCompras.objENDocumentoCompras = objENDocumentoCompras
            _objADDocumentoCompras.BuscarxDocumentoDetalle()
            _lstDocumentoCompras = New List(Of EN_DocumentoCompra)
            _lstDocumentoCompras = _objADDocumentoCompras.lstDocumentoCompra
            Return (_lstDocumentoCompras.Count > 0)

        End Function
    End Class
End Namespace