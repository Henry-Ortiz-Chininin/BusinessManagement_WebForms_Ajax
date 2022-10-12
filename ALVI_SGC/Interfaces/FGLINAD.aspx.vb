
Partial Class Interfaces_FGLINAD
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindTipoMovimiento()
            BindTipoDocumento()
            txtFechaEmisionFinal.Text = Format(Now.Date, "dd/MM/yyyy")
            txtFechaEmisionInicio.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionInicio.ClientID & ", 'dd/mm/yyyy');")
            btnFechaEmisionFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionFinal.ClientID & ", 'dd/mm/yyyy');")
            BindGrid()

        End If
    End Sub


    Private Sub BindTipoMovimiento()
        Dim objTipoMovimiento As New ALVI_LOGIC.Maestros.Logistica.TipoMovimiento
        ddlOperacion.Items.Clear()
        objTipoMovimiento.Clasificacion = "S"
        If objTipoMovimiento.Listar() = True Then
            ddlOperacion.DataValueField = "var_IdTipoMovimiento"
            ddlOperacion.DataTextField = "var_Descripcion"
            ddlOperacion.DataSource = objTipoMovimiento.Datos
            ddlOperacion.DataBind()
        End If
        ddlOperacion.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlOperacion.SelectedIndex = 0
    End Sub


    Private Sub BindTipoDocumento()
        Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
        ddlTipo.Items.Clear()
        objTipoDocumento.Clasificacion = "S"
        If objTipoDocumento.Listar() = True Then
            ddlTipo.DataValueField = "chr_IdTipoDocumento"
            ddlTipo.DataTextField = "var_Descripcion"
            ddlTipo.DataSource = objTipoDocumento.Datos
            ddlTipo.DataBind()
        End If
        ddlTipo.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlTipo.SelectedIndex = 0
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        If txtFechaEmisionInicio.Text <> "" AndAlso txtFechaEmisionFinal.Text <> "" Then
            BindGrid()
        Else
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Ingrese fecha de inicio y de fin'); </script>")
        End If
    End Sub

    Private Sub BindGrid()
        Dim objvale As New ALVI_LOGIC.Maestros.Logistica.Vale
        objvale.Buscar(txtCodigo.Text, _
                       ctlSolicitante_Buscar1.IdSolicitante, _
                       txtFechaEmisionInicio.Text, _
                       txtFechaEmisionFinal.Text, _
                        ctlElementoReferencial_Buscar1.idArticulo, _
                        ctlCentroCosto_Buscar1.IdCentroCosto, _
                        txtNumero.Text, _
                        ddlOperacion.SelectedValue, _
                        ddlTipo.SelectedValue)
        grdDatos.DataSource = objvale.Datos
        grdDatos.DataBind()


    End Sub


    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        Dim itmFila As GridViewRow = grdDatos.Rows(e.CommandArgument)
        Dim objSeguridad As New ALVI_Security.General

        If e.CommandName = "GENERAR" Then
            Response.Redirect("FGCINMA.aspx?IdVale=" & objSeguridad.Encrypta(itmFila.Cells(0).Text), True)

        End If
        If e.CommandName = "ABRIR" Then
            Response.Redirect("FGLINAC.aspx?IdVale=" & objSeguridad.Encrypta(itmFila.Cells(0).Text), True)
        End If

        If e.CommandName = "ELIMINAR" Then
            Dim objVale As New ALVI_LOGIC.Maestros.Logistica.Vale
            objVale.IdValeAlemacen = itmFila.Cells(0).Text
            objVale.Estado = "INA"
            If objVale.Actualizar Then

            Else

            End If

        End If


    End Sub


    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar = CType(e.Row.FindControl("btnEliminar"), ImageButton)
            Dim strIdValeAlmacen As String = e.Row.Cells(0).Text
            btnEliminar.Attributes.Add("onclick", "return confirm('El vale " & strIdValeAlmacen & " sera eliminada');")
        End If
    End Sub


    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        Response.Redirect("FGLINAC.aspx")
    End Sub
End Class
