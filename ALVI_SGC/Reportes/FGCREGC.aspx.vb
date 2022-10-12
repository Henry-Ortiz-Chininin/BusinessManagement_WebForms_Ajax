
Partial Class Reportes_FGCREGC
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindMotivo(ddlMotivo)
            btnFechaFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaFinal.ClientID & ", 'dd/mm/yyyy');")
            'txtFechaFinal.Text = Format(Now, "dd/MM/yyyy")

            btnFechaInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaInicio.ClientID & ", 'dd/mm/yyyy');")
            'txtFechaInicio.Text = Format(DateAdd(DateInterval.Month, -1, Now), "dd/MM/yyyy")
        End If
    End Sub
    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGenerar.Click
        Generar()
    End Sub
    Private Sub Generar()
        Dim objResultado As New ALVI_LOGIC.Proceso.Produccion.ReprocesosDevoluciones.ReporteReprocesoDevoluciones
        Dim Tipo As String = "D"
        objResultado.Obtener_ProcesosDevoluciones(txtFechaInicio.Text, txtFechaFinal.Text, Tipo, ddlMotivo.SelectedValue)
        grdDatos.DataSource = objResultado.Datos
        grdDatos.DataBind()

    End Sub
    Private Sub BindMotivo(ByRef ddlMotivo As DropDownList)
        Dim objDevoluciones As New ALVI_LOGIC.Maestros.Produccion.TipoProceso.Valor
        ddlMotivo.Items.Clear()
        If objDevoluciones.Listar() = True Then
            ddlMotivo.DataValueField = "chr_IdAtributo"
            ddlMotivo.DataTextField = "var_Descripcion"
            ddlMotivo.DataSource = objDevoluciones.Datos
            ddlMotivo.DataBind()
        End If
        ddlMotivo.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlMotivo.SelectedIndex = 0
    End Sub
    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        Generar()
    End Sub

    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
    End Sub
End Class
