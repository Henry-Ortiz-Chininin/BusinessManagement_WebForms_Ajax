
Partial Class Security_FGCSEAC
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            If Request("IdGrupo") <> "" Then
                Dim objSeguridad As New ALVI_Security.General
                hdnIdGrupo.Value = Request("IdGrupo")
                Dim objPerfil As New ALVI_Security.clsPerfil
                If objPerfil.Obtener(objSeguridad.Decrypta(hdnIdGrupo.Value)) Then
                    lblGrupo.Text = objPerfil.Nombre
                Else
                    lblGrupo.Text = ""
                End If
            End If
            BindGrid()
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
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
        BindAccesoTipo()
        ddlAccesoValor.Items.Clear()
    End Sub

    Private Sub BindAccesoTipo()
        Dim objAccesoTipo As New ALVI_Security.Accesos.Tipo
        If objAccesoTipo.Listar Then
            ddlAccesoTipo.DataTextField = "var_Descripcion"
            ddlAccesoTipo.DataValueField = "chr_IdAccesoTipo"
            ddlAccesoTipo.DataSource = objAccesoTipo.Datos
            ddlAccesoTipo.DataBind()
        End If
        ddlAccesoTipo.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlAccesoTipo.SelectedIndex = 0
    End Sub

    Private Sub BindAccesoValor()
        Dim objAccesoValor As New ALVI_Security.Accesos.Acceso
        objAccesoValor.IdAccesoTipo = ddlAccesoTipo.SelectedValue
        If objAccesoValor.Listar Then
            ddlAccesoValor.DataTextField = "var_Descripcion"
            ddlAccesoValor.DataValueField = "int_Secuencia"
            ddlAccesoValor.DataSource = objAccesoValor.Datos
            ddlAccesoValor.DataBind()
        End If
        ddlAccesoValor.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlAccesoValor.SelectedIndex = 0
    End Sub

    Private Sub BindGrid()
        Dim objAccesoGrupo As New ALVI_Security.Accesos.AccesoPerfil
        Dim objAccesoValor As New ALVI_Security.Accesos.Acceso
        Dim objAccesoTipo As New ALVI_Security.Accesos.Tipo
        Dim objSeguridad As New ALVI_Security.General
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("chr_IdAccesoTipo", GetType(String))
        dtbDatos.Columns.Add("var_AccesoTipo", GetType(String))
        dtbDatos.Columns.Add("int_Secuencia", GetType(Int16))
        dtbDatos.Columns.Add("var_AccesoValor", GetType(String))
        dtbDatos.Columns.Add("var_Codigo", GetType(String))


        If objAccesoTipo.Listar() = True Then
            For Each dtrTipo As Data.DataRow In objAccesoTipo.Datos.Rows
                objAccesoGrupo.IdAccesoTipo = dtrTipo("chr_IdAccesoTipo")
                objAccesoGrupo.IdGrupo = objSeguridad.Decrypta(hdnIdGrupo.Value)
                If objAccesoGrupo.Listar() Then
                    For Each dtrItem As Data.DataRow In objAccesoGrupo.Datos.Rows
                        Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                        dtrNuevo("chr_IdAccesoTipo") = dtrItem("chr_IdAccesoTipo")
                        dtrNuevo("int_Secuencia") = dtrItem("int_Secuencia")
                        dtrNuevo("var_AccesoTipo") = dtrTipo("var_Descripcion")
                        dtrNuevo("var_Codigo") = dtrItem("chr_IdAccesoTipo") & "-" & CStr(dtrItem("int_Secuencia"))

                        objAccesoValor.IdAccesoTipo = dtrItem("chr_IdAccesoTipo")
                        objAccesoValor.Secuencia = dtrItem("int_Secuencia")
                        If objAccesoValor.Obtener() Then
                            dtrNuevo("var_AccesoValor") = objAccesoValor.Descripcion
                        Else
                            dtrNuevo("var_AccesoValor") = ""
                        End If

                        dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                        dtbDatos.AcceptChanges()
                    Next
        End If
            Next

        End If
        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = New Data.DataView(dtbDatos, "", "var_Codigo", Data.DataViewRowState.OriginalRows)
        grdDatos.DataBind()
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If ddlAccesoTipo.SelectedValue <> "" AndAlso ddlAccesoValor.SelectedValue <> "" Then
            Dim objAccesoGrupo As New ALVI_Security.Accesos.AccesoPerfil
            Dim objSeguridad As New ALVI_Security.General
            objAccesoGrupo.IdAccesoTipo = ddlAccesoTipo.SelectedValue
            objAccesoGrupo.IdGrupo = objSeguridad.Decrypta(hdnIdGrupo.Value)
            objAccesoGrupo.Secuencia = ddlAccesoValor.SelectedValue
            objAccesoGrupo.Usuario = Session("Usuario")
            If objAccesoGrupo.Registrar = True Then
                LimpiarFormulario()
                lblMensaje.Text = "Registro exitoso"
                grdDatos.EditIndex = -1
                BindGrid()
            End If
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Dim strURL As String = "PERFIL.ASPX"
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
        If e.CommandName = "Eliminar" Then
            Dim objAccesoGrupo As New ALVI_Security.Accesos.AccesoPerfil
            Dim objSeguridad As New ALVI_Security.General
            Dim strParametros() As String = Split(e.CommandArgument.ToString, "-")
            objAccesoGrupo.IdAccesoTipo = strParametros(0)
            objAccesoGrupo.Secuencia = strParametros(1)
            objAccesoGrupo.IdGrupo = objSeguridad.Decrypta(hdnIdGrupo.Value)
            If objAccesoGrupo.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub


    Protected Sub ddlAccesoTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAccesoTipo.SelectedIndexChanged
        BindAccesoValor()
    End Sub
End Class
