Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAP
    Inherits System.Web.UI.Page

    Private Sub bindGrid()
        Dim objLNUsuarioEmpresa As New LN_UsuarioEmpresa
        Dim objENUsuarioEmpresa As New EN_UsuarioEmpresa

        objENUsuarioEmpresa.IdUsuario = hdnUsuario.Value
        objLNUsuarioEmpresa.entUsuarioEmpresa = objENUsuarioEmpresa

        objLNUsuarioEmpresa.Buscar()
        grdUsuarioEmpresa.DataSource = objLNUsuarioEmpresa.lstUsuarioEmpresas
        grdUsuarioEmpresa.DataBind()

    End Sub


    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlRegistroUsuarioEmpresa.Visible = True
        ctlUsuarioEmpresa.limpiar()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            bindGrid()
            pnlRegistroUsuarioEmpresa.Visible = False
        End If
    End Sub


    Protected Sub ctlUsuarioEmpresa_cargar() Handles ctlUsuarioEmpresa.cargar
        bindGrid()
    End Sub

    Protected Sub ctlUsuarioEmpresa_Cerrado() Handles ctlUsuarioEmpresa.Cerrado
        pnlRegistroUsuarioEmpresa.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlUsuarioEmpresa_Registrado() Handles ctlUsuarioEmpresa.Registrado
        bindGrid()
    End Sub


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        pnlRegistroUsuarioEmpresa.Visible = False
    End Sub

    Protected Sub grdUsuarioEmpresa_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdUsuarioEmpresa.RowCommand

        If e.CommandName = "ELIMINAR" Then

            Dim intIndice As Integer = e.CommandArgument
            Dim objUsuarioEmpresa As New LN_UsuarioEmpresa

            objUsuarioEmpresa.entUsuarioEmpresa.IdEmpresa = HttpUtility.HtmlDecode(grdUsuarioEmpresa.Rows(intIndice).Cells(0).Text)
            objUsuarioEmpresa.entUsuarioEmpresa.IdUsuario = HttpUtility.HtmlDecode(grdUsuarioEmpresa.Rows(intIndice).Cells(1).Text)

            objUsuarioEmpresa.Eliminar()
        End If
        bindGrid()
    End Sub



    Protected Sub grdUsuarioEmpresa_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdUsuarioEmpresa.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As Button = CType(e.Row.FindControl("btnEliminar"), Button)

            btnEliminar.Attributes.Add("onclick", "return confirm ('El registro será Eliminado');")
        End If
    End Sub

    Protected Sub grdUsuarioEmpresa_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdUsuarioEmpresa.PageIndexChanging
        grdUsuarioEmpresa.PageIndex = e.NewPageIndex
        bindGrid()
    End Sub
End Class
