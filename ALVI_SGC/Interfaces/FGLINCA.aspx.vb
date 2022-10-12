Imports System.Data
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Partial Class Interfaces_FGLINCA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlDocumento.Visible = False
            btnFechaEmisionInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionInicio.ClientID & ", 'dd/mm/yyyy');")
            txtFechaEmisionFinal.Text = Format(Now.Date, "dd/MM/yyyy")
            txtFechaEmisionInicio.Text = Format(Now.Date, "dd/MM/yyyy")
            btnFechaEmisionFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionFinal.ClientID & ", 'dd/mm/yyyy');")
            '            btnBuscar.Attributes.Add("onclick", "javascript:return Buscar('" & hdnIdSolicitud.ClientID & "');")
            'btnImprimir.Attributes.Add("onclick", "javascript:return Buscar('" & hdnIdSolicitud.ClientID & "');")

            If Request("var_IdSolicitud") <> "" Then
                Dim objSeguridad As New ALVI_Security.General
                hdnIdSolicitud.Value = objSeguridad.Decrypta(Request("var_IdSolicitud"))
                Buscar()
            End If

            'BindGrid()
            BuscarSolicitudes()
        End If

    End Sub


    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        pnlDocumento.Visible = True
        datable()
        LimpiarFormulario()
        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
        grdDatosSolicitud.DataSource = dtbDatos
        grdDatosSolicitud.DataBind()
        btnActualizar.Visible = False


    End Sub

    Public Sub LimpiarFormulario()
        ctlProveedor_Buscar1.Limpia()
        txtRequisicion1.Text = ""
        txtFechaEmisionInicio1.Text = ""
        

    End Sub

    Protected Sub btnCerrarDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrarDocumento.Click
        CerrarCotizacion()

    End Sub

    Private Sub CerrarCotizacion()
        pnlDocumento.Visible = False

    End Sub

    Private Sub BuscarSolicitudes()
        Dim objSolicitud As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Solicitud
        objSolicitud.IdRequisicion = txtRequisicion.Text
        objSolicitud.BuscarRequisicion(txtFechaEmisionInicio.Text, txtFechaEmisionFinal.Text, ctlProveedor_Buscar2.IdProveedor)

        grdDatos.DataSource = objSolicitud.Datos
        grdDatos.DataBind()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BuscarSolicitudes()
    End Sub


    Protected Sub txtRequisicion1_textchanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRequisicion1.TextChanged
        Buscar()

    End Sub

    Private Sub datable()

        Dim dtbDatos As New DataTable

        dtbDatos.Columns.Add("var_IdDetalle", GetType(String))
        dtbDatos.Columns.Add("var_IdArticuloReferencia", GetType(String))
        dtbDatos.Columns.Add("Articulo", GetType(String))
        dtbDatos.Columns.Add("var_IdUnidadMedida", GetType(String))
        dtbDatos.Columns.Add("UNIDADMEDIDA", GetType(String))
        dtbDatos.Columns.Add("int_Cantidad", GetType(Integer))



        Dim pkDetalle(1) As Data.DataColumn
        pkDetalle(0) = dtbDatos.Columns("var_IdArticuloReferencia")
        dtbDatos.PrimaryKey = pkDetalle


        Session("datos") = dtbDatos



    End Sub


    Private Sub BindGrid()
        datable()

        Dim objSolicitud As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Cotizacion
        objSolicitud.IdRequisicion = txtRequisicion1.Text


        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)
        If objSolicitud.Listar Then

            Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo


            For Each dtrItem As Data.DataRow In objSolicitud.Datos.Rows
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
        grdDatosSolicitud.DataSource = dtbDatos
        grdDatosSolicitud.DataBind()

    End Sub

    Private Sub Buscar()
        Dim objRequisicion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Requisicion
        hdnIdCorrelativo.Value = txtRequisicion1.Text



        Dim dt As New DataTable

        dt = objRequisicion.Buscar1(hdnIdCorrelativo.Value)

        txtFechaEmisionInicio1.Text = dt.Rows(0)("dtm_FechaEmision").ToString()


        BindGrid()




    End Sub

    Private Sub Registra()


        Dim strFechaEmision() = txtFechaEmisionInicio1.Text.Split("/")

        Dim dtmFechaEmision As New Date(strFechaEmision(2), strFechaEmision(1), strFechaEmision(0))


        If dtmFechaEmision > Now.Date Then

            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('La fecha no permitida');</script>")

        End If

        Dim dtbDatos As Data.DataTable = CType(Session("datos"), Data.DataTable)

        For Each grdItem As GridViewRow In grdDatosSolicitud.Rows


            Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow


            dtrNuevo("var_IdArticuloReferencia") = grdItem.Cells(1).Text
            dtrNuevo("Articulo") = grdItem.Cells(2).Text
            dtrNuevo("var_IdUnidadMedida") = grdItem.Cells(3).Text
            dtrNuevo("UNIDADMEDIDA") = grdItem.Cells(4).Text
            dtrNuevo("int_Cantidad") = grdItem.Cells(5).Text


            dtbDatos.LoadDataRow(dtrNuevo.ItemArray, True)
            dtbDatos.AcceptChanges()


        Next


        If dtbDatos.Rows.Count > 0 Then
            Dim objSolicitud As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Solicitud

            objSolicitud.IdRequisicion = txtRequisicion1.Text
            objSolicitud.FechaEmision = txtFechaEmisionInicio1.Text
            objSolicitud.Proveedor = ctlProveedor_Buscar1.IdProveedor
            objSolicitud.Usuario = Session("Usuario")
            objSolicitud.Estado = "ACT"

        


            If objSolicitud.Registrar(dtbDatos) Then
                Dim intRegistros As Int16 = 0
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Registro exitoso.');</script>")


            End If

        End If



    End Sub

    Private Sub buscar2()
        Dim objSolicitud As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Solicitud
        objSolicitud.IdSolicitud = hdnIdSolicitud.Value()
        If objSolicitud.Obtener Then
            txtRequisicion.Text = objSolicitud.IdRequisicion
            txtFechaEmisionInicio.Text = objSolicitud.FechaEmision
            ctlProveedor_Buscar2.IdProveedor = objSolicitud.Proveedor
            ctlProveedor_Buscar2.BuscarId()
            grdDatos.DataSource = objSolicitud.Datos
            grdDatos.DataBind()



        End If



    End Sub

    Protected Sub btnRegistraCotizacion_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistraCotizacion.Click

        If txtRequisicion1.Text <> "" AndAlso txtFechaEmisionInicio1.Text <> "" _
           AndAlso ctlProveedor_Buscar1.IdProveedor <> "" Then
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
       
            ctlProveedor_Buscar1.IdProveedor = itmFila.Cells(5).Text.ToString()
            ctlProveedor_Buscar1.BuscarId()
    

            pnlDocumento.Visible = True

        End If

        If e.CommandName = "Eliminar" Then

            Dim objSOLICITUD As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Solicitud
            objSOLICITUD.IdRequisicion = itmFila.Cells(0).Text
            If objSOLICITUD.Eliminar Then
                grdDatos.DataSource = objSOLICITUD.Datos
                grdDatos.DataBind()

            Else

            End If

        End If
        If e.CommandName = "Imprimir" Then
            Imprimir(itmFila.Cells(3).Text)

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
        grdDatosSolicitud.DataSource = dtbDatos
        grdDatosSolicitud.DataBind()

    End Sub


    Private Sub Imprimir(ByVal pstrIdSolicitud As String)
        hdnIdSolicitud.Value = pstrIdSolicitud

        If hdnIdSolicitud.Value <> "" Then
            Dim stringWrite1 As New System.IO.StringWriter
            Dim stringWrite2 As New System.IO.StringWriter
            Dim htmlWrite1 As New System.Web.UI.HtmlTextWriter(stringWrite1)
            Dim htmlWrite2 As New System.Web.UI.HtmlTextWriter(stringWrite2)
            Dim objSolicitud As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Solicitud
            Dim objSolicitudDetalle As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Solicitud
            Dim objUtil As New Utilitarios

            Dim tblCabecera As New Table
            Dim tblDetalle As New Table
            Dim tblPie As New Table
            Dim rowTable As TableRow


            objSolicitud.IdSolicitud = hdnIdSolicitud.Value
            If objSolicitud.Obtener() Then
                Dim objTipoMovimiento As New ALVI_LOGIC.Maestros.Logistica.TipoMovimiento
                Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
                Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
                Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
                Dim objProveedor As New ALVI_LOGIC.Maestros.Compras.Proveedor

                tblCabecera.Width = New Unit(100, UnitType.Percentage)
                rowTable = New TableRow
                rowTable.Cells.Add(objUtil.CreateCell("DPTO LOGISTICA", "TIT", "L", 2, 1))
                rowTable.Cells.Add(objUtil.CreateCell("SOLICITUD DE COTIZACION", "TIT", "L", 1, 1))
                tblCabecera.Rows.Add(rowTable)

                rowTable = New TableRow
                rowTable.Cells.Add(objUtil.CreateCell(" ", "TIT", "L", 3, 1))
                tblCabecera.Rows.Add(rowTable)

                rowTable = New TableRow
                rowTable.Cells.Add(objUtil.CreateCell("TELEFAX:", "TIT", "L", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell("465-0331", "TIT", "L", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(" ", "TIT", "L", 1, 1))
                tblCabecera.Rows.Add(rowTable)

                rowTable = New TableRow
                rowTable.Cells.Add(objUtil.CreateCell(" ", "TIT", "L", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell("429-0870", "TIT", "L", 1, 1))
                rowTable.Cells.Add(objUtil.CreateCell(" ", "TIT", "L", 1, 1))
                tblCabecera.Rows.Add(rowTable)


                objProveedor.IdProveedor = objSolicitud.Proveedor
                objProveedor.Obtener()
                rowTable = New TableRow
                rowTable.Cells.Add(objUtil.CreateCell(objProveedor.Descripcion, "TIT", "L", 3, 1))
                tblCabecera.Rows.Add(rowTable)

                rowTable = New TableRow
                rowTable.Cells.Add(objUtil.CreateCell("FECHA: " & Format(objSolicitud.FechaEmision, "dd/MM/yyyy"), "TIT", "L", 2, 1))
                rowTable.Cells.Add(objUtil.CreateCell("", "TIT", "L", 3, 1))
                tblCabecera.Rows.Add(rowTable)

                rowTable = New TableRow
                rowTable.Cells.Add(objUtil.CreateCell("Sirvanse cotizar lo siguiente;", "TIT", "L", 3, 1))
                tblCabecera.Rows.Add(rowTable)


                objSolicitudDetalle.IdSolicitud = objSolicitud.IdSolicitud
                If objSolicitudDetalle.Listar1() Then
                    Dim objUnidad As New ALVI_LOGIC.Configuracion.UnidadMedida

                    rowTable = New TableRow
                    rowTable.Cells.Add(objUtil.CreateCell("ITEM", "Head", "C", 1, 1, 50))
                    rowTable.Cells.Add(objUtil.CreateCell("CANTIDAD", "Head", "C", 1, 1, 100))
                    rowTable.Cells.Add(objUtil.CreateCell("UNIDAD", "Head", "C", 1, 1, 100))
                    rowTable.Cells.Add(objUtil.CreateCell("DESCRIPCION Y/O DETALLE", "Head", "C", 1, 1, 500))

                    tblDetalle.Rows.Add(rowTable)
                    Dim intConteo As Integer = 0
                    For Each dtrItem As Data.DataRow In objSolicitudDetalle.Datos.Rows
                        intConteo = intConteo + 1

                        objArticulo.IdArticulo = dtrItem("var_IdArticuloReferencia")
                        objArticulo.Obtener()
                        objUnidad.IdUnidadMedida = dtrItem("var_IdUnidadMedida")
                        objUnidad.Obtener()


                        rowTable = New TableRow
                        rowTable.Cells.Add(objUtil.CreateCell(Format(intConteo, "00"), "Item", "C", 1, 1))
                        rowTable.Cells.Add(objUtil.CreateCell(dtrItem("int_Cantidad"), "Item", "C", 1, 1))
                        rowTable.Cells.Add(objUtil.CreateCell(objUnidad.Descripcion, "Item", "C", 1, 1))
                        rowTable.Cells.Add(objUtil.CreateCell(dtrItem("var_IdArticuloReferencia"), "Item", "C", 1, 1, 500))

                        tblDetalle.Rows.Add(rowTable)
                    Next

                    While intConteo < 15
                        intConteo = intConteo + 1

                        rowTable = New TableRow
                        rowTable.Cells.Add(objUtil.CreateCell(Format(intConteo, "00"), "Item", "C", 1, 1))
                        rowTable.Cells.Add(objUtil.CreateCell(" ", "Item", "C", 1, 1))
                        rowTable.Cells.Add(objUtil.CreateCell(" ", "Item", "C", 1, 1))
                        rowTable.Cells.Add(objUtil.CreateCell(" ", "Item", "C", 1, 1, 500))

                        tblDetalle.Rows.Add(rowTable)
                    End While

                    rowTable = New TableRow
                    rowTable.Cells.Add(objUtil.CreateCell("Indicar", "TIT", "L", 4, 1))
                    tblDetalle.Rows.Add(rowTable)

                    rowTable = New TableRow
                    rowTable.Cells.Add(objUtil.CreateCell("Condiciones de pago", "TIT", "L", 4, 1))
                    tblDetalle.Rows.Add(rowTable)

                    rowTable = New TableRow
                    rowTable.Cells.Add(objUtil.CreateCell("Tipo de cambio si el precio es en dólares", "TIT", "L", 4, 1))
                    tblDetalle.Rows.Add(rowTable)

                    rowTable = New TableRow
                    rowTable.Cells.Add(objUtil.CreateCell("Punto de entrega", "TIT", "L", 4, 1))
                    tblDetalle.Rows.Add(rowTable)

                    rowTable = New TableRow
                    rowTable.Cells.Add(objUtil.CreateCell("Plazo de entrega", "TIT", "L", 4, 1))
                    tblDetalle.Rows.Add(rowTable)

                    rowTable = New TableRow
                    rowTable.Cells.Add(objUtil.CreateCell("PROCESO DE COMPRAS", "TIT", "R", 4, 1))
                    tblDetalle.Rows.Add(rowTable)


                    rowTable = New TableRow
                    rowTable.Cells.Add(objUtil.CreateCell("LO-P-001.FM3", "TIT", "L", 4, 1))
                    tblDetalle.Rows.Add(rowTable)

                    rowTable = New TableRow
                    rowTable.Cells.Add(objUtil.CreateCell("Editado: 01/07/12", "TIT", "L", 4, 1))
                    tblDetalle.Rows.Add(rowTable)

                    rowTable = New TableRow
                    rowTable.Cells.Add(objUtil.CreateCell("Revisión: 5-20/05/09", "TIT", "L", 4, 1))
                    tblDetalle.Rows.Add(rowTable)

                    rowTable = New TableRow
                    rowTable.Cells.Add(objUtil.CreateCell("Vigencia: 5 años", "TIT", "L", 4, 1))
                    tblDetalle.Rows.Add(rowTable)


                End If

                Session("Titulo") = "Solicitud Cotizacion"
                tblCabecera.RenderControl(htmlWrite1)
                Session("Datos") = stringWrite1.ToString
                tblDetalle.RenderControl(htmlWrite2)
                Session("Impresion") = stringWrite2.ToString

                
                ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('../Controles/frmPrint.aspx','Reporte', 'resizable=1, height=600, width=1000, top=0, left=0');</script>")
            End If
        End If

    End Sub

    Protected Sub btnRegistraCierreDocumento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistraCierreDocumento.Click
        If txtRequisicion1.Text <> "" AndAlso txtFechaEmisionInicio1.Text <> "" _
           AndAlso ctlProveedor_Buscar1.IdProveedor <> "" Then
            Registra()
            pnlDocumento.Visible = False
        End If
    End Sub
End Class
