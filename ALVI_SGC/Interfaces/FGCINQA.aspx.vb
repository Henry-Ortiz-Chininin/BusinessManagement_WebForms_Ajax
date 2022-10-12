
Partial Class Estandares_FGCINQA
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dtbAtributos As New Data.DataTable
            Dim dtbArticulos As New Data.DataTable
            pnlFormulario.Visible = False
            BindGrid()
            'btnFechaInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaInicio.ClientID & ", 'dd/mm/yyyy');")
            'btnFechaFin.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaFin.ClientID & ", 'dd/mm/yyyy');")
            'btnFechaEmision.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmision.ClientID & ", 'dd/mm/yyyy');")
            BinDepartamento(ddlDepartamento)
            BindAtributos(ddlMoneda)
            BindCuotas(ddlCredito)
            BindVendedor(ddlVendedor)
            txtFechaEmision.Text = Format(Now.Date, "dd/MM/yyyy")
            ddlCredito.Enabled = False
            rbtcontado.Checked = True
            rbtCredito.Checked = False
            rbtProducto.Checked = False
            rbtServicio.Checked = True
            CreateSchemaArticulos()
            txtCodigo.Enabled = False
            ddlTipoPago.Enabled = True
            FechaInicial()
            Horas()

        End If
    End Sub
    Private Sub FechaInicial()
        Dim dtmFechaFinal As New DateTime
        Dim intDia As Integer = 0
        Dim intMes As Integer = 0
        Dim intAnio As Integer = 0

        If txtFechaFin.Text <> "" Then
            dtmFechaFinal = CType(txtFechaFin.Text, DateTime)
            intDia = dtmFechaFinal.Day
            intMes = dtmFechaFinal.Month
            intAnio = dtmFechaFinal.Year

            Dim dtmF1 = New DateTime(intAnio, intMes, 1)
            Dim dtmF2 As DateTime = dtmF1.AddMonths(-1)
            txtFechaInicio.Text = Format(dtmF1, "dd/MM/yyyy")
        Else
            txtFechaFin.Text = Format(Now.Date, "dd/MM/yyyy")
            dtmFechaFinal = CType(txtFechaFin.Text, DateTime)
            intDia = dtmFechaFinal.Day
            intMes = dtmFechaFinal.Month
            intAnio = dtmFechaFinal.Year

            Dim dtmF1 = New DateTime(intAnio, intMes, 1)
            Dim dtmF2 As DateTime = dtmF1.AddMonths(-1)
            txtFechaInicio.Text = Format(dtmF1, "dd/MM/yyyy")
        End If
    End Sub
    Private Sub Horas()

        Dim dt As DateTime = DateTime.Parse("00:00 PM")
        Dim am_pm As MKB.TimePicker.TimeSelector.AmPmSpec
        If dt.ToString("tt") = "AM" Then
            am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM
        Else
            am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM
        End If
        'tisSalidaBase.SetTime(dt.Hour, dt.Minute, am_pm)
        tisLlegadaObra.SetTime(dt.Hour, dt.Minute, am_pm)
        tisInicioOperacion.SetTime(dt.Hour, dt.Minute, am_pm)
        tisTerminoOperacion.SetTime(dt.Hour, dt.Minute, am_pm)
        tisSalidaObra.SetTime(dt.Hour, dt.Minute, am_pm)
        tisLlegoBase.SetTime(dt.Hour, dt.Minute, am_pm)
    End Sub
    Private Sub BinDepartamento(pddlAtributo As DropDownList)
        Dim LN_Departamento As New LN_ALVINET_CONTA.GENERAL.LN_Departamento

        If LN_Departamento.Listar() = True Then
            pddlAtributo.Items.Clear()

            pddlAtributo.DataTextField = "NomDepartamento"
            pddlAtributo.DataValueField = "IdDepartamento"

            pddlAtributo.DataSource = LN_Departamento.lstDepartamento
            pddlAtributo.DataBind()
        End If

        'pddlAtributo.Items.Insert(0, New ListItem("Seleccionar", 0))
        pddlAtributo.ToolTip = "Seleccionar Departamento"
        pddlAtributo.SelectedValue = "1"

    End Sub
    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        txtCodigo.ReadOnly = True
        txtCodigo.MaxLength = 21
        pnlFormulario.Visible = True
        txtCodigo.Focus()
    End Sub
    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub
    Private Sub Cancelar()
        LimpiarFormulario()
        pnlFormulario.Visible = False
        BindGrid()
    End Sub
    Private Sub LimpiarFormulario()
        txtCodigo.Text = ""
        lblMensaje.Text = ""
        txtDesServicio.Text = ""
        txtFechaEmision.Text = ""
        txtAprobado.Text = ""
        ddlVendedor.SelectedIndex = 0
        ddlCredito.SelectedIndex = 0
        ddlTipoPago.SelectedIndex = 0
        txtCantidad.Text = ""
        txtImporte.Text = ""
        txtTiempoTotal.Text = ""
        ctlArticulo1.Limpia()
        ctlCliente2.Limpia()
        rbtCredito.Checked = False
        ddlCredito.Enabled = False
        CreateSchemaArticulos()
        Dim dtbAtributos As Data.DataTable = CType(Session("dtbAtributos"), Data.DataTable)
        Dim dtbArticulos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
        grdArticulo.DataSource = dtbArticulos
        grdArticulo.DataBind()
    End Sub
    Private Sub BindAtributos(ByRef pddlAtributos As DropDownList)
        Dim objAtributos As New ALVI_LOGIC.Maestros.Administracion.Moneda
        pddlAtributos.Items.Clear()
        If objAtributos.Listar() = True Then
            pddlAtributos.DataValueField = "var_IdMoneda"
            pddlAtributos.DataTextField = "var_DesMoneda"
            pddlAtributos.DataSource = objAtributos.Datos
            pddlAtributos.DataBind()
        End If
        'pddlAtributos.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlAtributos.SelectedIndex = 0
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
    Private Sub BindCuotas(ByRef pddlCuotas As DropDownList)
        Dim objValores As New ALVI_LOGIC.Maestros.Administracion.Cuotas
        pddlCuotas.Items.Clear()
        If objValores.Listar() = True Then
            pddlCuotas.DataValueField = "var_IdCuota"
            pddlCuotas.DataTextField = "var_Descripcion"
            pddlCuotas.DataSource = objValores.Datos
            pddlCuotas.DataBind()
        End If
        pddlCuotas.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlCuotas.SelectedIndex = 0
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
        Dim pkTelas(1) As Data.DataColumn
        pkTelas(0) = dtbArticulos.Columns("int_Secuencia")

        dtbArticulos.PrimaryKey = pkTelas
        Session("dtbArticulos") = dtbArticulos
    End Sub
    Private Sub BindGrid()
        Dim objArticulo As New ALVI_LOGIC.Maestros.Ventas.Pedido
        Dim dtbDatos As New Data.DataTable
        dtbDatos.Columns.Add("var_IdPedido", GetType(String))
        dtbDatos.Columns.Add("var_IdCliente", GetType(String))
        dtbDatos.Columns.Add("dtm_FechaEmision", GetType(String))
        dtbDatos.Columns.Add("var_Aprobado", GetType(String))
        dtbDatos.Columns.Add("var_Estado", GetType(String))
        dtbDatos.Columns.Add("var_TipoServicio", GetType(String))
        dtbDatos.Columns.Add("var_idVendedor", GetType(String))
        objArticulo.IdPedido = txtIdArticuloBusqueda.Text
        objArticulo.IdCliente = txtCliente.Text
        objArticulo.IdCliente = txtCliente.Text
        objArticulo.FechaIngreso = txtFechaInicio.Text
        objArticulo.FechaEntrega = txtFechaFin.Text
        objArticulo.Buscar()
        Try
            For Each dtrItem As Data.DataRow In objArticulo.Datos.Rows
                Dim dtrNuevo As Data.DataRow = dtbDatos.NewRow
                Dim FechaIngreso As DateTime
                dtrNuevo("var_IdPedido") = dtrItem("var_IdPedido")
                dtrNuevo("var_IdCliente") = dtrItem("var_IdCliente")
                FechaIngreso = CDate(dtrItem("dtm_FechaEmision"))
                dtrNuevo("dtm_FechaEmision") = Format(FechaIngreso, "dd/MM/yyyy")
                dtrNuevo("var_Aprobado") = dtrItem("var_Aprobado")
                dtrNuevo("var_Estado") = dtrItem("var_Estado")
                dtrNuevo("var_TipoServicio") = dtrItem("var_TipoServicio")
                dtrNuevo("var_idVendedor") = dtrItem("var_idVendedor")
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
        txtCodigo.Focus()
    End Sub
    Private Sub Registrar()
        Dim dtbAtributos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
        Dim dtbRAtributos As New Data.DataTable
        dtbRAtributos.Columns.Add("int_Secuencia")
        dtbRAtributos.Columns.Add("var_CodArticulo")
        dtbRAtributos.Columns.Add("num_Cantidad")
        dtbRAtributos.Columns.Add("num_Rollos")
        dtbRAtributos.Columns.Add("num_Importe")
        dtbRAtributos.Columns.Add("var_DesServicio")

        Dim dtbAtributo As New GridView
        dtbAtributo.DataSource = CType(Session("dtbAtributos"), Data.DataTable)
        dtbAtributo.DataBind()
        For Each itmDocumento As GridViewRow In dtbAtributo.Rows
            Dim dtrActual As Data.DataRow = dtbRAtributos.NewRow
            dtrActual("int_Secuencia") = itmDocumento.Cells(0).Text
            dtrActual("var_CodArticulo") = itmDocumento.Cells(1).Text
            dtrActual("num_Cantidad") = itmDocumento.Cells(4).Text
            dtrActual("num_Rollos") = itmDocumento.Cells(5).Text
            dtrActual("num_Importe") = itmDocumento.Cells(6).Text
            dtrActual("var_DesServicio") = itmDocumento.Cells(7).Text
            dtbRAtributos.LoadDataRow(dtrActual.ItemArray, True)
            dtbRAtributos.AcceptChanges()
        Next
        If txtFechaEmision.Text <> "" AndAlso ctlCliente2.RazonSocial <> "" AndAlso ddlMoneda.SelectedValue <> "" _
             AndAlso grdArticulo.Rows.Count > 0 Then
            Dim objPartida As New ALVI_LOGIC.Maestros.Ventas.Pedido
            objPartida.idArticulo = txtCodigo.Text
            objPartida.IdCliente = ctlCliente2.IdCliente.ToString
            objPartida.idVendedor = ddlVendedor.SelectedValue.ToString
            objPartida.idMoneda = ddlMoneda.SelectedValue
            objPartida.IdPedido = txtCodigo.Text
            If rbtServicio.Checked Then
                objPartida.IdServicio = "S"
            Else
                objPartida.IdServicio = "P"
            End If
            objPartida.FechaEmision = txtFechaEmision.Text
            objPartida.EstadoPedido = ddlEstado.SelectedValue
            objPartida.IdAprobacion = txtAprobado.Text
            objPartida.TipoPago = ddlTipoPago.SelectedValue
            If rbtcontado.Checked Then
                objPartida.Formapago = "CN"
                objPartida.Cuotas = ""
            Else
                objPartida.Formapago = "CR"
                objPartida.Cuotas = ddlCredito.SelectedValue.ToString
            End If
            objPartida.Usuario = Session("Usuario")
            objPartida.Estado = ddlEstado.SelectedValue
            objPartida.Observacion = txtDesServicio.Text
            objPartida.TipoCambio = CDbl(Master.TipoCambio)
            If objPartida.Registrar(dtbAtributos) = True Then
                LimpiarFormulario()
                lblMensaje.Text = "Registro exitoso"
                dtbAtributos.Rows.Clear()
                BindGrid()
                grdDatos.EditIndex = -1
            Else
                lblMensaje.Text = "Datos Incorrectos"
            End If
        Else
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Faltan Datos.');</script>")
        End If
    End Sub
    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCerrar.Click
        Response.Redirect("default.aspx")
    End Sub
    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub
    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then
            Dim objArticulo As New ALVI_LOGIC.Maestros.Ventas.Pedido
            objArticulo.IdPedido = e.CommandArgument.ToString
            If objArticulo.Obtener = True Then
                LimpiarFormulario() 
                txtCodigo.Text = objArticulo.IdPedido
                ddlVendedor.SelectedValue = objArticulo.idVendedor
                ctlCliente2.IdCliente = objArticulo.IdCliente
                ctlCliente2.RazonSocial = objArticulo.Cliente
                txtFechaEmision.Text = objArticulo.FechaEmision
                ddlEstado.SelectedValue = objArticulo.Estado
                txtAprobado.Text = objArticulo.IdAprobacion
                ddlTipoPago.SelectedValue = objArticulo.TipoPago
                If objArticulo.Formapago = "CN" Then
                    rbtcontado.Checked = True
                    rbtCredito.Checked = False
                    ddlCredito.Enabled = False
                Else
                    rbtcontado.Checked = False
                    rbtCredito.Checked = True
                    ddlCredito.SelectedValue = objArticulo.Cuotas
                    ddlCredito.Enabled = True
                End If
                txtDesServicio.Text = objArticulo.Observacion
                BindGridDetalle(e.CommandArgument)
                txtCodigo.ReadOnly = True
                txtCodigo.MaxLength = 20
                pnlFormulario.Visible = True
            End If
        End If
        If e.CommandName = "Eliminar" Then
            Dim objArticulo As New ALVI_LOGIC.Maestros.Ventas.Pedido
            Dim strParametros As String = e.CommandArgument.ToString
            objArticulo.IdPedido = e.CommandArgument.ToString
            If objArticulo.Eliminar = True Then
                BindGrid()
            Else
                ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('No se Pudo eliminar el Pedido.');</script>")
                BindGrid()
            End If
        End If
    End Sub
    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTerminar.Click
        Registrar()
        Cancelar()
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindGrid()
    End Sub
    Private Sub BindGridDetalle(ByVal Pedido As String)
        CreateSchemaArticulos()
        Dim objAtributo As New ALVI_LOGIC.Maestros.Ventas.Pedido
        objAtributo.IdPedido = Pedido
        objAtributo.ObtenerAtributos()
        grdArticulo.DataSource = objAtributo.DatosArticulos
        Session("dtbArticulos") = grdArticulo.DataSource
        grdArticulo.DataBind()

    End Sub
    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound

    End Sub
    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAgregar.Click
        Dim objImpuesto As New ALVI_LOGIC.Maestros.Produccion.Impuesto
        Dim dtbArticulos As Data.DataTable
        dtbArticulos = CType(Session("dtbArticulos"), Data.DataTable)
        If ctlArticulo1.IdArticulo <> "" AndAlso ctlArticulo1.Descripcion <> "" AndAlso txtCantidad.Text <> "" AndAlso txtTiempoTotal.Text <> "" AndAlso txtDesServicio.Text <> "" Then
            Dim dtrNuevoArticulo As Data.DataRow = dtbArticulos.NewRow
            Dim intSecuencia As Int16 = 0
            objImpuesto.ObtenerImpuesto1()
            Dim IGV As Double = (CDbl(objImpuesto.Impuesto1) / 100).ToString
            If dtbArticulos.Rows.Count > 0 Then
                intSecuencia = -1
                For Each dtrItem As Data.DataRow In dtbArticulos.Select("var_CodArticulo='" & ctlArticulo1.IdArticulo.ToString & "'")
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
            dtrNuevoArticulo("num_Rollos") = txtTiempoTotal.Text
            If ddlTipoPago.SelectedValue = 0 Then
                dtrNuevoArticulo("num_Importe") = txtImporte.Text
            ElseIf ddlTipoPago.SelectedValue = 1 Then
                dtrNuevoArticulo("num_Importe") = Math.Round(CDbl(txtImporte.Text) / (1 + IGV), 2)
            End If
            dtrNuevoArticulo("var_DesServicio") = txtDesServicio.Text
            dtbArticulos.LoadDataRow(dtrNuevoArticulo.ItemArray, True)
            dtbArticulos.AcceptChanges()
            Session("dtbArticulos") = dtbArticulos
            grdArticulo.DataSource = dtbArticulos
            grdArticulo.DataBind()
            txtCantidad.Text = ""
            txtTiempoTotal.Text = ""
            txtImporte.Text = ""
            txtDesServicio.Text = ""

            ctlArticulo1.Limpia()
            ctlArticulo1.Focus()
        End If
    End Sub
    Protected Sub grdArticulo_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdArticulo.RowCreated
        If grdArticulo.Rows.Count = 0 Then
            ddlTipoPago.Enabled = True
        Else
            ddlTipoPago.Enabled = False
        End If
    End Sub
    Protected Sub grdArticulo_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdArticulo.RowDeleting
        Dim dtbArticulos As Data.DataTable = CType(Session("dtbArticulos"), Data.DataTable)
        Dim dtbTemporal As Data.DataTable = dtbArticulos.Clone
        Dim strIndice As String = grdArticulo.Rows(e.RowIndex).Cells(0).Text
        For Each itmAtributoTela As Data.DataRow In dtbArticulos.Rows
            If itmAtributoTela("int_Secuencia") <> strIndice Then
                dtbTemporal.LoadDataRow(itmAtributoTela.ItemArray, True)
                dtbTemporal.AcceptChanges()
            End If
        Next
        Session("dtbArticulos") = dtbTemporal
        grdArticulo.DataSource = dtbTemporal
        grdArticulo.DataBind()
        If grdArticulo.Rows.Count = 0 Then
            ddlTipoPago.Enabled = True
        Else
            ddlTipoPago.Enabled = False
        End If
    End Sub
    Protected Sub rbtcontado_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtcontado.CheckedChanged
        rbtCredito.Checked = False
        ddlCredito.Enabled = False
    End Sub
    Protected Sub rbtCredito_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtCredito.CheckedChanged
        rbtcontado.Checked = False
        ddlCredito.Enabled = True
    End Sub
    Protected Sub rbtProducto_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtProducto.CheckedChanged
        rbtServicio.Checked = False
    End Sub
    Protected Sub rbtServicio_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtServicio.CheckedChanged
        rbtProducto.Checked = False
    End Sub
    Private Sub CalcularTiempos()
        Dim intSegundos As Integer = 0
        Dim intSegundosTotal As Integer = 0
        Dim intMinutos As Integer = 0
        Dim intHoras As Integer = 0
        Dim intSegundosIni As Integer = 0
        Dim intSegundosFin As Integer = 0


        '--->> Calcular Tiempo Recorrido ----------------------------------------------------------------------------------------------------
        '--->>  Salida de Obra - Salida de Base ------------------------------------------------------- 
        'intSegundosIni = tisSalidaBase.Minute * 60 + tisSalidaBase.Hour * 3600
        intSegundosFin = tisLlegadaObra.Minute * 60 + tisLlegadaObra.Hour * 3600

        intSegundos = intSegundosFin - intSegundosIni

        '--->>  Salida de Obra - Llegada a Base ------------------------------------------------------- 
        intSegundosIni = tisSalidaObra.Minute * 60 + tisSalidaObra.Hour * 3600
        intSegundosFin = tisLlegoBase.Minute * 60 + tisLlegoBase.Hour * 3600

        intSegundos += intSegundosFin - intSegundosIni
        intSegundosTotal = intSegundos
        '--->> Convertir a horas y minutos

        If (intSegundos Mod 3600) < intSegundos Then
            intHoras += Int(CDec((intSegundos / 3600)))
        End If

        If (intSegundos Mod 3600) > 59 Then
            intMinutos += (intSegundos Mod 3600) / 60
        End If

        '--->> Mostrar En el Text Box -> txtTiempoRecorrido---------------------------------------------
        If intHoras > 1 Then
            If intMinutos > 1 Then
                txtTiempoRecorrido.Text = intHoras & " Horas y " & intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoRecorrido.Text = intHoras & " Horas"
            Else
                txtTiempoRecorrido.Text = intHoras & " Horas y " & intMinutos & " Minuto"
            End If
        ElseIf intHoras = 0 Then
            If intMinutos > 1 Then
                txtTiempoRecorrido.Text = intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoRecorrido.Text = ""
            Else
                txtTiempoRecorrido.Text = intMinutos & " Minuto"
            End If
        Else
            If intMinutos > 1 Then
                txtTiempoRecorrido.Text = intHoras & " Hora y " & intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoRecorrido.Text = intHoras & " Hora"
            Else
                txtTiempoRecorrido.Text = intHoras & " Hora y " & intMinutos & " Minuto"
            End If
        End If

        intSegundos = 0
        intHoras = 0
        intMinutos = 0
        intSegundosIni = 0
        intSegundosIni = 0

        '--->> Tiempo de Operacion-----------------------------------------------------------------------------------------------------------
        '--->>  Termino de Operación - Inicio de Operación------------------------------------------------------- 
        intSegundosIni = tisInicioOperacion.Minute * 60 + tisInicioOperacion.Hour * 3600
        intSegundosFin = tisTerminoOperacion.Minute * 60 + tisTerminoOperacion.Hour * 3600

        intSegundos = intSegundosFin - intSegundosIni
        intSegundosTotal += intSegundos
        '--->> Convertir a horas y minutos

        If (intSegundos Mod 3600) < intSegundos Then
            intHoras = Int(CDec((intSegundos / 3600)))
        End If

        If (intSegundos Mod 3600) > 59 Then
            intMinutos = (intSegundos Mod 3600) / 60
        End If

        '--->> Mostrar En el Text Box -> txtTiempoTrabajo---------------------------------------------
        If intHoras > 1 Then
            If intMinutos > 1 Then
                txtTiempoTrabajo.Text = intHoras & " Horas y " & intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoTrabajo.Text = intHoras & " Horas"
            Else
                txtTiempoTrabajo.Text = intHoras & " Horas y " & intMinutos & " Minuto"
            End If
        ElseIf intHoras = 0 Then
            If intMinutos > 1 Then
                txtTiempoTrabajo.Text = intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoTrabajo.Text = ""
            Else
                txtTiempoTrabajo.Text = intMinutos & " Minuto"
            End If
        Else
            If intMinutos > 1 Then
                txtTiempoTrabajo.Text = intHoras & " Hora y " & intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoTrabajo.Text = intHoras & " Hora"
            Else
                txtTiempoTrabajo.Text = intHoras & " Hora y " & intMinutos & " Minuto"
            End If
        End If

        intSegundos = 0
        intHoras = 0
        intMinutos = 0
        '--->> Tiempo de Total-----------------------------------------------------------------------------------------------------------
        '--->> Convertir a horas y minutos

        If (intSegundosTotal Mod 3600) < intSegundosTotal Then
            intHoras = Int(CDec((intSegundosTotal / 3600)))
        End If

        If (intSegundosTotal Mod 3600) > 59 Then
            intMinutos = (intSegundosTotal Mod 3600) / 60
        End If

        '--->> Mostrar En el Text Box -> txtTiempoTotal---------------------------------------------
        If intHoras > 1 Then
            If intMinutos > 1 Then
                txtTiempoTotal.Text = intHoras & " Horas y " & intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoTotal.Text = intHoras & " Horas"
            Else
                txtTiempoTotal.Text = intHoras & " Horas y " & intMinutos & " Minuto"
            End If
        ElseIf intHoras = 0 Then
            If intMinutos > 1 Then
                txtTiempoTotal.Text = intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoTotal.Text = ""
            Else
                txtTiempoTotal.Text = intMinutos & " Minuto"
            End If
        Else
            If intMinutos > 1 Then
                txtTiempoTotal.Text = intHoras & " Hora y " & intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoTotal.Text = intHoras & " Hora"
            Else
                txtTiempoTotal.Text = intHoras & " Hora y " & intMinutos & " Minuto"
            End If
        End If
        '--->> Calcular Total a Pagar
        If txtTarifa.Text.ToString() <> "" Then

            txtImporte.Text = Format((intHoras * txtTarifa.Text) + ((intMinutos / 60) * txtTarifa.Text), "#,##0.0000")
        End If
    End Sub
    Protected Sub btnCalcularTiempo_Click(sender As Object, e As System.EventArgs) Handles btnCalcularTiempo.Click
        CalcularTiempos()
    End Sub
End Class
