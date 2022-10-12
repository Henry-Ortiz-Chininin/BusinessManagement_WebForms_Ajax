Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAA
    Inherits System.Web.UI.Page

    Public Sub bindGrid()
        Dim objLNContabilidad As New LN_Contabilidad
        Dim objENContabilidad As New EN_Contabilidad

        objENContabilidad.IdEmpresa = hdnEmpresa.Value
        objLNContabilidad.entContabilidad = objENContabilidad
        objLNContabilidad.Listar()
        grdDatos.DataSource = objLNContabilidad.lstContabilidades
        grdDatos.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hdnEmpresa.Value = Session("Empresa")
            pnlContabilidad.Visible = False
            bindGrid()
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        pnlContabilidad.Visible = False
        bindGrid()
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand

        If e.CommandName = "MODIFICAR" Then

            pnlContabilidad.Visible = True

            Dim objENContabilidad As New EN_Contabilidad

            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)

            objENContabilidad.IdContabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(0).Text)

            objENContabilidad.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)

            objENContabilidad.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(2).Text)

            objENContabilidad.IdMoneda = HttpUtility.HtmlDecode(dgrFila.Cells(3).Text)
            objENContabilidad.IdMoneda = HttpUtility.HtmlDecode(dgrFila.Cells(4).Text)

            objENContabilidad.Contabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(5).Text)
            objENContabilidad.CuentaGananciaCambio = HttpUtility.HtmlDecode(dgrFila.Cells(6).Text)
            objENContabilidad.CuentaPerdidaCambio = HttpUtility.HtmlDecode(dgrFila.Cells(7).Text)
            objENContabilidad.Estado = HttpUtility.HtmlDecode(dgrFila.Cells(8).Text)


            ctlContabilidad.Contabilidad = objENContabilidad

        ElseIf e.CommandName = "ELIMINAR" Then

            Dim objLNContabilidad As New LN_Contabilidad
            Dim objENContabilidad As New EN_Contabilidad

            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)

            objENContabilidad.IdContabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(0).Text)
            objENContabilidad.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)

            objLNContabilidad.entContabilidad = objENContabilidad
            If objLNContabilidad.Eliminar = True Then
                bindGrid()
            Else
                Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "alerta", "<script language= 'javascript'>alert('NO SE LOGRO ELIMINAR')</script>")
            End If

        End If
    End Sub

    Protected Sub ctlContabilidad_cargarGrilla() Handles ctlContabilidad.cargarGrilla
        bindGrid()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub ctlContabilidad_Cerrado() Handles ctlContabilidad.Cerrado
        pnlContabilidad.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlContabilidad_Registrado() Handles ctlContabilidad.Registrado
        bindGrid()
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlContabilidad.Visible = True
        ctlContabilidad.limpiar()
    End Sub

    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As Button = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.Attributes.Add("onclick", "return confirm ('El Rgistro sera Eliminado');")
        End If
    End Sub

    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        bindGrid()
    End Sub
End Class
