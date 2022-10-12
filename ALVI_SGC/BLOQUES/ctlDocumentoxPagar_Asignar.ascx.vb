
Partial Class BLOQUES_ctlDocumentoxPagar_Asignar
    Inherits System.Web.UI.UserControl



    Private Sub BindTipoDocumento()
        Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
        ddlTipoDocumento.Items.Clear()
        objTipoDocumento.Clasificacion = "I"
        If objTipoDocumento.Listar() = True Then
            ddlTipoDocumento.DataValueField = "chr_IdTipoDocumento"
            ddlTipoDocumento.DataTextField = "var_Descripcion"
            ddlTipoDocumento.DataSource = objTipoDocumento.Datos
            ddlTipoDocumento.DataBind()
        End If
        ddlTipoDocumento.Items.Insert(0, New ListItem("Seleccionar", ""))
        ddlTipoDocumento.SelectedIndex = 0
    End Sub
    Public Sub Limpiar()
        BindTipoDocumento()
        ddlTipoDocumento.SelectedIndex = 0
        txtNumeroDocumento.Text = ""
        txtImporte.Text = "0"
        CrearEsquema()

    End Sub

    Private Sub CrearEsquema()
        Dim dtbDocumento As New Data.DataTable
        dtbDocumento.Columns.Add("var_IdProveedor", GetType(String))
        dtbDocumento.Columns.Add("var_RazonSocial", GetType(String))
        dtbDocumento.Columns.Add("chr_IdTipoDocumento", GetType(String))
        dtbDocumento.Columns.Add("var_TipoDocumento", GetType(String))
        dtbDocumento.Columns.Add("var_NumeroDocumento", GetType(String))
        dtbDocumento.Columns.Add("var_Fecha", GetType(String))
        dtbDocumento.Columns.Add("num_Importe", GetType(Double))

        Dim pkDocumento(3) As Data.DataColumn
        pkDocumento(0) = dtbDocumento.Columns("var_IdProveedor")
        pkDocumento(1) = dtbDocumento.Columns("chr_IdTipoDocumento")
        pkDocumento(2) = dtbDocumento.Columns("var_NumeroDocumento")

        dtbDocumento.PrimaryKey = pkDocumento
        Session("dtbDocumento") = dtbDocumento
    End Sub
    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If ddlTipoDocumento.SelectedValue <> "" AndAlso txtNumeroDocumento.Text <> "" Then
            RegistroDocumento()
            Limpiar()
        Else
            Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Faltan datos.');</script>")
        End If
    End Sub

    Private Sub RegistroDocumento()
        Dim dtbDocumento As Data.DataTable = CType(Session("dtbDocumento"), Data.DataTable)

        Dim dtrNuevo As Data.DataRow = dtbDocumento.NewRow

        dtrNuevo("var_IdProveedor") = ctlProveedor.IdProveedor
        dtrNuevo("var_RazonSocial") = ctlProveedor.RazonSocial
        dtrNuevo("chr_IdTipoDocumento") = ddlTipoDocumento.SelectedItem
        dtrNuevo("var_TipoDocumento") = txtNumeroDocumento.Text
        dtrNuevo("var_NumeroDocumento") = txtNumeroDocumento.Text
        dtrNuevo("var_Fecha") = txtFecha.Text
        dtrNuevo("num_Importe") = txtImporte.Text
        dtbDocumento.LoadDataRow(dtrNuevo.ItemArray, True)
        dtbDocumento.AcceptChanges()

        Session("dtbDocumento") = dtbDocumento
        grdDocumento.DataSource = dtbDocumento
        grdDocumento.DataBind()

        ctlProveedor.Limpia()
        txtNumeroDocumento.Text = ""
        txtFecha.Text = ""
        txtImporte.Text = 0
        ddlTipoDocumento.SelectedValue = ""

    End Sub

    Protected Sub grdProveedor_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdDocumento.RowDeleting
        Dim dtbDocumento As Data.DataTable = CType(Session("dtbDocumento"), Data.DataTable)
        dtbDocumento.Rows.RemoveAt(e.RowIndex)
        dtbDocumento.AcceptChanges()
        Session("dtbDocumento") = dtbDocumento
        grdDocumento.DataSource = dtbDocumento
        grdDocumento.DataBind()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Limpiar()
            btnFecha.Attributes.Add("onclick", "popUpCalendar(this, " & txtFecha.ClientID & ", 'dd/mm/yyyy');")

        End If
    End Sub
End Class
