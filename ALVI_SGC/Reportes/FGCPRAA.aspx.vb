
Partial Class Reportes_FGCPRAA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblNumero.Text = Request("Numero")
            BindRegistro()
        End If
    End Sub

    Private Sub BindRegistro()
        Dim objOrden As New LN_ALVINET_CONTA.OPERACION.LN_OrdenServicio
        Dim objEntidad As New EN_ALVINET_CONTA.OPERACION.EN_OrdenServicio

        objEntidad.IdOrdenServicio = lblNumero.Text
        objOrden.entDato = objEntidad

        objOrden.Buscar()
        With objOrden.lstDatos(0)
            lblAgno.Text = Right(.FechaEmision, 4)
            lblCliente.Text = .RazonSocial
            lblDia.Text = Left(.FechaEmision, 2)
            lblDireccion.Text = .LugarOperacion
            ''lblDNI.Text = .DNI
            lblEfectuado.Text = .TrabajoEfectuado
            lblLugar.Text = .LugarOperacion
            lblMes.Text = ""
            lblObservacion.Text = .Observacion

            lblOpcion1.Text = "X"
            lblOpcion2.Text = "X"
            lblOpcion3.Text = "X"
            lblOpcion4.Text = "X"
            lblOpcion5.Text = "X"

            'lblLlegada.Text = .HoraLlegada
            'lblRegreso.Text = .HoraRegreso
            'lblSalida.Text = .HoraSalida
            'lblTermino.Text = .HoraTermino
            'lblHoras.Text = .TiempoTotal

            'lblResponsable.Text = .Responsable
            'lblRUC.Text = .IdCliente
            'lblSolicitado.Text = .Solicitante
            'lblTarifa.Text = .TarifaHora
            'lblTelefono.Text = .Telefono
            lblTotal.Text = .TotalFacturar * .TarifaHora
            lblTotalHora.Text = .TiempoFacturar
            lblTotalSoles.Text = lblTotal.Text
        End With

    End Sub
End Class
