
Partial Class OPERACION_FGCOPCA
    Inherits System.Web.UI.Page

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BindGrid()
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlFormulario.Visible = True
        ctlOrdenServicio.limpiar()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            BinDepartamento(ddlDepartamento)
            BindGrid()
        End If
    End Sub

    Private Sub BinDepartamento(ByVal pddlAtributo As DropDownList)
        Dim LN_Departamento As New LN_ALVINET_CONTA.GENERAL.LN_Departamento

        If LN_Departamento.Listar() = True Then
            pddlAtributo.Items.Clear()

            pddlAtributo.DataTextField = "NomDepartamento"
            pddlAtributo.DataValueField = "IdDepartamento"

            pddlAtributo.DataSource = LN_Departamento.lstDepartamento
            pddlAtributo.DataBind()
        End If

        pddlAtributo.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlAtributo.ToolTip = "Seleccionar Departamento"
        pddlAtributo.SelectedIndex = 0

    End Sub

    Protected Sub ctlOrdenServicio_Cerrado() Handles ctlOrdenServicio.Cerrado
        pnlFormulario.Visible = False
        BindGrid()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click

    End Sub

    Private Sub BindGrid()
        Dim objOrden As New LN_ALVINET_CONTA.OPERACION.LN_OrdenServicio
        objOrden.entDato.IdOrdenServicio = txtCodigo.Text
        objOrden.entDato.IdDepartamento = ddlDepartamento.SelectedValue
        objOrden.entDato.IdCliente = ctlCliente.IdCliente
        objOrden.entDato.FechaInicio = txtFechaInicio.Text
        objOrden.entDato.FechaFinal = txtFechaFinal.Text
        objOrden.entDato.TipoServicio = ddlTipo.SelectedValue
        objOrden.entDato.Estado = ddlEstado.SelectedValue

        objOrden.Buscar()

        grdDatos.DataSource = objOrden.lstDatos
        grdDatos.DataBind()

    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "MODIFICAR" Then
            Dim Fila As GridViewRow = grdDatos.Rows(CInt(e.CommandArgument) - (grdDatos.PageCount * grdDatos.PageIndex))
            Dim entOrden As New EN_ALVINET_CONTA.OPERACION.EN_OrdenServicio
            entOrden.IdOrdenServicio = HttpUtility.HtmlDecode(Fila.Cells(0).Text).ToString.Trim()
            entOrden.IdDepartamento = HttpUtility.HtmlDecode(Fila.Cells(1).Text).ToString.Trim()
            entOrden.IdCliente = HttpUtility.HtmlDecode(Fila.Cells(3).Text).ToString.Trim()
            entOrden.LugarOperacion = HttpUtility.HtmlDecode(Fila.Cells(5).Text).ToString.Trim()
            entOrden.TrabaSolicitante = HttpUtility.HtmlDecode(Fila.Cells(6).Text).ToString.Trim()
            entOrden.Telefono = HttpUtility.HtmlDecode(Fila.Cells(7).Text).ToString.Trim()
            entOrden.TrabajoEfectuado = HttpUtility.HtmlDecode(Fila.Cells(8).Text).ToString.Trim()
            entOrden.Operador = HttpUtility.HtmlDecode(Fila.Cells(9).Text).ToString.Trim()
            entOrden.Riger = HttpUtility.HtmlDecode(Fila.Cells(10).Text).ToString.Trim()
            entOrden.Ayudante = HttpUtility.HtmlDecode(Fila.Cells(11).Text).ToString.Trim()
            entOrden.FechaEmision = HttpUtility.HtmlDecode(Fila.Cells(12).Text).ToString.Trim()
            entOrden.HoraSalidaBase = Fila.Cells(13).Text.Replace(":", "")
            entOrden.HoraLlegadaObra = Fila.Cells(14).Text.Replace(":", "")
            entOrden.HoraInicioOperacion = Fila.Cells(15).Text.Replace(":", "")
            entOrden.HoraTerminoOperacion = Fila.Cells(16).Text.Replace(":", "")
            entOrden.HoraSalidaObra = Fila.Cells(17).Text.Replace(":", "")
            entOrden.HoraLlegadaBase = Fila.Cells(18).Text.Replace(":", "")
            entOrden.TarifaHora = HttpUtility.HtmlDecode(Fila.Cells(19).Text)
            entOrden.IdMoneda = HttpUtility.HtmlDecode(Fila.Cells(21).Text)
            entOrden.IdTipoServicio = HttpUtility.HtmlDecode(Fila.Cells(23).Text)
            entOrden.Estado = HttpUtility.HtmlDecode(Fila.Cells(25).Text)
            entOrden.Placa_Grua = HttpUtility.HtmlDecode(Fila.Cells(26).Text)
            entOrden.Observacion = HttpUtility.HtmlDecode(Fila.Cells(27).Text)

            ctlOrdenServicio.Orden = entOrden
            pnlFormulario.Visible = True

        End If
        If e.CommandName = "IMPRIMIR" Then
            Dim Fila As GridViewRow = grdDatos.Rows(CInt(e.CommandArgument) - (grdDatos.PageCount * grdDatos.PageIndex))

            ClientScript.RegisterStartupScript(ClientScript.GetType, "IMPRESION", "<script language='javascript'>window.open('../reportes/FGCPRAA.aspx?Numero=" & Fila.Cells(0).Text & "','impresion');</script>")

        End If

    End Sub
End Class
