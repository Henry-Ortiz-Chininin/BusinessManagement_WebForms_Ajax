Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAH
    Inherits System.Web.UI.Page
    Dim objSeguridad As New ALVI_Security.General
    Public Sub bindGrid()
        Dim objLNOperacionCuenta As New LN_OperacionCuenta
        Dim objSeguridad As New ALVI_Security.General
        Dim objENOperacionCuenta As New EN_OperacionesCuenta

        objENOperacionCuenta.IdEmpresa = hdnEmpresa.Value
        If Request.QueryString("strFlag") Is Nothing Then
        Else
            hdnFlag.Value = objSeguridad.Decrypta(Request.QueryString("strFlag"))
        End If

        'If Request.QueryString("ope") Is Nothing Then
        'Else
        '    lblOperacion.Text = objSeguridad.Decrypta(Request.QueryString("ope"))

        'End If

        If Request.QueryString("desc") Is Nothing Then
            lblOperacion.Text = ""

        Else
            lblOperacion.Text = objSeguridad.Decrypta(Request.QueryString("desc"))

        End If
        If Request.QueryString("flag") Is Nothing Then
        Else
            hdnBC.Value = objSeguridad.Decrypta(Request.QueryString("flag"))
        End If

        If Request.QueryString("desc1") Is Nothing Then
        Else
            lblSuboperacion.Text = objSeguridad.Decrypta(Request.QueryString("desc1"))
        End If
        If Request.QueryString("desc2") Is Nothing Then
        Else
            lblSubOperacionn.Text = objSeguridad.Decrypta(Request.QueryString("desc2"))
        End If
        If Request.QueryString("Id") Is Nothing Then
        Else
            hdnId.Value = objSeguridad.Decrypta(Request.QueryString("id"))
        End If


        If Request.QueryString("subOp") Is Nothing Then
            objENOperacionCuenta.IdSubOperacion = ""
        Else
            objENOperacionCuenta.IdSubOperacion = objSeguridad.Decrypta(Request.QueryString("subOp"))
        End If


        objLNOperacionCuenta.entOperacionCuenta = objENOperacionCuenta

        objLNOperacionCuenta.Listar()
        grdDatos.DataSource = objLNOperacionCuenta.lstOperacionCuenta
        grdDatos.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            If Request.QueryString("idOperacion") Is Nothing Then
            Else
                hdnIdOperacion.Value = objSeguridad.Decrypta(Request.QueryString("idOperacion"))
            End If
            If Request.QueryString("subOp") Is Nothing Then
                hdnIsSubop.Value = ""
            Else
                hdnIsSubop.Value = objSeguridad.Decrypta(Request.QueryString("subOp"))
            End If


            pnlOperacionCuenta.Visible = False
            If Request.QueryString("ope") Is Nothing Then
            Else
                hdnNomOperacion.Value = objSeguridad.Decrypta(Request.QueryString("ope"))
            End If


            bindGrid()
            Dim objENOperacionCuenta As New EN_OperacionesCuenta
            objENOperacionCuenta.TipoMovimiento = lblSuboperacion.Text & lblSubOperacionn.Text
            ctlOperacionCuenta.EnOperacionC = lblSuboperacion.Text & lblSubOperacionn.Text
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        'pnlOperacionCuenta.Visible = False
        'bindGrid()

        If hdnBC.Value = "1" Then
            Response.Redirect("FGCCOAS.aspx?subOp=" + objSeguridad.Encrypta(lblOperacion.Text) _
                              + "&desc=" + objSeguridad.Encrypta(lblOperacion.Text) _
                              + "&strFlag=" + objSeguridad.Encrypta(hdnFlag.Value) _
                              + "&idOperacion=" + objSeguridad.Encrypta(hdnIdOperacion.Value) _
                              + "&desc1=" + objSeguridad.Encrypta(lblSuboperacion.Text) + "&Id=" + objSeguridad.Encrypta(hdnId.Value) + "")
        Else
            Response.Redirect("FGCCOAQ.aspx?subOp=" + objSeguridad.Encrypta(lblOperacion.Text) + "&desc=" + objSeguridad.Encrypta(hdnNomOperacion.Value) + "&strFlag=" + objSeguridad.Encrypta(hdnFlag.Value) + "&idOperacion=" + objSeguridad.Encrypta(hdnIdOperacion.Value) + "")
        End If


    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand

        If e.CommandName = "MODIFICAR" Then

            pnlOperacionCuenta.Visible = True

            Dim objENOperacionCuenta As New EN_OperacionesCuenta

            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)

            objENOperacionCuenta.IdCuentaContable = HttpUtility.HtmlDecode(dgrFila.Cells(0).Text)
            objENOperacionCuenta.Nombre = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)
            ' ctlOperacionCuenta.llenarComboContabilidad(hdnEmpresa.Value)
            ctlOperacionCuenta.llenarComboOperacion(hdnEmpresa.Value)


            objENOperacionCuenta.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(2).Text)
            objENOperacionCuenta.RazonSocial = HttpUtility.HtmlDecode(dgrFila.Cells(3).Text)

            objENOperacionCuenta.IdOperacion = HttpUtility.HtmlDecode(dgrFila.Cells(4).Text)
            objENOperacionCuenta.Operacion = HttpUtility.HtmlDecode(dgrFila.Cells(5).Text)



            objENOperacionCuenta.Idcontabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(6).Text)
            objENOperacionCuenta.Contabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(7).Text)
            'ctlOperacionCuenta.llenarComboContabilidad(HttpUtility.HtmlDecode(dgrFila.Cells(6).Text).Trim)
            objENOperacionCuenta.EsCargo = HttpUtility.HtmlDecode(dgrFila.Cells(8).Text)
            objENOperacionCuenta.EsAbono = HttpUtility.HtmlDecode(dgrFila.Cells(9).Text)
            objENOperacionCuenta.EsObligatorio = HttpUtility.HtmlDecode(dgrFila.Cells(10).Text)
            objENOperacionCuenta.IdSubOperacion = HttpUtility.HtmlDecode(dgrFila.Cells(11).Text)
            ctlOperacionCuenta.llenarComboSubOperacion(HttpUtility.HtmlDecode(dgrFila.Cells(4).Text).Trim)
            objENOperacionCuenta.Nombre = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text).Trim
            objENOperacionCuenta.Observacion = HttpUtility.HtmlDecode(dgrFila.Cells(13).Text).Trim
            objENOperacionCuenta.IdOperacionCuenta = HttpUtility.HtmlDecode(dgrFila.Cells(14).Text)
            ctlOperacionCuenta.enOperacionCuenta = objENOperacionCuenta

        ElseIf e.CommandName = "ELIMINAR" Then

            Dim objLNOperacionCuenta As New LN_OperacionCuenta
            Dim objENOperacionCuenta As New EN_OperacionesCuenta

            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)

            objENOperacionCuenta.IdCuentaContable = HttpUtility.HtmlDecode(dgrFila.Cells(0).Text)
            objENOperacionCuenta.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(2).Text)
            objENOperacionCuenta.IdOperacion = HttpUtility.HtmlDecode(dgrFila.Cells(4).Text)
            objENOperacionCuenta.Idcontabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(6).Text)
            objENOperacionCuenta.IdSubOperacion = HttpUtility.HtmlDecode(dgrFila.Cells(11).Text)
            objLNOperacionCuenta.entOperacionCuenta = objENOperacionCuenta
            If objLNOperacionCuenta.Eliminar = True Then
                bindGrid()
            Else
                Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERT", "<script language= 'javascript'>alert('NO SE LOGRO ELIMINAR')</script>")
            End If

        End If

    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlOperacionCuenta.Visible = True
        Dim objENOperacionCuenta As New EN_OperacionesCuenta
        ctlOperacionCuenta.Limpiar()
        'ctlOperacionCuenta.LlenarComboEmpresa()
        objENOperacionCuenta.IdOperacion = hdnIdOperacion.Value
        objENOperacionCuenta.IdSubOperacion = hdnIsSubop.Value
        ctlOperacionCuenta.llenarComboOperacion(hdnEmpresa.Value)
        ctlOperacionCuenta.llenarComboSubOperacion(hdnIdOperacion.Value)

        ctlOperacionCuenta.enOperacionCuenta = objENOperacionCuenta
        objENOperacionCuenta.TipoMovimiento = lblSuboperacion.Text & lblSubOperacionn.Text
        ctlOperacionCuenta.EnOperacionC = lblSuboperacion.Text & lblSubOperacionn.Text


    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub ctlOperacionCuenta_cargarGrilla() Handles ctlOperacionCuenta.cargarGrilla
        bindGrid()
    End Sub

    Protected Sub ctlOperacionCuenta_Cerrado() Handles ctlOperacionCuenta.Cerrado
        pnlOperacionCuenta.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlOperacionCuenta_Registrado() Handles ctlOperacionCuenta.Registrado
        bindGrid()
    End Sub

    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As Button = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.Attributes.Add("onclick", "return confirm ('El Registro sera Eliminado');")
        End If
    End Sub

    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        bindGrid()
    End Sub
End Class
