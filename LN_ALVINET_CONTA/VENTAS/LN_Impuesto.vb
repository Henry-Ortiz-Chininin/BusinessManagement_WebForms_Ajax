Imports EN_ALVINET_CONTA.VENTAS
Imports AD_ALVINET_CONTA.VENTAS


Namespace VENTAS
    Public Class LN_Impuesto



#Region "Variables"
        Private _objADDatos As New AD_Impuesto
        Private _objError As New Exception
        Private _lstImpuestos As List(Of EN_Impuesto)
        Private _entImpuesto As New EN_Impuesto
#End Region
#Region "Propiedades"
        Public ReadOnly Property objError As Exception
            Get
                Return _objError
            End Get
        End Property

        Public ReadOnly Property lstImpuestos As List(Of EN_Impuesto)
            Get
                Return _lstImpuestos
            End Get
        End Property

        Public Property entImpuesto As EN_Impuesto
            Get
                Return _entImpuesto
            End Get
            Set(ByVal Value As EN_Impuesto)
                _entImpuesto = Value
            End Set
        End Property
#End Region


#Region "METODOS Y FUNCIONES"
        Public Function Buscar() As Boolean

            If _entImpuesto.FechaInicio <> "" AndAlso
                _entImpuesto.FechaFin <> "" AndAlso
                _entImpuesto.IdTipo <> "" Then
                _objADDatos.entImpuesto = _entImpuesto
                _objADDatos.Buscar()
                _lstImpuestos = _objADDatos.lstImpuestos
                Return (_lstImpuestos.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function Obtener() As Boolean

            If _entImpuesto.Codigo <> "" Then

                _objADDatos.entImpuesto = _entImpuesto

                _objADDatos.Obtener()
                _lstImpuestos = _objADDatos.lstImpuestos
                Return (_lstImpuestos.Count > 0)
            Else
                Return False
            End If
        End Function
        Public Function Registrar() As Boolean
            If entImpuesto.Codigo <> "" Then
                _objADDatos.entImpuesto = _entImpuesto
                Return _objADDatos.Registrar()
            Else
                Return False
            End If
        End Function


        Public Function Eliminar() As Boolean
            If entImpuesto.Codigo <> "" Then
                _objADDatos.entImpuesto = _entImpuesto
                Return _objADDatos.Eliminar()
            Else
                Return False
            End If
        End Function


        Public Function ObtenerImpuesto1() As Boolean

            If _entImpuesto.Impuesto1.ToString() <> "" Then

                _objADDatos.entImpuesto = _entImpuesto

                _objADDatos.ObtenerImpuesto1()
                _lstImpuestos = _objADDatos.lstImpuestos
                Return (_lstImpuestos.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function ObtenerImpuesto2() As Boolean

            If _entImpuesto.Impuesto2 <> "" Then

                _objADDatos.entImpuesto = _entImpuesto

                _objADDatos.ObtenerImpuesto2()
                _lstImpuestos = _objADDatos.lstImpuestos
                Return (_lstImpuestos.Count > 0)
            Else
                Return False
            End If
        End Function

        Public Function ObtenerImpuesto3() As Boolean

            If _entImpuesto.Impuesto3 <> "" Then

                _objADDatos.entImpuesto = _entImpuesto

                _objADDatos.ObtenerImpuesto3()
                _lstImpuestos = _objADDatos.lstImpuestos
                Return (_lstImpuestos.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function ObtenerDetraccion() As Boolean

            If _entImpuesto.Detraccion <> "" Then

                _objADDatos.entImpuesto = _entImpuesto

                _objADDatos.ObtenerDetraccion()
                _lstImpuestos = _objADDatos.lstImpuestos
                Return (_lstImpuestos.Count > 0)
            Else
                Return False
            End If
        End Function




        Public Function ObtenerPercepcion() As Boolean

            If _entImpuesto.Percepcion <> "" Then

                _objADDatos.entImpuesto = _entImpuesto

                _objADDatos.ObtenerPercepcion()
                _lstImpuestos = _objADDatos.lstImpuestos
                Return (_lstImpuestos.Count > 0)
            Else
                Return False
            End If
        End Function


        Public Function ObtenerRetencion() As Boolean

            If _entImpuesto.Retencion <> "" Then

                _objADDatos.entImpuesto = _entImpuesto

                _objADDatos.ObtenerRetencion()
                _lstImpuestos = _objADDatos.lstImpuestos
                Return (_lstImpuestos.Count > 0)
            Else
                Return False
            End If
        End Function

#End Region



    End Class
End Namespace