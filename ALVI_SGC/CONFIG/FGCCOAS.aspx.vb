Imports LN_ALVINET_CONTA
Imports EN_ALVINET_CONTA
Imports LN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.GENERAL
Imports AD_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAS
    Inherits System.Web.UI.Page
    Private objSeguridad As New ALVI_Security.General
    Dim _objLNSubOperacion As New LN_SubOperacion
    Dim _entSubOperacion As New EN_SubOperacion
    Dim _objLNEmpresa As New LN_Empresa
    Dim _entEmpresa As New EN_Empresa
    Dim _objLNOperacion As New AD_Operacion
    Dim _entOperacion As New EN_Operacion

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            setParametros()
            hdnEmpresa.Value = Session("Empresa")
            BindEmpresa()
            BindOperacion(hdnEmpresa.Value)
            llenarComboEntidadFinanciera(hdnEmpresa.Value)
            llenarComboMoneda(hdnEmpresa.Value)
            bindGrid()
        End If

    End Sub

    Private Sub setParametros()
        pnlRegistroTipoCambio.Visible = False
        txtDescripcion.Focus()
        If Request.QueryString("Id") Is Nothing Then
        Else
            hdnId.Value = objSeguridad.Decrypta(Request.QueryString("Id"))
        End If

        If Request.QueryString("desc") Is Nothing Then
            lblOperacion.Text = ""
        Else
            hdnTitulo.Value = objSeguridad.Decrypta(Request.QueryString("desc"))
            lblOperacion.Text = hdnTitulo.Value

        End If
        If Request.QueryString("desc1") Is Nothing Then
        Else
            lblNivel1.Text = objSeguridad.Decrypta(Request.QueryString("desc1"))
        End If


        If Request.QueryString("IdEmpresa") Is Nothing Then

        Else
            hdnEmpresa.Value = objSeguridad.Decrypta(Request.QueryString("IdEmpresa"))
        End If




        If Request.QueryString("Operacion") Is Nothing Then

        Else
            hdnOperacion.Value = objSeguridad.Decrypta(Request.QueryString("Operacion"))
        End If

        If Request.QueryString("Tesoreria") Is Nothing Then

        Else

            'lblOperacion.Text = objSeguridad.Decrypta(Request.QueryString("Tesoreria"))
        End If
        If Request.QueryString("idOperacion") Is Nothing Then

        Else

            hdnIdOperacion.Value = objSeguridad.Decrypta(Request.QueryString("idOperacion"))
        End If

    End Sub
    Public Sub llenarComboMoneda(ByVal pstrEmpresa As String)

        Dim objLNMoneda As New LN_Moneda
        Dim objENMoneda As New EN_Moneda

        objENMoneda.IdEmpresa = pstrEmpresa
        objLNMoneda.entMoneda = objENMoneda
        ddlMoneda.Items.Clear()

        objLNMoneda.Listar()
        ddlMoneda.DataTextField = "Moneda"
        ddlMoneda.DataValueField = "IdMoneda"
        ddlMoneda.DataSource = objLNMoneda.lstMonedas
        ddlMoneda.DataBind()

        ddlMoneda.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlMoneda.SelectedIndex = 0

    End Sub
    Public Sub llenarComboEntidadFinanciera(ByVal pstrEmpresa As String)

        Dim objLNEntidadFinanciera As New LN_EntidadFinanciera
        Dim objENEntidadFinanciera As New EN_EntidadFinanciera

        objENEntidadFinanciera.IdEmpresa = pstrEmpresa
        objLNEntidadFinanciera.entEntidadFinanciera = objENEntidadFinanciera
        ddlEntidadFinanciera.Items.Clear()
        objLNEntidadFinanciera.Listar()
        ddlEntidadFinanciera.DataTextField = "NombreEntidad"
        ddlEntidadFinanciera.DataValueField = "IdEntidadFinanciera"
        ddlEntidadFinanciera.DataSource = objLNEntidadFinanciera.lstEntidadFinanciera
        ddlEntidadFinanciera.DataBind()

        ddlEntidadFinanciera.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlEntidadFinanciera.SelectedIndex = 0

    End Sub
    Private Sub Registrar()
        _entSubOperacion.IdSubOperacion = txtCodigo.Text
        _entSubOperacion.IdOperacion = hdnIdOperacion.Value
        _entSubOperacion.Idempresa = hdnEmpresa.Value
        _entSubOperacion.SubOperacion = txtDescripcion.Text
        _entSubOperacion.FechaCreacion = Date.Now
        '_entSubOperacion.Nivel = hdnId.Value
        _entSubOperacion.IdEntidad = ddlEntidadFinanciera.SelectedValue
        _entSubOperacion.IdMoneda = ddlMoneda.SelectedValue
        _objLNSubOperacion.entSubOperacion = _entSubOperacion
        _objLNSubOperacion.Registrar()
        txtCodigo.Text = _entSubOperacion.IdOperacion
        bindGrid()
        Limpiar()

    End Sub
    Private Sub Limpiar()
        txtDescripcion.Text = ""
        txtDescripcion.Focus()
        txtCodigo.Text = ""
        txtCodigo.Enabled = False


    End Sub
    Private Sub bindGrid()

        grDatos.DataSource = Nothing
        grDatos.DataBind()
        Dim objSeguridad As New ALVI_Security.General
        _entSubOperacion.Idempresa = hdnEmpresa.Value
        _entSubOperacion.IdOperacion = Left(hdnId.Value, 7)
        _entSubOperacion.Flag = "2"
        '_entSubOperacion.Nivel = ""
        _objLNSubOperacion.entSubOperacion = _entSubOperacion
        _objLNSubOperacion.Listar()
        grDatos.DataSource = _objLNSubOperacion.lstSubOperacion
        grDatos.DataBind()

    End Sub
    Private Sub Eliminar(ByVal id As String)
        _entSubOperacion.IdSubOperacion = id
        _objLNSubOperacion.entSubOperacion = _entSubOperacion
        _objLNSubOperacion.Eliminar()
        bindGrid()

    End Sub
    Protected Sub btnCerrar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar2.Click
        pnlRegistroTipoCambio.Visible = False
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Response.Redirect("FGCCOAQ.aspx?desc=" + objSeguridad.Encrypta(lblOperacion.Text) + "&idOperacion=" + objSeguridad.Encrypta(hdnIdOperacion.Value) + "")

    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        Registrar()
        pnlRegistroTipoCambio.Visible = False
        bindGrid()
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub

    Protected Sub grDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grDatos.RowCommand

        If e.CommandName = "ELIMINAR" Then
            Eliminar(e.CommandArgument.ToString)
        ElseIf e.CommandName = "EDITAR" Then
            Dim boton As Button = e.CommandSource
            Dim row As GridViewRow = boton.NamingContainer
            txtCodigo.Text = HttpUtility.HtmlDecode(row.Cells(0).Text).Trim
            txtDescripcion.Text = HttpUtility.HtmlDecode(row.Cells(4).Text).Trim
            ddlOperacion.SelectedValue = HttpUtility.HtmlDecode(row.Cells(5).Text).Trim
            ddlEmpresa.SelectedValue = HttpUtility.HtmlDecode(row.Cells(3).Text).Trim
            ddlEntidadFinanciera.SelectedValue = HttpUtility.HtmlDecode(row.Cells(10).Text).Trim
            ddlMoneda.SelectedValue = HttpUtility.HtmlDecode(row.Cells(8).Text).Trim
            pnlRegistroTipoCambio.Visible = True
        ElseIf e.CommandName = "DETALLE" Then
            Dim boton As Button = e.CommandSource
            Dim row As GridViewRow = boton.NamingContainer
            Response.Redirect("FGCCOAH.aspx?subOp=" + objSeguridad.Encrypta(row.Cells(0).Text) _
                           + "&desc2=" + objSeguridad.Encrypta(grDatos.Rows(row.RowIndex).Cells(4).Text) _
                           + "&empresa=" + objSeguridad.Encrypta(grDatos.Rows(row.RowIndex).Cells(3).Text) _
                           + "&desc=" + objSeguridad.Encrypta(lblOperacion.Text) + "&strFlag=" _
                           + objSeguridad.Encrypta("") + "&idOperacion=" + objSeguridad.Encrypta(hdnIdOperacion.Value) _
                           + "&desc1=" + objSeguridad.Encrypta(lblNivel1.Text) _
                           + "&flag=" + objSeguridad.Encrypta("1") + "&Id=" + objSeguridad.Encrypta(hdnId.Value) + "")
        End If

    End Sub

    Private Sub BindOperacion(ByVal empresa As String)
        _entOperacion.Idempresa = empresa
        _objLNOperacion.entOperacion = _entOperacion
        ' ddlOperacion.Items.Clear()

        _objLNOperacion.Listar()
        ddlOperacion.DataSource = _objLNOperacion.lstOperacion
        ddlOperacion.DataTextField = "Operacion"
        ddlOperacion.DataValueField = "IdOperacion"
        ddlOperacion.DataBind()
        ddlOperacion.SelectedValue = hdnOperacion.Value
    End Sub
    Private Sub BindEmpresa()
        _entEmpresa.IdUsuario = Session("Usuario").ToString
        _objLNEmpresa.entEmpresa = _entEmpresa
        _objLNEmpresa.Listar()
        ddlEmpresa.Items.Clear()
        ddlEmpresa.DataTextField = "RazonSocial"
        ddlEmpresa.DataValueField = "IdEmpresa"
        ddlEmpresa.DataSource = _objLNEmpresa.lstEmpresas
        ddlEmpresa.DataBind()
        ddlEmpresa.SelectedValue = hdnEmpresa.Value
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click

        pnlRegistroTipoCambio.Visible = True
        Limpiar()
    End Sub
End Class
