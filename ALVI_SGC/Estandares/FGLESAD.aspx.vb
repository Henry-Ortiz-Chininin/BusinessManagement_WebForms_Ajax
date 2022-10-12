
Partial Class Estandares_FGLESAD
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
        If txtCodigo.Text <> "" AndAlso txtDescripcionArea.Text <> "" Then
            Dim objArea As New ALVI_LOGIC.Maestros.Administracion.Area
            objArea.IdArea = txtCodigo.Text
            objArea.Descripcion = txtDescripcionArea.Text
            objArea.Usuario = Session("Usuario")
            objArea.Estado = "ACT"
            If objArea.Registrar = True Then

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
        txtDescripcionArea.Text = ""
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
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdArea='" & e.CommandArgument.ToString & "'")
                txtCodigo.Text = dtrItem("var_IdArea")
                txtDescripcionArea.Text = dtrItem("var_Descripcion")

            Next

            pnlFormulario.Visible = True
            txtCodigo.ReadOnly = True

        End If

        If e.CommandName = "Eliminar" Then

            Dim objArea As New ALVI_LOGIC.Maestros.Administracion.Area
            objArea.IdArea = e.CommandArgument.ToString
            If objArea.Eliminar = True Then

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
        Dim objArea As New ALVI_LOGIC.Maestros.Administracion.Area
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdArea", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))





        If txtDescripcion.Text <> "" Then


            objArea.Descripcion = txtDescripcion.Text

            If objArea.Buscar() = True Then
                For Each dtrItem As Data.DataRow In objArea.Datos.Rows
                    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                    dtrNuevo("var_IdArea") = dtrItem("var_IdArea")
                    dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")


                    dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                    dtbDatos.AcceptChanges()
                Next
            End If
        Else

            If objArea.Listar() = True Then
                For Each dtrItem As Data.DataRow In objArea.Datos.Rows
                    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                    dtrNuevo("var_IdArea") = dtrItem("var_IdArea")
                    dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")


                    dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                    dtbDatos.AcceptChanges()
                Next
            End If


        End If
        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = New Data.DataView(dtbDatos, "", "var_IdArea", Data.DataViewRowState.OriginalRows)
        grdDatos.DataBind()
    End Sub



End Class
