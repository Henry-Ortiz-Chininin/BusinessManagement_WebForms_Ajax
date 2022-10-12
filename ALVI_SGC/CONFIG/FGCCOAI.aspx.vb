Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAI
    Inherits System.Web.UI.Page


    Private Sub bindGrid()
        Dim objLNTipoAnalisis As New LN_TipoAnalisis
        Dim objENTipoAnalisis As New EN_TipoAnalisis

        objENTipoAnalisis.IdEmpresa = hdnEmpresa.Value
        objLNTipoAnalisis.entTipoAnalisis = objENTipoAnalisis

        objLNTipoAnalisis.Listar()
        grdTipoAnalisis.DataSource = objLNTipoAnalisis.lstTiposAnalisis
        grdTipoAnalisis.DataBind()
    End Sub


    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlRegistroTipoAnalisis.Visible = True
        ctlTipoAnalisis.limpiar()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            bindGrid()
            pnlRegistroTipoAnalisis.Visible = False
        End If
    End Sub

    Protected Sub grdTipoAnalisis_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdTipoAnalisis.RowCommand

        If e.CommandName = "EDITAR" Then

            pnlRegistroTipoAnalisis.Visible = True
            Dim intIndice As Integer = e.CommandArgument
            Dim objTipoAanalisis As New EN_TipoAnalisis

            objTipoAanalisis.IdTipoAnalisis = HttpUtility.HtmlDecode(grdTipoAnalisis.Rows(intIndice).Cells(0).Text)
            objTipoAanalisis.IdEmpresa = HttpUtility.HtmlDecode(grdTipoAnalisis.Rows(intIndice).Cells(1).Text)
            objTipoAanalisis.RazonSocial = HttpUtility.HtmlDecode(grdTipoAnalisis.Rows(intIndice).Cells(2).Text)
            objTipoAanalisis.TipoAnalisis = HttpUtility.HtmlDecode(grdTipoAnalisis.Rows(intIndice).Cells(3).Text)

            ctlTipoAnalisis.entTipoAnalisis = objTipoAanalisis
        End If

        If e.CommandName = "ELIMINAR" Then
            Dim intIndice As Integer = e.CommandArgument
            Dim objTipoAnalisis As New LN_TipoAnalisis


            objTipoAnalisis.entTipoAnalisis.IdTipoAnalisis = HttpUtility.HtmlDecode(grdTipoAnalisis.Rows(intIndice).Cells(0).Text)
            objTipoAnalisis.entTipoAnalisis.IdEmpresa = HttpUtility.HtmlDecode(grdTipoAnalisis.Rows(intIndice).Cells(1).Text)
            objTipoAnalisis.Eliminar()

        End If
        bindGrid()
    End Sub


    Protected Sub ctlTipoAnalisis_cargarGrilla() Handles ctlTipoAnalisis.cargarGrilla
        bindGrid()
    End Sub

    Protected Sub ctlTipoAnalisis_Cerrado() Handles ctlTipoAnalisis.Cerrado
        pnlRegistroTipoAnalisis.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlTipoAnalisis_Registrado() Handles ctlTipoAnalisis.Registrado
        bindGrid()
    End Sub


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        pnlRegistroTipoAnalisis.Visible = False
    End Sub

    Protected Sub grdTipoAnalisis_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdTipoAnalisis.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As Button = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.Attributes.Add("onclick", "return confirm ('El Registro sera Eliminado');")
        End If
    End Sub

    Protected Sub grdTipoAnalisis_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdTipoAnalisis.PageIndexChanging
        grdTipoAnalisis.PageIndex = e.NewPageIndex
        bindGrid()
    End Sub
End Class
