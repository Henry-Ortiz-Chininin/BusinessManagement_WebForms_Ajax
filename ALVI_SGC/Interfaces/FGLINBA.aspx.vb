Imports System.Data
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Class Interfaces_FGLINBA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlDocumento.Visible = False
            btnFechaEmisionInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionInicio.ClientID & ", 'dd/mm/yyyy');")
            txtFechaEmisionFinal.Text = Format(Now.Date, "dd/MM/yyyy")
            txtFechaEmisionInicio.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFechaEmisionFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionFinal.ClientID & ", 'dd/mm/yyyy');")
            'btnBuscar.Attributes.Add("onclick", "javascript:return Buscar('" & hdnIdCotizacion.ClientID & "');")
            'btnImprimir.Attributes.Add("onclick", "javascript:return Buscar('" & hdnIdCotizacion.ClientID & "');")
            If Request("var_IdOrdenCompra") <> "" Then
                Dim objSeguridad As New ALVI_Security.General
                hdnIdCotizacion.Value = objSeguridad.Decrypta(Request("var_IdCotizacion"))
                Buscar()
            End If

            BuscarSolicitudes()

            'BindGrid()

        End If

    End Sub


    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        pnlDocumento.Visible = True
        datable()
        LimpiarFormulario()
        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
        grdDatosCOTIZACIONES.DataSource = dtbDatos
        grdDatosCOTIZACIONES.DataBind()
        btnActualizar.Visible = False


    End Sub

    Public Sub LimpiarFormulario()
        ctlProveedor_Buscar1.Limpia()
        txtRequisicion1.Text = ""
        txtFechaEmisionInicio1.Text = ""
        txtObservacion.Text = ""
        txtArchivo.Text = ""

    End Sub
    Protected Sub btnCerrarDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrarDocumento.Click
        CerrarCotizacion()

    End Sub


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        'buscar2()
        BuscarSolicitudes()
    End Sub

    Private Sub CerrarCotizacion()
        pnlDocumento.Visible = False

    End Sub

    Protected Sub txtRequisicion1_textchanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRequisicion1.TextChanged
        Buscar()

    End Sub

    Private Sub BuscarSolicitudes()
        Dim objSolicitud As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Cotizacion
        objSolicitud.IdRequisicion = txtRequisicion.Text
        objSolicitud.BuscarRequisicion(txtFechaEmisionInicio.Text, txtFechaEmisionFinal.Text, ctlProveedor_Buscar2.IdProveedor)

        grdDatos.DataSource = objSolicitud.Datos
        grdDatos.DataBind()
    End Sub

    Private Sub datable()

        Dim dtbDatos As New DataTable

        dtbDatos.Columns.Add("var_IdDetalle", GetType(String))
        dtbDatos.Columns.Add("var_IdArticuloReferencia", GetType(String))
        dtbDatos.Columns.Add("Articulo", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("UNIDADMEDIDA", GetType(String))
        dtbDatos.Columns.Add("int_Cantidad", GetType(Integer))
        dtbDatos.Columns.Add("dec_PrecioRef", GetType(Double))
        dtbDatos.Columns.Add("var_ObservacionArticulo", GetType(String))


        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdArticuloReferencia")
        dtbDatos.PrimaryKey = pkDetalle


        Session("datos") = dtbDatos



    End Sub


    Private Sub BindGrid()
        datable()

        Dim objCotizacion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Cotizacion
        objCotizacion.IdRequisicion = txtRequisicion1.Text


        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
        If objCotizacion.Listar Then

            Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo


            For Each dtrItem As Data.DataRow In objCotizacion.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow

                dtrNuevo("var_IdDetalle") = dtrItem("var_IdDetalle")
                dtrNuevo("var_IdArticuloReferencia") = dtrItem("var_IdArticuloReferencia")
                objArticulo.IdArticulo = dtrItem("var_IdArticuloReferencia")
                objArticulo.Obtener1()
                dtrNuevo("Articulo") = objArticulo.Descripcion
                dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.Obtener1()
                dtrNuevo("UNIDADMEDIDA") = objUnidadMedida.Descripcion
                dtrNuevo("int_Cantidad") = dtrItem("int_Cantidad")

                dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbDatos.AcceptChanges()


            Next
          
        End If

        Session("datos") = dtbDatos
        grdDatosCOTIZACIONES.DataSource = dtbDatos
        grdDatosCOTIZACIONES.DataBind()

    End Sub


    Private Sub Buscar()
        Dim objRequisicion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Requisicion
        hdnIdCorrelativo.Value = txtRequisicion1.Text



        Dim dt As New DataTable

        dt = objRequisicion.Buscar1(hdnIdCorrelativo.Value)

        txtFechaEmisionInicio1.Text = dt.Rows(0)("dtm_FechaEmision").ToString()

        
        BindGrid()




    End Sub

    Private Sub Buscar1()
        Dim objCotizacion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Cotizacion
        objCotizacion.Buscar(txtRequisicion.Text, _
                             txtFechaEmisionInicio.Text, _
                             txtFechaEmisionFinal.Text, _
                             ctlProveedor_Buscar2.IdProveedor, _
                             hdnIdCotizacion.Value
                             )
        grdDatos.DataSource = objCotizacion.Datos
        grdDatos.DataBind()

        objCotizacion.IdRequisicion = txtRequisicion.Text
        objCotizacion.FechaEmision = txtFechaEmisionInicio.Text
        objCotizacion.Proveedor = ctlProveedor_Buscar2.IdProveedor

       

    End Sub

    Private Sub buscar2()
        Dim objCotizacion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Cotizacion
        objCotizacion.IdCotizacion = hdnIdCotizacion.Value
        If objCotizacion.Obtener Then
            txtRequisicion.Text = objCotizacion.IdRequisicion
            txtFechaEmisionInicio.Text = objCotizacion.FechaEmision
            ctlProveedor_Buscar2.IdProveedor = objCotizacion.Proveedor
            ctlProveedor_Buscar2.BuscarId()
            grdDatos.DataSource = objCotizacion.Datos
            grdDatos.DataBind()



        End If



    End Sub


    Private Sub BindGrid1()
        datable()

        Dim objCotizacion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Cotizacion

        objCotizacion.IdRequisicion = hdnIdCorrelativo.Value

        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
        If objCotizacion.Listar Then

            Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo


            For Each dtrItem As Data.DataRow In objCotizacion.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow

                dtrNuevo("var_IdDetalle") = dtrItem("var_IdDetalle")
                dtrNuevo("var_IdArticuloReferencia") = dtrItem("var_IdArticuloReferencia")
                objArticulo.IdArticulo = dtrItem("var_IdArticuloReferencia")
                objArticulo.Obtener1()
                dtrNuevo("Articulo") = objArticulo.Descripcion
                dtrNuevo("var_IdUnidadMedida") = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                objUnidadMedida.Obtener1()
                dtrNuevo("UNIDADMEDIDA") = objUnidadMedida.Descripcion
                dtrNuevo("int_Cantidad") = dtrItem("int_Cantidad")

                dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
                dtbDatos.AcceptChanges()


            Next

        End If

        Session("datos") = dtbDatos
        grdDatosCOTIZACIONES.DataSource = dtbDatos
        grdDatosCOTIZACIONES.DataBind()

    End Sub


    Protected Sub btnActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnActualizar.Click
        If txtRequisicion1.Text <> "" AndAlso txtFechaEmisionInicio1.Text <> "" _
           AndAlso txtObservacion.Text <> "" AndAlso txtArchivo.Text <> "" AndAlso ctlProveedor_Buscar1.IdProveedor <> "" Then

            Dim objCotizacion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Cotizacion
            objCotizacion.IdCotizacion = hdnIdCotizacion.Value
            objCotizacion.IdRequisicion = txtRequisicion1.Text
            objCotizacion.Eliminar1()

            Registra()



        End If
    End Sub

    Private Sub Registra()


        Dim strFechaEmision() = txtFechaEmisionInicio1.Text.Split("/")

        Dim dtmFechaEmision As New Date(strFechaEmision(2), strFechaEmision(1), strFechaEmision(0))


        If dtmFechaEmision > Now.Date Then

            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('La fecha no permitida');</script>")

        End If

        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)

        For Each grdItem As GridViewRow In grdDatosCOTIZACIONES.Rows

            Dim PrecioReferencia As TextBox = CType(grdItem.FindControl("txtPreciRef"), TextBox)
            Dim Observacion As TextBox = CType(grdItem.FindControl("TxtObservación"), TextBox)

            Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow


            dtrNuevo("var_IdArticuloReferencia") = grdItem.Cells(1).Text
            dtrNuevo("Articulo") = grdItem.Cells(2).Text
            dtrNuevo("var_IdUnidadMedida") = grdItem.Cells(3).Text
            dtrNuevo("UNIDADMEDIDA") = grdItem.Cells(4).Text
            dtrNuevo("int_Cantidad") = grdItem.Cells(5).Text
            dtrNuevo("dec_PrecioRef") = PrecioReferencia.Text
            dtrNuevo("var_ObservacionArticulo") = Observacion.Text

            dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
            dtbDatos.AcceptChanges()


        Next


        If dtbDatos.Rows.Count > 0 Then
            Dim objCotizacion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Cotizacion

            objCotizacion.IdRequisicion = txtRequisicion1.Text
            objCotizacion.FechaEmision = txtFechaEmisionInicio1.Text
            objCotizacion.Observacion = txtObservacion.Text
            objCotizacion.NombrerArchivo = txtArchivo.Text
            objCotizacion.Proveedor = ctlProveedor_Buscar1.IdProveedor
            objCotizacion.Usuario = Session("Usuario")
            objCotizacion.Estado = "ACT"

            If FileUpload1.HasFile Then

                Dim str_Nombre As String = String.Format("{0:yyMMddHHmmss}", DateTime.Now)

                Dim ruta As String = Server.MapPath("./") + "../Archivos/"

                Dim str_Extension As String() = FileUpload1.FileName.Split(".")

                ruta += str_Nombre + "." + str_Extension(str_Extension.Length - 1)

                FileUpload1.SaveAs(ruta)

                objCotizacion.Archivo = str_Nombre + "." + str_Extension(str_Extension.Length - 1)

            End If


            If objCotizacion.Registrar(dtbDatos) Then
                Dim intRegistros As Int16 = 0
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Registro exitoso.');</script>")


            End If

        End If



    End Sub

    Protected Sub btnRegistraCotizacion_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistraCotizacion.Click

        If txtRequisicion1.Text <> "" AndAlso txtFechaEmisionInicio1.Text <> "" _
           AndAlso txtObservacion.Text <> "" AndAlso txtArchivo.Text <> "" AndAlso ctlProveedor_Buscar1.IdProveedor <> "" Then
            Registra()




        End If





    End Sub


    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        Dim itmFila As GridViewRow = grdDatos.Rows(e.CommandArgument)
        Dim objSeguridad As New ALVI_Security.General


        If e.CommandName = "ABRIR" Then
            Dim objRequisicion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Requisicion
            hdnIdCorrelativo.Value = itmFila.Cells(0).Text
            btnRegistraCotizacion.Visible = False
            btnActualizar.Visible = True

            BindGrid1()

            txtFechaEmisionInicio1.Text = itmFila.Cells(4).Text.ToString()
            txtRequisicion1.Text = itmFila.Cells(0).Text.ToString()
            txtObservacion.Text = itmFila.Cells(6).Text.ToString()
            txtArchivo.Text = CType(itmFila.FindControl("lnkArchivo"), HyperLink).Text

            ctlProveedor_Buscar1.IdProveedor = itmFila.Cells(5).Text.ToString()
            ctlProveedor_Buscar1.BuscarId()
            Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)

            'Dim i As Integer = -1

            'For Each grdItem As GridViewRow In grdDatosCOTIZACIONES.Rows

            '    i += 1

            '    Dim PrecioReferencia As TextBox = CType(grdItem.FindControl("txtPreciRef"), TextBox)
            '    Dim Observacion As TextBox = CType(grdItem.FindControl("TxtObservación"), TextBox)
            '    Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
            '    PrecioReferencia.Text = dt.Rows(i)("dec_PrecioRef").ToString()
            '    Observacion.Text = dt.Rows(i)("var_ObservacionArticulo").ToString()

            'Next

            pnlDocumento.Visible = True

        End If

        If e.CommandName = "Eliminar" Then

            Dim objCotizacion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Cotizacion
            objCotizacion.IdRequisicion = itmFila.Cells(0).Text
            If objCotizacion.Eliminar Then
                grdDatos.DataSource = objCotizacion.Datos
                grdDatos.DataBind()

            Else

            End If

        End If
        If e.CommandName = "Imprimir" Then
            Imprimir(itmFila.Cells(3).Text)

        End If

    End Sub


    Private Sub Imprimir(ByVal pstrIdCotizacion As String)

        hdnIdCotizacion.Value = pstrIdCotizacion

        If hdnIdCotizacion.Value <> "" Then
            Dim stringWrite1 As New System.IO.StringWriter
            Dim stringWrite2 As New System.IO.StringWriter
            Dim htmlWrite1 As New System.Web.UI.HtmlTextWriter(stringWrite1)
            Dim htmlWrite2 As New System.Web.UI.HtmlTextWriter(stringWrite2)
            Dim objCotizacion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Cotizacion
            Dim objCotizacionArticulo As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.CotizacionDetalle

            Dim tblMovimiento As New Table
            Dim tblDetalle As New Table
            Dim rowTable As TableRow
            Dim celTable As TableCell

            objCotizacion.IdCotizacion = hdnIdCotizacion.Value
            If objCotizacion.Obtener() Then
                Dim objTipoMovimiento As New ALVI_LOGIC.Maestros.Logistica.TipoMovimiento
                Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
                Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
                Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
                Dim objProveedor As New ALVI_LOGIC.Maestros.Compras.Proveedor

                'CODIGO DE INGRESO
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Cod. Ingreso" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objCotizacion.IdCotizacion : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)
                'FECHA
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Fecha" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objCotizacion.FechaEmision : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)

                'OBSERVACIONES
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Observacion" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objCotizacion.Observacion : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)

                'PROVEEDOR
                objProveedor.IdProveedor = objCotizacion.Proveedor
                objProveedor.Obtener()
                rowTable = New TableRow
                celTable = New TableCell : celTable.Font.Bold = True : celTable.Text = "Proveedor:" : rowTable.Cells.Add(celTable)
                celTable = New TableCell : celTable.Text = objProveedor.Descripcion : rowTable.Cells.Add(celTable)
                tblMovimiento.Rows.Add(rowTable)



                objCotizacionArticulo.IdCotizacion = objCotizacion.IdCotizacion
                If objCotizacionArticulo.Listar1() Then
                    Dim objUnidad As New ALVI_LOGIC.Configuracion.UnidadMedida

                    rowTable = New TableRow
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Cod. Articulo" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Descripción" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Unidad Medida" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Cantidad" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Prec. Referencia" : rowTable.Cells.Add(celTable)
                    celTable = New TableCell
                    celTable.BackColor = Drawing.Color.LightGray : celTable.BorderColor = Drawing.Color.Black : celTable.BorderWidth = New Unit(1, UnitType.Pixel)
                    celTable.Font.Bold = True : celTable.Text = "Observaciones" : rowTable.Cells.Add(celTable)

                    tblDetalle.Rows.Add(rowTable)

                    For Each dtrItem As Data.DataRow In objCotizacionArticulo.Datos.Rows
                        objArticulo.IdArticulo = dtrItem("var_IdArticuloReferencia")
                        objArticulo.Obtener()
                        objUnidad.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                        objUnidad.Obtener()


                        rowTable = New TableRow
                        celTable = New TableCell : celTable.Text = dtrItem("var_IdArticuloReferencia") : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = objArticulo.Descripcion : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = objUnidad.Descripcion : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("int_Cantidad") : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("dec_PrecioRef") : rowTable.Cells.Add(celTable)
                        celTable = New TableCell : celTable.Text = dtrItem("var_ObservacionArticulo") : rowTable.Cells.Add(celTable)

                        tblDetalle.Rows.Add(rowTable)
                    Next

                End If

                Session("Titulo") = "Cotizacion"
                tblMovimiento.RenderControl(htmlWrite1)
                Session("Impresion") = stringWrite1.ToString
                tblDetalle.RenderControl(htmlWrite2)
                Session("Impresion") = Session("Impresion") & "<br>" & stringWrite2.ToString

                Session("Datos") = ""

                ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('../Controles/frmPrint.aspx','Reporte', 'resizable=1, height=600, width=1000, top=0, left=0');</script>")
            End If
        End If

    End Sub


    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lnkArchivo As HyperLink = CType(e.Row.FindControl("lnkArchivo"), HyperLink)
            Dim drvItem As Data.DataRowView = CType(e.Row.DataItem, Data.DataRowView)

            lnkArchivo.NavigateUrl = "../Archivos/" & drvItem("var_RutaArchivo")
            lnkArchivo.Text = drvItem("var_NombreArchivo")
        End If

    End Sub
End Class
