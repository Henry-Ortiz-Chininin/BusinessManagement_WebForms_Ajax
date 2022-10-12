Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAD
    Inherits System.Web.UI.Page

    Public Sub bindGrid()
        Dim objLNEjercicioMes As New LN_EjercicioMes
        Dim objENEjerccioMes As New EN_EjercicioMes

        objENEjerccioMes.IdEmpresa = hdnEmpresa.Value
        objLNEjercicioMes.entEjercicioMes = objENEjerccioMes
        objLNEjercicioMes.Listar()
        grdDatos.DataSource = objLNEjercicioMes.lstEjerciciosMes
        grdDatos.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hdnEmpresa.Value = Session("Empresa")
            pnlEjercicioMes.Visible = False
            bindGrid()
        End If
    End Sub


    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand

        If e.CommandName = "MODIFICAR" Then

            pnlEjercicioMes.Visible = True

            Dim objENEjercicioMes As New EN_EjercicioMes
            Dim boton As Button = e.CommandSource
            Dim dgrFila As GridViewRow = CType(boton.NamingContainer, GridViewRow)

            objENEjercicioMes.IdEjercicioMes = HttpUtility.HtmlDecode(dgrFila.Cells(0).Text)
            objENEjercicioMes.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)
            objENEjercicioMes.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(2).Text)
            objENEjercicioMes.IdEjercicioEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(3).Text)
            objENEjercicioMes.Ejercicio = HttpUtility.HtmlDecode(dgrFila.Cells(4).Text)
            objENEjercicioMes.FechaInicio = HttpUtility.HtmlDecode(dgrFila.Cells(5).Text)
            objENEjercicioMes.FechaFinal = HttpUtility.HtmlDecode(dgrFila.Cells(6).Text)
            objENEjercicioMes.EjercicioMes = HttpUtility.HtmlDecode(dgrFila.Cells(7).Text)
            objENEjercicioMes.Estado = HttpUtility.HtmlDecode(dgrFila.Cells(8).Text)

            ctlEjercicioMes.EjercicioMes = objENEjercicioMes

        ElseIf e.CommandName = "ELIMINAR" Then

            Dim objLNEjercicioMes As New LN_EjercicioMes
            Dim objENEjercicioMes As New EN_EjercicioMes

            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)

            objENEjercicioMes.IdEjercicioMes = HttpUtility.HtmlDecode(dgrFila.Cells(0).Text)
            objENEjercicioMes.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)
            objENEjercicioMes.IdEjercicioEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(3).Text)

            objLNEjercicioMes.entEjercicioMes = objENEjercicioMes

            If objLNEjercicioMes.Eliminar = True Then
                bindGrid()
            Else
                Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERT", "<script language= 'javascript'>alert('NO SE LOGRO ELIMINAR')</script>")
            End If

        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        pnlEjercicioMes.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlEjercicioMes_cargarGrilla() Handles ctlEjercicioMes.cargarGrilla
        bindGrid()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub ctlEjercicioMes_Cerrado() Handles ctlEjercicioMes.Cerrado
        pnlEjercicioMes.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlEjercicioMes_Registrado() Handles ctlEjercicioMes.Registrado
        bindGrid()
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        pnlEjercicioMes.Visible = True
        ctlEjercicioMes.limpiar()

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
