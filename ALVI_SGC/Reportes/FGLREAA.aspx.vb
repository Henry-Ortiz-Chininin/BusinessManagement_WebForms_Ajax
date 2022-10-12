

Imports System.Data
Imports System.IO
Imports System.Web.UI.WebControls

Partial Class Reportes_FGLREAA
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            btnFechaEmisionInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionInicio.ClientID & ", 'dd/mm/yyyy');")
            btnFechaEmisionFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionFinal.ClientID & ", 'dd/mm/yyyy');")
            btnFechaRecepcionInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaRecepcionInicio.ClientID & ", 'dd/mm/yyyy');")
            btnFechaRecepcionFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaRecepcionFinal.ClientID & ", 'dd/mm/yyyy');")
            btnFechaPlazoInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaPlazoInicio.ClientID & ", 'dd/mm/yyyy');")
            btnFechaPlazoFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaPlazoFinal.ClientID & ", 'dd/mm/yyyy');")


        End If
    End Sub


    Protected Sub btnGenerar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGenerar.Click

        Dim objRequisicion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Requisicion

        objRequisicion.Buscar(txtCodigo.Text, _
                             ctlSolicitante_Buscar1.IdSolicitante, _
                             txtFechaEmisionInicio.Text, _
                             txtFechaEmisionFinal.Text, _
                             txtFechaRecepcionInicio.Text, _
                             txtFechaRecepcionFinal.Text, _
                             txtFechaPlazoInicio.Text, _
                             txtFechaPlazoFinal.Text, _
                             rbtTipo.SelectedValue, _
                             ctlCentroCosto_Buscar1.IdCentroCosto, _
                             ctlProyecto_Buscar1.IdProyecto, _
                             ctlCargo_Buscar1.IdCargo)

        If objRequisicion.Datos.Rows.Count > 0 Then

            Dim stringWrite As New StringWriter()
            Dim htmlWrite As New HtmlTextWriter(stringWrite)


            Dim tblResumen As New Table
            Dim tblDatos As New Table


            BindDatos(tblDatos)
            Session("Datos") = stringWrite.ToString
            tblDatos.RenderControl(htmlWrite)

            BindResumen(tblResumen)
            Session("Titulo") = "Seguimiento de Requisiciones: "
            tblResumen.RenderControl(htmlWrite)


            Session("Impresion") = stringWrite.ToString

            ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('../Controles/frmPrint.aspx','Reporte', 'resizable=1,height=600,width=1000,top=0,left=0,scrollbars=1');</script>")



        End If


        'Response.Redirect("FGLINAA.aspx")

    End Sub

    Private Sub BindDatos(ByRef tblDatos As Table)

        Dim stringWrite As New StringWriter()
        Dim htmlWrite As New HtmlTextWriter(stringWrite)

        Dim rowItem As TableRow

        If (rbtTipo.SelectedValue <> "") Then

            If rbtTipo.SelectedValue = "C" Then

                rowItem = New TableRow
                rowItem.Cells.Add(CreateCelll("Tipo:", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll("COMPRA", "Item", "C", 2, 1))
                rowItem.Cells.Add(CreateCelll("        ", "Item", "L", 8, 1))
                rowItem.Cells.Add(CreateCelll("Solicitante", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll(ctlSolicitante_Buscar1.Nombre, "Item", "C", 4, 1))
                tblDatos.Rows.Add(rowItem)

                rowItem = New TableRow
                rowItem.Cells.Add(CreateCelll("Fecha Emision:", "Item", "L", 4, 1))
                rowItem.Cells.Add(CreateCelll(txtFechaEmisionInicio.Text, "Item", "C", 3, 1))
                rowItem.Cells.Add(CreateCelll("al:", "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(txtFechaEmisionFinal.Text, "Item", "C", 3, 1))
                rowItem.Cells.Add(CreateCelll("", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll("Cargo", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll(ctlCargo_Buscar1.Nombre, "Item", "C", 4, 1))
                tblDatos.Rows.Add(rowItem)

                rowItem = New TableRow
                rowItem.Cells.Add(CreateCelll("Fecha Recepcion:", "Item", "L", 4, 1))
                rowItem.Cells.Add(CreateCelll(txtFechaRecepcionInicio.Text, "Item", "C", 3, 1))
                rowItem.Cells.Add(CreateCelll("al:", "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(txtFechaRecepcionFinal.Text, "Item", "C", 3, 1))
                rowItem.Cells.Add(CreateCelll("", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll("Centro de Costo Destino", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll(ctlCentroCosto_Buscar1.Descripcion, "Item", "C", 4, 1))
                tblDatos.Rows.Add(rowItem)


                rowItem = New TableRow
                rowItem.Cells.Add(CreateCelll("Fecha PLazo:", "Item", "L", 4, 1))
                rowItem.Cells.Add(CreateCelll(txtFechaPlazoInicio.Text, "Item", "C", 3, 1))
                rowItem.Cells.Add(CreateCelll("al:", "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(txtFechaPlazoFinal.Text, "Item", "C", 3, 1))
                rowItem.Cells.Add(CreateCelll("", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll("Proyecto", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll(ctlProyecto_Buscar1.Nombre, "Item", "C", 4, 1))
                tblDatos.Rows.Add(rowItem)

            End If

            If rbtTipo.SelectedValue = "S" Then

                rowItem = New TableRow
                rowItem.Cells.Add(CreateCelll("Tipo:", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll("SERVICIO", "Item", "C", 2, 1))
                rowItem.Cells.Add(CreateCelll("        ", "Item", "L", 8, 1))
                rowItem.Cells.Add(CreateCelll("Solicitante", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll(ctlSolicitante_Buscar1.Nombre, "Item", "C", 4, 1))
                tblDatos.Rows.Add(rowItem)

                rowItem = New TableRow
                rowItem.Cells.Add(CreateCelll("Fecha Emision:", "Item", "L", 4, 1))
                rowItem.Cells.Add(CreateCelll(txtFechaEmisionInicio.Text, "Item", "C", 3, 1))
                rowItem.Cells.Add(CreateCelll("al:", "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(txtFechaEmisionFinal.Text, "Item", "C", 3, 1))
                rowItem.Cells.Add(CreateCelll("", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll("Cargo", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll(ctlCargo_Buscar1.Nombre, "Item", "C", 4, 1))
                tblDatos.Rows.Add(rowItem)

                rowItem = New TableRow
                rowItem.Cells.Add(CreateCelll("Fecha Recepcion:", "Item", "L", 4, 1))
                rowItem.Cells.Add(CreateCelll(txtFechaRecepcionInicio.Text, "Item", "C", 3, 1))
                rowItem.Cells.Add(CreateCelll("al:", "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(txtFechaRecepcionFinal.Text, "Item", "C", 3, 1))
                rowItem.Cells.Add(CreateCelll("", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll("Centro de Costo Destino", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll(ctlCentroCosto_Buscar1.Descripcion, "Item", "C", 4, 1))
                tblDatos.Rows.Add(rowItem)


                rowItem = New TableRow
                rowItem.Cells.Add(CreateCelll("Fecha PLazo:", "Item", "L", 4, 1))
                rowItem.Cells.Add(CreateCelll(txtFechaPlazoInicio.Text, "Item", "C", 3, 1))
                rowItem.Cells.Add(CreateCelll("al:", "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(txtFechaPlazoFinal.Text, "Item", "C", 3, 1))
                rowItem.Cells.Add(CreateCelll("", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll("Proyecto", "Item", "L", 2, 1))
                rowItem.Cells.Add(CreateCelll(ctlProyecto_Buscar1.Nombre, "Item", "C", 4, 1))
                tblDatos.Rows.Add(rowItem)

            End If

        End If


    End Sub


    Private Sub BindResumen(ByRef tblDatos As Table)

        If (rbtTipo.SelectedValue <> "") Then

            Dim objRequisicion As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Requisicion

            Dim stringWrite As New StringWriter()
            Dim htmlWrite As New HtmlTextWriter(stringWrite)

            Dim dtbResumen = CType(Session("dtbResumen"), Data.DataTable)

            Dim objResumen As New ALVI_LOGIC.Proceso.Logistica.Compra.Requisicion.Requisicion



            '*********************************************************
            'INICIO: CABECERA
            '*********************************************************

            Dim rowItem As TableRow
            rowItem = New TableRow
            rowItem.Cells.Add(CreateCelll("Codigo", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Solicitante", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Cargo", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Destino", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Emision", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Recepcion", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Plazo", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Cierre", "Head", "C", 1, 1))
            rowItem.Cells.Add(CreateCelll("Proyecto", "Head", "C", 1, 1))
            tblDatos.Rows.Add(rowItem)


            '*********************************************************
            'DETALLE
            '*********************************************************


            Dim strCodigo As String = ""
            Dim strSolicitante As String = ""
            Dim strCargo As String = ""
            Dim strDestino As String = ""
            Dim strEmision As String = ""
            Dim strRecepcion As String = ""
            Dim strPlazo As String = ""
            Dim strCierre As String = ""
            Dim strProyecto As String = ""

            objRequisicion.Buscar(txtCodigo.Text, _
                             ctlSolicitante_Buscar1.IdSolicitante, _
                             txtFechaEmisionInicio.Text, _
                             txtFechaEmisionFinal.Text, _
                             txtFechaRecepcionInicio.Text, _
                             txtFechaRecepcionFinal.Text, _
                             txtFechaPlazoInicio.Text, _
                             txtFechaPlazoFinal.Text, _
                             rbtTipo.SelectedValue, _
                             ctlCentroCosto_Buscar1.IdCentroCosto, _
                             ctlProyecto_Buscar1.IdProyecto, _
                             ctlCargo_Buscar1.IdCargo)



            For Each dtrResumen As Data.DataRow In objRequisicion.Datos.Rows

                strCodigo = dtrResumen("var_IdRequisicion")
                strSolicitante = dtrResumen("var_Solicitante")
                strCargo = dtrResumen("var_Cargo")
                strDestino = dtrResumen("var_TipoOperacion")
                strEmision = dtrResumen("dtm_FechaEmision")
                strRecepcion = dtrResumen("dtm_FechaRecepcion")
                strPlazo = dtrResumen("dtm_FechaPlazo")
                strCierre = dtrResumen("dtm_FechaCierre")
                strProyecto = dtrResumen("var_Proyecto")

                If strCierre = "01/01/1900" Then
                    strCierre = ""
                End If

                rowItem = New TableRow
                rowItem.Cells.Add(CreateCelll(strCodigo, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strSolicitante, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strCargo, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strDestino, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strEmision, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strRecepcion, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strPlazo, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strCierre, "Item", "C", 1, 1))
                rowItem.Cells.Add(CreateCelll(strProyecto, "Item", "C", 1, 1))

                tblDatos.Rows.Add(rowItem)

                tblDatos.Width = 1000

            Next

        End If


    End Sub


    Private Function CreateCelll(ByVal strTexto As String, ByVal strTipo As String, _
                                 ByVal strAlign As String, ByVal intCols As Int16, ByVal intRows As Int16) As TableCell
        Dim celItem As New TableCell
        celItem.Text = strTexto
        celItem.ColumnSpan = intCols
        celItem.RowSpan = intRows
        Select Case strTipo
            Case "Head"
                celItem.CssClass = "GridHeader"
            Case "Foot"
                celItem.CssClass = "GridFooter"
            Case "Item"
                celItem.CssClass = "GridItem"
            Case "Alt"
                celItem.CssClass = "GridAltItem"
        End Select
        Select Case strAlign
            Case "L"
                celItem.HorizontalAlign = HorizontalAlign.Left
            Case "R"
                celItem.HorizontalAlign = HorizontalAlign.Right
            Case "C"
                celItem.HorizontalAlign = HorizontalAlign.Center
            Case "J"
                celItem.HorizontalAlign = HorizontalAlign.Justify
        End Select
        Return celItem
    End Function


End Class
