Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAE
    Inherits System.Web.UI.Page

    Public Sub bindGrid()
        Dim objLNOperacion As New LN_Operacion
        Dim objENOperacion As New EN_Operacion

        objENOperacion.Idempresa = hdnEmpresa.Value
        objLNOperacion.entOperacion = objENOperacion

        objLNOperacion.Listar()
        grdDatos.DataSource = objLNOperacion.lstOperacion
        grdDatos.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            pnlOperacion.Visible = False
            bindGrid()
            ctlOperacion.LlenarComboEmpresa()
            ctlOperacion.llenarComboContabilidad(hdnEmpresa.Value)
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        pnlOperacion.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlOperacion_cargarGrilla() Handles ctlOperacion.cargarGrilla
        bindGrid()
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand

        If e.CommandName = "MODIFICAR" Then

            pnlOperacion.Visible = True

            Dim objENOperacion As New EN_Operacion

            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)

            objENOperacion.IdOperacion = HttpUtility.HtmlDecode(dgrFila.Cells(0).Text)
            objENOperacion.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)
            objENOperacion.Idempresa = HttpUtility.HtmlDecode(dgrFila.Cells(2).Text)

            ctlOperacion.llenarComboContabilidad(hdnEmpresa.Value)

            objENOperacion.IdContabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(4).Text)
            objENOperacion.IdContabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(3).Text)
            objENOperacion.Descripcion = HttpUtility.HtmlDecode(dgrFila.Cells(5).Text)
            objENOperacion.IdSunat = HttpUtility.HtmlDecode(dgrFila.Cells(6).Text)

            ctlOperacion.Operacion = objENOperacion

        ElseIf e.CommandName = "ELIMINAR" Then

            Dim objLNOperacion As New LN_Operacion
            Dim objENOperacion As New EN_Operacion

            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)

            objENOperacion.IdOperacion = HttpUtility.HtmlDecode(dgrFila.Cells(0).Text)
            objENOperacion.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)


            objENOperacion.IdContabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(3).Text)

            objLNOperacion.entOperacion = objENOperacion

            If objLNOperacion.Eliminar = True Then
                bindGrid()
            Else
                Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERT", "<script language= 'javascript'>alert('NO SE LOGRO ELIMINAR')</script>")
            End If
        ElseIf e.CommandName = "DETALLE" Then

            Dim objSeguridad As New ALVI_Security.General
            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)
            Dim strOperacion As String = objSeguridad.Encrypta(grdDatos.Rows(dgrFila.RowIndex).Cells(0).Text)
            Dim strIdOperacion As String = objSeguridad.Encrypta(grdDatos.Rows(dgrFila.RowIndex).Cells(0).Text)
            Dim strflag As String = "1"
            Dim STRURL As String = ""
            STRURL = "FGCCOAQ.aspx?operacion=" + strOperacion + "&strFlag=" + strflag + "&IdOperacion=" + strIdOperacion + "&desc=" + objSeguridad.Encrypta(grdDatos.Rows(dgrFila.RowIndex).Cells(5).Text).ToString + ""
            Response.Redirect(STRURL)
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub ctlOperacion_Cerrado() Handles ctlOperacion.Cerrado
        pnlOperacion.Visible = False
    End Sub

    Protected Sub ctlOperacion_Registrado() Handles ctlOperacion.Registrado
        bindGrid()
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlOperacion.Visible = True
        ctlOperacion.Limpiar()
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
