Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAG
    Inherits System.Web.UI.Page

    Public Sub bindGrid()
        Dim objLNPlanCuenta As New LN_PlanCuenta
        Dim _entPlanCuenta As New EN_PlanCuenta

        _entPlanCuenta.IdEmpresa = hdnEmpresa.Value
        _entPlanCuenta.IdUsuario = hdnusuario.Value
        _entPlanCuenta.Nombre = RTrim(txtNombre.Text.Trim)
        _entPlanCuenta.IdCuentaContable = RTrim(txtCuenta.Text.Trim)
        objLNPlanCuenta.entPlanCuenta = _entPlanCuenta

        objLNPlanCuenta.Listar()
        grdDatos.DataSource = objLNPlanCuenta.lstPlanCuentas
        grdDatos.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            pnlPlanCuenta.Visible = False
            hdnusuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")

            bindGrid()
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        pnlPlanCuenta.Visible = False
        bindGrid()
    End Sub


    Protected Sub ctlPlanCuenta_cargarGrilla() Handles ctlPlanCuenta.cargarGrilla
        bindGrid()
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand

        If e.CommandName = "MODIFICAR" Then

            pnlPlanCuenta.Visible = True

            Dim objENPlanCuenta As New EN_PlanCuenta
            Dim buton As Button = CType(e.CommandSource, Button)

            Dim dgrFila As GridViewRow = CType(buton.NamingContainer, GridViewRow)
            If HttpUtility.HtmlDecode(dgrFila.Cells(1).Text).Trim <> "" Then
                objENPlanCuenta.IdCuentaContable = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)

            End If


            If HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim <> "" Then
                objENPlanCuenta.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(2).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(3).Text).Trim <> "" Then
                objENPlanCuenta.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(3).Text)
            End If
            ctlPlanCuenta.llenarComboContabilidad(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim)
            ctlPlanCuenta.llenarComboCuentaEntidad(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim)
            ctlPlanCuenta.llenarComboEntidadFinanciera(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim)
            ctlPlanCuenta.llenarComboMoneda(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim)
            ctlPlanCuenta.llenarComboNivelPlan(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim)
            ctlPlanCuenta.llenarComboTipoAnalisis(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim)
            ctlPlanCuenta.llenarComboTipoCuenta(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim)

            If HttpUtility.HtmlDecode(dgrFila.Cells(4).Text).Trim <> "" Then
                objENPlanCuenta.IdContabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(4).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(5).Text).Trim <> "" Then
                objENPlanCuenta.IdContabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(5).Text)
                ' ctlPlanCuenta.llenarComboPlanContable(HttpUtility.HtmlDecode(dgrFila.Cells(3).Text))
            End If

            ctlPlanCuenta.llenarComboEntidadFinanciera(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text))
            '            ctlPlanCuenta.llenarComboPlanContable(HttpUtility.HtmlDecode(dgrFila.Cells(1).Text))

            If HttpUtility.HtmlDecode(dgrFila.Cells(6).Text).Trim <> "" Then
                objENPlanCuenta.IdPlanContable = HttpUtility.HtmlDecode(dgrFila.Cells(6).Text)
                'ctlPlanCuenta.llenarComboPlanContable(HttpUtility.HtmlDecode(dgrFila.Cells(5).Text))
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(7).Text).Trim <> "" Then
                objENPlanCuenta.IdPlanContable = HttpUtility.HtmlDecode(dgrFila.Cells(7).Text)

            End If
            Dim _strPlanCuenta As String = RTrim(HttpUtility.HtmlDecode(dgrFila.Cells(8).Text).Trim)
            If _strPlanCuenta <> "" Then
                objENPlanCuenta.Nombre = HttpUtility.HtmlDecode(dgrFila.Cells(8).Text)
            End If
            ctlPlanCuenta.llenarComboNivelPlan(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text))

            If HttpUtility.HtmlDecode(dgrFila.Cells(9).Text).Trim <> "" Then
                objENPlanCuenta.IdNivel = HttpUtility.HtmlDecode(dgrFila.Cells(9).Text)
                'ctlPlanCuenta.llenarComboNivelPlan(HttpUtility.HtmlDecode(dgrFila.Cells(8).Text))
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(10).Text).Trim <> "" Then
                objENPlanCuenta.IdNivel = HttpUtility.HtmlDecode(dgrFila.Cells(10).Text)
            End If
            Dim strTipoAnalisis As String = ""
            strTipoAnalisis = HttpUtility.HtmlDecode(dgrFila.Cells(11).Text).Trim
            If strTipoAnalisis = "" Then
            Else
                objENPlanCuenta.IdTipoAnalisis = HttpUtility.HtmlDecode(dgrFila.Cells(11).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(12).Text).Trim <> "" Then
                objENPlanCuenta.IdTipoAnalisis = HttpUtility.HtmlDecode(dgrFila.Cells(12).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(13).Text).Trim <> "" Then
                objENPlanCuenta.IdTipoCuenta = HttpUtility.HtmlDecode(dgrFila.Cells(13).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(14).Text).Trim <> "" Then
                objENPlanCuenta.IdTipoCuenta = HttpUtility.HtmlDecode(dgrFila.Cells(14).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(15).Text).Trim <> "" Then
                objENPlanCuenta.DiferenciaCambio = HttpUtility.HtmlDecode(dgrFila.Cells(15).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(16).Text).Trim <> "" Then
                objENPlanCuenta.ConversionMoneda = HttpUtility.HtmlDecode(dgrFila.Cells(16).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(17).Text).Trim <> "" Then
                objENPlanCuenta.IdEntidadFinanciera = HttpUtility.HtmlDecode(dgrFila.Cells(17).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(18).Text).Trim <> "" Then
                objENPlanCuenta.IdEntidadFinanciera = HttpUtility.HtmlDecode(dgrFila.Cells(18).Text)
            End If
            ctlPlanCuenta.llenarComboMoneda(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text))

            If HttpUtility.HtmlDecode(dgrFila.Cells(19).Text).Trim <> "" Then
                objENPlanCuenta.IdMoneda = HttpUtility.HtmlDecode(dgrFila.Cells(19).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(20).Text).Trim <> "" Then
                objENPlanCuenta.IdMoneda = HttpUtility.HtmlDecode(dgrFila.Cells(20).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(21).Text).Trim <> "" Then
                objENPlanCuenta.CuentaEntidad = HttpUtility.HtmlDecode(dgrFila.Cells(21).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(22).Text).Trim <> "" Then
                objENPlanCuenta.CuentaEntidad = HttpUtility.HtmlDecode(dgrFila.Cells(22).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(23).Text).Trim <> "" Then
                objENPlanCuenta.CuentaDebe = HttpUtility.HtmlDecode(dgrFila.Cells(23).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(24).Text).Trim <> "" Then
                objENPlanCuenta.CuentaHaber = HttpUtility.HtmlDecode(dgrFila.Cells(24).Text)
            End If
            If HttpUtility.HtmlDecode(dgrFila.Cells(25).Text).Trim <> "" Then
                objENPlanCuenta.IdCuentaPadre = HttpUtility.HtmlDecode(dgrFila.Cells(25).Text)
            End If


            ctlPlanCuenta.PlanCuenta = objENPlanCuenta

        ElseIf e.CommandName = "MODIFICAR2" Then
            For j = 0 To grdDatos.Rows.Count - 1
                Dim grdDatos2 As GridView = CType(grdDatos.Rows(j).FindControl("grdDatos2"), GridView)



                For i As Integer = 0 To grdDatos2.Rows.Count - 1

                    Dim boton As Button = CType(grdDatos2.Rows(i).FindControl("btnEditar2"), Button)

                    Dim objENPlanCuenta As New EN_PlanCuenta
                    Dim intIndice As Integer = grdDatos2.SelectedIndex

                    'CType(e.CommandSource, Button)
                    'Dim dgrFila As GridViewRow = CType(boton.NamingContainer, GridViewRow)
                    'Dim dgrFila As GridViewRow = grdDatos2.Rows(i)(boton.CommandArgument)

                    'If HttpUtility.HtmlDecode(dgrFila.Cells(1).Text).Trim <> "" Then
                    '    objENPlanCuenta.IdCuenta = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)

                    'End If


                    'If HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim <> "" Then
                    '    objENPlanCuenta.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(2).Text)
                    'End If
                    'If HttpUtility.HtmlDecode(dgrFila.Cells(3).Text).Trim <> "" Then
                    '    objENPlanCuenta.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(3).Text)
                    'End If
                    'ctlPlanCuenta.llenarComboContabilidad(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim)
                    'ctlPlanCuenta.llenarComboCuentaEntidad(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim)
                    'ctlPlanCuenta.llenarComboEntidadFinanciera(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim)
                    'ctlPlanCuenta.llenarComboMoneda(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim)
                    'ctlPlanCuenta.llenarComboNivelPlan(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim)
                    'ctlPlanCuenta.llenarComboTipoAnalisis(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim)
                    'ctlPlanCuenta.llenarComboTipoCuenta(HttpUtility.HtmlDecode(dgrFila.Cells(2).Text).Trim)
                Next
            Next


        ElseIf e.CommandName = "ELIMINAR" Then

            Dim objLNPlanCuenta As New LN_PlanCuenta
            Dim objENPlanCuenta As New EN_PlanCuenta

            Dim dgrFila As GridViewRow = grdDatos.Rows(e.CommandArgument)

            objENPlanCuenta.IdCuentaContable = HttpUtility.HtmlDecode(dgrFila.Cells(1).Text)
            objENPlanCuenta.IdEmpresa = HttpUtility.HtmlDecode(dgrFila.Cells(2).Text)
            objENPlanCuenta.IdContabilidad = HttpUtility.HtmlDecode(dgrFila.Cells(4).Text)
            objENPlanCuenta.IdPlanContable = HttpUtility.HtmlDecode(dgrFila.Cells(6).Text)

            objLNPlanCuenta.entPlanCuenta = objENPlanCuenta
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "Alerta", "<script languange='javascript'>confirm('Desea Eliminar..?')</script>")
            If objLNPlanCuenta.Eliminar = True Then
                bindGrid()
            Else
                Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERT", "<script language= 'javascript'>alert('NO SE LOGRO ELIMINAR')</script>")
            End If

        End If
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        pnlPlanCuenta.Visible = True
        ctlPlanCuenta.Limpiar()
        'ctlPlanCuenta.LlenarComboEmpresa()
        ctlPlanCuenta.llenarComboContabilidad(hdnEmpresa.Value)

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub ctlPlanCuenta_Cerrado() Handles ctlPlanCuenta.Cerrado
        pnlPlanCuenta.Visible = False
        bindGrid()
    End Sub

    Protected Sub ctlPlanCuenta_Registrado() Handles ctlPlanCuenta.Registrado
        bindGrid()
    End Sub

    Protected Sub grdDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnEliminar As Button = CType(e.Row.FindControl("btnEliminar"), Button)
            btnEliminar.Attributes.Add("onclick", "return confirm ('El Registro sera Eliminado');")


            'Dim cuenta As String = e.Row.DataItemIndex
            'Dim grdDatos2 As GridView = CType(e.Row.FindControl("grdDatos2"), GridView)



            'Dim objLNPlanCuenta As LN_PlanCuenta
            'Dim _entPlanCuenta As EN_PlanCuenta
            'hdnTipo.Value = Len(e.Row.Cells(1).Text) + 1
            'hdnNivel.Value = Left(e.Row.Cells(1).Text, 2)
            'objLNPlanCuenta = New LN_PlanCuenta
            '_entPlanCuenta = New EN_PlanCuenta
            '_entPlanCuenta.IdEmpresa = hdnEmpresa.Value
            '_entPlanCuenta.IdUsuario = hdnusuario.Value
            '_entPlanCuenta.Tipo = hdnTipo.Value
            '_entPlanCuenta.Nivel = hdnNivel.Value
            'objLNPlanCuenta.entPlanCuenta = _entPlanCuenta

            'objLNPlanCuenta.Listar()
            'grdDatos2.DataSource = objLNPlanCuenta.lstPlanCuentas
            'grdDatos2.DataBind()
            'Dim grdDatos3 As GridView
            'For i As Integer = 0 To grdDatos2.Rows.Count - 1
            '    grdDatos3 = CType(grdDatos2.Rows(i).FindControl("grdDatos3"), GridView)
            '    Dim strTipo4 As String = Len(grdDatos2.Rows(i).Cells(1).Text) + 1
            '    Dim strNivel3 As String = Left(grdDatos2.Rows(i).Cells(1).Text, 3)
            '    objLNPlanCuenta = New LN_PlanCuenta
            '    _entPlanCuenta = New EN_PlanCuenta
            '    '  grdDatos3 = New GridView
            '    _entPlanCuenta.IdEmpresa = hdnEmpresa.Value
            '    _entPlanCuenta.IdUsuario = hdnusuario.Value
            '    _entPlanCuenta.Tipo = strTipo4
            '    _entPlanCuenta.Nivel = strNivel3
            '    objLNPlanCuenta.entPlanCuenta = _entPlanCuenta
            '    objLNPlanCuenta.Listar()
            '    grdDatos3.DataSource = objLNPlanCuenta.lstPlanCuentas
            '    grdDatos3.DataBind()
            '    Dim grdDatos4 As GridView
            '    For j As Integer = 0 To grdDatos3.Rows.Count - 1
            '        grdDatos4 = grdDatos3.Rows(j).FindControl("grdDatos4")
            '        Dim strTipo5 As String = Len(grdDatos3.Rows(j).Cells(1).Text) + 1
            '        Dim strNivel4 As String = Left(grdDatos3.Rows(j).Cells(1).Text, 4)

            '        objLNPlanCuenta = New LN_PlanCuenta
            '        _entPlanCuenta = New EN_PlanCuenta
            '        '  grdDatos3 = New GridView
            '        _entPlanCuenta.IdEmpresa = hdnEmpresa.Value
            '        _entPlanCuenta.IdUsuario = hdnusuario.Value
            '        _entPlanCuenta.Tipo = strTipo5
            '        _entPlanCuenta.Nivel = strNivel4
            '        objLNPlanCuenta.entPlanCuenta = _entPlanCuenta
            '        objLNPlanCuenta.Listar()
            '        grdDatos4.DataSource = objLNPlanCuenta.lstPlanCuentas
            '        grdDatos4.DataBind()
            '    Next


            'Next





        End If
    End Sub

    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        bindGrid()
    End Sub
End Class
