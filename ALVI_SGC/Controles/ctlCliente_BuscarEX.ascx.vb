
Partial Class Controles_ctlCliente_BuscarEX
    Inherits System.Web.UI.UserControl

    Public Event ControlUpdate As EventHandler
    Public Event AgregarCliente()
    Public Property ObjlblIdCliente() As Label
        Get
            Return lblIdCliente
        End Get
        Set(ByVal value As Label)
            lblIdCliente = value
        End Set
    End Property
    Public Property ObjLblDireccion() As Label
        Get
            Return lblDireccion
        End Get
        Set(ByVal value As Label)
            lblDireccion = value
        End Set
    End Property
    Public Property ObjTxtDireccion() As TextBox
        Get
            Return txtDireccion
        End Get
        Set(ByVal value As TextBox)
            txtDireccion = value
        End Set
    End Property
    Public Property ObjLblContacto() As Label
        Get
            Return lblContacto
        End Get
        Set(ByVal value As Label)
            lblContacto = value
        End Set
    End Property
    Public Property ObjTxtContacto() As TextBox
        Get
            Return txtcontacto
        End Get
        Set(ByVal value As TextBox)
            txtcontacto = value
        End Set
    End Property
    Public Property IdCliente() As String
        Get
            Return txtIdCliente.Text
        End Get
        Set(ByVal value As String)
            txtIdCliente.Text = value
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return txtRazonSocial.Text
        End Get
        Set(ByVal value As String)
            txtRazonSocial.Text = value
        End Set
    End Property
    Public Sub Limpia()
        txtIdCliente.Text = ""
        txtRazonSocial.Text = ""
        txtcontacto.Text = ""
        txtDireccion.Text = ""
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            txtRazonSocial.Text = ""
            txtIdCliente.Text = ""
            txtDireccion.Text = ""
            txtcontacto.Text = ""
        End If
    End Sub
    Private Sub BindLista()
        Dim objCliente As New ALVI_LOGIC.Maestros.Ventas.Cliente
        Dim strCriterio As String = ""
        If txtIdCliente.Text <> "" Then
            strCriterio = "var_IdCliente LIKE '" & txtIdCliente.Text & "%'"
        ElseIf txtRazonSocial.Text <> "" Then
            strCriterio = "var_Descripcion LIKE '%" & txtRazonSocial.Text & "%'"
            strCriterio = Replace(strCriterio.ToUpper, " AND ", "")
            strCriterio = Replace(strCriterio.ToUpper, " OR ", "")
        End If

        objCliente.Listar()

        Dim dtvDatos As New Data.DataView(objCliente.Datos, strCriterio, "var_Descripcion ASC", Data.DataViewRowState.OriginalRows)
        dtlLista.DataSource = dtvDatos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub
    Public Sub BuscarId()
        If txtIdCliente.Text <> "" Then
            Dim objCliente As New ALVI_LOGIC.Maestros.Ventas.Cliente
            objCliente.IdCliente = txtIdCliente.Text
            If objCliente.Obtener() = True Then
                txtRazonSocial.Text = objCliente.Descripcion
                txtDireccion.Text = objCliente.Direccion
                txtcontacto.Text = objCliente.PersonaContacto
            Else
                txtRazonSocial.Text = ""
                txtDireccion.Text = ""
                txtcontacto.Text = ""
            End If
        End If
    End Sub
    Protected Sub btnBuscar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar1.Click
        BindLista()
    End Sub
    Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
        BindLista()
    End Sub
    Protected Sub txtIdCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdCliente.TextChanged
        txtRazonSocial.Text = ""
        If txtIdCliente.Text = "" Then
            pnlLista.Visible = False
        Else
            BuscarId()
        End If
    End Sub
    Protected Sub txtRazonSocial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazonSocial.TextChanged
        txtIdCliente.Text = ""
        If txtRazonSocial.Text = "" Then
            pnlLista.Visible = False
        Else
            BindLista()
        End If
    End Sub
    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdCliente.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
            RaiseEvent ControlUpdate(Me, EventArgs.Empty)
        End If
    End Sub
    Protected Sub btnAgregarCliente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAgregarCliente.Click
        RaiseEvent AgregarCliente()
    End Sub
End Class
