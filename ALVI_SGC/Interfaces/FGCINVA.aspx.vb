
Partial Class Estandares_FGCINVA
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim dtbAtributos As New Data.DataTable
            Dim dtbArticulos As New Data.DataTable
            pnlFormulario.Visible = False
            pnlRegistroOrdenServicio.Visible = False
            BindGrid()
            btnFechaInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaInicio.ClientID & ", 'dd/mm/yyyy');")
            btnFechaFin.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaFin.ClientID & ", 'dd/mm/yyyy');")
            btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmision.ClientID & ", 'dd/mm/yyyy');")
            btnFechavencimiento.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaVencimiento.ClientID & ", 'dd/mm/yyyy');")

            btnInicioServicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtInicioServicio.ClientID & ", 'dd/mm/yyyy');")
            'btnFinalServicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFinalServicio.ClientID & ", 'dd/mm/yyyy');")

            BindAtributos(ddlMoneda)
            BindVendedor(ddlVendedor)
            BinMotivo(ddlMotivo)
            BindMotivos(ddlMotivo)
            ddlTipoDocumento.SelectedIndex = 1
            rbtProducto.Checked = False
            rbtServicio.Checked = True
            ddlTipoPago.Enabled = True
            'CreateSchemaArticulos()
            'CreateSchemeOrdenServicio()
            txtCodigo.Enabled = False
            txtFechaEmision.Text = Format(Now.Date, "dd/MM/yyyy")
            pnlCajaBanco.Visible = False
            pnlClienteRegistro.Visible = False
            ctlClienteTercero.ObjLblContacto.Visible = False
            ctlClienteTercero.ObjLblDireccion.Visible = False
            ctlClienteTercero.ObjTxtContacto.Visible = False
            ctlClienteTercero.ObjTxtDireccion.Visible = False
        End If
    End Sub
    Private Sub Mensaje(ByVal _pstrMensaje As String)
        If _pstrMensaje <> "" Then
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('" & _pstrMensaje & "');</script>")
        End If

    End Sub
    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
        LimpiarFormulario()
        lblMensaje.Text = ""
        txtCodigo.ReadOnly = True
        txtCodigo.MaxLength = 21
        pnlFormulario.Visible = True
        objComprobante.MaxID()
        txtNumero.Text = objComprobante.Maximo
        txtCodigo.Focus()
    End Sub
    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub
    Private Sub Cancelar()
        LimpiarFormulario()
        pnlFormulario.Visible = False
        pnlRegistroOrdenServicio.Visible = False
        BindGrid()
    End Sub
    Private Sub LimpiarFormulario()
        Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
        ddlVendedor.Enabled = True
        ddlMoneda.Enabled = True
        txtCodigo.Enabled = True
        txtCorrelativo.Enabled = True
        txtNumero.Enabled = True
        rbtServicio.Enabled = True
        rbtProducto.Enabled = True
        txtFechaEmision.Enabled = True
        txtFechaVencimiento.Enabled = True
        ddlTipoDocumento.Enabled = True
        ddlMotivo.Enabled = True
        grdArticulo.Enabled = True
        btnAgregar.Enabled = True
        'btnFechaEmision.Visible = True
        'btnFechavencimiento.Visible = True
        txtTotalParcial.ReadOnly = True
        txtTotalDesc.ReadOnly = True
        txtSubTotal.ReadOnly = True
        txtIGV.ReadOnly = True
        txtTotal.ReadOnly = True
        txtCodigo.ReadOnly = True
        pnlFormulario.Visible = True
        ddlTipoPago.Enabled = True

        objComprobante.TotalParcial = 0
        objComprobante.Descuento = 0
        objComprobante.SubTotal = 0
        objComprobante.IGV = 0
        objComprobante.Total = 0

        txtCantidad.Text = "0"
        'txtFechaInicio.Text = Format(Now, "dd/MM/yyyy")
        'txtFechaFin.Text = Format(Now, "dd/MM/yyyy")
        txtCostoUnitario.Text = "0"
        txtDesServicio.Text = "0"
        txtDesc.Text = "0"
        txtCodigo.Text = ""
        txtNumero.Text = ""
        txtCorrelativo.Text = ""
        txtIGV.Text = "0"
        txtTotalDesc.Text = "0"
        txtSubTotal.Text = "0"
        txtTotal.Text = "0"
        txtDesc.Text = "0"
        txtTotalParcial.Text = "0"
        txtImporteTercero.Text = "0"
        txtFechaVencimiento.Text = ""
        txtDesServicio.Text = ""
        txtFechaEmision.Text = Format(Now.Date, "dd/MM/yyyy")
        ddlVendedor.SelectedIndex = 0
        ddlMotivo.SelectedIndex = 0
        ddlTipoPago.SelectedIndex = 0
        ctlArticulo1.Limpia()
        ctlCliente2.Limpia()
        CreateSchemaArticulos()
        CreateSchemeOrdenServicio()
        Dim dtbAtributos As Data.DataTable = CType(Session("dtbAtributos"), Data.DataTable)
        Dim dtbOrdenServicio As Data.DataTable = CType(Session("dtbOrdenServicio"), Data.DataTable)
        grdOrdenServicios.DataSource = dtbOrdenServicio
        grdOrdenServicios.DataBind()
        grdArticulo.DataSource = dtbAtributos
        grdArticulo.DataBind()
    End Sub
    Private Sub BindAtributos(ByRef pddlAtributos As DropDownList)
        Try
            Dim objAtributos As New ALVI_LOGIC.Maestros.Administracion.Moneda
            pddlAtributos.Items.Clear()
            If objAtributos.Listar() = True Then
                pddlAtributos.DataValueField = "var_IdMoneda"
                pddlAtributos.DataTextField = "var_DesMoneda"
                pddlAtributos.DataSource = objAtributos.Datos
                pddlAtributos.DataBind()
            End If
            pddlAtributos.Items.Insert(0, New ListItem("Seleccionar", ""))
            pddlAtributos.SelectedIndex = 2
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindMotivos(ByRef pddlMotivo As DropDownList)
        Dim objMotivos As New ALVI_LOGIC.Maestros.Ventas.AtributoMotivo
        objMotivos.IdMotivo = "CO"
        pddlMotivo.Items.Clear()
        If objMotivos.Listar() = True Then
            pddlMotivo.DataValueField = "var_IdMotivoAtributo"
            pddlMotivo.DataTextField = "var_Descripcion"
            pddlMotivo.DataSource = objMotivos.Datos
            pddlMotivo.DataBind()
        End If
        pddlMotivo.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlMotivo.SelectedIndex = 0
    End Sub
    Private Sub BindVendedor(ByRef pddlVendedor As DropDownList)
        Dim objAtributos As New ALVI_LOGIC.Maestros.Ventas.Vendedor
        pddlVendedor.Items.Clear()
        If objAtributos.Listar() = True Then
            pddlVendedor.DataValueField = "var_IdVendedor"
            pddlVendedor.DataTextField = "var_Nombrecompleto"
            pddlVendedor.DataSource = objAtributos.Datos
            pddlVendedor.DataBind()
        End If
        pddlVendedor.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlVendedor.SelectedIndex = 0
    End Sub
    Private Sub BinMotivo(ByRef pddlMotivo As DropDownList)
        Dim objAtributos As New ALVI_LOGIC.Maestros.Ventas.Motivo
        pddlMotivo.Items.Clear()
        If objAtributos.Listar() = True Then
            pddlMotivo.DataValueField = "var_IdMotivo"
            pddlMotivo.DataTextField = "var_Descripcion"
            pddlMotivo.DataSource = objAtributos.Datos
            pddlMotivo.DataBind()
        End If
        pddlMotivo.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlMotivo.SelectedIndex = 0
    End Sub
    Private Sub BindValores(ByRef pddlValores As DropDownList, ByVal pstrIdAtributoTipo As String)
        Dim objValores As New ALVI_LOGIC.Maestros.Pedido.PedidoValor
        pddlValores.Items.Clear()
        objValores.IdAtributoTipo = pstrIdAtributoTipo
        If objValores.Listar() = True Then
            pddlValores.DataValueField = "var_IdAtributoValor"
            pddlValores.DataTextField = "var_Descripcion"
            pddlValores.DataSource = objValores.Datos
            pddlValores.DataBind()
        End If
        pddlValores.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlValores.SelectedIndex = 0
    End Sub
    Private Sub BindDocumentos(ByRef pddlDocumentos As DropDownList)
        Dim objValores As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento
        objValores.Clasificacion = "S"
        pddlDocumentos.Items.Clear()
        If objValores.Listar() = True Then
            pddlDocumentos.DataValueField = "chr_IdTipoDocumento"
            pddlDocumentos.DataTextField = "var_Descripcion"
            pddlDocumentos.DataSource = objValores.Datos
            pddlDocumentos.DataBind()
        End If
        pddlDocumentos.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlDocumentos.SelectedIndex = 2
    End Sub
    Private Sub CreateSchemeOrdenServicio()
        Dim dtbOrdenServicio As New Data.DataTable
        dtbOrdenServicio.Columns.Add("int_Secuencia", GetType(Integer))
        dtbOrdenServicio.Columns.Add("var_IdComprobante", GetType(String))
        dtbOrdenServicio.Columns.Add("var_IdOrdenServicio", GetType(String))
        dtbOrdenServicio.Columns.Add("var_RazonSocial", GetType(String))
        dtbOrdenServicio.Columns.Add("num_Importe", GetType(Decimal))
        dtbOrdenServicio.Columns.Add("var_Usuario", GetType(String))
        dtbOrdenServicio.Columns.Add("int_NumeroComprobante", GetType(String))

        Dim pkyOS(1) As Data.DataColumn
        pkyOS(0) = dtbOrdenServicio.Columns("int_Secuencia")
        dtbOrdenServicio.PrimaryKey = pkyOS

        Session("dtbOrdenServicio") = dtbOrdenServicio
    End Sub
    Private Sub CreateSchemeOrdenServicioNuevo()
        Dim dtbOrdenServicio As New Data.DataTable
        dtbOrdenServicio.Columns.Add("int_Secuencia", GetType(Integer))
        dtbOrdenServicio.Columns.Add("var_IdComprobante", GetType(String))
        dtbOrdenServicio.Columns.Add("var_IdOrdenServicio", GetType(String))
        dtbOrdenServicio.Columns.Add("var_RazonSocial", GetType(String))
        dtbOrdenServicio.Columns.Add("num_Importe", GetType(Decimal))
        dtbOrdenServicio.Columns.Add("var_Usuario", GetType(String))
        dtbOrdenServicio.Columns.Add("int_NumeroComprobante", GetType(String))

        Dim pkyOS(1) As Data.DataColumn
        pkyOS(0) = dtbOrdenServicio.Columns("int_Secuencia")
        dtbOrdenServicio.PrimaryKey = pkyOS

        Session("dtbOrdenServicioNuevo") = dtbOrdenServicio
    End Sub
    Private Sub CreateSchemaArticulos()
        Dim dtbArticulos As New Data.DataTable
        dtbArticulos.Columns.Add("int_Secuencia", GetType(Int16))
        dtbArticulos.Columns.Add("var_CodArticulo", GetType(String))
        dtbArticulos.Columns.Add("var_DesArticulo", GetType(String))
        dtbArticulos.Columns.Add("var_Unidad", GetType(String))
        dtbArticulos.Columns.Add("num_Cantidad", GetType(Double))
        dtbArticulos.Columns.Add("num_Rollos", GetType(Double))
        dtbArticulos.Columns.Add("num_Importe", GetType(Double))
        dtbArticulos.Columns.Add("var_DesServicio", GetType(String))
        dtbArticulos.Columns.Add("num_CostoUnitario", GetType(String))
        dtbArticulos.Columns.Add("var_Descuento", GetType(Double))
        dtbArticulos.Columns.Add("num_CostoUnitarioR", GetType(String))
        dtbArticulos.Columns.Add("dtm_FechaInicio", GetType(String))
        dtbArticulos.Columns.Add("dtm_FechaFinal", GetType(String))

        Dim pkTelas(1) As Data.DataColumn
        pkTelas(0) = dtbArticulos.Columns("int_Secuencia")

        dtbArticulos.PrimaryKey = pkTelas
        Session("dtbAtributos") = dtbArticulos
    End Sub
    Private Sub CreateSchemaArticulosNuevo()
        Dim dtbArticulos As New Data.DataTable
        dtbArticulos.Columns.Add("int_Secuencia", GetType(Int16))
        dtbArticulos.Columns.Add("var_CodArticulo", GetType(String))
        dtbArticulos.Columns.Add("var_Unidad", GetType(String))
        dtbArticulos.Columns.Add("num_Cantidad", GetType(Double))
        dtbArticulos.Columns.Add("num_Rollos", GetType(Double))
        dtbArticulos.Columns.Add("num_Importe", GetType(Double))
        dtbArticulos.Columns.Add("var_DesServicio", GetType(String))
        dtbArticulos.Columns.Add("num_CostoUnitario", GetType(String))
        dtbArticulos.Columns.Add("var_Descuento", GetType(Double))
        dtbArticulos.Columns.Add("num_CostoUnitarioR", GetType(String))
        dtbArticulos.Columns.Add("dtm_FechaInicio", GetType(String))
        dtbArticulos.Columns.Add("dtm_FechaFinal", GetType(String))
        Dim pkTelas(1) As Data.DataColumn
        pkTelas(0) = dtbArticulos.Columns("int_Secuencia")

        dtbArticulos.PrimaryKey = pkTelas
        Session("dtbAtributosNuevo") = dtbArticulos
    End Sub
    Private Sub BindGrid()
        Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("int_Secuencia", GetType(String))
        dtbDatos.Columns.Add("var_IdComprobante", GetType(String))
        dtbDatos.Columns.Add("var_IdCliente", GetType(String))
        dtbDatos.Columns.Add("dtm_FechaEmision", GetType(String))
        dtbDatos.Columns.Add("dtm_FechaVencimiento", GetType(String))
        dtbDatos.Columns.Add("var_Estado", GetType(String))
        dtbDatos.Columns.Add("var_TipoServicio", GetType(String))
        dtbDatos.Columns.Add("var_idVendedor", GetType(String))
        dtbDatos.Columns.Add("var_Tipo", GetType(String))
        dtbDatos.Columns.Add("var_DesMoneda", GetType(String))

        objComprobante.IdComprobante = txtComprobante.Text
        objComprobante.NumeroDocumento = txtNumDoc.Text
        objComprobante.IdCliente = txtCliente.Text
        objComprobante.FechaIngreso = txtFechaInicio.Text
        objComprobante.Correlativo = txtNumCorrelativo.Text
        objComprobante.FechaEntrega = txtFechaFin.Text
        objComprobante.Estado = ddlEstadoB.SelectedValue
        'txtCorrelativo.ReadOnly = True
        objComprobante.Buscar()
        Try
            For Each dtrItem As Data.DataRow In objComprobante.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                Dim FechaIngreso As DateTime
                dtrNuevo("int_Secuencia") = dtrItem("int_Secuencia")
                dtrNuevo("var_IdComprobante") = dtrItem("var_IdComprobante")
                dtrNuevo("var_IdCliente") = dtrItem("var_IdCliente")
                FechaIngreso = CDate(dtrItem("dtm_FechaEmision"))
                dtrNuevo("dtm_FechaVencimiento") = Format(FechaIngreso, "dd/MM/yyyy")
                FechaIngreso = CDate(dtrItem("dtm_FechaVencimiento"))
                dtrNuevo("dtm_FechaEmision") = Format(FechaIngreso, "dd/MM/yyyy")
                dtrNuevo("var_Estado") = dtrItem("var_Estado")
                dtrNuevo("var_TipoServicio") = dtrItem("var_TipoServicio")
                dtrNuevo("var_idVendedor") = dtrItem("var_idVendedor")
                dtrNuevo("var_Tipo") = dtrItem("var_Tipo")
                dtrNuevo("var_DesMoneda") = dtrItem("var_DesMoneda")
                dtbDatos.Rows.Add(dtrNuevo.ItemArray)
                dtbDatos.AcceptChanges()
            Next
        Catch
        End Try
        Session("dtbArticulos") = dtbDatos
        grdDatos.DataSource = Session("dtbArticulos")
        grdDatos.DataBind()
    End Sub
    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrar.Click
        Registrar()
        If lblMensaje.Text = "Registro exitoso" Then
            LimpiarFormulario()
            Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
            objComprobante.MaxID()
            txtNumero.Text = objComprobante.Maximo
        End If
    End Sub
    Private Function Registrar() As Boolean
        Dim dtbAtributos As Data.DataTable = CType(Session("dtbAtributos"), Data.DataTable)
        Dim dtbOrdenServicio As Data.DataTable = CType(Session("dtbOrdenServicio"), Data.DataTable)
        Session("dtbAtributosNuevo") = dtbAtributos
        Session("dtbOrdenServicioNuevo") = dtbOrdenServicio
        Dim _strMensaje As String = ""
        Dim _bolValidar As Boolean = True

        If ddlEstado.SelectedValue = "ACT" Then
            If txtFechaEmision.Text = "" Then
                _bolValidar = False
                _strMensaje += "- Ingresar fecha \n"
            End If
            If ctlCliente2.RazonSocial = "" Then
                _bolValidar = False
                _strMensaje += "- Seleccionar cliente \n"
            End If
            If ddlMoneda.SelectedValue = "" Then
                _bolValidar = False
                _strMensaje += "- Seleccionar moneda \n"
            End If
        End If

        If ddlEstado.SelectedValue = "DES" Then
            If txtFechaEmision.Text = "" Then
                _bolValidar = False
                _strMensaje += "- Ingresar fecha \n"
            End If
            If ddlMoneda.SelectedValue = "" Then
                _bolValidar = False
                _strMensaje += "- Seleccionar moneda \n"
            End If
        End If


        Dim dtbAtributosNuevo As Data.DataTable = CType(Session("dtbAtributosNuevo"), Data.DataTable)

        If _bolValidar = True Then
            Dim objFactura As New ALVI_LOGIC.Maestros.Ventas.Factura
            objFactura.idArticulo = txtCodigo.Text
            objFactura.IdCliente = ctlCliente2.IdCliente.ToString
            objFactura.idVendedor = ddlVendedor.SelectedValue.ToString
            objFactura.idMoneda = ddlMoneda.SelectedValue
            objFactura.NumeroDocumento = txtCodigo.Text
            objFactura.Correlativo = txtCorrelativo.Text
            objFactura.IdComprobante = txtNumero.Text
            If rbtServicio.Checked Then
                objFactura.IdServicio = "S"
            Else
                objFactura.IdServicio = "P"
            End If
            objFactura.FechaEmision = txtFechaEmision.Text
            objFactura.EstadoPedido = ddlEstado.SelectedValue
            objFactura.FechaVencimiento = txtFechaVencimiento.Text
            objFactura.IdDocumento = ddlTipoDocumento.SelectedValue
            objFactura.TipoPago = ddlTipoPago.SelectedValue
            objFactura.Usuario = Session("Usuario")
            objFactura.Estado = ddlEstado.SelectedValue
            objFactura.Observacion = txtDesServicio.Text
            objFactura.IdMotivo = ddlMotivo.SelectedValue.ToString
            objFactura.SubTotal = Math.Round(CDbl(txtSubTotal.Text), 3)
            objFactura.IGV = Math.Round(CDbl(Replace(txtIGV.Text, "%", "")), 3)
            objFactura.TotalParcial = Math.Round(CDbl(txtTotalParcial.Text), 3)
            objFactura.Descuento = Math.Round(CDbl(Replace(txtTotalDesc.Text, "%", "")), 3)
            objFactura.Total = Math.Round(CDbl(txtTotal.Text), 2)
            objFactura.TipoCambio = CDbl(Master.TipoCambio)
            objFactura.IdServicioTer = ctlClienteTercero.IdCliente.ToString()
            objFactura.ImporteSerTer = CDbl(txtImporteTercero.Text)

            If objFactura.Registrar(dtbAtributosNuevo) = True Then
                dtbAtributos.Rows.Clear()
                BindGrid()
                lblMensaje.Text = "Registro exitoso"
                grdDatos.EditIndex = -1
                _bolValidar = True
            Else
                lblMensaje.Text = "Datos Incorrectos"
                _bolValidar = False
            End If

            If dtbOrdenServicio.Rows.Count > 0 Then
                objFactura.Registrar_ComprobanteOrdenServicio(dtbOrdenServicio)
            End If

        Else
            Mensaje(_strMensaje)
        End If

        Return _bolValidar
    End Function
    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("default.aspx")
    End Sub
    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub
    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "CAJABANCO" Then
            Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
            objComprobante.NumeroDocumento = e.CommandArgument.ToString
            If objComprobante.Obtener = True Then
                pnlCajaBanco.Visible = True
                ctlCajaBanco.Limpiar()
                ctlCajaBanco.IdCliente = objComprobante.IdCliente
                ctlCajaBanco.IdProveedor = ""
                ctlCajaBanco.IdTipoDocumentoHaber = objComprobante.IdDocumento
                ctlCajaBanco.NumeroDocumentoHaber = Format(CInt(objComprobante.Correlativo), "000-000000")
                ctlCajaBanco.Importe = objComprobante.Importe
                ctlCajaBanco.Glosa = "POR EL COBRO DE LA FACTURA " & Format(CInt(objComprobante.Correlativo), "000-000000")
                ctlCajaBanco.IdOperacion = "0000010"
                ctlCajaBanco.Importe = objComprobante.TotalParcial
                ctlCajaBanco.IdTipoDocumentoDebe = "VIB"
                ctlCajaBanco.OperacionHabilitado = False
                ctlCajaBanco.DocumentoAcreedorHabilitado = False

            End If
        End If

        If e.CommandName = "Modificar" Then
            Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
            objComprobante.NumeroDocumento = e.CommandArgument.ToString
            If objComprobante.Obtener = True Then
                LimpiarFormulario()
                lblMensaje.Text = ""
                txtNumero.Text = ""
                Try
                    ctlCliente2.IdCliente = objComprobante.IdCliente
                    ctlCliente2.RazonSocial = objComprobante.Cliente
                    ctlCliente2.BuscarId()
                    If objComprobante.IdServicioTer <> "" Then
                        ctlClienteTercero.IdCliente = objComprobante.IdServicioTer
                        ctlClienteTercero.BuscarId()
                        txtImporteTercero.Text = objComprobante.ImporteSerTer
                    End If
                    ddlVendedor.SelectedValue = objComprobante.idVendedor
                    ddlVendedor.Enabled = False
                    ddlTipoDocumento.Enabled = False
                    ddlMotivo.Enabled = False
                    ddlMoneda.SelectedValue = objComprobante.idMoneda
                    ddlMoneda.Enabled = False
                    txtCodigo.Text = objComprobante.NumeroDocumento
                    txtCodigo.Enabled = False
                    txtCorrelativo.Text = objComprobante.Correlativo
                    txtCorrelativo.Enabled = False
                    txtNumero.Text = objComprobante.IdComprobante
                    txtNumero.Enabled = False
                    If objComprobante.IdServicio = "S" Then
                        rbtServicio.Checked = True
                        rbtProducto.Checked = False
                        rbtServicio.Enabled = False
                        rbtProducto.Enabled = False
                    Else
                        rbtServicio.Checked = False
                        rbtProducto.Checked = True
                        rbtServicio.Enabled = False
                        rbtProducto.Enabled = False
                    End If
                    txtFechaEmision.Text = objComprobante.FechaEmision
                    txtFechaEmision.Enabled = False
                    ddlEstado.SelectedValue = objComprobante.EstadoPedido
                    txtFechaVencimiento.Text = objComprobante.FechaVencimiento
                    txtFechaVencimiento.Enabled = False
                    ddlTipoDocumento.SelectedValue = objComprobante.IdDocumento
                    ddlTipoDocumento.Enabled = False
                    ddlMotivo.SelectedValue = objComprobante.IdMotivo
                    ddlMotivo.Enabled = False
                    ddlTipoPago.SelectedValue = objComprobante.TipoPago
                    ddlTipoPago.Enabled = False
                Catch
                    ddlMotivo.SelectedIndex = 0
                End Try
                BindGridDetalle(e.CommandArgument)
                BindGridOrdenServicio(e.CommandArgument)
                grdArticulo.Enabled = False
                btnAgregar.Enabled = False
                btnFechaEmision.Visible = False
                btnFechavencimiento.Visible = False
                txtCodigo.ReadOnly = True
                txtCodigo.MaxLength = 20
                pnlFormulario.Visible = True
            End If
        End If
        If e.CommandName = "Eliminar" Then
            Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
            objComprobante.NumeroDocumento = CInt(e.CommandArgument)
            objComprobante.EliminarSecuencia()
            BindGrid()
        End If

        If e.CommandName = "Imprimir" Then
            Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
            Dim strMensaje As String = ""
            Dim strEstadoPedido As String = ""
            objComprobante.NumeroDocumento = CInt(e.CommandArgument)

            If objComprobante.Obtener = True Then
                If objComprobante.EstadoPedido.ToString.Trim() = "ACT" Then
                    Imprimir(objComprobante, "EXPO")
                Else
                    strMensaje = "El Comprobante esta Anulado"
                    ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('" + strMensaje + "');</script>")
                End If
            End If

        End If
    End Sub
    Private Sub Imprimir(ByVal pobjComprobante As ALVI_LOGIC.Maestros.Ventas.Factura, ByVal pstrAction As String)
        Dim objSeguridad As New ALVI_Security.General
        Dim strReporte As String = ""
        Dim strTipo As String = ""
        Dim strAction As String = ""
        Dim strCodigo As String = ""
        Dim strIdIdioma As String = ""
        Dim strMensaje As String = ""
        If pobjComprobante.NumeroDocumento <> "" Then
            strReporte = objSeguridad.Encrypta("CO")
            strTipo = "CO"
            strAction = objSeguridad.Encrypta(pstrAction)
            strCodigo = objSeguridad.Encrypta(pobjComprobante.NumeroDocumento)
            ClientScript.RegisterStartupScript(ClientScript.GetType, "Imprimir", "<script language='javascript'>window.open('FGCIMPRE.aspx?Repor=" & strReporte & "&" & strTipo & "=" & strCodigo & "&Act=" & strAction & "','Reporte', 'scrollbars=yes,resizable=1, height=600, width=1000, top=0, left=0');</script>")
        Else
            strMensaje = "No Jala el código del comprobante"

            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('" + strMensaje + "');</script>")
        End If
    End Sub
    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        Registrar()
        If lblMensaje.Text = "Registro exitoso" Then

            lblMensaje.Text = ""
            LimpiarFormulario()
            pnlFormulario.Visible = False
        End If
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGrid()
    End Sub
    Private Sub BindGridDetalle(ByVal Numero As String)
        Dim objDetalle As New ALVI_LOGIC.Maestros.Ventas.Factura

        objDetalle.NumeroDocumento = Numero
        objDetalle.ObtenerAtributos()

        Session("dtbAtributos") = objDetalle.DatosArticulos
        grdArticulo.DataSource = Session("dtbAtributos")
        grdArticulo.DataBind()
    End Sub
    Private Sub BindGridOrdenServicio(ByVal Numero As String)
        Dim objDetalle As New ALVI_LOGIC.Maestros.Ventas.Factura

        objDetalle.NumeroDocumento = Numero
        If objDetalle.ObtenerOrdenServicio() Then
            Session("dtbOrdenServicio") = objDetalle.DatosOrdenServicio
            grdOrdenServicios.DataSource = Session("dtbOrdenServicio")
            grdOrdenServicios.DataBind()
        End If

    End Sub
    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAgregar.Click
        Dim objImpuesto As New ALVI_LOGIC.Maestros.Produccion.Impuesto
        Dim dtbArticulos As Data.DataTable
        Dim CostoUnitario As Double = CDbl(txtCostoUnitario.Text)
        Dim Cantidad As Double = CDbl(txtCantidad.Text)
        Dim Descuento As Double = 0
        objImpuesto.ObtenerImpuesto1()
        Dim IGV As Double = (CDbl(objImpuesto.Impuesto1) / 100).ToString
        If txtDesc.Text <> "" Then
            Descuento = CDbl(txtDesc.Text)
        Else
            Descuento = 0
        End If
        Dim Importe As Double
        dtbArticulos = CType(Session("dtbAtributos"), Data.DataTable)
        If ctlArticulo1.IdArticulo <> "" AndAlso ctlArticulo1.Descripcion <> "" AndAlso txtCantidad.Text <> "" Then
            Dim dtrNuevoArticulo As Data.DataRow = dtbArticulos.NewRow
            Dim intSecuencia As Int16 = 0
            If dtbArticulos.Rows.Count > 0 Then
                intSecuencia = -1
                For Each dtrItem As Data.DataRow In dtbArticulos.Select("var_CodArticulo='" & ctlArticulo1.IdArticulo.ToString & "' AND var_DesArticulo ='" & ctlArticulo1.Descripcion.ToString & "'")
                    intSecuencia = dtrItem("int_Secuencia")
                Next
                If intSecuencia = -1 Then
                    intSecuencia = dtbArticulos.Compute("Max(int_Secuencia)", "") + 1
                End If
            End If

            dtrNuevoArticulo("int_Secuencia") = intSecuencia
            dtrNuevoArticulo("var_CodArticulo") = ctlArticulo1.IdArticulo.ToString
            dtrNuevoArticulo("var_DesArticulo") = ctlArticulo1.Descripcion.ToString
            dtrNuevoArticulo("var_Unidad") = ctlArticulo1.NombreMetrica.ToString
            dtrNuevoArticulo("num_Cantidad") = txtCantidad.Text
            dtrNuevoArticulo("dtm_FechaInicio") = txtInicioServicio.Text
            dtrNuevoArticulo("dtm_FechaFinal") = txtFinalServicio.Text

            dtrNuevoArticulo("var_DesServicio") = txtDesServicio.Text
            dtrNuevoArticulo("var_Descuento") = Descuento.ToString
            If ddlTipoPago.SelectedValue = 0 Then
                dtrNuevoArticulo("num_CostoUnitario") = txtCostoUnitario.Text
                CostoUnitario = txtCostoUnitario.Text
            ElseIf ddlTipoPago.SelectedValue = 1 Then
                dtrNuevoArticulo("num_CostoUnitario") = CDbl(txtCostoUnitario.Text) / (1 + IGV)
                dtrNuevoArticulo("num_CostoUnitarioR") = Math.Round(CDbl(txtCostoUnitario.Text) / (1 + IGV), 2)
                CostoUnitario = CDbl(txtCostoUnitario.Text) / (1 + IGV)
            End If

            Importe = CostoUnitario * Cantidad
            If Descuento <> 0 Then
                Importe = (CostoUnitario * Cantidad) - ((CostoUnitario * Cantidad) * Descuento / 100)
            End If
            dtrNuevoArticulo("num_Importe") = Importe
            dtbArticulos.LoadDataRow(dtrNuevoArticulo.ItemArray, True)
            dtbArticulos.AcceptChanges()
            grdArticulo.DataSource = dtbArticulos
            grdArticulo.DataBind()

            Session("dtbAtributos") = dtbArticulos
            txtCantidad.Text = ""
            txtFechaInicio.Text = Format(Now, "dd/MM/yyyy")
            txtFechaFin.Text = Format(Now, "dd/MM/yyyy")
            txtCostoUnitario.Text = ""
            txtDesServicio.Text = ""
            txtDesc.Text = ""

            ctlArticulo1.Limpia()
            ctlArticulo1.Focus()
        End If
    End Sub
    Private Sub Totales()
        Dim dtbArticulos As Data.DataTable
        Dim objImpuesto As New ALVI_LOGIC.Maestros.Produccion.Impuesto
        dtbArticulos = CType(Session("dtbAtributos"), Data.DataTable)
        Dim Parcial As String = 0
        Dim Desc As String = 0
        Dim SumCantidades As String = 0
        Dim SubTotal As String = 0
        Dim ImporteSinDescuento As String = 0
        objImpuesto.ObtenerImpuesto1()
        Dim IGV As String = (CDbl(objImpuesto.Impuesto1) / 100).ToString
        Dim Total As String = 0
        Dim objComprobante As New ALVI_LOGIC.Maestros.Ventas.Factura
        If dtbArticulos.Rows.Count > 0 AndAlso objComprobante.IGV > 0 AndAlso objComprobante.Total > 0 AndAlso objComprobante.SubTotal > 0 AndAlso objComprobante.TotalParcial > 0 Then
            txtTotalParcial.Text = objComprobante.TotalParcial.ToString
            txtTotalDesc.Text = objComprobante.Descuento.ToString
            txtSubTotal.Text = objComprobante.SubTotal.ToString
            txtIGV.Text = objComprobante.IGV.ToString
            txtTotal.Text = objComprobante.Total.ToString
        ElseIf dtbArticulos.Rows.Count > 0 AndAlso objComprobante.IGV = 0 AndAlso objComprobante.Total = 0 AndAlso objComprobante.SubTotal = 0 AndAlso objComprobante.TotalParcial = 0 Then
            Dim columnas As Integer = dtbArticulos.Rows.Count

            For Each itmAtributoTela As Data.DataRow In dtbArticulos.Rows
                Desc = (itmAtributoTela("num_Cantidad") * itmAtributoTela("var_Descuento") * itmAtributoTela("num_CostoUnitario")) + Desc
            Next
            For Each itmAtributoTela As Data.DataRow In dtbArticulos.Rows
                ImporteSinDescuento = (itmAtributoTela("num_Cantidad") * itmAtributoTela("num_CostoUnitario")) + ImporteSinDescuento
            Next
            For Each itmAtributoTela As Data.DataRow In dtbArticulos.Rows
                Parcial = (itmAtributoTela("num_Cantidad") * itmAtributoTela("num_CostoUnitario")) + Parcial
            Next

            Desc = Desc / ImporteSinDescuento
            SubTotal = Parcial - (Parcial * (Desc / 100))
            Total = (SubTotal * IGV) + SubTotal
            txtTotalParcial.Text = Format(CDbl(Parcial), "#,###,##0.00")
            txtTotalDesc.Text = Math.Round(CDbl(Desc), 2).ToString + " %"
            txtSubTotal.Text = Format(CDbl(SubTotal), "#,###,##0.00")
            txtIGV.Text = Format(CDbl(CDbl(Total) - (CDbl(Total) / (1 + IGV))), "#,###,##0.00")
            txtTotal.Text = Format(CDbl(Total), "#,###,##0.00")
        Else
            txtTotalParcial.Text = ""
            txtTotalDesc.Text = ""
            txtSubTotal.Text = ""
            txtIGV.Text = ""
            txtTotal.Text = ""
        End If
    End Sub
    Protected Sub grdArticulo_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdArticulo.RowCreated
        Totales()
        If grdArticulo.Rows.Count = 0 Then
            ddlTipoPago.Enabled = True
        Else
            ddlTipoPago.Enabled = False
        End If
    End Sub
    Protected Sub grdArticulo_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdArticulo.RowDeleting
        Dim dtbArticulos As Data.DataTable = CType(Session("dtbAtributos"), Data.DataTable)
        Dim dtbTemporal As Data.DataTable = dtbArticulos.Clone
        Dim strIndice As String = grdArticulo.Rows(e.RowIndex).Cells(0).Text

        For Each itmAtributoTela As Data.DataRow In dtbArticulos.Rows
            If itmAtributoTela("int_Secuencia") <> strIndice Then
                dtbTemporal.LoadDataRow(itmAtributoTela.ItemArray, True)
                dtbTemporal.AcceptChanges()
            End If
        Next
        Session("dtbAtributos") = dtbTemporal
        grdArticulo.DataSource = dtbTemporal
        Totales()
        grdArticulo.DataBind()
        If grdArticulo.Rows.Count = 0 Then
            ddlTipoPago.Enabled = True
        Else
            ddlTipoPago.Enabled = False
        End If
    End Sub
    Protected Sub rbtProducto_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtProducto.CheckedChanged
        rbtServicio.Checked = False
    End Sub
    Protected Sub rbtServicio_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtServicio.CheckedChanged
        rbtProducto.Checked = False
    End Sub
    Protected Sub ctlCajaBanco_Cerrado() Handles ctlCajaBanco.Cerrado
        pnlCajaBanco.Visible = False
        BindGrid()
    End Sub
    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(5).Text = "ANULADO" Then
                Dim btnCajaBanco As Button = CType(e.Row.FindControl("btnCajaBanco"), Button)
                btnCajaBanco.Visible = False
                e.Row.Cells(5).ForeColor = Drawing.Color.Red
            End If
            If e.Row.Cells(5).Text = "PAGADO" Then
                Dim btnCajaBanco As Button = CType(e.Row.FindControl("btnCajaBanco"), Button)
                btnCajaBanco.Visible = False

            End If
        End If
    End Sub
    Protected Sub ctlCliente_Registro_Cancelar() Handles ctlCliente_Registro.Cancelar
        pnlClienteRegistro.Visible = False
        BindGrid()
    End Sub
    Protected Sub btnAgregarCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarCliente.Click
        pnlClienteRegistro.Visible = True
    End Sub
    Protected Sub ctlCliente2_AgregarCliente() Handles ctlCliente2.AgregarCliente
        pnlClienteRegistro.Visible = True
    End Sub
    Public Function RegistrarOrdenServicio() As Boolean
        Dim objImpuesto As New ALVI_LOGIC.Maestros.Produccion.Impuesto
        Dim dtbOrdenServicio As Data.DataTable
        Dim _bolValidar As Boolean = False

        dtbOrdenServicio = CType(Session("dtbOrdenServicio"), Data.DataTable)
        If ctlOrdenServicio_Buscar.IdOrdenServicio.Text <> "" Then
            Dim dtrNuevoOrdenServ As Data.DataRow = dtbOrdenServicio.NewRow
            Dim intSecuencia As Int16 = 0
            If dtbOrdenServicio.Rows.Count > 0 Then
                intSecuencia = -1
                For Each dtrItem As Data.DataRow In dtbOrdenServicio.Select("var_IdOrdenServicio='" & ctlOrdenServicio_Buscar.IdOrdenServicio.Text & "'")
                    intSecuencia = dtrItem("int_Secuencia")
                Next
                If intSecuencia = -1 Then
                    intSecuencia = dtbOrdenServicio.Compute("Max(int_Secuencia)", "") + 1
                End If
            End If

            dtrNuevoOrdenServ("int_Secuencia") = intSecuencia
            dtrNuevoOrdenServ("int_NumeroComprobante") = txtCodigo.Text
            dtrNuevoOrdenServ("var_IdComprobante") = txtNumero.Text & txtCorrelativo.Text
            dtrNuevoOrdenServ("var_IdOrdenServicio") = ctlOrdenServicio_Buscar.IdOrdenServicio.Text.ToString.Trim()
            dtrNuevoOrdenServ("var_RazonSocial") = ctlOrdenServicio_Buscar.RazonSocial.ToString.Trim()
            dtrNuevoOrdenServ("num_Importe") = ctlOrdenServicio_Buscar.Importe.ToString.Trim()
            dtrNuevoOrdenServ("var_Usuario") = Session("Usuario").ToString.Trim()

            dtbOrdenServicio.LoadDataRow(dtrNuevoOrdenServ.ItemArray, True)
            dtbOrdenServicio.AcceptChanges()
            grdOrdenServicios.DataSource = dtbOrdenServicio
            grdOrdenServicios.DataBind()

            Session("dtbOrdenServicio") = dtbOrdenServicio
            ctlOrdenServicio_Buscar.Limpia()

            _bolValidar = True
        End If
        Return _bolValidar
    End Function
    Protected Sub btnTerminarOSR_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminarOSR.Click
        If RegistrarOrdenServicio() = True Then
            pnlRegistroOrdenServicio.Visible = False
        End If
    End Sub
    Protected Sub btnRegistrarOSR_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRegistrarOSR.Click
        RegistrarOrdenServicio()
    End Sub
    Protected Sub btnCancelarOSR_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelarOSR.Click
        pnlRegistroOrdenServicio.Visible = False
    End Sub
    Protected Sub btnAsignarOrdenServicio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAsignarOrdenServicio.Click
        pnlRegistroOrdenServicio.Visible = True
    End Sub
    Protected Sub grdOrdenServicios_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdOrdenServicios.RowCommand
        'If e.CommandName = "Eliminar" Then
        '    Dim dtbOrdenServicio = CType(Session("dtbOrdenServicio"), Data.DataTable)
        '    CreateSchemeOrdenServicio()
        '    Dim dtbOrdenServicioNuevo = CType(Session("dtbOrdenServicio"), Data.DataTable)

        '    For Each dtrItem As Data.DataRow In dtbOrdenServicio.Rows
        '        If dtrItem("") <> e.CommandArgument Then
        '            dtbOrdenServicioNuevo.AcceptChanges(dtrItem)
        '        End If
        '    Next
        'End If
    End Sub
    Protected Sub grdOrdenServicios_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdOrdenServicios.RowDeleting
        Dim dtbOrdenServicio As Data.DataTable = CType(Session("dtbOrdenServicio"), Data.DataTable)
        Dim dtbTemporal As Data.DataTable = dtbOrdenServicio.Clone
        Dim strIndice As String = grdOrdenServicios.Rows(e.RowIndex).Cells(0).Text

        For Each dtrItem As Data.DataRow In dtbOrdenServicio.Rows
            If dtrItem("int_Secuencia") <> strIndice Then
                dtbTemporal.LoadDataRow(dtrItem.ItemArray, True)
                dtbTemporal.AcceptChanges()
            End If
        Next

        Session("dtbOrdenServicio") = dtbTemporal
        grdOrdenServicios.DataSource = dtbTemporal
        grdOrdenServicios.DataBind()
    End Sub
End Class