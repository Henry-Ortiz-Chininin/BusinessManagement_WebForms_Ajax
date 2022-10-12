
Partial Class Estandares_FGCESMA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlFormulario.Visible = False
            txtCodigo.ReadOnly = True
            btnFechaInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaInicio.ClientID & ", 'dd/mm/yyyy');")
            btnFechaFin.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaFin.ClientID & ", 'dd/mm/yyyy');")
            btnFechaCaducidad.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaCaducidad.ClientID & ", 'dd/mm/yyyy');")
            BindGrid()
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        lblMensaje.Text = ""
        txtCodigo.ReadOnly = True
        pnlFormulario.Visible = True
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid()
    End Sub

    Private Sub LimpiarFormulario()
        txtCodigo.Text = ""
        txtImpuesto1.Text = "0"
        txtImpuesto2.Text = "0"
        txtImpuesto3.Text = "0"
        txtdetraccion.Text = "0"
        txtPercepcion.Text = "0"
        txtRetencion.Text = "0"
        ddlEstado.SelectedIndex = 0
    End Sub

    Private Sub BindGrid()
        Dim objProceso As New ALVI_LOGIC.Maestros.Produccion.Impuesto
        Dim dtbDatos As New Data.DataTable
        objProceso.FechaFin = txtFechaFin.Text
        objProceso.FechaInicio = txtFechaInicio.Text
        objProceso.IdTipo = ddlTipo.SelectedValue
        dtbDatos.Columns.Add("int_Secuencia", GetType(String))
        dtbDatos.Columns.Add("num_Impuesto1", GetType(String))
        dtbDatos.Columns.Add("num_Impuesto2", GetType(String))
        dtbDatos.Columns.Add("num_Impuesto3", GetType(String))
        dtbDatos.Columns.Add("num_Percepcion", GetType(String))
        dtbDatos.Columns.Add("num_Retencion", GetType(String))
        dtbDatos.Columns.Add("num_Detraccion", GetType(String))
        dtbDatos.Columns.Add("chr_Estado", GetType(String))
        dtbDatos.Columns.Add("dtm_FechaVencimiento", GetType(Date))
        If objProceso.Buscar() = True Then
            For Each dtrItem As Data.DataRow In objProceso.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                dtrNuevo("int_Secuencia") = dtrItem("int_Secuencia")
                dtrNuevo("num_Impuesto1") = dtrItem("num_Impuesto1")
                dtrNuevo("num_Impuesto2") = dtrItem("num_Impuesto2")
                dtrNuevo("num_Impuesto3") = dtrItem("num_Impuesto3")
                dtrNuevo("num_Percepcion") = dtrItem("num_Percepcion")
                dtrNuevo("num_Retencion") = dtrItem("num_Retencion")
                dtrNuevo("num_Detraccion") = dtrItem("num_Detraccion")
                dtrNuevo("chr_Estado") = dtrItem("chr_Estado")
                dtrNuevo("dtm_FechaVencimiento") = dtrItem("dtm_FechaVencimiento")
                dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                dtbDatos.AcceptChanges()
            Next
        End If
        Session("dtbDatos") = dtbDatos
        grdDatos.DataSource = Session("dtbDatos")
        grdDatos.DataBind()
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Dim objImpuesto As New ALVI_LOGIC.Maestros.Produccion.Impuesto
        If txtFechaCaducidad.Text <> "" AndAlso txtImpuesto1.Text <> "" AndAlso txtImpuesto2.Text <> "" AndAlso txtImpuesto3.Text <> "" _
        AndAlso txtdetraccion.Text <> "" AndAlso txtPercepcion.Text <> "" AndAlso txtRetencion.Text <> "" Then
            objImpuesto.Codigo = txtCodigo.Text
            objImpuesto.Impuesto1 = txtImpuesto1.Text
            objImpuesto.Impuesto2 = txtImpuesto2.Text
            objImpuesto.Impuesto3 = txtImpuesto3.Text
            objImpuesto.Usuario = Session("Usuario")
            objImpuesto.Detraccion = txtdetraccion.Text
            objImpuesto.Percepcion = txtPercepcion.Text
            objImpuesto.Retencion = txtRetencion.Text
            objImpuesto.Estado = ddlEstado.SelectedValue
            objImpuesto.FechaCaducidad = txtFechaCaducidad.Text
            If objImpuesto.Registrar = True Then
                lblMensaje.Text = "Registro exitoso"
                LimpiarFormulario()
                grdDatos.EditIndex = -1
                BindGrid()
            Else
                lblMensaje.Text = "Datos Incorrectos"
            End If

        Else
            lblMensaje.Text = "Faltan Datos"
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
            Dim objImpuesto As New ALVI_LOGIC.Maestros.Produccion.Impuesto
            objImpuesto.Codigo = e.CommandArgument
            objImpuesto.Obtener()
            txtCodigo.Text = objImpuesto.Codigo
            txtImpuesto1.Text = objImpuesto.Impuesto1
            txtImpuesto2.Text = objImpuesto.Impuesto2
            txtImpuesto3.Text = objImpuesto.Impuesto3
            txtdetraccion.Text = objImpuesto.Detraccion
            txtPercepcion.Text = objImpuesto.Percepcion
            txtRetencion.Text = objImpuesto.Retencion
            ddlEstado.SelectedValue = objImpuesto.Estado
            txtFechaCaducidad.Text = objImpuesto.FechaCaducidad
            pnlFormulario.Visible = True

        End If
        If e.CommandName = "Eliminar" Then
            Dim objImpuesto As New ALVI_LOGIC.Maestros.Produccion.Impuesto
            Dim strParametros As String = e.CommandArgument.ToString
            objImpuesto.Codigo = strParametros
            If objImpuesto.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGrid()
    End Sub
End Class