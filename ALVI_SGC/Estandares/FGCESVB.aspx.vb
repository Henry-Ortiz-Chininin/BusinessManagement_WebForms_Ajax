
Partial Class Estandares_FGCESVB
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim objSecurity As New ALVI_Security.General
            hdnIdMotivoAtributo.Value = Request("IdAT")
            Dim objAtributo As New ALVI_LOGIC.Maestros.Ventas.Motivo
            If hdnIdMotivoAtributo.Value <> "" Then
                objAtributo.IdMotivo = objSecurity.Decrypta(hdnIdMotivoAtributo.Value)
                If objAtributo.Obtener Then
                    lblAtributoTipo.Text = objAtributo.Descripcion
                End If
            End If
            pnlFormulario.Visible = False
            BindGrid()
        End If
    End Sub
    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        Nuevo()
    End Sub
    Private Sub Nuevo()
        LimpiarFormulario()
        Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
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
    End Sub
    Private Sub BindGrid()
        Dim objAtributo As New ALVI_LOGIC.Maestros.Ventas.AtributoMotivo
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdMotivoAtributo", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))

        Dim objSecurity As New ALVI_Security.General
        objAtributo.IdMotivo = objSecurity.Decrypta(hdnIdMotivoAtributo.Value)
        objAtributo.Descripcion = txtBusqueda.Text
        If objAtributo.Buscar() = True Then
            dtbDatos = objAtributo.Datos
        End If
        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
        Nuevo()
    End Sub

    Private Sub Registrar()
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" Then
            Dim objAtributo As New ALVI_LOGIC.Maestros.Ventas.AtributoMotivo
            Dim objSecurity As New ALVI_Security.General
            objAtributo.IdMotivo = objSecurity.Decrypta(hdnIdMotivoAtributo.Value)
            objAtributo.IdMotivoAtributo = txtCodigo.Text
            objAtributo.Descripcion = txtDescripcion.Text
            objAtributo.Usuario = Session("Usuario")
            objAtributo.Estado = "ACT"
            If objAtributo.Registrar = True Then
                lblMensaje.Text = "Registro exitoso"
                LimpiarFormulario()
                grdDatos.EditIndex = -1
                BindGrid()
            End If
        End If

    End Sub
    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Dim strURL As String = "FGCESVA.ASPX"
        strURL = strURL & "?IdSeccion=" & Master.IdSeccion
        strURL = strURL & "&IdMenu=" & Master.IdMenu
        strURL = strURL & "&IdSubMenu=" & Master.IdSubMenu

        Response.Redirect(strURL)

    End Sub
    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub
    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdMotivoAtributo='" & e.CommandArgument.ToString & "'")
                txtCodigo.Text = dtrItem("var_IdMotivoAtributo")
                txtDescripcion.Text = dtrItem("var_Descripcion")
                pnlFormulario.Visible = True
            Next
        End If
        If e.CommandName = "Eliminar" Then
            Dim objAtributo As New ALVI_LOGIC.Maestros.Ventas.AtributoMotivo
            Dim objSecurity As New ALVI_Security.General
            Dim strParametros As String = e.CommandArgument.ToString
            objAtributo.IdMotivo = objSecurity.Decrypta(hdnIdMotivoAtributo.Value)
            objAtributo.IdMotivoAtributo = e.CommandArgument.ToString
            If objAtributo.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGrid()
    End Sub
End Class
