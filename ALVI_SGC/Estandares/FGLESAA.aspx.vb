

Partial Class Estandares_FGLESAA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False


            BindGrid()

    
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        'LimpiarFormulario()
        pnlFormulario.Visible = True
        txtPresupuestado.Text = "0"
        txtEjecutado.Text = "0"
        lblMensaje.Text = ""
        txtCodigo.ReadOnly = False

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
        Cancelar()
        pnlFormulario.Visible = False
    End Sub


    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()

    End Sub

    Private Sub Registrar()

        If txtCodigo.Text <> "" AndAlso txtNombreProyecto.Text <> "" AndAlso txtDescripcionProyecto.Text <> "" _
            AndAlso txtPresupuestado.Text <> "" AndAlso txtEjecutado.Text <> "" Then

            Dim objProyecto As New ALVI_LOGIC.Maestros.Compras.Proyectos
            objProyecto.IdCodigo = txtCodigo.Text
            objProyecto.Nombre = txtNombreProyecto.Text
            objProyecto.Descripcion = txtDescripcionProyecto.Text
            objProyecto.Presupuesto = txtPresupuestado.Text
            objProyecto.Ejecutado = txtEjecutado.Text
            objProyecto.Estado = ddlEstadoProyecto.SelectedValue()

            objProyecto.Usuario = Session("Usuario")
            If objProyecto.Registrar = True Then


                lblMensaje.Text = "Registro exitoso"
                LimpiarFormulario()
                grdDatos.EditIndex = -1
                BindGrid()

            Else
                lblMensaje.Text = "Datos Incorrectos"
            End If

        Else : lblMensaje.Text = "Faltan Datos"




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
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdProyecto='" & e.CommandArgument.ToString & "'")
                txtCodigo.Text = dtrItem("var_IdProyecto")
                txtNombreProyecto.Text = dtrItem("var_Nombre")
                txtDescripcionProyecto.Text = dtrItem("var_Descripcion")
                txtPresupuestado.Text = dtrItem("num_ImpPresupuesto")
                txtEjecutado.Text = dtrItem("num_ImpUtilizado")
                ' ddlEstadoProyecto.SelectedValue = dtrItem("var_Estado")

            Next
            pnlFormulario.Visible = True
            txtCodigo.ReadOnly = True


        End If


        If e.CommandName = "Eliminar" Then
            Dim objProyecto As New ALVI_LOGIC.Maestros.Compras.Proyectos
            objProyecto.IdCodigo = e.CommandArgument.ToString
            If objProyecto.Eliminar = True Then

                BindGrid()
            End If
            BindGrid()



        End If


    End Sub


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        Buscar()
    End Sub

    Private Sub Buscar()
        BindGrid()


    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        Registrar()
        Cancelar()
    End Sub
    Private Sub Cancelar()
        LimpiarFormulario()
        pnlFormulario.Visible = False

    End Sub

    Private Sub LimpiarFormulario()
        txtCodigo.Text = ""
        txtNombreProyecto.Text = ""
        txtDescripcionProyecto.Text = ""
        txtPresupuestado.Text = "0"
        txtEjecutado.Text = "0"


        ddlEstado.SelectedIndex = 0
    End Sub



    Private Sub BindGrid()
        Dim objProyecto As New ALVI_LOGIC.Maestros.Compras.Proyectos
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdProyecto", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))
        dtbDatos.Columns.Add("var_Nombre", GetType(String))
        dtbDatos.Columns.Add("var_Estado", GetType(String))
        dtbDatos.Columns.Add("num_ImpPresupuesto", GetType(Double))
        dtbDatos.Columns.Add("num_ImpUtilizado", GetType(Double))




        If txtNombre.Text <> "" Or txtDescripcion.Text <> "" Or ddlEstado.SelectedValue <> "" Then

            objProyecto.Nombre = txtNombre.Text
            objProyecto.Descripcion = txtDescripcion.Text
            objProyecto.Estado = ddlEstado.SelectedValue
            If objProyecto.Buscar() = True Then
                For Each dtrItem As Data.DataRow In objProyecto.Datos.Rows
                    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                    dtrNuevo("var_IdProyecto") = dtrItem("var_IdProyecto")
                    dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                    dtrNuevo("var_Nombre") = dtrItem("var_Nombre")
                    dtrNuevo("var_Estado") = dtrItem("var_Estado")

                    dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                    dtbDatos.AcceptChanges()
                Next
            End If
        Else

            If objProyecto.Listar() = True Then
                For Each dtrItem As Data.DataRow In objProyecto.Datos.Rows
                    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                    dtrNuevo("var_IdProyecto") = dtrItem("var_IdProyecto")
                    dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                    dtrNuevo("var_Nombre") = dtrItem("var_Nombre")
                    dtrNuevo("var_Estado") = dtrItem("var_Estado")
                    dtrNuevo("num_ImpPresupuesto") = dtrItem("num_ImpPresupuesto")
                    dtrNuevo("num_ImpUtilizado") = dtrItem("num_ImpUtilizado")


                    dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                    dtbDatos.AcceptChanges()
                Next
            End If


        End If
        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = New Data.DataView(dtbDatos, "", "var_IdProyecto", Data.DataViewRowState.OriginalRows)
        grdDatos.DataBind()
    End Sub
End Class
