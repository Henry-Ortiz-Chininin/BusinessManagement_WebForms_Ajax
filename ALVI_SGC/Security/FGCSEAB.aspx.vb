
Partial Class Security_FGCSEAB
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim objSecurity As New ALVI_Security.General
            hdnIdAccesoTipo.Value = Request("IdAcceso")
            If hdnIdAccesoTipo.Value <> "" Then
                Dim objAcceso As New ALVI_Security.Accesos.Tipo
                objAcceso.IdAccesoTipo = objSecurity.Decrypta(hdnIdAccesoTipo.Value)
                If objAcceso.Obtener Then
                    lblAccesoTipo.Text = objAcceso.Descripcion
                End If
            End If
            pnlFormulario.Visible = False
            BindGrid()
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        Nuevo()
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
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
        Dim objAcceso As New ALVI_Security.Accesos.Acceso

        Dim objSecurity As New ALVI_Security.General
        objAcceso.IdAccesoTipo = objSecurity.Decrypta(hdnIdAccesoTipo.Value)
        objAcceso.Listar()
        Session("dtbDatos") = objAcceso.Datos
        grdDatos.DataSource = objAcceso.Datos
        grdDatos.DataBind()

    End Sub
    Private Sub Nuevo()
        LimpiarFormulario()
        txtCodigo.ReadOnly = False
        pnlFormulario.Visible = True

        Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        If dtbDatos.Rows.Count > 0 Then
            txtCodigo.Text = dtbDatos.Compute("Max(int_Secuencia)", "") + 1
        Else
            txtCodigo.Text = 0
        End If
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" _
        AndAlso hdnIdAccesoTipo.Value <> "" Then
            Dim objAcceso As New ALVI_Security.Accesos.Acceso
            Dim objSecurity As New ALVI_Security.General
            objAcceso.IdAccesoTipo = objSecurity.Decrypta(hdnIdAccesoTipo.Value)
            objAcceso.Secuencia = txtCodigo.Text
            objAcceso.Descripcion = txtDescripcion.Text
            objAcceso.Usuario = Session("Usuario")
            objAcceso.Estado = "ACT"
            If objAcceso.Registrar = True Then
                LimpiarFormulario()
                lblMensaje.Text = "Registro exitoso"
                grdDatos.EditIndex = -1
                BindGrid()

            End If
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Dim strURL As String = "FGCSEAA.ASPX"
        strURL = strURL & "?IdSeccion=" & Master.IdSeccion
        strURL = strURL & "&IdMenu=" & Master.IdMenu

        Response.Redirect(strURL)

    End Sub

    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            Dim objAcceso As New ALVI_Security.Accesos.Acceso
            Dim objSecurity As New ALVI_Security.General
            objAcceso.IdAccesoTipo = objSecurity.Decrypta(hdnIdAccesoTipo.Value)
            objAcceso.Secuencia = e.CommandArgument
            If objAcceso.Obtener() Then
                txtCodigo.Text = objAcceso.IdAccesoTipo
                txtDescripcion.Text = objAcceso.Descripcion
            Else
                txtCodigo.Text = ""
                txtDescripcion.Text = ""
            End If
            pnlFormulario.Visible = True
        End If
        If e.CommandName = "Eliminar" Then
            Dim objAcceso As New ALVI_Security.Accesos.Acceso
            Dim objSecurity As New ALVI_Security.General
            Dim strParametros As String = e.CommandArgument.ToString
            objAcceso.IdAccesoTipo = objSecurity.Decrypta(hdnIdAccesoTipo.Value)
            objAcceso.Secuencia = e.CommandArgument
            If objAcceso.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub
End Class
