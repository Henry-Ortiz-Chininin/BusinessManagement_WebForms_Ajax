Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAF
    Inherits System.Web.UI.Page

    Public Sub bindGrid()
        Dim objLNPlanContable As New LN_PlanContable
        Dim objENPlanContable As New EN_PlanContable

        objENPlanContable.IdEmpresa = hdnEmpresa.Value
        objLNPlanContable.entPlanContable = objENPlanContable

        objLNPlanContable.Listar()
        grdDatos.DataSource = objLNPlanContable.lstPlanesContables
        grdDatos.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            pnlPlanContable.Visible = False
            bindGrid()
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        pnlPlanContable.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlPlanContable_cargarGrilla() Handles ctlPlanContable.cargarGrilla
        bindGrid()
    End Sub


    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand

        If e.CommandName = "MODIFICAR" Then

            pnlPlanContable.Visible = True

            Dim objENPlanContable As New EN_PlanContable

            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)

            objENPlanContable.IdPlanContable = HttpUtility.HtmlDecode(dgrFila.Cells(0).Text)
            objENPlanContable.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)
            objENPlanContable.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(2).Text)
            objENPlanContable.IdContabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(3).Text)
            objENPlanContable.IdContabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(4).Text)

            objENPlanContable.Formato = HttpUtility.HtmlDecode(dgrFila.Cells(5).Text)
            objENPlanContable.LongitudNivel1 = HttpUtility.HtmlDecode(dgrFila.Cells(6).Text)
            objENPlanContable.LongitudNivel2 = HttpUtility.HtmlDecode(dgrFila.Cells(7).Text)
            objENPlanContable.LongitudNivel3 = HttpUtility.HtmlDecode(dgrFila.Cells(8).Text)
            objENPlanContable.LongitudNivel4 = HttpUtility.HtmlDecode(dgrFila.Cells(9).Text)
            objENPlanContable.LongitudNivel5 = HttpUtility.HtmlDecode(dgrFila.Cells(10).Text)
            objENPlanContable.LongitudNivel6 = HttpUtility.HtmlDecode(dgrFila.Cells(11).Text)
            objENPlanContable.LongitudNivel7 = HttpUtility.HtmlDecode(dgrFila.Cells(12).Text)
            objENPlanContable.LongitudNivel8 = HttpUtility.HtmlDecode(dgrFila.Cells(13).Text)

            objENPlanContable.Estado = HttpUtility.HtmlDecode(dgrFila.Cells(10).Text)

            ctlPlanContable.PlanContable = objENPlanContable

        ElseIf e.CommandName = "ELIMINAR" Then

            Dim objLNPlanContable As New LN_PlanContable
            Dim objENPlanContable As New EN_PlanContable

            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)

            objENPlanContable.IdPlanContable = HttpUtility.HtmlDecode(dgrFila.Cells(0).Text)
            objENPlanContable.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)
            objENPlanContable.IdContabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(3).Text)

            objLNPlanContable.entPlanContable = objENPlanContable

            If objLNPlanContable.Eliminar = True Then
                bindGrid()
            Else
                Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERT", "<script language= 'javascript'>alert('NO SE LOGRO ELIMINAR')</script>")
            End If

        End If

    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlPlanContable.Visible = True
        ctlPlanContable.Limpiar()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub ctlPlanContable_Cerrado() Handles ctlPlanContable.Cerrado
        pnlPlanContable.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlPlanContable_Registrado() Handles ctlPlanContable.Registrado
        bindGrid()
    End Sub

    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As Button = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.Attributes.Add("onclick", "return confirm ('El Registro sera Eliminado');")
        End If
    End Sub

    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        bindGrid()
    End Sub
End Class
