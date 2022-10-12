Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAJ
    Inherits System.Web.UI.Page

    Private Sub bindGrid()
        Dim objLNTipoCuenta As New LN_TipoCuenta
        Dim objENTipoCuenta As New EN_TipoCuenta

        objENTipoCuenta.IdEmpresa = hdnEmpresa.Value
        objLNTipoCuenta.entTipoCuenta = objENTipoCuenta

        objLNTipoCuenta.Listar()
        grdTipoCuenta.DataSource = objLNTipoCuenta.lstTipoCuentas
        grdTipoCuenta.DataBind()
    End Sub


    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlRegistroTipoCuenta.Visible = True
        ctlTipoCuenta.limpiar()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            bindGrid()
            pnlRegistroTipoCuenta.Visible = False
        End If
    End Sub


    Protected Sub ctlTipoCuenta_cargarGrilla() Handles ctlTipoCuenta.cargarGrilla
        bindGrid()
    End Sub

    Protected Sub ctlTipoCuenta_Cerrado() Handles ctlTipoCuenta.Cerrado
        pnlRegistroTipoCuenta.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlTioCuenta_Registrado() Handles ctlTipoCuenta.Registrado
        bindGrid()
    End Sub


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub grdTipoCuenta_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdTipoCuenta.RowCommand

        If e.CommandName = "Editar" Then

            pnlRegistroTipoCuenta.Visible = True
            Dim intIndice As Integer = e.CommandArgument
            Dim objTipoCuenta As New EN_TipoCuenta

            objTipoCuenta.IdTipoCuenta = HttpUtility.HtmlDecode(grdTipoCuenta.Rows(intIndice).Cells(0).Text)
            objTipoCuenta.IdEmpresa = HttpUtility.HtmlDecode(grdTipoCuenta.Rows(intIndice).Cells(1).Text)
            objTipoCuenta.RazonSocial = HttpUtility.HtmlDecode(grdTipoCuenta.Rows(intIndice).Cells(2).Text)
            objTipoCuenta.Descripcion = HttpUtility.HtmlDecode(grdTipoCuenta.Rows(intIndice).Cells(3).Text)

            ctlTipoCuenta.entTipoCuenta = objTipoCuenta

        End If

        If e.CommandName = "Eliminar" Then

            Dim intIndice As Integer = e.CommandArgument
            Dim objTipoCuenta As New LN_TipoCuenta

            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('EL REGISTRO SERA ELIMINADO');</script>")

            objTipoCuenta.entTipoCuenta.IdTipoCuenta = HttpUtility.HtmlDecode(grdTipoCuenta.Rows(intIndice).Cells(0).Text)
            objTipoCuenta.entTipoCuenta.IdEmpresa = HttpUtility.HtmlDecode(grdTipoCuenta.Rows(intIndice).Cells(1).Text)

            objTipoCuenta.Eliminar()

        End If
        bindGrid()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        pnlRegistroTipoCuenta.Visible = False
    End Sub

    Protected Sub grdTipoCuenta_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdTipoCuenta.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As Button = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.Attributes.Add("onclick", "return confirm ('El Registro sera Eliminado');")
        End If
    End Sub

    Protected Sub grdTipoCuenta_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdTipoCuenta.PageIndexChanging
        grdTipoCuenta.PageIndex = e.NewPageIndex
        bindGrid()
    End Sub
End Class
