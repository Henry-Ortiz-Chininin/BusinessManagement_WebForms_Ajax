
Partial Class CONTROLES_BUSQUEDA_ctlCliente_Buscar
    Inherits System.Web.UI.UserControl

    Public Event ControlUpdate As EventHandler

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
        pnlLista.Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Limpia()
        End If
    End Sub
    Private Sub BindLista()
        Dim objCliente As New ALVI_LOGIC.Maestros.Ventas.Cliente
        
        'objCliente.IdCliente = txtIdCliente.Text
        objCliente.Descripcion = txtRazonSocial.Text
        objCliente.Buscar()

        If objCliente.Datos.Rows.Count = 1 Then
            txtIdCliente.Text = objCliente.IdCliente.ToString.Trim()
            txtRazonSocial.Text = objCliente.Descripcion.ToString.Trim()
            pnlLista.Visible = False
        Else
            dtlLista.DataSource = objCliente.Datos
            dtlLista.DataBind()
            pnlLista.Visible = True
        End If
        
    End Sub
    Public Sub BuscarId()
        If txtIdCliente.Text <> "" Then
            Dim objCliente As New ALVI_LOGIC.Maestros.Ventas.Cliente
            objCliente.IdCliente = txtIdCliente.Text
            If objCliente.Obtener() = True Then
                txtRazonSocial.Text = objCliente.Descripcion
            Else
                txtRazonSocial.Text = ""
            End If
        End If
        pnlLista.Visible = False
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindLista()
    End Sub
    
    Protected Sub txtIdCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdCliente.TextChanged
        BuscarId()
    End Sub
   
    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdCliente.Text = e.CommandArgument.ToString
            BuscarId()
            RaiseEvent ControlUpdate(Me, EventArgs.Empty)
        End If
    End Sub

    Protected Sub txtRazonSocial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazonSocial.TextChanged
        txtIdCliente.Text = ""
        If txtRazonSocial.Text <> "" Then
            BindLista()
        Else
            pnlLista.Visible = False
        End If
    End Sub
End Class
