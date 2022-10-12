
Partial Class Estandares_FGCESAF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            pnlEnergetico.Visible = False
            BindGrid()
            BindUnidadMedida()
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        If dtbDatos.Rows.Count > 0 Then
            Try
                Dim strIdentificador As String = dtbDatos.Compute("Max(var_IdMaquina)", "")+1
                txtCodigo.Text = strIdentificador
            Catch
                txtCodigo.Text = "0"
            End Try
        End If
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
        ctlCentroCosto1.IdCentroCosto = ""
        lblCentroCosto.Text = ""
        txtPesoMaximo.Text = ""
        txtPesoMinimo.Text = ""
        txtVolMaximo.Text = ""
        txtVolMinimo.Text = ""
        txtVelocidad.Text = ""
        txtRelacionBano.Text = ""
        BindPlanta()
        BindTipoMaquina()
    End Sub
    Private Sub BindPlanta()
        Dim objPlanta As New ALVI_LOGIC.Maestros.Produccion.Planta
        ddlPlanta.Items.Clear()
        If objPlanta.Listar = True Then
            ddlPlanta.DataSource = objPlanta.Datos
            ddlPlanta.DataTextField = "var_Descripcion"
            ddlPlanta.DataValueField = "var_IdPlanta"
            ddlPlanta.DataBind()
        End If
        ddlPlanta.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlPlanta.SelectedIndex = 0
    End Sub

    Private Sub BindTipoMaquina()
        Dim objTipoMaquina As New ALVI_LOGIC.Maestros.Produccion.TipoMaquina
        ddlTipoMaquina.Items.Clear()
        If objTipoMaquina.Listar = True Then
            ddlTipoMaquina.DataSource = objTipoMaquina.Datos
            ddlTipoMaquina.DataTextField = "var_Descripcion"
            ddlTipoMaquina.DataValueField = "var_IdTipoMaquina"
            ddlTipoMaquina.DataBind()
        End If
        ddlTipoMaquina.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlTipoMaquina.SelectedIndex = 0
    End Sub
    Private Sub BindGrid()
        Dim objMaquina As New ALVI_LOGIC.Maestros.Produccion.Maquina
        Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
        Dim objPlanta As New ALVI_LOGIC.Maestros.Produccion.Planta
        Dim objTipoMaquina As New ALVI_LOGIC.Maestros.Produccion.TipoMaquina
        objMaquina.Descripcion = txtBusqueda.Text.ToString
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdMaquina", GetType(String))
        dtbDatos.Columns.Add("var_IdPlanta", GetType(String))
        dtbDatos.Columns.Add("var_IdTipoMaquina", GetType(String))
        dtbDatos.Columns.Add("var_Planta", GetType(String))
        dtbDatos.Columns.Add("var_TipoMaquina", GetType(String))
        dtbDatos.Columns.Add("var_IdCentroCosto", GetType(String))
        dtbDatos.Columns.Add("var_CentroCosto", GetType(String))
        dtbDatos.Columns.Add("var_Descripcion", GetType(String))
        dtbDatos.Columns.Add("var_volmax", GetType(String))
        dtbDatos.Columns.Add("var_volmin", GetType(String))
        dtbDatos.Columns.Add("var_pesoMax", GetType(String))
        dtbDatos.Columns.Add("var_pesoMin", GetType(String))
        dtbDatos.Columns.Add("var_velocidad", GetType(String))
        dtbDatos.Columns.Add("var_relacionBano", GetType(String))
        objPlanta.Listar()

        If objCentroCosto.Listar() = True _
        AndAlso objMaquina.Buscar() = True AndAlso objTipoMaquina.Listar() = True Then
            For Each dtrItem As Data.DataRow In objMaquina.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("var_IdMaquina") = dtrItem("var_IdMaquina")
                dtrNuevo("var_IdPlanta") = dtrItem("var_IdPlanta")
                dtrNuevo("var_IdTipoMaquina") = dtrItem("var_IdTipoMaquina")
                dtrNuevo("var_IdCentroCosto") = dtrItem("var_IdCentroCosto")
                dtrNuevo("var_Descripcion") = dtrItem("var_Descripcion")
                dtrNuevo("var_volmax") = dtrItem("var_volmax")
                dtrNuevo("var_volmin") = dtrItem("var_volmin")
                dtrNuevo("var_pesoMax") = dtrItem("var_pesoMax")
                dtrNuevo("var_pesoMin") = dtrItem("var_pesoMin")
                dtrNuevo("var_velocidad") = dtrItem("var_velocidad")
                dtrNuevo("var_relacionBano") = dtrItem("var_relacionBano")
                For Each dtrAuxiliar As Data.DataRow In objCentroCosto.Datos.Select("var_IdCentroCosto='" & dtrItem("var_IdCentroCosto") & "'")
                    dtrNuevo("var_CentroCosto") = dtrAuxiliar("var_Descripcion")
                Next
                For Each dtrAuxiliar As Data.DataRow In objPlanta.Datos.Select("var_IdPlanta='" & dtrItem("var_IdPlanta") & "'")
                    dtrNuevo("var_Planta") = dtrAuxiliar("var_Descripcion")
                Next
                For Each dtrAuxiliar As Data.DataRow In objTipoMaquina.Datos.Select("var_IdTipoMaquina='" & dtrItem("var_IdTipoMaquina") & "'")
                    dtrNuevo("var_TipoMaquina") = dtrAuxiliar("var_Descripcion")
                Next
                dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                dtbDatos.AcceptChanges()
            Next

        End If
        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = New Data.DataView(dtbDatos, "", "var_IdPlanta, var_IdMaquina", Data.DataViewRowState.OriginalRows)
        grdDatos.DataBind()
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtCodigo.Text <> "" AndAlso ctlCentroCosto1.IdCentroCosto <> "" _
        AndAlso ddlPlanta.SelectedValue <> "" _
        AndAlso txtDescripcion.Text <> "" _
        AndAlso txtVolMinimo.Text <> "" _
        AndAlso txtVolMaximo.Text <> "" _
        AndAlso txtPesoMinimo.Text <> "" _
        AndAlso txtPesoMaximo.Text <> "" _
        AndAlso txtVelocidad.Text <> "" _
        AndAlso txtRelacionBano.Text <> "" Then
            Dim objMaquina As New ALVI_LOGIC.Maestros.Produccion.Maquina
            objMaquina.IdMaquina = txtCodigo.Text
            objMaquina.IdCentroCosto = ctlCentroCosto1.IdCentroCosto.ToString
            objMaquina.IdPlanta = ddlPlanta.SelectedValue
            objMaquina.IdTipoMaquina = ddlTipoMaquina.SelectedValue
            objMaquina.Descripcion = txtDescripcion.Text
            objMaquina.Usuario = Session("Usuario")
            objMaquina.Estado = "ACT"
            objMaquina.VolumenMaximo = txtVolMaximo.Text
            objMaquina.VolumenMinimo = txtVolMinimo.Text
            objMaquina.PesoMaximo = txtPesoMaximo.Text
            objMaquina.PesoMinimo = txtPesoMinimo.Text
            objMaquina.Velocidad = txtVelocidad.Text
            objMaquina.RelacionBaño = txtRelacionBano.Text
            objMaquina.UnidadVelocidad = ddlUnidadVelocidad.SelectedValue.ToString
            objMaquina.UnidadVolumen = ddlUnidadVolumen.SelectedValue.ToString
            objMaquina.UnidadPeso = ddlUnidadPeso.SelectedValue.ToString
            If objMaquina.Registrar = True Then
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
            For Each dtrItem As Data.DataRow In dtbDatos.Select("var_IdMaquina='" & e.CommandArgument.ToString & "'")
                txtCodigo.Text = dtrItem("var_IdMaquina")
                ctlCentroCosto1.IdCentroCosto = dtrItem("var_IdCentroCosto")
                lblCentroCosto.Text = dtrItem("var_CentroCosto")
                ddlPlanta.SelectedValue = dtrItem("var_IdPlanta")
                ddlTipoMaquina.SelectedValue = dtrItem("var_IdTipoMaquina")
                txtDescripcion.Text = dtrItem("var_Descripcion")
                txtPesoMaximo.Text = dtrItem("var_pesoMax")
                txtPesoMinimo.Text = dtrItem("var_pesoMin")
                txtVolMaximo.Text = dtrItem("var_volmax")
                txtVolMinimo.Text = dtrItem("var_volmin")
                txtVelocidad.Text = dtrItem("var_velocidad")
                txtRelacionBano.Text = dtrItem("var_relacionBano")
                txtCodigo.ReadOnly = True
                pnlFormulario.Visible = True
            Next
        End If

        If e.CommandName = "Energetico" Then
            LimpiarEnergetico()
            pnlEnergetico.Visible = True
            hdnIdMaquina.Value = e.CommandArgument
            BindGridEnergetico()
        End If

        If e.CommandName = "Eliminar" Then
            Dim objMaquina As New ALVI_LOGIC.Maestros.Produccion.Maquina
            Dim strParametros As String = e.CommandArgument.ToString
            objMaquina.IdMaquina = strParametros

            If objMaquina.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub
    Private Sub LimpiarEnergetico()
        BindEnergetico()
        BindUnidadMedida()
        txtConsumo.Text = 0

    End Sub

    Private Sub BindEnergetico()
        Dim objEnergetico As New ALVI_LOGIC.Configuracion.Energetico
        objEnergetico.Listar()
        ddlEnergetico.Items.Clear()
        ddlEnergetico.DataSource = objEnergetico.Datos
        ddlEnergetico.DataTextField = "var_Descripcion"
        ddlEnergetico.DataValueField = "var_IdEnergetico"
        ddlEnergetico.DataBind()
        ddlEnergetico.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlEnergetico.SelectedIndex = 0

    End Sub

    Private Sub BindUnidadMedida()
        Dim objUM As New ALVI_LOGIC.Configuracion.UnidadMedida
        objUM.Listar()
        ddlUMConsumo.Items.Clear()
        ddlUMConsumo.DataSource = objUM.Datos
        ddlUMConsumo.DataTextField = "var_Descripcion"
        ddlUMConsumo.DataValueField = "var_IdUnidadMedida"
        ddlUMConsumo.DataBind()

        ddlUnidadVolumen.Items.Clear()
        ddlUnidadVolumen.DataSource = objUM.Datos
        ddlUnidadVolumen.DataTextField = "var_Descripcion"
        ddlUnidadVolumen.DataValueField = "var_IdUnidadMedida"
        ddlUnidadVolumen.DataBind()

        ddlUnidadVelocidad.Items.Clear()
        ddlUnidadVelocidad.DataSource = objUM.Datos
        ddlUnidadVelocidad.DataTextField = "var_Descripcion"
        ddlUnidadVelocidad.DataValueField = "var_IdUnidadMedida"
        ddlUnidadVelocidad.DataBind()

        ddlUnidadPeso.Items.Clear()
        ddlUnidadPeso.DataSource = objUM.Datos
        ddlUnidadPeso.DataTextField = "var_Descripcion"
        ddlUnidadPeso.DataValueField = "var_IdUnidadMedida"
        ddlUnidadPeso.DataBind()

        ddlUMConsumo.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlUMConsumo.SelectedIndex = 0

        ddlUnidadVolumen.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlUnidadVolumen.SelectedIndex = 3

        ddlUnidadVelocidad.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlUnidadVelocidad.SelectedIndex = 6

        ddlUnidadPeso.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlUnidadPeso.SelectedIndex = 1
    End Sub


    Protected Sub btnSalEnergetico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSalEnergetico.Click
        LimpiarEnergetico()
        pnlEnergetico.Visible = False
        hdnIdMaquina.Value = ""
    End Sub

    Private Sub BindGridEnergetico()
        Dim objEnergetico As New ALVI_LOGIC.Maestros.Produccion.MaquinaEnergetico
        objEnergetico.IdEnergetico = ""
        objEnergetico.IdMaquina = hdnIdMaquina.Value
        objEnergetico.Listar()
        grdEnergetico.DataSource = objEnergetico.Datos
        grdEnergetico.DataBind()

    End Sub

    Protected Sub btnRegEnergetico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegEnergetico.Click
        Dim objEnergetico As New ALVI_LOGIC.Maestros.Produccion.MaquinaEnergetico
        objEnergetico.ConsumoStd = txtConsumo.Text
        objEnergetico.IdEnergetico = ddlEnergetico.SelectedValue
        objEnergetico.IdMaquina = hdnIdMaquina.Value
        objEnergetico.IdUnidadMedida = ddlUMConsumo.SelectedValue
        objEnergetico.Usuario = Session("Usuario")
        objEnergetico.Registrar()
        BindGridEnergetico()
    End Sub

    Protected Sub grdEnergetico_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdEnergetico.RowCommand
        If e.CommandName = "Eliminar" Then
            Dim objEnergetico As New ALVI_LOGIC.Maestros.Produccion.MaquinaEnergetico

            objEnergetico.IdMaquina = hdnIdMaquina.Value
            objEnergetico.IdEnergetico = e.CommandArgument
            objEnergetico.Eliminar()
            BindGridEnergetico()

        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGrid()
    End Sub
End Class
