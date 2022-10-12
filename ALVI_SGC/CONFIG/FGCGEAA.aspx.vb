Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class GENERAL_FGCGEAA
    Inherits System.Web.UI.Page

    Private Sub bindGrid()
        Dim objLNEmpresa As New LN_Empresa
        Dim objENEmpresa As New EN_Empresa
        objENEmpresa.IdUsuario = hdnUsuario.Value
        objLNEmpresa.entEmpresa = objENEmpresa
        objLNEmpresa.Listar()
        grdEmpresa.DataSource = objLNEmpresa.lstEmpresas
        grdEmpresa.DataBind()
    End Sub

    Protected Sub grdEmpresa_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdEmpresa.RowCommand

        If e.CommandName = "EDITAR" Then
            pnlRegistroEmpresa.Visible = True
            Dim intIndice As Integer = e.CommandArgument
            Dim objEmpresa As New EN_Empresa

            objEmpresa.IdEmpresa = HttpUtility.HtmlDecode(grdEmpresa.Rows(intIndice).Cells(0).Text)
            objEmpresa.Ruc = HttpUtility.HtmlDecode(grdEmpresa.Rows(intIndice).Cells(1).Text)
            objEmpresa.RazonSocial = HttpUtility.HtmlDecode(grdEmpresa.Rows(intIndice).Cells(2).Text)

            ctlEmpresa.Empresa = objEmpresa

        End If

        If e.CommandName = "ELIMINAR" Then
            Dim intIndice As Integer = e.CommandArgument
            Dim objEmpresa As New LN_Empresa
            objEmpresa.entEmpresa.IdEmpresa = HttpUtility.HtmlDecode(grdEmpresa.Rows(intIndice).Cells(0).Text)
            objEmpresa.Eliminar()
        End If
        bindGrid()

    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlRegistroEmpresa.Visible = True
        ctlEmpresa.limpiar()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            bindGrid()
            pnlRegistroEmpresa.Visible = False
        End If
    End Sub

    Protected Sub ctlEmpresa_CargarGrilla() Handles ctlEmpresa.CargarGrilla
        bindGrid()
    End Sub

    Protected Sub ctlEmpresa_Cerrado() Handles ctlEmpresa.Cerrado
        pnlRegistroEmpresa.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlEmpresa_Registrado() Handles ctlEmpresa.Registrado
        bindGrid()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub grdEmpresa_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEmpresa.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As Button = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.Attributes.Add("onclick", "return confirm ('El Registro sera Eliminado');")
        End If
    End Sub

    Protected Sub grdEmpresa_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdEmpresa.PageIndexChanging
        grdEmpresa.PageIndex = e.NewPageIndex
        bindGrid()
    End Sub
End Class