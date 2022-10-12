
Partial Class Configuracion_FGCCOAJ
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
        BindInductor()
        BindUnidadMedida()
        ddlInductor.SelectedIndex = 0
        ddlUnidadMedida.SelectedIndex = 0
        lblMensaje.Text = ""
    End Sub

    Private Sub BindInductor()
        Dim objInductor As New ALVI_LOGIC.Configuracion.Inductores
        ddlInductor.Items.Clear()
        If objInductor.Listar() = True Then
            ddlInductor.DataSource = objInductor.Datos
            ddlInductor.DataTextField = "var_Descripcion"
            ddlInductor.DataValueField = "var_IdInductor"
            ddlInductor.DataBind()
        End If
        ddlInductor.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlInductor.SelectedIndex = 0
    End Sub

    Private Sub BindUnidadMedida()
        Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
        ddlUnidadMedida.Items.Clear()
        If objUnidadMedida.Listar() = True Then
            ddlUnidadMedida.DataSource = objUnidadMedida.Datos
            ddlUnidadMedida.DataTextField = "var_Descripcion"
            ddlUnidadMedida.DataValueField = "var_IdUnidadMedida"
            ddlUnidadMedida.DataBind()
        End If
        ddlUnidadMedida.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlUnidadMedida.SelectedIndex = 0
    End Sub

    Private Sub BindGrid()
        Dim objEnergetico As New ALVI_LOGIC.Configuracion.Energetico
        Dim objInductor As New ALVI_LOGIC.Configuracion.Inductores
        Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdEnergetico", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))
        dtbDatos.Columns.Add("var_IdInductor", GetType(String))
        dtbDatos.Columns.Add("var_Inductor", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("var_UnidadMedida", GetType(String))

        If objEnergetico.Listar() = True AndAlso _
        objInductor.Listar = True AndAlso objUnidadMedida.Listar() = True Then
            For Each dtrItem As Data.DataRow In objEnergetico.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("var_IdEnergetico") = dtrItem("var_IdEnergetico")
                dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                dtrNuevo("var_IdInductor") = dtrItem("var_IdInductor")
                dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
                For Each dtrInductor As Data.DataRow In objInductor.Datos.Select("var_IdInductor ='" & dtrItem("var_IdInductor") & "'")
                    dtrNuevo("var_Inductor") = dtrInductor("var_Descripcion")
                Next

                For Each dtrUnidad As Data.DataRow In objUnidadMedida.Datos.Select("var_IdUnidadMedida ='" & dtrItem("var_IdUnidadMedida") & "'")
                    dtrNuevo("var_UnidadMedida") = dtrUnidad("var_Descripcion")
                Next

                dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                dtbDatos.AcceptChanges()
            Next
            Session("dtbDatos") = dtbDatos
            grdDatos.DataSource = dtbDatos
            grdDatos.DataBind()
        End If

    End Sub


    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub

    Private Sub Registrar()
        If txtCodigo.Text <> "" AndAlso txtDescripcion.Text <> "" _
            AndAlso ddlInductor.SelectedValue <> "" AndAlso ddlUnidadMedida.SelectedValue <> "" Then
            Dim objEnergetico As New ALVI_LOGIC.Configuracion.Energetico
            objEnergetico.IdEnergetico = txtCodigo.Text
            objEnergetico.Descripcion = txtDescripcion.Text
            objEnergetico.IdInductor = ddlInductor.SelectedValue
            objEnergetico.UnidadMedida = ddlUnidadMedida.SelectedValue
            objEnergetico.Usuario = Session("Usuario")
            objEnergetico.Estado = "ACT"
            If objEnergetico.Registrar = True Then
                LimpiarFormulario()
                lblMensaje.Text = "Registro exitoso"
                grdDatos.EditIndex = -1
                BindGrid()
            End If
        Else
            lblMensaje.Text = ""
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
            LimpiarFormulario()
            Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdEnergetico='" & e.CommandArgument.ToString & "'")
                txtCodigo.Text = dtrItem("var_IdEnergetico")
                txtDescripcion.Text = dtrItem("var_Descripcion")
                ddlInductor.SelectedValue = dtrItem("var_IdInductor")
                ddlUnidadMedida.SelectedValue = dtrItem("var_IdUnidadMedida")
                txtCodigo.ReadOnly = True
                pnlFormulario.Visible = True
            Next
        End If
        If e.CommandName = "Eliminar" Then
            Dim objUnidad As New ALVI_LOGIC.Configuracion.Energetico
            objUnidad.IdEnergetico = e.CommandArgument.ToString
            If objUnidad.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        Registrar()
        If lblMensaje.Text = "Registro exitoso" Then
            Cancelar()
        End If
    End Sub
End Class
