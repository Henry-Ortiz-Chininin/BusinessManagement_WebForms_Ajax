Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAM
    Inherits System.Web.UI.Page

    Private Sub bindGrid()
        Dim objLNNivelPlan As New LN_NivelPlan
        Dim objENNivelPlan As New EN_NivelPlan

        objENNivelPlan.IdEmpresa = hdnEmpresa.Value
        objLNNivelPlan.entNivelPlan = objENNivelPlan

        objLNNivelPlan.Listar()
        grdNivelPlan.DataSource = objLNNivelPlan.lstNivelPlan
        grdNivelPlan.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            bindGrid()
            pnlNivelPlan.Visible = False
        End If
    End Sub

    Protected Sub grdNivelPlan_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdNivelPlan.RowCommand

        If e.CommandName = "EDITAR" Then

            pnlNivelPlan.Visible = True

            Dim intIndice As Integer = e.CommandArgument
            Dim objNivelPlan As New EN_NivelPlan

            objNivelPlan.IdNivel = HttpUtility.HtmlDecode(grdNivelPlan.Rows(intIndice).Cells(0).Text)
            objNivelPlan.IdEmpresa = HttpUtility.HtmlDecode(grdNivelPlan.Rows(intIndice).Cells(1).Text)
            objNivelPlan.IdEmpresa = HttpUtility.HtmlDecode(grdNivelPlan.Rows(intIndice).Cells(2).Text)
            objNivelPlan.Descripcion = HttpUtility.HtmlDecode(grdNivelPlan.Rows(intIndice).Cells(3).Text)

            ctlNivelPlan.NivelPlan = objNivelPlan

        End If

        If e.CommandName = "ELIMINAR" Then
            Dim intIndice As Integer = e.CommandArgument
            Dim objNivelPlan As New LN_NivelPlan
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('');</script>")

            objNivelPlan.entNivelPlan.IdNivel = HttpUtility.HtmlDecode(grdNivelPlan.Rows(intIndice).Cells(0).Text)
            objNivelPlan.entNivelPlan.IdEmpresa = HttpUtility.HtmlDecode(grdNivelPlan.Rows(intIndice).Cells(1).Text)

            objNivelPlan.Eliminar()
        End If
        bindGrid()

    End Sub

    Protected Sub ctlNivelPlan_cargarGrilla() Handles ctlNivelPlan.cargarGrilla
        bindGrid()
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlNivelPlan.Visible = True
        ctlNivelPlan.limpiar()
    End Sub

    Protected Sub ctlNivelPlan_Cerrado() Handles ctlNivelPlan.Cerrado
        pnlNivelPlan.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlNivelPlan_Registrado() Handles ctlNivelPlan.Registrado
        bindGrid()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        pnlNivelPlan.Visible = False
    End Sub

    Protected Sub grdNivelPlan_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdNivelPlan.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As Button = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.Attributes.Add("onclick", "return confirm ('El Registro sera Eliminado');")
        End If
    End Sub

    Protected Sub grdNivelPlan_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdNivelPlan.PageIndexChanging
        grdNivelPlan.PageIndex = e.NewPageIndex
        bindGrid()
    End Sub
End Class
