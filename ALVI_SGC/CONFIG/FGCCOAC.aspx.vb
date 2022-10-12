Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAC
    Inherits System.Web.UI.Page

    Public Sub bindGrid()

        Dim objLNEjercicioEmpresa As New LN_EjercicioEmpresa
        Dim objENEjercicioEmpresa As New EN_EjercicioEmpresa

        objENEjercicioEmpresa.IdEmpresa = hdnEmpresa.Value
        objLNEjercicioEmpresa.entEjercicioEmpresa = objENEjercicioEmpresa
        objLNEjercicioEmpresa.Listar()
        grdDatos.DataSource = objLNEjercicioEmpresa.lstEjerciciosEmpresa
        grdDatos.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hdnEmpresa.Value = Session("Empresa")
            pnlEjercicioEmpresa.Visible = False
            bindGrid()
        End If
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand

        If e.CommandName = "MODIFICAR" Then
            Dim objENContabilidad As New EN_Contabilidad
            Dim objLNContabilidad As New LN_Contabilidad
            pnlEjercicioEmpresa.Visible = True

            Dim objENEjercicioEmpresa As New EN_EjercicioEmpresa

            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)

            objENEjercicioEmpresa.IdEjercicioEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(0).Text)
            objENEjercicioEmpresa.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)
            objENContabilidad.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)
            objENEjercicioEmpresa.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(2).Text)
            objENEjercicioEmpresa.IdContabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(3).Text)
            objENEjercicioEmpresa.IdContabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(4).Text)
            objENEjercicioEmpresa.IdEjercicio = HttpUtility.HtmlDecode(dgrFila.Cells(5).Text)
            objENEjercicioEmpresa.IdEjercicio = HttpUtility.HtmlDecode(dgrFila.Cells(6).Text)
            objENEjercicioEmpresa.Estado = HttpUtility.HtmlDecode(dgrFila.Cells(7).Text)
            ctlEjercicioEmpresa.EjercicioEmpresa = objENEjercicioEmpresa

        ElseIf e.CommandName = "ELIMINAR" Then

            Dim objLNEjercicioEmpresa As New LN_EjercicioEmpresa
            Dim objENEjercicioEmpresa As New EN_EjercicioEmpresa

            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)

            objENEjercicioEmpresa.IdEjercicioEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(0).Text)
            objENEjercicioEmpresa.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)

            objLNEjercicioEmpresa.entEjercicioEmpresa = objENEjercicioEmpresa

            If objLNEjercicioEmpresa.Eliminar = True Then
                bindGrid()
            Else
                Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERT", "<script language= 'javascript'>alert('NO SE LOGRO ELIMINAR')</script>")
            End If

        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        pnlEjercicioEmpresa.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlEjercicioEmpresa_cargarGrilla() Handles ctlEjercicioEmpresa.cargarGrilla
        bindGrid()
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlEjercicioEmpresa.Visible = True
        ctlEjercicioEmpresa.limpiar()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub ctlEjercicioEmpresa_Cerrado() Handles ctlEjercicioEmpresa.Cerrado
        pnlEjercicioEmpresa.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlEjercicioEmpresa_Registrado() Handles ctlEjercicioEmpresa.Registrado
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
