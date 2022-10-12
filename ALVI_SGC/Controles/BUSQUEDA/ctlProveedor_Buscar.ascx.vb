
Partial Class CONTROLES_BUSQUEDA_ctlProveedor_Buscar
    Inherits System.Web.UI.UserControl


    Public Property IdProveedor() As String
        Get
            Return txtIdProveedor.Text
        End Get
        Set(ByVal value As String)
            txtIdProveedor.Text = value
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
        txtRazonSocial.Text = ""
        txtIdProveedor.Text = ""
        pnlLista.Visible = False

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False

        End If
    End Sub


    Private Sub BindLista()
        Dim objProveedor As New ALVI_LOGIC.Maestros.Compras.Proveedor

        objProveedor.IdProveedor = txtIdProveedor.Text
        objProveedor.Descripcion = txtRazonSocial.Text


        objProveedor.Buscar1()
        Dim dtbDatos As Data.DataTable = objProveedor.Datos

        Dim dtvDatos As New Data.DataView(dtbDatos, "", "var_IdProveedor", Data.DataViewRowState.OriginalRows)
        dtlLista.DataSource = dtvDatos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub


    Public Sub BuscarId()
        If txtIdProveedor.Text <> "" Then
            Dim objProveedor As New ALVI_LOGIC.Maestros.Compras.Proveedor
            objProveedor.IdProveedor = txtIdProveedor.Text
            If objProveedor.Obtener() = True Then
                txtRazonSocial.Text = objProveedor.Descripcion

            Else
                txtRazonSocial.Text = ""

            End If

        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindLista()
    End Sub

    Protected Sub txtIdProveedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdProveedor.TextChanged
        BuscarId()
    End Sub

    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdProveedor.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
        End If
    End Sub

End Class
