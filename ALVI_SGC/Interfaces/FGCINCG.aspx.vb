
Partial Class Interfaces_FGCINCG
    Inherits System.Web.UI.Page

    Private Sub BindTipoDocumento()
        Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
        ddlTipoDocumento.Items.Clear()
        objTipoDocumento.Clasificacion = "S"
        If objTipoDocumento.Listar() = True Then
            ddlTipoDocumento.DataValueField = "chr_IdTipoDocumento"
            ddlTipoDocumento.DataTextField = "var_Descripcion"
            ddlTipoDocumento.DataSource = objTipoDocumento.Datos
            ddlTipoDocumento.DataBind()
        End If
        ddlTipoDocumento.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlTipoDocumento.SelectedIndex = 0
    End Sub

    Private Sub BindTipoMovimiento()
        Dim objTipoMovimiento As New ALVI_LOGIC.Maestros.Logistica.TipoMovimiento
        ddlTipoMovimiento.Items.Clear()
        objTipoMovimiento.Clasificacion = "S"
        If objTipoMovimiento.Listar() = True Then
            ddlTipoMovimiento.DataValueField = "var_IdTipoMovimiento"
            ddlTipoMovimiento.DataTextField = "var_Descripcion"
            ddlTipoMovimiento.DataSource = objTipoMovimiento.Datos
            ddlTipoMovimiento.DataBind()
        End If
        ddlTipoMovimiento.Items.Insert(0, New ListItem("Seleccionar", "S"))
        ddlTipoMovimiento.SelectedIndex = 0
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindTipoDocumento()
            BindTipoMovimiento()
            txtFechaInicio.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFechaInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaInicio.ClientID & ", 'dd/mm/yyyy');")
            txtFechaFinal.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFechaFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaFinal.ClientID & ", 'dd/mm/yyyy');")

        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        If txtFechaInicio.Text <> "" AndAlso txtFechaFinal.Text <> "" Then
            BindGrid()
        Else
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Ingrese fecha de inicio y de fin'); </script>")
        End If
    End Sub

    Private Sub BindGrid()
        Dim objMovimientos As New ALVI_LOGIC.Proceso.Logistica.Kardex.Movimiento
        objMovimientos.IdOrdenProduccion = txtOPReferencia.Text
        objMovimientos.IdTipoDocumento = ddlTipoDocumento.SelectedValue
        objMovimientos.IdTipoMovimiento = ddlTipoMovimiento.SelectedValue
        objMovimientos.NumeroDocumento = txtNumeroDocumento.Text
        objMovimientos.Busqueda(txtFechaInicio.Text, txtFechaFinal.Text)
        grdDatos.DataSource = New Data.DataView(objMovimientos.Datos, "chr_Clase='S'", "chr_IdKardex", Data.DataViewRowState.OriginalRows)
        grdDatos.DataBind()
    End Sub

    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            Dim strParametros As String = e.CommandArgument.ToString
            Dim objSecurity As New ALVI_Security.General
            Dim strURL As String = "FGCINCE.ASPX"
            strURL = strURL & "?IdSeccion=" & Master.IdSeccion
            strURL = strURL & "&IdMenu=" & Master.IdMenu
            strURL = strURL & "&IdSubMenu=" & Master.IdSubMenu
            strURL = strURL & "&IdKardex=" & objSecurity.Encrypta(strParametros)

            Response.Redirect(strURL)


        End If
    End Sub
End Class
