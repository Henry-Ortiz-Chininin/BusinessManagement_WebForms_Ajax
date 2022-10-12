Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAB
    Inherits System.Web.UI.Page

    Public Sub bindGrid()
        Dim objLNEjercicio As New LN_Ejercicio
        Dim objENEjercicio As New EN_Ejercicio

        objENEjercicio.IdEmpresa = hdnEmpresa.Value
        objLNEjercicio.entEjercicio = objENEjercicio
        objLNEjercicio.Listar()
        grdDatos.DataSource = objLNEjercicio.lstEjercicios
        grdDatos.DataBind()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            pnlEjercicio.Visible = False
            bindGrid()
        End If
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "MODIFICAR" Then

            pnlEjercicio.Visible = True

            Dim objENEjercicio As New EN_Ejercicio

            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)

            objENEjercicio.IdEjercicio = HttpUtility.HtmlDecode(dgrFila.Cells(0).Text)
            objENEjercicio.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)
            objENEjercicio.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(2).Text)
            objENEjercicio.FechaInicio = HttpUtility.HtmlDecode(dgrFila.Cells(3).Text)
            objENEjercicio.FechaFinal = HttpUtility.HtmlDecode(dgrFila.Cells(4).Text)
            objENEjercicio.Ejercicio = HttpUtility.HtmlDecode(dgrFila.Cells(5).Text)
            objENEjercicio.Agno = HttpUtility.HtmlDecode(dgrFila.Cells(6).Text)

            ctlEjercicio.Ejercicio = objENEjercicio

        ElseIf e.CommandName = "ELIMINAR" Then

            Dim objLNEjercicio As New LN_Ejercicio
            Dim objENEjercicio As New EN_Ejercicio

            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)

            objENEjercicio.IdEjercicio = HttpUtility.HtmlDecode(dgrFila.Cells(0).Text)
            objENEjercicio.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)

            objLNEjercicio.entEjercicio = objENEjercicio

            If objLNEjercicio.Eliminar = True Then
                bindGrid()
            Else
                Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERT", "<script language= 'javascript'>alert('NO SE LOGRO ELIMINAR')</script>")
            End If

        End If

    End Sub

    Protected Sub ctlEjercicio_cargarGrilla() Handles ctlEjercicio.cargarGrilla
        bindGrid()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        pnlEjercicio.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlEjercicio_Registrado() Handles ctlEjercicio.Registrado
        bindGrid()
    End Sub

    Protected Sub ctlEjercicio_Cerrado() Handles ctlEjercicio.Cerrado
        pnlEjercicio.Visible = False
        bindGrid()
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlEjercicio.Visible = True
        ctlEjercicio.LIMPIAR()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
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
