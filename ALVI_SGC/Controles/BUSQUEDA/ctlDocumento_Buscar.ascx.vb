Imports LN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.GENERAL

Partial Class CONTROLES_BUSQUEDA_ctlDocumento_Buscar
    Inherits System.Web.UI.UserControl

    Public Property Titulo As String
        Get
            Return lblTitulo.Text
        End Get
        Set(ByVal value As String)
            lblTitulo.Text = value
        End Set
    End Property

    Public Property codTipoDocumento As String
        Get
            Return ddlTipoDocumento.SelectedValue

        End Get
        Set(ByVal value As String)
            llenarComboTipoDocumento()
            ddlTipoDocumento.SelectedValue = value
        End Set
    End Property


    Public Property Habilitar() As Boolean
        Get
            Return ddlTipoDocumento.Enabled
            Return txtNumeroDocumento.Enabled

        End Get
        Set(ByVal value As Boolean)
            ddlTipoDocumento.Enabled = value
            txtNumeroDocumento.Enabled = value
            btnBuscar2.Enabled = value
        End Set
    End Property


    Public Property Indice As String
        Get
            Return ddlTipoDocumento.SelectedIndex
        End Get
        Set(ByVal value As String)
            ddlTipoDocumento.SelectedIndex = value
        End Set
    End Property



    Public Property NumeroDocumento As String
        Get
            Return txtNumeroDocumento.Text
        End Get
        Set(ByVal value As String)
            txtNumeroDocumento.Text = value
        End Set
    End Property

    Public Sub llenarComboTipoDocumento()

        Dim objLNTipoDocumento As New LN_TipoDocumento
        ddlTipoDocumento.Items.Clear()
        Dim objENTipoDocumento As New EN_TipoDocumento
        objENTipoDocumento.IdEmpresa = hdnIdEmpresa.Value
        objLNTipoDocumento.entTipoDocumento = objENTipoDocumento
        objLNTipoDocumento.Listar()
        ddlTipoDocumento.DataValueField = "IdTipoDocumento"
        ddlTipoDocumento.DataTextField = "TipoDocumento"
        ddlTipoDocumento.DataSource = objLNTipoDocumento.lstTipoDocumentos
        ddlTipoDocumento.DataBind()
        ddlTipoDocumento.Items.Insert(0, New ListItem("Seleccione>>>", ""))
    End Sub

    Public Sub Limpiar()
        ddlTipoDocumento.SelectedIndex = 0
        txtNumeroDocumento.Text = ""
        pnlLista.Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            hdnIdEmpresa.Value = Session("Empresa")

            llenarComboTipoDocumento()




            'Limpiar()
        End If
    End Sub

    Public Sub Lista()

        Dim objLNComprobante As New LN_Comprobante
        Dim objENComprobante As New EN_Comprobante

        objENComprobante.IdTipoDocumento = ddlTipoDocumento.SelectedValue
        objENComprobante.IdComprobanteVenta = txtNumeroDocumento.Text

        objLNComprobante.entComprobante = objENComprobante
        objLNComprobante.BuscarDocumento()
        dtlLista.DataSource = objLNComprobante.lstComprobantes

        dtlLista.DataBind()
        pnlLista.Visible = True

    End Sub

    Private Sub BindLista()
        Lista()

    End Sub

    Public Sub Obtener()

        Dim objLNComprobante As New LN_Comprobante
        Dim objENComprobante As New EN_Comprobante

        If txtNumeroDocumento.Text <> "" Then
            objENComprobante.IdComprobanteVenta = txtNumeroDocumento.Text

            objLNComprobante.entComprobante = objENComprobante

            If objLNComprobante.BuscarDocumento() = True Then
                ddlTipoDocumento.SelectedValue = objLNComprobante.lstComprobantes(0).IdTipoDocumento
            End If
        End If

    End Sub

    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand

        If e.CommandName = "Seleccionar" Then
            txtNumeroDocumento.Text = e.CommandArgument.ToString
            Obtener()
            pnlLista.Visible = False
        End If

    End Sub

    Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
        BindLista()
        'Limpiar()
    End Sub

End Class