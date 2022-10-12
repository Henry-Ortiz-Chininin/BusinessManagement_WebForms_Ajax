
Partial Class Reportes_FGCREGA
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindMaquina(ddlMaquina)
            btnFechaFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaFinal.ClientID & ", 'dd/mm/yyyy');")
            btnFechaInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaInicio.ClientID & ", 'dd/mm/yyyy');")
        End If
    End Sub
    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGenerar.Click
        Generar()
    End Sub
    Private Sub Generar()
        Dim objResultado As New ALVI_LOGIC.Proceso.Produccion.ParosDeProduccion.ReporteDeParo

        objResultado.Obtener_ParoProduccion(txtFechaInicio.Text, txtFechaFinal.Text, ddlMaquina.SelectedValue)
        grdDatos.DataSource = objResultado.Datos
        grdDatos.DataBind()

    End Sub
    Private Sub BindMaquina(ByRef ddlMaquinaria As DropDownList)
        Dim objMaquinaria As New ALVI_LOGIC.Maestros.Produccion.Maquina
        ddlMaquinaria.Items.Clear()
        If objMaquinaria.Listar() = True Then
            ddlMaquinaria.DataValueField = "var_IdMaquina"
            ddlMaquinaria.DataTextField = "var_Descripcion"
            ddlMaquinaria.DataSource = objMaquinaria.Datos
            ddlMaquinaria.DataBind()
        End If
        ddlMaquinaria.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlMaquinaria.SelectedIndex = 0
    End Sub
    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        Generar()
    End Sub

    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
    End Sub
End Class
