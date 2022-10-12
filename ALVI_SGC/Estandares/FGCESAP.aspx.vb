
Partial Class Estandares_FGCESAP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            BindGrid()
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        pnlFormulario.Visible = True
        txtCodigo.ReadOnly = False
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid()
    End Sub

    Private Sub LimpiarFormulario()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        BindEtapa()
        BindProceso()
    End Sub
    Private Sub BindEtapa()
        Dim objEtapa As New ALVI_LOGIC.Maestros.Produccion.Etapa
        ddlEtapa.Items.Clear()
        If objEtapa.Listar() = True Then
            ddlEtapa.DataValueField = "chr_IdEtapa"
            ddlEtapa.DataTextField = "var_Descripcion"
            ddlEtapa.DataSource = objEtapa.Datos
            ddlEtapa.DataBind()
        End If
        ddlEtapa.Items.Insert(0, "Seleccionar")
        ddlEtapa.SelectedIndex = 0
    End Sub
    Private Sub BindProceso()
        Dim objProceso As New ALVI_LOGIC.Maestros.Produccion.Proceso
        ddlProceso.Items.Clear()
        objProceso.IdEtapa = ddlEtapa.SelectedValue
        If objProceso.Listar() = True Then
            ddlProceso.DataValueField = "chr_IdProceso"
            ddlProceso.DataTextField = "var_Descripcion"
            ddlProceso.DataSource = objProceso.Datos
            ddlProceso.DataBind()
        End If
        ddlProceso.Items.Insert(0, "Seleccionar")
        ddlProceso.SelectedIndex = 0
    End Sub
    Private Sub BindGrid()
        Dim objOperacion As New ALVI_LOGIC.Maestros.Ruta.Operacion
        Dim objProceso As New ALVI_LOGIC.Maestros.Produccion.Proceso
        Dim objEtapa As New ALVI_LOGIC.Maestros.Produccion.Etapa

        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdOperacion", GetType(String))
        dtbDatos.Columns.Add("chr_IdEtapa", GetType(String))
        dtbDatos.Columns.Add("chr_IdProceso", GetType(String))
        dtbDatos.Columns.Add("var_Etapa", GetType(String))
        dtbDatos.Columns.Add("var_Proceso", GetType(String))
        dtbDatos.Columns.Add("var_IdSecuencia", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))
        objEtapa.Listar()
        objProceso.IdEtapa = ""
        objProceso.Listar()
        objOperacion.IdProceso = ""
        If objEtapa.Listar() = True AndAlso objOperacion.Listar() = True Then
            For Each dtrItem As Data.DataRow In objOperacion.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("chr_IdProceso") = dtrItem("chr_IdProceso")
                dtrNuevo("var_IdOperacion") = dtrItem("var_IdOperacion")
                dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                For Each dtrAuxiliar As Data.DataRow In objProceso.Datos.Select("chr_IdProceso='" & dtrItem("chr_IdProceso") & "'")
                    dtrNuevo("var_Proceso") = dtrAuxiliar("var_Descripcion")
                    dtrNuevo("chr_IdEtapa") = dtrAuxiliar("chr_IdEtapa")

                    For Each dtrEtapa As Data.DataRow In objEtapa.Datos.Select("chr_IdEtapa='" & dtrAuxiliar("chr_IdEtapa") & "'")
                        dtrNuevo("var_Etapa") = dtrEtapa("var_Descripcion")
                    Next
                Next

                dtrNuevo("var_IdSecuencia") = dtrNuevo("chr_IdEtapa") & "-" & dtrNuevo("chr_IdProceso") & "-" & dtrItem("var_IdOperacion")

                dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                dtbDatos.AcceptChanges()
            Next

        End If
        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()
    End Sub
    Private Sub BindGridBuscar()
        Dim objOperacion As New ALVI_LOGIC.Maestros.Ruta.Operacion
        Dim objProceso As New ALVI_LOGIC.Maestros.Produccion.Proceso
        Dim objEtapa As New ALVI_LOGIC.Maestros.Produccion.Etapa

        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdOperacion", GetType(String))
        dtbDatos.Columns.Add("chr_IdEtapa", GetType(String))
        dtbDatos.Columns.Add("chr_IdProceso", GetType(String))
        dtbDatos.Columns.Add("var_Etapa", GetType(String))
        dtbDatos.Columns.Add("var_Proceso", GetType(String))
        dtbDatos.Columns.Add("var_IdSecuencia", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))
        objEtapa.Listar()
        objProceso.IdEtapa = ""
        objOperacion.Descripcion = txtBuscar.Text
        objProceso.Listar()
        objOperacion.IdProceso = ""
        If objEtapa.Listar() = True AndAlso objOperacion.Buscar() = True Then
            For Each dtrItem As Data.DataRow In objOperacion.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("chr_IdProceso") = dtrItem("chr_IdProceso")
                dtrNuevo("var_IdOperacion") = dtrItem("var_IdOperacion")
                dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                For Each dtrAuxiliar As Data.DataRow In objProceso.Datos.Select("chr_IdProceso='" & dtrItem("chr_IdProceso") & "'")
                    dtrNuevo("var_Proceso") = dtrAuxiliar("var_Descripcion")
                    dtrNuevo("chr_IdEtapa") = dtrAuxiliar("chr_IdEtapa")

                    For Each dtrEtapa As Data.DataRow In objEtapa.Datos.Select("chr_IdEtapa='" & dtrAuxiliar("chr_IdEtapa") & "'")
                        dtrNuevo("var_Etapa") = dtrEtapa("var_Descripcion")
                    Next
                Next

                dtrNuevo("var_IdSecuencia") = dtrNuevo("chr_IdEtapa") & "-" & dtrNuevo("chr_IdProceso") & "-" & dtrItem("var_IdOperacion")

                dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                dtbDatos.AcceptChanges()
            Next

        End If
        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()
    End Sub
    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtCodigo.Text <> "" AndAlso ddlProceso.SelectedValue <> "" _
        AndAlso txtDescripcion.Text <> "" Then
            Dim objOperacion As New ALVI_LOGIC.Maestros.Ruta.Operacion
            objOperacion.IdOperacion = txtCodigo.Text
            objOperacion.IdProceso = ddlProceso.SelectedValue
            objOperacion.Descripcion = txtDescripcion.Text
            objOperacion.Usuario = Session("Usuario")
            objOperacion.Estado = "ACT"
            If objOperacion.Registrar = True Then
                lblMensaje.Text = "Registro exitoso"
                LimpiarFormulario()
                grdDatos.EditIndex = -1
                BindGrid()
            End If
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
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdSecuencia='" & e.CommandArgument.ToString & "'")
                txtCodigo.Text = dtrItem("var_IdOperacion")
                BindEtapa()
                ddlEtapa.SelectedValue = dtrItem("chr_IdEtapa")
                BindProceso()
                ddlProceso.SelectedValue = dtrItem("chr_IdProceso")
                txtDescripcion.Text = dtrItem("var_Descripcion")
                txtCodigo.ReadOnly = True
                pnlFormulario.Visible = True
            Next
        End If
        If e.CommandName = "Eliminar" Then
            Dim objOperacion As New ALVI_LOGIC.Maestros.Ruta.Operacion
            Dim strParametros() As String = Split(e.CommandArgument.ToString, "-")
            objOperacion.IdProceso = strParametros(1)
            objOperacion.IdOperacion = strParametros(2)

            If objOperacion.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub
    Protected Sub txtBuscar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        BindGridBuscar()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGridBuscar()
    End Sub
End Class
