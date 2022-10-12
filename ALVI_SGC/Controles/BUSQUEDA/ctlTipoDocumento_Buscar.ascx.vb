
Imports EN_ALVINET_CONTA.GENERAL
Imports LN_ALVINET_CONTA.GENERAL
Partial Class CONTROLES_BUSQUEDA_ctlTipoDocumento_Buscar
    Inherits System.Web.UI.UserControl

    Public Property descripcionTipoDocumento As String
        Get
            Return txtDescripcion.Text
        End Get
        Set(ByVal value As String)
            txtDescripcion.Text = value
        End Set
    End Property

    Public Property IdtipoDocumento() As String
        Get
            Return hdnIdTipoDocumento.Value
        End Get
        Set(ByVal value As String)
            hdnIdTipoDocumento.Value = value
        End Set
    End Property

    Public Property ctl_txtDescripcionCC As TextBox
        Get
            Return txtDescripcion
        End Get
        Set(ByVal value As TextBox)
            txtDescripcion = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False

        End If
    End Sub
    Public Sub EnlazarLista()

        Dim objLNTipoDocuemento As New LN_TipoDocumento
        Dim objENTipoDocuemento As New EN_TipoDocumento


        objENTipoDocuemento.TipoDocumento = txtDescripcion.Text

        objLNTipoDocuemento.entTipoDocumento = objENTipoDocuemento

        If objLNTipoDocuemento.Buscar() Then
            hdnIdTipoDocumento.Value = objLNTipoDocuemento.lstTipoDocumentos(0).IdTipoDocumento
            dtlLista.DataSource = objLNTipoDocuemento.lstTipoDocumentos
            dtlLista.DataBind()
            pnlLista.Visible = True
        End If

    End Sub



    Public Sub LimpiarCC()

        txtDescripcion.Text = ""
    End Sub


    Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
        EnlazarLista()
        LimpiarCC()
    End Sub

    Protected Sub txtDescripcion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        EnlazarLista()
    End Sub

    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtDescripcion.Text = e.CommandArgument.ToString
            EnlazarLista()
            pnlLista.Visible = False
        End If
    End Sub
End Class
