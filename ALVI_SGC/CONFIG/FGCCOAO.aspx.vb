Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAO
    Inherits System.Web.UI.Page

    Private Sub bindGrid()
        Dim objLNEntidadFinanciera As New LN_EntidadFinanciera
        Dim objENEntidadFinanciera As New EN_EntidadFinanciera

        objENEntidadFinanciera.IdEmpresa = hdnEmpresa.Value
        objLNEntidadFinanciera.entEntidadFinanciera = objENEntidadFinanciera

        objLNEntidadFinanciera.Listar()
        grdEntidadFinanciera.DataSource = objLNEntidadFinanciera.lstEntidadFinanciera
        grdEntidadFinanciera.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            bindGrid()
            pnlEntidadFinanciera.Visible = False
        End If
    End Sub

    Protected Sub grdEntidadFinanciera_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdEntidadFinanciera.RowCommand

        If e.CommandName = "EDITAR" Then

            pnlEntidadFinanciera.Visible = True
            Dim intIndice As Integer = e.CommandArgument
            Dim objEntidadFinanciera As New EN_EntidadFinanciera

            objEntidadFinanciera.IdEntidadFinanciera = HttpUtility.HtmlDecode(grdEntidadFinanciera.Rows(intIndice).Cells(0).Text)

            objEntidadFinanciera.IdEmpresa = HttpUtility.HtmlDecode(grdEntidadFinanciera.Rows(intIndice).Cells(1).Text)
            objEntidadFinanciera.IdEmpresa = HttpUtility.HtmlDecode(grdEntidadFinanciera.Rows(intIndice).Cells(2).Text)
            objEntidadFinanciera.NombreEntidad = HttpUtility.HtmlDecode(grdEntidadFinanciera.Rows(intIndice).Cells(3).Text)
            objEntidadFinanciera.IdSunat = HttpUtility.HtmlDecode(grdEntidadFinanciera.Rows(intIndice).Cells(4).Text)

            ctlEntidadFinanciera.EntidadFinanciera = objEntidadFinanciera

        End If

        If e.CommandName = "ELIMINAR" Then

            Dim intIndice As Integer = e.CommandArgument

            Dim objEntidadFinanciera As New LN_EntidadFinanciera

            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('El Registro Sera Eliminado');</script>")

            objEntidadFinanciera.entEntidadFinanciera.IdEntidadFinanciera = HttpUtility.HtmlDecode(grdEntidadFinanciera.Rows(intIndice).Cells(0).Text)
            objEntidadFinanciera.entEntidadFinanciera.IdEmpresa = HttpUtility.HtmlDecode(grdEntidadFinanciera.Rows(intIndice).Cells(1).Text)
            objEntidadFinanciera.Eliminar()

        End If

        If e.CommandName = "DETALLE" Then
            Dim fila As GridViewRow = grdEntidadFinanciera.Rows(e.CommandArgument)
            Dim objSeguridad As New ALVI_Security.General
            Dim STRURL = "FGCCOAL.aspx"
            STRURL = STRURL & "?entidadF=" + grdEntidadFinanciera.Rows(fila.RowIndex).Cells(0).Text
            STRURL = STRURL & "&entidadD=" + grdEntidadFinanciera.Rows(fila.RowIndex).Cells(3).Text
            Response.Redirect(STRURL)
            Session("Usuario") = hdnUsuario.Value
            Session("Empresa") = hdnEmpresa.Value
        End If

        bindGrid()
    End Sub

    Protected Sub ctlEntidadFinanciera_cargarGrilla() Handles ctlEntidadFinanciera.cargarGrilla
        bindGrid()
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlEntidadFinanciera.Visible = True
        ctlEntidadFinanciera.limpiar()
    End Sub

    Protected Sub ctlEntidadFinanciera_Cerrado() Handles ctlEntidadFinanciera.Cerrado
        pnlEntidadFinanciera.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlEntidadFinanciera_Registrado() Handles ctlEntidadFinanciera.Registrado
        bindGrid()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        pnlEntidadFinanciera.Visible = False
    End Sub

    Protected Sub grdEntidadFinanciera_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEntidadFinanciera.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As Button = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.Attributes.Add("onclick", "return confirm ('El Registro sera Eliminado');")
        End If
    End Sub

    Protected Sub grdEntidadFinanciera_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdEntidadFinanciera.PageIndexChanging
        grdEntidadFinanciera.PageIndex = e.NewPageIndex
        bindGrid()
    End Sub
End Class
