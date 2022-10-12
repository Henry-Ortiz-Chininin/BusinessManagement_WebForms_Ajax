Imports LN_ALVINET_CONTA.OPERACION
Imports EN_ALVINET_CONTA.OPERACION
Imports LN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_REGISTRO_ctlTipoCambio_Registro
    Inherits System.Web.UI.UserControl

    Private _entTipoCambio As New EN_TipoCambio

    Public Property entTipoCambio As EN_TipoCambio
        Get
            Return _entTipoCambio
        End Get
        Set(ByVal value As EN_TipoCambio)

            _entTipoCambio = value
            If _entTipoCambio.IdEmpresa <> "" Then
                ddlEmpresa.SelectedValue = _entTipoCambio.IdEmpresa
            End If


            ddlEmpresa.Enabled = False
            txtIdTipoCambio.Text = _entTipoCambio.IdTipoCambio
            txtIdTipoCambio.Enabled = False
            ddlMoneda.SelectedValue = _entTipoCambio.IdMoneda
            ddlMoneda.Enabled = False
            txtFecha.Text = _entTipoCambio.Fecha
            txtCompra.Text = _entTipoCambio.Compra
            txVenta.Text = _entTipoCambio.Venta
        End Set
    End Property

    Protected Sub Registrar()
        Dim objLNTipoCambio As New LN_TipoCambio
        Dim objENTipoCambio As New EN_TipoCambio

        objENTipoCambio.IdEmpresa = ddlEmpresa.SelectedValue
        objENTipoCambio.IdTipoCambio = txtIdTipoCambio.Text
        objENTipoCambio.Fecha = Convert.ToDateTime(txtFecha.Text)
        objENTipoCambio.Compra = txtCompra.Text
        objENTipoCambio.Venta = txVenta.Text
        objENTipoCambio.IdMoneda = ddlMoneda.SelectedValue


        objLNTipoCambio.entTipoCambio = objENTipoCambio
        If objLNTipoCambio.Registrar = True Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Registro completo');</script>")
            limpiar()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('Sucedio un error al Registrar.');</script>")
        End If
    End Sub

    Public Sub limpiar()
        ddlEmpresa.Enabled = False
        ddlEmpresa.SelectedIndex = 0
        txtIdTipoCambio.Text = ""
        txtFecha.Text = ""
        txtCompra.Text = ""
        txVenta.Text = ""
        ddlMoneda.SelectedIndex = 0
        ddlMoneda.Enabled = True
    End Sub

    Public Event cargarGrilla()
    Public Event Registrado()
    Public Event Cerrado()

    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        If ddlEmpresa.SelectedValue <> "" Then
            Registrar()
            RaiseEvent cargarGrilla()
            RaiseEvent Registrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert  ('Seleccione una Opcion');</script>")
        End If

    End Sub
    Private Sub SetEmpresa()
        If Session("Empresa") Is Nothing Then
        Else
            hdnEmpresa.Value = Session("Empresa").ToString
        End If
        If Session("nomEmpresa") Is Nothing Then
        Else
            hdnNomEmpresa.Value = Session("nomEmpresa").ToString
        End If


    End Sub
    Private Sub LlenarComboEmpresaInterno()
        Dim objLNEmpresa As New LN_Empresa
        Dim objENEmpresa As New EN_Empresa


        objLNEmpresa.ListaInterno(hdnEmpresa.Value, hdnNomEmpresa.Value)
        ddlEmpresa.Items.Clear()
        ddlEmpresa.DataTextField = "RazonSocial"
        ddlEmpresa.DataValueField = "IdEmpresa"
        ddlEmpresa.DataSource = objLNEmpresa.lstEmpresas
        ddlEmpresa.DataBind()
        ddlEmpresa.SelectedIndex = 0

    End Sub
    Public Sub llenarComboEmpresa()

        Dim objLNEmpresa As New LN_Empresa
        Dim objENEmpresa As New EN_Empresa

        objENEmpresa.IdUsuario = hdnUsuario.Value
        objLNEmpresa.entEmpresa = objENEmpresa

        ddlEmpresa.Items.Clear()

        objLNEmpresa.Listar()
        ddlEmpresa.DataTextField = "RazonSocial"
        ddlEmpresa.DataValueField = "IdEmpresa"
        ddlEmpresa.DataSource = objLNEmpresa.lstEmpresas
        ddlEmpresa.DataBind()

        ddlEmpresa.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlEmpresa.SelectedIndex = 0

    End Sub
    Public Sub llenarComboMoneda(ByVal ddlEmpresa As String)
        Dim objLNMoneda As New LN_Moneda
        Dim entMoneda As New EN_Moneda
        entMoneda.IdEmpresa = ddlEmpresa

        objLNMoneda.entMoneda = entMoneda

        ddlMoneda.Items.Clear()

        objLNMoneda.Listar()
        ddlMoneda.DataTextField = "Moneda"
        ddlMoneda.DataValueField = "IdMoneda"
        ddlMoneda.DataSource = objLNMoneda.lstMonedas
        ddlMoneda.DataBind()

        ddlMoneda.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlMoneda.SelectedIndex = 0
    End Sub
    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        If ddlEmpresa.SelectedValue <> "" Then
            Registrar()
            limpiar()
            RaiseEvent cargarGrilla()
            RaiseEvent Cerrado()
        Else
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert ('Seleccione una Opcion');</script>")
        End If
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        RaiseEvent Cerrado()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            txtIdTipoCambio.Enabled = False
            SetEmpresa()
            LlenarComboEmpresaInterno()
            llenarComboMoneda(ddlEmpresa.SelectedValue)
        End If
    End Sub


    Protected Sub lnktipok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnktipok.Click
        Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "Imprimir", "<script language='javascript'>window.open('http://www.sunat.gob.pe/cl-at-ittipcam/tcS01Alias','Reporte', 'resizable=1, height=350, width=600, top=0, left=0, scrollbars=1');</script>")



    End Sub



    Protected Sub ddlEmpresa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpresa.SelectedIndexChanged
        llenarComboMoneda(ddlEmpresa.SelectedValue)
    End Sub
End Class
