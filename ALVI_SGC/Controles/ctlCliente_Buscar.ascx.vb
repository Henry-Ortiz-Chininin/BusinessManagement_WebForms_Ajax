
Partial Class Controles_ctlCliente_Buscar
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
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            txtRazonSocial.Text = ""
            txtIdCliente.Text = ""
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
        
        Dim dtvDatos As New Data.DataView(objCliente.Datos, strCriterio, "var_IdCliente ASC", Data.DataViewRowState.OriginalRows)
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
            Else
                txtRazonSocial.Text = ""
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
        BuscarId()
    End Sub
    Protected Sub txtRazonSocial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRazonSocial.TextChanged
        BindLista()
    End Sub
    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdCliente.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
            RaiseEvent ControlUpdate(Me, EventArgs.Empty)
        End If
    End Sub
End Class
