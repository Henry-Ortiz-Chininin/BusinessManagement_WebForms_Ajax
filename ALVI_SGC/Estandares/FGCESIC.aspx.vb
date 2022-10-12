
Partial Class Estandares_FGCESIC
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtFechaInicio.Text = Format(Now.Date.AddDays(-7), "dd/MM/yyyy")
            txtFechaFinal.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFechaInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaInicio.ClientID & ", 'dd/mm/yyyy');")
            btnFechaFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaFinal.ClientID & ", 'dd/mm/yyyy');")
            pnlFormulario.Visible = False
            BindGrid()
        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        
        txtCodigo.ReadOnly = False
        txtCodigo.MaxLength = 14
        pnlFormulario.Visible = True

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid()
    End Sub

    Private Sub LimpiarFormulario()
        txtCodigo.Text = ""
        txtCompra.Text = 0
        txtVenta.Text = 0
        txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")
        btnFecha.Attributes.Add("onclick", "popUpCalendar(this, " & txtFecha.ClientID & ", 'dd/mm/yyyy');")
        'txtDescripcion.Text = ""
    End Sub
    Private Sub BindGrid()
        Dim objTipoCambio As New ALVI_LOGIC.Maestros.Administracion.TipoCambio

        objTipoCambio.Listar(txtFechaInicio.Text, txtFechaFinal.Text)
        Session("dtbDatos") = objTipoCambio.Datos
        grdDatos.DataSource = objTipoCambio.Datos
        grdDatos.DataBind()
    End Sub


    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Dim objTipoCambio As New ALVI_LOGIC.Maestros.Administracion.TipoCambio
        If txtCodigo.Text = "" Then
            Dim strFecha() As String = txtFecha.Text.Split("/")
            txtCodigo.Text = strFecha(2) & strFecha(1) & strFecha(0)
        End If
        objTipoCambio.IdTipoCambio = txtCodigo.Text
        objTipoCambio.Fecha = txtFecha.Text
        objTipoCambio.Compra = txtCompra.Text
        objTipoCambio.Venta = txtVenta.Text
        objTipoCambio.Usuario = Session("Usuario")
        If objTipoCambio.Registrar = True Then
            lblMensaje.Text = "Registro exitoso"
            LimpiarFormulario()
            grdDatos.EditIndex = -1
            BindGrid()
        End If
        'Else
        'lblMensaje.Text = "Registro fallido"
        'End If
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
            grdDatos.SelectedIndex = e.CommandArgument
            Dim objTipoCambio As New ALVI_LOGIC.Maestros.Administracion.TipoCambio
            Dim idTipoCambio As String = grdDatos.SelectedRow.Cells(0).Text
            objTipoCambio.IdTipoCambio = idTipoCambio
            If objTipoCambio.Obtener = True Then
                txtCodigo.Text = objTipoCambio.IdTipoCambio
                txtCompra.Text = objTipoCambio.Compra
                txtFecha.Text = grdDatos.SelectedRow.Cells(1).Text
                txtVenta.Text = objTipoCambio.Venta
                pnlFormulario.Visible = True
                txtCodigo.ReadOnly = True
            End If
        End If
        If e.CommandName = "Eliminar" Then
            Dim objTipoCambio As New ALVI_LOGIC.Maestros.Administracion.TipoCambio
            Dim IdTipoCambio As String = e.CommandArgument.ToString
            objTipoCambio.IdTipoCambio = IdTipoCambio
            If objTipoCambio.Eliminar = True Then
                BindGrid()
            End If
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGrid()
    End Sub

End Class
