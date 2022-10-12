Imports EN_ALVINET_CONTA
Imports LN_ALVINET_CONTA
Imports LN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.GENERAL
Imports AD_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.CONFIG

Partial Class CONFIG_FGCCOAQ
    Inherits System.Web.UI.Page
    Dim _objLNSubOperacion As New LN_SubOperacion
    Dim _entSubOperacion As New EN_SubOperacion
    Dim _objLNEmpresa As New LN_Empresa
    Dim _entEmpresa As New EN_Empresa
    Dim _objLNOperacion As New AD_Operacion
    Dim _entOperacion As New EN_Operacion


    Private objSeguridad As New ALVI_Security.General
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlRegistroTipoCambio.Visible = False
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            hdnOperacion.Value = objSeguridad.Decrypta(Request.QueryString("IdOperacion"))

            If Request.QueryString("strFlag") Is Nothing Then
                hdnflag.Value = "0"

            Else
                hdnflag.Value = Request.QueryString("strFlag")

            End If

            bindGrid()
            BindEmpresa()
            BindOperacion(hdnEmpresa.Value)


        End If
    End Sub

    Private Sub BindOperacion(ByVal empresa As String)
        _entOperacion.Idempresa = empresa
        _objLNOperacion.entOperacion = _entOperacion
        ' ddlOperacion.Items.Clear()

        _objLNOperacion.Listar()
        ddlOperacion.DataSource = _objLNOperacion.lstOperacion
        ddlOperacion.DataTextField = "Descripcion"
        ddlOperacion.DataValueField = "IdOperacion"
        ddlOperacion.DataBind()

    End Sub
    Private Sub BindEmpresa()
        _entEmpresa.IdUsuario = hdnUsuario.Value
        _objLNEmpresa.entEmpresa = _entEmpresa
        _objLNEmpresa.Listar()
        ddlEmpresa.Items.Clear()
        ddlEmpresa.DataTextField = "RazonSocial"
        ddlEmpresa.DataValueField = "IdEmpresa"
        ddlEmpresa.DataSource = _objLNEmpresa.lstEmpresas
        ddlEmpresa.DataBind()
        ddlEmpresa.Items.Insert(0, New ListItem("Seleccione>>>", ""))
    End Sub

    Private Sub Registrar()
        _entSubOperacion.IdSubOperacion = txtCodigo.Text
        _entSubOperacion.IdOperacion = ddlOperacion.SelectedValue
        _entSubOperacion.Idempresa = ddlEmpresa.SelectedValue
        _entSubOperacion.SubOperacion = txtDescripcion.Text
        _entSubOperacion.FechaCreacion = Date.Now
        _entSubOperacion.IdEntidad = ""
        _entSubOperacion.IdMoneda = ""

        'If hdnUbicacion.Value = "0" Then
        '    _entSubOperacion.Nivel = hdnNivel.Value + "0"
        'Else
        '    _entSubOperacion.Nivel = "0"
        'End If
        _objLNSubOperacion.entSubOperacion = _entSubOperacion
        _objLNSubOperacion.Registrar()
        txtCodigo.Text = _entSubOperacion.IdOperacion

        If grDatos.Rows.Count > 0 Then
            bindGrid()
        Else
            bindGrid()
        End If


        Limpiar()

    End Sub
    Private Sub Limpiar()
        'ddlEmpresa.SelectedIndex = 0
        'ddlOperacion.SelectedIndex = 0
        txtDescripcion.Text = ""
        txtDescripcion.Focus()
        txtCodigo.Text = ""
        txtCodigo.Enabled = False
        ddlEmpresa.Enabled = False
        ddlOperacion.Enabled = False

    End Sub
    Private Sub Eliminar(ByVal id As String)
        _entSubOperacion.IdSubOperacion = id
        _objLNSubOperacion.entSubOperacion = _entSubOperacion
        _objLNSubOperacion.Eliminar()
        bindGrid()

    End Sub
    Private Sub bindGrid()
        grDatos.DataSource = Nothing
        grDatos.DataBind()
        Dim objSeguridad As New ALVI_Security.General
        _entSubOperacion.Idempresa = hdnEmpresa.Value
        _entSubOperacion.IdOperacion = hdnNivel.Value
        _entSubOperacion.Flag = "1"
        If Request.QueryString("operacion") Is Nothing Then
        Else
            _entSubOperacion.IdOperacion = objSeguridad.Decrypta(Request.QueryString("operacion").ToString)
            hdnOperacion.Value = _entSubOperacion.IdOperacion
            ddlOperacion.SelectedValue = _entSubOperacion.IdOperacion
        End If
        If Request.QueryString("idOperacion") Is Nothing Then
        Else
            _entSubOperacion.IdOperacion = objSeguridad.Decrypta(Request.QueryString("idOperacion").ToString)

        End If


        If Request.QueryString("desc") Is Nothing Then
            lblOperacion.Text = ""
        Else
            lblOperacion.Text = objSeguridad.Decrypta(Request.QueryString("desc").ToString)
        End If

        _objLNSubOperacion.entSubOperacion = _entSubOperacion
        _objLNSubOperacion.Listar()
        grDatos.DataSource = _objLNSubOperacion.lstSubOperacion
        grDatos.DataBind()

    End Sub

    Private Sub bindGrid2()

    End Sub

    Protected Sub grDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grDatos.RowCommand
        If e.CommandName = "ELIMINAR" Then

            Dim row As GridViewRow = grDatos.Rows(e.CommandArgument)
            Eliminar(grDatos.Rows(row.RowIndex).Cells(0).Text)

        End If
        If e.CommandName = "EDITAR" Then
            Dim row As GridViewRow = grDatos.Rows(e.CommandArgument)
            Dim btnEdit As Button = CType(e.CommandSource, Button)
            Dim fila As GridViewRow = CType(btnEdit.NamingContainer, GridViewRow)
            pnlRegistroTipoCambio.Visible = True
            BindEmpresa()
            ddlEmpresa.SelectedValue = fila.Cells(3).Text
            txtCodigo.Text = HttpUtility.HtmlDecode(fila.Cells(0).Text)
            BindOperacion(ddlEmpresa.SelectedValue)
            ddlOperacion.SelectedValue = fila.Cells(5).Text
            txtDescripcion.Text = HttpUtility.HtmlDecode(fila.Cells(4).Text)
            ddlEmpresa.Enabled = False
            ddlOperacion.Enabled = False
            txtCodigo.Enabled = False
        End If

        If e.CommandName = "DETALLE" Then
            Dim boton As Button = e.CommandSource
            Dim row As GridViewRow = CType(boton.NamingContainer, GridViewRow)

            Dim texto As String = row.Cells(0).Text + "&desc=" + row.Cells(4).Text
            Dim strId As String = objSeguridad.Encrypta(row.Cells(0).Text) & objSeguridad.Encrypta(row.Cells(8).Text)
            Dim strTitulo2 As String = objSeguridad.Encrypta(row.Cells(4).Text)
            Dim strTitulo As String = objSeguridad.Encrypta(lblOperacion.Text)
            Dim strIdEmpresa As String = objSeguridad.Encrypta(row.Cells(3).Text)
            Dim strIdOperacion As String = objSeguridad.Encrypta(row.Cells(5).Text)

            Dim strEmpresa As String = objSeguridad.Encrypta(ddlEmpresa.SelectedItem.ToString)
            Dim strOperacion As String = objSeguridad.Encrypta(ddlOperacion.SelectedItem.Text.ToString)

            Dim strTesoreria As String = objSeguridad.Encrypta(lblOperacion.Text)
            lblNivel1.Text = ""
            Dim strURL As String = String.Empty
            
            Response.Redirect("FGCCOAH.aspx?subOp=" + objSeguridad.Encrypta(grDatos.Rows(row.RowIndex).Cells(0).Text) _
                                + "&desc=" + objSeguridad.Encrypta(lblOperacion.Text) _
                                + "&empresa=" + objSeguridad.Encrypta(grDatos.Rows(row.RowIndex).Cells(3).Text) _
                                + "&ope=" + objSeguridad.Encrypta(lblOperacion.Text) + "&strFlag=" _
                                + objSeguridad.Encrypta(hdnflag.Value) + "&idOperacion=" _
                                + objSeguridad.Encrypta(hdnOperacion.Value) + "&desc1=" + strTitulo2 + "")

        End If


    End Sub

    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        pnlRegistroTipoCambio.Visible = False
        Registrar()
    End Sub



    Protected Sub btnCerrar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar2.Click
        pnlRegistroTipoCambio.Visible = False
    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        pnlRegistroTipoCambio.Visible = True
        Limpiar()
        ddlEmpresa.SelectedIndex = 1
        ddlOperacion.SelectedValue = hdnOperacion.Value

    End Sub

    Protected Sub ddlEmpresa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpresa.SelectedIndexChanged
        BindOperacion(ddlEmpresa.SelectedValue)
    End Sub

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        Registrar()
        Limpiar()
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click

        If hdnUbicacion.Value = "0" Then

            grDatos.Visible = True
            lblNivel1.Text = ""
            hdnNivel.Value = ""
            bindGrid()
        ElseIf hdnUbicacion.Value = "1" Then
            lblNivel1.Text = ""
            bindGrid()
        Else
            Response.Redirect("FGCCOAE.aspx?")
        End If


    End Sub

    Protected Sub grDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grDatos.PageIndexChanging
        grDatos.PageIndex = e.NewPageIndex
        bindGrid()
    End Sub
End Class
