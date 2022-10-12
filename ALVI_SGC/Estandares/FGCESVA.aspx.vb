
Partial Class Estandares_FGCESVA
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            BindGrid()
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        txtCodigo.ReadOnly = False
        txtCodigo.MaxLength = 14
        pnlFormulario.Visible = True

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid()
    End Sub

    Private Sub LimpiarFormulario()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
    End Sub
    Private Sub BindGrid()
        Dim objMotivo As New ALVI_LOGIC.Maestros.Ventas.Motivo
        Dim dtbDatos As New Data.DataTable
        objMotivo.Descripcion = txtBusqueda.Text
        If objMotivo.Buscar() = True Then
            For Each dtrItem As Data.DataRow In objMotivo.Datos.Rows
                dtbDatos = objMotivo.Datos
            Next
        End If

        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = Session("dtbDatos")
        grdDatos.DataBind()
    End Sub


    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" Then
            Dim objMotivo As New ALVI_LOGIC.Maestros.Ventas.Motivo
            objMotivo.IdMotivo = txtCodigo.Text
            objMotivo.Descripcion = txtDescripcion.Text
            objMotivo.Usuario = Session("Usuario")
            objMotivo.Estado = "ACT"
            If objMotivo.Registrar = True Then
                lblMensaje.Text = "Registro exitoso"
                LimpiarFormulario()
                grdDatos.EditIndex = -1
                BindGrid()
            End If
        Else
            lblMensaje.Text = "Registro fallido"
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("default.aspx")
    End Sub
    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_idMotivo='" & e.CommandArgument.ToString & "'")
                txtCodigo.Text = dtrItem("var_idMotivo")
                txtDescripcion.Text = dtrItem("var_Descripcion")
            Next
            pnlFormulario.Visible = True
            txtCodigo.ReadOnly = True
        End If
        If e.CommandName = "Detalle" Then
            Dim strParametros As String = e.CommandArgument.ToString
            Dim objSecurity As New ALVI_Security.General
            Dim strURL As String = "FGCESVB.ASPX"
            strURL = strURL & "?IdSeccion=" & Master.IdSeccion
            strURL = strURL & "&IdMenu=" & Master.IdMenu
            strURL = strURL & "&IdSubMenu=" & Master.IdSubMenu
            strURL = strURL & "&IdAT=" & objSecurity.Encrypta(strParametros)

            Response.Redirect(strURL)
        End If
        If e.CommandName = "Eliminar" Then
            Dim objAtributo As New ALVI_LOGIC.Maestros.Ventas.Motivo
            Dim strParametros As String = e.CommandArgument.ToString
            objAtributo.IdMotivo = strParametros(0)
            If objAtributo.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGrid()
    End Sub
End Class
