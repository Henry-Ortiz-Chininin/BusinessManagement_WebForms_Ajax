
Partial Class Estandares_FGLESAC
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
        If txtCodigo.Text <> "" AndAlso txtDescripcionCargo.Text <> "" Then
            Dim objCargo As New ALVI_LOGIC.Maestros.Compras.Cargo
            objCargo.IdCargo = txtCodigo.Text
            objCargo.Descripcion = txtDescripcionCargo.Text
            objCargo.Usuario = Session("Usuario")
            objCargo.Estado = "ACT"

            If objCargo.Registrar = True Then
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
        txtDescripcionCargo.Text = ""


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
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdCargo='" & e.CommandArgument.ToString & "'")
                txtCodigo.Text = dtrItem("var_IdCargo")
                txtDescripcionCargo.Text = dtrItem("var_Descripcion")
                txtCodigo.Enabled = True
            Next

            pnlFormulario.Visible = True
            txtCodigo.ReadOnly = True




        End If

        If e.CommandName = "Eliminar" Then

            Dim objCargo As New ALVI_LOGIC.Maestros.Compras.Cargo
            objCargo.IdCargo = e.CommandArgument.ToString
            If objCargo.Eliminar = True Then

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
        Dim objCargo As New ALVI_LOGIC.Maestros.Compras.Cargo
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdCargo", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))





        If txtDescripcion.Text <> "" Then


            objCargo.Descripcion = txtDescripcion.Text

            If objCargo.Buscar() = True Then
                For Each dtrItem As Data.DataRow In objCargo.Datos.Rows
                    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                    dtrNuevo("var_IdCargo") = dtrItem("var_IdCargo")
                    dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")


                    dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                    dtbDatos.AcceptChanges()
                Next
            End If
        Else

            If objCargo.Listar() = True Then
                For Each dtrItem As Data.DataRow In objCargo.Datos.Rows
                    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                    dtrNuevo("var_IdCargo") = dtrItem("var_IdCargo")
                    dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")


                    dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                    dtbDatos.AcceptChanges()
                Next
            End If


        End If
        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = New Data.DataView(dtbDatos, "", "var_IdCargo", Data.DataViewRowState.OriginalRows)
        grdDatos.DataBind()
    End Sub


End Class
