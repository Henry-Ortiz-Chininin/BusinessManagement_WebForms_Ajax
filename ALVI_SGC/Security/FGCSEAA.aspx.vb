
Partial Class Security_FGCSEAA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            BindGrid()
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        txtCodigo.ReadOnly = False
        pnlFormulario.Visible = True
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub Cancelar()
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid()
    End Sub

    Private Sub LimpiarFormulario()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        lblMensaje.Text = ""
    End Sub

    Private Sub BindGrid()
        Dim objAcceso As New ALVI_Security.Accesos.Tipo
        objAcceso.Listar()
        grdDatos.DataSource = objAcceso.Datos
        grdDatos.DataBind()
    End Sub


    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" Then
            Dim objAcceso As New ALVI_Security.Accesos.Tipo
            objAcceso.IdAccesoTipo = txtCodigo.Text
            objAcceso.Descripcion = txtDescripcion.Text
            objAcceso.Usuario = Session("Usuario")
            objAcceso.Estado = "ACT"
            If objAcceso.Registrar = True Then
                LimpiarFormulario()
                lblMensaje.Text = "Registro exitoso"
                grdDatos.EditIndex = -1
                BindGrid()
            End If
        Else
            lblMensaje.Text = "Faltan datos"
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
            Dim objAcceso As New ALVI_Security.Accesos.Tipo
            objAcceso.IdAccesoTipo = e.CommandArgument
            If objAcceso.Obtener() Then
                txtCodigo.Text = objAcceso.IdAccesoTipo
                txtDescripcion.Text = objAcceso.Descripcion
            Else
                txtCodigo.Text = ""
                txtDescripcion.Text = ""
            End If

            pnlFormulario.Visible = True
            txtCodigo.ReadOnly = True
        End If
        If e.CommandName = "Detalle" Then
            Dim strParametros() As String = Split(e.CommandArgument.ToString, "-")
            Dim objSecurity As New ALVI_Security.General
            Dim strURL As String = "FGCSEAB.ASPX"
            strURL = strURL & "?IdSeccion=" & Master.IdSeccion
            strURL = strURL & "&IdMenu=" & Master.IdMenu
            strURL = strURL & "&IdSubMenu=" & Master.IdSubMenu
            strURL = strURL & "&IdAcceso=" & objSecurity.Encrypta(strParametros(0))

            Response.Redirect(strURL)
        End If
        If e.CommandName = "Eliminar" Then
            Dim objAcceso As New ALVI_Security.Accesos.Tipo
            objAcceso.IdAccesoTipo = e.CommandArgument.ToString
            If objAcceso.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub

End Class
