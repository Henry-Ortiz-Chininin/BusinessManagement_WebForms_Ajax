Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL

Partial Class GENERAL_FGCGEAC
    Inherits System.Web.UI.Page

    Private Sub bindGrid()
        Dim objLNMedioPago As New LN_MedioPago
        Dim objENMedioPago As New EN_MedioPago

        objENMedioPago.IdEmpresa = hdnEmpresa.Value
        objLNMedioPago.entMedioPago = objENMedioPago

        objLNMedioPago.Listar()
        grdMedioPago.DataSource = objLNMedioPago.lstMedioPagos
        grdMedioPago.DataBind()
    End Sub


    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlRegistroMedioPago.Visible = True
        ctlMedioPago.limpiar()
        bindGrid()
    End Sub


    Protected Sub grdMedioPago_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdMedioPago.RowCommand

        If e.CommandName = "EDITAR" Then
            pnlRegistroMedioPago.Visible = True
            Dim btnEdit As Button = CType(e.CommandSource, Button)
            Dim fila As GridViewRow = CType(btnEdit.NamingContainer, GridViewRow)
            Dim intIndice As Integer = e.CommandArgument
            Dim objMedioPago As New EN_MedioPago

            objMedioPago.IdMedioPago = HttpUtility.HtmlDecode(fila.Cells(0).Text)
            objMedioPago.IdEmpresa = HttpUtility.HtmlDecode(fila.Cells(1).Text)
            objMedioPago.RazonSocial = HttpUtility.HtmlDecode(fila.Cells(2).Text)
            objMedioPago.MedioPago = HttpUtility.HtmlDecode(fila.Cells(3).Text)
            objMedioPago.CodigoSunat = HttpUtility.HtmlDecode(fila.Cells(4).Text)

            ctlMedioPago.MedioPago = objMedioPago
        End If

        If e.CommandName = "ELIMINAR" Then
            Dim intIndice As Integer = e.CommandArgument

            Dim objMedioPago As New LN_MedioPago
            Dim btnEdit As Button = CType(e.CommandSource, Button)
            Dim fila As GridViewRow = CType(btnEdit.NamingContainer, GridViewRow)
            objMedioPago.entMedioPago.IdMedioPago = HttpUtility.HtmlDecode(fila.Cells(0).Text)
            objMedioPago.entMedioPago.IdEmpresa = HttpUtility.HtmlDecode(fila.Cells(1).Text)
            objMedioPago.Eliminar()
        End If
        bindGrid()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            bindGrid()
            pnlRegistroMedioPago.Visible = False
        End If
    End Sub


    Protected Sub ctlMedioPago_CargarGrilla() Handles ctlMedioPago.cargarGrilla
        bindGrid()
    End Sub

    Protected Sub ctlMedioPago_Cerrado() Handles ctlMedioPago.Cerrado
        pnlRegistroMedioPago.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlMedioPago_Registrado() Handles ctlMedioPago.Registrado
        bindGrid()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        pnlRegistroMedioPago.Visible = False
    End Sub

    Protected Sub grdMedioPago_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdMedioPago.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As Button = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.Attributes.Add("onclick", "return confirm ('El Registro sera Eliminado');")
        End If
    End Sub

    Protected Sub grdMedioPago_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdMedioPago.PageIndexChanging
        grdMedioPago.PageIndex = e.NewPageIndex
        bindGrid()
    End Sub
End Class
