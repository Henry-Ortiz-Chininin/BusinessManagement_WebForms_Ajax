
Partial Class Estandares_FGLESAG
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False


            BindGrid()
        End If
    End Sub


    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click

        pnlFormulario.Visible = True
        txtPorcentaje.Text = "0"
        txtImporte.Text = "0"
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

        If txtCodigo.Text <> "" AndAlso txtDescripcionConceptuales.Text <> "" _
            AndAlso txtPorcentaje.Text <> "" AndAlso txtImporte.Text <> "" AndAlso ddlDireccion.SelectedValue <> "" Then

            Dim objConcepto As New ALVI_LOGIC.Maestros.Requisicion.Conceptos
            objConcepto.IdCodigo = txtCodigo.Text

            objConcepto.Descripcion = txtDescripcionConceptuales.Text
            objConcepto.Porcentaje = txtPorcentaje.Text
            objConcepto.Importe = txtImporte.Text
            objConcepto.Dirrecion = ddlDireccion.SelectedValue()
            objConcepto.Estado = "ACT"
            objConcepto.Usuario = Session("Usuario")
            If objConcepto.Registrar = True Then


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
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdConcepto='" & e.CommandArgument.ToString & "'")
                txtCodigo.Text = dtrItem("var_IdConcepto")

                txtDescripcionConceptuales.Text = dtrItem("var_Descripcion")
                txtPorcentaje.Text = dtrItem("dec_Porcentaje")
                txtImporte.Text = dtrItem("num_Importe")
                ' ddlDireccion.SelectedValue = dtrItem("var_Direccion")

            Next
            pnlFormulario.Visible = True
            txtCodigo.ReadOnly = True



        End If


        If e.CommandName = "Eliminar" Then
            Dim objConcepto As New ALVI_LOGIC.Maestros.Requisicion.Conceptos
            objConcepto.IdCodigo = e.CommandArgument.ToString
            If objConcepto.Eliminar = True Then

                BindGrid()
            End If
            BindGrid()



        End If


    End Sub


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
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

        txtDescripcionConceptuales.Text = ""
        txtPorcentaje.Text = "0"
        txtImporte.Text = "0"


        ddlDireccion.SelectedIndex = 0
    End Sub
    Private Sub BindGrid()
        Dim objConcepto As New ALVI_LOGIC.Maestros.Requisicion.Conceptos
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdConcepto", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))
        dtbDatos.Columns.Add("dec_Porcentaje", GetType(Double))
        dtbDatos.Columns.Add("num_Importe", GetType(Double))
        dtbDatos.Columns.Add("var_Direccion", GetType(String))




        If txtDescripcion.Text <> "" Then


            objConcepto.Descripcion = txtDescripcion.Text

            If objConcepto.Buscar() = True Then
                For Each dtrItem As Data.DataRow In objConcepto.Datos.Rows
                    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                    dtrNuevo("var_IdConcepto") = dtrItem("var_IdConcepto")
                    dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                    dtrNuevo("dec_Porcentaje") = dtrItem("Porcentaje")
                    dtrNuevo("num_Importe") = dtrItem("Importe")
                    dtrNuevo("var_Direccion") = dtrItem("var_Direcion")



                    dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                    dtbDatos.AcceptChanges()
                Next
            End If
        Else

            If objConcepto.Listar() = True Then
                For Each dtrItem As Data.DataRow In objConcepto.Datos.Rows
                    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                    dtrNuevo("var_IdConcepto") = dtrItem("var_IdConcepto")
                    dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                    dtrNuevo("dec_Porcentaje") = dtrItem("dec_Porcentaje")
                    dtrNuevo("num_Importe") = dtrItem("num_Importe")
                    dtrNuevo("var_Direccion") = dtrItem("var_Direccion")


                    dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                    dtbDatos.AcceptChanges()
                Next
            End If


        End If
        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = New Data.DataView(dtbDatos, "", "var_IdConcepto", Data.DataViewRowState.OriginalRows)
        grdDatos.DataBind()
    End Sub

End Class
