
Partial Class Estandares_FGLESAF
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False


            BindGrid()
        End If
    End Sub


    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        pnlFormulario.Visible = True
        lblMensaje.Text = ""
        txtDescripcion.Text = ""
        txtImporte.Text = "0"
        txtCodigo.ReadOnly = False
    End Sub


    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
        Cancelar()
        pnlFormulario.Visible = False
        BindGrid()


    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub

    Private Sub Registrar()
        If txtCodigo.Text <> "" AndAlso txtDescripcionCondicion.Text <> "" AndAlso txtImporte.Text <> "" Then
            Dim objCondicion As New ALVI_LOGIC.Maestros.Compras.Condicion
            objCondicion.IdCondicion = txtCodigo.Text
            objCondicion.Descripcion = txtDescripcionCondicion.Text
            objCondicion.Monto = txtImporte.Text
            objCondicion.Estado = "ACT"
            objCondicion.Usuario = Session("Usuario")
            If objCondicion.Registrar = True Then

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



    Private Sub LimpiarFormulario()
        txtCodigo.Text = ""
        txtDescripcionCondicion.Text = ""
        txtImporte.Text = ""
    End Sub

    Private Sub Cancelar()
        LimpiarFormulario()
        pnlFormulario.Visible = False
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
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdCondicion='" & e.CommandArgument.ToString & "'")
                txtCodigo.Text = dtrItem("var_IdCondicion")
                txtDescripcionCondicion.Text = dtrItem("var_Descripcion")
                txtImporte.Text = dtrItem("dec_MontoLimitado")
                txtCodigo.Enabled = True
            Next

            pnlFormulario.Visible = True
            txtCodigo.ReadOnly = True




        End If

        If e.CommandName = "Eliminar" Then

            Dim objCondicion As New ALVI_LOGIC.Maestros.Compras.Condicion
            objCondicion.IdCondicion = e.CommandArgument.ToString
            If objCondicion.Eliminar = True Then

                BindGrid()


            End If
        End If


    End Sub


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGrid()

    End Sub




    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        Registrar()
        Cancelar()
    End Sub

    Private Sub BindGrid()
        Dim objCondicion As New ALVI_LOGIC.Maestros.Compras.Condicion
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdCondicion", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))
        dtbDatos.Columns.Add("dec_MontoLimitado", GetType(Double))






        If txtDescripcion.Text <> "" Then


            objCondicion.Descripcion = txtDescripcion.Text

            If objCondicion.Buscar() = True Then
                For Each dtrItem As Data.DataRow In objCondicion.Datos.Rows
                    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                    dtrNuevo("var_IdCondicion") = dtrItem("var_IdCondicion")
                    dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")


                    dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                    dtbDatos.AcceptChanges()
                Next
            End If
        Else

            If objCondicion.Listar() = True Then
                For Each dtrItem As Data.DataRow In objCondicion.Datos.Rows
                    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                    dtrNuevo("var_IdCondicion") = dtrItem("var_IdCondicion")
                    dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                    dtrNuevo("dec_MontoLimitado") = dtrItem("dec_MontoLimitado")


                    dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                    dtbDatos.AcceptChanges()
                Next
            End If


        End If
        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = New Data.DataView(dtbDatos, "", "var_IdCondicion", Data.DataViewRowState.OriginalRows)
        grdDatos.DataBind()
    End Sub





End Class
