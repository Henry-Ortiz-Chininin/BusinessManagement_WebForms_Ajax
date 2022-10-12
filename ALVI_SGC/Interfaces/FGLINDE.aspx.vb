
Partial Class Interfaces_FGLINDE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            btnEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtEmision.ClientID & ", 'dd/mm/yyyy');")

            Dim objSeguridad As New ALVI_Security.General
            If objSeguridad.Decrypta(Request("AC")) = "SCO" Then
                BindGrid()
            End If
        End If
    End Sub

    Private Sub BindGrid()
        Dim dtbDatos As Data.DataTable = CType(Session("dtbDatos"), Data.DataTable)
        grdDatos.DataSource = dtbDatos
        grdDatos.DataBind()

    End Sub

    Private Sub Registrar()
        Dim strFechaEmision() = txtEmision.Text.Split("/")
        Dim dtmFechaEmision As New Date(strFechaEmision(2), strFechaEmision(1), strFechaEmision(0))

        If dtmFechaEmision > Now.Date Then
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('La fecha no permitida');</script>")
        End If

        Dim dtbDatos As New Data.DataTable

        dtbDatos.Columns.Add("var_IdRequisicion", GetType(String))
        dtbDatos.Columns.Add("var_IdValeAlmacen", GetType(String))
        dtbDatos.Columns.Add("var_IdDetalle", GetType(String))
        dtbDatos.Columns.Add("var_IdArticuloReferencia", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("int_Cantidad", GetType(Integer))
        dtbDatos.Columns.Add("dec_PrecioRef", GetType(Double))
        dtbDatos.Columns.Add("var_ObservacionArticulo", GetType(String))


        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdArticuloReferencia")
        dtbDatos.PrimaryKey = pkDetalle

        For Each grdItem As GridViewRow In grdDatos.Rows

            Dim txtPrecio As TextBox = CType(grdItem.FindControl("txtPrecio"), TextBox)
            Dim txtObservacion As TextBox = CType(grdItem.FindControl("TxtObservacion"), TextBox)

            Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow


            dtrNuevo("var_IdRequisicion") = grdItem.Cells(0).Text
            dtrNuevo("var_IdValeAlmacen") = grdItem.Cells(1).Text
            dtrNuevo("var_IdDetalle") = grdItem.Cells(2).Text
            dtrNuevo("var_IdArticuloReferencia") = grdItem.Cells(3).Text
            dtrNuevo("var_IdUnidadMedida") = grdItem.Cells(5).Text
            dtrNuevo("int_Cantidad") = grdItem.Cells(7).Text
            dtrNuevo("dec_PrecioRef") = txtPrecio.Text
            dtrNuevo("var_ObservacionArticulo") = txtObservacion.Text

            dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
            dtbDatos.AcceptChanges()
        Next


        If dtbDatos.Rows.Count > 0 Then
            Dim objCotizacion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Cotizacion

            objCotizacion.IdRequisicion = txtRequisicion.Text
            objCotizacion.FechaEmision = txtEmision.Text
            objCotizacion.Observacion = txtObservacion.Text
            objCotizacion.NombrerArchivo = txtArchivo.Text
            objCotizacion.Archivo = ""
            objCotizacion.Proveedor = ctlProveedor.IdProveedor
            objCotizacion.Usuario = Session("Usuario")
            objCotizacion.Estado = "ACT"

            If FileUpload1.HasFile Then
                Dim strNombre As String = String.Format("{0:yyMMddHHmmss}", DateTime.Now)
                Dim strRuta As String = Server.MapPath("./") + "../Archivos/"
                Dim strExtension As String() = FileUpload1.FileName.Split(".")
                strRuta += strNombre + "." + strExtension(strExtension.Length - 1)
                FileUpload1.SaveAs(strRuta)
                objCotizacion.Archivo = strNombre + "." + strExtension(strExtension.Length - 1)
            End If

            If objCotizacion.Registrar(dtbDatos) Then
                Dim intRegistros As Int16 = 0
                txtRequisicion.Text = objCotizacion.IdCotizacion
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Registro exitoso. Cotización: " & txtRequisicion.Text & "');</script>")
            End If
        End If

    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        If txtEmision.Text <> "" AndAlso ctlProveedor.IdProveedor <> "" Then
            Registrar()
        End If
    End Sub
End Class
