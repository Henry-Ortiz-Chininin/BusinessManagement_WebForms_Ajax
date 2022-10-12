Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAL
    Inherits System.Web.UI.Page

    Private Sub bindGrid()
        Dim objLNCuentaEntidad As New LN_CuentaEntidad
        Dim objENCuentaEntidad As New EN_CuentaEntidad
        Dim objSeguridad As New ALVI_Security.General
        objENCuentaEntidad.IdEmpresa = hdnEmpresa.Value

        If Request.QueryString("entidadF") Is Nothing Then
            objENCuentaEntidad.IdEntidadFinanciera = ""
        Else
            objENCuentaEntidad.IdEntidadFinanciera = Request.QueryString("entidadF")
            hdnEFinanciera.Value = Request.QueryString("entidadF")
        End If
        If Request.QueryString("entidadF") Is Nothing Then
            lblOperacion.Text = ""
        Else
            lblOperacion.Text = Request.QueryString("entidadD")
        End If

        objLNCuentaEntidad.entCuentaEntidad = objENCuentaEntidad

        objLNCuentaEntidad.Listar()
        grdCuentaEntidad.DataSource = objLNCuentaEntidad.lstCuentaEntidad
        grdCuentaEntidad.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            bindGrid()
            pnlCuentaEntidad.Visible = False
        End If
    End Sub

    Protected Sub grdCuentaEntidad_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdCuentaEntidad.RowCommand

        If e.CommandName = "EDITAR" Then
            pnlCuentaEntidad.Visible = True
            Dim intIndice As Integer = e.CommandArgument
            Dim objCuentaEntidad As New EN_CuentaEntidad

            objCuentaEntidad.Secuencia = HttpUtility.HtmlDecode(grdCuentaEntidad.Rows(intIndice).Cells(0).Text)
            objCuentaEntidad.IdEmpresa = HttpUtility.HtmlDecode(grdCuentaEntidad.Rows(intIndice).Cells(1).Text)

            ctlCtaEntidad.LlenarComboEmpresa()
            ctlCtaEntidad.LlenarComboEntidadFinanciera(HttpUtility.HtmlDecode(grdCuentaEntidad.Rows(intIndice).Cells(1).Text))
            ctlCtaEntidad.LlenarComboMoneda(HttpUtility.HtmlDecode(grdCuentaEntidad.Rows(intIndice).Cells(1).Text))

            objCuentaEntidad.RazonSocial = HttpUtility.HtmlDecode(grdCuentaEntidad.Rows(intIndice).Cells(2).Text)
            objCuentaEntidad.IdEntidadFinanciera = HttpUtility.HtmlDecode(grdCuentaEntidad.Rows(intIndice).Cells(3).Text)
            objCuentaEntidad.NombreEntidad = HttpUtility.HtmlDecode(grdCuentaEntidad.Rows(intIndice).Cells(4).Text)
            objCuentaEntidad.IdMoneda = HttpUtility.HtmlDecode(grdCuentaEntidad.Rows(intIndice).Cells(5).Text)
            objCuentaEntidad.Moneda = HttpUtility.HtmlDecode(grdCuentaEntidad.Rows(intIndice).Cells(6).Text)
            objCuentaEntidad.NumeroCuenta = HttpUtility.HtmlDecode(grdCuentaEntidad.Rows(intIndice).Cells(7).Text)
            ctlCtaEntidad.cuentaEntidad = objCuentaEntidad
        End If

        If e.CommandName = "ELIMINAR" Then
            Dim intIndice As Integer = e.CommandArgument
            Dim objCuentaEntidad As New LN_CuentaEntidad
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('El Registro Sera Eliminado');</script>")
            objCuentaEntidad.entCuentaEntidad.Secuencia = HttpUtility.HtmlDecode(grdCuentaEntidad.Rows(intIndice).Cells(0).Text)
            objCuentaEntidad.entCuentaEntidad.IdEmpresa = HttpUtility.HtmlDecode(grdCuentaEntidad.Rows(intIndice).Cells(1).Text)
            objCuentaEntidad.entCuentaEntidad.IdEntidadFinanciera = HttpUtility.HtmlDecode(grdCuentaEntidad.Rows(intIndice).Cells(3).Text)
            objCuentaEntidad.Eliminar()
        End If
        bindGrid()
    End Sub

    Protected Sub ctlCtaEntidad_cargarGrilla() Handles ctlCtaEntidad.cargarGrilla
        bindGrid()
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlCuentaEntidad.Visible = True
        Dim objCuentaEntidad As New EN_CuentaEntidad
        ctlCtaEntidad.IdentidadFinanciera = hdnEFinanciera.Value
        ctlCtaEntidad.Limpiar()
    End Sub


    Protected Sub ctlCtaEntidad_Cerrado() Handles ctlCtaEntidad.Cerrado
        pnlCuentaEntidad.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlCtaEntidad_Registrado() Handles ctlCtaEntidad.Registrado
        bindGrid()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Response.Redirect("FGCCOAN.aspx")
    End Sub

    Protected Sub grdCuentaEntidad_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdCuentaEntidad.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As Button = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.Attributes.Add("onclick", "return confirm ('El Registro sera Eliminado');")
        End If
    End Sub

    Protected Sub grdCuentaEntidad_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdCuentaEntidad.PageIndexChanging
        grdCuentaEntidad.PageIndex = e.NewPageIndex
        bindGrid()
    End Sub
End Class

